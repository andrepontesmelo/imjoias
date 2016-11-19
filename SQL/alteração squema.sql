use imjoias;

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

CREATE TABLE `imjoias`.`materiaprima` (
  `referencia` VARCHAR(11) NOT NULL,
  PRIMARY KEY (`referencia`),
  CONSTRAINT `fk_materiaprima_referencia`
    FOREIGN KEY (`referencia`)
    REFERENCES `imjoias`.`mercadoria` (`referencia`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

ALTER TABLE `imjoias`.`materiaprima`
ADD COLUMN `valor` DECIMAL(8,2) NOT NULL AFTER `referencia`;

insert into materiaprima(referencia,valor) select referencia, 0 as valor from mercadoria where referencia like '9%';

  USE `imjoias`;
  CREATE
       OR REPLACE ALGORITHM = UNDEFINED
      DEFINER = `root`@`localhost`
      SQL SECURITY DEFINER
  VIEW `inventario_parcial` AS
     SELECT
          `m`.`referencia` AS `referencia`,
          SUM(IFNULL(`i`.`quantidade`, 0)) AS `quantidade`,
          `m`.`nome` AS `nome`,
          `m`.`classificacaofiscal` AS `classificacaofiscal`,
          `m`.`tipounidade` AS `tipounidade`,
  		ifnull(a.valor, `p`.`novoPrecoCusto`) AS `valor`,
          (SUM(IFNULL(`i`.`quantidade`, 0)) * ifnull(a.valor, `p`.`novoPrecoCusto`)) AS `valortotal`
      FROM
          ((`mercadoria` `m`
          LEFT JOIN materiaprima a on a.referencia=m.referencia
          LEFT JOIN `inventario_interno_parcial` `i` ON ((`i`.`referencia` = `m`.`referencia`)))
          LEFT JOIN `novosPrecos` `p` ON ((`m`.`referencia` = `p`.`mercadoria`)))
      GROUP BY `m`.`referencia`;
