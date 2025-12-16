# 1. Contexte et Cahier des Charges

## 1.1 Présentation du contexte

### L'entreprise GSB (Galaxy Swiss Bourdin)

**GSB** est un laboratoire pharmaceutique fictif spécialisé dans la fabrication et la distribution de médicaments. L'entreprise emploie des **visiteurs médicaux** chargés de promouvoir les produits auprès des professionnels de santé (médecins, pharmaciens, hôpitaux).

### Problématique métier

Les visiteurs médicaux et l'équipe administrative doivent gérer :
- **Les informations patients** : coordonnées, historique médical.
- **Le catalogue de médicaments** : composition, dosage, indications.
- **Les prescriptions** : association patient-médicaments avec posologie et quantités.
- **Les exports** : génération de documents PDF pour archivage ou transmission.

Actuellement, ces données sont gérées de manière disparate (tableurs, documents papier), ce qui entraîne :
- Risques d'erreurs et de doublons.
- Difficulté à suivre l'historique des prescriptions.
- Perte de temps dans la recherche d'informations.
- Absence de traçabilité et de sécurité.

### Objectif du projet

Développer une **application de gestion centralisée** permettant de :
1. Créer et gérer les comptes utilisateurs (administrateurs, médecins/visiteurs).
2. Enregistrer et consulter les patients.
3. Gérer le catalogue de médicaments.
4. Créer des prescriptions en associant patients et médicaments avec posologie.
5. Exporter les prescriptions au format PDF.
6. Garantir la sécurité des données (authentification, droits d'accès, confidentialité).

---

## 1.2 Cahier des charges fonctionnel

### Acteurs

| Acteur | Rôle |
|--------|------|
| **Administrateur** | Gère les utilisateurs, le catalogue de médicaments, supervise l'ensemble du système. |
| **Médecin / Visiteur médical** | Consulte et gère les patients, crée et consulte les prescriptions, exporte les documents. |

### Fonctionnalités principales

#### F1 : Gestion des utilisateurs
- **F1.1** : Création d'un compte utilisateur (admin uniquement).
- **F1.2** : Authentification (email + mot de passe).
- **F1.3** : Gestion des rôles (admin, médecin).
- **F1.4** : Modification et suppression d'utilisateurs (admin uniquement).

#### F2 : Gestion des patients
- **F2.1** : Ajouter un patient (nom, prénom, date de naissance, adresse, téléphone).
- **F2.2** : Consulter la liste des patients.
- **F2.3** : Modifier les informations d'un patient.
- **F2.4** : Supprimer un patient.
- **F2.5** : Rechercher un patient (par nom, prénom).

#### F3 : Gestion des médicaments
- **F3.1** : Ajouter un médicament (nom, molécule, dosage, description).
- **F3.2** : Consulter le catalogue de médicaments.
- **F3.3** : Modifier un médicament.
- **F3.4** : Supprimer un médicament.
- **F3.5** : Rechercher un médicament (par nom, molécule).

#### F4 : Gestion des prescriptions
- **F4.1** : Créer une prescription (sélection patient, date, notes).
- **F4.2** : Associer des médicaments à une prescription (quantité, posologie).
- **F4.3** : Consulter les prescriptions d'un patient.
- **F4.4** : Modifier une prescription existante.
- **F4.5** : Supprimer une prescription.

#### F5 : Export et impression
- **F5.1** : Exporter une prescription au format PDF.
- **F5.2** : Inclure les informations patient, médicaments prescrits, posologies, date et prescripteur.

#### F6 : Sécurité
- **F6.1** : Authentification obligatoire pour accéder à l'application.
- **F6.2** : Hashage des mots de passe (bcrypt ou argon2).
- **F6.3** : Gestion des sessions utilisateur.
- **F6.4** : Contrôle d'accès basé sur les rôles (admin vs médecin).

---

## 1.3 Contraintes techniques

### Environnement de développement
- **Langage** : C# (.NET 8)
- **Framework UI** : Windows Forms (WinForms)
- **Base de données** : MySQL 8.x
- **Bibliothèques tierces** :
  - `MySql.Data` : accès à la base de données
  - `iTextSharp` : génération de PDF

### Contraintes non-fonctionnelles
- **Performance** : temps de réponse < 2s pour les opérations CRUD courantes.
- **Sécurité** : mots de passe hashés, connexion DB via utilisateur à privilèges limités.
- **Maintenabilité** : architecture en couches (DAO, Modèles, UI) pour faciliter l'évolution.
- **Portabilité** : application Windows uniquement (déploiement sur postes Windows 10/11).

### Livrables attendus
1. Application WinForms fonctionnelle.
2. Base de données MySQL avec script d'initialisation.
3. Documentation technique (ce dossier).
4. Guide utilisateur (captures d'écran, procédures).
5. Plan de tests et résultats.

---

## 1.4 Périmètre du projet

### Inclus
- Gestion complète des utilisateurs, patients, médicaments et prescriptions.
- Export PDF des prescriptions.
- Interface graphique intuitive (WinForms).
- Authentification et gestion des sessions.

### Exclus (hors périmètre)
- Application web ou mobile.
- Synchronisation multi-postes en temps réel.
- Gestion des stocks de médicaments.
- Facturation ou gestion financière.
- Notifications automatiques (email, SMS).

---

## 1.5 Planning prévisionnel

| Phase | Durée estimée | Livrables |
|-------|---------------|-----------|
| Analyse et conception | 2 semaines | Diagrammes UML, MCD/MLD, maquettes |
| Développement | 4 semaines | Code source, base de données |
| Tests et corrections | 1 semaine | Plan de tests, rapport de bugs |
| Documentation | 1 semaine | Dossier technique, guide utilisateur |
| **Total** | **8 semaines** | Application complète + documentation |

---

## 1.6 Critères de réussite

Le projet sera validé si :
1. Toutes les fonctionnalités du cahier des charges sont opérationnelles.
2. Les tests unitaires et d'intégration sont concluants.
3. L'application respecte les contraintes de sécurité (hash passwords, sessions).
4. La documentation est complète et claire.
5. L'interface utilisateur est ergonomique et intuitive.
6. Le code est structuré, commenté et maintenable.









