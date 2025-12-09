# 2. Diagrammes UML

## 2.1 Diagramme de cas d'utilisation

Le diagramme ci-dessous présente les interactions entre les acteurs (Administrateur, Médecin/Visiteur) et le système GSB.

```plantuml
@startuml
left to right direction
skinparam actorStyle awesome

actor "Administrateur" as Admin
actor "Médecin / Visiteur" as Medecin

rectangle "Système GSB" {
  usecase "S'authentifier" as UC1
  usecase "Gérer les utilisateurs" as UC2
  usecase "Créer un utilisateur" as UC2.1
  usecase "Modifier un utilisateur" as UC2.2
  usecase "Supprimer un utilisateur" as UC2.3
  
  usecase "Gérer les patients" as UC3
  usecase "Ajouter un patient" as UC3.1
  usecase "Consulter les patients" as UC3.2
  usecase "Modifier un patient" as UC3.3
  usecase "Supprimer un patient" as UC3.4
  
  usecase "Gérer les médicaments" as UC4
  usecase "Ajouter un médicament" as UC4.1
  usecase "Consulter les médicaments" as UC4.2
  usecase "Modifier un médicament" as UC4.3
  usecase "Supprimer un médicament" as UC4.4
  
  usecase "Gérer les prescriptions" as UC5
  usecase "Créer une prescription" as UC5.1
  usecase "Consulter les prescriptions" as UC5.2
  usecase "Modifier une prescription" as UC5.3
  usecase "Supprimer une prescription" as UC5.4
  
  usecase "Exporter en PDF" as UC6
}

Admin --> UC1
Medecin --> UC1

Admin --> UC2
UC2 ..> UC2.1 : <<include>>
UC2 ..> UC2.2 : <<include>>
UC2 ..> UC2.3 : <<include>>

Admin --> UC4
Medecin --> UC4
UC4 ..> UC4.1 : <<include>>
UC4 ..> UC4.2 : <<include>>
UC4 ..> UC4.3 : <<include>>
UC4 ..> UC4.4 : <<include>>

Medecin --> UC3
UC3 ..> UC3.1 : <<include>>
UC3 ..> UC3.2 : <<include>>
UC3 ..> UC3.3 : <<include>>
UC3 ..> UC3.4 : <<include>>

Medecin --> UC5
UC5 ..> UC5.1 : <<include>>
UC5 ..> UC5.2 : <<include>>
UC5 ..> UC5.3 : <<include>>
UC5 ..> UC5.4 : <<include>>

Medecin --> UC6
UC6 ..> UC5.2 : <<extend>>

@enduml
```

### Description des cas d'utilisation principaux

| ID | Cas d'utilisation | Acteur(s) | Description |
|----|-------------------|-----------|-------------|
| UC1 | S'authentifier | Admin, Médecin | Connexion avec email et mot de passe. Création d'une session. |
| UC2 | Gérer les utilisateurs | Admin | CRUD des comptes utilisateurs (création, modification, suppression). |
| UC3 | Gérer les patients | Médecin | CRUD des patients (ajout, consultation, modification, suppression). |
| UC4 | Gérer les médicaments | Admin, Médecin | CRUD du catalogue de médicaments. |
| UC5 | Gérer les prescriptions | Médecin | Création, consultation, modification et suppression de prescriptions avec association médicaments. |
| UC6 | Exporter en PDF | Médecin | Génération d'un document PDF d'une prescription sélectionnée. |

---

## 2.2 Diagramme de classes

Le diagramme de classes représente la structure statique de l'application avec les entités métier et leurs relations.

```plantuml
@startuml
skinparam classAttributeIconSize 0

class User {
  + id_users : int
  + firstname : string
  + lastname : string
  + email : string
  + password : string
  + role : string
  + created_at : DateTime
  --
  + User()
  + User(id, firstname, lastname, email, password, role)
}

class Patient {
  + id_patient : int
  + firstname : string
  + lastname : string
  + birthdate : DateTime
  + address : string
  + phone : string
  --
  + Patient()
  + Patient(id, firstname, lastname, birthdate, address, phone)
}

class Medicine {
  + MedecineId : int
  + UserId : int
  + Name : string
  + Molecule : string
  + Dosage : string
  + Description : string
  --
  + Medicine()
  + Medicine(id, userId, name, molecule, dosage, description)
}

class Prescription {
  + id_prescription : int
  + id_patient : int
  + id_users : int
  + date : DateTime
  + notes : string
  --
  + Prescription()
  + Prescription(id, patientId, userId, date, notes)
}

class Appartient {
  + id_appartient : int
  + id_prescription : int
  + id_medicine : int
  + quantity : int
  + posology : string
  --
  + Appartient()
  + Appartient(id, prescId, medId, qty, posology)
}

class UserSession {
  + {static} CurrentUser : User
  + {static} IsAuthenticated : bool
  --
  + {static} Login(user : User) : void
  + {static} Logout() : void
}

' Relations
User "1" -- "0..*" Medicine : crée >
User "1" -- "0..*" Prescription : rédige >
Patient "1" -- "0..*" Prescription : reçoit >
Prescription "1" -- "0..*" Appartient : contient >
Medicine "1" -- "0..*" Appartient : inclus dans >

@enduml
```

### Description des classes principales

| Classe | Responsabilité |
|--------|----------------|
| **User** | Représente un utilisateur (admin ou médecin). Contient les informations d'authentification et le rôle. |
| **Patient** | Représente un patient avec ses coordonnées. |
| **Medicine** | Représente un médicament du catalogue (nom, molécule, dosage, description). Lié à l'utilisateur créateur. |
| **Prescription** | Représente une prescription rédigée par un utilisateur pour un patient à une date donnée. |
| **Appartient** | Table d'association entre Prescription et Medicine. Contient la quantité et la posologie pour chaque médicament prescrit. |
| **UserSession** | Classe statique pour gérer la session utilisateur en cours (authentification, déconnexion). |

---

## 2.3 Diagramme de séquence : Authentification

Ce diagramme illustre le processus de connexion d'un utilisateur.

```plantuml
@startuml
actor Utilisateur
participant "Form1\n(Login)" as Form1
participant "UserDAO" as DAO
participant "Database" as DB
participant "UserSession" as Session

Utilisateur -> Form1 : Saisir email/password
Utilisateur -> Form1 : Cliquer sur "Connexion"
activate Form1

Form1 -> DAO : Login(email, password)
activate DAO

DAO -> DB : SELECT * FROM Users WHERE email = ?
activate DB
DB --> DAO : Résultat (User ou null)
deactivate DB

alt Utilisateur trouvé
  DAO -> DAO : Vérifier password (comparaison hash)
  alt Mot de passe correct
    DAO --> Form1 : User
    deactivate DAO
    Form1 -> Session : Login(user)
    activate Session
    Session -> Session : CurrentUser = user
    Session -> Session : IsAuthenticated = true
    Session --> Form1 : Session créée
    deactivate Session
    Form1 -> Utilisateur : Afficher FormAdmin ou FormDoctor selon rôle
  else Mot de passe incorrect
    DAO --> Form1 : null
    Form1 -> Utilisateur : MessageBox "Identifiants incorrects"
  end
else Utilisateur non trouvé
  DAO --> Form1 : null
  Form1 -> Utilisateur : MessageBox "Identifiants incorrects"
end

deactivate Form1
@enduml
```

---

## 2.4 Diagramme de séquence : Création d'une prescription

Ce diagramme montre le flux complet de création d'une prescription avec association de médicaments.

```plantuml
@startuml
actor Médecin
participant "FormPrescription" as Form
participant "PrescriptionDAO" as PrescDAO
participant "AppartientDAO" as AppDAO
participant "Database" as DB

Médecin -> Form : Sélectionner patient
Médecin -> Form : Saisir date et notes
Médecin -> Form : Ajouter médicaments (quantité, posologie)
Médecin -> Form : Cliquer sur "Enregistrer"
activate Form

Form -> Form : Valider les données
alt Données valides
  Form -> PrescDAO : Add(prescription)
  activate PrescDAO
  
  PrescDAO -> DB : INSERT INTO Prescription (...)
  activate DB
  DB --> PrescDAO : id_prescription généré
  deactivate DB
  
  PrescDAO --> Form : true, id_prescription
  deactivate PrescDAO
  
  loop Pour chaque médicament sélectionné
    Form -> AppDAO : Add(appartient)
    activate AppDAO
    AppDAO -> DB : INSERT INTO Appartient (id_prescription, id_medicine, quantity, posology)
    activate DB
    DB --> AppDAO : OK
    deactivate DB
    AppDAO --> Form : true
    deactivate AppDAO
  end
  
  Form -> Médecin : MessageBox "Prescription créée avec succès"
  Form -> Form : Rafraîchir la liste
else Données invalides
  Form -> Médecin : MessageBox "Erreur : vérifier les champs"
end

deactivate Form
@enduml
```

---

## 2.5 Diagramme de séquence : Export PDF

Ce diagramme illustre le processus d'export d'une prescription au format PDF.

```plantuml
@startuml
actor Médecin
participant "FormPrescription" as Form
participant "PrescriptionDAO" as PrescDAO
participant "AppartientDAO" as AppDAO
participant "ExporterPDF" as PDF
participant "Database" as DB

Médecin -> Form : Sélectionner une prescription
Médecin -> Form : Cliquer sur "Exporter PDF"
activate Form

Form -> PrescDAO : GetById(id_prescription)
activate PrescDAO
PrescDAO -> DB : SELECT * FROM Prescription WHERE id = ?
activate DB
DB --> PrescDAO : Prescription
deactivate DB
PrescDAO --> Form : Prescription
deactivate PrescDAO

Form -> AppDAO : GetByPrescriptionId(id_prescription)
activate AppDAO
AppDAO -> DB : SELECT * FROM Appartient WHERE id_prescription = ?
activate DB
DB --> AppDAO : Liste Appartient (médicaments + posologies)
deactivate DB
AppDAO --> Form : Liste médicaments
deactivate AppDAO

Form -> PDF : GeneratePDF(prescription, médicaments, patient)
activate PDF

PDF -> PDF : Créer document PDF
PDF -> PDF : Ajouter en-tête (GSB, date)
PDF -> PDF : Ajouter infos patient
PDF -> PDF : Ajouter tableau médicaments (nom, dosage, quantité, posologie)
PDF -> PDF : Ajouter notes et signature prescripteur
PDF -> PDF : Enregistrer fichier

PDF --> Form : Chemin fichier PDF
deactivate PDF

Form -> Médecin : MessageBox "PDF généré : [chemin]"
Form -> Form : Ouvrir le PDF (optionnel)

deactivate Form
@enduml
```

---

## 2.6 Diagramme d'activité : Gestion d'une prescription

Ce diagramme représente le flux de travail complet pour gérer une prescription (création ou modification).

```plantuml
@startuml
start

:Médecin ouvre FormPrescription;

if (Mode création ou modification ?) then (création)
  :Sélectionner un patient;
  :Saisir date et notes;
else (modification)
  :Charger la prescription existante;
  :Afficher patient, date, notes, médicaments;
endif

:Ajouter/Modifier des médicaments;
:Saisir quantité et posologie pour chaque médicament;

if (Données valides ?) then (non)
  :Afficher message d'erreur;
  stop
else (oui)
endif

if (Mode création ?) then (oui)
  :Insérer Prescription dans la BD;
  :Récupérer id_prescription;
else (modification)
  :Mettre à jour Prescription dans la BD;
  :Supprimer les anciennes associations Appartient;
endif

:Insérer les nouvelles associations Appartient;

:Afficher message de succès;
:Rafraîchir la liste des prescriptions;

stop
@enduml
```

---

## 2.7 Synthèse des diagrammes

| Diagramme | Objectif | Niveau |
|-----------|----------|--------|
| **Cas d'utilisation** | Vue fonctionnelle globale : acteurs et fonctionnalités principales | Analyse |
| **Classes** | Structure statique du système : entités métier et relations | Conception |
| **Séquence (Authentification)** | Flux technique de connexion et gestion de session | Conception détaillée |
| **Séquence (Création prescription)** | Flux de création d'une prescription avec associations | Conception détaillée |
| **Séquence (Export PDF)** | Processus de génération d'un document PDF | Conception détaillée |
| **Activité** | Logique métier de gestion d'une prescription | Analyse/Conception |

Ces diagrammes servent de référence pour l'implémentation du code et la validation des fonctionnalités avec le client/jury.


