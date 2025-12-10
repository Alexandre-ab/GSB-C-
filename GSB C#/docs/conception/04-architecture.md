# 4. Architecture de l'application

## 4.1 Architecture globale (3 tiers)

L'application GSB WinForms suit une architecture en couches (3-tier architecture) pour garantir la séparation des responsabilités, la maintenabilité et l'évolutivité.

```
┌──────────────────────────────────────────────────────────┐
│                   COUCHE PRÉSENTATION                     │
│                    (User Interface)                       │
├──────────────────────────────────────────────────────────┤
│  - Forms/ (WinForms)                                      │
│    • Form1 (Login)                                        │
│    • FormAdmin (Gestion admin)                            │
│    • FormDoctor (Vue médecin)                             │
│    • FormAddpatient, FormAddUser                          │
│    • FormPrescription, FormDetailMedicine                 │
│    • FormModifyAdmin                                      │
│                                                            │
│  Responsabilités :                                        │
│  - Affichage des données                                  │
│  - Capture des événements utilisateur                     │
│  - Validation des saisies (côté client)                   │
│  - Navigation entre les écrans                            │
└──────────────────────────────────────────────────────────┘
                         ▼ ▲
┌──────────────────────────────────────────────────────────┐
│                   COUCHE MÉTIER                           │
│                  (Business Logic)                         │
├──────────────────────────────────────────────────────────┤
│  - Models/                                                │
│    • User, Patient, Medicine, Prescription, Appartient    │
│    • UserSession (gestion de session)                     │
│                                                            │
│  - Utils/                                                 │
│    • ExporterPDF (génération de documents)                │
│                                                            │
│  Responsabilités :                                        │
│  - Représentation des entités métier                      │
│  - Logique métier (règles de gestion)                     │
│  - Gestion de la session utilisateur                      │
│  - Export de documents                                    │
└──────────────────────────────────────────────────────────┘
                         ▼ ▲
┌──────────────────────────────────────────────────────────┐
│                  COUCHE ACCÈS DONNÉES                     │
│                   (Data Access Layer)                     │
├──────────────────────────────────────────────────────────┤
│  - Dao/                                                   │
│    • Database (connexion MySQL)                           │
│    • UserDAO, PatientsDao, MedicineDao                    │
│    • PrescriptionDao, AppartientDao                       │
│                                                            │
│  Responsabilités :                                        │
│  - Connexion à la base de données                         │
│  - Opérations CRUD (Create, Read, Update, Delete)        │
│  - Requêtes SQL paramétrées (sécurité)                    │
│  - Mapping résultats → objets métier                      │
└──────────────────────────────────────────────────────────┘
                         ▼ ▲
┌──────────────────────────────────────────────────────────┐
│                  BASE DE DONNÉES MySQL                    │
├──────────────────────────────────────────────────────────┤
│  Tables :                                                 │
│  - Users, Patients, Medicine                              │
│  - Prescription, Appartient                               │
│                                                            │
│  Contraintes :                                            │
│  - Clés primaires (PK)                                    │
│  - Clés étrangères (FK)                                   │
│  - Contraintes d'intégrité (UNIQUE, NOT NULL, CASCADE)    │
└──────────────────────────────────────────────────────────┘
```

---

## 4.2 Principe de séparation des responsabilités

| Couche | Responsabilité | Technologies |
|--------|----------------|--------------|
| **Présentation** | Interagir avec l'utilisateur, afficher les données, capturer les événements. | Windows Forms, C# |
| **Métier** | Représenter les entités, appliquer les règles de gestion, gérer la logique applicative. | C# (classes POCO) |
| **Accès données** | Communiquer avec la base de données, exécuter les requêtes SQL, mapper les résultats. | ADO.NET (MySql.Data) |
| **Persistance** | Stocker les données de manière durable et structurée. | MySQL 8.x |

---

## 4.3 Diagramme de déploiement

Ce diagramme illustre l'infrastructure physique de l'application.

```
┌──────────────────────────────────────────────┐
│         Poste utilisateur (Windows)          │
│                                              │
│  ┌────────────────────────────────────────┐ │
│  │      GSB WinForms.exe                  │ │
│  │                                        │ │
│  │  - Interface graphique (Forms)         │ │
│  │  - Logique métier (Models, Utils)      │ │
│  │  - Accès données (DAO)                 │ │
│  └────────────────────────────────────────┘ │
│                   │                          │
│                   │ TCP/IP                   │
│                   │ MySQL Protocol           │
│                   │ (port 3307)              │
└───────────────────┼──────────────────────────┘
                    │
                    ▼
┌──────────────────────────────────────────────┐
│      Serveur MySQL (local ou distant)       │
│                                              │
│  ┌────────────────────────────────────────┐ │
│  │        Base de données bts-gsb         │ │
│  │                                        │ │
│  │  Tables :                              │ │
│  │  - Users, Patients, Medicine           │ │
│  │  - Prescription, Appartient            │ │
│  └────────────────────────────────────────┘ │
│                                              │
│  Moteur : InnoDB                             │
│  Charset : utf8mb4                           │
└──────────────────────────────────────────────┘
```

### Environnements

| Environnement | Serveur MySQL | Port | Base | Utilisateur |
|---------------|---------------|------|------|-------------|
| **Développement** | localhost | 3307 | bts-gsb | root |
| **Production** | serveur-prod.gsb.fr | 3306 | bts-gsb | gsb_app (privilèges limités) |

---

## 4.4 Flux de données : Exemple d'une création de prescription

```
┌─────────────┐
│  Utilisateur│
└──────┬──────┘
       │ 1. Saisir infos prescription
       ▼
┌─────────────────────┐
│ FormPrescription    │
│  (Couche UI)        │
└──────┬──────────────┘
       │ 2. Clic "Enregistrer"
       │ 3. Créer objet Prescription
       ▼
┌─────────────────────┐
│ Prescription (Model)│
│  (Couche Métier)    │
└──────┬──────────────┘
       │ 4. Appel PrescriptionDao.Add()
       ▼
┌─────────────────────┐
│ PrescriptionDao     │
│  (Couche DAO)       │
└──────┬──────────────┘
       │ 5. Exécuter INSERT INTO Prescription
       │ 6. Récupérer id_prescription
       ▼
┌─────────────────────┐
│  MySQL Database     │
└──────┬──────────────┘
       │ 7. Retour id_prescription
       ▼
┌─────────────────────┐
│ PrescriptionDao     │
└──────┬──────────────┘
       │ 8. Retour TRUE + id
       ▼
┌─────────────────────┐
│ FormPrescription    │
└──────┬──────────────┘
       │ 9. Pour chaque médicament
       │    Appel AppartientDao.Add()
       ▼
┌─────────────────────┐
│ AppartientDao       │
└──────┬──────────────┘
       │ 10. INSERT INTO Appartient
       ▼
┌─────────────────────┐
│  MySQL Database     │
└──────┬──────────────┘
       │ 11. Retour OK
       ▼
┌─────────────────────┐
│ FormPrescription    │
└──────┬──────────────┘
       │ 12. MessageBox "Prescription créée avec succès"
       ▼
┌─────────────┐
│  Utilisateur│
└─────────────┘
```

---

## 4.5 Gestion de la connexion à la base de données

### Classe Database (Singleton pattern recommandé)

```csharp
// Dao/Database.cs
using MySql.Data.MySqlClient;

namespace GSB2.DAO
{
    public class Database
    {
        private readonly string myConnectionString;

        public Database()
        {
            // Lire depuis variable d'environnement ou configuration
            string? envConnString = Environment.GetEnvironmentVariable("GSB_DB_CONN");
            
            if (!string.IsNullOrEmpty(envConnString))
            {
                myConnectionString = envConnString;
            }
            else
            {
                // Fallback pour développement
                myConnectionString = "server=localhost;port=3307;uid=root;pwd=rootpassword;database=bts-gsb";
            }
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(myConnectionString);
        }
    }
}
```

### Avantages de cette approche
- **Centralisation** : une seule classe gère la configuration de connexion.
- **Flexibilité** : changement de connexion sans recompiler (via env vars).
- **Sécurité** : pas de credentials hardcodés dans le code source.

---

## 4.6 Pattern DAO (Data Access Object)

Chaque entité métier possède son DAO dédié :

| Entité | DAO | Méthodes principales |
|--------|-----|---------------------|
| User | UserDAO | Login, GetAll, GetById, Add, Update, Delete |
| Patient | PatientsDao | GetAll, GetById, Add, Update, Delete |
| Medicine | MedicineDao | GetAll, GetById, GetByUserId, Add, Update, Delete |
| Prescription | PrescriptionDao | GetAll, GetById, GetByPatientId, Add, Update, Delete |
| Appartient | AppartientDao | GetByPrescriptionId, Add, Delete |

### Structure type d'un DAO

```csharp
public class ExampleDAO
{
    private readonly Database db = new Database();

    public List<Example> GetAll()
    {
        List<Example> items = new List<Example>();
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Example;", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Mapping reader → objet
                        items.Add(new Example(...));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data: " + ex.Message);
            }
        }
        return items;
    }

    public bool Add(Example item)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO Example (...) VALUES (@param1, @param2);", connection);
                cmd.Parameters.AddWithValue("@param1", item.Property1);
                cmd.Parameters.AddWithValue("@param2", item.Property2);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding data: " + ex.Message);
            }
        }
    }
}
```

---

## 4.7 Gestion de la session utilisateur

La classe statique `UserSession` maintient l'état de l'utilisateur connecté.

```csharp
// Models/UserSession.cs
namespace GSB_C_.Models
{
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
    }
}
```

### Utilisation dans les formulaires

```csharp
// Vérifier si l'utilisateur est authentifié
if (!UserSession.IsAuthenticated)
{
    MessageBox.Show("Vous devez vous connecter d'abord.");
    return;
}

// Vérifier le rôle
if (UserSession.CurrentUser.Role == "admin")
{
    // Afficher FormAdmin
}
else
{
    // Afficher FormDoctor
}
```

---

## 4.8 Gestion des erreurs et exceptions

### Stratégie de gestion des erreurs

1. **Couche DAO** : capturer les exceptions MySQL et les relancer avec un message contextualisé.
2. **Couche UI** : entourer les appels DAO d'un `try/catch` et afficher un message utilisateur convivial.

### Exemple dans un formulaire

```csharp
private void btnSave_Click(object sender, EventArgs e)
{
    try
    {
        Patient patient = new Patient(
            0,
            txtFirstname.Text,
            txtLastname.Text,
            dtpBirthdate.Value,
            txtAddress.Text,
            txtPhone.Text
        );

        PatientsDao dao = new PatientsDao();
        bool success = dao.Add(patient);

        if (success)
        {
            MessageBox.Show("Patient ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        else
        {
            MessageBox.Show("Erreur lors de l'ajout du patient.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        // TODO : journaliser l'erreur (fichier log, Serilog, etc.)
    }
}
```

---

## 4.9 Sécurité de l'architecture

### Mesures de sécurité implémentées

| Mesure | Description | Implémentation |
|--------|-------------|----------------|
| **Requêtes paramétrées** | Prévention des injections SQL | `cmd.Parameters.AddWithValue()` dans tous les DAO |
| **Hash des mots de passe** | Stockage sécurisé | Utilisation de bcrypt (recommandé, à implémenter) |
| **Gestion des sessions** | Authentification persistante | Classe `UserSession` statique |
| **Contrôle d'accès par rôle** | Limiter l'accès selon le rôle | Vérification `UserSession.CurrentUser.Role` |
| **Variables d'environnement** | Ne pas hardcoder les credentials | Lecture `GSB_DB_CONN` depuis env vars |
| **Privilèges DB limités** | Principe de moindre privilège | Compte MySQL dédié avec droits SELECT/INSERT/UPDATE/DELETE uniquement |

### Améliorations recommandées (V2)

- **Logging** : intégrer Serilog ou NLog pour journaliser les actions et erreurs.
- **Validation côté serveur** : ajouter une couche de validation métier avant l'accès DAO.
- **Chiffrement des communications** : utiliser SSL/TLS pour la connexion MySQL en production.
- **Audit trail** : table d'audit pour tracer les modifications (qui, quand, quoi).

---

## 4.10 Diagramme de paquetages (structure du projet)

```
GSB C#
│
├── Dao/
│   ├── Database.cs
│   ├── UserDAO.cs
│   ├── PatientsDao.cs
│   ├── MedicineDao.cs
│   ├── PrescriptionDao.cs
│   └── AppartientDao.cs
│
├── Models/
│   ├── User.cs
│   ├── Patient.cs
│   ├── Medicine.cs
│   ├── Prescription.cs
│   ├── Appartient.cs
│   └── UserSession.cs
│
├── Forms/
│   ├── Form1.cs (Login)
│   ├── FormAdmin.cs
│   ├── FormDoctor.cs
│   ├── FormAddpatient.cs
│   ├── FormAddUser.cs
│   ├── FormPrescription.cs
│   ├── FormDetailMedicine.cs
│   └── FormModifyAdmin.cs
│
├── Utils/
│   └── ExporterPDF.cs
│
├── Properties/
│   └── Resources.resx
│
├── Program.cs
└── GSB C#.csproj
```

---

## 4.11 Synthèse de l'architecture

| Aspect | Choix technique | Justification |
|--------|-----------------|---------------|
| **Architecture** | 3-tier (UI, Métier, DAO) | Séparation des responsabilités, maintenabilité |
| **UI** | Windows Forms | Exigence projet (application desktop Windows) |
| **Accès données** | ADO.NET + MySql.Data | Léger, performant, contrôle total des requêtes SQL |
| **Base de données** | MySQL 8.x | Open-source, robuste, adapté au projet |
| **Sécurité** | Requêtes paramétrées, hash passwords, sessions | Prévenir injections SQL, sécuriser authentification |
| **Export** | iTextSharp | Bibliothèque mature pour génération PDF en C# |

Cette architecture garantit une application modulaire, testable et évolutive, conforme aux bonnes pratiques du développement logiciel.





