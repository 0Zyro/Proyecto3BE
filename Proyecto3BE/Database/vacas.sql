-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 26-10-2018 a las 01:42:46
-- Versión del servidor: 5.7.19
-- Versión de PHP: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `vacas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

DROP TABLE IF EXISTS `cliente`;
CREATE TABLE IF NOT EXISTS `cliente` (
  `id` int(11) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `apellido` varchar(30) DEFAULT NULL,
  `direccion` varchar(30) DEFAULT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `estado` int(11) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`id`, `nombre`, `apellido`, `direccion`, `telefono`, `estado`) VALUES
(46658364, 'Diego', 'Ferreira', 'Nicanor Amaro 1498', '47322841', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compra`
--

DROP TABLE IF EXISTS `compra`;
CREATE TABLE IF NOT EXISTS `compra` (
  `idc` int(11) NOT NULL AUTO_INCREMENT,
  `fechacompra` date DEFAULT NULL,
  `comentarioc` varchar(300) DEFAULT NULL,
  `totalc` double DEFAULT NULL,
  PRIMARY KEY (`idc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ganado`
--

DROP TABLE IF EXISTS `ganado`;
CREATE TABLE IF NOT EXISTS `ganado` (
  `idg` int(11) NOT NULL AUTO_INCREMENT,
  `sexo` varchar(10) DEFAULT NULL,
  `raza` varchar(10) DEFAULT NULL,
  `nacimiento` date DEFAULT NULL,
  `estado` varchar(20) DEFAULT NULL,
  `preciov` double DEFAULT NULL,
  `precioc` double DEFAULT NULL,
  `idc` int(11) DEFAULT NULL,
  `idv` int(11) DEFAULT NULL,
  PRIMARY KEY (`idg`),
  KEY `idc` (`idc`),
  KEY `idv` (`idv`)
) ENGINE=InnoDB AUTO_INCREMENT=1008 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `ganado`
--

INSERT INTO `ganado` (`idg`, `sexo`, `raza`, `nacimiento`, `estado`, `preciov`, `precioc`, `idc`, `idv`) VALUES
(1001, 'Macho', 'Aberdeen', '2010-02-25', 'activo', NULL, NULL, NULL, NULL),
(1002, 'Hembra', 'Aberdeen', '2018-10-25', 'activo', NULL, NULL, NULL, NULL),
(1003, 'Macho', 'Angus', '2017-10-01', 'activo', NULL, NULL, NULL, NULL),
(1004, 'Macho', 'Braford', '2018-10-25', 'activo', NULL, NULL, NULL, NULL),
(1005, 'Macho', 'Hereford', '2018-10-25', 'activo', NULL, NULL, NULL, NULL),
(1006, 'Hembra', 'Hereford', '2018-10-25', 'activo', NULL, NULL, NULL, NULL),
(1007, 'Hembra', 'Angus', '2018-10-25', 'activo', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `razas`
--

DROP TABLE IF EXISTS `razas`;
CREATE TABLE IF NOT EXISTS `razas` (
  `idr` int(11) NOT NULL AUTO_INCREMENT,
  `razitas` varchar(15) NOT NULL,
  PRIMARY KEY (`idr`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `razas`
--

INSERT INTO `razas` (`idr`, `razitas`) VALUES
(14, 'Aberdeen'),
(15, 'Angus'),
(16, 'Braford'),
(17, 'Hereford'),
(18, 'Angus Prime');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE IF NOT EXISTS `usuario` (
  `ci` varchar(8) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `contrasena` varchar(256) DEFAULT NULL,
  `rango` varchar(15) DEFAULT NULL,
  `estado` varchar(10) DEFAULT NULL,
  `perfil` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ci`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`ci`, `nombre`, `contrasena`, `rango`, `estado`, `perfil`) VALUES
('46658364', 'Diego Ferreira', '681522551939924028114198235144871542159421013446879595209133661783214231181175252143', 'User', 'activo', 'E:/Documents/Proyecto/Proyecto3BE/Resources/profile/img2.bmp');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `venta`
--

DROP TABLE IF EXISTS `venta`;
CREATE TABLE IF NOT EXISTS `venta` (
  `idv` int(11) NOT NULL AUTO_INCREMENT,
  `fechaventa` date DEFAULT NULL,
  `comentariov` varchar(300) DEFAULT NULL,
  `totalv` double DEFAULT NULL,
  `id` int(11) DEFAULT NULL,
  PRIMARY KEY (`idv`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `ganado`
--
ALTER TABLE `ganado`
  ADD CONSTRAINT `ganado_ibfk_1` FOREIGN KEY (`idc`) REFERENCES `compra` (`idc`),
  ADD CONSTRAINT `ganado_ibfk_2` FOREIGN KEY (`idv`) REFERENCES `venta` (`idv`);

--
-- Filtros para la tabla `venta`
--
ALTER TABLE `venta`
  ADD CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`id`) REFERENCES `cliente` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
