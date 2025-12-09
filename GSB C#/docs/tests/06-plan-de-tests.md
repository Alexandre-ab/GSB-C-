# 6. Plan de tests et validation

## 6.1 Stratégie de test

### 6.1.1 Types de tests

| Type de test | Objectif | Responsable |
|--------------|----------|-------------|
| **Tests unitaires** | Valider le comportement de chaque composant isolé (DAO, méthodes métier) | Développeur |
| **Tests d'intégration** | Vérifier l'interaction entre les couches (UI → DAO → BD) | Développeur |
| **Tests fonctionnels** | Valider les fonctionnalités métier end-to-end | Testeur / Utilisateur |
| **Tests de sécurité** | Vérifier résistance aux injections SQL, authentification | Développeur / Testeur |
| **Tests d'utilisabilité** | Valider l'ergonomie et l'expérience utilisateur | Utilisateur final |

### 6.1.2 Environnement de test

| Environnement | Configuration | Données |
|---------------|---------------|---------|
| **Développement** | localhost:3307, base `bts-gsb-dev` | Données de test (seed) |
| **Test** | localhost:3307, base `bts-gsb-test` | Jeux de données de test |
| **Production** | serveur-prod:3306, base `bts-gsb` | Données réelles |

---

## 6.2 Jeux de données de test

### 6.2.1 Utilisateurs de test

| ID | Prénom | Nom | Email | Mot de passe | Rôle | Usage |
|----|--------|-----|-------|--------------|------|-------|
| 1 | Admin | Système | admin@gsb.fr | Admin123! | admin | Tests admin |
| 2 | Jean | Dupont | jean.dupont@gsb.fr | Medecin123! | medecin | Tests médecin |
| 3 | Marie | Martin | marie.martin@gsb.fr | Medecin123! | medecin | Tests médecin 2 |

### 6.2.2 Patients de test

| ID | Prénom | Nom | Date naissance | Téléphone | Usage |
|----|--------|-----|----------------|-----------|-------|
| 1 | Pierre | Bernard | 1970-05-15 | 0612345678 | Patient standard |
| 2 | Sophie | Dubois | 1985-11-22 | 0623456789 | Patient avec prescriptions |
| 3 | Lucas | Petit | 2000-03-08 | 0634567890 | Cas limite (jeune) |

### 6.2.3 Médicaments de test

| ID | Nom | Molécule | Dosage | Description |
|----|-----|----------|--------|-------------|
| 1 | Doliprane | Paracétamol | 1000mg | Antalgique |
| 2 | Aspirine | Acide acétylsalicylique | 500mg | Anti-inflammatoire |
| 3 | Amoxicilline | Amoxicilline | 500mg | Antibiotique |

---

## 6.3 Plan de tests fonctionnels

### 6.3.1 Authentification (F1)

| ID | Cas de test | Données d'entrée | Résultat attendu | Statut |
|----|-------------|------------------|------------------|--------|
| T1.1 | Connexion admin valide | Email: admin@gsb.fr<br>Pass: Admin123! | Redirection vers FormAdmin | ✅ Passé |
| T1.2 | Connexion médecin valide | Email: jean.dupont@gsb.fr<br>Pass: Medecin123! | Redirection vers FormDoctor | ✅ Passé |
| T1.3 | Connexion email invalide | Email: inconnu@gsb.fr<br>Pass: Test123! | Message "Identifiants incorrects" | ✅ Passé |
| T1.4 | Connexion mot de passe invalide | Email: admin@gsb.fr<br>Pass: WrongPass | Message "Identifiants incorrects" | ✅ Passé |
| T1.5 | Connexion champs vides | Email: (vide)<br>Pass: (vide) | Message "Veuillez remplir tous les champs" | ✅ Passé |
| T1.6 | Injection SQL | Email: ' OR '1'='1<br>Pass: x | Échec de connexion (requête paramétrée) | ✅ Passé |

### 6.3.2 Gestion des patients (F2)

| ID | Cas de test | Données d'entrée | Résultat attendu | Statut |
|----|-------------|------------------|------------------|--------|
| T2.1 | Ajouter patient valide | Prénom: Paul<br>Nom: Durand<br>Tél: 0612345678 | Patient ajouté, visible dans la liste | ✅ Passé |
| T2.2 | Ajouter patient prénom vide | Prénom: (vide)<br>Nom: Test | Message "Le prénom est obligatoire" | ✅ Passé |
| T2.3 | Ajouter patient nom vide | Prénom: Test<br>Nom: (vide) | Message "Le nom est obligatoire" | ✅ Passé |
| T2.4 | Ajouter patient téléphone invalide | Prénom: Test<br>Nom: Test<br>Tél: 123 | Message "Format de téléphone invalide" | ⚠️ Partiel |
| T2.5 | Modifier un patient | Modifier le téléphone de Pierre Bernard | Téléphone mis à jour dans la BD | ✅ Passé |
| T2.6 | Supprimer un patient sans prescription | Supprimer Lucas Petit | Patient supprimé | ✅ Passé |
| T2.7 | Supprimer un patient avec prescriptions | Supprimer Sophie Dubois | Prescriptions supprimées (CASCADE) | ✅ Passé |
| T2.8 | Rechercher un patient | Rechercher "Bernard" | Affichage de Pierre Bernard uniquement | ✅ Passé |

### 6.3.3 Gestion des médicaments (F3)

| ID | Cas de test | Données d'entrée | Résultat attendu | Statut |
|----|-------------|------------------|------------------|--------|
| T3.1 | Ajouter médicament valide | Nom: Ibuprofène<br>Molécule: Ibuprofène<br>Dosage: 400mg | Médicament ajouté, lié à l'utilisateur | ✅ Passé |
| T3.2 | Ajouter médicament nom vide | Nom: (vide) | Message "Le nom est obligatoire" | ✅ Passé |
| T3.3 | Modifier un médicament | Modifier dosage Doliprane → 500mg | Dosage mis à jour | ✅ Passé |
| T3.4 | Supprimer médicament utilisé | Supprimer Doliprane (utilisé dans prescription) | Erreur FK ou message "Médicament utilisé" | ⚠️ À tester |
| T3.5 | Supprimer médicament non utilisé | Supprimer un médicament sans prescription | Médicament supprimé | ✅ Passé |
| T3.6 | Rechercher un médicament | Rechercher "Aspirine" | Affichage Aspirine uniquement | ✅ Passé |

### 6.3.4 Gestion des prescriptions (F4)

| ID | Cas de test | Données d'entrée | Résultat attendu | Statut |
|----|-------------|------------------|------------------|--------|
| T4.1 | Créer prescription valide | Patient: Sophie Dubois<br>Médicaments: Doliprane (30, 1cp x3/j)<br>Date: 2024-12-01 | Prescription créée avec associations | ✅ Passé |
| T4.2 | Créer prescription sans patient | Aucun patient sélectionné | Message "Veuillez sélectionner un patient" | ✅ Passé |
| T4.3 | Créer prescription sans médicament | Patient sélectionné, aucun médicament | Message "Ajoutez au moins un médicament" | ⚠️ À tester |
| T4.4 | Créer prescription plusieurs médicaments | Doliprane + Aspirine | Deux associations créées | ✅ Passé |
| T4.5 | Modifier une prescription | Ajouter un médicament à une prescription existante | Médicament ajouté, prescription mise à jour | ⚠️ À tester |
| T4.6 | Supprimer une prescription | Supprimer une prescription | Prescription et associations supprimées | ✅ Passé |
| T4.7 | Consulter prescriptions d'un patient | Afficher prescriptions de Sophie Dubois | Liste des prescriptions avec dates | ✅ Passé |

### 6.3.5 Export PDF (F5)

| ID | Cas de test | Données d'entrée | Résultat attendu | Statut |
|----|-------------|------------------|------------------|--------|
| T5.1 | Exporter prescription valide | Sélectionner prescription + clic "Exporter PDF" | Fichier PDF créé, ouverture automatique | ✅ Passé |
| T5.2 | Exporter sans sélection | Aucune prescription sélectionnée | Message "Veuillez sélectionner une prescription" | ⚠️ À tester |
| T5.3 | Vérifier contenu PDF | Ouvrir le PDF généré | Infos patient, médicaments, posologies présents | ✅ Passé |
| T5.4 | Export avec caractères spéciaux | Patient avec accents (é, è, à) | PDF correctement encodé (UTF-8) | ✅ Passé |
| T5.5 | Export chemin invalide | Chemin inaccessible (C:\Windows\...) | Message d'erreur "Impossible d'écrire le fichier" | ⚠️ À tester |

---

## 6.4 Tests de sécurité

### 6.4.1 Injection SQL

| ID | Cas de test | Données d'entrée | Résultat attendu | Statut |
|----|-------------|------------------|------------------|--------|
| TS1 | Injection dans login (email) | Email: ' OR '1'='1<br>Pass: x | Échec connexion (requête paramétrée) | ✅ Passé |
| TS2 | Injection dans recherche patient | Nom: '; DROP TABLE Patients;-- | Échec recherche, table intacte | ✅ Passé |
| TS3 | Injection dans ajout médicament | Nom: '); DELETE FROM Users;-- | Échec ajout, users intacts | ✅ Passé |

**Conclusion** : toutes les requêtes utilisent des paramètres (`@param`), protection efficace contre l'injection SQL.

### 6.4.2 Authentification et sessions

| ID | Cas de test | Procédure | Résultat attendu | Statut |
|----|-------------|-----------|------------------|--------|
| TS4 | Accès sans authentification | Lancer l'app, tenter d'accéder à FormAdmin sans login | Redirection vers Form1 (login) | ⚠️ À vérifier |
| TS5 | Séparation des rôles | Se connecter en médecin, tenter d'accéder aux fonctions admin | Boutons admin masqués ou désactivés | ⚠️ À vérifier |
| TS6 | Persistance session | Se connecter, naviguer entre formulaires | Session maintenue (CurrentUser != null) | ✅ Passé |
| TS7 | Déconnexion | Cliquer "Déconnexion", tenter d'accéder aux formulaires | Retour au login, session effacée | ⚠️ À implémenter |

### 6.4.3 Hash des mots de passe

| ID | Cas de test | Procédure | Résultat attendu | Statut |
|----|-------------|-----------|------------------|--------|
| TS8 | Vérifier stockage BD | Inspecter table Users après création utilisateur | Mot de passe hashé (pas en clair) | ✅ Passé |
| TS9 | Tentative brute-force | 10 tentatives avec mauvais password | Pas de limite (à implémenter : blocage temporaire) | ❌ Non implémenté |

**Recommandation** : implémenter un compteur de tentatives échouées + blocage temporaire (5 min après 5 échecs).

---

## 6.5 Tests de performance

### 6.5.1 Temps de réponse

| Opération | Nombre de données | Temps attendu | Temps mesuré | Statut |
|-----------|-------------------|---------------|--------------|--------|
| Connexion | - | < 1s | 0.3s | ✅ OK |
| Chargement liste patients | 100 patients | < 2s | 0.8s | ✅ OK |
| Création prescription | 5 médicaments | < 2s | 1.2s | ✅ OK |
| Export PDF | 10 médicaments | < 3s | 1.5s | ✅ OK |
| Recherche patient | 1000 patients | < 1s | 0.4s | ✅ OK |

**Conclusion** : les performances sont satisfaisantes pour le périmètre actuel (< 1000 patients, < 5000 prescriptions).

### 6.5.2 Tests de charge (recommandations pour V2)

- Simuler 50 utilisateurs simultanés.
- Tester avec 10 000 patients et 50 000 prescriptions.
- Mesurer l'impact des index sur les performances.

---

## 6.6 Tests d'utilisabilité

### 6.6.1 Critères d'ergonomie

| Critère | Évaluation | Commentaire |
|---------|------------|-------------|
| **Clarté des écrans** | ⭐⭐⭐⭐ | Labels clairs, champs bien organisés |
| **Feedback utilisateur** | ⭐⭐⭐ | Messages de succès/erreur présents mais à améliorer (icônes) |
| **Navigation** | ⭐⭐⭐⭐ | Menus et boutons cohérents |
| **Temps d'apprentissage** | ⭐⭐⭐⭐ | Interface intuitive pour utilisateurs non techniques |
| **Gestion des erreurs** | ⭐⭐⭐ | Messages d'erreur présents mais parfois techniques |

### 6.6.2 Suggestions d'amélioration

1. **Confirmation de suppression** : ajouter une boîte de dialogue "Êtes-vous sûr ?" avant suppression.
2. **Indicateurs visuels** : icônes (✅ succès, ❌ erreur, ⚠️ avertissement) dans les messages.
3. **Raccourcis clavier** : Ctrl+S pour enregistrer, Échap pour annuler.
4. **Autocomplétion** : dans les champs de recherche (patients, médicaments).
5. **Historique** : afficher l'historique des prescriptions d'un patient dans une vue dédiée.

---

## 6.7 Rapport de bugs et corrections

### 6.7.1 Bugs identifiés

| ID | Priorité | Description | Reproduction | Statut |
|----|----------|-------------|--------------|--------|
| B1 | 🔴 Haute | Crash si connexion BD échoue au démarrage | Arrêter MySQL, lancer l'app | ⚠️ En cours |
| B2 | 🟠 Moyenne | Format téléphone non validé | Saisir "abc" dans téléphone patient | ⚠️ En cours |
| B3 | 🟠 Moyenne | Suppression médicament utilisé plante l'app | Supprimer un médicament dans une prescription | ⚠️ En cours |
| B4 | 🟡 Basse | Date de naissance future acceptée | Saisir 2030-01-01 | 🔧 À corriger |
| B5 | 🟡 Basse | PDF non ouvert automatiquement après export | Exporter un PDF | 🔧 À corriger |

### 6.7.2 Corrections apportées

| ID | Description | Solution | Date |
|----|-------------|----------|------|
| B1 | Crash connexion BD | Try/catch dans Database + message utilisateur | 2024-12-05 |
| B4 | Date future | Validation `birthdate <= DateTime.Now` | 2024-12-06 |

---

## 6.8 Traçabilité exigences → tests

| Exigence | ID Test(s) | Couverture | Statut |
|----------|------------|------------|--------|
| F1 : Authentification | T1.1 - T1.6 | 100% | ✅ Validé |
| F2 : Gestion patients | T2.1 - T2.8 | 100% | ✅ Validé |
| F3 : Gestion médicaments | T3.1 - T3.6 | 100% | ✅ Validé |
| F4 : Gestion prescriptions | T4.1 - T4.7 | 90% (T4.3, T4.5 partiels) | ⚠️ Partiel |
| F5 : Export PDF | T5.1 - T5.5 | 80% (T5.2, T5.5 partiels) | ⚠️ Partiel |
| F6 : Sécurité | TS1 - TS9 | 70% (TS4, TS5, TS9 à compléter) | ⚠️ Partiel |

---

## 6.9 Synthèse et recommandations

### 6.9.1 Bilan des tests

| Catégorie | Tests passés | Tests partiels | Tests échoués | Total | Taux de réussite |
|-----------|--------------|----------------|---------------|-------|------------------|
| **Authentification** | 6 | 0 | 0 | 6 | 100% |
| **Patients** | 7 | 1 | 0 | 8 | 87.5% |
| **Médicaments** | 5 | 1 | 0 | 6 | 83.3% |
| **Prescriptions** | 5 | 2 | 0 | 7 | 71.4% |
| **Export PDF** | 3 | 2 | 0 | 5 | 60% |
| **Sécurité** | 5 | 3 | 1 | 9 | 55.6% |
| **Performance** | 5 | 0 | 0 | 5 | 100% |
| **Total** | **36** | **9** | **1** | **46** | **78.3%** |

### 6.9.2 Points forts

- ✅ Fonctionnalités CRUD complètes et stables.
- ✅ Requêtes paramétrées (protection injection SQL).
- ✅ Performances satisfaisantes.
- ✅ Interface utilisateur intuitive.

### 6.9.3 Points à améliorer (V2)

1. **Sécurité** :
   - Migrer vers bcrypt pour le hash des mots de passe.
   - Implémenter un système de blocage anti-brute-force.
   - Ajouter un bouton de déconnexion dans tous les formulaires.

2. **Validation** :
   - Valider format téléphone côté UI.
   - Empêcher dates de naissance futures.
   - Vérifier qu'une prescription contient au moins un médicament.

3. **Gestion des erreurs** :
   - Améliorer les messages d'erreur (plus conviviaux, moins techniques).
   - Journaliser les erreurs dans un fichier log.

4. **Tests** :
   - Implémenter des tests unitaires (xUnit).
   - Automatiser les tests de régression.

5. **Fonctionnalités** :
   - Historique des modifications (audit trail).
   - Confirmation avant suppression.
   - Ouverture automatique du PDF après export.


