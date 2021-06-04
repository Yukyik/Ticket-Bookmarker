-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 06 พ.ค. 2020 เมื่อ 06:17 PM
-- เวอร์ชันของเซิร์ฟเวอร์: 10.4.10-MariaDB
-- PHP Version: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `final`
--

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room1f1`
--

CREATE TABLE `room1f1` (
  `room` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `day` varchar(100) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room1f1`
--

INSERT INTO `room1f1` (`room`, `time`, `day`, `id`, `status`) VALUES
('1101', '8.00 - 9.00', 'จ', 1, 'b'),
('1101', '12.00 - 13.00', 'จ', 2, 'a'),
('1101', '13.00 - 14.00', 'จ', 3, 'a'),
('1101', '14.00 - 15.00', 'จ', 4, 'a'),
('1101', '15.00 - 16.00', 'จ', 5, 'a'),
('1101', '8.00 - 9.00', 'อ', 6, 'b'),
('1101', '9.00 - 10.00', 'อ', 7, 'a'),
('1101', '10.00 - 11.00', 'อ', 8, 'a'),
('1101', '11.00 - 12.00', 'อ', 9, 'a'),
('1101', '12.00 - 13.00', 'อ', 10, 'a'),
('1101', '10.00 - 11.00', 'พ', 11, 'a'),
('1101', '11.00 - 12.00', 'พ', 12, 'a'),
('1101', '12.00 - 13.00', 'พ', 13, 'a'),
('1101', '13.00 - 14.00', 'พ', 14, 'a'),
('1101', '14.00 - 15.00', 'พ', 15, 'a'),
('1101', '15.00 - 16.00', 'พ', 16, 'a'),
('1101', '10.00 - 11.00', 'พฤ', 17, 'a'),
('1101', '11.00 - 12.00', 'พฤ', 18, 'a'),
('1101', '12.00 - 13.00', 'พฤ', 19, 'a'),
('1101', '15.00 - 16.00', 'พฤ', 20, 'a'),
('1101', '8.00 - 9.00', 'ศ', 21, 'a'),
('1101', '9.00 - 10.00', 'ศ', 22, 'a'),
('1101', '10.00 - 11.00', 'ศ', 23, 'a'),
('1101', '11.00 - 12.00', 'ศ', 24, 'a'),
('1101', '12.00 - 13.00', 'ศ', 25, 'a'),
('1101', '13.00 - 14.00', 'ศ', 26, 'a'),
('1101', '14.00 - 15.00', 'ศ', 27, 'a'),
('1101', '15.00 - 16.00', 'ศ', 28, 'a');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room1f2`
--

CREATE TABLE `room1f2` (
  `room` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `day` varchar(100) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room1f2`
--

INSERT INTO `room1f2` (`room`, `time`, `day`, `id`, `status`) VALUES
('1201', '8.00 - 9.00', 'จ', 1, 'b'),
('1201', '9.00 - 10.00', 'จ', 2, 'b'),
('1201', '10.00 - 11.00', 'จ', 3, 'b'),
('1201', '11.00 - 12.00', 'จ', 4, 'b'),
('1201', '12.00 - 13.00', 'จ', 5, 'b'),
('1201', '15.00 - 16.00', 'จ', 6, 'a'),
('1201', '8.00 - 9.00', 'อ', 7, 'a'),
('1201', '12.00 - 13.00', 'อ', 8, 'a'),
('1201', '13.00 - 14.00', 'อ', 9, 'a'),
('1201', '14.00 - 15.00', 'อ', 10, 'a'),
('1201', '15.00 - 16.00', 'อ', 11, 'a'),
('1201', '8.00 - 9.00', 'พ', 12, 'a'),
('1201', '9.00 - 10.00', 'พ', 13, 'a'),
('1201', '12.00 - 13.00', 'พ', 14, 'a'),
('1201', '13.00 - 14.00', 'พ', 15, 'a'),
('1201', '10.00 - 11.00', 'พฤ', 16, 'a'),
('1201', '11.00 - 12.00', 'พฤ', 17, 'a'),
('1201', '12.00 - 13.00', 'พฤ', 18, 'a'),
('1201', '13.00 - 14.00', 'พฤ', 19, 'a'),
('1201', '14.00 - 15.00', 'พฤ', 20, 'a'),
('1201', '15.00 - 16.00', 'พฤ', 21, 'a'),
('1201', '8.00 - 9.00', 'ศ', 22, 'a'),
('1201', '11.00 -12.00', 'ศ', 23, 'a'),
('1201', '12.00 - 13.00', 'ศ', 24, 'a'),
('1201', '15.00 - 16.00', 'ศ', 25, 'a');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room2f1`
--

CREATE TABLE `room2f1` (
  `room` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `day` varchar(100) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room2f1`
--

INSERT INTO `room2f1` (`room`, `time`, `day`, `id`, `status`) VALUES
('1102', '8.00 - 9.00', 'จ', 1, 'a'),
('1102', '9.00 - 10.00', 'จ', 2, 'a'),
('1102', '10.00 - 11.00', 'จ', 3, 'a'),
('1102', '11.00 - 12.00', 'จ', 4, 'a'),
('1102', '12.00 - 13.00', 'จ', 5, 'b'),
('1102', '10.00 - 11.00', 'อ', 6, 'a'),
('1102', '11.00 - 12.00', 'อ', 7, 'a'),
('1102', '12.00 - 13.00', 'อ', 8, 'b'),
('1102', '15.00 - 16.00', 'อ', 9, 'a'),
('1102', '8.00 - 9.00', 'พ', 10, 'a'),
('1102', '12.00 -13.00', 'พ', 11, 'b'),
('1102', '13.00 - 14.00', 'พ', 12, 'a'),
('1102', '14.00 - 15.00', 'พ', 13, 'a'),
('1102', '15.00 - 16.00', 'พ', 14, 'a'),
('1102', '12.00 - 13.00', 'พฤ', 15, 'b'),
('1102', '13.00 - 14.00', 'พฤ', 16, 'a'),
('1102', '14.00 - 15.00', 'พฤ', 17, 'a'),
('1102', '15.00 - 16.00', 'พฤ', 18, 'a'),
('1102', '8.00 - 9.00', 'ศ', 19, 'a'),
('1102', '9.00 - 10.00', 'ศ', 20, 'a'),
('1102', '10.00 - 11.00', 'ศ', 21, 'a'),
('1102', '11.00 - 12.00', 'ศ', 22, 'a'),
('1102', '12.00 - 13.00', 'ศ', 23, 'b');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room2f2`
--

CREATE TABLE `room2f2` (
  `room` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `day` varchar(100) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room2f2`
--

INSERT INTO `room2f2` (`room`, `time`, `day`, `id`, `status`) VALUES
('1202', '8.00 - 9.00', 'จ', 1, 'b'),
('1202', '11.00 - 12.00', 'จ', 2, 'b'),
('1202', '12.00 - 13.00', 'จ', 3, 'b'),
('1202', '14.00 - 15.00', 'จ', 4, 'b'),
('1202', '15.00 - 16.00', 'จ', 5, 'a'),
('1202', '8.00 - 9.00', 'อ', 6, 'a'),
('1202', '9.00 - 10.00', 'อ', 7, 'a'),
('1202', '12.00 - 13.00', 'อ', 8, 'a'),
('1202', '14.00 - 15.00', 'อ', 9, 'a'),
('1202', '15.00 - 16.00', 'อ', 10, 'a'),
('1202', '8.00 - 9.00', 'พ', 11, 'a'),
('1202', '12.00 - 13.00', 'พ', 12, 'a'),
('1202', '15.00 - 16.00', 'พ', 13, 'a'),
('1202', '12.00 - 13.00', 'พฤ', 14, 'a'),
('1202', '8.00 - 9.00', 'ศ', 15, 'a'),
('1202', '9.00 - 10.00', 'ศ', 16, 'a'),
('1202', '12.00 - 13.00', 'ศ', 17, 'a'),
('1202', '14.00 - 15.00', 'ศ', 18, 'a'),
('1202', '15.00 - 16.00', 'ศ', 19, 'a');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room3f1`
--

CREATE TABLE `room3f1` (
  `room` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `day` varchar(100) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room3f1`
--

INSERT INTO `room3f1` (`room`, `time`, `day`, `id`, `status`) VALUES
('1103', '12.00 - 13.00', 'จ', 1, 'a'),
('1103', '13.00 - 14.00', 'จ', 2, 'a'),
('1103', '14.00 - 15.00', 'จ', 3, 'a'),
('1103', '15.00 - 16.00', 'จ', 4, 'b'),
('1103', '8.00 - 9.00', 'อ', 5, 'a'),
('1103', '9.00 - 10.00', 'อ', 6, 'a'),
('1103', '10.00 - 11.00 ', 'อ', 7, 'a'),
('1103', '11.00 - 12.00', 'อ', 8, 'a'),
('1103', '15.00 - 16.00', 'อ', 9, 'b'),
('1103', '8.00 - 9.00', 'พ', 10, 'a'),
('1103', '9.00 - 10.00', 'พ', 11, 'a'),
('1103', '12.00 - 13.00', 'พ', 12, 'a'),
('1103', '13.00 - 14.00', 'พ', 13, 'a'),
('1103', '15.00 - 16.00', 'พ', 14, 'b'),
('1103', '8.00 - 9.00', 'พฤ', 15, 'a'),
('1103', '12.00 - 13.00', 'พฤ', 16, 'a'),
('1103', '8.00 - 9.00', 'ศ', 17, 'a'),
('1103', '9.00 - 10.00', 'ศ', 18, 'a'),
('1103', '10.00 - 11.00', 'ศ', 19, 'a'),
('1103', '11.00 - 12.00', 'ศ', 20, 'a'),
('1103', '12.00 - 13.00', 'ศ', 21, 'a'),
('1103', '15.00 - 16.00', 'ศ', 22, 'b');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room3f2`
--

CREATE TABLE `room3f2` (
  `room` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `day` varchar(100) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room3f2`
--

INSERT INTO `room3f2` (`room`, `time`, `day`, `id`, `status`) VALUES
('1203', '9.00 - 8.00', 'จ', 1, 'b'),
('1203', '12.00 - 13.00', 'จ', 2, 'a'),
('1203', '13.00 - 14.00', 'จ', 3, 'a'),
('1203', '14.00 -15.00', 'จ', 4, 'a'),
('1203', '15.00 -16.00', 'จ', 5, 'a'),
('1203', '8.00 - 9.00', 'อ', 6, 'b'),
('1203', '12.00 - 13.00', 'อ', 7, 'a'),
('1203', '13.00 - 14.00', 'อ', 8, 'a'),
('1203', '14.00 - 15.00', 'อ', 9, 'a'),
('1203', '15.00 - 16.00', 'อ', 10, 'a'),
('1203', '8.00 - 9.00 ', 'พ', 11, 'b'),
('1203', '12.00 - 13.00', 'พ', 12, 'a'),
('1203', '13.00 - 14.00', 'พ', 13, 'a'),
('1203', '14.00 - 15.00', 'พ', 14, 'a'),
('1203', '15.00 - 16.00', 'พ', 15, 'a'),
('1203', '8.00 - 9.00', 'พฤ', 16, 'b'),
('1203', '12.00 - 13.00', 'พฤ\r\n', 17, 'a'),
('1203', '13.00 - 14.00', 'พฤ', 18, 'a'),
('1203', '14.00 - 15.00', 'พฤ', 19, 'a'),
('1203', '15.00 - 16.00', 'พฤ', 20, 'a'),
('1203', '8.00 - 9.00', 'ศ', 21, 'b'),
('1203', '12.00 - 13.00', 'ศ', 22, 'a'),
('1203', '13.00 - 14.00', 'ศ', 23, 'a'),
('1203', '14.00 - 15.00', 'ศ', 24, 'a'),
('1203', '15.00 - 16.00', 'ศ', 25, 'a');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room4f1`
--

CREATE TABLE `room4f1` (
  `room` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  `day` varchar(100) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room4f1`
--

INSERT INTO `room4f1` (`room`, `time`, `day`, `id`, `status`) VALUES
('1104', '12.00 - 13.00', 'จ', 1, 'b'),
('1104', '8.00 - 9.00', 'อ', 2, 'a'),
('1104', '9.00 - 10.00', 'อ', 3, 'a'),
('1104', '12.00 - 13.00', 'อ', 4, 'b'),
('1104', '13.00 - 14.00', 'อ', 5, 'a'),
('1104', '8.00 - 9.00', 'พ', 6, 'a'),
('1104', '12.00 - 13.00', 'พ', 7, 'b'),
('1104', '15.00 - 16.00', 'พ', 8, 'a'),
('1104', '10.00 - 11.00', 'พฤ', 9, 'a'),
('1104', '11.00 - 12.00', 'พฤ', 10, 'a'),
('1104', '12.00 - 13.00', 'พฤ', 11, 'b'),
('1104', '8.00 - 9.00', 'ศ', 12, 'a'),
('1104', '9.00 - 10.00', 'ศ', 13, 'a'),
('1104', '12.00 - 13.00', 'ศ', 14, 'b'),
('1104', '15.00 - 16.00', 'ศ', 15, 'a');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room4f2`
--

CREATE TABLE `room4f2` (
  `room` varchar(25) NOT NULL,
  `time` varchar(25) NOT NULL,
  `day` varchar(25) NOT NULL,
  `id` int(11) NOT NULL,
  `status` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- dump ตาราง `room4f2`
--

INSERT INTO `room4f2` (`room`, `time`, `day`, `id`, `status`) VALUES
('1204', '8.00 - 900', 'จ', 1, 'b'),
('1204', '9.00 - 10.00', 'จ', 2, 'a'),
('1204', '10.00 - 11.00', 'จ', 3, 'a'),
('1204', '11.00 - 12.00', 'จ', 4, 'a'),
('1204', '12.00 - 13.00', 'จ', 5, 'a'),
('1204', '8.00 - 900', 'อ', 6, 'b'),
('1204', '9.00 - 10.00', 'อ', 7, 'a'),
('1204', '10.00 - 11.00', 'อ', 8, 'a'),
('1204', '11.00 - 12.00', 'อ', 9, 'a'),
('1204', '12.00 - 13.00', 'อ', 10, 'a'),
('1204', '8.00 - 900', 'พ', 11, 'b'),
('1204', '9.00 - 10.00', 'พ', 12, 'a'),
('1204', '10.00 - 11.00', 'พ', 13, 'a'),
('1204', '11.00 - 12.00', 'พ', 14, 'a'),
('1204', '12.00 - 13.00', 'พ', 15, 'a'),
('1204', '8.00 - 900', 'พฤ', 16, 'b'),
('1204', '9.00 - 10.00', 'พฤ', 17, 'a'),
('1204', '10.00 - 11.00', 'พฤ', 18, 'a'),
('1204', '11.00 - 12.00', 'พฤ', 19, 'a'),
('1204', '12.00 - 13.00', 'พฤ', 20, 'a'),
('1204', '8.00 - 900', 'ศ', 21, 'b'),
('1204', '9.00 - 10.00', 'ศ', 22, 'a'),
('1204', '10.00 - 11.00', 'ศ', 23, 'a'),
('1204', '11.00 - 12.00', 'ศ', 24, 'a'),
('1204', '12.00 - 13.00', 'ศ', 25, 'a');

-- --------------------------------------------------------

--
-- โครงสร้างตาราง `room_and_time`
--

CREATE TABLE `room_and_time` (
  `Room_No` varchar(100) NOT NULL,
  `Room_Time` varchar(100) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `room1f1`
--
ALTER TABLE `room1f1`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room1f2`
--
ALTER TABLE `room1f2`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room2f1`
--
ALTER TABLE `room2f1`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room2f2`
--
ALTER TABLE `room2f2`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room3f1`
--
ALTER TABLE `room3f1`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room3f2`
--
ALTER TABLE `room3f2`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room4f1`
--
ALTER TABLE `room4f1`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room4f2`
--
ALTER TABLE `room4f2`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `room1f1`
--
ALTER TABLE `room1f1`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `room1f2`
--
ALTER TABLE `room1f2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `room2f1`
--
ALTER TABLE `room2f1`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `room2f2`
--
ALTER TABLE `room2f2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `room3f1`
--
ALTER TABLE `room3f1`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `room3f2`
--
ALTER TABLE `room3f2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `room4f1`
--
ALTER TABLE `room4f1`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `room4f2`
--
ALTER TABLE `room4f2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
