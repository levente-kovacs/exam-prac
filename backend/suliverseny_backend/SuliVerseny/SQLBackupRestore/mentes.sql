-- MySqlBackup.NET 2.3.7.0
-- Dump Time: 2023-02-07 09:48:45
-- --------------------------------------
-- Server version 10.4.22-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of iskolak
-- 

DROP TABLE IF EXISTS `iskolak`;
CREATE TABLE IF NOT EXISTS `iskolak` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `iskolaId` int(11) NOT NULL,
  `nev` varchar(60) COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `iskolaId` (`iskolaId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table iskolak
-- 

/*!40000 ALTER TABLE `iskolak` DISABLE KEYS */;
INSERT INTO `iskolak`(`Id`,`iskolaId`,`nev`) VALUES(1,11,'Andrássy Gyula Gépipari Technikum'),(2,13,'Baross Gábor Üzleti és Közlekedési Technikum'),(3,2,'Berzeviczy Gergely Technikum'),(4,4,'Bláthy Ottó Villamosipari Technikum'),(5,15,'Kandó Kálmán Informatikai Technikum'),(6,14,'Kós Károly Építőipari, Kreatív Technikum és Szakképző Iskola'),(7,24,'Martin János Szakiskola és Készségfejlesztő Iskola'),(8,26,'Mezőcsáti Gimnázium és Szakképző Iskola'),(9,22,'Mezőkövesdi Szent László Gimnázium és Közgazdasági Technikum'),(10,18,'Szemere Bertalan Technikum,Szakképző Iskola és Kollégium'),(11,19,'Szentpáli István Kereskedelmi és Vendéglátó Technikum és Sza');
/*!40000 ALTER TABLE `iskolak` ENABLE KEYS */;

-- 
-- Definition of felhasznalok
-- 

DROP TABLE IF EXISTS `felhasznalok`;
CREATE TABLE IF NOT EXISTS `felhasznalok` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FelhasznaloNev` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TeljesNev` varchar(50) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `imagePath` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `iskolaId` int(11) NOT NULL,
  `SALT` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `HASH` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Jogosultsag` int(1) NOT NULL,
  `Aktiv` int(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `FelhasznaloNev` (`FelhasznaloNev`),
  UNIQUE KEY `Email` (`Email`),
  KEY `iskolaId` (`iskolaId`),
  CONSTRAINT `felhasznalok_ibfk_1` FOREIGN KEY (`iskolaId`) REFERENCES `iskolak` (`iskolaId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table felhasznalok
-- 

/*!40000 ALTER TABLE `felhasznalok` DISABLE KEYS */;
INSERT INTO `felhasznalok`(`Id`,`FelhasznaloNev`,`TeljesNev`,`imagePath`,`iskolaId`,`SALT`,`HASH`,`Email`,`Jogosultsag`,`Aktiv`) VALUES(1,'a','Admin','xd.jpg',15,'T38sNjbuq8HaemE8VUR2oDAzKbXfDAmjnaLEaYGQeSlBAsjp1IVOGTDwuaadLhHw','8fbcc841c5c4836f97008cc79c180daf0fe86f0aff701c9c4935f433de2566d3','kerenyir@kkszki.hu',9,1),(7,'b','Béluska','userDefault.jpg',15,'qHv6merskIB9KXCWxlJLEUnZbm6EgtzeyvRmCrG9AbNmKwTWVj87Wd7VeVf9inL0','cc65c60f2bdc57caac02b81ba0a848ce41f62aaec5f9769a9b813160a4670b6e','bela@bela.hu',3,0),(8,'c','cecilia','userDefault.jpg',15,'YebnNW56Tfka5LwQCldV3p1tz0S6rBHWWnbfceqPoU4O9nYcMAYT1VktmsyXE9OS','9335afbdac64538cba1038f6d71a6352c8a0e021de6dff0483e2ef35d71b2b83','cicacecilia',8,1),(22,'Teszt','Teszt Elek','sullivan.gif',15,'dsakdfhdlkfdshnljsdsdlfsd','uj jelszo','kerenyirobert18@gmail.com',0,1),(24,'puda','Puda Ádám','puda.jpg',15,'TEdayeQX3pCp9nznnlNQfBXTCBzFPBAawNqlgLfy0ZmN6gy2VS5dAIf1dqWZunuK','83b216eebacb8fa8409d7012d54f259814ef8aa62a76b7afc82966305b917a05','pudaa@kkszki.hu',9,1),(25,'jakabb','Jakab Balázs Erik','jakab.jpg',15,'6MN8zWiTm1q14o4rDWiJOVTzgHHdMcWWlTvKdyytoVbE5WpHHxM22eGHfjMkRkoA','3cad5c53ce74bac1ce0e264b59d85592845d8f9953f1f8ad79dee708c19423d4','jakabb1@kkszki.hu',5,0),(26,'liktora','Liktor Adrián','futo.JPG',15,'oahQIk2Jf5scqivYE7MVxDg8Q2f5MYTgpO0ezSIw4QnQcrxwtVWal07cdGOIePKJ','46b5894839b8c5f5ff5e982d230470b07adc65a30591faef500e1d2f32991ba1','liktora@kkszki.hu',0,1),(34,'TesztE','Teszt Elek','userdefault.jpg',14,'sHg2f5lAXxDR3Ti1jhlaG8KKxmqIQiLeJXJ8erhXfqdhRgJ5b83Y7IoN61QWTIGr','ef3687cda0bd025e7843e79ca1efa69cbf3e5ad0e19e00c9a8dc71244de2c7cc','teszt@elek.hu',9,0),(35,'pasztord','Pásztor Dávid','car2.jpg',15,'c9uNMHZCU1QeXimaRFesXbkQzlkKkOYcma0q9p2mLyhbnrG4a0vGIJTwHi8BY7DC','25a43828942467492aefe3416138898602db02cd605d8b8715975402cd7beec7','pasztord@kkszki.hu',6,1);
/*!40000 ALTER TABLE `felhasznalok` ENABLE KEYS */;

-- 
-- Definition of iskolalogok
-- 

DROP TABLE IF EXISTS `iskolalogok`;
CREATE TABLE IF NOT EXISTS `iskolalogok` (
  `id` int(11) NOT NULL,
  `iskolaId` int(11) NOT NULL,
  `logo` mediumblob NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `iskolaId` (`iskolaId`),
  CONSTRAINT `iskolalogok_ibfk_1` FOREIGN KEY (`iskolaId`) REFERENCES `iskolak` (`iskolaId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table iskolalogok
-- 

/*!40000 ALTER TABLE `iskolalogok` DISABLE KEYS */;
/*!40000 ALTER TABLE `iskolalogok` ENABLE KEYS */;

-- 
-- Definition of registry
-- 

DROP TABLE IF EXISTS `registry`;
CREATE TABLE IF NOT EXISTS `registry` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FelhasznaloNev` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TeljesNev` varchar(50) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `SALT` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `HASH` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Key` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `key` (`Key`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table registry
-- 

/*!40000 ALTER TABLE `registry` DISABLE KEYS */;
INSERT INTO `registry`(`Id`,`FelhasznaloNev`,`TeljesNev`,`SALT`,`HASH`,`Email`,`Key`) VALUES(11,'Teszt','Teszt Elek','dsakdfhdlkfdshnljsdsdlfsd','erewqrqreqereqwrqwrqwr','kerenyirobert18@kkszki.hu','MP75jJosKDVtuWo0rfduLSGSUEogOMdfhb2zql3odJt3JIjIJtxZOn84IplfeId8'),(13,'t','t','tSpKbtrWaXfHVbzbzKq6ZsaI0aBnwJdwjQZrrnGCQfamuUDmBGkz8wjSVhI2CaiM','9feefd1672f3361343464e4426a7f2dd13fc4540ac012e4f14d0f21e9451538b','t@t.hu','Owf3kHJrA3DungoKe4vfYTf05SCcd7nEp9siK0YrvIqrK88DN25GIdRxUq4Deync'),(14,'u','z','c1SonOLej2z4a95VpuNL1jMJo1xSRzN6r3mhmaMHGMpCQakK624p75UmVYcZ8mz5','5761ef82a29e87af10bef188164dd1c370433e0d41e754956a51c31abe9ed4fa','u@u.hu','bxK4P61EjQqdE7ryc2fGHlR7TxAO69ByQv8wKQDeIQ1TEbMJWbv92NSGv3W8B8Jm');
/*!40000 ALTER TABLE `registry` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2023-02-07 09:48:45
-- Total time: 0:0:0:0:380 (d:h:m:s:ms)