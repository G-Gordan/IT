-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 28, 2016 at 08:52 PM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 7.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `autoplac`
--

-- --------------------------------------------------------

--
-- Table structure for table `model`
--

CREATE TABLE `model` (
  `id` int(11) NOT NULL,
  `marka` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `model` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `model`
--

INSERT INTO `model` (`id`, `marka`, `model`) VALUES
(1, 'Opel', 'Corsa'),
(2, 'Opel', 'Astra'),
(3, 'Ford', 'Fiesta'),
(4, 'Ford', 'Focus'),
(5, 'Peugeot', '206'),
(6, 'Peugeot', '207'),
(7, 'Peugeot', '106'),
(8, 'Peugeot', '307'),
(9, 'Peugeot', '407'),
(10, 'Peugeot', '3008'),
(11, 'Peugeot', '208'),
(12, 'Citroen', 'C1'),
(13, 'Citroen', 'C2'),
(14, 'Citroen', 'C3'),
(15, 'Citroen', 'C4'),
(16, 'Citroen', 'C5'),
(17, 'Citroen', 'C6'),
(19, 'Renault', 'Megan'),
(20, 'Renault', 'Laguna'),
(21, 'Renault', 'Clio'),
(22, 'Renault', 'Scenic'),
(23, 'Mercedes', 'A170'),
(24, 'Mercedes', 'A180'),
(25, 'Mercedes', 'B180'),
(27, 'Ford', 'Mondeo');

-- --------------------------------------------------------

--
-- Table structure for table `vozilo`
--

CREATE TABLE `vozilo` (
  `id` int(11) NOT NULL,
  `model_id` int(11) NOT NULL,
  `opis` varchar(400) COLLATE utf8mb4_unicode_ci NOT NULL,
  `slika` varchar(400) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kilometraza` int(11) NOT NULL,
  `godiste` year(4) NOT NULL,
  `snaga` int(11) NOT NULL,
  `tip_goriva` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `cena` int(11) NOT NULL,
  `specijalna_ponuda` tinyint(1) NOT NULL,
  `datum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `vozilo`
--

INSERT INTO `vozilo` (`id`, `model_id`, `opis`, `slika`, `kilometraza`, `godiste`, `snaga`, `tip_goriva`, `cena`, `specijalna_ponuda`, `datum`) VALUES
(1, 1, 'Malo presla, puno vredi', 'slike/corsa2015.jpg', 29995, 2015, 85, 'Benzin', 11590, 0, '2016-09-28'),
(2, 3, 'Zena vozila. Treba limarija da se radi', 'slike/fiesta2006.jpg', 66666, 2006, 69, 'Benzin', 2850, 0, '2016-09-30'),
(3, 4, 'Sedi i odvezi', 'slike/focus1994.jpg', 220555, 1994, 110, 'Dizel', 1400, 0, '2016-09-01'),
(4, 10, 'Nov, malo vozen. Prvi i jedini vlasnik.', 'slike/pezo3008.jpg', 36000, 2013, 105, 'Dizel', 9999, 1, '2016-09-28'),
(5, 15, 'Na ime kupca. Uvezen iz Nemacke', 'slike/citroenc4.jpg', 140000, 2008, 85, 'Benzin', 5000, 1, '2016-09-27'),
(6, 1, 'Crvene boje, savrsen auto za gradsku voznju', 'slike/corsa2004.jpg', 149550, 2004, 75, 'Gas', 2650, 1, '2016-09-13'),
(7, 2, 'Metalik boje, dobar porodican auto. Uradjen veliki servis.', 'slike/astra2006.jpg', 110000, 2006, 95, 'Metan', 3800, 0, '2016-09-01');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `model`
--
ALTER TABLE `model`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vozilo`
--
ALTER TABLE `vozilo`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `model`
--
ALTER TABLE `model`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;
--
-- AUTO_INCREMENT for table `vozilo`
--
ALTER TABLE `vozilo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
