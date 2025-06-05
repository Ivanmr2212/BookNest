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
-- Table structure for table `libroscoleccion`
--

DROP TABLE IF EXISTS `libroscoleccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `libroscoleccion` (
  `Coleccion_idColeccion` int NOT NULL,
  `Libro_idLibro` int NOT NULL,
  PRIMARY KEY (`Coleccion_idColeccion`,`Libro_idLibro`),
  KEY `fk_Coleccion_has_Libro_Libro1_idx` (`Libro_idLibro`),
  KEY `fk_Coleccion_has_Libro_Coleccion1_idx` (`Coleccion_idColeccion`),
  CONSTRAINT `fk_Coleccion_has_Libro_Coleccion1` FOREIGN KEY (`Coleccion_idColeccion`) REFERENCES `coleccion` (`idColeccion`),
  CONSTRAINT `fk_Coleccion_has_Libro_Libro1` FOREIGN KEY (`Libro_idLibro`) REFERENCES `libro` (`idLibro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libroscoleccion`
--

LOCK TABLES `libroscoleccion` WRITE;
/*!40000 ALTER TABLE `libroscoleccion` DISABLE KEYS */;
INSERT INTO `libroscoleccion` VALUES (11,12),(28,13),(31,13),(66,14),(69,14),(21,15),(45,15),(47,15),(45,16),(46,16),(45,17),(48,17),(28,19),(31,19),(61,19),(28,20),(31,20),(18,28),(28,29),(31,29),(9,31),(28,32),(31,32),(53,32),(56,32),(28,34),(31,34),(32,34),(45,34),(46,34),(8,36),(28,36),(71,36),(9,37),(66,37),(69,37),(45,41),(48,41),(66,41),(69,41),(9,44),(15,44),(23,44),(71,44),(31,49),(16,50),(20,54),(28,59),(45,59),(48,59),(28,60),(31,60),(32,60),(66,60),(69,60),(77,60),(18,63),(28,69),(29,69),(64,69),(45,71),(48,71),(28,72),(31,72),(45,81),(48,81),(28,96),(31,96),(28,108),(31,108),(8,109),(22,109),(31,109),(28,111),(30,111),(45,112),(48,112),(49,112),(28,119),(29,119),(45,123),(48,123),(66,156),(69,156);
/*!40000 ALTER TABLE `libroscoleccion` ENABLE KEYS */;
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
