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
3. Copier `api/config.local.php.example` vers `api/config.local.php` et renseigner les secrets.
4. Créer l’utilisateur MySQL applicatif : importer `database/secure_user.sql` (via root), puis `database/matos.sql`.
5. Ouvrir la solution WinForms et aligner `ApiKey` dans `App.config` avec `api_key` de `config.local.php`.
6. Lancer avec **F5**.

Setup BDD (localhost + token uniquement) :
```
http://localhost/Projet-C/api/setup.php?token=VOTRE_SETUP_TOKEN
```

## Configuration / sécurité

Secrets locaux dans `api/config.local.php` (non versionné) :

- compte MySQL dédié `gmmatos_app` (pas root)
- clé API (`X-Api-Key`) obligatoire sur `clients.php` / `materiel.php`
- `setup.php` limité à 127.0.0.1 + `setup_token`
- dossier `database/` bloqué par `.htaccess`

Dans `App.config` :

```xml
<add key="ApiBaseUrl" value="http://localhost/Projet-C/api/" />
<add key="ApiKey" value="meme_valeur_que_config.local.php" />
```

## Structure du projet

```
Projet-C/
├── api/                  # Endpoints REST PHP
│   ├── clients.php
│   ├── materiel.php
│   ├── config.php
│   └── setup.php
├── database/
│   ├── matos.sql         # Création BDD + données démo
│   ├── secure_user.sql   # User MySQL applicatif
│   └── .htaccess         # Accès web refusé
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
