Alterações de SQL's


RENAME TABLE imjoias.vendafiscal TO imjoias.saidafiscal;



ALTER TABLE imjoias.saidafiscal CHANGE tipovenda tiposaida varchar(1) NOT NULL;


RENAME TABLE imjoias.vendaitemfiscal TO imjoias.saidaitemfiscal;


ALTER TABLE imjoias.saidaitemfiscal CHANGE vendafiscal saidafiscal varchar(49) NULL;



