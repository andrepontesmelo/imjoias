use imjoias;


RENAME TABLE imjoias.vendafiscal TO imjoias.saidafiscal;



ALTER TABLE imjoias.saidafiscal CHANGE tipovenda tiposaida varchar(1) NOT NULL;


RENAME TABLE imjoias.vendaitemfiscal TO imjoias.saidaitemfiscal;


ALTER TABLE imjoias.saidaitemfiscal CHANGE vendafiscal saidafiscal varchar(49) NULL;


ALTER TABLE imjoias.saidafiscal ADD emitidoporcnpj varchar(18) NULL;

CREATE TABLE `entradafiscal` (
  `id` varchar(49) NOT NULL,
  `dataemissao` datetime NOT NULL,
  `valortotal` decimal(8,2) NOT NULL,
  `nnf` int(11) DEFAULT NULL,
  `emitidoporcnpj` varchar(18) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nnf_UNIQUE` (`nnf`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

 CREATE TABLE `entradaitemfiscal` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `descricao` varchar(100) NOT NULL,
  `cfop` int(11) DEFAULT NULL,
  `tipounidade` varchar(1) NOT NULL,
  `quantidade` decimal(8,2) NOT NULL,
  `valorunitario` decimal(8,2) NOT NULL,
  `valor` decimal(8,2) NOT NULL,
  `entradafiscal` varchar(49) DEFAULT NULL,
  KEY `fk_entradaitemfiscal_1_idx` (`entradafiscal`),
  CONSTRAINT `fk_entradaitemfiscal_1` FOREIGN KEY (`entradafiscal`) REFERENCES `entradafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

ALTER TABLE imjoias.entradafiscal CHANGE emitidoporcnpj cnpjemitente varchar(18) NULL;


ALTER TABLE imjoias.saidafiscal CHANGE emitidoporcnpj cnpjemitente varchar(18) NULL;

alter table entradafiscal drop key nnf_UNIQUE;

ALTER TABLE imjoias.saidafiscal ADD cancelada bool DEFAULT false NOT NULL;

ALTER TABLE imjoias.saidafiscal DROP KEY nnf_UNIQUE;



CREATE TABLE imjoias.tipodocumentofiscal (
	id int NOT NULL,
	nome varchar(80) NULL
)
ENGINE=InnoDB
DEFAULT CHARSET=latin1
COLLATE=latin1_swedish_ci;


ALTER TABLE imjoias.tipodocumentofiscal MODIFY COLUMN id INT NOT NULL AUTO_INCREMENT primary key;

insert into tipodocumentofiscal(id, nome) values (1, 'NF-e'), (2, 'Cupom');

ALTER TABLE imjoias.entradafiscal ADD tipo int NOT NULL;

update entradafiscal set tipo=1;

ALTER TABLE imjoias.entradafiscal ADD CONSTRAINT entradafiscal_tipodocumentofiscal_FK FOREIGN KEY (tipo) REFERENCES imjoias.tipodocumentofiscal(id) ON DELETE RESTRICT ON UPDATE CASCADE;

ALTER TABLE imjoias.entradafiscal ADD observacoes mediumtext DEFAULT '' NOT NULL;

ALTER TABLE imjoias.saidafiscal ADD observacoes mediumtext DEFAULT '' NOT NULL;

alter table saidafisca drop column tiposaida;

ALTER TABLE imjoias.saidafiscal ADD tipo int NOT NULL;

update saidafiscal set tipo=1;

ALTER TABLE imjoias.saidafiscal ADD CONSTRAINT saidafiscal_tipodocumentofiscal_FK FOREIGN KEY (tipo) REFERENCES imjoias.tipodocumentofiscal(id) ON DELETE RESTRICT ON UPDATE CASCADE;


ALTER TABLE imjoias.entradafiscal ADD dataentrada datetime NOT NULL;
ALTER TABLE imjoias.entradafiscal CHANGE nnf numero int(11) NULL;
 update entradafiscal set dataentrada=dataemissao;


ALTER TABLE imjoias.saidafiscal ADD datasaida datetime NOT NULL;
ALTER TABLE imjoias.saidafiscal CHANGE nnf numero int(11) NULL;
update entradafiscal set dataentrada=dataemissao;

ALTER TABLE imjoias.saidafiscal DROP COLUMN coo;
ALTER TABLE imjoias.saidafiscal DROP COLUMN contadordocumentoemitido;
update saidafiscal set datasaida=dataemissao;


delete from saidafiscal;

ALTER TABLE imjoias.saidafiscal ADD setor int(10) unsigned NOT NULL;

ALTER TABLE imjoias.saidafiscal ADD CONSTRAINT saidafiscal_setor_FK FOREIGN KEY (setor) REFERENCES imjoias.setor(codigo) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE imjoias.tipodocumentofiscal ADD entrada boolean NULL;
ALTER TABLE imjoias.tipodocumentofiscal ADD saida boolean NULL;



update tipodocumentofiscal set entrada='1', saida='1';

ALTER TABLE imjoias.saidafiscal ADD tipo int NOT NULL;
update saidafiscal set tipo=1;


RENAME TABLE `nfepdf` TO `saidafiscalpdf`;

ALTER TABLE `saidafiscalpdf`
	ALTER `nfe` DROP DEFAULT;
ALTER TABLE `saidafiscalpdf`
	CHANGE COLUMN `nfe` `nfe` VARCHAR(49) NOT NULL FIRST;


ALTER TABLE `saidafiscalpdf`
	ALTER `nfe` DROP DEFAULT;
ALTER TABLE `saidafiscalpdf`
	CHANGE COLUMN `nfe` `id` VARCHAR(49) NOT NULL FIRST;

delete from saidafiscalpdf;


ALTER TABLE `saidafiscalpdf`
	ADD CONSTRAINT `FK_saidafiscalpdf_saidafiscal` FOREIGN KEY (`id`) REFERENCES `saidafiscal` (`id`) ON UPDATE CASCADE ON DELETE CASCADE;

CREATE TABLE `entradafiscalpdf` (
  `id` varchar(49) NOT NULL,
  `pdf` mediumblob NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `FK_entradafiscalpdf_entradafiscal` FOREIGN KEY (`id`) REFERENCES `entradafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;


ALTER TABLE `saidaitemfiscal`
	CHANGE COLUMN `descricao` `descricao` TINYTEXT NOT NULL AFTER `referencia`;

ALTER TABLE `entradaitemfiscal`
	CHANGE COLUMN `descricao` `descricao` TINYTEXT NOT NULL AFTER `referencia`;


ALTER TABLE `imjoias`.`saidaitemfiscal`
CHANGE COLUMN `tipounidade` `tipounidade` INT NOT NULL ;

ALTER TABLE `imjoias`.`entradaitemfiscal`
CHANGE COLUMN `tipounidade` `tipounidade` INT NOT NULL ;

ALTER TABLE `imjoias`.`saidaitemfiscal`
ADD COLUMN `codigo` INT NOT NULL AUTO_INCREMENT AFTER `saidafiscal`,
ADD PRIMARY KEY (`codigo`);


ALTER TABLE `imjoias`.`entradaitemfiscal`
ADD COLUMN `codigo` INT NOT NULL AUTO_INCREMENT AFTER `entradafiscal`,
ADD PRIMARY KEY (`codigo`);

CREATE TABLE `tipounidadefiscal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

insert into tipounidadefiscal (id, nome) values
(1, 'Peça'), (2, 'Par'), (3, 'Gramas'), (4, 'Unidade');

 update saidaitemfiscal set tipounidade=1;
 update entradaitemfiscal set tipounidade=1;


ALTER TABLE `imjoias`.`saidaitemfiscal`
DROP FOREIGN KEY `fk_vendaitemfiscal_1`;
ALTER TABLE `imjoias`.`saidaitemfiscal`
ADD INDEX `fk_vendaitemfiscal_1_idx` (`tipounidade` ASC),
DROP INDEX `fk_vendaitemfiscal_1_idx` ;
ALTER TABLE `imjoias`.`saidaitemfiscal`
ADD CONSTRAINT `fk_vendaitemfiscal_1`
  FOREIGN KEY (`tipounidade`)
  REFERENCES `imjoias`.`tipounidadefiscal` (`id`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


ALTER TABLE `imjoias`.`entradaitemfiscal`
ADD INDEX `fk_entradaitemfiscal_2_idx` (`tipounidade` ASC);
ALTER TABLE `imjoias`.`entradaitemfiscal`
ADD CONSTRAINT `fk_entradaitemfiscal_2`
  FOREIGN KEY (`tipounidade`)
  REFERENCES `imjoias`.`tipounidadefiscal` (`id`)
  ON DELETE RESTRICT
  ON UPDATE CASCADE;

ALTER TABLE `imjoias`.`saidaitemfiscal`
ADD INDEX `fk_saidaitemfiscal_1_idx` (`saidafiscal` ASC);
ALTER TABLE `imjoias`.`saidaitemfiscal`
ADD CONSTRAINT `fk_saidaitemfiscal_1`
  FOREIGN KEY (`saidafiscal`)
  REFERENCES `imjoias`.`saidafiscal` (`id`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


ALTER TABLE `imjoias`.`saidaitemfiscal`
DROP FOREIGN KEY `fk_vendaitemfiscal_1`;
ALTER TABLE `imjoias`.`saidaitemfiscal`
CHANGE COLUMN `tipounidade` `tipounidade` INT(11) NULL ;
ALTER TABLE `imjoias`.`saidaitemfiscal`
ADD CONSTRAINT `fk_vendaitemfiscal_1`
  FOREIGN KEY (`tipounidade`)
  REFERENCES `imjoias`.`tipounidadefiscal` (`id`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


ALTER TABLE `imjoias`.`entradaitemfiscal`
DROP FOREIGN KEY `fk_entradaitemfiscal_2`;
ALTER TABLE `imjoias`.`entradaitemfiscal`
CHANGE COLUMN `tipounidade` `tipounidade` INT(11) NULL ;
ALTER TABLE `imjoias`.`entradaitemfiscal`
ADD CONSTRAINT `fk_entradaitemfiscal_2`
  FOREIGN KEY (`tipounidade`)
  REFERENCES `imjoias`.`tipounidadefiscal` (`id`)
  ON UPDATE CASCADE;


CREATE TABLE `imjoias`.`maquinafiscal` (
  `codigo` INT NOT NULL AUTO_INCREMENT,
  `modelo` VARCHAR(45) NULL,
  `fabricacao` VARCHAR(45) NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE INDEX `index2` (`modelo` ASC, `fabricacao` ASC));


ALTER TABLE `imjoias`.`saidafiscal`
ADD COLUMN `maquina` INT NULL AFTER `setor`;

ALTER TABLE `imjoias`.`saidafiscal`
ADD INDEX `fk_saidafiscal_1_idx` (`maquina` ASC);
ALTER TABLE `imjoias`.`saidafiscal`
ADD CONSTRAINT `fk_saidafiscal_1`
  FOREIGN KEY (`maquina`)
  REFERENCES `imjoias`.`maquinafiscal` (`codigo`)
  ON DELETE RESTRICT
  ON UPDATE CASCADE;



 alter table saidafiscal drop column tiposaida;

ALTER TABLE `imjoias`.`mercadoria`
ADD COLUMN `classificacaofiscal` VARCHAR(45) NULL AFTER `depeso`;


ALTER TABLE `imjoias`.`mercadoria`
ADD COLUMN `tipounidade` INT(11) NOT NULL DEFAULT 1 AFTER `classificacaofiscal`;



ALTER TABLE `imjoias`.`mercadoria`
ADD INDEX `fk_mercadoria_1_idx` (`tipounidade` ASC);
ALTER TABLE `imjoias`.`mercadoria`
ADD CONSTRAINT `fk_mercadoria_1`
  FOREIGN KEY (`tipounidade`)
  REFERENCES `imjoias`.`tipounidadefiscal` (`id`)
  ON DELETE RESTRICT
  ON UPDATE CASCADE;


CREATE TABLE `imjoias`.`esquemaproducaofiscal` (
  `referencia` VARCHAR(11) NOT NULL,
  `quantidade` DECIMAL NOT NULL,
  PRIMARY KEY (`referencia`));




ALTER TABLE `imjoias`.`esquemaproducaofiscal`
ADD CONSTRAINT `fk_esquemaproducaofiscal_1`
  FOREIGN KEY (`referencia`)
  REFERENCES `imjoias`.`mercadoria` (`referencia`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;

CREATE TABLE `imjoias`.`ingredienteesquemaproducaofiscal` (
  `esquema` VARCHAR(11) NOT NULL,
  `referencia` VARCHAR(11) NOT NULL,
  `quantidade` DECIMAL NOT NULL);

ALTER TABLE `imjoias`.`ingredienteesquemaproducaofiscal`
ADD UNIQUE INDEX `index1` (`esquema` ASC, `referencia` ASC);


CREATE TABLE `imjoias`.`estoquelegado` (
  `estoque1` DECIMAL NOT NULL,
  `estoque2` DECIMAL NOT NULL,
  `estoque3` DECIMAL NOT NULL,
  `estoqueanterior` DECIMAL NOT NULL,
  `referencia` VARCHAR(11) NOT NULL,
  PRIMARY KEY (`referencia`));

 insert into tipounidadefiscal( id, nome) values (5, 'Caixa');


ALTER TABLE `imjoias`.`mercadoria`
ADD COLUMN `cfop` INT(11) NOT NULL DEFAULT 5101 AFTER `tipounidade`;

ALTER TABLE `imjoias`.`ingredienteesquemaproducaofiscal`
ADD CONSTRAINT `fk_ingredienteesquemaproducaofiscal_1`
  FOREIGN KEY (`esquema`)
  REFERENCES `imjoias`.`esquemaproducaofiscal` (`referencia`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


update tipounidadefiscal set id=id-1;



CREATE TABLE `imjoias`.`producaofiscal` (
  `codigo` INT NOT NULL AUTO_INCREMENT,
  `data` DATETIME NOT NULL,
  PRIMARY KEY (`codigo`));



CREATE TABLE `imjoias`.`entradaproducaofiscal` (
  `producaofiscal` INT NOT NULL,
  `quantidade` DECIMAL NOT NULL,
  `referencia` VARCHAR(11) NOT NULL,
  PRIMARY KEY (`producaofiscal`));

ALTER TABLE `imjoias`.`entradaproducaofiscal`
ADD CONSTRAINT `fk_entradaproducaofiscal_1`
  FOREIGN KEY (`producaofiscal`)
  REFERENCES `imjoias`.`producaofiscal` (`codigo`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;

ALTER TABLE `imjoias`.`entradaproducaofiscal`
ADD INDEX `fk_entradaproducaofiscal_2_idx` (`referencia` ASC);
ALTER TABLE `imjoias`.`entradaproducaofiscal`
ADD CONSTRAINT `fk_entradaproducaofiscal_2`
  FOREIGN KEY (`referencia`)
  REFERENCES `imjoias`.`mercadoria` (`referencia`)
  ON DELETE RESTRICT
  ON UPDATE CASCADE;


CREATE TABLE `imjoias`.`saidaproducaofiscal` (
  `producaofiscal` INT NOT NULL,
  `quantidade` DECIMAL NOT NULL,
  `referencia` VARCHAR(11) NOT NULL,
  PRIMARY KEY (`producaofiscal`));

ALTER TABLE `imjoias`.`saidaproducaofiscal`
ADD CONSTRAINT `fk_saidaproducaofiscal_1`
  FOREIGN KEY (`producaofiscal`)
  REFERENCES `imjoias`.`producaofiscal` (`codigo`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;

ALTER TABLE `imjoias`.`saidaproducaofiscal`
ADD INDEX `fk_saidaproducaofiscal_2_idx` (`referencia` ASC);
ALTER TABLE `imjoias`.`saidaproducaofiscal`
ADD CONSTRAINT `fk_saidaproducaofiscal_2`
  FOREIGN KEY (`referencia`)
  REFERENCES `imjoias`.`mercadoria` (`referencia`)
  ON DELETE RESTRICT
  ON UPDATE CASCADE;


ALTER TABLE `imjoias`.`entradaitemfiscal`
ADD INDEX `index4` (`referencia` ASC);

ALTER TABLE `imjoias`.`entradafiscal`
ADD INDEX `index3` (`dataentrada` ASC);


ALTER TABLE `imjoias`.`saidaitemfiscal`
ADD INDEX `index4` (`referencia` ASC);

ALTER TABLE `imjoias`.`saidafiscal`
ADD INDEX `index5` (`cancelada` ASC);

ALTER TABLE `imjoias`.`saidafiscal`
ADD INDEX `index6` (`datasaida` ASC);


drop table saidaproducaofiscal;

CREATE TABLE `saidaproducaofiscal` (
  `producaofiscal` int(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  `referencia` varchar(11) NOT NULL,
  KEY `fk_saidaproducaofiscal_2_idx` (`referencia`),
  CONSTRAINT `fk_saidaproducaofiscal_1` FOREIGN KEY (`producaofiscal`) REFERENCES `producaofiscal` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_saidaproducaofiscal_2` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE
) ENGINE=InnoDB;


drop table entradaproducaofiscal;

 CREATE TABLE `entradaproducaofiscal` (
  `producaofiscal` int(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  `referencia` varchar(11) NOT NULL,
  KEY `fk_entradaproducaofiscal_2_idx` (`referencia`),
  CONSTRAINT `fk_entradaproducaofiscal_1` FOREIGN KEY (`producaofiscal`) REFERENCES `producaofiscal` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_entradaproducaofiscal_2` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE
) ENGINE=InnoDB;


USE `imjoias`;
DROP procedure IF EXISTS `inventario`;

DELIMITER $$
USE `imjoias`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `inventario`(IN dataMaxima DATETIME)
BEGIN
select i.referencia, sum(quantidade) as quantidade, nome, classificacaofiscal, tipounidade, p.novoPrecoCusto as valor, sum(quantidade)*p.novoPrecoCusto as valortotal from (
select ei.referencia, e.dataentrada as data,  ei.quantidade from entradaitemfiscal ei join entradafiscal e on ei.entradafiscal=e.id where dataentrada < dataMaxima
UNION
select ei.referencia, e.datasaida as data, -1*ei.quantidade from saidaitemfiscal ei join saidafiscal e on ei.saidafiscal=e.id where datasaida < dataMaxima
UNION
select ei.referencia, e.data, -1*ei.quantidade from entradaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < dataMaxima
UNION
select ei.referencia, e.data, ei.quantidade from saidaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < dataMaxima) i left join
mercadoria m on i.referencia=m.referencia left join novosPrecos p on i.referencia=p.mercadoria
group by referencia;
END$$

DELIMITER ;

ALTER TABLE `imjoias`.`esquemaproducaofiscal`
CHANGE COLUMN `quantidade` `quantidade` DECIMAL(10, 2) NOT NULL ;


ALTER TABLE `imjoias`.`ingredienteesquemaproducaofiscal`
CHANGE COLUMN `quantidade` `quantidade` DECIMAL(10,2) NOT NULL ;


USE `imjoias`;
CREATE  OR REPLACE VIEW `extratoinventario` AS
select e.tipo as tipodocumento, 'E' as tipoextrato, ei.referencia, e.dataentrada as data,  ei.quantidade, ei.valor from entradaitemfiscal ei join entradafiscal e on ei.entradafiscal=e.id where dataentrada < now()
UNION
select e.tipo as tipodocumento, 'S' as tipoextrato, ei.referencia, e.datasaida as data, -1*ei.quantidade, ei.valor from saidaitemfiscal ei join saidafiscal e on ei.saidafiscal=e.id where datasaida < now()
UNION
select null as tipodocumento, 'OT' as tipoextrato, ei.referencia, e.data, -1*ei.quantidade, 0 as valor from entradaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < now()
UNION
select null as tipodocumento, 'TO' as tipoextrato, ei.referencia, e.data, ei.quantidade, 0 as valor from saidaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < now();


ALTER TABLE `imjoias`.`entradafiscal`
DROP INDEX `index3` ,
ADD INDEX `idx_data_entrada` (`dataentrada` ASC);


ALTER TABLE `imjoias`.`entradafiscal`
DROP INDEX `idx_data_entrada_desc`

ALTER TABLE `imjoias`.`entradafiscal` ADD INDEX `idx_data_entrada` (`dataentrada`);


USE `imjoias`;
DROP procedure IF EXISTS `inventario`;

DELIMITER $$
USE `imjoias`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `inventario`(IN dataMaxima DATETIME)
BEGIN
select i.referencia, sum(quantidade) as quantidade, nome, classificacaofiscal, tipounidade, p.novoPrecoCusto as valor, sum(quantidade)*p.novoPrecoCusto as valortotal from (
select ei.referencia, e.dataentrada as data,  ei.quantidade from entradaitemfiscal ei join entradafiscal e on ei.entradafiscal=e.id where dataentrada < dataMaxima
UNION
select ei.referencia, e.datasaida as data, -1*ei.quantidade from saidaitemfiscal ei join saidafiscal e on ei.saidafiscal=e.id where datasaida < dataMaxima
UNION
select ei.referencia, e.data, -1*ei.quantidade from entradaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < dataMaxima
UNION
select ei.referencia, e.data, ei.quantidade from saidaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < dataMaxima) i left join
mercadoria m on i.referencia=m.referencia left join novosPrecos p on i.referencia=p.mercadoria
group by referencia;
END$$

DELIMITER ;

ALTER TABLE `imjoias`.`tipodocumentofiscal`
ADD COLUMN `nomeresumido` VARCHAR(3) NOT NULL DEFAULT '' AFTER `saida`;

UPDATE `imjoias`.`tipodocumentofiscal` SET `nomeresumido`='NF' WHERE `id`='1';
UPDATE `imjoias`.`tipodocumentofiscal` SET `nomeresumido`='CP' WHERE `id`='2';

DROP procedure IF EXISTS `inventario`;


DELIMITER $$
USE `imjoias`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `inventario`(IN dataMaxima DATETIME)
BEGIN
select m.referencia, sum(ifnull(quantidade,0)) as quantidade, m.nome, m.classificacaofiscal, m.tipounidade, p.novoPrecoCusto as valor, sum(ifnull(quantidade,0))*p.novoPrecoCusto as valortotal from
mercadoria m left join
(
	select ei.referencia, e.dataentrada as data,  ei.quantidade from entradaitemfiscal ei join entradafiscal e on ei.entradafiscal=e.id where dataentrada < dataMaxima
	UNION
	select ei.referencia, e.datasaida as data, -1*ei.quantidade from saidaitemfiscal ei join saidafiscal e on ei.saidafiscal=e.id where datasaida < dataMaxima
	UNION
	select ei.referencia, e.data, -1*ei.quantidade from entradaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < dataMaxima
	UNION
	select ei.referencia, e.data, ei.quantidade from saidaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < dataMaxima
) i on i.referencia=m.referencia left join novosPrecos p on m.referencia=p.mercadoria
group by m.referencia;
END$$

DELIMITER ;

CREATE VIEW `inventario_interno` AS
	select ei.referencia, e.dataentrada as data,  ei.quantidade from entradaitemfiscal ei join entradafiscal e on ei.entradafiscal=e.id
	UNION
	select ei.referencia, e.datasaida as data, -1*ei.quantidade from saidaitemfiscal ei join saidafiscal e on ei.saidafiscal=e.id
	UNION
	select ei.referencia, e.data, -1*ei.quantidade from entradaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo
	UNION
	select ei.referencia, e.data, ei.quantidade from saidaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo;


  USE `imjoias`;
  CREATE  OR REPLACE VIEW `inventario_total` AS
  select m.referencia, sum(ifnull(quantidade,0)) as quantidade, m.nome, m.classificacaofiscal, m.tipounidade, p.novoPrecoCusto as valor, sum(ifnull(quantidade,0))*p.novoPrecoCusto as valortotal from
  mercadoria m left join inventario_interno i on i.referencia=m.referencia left join novosPrecos p on m.referencia=p.mercadoria
  group by m.referencia;


update mercadoria set classificacaofiscal='7113190100' where classificacaofiscal is null;

  create function d1() returns DATETIME DETERMINISTIC NO SQL return @d1;

  CREATE VIEW `inventario_interno_parcial` AS
  	select ei.referencia, e.dataentrada as data,  ei.quantidade from entradaitemfiscal ei join entradafiscal e on ei.entradafiscal=e.id where dataentrada < d1()
  	UNION
  	select ei.referencia, e.datasaida as data, -1*ei.quantidade from saidaitemfiscal ei join saidafiscal e on ei.saidafiscal=e.id where datasaida < d1()
  	UNION
  	select ei.referencia, e.data, -1*ei.quantidade from entradaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < d1()
  	UNION
  	select ei.referencia, e.data, ei.quantidade from saidaproducaofiscal ei join producaofiscal e on ei.producaofiscal=e.codigo where data < d1();


    USE `imjoias`;
    CREATE  OR REPLACE VIEW `inventario_parcial` AS
    select m.referencia, sum(ifnull(quantidade,0)) as quantidade, m.nome, m.classificacaofiscal, m.tipounidade, p.novoPrecoCusto as valor, sum(ifnull(quantidade,0))*p.novoPrecoCusto as valortotal from
    mercadoria m left join inventario_interno_parcial i on i.referencia=m.referencia left join novosPrecos p on m.referencia=p.mercadoria
    group by m.referencia;

DROP procedure IF EXISTS `inventario`;

    DELIMITER $$
    USE `imjoias`$$
    CREATE DEFINER=`root`@`localhost` PROCEDURE `inventario`(IN dataMaxima DATETIME)
    BEGIN
    END$$

    select i.* from (select @d1:=dataMaxima p) parm, inventario_parcial i;
    DELIMITER ;

    ALTER TABLE `imjoias`.`estoquelegado`
    CHANGE COLUMN `estoque1` `estoque1` DECIMAL(10,2) NOT NULL ,
    CHANGE COLUMN `estoque2` `estoque2` DECIMAL(10,2) NOT NULL ,
    CHANGE COLUMN `estoque3` `estoque3` DECIMAL(10,2) NOT NULL ,
    CHANGE COLUMN `estoqueanterior` `estoqueanterior` DECIMAL(10,2) NOT NULL ;
