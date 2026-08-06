# Projet-C — Gestion Matos

Application de **gestion de matériel** (parc + clients) développée en **C# Windows Forms**, avec une **API PHP** et une base **MySQL** sous XAMPP.

## Fonctionnalités

- Menu principal (`FormGenerale`)
- CRUD **Clients** (nom, prénom, email, téléphone, adresse)
- CRUD **Matériel** (référence, désignation, catégorie, quantité, prix/jour, état)
- API REST PHP pour l’accès aux données
- Script SQL d’initialisation avec données de démonstration

## Stack technique

| Couche | Technologie |
|--------|-------------|
| Interface | C# WinForms (.NET Framework 4.8) |
| API | PHP (PDO) |
| Base de données | MySQL / MariaDB (XAMPP) |
| Communication | HTTP JSON |

## Prérequis

- [XAMPP](https://www.apachefriends.org/) (Apache + MySQL)
- Visual Studio avec le ciblage **.NET Framework 4.8**

## Installation

1. Cloner le dépôt dans `C:\xampp\htdocs\Projet-C` (ou adapter l’URL de l’API).
2. Démarrer **Apache** et **MySQL** dans le panneau XAMPP.
3. Initialiser la base une fois :
   - navigateur : `http://localhost/Projet-C/api/setup.php`
   - ou import de `database/matos.sql` via phpMyAdmin
4. Ouvrir `WindowsFormsAppGMmatos/WindowsFormsAppGMmatos/WindowsFormsAppGMmatos.sln` dans Visual Studio.
5. Lancer avec **F5**.

## Configuration

L’URL de l’API est définie dans `App.config` :

```xml
<add key="ApiBaseUrl" value="http://localhost/Projet-C/api/" />
```

Les identifiants MySQL se configurent dans `api/config.php` (par défaut : `root` / mot de passe vide).

## Structure du projet

```
Projet-C/
├── api/                  # Endpoints REST PHP
│   ├── clients.php
│   ├── materiel.php
│   ├── config.php
│   └── setup.php
├── database/
│   └── matos.sql         # Création BDD + données démo
└── WindowsFormsAppGMmatos/
    └── ...               # Application WinForms
        ├── Models/       # Client, Materiel
        ├── Data/         # ApiService (appels HTTP)
        ├── FormGenerale  # Menu
        ├── Formclient    # Gestion clients
        └── FormMateriel  # Gestion matériel
```

## Endpoints API

| Méthode | URL | Description |
|---------|-----|-------------|
| GET | `/api/clients.php` | Liste des clients |
| POST | `/api/clients.php` | Créer un client |
| PUT | `/api/clients.php?id=` | Modifier un client |
| DELETE | `/api/clients.php?id=` | Supprimer un client |
| GET/POST/PUT/DELETE | `/api/materiel.php` | Idem pour le matériel |

## Auteur

Projet académique — Gestion Matos 13
