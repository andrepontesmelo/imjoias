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


 ALTER TABLE `imjoias`.`saidafiscal`
 ADD COLUMN `cliente` INT(10) UNSIGNED NULL DEFAULT NULL AFTER `maquina`;


 ALTER TABLE `imjoias`.`saidafiscal`
 ADD INDEX `fk_saidafiscal_cliente_idx` (`cliente` ASC);
 ALTER TABLE `imjoias`.`saidafiscal`
 ADD CONSTRAINT `fk_saidafiscal_cliente`
   FOREIGN KEY (`cliente`)
   REFERENCES `imjoias`.`pessoa` (`codigo`)
   ON DELETE NO ACTION
   ON UPDATE NO ACTION;


ALTER TABLE `imjoias`.`mercadoria` 
ADD COLUMN `classificacaofiscal` VARCHAR(45) NOT NULL DEFAULT '0' AFTER `depeso`,
ADD COLUMN `tipounidade` INT(11) NOT NULL DEFAULT '1' AFTER `classificacaofiscal`,
ADD COLUMN `cfop` INT(11) NOT NULL DEFAULT '5101' AFTER `tipounidade`,
ADD INDEX `fk_mercadoria_tipounidade_idx` (`tipounidade` ASC);
ALTER TABLE `imjoias`.`mercadoria` 
ADD CONSTRAINT `fk_mercadoria_tipounidade`
  FOREIGN KEY (`tipounidade`)
  REFERENCES `imjoias`.`tipounidadefiscal` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

