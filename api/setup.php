<?php
/**
 * Initialisation BDD — réservé au localhost + token setup.
 * Exemple : http://localhost/Projet-C/api/setup.php?token=VOTRE_SETUP_TOKEN
 */
header('Content-Type: application/json; charset=utf-8');

$localFile = __DIR__ . '/config.local.php';
if (!is_file($localFile)) {
    http_response_code(500);
    echo json_encode(['ok' => false, 'error' => 'Configuration manquante.']);
    exit;
}

$cfg = require $localFile;
$setupToken = $cfg['setup_token'] ?? '';
$token = $_GET['token'] ?? '';

$ip = $_SERVER['REMOTE_ADDR'] ?? '';
if (!in_array($ip, ['127.0.0.1', '::1'], true)) {
    http_response_code(403);
    echo json_encode(['ok' => false, 'error' => 'Accès refusé.']);
    exit;
}

if ($setupToken === '' || !hash_equals($setupToken, $token)) {
    http_response_code(401);
    echo json_encode(['ok' => false, 'error' => 'Token setup invalide.']);
    exit;
}

// Connexion root uniquement pour créer la base / user (local)
$host = $cfg['db_host'] ?? '127.0.0.1';
$rootUser = $cfg['setup_db_user'] ?? 'root';
$rootPass = $cfg['setup_db_pass'] ?? '';

try {
    $pdo = new PDO("mysql:host=$host;charset=utf8mb4", $rootUser, $rootPass, [
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
    ]);

    $sqlFile = __DIR__ . '/../database/matos.sql';
    $sql = file_get_contents($sqlFile);
    if ($sql === false) {
        throw new RuntimeException('Lecture SQL impossible');
    }

    $lines = preg_split("/\r\n|\n|\r/", $sql);
    $buffer = '';
    $executed = 0;

    foreach ($lines as $line) {
        $trim = trim($line);
        if ($trim === '' || strpos($trim, '--') === 0) {
            continue;
        }
        $buffer .= $line . "\n";
        if (substr(rtrim($line), -1) === ';') {
            $pdo->exec($buffer);
            $executed++;
            $buffer = '';
        }
    }

    if (trim($buffer) !== '') {
        $pdo->exec($buffer);
        $executed++;
    }

    // Applique aussi le user applicatif si le fichier existe
    $secureFile = __DIR__ . '/../database/secure_user.sql';
    if (is_file($secureFile)) {
        $secureSql = file_get_contents($secureFile);
        $buffer = '';
        foreach (preg_split("/\r\n|\n|\r/", $secureSql) as $line) {
            $trim = trim($line);
            if ($trim === '' || strpos($trim, '--') === 0) {
                continue;
            }
            $buffer .= $line . "\n";
            if (substr(rtrim($line), -1) === ';') {
                try {
                    $pdo->exec($buffer);
                } catch (Throwable $ignored) {
                    // user peut déjà exister
                }
                $buffer = '';
            }
        }
    }

    echo json_encode([
        'ok' => true,
        'message' => "Base initialisée ($executed instructions).",
    ], JSON_UNESCAPED_UNICODE);
} catch (Throwable $e) {
    error_log('GMmatos setup: ' . $e->getMessage());
    http_response_code(500);
    echo json_encode(['ok' => false, 'error' => 'Échec de l\'initialisation.']);
}
