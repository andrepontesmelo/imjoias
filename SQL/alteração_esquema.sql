CREATE TABLE `imjoias`.`fechamento` (
  `codigo` INT NOT NULL,
  `inicio` DATETIME NOT NULL,
  `fim` DATETIME NOT NULL,
  `fechado` TINYINT NOT NULL,
  PRIMARY KEY (`codigo`));

ALTER TABLE `imjoias`.`fechamento` 
CHANGE COLUMN `codigo` `codigo` INT(11) NOT NULL AUTO_INCREMENT ;

USE `imjoias`;
CREATE  OR REPLACE VIEW `mercadoria_fiscal` AS
SELECT 
        `m`.`referencia` AS `referencia`,
        `m`.`nome` AS `nome`,
        `m`.`classificacaofiscal` AS `classificacaofiscal`,
        IFNULL(`a`.`valor`, `p`.`novoPrecoCusto`) AS `valor`
    FROM
        `imjoias`.`mercadoria` `m`
        LEFT JOIN `imjoias`.`materiaprima` `a` ON `a`.`referencia` = `m`.`referencia`
        LEFT JOIN `imjoias`.`novosPrecos` `p` ON `m`.`referencia` = `p`.`mercadoria`;

CREATE TABLE `imjoias`.`mercadoriafechamento` (
  `mercadoria` VARCHAR(11) NOT NULL,
  `descricao` VARCHAR(100) NULL,
  `precocusto` DECIMAL(8,2) NULL,
  `fechamento` INT NOT NULL);

ALTER TABLE `imjoias`.`mercadoriafechamento` 
ADD UNIQUE INDEX `idx_mercadoriafechamento_unica` (`mercadoria` ASC, `fechamento` ASC);



ALTER TABLE `imjoias`.`mercadoriafechamento` 
ADD INDEX `fk_mercadoriafechamento_fechamento_idx` (`fechamento` ASC);
ALTER TABLE `imjoias`.`mercadoriafechamento` 
ADD CONSTRAINT `fk_mercadoriafechamento_fechamento`
  FOREIGN KEY (`fechamento`)
  REFERENCES `imjoias`.`fechamento` (`codigo`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;

ALTER TABLE `imjoias`.`mercadoriafechamento` 
CHANGE COLUMN `mercadoria` `referencia` VARCHAR(11) NOT NULL ;

ALTER TABLE `imjoias`.`mercadoriafechamento` 
CHANGE COLUMN `precocusto` `valor` DECIMAL(8,2) NULL DEFAULT NULL ;

USE `imjoias`;
CREATE 
     OR REPLACE ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `mercadoria_fiscal` AS
    SELECT 
        `m`.`referencia` AS `referencia`,
        `m`.`nome` AS `descricao`,
        IFNULL(`a`.`valor`, `p`.`novoPrecoCusto`) AS `valor`
    FROM
        ((`mercadoria` `m`
        LEFT JOIN `materiaprima` `a` ON ((`a`.`referencia` = `m`.`referencia`)))
        LEFT JOIN `novosPrecos` `p` ON ((`m`.`referencia` = `p`.`mercadoria`)));

USE `imjoias`;
DROP procedure IF EXISTS `atualizarfechamento`;

DELIMITER $$
USE `imjoias`$$
CREATE PROCEDURE `atualizarfechamento` (codigoFechamento INTEGER UNSIGNED)
BEGIN
	start transaction;
	delete from mercadoriafechamento where fechamento=codigoFechamento;
	insert into mercadoriafechamento(referencia, descricao, valor, fechamento) select m.*, codigoFechamento as fechamento from mercadoria_fiscal m;
	commit;
END$$

DELIMITER ;


