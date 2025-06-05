-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: tfg
-- ------------------------------------------------------
-- Server version	9.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `frase`
--

DROP TABLE IF EXISTS `frase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `frase` (
  `idFrases` int NOT NULL AUTO_INCREMENT,
  `contenido` varchar(1028) NOT NULL,
  PRIMARY KEY (`idFrases`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frase`
--

LOCK TABLES `frase` WRITE;
/*!40000 ALTER TABLE `frase` DISABLE KEYS */;
INSERT INTO `frase` VALUES (39,'VIDA ANTES QUE MUERTE\nFUERZA ANTES QUE DEBILIDAD\nVIAJE ANTES QUE DESTINO'),(40,'Yo soy la esperanza'),(41,'¿Tan lejos anda la locura de la sabiduría?'),(42,'Escribo estas palabras en acero, pues todo lo que no esté grabado en metal es indigno de confianza'),(43,'Szeth-hijo-hijo-Vallano, Sinverdad de Shinovar, vestía de blanco el día que iba a matar a un rey'),(44,'El hombre que teme la derrota ya ha sido derrotado.'),(45,'Rompe las cadenas, amor mío'),(46,'Protegeré a aquellos que no puedan protegerse'),(47,'No tienes nada que temer. Duerme, y deja de soñar a voces'),(48,'No jugaba deprisa, sino para ganar'),(49,'No puedes tener mi dolor'),(50,'Caía ceniza del cielo'),(51,'Acepta el dolor, pero no aceptes que lo merecías'),(52,'Aceptaré la responsabilidad por lo que he hecho. Si debo caer, cada vez me alzaré como un hombre mejor'),(53,'Las palabras mas importantes que puede decir un hombre son: Lo haré mejor'),(54,'Soy lo que el universo me hizo ser'),(55,'Si muero, lo haré habiendo vivido bien mi vida'),(56,'Te estás volviendo débil, tío. No explotaré esa debilidad. Pero otros lo harán'),(57,'Los lobos no tienen rey'),(58,'La verdad es a menudo mucho más grande que los hechos'),(59,'Ser incapaz de pensar en una respuesta no es lo mismo que aceptar las palabras de otro'),(60,'Una cicatriz nunca es lo mismo que la verdadera piel, pero la herida deja de sangrar igual'),(61,'El paso mas importante que debe dar un hombre es siempre el siguiente'),(62,'Si me amaras con la pasión con que declaraste que me amabas, nada podría impedirte que me vieras, ni los muros, ni los modales, ni la reputación ni el protocolo');
/*!40000 ALTER TABLE `frase` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-02 19:34:07
