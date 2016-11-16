use imjoias;

DROP TABLE IF EXISTS `foto`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `foto` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `mercadoria` varchar(100) NOT NULL DEFAULT '',
  `descricao` varchar(45) DEFAULT NULL,
  `foto` mediumblob NOT NULL,
  `icone` blob,
  `data` datetime DEFAULT NULL,
  `peso` double DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `idx_foto_mercadoria` (`mercadoria`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 DATA DIRECTORY='/var/lib/mysql_hd/' INDEX DIRECTORY='/var/lib/mysql_hd/';
 SET character_set_client = @saved_cs_client ;


SET PASSWORD FOR 'andrep'@'%' = PASSWORD('andrep');
flush privileges;

=============================================
use imjoias;

DROP TABLE saidafiscalpdf;
drop table saidaitemfiscal;
DROP TABLE saidafiscal;




 CREATE TABLE `saidafiscal` (
   `id` varchar(49) NOT NULL,
   `dataemissao` datetime NOT NULL,
   `valortotal` decimal(8,2) NOT NULL,
   `numero` int(11) DEFAULT NULL,
   `cnpjemitente` varchar(18) DEFAULT NULL,
   `cancelada` tinyint(1) NOT NULL DEFAULT '0',
   `observacoes` mediumtext NOT NULL,
   `tipo` int(11) NOT NULL,
   `datasaida` datetime NOT NULL,
   `setor` int(10) unsigned NOT NULL,
   `maquina` int(11) DEFAULT NULL,
   PRIMARY KEY (`id`),
   KEY `saidafiscal_tipodocumentofiscal_FK` (`tipo`),
   KEY `saidafiscal_setor_FK` (`setor`),
   KEY `fk_saidafiscal_1_idx` (`maquina`),
   KEY `index5` (`cancelada`),
   KEY `index6` (`datasaida`),
   CONSTRAINT `fk_saidafiscal_1` FOREIGN KEY (`maquina`) REFERENCES `maquinafiscal` (`codigo`) ON UPDATE CASCADE,
   CONSTRAINT `saidafiscal_setor_FK` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
   CONSTRAINT `saidafiscal_tipodocumentofiscal_FK` FOREIGN KEY (`tipo`) REFERENCES `tipodocumentofiscal` (`id`) ON UPDATE CASCADE
 ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
  SET character_set_client = @saved_cs_client ;


DROP TABLE IF EXISTS `saidafiscalpdf`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `saidafiscalpdf` (
  `id` varchar(49) NOT NULL,
  `pdf` mediumblob NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `FK_saidafiscalpdf_saidafiscal` FOREIGN KEY (`id`) REFERENCES `saidafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;
 SET character_set_client = @saved_cs_client ;



DROP TABLE IF EXISTS `saidaitemfiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `saidaitemfiscal` (
  `referencia` varchar(11) NOT NULL,
  `descricao` tinytext NOT NULL,
  `cfop` int(11) DEFAULT NULL,
  `tipounidade` int(11) DEFAULT NULL,
  `quantidade` decimal(8,2) NOT NULL,
  `valorunitario` decimal(8,2) NOT NULL,
  `valor` decimal(8,2) NOT NULL,
  `saidafiscal` varchar(49) DEFAULT NULL,
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`codigo`),
  KEY `fk_vendaitemfiscal_1_idx` (`tipounidade`),
  KEY `fk_saidaitemfiscal_1_idx` (`saidafiscal`),
  KEY `index4` (`referencia`),
  CONSTRAINT `fk_saidaitemfiscal_tipounidade` FOREIGN KEY (`tipounidade`) REFERENCES `tipounidadefiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_saidaitemfiscal_saidafiscal` FOREIGN KEY (`saidafiscal`) REFERENCES `saidafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

 drop procedure inventario;

 USE `imjoias`;
 DROP procedure IF EXISTS `inventario`;

 DELIMITER $$
 USE `imjoias`$$
 CREATE PROCEDURE `inventario` (IN dataMaxima DATETIME)
 BEGIN
 select i.* from (select @d1:=dataMaxima p) parm, inventario_parcial i;
 END$$

 DELIMITER ;
