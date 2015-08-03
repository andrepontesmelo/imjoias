SELECT mc.mercadoria,

round(SUM(t1.valor * mc.quantidade) * (f.valor + 1) / 39, 2) as novoCoeficiente
FROM vinculomercadoriacomponentecusto mc,
  (
    select codigo, valor from componentecusto where multiplicarcomponentecusto is null
    UNION select c.codigo, (c.valor * v2.valor) as valor

    from componentecusto c, componentecusto v2 where c.multiplicarcomponentecusto = v2.codigo

  ) t1, faixa f, mercadoria m

  where mc.componentecusto = t1.codigo and m.referencia = mc.mercadoria and m.faixa = f.faixa and f.setor = 2
group by mc.mercadoria
order by referencia
