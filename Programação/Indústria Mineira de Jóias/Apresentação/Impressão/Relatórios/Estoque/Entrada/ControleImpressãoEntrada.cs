using Apresentação.Impressão.Relatórios.Estoque.Entrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Entrada
{
    public class ControleImpressãoEntrada : ControleImpressãoRelacionamento<DataSetEntrada, Entidades.Estoque.Entrada>
    {
        protected override void MapearInformações(System.Data.DataRow linha, Entidades.Estoque.Entrada entrada)
        {
            base.MapearInformações(linha, entrada);
            linha["tabela"] = entrada.TabelaPreço.Nome;
        }

        protected override void MapearItem(System.Data.DataRow linha, 
            Entidades.Relacionamento.SaquinhoRelacionamento s,
            Entidades.Estoque.Entrada relacionamento)
        {
            base.MapearItem(linha, s, relacionamento);

            //linha["preço"] = s.Mercadoria.CalcularPreço(relacionamento.Cotação).Valor;
        }
    }
}
