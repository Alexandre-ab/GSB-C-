# 5. Réalisation technique

## 5.1 Choix techniques et justifications

### 5.1.1 Technologies retenues

| Technologie | Version | Justification |
|-------------|---------|---------------|
| **C#** | 12 (.NET 8) | Langage orienté objet robuste, performant, adapté aux applications Windows. |
| **Windows Forms** | .NET 8 | Framework mature pour interfaces desktop Windows, simple à utiliser, adapté au périmètre du projet. |
| **MySQL** | 8.x | SGBD relationnel open-source, robuste, performant, adapté aux applications de gestion. |
| **ADO.NET (MySql.Data)** | 9.5.0 | Bibliothèque officielle pour connexion MySQL en C#, légère, contrôle total des requêtes SQL. |
| **iTextSharp** | 5.5.13.4 | Bibliothèque mature et éprouvée pour génération de PDF en C#. |

### 5.1.2 Justification du choix de Windows Forms

| Critère | Windows Forms | WPF | Blazor Desktop |
|---------|---------------|-----|----------------|
| **Courbe d'apprentissage** | ✅ Faible | ⚠️ Moyenne | ⚠️ Moyenne |
| **Performance** | ✅ Excellente | ✅ Excellente | ⚠️ Moyenne |
| **Design moderne** | ⚠️ Basique | ✅ Avancé | ✅ Avancé |
| **Maturité** | ✅ Très mature | ✅ Mature | ⚠️ Récent |
| **Déploiement** | ✅ Simple | ✅ Simple | ⚠️ Plus complexe |
| **Adapté au projet** | ✅ Oui | ⚠️ Overkill | ⚠️ Overkill |

**Conclusion** : Windows Forms est le choix optimal pour ce projet (application de gestion desktop simple, délai court, équipe débutante).

### 5.1.3 ADO.NET vs Entity Framework

| Critère | ADO.NET | Entity Framework Core |
|---------|---------|----------------------|
| **Contrôle SQL** | ✅ Total | ⚠️ Abstrait (LINQ) |
| **Performance** | ✅ Optimale | ⚠️ Overhead possible |
| **Courbe d'apprentissage** | ✅ Simple | ⚠️ Moyenne |
| **Maintenance** | ⚠️ SQL manuel | ✅ Migrations |
| **Adapté au projet** | ✅ Oui | ⚠️ Trop lourd |

**Conclusion** : ADO.NET est suffisant pour ce projet (peu de tables, requêtes simples, besoin de contrôle sur les requêtes).

---

## 5.2 Implémentation de l'authentification

### 5.2.1 Processus d'authentification

```csharp
// Dao/UserDAO.cs (extrait simplifié et corrigé)
public User Login(string email, string password)
{
    using (var connection = db.GetConnection())
    {
        try
        {
            connection.Open();

            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = connection;
            
            // Requête paramétrée pour prévenir l'injection SQL
            myCommand.CommandText = @"SELECT * FROM Users 
                                      WHERE email = @email 
                                      AND password = SHA2(@password, 256)";
            
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@password", password);

            using var myReader = myCommand.ExecuteReader();
            {
                if (myReader.Read())
                {
                    // Mapping des colonnes vers objet User
                    int id = myReader.GetInt32("id_users");
                    string name = myReader.GetString("lastname");
                    string firstname = myReader.GetString("firstname");
                    string role = myReader.GetString("role");

                    return new User(id, name, firstname, email, "", role);
                }
                else
                {
                    return null; // Identifiants incorrects
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving user: " + ex.Message);
        }
    }
}
```

### 5.2.2 Points clés de l'implémentation

1. **Requêtes paramétrées** : `@email` et `@password` empêchent l'injection SQL.
2. **Hash SHA-256** : le mot de passe est hashé côté BD (amélioration recommandée : utiliser bcrypt côté C#).
3. **Gestion des erreurs** : exceptions capturées et relancées avec contexte.
4. **Retour null** : si aucun utilisateur trouvé, retour `null` au lieu d'une exception.

### 5.2.3 Améliorations recommandées (sécurité)

**Problème actuel** : SHA-256 seul (sans sel) est vulnérable aux attaques par rainbow tables.

**Solution recommandée** : utiliser bcrypt avec sel.

```csharp
// Installation du package : dotnet add package BCrypt.Net-Next

using BCrypt.Net;

// Lors de la création d'un utilisateur (registration)
public bool Add(User user)
{
    string hashedPassword = BCrypt.HashPassword(user.Password);
    
    // Ensuite, stocker hashedPassword dans la BD
    myCommand.CommandText = @"INSERT INTO Users (..., password, ...) 
                              VALUES (..., @password, ...)";
    myCommand.Parameters.AddWithValue("@password", hashedPassword);
    // ...
}

// Lors de l'authentification (login)
public User Login(string email, string password)
{
    // 1. Récupérer l'utilisateur par email
    myCommand.CommandText = "SELECT * FROM Users WHERE email = @email";
    // ...
    
    if (myReader.Read())
    {
        string storedHash = myReader.GetString("password");
        
        // 2. Vérifier le mot de passe avec bcrypt
        if (BCrypt.Verify(password, storedHash))
        {
            return new User(...);
        }
        else
        {
            return null;
        }
    }
}
```

---

## 5.3 Gestion des prescriptions avec transactions

### 5.3.1 Problématique

Une prescription contient :
1. Les informations de base (patient, date, notes) → table `Prescription`.
2. Les médicaments associés (quantité, posologie) → table `Appartient`.

**Risque** : si l'insertion de `Prescription` réussit mais que l'insertion dans `Appartient` échoue, on se retrouve avec une prescription vide.

**Solution** : utiliser une **transaction** pour garantir l'atomicité.

### 5.3.2 Implémentation avec transaction

```csharp
// Dao/PrescriptionDao.cs (version améliorée)
public bool AddWithMedicines(Prescription prescription, List<Appartient> medicaments)
{
    using (var connection = db.GetConnection())
    {
        connection.Open();
        MySqlTransaction transaction = connection.BeginTransaction();
        
        try
        {
            // 1. Insérer la prescription
            MySqlCommand cmdPrescription = new MySqlCommand();
            cmdPrescription.Connection = connection;
            cmdPrescription.Transaction = transaction;
            cmdPrescription.CommandText = @"INSERT INTO Prescription 
                (id_patient, id_users, date, notes) 
                VALUES (@patientId, @userId, @date, @notes);
                SELECT LAST_INSERT_ID();";
            
            cmdPrescription.Parameters.AddWithValue("@patientId", prescription.PatientId);
            cmdPrescription.Parameters.AddWithValue("@userId", prescription.UserId);
            cmdPrescription.Parameters.AddWithValue("@date", prescription.Date);
            cmdPrescription.Parameters.AddWithValue("@notes", prescription.Notes);
            
            // Récupérer l'ID de la prescription insérée
            int prescriptionId = Convert.ToInt32(cmdPrescription.ExecuteScalar());
            
            // 2. Insérer les médicaments associés
            foreach (var med in medicaments)
            {
                MySqlCommand cmdAppartient = new MySqlCommand();
                cmdAppartient.Connection = connection;
                cmdAppartient.Transaction = transaction;
                cmdAppartient.CommandText = @"INSERT INTO Appartient 
                    (id_prescription, id_medicine, quantity, posology) 
                    VALUES (@prescId, @medId, @qty, @posology)";
                
                cmdAppartient.Parameters.AddWithValue("@prescId", prescriptionId);
                cmdAppartient.Parameters.AddWithValue("@medId", med.MedicineId);
                cmdAppartient.Parameters.AddWithValue("@qty", med.Quantity);
                cmdAppartient.Parameters.AddWithValue("@posology", med.Posology);
                
                cmdAppartient.ExecuteNonQuery();
            }
            
            // 3. Valider la transaction
            transaction.Commit();
            return true;
        }
        catch (Exception ex)
        {
            // 4. En cas d'erreur, annuler toutes les opérations
            transaction.Rollback();
            throw new Exception("Error creating prescription: " + ex.Message);
        }
    }
}
```

### 5.3.3 Avantages de cette approche

- **Atomicité** : soit tout est inséré, soit rien (pas de prescription orpheline).
- **Cohérence** : la base reste dans un état cohérent même en cas d'erreur.
- **Rollback automatique** : en cas d'exception, la transaction est annulée.

---

## 5.4 Export PDF avec iTextSharp

### 5.4.1 Implémentation actuelle (simplifiée)

```csharp
// Utils/ExporterPDF.cs (extrait)
using iTextSharp.text;
using iTextSharp.text.pdf;

public class ExporterPDF
{
    public bool ExporterPrescription(Prescription p, Patient patient, 
                                      List<Appartient> medicaments, string cheminFichier)
    {
        try
        {
            // 1. Initialisation du document
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
            doc.Open();

            // 2. En-tête
            var fontTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.BLUE);
            Paragraph titre = new Paragraph("ORDONNANCE GSB", fontTitre);
            titre.Alignment = Element.ALIGN_CENTER;
            titre.SpacingAfter = 30;
            doc.Add(titre);

            // 3. Informations patient
            var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var fontGras = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            
            doc.Add(new Paragraph($"Date : {p.Date.ToShortDateString()}", fontNormal));
            doc.Add(new Paragraph($"Patient : {patient.Firstname} {patient.Lastname}", fontGras));
            doc.Add(new Paragraph($"Né(e) le : {patient.Birthdate.ToShortDateString()}", fontNormal));
            doc.Add(new Paragraph("\n"));

            // 4. Tableau des médicaments
            PdfPTable table = new PdfPTable(4); // 4 colonnes
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 3f, 2f, 1.5f, 3f }); // Largeurs relatives

            // En-têtes de colonnes
            table.AddCell(new PdfPCell(new Phrase("Médicament", fontGras)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            table.AddCell(new PdfPCell(new Phrase("Dosage", fontGras)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            table.AddCell(new PdfPCell(new Phrase("Quantité", fontGras)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            table.AddCell(new PdfPCell(new Phrase("Posologie", fontGras)) { BackgroundColor = BaseColor.LIGHT_GRAY });

            // Lignes des médicaments
            foreach (var app in medicaments)
            {
                // Récupérer les infos du médicament depuis la BD
                Medicine med = medicineDao.GetById(app.MedicineId);
                
                table.AddCell(new Phrase(med.Name, fontNormal));
                table.AddCell(new Phrase(med.Dosage, fontNormal));
                table.AddCell(new Phrase(app.Quantity.ToString(), fontNormal));
                table.AddCell(new Phrase(app.Posology, fontNormal));
            }

            doc.Add(table);

            // 5. Notes
            if (!string.IsNullOrEmpty(p.Notes))
            {
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("Notes :", fontGras));
                doc.Add(new Paragraph(p.Notes, fontNormal));
            }

            // 6. Signature
            doc.Add(new Paragraph("\n\n"));
            Paragraph signature = new Paragraph($"Prescripteur : Dr. {UserSession.CurrentUser.Firstname} {UserSession.CurrentUser.Lastname}", fontNormal);
            signature.Alignment = Element.ALIGN_RIGHT;
            doc.Add(signature);

            // 7. Fermeture
            doc.Close();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur PDF : " + ex.Message);
            return false;
        }
    }
}
```

### 5.4.2 Points clés

1. **Document A4** : format standard pour les ordonnances.
2. **Mise en forme** : polices, couleurs, alignements pour un rendu professionnel.
3. **Tableau** : présentation structurée des médicaments.
4. **Gestion des erreurs** : try/catch pour éviter les crashs si le fichier est ouvert ailleurs.

---

## 5.5 Validation des données

### 5.5.1 Validation côté UI (exemple : ajout patient)

```csharp
// Forms/FormAddpatient.cs
private void btnSave_Click(object sender, EventArgs e)
{
    // 1. Validation des champs obligatoires
    if (string.IsNullOrWhiteSpace(txtFirstname.Text))
    {
        MessageBox.Show("Le prénom est obligatoire.", "Validation", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtFirstname.Focus();
        return;
    }

    if (string.IsNullOrWhiteSpace(txtLastname.Text))
    {
        MessageBox.Show("Le nom est obligatoire.", "Validation", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtLastname.Focus();
        return;
    }

    // 2. Validation du format téléphone (optionnel mais recommandé)
    if (!string.IsNullOrEmpty(txtPhone.Text) && !IsValidPhoneNumber(txtPhone.Text))
    {
        MessageBox.Show("Format de téléphone invalide (attendu : 06XXXXXXXX).", 
            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtPhone.Focus();
        return;
    }

    // 3. Création de l'objet et appel DAO
    try
    {
        Patient patient = new Patient(
            0,
            txtFirstname.Text.Trim(),
            txtLastname.Text.Trim(),
            dtpBirthdate.Value,
            txtAddress.Text.Trim(),
            txtPhone.Text.Trim()
        );

        PatientsDao dao = new PatientsDao();
        bool success = dao.Add(patient);

        if (success)
        {
            MessageBox.Show("Patient ajouté avec succès.", "Succès", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur : {ex.Message}", "Erreur", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

private bool IsValidPhoneNumber(string phone)
{
    // Regex simple : 06 ou 07 suivi de 8 chiffres
    return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^0[67]\d{8}$");
}
```

---

## 5.6 Difficultés rencontrées et solutions

### 5.6.1 Problème : Gestion des FK lors de la suppression

**Contexte** : suppression d'un patient alors qu'il a des prescriptions.

**Erreur** : `Cannot delete or update a parent row: a foreign key constraint fails`

**Solution** :
1. Option 1 (adoptée) : CASCADE sur la FK `Prescription.id_patient` → suppression du patient supprime ses prescriptions.
2. Option 2 : Soft delete (marquer le patient comme inactif au lieu de le supprimer).

```sql
-- Modification de la contrainte FK
ALTER TABLE Prescription 
DROP FOREIGN KEY fk_prescription_patient;

ALTER TABLE Prescription 
ADD CONSTRAINT fk_prescription_patient 
FOREIGN KEY (id_patient) REFERENCES Patients(id_patient) 
ON DELETE CASCADE ON UPDATE CASCADE;
```

### 5.6.2 Problème : Hash de mot de passe (SHA-256 vs bcrypt)

**Contexte** : implémentation initiale avec SHA-256 côté MySQL.

**Limitation** : SHA-256 sans sel est vulnérable.

**Solution recommandée** : migrer vers bcrypt côté C# (voir section 5.2.3).

### 5.6.3 Problème : Performance des requêtes (N+1)

**Contexte** : chargement d'une prescription avec ses médicaments.

**Code initial** :
```csharp
List<Appartient> medicaments = appartientDao.GetByPrescriptionId(prescriptionId);
foreach (var app in medicaments)
{
    Medicine med = medicineDao.GetById(app.MedicineId); // N requêtes
}
```

**Problème** : 1 requête pour les associations + N requêtes pour les médicaments.

**Solution** : JOIN dans la requête SQL pour récupérer tout en une fois.

```sql
SELECT a.*, m.name, m.dosage, m.molecule, m.description
FROM Appartient a
JOIN Medicine m ON a.id_medicine = m.id_medicine
WHERE a.id_prescription = @prescriptionId;
```

---

## 5.7 Extraits de code significatifs

### 5.7.1 Méthode CRUD générique (pattern DAO)

```csharp
// Dao/PatientsDao.cs (extrait)
public List<Patient> GetAll()
{
    List<Patient> patients = new List<Patient>();
    
    using (var connection = db.GetConnection())
    {
        try
        {
            connection.Open();
            
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Patients ORDER BY lastname, firstname", connection);
            
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    patients.Add(new Patient(
                        reader.GetInt32("id_patient"),
                        reader.GetString("firstname"),
                        reader.GetString("lastname"),
                        reader.GetDateTime("birthdate"),
                        reader.GetString("address"),
                        reader.GetString("phone")
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving patients: " + ex.Message);
        }
    }
    
    return patients;
}
```

### 5.7.2 Gestion de session utilisateur

```csharp
// Models/UserSession.cs
public static class UserSession
{
    public static User? CurrentUser { get; private set; }
    public static bool IsAuthenticated => CurrentUser != null;

    public static void Login(User user)
    {
        CurrentUser = user;
    }

    public static void Logout()
    {
        CurrentUser = null;
    }

    public static bool IsAdmin => CurrentUser?.Role == "admin";
    public static bool IsMedecin => CurrentUser?.Role == "medecin";
}
```

---

## 5.8 Tests unitaires (recommandation)

**Note** : l'application actuelle ne contient pas de tests unitaires. Voici une proposition pour une V2.

### 5.8.1 Structure de test recommandée

```
GSB.Tests/
├── DAO/
│   ├── UserDAOTests.cs
│   ├── PatientsDAOTests.cs
│   └── PrescriptionDAOTests.cs
├── Models/
│   └── UserSessionTests.cs
└── Utils/
    └── ExporterPDFTests.cs
```

### 5.8.2 Exemple de test unitaire (xUnit + Moq)

```csharp
using Xunit;
using Moq;

public class UserDAOTests
{
    [Fact]
    public void Login_ValidCredentials_ReturnsUser()
    {
        // Arrange
        var dao = new UserDAO();
        string email = "admin@gsb.fr";
        string password = "Admin123!";
        
        // Act
        User user = dao.Login(email, password);
        
        // Assert
        Assert.NotNull(user);
        Assert.Equal(email, user.Email);
        Assert.Equal("admin", user.Role);
    }

    [Fact]
    public void Login_InvalidCredentials_ReturnsNull()
    {
        // Arrange
        var dao = new UserDAO();
        
        // Act
        User user = dao.Login("wrong@gsb.fr", "wrongpass");
        
        // Assert
        Assert.Null(user);
    }
}
```

---

## 5.9 Synthèse de la réalisation

| Composant | Statut | Remarques |
|-----------|--------|-----------|
| **Authentification** | ✅ Fonctionnel | Amélioration recommandée : bcrypt |
| **Gestion utilisateurs** | ✅ Fonctionnel | CRUD complet |
| **Gestion patients** | ✅ Fonctionnel | Validation UI, CRUD complet |
| **Gestion médicaments** | ✅ Fonctionnel | Association avec utilisateur créateur |
| **Gestion prescriptions** | ✅ Fonctionnel | Transaction recommandée pour atomicité |
| **Export PDF** | ✅ Fonctionnel | Mise en forme basique, extensible |
| **Sécurité** | ⚠️ Partiel | Requêtes paramétrées OK, hash à améliorer |
| **Tests unitaires** | ❌ Absent | À implémenter en V2 |





