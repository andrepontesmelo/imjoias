delete from fechamento;

insert into esquemafabricacaofiscal (referencia, quantidade, fechamento) select mercadoria as referencia, 1 as quantidade, 
49 as fechamento from vinculomercadoriacomponentecusto where componentecusto=31;

insert into materiaprimaesquemafabricacaofiscal(esquema, materiaprima, quantidade, fechamento) select mercadoria as esquema, 99900000012 as materiaprima,quantidade, 
49 as fechamento from vinculomercadoriacomponentecusto where componentecusto=31;
