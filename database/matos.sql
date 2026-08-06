CREATE DATABASE IF NOT EXISTS gmmatos
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE gmmatos;

CREATE TABLE IF NOT EXISTS clients (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nom VARCHAR(100) NOT NULL,
  prenom VARCHAR(100) NOT NULL,
  email VARCHAR(150) NULL,
  telephone VARCHAR(30) NULL,
  adresse VARCHAR(255) NULL,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS materiel (
  id INT AUTO_INCREMENT PRIMARY KEY,
  reference VARCHAR(50) NOT NULL UNIQUE,
  designation VARCHAR(150) NOT NULL,
  categorie VARCHAR(80) NULL,
  quantite INT NOT NULL DEFAULT 0,
  prix_jour DECIMAL(10,2) NOT NULL DEFAULT 0.00,
  etat ENUM('disponible','loue','maintenance','hors_service') NOT NULL DEFAULT 'disponible',
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO clients (nom, prenom, email, telephone, adresse)
SELECT 'Dupont', 'Alice', 'alice.dupont@email.fr', '0601020304', '12 rue des Lilas, Paris'
WHERE NOT EXISTS (SELECT 1 FROM clients LIMIT 1);

INSERT INTO clients (nom, prenom, email, telephone, adresse)
SELECT 'Martin', 'Bruno', 'bruno.martin@email.fr', '0611223344', '5 avenue Victor Hugo, Lyon'
WHERE (SELECT COUNT(*) FROM clients) < 2;

INSERT INTO materiel (reference, designation, categorie, quantite, prix_jour, etat)
SELECT 'CAM-001', 'Caméra Sony A7', 'Image', 3, 45.00, 'disponible'
WHERE NOT EXISTS (SELECT 1 FROM materiel LIMIT 1);

INSERT INTO materiel (reference, designation, categorie, quantite, prix_jour, etat)
SELECT 'MIC-014', 'Micro HF Sennheiser', 'Son', 5, 18.50, 'disponible'
WHERE NOT EXISTS (SELECT 1 FROM materiel WHERE reference = 'MIC-014');

INSERT INTO materiel (reference, designation, categorie, quantite, prix_jour, etat)
SELECT 'LUM-003', 'Projecteur LED 200W', 'Lumière', 2, 25.00, 'maintenance'
WHERE NOT EXISTS (SELECT 1 FROM materiel WHERE reference = 'LUM-003');
