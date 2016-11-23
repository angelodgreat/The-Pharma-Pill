CREATE DATABASE  IF NOT EXISTS `thepharmapill` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `thepharmapill`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: thepharmapill
-- ------------------------------------------------------
-- Server version	5.7.9-log

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
-- Table structure for table `brandnameinphtable`
--

DROP TABLE IF EXISTS `brandnameinphtable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `brandnameinphtable` (
  `drugname` varchar(255) NOT NULL,
  `brandnameintheph` text,
  KEY `fk_drugname_idx` (`drugname`),
  CONSTRAINT `fk_drugname` FOREIGN KEY (`drugname`) REFERENCES `drugs` (`drugname`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brandnameinphtable`
--

LOCK TABLES `brandnameinphtable` WRITE;
/*!40000 ALTER TABLE `brandnameinphtable` DISABLE KEYS */;
/*!40000 ALTER TABLE `brandnameinphtable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dosinginformationtable`
--

DROP TABLE IF EXISTS `dosinginformationtable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dosinginformationtable` (
  `drugname` varchar(255) NOT NULL,
  `adult` text,
  `children` text,
  KEY `fk_dosinginfo_idx` (`drugname`),
  CONSTRAINT `fk_dosinginfo` FOREIGN KEY (`drugname`) REFERENCES `drugs` (`drugname`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dosinginformationtable`
--

LOCK TABLES `dosinginformationtable` WRITE;
/*!40000 ALTER TABLE `dosinginformationtable` DISABLE KEYS */;
/*!40000 ALTER TABLE `dosinginformationtable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drugs`
--

DROP TABLE IF EXISTS `drugs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `drugs` (
  `drugname` varchar(255) NOT NULL,
  `indication` text,
  `contraindication` text,
  `specialprecautions` text,
  `sideeffects` text,
  `druginteraction` text,
  PRIMARY KEY (`drugname`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drugs`
--

LOCK TABLES `drugs` WRITE;
/*!40000 ALTER TABLE `drugs` DISABLE KEYS */;
/*!40000 ALTER TABLE `drugs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-23 21:42:30
