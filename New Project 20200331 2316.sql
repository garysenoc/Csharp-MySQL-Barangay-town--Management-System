-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.16


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema dbbarangay
--

CREATE DATABASE IF NOT EXISTS dbbarangay;
USE dbbarangay;

--
-- Definition of table `tbaccount`
--

DROP TABLE IF EXISTS `tbaccount`;
CREATE TABLE `tbaccount` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `surname` varchar(200) NOT NULL,
  `fname` varchar(200) NOT NULL,
  `mname` varchar(200) NOT NULL,
  `username` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  `securityquestion` varchar(200) NOT NULL,
  `secanswer` varchar(200) NOT NULL,
  `pic` varchar(4300) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbaccount`
--

/*!40000 ALTER TABLE `tbaccount` DISABLE KEYS */;
INSERT INTO `tbaccount` (`id`,`surname`,`fname`,`mname`,`username`,`password`,`securityquestion`,`secanswer`,`pic`,`status`) VALUES 
 (1,'senocg','gary','s','gary','green','What is your favorite color?','breen','C:\\Users\\Gary Lloyd Senoc\\Desktop\\princess.jpg','Active');
/*!40000 ALTER TABLE `tbaccount` ENABLE KEYS */;


--
-- Definition of table `tbadmin`
--

DROP TABLE IF EXISTS `tbadmin`;
CREATE TABLE `tbadmin` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbadmin`
--

/*!40000 ALTER TABLE `tbadmin` DISABLE KEYS */;
INSERT INTO `tbadmin` (`id`,`username`,`password`) VALUES 
 (1,'admin','admin');
/*!40000 ALTER TABLE `tbadmin` ENABLE KEYS */;


--
-- Definition of table `tbhistory`
--

DROP TABLE IF EXISTS `tbhistory`;
CREATE TABLE `tbhistory` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `timeanddate` varchar(200) NOT NULL,
  `activity` varchar(200) NOT NULL,
  `username` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbhistory`
--

/*!40000 ALTER TABLE `tbhistory` DISABLE KEYS */;
INSERT INTO `tbhistory` (`id`,`timeanddate`,`activity`,`username`) VALUES 
 (1,'2018-10-29 09:16:33','Update Profile','Admin'),
 (2,'2018-10-29 18:56:49','Deactivate an account','Admin'),
 (3,'2018-10-30 01:31:47','Activate an account','Admin'),
 (4,'2018-10-30 01:42:36','Update Profile','gary'),
 (5,'2018-10-30 01:46:21','Update Profile','gary'),
 (6,'2018-10-30 01:51:36','Login','gary'),
 (7,'2018-10-30 08:22:07','Login','gary'),
 (8,'2018-10-30 08:23:51','Login','Admin'),
 (9,'2018-10-30 08:25:33','Login','Admin'),
 (10,'2018-10-30 14:43:44','Login','gary'),
 (11,'2018-10-30 14:44:29','Login','Admin'),
 (12,'2018-10-30 17:39:58','Login','Admin'),
 (13,'2018-10-30 17:40:34','Login','Admin'),
 (14,'2018-10-30 17:42:14','Login','Admin'),
 (15,'2018-10-30 17:42:26','Update Organization','Admin'),
 (16,'2018-10-30 18:33:20','Login','Admin'),
 (17,'2018-10-30 18:33:43','Delete a resident profile','Admin'),
 (18,'2018-10-30 18:36:10','Deactivate an account','Admin'),
 (19,'2018-10-30 18:36:16','Activate an account','Admin'),
 (20,'2018-11-15 12:55:54','Login','Admin');
INSERT INTO `tbhistory` (`id`,`timeanddate`,`activity`,`username`) VALUES 
 (21,'2019-09-03 20:17:27','Login','Admin'),
 (22,'2019-09-03 20:18:18','Add a resident profile','Admin'),
 (23,'2019-09-03 20:28:01','Add a resident profile','Admin'),
 (24,'2019-10-01 19:04:36','Login','Admin'),
 (25,'2019-10-01 19:08:09','Add a resident profile','Admin'),
 (26,'2019-10-01 19:11:59','Logout','Admin'),
 (27,'2020-03-31 23:12:03','Login','Admin'),
 (28,'2020-03-31 23:12:27','Delete a resident profile','Admin');
/*!40000 ALTER TABLE `tbhistory` ENABLE KEYS */;


--
-- Definition of table `tbofficial`
--

DROP TABLE IF EXISTS `tbofficial`;
CREATE TABLE `tbofficial` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `q` varchar(200) DEFAULT NULL,
  `w` varchar(200) DEFAULT NULL,
  `e` varchar(200) DEFAULT NULL,
  `r` varchar(200) DEFAULT NULL,
  `t` varchar(200) DEFAULT NULL,
  `y` varchar(200) DEFAULT NULL,
  `u` varchar(200) DEFAULT NULL,
  `i` varchar(200) DEFAULT NULL,
  `o` varchar(200) DEFAULT NULL,
  `p` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbofficial`
--

/*!40000 ALTER TABLE `tbofficial` DISABLE KEYS */;
INSERT INTO `tbofficial` (`id`,`q`,`w`,`e`,`r`,`t`,`y`,`u`,`i`,`o`,`p`) VALUES 
 (1,'Gary','asdf','sdfasfsdf','asdf','asdf','asd','asdf','asdf','asdf','asdf');
/*!40000 ALTER TABLE `tbofficial` ENABLE KEYS */;


--
-- Definition of table `tbresident`
--

DROP TABLE IF EXISTS `tbresident`;
CREATE TABLE `tbresident` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `surname` varchar(200) NOT NULL,
  `fname` varchar(200) NOT NULL,
  `mname` varchar(200) NOT NULL,
  `bday` varchar(200) NOT NULL,
  `age` varchar(200) NOT NULL,
  `birthplace` varchar(200) NOT NULL,
  `sex` varchar(200) NOT NULL,
  `civil` varchar(200) NOT NULL,
  `citizen` varchar(200) NOT NULL,
  `relgion` varchar(200) NOT NULL,
  `occupation` varchar(200) NOT NULL,
  `houseno` varchar(200) NOT NULL,
  `purok` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbresident`
--

/*!40000 ALTER TABLE `tbresident` DISABLE KEYS */;
INSERT INTO `tbresident` (`id`,`surname`,`fname`,`mname`,`bday`,`age`,`birthplace`,`sex`,`civil`,`citizen`,`relgion`,`occupation`,`houseno`,`purok`) VALUES 
 (1,'Senoc','Gary','M','Tuesday, September 3, 2019','12','palawan','Male','Single','Filipino','Catholic','student','12','Pagkakaisa'),
 (2,'sdffdqgs','sfd','sfs','Tuesday, September 3, 2019','sf','ad','Male','Single','123','123','123','12','Bagong Buhay');
/*!40000 ALTER TABLE `tbresident` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
