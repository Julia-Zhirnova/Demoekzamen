<?php
require_once "helpers/function.php";
if (!empty($_SESSION['user'])) {
    header("Location: http://kinder-shop.ru/admpanel");
}
?>
<!doctype html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Интернет-магазин kinder-shop.ru</title>
    <link rel="icon" href="images/logo.png">
    <link rel="stylesheet" href="styles/main.css">

</head>
<body>
<header>
    <img src="images/logo.png" alt="Логотип">
    <h1>Интернет-магазин kinder-shop.ru</h1>
</header>

<nav>
    <a href="/">Главная</a>
    <a href="/admpanel">Административная панель</a>
</nav>

<main>
    <h2>Вход</h2>
    <p class="error">
        <?php
        $login = strip_tags($_GET['login'] ?? "");
        $password = strip_tags($_GET['password'] ?? "");
            if ($login && $password) {
                if (login($login, $password)) {
                    header("Location: http://kinder-shop.ru/admpanel");
                    $_SESSION['user'] = $login;
                } else {
                    echo "Не верный логин или пароль";
                }
            }
        ?>
    </p>
    <form>
        <label>
            Логин
            <input type="text" name="login">
        </label>
        <label>
            Пароль
            <input type="password" name="password">
        </label>
        <button>Войти</button>
    </form>
</main>
<script src="scripts/main.js"></script>
</body>
</html>