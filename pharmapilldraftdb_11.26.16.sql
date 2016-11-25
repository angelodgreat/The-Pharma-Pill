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
INSERT INTO `brandnameinphtable` VALUES ('Analgesic/Antipyretics','Aspirin');
/*!40000 ALTER TABLE `brandnameinphtable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drugs`
--

DROP TABLE IF EXISTS `drugs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `drugs` (
  `drugfor` text NOT NULL,
  `drugclassification` text NOT NULL,
  `drugname` varchar(255) NOT NULL,
  `indication` text,
  `contraindication` text,
  `specialprecautions` text,
  `sideeffects` text,
  `druginteraction` text,
  `dosinginformation` text,
  `adultdose` text,
  `childrendose` text,
  PRIMARY KEY (`drugname`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drugs`
--

LOCK TABLES `drugs` WRITE;
/*!40000 ALTER TABLE `drugs` DISABLE KEYS */;
INSERT INTO `drugs` VALUES ('Pain and Fever','','Analgesic/Antipyretics','- Prophylaxis of thromboemobolic disorders in preventing myocardial infarction and transient ischemic attacks. \r\n\r\n- Provides quick relief of headache, rheumatism, muscular pains, toothache, neuralgia, periodic pains\r\n\r\n- Reduces fever and discomforts in colds and flu. \r\n','- History of salicylate-induced asthma.\r\n- Active peptic ulcers\r\n- Hemorrhagic diathesis\r\n- severe renal or cardiac failure\r\n- Combination with methotrexate at doses of > or = 15mg/week\r\n','- Renal disorders\r\n- G6PD deficiency\r\n- Patients with flu, chicken pox, or hemorrhagic fever, GI ulceration or asthma\r\n- Pregnant women close to delivery.\r\n','- Gastric hemorrhage\r\n- Hypersensitivity\r\n- Thrombocytopenia\r\n','- Methotrexate\r\n- Anticoagulants\r\n- Thrombolytics and other anti platelets\r\n- Uricosuric drugs\r\n- Digoxin\r\n- Antidiabetics\r\n- Diuretics\r\n- systemic glucocorticoids EXCEPT Hydrocortisone\r\n- ACE inhibitors\r\n- Valproic acid\r\n- Alcohol\r\n','Adult','- 100mg tab (Prophylaxis of thromboembolic disorders) 1 tab daily\r\n- 300mg tab (Pain) 1 to 2 tabs. Repeat after 3 to 4 hours, as needed. \r\n','- (>5y/o) 1 tablet\r\n- (3 to 5 y/o) 1/2 tablet\r\n***Repeat if necessary BUT is not taken >3 times daily.\r\n'),('Cough','','Expectorant Guaifenesin','Expectorant; increase the bronchial secretion and enhance the expulsion of mucus by air passages of the lungs.','Hypersensitivity to the active ingredient.','Persistent cough (e.g. occurs with smoking, asthma, chronic bronchitis, or emphysema); cough accompanied by excessive secretions; cough with a fever, rash, or persistent headache; Pregnancy, lactation. Porphyria.','GI discomfort, nausea and vomiting; dizziness, drowsiness, headache; rash; decreased uric acid levels; urinary calculi (large doses).','n/a','Adult','200-400 mg every 4 hr. Max: 2.4 g/day.','6-12 yr: 100-200 mg; 2-6 yr: 50-100 mg; 6 mth-2 yr: 25-50 mg. To be given every 4 hr. Max: 6-12 yr: 1.2 g/day; 2-5 yr: 600 mg/day.'),('Cough','','Mucolytics','as a mucolytic; make the mucus (sputum) less thick and sticky and easier to cough up.','Active peptic ulceration','History of peptic ulcer disease','- nausea			\r\n- gastric discomfort\r\n- gastrointestinal bleeding	\r\n- skin rash\r\n- Stevens-Johnson syndrome\r\n- erythema multiforme\r\n','n/a','Adult','INITIALLY, 2.25 g daily in divided doses, THEN, 1.5 g daily in \r\n  			divided doses as condition improves.\r\n','2-5 yrs	       62.5 -125 mg four times a day						6-12 yrs  	250 mg thrice a day');
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

-- Dump completed on 2016-11-26  4:38:05
