<?php
header('Content-Type: application/json; charset=utf-8');
header('Access-Control-Allow-Origin: http://localhost');
header('Access-Control-Allow-Methods: GET, POST, PUT, DELETE, OPTIONS');
header('Access-Control-Allow-Headers: Content-Type, X-Api-Key');

if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
    http_response_code(204);
    exit;
}

$localFile = __DIR__ . '/config.local.php';
if (!is_file($localFile)) {
    http_response_code(500);
    echo json_encode([
        'error' => 'Configuration manquante. Copiez api/config.local.php.example vers api/config.local.php.',
    ], JSON_UNESCAPED_UNICODE);
    exit;
}

/** @var array $cfg */
$cfg = require $localFile;

$host = $cfg['db_host'] ?? '127.0.0.1';
$db = $cfg['db_name'] ?? 'gmmatos';
$user = $cfg['db_user'] ?? '';
$pass = $cfg['db_pass'] ?? '';
$apiKey = $cfg['api_key'] ?? '';
$setupToken = $cfg['setup_token'] ?? '';
$charset = 'utf8mb4';

try {
    $pdo = new PDO(
        "mysql:host=$host;dbname=$db;charset=$charset",
        $user,
        $pass,
        [
            PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
            PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
        ]
    );
} catch (PDOException $e) {
    error_log('GMmatos DB: ' . $e->getMessage());
    http_response_code(500);
    echo json_encode(['error' => 'Service temporairement indisponible.']);
    exit;
}

function json_body(): array
{
    $raw = file_get_contents('php://input');
    if ($raw === false || $raw === '') {
        return [];
    }
    $data = json_decode($raw, true);
    return is_array($data) ? $data : [];
}

function respond($data, int $code = 200): void
{
    http_response_code($code);
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
    exit;
}

function require_api_key(): void
{
    global $apiKey;
    $provided = $_SERVER['HTTP_X_API_KEY'] ?? '';
    if ($apiKey === '' || !hash_equals($apiKey, $provided)) {
        respond(['error' => 'Non autorisé'], 401);
    }
}

function client_ip(): string
{
    return $_SERVER['REMOTE_ADDR'] ?? '';
}

function is_local_request(): bool
{
    $ip = client_ip();
    return in_array($ip, ['127.0.0.1', '::1'], true);
}

function clamp_string(?string $value, int $max): string
{
    $value = trim((string) $value);
    if (strlen($value) > $max) {
        $value = substr($value, 0, $max);
    }
    return $value;
}

function valid_email(?string $email): bool
{
    if ($email === null || $email === '') {
        return true;
    }
    return (bool) filter_var($email, FILTER_VALIDATE_EMAIL);
}
