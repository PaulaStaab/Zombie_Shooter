<?php
header('Access-Control-Allow-Origin: *');
header('Access-Control-Allow-Methods: GET, POST, OPTIONS');
header('Access-Control-Allow-Headers: Content-Type');

if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
    http_response_code(200);
    exit;
}

header('Content-Type: application/json');
require_once 'db_config.php';

$input = json_decode(file_get_contents('php://input'), true);
$data = $input ?: $_POST ?: [];

if (!isset($data['player_name']) || !isset($data['kills'])) {
    http_response_code(400);
    echo json_encode(['ok' => false, 'error' => 'Missing player_name or kills']);
    exit;
}

$name = trim($data['player_name']);
$kills = (int)$data['kills'];

if ($name === '' || mb_strlen($name) > 50) {
    http_response_code(400);
    echo json_encode(['ok' => false, 'error' => 'Invalid name']);
    exit;
}

if ($kills < 0) {
    http_response_code(400);
    echo json_encode(['ok' => false, 'error' => 'Invalid kills']);
    exit;
}

$total_score = $kills * 100;

$stmt = $pdo->prepare("INSERT INTO highscores (player_name, kills, total_score) VALUES (?, ?, ?)");
$stmt->execute([$name, $kills, $total_score]);

echo json_encode(['ok' => true, 'id' => $pdo->lastInsertId()]);
?>
