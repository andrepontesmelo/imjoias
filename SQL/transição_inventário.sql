


INSERT INTO entradaitemfiscal (referencia, descricao, cfop, tipounidade,
quantidade, valorunitario, valor, entradafiscal)
SELECT m.referencia, m.nome, m.cfop, m.tipounidade, 55 as quantidade,
0 as valorunitario, 0 as valor, 'transição_sistema_legado' as entradafiscal
from mercadoria m;
