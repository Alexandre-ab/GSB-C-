# 7. Veille technologique

## 7.1 Méthodologie de veille

Dans le cadre du projet GSB, une veille technologique a été menée pour :
- Identifier les meilleures pratiques du développement C# / .NET.
- Comparer les solutions techniques disponibles.
- Anticiper les évolutions futures.
- Garantir la sécurité et la performance de l'application.

### Sources de veille

| Source | Type | Fréquence | Usage |
|--------|------|-----------|-------|
| **Microsoft Learn** | Documentation officielle | Quotidienne | Référence .NET/C# |
| **Stack Overflow** | Forum Q&A | Hebdomadaire | Résolution de problèmes |
| **GitHub** | Dépôts open-source | Hebdomadaire | Exemples de code, bibliothèques |
| **Dev.to / Medium** | Articles techniques | Hebdomadaire | Bonnes pratiques, retours d'expérience |
| **OWASP** | Sécurité applicative | Mensuelle | Recommandations sécurité |
| **YouTube (Nick Chapsas, IAmTimCorey)** | Vidéos tutoriels | Hebdomadaire | Nouveautés C#, patterns |

---

## 7.2 Comparaison des technologies : ADO.NET vs Entity Framework

### 7.2.1 Contexte

Pour l'accès aux données, deux approches principales existent en .NET :
- **ADO.NET** : accès direct avec SQL manuel.
- **Entity Framework Core** : ORM (Object-Relational Mapping).

### 7.2.2 Tableau comparatif

| Critère | ADO.NET | Entity Framework Core |
|---------|---------|----------------------|
| **Contrôle SQL** | ✅ Total (requêtes manuelles) | ⚠️ Limité (LINQ → SQL) |
| **Performance** | ✅ Optimale (requêtes ajustées) | ⚠️ Overhead possible |
| **Productivité** | ⚠️ Code répétitif | ✅ Rapide (scaffolding, migrations) |
| **Maintenance** | ⚠️ SQL dispersé dans le code | ✅ Centralisé (modèles) |
| **Courbe d'apprentissage** | ✅ Simple (SQL standard) | ⚠️ Moyenne (LINQ, conventions) |
| **Migrations de schéma** | ❌ Manuelles | ✅ Automatiques (migrations) |
| **Adapté au projet GSB** | ✅ Oui (schéma simple, besoin de contrôle) | ⚠️ Overkill pour ce périmètre |

### 7.2.3 Décision retenue

**Choix : ADO.NET**

**Justification** :
- Schéma de base simple (5 tables).
- Besoin de contrôle total sur les requêtes (optimisation).
- Équipe débutante : SQL plus accessible que LINQ.
- Pas besoin de migrations complexes.

**Pour une V2 ou un projet plus complexe** : Entity Framework Core serait pertinent (nombreuses tables, relations complexes, équipe expérimentée).

---

## 7.3 Sécurité : Hash des mots de passe

### 7.3.1 Problématique

Le stockage des mots de passe en clair est une faille majeure. Les alternatives :

| Méthode | Sécurité | Réversible | Performance | Recommandé |
|---------|----------|------------|-------------|------------|
| **Clair** | ❌ Aucune | ✅ Oui | ✅ Instantané | ❌ Jamais |
| **MD5** | ❌ Faible (rainbow tables) | ❌ Non | ✅ Rapide | ❌ Obsolète |
| **SHA-256** | ⚠️ Moyenne (sans sel) | ❌ Non | ✅ Rapide | ⚠️ Acceptable avec sel |
| **bcrypt** | ✅ Élevée (sel intégré) | ❌ Non | ⚠️ Lent (intentionnellement) | ✅ Recommandé |
| **argon2** | ✅ Très élevée (plus récent) | ❌ Non | ⚠️ Lent | ✅ Idéal (V2) |

### 7.3.2 Implémentation actuelle (GSB)

**État actuel** : SHA-256 côté MySQL (sans sel).

```sql
-- Requête actuelle
SELECT * FROM Users 
WHERE email = @email AND password = SHA2(@password, 256);
```

**Limitations** :
- Pas de sel unique par utilisateur.
- Vulnérable aux rainbow tables.

### 7.3.3 Recommandation : migration vers bcrypt

**Bibliothèque** : `BCrypt.Net-Next` (NuGet)

```bash
dotnet add package BCrypt.Net-Next
```

**Exemple d'implémentation** :

```csharp
using BCrypt.Net;

// Lors de l'enregistrement
public bool Register(User user)
{
    string hashedPassword = BCrypt.HashPassword(user.Password);
    // Stocker hashedPassword dans la BD
}

// Lors de l'authentification
public User Login(string email, string password)
{
    // 1. Récupérer l'utilisateur par email
    string storedHash = GetPasswordHashFromDB(email);
    
    // 2. Vérifier avec bcrypt
    if (BCrypt.Verify(password, storedHash))
    {
        return GetUserByEmail(email);
    }
    return null;
}
```

**Avantages** :
- Sel automatique et unique par mot de passe.
- Résistant aux attaques par force brute (calcul lent).
- Standard de l'industrie.

---

## 7.4 Architecture : WinForms vs WPF vs Blazor

### 7.4.1 Contexte

Pour développer une application desktop Windows, trois frameworks majeurs :

| Framework | Année de sortie | État | Cas d'usage |
|-----------|-----------------|------|-------------|
| **Windows Forms** | 2002 | Mature, maintenance | Apps de gestion simples |
| **WPF** | 2006 | Mature, évolutions | Apps desktop complexes, UI moderne |
| **Blazor Desktop** | 2021 | Récent, en développement | Apps multiplateformes (web + desktop) |

### 7.4.2 Comparaison détaillée

| Critère | WinForms | WPF | Blazor Desktop |
|---------|----------|-----|----------------|
| **Complexité** | ⭐ Faible | ⭐⭐⭐ Moyenne | ⭐⭐⭐ Moyenne |
| **Designer visuel** | ✅ Excellent | ✅ Bon | ❌ Limité |
| **Styling/Thèmes** | ⚠️ Basique | ✅ Avancé (XAML) | ✅ Avancé (CSS) |
| **Data binding** | ⚠️ Manuel | ✅ Puissant (MVVM) | ✅ Puissant (Razor) |
| **Performance** | ✅ Excellente | ✅ Excellente | ⚠️ Moyenne |
| **Multiplateformes** | ❌ Windows uniquement | ❌ Windows uniquement | ✅ Windows/Mac/Linux |
| **Écosystème** | ✅ Très mature | ✅ Mature | ⚠️ En croissance |

### 7.4.3 Décision retenue

**Choix : Windows Forms**

**Justification** :
- Contrainte projet : application Windows desktop uniquement.
- Besoin d'un développement rapide avec designer visuel.
- Interface simple (formulaires de gestion), pas de design complexe.
- Équipe débutante : WinForms plus accessible que WPF/XAML.

**Pour une V2** : si besoin d'une UI moderne ou multiplateformes → envisager WPF (Windows) ou Blazor Hybrid (multiplateforme).

---

## 7.5 Génération de PDF : iTextSharp vs QuestPDF vs PdfSharp

### 7.5.1 Contexte

Besoin : générer des ordonnances au format PDF.

| Bibliothèque | Licence | État | Popularité (GitHub) |
|--------------|---------|------|---------------------|
| **iTextSharp** | AGPL (gratuit) / Commercial | Mature (abandonné en 5.x) | ⭐⭐⭐⭐ 10k+ stars |
| **iText 7/8** | AGPL / Commercial | Actif | ⭐⭐⭐⭐⭐ (continuation de iTextSharp) |
| **QuestPDF** | MIT (gratuit) | Très actif | ⭐⭐⭐⭐⭐ 11k+ stars |
| **PdfSharp** | MIT (gratuit) | Actif | ⭐⭐⭐ 1k+ stars |

### 7.5.2 Comparaison

| Critère | iTextSharp 5.x | iText 7/8 | QuestPDF | PdfSharp |
|---------|----------------|-----------|----------|----------|
| **Facilité d'usage** | ⚠️ API verbeux | ⚠️ API verbeux | ✅ API fluent | ⭐⭐ Simple |
| **Documentation** | ✅ Bonne | ✅ Excellente | ✅ Excellente | ⚠️ Moyenne |
| **Performance** | ✅ Bonne | ✅ Excellente | ✅ Bonne | ⭐⭐ Moyenne |
| **Licence** | ⚠️ AGPL (attention) | ⚠️ AGPL / Payant | ✅ MIT (libre) | ✅ MIT (libre) |
| **Maintenance** | ❌ Arrêté | ✅ Actif | ✅ Très actif | ✅ Actif |

### 7.5.3 Décision retenue

**Choix : iTextSharp 5.5.13** (version actuelle du projet)

**Justification** :
- Bibliothèque mature et éprouvée.
- Documentation et exemples abondants.
- Suffit pour les besoins simples du projet (ordonnances).

**Limitations** :
- Version 5.x n'est plus maintenue (dernier commit : 2017).
- Licence AGPL : attention si distribution commerciale (nécessite publication du code source).

**Recommandation V2** : migrer vers **QuestPDF** (MIT, API moderne, actif).

**Exemple QuestPDF** (pour comparaison) :

```csharp
using QuestPDF.Fluent;
using QuestPDF.Helpers;

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Header().Text("ORDONNANCE GSB").FontSize(24).Bold();
        page.Content().Column(column =>
        {
            column.Item().Text($"Patient : {patient.Firstname} {patient.Lastname}");
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(1);
                });
                table.Header(header =>
                {
                    header.Cell().Text("Médicament");
                    header.Cell().Text("Dosage");
                    header.Cell().Text("Quantité");
                });
                foreach (var med in medicaments)
                {
                    table.Cell().Text(med.Name);
                    table.Cell().Text(med.Dosage);
                    table.Cell().Text(med.Quantity.ToString());
                }
            });
        });
    });
}).GeneratePdf("ordonnance.pdf");
```

**Avantages QuestPDF** : API plus lisible, moderne, licence permissive.

---

## 7.6 Injection de dépendances et tests unitaires

### 7.6.1 Problématique actuelle

Dans le code actuel, les DAO instancient directement `Database` :

```csharp
public class UserDAO
{
    private readonly Database db = new Database();
    // ...
}
```

**Limitations** :
- Couplage fort (impossible de mocker `Database` pour les tests).
- Difficile de changer la connexion sans modifier le code DAO.

### 7.6.2 Solution : Injection de dépendances (DI)

**Principe** : passer les dépendances via le constructeur.

```csharp
public class UserDAO
{
    private readonly IDatabase db;

    public UserDAO(IDatabase database)
    {
        db = database;
    }
}

// Interface pour faciliter les tests
public interface IDatabase
{
    MySqlConnection GetConnection();
}

public class Database : IDatabase
{
    public MySqlConnection GetConnection() { /* ... */ }
}
```

**Avantages** :
- Tests unitaires facilités (mock de `IDatabase`).
- Changement de connexion sans modifier le DAO.
- Meilleure séparation des responsabilités.

### 7.6.3 Tests unitaires avec xUnit et Moq

```csharp
using Xunit;
using Moq;

public class UserDAOTests
{
    [Fact]
    public void Login_ValidCredentials_ReturnsUser()
    {
        // Arrange
        var mockDb = new Mock<IDatabase>();
        var mockConnection = new Mock<MySqlConnection>();
        mockDb.Setup(db => db.GetConnection()).Returns(mockConnection.Object);
        
        var dao = new UserDAO(mockDb.Object);
        
        // Act
        User user = dao.Login("admin@gsb.fr", "Admin123!");
        
        // Assert
        Assert.NotNull(user);
        Assert.Equal("admin", user.Role);
    }
}
```

**Recommandation V2** : migrer vers DI + tests unitaires systématiques.

---

## 7.7 Protection contre les attaques : OWASP Top 10

### 7.7.1 OWASP Top 10 2021

| Rang | Vulnérabilité | Statut GSB | Mesures prises |
|------|---------------|------------|----------------|
| A01 | **Contrôle d'accès défaillant** | ⚠️ Partiel | Session utilisateur, rôles (à renforcer) |
| A02 | **Défaillances cryptographiques** | ⚠️ Partiel | Hash SHA-256 (à migrer vers bcrypt) |
| A03 | **Injection** | ✅ Protégé | Requêtes paramétrées partout |
| A04 | **Conception non sécurisée** | ⭐ Moyen | Architecture 3-tiers, validation UI |
| A05 | **Mauvaise config sécurité** | ⚠️ À vérifier | Credentials hardcodés (à externaliser) |
| A06 | **Composants vulnérables** | ⚠️ À surveiller | iTextSharp 5.x (obsolète), MySql.Data récent |
| A07 | **Échec identification/authentification** | ⚠️ Partiel | Pas de MFA, pas de limite tentatives |
| A08 | **Défaillances intégrité données** | ⭐ Moyen | Contraintes FK, transactions partielles |
| A09 | **Défaillances journalisation** | ❌ Absent | Aucun logging (à implémenter) |
| A10 | **Falsification requêtes côté serveur (SSRF)** | ✅ N/A | Pas de requêtes externes |

### 7.7.2 Recommandations prioritaires

1. **A02 : Cryptographie** → Migrer vers bcrypt immédiatement.
2. **A07 : Authentification** → Implémenter limitation des tentatives de connexion.
3. **A09 : Logging** → Intégrer Serilog pour tracer les actions critiques.
4. **A05 : Configuration** → Externaliser credentials (variables d'environnement, user secrets).

---

## 7.8 Évolutions futures et tendances

### 7.8.1 .NET 9+ (sortie novembre 2024)

**Nouveautés pertinentes pour GSB V2** :
- Améliorations des performances (Hot Reload, compilation).
- Entity Framework Core 9 : meilleures performances, JSON columns.
- C# 13 : nouveautés syntaxiques (params collections, inline arrays).

### 7.8.2 Cloud et conteneurisation

**Tendance** : migration des applications desktop vers le cloud ou hybrides.

| Approche | Avantages | Pertinence GSB |
|----------|-----------|----------------|
| **Application web (Blazor Server/WASM)** | Accessible partout, pas d'installation | ⭐⭐⭐ Pertinent en V2 |
| **API REST + client desktop** | Centralisation données, multi-clients | ⭐⭐⭐⭐ Recommandé en V3 |
| **Conteneurisation (Docker)** | Déploiement simplifié, reproductibilité | ⭐⭐ Utile pour tests/dev |

### 7.8.3 Intelligence artificielle (IA)

**Applications potentielles pour GSB V3** :
- **Assistance à la prescription** : détection d'interactions médicamenteuses (IA).
- **OCR** : extraction de données de documents scannés.
- **Chatbot** : assistance aux utilisateurs (FAQ automatique).

**Technologies** : OpenAI API, Azure Cognitive Services, ML.NET.

---

## 7.9 Synthèse de la veille

### 7.9.1 Décisions validées

| Décision | Technologie retenue | Justification |
|----------|---------------------|---------------|
| **Accès données** | ADO.NET | Contrôle total, simplicité pour ce projet |
| **UI** | Windows Forms | Rapidité de développement, designer visuel |
| **Hash passwords** | SHA-256 (actuel) → bcrypt (V2) | Sécurité renforcée |
| **PDF** | iTextSharp 5.x → QuestPDF (V2) | Licence permissive, API moderne |

### 7.9.2 Actions à mener (V2)

| Priorité | Action | Délai estimé |
|----------|--------|--------------|
| 🔴 Haute | Migrer vers bcrypt | 1 jour |
| 🔴 Haute | Externaliser credentials (env vars) | 0.5 jour |
| 🟠 Moyenne | Implémenter logging (Serilog) | 1 jour |
| 🟠 Moyenne | Ajouter tests unitaires (xUnit) | 2 jours |
| 🟡 Basse | Migrer vers QuestPDF | 1 jour |
| 🟡 Basse | Évaluer migration vers Blazor (web) | Phase d'étude (1 semaine) |

### 7.9.3 Ressources de veille continue

| Ressource | URL | Fréquence recommandée |
|-----------|-----|----------------------|
| **Microsoft .NET Blog** | https://devblogs.microsoft.com/dotnet/ | Hebdomadaire |
| **OWASP Cheat Sheets** | https://cheatsheetseries.owasp.org/ | Mensuelle |
| **C# Corner** | https://www.c-sharpcorner.com/ | Hebdomadaire |
| **GitHub Trending (C#)** | https://github.com/trending/c%23 | Hebdomadaire |
| **Stack Overflow (.NET tag)** | https://stackoverflow.com/questions/tagged/.net | Quotidienne |









