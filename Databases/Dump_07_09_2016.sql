CREATE DATABASE  IF NOT EXISTS `poupaguaz` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `poupaguaz`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: poupaguaz
-- ------------------------------------------------------
-- Server version	5.6.27-log

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
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admin` (
  `USER` varchar(10) NOT NULL,
  `SENHA` varchar(10) NOT NULL,
  `CPF` bigint(11) NOT NULL,
  `DATA_HORA_CAD` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `NOME` varchar(100) NOT NULL,
  `EMAIL` varchar(100) NOT NULL,
  PRIMARY KEY (`USER`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `altera_parm`
--

DROP TABLE IF EXISTS `altera_parm`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `altera_parm` (
  `DATA_HORA` datetime NOT NULL,
  `USER` varchar(10) NOT NULL,
  `ID_PARM` int(11) NOT NULL,
  PRIMARY KEY (`DATA_HORA`),
  KEY `FK_USER` (`USER`),
  KEY `FK_ID_PARM` (`ID_PARM`),
  CONSTRAINT `FK_ID_PARM` FOREIGN KEY (`ID_PARM`) REFERENCES `parametro` (`ID_PARM`),
  CONSTRAINT `FK_USER` FOREIGN KEY (`USER`) REFERENCES `admin` (`USER`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `altera_parm`
--

LOCK TABLES `altera_parm` WRITE;
/*!40000 ALTER TABLE `altera_parm` DISABLE KEYS */;
/*!40000 ALTER TABLE `altera_parm` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `caixa_dagua`
--

DROP TABLE IF EXISTS `caixa_dagua`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `caixa_dagua` (
  `ID_CAIXA` int(5) NOT NULL AUTO_INCREMENT,
  `CAPACIDADE` int(10) NOT NULL,
  `MODELO` varchar(100) NOT NULL,
  `FABRICANTE` varchar(100) NOT NULL,
  PRIMARY KEY (`ID_CAIXA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caixa_dagua`
--

LOCK TABLES `caixa_dagua` WRITE;
/*!40000 ALTER TABLE `caixa_dagua` DISABLE KEYS */;
/*!40000 ALTER TABLE `caixa_dagua` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comentario`
--

DROP TABLE IF EXISTS `comentario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comentario` (
  `EMAIL` varchar(100) NOT NULL,
  `DATA_HORA` datetime NOT NULL,
  `NOME` varchar(100) NOT NULL,
  `OPINIAO` varchar(600) NOT NULL,
  PRIMARY KEY (`EMAIL`,`DATA_HORA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comentario`
--

LOCK TABLES `comentario` WRITE;
/*!40000 ALTER TABLE `comentario` DISABLE KEYS */;
/*!40000 ALTER TABLE `comentario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comunicacao`
--

DROP TABLE IF EXISTS `comunicacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comunicacao` (
  `ID` int(5) NOT NULL AUTO_INCREMENT,
  `DESTINATARIO` varchar(100) NOT NULL,
  `MENSAGEM` varchar(600) NOT NULL,
  `TIPO` char(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comunicacao`
--

LOCK TABLES `comunicacao` WRITE;
/*!40000 ALTER TABLE `comunicacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `comunicacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS `endereco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `endereco` (
  `CEP` bigint(8) NOT NULL,
  `LOGRADOURO` varchar(300) NOT NULL,
  `BAIRRO` varchar(100) NOT NULL,
  `CIDADE` varchar(100) NOT NULL,
  `ESTADO` varchar(2) NOT NULL,
  PRIMARY KEY (`CEP`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endereco`
--

LOCK TABLES `endereco` WRITE;
/*!40000 ALTER TABLE `endereco` DISABLE KEYS */;
/*!40000 ALTER TABLE `endereco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fornecedor`
--

DROP TABLE IF EXISTS `fornecedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedor` (
  `CNPJ` bigint(14) NOT NULL,
  `RAZAO_SOCIAL` varchar(100) NOT NULL,
  PRIMARY KEY (`CNPJ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fornecedor`
--

LOCK TABLES `fornecedor` WRITE;
/*!40000 ALTER TABLE `fornecedor` DISABLE KEYS */;
/*!40000 ALTER TABLE `fornecedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parametro`
--

DROP TABLE IF EXISTS `parametro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parametro` (
  `ID_PARM` int(2) NOT NULL,
  `DESCRICAO` varchar(100) NOT NULL,
  `VALOR` int(5) NOT NULL,
  PRIMARY KEY (`ID_PARM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parametro`
--

LOCK TABLES `parametro` WRITE;
/*!40000 ALTER TABLE `parametro` DISABLE KEYS */;
/*!40000 ALTER TABLE `parametro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `residencia`
--

DROP TABLE IF EXISTS `residencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `residencia` (
  `HIDROMETRO` bigint(10) NOT NULL,
  `QTDE_MORADOR` int(2) NOT NULL,
  `IN_CADASTRO` char(1) NOT NULL DEFAULT 'N',
  `CEP` bigint(8) NOT NULL,
  `NUMERO` varchar(10) NOT NULL,
  `COMPLEMENTO` varchar(100) NOT NULL,
  `ID_CAIXA` int(5) NOT NULL,
  `IP` varchar(15) DEFAULT NULL,
  `CPF` bigint(11) NOT NULL,
  PRIMARY KEY (`HIDROMETRO`),
  KEY `FK_CEP` (`CEP`),
  KEY `FK_ID_CAIXA` (`ID_CAIXA`),
  KEY `FK_USER_CPF` (`CPF`),
  CONSTRAINT `FK_CEP` FOREIGN KEY (`CEP`) REFERENCES `endereco` (`CEP`),
  CONSTRAINT `FK_ID_CAIXA` FOREIGN KEY (`ID_CAIXA`) REFERENCES `caixa_dagua` (`ID_CAIXA`),
  CONSTRAINT `FK_USER_CPF` FOREIGN KEY (`CPF`) REFERENCES `usuario` (`CPF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `residencia`
--

LOCK TABLES `residencia` WRITE;
/*!40000 ALTER TABLE `residencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `residencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telefones_admin`
--

DROP TABLE IF EXISTS `telefones_admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefones_admin` (
  `USER` varchar(10) NOT NULL,
  `TELEFONE` varchar(11) NOT NULL,
  PRIMARY KEY (`USER`,`TELEFONE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telefones_admin`
--

LOCK TABLES `telefones_admin` WRITE;
/*!40000 ALTER TABLE `telefones_admin` DISABLE KEYS */;
/*!40000 ALTER TABLE `telefones_admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telefones_fornec`
--

DROP TABLE IF EXISTS `telefones_fornec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefones_fornec` (
  `CNPJ` varchar(10) NOT NULL,
  `TELEFONE` varchar(11) NOT NULL,
  PRIMARY KEY (`CNPJ`,`TELEFONE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telefones_fornec`
--

LOCK TABLES `telefones_fornec` WRITE;
/*!40000 ALTER TABLE `telefones_fornec` DISABLE KEYS */;
/*!40000 ALTER TABLE `telefones_fornec` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `CPF` bigint(11) NOT NULL,
  `TELEFONE` varchar(11) NOT NULL,
  `NOME` varchar(100) NOT NULL,
  `EMAIL` varchar(100) NOT NULL,
  `DATA_HORA_CAD` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `USER` varchar(10) NOT NULL,
  `SENHA` varchar(10) NOT NULL,
  PRIMARY KEY (`CPF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'poupaguaz'
--

--
-- Dumping routines for database 'poupaguaz'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-09-07 11:12:56
