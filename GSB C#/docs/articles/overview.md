# Présentation et architecture

Cette application WinForms cible `.NET 8` et s’appuie sur MySQL pour la persistance. Le code suit une séparation claire entre couche d’accès aux données, modèles métier et formulaires d’interface.

## Couche DAO
- `Dao/Database.cs` : fournit les connexions MySQL.
- `Dao/MedicineDao.cs`, `PatientsDao.cs`, `PrescriptionDao.cs`, `UserDAO.cs`, `AppartientDao.cs` : CRUD et requêtes spécialisées sur les tables correspondantes.

## Modèles métier
- `Models` contient les entités `Medicine`, `Patients`, `Prescription`, `Appartient`, `User` et la session `UserSession`.

## Interface WinForms
- Les formulaires dans `Forms` couvrent l’administration (`FormAdmin`, `FormModifyAdmin`), la gestion des patients et médecins (`FormDoctor`, `FormAddpatient`, `FormDetailMedicine`, `FormPrescription`), ainsi que la création d’utilisateurs (`FormAddUser`).

## Utilitaires
- `Utils/ExporterPDF.cs` : génération d’export PDF (iTextSharp).

## Générer la documentation (DocFX)
1) Installer DocFX : `dotnet tool install -g docfx` (ou `choco install docfx` sur Windows).
2) Depuis le dossier `docs`, générer les métadonnées : `docfx metadata`.
3) Construire le site statique : `docfx build -o _site`.
4) Ouvrir `_site/index.html` dans un navigateur ou publier le dossier `_site` sur GitHub Pages/Azure Static Web Apps.

La page « Référence API » regroupe automatiquement les espaces de noms et classes détectés dans le projet, pour reproduire l’expérience de navigation de l’exemple gsbMonolith DAO.

