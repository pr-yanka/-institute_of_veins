-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: med_db
-- ------------------------------------------------------
-- Server version	5.7.20-log

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
-- Table structure for table `а`
--

DROP TABLE IF EXISTS `а`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `а` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `буквы` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `А_fk0` (`буквы`),
  CONSTRAINT `А_fk0` FOREIGN KEY (`буквы`) REFERENCES `анатомическая_локализация_заболевания` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `аккаунты`
--

DROP TABLE IF EXISTS `аккаунты`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `аккаунты` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `роль` int(11) NOT NULL,
  `врач` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `аккаунты_fk0` (`роль`),
  KEY `аккаунты_fk1` (`врач`),
  CONSTRAINT `аккаунты_fk0` FOREIGN KEY (`роль`) REFERENCES `виды_ролей` (`id`),
  CONSTRAINT `аккаунты_fk1` FOREIGN KEY (`врач`) REFERENCES `врачи` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `анализы`
--

DROP TABLE IF EXISTS `анализы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `анализы` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `тип_анализа` int(11) NOT NULL,
  `дата` date NOT NULL,
  `id_пациента` int(11) NOT NULL,
  `анализ` longblob NOT NULL,
  PRIMARY KEY (`id`),
  KEY `анализы_fk0` (`тип_анализа`),
  KEY `анализы_fk1` (`id_пациента`),
  CONSTRAINT `анализы_fk0` FOREIGN KEY (`тип_анализа`) REFERENCES `виды_анализа` (`id`),
  CONSTRAINT `анализы_fk1` FOREIGN KEY (`id_пациента`) REFERENCES `пациент` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8 COLLATE=utf8_esperanto_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `анатомическая_локализация_заболевания`
--

DROP TABLE IF EXISTS `анатомическая_локализация_заболевания`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `анатомическая_локализация_заболевания` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(5) NOT NULL,
  `описание` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бедренное_продолжение_малой_подкожной_вены`
--

DROP TABLE IF EXISTS `бедренное_продолжение_малой_подкожной_вены`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бедренное_продолжение_малой_подкожной_вены` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_хода_ФФ` int(11) DEFAULT NULL,
  `протяженность_ФФ` float DEFAULT NULL,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Бедренное_продолжение_малой_подкожной_вены_fk0` (`id_хода_ФФ`),
  KEY `Бедренное_продолжение_малой_подкожной_вены_fk1` (`подзапись1`),
  KEY `Бедренное_продолжение_малой_подкожной_вены_fk2` (`подзапись2`),
  KEY `Бедренное_продолжение_малой_подкожной_вены_fk3` (`подзапись3`),
  CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk0` FOREIGN KEY (`id_хода_ФФ`) REFERENCES `ход_в_фасциальном_футляре` (`id`),
  CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk1` FOREIGN KEY (`подзапись1`) REFERENCES `те_мпв_подзапись` (`id`),
  CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk2` FOREIGN KEY (`подзапись2`) REFERENCES `те_мпв_подзапись` (`id`),
  CONSTRAINT `Бедренное_продолжение_малой_подкожной_вены_fk3` FOREIGN KEY (`подзапись3`) REFERENCES `те_мпв_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `большая_подкожная_вена_на_бедре`
--

DROP TABLE IF EXISTS `большая_подкожная_вена_на_бедре`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `большая_подкожная_вена_на_бедре` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_хода` int(11) NOT NULL,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  `подзапись4` int(11) DEFAULT NULL,
  `подзапись5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `большая_подкожная_вена_на_бедре_fk0` (`id_хода`),
  KEY `большая_подкожная_вена_на_бедре_fk1` (`подзапись1`),
  KEY `большая_подкожная_вена_на_бедре_fk2` (`подзапись2`),
  KEY `большая_подкожная_вена_на_бедре_fk3` (`подзапись3`),
  KEY `большая_подкожная_вена_на_бедре_fk4` (`подзапись4`),
  KEY `большая_подкожная_вена_на_бедре_fk5` (`подзапись5`),
  CONSTRAINT `большая_подкожная_вена_на_бедре_fk0` FOREIGN KEY (`id_хода`) REFERENCES `вид_бпв_хода` (`id_вида`),
  CONSTRAINT `большая_подкожная_вена_на_бедре_fk1` FOREIGN KEY (`подзапись1`) REFERENCES `бпв_на_бедре_подзапись` (`id`),
  CONSTRAINT `большая_подкожная_вена_на_бедре_fk2` FOREIGN KEY (`подзапись2`) REFERENCES `бпв_на_бедре_подзапись` (`id`),
  CONSTRAINT `большая_подкожная_вена_на_бедре_fk3` FOREIGN KEY (`подзапись3`) REFERENCES `бпв_на_бедре_подзапись` (`id`),
  CONSTRAINT `большая_подкожная_вена_на_бедре_fk4` FOREIGN KEY (`подзапись4`) REFERENCES `бпв_на_бедре_подзапись` (`id`),
  CONSTRAINT `большая_подкожная_вена_на_бедре_fk5` FOREIGN KEY (`подзапись5`) REFERENCES `бпв_на_бедре_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бпв_на_бедре_комбо`
--

DROP TABLE IF EXISTS `бпв_на_бедре_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бпв_на_бедре_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  `структура4` int(11) DEFAULT NULL,
  `структура5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `БПВ_на_бедре_комбо_fk0` (`структура1`),
  KEY `БПВ_на_бедре_комбо_fk1` (`структура2`),
  KEY `БПВ_на_бедре_комбо_fk2` (`структура3`),
  KEY `БПВ_на_бедре_комбо_fk3` (`структура4`),
  KEY `БПВ_на_бедре_комбо_fk4` (`структура5`),
  CONSTRAINT `БПВ_на_бедре_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `бпв_на_бедре_структура` (`id`),
  CONSTRAINT `БПВ_на_бедре_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `бпв_на_бедре_структура` (`id`),
  CONSTRAINT `БПВ_на_бедре_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `бпв_на_бедре_структура` (`id`),
  CONSTRAINT `БПВ_на_бедре_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `бпв_на_бедре_структура` (`id`),
  CONSTRAINT `БПВ_на_бедре_комбо_fk4` FOREIGN KEY (`структура5`) REFERENCES `бпв_на_бедре_структура` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бпв_на_бедре_подзапись`
--

DROP TABLE IF EXISTS `бпв_на_бедре_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бпв_на_бедре_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(50) DEFAULT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `БПВ_на_бедре_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `БПВ_на_бедре_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `бпв_на_бедре_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бпв_на_бедре_структура`
--

DROP TABLE IF EXISTS `бпв_на_бедре_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бпв_на_бедре_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `БПВ_на_бедре_структура_fk0` (`id_метрики`),
  CONSTRAINT `БПВ_на_бедре_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бпв_на_голени`
--

DROP TABLE IF EXISTS `бпв_на_голени`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бпв_на_голени` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  `подзапись4` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `БПВ_на_голени_fk0` (`подзапись1`),
  KEY `БПВ_на_голени_fk1` (`подзапись2`),
  KEY `БПВ_на_голени_fk2` (`подзапись3`),
  KEY `БПВ_на_голени_fk3` (`подзапись4`),
  CONSTRAINT `БПВ_на_голени_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `бпв_на_голени_подзапись` (`id`),
  CONSTRAINT `БПВ_на_голени_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `бпв_на_голени_подзапись` (`id`),
  CONSTRAINT `БПВ_на_голени_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `бпв_на_голени_подзапись` (`id`),
  CONSTRAINT `БПВ_на_голени_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `бпв_на_голени_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бпв_на_голени_комбо`
--

DROP TABLE IF EXISTS `бпв_на_голени_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бпв_на_голени_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  `структура4` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `БПВ_на_голени_комбо_fk0` (`структура1`),
  KEY `БПВ_на_голени_комбо_fk1` (`структура2`),
  KEY `БПВ_на_голени_комбо_fk2` (`структура3`),
  KEY `БПВ_на_голени_комбо_fk3` (`структура4`),
  CONSTRAINT `БПВ_на_голени_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `бпв_на_голени_структура` (`id`),
  CONSTRAINT `БПВ_на_голени_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `бпв_на_голени_структура` (`id`),
  CONSTRAINT `БПВ_на_голени_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `бпв_на_голени_структура` (`id`),
  CONSTRAINT `БПВ_на_голени_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `бпв_на_голени_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бпв_на_голени_подзапись`
--

DROP TABLE IF EXISTS `бпв_на_голени_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бпв_на_голени_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) NOT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `БПВ_на_голени_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `БПВ_на_голени_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `бпв_на_голени_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бпв_на_голени_структура`
--

DROP TABLE IF EXISTS `бпв_на_голени_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бпв_на_голени_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `БПВ_на_голени_структура_fk0` (`id_метрики`),
  CONSTRAINT `БПВ_на_голени_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `бригада`
--

DROP TABLE IF EXISTS `бригада`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `бригада` (
  `id_врача` int(11) NOT NULL,
  `id_операции` int(11) NOT NULL,
  PRIMARY KEY (`id_врача`,`id_операции`),
  KEY `бригада_fk1` (`id_операции`),
  CONSTRAINT `бригада_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи` (`id`),
  CONSTRAINT `бригада_fk1` FOREIGN KEY (`id_операции`) REFERENCES `операции` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ход_в_фасциальном_футляре`
--

DROP TABLE IF EXISTS `ход_в_фасциальном_футляре`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ход_в_фасциальном_футляре` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(40) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_анализа`
--

DROP TABLE IF EXISTS `виды_анализа`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_анализа` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_анестезика`
--

DROP TABLE IF EXISTS `виды_анестезика`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_анестезика` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_жалоб`
--

DROP TABLE IF EXISTS `виды_жалоб`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_жалоб` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_изменений`
--

DROP TABLE IF EXISTS `виды_изменений`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_изменений` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_категории`
--

DROP TABLE IF EXISTS `виды_категории`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_категории` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_научных_званий`
--

DROP TABLE IF EXISTS `виды_научных_званий`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_научных_званий` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_операции`
--

DROP TABLE IF EXISTS `виды_операции`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_операции` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `короткое_название` varchar(20) NOT NULL,
  `длинное_название` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_патологий`
--

DROP TABLE IF EXISTS `виды_патологий`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_патологий` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(150) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_рекомендаций`
--

DROP TABLE IF EXISTS `виды_рекомендаций`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_рекомендаций` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_ролей`
--

DROP TABLE IF EXISTS `виды_ролей`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_ролей` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `виды_специализаций`
--

DROP TABLE IF EXISTS `виды_специализаций`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `виды_специализаций` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `вид_бпв_хода`
--

DROP TABLE IF EXISTS `вид_бпв_хода`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `вид_бпв_хода` (
  `id_вида` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(40) NOT NULL,
  PRIMARY KEY (`id_вида`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `вид_диагноз`
--

DROP TABLE IF EXISTS `вид_диагноз`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `вид_диагноз` (
  `id_вида` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(200) NOT NULL,
  PRIMARY KEY (`id_вида`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `вид_мпв_хода`
--

DROP TABLE IF EXISTS `вид_мпв_хода`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `вид_мпв_хода` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(40) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `врачи`
--

DROP TABLE IF EXISTS `врачи`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `врачи` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `имя` varchar(20) NOT NULL,
  `фамилия` varchar(40) NOT NULL,
  `отчество` varchar(40) NOT NULL,
  `дополнительно` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `врачи_специализации`
--

DROP TABLE IF EXISTS `врачи_специализации`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `врачи_специализации` (
  `id_врача` int(11) NOT NULL,
  `id_специлизации` int(11) NOT NULL,
  PRIMARY KEY (`id_врача`,`id_специлизации`),
  KEY `врачи_специализации_fk1` (`id_специлизации`),
  CONSTRAINT `врачи_специализации_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи` (`id`),
  CONSTRAINT `врачи_специализации_fk1` FOREIGN KEY (`id_специлизации`) REFERENCES `виды_специализаций111` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `диагноз`
--

DROP TABLE IF EXISTS `диагноз`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `диагноз` (
  `id_диагноз` int(11) NOT NULL,
  `id_операции` int(11) NOT NULL,
  `isLeft` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_диагноз`,`id_операции`,`isLeft`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `диагноз_обследование`
--

DROP TABLE IF EXISTS `диагноз_обследование`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `диагноз_обследование` (
  `id_обследование_ноги` int(11) DEFAULT NULL,
  `id_диагноз` int(11) DEFAULT NULL,
  `isLeft` tinyint(1) DEFAULT NULL,
  KEY `диагноз_обследование` (`id_обследование_ноги`),
  CONSTRAINT `диагноз_обследование` FOREIGN KEY (`id_обследование_ноги`) REFERENCES `обследование_ноги` (`id_обследования`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `е`
--

DROP TABLE IF EXISTS `е`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `е` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `буквы` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Е_fk0` (`буквы`),
  CONSTRAINT `Е_fk0` FOREIGN KEY (`буквы`) REFERENCES `этиология_заболевания` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `жалобы`
--

DROP TABLE IF EXISTS `жалобы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `жалобы` (
  `id_обследования` int(11) NOT NULL,
  `id_жалобы` int(11) NOT NULL,
  PRIMARY KEY (`id_обследования`,`id_жалобы`),
  KEY `жалобы_fk1` (`id_жалобы`),
  CONSTRAINT `жалобы_fk0` FOREIGN KEY (`id_обследования`) REFERENCES `обследование` (`id`),
  CONSTRAINT `жалобы_fk1` FOREIGN KEY (`id_жалобы`) REFERENCES `виды_жалоб` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `задняя_добавочная_сафенная_вена`
--

DROP TABLE IF EXISTS `задняя_добавочная_сафенная_вена`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `задняя_добавочная_сафенная_вена` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `задняя_добавочная_сафенная_вена_fk0` (`подзапись1`),
  KEY `задняя_добавочная_сафенная_вена_fk1` (`подзапись2`),
  KEY `задняя_добавочная_сафенная_вена_fk2` (`подзапись3`),
  CONSTRAINT `задняя_добавочная_сафенная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `здсв_подзапись` (`id`),
  CONSTRAINT `задняя_добавочная_сафенная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `здсв_подзапись` (`id`),
  CONSTRAINT `задняя_добавочная_сафенная_вена_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `здсв_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `звания`
--

DROP TABLE IF EXISTS `звания`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `звания` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `здсв_комбо`
--

DROP TABLE IF EXISTS `здсв_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `здсв_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ЗДСВ_комбо_fk0` (`структура1`),
  KEY `ЗДСВ_комбо_fk1` (`структура2`),
  KEY `ЗДСВ_комбо_fk2` (`структура3`),
  CONSTRAINT `ЗДСВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `здсв_структура` (`id`),
  CONSTRAINT `ЗДСВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `здсв_структура` (`id`),
  CONSTRAINT `ЗДСВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `здсв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `здсв_подзапись`
--

DROP TABLE IF EXISTS `здсв_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `здсв_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) NOT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ЗДСВ_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `ЗДСВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `здсв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `здсв_структура`
--

DROP TABLE IF EXISTS `здсв_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `здсв_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `есть_метрика` tinyint(1) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ЗДСВ_структура_fk0` (`id_метрики`),
  CONSTRAINT `ЗДСВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `история_изменений`
--

DROP TABLE IF EXISTS `история_изменений`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `история_изменений` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_аккаунта` int(11) NOT NULL,
  `название_таблицы` varchar(50) NOT NULL,
  `название_столбца` varchar(50) NOT NULL,
  `дата_изменения` datetime NOT NULL,
  `старое_значение` varchar(200) DEFAULT NULL,
  `новое_значение` varchar(200) DEFAULT NULL,
  `тип_изменения` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `история_изменений_fk0` (`id_аккаунта`),
  KEY `история_изменений_fk1` (`тип_изменения`),
  CONSTRAINT `история_изменений_fk0` FOREIGN KEY (`id_аккаунта`) REFERENCES `аккаунты` (`id`),
  CONSTRAINT `история_изменений_fk1` FOREIGN KEY (`тип_изменения`) REFERENCES `виды_изменений` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `итоги_операции`
--

DROP TABLE IF EXISTS `итоги_операции`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `итоги_операции` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `описание` varchar(200) NOT NULL,
  `id_следущей_операции` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `итоги_операции_fk0` (`id_следущей_операции`),
  CONSTRAINT `итоги_операции_fk0` FOREIGN KEY (`id_следущей_операции`) REFERENCES `операции` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `этиология_заболевания`
--

DROP TABLE IF EXISTS `этиология_заболевания`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `этиология_заболевания` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(5) NOT NULL,
  `описание` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `категории`
--

DROP TABLE IF EXISTS `категории`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `категории` (
  `id_категории` int(11) NOT NULL,
  `id_врача` int(11) NOT NULL,
  PRIMARY KEY (`id_категории`,`id_врача`),
  KEY `категории_fk0` (`id_врача`),
  CONSTRAINT `категории_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `малая_подкожная_вена`
--

DROP TABLE IF EXISTS `малая_подкожная_вена`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `малая_подкожная_вена` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  `подзапись4` int(11) DEFAULT NULL,
  `вид_хода` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Малая_подкожная_вена_fk0` (`подзапись1`),
  KEY `Малая_подкожная_вена_fk1` (`подзапись2`),
  KEY `Малая_подкожная_вена_fk2` (`подзапись3`),
  KEY `Малая_подкожная_вена_fk3` (`подзапись4`),
  KEY `Малая_подкожная_вена_fk4` (`вид_хода`),
  CONSTRAINT `Малая_подкожная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `мпв_подзапись` (`id`),
  CONSTRAINT `Малая_подкожная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `мпв_подзапись` (`id`),
  CONSTRAINT `Малая_подкожная_вена_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `мпв_подзапись` (`id`),
  CONSTRAINT `Малая_подкожная_вена_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `мпв_подзапись` (`id`),
  CONSTRAINT `Малая_подкожная_вена_fk4` FOREIGN KEY (`вид_хода`) REFERENCES `вид_мпв_хода` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `метрика`
--

DROP TABLE IF EXISTS `метрика`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `метрика` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `мпв_комбо`
--

DROP TABLE IF EXISTS `мпв_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `мпв_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  `структура4` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `МПВ_комбо_fk0` (`структура1`),
  KEY `МПВ_комбо_fk1` (`структура2`),
  KEY `МПВ_комбо_fk2` (`структура3`),
  KEY `МПВ_комбо_fk3` (`структура4`),
  CONSTRAINT `МПВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `мпв_структура` (`id`),
  CONSTRAINT `МПВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `мпв_структура` (`id`),
  CONSTRAINT `МПВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `мпв_структура` (`id`),
  CONSTRAINT `МПВ_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `мпв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `мпв_подзапись`
--

DROP TABLE IF EXISTS `мпв_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `мпв_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `МПВ_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `МПВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `мпв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `мпв_структура`
--

DROP TABLE IF EXISTS `мпв_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `мпв_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `МПВ_структура_fk0` (`id_метрики`),
  CONSTRAINT `МПВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `научные_звания`
--

DROP TABLE IF EXISTS `научные_звания`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `научные_звания` (
  `id_звания` int(11) NOT NULL,
  `id_врача` int(11) NOT NULL,
  PRIMARY KEY (`id_звания`,`id_врача`),
  KEY `научные_звания_fk0` (`id_врача`),
  CONSTRAINT `научные_звания_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи` (`id`),
  CONSTRAINT `научные_звания_fk1` FOREIGN KEY (`id_звания`) REFERENCES `виды_научных_званий` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `обследование`
--

DROP TABLE IF EXISTS `обследование`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `обследование` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_пациента` int(11) NOT NULL,
  `дата_обследования` date NOT NULL,
  `вес` float NOT NULL,
  `рост` float NOT NULL,
  `id_обследования_правой_ноги` int(11) NOT NULL,
  `id_обследования_левой_ноги` int(11) NOT NULL,
  `id_врача` int(11) DEFAULT NULL,
  `NB!` varchar(60) DEFAULT NULL,
  `нужна_операция` tinyint(1) NOT NULL,
  `вид_операции` int(11) DEFAULT NULL,
  `комментарий_к_операции` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `обследование_fk0` (`id_пациента`),
  KEY `обследование_fk1` (`id_обследования_правой_ноги`),
  KEY `обследование_fk2` (`id_обследования_левой_ноги`),
  KEY `обследование_fk3` (`вид_операции`),
  CONSTRAINT `обследование_fk0` FOREIGN KEY (`id_пациента`) REFERENCES `пациент` (`id`),
  CONSTRAINT `обследование_fk1` FOREIGN KEY (`id_обследования_правой_ноги`) REFERENCES `обследование_ноги` (`id_обследования`),
  CONSTRAINT `обследование_fk2` FOREIGN KEY (`id_обследования_левой_ноги`) REFERENCES `обследование_ноги` (`id_обследования`),
  CONSTRAINT `обследование_fk3` FOREIGN KEY (`вид_операции`) REFERENCES `виды_операции` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `обследование_ноги`
--

DROP TABLE IF EXISTS `обследование_ноги`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `обследование_ноги` (
  `id_обследования` int(11) NOT NULL AUTO_INCREMENT,
  `id_СФС` int(11) NOT NULL,
  `id_БПВ_на_бедре` int(11) NOT NULL,
  `id_ПДСВ` int(11) DEFAULT NULL,
  `id_ЗДСВ` int(11) DEFAULT NULL,
  `id_перфоранты_бедра` int(11) NOT NULL,
  `id_БПВ_на_голени` int(11) NOT NULL,
  `id_перфорант_голени` int(11) DEFAULT NULL,
  `id_СПС` int(11) NOT NULL,
  `id_МПВ` int(11) NOT NULL,
  `id_ТЕ_МПВ` int(11) DEFAULT NULL,
  `id_ППВ` int(11) DEFAULT NULL,
  `Примечание` varchar(300) DEFAULT NULL,
  `id_глубокие_вены` int(11) DEFAULT NULL,
  `C` int(11) NOT NULL,
  `E` int(11) NOT NULL,
  `A` int(11) NOT NULL,
  `P` int(11) NOT NULL,
  PRIMARY KEY (`id_обследования`),
  UNIQUE KEY `id_СФС` (`id_СФС`),
  UNIQUE KEY `id_БПВ_на_бедре` (`id_БПВ_на_бедре`),
  UNIQUE KEY `id_перфоранты_бедра` (`id_перфоранты_бедра`),
  UNIQUE KEY `id_БПВ_на_голени` (`id_БПВ_на_голени`),
  UNIQUE KEY `id_СПС` (`id_СПС`),
  UNIQUE KEY `id_МПВ` (`id_МПВ`),
  UNIQUE KEY `id_ПДСВ` (`id_ПДСВ`),
  UNIQUE KEY `id_ЗДСВ` (`id_ЗДСВ`),
  UNIQUE KEY `id_перфорант_голени` (`id_перфорант_голени`),
  UNIQUE KEY `id_ТЕ_МПВ` (`id_ТЕ_МПВ`),
  UNIQUE KEY `id_ППВ` (`id_ППВ`),
  UNIQUE KEY `id_глубокие_вены` (`id_глубокие_вены`),
  KEY `обследование_ноги_fk11` (`C`),
  KEY `обследование_ноги_fk12` (`E`),
  KEY `обследование_ноги_fk13` (`A`),
  KEY `обследование_ноги_fk14` (`P`),
  CONSTRAINT `обследование_ноги_fk0` FOREIGN KEY (`id_СФС`) REFERENCES `сафено-феморальное соустье` (`id`),
  CONSTRAINT `обследование_ноги_fk1` FOREIGN KEY (`id_БПВ_на_бедре`) REFERENCES `большая_подкожная_вена_на_бедре` (`id`),
  CONSTRAINT `обследование_ноги_fk10` FOREIGN KEY (`id_ППВ`) REFERENCES `подколенная_перфорантная_вена` (`id`),
  CONSTRAINT `обследование_ноги_fk11` FOREIGN KEY (`C`) REFERENCES `с` (`id`),
  CONSTRAINT `обследование_ноги_fk12` FOREIGN KEY (`E`) REFERENCES `е` (`id`),
  CONSTRAINT `обследование_ноги_fk13` FOREIGN KEY (`A`) REFERENCES `а` (`id`),
  CONSTRAINT `обследование_ноги_fk14` FOREIGN KEY (`P`) REFERENCES `p` (`id`),
  CONSTRAINT `обследование_ноги_fk2` FOREIGN KEY (`id_ПДСВ`) REFERENCES `передняя_добавочная_сафенная_вена` (`id`),
  CONSTRAINT `обследование_ноги_fk3` FOREIGN KEY (`id_ЗДСВ`) REFERENCES `задняя_добавочная_сафенная_вена` (`id`),
  CONSTRAINT `обследование_ноги_fk4` FOREIGN KEY (`id_перфоранты_бедра`) REFERENCES `перфорант_бедра_и_несафенные_вены` (`id`),
  CONSTRAINT `обследование_ноги_fk5` FOREIGN KEY (`id_БПВ_на_голени`) REFERENCES `бпв_на_голени` (`id`),
  CONSTRAINT `обследование_ноги_fk6` FOREIGN KEY (`id_перфорант_голени`) REFERENCES `перфорант_голень` (`id`),
  CONSTRAINT `обследование_ноги_fk7` FOREIGN KEY (`id_СПС`) REFERENCES `сафено_поплитеальное_соустье` (`id`),
  CONSTRAINT `обследование_ноги_fk8` FOREIGN KEY (`id_МПВ`) REFERENCES `малая_подкожная_вена` (`id`),
  CONSTRAINT `обследование_ноги_fk9` FOREIGN KEY (`id_ТЕ_МПВ`) REFERENCES `бедренное_продолжение_малой_подкожной_вены` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `операции`
--

DROP TABLE IF EXISTS `операции`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `операции` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_пациента` int(11) NOT NULL,
  `дата_операции` date NOT NULL,
  `время_операции` time NOT NULL,
  `id_вида_операции` int(11) NOT NULL,
  `id_вида_анестетика` int(11) NOT NULL,
  `NB!` varchar(100) DEFAULT NULL,
  `отмена_операции` int(11) DEFAULT NULL,
  `итоги_операции` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `операции_fk0` (`отмена_операции`),
  KEY `операции_fk4` (`итоги_операции`),
  CONSTRAINT `операции_fk0` FOREIGN KEY (`отмена_операции`) REFERENCES `отмена_операции` (`id`),
  CONSTRAINT `операции_fk4` FOREIGN KEY (`итоги_операции`) REFERENCES `итоги_операции` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `отмена_операции`
--

DROP TABLE IF EXISTS `отмена_операции`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `отмена_операции` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `дата_переноса` date NOT NULL,
  `причина` int(11) NOT NULL,
  `операция_отменена` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `перенос_операции_fk0` (`причина`),
  CONSTRAINT `перенос_операции_fk0` FOREIGN KEY (`причина`) REFERENCES `причины_переноса` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `пациент`
--

DROP TABLE IF EXISTS `пациент`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `пациент` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `имя` varchar(20) NOT NULL,
  `фамилия` varchar(40) NOT NULL,
  `отчество` varchar(40) NOT NULL,
  `пол` varchar(1) NOT NULL,
  `дата_рождения` date NOT NULL,
  `город_проживания` varchar(30) NOT NULL DEFAULT 'Харьков',
  `улица_проживания` varchar(40) NOT NULL,
  `номер_дома` varchar(5) NOT NULL,
  `номер_квартиры` int(3) NOT NULL,
  `телефон` varchar(16) NOT NULL,
  `электронная_почта` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `патологии`
--

DROP TABLE IF EXISTS `патологии`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `патологии` (
  `id_патологии` int(11) NOT NULL,
  `id_пациента` int(11) NOT NULL,
  PRIMARY KEY (`id_патологии`,`id_пациента`),
  KEY `патологии_fk1` (`id_пациента`),
  CONSTRAINT `патологии_fk0` FOREIGN KEY (`id_патологии`) REFERENCES `виды_патологий` (`id`),
  CONSTRAINT `патологии_fk1` FOREIGN KEY (`id_пациента`) REFERENCES `пациент` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `пдсв_комбо`
--

DROP TABLE IF EXISTS `пдсв_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `пдсв_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ПДСВ_комбо_fk0` (`структура1`),
  KEY `ПДСВ_комбо_fk1` (`структура2`),
  KEY `ПДСВ_комбо_fk2` (`структура3`),
  CONSTRAINT `ПДСВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `пдсв_структура` (`id`),
  CONSTRAINT `ПДСВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `пдсв_структура` (`id`),
  CONSTRAINT `ПДСВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `пдсв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `пдсв_подзапись`
--

DROP TABLE IF EXISTS `пдсв_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `пдсв_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ПДСВ_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `ПДСВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `пдсв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `пдсв_структура`
--

DROP TABLE IF EXISTS `пдсв_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `пдсв_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `уровень_вложенности` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ПДСВ_структура_fk0` (`id_метрики`),
  CONSTRAINT `ПДСВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_бедра_и_несафенные_вены`
--

DROP TABLE IF EXISTS `перфорант_бедра_и_несафенные_вены`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_бедра_и_несафенные_вены` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  `подзапись4` int(11) DEFAULT NULL,
  `подзапись5` int(11) DEFAULT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_бедра_и_несафенные_вены_fk0` (`подзапись1`),
  KEY `перфорант_бедра_и_несафенные_вены_fk1` (`подзапись2`),
  KEY `перфорант_бедра_и_несафенные_вены_fk2` (`подзапись3`),
  KEY `перфорант_бедра_и_несафенные_вены_fk3` (`подзапись4`),
  KEY `перфорант_бедра_и_несафенные_вены_fk4` (`подзапись5`),
  CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `перфорант_бедро_подзапись` (`id`),
  CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `перфорант_бедро_подзапись` (`id`),
  CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `перфорант_бедро_подзапись` (`id`),
  CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `перфорант_бедро_подзапись` (`id`),
  CONSTRAINT `перфорант_бедра_и_несафенные_вены_fk4` FOREIGN KEY (`подзапись5`) REFERENCES `перфорант_бедро_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_бедро_комбо`
--

DROP TABLE IF EXISTS `перфорант_бедро_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_бедро_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  `структура4` int(11) DEFAULT NULL,
  `структура5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_бедро_комбо_fk0` (`структура1`),
  KEY `перфорант_бедро_комбо_fk1` (`структура2`),
  KEY `перфорант_бедро_комбо_fk2` (`структура3`),
  KEY `перфорант_бедро_комбо_fk3` (`структура4`),
  KEY `перфорант_бедро_комбо_fk4` (`структура5`),
  CONSTRAINT `перфорант_бедро_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `перфорант_бедро_структура` (`id`),
  CONSTRAINT `перфорант_бедро_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `перфорант_бедро_структура` (`id`),
  CONSTRAINT `перфорант_бедро_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `перфорант_бедро_структура` (`id`),
  CONSTRAINT `перфорант_бедро_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `перфорант_бедро_структура` (`id`),
  CONSTRAINT `перфорант_бедро_комбо_fk4` FOREIGN KEY (`структура5`) REFERENCES `перфорант_бедро_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_бедро_подзапись`
--

DROP TABLE IF EXISTS `перфорант_бедро_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_бедро_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(50) DEFAULT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_бедро_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `перфорант_бедро_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `перфорант_бедро_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_бедро_структура`
--

DROP TABLE IF EXISTS `перфорант_бедро_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_бедро_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_бедро_структура_fk0` (`id_метрики`),
  CONSTRAINT `перфорант_бедро_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_голень`
--

DROP TABLE IF EXISTS `перфорант_голень`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_голень` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись_1` int(11) NOT NULL,
  `подзапись_2` int(11) DEFAULT NULL,
  `подзапись_3` int(11) DEFAULT NULL,
  `подзапись_4` int(11) DEFAULT NULL,
  `подзапись_5` int(11) DEFAULT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_голень_fk0` (`подзапись_1`),
  KEY `перфорант_голень_fk1` (`подзапись_2`),
  KEY `перфорант_голень_fk2` (`подзапись_3`),
  KEY `перфорант_голень_fk3` (`подзапись_4`),
  KEY `перфорант_голень_fk4` (`подзапись_5`),
  CONSTRAINT `перфорант_голень_fk0` FOREIGN KEY (`подзапись_1`) REFERENCES `перфорант_голень_подзапись` (`id`),
  CONSTRAINT `перфорант_голень_fk1` FOREIGN KEY (`подзапись_2`) REFERENCES `перфорант_голень_подзапись` (`id`),
  CONSTRAINT `перфорант_голень_fk2` FOREIGN KEY (`подзапись_3`) REFERENCES `перфорант_голень_подзапись` (`id`),
  CONSTRAINT `перфорант_голень_fk3` FOREIGN KEY (`подзапись_4`) REFERENCES `перфорант_голень_подзапись` (`id`),
  CONSTRAINT `перфорант_голень_fk4` FOREIGN KEY (`подзапись_5`) REFERENCES `перфорант_голень_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_голень_комбо`
--

DROP TABLE IF EXISTS `перфорант_голень_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_голень_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура_1` int(11) NOT NULL,
  `структура_2` int(11) DEFAULT NULL,
  `структура_3` int(11) DEFAULT NULL,
  `структура_4` int(11) DEFAULT NULL,
  `структура_5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_голень_комбо_fk0` (`структура_1`),
  KEY `перфорант_голень_комбо_fk1` (`структура_2`),
  KEY `перфорант_голень_комбо_fk2` (`структура_3`),
  KEY `перфорант_голень_комбо_fk3` (`структура_4`),
  KEY `перфорант_голень_комбо_fk4` (`структура_5`),
  CONSTRAINT `перфорант_голень_комбо_fk0` FOREIGN KEY (`структура_1`) REFERENCES `перфорант_голень_структура` (`id`),
  CONSTRAINT `перфорант_голень_комбо_fk1` FOREIGN KEY (`структура_2`) REFERENCES `перфорант_голень_структура` (`id`),
  CONSTRAINT `перфорант_голень_комбо_fk2` FOREIGN KEY (`структура_3`) REFERENCES `перфорант_голень_структура` (`id`),
  CONSTRAINT `перфорант_голень_комбо_fk3` FOREIGN KEY (`структура_4`) REFERENCES `перфорант_голень_структура` (`id`),
  CONSTRAINT `перфорант_голень_комбо_fk4` FOREIGN KEY (`структура_5`) REFERENCES `перфорант_голень_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_голень_подзапись`
--

DROP TABLE IF EXISTS `перфорант_голень_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_голень_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_голень_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `перфорант_голень_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `перфорант_голень_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перфорант_голень_структура`
--

DROP TABLE IF EXISTS `перфорант_голень_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перфорант_голень_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `перфорант_голень_структура_fk0` (`id_метрики`),
  CONSTRAINT `перфорант_голень_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `передняя_добавочная_сафенная_вена`
--

DROP TABLE IF EXISTS `передняя_добавочная_сафенная_вена`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `передняя_добавочная_сафенная_вена` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Передняя_добавочная_сафенная_вена_fk0` (`подзапись1`),
  KEY `Передняя_добавочная_сафенная_вена_fk1` (`подзапись2`),
  KEY `Передняя_добавочная_сафенная_вена_fk2` (`подзапись3`),
  CONSTRAINT `Передняя_добавочная_сафенная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `пдсв_подзапись` (`id`),
  CONSTRAINT `Передняя_добавочная_сафенная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `пдсв_подзапись` (`id`),
  CONSTRAINT `Передняя_добавочная_сафенная_вена_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `пдсв_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `перенос_операции`
--

DROP TABLE IF EXISTS `перенос_операции`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `перенос_операции` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `дата_переноса` date NOT NULL,
  `причина` int(11) NOT NULL,
  `операция_отменена` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `подколенная_перфорантная_вена`
--

DROP TABLE IF EXISTS `подколенная_перфорантная_вена`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `подколенная_перфорантная_вена` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Подколенная_перфорантная_вена_fk0` (`подзапись1`),
  KEY `Подколенная_перфорантная_вена_fk1` (`подзапись2`),
  CONSTRAINT `Подколенная_перфорантная_вена_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `ппв_подзапись` (`id`),
  CONSTRAINT `Подколенная_перфорантная_вена_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `ппв_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ппв_комбо`
--

DROP TABLE IF EXISTS `ппв_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ппв_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ППВ_комбо_fk0` (`структура1`),
  KEY `ППВ_комбо_fk1` (`структура2`),
  CONSTRAINT `ППВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `пдсв_структура` (`id`),
  CONSTRAINT `ППВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `пдсв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ппв_подзапись`
--

DROP TABLE IF EXISTS `ппв_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ппв_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ППВ_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `ППВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `ппв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ппв_структура`
--

DROP TABLE IF EXISTS `ппв_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ппв_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ППВ_структура_fk0` (`id_метрики`),
  CONSTRAINT `ППВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `причины_переноса`
--

DROP TABLE IF EXISTS `причины_переноса`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `причины_переноса` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `причина` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `рекомендации`
--

DROP TABLE IF EXISTS `рекомендации`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `рекомендации` (
  `id_рекомендации` int(11) NOT NULL,
  `id_обследования` int(11) NOT NULL,
  PRIMARY KEY (`id_рекомендации`,`id_обследования`),
  KEY `рекомендации_fk1` (`id_обследования`),
  CONSTRAINT `рекомендации_fk0` FOREIGN KEY (`id_рекомендации`) REFERENCES `виды_рекомендаций` (`id`),
  CONSTRAINT `рекомендации_fk1` FOREIGN KEY (`id_обследования`) REFERENCES `обследование` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `с`
--

DROP TABLE IF EXISTS `с`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `с` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `буква` int(11) NOT NULL,
  `индекс` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `С_fk0` (`буква`),
  KEY `С_fk1` (`индекс`),
  CONSTRAINT `С_fk0` FOREIGN KEY (`буква`) REFERENCES `с_клинический_класс_заболевания` (`id`),
  CONSTRAINT `С_fk1` FOREIGN KEY (`индекс`) REFERENCES `c_субъективные_симптомы` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `сафено-феморальное соустье`
--

DROP TABLE IF EXISTS `сафено-феморальное соустье`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `сафено-феморальное соустье` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  `подзапись4` int(11) DEFAULT NULL,
  `подзапись5` int(11) DEFAULT NULL,
  `подзапись6` int(11) DEFAULT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Сафено-феморальное соустье_fk0` (`подзапись1`),
  KEY `Сафено-феморальное соустье_fk1` (`подзапись2`),
  KEY `Сафено-феморальное соустье_fk2` (`подзапись3`),
  KEY `Сафено-феморальное соустье_fk3` (`подзапись4`),
  KEY `Сафено-феморальное соустье_fk4` (`подзапись5`),
  KEY `Сафено-феморальное соустье_fk5` (`подзапись6`),
  CONSTRAINT `Сафено-феморальное соустье_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `сфс_подзапись` (`id`),
  CONSTRAINT `Сафено-феморальное соустье_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `сфс_подзапись` (`id`),
  CONSTRAINT `Сафено-феморальное соустье_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `сфс_подзапись` (`id`),
  CONSTRAINT `Сафено-феморальное соустье_fk3` FOREIGN KEY (`подзапись4`) REFERENCES `сфс_подзапись` (`id`),
  CONSTRAINT `Сафено-феморальное соустье_fk4` FOREIGN KEY (`подзапись5`) REFERENCES `сфс_подзапись` (`id`),
  CONSTRAINT `Сафено-феморальное соустье_fk5` FOREIGN KEY (`подзапись6`) REFERENCES `сфс_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `сафено_поплитеальное_соустье`
--

DROP TABLE IF EXISTS `сафено_поплитеальное_соустье`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `сафено_поплитеальное_соустье` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `подзапись1` int(11) NOT NULL,
  `подзапись2` int(11) DEFAULT NULL,
  `подзапись3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Сафено_поплитеальное_соустье_fk0` (`подзапись1`),
  KEY `Сафено_поплитеальное_соустье_fk1` (`подзапись2`),
  KEY `Сафено_поплитеальное_соустье_fk2` (`подзапись3`),
  CONSTRAINT `Сафено_поплитеальное_соустье_fk0` FOREIGN KEY (`подзапись1`) REFERENCES `спс_голень_подзапись` (`id`),
  CONSTRAINT `Сафено_поплитеальное_соустье_fk1` FOREIGN KEY (`подзапись2`) REFERENCES `спс_голень_подзапись` (`id`),
  CONSTRAINT `Сафено_поплитеальное_соустье_fk2` FOREIGN KEY (`подзапись3`) REFERENCES `спс_голень_подзапись` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `сфс_комбо`
--

DROP TABLE IF EXISTS `сфс_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `сфс_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  `структура4` int(11) DEFAULT NULL,
  `структура5` int(11) DEFAULT NULL,
  `структура6` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `СФС_комбо_fk0` (`структура1`),
  KEY `СФС_комбо_fk1` (`структура2`),
  KEY `СФС_комбо_fk2` (`структура3`),
  KEY `СФС_комбо_fk3` (`структура4`),
  KEY `СФС_комбо_fk4` (`структура5`),
  KEY `СФС_комбо_fk5` (`структура6`),
  CONSTRAINT `СФС_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `сфс_структура` (`id`),
  CONSTRAINT `СФС_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `сфс_структура` (`id`),
  CONSTRAINT `СФС_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `сфс_структура` (`id`),
  CONSTRAINT `СФС_комбо_fk3` FOREIGN KEY (`структура4`) REFERENCES `сфс_структура` (`id`),
  CONSTRAINT `СФС_комбо_fk4` FOREIGN KEY (`структура5`) REFERENCES `сфс_структура` (`id`),
  CONSTRAINT `СФС_комбо_fk5` FOREIGN KEY (`структура6`) REFERENCES `сфс_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `сфс_подзапись`
--

DROP TABLE IF EXISTS `сфс_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `сфс_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) NOT NULL,
  `метрика1` float DEFAULT NULL,
  `метрика2` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `СФС_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `СФС_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `сфс_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `сфс_структура`
--

DROP TABLE IF EXISTS `сфс_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `сфс_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `двойная_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `СФС_структура_fk0` (`id_метрики`),
  CONSTRAINT `СФС_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `специализации`
--

DROP TABLE IF EXISTS `специализации`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `специализации` (
  `id_специализации` int(11) NOT NULL,
  `id_врача` int(11) NOT NULL,
  PRIMARY KEY (`id_специализации`,`id_врача`),
  KEY `специализации_fk0` (`id_врача`),
  CONSTRAINT `специализации_fk0` FOREIGN KEY (`id_врача`) REFERENCES `врачи` (`id`),
  CONSTRAINT `специализации_fk1` FOREIGN KEY (`id_специализации`) REFERENCES `виды_специализаций` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `спс_голень_подзапись`
--

DROP TABLE IF EXISTS `спс_голень_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `спс_голень_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  `метрика1` float DEFAULT NULL,
  `метрика2` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `СПС_голень_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `СПС_голень_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `спс_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `спс_комбо`
--

DROP TABLE IF EXISTS `спс_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `спс_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `СПС_комбо_fk0` (`структура1`),
  KEY `СПС_комбо_fk1` (`структура2`),
  KEY `СПС_комбо_fk2` (`структура3`),
  CONSTRAINT `СПС_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `спс_структура` (`id`),
  CONSTRAINT `СПС_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `спс_структура` (`id`),
  CONSTRAINT `СПС_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `спс_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `спс_структура`
--

DROP TABLE IF EXISTS `спс_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `спс_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(11) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `двойная_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `СПС_структура_fk0` (`id_метрики`),
  CONSTRAINT `СПС_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `с_клинический_класс_заболевания`
--

DROP TABLE IF EXISTS `с_клинический_класс_заболевания`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `с_клинический_класс_заболевания` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(5) NOT NULL,
  `описание` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `те_мпв_комбо`
--

DROP TABLE IF EXISTS `те_мпв_комбо`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `те_мпв_комбо` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `структура1` int(11) NOT NULL,
  `структура2` int(11) DEFAULT NULL,
  `структура3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ТЕ_МПВ_комбо_fk0` (`структура1`),
  KEY `ТЕ_МПВ_комбо_fk1` (`структура2`),
  KEY `ТЕ_МПВ_комбо_fk2` (`структура3`),
  CONSTRAINT `ТЕ_МПВ_комбо_fk0` FOREIGN KEY (`структура1`) REFERENCES `те_мпв_структура` (`id`),
  CONSTRAINT `ТЕ_МПВ_комбо_fk1` FOREIGN KEY (`структура2`) REFERENCES `те_мпв_структура` (`id`),
  CONSTRAINT `ТЕ_МПВ_комбо_fk2` FOREIGN KEY (`структура3`) REFERENCES `те_мпв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `те_мпв_подзапись`
--

DROP TABLE IF EXISTS `те_мпв_подзапись`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `те_мпв_подзапись` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_структуры` int(11) NOT NULL,
  `комментарий` varchar(100) DEFAULT NULL,
  `метрика` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ТЕ_МПВ_подзапись_fk0` (`id_структуры`),
  CONSTRAINT `ТЕ_МПВ_подзапись_fk0` FOREIGN KEY (`id_структуры`) REFERENCES `те_мпв_структура` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `те_мпв_структура`
--

DROP TABLE IF EXISTS `те_мпв_структура`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `те_мпв_структура` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название1` varchar(150) DEFAULT NULL,
  `название2` varchar(100) DEFAULT NULL,
  `id_метрики` int(50) DEFAULT NULL,
  `есть_метрика` tinyint(1) NOT NULL,
  `уровень_вложенности` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ТЕ_МПВ_структура_fk0` (`id_метрики`),
  CONSTRAINT `ТЕ_МПВ_структура_fk0` FOREIGN KEY (`id_метрики`) REFERENCES `метрика` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `тип_расстройства`
--

DROP TABLE IF EXISTS `тип_расстройства`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `тип_расстройства` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(5) NOT NULL,
  `описание` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `c_субъективные_симптомы`
--

DROP TABLE IF EXISTS `c_субъективные_симптомы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `c_субъективные_симптомы` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `название` varchar(5) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `название` (`название`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p`
--

DROP TABLE IF EXISTS `p`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `p` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `буквы` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `P_fk0` (`буквы`),
  CONSTRAINT `P_fk0` FOREIGN KEY (`буквы`) REFERENCES `тип_расстройства` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-04  0:31:52
