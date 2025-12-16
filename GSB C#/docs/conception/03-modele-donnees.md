# 3. Modèle de données (Merise)

## 3.1 Modèle Conceptuel de Données (MCD)

Le MCD représente les entités métier et leurs associations sans considération technique.

```
┌─────────────────────┐
│       USER          │
├─────────────────────┤
│ id_users (PK)       │
│ firstname           │
│ lastname            │
│ email               │
│ password            │
│ role                │
│ created_at          │
└─────────────────────┘
        │
        │ 1,n
        │
        ▼ crée
┌─────────────────────┐
│     MEDICINE        │
├─────────────────────┤
│ id_medicine (PK)    │
│ #id_users (FK)      │
│ name                │
│ molecule            │
│ dosage              │
│ description         │
└─────────────────────┘
        │
        │ 0,n
        ▼
    ┌───────────────┐
    │  APPARTIENT   │ (association)
    ├───────────────┤
    │ quantity      │
    │ posology      │
    └───────────────┘
        │
        │ 0,n
        ▼
┌─────────────────────┐
│   PRESCRIPTION      │
├─────────────────────┤
│ id_prescription (PK)│
│ #id_patient (FK)    │
│ #id_users (FK)      │
│ date                │
│ notes               │
└─────────────────────┘
        ▲
        │ 0,n
        │ reçoit
        │
┌─────────────────────┐
│      PATIENT        │
├─────────────────────┤
│ id_patient (PK)     │
│ firstname           │
│ lastname            │
│ birthdate           │
│ address             │
│ phone               │
└─────────────────────┘
```

### Cardinalités

| Association | Entité 1 | Cardinalité 1 | Entité 2 | Cardinalité 2 | Description |
|-------------|----------|---------------|----------|---------------|-------------|
| **crée** | USER | 1,n | MEDICINE | 0,n | Un utilisateur crée 0 ou plusieurs médicaments. Un médicament est créé par un seul utilisateur. |
| **rédige** | USER | 1,n | PRESCRIPTION | 0,n | Un utilisateur rédige 0 ou plusieurs prescriptions. Une prescription est rédigée par un seul utilisateur. |
| **reçoit** | PATIENT | 1,n | PRESCRIPTION | 0,n | Un patient reçoit 0 ou plusieurs prescriptions. Une prescription concerne un seul patient. |
| **APPARTIENT** | MEDICINE | 0,n | PRESCRIPTION | 0,n | Une prescription contient 0 ou plusieurs médicaments. Un médicament peut être dans 0 ou plusieurs prescriptions. |

---

## 3.2 Modèle Logique de Données (MLD)

Le MLD traduit le MCD en tables relationnelles avec clés primaires (PK) et clés étrangères (FK).

### Tables

#### **Users**
- **id_users** (PK, INT, AUTO_INCREMENT)
- firstname (VARCHAR(100))
- lastname (VARCHAR(100))
- email (VARCHAR(255), UNIQUE)
- password (VARCHAR(255))
- role (VARCHAR(50))
- created_at (DATETIME, DEFAULT CURRENT_TIMESTAMP)

#### **Patients**
- **id_patient** (PK, INT, AUTO_INCREMENT)
- firstname (VARCHAR(100))
- lastname (VARCHAR(100))
- birthdate (DATE)
- address (VARCHAR(255))
- phone (VARCHAR(50))

#### **Medicine**
- **id_medicine** (PK, INT, AUTO_INCREMENT)
- **id_users** (FK → Users.id_users)
- name (VARCHAR(255))
- molecule (VARCHAR(255))
- dosage (VARCHAR(100))
- description (TEXT)

#### **Prescription**
- **id_prescription** (PK, INT, AUTO_INCREMENT)
- **id_patient** (FK → Patients.id_patient)
- **id_users** (FK → Users.id_users)
- date (DATE)
- notes (TEXT)

#### **Appartient** (table d'association)
- **id_appartient** (PK, INT, AUTO_INCREMENT)
- **id_prescription** (FK → Prescription.id_prescription)
- **id_medicine** (FK → Medicine.id_medicine)
- quantity (INT)
- posology (VARCHAR(255))

---

## 3.3 Modèle Physique de Données (MPD) - Script SQL

```sql
-- Base de données
CREATE DATABASE IF NOT EXISTS `bts-gsb` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `bts-gsb`;

-- Table Users
CREATE TABLE Users (
  id_users INT AUTO_INCREMENT PRIMARY KEY,
  firstname VARCHAR(100) NOT NULL,
  lastname VARCHAR(100) NOT NULL,
  email VARCHAR(255) NOT NULL UNIQUE,
  password VARCHAR(255) NOT NULL,
  role VARCHAR(50) NOT NULL DEFAULT 'medecin',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  INDEX idx_email (email),
  INDEX idx_role (role)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Table Patients
CREATE TABLE Patients (
  id_patient INT AUTO_INCREMENT PRIMARY KEY,
  firstname VARCHAR(100) NOT NULL,
  lastname VARCHAR(100) NOT NULL,
  birthdate DATE,
  address VARCHAR(255),
  phone VARCHAR(50),
  INDEX idx_name (lastname, firstname)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Table Medicine
CREATE TABLE Medicine (
  id_medicine INT AUTO_INCREMENT PRIMARY KEY,
  id_users INT NOT NULL,
  name VARCHAR(255) NOT NULL,
  molecule VARCHAR(255),
  dosage VARCHAR(100),
  description TEXT,
  INDEX idx_name (name),
  INDEX idx_molecule (molecule),
  FOREIGN KEY (id_users) REFERENCES Users(id_users) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Table Prescription
CREATE TABLE Prescription (
  id_prescription INT AUTO_INCREMENT PRIMARY KEY,
  id_patient INT NOT NULL,
  id_users INT NOT NULL,
  date DATE NOT NULL,
  notes TEXT,
  INDEX idx_date (date),
  INDEX idx_patient (id_patient),
  FOREIGN KEY (id_patient) REFERENCES Patients(id_patient) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY (id_users) REFERENCES Users(id_users) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Table Appartient (association Prescription-Medicine)
CREATE TABLE Appartient (
  id_appartient INT AUTO_INCREMENT PRIMARY KEY,
  id_prescription INT NOT NULL,
  id_medicine INT NOT NULL,
  quantity INT NOT NULL DEFAULT 1,
  posology VARCHAR(255),
  UNIQUE KEY unique_prescription_medicine (id_prescription, id_medicine),
  FOREIGN KEY (id_prescription) REFERENCES Prescription(id_prescription) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY (id_medicine) REFERENCES Medicine(id_medicine) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Données de test (seed)
-- Utilisateur admin (mot de passe : Admin123! hashé avec bcrypt)
INSERT INTO Users (firstname, lastname, email, password, role) 
VALUES ('Admin', 'Système', 'admin@gsb.fr', '$2a$11$6EW8ZqQjY5Bb3xK4F4gN5.vYzJh9KqZ3Xm8FYqX5YqX5YqX5YqX5Y', 'admin');

-- Utilisateur médecin (mot de passe : Medecin123!)
INSERT INTO Users (firstname, lastname, email, password, role) 
VALUES ('Jean', 'Dupont', 'jean.dupont@gsb.fr', '$2a$11$7FX9ArRkZ6Cc4yL5G5hO6.wZaKi0LrA4Yn9GAr6Ar6Ar6Ar6Ar6Ar', 'medecin');

-- Patients de test
INSERT INTO Patients (firstname, lastname, birthdate, address, phone) 
VALUES 
('Marie', 'Martin', '1985-03-15', '12 rue de la Paix, 75001 Paris', '0612345678'),
('Pierre', 'Bernard', '1970-07-22', '34 avenue des Champs, 69001 Lyon', '0623456789'),
('Sophie', 'Dubois', '1992-11-08', '56 boulevard Victor Hugo, 31000 Toulouse', '0634567890');

-- Médicaments de test (créés par l'admin)
INSERT INTO Medicine (id_users, name, molecule, dosage, description) 
VALUES 
(1, 'Doliprane', 'Paracétamol', '1000mg', 'Antalgique et antipyrétique'),
(1, 'Aspirine', 'Acide acétylsalicylique', '500mg', 'Anti-inflammatoire non stéroïdien'),
(1, 'Amoxicilline', 'Amoxicilline', '500mg', 'Antibiotique à large spectre');

-- Prescription de test
INSERT INTO Prescription (id_patient, id_users, date, notes) 
VALUES (1, 2, '2024-12-01', 'Traitement pour douleurs et fièvre');

-- Association médicaments-prescription
INSERT INTO Appartient (id_prescription, id_medicine, quantity, posology) 
VALUES 
(1, 1, 30, '1 comprimé 3 fois par jour pendant 10 jours'),
(1, 2, 20, '1 comprimé matin et soir pendant 10 jours');
```

---

## 3.4 Contraintes d'intégrité

| Contrainte | Type | Description |
|------------|------|-------------|
| **PK** | Clé primaire | Chaque table possède un identifiant unique auto-incrémenté. |
| **FK ON DELETE RESTRICT** | Intégrité référentielle | Medicine.id_users : impossible de supprimer un utilisateur ayant créé des médicaments. |
| **FK ON DELETE CASCADE** | Intégrité référentielle | Prescription.id_patient : suppression d'un patient supprime ses prescriptions. |
| **UNIQUE** | Unicité | Users.email : un email ne peut être utilisé qu'une seule fois. |
| **UNIQUE composite** | Unicité | Appartient(id_prescription, id_medicine) : un médicament ne peut être ajouté qu'une fois par prescription. |
| **NOT NULL** | Obligation | Champs clés et données essentielles (nom, email, etc.) sont obligatoires. |
| **INDEX** | Performance | Index sur les colonnes fréquemment recherchées (email, nom, date). |

---

## 3.5 Règles de gestion métier

1. **RG1** : Un utilisateur doit avoir un email unique.
2. **RG2** : Un mot de passe doit être hashé (bcrypt/argon2) avant stockage.
3. **RG3** : Un utilisateur de rôle "admin" peut gérer les utilisateurs et les médicaments.
4. **RG4** : Un utilisateur de rôle "medecin" peut gérer les patients et les prescriptions.
5. **RG5** : Une prescription doit contenir au moins un médicament (via Appartient).
6. **RG6** : La suppression d'un patient entraîne la suppression de ses prescriptions (CASCADE).
7. **RG7** : La suppression d'un médicament est bloquée s'il est utilisé dans une prescription (RESTRICT).
8. **RG8** : Un médicament ne peut être ajouté qu'une seule fois à une prescription (UNIQUE composite).
9. **RG9** : La posologie et la quantité sont obligatoires pour chaque association médicament-prescription.
10. **RG10** : Les dates de prescription et de naissance sont au format DATE (YYYY-MM-DD).

---

## 3.6 Dictionnaire de données

| Table | Colonne | Type | Taille | Obligatoire | Description |
|-------|---------|------|--------|-------------|-------------|
| Users | id_users | INT | - | Oui | Identifiant unique |
| Users | firstname | VARCHAR | 100 | Oui | Prénom |
| Users | lastname | VARCHAR | 100 | Oui | Nom |
| Users | email | VARCHAR | 255 | Oui | Adresse email (unique) |
| Users | password | VARCHAR | 255 | Oui | Mot de passe hashé |
| Users | role | VARCHAR | 50 | Oui | Rôle (admin, medecin) |
| Users | created_at | DATETIME | - | Oui | Date de création du compte |
| Patients | id_patient | INT | - | Oui | Identifiant unique |
| Patients | firstname | VARCHAR | 100 | Oui | Prénom |
| Patients | lastname | VARCHAR | 100 | Oui | Nom |
| Patients | birthdate | DATE | - | Non | Date de naissance |
| Patients | address | VARCHAR | 255 | Non | Adresse postale |
| Patients | phone | VARCHAR | 50 | Non | Numéro de téléphone |
| Medicine | id_medicine | INT | - | Oui | Identifiant unique |
| Medicine | id_users | INT | - | Oui | Créateur (FK) |
| Medicine | name | VARCHAR | 255 | Oui | Nom commercial |
| Medicine | molecule | VARCHAR | 255 | Non | Molécule active |
| Medicine | dosage | VARCHAR | 100 | Non | Dosage (ex: 500mg) |
| Medicine | description | TEXT | - | Non | Description détaillée |
| Prescription | id_prescription | INT | - | Oui | Identifiant unique |
| Prescription | id_patient | INT | - | Oui | Patient concerné (FK) |
| Prescription | id_users | INT | - | Oui | Prescripteur (FK) |
| Prescription | date | DATE | - | Oui | Date de prescription |
| Prescription | notes | TEXT | - | Non | Notes et observations |
| Appartient | id_appartient | INT | - | Oui | Identifiant unique |
| Appartient | id_prescription | INT | - | Oui | Prescription (FK) |
| Appartient | id_medicine | INT | - | Oui | Médicament (FK) |
| Appartient | quantity | INT | - | Oui | Quantité prescrite |
| Appartient | posology | VARCHAR | 255 | Non | Posologie (ex: 1cp x3/j) |

---

## 3.7 Remarques et évolutions possibles

### Remarques sur le modèle actuel
- Le modèle est simple et fonctionnel pour le périmètre défini.
- Les contraintes d'intégrité garantissent la cohérence des données.
- Les index optimisent les recherches fréquentes (email, nom, date).

### Évolutions possibles (V2)
1. **Historique des modifications** : table d'audit pour tracer les modifications (qui, quand, quoi).
2. **Gestion des stocks** : ajouter une table Stock pour suivre les quantités disponibles de chaque médicament.
3. **Allergies et contre-indications** : table Patient_Allergies et contrôle lors de la prescription.
4. **Versioning des prescriptions** : conserver l'historique des modifications d'une prescription.
5. **Multi-établissements** : ajouter une table Etablissement et lier les utilisateurs/patients.
6. **Soft delete** : ajouter un champ `deleted_at` pour marquer les suppressions logiques au lieu de physiques.









