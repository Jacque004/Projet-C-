<?php
require __DIR__ . '/config.php';

require_api_key();

$method = $_SERVER['REQUEST_METHOD'];
$id = isset($_GET['id']) ? (int) $_GET['id'] : null;
$etats = ['disponible', 'loue', 'maintenance', 'hors_service'];

function normalize_materiel(array $row): array
{
    return [
        'id' => (int) $row['id'],
        'reference' => $row['reference'],
        'designation' => $row['designation'],
        'categorie' => $row['categorie'],
        'quantite' => (int) $row['quantite'],
        'prix_jour' => (float) $row['prix_jour'],
        'etat' => $row['etat'],
    ];
}

try {
    if ($method === 'GET') {
        if ($id) {
            $stmt = $pdo->prepare('SELECT * FROM materiel WHERE id = ?');
            $stmt->execute([$id]);
            $row = $stmt->fetch();
            if (!$row) {
                respond(['error' => 'Matériel introuvable'], 404);
            }
            respond(normalize_materiel($row));
        }

        $rows = $pdo->query('SELECT * FROM materiel ORDER BY reference')->fetchAll();
        respond(array_map('normalize_materiel', $rows));
    }

    if ($method === 'POST' || $method === 'PUT') {
        if ($method === 'PUT' && !$id) {
            respond(['error' => 'Id requis'], 400);
        }

        $data = json_body();
        $reference = clamp_string($data['reference'] ?? '', 50);
        $designation = clamp_string($data['designation'] ?? '', 150);
        $categorie = clamp_string($data['categorie'] ?? '', 80);
        $quantite = (int) ($data['quantite'] ?? 0);
        $prixJour = (float) ($data['prix_jour'] ?? 0);
        $etat = $data['etat'] ?? 'disponible';

        if ($reference === '' || $designation === '') {
            respond(['error' => 'Référence et désignation obligatoires'], 400);
        }
        if ($quantite < 0 || $quantite > 100000) {
            respond(['error' => 'Quantité invalide'], 400);
        }
        if ($prixJour < 0 || $prixJour > 100000) {
            respond(['error' => 'Prix invalide'], 400);
        }
        if (!in_array($etat, $etats, true)) {
            respond(['error' => 'État invalide'], 400);
        }

        if ($method === 'POST') {
            $stmt = $pdo->prepare(
                'INSERT INTO materiel (reference, designation, categorie, quantite, prix_jour, etat)
                 VALUES (?, ?, ?, ?, ?, ?)'
            );
            $stmt->execute([
                $reference,
                $designation,
                $categorie !== '' ? $categorie : null,
                $quantite,
                $prixJour,
                $etat,
            ]);
            respond(['id' => (int) $pdo->lastInsertId()], 201);
        }

        $stmt = $pdo->prepare(
            'UPDATE materiel
             SET reference = ?, designation = ?, categorie = ?, quantite = ?, prix_jour = ?, etat = ?
             WHERE id = ?'
        );
        $stmt->execute([
            $reference,
            $designation,
            $categorie !== '' ? $categorie : null,
            $quantite,
            $prixJour,
            $etat,
            $id,
        ]);
        respond(['ok' => true]);
    }

    if ($method === 'DELETE') {
        if (!$id) {
            respond(['error' => 'Id requis'], 400);
        }
        $stmt = $pdo->prepare('DELETE FROM materiel WHERE id = ?');
        $stmt->execute([$id]);
        respond(['ok' => true]);
    }

    respond(['error' => 'Méthode non supportée'], 405);
} catch (Throwable $e) {
    error_log('GMmatos materiel: ' . $e->getMessage());
    respond(['error' => 'Erreur serveur'], 500);
}
