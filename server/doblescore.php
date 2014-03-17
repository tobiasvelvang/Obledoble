<?php
include '../scoreconfig/config.php';

try{
    $db = new PDO('mysql:host='.$host.';dbname='.$dbname, $user, $password);
}catch (PDOException $e){
    echo 'Connection error';
    exit();
}

if($_SERVER['REQUEST_METHOD'] == 'GET'){


    $count = $_GET['count'];
    if($count == '')
        $count = '10';
    $count = intval($count);
    $statement = $db->prepare('SELECT * FROM scores ORDER BY score DESC LIMIT :num');
    try{
        $statement->bindParam(':num', $count, PDO::PARAM_INT);
        $result = $statement->execute();
    }catch (PDOException $e){
        echo 'Query error';
        exit();
    }

    if($result)
        echo json_encode($statement->fetchAll(PDO::FETCH_ASSOC));
    else
        echo "{error:Query error}";
}else if($_SERVER['REQUEST_METHOD'] == 'POST'){

    if(!(isset($_POST['hash']) && isset($_POST['name']) && isset($_POST['score']))){
        echo 'Invalid parameters';
        exit();
    }
    $hash = $_POST['hash'];
    $name = $_POST['name'];
    $score = $_POST['score'];
    if(md5($name.$score.$secret)== $hash){

        $statement = $db->prepare('INSERT INTO scores VALUES(:name,:score)');
        try{
            $statement->bindParam(':name', $name, PDO::PARAM_STR);
            $statement->bindParam(':score', $score, PDO::PARAM_INT);
            $result = $statement->execute();
            echo $result;
        }catch (PDOException $e){
            echo 'Query error';
            exit();
        }
    }else{
        echo 'Invalid hash';
        exit();
    }

}



 ?>