
ALTER TABLE `imjoias`.`saidafabricacaofiscal`
ADD COLUMN `codigo` INT NOT NULL AUTO_INCREMENT AFTER `referencia`,
ADD PRIMARY KEY (`codigo`);

ALTER TABLE `imjoias`.`entradafabricacaofiscal`
ADD COLUMN `codigo` INT NOT NULL AUTO_INCREMENT AFTER `referencia`,
ADD PRIMARY KEY (`codigo`);

ALTER TABLE `imjoias`.`saidafabricacaofiscal`
CHANGE COLUMN `codigo` `codigo` INT(11) NOT NULL AUTO_INCREMENT FIRST;


ALTER TABLE `imjoias`.`entradafabricacaofiscal`
CHANGE COLUMN `codigo` `codigo` INT(11) NOT NULL AUTO_INCREMENT FIRST;

ALTER TABLE `imjoias`.`saidafabricacaofiscal`
ADD COLUMN `valor` DECIMAL(8,2) NOT NULL AFTER `referencia`;


ALTER TABLE `imjoias`.`entradafabricacaofiscal`
ADD COLUMN `valor` DECIMAL(8,2) NOT NULL AFTER `referencia`;

ALTER TABLE `imjoias`.`saidafabricacaofiscal`
DROP FOREIGN KEY `fk_saidaproducaofiscal_2`;
ALTER TABLE `imjoias`.`saidafabricacaofiscal`
DROP INDEX `fk_saidafabricacaofiscal_referencia` ;

ALTER TABLE `imjoias`.`entradafabricacaofiscal`
DROP FOREIGN KEY `fk_entradaproducaofiscal_2`;
ALTER TABLE `imjoias`.`entradafabricacaofiscal`
DROP INDEX `fk_entradafabricacaofiscal_referencia` ;

delete from entradafabricacaofiscal;

ALTER TABLE `imjoias`.`entradafabricacaofiscal`
ADD CONSTRAINT `fk_entradafabricacaofiscal_fabricacao`
  FOREIGN KEY (`fabricacaofiscal`)
  REFERENCES `imjoias`.`fabricacaofiscal` (`codigo`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


  USE `imjoias`;
  CREATE
       OR REPLACE ALGORITHM = UNDEFINED
      DEFINER = `root`@`localhost`
      SQL SECURITY DEFINER
  VIEW `extratoinventario` AS
      SELECT
          `e`.`tipo` AS `tipodocumento`,
          'E' AS `tipoextrato`,
          `ei`.`referencia` AS `referencia`,
          `e`.`dataentrada` AS `data`,
          `ei`.`quantidade` AS `quantidade`,
          `ei`.`valor` AS `valor`
      FROM
          (`entradaitemfiscal` `ei`
          JOIN `entradafiscal` `e` ON ((`ei`.`entradafiscal` = `e`.`id`)))
      WHERE
          (`e`.`dataentrada` < NOW())
      UNION SELECT
          `e`.`tipo` AS `tipodocumento`,
          'S' AS `tipoextrato`,
          `ei`.`referencia` AS `referencia`,
          `e`.`datasaida` AS `data`,
          (-(1) * `ei`.`quantidade`) AS `-1*ei.quantidade`,
          `ei`.`valor` AS `valor`
      FROM
          (`saidaitemfiscal` `ei`
          JOIN `saidafiscal` `e` ON ((`ei`.`saidafiscal` = `e`.`id`)))
      WHERE
          (`e`.`datasaida` < NOW())
      UNION SELECT
          NULL AS `tipodocumento`,
          'OT' AS `tipoextrato`,
          `ei`.`referencia` AS `referencia`,
          `e`.`data` AS `data`,
          (-(1) * `ei`.`quantidade`) AS `-1*ei.quantidade`,
          ei.valor AS `valor`
      FROM
          (`entradafabricacaofiscal` `ei`
          JOIN `fabricacaofiscal` `e` ON ((`ei`.`fabricacaofiscal` = `e`.`codigo`)))
      WHERE
          (`e`.`data` < NOW())
      UNION SELECT
          NULL AS `tipodocumento`,
          'TO' AS `tipoextrato`,
          `ei`.`referencia` AS `referencia`,
          `e`.`data` AS `data`,
          `ei`.`quantidade` AS `quantidade`,
  		ei.valor AS `valor`
      FROM
          (`saidafabricacaofiscal` `ei`
          JOIN `fabricacaofiscal` `e` ON ((`ei`.`fabricacaofiscal` = `e`.`codigo`)))
      WHERE
          (`e`.`data` < NOW());
