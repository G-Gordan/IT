-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 02, 2016 at 08:48 PM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 7.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sajt2`
--

-- --------------------------------------------------------

--
-- Table structure for table `kategorija`
--

CREATE TABLE `kategorija` (
  `id` int(11) NOT NULL,
  `naziv` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `opis` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `kategorija`
--

INSERT INTO `kategorija` (`id`, `naziv`, `opis`) VALUES
(1, 'Web', 'Web opis'),
(2, 'Office', 'Office opis...');

-- --------------------------------------------------------

--
-- Table structure for table `komentar`
--

CREATE TABLE `komentar` (
  `id` int(11) NOT NULL,
  `datum` datetime NOT NULL,
  `autor` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `sadrzaj` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL,
  `vest_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `komentar`
--

INSERT INTO `komentar` (`id`, `datum`, `autor`, `sadrzaj`, `vest_id`) VALUES
(1, '2016-10-24 00:00:00', 'Pera', 'Da li ce na sajmu biti velikih popusta?', 1),
(2, '2016-10-14 00:00:00', 'Mika', 'Komentar sajam Mika...', 1);

-- --------------------------------------------------------

--
-- Table structure for table `prijava_za_posao`
--

CREATE TABLE `prijava_za_posao` (
  `id` int(11) NOT NULL,
  `ime_i_prezime` varchar(48) COLLATE utf8mb4_unicode_ci NOT NULL,
  `telefon` varchar(24) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `cv` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `prijava_za_posao`
--

INSERT INTO `prijava_za_posao` (`id`, `ime_i_prezime`, `telefon`, `email`, `cv`) VALUES
(0, '', '00000', 'pera@pera.net', 'cv/opis vezbe.html'),
(0, '', '00000', 'pera@pera.net', 'cv/opis vezbe.html'),
(0, 'asdf', 'asdf', 'asdfasdf@petar.net', 'cv/forma-validacija-vezba.png'),
(0, 'test', 'test', 'test', 'cv/opis vezbe.html'),
(0, '', '', '', 'cv/1478116062243');

-- --------------------------------------------------------

--
-- Table structure for table `proizvod`
--

CREATE TABLE `proizvod` (
  `id` int(11) NOT NULL,
  `naziv` varchar(150) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kraci_opis` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pun_opis` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `slika` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `cena` int(11) NOT NULL,
  `trajanje_dana` tinyint(4) NOT NULL,
  `trajanje_casova` tinyint(4) NOT NULL,
  `pocinje` date NOT NULL,
  `vreme` time NOT NULL,
  `specijalna_ponuda` tinyint(1) NOT NULL,
  `kat_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `proizvod`
--

INSERT INTO `proizvod` (`id`, `naziv`, `kraci_opis`, `pun_opis`, `slika`, `cena`, `trajanje_dana`, `trajanje_casova`, `pocinje`, `vreme`, `specijalna_ponuda`, `kat_id`) VALUES
(1, 'HTML & CSS', 'HTML i CSS su osnovni gradivni elementi Interneta, jezici koji pokreću web. U ovom kursu videćete kako HTML čini osnovu weba i na koji način se CSS ugrađuje i proširuje mogućnosti HTML-a.', '<p>Upoznaćete se sa mogućnostima oba jezika, njihovom sintaksom, primenom i često kori&scaron;ćenim tehnikama. Razumećete osnove Bootstrap biblioteke i izgradnje responsive stranica. Naučićete kako da napravite web sajt od početka, pripremite sadržaj i grafiku i prilagodite web sajt mobilnim uređajima. Nakon kursa moći ćete da samostalno kreirate portfolio web sajt, blog, web sajt preduzeća, katalog proizvoda. Moći ćete i da prilagodite postojeće web sajtove potrebama svojih klijenata.</p>', '', 80, 5, 20, '2016-10-31', '17:30:00', 1, 1),
(3, 'PHP', 'kratak opis php-a', '<p>pun opis php-a</p>', 'img/kursevi/php.jpg', 200, 10, 40, '2016-10-29', '11:26:00', 0, 2),
(4, 'Web developer', 'kratak opis php-a', 'pun opis php-a', 'img/kursevi/php.jpg', 200, 10, 40, '2016-10-29', '11:26:00', 0, 2);

-- --------------------------------------------------------

--
-- Table structure for table `vest`
--

CREATE TABLE `vest` (
  `id` int(11) NOT NULL,
  `naslov` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kraci_opis` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pun_opis` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `datum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `vest`
--

INSERT INTO `vest` (`id`, `naslov`, `kraci_opis`, `pun_opis`, `datum`) VALUES
(1, 'CET na Sajmu knjiga 2017', 'Na Sajmu knjiga u Beogradu (od 25.oktobra – 1.novembra 2017.) CET je predstavio nove naslove: Autodesk Revit, Naučite programiranje, Uvod u Pyton, Web programiranje, IOS 8. ', '<p style="text-align: right;">Na Sajmu knjiga u Beogradu<strong> (od 25.oktobra</strong> &ndash; 1.novembra 2015.) CET je predstavio nove naslove: Autodesk Revit, Naučite programiranje, Uvod u Pyton, Web programiranje, IOS 8. Nton, Web programiranje, IOS 8.</p>', '2016-10-28'),
(2, 'U prodaji Office 2016', 'Odeljenje CET softvera započelo je prodaju najnovijeg Office 2016, koji je dodatak Office 365 Microsoft pretplatničkom servisu baziranom na cloud-u.', 'Odeljenje CET softvera započelo je prodaju najnovijeg Office 2016, koji je dodatak Office 365 Microsoft pretplatničkom servisu baziranom na cloud-u. \r\nOffice 2016 aplikacije prvenstveno pomažu timskom radu. Odeljenje CET softvera započelo je prodaju najnovijeg Office 2016, koji je dodatak Office 365 Microsoft pretplatničkom servisu baziranom na cloud-u. \r\nOffice 2016 aplikacije prvenstveno pomažu timskom radu. Odeljenje CET softvera započelo je prodaju najnovijeg Office 2016, koji je dodatak Office 365 Microsoft pretplatničkom servisu baziranom na cloud-u. \r\nOffice 2016 aplikacije prvenstveno pomažu timskom radu. ', '2016-10-02'),
(5, 'asdfasdf', 'asdfasdf', '<p>asfasdfasdfasdf</p>', '2016-10-20'),
(6, 'asdfasdf', 'asdfasd', '<p>asdfasfsdf</p>', '2016-10-28');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kategorija`
--
ALTER TABLE `kategorija`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `komentar`
--
ALTER TABLE `komentar`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `proizvod`
--
ALTER TABLE `proizvod`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vest`
--
ALTER TABLE `vest`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `kategorija`
--
ALTER TABLE `kategorija`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `komentar`
--
ALTER TABLE `komentar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `proizvod`
--
ALTER TABLE `proizvod`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `vest`
--
ALTER TABLE `vest`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
