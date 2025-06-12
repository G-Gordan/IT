-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 27, 2016 at 08:48 PM
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
  `specijalna_ponuda` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `proizvod`
--

INSERT INTO `proizvod` (`id`, `naziv`, `kraci_opis`, `pun_opis`, `slika`, `cena`, `trajanje_dana`, `trajanje_casova`, `pocinje`, `vreme`, `specijalna_ponuda`) VALUES
(1, 'HTML & CSS', 'HTML i CSS su osnovni gradivni elementi Interneta, jezici koji pokreću web. U ovom kursu videćete kako HTML čini osnovu weba i na koji način se CSS ugrađuje i proširuje mogućnosti HTML-a.', 'Upoznaćete se sa mogućnostima oba jezika, njihovom sintaksom, primenom i često korišćenim tehnikama. Razumećete osnove Bootstrap biblioteke i izgradnje responsive stranica. Naučićete kako da napravite web sajt od početka, pripremite sadržaj i grafiku i prilagodite web sajt mobilnim uređajima.\r\n\r\nNakon kursa moći ćete da samostalno kreirate portfolio web sajt, blog, web sajt preduzeća, katalog proizvoda. Moći ćete i da prilagodite postojeće web sajtove potrebama svojih klijenata.', 'img/kursevi/html-css.jpg', 80, 5, 20, '2016-10-31', '17:30:00', 1),
(3, 'PHP', 'kratak opis php-a', 'pun opis php-a', 'img/kursevi/php.jpg', 200, 10, 40, '2016-10-29', '11:26:00', 0),
(4, 'Web developer', 'kratak opis php-a', 'pun opis php-a', 'img/kursevi/php.jpg', 200, 10, 40, '2016-10-29', '11:26:00', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `proizvod`
--
ALTER TABLE `proizvod`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `proizvod`
--
ALTER TABLE `proizvod`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
