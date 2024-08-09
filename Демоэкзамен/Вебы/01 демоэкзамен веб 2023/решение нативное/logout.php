<?php
require_once "helpers/function.php";

if (!empty($_SESSION['user'])) {
    $_SESSION['user'] = "";
    header("Location: http://kinder-shop.ru");
}
?>