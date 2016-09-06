CREATE DATABASE  IF NOT EXISTS `poupagua_mat` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `poupagua_mat`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: poupagua_mat
-- ------------------------------------------------------
-- Server version	5.7.13-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contato`
--

DROP TABLE IF EXISTS `contato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contato` (
  `ID_CONTATO` int(11) NOT NULL AUTO_INCREMENT,
  `DDD` char(3) DEFAULT NULL,
  `TELEFONE` varchar(9) DEFAULT NULL,
  `EMAIL` varchar(500) DEFAULT NULL,
  `ID_USUARIO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_CONTATO`),
  KEY `ID_USUARIO` (`ID_USUARIO`),
  CONSTRAINT `contato_ibfk_1` FOREIGN KEY (`ID_USUARIO`) REFERENCES `usuario` (`ID_USUARIO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS `endereco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `endereco` (
  `ID_ENDERECO` int(11) NOT NULL AUTO_INCREMENT,
  `LOGRADOURO` varchar(500) DEFAULT NULL,
  `NUMERO` varchar(10) DEFAULT NULL,
  `COMPLEMENTO` varchar(100) DEFAULT NULL,
  `BAIRRO` varchar(200) DEFAULT NULL,
  `MUNICIPIO` varchar(200) DEFAULT NULL,
  `UF` char(2) DEFAULT NULL,
  `CEP` char(9) DEFAULT NULL,
  `TIPO_RESIDENCIA` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_ENDERECO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `residencia`
--

DROP TABLE IF EXISTS `residencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `residencia` (
  `ID_RESIDENCIA` int(11) NOT NULL AUTO_INCREMENT,
  `QTD_MORADORES` int(11) DEFAULT NULL,
  `ID_ENDERECO` int(11) DEFAULT NULL,
  `ID_USUARIO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_RESIDENCIA`),
  KEY `ID_USUARIO` (`ID_USUARIO`),
  KEY `ID_ENDERECO` (`ID_ENDERECO`),
  CONSTRAINT `residencia_ibfk_1` FOREIGN KEY (`ID_USUARIO`) REFERENCES `usuario` (`ID_USUARIO`),
  CONSTRAINT `residencia_ibfk_2` FOREIGN KEY (`ID_ENDERECO`) REFERENCES `endereco` (`ID_ENDERECO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `ID_USUARIO` int(11) NOT NULL AUTO_INCREMENT,
  `NOME` varchar(500) DEFAULT NULL,
  `USER_NAME` varchar(50) DEFAULT NULL,
  `CPF` varchar(100) DEFAULT NULL,
  `SENHA` char(64) DEFAULT NULL,
  `ADMINISTRADOR` int(1) DEFAULT NULL,
  PRIMARY KEY (`ID_USUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-06 19:58:39
