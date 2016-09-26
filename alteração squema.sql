Alterações de SQL's


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




