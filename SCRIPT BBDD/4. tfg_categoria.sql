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
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `idCategoria` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(1024) DEFAULT NULL,
  `Usuario_idUsuario` int NOT NULL,
  PRIMARY KEY (`idCategoria`),
  KEY `fk_Categoria_Usuario1_idx` (`Usuario_idUsuario`),
  CONSTRAINT `fk_Categoria_Usuario1` FOREIGN KEY (`Usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'WorldBuilding','Categoria de ejemplo',8),(2,'Personajes','Categoria para hablar de los personajes, su desarrollos, momentos...',8),(3,'Momentos','Buenos momentos del libro',7),(4,'Momentos','Descripción ejemplo',8),(5,'Contenido del libro','Categoria para hablar de momentos',10),(6,'Resumen','Categoria para resumenes',10),(7,'Teorías','Categoria para hablar de teorías y pensamientos que se nos ocurren',10),(8,'Contenido del libro','Categoria para comentar todo aquello relacionado con la historia del libro',11),(9,'Momentos','Categoria para hablar de buenos momentos del libro',11),(10,'Teorías','Categoria para hablar de teorías que se nos ocurren',11),(14,'Contenido del libro','Categoria para hablar de momentos',1002),(15,'Resumen','Categoria para escribir resumenes',1002),(16,'Teorías','Categoria para hablar de teorías y pensamientos que se nos ocurren',1002),(17,'Contenido del libro','Categoria para comentar todo aquello relacionado con la historia del libro',1006),(18,'Momentos','Categoria para hablar de buenos momentos del libro',1006),(19,'Teorías','Categoria para hablar de teorías que se nos ocurren',1006),(20,'Contenido del libro','Categoria para comentar todo aquello relacionado con la historia del libro',1007),(21,'Momentos','Categoria para hablar de buenos momentos del libro',1007),(22,'Teorías','Categoria para hablar de teorías que se nos ocurren',1007),(26,'Contenido del libro','Categoria para comentar todo aquello relacionado con la historia del libro',1009),(27,'Momentos','Categoria para hablar de buenos momentos del libro',1009),(28,'Teorías','Categoria para hablar de teorías que se nos ocurren',1009),(29,'Personajes','Categoria para hablar sobre el desarrollo de los personajes',10);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
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
