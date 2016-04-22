-- MySQL dump 10.13  Distrib 5.7.12, for Linux (x86_64)
--
-- Host: localhost    Database: imjoias
-- ------------------------------------------------------
-- Server version	5.6.28-0ubuntu0.14.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `acertoconsignado`
--

DROP TABLE IF EXISTS `acertoconsignado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acertoconsignado` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cliente` int(10) unsigned NOT NULL,
  `funcConsignado` int(10) unsigned NOT NULL COMMENT 'Funcionario que registrou \r\n\r\no consignado e marcou o acerto.',
  `funcAcerto` int(10) unsigned DEFAULT NULL COMMENT 'Funcionario que realizou o acerto com o \r\n\r\ncliente.',
  `previsao` datetime DEFAULT NULL,
  `dataEfetiva` datetime DEFAULT NULL,
  `dataMarcacao` datetime NOT NULL,
  `cotacao` double DEFAULT NULL,
  `formulaAcerto` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `Index_AcertoConsignado_Previsao` (`previsao`),
  KEY `Index_DataEfetiva` (`dataEfetiva`),
  KEY `fk_acertoconsignado_1` (`cliente`),
  KEY `fk_acertoconsignado_2_idx` (`funcConsignado`),
  KEY `fk_acertoconsignado_3_idx` (`funcAcerto`),
  CONSTRAINT `fk_acertoconsignado_1` FOREIGN KEY (`cliente`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_acertoconsignado_2` FOREIGN KEY (`funcConsignado`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_acertoconsignado_3` FOREIGN KEY (`funcAcerto`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19811 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agenda`
--

DROP TABLE IF EXISTS `agenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agenda` (
  `nome` varchar(100) NOT NULL,
  `telfixo` varchar(45) NOT NULL,
  `telcelular` varchar(45) NOT NULL,
  `teloutro` varchar(45) NOT NULL,
  `endcidade` varchar(45) NOT NULL,
  `endestado` varchar(45) NOT NULL,
  `palavraschave` varchar(100) NOT NULL,
  PRIMARY KEY (`nome`),
  KEY `Index_agenda_palavraschave` (`palavraschave`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agendamento` (
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `descricao` tinytext NOT NULL,
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `alarme` datetime DEFAULT '0000-00-00 00:00:00',
  `funcionario` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `IDX_Agendamento_Data` (`data`),
  KEY `IDX_Agentamento_Alarme` (`alarme`),
  KEY `fk_agendamento_1_idx` (`funcionario`),
  CONSTRAINT `fk_agendamento_1` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6715 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `album`
--

DROP TABLE IF EXISTS `album`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `album` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `criacao` datetime NOT NULL,
  `alteracao` datetime DEFAULT NULL,
  `descricao` text NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `IDX_ALBUM_NOME` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=273 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `balanco`
--

DROP TABLE IF EXISTS `balanco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `balanco` (
  `referencia` varchar(15) NOT NULL,
  `digito` varchar(45) NOT NULL,
  `peso` double NOT NULL,
  `indice` double NOT NULL,
  `saida` double NOT NULL,
  `retorno` double NOT NULL,
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `venda` double NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=176515 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bug`
--

DROP TABLE IF EXISTS `bug`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bug` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `primeiraData` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `ultimaData` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `ocorrencias` int(11) DEFAULT NULL,
  `message` text,
  `targetsite` varchar(600) DEFAULT '',
  `source` varchar(255) DEFAULT '',
  `stacktrace` text,
  `corrigido` tinyint(1) DEFAULT '0',
  `correcaoAutor` varchar(250) DEFAULT NULL,
  `correcaoData` datetime DEFAULT NULL,
  `correcaoComentarios` text,
  `ignorar` tinyint(1) DEFAULT '0',
  `innerException` text,
  PRIMARY KEY (`codigo`),
  KEY `Index_bug_ultimadata` (`ultimaData`),
  KEY `index_bug` (`targetsite`,`source`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=14440 DEFAULT CHARSET=latin1 COMMENT='relatório de erros';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `bugs_pendentes`
--

DROP TABLE IF EXISTS `bugs_pendentes`;
/*!50001 DROP VIEW IF EXISTS `bugs_pendentes`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `bugs_pendentes` AS SELECT 
 1 AS `codigo`,
 1 AS `primeiraData`,
 1 AS `ultimaData`,
 1 AS `ocorrencias`,
 1 AS `message`,
 1 AS `targetsite`,
 1 AS `source`,
 1 AS `stacktrace`,
 1 AS `corrigido`,
 1 AS `correcaoAutor`,
 1 AS `correcaoData`,
 1 AS `correcaoComentarios`,
 1 AS `ignorar`,
 1 AS `innerException`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `cep`
--

DROP TABLE IF EXISTS `cep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cep` (
  `cep` char(9) NOT NULL,
  `localidade` int(10) unsigned NOT NULL,
  `logradouro` varchar(255) DEFAULT NULL,
  `bairro` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`cep`),
  KEY `FK_cep_localidade` (`localidade`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED COMMENT='InnoDB free: 280576 kB; (`localidade`) REFER `imjoias/locali';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cheque`
--

DROP TABLE IF EXISTS `cheque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cheque` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `vencimento` datetime NOT NULL DEFAULT '2001-01-01 00:00:00',
  `cpf` varchar(45) DEFAULT NULL,
  `deTerceiro` tinyint(1) NOT NULL,
  `prorrogadopara` datetime DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `cheque_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=222883 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `classpessoa`
--

DROP TABLE IF EXISTS `classpessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classpessoa` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `denominacao` varchar(50) NOT NULL DEFAULT '',
  `criacao` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `questionarAntigos` tinyint(1) NOT NULL DEFAULT '0',
  `msgMarcando` varchar(255) DEFAULT NULL,
  `msgDesmarcando` varchar(255) DEFAULT NULL,
  `alertarVenda` tinyint(1) NOT NULL DEFAULT '0',
  `alertarSaida` tinyint(1) NOT NULL DEFAULT '0',
  `alertarCorreio` tinyint(1) NOT NULL DEFAULT '0',
  `alertarPedido` tinyint(1) NOT NULL DEFAULT '0',
  `sistema` tinyint(1) NOT NULL,
  `exigirPrivilegios` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_CLASSPESSOA_DENOMINACAO` (`denominacao`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=latin1 COMMENT='Classificação de pessoas';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `comissao`
--

DROP TABLE IF EXISTS `comissao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comissao` (
  `codigo` int(10) NOT NULL AUTO_INCREMENT,
  `descricao` text,
  `pago` tinyint(1) NOT NULL DEFAULT '0',
  `mes` date NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `comissao_qtdestorno`
--

DROP TABLE IF EXISTS `comissao_qtdestorno`;
/*!50001 DROP VIEW IF EXISTS `comissao_qtdestorno`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comissao_qtdestorno` AS SELECT 
 1 AS `venda`,
 1 AS `pessoa`,
 1 AS `qtdEstorno`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `comissao_qtdvenda`
--

DROP TABLE IF EXISTS `comissao_qtdvenda`;
/*!50001 DROP VIEW IF EXISTS `comissao_qtdvenda`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comissao_qtdvenda` AS SELECT 
 1 AS `venda`,
 1 AS `pessoa`,
 1 AS `qtdVenda`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `comissao_saldo`
--

DROP TABLE IF EXISTS `comissao_saldo`;
/*!50001 DROP VIEW IF EXISTS `comissao_saldo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comissao_saldo` AS SELECT 
 1 AS `venda`,
 1 AS `pessoa`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `comissao_semaforo`
--

DROP TABLE IF EXISTS `comissao_semaforo`;
/*!50001 DROP VIEW IF EXISTS `comissao_semaforo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comissao_semaforo` AS SELECT 
 1 AS `venda`,
 1 AS `semaforo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `comissao_semaforo_multiplo`
--

DROP TABLE IF EXISTS `comissao_semaforo_multiplo`;
/*!50001 DROP VIEW IF EXISTS `comissao_semaforo_multiplo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comissao_semaforo_multiplo` AS SELECT 
 1 AS `venda`,
 1 AS `semaforo`,
 1 AS `descricao`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `comissao_valor`
--

DROP TABLE IF EXISTS `comissao_valor`;
/*!50001 DROP VIEW IF EXISTS `comissao_valor`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comissao_valor` AS SELECT 
 1 AS `cliente`,
 1 AS `vendedor`,
 1 AS `comissaopara`,
 1 AS `venda`,
 1 AS `vendaitem`,
 1 AS `vendadevolucao`,
 1 AS `referencia`,
 1 AS `faixa`,
 1 AS `setor`,
 1 AS `tipo`,
 1 AS `regra`,
 1 AS `valorc`,
 1 AS `valorv`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `comissao_venda`
--

DROP TABLE IF EXISTS `comissao_venda`;
/*!50001 DROP VIEW IF EXISTS `comissao_venda`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `comissao_venda` AS SELECT 
 1 AS `cliente`,
 1 AS `vendedor`,
 1 AS `comissaopara`,
 1 AS `venda`,
 1 AS `setor`,
 1 AS `tipo`,
 1 AS `regra`,
 1 AS `valorc`,
 1 AS `valorv`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `comissaoestornovenda`
--

DROP TABLE IF EXISTS `comissaoestornovenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comissaoestornovenda` (
  `venda` int(10) unsigned NOT NULL,
  `comissao` int(10) NOT NULL,
  `pessoa` int(10) unsigned NOT NULL,
  PRIMARY KEY (`venda`,`comissao`,`pessoa`),
  KEY `fk_comissaoestornovenda_2` (`comissao`),
  KEY `fk_comissaoestornovenda_3_idx` (`pessoa`),
  KEY `fk_comissaoestornovenda_4_idx` (`comissao`,`pessoa`),
  CONSTRAINT `fk_comissaoestornovenda_1` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_comissaoestornovenda_2` FOREIGN KEY (`comissao`) REFERENCES `comissao` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_comissaoestornovenda_3` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `comissaosetorfaixa`
--

DROP TABLE IF EXISTS `comissaosetorfaixa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comissaosetorfaixa` (
  `setor` int(10) unsigned NOT NULL,
  `faixa` varchar(1) NOT NULL,
  `valor` double DEFAULT NULL,
  PRIMARY KEY (`setor`,`faixa`),
  CONSTRAINT `fk_comissaosetorfaixa_1` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `comissaovenda`
--

DROP TABLE IF EXISTS `comissaovenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comissaovenda` (
  `venda` int(10) unsigned NOT NULL,
  `comissao` int(10) NOT NULL,
  `pessoa` int(10) unsigned NOT NULL,
  PRIMARY KEY (`venda`,`comissao`,`pessoa`),
  KEY `fk_comissaovenda_2` (`comissao`),
  KEY `fk_comissaovenda_3_idx` (`pessoa`),
  KEY `fk_comissaovenda_4_idx` (`comissao`,`pessoa`),
  CONSTRAINT `fk_comissaovenda_1` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_comissaovenda_2` FOREIGN KEY (`comissao`) REFERENCES `comissao` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_comissaovenda_3` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `componentecusto`
--

DROP TABLE IF EXISTS `componentecusto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `componentecusto` (
  `codigo` varchar(10) NOT NULL DEFAULT '',
  `nome` varchar(50) NOT NULL DEFAULT '',
  `multiplicarcomponentecusto` varchar(10) DEFAULT NULL,
  `valor` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `componentecusto_valorfinal`
--

DROP TABLE IF EXISTS `componentecusto_valorfinal`;
/*!50001 DROP VIEW IF EXISTS `componentecusto_valorfinal`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `componentecusto_valorfinal` AS SELECT 
 1 AS `codigo`,
 1 AS `valorfinal`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `config-globais`
--

DROP TABLE IF EXISTS `config-globais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `config-globais` (
  `chave` varchar(255) NOT NULL,
  `valor` varchar(255) NOT NULL,
  PRIMARY KEY (`chave`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `configuracoes`
--

DROP TABLE IF EXISTS `configuracoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `configuracoes` (
  `chave` varchar(255) NOT NULL DEFAULT '',
  `valor` varchar(255) NOT NULL DEFAULT '',
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`chave`,`pessoa`),
  KEY `fk_configuracoes_1_idx` (`pessoa`),
  CONSTRAINT `fk_configuracoes_1` FOREIGN KEY (`pessoa`) REFERENCES `funcionario` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cotacao`
--

DROP TABLE IF EXISTS `cotacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cotacao` (
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `valor` double NOT NULL DEFAULT '0',
  `funcionario` int(10) unsigned NOT NULL DEFAULT '0',
  `moeda` int(10) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`data`,`moeda`),
  KEY `fk_cotacao_1_idx` (`moeda`),
  KEY `fk_cotacao_2_idx` (`funcionario`),
  CONSTRAINT `fk_cotacao_1` FOREIGN KEY (`moeda`) REFERENCES `moeda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_cotacao_2` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `credito`
--

DROP TABLE IF EXISTS `credito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `credito` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pessoa` int(10) unsigned NOT NULL,
  `valor` double NOT NULL,
  `data` datetime NOT NULL,
  `descricao` tinytext NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_credito_1_idx` (`pessoa`),
  CONSTRAINT `fk_credito_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1251 DEFAULT CHARSET=latin1 COMMENT='gasto nesta venda';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `devedores`
--

DROP TABLE IF EXISTS `devedores`;
/*!50001 DROP VIEW IF EXISTS `devedores`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `devedores` AS SELECT 
 1 AS `codigo`,
 1 AS `nome`,
 1 AS `sum(valor)`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `dinheiro`
--

DROP TABLE IF EXISTS `dinheiro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dinheiro` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `dinheiro_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=222890 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dolar`
--

DROP TABLE IF EXISTS `dolar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dolar` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `valorEmDolar` double NOT NULL,
  `cotacao` double NOT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `dolar_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=222747 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS `endereco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `endereco` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `id` smallint(5) unsigned NOT NULL DEFAULT '0',
  `descricao` varchar(45) NOT NULL DEFAULT '',
  `logradouro` varchar(100) NOT NULL DEFAULT '',
  `cep` varchar(15) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `numero` varchar(10) DEFAULT NULL,
  `complemento` varchar(45) DEFAULT NULL,
  `localidade` int(10) unsigned NOT NULL DEFAULT '0',
  `observacoes` text,
  PRIMARY KEY (`pessoa`,`id`),
  KEY `fk_endereco_2_idx` (`localidade`),
  CONSTRAINT `fk_endereco_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_endereco_2` FOREIGN KEY (`localidade`) REFERENCES `localidade` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `entrada`
--

DROP TABLE IF EXISTS `entrada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entrada` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `digitadopor` int(10) unsigned NOT NULL,
  `observacoes` tinytext NOT NULL,
  `tabela` int(10) unsigned NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_entrada_1_idx` (`digitadopor`),
  KEY `fk_entrada_2_idx` (`tabela`),
  CONSTRAINT `fk_entrada_1` FOREIGN KEY (`digitadopor`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_entrada_2` FOREIGN KEY (`tabela`) REFERENCES `tabela` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `entradaitem`
--

DROP TABLE IF EXISTS `entradaitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entradaitem` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `funcionario` int(10) unsigned NOT NULL,
  `referencia` varchar(11) NOT NULL,
  `peso` double NOT NULL,
  `quantidade` double NOT NULL,
  `entrada` int(10) unsigned NOT NULL,
  `indice` double NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_entradaitem_1_idx` (`funcionario`),
  KEY `fk_entradaitem_3_idx` (`referencia`),
  KEY `fk_entradaitem_2_idx` (`entrada`),
  CONSTRAINT `fk_entradaitem_1` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_entradaitem_3` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14226 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `estado`
--

DROP TABLE IF EXISTS `estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estado` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL DEFAULT '',
  `sigla` varchar(10) DEFAULT NULL,
  `pais` int(10) unsigned NOT NULL DEFAULT '0',
  `regiao` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_Estado_Nome` (`nome`,`pais`),
  KEY `FK_estado_pais` (`pais`),
  KEY `FK_estado_regiao` (`regiao`),
  CONSTRAINT `fk_estado_1` FOREIGN KEY (`regiao`) REFERENCES `regiao` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=latin1 COMMENT='Endereço: Estado';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `estoque_extrato`
--

DROP TABLE IF EXISTS `estoque_extrato`;
/*!50001 DROP VIEW IF EXISTS `estoque_extrato`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `estoque_extrato` AS SELECT 
 1 AS `data`,
 1 AS `nome`,
 1 AS `referencia`,
 1 AS `peso`,
 1 AS `entrada`,
 1 AS `venda`,
 1 AS `devolucao`,
 1 AS `operacao`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `estoque_saldo`
--

DROP TABLE IF EXISTS `estoque_saldo`;
/*!50001 DROP VIEW IF EXISTS `estoque_saldo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `estoque_saldo` AS SELECT 
 1 AS `referencia`,
 1 AS `peso`,
 1 AS `entrada`,
 1 AS `venda`,
 1 AS `devolucao`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `etiquetaformato`
--

DROP TABLE IF EXISTS `etiquetaformato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `etiquetaformato` (
  `formato` varchar(50) NOT NULL DEFAULT '',
  `autor` varchar(100) NOT NULL DEFAULT '',
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `configuracao` text NOT NULL,
  PRIMARY KEY (`formato`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `etiquetamercadoria`
--

DROP TABLE IF EXISTS `etiquetamercadoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `etiquetamercadoria` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `formato` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`referencia`),
  KEY `IDX_EtiquetaMercadoria_Formato` (`formato`),
  CONSTRAINT `fk_etiquetamercadoria_1` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `faixa`
--

DROP TABLE IF EXISTS `faixa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faixa` (
  `faixa` char(1) NOT NULL DEFAULT '',
  `setor` int(10) unsigned NOT NULL DEFAULT '0',
  `valor` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`faixa`,`setor`),
  KEY `IDX_Faixa_Faixa` (`faixa`),
  KEY `fk_faixa_1_idx` (`setor`),
  CONSTRAINT `fk_faixa_1` FOREIGN KEY (`setor`) REFERENCES `tabela` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fiscal_cfop`
--

DROP TABLE IF EXISTS `fiscal_cfop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fiscal_cfop` (
  `codigo` int(11) NOT NULL,
  `descricao` varchar(473) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fiscal_municipioibge`
--

DROP TABLE IF EXISTS `fiscal_municipioibge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fiscal_municipioibge` (
  `localidade` int(10) unsigned NOT NULL,
  `codigo` int(10) unsigned NOT NULL,
  PRIMARY KEY (`localidade`,`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fornecedor`
--

DROP TABLE IF EXISTS `fornecedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedor` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL DEFAULT '',
  `comentarios` text,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_FORNECEDOR_NOME` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `foto`
--

DROP TABLE IF EXISTS `foto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
) ENGINE=MyISAM AUTO_INCREMENT=8575 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `funcionario` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `empresa` int(10) unsigned NOT NULL DEFAULT '0',
  `ficha` int(11) DEFAULT NULL,
  `salario` double DEFAULT NULL,
  `cargo` varchar(50) DEFAULT '',
  `carteiraProfissional` varchar(30) DEFAULT NULL,
  `carteiraProfissionalSerie` varchar(20) DEFAULT NULL,
  `reservista` varchar(30) DEFAULT NULL,
  `reservistaSerie` varchar(20) DEFAULT NULL,
  `reservistaCategoria` varchar(20) DEFAULT NULL,
  `dataAdmissao` date DEFAULT '0000-00-00',
  `dataSaida` date DEFAULT NULL,
  `pis` varchar(30) DEFAULT NULL,
  `cbo` varchar(100) DEFAULT NULL,
  `tituloEleitor` varchar(30) DEFAULT NULL,
  `ramal` smallint(5) DEFAULT NULL,
  `rodizio` int(3) unsigned DEFAULT NULL,
  `beneficiario` varchar(100) DEFAULT NULL,
  `beneficiarioParentesco` varchar(20) DEFAULT NULL,
  `usuario` varchar(20) DEFAULT NULL,
  `privilegios` int(10) unsigned NOT NULL DEFAULT '0',
  `contextoEstado` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `IDX_Funcionario_Empresa` (`empresa`),
  KEY `idx_funcionario_dataSaida` (`dataSaida`),
  KEY `idx_funcionario_usuario` (`usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `geracaoprecosdolar`
--

DROP TABLE IF EXISTS `geracaoprecosdolar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `geracaoprecosdolar` (
  `data` datetime NOT NULL,
  `funcionario` int(10) unsigned NOT NULL,
  `valor` decimal(10,0) NOT NULL,
  KEY `dolarGeracaoPrecos_funcionario_FK` (`funcionario`),
  KEY `dolarGeracaoPrecos_data_IDX` (`data`),
  CONSTRAINT `dolarGeracaoPrecos_funcionario_FK` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `geracaoprecosjuros`
--

DROP TABLE IF EXISTS `geracaoprecosjuros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `geracaoprecosjuros` (
  `data` date DEFAULT NULL,
  `juros` double DEFAULT NULL,
  `multiplicador` double DEFAULT NULL,
  KEY `geracaoprecosjuros_data_IDX` (`data`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `grama`
--

DROP TABLE IF EXISTS `grama`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grama` (
  `tabela` int(10) unsigned NOT NULL,
  `faixa` char(1) NOT NULL,
  `grupo` smallint(6) NOT NULL,
  `valor` decimal(8,4) NOT NULL,
  UNIQUE KEY `grama_idx` (`tabela`,`faixa`,`grupo`),
  KEY `grama_faixa_FK` (`faixa`),
  CONSTRAINT `grama_faixa_FK` FOREIGN KEY (`faixa`) REFERENCES `faixa` (`faixa`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `grama_faixa_FK_tabela` FOREIGN KEY (`tabela`) REFERENCES `tabela` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `grupopessoa`
--

DROP TABLE IF EXISTS `grupopessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupopessoa` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `grupo` varchar(50) NOT NULL DEFAULT '',
  `flags` int(10) unsigned NOT NULL DEFAULT '0',
  `descricao` tinytext,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_Grupo` (`grupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `historico`
--

DROP TABLE IF EXISTS `historico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `historico` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `digitadoPor` int(10) unsigned DEFAULT NULL,
  `texto` longtext NOT NULL,
  `alertarVenda` tinyint(1) NOT NULL DEFAULT '0',
  `alertarPedido` tinyint(1) NOT NULL DEFAULT '0',
  `alertarSaida` tinyint(1) NOT NULL DEFAULT '0',
  `alertarCorreio` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`pessoa`,`data`),
  CONSTRAINT `fk_historico_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='Histórico das pessoas';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `horariofuncionario`
--

DROP TABLE IF EXISTS `horariofuncionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `horariofuncionario` (
  `funcionario` int(10) unsigned NOT NULL DEFAULT '0',
  `diaSemana` smallint(5) unsigned NOT NULL DEFAULT '0',
  `iniHora` smallint(5) unsigned NOT NULL DEFAULT '0',
  `iniMinuto` smallint(5) unsigned NOT NULL DEFAULT '0',
  `fimHora` smallint(5) unsigned NOT NULL DEFAULT '0',
  `fimMinuto` smallint(5) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`funcionario`,`diaSemana`,`iniHora`,`iniMinuto`),
  CONSTRAINT `fk_horariofuncionario_1` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `localidade`
--

DROP TABLE IF EXISTS `localidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `localidade` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL DEFAULT '',
  `estado` int(10) unsigned NOT NULL DEFAULT '0',
  `tipo` smallint(5) unsigned NOT NULL DEFAULT '0',
  `ddd` int(10) unsigned DEFAULT NULL,
  `regiao` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_LOCALIDADE_nome` (`nome`,`estado`),
  KEY `FK_localidade_estado` (`estado`),
  KEY `fk_localidade_2_idx` (`regiao`),
  CONSTRAINT `fk_localidade_1` FOREIGN KEY (`estado`) REFERENCES `estado` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_localidade_2` FOREIGN KEY (`regiao`) REFERENCES `regiao` (`codigo`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10085 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED COMMENT='Endereço: Localidade';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `mercadoria`
--

DROP TABLE IF EXISTS `mercadoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mercadoria` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `nome` varchar(100) DEFAULT NULL,
  `teor` int(11) DEFAULT NULL,
  `peso` double DEFAULT NULL,
  `faixa` char(1) DEFAULT NULL,
  `grupo` int(11) DEFAULT NULL,
  `digito` tinyint(1) unsigned DEFAULT NULL,
  `foradelinha` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `depeso` tinyint(1) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`referencia`),
  KEY `IDX_Mercadoria_Faixa` (`faixa`),
  KEY `idx_mercadoria_peso` (`peso`),
  KEY `idx_mercadoria_digito` (`digito`),
  KEY `idx_mercadoria_foradelinha` (`foradelinha`),
  KEY `idx_mercadoria_depeso` (`depeso`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `mercadoriaalteracao`
--

DROP TABLE IF EXISTS `mercadoriaalteracao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mercadoriaalteracao` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `nome` varchar(100) DEFAULT NULL,
  `teor` int(11) DEFAULT NULL,
  `peso` double DEFAULT NULL,
  `faixa` char(1) DEFAULT NULL,
  `grupo` int(11) DEFAULT NULL,
  `digito` tinyint(4) DEFAULT NULL,
  `foradelinha` tinyint(4) DEFAULT NULL,
  `depeso` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`referencia`),
  KEY `IDX_mercadoriaalteracao_Faixa` (`faixa`),
  KEY `IDX_mercadoriaalteracao_ForaDeLinha` (`foradelinha`),
  KEY `IDX_mercadoriaalteracao_DePeso` (`depeso`),
  KEY `IDX_mercadoriaalteracao_Digito` (`digito`),
  KEY `IDX_mercadoriaalteracao_Grupo` (`grupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `mercadoriamapeamento`
--

DROP TABLE IF EXISTS `mercadoriamapeamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mercadoriamapeamento` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `codigo` int(11) NOT NULL DEFAULT '0',
  `obsoleto` tinyint(1) NOT NULL DEFAULT '0',
  `peso` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`,`peso`),
  KEY `IDX_MercadoriaMapeamento_Referencia` (`referencia`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `mercadoriapedra`
--

DROP TABLE IF EXISTS `mercadoriapedra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mercadoriapedra` (
  `codigo` char(2) NOT NULL,
  `pedra` int(10) unsigned NOT NULL,
  PRIMARY KEY (`codigo`,`pedra`),
  KEY `FK_mercadoriapedra_pedra` (`pedra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `mercadoriatipo`
--

DROP TABLE IF EXISTS `mercadoriatipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mercadoriatipo` (
  `codigo` char(2) NOT NULL COMMENT 'Digitos 2 e 3',
  `tipo` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `metal`
--

DROP TABLE IF EXISTS `metal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `metal` (
  `codigo` char(1) NOT NULL COMMENT '9o digito',
  `metal` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `moeda`
--

DROP TABLE IF EXISTS `moeda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moeda` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `sistema` tinyint(1) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `componenteCusto` varchar(10) DEFAULT NULL,
  `icone` mediumblob,
  `casasDecimais` tinyint(1) unsigned NOT NULL DEFAULT '2',
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `idx_moeda_nome` (`nome`),
  UNIQUE KEY `idx_moeda_componentecusto` (`componenteCusto`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `nfe`
--

DROP TABLE IF EXISTS `nfe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nfe` (
  `data` datetime NOT NULL,
  `venda` int(10) unsigned NOT NULL,
  `cfop` int(10) unsigned NOT NULL,
  `nfe` int(10) unsigned NOT NULL,
  `fatura` int(10) unsigned NOT NULL,
  `aliquota` float unsigned NOT NULL,
  `funcionario` int(10) unsigned NOT NULL,
  PRIMARY KEY (`data`,`venda`),
  KEY `fk_vinculovendanfe_1_idx` (`venda`),
  KEY `fk_vinculovendanfe_2_idx` (`funcionario`),
  CONSTRAINT `fk_vinculovendanfe_1` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_vinculovendanfe_2` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `notapromissoria`
--

DROP TABLE IF EXISTS `notapromissoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `notapromissoria` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `vencimento` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `prorrogadopara` datetime DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `notapromissoria_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=222880 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `novosPrecos`
--

DROP TABLE IF EXISTS `novosPrecos`;
/*!50001 DROP VIEW IF EXISTS `novosPrecos`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `novosPrecos` AS SELECT 
 1 AS `mercadoria`,
 1 AS `novoIndiceAtacado`,
 1 AS `novoPrecoCusto`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `novosPrecosVarejo`
--

DROP TABLE IF EXISTS `novosPrecosVarejo`;
/*!50001 DROP VIEW IF EXISTS `novosPrecosVarejo`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `novosPrecosVarejo` AS SELECT 
 1 AS `mercadoria`,
 1 AS `novoValorVarejoConsulta`,
 1 AS `novoValorVarejo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `novos_coeficientes`
--

DROP TABLE IF EXISTS `novos_coeficientes`;
/*!50001 DROP VIEW IF EXISTS `novos_coeficientes`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `novos_coeficientes` AS SELECT 
 1 AS `tabela`,
 1 AS `mercadoria`,
 1 AS `coeficiente`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `ouro`
--

DROP TABLE IF EXISTS `ouro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ouro` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `peso` double NOT NULL,
  `paraFundir` tinyint(1) NOT NULL,
  `multiplicador` double NOT NULL,
  `cotacao` double NOT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `ouro_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=222837 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pagamento`
--

DROP TABLE IF EXISTS `pagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagamento` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cliente` int(10) unsigned NOT NULL DEFAULT '0',
  `valor` double NOT NULL DEFAULT '0',
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pendente` tinyint(1) NOT NULL DEFAULT '0',
  `registradopor` int(10) unsigned NOT NULL DEFAULT '0',
  `devolvido` tinyint(1) NOT NULL DEFAULT '0',
  `cobrarJuros` tinyint(1) DEFAULT '1',
  `descricao` varchar(240) DEFAULT NULL,
  `venda` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `idx_pagamento_pendente` (`pendente`),
  KEY `index5` (`venda`) USING BTREE,
  KEY `fk_pagamento_1_idx` (`registradopor`),
  KEY `fk_pagamento_2_idx` (`cliente`),
  CONSTRAINT `fk_pagamento_1` FOREIGN KEY (`registradopor`) REFERENCES `funcionario` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_pagamento_2` FOREIGN KEY (`cliente`) REFERENCES `pessoa` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=222890 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pais`
--

DROP TABLE IF EXISTS `pais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pais` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL DEFAULT '',
  `sigla` varchar(10) DEFAULT NULL,
  `ddi` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `Index_pais_nome` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COMMENT='Endereço: País';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pedido` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tipo` enum('C','E') NOT NULL COMMENT 'C = Conserto, E = Encomenda',
  `cliente` int(10) unsigned DEFAULT NULL,
  `representante` int(10) unsigned DEFAULT NULL,
  `receptor` int(10) unsigned NOT NULL,
  `dataRecepcao` datetime NOT NULL,
  `dataPrevisao` datetime NOT NULL,
  `dataConclusao` datetime DEFAULT NULL,
  `dataEntrega` datetime DEFAULT NULL,
  `observacoes` mediumtext,
  `entrega` enum('L','D') NOT NULL,
  `funcionarioentrega` int(10) unsigned DEFAULT NULL,
  `pertenceAoCliente` tinyint(1) NOT NULL DEFAULT '0',
  `valor` double NOT NULL,
  `nomecliente` varchar(100) DEFAULT NULL,
  `dataOficina` datetime DEFAULT NULL,
  `funcionariooficina` int(10) unsigned DEFAULT NULL,
  `funcionarioconclusao` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `Index_Pedido_Previsao` (`dataPrevisao`),
  KEY `Index_Pedido_Conclusao` (`dataConclusao`),
  KEY `FK_pedido_cliente` (`cliente`),
  KEY `FK_pedido_funcionarioentrega` (`funcionarioentrega`),
  KEY `indice_pedido` (`cliente`,`representante`,`dataEntrega`,`dataConclusao`),
  KEY `Index_Pedido_DataRecepcao` (`dataRecepcao`),
  KEY `index_pedido_tipo` (`tipo`),
  KEY `fk_pedido_2_idx` (`representante`),
  KEY `fk_pedido_3` (`receptor`),
  KEY `fk_pedido_5` (`funcionariooficina`),
  KEY `fk_pedido_6` (`funcionarioconclusao`),
  CONSTRAINT `fk_pedido_1` FOREIGN KEY (`cliente`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_pedido_2` FOREIGN KEY (`representante`) REFERENCES `representante` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_pedido_3` FOREIGN KEY (`receptor`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_pedido_4` FOREIGN KEY (`funcionarioentrega`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_pedido_5` FOREIGN KEY (`funcionariooficina`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_pedido_6` FOREIGN KEY (`funcionarioconclusao`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=61406 DEFAULT CHARSET=latin1 COMMENT='Pedido e conserto';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pedidoitem`
--

DROP TABLE IF EXISTS `pedidoitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pedidoitem` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pedido` int(11) unsigned NOT NULL,
  `mercadoria` varchar(11) DEFAULT NULL,
  `quantidade` int(11) NOT NULL,
  `descricao` tinytext,
  PRIMARY KEY (`codigo`),
  KEY `fk_pedidoitem_1_idx` (`pedido`),
  KEY `fk_pedidoitem_2` (`mercadoria`),
  CONSTRAINT `fk_pedidoitem_1` FOREIGN KEY (`pedido`) REFERENCES `pedido` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_pedidoitem_2` FOREIGN KEY (`mercadoria`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=31011 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pedra`
--

DROP TABLE IF EXISTS `pedra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pedra` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pedra` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pessoa` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL DEFAULT '',
  `setor` int(10) unsigned DEFAULT NULL,
  `email` varchar(100) DEFAULT '',
  `observacoes` longtext,
  `ultimaVisita` datetime DEFAULT NULL,
  `dataRegistro` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `dataAlteracao` datetime NOT NULL,
  `classificacoes` bigint(20) unsigned NOT NULL DEFAULT '0' COMMENT 'A ser utilizado como bitwise flag com os valores da tabela classificacao',
  `maiorVenda` double DEFAULT NULL,
  `credito` double DEFAULT NULL,
  `fornecedor` tinyint(1) NOT NULL DEFAULT '0',
  `regiao` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `IDX_Pessoa_Nome` (`nome`),
  KEY `idx_pessoa_ultimaVisita` (`ultimaVisita`),
  KEY `fk_pessoa_1_idx` (`regiao`),
  KEY `fk_pessoa_2_idx` (`setor`),
  FULLTEXT KEY `fulltext_pessoa_nome` (`nome`),
  CONSTRAINT `fk_pessoa_1` FOREIGN KEY (`regiao`) REFERENCES `regiao` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_pessoa_2` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=361718 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pessoadatarelevante`
--

DROP TABLE IF EXISTS `pessoadatarelevante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pessoadatarelevante` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `descricao` varchar(100) NOT NULL,
  `alertar` tinyint(1) NOT NULL DEFAULT '1',
  KEY `fk_pessoadatarelevante_1_idx` (`pessoa`),
  CONSTRAINT `fk_pessoadatarelevante_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pessoafisica`
--

DROP TABLE IF EXISTS `pessoafisica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pessoafisica` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `sexo` enum('M','F') DEFAULT NULL,
  `di` varchar(15) DEFAULT NULL,
  `diEmissor` varchar(10) DEFAULT NULL,
  `cpf` varchar(14) DEFAULT '',
  `nascimento` datetime DEFAULT '0000-00-00 00:00:00',
  `estadoCivil` enum('C','S','D','V','O') DEFAULT NULL,
  `nomePai` varchar(100) DEFAULT '',
  `nomeMae` varchar(100) DEFAULT '',
  `naturalidade` int(10) unsigned DEFAULT NULL,
  `profissao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_PessoaFisica_CPF` (`cpf`),
  UNIQUE KEY `IDX_PessoaFisica_RG` (`di`,`diEmissor`),
  KEY `FK_pessoafisica_naturalidade` (`naturalidade`),
  CONSTRAINT `fk_pessoafisica_1` FOREIGN KEY (`codigo`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pessoafoto`
--

DROP TABLE IF EXISTS `pessoafoto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pessoafoto` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `foto` blob NOT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `imjoias/pessoafoto_ibfk_1` FOREIGN KEY (`codigo`) REFERENCES `pessoa` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pessoajuridica`
--

DROP TABLE IF EXISTS `pessoajuridica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pessoajuridica` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `cnpj` varchar(18) DEFAULT NULL,
  `fantasia` varchar(100) DEFAULT NULL,
  `inscEstadual` varchar(45) DEFAULT NULL,
  `inscMunicipal` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_PessoaFisica_CNPJ` (`cnpj`),
  KEY `IDX_PessoaJuridica_Fantasia` (`fantasia`),
  CONSTRAINT `fk_pessoajuridica_1` FOREIGN KEY (`codigo`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `regiao`
--

DROP TABLE IF EXISTS `regiao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `regiao` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL DEFAULT '',
  `observacoes` text,
  `representante` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_Regiao_Nome` (`nome`),
  KEY `fk_regiao_1_idx` (`representante`),
  CONSTRAINT `fk_regiao_1` FOREIGN KEY (`representante`) REFERENCES `representante` (`codigo`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=934 DEFAULT CHARSET=latin1 COMMENT='Endereço: Região';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `representante`
--

DROP TABLE IF EXISTS `representante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `representante` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `fk_representante_1` FOREIGN KEY (`codigo`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29481 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `retorno`
--

DROP TABLE IF EXISTS `retorno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `retorno` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `digitadopor` int(10) unsigned NOT NULL DEFAULT '0',
  `travado` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `tabela` int(10) unsigned NOT NULL DEFAULT '3',
  `acerto` int(10) unsigned DEFAULT NULL,
  `observacoes` mediumtext,
  PRIMARY KEY (`codigo`),
  KEY `IDX_Retorno_Data` (`data`),
  KEY `Idx_Retorno_Travado` (`travado`),
  KEY `fk_retorno_1_idx` (`pessoa`),
  KEY `fk_retorno_2_idx` (`digitadopor`),
  KEY `fk_retorno_3_idx` (`tabela`),
  KEY `fk_retorno_4_idx` (`acerto`),
  CONSTRAINT `fk_retorno_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_retorno_2` FOREIGN KEY (`digitadopor`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_retorno_3` FOREIGN KEY (`tabela`) REFERENCES `tabela` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_retorno_4` FOREIGN KEY (`acerto`) REFERENCES `acertoconsignado` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21934 DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 125952 kB; (`funcionario`) REFER `imjoias';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `retornoitem`
--

DROP TABLE IF EXISTS `retornoitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `retornoitem` (
  `retorno` int(10) unsigned NOT NULL DEFAULT '0',
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `peso` double NOT NULL DEFAULT '0',
  `quantidade` double NOT NULL DEFAULT '0',
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT '1900-00-00 00:00:00',
  `indice` double NOT NULL DEFAULT '0',
  `funcionario` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `idx_retornoitem_retorno` (`retorno`),
  KEY `fk_retornoitem_2_idx` (`referencia`),
  KEY `fk_retornoitem_3_idx` (`funcionario`),
  CONSTRAINT `fk_retornoitem_1` FOREIGN KEY (`retorno`) REFERENCES `retorno` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_retornoitem_2` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE,
  CONSTRAINT `fk_retornoitem_3` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1237764 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `saida`
--

DROP TABLE IF EXISTS `saida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `saida` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `digitadopor` int(10) unsigned NOT NULL DEFAULT '0',
  `travado` tinyint(1) NOT NULL DEFAULT '0',
  `tabela` int(10) unsigned NOT NULL DEFAULT '3',
  `acerto` int(10) unsigned NOT NULL,
  `cotacao` double NOT NULL,
  `observacoes` mediumtext,
  PRIMARY KEY (`codigo`),
  KEY `Idx_Saida_Data` (`data`),
  KEY `Idx_Saida_Travado` (`travado`),
  KEY `fk_saida_1_idx` (`pessoa`),
  KEY `fk_saida_2_idx` (`digitadopor`),
  KEY `fk_saida_3_idx` (`tabela`),
  KEY `fk_saida_4_idx` (`acerto`),
  CONSTRAINT `fk_saida_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_saida_2` FOREIGN KEY (`digitadopor`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_saida_3` FOREIGN KEY (`tabela`) REFERENCES `tabela` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_saida_4` FOREIGN KEY (`acerto`) REFERENCES `acertoconsignado` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=63559 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `saidaitem`
--

DROP TABLE IF EXISTS `saidaitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `saidaitem` (
  `saida` int(11) NOT NULL DEFAULT '0',
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `peso` double NOT NULL DEFAULT '0',
  `quantidade` double NOT NULL DEFAULT '0',
  `data` datetime NOT NULL DEFAULT '1910-00-00 00:00:00',
  `funcionario` int(10) unsigned NOT NULL DEFAULT '0',
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `indice` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `idx_itempedido_pedido` (`saida`) USING BTREE,
  KEY `FK_saidaitem_funcionario` (`funcionario`),
  KEY `Index_saidaitem_referencia` (`referencia`),
  KEY `saidaitem_peso` (`peso`),
  CONSTRAINT `fk_saidaitem_1` FOREIGN KEY (`saida`) REFERENCES `saida` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_saidaitem_2` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE,
  CONSTRAINT `fk_saidaitem_3` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1936761 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `setor`
--

DROP TABLE IF EXISTS `setor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `setor` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL DEFAULT '',
  `atendimento` tinyint(1) NOT NULL DEFAULT '0',
  `empresa` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_Setor_Nome` (`nome`),
  KEY `IDX_Setor_Empresa` (`empresa`),
  KEY `Idx_Setor_Atendimento` (`atendimento`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 62464 kB; (`empresa`) REFER `imjoias/pessoajuri';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tabela`
--

DROP TABLE IF EXISTS `tabela`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tabela` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `moeda` int(10) unsigned NOT NULL,
  `setor` int(10) unsigned NOT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `Index_tabela_nome` (`nome`),
  KEY `fk_tabela_1_idx` (`moeda`),
  KEY `fk_tabela_2_idx` (`setor`),
  CONSTRAINT `fk_tabela_1` FOREIGN KEY (`moeda`) REFERENCES `moeda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_tabela_2` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tabelaindices`
--

DROP TABLE IF EXISTS `tabelaindices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tabelaindices` (
  `numero` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`numero`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tabelamercadoria`
--

DROP TABLE IF EXISTS `tabelamercadoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tabelamercadoria` (
  `tabela` int(10) unsigned NOT NULL,
  `mercadoria` varchar(11) NOT NULL,
  `coeficiente` double unsigned NOT NULL,
  PRIMARY KEY (`tabela`,`mercadoria`),
  KEY `fk_tabelamercadoria_2_idx` (`mercadoria`),
  CONSTRAINT `fk_tabelamercadoria_1` FOREIGN KEY (`tabela`) REFERENCES `tabela` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_tabelamercadoria_2` FOREIGN KEY (`mercadoria`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `telefone`
--

DROP TABLE IF EXISTS `telefone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefone` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `id` int(10) unsigned NOT NULL DEFAULT '0',
  `descricao` varchar(45) NOT NULL DEFAULT '',
  `telefone` varchar(32) NOT NULL,
  `observacoes` text,
  PRIMARY KEY (`pessoa`,`id`),
  CONSTRAINT `fk_telefone_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `telefonemanomefuncionario`
--

DROP TABLE IF EXISTS `telefonemanomefuncionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefonemanomefuncionario` (
  `quando` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `telefone` varchar(20) NOT NULL DEFAULT '',
  `nome` varchar(100) NOT NULL DEFAULT '',
  `funcionario` int(10) unsigned NOT NULL DEFAULT '0',
  `cidade` varchar(50) NOT NULL DEFAULT '',
  `tipoOrigem` int(11) NOT NULL DEFAULT '0',
  `tipoDestino` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`quando`),
  KEY `IDX_TelefonemaNomeFuncionario_Funcionario` (`funcionario`),
  CONSTRAINT `fk_telefonemanomefuncionario_1` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `telefonemanomenome`
--

DROP TABLE IF EXISTS `telefonemanomenome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefonemanomenome` (
  `quando` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `telefone` varchar(20) NOT NULL DEFAULT '',
  `origem` varchar(100) NOT NULL DEFAULT '',
  `destino` varchar(50) NOT NULL DEFAULT 'Belo Horizonte',
  `cidade` varchar(50) NOT NULL DEFAULT '',
  `tipoOrigem` int(11) NOT NULL DEFAULT '0',
  `tipoDestino` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`quando`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tmp`
--

DROP TABLE IF EXISTS `tmp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmp` (
  `codigo` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `utilizacao`
--

DROP TABLE IF EXISTS `utilizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `utilizacao` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(100) NOT NULL DEFAULT '',
  `quando` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `aplicacao` int(11) NOT NULL DEFAULT '0',
  `parametros` tinytext,
  PRIMARY KEY (`codigo`),
  KEY `IDX_UTILIZACAO_APLICACAO` (`aplicacao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venda` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cotacao` double NOT NULL DEFAULT '0',
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `travado` tinyint(1) NOT NULL DEFAULT '0',
  `vendedor` int(10) unsigned NOT NULL,
  `cliente` int(10) unsigned NOT NULL,
  `controle` int(10) unsigned DEFAULT NULL,
  `valortotal` double DEFAULT NULL COMMENT 'Valor vendido menos devolvido',
  `digitadopor` int(10) unsigned NOT NULL DEFAULT '0',
  `desconto` double NOT NULL DEFAULT '0',
  `tabela` int(10) unsigned NOT NULL DEFAULT '3',
  `acerto` int(10) unsigned DEFAULT NULL,
  `taxajuros` double unsigned NOT NULL DEFAULT '1.8' COMMENT 'Taxa de juros ao mes (percentual)',
  `quitacao` datetime DEFAULT NULL,
  `observacoes` mediumtext,
  `diasSemJuros` int(10) unsigned NOT NULL,
  `rastreada` tinyint(1) NOT NULL DEFAULT '0',
  `sedex` int(11) NOT NULL DEFAULT '0',
  `corretor` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `FK_VENDA_PESSOA` (`vendedor`),
  KEY `FK_VENDA_CLIENTE` (`cliente`),
  KEY `FK_VENDA_DIGITADOPOR` (`digitadopor`),
  KEY `Idx_Venda_Travado` (`travado`),
  KEY `IDX_Venda_Data` (`data`),
  KEY `IDX_Venda_ValorTotal` (`valortotal`),
  KEY `IDX_Venda_Cotacao` (`cotacao`),
  KEY `fk_venda_1_idx` (`corretor`),
  KEY `fk_venda_4_idx` (`tabela`),
  KEY `fk_venda_5_idx` (`acerto`),
  CONSTRAINT `fk_venda_1` FOREIGN KEY (`corretor`) REFERENCES `pessoa` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_venda_2` FOREIGN KEY (`cliente`) REFERENCES `pessoa` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_venda_3` FOREIGN KEY (`vendedor`) REFERENCES `pessoa` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_venda_4` FOREIGN KEY (`tabela`) REFERENCES `tabela` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_venda_5` FOREIGN KEY (`acerto`) REFERENCES `acertoconsignado` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=103291 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='InnoDB free: 855040 kB; (`acerto`) REFER `imjoias/acertocons';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vendacredito`
--

DROP TABLE IF EXISTS `vendacredito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendacredito` (
  `venda` int(10) unsigned NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `valorliquido` double NOT NULL,
  `valorbruto` double NOT NULL,
  `data` datetime NOT NULL,
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `diasdejuros` int(11) NOT NULL DEFAULT '0',
  `cobrarjuros` tinyint(1) NOT NULL DEFAULT '1',
  `credito` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `vendacredito_vendacredito_FK` (`venda`),
  CONSTRAINT `vendacredito_vendacredito_FK` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7252 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vendadebito`
--

DROP TABLE IF EXISTS `vendadebito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendadebito` (
  `venda` int(10) unsigned NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `valorliquido` double NOT NULL,
  `valorbruto` double NOT NULL,
  `data` datetime NOT NULL,
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `diasdejuros` int(11) NOT NULL DEFAULT '0',
  `cobrarjuros` tinyint(1) NOT NULL DEFAULT '1',
  `pagamento` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `Index_venda` (`venda`),
  KEY `FK_VENDADEBITO_PAGAMENTO` (`pagamento`),
  CONSTRAINT `vendadebito_FK` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=127756 DEFAULT CHARSET=latin1 COMMENT='Debitos da venda';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vendadevolucao`
--

DROP TABLE IF EXISTS `vendadevolucao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendadevolucao` (
  `venda` int(10) unsigned NOT NULL DEFAULT '0',
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `peso` double NOT NULL DEFAULT '0',
  `quantidade` double NOT NULL DEFAULT '0',
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `funcionario` int(10) unsigned NOT NULL DEFAULT '0',
  `indice` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `FK_VENDA_DEVOLUCAO` (`venda`),
  KEY `idx_vendadevolucao_venda` (`venda`),
  KEY `idx_vendadevolucao_referencia` (`referencia`),
  KEY `idx_vendadevolucao_peso` (`peso`),
  KEY `idx_vendadevolucao_quantidade` (`quantidade`),
  KEY `idx_vendadevolucao_data` (`data`),
  KEY `idx_vendadevolucao_funcionario` (`funcionario`),
  KEY `idx_vendadevolucao_indice` (`indice`),
  CONSTRAINT `fk_vendadevolucao_1` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_vendadevolucao_2` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_vendadevolucao_3` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=78143 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='InnoDB free: 198656 kB; (`venda`) REFER `imjoias-desenv/vend';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vendaitem`
--

DROP TABLE IF EXISTS `vendaitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendaitem` (
  `venda` int(10) unsigned NOT NULL DEFAULT '0',
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `peso` double NOT NULL DEFAULT '0',
  `quantidade` double NOT NULL DEFAULT '0',
  `data` datetime NOT NULL DEFAULT '1910-00-00 00:00:00',
  `funcionario` int(10) unsigned NOT NULL DEFAULT '0',
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `indice` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `idx_vendaitem_venda` (`venda`),
  KEY `idx_vendaitem_referencia` (`referencia`),
  KEY `idx_vendaitem_peso` (`peso`),
  KEY `idx_vendaitem_quantidade` (`quantidade`),
  KEY `idx_vendaitem_data` (`data`),
  KEY `idx_vendaitem_funcionario` (`funcionario`),
  KEY `idx_vendaitem_indice` (`indice`),
  CONSTRAINT `fk_vendaitem_1` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_vendaitem_2` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON UPDATE CASCADE,
  CONSTRAINT `fk_vendaitem_3` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=809079 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `vendasintetizada`
--

DROP TABLE IF EXISTS `vendasintetizada`;
/*!50001 DROP VIEW IF EXISTS `vendasintetizada`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vendasintetizada` AS SELECT 
 1 AS `codigo`,
 1 AS `controle`,
 1 AS `valortotal`,
 1 AS `nome`,
 1 AS `cliente`,
 1 AS `data`,
 1 AS `vendedorcod`,
 1 AS `clientecod`,
 1 AS `taxajuros`,
 1 AS `cotacao`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `vinculocomissaovenda`
--

DROP TABLE IF EXISTS `vinculocomissaovenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vinculocomissaovenda` (
  `comissao` int(11) NOT NULL,
  `venda` int(11) unsigned NOT NULL,
  PRIMARY KEY (`comissao`,`venda`),
  KEY `fk_vinculocomissaovenda_2` (`venda`),
  CONSTRAINT `fk_vinculocomissaovenda_1` FOREIGN KEY (`comissao`) REFERENCES `comissao` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_vinculocomissaovenda_2` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vinculofotoalbum`
--

DROP TABLE IF EXISTS `vinculofotoalbum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vinculofotoalbum` (
  `album` int(10) unsigned NOT NULL DEFAULT '0',
  `foto` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`album`,`foto`),
  KEY `Index_vinculofotoalbum_foto` (`foto`),
  CONSTRAINT `fk_vinculofotoalbum_1` FOREIGN KEY (`album`) REFERENCES `album` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vinculogrupopessoa`
--

DROP TABLE IF EXISTS `vinculogrupopessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vinculogrupopessoa` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `grupo` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`pessoa`,`grupo`),
  KEY `IDX_VinculoGrupoPessoa_Grupo` (`grupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vinculomercadoriacomponentecusto`
--

DROP TABLE IF EXISTS `vinculomercadoriacomponentecusto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vinculomercadoriacomponentecusto` (
  `mercadoria` varchar(30) NOT NULL DEFAULT '',
  `componentecusto` char(2) NOT NULL DEFAULT '',
  `quantidade` double NOT NULL DEFAULT '0',
  UNIQUE KEY `idx_unico` (`mercadoria`,`componentecusto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vinculomercadoriafornecedor`
--

DROP TABLE IF EXISTS `vinculomercadoriafornecedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vinculomercadoriafornecedor` (
  `mercadoria` varchar(11) NOT NULL,
  `fornecedor` int(11) NOT NULL,
  `referenciafornecedor` varchar(45) DEFAULT NULL,
  `inicio` datetime NOT NULL DEFAULT '1900-01-01 00:00:00',
  PRIMARY KEY (`mercadoria`,`fornecedor`),
  CONSTRAINT `FK_vinculomercadoriafornecedor_mercadoria` FOREIGN KEY (`mercadoria`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vinculopessoasetor`
--

DROP TABLE IF EXISTS `vinculopessoasetor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vinculopessoasetor` (
  `Pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `Setor` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`Pessoa`),
  KEY `IDX_VinculoPessoaSetor_Setor` (`Setor`),
  CONSTRAINT `fk_vinculopessoasetor_1` FOREIGN KEY (`Pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_vinculopessoasetor_2` FOREIGN KEY (`Setor`) REFERENCES `setor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `visita`
--

DROP TABLE IF EXISTS `visita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `visita` (
  `entrada` datetime NOT NULL DEFAULT '1900-01-01 00:00:00',
  `saida` datetime DEFAULT NULL,
  `espera` int(11) DEFAULT '0',
  `motivo` int(11) NOT NULL DEFAULT '0',
  `setor` int(10) unsigned DEFAULT NULL,
  `funcionario` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`entrada`),
  KEY `idx_visita_saida` (`saida`),
  KEY `idx_visita_espera` (`espera`),
  KEY `idx_visita_motivo` (`motivo`),
  KEY `fk_visita_1_idx` (`funcionario`),
  KEY `fk_visita_2_idx` (`setor`),
  CONSTRAINT `fk_visita_1` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_visita_2` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `visitanome`
--

DROP TABLE IF EXISTS `visitanome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `visitanome` (
  `visita` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `nome` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`visita`,`nome`),
  KEY `IDX_VisitaNome_Visita` (`visita`),
  KEY `IDX_VisitaNome_Nome` (`nome`),
  CONSTRAINT `fk_visitanome_visita` FOREIGN KEY (`visita`) REFERENCES `visita` (`entrada`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `visitapessoafisica`
--

DROP TABLE IF EXISTS `visitapessoafisica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `visitapessoafisica` (
  `visita` datetime NOT NULL DEFAULT '1900-01-01 00:00:00',
  `pessoaFisica` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`visita`,`pessoaFisica`),
  KEY `IDX_VisitaPessoaFisica_Visita` (`visita`),
  KEY `IDX_VisitaPessoaFisica_PessoaFisica` (`pessoaFisica`),
  KEY `fk_visitapessoafisica_1_idx` (`pessoaFisica`),
  CONSTRAINT `fk_visitapessoafisica_1` FOREIGN KEY (`visita`) REFERENCES `visita` (`entrada`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `visitapessoafisica_pessoa_FK` FOREIGN KEY (`pessoaFisica`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `zeragemestoque`
--

DROP TABLE IF EXISTS `zeragemestoque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `zeragemestoque` (
  `data` datetime NOT NULL,
  `funcionario` int(10) unsigned NOT NULL,
  `observacoes` tinytext NOT NULL,
  `comissaoVigente` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`data`),
  KEY `fk_zeragemestoque_1_idx` (`funcionario`),
  KEY `zeragemestoque_comissao_FK` (`comissaoVigente`),
  CONSTRAINT `fk_zeragemestoque_1` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `zeragemestoque_comissao_FK` FOREIGN KEY (`comissaoVigente`) REFERENCES `comissao` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Final view structure for view `bugs_pendentes`
--

/*!50001 DROP VIEW IF EXISTS `bugs_pendentes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `bugs_pendentes` AS (select `b`.`codigo` AS `codigo`,`b`.`primeiraData` AS `primeiraData`,`b`.`ultimaData` AS `ultimaData`,`b`.`ocorrencias` AS `ocorrencias`,`b`.`message` AS `message`,`b`.`targetsite` AS `targetsite`,`b`.`source` AS `source`,`b`.`stacktrace` AS `stacktrace`,`b`.`corrigido` AS `corrigido`,`b`.`correcaoAutor` AS `correcaoAutor`,`b`.`correcaoData` AS `correcaoData`,`b`.`correcaoComentarios` AS `correcaoComentarios`,`b`.`ignorar` AS `ignorar`,`b`.`innerException` AS `innerException` from `bug` `b` where ((`b`.`corrigido` = 0) and (`b`.`ignorar` = 0)) order by `b`.`ocorrencias` desc,`b`.`ultimaData` desc) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `comissao_qtdestorno`
--

/*!50001 DROP VIEW IF EXISTS `comissao_qtdestorno`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comissao_qtdestorno` AS select `comissaoestornovenda`.`venda` AS `venda`,`comissaoestornovenda`.`pessoa` AS `pessoa`,count(0) AS `qtdEstorno` from `comissaoestornovenda` group by `comissaoestornovenda`.`venda`,`comissaoestornovenda`.`pessoa` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `comissao_qtdvenda`
--

/*!50001 DROP VIEW IF EXISTS `comissao_qtdvenda`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comissao_qtdvenda` AS select `comissaovenda`.`venda` AS `venda`,`comissaovenda`.`pessoa` AS `pessoa`,count(0) AS `qtdVenda` from `comissaovenda` group by `comissaovenda`.`venda`,`comissaovenda`.`pessoa` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `comissao_saldo`
--

/*!50001 DROP VIEW IF EXISTS `comissao_saldo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comissao_saldo` AS select `a`.`venda` AS `venda`,`a`.`pessoa` AS `pessoa`,(ifnull(`a`.`qtdVenda`,0) - ifnull(`b`.`qtdEstorno`,0)) AS `saldo` from (`comissao_qtdvenda` `a` left join `comissao_qtdestorno` `b` on(((`a`.`venda` = `b`.`venda`) and (`a`.`pessoa` = `b`.`pessoa`)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `comissao_semaforo`
--

/*!50001 DROP VIEW IF EXISTS `comissao_semaforo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comissao_semaforo` AS select `comissao_semaforo_multiplo`.`venda` AS `venda`,max(`comissao_semaforo_multiplo`.`semaforo`) AS `semaforo` from `comissao_semaforo_multiplo` group by `comissao_semaforo_multiplo`.`venda` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `comissao_semaforo_multiplo`
--

/*!50001 DROP VIEW IF EXISTS `comissao_semaforo_multiplo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comissao_semaforo_multiplo` AS select `v`.`codigo` AS `venda`,5 AS `semaforo`,'nfe' AS `descricao` from (`venda` `v` join `nfe` `n` on((`v`.`codigo` = `n`.`venda`))) union select `v`.`codigo` AS `venda`,3 AS `semaforo`,'comissao_fechada' AS `descricao` from (`venda` `v` join `comissao_saldo` `c` on(((`v`.`codigo` = `c`.`venda`) and (`c`.`saldo` = 1)))) union select `v`.`codigo` AS `venda`,2 AS `semaforo`,'quitado' AS `descricao` from `venda` `v` where (`v`.`quitacao` is not null) union select `v`.`codigo` AS `venda`,0 AS `semaforo`,'nao_quitado' AS `descricao` from `venda` `v` where isnull(`v`.`quitacao`) union select `v`.`codigo` AS `venda`,1 AS `semaforo`,'cobranca' AS `descricao` from `venda` `v` where (isnull(`v`.`quitacao`) and (abs(`v`.`valortotal`) < 0.01)) union select `v`.`codigo` AS `venda`,4 AS `semaforo`,'do_dia' AS `descricao` from `venda` `v` where ((to_days(now()) - to_days(`v`.`data`)) < 1) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `comissao_valor`
--

/*!50001 DROP VIEW IF EXISTS `comissao_valor`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comissao_valor` AS select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,1 AS `setor`,'C0+' AS `tipo`,0 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 1) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,1 AS `setor`,'C0-' AS `tipo`,0 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 1) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C1+' AS `tipo`,1 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` = 2) and isnull(`v`.`acerto`) and (`v`.`tabela` <> 2) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C1-' AS `tipo`,1 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` = 2) and isnull(`v`.`acerto`) and (`v`.`tabela` <> 2) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C2+' AS `tipo`,2 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) left join `representante` `rr` on((`v`.`vendedor` = `rr`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rr`.`codigo`) and (`cli`.`setor` = 2) and ((`v`.`acerto` is not null) or (`v`.`tabela` = 2)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C2-' AS `tipo`,2 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) left join `representante` `rr` on((`v`.`vendedor` = `rr`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rr`.`codigo`) and (`cli`.`setor` = 2) and ((`v`.`acerto` is not null) or (`v`.`tabela` = 2)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,3 AS `setor`,'C3+' AS `tipo`,3 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 3) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,3 AS `setor`,'C3-' AS `tipo`,3 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 3) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C4+' AS `tipo`,4 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` = `v`.`vendedor`)) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C4-' AS `tipo`,4 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` = `v`.`vendedor`)) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C5+' AS `tipo`,5 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and `v`.`vendedor` in (select `representante`.`codigo` from `representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C5-' AS `tipo`,5 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and `v`.`vendedor` in (select `representante`.`codigo` from `representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C6+' AS `tipo`,6 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` > 1) and (`v`.`vendedor` <> `v`.`cliente`) and isnull(`r`.`representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C6-' AS `tipo`,6 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` > 1) and (`v`.`vendedor` <> `v`.`cliente`) and isnull(`r`.`representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,2 AS `setor`,'C7v+' AS `tipo`,7 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 2) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,2 AS `setor`,'C7v-' AS `tipo`,7 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 2) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`r`.`representante` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C7r+' AS `tipo`,7 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * (`csf_r`.`valor` - `csf_a`.`valor`)) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf_r` on(((`csf_r`.`setor` = 100) and (`csf_r`.`faixa` = `m`.`faixa`)))) join `comissaosetorfaixa` `csf_a` on(((`csf_a`.`setor` = 2) and (`csf_a`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`r`.`representante` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C7r-' AS `tipo`,7 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * (`csf_r`.`valor` - `csf_a`.`valor`)) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf_r` on(((`csf_r`.`setor` = 100) and (`csf_r`.`faixa` = `m`.`faixa`)))) join `comissaosetorfaixa` `csf_a` on(((`csf_a`.`setor` = 2) and (`csf_a`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C8+' AS `tipo`,8 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `representante` `r` on((`cli`.`codigo` = `r`.`codigo`))) where (`v`.`quitacao` is not null) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C8-' AS `tipo`,8 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `representante` `r` on((`cli`.`codigo` = `r`.`codigo`))) where (`v`.`quitacao` is not null) union select `v`.`cliente` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`corretor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,15 AS `setor`,'corretor+' AS `tipo`,9 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 15) and (`csf`.`faixa` = `m`.`faixa`)))) join `pessoa` `corretor` on((`v`.`corretor` = `corretor`.`codigo`))) where (`v`.`quitacao` is not null) union select `v`.`cliente` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`corretor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,15 AS `setor`,'corretor-' AS `tipo`,9 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 15) and (`csf`.`faixa` = `m`.`faixa`)))) join `pessoa` `corretor` on((`v`.`corretor` = `corretor`.`codigo`))) where (`v`.`quitacao` is not null) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`s`.`codigo` AS `setor`,'C10+' AS `tipo`,10 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` `s` on((`s`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `s`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` not in (3,1,2,100,15)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C10-' AS `tipo`,10 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` on((`setor`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `setor`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` not in (3,1,2,100,15)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`s`.`codigo` AS `setor`,'C11+' AS `tipo`,11 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` `s` on((`s`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `s`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and `v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`) and (not(`v`.`cliente` in (select `representante`.`codigo` from `representante`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`s`.`codigo` AS `setor`,'C11-' AS `tipo`,11 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` `s` on((`s`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `s`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and `v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`) and (not(`v`.`cliente` in (select `representante`.`codigo` from `representante`)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `comissao_venda`
--

/*!50001 DROP VIEW IF EXISTS `comissao_venda`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `comissao_venda` AS select `cv`.`cliente` AS `cliente`,`cv`.`vendedor` AS `vendedor`,`cv`.`comissaopara` AS `comissaopara`,`cv`.`venda` AS `venda`,`cv`.`setor` AS `setor`,`cv`.`tipo` AS `tipo`,`cv`.`regra` AS `regra`,(sum(`cv`.`valorc`) - ((`csf`.`valor` * `v`.`desconto`) / 100)) AS `valorc`,round((sum(`cv`.`valorv`) - `v`.`desconto`),2) AS `valorv` from ((`comissao_valor` `cv` join `venda` `v` on((`cv`.`venda` = `v`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cv`.`setor`) and (`csf`.`faixa` = 'A')))) group by `cv`.`comissaopara`,`cv`.`venda` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `componentecusto_valorfinal`
--

/*!50001 DROP VIEW IF EXISTS `componentecusto_valorfinal`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `componentecusto_valorfinal` AS select `componentecusto`.`codigo` AS `codigo`,`componentecusto`.`valor` AS `valorfinal` from `componentecusto` where isnull(`componentecusto`.`multiplicarcomponentecusto`) union select `c`.`codigo` AS `codigo`,(`c`.`valor` * `v2`.`valor`) AS `valorfinal` from (`componentecusto` `c` join `componentecusto` `v2`) where (`c`.`multiplicarcomponentecusto` = `v2`.`codigo`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `devedores`
--

/*!50001 DROP VIEW IF EXISTS `devedores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `devedores` AS select `pessoa`.`codigo` AS `codigo`,`pessoa`.`nome` AS `nome`,sum(`pagamento`.`valor`) AS `sum(valor)` from (`pessoa` join `pagamento`) where ((`pagamento`.`pendente` = 1) and (`pessoa`.`codigo` = `pagamento`.`cliente`)) group by `pessoa`.`codigo` order by sum(`pagamento`.`valor`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `estoque_extrato`
--

/*!50001 DROP VIEW IF EXISTS `estoque_extrato`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `estoque_extrato` AS select `ei`.`data` AS `data`,`p`.`nome` AS `nome`,`ei`.`referencia` AS `referencia`,`ei`.`peso` AS `peso`,`ei`.`quantidade` AS `entrada`,0 AS `venda`,0 AS `devolucao`,concat('Entrada ',`e`.`codigo`) AS `operacao` from ((`entrada` `e` join `entradaitem` `ei` on((`e`.`codigo` = `ei`.`entrada`))) join `pessoa` `p` on((`p`.`codigo` = `ei`.`funcionario`))) where (`e`.`data` > (select max(`zeragemestoque`.`data`) from `zeragemestoque`)) union select `vi`.`data` AS `data`,`p`.`nome` AS `nome`,`vi`.`referencia` AS `referencia`,`vi`.`peso` AS `peso`,0 AS `entrada`,`vi`.`quantidade` AS `venda`,0 AS `devolucao`,concat('Venda ',`v`.`codigo`) AS `operacao` from (((`venda` `v` join `vendaitem` `vi` on((`v`.`codigo` = `vi`.`venda`))) join `pessoa` `p` on((`p`.`codigo` = `vi`.`funcionario`))) join `comissao_saldo` `s` on((`v`.`codigo` = `s`.`venda`))) where ((`s`.`saldo` > 0) and `v`.`codigo` in (select `comissaovenda`.`venda` from `comissaovenda` where (`comissaovenda`.`comissao` > (select max(`zeragemestoque`.`comissaoVigente`) from `zeragemestoque`)))) union select `d`.`data` AS `data`,`p`.`nome` AS `nome`,`d`.`referencia` AS `referencia`,`d`.`peso` AS `peso`,0 AS `entrada`,0 AS `venda`,`d`.`quantidade` AS `devolucao`,concat('Devoluo ',`v`.`codigo`) AS `operacao` from (((`venda` `v` join `vendadevolucao` `d` on((`v`.`codigo` = `d`.`venda`))) join `pessoa` `p` on((`p`.`codigo` = `d`.`funcionario`))) join `comissao_saldo` `s` on((`v`.`codigo` = `s`.`venda`))) where ((`s`.`saldo` > 0) and `v`.`codigo` in (select `comissaovenda`.`venda` from `comissaovenda` where (`comissaovenda`.`comissao` > (select max(`zeragemestoque`.`comissaoVigente`) from `zeragemestoque`)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `estoque_saldo`
--

/*!50001 DROP VIEW IF EXISTS `estoque_saldo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `estoque_saldo` AS select `e`.`referencia` AS `referencia`,`e`.`peso` AS `peso`,sum(`e`.`entrada`) AS `entrada`,sum(`e`.`venda`) AS `venda`,sum(`e`.`devolucao`) AS `devolucao`,((sum(`e`.`entrada`) - sum(`e`.`venda`)) + sum(`e`.`devolucao`)) AS `saldo` from (`estoque_extrato` `e` join `mercadoria` `m` on((`e`.`referencia` = `m`.`referencia`))) where (`m`.`foradelinha` = 0) group by `e`.`referencia`,`e`.`peso` having ((`venda` <> 0) or (`devolucao` <> 0) or (`saldo` <> 0) or (`entrada` <> 0)) order by `e`.`referencia`,`e`.`peso` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `novosPrecos`
--

/*!50001 DROP VIEW IF EXISTS `novosPrecos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `novosPrecos` AS select `mc`.`mercadoria` AS `mercadoria`,round((round(sum((round((`t1`.`valorfinal` * `mc`.`quantidade`),2) * (1 + `f`.`valor`))),2) / `OBTEMDOLAR`()),2) AS `novoIndiceAtacado`,round(sum((`t1`.`valorfinal` * `mc`.`quantidade`)),2) AS `novoPrecoCusto` from (((`vinculomercadoriacomponentecusto` `mc` join `componentecusto_valorfinal` `t1`) join `faixa` `f`) join `mercadoria` `m`) where ((`mc`.`componentecusto` = `t1`.`codigo`) and (`m`.`referencia` = `mc`.`mercadoria`) and (`m`.`faixa` = `f`.`faixa`) and (`f`.`setor` = 2)) group by `mc`.`mercadoria` order by `m`.`referencia` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `novosPrecosVarejo`
--

/*!50001 DROP VIEW IF EXISTS `novosPrecosVarejo`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `novosPrecosVarejo` AS select `mc`.`mercadoria` AS `mercadoria`,round(round(sum((round((`t1`.`valorfinal` * `mc`.`quantidade`),2) * (1 + `f`.`valor`))),2),2) AS `novoValorVarejoConsulta`,round((round(sum((round((`t1`.`valorfinal` * `mc`.`quantidade`),2) * (1 + `f`.`valor`))),2) * `OBTEMMULTIPLICADORJUROS`()),2) AS `novoValorVarejo` from (((`vinculomercadoriacomponentecusto` `mc` join `componentecusto_valorfinal` `t1`) join `faixa` `f`) join `mercadoria` `m`) where ((`mc`.`componentecusto` = `t1`.`codigo`) and (`m`.`referencia` = `mc`.`mercadoria`) and (`m`.`faixa` = `f`.`faixa`) and (`f`.`setor` = 1)) group by `mc`.`mercadoria` order by `m`.`referencia` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `novos_coeficientes`
--

/*!50001 DROP VIEW IF EXISTS `novos_coeficientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `novos_coeficientes` AS select 1 AS `tabela`,`novosPrecosVarejo`.`mercadoria` AS `mercadoria`,`novosPrecosVarejo`.`novoValorVarejo` AS `coeficiente` from `novosPrecosVarejo` union select 5 AS `tabela`,`novosPrecosVarejo`.`mercadoria` AS `mercadoria`,`novosPrecosVarejo`.`novoValorVarejoConsulta` AS `coeficiente` from `novosPrecosVarejo` union select 2 AS `tabela`,`n`.`mercadoria` AS `mercadoria`,`n`.`novoIndiceAtacado` AS `coeficiente` from (`novosPrecos` `n` join `mercadoria` `m` on((`n`.`mercadoria` = `m`.`referencia`))) where (`m`.`depeso` = 0) union select 3 AS `tabela`,`n`.`mercadoria` AS `mercadoria`,`n`.`novoIndiceAtacado` AS `coeficiente` from (`novosPrecos` `n` join `mercadoria` `m` on((`n`.`mercadoria` = `m`.`referencia`))) where (`m`.`depeso` = 0) union select 4 AS `tabela`,`n`.`mercadoria` AS `mercadoria`,`n`.`novoIndiceAtacado` AS `coeficiente` from (`novosPrecos` `n` join `mercadoria` `m` on((`n`.`mercadoria` = `m`.`referencia`))) where (`m`.`depeso` = 0) union select 6 AS `tabela`,`n`.`mercadoria` AS `mercadoria`,`n`.`novoIndiceAtacado` AS `coeficiente` from (`novosPrecos` `n` join `mercadoria` `m` on((`n`.`mercadoria` = `m`.`referencia`))) where (`m`.`depeso` = 0) union select `g`.`tabela` AS `tabela`,`m`.`referencia` AS `referencia`,`g`.`valor` AS `coeficiente` from (`mercadoria` `m` join `grama` `g` on(((`m`.`faixa` = `g`.`faixa`) and (`m`.`grupo` = `g`.`grupo`)))) where ((`m`.`depeso` = 1) and (`g`.`tabela` <> 1) and (`g`.`tabela` <> 5)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vendasintetizada`
--

/*!50001 DROP VIEW IF EXISTS `vendasintetizada`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `vendasintetizada` AS (select `v`.`codigo` AS `codigo`,`v`.`controle` AS `controle`,`v`.`valortotal` AS `valortotal`,`vendedor`.`nome` AS `nome`,`cliente`.`nome` AS `cliente`,`v`.`data` AS `data`,`vendedor`.`codigo` AS `vendedorcod`,`cliente`.`codigo` AS `clientecod`,`v`.`taxajuros` AS `taxajuros`,`v`.`cotacao` AS `cotacao` from ((`venda` `v` left join `pessoa` `cliente` on((`v`.`cliente` = `cliente`.`codigo`))) left join `pessoa` `vendedor` on((`v`.`vendedor` = `vendedor`.`codigo`))) where (`v`.`valortotal` is not null)) union (select `v`.`codigo` AS `codigo`,`v`.`controle` AS `controle`,sum(((`i`.`quantidade` * `i`.`indice`) * `v`.`cotacao`)) AS `valorTotal`,`vendedor`.`nome` AS `nome`,`cliente`.`nome` AS `cliente`,`v`.`data` AS `data`,`vendedor`.`codigo` AS `vendedorcod`,`cliente`.`codigo` AS `clientecod`,`v`.`taxajuros` AS `taxajuros`,`v`.`cotacao` AS `cotacao` from (((`venda` `v` left join `vendaitem` `i` on((`v`.`codigo` = `i`.`venda`))) left join `pessoa` `cliente` on((`v`.`cliente` = `cliente`.`codigo`))) left join `pessoa` `vendedor` on((`v`.`vendedor` = `vendedor`.`codigo`))) where isnull(`v`.`valortotal`) group by `v`.`codigo`) order by `data` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-04-22 15:35:19
