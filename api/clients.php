<?php
require __DIR__ . '/config.php';

require_api_key();

$method = $_SERVER['REQUEST_METHOD'];
$id = isset($_GET['id']) ? (int) $_GET['id'] : null;

function normalize_client(array $row): array
{
    return [
        'id' => (int) $row['id'],
        'nom' => $row['nom'],
        'prenom' => $row['prenom'],
        'email' => $row['email'],
        'telephone' => $row['telephone'],
        'adresse' => $row['adresse'],
    ];
}

try {
    if ($method === 'GET') {
        if ($id) {
            $stmt = $pdo->prepare('SELECT * FROM clients WHERE id = ?');
            $stmt->execute([$id]);
            $row = $stmt->fetch();
            if (!$row) {
                respond(['error' => 'Client introuvable'], 404);
            }
            respond(normalize_client($row));
        }

        $rows = $pdo->query('SELECT * FROM clients ORDER BY nom, prenom')->fetchAll();
        respond(array_map('normalize_client', $rows));
    }

    if ($method === 'POST' || $method === 'PUT') {
        if ($method === 'PUT' && !$id) {
            respond(['error' => 'Id requis'], 400);
        }

        $data = json_body();
        $nom = clamp_string($data['nom'] ?? '', 100);
        $prenom = clamp_string($data['prenom'] ?? '', 100);
        $email = clamp_string($data['email'] ?? '', 150);
        $telephone = clamp_string($data['telephone'] ?? '', 30);
        $adresse = clamp_string($data['adresse'] ?? '', 255);

        if ($nom === '' || $prenom === '') {
            respond(['error' => 'Nom et prénom obligatoires'], 400);
        }
        if (!valid_email($email === '' ? null : $email)) {
            respond(['error' => 'Email invalide'], 400);
        }

        if ($method === 'POST') {
            $stmt = $pdo->prepare(
                'INSERT INTO clients (nom, prenom, email, telephone, adresse) VALUES (?, ?, ?, ?, ?)'
            );
            $stmt->execute([
                $nom,
                $prenom,
                $email !== '' ? $email : null,
                $telephone !== '' ? $telephone : null,
                $adresse !== '' ? $adresse : null,
            ]);
            respond(['id' => (int) $pdo->lastInsertId()], 201);
        }

        $stmt = $pdo->prepare(
            'UPDATE clients SET nom = ?, prenom = ?, email = ?, telephone = ?, adresse = ? WHERE id = ?'
        );
        $stmt->execute([
            $nom,
            $prenom,
            $email !== '' ? $email : null,
            $telephone !== '' ? $telephone : null,
            $adresse !== '' ? $adresse : null,
            $id,
        ]);
        respond(['ok' => true]);
    }

    if ($method === 'DELETE') {
        if (!$id) {
            respond(['error' => 'Id requis'], 400);
        }
        $stmt = $pdo->prepare('DELETE FROM clients WHERE id = ?');
        $stmt->execute([$id]);
        respond(['ok' => true]);
    }

    respond(['error' => 'Méthode non supportée'], 405);
} catch (Throwable $e) {
    error_log('GMmatos clients: ' . $e->getMessage());
    respond(['error' => 'Erreur serveur'], 500);
}
