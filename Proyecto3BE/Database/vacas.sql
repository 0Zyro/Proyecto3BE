-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 13-11-2018 a las 08:48:48
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
(36444909, 'Andrea', 'Paulo', 'Nicanor Amaro 1498', '099533719', 1),
(44880987, 'Carlos ', 'Hernandez', 'Luis menoni', '47377411', 0),
(46658364, 'Maximiliano', 'Curbelo', 'Juncal 1434', '092583411', 1),
(49910331, 'Marcos', 'Paulo', 'Camino del Exodo 1232', '092020071', 1),
(50261755, 'Carlos', 'Fetin', 'Apolon 1492', '22841', 1),
(52663236, 'Luis', 'Peréz', 'Julio delgado 1222', '092345671', 1),
(53656101, 'Vanesa', 'Castellanos', 'Luis menoni', '47377411', 0),
(55765251, 'Aldana', 'Olivera', 'Victor Lima 1478', '099533719', 1),
(62713021, 'Erick', 'Hernandez', 'Luis menoni', '47377411', 0);

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
) ENGINE=InnoDB AUTO_INCREMENT=2011 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `compra`
--

INSERT INTO `compra` (`idc`, `fechacompra`, `comentarioc`, `totalc`) VALUES
(2001, '2018-11-12', 'Vacunas al dia', 4143),
(2002, '2018-11-12', 'Vacunas al dia', 3352),
(2003, '2018-11-12', '3 Paquetes de vacunas', 4000),
(2004, '2017-11-12', 'Alambrado 600 Metros', 3500),
(2005, '2018-11-12', 'Vacunas contra infecciones', 1500),
(2006, '2013-08-01', 'Vacunas al dia', 870),
(2007, '2018-11-12', 'Productoooooo', 200),
(2008, '2018-02-12', 'Vendido con vacunas al dia', 1362),
(2009, '2015-01-16', 'Comprado con bajo peso', 759),
(2010, '2017-11-12', 'Madera para cercado', 2500);

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
) ENGINE=InnoDB AUTO_INCREMENT=1033 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `ganado`
--

INSERT INTO `ganado` (`idg`, `sexo`, `raza`, `nacimiento`, `estado`, `preciov`, `precioc`, `idc`, `idv`) VALUES
(1001, 'Hembra', 'Aberdeen', '2018-01-12', 'vendido', 600, NULL, NULL, 3001),
(1002, 'Hembra', 'Aberdeen', '2010-11-12', 'vendido', 660, NULL, NULL, 3002),
(1003, 'Hembra', 'Aberdeen', '2018-02-12', 'vendido', 330.2, NULL, NULL, 3004),
(1004, 'Hembra', 'Aberdeen', '2009-06-12', 'vendido', 660, NULL, NULL, 3003),
(1005, 'Hembra', 'Aberdeen', '2010-11-12', 'vendido', 660, NULL, NULL, 3006),
(1007, 'Macho', 'Angus', '2018-11-12', 'vendido', 600, NULL, NULL, 3008),
(1008, 'Macho', 'Aberdeen', '2009-02-12', 'vendido', 530, NULL, NULL, 3007),
(1009, 'Macho', 'Aberdeen', '2009-12-26', 'activo', NULL, NULL, NULL, NULL),
(1010, 'Macho', 'Aberdeen', '2014-07-25', 'vendido', 800, NULL, NULL, 3006),
(1011, 'Macho', 'Braford', '2010-02-12', 'vendido', 735, NULL, NULL, 3007),
(1012, 'Macho', 'Braford', '2015-07-17', 'vendido', 990, 690, 2001, 3008),
(1013, 'Macho', 'Braford', '2015-08-06', 'Activo', NULL, 660, 2001, NULL),
(1014, 'Macho', 'Braford', '2015-11-12', 'vendido', 600, 600, 2001, 3009),
(1015, 'Macho', 'Braford', '2017-12-31', 'Activo', NULL, 578, 2001, NULL),
(1016, 'Hembra', 'Braford', '2015-07-18', 'Activo', NULL, 805, 2001, NULL),
(1017, 'Hembra', 'Braford', '2015-06-10', 'Activo', NULL, 810, 2001, NULL),
(1018, 'Hembra', 'Hereford', '2014-06-17', 'Activo', NULL, 768, 2002, NULL),
(1019, 'Hembra', 'Hereford', '2013-02-23', 'Activo', NULL, 833, 2002, NULL),
(1020, 'Hembra', 'Hereford', '2016-11-26', 'Activo', NULL, 660, 2002, NULL),
(1021, 'Macho', 'Hereford', '2015-07-10', 'Activo', NULL, 651, 2002, NULL),
(1022, 'Macho', 'Hereford', '2016-07-08', 'Activo', NULL, 440, 2002, NULL),
(1023, 'Macho', 'Angus', '2018-06-13', 'Activo', NULL, 450, 2006, NULL),
(1024, 'Macho', 'Angus', '2018-05-30', 'Activo', NULL, 420, 2006, NULL),
(1025, 'Hembra', 'Aberdeen', '2018-11-12', 'vendido', 627, NULL, NULL, 3009),
(1026, 'Hembra', 'Aberdeen', '2018-11-12', 'activo', NULL, NULL, NULL, NULL),
(1027, 'Macho', 'Hereford', '2018-11-12', 'Activo', NULL, 330, 2008, NULL),
(1028, 'Macho', 'Angus', '2018-11-12', 'Activo', NULL, 300, 2008, NULL),
(1029, 'Hembra', 'Hereford', '2018-11-12', 'Activo', NULL, 372, 2008, NULL),
(1030, 'Hembra', 'Hereford', '2018-11-12', 'Activo', NULL, 360, 2008, NULL),
(1031, 'Macho', 'Braford', '2018-01-17', 'Activo', NULL, 429, 2009, NULL),
(1032, 'Hembra', 'Braford', '2018-01-24', 'Activo', NULL, 330, 2009, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `razas`
--

DROP TABLE IF EXISTS `razas`;
CREATE TABLE IF NOT EXISTS `razas` (
  `idr` int(11) NOT NULL AUTO_INCREMENT,
  `razitas` varchar(15) NOT NULL,
  PRIMARY KEY (`idr`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `razas`
--

INSERT INTO `razas` (`idr`, `razitas`) VALUES
(14, 'Aberdeen'),
(15, 'Angus'),
(16, 'Braford'),
(17, 'Hereford');

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
('46658364', 'Diego Ferreira', '2391211241292424045251100150722193631401183541401566618344201929421516815216679', 'Admin', 'activo', 'C:/Users/Usuario/AppData/Local/Apps/2.0/TDO3C0WA.O7E/Resources/profile/img2.bmp'),
('49784384', 'Luciano Garayalde', '168175196198108177185197420513625123020143301748856235119492461163200562149427', 'Admin', 'activo', 'C:/Users/Usuario/AppData/Local/Apps/2.0/TDO3C0WA.O7E/Resources/profile/nueva.bmp'),
('52663236', 'Juan Pablo', '809817156791621961429911481561923822314857140179462197717821798196183188213822519', 'Admin', 'activo', 'C:/Users/Usuario/AppData/Local/Apps/2.0/TDO3C0WA.O7E/Resources/profile/img3.bmp'),
('53658278', 'Matias Castellanos', '4316052107501893678208212262620271220391112157165355312431051197611320314470', 'Admin', 'activo', 'C:/Users/Usuario/AppData/Local/Apps/2.0/TDO3C0WA.O7E/Resources/profile/nueva.bmp');

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
) ENGINE=InnoDB AUTO_INCREMENT=3010 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `venta`
--

INSERT INTO `venta` (`idv`, `fechaventa`, `comentariov`, `totalv`, `id`) VALUES
(3001, '2018-11-12', 'Vacunado contra hepatitis', 732, 46658364),
(3002, '2018-11-06', 'Vendida en buen estado y con vacunas al dia', 805.2, 36444909),
(3003, '2018-11-11', 'dsgdf', 805.2, 36444909),
(3004, '2018-11-12', 'Otra venta', 402.84, 46658364),
(3006, '2018-11-12', 'Vacunas al dia', 1781.2, 62713021),
(3007, '2017-09-14', 'Vendido al señor', 1543.3, 46658364),
(3008, '2018-06-12', 'Vendido a precio arreglado', 1939.8, 36444909),
(3009, '2018-06-12', 'Vendido a precio arreglado', 1496.94, 53656101);

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
