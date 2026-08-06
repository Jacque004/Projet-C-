# WindowsFormsAppGMmatos

Application WinForms de gestion de matériel (clients + parc matériel), avec API PHP et base MySQL (XAMPP).

## Prérequis

1. Démarrer **Apache** et **MySQL** dans le panneau XAMPP
2. Visual Studio avec .NET Framework 4.8

## Initialisation de la base

Ouvrir une fois dans le navigateur :

```
http://localhost/Projet-C/api/setup.php
```

Ou importer `database/matos.sql` via phpMyAdmin.

## Lancer l'application

Ouvrir `WindowsFormsAppGMmatos.sln` dans Visual Studio, puis F5.

L'URL de l'API est configurable dans `App.config` (`ApiBaseUrl`).

## Structure

| Élément | Rôle |
|---------|------|
| `api/` | Endpoints REST PHP (clients, matériel) |
| `database/matos.sql` | Structure BDD + données de démo |
| `Models/` | Entités Client et Materiel |
| `Data/ApiService.cs` | Appels HTTP vers l'API |
| `FormGenerale` | Menu principal |
| `Formclient` | CRUD clients |
| `FormMateriel` | CRUD matériel |
