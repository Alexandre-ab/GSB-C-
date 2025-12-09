# Dossier de Projet BTS SLAM

## Application de Gestion des Prescriptions - GSB WinForms

---

**Candidat** : Boué Alexandre 
**Session** : 2024-2026
**Établissement** : Nexa Digital School
**Formation** : BTS Services Informatiques aux Organisations (SIO)  
**Option** : Solutions Logicielles et Applications Métiers (SLAM)

---

## Table des matières

1. [Contexte et Cahier des Charges](#1-contexte-et-cahier-des-charges)
2. [Conception](#2-conception)
   - 2.1 [Diagrammes UML](conception/02-diagrammes-uml.md)
   - 2.2 [Modèle de données (Merise)](conception/03-modele-donnees.md)
   - 2.3 [Architecture applicative](conception/04-architecture.md)
3. [Réalisation](#3-réalisation)
4. [Tests et Validation](#4-tests-et-validation)
5. [Veille Technologique](#5-veille-technologique)
6. [Annexes](#6-annexes)
7. [Conclusion et Perspectives](#7-conclusion-et-perspectives)

---

## Résumé exécutif

Ce projet consiste à développer une **application de gestion de prescriptions médicales** pour le laboratoire pharmaceutique fictif **GSB (Galaxy Swiss Bourdin)**. L'objectif est de centraliser et sécuriser la gestion des patients, des médicaments et des prescriptions pour les visiteurs médicaux et l'équipe administrative.

**Technologies utilisées** :
- **C# (.NET 8)** : langage de développement
- **Windows Forms** : interface utilisateur desktop
- **MySQL 8.x** : base de données relationnelle
- **ADO.NET** : accès aux données
- **iTextSharp** : génération de documents PDF

**Fonctionnalités principales** :
- Authentification et gestion des utilisateurs (administrateurs, médecins)
- CRUD complet sur les patients, médicaments et prescriptions
- Association médicaments-prescriptions avec posologie et quantité
- Export des ordonnances au format PDF

**Résultats** :
- Application opérationnelle et testée
- Taux de réussite des tests : **78,3%** (36/46 tests passés)
- Architecture modulaire et maintenable (3 tiers : DAO, Métier, UI)
- Conformité aux bonnes pratiques (requêtes paramétrées, séparation des responsabilités)

---

## 1. Contexte et Cahier des Charges

### 1.1 Présentation de l'entreprise et du besoin

**GSB** est un laboratoire pharmaceutique employant des visiteurs médicaux chargés de promouvoir les médicaments auprès des professionnels de santé. L'entreprise rencontrait des difficultés dans la gestion dispersée des données (tableurs, papier), entraînant des risques d'erreurs, de perte de données et un manque de traçabilité.

**Besoin identifié** : développer une application centralisée pour gérer les patients, les médicaments et les prescriptions, avec export PDF et sécurisation des accès.

### 1.2 Objectifs du projet

1. **Centraliser** les données patients, médicaments et prescriptions.
2. **Sécuriser** l'accès via authentification et gestion de rôles.
3. **Simplifier** la création de prescriptions avec associations médicaments.
4. **Tracer** les actions (création, modification) pour audit.
5. **Exporter** les ordonnances au format PDF professionnel.

### 1.3 Contraintes

- **Technique** : application desktop Windows uniquement (WinForms).
- **Délai** : 8 semaines de développement.
- **Équipe** : développeur débutant (projet de formation BTS).
- **Budget** : technologies open-source ou gratuites uniquement.

**➔ Détails complets** : [01-contexte-cahier-charges.md](01-contexte-cahier-charges.md)

---

## 2. Conception

### 2.1 Analyse fonctionnelle (UML)

La phase de conception a permis de modéliser le système avec plusieurs diagrammes UML :

**Diagramme de cas d'utilisation** : identification des acteurs (Admin, Médecin) et des fonctionnalités (authentification, CRUD patients/médicaments/prescriptions, export PDF).

**Diagramme de classes** : modélisation des entités métier (`User`, `Patient`, `Medicine`, `Prescription`, `Appartient`) et de leurs relations (associations, FK).

**Diagrammes de séquence** : flux détaillés pour :
- Authentification (Form1 → UserDAO → Database → UserSession)
- Création de prescription (FormPrescription → PrescriptionDAO + AppartientDAO)
- Export PDF (FormPrescription → PrescriptionDAO → AppartientDAO → ExporterPDF)

**➔ Détails et diagrammes** : [conception/02-diagrammes-uml.md](conception/02-diagrammes-uml.md)

### 2.2 Modèle de données (Merise)

Le modèle de données suit la méthode **Merise** :

**MCD (Modèle Conceptuel de Données)** : 5 entités principales avec cardinalités :
- `USER` (1,n) crée `MEDICINE` (0,n)
- `USER` (1,n) rédige `PRESCRIPTION` (0,n)
- `PATIENT` (1,n) reçoit `PRESCRIPTION` (0,n)
- `MEDICINE` (0,n) APPARTIENT `PRESCRIPTION` (0,n)

**MLD (Modèle Logique de Données)** : traduction en tables relationnelles avec PK, FK, contraintes d'intégrité (CASCADE, RESTRICT, UNIQUE).

**MPD (Modèle Physique de Données)** : script SQL complet avec types MySQL, index, contraintes et données de test (seed).

**➔ Détails et script SQL** : [conception/03-modele-donnees.md](conception/03-modele-donnees.md)

### 2.3 Architecture applicative

Architecture **3-tiers** (couches) :

1. **Couche Présentation (UI)** : Windows Forms (`Form1`, `FormAdmin`, `FormDoctor`, `FormPrescription`, etc.)
2. **Couche Métier (Business Logic)** : modèles POCO (`User`, `Patient`, `Medicine`, `Prescription`, `Appartient`, `UserSession`)
3. **Couche Accès Données (DAL)** : DAO pour chaque entité (`UserDAO`, `PatientsDao`, `MedicineDao`, `PrescriptionDao`, `AppartientDao`, `Database`)

**Avantages** :
- Séparation des responsabilités
- Maintenabilité (modification d'une couche sans impact sur les autres)
- Testabilité (possibilité de mocker les DAO pour tests unitaires)

**➔ Schémas et détails** : [conception/04-architecture.md](conception/04-architecture.md)

---

## 3. Réalisation

### 3.1 Choix techniques et justifications

| Décision | Technologie retenue | Justification |
|----------|---------------------|---------------|
| **Langage** | C# (.NET 8) | Orienté objet, robuste, adapté Windows |
| **UI** | Windows Forms | Rapidité développement, designer visuel, mature |
| **BD** | MySQL 8.x | Open-source, robuste, performant |
| **Accès données** | ADO.NET (MySql.Data) | Contrôle total SQL, léger, adapté au projet |
| **PDF** | iTextSharp 5.x | Mature, documentation abondante |

**Comparaison ADO.NET vs Entity Framework** : ADO.NET retenu pour le contrôle des requêtes et la simplicité (schéma simple, équipe débutante).

**Comparaison WinForms vs WPF/Blazor** : WinForms retenu pour la rapidité de développement et l'absence de besoin de design complexe.

**➔ Détails et alternatives évaluées** : [realisation/05-realisation-technique.md](realisation/05-realisation-technique.md)

### 3.2 Implémentation des fonctionnalités clés

**Authentification** :
- Requêtes paramétrées pour prévenir l'injection SQL
- Hash SHA-256 côté MySQL (amélioration recommandée : bcrypt côté C#)
- Gestion de session avec classe statique `UserSession`

**Gestion des prescriptions** :
- Création de `Prescription` avec insertion des médicaments dans `Appartient`
- Recommandation : utiliser une **transaction** pour garantir l'atomicité (si échec, rollback)

**Export PDF** :
- Génération document A4 avec iTextSharp
- En-tête (titre, date), infos patient, tableau médicaments (nom, dosage, quantité, posologie), notes, signature prescripteur

**Validation des données** :
- Côté UI : vérification champs obligatoires, format téléphone (regex)
- Messages d'erreur conviviaux (MessageBox)

### 3.3 Difficultés rencontrées et solutions

| Problème | Solution |
|----------|----------|
| Suppression patient avec prescriptions (erreur FK) | Ajout `ON DELETE CASCADE` sur FK `Prescription.id_patient` |
| Hash SHA-256 sans sel (vulnérable) | Recommandation : migration vers bcrypt (V2) |
| Requêtes N+1 (performance) | JOIN dans SQL pour récupérer tout en une fois |

**➔ Extraits de code commentés** : [realisation/05-realisation-technique.md](realisation/05-realisation-technique.md)

---

## 4. Tests et Validation

### 4.1 Stratégie de test

Tests organisés en 5 catégories :
1. **Fonctionnels** : validation des fonctionnalités métier (authentification, CRUD, export)
2. **Sécurité** : injection SQL, authentification, hash passwords
3. **Performance** : temps de réponse, charge
4. **Utilisabilité** : ergonomie, feedback utilisateur
5. **Intégration** : interaction entre couches (UI → DAO → BD)

### 4.2 Résultats des tests

| Catégorie | Tests passés | Tests partiels | Tests échoués | Total | Taux |
|-----------|--------------|----------------|---------------|-------|------|
| Authentification | 6 | 0 | 0 | 6 | 100% |
| Patients | 7 | 1 | 0 | 8 | 87.5% |
| Médicaments | 5 | 1 | 0 | 6 | 83.3% |
| Prescriptions | 5 | 2 | 0 | 7 | 71.4% |
| Export PDF | 3 | 2 | 0 | 5 | 60% |
| Sécurité | 5 | 3 | 1 | 9 | 55.6% |
| Performance | 5 | 0 | 0 | 5 | 100% |
| **Total** | **36** | **9** | **1** | **46** | **78.3%** |

### 4.3 Points forts et axes d'amélioration

**Points forts** ✅ :
- Fonctionnalités CRUD complètes et stables
- Protection contre l'injection SQL (requêtes paramétrées)
- Performances satisfaisantes (< 2s pour toutes les opérations)
- Interface intuitive

**Axes d'amélioration** ⚠️ :
- Migrer vers bcrypt pour le hash des mots de passe
- Implémenter limitation tentatives de connexion (anti-brute-force)
- Améliorer validation (format téléphone, dates futures)
- Ajouter tests unitaires automatisés (xUnit)
- Implémenter logging (Serilog) pour tracer les erreurs

**➔ Plan de tests détaillé** : [tests/06-plan-de-tests.md](tests/06-plan-de-tests.md)

---

## 5. Veille Technologique

### 5.1 Démarche de veille

Sources consultées régulièrement :
- **Microsoft Learn** : documentation officielle .NET/C#
- **Stack Overflow** : résolution de problèmes
- **GitHub** : exemples de code, bibliothèques
- **OWASP** : recommandations sécurité
- **YouTube** (Nick Chapsas, IAmTimCorey) : tutoriels C#

### 5.2 Comparaisons et choix techniques

**ADO.NET vs Entity Framework** : ADO.NET retenu pour le contrôle total des requêtes et la simplicité du schéma.

**SHA-256 vs bcrypt vs argon2** : bcrypt recommandé pour le hash des mots de passe (sel intégré, résistant brute-force).

**iTextSharp vs QuestPDF vs PdfSharp** : iTextSharp retenu pour la maturité, mais QuestPDF recommandé en V2 (API moderne, licence MIT).

**WinForms vs WPF vs Blazor Desktop** : WinForms retenu pour la rapidité de développement et l'absence de besoin multiplateformes.

### 5.3 Conformité OWASP Top 10 2021

| Vulnérabilité | Statut GSB | Mesures |
|---------------|------------|---------|
| A01 : Contrôle d'accès | ⚠️ Partiel | Session + rôles (à renforcer) |
| A02 : Cryptographie | ⚠️ Partiel | SHA-256 → migrer bcrypt |
| A03 : Injection | ✅ Protégé | Requêtes paramétrées partout |
| A07 : Authentification | ⚠️ Partiel | Pas de MFA, pas de limite tentatives |
| A09 : Logging | ❌ Absent | À implémenter (Serilog) |

**➔ Détails et recommandations** : [veille/07-veille-technologique.md](veille/07-veille-technologique.md)

---

## 6. Annexes

### 6.1 Script SQL complet

Script d'initialisation de la base de données avec :
- Création des 5 tables (Users, Patients, Medicine, Prescription, Appartient)
- Contraintes d'intégrité (PK, FK, UNIQUE, NOT NULL, INDEX)
- Données de test (3 users, 5 patients, 5 médicaments, 3 prescriptions)

**➔ Script complet** : [annexes/08-annexes.md#81-script-sql-complet](annexes/08-annexes.md)

### 6.2 Extraits de code significatifs

- **Authentification** : `UserDAO.Login()` avec requêtes paramétrées
- **Formulaire de connexion** : `Form1.button1_Click()` avec gestion des rôles
- **Gestion de session** : `UserSession` (Login/Logout)
- **Export PDF** : `ExporterPDF.ExporterPrescription()` avec iTextSharp

**➔ Code complet commenté** : [annexes/08-annexes.md#82-extraits-de-code-significatifs](annexes/08-annexes.md)

### 6.3 Arborescence du projet

Structure complète du projet avec tous les fichiers (DAO, Models, Forms, Utils, docs).

**➔ Arborescence détaillée** : [annexes/08-annexes.md#83-structure-du-projet](annexes/08-annexes.md)

---

## 7. Conclusion et Perspectives

### 7.1 Bilan du projet

**Objectifs atteints** ✅ :
- Application fonctionnelle répondant au cahier des charges
- Architecture claire et maintenable (3 tiers)
- Fonctionnalités CRUD complètes (users, patients, médicaments, prescriptions)
- Export PDF opérationnel
- Sécurité de base (requêtes paramétrées, sessions)

**Compétences acquises** 🎓 :
- Développement C# / .NET 8 / Windows Forms
- Conception (UML, Merise)
- Accès données avec ADO.NET (MySql.Data)
- Gestion de projet (analyse → conception → réalisation → tests)
- Veille technologique (comparaison de solutions, OWASP)

### 7.2 Limites de la version actuelle

- **Sécurité** : hash SHA-256 sans sel (à migrer vers bcrypt)
- **Tests** : absence de tests unitaires automatisés
- **Logging** : aucune journalisation des actions/erreurs
- **Validations** : certaines validations côté UI à renforcer
- **Architecture** : couplage fort (DAO instancient directement `Database`, pas d'injection de dépendances)

### 7.3 Perspectives d'évolution (V2/V3)

**Version 2.0** (améliorations prioritaires) :
1. **Sécurité** :
   - Migration vers bcrypt (package `BCrypt.Net-Next`)
   - Limitation tentatives de connexion (anti-brute-force)
   - Externalisation credentials (variables d'environnement)
2. **Qualité** :
   - Tests unitaires avec xUnit + Moq
   - Logging avec Serilog
   - Injection de dépendances (interface `IDatabase`)
3. **Fonctionnalités** :
   - Historique des modifications (audit trail)
   - Confirmation avant suppression
   - Autocomplétion recherche (patients, médicaments)

**Version 3.0** (évolutions majeures) :
1. **Architecture** :
   - Migration vers API REST (ASP.NET Core) + client desktop
   - Séparation backend/frontend pour multi-clients
2. **Interface** :
   - Migration vers Blazor Hybrid (multiplateformes : Windows/Mac/Linux)
   - UI moderne avec design system
3. **Fonctionnalités avancées** :
   - Détection interactions médicamenteuses (IA)
   - Gestion des stocks de médicaments
   - Notifications automatiques (renouvellement prescriptions)
   - Multi-établissements

### 7.4 Retour d'expérience personnel

Ce projet m'a permis de mettre en pratique l'ensemble des connaissances acquises en BTS SLAM :
- **Analyse et conception** : UML, Merise
- **Développement** : C#, .NET, Windows Forms, ADO.NET
- **Base de données** : MySQL, requêtes SQL, contraintes d'intégrité
- **Tests** : plan de tests, validation fonctionnelle
- **Veille** : comparaison de solutions, veille sécurité (OWASP)

Les principales difficultés rencontrées ont été :
- La gestion des contraintes FK (CASCADE vs RESTRICT)
- La sécurisation des mots de passe (découverte de bcrypt)
- L'architecture (choix ADO.NET vs Entity Framework)

Ces difficultés m'ont permis d'approfondir mes connaissances et de comprendre l'importance de la veille technologique et des bonnes pratiques de sécurité.

---

## Remerciements

Je tiens à remercier :
- **[Nom tuteur]**, mon tuteur de stage, pour son accompagnement et ses conseils
- **[Nom enseignant]**, mon enseignant de SLAM, pour son soutien technique
- La **communauté Stack Overflow** pour l'aide à la résolution de problèmes
- **Microsoft** et **MySQL** pour leurs documentations complètes

---

**Candidat** : Alexandre Boué 
**Date de soutenance** : 2026
**Établissement** : Nexa Digital School
**Session** : 2024-2026


