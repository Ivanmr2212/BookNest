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
-- Table structure for table `nota`
--

DROP TABLE IF EXISTS `nota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nota` (
  `idNota` int NOT NULL AUTO_INCREMENT,
  `titulo` varchar(45) DEFAULT NULL,
  `texto` varchar(255) DEFAULT NULL,
  `fecha` varchar(45) DEFAULT NULL,
  `Categoria_idCategoria` int NOT NULL,
  `Libro_idLibro` int NOT NULL,
  `Usuario_idUsuario` int NOT NULL,
  PRIMARY KEY (`idNota`),
  KEY `fk_Nota_Categoria1_idx` (`Categoria_idCategoria`),
  KEY `fk_Nota_Libro1_idx` (`Libro_idLibro`),
  KEY `fk_Nota_Usuario1_idx` (`Usuario_idUsuario`),
  CONSTRAINT `fk_Nota_Categoria1` FOREIGN KEY (`Categoria_idCategoria`) REFERENCES `categoria` (`idCategoria`),
  CONSTRAINT `fk_Nota_Libro1` FOREIGN KEY (`Libro_idLibro`) REFERENCES `libro` (`idLibro`),
  CONSTRAINT `fk_Nota_Usuario1` FOREIGN KEY (`Usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nota`
--

LOCK TABLES `nota` WRITE;
/*!40000 ALTER TABLE `nota` DISABLE KEYS */;
INSERT INTO `nota` VALUES (1,'Nota Ej1','Ejemplo','06/04/2025 18:57:54',1,25,8),(2,'Jaimie Lannister','El kingslayer','06/04/2025 19:10:13',2,44,8),(3,'Worldbuilding1','Texto de ejemplo','07/04/2025 7:47:18',1,44,8),(4,'Momento1','Ejemplo de Nota','07/04/2025 7:56:29',3,31,7),(5,'Nota Ej','Ejemplo de texto','09/04/2025 8:13:25',4,158,8),(6,'Ejemplo','TExto ejmplo','09/04/2025 9:57:55',4,11,8),(10,'Nota4','','16/04/2025 16:53:47',6,49,10),(11,'Nota5','','16/04/2025 16:53:54',7,49,10),(12,'Nota6','','16/04/2025 16:56:42',6,49,10),(14,'NotaEj','Ejemplo','22/04/2025 9:32:02',6,93,10),(15,'Primeras 200 pags','Me está gustando mucho','22/04/2025 12:20:10',5,59,10),(16,'Teoría 1','No se que va a pasar','22/04/2025 9:47:42',7,111,10),(17,'Teorías en general','No se que va a pasar','22/04/2025 11:45:41',7,13,10),(18,'Traspié','Le pasa de todo al pobre. Modificación','22/04/2025 11:51:02',5,34,10),(19,'Nota1.1','Texto de ejemplo 1.1','22/04/2025 23:42:58',5,144,10),(21,'Resumen general','Me ha gustado mucho el libro porque es maravilloso','29/05/2025 8:51:22',6,32,10),(23,'1ras impresiones','Tengo ganas','01/06/2025 13:01:55',14,123,1002),(24,'1ra teoria','No se que va a a pasar','01/06/2025 15:41:20',16,17,1002),(25,'1ras impresiones','Me ha gustado','01/06/2025 15:51:01',14,41,1002),(26,'1er capitulo','Me está gustando','01/06/2025 15:54:12',14,81,1002),(27,'Dalinar','Me gusta mucho','01/06/2025 16:15:53',29,20,10);
/*!40000 ALTER TABLE `nota` ENABLE KEYS */;
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
