# GSB WinForms

Application WinForms (C#, .NET Framework) de gestion des comptes-rendus de visite des visiteurs médicaux pour le laboratoire Galaxy Swiss Bourdin (GSB) avec MySQL.

---

## 📚 Documentation complète du projet

**Pour la documentation technique complète (BTS SLAM)**, consultez le [Dossier de projet BTS](docs/00-dossier-projet-bts.md) qui inclut :

- **[Contexte et Cahier des charges](docs/01-contexte-cahier-charges.md)** : présentation GSB, besoins, objectifs, contraintes
- **[Conception - Diagrammes UML](docs/conception/02-diagrammes-uml.md)** : cas d'utilisation, classes, séquences, activité
- **[Conception - Modèle de données](docs/conception/03-modele-donnees.md)** : MCD/MLD/MPD avec script SQL complet
- **[Conception - Architecture](docs/conception/04-architecture.md)** : architecture 3 tiers, patterns, sécurité
- **[Réalisation technique](docs/realisation/05-realisation-technique.md)** : choix techniques, code commenté, difficultés
- **[Plan de tests](docs/tests/06-plan-de-tests.md)** : tests fonctionnels, sécurité, performance, résultats
- **[Veille technologique](docs/veille/07-veille-technologique.md)** : comparaisons, OWASP, évolutions
- **[Annexes](docs/annexes/08-annexes.md)** : script SQL, extraits code, glossaire, bibliographie

---

## Sommaire (guide rapide)
- [Prérequis](#prérequis)
- [Installation & configuration](#installation--configuration)
- [Comptes de test](#-comptes-de-test)
- [Démarrage rapide](#démarrage-rapide)
- [Architecture](#architecture)
- [Résumé API (DAO)](#résumé-api-dao)
- [Fonctionnalités clés](#fonctionnalités-clés)
- [Base de données](#base-de-données)
- [Flux d'usage](#flux-dusage)
- [Navigation des formulaires](#navigation-des-formulaires)
- [Sécurité](#sécurité)
- [Connexion DB](#connexion-db)
- [Build / Distribution](#build--distribution)
- [Dépendances](#dépendances-nuget)
- [Gestion des erreurs](#gestion-des-erreurs)
- [Support / FAQ](#support--faq)

## Prérequis
- .NET Framework 4.8 (ou version compatible)
- Microsoft Visual Studio 2022
- MySQL (adapter port/identifiants)
- Accès réseau base de données (`localhost:3306` par défaut)

## Installation & configuration
1. Cloner le dépôt.
```bash
git clone https://github.com/Alexandre-ab/GSB-C-.git
cd GSB-C-
```
2. Démarrer la base de données :
   - **Option A (Docker - Recommandé)** :
     - Aller dans le dossier `docker/`.
     - Lancer : `docker-compose up -d`.
     - La base `bts-gsb` est automatiquement créée et peuplée sur `localhost:3306`.
   - **Option B (Manuelle)** :
     - Importer le fichier `docker/init.sql` dans votre serveur MySQL.
     - Adapter la chaîne de connexion dans `App.config` (serveur, port, user, pwd) si nécessaire.
3. Ouvrir `GSB C#.sln` dans Visual Studio 2022, restaurer les packages NuGet.

## 🔑 Comptes de test

| Rôle | Email | Mot de passe | Accès |
|------|-------|-------------|-------|
| **Admin** | claire.lefevre@example.com | `123` | Gestion visiteurs + tous les rapports |
| **User** (visiteur médical) | emma.petit@example.com | `1234` | Ses propres rapports uniquement |

> **Note :** les mots de passe sont stockés en clair dans la base de données dans ce contexte pédagogique. En production, un hachage bcrypt serait implémenté.

## Démarrage rapide
- Visual Studio : ouvrir `GSB C#.sln`, choisir le profil, F5.
- CLI : `dotnet run --project "GSB C#.csproj"`

## Architecture
- DAO (`Dao/`) : MySQL (`Database`) + CRUD pour `Medicine`, `Patients`, `Prescription`, `User`, `Appartient`.
- Modèles (`Models/`) : entités (`Medicine`, `Patients`, `Prescription`, `User`, `Appartient`, `UserSession`).
- Interface (`Forms/`) : formulaires d'admin, visiteurs/praticiens, prescriptions, ajout utilisateurs.
- Utilitaires (`Utils/`) : `ExporterPDF` (iTextSharp) pour PDF.

## Résumé API (DAO)
- `MedicineDao`, `PatientsDao`, `PrescriptionDao`, `UserDAO`, `AppartientDao` : CRUD + requêtes (GetAll, GetById, filtres, insert/update/delete).
- `Database` : fournit les connexions MySQL.

## Fonctionnalités clés
- Authentification avec gestion des rôles (Admin / User).
- Consultation de la liste des praticiens visités.
- Saisie et modification des comptes-rendus de visite (CRUD).
- Gestion des visiteurs par l'administrateur (ajout, invitation, suppression).
- Médicaments (CRUD), prescriptions et associations médicament/prescription.
- Export PDF.

## Base de données
Tables (à adapter) :
- `Users` : id_users PK, firstname, lastname, email (unique), password, role, created_at.
- `Patients` : id_patient PK, firstname, lastname, birthdate, address, phone.
- `Medicine` : id_medicine PK, id_users FK, name, molecule, dosage, description.
- `Prescription` : id_prescription PK, id_patient FK, id_users FK, date, notes.
- `Appartient` : id_appartient PK, id_prescription FK, id_medicine FK, quantity, posology.

Initialisation :
Utilisez le fichier `docker/init.sql` pour créer la base de données, les tables et insérer les données de test.

Alternativement, suivez les étapes manuelles :
1. Créer la base `bts-gsb`.
2. Importer le contenu de `docker/init.sql`.
3. Ajuster la chaîne de connexion dans `App.config`.

SQL minimal (exemple) :
```sql
CREATE TABLE Users (
  id_users INT AUTO_INCREMENT PRIMARY KEY,
  firstname VARCHAR(100), lastname VARCHAR(100),
  email VARCHAR(255) UNIQUE,
  password VARCHAR(255),
  role VARCHAR(50),
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE Patients (
  id_patient INT AUTO_INCREMENT PRIMARY KEY,
  firstname VARCHAR(100), lastname VARCHAR(100),
  birthdate DATE, address VARCHAR(255), phone VARCHAR(50)
);
CREATE TABLE Medicine (
  id_medicine INT AUTO_INCREMENT PRIMARY KEY,
  id_users INT, name VARCHAR(255), molecule VARCHAR(255),
  dosage VARCHAR(100), description TEXT,
  FOREIGN KEY (id_users) REFERENCES Users(id_users)
);
CREATE TABLE Prescription (
  id_prescription INT AUTO_INCREMENT PRIMARY KEY,
  id_patient INT, id_users INT,
  date DATE, notes TEXT,
  FOREIGN KEY (id_patient) REFERENCES Patients(id_patient),
  FOREIGN KEY (id_users) REFERENCES Users(id_users)
);
CREATE TABLE Appartient (
  id_appartient INT AUTO_INCREMENT PRIMARY KEY,
  id_prescription INT, id_medicine INT,
  quantity INT, posology VARCHAR(255),
  FOREIGN KEY (id_prescription) REFERENCES Prescription(id_prescription),
  FOREIGN KEY (id_medicine) REFERENCES Medicine(id_medicine)
);
```

## Flux d'usage
- Création utilisateur : `FormAdmin` / `FormAddUser`, stocké dans `Users`.
- Praticiens : `FormDoctor` / `FormAddpatient` (CRUD `Patients`).
- Médicaments : `FormAdmin` / `FormDetailMedicine` / `FormPrescription` (CRUD `Medicine`).
- Prescription : `FormPrescription` (praticien, médicaments via `Appartient`, posologie/quantité), enregistrement dans `Prescription`.
- Export PDF : via `Utils/ExporterPDF`.

## Navigation des formulaires
- `FrmConnexion` : authentification sécurisée.
- `FrmMenu` : menu principal, navigation entre fenêtres.
- `FrmRapport` : gestion CRUD des rapports de visite.
- `FormAdmin` : administration (utilisateurs, médicaments).
- `FormDoctor` : praticien (praticiens, prescriptions).
- `FormPrescription` : création/édition de prescriptions et associations.
- `FormAddpatient`, `FormAddUser`, `FormModifyAdmin`, `FormDetailMedicine` : écrans dédiés d'ajout/édition.
- `FormPrescription` + `FormDetailMedicine` : détail médicament dans le contexte d'une prescription.

## Détail DAO / modèles
- DAO : GetAll, GetById, filtres, insert, update, delete.
- Modèles : propriétés mappées aux colonnes (voir `Models/*.cs`).

## Sécurité
- Requêtes préparées pour prévenir les injections SQL.
- Gestion des rôles (Admin/User) conditionnant l'accès aux fonctionnalités.
- Mots de passe stockés en clair dans ce contexte pédagogique. En production, un hachage (bcrypt ou argon2) serait implémenté pour sécuriser les credentials.
- Compte MySQL à privilèges limités dédié à l'app.
- Pas de credentials commités : variables d'environnement ou secrets utilisateur.
- Journaliser les erreurs côté serveur sans exposer d'infos sensibles.

## Connexion DB
- Exemple : `Server=localhost;Port=3306;Database=bts-gsb;Uid=root;Pwd=xxxx;`
- Configuration dans `App.config`.
- Production : privilégier appsettings / secrets / env vars.

## Build / Distribution
- Restore : `dotnet restore`
- Run : `dotnet run --project "GSB C#.csproj"`
- Publish : `dotnet publish -c Release -r win-x64 --self-contained false -o publish`
  - Binaire dans `publish/` à distribuer avec dépendances.

## Dépendances NuGet
- `MySql.Data` : accès MySQL (MySQL Connector/NET).
- `iTextSharp` : génération PDF (`Utils/ExporterPDF.cs`).

## Gestion des erreurs
- Connexion MySQL : vérifier hôte/port/identifiants dans `App.config`; capturer les exceptions MySQL, afficher un message utilisateur.
- Exceptions DAO : try/catch dans l'UI pour éviter les crashs et journaliser.
- Changement d'environnement : surcharger la chaîne de connexion via env vars ou config.

## Support / FAQ
- Connexion MySQL : vérifier hôte/port/identifiants.
- Dépendances : `dotnet restore`.
- Changer de base : ajuster la chaîne de connexion et appliquer le schéma.

---

## 📖 Pour aller plus loin

### Documentation BTS SLAM complète

Ce README est un guide rapide. Pour la documentation technique complète destinée au jury BTS, consultez :

**[📘 Dossier de projet BTS](docs/00-dossier-projet-bts.md)**

### Structure de la documentation

```
docs/
├── 00-dossier-projet-bts.md          ← Synthèse complète
├── 01-contexte-cahier-charges.md     ← Analyse du besoin
├── conception/
│   ├── 02-diagrammes-uml.md          ← UML (6 diagrammes)
│   ├── 03-modele-donnees.md          ← MCD/MLD/MPD + SQL
│   └── 04-architecture.md            ← Architecture 3 tiers
├── realisation/
│   └── 05-realisation-technique.md   ← Code commenté, choix
├── tests/
│   └── 06-plan-de-tests.md           ← 46 tests, résultats
├── veille/
│   └── 07-veille-technologique.md    ← Comparaisons, OWASP
└── annexes/
    └── 08-annexes.md                 ← Script SQL, glossaire
```

### Liens rapides

- **Démarrage rapide** : [Installation](docs/01-contexte-cahier-charges.md#12-cahier-des-charges-fonctionnel)
- **Script SQL complet** : [Annexes - Script SQL](docs/annexes/08-annexes.md#81-script-sql-complet)
- **Diagrammes UML** : [Conception - UML](docs/conception/02-diagrammes-uml.md)
- **Résultats tests** : [Plan de tests - Résultats](docs/tests/06-plan-de-tests.md#64-tests-de-sécurité)
- **Veille sécurité** : [Veille - OWASP Top 10](docs/veille/07-veille-technologique.md#77-protection-contre-les-attaques--owasp-top-10)

---

## 🎯 Projet BTS SLAM 2024-2025

**Candidat** : Alexandre Boué
**Formation** : BTS SIO option SLAM  
**Session** : 2024-2026
