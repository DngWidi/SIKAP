-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versi server:                 8.0.25 - MySQL Community Server - GPL
-- OS Server:                    Win64
-- HeidiSQL Versi:               12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Membuang struktur basisdata untuk salary_new
CREATE DATABASE IF NOT EXISTS `salary_new` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `salary_new`;

-- membuang struktur untuk table salary_new.saabsensi
CREATE TABLE IF NOT EXISTS `saabsensi` (
  `ffcnik` char(6) NOT NULL,
  `ffdtgl` date NOT NULL,
  `ffcabs` varchar(3) DEFAULT '',
  `ffnjam` decimal(5,2) DEFAULT '0.00',
  `ffcket` varchar(50) DEFAULT '',
  `ffcbag` varchar(5) DEFAULT '',
  `ffc_id` varchar(10) DEFAULT '',
  PRIMARY KEY (`ffcnik`,`ffdtgl`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sabagian
CREATE TABLE IF NOT EXISTS `sabagian` (
  `ffcbag` varchar(5) NOT NULL,
  `ffcnama` varchar(25) DEFAULT '',
  `ffntkar` int DEFAULT '0',
  `ffntkar1` int DEFAULT '0',
  `ffcid` varchar(10) DEFAULT '',
  PRIMARY KEY (`ffcbag`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sabiaya
CREATE TABLE IF NOT EXISTS `sabiaya` (
  `ffckode` varchar(2) NOT NULL,
  `ffcnama` varchar(35) DEFAULT '',
  `ffc_id` varchar(50) DEFAULT '',
  PRIMARY KEY (`ffckode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sacuti
CREATE TABLE IF NOT EXISTS `sacuti` (
  `ffcnik` char(6) NOT NULL,
  `ffncuti1` int DEFAULT '0',
  `ffncuti2` int DEFAULT '0',
  PRIMARY KEY (`ffcnik`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sacuti_detil
CREATE TABLE IF NOT EXISTS `sacuti_detil` (
  `ffdtgl` date DEFAULT NULL,
  `ffcnik` char(6) DEFAULT '',
  `ffcketerangan` varchar(100) DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sadepartment
CREATE TABLE IF NOT EXISTS `sadepartment` (
  `ffckode` char(1) NOT NULL,
  `ffcnama` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ffckode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sagajian
CREATE TABLE IF NOT EXISTS `sagajian` (
  `Nik` char(6) NOT NULL,
  `Karyawan` varchar(50) DEFAULT '',
  `Bagian` varchar(150) DEFAULT '',
  `Jabatan` varchar(150) DEFAULT '',
  `Gp` varchar(50) DEFAULT '',
  `Tunlain` varchar(50) DEFAULT '',
  `Tunjabat` varchar(50) DEFAULT '',
  `Trans` decimal(10,2) DEFAULT '0.00',
  `Makan` decimal(10,2) DEFAULT '0.00',
  `Spsi` decimal(10,2) DEFAULT '0.00',
  `Jamsostek` decimal(10,2) DEFAULT '0.00',
  `L1` varchar(5) DEFAULT '',
  `L2` varchar(5) DEFAULT '',
  `L3` varchar(5) DEFAULT '',
  `L4` varchar(5) DEFAULT '',
  `L5` varchar(5) DEFAULT '',
  `P4A` varchar(5) DEFAULT '',
  `P4B` varchar(5) DEFAULT '',
  `Skor` varchar(5) DEFAULT '',
  `TransL` decimal(10,2) DEFAULT '0.00',
  `MakanL` decimal(10,2) DEFAULT '0.00',
  `Biaya` varchar(50) DEFAULT '',
  `Kesehatan` decimal(10,2) DEFAULT '0.00',
  `Department` varchar(50) DEFAULT '',
  PRIMARY KEY (`Nik`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sagrupbagian
CREATE TABLE IF NOT EXISTS `sagrupbagian` (
  `ffckode` char(2) NOT NULL,
  `ffcnama` varchar(25) DEFAULT '',
  `ffntkar` int DEFAULT '0',
  `ffntkar1` int DEFAULT '0',
  `ffc_id` varchar(15) DEFAULT '',
  PRIMARY KEY (`ffckode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sagrupjabatan
CREATE TABLE IF NOT EXISTS `sagrupjabatan` (
  `ffckode` char(2) NOT NULL,
  `ffcnama` varchar(30) DEFAULT '',
  `ffntkar` int DEFAULT '0',
  `ffntkar1` int DEFAULT '0',
  `ffc_id` varchar(15) DEFAULT '',
  PRIMARY KEY (`ffckode`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sajabatan
CREATE TABLE IF NOT EXISTS `sajabatan` (
  `ffckls` varchar(3) NOT NULL DEFAULT '',
  `ffcnama` varchar(75) DEFAULT '',
  `ffnbbgp` decimal(10,2) DEFAULT '0.00',
  `ffnbagp` decimal(10,2) DEFAULT '0.00',
  `ffnbbgb` decimal(10,2) DEFAULT '0.00',
  `ffnbagb` decimal(10,2) DEFAULT '0.00',
  `ffntkar` int DEFAULT '0',
  `ffntkar1` int DEFAULT '0',
  `ffcid` varchar(50) DEFAULT '',
  PRIMARY KEY (`ffckls`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sajadwalkerja
CREATE TABLE IF NOT EXISTS `sajadwalkerja` (
  `ffcnik` char(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ffdtanggal` date NOT NULL,
  `ffckode` char(2) NOT NULL DEFAULT '',
  `ffcnama` varchar(50) DEFAULT '',
  `ffcbagian` varchar(50) DEFAULT '',
  `ffcshift` int DEFAULT '0',
  PRIMARY KEY (`ffcnik`,`ffdtanggal`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sajatidiri
CREATE TABLE IF NOT EXISTS `sajatidiri` (
  `ffcnik` char(6) NOT NULL,
  `ffckk` char(16) DEFAULT '',
  `ffcktp` char(16) DEFAULT '',
  `ffcprefix` char(2) DEFAULT '',
  `ffcfname` varchar(30) DEFAULT '',
  `ffcmname` varchar(30) DEFAULT '',
  `ffclname` varchar(30) DEFAULT '',
  `ffcnick` varchar(15) DEFAULT '',
  `ffcnama` varchar(50) DEFAULT '',
  `ffcdepart` char(1) DEFAULT '',
  `ffcbagian` char(5) DEFAULT '',
  `ffcjabatan` char(3) DEFAULT '',
  `ffcsex` char(1) DEFAULT '',
  `ffcbank` varchar(50) DEFAULT '',
  `ffcrek` varchar(25) DEFAULT '',
  `ffdmasuk` date DEFAULT NULL,
  `ffcstatuspeg` varchar(20) DEFAULT '',
  `ffdstatuspeg` date DEFAULT NULL,
  `ffcshift` varchar(15) DEFAULT '',
  `ffcnpwp` varchar(20) DEFAULT '',
  `ffckewarganegaraan` varchar(25) DEFAULT '',
  `ffclahir` varchar(25) DEFAULT '',
  `ffdlahir` date DEFAULT NULL,
  `ffcagama` char(1) DEFAULT '',
  `ffcdarah` varchar(3) DEFAULT '',
  `ffcemail` varchar(150) DEFAULT '',
  `ffcemailoff` varchar(150) DEFAULT '',
  `ffcpend` varchar(3) DEFAULT '',
  `ffcjurusan` varchar(50) DEFAULT '',
  `ffcstatuskawin` varchar(20) DEFAULT '',
  `ffctk` varchar(4) DEFAULT '',
  `ffctelp` varchar(20) DEFAULT '',
  `ffcalamatktp` varchar(200) DEFAULT '',
  `ffcdomisili` varchar(200) DEFAULT '',
  `ffcref` varchar(20) DEFAULT '',
  `ffcnamaref` varchar(100) DEFAULT '',
  `ffcsisker` varchar(2) DEFAULT '',
  `ffcbiaya` varchar(2) DEFAULT '',
  `ffcpl_group` varchar(1) DEFAULT '',
  `ffcpin` varchar(4) DEFAULT '',
  PRIMARY KEY (`ffcnik`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sajatidiri_detil1
CREATE TABLE IF NOT EXISTS `sajatidiri_detil1` (
  `ffcnik` char(6) NOT NULL DEFAULT '',
  `ffcgp` varchar(50) NOT NULL DEFAULT '' COMMENT 'Gapok',
  `ffctunlain` varchar(50) NOT NULL DEFAULT '' COMMENT 'Tun. Lain',
  `ffctunjabat` varchar(50) NOT NULL DEFAULT '' COMMENT 'Tun. Jabatan',
  `ffntrans` decimal(8,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Trans',
  `ffntranst` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Trans Total',
  `ffnmakan` decimal(8,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Makan',
  `ffnmakant` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Makan Total',
  `ffntransl` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Trans Lembur',
  `ffnmakanl` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Makan Lembur',
  `ffnspsi` decimal(8,2) NOT NULL DEFAULT '0.00',
  `ffnjamsostek` decimal(8,2) NOT NULL DEFAULT '0.00',
  `ffnkesehatan` decimal(8,2) NOT NULL DEFAULT '0.00',
  `ffnl1` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur A (HARI KERJA - JAM 1)',
  `ffnl2` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur B (HARI KERJA - JAM 2)',
  `ffnl3` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur C (HARI LIBUR - JAM 1)',
  `ffnl4` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur D (HARI LIBUR - JAM 2)',
  `ffnl5` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur E (HARI LIBUR - JAM 3)',
  `ffnp4a` decimal(5,2) NOT NULL DEFAULT '0.00',
  `ffnp4b` decimal(5,2) NOT NULL DEFAULT '0.00',
  `ffnskr` decimal(5,2) NOT NULL DEFAULT '0.00',
  `ffcgpx` varchar(50) NOT NULL DEFAULT '' COMMENT 'GP awal sebelum Mutasi',
  `ffctunjabatx` varchar(50) NOT NULL DEFAULT '' COMMENT 'TunJabat awal sebelum Mutasi',
  `ffctunlainx` varchar(50) NOT NULL DEFAULT '' COMMENT 'TunLain awal sebelum Mutasi',
  `ffntransx` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Trans awal sebelum Mutasi',
  KEY `ffcnik` (`ffcnik`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sajatidiri_detil2
CREATE TABLE IF NOT EXISTS `sajatidiri_detil2` (
  `ffcnik` char(6) NOT NULL,
  `ffdtgl` date NOT NULL,
  `ffcnama` varchar(50) DEFAULT '',
  `ffcdepart_old` char(1) DEFAULT '',
  `ffcbagian_old` char(5) DEFAULT '',
  `ffcjabatan_old` char(3) DEFAULT '',
  `ffcgp_old` varchar(50) DEFAULT '',
  `ffctunjabat_old` varchar(50) DEFAULT '',
  `ffctunlain_old` varchar(50) DEFAULT '',
  `ffcdepart` varchar(50) DEFAULT '',
  `ffcbagian` varchar(50) DEFAULT '',
  `ffcjabatan` varchar(50) DEFAULT '',
  `ffcgp` varchar(50) DEFAULT '',
  `ffctunjabat` varchar(50) DEFAULT '',
  `ffctunlain` varchar(50) DEFAULT '',
  `ffcketerangan` varchar(50) DEFAULT '',
  PRIMARY KEY (`ffcnik`,`ffdtgl`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sajatidiri_detil3
CREATE TABLE IF NOT EXISTS `sajatidiri_detil3` (
  `ffcnik` char(6) NOT NULL DEFAULT '',
  `ffcgp` varchar(50) NOT NULL DEFAULT '' COMMENT 'Gapok',
  `ffctunlain` varchar(50) NOT NULL DEFAULT '' COMMENT 'Tun. Lain',
  `ffctunjabat` varchar(50) NOT NULL DEFAULT '' COMMENT 'Tun. Jabatan',
  `ffntrans` decimal(8,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Trans',
  `ffntranst` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Trans Total',
  `ffnmakan` decimal(8,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Makan',
  `ffnmakant` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Makan Total',
  `ffntransl` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Trans Lembur',
  `ffnmakanl` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Uang Makan Lembur',
  `ffnspsi` decimal(8,2) NOT NULL DEFAULT '0.00',
  `ffnjamsostek` decimal(8,2) NOT NULL DEFAULT '0.00',
  `ffnkesehatan` decimal(8,2) NOT NULL DEFAULT '0.00',
  `ffnl1` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur A (HARI KERJA - JAM 1)',
  `ffnl2` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur B (HARI KERJA - JAM 2)',
  `ffnl3` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur C (HARI LIBUR - JAM 1)',
  `ffnl4` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur D (HARI LIBUR - JAM 2)',
  `ffnl5` decimal(5,2) NOT NULL DEFAULT '0.00' COMMENT 'Lembur E (HARI LIBUR - JAM 3)',
  `ffnp4a` decimal(5,2) NOT NULL DEFAULT '0.00',
  `ffnp4b` decimal(5,2) NOT NULL DEFAULT '0.00',
  `ffnskr` decimal(5,2) NOT NULL DEFAULT '0.00',
  `ffcgpx` varchar(50) NOT NULL DEFAULT '' COMMENT 'GP awal sebelum Mutasi',
  `ffctunjabatx` varchar(50) NOT NULL DEFAULT '' COMMENT 'TunJabat awal sebelum Mutasi',
  `ffctunlainx` varchar(50) NOT NULL DEFAULT '' COMMENT 'TunLain awal sebelum Mutasi',
  `ffntransx` decimal(10,2) NOT NULL DEFAULT '0.00' COMMENT 'Trans awal sebelum Mutasi',
  KEY `ffcnik` (`ffcnik`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakandidat
CREATE TABLE IF NOT EXISTS `sakandidat` (
  `ffcidkandidat` bigint NOT NULL AUTO_INCREMENT,
  `ffcnokandidat` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `ffcnama` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `ffctempatlahir` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffdtgllahir` date DEFAULT NULL,
  `ffcjeniskelamin` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcstatuspernikahan` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcnik` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcnpwp` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcnotelp` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcemail` varchar(150) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcalamat` text COLLATE utf8mb4_general_ci,
  `ffckelurahan` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffckecamatan` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffckota` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcprovinsi` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffckodepos` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcsumberkandidat` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcstatus` varchar(30) COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'ACTIVE',
  `ffcketerangan` text COLLATE utf8mb4_general_ci,
  `ffcfilefoto` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcusercreate` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffdcreate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffcuserupdate` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffcidkandidat`),
  UNIQUE KEY `uk_nokandidat` (`ffcnokandidat`),
  KEY `idx_nama` (`ffcnama`),
  KEY `idx_nik` (`ffcnik`),
  KEY `idx_email` (`ffcemail`),
  KEY `idx_status` (`ffcstatus`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakandidatdokumen
CREATE TABLE IF NOT EXISTS `sakandidatdokumen` (
  `ffciddokumen` bigint NOT NULL AUTO_INCREMENT,
  `ffcidkandidat` bigint NOT NULL,
  `ffcjenis` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `ffcnama` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `ffcfile` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `ffctipefile` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffnukurang` bigint DEFAULT NULL,
  `ffcketerangan` text COLLATE utf8mb4_general_ci,
  `ffdcreate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffciddokumen`),
  KEY `idx_kandidat` (`ffcidkandidat`),
  KEY `idx_jenis` (`ffcjenis`),
  CONSTRAINT `fk_dokumen_kandidat` FOREIGN KEY (`ffcidkandidat`) REFERENCES `sakandidat` (`ffcidkandidat`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakandidatkeahlian
CREATE TABLE IF NOT EXISTS `sakandidatkeahlian` (
  `ffcidkeahlian` bigint NOT NULL AUTO_INCREMENT,
  `ffcidkandidat` bigint NOT NULL,
  `ffckeahlian` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `ffctingkat` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcketerangan` text COLLATE utf8mb4_general_ci,
  `ffdcreate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffcidkeahlian`),
  KEY `idx_kandidat` (`ffcidkandidat`),
  KEY `idx_keahlian` (`ffckeahlian`),
  CONSTRAINT `fk_keahlian_kandidat` FOREIGN KEY (`ffcidkandidat`) REFERENCES `sakandidat` (`ffcidkandidat`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakandidatpendidikan
CREATE TABLE IF NOT EXISTS `sakandidatpendidikan` (
  `ffcidpendidikan` bigint NOT NULL AUTO_INCREMENT,
  `ffcidkandidat` bigint NOT NULL,
  `ffctingkat` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcnamainstitusi` varchar(150) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcjurusan` varchar(150) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffctahunmasuk` year DEFAULT NULL,
  `ffctahunlulus` year DEFAULT NULL,
  `ffcnilai` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcketerangan` text COLLATE utf8mb4_general_ci,
  `ffdcreate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffcidpendidikan`),
  KEY `idx_kandidat` (`ffcidkandidat`),
  CONSTRAINT `fk_pendidikan_kandidat` FOREIGN KEY (`ffcidkandidat`) REFERENCES `sakandidat` (`ffcidkandidat`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakandidatpengalaman
CREATE TABLE IF NOT EXISTS `sakandidatpengalaman` (
  `ffcidpengalaman` bigint NOT NULL AUTO_INCREMENT,
  `ffcidkandidat` bigint NOT NULL,
  `ffcperusahaan` varchar(150) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcjabatan` varchar(150) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffdtglmulai` date DEFAULT NULL,
  `ffdtglselesai` date DEFAULT NULL,
  `ffcgajiterakhir` decimal(18,2) DEFAULT NULL,
  `ffcalasanberhenti` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcketerangan` text COLLATE utf8mb4_general_ci,
  `ffdcreate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffcidpengalaman`),
  KEY `idx_kandidat` (`ffcidkandidat`),
  CONSTRAINT `fk_pengalaman_kandidat` FOREIGN KEY (`ffcidkandidat`) REFERENCES `sakandidat` (`ffcidkandidat`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakandidatrekrutmen
CREATE TABLE IF NOT EXISTS `sakandidatrekrutmen` (
  `ffcidrekrutmen` bigint NOT NULL AUTO_INCREMENT,
  `ffcidkandidat` bigint NOT NULL,
  `ffcidpermintaan` bigint NOT NULL,
  `ffcstatus` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'SCREENING',
  `ffdapply` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffcketerangan` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffcalasanreject` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffcusercreate` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffdcreate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffcuserupdate` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffcidrekrutmen`) USING BTREE,
  UNIQUE KEY `uk_kandidat_permintaan` (`ffcidkandidat`,`ffcidpermintaan`) USING BTREE,
  KEY `idx_kandidat` (`ffcidkandidat`) USING BTREE,
  KEY `idx_permintaan` (`ffcidpermintaan`) USING BTREE,
  KEY `idx_status` (`ffcstatus`) USING BTREE,
  CONSTRAINT `fk_rekrutmen_kandidat` FOREIGN KEY (`ffcidkandidat`) REFERENCES `sakandidat` (`ffcidkandidat`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_rekrutmen_permintaan` FOREIGN KEY (`ffcidpermintaan`) REFERENCES `sapermintaankaryawan` (`ffcidpermintaan`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakandidatsertifikat
CREATE TABLE IF NOT EXISTS `sakandidatsertifikat` (
  `ffcidsertifikat` bigint NOT NULL AUTO_INCREMENT,
  `ffcidkandidat` bigint NOT NULL,
  `ffcnamasertifikat` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `ffcpenerbit` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcnomorsertifikat` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffdtglterbit` date DEFAULT NULL,
  `ffdtglkadaluarsa` date DEFAULT NULL,
  `ffciddokumen` bigint DEFAULT NULL,
  `ffcketerangan` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffdcreate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffcidsertifikat`) USING BTREE,
  KEY `idx_kandidat` (`ffcidkandidat`) USING BTREE,
  KEY `idx_dokumen` (`ffciddokumen`) USING BTREE,
  CONSTRAINT `fk_sertifikat_dokumen` FOREIGN KEY (`ffciddokumen`) REFERENCES `sakandidatdokumen` (`ffciddokumen`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `fk_sertifikat_kandidat` FOREIGN KEY (`ffcidkandidat`) REFERENCES `sakandidat` (`ffcidkandidat`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakodeabsen
CREATE TABLE IF NOT EXISTS `sakodeabsen` (
  `ffcabs` varchar(3) NOT NULL,
  `ffcket` varchar(40) DEFAULT '',
  `ffcjns` varchar(1) DEFAULT '',
  `ffnpot` int DEFAULT '0',
  `ffcsat` varchar(5) DEFAULT '',
  `ffnjum1` int DEFAULT '0' COMMENT 'untuk jumlah per bulan',
  `ffnjum2` int DEFAULT '0' COMMENT 'untuk jumlah per tahun',
  `ffc_id` varchar(25) DEFAULT '',
  PRIMARY KEY (`ffcabs`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sakodejadwal
CREATE TABLE IF NOT EXISTS `sakodejadwal` (
  `ffckode` char(2) NOT NULL,
  `ffcnama` varchar(50) DEFAULT '',
  `fftberangkat` time DEFAULT NULL,
  `fftpulang` time DEFAULT NULL,
  PRIMARY KEY (`ffckode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.salembur
CREATE TABLE IF NOT EXISTS `salembur` (
  `ffcnik` char(50) NOT NULL,
  `ffdtgl` date NOT NULL,
  `ffnjam` decimal(4,2) DEFAULT '0.00',
  `ffntrans` decimal(8,0) DEFAULT '0',
  `ffcketerangan` varchar(70) DEFAULT '',
  `ffnl1` decimal(4,1) DEFAULT '0.0',
  `ffnl2` decimal(4,1) DEFAULT '0.0',
  `ffnl3` decimal(4,1) DEFAULT '0.0',
  `ffnl4` decimal(4,1) DEFAULT '0.0',
  `ffc_id` varchar(50) DEFAULT '',
  PRIMARY KEY (`ffcnik`,`ffdtgl`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.salibur
CREATE TABLE IF NOT EXISTS `salibur` (
  `ffdtgl` date NOT NULL,
  `ffcket` varchar(50) DEFAULT '',
  `ffc_id` varchar(20) DEFAULT '',
  PRIMARY KEY (`ffdtgl`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.saperiode
CREATE TABLE IF NOT EXISTS `saperiode` (
  `sandi` varchar(50) DEFAULT '',
  `periodeawal` date DEFAULT NULL,
  `periodeakhir` date DEFAULT NULL,
  `pembulatan` varchar(5) DEFAULT '',
  `proseshrd` tinyint DEFAULT '0',
  `lapbulanan` tinyint DEFAULT '0',
  `slip` tinyint DEFAULT '0',
  `backup` tinyint DEFAULT '0',
  `close` tinyint DEFAULT '0',
  `idulfitri` varchar(5) DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sapermintaanapproval
CREATE TABLE IF NOT EXISTS `sapermintaanapproval` (
  `ffcidapproval` bigint NOT NULL AUTO_INCREMENT,
  `ffcidpermintaan` bigint NOT NULL,
  `ffclevel` tinyint NOT NULL,
  `ffcjenis` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `ffcnikapproval` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ffcstatus` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'WAITING',
  `ffdapproval` datetime DEFAULT NULL,
  `ffccatatan` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffdcreate` datetime NOT NULL DEFAULT (now()),
  `ffdupdate` datetime DEFAULT NULL,
  PRIMARY KEY (`ffcidapproval`),
  KEY `ffcidpermintaan` (`ffcidpermintaan`),
  KEY `ffcnikapproval` (`ffcnikapproval`),
  KEY `ffcstatus` (`ffcstatus`),
  KEY `ffcidpermintaan_ffclevel` (`ffcidpermintaan`,`ffclevel`),
  CONSTRAINT `FK__sapermintaankaryawan` FOREIGN KEY (`ffcidpermintaan`) REFERENCES `sapermintaankaryawan` (`ffcidpermintaan`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sapermintaankaryawan
CREATE TABLE IF NOT EXISTS `sapermintaankaryawan` (
  `ffcidpermintaan` bigint NOT NULL AUTO_INCREMENT,
  `ffcnopermintaan` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '' COMMENT 'Nomer Request',
  `ffdtglpermintaan` date DEFAULT NULL COMMENT 'Tanggal Request',
  `ffcnikrequester` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '' COMMENT 'Nik Request',
  `ffckddepart` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '' COMMENT 'Department Request',
  `ffckdbagian` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '' COMMENT 'Kode Bagian',
  `ffckdjabatan` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '' COMMENT 'Kode Jabatan',
  `ffnjumlah` int DEFAULT '0',
  `ffcjnskebutuhan` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffcprioritas` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffcstatuskaryawan` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffdtglbutuh` date DEFAULT NULL,
  `ffcalasan` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffcjustifikasi` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffcstatus` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT 'DRAFT',
  `ffcpendidikan` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffcjurusan` varchar(70) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffnpengalaman` int DEFAULT NULL,
  `ffckompetensi` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffcsertifikasi` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffcdeskripsi` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffctanggungjawab` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffcpersyaratan` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffccatatan` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `ffcnikreplacement` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffcalasanreplace` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  `ffdcreate` datetime DEFAULT NULL,
  `ffdupdate` datetime DEFAULT NULL,
  `ffcupdate` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '',
  PRIMARY KEY (`ffcidpermintaan`),
  UNIQUE KEY `ffcnopermintaan` (`ffcnopermintaan`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.saresign
CREATE TABLE IF NOT EXISTS `saresign` (
  `ffcnik` char(6) NOT NULL DEFAULT '',
  `ffdtglkeluar` date DEFAULT NULL,
  `ffcketkeluar` varchar(150) DEFAULT '',
  `ffcgp` varchar(150) DEFAULT '',
  `ffctunjabat` varchar(150) DEFAULT '',
  `ffctunlain` varchar(150) DEFAULT '',
  `ffntrans` decimal(10,0) DEFAULT '0',
  `ffnmakan` decimal(10,0) DEFAULT '0',
  `ffnasuransi` decimal(10,0) DEFAULT '0',
  PRIMARY KEY (`ffcnik`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.saresign_detil
CREATE TABLE IF NOT EXISTS `saresign_detil` (
  `ffcnik` char(6) NOT NULL,
  `ffckk` char(16) DEFAULT '',
  `ffcktp` char(16) DEFAULT '',
  `ffcprefix` char(2) DEFAULT '',
  `ffcfname` varchar(30) DEFAULT '',
  `ffcmname` varchar(30) DEFAULT '',
  `ffclname` varchar(30) DEFAULT '',
  `ffcnick` varchar(15) DEFAULT '',
  `ffcnama` varchar(50) DEFAULT '',
  `ffcdepart` char(1) DEFAULT '',
  `ffcbagian` char(5) DEFAULT '',
  `ffcjabatan` char(3) DEFAULT '',
  `ffcsex` char(1) DEFAULT '',
  `ffcbank` varchar(50) DEFAULT '',
  `ffcrek` varchar(25) DEFAULT '',
  `ffdmasuk` date DEFAULT NULL,
  `ffcstatuspeg` varchar(20) DEFAULT '',
  `ffdstatuspeg` date DEFAULT NULL,
  `ffcshift` varchar(15) DEFAULT '',
  `ffcnpwp` varchar(20) DEFAULT '',
  `ffckewarganegaraan` varchar(30) DEFAULT '',
  `ffclahir` varchar(25) DEFAULT '',
  `ffdlahir` date DEFAULT NULL,
  `ffcagama` char(1) DEFAULT '',
  `ffcdarah` varchar(3) DEFAULT '',
  `ffcemail` varchar(150) DEFAULT '',
  `ffcemailoff` varchar(150) DEFAULT '',
  `ffcpend` varchar(3) DEFAULT '',
  `ffcjurusan` varchar(50) DEFAULT '',
  `ffcstatuskawin` varchar(20) DEFAULT '',
  `ffctk` varchar(4) DEFAULT '',
  `ffctelp` varchar(20) DEFAULT '',
  `ffcalamatktp` varchar(200) DEFAULT '',
  `ffcdomisili` varchar(200) DEFAULT '',
  `ffcref` varchar(20) DEFAULT '',
  `ffcnamaref` varchar(100) DEFAULT '',
  `ffcsisker` varchar(2) DEFAULT '',
  `ffcbiaya` varchar(2) DEFAULT '',
  `ffcpl_group` varchar(1) DEFAULT '',
  `ffcpin` varchar(3) DEFAULT '',
  PRIMARY KEY (`ffcnik`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sathr
CREATE TABLE IF NOT EXISTS `sathr` (
  `FFCNIK` char(6) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FFCBAG` char(6) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT '',
  `FFNMASA` int DEFAULT '0',
  `FFNTHR` decimal(13,2) DEFAULT '0.00',
  `FFNTHRX` decimal(13,2) DEFAULT '0.00',
  PRIMARY KEY (`FFCNIK`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sathr_lalu
CREATE TABLE IF NOT EXISTS `sathr_lalu` (
  `FFCNIK` char(6) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `FFNGP1` int DEFAULT '0',
  `FFNGP2` int DEFAULT '0',
  `FFNPOKOK1` decimal(5,2) DEFAULT '0.00',
  `FFNEKS1` decimal(5,2) DEFAULT '0.00',
  `FFNPOKOK2` decimal(5,2) DEFAULT '0.00',
  `FFNEKS2` decimal(5,2) DEFAULT '0.00',
  `FFNTHR` int DEFAULT '0',
  `FFNBONUS` int DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sau
CREATE TABLE IF NOT EXISTS `sau` (
  `Nik` varchar(4) DEFAULT '',
  `Karyawan` varchar(50) DEFAULT '',
  `Tgl` date DEFAULT NULL,
  `Waktu` varchar(10) DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.saupload
CREATE TABLE IF NOT EXISTS `saupload` (
  `ffcnik` char(6) NOT NULL,
  `ffdtanggal` date NOT NULL,
  `ffcnama` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
  `ffckode` char(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
  `fftberangkat` time DEFAULT NULL,
  `fftcheckin` time DEFAULT NULL,
  `fftpulang` time DEFAULT NULL,
  `fftcheckout` time DEFAULT NULL,
  PRIMARY KEY (`ffcnik`,`ffdtanggal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Pengeluaran data tidak dipilih.

-- membuang struktur untuk table salary_new.sauser
CREATE TABLE IF NOT EXISTS `sauser` (
  `user` varchar(50) NOT NULL,
  `pass` varchar(50) DEFAULT '',
  `status` char(1) DEFAULT '',
  `f_kdepart` tinyint DEFAULT '0',
  `f_kbagian` tinyint DEFAULT '0',
  `f_kjabatan` tinyint DEFAULT '0',
  `f_kbiaya` tinyint DEFAULT '0',
  `f_kabsen` tinyint DEFAULT '0',
  `f_kalender` tinyint DEFAULT '0',
  `f_karyawan` tinyint DEFAULT '0',
  `f_absen` tinyint DEFAULT '0',
  `f_lembur` tinyint DEFAULT '0',
  `f_proseshrd` tinyint DEFAULT '0',
  `f_imbaljasa` tinyint DEFAULT '0',
  `f_mutasi` tinyint DEFAULT '0',
  `f_resign` tinyint DEFAULT '0',
  `f_thr` tinyint DEFAULT '0',
  `f_lapbulanan` tinyint DEFAULT '0',
  `f_rbagian` tinyint DEFAULT '0',
  `f_rkpbagian` tinyint DEFAULT '0',
  `f_rbiaya` tinyint DEFAULT '0',
  `f_rjabatan` tinyint DEFAULT '0',
  `f_transfer` tinyint DEFAULT '0',
  `f_slip` tinyint DEFAULT '0',
  `f_close` tinyint DEFAULT '0',
  PRIMARY KEY (`user`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Pengeluaran data tidak dipilih.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
