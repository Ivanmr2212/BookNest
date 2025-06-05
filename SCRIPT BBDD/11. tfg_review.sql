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
-- Table structure for table `review`
--

DROP TABLE IF EXISTS `review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `review` (
  `Usuario_idUsuario` int NOT NULL,
  `Libro_idLibro` int NOT NULL,
  `texto` varchar(1028) DEFAULT NULL,
  `puntuacion` int DEFAULT NULL,
  `fecha` varchar(45) NOT NULL,
  PRIMARY KEY (`Usuario_idUsuario`,`Libro_idLibro`,`fecha`),
  KEY `fk_Usuario_has_Libro_Libro1_idx` (`Libro_idLibro`),
  KEY `fk_Usuario_has_Libro_Usuario_idx` (`Usuario_idUsuario`),
  CONSTRAINT `fk_Usuario_has_Libro_Libro1` FOREIGN KEY (`Libro_idLibro`) REFERENCES `libro` (`idLibro`),
  CONSTRAINT `fk_Usuario_has_Libro_Usuario` FOREIGN KEY (`Usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `review`
--

LOCK TABLES `review` WRITE;
/*!40000 ALTER TABLE `review` DISABLE KEYS */;
INSERT INTO `review` VALUES (10,20,'Me ha gustado mucho pero....',4,'2025-6-1'),(10,29,'Muy bueno. Hrathen el mejor',3,'2025-5-28'),(10,72,'Me ha gustado, excepto...',3,'2025-5-27'),(10,96,'No me ha gustado',1,'2025-5-28'),(1002,17,'Me ha gustado mucho',4,'2025-6-1'),(1002,59,'No me ha gustado',2,'2025-6-1'),(1002,81,'No me ha gustado porque...',2,'2025-6-1'),(1002,112,'Me ha gustado mucho, me ha parecido una buena historia para...',3,'2025-6-1'),(1002,123,'No era lo que m esperaba',2,'2025-6-1'),(1007,41,'Entretenido',4,'2025-5-29'),(1007,156,'No me ha gustado',1,'2025-5-27');
/*!40000 ALTER TABLE `review` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-02 19:34:05
