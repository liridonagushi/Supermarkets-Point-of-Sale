-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.16-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.4.0.5169
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for dmobiledb
CREATE DATABASE IF NOT EXISTS `dmobiledb` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `dmobiledb`;

-- Dumping structure for table dmobiledb.attachments
CREATE TABLE IF NOT EXISTS `attachments` (
  `id_attachment` int(11) NOT NULL AUTO_INCREMENT,
  `name_doc` varchar(50) DEFAULT NULL,
  `description` varchar(200) NOT NULL DEFAULT '0',
  `name_file` varchar(20) DEFAULT NULL,
  `date_insert` date DEFAULT NULL,
  PRIMARY KEY (`id_attachment`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.attachments: ~43 rows (approximately)
DELETE FROM `attachments`;
/*!40000 ALTER TABLE `attachments` DISABLE KEYS */;
INSERT INTO `attachments` (`id_attachment`, `name_doc`, `description`, `name_file`, `date_insert`) VALUES
	(1, 'Doc 1', 'bvnnbnbv', '101150.pdf', '2016-12-21'),
	(2, 'Doc 2', '23213321', '103020.pdf', '2016-11-21'),
	(3, 'Doc 3', '0', NULL, '2016-12-21'),
	(4, 'Doc 1', '432', NULL, '2016-12-21'),
	(5, '123213321321', '3132321', '', '2016-12-21'),
	(6, '21321312', '123213321321', NULL, '2016-12-21'),
	(7, '123', '23213321', '', '2016-12-21'),
	(8, 'Contrat', 'Company Contrat with client ...', '113924.pdf', '2017-02-06'),
	(9, 'bvcnbv', '32532112321', '101515.pdf', '2016-12-21'),
	(10, '324432432', '21332213', '102152.pdf', '2016-12-21'),
	(11, '132321', '43243432', '', '2016-12-21'),
	(12, '213213', '213321321', NULL, '2016-12-21'),
	(13, 'Doc 2', '213321321', NULL, '2016-12-21'),
	(14, '324432432', '21332213', '', '2016-12-21'),
	(15, '213321321321', '324432432', NULL, '2016-12-21'),
	(16, '123324432432432', '213213321213213', '', '2016-12-21'),
	(17, '324432432', '43243432', '', '2016-12-21'),
	(18, '213213', '213213321', '115838.pdf', '2016-12-21'),
	(19, '123', '123', '', '2016-12-21'),
	(20, '123213', '123', '', '2016-12-21'),
	(21, '213', '213', NULL, '2016-12-21'),
	(22, '1231', '123', '', '2016-12-21'),
	(23, '213vcx', '213', '090804.pdf', '2016-12-21'),
	(24, '213321321', '213321', '090903.exe', '2016-12-21'),
	(25, '213213', '213321', NULL, '2016-12-21'),
	(26, '213321', '32132321', NULL, '2016-12-21'),
	(27, '213', '321321', NULL, '2016-12-21'),
	(28, '213', '213', NULL, '2016-12-21'),
	(30, '213213213', '213', '', '2016-12-21'),
	(31, '213213213213', '213213', '', '2016-12-21'),
	(32, '2131321321321321fdfd', 'fdggfgfd', '093155.pdf', '2016-12-21'),
	(33, '21321321', '123213213', '093321.pdf', '2016-12-21'),
	(35, '13232132', '13213212', NULL, '2016-12-21'),
	(37, '132321213321', '32132132', NULL, '2016-12-21'),
	(38, '213321321213', '21332321', '', '2016-12-21'),
	(39, '213321321213231', '213321321', NULL, '2016-12-21'),
	(40, '32443432', '54343', '', '2016-12-21'),
	(42, '213321321212', '321321321', NULL, '2016-12-21'),
	(43, '123321321', '321321321213', '', '2016-12-21'),
	(44, '21321', '32132132132121', '', '2017-01-31'),
	(45, 'kontrata e lokalit', 'nmcvxbnvnvx', '', '2017-03-04'),
	(46, 'kontrata me firmen b', 'j]jdcjsbbncs  csnscncbsmmn', '', '2017-04-11'),
	(47, '42234234', '243423423', '', '2017-04-14');
/*!40000 ALTER TABLE `attachments` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.backuplinks
CREATE TABLE IF NOT EXISTS `backuplinks` (
  `id_link` int(11) NOT NULL AUTO_INCREMENT,
  `type_backup` varchar(50) NOT NULL,
  `backupfolder` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id_link`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.backuplinks: ~2 rows (approximately)
DELETE FROM `backuplinks`;
/*!40000 ALTER TABLE `backuplinks` DISABLE KEYS */;
INSERT INTO `backuplinks` (`id_link`, `type_backup`, `backupfolder`) VALUES
	(1, 'local', 'D:\\backup\\'),
	(2, 'server', 'C:\\Users\\Public\\Documents\\testbackup\\');
/*!40000 ALTER TABLE `backuplinks` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.backup_db
CREATE TABLE IF NOT EXISTS `backup_db` (
  `id_backup` int(11) NOT NULL AUTO_INCREMENT,
  `name_backup` varchar(20) DEFAULT NULL,
  `date_backup` date DEFAULT NULL,
  PRIMARY KEY (`id_backup`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.backup_db: ~3 rows (approximately)
DELETE FROM `backup_db`;
/*!40000 ALTER TABLE `backup_db` DISABLE KEYS */;
INSERT INTO `backup_db` (`id_backup`, `name_backup`, `date_backup`) VALUES
	(1, '1', '2016-12-16'),
	(2, '10', '2017-03-10'),
	(3, '20', '2017-03-20');
/*!40000 ALTER TABLE `backup_db` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.bought_ocassion
CREATE TABLE IF NOT EXISTS `bought_ocassion` (
  `id_ocassion` int(11) NOT NULL AUTO_INCREMENT,
  `id_product` int(11) NOT NULL DEFAULT '0',
  `id_staff` int(11) NOT NULL DEFAULT '0',
  `qty` int(11) NOT NULL DEFAULT '0',
  `unity_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `total_buy` decimal(10,2) NOT NULL DEFAULT '0.00',
  `date_buy` date NOT NULL,
  `end_session` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_ocassion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.bought_ocassion: ~2 rows (approximately)
DELETE FROM `bought_ocassion`;
/*!40000 ALTER TABLE `bought_ocassion` DISABLE KEYS */;
INSERT INTO `bought_ocassion` (`id_ocassion`, `id_product`, `id_staff`, `qty`, `unity_price`, `total_buy`, `date_buy`, `end_session`) VALUES
	(1, 1, 1, 1, 180.00, 180.00, '2017-04-23', 1),
	(2, 1, 1, 1, 170.00, 170.00, '2017-04-23', 1);
/*!40000 ALTER TABLE `bought_ocassion` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.clients
CREATE TABLE IF NOT EXISTS `clients` (
  `id_client` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(50) DEFAULT NULL,
  `other_details` mediumtext,
  `total_points` decimal(10,2) NOT NULL DEFAULT '0.00',
  `date_registration` date DEFAULT NULL,
  `active` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`id_client`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.clients: ~11 rows (approximately)
DELETE FROM `clients`;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` (`id_client`, `fullname`, `other_details`, `total_points`, `date_registration`, `active`) VALUES
	(1, 'Liridon Agushi', 'Dot Rond nbnvnnbv', 389.60, '2016-11-28', 1),
	(2, 'Agushi1', 'Agushi', 31.70, '2016-11-28', 1),
	(3, 'adile', 'company1', 44.00, '2016-11-30', 1),
	(4, '123', '213', 3.80, '2017-03-17', 1),
	(5, 'liridon', 'dsakjhdsaj', 0.00, '2017-03-17', 1),
	(6, 'gazmend doda', 'Preshev perball marketit MEN, 0625468, doda@doda.com', 0.00, '2017-03-04', 1),
	(7, 'liridon', 'bvvcmbvc,nbvcm', 2.60, '2017-03-11', 1),
	(8, 'valoni geraj', '06225334534 i magacinit', 0.00, '2017-04-11', 1),
	(9, 'nmjvjvdnc', 'vdjdjfjdfjhdgghj 06324356', 0.00, '2017-04-14', 1),
	(10, '123213321', '123132123', 0.00, '2017-04-27', 1),
	(11, 'test register', 'rewfdggfdgfgfd', 0.00, '2017-04-27', 1);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.client_debts
CREATE TABLE IF NOT EXISTS `client_debts` (
  `id_debt` int(11) NOT NULL AUTO_INCREMENT,
  `StaffID` int(11) DEFAULT NULL,
  `id_client` int(11) DEFAULT NULL,
  `InvoiceNo` varchar(20) DEFAULT '0',
  `debtValue` decimal(10,2) DEFAULT '0.00',
  `debtDate` date DEFAULT NULL,
  `type_payment` int(11) DEFAULT '1',
  PRIMARY KEY (`id_debt`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.client_debts: ~3 rows (approximately)
DELETE FROM `client_debts`;
/*!40000 ALTER TABLE `client_debts` DISABLE KEYS */;
INSERT INTO `client_debts` (`id_debt`, `StaffID`, `id_client`, `InvoiceNo`, `debtValue`, `debtDate`, `type_payment`) VALUES
	(1, 1, 2, '22', 200.00, '2017-04-23', 3),
	(2, 1, 1, '26', 2040.00, '2017-04-23', 3),
	(3, 1, 4, '29', 380.00, '2017-04-23', 3);
/*!40000 ALTER TABLE `client_debts` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.company
CREATE TABLE IF NOT EXISTS `company` (
  `id_company` int(11) NOT NULL AUTO_INCREMENT,
  `id_currency` tinyint(4) DEFAULT NULL,
  `companyName` varchar(50) NOT NULL,
  `manager` varchar(50) NOT NULL,
  `contactNumber` varchar(50) DEFAULT NULL,
  `CompanySN` varchar(50) NOT NULL,
  `BANK_Number` varchar(50) NOT NULL,
  `adress` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `country` varchar(50) NOT NULL,
  `base_currency` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_company`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.company: ~0 rows (approximately)
DELETE FROM `company`;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` (`id_company`, `id_currency`, `companyName`, `manager`, `contactNumber`, `CompanySN`, `BANK_Number`, `adress`, `city`, `country`, `base_currency`) VALUES
	(1, 4, 'DotRond', 'Liridon', '0638002549', '123456789', '01010101', 'Shoshaj', 'Preshev', 'Serbia', 4);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.distributors
CREATE TABLE IF NOT EXISTS `distributors` (
  `id_distributor` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(50) DEFAULT NULL,
  `company` varchar(20) DEFAULT NULL,
  `BankAccountNumber` varchar(30) DEFAULT NULL,
  `adress` varchar(50) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL,
  `p_code` varchar(10) DEFAULT NULL,
  `country` varchar(50) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(20) DEFAULT NULL,
  `date_registration` date DEFAULT NULL,
  `active` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`id_distributor`),
  UNIQUE KEY `BankAccountNumber` (`BankAccountNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.distributors: ~3 rows (approximately)
DELETE FROM `distributors`;
/*!40000 ALTER TABLE `distributors` DISABLE KEYS */;
INSERT INTO `distributors` (`id_distributor`, `fullname`, `company`, `BankAccountNumber`, `adress`, `city`, `p_code`, `country`, `phone`, `email`, `date_registration`, `active`) VALUES
	(1, 'John Doe', 'Microsoft', '213132', 'Chicago', 'Chicago', '123456PCOD', 'US', '123456789Phone', 'j.doe@email.com', '2016-12-02', 1),
	(2, 'Don Doe', 'Apple', '789123', 'Chicago', 'Chicago', '54564564', 'US', '2545646874', 'd.doe@email.com', '2016-12-02', 1),
	(3, '123123321', '32121321', NULL, '21321321', '213321', '21321', '321321321', '321321321', '321321321', NULL, 1);
/*!40000 ALTER TABLE `distributors` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.employee_stats
CREATE TABLE IF NOT EXISTS `employee_stats` (
  `id_stat` int(11) NOT NULL AUTO_INCREMENT,
  `id_employee` int(11) DEFAULT NULL,
  `time_start` datetime DEFAULT NULL,
  `time_end` datetime DEFAULT NULL,
  `hours_worked` decimal(10,2) DEFAULT '0.00',
  `NonVatAmount` decimal(10,3) DEFAULT '0.000',
  `VatAmount` decimal(10,3) DEFAULT '0.000',
  `TotalAmount` decimal(10,3) DEFAULT '0.000',
  `TotalDebtAmount` decimal(10,2) DEFAULT '0.00',
  `service_amount` decimal(10,2) DEFAULT '0.00',
  `returned_debts` decimal(10,2) DEFAULT '0.00',
  `buys_amount` decimal(10,2) DEFAULT '0.00',
  `total_sum` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`id_stat`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.employee_stats: ~3 rows (approximately)
DELETE FROM `employee_stats`;
/*!40000 ALTER TABLE `employee_stats` DISABLE KEYS */;
INSERT INTO `employee_stats` (`id_stat`, `id_employee`, `time_start`, `time_end`, `hours_worked`, `NonVatAmount`, `VatAmount`, `TotalAmount`, `TotalDebtAmount`, `service_amount`, `returned_debts`, `buys_amount`, `total_sum`) VALUES
	(1, 1, '2017-04-27 23:55:34', '2017-04-27 23:59:22', 0.30, 514.550, 25.450, 540.000, 0.00, 1464.00, 0.00, 0.00, 2004.00),
	(2, 1, '2017-04-27 23:59:59', '2017-04-28 00:18:36', 0.18, 260.000, 0.000, 260.000, 0.00, 0.00, 0.00, 0.00, 260.00),
	(3, 1, '2017-04-28 13:57:19', NULL, 0.00, 0.000, 0.000, 0.000, 0.00, 0.00, 0.00, 0.00, 0.00);
/*!40000 ALTER TABLE `employee_stats` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.imp_invoices
CREATE TABLE IF NOT EXISTS `imp_invoices` (
  `id_invoice` int(11) NOT NULL AUTO_INCREMENT,
  `id_distributor` int(11) DEFAULT '0',
  `invoice_code` varchar(20) DEFAULT NULL,
  `date_invoice` date DEFAULT NULL,
  `date_registration` date DEFAULT NULL,
  `date_payment` date DEFAULT NULL,
  `vatAmount` decimal(10,3) DEFAULT '0.000',
  `benefitAmount` decimal(10,3) DEFAULT '0.000',
  `importAmount` decimal(10,3) DEFAULT '0.000',
  `totalAmount` decimal(10,3) DEFAULT '0.000',
  `payment_status` tinyint(4) DEFAULT '0',
  `id_type_payment` varchar(50) DEFAULT '0',
  PRIMARY KEY (`id_invoice`),
  UNIQUE KEY `number_facture` (`invoice_code`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.imp_invoices: ~1 rows (approximately)
DELETE FROM `imp_invoices`;
/*!40000 ALTER TABLE `imp_invoices` DISABLE KEYS */;
INSERT INTO `imp_invoices` (`id_invoice`, `id_distributor`, `invoice_code`, `date_invoice`, `date_registration`, `date_payment`, `vatAmount`, `benefitAmount`, `importAmount`, `totalAmount`, `payment_status`, `id_type_payment`) VALUES
	(1, 3, '324432', '2017-03-05', '2017-04-15', '2017-04-15', 38.330, 1800.000, 6400.000, 8200.000, 1, '2'),
	(2, 1, '123321', '2017-04-28', '2017-04-28', '2017-05-08', 38.330, 1500.000, 5400.000, 6900.000, 0, '1');
/*!40000 ALTER TABLE `imp_invoices` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.invoiceprocessing
CREATE TABLE IF NOT EXISTS `invoiceprocessing` (
  `id_invoiceProcessing` int(11) NOT NULL AUTO_INCREMENT,
  `id_order` int(11) DEFAULT '0',
  `invoice_code` varchar(50) DEFAULT '0',
  `id_distributor` int(11) DEFAULT '0',
  `id_product` int(11) DEFAULT '0',
  `vatPerc` int(11) DEFAULT '0',
  `maj_unit_price` decimal(10,3) DEFAULT '0.000',
  `unit_price` decimal(10,3) DEFAULT '0.000',
  `stockstotal` decimal(10,3) DEFAULT '0.000',
  `stocks_insert` decimal(10,3) DEFAULT '0.000',
  `freeQty` int(11) DEFAULT '0',
  `import_amount` decimal(10,3) DEFAULT '0.000',
  `vat_amount` decimal(10,3) DEFAULT '0.000',
  `sell_amount` decimal(10,3) DEFAULT '0.000',
  PRIMARY KEY (`id_invoiceProcessing`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.invoiceprocessing: ~3 rows (approximately)
DELETE FROM `invoiceprocessing`;
/*!40000 ALTER TABLE `invoiceprocessing` DISABLE KEYS */;
INSERT INTO `invoiceprocessing` (`id_invoiceProcessing`, `id_order`, `invoice_code`, `id_distributor`, `id_product`, `vatPerc`, `maj_unit_price`, `unit_price`, `stockstotal`, `stocks_insert`, `freeQty`, `import_amount`, `vat_amount`, `sell_amount`) VALUES
	(1, 1, '324432', 3, 2, 20, 0.000, 230.000, 290.000, 30.000, 0, 5400.000, 38.330, 6900.000),
	(2, 2, '324432', 3, 7, 0, 230.000, 260.000, 1234307.000, 5.000, 0, 1000.000, 0.000, 1300.000),
	(3, 1, '123321', 1, 2, 20, 0.000, 230.000, 315.000, 30.000, 0, 5400.000, 38.330, 6900.000);
/*!40000 ALTER TABLE `invoiceprocessing` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.messages
CREATE TABLE IF NOT EXISTS `messages` (
  `id_message` int(11) NOT NULL AUTO_INCREMENT,
  `id_sender` int(11) DEFAULT NULL,
  `id_receiver` int(11) DEFAULT NULL,
  `message` varchar(70) DEFAULT NULL,
  `date_msg` datetime DEFAULT CURRENT_TIMESTAMP,
  `seen` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_message`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.messages: ~0 rows (approximately)
DELETE FROM `messages`;
/*!40000 ALTER TABLE `messages` DISABLE KEYS */;
/*!40000 ALTER TABLE `messages` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.paiddebts
CREATE TABLE IF NOT EXISTS `paiddebts` (
  `id_paid_debt` int(11) NOT NULL AUTO_INCREMENT,
  `StaffID` int(11) NOT NULL DEFAULT '0',
  `CustomerNo` int(11) NOT NULL,
  `debtValue` decimal(10,2) NOT NULL,
  `paidDate` date NOT NULL,
  `type_payment` int(11) DEFAULT NULL,
  `end_session` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_paid_debt`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.paiddebts: ~7 rows (approximately)
DELETE FROM `paiddebts`;
/*!40000 ALTER TABLE `paiddebts` DISABLE KEYS */;
INSERT INTO `paiddebts` (`id_paid_debt`, `StaffID`, `CustomerNo`, `debtValue`, `paidDate`, `type_payment`, `end_session`) VALUES
	(1, 1, 2, 60.00, '2017-04-23', 1, 1),
	(2, 1, 2, 530.00, '2017-04-23', 1, 1),
	(3, 1, 2, 300.00, '2017-04-23', 1, 1),
	(4, 1, 1, 2080.00, '2017-04-23', 1, 1),
	(5, 1, 1, 200.00, '2017-04-23', 1, 1),
	(6, 1, 1, 200.00, '2017-04-23', 1, 1),
	(7, 1, 1, 100.00, '2017-04-23', 1, 1),
	(8, 1, 1, 200.00, '2017-04-23', 1, 1);
/*!40000 ALTER TABLE `paiddebts` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.payment
CREATE TABLE IF NOT EXISTS `payment` (
  `PaymentNo` int(20) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(80) NOT NULL DEFAULT '0',
  `Cash` decimal(10,2) NOT NULL DEFAULT '0.00',
  `changeMoney` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`PaymentNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.payment: ~0 rows (approximately)
DELETE FROM `payment`;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.pos
CREATE TABLE IF NOT EXISTS `pos` (
  `InvoiceNo` int(20) NOT NULL,
  `StaffID` int(11) DEFAULT '1',
  `id_client` int(11) DEFAULT '0',
  `type_payment` tinyint(4) DEFAULT '1',
  `POSDate` datetime DEFAULT NULL,
  `NonVatAmount` decimal(20,2) DEFAULT '0.00',
  `VatAmount` decimal(20,2) DEFAULT '0.00',
  `TotalAmount` decimal(20,2) DEFAULT '0.00',
  `end_session` tinyint(1) DEFAULT '0',
  `discount_amount` decimal(10,2) DEFAULT '0.00',
  `majority_bool` tinyint(4) DEFAULT '0',
  `updatedPrice` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`InvoiceNo`),
  UNIQUE KEY `InvoiceNo` (`InvoiceNo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Dumping data for table dmobiledb.pos: 4 rows
DELETE FROM `pos`;
/*!40000 ALTER TABLE `pos` DISABLE KEYS */;
INSERT INTO `pos` (`InvoiceNo`, `StaffID`, `id_client`, `type_payment`, `POSDate`, `NonVatAmount`, `VatAmount`, `TotalAmount`, `end_session`, `discount_amount`, `majority_bool`, `updatedPrice`) VALUES
	(1, 1, 0, 1, NULL, 0.00, 0.00, 0.00, 1, 0.00, 0, 0),
	(2, 1, 0, 1, '2017-04-27 23:57:28', 254.55, 25.45, 280.00, 1, 0.00, 0, 0),
	(3, 1, 0, 1, '2017-04-27 23:57:37', 260.00, 0.00, 260.00, 1, 0.00, 0, 0),
	(4, 1, 0, 1, '2017-04-28 00:18:31', 260.00, 0.00, 260.00, 1, 0.00, 0, 0);
/*!40000 ALTER TABLE `pos` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.posdetails
CREATE TABLE IF NOT EXISTS `posdetails` (
  `POSDetailNo` int(20) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` int(20) DEFAULT NULL,
  `id_product` int(11) DEFAULT NULL,
  `vatAmount` decimal(10,2) DEFAULT '0.00',
  `productPrice` decimal(10,2) DEFAULT '0.00',
  `Quantity` decimal(10,2) DEFAULT '0.00',
  `discount_percentage` decimal(10,2) DEFAULT '0.00',
  `discount_amount` decimal(10,2) DEFAULT '0.00',
  `total_amount` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`POSDetailNo`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Dumping data for table dmobiledb.posdetails: 3 rows
DELETE FROM `posdetails`;
/*!40000 ALTER TABLE `posdetails` DISABLE KEYS */;
INSERT INTO `posdetails` (`POSDetailNo`, `InvoiceNo`, `id_product`, `vatAmount`, `productPrice`, `Quantity`, `discount_percentage`, `discount_amount`, `total_amount`) VALUES
	(1, 2, 3, 25.45, 280.00, 1.00, 0.00, 0.00, 280.00),
	(2, 3, 7, 0.00, 260.00, 1.00, 0.00, 0.00, 260.00),
	(3, 4, 7, 0.00, 260.00, 1.00, 0.00, 0.00, 260.00);
/*!40000 ALTER TABLE `posdetails` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.price_hist
CREATE TABLE IF NOT EXISTS `price_hist` (
  `id_modification` int(11) NOT NULL AUTO_INCREMENT,
  `id_product` int(11) DEFAULT NULL,
  `old_price` decimal(10,2) DEFAULT NULL,
  `new_price` decimal(10,2) DEFAULT NULL,
  `date_mod` date DEFAULT NULL,
  PRIMARY KEY (`id_modification`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.price_hist: ~8 rows (approximately)
DELETE FROM `price_hist`;
/*!40000 ALTER TABLE `price_hist` DISABLE KEYS */;
INSERT INTO `price_hist` (`id_modification`, `id_product`, `old_price`, `new_price`, `date_mod`) VALUES
	(1, 2, 230.00, 5400.00, '2017-04-15'),
	(2, 7, 260.00, 1000.00, '2017-04-15'),
	(3, 1, 160.00, 250.00, '2017-04-16'),
	(4, 1, 250.00, 300.00, '2017-04-16'),
	(5, 1, 300.00, 100.00, '2017-04-16'),
	(6, 1, 100.00, 300.00, '2017-04-16'),
	(7, 1, 300.00, 301.00, '2017-04-16'),
	(8, 2, 230.00, 5400.00, '2017-04-28');
/*!40000 ALTER TABLE `price_hist` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.products
CREATE TABLE IF NOT EXISTS `products` (
  `id_product` int(11) NOT NULL AUTO_INCREMENT,
  `barcode` varchar(20) DEFAULT NULL,
  `description` varchar(80) DEFAULT NULL,
  `id_type` tinyint(4) DEFAULT '1',
  `id_category` int(11) DEFAULT NULL,
  `import_price` decimal(8,2) DEFAULT '0.00',
  `id_tax` int(11) DEFAULT '0',
  `majority_price` decimal(10,2) DEFAULT '0.00',
  `tax_majority` decimal(10,2) DEFAULT '0.00',
  `tax_amount` decimal(10,2) DEFAULT '0.00',
  `sold_price` decimal(10,2) DEFAULT '0.00',
  `quantity` decimal(10,2) DEFAULT '0.00',
  `quantity_processing` decimal(10,2) DEFAULT '0.00',
  `free_offer` tinyint(4) DEFAULT '0',
  `imported_qty` decimal(10,2) DEFAULT '0.00',
  `total_import_amount` decimal(10,2) DEFAULT '0.00',
  `date_insert` date DEFAULT NULL,
  PRIMARY KEY (`id_product`),
  UNIQUE KEY `barcode` (`barcode`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.products: ~21 rows (approximately)
DELETE FROM `products`;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` (`id_product`, `barcode`, `description`, `id_type`, `id_category`, `import_price`, `id_tax`, `majority_price`, `tax_majority`, `tax_amount`, `sold_price`, `quantity`, `quantity_processing`, `free_offer`, `imported_qty`, `total_import_amount`, `date_insert`) VALUES
	(1, '213321', 'Cokolada Nestle', 1, 0, 170.00, 3, 300.00, 21.67, 50.17, 301.00, 77.00, 20.00, 1, 200.00, 24000.00, '2016-12-26'),
	(2, '123', 'Cokolada Milka', 3, 1, 180.00, 3, 170.00, 0.00, 38.33, 230.00, 345.00, 0.00, 0, 30.00, 5400.00, '2016-12-26'),
	(3, '12345678', 'Swatch Watches', 2, 0, 100.00, 2, 0.00, 0.00, 20.00, 280.00, 4322122.00, 20.00, 0, 0.00, 0.00, '2016-12-17'),
	(4, '123132', '13564', 1, 0, 120.00, 3, 0.00, 0.00, 33.33, 200.00, 132318.00, 0.00, 0, 0.00, 0.00, '2016-12-26'),
	(6, '123456', '13564', 3, 4, 20.00, 2, 0.00, 0.00, 9.09, 100.00, 243425.00, 0.00, 0, 0.00, 0.00, '2016-12-26'),
	(7, '213', '321', 3, 3, 200.00, 1, 230.00, 0.00, 0.00, 260.00, 1234293.00, 2.00, 0, 5.00, 1000.00, '2016-12-26'),
	(8, 'testproduct', 'test product', 1, 3, 0.00, 3, 0.00, 0.00, 33.33, 200.00, 5430.00, 0.00, 0, 1.00, 0.00, '2017-01-19'),
	(9, 'prodtest', '2132131', 1, 2, 0.00, 3, 0.00, 0.00, 41.67, 250.00, 124333.00, 0.00, 0, 1.00, 0.00, '2017-01-19'),
	(10, '1232131', '213', 3, 2, 25.00, 3, 125.00, 20.83, 21.33, 128.00, 213131.00, 0.00, 0, 10.00, 250.00, '2017-03-18'),
	(11, '1234566', 'bateri iphone 6', 1, 2, 120.00, 3, 0.00, 0.00, 30.00, 180.00, 7.00, 0.00, 1, 1.00, 120.00, '2017-03-04'),
	(12, '5315311515', 'KENT', 1, 1, 12.00, 3, 270.00, 45.00, 50.00, 300.00, 34.00, 0.00, 0, 12.00, 3000.00, '2017-03-04'),
	(13, '111', 'LCD IPHONE 5', 1, 2, 254548.00, 3, 250.00, 41.67, 423909.00, 2543454.00, 95.00, 0.00, 0, 20.00, 5090960.00, '2017-03-04'),
	(14, '21312', '213', 1, 1, 0.00, 3, 1212.00, 202.00, 2.00, 12.00, -1.00, 0.00, 0, 0.00, 0.00, '2017-03-25'),
	(15, 'zall', 'Zall', 1, 4, 0.00, 3, 134200.00, 22366.67, 24400.00, 146400.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-04-11'),
	(16, 'qewewqewq', 'qweewq', 1, 1, 0.00, 1, 213.00, 0.00, 0.00, 25986.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-04-16'),
	(17, '123123', '213', 1, 4, 0.00, 3, 12.00, 2.00, 2.00, 12.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-04-27'),
	(18, 'testprodukt', 'testprodukt', 1, 2, 0.00, 3, 12.00, 2.00, 2.00, 12.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-04-27'),
	(19, '12321', '123', 1, 1, 0.00, 3, 123.00, 20.50, 22.00, 132.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-04-27'),
	(20, 'produlkttesttaks', 'produlkttesttaks', 1, 1, 0.00, 3, 180.00, 30.00, 33.33, 200.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-04-28'),
	(21, 'testprodukt1', 'testprodukt1', 1, 1, 0.00, 3, 210.00, 35.00, 33.33, 200.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-05-01'),
	(22, 'testprodukt2', 'testprodukt2', 1, 1, 0.00, 3, 250.00, 41.67, 41.67, 250.00, 0.00, 0.00, 0, 0.00, 0.00, '2017-05-01');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.product_categories
CREATE TABLE IF NOT EXISTS `product_categories` (
  `id_category` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.product_categories: ~4 rows (approximately)
DELETE FROM `product_categories`;
/*!40000 ALTER TABLE `product_categories` DISABLE KEYS */;
INSERT INTO `product_categories` (`id_category`, `category_name`) VALUES
	(1, 'Cigare'),
	(2, 'Teknologji'),
	(3, 'Kredit'),
	(4, 'Tjera');
/*!40000 ALTER TABLE `product_categories` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.repairing_products_sold
CREATE TABLE IF NOT EXISTS `repairing_products_sold` (
  `id_repair` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) DEFAULT NULL,
  `id_product` int(11) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_repair`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.repairing_products_sold: ~1 rows (approximately)
DELETE FROM `repairing_products_sold`;
/*!40000 ALTER TABLE `repairing_products_sold` DISABLE KEYS */;
INSERT INTO `repairing_products_sold` (`id_repair`, `id_service`, `id_product`, `qty`) VALUES
	(2, 2, 3, 1);
/*!40000 ALTER TABLE `repairing_products_sold` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.repairing_services
CREATE TABLE IF NOT EXISTS `repairing_services` (
  `id_service` int(11) NOT NULL AUTO_INCREMENT,
  `id_client` int(11) DEFAULT NULL,
  `id_staff` int(11) DEFAULT '0',
  `header_service` varchar(200) DEFAULT NULL,
  `parts_cost` decimal(10,3) NOT NULL DEFAULT '0.000',
  `service_details` varchar(30) DEFAULT NULL,
  `service_details2` varchar(30) DEFAULT NULL,
  `vat_cost` decimal(10,3) DEFAULT NULL,
  `total_cost` decimal(10,3) DEFAULT NULL,
  `time_service` datetime DEFAULT NULL,
  `status_service` tinyint(4) DEFAULT '0' COMMENT '0=Duke servisuar; 1=me sukses; 2=pa sukses;',
  `end_session` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_service`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.repairing_services: ~2 rows (approximately)
DELETE FROM `repairing_services`;
/*!40000 ALTER TABLE `repairing_services` DISABLE KEYS */;
INSERT INTO `repairing_services` (`id_service`, `id_client`, `id_staff`, `header_service`, `parts_cost`, `service_details`, `service_details2`, `vat_cost`, `total_cost`, `time_service`, `status_service`, `end_session`) VALUES
	(1, NULL, 0, NULL, 0.000, NULL, NULL, NULL, NULL, NULL, 0, 1),
	(2, 2, 1, '213', 280.000, '213', '213', 244.000, 1464.000, '2017-04-27 23:57:56', 1, 1);
/*!40000 ALTER TABLE `repairing_services` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.saved_posdetails
CREATE TABLE IF NOT EXISTS `saved_posdetails` (
  `id_detail` int(20) NOT NULL AUTO_INCREMENT,
  `id_product` int(11) DEFAULT NULL,
  `vatAmount` decimal(20,2) DEFAULT '0.00',
  `ProductPrice` decimal(20,2) DEFAULT '0.00',
  `Quantity` decimal(10,2) DEFAULT '0.00',
  `discount_percentage` decimal(10,2) DEFAULT '0.00',
  `discount_amount` decimal(20,2) DEFAULT '0.00',
  `total_amount` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`id_detail`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Dumping data for table dmobiledb.saved_posdetails: 0 rows
DELETE FROM `saved_posdetails`;
/*!40000 ALTER TABLE `saved_posdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `saved_posdetails` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.stocksin
CREATE TABLE IF NOT EXISTS `stocksin` (
  `StocksInNo` int(11) NOT NULL AUTO_INCREMENT,
  `ItemNo` int(11) DEFAULT '0',
  `ItemQuantity` decimal(10,2) DEFAULT '0.00',
  `SIDate` date DEFAULT NULL,
  `CurrentStocks` decimal(10,2) DEFAULT '0.00',
  `number_facture` varchar(50) DEFAULT '0',
  PRIMARY KEY (`StocksInNo`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- Dumping data for table dmobiledb.stocksin: 18 rows
DELETE FROM `stocksin`;
/*!40000 ALTER TABLE `stocksin` DISABLE KEYS */;
INSERT INTO `stocksin` (`StocksInNo`, `ItemNo`, `ItemQuantity`, `SIDate`, `CurrentStocks`, `number_facture`) VALUES
	(1, 2, 20.00, '2017-03-13', 140.00, '78587656'),
	(2, 2, 20.00, '2017-03-18', 160.00, '213123213'),
	(3, 11, 1.00, '2017-03-18', 11.00, '213123213'),
	(4, 2, 20.00, '2017-03-18', 160.00, '213123213'),
	(5, 11, 1.00, '2017-03-18', 11.00, '213123213'),
	(6, 13, 10.00, '2017-03-19', 66.00, '123321'),
	(7, 11, 1.00, '2017-03-20', 6.00, '123'),
	(8, 2, 20.00, '2017-03-20', 200.00, '123'),
	(9, 13, 20.00, '2017-03-21', 76.00, 'hjjhhghg'),
	(10, 2, 20.00, '2017-03-21', 220.00, 'hjjhhghg'),
	(11, 2, 20.00, '2017-03-22', 240.00, '213321'),
	(12, 11, 1.00, '2017-03-22', 7.00, '213321'),
	(13, 2, 30.00, '2017-03-27', 260.00, '784387'),
	(14, 8, 1.00, '2017-03-27', 5429.00, '784387'),
	(15, 13, 50.00, '2017-04-11', 96.00, '545634345'),
	(16, 2, 30.00, '2017-04-15', 290.00, '324432'),
	(17, 7, 5.00, '2017-04-15', 1234307.00, '324432'),
	(18, 2, 30.00, '2017-04-28', 315.00, '123321');
/*!40000 ALTER TABLE `stocksin` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.suggested_products
CREATE TABLE IF NOT EXISTS `suggested_products` (
  `id_suggest` int(11) NOT NULL AUTO_INCREMENT,
  `keyword` varchar(50) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `id_user` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_suggest`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.suggested_products: ~4 rows (approximately)
DELETE FROM `suggested_products`;
/*!40000 ALTER TABLE `suggested_products` DISABLE KEYS */;
INSERT INTO `suggested_products` (`id_suggest`, `keyword`, `date`, `id_user`) VALUES
	(22, 'ekran iphone7', '2017-03-08', 1),
	(23, '13323443243234', '2017-04-14', 1),
	(24, 'bbncbncxvbn', '2017-04-14', 1),
	(25, 'produkt i sugjerurar', '2017-04-14', 1);
/*!40000 ALTER TABLE `suggested_products` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.sys_currency
CREATE TABLE IF NOT EXISTS `sys_currency` (
  `id_currency` int(11) NOT NULL AUTO_INCREMENT,
  `name_currency` varchar(20) DEFAULT NULL,
  `currency` varchar(10) DEFAULT NULL,
  `amount` decimal(10,1) DEFAULT '0.0',
  PRIMARY KEY (`id_currency`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.sys_currency: ~5 rows (approximately)
DELETE FROM `sys_currency`;
/*!40000 ALTER TABLE `sys_currency` DISABLE KEYS */;
INSERT INTO `sys_currency` (`id_currency`, `name_currency`, `currency`, `amount`) VALUES
	(1, 'Dollar', '$', 0.0),
	(2, 'Euro', 'Euro', 0.0),
	(3, 'Frank', 'CHF', 0.0),
	(4, 'Dinar', 'Din', 122.0),
	(5, 'Lek', 'Lek', 0.0);
/*!40000 ALTER TABLE `sys_currency` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.sys_fiscal_customization
CREATE TABLE IF NOT EXISTS `sys_fiscal_customization` (
  `id_fiscal` int(11) NOT NULL AUTO_INCREMENT,
  `input_directory` varchar(50) DEFAULT NULL,
  `output_directory` varchar(50) DEFAULT NULL,
  `render_xml_catalog` tinyint(4) DEFAULT '0' COMMENT 'Auto Create XML Catalog in Directory',
  `render_txt_catalog` tinyint(4) DEFAULT '0' COMMENT 'Auto Create TXT Catalog in Directory',
  `activate_fiscal` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_fiscal`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.sys_fiscal_customization: ~0 rows (approximately)
DELETE FROM `sys_fiscal_customization`;
/*!40000 ALTER TABLE `sys_fiscal_customization` DISABLE KEYS */;
INSERT INTO `sys_fiscal_customization` (`id_fiscal`, `input_directory`, `output_directory`, `render_xml_catalog`, `render_txt_catalog`, `activate_fiscal`) VALUES
	(1, 'C:\\Users\\Doni\\Documents\\', 'C:\\Users\\Doni\\Desktop\\', 0, 0, 1);
/*!40000 ALTER TABLE `sys_fiscal_customization` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.sys_points
CREATE TABLE IF NOT EXISTS `sys_points` (
  `id_points` int(11) NOT NULL AUTO_INCREMENT,
  `id_company` int(11) DEFAULT NULL,
  `amountToPoint` int(11) DEFAULT NULL COMMENT 'Amount to create a point',
  `active` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id_points`),
  UNIQUE KEY `id_company` (`id_company`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.sys_points: ~0 rows (approximately)
DELETE FROM `sys_points`;
/*!40000 ALTER TABLE `sys_points` DISABLE KEYS */;
INSERT INTO `sys_points` (`id_points`, `id_company`, `amountToPoint`, `active`) VALUES
	(1, 1, 200, 1);
/*!40000 ALTER TABLE `sys_points` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.sys_printer_devices
CREATE TABLE IF NOT EXISTS `sys_printer_devices` (
  `id_printer` int(11) NOT NULL AUTO_INCREMENT,
  `printer_name` varchar(50) NOT NULL,
  `paper_size` varchar(50) NOT NULL,
  `pos_printer` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_printer`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.sys_printer_devices: ~0 rows (approximately)
DELETE FROM `sys_printer_devices`;
/*!40000 ALTER TABLE `sys_printer_devices` DISABLE KEYS */;
INSERT INTO `sys_printer_devices` (`id_printer`, `printer_name`, `paper_size`, `pos_printer`) VALUES
	(1, 'Microsoft XPS Document Writer', 'A4', 1);
/*!40000 ALTER TABLE `sys_printer_devices` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.taxes
CREATE TABLE IF NOT EXISTS `taxes` (
  `id_tax` int(11) NOT NULL AUTO_INCREMENT,
  `vat_perc` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_tax`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.taxes: ~3 rows (approximately)
DELETE FROM `taxes`;
/*!40000 ALTER TABLE `taxes` DISABLE KEYS */;
INSERT INTO `taxes` (`id_tax`, `vat_perc`) VALUES
	(1, 0),
	(2, 10),
	(3, 20);
/*!40000 ALTER TABLE `taxes` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.type_documents
CREATE TABLE IF NOT EXISTS `type_documents` (
  `id_type_document` int(11) NOT NULL AUTO_INCREMENT,
  `type_document` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_type_document`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.type_documents: ~5 rows (approximately)
DELETE FROM `type_documents`;
/*!40000 ALTER TABLE `type_documents` DISABLE KEYS */;
INSERT INTO `type_documents` (`id_type_document`, `type_document`) VALUES
	(1, 'DOC'),
	(2, 'PDF'),
	(3, 'XLS'),
	(4, 'JPEG'),
	(5, 'CSV');
/*!40000 ALTER TABLE `type_documents` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.type_payments
CREATE TABLE IF NOT EXISTS `type_payments` (
  `id_type_payment` int(11) NOT NULL AUTO_INCREMENT,
  `type_payment` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_type_payment`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.type_payments: ~4 rows (approximately)
DELETE FROM `type_payments`;
/*!40000 ALTER TABLE `type_payments` DISABLE KEYS */;
INSERT INTO `type_payments` (`id_type_payment`, `type_payment`) VALUES
	(1, 'KESH'),
	(2, 'CHEQUE'),
	(3, 'BORXH'),
	(4, 'PIKE');
/*!40000 ALTER TABLE `type_payments` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.type_products
CREATE TABLE IF NOT EXISTS `type_products` (
  `id_type` int(11) NOT NULL AUTO_INCREMENT,
  `type_product` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.type_products: ~3 rows (approximately)
DELETE FROM `type_products`;
/*!40000 ALTER TABLE `type_products` DISABLE KEYS */;
INSERT INTO `type_products` (`id_type`, `type_product`) VALUES
	(1, 'Cop'),
	(2, 'Paket'),
	(3, 'Kg');
/*!40000 ALTER TABLE `type_products` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.users
CREATE TABLE IF NOT EXISTS `users` (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) DEFAULT NULL,
  `user_type` tinyint(4) NOT NULL,
  `fullname` varchar(50) DEFAULT NULL,
  `phone` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(20) DEFAULT NULL,
  `adress` varchar(50) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL,
  `p_code` varchar(50) NOT NULL,
  `country` varchar(50) DEFAULT NULL,
  `date_registration` date NOT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.users: ~2 rows (approximately)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id_user`, `username`, `user_type`, `fullname`, `phone`, `email`, `password`, `adress`, `city`, `p_code`, `country`, `date_registration`) VALUES
	(1, 'doni', 1, 'Liridon Agushi', '0638002549', 'agushi.liirodn', 'doni', 'Shoshaj', 'Preshev', '17523', 'Serbia', '0000-00-00'),
	(2, 'adile', 2, 'Adile Agushi', 'Phone', 'adile', 'adile', 'Adresa', 'City', 'Postal Cod', 'Country', '0000-00-00');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Dumping structure for table dmobiledb.user_types
CREATE TABLE IF NOT EXISTS `user_types` (
  `id_type` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table dmobiledb.user_types: ~3 rows (approximately)
DELETE FROM `user_types`;
/*!40000 ALTER TABLE `user_types` DISABLE KEYS */;
INSERT INTO `user_types` (`id_type`, `type`) VALUES
	(1, 'Admin'),
	(2, 'Stocks Import'),
	(3, 'Cashier');
/*!40000 ALTER TABLE `user_types` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
