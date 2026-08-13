-- À exécuter une fois en tant que root (phpMyAdmin ou mysql CLI)
-- Crée un compte applicatif limité à la base gmmatos

CREATE DATABASE IF NOT EXISTS gmmatos
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE gmmatos;

CREATE USER IF NOT EXISTS 'gmmatos_app'@'localhost' IDENTIFIED BY 'GMmatos_App_2026!';
CREATE USER IF NOT EXISTS 'gmmatos_app'@'127.0.0.1' IDENTIFIED BY 'GMmatos_App_2026!';

GRANT SELECT, INSERT, UPDATE, DELETE ON gmmatos.* TO 'gmmatos_app'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON gmmatos.* TO 'gmmatos_app'@'127.0.0.1';

FLUSH PRIVILEGES;
