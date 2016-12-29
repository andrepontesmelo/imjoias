-- mysqldump --routines --no-data -u root -p  --opt imjoias -d --single-transaction | sed 's/ AUTO_INCREMENT=[0-9]*\b//'  | sed 's/![0-9]*\b//' | sed 's/\/\*//'  | sed 's/*\///' > db_schema.sql
--
-- MySQL dump 10.16  Distrib 10.1.20-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: localhost
-- ------------------------------------------------------
-- Server version	10.1.20-MariaDB

 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT ;
 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS ;
 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION ;
 SET NAMES utf8 ;
 SET @OLD_TIME_ZONE=@@TIME_ZONE ;
 SET TIME_ZONE='+00:00' ;
 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 ;
 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 ;
 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' ;
 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 ;

--
-- Table structure for table `acertoconsignado`
--

DROP TABLE IF EXISTS `acertoconsignado`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `agenda`
--

DROP TABLE IF EXISTS `agenda`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `album`
--

DROP TABLE IF EXISTS `album`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `album` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `criacao` datetime NOT NULL,
  `alteracao` datetime DEFAULT NULL,
  `descricao` text NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `IDX_ALBUM_NOME` (`nome`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `balanco`
--

DROP TABLE IF EXISTS `balanco`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `bug`
--

DROP TABLE IF EXISTS `bug`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='relatório de erros';
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `bugs_pendentes`
--

DROP TABLE IF EXISTS `bugs_pendentes`;
 DROP VIEW IF EXISTS `bugs_pendentes`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `bugs_pendentes` (
  `codigo` tinyint NOT NULL,
  `primeiraData` tinyint NOT NULL,
  `ultimaData` tinyint NOT NULL,
  `ocorrencias` tinyint NOT NULL,
  `message` tinyint NOT NULL,
  `targetsite` tinyint NOT NULL,
  `source` tinyint NOT NULL,
  `stacktrace` tinyint NOT NULL,
  `corrigido` tinyint NOT NULL,
  `correcaoAutor` tinyint NOT NULL,
  `correcaoData` tinyint NOT NULL,
  `correcaoComentarios` tinyint NOT NULL,
  `ignorar` tinyint NOT NULL,
  `innerException` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `cep`
--

DROP TABLE IF EXISTS `cep`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `cep` (
  `cep` char(9) NOT NULL,
  `localidade` int(10) unsigned NOT NULL,
  `logradouro` varchar(255) DEFAULT NULL,
  `bairro` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`cep`),
  KEY `FK_cep_localidade` (`localidade`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED COMMENT='InnoDB free: 280576 kB; (`localidade`) REFER `imjoias/locali' DATA DIRECTORY='/var/lib/mysql_hd/';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `cheque`
--

DROP TABLE IF EXISTS `cheque`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `cheque` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `vencimento` datetime NOT NULL DEFAULT '2001-01-01 00:00:00',
  `cpf` varchar(45) DEFAULT NULL,
  `deTerceiro` tinyint(1) NOT NULL,
  `prorrogadopara` datetime DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `cheque_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `classpessoa`
--

DROP TABLE IF EXISTS `classpessoa`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Classificação de pessoas';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `comissao`
--

DROP TABLE IF EXISTS `comissao`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `comissao` (
  `codigo` int(10) NOT NULL AUTO_INCREMENT,
  `descricao` text,
  `pago` tinyint(1) NOT NULL DEFAULT '0',
  `mes` date NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `comissao_qtdestorno`
--

DROP TABLE IF EXISTS `comissao_qtdestorno`;
 DROP VIEW IF EXISTS `comissao_qtdestorno`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `comissao_qtdestorno` (
  `venda` tinyint NOT NULL,
  `pessoa` tinyint NOT NULL,
  `qtdEstorno` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `comissao_qtdvenda`
--

DROP TABLE IF EXISTS `comissao_qtdvenda`;
 DROP VIEW IF EXISTS `comissao_qtdvenda`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `comissao_qtdvenda` (
  `venda` tinyint NOT NULL,
  `pessoa` tinyint NOT NULL,
  `qtdVenda` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `comissao_saldo`
--

DROP TABLE IF EXISTS `comissao_saldo`;
 DROP VIEW IF EXISTS `comissao_saldo`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `comissao_saldo` (
  `venda` tinyint NOT NULL,
  `pessoa` tinyint NOT NULL,
  `saldo` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `comissao_semaforo`
--

DROP TABLE IF EXISTS `comissao_semaforo`;
 DROP VIEW IF EXISTS `comissao_semaforo`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `comissao_semaforo` (
  `venda` tinyint NOT NULL,
  `semaforo` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `comissao_semaforo_multiplo`
--

DROP TABLE IF EXISTS `comissao_semaforo_multiplo`;
 DROP VIEW IF EXISTS `comissao_semaforo_multiplo`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `comissao_semaforo_multiplo` (
  `venda` tinyint NOT NULL,
  `semaforo` tinyint NOT NULL,
  `descricao` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `comissao_valor`
--

DROP TABLE IF EXISTS `comissao_valor`;
 DROP VIEW IF EXISTS `comissao_valor`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `comissao_valor` (
  `cliente` tinyint NOT NULL,
  `vendedor` tinyint NOT NULL,
  `comissaopara` tinyint NOT NULL,
  `venda` tinyint NOT NULL,
  `vendaitem` tinyint NOT NULL,
  `vendadevolucao` tinyint NOT NULL,
  `referencia` tinyint NOT NULL,
  `faixa` tinyint NOT NULL,
  `setor` tinyint NOT NULL,
  `tipo` tinyint NOT NULL,
  `regra` tinyint NOT NULL,
  `valorc` tinyint NOT NULL,
  `valorv` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `comissao_venda`
--

DROP TABLE IF EXISTS `comissao_venda`;
 DROP VIEW IF EXISTS `comissao_venda`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `comissao_venda` (
  `cliente` tinyint NOT NULL,
  `vendedor` tinyint NOT NULL,
  `comissaopara` tinyint NOT NULL,
  `venda` tinyint NOT NULL,
  `setor` tinyint NOT NULL,
  `tipo` tinyint NOT NULL,
  `regra` tinyint NOT NULL,
  `valorc` tinyint NOT NULL,
  `valorv` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `comissaoestornovenda`
--

DROP TABLE IF EXISTS `comissaoestornovenda`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `comissaosetorfaixa`
--

DROP TABLE IF EXISTS `comissaosetorfaixa`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `comissaosetorfaixa` (
  `setor` int(10) unsigned NOT NULL,
  `faixa` varchar(1) NOT NULL,
  `valor` double DEFAULT NULL,
  PRIMARY KEY (`setor`,`faixa`),
  CONSTRAINT `fk_comissaosetorfaixa_1` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `comissaovenda`
--

DROP TABLE IF EXISTS `comissaovenda`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `componente`
--

DROP TABLE IF EXISTS `componente`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `componente` (
  `codigo` varchar(2) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `componentecusto`
--

DROP TABLE IF EXISTS `componentecusto`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `componentecusto` (
  `codigo` varchar(2) NOT NULL DEFAULT '',
  `multiplicarcomponentecusto` varchar(10) DEFAULT NULL,
  `valor` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  CONSTRAINT `componentecusto_componente_FK` FOREIGN KEY (`codigo`) REFERENCES `componente` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `componentecusto_valorfinal`
--

DROP TABLE IF EXISTS `componentecusto_valorfinal`;
 DROP VIEW IF EXISTS `componentecusto_valorfinal`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `componentecusto_valorfinal` (
  `codigo` tinyint NOT NULL,
  `valorfinal` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `config-globais`
--

DROP TABLE IF EXISTS `config-globais`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `config-globais` (
  `chave` varchar(255) NOT NULL,
  `valor` varchar(255) NOT NULL,
  PRIMARY KEY (`chave`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `configuracoes`
--

DROP TABLE IF EXISTS `configuracoes`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `configuracoes` (
  `chave` varchar(255) NOT NULL DEFAULT '',
  `valor` varchar(255) NOT NULL DEFAULT '',
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`chave`,`pessoa`),
  KEY `fk_configuracoes_1_idx` (`pessoa`),
  CONSTRAINT `fk_configuracoes_1` FOREIGN KEY (`pessoa`) REFERENCES `funcionario` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `cotacao`
--

DROP TABLE IF EXISTS `cotacao`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `credito`
--

DROP TABLE IF EXISTS `credito`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `credito` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pessoa` int(10) unsigned NOT NULL,
  `valor` double NOT NULL,
  `data` datetime NOT NULL,
  `descricao` tinytext NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_credito_1_idx` (`pessoa`),
  CONSTRAINT `fk_credito_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='gasto nesta venda';
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `devedores`
--

DROP TABLE IF EXISTS `devedores`;
 DROP VIEW IF EXISTS `devedores`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `devedores` (
  `codigo` tinyint NOT NULL,
  `nome` tinyint NOT NULL,
  `sum(valor)` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `dinheiro`
--

DROP TABLE IF EXISTS `dinheiro`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `dinheiro` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `dinheiro_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `dolar`
--

DROP TABLE IF EXISTS `dolar`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `dolar` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `valorEmDolar` double NOT NULL,
  `cotacao` double NOT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `dolar_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS `endereco`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `entrada`
--

DROP TABLE IF EXISTS `entrada`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `entradafabricacaofiscal`
--

DROP TABLE IF EXISTS `entradafabricacaofiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `entradafabricacaofiscal` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `fabricacaofiscal` int(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  `referencia` varchar(11) NOT NULL,
  `valor` decimal(8,2) NOT NULL,
  `cfop` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  KEY `fk_entradafabricacaofiscal_fabricacaofiscal` (`fabricacaofiscal`),
  CONSTRAINT `fk_entradafabricacaofiscal_fabricacao` FOREIGN KEY (`fabricacaofiscal`) REFERENCES `fabricacaofiscal` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `entradafiscal`
--

DROP TABLE IF EXISTS `entradafiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `entradafiscal` (
  `id` varchar(49) NOT NULL,
  `dataemissao` datetime NOT NULL,
  `valortotal` decimal(8,2) NOT NULL,
  `numero` int(11) DEFAULT NULL,
  `cnpjemitente` varchar(18) DEFAULT NULL,
  `tipo` int(11) NOT NULL,
  `observacoes` mediumtext NOT NULL,
  `dataentrada` datetime NOT NULL,
  `subtotal` decimal(8,2) NOT NULL DEFAULT '0.00',
  `desconto` decimal(8,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  KEY `entradafiscal_tipodocumentofiscal_FK` (`tipo`),
  KEY `idx_data_entrada` (`dataentrada`),
  CONSTRAINT `entradafiscal_tipodocumentofiscal_FK` FOREIGN KEY (`tipo`) REFERENCES `tipodocumentofiscal` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `entradafiscalpdf`
--

DROP TABLE IF EXISTS `entradafiscalpdf`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `entradafiscalpdf` (
  `id` varchar(49) NOT NULL,
  `pdf` mediumblob NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `FK_entradafiscalpdf_entradafiscal` FOREIGN KEY (`id`) REFERENCES `entradafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `entradaitem`
--

DROP TABLE IF EXISTS `entradaitem`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `entradaitemfiscal`
--

DROP TABLE IF EXISTS `entradaitemfiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `entradaitemfiscal` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `descricao` tinytext NOT NULL,
  `cfop` int(11) DEFAULT NULL,
  `tipounidade` int(11) DEFAULT NULL,
  `quantidade` decimal(8,2) NOT NULL,
  `valorunitario` decimal(8,2) NOT NULL,
  `valor` decimal(8,2) NOT NULL,
  `entradafiscal` varchar(49) DEFAULT NULL,
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`codigo`),
  KEY `fk_entradaitemfiscal_1_idx` (`entradafiscal`),
  KEY `fk_entradaitemfiscal_2_idx` (`tipounidade`),
  KEY `index4` (`referencia`),
  CONSTRAINT `fk_entradaitemfiscal_1` FOREIGN KEY (`entradafiscal`) REFERENCES `entradafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_entradaitemfiscal_2` FOREIGN KEY (`tipounidade`) REFERENCES `tipounidadefiscal` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `esquemafabricacaofiscal`
--

DROP TABLE IF EXISTS `esquemafabricacaofiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `esquemafabricacaofiscal` (
  `referencia` varchar(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  `fechamento` int(11) NOT NULL,
  PRIMARY KEY (`referencia`,`fechamento`),
  KEY `fk_esquemafabricacaofiscal_fechamento_idx` (`fechamento`),
  CONSTRAINT `fk_esquemafabricacaofiscal_fechamento` FOREIGN KEY (`fechamento`) REFERENCES `fechamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `estado`
--

DROP TABLE IF EXISTS `estado`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Endereço: Estado';
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `estoque_extrato`
--

DROP TABLE IF EXISTS `estoque_extrato`;
 DROP VIEW IF EXISTS `estoque_extrato`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `estoque_extrato` (
  `data` tinyint NOT NULL,
  `nome` tinyint NOT NULL,
  `referencia` tinyint NOT NULL,
  `peso` tinyint NOT NULL,
  `entrada` tinyint NOT NULL,
  `venda` tinyint NOT NULL,
  `devolucao` tinyint NOT NULL,
  `operacao` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `estoque_saldo`
--

DROP TABLE IF EXISTS `estoque_saldo`;
 DROP VIEW IF EXISTS `estoque_saldo`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `estoque_saldo` (
  `referencia` tinyint NOT NULL,
  `peso` tinyint NOT NULL,
  `entrada` tinyint NOT NULL,
  `venda` tinyint NOT NULL,
  `devolucao` tinyint NOT NULL,
  `saldo` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `estoquelegado`
--

DROP TABLE IF EXISTS `estoquelegado`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `estoquelegado` (
  `estoque1` decimal(10,2) NOT NULL,
  `estoque2` decimal(10,2) NOT NULL,
  `estoque3` decimal(10,2) NOT NULL,
  `estoqueanterior` decimal(10,2) NOT NULL,
  `referencia` varchar(11) NOT NULL,
  PRIMARY KEY (`referencia`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `etiquetaformato`
--

DROP TABLE IF EXISTS `etiquetaformato`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `etiquetaformato` (
  `formato` varchar(50) NOT NULL DEFAULT '',
  `autor` varchar(100) NOT NULL DEFAULT '',
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `configuracao` text NOT NULL,
  PRIMARY KEY (`formato`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `etiquetamercadoria`
--

DROP TABLE IF EXISTS `etiquetamercadoria`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `etiquetamercadoria` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `formato` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`referencia`),
  KEY `IDX_EtiquetaMercadoria_Formato` (`formato`),
  CONSTRAINT `fk_etiquetamercadoria_1` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `extratoinventario`
--

DROP TABLE IF EXISTS `extratoinventario`;
 DROP VIEW IF EXISTS `extratoinventario`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `extratoinventario` (
  `tipodocumento` tinyint NOT NULL,
  `tipoextrato` tinyint NOT NULL,
  `referencia` tinyint NOT NULL,
  `data` tinyint NOT NULL,
  `quantidade` tinyint NOT NULL,
  `valor` tinyint NOT NULL,
  `cfop` tinyint NOT NULL,
  `idpai` tinyint NOT NULL,
  `idfilho` tinyint NOT NULL,
  `fabricacao` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `fabricacaofiscal`
--

DROP TABLE IF EXISTS `fabricacaofiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `fabricacaofiscal` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `faixa`
--

DROP TABLE IF EXISTS `faixa`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `faixa` (
  `faixa` char(1) NOT NULL DEFAULT '',
  `setor` int(10) unsigned NOT NULL DEFAULT '0',
  `valor` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`faixa`,`setor`),
  KEY `IDX_Faixa_Faixa` (`faixa`),
  KEY `fk_faixa_1_idx` (`setor`),
  CONSTRAINT `fk_faixa_1` FOREIGN KEY (`setor`) REFERENCES `tabela` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `fechamento`
--

DROP TABLE IF EXISTS `fechamento`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `fechamento` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `inicio` datetime NOT NULL,
  `fim` datetime NOT NULL,
  `fechado` tinyint(4) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `fiscal_cfop`
--

DROP TABLE IF EXISTS `fiscal_cfop`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `fiscal_cfop` (
  `codigo` int(11) NOT NULL,
  `descricao` varchar(473) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `fiscal_municipioibge`
--

DROP TABLE IF EXISTS `fiscal_municipioibge`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `fiscal_municipioibge` (
  `localidade` int(10) unsigned NOT NULL,
  `codigo` int(10) unsigned NOT NULL,
  PRIMARY KEY (`localidade`,`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `fornecedor`
--

DROP TABLE IF EXISTS `fornecedor`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `fornecedor` (
  `codigo` int(10) unsigned NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `foto`
--

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
  PRIMARY KEY (`codigo`),
  KEY `idx_foto_mercadoria` (`mercadoria`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 DATA DIRECTORY='/var/lib/mysql_hd/';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `geracaotabela`
--

DROP TABLE IF EXISTS `geracaotabela`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `geracaotabela` (
  `data` datetime NOT NULL,
  `funcionario` int(10) unsigned NOT NULL,
  `ouro` decimal(10,2) NOT NULL,
  `juros` decimal(10,2) DEFAULT NULL,
  KEY `dolarGeracaoPrecos_funcionario_FK` (`funcionario`),
  KEY `dolarGeracaoPrecos_data_IDX` (`data`),
  CONSTRAINT `dolarGeracaoPrecos_funcionario_FK` FOREIGN KEY (`funcionario`) REFERENCES `funcionario` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `grama`
--

DROP TABLE IF EXISTS `grama`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `grupopessoa`
--

DROP TABLE IF EXISTS `grupopessoa`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `grupopessoa` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `grupo` varchar(50) NOT NULL DEFAULT '',
  `flags` int(10) unsigned NOT NULL DEFAULT '0',
  `descricao` tinytext,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_Grupo` (`grupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `historico`
--

DROP TABLE IF EXISTS `historico`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `horariofuncionario`
--

DROP TABLE IF EXISTS `horariofuncionario`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `inventario_interno`
--

DROP TABLE IF EXISTS `inventario_interno`;
 DROP VIEW IF EXISTS `inventario_interno`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `inventario_interno` (
  `referencia` tinyint NOT NULL,
  `data` tinyint NOT NULL,
  `quantidade` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `inventario_interno_parcial`
--

DROP TABLE IF EXISTS `inventario_interno_parcial`;
 DROP VIEW IF EXISTS `inventario_interno_parcial`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `inventario_interno_parcial` (
  `referencia` tinyint NOT NULL,
  `data` tinyint NOT NULL,
  `quantidade` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `inventario_parcial`
--

DROP TABLE IF EXISTS `inventario_parcial`;
 DROP VIEW IF EXISTS `inventario_parcial`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `inventario_parcial` (
  `referencia` tinyint NOT NULL,
  `quantidade` tinyint NOT NULL,
  `nome` tinyint NOT NULL,
  `classificacaofiscal` tinyint NOT NULL,
  `tipounidade` tinyint NOT NULL,
  `valor` tinyint NOT NULL,
  `valortotal` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `localidade`
--

DROP TABLE IF EXISTS `localidade`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED COMMENT='Endereço: Localidade';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `maquinafiscal`
--

DROP TABLE IF EXISTS `maquinafiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `maquinafiscal` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `modelo` varchar(45) DEFAULT NULL,
  `fabricacao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `index2` (`modelo`,`fabricacao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `materiaprima`
--

DROP TABLE IF EXISTS `materiaprima`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `materiaprima` (
  `referencia` varchar(11) NOT NULL,
  `valor` decimal(8,2) NOT NULL,
  PRIMARY KEY (`referencia`),
  CONSTRAINT `fk_materiaprima_referencia` FOREIGN KEY (`referencia`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `materiaprimaesquemafabricacaofiscal`
--

DROP TABLE IF EXISTS `materiaprimaesquemafabricacaofiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `materiaprimaesquemafabricacaofiscal` (
  `esquema` varchar(11) NOT NULL,
  `materiaprima` varchar(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  `fechamento` int(11) NOT NULL,
  `proporcional` tinyint(4) DEFAULT '0',
  UNIQUE KEY `unique_materiaprimaesquemafabricacao` (`esquema`,`materiaprima`,`fechamento`),
  KEY `fk_materiaprimaesquemafabricacaofiscal_fechamento_idx` (`fechamento`),
  KEY `idx_materiaprimaesquema_materiaprima` (`materiaprima`),
  CONSTRAINT `fk_materiaprimaesquemafabricacaofiscal_fechamento` FOREIGN KEY (`fechamento`) REFERENCES `fechamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `mercadoria`
--

DROP TABLE IF EXISTS `mercadoria`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
  `classificacaofiscal` varchar(45) NOT NULL DEFAULT '0',
  `tipounidade` int(11) NOT NULL DEFAULT '1',
  `cfop` int(11) NOT NULL DEFAULT '5101',
  PRIMARY KEY (`referencia`),
  KEY `IDX_Mercadoria_Faixa` (`faixa`),
  KEY `idx_mercadoria_peso` (`peso`),
  KEY `idx_mercadoria_digito` (`digito`),
  KEY `idx_mercadoria_foradelinha` (`foradelinha`),
  KEY `idx_mercadoria_depeso` (`depeso`),
  KEY `fk_mercadoria_tipounidade_idx` (`tipounidade`),
  CONSTRAINT `fk_mercadoria_tipounidade` FOREIGN KEY (`tipounidade`) REFERENCES `tipounidadefiscal` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `mercadoria_fiscal`
--

DROP TABLE IF EXISTS `mercadoria_fiscal`;
 DROP VIEW IF EXISTS `mercadoria_fiscal`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `mercadoria_fiscal` (
  `referencia` tinyint NOT NULL,
  `descricao` tinyint NOT NULL,
  `valor` tinyint NOT NULL,
  `peso` tinyint NOT NULL,
  `depeso` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `mercadoriafechamento`
--

DROP TABLE IF EXISTS `mercadoriafechamento`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `mercadoriafechamento` (
  `referencia` varchar(11) NOT NULL,
  `descricao` varchar(100) DEFAULT NULL,
  `valor` decimal(8,2) DEFAULT NULL,
  `fechamento` int(11) NOT NULL,
  `peso` decimal(8,2) NOT NULL,
  `depeso` tinyint(1) NOT NULL DEFAULT '0',
  UNIQUE KEY `idx_mercadoriafechamento_unica` (`referencia`,`fechamento`),
  KEY `fk_mercadoriafechamento_fechamento_idx` (`fechamento`),
  CONSTRAINT `fk_mercadoriafechamento_fechamento` FOREIGN KEY (`fechamento`) REFERENCES `fechamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `mercadoriamapeamento`
--

DROP TABLE IF EXISTS `mercadoriamapeamento`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `mercadoriamapeamento` (
  `referencia` varchar(11) NOT NULL DEFAULT '',
  `codigo` int(11) NOT NULL DEFAULT '0',
  `obsoleto` tinyint(1) NOT NULL DEFAULT '0',
  `peso` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`,`peso`),
  KEY `IDX_MercadoriaMapeamento_Referencia` (`referencia`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `mercadoriapedra`
--

DROP TABLE IF EXISTS `mercadoriapedra`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `mercadoriapedra` (
  `codigo` char(2) NOT NULL,
  `pedra` int(10) unsigned NOT NULL,
  PRIMARY KEY (`codigo`,`pedra`),
  KEY `FK_mercadoriapedra_pedra` (`pedra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `mercadoriatipo`
--

DROP TABLE IF EXISTS `mercadoriatipo`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `mercadoriatipo` (
  `codigo` char(2) NOT NULL COMMENT 'Digitos 2 e 3',
  `tipo` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `metal`
--

DROP TABLE IF EXISTS `metal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `metal` (
  `codigo` char(1) NOT NULL COMMENT '9o digito',
  `metal` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `moeda`
--

DROP TABLE IF EXISTS `moeda`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `moeda` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `sistema` tinyint(1) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `componenteCusto` varchar(2) DEFAULT NULL,
  `icone` mediumblob,
  `casasDecimais` tinyint(1) unsigned NOT NULL DEFAULT '2',
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `idx_moeda_nome` (`nome`),
  UNIQUE KEY `idx_moeda_componentecusto` (`componenteCusto`),
  CONSTRAINT `moeda_componente_FK` FOREIGN KEY (`componenteCusto`) REFERENCES `componente` (`codigo`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `nfe`
--

DROP TABLE IF EXISTS `nfe`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `notapromissoria`
--

DROP TABLE IF EXISTS `notapromissoria`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `notapromissoria` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `vencimento` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `prorrogadopara` datetime DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `notapromissoria_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `novosPrecos`
--

DROP TABLE IF EXISTS `novosPrecos`;
 DROP VIEW IF EXISTS `novosPrecos`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `novosPrecos` (
  `mercadoria` tinyint NOT NULL,
  `novoIndiceAtacado` tinyint NOT NULL,
  `novoPrecoCusto` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `novosPrecosVarejo`
--

DROP TABLE IF EXISTS `novosPrecosVarejo`;
 DROP VIEW IF EXISTS `novosPrecosVarejo`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `novosPrecosVarejo` (
  `mercadoria` tinyint NOT NULL,
  `novoValorVarejoConsulta` tinyint NOT NULL,
  `novoValorVarejo` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `novos_coeficientes`
--

DROP TABLE IF EXISTS `novos_coeficientes`;
 DROP VIEW IF EXISTS `novos_coeficientes`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `novos_coeficientes` (
  `tabela` tinyint NOT NULL,
  `mercadoria` tinyint NOT NULL,
  `coeficiente` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `novos_coeficientes_varejo`
--

DROP TABLE IF EXISTS `novos_coeficientes_varejo`;
 DROP VIEW IF EXISTS `novos_coeficientes_varejo`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `novos_coeficientes_varejo` (
  `tabela` tinyint NOT NULL,
  `mercadoria` tinyint NOT NULL,
  `coeficiente` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `ouro`
--

DROP TABLE IF EXISTS `ouro`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `ouro` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `peso` double NOT NULL,
  `paraFundir` tinyint(1) NOT NULL,
  `multiplicador` double NOT NULL,
  `cotacao` double NOT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `ouro_FK` FOREIGN KEY (`codigo`) REFERENCES `pagamento` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pagamento`
--

DROP TABLE IF EXISTS `pagamento`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pais`
--

DROP TABLE IF EXISTS `pais`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `pais` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL DEFAULT '',
  `sigla` varchar(10) DEFAULT NULL,
  `ddi` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `Index_pais_nome` (`nome`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Endereço: País';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Pedido e conserto';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pedidoitem`
--

DROP TABLE IF EXISTS `pedidoitem`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pedra`
--

DROP TABLE IF EXISTS `pedra`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `pedra` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `pedra` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
  `regiao` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `IDX_Pessoa_Nome` (`nome`),
  KEY `idx_pessoa_ultimaVisita` (`ultimaVisita`),
  KEY `fk_pessoa_1_idx` (`regiao`),
  KEY `fk_pessoa_2_idx` (`setor`),
  FULLTEXT KEY `fulltext_pessoa_nome` (`nome`),
  FULLTEXT KEY `pessoa_email` (`email`),
  FULLTEXT KEY `pessoa_obs` (`observacoes`),
  CONSTRAINT `fk_pessoa_1` FOREIGN KEY (`regiao`) REFERENCES `regiao` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_pessoa_2` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pessoadatarelevante`
--

DROP TABLE IF EXISTS `pessoadatarelevante`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `pessoadatarelevante` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `data` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `descricao` varchar(100) NOT NULL,
  `alertar` tinyint(1) NOT NULL DEFAULT '1',
  KEY `fk_pessoadatarelevante_1_idx` (`pessoa`),
  CONSTRAINT `fk_pessoadatarelevante_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pessoafisica`
--

DROP TABLE IF EXISTS `pessoafisica`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pessoafoto`
--

DROP TABLE IF EXISTS `pessoafoto`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `pessoafoto` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `foto` blob NOT NULL,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `imjoias/pessoafoto_ibfk_1` FOREIGN KEY (`codigo`) REFERENCES `pessoa` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `pessoajuridica`
--

DROP TABLE IF EXISTS `pessoajuridica`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `pessoajuridica` (
  `codigo` int(10) unsigned NOT NULL DEFAULT '0',
  `cnpj` varchar(18) DEFAULT NULL,
  `fantasia` varchar(100) DEFAULT NULL,
  `inscEstadual` varchar(45) DEFAULT NULL,
  `inscMunicipal` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_PessoaFisica_CNPJ` (`cnpj`),
  KEY `IDX_PessoaJuridica_Fantasia` (`fantasia`),
  FULLTEXT KEY `pessoajuridica_fantasia_fulltext` (`fantasia`),
  CONSTRAINT `fk_pessoajuridica_1` FOREIGN KEY (`codigo`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `regiao`
--

DROP TABLE IF EXISTS `regiao`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `regiao` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL DEFAULT '',
  `observacoes` text,
  `representante` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_Regiao_Nome` (`nome`),
  KEY `fk_regiao_1_idx` (`representante`),
  CONSTRAINT `fk_regiao_1` FOREIGN KEY (`representante`) REFERENCES `representante` (`codigo`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Endereço: Região';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `representante`
--

DROP TABLE IF EXISTS `representante`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `representante` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`codigo`),
  CONSTRAINT `fk_representante_1` FOREIGN KEY (`codigo`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `retorno`
--

DROP TABLE IF EXISTS `retorno`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 125952 kB; (`funcionario`) REFER `imjoias';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `retornoitem`
--

DROP TABLE IF EXISTS `retornoitem`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `saida`
--

DROP TABLE IF EXISTS `saida`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `saidafabricacaofiscal`
--

DROP TABLE IF EXISTS `saidafabricacaofiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `saidafabricacaofiscal` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `fabricacaofiscal` int(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  `referencia` varchar(11) NOT NULL,
  `valor` decimal(8,2) NOT NULL,
  `cfop` int(11) NOT NULL DEFAULT '0',
  `peso` decimal(10,2) NOT NULL DEFAULT '0.00',
  `quantidadeextrato` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_saidaproducaofiscal_fabricacaofiscal` (`fabricacaofiscal`),
  CONSTRAINT `fk_saidaproducaofiscal_1` FOREIGN KEY (`fabricacaofiscal`) REFERENCES `fabricacaofiscal` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `saidafiscal`
--

DROP TABLE IF EXISTS `saidafiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
  `cliente` int(10) unsigned DEFAULT NULL,
  `fabricacao` int(11) DEFAULT NULL,
  `subtotal` decimal(8,2) NOT NULL DEFAULT '0.00',
  `desconto` decimal(8,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  KEY `saidafiscal_tipodocumentofiscal_FK` (`tipo`),
  KEY `saidafiscal_setor_FK` (`setor`),
  KEY `fk_saidafiscal_1_idx` (`maquina`),
  KEY `index5` (`cancelada`),
  KEY `index6` (`datasaida`),
  KEY `fk_saidafiscal_cliente_idx` (`cliente`),
  KEY `fk_saidafiscal_fabricacao_idx` (`fabricacao`),
  CONSTRAINT `fk_saidafiscal_1` FOREIGN KEY (`maquina`) REFERENCES `maquinafiscal` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fk_saidafiscal_cliente` FOREIGN KEY (`cliente`) REFERENCES `pessoa` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_saidafiscal_fabricacao` FOREIGN KEY (`fabricacao`) REFERENCES `fabricacaofiscal` (`codigo`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `saidafiscal_setor_FK` FOREIGN KEY (`setor`) REFERENCES `setor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `saidafiscal_tipodocumentofiscal_FK` FOREIGN KEY (`tipo`) REFERENCES `tipodocumentofiscal` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `saidafiscalpdf`
--

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

--
-- Table structure for table `saidaitem`
--

DROP TABLE IF EXISTS `saidaitem`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPRESSED;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `saidaitemfiscal`
--

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
  CONSTRAINT `fk_saidaitemfiscal_saidafiscal` FOREIGN KEY (`saidafiscal`) REFERENCES `saidafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_saidaitemfiscal_tipounidade` FOREIGN KEY (`tipounidade`) REFERENCES `tipounidadefiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `setor`
--

DROP TABLE IF EXISTS `setor`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `setor` (
  `codigo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL DEFAULT '',
  `atendimento` tinyint(1) NOT NULL DEFAULT '0',
  `empresa` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IDX_Setor_Nome` (`nome`),
  KEY `IDX_Setor_Empresa` (`empresa`),
  KEY `Idx_Setor_Atendimento` (`atendimento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 62464 kB; (`empresa`) REFER `imjoias/pessoajuri';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `tabela`
--

DROP TABLE IF EXISTS `tabela`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `tabelamercadoria`
--

DROP TABLE IF EXISTS `tabelamercadoria`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `tabelamercadoria` (
  `tabela` int(10) unsigned NOT NULL,
  `mercadoria` varchar(11) NOT NULL,
  `coeficiente` double unsigned NOT NULL,
  PRIMARY KEY (`tabela`,`mercadoria`),
  KEY `fk_tabelamercadoria_2_idx` (`mercadoria`),
  CONSTRAINT `fk_tabelamercadoria_1` FOREIGN KEY (`tabela`) REFERENCES `tabela` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_tabelamercadoria_2` FOREIGN KEY (`mercadoria`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `telefone`
--

DROP TABLE IF EXISTS `telefone`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `telefone` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `id` int(10) unsigned NOT NULL DEFAULT '0',
  `descricao` varchar(45) NOT NULL DEFAULT '',
  `telefone` varchar(32) NOT NULL,
  `observacoes` text,
  PRIMARY KEY (`pessoa`,`id`),
  CONSTRAINT `fk_telefone_1` FOREIGN KEY (`pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `telefonemanomefuncionario`
--

DROP TABLE IF EXISTS `telefonemanomefuncionario`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `telefonemanomenome`
--

DROP TABLE IF EXISTS `telefonemanomenome`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `tipodocumentofiscal`
--

DROP TABLE IF EXISTS `tipodocumentofiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `tipodocumentofiscal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) DEFAULT NULL,
  `entrada` tinyint(1) DEFAULT NULL,
  `saida` tinyint(1) DEFAULT NULL,
  `nomeresumido` varchar(3) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `tipounidadefiscal`
--

DROP TABLE IF EXISTS `tipounidadefiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `tipounidadefiscal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `tmp`
--

DROP TABLE IF EXISTS `tmp`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `tmp` (
  `codigo` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `utilizacao`
--

DROP TABLE IF EXISTS `utilizacao`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `utilizacao` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(100) NOT NULL DEFAULT '',
  `quando` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `aplicacao` int(11) NOT NULL DEFAULT '0',
  `parametros` tinytext,
  PRIMARY KEY (`codigo`),
  KEY `IDX_UTILIZACAO_APLICACAO` (`aplicacao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='InnoDB free: 855040 kB; (`acerto`) REFER `imjoias/acertocons';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vendacredito`
--

DROP TABLE IF EXISTS `vendacredito`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vendadebito`
--

DROP TABLE IF EXISTS `vendadebito`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Debitos da venda';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vendadevolucao`
--

DROP TABLE IF EXISTS `vendadevolucao`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='InnoDB free: 198656 kB; (`venda`) REFER `imjoias-desenv/vend';
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vendafiscal`
--

DROP TABLE IF EXISTS `vendafiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vendafiscal` (
  `id` varchar(49) NOT NULL,
  `dataemissao` datetime NOT NULL,
  `tipovenda` varchar(1) NOT NULL,
  `valortotal` decimal(8,2) NOT NULL,
  `nnf` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nnf_UNIQUE` (`nnf`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vendaitem`
--

DROP TABLE IF EXISTS `vendaitem`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vendaitemfiscal`
--

DROP TABLE IF EXISTS `vendaitemfiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vendaitemfiscal` (
  `referencia` varchar(11) NOT NULL,
  `descricao` varchar(100) NOT NULL,
  `cfop` int(11) DEFAULT NULL,
  `tipounidade` varchar(1) NOT NULL,
  `quantidade` decimal(8,2) NOT NULL,
  `valorunitario` decimal(8,2) NOT NULL,
  `valor` decimal(8,2) NOT NULL,
  `vendafiscal` varchar(49) DEFAULT NULL,
  KEY `fk_vendaitemfiscal_1_idx` (`vendafiscal`),
  CONSTRAINT `fk_vendaitemfiscal_1` FOREIGN KEY (`vendafiscal`) REFERENCES `vendafiscal` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Temporary table structure for view `vendasintetizada`
--

DROP TABLE IF EXISTS `vendasintetizada`;
 DROP VIEW IF EXISTS `vendasintetizada`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
 CREATE TABLE `vendasintetizada` (
  `codigo` tinyint NOT NULL,
  `controle` tinyint NOT NULL,
  `valortotal` tinyint NOT NULL,
  `nome` tinyint NOT NULL,
  `cliente` tinyint NOT NULL,
  `data` tinyint NOT NULL,
  `vendedorcod` tinyint NOT NULL,
  `clientecod` tinyint NOT NULL,
  `taxajuros` tinyint NOT NULL,
  `cotacao` tinyint NOT NULL
) ENGINE=MyISAM ;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `vinculocomissaovenda`
--

DROP TABLE IF EXISTS `vinculocomissaovenda`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vinculocomissaovenda` (
  `comissao` int(11) NOT NULL,
  `venda` int(11) unsigned NOT NULL,
  PRIMARY KEY (`comissao`,`venda`),
  KEY `fk_vinculocomissaovenda_2` (`venda`),
  CONSTRAINT `fk_vinculocomissaovenda_1` FOREIGN KEY (`comissao`) REFERENCES `comissao` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_vinculocomissaovenda_2` FOREIGN KEY (`venda`) REFERENCES `venda` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vinculofotoalbum`
--

DROP TABLE IF EXISTS `vinculofotoalbum`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vinculofotoalbum` (
  `album` int(10) unsigned NOT NULL DEFAULT '0',
  `foto` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`album`,`foto`),
  KEY `Index_vinculofotoalbum_foto` (`foto`),
  CONSTRAINT `fk_vinculofotoalbum_1` FOREIGN KEY (`album`) REFERENCES `album` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vinculogrupopessoa`
--

DROP TABLE IF EXISTS `vinculogrupopessoa`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vinculogrupopessoa` (
  `pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `grupo` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`pessoa`,`grupo`),
  KEY `IDX_VinculoGrupoPessoa_Grupo` (`grupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vinculomercadoriacomponentecusto`
--

DROP TABLE IF EXISTS `vinculomercadoriacomponentecusto`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vinculomercadoriacomponentecusto` (
  `mercadoria` varchar(30) NOT NULL DEFAULT '',
  `componentecusto` varchar(2) NOT NULL DEFAULT '',
  `quantidade` double NOT NULL DEFAULT '0',
  UNIQUE KEY `idx_unico` (`mercadoria`,`componentecusto`),
  KEY `vinculomercadoriacomponentecusto_componentecusto_FK` (`componentecusto`),
  CONSTRAINT `vinculomercadoriacomponentecusto_componentecusto_FK` FOREIGN KEY (`componentecusto`) REFERENCES `componentecusto` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `vinculomercadoriacomponentecusto_mercadoria_FK` FOREIGN KEY (`mercadoria`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vinculomercadoriacomponentefiscal`
--

DROP TABLE IF EXISTS `vinculomercadoriacomponentefiscal`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vinculomercadoriacomponentefiscal` (
  `mercadoria` varchar(30) NOT NULL DEFAULT '',
  `componente` varchar(2) NOT NULL DEFAULT '',
  `quantidade` double NOT NULL DEFAULT '0',
  UNIQUE KEY `idx_unico` (`mercadoria`,`componente`),
  KEY `vinculomercadoriacomponentefiscal_componente_FK` (`componente`),
  CONSTRAINT `vinculomercadoriacomponentefiscal_componente_FK` FOREIGN KEY (`componente`) REFERENCES `componente` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `vinculomercadoriacomponentefiscal_mercadoria_FK` FOREIGN KEY (`mercadoria`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vinculomercadoriafornecedor`
--

DROP TABLE IF EXISTS `vinculomercadoriafornecedor`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vinculomercadoriafornecedor` (
  `mercadoria` varchar(11) NOT NULL,
  `fornecedor` int(10) unsigned NOT NULL,
  `referenciafornecedor` varchar(45) DEFAULT NULL,
  `inicio` datetime NOT NULL DEFAULT '1900-01-01 00:00:00',
  `foradelinha` tinyint(1) NOT NULL DEFAULT '0',
  `peso` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`mercadoria`,`fornecedor`),
  KEY `vinculomercadoriafornecedor_fornecedor_FK` (`fornecedor`),
  CONSTRAINT `FK_vinculomercadoriafornecedor_mercadoria` FOREIGN KEY (`mercadoria`) REFERENCES `mercadoria` (`referencia`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `vinculomercadoriafornecedor_fornecedor_FK` FOREIGN KEY (`fornecedor`) REFERENCES `fornecedor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `vinculopessoasetor`
--

DROP TABLE IF EXISTS `vinculopessoasetor`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `vinculopessoasetor` (
  `Pessoa` int(10) unsigned NOT NULL DEFAULT '0',
  `Setor` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`Pessoa`),
  KEY `IDX_VinculoPessoaSetor_Setor` (`Setor`),
  CONSTRAINT `fk_vinculopessoasetor_1` FOREIGN KEY (`Pessoa`) REFERENCES `pessoa` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_vinculopessoasetor_2` FOREIGN KEY (`Setor`) REFERENCES `setor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `visita`
--

DROP TABLE IF EXISTS `visita`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `visitanome`
--

DROP TABLE IF EXISTS `visitanome`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
CREATE TABLE `visitanome` (
  `visita` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `nome` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`visita`,`nome`),
  KEY `IDX_VisitaNome_Visita` (`visita`),
  KEY `IDX_VisitaNome_Nome` (`nome`),
  CONSTRAINT `fk_visitanome_visita` FOREIGN KEY (`visita`) REFERENCES `visita` (`entrada`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `visitapessoafisica`
--

DROP TABLE IF EXISTS `visitapessoafisica`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Table structure for table `zeragemestoque`
--

DROP TABLE IF EXISTS `zeragemestoque`;
 SET @saved_cs_client     = @@character_set_client ;
 SET character_set_client = utf8 ;
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
 SET character_set_client = @saved_cs_client ;

--
-- Dumping routines for database 'imjoias'
--
 DROP FUNCTION IF EXISTS `d1` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `D1`() RETURNS datetime
    NO SQL
    DETERMINISTIC
return @d1 ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
 DROP FUNCTION IF EXISTS `obtemjuros` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtemjuros`() RETURNS double
    DETERMINISTIC
return @juros ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
 DROP FUNCTION IF EXISTS `obtemmultiplicadorjuros` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtemmultiplicadorjuros`() RETURNS double
    NO SQL
    DETERMINISTIC
return @multiplicadorjuros ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
 DROP FUNCTION IF EXISTS `obtemouro` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `obtemouro`() RETURNS double
    DETERMINISTIC
return @ouro ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
 DROP FUNCTION IF EXISTS `p1` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `p1`() RETURNS decimal(10,2)
    NO SQL
    DETERMINISTIC
return @p1 ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
 DROP FUNCTION IF EXISTS `p2` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `p2`() RETURNS decimal(10,2)
    NO SQL
    DETERMINISTIC
return @p2 ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
 DROP FUNCTION IF EXISTS `ranking_mercadoria` ;
ALTER DATABASE `imjoias` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = ''  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `ranking_mercadoria`(preferencia VARCHAR(45), ppeso DOUBLE) RETURNS double
    READS SQL DATA
return ((select sum(quantidade) from vendaitem where referencia = preferencia AND peso = ppeso) -
  (select sum(quantidade) from vendadevolucao where referencia = preferencia AND peso = ppeso)) /
  (select sum(quantidade) from saidaitem where referencia = preferencia AND peso = ppeso) ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
ALTER DATABASE `imjoias` CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
 DROP PROCEDURE IF EXISTS `atualizarvendas` ;
ALTER DATABASE `imjoias` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = ''  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `atualizarvendas`()
BEGIN
  DECLARE TOTAL integer;
  DECLARE ATUAL integer;

  SET total=(select max(codigo) from venda);
  SET atual = 0;
  WHILE atual < total DO
    call calcularvendavalortotal(atual);  
    SET atual = atual + 1;
  end while;
END ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
ALTER DATABASE `imjoias` CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
 DROP PROCEDURE IF EXISTS `calcularcomissao` ;
ALTER DATABASE `imjoias` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = ''  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `calcularcomissao`()
BEGIN

update venda,
(select c.codigo, c.comissaovenda-c.comissaodevolucao as comissao from
(
select a.codigo, ifnull(comissaovenda,0) as comissaovenda, ifnull(comissaodevolucao,0) as comissaodevolucao

from
(

select venda.codigo,
sum(vendaitem.indice * vendaitem.quantidade * venda.cotacao * if(mercadoria.depeso,  0.05, 0.10)) as comissaovenda

from venda
left join vendaitem on venda.codigo=vendaitem.venda
left join mercadoria on vendaitem.referencia=mercadoria.referencia

group by venda.codigo

) a

left join

(

select venda.codigo,
sum(vendadevolucao.indice * vendadevolucao.quantidade * venda.cotacao * if(mercadoria.depeso,  0.05, 0.10)) as comissaodevolucao

from venda
left join vendadevolucao on venda.codigo=vendadevolucao.venda
left join mercadoria on vendadevolucao.referencia=mercadoria.referencia

group by venda.codigo

) b on  a.codigo=b.codigo

) c) d
set venda.comissao=d.comissao where d.codigo=venda.codigo;


END ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
ALTER DATABASE `imjoias` CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
 DROP PROCEDURE IF EXISTS `calcularvendavalortotal` ;
ALTER DATABASE `imjoias` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = ''  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `calcularvendavalortotal`(pcodigo

INTEGER UNSIGNED)
BEGIN

     SET @cotacao := (SELECT cotacao FROM venda WHERE venda.codigo = pcodigo);

     SET @itens := (SELECT SUM( ROUND(ROUND(ROUND(indice, 2) * @cotacao,2)* quantidade,2)) FROM vendaitem WHERE vendaitem.venda = pcodigo);

     SET @devolucao := (SElECT SUM(ROUND(ROUND(ROUND(indice, 2)  * @cotacao,2) * quantidade,2)) FROM vendadevolucao WHERE vendadevolucao.venda = pcodigo);

     SET @desconto := (select desconto from venda WHERE codigo=pcodigo);





     UPDATE venda SET valortotal = IF(@itens IS NULL, 0, @itens)

                                 - IF(@devolucao IS NULL, 0, @devolucao)

                                 - IF(@desconto IS NULL, 0, @desconto)

          WHERE codigo = pcodigo;

END ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
ALTER DATABASE `imjoias` CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
 DROP PROCEDURE IF EXISTS `gerartabela` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `gerartabela`(IN p_funcionario INTEGER, IN p_ouro DECIMAL(10,2), IN p_juros DECIMAL(10,2))
BEGIN
START TRANSACTION;

    set @p1 := p_ouro;
    set @p2 := p_juros;
    
    insert into geracaotabela (data, funcionario, ouro, juros) VALUES (NOW(), p_funcionario, p_ouro, p_juros);
    
    delete from tabelamercadoria;
    insert into tabelamercadoria select * from novos_coeficientes;
    insert into tabelamercadoria select * from novos_coeficientes_varejo;
    
    COMMIT;
 END ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;
 DROP PROCEDURE IF EXISTS `lerParametrosGeracaoPrecos` ;
 SET @saved_cs_client      = @@character_set_client  ;
 SET @saved_cs_results     = @@character_set_results  ;
 SET @saved_col_connection = @@collation_connection  ;
 SET character_set_client  = utf8  ;
 SET character_set_results = utf8  ;
 SET collation_connection  = utf8_general_ci  ;
 SET @saved_sql_mode       = @@sql_mode  ;
 SET sql_mode              = 'NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION'  ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `lerParametrosGeracaoPrecos`()
BEGIN
SET @ouro := (select ouro from geracaotabela order by data desc limit 1);
SET @juros := (select juros from geracaotabela order by data desc limit 1);
END ;;
DELIMITER ;
 SET sql_mode              = @saved_sql_mode  ;
 SET character_set_client  = @saved_cs_client  ;
 SET character_set_results = @saved_cs_results  ;
 SET collation_connection  = @saved_col_connection  ;

--
-- Final view structure for view `bugs_pendentes`
--

 DROP TABLE IF EXISTS `bugs_pendentes`;
 DROP VIEW IF EXISTS `bugs_pendentes`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`%` SQL SECURITY DEFINER 
 VIEW `bugs_pendentes` AS (select `b`.`codigo` AS `codigo`,`b`.`primeiraData` AS `primeiraData`,`b`.`ultimaData` AS `ultimaData`,`b`.`ocorrencias` AS `ocorrencias`,`b`.`message` AS `message`,`b`.`targetsite` AS `targetsite`,`b`.`source` AS `source`,`b`.`stacktrace` AS `stacktrace`,`b`.`corrigido` AS `corrigido`,`b`.`correcaoAutor` AS `correcaoAutor`,`b`.`correcaoData` AS `correcaoData`,`b`.`correcaoComentarios` AS `correcaoComentarios`,`b`.`ignorar` AS `ignorar`,`b`.`innerException` AS `innerException` from `bug` `b` where ((`b`.`corrigido` = 0) and (`b`.`ignorar` = 0)) order by `b`.`ocorrencias` desc,`b`.`ultimaData` desc) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `comissao_qtdestorno`
--

 DROP TABLE IF EXISTS `comissao_qtdestorno`;
 DROP VIEW IF EXISTS `comissao_qtdestorno`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `comissao_qtdestorno` AS select `comissaoestornovenda`.`venda` AS `venda`,`comissaoestornovenda`.`pessoa` AS `pessoa`,count(0) AS `qtdEstorno` from `comissaoestornovenda` group by `comissaoestornovenda`.`venda`,`comissaoestornovenda`.`pessoa` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `comissao_qtdvenda`
--

 DROP TABLE IF EXISTS `comissao_qtdvenda`;
 DROP VIEW IF EXISTS `comissao_qtdvenda`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `comissao_qtdvenda` AS select `comissaovenda`.`venda` AS `venda`,`comissaovenda`.`pessoa` AS `pessoa`,count(0) AS `qtdVenda` from `comissaovenda` group by `comissaovenda`.`venda`,`comissaovenda`.`pessoa` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `comissao_saldo`
--

 DROP TABLE IF EXISTS `comissao_saldo`;
 DROP VIEW IF EXISTS `comissao_saldo`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `comissao_saldo` AS select `a`.`venda` AS `venda`,`a`.`pessoa` AS `pessoa`,(ifnull(`a`.`qtdVenda`,0) - ifnull(`b`.`qtdEstorno`,0)) AS `saldo` from (`comissao_qtdvenda` `a` left join `comissao_qtdestorno` `b` on(((`a`.`venda` = `b`.`venda`) and (`a`.`pessoa` = `b`.`pessoa`)))) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `comissao_semaforo`
--

 DROP TABLE IF EXISTS `comissao_semaforo`;
 DROP VIEW IF EXISTS `comissao_semaforo`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `comissao_semaforo` AS select `comissao_semaforo_multiplo`.`venda` AS `venda`,max(`comissao_semaforo_multiplo`.`semaforo`) AS `semaforo` from `comissao_semaforo_multiplo` group by `comissao_semaforo_multiplo`.`venda` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `comissao_semaforo_multiplo`
--

 DROP TABLE IF EXISTS `comissao_semaforo_multiplo`;
 DROP VIEW IF EXISTS `comissao_semaforo_multiplo`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `comissao_semaforo_multiplo` AS select `v`.`codigo` AS `venda`,5 AS `semaforo`,'nfe' AS `descricao` from (`venda` `v` join `nfe` `n` on((`v`.`codigo` = `n`.`venda`))) union select `v`.`codigo` AS `venda`,3 AS `semaforo`,'comissao_fechada' AS `descricao` from (`venda` `v` join `comissao_saldo` `c` on(((`v`.`codigo` = `c`.`venda`) and (`c`.`saldo` = 1)))) union select `v`.`codigo` AS `venda`,2 AS `semaforo`,'quitado' AS `descricao` from `venda` `v` where (`v`.`quitacao` is not null) union select `v`.`codigo` AS `venda`,0 AS `semaforo`,'nao_quitado' AS `descricao` from `venda` `v` where isnull(`v`.`quitacao`) union select `v`.`codigo` AS `venda`,1 AS `semaforo`,'cobranca' AS `descricao` from `venda` `v` where (isnull(`v`.`quitacao`) and (abs(`v`.`valortotal`) < 0.01)) union select `v`.`codigo` AS `venda`,4 AS `semaforo`,'do_dia' AS `descricao` from `venda` `v` where ((to_days(now()) - to_days(`v`.`data`)) < 1) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `comissao_valor`
--

 DROP TABLE IF EXISTS `comissao_valor`;
 DROP VIEW IF EXISTS `comissao_valor`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `comissao_valor` AS select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,1 AS `setor`,'C0+' AS `tipo`,0 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 1) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,1 AS `setor`,'C0-' AS `tipo`,0 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 1) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C1+' AS `tipo`,1 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` = 2) and isnull(`v`.`acerto`) and (`v`.`tabela` <> 2) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C1-' AS `tipo`,1 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` = 2) and isnull(`v`.`acerto`) and (`v`.`tabela` <> 2) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C2+' AS `tipo`,2 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) left join `representante` `rr` on((`v`.`vendedor` = `rr`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rr`.`codigo`) and (`cli`.`setor` = 2) and ((`v`.`acerto` is not null) or (`v`.`tabela` = 2)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C2-' AS `tipo`,2 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) left join `representante` `rr` on((`v`.`vendedor` = `rr`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rr`.`codigo`) and (`cli`.`setor` = 2) and ((`v`.`acerto` is not null) or (`v`.`tabela` = 2)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,3 AS `setor`,'C3+' AS `tipo`,3 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 3) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,3 AS `setor`,'C3-' AS `tipo`,3 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cli`.`setor`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` = 3) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C4+' AS `tipo`,4 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` = `v`.`vendedor`)) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C4-' AS `tipo`,4 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` = `v`.`vendedor`)) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C5+' AS `tipo`,5 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and `v`.`vendedor` in (select `representante`.`codigo` from `representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C5-' AS `tipo`,5 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and `v`.`vendedor` in (select `representante`.`codigo` from `representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C6+' AS `tipo`,6 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` > 1) and (`v`.`vendedor` <> `v`.`cliente`) and isnull(`r`.`representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C6-' AS `tipo`,6 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`cli`.`setor` > 1) and (`v`.`vendedor` <> `v`.`cliente`) and isnull(`r`.`representante`) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,2 AS `setor`,'C7v+' AS `tipo`,7 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 2) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,2 AS `setor`,'C7v-' AS `tipo`,7 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 2) and (`csf`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`r`.`representante` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C7r+' AS `tipo`,7 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * (`csf_r`.`valor` - `csf_a`.`valor`)) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf_r` on(((`csf_r`.`setor` = 100) and (`csf_r`.`faixa` = `m`.`faixa`)))) join `comissaosetorfaixa` `csf_a` on(((`csf_a`.`setor` = 2) and (`csf_a`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`r`.`representante` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C7r-' AS `tipo`,7 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * (`csf_r`.`valor` - `csf_a`.`valor`)) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf_r` on(((`csf_r`.`setor` = 100) and (`csf_r`.`faixa` = `m`.`faixa`)))) join `comissaosetorfaixa` `csf_a` on(((`csf_a`.`setor` = 2) and (`csf_a`.`faixa` = `m`.`faixa`)))) join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and (`r`.`representante` is not null) and (`r`.`representante` <> `v`.`vendedor`) and (not(`v`.`vendedor` in (select `representante`.`codigo` from `representante`))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C8+' AS `tipo`,8 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `representante` `r` on((`cli`.`codigo` = `r`.`codigo`))) where (`v`.`quitacao` is not null) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,100 AS `setor`,'C8-' AS `tipo`,8 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 100) and (`csf`.`faixa` = `m`.`faixa`)))) join `representante` `r` on((`cli`.`codigo` = `r`.`codigo`))) where (`v`.`quitacao` is not null) union select `v`.`cliente` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`corretor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,15 AS `setor`,'corretor+' AS `tipo`,9 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 15) and (`csf`.`faixa` = `m`.`faixa`)))) join `pessoa` `corretor` on((`v`.`corretor` = `corretor`.`codigo`))) where (`v`.`quitacao` is not null) union select `v`.`cliente` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`corretor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,15 AS `setor`,'corretor-' AS `tipo`,9 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = 15) and (`csf`.`faixa` = `m`.`faixa`)))) join `pessoa` `corretor` on((`v`.`corretor` = `corretor`.`codigo`))) where (`v`.`quitacao` is not null) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`s`.`codigo` AS `setor`,'C10+' AS `tipo`,10 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from ((((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` `s` on((`s`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `s`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` not in (3,1,2,100,15)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`cli`.`setor` AS `setor`,'C10-' AS `tipo`,10 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from ((((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` on((`setor`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) left join `representante` `rte` on((`v`.`vendedor` = `rte`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `setor`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and isnull(`rte`.`codigo`) and (`cli`.`setor` not in (3,1,2,100,15)) and (isnull(`cli`.`regiao`) or (not(`cli`.`regiao` in (select `regiao`.`codigo` from `regiao` where (`regiao`.`representante` is not null))))) and (not(`v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,`vi`.`codigo` AS `vendaitem`,NULL AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`s`.`codigo` AS `setor`,'C11+' AS `tipo`,11 AS `regra`,((((`v`.`cotacao` * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((round((round(`vi`.`indice`,2) * `v`.`cotacao`),2) * `vi`.`quantidade`),2) AS `valorv` from (((((((`vendaitem` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` `s` on((`s`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `s`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and `v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`) and (not(`v`.`cliente` in (select `representante`.`codigo` from `representante`)))) union select `cli`.`codigo` AS `cliente`,`v`.`vendedor` AS `vendedor`,`v`.`vendedor` AS `comissaopara`,`v`.`codigo` AS `venda`,NULL AS `vendaitem`,`vi`.`codigo` AS `vendadevolucao`,`vi`.`referencia` AS `referencia`,`m`.`faixa` AS `faixa`,`s`.`codigo` AS `setor`,'C11-' AS `tipo`,11 AS `regra`,(((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`) * `csf`.`valor`) / 100) AS `valorc`,round((((-(1) * `v`.`cotacao`) * `vi`.`quantidade`) * `vi`.`indice`),2) AS `valorv` from (((((((`vendadevolucao` `vi` join `mercadoria` `m` on((`vi`.`referencia` = `m`.`referencia`))) join `venda` `v` on((`vi`.`venda` = `v`.`codigo`))) join `tabela` `t` on((`v`.`tabela` = `t`.`codigo`))) join `setor` `s` on((`s`.`codigo` = `t`.`setor`))) join `pessoa` `cli` on((`v`.`cliente` = `cli`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `s`.`codigo`) and (`csf`.`faixa` = `m`.`faixa`)))) left join `regiao` `r` on((`cli`.`regiao` = `r`.`codigo`))) where ((`v`.`quitacao` is not null) and `v`.`cliente` in (select `funcionario`.`codigo` from `funcionario`) and (not(`v`.`cliente` in (select `representante`.`codigo` from `representante`)))) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `comissao_venda`
--

 DROP TABLE IF EXISTS `comissao_venda`;
 DROP VIEW IF EXISTS `comissao_venda`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `comissao_venda` AS select `cv`.`cliente` AS `cliente`,`cv`.`vendedor` AS `vendedor`,`cv`.`comissaopara` AS `comissaopara`,`cv`.`venda` AS `venda`,`cv`.`setor` AS `setor`,`cv`.`tipo` AS `tipo`,`cv`.`regra` AS `regra`,(sum(`cv`.`valorc`) - ((`csf`.`valor` * `v`.`desconto`) / 100)) AS `valorc`,round((sum(`cv`.`valorv`) - `v`.`desconto`),2) AS `valorv` from ((`comissao_valor` `cv` join `venda` `v` on((`cv`.`venda` = `v`.`codigo`))) join `comissaosetorfaixa` `csf` on(((`csf`.`setor` = `cv`.`setor`) and (`csf`.`faixa` = 'A')))) group by `cv`.`comissaopara`,`cv`.`venda` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `componentecusto_valorfinal`
--

 DROP TABLE IF EXISTS `componentecusto_valorfinal`;
 DROP VIEW IF EXISTS `componentecusto_valorfinal`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `componentecusto_valorfinal` AS select `componentecusto`.`codigo` AS `codigo`,`componentecusto`.`valor` AS `valorfinal` from `componentecusto` where isnull(`componentecusto`.`multiplicarcomponentecusto`) union select `c`.`codigo` AS `codigo`,(`c`.`valor` * `v2`.`valor`) AS `valorfinal` from (`componentecusto` `c` join `componentecusto` `v2`) where (`c`.`multiplicarcomponentecusto` = `v2`.`codigo`) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `devedores`
--

 DROP TABLE IF EXISTS `devedores`;
 DROP VIEW IF EXISTS `devedores`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `devedores` AS select `pessoa`.`codigo` AS `codigo`,`pessoa`.`nome` AS `nome`,sum(`pagamento`.`valor`) AS `sum(valor)` from (`pessoa` join `pagamento`) where ((`pagamento`.`pendente` = 1) and (`pessoa`.`codigo` = `pagamento`.`cliente`)) group by `pessoa`.`codigo` order by sum(`pagamento`.`valor`) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `estoque_extrato`
--

 DROP TABLE IF EXISTS `estoque_extrato`;
 DROP VIEW IF EXISTS `estoque_extrato`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `estoque_extrato` AS select `ei`.`data` AS `data`,`p`.`nome` AS `nome`,`ei`.`referencia` AS `referencia`,`ei`.`peso` AS `peso`,`ei`.`quantidade` AS `entrada`,0 AS `venda`,0 AS `devolucao`,concat('Entrada ',`e`.`codigo`) AS `operacao` from ((`entrada` `e` join `entradaitem` `ei` on((`e`.`codigo` = `ei`.`entrada`))) join `pessoa` `p` on((`p`.`codigo` = `ei`.`funcionario`))) where (`e`.`data` > (select max(`zeragemestoque`.`data`) from `zeragemestoque`)) union select `vi`.`data` AS `data`,`p`.`nome` AS `nome`,`vi`.`referencia` AS `referencia`,`vi`.`peso` AS `peso`,0 AS `entrada`,`vi`.`quantidade` AS `venda`,0 AS `devolucao`,concat('Venda ',`v`.`codigo`) AS `operacao` from (((`venda` `v` join `vendaitem` `vi` on((`v`.`codigo` = `vi`.`venda`))) join `pessoa` `p` on((`p`.`codigo` = `vi`.`funcionario`))) join `comissao_saldo` `s` on((`v`.`codigo` = `s`.`venda`))) where ((`s`.`saldo` > 0) and `v`.`codigo` in (select `comissaovenda`.`venda` from `comissaovenda` where (`comissaovenda`.`comissao` > (select max(`zeragemestoque`.`comissaoVigente`) from `zeragemestoque`)))) union select `d`.`data` AS `data`,`p`.`nome` AS `nome`,`d`.`referencia` AS `referencia`,`d`.`peso` AS `peso`,0 AS `entrada`,0 AS `venda`,`d`.`quantidade` AS `devolucao`,concat('Devoluo ',`v`.`codigo`) AS `operacao` from (((`venda` `v` join `vendadevolucao` `d` on((`v`.`codigo` = `d`.`venda`))) join `pessoa` `p` on((`p`.`codigo` = `d`.`funcionario`))) join `comissao_saldo` `s` on((`v`.`codigo` = `s`.`venda`))) where ((`s`.`saldo` > 0) and `v`.`codigo` in (select `comissaovenda`.`venda` from `comissaovenda` where (`comissaovenda`.`comissao` > (select max(`zeragemestoque`.`comissaoVigente`) from `zeragemestoque`)))) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `estoque_saldo`
--

 DROP TABLE IF EXISTS `estoque_saldo`;
 DROP VIEW IF EXISTS `estoque_saldo`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `estoque_saldo` AS select `e`.`referencia` AS `referencia`,`e`.`peso` AS `peso`,sum(`e`.`entrada`) AS `entrada`,sum(`e`.`venda`) AS `venda`,sum(`e`.`devolucao`) AS `devolucao`,((sum(`e`.`entrada`) - sum(`e`.`venda`)) + sum(`e`.`devolucao`)) AS `saldo` from (`estoque_extrato` `e` join `mercadoria` `m` on((`e`.`referencia` = `m`.`referencia`))) where (`m`.`foradelinha` = 0) group by `e`.`referencia`,`e`.`peso` having ((`venda` <> 0) or (`devolucao` <> 0) or (`saldo` <> 0) or (`entrada` <> 0)) order by `e`.`referencia`,`e`.`peso` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `extratoinventario`
--

 DROP TABLE IF EXISTS `extratoinventario`;
 DROP VIEW IF EXISTS `extratoinventario`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `extratoinventario` AS select `e`.`tipo` AS `tipodocumento`,'E' AS `tipoextrato`,`ei`.`referencia` AS `referencia`,`e`.`dataentrada` AS `data`,`ei`.`quantidade` AS `quantidade`,`ei`.`valor` AS `valor`,`ei`.`cfop` AS `cfop`,`e`.`id` AS `idpai`,`ei`.`codigo` AS `idfilho`,NULL AS `fabricacao` from (`entradaitemfiscal` `ei` join `entradafiscal` `e` on((`ei`.`entradafiscal` = `e`.`id`))) where (`e`.`dataentrada` < now()) union select `e`.`tipo` AS `tipodocumento`,'S' AS `tipoextrato`,`ei`.`referencia` AS `referencia`,`e`.`datasaida` AS `data`,if(`m`.`depeso`,-(1),(-(1) * `ei`.`quantidade`)) AS `if(m.depeso, -1, -1*quantidade)`,round((`ei`.`valor` * (`e`.`valortotal` / `e`.`subtotal`)),2) AS `valor`,`ei`.`cfop` AS `cfop`,cast(`e`.`id` as char charset utf8) AS `idpai`,cast(`ei`.`codigo` as char charset utf8) AS `idfilho`,`e`.`fabricacao` AS `fabricacao` from (((`saidaitemfiscal` `ei` join `saidafiscal` `e` on((`ei`.`saidafiscal` = `e`.`id`))) join `fechamento` `f` on((`e`.`datasaida` between `f`.`inicio` and `f`.`fim`))) join `mercadoriafechamento` `m` on(((`m`.`fechamento` = `f`.`codigo`) and (`m`.`referencia` = `ei`.`referencia`)))) where ((`e`.`cancelada` = 0) and (`e`.`datasaida` < now())) union select NULL AS `tipodocumento`,'OT' AS `tipoextrato`,`ei`.`referencia` AS `referencia`,`e`.`data` AS `data`,(-(1) * `ei`.`quantidade`) AS `-1*ei.quantidade`,round((`ei`.`valor` * `ei`.`quantidade`),2) AS `valor`,`ei`.`cfop` AS `cfop`,`e`.`codigo` AS `idpai`,cast(`ei`.`codigo` as char charset utf8) AS `idfilho`,cast(`e`.`codigo` as char charset utf8) AS `fabricacao` from (`entradafabricacaofiscal` `ei` join `fabricacaofiscal` `e` on((`ei`.`fabricacaofiscal` = `e`.`codigo`))) where (`e`.`data` < now()) union select NULL AS `tipodocumento`,'TO' AS `tipoextrato`,`ei`.`referencia` AS `referencia`,`e`.`data` AS `data`,`ei`.`quantidade` AS `quantidade`,round((`ei`.`valor` * `ei`.`quantidade`),2) AS `valor`,`ei`.`cfop` AS `cfop`,cast(`e`.`codigo` as char charset utf8) AS `idpai`,cast(`ei`.`codigo` as char charset utf8) AS `idfilho`,`e`.`codigo` AS `fabricacao` from (`saidafabricacaofiscal` `ei` join `fabricacaofiscal` `e` on((`ei`.`fabricacaofiscal` = `e`.`codigo`))) where (`e`.`data` < now()) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `inventario_interno`
--

 DROP TABLE IF EXISTS `inventario_interno`;
 DROP VIEW IF EXISTS `inventario_interno`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `inventario_interno` AS select `ei`.`referencia` AS `referencia`,`e`.`dataentrada` AS `data`,`ei`.`quantidade` AS `quantidade` from (`entradaitemfiscal` `ei` join `entradafiscal` `e` on((`ei`.`entradafiscal` = `e`.`id`))) union select `ei`.`referencia` AS `referencia`,`e`.`datasaida` AS `data`,(-(1) * `ei`.`quantidade`) AS `-1*ei.quantidade` from (`saidaitemfiscal` `ei` join `saidafiscal` `e` on((`ei`.`saidafiscal` = `e`.`id`))) union select `ei`.`referencia` AS `referencia`,`e`.`data` AS `data`,(-(1) * `ei`.`quantidade`) AS `-1*ei.quantidade` from (`entradafabricacaofiscal` `ei` join `fabricacaofiscal` `e` on((`ei`.`fabricacaofiscal` = `e`.`codigo`))) union select `ei`.`referencia` AS `referencia`,`e`.`data` AS `data`,`ei`.`quantidade` AS `quantidade` from (`saidafabricacaofiscal` `ei` join `fabricacaofiscal` `e` on((`ei`.`fabricacaofiscal` = `e`.`codigo`))) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `inventario_interno_parcial`
--

 DROP TABLE IF EXISTS `inventario_interno_parcial`;
 DROP VIEW IF EXISTS `inventario_interno_parcial`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `inventario_interno_parcial` AS select `ei`.`referencia` AS `referencia`,`e`.`dataentrada` AS `data`,`ei`.`quantidade` AS `quantidade` from (`entradaitemfiscal` `ei` join `entradafiscal` `e` on((`ei`.`entradafiscal` = `e`.`id`))) where (`e`.`dataentrada` < `D1`()) union select `ei`.`referencia` AS `referencia`,`e`.`datasaida` AS `data`,(-(1) * `ei`.`quantidade`) AS `-1*ei.quantidade` from (`saidaitemfiscal` `ei` join `saidafiscal` `e` on((`ei`.`saidafiscal` = `e`.`id`))) where (`e`.`datasaida` < `D1`()) union select `ei`.`referencia` AS `referencia`,`e`.`data` AS `data`,(-(1) * `ei`.`quantidade`) AS `-1*ei.quantidade` from (`entradafabricacaofiscal` `ei` join `fabricacaofiscal` `e` on((`ei`.`fabricacaofiscal` = `e`.`codigo`))) where (`e`.`data` < `D1`()) union select `ei`.`referencia` AS `referencia`,`e`.`data` AS `data`,`ei`.`quantidade` AS `quantidade` from (`saidafabricacaofiscal` `ei` join `fabricacaofiscal` `e` on((`ei`.`fabricacaofiscal` = `e`.`codigo`))) where (`e`.`data` < `D1`()) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `inventario_parcial`
--

 DROP TABLE IF EXISTS `inventario_parcial`;
 DROP VIEW IF EXISTS `inventario_parcial`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `inventario_parcial` AS select `m`.`referencia` AS `referencia`,sum(ifnull(`i`.`quantidade`,0)) AS `quantidade`,`m`.`nome` AS `nome`,`m`.`classificacaofiscal` AS `classificacaofiscal`,`m`.`tipounidade` AS `tipounidade`,ifnull(`a`.`valor`,`p`.`novoPrecoCusto`) AS `valor`,(sum(ifnull(`i`.`quantidade`,0)) * ifnull(`a`.`valor`,`p`.`novoPrecoCusto`)) AS `valortotal` from (((`mercadoria` `m` left join `materiaprima` `a` on((`a`.`referencia` = `m`.`referencia`))) left join `inventario_interno_parcial` `i` on((`i`.`referencia` = `m`.`referencia`))) left join `novosPrecos` `p` on((`m`.`referencia` = `p`.`mercadoria`))) group by `m`.`referencia` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `mercadoria_fiscal`
--

 DROP TABLE IF EXISTS `mercadoria_fiscal`;
 DROP VIEW IF EXISTS `mercadoria_fiscal`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `mercadoria_fiscal` AS select `m`.`referencia` AS `referencia`,`m`.`nome` AS `descricao`,ifnull(`a`.`valor`,`p`.`novoPrecoCusto`) AS `valor`,`m`.`peso` AS `peso`,`m`.`depeso` AS `depeso` from ((`mercadoria` `m` left join `materiaprima` `a` on((`a`.`referencia` = `m`.`referencia`))) left join `novosPrecos` `p` on((`m`.`referencia` = `p`.`mercadoria`))) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `novosPrecos`
--

 DROP TABLE IF EXISTS `novosPrecos`;
 DROP VIEW IF EXISTS `novosPrecos`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `novosPrecos` AS select `mc`.`mercadoria` AS `mercadoria`,round((round(sum((round((`t1`.`valorfinal` * `mc`.`quantidade`),2) * (1 + `f`.`valor`))),2) / `obtemouro`()),2) AS `novoIndiceAtacado`,round(sum((`t1`.`valorfinal` * `mc`.`quantidade`)),2) AS `novoPrecoCusto` from (((`vinculomercadoriacomponentecusto` `mc` join `componentecusto_valorfinal` `t1`) join `faixa` `f`) join `mercadoria` `m`) where ((`mc`.`componentecusto` = `t1`.`codigo`) and (`m`.`referencia` = `mc`.`mercadoria`) and (`m`.`faixa` = `f`.`faixa`) and (`f`.`setor` = 2)) group by `mc`.`mercadoria` order by `m`.`referencia` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `novosPrecosVarejo`
--

 DROP TABLE IF EXISTS `novosPrecosVarejo`;
 DROP VIEW IF EXISTS `novosPrecosVarejo`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `novosPrecosVarejo` AS select `mc`.`mercadoria` AS `mercadoria`,round(round(sum((round((`t1`.`valorfinal` * `mc`.`quantidade`),2) * (1 + `f`.`valor`))),2),2) AS `novoValorVarejoConsulta`,round((round(sum((round((`t1`.`valorfinal` * `mc`.`quantidade`),2) * (1 + `f`.`valor`))),2) * `obtemjuros`()),2) AS `novoValorVarejo` from (((`vinculomercadoriacomponentecusto` `mc` join `componentecusto_valorfinal` `t1`) join `faixa` `f`) join `mercadoria` `m`) where ((`mc`.`componentecusto` = `t1`.`codigo`) and (`m`.`referencia` = `mc`.`mercadoria`) and (`m`.`faixa` = `f`.`faixa`) and (`f`.`setor` = 1)) group by `mc`.`mercadoria` order by `m`.`referencia` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `novos_coeficientes`
--

 DROP TABLE IF EXISTS `novos_coeficientes`;
 DROP VIEW IF EXISTS `novos_coeficientes`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `novos_coeficientes` AS select `t`.`codigo` AS `tabela`,`n`.`mercadoria` AS `mercadoria`,`n`.`novoIndiceAtacado` AS `coeficiente` from ((`novosPrecos` `n` join `mercadoria` `m` on((`n`.`mercadoria` = `m`.`referencia`))) join `tabela` `t`) where ((`m`.`depeso` = 0) and (`t`.`codigo` not in (1,5))) union select `g`.`tabela` AS `tabela`,`m`.`referencia` AS `referencia`,`g`.`valor` AS `coeficiente` from (`mercadoria` `m` join `grama` `g` on(((`m`.`faixa` = `g`.`faixa`) and (`m`.`grupo` = `g`.`grupo`)))) where ((`m`.`depeso` = 1) and (`g`.`tabela` not in (1,5))) ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `novos_coeficientes_varejo`
--

 DROP TABLE IF EXISTS `novos_coeficientes_varejo`;
 DROP VIEW IF EXISTS `novos_coeficientes_varejo`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`localhost` SQL SECURITY DEFINER 
 VIEW `novos_coeficientes_varejo` AS select 1 AS `tabela`,`novosPrecosVarejo`.`mercadoria` AS `mercadoria`,`novosPrecosVarejo`.`novoValorVarejo` AS `coeficiente` from `novosPrecosVarejo` union select 5 AS `tabela`,`novosPrecosVarejo`.`mercadoria` AS `mercadoria`,`novosPrecosVarejo`.`novoValorVarejoConsulta` AS `coeficiente` from `novosPrecosVarejo` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;

--
-- Final view structure for view `vendasintetizada`
--

 DROP TABLE IF EXISTS `vendasintetizada`;
 DROP VIEW IF EXISTS `vendasintetizada`;
 SET @saved_cs_client          = @@character_set_client ;
 SET @saved_cs_results         = @@character_set_results ;
 SET @saved_col_connection     = @@collation_connection ;
 SET character_set_client      = utf8 ;
 SET character_set_results     = utf8 ;
 SET collation_connection      = utf8_general_ci ;
 CREATE ALGORITHM=UNDEFINED 
 DEFINER=`root`@`%` SQL SECURITY DEFINER 
 VIEW `vendasintetizada` AS (select `v`.`codigo` AS `codigo`,`v`.`controle` AS `controle`,`v`.`valortotal` AS `valortotal`,`vendedor`.`nome` AS `nome`,`cliente`.`nome` AS `cliente`,`v`.`data` AS `data`,`vendedor`.`codigo` AS `vendedorcod`,`cliente`.`codigo` AS `clientecod`,`v`.`taxajuros` AS `taxajuros`,`v`.`cotacao` AS `cotacao` from ((`venda` `v` left join `pessoa` `cliente` on((`v`.`cliente` = `cliente`.`codigo`))) left join `pessoa` `vendedor` on((`v`.`vendedor` = `vendedor`.`codigo`))) where (`v`.`valortotal` is not null)) union (select `v`.`codigo` AS `codigo`,`v`.`controle` AS `controle`,sum(((`i`.`quantidade` * `i`.`indice`) * `v`.`cotacao`)) AS `valorTotal`,`vendedor`.`nome` AS `nome`,`cliente`.`nome` AS `cliente`,`v`.`data` AS `data`,`vendedor`.`codigo` AS `vendedorcod`,`cliente`.`codigo` AS `clientecod`,`v`.`taxajuros` AS `taxajuros`,`v`.`cotacao` AS `cotacao` from (((`venda` `v` left join `vendaitem` `i` on((`v`.`codigo` = `i`.`venda`))) left join `pessoa` `cliente` on((`v`.`cliente` = `cliente`.`codigo`))) left join `pessoa` `vendedor` on((`v`.`vendedor` = `vendedor`.`codigo`))) where isnull(`v`.`valortotal`) group by `v`.`codigo`) order by `data` ;
 SET character_set_client      = @saved_cs_client ;
 SET character_set_results     = @saved_cs_results ;
 SET collation_connection      = @saved_col_connection ;
 SET TIME_ZONE=@OLD_TIME_ZONE ;

 SET SQL_MODE=@OLD_SQL_MODE ;
 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS ;
 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS ;
 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT ;
 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS ;
 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION ;
 SET SQL_NOTES=@OLD_SQL_NOTES ;

-- Dump completed on 2016-12-29 15:28:04
