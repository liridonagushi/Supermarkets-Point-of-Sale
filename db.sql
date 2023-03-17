-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.16-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for amiri_market
CREATE DATABASE IF NOT EXISTS `amiri_market` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `amiri_market`;

-- Dumping structure for table amiri_market.attachments
CREATE TABLE IF NOT EXISTS `attachments` (
  `id_attachment` int(11) NOT NULL AUTO_INCREMENT,
  `name_doc` varchar(50) DEFAULT NULL,
  `description` varchar(200) NOT NULL DEFAULT '0',
  `name_file` varchar(20) DEFAULT NULL,
  `date_insert` date DEFAULT NULL,
  PRIMARY KEY (`id_attachment`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.attachments: ~47 rows (approximately)
DELETE FROM `attachments`;
/*!40000 ALTER TABLE `attachments` DISABLE KEYS */;
INSERT INTO `attachments` (`id_attachment`, `name_doc`, `description`, `name_file`, `date_insert`) VALUES
	(1, 'Doc 1', 'bvnnbnbv', '101150.pdf', '2016-12-21'),
	(2, 'Doc 2', '23213321', '103020.pdf', '2016-11-21'),
	(3, 'Doc 3', '0', NULL, '2016-12-21'),
	(4, 'Doc 1', '432', NULL, '2016-12-21'),
	(5, '123213321321', '3132321', '', '2016-12-21'),
	(6, '21321312', '123213321321', NULL, '2016-12-21'),
	(7, '12332321321', '23213321', '', '2018-06-22'),
	(8, 'Contrat', 'Company Contrat with client ...', '113924.pdf', '2017-02-06'),
	(9, 'bvcnbv', '32532112321', '101515.pdf', '2016-12-21'),
	(10, '324432432', '21332213', '102152.pdf', '2016-12-21'),
	(11, '132321', '43243432', '', '2016-12-21'),
	(12, '213213', '213321321', NULL, '2016-12-21'),
	(13, 'Doc 2', '213321321', NULL, '2016-12-21'),
	(14, '324432432', '21332213', '', '2016-12-21'),
	(15, '213321321321', '324432432', NULL, '2016-12-21'),
	(16, '123324432432432', '213213321213213', '063359.pdf', '2018-06-22'),
	(17, '324432432', '43243432', '', '2016-12-21'),
	(18, '213213', '213213321', '115838.pdf', '2016-12-21'),
	(19, '123', '123', '063249.pdf', '2018-06-22'),
	(20, '123213', '123', '', '2016-12-21'),
	(21, '213', '213', NULL, '2016-12-21'),
	(22, '1231', '123', '', '2018-06-22'),
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
	(35, '13232132', '13213212', '', '2016-12-21'),
	(37, '132321213321', '32132132', NULL, '2016-12-21'),
	(38, '213321321213', '21332321', '', '2016-12-21'),
	(39, '213321321213231', '213321321', NULL, '2016-12-21'),
	(40, '32443432', '54343', '', '2016-12-21'),
	(42, '213321321212', '321321321', NULL, '2016-12-21'),
	(43, '123321321', '321321321213', '062705.pdf', '2018-06-22'),
	(44, '21321', '32132132132121', '', '2017-01-31'),
	(45, 'kontrata e lokalit', 'nmcvxbnvnvx', '', '2017-03-04'),
	(46, 'kontrata me firmen b', 'j]jdcjsbbncs  csnscncbsmmn', '', '2017-04-11'),
	(47, '42234234', '243423423', '', '2017-04-14'),
	(48, '1232', '1231', '', '2018-06-22'),
	(49, '12343554354354', '123', NULL, '2018-06-22'),
	(50, '21321332', '132321', '', '2018-06-22'),
	(51, '543543543', '54543543543', '', '2018-06-22');
/*!40000 ALTER TABLE `attachments` ENABLE KEYS */;

-- Dumping structure for table amiri_market.backuplinks
CREATE TABLE IF NOT EXISTS `backuplinks` (
  `id_link` int(11) NOT NULL AUTO_INCREMENT,
  `type_backup` varchar(50) NOT NULL,
  `backupfolder` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`id_link`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.backuplinks: ~2 rows (approximately)
DELETE FROM `backuplinks`;
/*!40000 ALTER TABLE `backuplinks` DISABLE KEYS */;
INSERT INTO `backuplinks` (`id_link`, `type_backup`, `backupfolder`) VALUES
	(1, 'local', 'D:\\backup\\'),
	(2, 'server', 'C:\\Users\\Public\\Documents\\testbackup\\');
/*!40000 ALTER TABLE `backuplinks` ENABLE KEYS */;

-- Dumping structure for table amiri_market.backup_db
CREATE TABLE IF NOT EXISTS `backup_db` (
  `id_backup` int(11) NOT NULL AUTO_INCREMENT,
  `name_backup` varchar(20) DEFAULT NULL,
  `date_backup` date DEFAULT NULL,
  PRIMARY KEY (`id_backup`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.backup_db: ~3 rows (approximately)
DELETE FROM `backup_db`;
/*!40000 ALTER TABLE `backup_db` DISABLE KEYS */;
INSERT INTO `backup_db` (`id_backup`, `name_backup`, `date_backup`) VALUES
	(1, '1', '2016-12-16'),
	(2, '10', '2017-03-10'),
	(3, '20', '2018-06-20');
/*!40000 ALTER TABLE `backup_db` ENABLE KEYS */;

-- Dumping structure for table amiri_market.bought_ocassion
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.bought_ocassion: ~0 rows (approximately)
DELETE FROM `bought_ocassion`;
/*!40000 ALTER TABLE `bought_ocassion` DISABLE KEYS */;
/*!40000 ALTER TABLE `bought_ocassion` ENABLE KEYS */;

-- Dumping structure for table amiri_market.clients
CREATE TABLE IF NOT EXISTS `clients` (
  `id_client` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(50) DEFAULT NULL,
  `other_details` mediumtext,
  `total_points` decimal(10,2) NOT NULL DEFAULT '0.00',
  `date_registration` date DEFAULT NULL,
  `active` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`id_client`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.clients: ~14 rows (approximately)
DELETE FROM `clients`;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` (`id_client`, `fullname`, `other_details`, `total_points`, `date_registration`, `active`) VALUES
	(1, 'Liridon Agushi', 'Dot Rond nbnvnnbv', 331.43, '2016-11-28', 1),
	(2, 'Agushi1', 'Agushi', 31.70, '2016-11-28', 1),
	(3, 'adile', 'company1', 44.00, '2016-11-30', 1),
	(4, '123', '213', 3.80, '2017-03-17', 1),
	(5, 'liridon', 'dsakjhdsaj', 0.00, '2017-03-17', 1),
	(6, 'gazmend doda', 'Preshev perball marketit MEN, 0625468, doda@doda.com', 0.00, '2017-03-04', 1),
	(7, 'liridon', 'bvvcmbvc,nbvcm', 2.60, '2017-03-11', 1),
	(8, 'valoni geraj', '06225334534 i magacinit', 0.00, '2017-04-11', 1),
	(9, 'nmjvjvdnc', 'vdjdjfjdfjhdgghj 06324356', 0.00, '2017-04-14', 1),
	(10, '123213321', '123132123', 0.00, '2017-04-27', 1),
	(11, 'test register', 'rewfdggfdgfgfd', 0.00, '2017-04-27', 1),
	(12, '21321', '321321321', 0.00, '2017-06-04', 1),
	(13, 'EMRI MBIEMRI', 'NMVXCNMVXCXCNVCX', 0.00, '2017-08-15', 1),
	(14, 'samia mjeshtri', 'mmncbnnmnmnm', 426.42, '2017-09-24', 1),
	(15, 'doni', 'doni', 0.00, '2018-06-15', 1);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;

-- Dumping structure for table amiri_market.client_debts
CREATE TABLE IF NOT EXISTS `client_debts` (
  `id_debt` int(11) NOT NULL AUTO_INCREMENT,
  `StaffID` int(11) DEFAULT NULL,
  `id_client` int(11) DEFAULT NULL,
  `InvoiceNo` varchar(20) DEFAULT '0',
  `debtValue` decimal(10,2) DEFAULT '0.00',
  `debtDate` date DEFAULT NULL,
  `type_payment` int(11) DEFAULT '1',
  PRIMARY KEY (`id_debt`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.client_debts: ~0 rows (approximately)
DELETE FROM `client_debts`;
/*!40000 ALTER TABLE `client_debts` DISABLE KEYS */;
INSERT INTO `client_debts` (`id_debt`, `StaffID`, `id_client`, `InvoiceNo`, `debtValue`, `debtDate`, `type_payment`) VALUES
	(1, 1, 1, '2', 100.00, '2017-08-15', 3);
/*!40000 ALTER TABLE `client_debts` ENABLE KEYS */;

-- Dumping structure for table amiri_market.company
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

-- Dumping data for table amiri_market.company: ~0 rows (approximately)
DELETE FROM `company`;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` (`id_company`, `id_currency`, `companyName`, `manager`, `contactNumber`, `CompanySN`, `BANK_Number`, `adress`, `city`, `country`, `base_currency`) VALUES
	(1, 4, 'DotRond', 'Liridon', '0638002549', '123456789', '01010101', 'Shoshaj', 'Preshev', 'Serbia', 4);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;

-- Dumping structure for table amiri_market.distributors
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

-- Dumping data for table amiri_market.distributors: ~3 rows (approximately)
DELETE FROM `distributors`;
/*!40000 ALTER TABLE `distributors` DISABLE KEYS */;
INSERT INTO `distributors` (`id_distributor`, `fullname`, `company`, `BankAccountNumber`, `adress`, `city`, `p_code`, `country`, `phone`, `email`, `date_registration`, `active`) VALUES
	(1, 'John Doe', 'Microsoft', '213132', 'Chicago', 'Chicago', '123456PCOD', 'US', '123456789Phone', 'j.doe@email.com', '2016-12-02', 1),
	(2, 'Don Doe', 'Apple', '789123', 'Chicago', 'Chicago', '54564564', 'US', '2545646874', 'd.doe@email.com', '2016-12-02', 1),
	(3, '123123321', '32121321', NULL, '21321321', '213321', '21321', '321321321', '321321321', '321321321', NULL, 1);
/*!40000 ALTER TABLE `distributors` ENABLE KEYS */;

-- Dumping structure for table amiri_market.employee_stats
CREATE TABLE IF NOT EXISTS `employee_stats` (
  `id_stat` int(11) NOT NULL AUTO_INCREMENT,
  `id_employee` int(11) DEFAULT NULL,
  `time_start` datetime DEFAULT NULL,
  `time_end` datetime DEFAULT NULL,
  `hours_worked` decimal(10,2) DEFAULT '0.00',
  `NonVatAmount` decimal(10,2) DEFAULT '0.00',
  `VatAmount` decimal(10,3) DEFAULT '0.000',
  `TotalAmount` decimal(10,3) DEFAULT '0.000',
  `TotalDebtAmount` decimal(10,2) DEFAULT '0.00',
  `returned_debts` decimal(10,2) DEFAULT '0.00',
  `total_sum` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`id_stat`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.employee_stats: ~5 rows (approximately)
DELETE FROM `employee_stats`;
/*!40000 ALTER TABLE `employee_stats` DISABLE KEYS */;
INSERT INTO `employee_stats` (`id_stat`, `id_employee`, `time_start`, `time_end`, `hours_worked`, `NonVatAmount`, `VatAmount`, `TotalAmount`, `TotalDebtAmount`, `returned_debts`, `total_sum`) VALUES
	(5, 1, '2017-06-04 01:02:10', '2018-06-17 14:27:53', 13.25, 0.00, 10660.500, 63963.000, 21444.00, 21344.00, 63863.00),
	(6, 1, '2018-06-18 18:51:56', '2018-06-22 15:00:40', 20.80, 0.00, 2281.080, 25092.000, 0.00, 0.00, 0.00),
	(7, 1, '2018-06-22 15:00:49', '2018-06-22 15:09:50', 0.90, 105.00, 21.000, 126.000, 0.00, 0.00, 0.00),
	(8, 1, '2018-06-22 15:10:01', '2018-06-22 15:13:21', 0.30, 5.00, 1.000, 6.000, 0.00, 0.00, 6.00),
	(9, 1, '2018-06-22 15:14:19', NULL, 0.00, 0.00, 0.000, 0.000, 0.00, 0.00, 0.00);
/*!40000 ALTER TABLE `employee_stats` ENABLE KEYS */;

-- Dumping structure for table amiri_market.imp_invoices
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.imp_invoices: ~3 rows (approximately)
DELETE FROM `imp_invoices`;
/*!40000 ALTER TABLE `imp_invoices` DISABLE KEYS */;
INSERT INTO `imp_invoices` (`id_invoice`, `id_distributor`, `invoice_code`, `date_invoice`, `date_registration`, `date_payment`, `vatAmount`, `benefitAmount`, `importAmount`, `totalAmount`, `payment_status`, `id_type_payment`) VALUES
	(1, 3, '0233032123', '2017-09-24', '2017-09-24', '2017-10-04', 0.830, 75.000, 75.000, 150.000, 1, '1'),
	(2, 1, '123213213', '2018-06-20', '2018-06-20', '2018-06-30', 11.180, 260.000, 2200.000, 2460.000, 1, '1'),
	(3, 1, '123231213213', '2018-06-20', '2018-06-20', '2018-07-03', 15.550, -83620.000, 88600.000, 4980.000, 1, '2');
/*!40000 ALTER TABLE `imp_invoices` ENABLE KEYS */;

-- Dumping structure for table amiri_market.invoiceprocessing
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.invoiceprocessing: ~4 rows (approximately)
DELETE FROM `invoiceprocessing`;
/*!40000 ALTER TABLE `invoiceprocessing` DISABLE KEYS */;
INSERT INTO `invoiceprocessing` (`id_invoiceProcessing`, `id_order`, `invoice_code`, `id_distributor`, `id_product`, `vatPerc`, `maj_unit_price`, `unit_price`, `stockstotal`, `stocks_insert`, `freeQty`, `import_amount`, `vat_amount`, `sell_amount`) VALUES
	(1, 1, '0233032123', 3, 1, 20, 4.000, 5.000, -3.000, 30.000, 0, 75.000, 0.830, 150.000),
	(2, 1, '123213213', 1, 2, 10, 130.000, 123.000, -202.000, 20.000, 10, 2200.000, 11.180, 2460.000),
	(3, 1, '123231213213', 1, 2, 10, 150.000, 160.000, -182.000, 30.000, 0, 3600.000, 14.550, 4800.000),
	(4, 2, '123231213213', 1, 1, 20, 4.000, 6.000, 27.000, 30.000, 0, 85000.000, 1.000, 180.000);
/*!40000 ALTER TABLE `invoiceprocessing` ENABLE KEYS */;

-- Dumping structure for table amiri_market.messages
CREATE TABLE IF NOT EXISTS `messages` (
  `id_message` int(11) NOT NULL AUTO_INCREMENT,
  `id_sender` int(11) DEFAULT NULL,
  `id_receiver` int(11) DEFAULT NULL,
  `message` varchar(70) DEFAULT NULL,
  `date_msg` datetime DEFAULT CURRENT_TIMESTAMP,
  `seen` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_message`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.messages: ~0 rows (approximately)
DELETE FROM `messages`;
/*!40000 ALTER TABLE `messages` DISABLE KEYS */;
/*!40000 ALTER TABLE `messages` ENABLE KEYS */;

-- Dumping structure for table amiri_market.paiddebts
CREATE TABLE IF NOT EXISTS `paiddebts` (
  `id_paid_debt` int(11) NOT NULL AUTO_INCREMENT,
  `StaffID` int(11) NOT NULL DEFAULT '0',
  `CustomerNo` int(11) NOT NULL,
  `debtValue` decimal(10,2) NOT NULL,
  `paidDate` date NOT NULL,
  `type_payment` int(11) DEFAULT NULL,
  `end_session` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_paid_debt`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.paiddebts: ~3 rows (approximately)
DELETE FROM `paiddebts`;
/*!40000 ALTER TABLE `paiddebts` DISABLE KEYS */;
INSERT INTO `paiddebts` (`id_paid_debt`, `StaffID`, `CustomerNo`, `debtValue`, `paidDate`, `type_payment`, `end_session`) VALUES
	(1, 1, 1, 23.00, '2017-08-15', 1, 1),
	(2, 1, 14, 10000.00, '2017-09-24', 1, 1),
	(3, 1, 14, 11321.00, '2017-09-24', 1, 1);
/*!40000 ALTER TABLE `paiddebts` ENABLE KEYS */;

-- Dumping structure for table amiri_market.payment
CREATE TABLE IF NOT EXISTS `payment` (
  `PaymentNo` int(20) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(80) NOT NULL DEFAULT '0',
  `Cash` decimal(10,2) NOT NULL DEFAULT '0.00',
  `changeMoney` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`PaymentNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.payment: ~0 rows (approximately)
DELETE FROM `payment`;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;

-- Dumping structure for table amiri_market.pos
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

-- Dumping data for table amiri_market.pos: 12 rows
DELETE FROM `pos`;
/*!40000 ALTER TABLE `pos` DISABLE KEYS */;
INSERT INTO `pos` (`InvoiceNo`, `StaffID`, `id_client`, `type_payment`, `POSDate`, `NonVatAmount`, `VatAmount`, `TotalAmount`, `end_session`, `discount_amount`, `majority_bool`, `updatedPrice`) VALUES
	(1, 1, 1, 3, '2017-08-15 08:54:02', 102.50, 20.50, 123.00, 1, 0.00, 1, 0),
	(2, 1, 0, 1, '2017-08-15 09:06:46', 35535.00, 7107.00, 42642.00, 1, 0.00, 0, 0),
	(3, 1, 14, 1, '2017-09-24 10:44:30', 17767.50, 3553.50, 21321.00, 1, 0.00, 0, 0),
	(4, 1, 14, 3, '2017-09-24 10:45:53', 17767.50, 3553.50, 21321.00, 1, 0.00, 0, 0),
	(5, 1, 0, 1, '2018-06-19 15:57:00', 223.64, 22.36, 246.00, 1, 0.00, 0, 0),
	(6, 1, 0, 1, '2018-06-19 15:58:04', 22363.64, 2236.36, 24600.00, 1, 0.00, 0, 0),
	(7, 1, 1, 4, '2018-06-19 16:01:23', 50.00, 10.00, 60.00, 1, 0.00, 0, 0),
	(8, 1, 0, 1, '2018-06-20 08:59:13', 111.82, 11.18, 123.00, 1, 0.00, 0, 0),
	(9, 1, 0, 1, '2018-06-22 15:00:33', 111.82, 11.18, 123.00, 1, 0.00, 0, 0),
	(10, 1, 0, 1, '2018-06-22 15:01:24', 5.00, 1.00, 6.00, 1, 0.00, 0, 0),
	(11, 1, 0, 1, '2018-06-22 15:09:39', 105.00, 21.00, 126.00, 1, 0.00, 0, 0),
	(12, 1, 0, 1, '2018-06-22 15:13:15', 5.00, 1.00, 6.00, 1, 0.00, 0, 0);
/*!40000 ALTER TABLE `pos` ENABLE KEYS */;

-- Dumping structure for table amiri_market.posdetails
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
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- Dumping data for table amiri_market.posdetails: 12 rows
DELETE FROM `posdetails`;
/*!40000 ALTER TABLE `posdetails` DISABLE KEYS */;
INSERT INTO `posdetails` (`POSDetailNo`, `InvoiceNo`, `id_product`, `vatAmount`, `productPrice`, `Quantity`, `discount_percentage`, `discount_amount`, `total_amount`) VALUES
	(1, 1, 1, 20.50, 123.00, 1.00, 0.00, 0.00, 123.00),
	(2, 2, 1, 7107.00, 21321.00, 2.00, 0.00, 0.00, 42642.00),
	(3, 3, 1, 3553.50, 21321.00, 1.00, 0.00, 0.00, 21321.00),
	(4, 4, 1, 3553.50, 21321.00, 1.00, 0.00, 0.00, 21321.00),
	(5, 5, 2, 22.36, 123.00, 2.00, 0.00, 0.00, 246.00),
	(6, 6, 2, 2236.36, 123.00, 200.00, 0.00, 0.00, 24600.00),
	(7, 7, 1, 10.00, 6.00, 10.00, 0.00, 0.00, 60.00),
	(8, 8, 3, 11.18, 123.00, 1.00, 0.00, 0.00, 123.00),
	(9, 9, 3, 11.18, 123.00, 1.00, 0.00, 0.00, 123.00),
	(10, 10, 1, 1.00, 6.00, 1.00, 0.00, 0.00, 6.00),
	(11, 11, 1, 21.00, 6.00, 21.00, 0.00, 0.00, 126.00),
	(12, 12, 1, 1.00, 6.00, 1.00, 0.00, 0.00, 6.00);
/*!40000 ALTER TABLE `posdetails` ENABLE KEYS */;

-- Dumping structure for table amiri_market.price_hist
CREATE TABLE IF NOT EXISTS `price_hist` (
  `id_modification` int(11) NOT NULL AUTO_INCREMENT,
  `id_product` int(11) DEFAULT NULL,
  `old_price` decimal(10,2) DEFAULT NULL,
  `new_price` decimal(10,2) DEFAULT NULL,
  `date_mod` date DEFAULT NULL,
  PRIMARY KEY (`id_modification`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.price_hist: ~6 rows (approximately)
DELETE FROM `price_hist`;
/*!40000 ALTER TABLE `price_hist` DISABLE KEYS */;
INSERT INTO `price_hist` (`id_modification`, `id_product`, `old_price`, `new_price`, `date_mod`) VALUES
	(1, 1, 21321.00, 75.00, '2017-09-24'),
	(2, 1, 5.00, 6.00, '2018-06-17'),
	(3, 2, 123.00, 2200.00, '2018-06-20'),
	(4, 2, 123.00, 110.00, '2018-06-20'),
	(5, 2, 110.00, 3600.00, '2018-06-20'),
	(6, 1, 6.00, 85000.00, '2018-06-20');
/*!40000 ALTER TABLE `price_hist` ENABLE KEYS */;

-- Dumping structure for table amiri_market.products
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
  `margin_perc` decimal(10,2) DEFAULT '0.00',
  `sold_price` decimal(10,2) DEFAULT '0.00',
  `quantity` decimal(10,2) DEFAULT '0.00',
  `quantity_processing` decimal(10,2) DEFAULT '0.00',
  `free_offer` tinyint(4) DEFAULT '0',
  `imported_qty` decimal(10,2) DEFAULT '0.00',
  `total_import_amount` decimal(10,2) DEFAULT '0.00',
  `date_insert` date DEFAULT NULL,
  `active` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`id_product`),
  UNIQUE KEY `barcode` (`barcode`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.products: ~6 rows (approximately)
DELETE FROM `products`;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` (`id_product`, `barcode`, `description`, `id_type`, `id_category`, `import_price`, `id_tax`, `majority_price`, `tax_majority`, `tax_amount`, `margin_perc`, `sold_price`, `quantity`, `quantity_processing`, `free_offer`, `imported_qty`, `total_import_amount`, `date_insert`, `active`) VALUES
	(1, 'produkttest1', '123132321', 1, 2, 2833.33, 3, 4.00, 0.67, 1.00, 0.00, 6.00, 34.00, 0.00, 0, 30.00, 85000.00, '2017-06-04', NULL),
	(2, '123', '123', 2, 2, 120.00, 2, 150.00, 13.64, 14.55, 0.00, 160.00, -152.00, 0.00, 0, 30.00, 3600.00, '2018-06-18', 1),
	(3, '123123', '123', 1, 2, 0.00, 2, 123.00, 11.18, 11.18, 0.00, 123.00, -2.00, 0.00, 0, 0.00, 0.00, '2018-06-18', NULL),
	(4, '123213211', '32132323211', 1, 2, 0.00, 3, 0.00, 0.00, 20553.50, 0.00, 123321.00, 0.00, 0.00, 0, 0.00, 0.00, '2018-06-20', NULL),
	(5, ' produkt test', 'produkt per kas', 1, 4, 0.00, 3, 0.00, 0.00, 183.00, 0.00, 1098.00, 0.00, 0.00, 0, 0.00, 0.00, '2018-06-20', NULL),
	(6, 'nbvnbvnbv', '231321321321', 1, 4, 0.00, 3, 0.00, 0.00, 20.50, 0.00, 123.00, 20.00, 0.00, 0, 0.00, 0.00, '2018-06-22', 1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;

-- Dumping structure for table amiri_market.product_categories
CREATE TABLE IF NOT EXISTS `product_categories` (
  `id_category` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.product_categories: ~4 rows (approximately)
DELETE FROM `product_categories`;
/*!40000 ALTER TABLE `product_categories` DISABLE KEYS */;
INSERT INTO `product_categories` (`id_category`, `category_name`) VALUES
	(1, 'Cigare'),
	(2, 'Teknologji'),
	(3, 'Kredit'),
	(4, 'Tjera');
/*!40000 ALTER TABLE `product_categories` ENABLE KEYS */;

-- Dumping structure for table amiri_market.repairing_products_sold
CREATE TABLE IF NOT EXISTS `repairing_products_sold` (
  `id_repair` int(11) NOT NULL AUTO_INCREMENT,
  `id_service` int(11) DEFAULT NULL,
  `id_product` int(11) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_repair`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.repairing_products_sold: ~0 rows (approximately)
DELETE FROM `repairing_products_sold`;
/*!40000 ALTER TABLE `repairing_products_sold` DISABLE KEYS */;
/*!40000 ALTER TABLE `repairing_products_sold` ENABLE KEYS */;

-- Dumping structure for table amiri_market.repairing_services
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.repairing_services: ~0 rows (approximately)
DELETE FROM `repairing_services`;
/*!40000 ALTER TABLE `repairing_services` DISABLE KEYS */;
/*!40000 ALTER TABLE `repairing_services` ENABLE KEYS */;

-- Dumping structure for table amiri_market.saved_posdetails
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

-- Dumping data for table amiri_market.saved_posdetails: 0 rows
DELETE FROM `saved_posdetails`;
/*!40000 ALTER TABLE `saved_posdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `saved_posdetails` ENABLE KEYS */;

-- Dumping structure for table amiri_market.stocksin
CREATE TABLE IF NOT EXISTS `stocksin` (
  `StocksInNo` int(11) NOT NULL AUTO_INCREMENT,
  `ItemNo` int(11) DEFAULT '0',
  `ItemQuantity` decimal(10,2) DEFAULT '0.00',
  `SIDate` date DEFAULT NULL,
  `CurrentStocks` decimal(10,2) DEFAULT '0.00',
  `number_facture` varchar(50) DEFAULT '0',
  PRIMARY KEY (`StocksInNo`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

-- Dumping data for table amiri_market.stocksin: 4 rows
DELETE FROM `stocksin`;
/*!40000 ALTER TABLE `stocksin` DISABLE KEYS */;
INSERT INTO `stocksin` (`StocksInNo`, `ItemNo`, `ItemQuantity`, `SIDate`, `CurrentStocks`, `number_facture`) VALUES
	(19, 1, 30.00, '2017-09-24', -3.00, '0233032123'),
	(20, 2, 20.00, '2018-06-20', -202.00, '123213213'),
	(21, 2, 30.00, '2018-06-20', -182.00, '123231213213'),
	(22, 1, 30.00, '2018-06-20', 27.00, '123231213213');
/*!40000 ALTER TABLE `stocksin` ENABLE KEYS */;

-- Dumping structure for table amiri_market.suggested_products
CREATE TABLE IF NOT EXISTS `suggested_products` (
  `id_suggest` int(11) NOT NULL AUTO_INCREMENT,
  `keyword` varchar(50) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `id_user` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_suggest`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.suggested_products: ~0 rows (approximately)
DELETE FROM `suggested_products`;
/*!40000 ALTER TABLE `suggested_products` DISABLE KEYS */;
/*!40000 ALTER TABLE `suggested_products` ENABLE KEYS */;

-- Dumping structure for table amiri_market.sys_currency
CREATE TABLE IF NOT EXISTS `sys_currency` (
  `id_currency` int(11) NOT NULL AUTO_INCREMENT,
  `name_currency` varchar(20) DEFAULT NULL,
  `currency` varchar(10) DEFAULT NULL,
  `amount` decimal(10,1) DEFAULT '0.0',
  PRIMARY KEY (`id_currency`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.sys_currency: ~5 rows (approximately)
DELETE FROM `sys_currency`;
/*!40000 ALTER TABLE `sys_currency` DISABLE KEYS */;
INSERT INTO `sys_currency` (`id_currency`, `name_currency`, `currency`, `amount`) VALUES
	(1, 'Dollar', '$', 0.0),
	(2, 'Euro', 'Euro', 0.0),
	(3, 'Frank', 'CHF', 0.0),
	(4, 'Dinar', 'Din', 122.0),
	(5, 'Lek', 'Lek', 0.0);
/*!40000 ALTER TABLE `sys_currency` ENABLE KEYS */;

-- Dumping structure for table amiri_market.sys_fiscal_customization
CREATE TABLE IF NOT EXISTS `sys_fiscal_customization` (
  `id_fiscal` int(11) NOT NULL AUTO_INCREMENT,
  `input_directory` varchar(50) DEFAULT NULL,
  `output_directory` varchar(50) DEFAULT NULL,
  `render_xml_catalog` tinyint(4) DEFAULT '0' COMMENT 'Auto Create XML Catalog in Directory',
  `render_txt_catalog` tinyint(4) DEFAULT '0' COMMENT 'Auto Create TXT Catalog in Directory',
  `activate_fiscal` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_fiscal`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.sys_fiscal_customization: ~0 rows (approximately)
DELETE FROM `sys_fiscal_customization`;
/*!40000 ALTER TABLE `sys_fiscal_customization` DISABLE KEYS */;
INSERT INTO `sys_fiscal_customization` (`id_fiscal`, `input_directory`, `output_directory`, `render_xml_catalog`, `render_txt_catalog`, `activate_fiscal`) VALUES
	(1, 'C:\\Users\\Doni\\Documents\\', 'C:\\Users\\Doni\\Desktop\\', 0, 0, 1);
/*!40000 ALTER TABLE `sys_fiscal_customization` ENABLE KEYS */;

-- Dumping structure for table amiri_market.sys_points
CREATE TABLE IF NOT EXISTS `sys_points` (
  `id_points` int(11) NOT NULL AUTO_INCREMENT,
  `id_company` int(11) DEFAULT NULL,
  `amountToPoint` int(11) DEFAULT NULL COMMENT 'Amount to create a point',
  `active` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id_points`),
  UNIQUE KEY `id_company` (`id_company`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.sys_points: ~0 rows (approximately)
DELETE FROM `sys_points`;
/*!40000 ALTER TABLE `sys_points` DISABLE KEYS */;
INSERT INTO `sys_points` (`id_points`, `id_company`, `amountToPoint`, `active`) VALUES
	(1, 1, 200, 1);
/*!40000 ALTER TABLE `sys_points` ENABLE KEYS */;

-- Dumping structure for table amiri_market.sys_printer_devices
CREATE TABLE IF NOT EXISTS `sys_printer_devices` (
  `id_printer` int(11) NOT NULL AUTO_INCREMENT,
  `printer_name` varchar(50) NOT NULL,
  `paper_size` varchar(50) NOT NULL,
  `pos_printer` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id_printer`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.sys_printer_devices: ~0 rows (approximately)
DELETE FROM `sys_printer_devices`;
/*!40000 ALTER TABLE `sys_printer_devices` DISABLE KEYS */;
INSERT INTO `sys_printer_devices` (`id_printer`, `printer_name`, `paper_size`, `pos_printer`) VALUES
	(1, 'Microsoft XPS Document Writer', 'A4', 1);
/*!40000 ALTER TABLE `sys_printer_devices` ENABLE KEYS */;

-- Dumping structure for table amiri_market.taxes
CREATE TABLE IF NOT EXISTS `taxes` (
  `id_tax` int(11) NOT NULL AUTO_INCREMENT,
  `vat_perc` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_tax`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.taxes: ~3 rows (approximately)
DELETE FROM `taxes`;
/*!40000 ALTER TABLE `taxes` DISABLE KEYS */;
INSERT INTO `taxes` (`id_tax`, `vat_perc`) VALUES
	(1, 0),
	(2, 10),
	(3, 20);
/*!40000 ALTER TABLE `taxes` ENABLE KEYS */;

-- Dumping structure for table amiri_market.type_documents
CREATE TABLE IF NOT EXISTS `type_documents` (
  `id_type_document` int(11) NOT NULL AUTO_INCREMENT,
  `type_document` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_type_document`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.type_documents: ~5 rows (approximately)
DELETE FROM `type_documents`;
/*!40000 ALTER TABLE `type_documents` DISABLE KEYS */;
INSERT INTO `type_documents` (`id_type_document`, `type_document`) VALUES
	(1, 'DOC'),
	(2, 'PDF'),
	(3, 'XLS'),
	(4, 'JPEG'),
	(5, 'CSV');
/*!40000 ALTER TABLE `type_documents` ENABLE KEYS */;

-- Dumping structure for table amiri_market.type_payments
CREATE TABLE IF NOT EXISTS `type_payments` (
  `id_type_payment` int(11) NOT NULL AUTO_INCREMENT,
  `type_payment` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_type_payment`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.type_payments: ~4 rows (approximately)
DELETE FROM `type_payments`;
/*!40000 ALTER TABLE `type_payments` DISABLE KEYS */;
INSERT INTO `type_payments` (`id_type_payment`, `type_payment`) VALUES
	(1, 'KESH'),
	(2, 'CHEQUE'),
	(3, 'BORXH'),
	(4, 'PIKE');
/*!40000 ALTER TABLE `type_payments` ENABLE KEYS */;

-- Dumping structure for table amiri_market.type_products
CREATE TABLE IF NOT EXISTS `type_products` (
  `id_type` int(11) NOT NULL AUTO_INCREMENT,
  `type_product` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.type_products: ~3 rows (approximately)
DELETE FROM `type_products`;
/*!40000 ALTER TABLE `type_products` DISABLE KEYS */;
INSERT INTO `type_products` (`id_type`, `type_product`) VALUES
	(1, 'Copë'),
	(2, 'Paket'),
	(3, 'Kg');
/*!40000 ALTER TABLE `type_products` ENABLE KEYS */;

-- Dumping structure for table amiri_market.users
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.users: ~0 rows (approximately)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id_user`, `username`, `user_type`, `fullname`, `phone`, `email`, `password`, `adress`, `city`, `p_code`, `country`, `date_registration`) VALUES
	(1, 'doni', 1, 'doni', '123', '123', 'doni', NULL, NULL, '123', NULL, '2018-06-15');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Dumping structure for table amiri_market.user_types
CREATE TABLE IF NOT EXISTS `user_types` (
  `id_type` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table amiri_market.user_types: ~3 rows (approximately)
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
