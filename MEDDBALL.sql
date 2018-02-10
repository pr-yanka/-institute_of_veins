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
-- Table structure for table `Ð°`
--

DROP TABLE IF EXISTS `Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð±ÑƒÐºÐ²Ñ‹` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð_fk0` (`Ð±ÑƒÐºÐ²Ñ‹`),
  CONSTRAINT `Ð_fk0` FOREIGN KEY (`Ð±ÑƒÐºÐ²Ñ‹`) REFERENCES `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð°`
--

LOCK TABLES `Ð°` WRITE;
/*!40000 ALTER TABLE `Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹`
--

DROP TABLE IF EXISTS `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð²Ñ€Ð°Ñ‡` tinyint(4) DEFAULT NULL,
  `Ð°Ð´Ð¼Ð¸Ð½` tinyint(4) DEFAULT NULL,
  `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` tinyint(4) DEFAULT NULL,
  `ÑÐµÐºÑ€ÐµÑ‚Ð°Ñ€ÑŒ` tinyint(4) DEFAULT NULL,
  `Ð¿Ð°Ñ€Ð¾Ð»ÑŒ` varchar(100) DEFAULT NULL,
  `enabled/disabled` tinyint(4) DEFAULT NULL,
  `Ð¸Ð¼Ñ` varchar(45) DEFAULT NULL,
  `idÐ²Ñ€Ð°Ñ‡` int(11) DEFAULT NULL,
  `idÐ¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹_fk1` (`Ð²Ñ€Ð°Ñ‡`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹`
--

LOCK TABLES `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹` WRITE;
/*!40000 ALTER TABLE `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹` DISABLE KEYS */;
INSERT INTO `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹` VALUES (1,NULL,1,NULL,NULL,'C3FCD3D76192E4007DFB496CCA67E13B',1,'ÐÐ´Ð¼Ð¸Ð½',NULL,NULL),(2,1,0,0,0,'F41ABD2FCAC66098D7626E48CC0C9CA0',1,'Ñ–Ñ–Ñ–',8,NULL),(5,0,0,1,0,'1AABAC6D068EEF6A7BAD3FDF50A05CC8',1,'dd',NULL,2);
/*!40000 ALTER TABLE `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹`
--

DROP TABLE IF EXISTS `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ñ‚Ð¸Ð¿_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°` int(11) NOT NULL,
  `Ð´Ð°Ñ‚Ð°` date NOT NULL,
  `id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°` int(11) NOT NULL,
  `Ð°Ð½Ð°Ð»Ð¸Ð·` longblob NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹_fk0` (`Ñ‚Ð¸Ð¿_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°`),
  KEY `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹_fk1` (`id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°`),
  CONSTRAINT `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹_fk0` FOREIGN KEY (`Ñ‚Ð¸Ð¿_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°`) REFERENCES `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°` (`id`),
  CONSTRAINT `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹_fk1` FOREIGN KEY (`id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°`) REFERENCES `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_esperanto_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹`
--

LOCK TABLES `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹` WRITE;
/*!40000 ALTER TABLE `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹` DISABLE KEYS */;
INSERT INTO `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹` VALUES (1,1,'2018-01-09',2,'ÿ\Øÿ\à\0JFIF\0\0`\0`\0\0ÿ\Û\0C\0\n\n\n\r\rÿ\Û\0C		\r\rÿÀ\0\0V\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0\0}\0!1AQa\"q2‘¡#B±ÁR\Ñð$3br‚	\n\Z%&\'()*456789:CDEFGHIJSTUVWXYZcdefghijstuvwxyzƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\á\â\ã\ä\å\æ\ç\è\é\êñòóôõö÷øùúÿ\Ä\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0w\0!1AQaq\"2B‘¡±Á	#3Rðbr\Ñ\n$4\á%ñ\Z&\'()*56789:CDEFGHIJSTUVWXYZcdefghijstuvwxyz‚ƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\â\ã\ä\å\æ\ç\è\é\êòóôõö÷øùúÿ\Ú\0\0\0?\0øŠŠ+ºøAð¦o‹ºö£¥Ã­iº\0³°’ù¯5Wdƒ‡Ž5Ven\ç•\ãÀ\'Z\ÂÕ–\Ò\ïWLMD\ÚN4÷™­\Ö\ì\Ä\ÞQ”(bñÀ2’3œ0=\ë\î?\Ù\ïöð¥§‰-|;ñªý­|g¯\Ã?öO„ôÛ¡ö‹h£Zòi#%F|¶	*\Ú9\ïðN?iG\à\Ä^YÃªivþ6¿µò5’e‘\Þ\ÕFõ#i8”®\ä\ÅU\Û=\"k\í?P¼‰£\Ùb©$¨I\ÜUœ&G\à•\Ï=\Å0)Q]\ï5>å¡\íÔ®œ56mä¨Œºx\á÷|˜þ÷\ïX\Ú^›>±©ZXZ¨{›©V•ˆ\0³\0\É\éÉ§\ÖÂ¾—\èV¢ºK?\Þjš¦©eawi{ýŸHó\ÆÎ±\ÈGð&õXœ€Á\í\Íst“¾\ÅZÁEµu\áw‡A:¤:•\ìq¼iq»?™n\Î¨m\Èý\Ó÷°G8£\ÌF-VÖ¥\á\í/\ÃzN¹!‰\ìµ# \ËbY\n1\\8#Œ\í$`ž£\ÌZ+¡\×|w\á»[	µ«X\Zú\Éo ‡.\Î\Ê[ñ\Î	®x®z€\n(¢€\n+W\Ãþ—\Ä3]„¹·³‚\ÒÝ®g¸¹-²4.pª\ÌIfQ€_Nj\ê\Æþ\Ö\Ò\è%³Ü¤R£;eBH#¹\ã_j}l+\è\ÙBŠ\Ýo\ÝAqª\Çwqobšm\Ê\Ú\\M6ý¢Fv\\\0ªXý\×n™ÂžüV(V 0`7\àûóRšz¢¶\ÐJ(­m{­ûTGŒ[\Ù\Ë2+¼´\Ê\àcùyô§\æ#>ŠÜ“\Âoo¢Áq¨\Ù[Kqž\Þ\ÆC\'4a\Ê\î!AÊ·\à½9\Í\Õ4»­R¹°½‹É»·s±\î\rµ‡QH?…A\æU¢®hºTº\î±c¦ÀÈ“\ÞN–ñ´„…\Ì€N2})—\Ö+bÈŸi†y>`\é|\ÆC†Ü \Æx\ÈÁò(µQ@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@“ð§örø‡ñ»O¾½ðV€ºÕ½Œ«\r\Ã}¾\Úˆ\Èe‘N\Ï cƒ\é]­\Ç\ìñ\Î\Î\ÞY\çðJAJ^IdÖ´õTP2I&|\0z“ö ø\Ýÿ\0\nc\ãvŸö\Ùü¯\ë»t\ÝCw\ÝM\Íû©O\î¾?jõ¯\Ûûö®\Öõ\ïjÿ\044¸Ñ´M:_#T•¾Io\ä\0¼t‡qü}Oµ¸\Ü@Ö·\Â\å\ãbŒcuu$p\ÊHa\î	µG^¯ðûC\Ò/4]6MB\Ú?.IŸ:\Û$\Ò*ù„ª\Än `:Žµ\è~ø_\Âþ&K-\Ë\ÏÓ¦Ó¬oc’ö„\ÇÏµŠcƒ™\0\'\'©ûœ?V\ÄS§5U.xó-\Úuùž\í,ªuTZ’\Õ_òÿ\03\æŠ(­ÿ\0‡úX\Ö<m¡Ú¾“{®Ûµ\Üoq§i\Ñ4·À¬\ZUE^IØ¯Ó¦3_xE½/áž¹«iVšŠ6“ikv­%¹Ôµ»+\'•\ÙªM21]\è\ë»Ê‘\Ø\Õ/x\'Uð½¥\Åø³’\Úí¤Ž?P·½‰MðH\ê	•\'8u=\ë\èßøkñ3Y\Ò.¼.ÁZ\r\ÄwZ\ÈÐ¦†\Êi\ãesj „zÄ·R´T.I9\â\íc@_	\è¾\Ðo5\rF+;\ë\Ëùnµ$´$\Ï²TY¥\Èf\Î\â\Ã;ñŽ2Pœk%À»—ks\ÙI«[aÿ\0Ÿtü\Ûüj¾Ÿÿ\0#ý\Çÿ\0\ÐMz€\ã…<+¯\Ý4úU•\Äw‰Ö­b.‘C	·(T„\Î\Þ\Ýjº\\G	¶ù÷OÍ¿Æ°ÿ\0Ïº~mþ5\Û\\ü1\Õ\î!¸Z\Õõ\Ô&³{5–w2ª>b—~wð¨¼`zâ¡›À–\Úu»\Þj:œ°i\é¤…\í\íD²™\'\ÌT]F\0\r–,:9\Å+\é\ëQú~\Ø\ç\Ý?6ÿ\0\Z6\Ãÿ\0>\éù·ø\×k¥øH\Õôý\"x5›Õ›R\ÔNH\äÓ*>c\ÜÅ„\ç€$q’F8\ëRZü7¶\Õn-“N\Ö|ø\ä’\æ\ÞIg¶ª\Ë&N>\n0\Ü\ÅH\êTQ\ëúõ\ëúû™\Ãm‡þ}\Óóoñ£l?óîŸ›vš_\Ã;\Ù\å‰o.#´i/,\í\ãhŒw1È³³¨‘]«1ž\ä\ädb¦ñ\î‹ömK\Ô\Z\ßN±šk‰£–\Ö\ÆÝ†ÚŒØ»r\Ê\ÊÁ\n ðM\r\Ø®\Ç¶ù÷OÍ¿Æ°ÿ\0Ïº~mþ5\ÙG\à;[¨´i¬\ïî®¢½fí¶‡6\áP1$‰\Ê7$h\È’\0«ÿ\0ô\íµ9oµ©¾\ÇköO.K;H\çi<ôgpƒHÊ»\Ø\Óò\Â\í‡þ}\Óóoñ£l?óîŸ›vú—\Ãd°\Õ^\Ýu&–\Ò\Þ\â\æ»Ÿ³c\È®ý\Åw\îS\Ç#\'#¶j¬~	³þ\ÓÑ´™u9“V\Ô\Ûtih\ZRm¥I\È	`¬¤¨\\sÔ“æµº†Úœ–\Ø\ç\Ý?6ÿ\0\Z6\Ãÿ\0>\éù·ø\ÖßŠ¼6¾\ÔN’\å¦\Ô#\é1ù[R\"pUCn;Ž\Ò	\à\0xº\×U«Z\Úh/\â«{Y¦\Ñ\î`\Ò\í\Öh\ãN$;¡v-\Æð@\ß\ì¸/¥ÿ\0¯\ëT;4\ìy\Ö\Ø\ç\Ý?6ÿ\0\Z6\Ãÿ\0>\éù·ø\×ioo¥\ëþ\×u‹ñö}Z‹x¢ûšGÌ²\nº¨Ý·’ €K\Z¿ªx6\ËG\ÒüI¦[\\Gyk¨Y\Û}®\æ¶\Ç\Ïª\ì\ç\np¹$¨\Èô\0‘\é¿õ·ù\ç›aÿ\0Ÿtü\Ûüh\Ûüû§\æ\ß\ã]µ·\Ã\Ãc\â\íO¿¹µ¹µ¾xw[\Èds½UŠ\â7b:\í\rŒ¢‹dx–b;7M´[;f¼µ6¶G\ä22\á€ÌŠA\ÚD…²H\ïÔ¸ÀüN\'l?óîŸ›aÿ\0Ÿtü\Ûüks\ÆvpYë…­£X!¹‚µ‰xù±+•°Ž¦+€\r°ÿ\0Ïº~mþ4m‡þ}\Óóoñ¢Š`aÿ\0Ÿtü\Ûüh\Ûüû§\æ\ß\ãE_\ÐtG\Å:Õž‘¤YM¨\êw’m\ímÐ³\È\ç \0Pm\à?\Ù\Ó\â\Ä\ímo\Ã\n¼Õ´¨‹)ºŒ\ìW+\Ô&÷aŒ.y¯?Ô´\×\Óä½µº²k+\ËV1\Ëª\ë$n+++9\Å}\áño\àüºu\ÂM÷\âï†¾\ê~\Ñm\ÓRÒ§\ÕR\ÛÉ»s\\Ûªÿ\0¬•»—;ƒ_+~\Ó=\Ñþ\'|jñ·‰´\Ìz=ô\èmØ¡C EŽ3.\Ó\È\ÞP¿<ü\Ü\à\ÒL#¢Š\Øð·ƒ<A\ãBK\r\èZ—ˆ/£ˆ\Îöº]œ—2¬`….U!Ae\é–´Ev> ø3ñ\ÂzLú®·\à_\è\Ú]¾\ß:÷P\Ò. †=\Ìw; Q–`O$Þ¸\ê\0(¢»„~°ø\ã«]U\×?\á\Z\Ò\Ú\Öòö\ïVû#]ýškYn]¼¥egùa#\0\çž\è@8\ê+ôWÁ?ð\ëV¾Ó¾xsÀ_´»SDðþ¿$Ÿ.#\Ô-­å‰’mBk‡}§s[\ÊÅŒd.ñ¹Ž2ÿ\0T\0QE\0Q_R|>ø\àÿ\0Š\Þ³ø‡•¨\è\Zn‡©­xr\Ä\É4š\ÓÀ\Ë\é\ï#ùh$ù\\‘‘_6x‹P²Õµ\Ë\ë\Í;J‡D°šVx4\è%’T·Lð\äfvÀ\îO>\Ý(:Š( ½Cö}Ö¼i\á\Ï^\Þøûµ‰m\rŸ—«\ÜZ&C²²´QÜº‰$W‰Xm\r‚£#šòú(ô‹\à/\ÄOŒ\r\Z9¾,|ñ¯t•¸ŸC\×\ì\ìM\î£\Ê0ðA%¡p\ÌrKcŒ\íöOø\'^“­\éŸ\n¼m6¿ \ê>½\Ô<c{|¶:³Á*¤[pê¤Œ\äg%M~[ü=øûñ\áK¯ü\"ž0\Õtˆ—\è\Ñ\Î^=b|¡ü«\×|]ÿ\0ø\Ù\â\ï\rÁ¤\rr\ÏEeÿ\0[¨ižE\Ôÿ\0\ï>H_ûf¦À|\É]\'€u->\Ã^hµ‰Z\r&ò	-n¤T.QHÊ¶\'ªxô®nŠ´\ì\'©\èzÇŽlµŸ\n\ê\äa®]^4=f\Òùÿ\0{§qJ\í¼I\ãˆ|?ã«w\â¸\ë\ÐM¼1Ê¿\ÙÐ£0Ÿ? 8lm\à’\Ü×ƒT·Ws\ß\\Iqs4—6\ç–V,\ÌORI\äšVµ’\éÿ\0ü‚^õÿ\0­\ÏA±ñÖ•¦\Ûý²\ì\ê:Æ¯sª}¾Y!¼òY\\B¤‰÷\çsœ`bºm/Z\Ót=\Í3_\ZN‰ÿ\0	\r\Äû|™K\Ü[ùP3[Œ!\ÏiW\Â62O¼N¥k\É\Ú\ÕmL\Òes\"\Â\\\ì@€\é’\0ö­eeýmþCz»ÿ\0]\Ìõ\åñ%¾—\áYuE²\Óf\Ó\ïƒ\è‹“w¾i\Ö5$!Bˆû\ämÁ+É®3\Ä_Ù–¾‚\ÏH\Ö\ì\'¶\ÌSOn‘\\-\ÌólÁg-L!g\nt9\ä’k”šò{ˆaŠY¤’(¬H\îJÆ¤–!Ga’OÉ¨¨¶ÿ\0\×[Ì½6£o&—\r¢\év‘N¹¯‘¦ó¤ðÀ\ÈSŽˆž¹\î4¯h-¡\èzF«$“iñÙ¹¹Ž$m\É:\\K,`q\Î\år™\Í\'µy\ÍDž™u\ã\Û\rSE•¯nƒ\ßÏ¤O±ˆ\Ü3ß‰‚Œ³œô:ñV¤ñ½´0‡UÄ¾nŽ±]}‹L	8þ\Î\ßl\ë~YO,`•\\¡ \ã&¼¦Š›~¿ü8\ÏOÓ¼un|?hn5\Ù\Ú\é5-U•\ÛQ¸‘¤++¥\Ñåƒ/—À8±4Å“Ã³\Þk{\îm\áx;Cpö–\ìû\"›Ê‘\ÉÊ“\åi ŒùEûùÿ\0_¨_\×õ\êz¤Ÿ¾\Ãc¨Û\Ü_j2h\æ\Ùõ(ZuûT\ßhVE\ÜÊ®\Ûc.»œ¬£Œg›ø\âfñDš5\ÏöÌšŸ—aO\Í){yV5Y3¼m\Ë0\'*Nzžk¢•¿¯¿üÁiýz‘\é­\ã&MW\Â7b\åÄ†þ\rGXv¿w${#\ì>nßŒÿ\0¬\"¦±ñ¾Ÿk§h’\\\ê\ì\ÃOÔ¢ž=6Á\îZ1;H\Ï<n‚2\à<€A\ê<²Š®·ó¿õ÷\n\Ú[\ÊßŸùž©c¬x{I]2\ÜxŽ9¤‡R½¾©u\nF^‡`‹ RË†\Ø3‚p{\Õox\ÃJ\ÖluÕ·¼Ž{«\Æ\Ó[tQÍ¶VŠV\Ý.X\à°\å\Î\ãœó\Íy¥º[ú\Óþ«õþ·¹\Ý\èzåžŸ\áW[\Íj§†&“O²H%¶W[ÁVŽmQ2$Á\Ï\Ý\Ý\È\ÛñGŠ4\Ï_x¢)üME¨\\[]\Ú\\\Ü\Çr\ëq™s<²Á€“ ³¯\Í^SE_[“\ÒÇµ\Ùü@\Ñ\Ó\ÅS\Þ\Úøû&\Ïû}¯nW\ì\Ó¨[›v\í•ðüŒš\Å\Óüe¦Goi\Z·ö^ ºmÍ¼:——(û­xÒƒ”R\ÃtD®\äøõÇ—QSmþ¶°ÿ\0¯\Æ\çA\ã­Z\rk^ó\á¸ûk,E5\îÂ¿j•P—\É\Ï,2zœEsôQO`\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\nô‹Ÿ\án\Â3{{¥}—\Ä\Zn—›¨jh\ßý¥\åq¬›\Æ	…<¶\ì\Åyõ\è\Þñv•¦ø~\Ö\Ö\ê\ëÊž=û—\Ës\Õ\É\èk³ñ‡\Æ-\Åz•µ\ç›öo#N²°òö\Èû¾\Ïm³°cw—»³Œœf¼\ZŠû\ZSŒ\ÃÓ§N0‡¸¹Vm?½\ä{4óZ\Ô\ã¨­ºí§Ÿ’\n\ìþüFÿ\0…KñHñ_öö¯öþ‰\çù>g™\Ç÷ö¶1¿=L{\×E|q\ãùñ\ëö¦‹\ã_‚m<=„S\Ã\É¤54w\Â`\í²Ua´Dœ±”±lõ\×5\àtQ@tðZ\è\02J·þ‚k¢\Ñ<A«xzˆl\Ò#\r\Ã#\ÉÍ”W\nY3´\âD`\ÜÜZ\å(¦om\ãZ\Ç2¬û\ÚY\Þ\è\Í5¤RÊ²¸$d,Œ@©À\ÅCo\â\Ýz\Þg}\ë0x\"¶x®m#š&HÀƒ¡RT†#=y\ä\×E-\0\í<;\â+½/V\Ñ\Þ\é%}:\ÇR]@\Ã*\íÉ¼¯¨@\0\Î8\íR\Üx\ã^“U†ö&XÍ»LaE±…S÷ƒk–@›]™x%\'k†¢€þ¿¯¼\í[Æ¾\"3$«7”c’cHm#Ž8\Ú\"\Æ=¨¨@.\Ç\0`–$\æ¨jZÖ¯¬Bñ\Þ\Ë5Â½Ì—m½L®3g\ä*ñÓŠ\æh£@;Xüi¯\Âmü“	ý°Ã§Áo¹v7˜Šd\ÊñóƒUµ/kz¼w\ÝH\ÏÇ“\æ\"Û¢/î”¬`Q€¡ˆÀÀ®NŠ`w·)º›CÕ£io.5=ju’ùšŽ%\nIvžK3ò¨\0cœ\Õ(üW®Cž€¡kG¶\ì¢i£\ØÛy¥7•¢“Ž\Ø\ÅqôR\Ñ\ê:–¥«Cm\Þé…¸+T8Rs´° v;b´\æñv¦º´šœMmqs\Åx’\"\Í\Ë\03F\êTƒ€\Ø`\ß6H\íŽ&Šu\Òx›Y’;\èÈˆCz¨²Â¶1\Æ\Ü\í(6\ÆF\æ\å\0?1õ¨oµ\ÝcRþ\Ñ2<Ÿ\Ú­\Å\Ï\îTy’.\í­À\ã\ï·š\å\è£@6Œ—\Æ\â9\Ë\\£\ÚL¶\å\Ú\0\\\Ø\0c\ÓºUñ\æ«skui©XZ\ê—{MÂ‹U·–F!Ì‘gq’rû†NH5ÀQL“^¾Ÿ\\Õ§¼6­>ÕŽ	Æª8\ç\n\0\Ï|f³þ\Í7üòû\ä\Ö]€\Ôû4\ßó\Éÿ\0\ï“GÙ¦ÿ\0žOÿ\0|šË¢˜\ZŸf›þy?ýòk±øOñ;\Ä\ßüe‰¼5\åÅ©Eÿ\0¤Û‰Q‘\Æ þ ƒÇ¦Ey\Õ\ÒxƒX\Ö<Y®^\ë\Z\Å\ÅÎ£©\Þ\Ê\Ó\\]O–yžIÿ\0ƒ ¬é¡’;[‚\È\Ê6Ž£\Ä+2Š\0+±ø[ñ{Å¿¼Aq­ø7Vþ\Æ\Õ.-Z\ÊIþ\Íû¡gG+¶Te4hrx\ëÉ®:Š@{ÿ\0kÏ‹<#\áø³ûOC¾òþ\Ñký›iý’,‹óG°Ã¢ž\é\é^;E\0WA\à?M\à&¯\r…ž©þ‹ue-–¡\æù3Cqo%¼ª\ÞS£Œ\Ç+\à«kŸ¢€;Ÿ|PƒXð}Ï†ô\Ïh>±º¿·\Ô.$\Òä¾’Y¤‚9\ãŒss0\nÌ¿tIñ\\5PEPc}ñƒ\Æ\Ú\ç‡õv\×&·¾ðüQÃ¥5œil–Hœqª¢\äòxù²wg5\Ïxƒ^¼ñF¹{«\ê¾¼•¦­\í\ã·Fs\É\"8\ÕQry\à\nÏ¢€\n(¢€\nõ/„\î>\'B/o|C§xWJ“\íq\Û\\\ßG,\Ïu-½³\\J±\Ç±ÚŠ»6\06\ïl!ò\Úö_‚¿´O\Ú[\éž,\Ñu\r_N±þÑ“OŸJ»H\'\î\ì\Ú\Þd`\è\Ê\èØŒƒÁB|\ã(_Ù—{;z‡U\ÛúýNRû\àŒ\â\×nô\Í/B½ñ?‘mð¼\Ð-e¼‚[Y\è®•2†q¸)`¬¤	ü+ð¦?x^]JMJú\ÓQ·W¶úJhww^\Ã\àK‘©Œ\Æ$YGvABFó••ðûö‡ðŽ™\â\èõ\ÝgDŸM—K—M‡F[]6\×VxtûPÀ\Ûn¹dJ\ç\Ësr‹¿pmª€\â§\ÐiŸ\è:ao¦jIu¬iú­\æÈ‹I\Ã^=¼Q\r\Ù\Ù\æ\\\ÆòFLI€vü\Ó+¨¾]õ·\Ü\í\å}“ó¾\êÃŽ¶o\ËþŸ§ªó<:‡^,¸ð«øž/k2xm2[XM>Sf¸m§3m\Ø0\ß/^¼W=^\Ëqñ{Ã¶Z© i–ú“\éK\áøG\ìg¸†4–[—¾Žòi¥A#Ô·˜ +9Â§¾<j›øš[ÁkòIüÄ¾½ÿ\0\à\'úµò\n\ï¼ðÿ\0B\×ü\âOx‡^\Ôtk\r\æ\Î\ÐG¦iQ\ßK3\Ü	ˆ8{ˆB…òs\Ý+®\ËCñ•–™ð¯\Å~–+†¿Õµ\r>\î	TÄ©Ü‡sOœ¸À=q\Æ[ø_}?5\Â\àmx§\àÓ­¿…\î¼úßŒ­µ\Û	/’/\ì_&\ê·ok†Š)g2*€wr]GS\\\åÂ¯\Z\êZ¶§¥\Ùø?_º\Ôô°\rý”\Zd\ï5 # Êw\'ü\nöß„¾:Ñµ¯‡ú®•=Î­¥E¢x÷O\Ô/,aG“÷\Ú\ÄRf%2/˜»&\n\ÊÌ™ù†q\Í/„ÿ\0h/h¾6ƒZº\ÓõG“I\ZE¶©O£\Ù\êW¶qm•\'”¥´’0„±—x\ÂSÔ‘«J\×\ï÷sI/¹%\æ\Óv\Õj¯£v\Ûü¢ÿ\0¿%mw\Ó\Â?\á^x¨øTxŸþcþ¢p5Ÿ°Kö<\ïÙ;nÏ¿òõ\ë\ÇZ–†^0¸º[h¼\'®Kp×­¦ˆSN˜¹ºT\Þ\ÖøŸ4/\ÌS\ï\Î1^¹«|wð¾£ðm|5\åjmª-•Í €i–\Ñ!i5&»I\r\ê\Êg(ª@6\å<¶p¨\rZž<øýðÿ\0\âW\Ä\ëoj\ÚV«yom§ÿ\0g[\ÝZªH²<nói–WS$,Lr\í\ÉaÊ™¾»wþ½_Ý®¯FT•®“\ïÿ\0ýk¦›£\çsA\Ôü3ª\ÜišÆw¤\êV\ä,\Öw\Ð43DHF\0Ž<Ž„U\ZôŽ^>\Ó~#ø\ÚWJ[i›gb\Z\â\Ê6v†Œ°‚cI\\„^`v¯>¢7¶ ü¿¯øaQwº¯LœW±üHøg\áV\Öm¼9¯j>%\Õ4}r\æ\Ê}mZ{‰VBŸe\Ù<¦nb`W\n\ÃrðsÇŽ\Æ\ÛdV=\Í}K\â\ßÚ‹\Ã\ZÇŽ¬µÇ¼ñO‰\í—\Å6Z\äë–°£hv\ÐË¾K{/ô‰wyƒh#1/\î“ ðV\ÚME.¯_¾?§7õbj\ï\ÉþOõ±ó„~ñ\Ñ\éòG¡jO¡t\ÖVl¶rsp¤+C\Ç\Îà²‚«“’8\æ¡ñ†uj’išö“}¢jQ…g³\Ômž\ÞedŽ\0ŽGô¾ñ¿Á>(XdÔ¥¾ðö›\à\Û\ë\íkE³[h.\ÖD¶‚\ÕZh„“‰Œ—R€\Û_Ÿ—\Ê>?jž\×õO	j~Õ¦\Ô\ì\äðí¤‰yp\\Á%°kR%%”)q\0”\r\Ù\Û*ýNwvM­\íø¦þM5c[+»=¯÷§ú§s\ËiQwº¯LœRS£m²+€æ¶§\ËÎ¹¶¹™\îw\ß<\Ä-wÀ\Öþ8\×fñ—ó/†aŽ\ÒG¶‚I™|Á~\Î—\Üq^Uyðó\ÅZw‡ÿ\0·nü3¬[h»ÿ\0‰œ\Ö¥·\ïZ?Þ•\Ûó++y\ê+Ð¦øÅ¢\ÉûBxŸ\Çb\Öÿ\0û#S\Z †->Ð¿iµš÷.ý£\r\"“†<Œô®\ë\â—\Ä\r\Â:m¤f\çX\Ô<A©xD\ÒM¸…?³ „\Ãm9I\æ\î\'\ä8\Ê\03\ÜzV1¿,e\'ºWõ÷¯ù%\å{”µ—/õ¼W\ë=Ö¾ø£Ãšn¨j\Þ\Õô»\rHeu{a,1])™@|‚\ÊOTº\ß\Ã_xj\êkm_\Â\ÚÖ•q\r¯\Ûe†ûNšKr\á<\æ „\ÞB\î<dœ×µ^þÑ¾\Òüc{\â\ßZ\Õo5¯XxP\Òõh\âŠ3n\ï!†G2’\ÒY#Úª>C»\å\Ò\Òÿ\0j\Â>(¿\Õ,ž\ïÄ¶o§\Ü[\Ùi÷^Ó´T·–K\ËY·1³”‡m°\ç®¨BœœR¿]7ü“·\ßu}´ÿ\0/\Î\Ï\îZ\Û\Ìñ[ÿ\0¬ôû»û\0x¢Eg¸¹“F¹X¡Ub\ìS\n\0\ä“\ÐW^‘¨x\Û\Ã\Ö^\rñ×‡´¹µA5­SO¿³¼\Ô\à%\Ù\n\Üy‚m²7Ïºp\îÁ$&v×›\ÒW¿\Ýù&ÿ\0>Cv\n\ì<\à;iz®»¬\ê§CðÎ”\ÑGuy·\Úg’iwyPÁ\ä#lvù*1-œ\Ç\×y\àh6\Þ×¼)\â¨\ï\ÓE\Õ%‚ò=CJŠ9®l\î¡YD\ì‹*2\Ê\êÉ½:†\åÁ®Ž\Ûÿ\0_¥\í\çb{_\×ù>ø\Z>%jÚ¬ž\Ôõ\rSÃºjBò\Ü.‹,š” b!Ž\Î—t¤G)½\ár\Ò&p9;†¾#\×o5Á\á\ß\ëúÝŽ‘+­\Ì\Ñ\éRy–\Ê`\Ü\"o¶‰R\ÇnN3]~ƒ\ã\é¾ñG‚\ßVñ4\Õ%²½UƒN®ž\â\ß\ÌdµûJ¨„\Íÿ\0-Ø†‰œ;‹¯\Ú#Âž#\× \Ôõ%ñ&•&\âwñœšz\Å;\êŠ\Þ0—24‰\åIþŠ¤Ê«/ú\×ùxù“\ßG§ü¯\Ê\î\Ëvk\Ûú³\Óç¦»+žkðó\ÅWú\Úí·†u‹~\Ñ&¥„­l‘\îe\Þ\Ò\Úr:\äœeXv4\Èü\âi¡ycð\î­$H-™le*¢\ãþ=\É;x\älþþ~\\\×Ðº‡Ä­\Ã?þ\Zø‡Q¸\Õÿ\0µÿ\0±5\Ãc£YÂ§O‘\î¯/\"c#™U£¸xERW¬/|tð7¬|c¯i\Z©\Óü-›–v±F\"\ÕBA7Bq\æŒ0.A’\Èv0O¼­>Žß‹Oò_x\å¥\í®ÿ\0¥¾ó\Ä<M\áwÁ:\ÓüE¢j:\rùŒJ-u;I-¥(I¶8ƒ\Î;\ZÉ¯Rø\çñ+Fø‚ž·Ñ\ÃÅ£X\Ëk$\Ò\èÖšJH\Ïq$ ¥µ«4h\0Iœ“^[J-½üÊ’I\Ùz\æ—ðGHš\ã\Ãú§\â\Ù4\ß\ëöñ\\YicMZE\ç¨kh\înL\Ê\Ñ< ©ùb(‘7–\Û\äu\í:g\ÅM\âx\ÛX·Ö‹4kHÎ“io\Øu	­R\ÞV¹2‡„mH·¢\Âùò\Û»þJ\Ò\Úÿ\0Áµžß‡ü5íž·Ó¶žºZÿ\0+œ¡ð—\Ç\ZG‡\Û^¾ðn¿i¡*«Rm2tµ\Ú\Ä*·šWf	 œE>û\àÿ\0t\Û\Í2\ÒóÁ#´»\Õ¥„\é7	%\Û¸ˆ”¦\\\ÏËž+¡Ó¾ x{Xð†ƒ øœ\ê!ñ-æµ©Oco­$3C\ìŒ4©ó–…\ÉC7–º\ë_^\×\î\Þ)\Ñ\îdi¼G«ëŒ‘\ÚC{\r±¹¶Š;b!•\Õgò¤Œ\íF\0H%ik\×ú\ÛO\Åý\Ú\Ú\å»_O?\Öß’¿®‡”Yü/ñ–£\âK¿\ÚxK]ºñšy—:L:l\Ïuü¿3\Äry#ø‡¨ªqø\'\ÄS[¼ñ\è\Z¤¥¬—\Í\"\Ù\ÈUm\ãs“·ˆ\ÑÁVn†	\Í}Ccñ§\á¼\ZµŸŽ.µmb;\Énô<YYhvK?Ù´Å¶šB\Ð%\Ôin“Ê±\Ø\n¨·`\í\Ê|Lø±\àù<ÿ\0\r×·\Öz%\ÕÜ‘\ëºLql\Ô\å[\ë™\"ñ6\Z\Ý\ãœÀ“ä…G{%\Öÿ\0\Óüvß t\æôýn¾MZûu<+\Ä\Þñ\'‚\ÖÍ¼C\á\íWB[\Ô2ZN\Ê[q:Œe“zÃ‘\Èõ‰^\Õñ¿\âÇ„|e\á\r+@ð¥Õ–«uhÖštvðKI9‚Gi\ÝX3Jw¿×Š\ÒN\íÿ\0_\×`\èŸõýuù…z¯Á\ãð>…\ãW\\m;\Ãw\Ö\Ý\ÜÜ­Ÿ˜ñL.f‚+XPÈ¾t²Kõ@ªž\'\Ë+Ú­þ4xVøc\áo‡úýž¡>…cap“O1´ö7\Íu<\Ñ\\Ú‚\à0)\"\Ç\"1@\ã=\n#/ƒM\ïøY\ßô·¯¥Ä·W\ÛúþŸ–Úže?€|Ok\áx<I7‡5h¼;;l‹W’\ÆU´‘²W1]„\ä€zƒD¾ñ4\Z\åÞ‹\'‡5hõ‹8Z\â\çOkE\Ä1*i=»•BÄ‘Œô¯S\×>3xnóC¿¾µ:\×ü$:—†¬¼3>•,®@!S2J%.ù\ê\Â#…y	\Þ\Û~n\ßXý«<+©x\×^ñ*i:ª\êZ¤:†•%\ÃC\æ\Ó\ä†\ã\ì\à\âN$\Í¿$\í\Ó‰\Å)û·\å\×\Ão¿O½öuJÿ\0\Ö\×ýWª]óÜŸ\r|]Ÿ¤_¿…u¤±\Ö%H4Û–Ó¦^\Èÿ\0q!m¸‘›°\\“Ú¨[xWZ¼û/\Ùô{ùþ\×vtû.\Õ\ÛÎ¹s`|\Ò\r\éò~e\ã‘_@\è?´€ü/¡øf\ÏL\Ó5XìµTº³‡F³ˆ¡³\ÜnOÚ–O:\í¤ww_7hL\íEYðg\Æ\ïøª\Ê¯\Ï‹q\ámCPñ\rš\é:„\å\å[h-U!\àYfŽL\Ì\Ù\ä¤8\Üz­=¶¶ü½\ßóp£­¯\Ö\ß{¿\ê’ùžÁÿ\0Ï«_\éQø\'\Ärj–¬\×vK¤\Ü­£a•yf\äR9€\rr5õ­¿\Æ?†ñ\'…|M\rÆ¡ª\Ý&£ùW/¡X]\ÝB–>e¼\Ö\ï·¶²J`†e™HªÀg\'\å]bñ5\r^ú\ê0\Ëó¼ª¨ÄŒûóR\î¥\Ë\ëø?\ë\î},\Ç\ÒþŸŠ\×\îýW[•+wÀþ\r½ñ\ï‰-ô{ ·’D’inn˜¬6ðÆ$²\È@$*\"³x\àXU\Ôü4ñ¤^ñl:ÍöžŸ$\Ù^Ù¬‚6š\ÞxžU_kls†ÁÁƒÒ­^½/\å}\Éek\Â:\íÅ½¯õmgÅ—\Ä\É\çZÍ¡ýšM¨…Ì‘æ˜ºW$¶\Â\0n3¶œŸüe‰\âð\ÛøK]OM›\Úl\Â\í\Ó\î\í\ÞF9\Ç@k\×~ÿ\0\Â£üf\Ón<-¬øš\è-†±,“\Þ\ØAc5¬cN¹+\åywï“¾\âc\0¨ãŸ–o\r||ð¯…~Í [ÿ\0j\Þ\èxr}kZŽgut%’ð]\ïûò\ÉDU<³\'B\Î\nš]\Õÿ\0ô¯\Õ%ó\Ð\×\â¿MlxÍ\Ã_jSk1Yø[Z»—E$j‰3µ†7g\Ïu÷±÷O¡©´o…>6ñ™g¨\é>\×õ=>òS\rµÝž™<\ÑO \ÎQT†aµ¸?)ô¯¥<ñ\á\ì:žŠúŸõO\ÅS\ÜIy|¾°³‚\Ù\Ú}2\ÙnR;À–\Âyf!A$C\ÇZðß‰\Þ.ðÏ\ìô}N\Í^\Û\Ä6\Z}ž•&–l¢}<%º¼\Ènû\Ô:¢¿—\äð\Îÿ\01\ëT¾%¶šýü\ßsü\î;^öóÿ\0÷«»ü·fgü(Ÿ‰Fök1ð÷\Å_k‚%ž[\ìKŸ28Ø°WeÙ¤£€Ocz\Z\Ãÿ\0„Ä¿ð‹·‰\á\Õ\áWòŽ±ö)~\ÆvÝ¦m»3»Œg¯ô†¿iO	Xø\ë\â.³w­ki\âYkb=\Òò_.š3\æÌ¿g‘¼\Õ\Û4DºJœ\×1cñ‡Á\Z_\ÂMoA\Ót»\Í;XÕ´¹l§„iv“™¯e™õ´ò’4òB*ewrI5\ß-\í\Ñ}ö¿ü]Z°+9[\Ïúû·ô\Ò÷<*Š(«\èŸþøo\âF©6•ªøU\Ðõ!\r\Í\ÔKg£EyE»\Îå®¢*\ÄFÀ(R	\ÆHí„¾\Ô|A&µy\á\r+^ñ\'‡ôµó\'Ô†’\Ê`imó¬m*\Ä0¬yr0¤\ç®-ü$ñ•—€üf5}B+‰­¿³\ï\í6\Û*³\ïž\Îh\áˆ\r\"“\Ï@q“\Åw\ß¾7ižøfž¸»¹Ðµ;-V}J\ÓRµðÖŸ¬ùžl1\ÆT‹§F\ÔÄ¸’6$† ”\Z%Õ®\Ë\ï»_– ·I÷ý?¤yÆð§\Æ\Þ\"\Ó,õ\'Á\Úþ§§\ÞJa¶»³\Ó\'š)\ä\Ê#ª\Ì6·\0\ç\å>”\Ýs\áoŒü3/•¬xG]Ò¥\ÌK²ûMš™K,C£—1¸_\ïlgº‰0ð×4\íVŽ\çW³ñ–›e¦K¤5”O`©o‹|Wpuª\Ë0ð\Îÿ\01\ë]\í\Ç\í A«|WÕ¬´\ÍAõ/kÚ®ƒ$\é[9#ûBù³\r\Íó Ÿr\ÈÞªI\ã¬¯kõü.¿4\ÛùX:/4¾Oþ\ãº<’\Ó\á?Ž5	¯bµðoˆ.e²ycºHt¹Ù xÂ™UÀO” t\Ü1¹sŒŠ¥c\à/jžºñŸ‡uk¿\Ú1[V^\Ö1ò…Ú¤n^§¸õ¯¨u?‹ž\Ô<?o\ã»Ë¿Xi­ñ\"û]²±±†2÷/½£,sfuHó\ÈT3aNk\Îl>:xy´\íVºM^\×Äº©\é\ÖúM”6\ì]\Épþc\Êej`\È#}\â%—wË“rQ\Û[/\Æ)þn\Ö\Ýo°ÕŸFÿ\0V¿K\ß\ÎÇ–^|2ñ†›¥éš•ß„õ\Ë];Txã°¼›N™!»icXœ®°\ä\'#¥E­|;ñ_†\ïn¬õo\ë\Z]Ý­°½¸·½°–!·,J\ê\Ê\n¡bq\ã$æ½¿Zøõ\à{\Ã\ÞÓµM/T\Õ\í¬N‰¡§ÿ\0g[Y\'—gnbŸ7Jd»ß¸\ìY‚l‚•\ÜjM_ö–\Ð-a•4{y/g\Â\Ó\èpIy\á6\ÖÕ§“QK \Íb…\àX\Â–\Ãc\'\"å£•º7÷%u÷½m/\Å\ë÷#ÁÁºüq‰CÔ–3ö|1´ß©k~qÿ\0-Ÿ\Þ\0‘š¹oð\Ï\ÆGZøS\\˜\è™þ\Õòô\é›\ìŸ?û¬cóc\îŸJö\Ë\Ï\Ú{D“Kñ\ÌzU\ÑñÕŽ„št‰kookkygk,\Í\å¡Ú¡L¥\âTP*nÓ¡¨~\Ô\Z­/‰M¼Ú‡‡fŸÄ—š\æŸ}ÿ\0Æ›¬J\Ë<q¡G[™\ÛÈ¾R\âHœ\ä1| Ò\ã\Ín—ÿ\0\Û\Íý\ÃV÷o\Öß•\ß\ã§\æ|¿ES¿\à/\Ë\ã¿išWf.\äÄ·R.å·…Aye#¸DVb?Ù«~2øw¨x[\ÅZ\æ“l²\ë\Úb-Ñ¿µ¶5£\ì1\\0ØŒ²\Äy8À\Íj|)ñö‘ð\í|I}{¢¦»ª^iÍ§X\Ú\Ý\ÕVVp\Ò4R\Ç >Vô]‡þZ‘Ž}\n\Ú7B†\Æ}B\×\ÃvúWˆeð«xp\Ú\Åb—\ÚnR\îmÝ’òI™À…™»#\Çt——g÷\ëþK\ï}‚;\ë\Ý~kü\ßÜ»žI¤ü1ñˆ&š/\Âz\æ¥46ñ\ÞI¦›4¬H»£•‚©\Â2òðG \ÔzÃ¯x£G¼Õ´ok:¾•g»\í7\Ö:|³Á\Õ\Ü\Û\ÝTª\áy9<k\ß<9ûHx\"?Yx«UÒ® \Ö- \Ñnm¼?§Ü‚- 	s0\È\ë¨y&‰w¨L*¦H®OCø\Õ\á¯\r\\hpY[j“XÁ·w}4Æ’\Éyh\Öê¨‚Rq\ÌX—;G\0©]s%\çoU·ß·¯“CŽ¶¿—\å¯\Üÿ\0\Ý3Ê ð\'‰n¼\ß\'\ÃÚ¬\ÞL\ÝI\å\ÙJ\Û!›o“!\Âð¹v±\á·g4\Ïø/\Ä>¾Ž\ËÄš§\áû\É#%¾©g%´Œ„+¨%r\ÏLƒ^\åª~\Ñ~\Z\Ô<\'s\á¸,uK-C\Âv\Z6¡t°E$“_@m\Ì\Û\æ/\îcŠ	v\Ù-+d.\ï—Î¾/x\ÛBñe¿†­4F¼ºþË´’	¯®´\Ø4µ—t…•R\Î\ÞI\"ˆ(<²dffažK–’²\Úÿ\0\çþK\Õ?GX\Ý\ïÿ\0›_#\Îh¢Šz\æ—ðGHš\ã\Ãú§\â\Ù4\ß\ëöñ\\YicMZE\ç¨kh\înL\Ê\Ñ< ©ùb(‘7–\Û\ç\Ñø\ÄsE$±\è\Zœ±Gm-\ëIœŒ¢\Þ71\É6@Ç–®\n—\èÁ9¯N\Ó>(ø*oxc\Æ\ÚÅ¾´|Y \ÛZFt›Kx¾Ã¨MhŠ–òµÉ”<#jE½Ï–\Øe\ßòY\Ö~9hž+ø1¤ø\'S‡R³¾²Žk\É5;(Q\Íá»¸™!”Fø\n\Ügw\r‚B¸5V\\\ß?\Ã]~\íþKF\Â?\n¿—\ßm¾oTy×„õ\Ë¿[P·m>tµ¼Úº›iŸv\È\ä\Èù¶6\à§\Ð\Ô\Þ*ð/‰<q¿‰<=ªøz{„ó!‹U²–Ù¤\\\ãr‡PH\Ïq_@êŸµÅ…ßŠõ\ÝTh‰5³ø³M\×ô\ØcÒ¬\ì¥x-žft¹š\Þò16³™0wúùo\Äoø~÷\Âvž\Zð\ÝÞµªÙ®­u¬K{¯[\Ço*\É*¢yI\ZM(\Æs9`\\‘ò®\Þr»²vþ­óuºogýoþI|\ï\ÐóZ(¢¬G iô=?\Ã:^µ\ã/\ÞhQ\ë\ä\Ólô½-o\î$…£i\å4+eÕ•p\ÌÄ£| \0[6\Ï\áu]]oKð–½«x}Ž5‹=*\á\í8\É\âM˜\Ú6œ\çÁ\Î0k~\ß\Åñ‡ƒ|?¥ø¶}sF\Õ<?\Ù\Û^\è\Ö\Þ\Çwj\Ò\É0II¡1º<‡ûƒ\0Tm\É\Úðÿ\0\ÆmF¸ð1û¥\ä\è:±¥L»cvg»7žQS¸nP.c\ÜHS\Ã`2ONg;zYµóvKÕ¿ Ž\Êÿ\0\×õýu<\âó\áçŠ´\ïÿ\0n\ÝøgX¶\Ðÿ\0wÿ\09¬%Ko\Þ*´½+·\æVVò\ÔU¹þx\æ\×T\Ó4Ù¼\âµQ\ZK94©\ÖkµU\Ü\ÍË€¼’ \às^\ãñCÇº…t\ÛHg¸Öµ=kSð‰£ÿ\0eÈˆ¶Û´6\Ó4‹/š[8Cˆü¬rûJ¹\í%\à\r\'[ð\àÒ¬µ+]M¼Õ§X#ðÞŸµ†\ê\Ç\ì\Ð\Å\å,\Ûn\Ú2\é\'m\ÒózS–ŽIkkþ\r«|ôw\ÛtõZ¨\ê“z]_ð¿\ç§}š\Ðù\â\ã\áÏ‹,õIô\Ùü/¬Ã¨Áq\r¤¶riò¬\Ñ\Í0&™\n\ä<€ªF[f–ó\áÏ‹4ý\n\ç[ºð¾µm£[N\Ö\Ó\ê3ió%¼R«\ìh\ÚB»Uƒü¥I\È<u¯u°ý¥¼+¥O\ã#\Óõk‹}~.Åµ·†\Ö\â(à´ž\Þ{ˆ\"I\nZÉ‰WË…F2eAãž³ø±\à?ü%\Öü3£[j¨\ê\Z\\ºt’É¡Ù£\\\ÊoU¹’\ï\Íy\ÑLQÆ¦\Ýv¬¹\ËL6\Òv\éø\éùt\ïª\ÓFVœ\Éz|¿\á¿MõG„\ÑEB\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€=3Iø©k\Ó5ˆ<A¢\íSO»\Õ,´\'7_mžf”LAy ¬\Ê	\Ç$\nó:ú[\Ã¼+gð\Â\Ún£\â\r$Ác¡jz~£¡¦“/ö¼³M=\Ã\Â!½\r‘þò&u\n¥C«#\ä«i[ügðœZ§…¥“\ÅA¯lVX5=[\ìS±¼\ÔOò­u|÷7ÙœˆðÀIû¿9T¼®–“•¶_\ç/\Ñ/½=\ìGU¯Ÿ\éÿ\0\î\Ò\î\Éü¯E}c¢ø’\ÏPVñ}\×\Ä\ËIüA\á´øM.WQ\rs¨_5À‡-¹¹a\r²\Î’\"\á| 5y\í>‘Iñ\Ó\Å:…µ\äZ…Ž¯4z½¥\Ì!À’˜’x‰ªÀ\ì‘r\àæ¥¶¤—¯Ë·Þµÿ\01¥t\ßõ\Ó_K»zö<²Š(¦ ®÷Gñ©¡ü=Ó¿³u+½?\Í\Õ/<Ï²\Î\Ño\ÄV¸\Î\Ò3ŒŸ\Ì\×]tòOtŸû\n_\è«J\ãðóÁú—‹üo«]x\Ï\ÄP\Ý\Üù»7\Í\åÇµ\ÙA$·+ž£®=\ë\Ë<?\âýwT¸\Ô-ou­F\î\ÚM/P\ß÷r:6-&# œ@?…{\Û|ðô,‰b/4\ë7$]\Ù\Û\ÞJ#»\\,™lð}\ê}xñŸhv^ø\â\r;Nƒ\ìöp\éwž\\{Ù±9\ØòÄž¤÷©Ç¨¢Š \n(©#?+.s\ßk)À<õ\ê;}\étŒÛ™òI\Ü\ÝO¹¯køKðFñ‚\åñŸµ¹´?4¿gµ[@÷i+ò¶~`@UV\'\r\Óô\áðõ13\ä§\ë\èŽlF\"ž\Zõ==Y\âTW¿üyý™aøm\á¸|M\á\ë\ë»\í(·\êx7\à+*ðI\0‚ ‚G^q\àXœ5\\%OgUY‹\rŠ¥‹§\í); ¢Š\ÒÐ´V\ÖnY7yq Ë·`+\ê3h®ž\ïÂ¶¬³\Çeq#]B2\ÑJ:ý8s\0F21úh©\'ÿ\0–õ\Â/ýµ\ï~øO\â\ïµ]gW‘/‹´\"q h\ËC \ß#c\È\Ûº;µbb\0|+Vó\ÏcZt\åV\\±<Šö\Ûƒ~\Ô<¬\\\\A\â\ëVö-y¤_\ÞG,ºn¾°Á,ó<­\"1©Ž-\é½\ÉÃŽ¤\Zñ*\Ý;™Wgðÿ\0Á¶:íž¥¬ê·m¦is\Ú\Ç$Q\Ûy\Æf•Ÿj¶eˆ\"b6\Ü\æE\ÆG<\äkNœªË’™T©\ZQ\çž\ÇEz¿\Ä\ïøþK˜|\'\â½?N\ÓR\Ù\ã¼3Ä²œ\îH¥…&\Þ$œe°¹ÇŸx§Ã²øWYm>[«{\ï\ÜÁp—»ü¹#–•Þª\ßvE\à¨ æ¢ªT«Jƒwk¶\ß&U){jQ¬•“\ï¿\Í4Wªøo\áN“¬~Ï¾&ñ\Ô\×««éšŠZCn‚B\Ö\à–R¥‰ýóta\Ð{\çcFø3\á?x\ÄzÇ‡õ\Ë\é/t-\ÓQ»Y\Ôyb\ì­\Ã\ÜÁƒ\Z’\0‰vH\É9-Û¶8*²i+]®e¯MÉœr\ÆÒÛ½“\åzu\Óü\Ñ\âTQ]ÿ\0À_\r\è\Þ.øµ hþ ….4›¶™%‰\æhƒ·“!A¹H \ïŒNz\å¥MÖ©\ZqÝ´¾óª­EFœªKd›ûŽ…Ž\0\É\ç\ì2A_Aø\ãöi›ÀŸ	5sY‚\Þ\×T\Ó\ÔE-\ÛÌ·L÷2,Œ\ê\Ê|’À /üñ\Ïñ\Zð_øúO÷%ÿ\0\ÑOZ\â0\Õ0­Fª³jÿ\0§\èe‡\Ä\Ó\Å\'*N\é;~¿©·\à}ø\×\Ãú5Ã¼vú†¡oi#ÇÊ²H¨H\Ï|\Zú#\âW\Ão†_\ä€kž½ñA\Õ.¥’-º—\ÙÅ¤\Î\ÔDY¹U\Ú0Á?\Ä3Š\Ûƒž\"œª¦”c»ð2\Äc!‡©\ZM7)l—ü—(¯Bø\áðÿ\0Mø}\â\ëX´[‰n4]R\ÂR\Ë\Ïÿ\0X‘I¸n ©ü\Ï9¯=®ZÔ¥F£§=\Ñ\ÕF¬kSU!³\n(­{{{;6»¸Z\é§fÆ®T\0	$w¬MLŠ+£Ô´hôyuK !#,8##¨\ä~U\ÎPF	À\ÆO¦s\ä**H¿\ã\Ú\çýø¿””\0\èl\åž=\ênq–u^\ïOþÎŸþ™ÿ\0\ß\Ôÿ\0\Z±h»\ì\â^™•‡\èµ\ì>ø£øvo\Ø\è>+ºÖµŸ°mN\ÆûI~d>b\ÄòÛºO/˜\Ý7­‘œî«¿\êÖ¿\Ýp\Ý\Øñ\ì\éÿ\0\éŸýýOñ£û:úgÿ\0Sük\Ò|%ðK\Äzæ¹¦Yjúf©\á\Ë]R\Âòþ\Æö÷M‘R\é`µ{ŒE»hpÁTeI\Æðy\èy½_À>\'ðý\íÝž©\á\Í[M»´·—÷–2\Å$0\n%ueP³(\Üx\É<\Ðý\×gýoþL7\Øæ¿³§ÿ\0¦÷õ?Æ\ì\éÿ\0\éŸýýOñ®ŸMø{\â­fñ\í4ÿ\0\rk\×ih·\íµ„²:\Û0³U$FC)Ð‚9\æ²5=.óE\Ô.,5I\ì/­\Ü\Ç5µ\Ôm‘°ê¬¬\Ø\Ñ\äötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ5=RkY-\ÕK…\Ãd¬§\ÐûÓ£±šH\ÕÀP­\È\Ý\"Žø\îjk\ßøõƒý÷þKR/üz\Û¸ô6¦\ì\éÿ\0\éŸýýOñ£û:úgÿ\0Sük\Ó>\"|Ô¼u\á\Ë[kƒ¯^j\È {k;v2A~6y–{A%\Ý|Ø¹K\ãW;ªü7ñv‚Šú—…µ­9\Z\ÔÞ†ºÓ¦ˆpT†\å .£wO˜sÈ¥\æœ¯ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ5\Ð\é>\Öõ­kCÒ­ôÛ{­¼k§$Ñ˜\Å\Î÷1«!l»‡S\èkµ±øa\á=k\Æ\Z\'…t¿\\\ßkWš­¶™q0Ñ¶Ø2A\Éo)Ÿ|¡KdŽ-Àp\rY¶—}Ì’o¢\ÔòŸ\ì\éÿ\0\éŸýýOñ£û:úgÿ\0Sük\Ûcø¦k7ZtºŠnot›“«[\Ëq}¥-´ð\\\ØÚ›†ŒÄ³È¬®»0\áø\Ür¼`ð^\nû7\Ã];Å¿l\Ýö\ÍZ\çKû•žT0É¿~\îs\çc\ãnrs\Äs+_\Ñý\î\Ë\ïÿ\0ƒ±n-;??\Â÷ü™\Èÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ãS\ÑL’\ì\éÿ\0\éŸýýOñ£û:úgÿ\0Süjz(\ì\éÿ\0\éŸýýOñ£û:úgÿ\0Süjz(\Ógf\0\É<\0%Oñªµ«iÿ\0Pÿ\0¾¿Î²¨\0¢½{\á\ß\ìó¨üRø[\â=\n\ã\Ì\Ö,µ	-N)\n³Æ±D\ãcv|»px<r1Ï”\ê\Z}Ö“}=í¼¶—p9I`™\n:0\ê=\re\Z°œœbõ[˜Â´*I\Â/U¹^Š\ï¼ðÿ\0B\×ü\âOx‡^\Ôtk\r\æ\Î\ÐG¦iQ\ßK3\Ü	ˆ8{ˆB…òs\Ý*_ˆ_mü7\á\Ïø\Ã\×Ú¦¿\á\íVÑ®^\îóImh\Â\âXHih\\¯\Ï\È\íÁ­e\î\ï\åø«¯À\Ûs\Ï(®“Oøg\ã\rZKø\ì|)®^Ia\\Ý­¾4†\ÞM\é$€/È¬Ÿ0c€G#Š§7ƒuû}>\æú]RŠ\Æ\Ö(&ž\å\í$\Å\ã0;±Ur„ðÝ³@ôQE\0ŒŒd>„d\Z*Iÿ\0\å‡ýp‹ÿ\0E­{ÀÙ¾\ß\âö†\ÚõÞ¸\ÖV¶º—\Ùf±K]\ædU\ÛoIG\Ý8\Æy\é\\ØŒM,-?kU\ÙQ£:ó\ä‚\Ôðª+\ì¯~\Ëþð÷…<M«%ž•\ä\Ùé·—0G7\Ë22\Â\í\Þ×®¤«\'1pFxøÖ°Á\ã©c¢\åFúw5\ÄaªašU:…T\Êÿ\0»{p6\ç<®w| g¡\ïõüý†Š\ßø}£\Ûx‹Ç¾\ZÒ¯Už\ÎûS¶µ™U¶’*«\0{[ÿ\0\Z>ÿ\0Â§ñ|º\\z¥®©h\ãÌ\ã™È¤XÁ\Ê69##¸\n„\åI\ÖK\ÝN\Æ¼#UQo\Þj\çE\ÙxÂ¾Õ­\'\Õ|O¬^iZE®£ge/\Øl\Ä\î\Âa33\\l\n°7!d?0Âœ`\çN¤¹cþEÔ¨©Çš_\æq´W\Ò\×>\0ðNŸ¥\Â \Ñü=q3ivW6ª\êi\×m-”2\ï¸VÖ¡0‘\ß\åX˜*\à©pkÁ<in-<My±\Ó4Ð»?\Ñt{ß¶Z§È§\ä—Í—vzŸ\Þ6	#Œ`fhb`\àpz^qüÁü¨©$ÿ\0[O÷ÿ\0F½jøoM\ÒuI¾Ï¨j7V2OPy6\Ñ<L¬\ádi$’x„{T\äg*Ç†d5\0cQ^‘\â\ï†~ðÿ\0‡nõI¨\ÝC³e³/—U?\êu¤\à~XÛ§8#\Í\éFJZ¦Ld¥¬]ÂŠõ«?‡¾\Ö<#=Ö•ª\ê·Ú•¶ŒÚõ\ÎÁ¦Ÿp±+}š@ñ\r\æI7¢2?qÁ\ÆN/\Ä‚ú\ÏÃ\ZKPŸÍ†[…·û/RµùŠ³}\ë›Xð‡€Å½°	5hÊœšwí©*Ñ­t“V\î¬yú‚\Ç\0dóÀö? ¢¤µÿ\0¤ÿ\0r_ýõ\Ñ|/\Ñ\ìüEñ3\ÂZN¡\Ú4û\í^\Ò\Ö\âÌ»\ãy‘]r¤H\È \×9\Ðs4W\é§ü1\Ï\Âúò§yÿ\0Ç«\á\ÚSÁº?\Ãÿ\0^#\Ðt?°i6Ÿfòmü×“fûh¾g%ŽY˜ò{\ÒN\ày•5œqMuM\'“6ñœ\n\é?\á²º\Ö#·ŠI<¿\ãŽ8\Øm]¤†\Þr9 Æ˜­cP·[MB\æ$¤R²\Ýp	Ö‡‡´û;\é±q7Ï’<Ÿ-¾\î>ö\àp?\Z\0Ç¢º˜|+m&•}v^r\"Whd\È \0qŒ\ãù\×-@³g¤\Åc»Z\Ý\Ô\í<\ç\Î\ê~\\÷©µ\ï\Æ;¥¹,Ž\"¦\0\È\'®y\éEÀÀ¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0®ƒIñönŽšlú>Ÿ©ÁÄ—µÑY\Õ€ò\å@F#^ ÷®~Š\0\ê?\á4³ÿ\0¡SFÿ\0¿—Ÿü‘NO%¼weð\î“i4\ÐKo\ç\Æ\×LÈ²FÑ±§+¬zƒ\\­\0QE\0T‘Ÿ•—9ïµŽ\àzõ¾¿Ž—q\ÚW\'i9#·ù\ä\Ð\ÈÛ¤f\ÜÏ’N\æ\ê}\Í}\rð\ÏVð?\ÄÏ„ºüS¬C\á[D¸–m>þ\íöÁ\"I!v\r–Pyb\n–S÷Jžµó\Ã1v,Ä³’OSI]˜lC\ÃÉ¾U$Õš}QÉ‰Ã¬DR\æqi\Ý5ÑŸK|iñ\Ã_|;Ô¼\'\àSi{©k¦\Ø\ê7\Z}Ô“À«ùŠC<Ž-I\àœž~r\Óu+­P·¾±\í®\í\ÜIÑœ2°\ïU¨£‰x©©r¨¤¬’\ÙM‹†XX8ó96\î\Û\Ýôü‘\Ðx\Û\Çz\Ç\Ä\rXj\Z\ÅÀšUAq \Ûj;*ö\É\ä\Õ\ÞZB\×·£ý\à.[$\0T\ägEq‡]ÿ\0­I¯!ž9¤\Æ!†&\Î>¼ŸÎ¹\Z( 	\'ÿ\0–õ\Â/ýµ\êÿ\0´½3\Å^¶Ð­\Ï\Ú5ùÎ¹\ç\év±Î·7±\r69\ìÁd]²¢]Zn\'yR‚My+9}¹þTE\0\åIHr\Ñôßˆø3ñDÖ´]_Eð\Ï\Ù\"¾‰oôÆ~\Ø×¶Q²²É‹z\í\r‚7qÖ¼>9^HÝ£‘ee8 Ž„ZmÀ\éüeñ\'_ñôv\ë7¦\â;8\ÂFª6‚{»\ì{šôO\Ùw\Âz/Žµ\ï\è:ž¥ª\é·7ºv\È[L¼ò<\È÷9`‡\Ê\àm`Wi~3‚<RŠÂ½9Ô¦\áNnº\èiNQŒÓœy—f}—\âØ¯\Ã\Ðøvýô\rKW“XŽÖ±\ÞMD\î9\nØO=3ž	ž•ó\'\Åxd¶ñd\ÍE,z>’‚Xi\Ö\à‚B\rqôW^„œ«V\çù[·›\ìt×­J¢µ:|¿?ø\Ø±ßŽ¼7á†z®±\â+Iº}^YV\ëØ¡vC\00V`qF}zw\Å/Š^\Ô>øº\Ö\×\Å\Ú\Í\ÔúE\äQC¥¼ŽÐ¸UU\r’I \0+óºŠûŠ9\ÝJ8u‡PVJ\Ç\ÇV\É)\Ö\Ä<C›»w\ný\'¼ø/¢_ø\âÿ\0Ä·77\Ó\É}$s\\i\Ò¬´–\Èq\å\ïId\èýN{~lQ\\Xt0|\Üôù®\ÓZ\Ú\Í_\É÷;qø\ã9y*r\Ù4ô½Ó·š\ìwþ$øõ\ã\Ïxfo\ë\Zû\ßi3,i$2[B\Â2²\å\Â\'r©\Îrq\Îk„µÿ\0¤ÿ\0r_ýõ,nc8\ê}Ô©ý\ryµ*Ô¬ùªI·\æ\îzT\éS¢¹i\Å%\ä¬%z\ÏÂ¿xKMðüž:ñµü7:e´\æ=\Ú@\×³¨¿Â€×®yÀÀo&¢®…HÑŸ;7k\í\×ÐŠô\åZŠ\\½í½¿OSªø™ñPø¡â©µ½B8\íò‹½¬?\ê\í\á_º‹ù“õ\'§J«\àŸ\ëõc¨h÷YrF\ãtr)\ì\Ë\ß‘\\ýIÊ¬œ\æ\îÙ­:q§+$YÔµ+­cP¸¾¾\în\î\É,\Ò³1\ïVô\ÝB	-þ\Ã|¹¶\')*ý\è˜÷úV]™e‹\ëScrðù©(‡Œ\äy³FÁ”•e9i( \rMk\ÄÚ‡ˆ\ÝogóÚ ¼}O½g\Åÿ\0\×?\ï\Åü¤¨\éU\Ê\Ç\"ŽTŸø\ì\èF€4,\Ûm¬Lz	˜þ‹^\áñ\â÷„®<A\ã­\Â\ÃY¾\Õ<^\Æ9“X³Š\Ö+v™&‘ËžS;9Wq\Øw|¬Xmð‹{ÄŽ\ÄÏ†,\n¾:\ì})ÿ\0mƒþxIÿ\0Gÿ\0Uw¥º_ñµÿ\0 >§¾ý¨<=yñ-öµkcq5\Ý\ÝÎ•c\á\Í6\Ò{I¦²ž\0\é}‹%\Ë#\Í\ÃJªvò~aƒ\Ç\Ûü\\ð…½„~3\ë\Óxhxj\ãCmfK÷™-\ê\Ý\ï\ßi\ØYy\Ý6rv×„}¶ù\á\'ýýüMmƒþxIÿ\0Gÿ\0QÊ¶ò·\Ê\Í~Mÿ\0H5Vòÿ\0;þg\Ôú¹cñš\çPð\ç†to\\i±Ã $Z†‹¦$Ó¤¶P4\0\\…”$Q¹fu¹\ØS;[œx\ç\í¬Zxƒã‡Žµ„»²ŸW¹h®#p\ë\"\ï 2°\á\ÆAA¯;ûló\ÂOûú?øš>\Ûüð“þþþ&‰.iszý\î\ßä†´\\¾Ÿr]>‡ñ\'\Äð\Ýþ‡a~\Ð\Ø^}\åþ(ó÷¶\á\Ü88®W\í°\Ï	?\ï\èÿ\0\âhûló\ÂOûú?øšb\ßøõƒý÷þK]\'\Ã\ÝKF\Ñ|Y\á\ÍC\Ä6\Ó\Þ\èÖ“­\ÅÍ­º‚óª;0–@RsÀ$ûW-ut“\Ç\Z$lI?3n\Îq\ì=*H\ïcXcG‰˜ #*\àg’}­Rn.\èM)+3\èMöÐ¯5K\Íw\ÂVúMÕŸŠ¬üQÆ€n&y¥\æ\è?Ú®Ÿ\Ói6‚Ñ¨<r%øc\ã\Éüiy£h\Úv§¬HuýSP\Ö$”n‰4«\Øa†á¤“q1\à	€U;[vz|\ïö\Ø?ç„Ÿ÷ôñ4}¶ù\á\'ýýüMJI+[ú\Óð÷Rô\Þ÷þµÿ\0\äŸ\Ìô}s\âj\éÿ\0¬üQ \ÄNÐ®\í\ÓI·¸%—\ì¶\ÛVlÿ\0yP÷f=k[Hñ7\Ão	üCð÷‹tY|N\â\ÏY´\Ôd\Ñî¬­\Â\ÚÄ’¬’\"\\	É¸#W1Åœ‚H\Æ‘}¶ù\á\'ýýüMmƒþxIÿ\0Gÿ\0DoW}W_ë½¿\ËqI)]tðm÷\\õ\í\'\ã\å\ì\ß´\Íc^S?‡­>\Ûlºv“gmb\"·ºŽH¦x\â‰?8¬™,\Ã,QC6\0#\Ç^,ðóx\'Að‡…¤\Ô\ït\ëË­J\çPÕ­cµ–i\æX*Ä’\Ê!^w’Å›^yö\Ø?ç„Ÿ÷ôñ4}¶ù\á\'ýýüMJŠI%ýuüõõ-É¹s1ôS>\Ûüð“þþþ&¶Áÿ\0<$ÿ\0¿£ÿ\0‰ª$}Ï¶Áÿ\0<$ÿ\0¿£ÿ\0‰£\í°\Ï	?\ï\èÿ\0\âhõcMÔ®´{\è/l§{k¨<r\Æp\ÊÃ½Tûló\ÂOûú?øš>\Ûüð“þþþ&€:x\ãWñ\æ¿þ¯q\æÊ¥Q#A¶8\×#…^\Ù<š\â\êüz„1È® “*A”ñ5B€>˜øñ\ßAø;ð_T[\Âou©õy¤¶\Ó!8wD\0;Ÿ\áL‚3\ß\0\à×†üEø…«|OñDú\î°bûTŠ#X\á@‰c;Pw8\ÏS“\ï\\\Í\ÍONIU[³’ž\Z:’ª—¼\Î\ËCñ•–™ð¯\Å~–+†¿Õµ\r>\î	TÄ©Ü‡sOœ¸À=q\Æ}o\áGŠ4ÿ\0hú©i\Z×ƒ4O\ÞYø®\ëf\È!Sy5í»¬€¬]bU\Î\Ò\ÌY@9\ç\ç*+©·«\ëú¨ò¯À\ë\Þ\ß\×[ž»«|T\Ñ>#x?S\Ó|Uu«\èú‡ö\åÖ¹m.“g\Ü7\r<hžL\ÊóDPG\å GRøWq·›Ÿ>2x\âg\Ãÿ\0\è‰o©iw¾\Ó\ì­\íŒP§‘*\ÛC\íp<Ì«)‹÷r\0Ä¡\ÚÊ½G‹QSÊ­\Ë\ÓOÁY\r;;úþ.\ïñ:ø\ïXø«CG¸\Ê\Èc’7£‘Of^ø<Š\ÈÔµ+­cP¸¾¾\în\î\É,\Ò³1\ïU¨¦\"Iÿ\0\å‡ýp‹ÿ\0E­{W„WOð/ƒ|16»ªhö\Íu}.©6Ÿslo.¤²eS\È+‹yX\Ç&|dþ\ì–ù~_g/·?ÂŠƒ\è ü©+¢UE¹8\Ýùÿ\0_#žµ\'Y(óY_ð\çÑš—\í‰q¬|:ºð\Õç†š{»­)ô\éµ&\ÔywhLm1O+©$¶\Ý\Þ\Ù\ï_<\ØÂ—7¶ð\Èe\É\"£#ó$Á ©‘¸úŒžâ¡¢¼\Ì>Ž5F6¿©\ßV½JööŽö:¯x-<1e\ÆA$’lWÑ¾\Å$\í9òzqŽ„ó\Ç<Ú¿\îÁ\Þ\Ü\r¹\Ï+\ß(\è{ý;ºß‰µ_}“ûRþ{\ï²\Ä ‡\Îl\ìA\ØSY\ÞcŒa›€Ts\Ð\ä~§ó®³\Ö\×2\Ù\ÜEq¯ñ8’9#b¬ŒAt \×\Ó÷ú†•\â}}t\ÏÈšH½–1´‰\Zf—°Gal.\ÌU1\Î\â¾c¢«™\Ú\×ÐžT\ß3Zž·ñ“WÔ¯ü\á\Ë}g_\ZÞ¡­ªKI\âu‰\í\í^;!¼\Ñ;\ÊK\ÙrC£5\Â\è¾#±²ðž·¢\ßi÷nž\Þ\ê	\í\î\Ö&hcº˜\ßzŸ´T?/\Þ®zŠq“ƒº¢¦¬Ï¡¼/ªdüWI¿´?³wxGHO7\í\ßd\ÏüK\ìN\Ýÿ\0o²\ÏL\íó[¦vn_-ø\Ë}ý¥ñ\'X¸û_Û·ù?¿ûW\Úwb\ë>\Õu»\Çú÷\Æ1ò\ãjñtTI\'üz\Ú¸ÿ\0ú5\ê÷†æ¶µ\×l\ç»\Ôo´˜a4_i°‰®!uFE2G\Î\à¼\ï\ê2Fs9h\ãN\È‹þd\ÒP´x\ë\â\æ‘\â‡÷:$\ZÖ½ª^¼p§›©Cx‚bŽ„»\îÕ¦ˆ´Ÿõg ^\nø½T\Æ*:$Lb£¤UŽ›\Â7÷4É¼Ke¡iN5VŠi\ì\äJº(\á”9\ÇgM¤\\\ë\ãˆ<+«xf\Ú\ëGž\ío\Ùtûh£“f\Ç’šE™\ÆJñ\æ7oý\åñú*\ÛrÝ$¶D–¿ñôŸ\îKÿ\0¢žº„wö\Ú_\Åo\Þ\ÞO­¶µe4\Ó\ÌÁR4YÐ³1<\0\0$Ÿj\å#s\ÇPs\î¥O\èi)ý\n\Õ?n\ï\0Xxµt\Èmõ\Ý(0I5ˆc5<\å–3‡es€z\à3òO\íE\âM/\Å\ßüG¬h\×\Ð\ê:e\Ò\Ú<706UÀ´„¡A\äA\äW•\ÑJ\Ö\0®“\ÃZõŽ‹fL\Ðy—-)ù\Õ\åLÿ\0\\ñ\\\ÝÀ³©Ì—:•\ÜÑœ\Ç$\Î\êqŒ‚ÄŠ­E\Øÿ\0\ÂYgý‹öI»\ì~W™Ž7\ì\Æ?>õ\ÇQE\0^²¼kBÀ]Iº\äE\Ãý\Õ\\Œþ•¹\âMKNº\ÑV	\Ùs¸£\'\î·#=³\\­A\ÓSX\Õ\í¬\Ü^˜•Å…¯\Úg\'cÜ»ŽqüCŒžzV—Œ<.ž’\Ö1³’†bºÆ—öŒc\îs\Ós\Æ3=¼©,N\ÑÈŒ]\n‘\È ö5{^ñ¥\âI\ïõ[\Éo¯B™e98\0{\n\0Ï¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Šõ„?ôß‰¾ñ}Ô—\×¾\"³¸²³\ÑaVA\Í\Ä\ËpþL›†w?aóº\ç ðþË—oó·\ê“\Ñ^•©|!i4?¾™q\Z¦¹¦\Ý^]¦µ©\Ú\ØA\Åy4Q\çh\Ô±¯\ÊX±;±\Ç*\ï\àÏŒl5\ë\r\Z\ãF0\ê7\×76\Â\×0\æÛ¶\ÙÕ›~\Ô\ÙÔ– m!³´‚U\ì\í\ëø;0\Øâ¨¯Fo‚¾$\Öo\ÌzN‚ö0E§X\ÞJÚž±hý¦5hŠ\Ì\Æ$\Ý.K$<ÉŒ˜©5Oþ—‹ÿ\0´uý8\Ø\Ù&©¡<\É}¦¾­f·jbBòùp|É‚ª±&5aòŸCF\Î\Ï\Ïð\Ü?¯¼\áh¯\\ñŸÀ;ÿ\0›¨\åò|E\Ûk†}/W³Å“\È\ÜeDyLˆ\Zp‹´§™¸:’ ŠÆ½ýŸüy§Ï§A.‹\\\ß^Á¦­¼:…¬²Áu7ú¨n$-l\í\Î`‡†ô8:\Ûú\Þßž‚\é\ëdÿ\0&y\å\êZ\ìó\âK\é¶~\"û>‰¦\\\Ç{<Ú½\Ì\Â´ˆ\Ët…a”\âdP’\å[s(;s‘‘> øóY\Óôo‡º½«4®žV­©[\Ü,Ñ…-\æ\îXaX…fm\Å\Ô.Ip’v·õýŸf?S„¢½\n€~7¸Õ¤°‡L´™“O:±»V³k#h$4\â\èK\ä²+°V!\Î\Ü6\ìm8ÓŸöuñ›\à¿kZ­ÆŸ¦\Þxz\æ\ÎÓ¥\Ôm\\$ñ<¢H\Û\Ïù@…6ów„\ìj?¯\Æßž¹\åTW¤\Ü~\Îþ;³\×5\r&\ëNÓ¬\ï4\åŒÞµÖ¹a6\Ì\ìV8ä™§¤ŒUŠ\Æ\Ì€\Ü¯5\Ôx3ö´\Ô4«A\â!ªiš\È\Ôu\Ë\ËEdO(\Ø\é«uÁBA2’\nôÁ\æ“iEË²¿\ÉÃ{\Í%ýh\ß\ä¢»»?þ3¿³\Ò.-ô¸d:¬¶\ÑZÚB\Û\í_\é’3ÌŠ9	]²Hª‡r\Øaœ–øo\âøM—\Â1YGy\âEö[;¨n[n\æ\r$nÈ»Fw\å†Í­»nÓŠ\ëo\ëM\Å\Ò\ç5Evÿ\0ð¦üI³S”>†mt\Ñ\Ú/\Äzq¶,\êÎ±\Ç7Ÿ²Y\n£.6f\ã¥q®¯`\n(¢€\n(¢€\n(¯[\Òþ\èú‡ü\"Z©¹¼¼\Ð.õmVT•°\ËjeY¢C³¹–\0»ƒ`Î¼š‹™ÿ\0Z7ù \ëo\ët¾ýO$¢½þ¿ˆµ­IaÒ´Q¦B¶7rI¬\ëvq\Ä~\ÓxˆžC`\Ë\Ë$9.\0 \î*Æ²føE\âûu¿2h“\'\Ø4\ß\í{œº~\ê\×\ÌòËŸ›¨|©_¼\n¶@\Ú\Ø»¿õoø`Z\í\åø\íùœ…\ìó|ûÀ\ÝS\Ä\×mwk\âý;Ra.˜ÎX-\\¸\0dH\r\äLF\îvT8›\\ý\Ú‡^\0ºÑ\æ£\ã_]O\îœ\Ï\Z[Ú ‚+˜¾b\ß\ÜJ²;»mP\Ü\í\ÚMÝ½ú[ñ\Ø#\ïZ\Ýoøoýz%EwŸð£|eý¹–4\ëGy,›R[\ä\Õ-Oû*¶Ö›\í‚_³„òdá°¿x\âº_~ÎºÎŸ\â¨ô}?g\ÒtË»ùõmN\Ò\Ö®n`W1,ò¼q’\\¸DY•I°M\×\çþMz‡-/óGQ^\Ñoð?K´ðî‡®k7z†e‹u«k°…C8xµ³Kxµ„jK\îÛ—l<>¥ \éž+÷ž\n\Ñõk;-*\Ä\Þ\êPjÚŒMbT\ÍY(wÒ \Ø#\È\ë’	Ú®¯o_\Â\ëôžÃ³½¾_=4üQ\Ç\Ñ]\Â|ñƒizŽ¤\ÚlX\éöv·÷3\ÜjÐªCsKnFù\æ‘\á[8\\n \Ù\ß\ÇVzõ\îu§\é\Öw\Ö\"?µ}«\\°Š+wveŽ)%i\Â,¯µŠ\Ä[{(\Ü¯5[;2z_¡\æôW \Ãð\ÇSx|\ë_Ø±\Çeö{›¥I¯í£¸’;wt¸d¤¿–c}\áT•\0€A=\ßü3Î•\à›\í^_^>»ag\á(<E>\Õ\ìã•¥‘\íT\ÄÎ¢\ä*/\ÚN¨¼RvZ¿\ëFÿ\0FU›|«ø)~mEzÏŠ¾^Mñ\Z_øE\âf´²½µ±\ÖõKK;\Ñö¨RT·++\Ç\æÌ¥ö•rNÑ¸\n–O\Ùÿ\0Q\Òôjr¬Z\ëx‡L½¾þË°Õ¬\í\îmZ9\Ëe\äbª|¢\à†‹+ ¤Ý—3þ·ÿ\0\'®Á¾Ç\Ñ]ÝŸÀÿ\0\ß\Ù\éú\\2V[h­mF¡mö¯ô†\É™\æE„®\Ù$UC¹N\ì0\ÏM\á\ÙwÅºÇ‰­4Uô\í+«[ù\ã¼mR\Êhü\ËHK\É8(bŠ\è\Ä<a‹²\íF\Åm{ô¿\á«û…¾ÇQ]‡ü­x§\ÄZ>—o\ÕÝª\É%\Ä\ßl…-aŽ>W¹g¬`\ã÷…öœ®	\È\ÍûÏ…> \Óô;\íb\ì”Ó­\'’\Ü\Ì5\Ëö‡@…Å¸f\ä/˜™0‡õ¥u¿\Ï\älrQE\0QE\0QE\0W²\\x/Àú¯Â½#ZÐ¼7\â¹|G¬jóhv–®[\Ï\Ú(_\Ë[g\Ó\í†¼sXþÏ¾9ŸR–\Ê\ßN±¼xm$¿–\â\ÓY²š\Ú(c‘c•žt˜Ä»\Óx,\n\ÜÀ/4ÞŽ\ß\Ö\×üµªOú\Þßž‡Q^\â/€¾8ð®“¨j:ž“o\rµ‚\Ç-ÀRµšT†FTŽqJ]¡vu2©²0Æº\röiñV›\ã¯\é^.\ÓN\Óo5\ë=Pk=B\Úk‹Fž@\0tGsd\È\Ò.\Ö\0¸Q\Ì\Ò]tþ¾ô&\ì¯ýhxý\Ý[ü\×uˆu\í+û:\ãM´¹0\Èd\Öl’\âó\Ö,Ð´¢H\ã\Þ\èŒªƒp$\Íoø·ömñ.ƒñ\Ä>Ó®4\ÍV-e‰õ9u[+Ks½™cWwŸds9F\Äþf¸©N\é>ÿ\0ð?\Í%\Ê\Ú}&¢½\Ä\ßm´ß„ñ%Œ\×\Ç\Ä~T\×\Z\î“s·÷\ÙmVX”\0À#Ä« m\Ø2¡\àd<qû>k>9ñ†Ÿ\á›oµ\èš6¥>Ÿo6¥¨[A=\ÓF»Œq+²‰B\à”…Y¾e\ã\æm¥øþÿ\05ùn{GEu÷ü]k§+è²˜´Û‹[[—ŽH\Ü,—+º\0\n±\Þ`†\\™rF\áŸQ±ø\á±\á\Ý+M\Ôa\×-|c{¢jú¤\×\É\éörX\Ïr†9\"–(\Â\Ûo˜&ÀgqD½Ø¹?\ëNo\Ë_»º÷šKú»·\æ|ÿ\0Ezg\Ãÿ\0€>!ñ\æ¥á—\Z]¾‘­j\Ö¨Eª\ÙN\Öm6\â¾t\"pñ±T“jI°».\Õ\Ë*;\ï‚úâµ¾a¥h_¾­u¦J\ÛX´š\Îc1\ÊÀl$F#G\Þò´¥\0$¥\Z›\ÓGýmþh»[ÿ\0“<ÞŠô[/\Ù÷\Ç\Z…\Åôpiú{\Ãd-Œ\×\Ç[±[0.7ù%nL\ÞS†1º‚®F\á·\ï`T¾&ø¬øG\á¯ü%ZÍ­\ÌZ\ÍÖu£\Éyn.`x|°N\Ï7{6÷`P&UU\\ü®¦“\ÓWýl¿TWeýi\ÉkEumð·Ä±\éPj’Y[Å¦M½\Äw\Ò\ß[¤³\Èñ\Æ<\Ã&\Ý\Û\ã”\Î\åò¤,#±À\\jf\Æ\ßM³»a§6­ö«]^\ÎkO²,\Â›\í+1‡jHp\ß?É‚[\0õ÷õ÷žyEzˆ>x\ßÂº]þ£ªiPAi`±\Ër\"Ô­f•!‘\Õ#œD’³´,Î¡fU1¶F\Öw\Æ\Ù|?ø£\â\r\é\Ò\Ï5Ž—-¬2]2´¬ªp\0ô•Öžwü-þh:\\\ãè¢Š\0(¢Š\0¹£\éR\ëz”6P2$²\ç\r!!xó€}+¦ÿ\0…W«\ÏÅŸýöÿ\0üMg|?ÿ\0‘º\Ãþ\Úè¶¯©<3ð\Öh¾¸±žD¸¿\ÖdÒµ#©Ku\Û‘\Ê\ÐBùfbrOú£Ó¥}þC”\à1˜9b1wº“W½•¹S\Ôüßˆ³¬\ÃŽk8)Z\×mÝ­>Kó>lÿ\0…W«\ÏÅŸýöÿ\0üMðªõoùø³ÿ\0¾\ßÿ\0‰¯£n¾\Üks\Ø?‡4«˜tû\Ènn\á¼\Õ5+uí£\ã»‘\ZÀ˜~g\éÊµWþ‹N©k§&f»ºûG°\ÜE\"\Éä ’B¬®TŒ¬~`\êW;†~•p\îMö›O]•ô½þ\ë;ö\ê|¼¸›<N\ÑI«¥u.\íkz\Ý[½Õ·GÏŸðªõoùø³ÿ\0¾\ßÿ\0‰£þ^­ÿ\0?÷\Ûÿ\0ñ5õ?~ÿ\0\ÂM\àjW­sg«Ckow£B®†;¥´–¸\',-\\\'+\Î:‚3›ðŽßƒo\âP÷“ø’\çR··°\ÓmÀe’\ÞV’5r¸,Y¥ŠEPû‡ƒ‘YK!\Éc)Aó]5ú\Ëo\ëÉšÇˆ³\ÙF3\\¶qrÛ¤wý-\Þ\èùwþ^­ÿ\0?÷\Ûÿ\0ñ4Â«Õ¿\ç\â\Ïþûþ&¾‡¼ø7\â\Û=OO°þÍ†\ê{\éä¶…¬o\í\î¢óc‘H¤d‘~fF\Õ\ä\às[Z÷ÁJ\Æ\Ç\Â\ÑY$sjz†Ÿqz\ï¨\Û}Š\ã¸x\ÖAq¸D#*\æ2Y€$\n·\Ãù\"\å÷·þ÷“wô\Ñ\êB\âLýó{¶\åþ\çv’^º­—¿\áU\ê\ßóñgÿ\0}¿ÿ\0Gü*½[þ~,ÿ\0\ï·ÿ\0\âk\ë¯|\ÓoŽ–ž(’þ\ÎW\Õ5KÅ°ž,\é&\Ú\ÊÛ‹}\àJ²‘Ž¹¬+¯ƒò\Ùi>(®5\rJ\ÆûN·\ÒÍ˜+øn¼\ÓŠ¸%·ªFWøˆ9=2þ\Â\É\\\Ü7N½\åÊ¿À\Õñ|©ª–\Úô\ÕY]\Ý|¾ó\æ/øUz·üüYÿ\0\ßoÿ\0\Ä\Ñÿ\0\n¯Vÿ\0Ÿ‹?û\íÿ\0øšúZøW\â]\Ö\â\æ\â\Î\Þkku\r,\Ö7ö÷h¹G·0\È\ÃpvE+\Õw¦@\Ü3\Ðx/\à\Ýô¾9›Jñ^Ÿyecbó\Ãz-n\"ID\Éi5\ÊF®C˜C÷‚°\0ûŠ\Ö\\=’Æ›©\Ít“zK¶ÿ\0šû\×sñ.}*Š—*M´µ·½¿\'÷>\Ç\Ëÿ\0ðªõoùø³ÿ\0¾\ßÿ\0‰£þ^­ÿ\0?÷\Ûÿ\0ñ5ô¿‰¾\Ú\\Má«\r±°¶\×4\æ¾[?j–\Ð<&x˜\äòceb›”\áI¡\Æjô?õ‹-O\Ô/\ãŠ[¹5ö\Ð\æÐ£\Ôm`ºgVpŒ\Î\Øfi1þ¬…]²£Sý’¤œ›M\ég-n¿5k\í\æWúÉž¶\ÔRi+\ÝGK[›ò\Ö\Ûù-Â«Õ¿\ç\â\Ïþûþ&øUz·üüYÿ\0\ßoÿ\0\Ä×¿Ið\Ï\Ä\r¤\Ýj\Éa6™Š\Ç5ô\á\Ò&+#$E„’ªC:!Qµ¹N:;\Ù\çÅ¿ð“izV«®’—zœ:dó¶¡k+ZI&Jùˆ²\åK\"³ m¾f\0\\\î¹pöIyJ\ßö÷m\È\\KŸ\É\ÙBÿ\0ö\ã>^ÿ\0…W«\ÏÅŸýöÿ\0üMðªõoùø³ÿ\0¾\ßÿ\0‰¯uºð.©¥ðµ”qêšš\Ü#[)\ã™$=r\09\'vq8¸>\ë\Íöö\r£´!<ë¡®Ø›}Î¬Ê‹/±Ü„s±In:Uÿ\0«y2I¹Z\êÿ\0G³#ýh\ÏyœU\Óiû·\ÕnŸ¿\áU\ê\ßóñgÿ\0}¿ÿ\0Gü*½[þ~,ÿ\0\ï·ÿ\0\âk\è_øWÃº\'‡4;\Ý\'\Ä\rª\ß\Ý\Æ\rÝ™Ž0mØ\Øm²6\Ö@\0\Ü3»,¬k\ÉY\ÚO¨]Ckk—73º\Å0¡w‘\Ø\áUTrI$\0]>ÊªG)[Íµ·©N-\Î)\ÉFN7v\Ù\'¿¡\äÿ\0ðªõoùø³ÿ\0¾\ßÿ\0‰£þ^­ÿ\0?÷\Ûÿ\0ñ5ô¥\çÁ\Û\Ë/¶jvú^µ>™sª>‡©Z\ÜÁt±\Âg,\îŠr–\å†\æRsŒcùõ*|3”Ö¿%Ý¼\ßõ\Óq\Õ\â\Ìæ½£Š¿’ÿ\0=»nygü*½[þ~,ÿ\0\ï·ÿ\0\âhÿ\0…W«\ÏÅŸýöÿ\0üM}?\àŸ…6Ÿ´X¤ðýì–š¥‡:\Ä:ƒpœÿ\0¤DUFT\0AŒ\å³Ðš\â|Tº$z\Ôñøy¯%\Ò\ã\ÂG5ñ_2R:¾F\ÐO!y u&¢Ÿ\r\å5*:QRº\ß]¿\áúy\ZT\âœ\æ5VR,¶\Ñk\ß\î\ëÙŸ2Q]\ÇÁ\é^:ñõ¾•­ý°\é‚\Êúòe°™!™ü‹Ig\n®\è\ê¹1’§‚x­¿ü%³¹¼ð¤\Þ\ì\ëO\éTŽ\Ç\Å:Å¥´¶\Ûf’Sq/‘«÷¡Ú¥•ºf¿wM.ÿ\0ðù~\åý~_\æye\ì–ÿ\0³f»a¢èº–¥77\×^%“\Ã\ÓønZ\Î\ÚôÈGi\Ï!\ê\ÈU!\Ê:š\ã›\á‰\äðýÖ»:l^k¬sj\Â\é\ãöI$pÊˆÀ†‘ \Úù#kao·õ¢“Cþ¿¿4\Î2Šö/öXñ»x\ËE\Ðõ»{=;\íb\Z\â\åµ;9š\Êi2ÀK\ZÏ•bŠ\ìŠ\ÅL¸2Xg˜\×>\røƒA·\Ô\ïn$\ÒN™cu%¯\ÚF·c›–M…¼„ŸDÏ”i8<‚Š\æj+¯üóB\Ý][ÿ\0“ûŽŠú\ã\ìõ£ø\ï´ýHñF™­Å®E¥iv\Ú\äñ\Î|A‡{DKx›\n\ë8óù\Ê7€|ö?\Ù÷\Ç3\êR\Ù[\é\Ö7\r¤—ò\ÜZk6S[Er,r³Î“—c:o@Û˜\æ¦/›o\ëKþO^\ÝC¢\Ööü\Ï:¢»ø~x\ÖmkR\ÓM´µ—NH$¸¹¼\Õm-\ì\Â\Î€­Ô’¬/\æ”\Ú\çpŒ€qNó\á‰ô}6ÿ\0Q\Õl-ô»{©l\çƒP\Ôm­n^XŠ‰R(dI)]\ë“\Z0…R\Õ\ÛúþµŒ¢½\Æ?³Ž·¢øxk\Ð%½\Üþ ŸB\Ã2j–——ñº•1:´\Ò—iTˆ¾6ºšÁ“ö}ñ\Ú\ëzv••k{w¨„·kV\Î\æöñ™\'¦ŽVn(\Ì\ã‘S\ë\äŸ\ä\Ðyÿ\0[µú3Î¨®»PøQ\âm3Sš\Æ[+y%‡M}]¦¶\Ô-§·6‹Ò¬\é!\ÆT¨\ÚÄ–ù@\'Š¯\á\ï‡:\ï‰ô;\Ýf\ÎH4›GòžóR\Ôm¬by6—ò\ãi\äA,›Fv&\æÁr2\îµòÿ\0;~zz‡õúþZœ\Í\Ñø£\áþµ\à\Û­Y,­þ\Û\ZK´z•´\×H®‹\"`I\ZX²¬¤yŠ¹\Ís”y˜QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0Q^\Åð?\á6›ñÂž)\Õ\îü=\â\Ü\é7v\é§øb\á!‘cŸ\Ïó&µ¼\ß*yK\ÙG\ÌrÂ±µO‚:¥ö½\âQ\á9­uÿ\0éºÅ•ž§%ý´PòòØ·W‘MÄ›6±XCŸ™q÷—$½\×gýmþh»_Õ6¢»½S\àoto~\ïHŽ=;\ìPj_-õ»\ÏöI¶yWB\Èeò‰u]ûv†%I,_~\Ïþ<\Óä²Š]7ž\ê\î³\Û\ß\ÛM5µÄ£1\Ås\ZHZÙˆ‰‚}\Ö\Ï\Ý8{h\Ã\Ìó\Ê+Ö¼	ðSñwˆ\"\Ð%û\ZM.«§\ØK®Ykö6Vkq\æ`IšF±UIA\Êl ³­f[þ\Ïþ1Ôµ-J\×Mµ\Ó\ï\Ò\Îô\é\é:jöJ——C­‰›m*Lp—`X2@¤ôþ½?\Íõ÷\ßü™\çWqÁ_\É\á8üGý™\nir[\Ïw™¨[%Ä‘@\î“:Û™¬‘·a\ÜdðA¬\Ï\ëV7Z5¬–5Þ±w6Ð•–Y\ÒF+	`XŽ€H ‚	:Û¯ü?ù?¹‡õý}\ë\ï1¨®ù¾x±uk9—D[‹X\r\ÅÓŸ\é\ÂEö\Í7\Ú<¸Ÿ{\Ø\ì¬I\àW	q[O$.P¼lP˜\Ü:’8`H#\Ü\ZW@2Š\×\Ðô1­+ª6&]\Ø]\ê3òðq\×\Çnõ³\áû­\ÉûIŒù¹Û±³\Ó\í\ïL\Ú*{!n\×\n.Œ‹	\à´x\Êûó\×\éZ\Z†Šš=¹7RšOø÷X¾\Ù=º\ÐEW±\Ã\"üTÿ\0„\'þøG\ìÿ\0\áû/\Ûµ?·4ÿ\0\'\É\Æwg\Ïü1\×<c<PŽ\Ô\æ\ÕW§I°Cwô¨*k¿õ«ÿ\0\\\Óÿ\0@À>ÎŸóó\äÿ\0üMgOùù‹òþ&»?x/Bðï´m\"óT¼Ó´[½3H¾º\Ô>Î·RÛ›­>\Þ\æVƒ\åW™°¹h±\ë\Ø\ë?³=Ïƒ¬us\Å\"´\Ó|Aôr\Î1t5\çqº´z–\È\å\É Gƒ»ž\n\Çª¶v\Ï`\ì3\éP®;œzT¶Ÿ\ë[þ¹¿þ€j8\Ø+Ë¸`Œ}G‡°ãº¹\ÓÂ²ñ,ºµ®k¤\ÜjW6pß ´¤_\"X\Õ\Õ\Ë…P\æ\'… \äðk_\Ñ&ð\æ­>s5¬÷m5\ÂOb •!*\ÄgŒƒÉ¯sð¯‚<c¤ø\êñ†µM\r,¢Ô®|+©©€Y-d¼D\0Áµ$1G#nŽE\ä¸gŸ\n\Ö\ï,õ\rRk‹\r=t«Y6•³IZUŒ\í‚³e°NH’\ÆN3D´“ˆ–\Éÿ\0_\×õ©/ü#÷ß‹ó?\áEo\ÑZr¢nqµ\Õh~<}À:ÿ\0†\âµc&©}c|·\Ë6\Ó¶€\ã’\Þvs‘½ó\Æ?†î¥³Ö­¦…¶H»°\Øª‘Þ½Eÿ\0„\Ã_\ÒF§m6—\r“Nö\Ë-ö¡ii¾DTgUH¥°$L1ó\n\è¥õ^Fñ%~‘Ok5«œuº\ìp\âjbi\Ë÷0‹÷¦\ã¯k(Kóùý¬–óRÓ¯\î|1qa¨[è¯¦Ë¨øVû\á¹{¿´\Ëw¾KùV.®ªDŽ(8®_ý£&\×\Ç\Ìt$Ž\ë\Äw²\Þ\Ø\\Ite}$Î¾]Ú¡)óù\ÑŒŸ”ü òj?\ì\Ï\ÐC\ÃøPi¿ü~¹\Í_\Å^\"\Ðuk\Ý2ø\Ç\íœ\ïm<[Q¶HŒU—# \àƒ\È8­yr\É\Ý*\Ò\ëö#\Õ\Ýÿ\0\Ë\Îÿ\0\å±\ÍF`ß»J÷þ$º+_ø]¾þ§¥x7\ÇŸmX\Ðô´\ÑR\×E¤¿ñm®Ž\Ð\Íe[¬û\ç_\Þ\Æ\È\Ò‰¸p\à\à]ö«\Ó4øõt}*ú\î\ÏU\ÕuYa»\Óõf±·¿†\æ/&3w…šq\ã\ê»dI¯ÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠ¹\Ò\Ë\æ\Ý\ê\Ï[\ßÜŽ·µÿ\0\å\ç’.5s(\Ú\Ôa¥­û\Éid\×üúó:»ÏŽö³Y\Ü5¿‡\çƒT»ðµ·†®.PW‡ý\íŒS¤~H+ò\Ûa»d¾AÁÕ›ö\Ó\àñ`ñ&›\á)lõ=C_³ñ¹\æ\ê¾lWR\Û\Èeò\í\×\É\Ý\ZFv;Œ¬>P\r\çÿ\0ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±O\Ù\à9”½¬\î¿\é\Ü{\ßþ~wþ¬O´\Ìyy}Œ-ÿ\0_%\Ú\ßó\ë²þ™¿ |w»ðÖ›§\Ú\ÚiJmµCS™n¥g†\ê»x\à–\Õ\ÑB¥`Àüü`Œ\Òhÿ\0¼#\àÿ\0\Û\êž\Zðf¡kk$wVº…¦§®‹¦š\Ú\â…\â…\Ò\Þ/+	#\á™d9y\0†Áÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠŸe—\Ú\Þ\Ö{[\àŽÖµ¿‰\Ûõ\î\Ëu³6\î\è\Ãÿ\0K»ó\ë»þ¬Ž’\ë\ãe•¾‡¨\è\Z?‡¦²Ð¤\Ðd\Ñ-!»\ÔE\Å\ÄM%\äwRO$¢\Ñ\í\n¨€\r½H%¥\Õþ9Yøƒ\Âú¶‰\á\éü»½;Gµ‚[}EP\Å>Ÿnð¤¬-½{1Œm#€½r\ßðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±T©\à\Õgÿ\0€G£m\Ë\Î\íÿ\0V«™-¨\Ãÿ\0K\ËþuM~¥ñ\ÓIñNµ\ã–ñ…®¯4/j±k?b°\ÕEµÅ­\Ä~`@\'h$WB³H¬`Ÿ”‚¸\æ\Ü?´\Õ\Ë]=\ÕÞ³¾£«ß‘\rÑ^\Ø-šÆ £D6I%ºš¸_øOµù\íýû\Â}¬\Ïhÿ\0\ïØ¨ö9w+µš·À¶\Óþžy U³$\î¨\Ãÿ\0K\Ïþy³\Ò\×ö«¹ž\Éyo\âYn|<úim>²h\×kfñ”&Å mŽ\É\Z‚\Ë&7üûzŠ\á¼ñSOð–¯¦¾K»é®¯†¡+\ß:ýª\Â\ê%\í@²†”‰@\'.2¤.oü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìUºy{mº³\Öÿ\0ò\î=mùy\Ö\ßv›	TÌ¢’Ta¥¿\å\äº^\ßò\ë¥\ß\ç\Ñ\'„þ,x_Á-¯C§xk\\ºÒµ&«k¶÷VM FQ%\ÌF\Ä	Š³BžS¦\'#\Êk²ÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠ^\Ë/½ý¬ÿ\0ðÿ\0\Ë\ís+[\Ø\Ãÿ\0Kÿ\0•m\Ù\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\Ï/ÿ\0Ÿ³ÿ\0Áqÿ\0\å‚ö¹—üù‡þ—ÿ\0*8\Ú+²ÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠ=ž_ÿ\0?gÿ\0‚\ãÿ\0\Ë\Ú\æ_ó\æø2_ü¨\ãk¿\Ðþ.\\h¿õ\Ï.­¨\\	\"\ÔÌ¤Ik\ÚxUqÈ‘­\í\É9ò\È\çqª_ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±G³\Ë\Úk\Ú\Ï_\îGÿ\0–µÌ®Ÿ±†Ÿôò_ü¨ôþ\Õ:=½\í—\Øu\Í6\Ê\ëL\ÒlŒ\Þñi—\É-ŒJ\È\'¸)\"—\Ý!\ä®+“GIý¥¥\Ót\Ý2\ÂmmJ/®\Zú\â÷Q/u¨\éòùÿ\0\è’\É\åõ\îåŒ¸ù™\Ô\í@®þ\ícþ{Gÿ\0~\ÅðŸkó\Ú?ûö)ò`¹½¬\ïÿ\0^\ãÿ\0\Ë?¥¦\Âö™¹U[þ¾Kµ¿\ç\×ôõ\Ü\ìm?hû\È\ïmno4X¯\ÛþCZ¾†YÈŠò\Èc†k2¡~UòÑ—p\'\Æ\0\Û\Ëô¿\ÚRòõ-5>­ª_ßª\Ý„\Ð_Z¥¬¶ñü§\ÊØŠv?\ÌW\å!px¿øOµù\íýû\Â}¬\Ïhÿ\0\ïØ©öY}­\ígµ¿‡´\ÓøžKúl¯m™^þ\Æø2^ô\ë\Íÿ\0Id48-Î€<)x\Þ:DšWökköü½\Ê\Ýþ\Õö}›ü\Ô^<»6\ç-]-—\í_ö­^=#\\\Ð4{\ë.\Ò$ðß‰^\ÂþÝ¬¡0¡>KGFm\ÈÑžvA^|»þ\ícþ{Gÿ\0~\ÅðŸkó\Ú?ûö)û<¾\Öö³ÿ\0À#\æÿ\0\çç˜½¦cÿ\0>aÿ\0ƒ%\åÿ\0N¼—õs®_\Ú7öeÞ‡6«¢G§\Þiz®£©4“\ê0O}%\Þö™QJÌŽ\èD›H/\â¸%+3@ø•\á/\ê:¬\Zw„µQ\á\Ý_J“K\Ô-n5\Ô{\Ù7K¡\Ò\àZ¬iµ¡\É9²NF\ÜOøOµù\íýû\Â}¬\Ïhÿ\0\ïØ£\Ùeÿ\0óö}\å\Üz\Þÿ\0òóÍ\Ú\æW¿±†÷þ$·Vÿ\0§^H\ê<uñ\Ò\ÛÅš¯¤Yxq´»;\Èôha_ù\í\niöòB Ÿ-w—O\Û\Ð\ç\í/ö¦¹²ñ7\Äÿ\0±kš]—‹/\ãÔˆðßˆ[M¾´•\íQr!p\èVG­\'i+Ïœÿ\0\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\Ïvý¬õþ\ä|¿\é\ç÷W\Ü\'W2i/c\r-ÿ\0/%\Óþ\áT?>Ï¬xr÷û\"\æ\ëûMÕ´\í×º›=\Ï\ÛZ\ìù²I\åºý«“œ¡?.\ìvÿ\0´t\Ú;I¨hz~¥¢xŽo\n\ÛøfMR\ÓX1\ìòM°I\á	¼d¥¹V]\í“&C\00x¯øOµù\íýû\Â}¬\Ïhÿ\0\ïØ£\Ùeÿ\0óöø\ë\Íÿ\0O?¼þÿ\0Aûl\Êü\Þ\Æø2]\Óÿ\0Ÿ]\Ò;/ƒ´U\Ç\ÂýKT\Ô\ï\ìõmcW¾\Ômõ)u;=m¬®®e\Ùà¸—Ë‘¦‚VpÎ™]\Å’qI§ü~³³Ã“¿†\ç“SÑ­5]=&]IV`½G˜ü’ÁÑ®‰Ý¿A;‡ÿ\0	ö±ÿ\0=£ÿ\0¿bøOµù\íýû¥K/’³«>\ßÃk\Ï\ÎÀ«fQ½¨\Ã_úy/þU\æzZþ\Õw3Á\à\Ù/-üK-Ï‡ŸM-§Á\âvM\Z\íl\Þ2„Ø´\r±\Ù#PYd\Æÿ\0ŸoQ\\÷‚þ=\Ç\á[{iô½¶ƒT\Õo\æ\ßžH\ï¬\Ö\Õ\ãRb`ŒŠ!$|¼s\Êÿ\0\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\ÅS§—\Ê÷«=o\ÝÇ­¯ÿ\0/<£W2’£\r?\é\äº&¿\ç\×f\Í\rüMð\ç†\ãº\Ó\âð\Ãèš¦›6›«\Ä5r.®\Ô\ÜùðJ’˜ŠE${ SˆÊ¿–Ä¨\ßÄ¶4-#À¾\"ðÕž«][j\æ\ÆcW‚ò\×O-°y\É\Ù…ÀU#Í\ã\È  `\áÿ\0\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\'K/i§Vz\éð.÷ÿ\0Ÿƒö¹•\ï\ìa½ÿ\0‰-ÿ\0ðQ\Æ\Ñ]—ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìQ\ìòÿ\0ùû?üþX/k™Ï˜\à\Éò£¢»/øOµù\íýû\Â}¬\Ïhÿ\0\ïØ£\Ù\åÿ\0óöø.?ü°=®eÿ\0>aÿ\0ƒ%ÿ\0ÊŽ6Š\ì¿\á>\Ö?\ç´÷\ìQÿ\0	ö±ÿ\0=£ÿ\0¿bg—ÿ\0\Ï\Ùÿ\0\à¸ÿ\0òÀö¹—üù‡þ—ÿ\0*4|#ñ’\ïÁz/„­l4ø\ÞóÃ¾#“\Ä1\\M!)+2@¢&@\0y°lý±“\Ôx¿öŠ_\ÂB\ß\Å7««\éSi<K\â–\ÕE’\æ	ókt*£\È\ÚT’NT–ùy\á¿\á>\Ö?\ç´÷\ìQÿ\0	ö±ÿ\0=£ÿ\0¿b‰S\Ë\å½Yÿ\0\à\ê­ÿ\0?;!Æ®e¨Ã§ü¼—Gùõ\Ý\Ü\è.>7}²]X\Ë\Z‡…,¼/ÿ\0Yòþ\Ïöo\ßý\Îw}›\îqÿ\0x\ãŸGøñ\ë\Ã\ÞøÉ¯^x[Dûr¿‹-u›ý@j\éq ¶’³Æ–ûaý\Ê9b\ÌÅ¥\Éÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠnÔ½¬\î¯ÿ\0.\ãÕ§ÿ\0?;ÿ\0V´\Ìyy=Œ-ÿ\0_%\Ú\ßó\ë²_ð\çzß´’†\Z—„¡\Ð\ï­Mõœ¶’ˆu’š{3\Ýý£\í/h!ù\î03#IÊ¨\0.+NÚª;_x\Îú\ÏJñ‰k\â©à¿»:Š\r\ì7‘™2b¸[b<†YX]ð§~Eyü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìTû,¿þ~\Ïÿ\0\0ÿ\0,­™=\èÃ¿ñ%¿þ\n:9~<NºÇ„¯!\Ó$¹‹D†ò\Ò\æ-Vó\íMª[\Ü\ÝO4±\Îû%’vF`2H\Þ6œ\Ø\Þ~\Ö\×\Z’ø¢³ñ.‡g«kW:Íºø_\Å/§I^\Û\Èu¸A\å¡D \î\ç\r\æ\Æ\Ú\Ã<Mö•\0\Æ\ÌW\Ë\\dnöö\Øü)ð\ï~2\ëòi^Žhc2\Ü]\Ü&\È ^v\ï`€\0$ó\Ø\"¤r\ÈAÊ¥i¥¯ØV›ÿ\0—\×ùnTgšNk–Œÿ\0¯’\íoùõ\Ùÿ\0V.h?µ5Þ‹‡ø~§iÿ\0g»\Í\Ño¹\Èû-\Ëü‡/²Z¼\îòß‘¼\ãñ\Æ\Ï\ëŸü?\à\ØuN\ÇF\Ó\í\æŠò\Ö=FCo¨\È÷R\\	d„ar¨\çw\Ü# _k¾*ðž¹y£\ë?S³\Å=¼Ð€\È\ßÈ‚0AA³¿\á>\Ö?\ç´÷\ìUòe\Õ7¶›O_‚>ôó\Ïò\ì­>\Ó3‡»\ì`­ÿ\0O%\éÿ\0>¿­{³Ó“ö¬º†ôûO^ÆºEþ‘¨-¤º\Ñ}=\ÄEµ°„<\âK¹\Ü\ä±\'&³¼/ûH\Ã\à}KO“Bðýåµ•®±¨jE&\ÕÉ¹1\ÞZ\Ço,k<p\ÆQ\×c2J«ò–_”\í;¸/øOµù\íýû\Â}¬\Ïhÿ\0\ïØªöx\Ûö³\×þÇ­¿\é\ç’©™$’£\r?\é\äº]/ùu\æÎ“ÆŸ?\á)\Ðuý/\Ëñÿ\0ö¬\Ú|\ßnñ?ˆ?µ.¢û/\Ú>A\'‘Q¾\ÑÀÀ\ÚTõ\ÝÆ‹>=\èž;–ð\ë¾ž\ê	¼S/ˆ\Ò\Ú_\ÊC\Âž\ÖB!\ÜÛ’	©bp\Ø\Åq_ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±K\Ù\åÿ\0óöø.>_ôóû«\îõ«™?ùsü.\ÍÏ®Ížñ\ïH\Ñô_\è¿ð…­Þ \ê0\êö¶—Z‡˜\Z\ë\Ì&\á¤&,<rG\å\Æ“É²\Ä\È$·\ã_\Úa¼]g{l\Ú^­söK \Ís]:…\Ù\ßz—^k\ÊaM\ØÙ° \n\0\Ç<`ð?ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±I\Ò\Ë\å½Yÿ\0\àª·üü\í *Ù’wTiôÿ\0—’\è\î¿\å\×}Mû¿\ßj}]¿±vÿ\0hxR\Ë\ÃñõŸ/\ìÿ\0fýÿ\0\Ü\çwÙ¾\ç\ß÷Ž9\å>&ø\Óþ7\ÄxŸ\ì\Ùÿ\0\Ú×’]ý—\Íó|­\Ç;w\í]\ØõÀ«ŸðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±M\Ó\Ë\äùY\ß_±®\ïþ^wW2Q\åTaoúù.\ÉÏ®\Ém\Ù\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\Ï/ÿ\0Ÿ³ÿ\0Áqÿ\0\å‚ö¹—üù‡þ—ÿ\0*8\Ú+²ÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠ=ž_ÿ\0?gÿ\0‚\ãÿ\0\Ë\Ú\æ_ó\æø2_ü¨\Îøÿ\0#u‡ý´ÿ\0\Ñm_Lx\â\\þ\Ò|GeŠ^jÚ˜¡•\ä*l\æ\Úñ‰×ƒ–\Ë2ã¿œñ_<\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å}nWœ\å™~XJŠsR•þ»iñ¾\Ç\Æfùk™c!Œ¦\áM\Æ6ø¤ú½~ß±õG‚þ<\\x>\ÇI²Š\Æò8mt›­*{;Rk;¦YnMÀ’U”\Ê\ÛG!\Ã\0À›‡\ÃñúûN‹Sû\Z…\Í\ä÷ð\Þ\ÚjzÎ¦o/-\Âù&Ti<´ó<\Ão\Î\n›psšùSþ\ícþ{Gÿ\0~\ÅðŸkó\Ú?ûö+\Ó|E“JNnŒ\î÷Û¿7ówü4\ÛC\É\\/žF\n\n¼,¶\Õÿ\0//òvûž»\ê}G¨|r¹{bm3L\ZY¸»\Ó.4õ[0X%’º\Ç(7\çp$ñ\È<Õøh«}cQ\Ô,´[k?3P\Ó/,-VV0YGd_Ë„.2\Ê\Ûù9SÇ©\ã\åOøOµù\íýû\Â}¬\Ïhÿ\0\ïØ£ýbÉ­oc>ºr\Û\íu~=\ÝÜ¸c<“m×†¾o¯7÷?¼ÿ\0\Ê\ßR\Úüb\Òt[\ËXtOo¡›‹«‹û\ÍOÏ–\ç\í˜e‰<µXÙ¶ü¬A9b\Ü¥£þ\Ð\Þ“M¶\Ñt=KK\Òmt›!¾Í­´w\åe¸û@•.V @øþ¤dmÁ\ã\äøOµù\íýû\Â}¬\Ïhÿ\0\ïØ©—\ä\ÒV•)¿\éÿ\0}]ž\è¥\Ã9\ä]\ãZš\ëø§üšj“}úŸV\Ûüxû-\Â?ö~¥©m½½»ûF±«ýª\êO´X-¦×—\Ê]\Åv\îh\È\Â\àcuUð§\Çk\ï\nø6\ÃFM*\Þ\êÿ\0N\Ô\í/\ìõ)\\†X\à‘\å[wP>t\ß,Œ\àFö˜ùsþ\ícþ{Gÿ\0~\ÅðŸkó\Ú?ûö*¿\Ö,™®WFvÓ·Kµöüß¯R\Õ|ò÷öðûK¯\Ú\ß\ìuü7Vg\×3~\Ðÿ\0ñVÇ¬ý^Õ­¼©£}7\Ä~!mF$,\é,^Q0©EIbŠÅ‚\0H\ëT´ÿ\0\ÚP²½ð\Å\ï\Ød7º<K-\Ìwe$ºžKo³G6\í¹Ck9*NF\î>Sÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠ•\Ä*\\¾\Ævµºlî¿Ÿ\Íþ•­ð\Þ|\ä\å\í\áv\ï\×}?¹ý\Õøÿ\03¿\Ò~ø»¡ø—T\Öõ©µmoS¾´û(\Õ\"\ÕZ\rFÜ†B+–I\n¨c<d£0fºß–Ú–°5;ŸL\×0ø|Kl#Ô€UoÜ‡ŠM\Ñ\à¬#\n[$7Jù3þ\ícþ{Gÿ\0~\ÅðŸkó\Ú?ûö*\åÄ™<\ç\Î\è\Îö·E§\Ê~FP\ál\ît\ÕhY»õzµk\ë\ìÏª¯>;\Üj^oNºõšÆ·q\Â4y­­%Ži\ZM·6\æ&mgqSrL\Ñÿ\0\á\×\Å\Zþµˆ¡õMr\ÃZXZ\ë\"#l\îþY;\í\Ûñ»Œc¡\Í|«ÿ\0	ö±ÿ\0=£ÿ\0¿bøOµù\íýû—d\Êö£=}:´ÿ\0ŸºL¹p\Î{?Š¼?\Í\'f\Ñô¾ñ/E\Ð|Lu}3\Ã«Kwr\×óR2¼\ÖwyR[nX\ÑTüÒ²\È#x¼¿\Ã?<=\áµe±\Ð5{:ò%Q¥\ê:\Ä®\áX¸Œ\Ú.ƒ.\ß-—\r“‘ó/ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìUK‰r™.WN¥¬—\Éj¾\ßB\n\çJJj­;¦\ß\Í\îþ¿\å\Øõ:+\Ë?\á>\Ö?\ç´÷\ìQÿ\0	ö±ÿ\0=£ÿ\0¿b»¿\×,¿ù\'÷Gÿ\0’<ÿ\0õ2ÿ\0Ÿû\åÿ\0ÈŸG\Ùünñ~—\àx¼#c¨\Çg ­¬Ö’[¥´lfI^F³²–ù…~R0\0\ï’x:ò\ÏøOµù\íýû\Â}¬\Ïhÿ\0\ïØ¬©ñfWI\ÉÓ¥%wwe_w\ïT\à\ÜÞ²Š©Z•Y^R\Ñv^î‡¿\ÚüM\ÖôM\Óty#\Ðá²˜\\™4ý\É%\ÌÃ¤“1bXÀ(¹¬x¼Q¬Í©=žŸ4ø2\ÇaG?w\ÚX€I\ä…À\Ï@+\Åÿ\0\á>\Ö?\ç´÷\ìQÿ\0	ö±ÿ\0=£ÿ\0¿b”x³+„¹\ãJiúG¯ý¼9pnm8òJ¬\Z\íytÿ\0·Hþ|C¸øY\ãK\ÚC$\×Vö\×pE\ä\Ü7š\ÞHVEp	†:\í\ÆGQ\Ðü?ø\é¨øg\ÅZßˆ5ùµ¿júš\Úÿ\0lÁ­=¶«nU\ã!\â»t•—)–\Üd£\n\Âÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠüß“tý¬ö·ð\ã\çÿ\0O<\Ï\Ôý¦cÿ\0>aÿ\0ƒ%\Óþ\á‰yûLZj^!‹Z»ðµ\Ã^Zø\Çþ\ëE‹V±ƒÌ‚M\Ð1“\"\Ü\0\à©‰!ºU+\Ï\ÚB\çTøk….WÄ¶B\Þ;¨ \Z/‰\Z\Ò\Âx¦•\åwhauœ«H\à•h÷.\éš\â?\á>\Ö?\ç´÷\ìQÿ\0	ö±ÿ\0=£ÿ\0¿b¥S\Ë\â’Ug§÷#\Ù/ùù\Ù!ûl\Ê÷ö0ÿ\0Á’\î\ßüú\î\ßõc¸ö”x|g\â?\Ç\á\åj\Þ(Ó¼J°5\æD&\ÖI_\É\'\Ë·y¸\Ý\Æ6ô9\ã:OŒz\r¿†<Q£\ÙøsVž\rZi&´·\Ö5ˆ/m4ù¦é£‹\ìh\Â•€–7 ¨`ÁHncþ\ícþ{Gÿ\0~\ÅðŸkó\Ú?ûö(<¾6µYÿ\0\à\ì—üüþ\êûƒ\Ú\æW¿±‡Oùy.—ÿ\0§^l\î.?ik‰üe©øˆ\èJ÷ð‘\Ç\âm®\Ë.›pP\á˜’¢¢°cFc­\Òþ8ø\Æ\Óx\î\ï_“\Åxj\â\Ó|E\ã{+´—\Ön!³–Ku1¨Í‚²’SŸ\Zÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠ^\Ç.Q\åö³Ù¯\áÇª\åÿ\0ŸUÌ“¿±†\éÿ\0]ÿ\0\ç\×\Ì\ìo>:\èºí¾©¢\ë^º¸ðŒÉ§%–Ÿc«-½Ý¯Ø¢x¢-pm\ÝdÜ’Ë¿÷C,À®\Ìb™©|~‹[\Ñ<]§¡\Ü_\ßk·O3\ß\Ç&™§3H-ž‘&TMžjÎ¥†7\0ƒ\Èÿ\0\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\ÅR§€O›\Ú\Îÿ\0\à—ý<òµÌ´ý\Ì4\Û÷’\éÿ\0pA\Õ?i\Å\Ô5¦Ö£ð\ÛA«[xµüW§1\ÔA¿’	“\Ê\r*‘\0•\ã#q85Ÿcñ\ßGð\ÍÕ¬^\Zð¥ÖŸ£FÚ”óZ\ßj\Â\êi..\í\×p”@cXM„“»sœ¼wü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìT{»——\Ú\ÎÖ·À¶²_óó²_ž\ãU³(\ê¨\Ãÿ\0K\Ïþy¿¼\ëõ.ƒðHð\å\Ãé·š\æ¡;lš\Î\ê;‰­´\é8·”\Æ\Íå–¹\Üþ[a\×knQ¸g2û\â…u\ßø~\ïÁ·–ú$Z•Æ¥¡Á¦\ë^\\šsM\Z#\Å#\Ë¿hO\ÝBG\ÙSó|\Üaÿ\0\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\ÅS§—»þözÿ\0r>_ôó\Ë\ï¿v%W2Vý\Ì4ÿ\0§’óÿ\0§^vô\Ð\Ðñ\ï\Åx3\Ãú$:M\ï\Û4\Ü	5bþ+Û§A\Z¢Á‹o¤\nC\ÚM¹J€wy\ív\ç\Æ\ÚÂ¼­ö• F¬\Ë\\d\íö÷5-¯ŠüK\r\Ä\Ö\Ñ=\ÄV\ë¾i\"¶Ü±.q– p=\Í5G)6ª\Î\ïþ¯þX5S2²Š£\r?\é\ä¿ùQÁ\Ñ]—ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìRöyüýŸþÿ\0,µÌ¿\ç\Ì?ðd¿ùQ\Æ\Ñ]—ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìQ\ìòÿ\0ùû?üþX\×2ÿ\0Ÿ0ÿ\0Á’ÿ\0\åGEv_ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±G³\Ëÿ\0\ç\ìÿ\0ð\\ù`{\\\Ëþ|\Ãÿ\0Kÿ\0•m\Ù\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\Ï/ÿ\0Ÿ³ÿ\0Áqÿ\0\å\ís/ùóü/þTq´Weÿ\0	ö±ÿ\0=£ÿ\0¿bøOµù\íýû{<¿þ~\Ïÿ\0\Çÿ\0–µÌ¿\ç\Ì?ðd¿ùQ\Æ\Ñ]—ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìQ\ìòÿ\0ùû?üþX\×2ÿ\0Ÿ0ÿ\0Á’ÿ\0\åGEv_ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±G³\Ëÿ\0\ç\ìÿ\0ð\\ù`{\\\Ëþ|\Ãÿ\0Kÿ\0•m\Ù\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\Ï/ÿ\0Ÿ³ÿ\0Áqÿ\0\å\ís/ùóü/þTq´Weÿ\0	ö±ÿ\0=£ÿ\0¿bøOµù\íýû{<¿þ~\Ïÿ\0\Çÿ\0–µÌ¿\ç\Ì?ðd¿ùQ\Æ\Ñ]—ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìQ\ìòÿ\0ùû?üþX\×2ÿ\0Ÿ0ÿ\0Á’ÿ\0\åGEv_ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±G³\Ëÿ\0\ç\ìÿ\0ð\\ù`{\\\Ëþ|\Ãÿ\0Kÿ\0•m\Ù\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\Ï/ÿ\0Ÿ³ÿ\0Áqÿ\0\å\ís/ùóü/þTq´Weÿ\0	ö±ÿ\0=£ÿ\0¿bøOµù\íýû{<¿þ~\Ïÿ\0\Çÿ\0–µÌ¿\ç\Ì?ðd¿ùQ\Æ\Ñ]—ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìQ\ìòÿ\0ùû?üþX\×2ÿ\0Ÿ0ÿ\0Á’ÿ\0\åGEv_ðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±G³\Ëÿ\0\ç\ìÿ\0ð\\ù`{\\\Ëþ|\Ãÿ\0Kÿ\0•m\Ù\Â}¬\Ïhÿ\0\ïØ£þ\ícþ{Gÿ\0~\Å\Ï/ÿ\0Ÿ³ÿ\0Áqÿ\0\å\ís/ùóü/þTq´Weÿ\0	ö±ÿ\0=£ÿ\0¿bøOµù\íýû{<¿þ~\Ïÿ\0\Çÿ\0–µÌ¿\ç\Ì?ðd¿ùQ\Æ\Ñ]—ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìQ\ìòÿ\0ùû?üþX\×2ÿ\0Ÿ0ÿ\0Á’ÿ\0\åCüñBûÀþ\Õt½29 \Ô.µ=?T·Ô¢›k[Ik\çm\Â\íù²f\Îr1·¡\Ï‰§þÓiº¯¢Xi^#ðÎ“u©Kª[Á\á?¾šb’h‘&ŠO\Ü:\Ë\äŠT2Wsg5\çðŸkó\Ú?ûö(ÿ\0„ûXÿ\0ž\Ñÿ\0ß±D©\åò½\ê\Ï_\îG\Ëþžy/¸\\\É4\Õiÿ\0O%\çÿ\0N¼\ß\ÞzwÄ¯‹\Z‹gi§‹\Ï_x?H\Ò.u”\Ô\ÒkhQm\í\ÚT\â<¬Á¢±2\à\0FÀ\Ü\Ö6»ñÿ\0MÔµKýOOðö©¡j:\æ­±®]\Øk¡ey¢.ø²o³\æ\Ô$g\Ëy\Ì0 »Šÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠnž^\å\Ì\ê\Î÷oøq\Ò\îÿ\0óó¸{LÇ•G\Ø\ÂÖ·ñ%\Ú\ßó\ë·\Ý\ÐôûK[Y\ë’_\é¾Ž\Õ[UÑµ\\Iu›4–Vf¢‚5’IšbZ@‰£!‰,h\é¿<9c\äE/ƒ¯®í´­nMDI5µV·¸‘bÞ—,¶\ÃÏˆ¼°!`Žr8\ßøOµù\íýû\Â}¬\Ïhÿ\0\ïØ¥\ìòõª«?üy\Ó\Ï\î¯\ê\à\êfOz0ÿ\0Á’\ì\×üú\ì\ß\Þw~ø“s\ãxÝ7LƒÃ°\Ý.«y©\ß\Ç7v³\ÝM-\Ð\Ø\ÛwŽ\å\Ó\ÉM\ì\Ü\àvS|d¶³ø{\â\Ý7@…uk}Z\ÎóCšYœGakm¹R\Ø\Â8p\È Rr\nùGx\Öü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìP©\åñiÆ¬ÿ\0ð\\{\ßþ~~o£°\åW2•ù¨Á\ßþžKÿ\0•}ÿ\0.\ÇSá¯‹ð§Ö´x’\×M¹’\ëGo[\Ë\Îdb”=ƒ,¶ø1:±$¿\"¼·T¼]KR»»Khl\ÒyžQon¸Ž \ÌN\Å”g\ØWSÿ\0	ö±ÿ\0=£ÿ\0¿bøOµù\íýû½Ž_§\ïg§÷ÿ\0,m™jýŒ5ÿ\0§’ÿ\0\åG7¤\ë\è³<¶\ë˜\Ãn\ç\\\à{ž\Õ.¯\â­n8\Ö\äF|²J²®\ÏQ\×\éùVÿ\0ü\'\Ú\ÇüöþýŠ?\á>\Ö?\ç´÷\ìSöyüýŸþÿ\0,µÌ¿\ç\Ì?ðd¿ùQ\É\Ù\Ý;…˜E¬½€®*y5‹‰\í\æ†r.VFß™rJ7ªœñü«¥ÿ\0„ûXÿ\0ž\Ñÿ\0ß±Gü\'\Ú\ÇüöþýŠ=ž_ÿ\0?gÿ\0‚\ãÿ\0\Ë\Ú\æ_ó\æø2_ü¨\ãk£ÿ\0…\âoøA\áþÛ¼ÿ\0„[\í_lþ\Êó“\æ\ã\ïcõ\ÇLóŒóWÿ\0\á>\Ö?\ç´÷\ìQÿ\0	ö±ÿ\0=£ÿ\0¿bg—ÿ\0\Ï\Ùÿ\0\à¸ÿ\0òÀö¹—üù‡þ—ÿ\0*8Úš\ïýjÿ\0\×4ÿ\0\Ðiø£R¸\Õ/m\ç¹}òy\n2\0dž\ßSY—\ëWþ¹§þ€+‚¢‚“T\Ûk\ÍYý\×›=*nn)\ÔIKªN\ë\ï²ü‘\Ñ\Þø\àø³\Çþ ñ…¯ö\Ô?\èñ\Ü\Ù\éþNš$‚’(\áÊ‹dJ#m€=y¯AÖ¿ikiº§‡üO\á»;ÿ\0´[4m\ÆAjt\'E\Û\ÚË±O¾7™\É88#\Åi\Ñ\Æò±¬\ç°£<’\0	¬I-?Ö·ýsý\0\Óm\ÈŒü\Û?\ÂjKh\Ý$•”<R2’1¸ma‘ø‚?\n±\áÙ¦·\×,¥·¿þÊ%—\å¤_³\Ò\\\Æ¿{*qÀ\Í¢\à\í$Ï¡\ítû;…÷úyñ‰m\ït­\ÚG¸me\"±\Ùug-\ÏÙ¼¹d\ÌQAƒ&KÈ¼\0Ÿš+\ê¯E¢x›\Âsx—Y´\Õ|_kºkðøZ\â8žñ-)\ÔL\ÑI*ù\à\Ó\Ä\Ý\×+\åZOø’þ»’¾\Ûú\Ñ\\ì¨¢Š\Ü\Ì\æ´_ù\nAõ?\È×´ü5]-¼	¦ý¼\Ø\áy¬+û[o\Ø\Íç“§ló·ü˜\Û\æmó>Mû7ü¹¯Ñ˜.¥	\'\0d’~†º­ÆšÖ¤2\Ø\ésY,\ïr±_iöw{$uEvS21\\ˆ\Ó |¢¹¤›³]4Ýœz³ÿ\0	\'\Ãû…úÞ®X\é/\ã\ÆK\Õó¬4°\é\ç4¶¦#\Ð\\@\n¯‚Š”‚\Ëu¤\Ï\ão‹\ß<l¾mßˆ\'¾6Qz\Ý[Ý™\Ó\åUù\È\îkÍ¿\ádk¿ó\í\á¿ü\'ô\Ïþ1X\í\â-oþi¼E§%®¹-\ÃÝµý¬\ë¢W%™Ô¡I$ý\Üu¢7\æ\æ’\èÿ\0‘³””¶·Ïªòò>’ø&/…|E\ã­)V;]>O\0Úº½\"\\ˆÑ³´rtñŽrj]à·€|/ñ’;;{?Ü§†¼e¥\éSÿ\0k\Ý[ù:€¸w\Ø.ÂŠ\Äþla\î²1òú\ê\Z’\é¿\Ù\ÆþS¦ý ]/µ~\ä\Ìo™³v7\í\ÈÝŒ\ãŠ\íþ&ühñW\ÄoÏ­¶³©\ØZÇ¨>¡¦i\ÇWySLrÛ„\ä ÿ\0ªš\Ò-\Å\ÆW»\êþiþ-\ÎÞ¦ÓŠ”\\V‰\ßò²üûlðK¨kž-ñµü\Öó[x[ÿ\0„~Vñoˆ¬\Ò\å´\Õ\é\Åe¸h|\Â@«±~Qòö®CAýŸ|=¥ýOñL^ ¼\Ö.üe?„—ûxc‚=©KŒ¼L_ýk0L®õ\çrmù¼*óP\Ôõ+k{{½B[«{r\íS]oH‹¶\ç*`nnN:žMw‘üpñm¯€SÃ¶zÞ©ew%ü÷Wzœ\ZË¬—p\Éˆ$\0‚Ê«\0\ê\Ä`ŽsŒycn\É/\Æ=z}¯½ù\'\Í6û¶ý4vÓ¯\Ù_%\ævZoÀ\ïI¢ør\Ú\â}r}k\\\Ó5{\Ä\Õ-\çt\ëf²’\ä*c-\"2À»€u)\ÙmÁWŸñ¯Šµ}/\á<ñ6±>««\\\Íe{e¥J\Å\â\Ð\í\Ø–7™fŠG\ÑToùŽ­ño\Ä7Ÿt\ØjºN“§\Ù\Ëiymmª0ƒP\ßs,á¤ˆ§n\Ü\ßw<g\'Zø•\ãhk£j\Þ1ÖµMB\Ó\ïuyf·>\æ#g+\Æ8\â›O\ÞWº¿\äÛ¿—@º½Ò¶ÿ\0‰\ÉQRý•ÿ\0½ýü_ñ£\ì¯ý\èÿ\0\ï\âÿ\0Q$TT¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ã@QRý•ÿ\0½ýü_ñ£\ì¯ý\èÿ\0\ï\âÿ\0\0EEKöWþô÷ñÆ²¿÷£ÿ\0¿‹þ4/\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\ÐTT¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ã@QRý•ÿ\0½ýü_ñ£\ì¯ý\èÿ\0\ï\âÿ\0\0EEKöWþô÷ñÆ²¿÷£ÿ\0¿‹þ4/\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\ÐTT¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ã@QRý•ÿ\0½ýü_ñ£\ì¯ý\èÿ\0\ï\âÿ\0\0EEKöWþô÷ñÆ²¿÷£ÿ\0¿‹þ4/\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\ÐTT¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ã@QRý•ÿ\0½ýü_ñ£\ì¯ý\èÿ\0\ï\âÿ\0\0EEKöWþô÷ñÆ²¿÷£ÿ\0¿‹þ4/\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\ÐTT¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ã@QRý•ÿ\0½ýü_ñ£\ì¯ý\èÿ\0\ï\âÿ\0\0EEKöWþô÷ñÆ²¿÷£ÿ\0¿‹þ4/\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\ÐU\Ó\è~ðþ¡\á»ûûÿ\06k÷tÿ\0±y>~\î\Æóy\ë‘\Ås¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ã@§ü±ÿ\0®/ÿ\0³\×\Ðÿ\0khþ\rü,\Ôü;†\í\î5••¦°¼@9\Ï\Ìn°C1AŒm\ê\0_—Ï«…x²\ç\Êu?0\ÆN\ìsøŠ‡\ì¯ý\èÿ\0\ï\âÿ\0s\×\Ã\Ó\ÄÇ’ªº\ÜÚ•YÑ—4§\ÛZ~‡\á\ïi~.ñ>·ð—Pñˆ¯´K]N˜£¼{{å¸²‚IDSM+¢¼r»¨\á\Õ**Â¼;\à‡\íþ\"\èZ¯†/Fû]7R²ñ£œ­¤lb½#\0Ÿõr#ùg\ÏA\\·þ5ø\Ç\áÏ‚õ\Ï\è:„V:³’e*\'…°ŒR•, )\'8\ÆWiæ¸­6ûR\Ñ\ä\ì/\ä±y\á{yZ\Ú\ë\Ë2D\ãa†U‡Ou®l\n¸iT»\ÓKj\ÞÚ¯Et¿«\Z\âjB²…·\Öÿ\0=þv¿õs\ê=kI´ñ\ä\ÚFµw¾\Î\Û\âö·£\Ù\Êm6«¬q6\ÝCa+·?iò˜p@8\ë\ÍCðÁ^ð·Œô\Ïi\Ö^#G³›]Ó’-Bú\Þ9Å¥‹L·qò\È\É0\Æ9m\æ>Ò§À<\ãmG\Â~)ð–©<²j–>\Ôc¿¶\Ód½\Û\í•duL\äG¼ \É\îA\Å/ˆ~#x·Äº\à\Õ/<KªOsK³Ïª¼m•¡F-•B¬T¨À ‘Žk\Ðk•5\r/{yh’õ\ë÷\ß{«_]¾ý:z\Ú\ÝY\ï\ß|u¯x\Ø]\\\éŠÿ\0g½š\âm{]³[ð‹¹4÷\Û,‰,\ÌnÄŒY\æ\ÛÀ\ç\Æh_¼-u\áŸ\nÅ¨§ˆ`ñ¿¤\ê·\Ít³B–VY½\È;Ñ£,\êD*oB™\Î[pUñ‰µ=V\æ\â\Êyµ)¥ž\Ê4Š\ÖG»\Ë@ˆrŠ„·\Êô§j\í¼Gñ£\Å\Z÷‚t\rG«\êVvvö\ÓÃ©*\ê\îc\Õ^K©n“Gƒ.>m\Ù\Æs\Î(š\Ñò\ï·\É\'o\Òý\Â/no_óÿ\0€v\Z\×ÁY\è7i\ë\âøHmü)§øœ^]IY;\Ï\ä¶yA˜˜…}ÿ\0{\ä(pX\å|V\Öuÿ\0iZ/ƒuKû\ïx\ÏJ¹½º¿•CÜµ‚ùqî²¹%aH\ï³÷jIÛ¥ŽŽ>1ø›\ÅöºFŸ©¨iz6›cclš\\z³5¿mD.\\”\Ý\Ó#=N3Yz\Ç\Åoøƒ\È:§Ž5ýK\È\ß\å}³Z–_/z\ßn\é7#2œuA\àÓž­\Ûk¿\ÏON—ô]Ø£\î¥}\ì¿-}u¿\ß\ä[ñD\Û<	{ñF&h®¼K¢\Ø\èÍ¸–€˜¯YO]\Æ+<Ÿk°{Š\ÒñwÀÿ\0iw~1\Ö<e\ã=MIñ\îiq<³yÄ\æ\Ìc³›Ï‘Œ£\äfƒ!	rvü\à÷Ú”š\\\Zk\ß\Ê\Út´ñYµ\ÖaŽF\03ªnÀbA d\í•¹¥üJñ¾‰u©\Ü\é\Þ1Ö¬.u6\ß5®¯$ov\Üó)W\Ï\'–\ÏSDý\ë\Û\Î\ÞWi\Û\å\ï[\Ô#\îò®\Ûù\éoò¿{yž·cû2\éZÝº½†«wº±±»\Ñá‘„¶l-¾\Øò£&&º\0û‰²8\ã¥Õ¼eñS\á?€<\á\ãþ™kÞ¥£\\^=™\Õna¸+‘1À\0,2šù¶\ßÄ¾ µû\'“®^\Ãö;y--¼»ö_&7y‘&\åF\ÞùQÁ\Ü\Ù\êj%Öµ˜\ã´E\Õn-!’\Ú\ÙE\á¤\Ý\æFƒwÊ­½÷(\à\ïlõ4å®‹k\ßî½¿Fÿ\0\í\îâŽ‹]ûþ¯\á\ç¦¾$i^ø‰ øgZ’\çð§†<!u5¦Ÿ¦:[\Ý]\ÛÃª½¤$»#ªe‘\Ê7FãœŽó\àï„´8un\â\ê:V\Ý\ìzMœ°¥õ³\ß\Äò¯Ÿ!‰•\Âð Fži‘9Ž¼ŸIñw‰´­:\ëLñ¡§\\é±¼VSZj-Ú£–.±2¸(»,s\Ô\Ô\Ö><ñ~—«jZ­—Šu[=SRV[\ë\Ø5GI®ƒ°•\Ã\îpO\'q9§\Ë.e\Þÿ\0ù3Šv¿K]¿\áå¢·\Ýg§[\ë±ôo\Åo…½ñg\Ä/ø\Ç\Äsh\æ\ë\Å7ú]™S:¬hûc´Ÿ\Íbe»gƒ„8s“·\Å~	ð÷ŒõHn~Õ¨ø©<\'¡3F¶Ô¢\Óüô\Zj´²	%‚D‘ª~\çtlÀ¥\âú_Ä¯\è—ZÎ\ãj\Â\çSm÷óZ\êòF÷m\Ï2•p\\òylõ4\ËOˆ^3\Ó\ìo,­|[¬[Y\Þ[¥¥Í¼:´‹ð¢yi¨|2*¡Ox\éX¨µO‘y~	§÷ÿ\0Vz”Ÿ½_Å§ø%o\é£Ñ¾x&÷\â‡µ_‡wÖ·Vs]\éþ!³3£FE¾|©\åUnª`¸Y·t+s]^›\à\Û?—öZî¹©X\è·þ#\Özts3[ÁiicÑ¬¬n\Ë!V2\á\íE\Â1]§\ç\èüE¯E|—©­^%\äv\ßbK…¾\"E·òü¿$6\ì„òþM½6ñŒStý{[\ÒV\Élu‹«5²¹7¶«ozcNBƒ*a¾W\Â\'\Ì0~Q\Ïµz¶ÿ\0«\ég\çd–ž½\ÈZ^Oóm¿¸ö{Oƒ?<Muqy\á\ß__hZT\Ö÷:Ô\Ê\Ò[\Ï1G–\Öw\r\0P\æ ¹¸v’2Ý§Ã¯\èÿ\0õo.¥$šºM\á\Ë\Ö\Ô!;JI¦6©ml…\Ï$K3‚N0ñœzü\å¬xó\Å\Þ\"º»¹\Õ|Qª\êw7v\Â\Î\æk\ÍQ\åy Dåœ–@À6\Ó\ÆFqš§7ˆµë–¦Ö¯%k‹T±™žø“%ºm\Ùe¹v&ð6.—Ÿ\â­þ_û_¥¿Ÿùþg\Ò:/‚—\áO\Ão‰\ÞžKyõ}cF}I\ï\n‹\ïí¢³un\Ë.ù¥>«\å\Z\ç5\Ùó\Â\×þ*¿ðÆ—q®iz†\âK\Ý\ê:œ‘Mñ\ÝD±\Æbl\ÆÎ±—“rŸ¼1“\á¿\ÛZ\ÈûF5[ô‹d²›ý0þö\Ýví…¾nPyi…<\r‹\Ç®jþ4ñOˆ,ô\Ë=SÄš–¥i¦\0, ¼ÔžX\í\0\0³˜\n£\å\ÇA\éG\ÚMù|\ìÿ\0\ËN\Î÷\ryZ^o\æ\Òývì¬¢´?†žø\ào\è60\ë¾\Ð_\Äz\å\Ä\ë«Ê³\Ý8¶±\ÜFñ@9a\Þ!r¸m“n\r¿„\ÚO…4}HE\à\í]µ}!üc\á9³\Ë!†_:\ì<~d–ö\í\'@Û¼¤69\ÆOÎš§Äkš…ö¥\ã\rkP½²˜\\\Ú\Ü\ÝjòK$€\0‘œ•l*üÃŸ”zQ¨|Hñ¶¯~/¯¼_¬\ÞÞ‰!”\\\ÜjòI&øK[q|\å¹Sü%›É§Ó¿ø¿;mÓ¾\â’R‹Š\ì\×\Þ\Ûü/¿S\Þ\ã\Ò\íüa¡üVñÆ™\Z[‹\Ý];[…B„¶\Ô¡i‰p:$\êƒ¾³ÂŠ\Èñ—\ìÿ\0\à\r+\Å7~Ñ¼G}\ã;U»·!¥f¸¹ŠÝ¥¶Ie\Æ£(#IfÏš„HBüþ	k¬k6úŒÚ­Å¼\Z’„½Ž+Â«t¡·(\róÀ6y\æ¶.>%x\Þò\ÛJ·Ÿ\Æ\Z\ÔöúL‰.š¼Œ–nƒÐ‚øŒ¨\à\ÆJ…|­ÿ\0\r\éwm?+—)^NK»‚\ß\î\×þ	\îþø#¡ø\âW‚õ›}Z\æöõ\í\Â”\Ãjbõ£¼C…\æ4û4Œ¸\çÅ’{\Ðñ•ÕŸ\Å-s\Ãþ\ZÕ¼Lþ?\ÔtË½SP\ÔõÕº¸¶Zj¨³ý¢\â\Ù\åa•,‡¸ö bxðH<E¯Z­˜‡Z¼ˆY\Ý\ëañ_\"\à\í\ÌÉ†ùd;W\çü£žG¤k:Ï‡õ˜µ}/U¸\Óuh™ž;û;\Ã\è\ÄH‘X0$“ž\æ«Wkô»û\íø]z\ÛK\îN×·[/º\ë\ïiýú\Ûc\è/ü:ð/\Ãÿ\0‡~:K+ýZ\àM \Ýéš±¼E’\Ýn­f‘UY\íF@Á‹|±—ò\ÆP–±\â\ïþ\Ò\îüc¬x\Ë\Æzš“\â;\Ý\Z\Òþþ\âyfó!‰Í˜\Çg7Ÿ#G\È\ÍB\ä\íðy¾ x\Æ\âmNi|W«K.©·¿‘õY]\Ä9Nÿ\0\Þ(\Éù[#š—Kø•\ã}\ëS¹Ó¼c­X\\\êm¾þk]^H\Þ\í¹\æR®žO-ž¦¦I»\ÛúøDõóò*ú¯\Ç\ÏOó\ÖÇ¨^|#ð%Ž“rªž\"ŸWÓ¼3¥ø¢\êF¾-\æI\Ú\ÔOl‹\äC‹‚VB[‚‡›ý¥¬t=+ã‡‹l|=¥6ak}$&\×Ì£\äÄ©\Z\Ó\Âa±ƒóñ\ÅI¯\ë’ù\Ûõ‹·ó­\Â]\×\Ä\ï¶M»!o›˜\×bab\àp)<A¯kž,¼Š\ï\\\Ö.µ›¨¢X#ŸP½3ºF¹Ú‰\n2p:\ÕKÞ’kmú$—\ã\ë1\Ò6{\éù/\Ö\ïð1\è©~\Êÿ\0Þþþ/ø\ÑöWþô÷ñÆ€\"¢¥û+ÿ\0z?ûø¿\ãG\Ù_û\Ñÿ\0\ß\Åÿ\0\Z\0ŠŠ—\ì¯ý\èÿ\0\ï\âÿ\0e\ïGÿ\0üh**_²¿÷£ÿ\0¿‹þ4}•ÿ\0½ýü_ñ ¨©~\Êÿ\0Þþþ/ø\ÑöWþô÷ñÆ€\"¢¥û+ÿ\0z?ûø¿\ãG\Ù_û\Ñÿ\0\ß\Åÿ\0\Z\0ŠŠ—\ì¯ý\èÿ\0\ï\âÿ\0e\ïGÿ\0üh**_²¿÷£ÿ\0¿‹þ4}•ÿ\0½ýü_ñ ¨©~\Êÿ\0Þþþ/ø\ÑöWþô÷ñÆ€\"®Ÿþ\ïÿ\0\Âý­ÿ\0	#koòÿ\0±þ\Åó\îõ\ß\æ}\Ì=±š\ç~\Êÿ\0Þþþ/ø\ÑöWþô÷ñÆ€%ùmÿ\0\\Sÿ\0d¯_·±¼Ô´½>mÄ³\Òô\Û[›o\ìip·7$A\ÊûA\Û0’V$žv¦1‚\Z¼…°\Ï*\\ùH£\æ\ÈÛžRZ\Ý_\ØCq\rµ\ë\Û\Åp»&Ž+«*\ç8`#\Ø\×^²¢\Ý\Ö\æ´\ç\É{šÿ\0d¶›\Æom¤!¡·i£±*aI\ÌùÁv’0$\ßÐ‘^µðf\Æ\Ó\Æ\Þ\n\Ñç¿‹Ïƒ\áö«>¯x®\ß+i\ï	›a\Ýó\íBq\Þ\äu&¼\ì¯ý\èÿ\0\ï\âÿ\0[±¾Ô´\Ø/ ³¿’\ÒÈ¼‹¨\àºØ³Ç¸6\Ç¾eÜªpx\Èµa9¹9IhÞ«\É\Þÿ\0×‘”­9]\íú=ç§™ô‡ð\ÓOø•¥\è¾%ñŠ5I-?\á¿\×\ïc¸º“j0\Õ$€¤%-\çhc\Üþk‘œ–\áCZ\Ú\'À?xªò=CHñ5\ä\ÞKË‹K?\ê\ç³­Hcl.B±dR\Ëo+\0™\ÂøÆ“\â\ïh7ZuÖ™\âCN¹\Ócx¬¦´\ÔZ\'µG,]bepP1v$.2Xç©£Sñw‰µ©/¤\Ô<C¨_½ô\Ñ\Ü]µÖ¢\Ò‰cc’B\Îw²‚@c’8¬ì¯¦‹_\Åþ‹Eæ¶õ{\Þÿ\0†\ß~þ]£ü\á\'Á~ñ¯ƒuIŠ¶µýƒcª\Éu·e\å\ÌW²\ÂGj\Ä\æØ¶r~Y=±>‰ð\ìÂ©?\î™t½^OhGY¹h\Ã=½\Õ\ç\ÚG—\Û>\\+ËŸ¾\Ò\×\ÌW\Þ \×u?\í¶k7w\Ú3-\Í\ïŸ|_\íR®\í²I–ù\Øol3d\Ç\Ô\Óf\×5«…½\ê÷R\é\Ö\ê\ì=\é?h™K’O›\æp]ð\Ç$n>¦Ÿ\ÄÛ—Wü¹]½4~{v³Qí§­­\ëMûžÅ¥üðw‹%\Óu\r2i\Zj\Ý\ê–÷zeõ\Ä77·B\Ê\×\í\'\ì\î°\Æ˜~\ì©F\ØH9»]œ\ß\r|)\ã¯ø\âò]OAð¶\à\ë\Í\\\Û\ßN\Æ\ä©\Õ$@\Ð\Ú\Êv.\ï1m\ÎTª‚Y~|\Ôþ!x\ËZ\×,5­GÅš½þ±a²jZ¬’\\[\à\äyr3–LOri\ïñ#\Æ\Òk\Ö\Ú\ãø\ÃZ}j\Ù] Ô›W\ÜÄ®Ip²oÜ¡‹6py\Ü}ju²_\Õ\ì\Õþm\Þ\Ý-¦\ãv¾ŸÖ··Ý¥ú\îÏ¥þ¶•\á8t)¼#ªj\évZ\ç‰g°½‘\îÆ…€D‘\Æ[keI1¦\í¹\Ú\ÅcxážŸ\ã\0\ê2hn4Ÿx\ß\Äú0¶6vk´¸¶À#&&pTGˆñšù\îóÇž/\Ô/\î\ë\Å:­\ÍÓ¼’´ójŽ\î\Ï$B)±|’Ñª£\êž+6\ßV\Õ\ít™t¸uKˆt\Éf[™,£¼\ÛÊ … m¥€$\ÆFj·w}£ø4\ß\ßo\ëQ;òò¯?Å¶¾\ëþ~G¸^|ð/Šµ»\ÝÀúý\ÝÞ»og³šieX6]\Ç\ÆF–\Ê\Ôñ¦Bª§gùf\Ýòõ\rþ\èŸ>\'\éšÎ‡\â\È \Õ\"\Ô\ä\Ðu‡*\ÑY\r\ZIZ\âCnÞ’M\Z\åX¤Â“Œ|ý«|KñÆ½yoy©ø\ÇZ\Ôn\í\â–g»\Ö%–H\ã‘vÈŠ\Ì\ä…u\á€\àŽ\re\Ã\â-z\ß\ìF-jò3e–¶»/ˆò!“w™\Z|\ß*6÷ÊŒ½³\ÔÔ«¨8\ß[5÷\ßþ\ÊþCÓ™¾Ÿ\×ü\Ã\Îþß©Å ü]ñ6™&·­\É\â›\è*ž ñr\Ý\Ïd.ek’°¶÷³žyv‰¢ƒ&\r\ìW\'\n»«¨ºø_\á/\n\Üxc\Âú|ZÍ¦¶¿g\Ñbñ5¥\ìV÷ikL0Å¾ðV9Ñ¸m“{ôm‹óG†üG¯ø6ù\ï´\rnóC½x\Ì-s¦ß›y	R\ÈÀ\í8t\àU\è~ x\Æ\ÝnV/\ê\Ñ-\Õ\Ú_\ÎUy·(C$Ï‡ù¤RªCžAŠ­_{ÿ\0À“ÿ\05ó%Ý§ý}—\ÏS\ÓõÏ„>ðÿ\0\ÃX5­o\Ä÷x—XŠò\ïOGy\Ù]¢¹’	E³t‘›\Ë;®b\ÚdB_·\Ñ~|:\Ñþ,-¥ž¹©C\á¿\Z\éº%\ì:µå´\ß\ÇrÒ…;¿\Ê\â•·	<\ÆO\ËóÅ<_¥\èwº-ŸŠu[Mù®´ø5GK{‚\à2Fk\0sŠª\Þ)ñ—7W-¯_5\Å\Õ\Ìw·A‹\Í<d˜\ås»,\êYˆc\È\Üpy¢>\ë^_\æ¿D×\ïkŽ§¼¥n·ü«ùÿ\0ðòM?Fñ\'ƒ\ÛÃ–—\ZeŽµñ&[ˆ¦¸Y¤Ú½«\Å:G(d¸‘ö\í\äN¥3V\ã\Òcñž‰ñ[\Æ\Ú=°Y/´It\Ýb\Ò  C¨B\Ó\0\è·\nƒ¾³Š+\Ã\áhx¦kMA/5Yu\ë»\ë}Mu[»\×{\Û{¨ATš9¼ÀÁö§vxŒR9û]cX±ƒQ‚\ÛU¸·‡RP—±\ÅxUn”6\à%¾q¸†\Ï<\Ô(ûª/µ¾ø\Å?\ÉþÈ¾o{™wOî”¥ú¯¹£Þ¼Aû;øR\Ú\ÛKµ²¼¿‹_¼ŸQÑ’\êjŽ-Z\Þ¤HZF³€\Î\Í	X÷¨fB% j\è?lu->\ç\Âñk\ÚÅ…\Ú\êú›ª\Ûý¡^\Ó\í—B\à\Ëû\ç‡\Z‚\Ù\Þ%\ç\0ò=c\âŒ¼Aqaqªø³WÔ§\Ó\äYl\å¼Õ¤•­œc\rg%ÀÁ\è*¥ž¿©\ÉZ÷R¾¹´¼¼ŽóPŠKË’\êEf;Ë\Ã\Ì\ß\Ê\Ä\'\'6·\×\Ëðiþ:úi\Ø\Íü6[\Ùÿ\0_-?\ç±CðW\Â~ \Òü?­i\Zoˆôý>\ãT\Ô\íµ}oRŠ3­œ	,“‰’Ð‘€\ÎX\\\åJ*±\ä\ìx\Ç\á×~ü;ñ\ÒYX\ß\ê\×m\ïLÕ\â,–\ëuk4Šª\Ïh’2[\åˆ\È<¿–2„·ñ\ãö¹\âeð\ê\è—úþ•6‹-\Å\Ôz¶§\âV¿\Õ$ž`¨\ÌnUbÚ¢4DUU²N\ê\á\æø\ã‰µ9¥ñ^­,º¤\"\ÞþG\Õd-w\å;ÿ\0x£\'\ålŽiF\ë/\Â\×û\íò\×Ð½??\ÏO[-<ô\ísÜ¼IðO\ÃPø\ê\îz\ï\Å~$ºÖ¼cs\á»[\Ø/bi\àd“=\Éx\\\Ü;\Ô\ì,ˆ\Ø\î\çŒ-3\àŸƒ\'\Ñô+	nµ«kZ>±¨C}ou\n\ØDöOt1˜‹ºH¶\Ü\áÔ®rg\åv¼e§¶®Ö¾,\Õ\í›X\Ïö“C«H†÷ ƒ\çaÿ\0y\Ã0ù³\Ôú\Ö}¾¿®Zý\È\Ö.\áû2[[yw\Å|ˆ¤\Ý\æF˜o•_\Ì}\Ê8;\Û=MG+\ä\åòÿ\0\Ûmÿ\0¥k\ç³\ØKÏ¿\êÿ\0K/•úž¯ñÄ¾+ðL\Ð|u¥øGTÐ­&†\ÛM\Ü \Õ\ä’ûSÎ b\åü\ï626Ð0\0™¬|ðÆŸ¡jQi|A§øj\Ë\Är\ê\ÒOÓ§ˆ[\ÈX| \É\ÅÂ \ÊÛ\Ø7q\æúWŽ¼[¡x~\ïB\Ó|Oªiú%\Þÿ\0´i¶º£\Åm6\å\n\Û\ãW\n\Ù\0‘\ÈÇŒ<Ow\á«\Ï\â-BoÛ¿™“&¢\Íid\Ë}ªr\Ìrs\ëZ\évû»þz|®¼¶HQÓ–ý¿-~v~—¾­Gh¿¾hÿ\0\Î\Ò\Ï\\Ô¡ðßt\ÝöZò\ÚHo\ã¹iB‚\ß\åñ\0\ÊÛ„‰žc\'\å\ã´ÿ\0„\Þñ‡ös\ÙÇ¬i~\"ñœž²Y/¡–”[‘À­™œ*)Œr¼ü§·Š|G%\Í\Õ\Ëk\×\Íqus\í\Ä\ÇPbóO&9\\\î\Ë:–bò7iu¯ø“Ä’4š¾¿ª\ÈÓ›¢÷ºƒLL\ÅU™f?9TE\Ý\×£°©No\ë\á¿\ßi}\â\è\Òþ´—\ê\×\Ü{\Ï\Ã_øj\Ë\ÄV>!ðå¶·¤\Æ\É\â-&[\rv\æ+‰¡Ò¥5\"‹\ë²;N>cž4µ†~ñH%ñ–±.›¤iðÍ¦\Øf–º{w³\Çit@\"˜Àb\Ã\ç\\\0\ß?j\ß<c¯j\êzŸŠõmGR†¶Šò\ïU’Y£‰\Ã+Æ®\ÎHVÀ¨8!ŽzÑ£øû\ÆÔ¿´4¯j\Úeÿ\0Ù’\Ë\íVz¬‘K\ä \"Þ®\Å\n .p6Œ)km|¿ký÷ù_M‘N\×Ó³üZkîµ¼ú\ît<\áOø\'Â·zMÎ¥ª\êzÐº¸þÐ’TŽ\Ð\Û\Åw<R˜\Ö4o™\Æ\ÞF\ï—i¾øsþ\Ïø 6ªºÿ\0ˆ†™4šó\\\Æ,;°­¶+o+s\ìy˜\è\Ãh¯/Õµ__h›T\Õ.5&ˆ¹Œ\Ý\ÞJov‘ñ¹Ž7;3VbO$\Õ\Æñ—Š\Ãpxu¼G¨·‡\à“Í‡I:“ý–7\Ü[rÅ¿h;‰9©&ª:o\Þÿ\0.ß—­¼\Å?zö\ÓG÷÷þ»ù¿\á\ïƒ~ñ~¡¥\ÝÛ§‰ô-!\îµ{;«K\ë˜..œ\Ù\Ù5È–\'Æ½v«\ÆT\í$|ÿ\07\Zžð7\Ã\Í;Áú\î¾4bÿ\0O\Õ|&©mk{©[½ÅŒ±\êkm&É¾É‚ÄªpŠB™ƒ¸2øž­ñ\Æ:ö©§©ø¯V\Ôu(`{h¯.õY%š8œ2¼j\ì\ä…`\Ì\nƒ‚\ç­C¤ø\Ë\Å\Z–²i~#Ô´\Ù-`{X\Z\ÓRxŒ0»xÐ«¨\ÌKI5\r>[y[ð’{iùZÈ»®d\Ò\ëú\ßò\Ó\Ïvz\Äÿ\0|§«\Ë,~!¼M\'\Â~%Ô¡‚ú{¹.V\Ø,P!¼”F¸,\Î\ÂBTch\Æ\ã\è?|%§x?R‚\r)\ï…\ïŠ<©Eo¨k›eŸ\í¤e\n\ßx*\îNÑœWÌš‹¼M¤\ë6º½ˆu=Z\Ö··¿·\ÔZ9\á‰SbÆ’Üª\å\n\0\ã¥ð˜xœ_\Ü\ßjm¹ºŽú{Ÿ\íó%¸Œ“\Ì\Ûò\Ò)f!\Ï ±Áæ´¿½u\Ý?º\\\Öû¬¾^l\É\Æðq}­ø%¾ÿ\0’=o\Ä\ß\n<¤ü?_k~#–\ÓÄº\â_^\éð«Oå–Š\êH„5³tr\ÞYËµ\Ì{®P—ŸÆžÐ¼2\ß¼£NMÃ¶ñ\Þ\Å6­s\Ç\í\Ñ\ÞC•F‚=ñN\Ñ\íù·mž<’\ÇÇž/\Òô;\Ý\Ï\Å:­¦|\Î\×Z|\Z£¥½Áp™#µ‹\0\È9\Å>_k7\Zµ§\\K\r\ÕÆµuÎ¡ª\Ü\\4——!2V\'vr\no!\Ï,ªI;@r\Ù$¶ÿ\0†·\Ýø\ïkš\Ê\\\Ò\æó¿üž\ÞW\ìr´T¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ãVA/\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\ÐTT¿e\ïGÿ\0ühû+ÿ\0z?ûø¿\ã@QRý•ÿ\0½ýü_ñ£\ì¯ý\èÿ\0\ï\âÿ\0\0EEKöWþô÷ñÆ²¿÷£ÿ\0¿‹þ4/\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\ÐU\Óÿ\0\Â=\áÿ\0øCµ¿\á$o\ímþ_ö?Ø¾}Þ»üÏ¹\âÇ¶3\\\ï\Ù_û\Ñÿ\0\ß\Åÿ\0\Z>\Êÿ\0Þþþ/ø\Ð:\Çú\Ëú\àŸÖ«]ÿ\0­_ú\æŸú\0«:\Ïú\è\0 \âŽ3U®ÿ\0Ö¯ýsOý\0S\Z\Ð\ÐuÛ¿\r\êKbÊ—+±+:†\0IF\Ü>\ë\ZÏ¢\Z\Òk·z•–›a;)¶\Óm\æŠ\ÝU@ 9y\'©ù˜\Öl·£\'k~[NiÖŸ\ë[þ¹¿þ€i©g!NÓµ\îš\Å\Ã\âGÑšF—­\êž›Å–\Þûf«i\áƒ`ò[x¢Å­£³†5\íCù\Ê\Â,Ÿ,Ÿõƒ8þ\nùÂ½\ë\Å^\Z·øc¤\é>#¾ñ\r…ÿ\0ö\\WZu¶Ÿ¥-µŒ\Ò4!¹ûKG.K\rÒ¬j\ç’\Ü\äW‚\Ñ/\âKú\êÈÁ\ë¢;*(¢¶ \åtÿ\0øù\î?þ‚j\ÅW\Óÿ\0\ã\ä¸ÿ\0ú	«\Ï\"Â¸z\î+‡¨Kyˆ\äx’uVb“!\\\Ð\í \àûk¶\Ô%\ÓmüUi=\ÜV–‰6•ˆ~\Ê\rº\\<\0«¼j¸+¸ä§\èzWoq-¤ñ\ÏÑ°t’6*\ÊÀ\äGB+Jo\ë\×O.·¨\Ë=¹&\îBÑ’0J’x\È\ãŠ\é§R1ž÷Oðkº\ïø5\èÎ¤“Ž\Ök~ÿ\0\'\Ø\îf\Òt˜n£p\Ö\Ï<z:\Ý\È\Öö#\Ê2üµ‘m\ÈU#f\Ò‚©\ÈbpxŸY½–´û¤I\ÑE:2[-·\Êè¬¹‰~T8# qž\ç­S‡[\Ômõ&\Ô\"¿ºŽý‰-t“0”“Ô–\Îyú\Õk«©¯n$ž\âi\'žF\Üò\ÊÅ™‰\îIäšªÕ£R6Š¶¿\çÿ\0\îû²\Ã\áªQŸ4¥uo\é-6_\ÒÐŽ­\èÿ\0ò±ÿ\0®\éÿ\0¡\n©VôùY\×tÿ\0Ð…qK\ág¤ö={\ã\×ü‚4¯ú\î\ßú\rpzoü’ÿ\0\ØoKÿ\0\Ñ\Z…wšC¤\é{\ÑW÷í¬Oðýr^—B“\áïˆ¬õ½R\ãNó5M:hV\Ê\Ú;™¤\Û\r\ècå¼±ü£x\ËpYF>jó2¿÷Xüÿ\03\Z?\È\Ùý“\ì÷\ßi\Ý\çy#\ì\Ûzyžbg>\Û<\Ï\ÇV¯\é²Mž¬±\Û	\Ñ\í•eÿ\0\Ëó¢;\Çü*ÿ\0À\ê…z¦\áEP­K\ìŸhO±nò|˜·o\ë\æyk\æ~÷c\ÛV¯\ë’M-\äm5°µ³[¨{¨…¿ü	@oøP ­Yý“\ì÷\ßi\Ý\çy#\ì\Ûzyžbg>\Û<\Ï\ÇV¯\é²Mž¬±\Û	\Ñ\í•eÿ\0\Ëó¢;\Çü*ÿ\0À\è…Q@Q@Q@¬þ\Éö{\ï´\îó¼‘öm½<\Ï13ŸmžgãŠ«W´ù<»MM~\Åö­ö\á|Ý¹û7\ïc>gCŒ\ãgoõ{\Z4\0QEkRŽ\Ò+„R´\Ðù133ŽD†52ƒ€\å€ö“Öª\Õ\íbO6\î6û\Ø?\Ñ\à_+n7b$gA÷ñ¿þ\Ôõª4\0W©ü¾º\Ô4\ßxf\ãP’\Û\Ã÷ú,³Ü‰Ýš\Î\ÚXä‰£º–1–%thò|ø\nA\"¼²º\Ï	x\Î\ËÂ¾ñ5ªis\\\ë\ZÅŸö|w\Ívx\ZH\ÞO\Üùyw>^y€\0\Ç\å\'\á’\îŸ\å§\ãý\\>\Ô_šüõ9YG#ªºÈªH¹\Ã{Œ€qõ\Ú( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( º;_øõ‡ý\ÅþU\ÎWIf¡­\à‚‚ª7\àqÖª IO†?:h\ã\Î70\\úd×¤]|\Õ,ã»¿—S\Ó\×Ã°\Ùý®=ky0M‘ò¢ón-\Æ1Ç¾@>ueÿ\0\×Eþu`iÿ\0\Â;ÿ\0Oø\çÿ\0^øG\é\ãÿ\0ÿ\0\ë×£ü-\Ðl|E\â‰\í5>\ÑnºV§r{/\ï\"±žX\Û*A\á\ÑN:`\äq^¿\'Á¿jž$øh4\Ë\" q¡G\â]9®$&U¼H[\í*s¹U\ÚG‚ˆñ\â¶\å\Õ.öün¿B²o²o\î·ùŸ,ÿ\0\Â;ÿ\0Oø\çÿ\0^øG\é\ãÿ\0ÿ\0\ë×³Â¿\Ô!ûD\Z®‘esz·wZf‰s,\Â\î\î\Þ‘]Ðˆ\ÌcýT€	$Vo,\àŒô!ø%¦hº„ÖºV»¢\ê¶\ßðYk——\Æø)¶\r4a!MÀ™òªVB#Ý¹C…´­n¿ðÉ–\ÓRqþ·KõG\Ï?ðŽÿ\0\Ó\Çþ9ÿ\0×£þ\ßúxÿ\0\Ç?úõô?\ÆOƒv\Ö~;¼Ó¼º[\éöZ´ò,\æ»iþ\Ñ o-\î\ë\ÎQÁ1|™C€:ž’\Ï\á‰Ã6{¿[\Ýi’hú­\Å÷-§¼Aw\Å\Äv\áœBVC(#1‡o0ƒS\ÍN\ëkþ_š›iz~:*\Â;ÿ\0Oø\çÿ\0^øG\é\ãÿ\0ÿ\0\ë×²ÿ\0Â‰\Ô\"6¦\ã\Äz\r¬M£Å®\ÞK$—%tûYV#M¶K;Lˆ0íž .¹~\ê1®­sy\âOi\ÚFž,œ\ê\×\Î`ž;´v‚H‚B\Ò0>YJ\\ò +m%£þµ·\æM\î¯ýZ¯½w<cþ\ßúxÿ\0\Ç?úô\Â;ÿ\0Oø\çÿ\0^½\ëEý•üq­Ç®¼0\Â?²\ï&°ý\ÜW7s4h‚<0º\"•d\Ã\ÌÑ¡\Þ>n\è_³\í‡ö.³u¯ø\ËG°½‡Ã\ë\ÖÖ›·x’fƒ\ËiöÚ²\í\Û1R¨Å·?w&—»fþ…ÿ\0$5v\Ò]tümù³\ç\ïøG\é\ãÿ\0ÿ\0\ë\Ñÿ\0\ïý<\ãŸýzö\rüÔµŸ.‹qªX[[­6\ß\íÑ™n÷kB`rc-&o\Ýø«^ŸÁ¾2ø“\á\Ûø*\Þ\ÇK¸\×,\í>\Ø\×÷M{q™Q\Ö\à™<¼²’O•X8ÁÀÁ¥f¢·ð?Ì—+\'.‹þùÿ\0\ïý<\ãŸýz?\áÿ\0§üsÿ\0¯^Ñ­|»‡Z\Òb°\Öt›û-_R¸\Óa›NWB\Ú\â-¥ uŽ‘\Û&K\"¶r¬G5jÿ\0öqÖ´MG\\·Öµ\íB·\Ñ\Ú\ÄOy¨›¨Ñ¾\×<;còÀü„2´j\Êz€1´’k¯üóùô.IÅ´ú\Ã]ºžÿ\0\ïý<\ãŸýz?\áÿ\0§üsÿ\0¯^Û¥þ\Î\Ú\í\î½&}¬hzùÖŸ@µQ¸”}¶\é\n‡\ã”oC¹öƒ½B\äñE¿\ì\ß\âû¯\0\Üø±!F°‰\'™\"[{—2\Å†9J°˜S_$ˆ\ä.Bœ®M\ZºþºþZ‹[\Ûúþ´<Kþ\ßúxÿ\0\Ç?úô\Â;ÿ\0Oø\çÿ\0^½\ã^ø?g\àß†>-¼\Ô5\r/Tñ›ªiöOŸq3>œ\î·hdªŒ\ÙD“z\å\ë^AGº\ÛK§\ê“ýCSþ\ßúxÿ\0\Ç?úô\Â;ÿ\0Oø\çÿ\0^¶h§d#þ\ßúxÿ\0\Ç?úô\Â;ÿ\0Oø\çÿ\0^¶k_C\ÐÆ¾²Áo&5;’\'GNüö#Þº(aç‰¨©RW“\Ùwò^}—S›‰§…¦\ëVvŠ\Ýöó~]\ßM\Ù\Çÿ\0\Â;ÿ\0Oø\çÿ\0^øG\é\ãÿ\0ÿ\0\ë\×K«Z\Û\Ù^4ó4\ë\Úò2\í\Ç\ÞÀôÏ­v¿>KñV\rbKøo\Ã\ï¥Àn§‹]º–h@ù¤M±8`;Œ\ç‘\Ç5J~\Ên\Ý|\Í)TU ªGg®º~Œj:wö—û\Ï3~‡\Æ=ý\ênøª5†x\ãIRtVu\Æ+€G\Ì7\0p}À>Õ­ð\ç\àßŒ>-h\Â)¤jÿ\0gùiÿ\0I†/\ÌÝ³ýc®s±ºg§=«nq”W\Ðÿ\0?e;¿‡¿tÿ\0\é–÷\ÖV‰\Z&±¤j÷vó\Ü\Ø\ÊÏ±]%„–2\ÅW€eI°\çŠ@WQ\â¿Ÿ\ni:eûk\Ú>¨š’y¶ñiò\Èòù\Ø4k´ppw1ò¶9z\0(¯H\Ñþ\éž\'\Òb\×ôýBkM\Í?\âr.€y\íYFO—µ@?ð\àp~÷­p\Z“Y¶¡ptôž;\ç\É[—W/m\Å@ú\n\0<;ð·Å¿õ‹\ïøF</­xŽ+/\'\í‡G±’\å §nà£‚v>3Œ\í>•\êÿ\0´wì½«x?V†óÁŸ|ie\á»]\ÒûRºÔ­$ž(d6±\Í;4¡\0B…dSÂ´mŒ•|³\Âÿ\0/>\ë\Z‚\Ûiž\Ô#½ò¯¯h6º§”O1‰\ãmŸx\çn7as\Ðc\Öÿ\0iŠº>—ªE£x:†úÎ“¨hV«su¢xB\Æ7‚w´Eœ¬\Æ\Ý^9†GpcÊ•Už xŽŸÿ\0 ›ú\æ\ßú1\ëF\â\ÖiY!‘”Æ˜*¤º+;Oÿ\0Mýsoýõ¹qþ®\×þ¸­Xÿ\0b¸ÿ\0žÿ\0\ß±\\\Ï	\ïƒ]…Ç€n\í\á™MõŒšœ™´¤w7 ›?&\ÂBü\ÅC–<p@Ïºð\Üö\ZTw·—Ö2,–öŽå§™	ûÁTƒü\år9\\\Ò\Þ\ÖhÝ™\á‘TFù,¤ºju!ûŒxöRjôò\Óþ¹¿þ‚k6‡±Q|­6}-\á-?Vð§\Â[«û=#\Å2YÍ¤J&Ó¥ñ]©µ>}¼£\í?\Ù\â!.\Ì	%^s¶2\Ù*W\Í5\ï\Ú_Šl?\áWø‡Z·ñe\ÌWmi§\éW6§\Ãh\Û%7ñ$r›£…1,\È\Ò\ÏÏ¸(=<‰_/óýD¾ýv;*(¢¶39]?þ>Gûÿ\0 š±Uôÿ\0øù\î?þ‚j\ÅsÈ°®»Š\á\ê\0’\ÞE†\â9$Uƒ¤\ÈW\0ô;H8>\Ä\Z\íµ	t\ÛZOw¥¢M¥C\"²ƒn—\0*\ï\Z®\n\î9#iú•\Ä\Û\ÜKi<sÁ#\Ã4l$Š²°9ÐŠÒ›\Åúõ\Å\ÄË­\ê2\ÏnI†G»´dŒ¤ž28\âºiÔŒcg½\Óü\Z\î»þ\rz3©$ãµšß¿\Éö:½R\ÒXµ\í)4ÛCR³FŽŸN÷EŽHñØª\Ù\n¹6k–ñv¡k©k÷2\ÙEV«ˆ£òaX„@]\åT\0cq\0wªT½kÉ®\Ü\æ\ê`\ÂIü\Ö\Þ\á†sg\' s\×5Z•J¼\ê\Éi{ÿ\0_¨¨a))IÝ¥o\Çô\Ñ.ÁVôù\Øÿ\0\×tÿ\0Ð…T«z?ü…¬¿\ëº\èB¹eð³¹\ì}®\ÉBømÿ\0c§þJ\Æøwño<M\à\ä_‰\Þ<\Ôu‰õ==\'\ÒomvØ¹i\ãFgû{³ ðL?6\0*¹8\Íø\Õ{yag¢\ÝA#Z\\Áu\æ\Ã=¼¤::€C)\0A\0‚+\n\Ç\âGŒ&ø{­\êo\ã\ë}R\Â\Ú)µ\î~X\ä†ñq¿&(ù##oN|Ì¯ý\Ö??\ÌÆÀp\ZlsIg«4w\"Keic?ò\Ù|\è†Áÿ\0*\ßð\n¡V¬þ\Éö{\ï´\îó¼‘öm½<\Ï13ŸmžgãŠ«^©¸QE\\Žh¯#Y®E\ÓýšÝ„‹\ÙL(U?\à*Bÿ\0Àj…ZÔ¾\Éö„û\ï\'É‹vþ¾g–¾g\á¿v=±Uh\0­.\Þ\âka\áŸÊŽUy“þz§Ÿ…ÿ\0¾™[þY\Õj\Î;G·¾72´s$!­•G\'˜€ƒÁ\ãaö\ä{\n´QE\0QE\0QE\0h\éqÝ½Ž°m¥X\áKUk•a\Ë\Ç\ç\Ä\0w”=¸ž\Ç:­Y\Çhö÷\Æ\æVŽd„5²¨\á\äóx<l2Ü\ÏcV€\n(¢€4u\è\îâ¾ˆ^Ê³Mö[fVAÀŒÀ†1\Ðr¨>\àòz\ÖuZÔ£´Š\á”­4>LL\Ì\ã‘!Lƒ \à9`=€\äõª´\0W{\áOør\ã\Ãj\Þ!ÕšÁ.®¤µ‘\äV\ÅB[j[Ë¼üù\ØZ>^r¼ii\'\Ö<?É¥\ê\×\ÚjM5l\î^!&3ÁH\ÏS\×Öº(\Î\Ûsôþº¯Mü\Ì+Bu#h;^òò:M7Pº—\áoˆ\ìšòi\ìm\ï¬\Ì³·–›¼\ì•Rp¤\àg¾\Ònü\'\r\æ’\Ò^\ÞF±ù\Úõm\Ü.\Zˆ1\\°\ÖF¸\È‹g\ã/iúiÓ­u\ÝJ\ÛO!”\Ú\Ãw\"E†\Î\á°`\ä\çŽsQ]x£Z¿\Ò\â\Ónu{û:¾]œ·.Ð¦Ñ…\ÂÓŠ\ß\ÛSi)&ôK\îó\è¾Wô1öU›Ž—wü¿¯ó:Ÿˆ^ð×…ã¸´°Õž}f\Î\ç\ìòÛ±•¼À7r\Z\Þ1(y3»\ïq“ÁÖ–¡\â}gV±‚\ÆûV¾¼²ƒM½\Å\Ë\ÉxTœ8\íYµ\ÍZQœÜ¢¬¾\ïÕ›Q„©ÁFn\ïúòAEV&\áEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEP]¯üz\Ãþ\âÿ\0*\ç+£µÿ\0X\Ü_\åU4¤\×5	4x´§¼™´Ø¥3%©så«‘‚Àzÿ\0‰õ5—ü~Aÿ\0]ù\Ô4+`AÁ‚*ÀôŸøš\ë\Â:¤—öq\Ã$\ÏisfVu%vO\Â\ç‚9#\îA\é]‡¾;ø\Ã<\ÑüWeˆ¾\Ól-´Õ¶’&k{ˆ`‰#A*\ËÝ£d†P\Ãðß·\\\Ïy\ï³GÛ®?ç¼¿÷Ù­9¿¯¿ü\ß\ÞM¿¯»ü‘\îÿ\0uht˜m›J\Òf\Ôma¹¶±Ö¤Ž_µ\ÙC;;IxFFe—\èÌ¾a\Ú\Ãˆ\ï>3jwš|–\çJ\Ò\âžm\n/\Ü^F³y³\Û\ÄÐ˜Ù” u\è¹U\0‚\Ù\àûu\Çü÷—þû4}º\ãþ{\Ëÿ\0}šI¥·õ¿ù¿¼­o~¿ð\ÏôG\Ñú\Æ)­o> x\ÎóQ±‡_ñRAmo.VyX]+2”EŒo\Ûû\Âû°1‚My¾¹\â\ë\Í{Cðö•q	o¡\ÛIklÑ«uy¤˜—$N\éÀZó·\\\Ïy\ï³GÛ®?ç¼¿÷Ù©\ÑY%µ¿ÿ\0›\íV\ß5XõWºº\Ót½F\Òm\Z\ßBº\ÓnRQosm\nF±\ï\Ù\"¸pa÷#¯Ì½\"º\'\ãUŒ¾ñx\Öt}Q»½º\ÒR\ÃA¸†\åm#¶¶Ž\áv£G\"ºˆ\ÃG÷¤\ÜÛŽw\å«\æÏ·\\\Ïy\ï³GÛ®?ç¼¿÷Ù«r¿õ\ç\Ïóakiýt_¢û‘\î7_5n\×S·ñ&‡£x¦+\ÍF]Q¢·›I\åP²Z	¢!HX\Æ\Æ,£\Ë\\\ÎaµøÉ©Ç©\\\Ü\ÝiZ^¡\rÖ…‡§³¸Y–)-¡X‚11Ê®0FÄ†\0xÁ\Åx§Û®?ç¼¿÷Ù£\í\×ó\Þ_û\ì\Ô\ék[úµ¿-­\ïýo\ÏS\ß|sñ\"K_ø#Ãº.·¢þStÚµ”RD\à\ÈZ ¾b#‘\naC2ŽYÀ\È\0šr|g—þ;\Ä\ÞðÝ†½k£.¡kÂµÔ±8ž31Š0\Ìa\nG\ÜExwÛ®?ç¼¿÷Ù£\í\×ó\Þ_û\ì\Ó\æ×›­\ïý~r¹<ºrôµ¿¯\Ç\ïv=·\Ã\Zµ\rZ\ÇiŸ¦\ÞY‹«û©`¹Iq7\Û X&™$V±F6•`Iù»T~(øÅªx£MÔ´÷\Ót½>\Êøi\êa²Ž@![8\Þ8U7H\Çd;·dœ‘\Î|[\í\×ó\Þ_û\ì\Ñö\ëù\ï/ýöhºV·K~}\Åk¯\ÏñÕŸ[|7ø\Ýc\âwñ7n¼/v\Ú\ë\ëñ\Ø\Ëc-ôSB\â\Ï\ËHc@¸…*>a¨|V—Xðô:V¥\áý#S–\Ï\Ï]?TŸ\í1\Ý\Ù$’4»P\Å2#…wv_1n+\Æ>\Ýqÿ\0=\åÿ\0¾\Ín¸ÿ\0žòÿ\0\ßf–Š\Ö\éÿ\0\r÷‰h­ýuÿ\06{‹þ6j0\Ðum2]C\Ó[X¼‡P\Ôol ™\'»¸Œ86\éYWw˜Äª*®N@9óª\äþ\Ýqÿ\0=\åÿ\0¾\Ín¸ÿ\0žòÿ\0\ßf…e²þ¶¬¢¹?·\\\Ïy\ï³GÛ®?ç¼¿÷Ù§\Ì:Ê»k«\\YY\ËoD¬\äA‡ t]Þ™\ç\Ã}º\ãþ{\Ëÿ\0}š>\Ýqÿ\0=\åÿ\0¾\ÍkN´\é>h;?ó2©F—-Eu¾¾[¶¥©Kª\\	\ç	\çm\nÌ«‚\äõ\'Öª\×\'ö\ëù\ï/ýöhûu\Çü÷—þû4ªU•I9\ÍÝ±Ó¥\ZPT\é«%²4üEÿ\0.ÿ\0ð/\éX\Ôù&’ly’3\ã¦\âN)•‹5;¯|b\Ö|} \è~{k\Ãz4{m4m\"7Ž\Ø?9™Ã»³\Èw™˜õc\ÕÜ·E€(¢Š\0\ëcø­YË¦}€Á¦Zi\èR;T\"	20\æEb|\Â\ã†\ÜO§\Í\êW‹¨_\Ïr–°Y,®\\[\ÛÇž\Ê’\ãU¨ ’\Ò\Ú\ÖcRv/ðJ³6ŸöW	5·”\åUÂ¼x%YC)\ç±{‚\rhø\'TÓ´[\ë+\ÝOJþÙ·…–Ñ¦òÑŸþVÜ£û½ø\Ï³ø•ñKNøk“ÃŸaÔ¡ÀŠù/7™\ÉF_,n^¤r0yH =®([¨Â€—\Ð}MY’C\Ø\ÜrV$#ðªú\ïü}Gÿ\0\\\Çó5Ö©MR#Hd6?„Oz¤í¨C¸\Ö4XüA©x¢=Me–\î9\Þ=/ÉÎ“JŒ¤;òö)f9Ixœ[¼ñ¥¥\æ‡\'Ÿ¬y\Öo¥\Ãf¾ò¤ù.Q<\ÎW\ËsvðÛ°Bâ¼¯û^\Óþy¿ý÷ÿ\0\Ø\Ñý¯iÿ\0<\ßþûÿ\0\ìjtZ/\ëú¸ú\ßú\éþG¨x\ßÅ–z¶›ªE±ý©os0—O±ò¤_\ìÈ‚>S\æP«ÁU\Û*v\äž|¢­\Û\êV÷ñ¢0c\ã-Ÿ\á>\ÕQF{\ã\ëI+‘õ]µ¯‰/~‹=~)Kk‰‹«{­K\ìºz\Å\å\æD­m¶[m¸;VMûN1š¾T¯ ¬n|qð\Ö\Ü\ê:†SZm.x\î\"¶›S\Ò\Ø}“\ËP¢1—\å—9BA\É5ó\í9Oú\êþNÊŠ‡\í\Öÿ\0ó\Þ/û\ìQZ’szü|÷ÿ\0A5b«\éÿ\0ñò?\ÜýÕŠ\ÂEpõ\ÜWP–ò,7\Èñ$\ê¬\Å&B¸¡\ÚAÁö \×m¨K¦\Ûøª\Ò{¸­-m*ý”t¸xWx\ÕpWq\ÉO\Ðô®&\Þ\â[I\ãž	£`\é$lU•\È Ž„V”\Þ/×®. ž]oQ–{rL2=Ü…£$`•$ñ‘\Ç\ÓN¤c=\îŸ\à\×u\ßð8kÑI\'¬\ÖýþO±\ÜÉ¦\ØZÝBAf\äh\Â\æ\æ\â1£™ö$‘\Û:%—h\Ãmÿ\0)®CÇ–\Ëk\âIBC1\É2\'\Ù\Ô*º´JC\í\0-\Å@\0EfÁ¯jvº„—ð\ê7Q_I÷Q\Î\Ë+g®Xœ\Õ[«©¯n$ž\âi\'žF\Üò\ÊÅ™‰\îIäšªÕ£R6J\Úÿ\0Ÿùþt¶8|-J59\å+«[òü­\éäµ¼uoGÿ\0½ýwOýUJ·£ÿ\0\ÈZ\Ëþ»§þ„+Š_=7±\ë\ß¿\ä¥\×vÿ\0\Ðkƒ\Ó\ä“øþ\Ãz_þˆ\Ô+¸ø\ì\Ò\'KÞŠ¿¿lmb‡\è+‡\Ó\ä“øþ\Ãz_þˆ\Ô+\Ì\Êÿ\0\Ýcóü\ÌhüŸq,6zšGmç¬¶\á$“i>Jù±¶ÿ\0nT.\Û\Çz£Z:\\woc¬iV8R\ÕZ\åXrñùñ\0\ån\ç±Î¯T\Ü(¢Š\0½¬I\æ\Ý\Æ\ßbûú<\åm\Æ\ìDƒ\Ì\è>þ7ÿ\0ÀúžµF´u\è\îâ¾ˆ^Ê³Mö[fVAÀŒÀ†1\Ðr¨>\àòz\Öu\0{O“Ë´\Ô\×\ì_j\ßn\ÍÛŸ³~ö3\æt8\Î6vÿ\0Y×±£Z:\\woc¬iV8R\ÕZ\åXrñùñ\0\ån\ç±\0Î¢Š(\0¢Š(\0¢Š(öŸ\'—i©¯Ø¾Õ¾\Ü/›·?fý\ìg\Ì\èqœl\íþ³¯cF´t¸\î\Þ\ÇX6Ò¬p¥ªµÊ°\å\ãó\â\0;\Ê\Ü\Ïc@Q@µ‰<Û¸\Û\ì_`ÿ\0G|­¸Ýˆy\ß\Æÿ\0øSÖ¨ÖŽ½\ÜW\Ñ\ÙVi¾\Ël\Ê\È8˜\Æ:B\ÜOZÎ ½g\á=ý\ç…~|Dñ~ð\ëKeŠ¶Ÿ+\Ãya\Ý@ZrøP#|¿v\Ìùl2„%«É«²ø{\ã|7§ø£O¿\Ò.u}X°[kÄ³¹\ÓBx¤ŽE\Ç\"¨\"!±Á ƒ£þ¿«\ìSó_žÿ\0-\Î6Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( º;_øõ‡ý\ÅþU\ÎWac¥\Íq£\Ù\ÍS;ù í€˜ö\Ç\Z;py*¤³\r«´\ä\î\â¢z(¢¬eýžþh:‡^Ÿ\ÄÛ£·‘c\Ò4©<\Æ@5+\ÞSpF\à	 \är2\rpøm\â/\\\Ý\Ûi–quk#Bö\Íss4€Q\Ø4òŸ•5\Óøg\ã\æ½\àO\éžð\Ìvú\\^M}wy5´Mu+m²\Ä|½Š¸$\Ä\ät®£Aý¥¬4\ê>!ƒ\Â\r\Ýæ°º»-¦¤!\ÞJ(’\È,Ñ—\Þê ®œ\ïP^¥ð_\Ãö>(·\Õ\í®ôú[t\Ýms©}´½\Å\Ó\á`³Q\ÌJ7•r©#\r×€<¶½7\á¯\Äh¼\á\Ù,\ãñgˆ<+t\×\â\í\ÛAÓ–cpªŠdswTÿ\0&\Â9\É\' +ª\Ñü\"š\Ô	¾ƒá†Ž\Ú\'ˆZ(\çÕ£ƒW{k{\é-3‹\í¤üˆ\Ø%s\æ(ô\'\Â+\è;?\Ó\Ö¶ž\æ¸\n¬wKáƒ½a]KûDBû[fÁ8\Æv\î\Û\Æ\îõó\å\0O§\Û\Åu¨[Aqr¶pI*¤—.¥–%$\ä’\0\çž+\ßþ-~\Î\Úo‚>\èz\êjº}¬\ÑZ¸¹–%»‘µ\ÚBð¬˜€˜\n6\Þ}~õ`|3ý£?\á]|ñ_€¿\áþ\Ðþ\Ýû_üL>\Û\åy}ºCþ¯\Ë;¶\í\Ý÷†sŽ:×“\Ýx‡U¾†\â+Jò\â+‡I&IgvYYj3y*¼z (Wc}¦øm|­oaª¥\å\ÅÌ¶j²j1<jÈ‘¶ò\0wýÜŽkŽ­vñÿ\0„f\ÏIXvµ½ì—‚}\Ù\Îôv\í\Ço/9\Ïz®–\×ôƒªþº™no‡\ÚôGY\Æeq!1¥\ÔNñ”Œ\È\Ë\"‡&6\n	\Úø<ŒŠ¯}\à\ÍcOXLö€4Ò¤4š7u‘\ÆUU‰F#øXÁô®\Ê\ë\ãU\ÍÆ½o¬ˆõCy•þ\Ïqª™­#‘\áx÷EGû¼\Üf\ã\å÷¨4[Àº\æ¸m­­„Ñ«‹Y.–FmD6Rh¢\á•F÷nr#w T\ë¿õý~¶\ß\×õÿ\0r²x/XŽòch¦i£žX\Â\ÍXK‰!±ÁûóŽ3‘P§…uI4ñz¶¹µ6\Íx\Ì_õK/”[\Ï\ß\ã{\ã\×M üBÒ´\Û=!o4[Ë»½:\Ö\â\Íe‡QH‘\Òc&\âT\Â\Ç Jqóvv­+‰z>‹¢Y+LŸ\íqZ\\i\Ëo{v%ò”\ÍñNYb@\Ä>ñ·ý‘Ÿw·õ\ëÿ\0ñ¦\ÃÛ«=F{]z\Êú\×i·ˆ&iY¾hŒº\îÜªÃ†N3\èsn<!}7‹\ï4KVŽ\î)eQ\Í\Ä@¢ f;\ä\ÈNI\'8\â·_\â´\ß\ÙúŒ)a‹»»k;u»y\Ë4Fš&qÀ\Ë:»u?.{œ\Z\ÍonñÆ£\â/±c\íŸiÿ\0Fó~\ç›§\Þ\Û\Î7\ç§8\íI\Þÿ\0ü\0\é÷ÿ\0Â·\×\Ú\ábŽ\Ú\Þm\Ö\ÆðK\rõ¼‘y!ü¶s\"¹Ppy\ãž5õÇ¾ºµ6\Ð\Âö\ËI,÷p\Å\0Ç‰Y\Â6\á\È\Ã€q\Ð\×C\áo\éò\èw–Z•¾ ³\Ñ%´·B\'¹f¼Ip„©\Ã\0ÇŒ7\Ý\'ªŒ\Þ>±¿Ž\î\ÆûGšM\ZE¶[\Û\Þ\æ‹\ÈFD&C\Èw\Ýò“‘·§\Ö\ß\Ö\ïôFÿ\0®†L\×.>\×þ„!kYZŽ\âx\áv‘FY]‘€\ÇÊ€žG¨Ê§€õ¦$’{h¤X™%»¼†o1¦\ÜvHŒŒ\ã\"º+‹\×Mempº•ª\Ü]\Év¢\êmfWz…1¾QÄŠ®3‚9\ä\æ²üI\ã\ÔñFaew§úu¼0YL“€c\nŠ²n>p\ÛwÁRz‘\Å\Ï\Ëþõùþü\Ä>¾ð¶ \Ö:Š\ÃÒž8nbŸa\Éc0S\ÇC\ÍfV§Šµ\ÏøI¼G¨\ê¾GÙ¾\Ù;M\ä\ïß³\'8\Î*Ë¤¯m@(¢Š`QE\0QE\0tš\×Ã­\Ãú\r®µkZe\Ö\ß\"u¼‚O7##j«’}ø\ã½su,—S\Í0I49ò\ãf%S\'\'h\í“\éQPEP]geqý—Ç‘/\Ùö/\ïvžzuâ’º\Û?ù%°¸¿ú6¹*\ä\Ã\×u¹\î­\Ë&¾\â#.k˜z\ïü}Gÿ\0\\\Çó5‰«\Ç\áÿ\0®qÿ\0\è[z\ïü}Gÿ\0\\\Çó5‰«\Ç\áÿ\0®qÿ\0\è]l²\ï…\ä!\'ýr?\ÌWs§h:Ž¯kseg5Í½Œ^uÌ‘®DIœdþ§\èôŽÂ¿ò“þ¹\æ+Û¼+ñ¿Wðn‹™¦iZDVñò\Ì\Ð\Ê^W=]Ï™\Ë~€\0 <\Ú\ëþ=gÿ\0®mürõ\Ùø‡P]R\âþ\íl\í\ì\Ê\Ïö{Ee‰9\Ú	8\çÀ\Ï\ÆU\0QE€(¢Š\0±§ÿ\0\Ç\Èÿ\0qÿ\0ôV*¾Ÿÿ\0#ý\Çÿ\0\ÐMX©põ\ÜWP–ò,7\Èñ$\ê¬\Å&B¸¡\ÚAÁö \×m¨K¦\Ûøª\Ò{¸­-m*ý”t¸xWx\ÕpWq\ÉO\Ðô®&\Þ\â[I\ãž	£`\é$lU•\È Ž„V”\Þ/×®. ž]oQ–{rL2=Ü…£$`•$ñ‘\Ç\ÓN¤c=\îŸ\à\×u\ßð8kÑI\'¬\ÖýþO±\Ùj\é:mÕ¼²\\i°\êwzbJ·Ri\ä\Ú	<\â7yYÛº%ý\ß9Ý…-š\æ<}cm§x¢\âeT_.‘6*\ÈÑ«8ü?1?/ðô\íY¶þ \Õ,õ	o Ô¯!½—>e\Ìsº\Èù99`rr@ª,\ÅØ³\ÌNI<“UV´jF\É[[þ\ç\å²3\Ã\ágF§<¥}-ùyh•´^}«z?ü…\ì\ëº\èBªU½þB\Ö_õ\Ý?ô!\\RøYè½^øõÿ\0 +þ»·þƒ\\›ÿ\0$Ÿ\Äö\Òÿ\0ôF¡]\Ç\Çf\é:^ôUýûckü?A\\>›ÿ\0$Ÿ\Äö\Òÿ\0ôF¡^fWþ\ëŸ\æcG\à9\Ë8\í\Þø\Ü\Ê\ÑÌ†¶U<žb†CÛ9\ìj\Õ\í>O.\ÓS_±}«}¸_7n~\Íû\ØÏ™\Ð\ã8\Ù\Ûýg^Æz¦\áEP­J;H®YJ\ÓC\ä\Ä\Ì\Î9\Ô\È:–\ØOZ«Wµ‰<Û¸\Û\ì_`ÿ\0G|­¸Ýˆy\ß\Æÿ\0øSÖ¨\ÐV¬\ã´{{\ãs+G2B\Z\ÙTpòyˆ<6n@ç±«W´ù<»MM~\Åö­ö\á|Ý¹û7\ïc>gCŒ\ãgoõ{\n4QE\0QE\0QE\0Z³Ž\Ñ\í\ïÌ­\ÉkeQ\Ã\É\æ  ðx\Ød=¹žÆ­^\Ó\äò\í55ûÚ·Û…óv\ç\ìß½Œù3¿\Öu\ìh\ÐEP­J;H®YJ\ÓC\ä\Ä\Ì\Î9\Ô\È:–\ØOZ«Wµ‰<Û¸\Û\ì_`ÿ\0G|­¸Ýˆy\ß\Æÿ\0øSÖ¨\ÐZ:\\woc¬iV8R\ÕZ\åXrñùñ\0\ån\ç±Î©\íþ\Í\ä\Ýyþo›å³ùxÛ¿z\ç~‡fþœ\çol\ÐQE\0vŸ|7¥x\Ç\â×„´Mm\Â\éWÚ”0\\)ržb–»\Ü+¸\ár³]»\ÝüUñ\Íß‡õ½+OÐ“Oµ\Õn#²\Ñ4[]>he·´šT…\Ù\"HBªD…›¹\ÜI¯(\Î9\Z\ë5/‹¾:\Ö/t\ë\Ëÿ\0\ZøŠú\ïMs-\ÅÎ«<’Z¹\0‰‹’„€9\\t¦õVõüv/\êÀ´mÿ\0]?Ó©\è\ZoÁ¿X\éú.¡¯\rm`¸ðl\Þ&¸¶·’8d’E¼x£H\Ù\ã!cx\Õ\âÛ†\á…9ZO‡~jZOŠüH,üP\Ú>”––ud¸3L]eV¸òJ›•„@‘ò•\Ü8][Ç¾&×®\æº\ÔüE«j7S@Ö²Mw},®ð³—hÙ™‰(X–*x$\ç­eC©]\Û\Ù\Ü\Ù\Åu4V—%ö\é!\ÊT’¥”6	8\ÏLš—w+­üú4¾@¬•¿­—\ê›ùž\å\á_…¿u\Ë\â}oÄš†‹\áýCX¸Ó´æ¼–E¸µŠ4‰\ËJ¶öW4˜›\î·\ÈL†ù\Î\Êú\Âoj^\Z\ÒayõÙ¼AªxwV\×\"½Šxc³‹\ìv#w-·#z”\'9l\á|³\Âÿ\0¼S\àx\î£ð\ç‰u;¬}¡t»ùm„\Ø\Î7„a»=}MR‡\Ä\ÚÅ¿‘\åj·\ÑyòZE²\åÇ—›üÈ—„o2M\Ê8;\Û=M9jš]¿F¿;?\Ìq\Ò\×\ïúÿ\0–‡¬|B‡Àvÿ\0~\\\éþ\Ô\íuk\ëK /¿µ *dK¶V3ª\Ú+M\Ç\ÝÔª•ld÷?4¿\rk^.\Õ|e‡µ\\ø®;-Oð¾ŒºTº}¸•\ÒH..>\Í»6\è\ÔN£6\ì}\ï\ìüs\âM;\Ãw>´ñ©k ]?™>•\r\ì‰k+qó<A¶±ùW’?„zUµ½F\ãXmZ[û©5VŸ\í-|ó1œË»w˜_;·n\çvsžj›M«\í{þ)þ–\'^]7ÿ\0oS\è\ÏøT¿|\'\ã?…Ú¼\ë_\Ðu½v]2{3¨bóaš\ÝwgÓ ó#Ì¥^?(ƒ´\'\'o+\á{\nXþ\Ó\Z,\Z>‘¯\èi¸¶±˜õkg–\Þ\ë\íARd\Ýe°\"\Ï&F\Î1¾¼»Äž>ñ?Œ¦†]\Äz¶¹,.^\'Ô¯¥¸hØ…”»FG÷G ­ø\É\ã\ç\Ö\ã\Ö[\Ç$mb8\rªjV¸ûB\ÂN\ã“~\à„ó·8\Í|²„ŸÙ¿\ãoò~—òA4¥Euÿ\07ú5\ëo6wþøg\á}zø‡\ÆZÜ–\Ún“«¥ˆÿ\0H’Ù¤’gœùŽð\Ù]mÿ\0RF<•V,~e\Ú´üðƒá¶·¨höªkú\Ô:ÿ\0Š\î¼=¦j6EiÛ¢[¹xå…›7\ÇònÄ˜\ÃyT?<uo\â	õ\è¼i\âõ\É\áò\êiª\Î.dˆ`„iw\î*08\'\n\Ëÿ\0„\Ë\ÄnŠ÷ûsRûd7¨Gqö¹<Äº}¥\ç\rœ‰be\Ç\ÌvŒžeò¥\Êß—\çg\é{tL¹¾f\äº\Ýþ\ßs·­¾G©µ¯-g{[»Ÿ\ê—\Z\Ò\ë\×6O¨\Û\êD\Þh¶”¶m¼ž\â\Ù\Ès¿ž<¯Hðü\×iw7ð\ÜY\è—w‹jÚ‹DD]W\Ì\n\äm,ª\Ù#·&‡\ã¯x^\ÏP´Ñ¼Cª\é6ºŠì½‚\ÆöXR\épF$U`a˜a³÷­gË¬_Ï¥Á¦\É}s&,Vm+cvûÌ©œp2@\ç¤]ª9½vüO\ï³ûü‰•œyc¦ÿ\0‹m}ß§™õˆ>\Z\Úøû\Ä:\ï„mOð}¶\â«-t\Õð½š\Ë´²¼PL5\r\ßi™\Ùc\Þ\Êü9q‚A\0r|-øU¨x\ÃN\Óô\Ï\êW\Ç©6«cg,³\Ï\Ú\ÚI::\Ëqch73F\Êc\Ø\Ø\Û÷\Æ\î<—Qø‘\â\ícA´\Ñ/üS­_h¶{>Í¦\ÜjIoÁ„\Ùm«´p08*]sâŒüMqo>±\â\íwUž\Þ9a†K\íJiš(\å]’¢–c…uùXpr*Rj6¾½þI_\ï»\ë¹WWm­;v\ßþ\Ý\êz|Ÿ|\Z\Út~*Š-|øi|.5\éta}\ßMûY\Å\Ï\Ù\Â…\Ì$ò\ãÃ¹øð¿\ÂzÏ‹üE¯x²\î\ë@\Ò4};\Ã\Ö	asw,3\Ä\Ói¨G,V*!\Û\Ì‰ù”®\Öù·Gñï‰¼?yew¥ø‹V\Ón\ì`k[Y\ìï¥ŠKxY™š8\ÙXB\ÌÄ¨À%‰\ïS\éŸ<a¢\ëSjúŠõ»\rZhV\Þ[û]Fh\çx”(X\ÚE`\Å@UIÀ\Ú=*î¯§Ÿ\æÿ\0Go-\ÉZjû[ÿ\0IýS~w;\åðo\Ã-C\Ô5\Ëû¯xŸF\"“I²¸\Ò\'Š\Ä\Éj±¤‚r³@\ç~\î»³\Õ1ÏÜˆ–\âQn\Îðo>[H¡X®x$@8\í“Võêº²Î—Ú•\å\â\Ïr×’­\Ä\ï ’v\á¥lž\\÷c\ÉõªšNÿ\0w\ä¿[¿˜ú]\ß\éeò=Pøg¢\Ùø,\ë1ø—Î½û2Oö3Lû\Ä®Pi¸\Ïüñ\Ý\Ç*9ÇŸ\Ú]=•\Ô7ñ$.²/\ÔŠŠŠ¿µtM½\Û3Ó£ñM\Ï\Æ\ïYiž \Ûh¬\×\ÒÁsd\n¥´³;N\ÒJvaS\ØÁT²H9³\ã½*>0ž\ÓBžMB[‹k\Ûgº¸;¡0Jdƒb\áT™\ÜÇümù2\Þag¨\Ý\éþ\Ùn¦¶ó\â0\Ë\ä\ÈSÌŒ\ã(\Ø<©À\àñ\ÅM¨ëº–°¡oõ«\ÕY`·´€H\ä~O\ÞbOSš\æöViCH\ëu\Þ\ço\Ö9“”õîŸ¥Ž\ÓCº\â\×\Ä}Fû\ÄZf·©\Éym<\ím\áKq-ÇšŸ-¶¾\ïÝ‚ª\\õ\n×ž\×Uð\ï\â6£ð\ÇU¹\Õt{{o\íw·’\Þ\Þþc)’\Ïz”wU\Â3b?x®¼\ç\æ¹Z\Þ\Ê6Q\Ù/\Õþ–9œ®\å»\äQE1Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@wšNš\ÇK´&\Ö\ÒRcf\ß#\È\ïŒ\Îü\Ã©;·\n\à\ê\Òj—±¢¢^\\*¨ÀU•€Ó­T]·µ¸\Ñfš@È–ð\0Š»cg  ù²r\Ä=²N\0?øG\î?¿\æÂ¸ÿ\0\í‹ÿ\0ùý¸ÿ\0¿­þ4l_ÿ\0\Ï\í\Çýýoñª\æB;øG\î?¿\æÂøG\î?¿\æÂ¸ÿ\0\í‹ÿ\0ùý¸ÿ\0¿­þ4l_ÿ\0\Ï\í\Çýýoñ£™\Ø\Â?qýø¿3þ\Â?qýø¿3þ\Çÿ\0l_ÿ\0\Ï\í\Çýýoñ£ûbÿ\0þn?\ï\ë\È\Ãþû\ï\ÅùŸð£þû\ï\ÅùŸð®?ûbÿ\0þn?\ï\ë\Ûÿ\0óûqÿ\0[üh\æ@vð\Ü~/\Ìÿ\0…ð\Ü~/\Ìÿ\0…qÿ\0\Ûÿ\0óûqÿ\0[ühþØ¿ÿ\0ŸÛûú\ß\ãG2°ÿ\0„~\ãûñ~gü(ÿ\0„~\ãûñ~gü+þØ¿ÿ\0ŸÛûú\ß\ãGö\Åÿ\0üþ\Ü\ß\Öÿ\0\Z9‡ü#÷ß‹ó?\áGü#÷ß‹ó?\á\\ö\Åÿ\0üþ\Ü\ß\Öÿ\0\Z?¶/ÿ\0\çö\ãþþ·ø\ÑÌ€\ì?\á¸þü_™ÿ\0\n?\á¸þü_™ÿ\0\n\ãÿ\0¶/ÿ\0\çö\ãþþ·ø\Ñý±ÿ\0?·÷õ¿ÆŽdaÿ\0ý\Ç÷\âü\ÏøQÿ\0ý\Ç÷\âü\ÏøWý±ÿ\0?·÷õ¿Æ\í‹ÿ\0ùý¸ÿ\0¿­þ4s ;øG\î?¿\æÂøG\î?¿\æÂ¸ÿ\0\í‹ÿ\0ùý¸ÿ\0¿­þ4l_ÿ\0\Ï\í\Çýýoñ£™\Ø\Â?qýø¿3þ\Â?qýø¿3þ\Çÿ\0l_ÿ\0\Ï\í\Çýýoñ£ûbÿ\0þn?\ï\ë\È\Ãþû\ï\ÅùŸð£þû\ï\ÅùŸð®?ûbÿ\0þn?\ï\ë\Ûÿ\0óûqÿ\0[üh\æ@vð\Ü~/\Ìÿ\0…ð\Ü~/\Ìÿ\0…qÿ\0\Ûÿ\0óûqÿ\0[ühþØ¿ÿ\0ŸÛûú\ß\ãG2°ÿ\0„~\ãûñ~gü(ÿ\0„~\ãûñ~gü+þØ¿ÿ\0ŸÛûú\ß\ãGö\Åÿ\0üþ\Ü\ß\Öÿ\0\Z9‡ü#÷ß‹ó?\áGü#÷ß‹ó?\á\\ö\Åÿ\0üþ\Ü\ß\Öÿ\0\Z?¶/ÿ\0\çö\ãþþ·ø\ÑÌ€\ì?\á¸þü_™ÿ\0\n?\á¸þü_™ÿ\0\n\ãÿ\0¶/ÿ\0\çö\ãþþ·ø\Ñý±ÿ\0?·÷õ¿ÆŽdaÿ\0ý\Ç÷\âü\ÏøQÿ\0ý\Ç÷\âü\ÏøWý±ÿ\0?·÷õ¿Æ\í‹ÿ\0ùý¸ÿ\0¿­þ4s =\ê\Þ3\Ã8\ã<²¨^?\ë­r¥z‚>µ\Õi23|)³‘Ø³‘™‰\É\'\Í\×3<¢M¸\Ïµóø:µ£ˆ8\Âðs•\ßcl=:R¡Rr•¤ž‹¹\Ïk¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -m\ë¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -}2.øWþB\×#ü\ÅuU\ÊøWþB\×#ü\ÅuT]Ç¬ÿ\0õÍ¿‘®^º‹¯øõŸþ¹·ò5\Ë\Õ\0QE€(¢Š\0±§ÿ\0\Ç\Èÿ\0qÿ\0ôV*¾Ÿÿ\0#ý\Çÿ\0\ÐMX©põ\ÜWP\Öe…\ä`-½qD‡?t€rsÓŽkÑ­l\íou›;;\Ë}4k¶vwS\\*Áv\â@7F’\"(VhÀf`\è\ä‚+\Íí®¦³¸Ž{yd‚x\Ø2Ie#¡t5¡u\â­núkynu‹û‰m\Û|/-Ó³DÞªI\àð9\×F¬i­¯ø?\×S\Ï\Åa\çY®Wm½\á»üŸC\Ñ[J\Ò$ƒûZiÀÓ„­5Õ”k\Ñpckl\Þ@Ú«Žr	Á\ÉW\ÄK;_f\Ê&·ŠkhghYgŒ1ÊŽ9Ý´p7`p+/þ-WûOûKûNóûGû_žþn1Œo\ÎzqÖ©\Ü\\Kyq$ó\Êó\Í#y$b\Ì\Ìz’OSUZ¼jAF1¶¿\çù\ßðë¥±\Â\à\êQ©\Ï)\Ý[ü´ôV\Ó\×Dµ¼uoGÿ\0½ýwOýUJ\Õð‹jž)\Ñ\ìÑ‚=\Å\ì0†n€³ŸÖ¼ùü,õTøõÿ\0 +þ»·þƒ\\›ÿ\0$Ÿ\Äö\Òÿ\0ôF¡_Fþ\Û\0µOƒ\Þð\Ýæ¡©\Ù\ß%\åì¢\Û+‚¤&rw^\á4›†^&]föö\Â\×ûcL+%š\\¹&ÿ\0\0«K\çq\è8\ç#\È\É\êF¦2ƒº\×ó3§	B<²\Üä´¸\î\Þ\ÇX6Ò¬p¥ªµÊ°\å\ãó\â\0;\Ê\Ü\ÏcV¬\ã´{{\ãs+G2B\Z\ÙTpòyˆ<6n@ç±«^Ñ QE£¯GwôBöUšo²\Û2²f1Žƒ…A÷“Ö³ªÖ¥¤W,¥i¡òbfg‰jd\Ë\ì\'­U ´t¸\î\Þ\ÇX6Ò¬p¥ªµÊ°\å\ãó\â\0;\Ê\Ü\ÏcV¬\ã´{{\ãs+G2B\Z\ÙTpòyˆ<6n@\ç±\0«EPEPEPŽ—\Û\Ø\ë\ÚUŽµV¹V¼~|@Á\çyCÛ€y\ìsªÕœvo|neh\æHC[*ŽO1ƒ\Æ\Ã!\í\Èö5h\0¢Š(G^Ž\î+\è…\ì«4\ße¶ed\Ìc!\nƒ\î\'­gU­J;H®YJ\ÓC\ä\Ä\Ì\Î9\Ô\È:–\ØOZ«@zŸÁ;\ë­CMñ·†n5	-¼?¢\Ë=ÈÙ¬í¥ŽHš;©cbP€7F\'Ï€¤+\Ë+¬ð—Œ\ì¼+\á\ÏZ¦—5Î±¬Yÿ\0g\Ç|\×a`·¤\äýÏ——s\å\à7˜\0~Rp@þ.\éþZ~?\Õ\Ã\íEù¯\ÏS•‘Dr:«¬Š¤€\ëœ7¸\ÈQM¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0÷\Ý\'þI%—ýqOý+—®£Iÿ\0’Ieÿ\0\\Sÿ\0F\n\å\ë\Ï\Ëÿ\0\å÷ø\åú\Óû^¦»ÿ\0Qÿ\0\×1ü\Íbj\ßñø\ëœú\ÖÞ»ÿ\0Qÿ\0\×1ü\Íbj\ßñø\ëœú×ªÍ‹¾ÿ\0„Ÿõ\Èÿ\01]Ur¾ÿ\0„Ÿõ\Èÿ\01]U$W_ñ\ë?ýso\äk—®¢\ëþ=gÿ\0®mürõ@QE \n(¢€,iÿ\0ñò?\ÜýÕŠ¯§ÿ\0\Ç\Èÿ\0qÿ\0ôV*d\\=w\Ã\Ô5™ayX\Ëo\\BÀ‘!\Ï\Ý œô\ãšôk[;[\Ýf\Î\Îò\ßM\Zí\Ô\×\n°G¸\rÑ¤ˆŠš0˜\0z9 Šó{k©¬\î#ž\ÞY ž6’F\ÅYH\èA\rh]x«[¾š\Þ[bþ\â[v\ß\Ët\ì\Ñ7ª’x<EuÑ«\Zk_\ëþõ\ÔóñXy\Ök•\ÛG¯_ønÿ\0\'\Ð\í\äL\Å~š;[¯\í‘\Íö‹4$yO9a\"\îPT\ãw#\Îõ	rª¨•€\0`M\\\Å\Z\Ì:„—\é«_%ô‹±\î–\åÄ¬¼p[9#Ç°¥·Vñ§ˆ,\í\î5]^þh\í`\Èd’Y„E\É=\É\0TÖ©\Z‰Y[Wø\Ûü¿a°õ(\Ë\ÞwV\ï\æ\ßmµ·\Ëc.º‡òP<1ÿ\0aK_ý\Zµô\í¯üé¿³\Ó\í¾>ŠO\Ë;\á·\ÒL\Ö\ë&>\è”Ì¬W=[\Ëú\ß\ç\ë?\ê¿þ6i~\ÖaXu;\rb\Õ$Um\ÈÀÈŒŽ§º²²°>Œ+\ç0Ù¶2Uaƒ¬¦á½ž\ß\×}j¦µ:‘j\çÝ¿ðU¿ù\'þÿ\0°¤ÿ\0ú(WÀZoü’ÿ\0\ØoKÿ\0\Ñ\Z…}\éÿ\0P’ñþø\íPCþÔ›o“1“?º\ï”\\WÁzoü’ÿ\0\ØoKÿ\0\Ñ\Z…pðÖ™l=_\æ\Ì\êüLÀ\Ó\äò\í55ûÚ·Û…óv\ç\ìß½Œù3¿\Öu\ìh\×]o\ái,\â\Õ\á]b\Ö–\Ëö´d91™b t\ã\ç1ž\ßÒ²ÿ\0°lÿ\0\è5kù5}A‘‹Em`\Ùÿ\0\Ðj\×òj?°lÿ\0\è5kù5\0S\Ö$ón\ão±}ƒýò¶\ãv\"A\ætÿ\0\à}OZ£]Nµ ¶Gö\Ýr\Ñ\æû5¾\Ò\Ýù)\åŽ\0\è›Gøõª\Ø6ô\Zµüš€1jöŸ\'—i©¯Ø¾Õ¾\Ü/›·?fý\ìg\Ì\èqœl\íþ³¯csû\ÏþƒV¿“Uý7@c\Õ~Í®Z,?f_´¤\æ?:<œ|þY\í\Óð ZŠ\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& \nz|ž]¦¦¿bûVûp¾n\Üý›÷±Ÿ3¡\Æq³·úÎ½\Z\êt\Ý\0}Uû6¹h°ý™~\Ò6“˜ü\èð:qóùg·OÂ¨`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€)\ëy·q·Ø¾Áþù[q» ó:¿ÿ\0ð>§­Q®§Z\Ð\Û#ûn¹hó}š\ßi\nG\îü”ò\Ç\0tM£üz\Õ\ì?ú\rZþM@´V\×ö\rŸý­&£û\ÏþƒV¿“P-µýƒgÿ\0A«_É¨þÁ³ÿ\0 Õ¯\ä\Ô‹Em`\Ùÿ\0\Ðj\×òj?°lÿ\0\è5kù5\0b\Ñ[_\Ø6ô\Zµüš\ì?ú\rZþM@´V\×ö\rŸý­&£û\ÏþƒV¿“P-µýƒgÿ\0A«_É¨þÁ³ÿ\0 Õ¯\ä\Ô‹Em`\Ùÿ\0\Ðj\×òj?°lÿ\0\è5kù5\0b\Ñ[_\Ø6ô\Zµüš\ì?ú\rZþM@´V\×ö\rŸý­&£û\ÏþƒV¿“P-\ÙøO\á\Ü>,\Õ\'±ƒ^³‰â°½¿,\È\Çå¶µ–\á‡\â±ø\Ö7ö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ô`\Ùÿ\0\Ðj\×òj\0Å¢¶¿°lÿ\0\è5kù5\Ø6ô\Zµüš€1h­¯\ì?ú\rZþMGö\rŸý­& Z+kû\ÏþƒV¿“Qýƒgÿ\0A«_É¨Š\ÚþÁ³ÿ\0 Õ¯\ä\Ôø¼9k<©zÅ³;°UP’z\n\0ö\r\'þI%—ýqOý+—®º\Ö\Ü\Ùü/†ÝŽ\ã,;\â\\W#^~_ÿ\0/¿\Ç/\ÐÆŸ\Úõ0õ\ßøúþ¹\æj•\î‹yw0–(w\ÆÑ¦r\à¹«º\ïü}Gÿ\0\\\Çó5·eÿ\0p\×5þU\ë\Ú\æ¦ƒ¤\ÝX\Þ<“Å±eA\Ü9‡Ú·©ò}\Úe+X®¿\ã\Öú\æ\ß\È\×/]E\×üz\Ïÿ\0\\\Ûù\Z\å\èQE€(¢Š\0±§ÿ\0\Ç\Èÿ\0qÿ\0ôV*¾Ÿÿ\0#ý\Çÿ\0\ÐMX©põ\ÜWP\Öe…\ä`-½qD‡?t€rsÓŽkÑ­l\íou›;;\Ë}4k¶vwS\\*Áv\â@7F’\"(VhÀf`\è\ä‚+\Íí®¦³¸Ž{yd‚x\Ø2Ie#¡t5¡u\â­núkynu‹û‰m\Û|/-Ó³DÞªI\àð9\×F¬i­¯ø?\×S\Ï\Åa\çY®Wm½\á»üŸC°Õ¬–mKG¸\Ñ--gº»²w–[«8£„*H\ÊnLDyh¥T˜c?x\æ³ô¿[ø7\âÆ™\â­\Ö)a\Òõ/cƒn\È\æ1²³€1ò«•l˜®z?\ëP\ß\Ë}¯~—²¨I.V\åÄŽ£³’8•T\Ô5+½Z\é®on¦¼¸`š\âB\îqÀ\äœÒ­R5#dºÿ\0_ð\à†\ÃÔ£4\ä\ïeo=\ïÛ¦\Ëkk¦º~¼ø7\Ç\Ö^*øcg\âM:K¤ð\íÝœ—bòH\Î\ËxÌ¢Lqº2“)\ë\È\ãµ~ox\Ë\âd?i\Û\Û=”Ú¥Œ°Ë\âš8Ð¾8\ÜB\î d\Älø/ö­»ðo\Â\à¨ü7guw\r\ækª»G˜\â¹iY\Ë°ó\å\Æ\ÙQy\\©\Ãnòo‡yÿ\0…\áœrµ-ôj\×\Ç\àrZ9g´©	9{¼±¿Ù‚\Ú+ü÷i.\Ç\ÐV\ÅJºI«u~o¹úÿ\0[ÿ\0’\à_û\nOÿ\0¢…|¦ÿ\0\É\'ñý†ô¿ý¨WÞŸðU	/\áÿ\0þ\Õ0\íI¶ù33û®ùE\Å|¦ÿ\0\É\'ñý†ô¿ý¨TðÖ™l=_\æ\Îj¿+øž;G\×5£s+G2C[*ŽL\Ä<6n@\ç±æ«®msI\Ô[S¸—G¸¹y`Q$ò\0’<8\ã\å\è<}üwÁ\ËûVƒÿ\0>_÷øW\Ô´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0g\êQ\ÚEp‚\ÊVš&&fqÈÆ¦A\Ðp°Àrz\ÕZ\éµK\í\îP¾uf|ˆG–.@@|`}\á†\Ï}\Ù\ç9ªj\Ð\ç\Â\ëþÿ\0\n\0Å«Vq\Ú=½ñ¹•£™!\rlª8y<\Ä‡· s\Ø\è}«Aÿ\0Ÿ¯ûü*\åöˆ¶Ú€]\Z\ê\à4\04›\Ãy\ÌC¿8ùys\Ç\ß\Ç|fŠ\ÚûVƒÿ\0>_÷øQö­þ|.¿\ïð Z+k\íZüø]\ß\áGÚ´ùðºÿ\0¿Â€1h­¯µh?ó\áuÿ\0…j\Ð\ç\Â\ëþÿ\0\n\0Ï³Ž\Ñ\í\ïÌ­\ÉkeQ\Ã\É\æ  ðx\Ød=¹žÆ­t\Ö7\Ú\"\Ûjtk«€\Ð\0\Òo\r\ä1ü\ã\å\ä\Ïðiý«Aÿ\0Ÿ¯ûü(Š\ÚûVƒÿ\0>_÷øQö­þ|.¿\ïð ýJ;H®YJ\ÓC\ä\Ä\Ì\Î9\Ô\È:–\ØOZ«]6©}¢=\ÊÑ®¬Ï‘òÃ…\È¨Œ¼0\Ù\ï»<\ç5O\íZüø]\ß\á@µô_Â¸Sþÿ\0…še¿…´m{þO_\Øjq\Ýhð\\\\\Ü[²©9C4[IX4n¥~öx¯ûVƒÿ\0>_÷øW[¡|Z›Að\Å×†\í/¼Ci \Þ7Vz¼\ÑD\á†Õ¼²pw)\Èü0ù¹uµü»•\Zj¤’r\å\ß]{5\ÐôM#ö~ð¦­\á\ÝjW¼º´Ô¾Å«\êº<‹¨<¿j³´iBJ`[X\ÄSs\Ý!\Ï\Ì•V\ç~!\Ûx\Z?ƒÿ\0f\Ó<-ª[kZ…Ò¥\ê\ê0iRí•¼õ[EiŽ>\èÞ¥T¨\Ëc\'\n\Ë\âñ\Óü<4K¯Yhq‰é¶º\Ô\Ñ\ÛÉ¼þda¶Á˜¡r‡~\"³ø§\áû½\Óûf\ßD¼r÷:$z¬Ë§\ÈN>c\n¸¾U\ä“÷G¶0\æ{8»i\Û[_\ÏMý\Ö\Ú\Ø\íti7uV;·ö¶ö\ïO\Ô\ëþ.|ð÷‚þ\Ý\ë:u\Å\Ä:Þ“¬A£jš|—\ïz‘Nð\Ë#!sclŠ\ÈbÁ¼À\îû\Ã\0·7ð7Ã¯kñR\Ö\Û\\±¶±ÿ\0‰F£{öþŸ\ç[¦4ù\åŠw…\ã}\èW#ghÀ5¿ñsþ­:=3[¼ñ.µ§)ŒªjZÔ·\"‚\ì\Û\0P\Ì\ËüM\Ó<QŸ\âw|—\ÓC¬5\ìV\æ\Ò;¯\í9¯	CŠG$’…	Rh\ÚJ\ãŠö’NO•\ë\éü¶\ï\ß_\"~¯N\É:±ÿ\0É»ÿ\0‡·\Þz%Æ‡à¿‰$³i%\Ó\ï-tM\nK¯\ëºm¡i\í\'ž\'Ž5±‘¸\Å\Ûj¥›œ`;¿\r|	ð÷\Æ_tKGÔ¼G\rŸ…\ã\Õ,\åûtp\Ér%¬¥WÍ³,%_41D!Cf [\åòo\rüF±ð^¬uÁªèš£#De\Óõ)mÀF\ÆB˜\Ù\\g‚\ÄqÓ¦\'¶ø©—ˆ[·¸ñZ\Ö\Õ_\í¥\Ö%\Z‚\0›6¤À‚gË‚q\Æ“³J/Tûn\ï\ç\Ò\ë\î·PT)\Þ\î¬]­ü\Ý-ýÞ¶wõò6¾\Ü\é7^ø­’šÖ’\ï \Í<{¯\í\çGµY\àÿ\0G˜5¨.Ûˆo26‹\î\ão&­\éÿ\0\n~\é¿´}g\Äþ)}7\\\Öô\ë›û/-\çeVŽIcŽ!\nYH’–x€f71ó9_”o\Ì\Ó>>jš4—’iúß‹t\Ù.¦k›‡²ñ\ÌMy1\Æd¸!þw °Á8Ç¦*Xüe—KÒµ\r:\Ê\ë\Äºv¤\Ò5\î—³p–S™š%q¹˜pwŸ\Ë\nR“ZE\ì—N—óó\ß\ËoyŽ4)­\ëG{\í//\îùm\çäŽ‹XøW\à{?\ê\íl<@úÞ\á\Í\'\Ä3Ky\0¶—\íF\ÔIF!Ü¸9Yœc73>5Y|>‡Pð]¶™¡j~º>—q>¡öøg…`xÇ˜\Ív±™&–“x\ÜTü£<q­\ã­)¢¹·hu™!¼·Š\Ò\æI5\'2¼1\ìò\á\ë´Æ¾\\xVR\Å\Æ01 Ÿ6\èºvŽ·^\"‡I\Ò\å[‹µ™„J¬YdÙ»j°bN\ä\nrN1ž-\Ôm¯u\îŸMµ\Ó5÷y¶J\ÃÁ/\ãFö·\Úþ\ï÷{§÷ùø¹\à]\Ã\ï¤\ßxJ\Ú\ê\ë\ÃzŒ“Cgª>¯ ·¯MÀ\"\ÛA$¢E\Ìr¦\ã¸•Á.øß‡þ8xgF\Õ4‹F7zµ®›§kšT78\çŒ:\î#mŽ7\0d\àŒšOüZ_jVú¦¼úæ»¨Û°>§«\Ïp°.sû²\Î]Nyû\ØŸL?Eø¨tMn\ïV\Ò.<Me«^]jöº\Ä\É|\àJ™PŒ©*2\ãé‰„\å¯ø^¿€T\ÃÓ’iVþMþ_\×VhøMð×Œ4ÿ\0x³\ÆV·¯%®«§\é°Xøa,ô¨[\Ï[€IU·dM«n\Ë\Ìr-½v,¾øE|c\ãO‹›\íw\ÅZ~·6—£\éªE¥½\ÔHÌ¢O2[ib‘\É÷E\â\']\å€–µñ\r<Kqs>¯ˆ5\æx¦–kRi^\êHXšvrw²+0R0@b\ãF\Ç\ãF§¥®¨l®üQj5id›P¶‹Z¹K{—q‡y\\vK1\Ï\å„\å+YE\í\åý\ß\Õ?¿\î\ÒTiJnJ¬m\ïyÿ\0w\Í[\Ó\äjXü\'ð—ð¿H\ÕüQ\â‰4½wZ\Óî¯¬\ÕvTh\ä–(\áòR\ÊD—ˆcs_3•ùFüOxo\á÷„t=\"\Þ\ê\Û\Ä\×:î¡¢\Új‚\ê\ÛuµYe\Ú\Í”aÝ´¨|I¿*X|Œ-“ñ:MÃ·~\Ó%ñE‡‡\ï·«+}^h\ã“r\ípcR#`@\0\îS>˜È¾×´mW\ìÿ\0mÑµ;ƒi\nÁn^\í\ØùkÂ£\Ï\Ê@›q\È\ã)É»¨½ü¶\×\Ï\Íz\ÛTB\Ã\Ó[ÕþM½\×÷{\'÷\è{^¡‚l|a¤\Ç\á\ï\rj:E\í\ÏÃ­B\ì\\>¥26y»|ikyIû\Ò\ï ü£·Ë•\ì~ø\Ûq X}mõË­Z^\ÙÇ¡ÏªNt\èEÍ´\Ð;\Ç\ì+bw=z“\ë\Ç÷~X¼=|Cù\ÒNLŠ\Þ\Ä\0¸úŒžyas>i>W«o§W\ë\Ð^\Æ	%\íc¢_Í®Ÿ\áÿ\0†9*+þ%ô¾ÿ\0¾ÿ\0ú\ÔÄ£þw\ß÷\ßÿ\0Zµ8\Ì\n+þ%ô¾ÿ\0¾ÿ\0ú\ÔÄ£þw\ß÷\ßÿ\0Z€0(­ÿ\0ø”\Ð.ûþûÿ\0\ëQÿ\0ú\ß\ßýj\0À¢·ÿ\0\âQÿ\0@»\ïû\ïÿ\0­GüJ?\è}ÿ\0}ÿ\0õ¨Š\ßÿ\0‰Gý\ï¿\ï¿þµñ(ÿ\0 ]÷ý÷ÿ\0Ö \n+þ%ô¾ÿ\0¾ÿ\0ú\ÔÄ£þw\ß÷\ßÿ\0Z€0(­Æ¸\Ð\ãb­§Ý«zqMûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Ñ[_j\Ð\ç\Â\ëþÿ\0\n>Õ ÿ\0Ï…\×ýþ‹Em}«Aÿ\0Ÿ¯ûü(ûVƒÿ\0>_÷øP-µö­þ|.¿\ïð£\íZüø]\ß\á@´V\×Ú´ùðºÿ\0¿Âµh?ó\áuÿ\0…\0b\Õ\ÝþCZý|Gÿ\0¡\n»ö­þ|.¿\ïð©mõ-\Ö\â)£±º\ß‡\\\Ê:ƒ‘@\×7ü“\çÿ\0xÿ\0\è\êâ«°†\ä^|3Ž\áT¨•C…=³.k¯?/ÿ\0—\ß\ã—\ècO\íz˜z\ïü}Gÿ\0\\\Çó5·eÿ\0p\×5þU‰®ÿ\0\Ç\Ôõ\Ì3Yzõ\Ì7[#¸•G\\€>A^½\ìjvr}\Úes~¼ž\âúE–y$_,œ;’:Š\é)^\àEuÿ\0³ÿ\0\×6þF¹z\ê.¿\ã\Öú\æ\ß\È\×/@ÂŠ(¤EP?þ>Gûÿ\0 š±Uôÿ\0øù\î?þ‚j\ÅL€+‡®\â¸z€&³,/ +\0¹m\ëˆX$9û¤“žœs^kgk{¬\Ù\Ù\Þ[\é£]³³ºš\áV\ã·º4‘B³F3\0@§$^omu5\Äs\Û\Ë$\ÆÁ’HØ«)#¡­¯kw\Ó[\Ës¬_\ÜKn\Û\áynš&õROÈ®º5cMkýÁþºž~+:\Ír»hõ\ëÿ\0\r\ß\äúV¿6™¦\ê\Z%ü,¥Ý£ùòÿ\0e[\È$\Ú\ì«*\Û6CmÀ\èp3Ôœóþ9¶Š\×\Ä÷bb·†EŽdŽ…\nñ«—i\ç%z)$\0ª‘ø£Y‡P’ý5kä¾‘v=\ÒÜ¸•—Žg$p8öŸ4\Ò\\Lò\Ê\í,²1gw$³rI\'©¥V¬f¬—[ÿ\0^»ôù‹†))I\ìšû\Ýû-¶_‚C+¡øwÿ\0%\Ãöµÿ\0Ñ«\\õtóÿ\0\Ã8\äÿ\0jZÿ\0\èÕ®\ZŸ½In~…ÁVÿ\0\äŸøþÂ“ÿ\0\è¡_i¿òIüGÿ\0a½/ÿ\0Dj÷§üBK\Çø\àµA#ûRm¾L\ÆLþ\ë¾Qq_\é¿òIüGÿ\0a½/ÿ\0Djó|5¦[Wù³J¿0ô¸\î\Þ\ÇX6Ò¬p¥ªµÊ°\å\ãó\â\0;\Ê\Ü\ÏcV¬\ã´{{\ãs+G2B\Z\ÙTpòyˆ<6n@ç±«_PdQE\0h\ë\Ñ\Ý\Å}½•f›\ì¶Ì¬ƒc \ä!P}Á\äõ¬êµ©Gi\Â)Zh|˜™™\Ç\"C\Z™AÀrÀ{\É\ëUh\0­.;·±\Ö\r´«)j­r¬9xüø€ƒ\Îò‡·\0ó\Ø\çU«8\í\Þø\Ü\Ê\ÑÌ†¶U<žb†CÛ9\ì@*\ÑE\0QE\0QE£¥\Çvö:Á¶•c…-U®U‡/Ÿ\0py\ÞPö\à{\êµg£\Û\ß™Z9’\ÖÊ£‡“\Ì@A\àñ°\È{r=Z\0(¢Š\0\Ñ×£»Šú!{*\Í7\Ùm™Y3\ÇA\ÈB ûƒ\É\ëY\ÕkRŽ\Ò+„R´\Ðù133ŽD†52ƒ€\å€ö“Öª\ÐEPEPEPEPEPEPWô¸d¹&cie’DD–f9\0\0:’j…t^\Öcðï‰´­Zh\ÚX¬o\í\îž4\Æ\æT}\Ä÷À«‚NI=†·\ÔÛ—á®¯NˆÖ·\Zœ`¼\ÚL»‰Gr€`‘\ÎUIe\ÇÌ¢¹Jö­/\\\Ò<7‰\âC\âK;Ë˜5šy-\áÆ¡w\nZ8(Y¼\à\î[˜¼V»q4©\Ó\å\ä\ë\æŸk_qµH\Æ6±\é~\rðÇ‰¾#x\Ö\Ã\Ã:­ýž\Ía¦[«Ç‚\Ú[dfg#;A<t\ä°õ®BûXñ›¨\ÜX]jZ…½Ý¼­±=\Ë\åN\ÖS\ÏPA¯Lð‡‹¼\à\Ï	x˜\ë\êz¦³¬\Û\éºtVZEè°šEŠ9\å—\Ï{y“\æ’8h° \ë\ßIñk\Â7šÏ‹õ\nø\Íþ\ê\Þ$:f©=\äö÷È¥VA`\Ò\ÃX\É)I¸E†Lb¸À\é\Äb+G(ª•;=_~žIoÙ«o¡\à\á0´%†„¥M]¥\Ñv\Öþwü5\ÛS\È\îü\ã?Œð\Ýü@N¸Ú²h\ßh[Ù¾\Í\ç4‚0Û±»fH\çnqÚ¹ýs\\Ó¯®m$\Ö/ZH$h˜­Ô˜%Iôâ¾¶\Ò~?xF?ŠWºÖ™ñxSJÿ\0„\î]kR_\ìÛ¢u\í9Œ>R\íŽ&Ï–Ro\ÝÍ´/›¹r\ÜWÇºõ\Ôwº\æ£qo†k™$FÁRÄƒƒ\í^|q˜›Bõ%{k«\íú¿øw\Ôð¶“öq\ßMy’û\É\á(\Ö\è/}ÿ\0/þ4\ÂQ¬ÿ\0\Ð^ûÿ\0_ük.Š\Ó\ëXùù/½“õ<7üûÜOøJ5Ÿú\ß\àKÿ\0ð”k?ô¾ÿ\0À—ÿ\0\ZË¢­b?\ç\ä¾öS\ÃÏ¸ý\È\Ôÿ\0„£Yÿ\0 ½÷þ¿ø\Ñÿ\0	F³ÿ\0A{\ïü	ñ¬º(ú\Ö#þ~K\ïaõ<7üûÜOøJ5Ÿú\ß\àKÿ\0ð”k?ô¾ÿ\0À—ÿ\0\ZË¢­b?\ç\ä¾öS\ÃÏ¸ý\È\Ôÿ\0„£Yÿ\0 ½÷þ¿øÖ‡<I«O\â.95K\Ù#{¨•‘®†\ÆA\äW5Zžÿ\0‘›Hÿ\0¯\Èô1]X\\Uwˆ¦Gº\êûœ˜¼&a\ê5N?\è»½¼·wÁO4Ò°DŽ5,\Î\Ä\à\0ROjŸV\Òo4J\ãO\Ô-\Þ\ÖòÝ¶Iõú‚0AAV¿‚|mq\àMIõ;»Â»#–ñ\Ì \ç;6°Á \àž¸\à`›ž:ø“{ñ\ìÏ¨\é\Út70p·V±º\ÈSŸ’\ä\É\Ï#ƒœc\'>i\ë¶ž¢\Þ\ß|#H\Î\ÎT\ã\'{ŸÀ\n³ö‰\ç£ÿ\0\ßF¥ðÙ´ûE¾Mö#¤œTn#‘œþ\×[xf\Þ\Î\ê\ãO{Ôµ‹;S+Z«\ÈDò´‹ò€¤3»ƒœ\ç]Tðòª¹“\ïø+œ\Õq¤\ì\×õýZþ¨\äUn\ÚÝ§c°F”ghc’>§ò¤oµ,9ó„,\ÅC¥€€}FG\æ+µ_\éR\ÝJ’\ÃöOô\Ë¥ŒL\ÑÌˆ\æXòO`Í’¸Á<\Z«\â\ëY,ü/¦¤ºWö4Ÿm¸&\×.qòDÃ’\Ã#\Ôó\ÔpkY\á%Nœž\ß\æ—o3\â\ã9\Æ	oþW\îa]hzÝŽŸýÎŸ¨[\Ø\Ê\Çu,.±>\á•\Ãƒ‘\ÓÖ³~\Ñ/üôû\è×¨\ë\Æ.ò\Ú\É%]Eôm4\ÞyŽ7µX¡fx\Ð†B#\ÎK|»ˆ\Æ\rh^øB_\Ú\ØÁ \êl×—pÑ¼PÞªÛ»\Æ\Ë7š\ê\ìJ«ªƒ\å{G\Î\æÑŒoZ:»½;$ŸW\ç§\ãcÇ¾\Ñ/üôû\è\Ñö‰\ç£ÿ\0\ßF½$xNÍ®>Û­\r,Ü\ïŸ\æ—\Ï\Ø>R\Þoú¬É°6x\ÏN)W\Â6I¬\Åm¢\â\ê(#šCt.\ÒÁ¼’ò\ÄdG\r\Ó\Ì\Ü\Ü1eÅ­Mÿ\0µ(\ë£ü;¥\ßmwÛ³<\î\ê;\Ëw=¼…U\Â\ÊN\Ö\0©Á\ìA\à\Ô?h—þz?ýôk\Ô.´\Û[?\ëVzLrƒ•w4 \Ì\ï’\Õ\Ù\å >\0V$ò1ósò-Ç‚´¥×­-.4O°Yf\Ú\Î\Î\ãÎ”ÿ\0i\Û3Ï’\Ä7\Ê·Ç´\rø\î*¹\ìf³Zi{\Ñ‡h½¯ý\íµ\î\Ï*ûD¿ó\Ñÿ\0\ï£G\Ú%ÿ\0žÿ\0}\Z\î-ô½T²¸\Õ\×O‚\Ò\ÛKiVò\Íg“\äbÜ‚\Ì[,ù\r‚8\Í9¢ð\Òü=Ý¢5¬º\éˆjÿ\0m—	óøò_õE9PIf˜œ•U@\Ä\æôW=:5\Õv\â“V\Þÿ\0–û\ìþh\å®ôMoO\Óâ¾º°¿¶±›o—s4.‘¾\á•\Ãƒ‘\È\Åg}¢_ù\èÿ\0÷Ñ¯EñV§cal\Öq\Ëq.¡ªi\Zm³\Ç4j–Ð¨Šó7\î%›\å•\\nnO~ž\×\Ã>\Ö4ÿ\0\'D_·\Í¥d\Ñ<W$\åm²­™™˜9,¡²»ƒp €kGü\'ûS\Ù\ÓR«ev­¥Ò\Þÿ\05~¶¹\ã3Gym2L³Ä“.ø™\Ã\"äŒ©=FA†¡ûD¿ó\Ñÿ\0\ï£^› ø?I»62]i’µ\ã\és]fÂ’HòÌ·oQšŒv\Æ>\èp~Lœ\àƒ%Ÿ‡t¾\Óm\å\Ð\'\ÚZ\äšy[ö–	­¢)\0 s†S)#qn:\ç¨\\¯úõ±¯ö­$\Üy[jýº_\Ï\Èò\ï´Kÿ\0=þú4}¢_ù\èÿ\0÷Ñ¯L¸C%š=3IKX\àš	o5?0Z³N$I¹+—\ÂbL·\îðv‰\â/\é ñ`±ð*\Ü^¡µy\æŽF\É\Z<“y&\×hB¡+\æ“É‰iý~>‡¥‡­õˆ9Z\Öm}\Î\Ç/öMCû4\êM\×\Ø<\ß#\í[[\Êó1»fî›±\Î3œRZ\Û\ß\ßGrö\Ñ\\\Ü%´~t\í³£\Ü{÷W,£\'Œ;\×\Ð0xf\Óþøx\Þ!\ÓWR“E7Ø¾]Éºþ\Ô$\\¨Ï“\ånò‚\Ãþ³<žüRiþµ\Ð~xš[Om*\çÂ–²¯ŠÒ¿\Ûd’{f™0[\Ë;r\íEž^’h}|¿\àõù}\Æñ÷¹|ÿ\0\ÍŸ\ßs\çø\í\ïæ²žò8®^\ÎD–\áUŒq³gj³t\íl\×iô­ðŸ‰R;‰F\ÕV;q™˜\ÚËˆ\Æ\Ðÿ\01\Ç++sØƒ\Ð\×Ñ«\à½?\Ã\Öwšl¾]\Ã\í\â\Íoä¸’Aª\Ú˜‚]Š°e;·\Æüòšò\Ö×—Mµ‡[\×$¼þÕ·ñýÉ·†%ýô\Ûa,’1a±Kpp­Á<Pšmÿ\0_\Ëÿ\0\ÉxªÓ£é«¶×ž\ê]¿Ã¾\Úß¡\åh—þz?ýôjeŽñ\í^\åVv¶‚<À6\Åb	\0ž€Æ½Nð½Œ~—W»\Ò\Ò\âu€^\Åp‘Ì°Ÿô•C\È&\nN7e\0ƒ¼\Z\Öñ\'†ô\í_\Æ:äº­˜\Ò\ã}r\Òr\ZD\r­>\ér\ìGÍ±N\ïº1\ÆkNG§õ\Ø\á–kIJI\'h¶›\Ót\â´W\×\âÿ\0€y\Ú%ÿ\0žÿ\0}\Z>\Ñ/üôû\è×¨jžÑ´ÙµI\åð\Íå©³Óže¶¿†kX¤\\D—÷ò39\ã<ÑªX\Ú\ÚxC\Äpiº,oŸÙ·\åU¦‘­\ÖKgvl‡û¨\Ä\à°?\æ\Ï›iq\Ç4§;8A\ê\×n®+¿÷‘\åÿ\0h—þz?ýôhûD¿ó\Ñÿ\0\ï£^\Óð§À>Ö¾]\ê×š±\â}I¯eµž=\Z\ÆKÉ¬b«G&Ô¹‹\Ë\Ü\Ì\ä<‰*/F\ëžð®›ym…\í~×¦ø_Mñ½–\î\ä´ó9µócu…8™¸PÀ`\Þ÷+òüUÿ\0${+Þµºÿ\0š_›<;\íÿ\0\ÏGÿ\0¾X³¶¿\Ô<ÿ\0²\Åss\äD\Ó\Ë\ä«?—\êíŽŠ22O\×Ð¿ôý\"\ËÄŸ|E¬x&\Öy­õK$²Iæ¼†+ˆf7%®8˜\Þ#*BeFPqô¯	\é^\nø‹\à\è4ôŠñõ\Íen\ífóÙŠhòa7\\\íË«\Ê Ÿ\Ý\ã¡9\ÍJ\ë\Ïõi?\Öÿ\0&O\ëúôõhù—\Ç\È$\Ñã™†\éV\áT3r@*ù ü«¯Døˆ±®’\Â\"Z!x¡õ#l˜¯;©z\êSVv\n(¢‚Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( }\Ò\ä’Y\×ÿ\0Ñ‚¹z\ê4Ÿù$–_õ\Å?ô`®^¼ü¿þ_Ž_¡?µ\êa\ë¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -m\ë¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -z¬Ø»\á_ùIÿ\0\\ó\îšO„4‹­.\Îi-7I$(\ì\ÞcŒ’ “Ö¼/Â¿ò“þ¹\æ+\è\Íþ@zý{\Çÿ\0 Š†–ø\Î\Æ7R\Ô-\í\ÓË…#ùW$\ã1‚y>\æ¸*ôOˆò\Ôÿ\0\ë˜ÿ\0\Ñb¼î¯ Q@Q@4ÿ\0øù\î?þ‚j\ÅW\Óÿ\0\ã\ä¸ÿ\0ú	«2\0®»Š\á\ê\0šÌ°¼€¬å·®!`H\ç\îNzq\Íz5­­\î³ggyo¦v\Î\Î\êk…X#Ž\ÜH\è\ÒDE\n\Í\Ì\0=œEy½µ\Ô\Öw\Ïo,OI#b¬¤t Ž†´.¼U­\ßMo-Î±q-»o…\åºvh›\ÕI<\"º\èÕ5¯õÿ\0ú\êyø¬<\ë5\Ê\í£×¯ü7“\èwWš“yu§j‘›&\"\È\Êm\îZ½H\èŽ#,ª¨v\ä\Ô \î\Ä\×+ñM]+\Æz¤1¥¼Q™£Ž\ÙÐ¢)<!ÂŸöx#Ò°\ïµ­R\é®o.f»¹lnšy¹ÀÀ\É\'=*;‹™¯\'y§•\çšC¹ä‘‹3ROZ*Ö…H\Ú1¶¤aðµh\ÍJSº³Vù§é§¢ÿ\0(\ë¡øwÿ\0%\Ãöµÿ\0Ñ«\\õkø>øi~.\Ñ/\ny‚\Þú	Š\ÛdSÒ¸*k	z™ú\'ÿ\0[ÿ\0’\à_û\nOÿ\0¢…|¦ÿ\0\É\'ñý†ô¿ý¨W\Óÿ\0·w\í\Æ_ø^\Ít6\ÒM•ô“ok¡6üÇŒ}\Å\Å|Á¦ÿ\0\É\'ñý†ô¿ý¨W\Ïðõ9\Ñ\Ë\á	«;¿Ì©J3|\Ñ\ØÀ\Ó\äò\í55ûÚ·Û…óv\ç\ìß½Œù3¿\Öu\ìhÖŽ—\Û\Ø\ë\ÚUŽµV¹V¼~|@Á\çyCÛ€y\ìs«\é	\n(¢€/ky·q·Ø¾Áþù[q» ó:¿ÿ\0ð>§­Q­z;¸¯¢²¬\Ó}–Ù•p#0!Œt„*¸<žµ@^\Ó\äò\í55ûÚ·Û…óv\ç\ìß½Œù3¿\Öu\ìhÖŽ—\Û\Ø\ë\ÚUŽµV¹V¼~|@Á\çyCÛ€y\ì@3¨¢Š\0(¢Š\0(¢Š\0½§\É\å\Újkö/µo·\æ\í\ÏÙ¿{ó:g;¬\ë\ØÑ­.;·±\Ö\r´«)j­r¬9xüø€ƒ\Îò‡·\0ó\Ø\çPEP\íbO6\î6û\Ø?\Ñ\à_+n7b$gA÷ñ¿þ\Ôõª5£¯GwôBöUšo²\Û2²f1Žƒ…A÷“Ö³¨\0¯]ð¯ü#–>\Zðk\ê–6fõ®d»¤µó\r\æg0˜¤\ãW\n\à7G[Èª\ÃjWoª5\ÔÌ–¹\êd8‡,X\ì\ç\åù‰<w9­!.Wvqb°\ï+k\ÓÑ¯\×úg«ø“\áÏ„t->\æm[X:v¥x/.-\"‰¥(†9¥\"­³#\ä\Äc:m\Ý\Êü¿7/}\á]_&§£õ+\ëh£“R›\í\è‚Ñ™\Â\í6\Ív\\²¨t‘\×=v\ä\nÁ‡\Æ\Þ\"·\Ó\ï,b×µ8\ì¯\Þ\æ\Ù/$\Î\Ï÷Ë®\ì1nù\ëÞ›y\ã\r{Q\Ò!Ò®õ½F\ëK‡hŠ\Æk¹öŒ.\Ô\'hÀ\é\ÅF–·§õýnsS\Ã\â Ó”\ï­÷\ÒÞ–\í\Òö\ë®\Çe¨|>Òµ&Ð¿\áŠ\çYµ»½‚\Â[\ß\í(\Æù¤\êŒ-¼\íb¼\ÄÀ8-ƒ[W_	|7>¡á¹´ûù\ßJ\Ô?´ÿ\0\éd®mb\Äó[@1m…š2©Œ’yÍµ?xZkF\ÔuýRý­Ì¶7W’Han>d\Ü\Çi\àr=møsâ®±§x’WY½Ôµ\æŽ\âF›Pq<-,^Y–X?— Hlº=+KÅ¿ë±…L>20N\Õ\'¥÷ºv»z^öw\ÒÖµ¬ô\ê#øw\àÛ­Z\àG5µŽ›¤­þ¢‡UŽ\ì,­2\Æ#Yí­¤U]X²\Æ\ã$)\Û\É¼7„<7k\â›K\ä\Ôt\Å\ÔtÈ¡»}\rMñ$W\r$nV,\rÉ0*“±~AœC\Å_u=kUÒ¯´\ë­WNº\Óm\Ú\Þ-B\ãS{‹÷\ì\Ç}ÀT$|\åB€\0¹$\ã\ÚüBñUõ\åí·‰u‹{\ËÂ¦\æ\â+ùVIöŒ.ö\r–À8\éBšOo\ê÷üŒþ§‰«Iª’z\ÛFû4û>\Ï[½\ím.w¯ð¦\ÏVñ\æŸ`!š\Ý5_is\Û\é\Î^;x\"òX\Ë&r¢Y2XtAÀÁ®kGð®‹«x.\æ\â\ÌÏ©xŽ\æž{T¿Ko³B€Ÿ3\ÊxOž‚\Ä$¡‡÷p	<ö•\ã\r{A†ht\ÝoQÓ¡šA,±\Ú\Ý\É»ƒ\ÌŒ@\äúQŒ5\èt6Ñ“[\ÔSG`Ci\ëw ·9;Žc\ÎÞ¼ô\ëY«(\Û\È\ëX|J²s½š\ï\ÞW¿Þ•¯\ÓWÐ“@\Ñ.\ÚûF½ž\Âc¥\Ü_%º\ÜI	ò%`Ë¹´\Èô5ô®¹\à[/Šþ$ñ®ƒy¤hþ·Ó¼oo¡hšÆ—¤[Ø„Y®dŽKf¢-ÁX‘\\Ë‚¼0Aùwû{Rû­ö\×Ø­e3\Û\Ûy\í\å\Ã!\Æ]8V8Žx­/|DñW¤´“\Ä^&\Ö5÷´É·mRþ[“q…\Ø\í\ÎOAN\ë\Ý\ìŸÿ\0#þO\ïõOÔ³÷­»_ü—ù¯¸õ=C\Â	ô?xZ\r:úÿ\0\ÄK6¢lõ\r\ZùCEó ŽFž}6‚K«B\"c…ÿ\0X3\Å\Ú7Æ²x»â§ˆ¡Z\ä¶\Úf¡si:Î­öåˆ¬ò-ÀŠ1X\n`61÷o=ñÄø¾\â\Æ}{\Å\ZÖ·=‹´—Q\Ô&¸krH$\Æ]‰S•^˜\è=*Ï‚c_ø\ãMYžK¤\ÔuKu½žiIy’þñ™\É\ÎNI,Ny\Í(\Å\Í\Â7\êÿ\0ÁûüU®\í\Öß¯ü¸Æ¢½\ÓEu­WK±\Ôle>\Ô/\ßN6‚3§²yfi7”ò\Ödc\'ûX>\0\Éðº\ì­CØ¤Ó½ÿ\0\àŸ¯‘S‡%\Íi5\è§™ô«)\äH\Ò/1š`X\"…\Û À7û^\Óþ€–?÷\Ý\Çÿ\0¯^ý˜ô}KI“Äž<\Óÿ\0²R÷C†;]5µ½F\Ö\ÆÝ¯.n<Ë™	%\Ãc9\é\Ålø£\à†ü)\âo\êZ¶««hvú–Ÿg\á{¨[0\ê$\ÐJf\Ù*Hˆ©\å…A‰\à:“X©)¥+k»\åŽí¤·Z·tÿ\03ÍŽ—+µ\Ò_Þ–\Ývz%·\äxGö½§ý,ï»þ;Gö½§ý,ï»þ;_dO\à=\ßöª‡Äš®½©jz—Ä¹4û\Ò\Ú4‚É­\ä‚R÷\nÑ»I»\Í\"´{U·7Aü$W	´}6\×[\Õ/®%ð×ˆ$*Fª)\Ô/\æfófKN\Ê\ÉüH§Š\Ã\ësöJ¥£ªþXÿ\0/7oømûš,šn[¥ñK«k¿—\Ïóø÷û^\Óþ€–?÷\Ý\Çÿ\0£û^\Óþ€–?÷\Ý\Çÿ\0¯¡4Ù§\Ã\Z¦ƒ\á1}w§x†\ã[\Ðôýb\Êÿ\0´ƒP\Ê\ã6q\Ç”\ê¢kŒ!Â‘ŠÎ±ø\àQ\Ñ[Ä–úR_kVZ¥\Å\Äw\Ùö‰t\r±X•ciUŠ\ía&\Ã\ÎdIbg\ÝGK\ßÝD›{y¢c…„­g-mö¥\Öþ~Lð\Ï\í{OúXÿ\0\ßwüv\í{OúXÿ\0\ßwüv¾†Ñ¿g¿\ëVúGˆ$»\×4/\Í\áYüIwgª\Ýnœm¾6ª«4R0\\\È-\ß }\Ô\r•ð_i\Ú“\ã\rN\×\Ã\Z£k:H\r¥\ãÐ¨;Ix\ãf*I]\Æ4Ý·;W8¤ñ3O•¥}~\Ìz6»wL›WNVÿ\0»\'ß³E?\í{OúXÿ\0\ßwüv\í{OúXÿ\0\ßwüv²\è§õ™ö_ø\È>«O¼¿ð)™©ý¯iÿ\0@Kû\î\ãÿ\0Ž\Ñý¯iÿ\0@Kû\î\ãÿ\0Ž\Ö]}f}—þòª\Ó\ï/ü\n_\æjk\Ú\Ð\Çþû¸ÿ\0\ãµ-¯ˆ!²º†\â\Z\Å&…ÄˆÛ§8`r¾µE5Š©šµÿ\0\Ãò&X:RN2m§ý\é™\îŸlm¯´>\Ñoû|½¾j\Æwg«ž>\Óm,ôx^\Þ\ÖÎ ´q…8\Ú\Üp*/†óÿ\0¶û=^øÿ\0 8?\ë\áô®N§i\ç\ÚL‘_5½´ñ\Ï~ó4+f§÷¥Ì„ª…?xœŒm\Ï\çWZ\Êháµ•“lWr´\îXšE 2!þ&€@\ä+\Êõ‰\åµñóC#C4r\ïI#b¬¬0At \Óõ¿k¾&x\ßXÖµU\ãb\È\×\×RLT#q88Uü‡¥K“º¶Å®[;\îzJ²6 ,DÐ›\ã/-„«\æy™\ÆÍ¹\Î\ìñŽ¹§ù\è÷s\îÉ´uŽ\æO1v\Â\ìHUsŸ”’­€z\àúW\0\ß¼\\Ú¤z›x§Z:Œqð\ê3y\Ë9(vB\çœg\Èþ\"x®-b]Y<M¬&«,b/–þQ;\Æ0BÝ¸¯ŒãŠžiöE~\ï»=\Ö¿û)¶+qö©µ¿”\á¼\éF\ÜÆ˜?3|\ËòŽ~a\ëV´}iôú¬/l`\Ä\ÖFidPi\"de\Èaómb@\Ïlâ¼Œø—W7QÜVø\Ü\Çr×‰7\Úz\Î\Ø\Ý(9\Èsµr\ÝN\Ñ\Ï\í+\ÅzÞ…oy›¬j\Z|7«¶\ê;[§‰g#\Ãzúš|Ó±9§	l÷=+Ì‹\ì±\ÜùðýšI\Z$›\Í]Ž\êe8$RG_˜z\Õ\Ë\Ý.\ëM·¸¸»…­`·¸û$\Ò\Íò,Sc>SÀ|s´óŠó+xžóD\Z4þ#Õ¦\Ñ\Â,CO’úV·¸Ú¾Ym¸\ã¡\Õ<a¯k–q\ÚjZÞ£¨Z\ÆR«¹%E@‰\0(fÇ¦O­.i—\î[¯õý]=+\ëI\äHã¼µ’G!U\á	bz\03É«:´G@Ô®4\íQ“M\Ô-œ\Ç=¥Û¬R\ÄÃª²1O±\å:.¥‘«Z\Þ\Íao©\ÇÍ¥\ÓJ±KŽ\Ìbtp?\Ý`}\ëC\Ç>4\Õ~\"ø»Tñ&·0¸\Õ5)Œ\Ó:®\Õ\0Q\Ù@\0`*Ü¶·Ÿ\éo\ÔË¹\êø.´I4\Û3b\"Œý¦\êky·I \\…iò®\â8\n9\ç\'©Û¨¼û?\Ù\Þ9þ\Ñ!†.Eo6AŒ¢\àò\Ãrð9ù‡­yF™«^è·‰w§^\\X] !gµ•£u\ÈÁ\Ã)qR·ˆ5GºK–Ô¯\Z\å&k”˜\Î\å\ÖV\Æ\é\ÎC«–\êp=+U(h\Ýÿ\0¯ø\n2‹|‰k¯\Ïú·\ËCÓ’hd·–\á.-\ÚYVIVd*…³´œpq\ëƒD3\Ãqò\Åso,P(y]&B±©!AcžH÷\"¼\ê\Ï\Æ~ \ÓôÓ§\Úëº•¶žC)µ†\îD‹\r\Ã`8Á\É\Ïæ¢ºñFµ¥Å¦\Ü\ê÷÷\Zt;|»9n]¡M£„\'§^´oþ\ÞU\ê_eo\Ó\î=Jþ\ÖM.\Ò\Æ\êô-­üfkI®\"\\ b¥£bp\ê‘‘E&xƒPŠ\ÃK+©_KŸ.\Ö\ÍÄ²¾c…RIÀý®ÆŸµ\Z\éž\Òæ·¶\ÓôÕ­l,,Ì¦8÷¹y2»±gc“ó``\0\0+œ\Óõ­&ú\Þö\Æ\æk;\Ûih.-\ä1\É©Ê²°\åX#‘ŠÏ›W\Û_»¡¯CÖ¬\ÔjQ\ÝIi$wQ\ÚE\ç\Ü42+ˆcÜ«½\È?*\îe<e€\ïWumQ\Ðe½‹S³›N’\Ë\Ê7Iv¾Qƒ\Ìxlm\Þ9\\õ+Ï¦ø½ã»z\rr_\ZøŠMj\Þo¤ú¬\æ\æ8‰\ÉE“~à¤“À8\æ±õ/kš\Ã]µþ³¨_5\àˆ\\››©$3ùc\ï\É;¶=;R\æcþ¿¯\Äô¼ \Ó\Åù–be0¯5|£ Šn\Î7`ƒŽ¸4\ë¨Í•\Ý\ËGoiz¬ö³\Ë\"ªNª\Å‘‰\Ã\0À©#8 Šò_\í+³§‹u1±™Å¯˜|¡!K\í\Î7`ž¸±¥|CñV…\áû½Mñ6±§\è—{þÑ¦\Ú\ß\Ë´Û”+oX+d\0G QÍ¿õýj.Ç¥>\î\ßÏ\Æ\Ñý–\Þ+ÙŸ8òa“g—+\áFó#\ÚÇƒ½pysZ¹\Õ<E\â+yoñ>³¬ùrÁ\Z¢$—¾f@\Þ\\ÿ\0q$òI¯\Z\êò-Ê¾«z\ësmœ\ê\×D°G³Ë‰¹ù‘|¸ö©\àl\\h\ÃñÅ¶ú>Ÿ¤\Å\âj-+Nnl¬SP˜Am*±e’4\rµ1$2€A$\Ó\æþ¿¯tþ¿­\îz›kmk`Rú\éQ\åhmœH\áK;œ*‚I\ì&®`\ê?jÓ­¾\Ç7\Ú5(>\Õeßž\ê›÷‘®Ÿ+|Ë‘òŸC^=£ëº—‡õh5M+Pº\Óu8|W–s4SF\ÄJºAÁ<ƒÞ¯\ê>ñ>­®ZkW\Þ#Õ¯5›F\rm¨\Ü_J÷°rà¤…·)\ÜÅ¸=I=M.m¿¯\ëúù­¿¯\ëúóôM5F³x¶š|‘\ß]2³,\Ò,ŽUT³ªIÀPIô\0šVŒ®”š›4k¦\É3[%\á‘|–•T3F8,”•\Î@ ÷®6\×\ã\'\ìµ{\ÝV\ß\Ç$ƒT½TK«\èµ{…žuA„\á÷0PN<gŠ‹Møµ\ãûR½°ñ—ˆ,o57_\\[j“\Ç%\Û\á¥`\à¹\äò\Ù\êh\æ`w\Ði·7^A†˜\\[Iy—†ó ™*\ãª/—&\æ\r“Áª÷\n-,m/\'’8l\î÷ýž\âIc›i\Ãlbp\Ø<t5\æø›X·ò<­Vú/\"\ÞKH¶\\¸ò\à“™\àð\æI¹G{g©«6~8ñŸá»¯ZøƒT¶\Ð.›}Æ•\r\ì‰k3q\Ë\Äk•y#øG¥]¿¯\éé…“Gm:öú+siqûø\î]‘]Æ­ƒ†¥— ©*G~A®¦\ãÅž!\Ô<Y4öPEg©K¥ùp\Ø\Ù\Â\Û\é\æ\ß Ä¯¹\Õ<›\Ì;Im\Ç$Ÿ_k)6—2\ê÷\Ë6•·û>Arû¬ö¶\åòŽw†\äm\Ç<\ÖÎ©ñs\Ç:Þ¥§j\Z<C¦»Icuuª\Ï$¶¬\Ø\Ü\Ñ39(NJ‘\ÐSæ¾ž¿\×õ\ç\Ü\ëúþº\åÖ¹¨ü5\Ö<5©K`\Ìn¤Ž\é,\î¡\ÌZŒŠñÈ¸#ŠÌ™œŽ3/¾\Z\è\Ú_\Ç/øJk/\ëZf™>¡´>…g¼\ÌAü¢Á…óPb¹\Í\âv¥,<K\â\'ºñ…\îžZ[T\Ö/$•DÛšDg-’\È%c#&Fãœ‘¸\Ñ\àßŠ\Ú×‚<K©xŽ\Ía¹ñ\âLUºiZkw”0–T\n\êŒ\Ì‡\ï×œ\ã<\ÔIó}\ÒüvûµûýF·ù¯\Ã\ëü‘\Æ\ÑE(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0÷\Ý\'þI%—ýqOý+—®£Iÿ\0’Ieÿ\0\\Sÿ\0F\n\å\ë\Ï\Ëÿ\0\å÷ø\åú\Óû^¦»ÿ\0Qÿ\0\×1ü\Íbj\ßñø\ëœú\ÖÞ»ÿ\0Qÿ\0\×1ü\Íbj\ßñø\ëœú×ªÍ‹¾ÿ\0„Ÿõ\Èÿ\01_Fh_ò\Óÿ\0\ë\Þ?ýW\Î~ÿ\0„Ÿõ\Èÿ\01_Fh_ò\Óÿ\0\ë\Þ?ýT=€óOˆò\Ôÿ\0\ë˜ÿ\0\Ñb¼\î½\âü‡5?ú\æ?ôX¯;«\èEPEP?þ>Gûÿ\0 š±Uôÿ\0øù\î?þ‚j\ÅL€+‡®\â¸z€&³,/ +\0¹m\ëˆX$9û¤“žœs^kgk{¬\Ù\Ù\Þ[\é£]³³ºš\áV\ã·º4‘B³F3\0@§$^omu5\Äs\Û\Ë$\ÆÁ’HØ«)#¡­¯kw\Ó[\Ës¬_\ÜKn\Û\áynš&õROÈ®º5cMkýÁþºž~+:\Ír»hõ\ëÿ\0\r\ß\äú¶¡{ iVW\ÒD	¾\Ó]DË¥À\ã\ÌmYÅ»E¨À{sÔš\ãüe¦Ë¤øŽ\î\ÞY\"•¾ICÀ\n²\\Æ 8#*:õ\ëU\ãñ6±£& šµò_È»\én\\J\Ë\Ç³’8ªM%\Ä\Ï,®\Ò\Ë#wrK1\'$’zš+VEd¿­ÿ\0\0œ6t\'\Ì\Ýôÿ\0†è¬–ÝŸd2­\èÿ\0ò±ÿ\0®\éÿ\0¡\n©VôùY\×tÿ\0Ð…qK\ág¢ö={\ã\×ü‚4¯ú\î\ßú\rpzoü’ÿ\0\ØoKÿ\0\Ñ\Z…wšC¤\é{\ÑW÷í¬Oðýpúoü’ÿ\0\ØoKÿ\0\Ñ\Z…y™_û¬~™€\ç,\ã´{{\ãs+G2B\Z\ÙTpòyˆ<6n@ç±«W´ù<»MM~\Åö­ö\á|Ý¹û7\ïc>gCŒ\ãgoõ{\Z5ê›…Q@µ(\í\"¸Ae+M“38\äHcS \è8X`9=j­^\Ö$ón\ão±}ƒýò¶\ãv\"A\ætÿ\0\à}OZ£@Z³Ž\Ñ\í\ïÌ­\ÉkeQ\Ã\É\æ  ðx\Ød=¹žÆ­^\Ó\äò\í55ûÚ·Û…óv\ç\ìß½Œù3¿\Öu\ì@(\ÑE\0QE\0QEj\Î;G·¾72´s$!­•G\'˜€ƒÁ\ãaö\ä{\Zµ{O“Ë´\Ô\×\ì_j\ßn\ÍÛŸ³~ö3\æt8\Î6vÿ\0Y×±£@Q@µ(\í\"¸Ae+M“38\äHcS \è8X`9=j­ZÔ¯#¾¸I\"¶[UXbˆÆ˜ÁdQŸ€9b¥»½j­\0\ì\Zt\Ë\à\Ú‰´m/I\Ô5=[Y¼³\Ô/õM*\ßQ«qm\Õ.H\ã.I7\ÛpŠñú\ßð¯\Äø\í?ðx—Xð÷Ú¶ùÿ\0\ÙWò\Úù»s·–\Ãv763\Ó\'ÖŸF…\Õ?\ëo\éÿ\0W=CCøE\á½J\Ë\Ã\Ö\ÃZ›\Ä$\Ñ.µ\Ø5[\"M>\ÌF\'\"\'ƒ\Ê- g`\î²FxNß™\Ú\ÇÂ¿\Ùø_Wka\â\Öôi> ¹š[\È´¿j6¢H1\åÀ¹\Ê\È\\\ã(q¹¼²ˆ(·ðõÞ‰5xô+·2\Üii}(¶™\É³Å»kT‘\ØU\'ñ.¯\"Ü«ê·®·6\Ñ\ÙÎ­p\äK{<¸›Ÿ™Ëjž\ÅÀ\àR\ê\íýo§\ËE\çmwh¥º¾¿ð\êÿ\0zO\Òúl{gÄ¿øUñwÃ­Gðî©¢É¬Xh\Þe\Ò\êv\ïŠeUrc[D\Ý6O2\îÁ`IN\Ã.\Ã\áÿ\0\Ã\ïx¾ûF\ÒcñE©\Ð\×Q¹¿K‹«y\ä\Ôm\íc.¾Ø—É•\Ê8*\ÂP \î\Ëm ù²üBñR\èv:(ñ6°4{–\â\ÓOòýž\ÞUb\ÊñÇ»j0$@$šÌ±\×5-3X‹V³\Ô.­5X¥óã¾‚fI\ÒL\çxpw\Ï9\Îh{»ur}­÷k§Q-•ú(¯º÷ûôô=»Á0ø\âŸ\Â?ø6ó]\Ð,üMu’\Ò\êô5\Â\Æ/|™\ÍD%ŠM™ûŠ:©1ü×µ=/ö‚\×\ìlõ»K-@jñ\Þ[A;$w*¶\×,«\"ƒ‡\0ò\Î5\æ|Tñ¤$›\ÄQø¿^\ÄE\äI«.§8ºxøù\Z]ÛŠü«Á8\àzU›Œ\ß-5k½Vx–Nñ;›\Øõ{…šeL\ìWpû˜.N<dâ”—2Kü_ù5¿+~#Z_Ï—ð¿ùþqð\Ï\áo€\ïþ\ÛxŸ\Ç>$}\ZýNm6†Y\×\ìþTq3HV+++;\"6x8N\î%2¤ð¿\Ãÿ\0x@\Ôu\â-Bÿ\0[Žø\Åu§\\Á\æ^8\\\Âñ1¹|\Ä †$\àr\ÚoÅ¯h÷Ú•í‡Œ¼Acy©¸’ú\â\ÛTž9.\Øg\r+\Ï\'–\ÏS\\\íÆ¥yykmm=\Ôó\ÛZ†C$Œ\Éf\Ü\ÛA8\\““Ž§š%v\ï\åýÃ‚\Ñ[\Ïúþ¼½M-D»k\í\Zö{	Ž—q|–\ëq$\'È•ƒ.\äF\Ò@##\Ð\×ÔŸ¾\èþ&Ÿ\Çw^ðÝ‚‹\ïX\è6\ÖV1\Ålmncºž¢…¶‘’?³\ÈN6\æCÁŠù;û{Rû­ö\×Ø­e3\Û\Ûy\í\å\Ã!\Æ]8V8Žx«‹\ão/\Ú\Ê\ëú 7—ks‹\É?}r¤²\Îÿ\07\Í $\çIæ­´ùWgÿ\0\Èÿ\0“ü³´¼\×ÿ\0%þkñ=\Ï\\ø\àQ}\à\ã¥\ê÷¦\ÏÄ·\Z–“‰x÷\Ç\nF >l¶6Å‘¦•ce\à`‘\'P<·\Æ^µðEž‡`\Í9×§°ŠûTŠF-\ÚR\ïJ»A!1³džd\Çy\Ãñ\Äø¾x\'×¼I«\ës[¹’5ùn\Z6!Ae.\Çœ\îARé­«xû\ÄÊ·W³jZÎ­yMw};Hò\Ê\í´3»džH\É9©Œ[i-ÿ\0¯\Õþ	\Z\èôKú¿ùY}\ì½wñ\ÄW\Úz5Æ¯s.š„\âa’Qµ›\ï2\áW\nIhÀ\â¹úô«…¶:¥ø\Ñ,.\ï?µr¢=J\átû–bB¢Ê†#\nùmç«^k]•\áV6u]þwÛ¡U#5g\"\ßöµ÷ö_ög\Û.?³|\ï´ý\Ío\'\ÍÛ·\ÌÙœn\Û\Æ\ìgVÎ“ñ+\Åþ“\Ì\ÒüU­\é¯ö1§\î´\Ôfˆý”\Â«\Ýä“³\î\äž+¿ø\'ð–\Ç\Çþñ~µ7…üU\ã+ý\æ\Â4Ÿ\n\Ü,R”œ\\‘ókpH_%\n>÷\'¥sº\'À¿x»GmkF\ÑT\é’%\ÕÍ¼WZ•´w/o\0c,‹ºI\"&\ÖS\"¦\Ý\ÊW¯\Ë\\\Ò÷[O¦¯\îÿ\0#%®\ß\×S\'Mø³\ã\Z\ãQŸOñ—ˆ,gÔ¦[‹\é-µI\ãk©T\åd”‡\ØAl‘Y°x\Ë\Ä·šu\Ü:\î¥Ö›»\ì3\Çw\"½®\ægo)\Êe\Ø\í\ÆKÔšÑ¸ø_\â{_¶ùºfß±\ék\Óÿ\0¤DvYM\åyrý\îs\ç\Åò˜n\äv^\nø¨_kúl~!0Q±\Ôç·¾\Ðõ[K\Õ3ZØ½Ï”\ÏÊ¨\ÙnG\Ãmn1\Ô\'¢mô_•ÿ\0É¯Àk]_ø\Öÿ\03Œ“â¯f°\Ó,dñ†¼öZ[\Ç%…³js˜\í\Z3˜\Ú%Ý„*~\é\\cµ\'„üqw¡\ëZd÷º†½&Ÿex÷\ë“«)\Ò\á”4R”G!Ú™}„ z\Ïü;\Öüc§\Ýj\écmö\è\ÒX­c\Ôí¦ºEtY\Ën’4°\åYHós‘\\\Õ;\Ùù‹u\ä\ÏTø‰û@\ë\Þ+ñn‰­\èw\Úß‡g\Ñl>ÁezúÔ·:“ngyeš\ì\Ë\È\ï,™*ª6¸\ã\'Îµ\ÝTñF­qªk:•Þ¯©\Ü\Ó^\ßN\Ó\Í)\0\0YØ–<\09=\0ªR²þ¼õ\ØQE\ÄQE\0QE\0{\ß\Ã?ù‰\Û?ýž¯|Fÿ\0õð¿úU†óÿ\0¶û=^øÿ\0 8?\ë\áô¥\Ô3±ðŸ…|I©\è6²j\ÓE­\ß\ë\Ù\Ý\ÙB\Î\Í\ä\É)R\ãt\n‘²®\Ì~ò]Û³…\ÆÚ³\á\ßxA5\Ï\êqYjw:n¥«\Éa-­õ\Ô\'sDðm‘¿sŒ&ù¢ ô#z\âõ¿kpÝ¥”zÆ –v?h´·[§\ÛÉ’\Û\ã\\\á$œŒ“XM¨]5¼\æ\æco´±Dd;cv\Æ\æQ\ÐµrG]£Ò®2Q’muÿ\0/ø\'•SV£—\ï\ZNý{©zuq~Vµ\ÏSðüzñdÓ­mt5±\ÓØ¬\Þ#Ž=J%ûtXF¶§nUŠ\å±ºã¤¶¾ð¯<I©\ß\ìò´X‘»³‘\ìbšöD!ŒP¥¬\í¶FGe]ˆ\0\ë·!G›j\Þ0×µ\é$“S\ÖõFI!\î\×wrJZ \á\Â\Ä\åw\0\Ø\éZ‹Gñ.¯\áÕ¸\ZV«{¦•\Ù8³¸x¼\Õ\ç†\ÚF\á\É\àú\ÔÁ¨¨©ko\ëúÿ\0€fðU-)Fv“\Ów·»\Ö×¾Ž\Ý5\ÛVz`ðÿ\0…|3\áÿ\0\éúŽ•}ª\Ü\èÚ¼VŸl†ò($dN€¦\è\ÆÑ¸d\î%zcžK’	¾ø-šö\Ý\á\Ô,\Ú\â6š\'‚}\ÞpC·\Ê¥@=wN•\Ìi\Þ/×´}J\çQ°\Öõ-B\ëwŸwow$rË¸\îm\î[\'““Ö§³ñ÷‰ô\í1´\ÛO\êÖºs\Ò\éR\"%†À\Ø\ç\'<s“SvÏ·\åoò+\êµUõ»r‹Õ¾–¾š®šzù#¯ñG€ü\'\á¿\"K®7ü$emx«J\ë9•Q\Êû0EP®q ó³\î\ØY¼a\à¯ø}u™¬\âÖ®!\Ñ5\å\ÒnR\âòk•+1Ü„B|²8\ä>A\Î \à\Û\Å\Ú\ìš\Zè­­j-£¯M<\ÝHm\Æpý\Þvý\îzu\æª\\\ë÷‹r·\×3­\Ôÿ\0id•˜K/\Íû\Ç\Éù›\æo˜óóSV\ä¯t¿«¯\Ò\èp\Â\×V\ç¨Þ®ú\ï{y+u²\Ö\×\Ñ\íoEø‹‡l~.Kg¥øV\æ\é#\Ô<¹tÏµþ\ê\í[hT!‰\Z2s\ÆòG¡\Ý\Ó>ø\Ãÿ\0­t—•µ­6\Ò\Ò\ëV¸\Ñn6½\Ìok-\Ç\ØnZ?Ý³\îˆ#ylx\'p÷Fž[\'Ž<G+i\ìþ \Õ´ðVÌµ\ì„\Û»H\æù\0cŠ‹\Â~(¿ðW‰4\ísK‘c¿±˜M˜»‘±\ÕY‰XeH\î	žzü´û·þû0Ô¥FŠ§=ZVÝ¿Þºþ\ëdzÁ\ß^ø\Ã\ã<Z\ÛN\ß\Æw?\Ù:¬l€\ïK‡\nF0¦\'\Ù\"cLKŽ8®g\Ã>\Ó\ï¬üb/,u\íN\ãK²im.48[xdYUL·d‚V\r»¾aƒ¸­M üB²ðŠµ­{C\ÐÅ•\ÔñM”’]KiFÖ‘~PdeFp„‘´•c¸¯4ü)ñQð_‡üC¦ivö\ÐÍ®Z›­AŒ¦²±\áU\ß\å\íb£$¡aŽTý;?øv÷óò:þ\Óõ_ð~ýË±\Ê\ÑE\ÄQE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0{\î“ÿ\0$’\Ëþ¸§þŒ\Ë\×Q¤ÿ\0\É$²ÿ\0®)ÿ\0£rõ\ç\åÿ\0òûürýiý¯S]ÿ\0¨ÿ\0\ë˜þf±5oøü?õ\Î?ýko]ÿ\0¨ÿ\0\ë˜þf±5oøü?õ\Î?ýk\Õf\Å\ß\nÿ\0\ÈBOú\ä˜¯£4/ù\éÿ\0õ\ïþ‚+\ç?\nÿ\0\ÈBOú\ä˜¯£4/ù\éÿ\0õ\ïþ‚*Ày§\Äùjõ\Ì\è±^w^‰ñþCšŸýsú,W\Õô\0¢Š(\0¢Š(ÆŸÿ\0#ý\Çÿ\0\ÐMXªúü|÷ÿ\0A5b¦@\Ã\×q\\=@Y–€\\¶õ\Ä,	ý\Ò\É\ÏN9¯Fµ³µ½\Öl\ì\ï-ôÑ®\Ù\Ù\ÝMp«qÛ‰\0\Ý\ZHˆ¡Y£™€ S’¯7¶ºš\Î\â9\í\å’	\ã`\É$lU”Ž„\ÐÖ…×Šµ»\é­\å¹\Ö/\î%·mð¼·N\Íz©\'ƒÀ\äW]\Z±¦µþ¿\àÿ\0]O?‡f¹]´zõÿ\0†\ïò}þ\ãM\Ð\Ûf®B†M,\Üû‘…ÀˆN-†g\np§\0·|ð¾.³{-i÷H’	¢Štd¶[o•\ÑYsü¨pF@\ã=\ÏZ­ÿ\0	«ý§ý¥ý§yý£Œ}¯\Ï7\Æ7\ç=8\ëTî®¦½¸’{‰¤žys\Ë+f\'¹\'’h­Z5\"”U¿§ø½>\ï»<.¥	\ÞRº·\Ý\ä´\ÙIÕ½þBö?õ\Ý?ô!U*Þÿ\0!k/ú\îŸú®)|,ô\ÞÇ¯|zÿ\0F•ÿ\0]\Ûÿ\0A®Mÿ\0’O\â?û\r\éú#P®\ã\ã³Ht/z*þý±µ‰þ ®K\Âr\èR|=ñž·ª\\i\Þf©§M\n\Ù[Gs4›a½|·–?”o`N(\Ç\Í^fWþ\ëŸ\æcG\à9.;·±\Ö\r´«)j­r¬9xüø€ƒ\Îò‡·\0ó\Ø\çU«8\í\Þø\Ü\Ê\ÑÌ†¶U<žb†CÛ9\ìj×ªnQE\0h\ë\Ñ\Ý\Å}½•f›\ì¶Ì¬ƒc \ä!P}Á\äõ¬êµ©Gi\Â)Zh|˜™™\Ç\"C\Z™AÀrÀ{\É\ëUh\0­.;·±\Ö\r´«)j­r¬9xüø€ƒ\Îò‡·\0ó\Ø\çU«8\í\Þø\Ü\Ê\ÑÌ†¶U<žb†CÛ9\ì@*\ÑE\0QE\0QE£¥\Çvö:Á¶•c…-U®U‡/Ÿ\0py\ÞPö\à{\êµg£\Û\ß™Z9’\ÖÊ£‡“\Ì@A\àñ°\È{r=Z\0)ö÷\Ú\\G<<3FÁ\ÒHØ«#A=\é”ûv‰n#3£\É`]#pŒËž@b;\àý\r5¸žÇ§üu’MjxŠþüM­\êš%›\Þ\ÃrY\î\äeˆ ¹‘À(\Â@ ‚_\Ì\à—U\È\'\Ëk¨ø‰\ã+\Z\ë–\×Zs\éZm•¶ik5\Ç\Ú$X¡Œ / D\ÌAbB¨ù°\0¹z•¼Ÿvþ\ë\èWD¼—\äQE1Q@Q@Q@Q@Q@lx_VŸA\Õ-u;]¿i²¹†\æ-\ã+½²\äw±\ê\åú™\Þ_\ëU\â\ÓC\ÛS\Ô!ø iz>únw«§\ß\Í¼÷­ •\Ö¬\ßp¦„b1»–nAóZÜºðN»g¤Jm6h\í6‡bq½ý\×t\Î\åCÙ˜\0{Xu\ÕZu%eQ[\åb\ç);s#\Ð~üB\Ð|?\à¿øc\Ä~Ôµ­?Yº³»iz´v\Âö\âp^\ÚpÁ¼ó\Øch\æ½\'\à÷Å	\\\êZU–­¢¶£\è:Ö™§\ëWZÊ¤	o-µÜ‘G,F%6ùš5p\èxý\ÙlW‰ø?À\ÚÏ/§µÑ­¢”\Û\Ân...®bµ··ˆ7\Ë<Ì±Æ¹* »–P9 T*ð®£\à\Íj]+TKu»#—6·q]D\è\è%‰™`r¬G5\Í/y5/´¿N[ü–„G{®Ÿ\×ù~ª7\í¤?†oaM7ˆ\ï|9i\á©õ	5Pm\ïF\ël ­º+fR$m\é]‰k\Ä\×/´\Ùað\æ¤-\ìŸUx­u\r|\Ý%º\Þ\ÙQ²ù°[\ÂdˆÀÛžõó\åÖ“}akeusgqomz-¬\Ò\ÄÊ“¢±Fdb0À2²’;©ET¢^ýÔº\Þÿ\07¯\ãp¹n^Ÿ\åo\Èô_ˆ¬|e\à¯hp\é\ßm\Ó0$\Ö5›ø¯®\Ýj‹r-¼N)V7i6\ä*\Ý\çTQGVû‹d£\Ø(¢Š\0(¢Š\0(¢Š\0(¢Š\0÷¿†óÿ\0¶û=^øÿ\0 8?\ë\áôª?ÿ\0\æ%ÿ\0lÿ\0öz½ñþ@p\×\Âÿ\0\è-K¨9\ëÿ\0ò»ÿ\0~¨UýþC7\ï\Õ\nOp\n(¢Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@û¤ÿ\0\É$²ÿ\0®)ÿ\0£rõ\Ôi?òI,¿\ëŠ\èÁ\\½yùü¾ÿ\0¿C\Zk\Ô\Ã\×\ã\ê?ú\æ?™¬M[þ?ýsÿ\0@Z\Û\×\ã\ê?ú\æ?™¬M[þ?ýsÿ\0@ZõY±wÂ¿ò“þ¹\æ+ª®WÂ¿ò“þ¹\æ+ª¤€Š\ëþ=gÿ\0®mürõ\Ô]Ç¬ÿ\0õÍ¿‘®^¨Š(¤EP?þ>Gûÿ\0 š±Uôÿ\0øù\î?þ‚j\ÅL€+‡®\â¸z€&³,/ +\0¹m\ëˆX$9û¤“žœs^kgk{¬\Ù\Ù\Þ[\é£]³³ºš\áV\ã·º4‘B³F3\0@§$^omu5\Äs\Û\Ë$\ÆÁ’HØ«)#¡­¯kw\Ó[\Ës¬_\ÜKn\Û\áynš&õROÈ®º5cMkýÁþºž~+:\Ír»hõ\ëÿ\0\r\ß\äú†©“V\Ð°¡´’\ïT·+#\\\é\Ð\ä\Û#/œ\"d+\Z§ .O$\×\'\â\íB\×R\×\îe²Š­WG\äÂ±	€»Ê¨\0\Æ\â\0\ïT\æÖµ‹\Ù/%¿º–\îD1½\Ã\Ì\ÆFR»J–\'$cŒzqT\êj\ÖöŠË½ÿ\0¯\Æþ¾A‡Âº-JN\í+}\îÿ\0†‰[\Ñÿ\0\ä/cÿ\0]\Óÿ\0BR­\èÿ\0ò²ÿ\0®\éÿ\0¡\n\ä—\Â\Î÷±ô^¹ÿ\0%\á·ýŒVŸú5+\á\ß\Ä¼ñ7ƒ‘~\'xóQ\Ö\'\ÔôôŸI½µ\Ûbå§ŒMŸ\í\îÌ€Á0ü\Ø\0ª\ä\ã7\ãU\íå…ž‹uis×›öò\è\ê¤\0A¬+‰0›\áî·©¿Œ<Do­õKh¥þ×¹ùc’\Æu\Æü˜£äŒ¼u9ó2¿÷Xüÿ\03\Z?\çú|ž]¦¦¿bûVûp¾n\Üý›÷±Ÿ3¡\Æq³·úÎ½\Z\Ñ\Ò\ã»{`\ÛJ±Â–ª\×*Ã—Ïˆ\08<\ï({p=Žuz¦\áEP\íbO6\î6û\Ø?\Ñ\à_+n7b$gA÷ñ¿þ\Ôõª5£¯GwôBöUšo²\Û2²f1Žƒ…A÷“Ö³¨\0«\Ú|ž]¦¦¿bûVûp¾n\Üý›÷±Ÿ3¡\Æq³·úÎ½\Z\Ñ\Ò\ã»{`\ÛJ±Â–ª\×*Ã—Ïˆ\08<\ï({p=ˆuQ@Q@Q@´ù<»MM~\Åö­ö\á|Ý¹û7\ïc>gCŒ\ãgoõ{\Z5£¥\Çvö:Á¶•c…-U®U‡/Ÿ\0py\ÞPö\à{\ê\0+WÂšñ/‰´½)¦û:\Þ\\\Ç—\Ú€\ÈÏ \ïYTª\Å2’¬AEiNQŒÓ’ºOb&œ¢\Ô]™\Ùx’\Ãš}ß…u»…\Ôc‘\ÖU†y‹ÁŒ\0\ÂV‚	\Ë\r¡N1×œ\r?Zi\Z\Å\ß&»vö\Ö\ÆyYXHcó$\ãj™rl\'\æ(G\ã9ÇüGw}my>¿ªMyk»È¸’òF’,ŒŒ[+‘\×öñç‰›P[\ã\â-X\ß,f¹7\Òù	\ÉPÛ³ŒóŽ•\Ù\í\é\ìÖ—½­¦\Ö\Úÿ\0>\ß-/cSMu³W¾»\ß{tþ»VŸðÿ\0H·“[º×¤“I³²ž\Þ\í\Úû\ÌlJŒ\ê\Æxm\åVTcnû\Ã<&±ogk«^C§\Ý\ë\åe‚\å£(e@~V\ÚyY³ñf¹§\êW\Z…®³¨[_\ÜgÎº†\é\ÒYrrw89<\Ô\Öu\ÅÄ·wO<¯4\Ò1w’F,\Ì\Ä\ä’OROzÂ­JrŒT#k[õû•\éS©79^öôþ¾dtQEs!EPEPEPEP]/\Ã\ÝF\×Gñf}ÿ\0Vº´óü»¿v²nn;ð\ÍU\ËõRÿ\0¼¿Ö®q’’\è4\ì\î{öø~÷Hñ¥ýÎ˜ÚŒ£P\ÕR\ãÌŽ\æ\ÝD,\ÞT}L’‰%R»x\Ú>TÁ5\àôQ]U\ëûd’V·\ç¥ÿ\0/ø&“©\Ïec\Ö>\Íi¯|5ñ_„’ÿ\0L±\Ö\îµ-;S·ƒX½K+mB\áe·k‡dD?¾G¤@\Û[v\Ð}—Â±ü.\Ðu\ï\r/Cð­\æ½žŽ\Ñ\éskö`®a\'QKk­M.\í\ä\Ä\Æ1\Ã\Ú—&ò\Ì\Ý\ï\çoÁ%÷Yj¿#igýk¿³=\ï\ã÷Š#ñ\Ã‡\ÐX/†\íl4Ï¶\ÙË§i\Óiò\ÞYH/nLQ—ˆ	¤\É(|\ßõr1\ÞIv\ÉðJ(¨JÍ¾úý\å\Ê\\ÁEUQE\0QE\0QE\0QE\0{\ß\Ã?ù‰\Û?ýž¯|Fÿ\0õð¿úU†óÿ\0¶û=^øÿ\0 8?\ë\áô¥\Ôœõÿ\0ù\Ýÿ\0¿T*þ¿ÿ\0!›¿÷\ê…\'¸QHŠ( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( }\Ò\ä’Y\×ÿ\0Ñ‚¹z\ê4Ÿù$–_õ\Å?ô`®^¼ü¿þ_Ž_¡?µ\êa\ë¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -m\ë¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -z¬Ø»\á_ùIÿ\0\\ó\ÕW+\á_ùIÿ\0\\ó\ÕR@Euÿ\0³ÿ\0\×6þF¹z\ê.¿\ã\Öú\æ\ß\È\×/TER\0¢Š(ÆŸÿ\0#ý\Çÿ\0\ÐMXªúü|÷ÿ\0A5b¦@\Ã\×q\\=@Y–€\\¶õ\Ä,	ý\Ò\É\ÏN9¯Fµ³µ½\Öl\ì\ï-ôÑ®\Ù\Ù\ÝMp«qÛ‰\0\Ý\ZHˆ¡Y£™€ S’¯7¶ºš\Î\â9\í\å’	\ã`\É$lU”Ž„\ÐÖ…×Šµ»\é­\å¹\Ö/\î%·mð¼·N\Íz©\'ƒÀ\äW]\Z±¦µþ¿\àÿ\0]O?‡f¹]´zõÿ\0†\ïò}þk)]5h\â„Eý”\ÓMp\Ö}\á8fKR¾Y\ß÷B£1!«Œñ\å²\Úø’PÁrC‰öu\n®­û@KgqP\0‘TÄš²\êM¨®©zºƒ\r­v.\Í#Á|\ç¿j¥uu5\íÄ“\ÜM$ó\ÈÛžYX³1=\É<“NµhÔ’¶¿\çù\ßþKe†\ÂT£SžRºµ¿->_w’\ÖñÕ½þBö?õ\Ý?ô!U*Þÿ\0!k/ú\îŸú®|,õÇ¯|zÿ\0F•ÿ\0]\Ûÿ\0A®Mÿ\0’O\â?û\r\éú#P®\ã\ã³Ht/z*þý±µ‰þ ®Mÿ\0’O\â?û\r\éú#P¯3+ÿ\0u\Ïó1£ð\åœvo|neh\æHC[*ŽO1ƒ\Æ\Ã!\í\Èö5jöŸ\'—i©¯Ø¾Õ¾\Ü/›·?fý\ìg\Ì\èqœl\íþ³¯cF½Sp¢Š(Ö¥¤W,¥i¡òbfg‰jd\Ë\ì\'­U«\ÚÄžm\Ümö/°£À¾V\Ün\ÄH<Îƒ\ï\ãü©\ëTh\0«Vq\Ú=½ñ¹•£™!\rlª8y<\Ä‡· s\ØÕ«\Ú|ž]¦¦¿bûVûp¾n\Üý›÷±Ÿ3¡\Æq³·úÎ½ˆ\Z(¢€\n(¢€\n(¢€-Y\Çhö÷\Æ\æVŽd„5²¨\á\äóx<l2Ü\ÏcV¯iòyvššý‹\í[\í\Âù»söo\Þ\Æ|Î‡\Æ\Î\ß\ë:ö4h\0©ôûh\ï/­\íæº†\Æ)dT{«€\æ8A8.Á˜¨\êv©<p	â ¢˜£ûDk\Z„þ9ƒEš[”Ò´]:\Æ\×O³y·[\Ç\Ù!Ì°($*JG™\Ð1\Þ\0\ÙË«²ø™\ã|m¨iš„ºEÎ™¬¥…µµ\ë\Ér\Ç‘\Ç\å«Fh¤‚\î¶F\Ñ\Åq´»ÿ\0_\ÕÃ¢ô_–\ß-‚Š( Š( Š( Š( Š( Š( ®Xÿ\0ª—ý\åþµN¶ü\'6Ÿo¬YË«\Û\Ëw¥Gw]\ÛÀ\Ûd’\ÙuSØ•\È\Ô\Ó@}û\0|7[£\â_\ßi!\'c´ÑµK˜·$nD‚s\Z“\Éº‡b\Ê,+\É?j\Øø^\Ó\í¯<R|W\ã\Ë\É.o5û‘\ÂÇ¼\Çöt\Ú8C´9Ûœ€W€¥i>?~\Ñmñ:\Þ\Ï\Ã^²xNT[],*£JTpÒ…$`vPHI\'§‰S\Õ~\ÛY\è?<O\ã/±i\×ú½ž£a¤Ú¶¯h—––+p³´—/«¬„6(d`7±\nX.;û\Ù\Þ_\Zx“Z\ÕüK\âŸ\è\Ze½®”\ë\á\ë{[K£wo\æB\é\rÜ¶1¦cÀ\ÚÛ\Ë\ço†x;\Ç\Ú\ç€\î.\ä\Ñî¢Ž;È¼›«K»Xn\ínPÁe‚dx\ä€a¹N\Ò#5¿oñ\ãÆ¶ú¦«zu;‘ªC½Ý\æ“gqbñÀ\0V\ÒHš„Úƒh$dæ›¿ô»ýûüú\Ù	]\'ý]¿\á\Ù\é÷Ÿ\0</«j_|=\á\Û\Ë\íW\\×št\Õf³µ[\Ü\Å\r\å\Äs\\C\"\Îå‚¤$ HÀtP\çk1Z\éõ…±¯Å¯xƒRø||#¥x‡\Ãú\ãŸ\ê:a·K{›K+\n\Ã\"Œ|¢\ÚP\Øû\ìH\ä\ZðAñ»\Æ	¢d\Ç}g\r†\ê\Ú?\'J´ŽH¡¹gi\áŽUˆ<q±‘ÿ\0v¬n8³¼3ñG\Äþ\ÒÆ¤\êe³Y§c6ñIµ\æ·kiH.¤\Ñ;)\0\ã¡ê ˆ•\Üd¿\ÅoY][\Ñn·\×d‹Ms^\Ú–¿{z?.¦ÿ\0Ç&\ÇGñ‡\"°³·²Ž_h\×%¼Ky^\Æ&w Y˜’ORI&¼Úµ|E\âOÅ—V·\Z­\ÏÚ¦µ³‚\Âò\Õ6ÁkI…;QTdòq’I¬ª§ñI÷mý\ì]\"»$¾\äQE(¢Š\0(¢Š\0(¢Š\0÷¿†óÿ\0¶û=^øÿ\0 8?\ë\áôª?ÿ\0\æ%ÿ\0lÿ\0öz½ñþ@p\×\Âÿ\0\è-K¨9\ëÿ\0ò»ÿ\0~¨UýþC7\ï\Õ\nOp\n(¢Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@û¤ÿ\0\É$²ÿ\0®)ÿ\0£rõ\Ôi?òI,¿\ëŠ\èÁIðÿ\0\áþ£ñ#Y›L\Ó&µ‚x­\Ú\åš\í™Whe\\\rª\Ç9q\ÛÖ¼üü¾ÿ\0¿C\Zk\Ôó\Íwþ>£ÿ\0®cùš\ÄÕ¿\ãðÿ\0\×8ÿ\0ô®\×\âw….ü\â\ëúHeºµŽ=\ïnÅ\îP\ã€z0\í\\V­ÿ\0‡þ¹\Çÿ\0 -z¯cb\ï…\ä!\'ýr?\ÌWU\\¯…\ä!\'ýr?\ÌWUI\×üz\Ïÿ\0\\\Ûù\Z\åë¨ºÿ\0Yÿ\0\ë›#\\½PQHŠ( \Zü|÷ÿ\0A5b«\éÿ\0ñò?\ÜýÕŠ™\0W]\Åpõ\0MfX^@Vr\Û\×°$Hs÷H\'=8\æ½\Z\Ö\Î\Ö÷Y³³¼·\ÓF»ggu5Â¬\Çn$ti\"\"…fŒf\0NH\"¼\Þ\Ú\êk;ˆç·–H\'ƒ$‘±VR:GCZ^*\Öï¦·–\çX¿¸–Ý·\Âò\Ý;4Mê¤ž‘]tjÆš\×úÿ\0ƒýu<üVuš\åv\Ñ\ë\×þ¿\Éô;Kû\nÕ­.\ã’\Ò\Öúò\Ã0\Ü\Þi\Ëövuœ©”ÀˆÁw¢°_ô\ÉÁ9®S\Ç\Ö6\ÚwŠ.!¶UEò\áyb¬\Z³€¿\Ãóòÿ\0N\ÕB?k\ê2j	«_%ü‹±\î–\åÄ¬¼p[9#ù\n\Îf.Å˜–brI\äš+VH\Ù.¿\çù\ß]ˆ\Ãa\'F|Ò•ôÿ\0/%¢µ—®\ÈJ·£ÿ\0\È^\Çþ»§þ„*¥[\Ñÿ\0\ä-eÿ\0]\Óÿ\0B\Å/…ž“\Øõ\ï_òÒ¿\ë»\è5Á\é¿òIüGÿ\0a½/ÿ\0Dj\Ü|vi“¥\ïE_ß¶6±?\Ãô\Ã\é¿òIüGÿ\0a½/ÿ\0Dj\æe\î±ùþf4~KŽ\í\ìuƒm*\Ç\nZ«\\«^?> \0\àó¼¡\íÀ<ö9\Õj\Î;G·¾72´s$!­•G\'˜€ƒÁ\ãaö\ä{\Zµê›…Q@\Z:ôwq_D/eY¦û-³+ \àF`C\è9Tpy=k:­jQ\ÚEp‚\ÊVš&&fqÈÆ¦A\Ðp°Àrz\ÕZ\0+GKŽ\í\ìuƒm*\Ç\nZ«\\«^?> \0\àó¼¡\íÀ<ö9\Õj\Î;G·¾72´s$!­•G\'˜€ƒÁ\ãaö\ä{\n´QE\0QE\0QE\0h\éqÝ½Ž°m¥X\áKUk•a\Ë\Ç\ç\Ä\0w”=¸ž\Ç:­Y\Çhö÷\Æ\æVŽd„5²¨\á\äóx<l2Ü\ÏcV€\n(¢€4u\è\îâ¾ˆ^Ê³Mö[fVAÀŒÀ†1\Ðr¨>\àòz\ÖuOyöo9~\É\æù^\\yó±»~Á¿þû±\ß\Ï5\0\ë¾ÿ\0„r\Ç\Ã^\r}R\Æ\ÌÞµÌ—q´–¾a¼\Ì\æœ`ª\á\\\ã\ã«`ùXmJ\í\ãµFº™’\×\"\ÝL‡\å‹œü¿1\'Ž\ç5¤%\Ê\î\Î,V\âb¢¥mzz5úÿ\0Lõ|9ðŽ…§\ÜÍ«kNÔ¯\åÅ¤Q4¥\Ç4±¤B5¶d|˜€,gM»¹_—\æ\å\ï¼+¢\Ë\àD\Ôôc>¥}mrjS}½Z38]¦Ù¡Ë–U’:\ç®ÜX0ø\Û\ÄVú}\åŒZö§•\ã;\Ü\Û%\ä‚9\ÙþùuÝ†-\ß={\Óo<a¯j:D:UÞ·¨\Ýip\íX\Íw#ÁÑ…Ú„\í08¨\Ò\Öôþ¿­\Îjx|D\Zrõ¾ú[\ÒÝº^\Ýu\Ø\ìµ‡\ÚV¤\Úü\"\Ñ\\\ë6·w°XK{ý¥\ß4ƒýQ… W€¬C7˜˜°kj\ë\á/†\ç\Ô<76Ÿ;\éZ‡ö€Ÿý,•Í¬Aøžkh-°³FU1’O y¶§\ã\ëMhÚŽ¿ª_µ£ù–\Æ\êòI-\ÇÌ›˜\í<G ­¿|U\Ö4\ïCª\ë7º–¼\Ñ\Ã<H\Ój\'…¥‹\Ë2\Ã+ò\ä\0)\rƒ÷G¥ix·ýv0©‡\ÆF	\Âz¤ô¾÷N\×oK\Þ\ÎúZÖµžDüu«\\\ïæ¶±\Ót•¿\ÔP\ê±Ý…•¦X\Äk=µ´ƒj««X\Üd…;y\"×†\ãð‡†\í|Asi|šŽ˜ºŽ™7o¡Á©¾$Šá¤€-\ÊÅ¹1\æRv/\È3\Èx«â®§­jºUöuª\é\×Zm»[Å¨\\joq~á˜\ï¸\n„œ¨P\0\×$œ{_ˆ^*±¾¼½¶ñ.±oyxT\Ü\ÜE*\É>Ñ…\ÞÁ²\Ø=(SI\íý^ÿ\0‘Ÿ\Ôñ5i5RO[h\ßfŸg\Ù\ëw½­¥\ÏB¾øk¡Á\âe¶¿µ¾2k:õÖ™k‹:ù:~\ÉUp|\È\ËLG˜>OÝ«\×\æ\ã\"\Ç\áÎ‘q\àû­}\ßPq¦‹ˆ®¬\ãt\ßv\èÊ«4\r³ˆTÈ¾fCÀÁ;þ^#MñV·£\Ú\ÞZ\Økö6×€‹˜m®ž4œA\Þ¸$s\êi°ø—W¶’\ÚHu[è¤µ…­\àd¸pb‰³º5 üªw6TpwZ\ÏEy~Ÿ\×\ßäŽ•…\Å/ùyù\êµû´²Óµ÷dK¥\Ý\Û\Ù[js\é÷K’c\Ü4l±JË‚\È\Ü‘‘_Møy4ÿ\0ø\ëÀ\Þ\'ð{ižÓ¼Y¤\ÛI£`\Û\Ø\êZs\Ë1£\\\Ç7qí¾v˜»™\ã^µó/öö¥ö[\í¯±Z\Êg·¶ó\ÛË†CŒº.p¬p9ñ[š\×Åø–{	õxƒU›O˜\\Y\É{ªO3[J0D‘–s±¸Œ;\Ú\ÞM~—ým\Û\ï=YG™5\Ý5ùÿ\0_\Ò=N\Ë\à\ïƒ|]e¤\ëºTšý¾œÍ¬µõ\Äð\Ëuv,!Šoô}±J%#k	|¼™1ƒ\Èx³Àztv¾¾ðµ®©>\'‹t\Zf©<s\Ï‹<`J±Æ²+•\Èm‹ŽG8\É\ál|Y­\ém`\ÖZÆ¡h\Ö\rwh`ºt6\Ó6\Ý\ÒÇƒò9Ø™a‚vA[zoµ«¯\Úx§Z\Ô/<AªZ]\Û\\4ú•\Ó\Í,¾SeU¤b[P=…Kš)\í¥ÿ\0¿ø-¦\æü\ÊRmõ¿\ç§Üºõ7S\ál·W\Òh\Ö:œW¾\'‡w™¦,L¨H\ê‰)\áœ`\äû¬\Õ\Â×­\Ùø\ã\Ãz‘¢^ZjZ\åÞŸ~\×i¦KI/’\ÐE,\ßu£GIH\Ú2wœ*g#\É+»\ZQ\åöƒ¿kw\×òETQV\å;?x\Ó\ÄZV±¯ëº´š†4“W–ö‚\î\âI\å\Ý\åA&HÃ»v;UU\ç8Vhøuu\â¯\Ýi¿\íu\Ï\ÛE\\‡µÑ¤[•R«¿Ì‚6—f\×m„†e$\"´¾ø\ãE\Ó|3­xc\Ä/©\ØX_\Ý\Ú\êV\ÚÆMucun%\Â\'’1\"²\Ì\à1\n¬	\ÚU½€þÔº¥¨ø–Û­X%õ¾Œ¶þ\"\Ô4\rj\îy¬ hZI\í.\ä1ƒ.ö}\Ë1t`>f\ÜkŽV¾Ÿ\×wòw\ÓK«XÁ^\Ïúþ´ë®·ò<\ïDý™<Wu…\ïu‹{Gñ—}©\Ú_=Œ¬«öx.&XŸpE\r\"Û–\\1ù_ž•\Çøw\á\Üþ%ð½\âY\ä’\çM\Ôl4\è´\ØmÌr÷B}»H9\0\n\î\ß\Ûú\æ—ûB\è:n±\á\ïI\â\n\×\\³y\à\Ó\à·óšð\Þ\É\r\Ò2Oû§]&\è\Õp¸b®\Ø\0\äxWö›Uð\ÍÆ‰ñCSñ/Ž\ì$\×t½@Z\ß\ê] ¶€\Ïö„Ir¬\âXð¶Yp\r-Û·—þ—ÿ\0\Èú[Ô©Y\'o?\Ëü\Ï;ÿ\0…;\ã\ïøI?\áÿ\0„ÄŸ\Ûÿ\0gû_öWöM\ÇÚ¼œ\ã\Íò¶nÙž7c­]s\àˆô\Ï\èž\'³\ÓuMR\Î\ê\Æk\ÍI \Ód1\é^]\Ô\Öûfd.|†l¶\Ür1\ÆkÕ¯þ?ø#W\Õ4K;ÛJ_\Ú\é¦jvi\àý>µ5kÖ¹­µ½\ÜKj\å\"X¤ó®y\Ük\Òþ>\èzlž¶Š\×V·\ÑtM^\Ó$Óƒ¬¨\Zø\Þyar\à:…ž\0\ìÀ\åžfMò]o¯\à¥o¿O?E»²»]4ÿ\0ƒ÷^\\m÷\ÃOø[H³_x¦\ëKñ&¡d—ö\Ú]Ž”.¢‚)cÚ¦3!ˆº•lG¥U”Ÿ˜•½Ç€<Qi\áX<O?†õx|7;l‹X’\ÆU³‘²W1]„\åHÀ=A®\Û\Ä~,ð\'\Ä\r7N\Õu\Ù|A¥xª\ÏM‡Ož\×N²‚{=C\ìð¬PI\æ´\È\Ö\ä¢\"¸\Ê2»‡]£¡\Ö>7xn\ãE½\ÔmYoj\Z±ð\Ìú=\Ä2·)™e—p\Â\ÝXDb]¯!;\Ûo\Íz]\ë\×ð\Öß§¥\î\ÒØ˜ý›ö\×\×KýÚ¿;Y=N1þ	ø‡Oøi©x¿W\Óõ=8n,\"±¶½Ó¤ˆjÜ¬\ÄK¶7(òG\Ýñ\È\Ç<·Š¼\â/\ßEe\â]Sðõ\ä±	£·\Õlä¶‘\ã$€\á]A+Fzpk\èyÿ\0i\é\Z¶©®\éi\âm_Q\Õ|_¦ø²m7WŽí­»J\Ò@’,®\\\æ@«!EùQAA·Ÿ.ø\ãñMñ\å\æž4}^\ëPÓ­¤¸’;kŸ\é\Ú\'\Ùü\ÖRx³vY˜\í‚œ¯“ˆm\ßoø\êýo®\Úi\Ðkôý_\ém7\×Éž_EU(¢Š\0÷¿†óÿ\0¶û=^øÿ\0 8?\ë\áôª?ÿ\0\æ%ÿ\0lÿ\0öz½ñþ@p\×\Âÿ\0\è-K¨mc\á	x’÷C¶“Xš~ÿ\0X†\Î\ê\Æwc’”g·T‰•vû\Éwn\ÎkCLø3\áû\Í\Z;“\âˆnw¦¨\Í{l\'[h~\ÍN\Õ\íÄ‡™\íª\Ù\Û\Îkƒ\Öü_¯Cp–\ëZŠXX\Üý¢\Ò\Õn\ä[\Ê	mñ®p–\'#$ú\Ö~•\â\íwBxŸMÖµ\r=\ágx\Ú\Ö\êHŠ3€¤`°UŽ»FzW,©Í·i[s²i&¹¡}¿\àõ;½sA¼ø#™wo4WZž©igr\Ù/n\ÐÈ\ãVŽP\ß7CŒŒUß…¾2»ñ÷\Ç-õ˜#¸´ñœÉ¢\êv±&P\Ç1X\Õ\Ô1$4n#•[9\r>µ\åÚž¹©kLQ\Ô.¯\Ø;\È\r\Ô\Í!\çs·\ÌO,y\'¹\ë[>ñ±ð¡{ªZ\Ù-Æ°m$·°º’B\ÊIÆœ(3„.ˆnvZS½\é\ê\ì\×Ë±jœ×…-#{¯\'¢¹k\Ã>\Ó\ï¬üb/,u\íN\ãK²im.48[xdYUL·d‚V\r»¾aƒ¸­qõ\ÕxS\â6£\à¿ø‡L\Ò\íí¡›\\µ67ZƒLÿ\0ebÂ«¿\Ë\Ú\ÅFIB\Ã0®V¯ªôüuÿ\0€d\í«J\Úþ\ZQLAEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEP¾\é?òI,¿\ëŠ\èÁIðÿ\0\â£ð\ßY›S\Ó!µžym\ÚÙ–\í—iel¬§9A\ßÖ—Iÿ\0’Ieÿ\0\\Sÿ\0F\n\å\ë\ÏÀ\Ë\ïñ\Ëô1§ö½FüNñ]ßü]q­\ßGWWQÇ½-Ôª\rª`OE\ëŠÕ¿\ãðÿ\0\×8ÿ\0ô­½wþ>£ÿ\0®cùš\ÄÕ¿\ãðÿ\0\×8ÿ\0ô¯U\ìl]ð¯ü„$ÿ\0®GùŠê«•ð¯ü„$ÿ\0®GùŠ\ê© \"ºÿ\0Yÿ\0\ë›#\\½u_ñ\ë?ýso\äk—ª\0¢Š)\0QEcOÿ\0‘þ\ãÿ\0\è&¬U}?þ>Gûÿ\0 š±S \n\áë¸® 	¬\Ë\È\nÀ.[z\â‰~\é\0\ä\ç§\×U\â[\è´û.;‹->Mn\ÔIöÄ†\ÝbvŒ‘…Vt\äž\É\n\ÙÁ\É\Û]Mgqöò\Éñ°d’6*\ÊGB\èkN_k\×O.·©I<ŒR5Ü…£\ÈÁ\Ús\ÆG\ÓN¤a=\ïý|\Î:Ô¥R¤d’²¿Vº[¶\ßðC´þË±‹Åž1”%¨±;¢ó\í\ÖH`C*«¸‹X€v…\Æ2\ã§Q\Ì|@´³µñl¢kx¦¶†v…!Fx\Ã¨\ás\ÛGv³\äñV·5ôW¯¬_½\ìJR;†ºs\")\êg r:Ï¸¸–ò\âI\ç•\çšF,òHÅ™˜õ$ž¦ª­XJ\n]\Ïüÿ\0º[›…«J¢œ\å}-ø%ú_\ç\ëx\êÞÿ\0!{ú\îŸúª•oGÿ\0µ—ýwOýW¾zc×¾=\È#Jÿ\0®\íÿ\0 \×¦ÿ\0\É\'ñý†ô¿ý¨WqñÙ¤:N—½~\Ø\Ú\Äÿ\0\ÐW1\á4›†^&]föö\Â\×ûcL+%š\\¹&ÿ\0\0«K\çq\è8\ç#\Ì\Êÿ\0\Ýcóü\Ìhü§\É\å\Újkö/µo·\æ\í\ÏÙ¿{ó:g;¬\ë\ØÑ­.;·±\Ö\r´«)j­r¬9xüø€ƒ\Îò‡·\0ó\Ø\çWªnQE\0^\Ö$ón\ão±}ƒýò¶\ãv\"A\ætÿ\0\à}OZ£Z:ôwq_D/eY¦û-³+ \àF`C\è9Tpy=k:€\n½§\É\å\Újkö/µo·\æ\í\ÏÙ¿{ó:g;¬\ë\ØÑ­.;·±\Ö\r´«)j­r¬9xüø€ƒ\Îò‡·\0óØ€gQE\0QE\0QE{O“Ë´\Ô\×\ì_j\ßn\ÍÛŸ³~ö3\æt8\Î6vÿ\0Y×±£Z:\\woc¬iV8R\ÕZ\åXrñùñ\0\ån\ç±Î Ÿoq-¥\ÄsÁ#\Ã4l$Š²09ÐƒÞ™O·h–\â3:<†\Ò7Ì¹\ä \à\ã¾\Ð\Ó[‰\ìz\ÇY$Ö§ð·ˆ¯\ï\Ä\ÚÞ©¢Y½\ì7%ž\îFX‚™Œ$\n%ü\Î	u\\‚|¶ºˆž2·ñ®¹mqe§>•¦\ÙX\ÛiÖ–³\\}¢EŠ\Âò@\ì\Ä$*›\0\0+—©[\É÷oî¾…tK\É~AESQE\0QE\0QE\0QE\0QE\0U\ËõRÿ\0¼¿Ö©\×Kð÷\ì?ð–h\ßÚžWögö¯Ú¼\ïõ~W™ó\îöÛœ\Õ\Â<\ÒQ\î4®\ìV“J½‡OŠý\ì\î\ÆW1\Çt\Ñ0‰\ØuP\ØÁ#Òª\×\Ð\ZE®¥±e¬\ëVS‹Û¦´\Ô\í.\æS¦Ág‰šAü&2³~\éAÀ)ò–$óývb0ê¬÷þ¿_‘­J|–4ü;\ác\Åú´:^…¥_kzœÁŒvZu³\ÜL\àN\Ô@X\àNAMñ‡u_	\ê\Ó\éZÞ™y£jvøYj\ï\Ñ\ä‘ÀaA\ät\"½O\á—y\âO…¾8\Ðü;kq©xž\î÷Nyt½4ÿ\0§\ß\é‹\çˆ \038}\ÙU[…AT8õý\à‚W\Ä^([\Í\Å.Ô´½?Ddð¬\ÑI«jvI=¾\ë„xmç±˜EG\î£9y\Z³þºöüŸšf	\è\ßõÿ\0\×\Ò\ß/”ü1\áw\ÆÚŸöo‡t]G_\Ôv~É¥\ÚIs.ÁŒ¶\Ä\àdsŽõcÅ¿üQ\à­\áñ?†õMp¥\áV±–Õ¥PpJ‰dGJö¯\Ú\n\ÞøWð»û7Á\Òi:Eš\ßX.§s\Ò\ÜE$z…\Ðû,û¥h’b J\è\à\Ä\íÚ˜Q\Òx\ã\áþñ+\ã—\Å+K\Ñ\rþ‹\âG\Õ\ï¯^\áË£©ax gnô\"6\\\0N÷\É\àT¶´¶\×rk_¹\Ýù\'¾…Irùÿ\0_æ¬¼ß©ò•õnð§Âš÷\Ã\ïx~ý“B\Ö4gP\ÔüJ·÷­Š\Ð\Ïv-U˜c\rû¸£Ä¡ü\Ü(Ps6\ÅO…¾ð\ÇÀý#SÑ¼/\âË™ô\Ý>õ|_o¦\Êú|“J\íKwöÆ„vx\Äb\Ú7WAfä²“\å½ú4¾ö\×þ\Úÿ\0@J\î\Ë\Ïð·ùŸ7\ÑEB\n(¢€\n(¢€\n(¢€=\ï\áŸüÄ¿\íŸþ\ÏW¾#\Èúø_ýª\Ã?ù‰\Û?ýž¯|Fÿ\0õð¿úR\ê\Îzÿ\0ü†nÿ\0ßª_ÿ\0\Í\ßûõB“\ÜŠ(¤EPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEP¾\é?òI,¿\ëŠ\èÁ\\½u\ZOü’K/ú\âŸú0UÏ…?\ágxŠ\ãKþ\Ðþ\ÍòmZ\ç\Íò<\Ü\á\Ñv\ãrÿ\09\Ïjóðòûürýiý¯S\Ëõ\ßøúþ¹\ækVÿ\0\Ãÿ\0\\\ãÿ\0\Ð»\ï‹þÿ\0„\ÇWš\Úþ\ÝöX\ãÿ\0Hòü½Û?\Ý\É\Æ7c¯j\àuoøü?õ\Î?ýk\Õ{|+ÿ\0!	?\ë‘þbºª\å|+ÿ\0!	?\ë‘þbºªH®¿\ã\Öú\æ\ß\È\×/]E\×üz\Ïÿ\0\\\Ûù\Z\å\ê€(¢Š@QE\0X\Óÿ\0\ã\ä¸ÿ\0ú	«_Oÿ\0‘þ\ãÿ\0\è&¬T\È¸z\î+‡¨k2\Âò°–Þ¸…\"CŸº@99\é\Ç5\Õx–ú->\ãKŽ\â\ËO“[µ}±!·D…XŸÝ£$aU9\'‚2B¶pErv\×SY\ÜG=¼²A<l$Š²‘Ð‚:\ZÓ—\Æ\Zõ\Å\ÄË­\êROcw!hò0vœñ‘Á\ÅtÓ©F\Ï{ÿ\0_3Žµ)T©$¬¯Õ®–\í·ü\Ð\éJZ\Ù|^’\Õtû9m¤Ô–ƒj\Ò(;S\îô\È\ä32V ¡/\îU@U°\0É­øL5\ï¶¿\í½K\íB?(Oö¹7\ì\Îv\î\ÎqžqT5\rJ\ïVºk›Û©¯.\0f¸»œp9\'4ªN2ŠQ\è\ß\ãoòüH\ÃÑ©NI\ÏùR\Ý\î¾Ez·£ÿ\0\È^\Çþ»§þ„*¥Mcp-om\ç#pŽEr|\×,µM\ç±üzÿ\0F•ÿ\0]\Ûÿ\0A®Mÿ\0’O\â?û\r\éú#P«\ß>\"[ø\Ö\Ê\Î,\å¶0H\\™\äcµQ\Ó\ä“øþ\Ãz_þˆ\Ô+ƒ/§:8u	«=L©E\Æ6g9g£\Û\ß™Z9’\ÖÊ£‡“\Ì@A\àñ°\È{r=Z½§\É\å\Újkö/µo·\æ\í\ÏÙ¿{ó:g;¬\ë\ØÑ¯D\Ô(¢Š\0µ©Gi\Â)Zh|˜™™\Ç\"C\Z™AÀrÀ{\É\ëUjö±\'›w}‹\ì\èð/•·±3 ûø\ßÿ\0\êz\Õ\Z\0*Õœvo|neh\æHC[*ŽO1ƒ\Æ\Ã!\í\Èö5jöŸ\'—i©¯Ø¾Õ¾\Ü/›·?fý\ìg\Ì\èqœl\íþ³¯bFŠ( Š( Š( Vq\Ú=½ñ¹•£™!\rlª8y<\Ä‡· s\ØÕ«Vw‘\Û[\ßG%²\Î\×ˆ£‘±˜XH¼q\×\nW·~†­\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0r\ÇýT¿\ï/õªu»\à\Ý¼G®\éúJJ {û\È-VV]¶\äŽø\ÍTS“I\r+»!$\Õof\Ó\â°{Ë‡±‰Ì‘Ú´¬bF=X.p	õªµ\êú4\rvö\ÓI·‰¬\ì\î\æ\Ö>#k­\ís;´=0K/È 4{f ŒùEuV£:vrw¿õýt\ì\\\â\ãk…\ï_³—\Ã{/øG\Åwc\ÂZ/‹µ\Ë]OJ³³´\×5il#\Ù?\Ú|\ÑŽ\æ\rò-6¨.\Çjži–?³§ñ>óÅº\ï\ÃÁ$þµ\Õn­4‰.\í/$–\éc\Â±|\ßpaRXrm¼\Ò÷O¢¿\åÿ\0\É~}Œ\ã\ïmýoþG„WI¢ø\âøWX\Ñ\ìtû(§\ÕTCs«~ô\ÝýŸr±·_\ÞyjŒÈ¤›\Î1»i+]ô³6©ý–/.<_\á[2šE®¿sm5\ÕÁš\ÓOc+< aÁ•Æ¥¤\É#)V5.?gOM\Ô5qªø›ÃºF‰§%‹]Ir\ÖW_l‹Í¶ˆ\ày˜¼a›˜ÀP»iÀ#[\Åú~6ü^žn\ëº\ÒK\×þâŸ•\Ó\ìq ñ¥÷‰<?\á\æ+t¶ðý¬¶–­°wI\'’v.KN\éXÀù<ýz}÷\ì÷\âM/]Ó´»»\Í.	.®¯­%¸ûC4mh‚I\ÚWT?(‰’PSvQ\Ç|g\Å_³?Œ|ð\Æ\Û\Ç\ZŒHºd\Ð\Û\\´\"\Ú\ì4pÏ%\Ì\Í·|\îL¤r³®ñ¹Fjº·?\×üõ^_\ëC\Éè¢Šb\n(¢€\n(¢€\n(¢€=\ï\áŸüÄ¿\íŸþ\ÏW¾#\Èúø_ý«œðˆ\í¼?ö¿´$¯\çl\Û\å\0zn\ÎrG­Yñg‹-5\í:;{x\æGYD„È \0Gb}h\ê†\ëÿ\0ò»ÿ\0~¨UýþC7\ï\Õ\n—¸QHŠ( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( j\Ò|Aoÿ\0\nú\ËK\Ù/\Ú<”ù°6}\à\Ýsžž\Õ/…<e¬x#Q’ûD¼ûÔ‘\ZO)$\ÊŒ8#ªÊ±ôóþ›+ÿ\0\'ý\ÉO\Þn_e\éœõ¦\Öt!J\Þ\Í\Þ\í·\ëÔˆ¤¯b¯¼C¨x«\ÄRjš¥\ÇÚ¯\î#_2]Š›¶£…\0j\äµoøü?õ\Î?ýko]ÿ\0¨ÿ\0\ë˜þf±5oøü?õ\Î?ýk¥–]ð¯ü„$ÿ\0®GùŠê«•ð¯ü„$ÿ\0®GùŠ\ê© \"ºÿ\0Yÿ\0\ë›#\\½u_ñ\ë?ýso\äk—ª\0¢Š)\0QEcOÿ\0‘þ\ãÿ\0\è&¬U}?þ>Gûÿ\0 š±S \n\áë¸® 	¬\Ë\È\nÀ.[z\â‰~\é\0\ä\ç§\×U\â[\è´û.;‹->Mn\ÔIöÄ†\ÝbvŒ‘…Vt\äž\É\n\ÙÁ\É\Û]Mgqöò\Éñ°d’6*\ÊGB\èkN_k\×O.·©I<ŒR5Ü…£\ÈÁ\Ús\ÆG\ÓN¤a=\ïý|\Î:Ô¥R¤d’²¿Vº[¶\ßðC{S³ž?ˆ\ÚÍ¶•adYe“hž\Ì\èYÊ°Øª\0<°À\×`xª\æ\Æó\Ä’é±¬vl\Ão–›ˆP•p6©l00)\ßð™kÿ\0jûWö\æ¥öž_ö¹7\ì\Îv\î\ÎqžqYú†¥w«]5\Í\í\Ô×—\03\\H]\Î8“š*TŒ£h÷þ¿¯ò3\ÃÐ©NQs¶‘¶\ï\Ë}<´\í¯r½Q\\Ç \Ö\é¿òIüGÿ\0a½/ÿ\0Dj\ÉW}\á4›†^&]föö\Â\×ûcL+%š\\¹&ÿ\0\0«K\çq\è8\ç ’\Ò\ã»{`\ÛJ±Â–ª\×*Ã—Ïˆ\08<\ï({p=ŽuZ³Ž\Ñ\í\ïÌ­\ÉkeQ\Ã\É\æ  ðx\Ød=¹žÆ­\0QE\0h\ë\Ñ\Ý\Å}½•f›\ì¶Ì¬ƒc \ä!P}Á\äõ¬êµ©Gi\Â)Zh|˜™™\Ç\"C\Z™AÀrÀ{\É\ëUh\0­.;·±\Ö\r´«)j­r¬9xüø€ƒ\Îò‡·\0ó\Ø\çU«8\í\Þø\Ü\Ê\ÑÌ†¶U<žb†CÛ9\ì@*\ÑE\0QE\0QE\êï®µ\r7\Æ\Þ¸\Ô$¶ðýþ‹,÷\"wf³¶–9\"hî¥Œe‰B\0\Ý\Z<Ÿ>H¯.‘Dr:«¬Š¤€\ëœ7¸\ÈQ]W„¼ge\á_xš\Õ4¹®ub\Ïû>;\æ»¼\r$o\'\î|¼»Ÿ/¼À\0cò“‚9:%¬¯\ä¾û¿\Ò\ßð\Ö\é¼\ß\ä¿[ÿ\0W\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n\Ô\Ðu&\ê;\ÛILV\ÓG42¯Tu$©Be\Õý..I†\ÚYd‘#E%™Ž@\0¤š¨\Þú\ÐôñXC¤\ÙGc XX\êÖ·2Ý¥üy)’,J^8OÊû• ò\ÉU^1À\×W/\Ã]^8­n58Áy´˜&wŽ\å\0Á#œª’Ë™Er•\ÕY\Õvö¿\×üýM\'Ï§1\Òhž>\Ôü?\á=[@²ò¢·\Ôol\ï\Þ\än\Å-·›\å˜\Ø0ýsO‚;ö\Z—\Ç\ëZ\êVš\çƒ</­Y^_¾«´\Ñ]À¶—rF©<°˜.#a\æ\ìFdbÉ¹AU^•‹ðÿ\0\áSø\ëC\Öu™üM¢xcK\Ò\î-m%¹\Ö~\ÔC\Ëq\æùj¢%?ò\ÅòX\08\æ¹\ÏxWPð?Šuoj±¬Z–—u%¥Â£]\è\ÅN\ê8\à÷\Í-\í.¿\åÓ—ð2]\×Oø?ð¨»øÑ­\Þjoµ\Ó\Çö‡‡-|1.\Øß‹X<Ž¿?ú\Ãöd\É9¶q8h\rRhe³\Õü= ø‡H–\ËN´m/PŽ\åa\Ýc“o8h§I†\Ã\ím\í•\é-¢\Û\ßúÕ¿Í·\ê-ýt_¢ûE“\ãÇŠn4\Z\ØO%¬ÿ\0ð–N·—\rY``N\á\Ò5u>[.(Œ\n§\âÏŠ\ã_\ÙYj¾\Z\Ñ&\Ö---\ìS\Äq‹¨\ïš@X\Õ\Õg1ªÇ¸Å¸ªŒœŒ\×\r[\rð½×Ž<]¢xv\ÆHa½Õ¯a°‚K†+\Z\É+„R\ÄB\å†p	\ÇcIGš\Ñ^_†ˆ¹o/_\Ç\ÈÇ¢»Ÿü)¹ð.•aªÅ®\é%\Òo.®,E\îŽnEs\Ã$.³\Ã†D \í*CpN8j”ÔµCi­ÂŠ(ªQE\0QE\ètQEPs¯ÿ\0\Èf\ïýú¡Wõÿ\0ù\Ýÿ\0¿T+7¸QHŠ( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( }\Ò\ä’Y\×ÿ\0Ñ‚¹z\ê4Ÿù$–_õ\Å?ô`®^¼ü¿þ_Ž_¡?µ\êa\ë¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -m\ë¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -z¬Ø»\á_ùIÿ\0\\ó\ÕW+\á_ùIÿ\0\\ó\ÕR@Euÿ\0³ÿ\0\×6þF¹z\ê.¿\ã\Öú\æ\ß\È\×/TER\0¢Š(ÆŸÿ\0#ý\Çÿ\0\ÐMXªúü|÷ÿ\0A5b¦@\Ã\×q\\=@Y–€\\¶õ\Ä,	ý\Ò\É\ÏN9®«Ä·\Ñi÷\Z\\wZ|šÝ¨“\í‰\rº$*\Äþ\í#\n¬\é\É<’³‚+“¶ºš\Î\â9\í\å’	\ã`\É$lU”Ž„\ÐÖœ¾0×®. ž]oR’x¤k¹G‘ƒ´çŒŽ+¦H\Â6{\ßúùœu©J¥H\É%e~­t·m¿\à>†Æ¹5®‹ñVa´´Y\äM©§\Ãr¨;ŠL\'\\z`g\éY\Þ9¶Š\×\Ä÷bb·†EŽdŽ…\nñ«—i\ç%z)$\0¨?\á0×¾\Ø.ÿ\0¶õ/µü¡?\Ú\äß³9Û»9\Æy\Åe\Í4—<²»K,ŒY\Ý\É,Äœ’I\êiN¤eU\Þÿ\0\×ô¾ft(Nœ£)t½v\×e\Û\Ï\åÕ”QEsž€W[¦ÿ\0\É\'ñý†ô¿ý¨W%]n›ÿ\0$Ÿ\Äö\Òÿ\0ôF¡@\Z|ž]¦¦¿bûVûp¾n\Üý›÷±Ÿ3¡\Æq³·úÎ½\Z\Ñ\Ò\ã»{`\ÛJ±Â–ª\×*Ã—Ïˆ\08<\ï({p=Žu\0QE\0^\Ö$ón\ão±}ƒýò¶\ãv\"A\ætÿ\0\à}OZ£Z:ôwq_D/eY¦û-³+ \àF`C\è9Tpy=k:€\n½§\É\å\Újkö/µo·\æ\í\ÏÙ¿{ó:g;¬\ë\ØÑ©\íï¦µ†\ê(Ÿj\\\Æ\"”`\Ê_\ß2)\ãÒ€ ¢Š(Q\Ú7WF*\ÊrN>µ\ê?-\á\×o<\â™\ád¼ñN–—Z”6¨’\ÜGq-´“*\Òù\"Owv=\ë\Ë\â(²!‘Y\ã\ÈÜª\ÛIÀ88?®¿ÄŸ¿\á#ñ–±.‹ft½>(­,t9e›È†\Ú%\Äq\ÒBz³:²–vf\ã8«V÷o\ßð³¿ß§\Ý\èK½¥nßõýj\Ê?´[/ø\ãY\Ót\ë\rkL°·œ¤ž#…a\Ô\"L\è \0üö\ÎV\ïŽ|kªüEñn§\âMne¸\Õ5	|ÙWjðª\è\03“\Ç$žk\n²ùU÷4•®\ìQEQ!EPEPEPEPEPEPEPEP]€õ˜ü;\âm+Vš6–+û{§1¹•q=ð+«º~<¹rH^ƒ>µq“Œ”—A§gs\Ûô½sHð\Üz\'‰‰,\ï.`\Ô^iä·‡\Z…\Ü(!h\ât<¡fóƒ¹lüR`\nñZ~û\Íÿ\0|ÿ\0õ\è\Ây¿\ïŸþ½tÖ®\ëYZ\Ö4N{\Ãð_\ã‡\Â\ßx¢9m´\ÝSR»\Õô›˜ô­SOK¨®­\áûW‚\è\Ë20q»*x5\êø\Ç\á_x_\Å:N…\â\í\êú÷Z¹½¸Ô¼[¶?¶l\çG7\Ø\Ïï¤¼\Õx\îQ£-!d$3g\ä\ì\'÷›þùÿ\0\ëÑ„þó\ß?ýzæ—¿\Í~ª\ßúOÿ\0\"¿(û­Itÿ\0ƒþÕ§§ý¥…¦—©\é\Úw‹.­¬­ü¥\Ùi0Á‘ˆu˜V\Ñ$’< \Ù:ª\Ü(¸\à\í\0\Æ\ÑS·\Æ\Í#V¹\×n´ˆ-\àŸ\ê\Ú~%Ï‹^\Åy\ä‚\Óeý»Io\Ì\æ1¹!vHa;›¡?-a?¼\ß÷\Ïÿ\0^Œ\'÷›þùÿ\0\ë\Õ7v\åÕ»þ-þ¿rBZG—\Êß‚_§\Þ\Ùô†§ñ\Ë\ÂzŒ\Þ$\×\í\åš\Ç[\ÐuËŸÛ­·—\æ­\â\ìw!T¤>L€Üªd\rò0\×]cûAx]tß†p[\ë:‡‡t‹k\Ý\"\âeµ)­¦Œ\Ü\Í`½ŽX¬²,Ž²0 ¹9ù	ý\æÿ\0¾úôa?¼\ß÷\Ïÿ\0^¦>\å­Ó•ÿ\0\à?\ç\Ô$¹¯~·_õ¡ôž“ñk\Âþ+ñ†µ\íg\ÄQøWQ\Ð\îµ\âµ\Ò\í®t\ë9™\Ñä¶¼aa\Z´[Ÿd3˜B\ÊÈ‘‘\Î\æ]þ\ÒV+\ã]CÁþ,kOj‡Ã»u\r%/\"i\Þ\Ú\Út»dš\à±¹‘KJû\äV9,\nùW	ý\æÿ\0¾úôa?¼\ß÷\Ïÿ\0^ˆû‰%\Òßƒ¿\ã\×ô-¾g&úÿ\0ÿ\0\íß…ÿ\0´|k†\ÓÁ1_\Ç{ñmV\çOƒN¹_±\ÄÑ®=»c)9)9EA)u\ä^©|hÐ›\à]Ç†4}O\Ãö´:Œ:¦—«&®&¾™\î^H®![rl\ä}W¹P\è\Ñv…Ç\èŸ<Q\áûE\ÑüS­\éZ5þ\áw§\Ø\ßK\r½\Æ\å\Ú\Þdj\á_+òœƒ‘\Ås\ØO\ï7ýóÿ\0×¨q\\ª-oÁ/\Óþ¶½î·¿\â\ß\ëÿ\0Œ¢Ÿ„þó\ß?ýz0Ÿ\Þoû\çÿ\0¯VH\Ê)øO\ï7ýóÿ\0×£	ý\æÿ\0¾úô\ì\ÞñU—…µ¡&§¤Zk:l\ØYá¸·IG÷\ã,8až¡\ìFŸ\Åh\Þ\"Ô…¯‡´{7J·o–\âDŠ[–é¸è¿‰\ç|Ÿþ\Äÿ\0Ÿvÿ\0¾¿ú\Ô\ÂXŸó\î\ß÷\×ÿ\0Zž€s\Zÿ\0ü†nÿ\0ßªsW›\í\Z”ò€\ä6=2ªuŠ(¤EPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEPEP\Ú\ß~k_³n\ã\é¦\Ó%\ÐZm]Ý§?\é&ºSo\ß\ç\ït÷\â¹-sÂ±\ê\ZM\Ä:noö\Â¦\ÄD?xg“ŽÙ¯¤¾þ\Ò6ºo\ì{\á­2\Û\Ä^_,\ìbµ‚/°“²8\î6\"\ä\Ç\å[¨\'\'ü\Õ\æ_>=x·[ðë®½ý¯go\"Ì–þL0|ÿ\0p6\ä@x\Üt\æ¾sS\ìñ.1÷•IY>»[±\ée´°3\ÅÓ†6n4›÷šÕ¯M\äÏ•<_¦\Ü\é\ZÁ´»Ê¸Ž5Ü›ƒc9#qÐŠ\æµoøü?õ\Î?ýk®øƒ­\ÂA\âIu\'\ìþtiû½Û±·®¥r:·ü~ú\çþ€µôt\Ü\Ý8ºŠÒ²¿¯Sdpð\ÅUŽNT”Ÿ+{¸\ßFôZµ\ä½wÂ¿ò“þ¹\æ+ª®WÂ¿ò“þ¹\æ+ª­\ÆEuÿ\0³ÿ\0\×6þF¹z\ê.¿\ã\Öú\æ\ß\È\×/TER\0¢Š(ÆŸÿ\0#ý\Çÿ\0\ÐMXªúü|÷ÿ\0A5b¦@\Ã\×q\\=@Y–€\\¶õ\Ä,	ý\Ò\É\ÏN9®«Ä·\Ñi÷\Z\\wZ|šÝ¨“\í‰\rº$*\Äþ\í#\n¬\é\É<’³‚+“¶ºš\Î\â9\í\å’	\ã`\É$lU”Ž„\ÐÖœ¾0×®. ž]oR’x¤k¹G‘ƒ´çŒŽ+¦H\Â6{\ßúùœu©J¥H\É%e~­t·m¿\à>‡Qs¡Y\É\ã\í~B–\Û\Ø\Ì\Í\r„\×[$®N@vQ°H†;\Ö\'\Ä]5t¯\êÆ–ñDffŽ;gBˆ¤ð0‡\n\Ù\àJ\ÇÔµ­CZ™%\Ô/®o\åAµ^\æf‘”uÀ,NW¸¹šòwšy^y¤;žI³1õ$õ¢¥HJ<±]Lha\êÓœg9^Ñµµòÿ\0\'\Òú‘\ÑE\ÌzA]n›ÿ\0$Ÿ\Äö\Òÿ\0ôF¡\\•w\ÞƒI¸øe\âe\Öool-¶4Â²XÙ¥Ë—òoð\n´±€1žwƒŽr\08»8\í\Þø\Ü\Ê\ÑÌ†¶U<žb†CÛ9\ìj\Õ\í>O.\ÓS_±}«}¸_7n~\Íû\ØÏ™\Ð\ã8\Ù\Ûýg^Æ\0QE\0ZÔ£´Š\á”­4>LL\Ì\ã‘!Lƒ \à9`=€\äõªµkR¼Žú\á$Š\ÙmUaŠ#\Zc’5F~\0åŠ–>\ìzõª´\0W©ü¾º\Ô4\ßxf\ãP’\Û\Ã÷ú,³Ü‰Ýš\Î\ÚXä‰£º–1–%thò|ø\nA\"¼²º\Ï	x\Î\ËÂ¾ñ5ªis\\\ë\ZÅŸö|w\Ívx\ZH\ÞO\Üùyw>^y€\0\Ç\å\'\á’\îŸ\å§\ãý\\>\Ô_šüõ9YG#ªºÈªH¹\Ã{Œ€qõ\Ú( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( Š( ®Xÿ\0ª—ý\åþµN®Xÿ\0ª—ý\åþ´\ÐW¤\Éð\Ä:Â”ø«]iº;b\Ê\ÛP™\Ö\îû?t\Ã\Z£d7$n+Â–û¸cŸðƒ\á½ñŸÅ‘hº,[Qp÷w\Ò)ò­b\Ï.\Ç\×\Ñz“ø‘õßhÏ„\ßô\Ý+À÷:=Ï/<!Y\\y0›qsaKeH\Ú7F=	¦ÁóÁ%¬\ÒC4mÑ±GŽE*\ÊÀ\à‚B\rGZ~(ñÏ‹|M«k—«\Z^jws^Ì°‚<Ž]‚‚I,q’k2˜–¾	\×o4“©C¦\Í%¦\Ò\êF7º¼\è™\Ü\È;²‚r+½\ãX‰üA{«ø\Ò\Â\çL&F!§\ê¯q\å\Çmn\Âf_6>¢H„q(]¼\î?+\ä\Zò\Z\ê6ºÇŒµ\ëûøòº¿¸ž—o\î\ÚFe\ã·q]øœ<h¤\â÷ü|ÿ\0«ú)¨+£Š(®œ(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0©}ÿ\0ý\Õÿ\0\ÐEAS\ß\ÇÁÿ\0uôPT\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QEô\Ï\Ã?ùôoú\ãýMhx\ÛþE‹\ßøþ†µÀ|4\Õ-tŸ\"k¹|¨\Ú\ÉP6\Òyù8Æº¯x£L\Ôt+›{{Ÿ2gÛµ|¶\Ãy#\ÐW=\nÁ\Ë[ó6þò#[ùžI®ÿ\0\Ç\Ôõ\Ì3Xš·ü~ú\çþ€µ·®ÿ\0\Ç\Ôõ\Ì3Xš·ü~ú\çþ€µ\Ú\Ë.øWþB\×#ü\Å{w…~jþ2\Ña\Ôô\ÍWH–\ÞNZiC\Ä\ãª8òøaŸ\ÔA¯ð¯ü„$ÿ\0®GùŠ\ît\í{Q\Ò-oí¬¯&¶·¾‹É¹Ž6À•3œ\Ô}„‚€­\â=t«‹ûE¼·¿«\'\Ú-š\'8\çi dgŒ\ãd`\×]E\×üz\Ïÿ\0\\\Ûù\Z\å\ê€(¢Š@QE\0X\Óÿ\0\ã\ä¸ÿ\0ú	«_Oÿ\0‘þ\ãÿ\0\è&¬T\È¸z\î+‡¨k2\Âò°–Þ¸…\"CŸº@99\é\Ç5\Õx–ú->\ãKŽ\â\ËO“[µ}±!·D…XŸÝ£$aU9\'‚2B¶pErv\×SY\ÜG=¼²A<l$Š²‘Ð‚:\ZÓ—\Æ\Zõ\Å\ÄË­\êROcw!hò0vœñ‘Á\ÅtÓ©F\Ï{ÿ\0_3Žµ)T©$¬¯Õ®–\í·ü\Ð\éoo´¯ø÷Ä‰smP7™\r¿•a\r\ÂÀûÔ‚\"r=³\\ïŒ´\ÙtŸ\Ý\Û\Ë$R·\É h`XV@Ë˜\Ô\0‡eGCž½j3\âýy¯ð\ëz‰»Tò„ÿ\0k“\Ì	œ\íÝœ\ã<\â³&šK‰žY]¥–F,\î\ä–bNI$õ4T©G•[ÿ\0™–:RR“û6}nôòº\Ûo1”QEsˆW[¦ÿ\0\É\'ñý†ô¿ý¨W%]÷„ \Òn>x™u›\Û\Û_\í0¬–6ir\åü›ü­,`gÇ ãœ€KKŽ\í\ìuƒm*\Ç\nZ«\\«^?> \0\àó¼¡\íÀ<ö9\Õ=¿Ù¼›¯?\Íó|±ö/w\ï\\\ï\Ïð\ì\ßÓœ\ííš‚€\n}½Ä¶—\ÏÑ°t’6*\ÈÀ\äGBze>Ý¢[ˆ\Ì\èòBH\Ü#2\çƒƒŽø?CMn\'±\éÿ\0d“ZŸ\Â\Þ\"¿¿kz¦‰f÷°Ü–{¹b.dp\n0( —ó8%\Õr	ò\Ú\ê>\"x\Ê\ßÆº\åµÅ–œúV›ecm§ZZ\Íqö‰(c\È³Xª>l\0\0®^¥o\'Ý¿ºú\Ñ/%ùQLAEPEPEPEPEPEPEPEPEPEPEPEPW,\ÕKþòÿ\0Z§REpð\ä!\0¹\0ÿ\0:`v¾ø™\â\0\Øk6~\Ö\'Ò­õˆ–Õ€.eEÝŒ1R77*Aù5\ÌUO·M\ê¿÷\Âÿ\0…n›\Õ\ï…ÿ\0\nw\ÝS\í\Óz¯ýð¿\áGÛ¦õ_û\áÂ‹nŠ©ö\é½Wþø_ð£\í\Óz¯ýð¿\áEÀ·ETûtÞ«ÿ\0|/øQö\é½Wþø_ð¢\à[¢ª}ºoUÿ\0¾ü(ûtÞ«ÿ\0|/øQp-\ÑU>\Ý7ªÿ\0\ßþ}ºoUÿ\0¾ü(¸èªŸn›\Õ\ï…ÿ\0\n>\Ý7ªÿ\0\ßþ\\tUO·M\ê¿÷\Âÿ\0…n›\Õ\ï…ÿ\0\n.º*§Û¦õ_û\áÂ·M\ê¿÷\Âÿ\0…\0¾ÿ\0ƒþ\êÿ\0\è\" §I#J\å˜å¶)µ QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0zV“ÿ\0 «/ú\âŸú«uSIÿ\0U—ýqOýUº\Ô=wþ>£ÿ\0®cùš×µÿ\0X?\ëšÿ\0!Y\Z\ïü}Gÿ\0\\\Çó5¯kÿ\0°\×5þB˜õ\ÏøôO÷\Çò5‡[š\çüz\'û\ãù\ZÃ¤ÖŸ\ë[þ¹¿þ€j\Zš\Óýk\×7ÿ\0\Ð\rCLŠ(¤EP?þ>Gûÿ\0 š±Uôÿ\0øù\î?þ‚j\ÅL€+‡®\â¸z€&³,/ +\0¹m\ëˆX$9û¤“žœs]W‰o¢\Ó\î4¸\î,´ù5»Q\'\ÛtHU‰ý\Ú2FYÓ’x#$+gW\'mu5\Äs\Û\Ë$\ÆÁ’HØ«)#¡­9|a¯\\\\A<ºÞ¥$ð1H\×r#i\ÏWM:‘„l÷¿õó8\ëR•J‘’J\ÊýZ\én\ÛÀ}¶]7L·ñ§‹¦š(¡ƒOV’\Ò\ÙeD&T\\ˆxVÀc…8\\\ã<q\\§‹¬\Þ\ËZ}\Ò$‚h¢-–\Û\åtV\\Ä¿*8\ÏsÖ¢“\ÅZ\Ü\×\Ñ^¾±~÷±)H\î\Z\éÌˆ§¨\rœ\Éü\ë>\ê\êkÛ‰\'¸šIç‘·<²±fb{’y&J”Tb¿­\à}\ßv8|=ZSRœ¯¢_—•ú_ç¶—#¢Š+”ô‚º\Ý7þI?ˆÿ\0\ì7¥ÿ\0\èB¹*\ë|/«h_ð‰\ë:&·u¨\Øýªú\Îò\ì,£ºÿ\0S\Ê2²¼\Ñ\ã>x ‚~\é\â€:o‚w\×Z†›\ão\Üj[x~ÿ\0E–{‘;³Y\ÛK‘4wR\Æ2Ä¡\0nOŸH$W—H¢9U\ÖER@u\Î\Üd¨®«\Â^3²ð¯‡<Mjš\\\×:Æ±gýŸó]…‚\Þ’7“÷>^]Ï—€\Þ`\01ùIÁ\ÖWò_}\ß\éoøkt‹^oò_­ÿ\0«…Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@Q@•¤ÿ\0\È*\Ëþ¸§þ‚*\ÝT\Ò\äeÿ\0\\Sÿ\0Anµ]ÿ\0¨ÿ\0\ë˜þf“Gµþ\ÚñŽ¤\Üjÿ\0\Ø\Ö7—¶\Ò\ßJøŽ\Õb´¬(Â‚XäŽGZ]wþ>£ÿ\0®cùš¥nm—\Å\Zy½µ–ú\ÌKo\çZ\Â\Ådš<&\äSØ‘½=ô«±»ñÃ¶¾\røq iþ&‡\Å\Úe´°yz¥«\r\ÆôGlw)b§\æ<©\éÒ¦ð„u‰>*´ðîŒ–­©Ý¤\Í\nÌªŠ\Æ8žR¹\ÛÁ!\ã$d\Í]ø\×\àý7À?µ]GŽH´\ÛY\íŒ1\È\åÊ‡Š9\Üy 8\Ï8\ÇZÁ›‰\ì|}\åµ\íÝ„–zv¥vf°tŽr±X\Ï#¢;#„.ªS~\ÒWv@\ÈS‹§\'ºv.qt\ä\à÷Gö\É0@Œ‚>X\Ôxô¨kg\Æ\Úü\"\Þ2×´]»?³o\î,öù\Þv<¹1¿bo\é÷¶.z\í^ƒ\Z €¢Š(\0¢Š(ÆŸÿ\0#ý\Çÿ\0\ÐMX¨t¸Ì—¨ƒ«?îš·\ä§ü÷òoð©W]ï’Ÿó\Þ?É¿Â¹\ÏøEfÿ\0Ÿ»oüÿ\0‰©³.Ì°¼€¬å·®!`H\ç\îNzq\Íu^%¾‹O¸\Òã¸²\Ó\ä\Ö\íDŸlHm\Ñ!V\'÷h\ÉUgNI\àŒ­œY\Ö\Þ¼³¸Ž{}B\'ƒ$‘¼Š\ÊGB^\riK?‰n. ž_\\I<ŒR5\Ü\å£\ÈÁ\Úq\ÆG\ÓNj³\Þÿ\0\×\Ì\ã­JU*FI++õk¥»mÿ\0ô%Ô¡¹‡\âN§§i¶*\Ó]4I\Öp\Ékœ\ä+©U\0d’\0Àƒ\â\íB\×R\×\îe²Š­WG\äÂ±	€»Ê¨\0\Æ\â\0\ïZwP\ë·\×\â\ç_’\âqD%–\æf`Œe\ÉÁ\ä{\Öwü\"³\ÏÝ·þ?ÿ\0\Ä\ÔÔŸ4yV×¿õø‘C\é¸\ÊvºŠ^½\Ûû•»jb\Ñ[\ë\à»\ÇUežÝ•º\Íÿ\0\Ä\Òÿ\0\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âk3¼\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³Ÿ¢ºøBo¿ç­¿ýô\ßüMð„\ß\Ï[û\é¿øš,À\çè®ƒþ›\ïù\ëoÿ\0}7ÿ\0Gü!7\ßó\Ö\ßþúoþ&‹09ú+ ÿ\0„&ûþz\Ûÿ\0\ßMÿ\0\Ä\Ñÿ\0M÷üõ·ÿ\0¾›ÿ\0‰¢\Ì~Š\è?\á	¾ÿ\0ž¶ÿ\0÷\Óñ4\Â}ÿ\0=mÿ\0\ï¦ÿ\0\âh³\Ð~\ß\éZtšdšÖ™ý«¦˜Qf…ex\ÝA\çB¬>a\èx<Ž8#¼ø¡q\à+;xl¼\'¦¤\×2ª\Ë&¡ö‰™bRUf\åˆ\ë‘òôû\Ù\Û\æ0µ­•¼,Ah\ãT%zd\0*z\Ð=wþ>£ÿ\0®cùš}¦Ÿ©Zj\ÖZ¾sµÕ»C<\ä\îŽD\nUº@4\Íwþ>£ÿ\0®cùš»±\r¬1D\ë!es´}\Ð}jjµA¬&»\âI®\ëW\ë¨jÊ²O;Ÿ™ö\à€0\0\0\0\0¬\ß\ì{\Ïù\ãÿ\0/øÖŸü$ÿ\0Ü—ò\ãGü$ÿ\0Ü—ò\ãTõwlmÝk\Òj\Úö­¨\ë\Z‘ó\ï¯g’\î\æo‘w\È\ì]\Ûj\à’N\0Ç¥c\Öôš\Ä7P\Ë,š6\Æ\à1÷Iõ¬\Z‡\äER\0¢Š(\î‹ÿ\0!H>§ù\Zö/…¿ü7\ã\Ï	\éqOmyo¬]x¿KÑ§\Ô\Ðd\×\"}\Â8¶\r­òY™ó€¼†ñ\ÝþBp~?\È\×}£xó\Åð¤¾\Ó\îô\ë}2K…»,4\Ëf¹Y’-ÁˆÌ®¹;Y\\\Ü@\ÆMZ\Ùü¿Ÿ\åtL®öóüŸ\êzDðn±à»¿E\à\Û+ô¨u\Û\Ã\ë{x\ÖwoÅŒQH\ì\Ó†ùÝ²EÐ®‚Àñ\Þ \Ð|!á¿º<z¤–~\rº\Zn¥ub$•þ\Ï\rÅ¼3\É\à|Âªd+Á/´u-É‚\ï\â\ç\ïu‹]J]KNó-\ášµM&\Ñ,\Ý%;¥ó-V…\ÎBIT$\åW§‰/5k—šÆ­z—z…\Û\ï–]¡@\0UU\nª\0\0*€\0\0\0Q\×+¶\ßð~ÿ\0\éli\'š\ï\Ò\ßv«\Î÷zžÛ®|\Ð|Y¥\Ý^øL\Óo®õ+kX­=B[->	‘.®`kù#‘‘\æx f$³´ûAØ¸ù\Ú\æ\Þ[;‰mç¢ž\'1\ÉŒ`pA \× üNñŸ†o¢»°\Õm‘XÃ§GÅ…¼ð¤H$Œ¤‰2È¡\Ã\ãv\ì¶rI<uÅ…\Õ\ÝÄ³\Ï:\Ë4¬]\ävb\Ì\Ä\ä’q\É&—+OMµÿ\0ýw\ÛBS÷l÷\Óò\×úù\î\Ì\ÚôŸü“Æ¿u\Ï§Œü+¤Zh\ßñ÷a©\ÝO\à\Ï\Ü\Û\Z\ÂÁ÷ži<ðq\\\'öD¿ó\Ò?\Ìÿ\0…\Ùÿ\0\ÏHÿ\03þV`Y³ÿ\08~‡ÿ\0B5\ë6^\Ñ\í~\êþ#[ˆu-Ro).qgûøÁŒ2“\èp¿)\ËyT040F„‚T‘Ó©5~\×T½±±½³‚wŽ\ÖõU.!\å+\\PG¯$t\'*\Ì“\áíµ\ïö‡\Ú-\âŸo—·\Í@\Ø\Î\ì\ã5\Øÿ\0ai¿ôµÿ\0¿þ\åšf±}£ùŸc›\Éó1»\åV\Î3Ž úš½ÿ\0	ž·ÿ\0?Ÿù	?Â“‹\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð¥\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…\ØZoý­\ï\Âÿ\0…y\×ü&z\ßüþ\ä$ÿ\0\n?\á3\Öÿ\0\çóÿ\0!\'øQ\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…\ØZoý­\ï\Âÿ\0…y\×ü&z\ßüþ\ä$ÿ\0\n?\á3\Öÿ\0\çóÿ\0!\'øQ\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…\ØZoý­\ï\Âÿ\0…y\×ü&z\ßüþ\ä$ÿ\0\n?\á3\Öÿ\0\çóÿ\0!\'øQ\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…\ØZoý­\ï\Âÿ\0…y\×ü&z\ßüþ\ä$ÿ\0\n?\á3\Öÿ\0\çóÿ\0!\'øQ\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…\ØZoý­\ï\Âÿ\0…y\×ü&z\ßüþ\ä$ÿ\0\n?\á3\Öÿ\0\çóÿ\0!\'øQ\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…\ØZoý­\ï\Âÿ\0…y\×ü&z\ßüþ\ä$ÿ\0\n?\á3\Öÿ\0\çóÿ\0!\'øQ\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…\ØZoý­\ï\Âÿ\0…y\×ü&z\ßüþ\ä$ÿ\0\n?\á3\Öÿ\0\çóÿ\0!\'øQ\ÊÀô_\ì-7þÖ¿÷\áÂ\ì-7þÖ¿÷\áÂ¼\ëþ=oþ?ò…ð™\ëóùÿ\0“ü(\å`z/ö›ÿ\0@\ë_ûð¿\áGö›ÿ\0@\ë_ûð¿\á^uÿ\0	ž·ÿ\0?Ÿù	?ÂøLõ¿ùüÿ\0\ÈIþr°=ûMÿ\0 u¯ýø_ð£ûMÿ\0 u¯ýø_ð¯:ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áGü&z\ßüþ\ä$ÿ\0\n9X‹ý…¦ÿ\0\Ð:\×þü/øQý…¦ÿ\0\Ð:\×þü/øW\Âg­ÿ\0\Ï\çþBOð£þ=oþ?ò…¬Eþ\Â\Ó\èkÿ\0~ü(þ\Â\Ó\èkÿ\0~ü+Î¿\á3\Öÿ\0\çóÿ\0!\'øQÿ\0	ž·ÿ\0?Ÿù	?ÂŽV¢ÿ\0ai¿ôµÿ\0¿þai¿ôµÿ\0¿þ\ç_ð™\ëóùÿ\0“ü(ÿ\0„\Ï[ÿ\0Ÿ\Ïü„Ÿ\áG+\Ñ°´\ßúZÿ\0ß…ÿ\0\n?°´\ßúZÿ\0ß…ÿ\0\nó¯øLõ¿ùüÿ\0\ÈIþ\Âg­ÿ\0\Ï\çþBOð£•\è¿\ØZoý­\ï\Âÿ\0…y·‹\àŠ\×\ÄWq\Ã\Z\Å\Z\ì\Â\"…\äS\ÐTŸð™\ëóùÿ\0“ü+*ú\î\ãQº{‹‡ó&|nlœ°¦¢À¯E.\Ó\éF\Ó\éUfQK´úQ´úQfQK´úQ´úQfQK´úQ´úQfQK´úQ´úQfQK´úQ´úQfQK´úQ´úQfQK´úQ´úQfað‡I³×¾!iš~¡n—Vw:Iô#È“ò \à‚99ª<7g\á/_iv:‚jVð¶‹÷£=\ãsŒ^‡oC•ZN©{¡\ß-\å„\ïktŠ\è³Fp\ÊJ6c†<ŽGQƒTöŸJ,ÀJ)vŸJ6ŸJ,À\Â\×\ã\ê?ú\æ?™ª—\ëWþ¹§þ€*\æ½\Å\Üõ\Ì3T\îÿ\0Ö¯ýsOý\0Py\ãM\Ã^ø‰¢[^Y^I£è——°i\×nÏ¦Z\Ï;Fò‡Œ’»\0F\Þp01Añg\ì\ë\áÏ‡¹ñÆ»¯]\êž	Õ¢ÿ\0ŠIt\Ð!¼\Ô\äuÜ¾vôeb\ë2	b0r<q|q¨\ßx\Êø„ÿ\0\Âc¨,©,\ã\ÄMr.ö(UY˜8vPF7œWcqûGx¿V¹ñö\ãYø‹K\×b\\hÚ”Ll \Ø1[ÆŒ¦ˆp…À\à\ä)æ–Ÿ\ë[þ¹¿þ€j\Zš\Óýk\×7ÿ\0\Ð\rCLŠ(¤EP½)\ÄwÑ»*†$ÿ\0ÀMmÿ\0lYÿ\0\Ïoüu¿Â¹ûOõ­ÿ\0\\\ßÿ\0@5\ØøÀºOˆ¼;¬\ëZÎ±}¥\Ú\é÷V–‹Ÿ¦­ì’¼þn>Vš,\å„“ž•q¿Oë –¬\ÎþØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð¨<c\à\Ë\ïkZ”\Ênml¯\æÓ†¡\n³\Í$Dn\n\Ý3‚¤®r7\Óô¯‡-\×ZT\Ó|/­j-Q\Ï\"\Ú\éóJR9tnv©Â²‚Tô#‘R§Ì¹–\Ãq³³$þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oðª6žñþƒs­\ÛhZ•Î‹j\Åg\Ôa³‘­\â# TŒŽ§¸¦M\áv\ß\Ãð\ë\Òèº„z\Ï\åÅ©½¬‚\ÚF\ÉV\\m\'*\Ã\0ö>”ù…cGûb\Ïþ{\ã­þlYÿ\0\Ïoüu¿Â¹¥R\Ç3\É\Å/–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éG–x\åyý\á\Û?\áÒŽf:O\í‹?ù\íÿ\0Ž·øQý±gÿ\0=¿ñ\Öÿ\0\n\æü³\Ç+\È\'\ï\Ùÿ\0”ygŽWO\Þ³þ(\æac¤þØ³ÿ\0ž\ßø\ë…\Ûó\Ûÿ\0oð®o\Ë<r¼‚~ð\íŸð\éHT¨ŽFz\Ñ\Ì\Â\ÇKý±gÿ\0=¿ñ\Öÿ\0\n?¶,ÿ\0\ç·þ:\ß\á]_\ÃÙ\âG\Æm]_Áº:ÝŒ2˜ed\Õ,\âxß®\Z9%W\\ŽFG=³^}\â\ró\Âú\åî‘¨Vú\ÎV†u·¸Ž\á\Ç	#fFÁ\ã‚h\æ\Z\ß\Ûó\Ûÿ\0oð£ûb\Ïþ{\ã­þ\Þ|øi\áOmÿ\0„ž-boµøŸDðÝ¿öMüV¾OÛ¾×ºgó —~Ï³.m\Î\ãóW\rñW\ÂÖžø¡\ã\r\ØI4\Ö:>³y§\Û\ÉpÁ¥h\â\ãR\ä\0£8\0g°£˜,3ûb\Ïþ{\ã­þlYÿ\0\Ïoüu¿Âº?|¸ø©\á[©ü%¨[\Æsf\ãÂ¿g	<–Ä€\'·}\ç\ÎÁ?:\íR£žG5‘ñCÀºwÃr\Û\ÄPøƒU‚5_±\Âµ¥\ÏñA\ÛÏœW£0\n33Œ\Ñ\Ì9\Ýjd¸¸ŠH\Î\ä1ðqŽ\æ’hQŠ2|´ÿ\0\ÐEV¸ÿ\0Umÿ\0\\\Ïþ†\ÕrOùgÿ\0\\\Óÿ\0A†Cöxÿ\0»úš>\Ï÷SRW_ð§\á¼\ß¼ke\á{MsGÐµ\ï’\Ò]nY\"†y²Â®‘¾²v†\01A\ÜUJŒX\Ö9h\ÆUÁÿ\0¿mT\ë¥ñ‡\ãðŸŠo´xµ7_[9$„\ê:<%¤\Ì#m\Æ7tB\êF\à0q•,¤\ÍPEPEPÖŸ\ë[þ¹¿þ€kÒ¾üJ³ðO†üG¦Í¯ø‹\Ã7zÍœñj…d“d>vø\ß3Ã€\Þj÷#\å\äWš\Ú­oú\æÿ\0ú¨j¯¥¿®\âj\ç¿i<\Ún¡\î„ml\ä\×nõE\ÑSC²¼‚X%†$XD\Ò2µ³f3—…27\0T¾øù\á1¦ûTz²›m	Ç¦[]±k9UL’©„±a²dù×¨\0\×Ï”T[Kz~þ\â\ïùü\Ï`\Òþ+xz\ßM\Ð\î\ÙukM_D\Ó\ï´\Û]6I,\î\á\æ`òLdW\\‚Dm¿\Ë2\îùz\ë	ñW„´_\\\ÜÏ¤Á`¶\Í5œ[]›i¤IL2-Ë™¯y,\Ã\ä\áTŽqšùþŠ\ZM[ú\Þÿ\0›x\ï­\ßõ·ù\n¬òqÞžgf\Î\ï›w-’~f\ç\æ<õÿ\0<\ÔtS!›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóQ\Ñ@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5!›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóQ\Ñ@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5!›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóQ\Ñ@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5!›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóQ\Ñ@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5>^y \ËžH{\Ð™Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ñý?ý3ÿ\0¿©þ4›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóRÿ\0gOÿ\0Lÿ\0\ï\ê\Ù\Óÿ\0\Ó?ûúŸ\ã@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5/ötÿ\0ô\Ïþþ§ø\Ô3BðHQ\Æ`ðA\ê3Ú€\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\È#\È}\È4P†vl\îù·r\Ù\'\æn~c\ÏQŸó\Ívl\îù·r\Ù\'\æn~c\ÏQŸó\ÍGB‚\Ì–8\0w\'  	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨ðv\î\Ç\Æ}ø\ãõ!›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóA›;¾mÜ¶Iù›Ÿ˜ó\ÔgüóQ\Ñ@Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï4Ù³»\æ\Ý\ËdŸ™¹ù=F\Ï5c#\0¡Š\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy \ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¨\è 	\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?\çš\ì\Ù\Ýón\å²O\Ì\ÜüÇž£?çšŽŠ\0\ÎÍ\ß6\î[$ü\Í\Ï\Ìy\ê3þy¦\É!\äò\Ý\Û$–9\ÎM6Š\0\èüñ\Ä\ß´ÿ\0\á\Ö\ï4o\í;V³¼û$…<è›ªŸB98#5\ÎQE\0z\×ÀW¿î®¬ž\ãM·\Ò|«\ÍNº\Ñmo%]V+Æ*\Èð¼Š\Ép\Ñ\ìÁ\n¥Üœ|ù\ïŒ<]ªxó\ÄÚˆu©a¸Õµ	L÷SAk²\Ë!s”‰U1\åˆf%ŽI$\ã\Ñ@•ðû\ãU\Ç\Â\r\Ü/„´\ï\ì¿]K‰¼Ró	fŠ\Ø|›x\Êb-\Ä|\ï–,8ùFA\Åø\ã}7\â·µk\á\Ø|=ª\\EPYÍ›[«œü\ÓGÁ\ä\î\êP3ä£Š\ã\è 	®?\Õ[\×3ÿ\0¡µ\\“þYÿ\0\×4ÿ\0\ÐES¸ÿ\0Umÿ\0\\\Ïþ†Õ­¤i±j’jR]\ß\Ïekag\ìm\í\Ögl´1€™{Ëœ\çµkNœªË–;ý\Ûk\ÔÎ¥H\Ó\\\ÒØ§E_û?‡\è;¬\à¦þH£\ìþÿ\0 \î±ÿ\0‚˜ù\"¶ú­Nñÿ\0À£þf?Y‡gÿ\0€\ËüŒ\Öÿ\0XŸGÿ\0\ÑmT«{R\Òm-¬,5F\êö‰n +uj24q#dmw\È\"Q\Üt5ƒXÔ§*2\äžþ©\î¯\ÐÚHÕ4vû¶Ó¨QE‘ QE5§ú\Öÿ\0®oÿ\0 \Z\Ùø\á_øN¼u\á\ß}«\ì?\Úú½‡Ú¼¿3\ÊódTß·#v7g\ÇQXÖŸ\ë[þ¹¿þ€k øa\âk_|Ið¯ˆo£š[-+Uµ¾ž;uFH\åW` aN2@÷­!neÍ±¿+\å\Ü\ì¤øY\à\ÍSJñŒš‹µ\Û\ÍK\Ãv-}-¾¥\á\Øma™V\â(VD½”ƒ™AN€ô®2óáŸŒ4\Øtynü)®ZÅ¬º&™$\ÚtÈ·\Ì\àXI_\ÞÜ¸œ\äz\Ö\çƒþ\"iþ›\â“\Û\ÜMÿ\0	›%¢ª)\n\íy\ã\Ì\Ë.Ø˜d\äŽ;O›ö†ð•ŸŽfñ-ñ\r\á\ÖüU§xU±½‚K¶•¤h­\ØL|ö%\ÙU\ÜE…P6ü\ß.Q¿¹~©_\É\ß_\Ã_+yš\ÎË›—£vóVVü~ÿ\0‘\âº_\Ãk’\ÙE¦øK\\\Ô$½IdµK]6iL\ël•*Á…b>\é\à\à\Ó&øk\â\ëm\n÷[›Âº\ÔZ5Œ\Íou¨¾0··•\\#$’Ú¬… A8\ë^½qñŸÀ^\"ñ½\ïŠõk\rB\×S¼Ó…¬P\ÓS²Ò¥ŽH\Õ\Z\Þ\Ú\âa£Â®68ý\Ë9+¿‚­ñ\'Æ\ë¿õMº\Å\ä¾)¸šHô™4›[b›¥FF}B9Œ\ÛB¦\ã\0\Ëf\ÆG‚Wiz?\ÏO½Vd\ßkþ<\É~\nüBmB\Ò\Äx\Ä\Æö\î¹·¶\Z=Ç™4K´4ˆ»2\Ê7®Xp7QY\"ð?ˆüÌº÷‡õM–S]F\ÊKr$®S\çQól‘p\êz^\ë\â\Þ]kÀ\r \Øjh\ÞñWö\é´M\Î\ÃÉµ\Ì`O&Rn$U„ƒ4Í¹ø\ÉŸ\à_¾\nÒ¾\ê:ˆ4û@É«\êZ’\ØÉ¡Y\ÞGr—\Ñ\Å}¦Y¶Ž®›Œ©=:\â›nÍ¥ýiþo¾\Ún(«Û›ú\ßü—o‹]ð¯\Ã\ïø\énÏ†ü5¬x„Z7J°–\ç\É\r¥ö)Û­ŒõÁô¬»­&ú\Æ\Þ\Î\â\æ\Ê\â\Þ\Äi-¥–&UU\Ê3!#+)#º‘\ÔW°þ\Ï?ü?ð\ÃH×­5³\Þj:mô/c¤\Û_¶\Ær\èÒ¡·vóWlñ\åÐ‚WµW\ãw‚\'øO§hš]\Å\ÕíŽ›gŸq¡YN«4÷3KÉ©´Ÿi\Ê©*¨²xbjÝ¹¼´ü®ÿ\0?;-Dµß¿õ÷\Ã]ž;yðû\Å:l\ÞMß†µ‹YvO/—5„¨\Û!Ïž\Ø+\Ò<\ÇøpsŠn¹\àøgK\Óõ-cÃš¶“§j\05\åõŒ°\Ãr\n†7e\Æ?)<k\Û<iû@xS\ÄV>:²µ‡[XüM©\\j\Ë,öñf\ÖA$-\r¸Q)\ÌRˆœ\ä\É¼ŸŸF\ß\âw\Ã\ßx\Ë[{ýC[·\Ó<Q«\'ˆõ»}R+E´ŠiÍ¥³}£÷\ï+!„XF\Ö-1\Õ&ü¯\åµÿ\0_üû\È]/\×]?/¿õòg„\ëŸ\r<_á™¥‹Xð®·¤\Ë·\ÛdK\í:hY-÷„óˆeMì«»¦HÉ¬û¿\n\ëVr]\Ü\è÷öö‘¬ó\ÍlêŠ³)xIb0Š¥”ÿ\0Œ\×\Ó$øñ\á}?\Âc\\\Ñõ;sX¿\Òõ]­µ\Ëå¸—R‡Pó\åµy\çO%„\ÒÆ»ƒ|\Ñ\î\Ñ\Óÿ\0io\nj\ÛW†\âÍµM7\Ù\áM7R·/em$S µšDŠ%f‘eTp«Ò’»^ð_\égó)\è›\ß{y\Ú\ßð~\ã\ç\Í\'À\Þ$\×\îô\ë]3\Ãú®¥u©Fò\Ø\Ãie,¯tˆX;Dª¤¸RŽ	\\\à©\ÏCUÃº²\ëÿ\0\ØM¥\Þ.·ö±ÿ\0f›wûOŸ»o•\å\ãvý\Üm\Æs\Æ+\è=+öð•\ÂZ[\è·Z6‘6‹¨i%WM´\ÔÅ‡ª=\ì!-\î—p|¸\Ù_grTgšðOŠü9©üdÖ¼q\â/\\½¦göû)ÿ\0±--nn\îTEº¥’N±)eØ’¥¹\é’@\Ú\ÓMÿ\0O\Ì\Zµ\Ò}l¿\Ï\ïü?‹\àÿ\0gÕ¯ô¨ü\â95K\Ök»%\Òn\ÖÑ°Ê¼‰³r)‚@±mü+­]ý\È\Ñ\ï\æûl2\Ü\Úùv\Î\Þ|Q\îó$L™S\Ë}\Ì8=\r}Coñá‡ƒ¼I\á_Cq¨j·I§hþU\Ë\èVwP¥™o5»\Å-Ã­¬’˜!™fB\Ò*°\É\ä4_\ÚcN\Ñ\í|9§;~Ÿe¤\ë6W’I¤YKw\æÝµ\ãBa¸peDhpW^\Ãg\æ%x\ÞÚµ\Âÿ\0ž‹\×\Ê\Ìi_W¦ßŽÿ\0w\ë\Þ\èð\Öð®·œG¿S\r¢_Ë›W-ŸnÉ›Ž#m\é‡<\ëƒÈ¤>Ö—Z¸\ÑÎ‘~5{3\Î\Óþ\Ìÿ\0h\ËR\Òn†\ÕVc‘Àž•\í:§\íc¨ø{V\Ñ?³\Õln<§\è0JºEš]ý®²\ïi.Ty\Í	ò$À.z§\È1òõž.ý¥¼ªø¾û^µ\Ó/®\î\ï&\Ô$K“\á\Û\r6\â\Ò)\ì.-\Ä\r$³]\æI£f’RDg\0–\"Ov\î:\ïø=>ýÿ\0«\n:¥~¿\äŸ\çuý\\ù\Æ\ïÁ#°ðÍ¯ˆ\ît\rR\Û\Ã\×O\å[\ê\ÓYÈ¶“?\Íò¤¥v±ù[€„ú\Zmƒ|A©,\rg¡jWk=´·˜,\äq$–J¸¢`\Ì8NO\ëþ7iž6øsg¦\Ù\Ý\Ü\éw\ãK\ÓôÛ½)|5§˜¦û(D5%qs´ˆ\Õ\Äl„•\Î\Ü\Z\ÖðW\í øGÁ>Ñ£\Óu}g£\êºV¯x©ócŸ\ímo9`vy—(òA&$À;~bZ)µÑ»y\è\íø\Û\ï\î(\ê£~»þ¿\åÿ\0\0ò\rK\áoŒôX­e\Ô<#¯XGuo%\Ôs¦Mš\Ð<’!e‘T†,8\0‚x¬;þ>¿\àÿ\0 \Zö¯‰^‡Àúo‡\íu/I5¬¸¾°Ó­´r¦KQ\ZA$p\Í\"Ü£¸l\ÒbS\È\àxþÿ\0_ðÿ\0\Ð\r\âk§õýÀ°/…7¹\è>ø¤\\xAüQ\â­v\ëA\Ñ\ä»k$\Óôå¾º»™U^B±´ÐªÆŠé¹‹\ç. )\ä‹Ú·\ìÿ\0\ãhõ‹»x{Wñ†™\Z\Å,:¶‰¦Oq\ÑK\Ëªv1Ô”<©$v¨<9\â\ê\Þ‡Âž,—T\Ób°\Ô$\Ô,5=\"\Ê+\Éšˆ“C$O4 ƒ\åFÁ\Ã\åJ°\Úwev\ï¾2iWÚ‡\ni÷¶šv¡\á˜<9¤[—Yž\á’Ô£L\Ù^JÛ»1Q÷Ÿ\0cK­¿­?;\éÓ¯•\È\ëküÿ\0ð/Ë—S„\á×Š\åðÌž$Ok/\á\Øó¿W]>Sh¸m§3m\Ø0\ß/^¼R\êŸ\rü[¡\Þivz—…µ­>\ïU!tû{­>h¤¼$€*\Ê™,£\å\Ï\Þµ\è¿ð·¼5§\é·\Ú¦§q¢\Ç\áE\Ðmh\Ò)g¯£»šYTH\Â5b%Qµœ€\ß‘gñ{á–°Ö’Aq{¡\é~¹½×¬-S\Ãö\Ï\æH-àµ·\á~\Õ$-‰ZY|‹	\Î:\éª\ÕÁš\Õ}\Ï[\×M¯þI¯\ÇG÷­.|\çyð\×\Å\Ú~¥&u\á]j\ÛPŽh-\Þ\Öm:d•e›>Le\n\ä4˜;F2\Ø8\Í6ó\áßŠôý\ãZºðÆ³m£[L\Ö\Ó\êiò¥¼R«\ìh\ÚB»Uƒü¥I\È<u¯£µ\nðžŽa\Ó\î5-j\×\Äz“a$\ë6÷\ÚjZCwc4€,\î\"œ©IPAI\n’\Üx+?Š¾ð÷\Â}k\ÃZ=¶ ºŽ¡¥É§I,šš5Ì¦ñe[™.üÖ\Åjm\×\äV\\\å%Jñæ¶¶ü­½_d\Ç\Ö+½¾Wÿ\0/Ó»G†\ÑE\ÄQE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0QE\0j\ßxO\\\Ò\ìVö÷F\Ô-,\Û¸ž\Õ\Ò3žŸ1\æ°õøúÿ\0€\'þ€+fûÄš¦¥¥Yi—W\ÓOaeŸ³Û»ec\Ï\\ž;V6£ÿ\0_ðÿ\0\Ð\0E?ü°ÿ\0®èµ­2\Åc\Òf½\ro!D\Êf7ep{Ÿ“ZÇŸþX\×¿ôZÖ¿†MŠ´\íyH\ÊQ£+:\ÄTŒóË®{t\Î)tgY&‘‘<´f%S9\Ú3Ò–\Óþ?­?\ë¼ú­­r\êé¦¸{{¹É€¾Y\0A\É<\æ±m?\ãú\Óþ»\Çÿ\0¡Š\0Žº´;\'\Óm\Ú\Úv’wV+²s+¼p¿–kž­\Í7X³µ²Ž)m\à’E\ÎY\ì–By\'\ï*7W{|ø%ƒw\Ýó®q\éšKX\âš\áRy¾\Ï\Îd\Ú[z\n½­j÷\ÞO‘QmÝ»Ë¶\ç8\ë†lôö¬\Ê`ojúj°’yYxãŽfÁ\É\\ú\ZÄš-\ä1\ËE\"õWRü+£ÿ\0„ƒOÿ\0ŸK_ü/ÿ\0¬-J\â;«\Ù%‰8\ÛTŒF\0}\ÐN?:H‡üxú\îÿ\0úu\é_tS¬júª\ßi67\Þû.\Í^òüˆ\Ö\Æ\"r%ŽL²eN\0\ë‚8\ê<\ÔÇˆÿ\0®\ïÿ\0 G^›û=\ÝOŠõG–,d‹\Ç\ÒÓ¤\"Hñ€\ZQ“·=}cZ¥7\ís¯	Z8zÑ«%tºw\Ómo§#\Òü\á­N¸7~¸ø]w¢¬\rµß\ÚQ%\Ë4‚¡†\ãaù‘B\0|·Ïž6ÿ\0‘\Ë^ÿ\0gü\Ü\Èþ<\Ö7ü{ÿ\0\Ó\î³Šú\Óÿ\0–¾Kñ·üŽZ÷üƒ?\ãþ\ãþ@Ÿñ\ãþ±¿\ã\ßþ˜ÿ\0sýœUS‹„y[¹zŠµG8Ç–ý:|¿¯›2§ÿ\0–õ\Â/ýµô„~ü/¼\Óü:5Mn!wªi‚Ký\Þ&²ŒY\Ên4ó\æ\Æ\ÅF\Â!ž\ït3)ba‘W;VSó\ìÿ\0ò\Ãþ¸Eÿ\0¢Ö½2\ã\Ç^ox\Zò]ûKH\Ò\í\í\ãÔ´\ì«k/2D‚•¾\Ñ¹\ß\"<Ÿ¾Œ\ã£640-x\àß†üy\à=gV¶ñ×•\â]\'H¼\Ö.¼=ý‘!\Ù\à} ¸C¸yg€H\ß\Ð\à×’\×ÔŸ¿iOkÅ’øk\Â\ÚWºö‡6Œ5\ï\í{¥ò –0¾_\Ùe‹bl!N\Ôùx\á¹5ò\Ý0\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€&¸ÿ\0Umÿ\0\\\Ïþ†Õ·¢\È;\Åöƒÿ\0J-+\ãýU·ýs?úVÞ‰ÿ\0 \ïÿ\0\Ø.ý(´®\Ì/\Æÿ\0\Ã/ý%œ¸Ÿz\Çÿ\0JG¹\Ûü\Ñu/\é~‡Uñ\"\\µŽ…¦¥•\Ê[C§\ÚMiq\Ë:J³\Å\"\îp\Å\ã?\Þp¨üO¾\ÓüI\í\rF\ÛWû6“¨KoöYn¼©¿s´¦\ír|?\\’qþ¦l~\îÄž2øz¾²‚\ÛTðýž¤šn‰?`Ð¦³\Õ-/bž#y1¿X_hs½C“\Æ\ÕÊŸ;“ø\â\Èõ-Ÿ\Ù_õ+Ÿô¸\çþ\Ñ\×u\ß:6ò³l»¬`\Û\æ\ã\ÙFò\Æ\â˜]\Ü\'Q\ç\ÒÈ™£\ØCQÿ\0\Ò{zç«¡“þD\Íþ\Â\Zþ“\Û\×=]¸¯†?úJ9pÿ\0õ—þ”ÂŠ(®C¨(¢Š\0–Ù¶»“\ÐG!ÿ\0\Ç\rRûrz7\åV\áÿ\0–¿õ\ÊOý\0\Ö5Cøgð\ÓRø«q•sgj\Öf\Õ_\í®\ê\Ü]El›v«ty”œ\ã\å8/|=\Ô<:\Ú?Ÿqi:j——60<\ä	 ˜B\å·( A\Ï±È®½ó\áWÇø7À\ÞÐµ{-Fy­õ+·Momƒ\ì‘V=Ò©2˜a—i\Ú?t>nM8Û™9l·ó\Ú\ß\×Ï¡œÜ”_.ý>\ï\ÇúG\r­|&ñŽ‹ý·7ü#:µþ“¤M4W:Í„\ÒX\â)^&M°.\Íñ¸q÷OB¨­¼\n‡Àqø£Pñ—£Cr÷\Øi÷‹r\×7\æ›ü¿*F\\(2:A\ì	¯ZÕ¾1xgM\Ðü\â)5WRñ¾­Go [\ÅY\Ã-\í\åò3\ÜLg-ùs+˜\Ä$¸X\Æð+\Åj¿´³\âx3\Âz×Š¼Yq¤\Ù\Í,z\äo’Dºµich\ÑQ¥Ä…U|\0qŽ9¬¡\Ìý\Ùo·\Î\í?\ÑüüªZ-¸\ê®þ\ã\Ä\ßu\ß\ÛøZF‰u)¼E\Z›KM9^Y–VXm\ÝvÞ”žÚ»¸•Fs(\ß|9ñŽ™¨iö7žñ¥\î¡\\Y\ÛO¦L’\\Ä«¹ž5+—P ’F@5\í:\í\r\á¿|D\Ð÷Ãºw„’/i\ÚÝ®¡k$\Â4„I\å\ÎnL÷.‘~\í`9ˆ*þ\è\ä‚#ð\'\Åo\n\é¾&\Óô{/k‚\Â&ñ³{\âZ\Þk¿µ\\\é²B¢\ÅË†|¢\Æpdyap	«\Þ.V\îþä¼·jï·ž‰.\íoý»\ï\Ùmß²<Š?‡z¦Ÿ\âI4_\ãÀ\Ãoö©_\Å6óÚ”Œˆ–6™\Ë\0	¤\áUˆ\ÌñÇ†\ï>ø¯Qðþ§\å½å“…2[¶\è¥VP\é\"‚U‘•†@8a\è\Ö?>M®øONÖ¢\×õ/	xWJž)eÓ i¯¯$\ç{ar¡`V”ƒ\Z\ÎKûË¼…\ãõk\Â>$ø™¬j¾%Õ¼I®h÷‘\Í8¾¶°¶±½’\é£&=\Ðy²F‘	0W? ù@\à\Ûüÿ\0§Í®Ÿ\Ò?\à~?\åým®O†ü#\â/[\ê\Z‡5r\ßOA%\äºmŒ—l¤1\r!@B+rq÷O¥2\n\ë÷Á$^Õ¥Ž\â\ÎMFK)’\Ö<‰\'SŽc]­—(\Úrx¯JøIñ»Jðg€\í4i\î\æ\Ð53W—U²\Õm¼)¦k¬\ÌñÄ ¥²5»£@¤<ls»\n‚sô/‹´ømu\à«ÿ\0\íi-udž\æûT†\Þ5É‘8m\ãó\0kv0\ÆeRÉ¹Š°P`]\îM«Û·\éý}\Ö\ê…m\é_úûüµ\â&ðˆ­ü+‰\åð\æ±†¦.=e\ìdnÛŠ\íY±°\Ê\Ã\0õv®—\Çÿ\0õ‡>ƒW\Ôotû‹y®aµX\íF“t–pÝ‚w\"Œ\çE<ýì3]7¾:iž$øv4ý6òmRŸF²\Ò/t´ð–˜\ÑÎ¶\â%?ñ3.¶7’(pÀ.H\0×„\Ñ\'¬’\ï§\ßú¯\Ï\È#²“û¿®\Ï\ïùé­§¬º¶¡mcg—w2¬0Â€nwb¨\ç©$\n\ìl>^j0×´5\Õt¸\í´’]S\\’I>Ák\Z0Fb\Â3#þñ–0»´0 \×3ð\ï\Å+\àøk\ÄoºM#R¶¿h\à\È\"•\\¨=³·\Þ\é\Ú×†|\âoør÷QŸXðo‰¬Djú0Žk˜SÍŽ\æ\ÚS2‚\êÑª\É2—/µ¼ÿ\0K~¾¾V\Ö÷òû®\ï÷iÿ\0\ç\ï¼\n‰§ø‹Q\ÒüA¥øƒM\Ðã¶’{»¹dó¤Ø«\Z\ÏlJž»”Bkg\á\ßÁ›ß‰\Z-¥õ¦¿¢\é·ú„šV§j-p³\ß]$i\'—H^5$HŠŽ€“Œ÷¥ðÎ½ð÷E\Òüg\áÉµ\Ï>­Af-õ8ôsp’E7˜\Êö\æûhS\Ð0”Ÿa]\Âßøc¥\Øh\"\Æ\ëYÑ—^¼¹º»›O‚\Ñe5¼P¬¶\Ò	\ZKk•\ØÏˆ\ä!Av&\ï•÷\é÷¯ø;ú^e\Ûþýmùhx«\Ý,n\È\ÊÁ”\àŒµ©&ƒ¬E5\ÌO¢\êI-µª\ßOZ¸h­\Ø+,\Ì1ò\ÆC¡x!×žE`Üˆ–\âQn\Îð\"6‘B±\\ðH€q\Û\'\ë^°\ß\Z,#ø{¥Z%ƒ\Þx¡~\Ça©5ô*\Öwz}¤¯,0±WÛ‰a~[d\Ã\Ç\Õý?\áþZi\Ú\ãzI¥ýJÿ\0;\Þ2ø_«øÁ¾ñ«%ªE¯y¾MŒrun\"‘LË´\ßñH 1%\\Edø\Â÷|I§¼6\Î\Ñ\Ëq5\Ý\ã\ì‚\Ú‘¤–iB\"+1À$\ã\0@=¯\ÅO6¼Œþ\Ót¿I®^j\×W\Ör^2~ú;u\Ì~uÔŸ3He+µU#Ù·\æ\Ìø‰\àß†­u-\Z\ËV\Ô<5u¤6Ÿ©Ã¬E\Óy³A¶fHÔ„’5“±¹\Õv9‰¤›\Ö\ë\Ó\Ö\×_+\é}>Bmóÿ\0À­ùj–¿3Ÿø…\àß‡rhò\\\\\Û\êš^±f/´\ÝR\Å&X.\á\Þ\ÈYD\Ñ\Ç \Ã+ #*A1ü?ðýŸ‹µCk\'Š4Ÿ\r]3¤V\ë«Aw\'\Ú]\É]©ö{y¹\éûG\Ì1žq\Õ|@ø¥\áßˆ\Þ.ð…¶½{\âMc\ÂúHhõ\rY\â†Vñd”\É+G’H¢\n\n\Ç{\ÙB\Æ9\0\í\\?†*\Ò<\âmKSƒ\Æ^0ðr†ò\íeð\íœs\\\\Û—\Üc¾\Õ\0Q… Rs‘ÀË¦õ÷ö\×\î¿õÓ¾;\Û\Ý\Þ\Ë\ïþ·\×\ç\Ô\ê</ð7\Ä\Þ&º{3¨\è\Úf£.­>‡§Y]‡y5K\Øq\æ\Ç“Š–@d¤yqóp\Ø\Â\Ñü>¹ \ê·vþ#\ÑSY\Ò\í®.\î¼;5µ\Ê^\Ç$ù„±¶ò2\0\Î<ìž˜\Ýò×¤xgö ðõ¼¥ô\Ëÿ\0\n=v\ëV±±ðõ´R-Í¤Î’ÿ\0f¼\í$mm’0¢GÞ­‚˜ES\Åøg\âæ•¢ø_\Ä?m\ÖüC©Ë­­\ë\Üø-¬\Ñ46¹œ2%\ÃHnY™¢ýÜª|€Û£U1¾³¼¹u\Þß•¿ßµ­¢÷‹Ó›\Êÿ\0…\Ýÿ\0[õ\Ùb\ê\Þ\Õt¿\èž*]CI¿¶\Õ/\rŠYX0š\æ	„k Y0›(\èv«³v°V^4øy¨ø/I¼½:Ö¬I¦Þ®«Y\é©#K¦\\°|G)’G\æ)WtM\"e\ÍÊ’·¾,ðZü±ðÅž«\âñ-¾ª\Ú\Î$\Ò Ž\Ó\Ìx¢‰¢²øQ`þ^X\àm^µ«ñG\ã”(ðþ³\Ô/5ÛJþKQ\Õo´+!\Ý\âI)Kfsp\ìÒ³4óH\\\à\0£,Z\æ\Úr\å\î­÷Fÿ\0w½ø[\ÍGd\ßgù»~Ÿ\Ë\ÍõIµ=\â85+	ôù\äŠ9\Ò;«A4n¡‘À`2¬¤zA¡¤\é÷úÏ†u\ír¶º/\Ù\Í\Äo\Z‰L\å Ûƒ†\ÆrGQŒóŠ<\ÖtýsV´ŸM¾\Öõ#\Ó\í`y5\é–Y–D…U\Ñ\n“ˆUŽ¡ƒ]_Á?Š–?\áñ\\—Q\\\É{y`‡J{x’E†þ)’[y_s*2\î\Èx\Æ0M>®û\ïemô~\Zø\ÓSImA¼ñ3j61ß¬zœ÷m\n»Ìª’\åsöyü£9\àâ·„|\'}\âiu\Ó}©iþ³\Ð\ãV\Ô/5«iB@\Í*Ä±†$\Þ]±€œml\ã\ë\Z\Ç\Å\0ø\ÛÁ¾/·ŸZ\×<3 Ks¡CŸce\×sG\n_<‘\Z\éÂ’H¿>\ã‚\"%n9Ë¯\Ú\ÇÄ®Ÿd\Ó5\ßxuüEy\æ™k¦\êr,vG\Ï\ß&YY0Ì€Ê¿9\ê\'&¦Õ»þ–üû¼\Çou5\åùkøœ€ð>­75Z\Þ\é×šNxÖ¿º„·­\Z5\Äj\Ñ\Ýž—\ÚÙ•~^·¾ñŽ›\á\Õ\×\îü)¬Z\è-\å\ãT›Itµ>b«G‰Jmù•”Žy\ë]\î—ñ\ë\ÃZ†\ì<3/…’óOo\Ý\éw\Ú\Ô\Þö‰¹¸\ß+º ¹:-Ç’At\ÞV> \ã\Z~?ø™\á\'L”Xk:–¿¯jžÑ¼<ö¦(³´\è–Y%\Û0™\ÚG?.=®\îK¸kŠ¼¹o\Õ/\Ïó²×§7•‡y«úü®¿+½<»³\Íõ?x\Ï@:{k~Ô¼;ksöH/5­8\Ù[4»¶•2ÊªƒivO9\Æ*OøZ\ëÁz6¡±¥x‹GÕ’Si©\é1H!g‰öKY\áŠ@\ÊJõLÀ‚k\Òþ7|JðM\ç‹üw¥\Ú\ëz\çˆ\í|K\â˜o5mL[Á\å\ÛZ\Û<ª©dDòŒ¬¤#±ˆF\Ü1\Û\çÿ\0¼Y\à\ßj\Ú$~¼\ÖW\ÃZz›X4›­\"#eo¸7\Ê\ëu7Ÿ3–vy.[p«”d\ä¢ûÿ\0’ý~ÿ\0\ÍmO\Õÿ\0_ðúr\ÞYñf­•¡\éWZÎ©q»É²\Ó\ì|ù¤Â–;Q±Àœ€š»u\áÿ\0X\ÉyÏ†õKy,î£°¹Yt¶S\Ã\çd.\n|²6òpp+­ð\Äü=ñ×Œ“L‡Tÿ\0„GX²{½WI°\Õ/mTM\Èò\ÚÍ‹y‰1m+•\Æ\íÀ\å@:ú?\íe\á\ë*ûM÷ŠoeŠ\ÏO´‚m\ÓG·6±þv†\Ý\Ý\"–!,;\ØÁd\Ü\n7{òÛªý¯¾ý]Wõ\ëýv·]8=;Áþ5\Ö.5›{\ëW³è¤®©¾Žò5²\'36?\Þ\Ç\Ý>†«\éz^¡¬xOZ\×\í$¶–\rHÝ¨ˆy\é¤ªÍ»|°\áP\ÙD\ã5\éþø\Ù\á_x}´m3S\Õ4¶\Óu¹µm+[¸ðv•«\ÝH$Ž ¥Ì¿\èòFÐ©E#n\Ï ÀøWYµð÷Ã¿\ê77¶\Ò\ê^\"‰4[m=\n™vý¢©®ú´_*4\\\ãsHv\ç\ËlM\ß\à¾ý?]<·)Yµ\ëøkúkøzò\Û\Ï\è¿÷\å?Â­izš\ê\Zµ´÷–\Úl3H¨÷—PŠN°\ÈN\Õc\è\r2\ëþøB\ì>\Íý­ÿ\0	o\Û%ûg›\å}ƒ\ì\ÛW\Êòñû\Ï3vý\Ù\ã\Çz§á»¨¬|A§\\Ï¨\ßiC:HoôØ„—6ûH\"H”\É\\‘ó¯#¨«_™\á¹\è¾ øk­\é\ë\á¹4\ËÁ\âž=9ü7g<4°%ŒC4Ë¹w)\á0A\àœdÿ\0\Â\ã¯øJO†\á\r×¿\á$ò¼ÿ\0\ì\ìi>\Ù\å\ã;ü›ö\ãœ\ã\è\ß<%ªø£ÁrxŠ\ç\Ä>?¶\Ñþ\Ü÷~ ñ6Ÿ·ò™£Å¼_gy\äY¢‚@%	,\Ä1’EÂ¯ñ§Ç¯\ë\Öÿ\0a‡Pš]øs\Î:E–š$¸–y¤Yµ³yQG‰BäƒŸ¾~c\rµ­^¿“kñI|ô¾¥uû¿;~Zþv8[‡o5«½\ZxŠm^Ì¢\Ü\éñ\èrµ\ÄÐºŒG¹K\"³ŽB’8Štÿ\0,¶ÑüIuvú|	ýžs-\Ê\r¿4Š]A\ÈÜ¼r+³øY«xb„8\ÒüM\â-KD·½\Õô‰>Ï£\ÛEusv‘¥\éeò¤žcc%²Á[\ËùNF;øÂšŽ‹\ãÿ\0\ê\"\Î\ÚMKXmO\ÃZz\êP\Ïwk~\Ñ\É;B¿¼P±H²yÌˆ\ZKhqœ\à9>V\Öö_ü‹ýZ^i_pZÿ\0^¿­¯\äy:ø_\Å\íq\ÂÚ¹šC\Z¤cI}\Ìdc\0lä°ŠR¾¾[\ã\îœE&ƒ\â˜|+‰¤ð\æ©†\æ*-a´\Ær>\â»Vm»	Ü¬0PGjõ¯þ\Ñð\ÏÁFøwsiªO\êb\ëWP=Í¡’;µ•m‹Kˆe‡•\Þ%»\Ëó+\'\Æ_´¿ü?[6òm#Q›G±\Ò/t´ð––\Ñ\Ü%¸‰OüL\Ã­­\ä$\n¬\î ªû\\·\Ò\ë_]þ\îþ~@¬Ú¿õ·üº\ÝO1º·\×,Zùnt‹\Ëv±¹[;±-†\Óo;n\Û™_•Ï–øS‚v7\Zµ\â\Í\Å>¸‚\ß\Ä\Þ\Õ<;qpžd1j\ÚcZ´‹œnQ\"‚F{Šö-Cö±±¾ñv¯ªK¢\Ç-™ñ•—ˆtø­t›+	\Ú\Úu¹n&…7I7\ï\â*\ÎdÁwdü\ÞiñÆž“Àº„ü3y®\ë°\ê·\Z¼º†½m¬Šò¢G\å$Q\Í0\éf¸\ÜHùFÜœù¯nß’¿¥®þ\ë[]\É}÷\èfx#G\Ô<y©_YX\Íio%žu©\È\×Q€¦;xZWQµ\î*¤ŒdŒ9®²\ï\á±¤x‹\Äú~±®hZ.Ÿ\áÉ¢¶¿\Ö\î\ÒV´ó\åŽ\Äp4\Ò;\0\çÀ‰À¯¯EðŒ<8<¯ø3\ÅoªX\é\×÷¶º¥¶§£\Ú\Çu,¬±\ìx$– \è\é3ò$R¬ªpÀ‘Vû®ß¯ù~(Ÿ^ÿ\0¦Ÿ\àüŒ›«k\Ãy«&”\Ë\â+1|\Ùõ-2\ÊCn\"Ü«\æŸ2$tBÌ«—U\ä\ÜSµ+;\í7\Ã\Z>¼^\Þ{\rNI\áC@˜¥„®ø\äÊ€l‘¿²/9\È	¦jž\ÑS\Æ–\ÚÇ‰\r¥\å—\Ùô\çµH\í\ÛyÑ¶\ÛØ„Ž<­ª\Çj»|\ê‡<Tþ\r\×ô\Ù|\âŸkwd¶¹u-6vWqü!‚¦	cy#\'\Ý\å’@Z›û·]¯þ‡M\ï§Rº\ë\Þß•¿½k\ÏkV>/\×<9%ÎŸö\Í\"\Â]JiBþ\êH£€O„;2Y”€“ƒŠ¯\âOø›Â·\Ú›¥\ÞE®k,hòiÝ\Ò\ã]’Â¾ar>SpsŒ\ç zOŠ¿h\ß\ëž\Õô\ë{-N›h¦kh†o\Ú‚õœ‰r#x\âƒ\r\É&ÊÆ±G\Äo‡ú¹ð‡R\Òu/\êMà»˜\ÜWš-½¯Ÿ\n\ß\Ív\ï-\äŸ?\ïB Œ\î*\ßÄ—M/ÿ\0“_ÿ\0müû›\äo®¶_%o\×ò\èpú—„|g£j:VŸ¨xOZ±¿Õ±ýks¤<r\Þ\ä€<•(™$}\Üõ³®|\'ñ\ï‡õoh÷Ô¤ñ·d÷öú:T†ý#YeŒ‡€\ÆÜ³ð\ØT\ç\ÓWÁ47L²´\ÖÎ¯5Ì—šô—šœ\n’\ÜE£gX\ËÈ¥\åWI”²†\r÷òÄ)~+ü?þÆƒÂ–\Ï\â{m\0øcû\nmg\ìv\íz²I\ï|Å·*´NJ©Œ\Ê\n\ç\ï>Ü²¾‹¿ü§\É\Û^·\Ófh\ÒW\×ú½¯óWv\é÷_¬X\ëþk¡ª\è·\Úaµ¸ûÀ¼\Ó\Ì^LûwyO¹F\×\Û\Î\Ó\Î9\Åji^ñÎ»&¢šoƒµ\ÝAô\ÕW½[]\ZIMª²\îS.\Ô;PXn\ÆG5\êúg\í-\á]?ûB\ÚM;W¿¶†=*\Æ\Â{¸\ãy\'¶‚\Þ[;·|Í¨ò[N\áÂ– n¬¸~3xX\Ö<Y/‰#ÔµO\r_\ê\Ó_Yøb]MŠ±8¾[\Èæµª*°ŒH˜Q•\r¢[kšÚ®\î\éù/—K‰t¿\Ïþo&þ}‘åº•ö›\á^/o=†§$ð¡† LR\ÂW|re@\r¶Hß‚F\Ùœ\ä\Ë\\ø\â]6\Îÿ\0P¹º\Ód·µÐ­uó$R¶$†qòBŸ ý\è\n\ä©À\Äm†<g“ðv¿¦K\à\ßøcZº6v·1®¥¦\Ì\Ê\î#¿„0TÂƒ,o$d\ã¼²H]¾µñúcQñœ\ÒjSxb\ãF’\ÇM´’(¼Ø®\Z\ÚC¹\r’€Ã72p£seÉ»I-\íu÷=>ÿ\0\Òû‰|Q¾×³ûÖ¿w\ë\Ú\Ç\ão\ê\ßÆ“½iw§__\Úý¤i÷¶76³Áâ‹¸M\ZnAŒºãŒ‚­ð÷\Å\Ú\rÖŸm©øG^Ó®u\Ú[8nôÉ¢{”U\Ü\ÍeÀ^I\\€9®\ÓXø‰\ào…Ú‡‡.µ\ÍrûÁ¯\Z\Ég¬\èðYÁv‹{5\Ù;\Ò\êbe\í*Flÿ\0\rW\Òü}\á/üb´ñž‹­xŸYG’ú\â\æMKN†\Ö\î)eŠEŒ«¥Ô‚F\Ý&YÏ—\Ó s€7g\ßW÷tû\×\Ýkn>Kþ\Ý\Û\Ï\È\å\çøg\ãK_[xroxŠ/\ÝE\çÁ¤É¥N·r\Æ2w¬Ew²ü­\ÈùO¥3Kø{\ã\rcÄ—š\á_kú\Ïu¦Z\é“Ium‚^%RÉ‚W¨‘Z?\rþ!Xi\ÚOˆ|=\â‹ýf-U\Ó~Á\rÞš«s-‡úLwd2I\Z²H\Ña\Ô:gv\ì’0{«_¿ñ\ìZ¥Þ®\Þ\Zn¥\Ý\ßS}Z;X\ÌbYÉ»­d\ç\å0HYCß–z\éýwü´\Ów{­…}ü¿\à~zù+k¹\æ\Z7€üW\â%\Õ[Ið¦»©$‘¨=:Y¾\ÆFì‰¶©òñµ¾ö>\éô«¾ð*x\Ãwúý÷ˆ4¿\é6·)f·\ZªÜ¿\Ú\'dwÆ¶ð\Ê\Ù\n„’ÁTeyæ»\nüZð.žº3\Éˆü;†¼Ks¯\é:~±\Ü%\Ìr4MM$¨\Ñ:<à²’¬~_—\æÌ¼ý¤¼Q7\ÂýC\Ã¾%ñ%Î°÷)mm¨Ê¶‘X¼N­j\0qòn|\ìÛ´õ\ëP\äù.·²ÿ\0\Û\Íú[[\ìRø¬ö»ý\Éz\ßKndø\Ã\àŸŽ|	\áM+ÄšÏ…µ{=þ\Ø\\›©4ù\Ò;\\\Ìñ*LÌQØ e9Yÿ\0+›ðG‡\çñ\çŒ4oX\É\r½\æ«wœ2\Ý±#;Ê†!FyÀ\'Ú¶<M\â_ø“áŸ…-\Z\çVµñ?‡\ì\ä\ÓÅ¨±ŠK+˜\Þòk0\Ï\çFv|¦¨ù†x±\àŸø7À¾2øs\â(õÉ®4»ˆ\îõ\è\îF‘&, ¾X_õ„\Ù\íZ])»\íÃ§\áþ[‘+òé½¿u\ï„>$ðý«<Ö¢\æ\ïûz_&Ÿh[‰n‘‡–¡~uq\"\í ’\Ù\éÒ¬øc\à?\ÄxªûÃ°xC\\´\Õ\ìlä¾¹¶¼\Ó.\âE‰\ä@\Ê²´›\nG3(šô\nþÓž\Ó|3\à\Ë]KG¼—V\Ó\î/c\Õn…­½\ÌsC-\Ø\á#˜•’T‹`1È¡Doœãš“\ã&Œÿ\0´kû\ÝRÿ\0WðÕ¦}£\îµð¾Ÿ¢\Íi\Ô71¿•km)‰öµÁ“\æu,K:\Ô;¦\Ò\×üùù.úYÛ¡¦–¿õñ—ùœ<\Þ\×,­|H/\ìn4«ÿ\0,3_\é:„Awr²§™\å²ð< \î þñ0\Î ð\ï|U\âý.óS\Ð|+®kzu–E\Õæ§Kq]\Ç{¢¸^y=9«^\rñ&‡\àŸˆ\é5µ\Íö«\á)\Ã\Ø^µÝ²\ÚOqg4~\\ù‰%”+\0\ÌW\ß2!\ëÀô\ï\ß¾|¾‰¯\ãR¾\Ó<D×‹ª\Øøv\Êõµ+$\"H\å¼\"K2d|Æ›\Û\Ì\0•*\n»\é/\Æ\ëôw\îõ¶\Ä=ô_ÕŸ\ê­\ÛTy&›\à¿k»ñ‡†5«\ïÙ–:µ¶Ÿ,–°\0°yB•\\	\É\ã\"‰¼\âk\nE\â‰|1­E\á©N\Øõ—\Ó\ånwÀ˜®\Âw:õ®\ÏMø…\à\é¾\\hþ\"ûwˆ5aº\ZM„š,P®›4Ž\ådPŽ\ìJ\Èy†)!t\'p\n	ó)5ßˆ~\Õ>\ÙXÞ­ß‰|_iokocyw¢EaýŸeK\Än!ºoµ\ÆLk\çC¸d°¾º\é·ü\ëku¾…5f\Ò\×\Ão\ë¿N§)uðÿ\0\Åö¶º5\ÅÇ„µømõ€£Lš]6eK\àT¸“\å ¹\ãµ§üñ\ÍÖ±›{\ámcB¸š¹a:¾=º\Ì\Öö\ïpñ&S-!D\á@\êËœšõ=[ö Ð¦ñÞ—\â;+\ÍB× \Ö\ïô+	iVO¢\ÈF\Ûø$YnY\ZWUi$zÁ¢þ\ÓzM¤Gw7ˆ¬Åœ6‚ö\Ò(\åš\×n‚ú{<*gND\îdr\är\â•\ß,µ[/ø;hþB_Okny‡‡~\ëzŸ\Ä+\ëŠ|®ß˜\Ò\Ö\Ù\ÝÛ™d‘\ÂF›Rq¸ž”/,+kÁesz¶W2X[N¶\Ó^$DÂ’°bˆ_ f\ä\É\n}\rzÎƒñGÀ\Úg><—~\"ÿ\0„cÀª“[Ý.\Ý\ïu	…\áºuh~Ò«\ì£\ÊF\Ý\Øù\ÈUø[¬øw\Ã7>8¿’ù5´1L–\Ú\Ã\Û\Ù\Þ\Ý_C*OlŠ\Í+²™DÌ¥”G,„²ž)ß«óû“\Ó\æ\ÖË½‡\Ýu\Ò\ß;\ßä´¿\Ìó\ÍGÁš®‘\á\ë\ÍVö\ÚKCc¨.›{cq\Çsk+\ÆdŒÈŒ£hp’cœ\æ6\ÈgZ†\â\ßÁö^ \ÖüM¢øiue¸\Ót\íC\íR]\ÞÄ„¯˜‰*+:²)•1V#š­ðÿ\0\Æ6\×> ñ§ŠõJñE¼°\ê7\Ò“Éœ·\r\ÉT˜¬Ê¤\àU¤­z\'¾<x{G\Ñô«CSñF“¬\éþ»ð\åÆŸ¤B“Xjöì“‹f™š\â#ÆŸ•\Ù(>Z°Á$	mò·\×þ¿\â—M¥\Ö\Ì¹­\Óó\Õ[ð¿\Íyžu©|:\Õt¿‡ú?‹Ý –\ÃS›ÉŽ\Ö\"\Æ\â,´«:\í\Ú†	‚\á‰>Y\ÈŸ\Ç#ø°j^(\Ñdñ»¬W~µûT—v®FYO [\îNŒf \äu\Û_ý ¼5}£kzŸ\á8l´õÓ´û}\'U7Ûšk&Œ\Â÷µ\Ë@ ´c@ß½\ï\Îyÿ\07„¾/ø\ËPÖ¼7©jZw‰uûÇ¾›H\×#²´Ó­¤pdœ\rF[µCnÙ¾$$½z¹^þ\î\×ü4·ß­ûi\ê(ü7{ÿ\0Wû´K¾§7ð\ÏÀ÷ÿ\0<Y‡´™­­ï¥‚iÑ¯œ\Çò\ãi\n\ä\É\Æ2FH\×Ocð\\¸±\Óõ\ÍCL\Òt»!µ»›Û¶™“O·$k\ç¤q<›˜\Ë	\Z¿©8¶\Å\á\Ý3Pø#>£¬\êwº\\’\Þi—zu“x{\Ä:v£,w\ÄB;¥½Ã² \ç-Ž¸\ç±¦|pƒT—\Ãú¦§\â\ïxW\Å\Z{_Ks¬xM†c;O2:\Æ#ûMº¬{C¸\Û\Ñv•\è\Û÷’m}}\ïøþl\Û\ïøiÿ\0\Ã\ïƒþ\Ùx\×\Å\Z¦‹e\ã\Ãö+y.£¾¸‹P]\Å/4\Í-‰’$D\'PÕy\áym¼+u\â(¯-o4¸uS¤¬ù¥-¤*º)\ØUxÝ†\äeEz.›ñ+\áÔŸ5\ÜE«\è:lšD\Ú\\hú¡7R\Ía%¤·O\ÜC±,þo•õ\É+‘÷9\áÿ\0x‡zŸ„µ½_\Ä:z\rpjVw¶\Z$Fh„-F÷‘ylr82z\ÔÉ¾]7²ûù¬ÿ\0ò]zz_Ezs.\Úÿ\0\é.ß¯©\ÊjZúo†4}x¼s\ØjrO\nw°•\ß™\0\Û$oÁ#l‹\ÎrA\âo†\í\àý\Ê\çSñ—·yko{†\Ö;·¾0\ÎDÅ„G(\Êû|\ì€pFï–¨x?^\Ò\äðwŠ¼1¬Ý›[K˜\×R\Ó.„wÐ†\n›T	cy#\' o,’\æ»&ø\áù>M\á)5½s\ÆWS\Û\Åo¥\ÚxƒKµµ·Ð¦2F\Ï%µÙ¹–DO¡Œ‘ƒ\î|mªý¼¾\îÞ·ü-{^\â[\ë\çúk\éo\Æö½¬y\ÅÆƒ¬Z¶¢³èº”-¦Î¶·\Ë%«©µ™˜ª\Ç.G\È\ä«\0­‚J‘Úºý\à?\Äg\Æú/…$ðn½¤\êÚ³¨u=.\â±\ïTi\Øl,\"BÀ³€BŠ\é¾,|E†\r\ÂV\Ñj‹m¬[\ËgªøV\Ñf‡Qÿ\0‰ŒqG\n\É«ˆ§dŽ/7‡\Û\æ\\L»úš§­|TðM—Ä¯x«D\Ò\î.¯´N=KY\Ô™’u“F\ê\Ò;‰¡€Gù£òÕ‹ò€\ÌE\ê“\Úöÿ\0ƒ\é{\ë\Õ[¾“+ò¶·µÿ\0\àz\íó¿mx»Ï†\Þ1\ÓüY…\çð†¿‰\'S$\ZKi“¹;\Ò\"»\ÙpŒrE>†‹?†ž4\Ôou+;OxŠ\ê\ïL}—\Öð\éS¼–ý\ÙT.Pû6+®ð\Ä?ü:ñ‡‰EÖ©©h:\æ–\Ö\Ú\Z—†¬..,\åó\ã˜±M<°NŸºU;¤Có*3\Ó\éÿ\0´µ–™&»\æjZ¾§5ÃŸ±\ß[\èöšN\Ø\×F»±€{yLqyoq	ùž¸Z›¾Nn¶¿\Îû}\ßð\rZ^Ñ¥µÿ\0^ÿ\07§‘\ášÅ\ï‡uK7U\Ó\îô\ÍF\Ù\Ìs\Ù\ÞB\ÑMª\È\Ø*}ˆ®¶\Ï\áÊ	\Ùk\Ú×‰´oE¨G,\Úuž¤.¤¹¾Ž6(]\Þ	B)udRŠ¶8‰|k\â\ïx\ïÅž/\Ö\ï\â\×a–\æ\Â\ÑR\ÙaUIQ·\ÚA\'÷{RLl;³·Þ¥\Ô|W\à\Ïx\Ã6ž ½\×t_xwO—L„\é\Úl7¶·°ù\ÒMb÷´,\ZgFÀŒ‚6\Ô|ÿ\0\áÿ\0¥§fB\Õù\Ã~\ë\Ý\Ôþ\rñ-¯… ñ4\Þ\Z\Öað\Ü\í²-bK	V\ÎF\É\\,\Äl\' Œ\Ô\Z“ÄžñWƒl ¾\×ü+®hvS\Ê\Ð\Ãs©i\Ò\Û\Ç$‹È¬\êaƒ95\èz\Ç\ÆO\nÏ¥k:•™×ˆ5¯\Úxv}\ZhbM:\ÑaXÊ“	KH1n¬±“k9ù\Îßš¯>?6µª|A\Õt‹\ín\ÃVÖ¼Qk­\éW\Þo—=¤0¥\Ú.²G<J\0B2\0©hôþµKòw¿\È#¬SÖŸ\ç§\âb\ëõ\r7Q\Òôk=B\×_ñ]ðˆ·†t{[Û‹ûa$\"a¼}œF\Ä!;‘\Ïb\ÜxZo^xGIÓ¯¼E­\ÛM$e\Ó,.Zi\Z<\ï\Ä/\ZL6\à\ä2)9ºŠ›\ã?\Äh\î|I\â\Â%\Ãs·\Ëh\ÂW1Û½\ÂFÈœ\âE\à\ä\äñ^›\àoxÆŸ\Z>(\êðja´Oi³\Ë%—Š£¶Ó‹¼·\Ð\Ê\Ð(:„)&Ð¡·}®;I\ÚÀg«kþ\Þü·\ëýXWI}ßž§ø‹Á~%ð„“Ç¯xgZ\ÑÊº„¶\æ3 s`\ê1¼G!\\õ\Ø\Ø\èjÖ“ð\Û\Æzõ\åå¦™\à\ß\ê7vRI\Ôš\\Ò¼Š\êªJ•Ü¹¦ážµ\êþ>ñG‚-µ\ï\è ñ\rö­cª\\i\ZœWž±¶•`6°M±#\írG…ŽeA2O>6w±j\å>\'|l´ñU¿ˆ“BmWN’ÿ\0Æ·>\'¶gaŽ7@!$£œJ§=8\áª´º\×úŠü//U\ì\Ó-­Rþ¶oü—•û¦q¶\Þñ]\ç…\æñ5¿…5\Éü9\ï7XN•¬\Ói\ÚÛ¦°`ðrx5¹\ã‚~9ð/…t¯\ë>\Ö-4}B\Ø\\›©4ù\Ñ-s3Ä‰32Gb”d\ådCüX®\ß\á\ï\ÇøO\áû\Ú\Ü\Ù\ß\ÂKq¤\ê\Ö7òG¡X\\=\í\Í\ÒL‘\Ü6¡+›˜\ÕVHÕ¢Œ(;Kdå•¼óÄž%ðÇ‰~\ZøRÑ®ukOhri\â\ÔX\Å%•\Ìoy5Ç™\çù\áÑ€†\ß)(>až½ì¼¿[þŸ\'®\ÌJÖ»óÿ\0úþ\n~2ð>¯\à6\Ò Ö¬¯,5J\ß\í+§]\Ø\\\Û\\D¥\Ùpš$\r»i \Æ]{d@v©ð\×\Æz&±i¤\ê>\rñ\r†«w\Ïocu¥\ÍóF€—tFPÌª‰ `\0}+¼‰¾ðÎ©ð«TÐ®¼A­\Üx5–)\íu-&¸\í“\ÝDº˜«ƒ0P\n‘ò\î\Ü>\íZ\Ñ~6x_\áý½†\á\Ëÿ\0j–ö\ï¬_.«¨[\Åis\r\ÍÞžö±,q¤ò\0¶;\Ë\æ{ *7vRk[^\Þ}½4ÿ\0-Äµiy/\Éþº[\Îû#É¼M\áýgÁ:¡\Ó|E¢jZ£°Iö=N\Ñ\í¦\Úz6\Ç\0\à\àóŽÕ¹ð\ÏÀ±|LÔ¯,ÄšO‡®-í¥»WK¢&Ž(žYJ —\îG1\rŒðq\âŸ7‹</\â6øka¯Ç¬.¡Øµ†°úr\Ä.]\r\í\Ìù·.J’#™\0ßŽA\Æ	±ð\Ä^ðŸŒ5KZ¾×­,\Z\Êþ\Â\Æ;\r6¹].m§·\Ý.\ëˆB”«awn —­=W2ÿ\0¾[}ú~!§\äe\é_<O\âU½ŸÃž\Ö<O§Z\É*6¥£\é·Û°ig`*\0to˜)\× fª\é¾ñ6±á»¿XxcZ¾ðý™as«[iò\ÉkP”)UÀ œž2+³ðG\Å\í\'ÁvþÓ’]Z\çLðÿ\0%ñ\r\ÈX’?´\Û\â\Õc>_šW\Î\Û\ß)8fM\Zo\Ä/Ið¾}\Ä\"÷\ÄðÁt4›	4Ha]6iÊ¼z„wBV@[\Ì1I¡;€PO™I»Eµ\Ûôþ—\æ\×Fµµûþ­~O\ç÷\æx\Ã\àŸŽ|	\áM+ÄšÏ…µ{=þ\Ø\\›©4ù\Ò;\\\Ìñ*LÌQØ e9Yÿ\0+\'Xøy\âo\nÿ\0fK\âjþ\Óõ	8ukM¸‚Üƒ‚\\„¸\0\î;t­x“\Ä\Þñ\'\Ã_	\Ú=Æ­m\âo\ÚI§‹Ac\Ù\\\Æ÷“\\y†8<l\ì6ùL	Qóñ\èÿ\0~2ü<ñWn|+¡[jZF›y®\Ù_¬pxkN´‘E<m\èe^H<\ÐD“¸-ƒ‡%œ´½»\é\éò\×\äÓ³köü\áÿ\0\Ïc\Î<A\à(ü/\ã«j$\Ò\"·¸¶·»MqRé¬¼™\í\ÖxŸ?•uò²	\äcš/¾\êV>6ñ_…MÅ¤Ú·‡Vñ¦X™\Ê\Üý˜“0‡\ä\É!\äù‚ü¨\Ýð·\Ä}w\á÷Œ<g \ÞY\ëž&‹J‡L³Ó¯eŸ@·\Çö[H GŠ1zVO0Å’\Ó`<\ÅEñ\âV’>;]xÿ\0Á·:•\Äw\Z£\êþN¯d–®Žó3´G4¡\Ói\n[+¸3\r£¹\Ù\'¿7\é\Êÿ\01½¯\Ö\Éÿ\0šû\Î;{©´Ùµ\ìnŸO†T‚[µ„˜’GQú`Ž@\'$+c¡®\ßÁÿ\0¼K\âöñ86ë¡ŸZKsxº\È{v.‘<\ßgE\ÚX\Ì\Ñ\Å+ FÄkW\Ã>7ðG¼y\âK2/5Ï‡ÚƒÁ{omoeYb‘\'‚7”\ås%»°þ”7\Ôð\í<ºZµ¿Š|%¤kñ·ö\Å\Ó\ßfñ.§»¾·–6iDwQ\Æ\ÊK\"³rÇ»a\rƒJ\íÅµ½Ÿ\ß\Óñ¿\á½ÁZþWþ¿OÇ±\â¿nOFü«Óµ/z\æ\á\Ýk\íº}\Õæ§\Û\êÚŽ‡ngk\ËI\ÊùR\ÊLB‘$m±e.‚Ta¶ð°\É\ái¼+¬Is©Š\Z\î&Ó¢´(tô·;¼Õ“y2\î&\Ì\Æw\Z÷~\Ñ^4ð´\Úeƒ\Þ\Û\ëº\æ™o¢\Üi7	og¤\Çqˆ£’þK£>e‘–UóQ‘€}©†|¯•kÿ\0ÿ\0“þšK\âWÛ¯Þ¿Kµý\'ó\â]	Q\Ý\Ø\à*Œ’}+´ø¡ð\ÏUøIy£\ÚksZIu©Xý·É³”\È\Ö\ÄK$O¹\0	Q\âueRÀŒ\ç5Að\çˆ~	\ëºw]<­\"uš;/øI´ýD4¼‹[³+mb+Ð¨\'G\ÅŠ\Ú\Ä}/Á6±x^\ßB“I¶–Bkn¤w\ßw<Ì±µ\ÅÌ»—\î\Üÿ\06öq¡@oT¹w¾¾–\r®\ßcÀ~\rŸÇ—\Z™Kû-L\Ò\í\r\íþ«ª½´[\Õ°‰FfwE\nˆÄ–\é€Hg\ÄO\ê_¼O.‰«¢™\Ä1\\\Ã<!„wJ‚H¥M\ê¬+†Ua\È` v\ßþ*øKá¿Œ<gk£f/k¬Zuýõ•µ\î£c$r¬°N\ÐHeu*\ÃÀR\Ê\ã”\0\æx¿\â…>$|H:‡‰[\ÄshºP°¶º\â}J\êX¡+÷FeÌ’üò\0\Ì@b1Œ\ÊN\Ñk·ùþ;i\ç×£Ž\í?\ëo\Ã}|ºu_‡uo‰\ZmÕ¦¥¦\é²ê—¯¦\éw\æo?T¹DVx\áD\áB\ïŒ”Æ€¸ù¸ly\ÕÔes-¼ñIð¹ŽH\Ýp\ÊÀ\à‚=A¯løEûA\é^\nð>“¤jO«X\ÞèšŒ·°I£\Ú\Ä\ï©[¹\Ú\ÆI\ÞTkh\ÚH†÷dÞ­†R\åwZŸ‡u­\Ä:†¤º¢x\Æ\ïP[‹5µòÿ\0³\Ä.]§ný\æü•Û·Œg=©Éµ-6ÿ\0†ÿ\07~\ÖùµV»ÿ\0\Ãÿ\0À·¯\ÉvZ—À½sNð\îµö\Ý>\êóN\Ó\íõmGC·3µå…¤\å|©e&!È’6Ø²—Á*0\Û|\Ç\í\É\èß•}	\â\Ú\"\ËÆž›L°{\Û}w\\\Ó-ô[&\á-\ìô˜\î1r_\ÉtgÌ²2Âª¾j\"Â²0µ0\Þ_\'À¿\ÆPKÁ\Çsm|m¢Ÿ\Ï|sC¿;¶\ßð_\éo¿¦ÈÀ¯¿üú\ß\î\ë»\ÉðG†/~ kÿ\0\ØúR«_[«¤I|\â$•B‚KŒ…\åˆu®ƒIø?\âIµ­OO\×\í$ð:\éV?\Ú:…×‰í§µKXª#2\ÚV\Þìª¡‰\'¦#[À:m\ÇÀ¿\ZXø‹\Ä:¥ŒV[_XŸ	\ëºn«{o$ösB’¬P]\ämg\r’\È8\Æ\ì‘]_†ho\rxN\Þ\Û\Âö?\Ú\Ï\á«]\éöú\åÖ—o5ôWlkµºm7•„wdTiŽ%\r¸\r½¹{~>÷ÿ\0k\ëpþ¿ÿ\0\îùe\ÇÁ™ô\Í\á}{\Ä\Ú?‡o\Ê[Ke-ü\ï£\ê\Z\'‡Éµ‘À*\Êq*¡°@!€\Ë\Ðþ\Z\\\êZ·Š,õ_Mðí·†Ø¦£¨\ê&i-\ã8B~\Ï®\åœñµÀ$v2|kÓµO‰#4ñ¿„Í¥¶—k}¤\Û%\Íþ§`yv\íyÆ‘”9Pe\\¶\í¹jö?´Ö³¢i\í<9©kž\rµ\×/\ïG\Òô=BH­t\Ì\Üy’*\ítÙ”ùrŠ3Œ`*n\î¾š\åü5~}S£ù~^÷\ãÿ\0\ÎwRøii£øB\×_»ñ¯‡\â[\è\î&\Ó\ì<«ö¸½H¦xw&-|µ\ÞÑ¢GC‚7ªv>Ž_Á\âmKÄšNƒÜ“\Åcg|—OqzbÙ¼§“ˆ£.22dƒ\éš\èüñ’/\nü<Ô´Û¯ø³[{\Û\ËC\á¨WûdŸz‰Ëµ\Ënd,&O˜£\æ\Ühø\ÃöñGŠ>øo\ÂRø«Ä·	h·1\êP\Ýj2µµ\Ôl\è\Ð!_0\ï\00\ÂñŠm´\Ú\ßúð5\Û^¿\Þþ\ï\êÿ\0ðnSñ_Ã‹oø6/Xø\ÇBñ6Ÿ%ÿ\0öv\Ý.;\è\äó|³! \\\ÛBTm\ÉRp]3÷…K­|-\Z¡¦i—ž,ðüZ\ÍÐ‰\î´ù$¹‰ô\ÔxDÛ§‘\áXŽŒ¬O#–!UY¸ª(ø˜ao[x:\ãP\Ð\í|5fµ\Üoö{¦½“sqº6%I‘p\Ùòã¡È­¯ŠŸŸ\ãG\ÄH\î|E\âŸ	§–aŽ\ãý:[B EvŠ\Ý\çT\Ë:s‰ \äó\ÅRø­\Òÿ\0‚ÿ\0=û\ÛM\Å\Ñ_·õ÷m\êEÁI¾0\\ü:—X\Ñm5K{¥´kû›—KF‘™Ue<\×,Î *\Æ[’H\n¬G=¤øÄž#ñ.£ \è\Z§\â=JÁ\äY\á\Ñ\ì\åº*ö\Â)!wc’Q^‡­üIø}«~\Ò\Ð|A]G\Ä\Ñ\èK}®Ð\Ü\ÜùñH\äûfÒ…Sýfü‚q°\ã5GþÏ‡÷Pø\ÇE¼¼ñ8ÐµMn\Û\\‚\î\ÓN·Ž\ê\ã\ËY\ÃZ\Í¹es9\Û(i6\íÏ–w`M7ðs|þøþœ\Ï\Î\Þh}eò·\ãÿ\0y_É•õ/òxv-müC\ãxxiz\ÍÖ„E\â\ßJn.mÂ™<¿&\ÖO—\ç\\\Û×¥E\á\ïz\ç‰|1oªZ\Þ\é\ë¨\Ý\é÷:µ–€\Æv¿º³€°–u\Û‰1É$ˆÍ°\í+»¯\Òhm/Iø‰\â\ß[øŸ\ÆVz^£¯]j©\à»x#þ\Î\Õ\"v\Ê\Åzÿ\0i\Ú7ƒ±Ç‘(\Ú8\'<ý¦4\í\'Àz<5+MwI\Ó\'\Óci\Z\Ùj¹óE¼—7>h•R;n#d/m\Ê\\•‹\Ë\Ù\ß\íY~Nÿ\0ù5¾]·T­Ì—Kýúþ\Zuüö<–ÿ\0Àž*Ò¼3o\âK\ß\n\ë–~¸\Û\ä\ê÷\Zt©i.ï»¶b»{`óZú\ç\ÃV±ðõŽ³¢øƒKñ}­\Õúiž^‹\r\à–;—B\éK‹x‹–\0ÿ\0«\Ý\ÈÁ\ÆW=\Í\ßÆŸ[|\Õü1¤i÷–zŽ§ \Ùi¯z„H—QO³\Ì÷\á\Í\Ô\ë#D\ì¶ªd\r¤\0W>\ë\âÇ„“DðÆƒ¨\ßø—\â>‘§\êöwL|Ij–­§\Ø\Â\n\Ëgh«u9\Ù2°7¢&?”žW^­y«z__\Ã_ø*\Ï=yTº\Ù\éòºütù|\×%\Â[ø»IðÖ³ \ê>Õµl­Œ:õ”Ö†\á¹\n¨2K01¹†H\"—€üs\ã\Ë\ÍQRò\×G°\Òm\ZûQÔµ!/“ius,I$„—‘F9l\0$v\ß\Z¾2h.ðÏ…´¿=\äW\Z6§}¨}«û\ÃDD\Â\ß\Ë\Ãf\ÅC\'’r\ìKz*\Ãÿ\0	ß‡\í>(\Ziž2×¼u©Z%õ\ÃxgMûD¶\×\Î\Òm\ØIqn¦&`\Î0Î»]TƒƒˆŒ›W~–Ÿðzh­¹r\Óo\ë[?½Y¯ö<ÿ\0Y\Ñ[N{\é¬g\Zöi4v\í­iöó‹6‘Ô²¨ic”¯€Ê¤\ìb5£¦ü5ñ¦³>©Ÿ\à\Ï_M¥`j\ÛisH\Öy4>_\0Ÿ›^³\áÿ\0ˆ~¼ñ|CýŸ§Yø%¬-\é³Iig>¡©Z˜ž	—O‰¾Q4‘²È±)Ž4¸—\çõ\ä¾üOð\ÌZ6­\Ä	\ïüGmy¨K¨É¡)’y\ÝW3-ø»Š{iŒ6\Åu!T²\É÷Av“\ïkÿ\0_‹µ“³Ž\×\Ð\Ýù_úû´W»ë½µÈ“\àŸŽcøqi\ã•ð¶¯/‡®oôˆôùÈŠ\Ò7ûC¶Í‚a_v	ŽO\î\×?ÿ\0_‰¿\á¶ñü#:\×ü#÷2ù0j\ß`—\ì’\ÈX¨E—n\ÖmÀ®\ÎA©k\âoj_\ãðÞ©s«Xk:n§y©XK®m\î¼øm\ÓË•\Úh\Ú,qó*É\ç\å\ãŸBÖ¿h#RðžŸ•\ÝÆ“|4\í;M¿\ÒaðŽ–\Éq±„ja\Ö\çky	 FC†w`­4\æµôºûžÿ\0\å\äCmE>¶zz~\Zþ™kÿ\0|c\áM5µoÁþ \Ñôõ(\Z\ïP\Ó&‚ _;wP>ls\Î*—‚ü7}\ã\Ï\Ûh\ÚZ ¸˜<5Ä‚8`‰¼’\È\ç…DEfcè§©\â½g\â¯\í¤xû\Âþ \Ò\àX/~%0À›\ßX¹½,q!Á1M’ùŽ€1\ã¼+\ãx\âµ\î‘k¯^xbóG“KÕ£¾hVð5Å³Ctðù0¬\å£\r\Ô(FI¬£)4\ÛZ\ëo¹\ÚþM¯\Ä\Òi)r§§+þv\é\äe\ÝxK\ÏYh\ÞÔ¡ø‡¨]FÎ°øb\ÆúInI_.kxœœ\ß*\0\ä\ÔZo\Ã_\Zk\Z\Åö“a\à\Ï_j¶2ˆn\ìm´¹¤ž\ÞB‚HK#Žp@8Vô5\Ñxo\Ä?|*¾#Ñ Ö¼Qw£x‡KW\Z¨\Ñ-\í\î\ì\Ý.\"™BÀ/fü ¬±žs\Î0t<sñ\ÇNÖ¼\'­\è:Ck\Å9\Ðí ººeY.\íôø.#/p\Î\Ög’&XÁp»\0\ÜJ‚tV\Ó^ß›ùv\êN®ÿ\0\×o\Ï_Kyœ—„|?‰¥\×Mö£g\ák=5mBóZŽ\à$Ò¬KHb’M\å\Û	\Æ\Ö\Î1L¾ð¥a\àû¯È“`­è²³\Ô>Áv¶ú‹eÁh&hDxY%]‘ùû¤†\ÐõÚ“X³›\â’øo\Ä^(\Ð\í<GªýK\ç·[=\×FY*KˆÙ\à\ì\ÎO\ãš\ät_x2?ƒž!\Ñ5c\Ä?ð“j·\ÖÚ–\ØôxeµY-\Ò\éQ\ív®DŸi¿—•\ÚF\×\ëY©IÃ™\è\ì¿5\Âÿ\0ð\ãÓš\Æ5¿Ã]x\\øšx‚o\ÚS¬G¥\Ì\Öa\Í\çÙ€A\ç‚+5¼;­%\ÕÍ³hzš\ÜZÝ¦Ÿ<&\Ñ÷\År\å‚@\ÃY£€‡“±°85ô§Ä©|5}ð\\\Ïk\â\Új-\á\Í&\Þ\â[im\î®upl³`º‰–2A-ýŸSö\îw\ä¼Añ»À\r«jzÆ’ž$žÿ\0ZñžŸ\â›Ø¯,\í\âŠ\Ú8Zá¤‚2³1‘·\\;l1•\\d\ë§;ú\ÛñKò»ò·š¼]û5%½¯øm÷\éÿ\0\í\å—\r|ii{¤Y\Ï\à\ÏCw¬\Úm¼š\\\Ë%ð\010©\\É€AùsÁ·á€ÿ\0<U\â«\ïÁ\á\rr\ÓW±³’ú\æ\ÚóL¸G‰\'‘(B\Ê\Òl)@Ì j/üM\Ó?\ákÍ¬ø _\ê\ÞŸQ½Ôž\Æh\Ò\ï¤‚+†·•\ÄRº¹Š»a\Âm$ƒ]¶½ñ\Û\Âz§üz±ê¢\é~¾ðýõ\Ä:=ŽŸ+•¼C46–î°¨Qt­\å\î*Ab~s”d\Ü¶¯§\É\Û\îv]µõ¶­%&¯¢ÿ\0?òþ¶<ûGøW\âOVÖ´ûV\Òd\Ñ-\Ú\ãU{\Í*í…‚ˆ\ÚEó\Ö(\â\Ü‚\êœ’$dxoÁ¾$ñýÞ\á­g\\µ\Ó\×}\äúm„·	l¸\'22aX\ä\ã¡ô®£á†¹\àø\×X¾¿\ÖüI&—ö»-ôvšasg5»¼±›Ð±l2†^M\àrR¶|ñ;Á~\Ó|9m{{\âh\Â~ ŸZ\Ó[M³F¨\É*³\æqöi?\Ñ\Ôo_?\n\ä`\í¯ª»\è¾ûë§¥¿\à™»­•õý4üzœ§€üU¨xroZøW\\¹\Ðaˆ\Ï&©+Z¤a™K´¡v…ÜŽ2N2¤v5\Î}¶?Fü«\×\á{X\\]øi\î \Ô\ÏN\Ð5\Ý:k(ö´Ks|\×\ÅZ5.Áö›p\Ì@?º<«Ÿ2ºÿ\0„cþ»³ÿ\0k\Â[ö\É~\Ù\æù_`û.\Õòü¼~ó\ÌÝ¿v~\\c\ên\ï·õv¿+?F\\’N\É\ßþ¹q 4sÈ°^[\Þ@¬Dw\ï	*\ç‡P\ê¬Ày\0ñLþÃŸûñþgü+±ð—„\î<]«[\éZ\0–ò6»¸¹ŒBD#\0K*†`œc 3rpg³ø¡ðfóÀ6ð\ß\Ú\Êú–”URiöa¡“\0ÀtV=l\í<àµ¶<SP­¼ˆØ‚\ËnŸyª[\\øròv¶1“qor$\ÖñÌŒ˜FÁYyô\íN\×\ã\ê?ú\æ?™¬}cþ>“þ¹Gÿ\0 Š¸\ÎT\ß4™2Œf¹d®\ÏøXW¿ó\í¥ÿ\0\àš\Ïÿ\0Qÿ\0\n÷þ}´¿üYÿ\0ñª\å(­þ¹‰ÿ\0Ÿ’ûÙ‡\Õpÿ\0ó\í}\È\ê\'ñEßˆLóù	\r°šHã·´†\ÝC2\0\Çªä«\Éþ\íf\Ô\Z?ü}?ýr“ÿ\0A5=a:“ªù\æ\îû³xB4\ã\Ëe\äQEAaEP\áÿ\0–¿õ\ÊOý\0\Ö5l\Ãÿ\0-ë”Ÿú¬jLÿ\0Àþð\î±\à½c\Ä\Þ%ñ©£YX\ê\ÚtqiZDwòK$\Ñ\Ìáˆ’\æ\0ª¹\'p\â¶uÙ¿\Åð˜kú>€°\ëºn¥&—owwum§\É2€\Þ\\\Ë02Ë‚¤\Ç‘†õÄ¹\ã,¼eö?‡šŸ…þÇ¿íº¥®¥ö¿7<˜§f\Ìs»\Ï\Îs\ÆÞ‡<z…\ç\í£kº\ê\êúß‚ç½¼\Óõ\Éõ\í[\ëDpK/”\Æ+‘\ä1ž0ð\Æ~C}á»‘Û™\Ûoøýyº¯\ÈZò®úþ¶ý;œ-ÁOj¸ñ,_Ø‘\é6\ß,\íq\â-:¡rˆ\ÞœJ²0ŠM±•\Û¨®¾\rxº\Ï\Âg\ÄR\é°ÿ\0g-´w²F·ö\íw¼„\ç’\ÔHgŽ&,¸‘)¤0\Íi> \Ís\á/\è÷Šóëºµ®­%\ÒÉ´FÐ­\È(!\Îs‘x\ëõŽ\Zf¡¥\êw6þ–\Û\ÅÚ¶‰ª>§\æZ4¬I¾+o(2J\Ë`–•\×ïƒ#l\ëg/\Ë_\ÇKü\ì\ËÓ™%·üò\×õG!â¯…^(ð=„·šîšºl	zúxó®¡\ß,\È?y\å r\Ò\"ð\ZD@¦ü4ð/ü,¶Ÿ-ò\éZ}µ¥Æ¡¨4F_³\ÛAI+„ol.r2Ì GWñ£\ãŒ%{ý[D’r\Ùlu¿\ß\åX’XZÊ†?\Þ\ìfb’„*C\0›9Ï„.þø\Ú\ß_µƒ\íJ\"–\Ú{uF\ÏˆU¶9V\Ù\"\ä2>\Ö\Ú\ê§$zß³·­´üwýwpöVùýúþ~6\Ùu?gMoÁ\íiq¦}£Q\Ó\î´v\Ö\Äz”0\ØjÀ®VA%§!¼>\Ôg>[;@`¹>øSeŽdð¯Œõ¹ü5«}¦\Þ\Ê;]6\Î=R_>R\×2\"\È7™ˆ_,\Ûv\ßö€M?\Ä\Zn«¢h×–S\è6’Ç \Ï{©‹›‹k¹¥i&¼¹BŸi´’cPvd>\Ö/…þ6xOAñgˆ<Hþ\Ôb\ÕõKu\Ýizò[É¦Ü¹&\ækS%¬»<\Ì\á2¢¶¹8e#£Mùþz~\ç­\ÚC½·\ÓòWýz÷ZY9rºÁ?\ëZ¶«§\é±i÷rX_É¦¬©\Û[-\í\Â6\Ó¨šD7÷~Hƒ7Îœ|ë›¾ø{\á/xC\\\Ô\Ä\ÚÝ†¯£\é²_][Ë \Âl•\ÃŠqö\Íù‘\Ú4\É\à±\ã\nMt~ý£?\áð¥ç†¬‡Œ´­ jsj2xs\Å\ÇLºQ*¢˜\î]m™.\0¡#Œƒ¿³`pxù\×\á\Üþ¶´hd¾\Ôÿ\0´u=A\ç\Þ÷›l‘´mT/3N\æ6ŠTm\äµó\Òÿ\0v¯\åbôæ¿Ÿ\á¯\ç¢ùž…«þÌ·\Zw€õ½^Z\ê}cA\Ó\íuV\ÒM8EcRAoÑ›2\Ü$r£´~P\0\Ã\r\Þ5¥\é\Ò\êúµ”s\\H±#]\\Go$\à’FTA\ê\Ì@\Íz÷Šÿ\0i	¼S\áCm.“r¾\"›GAŸP—PY-ª”24žPò¦”\Å™!‘òwªXmòM\Z\ê\Ú\ËV³¸¼Š\ækH¦W–;;o3(9!$(\áÑŠ¶85§ü¼\Ëÿ\0þ¶ú\ï¹\Zû5ü\ßð\ës©Õ¾ø“D¼\Ñ\àºm\ËÕžX­/añŸ5›<aK«Ü¤\æ\È¹\ê~eõm>ø\ÊMb];\ìºZ´zpÕ\ë\ë¶bmL¢5n\ÌþC5‚p\ä\î\È\ÆA®\æ\çöœ·—\Æ\Ö\ßF\×uwÐ¾\ØM÷ˆ|D/õy<ø¼´\Þý™<¡	ý\äC\Ëm’37~4¤ý®Zo&¦\Ö>,‹g†‡F¡‹\Ük}¸]y\æù­\Ø\î8òÊˆÀ\ÚN6Œ(žŠþ“·\ão¼®¿w\ç¯\á©\å‹ðWÅŸð_hò\Ûi¶—Q\Ã,\×7šÍ”[fA$;n\Þa™\îP®K\0\Äd+b\îû=ø÷]Š\âK}|NM–ûRµ´v¾Œ)kdYeS$¿:\á\Ü\í\å\íaqk«x‰\Ò\Ï\ÄZeŽ®–[®´5†°ò\Û# –\âô@\Â\á¤9“tCsl#i^k\é?|1¦økI\Õ5gÄ¾-\ÓüW¨k\Ö1\ß\ë\'÷E\â³ò$¼\Û\æ\ë/	È\ác\å¶v\ï~¿Ö«þù ò_Öþv_\æyÞ›ð_\Æz´V\ÒZ\è¬\ëpÐ¬a®!BL¢s!œHµ¸\ëŒy|\ã+š\Ó|(ñ]¾©\êÏ£\È4\Ý6\Ê\ÏQ»ºFR.Š‹v$7W\Ü0£\æ\ë6œz×…ÿ\0j=E\Ð\ìc\Ô<©jZå¹†W¾^Žd–x#o$\Ú3\0~\Ý&\á\ærUpWœ\ájß´‹kž\Â÷z‹BþÄ±\Ò&†\ÎôG,\ÒA-³=\Ë9‰†÷Ž\Õ#PT„ü\ß6\é\Ö\íy\é\é¯õó\Û{\Z]v¶¾ºÁû¾þ?Wø\'\ã\Ã\Ö\Z\ÕÆ›o-óÙ¤1Y\êV·7[®¢2\Û+\ÛE#M‘²‡AœS5ƒ~)\Ó|Ma\á\é-ôéµ›Æ‘\Ò\ÓY²¸hc2ƒ\Ì-ö\0Ky\Å6…bpã¨»ý¢.—\\Ôµ=3EŠ\ÂW\Öô}[NŽKƒ*ZG§E,P@\ß(ó2®™o—”<|\ÜP³øŸ\áoüB´ñg†|+«X\Í\Úe6z–¾·q4\Ò+òV\Ú&0©c¾\'-\æ/\Ê\ÌlÓµô\Ûñ\Ù~·_/˜ºy\é÷õùmýhr>5ð³ðþ\î\Ê\ßYŽ\Ì\ëaym5†¡o}\ÑtÜ²Á#¡ù£q\ÙM/ƒ¾\ëž<{\ß\ì‹{sŒk-\Õ\åõ\ìV¶\ê\Ì|\É\çtK1Â‚À±\è\rhüKø›sñ3þ\É.ôû;\'Lþ\Îo°[CmØžiw¬0\Çqñ.6¨\ä©9\É4ÿ\0øóK\Ð<?¯øw\Ä:5æµ \ê\ïmpñéºŠ\Ø\Ü\Åq-\ÖF†e+¶iT£!\Î\àAh]o\ço¿O\Ãú]\Ò\Þ_ðN>ú\ÎM>ò\â\ÖV‰¥‚F‰š	RX\ÉS‚UÐ•a\Ç¤ƒ\Ô+¦±øS\âK\Ãÿ\0Ûéªº7Ø¤\Ô\rô\×P\Å\nÂ’´D–w\09‘3ó¹Uj\æož\ÞKË†³ŠX-\ZF0\Å<¢Y3ò«8U@\ÆHU\Ï\\•\éñürŽó\áN™ð÷Y\Ð\ä\Ô|?ao+B#¿òdŠø\Í,‘\ÝF|¶…™£x\È`\ë\ÝX#,\ë\Ë~¿\×õý]=9­\Óúþ¿G³ç®¾\røº\Ë\Âg\Äré°9m£½’5¿·{¸m\ä G<–¢C<q6\åÄŒHu \á†lj?|i¦húN¥&•ðj²\ÚAk\r–£msr\Ò]Fe¶F·ŠF–3\"\r\ÊW5\Ù\é¿ü/®jQ[\Ã÷ZN¥­\ÙY\è\Zö¹¤e·K0\Ç,\ÐZˆ$\Æ(“$‹\ÄG\È\×]~\ÒYµ\ÝOGðî§¥j¶šŽ™ª\éP\ßj\âò\Ö\å¬ÀµŽ\ßb\ÚDñ\Çöi$9i7e’x6\í};þºþ\Z§\Þú¯\Ëw¿\ëm?§ò\Ôò¸ÿ\0g?\ÜkZv—g£\Ú\êwZ‡\Ú³iºµ\Ü.ð&ù£ó¢™£YpLeƒò8\äg”ñ\'5\ßiºþ±§½•®·kö\Ý>Gt>t;Š\îÀ$¯#£\0qƒŒO¥i_´™\à›5²ðW…\ï4KH\ÅôñI}¬»¨\î\î ¬«\"Á\Z„\0Ú7I.x™ø±ñ’û\â\ìZLš„—¶/qóZ1XR2˜\áŠ,~\í#U\Ú\æ$u5›½Õ¶þ¿\àOKV³¿õ\çý~š\ÛøKði>\"\é÷\Zö¡¨X\Ùý¾\r&\ÒK\Z\Ý\ÝÜª\ïµb3D¡8\Ý\Ëð6ðrq\É|BðU\ßÃŸ\ë~¾š›­.\é\íš{f\Ý¸<:Ÿ\î°ÁZ\êþüa‡Á^ñ…µ}6ÿ\0Tðö³$SM—©.Ÿr2\ny\ÆsŠ\Øt\Ú7lO˜`ƒ\Èx\ã\Å÷ž>ñv­\âø\á†\ïQ¸i\Þ+u\Ûy\èŠ2N\Õ\0’O’yª•ùýÝ¿\à/\Ö\â\Â\ï¿ü?\ékß®\Úm¥¦øF\Æ/‡\ZŠuY®\Ëwý™¤[[•_:\áUdšI	÷q\Æ\È0¼–™9\0ú¥û0\Ü\Úø#X\Ô\íõ{‰µ­\Æ\Òÿ\0TµšÁ`°‡\í‹x\ï\Zo\ÞN‘\ËºyJ ù\Î\î\"\ÃÄšN©ðŽó\Ã:Œ\Æ\ÇR\Òõ\Õô©¶3%Ïœ‘Eqn\ÛA\ÚØŠV<|Ž	…v&ý¤_\Å[k\è\ë\ÓihW7Í©+ZEd2µ½¯“û©\åò£\ß!‘Á;\ÈQ‘µ\Ë\í[\Ê\ßw\åÍ¿^\Ún£ö[ó¿\ßÿ\0\È\í\Òû\ë·9¤þÏ¾1\Ô<M§\è\×v\Út—š¼z2\ÜO{G\æ´k)t\Ø\Ìe‰bt\Ée\n\é\ÏÎ¹\Ôñ\çÁ3Àz/„üZ—ú¶µ\à\Ýbñ\àcua—}$q•&H\Ë8ò\äB|¹©V\Ê`\r\×öŽd¿ð\íÝ¿‡R7ð\ÜOá¥šðÊ–¶k%¥\È)þ²m\ÜXyd4’ò°E\ÌøñR\Ë\âuÆŸ£\Ãß‡´‹UõCQ\×/Î©p\×„¥y#‚3\åG(X\Ò2@\r\ËeB­t\å\Þÿ\0üŽÿ\0Ž\Û=5Z†šómoó\Ûðõ\ßMŽC\â7ƒO€¼_y¤-\Ú\êª±\\\Ù\Þ*…ûE´Ñ¬°K·\'ih\Ý	\\œFx®f½\Åt{â½žµw¢Í®øKN–0\é77-k-Õ´Ihò&Ln\é,W8,q\\¡4\×2\Ú\Ûý’\ÚI¢·\Þ_\ÊBI¸òp02z\â’\Ù^—õÿ\0?\"\Þúù}ým\äŸ\èW¢Š*‰\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€\n(¢€;½7þAö¿õ\É«_Mÿ\0}¯ýr_\ä*\ÅPz\ïü}Gÿ\0\\\Çó5¬\Ç\Ò\×(ÿ\0ô[\Z\ïü}Gÿ\0\\\Çó5¬\Ç\Ò\×(ÿ\0ôC\Ø\nQEHôøúú\å\'þ‚jzƒGÿ\0§ÿ\0®R\è&§ª[\0QE\0QE\0ø\å¯ýr“ÿ\0@5[0ÿ\0\Ë_ú\å\'þ€k\Z“\Ôþ|9\Ñ<wg¯I{î»¬\Úy\"\Ã\ÂúV«{~y‘\ây¢—\Íd£È\ZG2d}\ÒmŸÁ\Ý[_’\Þ}>8ôû{rm\ìõ›\í\Z[¢ù™»>R\íQ—ÿ\0,%;Wn+Á\Þ.\Ó|.³ý»ÁšŠdwWŽMb[\å0\ã<(·¹„{\î\rÓ·5\Û\Â\ïøk\ÇW—×—\Þ0ñ”ù½Sc6–ƒ.\Zx¤W,\Ò4r\Í\ß-\0IŸ\æcŠR\î»|º|õ\Öý·Zhó\ïþ–\Ïm\Ì¾\\\Ùü:\Æwšþ—g¦\\\Í4\É\ë½ó\ÄpV7Kv‰\à’\É`d¨©ñ\á…\áOxGY\Ó|m¥\êúŽ¯§›§\ÓaŠ÷Ìþ\×49ƒ}¢ U€\ÂGY\\®T¦s<+ñŠ\ëÁ>Õ´=A\Ò\í.uk9tû\íag¾ûE\Ä2¹^/´ý™°¬TfŽ|\ÃuP¾ø“&¥\à}#Ã·Z•5Æ­†¹þ—¶ñ4\í9Œm˜B\Ã|’rñ3\r\çq‡¥\í\Ò\ë\î\Öÿ\0£\éé¦¢\Û\Ï_ø\åùùz6§û\Z|@\Ñ\ÛDK´·´—R\ÔaÒo-¯mR\Ò\âUvUyf·H\å_Ý¸/nò  |\Øe\'“ø™ð\'Røe\áûfhZ\í•Ü¢ÿ\0dK;2	­\Å\Ä,\âXc\Ú3>ð\îFf¼øõsu\ã\r;Å±øC\Ãv~*¶½]B\ãV·[\Å{\é€;Œ±“\Þ\ÇsyQ§=02++\Ä?µh¶Z]í–šm-e±•B\Äùskh–±«e\È!£@Xc’N08©Õ§\Ñ\Ýz[Kþ¶¾V~¶ð\ß\á‹üFðÿ\0‰ž“\Üköob–±È‰¦{o\Ü8\0²|Å”/~·†~\èZ~»a¤–·\×ð‰\Ü\ëZ±{sm$\×ÛŸ\"Kx)‰!I6JË¸ü»°x\ã\í~7jšn·\ãmGM\Ñt=%|Wg%ÅŽŸjðZ\Ù\Æ\äm£W\ÂŽ7n\'Œò5\âý£o¤ñ¥÷Š5xoW\Ô\î¬œÑ¾X\á‰\á’Š,WIóJ²¾\â\Ä\àœ¦\Ê\Ü,´nÿ\0úKVû\ì\Ûûµ@´›oU\Ó\ï_¥ÿ\0\æw\Ãÿ\0wÿ\047T‹\ÄzŽ5MUô]>\ÓSšq=\ÝÚ¤N#EŠÀ>r\0\ìBƒ\Ã\Ê\î\ÑðÀ¸5«8\ï|C\â!\î´mOU°\ÑU§:…\Ò[[\Ü2H6Àð¢``D’#2£m©<\î‘ñwR\Ð.|;&¦i¶h\Zü¾\"±µU™\ãYœÁû¦-!fˆhÀ·r\Ùcœ}ö€\Õt}+?øG¼?{¨C¥\Ý\è°\ë7vó=\ÜVw`ñ.%‚ò}›\Æv–+•._\å\Þß§\ç\Íò·™Qµ\×7õ«ü-oŸ–È¿\0uW\Ó\Z_øH4\Õá³·\Ôo4šqygk1d\Ò\'\Ê ,±;\"H\Ò*¿*`#¾ýž|_¥\Ér·qY\Û¼Ky$¸.\äk¹-?v\ØÀHd\'\Ì(v\ØÁMG\ãÆ­¨h“\Û.‹¢\Úk7V\éwž\"·†a}uk@‘¶e0©\ÄQ\é¹Œ±\ËgC\Æß´§ˆ¾![_Z\ëZV=ö±³qi\Z\\FŽ\Ñ\Ç\å˜2&Ü±?,ÁHm\ÌJ²\Óv\æV\Úúú_§\Ëõò3W\å\×{~~wü<\ÎO\âgÃ·øc\â\Ñnu»WR„²][\Ú[^ÀöŽ1òH·Vð¶H9A\ïÒ´¾øg\ÃZ¦ƒ\ã-o\ÄÖš®¡k¡\ÙA<VšMüVO#\És?4’A0À€¼\ã­Gã¯Œþ8µðÕƒ\é\Zv™£øx8°\Òí¤»¸…²³®n§š@§b\ÂbmYühkm{\Å\×\Òø3\Ã\Zw‰•\ëBX.ml U•%Q\Û\Ï \r\Zñ¼Žµ1¿_?\ë\çø///\ëú\Ü\ë\ì\Ï/‹|n4\ßjs2óI´\×,WP\Óo¯.V\Þ\àp’‹Y°Ñ¶P\ÈÊŠ\Ø¢œ\04\í7Á¾1¹ñt}\Ä~\×!\Ñæ²¸[\Ù#‰ˆº®a´39·\n1P÷\í%Eg\ÅûEk]k­ªx{\Ã\ÚÝŽ¨önš]\å¼\ÉicöEuµH#ŠTù#Yv9ua÷\ÃI¢ÿ\0oµ\rKÆ—:Ç‡4-v\ß\Åz‚ê—–7‹s0Ü«JRHL3\Æ\ë·Ï”\0]\r\È8¥-šŸ\æšù\Ú\ëªz>®Ô¿½¾Ÿ–¿+\êZðg\ì\ï\âO|;Ô¼a¤O\Öz|73\Ïn\Ö\Z€\ÂÀ…\äiû7\ÙCl‚™Á<n ,¯Qðÿ\0\ÇýO\Ã\Þ±\ÑSÃž¼ž\ÇL¾\Ò-u{¸n\î[¿4ÌŠ\Â s<„?—¸g+|º›ø´\Ûþô·\Îþ¤¯‡]\Ïvø¿ðKDð¿‰´\rxr\ÞH\ï\ïu,RúûÅº}þó\"®\Ù[Â³\Û\r\Ì9œŒEs_ð \ïn|M§øMño…µ}V\æ\â\æ\Òxmoe_±MfGYL‘ +…`%|d©ùû\Õoük“Ä¾)\Ó|L<#\áý/\Ä6—\Ð\ßÉ¨Y5ñk§‹VD’\å\ã\nJ©;\\ö…ñQðÿ\0ŽeñU¼6¯¨\É%Ä†9QŒY™€Àð$ls\Øu¥+\ßO?\Òß¯nŸ2;k\åú\ßô\ît0üûe\äg\ão\Þhvö&þó^†[¯³Y¨”BX\Ú\Ü\\i¨„\îÊ†\"\ÑýŸõ{a\ïüM\á\Ý7G\Ó ³»mjy®\Úx.•ŒÄ±\ÂÒ°l`¯–Iù”b¼·|q\ài5Hÿ\0²ô\íwL\Õ-¾\É}¥\ê«)‚t².Z\'ŽEetVŽ§#‚A\Óñ\'\Æ=g\Ä\Ö:ÝŒ\Özu¥†§•º\Ú\Ú\Â\è–pZE\\ 1¹vn¥‰$–\î­o\ë\Çk|\î­ÿ\0­¿\à\ß\Î\Ö3&ð†û\Å\Ç\Ä:aDf%ð1\ê#\ÌD\Ð\ã÷¬C\ï\Úvª\ÙÁW-[\Z‰?°\ì5«_\ì½7PþÓ´û/}o\æ\Éiû\Ä2\È\Ù\'É·w?+0\ïYvþ¿\åÿ\0õ\ß|Ò¼\'ðeõ›\ë\Ë\ÏøMá¾°û^œ¬‚\Þ\Î\Ú\î™!ŽA·wžV\Ýd?0\n² #vq\ä5\è÷ß´G\Ä]_Àú§…5?kZ¶•¨\Ë\Ê/õ;™™R%—t›Dm\æ\ÊAÉŽ3\Æ\ÚóŠ\Ç&¶\é÷!ý•\Ü\ØñG‡?\á¿‚\×ûSMÕ¼\ëH.¼\í.\ãÎ<\Ø\Õü¶lH›¶²ö`G8®‡á‚ô¿[ø›Z×žð\è^\Ó\ÅõÍ¶œ\é\Í\Ó<\ÑÁI#«,yyT—*\ØU8Rp+žñG‰?\á(¿‚\ëû/M\Ò|›H-|.\ßÉü¨\Õ<\Æ\\œ\Èûw3wbO«þñý\ç€o5†\Ê\ÇV\Óõ+F±\Ô4½N7{k¸X«mmŒŽ¤:#«#«+  \Õu;~„ÿ\0/\Êÿ\0…ÿ\0S«ðG\Âh~7x¦þ\ÏÁ\Þh–\Ö\ÐG/\ÙuU½\Ög9;Y‹\ØX«’9x\Ô˜\Õý3öc×®î¥³¿ñ‡t-Gû~\ã\ÃX\ß\ÜNfº\Ô!òób(\\m&UØªƒ\Ã\Ê\ç+Eø\Ù‚šÕ­§</ýªIipúD\ßo–\Ú)\íü\Ï*U\ßt]\ï_+#ºò¸\â‹\ïþ!\Ô<U§\ëòY\é‹yc\â{G\ZC Œ\Ý\Ì\Ð3¡ó\ån˜PCr\ß1\ã¦‰Z¯ø?‡ õ\×ú\èÿ\0[~>£´ÿ\0€º–¡\á\rkþ\Þ\ëP\Óou[=I§7\Ó\Ãj\Ó	ð«	H\Ã{¨`>RH`þ\ê0\èò\ÝM\â-J\Ö\Ê\rRÿ\0Di.\råœ¥6\Ï&!1°,n\É¼_”\È eZ|]\Ö,\æ\ÑdKk\ÚN‘}¢Áº7\ÃCvn|\ÖoŸ—k“ijd\è\ê\ß5M[@º²:&‰m«^\éð\é7\Þ!‚…õÝ¤a\Ä\á¥0¯\ËJ]\"W`ƒ,rÛ‰uqù}ò·\Ë\á¿]\ìS\å\æ²z~š~6½¼\íqÿ\0\Z>\è_\r¯4\Øôi\Úù¹°°¹{8#»¡š\Ò9š\\\ÉmyEœ\ì‹…e †\Ç)\à?\Ýü@ñU†‡esci=ÔŠžv¡{\r¤j\0Nù·<(;› \Õ\ï|Eo\é:M½î¤\Û\êz}µ½™Ö­~Ð·W0\ÃŠ$•L\ÆPecV;I\ç<î‹ªË¡\ë\Z”\n=œñ\ÜF²T²0`8\Èõ­!Êª{\Û_ð3\Ü.ö_}¿\Ì÷›ƒ¾±øý x:\Þ+H\í?´>\Ï$:×‹#\Ô\"Õˆ¸$f™j\Ídòs•“%s\Ë|\Þwá…£\Ç6\Þ$\Ö\×[\Ðü¡iw\Ð\ÛH\Ú\Å\Å\Ãkƒ7”ˆ\"†G“KB\ç1V·…~+\\xg\âdž9—A\Ò5­Wí­©C¡ö•··¹ó„«\"f‰V\n\ìË‚rZ©ª|E–ûK\×t»-L\Ñt\Í^þ\ÓP’\Ò\È\Ü:\Ã%¼s\"ˆ\Úidm­\ç\ÈÍ¹˜\ç*+:}¦ý~m_ð½ºvJ\ì\Ö\\·Ÿ.\Ú[\åø}ú\ïf\éuiú7‹üC¦øj\ÎOŸ\ìw®/\åŽTI\Ö\×Ë‚@ó˜\"e×ž3u†\êh\×%QÊŒõ\à×°i¿µ»g\âC¯]xk\ÃZ¾©¹q\âµi\ÜX\\\Î\ÈÒˆ”L‘Œi r¤nB­óWŽ\Í)šg‘€\ìX\ã§&¥^\Êýµõ\Óþ•­/]?øw\â/ƒ÷þð†ƒ­\ß\êúz]kGs§\è\é\ã\\\ÜF\í€\É\'\Ùþ\Î\Ø\ÈÊ¬Å—;H\r•\Íû6\ëRjVúmˆ¼;©\êCWµ\ÐõKY\çß¥]\Î\æ4Y\ËBª\êYKÀePTó\È\ÎD?\Z¯ôÏ‡\×Ñ´M7B´¼ky/®¬ç¾’K¹!et‘\ãš\å\áWÜŠÅ£‰O•:—ß´~¹&¥¥§hZƒ©Éª\Û\ëz…\æŸm.ýJò2G$\ÂI]Togb¬jKœŽ\Z;_M¯ø]~—¿[\Ú\Ö3×—\ÎßŽ¿­­Ó¹‡\á?ƒ:ßŒ—D6WZt_\Ú\×÷\Útj£%¬\Ï#;Â©YTž \çh\æ­[ü“RÕ„\Z_‹ü5ª\éQ\éò\êwºÝ´÷maoå¹ž7gV\ÜPX˜¿˜»wd\âý\×\í¨‰t/\ì¯xo\Ãöº=\Åõ\Ôšt7;K¸V)šF’wvùPm\Ëq\Óî€£ð/Ž.<¨^Ìš}Ž±chö7\Úf¤²{¨X«m-\ÑÁ‘¸du!‘N{W{ÿ\0Nß•þf’å¿»ý+þ|¿+‡€?gw\âv¯­\ÛøoPµ\Õô­$Ä’\ëV:v¥sn\ï %bŠ\Ñ\îv¿\ÌÐª‡$n]\Ü‹¼+¨ø\Å:·‡µh„\Zž—u%¥\Ìjrˆ\ÅNq‘Á®£Gø±ý»gÿ\0o‡¯<9«K\r\Ãø~\äÞ›[y¢#’)\ä\\+\0ò™ˆ\"B8\\q\Z…\Ôw—÷7\ÚCa²3¥­¹s œ„R\ì\ÌTt˜ž9$óMî­µ¿\Ëþ\Ý,.Œö?ü\ÓdøQ\ã5(š\á`³²°ñ–—¦È‹\åI#¼‚a+3ü¨\0«!\É>•\Í\ß|\Ô\ì|7w¨oE—V±Ó¢Õ¯<;³}¾\Ú\ÒM…%l\Ä!?,±1E•CŒ¨\Ã\Ê^/‚[\ÂþT\Ùí¨LÉµ¼\ß0Dc\Æs¸=1œ÷®·Vø\éªj\ÚÕ‘\Ñ4KmZ÷O‡I¾ñ\Ì/®\í#\'\r)…~X¢R\é»c–\ÜOy8ù[\îÿ\0\ä·\ëmº$£öT¼\ï÷ÿ\0ò;t½¯Õ¸> |›\áÝ½\â\Þx«Ã—úµŒ\Ñ\Åw£X\Ü\Ìn¡)dž%ŽA€2#vd\Ü*œ\âŸÁ\ßZ|Iñ\Ìz\r\åØ°†[û…¹i–ŽHl\æ™»7Æ»Ž>\î\îA\æ±|m\â\ë\Ïx§P\×õ †òùÄ’%²²\ÆP¼I\èRj\0x\Ú‡\Þ&Y·°³\Õ\n\Û\Ü\Ú\Ég¨y¾L\ÑOÁ\"·”\è\ã)#`«i®·\ìþûiø\è~ø%m\Ä\ï\Ùj:×‡uý\ÄG-Œ\Þ~¡miª\â\ç\Èk@\ëk\ç\Â\å\Ã.\æ‰@\îÁ\æü1ð´x\æ\ÛÄš\Ú\ëzƒô-.úiX¸¸`pfò‘P\Èòc\É`H\\\ã\æ#Š\Þ\Ó~<]i¾4\Ð<A„¼:ðxv$MFax¶v³y\ÂU+r%‘Ì…Ø™dpwF…\çuOˆ²\ßiz\î—e¢\éš.™«\ß\ÚjZY‡Xd·ŽdQM,µ¼ù·3\ã@\Å8ò\ÝsI\Éo\ç\Ë/½\Ýô/\É\ßñ·õc½ð/\ì\Ý.¡\ã\í?Fñˆt\ß\rY\É\âS\áÝŽóµ\Åü±Ê‰:\ÚùpHb\0óLºó\Ãcž‹\Â:E¯Á_kt\ÝSTMb\Ò\Ée[»¸\ï4µarv¼&«(„\Ë#\Ú8Ž6ô\ßÚƒ]³ñ!×®¼5\á­_T‡\\¸ñŒÚ…´\î,.gdiDJ&\n\È\Æ4À9R7!Vù«˜\Óþ,Eað÷Tð›x7\Ã÷Q\êS-\ÍÆ©4—\Â\ìÌ‚aƒmÐˆ\Äò\0<½§Áˆ\ÍF¼–{\Ù}÷WüŸ\åµ\Çk~ÿ\0ü—ù¯™]ø\r©h>›Voh—piVz\Ü\Ú5¤Ó½\äVw>HŽF\Ì\" Až0S\Ì\Ü3œ!‹¼uð\Z÷\áÿ\0†õ-Rÿ\0\Äú\r\Í\æ™—}£\Ú}¬\Ý[]:3ùEš\Ýab¡,’2ü¼‘œ©>.j—W:›\ÜZY´z–‹c \\,hÀ‹kSm±“s$?d%ƒ/\Ì\ß(\ÈÇ¨þ\Ñ_<ñk\ÃòC§Ã¯_\ê‘\Þyštº¡¹…4ø|\Äú\Ì-¸\ÆØ¡·Q´\0*§¢¼{þ«ô\ß\Ï^–j=\íúò_‡\Þx‡„¼#y\ã+\Ë\ë[`I\í,n5“±D…º¦\Ë\í€p:×¥ø+\à=\æ—ñC\Â:/Œ²-d\Ô5¶:.§wuÚž;…„Û´\Ö\Ð\ÊS\ÍbBÈ¹\\w3À|6ø…¨ü/ñu¯ˆ´¸-n®\í\ãš\"õY¡‘e‰¢`ÁYIù\\‘‚9\0\×]kûD\ë\â\Ï	x‡RÐ´]rû\ÂöP\Ú\é\ë}ö°‚H¥óR\åü«„/.\î¹;\ê™\æ«iE­ºú\ëÿ\0ó3’n2]z_\×\ä\'\Ã\ï†øc\ã\íFû\Äúw„¿±\íMÕ¥\×\Û%wA¤h­¥\ßYŠpD…\Ê»w\Z»\áo€¶¾3ðN—§ø«I¶\Öo¼Cy¡Z\Ç},\ë¢\É³@¶\è°v™ò\Ò\ìA˜\Ã\'žcEø¨4\ëÚ…·„ô#¥\ëvf\Æó\ÃòÆ³h÷\Ç\'\Ê\ßhó\Ôù‘#\äK\Ôc§\Ý\âÞ¥\á\éü8\Ú~§[\Ã\áý~_\Ø\Ûí•‘fsî˜´…š -£\0gw-–$\äDV‰y/\Ïü¿\à›I«·\íü¹t_üˆthÝ‘†N÷¯A\Õ>\Ühþ·Ô®¼Q\á\Øõ­6Z\ÛB7\Ù\í\å\Ú®bò·ü\Ç÷f@\ä!*¬0OŸ\Í)šg‘€\ìX\ã§&¶üM\ã+\ï\\i3Ü¤0I¦X[\é\ÐpË˜\á]¨\Ç$üÞ¤`{\nke~úúYþ¶üIv\çvÛ§Þ¿Kž‘\ãO\Ù;\Ç^\ÑlµN;[ež\î;	’õg\Óãµ\Ñ\ÙU\î.\â†\Ý\×÷n‘K\"Í†R\Û^8ý›E‹4/øf\ÊMC\Ä\×*q¨G\âK=J\'l³N\Â\Æ\Ò&¸…W,Ws;:§È®\Ìy¯\Ä/‰‰ñ\ZI//<+¡i\Ú\í\Äÿ\0h½Ö´\ïµ$÷’w³\ÆÓ´\n]Ž\ã\åÄœôÀÈ©cøÅ¬§Ä‡ñ¡´\Óå¾–/³\\X\É5¥\Ä\ß\ìòD\ê[v× \á%Jœ•\î\ïÿ\0o¾\×ùÛ ŸKvþ¼¿­Î›[ý—üQ\á¿¶ª_\é\ÚdK¤>¸u-F+\Ë8EªK\åH\Æ)­\Òp\Ê\ÙùLA˜6\å\Ü\Ïþ\Ìþ!ñæ³©\ÛxU\Óu½.\Â+y$\Öô›kûûv3)h\ãò­\íd¸FÂ¾D¨R„1“w,\ß¥\æ¯6‹\áÃ°jšS\é7–-w${\Õ\ÚE3\ÜH\áþU{n\Ý\Ï5‚¾#\É\á\'U\Ò.´\'\Äú&¥$3Í§kp‹4[„r£Á,R+$‹\Ã\à‡9\ß_\ëWù+[\Ï!ÿ\0_rýoÀ\ì´\ïÙ‡\Ä’Yj:÷‡ô\rKûz\Û\Ø\ê3\Îfº¿ˆFLqˆ¡•¼\ÔØª‚p\År¹\ä¿\áW\Íg\à›júö“¡%\ê\Îúnyö‡º\Ô&(\æ1.ˆ7†@exÁ*\Ø\àR\éu-\çÃ²i\Úf›i¯\Ë\â+UYž5™\Ìºb\Òh€¶Œ\0[w-–9Èþ\'›\ï\Ã\áýW\ÃZ.²Ö‹<z~©uö¤»°I\\\ÈR3\é(‘\ÔJ‚\í\Øâ–¼¾ð?;ü¬VŸ×«ý-\ç¹\Òê¿³t_†\rã‹»_+OŽ\ÒB[g²¼FKyYr	\ÚlùFv$\Ì\à1Ê‚®\É+¸ñ7\ÅøK¼?mgªx[CŸY·´‚\É|FŸjŽø\ÅTŒ2¬\â\"5X÷K$·\Í\\=Sø¶\èJøU÷þ¿¯C\Ö<\àø\ß\ã†ü9¥\ßjWš\r\í„R\ÞK%\ÄV³¡dež5–Hö\"¬\Ê\È”€r\Ã\æ7t_\0ø:÷ã—‡¼%}¥jphú¼\Ö\Ö;t\Ïiúœ°\Ë4Á¿j·¶hY@?ê¶†\È\å\Æk\Îü\ãKŸ‡¾,±\×\ì\í-o\çµóÙ¯ƒ˜eW£emŽ‚®~\ë\ï]‡~,YøS\â‡‹4\Ïøn\Þm?Ë’\×M2\ê/k\ÄrKº\ì\È\\Ö¦?ƒ<\Óê¯µ\ßõþ_¦\ä\Êü­-ì¿¯óþ‘c\áoÀ_ü^º\Ö‡%Ž–\ë÷cyxÜ·–ž]¤I’\Î\í›F\ÞX õ\ZO\ì\â‹\å\ÔVÿ\0_ðß‡\î,/nl¦¶\Ô\îgn‚x`•Ç—‚¾e\Ì\0s¹· \à\ã\Ó~/&Ÿ&½l|\áÛ¿\ë\Ãq/‡\î\rñµ†xƒ–)È¸V\ÃÉœ\ÊAó#qcGøñ¬xH:V›¤\é6šz\É3\Å\0I\ÜD$º´¹(¥¥,B½”J7v—\É$†mÌ¹¶·\ã§ü—f]Gv\Ü;þýŸ\ì“\ã\Û\Ï\n\êº\ê\Û*Áb/cw²-\Äv¬\ë3¥\Â[µºs ,²\Æí·…;“vF§ðûI\Ð´§ñW‡\Ñ\é¶:\ÍÎ›·2\\\Ú\Ù]DsI¶ƒiž=\È¸!X&§ˆ>5M\âý&[MÂž\Ö.\Ã]}T˜]\Åsb³\ÊóÊ¸DuY$‘—\ÍI\ÜA$qY·\ß5{ÿ\0\í2\Ú\ÈjhV~›j?\Ëomöo-—\ç\á\Ï\Ù#\É9s`Œg\Û_/\×ó\Òÿ\0;yW»\Í\åÿ\0~Jöù\\ô;\ï€~\Óþ,ø\ÃPø\Ò\×[±\×Ivúp¹K\È\Ö\æ\Þ)d™kDˆ!.JYÂ²n\\†\Äz\ç\ì\íg\rŽžºV©<\×:¯‰d\Ó4\ë¹ šhg³kH®-\å[\Ã$\Í#	@!¹\ão\×(¿/WWðŽ´¾\Ð\×\Ä6‚-YV\ëÍ»Ž\Ú5Ž\çO?\Ê * %\ín¹\Ðð\ï\í)\â\èÑ–•©Xx~[Ç·[È¥-,WP¼2Á#$ŠL{e“nÝ¬7}\ì\0\Ëgmï§¥\Óü•¾oÈ…\Òý¿Wú\Ûðó7¿\áŽüaŒ\Ã\×Z¦¦\Ë-µ\ì7Z’^\Ú$«=\×\ÙbO*[e\\\ÌB\á\â^\ì\íùª¾•û#ø\Ã[\Ö\îl¬/l5+--\î\ÛV\Ò\íuûs\ç [{Y&\'1Kóy{Ï¿ó&\ê6ÿ\0´Þ»¦\ê\ZTúg‡¼;¤\Ûivö–¶–6–óù)½ÿ\0Û£\Îé‹±2ð\Ì\ÌK)9;Ž\êÍƒ\ãÖ£.˜4­cÃšˆ´_²Z\Úÿ\0f\ê	r‘\î·iLS†x\äY\0žU;\\)\rÊœžwv¶ù\íóù‡W}¬¾ý/ú”®>ø¢\ÓVÖ´Û‰ü=cy¤^\Ëau¥\â]:\ÆA,g\r¶;‰\ãv_FƒÛ½h\è:€n¾k~ ¾\Ñ|G.½¥\ÞZ\é\Å\íõ\Ûx\íe’\â;§Y|³dÌªŸg\0§˜Kn?2\×?¤übñŸ…£¼µð¿‰õ¯	i73½\ÇöN‡ª\ÝAkn /šI\à\ËbdšÇ´ñuåŸƒõ_$pµ–¥{k}4Œ¬e@“ª9\Æ¸|\ä\Â\àŽs:ò5\Ö\Ëïº¿\ár´½ý\à‡¨~Ë¾4Ò¾\Z\Z\ÞB-tÕµ‚úh¦²½S´¬‹¾y·û;\äIŽf9@U\Â\å\ë\î¼-ý6·\âmMÓµ+¯&\Âý\ÍÔ‘^[ùa\Í\äB;vsYS%Co%v\æ96gøƒ\â¢ø«D³µÕ¼\' \Þjö¶\Ööc\Ä»Žñ\á„*Æ®©p!c\åª\Æ[\Ê\ÜTu\ÝóQâ¯‹ÚŸŒ´y´\ÍCM\ÒþÆ“¬\ÚbC‰ýB˜mŽþ\"eDdó2Wvw³3hšS¿Kþ_§\ë\äB\Ù_·\ãoóý<\ï\Õø·\àv‹¢üxo\é~)·\Öt´\Õ.-\îZ\Õ.>Õ§\ÚÀ\ä\Èf2\ÛÆ\"Ä®Ù‹z\å8\Æh\ê\ãÔ¼qc \êvúw‡WF‹\Äp_ë³œ%‹¤l\Û\Ú(²\ï‘”„L±‚®HR\Ë\Ï\ÚYo_x·K\Ñ4øªú\Ú\âgI{\È\î\ZY¶ù—*Z\á–)°Ucü½1KTøù\â\Ï@¶®—\\¿mmMOR’i\îå¶’?ç‘¤ù™X¤ôS‚1÷£·i?¾\ÏõQù7Ô­®ö\Óîº¿\áþ\Ìþ!ñæ³©\ÛxU\Óu½.\Â+y$\Öô›kûûv3)h\ãò­\íd¸FÂ¾D¨R„1“u¯~\Ê>2ñ·ˆ<G \Ú<kzûi·6mc¨L¦a3<\ÒC\Z±šH\Ç8\×à¯ˆòxGI\Õt‹­Iñ>‰©Iói\ÚÀœ\"\Í\á¨ðKŠÀI\"ðø!\ÎAÀ\ÇM\à_\Ú÷ÀZGe\á/\r^Ç§\ëRkºZj\ÝÊºuÃ¬jDc\íz\í‰\0ó|\Ær75rò\íþ_ŽþOM‰\Ö\Þð\ëo5\æq––>_\ëR\ß]\Ý\Å\â\Èo­¢±³Œ–\åeûC¹\Ú~ee„˜}ó\ÃrG9OšS4\Ï#\0Ø±\ÇNMm\Ýx³\í^°ð\ïö6“\Ù/%»þÖŠ\×mü\Û\ÕWÊ’\\üÑ®Üª\ã‚\ÇÖu}týü\ånkGm_øb\×\Â\ß\Úø\Û\âg„ü;}$\ÑYjÚµ­Œò[°Y9eTb¥°\Ç‚3\Ø×¢üFøE\áo\Ë\á)¬\ïG‡\íõ;«¨.\ÛRÖ£\×,¢X|²­ö\Í:Ü®\ç\ÞTÂ¨\îŸ#6­yWƒ¼Qu\àŸh¾\"±Ž¯t›\Øo Ž\áIž\'¡€ •%FpA\Çq]^«ñz=RM\"\Üø+Ã¶\Úq=\çö~-n.%UW–Y\rÑœ¶<•TlrÛ´‹IÅ¾_\ÃþÔ…ö¯ýoú\Ûú\Ñ\îx‹\á\nx‡\â\ç\Ä]\'M}Á\ZW†\Z{‹”½\Ô.n-maŠ\â8G1ˆ\Ë/\Ï  Ã€aN|Ÿ\ï4ýCT\Z·Š4\r#E±x\×nM\ÛZ\Ý¨|ûu…c·y˜´Y~bB\ÛI\0\ÔñgÆ«\ï\ë\Þ/Õ“@Ñ´kZmM4ñrQ\Ø\ÝGr\Ó(–y\n¹x`›s…š·kñóSX¥ƒQðö®Ù´Zr\Åk©A3E\ÖV\ßf‚u*\îo/;•÷FÄœ¡)Z*<\Ý-ù\ëøm\ç¹OVþ¥¿\ß\Éht:¯Â¿x_Rø\ÓiYkð‹›‹[[\ëË¨o­\ÑoaoG—‘7úÀ†7tûÅ¶ð+œ\Òþ\ê:§ƒô\íu|E Cq©i—šµ–‹$Ó›\ëˆ-Za9\n°˜ÐŒ7º†\å$†Å¿\Ç\é´¼m¨j>\nðÎ³{\âé¦“Qš\ì\ßÇˆ\äš9\Ì1¬7Hª‚X‘Án0XŽ+Oø³«\é§Bò­¬Oö>}¢[†G; ºûO˜\Íóò\ã\írm#\0m\\ƒƒ˜IòkñY}ö—\ëkÿ\0’V¯wñvŸð\á\îm]|¾\Óü{¯\Þø›A´¸³\Òíµ‰´Y>\Ö×‹opP[œ­¹„—ó# y¼ù¶@\èþ3|ðÇ‚u\í?D\Ó&]$\Ëw¼šÖ­\â\Ë-B5VŒ1yl­mþ\Ñl \å\Ã``“š\Ýñ\çÇ¿ø»\àý·†\Z\ß\Ä\×vš]¥½••É¸†\Ú\Îò(’6J\ê-nÀb\\±BÁù!‹9óO|`·ñ§ˆ-5»\ïxe54¹Ž\æ\îhŸP\Åþ\Õ\Û\åÌvT!À\'\Ëx\êE[ø\Ú\é\Âÿ\0\å\ço\Ée¯\"}mø\Ûüöþ›¾Ÿ³¯ˆ£ñV“\á»\ÝKFÒµ­B\ËÏ³_\\I¶¶·I$ó\å,¢\Ç*\Â\íw.\×;Q•ŠGû>\ê77–\æ\Û\Ä\Þ¹\Ñ\'\ÒfÖ£\×Ä—1\Úxfòfù^›z6~_/,Ë¸•CÂ¿´$\ßð“Y\ê¾0\Òm<A%¥¦©n—>S¤ò\Çui<Ihþ\\±³¬“dmÃ¢–ÀQ\Ïj_\Zµ[Æ¸†\×J\Òt-´i4+}.\Ê9|‹Ky%¹Œ¼#;I¹‹H\î~b:et´\Þ\Ïÿ\0n²ù-þ~Fš_\ËO\Í^\ß+\Û\å\Ö\æ\ç„føóY\Ô\í¼?ª\éºÞ—a¼’kzMµýý»”´qùVö²\\#a_\"HT)BÉº›~\Ïz\æ›c\â«\Í{U\Ó|7m\á\ÍI´‹¹ob¼M\Êÿ\0\06\Öò„­.\Åm\ß)8ls¾\nø\'„tWHº\ÐtŸèš”\Ï6¬	\Â,\ÑnÊ±H¬’/‚\äl|?ø\Õ7\Ã-J÷T\Ð|-£Z\ë\Ë+\Ûj\çQY,\ãq%n\ÂI\Zÿ\0ve“wG\Þ8§.¼½¿\Ëñ\Ývë¾„¯>ÿ\0\×õ¿O2’ü%»‡á¿\ïõ­;LÓ¯$–iá¼’[¹#8dY\"·xQòIQ°7`)\Ýñƒô\Ý?\àÿ\0„µt\íSU\ÕuK¨dÔ¬.®\Ì\èR+sö9-\å…#†eo2&p\Å\È\Ï\Ê*\nüc»ð_ƒõmG\Ðt»;­Z\Î[\íag½ûE\Ä2¹^/´ý™°¬Tf—†aº’ó\â\Ú\Ü|?\Ó<+„4<i·ò\ßV·’ø\Þ-\Ã,+$\Ç}\ËDY\Ä‚<½£j®j´»Om6õ\×úÓµ­{¥}¯\å§\ãþ{\ÚÛû6kR\ê–\Úeˆ¼;©\êcXµÐµK[‰÷iWs¹rÐªº‡VRðT<ò3\Íø\Û\á\\\Þ³\Ò\ïS\Ä:&½c}w=»\Òe™¢‚\â/Í\ÚH“8!Þ›ƒÆºI¿i=hkúµ‡|;¤j-«\ÛkšŒöVó\çU»ÌˆÓ‡™‚.ò\ìR’\çŽ%Ï¯nü3§hRAj\ÖV:•Î©(\Å\ÞI\Òuo›1n˜–\É9Q\Ýs[~ù\ìVšÿ\0_\Íÿ\0\Úùnoxoá½÷Å‰<){¬\Ù\Þ\é\Ö/s-î«¢L.!–\Ú\Ú\'ši-Ü¿1\ÄûN9$qSø\á\Ì#ñ/‰-u=Àž\Óï €Å«\\\ÝH°ý£\Í0Æ›\"–IH°\'þ\"†+GFø¥&“ñM¼dš—o\Ó\Ì\×\Z„?g²ky‘£š\Ý\'b4n\è1’3ž\ÕFÿ\0Å°iº_ˆ|9¡+\É\á\ÍCS·¿Š]B0·j Y\Ö%mŽP|·»®H#H[\Ý\ç\ì¿5\Ão;ƒ¶¶þ¿®§Ycû:\ëR\ê·:n§¯h>¾\Z\Äú\rŒ:œÓƒ©^BÊ²$&8\\*†xÇ™)3 ù¸m¾_yg6Ÿy=­\Ìf+ˆ$h¤ŒõVS‚?+Õ—ö’\Öf\Õ.õ-CÃž\ÕïŽ±q¯XMyo9:]\äÌ¬\ï\0Y”:\îH\Ûd\âU\Ê9lùM\å\äÚ…\ä÷W2n\'‘¥’CÕ™ŽIüI¨\\\Ú_¶¾¶_­\ïò·P\Ó_\ë¿\ék|\ï\Ðô­_\à©¤øv}Hx‡A¾¾·Ñ­¼A>‹i4\íyŒ\ëY0ˆrnO3~>`¥p\ÇK\Ä_³.¹\áO\rh\Þ$\Õu­>\ËÃš•\Ì6\ÇSºÓµ[h\àibi#b&²F•YQ¾hP3€A0x\ë\ã¤:Æ’ºo‡ü?c¥½Æ‡¦húŽµ\"J\×÷imo¼Gt\ÏFeH1ÆŽU1å«ñ\ãþ§ñG\Õlgð\ç‡ô‡Õµ8u}F÷M†\à\\]]F’ vifp9Ø¡T@9\Ú\éJý.¾\ë\ë÷\Ç\ç\'¢[+öý\â¥+y>¡û?xvZ¯l¼ag¨\ØB5€’¤“C%‹Z\Û\Í$Kw$\Öñ\Ç÷£]\í\åÀ|Á®&Oiüc\á¶ñ\rÅ—Šü)«Áö…¾\Ñä¸‰d·g’’?28\äY\"tr\Ó£§}o\ã…\î±\ã)üU‡4=3\\»¶¾·¿¸³[¬^µ\Ü³H;*¾$vXE\ÜyR8¬½\'\Æ\Ö\Z–¡\à\è<Ud\×Z†í¤·Km<m–\í<ù®Dn\Ì\Ø]\Ò\ÌPº•B±i§e\É\Ï\Ò\×óø¯ÿ\0¶Û¯\Ì%ªvþ¶þ»\Õ>\Üi?<C\àÛ­cKÓ®4yo#{\ÝNso¿gWl) ü\Òl\Â.9fQÞ¸Šô\ïüM\Ñ\áø¡­x\ß\Æ\ÚbøŽ{¡ysý’ö1Mmys:¸B\ì<•V“xuW  \0wcYG™(©oe]nT­wn\ç»\è?ü¯ZøO\ÃÊºõ·‹üG\á\éu{mP\ß@ö	pq¶¶ò…e¶+¿\Î%Kƒ´ƒ\ì\á\â¾§’þ\Ôh\n\Íq,\Ú~¥\n\Û\Ç$\Ëÿ\09\ív»\0V$n¤Á\Å[OZ–Ÿ\á\ËOhV\ÚÅŽ”ú-·‰.Zþ+Wy\ÕCLaV\"Y\Ì\n\çiú§\ÇýOUð}\æ†þðüWº=¦‡u¬\Ç\rÁ½–\ÖÙ¢hW-1òˆ»±ó@#Io&»\é\éwúr¯¿\Õ\Ì6‚—e_vÿ\0«_ðt\Å„:õ½\ÇGñ®™¬¶¡i§JðG\rñ–#qk­1\Ýh€\ÄY\ÉU]\Ò\íe7d	ü}ðÿ\0\à•÷‡o|gmqª\è:¤“F±\é\ëw¤\Ü;Fr·Y«®<\È\Î\ï%”Œ€r2fø\Õ}&©\á\rb=E·ñ†ž\ÈÁ¬Æ·>}\Ê\Ú*¬	2Œ$D¤h\Çh\É\ë™üCñ»þHôKIü\á‹}K½º\ÔJ¶©\Ä\×\Í\'\ÚL\Í\ÌHF$\Æ>\è\n*6SM\í\ÃOø?? Z\ï\Ù}öwümòó;ø+\àcã§‹üi­\ÜxcI\Ð Ô‘_[º’\ê\â\îkXn\ÍV·²Ú±ƒ3£.í¡‚3±¹\0~\Ï:\ï\Ä\í_[·ðÞ¡k«\éZI‰%Ö¬t\íJ\æ\Ý\Þ@J*\Å£\Ü\í™¡UHÜ»©\ßüp½¼ø±q\ã\è¼9¡\Ùj‚\ä_ið­\ÓY\Þ}¡$K‚\âI\ÚA½epv:\ÆÝ§š­£üXGþÝ³ÿ\0„7\Ã×žÕ¥†\áü?roM­¼\Ñ\É‹r.€y\Ì\Ä!.3†Ë›{~7\Õý\Ûy\ï \å\åý]²\Òd_.¢·úÿ\0†ü?qa{se5¶§s8“t\Ã®<¸\\ó.`Í¼m>¥ðo_\Ò\í5+™¯<8#\Ó\äž9¢o\é\És˜‘\Â\Û<\âbr§\å\în0Eh\èÿ\05\éJ\Ót&\ÓOY&x 	;ˆ„—V—%´¥ˆW²‰F\âN\Òù$Â†©ñ\Ó\Çú¥¾©d<a®YhÚŒ“\É6i©\ÜGc‰žH\Ä;ö\ì%\Û\å9\ÎNsC¿,m½µõ\Óþ+]ß¿\ài\ëŸu\Ãj\Ï\â-\î\î\r*\Ë[›Fµšw¼†\Î\ë\É\Èù„D3\Æ\ny›†s‚¤1\Ì\Ö~\ßx>\ï\Ä\Òkoyg\á}rR†\Æá£’ws?ú—hˆ‹i>f\\‚\Êvž@Šó\âÖ±zÚ¹{{%:ž‡g\áù¶\Æÿ\0-½·Ù¼·_Ÿ‡?d$\ä¶\0\È\Æÿ\0‹¿h+\Ï\Ø\ÞZ\ÞøG\Ã0G¨\êðkz«\Ú\Åt’jW1,ŠL­ö‚U\\LùXŠ\0I+°’M\Ëû¿Ö«ô½ü\ß\Ü+r«\ïÿ\0~·ù/¾‡<7\áO|H°·Kf\ë\Ã:nŸ¨›&\Ô\â[\ÕûMœS”ûG\Ù\Ê|­.3\äò@Nj¿Œ~\Ù\éŸ5Ÿ\éú¾ao®M¥A¨\ë·+PÆ³Y\'•T\0\0\0³\ÇSŠŸ\Å_­|a\âmX½ð†cþÏ¶ŽÍ¬`—R]E)+.o-pQÐ’>m\Õz?Šš\'‹>6Yø\ã\Å~°Ó­>\Ùý£¨\é\Ú=œ—\ê	Œ²EurÀ	I\Ø\Ømª§!	\"µ\ã\Û[úio\Éù\ê)?wM\ì¾ûkøü1ºƒ\ì·SC\æG7–\å<È›r62§¸5\éžøO\áÿ\0|%\ÖüS}\ã+D\ÔlµKDµ¼Žõ–5‘.X‰V’e\ß\ÉR…X¨\nûö’µ\çþ#\Ô\àÖ¼Aªj¶1iv·wR\ÜEcú»tg,±¯…À\é[\Þ\røŠ\ÞÐµ­\ç@\Ò|G¤\ê²A<¶º¯\ÚG4\"A¨\ÐM†i;¹Š…wM\ß{/\Í_ðºÿ\0€S·6›\'ƒ?gxû\áÞ¥\ã\r\"xf³\Óá¹ž{v°\Ô/ ûOÙ¾\Ê`\Ü\Î	\àcq\0\çj\ß\ç\Ñ<3©y\â¯C}q¦Ã«[\ès0¼š\ÞM¸*LB-\ãqýÙ9J«\Ãÿ\0õ?xN\ÇEOx~ò{2ûHµ\Õ\î\á¸{¸-nü\Ó2(\Ìòþ^\áœd®A\ã¼A\ã+Ÿ^\è\ÓjB©¦X\ÛiÈ¶\ë·|0ªN\í\ÃqN1\íÚ­\ë4–\Ú\í\×úO\ãn\ä­ßŸ\æ­ø_ðô;ýcöf\×t¸Lk\Ú«¯®¯o \Ë\áû#vnâ¿˜1X=º\ÂH\Øùe”§\ÊpÇŒôVŸ²F§ üDð>\ã\rb+Dñ¢¶+z\Ö\Z•¤Ž\âHƒÁ\Z\\Y+‰e]Žc1œ¿\ÊÀnüeý¦¼1\âÆ°Õ¼7ý½?‰t­V;ý\Z\ëV[ˆ\ã\ÓQ[s/—&£u†\Û)\'\ËÀ\nW\Þ|RDñ~‰\â]\ÂZ„õ=*õuþ\Êû[\Ç4«\"º—K‹‰@\0¯\n›F	˜Qz«÷\×\Ò\Ëõ¿¦‹RZ|ºoo\Ç_øŽ\Ú[\Æ²ðÖ´öZˆ4ÿ\0[ª\îûf›\ÊFH\ØE\Ä1>áœ.9\'œu?þø—\ã+jRh±´vZw–·a½¼Uy7lO.\Ò	¥\É\çvÍ£o,	Py_xŠ\×\Å\Z\Ë\ß\ÚxLð\Ò:\á¬ô–¸hKd’ÿ\0¿šV\ç m¼\Íjø+\â<ž\Òu]\"\ëA\Ò|O¢jRC<\Úv°\'³E¸G*<\Å\"°H¼>sp0¡·½¿õúmò¹¥K97¿¯\ëò:;…ö\ZV™ñ;Fñ\r–¥m\ã/Bg[\ßGöBVò\ÞÙ¢hL%›ýs0q*Ž\å«ý˜|k\â\ï‡2x\Ê\Î\×fŸö[‹\Ø\"{+\ÆûDóN5º«–dbW…;“v?„~.ZøF\ÃÄ–qø\ÃZ„:\ê´7ò]G1[™c•m\ã1Ý¦^`Í¹øÁr*¡ø¢/<g\á\í[\Â\Ú´\Ú|\Ú\éÚµ\×\Úã¼²‰Ý¤Ø¦\Ò7\n\î\ì¾j>\Ê\àR×“û\Ö_~½;\íå¾ ­+¿»Oø?\Ùj¿²¯ˆtŸ\nÍ­·ˆü7r\ÑZµ\Ñ\Óm\î.\Z\ì\í‚†Œ)€)a\Ì,~m£v\ÝÛ¾Z±®~Ç¾>ð÷ö\0¾ŽY5]V\×Ee¹´½·[K«‚Da\ä–\Ý#•AV\í\Úeá”¶\r÷\í\âk\ë­š\ÓKe·žØ¼qJV[K[V ùBYDGûL\ç@j?.5i>._ør\Ï\ÅV:œ:¼Úµ²\Þ+\ßO&hÁ„q¹¼¨\ã\ç¦\Ü\â®V\æV\ÛO\Ï_\Ãô\ßS5~M~-\à\Þý\ì\ï¼y\à\Í3Tñ¾ƒq¡kš³iR\ß\é/vûgŽHV[dcjA”¬\é±ÀhNs¿\æ0ðý—†µ§²\ÓüA§ø’\ÝWw\Û4\Ø\îR0rF\Â.!‰÷\áq\ÈÁ<\ã[Eø©¬ø~\r¥šZ£\è\ZÜšýœ­fûCù–ÁAöhð0-’r1‘\ãZø£Y{ûO\éž\ZG\\5ž’\×\r	l’_÷óJÀœô\r·€9©\Ö\Ëú\íÿ\0ð5÷}\ë|¾÷úYýþGUðOÂºO‰µ\ÍUµT\Óu±Ò¯n\ãÑ¯®\î\í^ð\Çk4…¢–\\ŒG¿lŒŠ\ØžN*øO\á-ß‰üªx¶\ãZÓ´-O¸[G¸¾†ò`\Ó\Üý\Z\Þ_/9\0v\'\nN|2ø”¿õ\Û\ÔðÆ\â››ymõv»LR\Å$3*.\"<r²’Ûˆ\à®\Ó\Íj|?ø\Õ7\Ã-J÷T\Ð|-£Z\ë\Ë+\Ûj\çQY,\ãq%n\ÂI\Zÿ\0ve“wG\Þ8§.¶\íø\ÝþòH…\Ó\×ôþ¿§s\Íë¡¼µð\ÚøL¹·¼»=ý\Äw–l?\Ñ\ãµTˆ\Â\êvý\æv”˜ýÁÀ\àž|œ’i(\ènvÿ\0<g\á_‰·\Ó\îeªÖ¨—™‘”\ËnK\Ó$\ç…Rp8õô˜ÿ\0d}gAñv‡¦xšú;m;Z²\Õeµ¾0]\é\Â9­,\Þ|J·\ÖÐº\Æ\Ê\Ü\á\n•,dq\Ú\Ç\ÇkS\Å\Z7‰\áð‡´\Ïé—¶—\ÃVµ7¦K‡·\ndŽK—‹iØ„\ìE?/d\æû~\Ñ÷\Ñ\Ý\é\ÓÁ¾°Ó´ù5)?³-\ã¼ònMý¸‚\ç\Ív¹2¶PpD€¯@p\0\Ú\Ë}-?˜G{oøøV¸hß³\'‰|O®iÖšýˆt\Ë\í>MN-kJ¶¾žs0­·Ú‹	p›V~`\ßs,&Ó¾	\Ûxg\âˆ¼\ã[MGûb\ßFº\Ô\ì.ôû“k¬%»F’\í¼\ÆW€¡ò]2ÀŒŒ•øõ¨¦¡´xs@ÿ\0„oû,\èÿ\0ð‹ùW`û1—\Ï#wöþxó|\Ï;~\î7mùj¯„~.Zx/\ÄÚ¦³c\à/\ÈomäµŽ\Îyu&‚\Ò) xfX±xù‰#d\È\ÎA9]´ž\Í.\Òûõ·Ý§\â5e«òý?\àþ9\á{_\r\Üi^%}vò\î\Öþ&°\ÊOu\çD¥$ùN\Êi[ªòƒž€ó\ÕcPºŽòþ\æ\âHl\"–Ftµ·.c„Š]™ŠŽƒs\Ç$žj½\êhzç…´­À>{›v¸\×|O;]¥ÏšÊ¶vQ\Ìö\áUGòH’’[;Dió^ñ7öoÐ¼\"þ8—J\Õo®4ý;Q°´Ò®®~q‰g¸·¸Y\ÄqgŽ[v»\0‘ƒ´\î¼¾\ë\ÇVz§\ÃýK¼¶k¾¹a¦\ÝÆªb–\ÎGi^y”³!È™Á\Æ\×SiûRx\Æ\ÍuHt¶[\ÏG\â°	\Ù\î\Ò_7d?3Ê¶O\ËÁ’jVm[¿\áx\Ûð½ü\ïÜl\í\ÛO]\à|Ÿ‘£®~È¾-ðî©¦[\ê\Zž›agm{v5\rB\×Q±Ž$´dŸ|W‘\ÎpŒ¤‰ƒg\0’§\Ý~Ç¾3‡Å±\è6·\Ú^± K§ºº\Ñ\Òòö;O³Ê±H®‘[´®\Û\äŒb(\ß¹\Æ\×Û‡©þ\Ñ:ÖŸ†Ÿ\á\è6)¤Ÿg\Ó\á¹;šú$Šwg–wvlF¥IcŽ˜\Ú‰/imV\Ô/¥\Ôô]S°\Ôù¯t»ˆg÷\"\ê\á.X¬\Ë\"\ì–8\ÙXmÁ$™W¼}ýz|‹v·ÿ\0ó3õ\ß\Ù\ï\Å^ñn©\áë¹´;K\Ý=!•\ÛU\Öm´‘$sF$‘/ž	TŒ©@\Èx`§Š\ç4\Ãö°ø¶\Û\Äw\ÓAª\Ø\Ú¥.,sÁsx\'\n4ˆZ?,\ÊÁ•€;\än\Ç\â\ç‰|3ªj7^\Ô\ï¾\Ú\ß2\é\Þ\Ô\ï-\àùW%\æy«\ÛŽ08®OP\Ô.µkû›\ëë™¯ondi§¹¸\É$®\Ç,\Ì\Äå˜’I\'“šZþ¦þŸ\×õ\ÐÙ°µð\ÛøX¸»¼»\ÅQ\Þ\Û%…¤c÷Û²\Êgw;OÌ¬°ó¾x<•Ù“\Ã:n±ðxxŽ\ÂÙ­uMRM\Õ0\î\És\Â\Ë%¼\Ø9\n\Êa–6\0€@ˆ\àÅ¸Z\ë\î¼]ckð\Î\×\Âúd7\â\îøjZ½\Ì\áB¼‘‰#·Š 	ù$‘‹\ÓŒ -Rø[[\éo½_ð¿\Íú	n¾“ý«\\¹¦ÿ\0\È>\×þ¹/òb¡³¶p™ž=‹µv’1Á#\'\Û&¦«]ÿ\0¨ÿ\0\ë˜þf±õøúOú\åþ‚+c]ÿ\0¨ÿ\0\ë˜þf±õøúOú\åþ‚)=€¡ETGÿ\0§ÿ\0®R\è&§¨4øúú\å\'þ‚jz¥°Q@Q@‡þZÿ\0\×)?ôXÕ³üµÿ\0®R\è±©0=Oà®Ÿ\á\rF\Ï]YC¼ñ;y#G±ñM\ÕÕ¦›:ü\æPg·’=“#e‘\"Á}\Ç;qf\×\à]Þ¯wr\×R§‡®¬¼A>—®\ékHº,+\Ï\ç+XÊ‚8.°g÷\æm\à\×\àÿ\0ˆš·–q¦[\è³™\\¶« \Ø\ê,¥ss…:ÿ\0	\ã=n\Çñz\ê/	ø¦\Ó\ZÏ‰<S \ZÎ³y¨y©<BO3	–\n\È[ƒ#H\ß)e\n¡)w]¿?\à\ß\ïZ\è\Èù÷ÿ\0?\ËF—}ô/\é¿ô\íS\á…\ïŠ\ìµ}WWºƒ\ÏvÓ´}*¯±\Å!d¾\"\èKl¬mþS\Æ\099Qs\â?ü¤øÀ—~\Õ5Éµý[L3˜n´ˆ\â†\éþ\Ýq	w“\í\å\ì\nˆÁ„jÄ©v\Çiµý\Ã2\è6K´´–-\Þ\æ\Éoš93\æ!¼ò~Ñ†T3î’¿wŠ†ˆú\í×‚\í|+q-ÆhOÙ¼\í6\Ù\îmÁ\ÈV;“™¹,U\\),\Ürrô½º]zõ¿\ßuýj<õÿ\0€{¡û\'\Ùiúö‹ ·´¿í«^-þ\Õf±­Ýƒ\ï–(à½–g6·›\ró§ËÁyo‹_4‡¾\Óõ\Ý\Åw Ž\æKUxn4¯±´Ksf·Qd‰¤¶0\Ü\0‘†nqƒ}ñ\ã\ÆZ–§¦\ês\ÞiÍ¬ió¥\ÔZª\è–)zò¢\í\r5\Â\Â$˜ã¯šÍ¸\àœ‘š\ÉÔ¾(x›X±µ³»\Ôü\ëkYmf…<ˆ—k\ÛÀ¶ð…\É\Û*ó\×9<\Ô\îÝ\×Ý¥ÿ\0\Û\×~\Æ\Îý,þýmÿ\0\Óc¤øGð\Þ\Û\âG†ü_n‹ZÅ ±–\Öú\êgŽH\Ú\àG<²‘\åª0f%Ir:\Z\ït‡ú„üae§]Z[Á\â;^\ÞM§\ê:Wö•\Í\ÚA{$¦]÷˜]c2+€\ê\Þ|¦\ï\ã7Œ/µ\ï\ëS\ê\âMO\ÅVòZ\ëe„˜Ü‚\ê\0LG£”\nzŒòkF\Ëö‚ñµˆ¯5\Ñy¥\Ü\ê\×v«g-\Õîƒ§Ü·’#hŠ(’¹•ö€dw\î¤\ï(r\ìõ¿þÕ½iùöV\ÔZM·ª\é÷§ú?\éš\ßþ\n\èž8ðÿ\0‡\ïuO\Ü\è\×þ ×¤ðþcm¤}¯tÊ–\ì²I!š0‘\æ\áT‡+v\éø\àÿ\0†FñF§y>·©øwV\Ö,4k[\ÖÁ!¶ºò^k¯=Ì·g±\ÈU~f\Îm~\'xŽ\Æ\ïK¸µ½†\Ñô½ZMr\É-ì Ž;{\Ç1‘cT\n÷b<lpd\çWHø\í\ãm\Ã\í¢\Ùjð\Ådm.,7¶Ÿl÷eŸ›n\'hÌ¢&2;y{¶†;€ª–±vÝ¯\Òßž¿‘Q²k›ú\Õþ–ùõ\ïÒ¯À}$\Û\ÝX7‹\'O\éúe®±¨i\ÇJÍ¬Vóy,V;6\é%H\î#b¦$RC\0\ç\0´\Þ&ý˜õ\Ãs¬k––VQj1\éð]I\Ü\×rÀZ~s/;\0>QÓœž8\ÝC\ãGŒ5O\ãT‰¬M¼vrL–6\éw5¼d\á–\écK\í\\F\îTlN>U\Äúÿ\0\ÇO\Zø¥®?µõhu¸\Õ\"\ÖfŠ\ãO¶xåºŽ1;¡k\r€„ln¬¤’i»s&¶¿Þ¯øiÿ\0®™«ò\Ù\ïo¹\Ûñ\×ú\ï\'\Æ†ÿ\0\r/\ì\"²¸\Öu+µv‡R\Ô4\Èm­n‚7\Ú\Í\r\Õ\Äw	\È\Ë+^–>Y\è‘x_Çº\î¯\á\ËK£\Ø[Kik©Mu*ò^C1û<\Ñ9ù]°7c=«Ÿñ7\Ä\ïx²m1\ïe±·M5\Ú[Km/Kµ°·ŠF*Yü›x\Ò2\çbeŠ’B¨\'\0\nÔã§Œ—\Å#ñ÷\Ö:†§\â,jKG³»†\ë®3°´cŠF\Õ\"¦7[ùÿ\0Àþºyô©k·—ü\Ò\îgÿ\0ø›\Åò\Úòó\Â>¼\Ñô\í`)k9`°’\íIû3O{{j1”s\Üò2A\ÚX\ç]|!ð/„üñ\ß\Ä\Úî°¾#ð\ç‰ \Ñ\Ú\ïK\Ò\â\âôb=×‘oY<…ffPSb…\Þˆ\â,~>x\ëO\Ö5½Pk]^\ë3Cqy%þŸmv¦Hw^5–6Xš0\Ä!Œ)A\Â\à\0*µ¯Æ\Ûj~%¿{\Û;\éüGqö½Q5-*\Òò‰·;	|©¢dGG\Ã*‚70\r)^\ÍG\ÏóM}\Ê\êýz¦R·_/\Ê\Ï\ïzþ§]\à\Ù\îü7Ÿ\Ä-®Ë¤\êa¾¿´±½Ž\É\"¼Ž\Õ\ÜÅºô\\¸\"\']\Éj\ÊH-…f3]ö‡ñ\ÓÆžð²x{O\Ô\í\à\ÓR\Ò\çOB\Úm«\Ü-µ\Æó4\"\á¢2ˆ\Ø\È\ä |d\ä\0@5ÀÓ—\Çu·ü?üWÃ®ÿ\0Õ¡>3|?ð„^?\Ñü\á´ð®—5Æ«mc#igX›RdURn>\Ô\ßfn_8„\ç rk˜µø7\ámk\ÇV\Ñüw5\Åù¹¼µ\Ô$½\Ñ·0D\Ï\æ\ÄVWóbbŽ¹o.A€|¾q\\\çˆ>5x«\Å\Z†¨_Ë¥iX]Ey¡k¡X\Û\\™c\ÆÆ’X¡W—HXA®Kñ–±£ø™üAgy\ä\ê\î\Ó;\\yH\Ù2«,‡iyÝ¸\Ï¤\ï}<ÿ\0K~·\íg\åú\ßôûŽ\Þ\ÃáŸƒu†¿\Ô\ì<k¨\Ë\á}/Oûn§s6‚þ	\Zu‚8R\ß\í&9³£óÀ»8 +i\Ü|Ð´˜õ½SSñ…\Ô~±³Óµk»=Kwu\râ±Œy\r:*H¥p\ÊeÛ€\Ä;aCyßƒ|y­xú\æ\ëF¹†#u¶¹·»´†\î\Þ\â\"A\Ù,3#\Ç Ê«\0\ÊpT‚«:\ç\Äÿ\0x‘u…\Ôu3q­öµF ¬$jªH€©U\0Sw\Ò\ß?\ÇþÝ·P]oòü?\àÿ\0˜M\á\ï\rG}âˆ“Å¢KkŒšD\ãM”j·˜Š©?¸;œ–\È\n‚r\rrõ¯¡ø»VðÝ†µe¦\Ýýš\ÛY´û\rô~Z7˜’m\ËW\çWŒg\Ö=¿¯\ëúÓ¹þ\åÿ\0üú/¤¼{û5\Ýx\à\r\Õõß‚õ\Ã\â«­>\îÿ\0]’\Ú\ä[Goq\Ã<ñ\å:E²\ß|¼\âIJd\07|\ÛZVþ\"\Ô-|?}¡\Åq·K½¸†\î\â\rŠw\Ë\nÈ±¶\ìnIÀ \Ü\ç´?ŽMlÿ\0\É_‹Õ\ì¥\Ô\ØñF™¤\é7ðE£k_Û¶\Ïi\Ò\\}•\íü¹š5ia\Ú\Ç\'\ËrÉ¸p\Ûr85\Ö|%ð\æ‘}§ø\Ë\ÄzÍ‚\ëVþ\Z\Ò\Öö-&I¤Š+©d¸Š\Ý<Ö•üµ3o!I\Ú\å\Îk“ñG‹µo\Z_Á{¬\Ýý²\æH,c“\ËD\Û1¬q.\0pŠ£\'“Œ’MK\à\ï\ë^ÕŸQ\Ð\î\Ö\Öy`’\Öd–\ç†\âx¥†Eh\åC\Ý]H\È««ùÿ\0Àþ¿2{|¯ø_\ïþ’\Ø\ïü\à#\ãF±¬_\Ë?ô{´¯%¬£‘\Ë\0]OR‹k6\Ö!DŽ[ka@S[\Ö³F•°4}sÆ’Xj÷,»ð…Œ\ZGÚ’kˆ|&wi£	i\Ô†A\n\Ã;xm3ã¿‹ô[\íF\ëO—G²:§‚\ß\Ã\Úr[ù\îòeHD\\r&öÄˆªÿ\01\æ¨\Ý|bñ}\î¹i¬M«ùš•®µ/ˆ¡œ\ÛCò\ß\Ê\Ñ4“cfL1ü¤mxœ\Ïkmÿ\0~—\ë£ýmò:\í/\àn}\á=\êo\\E\â][E\Ôu›]\"-$<*–mre¸3.\Ý\ëj\åJ£óÁF6‚\Z5¦Ÿo?Š\î—\ÄúV•o­\êZji!­ãµ”D\ì°\Üy\à\É2G<lU£D$0p	\ámþ$xŠ\ÖM9\â\Ôv¶Ÿau¥ÚŸ\"3\å\Û\\y\Þ|w\ßi›“’7ðF4µ/0Õ¼/ýsªD\Ö-mœ“%º]\Ïo8%ºX\Ä\ÒÄ»W»••p\å×—\å÷\Ëôå¿£\Õu§\ËÍ¦ßOø?ðM\ïŽþð/„u-.\nj:\Ä\×3izmÔ¶·\ÚbAÙ¬b•¦‹©[{³\î1\í\n¥\ÈV!Fxÿ\0‡^²ñ§Œ´½\Zÿ\0Z´\Ð-®\çHš\îñ&u\å€Ø¢(\äm\Ç8]¹\ê@\æ—\Äµ\ß\èz^•ª\Ëeu›p\Û\\f\Û%ØŽ4\Ùor±‰¤E\\\0®\ä\0aiÚ…Æ“¨Z\ßZI\å][J³E&\ÐvºT\àðp@\ëW£Rò\Õ_ð3\åM(\è\ì¾û^3\è¦ð×Wö˜ðï†´\ÔðÍ­Œ:\Ç\Ø\à]#M\ÔuXgŸ\íKP\êj\Â`|\í\Úrp#oœxWÀZŠ´Ÿx£\Ä~!—\Ã\Z~›©\Ú\Úm\'Hm+\Üý¡€‰Ñª*	\Ã7\Ý\Î	 +sþ\Zø¡\â	ø\Òió\Ù~iš\ä\Ý\Þé–·{&ižj$Ñº#‡\0†P\ì@&«\ëµ½nV	å³‚\ÛTº·¼º¶°\Ó\í\í!i¡I&X\áU0²É ,IóY\ÓVŒUMZ\ß\ïW·\É4¾^¦²³r¶‰\Ú\ß+ÿ\0™\ìýžü;¢üM\ÑôŸ\ëwomu\âù<;ic¦\é\Þp\Ô<‰\âŽfšCq·¼\ÔPS\Ìq–;~Q»Ào#X¯\'EUv\0{^‹£þ\Ñÿ\0´R\ëR²\×!]B}F][\íRé¶’\Ë\rÔ¤y²B\Ï0\ïÚ¡\Ä{C†q^m$,Œ\ìr\ÌI\'\ÜÔ«\Ù_·\ã§õú!+Z^oüÿ\0\Í}\ÝOR\Õ>\nÁoð\ßJñ›©jZõ\Ý\àƒ\Îþ\ÍÓ¡›M±’W\n!¸º[’ðKó²Xq\Î\ÒË†;ð~\ÎZF­\â\ì=#\ÆS]\êzˆl¼=­#ÉŠ\Þ[‰š6Ù¼\æ3¢ÈŽ>u…ˆ\Ú@\ä\ã\Î\î>+x†\ã\Â\ã\Ãñ¾™c§lŠ)NÑ¬\í.\'X\Èd\ÜE\Ë(Üª\Ç{¶YC\rijÿ\0<u­\Ég-Æ´‘\\Z\ÞE¨ý¢\Ê\Æ\Ú\Ök‹¨¿\Õ\Ïq$Q«\\H§$<\Å\ÎYŽr\Ç:;_M¯øiÿ\0\ï\Ýng¯/¿\à“Ø¿\à‚‹\ã(|;#ë©§&­ªjZk<–¦E·–±Nd;[,\ÍÛ€26\ç\æ\Î(\ÒþøK\ÄZ…\ÕÆ‘\ã[\É|7¦iRjšµ\Õ\æ‹\ä^Ú…™aX\Ò\ÜN\Ñ\Ê\ÎòÃ·ó\Å6óKVøû\ãf\ãJšmR\Öì§º’\Ê*\Ò\Ö\Z\áNDqD©—Q\ÎG\\ž¤š\æ<\ãM_Àš³j:5\Äp\Ü<2[J—\Ñ\\Á4N0ñ\Éª\ÑÈ¤©\0õ\0Ô«õþ¿\ÏSIr\ß\Ýþ•ÿ\0\ËC\Ð~ü\Ñ~ M\â\rFI§xKLšhõ\rF->\Ê\êy¥We_&\æþ(@)3‹†n\nr\Û<\ç\Å\Ú~ñN­£Å©Y\ëX\ÝInš†Ÿ*\Ëorª\Ä	#e$a\ÈÁ\ï[úW\Æ/hºŽ±wh\ÚJG«ùm\Ó\ßB±“O”\Çþ­…›B`V^p\Ë#ssó6yBúMNþ\æòe…%¸‘¥u·!Œ9!c@ž@ \0P\ïum­ø\éÿ\0°´³=³Àþðn“ðZÿ\0\Åú®¥\áoUžù-\"±Ö¿¶Z\â	$1/\Ù#Œ4\ìv`³´@/,	5‹©|\Ólt]Vñ<\Òx\ÃIÑ \×/t–\Ó6\Ú$XŸdwBR\Ï*¤ñ’J¹\Üœ\Þp<I¨\r¶€.?\âR\×bø\Û\ì_õÁ\nÝ\ßt‘Œ\ãÚºMK\ãGŒ5oÿ\0`\\\ê‘5‹[Gg$\Écn—s\Û\ÆAŽ	n–14±.\Õ\Än\åF\Ä\ã\å\\\Õ\ÉÇ­­\å§ùý\ëªt\åRó¿\ßþ_s\èj|Røgá‡sjZ]¿Œn5_\é\Ó\Åö2h\æ\Þ\ÞDu,LS‰\\³&P2º \É;YÀÉ§ð7Âº7> .—¯¸‡Km3SžI\ØHD\rŒò¤¸Œ†mŽŠ\ÛG\ÞÛŒq\\Ÿ‰<I¨ø»\\»\Õõkµ\ê7Li¶*n œ(\0pASø?\Æ\Z¯5\èu\Zha¿Š9b\â\Ö+˜\Ù%¢‘\Z)U‘Õ‘\ÙHe#š\ë~©þ_\çó\×|ð¿\ÃZ\Å/†SÅ¯Kªh~&š94\ï\ío\Å6ë…¼6þM\åŸ\Ûù%”’\Ë3§\î\ç ržð\â­\'Åž(ñˆeðÆŸ¦\êv¶‚\ÛI\Ò\ÛJ÷?h`\"C4jŠ‚p\Í÷s‚H\nÔ­~:x\Æ\Ï\Æ~&Ž\ïMþÕ±…-\ì|\Í\Å\í¬Q:ýšÙ¡0ÀC‚Û£E;™Žr\ÌN&±ñ[\Ö\á\Õ`ž[8-µK«{Ë«k\r>\Þ\Òš‘\"eŽ\ÕS,™\n\0bÄO4\ãk®o\êò_ûj·­½G¥Ÿ¿\ïø¿\ëc\Ø<û=øwEø›£\é>9\Ö\î\Þ\Ú\ë\Åòxv\Ò\ÇMÓ¼\á¨y\Å\Í4†\â#oy¨ §˜\ã,vü£w›¤\ÛüñEÝŸ\Ù\îu\×,mn\Ö÷G_:\ÑYn\Ú?²\Þ	\Ëma	ó¢\\¸\'o5´\Ú?\âƒª]jVZ\ä+¨O¨Ë«}ª]6\ÒYaº”6HY\â&ûT8h`0ÀŽ+&\Ç\âÿ\0‰4\ß\ÞxV\ìs¢\Þó¤º„“\Èÿ\0>\Î\Ðw¯› Wß¹¤\ny,÷²û\î›üŸß²ZW¿\Ã\Þÿ\05÷ksªñÁ\rGð½õÍ§‹n/üCc i\Þ\"º\Ó[Iò­\ã‚\ë\ì\Ã\ËûA˜“\"¤8\í+\Î\àr¢ÿ\0\Æ/\Ù\Ö\Ó\à÷„\ä¾\Ô5­d\ë}Œ·š\0µ³¿ù\É=¥Á¹-<	€<ÁÉ’<…\Ý^sÿ\0+\Ä-sw4·\Þw\Û4\ë]&\åLH¾m¥¹„\ÃT¸û4?2\Çg\'“ŸDø\Çû@h_´}F\Ú\ÇÀ–ºF¡z·’j7a–xpX²\Ç,6ó6\â\ÃsO$Ä“–ùª§·»\Õý\Ê\ëôý|…œ\Ýß§ÿ\0%•¼\Ï<øw\àY~!\ëº]½\Ã\Ãyu{i”\Îð\Ä\ÒyXcpR7sƒŽ+\Õü\'ð:\ßÀ?<¥x›T·šóTÔ¼»xWG]OO\Ö\éa„È¯<>e¼¿1\'†\n\0\ÚsÇx7\ÆZ\Ç\Ãÿ\0[kº\r\ß\ØuKu‘#œÄ’€\Z7]JU\Ør;\×E¥ürñŽ“®hz¼Wös\ê:Œzv›5ö“guöXc}ñ\ìYb`[‘.7Ž›±U{J2]7õ\×_\Ëú\ß9&\ã%\ßoòý­:/†¾ð?‹4ß‰Z‡Š®õ-6\ïN±7–\Ñ\èúRM°k\Ûhü\È\Ã]Å“ûÖŒD\ÃhW-»r€tüð‡Á¾6ð?‡A\×ot­oZñ]æ‡¦\Ü\r4\Ì×‹\åZ}Ÿ\ÏO´¦;™LŒ \0\ár<ûMøµ\â=#\Å\Z–½fú]½\î¥µ¼·]\Ë\ìS\ÄJ’i\äùe¿\Õý\å\r×š­gñ3\ÄZmÎ•=¥\ìV­¥j\Òk–K¤)Žb-\" M¸ý\ÄXLlpsVIy%øÿ\0—ü1´¥v\Ú\î\Úôq²_\'þkSš–6†G¾ò’§ð¯K\×þøo\Ã\ÞÓÇŒ.?\á\'Ô´›mZ\ÓLþ\Ç?eq6\Ü@\×\"R\Ë.û¢„Ë©$/™\É#K#;³I÷5£­ø“Qñ–/¨\Üý¡¬­\"±·;6C\Â/\Êp;žOsMl“ï¯¥\í\ç{\í\Î\Üv\é÷«_\ås\Öþ!þ\Îzg\Ãû8’\ë\â‡©úiÚ•½\ÅÅ¬‹n\å_|‘¥\Å\Í\ÃFŒ›[Ì·‰\Æôù3¸/Kã¯‚¾¾ñö“ðÿ\0\Ã~Š[xÎ¡¬[M¨­ò\Åži.\r\ë\Åf7ü\ì‚2€¡\Þ1¸×x\Ëâ¯ˆ¾ Z\Ç½&{*º\È\×\ë¤Y\Ã{3*\ík¨\âY¥$uó²pNH\ÍC\Ä\ï[ø\Þ?Çª2x…6µˆc\Ã(ŒEµ£Û±”\Æ62•!!\É\Ê[¾m¿\à~W\è\Ö\ç¡\ß|\ÐlüQwhž<¶º\Ñmt)5\É\ï,£´½¸„G0\àx\ín\æˆHAÜ£\Ï †M\Å2\ÛcðoÀŸx\Ö\ãX\Ôl¼n\ÂVeˆj7pY\Ø]5\Ä\è\î!ho/`ˆò¤\ÜRw\è¥C\Å8MC\â~½¨__]ƒ¦XI}`\Úe\ÊiZ=ŒR[³*c‚$MÄó\ãw\0gƒ~$k\Þ‹PƒIžÑ­5\0‚\ê\ËRÓ­¯\í¦(IFhn#x÷)-†Û¸n`\ÉÈ·\×úw…­óüG\åý+/\Öÿ\0\'÷zfƒû;\è\×V¶—\Þ>Au©x¢\ã\Âú[húj\ß\Û\Ý\É€¥Çç¢¬,n70\È![¼]\ç\Ã\Í\Ã\Þ\Óu­\ÄvÚ¾±\r\ÅÆ—¥\é\Új\\£G¯ë‰šxü \Ò\Ç C„$M¯\Ä\ï\Ø\Ý\éw·°\Ú>—«I®Y%½”\Çox\æ\"\Ò,jBþ\â,GƒnŒœ¾\ßâ—ˆmü\'\'†š]>óIf™‘/ô›K©­Ì¸ó<‰¥‰¤ƒ$û¶^rz’ik\Ë\çÿ\0üÿ\0\á»VŸ×«ý-ø\êw>%ýŸ-|+ð\åµ\Û\ß\é±x,-µ#¢=Ý†dŽ-’8À¼7&Qª\åZ\Ù\nør—ñª\ëõoŠ\Þ\"×¼/o j2i\×\ÖvðGk\r\ÅÆ‘f÷\Ñ\Ã\Ìq­\á‹\íWBù˜\n6ý\Þ+ª¶\Ý	_\nO~§±|;\Òü\ã\ï\Þ\Ó\í´O²xmôô[\ÛMJ\â.K˜¬Y§‘š\'2\Ì\ÈÍ„ \í\è\Ýü+k\àýcö‚ð®ý\á{\ÃÚµÕ¦›5¾‡6µ¢ù³ª´ˆ\×2\Çp%\nq\É1ôùMyO„üYªx\Ä6šÞ<vÚ•©c’Á\éó)F\rŠ\ÈÀ«†s]›ñ›Äº?Œ ñM„z\ržµk2A\á­5!ˆ«‡Yo\å,¡€Ä¡CöÝŠ}S~\×õ±2MÅ¥\Ù/\ëú\Ô\Úø[ð^\ß\â$zö¥¨\ë°x{C\Ò\î\"´34\ÖI#\Í/˜QT^]\Ú\Æ@Xœ’$-÷p¬7\í<7û,\è:¥ýÆ¡ñ8–\Þö\ê\Þ)´1u{˜ ºµ¶óRQ:ƒ½¯!*\r–\\|\ÃNø\Í\â+S\Ö/mŸHU\Õü¿¶\Ø>ƒ`ö˜ÿ\0Õ·\Ø\Ú²ó†T77?3f;OŒ^-\Ó\í^\Ö\ÓR†\ÒÕ¤–_³\Û\Ø\Û\Ç\Z™\'‚\áÂª\Æ¯›kP\0Ù€’	s.m­¯®Ÿð~ò\ê>f\Ü4\×ðþ¿®‡¢]~\Ì6úO†u\í_Æºf—¨ª_Makqsa\\\Ço$±\0\â[Ä¸W‘\àuQ¼«–L°\Ël\Ë\Ö>ø{I\Ðn.Œo.µ{Mñ\rýŒZ(CktmE•®yS\íHv\ì\n\Ã:œªò—_\Z|Y¨h—ZMýÎ©\ÚN÷n\Ôtk+© 3±y|‰¤…¤€3³6\"e˜°Á$\ÖU\Ï\ÄO\Þhyº†ÿ\0·\é–ú5\Ï\îce¤O“\Æß³\Ãó1\Ù\É99\Î<\Ö\×\Ëõüôý,W»\Í\åÿ\0~—ù\Ûs\Ùo>ü5\ãwÃ­JŸW\Ô\í5O\ìV¿\Óoôñk°\ÜZ\Ã#\É\ç¥\ä’¾\â€(B\ì\ÈPMcö\Ðu\rC—G¶¿Ž\Û_ñÁ°\ÔaU–e\Òþ\Å\ê\nK<Pþ\é¼\Õy\Ð-\Él-y\'ü.nð\äŸl²û_‡šÓ¯¿²­>\×’»bWŸ\Êó%E$fP\0ã‡\è?<k\á½/DÓ¬5­–\Z-\Å\ÅÍ¼ÖN‘4\èc˜\"6ôuf6\Ê|\Í\Ç&®Z¦¼ôôº’·]\Ú\êB¾\Ê\ß>V¯÷»þ;­}Z\ÃöG\Ó/¼]i§¨\Òo¬l\î\í/\í\ì­\ïž\ãPû\Æ\Â\ÞòHF\Ùy,“¾7\r•J\ßö[\Ó&»šñ¼o\ZxYm-\'Sš+)¥–\ã\ÎÚ‚+\Ë\è#\Ú¼§>vüý\ß-³ƒ›ö‡ñôÚ•÷ö\Ô0\Ïg\r½½²\Ûé¶°\ÅP\\‹¨Q#H‚*¤À0\0co\Ý\â©\éüc¤£Dš…¥Ý«ZCb\Öz–—i{l\ÑD\Ì\Ñn†hž2\È]ð\åw\r\ì3‚h\é\çw÷ko\Óú\Ü\êûY[\×Kÿ\0_\Ò\ìt\Ù[]ñ[k²h\ÚÝž§a¥\ê\Ø-öŸ¤\êÚ…½Ï—ƒ\æG5•œñm`A\0É‘ž@&‡‡n¼5ÿ\0\n?\ÄZ×€´+\ÝoL\Ô,tØµI®u•\Ö\â;\ÆiY\ícÞ¦ö\áõÜ­šò­BúMNþ\æòe…%¸‘¥u·!Œ9!c@ž@ \0U«j¾¾\Ð\â¸Û¥\Þ\ÜCwq\Å;\å…dX\Ûv7	¤\à\îs‰×‘\Å\ïe÷¦¯÷«•¥\ï\êz¯ˆ?g»/ü=\Z\æ¥\ã>\ß[[+]FM\í6\Ïþ[*D¢ó\í-0ŽUr¯n‹ò¾¥©x¯\à\î\à{MSÕ¼S}.¯\\tÙ¬4„–iljL\ï\\ ŽO1\Ä~Ib~Wm\Û|³\'-¨|Zñ&¯\á\ËMþM2þ\Ò\Ò(­à¸»Ñ¬¥¼H£ \ÇºhLûB\ï\Æß—x¨u¿Š>&ñ%ž©i©\ê+ym©]%\ì\ÑIm\Ø\åE­\0\Ùû€*m‹`(ˆ¤mUDÒŸ5´¿\áuúzö\ëx\Â\Ù_{~6þ¿\Ö~«®|\Zð¦©ûOK\àŸ.µª\éðk‹}¥>Ÿ\å´6ö\ì\ÎðÛº\ÜJóf8\ÝC0F\'o<A\ã€vÖ¿5K}F+ß‡ú*ør?}Š\â\Âi®-£\"1-º\Å+«–Y¨»ß‹¹€%‡®|lñwˆ®¯.\ïo,M\íåœ¶w–úEœ\ÝE!S\'›$q+H\í±s#ÿ\0{\æù›9Vÿ\0¼Ck¤Ç¦E¨m²O›JH\Ì’-e›Î’-\Åw`\ÈKu\È$\àŒš\Æ\Î0In“û\ìÿ\0ò¾½~uö®ö\Óîº¿\áÌ¾\ç\é\è^\rø\á\ï\Z\Ük\Z—\ÂxJ\Ã\ì±\rF\î;¦¸\Ä-\r\å\ìžT›ŠNý¨`X¦Ÿ\Ãÿ\0Ù†\×\Æ\ÚÞ«¥¿‹¡¶òu–\Ñ4\íZ\Ü\Ø>›¨\Ê1´\Ç,·\ÑI&w!+S0¼ÁO–x7\âF½\à8µ4™\í\Z\ÓP.¬µ-:\Úþ\Úb„”f†\â7r’\Øm»†\æ\0Œœ\îøO\ã÷ü¿ûP±°ÿ\0‰ƒ\ê‘mÑ¬Ÿ\ì·.]\í÷B|Œªª•‹j•\0cV’\ënßŽŸðmò½\É\Ö\ß\×gú\Ûñô9ûk¯\Ùø/[\Ó\ï4É§ñK_[A$a6ê²‰Ñ—p³q•<+r½›§I#K#;³I÷5¹u\ãn÷Ávš÷‡\ìo%¿·³òlžEUw\Þq\ÈE$Ž-u}týå¯›õ¹r·7»¶¿\×õÿ\0\0\Òø; \Øx«\â×‚´]RµišŽµgiuöO2\'\×r\Ã ‘Aô¯Gø•\áo\Û\ÚøCW²M>\ÃLŸP¼³\Ôu/A{yg˜„MB\ßRž9Œ\Ã\ÎK$e]veq^1\á\ízÿ\0Âºö›­isý—SÓ®c»µŸb¿—,lk§‚=\Åu\Z—\Æo\êÚž—yrtv\ZcJö¶) i\éb¯ I\Z\Ñ`;°—d-ò\'?*\ãH\É\'ú;þ_\×õbÚ¿_ø?\æ¾\ã¸ñGÃ/ÄŸ~,Ç¬j¶~\Òü.nn¦mDýËˆ\î\â¶Ák\çc(!L„Á`	aGQø# ønmSQ\ÖüU…`þ\ÍW–Z2Oyv×¶¿jˆ5»\\¢F Ûœpp6I‡‰¾/ø§\ÅÚ¦·¨\ê7vbó[µû¥%ž—kiö¨üôœ—Ä ¹’4c&7¸,GgHø\å\ãMieµ\Õa-$6p\â\ãO¶cû,Bi#F\Â9cAµeLH2N\ì’j)Z\n<Û«~zþ\Ó)\ê\Û\ï\Òß\ïòùz.¹\àÿ\0\rxg[øùa¥Cn&\Ñ\r\Ìz~£¤‹¸\à³\Z„¬]5Àx®˜\ß*\æ\Ëq\Îh¿t]SÁú-\ìž,¸‹\ÄzÎ‰¨\ëvšDzNøV;6¹Þ²\Ü—nõµr¥Qù\È`£±l>>x\ËO¸ñÀŸG»¹ñò\\j“\ê\Ó\î\äºid`\Í,BoD}€… €5\Ï\ÚüDñ\r‰\Ó\Z‡—ý›§\Ü\éVŸ¸Œùv\×w\Ý\çw\Úf\ä\äüˆI¨[\íY+ü¥ÿ\0·4þÿ\0B¯Å¿–Ÿ\äÿ\0\Ìô½sös´ð¿\Âs\ã\r[[\Öm¥“L´¿´Û ƒ¦^\És´\Çm\r\ë\\®ùUX´Š\"\Êyr`6Ü›¿ü-\à\rø²\×@°oh–p\Þ\Å\ä\ÚZ½Þ­mŒ3¥Ü‹lü¶q0@\ÍSñW\í\r¡x“Ào¢ÿ\0\Âký¬úU¶™ý¥xl§òŒQÆžtr}‰o7\â?”=Óª\î\Æ@Z\âõÏ\Þ)ñ&¥§\ê:‰\Ñ\'\Ô,n\ê;µðæœ’\É\")™\Ö\0fþ@$*\ß\Æÿ\0–ÿ\0…þÿ\0óò2×‘w·\ãoóû¼\Î\Âo\Ù\Æ\ßIñÖ\áMc\ÅKa}w§\ßj÷W1X\í\í¬\á†i¡2ÉºF• f(\Ã(9pÈ°\Ûü\n\Ðo®§m\ãµð­Æƒs®‹ËRõV\Þ\çÈ–#l·»‰¡óv¶@%9+‰à¿^\"ðÆ­my¨<~\"KUÔšõ(a™\Ök\Ëyb‘™\ä\ËÇ¾S#BÙ\ÛvFXµbj\ßüU­_]\Ü\Ü\ê1©¹ÓŽ\Öö\Öp[\Û\ÇhX1†(cEŽ,7-W,XõbL\Êö÷{?¿Þµý=\Û\Ú\Ûy\Ø\ÓKùiù«ý\êý_o3·ðoÀŸx\Ö\ãX\Ôl¼n\ÂVeˆj7pY\Ø]5\Ä\è\î!ho/`ˆò¤\ÜRw\è¥C\Å |\Óõ†ñ\\Qøšmz÷G¾–\Î\Ú\ËÁöPj\×± \ÏÚ–#u˜<B]¿1m \r\Üƒ~$k\Þ‹PƒIžÑ­5\0‚\ê\ËRÓ­¯\í¦(IFhn#x÷)-†Û¸n`\É\Í\í\âÿ\0ˆü.×’ik¢\Ú\\]\\=\×Ú—\Ãúy¸‚F›yL\íÀ\ÆTDP!\å@4\å×—·\ã§ü¿\æJ\é~ÿ\0‡õýt6to„z·Â›ŸCªjZž¡\n\Í$º^‡¦\Åz¶(‡\ï[\í)-º6	ó<—|Å²¢m{E\Ó\äø\'\àŸ\ì_³\Þ\Üj\Z\Ý\ä\Ïq£¥­\ê\\$6¤\Ãö‘<žt¾]»–2\âG5\Ì\é¿üA£xf]\n\Ä\év¶³C%¼—Qh\ÖBù£Ÿ1\r\ç“öŒ0b¤yœ©+÷x©¯þ/x“Rð]§…%:Bh¶¬·\Ðl!ž7\\$\"_1„Q†}ûœ(MV—w\ÛOÁ\ëýM+«>ºþ*\Èô\Ù\ÇHÕ¼Cý…¤ø\Îk½KOñ\r—‡u¯´iLVò\\L\Ðù¶\Í\ç1Dqó¬,F\Ò\'o>\è^\ÐômgBñ-Î»¥^jz\\÷Z_\Ø\Ìs[ˆY\ÙK!x\ÊÎ¥Y¶7(¦Ÿ¨~\Ð^<Ô®´û©u˜cº²¾‡S\Ûi¶°Iqu\ÌSÜ²D\rÌŠrCM¼\å›ûÍžFOj²\èöZ[]f\Â\ÎömB¼´ù\'•cY8\ÉÈ†>	À\ÛÀ9Q\Ýs[Á\ëó\íZký7ÿ\0k\Ók\éß°ð_‚|;ª|`—H‹SxWO—\Æò8Ñµk[yn\ÇtfEˆ¯\'#wZ±\á¿	h_4¿x\Ó\Ä\Ú\çü\"V6š•¥¸²\ÐôE¸÷Bv^tHŠ‚Áaò\ç’À\ç\í~+xŽ‰‡Ç“]\Çw\â).\Úò\âi¡A\Ã>DŠñ¨±Ô²²€EQ\Õ<\\\íµ¦\èÐ¶“\á\ÍJþ;ÿ\0\ì·uœ\Æ\Ñ	D#\Í*\ìY¤³žr@4BË—Ÿ²ü\Õûn´^k¥Á\Ù\ÞÇ¦\'\ìñ¦i> mÄž-›J»¼ñ\r×‡4–³Ò¾\Õó@\éM9ó\Ãich•¾÷\Ëò\Þ9ªi\Óhú¥\å…\Æ\ß>\Ög‚M§#r±Sƒ\é‘]Ý—\í\ã\ËF\æ=b	.o¯\å\Õ\Zk6\Öi »“\ï\Ïl\Ï6\Ò>hv•º1\ç²\Êó\ÈòH\í$ŽK3±\Ébz’{š…Í¥ûk\ëeú\ßþÁ¦¿\×øðO_Ö¾\è\Ö>½{/O}\â;Yøš\ãN“J\Û$­»EÁ˜³J¿hR\0‹k÷ƒ£O\Æ?³®\à\r\ÚkºŠ/ãµ‡P·\Óõkca&¡dóE,‰þ£!YJN`a\ØO\Çµ\ïh¶ú-´vº6ºnŸ§O¥¥º\\]‹X#Œy\×)\Í*ŒH#weRØ¤Tñ§\ÇO\Z|@\ÑgÒµ½N\Þ{‹´\Ô\'Ž\ÛMµµi\îQYi\Z(•¤“k°.Ä“\ÆIÀÆ·JW[]}\×ýV}{%²¿m}l¿\'ø\'¥\ê_\nþ\ÃIkþ°¾\ÔB´\Zè¹P±h£\ÓM½­\Ã\Äcx\îe’\ách\Ãe‚\ØS¸Šà¯´]á—Š¼­[?ü&\Ö-\r\àƒWÓ’\ÚY`3Mm<o\Ë(G)6º\ÈH;a\Æ^³ñ£Åšö¸š\Í\Ý\å—ö°¶¹´{\ë}*\Ò	§ŽxšŒ\ÏJfvFa¾M\Ì7\'5OAñô–z·†®5«(üA§øv\'Ž\ÇM˜ˆ¢ÿ\0Y$È²\\ºyÒ—e\',¤¨e©\Ú<œ\Ú\Ú\×ó^õþû¯Õ„µN\Ý\à_¡§\âo‡º/…þ-ø«\Âz¯ˆN•¦\é7\Öñj-j\×&W„?’…ðdeD\'¢–\É\èk€¯Fømñ’\ïÀ?5/\Ü[M¬ø’\â+£\ÒÜ„‡Ï¸GI$61•q#“œ\Ø>sYE4¢Ÿe]oúW*M6\Ú\î}\áŸø;\\ÿ\0„ÁóøN\Ò+\ïø^}I¼K\r\åØ¼·»F»er†c‹Ê¬¾P;Yˆ`pk¿g›(þ¿‹n<Esewkckª^i76ö\"qk4\ÑE\æC_5\Ã\ß#©–UÔƒ¹r¹\ã\ãø\Ý\ã|&ž‹PµƒO[\Ó\Ði–‘\Þ}‘œ»AöµˆNc,Í”ó0A ‚)÷\ß<i¨øBoÏ©Û\"{(4\é\Ö=6\Õ\'ž\Þ†\äb\ÈÆ›w9 	å¼œz½=.Ý¿$D4PR\Ù%_v\îÿ\0\'óù?\Åo‡>\n±ñ‡†4O\Þø‚òÿ\0T´\ÒØ¾\Z–ûE¤.eŒý²Bò»H\ÉÂ¨.T>ïˆ¿ôÏƒ/\á­z+\Û\éW\×WVr\éÚ„\0³B±–Y0¡\0N•\åq\Üe\Ç\Æ\\/‡\Þ\Ú¯=»\é·\é¦Z¥\ä^@k–E@\0#2€£Ž\\Ö¾;x\Ã\ÄW\Z<š…Æ“q‘<÷6VGA°[8¤˜(•°€DÛ¶);ü\ÃwRMi£4ú_ð\Òß¨\Ö\Þ÷d¾v­¿§¦\É\à_‡Z·\í\ãŸ\ß\é’øgC\Ñ`\Ö!²²\Ñ`šðJmm\î\\M+\ÏxH¾Z¸U;)	5\Çü=ø+¢ü@›\Ä\ZŒ>*“Nð–™4\Ñ\ê\ZŒZ}•\ÔóJ®Ê¾M\ÍüP€Rg\Ü.\å¶s7\ßüY¨|@_Iye‰0\á\î­ô«Hc›xu\Ë\nD#”¸‘\ÃV\Ü\r‘I¥|bñ6‹¨\ëv¤¤z¿—ö\Ý=ô+4ùL\ê\ØY´&e\ç±‚77?3g({©sn•¾w\ß\îþ˜\å®\ß\×õýXõ\rþ\Ë:©cq¨|EŽ%·½º·Šm\'L]B\Þ\æ(.­m¼Ô”N \ïk\ÈJ\Æe—\0œ-CöWñŸ…õ¯%ð›N\ÓZ\ïq]X`\ëo#£9,š\Øg\Ë\'&m£?3q6Ÿ¼[§Ú½­¦¥\r¥«I,¿g·±·Ž52OÃ…UŒ_6\Ö\n ³\0$[V\Õ.µ\ÍRóQ½—Î¼¼™\î\'“h]ò;c€\0$ð(iò\Å\'­µõ\Òß¨F\×wï§¡\ê¾ ø¢\é>½¸´ñm\Åÿ\0ˆlt;\Ä7Zi\Ò|«x\àºû0ò\ÅÁ˜–‘\r\Òö•\çp9Q—\âo…1ø\ë\Æ\×2\ÞE¬E\á[\è¯k=»\ÇøstK1IF?\ÑpU[?¼\á<½\Ç\ÄO\Ý}¼Ë¨n7úe¾qû˜\ÆûH<Ÿ&>¿f‡\æc³’rs\Ðxƒö€ñÇŠ¬c³\Õu»Q©$-£\Ù*\Ü\ÝD¬«4\áa{\ÌË»x8m\Ør·\Ùþµ_¢6\nÜ©=ÿ\0\à/\Öÿ\0+þ%Á øK\âv›qc\ám4\é7\ZN—¨>…,÷i\æ\\XC,Š\Ï\í\ß#0ý\îF\0\ÉUˆ^ð\î“û@x‹\Ã-yÿ\0¿…\í¼A=Ú„R]ý†\ÙgeÝ³qy6¨\é\ÇsU5Ïž\'ñ&½¥\ë:Šh77\Úl^E¹ÿ\0„kMX¼±RH–\Ü$ªˆª¨$V	·KøÝ¨\ÍñsKøƒ\â[Xõm[O¸[\ÕþÊ†\×J3\Ü#™\åòmö¾_—%w¸\ãx\àZñ¾\Ê÷ôv·®ßŽ\â“÷l·²ûÒ³ÿ\0?\Ðó›¨\ã†\êd†_>r©.Ò»\Ô¦G8¯Uð_ƒ¾j_|C®ëº®¹g®Y\ê¶6¢K\";”…eŽ\í‚.\ëÈƒ‡òT³2‚…\0PÁ˜6ñ¹?‰üAªkIwZ…Ô·r¤¶5y»8\'µ|#ñ]ð=–§e¥\Ëdö:——ö«MGM¶¿†FM\ÛË¸\Ô:\ï|0†\ãƒ\ÍDo\ì\Ú{´¾û§ÿ\0ô)Ûš\ëo\ëúýO@ð?\ì÷Œþ\Ï\â\×e\Òu?°\ß_\ÚX\Þ\Çd‘^GjŽ\îb\Ýz.\\®\äµe¤Â³_|2ðÇ…ü7c-çŒ®\Äwú=¶±m§cŸ²²\Êù-p%,²`¹º(BŒº’B\Ñ\Ðþ:x\ÓÃžOiú¼\ZjZ\\\é\è[Mµ{…¶¸\Þf„\\4FQ”Œœ€¹K\ÅZŽ·y¦\\j3}­´ûxl\àR¢=°\Ä0‰”Á\àq»;½\êÝœÕ´Z}\Þõÿ\0öß¹ü\åh®õzþjß…þÿ\0»\Ü|]û$Ÿ6•¥sT_jzÍ¾‹eoªhb\ËO½y^\æ\Ú\è\Ü3Mlœ~ôD3½2£u.‹ðÀúO\Å?‡úv¥\ã%ñ­j\Écqc`tû‹þl@,‚\ÏQ”G‚F_7\Ì¥÷g‚rþ\'þ\Òzo!š\ãAðl^×¤\Ô\ã\Ô\ãÖ‹XµÝ££3&{{y‹#-<³·\'\æù«\ÎõÏ‹^#×µý3\\–M2\ÇW\Ón>\×oy¤\è\ÖZ|‚m\Ê\âG6ð§˜Á”_v9õ9˜½S}ÿ\0/\Öÿ\0ðÄ´ùZ¾¶üuÿ\0€eø\Ê\Ë@\Óõ\É!ðÞ£¨\êzrŽf\Ôôô²”>NT\"O0*0\Ûòrx\ç±øCðn‰\Z~¯ª\êzôÑ´\Ùa¶i\Úk$’I\åÈª.\î\íc#lNN$-÷pŒ7\âü]\â\íC\ÆÚ»jzœzz]²\ìo\ì\Ý6\Ú\Â6äœ˜\í\ãD,I9b2x\É\àU\ßüH×¼¡“=£ZjÕ–¥§[_\ÛLP’Œ\Ð\ÜFñ\îR[\r·p\ÜÀ“’\Z/{sJJM\ÇDvºo„t;\r\âÎ…qg£\ë÷¾´7zŠ,.\çr\åo\ímóÉ¼—‰’W<£6[\ïqVt\Ùò\×Pøk‰µO\éº%õõÆ£§\Ø]]\Ø\"\ËFE\nþe\â\\‘\áuQ¼ŠIL°\Ël\å<;ñ£\Ä\Þ¶\Ömô\Ô\Ðc‡Xv{ÔŸ\ÃZl\â@Ì®ce»lˆ4h\Â%\Â)PBƒU-~+xŠ\×\Â+á–“M½\Ò#Ic5\r\Î\îkU\å\Ö	¥‰¤„%±.–$šZò[­–¾zÿ\0Àÿ\0 M_\Ê\íü´\Óóû÷=cXý•ô­?\ÂS\êþ7š\ïXŽ\ÊK‘¦Ë\äŽ\Ò\Ö\é\ÐM\çœ(Žò5\ÜW;Ávü\Õµû+\Ùhúæ¡\é²\ëwšõ®ƒg\Ö3=¼’¹G–à½’Y6\\:8\æO”Á|\Ö\ï\ãOŒ\ï­e¶ŸY\ß°\Ë¯\ÙaI ‚\Ý\ÆBg˜­`\\õ20K>¥ñ\Ï\Æ\Z¶§¤\ê—Wzs\ë\Ze\Ü7\ÐjË¢Ø¥\ëO6<\×’sÀ\'\Íf@-“W+s\'´üõü4ÿ\0-\Ì\Õù,÷\×þõù÷‚~x\ëÇŸ\Ìþ&\Õ5ÿ\0k^ }pº(·in\"’\Ût`}¨0‚E¸_\Þ\ådQŸ\ÝgŠòYh\Z~¹$>\ÔuONQ\ÌÚžž–R‡\ÉÊ„I\æ@\Æ~NO¾\Ã\Ç\Úþ—‘¦¢ö\ë¤\êO«\Ù\ÑCvþV\éCc$þ\â.	 m\àrs‹¼]¨x\ÛWmOSOK¶]ý›¦\ÛXFÜ““¼h…‰\',FO<\nl¿®ß­ÿ\0«šû¾õº\í÷¿\Ò\ß;ù§À;\r*ûÄš³^yµ4mF\â\Ê\ËQÑ“P²œ\Çe<\æ\æx\ÌL2Ž«&Ž9>ü ³ø\áWS:¦¥6¥k)Ž-\Ã\ÚlZüŠq™ k˜dò eÛ†,»œð\Ä\í{\á\Å\ÝÆ‚t\ØçºŒ\Ã$—ú=ûylŒŽªn\"}•\ÝX.7†È«Z\Åÿ\0ø]¯$\Ò\×E´¸º¸{¯µ/‡ôóqŒ96ò˜ÛŒ¨ˆ CÊ€i\Ë[òö·\Î\íþ¤.ž¿…Ž*º\ÍCÃ²xL³·\Ó&\Å1\ß\ÜIy¨´„\Å-©H„1ª\îÀeq1\'há—“\ÑyòKIÉ¤£¥ƒ­\ÏHø‘\àK;/\r\ám\Ê\â+i¦²‚[Ek‰‹KD„Wp]‹9Â–$\Ó\Ó-?fh^*\Ð~\Ý\âXµj–š\äs\Ê\æÙ¤°¸³°iƒ¸°¼¹V\n^\'\Ù\æ;H)‚7yN­ñ\Ë\Å\Ú\Õ\î—}sq¥¦§¦\ÜÁwm©Z\èV÷‚X@3\ÜG\n\É&\0;vŒƒW.h¯\Ý_\éWO¨\é\éý–\×mim‰cª}ª?.\äu€D\ÂD\áƒ)’z’h{YyþZ~!ý\ï\é\ëÿ\0ñ:mös\ÓüKu§j\Zg‹ðÖ“.­&£©\Û\ÚX]Â©uöCŠkÅƒq”®\\¨*Oñ\0…žø\á\Í\âW‰<!tš?\ì_B½¾³\Öa¼bö²E¦\Ír›M¥\ÓC\æ+ª«©i“(B’9<rüpñ’ø‹ûdjV\Â°3\ìÙ–¿\Ùÿ\0d\'qƒ\ì^W\Ùü²\ß>\Ï/þ|n\æ“Aø\Õ\â\ëÚž³¦&k¨\Ç\ä\Î\á\Z\ÓZ0†6–8šÜ¤J\È\ì®#U	ÝšOf»©}\îöû•¿­FšZ¿/\Òÿ\0©‹\á}CÃ¶zW‰c\ÖôÉ¯\ï\î,zD\ÑHUmn¼è‰‘Àa•ò„£7$q\Üs\ÕcP¾“S¿¹¼™aIn$i]m\àHcŽHX\ÐE\ç…P\0\è\0^6Hô­KI\Óü?ðóÀö‚\Æ\Þ{ÿ\0»\ê—w\ÒF\ZX\àŽ\æ[X­\ãn¨3®ø\å·\'8\\W°|JýŸ|-n|qu\á\"ó\ì-®\éúN–\æK‰­fûTö\×v\è­ óX´qº‡l\í’?˜dšð<}-ß€ô\ï\Ý\Ú	\ç\Òo\Z\çJ\ÔD˜{Xß™ +‚Âºò6¶þ»È­Ž\Þ;´\Z€‡\ÄF/õ¨üC8X!\çPGÞ³¯\Éò\Ø%W\np2)Ùµ\ë÷«\ÇO’Mzù6F¶v\ê¾\ç¯\ëo—¢=\'Uý–t6óN˜x\ß\Ì\Ñ&·\Õ&º¸Ž\Ú\Ê\î\âÙ¬aI¤Ë´¾ž\"YdPL¬\ÞUcgXý‘lô\ßMg\ã¹\Ñ\ìV÷ûKR¸µ·±0½½\Ìv\Å#7q\Äù’dyc\èø\ÜB‡ó=k\ã÷Ž5\ëxm\îuKX­aŠò\í¬t«;HQn‘R\ç\Å¨28\ÎrF	$¢ü|ñ\×ö´šŒš\ÌW\Ê\×fh\îtûi Ÿ\íR	\'Yax\Ìr+:«mu!J©P0*U\ïöwõ\éòþµ-\Ú\Úo\ÃüÎ·Oý–õx«]\Òü5\â;=n\ËL[wûu–Ÿ{©+‰£\ÞŽ™\r\äh\èAVB7)\Ú\Îk‚\×Cð}Ç´_\é\Ój:´0=–™qš¶¼Kˆ\ÃHñ\É\å¸_-f]2\0PWŸñ»s\âMZ}F\î+8n&\Æ\ä\Ó\ìa³„`\06\Ã\n$kÀþ9\'’k:–½{Ÿ‘\Ð\ØjÀºÅÖ™4\Þ(–ö\Ù\ì5ˆ¡·U—\ÏF]\Ø,\Ìa\Ç\Ê~\ër½¢þË±ñÀ\éµaioi«xoV‚Á\î!ECyot“È‚L\ãx$\ÃcqY\0\' y\åt\×\Þ3ó<§x^\Ê\ÈY[\Çr÷÷÷iw¾¸\åccÀ\n‘\ÆJªóó<­Ÿœ©kwvü\Zýù¿6%ºùþOõþ´5t\ßù\Úÿ\0\×%þB¬T6e\Z\Î²G±v«¶\â8\àdû\àT\Õ`a\ë¿ñõýs\Ì\Ö>±ÿ\0Iÿ\0\\£ÿ\0\ÐElk¿ñõýs\Ì\Ö>±ÿ\0Iÿ\0\\£ÿ\0\ÐE\'°(¢Š/\èÿ\0ñôÿ\0õ\ÊOý\Ôõÿ\0Oÿ\0\\¤ÿ\0\ÐMOT¶\0¢Š(\0¢Š(ðÿ\0\Ë_ú\å\'þ€k\Z¶aÿ\0–¿õ\ÊOý\0\Ö5&mð\ÏÇšOn/\ä\Õ|)câ•¹6¥÷f!]E3…\Ýÿ\0¬H\Ú#Œ|²\äeO­øáŽ›ñ[Áþñ¤\Z~†\çU\Ô#{x\íPýªO=.\Ø\í\n0¶\ßhe$\Ë €\0\Ã7V\æ“\ãŸh6öPiž \Õ4\èln\í¬v—²D¶÷v™£\n\Ãk•\0n8\ã5Q’Œ”ŸM¿òþ®\Ì\ç(¸®¿\åýÃž÷¬|%ðˆ5\È\â†\ß[´Õ¼Ag®\ë‰qe4\éš\\V·7\Â!\äYž2¶¡H L\ä\Î\Õ\Ì\Ô\í|#\áÿ\0>\Zµð\å\Ý\Í\î¹\âI/#&ÿ\0Áš|\Ó\\\Ê¼¥º’\âIm•2v4#,X’ôó-_\ã7Œ5\éž}vú\ßÃ–P</¦\Û\ÝÌ°]–¹’\à\É<{\ÊHû\äû\Ø\è‰\Üf¹‹j¶¿Ù¾N§yöl†k.\á\×\ì²^,‘·\0r¸9\0\Ö0Šºö\Û\åwú[\î6©.f\å\î\ÙõŽ>hú–©\à=F‹oig\âk?\ê7^\Ô,g¸ž)’0.%³²JeŠôþýwr«‚’\Ð~ü=ñBhÚ½¹ñF• K>·mq\ÍÅ¼\×W+aaö¡q	¢&N¢;ñ<Ãœ ð\Ä=oÁ>\'²\×,o$š\â\ßP·\Ô\ä‚\âWhn¦†O232†ð\Ù=s\ÉÁ­­?ã·Ž,üq‹\î¼E©k!·´¸²¶¾\Ôï§ž[dš)b&\'/½\ny\ÎËƒ€\Ø8<ƒZò»\î\ï÷\Ù}÷wûü•–4ÿ\0Û¾\ë{¿uº³·µð*iº×ƒu?h‘´ž$\Ñ\ç¾ûŒ–\ßRIŽ;™\"’\îGxc¢\Ù6ù!*¡›\0°V?\Ä+?|Tñü :<×šk\É$ð[iVnT¢&f™\"˜\â%^@¸ŠÌ·ø³\ã‹?\Ýx’\ß\Æ^ ƒ\ÄWQ.5xõI\Ö\îh\Æ\Ð\æ½—\äN	\Ç\Ê=?OñG<Y\âûR\ÇVñ³â›‹yk\Û{™ç½–ˆ‰8%\Ê\r“ \çŠO¿¯Ëªù òôÿ\0ƒÿ\0þ\ïþü)ð¥ðþø÷\ÄÍ¢Y\ß\ê“iv\ï—m\ÌQ\Ä\ï!X¬nD\ÌDÀˆ™\à\á>ù\ÜJU\Ñ~øoTøO©x\ÉN¯4še½\Ä2XE2+^N²D©w	0\äZÆ³/š¤\r°B\Ñù÷…>#ø·Àq\Ý\Ç\áŸk^Ž\ïo\ÚI\Ô&µc8\Þ#a»8Ï©ªö\Þ5ñ\rÖŸuo¯jp\\\éð5­œ\Ñ\ÞH¯mo\Ýl(‡Ì“*0öõ4\å­\í\Ûôÿ\0?ÏºBŽ–¿õ¯ü7\Ý\æ\ÏVñ\Ç\Â_‡þ	ø{»ñSË¤\Ù\ê°Z«Ü´w?hX\äò„_` \Èß½n	\î.\â‘ñÿ\0\Ä\Í\ÆƒNÓ¼¦øv\â;˜gk\ËA˜\ê–pÛ˜\ÉX”á¤‰\æ<ý\éNA?1Ào‰-“\Âc\Â\Í\âi¼0½4S¨Ll‡Ï¿ýN\íŸ{\æ\é×žµ\ÎQ-\\»7ú\Ý_\æ\Â:%\ÝOú\é÷?\Âÿ\0Zø\Ã\âW…4\çh\ìµMV\Ö\ÊwS‚#’eF#\ß×§øcP“Åž\"ø£\â\Ë\Í\Z\Öû[ð\îg\Òt[«5ž\Ö\Ê4¸†\ßþ=\Ùv:[ÀÍ…u*6†`pk\Ã!™\í\åIbvŽD`\Ê\èpTŽA±®£Vø¯\ê>8>0µ¼}Ä‡“Q\Ñ\ä{Y^m›dŸr¶VI9.W\0–niöùþ6³ù\Ã[Q-\Ýü¿ªù\é÷juzv¤<mðû\â^·ªi\ÚHÔ­\á\ÓV	,4›[%‡7!XÆFŠ„Ž	Pw\ÍzŸ\ì\Ë\á½3Xð’.l¼3%ßˆo¡º\Ó5]*õ\r^\Þ;(\\\Ú\Ù\Ï$GÉ——*|\è~f<W„\Ûüiø…k®\Ýkpø\ï\Ä\Ð\ë7Q,\ZŒz\Å\Â\ÜM\Zý\Ôy\îe8\'üG5ò_>¿ª=\ê_6¦·-y!‘nØ‚\×·dJJ®_\ï|£ž*m\î¸÷ÿ\04þcûJ]¿É¯\ÌÆ“caJœ)\äjöø?\áù¼;ˆ\"Ô®-ôKN\Ó\â\Ó&½¹Ž$\Z¤ò´S$\Òð°\Æm\î\ÜðQ[œŸ ¸¸–\ê\âI\ç‘\æšF.òHÅ™˜œ’I\êI\ïV\å\×õ9ôX4y5¹4‹yš\âŒ\ÊÀu;C\0$œ\n¥¶«ú\ê¿\à\ï{\rüM¯\ëúü›>ý¡>\èþøG\á‰4\r5Ž—«\ßi¿\Úún­§\Ü\Ý\ê¨!´a<†	\ß24\ì#\äÂ`¹¹/€Ÿd“\âš\Øø“IŽ\Òò\ïV°²ñ»Gm4‹lòÁ,¨Ë™!\0y¤m`\ë0À\àù+\êW’i\Ð\é\ïu3XC+\Ï«HLI#…\ê¹Àf€‘\É¹\è+B_ø‚}j\ÇX“]Ô¤\Õ\ìV$´¿k¹ö\ë!™Ü¡\0pF01Š\Õõ\ßõV¿­õ\éò\Ö1o\ÇÞ¿\å£=kã¿†ô¿\\|;¸ð~%þ±¯iò$‰§\é1Y6§*\\\ÉOº…ˆ>ÒªAab7®W\àÏˆ\ì|!\ã	-5ð¶¶’ºE4SxN\Ç[™¤Y\0ò¼»¼y9Ád\Ëdµ»rw~<ñ6¡\â¤ñ5×ˆµkŸ#¤‹¬M}+^+ L[x*\0\0\ç€Xð\ß\Ä\Ïø6mB]\ÅzÞ‡. C^I¦\ê3[µ\Éˆ2a¼ü\Í\×?xú\ÑMò;úþw~–\ÛKh)®eo%ÿ\0þ_3\êÿ\0ü;ðÏ„µ+K=WIÐ¦]W\ÆÚŽ‰¨i–öj—”’$†\Æ\ÖY“6Ð¢H\Ò=Àò\å\Ã&2Ë…ò\06‹¬\è\Þ7ðlCO\Ônm­5I4È®<;a·Ê…\ZapÚ²´«¨G*›v1¥\ÕX\ã\ÚŽ¼I\á?S°Ñ¼Cª\é6:¢yWö¶7²\Ã\Ú`²ª°0\Ì0\Ùá­Kÿ\0\Åð‰\Â+ÿ\0	>³ÿ\0\Æsý‹ý¡/Ø¾þÿ\0õ;¶}ÿ\0›§^z\Ö|¾\ï-ú[ðJÿ\0+]zôz—\Í\ïsy\ßñoñ½Ÿ§m kiz—\ì\ç\á‹ù4-6\Âk_Í§\És§Úª\\\Ï\n\Ú\Â\í\æL\Ùwb\Î\íó1U-…\n (\ë~.XøWXøM®\ë\Ú=\ç‡\îô\ë[\Úø{ûAm:{kgŽv{k™š\ÍÌª‹bZb¤d\ÉûÏŸ\Æ\î¾+ø\Þû\Â\ëá«Ÿ\ë÷X\Ò\Ñ\å\Õ\'k@ˆAE–ÙµJ‚001Ò¨ø£\Ç>$ñ\Ä\Ö\Òø\Ä\Z§ˆ%µÉ‚MRö[–‰3¨]Ž\Ñ\ì8«Ÿ¼\ån­?¹Gó\åù]ù\ÝG\ÝJýü[ÿ\0?—\ÊÇ4m?CÕ­ \Ólu½>	4ûY\Þ=zŠf‘\áVw@ fbLg©B¤\×qðGÁzo<1\ã½>ùí¬š\Þ\Þ\Îø\ê“[‰d±¶Ž\à™Pd1\ÄLÄ¨#v\Üg8¯/\Õ5C\\¸Ž}Jú\çPž8£$º™¥e* ,NT\0@\0Ÿ¥\ëúž‹\rôZv£waô\Ö\í-gh\Ö\âA1\È\èHi\È\àS\Ò\í¿\ë±-]%\éÿ\0úÅŸ|\áŸ4\Þ$\Óu;\ÍG@·Ò´¦²ð\ÜðY›Û«™/\Ý\ÞY\ZI!aL6\ÂX(\\`†[š|ð¦÷\â\×Úµ›\ë­K\Ãw1\éð\Éy\á+^;h\Ú\éT0Š\æ\ác’RcnE\Ùó\'<y‰ñû\Çþ\Ó5{m?\ÅZ½­Þ©%›OªÃ¨\Ü%\ï—l’¤P‰V@|­²Ÿ”\ä|‰ŒcžWI‡_\Ô4\íe4¸õ+›…nuE´Y\Z!¸\Û$\áx\Ú—\ÜGsIßžROM_\ßgøk÷NT½?c\è+\á|\Z\×ÁI\æ¶ð÷öÖ¯a}\âˆ.\Z{mF?&U1\Å q2\Ä\ÐCvûb_/÷‹\Ù9\íg\á‚£ð\î­Ÿÿ\0	z\æ•\áM7Ä—:•\Õ\Ì-be¹[Rm„+`\Ú~YFÒ‡Ï\ëBú\Öôj÷\âö\Ökoqö—ó!„!A\Z6r¨•\Ú8Á\ÇJ\è|gñÅ¾<\Ó4½+TÖ¯C\Óm­-­tdº˜\ÙEöx‘ag*ª’\Ì\0\Év#\Å\\yTµ\Ú\ë\î\×ô\å\ÓË³cŽ\ë›ú\Õiÿ\0¥k\Ò÷\ìzg\ÄO„¾ð¼ž-—\Â\Ö\Z\í\íÏ„|Mk£õ\Ù\Ò\â\ra¤i³\ÇQ´d1#RHò\Î\0\æ~:yM7†4›?I‡\ÇV°K¹‡\ì`µ…$yI†Ù¢·DŒ\Ï\Z’¨\',‰d8\Íø™ñS\âG5ý;Åž$\Õ5\Û>\æ]ODi..V\ÚÔ™y6%\Ø\ìEt\n\n\nœŠ\ç<Qñ;\Æ>8’\ÉüG\â\Ís\Äb\Å\í[TÔ¦¹01\ÆLe\Ø\í\'jô\Ç\Ý•”SÓ›¾¿rOñ»M;_§õc®øSð†\×\\ñ?‰\í|o%×†\í|3`\×Ú\Ò\Ïkp?{[¥µÄ‘`\ÌŸ!ø\\»·/O\áoƒ~\0ñ÷µ\Ã\Þ ¿º\ÓawV\ÚÊ³q4k=¡óm¡wžO.\nÆ®\áAEß”ò;_ˆ(±ñSøž\ßÄš½¿‰$fw\Ö\"¾•o˜mbf\r¼’	\çiºß<K\âczu\êÚ©½ž;›¯·^\Ë7Ÿ,hR9sÌªJ†<€HUÿ\0-û~7þ¾\ël\Øw_Õ¿«ýý\Ò={Á	~^xf\çÄ¾2\×/|+¤\Þkw:M•½\Í\Ä\æ\â\ÄB±³|:ež@&_ÝŸ³g\Ë8?1\Ù\Êx%b\×>üE\Ñ/$[‹-\Ú=wM¹*G“qö«{g	‘&ŽQ¹xÉŠ2~\çö›ñ‹Çº5þ¥}§ø\ß\Äv7º›+_\\\Ûj\×\ÉvT¦V	vp\rf\Å\ã\ë\Üøn\à‚\Î\îño.\çD>}\ÉE\ÄH\ìO\ÜB]‚€2\ÒÛ°›g_Á~Ÿ®¿™I«§\ç–º|×»ø÷(Ë \êph°ki\×q\é5¼7\í$•@,‹&6–\0‚@9\ï\ßG¦k\ÚuÜ®±\Å\r\Är;½”W¡T0$ùþ\î^?\ÈV\èp\r6]SŸEƒG“Q»“H·™®!°i\ØÁ¬\0gXó´1\0@\ÉÀ¨ô^ÿ\0@\Ô\íµ2ö\ãN\Ô-dÁwi+E,N:2:TPjÓ´®C\Ö6>ñ„´/Š\ßð¬®´û+{:úMV+ýR-.\Û\Â÷\Çj‹<…àµŠxU\"Œ–Æ²»\åÐ¨* \Ð\×>øEñE\ÌW:Æ«\ák¯\Üxž8moŒS;E,±„K‰\ìc%\Ë\Ü\Û/\r\Æ\á†>;wñ;ÆºÇŠ,¼Au\â\Ízû\Äv GkªM©O%\ä#œ,r–.£\ænþ#\ëOñwŠ¼r<C{Š5v8¤±ºM^\æ´¬lÅž‡pRX’§‚X’9¨\r–_É¯Í§\ån·+K\ë\åù\ßò\ÓüŽ\Ã\Ã>øy«øo\Å~\'¹\ÑüTl,u7OÓ´k]bÝ®${ˆ\îù—\Ó2»aï´ƒã¤¿ýŸ|9k¯x–\Î-WQ–\×\Â~!š\×\\•\ÌjË¦ˆd•ß–`m\çˆ\îÊ™\0\Î™x\'\ã‹>øXÒ¼1¬\ÞhÚ·\×\ÚmÔ¶\×?¹Y‚\Æ7_ù\ÌYH9*1\ÍK?\\\é¾\Ô<=e§\ÙZ6¦\Ê5\rR31»»…\\H°>\éaª7ÈŠÄ¢\åˆª–ï—¶ž¾\ï\êû¦üyÿ\0[ÿ\0K\ÏV{?„g	ø«\à\Ý\Ï\Ä?¶jÖ‰jŽ‚÷Q›»µŽ;¶À\Â2±†2°Cwû8^4øGðÿ\0Á~\0€]ø­‡Žf\Ò\ìµH-U\îY.~Ð±\É\å¾À#@±\Èß½n	\î\r\Ä\'—ZüCñU‘´6þ&\Ö 6b!m\å_Ê¾Hˆ8ˆ&\å\Ø%”.>\ï˜ø\Æã—¿Ä¯I\áQ\á‡ñV´\Þ\Z4f\Ôf6c\ç\ßþ§vÏ¿ót\ë\ÏZzs_¥\×\á¿ß¦›i\æt\ßõ·ü¾û£\Üu/\Ùg\Ãð–k\Z.•\ãHµ¡ñ•Ÿ‡#Š\Þ9\Úk(f7[¾\Ð$·‰$›÷\n\Ér¤†‚¦¼\Û\Çþð\Ì~\Ó|Y\á›-{G·—U¹\Ò&°×®¢ºvh£ŽO5$Ž@\âM¬…\Ò\Ìs\Ã\Üx«Z»’òIõ{ù¤½º[Û¦’\å\Ø\Ïp»¶\ÌäŸ™Ç˜øc\È\Þ\ÜòjÇ‹<u\âO^Cw\âo\ê¾\"º†?*)õk\Ùn$\íV‘‰$œZ\Î\ÎÖ¾º~Jÿ\0}Ÿ\ß}\Ðu¿Oøøuº“x#\Ä\Ö^Ô¯®o´[mv;:\ê\Ê8.‚•†Iah\Òq¹n˜8\à¨Ášõ‹i\×þø‹ñ+@ð†g¨Ç«iöpi\×\Zu½ý¦“i,s‘`’/$–xcM\í\Î0\Ì\rx-lx_\ÆZÿ\0õ&\Ô<9®j^¿h\ÌF\ëK»’\ÚR„‚WzpHg°«\ß\Ö\Öüoø\í\è\Éÿ\0;þÿ\0\'ê2;o\'Œ5mWNÔ§¾†\Ë\íp7‡tø!³¶”\Í\Zï¸Ž4TŠ\r¬\Ã\äó²æ®®™kâ„OyiiZÇ†nñz\ÐÄŠ\×7\rû¹\\ŽX\Å0(Xç‹ˆ‡Esw^2ñõ\æ­ws®jWzº\ì\Ôg–\îF{\ÕÜ­‰˜œ\È7*œ6yP{TZ‰µ/\É|\ÚuÀ€\ßZKcp­\ZH²C Ã¡ô õ \ZŸ³e\Ûñþ´ô\èW_Ÿ\á¢ÿ\07\ê}%\âï„º>¨x¯Å«šl&ðó\ÜÃ£­š¶[‹\×	\Î\Ð\Æe¹û£\äh”Œ\ï\åõMøƒ¯üð\ê\Ük\Þ\Õ\íãµŽ\Ò\î\æ\Þ{‹$—Už	Ds%¼A²P¸ÞŒAld^??¼Ou\r\Ä3xV–‹H¬&ŽK\éYd¶Œƒ,s\Z\n¡\àc€+OYø\Íñ\ÄKb5ox—S7	wh/5{‰¾\Ï2}\Éc\Ü\çc®N`Š·g$ú+i\é\Íø¾o\Óbj=]õõQýWô\îzE\Â?ø¦\r+Y\ÑGˆ­t8\äÖ—P¶¼»‚k»¤\Ó\íb¹\ÝXUbiV]»XI\å\àœÉŒ|5ð×†¼=\âðÎ»¤\è:oƒ¶g\Òc»‡ûNøË«Mr=\×\ÙUvmt0Àß»TQœ†¥ø»]\Ðå²—NÖµ>K‡»µ{[¹#6ó8Uyc*F\×`ˆz\n\Ò_Šž5_C¯k\Ã]…8µA©\Ïö¨\ÕÙ™\ÕeÝ¸gr@<–bzš]þ¯i~­i²¶›š6µ²ÿ\0†¾\ßv—\ë¿Ù¥ý˜´mr\Ö\æ}S\Ôt°Ë§]C­\å\È\ÐG{e,¶ðJP´qq	\0\0¬¡¶b¨XüðTž(ñO…¡—P\Ö|[gö\r?C:å¾˜ómŒuž[Y!™¼\ÒÀEº\'Â€¾ao—\Ç\á>ñ?Úµ¯øHõo´\êS\Çu{7Û¥\ßu4o¾9%;²\î¯óly\Õ\ë‹~9\ÓlõK;?ø†\Ò\ÓU–Iõx5Y\Ò;\É$‘\åPø‘˜pÅ²Oz–¯\Ím/Ó¶\Ýÿ\0Wq.—\éøü½u_v\Ë]\Ò\í¼Mð\î\ím#‡Yð\Å\Þ\ÛÖŠ$V¸±¸lG#\ãŒS…Žx¸ˆp½\ÃÅšWš\ÏÄšmŽ‰§¯‰m|w\ÃOX¾\Ì\Ð[\Å3Ý©\Æ\Ñ,¦T]\Êw~\æM\ß\ë9ù›Añ6¥\á™/›N¸\ëIln£IHdt!„ €AHþ(\Öd¾º½}Zù¯.¡6÷\rr\æI¢*\Æíœ²\í\0`ñ€9{\ÊQ\î¾\çf¿\àü\Þ\Ú	i(Ë³û\Õ\Óþ½š={\ÆZD>¸ø!\á\í:þûL\Ñukki±<GNóu;ˆ‰\"‚\r\é¹<\Ì8$n#v1Yš?‚|\r\âï‹¶>\Ó\ì¼M¢\é±=\ìW\×:…\ì72y1H\ê\é·ˆBs\Ìl\Ï\×†2yx\ë\âG‰4=-<_\â\êº5\În´õ\Ö\ïnf·—ihÌù¬U°w.\å\éÈª:\×\ÅO\Zø’ú\Ê÷Wñ~½ª\ÞX£\Çkq{©\Ï4–\ê\ãk¬l\ÌJ†1‘Ö‡»k¼Ÿ\Þÿ\0M}wa\Ó\ä¿ó\Ó\îó;MÂ¿|Q¹¯Xi\Þ*Eðþ’/5\rõy.¦•®R1\Ýp«%Wb\Ð»JŒ\îÜ»\Ñü$ðŒ\'±\Ôou(\×P\Òl5=E¿\Õ!\Ó\'‘®ce½{iaV@F‰8`Û“[\Æ<7\âkÁº´z¦«\ß\èzœjÊ—šm\Ë\ÛÌ¡†Bpy­\âçŽ¼=©\êzŽ•\ãOéš†¨\â[û»=Vx¥»pI\r+«‚\ännXŸ¼}i\é§õ\ßüÖ½-¶¢\×_\ë·ù=:\ß}Kð\ÇÁ=\"\Ë\Å:_‰´u\ï\Ýxn\Ú\ßI¼€ÿ\0e<-1˜˜\\\\¾\é‡È† Dd†ù†\Ý/\éþøwðo_Ô“T–\ë\Ä_\Û\Ùr\\^x7O\Õ\"\ÊDQ›†	œ1™P8ÀHø¶‰ñ\Å~³\Ô\í4\ë\ZU¦¨¿‚\ÆþXc»\È ùª¬ð\Ì>lõ>µ‘ý©yýšt\ïµ\ÏýžfûA´ó\Êó6\íß³8ÝƒŒ\ã8â¡¦\ã\Ë\ä¿ö\ßò~·\×DR²•ü\ß\ëþk\Ò\Új\Ï[ø±m~ü<›Gð¶­¦\êÚ†$\Ë}.«‘±]B\éÌ‹f3\á0z\í_-Hm™lo‚~¹_Œ\rÆ¹¡\È\ÚF¯©Û¼+©Y“m}œŠ‡]²¦AS\ÔpA®=|u\âHü*þ_j«á§“\Í}^\Ê,\Ùòq‡v\Âr\Î:Qk\êúCoR£ºk}®LØ\Åñ?»ù‰o—œÖ—´\Ü\×{þ¤IsG—\Ê\Ç\Ô\rðG\Ã>8ð¿‡¯,\àµ\Ñ4_kš†±\Ì1–ž;8´õš[%x\â’@h§Œa$+û\îž[Á~øGoñ@\ÚilñÆ›q\á½N\ä\ÛÁ~v\Ù\ÜGgv\Å|Ë6#3H\ÝBž[y³\æð›\Zx‡L·\Ó\à³\×u;H4û£}g’\"\Û\\fhÀo’Cµ~eÁ\às\Å]\Ô>\'x\ÇWñ%Ÿˆ¯¼Y®^ø‚\Ì¶Õ®5)¤º€H	)m\Êf\è{ŸZ‹jùtOOü——\ç\é¦×¾¬Ó›Mwÿ\0\í¯ý}\ÇK\à{=ÆšÏˆü/¥\é3Z.³k»Cû|\Ñ]\ÝÁyó#8Š-\Â`%‹\nªIA\Ø+±ýž~øs\â}ñ,÷Zlº¾®tm2\æ\ÚþEg™cGh\ì.7\ì#$\Ð)\r\Ã\ÃÆ¯<_®j^&\"¾\Õ\ï¯õ\á2\\i^N\Ó\\»’IW=…lYü`ñ¾•>©&™\â\ÍcE]Ní¯¯ \Òo\Ê	g-»yŠ¨8\Æ\0\Æ1O¥¼¿Uú]yYo©÷\Ñÿ\0V“³·©\Öx\á×…µß†ºÎœ÷Z\ï,âº¹»±Mb?\ì0D„¢\Þ[vûZ\ìR\äC8q’\n\0»Ø¾øs\ák\ï…pk>’\ãY\Õm¡‚Mfñõ˜`]5\ä•P«X=²\Ê\é¹\ÕD\ÑM\"ô-°ƒ‰_‰¾0Â¯\á…ñ^¸¾\ZpCh\ÃQ˜Yœ¾ó˜wl\å¾ny\ëI«|Kñ~½\á\Ë_\ê~*\Öõ\Ð ·\Ò\îõ¥µ„ Ú\"f*»GÒŸ[¿/\ÃO\Îým¡N\×v\Û_\Ço\ë·K\ê{Æ«û>ü1±ø£x!<]y/ˆ\ã\Ö\âÒµ;kw\ä–\"K2,¶\ÇVT!<\ë€\ÂN\å\Ü\Ûz?Á_†šN¡¦j¶\Öúô\Ú|ºmÄ·öÚ¬¶×…\Í|†!Œ\"%v»c,\Â\í\Éù\Ò\ë\âßŽolt\Ë+ø†{=-\Ñ\ì-\å\Õgh\íª4J_UI\0®0VÓ¾$x·Gº¶º°ñNµesjPÁ5¾¡4o	X|•(Á²¸‹÷c\å\é\Å-yd¯«\ëù\éú	i$\Þ\Ö\ÛÏ¦§²x\'\Ãz†þ+|¾Ñ´\Â\Ú?%.´O[\Ú\ê\Í\'PkwÃ½º!,yWXÕ—,w<ÃŸ†¿£ñŸe<¶þ$³ž\Ú{efQjl\Úq\r\Ã8\ÆAŒ\Ë™RGý¿ÅŸYøž\ëÄ–þ2ñ\"ºˆAq«ÇªN·sF6€0}\ì¿\"pN>Q\è*\å¯\Å\íz/\í\ëË¦\Z·‰uˆ\Z\ÖojW\ZŠ@ñùrD¬\Ò\ì\ÃÇ”,\È\Ì¬´üý;¥\èºù^\Ã\î»\Ûð½þnúz+›6\Ú_‡¼U¡x\ßEðí¬¦M&f\Ötk›¡]\ÜY\Çò\\E#ª©cå”œ(Q¸15\é>ðÞ„|#\áý>+,xƒ\ÃºÁÖ®|-g«É¨^Göƒ4}\ÃnµX’\ÝPF\à\ÌXŒ\ÕóÏ†¼I¨ø?\\´\Ö4›²\ê¬Z)k H(\à«	XA Š\ÒÐ¾&x\Ã\Âú-æ¢ø«[\Ñô‹\Â\Ís§\éúŒ\Ð[\ÌYB±xÑ‚¶T9€KW‹_\ÓÑ¯ò~«\ÏA|W\éÿ\0?óù?#\ÜüUðv\Ê\Ïà½¤\Ñ\è6š–‡›ª^\Ý\Ú\ßY¾¤R\îF+<(\æ\áD_h²Q\æ(Q±ˆûüðŸ´&±q\áÿ\0x›À–º¢\è:> \Ö\ÖQÃ¢Ú¥\á‚3ˆ¤{\Ï/\íy‰¶B\Í!\r¿#\åÀmq\âj\êúþúm^þk\ÝB3\åÄ—.\Ò\\¡\ÆVF\'.\Õ\à\ç ô®†\Ç\â÷‰¾Á§\é\ZÞ§}\â¿Y\0#ðÎ³ª^;\n¥PyqM]™\Ê\íe\Æl‚\å\ï;÷wü¿+i\ê\ï\ÜQ÷co\ëúm\ëò±¹û9®®¯µý*\rgG\Óô{û»›K›u™VÁ\èA`Cu9\Åzc\ê_\r¼o\á+Æ±¶“L›M¾\Òl<HšÀ\Ü\Çq7\Ó\Ù\\m‚\ZPƒr,‹€Z5\Å5\ïˆv·öf\ÂZ?ƒ%‘Z)\ît+½GÌ¸…\r‚\â\îU(x$À\çU?\r|Nñƒ5ðÿ\0‹5\Í	cG›©MnYƒ2Œ0*’;joY\'²J\ßúV¿¿¤M¬Ÿ{\ßå¦Ÿz¿ô\Ïdð­ž­\àßZÖŸ­ZxK[\Z‡‡nõˆ\å\ÃvOg\"®“5Õ¬°Á-ªùˆØ¨Ž2HÃƒ\ß\Ïn­\íµ·ºÜ¶VkªMâ°s\r¬q0Fµw1¨Ew!‡£üZñÇ‡µmKTÒ¼g\â\r3S\Ô\ÜI}{gªO\×l	!¥up\\\äžXž¦—Aø¹\ã¯\nÉ¨I¢x\Ó\Ä:;\ê›Æ°\Õg€\Ü\Ês™$(\ã{Ÿ˜\äóS%x\Û\É/º\\ßŠ\Óô\è]ý\äý~w‹_ž½}M\Ó-|Qð‰\ï--\"‹Xð\Í\Þ/Z‘Z\â\Æ\á¿w+‘\Ë¦ñq\à(¯Yø™}\á?ø\r´»\çð­\Ä÷^ÑŸL\Ò4\Í[ê¶—\Ò[Z\Ê÷SÞ­²FS1*g”±•APFS\ç\í\Å\ZŸ†æ¿“O¹òšú\Ò[ñ¬‚Xdu!Á„ €AT\ïõ+\ÍVdšö\êk\ÉR(\àY.$.\Ë\Z D@I\áUUT€\0œ½\ä\ã\Þßªÿ\0ƒ}\ï{Z\È#\î»ö¿æž¿Š·o™\íšÿ\0\Â\ËñB\Óá¶?ˆl|A6±g§®±¨\Ïö’$\Ä	?p‘££!u\nC¾ý§\åMÀ<Q\à_ƒúo‹<9kk\ãˆ´÷ºž\rn!%\Õ\ËÚª(1·›&›n\È]÷#*\Ã)n\ïŸ;+\Ç/µk\íSP’þöö\âòþF÷S\Ê\Ï+0\èK’x•t÷¿\Z> \êZ¾ª\Ýø\ëÄ·Z¦›¼X\ßM«\Ü<ö»\×kùN_rn¤dpiöõÿ\0/\ê\Þd÷ôÿ\0?øwc\Ótß>»ñ®§&¢óh\Óô®¤¯&¤o`7n$K»K<´\Þ\Ù \Û3.Â®%’”žøS§\Ùx\Ã^MK]ñN¦\Þ\éV–	¤]­³;\ÝC;Ì’Mqhùm\n\âß¸»²žf\ß¼b\Þ,(>,\×‰‚\ì\Z\ÑÔ¦û`]»1\çnß¿/^œSgñ‹¾ k\ÚÍ©\ë^$\Õu‹˜L\É<\×S\ÞÎ€¤$‚KH\ê•zÖœwJ\ß\×5ÿ\0§O!\ég\ëEúß¾úžÏªx7ÀðW\Å-/Sðæµ­\Þø{\Åv\Úb\êvú­½¼†?ôõŒ©k9kˆ\×\Ì\\‘# ¦\Ü\ZþøoÅŸ_Q\Õ..´\ï\\\èÚžµ§ˆo\ä”M —.\Ö\Ë`Èˆ^&Œ™.\Ðç§*­\å<i\á]oW¼²ñ6½£\ë\Ì\é©\\[\ß\Ï\Å\Ãn%„\Ì3\Ù\Èlóše‡\Ä\Ïi^>²ñ^·g Ÿ3:]¾£2Zü\à‡ý\Ðm¿0fŽCõ¬õpz\ê\ÒWùZÿ\0~·ùy•ö•\Ö\Ïúÿ\0/-ü@ø±m~ü;›Gð®¯¦êº†$\Ë}.«‘¹]B\éÌ‹f3\á0z\í_-Hm™m}\Ãp|L\Õ>øgN½\Ô\ì4MZÀÁko©KÜ¶!õ˜¤ñA™¸\Æ\\+‚r\Ûwc\ãñø\ëÄ±xYü2ž!\ÕS\Ão\'œ\Ú:\Þ\Ê,\Ùòq‡v\Âr\Î3+CÄŸüs\ã+;{]\Æ~!\×-m\åY\á‡R\Õg¸H¤\0€\ê®\ä\0œ\Ï&µm7\ïs~z~?‡›!\Þ\Ö]­ý}Ç«xs\àÿ\0€|a•­A‹4\r¦\Ö-¯l\ï.­\în\Ø\ÙX5Ø’/8\nÑ²|ÿ\07\Zü/\à\ÍV#µµºµ\Ðõ\Ý\ëÃ­X\Ùx‚{£¾kb\Ë±\Ã\Ç÷DÊ¸y\â¼?\\ø™\ã\ê‘\êZÇŠõ\Í[QŽ\ÞKD¼¾\Ôfšd…Õ•\â\ÌHFWpW8!ˆ=Mf\'‰µˆ\í’\Ý5[\å·KV²X–\á\Âvs#Bq°¹,W¡bN3Y»Ù¥\Úß„—\æ\Óòµ‘Z]z¯\Í?\ËO=\Ù\é\Ö:_ƒ¼U¼c¬[U\Óô©¬–\Ö\ßH´²\ÐZ\ë\Î.‡tQ\Ç4Vø\Ø\äW\ÎF_rõŸ¾x\â…ÿ\0\ï\î5}?J\Ö5\Ç\Ò4›‹ò·LDh\ì­m…\Â\ÈÑ¬ˆ\Ì\Í-º0=WW\ç\Øu;\Ëk›(n\çŠ\Îè¡ž\Ý$a¥	(]A\Ãm$\ã=2k§ðW‹¾ hzN©o\ákÄ–\Zd\n/õ´[«ˆ\áŒ+*‰¦ \Ø7·C·ž”Z\Ñk\Ëþð¾½	•\Û\Óú\íøý\ç¸ø3öuø}¬x?DŸQ¸ñ)\ÖõmI’\Ö\î\Ý-„—Pò4,ÁPiû\ÌKy›~\\n®c\Ä~ø?\Â:rj\Þ+‘|]qa§\êkm·¹K*C\ÆlQ…ŠF\Ä\ßj”Š§[ø\ëÄ¶‘Á!\ÕaH6yK\ìª#\Ù\æl\Úq·Î›\é\æ¾>ñ\Ì\íñ#Å¯\á5ð³x§Zo¯M\ê!‡\ßþ§vÏ½ót\ë\ÏZ»®g\'µ\Óùvþ½\nv\Ñ-­ø\é¯õ\Þ\ç½^~\È6V:\äš|º\í\Æn5øt(0¨d´‘\îed_ùj\æ\Õ\"”)óJ\àd\àh|\ã‰<7¨iðøŸÃº=î§¨iw–º•\Ìw;­\í>\Ð%‰\Ö—¸VŒ¯?\ÍÇj^<ñ6´²®¡\â-Zýf¹K\Ù\Íô²\"Jw1Ëª\0¡º€0*Æµñ7\Æ$\Ö-µm_\Åzæ«ª\ÛD\ÐÁ}{¨\Í4ñFÀ†EvbÊ¤3dƒ¸ú\Öv’“\×þ\ï\êµ\ï}\Ãwwýo÷t+lz\çÁÿ\0øâŽ½\â\r\'Có¼7þp÷0¹†\î;Ÿ·[ª\Íñ\Ã2·˜\×ib\í$=\Õ<\á\ëkzLz\Éð%žš\æ\0ž3Ž\åî¤‘\×––²ymO–\Ã\ä\Î\Ý\îFOg©\Þiñ\Ý%­\Üö\Éu‘p°\È\È&pmŽù—*§Œ¨=ªmc_\ÔüEsÆ­¨\Ý\êwB–\é-\ä\í3¤H»QbHU\0\0:\08ªkT\×oó\×\å\ê\Â[4ûþ‹ó·õv{À\ë­]\Ð\×ÁšSi:_\Ä\rSS\Ùi¨k\Þ·Õ¬\ï\Ñ\Â$V\Û\åŠW´`\Þa‘\Å\Æö@ Œ«„ú#x\ßÅ·sj	a§Ám­Û¬Ñ«®¥¢\Û\Ål $Ÿh€ò\â+‚\Ê1\Ä\èŸ|g\á­\ãC\Ò<]®\éZ%\Æÿ\0;M±Ô¦†\ÚM\ãk\îX)\Ü89Ž´j<¸ºðM§…\í4\ë+NI\Ö\î\í¬ü\ã&¡:«,r\Ìd‘\ÆQ]ÀX\Â/\Î\Çi\'4K[µ¾Ÿ\åø+ú»hµ\édö»ÿ\0†û\íè®¯µ»k¯\0ø>O…ö\Þ \Ñû\ÄW–1[Ï¯\Í»«X\ï•Q£û–¾aº¢\Í² $3\Î\Ê\èþ\"x\'Á¾/ø©\àO	xkE\Ô<)w®Z\èQµõ\Õü76\â;‹8>av±—s\åŸ\ï1Ú»¾_#Õ¾%ø¿^ðå¯‡õ?kzŽƒh[\éwzŒ\Ò\Ú\Âm@‘3]£À\éP_øó\ÄÚ¦ƒ§\èw¾\"Õ¯4]9ƒ\Ùi·Ò½µ«\0@1\Æ[jO*SWu\Íwµ\ïò\íþ_ð\ìJ\éi½­ó\Ó_ë¿’=²O„\ß	nüD \Ó<A©\ê1Xiú¥æ©¥\Ø\Ý\Êó§\Ù`ó#\Ä÷:m°B\ì|§Ù´¶vŽ·\Ä?<ð\Ëþ\rk\Â\ÖWºö¡ \Ø\êKkg\âD‚ú?:\ÚþinŒ\" Ž©\Ò6\É®T;\r£\çM{\âÇüS$Rk^2ñ¯$P\Ëo_\ê“\ÎR)@YPs…p\0aÐ\Îj¬?|Wo¬[j\ÑxŸYUµ–[ˆ/“P”O’œ\Ê\êû·+>N\â[<\æ³\×\Ý\×dþþúùt+N\Ýoò\ÓO\Ã¾\çu¢Y\é>2ðö·\ã\ß\é·Z„·\ÖzBi¾‚\ÏF\åI\\Jþ]³F J€\"Ë³ò\Ão=‰>ø\áŠ\ë“xœø—Y†\Ë\Ä\ÒhqÇ¥\Ü[\ÙÈ°¬1\Ëæ¸’)s\"†*c6ü\Þk\Æoˆ\Þ ¹\×añÏ‰\"\×.a[yõ4\Õ\îÌ±.\n£Js(ÀÀ\'V=¤~!\×ô»ømWSÔ´\ë2Ú•\äp‰%†v£\\HB\ç*¥Ï¨¢]m§ü:¿Þ”µ\é\Í\åq-\Õÿ\0­¾\æ×­¼\ìz\å¯\ÂO‡Z_\Âû\rk\Ä>-–\ÃV\×,//ôœ›…ÿ\0U$±EAŒ±\ÈY\á›\íQ\ìó>\é\Øñ>(\Ólõ¯‡¾\ZñM•œpVþ\Ä\Ö\"¶#rðM…a%rFK\Û\ÈÄ’kIø‘\â\ÝÃ·z—\âkMÐ¯7ý§K´\Ô&Š\Ö}\ê÷Ä¬·(\0\är*†›\âmKI\Ñõm*\Ö\à&Ÿª¬kwFŽ$ò\ßzX¬ñ.\à[Ýµ\åo•ÿ\0Go=‡ÿ\0úûõü.{,ÿ\0|0º\Ô?ˆŽ“¥\ëº\Äh:–«w®šm\Ö\æi\çwUR\ê“[ Œ‡lþÓž´±‡\áýþ‹¢\è:E\æ—%´Vz¥e{,¦;Û˜\âyZ\ÚG3HbXƒM\Èg¹Ê•%¨kúž­gai}¨\Ý\Þ\Úiñ˜là¸¤Kh\Ë)\Z“„RÄœ’i’kó-Š\É{q\"\Ø\'—h­+n»\ÚM±óò\r\ìÍŽXž¦›³²\ì\ïòµ¿\àú¶+´Ÿ{~;ý\ß\ä{GÀŸÅ¥\ß|B›\Äv¶Z>»\á\Í1%x›L	§†¸Š9\ç{9Pù²\"9Uò©8\Æ\åÀý¥4½Mø¾²m6\ÓP\Òlu	,\Þ(\àh\å–v&þHK\äI\å/Ê»ð¿.+‰µø\â‹?‰\íüI«\Ûø’Fg}b+\éVñ™†\Ö&`\Û\É Ny¶ü3\ãe¼¾š=SÀú_\Äj—¦O¶\ë\Zœ—³\Ë!`û=\Ü[\Ë6O*X–<ž\0M9r÷_ðtô\Öÿ\0.ºXV‹—gÿ\0_]?š\ß×¿g/†:>§\à\ÝJúa\á]wZ\×4\íZ\Þ;]WW°Ž]&(l¦d›ÈžUq+Ì±‘ \\GnÄ€\Ù_ž†µ_\ì\Û\íE4û‰ô\Ë\Ö\Ú\çP‚3-´R6v©•r™m­ŽyÁ\ÆjÆ¥¯\Ïˆ¯o´»$ð£\Èc¥\Ëp©\n2\äŒ4²<˜e,3œ†aÓŠ§¿©\Ú\è÷ZD:\ÜZMÔ‰5ÅŒs²Á4‰Žñƒµ™rpH\È\É\Å|Ï™v_Ÿù?¼\n\å}\ßõù|«|o\à\ß\é¿üO¡m.Q§øN\ÃX\Ò\å±\Ó I­Ù…¹ûM\Õù_6I.$™\ÂÛ†d\Ãî²ª\rø3ð÷ûc\â¿\Ãû\é7Qhz\íô^@ºF‚=B=ûvG!\Ú\n»,²ž	<‚+‘¼ñÏ‰5Zxn\ë\Ä\Z¥Ï‡m$ómô‰¯d{H_\æù’\Ûü\í\È\Ä}MT½ñ«©[i\Ö÷z\åÕ¾š†+¦¸wKT,X¬@œ \ÜI\Âã“š¤\íWŸ\Ïõo\ï\Õ.\Ú|”Yû>O/\Ñ/»Fû\ë\Þ\íûŸÇ/D\Õ>øwT²·\Ó\æñ2\ëwšU\ÅÞ‡¤A¦Y\ÝmHœ\ÅoH†T…\Ü ™\Ô; ð³þø&-.û\â\Þ#µ²\Ñõ\ßi‰(‹\Ä\Ú`¸M<5\ÄQ\Ï;\ÙÊ‡Í‘Ê¬l„o•I\Æ7/”x“\Ç~%ñž©o©xƒ\Ä:®»¨Û¢\Ç\rÞ¥{-\Ä\Ñ(bÁUÝ‰\0H\0õ$Ó­~ x¢\Ç\ÅO\â{jöþ$‘™\ßXŠúU¼faµ‰˜6òH$žA¨Šq¿ÿ\0$¿;·­õß©r\ÖË·ù·þIio+hvß´¦—¡i¿¡—\ÃöM¦\Új\ZMŽ¡%›\Å\r²À®\Ä\Ã\É	|‰<¥ùW~\å\ÅyUvš?\ÄKKv¾Ÿ\ÄÑ¼mª^\\½\ÔÚ®¿w©—f\Æ\àZ¸ƒd\å²À±,rO½\Ä\ß lü$ðt™b~k½kn5‚„­ý~-»\Û\ä¿\rþ{ž£ü<ð_Œ<ðûM¸°\Ô\í<G{\á}WR“U°xcµ„[\\_ºIq”\Ï9\";\ãØª˜-\Ð`\ê>(»³øÎ³¥øm¯5«¸\ítc†ôû{˜­­Hi\îL\ÑÀ²>\çò\áË±\r‰ó’3^}yñ?\Å7¸ð\ä:þ«c\á9dg_[\ê7N‰Lž`E…\ä`@nFìœŒ’O5ƒ}«_jQZEyyqwœ?g¶I\ågE¹›b~U\Ü\Ìp8\ËÞªM\ÊRkK»þ-ýû/K½Å¦—óü­ÿ\0\îG¹x›\í\Þ,ð\ïÃ\ê:&ƒ/Š¼S¨\Å~©¤h\Ú~<V’7“m	–u\Î&I	pÀ/’\Øë½cÁ_>kñ¥¼—\Z×‡/nu]:\ê\ÞX±\Z\Í*‰*-Ý’LIÔ”(W1}òr«ó½Çˆu[­ZR}NòmN+Ê¼’wi£òÂ¬{\\œT.F:WAuñ\Ç\×\ÚÍž¯s\ã\\j\ÖL\ïk.­p\ÓÀÎ¤…÷)dN \0x£­\×w÷l¿\Ç]Ávz\éø\ëÅ¦¼•µ=K^øy¥x“\ÄG\Ä:¶¤Ú—‡cð›x’+]@´\Ð/®b[“n\"h G†&ó	s0þ\éws\Ðc|(ñ§´›\Ï\Ø\r>óJ“V¹²M\"\âû\Ã\ÚwŠ\ç¶U\Þ%–\áa\\»:Ñ¦~P0zŸ6_ˆ^)Å‡\Å+\â]a|NIc­ùE\îJl\'\ÎÝ¿;>^½8\éW\ìþ0ø÷NÔµ]F\Ó\Æþ#µ\Ô5m¿\Úp\ê\×	-\æ\ÐU|\ç™0	q8ˆû¯Ë·\ÎûúY_\ËmXKUnºkò_­\ß\Î\Ý\ï^ø{¤xXÏ§_jšHñŽ³\ã;\ß\r%ü¶\Ömƒ\ÆaUT‚fX­\âi&,Y\"i\0\nB†\r\çz]­¯ü(?ˆv:.Ž5U\Ó\ãMRe{§i%¸Y?~\Ù`¤FŠ6¦»‹1óŸ\rü@ñGƒ¬\ï\í4jú® »/ \Óo¥·K•Á‘Q€q†aƒž§Öµ,>\"|B\Ð|ºe—‰¼M§xB\è\Ïh¶v÷÷XJHh‚±ÄªYq\ÒAŸ½P\âùm~‹ð·Ý³ûö\ÓZOË«ý~ý½ý½‚\æ\ÇÁþ#ø=â›2\ïB}#H\Ðl%¶³‡Ahµ[-H\Én’‹\ãù‚G7%PM *r$vzñ«À>R\Ðô‰ \×-lõmr÷BÓ¼:–+-¼®b !.—÷.w\Ì\ÈÀ¬`(1¬x\ëÄ¾ \Ñô\Ý\'Tñ«©iZh\Ûccy{,°Z€\0\ÄH\ÌU\0(\n—ÅŸ<W\ãß²ÿ\0\ÂM\âmc\Ä_d-ÿ\0µ¯\åºòCcpO1Ž\Ü\í\Ç\\JÑ»¶ûµø;þ;zu\Ý8Ž‰.\×üU¿\àúô>ñ\çÁ}Æž4øm¾ð¦s¡_K4z&§iy4±ZMx\êd{?=¤•\à†5kƒ~ü+1\Õøá¥–§\â½_Âž!\ÒõT\Ó<?\á“\\¶“T·\ÒÝ¯)\åòç³·l!+±M¾\Îûž`ù\Æ\×\Ä\ÚÅÖ—sm«_[\ÜiXþÏš+—W³Ã´ƒ\É \æ?™¾\\|\ÌOS]Ÿ\Äoˆ¾&ñÆ›ªZøŸ\Å\Z¯Œp,\ìo!\Ô.f\Ô0\Ù(œ1“\ì6©\çq\ãšVm\é\çø\ßüÖšm£š\ß\Óð·õ\×\ÍIjZ‚¼7«xŸ\Ä\ëag\á\í\Z\â\×@cy{ Y\êsZ\\]Dò<\Ù\ÏA•\Îr¥L8p\ÞY§\á\røe~+\ßx:ko\èZ¬¾-¼‹Y\Ð\ï4f\ÕL\Ús1\Åapm˜[¬iö‚\ÎZÙ”\Ì\Ã`	ó~›ñ\'\Çñ«¨\éþ)ñ‹®^\È\ÃQ»¶\Ôg‚\æw\ÜKy\Î3\Ù\'q\ÎsU-~ ø¦\ËEÔ´k\ëi\Zœ†[\í>+ùV\Þ\í\Î2\Ò\Æk“\Ë\ÐT\ïª\Û_\Æ\ÎÞšvù^\ít\ë§\àš¿¯]÷\ë\Ð\éµ\r#Nñ\Ã;Û*\Þ1\ámA’yb®´ù\ßJ\ä\0X\Ç(\ØXç‹ˆ‡@¯Pø™}\á?ø\r´»\çð­\Ä÷^ÑŸL\Ò4\Í[ê¶—\Ò[Z\Ê÷SÞ­²FS1*g”±•APFSÂ¼5u\â=M\Ö5}\Þ\äin\Úf¡x¶žmº\Ç8#Ê‘™J©m¤®p\ÙL®\n\äc\ß\êWš¬\É5\í\Ô×’¤QÀ²\\H]–4@ˆ€“Âªª¨\0\0÷\\=?\'ù\è\ï½Þ–Ðµ/{ž\Ý\í÷§þjÝ´\î{f¿ðŸÀrüP´øm£O\âM¬Y\é\ë¬j3Á=¤‰1O\Ü$h\è\È]B\ï¿iùSpx\àþ›\â\ÏZ\Úø\Â\â-=î§ƒ[ˆIuröªŠm\æÉ¦Û²}\ÈÊ°\ÊcÛ»\ç\Î\Êñ\Ë\íZûT\Ô$¿½½¸¼¿‘ƒ½\Ôò³\Ê\Ì:\Ä\äž\å]=\ïÆˆ:–¯§j·~:ñ-Ö©¦\ï7\Ój÷=®õ\ÚþS—Ü›‡i\Z®Þ¿\åý[\ÌÏ¿§ùÿ\0Àû»›¦ü	ð\åßu95›@ðvŸ u$my5#{¸[q\"]\ÚX\É\å¦ö\ÉÙ™vp¹,”¤ðÂ>\Ë\Æ\ZòjZ\ïŠt\r6÷J´°M\"\ím™\Þ\ê\Þd’k‹@\Ç\ËhW.ü}\ÅÝ”ó6ø\ãñ`ñAñf¸|L`ÖŽ¥7\Û\íÙ;vümùzô\â©\ë^5ñ‰\'¾›W×µ=Vk\ébž\îK\Û\É&k‰#R‘¼…˜\îdVeRr@bZq²jÿ\0×½\ËNžEtwþ´_­û\Þúž\ãªx7ÀðW\Å-/Sðæµ­\Þø{\Åv\Úb\êvú­½¼†?ôõŒ©k9kˆ\×\Ì\\‘# ¦\Ü\ZþøoÅŸ_Q\Õ..´\ï\\\èÚžµ§ˆo\ä”M —.\Ö\Ë`Èˆ^&Œ™.\Ðç§*­\äšGÄ¿øTÔµ-/\ÅZÞ›¨\ê{¾\Ýyg¨\Í\×y$Ÿ5Õ|’I\ÜO&–\Ã\âgŒ4¯Ÿ\Ùx¯[³\ÐO™.\ßQ™-~pCþ\è6ß˜3\Ç!Žz\Öv|­ui/šVüõ¿ªó\×2}þ¿\Ëñò=\â\Ä>µøgð\îmÂº¾›ª\ê\Z<“-ôº¬F\åu¤s2-š4Ï„Àm\ëµ|µ!¶eµõÿ\0\rÁñ3Tø\á:÷S°\Ñ5k­¾¥,rØ‡\Ônb#\Åf\ãp®	\ËmÝŒW\Ç\ã¯\Å\ágð\Êx‡UO\r¼žsh\ë{(³g\Èm\Æ\Û	\È8\Î@­\ßxÿ\0\â^½£\é\Å~$ñ^£¥L\ßl\ÓN³}s,%<\Ø|\Æ*JË¹zŒÖ«\Ýÿ\05ÿ\0=?\ÃÍ\ïk-\íc\Ò|9ðÀ>0JÖ ƒÅš€\Ók×¶w—V÷7ll¬\Z\ìI‚—œh\Ù>›?‡þðf«\Ú\Ú\ÝZ\èz‡‚nõˆ\áÖ¬l¼A=Œ\Ñ\ß5±eŠX\á†cû¢F\å\\<ñ^®|Lñ‡‰õHõ-c\Åzæ­¨\Ço%¢^_j3M2B\ê\Êñf$#+¸+œ\Ä¦³\Ä\Ú\Äv\Énš­òÛ¥«Y,Kp\á»9‘¡8\Ø\\–+Ð±\'¨w³Kµ¿	/Í§\åk\"´ºõ_š–ž{³Ó¬t¿xª/x\ÇY:¶«§\éSY-­¾‘ie µ×œ]è£Žh­ñ°7È¯œŒ¾\å\ë>\r|ð/\Åÿ\0\ß\Üjú~•¬k¤h7\ån˜ˆ\Ñ\ÙZ\Ú…‘£Y™š[t`z®¯Ï°\êw–\Ö76P\Ý\Ï\ÑC=ºH\Â9JPºƒ†\ÚI\Æzd\Ö×†þ%x»Á¶\Øø\ÅZÖ…e<‹4¶\Ún£5¼rH1‡eF\0°ÀÁ<ð(·º\×õ\Óúò&Wn\ëú\Óüþóß¼û:ü>\Ö<¢O¨\Üx”\ëz„6¤\Ékwn–\ÂKƒ¨ù\Z`¨4ý\Ç\æ%¼Í¿.7W1\â?„?\rü\á95oÈ¾.¸°\Óõ5¶†[Œ\\¥Ç•!‰c6(\Â\Å#boµHG\Ê\r\ÅS\È-üu\â[H\àŽê°¤<¥ŽöU\ìó6m¸\Û\çMŒtó_x\ævø‘\â\×ðšøY¼S­7†W¦Šu	\Ã\ïÿ\0S»g\Þùºu\ç­]\×3“\Ú\éü»^…;h–\Öüt\×ú\ïs¸ñ—†\âðo‹µ\Í’Ht«\é\ìQ¦\Æò±H\ÈcŒ\áy\Åc\Óc¾¹\Ô\ã[\ËË‰n\î\î5\Ä\î^I]¹ff<’I$“\É&J+–)^\â½õ0õ\ßøúþ¹\ækXÿ\0¤ÿ\0®Qÿ\0\è\"¶5\ßøúþ¹\ækXÿ\0¤ÿ\0®Qÿ\0\è\"©\ì\n(¢¤ú?ü}?ýr“ÿ\0A5=A£ÿ\0\Ç\Óÿ\0\×)?ôS\Õ-€(¢Š\0(¢Š\0|?ò\×þ¹Iÿ\0 \ZÆ­˜\å¯ýr“ÿ\0@5I\ï?³-\ç‰\ã±ñ-‡‡¼7\ãiÆ \Öñ\Ë\â\0\Å)\Ô4²¢B¨\Å–Ð™\"\Ý\å©\Þ6Õ›O‡¹¼ñ{\ë:„>\"¼ðn½=î³«\Çz\íý¹§²¾\Þwœ3\\Ge\Ð\ç7£$\í¼CEðÎ±\âV™t&ûUhvy¢\Ê\Ù\æ)½\Ö4Ý´nwU\ê\Ì\0\äŠÛ»Ô¼Y¤øV?\Ïc.›¦^\\³y_\Ùi÷r\Æ\å\n<\Â1,Á$\ÈòÙ™U‡@E)^OM\íþ_•¾w³\î(\é«\Úúý\ÏôÛ¶\ç¨øká¥—ˆþ\êZõ§þ\Åy7w³øƒ^²\Ô\Ò\ÄÆ¬\Û\Â\î)¾\Ï\æ\r»w1Ï‘\æ1!¿•¼Ið?\áÞ«eð\æ\Â\ÏD‹L{[Ÿ\é\ë¨ÌšdƒR¹\Ì%\Ú\å\âR\á•\ÊÈ¥ò6…ð+\ë6ò\â\Îò\Þ[K»y\Z)­\çB’F\êp\Ê\ÊyA¦+cIðŠ5\ï\ß\ëºg†õ}GD°\Ýö\ÍJ\Ò\ÆYm­¶¨fó%U*˜R	\É4]o\ÑYý\×ü\ïýlV«Nºþ?\ä}Q¯|ø{¦ø\Ë\ÂzðO‰³§×­\ì¢ñšdöº~±fQ\Ë7\Û~\Ý4s<€F\èðGÀs³*ùÿ\0\Æ\ßøM|¢\ßø_\Âvþ\Õ..t¸\ß\ì÷\×3,\Íw¦Gt\Èò¸UW|/|g,r1\àú–ªh\Öö\Z†›wcü?h´–\ænb\É_22À\\‚7ŒƒT)Z\é§\Ý~\r]|\ío›\ÐZ¦š\íù\ìÿ\0ø\'\Ð~\ZÏ¤\ÅñoÁ^3‚\ãLm\Ú\Öÿ\0X†\ÖH\ä–(­nU¦X\ÜnyGeV\É`9É¯A\Òþk‘üE\Òü/©øôOOhºÖš/\ãž\ÊF¶¾žÜ£[:.\'gU(p\ê\Û@\ä\×\É\ÞðÎ±\âýZ/BÒ¯µ½N`\Æ;-:\Ù\î&p\'j ,p\' ªš†Ÿu¤\ß\Ü\Ø\ß[Me{m#C=µ\Äf9\"u8ee#*À‚<ŒRzÁB^7gü¯§ŸWÐ”\Ü\×ü6©þŸÕµ÷ß…>ð\Ä:_‚ô\Ïø!5\r{_ñ¥Ç‡/&\Ôn®í¥±…V\ÍHX£‘12½\Ã_ `†V\ãoQð§\á\ìz†-µ]/Á°j\Öw~×®u\Ü\Ïp\r\ÏÙ¯b‘™`\Þ#&7I$\"Fq…\0¯\ÊTUKÞ‹]Z·\áoø%E¨µ\åþmþV]´Û·\ÓW\ß\n<9£øF\æ\êûÁ+†-tKJ\Ç\ÇMyr£U¼sKj\Ìò÷ùQ •9,J±7>\"~\Ï>ð,Z¼°\Øj:\Ì\Ë\â[mû6\Í\Ý\î#i\'’uŠ\×\çg³0(\Þ\ç,A\è\Ë5±«x7_\Ðl\Ö\ïS\Ðõ-:Ñ#Y\î\í$Š2\Ï\ZÊŠ€1²¸Õ\èA§\'\ï)v¯_Ë·–÷\Í/w—«_§O\ÏúGª~Ð¿\r\Ã\Z·‡N›\á‹O[\ê\æU´\Ò\ä´\Ôlu,@\rÝ½ô\Ò\ì$¶á‘£m­óeH	<!ñ#À?ð¸<; Zk–>Ó¬-`koHò^\ÆEô`F¶$‘·9*H\Æk\çŠ\è®>x–\ß\Åþ\Z-\åÇˆn7K´Ï¹;\ÐH«\åÇ–´‚PÃ¸1N6^¿ð?__!\Ë\Þü?\rÿ\0OC\êˆ~iž:øƒ®j\Z\ï‡`ñf³¦\éšD#³\Ó\ì\'½¸]VTqq+-µõ¤h\Ëýü\Ï#ò2XŒ_øFm´}\ã/‚|-ð\Ö\ÓÆ¯¡x²H\ê7oj†ýy\Ú\å2!\Ê(eP¿½ù÷¤|Û¯x\Äþ¸½·Ö¼9«i\Ù$r]Ec,\r\ÈqHAPÇ€N3Ú¥\Ð~ø·\ÅZ-æ¯¢ø[Z\Ö4›-\ßj¿°\Ó\æž6®\æ\ß\")U\ÂòrxÒ—½m¿úRrjË²v¹i\ÚË®Ÿ‚·\ã¹ôÂ¿úˆ~É¬k’\î{½VÔ­õ\ë+­–²[,\Æ8¦ºk\åe/ú•µ‘ŒlFK\'Ë”QNZÏ™m\Û\ïÿ\0?À•¤l}}ûCZ\ë¾#øŸ\á}^\Ñ|„\îu\ëx\ç\×uY¥\Ñ.U\Õ­œ^Db\"T¾\n\Ê\ç±\ë^q¡\Øø\Å\ß,ü,|	—aay¨\Ç3\Ùj·E\ïm\â‚C”\È\ï‰CE»|{\î#\Ë\Åx\Åß‡u]?H°\Õn´\Ë\Ëm/P2-ô\Ö\î\\˜\ÈÜ®T	\Æy¨t½.÷[\Ôm´ý:\Ò{ûû©(-mbi%•\Ø\áUUA,I\è44\äô\îþ{[\î·\Î\â^\ìu\ì¿\ßóügø}¦øwâ†¡«\Ýhÿ\0\r-.u\Ý+H2\ÚøKO¾¾–\rZspŠdX\Ì\Æ\ä˜\áwcrü\Æ0\ß*†S¹\â_ø7Á0ø\ÓWŸÁ¶·W\Úm¦)ð\í\æ¡tmô\ËË•qso!ŽU˜„#\î4›Ñ€\Çkðox_Yðv­&—¯\é\Ú§V{-J\Ù\í\æP\Ã*J8Gw\Â_<U\ã\ç¹OxgXñÚ…3®“a-Ñˆ6v—ò\Ô\í\Î3\×“\ÖÜ½?\àÿ\0Ÿ®›\ÛA\í~n¿ð?\Ëñ:\r\"\ÇOñ:üBÔ´¯t\ë}<\ÞAÕ˜a©¸‰|\Ð[\rp\ï,!\ÉÄŽJ\æ¼þ·ô?‡\Þ)ñ5®§s£økXÕ­ô°Zþk	fK@$\ÊUHA…cóc\îŸJ|?\rü[q\á7ñD^Ö¥ð\Êd¶´š|\Æ\Íp\ÛNfÛ°a¾^½x§¢ù%ý_g®\Þ\å§õ÷o£õˆ|ÿ\0û>‰¤x\ÓE¿ðž‘­\è·+\r¥üWww2Ewö¦}öª¡\Ü|±€\å;a–~}ÚŠ\àCð\ç\ÄöZº\ê70r\Þoj\Z“2Y¼I˜txq´Y\Ç”\ZUùd&\"B\áù&\ë\ÂúÍŽ…e­\Ü\é7\Öú5ó¼vºŒ¶Î¶÷‡±\ÈF\Ö õ\0œU­{À~&ð®›§j:×‡umOÔ“Ì²»¿±–®—·D\ì 8\Ã)Ê“Á´T÷\Û{kÿ\0\Èÿ\0ò:v_‰u¯Oóÿ\0={ú™6Qù·\'•\ç\î‘G•»nþzg¶}k£ø©£ÿ\0\Â?ñ\Äzoü#ÿ\0ðŠ}–öH¿±>\ÛöÏ±`ÿ\0ªóò|Í½7gš\åj\Ô:e\åÍ\Í\ì6“\ËgjPOp‘±Ž\"\ä„Àawqž¸4>Ÿ?\Óúü­­\×s\è\ï\ÙNó_±ø\ã‰|;¥x\ÓX½\ZÆ\æ[øQ’\Êó\Ë\Ù}“#¤2“pHPI_˜c›¶þ×¼UqñøxÂ—\Zò™n~\Ï\â[\ß\Ç\rÄŸ\Ú\Û\ì\Ò8fkw\Ëw“\Êe€¡ƒ \×\Ìwšmæœ–¯wi=ª]D.-\Úh\ÙÑ–*2>eÊ°\È\ã*Gj¿\á\ëþ8Ô›Oðæ‡©x‚ýc2›].\ÒK™Bmˆ	À$sŽ\âœÿ\0y&üšüÿ\0\ÛG\Ëg\æŸ\Ý\Î\çµxo\Â>ºð‡„´™ü%o6³­xSZ\Ö.5\Ùon„\ÑOj\×\æ*%”D?\ã\ÕU·«`)·Ou\àð\Â?¶›\à\È \Ð\æðŽ›,>3–{ƒ6­4·z|²¤`\Í\ä2#³©Eº?-\ßqù¾l¹ðž¹gc}{q£jY\Ø]}†\î\âKY;{Žs#„“\åo”\àðx\â²h“Rm®¿\æ\ß\ä\Òù+\Üq÷evwûšÿ\0#\ê/|*\Õ/üUðøWðß‡5I-ô\ë\í2\ãûE-!’MNuhc72»B\ÒB«!Eq\ÅÀ\ÍRð_\Ãÿ\0üN\Õüum\á(4;k­W[\Ó\äÓ­.\ïnØ´³†{o7.ó;—k‹p¬\ã>Z+`WÍˆ#ª\"—v8\n£$ŸJ\ì­ÿ\0\á7ø\â\Èn.t«\ï\ëMk\"‹]sKš\ÞThœ4•’6R\ëó)¸§¥\Û}\\šù\ëo—ü\É~M~©ü¼Ï§<7\á©<ñWP\Óü;\à-s@\Õ\ãðMÌ’G\á5\ÕôÛ½Få§-d\×\ë$êª»Ww•÷„œƒ^s\á\ß	Xx\Ë\Ç^,›\âf¯hv°\ÞÙ™u¯jS>£ä¨Ž\Æ\âgX•¼ô\Ýû\Ãh•Ÿr6\r\âþ1ø­ø\îK#«Mj!²¢µ´\Ó\ì-\ìm VbÍ²#R\Ä\ä°\\·\'¹Ú…ñ)Kµ¿òfÿ\0]µZvºf–\å]\ïÿ\0’¥úo¾½šú«Àm®´\ËYu¯„\r,òø¾\ïN×¦š}B+oi©¬…™„ÀG±f‘–YÝ—j\ÂN\nù\æ±üðÿ\0\ÃW\r\àø|G6¸š’¾©q¨\\Á<kÄ‘[\É\n\Æ\â5p6–Þ’+mjòO•M\â-B\ãÃ¶š—´«K©¯!·Ø£lÒ¬i#n\Æã•†1‚p6ðN]ÿ\0Ö¥ÿ\0\Øñ\0µ/¤}¬Øµ\Ê2°I¶\à¦\å\ÉRÀ\Úûs±°4þVÿ\0%ù\í\×][*ý:\ëù\Éþ_-6=ÿ\0\Ç_|á¿‚0j6^ñ&¥<\ÚM•å¿Œ,ôyš\Ç\íR˜Ì±\Ëx/š\rŠ\Í,>XµI•bC\â‡\Â;\r\"\ÇÁ÷–Ÿ\ïô\r2óT¶\Ó\ßK¼°Ô­<I~Jü\ê‰<’[\Î8’\ÝT\ït\Ýa‚Ÿœ*Ö—¥\Þ\ëz¶Ÿ§ZOu\"\Å­¬M$²»*ª¨%‰=\0\æ´\ÞM¥\Öÿ\0Ž\ß\×\ÜgöRo£ü·ýO >&|/¸ðç¼ \Ú\ÃKiF¤n\Ó\ÂgO\Ö\íu9–0\ë«Y.^U#$«\ÛLPùmó|¬£S\Ä\ß\ïO\ÇÏŠ\Ñj^\Õ<O«\Ùý¢ûAðÞ¯%\ëM«\Æn\Ö!(o1nnQ!ól}\Í\å\ä±\nÀüû\â\Ïø“Àw\Úx›\ÃÚ¯‡n¦ÍŠ\rZ\Ê[Wt\É•dPH\È##Ò°\ë5²·No\Çü­ÿ\0\\¿\Ëðÿ\0?\ê\çÒž(ð‡ü¥ø§Xºð-¦¡©[Í \Â\Ú\r\æ§v \Ònnmî¤»·o*U”\íh@\ï½˜\íeo\Zø¿\á»/üVñ†…§+&Ÿ¦\ê÷V–\è\ÌX¬i+*‚O\'\0MrSz»úþŸ•Ÿž¿{ºµ½?ó>˜ðÂ­ó\áo…u]CÀ\Zû\Ãú¥ö±\ã™n.\Ò;;˜¦»Kd¼Å·YEynÉ½ª±\Ëh\ê|=£þ\Ï÷>\"¾ðžýV\ÇDÓµ¨5ˆl\ï!²½3\\@­¸{öY\ÛË˜‰x¶0\á\×\Í\Z§ˆµ\rgO\Òl¯.<\ëm&Ý­,\ãØ«\åD\Ò\É1\\€|ò\È\ÙlŸ›\06œý\ç&´»\Ó\Ò\ïü\×\ÝmE&›\×ú_\äþó\ë­b;C\ãwÁn‡¶š‡yu\ám\âK¿h®X[Û«Z¬“O$$FU—\0yƒ\Êù˜\Äø¿\Å?\êž\Ñ<Q¢xr\ß\Ã2\\k:–—-µ­\Ôó¬±À–²G#´\Îß¼ÿ\0H`\Å6!À!¥ym=o\ê\ß\ßoòýGe¯d¾\ä\×\ë•¶g­~\Íþ\Ðüu\â­b=f\Æ\ïZ–\ÃL{\Ë-\Æ\Ñ\î\æ\Ô%F¬‹w6òK¶7’M±Ì­û¼üÁY[«\×|3\à¯\Ü|HÕ‡€/ñ£)-tGw§igV\ï†;–›\Ë$nEi\Ë³.À0o\ÒômC\\žHt\ëBh¡’\âH\íai\"E,\îBƒ…U‰\è\0$Ö¾Ÿð\ãÅº·‰&ðí…õ«\ßB¥\åÒ­ôù¤º@–ˆ.\à0\ÊrGq\ëD®Ú¶š}\ä-¿õ·õó=\Â\ëÀš_€n<c\'\Ã\Ë]M.üM%”Zeö­y\å\Ú\Úy\ÊcG‰\ãb\à’\ßv;–C‚:¯ü(ðþ¥\à\"ôø(\ßxgQ\Ò/¯µ/I{q\é\â+b\è\ën¥|»q²X\Ë\Èfùq¹\0ù\ãX\Ñu\ê—:n«cs¦j6\Îcž\ÎòŠh˜uVF\0©ö\"£¹\Ó/,\ím.n-\'‚\Úñ\ZKi¤•&Ub¬\ÈH\Ã\0\ÊT‘\ÜÚ¡û\É\Ù\ïk\à6ü_½}ü\ÊW‹W\é¿\ßÁi\Û\Ëkz§\Ä!\àÿ\0øsE\Ò!ðU¼ºŽ©\á\Ë-AµÃ¨\Ý˜®\äUfeM\æ\nACl»\ê0%\ãMû/\Âþ	ºÿ\0„kû\íút“}¿\íÿ\0hþ\Õ\ÅÌ©\çùyý\ÎÝ¾^\Î3\å\îþ*Â“\Ã:\ÄZÞžúUò_\ÚFó\\Zµ³‰as»®2ª«óxš±®x/YðÞ¡jÚŸ\Ùôýr¹\Ó\æóQ¼\è\ÒF›\nI\\:°\Ã\0x\ÏJ§\Õ÷wù{\Ö_\ÖöÛ²Ž\Év_\åwýwûò ™í§Žh\Î6§ÁÈ¯mø;ñs\Å:\ï\íM¡xŽ-V\çF½ñ/‰mN§“<–ñO·H^P\Ùhûmbzsšð\ê³u¦\ÞX\Û\ÚOsk5¼‘™­¤–2«:d,„™C#®GR:ƒTš}¿]þû(óEÇ¹\îž\Òu_ŠVþ+ñ=\ï‡o¾2ø\Êû[A¥j—·Gh\Â]÷$A*N\áJE;¶&ÿ\0˜®5üYðžûVðŒt‡Z&©\â­?Mñ·\î\ÓH…õŠ/²0ùž%!€\'nþ‡õó]œ£xò®\Ëðqûoã¡¤¥\Í>6þõ%o•ÿ\0\rO¤|ðF¼ð‰uu\à\ß\íûF¾¼\Õüt\×Wÿ\0c\ÞFg\Û\ådñc€ys#<†”É/ü\"\Ð|#ðk–\Þþ×–\ëD\Ó\çƒ\\KMeå¶¹˜F÷\Íp¥tó\îtAfc¤‡\ÇÌ·:eå­¥\ÍÅ¤ð[^#Im4‘²¤Ê¬U™	`J’;‚;W§kž>ø¥}¡^iz†Ÿ,0®n//Ã–ö÷Í¦\í!i®\Ö¡e.ç« “š©k\Ìüÿ\0ù-?]5z\ZOú\Ûúí®ˆô¿|*\Õ/üUðøWðß‡5I-ô\ë\í2\ãûE-!’MNuhc72»B\ÒB«!Eq\ÅÀ\Í\'Ã½/\Âz¶©\áh¾\Ó|3«\Íw¯\éZU«]\Ë<S_Aeš{\Ènde3yÓ€0\ÂaJù\ç\\ð^³\á½BÕµ?³\éú\äs§\Í\æ£yÑ¤6’¸ua†\0ñž•‰Où—œ¾WýV¶\ìý[Fõ\Û\ÓDÿ\0¥û\Û\Ìú\'Eðo\ÄOkº¼Ÿü=\â\Ïø§N\Ñ\ÍÎ…\áŸ> &¿\Í\Äi\'–¥\Òy4i$)J\äœ+\Û\éŸ	~é¯­\ÜjžŠ\â\í!I.4w\Õn—û&\átk\ËÙ­”¬›ƒ	­‘q)v@Ì­–\ÑI\ë£\ïóþ¼ü\í GIs=\á­ýLû]þü1\Ñþ\Üóø\n\Öü»´ñ¬š¥ò,#\í\ZLK\í›%ö„\Ä\î%Ž\Ô†	9:O\ìó\á‰<\âinü1-\Äk¿sa®YZ]2\Ùý®1Ov\×\Ë”´÷B\ÖFh\È9\ä²|}[þðŠ<r/†ü7«ø€Y¨{Ÿ\ì»n|…9Á}Švƒƒ\Éô4¤¹£e¦_\Ö\Úü¬÷^º\êŸüÿ\0C\Úu\ßø&\ãCÕ´k_[išo„tMuüAöÛ©gk‹ƒ`\'\Ìm/”#+v\çnÌ†\n»_||ðwÆº|‡Âš<>+Ó­ô\íE®.$¹\Öm\ã†ýR\éü\ÙYXa–HcŽ6.Ás·ó5Ö›ycoi=Í¬\Öð^Ff¶’XÊ¬\è²>eŽ¹eH\ê\r.—¥\Þ\ëz¶Ÿ§ZOu\"\Å­¬M$²»*ª¨%‰=\0\æ®^úq]_þÜŸ\ák-Ek\Ûô·\âõ5üq\ãG\â«k¨jbž\Ú\Â\ÓNAn…WË·…!BA\'\æ*€“\Ó$\à€;\Ù÷Á¶\Þ0ºñ™“Á\Óø\ïP\Ót#{§h¶\ísº[µ\ÛF	[r$u	#–PFW8*p\ÃÍ®tN\ÎÉ¯.4\ë¸,\Ö\á¬\ÍÄ2\Æ\'PE¸Œo\0‚W¨\È\â®xkP\×!WÓ´EšaªX¼°[À%i-£d¸\á%UL\n\å†0\ä\ã4“Z¿_\Å^ÿ\0¨­¬WEo¹=¾\åcÜ¼M\àÿ\0x1|oªI\àû;\ë\í&\ÓE/ \Ü_\Ý}“N¾¸¾\×n\Æ9\Ä\ÌÁ\Z]\èëµ˜\íek¾xw\Æ\Ú}Žµ¥|5ÿ\0„ƒI\Õuù­µumJé‡…¬@ˆ«ù±º\Æ$\Ä\×!\Óƒµ\Ë|\ç™yqaq}¤òY[:G=\ÊF\Æ8™÷lVlaKml\×i\ÇJ­J:^úÿ\0\Ã\ß\×ñ½ºŠZ\Ú\Ú\Ã[þc\ê]/\á†Àº%\ìž’\ï\ÃW:6¯u©|@–\â\íc·š‹\È\íl$[u‘ŒV\ë±\ÕÌžbUc–\Íñ\×\Â\ßøg\à„\Z•Ÿ…|G¨\Ï6“eyo\ãMf°ûL¦3,r\Þ\æƒb³K–-REe@X\Åþ~\Õ<E¨k:~“eyq\ç[i6\íig\Å_*&–IŠ\ä\0[\ç–F\Ëdü\Ø\è\0´šn\é>¿…\ßù¯»©w\\\Ü\Ö\ïúÁûú\ÛñWPðG€üu¨øwOøq¦H4«\ÈZ+»Nýš\á|¼\ÉÂ‰Àd%Á_+\ÊeØ¹gù³\Ø|f\Ñô\ë\ÚrHü]\à8|3\áwU½†\rj6¾Š=A\'b±jIftqI¿º‚¤\ÌU\ÐxX\Öô%ï‡­#¼\Õ!ŠIQd\Ób¿ò\Ñ»\È#–7PQT¾üe–\È\Æjôv\æ\é\Å+úmòÜmhÿ\0_\×\âjüTðõ‚õ‹?\Ãiz¶“l°\ë+#±–õ‰yP‚\ÅW\Ê\Ü!ù@É‰\Îx\Þøko\á­3áŸ‹<I­øV\×\ÅW\Öz®™cg\rõ\å\ÌÆ³%\ÛJXA$lù.>a‚\ÉV\âtø›\â6·q‹¤\ê\Þ(\Ö$u4v\Ò\Ý\Ü0\Ï\Ï#Ç–c\Üû\Ö)F*À«‚QE9rüj\í\Ùþ7vò\Ýy\"¥i^\ÛX\éÿ\0´\ê–:wOt¤ñ…þ«^=\å\Ê\Â9§\Ä\è#”´Rª\ÄJ4¯\ç\\÷8\ÇžgS·MSöox{\áí‡ˆ\ì´]wV†\ëZµ\ZŒ\ÒYGö{M—\ÒywZ4—O+÷< ù³ó\ãi—‹¦¦ Ö“­„’´	tco)¤P>0XRFrZ\Ú\Ð~ø·\ÅZ-æ¯¢ø[Z\Ö4›-\ßj¿°\Ó\æž6®\æ\ß\")U\Âòrx\Ö|­F\×\Ù/\ÓW÷yo«c‹´”¼\ß\ãÌ´ûÿ\0\r¬`[´KqH\"F\á—<€\Ä;\à\ã\Ð\×\Ôþ\'\Öü3¯Â¦øumq\â¯\rxKV³\Óæº´¸ñDm§yR\\J\Îd„[F†büù\ì@|Ÿ-|\Çq j–º=®¯6›w•w#\Ão}$°L\é\ê’µŠ\äd‘‘š\Ô\Ô>ø·JðÅ¿‰/|-­Yøv\ãi‡W¸\Ó\æKIw}Ý³\ØsŽ0y­\Ñ\'²iþz~)ÿ\0Ã™\ÙÝµ»M~Zþkþ÷ÿ\0øS:n­y¢Zk\rÏ€üS~u«ko¥\Í\â\Éz\"\Ó\ÞK9\Ö+‰^m\ßiVò\å#N\ÔøM¢ü:ð\ê^ø»Áf\ëY´ð;\ë7\ZV¡wqoþš\ÚÐ¶¦X\äV\\BÊ­(x \í˜|û£\èz—ˆo>Ç¥i÷Zß–òýž\Î–Mˆ¥¶¨\'\n ’{\0I­\r/À>\'\×/4\ËM7Ãš¶¡uªDó\ØAkc,¯w\Z–ñ*©. £‚W m>†¦Ï§õ¤—\ë—–šs-/²ÿ\04ÿ\0- !øO¤\Íy¬\êžøm\â»÷‡Bž?\r\ÉuyöM2\Ës=\Ë4s¤\ÞZIµ’K±\ä\åHòo\Ú7þK÷\Än\0ÿ\0Š‚û…9\ëÞ²´ÿ\0ƒ¾>ÕµGH±ð?‰/um7gÛ¬-ô›‰\'µ\Þ2žla7&G#p®~÷\Ãú®›\rÄ·ze\å¬V\×-e;\Í¢\Åp&$|®0r§žJÍ¦¶WüyW\é÷°_+\ßO½_\Ö\ç\Ð	øK¢j\Ð\î\î<5=PÑ¯ouo›»„\Z=\â„vùY¼dyp~\îTg\Ïò‘¹1CÅžðjøW_\Ó4ÿ\0	[\ØjZOƒ4om‹Û©.&ºŸ\ì`Q¥ò–6Mò\ì\ÈaÀ£Á\ît\Ë\Ë;[K›‹Ià¶¼F’\Úi#eI•X«20À2•$wv©®4\rR\×Gµ\Õ\æ\Ón\áÒ®\äxmï¤–	1½RB6±\\Œ€r23NZ¹?\éoþk\î\Öâ‡»k\ëú\ì\ß\àŸ¥ô±B½{Á\Ïñ\Ëâ¦ÿ\0	”\ZÅ®Š-¬´‹wkq©Kge²\Ö\ÛpmÛ¥h„3!6’¸ò\Z)ù[5•\Éó_Òºvù\Øúó\Ã\â\Ó\Ä[|0™|Q¨ø*Iµ‡¶\Ïzì²¦­j!cvºY%h\Ë\î*¤†E`G#¥\ÛøoÀ¿´w†ôKo	iþ}õÆŽ—v\çQ\Ô#—A½Gö˜­¥‚\í]\ÈÄ­##&\ÓÊ¶~q®£Á5¿‡þshŸÙ°\ÜH\ë\"\Ý\Ýi—W:\çk\Ã4\Ñ;\ÂÀœ†”‚\ê]š}¿Í»yoøie I^=ÿ\0\r¿\áø\ës\Þ~|-ðŽ¿\á\ík\\Õ¼/\â?^6½sg{k \és\êw6\ê’L\Å}Dòo—Ì“¡1}Ü«\âÀ0\Û|±\×|=\à	üd·q^¾¯\âI’òA¡¼r²${m\åX\âeˆG13«ƒ\æŒp¤W˜øÁº×‹¬õ\Ë\Ý2\Ð\ÞC£YGPÊŠbƒz¡™o™\Ôary\éÖ³.´\Û\Ë{I\îmf·‚ò35´’\ÆUg@ì…‘ó(du\È\ã*GPk>^T£\ä¿+~-?»}\Í\\”›’]_ù\Û\îh÷Š\Í/ˆ>ü?\Õôß†\Öhð\éR[O\â-<j2¦0Ô®p]\î^%/¹\\‰T·\ï¾RÐ¾A\âOj>*\Ðü3¥^ˆE¯‡\ìž\Æ\ÐÄ„3F\Ó\É1.rrÛ¥#Œ\ÆrL3ø/Y¶ð}§Šd³Û \Ý\ÞI§\Ãw\æ¡\ß<h®\é³;†\Ô\äŒði¾\'ðoˆ<y§ˆ´-K@ºž!q\Z¥œ–\Ï$dUÀ%IdqÁ«–²•ú»üÞ¿“û™enß¯ùþ&T=´ñ\Í\Ã\ÆÁ\Ô\ã¸9\Ú\Éñƒ\\—\ã ø–\ÑYÿ\0\ÂAý®5Ÿ\'\Êo³y\ÂO3n\ÝÛ¶dc³Žù\æ²uÏ‡~#ðî¹¥\è×ºT\ßÚº¥½µÕ•¹Yä¸Ž\áCC´F[,\á†\ïd\ã®u”£`UÁ¨§vš\î¯ò}\"l¤š\èÿ\0¤{¯À(|g\ÒüQ\àû¤¶š\êò\Û\ÄV\×€°´Ryw„{}ži$>\Ö\ãÒº]?|n\Ó~5øƒDðF¯yô\Ö:¦“þð«wh‰§•†O\"T[s¸\ÆÑ³\0²Œ|\Û™yqaq}¤òY[:G=\ÊF\Æ8™÷lVlaKml\×i\ÇJ­R\Ò\Ùv·\ä¿$’^½\ÊMß™\ëª­¾n\íÿ\0À>“ð¿\Â\ß¯Àk}~\çÂ¾$ñ=\Ý\æ{qw¬\èº<\×i¤\ÝFÒ¬q\É:_G\n¡!‘\Öki¤ŒCa—f÷ü3ï„­ôù|CkžciZn¥\ç\Èa‰oV\Ö;y\É\Ü\\\\}¯!\Ë.6~^±ðî«ªizŽ¥g¦^]\é\ÚhF½¼‚\Ý\ÞP\íµ®3p7“À¬ú\ÑK–nkþ\Ó\Ï\Ïž«7h¥ýt\ßü¼þG\ÚZÎµ\áÏŒ^%ñ\æ‹v$\Ò,\î<K`þ º\ãˆ<¢ðÚ¯—\' )s½€\Ã\Ï.A\0g’OƒZUý\æ†uï†­\à¯´º¡·ðZ]^#\ëI¯›l6O+\Î7\Ì[£`$ÁXö°\Í|\ï¯x\Ä\Þ\Ót\íGZðî­£\éú’y–Wwö2Á\Ò\à6è”e9Rx#Ö°\ëC’Ïª\ë÷/\Â\Ýni\'\Í.n¾ÿ\0\Îû«;õ>Ä—áž›\â=sÁv\'ðkiWúo‚§¼¶ðNos{$\ÓjÜ†ˆ@×±\Ü;¬nò´B\ádR‡#\Ñ\Ö€|)¯Áñ£\Æ\Ú7€<1\ã}#Ã’xzöWCŸNº·);\éWTsÁ\æ\ÌB´Ä˜VY¾e\0±\äüÏ¯x{Uð¶§&›­i—šF£V{Kø	T2†RQ€  Ž9\Z·\á_x\Çw\Ò\Ùxk@\Õ<Cy~t–úU”—R\"d\r\ÅcR@\É=9£÷¹¼Ô¿òkþWü\ÍË¯§\éþ_‰\ë|w\ã¯\0øGâ¶‹i\âøq´½\Î\Z|7³Ú›K¯\í+(¤,0\Ù&\Ò\ÈN`{Š\ìþü\Ñ<QðN}s\\ðô\×÷w\Ú>¯ªC\â;;¢-\å¶YŠG=\Û_,+)x³\åY‘\È\ÉdùrXž	9£‘	VF*GPGc[V~ñ6¥á›¯ZxwVºð\í£ùw\Z¼62½¤-\Ç\ÊóØ§\æ^	þ!\ëJ^ô{Zý·\×ñ_pG\Ýj?Þ½¾KO\Ãñ>Žø£\à»\ïÍ¬k>“H´·ðV‡.›\ã)¤¹C¨jf³E¶‡sˆ$_/\Ì\ZA\å;—\03~\"|?ñ_‰/¾7\Äø|I¥X\ÞÚ¦“ªkš\ìS#Á»S»!i\Æ\Ä%YCži\Æ\Úùš·u\ïø›Âºn¨\ë^Õ´}?RO2\Ê\îþ\ÆX\"º\\\Ý²€\ã§*OzÕ¶¹¹šÓ™?\ÏOÿ\0¦\ä\ë\ÉÈ·µ¾\ä—\é™õM¯…ô‡<?>›\á|7\Ôb\Ó<Bf¿›C¸°\rzd\Å&µ\ê\r,Ñ\çr\Í\ZÇ¿xó¾\Ó?hY\Âöš§\Ó\Ã~™\î\ïu­2{­gZo´\r¥m­o£y12¢†¹8Ž6bN\Ìf\×M¼¿†\îkkY®\"´‹Ï¹’(\Ë,1\ïT\Þ\ä•w:.O`:‘Q½¹µ²ü}\í~\\\ß\×Jnûi·æ¾{\\G\á+Á¿>+ø3\Ã\í|Isu\á{\ëM\"é¯ž\êC#\éó\Ëj‘\Û\ÞQK<›U\äyXó]Cnóß…~ñG‰<	ñn/\áÞ­\Ìv­\Z]i1ja\âœ^Ú‰4\æE”\Ç\"¬m#˜\åGm\Ü[\å\Íxß…|\â?\ßKe\á­Tñ\r\äQù\Ò[\éVR]H‰7I$ô\äU­á—Œ|G¥\ß\êzO„õ\ÍSM\Ó\Ù\Öòò\ËMšhmŠ.\ç:©@\ä\äŒi=µ\ío\Ç\ÓõÕ„^\Ö[I?Áióµÿ\0\á‘\í\Þø[\à\Õø\ro¯\ÜøWÄž\'»¼Ó¯n.õGš\í4›¨\ÚUŽ9\'K\è\âT$2:\Ím#‘ˆl2\ì§\âø*\×A\Ö,lügö‹\á\r\ÄM©\Ë}xò\Ý\\\Ìl<\è\Ù\Â5‰\Å\Óüª¡Á«€B¯‹ø[À(ñÈ¼>ðÞ¯\âf¡\î²\ìe¹ò\çö)\Ú\'\ÐÕ‹\ï…þ3\Òü/‰o|#®\ÚxrDIWŸM™-\\€Œ&+°†$`çœŒUKvö\Ûå½¿?µ¸£ek\ëÿ\0Ÿ\ä­\å{ž\Ññ\ÃM“\Äz\ï€/\Ç\Ã¶ðö©e¡\Ã­\áø\ï\ä“Pÿ\0B…\Æ–ibgR¯\Z¨_31ÅŽ\ây¯\Ú#À‘øRðþ¡a\á»O	Z\Þù²[i²Y\êVZ’ª2a®\í\ïf›i\ÉÂ´.Ñ¶\Ö\ç \çúOÂŸk\Ú5®¯¦x;_\Ôt›©…½½ý¦—<°M)}ER¬\Åþ\\œñÖ«ø·\áÏ‹<Ö«\â\ë>7[¾\Î5m>k_;n7lón\ÆFq\Ó\"Ú’kGvÿ\0\à|·\ÕY\ë¢_v—#ñßŒ¯þ!ø\ËZñ6¨°¦¡«]\Éy:[©XÕ‰!A$€;d“\îk¯ø ²\Ãÿ\0	Ö¡§\çû{Oð\Õ\ÍÆš\Èq\"9–žHû\îKg¹lŽF\ÒÝ«ó\á4ý[LÒ®¼\â+mOT\ÖSiS¤\×aFXÄ…78“´\n‡À\Ö>/³ñ_\Ú|)§\ê’\ëú8{§[Gš[t‰\ZD\npƒ8`\Ãn	\rÁ\ÅBJ1q[Y¯\Âß‡õaÝ¹)oª~º\ßñ=\Ï\à•\ç†\íü7ða5½\'U\Ô/dñ\ÅÈ±›O\Õ\"´ŽÝ§ó*=¼¦Q§\n\Ñð\Ï96“ð?Añ‚|O¬k’\î{¸5ýJ\ß^±²º\Ùk%³\\\âšé¯–”¼?\êV\ÖF1°9,Ÿ$\ÚY\Þkš¤6¶v²^_\ÞL#†\Ö\Ö\Ï,Œ\ØTDQ\É$€ø·m>ø\ÓPðÌ¾#µð†½s\á\èU\ÞMZ2w´EBC“(]€)O9§SÞöÑ«ú¨þV{®\Û\ê¿9?\Æÿ\0\ê\Þ$ø_ioðNñ—ƒ@0Áj÷Z·ˆ¬µ+k«\é$uù¬fóM\Älv\ß.9) >\ÖzôOiþñ\'\Æ\ï\êšÏ‡4ý\Z\ÓEøga¨_Mw<‹}\r\ÃÝ´\Ít$s\Z {p~D@˜6\ìn¯–®¼\âk/\Ûø–\ãÃº´¹.\rb[V\ÎV\ÉVb»\åX`\á>•“ccsª^\Û\Ù\Ù\Û\Ëwyq\"\Å\r¼^IŽUG$’@\0u\Í[|Ò·ý.\â\íÿ\0’\Û\æGØ³\í¿ß©ôkxGâ—‹¾#[iŸ¬¼U©Ø§\Û\ç\Ò4}f[ˆlu\È\áwŠ\ÖÑ²,Œ¨ [YHT#*E\ßøSºd³¥\Úü6+\ãxü>\×\Ïð\Ö9¯‰iþÚ°«˜|\Óx£\Èc7•\ænùC\ä\'\ç¯xÄž¼†\Ó\Ä\Þ\Õ|;u4~lPj\ÖRÚ»¦HÜ«\"‚FA•™g¦^j\Ý=­¤÷)kŸp\Ð\Æ\Î!p]\î@ùW,£\'Œ°\ë5moò\çø.º–\îÛ¿_óZ/\ë¯U¡ö.¡ð\ÇAñ\'\Ä\Ü\ë>¹\Öõ\'Fð\í¼~ðõŒú¸‚7Ó£È‘Ã¨A4‰$q‰ò\æ\rÁ‹+/’\ØøG\áj>&Y½Ô¼=-¾©s\r–›¬jW67@§\äI¡‹I¼P\êr§3•\åGS\ãZ>ªxŠ\â[}+M»\Ô\ç†¸’+8\ZfHnyPHU–\èZ¡M\êþ_Ÿ_\ÃÏ¨_D»[ðV>±ðNˆ/¾\è\Ö:,ž.\Ò4K\ÝR›^ñ‡x–ºL7H\×aÔ±gÜ‹*I*mYWb±r©ñ\åõ¦™ðwZR\ãÁ3øgO“A»™\Þ\Z\ÊñD\"³QÄ·\í ¸y¤d\Ä\ÊAÚ¾%¢‰û\Ü\Ö\Òÿ\0‡Å·¥ô\ín·bŽŽ/·ù§ø\Û^÷\è{\ï\Å‰\Þ=\Ò|\'\à\ê2ñ«\âÇ–?O5Ö§<\×H›l¢‰™\ËF\â&2¸$\Ü(<¨\ÆÏŒ5oˆþ0øµ\à_‡º\'ˆ5?ø\ß@ŽKs¨\ßÝµ\Ô\ÑjS){²’\ÈX €* e\åZu\Ã\×\Í4øa{‰£Š1ºI*Œ\ã$œ\n¤¯%e\Öÿ\0¢_vžvD½#¿K~­ýÿ\0u\ÙõN¯áŸ‰þ(ý ­t\ïG\âm\ÄvžŽ+\ß\ßi—VÚ\å´8YõV_´’\ÄyJS÷®¡PòÌµkÁ\Ú\Ä}{öƒñ¾½\áý\Å^\Óôû›mC\\µ³Ò¥Mb\âƒ-0\ÉtAv>Q,]\ÉT>jñ\'\Ãÿ\0øG\Ä\Zæ‰ªiSC©hòŠ,L¶£r¦\çx\Ë(]Î‹»8\Ëœ‘Pø?ÁzÏuŸ\ì\n\Ï\íÚ‡‘5Ï“\æ¤»Š6’FË8EcŒ\ä\ã&¢.Öš}û\Ý\ï\Ú\Þ[|´U%t\âü—\Ýe÷ù\ï·\Ï\éÿ\0‚\ë\á\Û9¼alºÎ‘\àÿ\0kðx‚=gCÔ¬/\ãŸJ³[;’–±„µt\n÷²|ÁöÁ\Zª“•oð\Ù>üT\Ó\ï&[\Þ\Î\Öò\Úe\r\åý½o\"ŽM\ÛHf†K¡‚3·q\Ç\Ë\\EŸƒ<A¨xn÷\Ä6º¥s Y8Š\ëU†\ÎGµ\ÉP\åj“¹x$}\á\ëZ¶6>+Ô¾\êsZ©o\éz”2^\ìh©‘’\"\ã\"I>X\Ü/\Þ	—\Æ\Ý\í¹8¤½_ŽŸžß©|\×iù·úµú?/K¯<q¨\ÞøLðŒ‚\ì­>þ\ãQ‰•šd™\"F\ÙÁP!\\g,\Ù\'Œ3\Ä\Öü+£\è\Z®©eö[\rzÙ®ô\é¼\Ô>%s6‰_™H\Ã\0xô¬«­6ò\Æ\Þ\Ò{›Y­à¼Œ\Ím$±•Y\Ð;!d$|\Êr8Ê‘\Ô\Z­Vÿ\0\é—\ÝoHò\éÿ\0ÿ\0\ç÷ž½û(\ÉuÆ«±‡R¸½]/V0C£\Êb½y?³nv¬Š\ÊN°V!°pzW´\r/\\ñ_\íð±/|\'®\êú«\ØZ®¥a¬\\_I®\èñ}½\Ô\Ý\Ý\Ý[<2ùª¬$uR7ˆ!U›\ãš\èt‡~*ñUÕµ¶‹\ácX¸º·k¸!°°–w–sJ¡–@\êT°\à0#­Swq\Ëÿ\0\ÛŸ\àKZIwVüWù—¢øn\ÇÁ>ñ\î«\ãŸI«ø“O\Öô\Û8¬|A5\å£B.\îI\ZTŽH\äb\Ë–%[$e[\Øþü\Óü+ñ†\ÂOx*/¥Ÿ\Ä>\ëP½¹¹øz\Ö\Ú\â!³Ñ¨‘Ã¹Vœ¸s\Zª©;ƒ|•¢x+\Ä>&µ\Ô\ît}S\Õm´¸¼ûù¬l\ä™-#\0’ò•Rp­\Ë`|§Ò›¢ø7_ñ$-6‘¡\êZ¤+(€\Éei$\Ê$(ò%Aù¶G#c®@j6ù/þE~iýö¿{«û\Æôµ\ÛüŸùþ±\Øø\Äz\Ç\ì\Ó\âF\ÇÁZ¼6kV³6±bš‡P¶U½3I2y†\Ý\ÖH\×\ÌXÁM\Ä\Ë\Ùñ?ƒü\Z\Þ\Z\×4›	\Ûiú–•\à\í_þ\Ûû}\Ë\ÜMuplÀ«\Ë\ä¬l.\Ø\ãfC†\0…_ž\ê[Wš;˜šÜºÎ®f<\î\rž1Žù«¹µ\Ù\ÛðVÿ\0ƒb¥;\É\Î\Ýÿ\0\'ù]|Ï±¼qð—Aøa\â	¦™\àO ·‹´\è,¼F–z\ÒµY~\Ñ5\É[I\'‘¶m•\ã*²À\ÚO3ñ?Oñ‹>8iz‹<\ã\ë½-\å¾_+\ÇZ\ÕÄ¨–Á³-Ý¬†Ä€Hs½\ÕÝ‘Áò|Gø‹\ã\r?\Ä\Ú\í¢\ÛÁò6¸ö^µÓ®w>\Ñy$F\Ì\Ûü\ÂR~`N23^eYk&›\é\ÅE~Ÿ}HK•4º\Ûðmþ¿‡S\é\Ý#\àþ‰7ˆµ\Ï\ì/\0\Í\ã\í\"\×\ÂQ\ßøzKV½Î¿p.­c–\é’¦YU\í\ã+\å„\ÚHq\æÿ\0x?Á^_\ê’x>\ÎúûI´\ÑK\è7÷_dÓ¯®#oµÛ±Žq3pFÆ—z:\íf;Y[Á4Ÿj\Zž­keq\äÁªÚ‹;\ÄØ­\æ\Â%ŽP¹ •ù\âŒ\ä`ü¸\Î	6©\ßK?\ê\ï\å³\í\ÓK-­g\ëHÿ\0“ûõmŸP|#øy\àø_Rñ9ðˆ¼C\rÆ³5¼\Ú‡¬.5‰ô{Qn›^;\ÛfŒ¾ùB\Ë4s©ò€#*\Ûù\ï\rü.°\Öþ\êZÍ—ƒeŠ\ê\ÚË©¼M\â[\rF+YbF`‹gu\ßf¡<©\ãÁr@‘‰TEWºZio\Ã\ëþGK_½ÿ\0\àùâ¯…ö°|±ñƒAhm­^\ëUñŽ¥mu$Ž¿5Œ\Þi³¸ƒgo—k=ox\Ó\áN¡¨j\ß\âñ_…µoøgP…l¯¢¸k\è­,\åkûc\ïd[´‘\">\ÝÀ|ûö\à\×Ì´U]^ÿ\0Þ¿\àÕ¿øý›y[þõ÷ŸSÁð¯\Ã\Ñj\Z-ÏŒ~ÿ\0\Â¨(\Ö\ä›Â«}{^\Ú\Ûi\ÒOøžI&LJ…<\Å>[\í\á~V\Ïy\á}[ñŸ\ÂK½Àö³/‰í£–\ãÂ¶:ŒðAu*\ß\Ü[ùI<ò¼‘	\Ë;I$b¼ZŠ•º}­ø^ÿ\0}\Ö÷\Û\î©k—Ÿ\çò\Ûm,}ðg\ÅÀŸ~\"Ý·‰üK\àž \Òa3øY\Å\Ï\Ü\Ô\Ä\Ü@\n|¼’Ç•_”õ\ïÁ¿‡žøû\âg\Å:Ÿ‚\Ú7ˆ|Q%”i¥\Ø\ÜK&“*9y¦Žö\Þu\"Qµšw8p\áPü{]_„~x«ÇšN§©\è:<º–Ÿ¥óqˆ\Ñ|¹$\ß)flOó¶ .r@$µNO¢Jý¾\ß\Îß}\ÉjýÞ¯ü\íùþ­:I­~\Ì6±\é\r¬u¨ô}cSŽÿ\0Tµ\ZŒ\Ò\éÀ\ÛYí¼—eÇ–Œû[—O+÷< ù³¡ñ\Ç\Ã~(\Òu;Y¼;omª\è~ðö§ý¼·w\âW1iÐ˜\Ên1,^U\ÇA}É\Ä£\æª)õ¿§\à­ý}\Å]]i¦¿s’—\å§\ã¹\éz„6ú…\ÌZT¾~—¬¶’ù&øA!{G6W˜\ã\'©Eû¢½W\Ó\äkÿ\0\\—ù\n±TA‡®ÿ\0\Ç\Ôõ\Ì3Xú\Çü}\'ýrÿ\0A±®ÿ\0\Ç\Ôõ\Ì3Xú³)»\0©$G\àÿ\0°=¨`P¢Ÿ”þ\ë\ß_ýj2Ÿ\Ýoû\ëÿ\0­R\Íþ>Ÿþ¹Iÿ\0 šž \ÒYE\ÙH&9\'ýƒ\íS\Õ-€(¢Š\0(¢Š\0|?ò\×þ¹Iÿ\0 \ZÆ­˜\å¯ýr“ÿ\0@5I\Ñø7\âˆ>\Ës&¨}\îL\r)òc“q†tž/¾§’4n:\ã ‘^ñðö\ëÁþ5ð\'ƒ¤ñf±§.¶º\Ýô‹F+Slò4wb\êEÞ¡cf‰¡\Ü\à\'\ï\É 5\â>ø]¯ø\ëL¾\ÔtÁ¥\Ãae4vó\ÝjºÍž’@\ìˆ\Z\æX\Ã1¹\Â\ç\îš\ÆñG†u/ø‡P\Ðõ{uµ\Ô\ì&k{ˆVT”#©ÁÐ•o¨$SR\ä’}Vß…ÿ\0OÁ‘(óÅ®þõ÷£\ê­b\ëE›\Ã\Úf¿«\Øx-</«iš\íö©ut¶-¬\ß\Ý=\íúZù –º\È#l‘\0¸\Î÷*Ÿ/›x‹\ÆñWÂ‡^\Z´ðß„ô\Ëû‹›¸%»÷ªúc<Ð¯žÁ\î\Ê\'˜,eR¸_”(xÖ¥y}oi\Í\Ô\×Y\Æa¶ŽY,]œª~U,\î\Øe‰\êMV¬\á\Ý~—oõ·\ÜkRNmµ£\Õý\ç\×ój¾#x\ÓÁ\Ú^‘«I­¦\ã:\Ê7Z°·‚9´\ÙDV\Æ8±q/\Úc_²E’U8˜’¿1\Ä>²\Òu/xv\ÃY\Ñ~_x±?\á ºM?Iþ\Îm6+$\Ó]­#º–Ý¼‚VhÝƒ\Ë)•B\îvS_\'iú…Ö“m}cs5•í´‹46ò\äŠE9WV«r§Xê—ºe\Ó\Ü\Ù\Ý\Ïipñ\ÉM¬ŽRD)\"’p\ÊÌ¤wA\à\Ó×•¦õ\×òI[¶ß‹\î%dÞšû[ýÿ\0‚\ì}	}\á/\Ç^,ð\î‹w\âo\nøgS]Y<Yu¡_i\ÖWanZH­b1´Vr\ÎS\È\á[f\à\Æ\Ø\áüu¥\ÞüRø\Ñ\â·\êžð\äò\Ä÷K-Î·Åš\Ç\0\Ç»€¼r\ÊQxû\Îpv’@òš)[·Ÿ\Þõü;Áø…¿?\ëc\èÿ\0€7^\ÓþIs>¡ø—\ÄT‘u+\ro]\Ò4\Â\Öb8\Ì\"6\Ôm¤;Y¼ð\Ílñ\Ê2Õ•\Íð\ãxj\ë\á“YÌ¾¶ñ\ÅÍ…\Úh\ÍrmIddR\ëu!Z\Þ³d”‡œ\ášÜ®·KøS\âgÂ¯\âKM5e\ÑR«†¹7P®\Ü\Ä&;†ùM\Ä#\É\ßò\ç~÷3òû¬¿¯\Åu}Ö—[ýú\ßúô]fñ\Õ×‚­~Am øwC\Ô-¥\Òl™uOøH4„\Ô-o‰Œ\Ü1µû2\ê|Á2iž-¹@P›|[\Å?|O\ãM.-;Y\Ôþ\Ùg\É:Göx£Ã¥¼v\êrªC\Z\ã8ùsÔ’a¾ø{­i¾\rÓ¼Qsœ:F¢Ì¶›µo´Íµ\Ù…·™\çlŒ7\ìÛ‘×‘Oñ§\Ã_|=‡I—\Ä:oöp\Õ!ií•§Üª±FªÅ£u`T£…`A\n%¬¤\ßWÿ\0ðý<‚:$—Eÿ\0ýý|ýG|*¼Ò´ÿ\0‰þº\×\n\r\r^\ÒK\Ó(%d2n¶\Ðs^›\áxot¿|_ð¾¿©\Ú\èþ4Ö¬\'´·\Ô5+¥¶†i¾\×\ÓFn„Ež%b¨Á€\'^w¬|ñ–ƒ­xG¼\Ð.WU\×\íc½\Ólb+,\Ó\Äå‚ˆIC•l«a†9Ÿ«xÅš‡ŒôŸ\r\Ë5¿ˆ5Û¸áµ³O\Ömµ5>H\ãó¡•\Ñ…û¥†\Õ\0œj­\Íeþ%÷\Ù?š¶\ß~\Â^\í\ßø_\Ü\Û_\'ò;_ø*\ê\Ó\Â<\'>­\á˜u«»}>Ku“\Äúj\Û\Ì\ã{¹3ù,Áy*#Ò»o€ú÷…¼¤øgLñ¯o§øŽ\Ã\Å\×\ÏcoªÁ-•Œÿ\0e\"š\éS>u«H¡K¤¨¸w0È¯³ø3\â»\Ís_\ÒZ\Ö\Â\Æ\ëB¹û£&§«\Ù\Ù[Á>\æQŸ4©91¾X’ˆ\È\Õ{„þ\'\Ô/üKa´Z‡‡VgÔ¬®uh.#‡2ùq¼¦\Ø#r| \Ø\Üf>Ë¾\Í_\äšw_†¿1òûÞš}\é«~?¡\Ë^Fð\Ý\ÏÈ®\Ê\Í+! òA^÷W¶M\àoø@\ìüIuš·º½¥Žƒw¦\éñÛ½Õ‰†Cö»\Ø\à8\Û$\Ã\×;w=Ì¿6U«\Ãk¥›\áÏˆ­üAªh’iûu=2\ÖK\ë¨<øÏ—qy®\á·m`#ù¾RIíš¥¤lúk÷oòµ\ïÿ\0\0²¿\Õ\éó½¿¦{\'\Ç\Ïx#\Ç\n´\á\í{Sv±\Ö\ïcÓ´½.o°\Ù}ž\Í2\îVU<‰6Ÿ5\ÌÄ… –\Èø;§\è\ß\r~.Ce­ø—J¹·\Õ|?q:¶‰¨!Ž\Òk«FÀXeùŒL\Íò\ÆÏ–\ÈS^]–¥ð‡\ÄúOö,w\Ö?l\Ö$‚+M>V\Ò[\Ò\Ó(h„–\É)–-\Ê\ÊA‘|\Ã\ÔP–w\Ó\ïVû\Þú\ß^\âoH¯\åýþå·¡\é›Mñö¹ð\ÓÁ¶w~ð\åÝ›ióK¤“izjIr\ï\nK|\"\ÊU|’)`\ZF^?\áƒ-¯.®\ÇÁ\Þ ‹K™Q¿\á#ñzu¾\á&DÐ“sM‡¦õ\Ã\r\Èrµ\Ãx›\ÃZƒõ\ë\ÍVmµG\Ù,k*J¼€AWBU”‚e$AŠË¢œ¹Zœ|\ß\Þ\ï\ëß­ü\î2p—’û´þ»hx7Ç¾vz¦—®XjM\áÿ\0\Zj\Z¬—¾$¿†\ËóIÿ\0i‹bQ\ï\'ò\âdŽ8—*\Ã-Þ«^W\ài´»-\Æz\Õ\Ü\Ò4]b\×T[m^-b®B²+,V©§­\Ãa$p¨\ÄÛ‚Ga\"®y‡„þø›\Ç\Ze\Íþc\r\Ì,—°A-\Ã$~d‰R:½ÃªaŠÄ®À2\ä|\Ã<•G*K“\Ê\ß&’}´ûµZÍ¯?þ\æ\ß\æÿ\0§©\îú\Ä\Zƒ~\Í:×ºî‰©jzñ\Ô\ÂoY\\\Ý%™µ·Šû?œdÀ)·\ÊÛ¹Bœ¨µ~3øŸ\Ãÿ\0ð¯üIº\Î\Ò\Ï\Å^,×­õ™\ím|Oo®¢m[ƒ$Š\Ö\è\ÝOµcwyH\ÎH\n|\çET½\ç\'Ý¯Ã—ó\åWÿ\0†´\Ç\ÝIv¿\ã\Ê\î\ß\ÕûŠò°ÿ\0‘oþAV?ò+ÿ\0Ç·ü{§ú\Ïúxÿ\0ž¿ô\Óuv_/¼8š\ìüO5·öwö}¾¡ö+‹±nÚƒ[\\$ŸeF\Ü´ƒ+ò|\Ã9+Ì¼+\á}OÆ¾\"Ó´\Z\Ûíš®¡2\Û\Û@dH÷\È\Ç\0nr}IŸ\âo\ê\Þ¸±‡W¶[Yol\á\Ô Q2Iº	Wtoò1\ÆG88#¸ª¿+\æ\îÿ\0X­Ì¹{%þ_#\êË6\Ëþ\Ýr\ß\Â/\à}fm\r4-6\ËYñ5Æ™5½½¼ƒPšMv\æ1²›£\Ã0\Ã|›\ã¥ø‘ðûG\Óþ2A¢øK\ÂúŽ™q{\ÓVò\âþ¿€Ý†Ø±¥\ÌG\ËM¡\ÕQT·~@\Å|\ë¥yŸ=„wS%Œò$\ÒÚ¬„E# `ŒËœP\î<íŽ¦«TI^n]\ïø\Úÿ\0Šü_r¾\Ê]­ø+K\è:—€­þCà«Ÿ5¾§«x~öþ[h`ô\Ø\ï\äu¹·W»k\Ñ\È\Ò\Þ†6Árœ]ñõž¢xhuM7Áv:MÇ„4fÒ¢±K\í™õY ´‘\ç“\Ë\Ýt€¯ž[\Ì\Ùp[åºµ}©\Þj“$×—s\Ý\ÍQÂ’O#;,q¨H\ÐxUUU \0À­\"Ò•\Þ\×ü5üu\Ñù.Áu§ý_\Ýüµ^o¹õ?\ÇM>\ËK×¼I£¢ø\Âú¸ñm¼o\Ícm>\n<¢i®¦¶%\áPL‹—Š¡5øé£xB\ÇW\ÑõMJó\àƒX¶\Ö\ì¯~\Õ<²«\Ï;-¼²4\ä¨E“UK1e_!\Ôu+½cP¹¾¿ºšöö\æF–{›‰’J\ìr\Ì\ÌNX“\É\'“U«(\ÆÖ¿\Ï\îKôû\Å\ÒË·ùÿ\0_ð\ç¹ü ðß†|ñG\ÅZN¿{\áÿ\0_i¶R&q«g—yt$qK›\Ø%¶ \Âf\Úfi#Œ>\Â:K[À\ßðŸø’\ë\Å:†´O	´ÿ\0ô;û\rN·(LI–Qªµ³#\ÜG\n¬`1E\'–\ÍUÿ\0-ú/\×úù\Ùô\r5óþ­ýwk©õW\ÃoøEô=[“T\Ñ|\â¿nOý­iÿ\0	…§Y\ÉhR6‡\ì­um$~S8ÿ\0Cx¤L€q„\Û\ä\Þ\0eµøgñV\î\æC¸³µ³¶W`\Ã\í\æò)!Ulr\ëwG#.î›«Ëª\Ë\êW’i\Ð\é\ïu3XC+\Ï«HLI#…\ê¹Àf€‘\É¹\è*mù%ú\Ãvesk¯{þ7ÿ\0\èj\ÝxO\ì¾°ñöÎ“7\Ú\ï%´þÉŠ\ëuü;[Í’,|±¶\ì+g’§Ò©ønÍ¯üA§[¤7-$\è<J\émm¤\ä|²\Ê\ÒFB\Û\×\0ý\áÖ³hª[ÜŽ–>¥i4\Ík\án…ª^xW\ÃGO—U¸ŸE\Ñõ[MSI‰Z5xK\\]=\Ô)-Ä‘˜Ï›$©X\ßb\ç\r7ŒõO\èþ6·\Ö,-|\røð=Ü³Z‡\ÒõKT\Õi–%+\r¼v6Áp€x#~w·Ê”Rwq\åõüS_¯\à­b•“¿§\à\ïÿ\0\Ó{ŸC|\'»\Ô|a\à¿kðiž_jiGy¯Xi6v´W‚O*)\Õ-\Ã02¡	l\ÚYC\Ë7\Ã\ÍnóÇºÆ¥i£DðŽºúÞœV\Ï	¨[J­\ZZ¶\å¢7)jV7\äG$ø\Zù\Ò=Jò>{\î¦K\äI¥µYŠG@Á—8,¡\Üy\ÛMZ›\Å\Z\ÍÇ‡\à\ÐeÕ¯¤\Ð\í\ç70\ér\æ\Ú9H È±ghb	€\Ï4\å«mi¦ž_\ëü\Ý÷\çýn¿\í\å\ÐúwÀ\íðò\ë\àÚ¾´<\"¿®7Ó™„v‰˜¯¼t…v\ÈùÁÚ¡—š8l\âø\Þ\ëÁ6m­t/\èz¬š]‰\Z¯ü$\ZB_\ÚÞ“¸cköe\Ôù‚d*\Ó<[r€¡6ü\ÓJ2xš¥ñ\Ý.«OOó\ï\ä;4\ßOø\å÷6ª5©þ	^x\ÃÄ°Å§Z\é\Újx\îÀMq&¥Å¼ú~o|\Óh[\Æð\ÛdE¼#\Éò˜þl€OŸ|kkoøC´„\Õÿ\0\á\rÿ\0„\Íu+“ÿ\0X±ò?³ö\'—\æ›Ü–ó›w~÷nwq¶¸¯üñg€t´¿\ÖôØ­ óR	–\ë{‰m%t.±\\\ÅŒöòBJŽ\Ö\ã\å8\ã\á…\î%H¢F’G`ªˆ2Xž\0¹¬¹n¹W—\åºöû›A{{\Ý-þ~ÿ\0z]?x§Tð•\Õ\ÕÎ“uöI\îm\'±•¼µ}\Ð\ÍŽT\ÃŒ«‘\È\Ï\Zõ¯øš÷\âÇ€> i\×zþ™k\ã]gU\Óõ9¤\Õ/mô\Èõ+h–dx„²\á^HdòÙ—vÜ€J\×>\røŽ\ã\Æ7\Þ³ºžoöE–ú(m¬\0\æ,÷”‰l\Â6%¶\ïùA$Š\æüQ\á}OÁº\ÝÆ“¬[}–ú¬Ê²$¨\Ê\Ê	WFVVWRU\rSi«>«ð½ôòºüÄ¯Ó§ê­¯¿C§ðö“>‡k\ã\Û—ð”“\Û\é»õ¨®œŸ´Cÿ\0 \ébfGŸ\ÝX/Ì«~¼uð¿[ðò¨“Uðû>½§\0¹w·*«{=ð«ÀvJ‹œ¿ü ñ_´¹5N†{E¸û$mq}ol\×Wwy\é,Š\×\àƒ\å\Ä¾e\ã\æÊÁ·\Óø>\ç\Äp¼ZY\Þ-•åº±ó\í™\×1»©q\Èu	\ÃFCm\Ên%³O{/óO\ïk\Õi}Fº5\ßô\Õ}ÉŸJx\ËPð?\ÙüQ\â\r_M—Ä·^ŠI$MR3\æýª\Ñ-š\Õc`\É	‹qQ—\á· \Æ­ \é©\ão‚Z·ˆdð¶Y\ím<G}£˜7h\ÌÙ¸‚\Ñömû7•ºB»q€ÍœŠù®Š¦\ï%.\Öü/§þM¯w©¾\ã‡{þ)—\è}\á\ßxW\Æ\Ë\á\ÝGT³ðf›®\Ãy®Ágf¶––6YKHN[¥U\ãó\ÚE\\i3\0\Õ\Ñk\Ö\ZŒš7\Z¯\Ã\ÝC\ÇV>hlSþ%‰¢ÁxuY\ÞXŠ\í[!*\Û;\ãxòÙŽ\å.J1ù:Š]\íþM_\Õ\ßW\Ö\È\Ñ\Ê÷\Óú½\í\è¶_?—Õ’\é\ß\nü@u˜5©¼1myo.”.Î“,6\Ñ=\äö²\ÛÜ½³£*˜a¡„Y‡÷d°Ñ¢\Å\á[\ÍsÇ–\àýG\Z¤A\â™N…y²bT\Äz}\Ùó6Áq5¡Y\Ï~S¢¥«ó>ÿ\0wKi\åo»G ––]¾ÿ\0?¿{÷\×\Ó\Ò</n\Þ:øa®xuBËªøyŸ^Ó°§sÛ•T½ŒøU†`A§ø¹õÿ\0|\\\Ó5fñ?†\çNŠ+o\n-”z\Äw\ÊñÞ¬6±-S<ee’\ã8c¸²£\Ë\ç\åŠ)\Ë\ÞR‹\ÚJß…¯÷~½Ä´q—g\Å;}÷þ‘ôô!u…\Z¯ŠeðöpH­<O„ï´¿3þ?§f-ƒ\ç?eòÿ\0x\Ð\Ý\ÅL\Í¿\Æ\Í¼aÃ¹<5ö¶ƒB“J{ˆC\'–³5¡yò\Âƒ\æ\Çvk\çš(wn\ëM[ûÿ\0Ë§“^\É}\ßÖ¾‹±\î?¼eŽµ\r^\æóMð6\ãM Å¢½þ›a§\é÷„g3D\ê¶fU€Ê¨dP\Ü\á\rv\Úxjoˆš\Ôv–^Í¦ið\ê\Z¼w: ³\Ó\ïö¤½­¦ Eµ\Ê_˜@P?w\"£a¾X¢žšyÁüõôZ\è.þð?+i\êô\Ôúg\áí¿†\ìR?°j>Õ­\Ä\×K\â[\Ï\Û\Ù@ó\é`\Ç\åIi\ãz#\'\Úm˜óC£®n\ë\â„lþ\êš=—„ü9u+xˆ¬\â\îü]¼B\ÞQ\Û\"Ý¯Î»¶—\Ë\É\å	&¼*Š‡Ç•ö_ƒ‹ý4\ívR\Ò\\\Þoñ¿ù\ë\Þ\È÷‰ž1Ô¼eðCÁSAq\à×³³Óž\ÏR··´\Ò-u8\'ó²\ãTK†7‰‰ˆl;œ¶Irp¾\èÖžø£ð§^¿ñ‡%•õô³{\à_MTŸi[¬€\"o—v	?)5\ä´V—÷œ–\í\ßúùÿ\0‘-s.W\Ú\Ç\ØZWŠ¾ø\ËÃ¾\Ô5ýSLžóU×¯õKK¸»‚\ÜE©Š9&Þ’\"E4ñG&ù#h³+U\Åd\éž?°\Ðþ6Y\Çg£xCÂ\á\ë\ë®&½\ÐukI\î\Ú\ém\Ýæ¶·K[l»\ÇªªP<Ü†$ü§EKIÉ¾ÿ\0ü.Ÿ/]–š}-ýos\Ö|3¨\Ì\ßµŸx¢]<MöM\ì\Ú8´60JÁ\Z\Úxþ\Çû€e…˜\Ç\Û\Ì’\Õ\ê_³o‡|1\á\Øg°ñ\Èð\é™|Dúf±§x‚\ëH³“O·EEyK][Ks fgM¶\Ï\Ã%\×v\åùRŠ>Í¼­ø\ßü\ï\äúX—«ü¿\Ë\îó>€ðå®uð/S‚VðÏ‡o\']JGÑµ+\ÍM·0Ž§\íöŒHTY\",¸\ÃlPZBž$·\Ñn¾\é¯3xsÃ“ZÁh>\Ãb\Ú.¥y«3:—“Îˆý¾\Ñö—vŽ]\éò\í\Ý\Ëxú\ß\Óð\ïùv\ëk\êSwm\í¿\ãýzô\ÛC\ì}zó\á´>2ðœð›xB=zÝ­5‡ñ>\ëû»‹hm\áº\n\êSq¼gdd\0¶\æ%­h¾4ðmæ¥ \Ý\Ú\Ûø\ÇUŽÉ¬q\Ø\é\Ð\ÜKq\á\É\Ép\ÊcPv\â2¥•¾_”“Ÿ‹¨¥öeýzôü\ì%¤”»+[§õ©ôÖ‘o§^|løK<·¾\r°\×4i-¯üO{¦\ß\éº~š¡/Ë®×£¶’U€Ç¸@Xžœ²¾9?†þ\Ñõ\rcÆžñOö`X#[\ZÆ<¦\íœ=\Äq\Ü\ÂÎ…^\ÚI¾P\Ø2¤J~n+\ÄkN\×\Å\ZÍ–ƒy¡\Û\ê\×\Ðh·²$·ZlW.¶Óºœ«<`\íb00H\âž\ËO?½»ýË·[X~O­¿þw~6=Áú§ü-MG\Æ6v2ø‰Î££YY[¬QA\æŠ\ÕpIM\åš2y¯Aðô>\ZñÇ„|\"u)ü3w\á\Ý#\Ã7\Ö:~­®g\ÞiZ’}¢a40ˆŒ\í;µ¿Ì©*Ÿº@)_2QR\Õ\ã\ËýhšüŸ\à»j\'\ïs[§ù¯\Å÷>ñV«ðõ~_x:É©\Þøv\ÇL»†Ù­\í\Ö\Âkˆd&ñ-®\Ö\åŒ\ÆO¶\Ü6\ß-s\åpNÑžö†\Ðg\Ö<w\â_\Ù\ë\Ú·\á\íVü\ÜXKk­\Ú\Ét-\ä\æ\Ú\Ï\ÌûD^ZmŒ«Fl\ÇL\ä£\áÿ\0j\ÞÕ \Õt=RóF\Õ-÷y7º}\ÃÁ4yR§k¡2	¡\"©û\Ò\æ{\êþû_òV\ì(û±\åþ´\Ûóm÷;\Ï\Ù÷\Åi\à_\ê^ ûU­­ÖŸ¢\ßKkö©|±,\Æ©\Zò71Ý€½ù\ë^¯eñ¼M¥h\'C°ð´ú]ÖŸ}¥_ø[\Ä!·±X4å¹¡‹\íO	?vŒH,U˜©…x\'‹>*x\×Ç–p\Ùø›\Æ\Z÷ˆ­!“ÍŠ\ßV\ÔçºnU‘ˆŒS\\µ\'\ïI7\Ñ[óÿ\0?\êâµ“·W\Ëü¯\ë\è}\r\à\ßø{GøÍ­\Ç\á¯i¡\Ûø~ö“XñŒb+».xº\\;B—Ag/Í‰vcpO;\á\ï\n\Ï\â?‚Ú§‡mu_C¬Yøg’\Þÿ\0\ÄVa£[gŒ¼o4È²®\î7!`s‘\Åx\ÝIsF\ÞI}\Ò\æ_Žžo©W\Õ>ßª·ü\ÐôŸ\Û7Ž>\ëž\n²j\Þw\×tý£,ö\åU/bp«Àt)Hû\ÜúgŽµMð¿WðMŠ%¼\Ôô\r3N¸µ­\í\Ö\ÆK¨¾\Ö-®\Ö\áŒ\Å\Í\í\Ãmò\×>W\íùªŠo]=\Ímò\ÛNú\Þ\âZ;úý\Î\ßðu\ì\ì}ñ4ñ·‡VUð’| þÖ´û8\Ðd\Ó\ßTûq¹1§o1\ï.&\é! tZ·6\rñ»EO§\ÃÀ\ßfGá›­\";?0F\ße[‰­\Ò@\Ìò@k\Ä~2\\ó|\çEK|ýuV¿ª\èÿ\0[Kz~£\ê½§eÔ´[ŒVR¯‚|)j\Ñ\è¯Û¼Sá¹­Œ)t†=<ÊªÁ<ƒYWw\rûÁƒ¬´{?Š>6´K¿	\ë°\Ê-¢Ä·øz\Ê+&e\Ü\æ:\íÍœ\à0(\Â\Ý\Ç\Üeþšh¡Y4ý\ê\ß~‰\r\êšôü?¯O-\ï\ï~\rð\ÜZÇ†þ+\éq\ê~¿°14}CQ›H\Ó.\ç»[\Ëc\æ[ù\ì“\Ã[‰ˆU\".YF[Š\éü;¬h\ïð›Ái¬¿‚\î<3c\á½V\rUn¦±›YûS\\Þ›XaBZ\ê2HZ%UÄ…ŠŽ>]¢¥«Ã“\ÓòkõÓµ‘\\\Úü\ïùiø~,öo\Zh/{ð\ÂWóK\à\Õ\Õlo.|\Õ\Òï´˜õ±x­·&•\Ãùùó¤_˜¾Oñ\Â\×\Ú_‡~-¶©\á[\Û\í>\È\éò\Åˆ4»\è\á¹}F\ît ™\ÐG²H\Ë<ƒ\Ë°\Är+Ä¨«nÿ\0}ÿ\0~¯\æO\ÙQòkñ¿õ\ä}1uª[|7ý¥¼\â´ø.-.\ëûjh\çJ½µ·‘\"¶\Ï\ä\Û\ïKv‰‘UC2õ…¤\é·>(ø¿\áOA\á›Ÿi“iöw\Þ‹M{[I¾i-§`<¸\ÛÌVF8q¶\î+Á+OHñF³\áû]F\ÛKÕ¯´\Û}Jm{\r\ËÄ—Q±\Ê€\ëþ\ËdRõ]ÿ\0\Ë\Ôw}?»ÿ\0’õóó\îzv‹\âmXø¡ªøv\Ý-tÿ\0k–\ÃÃ°\Íöub¦\Ñiy&\ÜfO:8¥‘\ÎI\r \èqW¾\ØxI±¿²ñŽ•e¬ø#V›Rš\ËPò£›TU‰•¬[pÌ¸¸‚\Ùóag˜\ã\0×ˆQK[o­·ó½\Óõ½\ï\ßm…¥ü¿\àYþ\Zyn}1á¯ˆ\îþ	øŸ\Ãq\ë\ÚÆ…<šObtkUŽûS{ûW/‹\Åóª,i–»#¸\ÉÜ­\âz_‡­´}@ñ]î¥¤\ß\ÙËª\'\Ð\âº\Ý~±Å±\Ù\ä‹,n	UlòAô®NŠ¸Ë’|ñ\ßOÁ\ßþ’\ØOÞ‡#\Û_\Å[þ©õg\í	\ã?7‚üqmay¤\ê)\âm~\ßV°¾·\Ôb¾¿¾#\ÍgžtG&\Ê4IR(\àuYöyWÃ¾øƒ\Âþñ\Ì\ZÇŠ–ù­¬¡’k/±X\Çy¶ð\Ü<\É,A\Ñ\ç+¼d¨‚k•ðÿ\0ˆµo	\ê\Ðjº©y£j–û¼›\Ý>\á\àš<©SµÐ†ƒƒÐ‘[,ø©\ã_Y\Ãg\âok\Þ\"´†O6+}[Sž\ê4|¹VF 2=Meû5\îÿ\0Z[OøV*^þ’þµ¾Ç£üj·Ð¾&übð\ä\Z/#¼}SK\Òm\ï5\Ïˆ\í-\à˜YÀ…\æ•&›ŒÉžQ÷/Í\Ç_\àÞ‰o\à_xfi´[\Ýz\ß\\´¿·¶\Õ5˜t\í7QX–h\Õ\äžGŒINþg’¬¯&õ#…a_<QV½\Ô\ÒþµM}\Í\Ã=E/z\×\è’ü,þó\Ö~)G§üWøŸñ/\Å\ZV½£\ÚX[\É&£¿“\ì’jy‘Q…´[~gf&M§iÛ’px¯að/¼\'¥ü?ð–¶%\Ò]4¿_èº”z†¡\Ú,\ÙþÑ˜­l‰&’\å\çB\Ó\ídTb>RŽ\Ã\äZ*9W³ö}?\à5ù=¿K§W÷ùÿ\0­\Óü\Ö\çY¥øz\ÛG\Ñô\Þ\êZMýœº¡‚}+­\×\ë[žH±ò\Æ\à•V\Ï$Júö„ñŸ‡Á~8¶°¼\Òuñ6¿o«X_[\ê1__\ß\æ³\Ï:#“e\Z$©p:¬ƒ{¼†+òhø\ÄZ·„õh5]T¼ÑµK}\ÞM\îŸpðMT©\Ú\èC‚AÁ\èHª’\çI=—ÿ\0kú\Åzz\Ú\Óu\ßú\ëþ3:½‡ösÔ„ž>Šðÿ\0öß‡L0øš\â\Ò9fûu£\àý©\ÖeTw\n\ä‚S•apöˆø¬\Ò,‡\âoŒLŠV:ý\ÞFz\àùžÂ¹\ß|BñWä¶“\Å&\Ö<Hö¡–\Õ\ï\åº1\Æ\à†F;sœuÀ¦›_×uO³O\îw> ´\×|}e\â]M›\Ä\Üh÷÷6©\Ûi:&£y\r«\Çpþf\è¢xa\Ùü˜J‰nŒ”8Z/ˆ´}s\ã÷Š¼z‡\Ã\r\á©õ–‘üA«Ec¨Ø S\ç]\ÙYÕ¥v\Þ]C[\ÌCnò\å-^N_ð\Ý•’\Û\ï²Ig—þ®ýÞ¾ž[ž\Ùmñ\Ã6?³\ÍÎŒ¾ð\å\î uÐ¡®.o’\îU\Ò¼h\Ò\ì\r\ê[h\Âùc8*I\æçˆ¯´½c\ázj¾/Ñ¼%±g¦iÖºÖ¯5\Åý\éˆÆ‚+\ËX®\ä\'\ÙÄ…‰Ž¨\É+^E7«o½¿o\ë\î\Ø–]¯ø»ÿ\0_\æ{?\Çh>,\Òü§\èþðÞŸ:hvŠ\×zm\åã½£y’–¶>m\ÓÆªn;Ô¸-’\ÜÕ‹\ïøw\Ã?¼\á\Û{}\'Ä¾ð\ÃEdó^O(³¸ºy®\ïU\á’2Fþ‹1\ÅAWˆQWrÏŸû\Î_ü;ü÷DJ<\Ð\ä}’þ¾\ï\Íl}\r¡ø²/þ\Õ	©h¿\Ø\Ò\â×¼ýFòq­-¯\íRùeyd’\î\é–B\ØV\Ù¶‚©\Å[øKc{£þ\Ð^%ó¼K X\èaï¦¹‘üSaÁš\Ú\åm™X\Îb\ØùË\Ûy¯›¨¬c¡vM}öÿ\0-\rœ›”¥Ý§÷_üÿ\0#\ê/\Ù\Þ=?Á÷\Þ–=WÀšuõŠ›þký~\ãN¹–+hš#\ì.òQŸ‰mrCa™\ÕB°\æ4‹½3^øbcñŽ›\áO\ìM/O\ÔIÕ­õ\ìk‰p\ÒK$‹4ºm\Ê\×2[\å±mã†¯¢®^ò³\íúZÿ\0\å\ÛÌ˜û»wO\î¿ù\ëä®üo\ã\ß	x“S°›I–\Ç\Ä°\Ò\ãi5®5¸m\Õ,¢²W\ßm&¥‘>vU*\ØeSŸñ\ÏEðm\×Ã”\Òô{	\Ýk\Ðk¶Všn§g©\è°\É}jð\Ì$žD³‚ou‹\"\æI?ˆ§,ÿ\0*QN^óo»üŸ7ù«öz\Ý\ê(û©%\Òÿ\0ŠKòKçµ–‡\Óð\Ç\áÛ{á¦«]xW\Ã73\êsM£\èú•ž§¤¤fxY\în¤º…&¸‘\Z#æ¼Šc}‹Ñ³þ*x£Âžø¡\à}[N³\Ñ\Ö\Ê\ïE6¾&\ÓôK\Ë+\È\Ê\É5\Ä3\Æ\Íeþo\Ù\ÊcFB0,~vùÂŠ7µú?Ñ¦¾w\×ð°l»[ñ½ý{~7>’øwk\á\ï\Ù\ïPñ%Ç‰õ\ëˆ5õ‹+K4\Òl¡½–\î\Æ6[¶‘¡’\â°N¢\Û“X`óŠ¶ú.“ \é>-±ð%×‚u-b\ß\ÄWµ\ï‰n4·ótŸ,Vµûq1[\Í.cý\è\"1À5ó½-]Zý?\Ëó·\â\×Q­ü\ïùþWû\Ò}g…bô\Öðºø<J`¼$mbM4\ê\Æo0ùb\Ýnÿ\0|\Èò¶›^K™3ó]gŽ®¼kðF]Ãº£o.“dWT> \Ò#\Ô-o‰Œ\Ü3Zý™u>`™\n´\Ï\ÇÜ (M¿6QU/z\ë»_¯ù\é\ØQ÷Z\×O\ë\Î\ìú?â…®qc\àû˜­ü#c\"\ê–\Öÿ\0ðˆX\Þh“G$A~y$\ÕlœH±*‘vA]û¼\É\n³>\'Û¬\Þ;ð•ç‡¯|«qö†þÃš\r›-9@\ÝÁ‹;\Ã~\Ó:£‚ƒ\ä\ÉR\ß;\ÑN.\ÒR\ì\ïøÀý­¥¼­ý^·>¤³µ³ð¯\ÆOŒ\Ñhw’\r[M¸}WK})Ñµ;gF\é~\ÎcFu†Cü(G&\ÛEÖ¾(xŠ\ÖÉ¼ºTž\Z6º¼\×r\é6Ö¯«fÊ¡\ìZ}\Úöüö¸L€\Ù\ØT\×\Ì4T(ûŠ¢·\æ¿_½\'Ðµ+6û»þ_\å§k³Ù¾ø.\èøc\â}¼š¯†­&¸Ò¿²m\Òó\Ä\Úu¹ž\á/\ì\æa™8Þ›\"r$\\£mÀbx£I\Ð$\Ö?g[\íø6;\Ë]J\Ú\ïN\ß¤\Û\ê\Æ\ÙR\ì]ó­Ôƒ‘ˆ\ß%¾]ŠEx\ÍOXµ\éø;ÿ\0^BO—O6þô—\äyø‘\ãMO\Å\ßüqo?ƒ$´±\Ó\Ú\×Q¶‚\ËH¶Ô o\çtTˆ\"\Ü1¼L|¡±·9l’\ä\Ðø\Ýÿ\0ö—¡\Ù]\è\ÚnŸku\ã1½%¼Vˆ¿Ù°ˆ‚˜!\Ê\æ%k“tp¸8\à\Ç¼f\Þ\â[;ˆ§‚W‚x˜<r\Æ\ÅY†r=\êÞ»¯\êž(Õ®5MgR»\Õõ;‚\Zk\Û\é\Úy¥ \0;Ç€\' ¥\ï]÷wým÷\Ûä­­Ø–\åo\ë\Ñ~.ýLðƒô\n|O²³ÕµŸk&%õ„­y\Ú`¾{V{hn^@±‚²\ìWY>@\ÃJ\æ½C\Ìþ\Öø\Éð6[\Ïø+\í¶·º\Ön4\ÍGM\Óôû@š´ò<caŠ\"£©+%ùe\Þ\ãò¥W\Õ>\Îÿ\0úU¿={\ÙouÇº·\åþZv»=·\àÿ\0ƒntßŠ![\Í_\Ã6‰k¥j–\Ïq?‰´\ä\ä¹\Ó\îcb”Ï²\\»ª“`„ü\Ûk„\Ðþ!ø¯\áŸ\Ût}\'U†\Ö4¼ie\â\Þ\ê6˜C-¹e”V_.iTb§vFHq´T\Ú\é.–·\Ü\ïù¿\È\ÖRæ“—[\ß\ï\ÜÞ±ðŸÛ¼ªxƒûgI·û\r\Ì6\ß\Ùs\Ým¾¸ó2(±ó¢\íù›#—Ö³4™=V\ÉÝ‚\"Ì„³\07j¥¤%\É55\Ò\ÆR4yYõö¡ñ\á×Š5\ï‰v:ÆŸ\á\í#Cºñ¶%\Í\æ—tój\Öb\î\ãÍ›ç¸”wN\Ý²j>‹Pð·ƒ\ì\à‚\\ý©<I\áË«[\Óö\'û4r{H\í¡\"P¦7º‰‰i9\ÜhùŠ\Ê1åŠõð¨þ…·v\ßø?\çø.\Ç\Õúÿ\0ü\"·ž${­1<\r§ø\ÓþÂ¶Zmôú=ÆÐ½ùškˆcM–f¶2m\Ìh\Z@¬`\Ðo´[‰\Z‹Y\é^	\Õ-Z\ÂÁudQðí¢j>Xó\Ú\Ø\ê6ó#E»~\ájr­·m|¯ET}ÖŸõ»vô\×n\é>„½o\çÿ\0ñ\ÓOW\Üú\ß\Ã\Ú\çÁ\Ï¼I¬A\á½fXüY¨j6R\ÚX\"\Ås’8!·•X¹ŽÕ¼Öœ,¬T-»wÐŠ\ßÁº}‡—o/€\çð8´\ÕZ{†³}X\ßy·³ÿ\0KÛ²yf\ß÷X\Éùhk\åz+7ÁFû+z\ém­\ìýnþû—wM[\Ó\ïüþ_Wøª/‡-ðU#±ÿ\0„L|Oû4\Í$2\ØýŒþ\æ\Ä\Ê \0mó¼¢vm;|\Ñy\å\å\0‡ZŸ\à•\çŒ<KZu®¦§Ž\ì\×jP\\[Ï§\æ÷\Í6‰¼o\r¶D[\Â<Ÿ)\æ\Èü­El\Ý\ÝþŠv–·›\'þ]¨z\ëýu=£\ã[[\Â¤&¯ÿ\0oü&k©\\Ÿø¢Å‘ýŸ±<¿4\Øþä·˜$Û»÷»s»µ\Î| Ÿ\Âvö>:“\Å\ÖCP¶]}’\Ú+¸m.ž\ã\íÖ¿ñ\ï,‘J@ža8F%ƒ€IuEg\Ë?ò·ü[²¯ªòwüoÿ\0\ÓC\ëÿ\0\Â\0¾2\×5-)|:ºtzN€–ú.«}¢ ;\ì\Ð\ÝJ\×7¶r£\É©¬0¬®ò€Wi¹\á\Ûƒ:O.n/‡/,-þ!_Z\éöHž,$òV)¦žm\"Q+.N\Ör£w\×\ÈTUK\Þþ¼\Óý=u~VžŸw\á\Öÿ\0q\ëú\ÄD²ø\'\â[i\áF\Õ \Ôl­,Z\ã\Ãúl—\Æ\ÖH\ï\rÁY+\á–\Þd²|€2\çž\Ç\Å_ð¬¬þ\êñiÿ\0Ø·¾*¼ð–p&\Êb¸I-RXb\ï\\¾gyH\Ë\n3Ì‚¾o¢”½\ëù\ÛðVü^¯þ	W÷®¿­Sý,zÿ\0\ÃH/.#Kˆc˜!d@\Ã9Ny®»\ÅúM¯‡n\ä†\Î\Þ)f\"U#\çQ\Ô\n\à¼®\Â>°\Üy~\ëený½vœ\çÒ·u¿ÿ\0lisYý‹\Éó6üþn\ìa\é´zS\Ö\äžs®ÿ\0\Ç\Ôõ\Ì3Xš·ü~ú\çþ€µ·®ÿ\0\Ç\Ôõ\Ì3Xš·ü~ú\çþ€µL\ntQEH4Ÿøüõ\ÎOýª\ÕU\Ò\ãð\×9?ô«UK`\n(¢€\n(¢€üµÿ\0®R\è±«fùkÿ\0\\¤ÿ\0\Ð\rcR`w\Z_‰4\ëƒz\æ…%\Æ\ÝV\ç^°½Š\ßc\Ð\Ç\Ò;n\ÆÑ†•	\É\ÝÀ\à\ã\é\èþ-XXÚ¯Š\ì~ /‡¼+7õ-B\æ\Ú+{¿´ë–©o`\Æ\Ù\"ÁVS\ïl]KgnW\âš(oW.ÿ\0ý¯ÿ\0\"…m—kþ7ÿ\03\éŸü_ðå…4\ï#ÅƒEð\Ü:^¡m«|=Ž\Òá†§w3Nc—\r¼ƒ\ÛþòY\ã| \íLù÷\Ä/Œ:¶±\áoø_Hñ^¬\Þ·Ð­-/ôh\î\çŽ\Ï\í)#³„ŒA\Øw`Œ\Ï\äôQFJ]šuÿ\0yþ_[úþ6üt\ß\ï>\Åø\Ýñ#I·ø…\â\r\Å~;›\Ä\Òx\Þ\Ú\â]).‘¼3go4¢\à\Æ\ÒD‹\ì$QþŽ1™˜¶\Ò\×5\Ï\ÚK\Â\Ö:×†uÿ\0øHôÿ\0k\Ú:\æÖ¶]b\å%I­\âKKv›Qg™\Ã7›¸eI|w?\Å\ÔVq£\Êüÿ\0£ù!u¿õ\×üúvG\×\ÑþÑŸ!Ð¼˜£º‡E]\ZO¦…örnÎš÷‘røò¼\ã(ùð$ d\æ¤\Ñÿ\0hO\n\Þx»RñT\'\ÂÚ­Æ—¥\Û%œ’\ëö‘\Ç™e‡\Z{FóK\Z-¸M\î\"!œ8#\ã\Ú*\ã\îòù;þ\æ\ß\Í÷bj\í¾ú~_ä—¢;ŒZÆ‘\â‹1\Õ4hwº½\ÕÅ‹E	…/+2„£p@\"±-üY®Y\égLƒY\Ô \ÓY$Œ\Ù\Çt\ë	Y\n`8\Ã\ã,1\Î\Å\ÏAYTTF*P[%b\å\')s=\Ï[ø‰\á½Zo‚_5\Ä\Ò\ï[DŠ\Êò\ÖMIm\Ü\Û$\Æþ\á„fLmG;sœWM©ø›ÀþÐ¾\Ü>³£üC>7¨hBú\Ð\Îd¸–xÈ’\â\Ì!E%OJ’k\ç\ê*\îÓº\Ó[þ\æCI«?C\é\é>:xPñw5u‡Q[\Ô\Ñõ[Nó\ÄwCSŽ\Úk¹oŠ´\É¤FP\Z\äH\Í £\ìYN\ì\Ë\ï‹\ÞðÄ›_J¶ñ>½{£6™¨xƒÁA<?\ïžFo&\'±\Ææ€¤.\â\ÉÀ\ÎK(¦½\Ù)/\ê÷\Ó\ÓW\ç\æSm\êÿ\0­µüªW\â×n<}ñ[S\Ðu«]kZ‚ò\Êo[\Ýj:m\ä4²L\ÞD6\ÇlŒ\Æ2ždE£RûdW;«–ðUªø»\â\ç\Åø^\ÃX¾ð¬ZF»3\êI,\æš\Ê\ç\Ë3\ÊÅˆ.\ÙÁ‘‹\åŽM|ÿ\0EgÊ”yWf¾õo\ën¡}o\æŸ\ÜÂ¾¢ñW\ÅO‡šŽ™®\\X]ÚŸ]x~b˜Mqw=º[\Ý[o1ta‰”œ -6\Öù¹ùvŠ\Ö2\åþºvþ¿+§6÷”»j}iûI|V}\\ñÎ—s\â\ë\ê§\Å\"\ãJ\Ò%\Óä¹´\Ðb€Î²#Eu\nÃ½ü\ÄVX–DrŒ\Î\Ä\í-\Îkü9\â\×^\'Õž\Â\çC\Ò,Z\ãMM\'HƒMº¼¼6±Ä©\ç\Çm¼—V”2¯•À\äóuŒcÊ¬ÿ\0­-]\n\í\åþw·é¥¬<\ã½_Ÿ\ÄZÿ\0„5ù<¨E\à¬.ïµ‰¦º–\ÂX5+H#\Ïoj™ …x¢Ü­ýÒ»ªõ¯Ä­h=\Õt‰\á)R\ë\Ãz}ßŒ®\"½Ž}JX­/i‘ ŠI\Ã\Ê\ÈX3g@C•.\Ê~A¢µ¿õÿ\0osÀ¶Þ¶\Ò-[%ÿ\0¶\î}¤ø«ÀšŸüuñ\n\Ç\ÅZ_…¼Gw©\\.a¬Y\ßG¬R©\rz\ßd‚e2\áŽØ·W%‰!B·‡\Ù\èú\Þ\Õu‹}z\Þ\æ­4Qe#‹¸˜7™/÷Sf\åa–\Ý\ÇJÀ¢³QQV]’û¿Ï¯®–\Ò\Î÷wóoúôý=oôÇŒ>4i7\ß¬¼=\á\Ý[Ã–:si–6Ï¢Ýs\íöwQ´Fi\âŒ3X+™Q\äó+²\ÈùÙM{\â÷ƒµ«ÿ\05þ¬u[=_µ½ñ\r»\ÚM³Å¬4’ø!\0oUIË›\ËÜ¯¿‰%”W\ÍVœ\Þÿ\0?ÿ\0þ\í?]\Òj-\îòù[ð·\ßýl\Ýý\ë\ã÷\ÆK\ß_xv}7\Å\Z&©u¥\Ü\\Og«x~\ã]7ö\á¶W›Rb\ê>PU\"bªwž7dø†¥«\ß\ëC%ý\í\Åó\Ã\n[\Ä\×2´†8aI\'\n£€ªQY\Æ<ªÆŽW=Ÿöoø‡sðûP\Õ\'O\é~\Z¶›\ÊZj—\Ú\í²\Ü`“½²ñ¹”dbSŸ€yÇ­|ø\Ù\à_	ø—_\Ô&ñŒ¶ºn¥\âë‹»\ÛMgûP}³Mm»-lv¯+–H·\0 P»PŒ£|}E\\½\íû[ñOôþ´3µ¯÷þ\r~¿yõ—…>9x{Mø)£øjY\Úi\Ñhº¥–¡£\Âú¸¿yfž\í£X¡û9\Ã,°ü\Ó\Ê`«*cÆŸt}Kàµ¯‡4\rCÃ‘i¥\Ø\ÛK\áû¿í¯·\Û\ÝFcó¥Š=í§«´ˆòyª\Ùd|ü\ÌÀü\ÓER—¿\Îû§÷6ÿ\0SG\'\Í\Í\ëø\Ûü¶~%|Z\Òô‹\Zö›\âÃ¯\Æ|d“\ÚZ\Çmx\Öþ\Z·„Î’\ä4*\ß\Í@\Â\Ýd±Ù˜¥²#ø™ð\ÛG¸ðõ½ÇŽ­u; [\ÞË¤\é÷\Å\àH¼>\ÖÀOob\Ó}\ÐBm\ç\ÑY(\Ú­¯ò·ù´’’\èšûÏ¥®>4xgûWHñn©\Ç\áG\Ã\Þ\rº\Ò4­\"\Æ+…¸Š\êYn\â…Re@»¢†t•\æg›‘–$\r¿üvÐ£ñ–¹\âkOg¯\\\é:»^jWz\Ôq]´6h—\Ûþ\Âñ\Ë,\ë\"\0¾kˆ\Û.Kr|Ej¤Ô¹ºÿ\0Áoól:5òù{¿ü\âÏ¥µ_Š\Z%\Ü\Þ?‹Àþ?·øo=÷Š¯u$\Ô#‚þ\Ô\êºtƒ@¯kÈ‹7• U>x9\Ê\Öf“\âO†ú·Á¯\riþ!›A¸\Ôt­/Q‚H¤MYux§y§’\Ü[€³e\Üñ1ó‰\à°ôó\å’ŠQ\å]’û•¿¯2œ›wóo\ïwp2=+\Ù~?x\Ý<d\ÑÏ¤xú=K\Âo:I¦x*!{\Ñ#ò°±ù/\Û)A˜\ËD\ìX’\ß\Äk\Æh«z«_\×\åÐž·;ÿ\0~+\Ò|ñ*\ËX\×7\Ó!´¾ŽH¥”\Éi4kòþpW*A³‘Œ×ª/\Å=\ë\Æ\Úî©¦øý¼96¥¡\Çm\á\ÍA\íncÿ\0„T	£v°DD\Æ<µ–15²¶\àû›i’@>l¢Ž\ß\×óþ“w_\×\âŸ\éý4šûOñV›^#ñý\Ä\Û_jº­…\ãñ\êK¨\Ý[›Y\ï®\Ã[Àò\r\á#P\Òy7±p§ \Ù\×> hþøƒ©ý“\â<>…¼Q7ˆµx-mo$#\Ón\Ò‹xp±bB\"iÁs\å\Æ\Zc\Ï,k\ãZ(\ë÷þ-7ø­¶W\Ø-¥¿­š_‡\Í\ï\ä}q\á¿\ÚGÀšN\á­$À\ÑýK»°†ù­™£Ó¡½’\á\î¢es°Ql‹´ý\ì\ß7?*\èz—ö.·§\ê¸—\Ï\ä¿\Ý}¬iö8\ÅQ¢ˆ~\î~\Ño{þ7ü\Ç+N<c\éoŽ_|3­x3\ÅZ_‡5KK\Û/\êñjiöv“\Å=©\r$³M,±¯›p\í\"¨X™\ã@´¨Àoø_\â/	üJð¦·©\Æ\Ò\é\Ún«kyrŠ¡‹G\Ê\ì\0=Nâ¹Š)SJ“N>_‡ü0Tý\ä\\e\Öÿ\0‰ô‚u-/\áo>!xk\Å\×\Zu\Ì:Ý¬r\Øk\Z’\Ï>r\Ë:\\\Û\Í0^Y •@|(9`\Æ\Ýø\é§ý¡ôñµö­­k2xŸH··\Ò\ìFœ–l‚þ\î\ßñ3Š\"‰I	c¶—‘²*<~X¢’VQo\Òú\é\Ö\Î\Ú[£Vi4\äù¥)=\Þÿ\0‡\á¦\ß-›¿\Öø\Ñ\á¯\Ûi\Í}\ã+\ÍÃºýÞ¢\Þ\"º±¼¸¸\Ô\íg1K+Y+\ÂB]\Èc1´—6‚¥eš¼¯AÕŒ>ø§\â{\Ô\Ö%J±µy2fºk\È.Ü¨\ãp†8þf\ÇhÁûõ\ätQË·’·\äŸ\ßo“\Õvwó¿\Í6\×\Ü\ß\Ího]hú$>°Ô¡ñŸ\â	¯%†\ãCû¯\Ù\àUR“y\ä\ímÄ°\ØFÜžµƒE]oý]E\Ð(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0\îô\ßù\Úÿ\0\×%þB¬U¿xoPñSZiú\\)qx\ÐXšdŒ°\n3\ì2q\Î8ô·üEð¿Ä¾\ÓZÿ\0V\Ó\Ò\Î\Ô0M\íuÇ \n’zœ\Ð\Ð\Z <\ç]ÿ\0¨ÿ\0\ë˜þf±5oøü?õ\Î?ýko]ÿ\0¨ÿ\0\ë˜þf±5oøü?õ\Î?ýh`S¢Š*@¹¤ÿ\0\Ç\àÿ\0®r\è\rVª®“ÿ\0ƒþ¹\Éÿ\0 5Zª[\0QE\0QE\0ø\å¯ýr“ÿ\0@5]”¡\ï£V”†ÁùMn\Û\è\Ð\Ý\ÜG1\Í4¬#Ž\Ì\ìN\0\0I=¨¢½;Äž>\Ö&\ÒõKd¼…ciX)tWÛœr@`8\È8$sZÿ\0ð©\çþ\æùþ\"¤\Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñÂ§Ÿûšw\äøŠ\0ñª+\Ù\áS\Ïý\Í;ò?üEð©\çþ\æùþ\"€<jŠö_øTóÿ\0sNüÿ\0Gü*yÿ\0¹§~Gÿ\0ˆ \Z¢½—þ<ÿ\0\ÜÓ¿#ÿ\0\ÄQÿ\0\nž\îiß‘ÿ\0\â(Æ¨¯eÿ\0…O?÷4\ï\Èÿ\0ñ\Êÿ\0f\ÚÏ¬?÷\ì…\0p”Wwý›iÿ\0>°ÿ\0ß±þf\ÚÏ¬?÷\ì…;\ÂQ]\ßöm§üú\Ãÿ\0~\ÇøQý›iÿ\0>°ÿ\0ß±þXŠ\îÿ\0³m?\ç\Öûö?Â\ì\ÛOùõ‡þýð¢Àp”Wwý›iÿ\0>°ÿ\0ß±þf\ÚÏ¬?÷\ì…„¢»¿\ì\ÛOùõ‡þýð£û6\Óþ}aÿ\0¿cü(°%\Ýÿ\0f\ÚÏ¬?÷\ì…Ù¶Ÿó\ëýû\áE€\á(®\ïû6\Óþ}aÿ\0¿cü(þÍ´ÿ\0ŸX\ï\Øÿ\0\n,	EwÙ¶Ÿó\ëýû\áGöm§üú\Ãÿ\0~\ÇøQ`8J+»þÍ´ÿ\0ŸX\ï\Øÿ\0\n?³m?\ç\Öûö?Â‹\ÂQ]\ßöm§üú\Ãÿ\0~\ÇøQý›iÿ\0>°ÿ\0ß±þXŠ\îÿ\0³m?\ç\Öûö?Â\ì\ÛOùõ‡þýð¢Àp”Wwý›iÿ\0>°ÿ\0ß±þf\ÚÏ¬?÷\ì…„¢»¿\ì\ÛOùõ‡þýð£û6\Óþ}aÿ\0¿cü(°%\Ýÿ\0f\ÚÏ¬?÷\ì…Ù¶Ÿó\ëýû\áE€\á(®\ïû6\Óþ}aÿ\0¿cü(þÍ´ÿ\0ŸX\ï\Øÿ\0\n,	EwÙ¶Ÿó\ëýû\áGöm§üú\Ãÿ\0~\ÇøQ`8J+»þÍ´ÿ\0ŸX\ï\Øÿ\0\n?³m?\ç\Öûö?Â‹\ÂQ]\ßöm§üú\Ãÿ\0~\ÇøQý›iÿ\0>°ÿ\0ß±þXŠ\îÿ\0³m?\ç\Öûö?Â\ì\ÛOùõ‡þýð¢Àp”Wwý›iÿ\0>°ÿ\0ß±þf\ÚÏ¬?÷\ì…„¢»¿\ì\ÛOùõ‡þýð£û6\Óþ}aÿ\0¿cü(°%\Ýÿ\0f\ÚÏ¬?÷\ì…Ù¶Ÿó\ëýû\áE€\á(®\ïû6\Óþ}aÿ\0¿cü(þÍ´ÿ\0ŸX\ï\Øÿ\0\n,	EwÙ¶Ÿó\ëýû\áGöm§üú\Ãÿ\0~\ÇøQ`8J+»þÍ´ÿ\0ŸX\ï\Øÿ\0\n?³m?\ç\Öûö?Â‹\ÂQ]\ßöm§üú\Ãÿ\0~\ÇøQý›iÿ\0>°ÿ\0ß±þXŠ\îÿ\0³m?\ç\Öûö?Â\ì\ÛOùõ‡þýð¢Àp”Wwý›iÿ\0>°ÿ\0ß±þf\ÚÏ¬?÷\ì…„¢»¿\ì\ÛOùõ‡þýð£û6\Óþ}aÿ\0¿cü(°%\Ýÿ\0f\ÚÏ¬?÷\ì…Ù¶Ÿó\ëýû\áE€\á(®\ïû6\Óþ}aÿ\0¿cü(þÍ´ÿ\0ŸX\ï\Øÿ\0\n,	EwÙ¶Ÿó\ëýû\áGöm§üú\Ãÿ\0~\ÇøQ`8J+»þÍ´ÿ\0ŸX\ï\Øÿ\0\n?³m?\ç\Öûö?Â‹\ÂQ]\ßöm§üú\Ãÿ\0~\ÇøQý›iÿ\0>°ÿ\0ß±þXŠ\îÿ\0³m?\ç\Öûö?Â\ì\ÛOùõ‡þýð¢Àp”Wwý›iÿ\0>°ÿ\0ß±þf\ÚÏ¬?÷\ì…„¢»¿\ì\ÛOùõ‡þýð£û6\Óþ}aÿ\0¿cü(°%\Ýÿ\0f\ÚÏ¬?÷\ì…Ù¶Ÿó\ëýû\áE€\á(®\ïû6\Óþ}aÿ\0¿cü(þÍ´ÿ\0ŸX\ï\Øÿ\0\n,	Ezw†ü|U¬C¥\éö–\Ïy2\ÈÑ«ª¨bˆÏ·8\à¤ñ’2@\æ³\î4hm.$‚{\áš&(ñ\ÉVFG\ÔXF¸–\Ò\Ú\Æx$xf‰#t’6*\ÈÀ#¡½t~.ñÆ±ã‹«yõkŸ9 ˆG\Z*…E\àn`£\ÌFIü8\0€ªB¨\n `\08´À\Ã\×\ã\ê?ú\æ?™¬M[þ?ýsÿ\0@Z\Û\×\ã\ê?ú\æ?™¬M[þ?ýsÿ\0@Zè¢Š.i?ñø?ëœŸúUª«¤ÿ\0\Ç\àÿ\0®r\è\rVª–ÀQE\0QE\0\\\Ò?\ä!üÿ\0A5\ßø\Å\ÓøÄ–Ú´ð\Ý4YWŠe2†\n\Ø%~9ƒ\ç\×\rk2Ê \\ý\î1W·gÿ\0žq~Güi\è\ß<Eg\â\Ïj\Zµƒ9µ¹XY|\Å\ÚÀˆP2‘\ê#Ž8\à‘\Íu_ð›h¿óûÿ\0Ÿÿ\0‰¯þÝŸþy\Åùñ£ûvù\ç\äÆ¦À{‡ü&\Ú/üþÿ\0\ä\'ÿ\0\âhÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMxö\ìÿ\0ó\Î/\Èÿ\0Û³ÿ\0\Ï8¿#þ4r =\Ãþmþòÿ\0ñ4\Âm¢ÿ\0\Ï\ïþBþ&¼?ûvù\ç\äÆ\í\Ùÿ\0\çœ_‘ÿ\0\Z9P\áÿ\0	¶‹ÿ\0?¿ù	ÿ\0øš?\á6\Ñ\ç÷ÿ\0!?ÿ\0^ý»?üó‹ò?\ãGö\ìÿ\0ó\Î/\Èÿ\0¨pÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMð›h¿óûÿ\0Ÿÿ\0‰¯þÝŸþy\Åùñ£ûvù\ç\äÆŽT¸\Âm¢ÿ\0\Ï\ïþBþ&øM´_ùýÿ\0\ÈOÿ\0\Ä×‡ÿ\0n\Ïÿ\0<\âüø\Ñý»?üó‹ò?\ãG*\Ü?\á6\Ñ\ç÷ÿ\0!?ÿ\0Gü&\Ú/üþÿ\0\ä\'ÿ\0\âk\Ãÿ\0·gÿ\0žq~GühþÝŸþy\Åùñ£•\îð›h¿óûÿ\0Ÿÿ\0‰£þmþòÿ\0ñ5\áÿ\0Û³ÿ\0\Ï8¿#þ4n\Ïÿ\0<\âüø\ÑÊ€÷øM´_ùýÿ\0\ÈOÿ\0\Ä\Ñÿ\0	¶‹ÿ\0?¿ù	ÿ\0øšðÿ\0\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~Güh\å@{‡ü&\Ú/üþÿ\0\ä\'ÿ\0\âhÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMxö\ìÿ\0ó\Î/\Èÿ\0Û³ÿ\0\Ï8¿#þ4r =\Ãþmþòÿ\0ñ4\Âm¢ÿ\0\Ï\ïþBþ&¼?ûvù\ç\äÆ\í\Ùÿ\0\çœ_‘ÿ\0\Z9P\áÿ\0	¶‹ÿ\0?¿ù	ÿ\0øš?\á6\Ñ\ç÷ÿ\0!?ÿ\0^ý»?üó‹ò?\ãGö\ìÿ\0ó\Î/\Èÿ\0¨pÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMð›h¿óûÿ\0Ÿÿ\0‰¯þÝŸþy\Åùñ£ûvù\ç\äÆŽT¸\Âm¢ÿ\0\Ï\ïþBþ&øM´_ùýÿ\0\ÈOÿ\0\Ä×‡ÿ\0n\Ïÿ\0<\âüø\Ñý»?üó‹ò?\ãG*\Ü?\á6\Ñ\ç÷ÿ\0!?ÿ\0Gü&\Ú/üþÿ\0\ä\'ÿ\0\âk\Ãÿ\0·gÿ\0žq~GühþÝŸþy\Åùñ£•\îð›h¿óûÿ\0Ÿÿ\0‰£þmþòÿ\0ñ5\áÿ\0Û³ÿ\0\Ï8¿#þ4n\Ïÿ\0<\âüø\ÑÊ€÷øM´_ùýÿ\0\ÈOÿ\0\Ä\Ñÿ\0	¶‹ÿ\0?¿ù	ÿ\0øšðÿ\0\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~Güh\å@{‡ü&\Ú/üþÿ\0\ä\'ÿ\0\âhÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMxö\ìÿ\0ó\Î/\Èÿ\0Û³ÿ\0\Ï8¿#þ4r =\Ãþmþòÿ\0ñ4\Âm¢ÿ\0\Ï\ïþBþ&¼?ûvù\ç\äÆ\í\Ùÿ\0\çœ_‘ÿ\0\Z9P\áÿ\0	¶‹ÿ\0?¿ù	ÿ\0øš?\á6\Ñ\ç÷ÿ\0!?ÿ\0^ý»?üó‹ò?\ãGö\ìÿ\0ó\Î/\Èÿ\0¨pÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMð›h¿óûÿ\0Ÿÿ\0‰¯þÝŸþy\Åùñ£ûvù\ç\äÆŽT¸\Âm¢ÿ\0\Ï\ïþBþ&øM´_ùýÿ\0\ÈOÿ\0\Ä×‡ÿ\0n\Ïÿ\0<\âüø\Ñý»?üó‹ò?\ãG*\Ü?\á6\Ñ\ç÷ÿ\0!?ÿ\0Gü&\Ú/üþÿ\0\ä\'ÿ\0\âk\Ãÿ\0·gÿ\0žq~GühþÝŸþy\Åùñ£•\îð›h¿óûÿ\0Ÿÿ\0‰£þmþòÿ\0ñ5\áÿ\0Û³ÿ\0\Ï8¿#þ4n\Ïÿ\0<\âüø\ÑÊ€÷øM´_ùýÿ\0\ÈOÿ\0\Ä\Ñÿ\0	¶‹ÿ\0?¿ù	ÿ\0øšðÿ\0\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~Güh\å@{‡ü&\Ú/üþÿ\0\ä\'ÿ\0\âhÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMxö\ìÿ\0ó\Î/\Èÿ\0Û³ÿ\0\Ï8¿#þ4r =\Ãþmþòÿ\0ñ4\Âm¢ÿ\0\Ï\ïþBþ&¼?ûvù\ç\äÆ\í\Ùÿ\0\çœ_‘ÿ\0\Z9P\áÿ\0	¶‹ÿ\0?¿ù	ÿ\0øš?\á6\Ñ\ç÷ÿ\0!?ÿ\0^ý»?üó‹ò?\ãGö\ìÿ\0ó\Î/\Èÿ\0¨pÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMð›h¿óûÿ\0Ÿÿ\0‰¯þÝŸþy\Åùñ£ûvù\ç\äÆŽT¸\Âm¢ÿ\0\Ï\ïþBþ&øM´_ùýÿ\0\ÈOÿ\0\Ä×‡ÿ\0n\Ïÿ\0<\âüø\Ñý»?üó‹ò?\ãG*\Ü?\á6\Ñ\ç÷ÿ\0!?ÿ\0Gü&\Ú/üþÿ\0\ä\'ÿ\0\âk\Ãÿ\0·gÿ\0žq~GühþÝŸþy\Åùñ£•\îð›h¿óûÿ\0Ÿÿ\0‰£þmþòÿ\0ñ5\áÿ\0Û³ÿ\0\Ï8¿#þ4n\Ïÿ\0<\âüø\ÑÊ€÷øM´_ùýÿ\0\ÈOÿ\0\Ä\Ñÿ\0	¶‹ÿ\0?¿ù	ÿ\0øšðÿ\0\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~Güh\å@{‡ü&\Ú/üþÿ\0\ä\'ÿ\0\âhÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMxö\ìÿ\0ó\Î/\Èÿ\0Û³ÿ\0\Ï8¿#þ4r =\Ãþmþòÿ\0ñ4\Âm¢ÿ\0\Ï\ïþBþ&¼?ûvù\ç\äÆ\í\Ùÿ\0\çœ_‘ÿ\0\Z9P\áÿ\0	¶‹ÿ\0?¿ù	ÿ\0øš?\á6\Ñ\ç÷ÿ\0!?ÿ\0^ý»?üó‹ò?\ãGö\ìÿ\0ó\Î/\Èÿ\0¨pÿ\0„\ÛEÿ\0Ÿ\ßü„ÿ\0üMð›h¿óûÿ\0Ÿÿ\0‰¯þÝŸþy\Åùñ£ûvù\ç\äÆŽT¸\Âm¢ÿ\0\Ï\ïþBþ&øM´_ùýÿ\0\ÈOÿ\0\Ä×‡ÿ\0n\Ïÿ\0<\âüø\Ñý»?üó‹ò?\ãG*\Ü?\á6\Ñ\ç÷ÿ\0!?ÿ\0^WXÛ³ÿ\0\Ï8¿#þ4n\Ïÿ\0<\âüø\ÓJÀnQXÛ³ÿ\0\Ï8¿#þ4n\Ïÿ\0<\âüø\ÓrŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GührŠ\ÃþÝŸþy\Åùñ£ûvù\ç\äÆ€7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~GühÑ¾øŠ\Ï\Â~8\Óõköqkl³3yk¹‰0¸UÔ’<s\Éš§\ãO\ã\\\ê\Ó\Û\Ãj\Ò\áR(T|¨3`lucø`\0ý»?üó‹ò?\ãGö\ìÿ\0ó\Î/\Èÿ\0 7(¬?\í\Ùÿ\0\çœ_‘ÿ\0\Z?·gÿ\0žq~Güi€k¿ñõýs\Ì\Ö&­ÿ\0‡þ¹\Çÿ\0 -h^^=\ä\Ü( mùÏ½2FŠf\r%´n\Ø¸–ÀÀ\è\ÞÔ˜\ÔV¾\Ûùô‹þúþ*¶ÿ\0ó\éýôÿ\0üU+SIÿ\0Áÿ\0\\\äÿ\0\Ð\Z­S\ãh¡b\Ñ\ÛF‚»cŒŒ­\ïL¦EPEPº\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øW«üÿ\0‰_‰õ?·	\á­*\çTF=<ý¾U¿?õ\ÞX\áY\ßð»þ#\Ðÿ\0\âü\Üÿ\0ñuý\éSu%N»[W¦¯§\ÂúYü\Ï\æ(Ö©\ZQ©V¼\×5ì–º+kñ.·_#\Î\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+\Ú~9x›W\Ô4\0\è\ÚÖ«}«\êz8\Ô.g\Ô.yD·m\ç,ÄœE¿Z©ðGW¾\Ðañýþ™{q§_A\á©Z+«IZ)c?j¶VR8\'¥BT^Ûº1¿m-½“½ºï±«uþ´°ê¼­¦º\Ýiw¥ú=7<‡þ\Ý\'þvøŸ\áGü#ºOý\ìÿ\0ð?Â½¿\Âþ±ñÖŸ¥\ëþ0»ñˆu_\ëŸØ‘\\Z\Þ+IX\âý\ä¦T‘¦\'\ÍP±‚œF\ß7¥/\á„µC·‡ûV-cRñ!ð\ßö\Ôa’\ÑYL;®B\Ü1Vœ\'™\Æ\ÎzTJ¦–T•\ÖöJ\Þ}¶ôôEFž6¤y\áYÙ«\ê\Ýü»\ïg\×\ÔðøGtŸú\Ùÿ\0\à:…ðŽ\é?ô³ÿ\0Àtÿ\0\núÃ¿	|\â­kJh†»¢\éM¨jp\ê7q¼\ÍökVœJ’%¿\Ê2ºùnW#“Š©¬|/ðŸ‡\×^\Ö\å‹[\Ôü=k˜l­¬\ïcI¦û\\l\Þq\íÿ\0\Õª\î…‹.BA¬`y¹=–¶_eu|©v»f¯\r˜F.~\×M~\Ó\è®\ß{/\Ïk\Ýÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\á]Ÿ\ÄOC\à\Ïk:%¼ò\\ÁepcI&P²cƒµÀ\à8\Îzƒ\\\ízT\èaªÁT5f¯²\êyUqº3•9Ô•\Ói\êú\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£E_\Õpÿ\0ó\í}\È\Ïë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øV}Wÿ\0>\×Üƒë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øV}Wÿ\0>\×Üƒë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øV}Wÿ\0>\×Üƒë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øV}Wÿ\0>\×Üƒë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øV}Wÿ\0>\×Üƒë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øV}Wÿ\0>\×Üƒë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øV}Wÿ\0>\×Üƒë˜Ÿùù/½™\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ£EU\Ãÿ\0Ïµ÷ ú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’ûÙÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ4Qõ\\?üû_r®b\ç\ä¾ög\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øVtlô\ÍGÇžµÖ™SH›P·Žì»”_(È¡òÝ†3\Ïj™aðð‹“¦´òCX¼Lš^\Õý\ì\ã¿\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+\×<]\ã\\x‹R\Ñ<bš¼ºŸrEÇ‡mf°\Ù;PB\ÇnT±ò	\Å]W‰>ø@½ñ\äŸcñ4ö~¼³²Ç¨À\Ò]4\Í(g/ö`\"Q±06¿9\Ä\nùüøx(¹\Ñ^öÖ³Z¸¯.²^Z\Þûž³§Š”¦¡^^ë³»ke&û\éh¿=-mž\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+\èi¾\nøgAÖš\ËPmsV[\ï¿‡\ìÿ\0³¥Š\'´\ÂDÛ¦7Iûð<µ)\ÌOós\ÆnµðoGðÿ\0\Ão›«\Íb\ê\à\Ïf¶\Ö3F\'SC\Ã\å¬ˆr]\Ü\r\é\Æab0\åµ5\ï4—ºµoú\ëa\Ë\r˜\ÅIºÝ»~ó\Ñ\'oó\Ú\ç…ÿ\0\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øW³|Xø[£ø/\Âún¡§\Ï2\êK¨O¥\êvr]›¥‚\â(\ãfQ\'Ù ”»\Ì^˜\×[\à=Z\ë\Ïð‡„|W|ú\Í\Õö§§\\\Ùh·’\r2ŒK´ü¨\Óù‘er¿“€J®\Øûjt“Z\ée{-\Ú\Ñô\×{yÝ“\ZXµ[\ØÕ¬\â\í½Ý¯\Ñ=SZ\éµ\Ó\è|\Ùÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\á_EG¬x»[ð\ç†<Gq\âk\íWX\ï\ÓRñ,\ÓH.£\Ó\Òx2d_\Þ7\ïžX\Ô)\Éûœ(8ò_ˆ\"·ñgµ\Íf\Ò\Ûì–·×’O%UX+1#p^7§dšÚ„hÖ—+£/{kf­²\ß\Íleˆ•j\æU\å\Ò\É\Ý]5{üOm¿Sÿ\0„wIÿ\0 ]Ÿþ§øQÿ\0\î“ÿ\0@»?üOð­\Z+¿\ê¸ùö¾\äy\ß\\\Äÿ\0\Ï\É}\ì\Îÿ\0„wIÿ\0 ]Ÿþ§øQÿ\0\î“ÿ\0@»?üOð­\Zõ\êZ§„þ¶»\ái§\ÓõG\Õ\äµ\Õ5[)sm•[\Æ$_š$‘Œ\ÙÁ\Ê\0s´\nÂµ\Z¢š¥\ÛKd–¾vþž‡E\nØŠ\Óqud’M\î\Û\Ñ_E\ës\Ç\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+\Øì´­Äžñ?‰<Gg®M\â‹;‹X\Þ\ãûF(b\îD¥%tkfnj\Íó“&\âr¹\Í]ñ\Ç\Â}IÄš~³ý³\á\íF\×M–k\Ùcxu)%Ü¹‰51Sr©i2„œŒs\ËÏ„Sös¤“½¶Vû?‡½v\ÑÛ­\Ã\á\ícYµk\î\Óû_¹.½7\Õ_\Ãÿ\0\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+\ê-\á_´¿\Ø\Íko©^Å§\ë\Z¦™5½ôð\Þ\Çy-¥Ÿœ†8\Ö$4„\r€sŠ¤ž	\Ò>)µŠõ}_Y²\Ð\ÓF»»6:•×˜ð%½\ÂD	 µa¾f\È	m„\Ø\ëŒ|Ã—\ëx;§\ìW-·²\ë{+w|¬\ëúž=+:Ïšöµ\ßF“m\ék9/]m±óWü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…{Šü+ð¦¥}\á\ç\Ò5k\ÍCK\Õ|Vº ¸°»Gl\ÇnøQ‹«Lë½‘Cm`\Î+3á§„m›\Æzµ\ß\Û4°t·\Ù\Ù\êÚµ¯\Ú\çˆ9\ÑYT\îP»qóŠ\ëSÁ89{4¬º\Å//–½ö8\åO—µn\î\ÚI¾úù­\ä?ðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþõN¡«\\\\|Jø…ðü]\êº]Î¯«\ê7Íªhz²,<™%\Ìq£y±€\åó®\æ\È\È\"¾g§„ö•wF+Hµ³º’\ßné¯ñŸX\Â;*òz\Ê/ug\ëÙ§ó¶¦wü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…h\Ñ]ÿ\0U\Ãÿ\0Ïµ÷#\Ìú\æ\'þ~K\ïfwü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…t>¸¿³Ö¬®tÁ!\Ô-\åY 0\Å\æ:²Á‚sŒgð¯{ŸGƒ\ã—“Qñ£«\é¥õ{wñ²¦=GÌŠ\Ø\\\Ü~û0!\ÚF×þòA„8‡õ|3NT£Ë­Ý¶²okywG£„ú\Ö.ñisie}\î\Ò\ÞþwÙŸ1ÿ\0\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øW¼\Ùüðõ¼\Züú²\ë\Z4ú]Æ¡©jV—sZ[Å¶\ì\Û\ÆS}”“`±E+\ä±,Ä‚fµu€~ðþ“\â\íZk\ÍOP·ðþ¯ygöicŽ\æ\êŽ.\è\ÎÝ†m\Ò>Ó…_¸3‘\Ï,N_\Êé®«\á[§ky;\Û{n™\Ñ.e%uQÿ\0\àO¬y¯\æ­}¯ªhù\Çþ\Ý\'þvøŸ\áGü#ºOý\ìÿ\0ð?Â¾ý—ü;ü%úgˆEÞ’÷ð\ê–öv¶š´2€\äy³ˆ¥‘Yö¡*%\Ü÷0`\Óuiµß‡>\"ðZ\Ýj\Úcx~\Ö\ïPžK\rYe\Ó/H¸C¶XcL99\n’yŒ2«ƒ\êT\ÃÆ¬©FŒ_-¯¶—½Ý­\ÓO[ùFž&¥Õ•i.k¥¾­l¯}/®ûZýOÿ\0„wIÿ\0 ]Ÿþ§øQÿ\0\î“ÿ\0@»?üOð­\Z+\Õú®þ}¯¹G\×1?óò_{3¿\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+FŠ>«‡ÿ\0Ÿk\îAõ\ÌOüü—\Þ\Ì\ïøGtŸú\Ùÿ\0\à:…ðŽ\é?ô³ÿ\0Àtÿ\0\nÑ¢ª\áÿ\0\ç\Úû}sÿ\0?%÷³;þ\Ý\'þvøŸ\áGü#ºOý\ìÿ\0ð?Â´h£\ê¸ùö¾\ä\\\Äÿ\0\Ï\É}\ì\Îÿ\0„wIÿ\0 ]Ÿþ§øQÿ\0\î“ÿ\0@»?üOð­\Z(ú®þ}¯¹\×1?óò_{3¿\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+Fº\ïƒÿ\0òV¼ÿ\0a»/ý•0øxA\ËÙ­<‘p\Åbe%k-|\ßùœü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…}mu\åø\ãRðü÷\×^2ŽcX·´—\Ä\Ñq%\ê\Û+\ÛÙª•^\ß\ÌXð\Í!RŠ\Ï\âw\ß~\"5á»ºñ?ˆ\"¹³™¡Y\ÍÔ±½«6wDŒ1·˜\×\0\ì|£nT±:FŒS\ë6\Òû7\é\Ùn·=|U:\ØW\ïb$\Õ\ì­\åký«u\ÓW³\ÚÇšÿ\0\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øW±~Òž\"Õµ¯Œ#·\Ôu;\Ëû{\Ù#µŠ\ê\á\äH\ã+bBŽ+Ë«·\rJ…z0«*Q\\\É;Y=þHóñU«\á\ëÎŒkI¨¶¯v¶ò»ü\Ì\ïøGtŸú\Ùÿ\0\à:…ðŽ\é?ô³ÿ\0Àtÿ\0\nÑ¢º>«‡ÿ\0Ÿk\îG/\×1?óò_{3¿\á\Ò\ègÿ\0€\éþ\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü+FŠ>«‡ÿ\0Ÿk\îAõ\ÌOüü—\Þ\Ì\ïøGtŸú\Ùÿ\0\à:…ðŽ\é?ô³ÿ\0Àtÿ\0\nÑ¢ª\áÿ\0\ç\Úû}sÿ\0?%÷³;þ\Ý\'þvøŸ\áGü#ºOý\ìÿ\0ð?Â´h£\ê¸ùö¾\ä\\\Äÿ\0\Ï\É}\ì\Îÿ\0„wIÿ\0 ]Ÿþ§øQÿ\0\î“ÿ\0@»?üOð­\Z\ë¾C¯\Ü_x°¼ºm…«]Gg[Éƒ¢¤?C¸“\ì§<f°\ÄR\ÃÐ¥*ž\ÅJ\ÝUß’:põ±8Š±¥\íœo\Õ\É\Ùy³€ÿ\0„wIÿ\0 ]Ÿþ§øQÿ\0\î“ÿ\0@»?üOð¯¢¿j(<&\Úõ\ßöt_\Ùþ%°¹‚\Ö\ê\Ý,w0½¿˜²€;¯Ê‡\ê3Ú¼KG†^\Æ+£¶\Õ\çe9\Æ°\rúf¹2\éañøh\â=‚ú4¿\ËT÷L\ê\Í\'-\Ä\Ï\í\Ü\Ôz¦ÿ\0\ÏF¶k¹…ÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\á^ÿ\0ñšûQ\Ôü;\âT\ÖZG:O‹\åÓ´”›8¶·\Ë\æ[ÅŸ»¶\Â•wš¼F·\ÂÂ†\"Ÿ;¥òO¢{\Ùwû\Ìqs\Ä\ájr{i=úµ³q}_U§•Œ\ïøGtŸú\Ùÿ\0\à:…ðŽ\é?ô³ÿ\0Àtÿ\0\nÑ«zN™.µªZ\Ø\Â\Ñ\Ç%Ä‚1$Í²4\ÏVf\ì rO`\rt\Ë†„\\¥¤¼‘\ËN.¤”#RM½7f]Ÿƒlõ”Z\èp\\˜ci¤\Ú+l~ó\0\îj¿ü#ºOý\ìÿ\0ð?Â¾¾ñ—\áŸÙ§Á­iqö\ZMó\Ç079Àu‘sÿ\0ý¶õ\È\Ã#\å‹Û¦¾¼ž\å’8ši\ZC(“œ*Ž\0\à•\âe˜š›Jt¤¢\ÚZ÷\Ò\ÛL÷s\\6#*T\é\Ô\Ä7U«\Ê)¿w¶·\ßþðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ\ì¾øƒ\âŸ|*×¤okL¸Q¡Xi\Í{)¶O0„{¶±¸\ÇYó\Ôf¼®½ZTh\ÎSR¥“·G~½—\ë\Ôò*×­BJ´›’¾\ïN\ÝõO·\âg\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øVmx/K\Ó5¯iv:Æ¡ý•¦O0I\îñŸ-¦NO9<\nÒ¥5(J¤©«%}#}¼¬gKŠ­R4\ãUÝ´µ“K_;™º_Â¹u½Q\Õ\ì<3\rÖ›§\à\Ý\\Gl…c\Ïá“\É\Æp98ÿ\0\î“ÿ\0@»?üOð¯»¼S\á»_j^Á«­ö\Ù\áM%$©\n@ò“Ÿ˜\ä`;gkK“ž•ó—\Çÿ\0\nhžñE£iAl//m\Å\ÍþˆŒ$\Zt¬\Øqƒ“À\éŒô W\É\åY®0¯\ì”®ã¢½•þ/»F´\é¾ÿ\0c›\åœ·\íc^M\Æ\ÊZ»]Ù®_¿Tõû[m\ã\ßðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ\Óhú5ž§g}5Î½§\é2[¦\è­\ï#¸gº8\'lf(A\àœ¨ù‡=Hõ­SÀžµ\Ðnu\ï]ø‹Y[-/Bx¡Šþ4sö¨´bG‰ö¤aÀ\à\r½÷/\ÒVXZ2Qt“¾ŸV\ÒV\ÒÛ¾úu>^‡\×1rWd›øž\Ë{\ë\Ã^‡\Ïÿ\0ðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþ\ï:\ÏÂŸø~\ëÅ–C\Ä\Z¦‡¨\\y¶p\êp\ØIŸÂ³m’\Ý\Ä\ÌApÁ …rk½o	øboŒ#†\rB\ÓA³ñVe6ƒ\äB\Ê\å\å–e\Ü\Ñ6\ì]«„ ðd¾|¯±X4”£E4\ÕöK¬R\Ó}y•´ü5;£…\Çk\Í]¦·oT¤Þ»iË®½{\è|“ÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\á^\é\Ã=\Å\ZÎ‘6Ÿ¥emªxÉ´µ\Ç+C!%”¬J7fIùp\0ž¾\ZxK\Åð\ß@·³»\Òfž\ßR–÷P£½\Äv\Ó\\–R©o¸»°­ó”\\.\Éæ¥ˆÁA&\é.·\Ñid\äÿ\0\'°,&>NIVzY/y\êÜ¹W¥\ß™óGü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…wô\ß\riz\ìqøWT:¦šö\ê\ì\Å\ä“Ê—$4~d@_ lùK÷±\Î2{¹~ø_O\Ó\Þ„Ö¥Ô¬ô_\\_%\ÔIi<rùL`D0’‡l¡R\î¯\Ü\ç®_TŒc)R·7NUu\ëýzPXÊ•%N5›·^gg}­\ëøu±\áŸðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþìŸ´Æ¨—ÿ\05«h>Ø–šs ¹¹$(Dq€xŒŽy9«\Öt}BóJ‘o®\ít¯\\iÖšòI·™;rdFñY# \Ë4g8<\å	\á=…:\Õi(ó«\ìžÿ\0.\Úú\'\ØÒ¤q~Þ¥\nUœ¹/Õ­·{\í}>k¹\á¿ðŽ\é?ô³ÿ\0Àtÿ\0\n?\á\Ò\ègÿ\0€\éþô­\àO	\éÿ\0ð–A\áj[¬t[—¾²Š\æcó\ÇunŠ“4––û‘·±1„;Z wœ\â¥ñG\Â\é:¦¹mö·§Zxw]²\Óõ+û\ÉcœKm?™½\Ò8\áŒž^:¾\á\Îùk(\â0N×£kÿ\0w]\Ò\Û\ÖJÖ½\ï}\å…\Ç\Æÿ\0¾½®¾-.“–÷\ì\ïm­¹ó\×ü#ºOý\ìÿ\0ð?ÂøGtŸú\Ùÿ\0\à:…wü7o\á~8,¬å´°¸·K›f“R‹P\ÆÄ*\Ëq­ƒò”¸!€<V½*t0\Õ`¦©­|‘\åU\Äb©MÁÕ–žoõ3¿\á\Ò\ègÿ\0€\éþ¯\ÂÛ‹\êñxFY4¬\æù4\Â`Ú¤†>fÝ¸y\ã¡¯~øAñ¢\Ëþ­\áÞ§ö67&\â\ÑõK[†ŠH\ÚY\Ä\á\Ã3«v\Æ\Ó\È\Ü›™¯©\ÑUpøx\Î\Ï]‘³mþžTþ»]\Ñ\Ä\âe­Þ²ºI~;ž¢ü-¸ñ2M¤øF]R(\Ûc\Ée¦•[Á*§‘ÿ\0\î“ÿ\0@»?üOð¯¬\æñ¥·ìµ§\Øx^7—\ÄZœ\â[»½\Ó0†!\Ä)\Z„\Ëm,qœy\Ê\ã\å\Ñ\ØVYeHfu=„U?°\íñ+´Ýºmø›f”\ç—*t–\"N¯Ûßº\ìšWZ=\ß\Üg\Â;¤ÿ\0\Ð.\Ïÿ\0\Óü(ÿ\0„wIÿ\0 ]Ÿþ§øW\Ð\Þ*øgðó\Âòx¼ù~&¼Oj6ö3/Û­\ã7~x“O\ÞV\Ã\êGž\'µýŸô8u\Ïiz…\å\Ô\"\Þ\ëP¶\Ño>Õ‡¸6\Ðˆh\Ù\Ãm=\Ì\Ò\Â>c·$Wõ¬/;¥¥¯ð­¬Ÿà¤Ÿ§šv…„\Ì\\\Ô][·\Ä÷÷—\ç½|šo\ç/øGtŸú\Ùÿ\0\à:…ðŽ\é?ô³ÿ\0Àtÿ\0\núKá¿|ý­ \ê\é—~$Ò§\Óî£º¼mR-o„’¼Mjö\Û\ã*Uö±gRBº±\ÚV¹»‡>	±øei\â\íf\ãO\Õ5ˆ.\îô»Y&–M¢)ž4€„´)+˜g3C·x;0>m=¶\Ú{?c\Ûì§«\æ\èµZE½z¨c]5QW\Þÿ\0i¥e\Ë\Õé¼’Ó¯\ÌñøGtŸú\Ùÿ\0\à:…ðŽ\é?ô³ÿ\0Àtÿ\0\nôoŒ>\Ñ<\ã\íO@\Ð\×P6út†\ÞIµ	\ÒG•Á\É`5\n0@Á\É8\ÎFvŽ\ËÀ?t?|;¿\Öõ/ˆ¾\Ðu\×]\Ún‘wªÛ£8|\ì¾c-\Ðdu5¬ª`iÑyÁ(\Ê\Ö÷{\í¢O\×Ë©„)\æ+\Ï\n\Ê7¿½e¦ú¶½<úÿ\0\î“ÿ\0@»?üOð£þ\Ý\'þvøŸ\áZ“\Â\ÖóI-&7¹0$\î\r2»þ«‡ÿ\0Ÿqû‘\ç}sÿ\0?%÷³;þ\Ý\'þvøŸ\áEh\ÑG\Õpÿ\0ó\í}\È>¹‰ÿ\0Ÿ’û\Ù\Öx7\âðŽ‘­\é’h:^»e«ˆ\Äz‘¸RL]B´F@,A “‹\éV\á?Ð¿\èšø_ÿ\0u_þM¯\Î*U¯\Îe\Å\å\'/«´\Þö¨×—D~¥©¨}e4¶½8¿>¯»?@¼i\â\Û\Ïxžû\\¿Žnn\ÙIŠ\ÙXE\Zª„D@Äªª džfZj7zz\\¥­\Ô\Ö\Ës‚u†B¢X\ÉQ°~eÊ©Á\ã zW\Â4\Ó\ï[G‹c¨,6‹û\ßý©„¸.R›©,V¯[òÿ\0ö\Ç\ßú\'Œ5\ï\r[^[\é\ZÞ£¥[Þ®Ë¨¬n\ä…\'\\‡\n@a†aƒ\ê}jö\ç\Øc²û\\ÿ\0bŽS:[ùå¬„\0\\.p…Qž¸Ò¾¥\æõº7rXm_÷¿ûPÿ\0R¥e­h¿»\ß´~„\Ý|Hñm\î³g«\Üx£ZŸV³R–\×ò\ê4ð)’Ü ‚x¹¤µø‰\â»-z\ë[·ñ6±µtž]Æ£ü«q2ñò¼·0ùW‚„zWçº­-Gú\ÕJ\Öúª\Ú\Ûô\íð\ì_úU»¼c\Þÿ\0ß¿Ç¹÷D²¼ò<’;I#’\Ì\ìrXž¤ž\æ›_\rÿ\0\r5«_õ\Â\ßóÿ\0“ö¦‚.\îñ?ù\'ÿ\0l}\ÍE|0´´ÿ\0\×ú‡ÿ\0É¿ûQÿ\0¨ÿ\0õÿ\0’ö\Ç\Ü\ÔW\ÃkG\ËOýpÿ\0¨ü›ÿ\0µúÿ\0Q?ù\'ÿ\0l}\ÉE|7\Í-\ë‡ýCÿ\0\ä\ßý¨¨ÿ\0õÿ\0’ö\Ç\ÜtWÃ”Sÿ\0[ÿ\0\é\ÇþMÿ\0Ú‹ýHÿ\0¨Ÿü“ÿ\0¶>ã¢¾sø3oiÿ\0\ï‰n¦Ó´û\Ùã»±Š6¾²Š\çb²]\n$V%8þ\è®\ÓÍ¶?ó\Ð?ðIgÿ\0Æª?\×ú‡ÿ\0É¿ûR¿\Ôú‰ÿ\0\É?ûc\Ö(¯$cf\ßó\Ðÿ\0ðMiÿ\0\Æ\ê?.\Èÿ\0\ÌDÿ\0ÁE¯ÿ\0¥þ¹\Ô?þMÿ\0ÚýFÿ\0¨Ÿü“ÿ\0¶=~Šò.\Ëþ€º/þ\nm¿ø\ÝG©i:dc\Ä{t}-|—\Ò\çŒÿ\0\ÙûÀùxVó+÷Nö\ã“Kýrÿ\0¨ü›ÿ\0µõþ¢òOþ\Øö:+ä¯‹Yø\îò;kh-!6ö’yVñ,q†kX™ˆU\0’O½r5\ë‡ýCÿ\0\ä\ßý¨¿\Ôú‰ÿ\0\É?ûc\î:+á¿––Ÿú\áÿ\0N?òoþÔŸõ#þ¢òOþ\ØûŽŠørŠ?\×úqÿ\0“ö¡þ£ÿ\0\ÔOþIÿ\0\Ûq\Ñ_Rÿ\0?õ¿þœ\ä\ßý¨©õÿ\0’ö\Ç\ÜTWÃ”Qþ·ÿ\0Óü›ÿ\0µõ#þ¢òOþ\ØûŽŠør‘©®õÿ\0“ö£ÿ\0Qÿ\0\ê\'ÿ\0$ÿ\0í¹(¯¾ZÁ¨|Fð­­\Ô\Ü[M«ZG,2¨dt3 *ÀðA‚\r{Gkÿ\0@=ÿ\0–üj¥ñ¿\æÿ\0&ÿ\0\íF¸\Zÿ\0óÿ\0’öÇ¬\Ñ^K\æZº&‚>š%§ÿ\0\Z¤Í™\ë¢\èø&µÿ\0\ãt¿\×/ú‡ÿ\0É¿ûQÿ\0¨\ßõÿ\0’öÇ­\Ñ^C¶\Èÿ\0\ÌDÿ\0ÁE¯ÿ\0¤ò\ì¿\è¢ÿ\0\à¦\Ûÿ\0\Ñþ¹\Ô?þMÿ\0Ú‡úÿ\0Q?ù\'ÿ\0lzýó\ç\Äû;6ð\ÜÇ¦\éö·\êvñ¬¶–Q@\ÛZ+‚\ÊJ($Šp}wž&‹O\ÓüIª\Ú\Û\è:pAw,Q§ö-¡Úª\ä“OŸú\ãÿ\0Pÿ\0ù7ÿ\0j/õþ¢òOþ\Øôz+\É\ÚKFÿ\0˜&ƒÿ\0‚KOþ5M\Ýgÿ\0@Mÿ\0ÖŸünõ\Çþ¡ÿ\0òoþ\Ô?\Ôú‰ÿ\0\É?ûcÖ¨¯$\Ûd\æ¢\à¢\×ÿ\0\ÓZ+/úh¿ø(¶ÿ\0\ãt®?õÿ\0“ö¡þ£ÿ\0\ÔOþIÿ\0\Û»Ex‡‹¬\ìfð/ˆ\ä\ZN—°[\Ã$r\Û\éðB\è\Æ\ê$2 #\åf{\×\Ñp\Û\èú†ükk\à\ïº7…ô;‡’\ëÂšmÄ²K.™m,ŽòI;³;³Ä’I©|eoù‡ÿ\0É¿ûQÿ\0¨\ßõÿ\0’ö\Æ±ý¡aÿ\0Bo¿ðŒ\Òù\Z\Þ\é\çþd\ïÿ\0\á¤ÿ\0ò5/õ\Íÿ\0\Ð?þOÿ\0Ú‡úÿ\0Q?ù\'ÿ\0ldQZŸjÓü\É\Þ	ÿ\0\Â?Jÿ\0\äzO?Mÿ\0¡?Á?øHiüGú\æÿ\0\èÿ\0\'ÿ\0\íCýFÿ\0¨Ÿü“ÿ\0¶3(­;«Yðß‹­\î<!\áEðÎµp’[x_N‚X\ä‹M¸’7I#YY]REx/„a²³ð…\Ýt\"yn-f–Y®´»y\ävw	wB\Ç\nª:ôš\ã+ÿ\0\Ì?þMÿ\0Ú‰ð7ýDÿ\0\äŸý±\ìôW”›‹Sÿ\00Mÿ\0–üj™º\Óþ€šþ	­?ø\ÝWú\ãÿ\0Pÿ\0ù7ÿ\0j/õþ¢òOþ\Øõš+É¶Ù·]Cÿ\0Á=¯ÿ\0¤ò\ì\è¢ÿ\0\à¦\Ûÿ\0\Óÿ\0\\?\êÿ\0&ÿ\0\íCýGÿ\0¨Ÿü“ÿ\0¶=jŠó=\ÇM½\×4\ëy´=\âš\æ8\Ý²m†T°g\Ëô®W\ám½œ?¡¹}/L»¹—Uº¦½\Ó\à¸}‹\r±UDb\0.\ÇûÆõ\Ãþ¡ÿ\0òoþ\Ô_\ê?ýDÿ\0\äŸý±\î\ÔW•™­OüÀôüYÿ\0ñªik2?\ä	¡\à–\Óÿ\0\Òÿ\0\\\êÿ\0&ÿ\0\íCýHÿ\0¨Ÿü“ÿ\0¶=ZŠòr¶Gþ`šþ	\íø\Ý]ˆÿ\0˜.‹ÿ\0‚‹oþ7Oýpÿ\0¨ü›ÿ\0µõ#þ¢òOþ\ØõŠ+\Ê<«ú\è¿ø)¶ÿ\0\ãuŸ\á3N±Ö¾$•\ÒtÉ¾Ë®\Çmn·6Î°\ÆZó*Š\êB‘:÷E?õ\Ãþ¡ÿ\0òoþ\Ô?Ôú‰ÿ\0\É?ûc\Ù\è¯-óm?\è \à’\Ïÿ\0SKY·üÁ4/ü\Úñº?\Ö÷ÿ\0@ÿ\0ù7ÿ\0j\êGýDÿ\0\äŸý±\ê”W”\í²?ó\Ðÿ\0ðOkÿ\0\Æ\é<»ú\èŸø(¶ÿ\0\ãt­\ïþÿ\0òoþ\Ô?Ôú‰ÿ\0\É?ûc\Õ\è¯(ò\ì¿\è¢ÿ\0\à¦\Ûÿ\0×–|V´·³ñ\Í\äv\Ö\ÐZDm\í$ò­\âX\Ð3Z\Ä\ÌB¨\0d’x\é®/»þþMÿ\0Ú‰ðM—û\ÏþIÿ\0\ÛUQ_Ò¨•\ëoý8ÿ\0É¿ûR?Ô¿úˆÿ\0\Éûc\ï-S\Ç$\×4{]\'Qñ©¥Z\íû=\Õ\ì’A\ÕÚ»˜ª\à\0â·¼=ñ{_ðÞ\â(­5-J-kX¹¶¸}jù#¸O(J3oòw»\ß5ù\á´zQ´zV\âJS$°\Ê\ß\âóOù{¥\ë\Ô\è‡\nV„¹\ã‹w\Û\áòkù»7n\Ý¼4¿x‹D]Et\íT°]G?m·’F.³œù»Xoû\Í÷³÷­Ck\â­j\Æ†\ÛW¿·…m\ä´X\â¹uQ„´‘\0\ÜbI+Ð“\Í|+´zS€\è*ÿ\0ÖˆkþÌµþ÷\ËùLÿ\0\Õ\Zšµ=?»óþn\çÝº÷<Câ¨ ‹Z×µ=b(?\Õ%ýä“ˆø\Ç\ÊŽ8ô«ZÄ¯k\ZJiwþ)Ö¯t\Èöl²¸\Ôf’Ù˜B\ÛF\Üq\Æ+\àŽ=¨\ãÚõš’ú²\Ómvÿ\0\ÉGþ¨\Õ\×ý©\ë£÷w]¾#\ïÈ¾)x\ÒbmZ?k\Ñ\ê“Ä°\Ë|ºœ\Ây#!÷n*@N+V\Ö/õ\íF}CS½¸\Ôo\ç;¥º»•¥–CŒe™‰\'€:úW\Ä4qN<M>h\á’~¿ý¨¥\Â5&¹gŠmoðõÿ\0À´è¯‹(¯ú\Öÿ\0\ç\ÇþMÿ\0Ú˜ÿ\0©Ÿõÿ\0’ÿ\0ö\Ç\Úu©\á\ßk~¼{½X¿\Ñn<§ŸNºxv–B	\0\ã\ØW\Ã¿\ÃS.*R\\²\Ã\Ý‹ÿ\0µx9Å©Gf¿»ÿ\0\Ûp\Ükú¥\à¿\Z•\Ü\âþQ=\ç™;7\Údˆy2~v˜\ä\äü\ÇÖ´\Ï\Äo0\Óñ>²F–1aÿ\0	¿\ÑÝ¸‹\æù>_—\å\ÇWÁŠ£Ž*EÒ¡ñ59o†_\Ëù{i\è_ú¥R.\ëÿ\0ðŸów\Ôûr\×^\Ôì£¶K}F\î¶¹ûd\ì¢)øý\ê\àü¯ò¯\Ì9ùG<VŒ\ß¼Sq\âµ\é|K¬I®Bž\\z›\ß\ÊnQpF\Ñ.\íÀaˆÀ=Ï­|!‘\éúSöû\n§\ÄÐ–¯¾þûý\\%R*\Ëÿ\0ð\ßöñ÷Í¯\Å\ï\Ø\Íu5·<Eo-Ô‚k‰\"\ÕgV™Â…\Ü\ä?\Ìvª®O8P;VGŠ¼Mw\âÿ\0jzõ\àŽ;\ÝB\å\î¥;1c·$œd÷&¾\Ú=.\Ñ\éS$¥	s\Ç“\ÛG\ÓO\îù.«R“\Å6¯{8õ\×_‹ÍŸt/<Lº~£b<E«-JFšú\Ø_K\å\ÝH\Ø\Üò®\ì;–\É8…_\Z`zQ\è?*\Ö<O|8{\Û\ßý©”¸Fs·6%¿ûwÿ\0¶>Ë¢¾4Àô•ƒò«ÿ\0Z¿\é\ÇþMÿ\0Ú™ÿ\0©\ßõÿ\0’ÿ\0ö\Ç\Úz~£w¤\ßA{cs5•å»‰!¸·\Ç$nC+A\î+WRñï‰µ­R-OPñ­¨\ÃA\å\Íô²L‘°`\È˜¤33ƒ¸ú\×\ÂûG £hôœ¸š|\ÒÃ¦ÿ\0\Åÿ\0ÚšÇ„g\ËKKü?ý±÷.“\ãoh[I¦kÚ¦%´O\riy$F(Ý·:)VU›\æ pO4±ø\ã\Äp\Þ%\Üzþ©\ÒN\×K:\Þ\Èfe\ÒÝ\å@R\ÝH\0W\Ã?…”ŸSm·†Zùÿ\0ö¥.¨•–)\Ûü?ý±ö•ýÎŸ{\r\å­Ä¶\×p¸–;ˆ\\¤ˆ\à\ä2°\ä{ŠÐ“\Æ\Zü\Þ]MoR}\r_\Ì]1®\ä6Á·\Ü\"\Î\Üä“œu$\×Ã»G¥\'\å\Å•œ°÷·÷¿ûRc\Â3ùq-_û¿ý±öeñ¦\Ñ\éF\Ñ\éWþµÓü›ÿ\0µ3ÿ\0S\ê#ÿ\0%ÿ\0í²è¯Œ9ô¥þ”¿Ö¿úqÿ\0“ö£ÿ\0S\ê#ÿ\0%ÿ\0í³¨¯Œ‡¥\"ý(ÿ\0Zÿ\0\é\ÇþMÿ\0Ú‡ú›ÿ\0Qù/ÿ\0l}ŸE|cøRþ­ô\ãÿ\0&ÿ\0\íCýLÿ\0¨ü—ÿ\0¶>Í¢¾2ü)?\n?Ö¿úqÿ\0“ö¡þ¦\ÔGþKÿ\0\ÛgT\Öw—\Zu\äV“\Ému¬±O”x\ÝNU•‡ ‚W\Å……\ëUÿ\0\å\ÇþMÿ\0ÚýMÿ\0¨ü—ÿ\0¶>\åñŒ5\ï]Cs®\ëz–µs\n\ìŠmB\îI\Ý9Â—$žx§ø‹\Æþ#ñ€·\Zö¿ªkb\ß>Oö\ä—Vq»\Ø\ã8=|-\ÅVk‰¡[´\Û]½=\ÓW\ÂUe\Í|S\×w_{S\í}CQ»Õ¯f¼¾ºšö\îf\ß-\ÅÄ†I½Y‰\É?Z¯_\í”„Šµ\ÅI+*ù7ÿ\0jdø5\É\Ý\â?ò_þ\Øû>Šø¼¸ô¦’3Gú\Ùÿ\0N?òoþ\Ô?\Ô\Ïúˆÿ\0\Éûc\í*+\â¿ÂÂ—ú\Ùÿ\0N?òoþ\Ô?Ô¿úˆÿ\0\Éûc\íJ+\â®=(\ãÒ—ú\Ûÿ\0N?òoþ\Ô\ê_ýD\ä¿ý±ö­ñM­¿ô\ãÿ\0&ÿ\0\íCýKÿ\0¨ü—ÿ\0¶>Ö¢¾)lzS[\ït£ýmÿ\0§ù7ÿ\0j?õ+þ¢?ò_þ\Øû\×\Ç1½ñÿ\0Šou\íF+xo.öoKUeŒlP`1\'¢ŽýsXUñ=7Â³§\ÅQ¥Ó†\É+%\Í\ÑÛ¦\Õ8:u§*•17”\Û\å\êÿ\0\í\ã\î\Íc\Ä\ÚÇˆ£³U\Õoµ8\ì¢Z­\å\Ë\Ê Œc‰Ú¼Vm|L>”\Úq\â\Åh\á\ì¿\Åÿ\0Úø-\Í\ÞX›¿ðÿ\0ö\Ç\Ûu§\á¿^øOZƒT\Ó\Ú5º…]WÎdB`AXŽ}k\àüûSªjq\\jÁÓž\é\è\×7Gÿ\0n—OƒgJj¥<MšwO—f¿\í\ã\îmKT»\Ö.\Å\äòO&Ð‹½‰Øƒ…E\ÏE€\0UJø—wÒ’ª<W\ZqQŽ\É{ÿ\0µ&|*’sž&\íÿ\0wÿ\0¶>\âkë–±ŽÉ®%k8\äi’Ü¹ò\Õ\Ø(f\ÐA=HQ\éPWÄ¹ö£>\Ôÿ\0\ÖÔ¶¡ÿ\0“ö¤ÿ\0©m\ï‰ÿ\0\Éûc\íª+\âe\éJ«óU­¿ô\ãÿ\0&ÿ\0\íEþ¥\ÔGþKÿ\0\Û¤þøû¬øc\Ã#Lk;]Fú\Í4R\éCÍ§+®r\àŒw\ÈÀ¯5ººšú\ê[›™^{‰œ¼’\ÈÅ™Øœ’I\êI¯ˆHö W \Ã\á§:”p©9o\ïöºw²\ë®\çv#…ñ8¨Bl[j;{¿ý¶½®õµ–\Èûf´n<E«]Z½¬ú\ä\ÖÎ\Æ\Ð\ÉpìŒ±\"R	Á	\n?„ŒW\Â\Ô0ùºWS\â\Ä÷\Ãÿ\0\ä\ßý©Æ¸2Q\Ûÿ\0’ÿ\0ö\Ç\Þ÷<Qw¦\ßi\Óø“W›O¾“Î»´’úVŠ\âBA\ß\"\Ã7Ê¼O\Ê=)—¾:ñ.¤\Ê\×~!\Õn™D 4×²¹\"\Æ!\Ëf+ý\Ý\Ç\Í|¿Juf¸žš\Û¾ÿ\0þ\Ô\Ñð…W£Å¿üÿ\0¶>þ·ø¡\ã+;\Ëû¸<[®\Ãw~\È\×sÇ©L¯pPaŒ.@\àg8J?\Zø†[[hõ\íM-\í.¾\Ýo\n\ÞHŒ“\ç Ý…“$üÃžO5ðqi6\â’\âzKl*ûûÛ£|#U\èñoÿ\0}wû]O\Ð\Åø>¤\Í?Š4‹_ju5\ßj\Ïc¤jc¹A´\Ç–<\Ö%ÇŒuÛ­=\nMgPm\n\'ó\"\Ò\Ú\îCkdœ¬e¶ƒ’y\Æy5ðz·µ.á·¥(ñ58\í‡ÿ\0É´^‹–\Ë\ä9pYoŠùòjý_5\ß\Ìý\0\Ó|omu6µ\á\Í7Åš…Ì¦W\Ô5››\ã9\È\Ås#Œ\ä‚y<ô\n\çY¾»´´´–\î\á\ì\ì\Ù\Ú\ÖÕ¥fŽ\ßy¼µ\'\å\É\0œuÀ\Í|4\ÄzRzUGŠ#u‡ÿ\0\Éöô\\¶_\"%Áó”y^\'ÿ\0$W~¯š\ï\æ}÷¬|FñgˆW\Z¯‰õLy-o‹\ÍBYt\ÅY“\æcò’ˆH\èJ¯ ª\Ðø\Ï\Ä÷\Ó^Å®\êQ\ÞO<wR\Ü%Ü‚I&BJHÍœ—RNò2q_\Óy¡qE8®U†Võÿ\0\íJ—U“¼±mÿ\0Û¿/\æ\ì}Ñ­\ëÚŸ‰µ)5\r_Q»\Õo\ä\0=\Õô\í4­€\0\Ë1$\à\0:öª5ñ.\ï¥t\Þøs­üF¾ºµ\Ñc±\Ú1,\Ó\êz®o,Aš\æH\ã\ÌÀÝ¸ó€pj\×(+,=’þ÷ÿ\0jg.”\ß4±7oû¿ý±õ¥*;F\ê\èJ²œ†A\ë\çÙ§\âD\ÖúôŸðù/¢\\]Z\Ý\Ú\Ü_[Cr\Ò\Û ’\á`\ä\\Ð†o%_\nA\èEcü:ø3â¿Š\Æa\á»+;–Žh\í‘o5KK¸™Á)\âT3\ÊBŸ\ÝÇ¹ºq\È\Éþ·E­h\ä\ßý¨—\É=1ù\'ÿ\0l}‰\ã¯\Z_üAñEæ½©$1]\Ý\r°a\Z…E@38\\õ\êM`WÊ·Ÿüe¦|?ÿ\0„\â÷Ã·–>7\ÃNMB\éDBKƒ¿\åDbÀ1H(*\n’È·°©¥\ÅP¥NžÑŽ‹\Þ\Ú\ßö\éu¸:uªJ­\\M\å-[\å\ïÿ\0ot]ø‹V¿ûw\Úu;Ë·H³]ù\×\ßhu\ÎÖ“\'\æ#s`œ‘“\ëZ0üFñe¼7ñE\â}f(¯\Ü\Ëv‰¨J\á\ÈÁi\0oœ\0\É\Ïð/i´>(§%g†_øÿ\0k\ä¾\à\\!R.\ë\ïþþ\Û\Íý\çß’|Dñ\\\Òio\'‰õ—}(cOf\Ô%&\Ì`/\îN\ï\Ýð\0ùqÀüBñM¾Ÿ¨\Ø\Å\â]b;E\ä–ö\Ù/\å\Ý;ñ#J»°å»–\Î{\×À”£½Oú\ÏJ\ß\î«\ïùÿ\0)_\ê]þ¶ÿ\0ð\éüÝ¸µ\rF\ïV½šòú\êkÛ¹›|·$võf\'$ýj½|N½©p;[.,IYPÿ\0É¿ûSÁ»¼OþKÿ\0\Ûk\Ñ_/ÒOýmÿ\0§ù7ÿ\0jOú—ÿ\0Qù/ÿ\0l}«E|S´zQOýlÿ\0§ù7ÿ\0j\ê_ýD\ä¿ý±˜½\'öuø\'{ûE|dð÷\Ã\Ý;R·\Ò/5ƒq²ö\é\ãŒEo$í¼œˆˆ\äW›\×\ÒðN«}n\ïö\Èø}‡u\r?J\Ö[ûCÈ»\Õ,ö\Þ?ø—\\–\ß\nM>Wp‘pH<´þ\\ôM£õÅºGÓ¾,ÿ\0‚?\é\ß|3aª\ë?\îµin5\ÍJ{{%m‚-\æ§kf\ì¥|•YÙ‡\Ê9<g?Cø_þÿ\0ð#CT:Œž\'ñ\ã\æûv¦±)8\ç\ã g\ÜýMz\'\Çý\âô^\Ò\ÛPñÏ‚n ÿ\0„¯\Ã*©m\à\Ë\ÈXJu\ËmUÁU£2\àUe…ƒ¯¤\Â;ñ³þŠ€ð…½ÿ\0\å\Íq¹É­ÎžU}Ã¯Û»\á†~þ\Õ~8ðwƒ´\Ï\ìi¿aû-—Ÿ,þ_™co+üò³9\Ë\È\ç–8\Î\à•ôüN\ß[´ý²> \Å\â-CO\Õu•þ\Ïó\îô»²·“þ%\Ö\ÅvBóLÉ…\ÚdlO\0\í7\î®Ø¯u²Ý‰J’Š«\n\çWð\ß\á\Ý\ïÄ¯e\Ú\ÞZi–\Ð\Û\Ë{ªj\Ëmck\î–i\n‚\Ø€ª3U˜\ÛYüðo¾Ù§ø\Ç\×z\ç‰í –\â=+Z\Ð³WQ¡wK9V\âm\ïµY•%XK\í\Â\åˆS±û1ø8øƒDø&³o\á\ßxu´‹ÿ\0\êÅ½•Ñ¹·º´Œ\äi&´\nF¬\Â6‘ðBš³ð\ÃÀ¶¿üy¤üBñG‹ü+=Ÿ†\îSU\Ól4v\ÛSºÕ®¡!\í\áX­\Ý\Úioiü¼&ü\ØS›Ý”Ÿqº—i¤¢´±7mjø_\Âzßµ\ËmÃº>¡¯\ë7[¼;Kµ{›‰v©v\Ù\ZÍ…VcÀRz\n\Ê\Ý^§û7gþ¯ÿ\0bwŠÿ\0õ\Ô)5d³7\ìò4E»ñ‡\ÄøR\Õ!¸4=z\ÓXût\r\åÅ›‰–\Þ\ÂU„Ö“\r…·\r¼œR\Ûþ\Ï#]Ñµ«¯ü@ðÇ5.y\ßC\Ðm5·N³^[Ù …n,\"Y\Íw\Øq\ÝÀ8\ÅVøÁÿ\0$÷\àoý‰\×úk¿óÿ\0\n÷\ãý‰\Öÿ\0úhõ>c<ÿ\0\Äþ\Öü®\\\è¾\"\Ñõ\rYµ\Û\ç\éÚ¥«\Û\\E¹C®ø\Ü\\«+ŽC\Ð\Ö^\ßjõ_\Ú;þJ“Ÿú¼+ÿ\0¨þŸ^Xµ¤uFlõƒcþ)\×öŸÿ\0¢\î\ë\é\ï\Ù_ö\Ó~=k\Zõ¶§s}:l0\ÈŒ±\Æ\Ç{I.¬8\nx\Ç^õóÁ\ßùüOÿ\0_ºþ‹»¯¾ÿ\0\àšò3x\çþ½-ô9+À\Ï*T¡€«R”¹d­ªõ_ðÇ¡ƒŒjVŒd®ÿ\0#«ñ\'üƒ\ÃWlžñµew€VmXÁ4}y#U=;\îü+’ÿ\0‡h\ë?ô=Xÿ\0\à½ÿ\0øºú’_\ÚDŽGU\Ó\ïœ) 6g\ß\ïV¿„~0i~0Ö£\Ó-\í. šEfV”.\ÞH\àúW\Ê}SŠð\'Z¬%È¯&\ä¢\ì¿;<\ã‡ñu£F•h¹I\Ù%}Yù)ñÁ³ü=ñÆ·á«‹„»ŸK»’\Õ\çŒ®T\ãp¦kV_ù\Z¿ë–Žô\Ù^‹ûK\Éñ÷ý…\çÿ\0Ð«\Ïõuÿ\0‘³þ¸h\ßûŒ¯¼\ÃIÔ¡	\Ëv“ü*%\É.\ç’üb\\xú\ëþ¼\ìôŽ\Z\â6Š\î¾3qñ\çþ¼´ÿ\0ý\"‚¸}µÚ–†,÷ÿ\0ü%ð\Ø\Ñ\ìnæ´’\êi ŽV3Jq’ œŽk\Ñþüð¿\Åo\Zi¾\r»Y´K-HÈ²_i:s]\ÝG²6l™²PÀ$ö¯ký‘5\r\éž]o\ÄÁÇ…\Þ\×VK{¥M÷(ö\ÒBc\\òØÀ\Ø\è6“]žµ¥\èz/\í1\à¯½Í„¾\Ðmn\"ógkf·c*\Ü\\cp­q$kóƒÊŒsƒ_k\'F1•SIò½l»zy¯¼ù\ÈûF\ãRS¾»|ÿ\0\áþ\ã\Ì>3Á1üð\ïà¿|m¤ø\Û\Å·^±ûZ\Új\Ú–)1\Î\0\r*)=ó·8\ã8È¯Î­µûñ\×KðÞ›û#ümÿ\0„~M&Bú*y\ß\ÙcM\ãv\îûi\êq¿=ñŽkñu||’üE\Ø÷\âÿ\0¯¼6Ñ¶–Š\Î\Å\ÜôÏƒÿ\0\nbñ”©ê»“I…ö¬jv™\Øuì£½kø£\âW…ô]B]3EðÆŸqiyou$\nwÁ\Ú\é\îO5\Ñ|:\Ô\Äm\â·lJ!˜qýü·ÿ\0Z¾z;²s×½|\Õ\Zo‰ª\ë·\Ëd“·\Ïð?q\Í11\á.ŽWû\\Dy\çQ\ÅI½\"ùUÓ²\\\Ý;wnþ\â¿\0Ç¬\èC\Ä\Z=¬p\Ç\åù\ÍºŽ½\È\\œ\ÏŽ:W—2\×\×³ß‡þ\×ðx\Ýj+‹O6\à©~žHûß†w\×\Ésc\ÌltÉ®Œ²¬Üª\á\æ\ï\ÈìŸ–¿\ä|¯\à\èF–4£ˆ‡4¢´WV\Õ.—¿\á}\ît_\nÿ\0\ä¨x?þ\Ã6ú=+\Öñ^Mð·þJo„\ì1gÿ\0£Ò½n½‡¹ù\Òf×…|//‰\ï$\Ê\Âð\äq»<gõ¯Vµøk¡\Åjú¢\É|’\0óM²¤J[h\ä¦¹„÷koq \ã~ü\ã×Šõ_[xŸT\íw\Zöe¤[B$÷bÜ·p¬§\ï\çZó2ü\ÚX.%¡†\ÅT§4—½\í#{\ÝZ\Ñ\Ñû\×zmª\Ö\ê\éþ“\Ä\\\'F|\rO0ÁBr\ÅM6¥	5g~º¥d•Ÿ_\Â\Þõû@~\É>ñ\ï\Ãû}wÁ°\Ø\ëš~œ‚\Ú+f\èQ\Ô#¦ý£\n\Ýó\Ïb?<ž2ŒUVS‚Q_ ß²§Žõk¯‡²\Ï{+5oUõ@ªX¯û!‹~9¯†~!5›ø÷\Äm§\0,£pmöôòü\Æ\Ûúb¾…\å‰\Ë3lÇ†«\×ö\ë+F{\Ý~ž2¹ñøˆJ¶\r˜ÊŸ³uV±\ìúÿ\0\ÃõV8‰kÿ\0\Ö\ãþ\ÂÖŸú&\ê»_ø«õ\ÏúþŸÿ\0F5q¿ÿ\0\ä™]\Ø^\Ïÿ\0D]\×g\ãùu¿úþŸÿ\0F5~œx\æB\ÆY‚¨%‰À\0u¯Ð¯ƒ?±†føC£Iâ€±øŽ\íZ\î\æ9-\Ñ\Ì[À\Ù$‚\n¨\\ŒðÅ…|Oðº\Ö\Ú?\Ûj—Ë¾\Ö\ÆA*¡ \åAöý\0\ï_ >ø”÷\Þ±–Yw´\á¥\ÃV8?–+¢8yTW\èy8œÂ	ºw\Õk\â\ï\Ø\×\Âmp\ÖöE#Á,-\"mÀå¶’WŒgW\ÃWP{©¢pG*®+õCO™\çðî»®\ÜKû¸m¤†\Çø™p\ÍøÆ¿,¯¤ó¯&v`>§5…KSª©Ç³ýŒ\êV¢\êÏ«\Ó\ÓS/\Ä\ëŸ\0ø¯þ¼\áÿ\0\Ò\Ëzú/P‹v\à\ãù”|=ÿ\0¦‹Jù\ß\Ä\Çþ-ÿ\0‹¿\ë\Êý-¶¯¥&v\àÃù”|?ÿ\0¦›J™\èÆŠÍ¥m¨»Ž3S\Úims&Ø‹÷˜ÿ\0*¿j¢9	9\0©i™o\Æ	Œÿ\0:öpX\\=h©NW–¾\í\í~\Êý?^‡e*p’M½{w([\é\â\ÏV‰2H\'‘\ìi5«8£hš4T-œ\ãð­):ŒM\è¿\ãLÔ£ó<¿lÿ\0Jö1)RÀ\âc\é\é\åð3„cJi-ŸùV\í\Ñ|`qø¤¼Aÿ\0¦›ºù\ë\Ãcþ-\ïƒÿ\0\ë\Æoý-¹¯¥a‡o‡üf\êRñþšn\ë\æ\Ï\r\É?ðýyMÿ\0¥·5ññ<¦O¶»\r?AÓ´\Ûq.¦\Þd\åw˜y;¸×Š\åc\Å\"8\0• Œôâ»‹lÇ‡~Ñ¨’\ëp|É¤;²Nx\Î\Þp8¯±\á\ì=*\Õ*JQ‹”b\Ú\çøUº¿½\ßcã¸‹V:QŒ¤£)$ù>7~‹\åWeµÄ‡I\Ðõ\èZ(G_\â*Wð=kŽ\Ô4÷\Óo$·—õ\ìk¯\ÓõOir3\Ú\Ë\å3–C‘øŠÀñf¡m©jQ\ÍjþbyAKm#œŸQ\éŠô³º8:˜(\ÖR§\í\Ó\×Ùµf½7\ìyYle<t¨¸\Õö\rh\ê\'týv\î3\ÂiŸh\ãþŸ!ÿ\0\Ð\År\rWþ-}§ý†/?ôE¥v~\çÅš ÿ\0§\è?ôb\×ð\×þI¯ý…\ï?ôE¥~cô›!rÀ“\Ø\n÷_‡¿	ô\Ûou¸\åôª\ìòý\Ès\Î\î}s^-¡ºG¬X´Ÿ\ê\Öt-ŸMÂ¾\ßøu\à-S[†\Ã\ÅV—÷w\×l¶	(KS\Æ@la²OqÈ¯©É¨\Ñå©‰«~N›ü\ì|Obq<ôpT\'\É\í/vÝ»itp2ü2\Ñ<Kkq>IV(\ÚI$³‡\r’Å”p\0\É\ãŠù\ç\Ç\Þ“Áz·\Ïi(\ßÇ©\äqýE~¤üNño…|7ð_\Äz‡/4tº¹µ6ñ\éúT±\îý\á\n\ß\"\Ìv“’Fkó·\â\åõÎb\æ\Ê\å\Ä\Ìòy-„\\¼q\Ç\ãZ\â«a³-J\ê\n/M®ö½þó›G”\ã©aeQÔŒ\Ór\Ñ\Ùok?—ü\ÈvûTzJ\í\Ö~)ú™\"ÿ\0\Ð\ïªj‹M\ã\ÄýL±ÿ\0\èw\ÕòG\ß\\“m}±ð¿þ	\ëgñCÀúˆ\í<E5¤WA¿s3) «zGÓŠø¢¿Oþ\ê×“~\É~\ß\Ú/f/£mM4’ÿ\0jk?8ù¡6|\Ý1¼\í\Íy9…WG–I»Y½<¬r×Ÿ³÷\ì“zi\ØòoÁ:4o\Ú=Þ³\ãu¶·HžbªË½•6† 2€YrI\î=kÀ¿io\Ùþ\Û\à¿o¤.¥&¥q*,¾fFÝ»mü£ó¯¶¼[\àÛYøR\ÇÃ¶z¬zj.¥,\r\âydf…ðuŠN[8ýØ—€8$\nù—þ\n­G©|c†\äWòl\âVÁ\è@?\ã^fZµ{;ò\Ýu½\î®ÿ\0C’iÕ¨ôj+–Ú·{«¿\Ðù[h¯2øÄŸñ_]qÿ\0.v?úG\rzv\êóoŒ™.\ë\Ê\Ãÿ\0H ¯­Š\Ôô\å±\Ã\íö /µ>Š\Ö\Äòý\èòý\éù¢‚\ã6ûQ²ŸE/Þ,QE$M†—oµ>Š«˜nÁFÁO¥\ïE‘<Ìh£hô©(lzUX.4G\íN\ÙE¬…\Ì(QG—@\ëNª°µ°Q°S÷RS°]ˆ±Òˆý©r=)À\ÓHZŒ\Û\íF\ßj}ì€\Ëö¥\Ûõ§n¥¤{EE-.\ê,\nŠO.”š\\ñSaˆª(e5% \Ôm.\ÚZ\r\Z\ãZ?j6ûRµ%-\n\Ô(\Û\ëK\ÅQd!\0\æŽ=iwR\Ó\ÐCvûRù}ñJZš\Í@õ\nCŽôn¤fæ   Sx§gÚ’‘Z‰´PÀR\ÒsEƒQ6š6Ò­\Ña+I¶Ÿž)‡­&4-sIº’jPE:Š¸\ÚM´\í\Ôn¢\Ã\Å!ŸMô£”bm\Å&\ÑKEqGf’‹ \r£m&\Ñ\ëK]¯Á\ßø3Ä¾>\Ó\í~ ø©¼\á>uõô“\\\ÜHŠG\î`X\ã|HùÀwTc¸€Ž†q@\n~>Zõ\Ú[AøQ¤üCšó\à\çŠ\\ð~¡ºhô\ë›[¨®4¦\È\Ì\ç|\Øùù%ð\n¾J‡“\ÊÐ…%c©\Ô>ø—Kð=ŸŒ.t\ß+Ã—žG‘y\ç\Äwù\Ò\Þ\Å\Èx\Ëé·£•\ã\É\ÉÀt-Ë…\æ¿M¿gˆ^ø›\à?|C×¼¤\ÝZXhzwˆ<WýŸ¢Y6€úDòO`D¨\Ésp\r]›7^8c…\Ýô‹üQðsO_\É\àŒ—\ZÇŠ¤ñW‡\í\íôûoŠš†¨\×K«\ÚGqµ{\éU0<¡”£\r¥l\Ö­¬j©\Ý^\ç\á\Ë-7moøþ\×\Ãú<Ik\á;\ëSÂ°jW1i7\×JVk‹5•„8(„3F‘µy\'\å+¥ø7\à};\ÅZ¶««x.Â¾´ú„6m¶{\Æi(-\"88y¥‘8%W{\à\ì\Åt\ék˜\ë{\ç„>ø«\âÔ–þðÎ±\âKˆþüZE„·N¹õ©\"¹\íµö¿ˆaX´»­?\Ä\ß\Ø\í¥\è³ý†ò\ËT\Õnô\Ï\è·{C6Ÿmkb~\Õ}s\Z\ãÍ™X¶\áóo\âFøª¦/˜rV:O|3ñ?\Äe\×Ãš4ú¬z›>¯©KÕŽ\Ö\Ò/$®\Ì@\0*œ\å\n	 UŸ\0|)\×þ#j\Ú=Ž›möd\Ö.\åÓ¬/¯Uãµ¹½H„‚\Ñe\ÚT\ÌÛ¢P¾³G¸¨m\Õõž—ÿ\0	wöuŸü#\ß\Øÿ\0ð¨¿\á]\Þ}£þ\ìý¿Ú¿ð„\Üyÿ\0\Ú?eý÷Ÿ\çý«kù³\æl\ï\\­†[\á\ßØ§Oxo\Ùa>\Ì|Uý¦>Ç³\Ëù~\Õý—\æy\Øùü\Ï7Íº£˜»#\ÉC##«#©\Ú\Ê\Ã\Ô]O‚~x\Û\âZÝ·„<¯ø­lÊ‹“¢is\Þwgnÿ\0-nv¶3\×Ò·?h¿°ÿ\0\ÃAüNþ\Ë\Ùý™ÿ\0	F©ö_/;|¯µË³\í·ì¿³O„O?f¿ŠúxðWŠ<z¶ôI?²¼#7•x0—Ÿ¼\Ï\Ùn>AžG—\Ü|Â›vW!-l|Ý­x\Ä>·\Ó\î5mS\Ó-õ•,æ¼³’¹h\ßd‚2\Ê”•¶\çƒ\Íjh¿|y\â_\ê>\Ò<\â-W]\Ósö\Ý.\ËI¸š\ê\×Í‰P²r@ù€\ä\×\×_\èž øOð_\á‰bþÉ—VÒ®¦Ñ®5b}7Z‡T»Hã6¬À´¸p\Æ6\ãet_´„o>\"k\Þ-\Ð<7 \ë>,Ž\Û\â>£7‹ü?\áYB\ê“F\ÑB¶S°L\ÞJ<12+¨ö\å??µM&\ïDÔ®´ýF\Î{ûYZ‹[¨š9a‘N¬ ‚2ªÁG¥z7\í\r\áû/	üqñÆ§j÷šõŽ­=ºjZ…\Ò\Ü\Ü\ÜmbK*€óœœs^wºµN\ê\æoq»Ez\×\ì÷ð\ïCñŽµ«jš\íö\Ðh0\Åw©x‚\ÓFmff*À·R\"$`ny\n’\ÛWj\áœ2ùF\ÑF\ÑM« R>\ë\Ñ>!\Û\êž\"ð|_\âŸZj~Õ¼E¨xš\Î\Ó[´”\È\×J&…l\Ò9[\íK&\áò6a\È¸	øN\×OñÞ©ñÿ\0…÷ž(\ÐdÓ“Dðö‹\âk\rJ7?cG[\çûTÑ™&	¾8\Î^rù`ªÁ¾KjJ\ÏÙšsÁk«[\ÚþÏŸ´GT²}~\ãÅºTÿ\0g[È¥’\àG %–=¬Dˆ\×.™_yù†|h\Í&\ÑKZ¨¤MÄ£hô§·Jjõ¢\Ä\\\éþø|Lø\àÿ\0}³û7þ\rb\ÏIûo•\æù|\é™³r\îÛ¿;w\ãkªø+ÿ\0Cÿ\0?ð†²ÿ\0\å\Å²¿üœ÷\Âûtý-†¼½~õ+]Ø«\è{\'‡þü0ñ´š¥‡‡|y\â\Ùu‹]SÕ ‡Tð}­µ¼¿c±ž\í£iST•“rÀ\Ê#`°\â¼omz—\ì\ãÿ\0%Vÿ\0±?\Å_ú\ê\å\Ô%­„ö¸Œ(\ÛK´QŠz\0Ý´QE;R½#öuø\Ù}û:üdð÷\Ä-;M·\Õ\ï4sq²\Ê\é\Ù#Ko$\r–^F¤p+\ÍóEb\ìÕ™¾\Ç\éo‹?\à¯úw\Äo\ØiZ\Ï\ÃK­&[}sG\Õ^\â\ÇV[\ëg©\Ú\Þ:„h“–QóH\Ï\Ç\Ðþÿ\0‚¿|\×£Š<8øù¾Ý¦,ª9Á†I	öA_‰tVŒ¯´‘ïŸ·w\Äÿ\0üfýªüq\ãj_\ÛÔ¾\Ãö[\ß\"X<\Ï.\Æ\Þ\'ù%Uq‡\Ç*3ŒŽ0kÀ\è£5²²V2z»…f“u=\â¿\Æ	~![\éZ“¥§…¼¢)]\'Ã¶óV&`<\É\æ“jù÷\ÊTgT*ª¨óºM\Ôn¤†-›¨\Ý@þ\Z\Õð·Šµ¿\ë–\Ú×‡u‹ýYµ\Ý\äj:]\Ó\Û\\E¹J6\É†\\«2œC\Ð\ÖMD½\'\í5\íE´ñ‡\Ãÿ\0øóR\Òá¸5\Íz\ïWût\ë5\å\Åã™š\Þþ%‘Œ\×s\åwÜ“Œ\Ó\áý¡ƒ£kV¾ø\áŸ\ê:¤0@ú\æƒw«ýº†ò\Þñ-q*\Æ\ÂkHNð»†\Þ\Îk\Èœµ*(w5¼O\â­o\Æ\Ú\åÎµ\â-bÿ\0_\Ön¶ùúŽ©t÷7\íP‹¾G%›\nª£\'€ t•Edž­ðtÿ\0\Å/\âaÿ\0O–ú\Ý})û3þÑ‡öx\Ö5»\Æ\Ð·£\Ô\àŽ#ºû9Œ£v6~ñ\ã•ó/Áû\ËHôO\Û\Ïeg4—6r\"\Þ]GõT¸T»\àºôõ\Ùù–ô\Z\Ñðmmÿ\0\Ç+‹‡§Š§*5•\â÷6§9Sjp\Ý^xGö\Þ\Ðü×†\Û\ÂZ\ç\Û6ûe\Äv\ÞV\Ý\ØÛ…“vwLms\Ã\íÿ\0nm\Z\×\ÆOâ¸¼#v·Œ6ÿ\0e­\Ò,+òò&Ûžƒwú¾§õò{#ÿ\01­ÿ\0ö\ßürœÍ¿\æ7¡\à\æ\×ÿ\0ŽVµc\n\Õ\ë\âgz´y%«³’\ÚöZ%ª\Ôó)eôh\á\èa¡ðÒ—<{ó]½_]Þ‡Añ\'\ÆMñ\Ç\Úÿ\0‰š\ÔXVòK¯³\ß\å\î9Û»8õÀ¬`\È\Ûÿ\0^ú7þ\â\ê\r©ÿ\0˜\æƒÿ\0ƒ»Oþ;KªjzdŸð”lÖ´†ó¿²mbÆ¥\Þ\éý›¼¯\ÏÊ¯—&_î\Ï¦8¨Ge¡\é¶\ä\Ûg–ühÿ\0’ƒsÿ\0^:þ‘A\\9ö®\Ó\ãÕ½\ç\î\Þ\Ö\ê\Þò%µ²‹Îµ™eŒ²ZBŒ© á”ŽPk‹®•±“\Ü÷\Ïü]ð\âhö6³\Ï5´°ÁM\æDq ž8¯@økñÿ\0\Â\ß|]§øºvŸ\\µÓ‹³\éú^¥%…Ô»Ñ£%B®˜.	\ÇP\èM|‡E{¿\ÚÕ¥MÓ’M5n¿\æyŸP¦¦§ûŸ¡?\à¦^ñ÷Á¯\Zø#Ið\'‰¬§ñ\Ù>Ù«ø¢}I! \ä0Y‹mï¤gŒ\ç¿=ù¤Z>µ\â\ÊW\éùþ·=…¢Š*Fu~ñ£ø{u¬\åš\ÎC»ŽJ7¯Òº;Að.­©OY¸°¶v\Þ\ék±³\ê\0b\nþ¿Jó:+Ï©ƒR›©NN-\ïcì°¼I8`\á€\ÇPzpw5Ó’i­<¿C\è‰_´&o\à”ðw­¥†\Ç\ìÿ\0e–\îu\ÚV<`ªòH\ÎXúšù\âŠO\â­0¸ZxHr\Ó\ë«ov\Ï/8Î±Y\Õu[d¢­­#º$t¿[þ.W„ÿ\0\ì/iÿ\0£’½{ux\×\ÃÛ¨l|yá»›‰Rxu;Y$–F\n¨¢U%‰<\0\0\ÎkÙ¼\Û/ú\rh¿ø6¶ÿ\0\ã•\Ñ-\Ï;4]^Mù.,½}E{.ƒ\ã	\ëQÛr\ÛN½ò~\ïÛ£R\É\íóv¯Y,³ÿ\0!­ÿ\0\Ö\ßürœ\Z\Èÿ\0\ÌkDÿ\0Á½¯ÿ\0¯2\Ê\éfQ\\òq’\ÚQvk\æ~…‘q–3&\Â\Ë:q­E\ë\Ë.\ÉþšŸLø\Óöš\ÓôŸ#\ÃpG,\ÞQŠ3	\nF8\ÇS\è\ç_2ry<š-™ÿ\0˜Þ…ÿ\0ƒ›_þ9K\äZ\ÐsAÿ\0ÁÕ§ÿ\0®<“‡ð9\r9\Ã\æ\ï&\Ý\Û~yó¹\Æs_9¬ªTŠŒcð\ÅlŽ\âWü“¯ûYÿ\0è‹º\ì<Xs\â­dÿ\0\Ó\ì\ßúWñB\â\Ò‡3[&©¦]\ÜËª\ÚÈ°\Ùj\Ü>Å†\ä3’\0.£\'ûÂº\Í~ûM½\×uˆu\Í\áš\æI¿µm†T± ýÿ\0JúCÀ/xÆš¯†a’9ckY{\Û\Ï\nÈŒqŒò88¡+\Þ<-ûNx^haµ\×<;}¤*(E¸\Ñ\æY‘@\0\åHT\ãþø\Zù«Í²ÿ\0 Ö‹ÿ\0ƒkoþ9N\rd\æ7¢\à\Þ\Ûÿ\0ŽVñ«8\è¤qUÁa\ë¾jM÷\ë÷ŸwüDý¨þÂ•º\Òü3«Ku|ð}š+7µx\æ.A%Ü‘€7c$×Œô¯….dûEÄ’\íXÃ±`‹\Ñ}©l\Ïü\Æô/üZÿ\0ñ\Ê•i\Û\\\Ððuiÿ\0\Ç+Ÿ•só½\Î\ÈES‡$v3|Kÿ\0$÷\Æõ\ãþ–\ÛWÔ¶ö¾g…ü\Ø\ë\á-ÿ\0MVµòß‹¦²³ðŠP\êúDò\ÜZ\ÃP\Ú\êvó\È\ì.\íÜ€ˆ\äœ*±\é\ÐW\Õ>ñ…u/ø*EñÇƒ\áhü1£[\Ë\r×‰l –)cÓ­\ã‘7˜2²º2@ Š$Z x\ê¹ü)\ßd¤\Z\Òþ\Òð\Çýžÿ\0Â³Mÿ\0\ãô\ï\í/\Ðù\àü+t\ßþ?[\ÑÄº?e5\æ—\ç¿\âk8ôL\Ë\ávid·2c+\ÓÚµ>\ß\áƒÿ\03ç¿ð®\Ó?ù\"ö\Ïÿ\0\Ðû\à_ü+ô\ÏþH¯B¶fªa\Þ5-]¾_\å\æm*ü\Ð\äŒms2K]žñ³cðˆ;\Ô&\î¾VðÁÿ\0Š\Âõ\ç7þ–\\\×\Ö> ×¼-¥x\'\Æ\Ó?Ž|3I\ámj\Þ(m|Q§\Ï4²Ë¦\ÜG\Z$i1gfwUA$šù#Á÷¶3xÃ‘[K‚X-¦ŽHn5b‘\ÝNÀgp\Êzw¯\'4ZºøŠ\Þ\Þ\Ì\Ø_ŒÁ\Î\Ö+¸`õW/\æXÿ\0\ÐkEÿ\0Áµ·ÿ\0¥\rd\æ5¢\à\Þ\Ûÿ\0ŽW¯\Ç\Ö\Ë\ë{j6¾\Í=š\ì\Ï/€£™Qö5¯m\Ó[¦º£µÿ\0ŠbÙ¼\Ñ\å1\í\Ë7\é\\…ô©=õÄ‘ŒDò3(\Æ8$‘Qf\æ7¡ÿ\0\à\â\×ÿ\0ŽS\ÂZù\è?ø:´ÿ\0\ã•Ñ\Í>½ÁR…4µ÷U¯\êr\åù_\Ôg*’­:«{\Îö^FŸƒ\än\Ðÿ\0\ëúýµ\Åü3?ñmm‡ýE®ÿ\0ôE­v¾š\ÃOñ•uq¯hÁ\ÜR\È\ß\ÛV‡\n®	8g ®\á}\å—ü )m&¥§\Ú\\G©\ÜH\Ñ]\Þ\Åmh­À` ”a‘\èkÅ¹\í\n“šô|E6‘\ÃÜ²C<8ò\îœñ\Ðñ\È#Ö¸2\ÇþƒZ/þ\r­¿ø\å/™eÿ\0A­ÿ\0\Ö\ßür»ðxÚ¸)ó\Ò{\îº3\Ë\Ì2\Ì>eMS®¶Ù­\Ñúq\á\Ý\"\Î÷@‘4¹n\à»k•\É\r\ÃM,k\n¤x\Ë#¹˜“;N:Yš—†\íSÃ¾&ô\èMÆŸ{$r^\ç0˜ü\È\ãD\æM¹\ËµÔ’§;²+\ãhþ/x…U|e¢aF\íBÀŸÌži·ŸµýB\ÖKy¼e¢yR)VªX! û†W‰\ìe\Ü÷½¢8\ÅcL°b<MñT\ÔÊŸú2ú­}ž\Óþƒšþ\í?ø\ídhú¶›uâŸ‰eu]:4º×…Å¼“\Þ\ÅM’\ï\æFf‡Î½?¼+°ä±§^µ\áÚƒ\Çþ	\Ñlô}3Xkm.\Ñv\Åo(\ÆI$\î\ÆrI5\ä\Þmý´_ü[ñ\Ê_2\Èÿ\0\ÌkEÿ\0Áµ·ÿ\0¬\çN\ZsW±” ¥¹ô]Ÿ\í©â¤Œ­\Û^]û\Ä_H€þ\0×üXø´Ÿ–\Ú\æ\îÀÇ¨\ÄX}¡¥.ûN8,zŽ:v¯:cnšÞ‡ÿ\0ƒ{_þ9N\Ú7MoAÿ\0ÁÍ§ÿ\0¯b8ùÆ‹¢¡5o…_\ï9–\nji½<\ÈkÍ¾3\É@¹ÿ\0¯?ÿ\0H ¯Qò-\è9 ÿ\0\à\î\Óÿ\0Ž×•|`»·»ñõ\ã\Ú\Ü\Û\ÞD¶¶QyÖ³,±–KHQ€u$2‘Á\ê\rpGsª[e›¨\ÝZŽZu2Š (¤þ*Z`S„QÞU4«MRi\ËLüÐ½\èZJ`/£Úš=)V¯RE¢Š(\ÔC·Q‘LZZ.ES…\ÝKÏ¥6–‹ŒPsN\ÝM\Ú(jW\0\ÝFÿ\0jm\\V½.\ê½@À\ÓZœ\ÔÆ¤Á!	\æŠ(¥rÂQ«Sÿ\0\ZW@Ô›M!jk>h¸$HF)¾eDZ“uMÊ±.\ã\éF\ã\éQ«P\ÍE\Çaôf£\ÝF\ê.2L\ÓZ“h \ÔóÀ\Ä\Óvš]Ô”®;¢“<Ñº‘ 3KÏ¥&\êcS¹V$¢¢f¤\ÝH9IwR3~\Ê(ð\Ôy•\r>˜\ì?\'ý\ÚnM%4šAaû¨f¨è£˜,>ŠeaôS( ,;u&M%QN¦R÷¦€\ë|ñ[Æ¿ö\Â/\ã\r{\Ã{<\í¿\Ù\Zœö»|\ß+\ÍÇ–\Ãþ\Ï\ï\ïy1\ç;Oü5WÆ¯ú+þ<ÿ\0Âš÷ÿ\0Ž×•-©\Ù>‚Ôš»‡õ_†°¬:}–Ÿyöæ™®º\ßD\î$’Å¦h¡m®¹…\Ì\äºõ;¸9\à¢\É\Ø÷†¿µÇ¾\ê\Úf¡¥\Ù\èw\ÓX\éZ†”T³k”›\í·\r<÷)|\É(›†H‘YXn\Ý\âœúTlÙ ¶\êj\Ëa\îu>ø•\â‡)®\'‡5‹.-sMŸGÔ¢kGui2’\'VUŽ2§• €j\Ç\Ãÿ\0Š\Úÿ\0Ã­[G¾Ó®~Ðš=Üº…\ë<–¶×¯Œ],[‚‰—lL\Ö÷¶¸\Ú)YRy$y¤gvgv;™˜\ä’z’i´Å¡©“a\r¨4”\îU‚¬\ép\Ü\ÜjV‘YÀno$™B_1\Ë\0«°‚\'\çUªm>ú\çK½·¼³¸–\Òò\ÞEšˆ¤‘:œ«+A\äHg\Þ^ñ \Ô<e£øs\â&»¨øÿ\0\Çþ±ñˆ\ï.ct¹ŸO¼KUò´\ÛI\'WWx2Kò¡Š9v”#$ø\'\í\áýwMñ‡‡üos\âo\Ùj\Z6—­Iy\ã&\Z\Ì\Ú|“ò­n\ç’!Àù,\È5&3žZøýñ?Ä“\é·\Z¿\Äj—\ZeÀ»±–÷]º™\í&\0,E¤%Ëƒ\Íak<W\âg\ÕYñ6±«6­4W\Zƒ__\Ë1¼–%+Í¹˜È¤…-’ b³ŒZw•\ÑõGu\Ï^|~»ñ>•\ã	¼c„|;y\âOØƒnö–\ÏcfJ\Ç\ä(}\ÒHQV¶‡;A\Â)+\æ–÷\Þ5ø‘ñ\ã\Ä?>Z]ø\"\ÃV\Ô5+«´F\Ö\r2\ÝP\És)¸E\"7Ž\Ü\æ,¸ß…ºƒ\æ>ø\Ññ\Â:„÷úŽ¼K¢\ß\\A\r¬\×:~¯q²C…†6dpJ\"€ª§…b\×\ã\×\Ä\ÛYõKˆ¾,·\Ô\ä–Ižö-r\éfi$TI¸|–eŽ5\'9!‚ŽV‡t}‘¤üX½ñ´ñWÃ«ýF\ïV\Ô<}\áÿ\0jš×–\Ñ\Ýk\Ö\Ð\Ø\ì-t¹%£¹•fvG\'p	¿•¯+ñ¿Š$Ò¾üY\Ò<?=½Ž‰\áÏ‰vgD“L·Š\ÞH\×:™I<\è\Õ^F#\Ú\î\ÌT(\n@\0W…\Éñ\ë\â\\Úµþ«\'\Ä?¾©j,o/[[¹3\\ÛŒ\â~\çŒno”’9<s\\”ZÞ¡“q¥\Ç}s™q,wY,\Ì!–D\Ù3´²‡p	\ÛM%g\Ð´\Å\Þü!øy\àø«]ñ=ý\Üð—jkš„·\\)K8‘¥v*\Ü003rzãöš·©\ëZ†¹t—:õÎ£p‘Gn²\ÝLÒº\Ç\ZbN\ÕEU \0Àª…»Ö‹\ÝV3z²æ•ª\Þ\èZ¥ž¥¦\Þ\\iúœ\Éqmyk+E4£IÔ‚¬¬A\0ŠöOþ\Ö^0i.4ÿ\0‰W\ßü#t\ÜxÅº­\Í\Â,‰“\ÐLX¼)<²¹K+d<?v\æ¤j\ZOpZlz¿‹ÿ\0jOŠ\Þ3þÓ·¹ñæ½§\è—ñ5³ø{K\Ôf´Ò¢¶)³\ì\Ñ\Ú#ˆ\ÖŸ&\Ì`Ž¹\É\'Ê¿\Z=)*’Kb[oq\ÙdSiq\Å´Rn¢ÿ\Ù');
/*!40000 ALTER TABLE `Ð°Ð½Ð°Ð»Ð¸Ð·Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`
--

DROP TABLE IF EXISTS `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(5) NOT NULL,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`
--

LOCK TABLES `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` WRITE;
/*!40000 ALTER TABLE `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð°Ð½Ð°Ñ‚Ð¾Ð¼Ð¸Ñ‡ÐµÑÐºÐ°Ñ_Ð»Ð¾ÐºÐ°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹`
--

DROP TABLE IF EXISTS `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_Ñ…Ð¾Ð´Ð°_Ð¤Ð¤` int(11) DEFAULT NULL,
  `Ð¿Ñ€Ð¾Ñ‚ÑÐ¶ÐµÐ½Ð½Ð¾ÑÑ‚ÑŒ_Ð¤Ð¤` float DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk0` (`id_Ñ…Ð¾Ð´Ð°_Ð¤Ð¤`),
  KEY `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk3` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  CONSTRAINT `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk0` FOREIGN KEY (`id_Ñ…Ð¾Ð´Ð°_Ð¤Ð¤`) REFERENCES `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ` (`id_Ð²Ð¸Ð´Ð°`),
  CONSTRAINT `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð‘ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹_fk3` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹`
--

LOCK TABLES `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹` WRITE;
/*!40000 ALTER TABLE `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ`
--

DROP TABLE IF EXISTS `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_Ñ…Ð¾Ð´Ð°` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk0` (`id_Ñ…Ð¾Ð´Ð°`),
  KEY `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk3` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  KEY `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk4` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`),
  KEY `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk5` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5`),
  CONSTRAINT `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk0` FOREIGN KEY (`id_Ñ…Ð¾Ð´Ð°`) REFERENCES `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°` (`id_Ð²Ð¸Ð´Ð°`),
  CONSTRAINT `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk3` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk4` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_fk5` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ`
--

LOCK TABLES `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk3` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk4` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk3` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾_fk4` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (2,1,2,7,NULL,NULL),(3,1,2,7,NULL,NULL),(4,1,2,7,NULL,NULL),(5,1,2,7,NULL,NULL),(6,1,2,7,NULL,NULL),(7,1,2,8,NULL,NULL),(8,1,5,6,NULL,NULL),(9,1,NULL,NULL,NULL,NULL),(21,1,5,NULL,NULL,NULL),(22,26,NULL,NULL,NULL,NULL),(23,27,NULL,NULL,NULL,NULL),(24,28,NULL,NULL,NULL,NULL),(25,30,NULL,NULL,NULL,NULL),(26,1,31,NULL,NULL,NULL),(27,1,5,32,NULL,NULL),(28,33,34,35,NULL,NULL),(29,33,34,35,36,NULL),(30,37,38,39,NULL,NULL),(31,24,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(50) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
INSERT INTO `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` VALUES (1,17,NULL,0),(2,18,NULL,0),(3,21,NULL,33),(4,22,NULL,11),(5,23,NULL,123),(6,26,NULL,NULL),(7,27,NULL,NULL),(8,28,NULL,NULL),(9,29,NULL,NULL),(10,30,NULL,NULL),(11,1,NULL,0),(12,1,NULL,0),(13,1,NULL,0),(14,1,NULL,0);
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'Ð‘ÐµÐ· Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ°',NULL,NULL,0,1),(2,'ÐÐ° Ð²ÑÑ‘Ð¼ Ð¿Ñ€Ð¾Ñ‚ÑÐ¶ÐµÐ½Ð¸Ð¸ Ð±ÐµÐ´Ñ€Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,2,1,2),(3,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð‘ÐŸÐ’ Ð±ÐµÐ· Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ°.',NULL,NULL,0,3),(4,'ÐÐ° Ð²ÑÑ‘Ð¼ Ð¿Ñ€Ð¾Ñ‚ÑÐ¶ÐµÐ½Ð¸Ð¸ Ð±ÐµÐ´Ñ€Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,2,1,3),(5,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð‘ÐŸÐ’ Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼ Ð¸ Ð¾ÑÑ‚Ð°Ñ‚Ð¾Ñ‡Ð½Ñ‹Ð¼Ð¸ ÑÐ²Ð»ÐµÐ½Ð¸ÑÐ¼Ð¸ Ð¿ÐµÑ€ÐµÐ½ÐµÑÑ‘Ð½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,2,1,2),(6,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð‘ÐŸÐ’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,2,1,3),(7,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð‘ÐŸÐ’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð½ÐµÐ¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,2,1,3),(8,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð‘ÐŸÐ’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ñ‡Ð°ÑÑ‚Ð¸Ñ‡Ð½Ð¾ Ñ€ÐµÐºÐ°Ð½Ð°Ð»Ð¸Ð·Ð¸Ñ€Ð¾Ð²Ð°Ð½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,2,1,3),(24,'ddd','eee',14,1,1),(25,'2222','222',14,1,2),(26,'gh','',7,1,1),(27,'erwe','',14,1,1),(28,'kiliukhjmg','',3,1,1),(29,'22','',14,1,2),(30,'e3','',14,1,1),(31,'ed','',16,1,2),(32,'34434343','',NULL,0,3),(33,'1','',NULL,0,1),(34,'2','',NULL,0,2),(35,'3','',NULL,0,3),(36,'555','',NULL,0,4),(37,'88','',NULL,0,1),(38,'888','',NULL,0,2),(39,'8888','',NULL,0,3);
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸`
--

DROP TABLE IF EXISTS `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk3` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_fk3` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸`
--

LOCK TABLES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk3` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾_fk3` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2,3,NULL),(2,1,2,3,4),(3,1,NULL,NULL,NULL),(4,5,NULL,NULL,NULL);
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
INSERT INTO `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` VALUES (1,1,NULL,0),(2,1,NULL,0);
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'1','',NULL,0,1),(2,'2','',NULL,0,2),(3,'3','',NULL,0,3),(4,'4','',NULL,0,4),(5,'2','',NULL,0,1);
/*!40000 ALTER TABLE `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°`
--

DROP TABLE IF EXISTS `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°` (
  `id_Ð²Ñ€Ð°Ñ‡Ð°` int(11) NOT NULL,
  `id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id_Ð²Ñ€Ð°Ñ‡Ð°`,`id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  KEY `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_fk1` (`id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  CONSTRAINT `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_fk0` FOREIGN KEY (`id_Ð²Ñ€Ð°Ñ‡Ð°`) REFERENCES `Ð²Ñ€Ð°Ñ‡Ð¸` (`id`),
  CONSTRAINT `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_fk1` FOREIGN KEY (`id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°`
--

LOCK TABLES `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°` WRITE;
/*!40000 ALTER TABLE `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°` DISABLE KEYS */;
INSERT INTO `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°` VALUES (6,2),(4,3),(5,3),(6,3),(6,5),(4,6),(5,6),(6,6),(16,6),(16,7),(4,8),(5,8),(6,8),(4,9),(5,9),(5,10),(6,10);
/*!40000 ALTER TABLE `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`
--

DROP TABLE IF EXISTS `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` (
  `id_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` int(11) NOT NULL,
  `id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`,`id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  KEY `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»_fk1` (`id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  CONSTRAINT `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»_fk0` FOREIGN KEY (`id_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`) REFERENCES `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` (`id`),
  CONSTRAINT `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»_fk1` FOREIGN KEY (`id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`
--

LOCK TABLES `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` WRITE;
/*!40000 ALTER TABLE `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` DISABLE KEYS */;
INSERT INTO `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` VALUES (1,4),(1,5),(1,6),(2,6),(3,6);
/*!40000 ALTER TABLE `Ð±Ñ€Ð¸Ð³Ð°Ð´Ð°_Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð±ÑƒÐºÐ²Ñ‹`
--

DROP TABLE IF EXISTS `Ð±ÑƒÐºÐ²Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð±ÑƒÐºÐ²Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð±ÑƒÐºÐ²Ð°` varchar(100) NOT NULL,
  `Ñ…Ð²Ð¾ÑÑ‚Ð¸Ðº` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡_fk0` (`Ð±ÑƒÐºÐ²Ð°`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð±ÑƒÐºÐ²Ñ‹`
--

LOCK TABLES `Ð±ÑƒÐºÐ²Ñ‹` WRITE;
/*!40000 ALTER TABLE `Ð±ÑƒÐºÐ²Ñ‹` DISABLE KEYS */;
INSERT INTO `Ð±ÑƒÐºÐ²Ñ‹` VALUES (1,'C','0'),(2,'C','1'),(3,'E','c'),(4,'E','p'),(7,'P','r'),(8,'P','o'),(9,'C','2'),(10,'C','3'),(11,'C','4a'),(12,'C','4b'),(13,'C','5'),(14,'C','6'),(15,'E','s'),(16,'E','n'),(17,'A','s'),(18,'A','p'),(19,'A','d'),(20,'A','n'),(21,'P','r,o'),(22,'P','n');
/*!40000 ALTER TABLE `Ð±ÑƒÐºÐ²Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ`
--

DROP TABLE IF EXISTS `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ` (
  `id_Ð²Ð¸Ð´Ð°` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(40) NOT NULL,
  PRIMARY KEY (`id_Ð²Ð¸Ð´Ð°`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ`
--

LOCK TABLES `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ` WRITE;
/*!40000 ALTER TABLE `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ` DISABLE KEYS */;
INSERT INTO `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ` VALUES (1,'Ð¸Ð·Ð²Ð¸Ñ‚Ð¾Ð¹ Ñ…Ð¾Ð´ Ð² Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼ Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ'),(2,'Ð¿Ñ€ÑÐ¼Ð¾Ð»Ð¸Ð½ÐµÐ¹Ð½Ñ‹Ð¹ Ñ…Ð¾Ð´ Ð² Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼ Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ');
/*!40000 ALTER TABLE `Ñ…Ð¾Ð´_Ð²_Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð¾Ð¼_Ñ„ÑƒÑ‚Ð»ÑÑ€Ðµ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°` VALUES (1,'ÐžÐ±Ñ‹Ñ‡Ð½Ñ‹Ð¹'),(2,'Ð Ð°ÑÑˆÐ¸Ñ€ÐµÐ½Ð½Ñ‹Ð¹');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð°Ð½Ð°Ð»Ð¸Ð·Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°` VALUES (1,'ÑÐµÐ¿Ñ‚Ð¾Ð½ÐµÑÑ‚'),(2,'Ð»Ð¸Ð´Ð¾ÐºÐ°Ð¸Ð½');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð°Ð½ÐµÑÑ‚ÐµÐ·Ð¸ÐºÐ°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±` VALUES (1,'ÐÐ° Ð½Ð°Ð»Ð¸Ñ‡Ð¸Ðµ Ð¾Ñ‰ÑƒÑ‰ÐµÐ½Ð¸Ñ Ñ‚ÑÐ¶ÐµÑÑ‚Ð¸, Ð±Ñ‹ÑÑ‚Ñ€ÑƒÑŽ ÑƒÑ‚Ð¾Ð¼Ð»ÑÐµÐ¼Ð¾ÑÑ‚ÑŒ, Ð½Ð¾Ñ‡Ð½Ñ‹Ðµ ÑÑƒÐ´Ð¾Ñ€Ð¾Ð³Ð¸.'),(2,'ÐÐ° Ð³Ð¸Ð¿ÐµÑ€Ð¿ÐµÐ³Ð¼ÐµÐ½Ñ‚Ð°Ñ†Ð¸ÑŽ Ð² Ð¾Ð±Ð»Ð°ÑÑ‚Ð¸ Ð³Ð¾Ð»ÐµÐ½Ð¸ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(3,'ÐÐ° Ð³Ð¸Ð¿ÐµÑ€Ð¿ÐµÐ³Ð¼ÐµÐ½Ñ‚Ð°Ñ†Ð¸ÑŽ Ð² Ð¾Ð±Ð»Ð°ÑÑ‚Ð¸ Ð³Ð¾Ð»ÐµÐ½Ð¸ Ð»ÐµÐ²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(4,'ÐÐ° Ð³Ð¸Ð¿ÐµÑ€Ð¿ÐµÐ³Ð¼ÐµÐ½Ñ‚Ð°Ñ†Ð¸ÑŽ Ð² Ð¾Ð±Ð»Ð°ÑÑ‚Ð¸ Ð³Ð¾Ð»ÐµÐ½Ð¸ Ð¾Ð±ÐµÐ¸Ñ… Ð½Ð¸Ð¶Ð½Ð¸Ñ… ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚ÐºÐ¹.'),(5,'ÐŸÑ€Ð°Ð²Ð°Ñ Ð½Ð¸Ð¶Ð½ÑÑ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚ÑŒ Ð½Ðµ Ð±ÐµÑÐ¿Ð¾ÐºÐ¾Ð¸Ñ‚.'),(6,'Ð›ÐµÐ²Ð°Ñ Ð½Ð¸Ð¶Ð½ÑÑ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚ÑŒ Ð½Ðµ Ð±ÐµÑÐ¿Ð¾ÐºÐ¾Ð¸Ñ‚.');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` VALUES (4,'Ð²Ñ‹ÑÑˆÐ°Ñ'),(3,'Ð¿ÐµÑ€Ð²Ð°Ñ');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹` VALUES (4,'Ð´Ð¾ÐºÑ‚Ð¾Ñ€_Ð½Ð°ÑƒÐº'),(3,'Ð¿Ñ€Ð¾Ñ„ÐµÑÑÐ¾Ñ€');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÐºÐ¾Ñ€Ð¾Ñ‚ÐºÐ¾Ðµ_Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(20) NOT NULL,
  `Ð´Ð»Ð¸Ð½Ð½Ð¾Ðµ_Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` VALUES (1,'Ð­Ð’Ð','Ð­Ð½Ð´Ð¾ÑÐºÐ¾Ð¿Ð¸Ñ‡ÐµÑÐºÐ°Ñ Ð´Ð¸ÑÑÐµÐºÑ†Ð¸Ñ Ð²ÐµÐ½'),(2,'Ð¤Ð»ÐµÐ±ÑÐºÑ‚Ð¾Ð¼Ð¸Ñ','Ð¤Ð»ÐµÐ±ÑÐºÑ‚Ð¾Ð¼Ð¸Ñ'),(3,'Ð­Ð›Ðš','Ð­Ð½Ð´Ð¾Ð²Ð°Ð·Ð°Ð»ÑŒÐ½Ð°Ñ Ð»Ð°Ð·ÐµÑ€Ð½Ð°Ñ ÐºÐ¾Ð°Ð³ÑƒÐ»ÑÑ†Ð¸Ñ'),(9,'asd','dsa'),(10,'123','123'),(11,'sss','sss'),(12,'Ð¶Ð´Ð¶','Ð¶Ð¶'),(13,'ÑˆÐ´Ð³','Ð´ÑˆÐ³'),(14,'Ñ–Ñ„Ñ','Ñ„Ñ–Ð²');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(150) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹` VALUES (2,'Ð•Ñ€ÐµÑÑŒ'),(3,'Ð•Ñ€ÐµÑÑŒ'),(4,'ÐµÑ€ÐµÑÑŒ'),(5,'Ð“Ð»Ñ”Ðº'),(6,'zzz'),(7,'uuu'),(8,'333333'),(9,'444444'),(10,'fgrg4'),(11,'wqeweqewqeweqe'),(12,'zxzxzxzcxzcxzxzcxzcx'),(13,'44445'),(14,'112'),(15,'7'),(16,'9'),(17,'888');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹` VALUES (1,'Ð¾Ð¿ÐµÑ€Ð°Ñ‚Ð¸Ð²Ð½Ð¾Ðµ Ð»ÐµÑ‡ÐµÐ½Ð¸Ðµ Ð² Ð¿Ð»Ð°Ð½Ð¾Ð²Ð¾Ð¼ Ð¿Ð¾Ñ€ÑÐ´ÐºÐµ'),(2,'ÐºÐ¾Ð¼Ð¿Ñ€ÐµÑÑÐ¸Ð¾Ð½Ð½Ñ‹Ð¹ Ñ‚Ñ€Ð¸ÐºÐ¾Ñ‚Ð°Ð¶ 2 ÐºÐ»Ð°ÑÑÐ° ÐºÐ¾Ð¼Ð¿Ñ€ÐµÑÑÐ¸Ð¸ (Ñ‡ÑƒÐ»ÐºÐ¸)'),(3,'ÐºÐ¾Ð¼Ð¿Ñ€ÐµÑÑÐ¸Ð¾Ð½Ð½Ñ‹Ð¹ Ñ‚Ñ€Ð¸ÐºÐ¾Ñ‚Ð°Ð¶ 2 ÐºÐ»Ð°ÑÑÐ° ÐºÐ¾Ð¼Ð¿Ñ€ÐµÑÑÐ¸Ð¸ (Ð³Ð¾Ð»ÑŒÑ„Ñ‹)'),(4,'Ð´Ð²Ð¸Ð³Ð°Ñ‚ÐµÐ»ÑŒÐ½Ð°Ñ Ð°ÐºÑ‚Ð¸Ð²Ð½Ð¾ÑÑ‚ÑŒ (Ñ…Ð¾Ð´ÑŒÐ±Ð°), Ð¾Ð³Ñ€Ð°Ð½Ð¸Ñ‡Ð¸Ñ‚ÑŒ Ð¿Ð¾Ð´Ð½ÑÑ‚Ð¸Ðµ Ñ‚ÑÐ¶ÐµÑÑ‚ÐµÐ¹');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹`
--

LOCK TABLES `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹` VALUES (13,'ÐÐ»Ð»ÐµÑ€Ð³Ð¾Ð»Ð¾Ð³'),(6,'Ð³Ð»Ð°Ð²Ð½Ñ‹Ð¹ Ð²Ñ€Ð°Ñ‡'),(7,'Ð´ÐµÑ€Ð¼Ð°Ñ‚Ð¾Ð»Ð¾Ð³'),(12,'ÐÐµÐ²Ñ€Ð¾Ð»Ð¾Ð³'),(9,'Ð¾ÐºÑƒÐ»Ð¸ÑÑ‚'),(10,'ÐžÑ‚Ð¾Ñ€Ð¸Ð½Ð¾Ð»Ð°Ñ€Ð¸Ð½Ð³Ð¾Ð»Ð¾Ð³'),(11,'Ð¡Ñ‚Ð¾Ð¼Ð°Ñ‚Ð¾Ð»Ð¾Ð³'),(5,'Ñ„Ð»ÐµÐ±Ð¾Ð»Ð¾Ð³'),(8,'Ñ…Ð¸Ñ€ÑƒÑ€Ð³');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°` (
  `id_Ð²Ð¸Ð´Ð°` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(40) NOT NULL,
  PRIMARY KEY (`id_Ð²Ð¸Ð´Ð°`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°`
--

LOCK TABLES `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°` VALUES (1,'Ð¾Ð±Ñ‹Ñ‡Ð½Ñ‹Ð¹'),(2,'Ð³Ð¸Ð±Ñ€Ð¸Ð´Ð½Ñ‹Ð¹');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð±Ð¿Ð²_Ñ…Ð¾Ð´Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` (
  `id_Ð²Ð¸Ð´Ð°` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(200) NOT NULL,
  PRIMARY KEY (`id_Ð²Ð¸Ð´Ð°`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·`
--

LOCK TABLES `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` VALUES (1,'Ð’Ð°Ñ€Ð¸ÐºÐ¾Ð·Ð½Ð°Ñ Ð±Ð¾Ð»ÐµÐ·Ð½ÑŒ Ð² Ð±Ð°ÑÑÐµÐ¹Ð½Ðµ Ð±Ð¾Ð»ÑŒÑˆÐ¾Ð¹ Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹ Ð²ÐµÐ½Ñ‹ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(2,'ÐÐ°Ñ‡Ð°Ð»ÑŒÐ½Ñ‹Ðµ Ð¿Ñ€Ð¾ÑÐ²Ð»ÐµÐ½Ð¸Ñ Ð²Ð°Ñ€Ð¸ÐºÐ¾Ð·Ð½Ð¾Ð¹ Ð±Ð¾Ð»ÐµÐ·Ð½Ð¸ Ð² Ð±Ð°ÑÑÐµÐ¹Ð½Ðµ Ð±Ð¾Ð»ÑŒÑˆÐ¾Ð¹ Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(3,'Ð’Ð°Ñ€Ð¸ÐºÐ¾Ð·Ð½Ð°Ñ Ð±Ð¾Ð»ÐµÐ·Ð½ÑŒ Ð² Ð±Ð°ÑÑÐµÐ¹Ð½Ðµ Ð¼Ð°Ð»Ð¾Ð¹ Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹ Ð²ÐµÐ½Ñ‹ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(4,'ÐÐ°Ñ‡Ð°Ð»ÑŒÐ½Ñ‹Ðµ Ð¿Ñ€Ð¾ÑÐ²Ð»ÐµÐ½Ð¸Ñ Ð²Ð°Ñ€Ð¸ÐºÐ¾Ð·Ð½Ð¾Ð¹ Ð±Ð¾Ð»ÐµÐ·Ð½Ð¸ Ð² Ð±Ð°ÑÑÐµÐ¹Ð½Ðµ Ð¼Ð°Ð»Ð¾Ð¹ Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(5,'ÐÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ð¹ Ð²Ð°Ñ€Ð¸ÐºÐ¾Ð· Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(6,'Ð ÐµÑ‚Ð¸ÐºÑƒÐ»ÑÑ€Ð½Ñ‹Ð¹ Ð²Ð°Ñ€Ð¸ÐºÐ¾Ð· Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(7,'ÐÐµÑ‚ Ð´Ð°Ð½Ð½Ñ‹Ñ… Ð·Ð° Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·, ÐºÐ»Ð°Ð¿Ð°Ð½Ð½ÑƒÑŽ Ð½ÐµÐ´Ð¾ÑÑ‚Ð°Ñ‚Ð¾Ñ‡Ð½Ð¾ÑÑ‚ÑŒ Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ñ… Ð¸ Ð¿Ð¾Ð²ÐµÑ€Ñ…Ð½Ð¾ÑÑ‚Ð½Ñ‹Ñ… Ð²ÐµÐ½ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(8,'ÐžÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰Ð¸Ð¹ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð· ÑÑ‚Ð²Ð¾Ð»Ð° Ð‘ÐŸÐ’ Ð½Ð° Ð±ÐµÐ´Ñ€Ðµ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(9,'ÐžÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰Ð¸Ð¹ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð· ÑÑ‚Ð²Ð¾Ð»Ð° Ð‘ÐŸÐ’ Ð½Ð° Ð³Ð¾Ð»ÐµÐ½Ð¸ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.'),(10,'ÐžÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰Ð¸Ð¹ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð· ÑÑ‚Ð²Ð¾Ð»Ð° Ð‘ÐŸÐ’ Ð½Ð° Ð±ÐµÐ´Ñ€Ðµ Ð¸ Ð³Ð¾Ð»ÐµÐ½Ð¸ Ð¿Ñ€Ð°Ð²Ð¾Ð¹ Ð½Ð¸Ð¶Ð½ÐµÐ¹ ÐºÐ¾Ð½ÐµÑ‡Ð½Ð¾ÑÑ‚Ð¸.');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°` (
  `id_Ð²Ð¸Ð´Ð°` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(40) NOT NULL,
  PRIMARY KEY (`id_Ð²Ð¸Ð´Ð°`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°`
--

LOCK TABLES `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°`
--

DROP TABLE IF EXISTS `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°` (
  `id_Ð²Ð¸Ð´Ð°` int(11) NOT NULL,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(40) NOT NULL,
  PRIMARY KEY (`id_Ð²Ð¸Ð´Ð°`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°`
--

LOCK TABLES `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°` WRITE;
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°` DISABLE KEYS */;
INSERT INTO `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°` VALUES (1,'Ð¾Ð±Ñ‹Ñ‡Ð½Ñ‹Ð¹'),(2,'Ð¸Ð·Ð²Ð¸Ñ‚Ð¾Ð¹');
/*!40000 ALTER TABLE `Ð²Ð¸Ð´_Ð¿Ð´ÑÐ²_Ñ…Ð¾Ð´Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ñ€Ð°Ñ‡Ð¸`
--

DROP TABLE IF EXISTS `Ð²Ñ€Ð°Ñ‡Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ñ€Ð°Ñ‡Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¸Ð¼Ñ` varchar(20) NOT NULL,
  `Ñ„Ð°Ð¼Ð¸Ð»Ð¸Ñ` varchar(40) NOT NULL,
  `Ð¾Ñ‚Ñ‡ÐµÑÑ‚Ð²Ð¾` varchar(40) NOT NULL,
  `Ð´Ð¾Ð¿Ð¾Ð»Ð½Ð¸Ñ‚ÐµÐ»ÑŒÐ½Ð°Ñ_Ð¸Ð½Ñ„Ð¾Ñ€Ð¼Ð°Ñ†Ð¸Ñ` varchar(100) DEFAULT NULL,
  `enabled/disabled` tinyint(4) DEFAULT NULL,
  `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ñ` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ñ€Ð°Ñ‡Ð¸`
--

LOCK TABLES `Ð²Ñ€Ð°Ñ‡Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð²Ñ€Ð°Ñ‡Ð¸` DISABLE KEYS */;
INSERT INTO `Ð²Ñ€Ð°Ñ‡Ð¸` VALUES (4,'Ð¡ÐµÑ€Ð³ÐµÐµÐ²Ð½Ð°','ÐžÐºÑÐ°Ð½Ð°','Ð ÑÐ±Ð¸Ð½ÑÐºÐ°Ñ','Ð¾Ñ‡ÐµÐ½ÑŒ ÐºÐ»Ð°ÑÑÐ½Ð°Ñ Ð¶ÐµÐ½Ñ‰Ð¸Ð½Ð°',1,NULL),(5,'Ð’Ð¸Ñ‚Ð°Ð»Ð¸Ð¹','Ð¨Ñ‚Ð¾Ñ€Ð³Ð¸Ð½','Ð’Ð»Ð°Ð´Ð¸Ð¼Ð¸Ñ€Ð¾Ð²Ð¸Ñ‡','ÑƒÐ¼ÐµÐµÑ‚ Ñ€Ð°Ð±Ð¾Ñ‚Ð°Ñ‚ÑŒ Ñ Excel',1,NULL),(6,'Ð¡ÐµÑ€Ð³ÐµÐ¹','Ð—Ð°Ð¼Ñ‡Ð¸Ð¹','Ð’Ð»Ð°Ð´Ð¸Ð¼Ð¸Ñ€Ð¾Ð²Ð¸Ñ‡','',1,1),(7,'ÐžÐ´Ð¸Ð½','Ñ„Ñ–Ð²','Ñ–Ñ„',NULL,0,5),(8,'Ð½Ð¾Ð²Ñ‹Ð¹ Ð²Ñ€Ð°Ñ‡','Ð½Ð¾Ð²Ñ‹Ð¹ Ð²Ñ€Ð°Ñ‡','Ð½Ð¾Ð²Ñ‹Ð¹ Ð²Ñ€Ð°Ñ‡',NULL,1,1),(9,'Ð¾','Denis','Ðµ','ssss',0,NULL),(10,'2','2','2',NULL,0,0),(11,'dsfe','dsf','sef','sdf',0,NULL),(12,'333','333','333',NULL,0,NULL),(13,'Ð¿ÐµÐ¿','Ð¿Ðµ','ÐµÐ¿',NULL,0,NULL),(14,'ÑˆÐµÑ€ÑˆÐµÐ½ÑŒ','ÑˆÐµÑ€ÑˆÐµÐ½ÑŒ','Ñˆ','55555',0,NULL),(15,'df','df','9df','9d',0,NULL),(16,'edd','dd','dd',NULL,1,NULL),(17,'df','df','df','df',1,4),(18,'kiii','oiii','oiii',NULL,1,2),(19,'77777','oiii','oiii',NULL,1,2),(20,'77777','i8888','oiii',NULL,1,0),(21,'0','000','0',NULL,1,0);
/*!40000 ALTER TABLE `Ð²Ñ€Ð°Ñ‡Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` (
  `id_Ð²Ñ€Ð°Ñ‡Ð°` int(11) NOT NULL,
  `id_ÑÐ¿ÐµÑ†Ð¸Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id_Ð²Ñ€Ð°Ñ‡Ð°`,`id_ÑÐ¿ÐµÑ†Ð¸Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`),
  KEY `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸_fk1` (`id_ÑÐ¿ÐµÑ†Ð¸Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`),
  CONSTRAINT `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸_fk0` FOREIGN KEY (`id_Ð²Ñ€Ð°Ñ‡Ð°`) REFERENCES `Ð²Ñ€Ð°Ñ‡Ð¸` (`id`),
  CONSTRAINT `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸_fk1` FOREIGN KEY (`id_ÑÐ¿ÐµÑ†Ð¸Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` VALUES (4,5),(4,6),(12,6),(15,6),(4,7),(11,7),(12,7),(15,7),(4,8),(4,9),(4,10),(4,11),(4,12),(11,12),(12,12),(15,12),(4,13),(14,13),(17,13),(18,13);
/*!40000 ALTER TABLE `Ð²Ñ€Ð°Ñ‡Ð¸_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð³Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð³Ð²_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð³Ð²_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð“Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk0_idx` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð“Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk1_idx` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  CONSTRAINT `Ð“Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Ð“Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð³Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð³Ð²_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð³Ð²_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð³Ð²_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(50) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð“Ð’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0_idx` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð“Ð’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð“Ð’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0_idx` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð“Ð’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð³Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹`
--

DROP TABLE IF EXISTS `Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð“Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹_fk0_idx` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð“Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹_fk1_idx` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  CONSTRAINT `Ð“Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Ð“Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð³Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹`
--

LOCK TABLES `Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹` WRITE;
/*!40000 ALTER TABLE `Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·`
--

DROP TABLE IF EXISTS `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` (
  `id_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` int(11) NOT NULL,
  `id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) NOT NULL,
  `isLeft` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·`,`id_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`,`isLeft`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·`
--

LOCK TABLES `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` WRITE;
/*!40000 ALTER TABLE `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` DISABLE KEYS */;
INSERT INTO `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` VALUES (3,8,0),(4,6,0),(4,7,0),(4,8,0),(4,8,1),(5,3,1),(6,10,1),(7,2,0),(7,2,1),(7,6,1),(7,10,1),(8,5,0),(8,5,1),(9,8,1),(9,9,1),(10,3,0),(10,4,0),(10,4,1),(10,7,1),(10,8,0),(10,8,1),(10,9,0),(10,9,1),(10,10,0),(15,1,1),(18,2,0),(18,3,0),(18,4,0),(18,5,0),(18,6,0),(18,7,0),(19,1,0),(19,2,1),(19,3,1),(19,4,1),(19,5,1),(19,6,1),(19,7,1);
/*!40000 ALTER TABLE `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ`
--

DROP TABLE IF EXISTS `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` (
  `id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` int(11) DEFAULT NULL,
  `id_Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·` int(11) DEFAULT NULL,
  `isLeft` tinyint(1) DEFAULT NULL,
  KEY `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸`),
  CONSTRAINT `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` FOREIGN KEY (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸`) REFERENCES `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ`
--

LOCK TABLES `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` WRITE;
/*!40000 ALTER TABLE `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð´Ð¸Ð°Ð³Ð½Ð¾Ð·_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ðµ`
--

DROP TABLE IF EXISTS `Ðµ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ðµ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð±ÑƒÐºÐ²Ñ‹` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð•_fk0` (`Ð±ÑƒÐºÐ²Ñ‹`),
  CONSTRAINT `Ð•_fk0` FOREIGN KEY (`Ð±ÑƒÐºÐ²Ñ‹`) REFERENCES `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ðµ`
--

LOCK TABLES `Ðµ` WRITE;
/*!40000 ALTER TABLE `Ðµ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ðµ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¶Ð°Ð»Ð¾Ð±Ñ‹`
--

DROP TABLE IF EXISTS `Ð¶Ð°Ð»Ð¾Ð±Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¶Ð°Ð»Ð¾Ð±Ñ‹` (
  `id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ` int(11) NOT NULL,
  `id_Ð¶Ð°Ð»Ð¾Ð±Ñ‹` int(11) NOT NULL,
  PRIMARY KEY (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`,`id_Ð¶Ð°Ð»Ð¾Ð±Ñ‹`),
  KEY `Ð¶Ð°Ð»Ð¾Ð±Ñ‹_fk1` (`id_Ð¶Ð°Ð»Ð¾Ð±Ñ‹`),
  CONSTRAINT `Ð¶Ð°Ð»Ð¾Ð±Ñ‹_fk0` FOREIGN KEY (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`) REFERENCES `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` (`id`),
  CONSTRAINT `Ð¶Ð°Ð»Ð¾Ð±Ñ‹_fk1` FOREIGN KEY (`id_Ð¶Ð°Ð»Ð¾Ð±Ñ‹`) REFERENCES `Ð²Ð¸Ð´Ñ‹_Ð¶Ð°Ð»Ð¾Ð±` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¶Ð°Ð»Ð¾Ð±Ñ‹`
--

LOCK TABLES `Ð¶Ð°Ð»Ð¾Ð±Ñ‹` WRITE;
/*!40000 ALTER TABLE `Ð¶Ð°Ð»Ð¾Ð±Ñ‹` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¶Ð°Ð»Ð¾Ð±Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

DROP TABLE IF EXISTS `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  CONSTRAINT `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

LOCK TABLES `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` WRITE;
/*!40000 ALTER TABLE `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð·Ð²Ð°Ð½Ð¸Ñ`
--

DROP TABLE IF EXISTS `Ð·Ð²Ð°Ð½Ð¸Ñ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð·Ð²Ð°Ð½Ð¸Ñ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(30) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð·Ð²Ð°Ð½Ð¸Ñ`
--

LOCK TABLES `Ð·Ð²Ð°Ð½Ð¸Ñ` WRITE;
/*!40000 ALTER TABLE `Ð·Ð²Ð°Ð½Ð¸Ñ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð·Ð²Ð°Ð½Ð¸Ñ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð—Ð”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð—Ð”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `Ð—Ð”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  CONSTRAINT `Ð—Ð”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð—Ð”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð—Ð”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2,3),(2,1,2,4),(3,1,2,5),(4,1,2,6),(5,1,2,7),(6,1,2,8),(7,1,2,9),(8,1,10,3),(9,1,10,4),(10,1,10,5),(11,1,10,6),(12,1,10,7),(13,1,10,8),(14,1,10,9),(15,11,2,3),(16,11,2,4),(17,11,2,5),(18,11,2,6),(19,11,2,7),(20,11,2,8),(21,11,2,9),(22,11,10,3),(23,11,10,4),(24,11,10,5),(25,11,10,6),(26,11,10,7),(27,11,10,8),(28,11,10,9),(29,1,2,12),(30,1,NULL,NULL),(31,11,NULL,NULL);
/*!40000 ALTER TABLE `Ð·Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð—Ð”Ð¡Ð’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð—Ð”Ð¡Ð’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð·Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð—Ð”Ð¡Ð’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð—Ð”Ð¡Ð’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'Ð—Ð”Ð¡Ð’ Ð±ÐµÐ· Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,1),(2,'Ð˜Ð¼ÐµÐµÑ‚ Ð¿Ñ€ÑÐ¼Ð¾Ð»Ð¸Ð½ÐµÐ¹Ð½Ñ‹Ð¹ Ñ…Ð¾Ð´.',NULL,0,NULL,2),(3,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð—Ð”Ð¡Ð’ Ð±ÐµÐ· Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ°.',NULL,0,NULL,3),(4,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð—Ð”Ð¡Ð’ Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(5,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð—Ð”Ð¡Ð’ Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼ Ð¸ Ð¾ÑÑ‚Ð°Ñ‚Ð¾Ñ‡Ð½Ñ‹Ð¼Ð¸ ÑÐ²Ð»ÐµÐ½Ð¸ÑÐ¼Ð¸ Ð¿ÐµÑ€ÐµÐ½ÐµÑÐµÐ½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(6,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð—Ð”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(7,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð—Ð”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð½ÐµÐ¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(8,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð—Ð”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ñ‡Ð°ÑÑ‚Ð¸Ñ‡Ð½Ð¾ Ñ€ÐµÐºÐ°Ð½Ð°Ð»Ð¸Ð·Ð¸Ñ€Ð¾Ð²Ð°Ð½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(9,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ Ð—Ð”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ ÑÐºÐ»ÐµÑ€Ð¾Ð¾Ð±Ð»Ð¸Ñ‚ÐµÑ€Ð°Ñ†Ð¸Ð¸, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(10,'Ð˜Ð¼ÐµÐµÑ‚ Ð¸Ð·Ð²Ð¸Ñ‚Ð¾Ð¹ Ñ…Ð¾Ð´.',NULL,0,NULL,2),(11,'Ð—Ð”Ð¡Ð’ Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾3Ð¼',NULL,1,1,1),(12,'nththt','jjj',1,3,3);
/*!40000 ALTER TABLE `Ð·Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹`
--

DROP TABLE IF EXISTS `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ð°` int(11) NOT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ_Ñ‚Ð°Ð±Ð»Ð¸Ñ†Ñ‹` varchar(50) NOT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ_ÑÑ‚Ð¾Ð»Ð±Ñ†Ð°` varchar(50) NOT NULL,
  `Ð´Ð°Ñ‚Ð°_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ñ` datetime NOT NULL,
  `ÑÑ‚Ð°Ñ€Ð¾Ðµ_Ð·Ð½Ð°Ñ‡ÐµÐ½Ð¸Ðµ` varchar(200) DEFAULT NULL,
  `Ð½Ð¾Ð²Ð¾Ðµ_Ð·Ð½Ð°Ñ‡ÐµÐ½Ð¸Ðµ` varchar(200) DEFAULT NULL,
  `Ñ‚Ð¸Ð¿_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ñ` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹_fk0` (`id_Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ð°`),
  KEY `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹_fk1` (`Ñ‚Ð¸Ð¿_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ñ`),
  CONSTRAINT `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹_fk0` FOREIGN KEY (`id_Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ð°`) REFERENCES `Ð°ÐºÐºÐ°ÑƒÐ½Ñ‚Ñ‹` (`id`),
  CONSTRAINT `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹_fk1` FOREIGN KEY (`Ñ‚Ð¸Ð¿_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ñ`) REFERENCES `Ð²Ð¸Ð´Ñ‹_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹`
--

LOCK TABLES `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` WRITE;
/*!40000 ALTER TABLE `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¸ÑÑ‚Ð¾Ñ€Ð¸Ñ_Ð¸Ð·Ð¼ÐµÐ½ÐµÐ½Ð¸Ð¹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(200) NOT NULL,
  `id_ÑÐ»ÐµÐ´ÑƒÑ‰ÐµÐ¹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸_fk0` (`id_ÑÐ»ÐµÐ´ÑƒÑ‰ÐµÐ¹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  CONSTRAINT `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸_fk0` FOREIGN KEY (`id_ÑÐ»ÐµÐ´ÑƒÑ‰ÐµÐ¹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` VALUES (1,'Ð²Ð°Ñ‹Ð²Ð°Ñ‹',NULL),(2,'Ð²Ñ–Ð°Ñ–Ð°Ð²',NULL),(3,'3424ÑƒÑ†',NULL);
/*!40000 ALTER TABLE `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`
--

DROP TABLE IF EXISTS `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(5) NOT NULL,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`
--

LOCK TABLES `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` WRITE;
/*!40000 ALTER TABLE `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` DISABLE KEYS */;
/*!40000 ALTER TABLE `ÑÑ‚Ð¸Ð¾Ð»Ð¾Ð³Ð¸Ñ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸`
--

DROP TABLE IF EXISTS `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` (
  `id_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` int(11) NOT NULL,
  `id_Ð²Ñ€Ð°Ñ‡Ð°` int(11) NOT NULL,
  PRIMARY KEY (`id_ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸`,`id_Ð²Ñ€Ð°Ñ‡Ð°`),
  KEY `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸_fk0` (`id_Ð²Ñ€Ð°Ñ‡Ð°`),
  CONSTRAINT `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸_fk0` FOREIGN KEY (`id_Ð²Ñ€Ð°Ñ‡Ð°`) REFERENCES `Ð²Ñ€Ð°Ñ‡Ð¸` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸`
--

LOCK TABLES `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` VALUES (2,1),(1,3);
/*!40000 ALTER TABLE `ÐºÐ°Ñ‚ÐµÐ³Ð¾Ñ€Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

DROP TABLE IF EXISTS `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4` int(11) DEFAULT NULL,
  `Ð²Ð¸Ð´_Ñ…Ð¾Ð´Ð°` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  KEY `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk3` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`),
  KEY `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk4` (`Ð²Ð¸Ð´_Ñ…Ð¾Ð´Ð°`),
  CONSTRAINT `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk3` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`) REFERENCES `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `ÐœÐ°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk4` FOREIGN KEY (`Ð²Ð¸Ð´_Ñ…Ð¾Ð´Ð°`) REFERENCES `Ð²Ð¸Ð´_Ð¼Ð¿Ð²_Ñ…Ð¾Ð´Ð°` (`id_Ð²Ð¸Ð´Ð°`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

LOCK TABLES `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`
--

DROP TABLE IF EXISTS `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¸Ð¼Ñ` varchar(45) DEFAULT NULL,
  `Ñ„Ð°Ð¼Ð¸Ð»Ð¸Ñ` varchar(45) DEFAULT NULL,
  `Ð¾Ñ‚Ñ‡ÐµÑÑ‚Ð²Ð¾` varchar(45) DEFAULT NULL,
  `enabled/disabled` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»`
--

LOCK TABLES `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` WRITE;
/*!40000 ALTER TABLE `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` DISABLE KEYS */;
INSERT INTO `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` VALUES (1,'ÐÐ½Ð´Ñ€ÐµÐ¹','Ð›Ð¾Ð·Ñ‹Ñ‡ÐµÐ½ÐºÐ¾!!!','ÐŸÐµÑ‚Ñ€Ð¾Ð²Ð¸Ñ‡',1),(2,'Ð’Ð»Ð°Ð´','Ð˜Ð²Ð°Ð½Ð¾Ð²','ÐŸÐµÑ‚Ñ€Ð¾Ð²Ð¸Ñ‡',1),(3,'ÐÐ»Ð¼Ð°ÑˆÐ¸','Ð¯Ð½Ð¾Ñˆ','ÐŸÐµÑ‚Ñ€Ð¾Ð²Ð¸Ñ‡',1),(4,'34532','ÐŸÐµÑ‚Ñ€','k',1);
/*!40000 ALTER TABLE `Ð¼ÐµÐ´Ð¿ÐµÑ€ÑÐ¾Ð½Ð°Ð»` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°`
--

DROP TABLE IF EXISTS `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°`
--

LOCK TABLES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` WRITE;
/*!40000 ALTER TABLE `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` DISABLE KEYS */;
INSERT INTO `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` VALUES (20,NULL),(1,''),(18,'1'),(19,'2'),(17,'33'),(13,'dd'),(16,'dfs'),(14,'eeeee'),(8,'gr'),(7,'wp'),(2,'Ð¼Ð¼'),(3,'ÑÐ¼');
/*!40000 ALTER TABLE `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  KEY `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk3` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`),
  CONSTRAINT `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk3` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`) REFERENCES `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2,NULL,NULL),(2,1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐœÐŸÐ’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `ÐœÐŸÐ’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐœÐŸÐ’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `ÐœÐŸÐ’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'1','',NULL,0,1),(2,'2','',NULL,0,2);
/*!40000 ALTER TABLE `Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ`
--

DROP TABLE IF EXISTS `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ` (
  `id_Ð·Ð²Ð°Ð½Ð¸Ñ` int(11) NOT NULL,
  `id_Ð²Ñ€Ð°Ñ‡Ð°` int(11) NOT NULL,
  PRIMARY KEY (`id_Ð·Ð²Ð°Ð½Ð¸Ñ`,`id_Ð²Ñ€Ð°Ñ‡Ð°`),
  KEY `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ_fk0` (`id_Ð²Ñ€Ð°Ñ‡Ð°`),
  CONSTRAINT `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ_fk0` FOREIGN KEY (`id_Ð²Ñ€Ð°Ñ‡Ð°`) REFERENCES `Ð²Ñ€Ð°Ñ‡Ð¸` (`id`),
  CONSTRAINT `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ_fk1` FOREIGN KEY (`id_Ð·Ð²Ð°Ð½Ð¸Ñ`) REFERENCES `Ð²Ð¸Ð´Ñ‹_Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ñ…_Ð·Ð²Ð°Ð½Ð¸Ð¹` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ`
--

LOCK TABLES `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ` WRITE;
/*!40000 ALTER TABLE `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ` DISABLE KEYS */;
INSERT INTO `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ` VALUES (1,1),(2,2),(2,3),(3,4),(4,4),(3,11),(3,12),(4,13),(3,14),(4,15),(3,17),(4,18);
/*!40000 ALTER TABLE `Ð½Ð°ÑƒÑ‡Ð½Ñ‹Ðµ_Ð·Ð²Ð°Ð½Ð¸Ñ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ`
--

DROP TABLE IF EXISTS `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°` int(11) NOT NULL,
  `Ð´Ð°Ñ‚Ð°_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ` date NOT NULL,
  `Ð²ÐµÑ` float NOT NULL,
  `Ñ€Ð¾ÑÑ‚` float NOT NULL,
  `id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ_Ð¿Ñ€Ð°Ð²Ð¾Ð¹_Ð½Ð¾Ð³Ð¸` int(11) NOT NULL,
  `id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ_Ð»ÐµÐ²Ð¾Ð¹_Ð½Ð¾Ð³Ð¸` int(11) NOT NULL,
  `id_Ð²Ñ€Ð°Ñ‡Ð°` int(11) DEFAULT NULL,
  `NB!` varchar(60) DEFAULT NULL,
  `Ð½ÑƒÐ¶Ð½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ñ` tinyint(1) NOT NULL,
  `Ð²Ð¸Ð´_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) DEFAULT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹_Ðº_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk0` (`id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk1` (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ_Ð¿Ñ€Ð°Ð²Ð¾Ð¹_Ð½Ð¾Ð³Ð¸`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk2` (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ_Ð»ÐµÐ²Ð¾Ð¹_Ð½Ð¾Ð³Ð¸`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk3` (`Ð²Ð¸Ð´_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk0` FOREIGN KEY (`id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°`) REFERENCES `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk1` FOREIGN KEY (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ_Ð¿Ñ€Ð°Ð²Ð¾Ð¹_Ð½Ð¾Ð³Ð¸`) REFERENCES `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk2` FOREIGN KEY (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ_Ð»ÐµÐ²Ð¾Ð¹_Ð½Ð¾Ð³Ð¸`) REFERENCES `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_fk3` FOREIGN KEY (`Ð²Ð¸Ð´_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð²Ð¸Ð´Ñ‹_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ`
--

LOCK TABLES `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` WRITE;
/*!40000 ALTER TABLE `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸`
--

DROP TABLE IF EXISTS `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` (
  `id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ` int(11) NOT NULL AUTO_INCREMENT,
  `id_Ð¡Ð¤Ð¡` int(11) NOT NULL,
  `id_Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ` int(11) NOT NULL,
  `id_ÐŸÐ”Ð¡Ð’` int(11) DEFAULT NULL,
  `id_Ð—Ð”Ð¡Ð’` int(11) DEFAULT NULL,
  `id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ñ‹_Ð±ÐµÐ´Ñ€Ð°` int(11) NOT NULL,
  `id_Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸` int(11) NOT NULL,
  `id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½Ð¸` int(11) DEFAULT NULL,
  `id_Ð¡ÐŸÐ¡` int(11) NOT NULL,
  `id_ÐœÐŸÐ’` int(11) NOT NULL,
  `id_Ð¢Ð•_ÐœÐŸÐ’` int(11) DEFAULT NULL,
  `id_ÐŸÐŸÐ’` int(11) DEFAULT NULL,
  `ÐŸÑ€Ð¸Ð¼ÐµÑ‡Ð°Ð½Ð¸Ðµ` varchar(300) DEFAULT NULL,
  `id_Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹` int(11) DEFAULT NULL,
  `C` int(11) NOT NULL,
  `E` int(11) NOT NULL,
  `A` int(11) NOT NULL,
  `P` int(11) NOT NULL,
  PRIMARY KEY (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`),
  UNIQUE KEY `id_Ð¡Ð¤Ð¡` (`id_Ð¡Ð¤Ð¡`),
  UNIQUE KEY `id_Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ` (`id_Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ`),
  UNIQUE KEY `id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ñ‹_Ð±ÐµÐ´Ñ€Ð°` (`id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ñ‹_Ð±ÐµÐ´Ñ€Ð°`),
  UNIQUE KEY `id_Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸` (`id_Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸`),
  UNIQUE KEY `id_Ð¡ÐŸÐ¡` (`id_Ð¡ÐŸÐ¡`),
  UNIQUE KEY `id_ÐœÐŸÐ’` (`id_ÐœÐŸÐ’`),
  UNIQUE KEY `id_ÐŸÐ”Ð¡Ð’` (`id_ÐŸÐ”Ð¡Ð’`),
  UNIQUE KEY `id_Ð—Ð”Ð¡Ð’` (`id_Ð—Ð”Ð¡Ð’`),
  UNIQUE KEY `id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½Ð¸` (`id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½Ð¸`),
  UNIQUE KEY `id_Ð¢Ð•_ÐœÐŸÐ’` (`id_Ð¢Ð•_ÐœÐŸÐ’`),
  UNIQUE KEY `id_ÐŸÐŸÐ’` (`id_ÐŸÐŸÐ’`),
  UNIQUE KEY `id_Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹` (`id_Ð³Ð»ÑƒÐ±Ð¾ÐºÐ¸Ðµ_Ð²ÐµÐ½Ñ‹`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk11` (`C`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk12` (`E`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk13` (`A`),
  KEY `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk14` (`P`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk0` FOREIGN KEY (`id_Ð¡Ð¤Ð¡`) REFERENCES `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk1` FOREIGN KEY (`id_Ð‘ÐŸÐ’_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ`) REFERENCES `Ð±Ð¾Ð»ÑŒÑˆÐ°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_Ð½Ð°_Ð±ÐµÐ´Ñ€Ðµ` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk10` FOREIGN KEY (`id_ÐŸÐŸÐ’`) REFERENCES `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk11` FOREIGN KEY (`C`) REFERENCES `Ð±ÑƒÐºÐ²Ñ‹` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk12` FOREIGN KEY (`E`) REFERENCES `Ðµ` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk13` FOREIGN KEY (`A`) REFERENCES `Ð°` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk14` FOREIGN KEY (`P`) REFERENCES `p` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk2` FOREIGN KEY (`id_ÐŸÐ”Ð¡Ð’`) REFERENCES `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk3` FOREIGN KEY (`id_Ð—Ð”Ð¡Ð’`) REFERENCES `Ð·Ð°Ð´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk4` FOREIGN KEY (`id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ñ‹_Ð±ÐµÐ´Ñ€Ð°`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk5` FOREIGN KEY (`id_Ð‘ÐŸÐ’_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸`) REFERENCES `Ð±Ð¿Ð²_Ð½Ð°_Ð³Ð¾Ð»ÐµÐ½Ð¸` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk6` FOREIGN KEY (`id_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½Ð¸`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk7` FOREIGN KEY (`id_Ð¡ÐŸÐ¡`) REFERENCES `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk8` FOREIGN KEY (`id_ÐœÐŸÐ’`) REFERENCES `Ð¼Ð°Ð»Ð°Ñ_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (`id`),
  CONSTRAINT `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸_fk9` FOREIGN KEY (`id_Ð¢Ð•_ÐœÐŸÐ’`) REFERENCES `Ð±ÐµÐ´Ñ€ÐµÐ½Ð½Ð¾Ðµ_Ð¿Ñ€Ð¾Ð´Ð¾Ð»Ð¶ÐµÐ½Ð¸Ðµ_Ð¼Ð°Ð»Ð¾Ð¹_Ð¿Ð¾Ð´ÐºÐ¾Ð¶Ð½Ð¾Ð¹_Ð²ÐµÐ½Ñ‹` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸`
--

LOCK TABLES `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ_Ð½Ð¾Ð³Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°` int(11) NOT NULL,
  `Ð´Ð°Ñ‚Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` date NOT NULL,
  `Ð²Ñ€ÐµÐ¼Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` time NOT NULL,
  `id_Ð²Ð¸Ð´Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) NOT NULL,
  `id_Ð²Ð¸Ð´Ð°_Ð°Ð½ÐµÑÑ‚ÐµÑ‚Ð¸ÐºÐ°` int(11) NOT NULL,
  `NB!` varchar(100) DEFAULT NULL,
  `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) DEFAULT NULL,
  `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸_fk0` (`Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  KEY `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸_fk4` (`Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`),
  CONSTRAINT `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸_fk0` FOREIGN KEY (`Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (`id`),
  CONSTRAINT `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸_fk4` FOREIGN KEY (`Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð¸Ñ‚Ð¾Ð³Ð¸_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` VALUES (1,5,'2018-01-08','00:00:00',1,1,NULL,NULL,NULL),(2,2,'2018-01-08','00:00:00',1,1,NULL,NULL,NULL),(3,3,'2018-01-09','00:00:00',2,2,'2212121121',NULL,NULL),(4,6,'2018-01-10','02:23:00',1,1,NULL,NULL,NULL),(5,4,'2018-01-10','00:00:00',1,1,'Ñ‹Ñ„Ð²Ñ‹Ð²',NULL,NULL),(6,4,'2018-01-11','00:00:00',1,1,NULL,NULL,NULL),(7,7,'2018-01-11','22:51:00',1,1,NULL,NULL,NULL),(8,6,'2018-01-16','21:59:00',1,1,NULL,NULL,1),(9,5,'2018-01-16','22:48:00',1,1,NULL,NULL,2),(10,4,'2018-01-16','22:53:00',1,1,NULL,NULL,3);
/*!40000 ALTER TABLE `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð´Ð°Ñ‚Ð°_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°` date NOT NULL,
  `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ð°` int(11) NOT NULL,
  `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ñ_Ð¾Ñ‚Ð¼ÐµÐ½ÐµÐ½Ð°` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸_fk0` (`Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ð°`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¾Ñ‚Ð¼ÐµÐ½Ð°_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚`
--

DROP TABLE IF EXISTS `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¸Ð¼Ñ` varchar(20) NOT NULL,
  `Ñ„Ð°Ð¼Ð¸Ð»Ð¸Ñ` varchar(40) NOT NULL,
  `Ð¾Ñ‚Ñ‡ÐµÑÑ‚Ð²Ð¾` varchar(40) NOT NULL,
  `Ð¿Ð¾Ð»` varchar(1) NOT NULL,
  `Ð´Ð°Ñ‚Ð°_Ñ€Ð¾Ð¶Ð´ÐµÐ½Ð¸Ñ` date NOT NULL,
  `Ð³Ð¾Ñ€Ð¾Ð´_Ð¿Ñ€Ð¾Ð¶Ð¸Ð²Ð°Ð½Ð¸Ñ` int(11) NOT NULL,
  `ÑƒÐ»Ð¸Ñ†Ð°_Ð¿Ñ€Ð¾Ð¶Ð¸Ð²Ð°Ð½Ð¸Ñ` int(11) NOT NULL,
  `Ð½Ð¾Ð¼ÐµÑ€_Ð´Ð¾Ð¼Ð°` varchar(16) NOT NULL,
  `Ð½Ð¾Ð¼ÐµÑ€_ÐºÐ²Ð°Ñ€Ñ‚Ð¸Ñ€Ñ‹` int(11) NOT NULL,
  `Ñ‚ÐµÐ»ÐµÑ„Ð¾Ð½` varchar(16) NOT NULL,
  `ÑÐ»ÐµÐºÑ‚Ñ€Ð¾Ð½Ð½Ð°Ñ_Ð¿Ð¾Ñ‡Ñ‚Ð°` varchar(40) DEFAULT NULL,
  `Ñ€Ð°Ð¹Ð¾Ð½_Ð¿Ñ€Ð¾Ð¶Ð¸Ð²Ð°Ð½Ð¸Ñ` int(11) DEFAULT NULL,
  `Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ_Ð¿Ñ€Ð¾Ð¶Ð¸Ð²Ð°Ð½Ð¸Ñ` int(11) NOT NULL,
  `Ð¼ÐµÑÑ‚Ð¾_Ñ€Ð°Ð±Ð¾Ñ‚Ñ‹` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚`
--

LOCK TABLES `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` DISABLE KEYS */;
INSERT INTO `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` VALUES (1,'Ð£Ñ€Ð³Ð¾Ñ€Ð³','ÐžÑ€Ðº','Ð’Ñ€Ð°Ð¼Ñ€Ð°Ð¼Ð°Ð»Ð¾Ð²Ð¸Ñ‡','Ð¼','2008-07-04',1,1,'56Ð°',68,'098-678-45-45','tyrka@yandex.ru',NULL,1,NULL),(2,'ÐŸÐ°Ð´Ð¸Ñ…Ð°Ð´Ð¸','Ð¡Ð¸Ð½ÐµÐº','Ð Ð°Ð·Ð¼Ð°Ð¸Ð»Ð¾Ð²Ð½Ð°','Ð¶','2010-01-29',1,1,'1',6,'032-671-45-45',NULL,NULL,1,NULL),(3,'ÐŸÑˆÐµÐº','ÐŸÑˆÐµÐ²Ð¸ÑˆÐµÐ²Ð¸Ñ‡','ÐÐ´Ð°Ð¼Ð¾Ð²Ð¸Ñ‡','Ð¼','1991-10-30',1,1,'284Ð‘',3,'094-5642345',NULL,NULL,1,NULL),(4,'ÐÐ½Ð½Ð°','Ð’Ð¸Ð½Ð½Ð¸Ñ†ÐºÐ°Ñ','ÐÐ´Ð°Ð¼Ð¾Ð²Ð½Ð°','Ð¶','2002-12-16',1,1,'13Ð°',50,'0386784645','poap@mail.ru',NULL,1,NULL),(5,'Ð’Ð¸ÐºÐ°','Ð–Ð¸Ñ‚Ð¾Ð¼Ð¸Ñ€ÑÐºÐ°Ñ','Ð˜Ð³Ð¾Ñ€ÐµÐ²Ð½Ð°','Ð¶','1999-07-04',1,1,'25',69,'028-478-4545',NULL,NULL,1,NULL),(6,'ÐœÐ¸Ñ…Ð°Ð¸Ð»','ÐŸÑ€Ð¾Ñ…Ð¾Ñ€Ð¾Ð²','Ð’Ð°ÑÐ¸Ð»ÑŒÐµÐ²Ð¸Ñ‡','Ð¼','1995-02-03',1,1,'32Ð²',68,'066-753-04-54','Ñp.girls@gmail.com',NULL,1,NULL),(7,'Ð’Ð¸ÐºÑ‚Ð¾Ñ€','ÐšÐ°Ð»Ð¸Ð±ÐµÑ€Ð´Ð°','ÐšÐ¾Ð½ÑÑ‚Ð°Ð½Ñ‚Ð¸Ð½Ð¾Ð²Ð¸Ñ‡','Ð¼','2000-08-09',1,1,'21Ð°',68,'068-888-16-53','homeless@yandex.ru',NULL,1,NULL),(8,'Ð’ÑÑ‡ÐµÑÐ»Ð°Ð²','Ð¡Ð°Ð¿ÐºÐ¾Ð²ÑÐºÐ¸Ð¹','ÐÐ½Ñ‚Ð¾Ð½Ð¾Ð²Ð¸Ñ‡','Ð¼','1985-11-12',1,1,'12',68,'095-342-90-87','ababrglav@yandex.ru',1,1,NULL),(9,'ÐÐ½Ð´Ñ€ÐµÐ¹','Ð£Ñ€Ð´ÑŽÐº','ÐŸÐµÑ‚Ñ€Ð¾Ð²Ð¸Ñ‡','Ð¼','1999-02-13',1,1,'3Ð³',68,'066-321-65-98','andrey.urduk@yandex.ru',NULL,1,NULL),(10,'Ð“Ñ€Ð¸Ð³Ð¾Ñ€Ð¸Ð¹','Ð¡Ð²Ð¸Ð´Ð»ÐµÑ€','ÐÐ¸ÐºÐ¾Ð»Ð°ÐµÐ²Ð¸Ñ‡','Ð¼','1978-03-25',1,1,'23',68,'050-896-41-52','fafalala@yandex.ru',NULL,1,NULL),(11,' Ð’Ð¸Ð²Ð°Ð»Ð´Ð¸','sad','asd','Ð¼','2018-01-11',5,15,'2',2,'324324',NULL,4,3,NULL),(12,'R','R','R','Ð¼','2017-12-30',1,16,'3',3,'323233','',NULL,1,NULL),(13,'R','R','R','Ð¼','2018-01-11',1,16,'3',3,'323233','',NULL,1,NULL),(14,'EE','E','E','Ð¼','2018-01-11',1,5,'4',4,'43434',NULL,NULL,3,NULL),(15,'234','234','234','Ð¼','2018-01-11',1,4,'5',5,'33333',NULL,2,1,NULL),(16,'2343','234','234','Ð¼','2018-01-11',1,4,'5',5,'33333','eee',2,1,NULL);
/*!40000 ALTER TABLE `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸` (
  `id_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸` int(11) NOT NULL,
  `id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°` int(11) NOT NULL,
  `Ð°Ñ€Ñ…Ð¸Ð²Ð¸Ñ€Ð¾Ð²Ð°Ð½Ð°` tinyint(4) DEFAULT NULL,
  `Ð¼ÐµÑÑÑ†_Ð¿Ð¾ÑÐ²Ð»ÐµÐ½Ð¸Ñ` date DEFAULT NULL,
  `Ð³Ð¾Ð´_Ð¿Ð¾ÑÐ²Ð»ÐµÐ½Ð¸Ñ` date DEFAULT NULL,
  `Ð¼ÐµÑÑÑ†_Ð¸ÑÑ‡ÐµÐ·Ð½Ð¾Ð²Ð°Ð½Ð¸Ðµ` date DEFAULT NULL,
  `Ð³Ð¾Ð´_Ð¸ÑÑ‡ÐµÐ·Ð½Ð¾Ð²Ð°Ð½Ð¸Ðµ` date DEFAULT NULL,
  PRIMARY KEY (`id_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸`,`id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°`),
  KEY `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸_fk1` (`id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°`),
  CONSTRAINT `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸_fk0` FOREIGN KEY (`id_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸`) REFERENCES `Ð²Ð¸Ð´Ñ‹_Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¹` (`id`),
  CONSTRAINT `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸_fk1` FOREIGN KEY (`id_Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚Ð°`) REFERENCES `Ð¿Ð°Ñ†Ð¸ÐµÐ½Ñ‚` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸`
--

LOCK TABLES `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸` VALUES (2,2,1,'0003-03-01','0003-03-01','0002-02-01','0002-02-01'),(2,4,1,'0004-04-01','0004-04-01','0003-03-01','0003-03-01'),(2,6,0,'0004-04-01','0004-04-01',NULL,NULL),(3,3,1,'0002-03-01','0002-03-01','0005-05-01','0005-05-01'),(3,4,1,'2018-01-01','2018-01-01','2018-01-01','2018-01-01'),(3,5,0,'0005-05-01','0005-05-01','0001-01-01','0001-01-01'),(3,8,0,'0003-03-01','0003-03-01','0002-02-01','0002-02-01'),(4,2,0,'0006-05-01','0006-05-01',NULL,NULL),(4,4,0,'2018-01-08','2018-01-08','2018-01-08','2018-01-08'),(4,5,0,'0003-03-01','0003-03-01',NULL,NULL),(4,8,0,'0003-03-01','0003-03-01',NULL,NULL),(5,4,1,'2018-01-01','2018-01-01','2018-01-01','2018-01-01'),(6,3,1,'0044-03-01','0044-03-01','0004-04-01','0004-04-01'),(6,4,0,'0055-03-01','0055-03-01',NULL,NULL);
/*!40000 ALTER TABLE `Ð¿Ð°Ñ‚Ð¾Ð»Ð¾Ð³Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐ”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `ÐŸÐ”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `ÐŸÐ”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  CONSTRAINT `ÐŸÐ”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `ÐŸÐ”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `ÐŸÐ”Ð¡Ð’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2,3),(2,1,2,4),(3,1,2,5),(4,1,2,6),(5,1,2,7),(6,1,2,8),(7,1,2,9),(8,1,10,3),(9,1,10,4),(10,1,10,5),(11,1,10,6),(12,1,10,7),(13,1,10,8),(14,1,10,9),(15,11,2,3),(16,11,2,4),(17,11,2,5),(18,11,2,6),(19,11,2,7),(20,11,2,8),(21,11,2,9),(22,11,10,3),(23,11,10,4),(24,11,10,5),(25,11,10,6),(26,11,10,7),(27,11,10,8),(28,11,10,9),(29,1,NULL,NULL),(30,1,12,NULL),(31,1,13,NULL),(32,1,13,14),(33,15,16,NULL),(34,11,NULL,NULL);
/*!40000 ALTER TABLE `Ð¿Ð´ÑÐ²_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐ”Ð¡Ð’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `ÐŸÐ”Ð¡Ð’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
INSERT INTO `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` VALUES (1,1,NULL,33),(2,1,NULL,6),(3,1,NULL,6),(4,1,NULL,66),(5,1,NULL,66),(6,11,NULL,4),(7,11,NULL,4);
/*!40000 ALTER TABLE `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐ”Ð¡Ð’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `ÐŸÐ”Ð¡Ð’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'ÐŸÐ”Ð¡Ð’ Ð±ÐµÐ· Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,1),(2,'Ð˜Ð¼ÐµÐµÑ‚ Ð¿Ñ€ÑÐ¼Ð¾Ð»Ð¸Ð½ÐµÐ¹Ð½Ñ‹Ð¹ Ñ…Ð¾Ð´.',NULL,0,NULL,2),(3,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ ÐŸÐ”Ð¡Ð’ Ð±ÐµÐ· Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ°.',NULL,0,NULL,3),(4,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ ÐŸÐ”Ð¡Ð’ Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(5,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ ÐŸÐ”Ð¡Ð’ Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼ Ð¸ Ð¾ÑÑ‚Ð°Ñ‚Ð¾Ñ‡Ð½Ñ‹Ð¼Ð¸ ÑÐ²Ð»ÐµÐ½Ð¸ÑÐ¼Ð¸ Ð¿ÐµÑ€ÐµÐ½ÐµÑÐµÐ½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(6,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ ÐŸÐ”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(7,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ ÐŸÐ”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð½ÐµÐ¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(8,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ ÐŸÐ”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ñ‡Ð°ÑÑ‚Ð¸Ñ‡Ð½Ð¾ Ñ€ÐµÐºÐ°Ð½Ð°Ð»Ð¸Ð·Ð¸Ñ€Ð¾Ð²Ð°Ð½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(9,'ÐŸÑ€Ð¸Ñ‚Ð¾ÐºÐ¸ ÐŸÐ”Ð¡Ð’ Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ ÑÐºÐ»ÐµÑ€Ð¾Ð¾Ð±Ð»Ð¸Ñ‚ÐµÑ€Ð°Ñ†Ð¸Ð¸, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(10,'Ð˜Ð¼ÐµÐµÑ‚ Ð¸Ð·Ð²Ð¸Ñ‚Ð¾Ð¹ Ñ…Ð¾Ð´.',NULL,0,NULL,2),(11,'ÐŸÐ”Ð¡Ð’ Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾3Ð¼',NULL,1,1,1),(12,'22','',0,NULL,2),(13,'TestedSuccsesfullt','',0,NULL,2),(14,'not so bad','',0,NULL,3),(15,'8','',0,NULL,1),(16,'88','',0,NULL,2);
/*!40000 ALTER TABLE `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5` int(11) DEFAULT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk3` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk4` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk3` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹_fk4` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð°_Ð¸_Ð½ÐµÑÐ°Ñ„ÐµÐ½Ð½Ñ‹Ðµ_Ð²ÐµÐ½Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk3` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk4` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk3` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾_fk4` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2,3,4,5),(2,1,2,3,4,6),(3,1,2,3,4,7),(4,1,2,3,4,8),(5,1,2,3,4,9),(6,1,2,3,4,10),(7,1,2,11,4,5),(8,1,2,11,4,6),(9,1,2,11,4,7),(10,1,2,11,4,8),(11,1,2,11,4,9),(12,1,2,11,4,10),(13,12,13,14,15,16),(14,12,13,14,NULL,NULL),(15,12,NULL,NULL,NULL,NULL),(16,1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(50) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'Ð›Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð½ÐµÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ñ‹Ð¹ Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚',NULL,NULL,0,1),(2,'Ð²Ð½ÑƒÑ‚Ñ€ÐµÐ½Ð½ÐµÐ¹ Ð¿Ð¾Ð²ÐµÑ€Ñ…Ð½Ð¾ÑÑ‚Ð¸',NULL,NULL,0,2),(3,'Ð²ÐµÑ€Ñ…Ð½ÐµÐ¹ 1/3 Ð±ÐµÐ´Ñ€Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(4,'Ð¸ Ð¸ÑÑ…Ð¾Ð´ÑÑ‰Ð°Ñ Ð¸Ð· Ð½ÐµÐ³Ð¾ ÑÐ¿Ð¸Ñ„Ð°ÑÑ†Ð¸Ð°Ð»ÑŒÐ½Ð°Ñ Ð²ÐµÐ½Ð°',NULL,NULL,0,4),(5,'Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,5),(6,'Ñ Ñ€ÐµÑ„Ð»ÑŽÐºÑÐ¾Ð¼ Ð¸ Ð¾ÑÑ‚Ð°Ñ‚Ð¾Ñ‡Ð½Ñ‹Ð¼Ð¸ ÑÐ²Ð»ÐµÐ½Ð¸ÑÐ¼Ð¸ Ð¿ÐµÑ€ÐµÐ½ÐµÑÐµÐ½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,5),(7,'Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,5),(8,'Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ð½ÐµÐ¾ÐºÐºÐ»ÑŽÐ·Ð¸Ñ€ÑƒÑŽÑ‰ÐµÐ³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,5),(9,'Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ Ñ‡Ð°ÑÑ‚Ð¸Ñ‡Ð½Ð¾ Ñ€ÐµÐºÐ°Ð½Ð°Ð»Ð¸Ð·Ð¸Ñ€Ð¾Ð²Ð°Ð½Ð½Ð¾Ð³Ð¾ Ñ‚Ñ€Ð¾Ð¼Ð±Ð¾Ð·Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,5),(10,'Ñ Ð¿Ñ€Ð¸Ð·Ð½Ð°ÐºÐ°Ð¼Ð¸ ÑÐºÐ»ÐµÑ€Ð¾Ð¾Ð±Ð»Ð¸Ñ‚ÐµÑ€Ð°Ñ†Ð¸Ð¸, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,5),(11,'ÑÑ€ÐµÐ´Ð½ÐµÐ¹ 1/3 Ð±ÐµÐ´Ñ€Ð°, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,3),(12,'1','1',18,1,1),(13,'2','2',NULL,0,2),(14,'3','',NULL,0,3),(15,'4','',NULL,0,4),(16,'5','',NULL,0,5);
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð±ÐµÐ´Ñ€Ð¾_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_3` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_4` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_5` int(11) DEFAULT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_1`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_2`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_3`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk3` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_4`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk4` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_5`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_1`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_2`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_3`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk3` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_4`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_fk4` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_5`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_3` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_4` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_5` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_1`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_2`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_3`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk3` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_4`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk4` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_5`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_1`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_2`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_3`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk3` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_4`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾_fk4` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_5`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚_Ð³Ð¾Ð»ÐµÐ½ÑŒ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  `id_Ñ…Ð¾Ð´Ð°` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `ÐŸÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `ÐŸÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  CONSTRAINT `ÐŸÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `ÐŸÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `ÐŸÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `Ð¿Ð´ÑÐ²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

LOCK TABLES `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€ÐµÐ´Ð½ÑÑ_Ð´Ð¾Ð±Ð°Ð²Ð¾Ñ‡Ð½Ð°Ñ_ÑÐ°Ñ„ÐµÐ½Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð´Ð°Ñ‚Ð°_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°` date NOT NULL,
  `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ð°` int(11) NOT NULL,
  `Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ñ_Ð¾Ñ‚Ð¼ÐµÐ½ÐµÐ½Ð°` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿ÐµÑ€ÐµÐ½Ð¾Ñ_Ð¾Ð¿ÐµÑ€Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

DROP TABLE IF EXISTS `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐ¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `ÐŸÐ¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  CONSTRAINT `ÐŸÐ¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `ÐŸÐ¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°`
--

LOCK TABLES `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð°Ñ_Ð¿ÐµÑ€Ñ„Ð¾Ñ€Ð°Ð½Ñ‚Ð½Ð°Ñ_Ð²ÐµÐ½Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `ÐŸÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  CONSTRAINT `ÐŸÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `ÐŸÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ð¿Ð´ÑÐ²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2);
/*!40000 ALTER TABLE `Ð¿Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐŸÐ’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `ÐŸÐŸÐ’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ÐŸÐŸÐ’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `ÐŸÐŸÐ’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'1','1',19,1,1),(2,'3','',NULL,0,2),(3,'ÐžÐ‘Ð’','',NULL,0,1),(4,'ÐžÐ‘Ð’','',20,1,1);
/*!40000 ALTER TABLE `Ð¿Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ñ‹_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°`
--

DROP TABLE IF EXISTS `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ñ‹_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ñ‹_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ð°` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ñ‹_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°`
--

LOCK TABLES `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ñ‹_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°` WRITE;
/*!40000 ALTER TABLE `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ñ‹_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ð¿Ñ€Ð¸Ñ‡Ð¸Ð½Ñ‹_Ð¿ÐµÑ€ÐµÐ½Ð¾ÑÐ°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸` (
  `id_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸` int(11) NOT NULL,
  `id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ` int(11) NOT NULL,
  PRIMARY KEY (`id_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸`,`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`),
  KEY `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸_fk1` (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`),
  CONSTRAINT `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸_fk0` FOREIGN KEY (`id_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð²Ð¸Ð´Ñ‹_Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¹` (`id`),
  CONSTRAINT `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸_fk1` FOREIGN KEY (`id_Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ñ`) REFERENCES `Ð¾Ð±ÑÐ»ÐµÐ´Ð¾Ð²Ð°Ð½Ð¸Ðµ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ñ€ÐµÐºÐ¾Ð¼ÐµÐ½Ð´Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ`
--

DROP TABLE IF EXISTS `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ6` int(11) DEFAULT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk3` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk4` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk5` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ6`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk3` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ4`) REFERENCES `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk4` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ5`) REFERENCES `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk5` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ6`) REFERENCES `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ`
--

LOCK TABLES `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` WRITE;
/*!40000 ALTER TABLE `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` DISABLE KEYS */;
/*!40000 ALTER TABLE `ÑÐ°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ`
--

DROP TABLE IF EXISTS `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1` int(11) NOT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2` int(11) DEFAULT NULL,
  `Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk0` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk1` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`),
  KEY `Ð¡Ð°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk2` (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk0` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ1`) REFERENCES `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk1` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ2`) REFERENCES `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`),
  CONSTRAINT `Ð¡Ð°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ_fk2` FOREIGN KEY (`Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ3`) REFERENCES `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ`
--

LOCK TABLES `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` WRITE;
/*!40000 ALTER TABLE `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` DISABLE KEYS */;
/*!40000 ALTER TABLE `ÑÐ°Ñ„ÐµÐ½Ð¾_Ð¿Ð¾Ð¿Ð»Ð¸Ñ‚ÐµÐ°Ð»ÑŒÐ½Ð¾Ðµ_ÑÐ¾ÑƒÑÑ‚ÑŒÐµ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°6` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  KEY `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk3` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`),
  KEY `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk4` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5`),
  KEY `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk5` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°6`),
  CONSTRAINT `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk3` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°4`) REFERENCES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk4` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°5`) REFERENCES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¡Ð¤Ð¡_ÐºÐ¾Ð¼Ð±Ð¾_fk5` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°6`) REFERENCES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2,3,4,6,NULL),(2,1,2,3,4,7,NULL),(3,1,2,3,4,8,NULL),(4,1,2,3,4,9,NULL),(5,1,2,3,5,6,NULL),(6,1,2,3,5,7,NULL),(7,1,2,3,5,8,NULL),(8,1,2,3,5,9,NULL),(9,1,2,3,10,6,NULL),(10,1,2,3,10,7,NULL),(11,1,2,3,10,8,NULL),(12,1,2,3,10,9,NULL),(13,1,2,3,11,6,NULL),(14,1,2,3,11,7,NULL),(15,1,2,3,11,8,NULL),(16,1,2,3,11,9,NULL),(17,1,2,12,4,6,NULL),(18,1,2,12,4,7,NULL),(19,1,2,12,4,8,NULL),(20,1,2,12,4,9,NULL),(21,1,2,12,5,6,NULL),(22,1,2,12,5,7,NULL),(23,1,2,12,5,8,NULL),(24,1,2,12,5,9,NULL),(25,1,2,12,10,6,NULL),(26,1,2,12,10,7,NULL),(27,1,2,12,10,8,NULL),(28,1,2,12,10,9,NULL),(29,1,2,12,11,6,NULL),(30,1,2,12,11,7,NULL),(31,1,2,12,11,8,NULL),(32,1,2,12,11,9,NULL),(33,1,2,12,13,NULL,NULL),(34,1,14,NULL,NULL,NULL,NULL),(35,1,2,15,NULL,NULL,NULL),(36,1,2,16,NULL,NULL,NULL),(37,1,NULL,NULL,NULL,NULL,NULL),(38,1,2,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `ÑÑ„Ñ_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°1` float DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°2` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡Ð¤Ð¡_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð¡Ð¤Ð¡_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
INSERT INTO `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` VALUES (1,17,NULL,NULL,NULL),(2,18,NULL,NULL,NULL),(3,20,NULL,NULL,NULL),(4,21,NULL,NULL,NULL),(5,22,NULL,NULL,NULL),(6,23,NULL,NULL,NULL),(7,1,NULL,NULL,NULL),(8,1,'1',NULL,NULL),(9,2,'2',NULL,NULL),(10,1,NULL,0,0),(11,2,NULL,87,0),(12,16,NULL,9,99),(13,1,'2221',0,0),(14,14,'3',0,0),(15,1,NULL,0,0),(16,2,NULL,33,0),(17,1,NULL,0,0),(18,1,NULL,0,0),(19,1,NULL,0,0),(20,1,NULL,0,0);
/*!40000 ALTER TABLE `ÑÑ„Ñ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `Ð´Ð²Ð¾Ð¹Ð½Ð°Ñ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡Ð¤Ð¡_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð¡Ð¤Ð¡_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'Ð¡Ð°Ñ„ÐµÐ½Ð¾-Ñ„ÐµÐ¼Ð¾Ñ€Ð°Ð»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ ÑÑ‚Ð°Ð½Ð´Ð°Ñ€Ñ‚Ð½Ð¾Ðµ.',NULL,NULL,0,0,1),(2,'Ð¢ÐµÑ€Ð¼Ð¸Ð½Ð°Ð»ÑŒÐ½Ñ‹Ð¹ ÐºÐ»Ð°Ð¿Ð°Ð½ ÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ñ‹Ð¹, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,2),(3,'ÐŸÑ€ÐµÑ‚ÐµÑ€Ð¼Ð¸Ð½Ð°Ð»ÑŒÐ½Ñ‹Ð¹ ÐºÐ»Ð°Ð¿Ð°Ð½ ÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ñ‹Ð¹, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,3),(4,'ÐŸÑ€Ð¸ÑƒÑÑ‚ÑŒÐµÐ²Ð¾Ð¹ Ð¾Ñ‚Ð´ÐµÐ» Ð‘ÐŸÐ’ Ð¸Ð¼ÐµÐµÑ‚ Ð¸Ð·Ð²Ð¸Ñ‚Ð¾Ð¹ Ñ…Ð¾Ð´.',NULL,NULL,0,0,4),(5,'ÐŸÑ€Ð¸ÑƒÑÑ‚ÑŒÐµÐ²Ð¾Ð¹ Ð¾Ñ‚Ð´ÐµÐ» Ð‘ÐŸÐ’ Ð¸Ð¼ÐµÐµÑ‚ Ð¸Ð·Ð²Ð¸Ñ‚Ð¾Ð¹ Ñ…Ð¾Ð´, Ð»Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð¾Ñ‚Ð´ÐµÐ»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ.',NULL,NULL,0,0,4),(6,'ÐŸÐ”Ð¡Ð’ Ñ ÐžÐ‘Ð’, ÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,5),(7,'ÐŸÐ”Ð¡Ð’ Ñ ÐžÐ‘Ð’, Ð½ÐµÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,5),(8,'Ð—Ð”Ð¡Ð’ Ñ ÐžÐ‘Ð’, ÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,5),(9,'Ð—Ð”Ð¡Ð’ Ñ ÐžÐ‘Ð’, Ð½ÐµÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,5),(10,'ÐŸÑ€Ð¸ÑƒÑÑ‚ÑŒÐµÐ²Ð¾Ð¹ Ð¾Ñ‚Ð´ÐµÐ» Ð‘ÐŸÐ’ Ð¸Ð¼ÐµÐµÑ‚ Ð¿Ñ€ÑÐ¼Ð¾Ð»Ð¸Ð½ÐµÐ¹Ð½Ñ‹Ð¹ Ñ…Ð¾Ð´.',NULL,NULL,0,0,4),(11,'ÐŸÑ€Ð¸ÑƒÑÑ‚ÑŒÐµÐ²Ð¾Ð¹ Ð¾Ñ‚Ð´ÐµÐ» Ð‘ÐŸÐ’ Ð¸Ð¼ÐµÐµÑ‚ Ð¿Ñ€ÑÐ¼Ð¾Ð»Ð¸Ð½ÐµÐ¹Ð½Ñ‹Ð¹ Ñ…Ð¾Ð´, Ð»Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð¾Ñ‚Ð´ÐµÐ»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ.',NULL,NULL,0,0,4),(12,'ÐŸÑ€ÐµÑ‚ÐµÑ€Ð¼Ð¸Ð½Ð°Ð»ÑŒÐ½Ñ‹Ð¹ ÐºÐ»Ð°Ð¿Ð°Ð½ Ð½ÐµÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ñ‹Ð¹, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,3),(13,'Ð¡Ð’ÐžÐ™ Ð’ÐÐ Ð˜Ðš','23',NULL,0,0,4),(14,'erterter','',NULL,0,0,2),(15,'33','',17,1,1,3),(16,'ll','',13,1,1,3);
/*!40000 ALTER TABLE `ÑÑ„Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`
--

DROP TABLE IF EXISTS `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` (
  `id_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` int(11) NOT NULL,
  `id_Ð²Ñ€Ð°Ñ‡Ð°` int(11) NOT NULL,
  PRIMARY KEY (`id_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`,`id_Ð²Ñ€Ð°Ñ‡Ð°`),
  KEY `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸_fk0` (`id_Ð²Ñ€Ð°Ñ‡Ð°`),
  CONSTRAINT `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸_fk0` FOREIGN KEY (`id_Ð²Ñ€Ð°Ñ‡Ð°`) REFERENCES `Ð²Ñ€Ð°Ñ‡Ð¸` (`id`),
  CONSTRAINT `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸_fk1` FOREIGN KEY (`id_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`) REFERENCES `Ð²Ð¸Ð´Ñ‹_ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¹` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸`
--

LOCK TABLES `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` DISABLE KEYS */;
INSERT INTO `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` VALUES (1,1),(4,2),(2,3),(3,3);
/*!40000 ALTER TABLE `ÑÐ¿ÐµÑ†Ð¸Ð°Ð»Ð¸Ð·Ð°Ñ†Ð¸Ð¸` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°`
--

DROP TABLE IF EXISTS `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°`
--

LOCK TABLES `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°` DISABLE KEYS */;
INSERT INTO `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°` VALUES (1,'Ð¥Ð°Ñ€ÑŒÐºÐ¾Ð²'),(2,'Ð¯Ð»Ñ‚Ð° '),(3,'Ð“Ð°Ð¹ '),(4,'ÐžÑ€Ð³Ñ€Ð¸Ð¼Ð¼Ð°Ñ€'),(5,'asd');
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð³Ð¾Ñ€Ð¾Ð´Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ`
--

DROP TABLE IF EXISTS `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ`
--

LOCK TABLES `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ` DISABLE KEYS */;
INSERT INTO `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ` VALUES (1,'Ð¥Ð°Ñ€ÑŒÐºÐ¾Ð²ÑÐºÐ°Ñ '),(2,'Ð’Ñ–Ð½Ð½Ð¸Ñ†ÑŒÐºÐ°'),(3,'asd');
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ð¾Ð±Ð»Ð°ÑÑ‚ÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹`
--

DROP TABLE IF EXISTS `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹`
--

LOCK TABLES `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹` DISABLE KEYS */;
INSERT INTO `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹` VALUES (1,'ÐšÐ¸ÐµÐ²ÑÐºÐ¸Ð¹'),(2,'Ð¥Ð¾Ð»Ð¾Ð´Ð½Ð¾Ð³Ð¾Ñ€ÑÐºÐ¸Ð¹'),(3,'Ð˜Ð½Ð´ÑƒÑÑ‚Ñ€Ð¸Ð°Ð»ÑŒÐ½Ñ‹Ð¹'),(4,'asd'),(5,'3444'),(6,'1233123');
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_Ñ€Ð°Ð¹Ð¾Ð½Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹`
--

DROP TABLE IF EXISTS `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹`
--

LOCK TABLES `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹` DISABLE KEYS */;
INSERT INTO `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹` VALUES (1,'Ð‘Ð¾Ð³Ð´Ð°Ð½Ð° Ð¥Ð¼ÐµÐ»ÑŒÐ½Ð¸Ñ†ÐºÐ¾Ð³Ð¾ ÑƒÐ».'),(2,'Ð“ÑƒÑ€Ð·ÑƒÑ„ÑÐºÐ°Ñ ÑƒÐ».'),(3,'ÐœÐ°ÐºÑÐ¸Ð¼Ð¸Ð»Ð¸Ð°Ð½Ð¾Ð²ÑÐºÐ°Ñ ÑƒÐ».'),(4,'Ð•ÑÐµÐ½Ð¸Ð½Ð° ÑƒÐ».'),(5,'Ð•Ð½Ð¸ÑÐµÐ¹ÑÐºÐ°Ñ'),(6,'Ð•Ñ€ÐµÐ²Ð°Ð½ÑÐºÐ°Ñ'),(7,'Ð•Ð»Ð¾Ñ‡Ð½Ð°Ñ'),(8,'Ð•Ð»ÐµÑ†ÐºÐ°Ñ'),(9,'Ð•Ð¼Ð¸Ñ†ÐºÐ°Ñ'),(10,'Ð•Ð¼ÐµÐ»ÑŒÐ½Ð¸Ñ†ÐºÐ°Ñ'),(11,'Ð•Ð²ÑÐºÐ°Ñ'),(12,'Ð•Ñ€Ð²Ð¸Ð°Ð½ÑÐºÐ°Ñ'),(13,'Ð•Ð»ÐµÐ½Ð¸Ð½Ð³Ñ€Ð°Ð´ÑÐºÐ°Ñ'),(14,'Ð•Ð»ÑŒÑ†ÐºÐ°Ñ'),(15,'asd'),(16,'Ð•ÑÐµÐ½Ð¸Ð½Ð°');
/*!40000 ALTER TABLE `ÑÐ¿Ñ€Ð°Ð²Ð¾Ñ‡Ð½Ð¸Ðº_ÑƒÐ»Ð¸Ñ†Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°1` float DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°2` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡ÐŸÐ¡_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð¡ÐŸÐ¡_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `ÑÐ¿Ñ_Ð³Ð¾Ð»ÐµÐ½ÑŒ_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡ÐŸÐ¡_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð¡ÐŸÐ¡_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `Ð¡ÐŸÐ¡_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  CONSTRAINT `Ð¡ÐŸÐ¡_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¡ÐŸÐ¡_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¡ÐŸÐ¡_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,2,3),(2,1,2,4),(3,1,5,3),(4,1,5,4),(5,1,6,3),(6,1,6,4),(7,7,2,3),(8,7,2,4),(9,7,5,3),(10,7,5,4),(11,1,8,3),(12,1,NULL,NULL);
/*!40000 ALTER TABLE `ÑÐ¿Ñ_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(11) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `Ð´Ð²Ð¾Ð¹Ð½Ð°Ñ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¡ÐŸÐ¡_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð¡ÐŸÐ¡_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'Ð¡Ð¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,1),(2,'Ð»Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð½Ð° ÑƒÑ€Ð¾Ð²Ð½Ðµ Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð¾Ð¹ ÑÐºÐ»Ð°Ð´ÐºÐ¸',NULL,NULL,0,0,2),(3,'Ð›Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð´Ð¾Ð¿Ð¾Ð»Ð½Ð¸Ñ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ.',NULL,NULL,0,0,3),(4,'Ð›Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð´Ð¾Ð¿Ð¾Ð»Ð½Ð¸Ñ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ Ð½ÐµÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾Ðµ ÑÐ¾ÑƒÑÑ‚ÑŒÐµ.',NULL,NULL,0,0,3),(5,'Ð»Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð²Ñ‹ÑˆÐµ Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð¾Ð¹ ÑÐºÐ»Ð°Ð´ÐºÐ¸ Ð½Ð° ',NULL,3,1,0,2),(6,'Ð»Ð¾Ñ†Ð¸Ñ€ÑƒÐµÑ‚ÑÑ Ð½Ð¸Ð¶Ðµ Ð¿Ð¾Ð´ÐºÐ¾Ð»ÐµÐ½Ð½Ð¾Ð¹ ÑÐºÐ»Ð°Ð´ÐºÐ¸ Ð½Ð° ',NULL,3,1,0,2),(7,'ÐÐµÑÐ¾ÑÑ‚Ð¾ÑÑ‚ÐµÐ»ÑŒÐ½Ð¾, Ð´Ð¸Ð°Ð¼ÐµÑ‚Ñ€Ð¾Ð¼',NULL,1,1,0,1),(8,'23','',17,1,1,2);
/*!40000 ALTER TABLE `ÑÐ¿Ñ_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ñ_ÐºÐ»Ð¸Ð½Ð¸Ñ‡ÐµÑÐºÐ¸Ð¹_ÐºÐ»Ð°ÑÑ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`
--

DROP TABLE IF EXISTS `Ñ_ÐºÐ»Ð¸Ð½Ð¸Ñ‡ÐµÑÐºÐ¸Ð¹_ÐºÐ»Ð°ÑÑ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ñ_ÐºÐ»Ð¸Ð½Ð¸Ñ‡ÐµÑÐºÐ¸Ð¹_ÐºÐ»Ð°ÑÑ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(5) NOT NULL,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ñ_ÐºÐ»Ð¸Ð½Ð¸Ñ‡ÐµÑÐºÐ¸Ð¹_ÐºÐ»Ð°ÑÑ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ`
--

LOCK TABLES `Ñ_ÐºÐ»Ð¸Ð½Ð¸Ñ‡ÐµÑÐºÐ¸Ð¹_ÐºÐ»Ð°ÑÑ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` WRITE;
/*!40000 ALTER TABLE `Ñ_ÐºÐ»Ð¸Ð½Ð¸Ñ‡ÐµÑÐºÐ¸Ð¹_ÐºÐ»Ð°ÑÑ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ñ_ÐºÐ»Ð¸Ð½Ð¸Ñ‡ÐµÑÐºÐ¸Ð¹_ÐºÐ»Ð°ÑÑ_Ð·Ð°Ð±Ð¾Ð»ÐµÐ²Ð°Ð½Ð¸Ñ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

DROP TABLE IF EXISTS `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1` int(11) NOT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2` int(11) DEFAULT NULL,
  `ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¢Ð•_ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`),
  KEY `Ð¢Ð•_ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`),
  KEY `Ð¢Ð•_ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`),
  CONSTRAINT `Ð¢Ð•_ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk0` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°1`) REFERENCES `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¢Ð•_ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk1` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°2`) REFERENCES `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`),
  CONSTRAINT `Ð¢Ð•_ÐœÐŸÐ’_ÐºÐ¾Ð¼Ð±Ð¾_fk2` FOREIGN KEY (`ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°3`) REFERENCES `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾`
--

LOCK TABLES `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` WRITE;
/*!40000 ALTER TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` DISABLE KEYS */;
INSERT INTO `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` VALUES (1,1,NULL,NULL),(2,1,2,NULL);
/*!40000 ALTER TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÐºÐ¾Ð¼Ð±Ð¾` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

DROP TABLE IF EXISTS `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹` int(11) NOT NULL,
  `ÐºÐ¾Ð¼Ð¼ÐµÐ½Ñ‚Ð°Ñ€Ð¸Ð¹` varchar(100) DEFAULT NULL,
  `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¢Ð•_ÐœÐŸÐ’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`),
  CONSTRAINT `Ð¢Ð•_ÐœÐŸÐ’_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ_fk0` FOREIGN KEY (`id_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ñ‹`) REFERENCES `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ`
--

LOCK TABLES `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` WRITE;
/*!40000 ALTER TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_Ð¿Ð¾Ð´Ð·Ð°Ð¿Ð¸ÑÑŒ` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

DROP TABLE IF EXISTS `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ1` varchar(150) DEFAULT NULL,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ2` varchar(100) DEFAULT NULL,
  `id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸` int(50) DEFAULT NULL,
  `ÐµÑÑ‚ÑŒ_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` tinyint(1) NOT NULL,
  `ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ_Ð²Ð»Ð¾Ð¶ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Ð¢Ð•_ÐœÐŸÐ’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`),
  CONSTRAINT `Ð¢Ð•_ÐœÐŸÐ’_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°_fk0` FOREIGN KEY (`id_Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ¸`) REFERENCES `Ð¼ÐµÑ‚Ñ€Ð¸ÐºÐ°` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°`
--

LOCK TABLES `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` WRITE;
/*!40000 ALTER TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` DISABLE KEYS */;
INSERT INTO `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` VALUES (1,'2','',NULL,0,1),(2,'4','',NULL,0,2);
/*!40000 ALTER TABLE `Ñ‚Ðµ_Ð¼Ð¿Ð²_ÑÑ‚Ñ€ÑƒÐºÑ‚ÑƒÑ€Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°`
--

DROP TABLE IF EXISTS `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(5) NOT NULL,
  `Ð¾Ð¿Ð¸ÑÐ°Ð½Ð¸Ðµ` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°`
--

LOCK TABLES `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°` WRITE;
/*!40000 ALTER TABLE `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°` DISABLE KEYS */;
/*!40000 ALTER TABLE `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `c_ÑÑƒÐ±ÑŠÐµÐºÑ‚Ð¸Ð²Ð½Ñ‹Ðµ_ÑÐ¸Ð¼Ð¿Ñ‚Ð¾Ð¼Ñ‹`
--

DROP TABLE IF EXISTS `c_ÑÑƒÐ±ÑŠÐµÐºÑ‚Ð¸Ð²Ð½Ñ‹Ðµ_ÑÐ¸Ð¼Ð¿Ñ‚Ð¾Ð¼Ñ‹`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `c_ÑÑƒÐ±ÑŠÐµÐºÑ‚Ð¸Ð²Ð½Ñ‹Ðµ_ÑÐ¸Ð¼Ð¿Ñ‚Ð¾Ð¼Ñ‹` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` varchar(5) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ` (`Ð½Ð°Ð·Ð²Ð°Ð½Ð¸Ðµ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `c_ÑÑƒÐ±ÑŠÐµÐºÑ‚Ð¸Ð²Ð½Ñ‹Ðµ_ÑÐ¸Ð¼Ð¿Ñ‚Ð¾Ð¼Ñ‹`
--

LOCK TABLES `c_ÑÑƒÐ±ÑŠÐµÐºÑ‚Ð¸Ð²Ð½Ñ‹Ðµ_ÑÐ¸Ð¼Ð¿Ñ‚Ð¾Ð¼Ñ‹` WRITE;
/*!40000 ALTER TABLE `c_ÑÑƒÐ±ÑŠÐµÐºÑ‚Ð¸Ð²Ð½Ñ‹Ðµ_ÑÐ¸Ð¼Ð¿Ñ‚Ð¾Ð¼Ñ‹` DISABLE KEYS */;
/*!40000 ALTER TABLE `c_ÑÑƒÐ±ÑŠÐµÐºÑ‚Ð¸Ð²Ð½Ñ‹Ðµ_ÑÐ¸Ð¼Ð¿Ñ‚Ð¾Ð¼Ñ‹` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `p`
--

DROP TABLE IF EXISTS `p`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `p` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ð±ÑƒÐºÐ²Ñ‹` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `P_fk0` (`Ð±ÑƒÐºÐ²Ñ‹`),
  CONSTRAINT `P_fk0` FOREIGN KEY (`Ð±ÑƒÐºÐ²Ñ‹`) REFERENCES `Ñ‚Ð¸Ð¿_Ñ€Ð°ÑÑÑ‚Ñ€Ð¾Ð¹ÑÑ‚Ð²Ð°` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `p`
--

LOCK TABLES `p` WRITE;
/*!40000 ALTER TABLE `p` DISABLE KEYS */;
/*!40000 ALTER TABLE `p` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-28 18:56:54
