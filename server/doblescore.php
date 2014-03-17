<?php
include '../scoreconfig/config.php';

if($_SERVER['REQUEST_METHOD'] == 'GET'){

    try{
        $db = new PDO('mysql:host='.$host.';dbname='.$dbname, $user, $password);
    }catch (PDOException $e){
        echo "{error: Connection error}";
        exit();
    }
    $count = $_GET['count'];
    if($count == '')
        $count = '10';
    $count = intval($count);
    $statement = $db->prepare('SELECT * FROM scores ORDER BY score DESC LIMIT :num');
    try{
        $statement->bindParam(':num', $count, PDO::PARAM_INT);
        $result = $statement->execute();
    }catch (PDOException $e){
        echo "{error:Query error}";
        exit();
    }

    if($result)
        echo json_encode($statement->fetchAll(PDO::FETCH_ASSOC));
    else
        echo "{error:Query error}";

}

 ?>