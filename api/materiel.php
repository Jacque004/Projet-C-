<?php
require __DIR__ . '/config.php';

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

    if ($method === 'POST') {
        $data = json_body();
        $reference = trim($data['reference'] ?? '');
        $designation = trim($data['designation'] ?? '');
        if ($reference === '' || $designation === '') {
            respond(['error' => 'Référence et désignation obligatoires'], 400);
        }

        $etat = $data['etat'] ?? 'disponible';
        if (!in_array($etat, $etats, true)) {
            respond(['error' => 'État invalide'], 400);
        }

        $stmt = $pdo->prepare(
            'INSERT INTO materiel (reference, designation, categorie, quantite, prix_jour, etat)
             VALUES (?, ?, ?, ?, ?, ?)'
        );
        $stmt->execute([
            $reference,
            $designation,
            trim($data['categorie'] ?? '') ?: null,
            (int) ($data['quantite'] ?? 0),
            (float) ($data['prix_jour'] ?? 0),
            $etat,
        ]);

        respond(['id' => (int) $pdo->lastInsertId()], 201);
    }

    if ($method === 'PUT') {
        if (!$id) {
            respond(['error' => 'Id requis'], 400);
        }
        $data = json_body();
        $reference = trim($data['reference'] ?? '');
        $designation = trim($data['designation'] ?? '');
        if ($reference === '' || $designation === '') {
            respond(['error' => 'Référence et désignation obligatoires'], 400);
        }

        $etat = $data['etat'] ?? 'disponible';
        if (!in_array($etat, $etats, true)) {
            respond(['error' => 'État invalide'], 400);
        }

        $stmt = $pdo->prepare(
            'UPDATE materiel
             SET reference = ?, designation = ?, categorie = ?, quantite = ?, prix_jour = ?, etat = ?
             WHERE id = ?'
        );
        $stmt->execute([
            $reference,
            $designation,
            trim($data['categorie'] ?? '') ?: null,
            (int) ($data['quantite'] ?? 0),
            (float) ($data['prix_jour'] ?? 0),
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
    respond(['error' => $e->getMessage()], 500);
}
