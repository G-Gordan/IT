-- phpMyAdmin SQL Dump
-- version 4.8.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 14, 2019 at 06:51 PM
-- Server version: 10.1.33-MariaDB
-- PHP Version: 7.2.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cas10oop`
--

-- --------------------------------------------------------

--
-- Table structure for table `kategorije`
--

CREATE TABLE `kategorije` (
  `kategorija` varchar(255) NOT NULL,
  `opis` text NOT NULL,
  `trajanje` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kategorije`
--

INSERT INTO `kategorije` (`kategorija`, `opis`, `trajanje`) VALUES
('A', 'Motocikl', 5),
('B', 'Auto', 10),
('C', 'Kamion', 5),
('D', 'Autobus', 7);

-- --------------------------------------------------------

--
-- Table structure for table `proizvodjaci`
--

CREATE TABLE `proizvodjaci` (
  `imeproizvodjaca` varchar(255) NOT NULL,
  `zemljaporekla` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proizvodjaci`
--

INSERT INTO `proizvodjaci` (`imeproizvodjaca`, `zemljaporekla`) VALUES
('Audi', 'Nemacka'),
('Fiat', 'Italija'),
('Honda', 'Japan'),
('Kia', 'Korea'),
('Mercedes', 'Nemacka'),
('Mini', 'Engleska'),
('Nisan', 'Japan'),
('Peugeot', 'Francuska'),
('Seat', 'Spanija'),
('Volvo', 'Svedska');

-- --------------------------------------------------------

--
-- Table structure for table `vozaci`
--

CREATE TABLE `vozaci` (
  `idvozaca` int(11) NOT NULL,
  `ime` varchar(255) NOT NULL,
  `prezime` varchar(255) NOT NULL,
  `godiste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vozaci`
--

INSERT INTO `vozaci` (`idvozaca`, `ime`, `prezime`, `godiste`) VALUES
(1, 'Petar', 'Petrovic', 1991),
(2, 'Filip ', 'Filipovic', 1981),
(3, 'Jovan', 'Jovanovic', 1989),
(4, 'Vlada', 'Vlastic', 1995),
(5, 'Nemanja', 'Nemanjic', 1988),
(9, 'Laza', 'Lazarevic', 1978);

-- --------------------------------------------------------

--
-- Table structure for table `vozila`
--

CREATE TABLE `vozila` (
  `idvozila` int(11) NOT NULL,
  `imeproizvodjaca` varchar(255) NOT NULL,
  `model` varchar(255) NOT NULL,
  `kategorija` varchar(10) NOT NULL,
  `godiste` int(11) NOT NULL,
  `cena` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vozila`
--

INSERT INTO `vozila` (`idvozila`, `imeproizvodjaca`, `model`, `kategorija`, `godiste`, `cena`) VALUES
(1, 'Volvo', 'FH', 'C', 2012, 30),
(2, 'Peugeot', 'speed', 'A', 2003, 1300),
(3, 'Fiat', 'punto', 'B', 2005, 15000),
(4, 'Nisan', 'micra', 'B', 2008, 25000),
(5, 'Mercedes', 'ikarbus', 'D', 2014, 23000),
(6, 'Mini', 'Moris', 'B', 2000, 2000),
(7, 'Seat', 'ibica', 'B', 2007, 35000),
(8, 'Volvo', 'Fap', 'D', 2012, 50000),
(9, 'Audi', '22', 'A', 1977, 4444),
(10, 'Audi', 'a3', 'B', 1977, 50000);

-- --------------------------------------------------------

--
-- Table structure for table `vozilavozaci`
--

CREATE TABLE `vozilavozaci` (
  `idvozila` int(11) NOT NULL,
  `idvozaca` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vozilavozaci`
--

INSERT INTO `vozilavozaci` (`idvozila`, `idvozaca`) VALUES
(2, 2),
(6, 2),
(1, 3),
(3, 3),
(7, 5),
(7, 4),
(8, 1),
(6, 1),
(8, 4),
(2, 4),
(5, 3),
(1, 1),
(1, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kategorije`
--
ALTER TABLE `kategorije`
  ADD PRIMARY KEY (`kategorija`);

--
-- Indexes for table `proizvodjaci`
--
ALTER TABLE `proizvodjaci`
  ADD PRIMARY KEY (`imeproizvodjaca`);

--
-- Indexes for table `vozaci`
--
ALTER TABLE `vozaci`
  ADD PRIMARY KEY (`idvozaca`);

--
-- Indexes for table `vozila`
--
ALTER TABLE `vozila`
  ADD PRIMARY KEY (`idvozila`),
  ADD KEY `imeproizvodjaca` (`imeproizvodjaca`),
  ADD KEY `kategorija` (`kategorija`);

--
-- Indexes for table `vozilavozaci`
--
ALTER TABLE `vozilavozaci`
  ADD KEY `idvozila` (`idvozila`),
  ADD KEY `idvozaca` (`idvozaca`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `vozaci`
--
ALTER TABLE `vozaci`
  MODIFY `idvozaca` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `vozila`
--
ALTER TABLE `vozila`
  MODIFY `idvozila` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `vozila`
--
ALTER TABLE `vozila`
  ADD CONSTRAINT `vozila_ibfk_1` FOREIGN KEY (`imeproizvodjaca`) REFERENCES `proizvodjaci` (`imeproizvodjaca`),
  ADD CONSTRAINT `vozila_ibfk_2` FOREIGN KEY (`kategorija`) REFERENCES `kategorije` (`kategorija`);

--
-- Constraints for table `vozilavozaci`
--
ALTER TABLE `vozilavozaci`
  ADD CONSTRAINT `vozilavozaci_ibfk_1` FOREIGN KEY (`idvozila`) REFERENCES `vozila` (`idvozila`),
  ADD CONSTRAINT `vozilavozaci_ibfk_2` FOREIGN KEY (`idvozaca`) REFERENCES `vozaci` (`idvozaca`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
