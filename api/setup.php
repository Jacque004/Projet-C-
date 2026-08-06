<?php
header('Content-Type: application/json; charset=utf-8');

$host = '127.0.0.1';
$user = 'root';
$pass = '';

try {
    $pdo = new PDO("mysql:host=$host;charset=utf8mb4", $user, $pass, [
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
    ]);

    $sqlFile = __DIR__ . '/../database/matos.sql';
    $sql = file_get_contents($sqlFile);
    if ($sql === false) {
        throw new RuntimeException('Impossible de lire database/matos.sql');
    }

    // Retire les commentaires SQL ligne et découpe en instructions
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

    echo json_encode([
        'ok' => true,
        'message' => "Base gmmatos créée et initialisée ($executed instructions).",
    ], JSON_UNESCAPED_UNICODE);
} catch (Throwable $e) {
    http_response_code(500);
    echo json_encode(['ok' => false, 'error' => $e->getMessage()], JSON_UNESCAPED_UNICODE);
}
