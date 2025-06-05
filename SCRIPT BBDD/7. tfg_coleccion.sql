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
-- Table structure for table `coleccion`
--

DROP TABLE IF EXISTS `coleccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coleccion` (
  `idColeccion` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `Usuario_idUsuario` int NOT NULL,
  PRIMARY KEY (`idColeccion`),
  KEY `fk_Coleccion_Usuario1_idx` (`Usuario_idUsuario`),
  CONSTRAINT `fk_Coleccion_Usuario1` FOREIGN KEY (`Usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coleccion`
--

LOCK TABLES `coleccion` WRITE;
/*!40000 ALTER TABLE `coleccion` DISABLE KEYS */;
INSERT INTO `coleccion` VALUES (2,'Colec1',1),(5,'Por leer',6),(6,'Por leer',7),(7,'Leyendo',7),(8,'Leido',7),(9,'Favoritos',7),(10,'Proxima lectura',7),(11,'Fantasía',7),(12,'Thriller',7),(13,'Historico',7),(14,'Autoconclusivos',7),(15,'Por leer',8),(16,'Leyendo',8),(17,'Leido',8),(18,'Favoritos',8),(19,'Trilogias',8),(20,'Autoconclusivos',8),(21,'Por leer',9),(22,'Leyendo',9),(23,'Leido',9),(24,'Favoritos',9),(25,'Autoconclusivos',9),(26,'Fantasia',9),(27,'Suspense',8),(28,'Todos',10),(29,'Por leer',10),(30,'Leyendo',10),(31,'Leido',10),(32,'Favoritos',10),(34,'Todos',11),(35,'Favoritos',11),(36,'Por leer',11),(37,'Leido',11),(38,'Leyendo',11),(45,'Todos',1002),(46,'Por leer',1002),(47,'Leyendo',1002),(48,'Leido',1002),(49,'Favoritos',1002),(53,'Todos',1006),(54,'Favoritos',1006),(55,'Por leer',1006),(56,'Leido',1006),(57,'Leyendo',1006),(61,'Cosmere',10),(64,'Históricos',10),(66,'Todos',1007),(67,'Favoritos',1007),(68,'Por leer',1007),(69,'Leido',1007),(70,'Leyendo',1007),(71,'Fantasía',10),(77,'Ciencia ficcion',10),(78,'Todos',1009),(79,'Favoritos',1009),(80,'Por leer',1009),(81,'Leido',1009),(82,'Leyendo',1009),(83,'Históricos',1002);
/*!40000 ALTER TABLE `coleccion` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-02 19:34:06
