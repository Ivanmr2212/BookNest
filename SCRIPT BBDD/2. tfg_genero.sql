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
-- Table structure for table `genero`
--

DROP TABLE IF EXISTS `genero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genero` (
  `idGenero` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`idGenero`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genero`
--

LOCK TABLES `genero` WRITE;
/*!40000 ALTER TABLE `genero` DISABLE KEYS */;
INSERT INTO `genero` VALUES (1,'Fantasia','Género literario que presenta mundos, seres y eventos sobrenaturales o mágicos que no siguen las leyes de la realidad. Puede incluir criaturas mitológicas, magia, reinos imaginarios y aventuras épicas.'),(3,'Thriller','Género literario que se caracteriza por generar tensión y suspense en el lector.\nEl objetivo es mantener al lector expectante y preocupado por lo que le ocurrirá a los personajes. '),(4,'Ciencia ficción','Género literario que se basa en la especulación racional sobre el impacto de avances científicos o sociales en la sociedad.\nSe desarrolla en escenarios imaginarios y diferentes a los de la realidad. '),(5,'Histórico','Género narrativo que recrea un periodo histórico a través de la ficción'),(6,'Terror','Género que busca provocar miedo o terror en el lector.\nTambién se le conoce como literatura de horror o gótica. '),(7,'Romance','Género literario que se caracteriza por retratar argumentos construidos de eventos y personajes relacionados con la expresión del amor y las relaciones románticas.'),(8,'Drama','Género literario que se caracteriza por narrar historias a través de los diálogos entre personajes, con el objetivo de ser representado en escena.'),(9,'Distopia','Género literario que se caracteriza por representar una sociedad futura con características negativas. En este tipo de obras, los personajes suelen luchar contra la opresión de la sociedad.'),(10,'Realismo mágico',' Género literario y pictórico que se caracteriza por mostrar lo extraño o irreal como algo cotidiano.'),(11,'Aventura','Ggénero literario de aventuras es un relato que narra las hazañas de un personaje que se enfrenta a situaciones peligrosas o emocionantes. Las aventuras pueden ser físicas, emocionales o personales.');
/*!40000 ALTER TABLE `genero` ENABLE KEYS */;
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
