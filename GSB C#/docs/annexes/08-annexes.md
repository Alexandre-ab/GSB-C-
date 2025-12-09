# 8. Annexes

## 8.1 Script SQL complet d'initialisation

### 8.1.1 Création de la base et des tables

```sql
-- =============================================
-- Script d'initialisation base de données GSB
-- Version : 1.0
-- Date : Décembre 2024
-- =============================================

-- Création de la base de données
DROP DATABASE IF EXISTS `bts-gsb`;
CREATE DATABASE `bts-gsb` 
  CHARACTER SET utf8mb4 
  COLLATE utf8mb4_unicode_ci;

USE `bts-gsb`;

-- =============================================
-- Table Users
-- =============================================
CREATE TABLE Users (
  id_users INT AUTO_INCREMENT PRIMARY KEY,
  firstname VARCHAR(100) NOT NULL,
  lastname VARCHAR(100) NOT NULL,
  email VARCHAR(255) NOT NULL UNIQUE,
  password VARCHAR(255) NOT NULL COMMENT 'Hash SHA-256 (à migrer vers bcrypt)',
  role VARCHAR(50) NOT NULL DEFAULT 'medecin' COMMENT 'admin ou medecin',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  
  INDEX idx_email (email),
  INDEX idx_role (role)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Table des utilisateurs (administrateurs et médecins)';

-- =============================================
-- Table Patients
-- =============================================
CREATE TABLE Patients (
  id_patient INT AUTO_INCREMENT PRIMARY KEY,
  firstname VARCHAR(100) NOT NULL,
  lastname VARCHAR(100) NOT NULL,
  birthdate DATE COMMENT 'Date de naissance',
  address VARCHAR(255),
  phone VARCHAR(50),
  
  INDEX idx_name (lastname, firstname)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Table des patients';

-- =============================================
-- Table Medicine
-- =============================================
CREATE TABLE Medicine (
  id_medicine INT AUTO_INCREMENT PRIMARY KEY,
  id_users INT NOT NULL COMMENT 'Créateur du médicament',
  name VARCHAR(255) NOT NULL,
  molecule VARCHAR(255) COMMENT 'Molécule active',
  dosage VARCHAR(100) COMMENT 'Dosage (ex: 1000mg)',
  description TEXT,
  
  INDEX idx_name (name),
  INDEX idx_molecule (molecule),
  
  CONSTRAINT fk_medicine_user 
    FOREIGN KEY (id_users) REFERENCES Users(id_users) 
    ON DELETE RESTRICT 
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Catalogue des médicaments';

-- =============================================
-- Table Prescription
-- =============================================
CREATE TABLE Prescription (
  id_prescription INT AUTO_INCREMENT PRIMARY KEY,
  id_patient INT NOT NULL COMMENT 'Patient concerné',
  id_users INT NOT NULL COMMENT 'Prescripteur (médecin)',
  date DATE NOT NULL COMMENT 'Date de prescription',
  notes TEXT COMMENT 'Notes et observations',
  
  INDEX idx_date (date),
  INDEX idx_patient (id_patient),
  INDEX idx_user (id_users),
  
  CONSTRAINT fk_prescription_patient 
    FOREIGN KEY (id_patient) REFERENCES Patients(id_patient) 
    ON DELETE CASCADE 
    ON UPDATE CASCADE
    COMMENT 'Suppression du patient supprime ses prescriptions',
  
  CONSTRAINT fk_prescription_user 
    FOREIGN KEY (id_users) REFERENCES Users(id_users) 
    ON DELETE RESTRICT 
    ON UPDATE CASCADE
    COMMENT 'Impossible de supprimer un utilisateur ayant des prescriptions'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Prescriptions médicales';

-- =============================================
-- Table Appartient (association Prescription-Medicine)
-- =============================================
CREATE TABLE Appartient (
  id_appartient INT AUTO_INCREMENT PRIMARY KEY,
  id_prescription INT NOT NULL,
  id_medicine INT NOT NULL,
  quantity INT NOT NULL DEFAULT 1 COMMENT 'Quantité prescrite',
  posology VARCHAR(255) COMMENT 'Posologie (ex: 1cp 3x/jour)',
  
  UNIQUE KEY unique_prescription_medicine (id_prescription, id_medicine)
    COMMENT 'Un médicament ne peut être ajouté qu\'une fois par prescription',
  
  CONSTRAINT fk_appartient_prescription 
    FOREIGN KEY (id_prescription) REFERENCES Prescription(id_prescription) 
    ON DELETE CASCADE 
    ON UPDATE CASCADE
    COMMENT 'Suppression de la prescription supprime les associations',
  
  CONSTRAINT fk_appartient_medicine 
    FOREIGN KEY (id_medicine) REFERENCES Medicine(id_medicine) 
    ON DELETE RESTRICT 
    ON UPDATE CASCADE
    COMMENT 'Impossible de supprimer un médicament utilisé dans une prescription'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci
  COMMENT='Association prescriptions-médicaments avec posologie';

-- =============================================
-- Données de test (seed)
-- =============================================

-- Utilisateurs
-- Note : les mots de passe sont hashés en SHA-256 (à remplacer par bcrypt en production)
-- Mots de passe en clair pour référence : Admin123! et Medecin123!

INSERT INTO Users (firstname, lastname, email, password, role) VALUES
('Admin', 'Système', 'admin@gsb.fr', 
 SHA2('Admin123!', 256), 'admin'),
('Jean', 'Dupont', 'jean.dupont@gsb.fr', 
 SHA2('Medecin123!', 256), 'medecin'),
('Marie', 'Martin', 'marie.martin@gsb.fr', 
 SHA2('Medecin123!', 256), 'medecin');

-- Patients
INSERT INTO Patients (firstname, lastname, birthdate, address, phone) VALUES
('Pierre', 'Bernard', '1970-05-15', '12 rue de la Paix, 75001 Paris', '0612345678'),
('Sophie', 'Dubois', '1985-11-22', '34 avenue des Champs, 69001 Lyon', '0623456789'),
('Lucas', 'Petit', '2000-03-08', '56 boulevard Victor Hugo, 31000 Toulouse', '0634567890'),
('Emma', 'Rousseau', '1992-07-19', '78 rue de la République, 13001 Marseille', '0645678901'),
('Louis', 'Moreau', '1968-12-03', '90 avenue Foch, 33000 Bordeaux', '0656789012');

-- Médicaments (créés par l'admin)
INSERT INTO Medicine (id_users, name, molecule, dosage, description) VALUES
(1, 'Doliprane', 'Paracétamol', '1000mg', 'Antalgique et antipyrétique. Traitement symptomatique des douleurs et de la fièvre.'),
(1, 'Aspirine', 'Acide acétylsalicylique', '500mg', 'Anti-inflammatoire non stéroïdien. Traitement de la douleur et de la fièvre.'),
(1, 'Amoxicilline', 'Amoxicilline', '500mg', 'Antibiotique à large spectre. Traitement des infections bactériennes.'),
(1, 'Ibuprofène', 'Ibuprofène', '400mg', 'Anti-inflammatoire non stéroïdien. Traitement des douleurs et inflammations.'),
(1, 'Spasfon', 'Phloroglucinol', '80mg', 'Antispasmodique. Traitement des douleurs spasmodiques digestives et urinaires.');

-- Prescriptions (créées par Jean Dupont)
INSERT INTO Prescription (id_patient, id_users, date, notes) VALUES
(1, 2, '2024-12-01', 'Traitement pour douleurs et fièvre suite à grippe.'),
(2, 2, '2024-12-03', 'Traitement antibiotique pour infection respiratoire.'),
(3, 2, '2024-12-05', 'Traitement anti-inflammatoire pour entorse cheville.');

-- Associations prescriptions-médicaments
INSERT INTO Appartient (id_prescription, id_medicine, quantity, posology) VALUES
-- Prescription 1 (Pierre Bernard) : Doliprane + Aspirine
(1, 1, 30, '1 comprimé 3 fois par jour pendant 10 jours'),
(1, 2, 20, '1 comprimé matin et soir pendant 10 jours'),

-- Prescription 2 (Sophie Dubois) : Amoxicilline
(2, 3, 21, '1 gélule 3 fois par jour pendant 7 jours'),

-- Prescription 3 (Lucas Petit) : Ibuprofène + Spasfon
(3, 4, 20, '1 comprimé 2 fois par jour pendant 10 jours'),
(3, 5, 15, '1 comprimé si douleur (max 6 par jour)');

-- =============================================
-- Vérifications et statistiques
-- =============================================

-- Compter les entités
SELECT 'Users' AS Table_Name, COUNT(*) AS Count FROM Users
UNION ALL
SELECT 'Patients', COUNT(*) FROM Patients
UNION ALL
SELECT 'Medicine', COUNT(*) FROM Medicine
UNION ALL
SELECT 'Prescription', COUNT(*) FROM Prescription
UNION ALL
SELECT 'Appartient', COUNT(*) FROM Appartient;

-- Afficher les prescriptions avec détails
SELECT 
  p.id_prescription,
  CONCAT(pat.firstname, ' ', pat.lastname) AS Patient,
  CONCAT(u.firstname, ' ', u.lastname) AS Prescripteur,
  p.date AS Date_Prescription,
  COUNT(a.id_medicine) AS Nb_Medicaments
FROM Prescription p
JOIN Patients pat ON p.id_patient = pat.id_patient
JOIN Users u ON p.id_users = u.id_users
LEFT JOIN Appartient a ON p.id_prescription = a.id_prescription
GROUP BY p.id_prescription;

-- =============================================
-- Script de nettoyage (pour réinitialiser)
-- =============================================

/*
-- Désactiver les contraintes FK temporairement
SET FOREIGN_KEY_CHECKS = 0;

-- Vider les tables
TRUNCATE TABLE Appartient;
TRUNCATE TABLE Prescription;
TRUNCATE TABLE Medicine;
TRUNCATE TABLE Patients;
TRUNCATE TABLE Users;

-- Réactiver les contraintes
SET FOREIGN_KEY_CHECKS = 1;

-- Puis relancer les INSERT ci-dessus
*/
```

---

## 8.2 Extraits de code significatifs

### 8.2.1 Authentification (UserDAO.cs)

```csharp
// Dao/UserDAO.cs
using GSB_C_.Models;
using GSB2.DAO;
using MySql.Data.MySqlClient;

public class UserDAO
{
    private readonly Database db = new Database();

    /// <summary>
    /// Authentifie un utilisateur avec email et mot de passe.
    /// </summary>
    /// <param name="email">Email de l'utilisateur</param>
    /// <param name="password">Mot de passe en clair</param>
    /// <returns>Objet User si authentification réussie, null sinon</returns>
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
                        int id = myReader.GetInt32("id_users");
                        string name = myReader.GetString("lastname");
                        string firstname = myReader.GetString("firstname");
                        bool role = myReader.GetBoolean("role");

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

    /// <summary>
    /// Enregistre un nouvel utilisateur.
    /// </summary>
    /// <param name="user">Objet User à enregistrer</param>
    /// <returns>True si succès, false sinon</returns>
    public bool Add(User user)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"INSERT INTO Users 
                    (name, firstname, email, password, role) 
                    VALUES (@name, @firstname, @email, SHA2(@password, 256), @role)";
                
                myCommand.Parameters.AddWithValue("@name", user.Name);
                myCommand.Parameters.AddWithValue("@firstname", user.Firstname);
                myCommand.Parameters.AddWithValue("@email", user.Email);
                myCommand.Parameters.AddWithValue("@password", user.Password);
                myCommand.Parameters.AddWithValue("@role", user.Role);
                
                int rowsAffected = myCommand.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering user: " + ex.Message);
            }
        }
    }
}
```

### 8.2.2 Formulaire de connexion (Form1.cs)

```csharp
// Forms/Form1.cs
using GSB2.DAO;
using GSB_C_.Forms;
using GSB_C_.Models;

namespace GSB_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère le clic sur le bouton de connexion.
        /// Authentifie l'utilisateur et redirige vers le formulaire approprié selon son rôle.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Validation basique
            if (string.IsNullOrWhiteSpace(textBoxLoginEmail.Text) || 
                string.IsNullOrWhiteSpace(textBoxLoginPassword.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", 
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UserDAO userDao = new UserDAO();
                User user = userDao.Login(textBoxLoginEmail.Text, textBoxLoginPassword.Text);

                if (user != null && user.Role == true) // Admin
                {
                    UserSession.CurrentUser = user;
                    this.Hide();
                    FormAdmin formAdmin = new FormAdmin();
                    formAdmin.ShowDialog();
                    this.Close();
                }
                else if (user != null && user.Role == false) // Médecin
                {
                    UserSession.CurrentUser = user;
                    this.Hide();
                    FormDoctor formDoctor = new FormDoctor();
                    formDoctor.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects. Veuillez réessayer.", 
                        "Erreur d'authentification", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion : {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
```

### 8.2.3 Gestion de session (UserSession.cs)

```csharp
// Models/UserSession.cs
namespace GSB_C_.Models
{
    /// <summary>
    /// Classe statique pour gérer la session utilisateur en cours.
    /// </summary>
    public static class UserSession
    {
        /// <summary>
        /// Utilisateur actuellement connecté.
        /// </summary>
        public static User? CurrentUser { get; private set; }

        /// <summary>
        /// Indique si un utilisateur est authentifié.
        /// </summary>
        public static bool IsAuthenticated => CurrentUser != null;

        /// <summary>
        /// Connecte un utilisateur et crée une session.
        /// </summary>
        /// <param name="user">Utilisateur à connecter</param>
        public static void Login(User user)
        {
            CurrentUser = user;
        }

        /// <summary>
        /// Déconnecte l'utilisateur et détruit la session.
        /// </summary>
        public static void Logout()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// Vérifie si l'utilisateur courant est administrateur.
        /// </summary>
        public static bool IsAdmin => CurrentUser?.Role == "admin";

        /// <summary>
        /// Vérifie si l'utilisateur courant est médecin.
        /// </summary>
        public static bool IsMedecin => CurrentUser?.Role == "medecin";
    }
}
```

### 8.2.4 Export PDF (ExporterPDF.cs - version améliorée)

```csharp
// Utils/ExporterPDF.cs
using iTextSharp.text;
using iTextSharp.text.pdf;
using GSB_C_.Models;

namespace GSB_C_.Utils
{
    /// <summary>
    /// Classe utilitaire pour générer des documents PDF (ordonnances).
    /// </summary>
    public class ExporterPDF
    {
        /// <summary>
        /// Génère un PDF d'ordonnance pour une prescription donnée.
        /// </summary>
        /// <param name="prescription">La prescription à exporter</param>
        /// <param name="patient">Le patient concerné</param>
        /// <param name="medicaments">Liste des médicaments avec posologies</param>
        /// <param name="prescripteur">Médecin prescripteur</param>
        /// <param name="cheminFichier">Chemin du fichier PDF à créer</param>
        /// <returns>True si succès, false sinon</returns>
        public bool ExporterPrescription(
            Prescription prescription, 
            Patient patient,
            List<(Medicine med, int quantity, string posology)> medicaments,
            User prescripteur,
            string cheminFichier)
        {
            try
            {
                // 1. Initialisation du document A4
                Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
                doc.Open();

                // 2. En-tête
                var fontTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.BLUE);
                Paragraph titre = new Paragraph("ORDONNANCE GSB", fontTitre);
                titre.Alignment = Element.ALIGN_CENTER;
                titre.SpacingAfter = 30;
                doc.Add(titre);

                // 3. Informations patient
                var fontGras = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                doc.Add(new Paragraph($"Date : {prescription.Date.ToShortDateString()}", fontNormal));
                doc.Add(new Paragraph($"Patient : {patient.Firstname} {patient.Lastname}", fontGras));
                doc.Add(new Paragraph($"Né(e) le : {patient.Birthdate.ToShortDateString()}", fontNormal));
                doc.Add(new Paragraph($"Adresse : {patient.Address}", fontNormal));
                doc.Add(new Paragraph("\n"));

                // 4. Tableau des médicaments prescrits
                PdfPTable table = new PdfPTable(4); // 4 colonnes
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 3f, 2f, 1.5f, 3.5f });

                // En-têtes
                PdfPCell headerCell;
                string[] headers = { "Médicament", "Dosage", "Quantité", "Posologie" };
                foreach (var header in headers)
                {
                    headerCell = new PdfPCell(new Phrase(header, fontGras));
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.Padding = 5;
                    table.AddCell(headerCell);
                }

                // Lignes des médicaments
                foreach (var item in medicaments)
                {
                    table.AddCell(new Phrase(item.med.Name, fontNormal));
                    table.AddCell(new Phrase(item.med.Dosage, fontNormal));
                    table.AddCell(new Phrase(item.quantity.ToString(), fontNormal));
                    table.AddCell(new Phrase(item.posology, fontNormal));
                }

                doc.Add(table);

                // 5. Notes (si présentes)
                if (!string.IsNullOrEmpty(prescription.Notes))
                {
                    doc.Add(new Paragraph("\n"));
                    doc.Add(new Paragraph("Notes :", fontGras));
                    doc.Add(new Paragraph(prescription.Notes, fontNormal));
                }

                // 6. Signature du prescripteur
                doc.Add(new Paragraph("\n\n"));
                Paragraph signature = new Paragraph(
                    $"Prescripteur : Dr. {prescripteur.Firstname} {prescripteur.Lastname}", 
                    fontNormal);
                signature.Alignment = Element.ALIGN_RIGHT;
                doc.Add(signature);

                // 7. Fermeture du document
                doc.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la génération du PDF : {ex.Message}");
                return false;
            }
        }
    }
}
```

---

## 8.3 Structure du projet (arborescence complète)

```
GSB C#/
│
├── bin/
│   ├── Debug/
│   │   └── net8.0-windows/
│   │       ├── GSB C#.exe
│   │       ├── GSB C#.dll
│   │       ├── MySql.Data.dll
│   │       ├── iTextSharp.dll
│   │       └── (autres dépendances)
│   └── Release/
│
├── obj/
│   ├── Debug/
│   └── Release/
│
├── Dao/
│   ├── Database.cs                 // Connexion MySQL
│   ├── UserDAO.cs                  // CRUD Users
│   ├── PatientsDao.cs              // CRUD Patients
│   ├── MedicineDao.cs              // CRUD Medicine
│   ├── PrescriptionDao.cs          // CRUD Prescription
│   └── AppartientDao.cs            // CRUD Appartient
│
├── Models/
│   ├── User.cs                     // Entité User
│   ├── Patient.cs                  // Entité Patient
│   ├── Medicine.cs                 // Entité Medicine
│   ├── Prescription.cs             // Entité Prescription
│   ├── Appartient.cs               // Entité Appartient
│   └── UserSession.cs              // Gestion de session
│
├── Forms/
│   ├── Form1.cs                    // Formulaire de connexion
│   ├── Form1.Designer.cs
│   ├── Form1.resx
│   ├── FormAdmin.cs                // Interface admin
│   ├── FormAdmin.Designer.cs
│   ├── FormAdmin.resx
│   ├── FormDoctor.cs               // Interface médecin
│   ├── FormDoctor.Designer.cs
│   ├── FormDoctor.resx
│   ├── FormAddpatient.cs           // Ajout patient
│   ├── FormAddpatient.Designer.cs
│   ├── FormAddpatient.resx
│   ├── FormAddUser.cs              // Ajout utilisateur
│   ├── FormAddUser.Designer.cs
│   ├── FormAddUser.resx
│   ├── FormPrescription.cs         // Gestion prescriptions
│   ├── FormPrescription.Designer.cs
│   ├── FormPrescription.resx
│   ├── FormDetailMedicine.cs       // Détail médicament
│   ├── FormDetailMedicine.Designer.cs
│   ├── FormDetailMedicine.resx
│   ├── FormModifyAdmin.cs          // Modification admin
│   ├── FormModifyAdmin.Designer.cs
│   └── FormModifyAdmin.resx
│
├── Utils/
│   └── ExporterPDF.cs              // Export PDF (iTextSharp)
│
├── Properties/
│   ├── Resources.Designer.cs
│   └── Resources.resx
│
├── docs/                           // Documentation BTS
│   ├── 01-contexte-cahier-charges.md
│   ├── conception/
│   │   ├── 02-diagrammes-uml.md
│   │   ├── 03-modele-donnees.md
│   │   └── 04-architecture.md
│   ├── realisation/
│   │   └── 05-realisation-technique.md
│   ├── tests/
│   │   └── 06-plan-de-tests.md
│   ├── veille/
│   │   └── 07-veille-technologique.md
│   └── annexes/
│       └── 08-annexes.md
│
├── Program.cs                      // Point d'entrée application
├── GSB C#.csproj                   // Fichier projet .NET
├── GSB C#.csproj.user
└── README.md                       // Documentation technique principale
```

---

## 8.4 Configuration requise

### 8.4.1 Environnement de développement

| Composant | Version minimale | Version recommandée |
|-----------|------------------|---------------------|
| **Système d'exploitation** | Windows 10 | Windows 11 |
| **.NET SDK** | 8.0 | 8.0.x (dernière) |
| **Visual Studio** | 2022 (17.8+) | 2022 (17.9+) |
| **MySQL** | 8.0 | 8.0.36 |
| **RAM** | 4 Go | 8 Go |
| **Espace disque** | 2 Go | 5 Go |

### 8.4.2 Dépendances NuGet

```xml
<!-- GSB C#.csproj -->
<ItemGroup>
  <PackageReference Include="MySql.Data" Version="9.5.0" />
  <PackageReference Include="iTextSharp" Version="5.5.13.4" />
</ItemGroup>
```

**Commande d'installation** :
```bash
dotnet add package MySql.Data --version 9.5.0
dotnet add package iTextSharp --version 5.5.13.4
```

---

## 8.5 Guide d'installation

### 8.5.1 Installation pas à pas

1. **Prérequis** :
   - Installer .NET 8 SDK : https://dotnet.microsoft.com/download
   - Installer MySQL 8.x : https://dev.mysql.com/downloads/installer/
   - (Optionnel) Installer Visual Studio 2022 Community

2. **Cloner le dépôt** :
   ```bash
   git clone https://github.com/votre-depot/gsb-winforms.git
   cd "gsb-winforms/GSB C#"
   ```

3. **Configurer la base de données** :
   - Démarrer MySQL Server (port 3307 par défaut dans le projet).
   - Exécuter le script SQL d'initialisation (section 8.1).
   - Vérifier la création des tables et des données de test.

4. **Adapter la chaîne de connexion** :
   - Ouvrir `Dao/Database.cs`.
   - Modifier `myConnectionString` si nécessaire (serveur, port, utilisateur, mot de passe).

5. **Restaurer les dépendances** :
   ```bash
   dotnet restore
   ```

6. **Compiler le projet** :
   ```bash
   dotnet build -c Release
   ```

7. **Exécuter l'application** :
   ```bash
   dotnet run
   ```
   Ou depuis Visual Studio : F5.

8. **Tester la connexion** :
   - Email : `admin@gsb.fr`
   - Mot de passe : `Admin123!`

---

## 8.6 Glossaire

| Terme | Définition |
|-------|------------|
| **DAO** | Data Access Object. Pattern de conception pour isoler l'accès aux données. |
| **CRUD** | Create, Read, Update, Delete. Opérations de base sur les données. |
| **FK** | Foreign Key (Clé étrangère). Référence entre tables pour garantir l'intégrité. |
| **ORM** | Object-Relational Mapping. Technique de mapping objet-relationnel (ex: Entity Framework). |
| **Hash** | Fonction cryptographique unidirectionnelle pour sécuriser les mots de passe. |
| **Injection SQL** | Attaque consistant à insérer du code SQL malveillant dans une requête. |
| **Session** | État temporaire d'un utilisateur connecté (authentification persistante). |
| **Transaction** | Groupe d'opérations atomiques (tout ou rien) sur la base de données. |
| **WinForms** | Framework .NET pour créer des applications desktop Windows. |
| **PlantUML** | Outil de génération de diagrammes UML à partir de texte. |
| **bcrypt** | Algorithme de hachage de mots de passe sécurisé avec sel intégré. |

---

## 8.7 Bibliographie et sources

### 8.7.1 Documentation officielle

| Source | URL |
|--------|-----|
| Microsoft .NET Documentation | https://learn.microsoft.com/dotnet/ |
| Windows Forms .NET | https://learn.microsoft.com/dotnet/desktop/winforms/ |
| MySQL 8.0 Reference Manual | https://dev.mysql.com/doc/refman/8.0/en/ |
| iTextSharp Documentation | http://itextpdf.com/itext-in-action |

### 8.7.2 Articles et tutoriels

| Titre | Auteur | Lien |
|-------|--------|------|
| "Best Practices for Password Storage" | OWASP | https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html |
| "SQL Injection Prevention" | OWASP | https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html |
| "The DAO Pattern in C#" | Microsoft Docs | https://docs.microsoft.com/patterns/dao-pattern |

### 8.7.3 Outils utilisés

| Outil | Usage | URL |
|-------|-------|-----|
| **Visual Studio 2022** | IDE de développement | https://visualstudio.microsoft.com/ |
| **MySQL Workbench** | Gestion base de données | https://www.mysql.com/products/workbench/ |
| **PlantUML** | Génération diagrammes UML | https://plantuml.com/ |
| **Git** | Gestion de versions | https://git-scm.com/ |

---

## 8.8 Contacts et support

| Rôle | Nom | Email |
|------|-----|-------|
| **Développeur** | [Votre nom] | [votre.email@example.com] |
| **Tuteur BTS** | [Nom tuteur] | [tuteur@etablissement.fr] |
| **Référent technique** | [Nom référent] | [referent@gsb.fr] |

---

## 8.9 Changelog (historique des versions)

| Version | Date | Auteur | Modifications |
|---------|------|--------|---------------|
| **1.0.0** | 2024-12-09 | [Votre nom] | Version initiale : authentification, CRUD patients/médicaments/prescriptions, export PDF |
| **1.0.1** | 2024-12-XX | [Votre nom] | Corrections bugs (B1-B5), amélioration validation |
| **2.0.0** | À venir | - | Migration bcrypt, tests unitaires, logging, API REST |


