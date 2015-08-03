using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;

namespace Apresentação.Impressão.Relatórios.Saída
{
    public class ControleImpressãoSaída : ControleImpressãoRelacionamento<DataSetSaída, Entidades.Relacionamento.Saída.Saída>
    {
        protected override void MapearInformações(System.Data.DataRow linha, Entidades.Relacionamento.Saída.Saída saída)
        {
            base.MapearInformações(linha, saída);

            linha["cotação"] = saída.Cotação;

            if (saída.AcertoConsignado != null)
            {
                linha["previsãoAcerto"] =
                    saída.AcertoConsignado.Previsão.HasValue ?
                    saída.AcertoConsignado.Previsão.Value.ToString("dd/MM/yyyy 'às' HH:mm")
                    : "Sem previsão";
                linha["acerto"] = saída.AcertoConsignado.Código.ToString();
            }
            else
            {
                linha["previsãoAcerto"] = "Sem previsão";
                linha["acerto"] = "Não definido";
            }

            bool imprimirPreço = !Representante.ÉRepresentante(saída.Pessoa);
            imprimirPreço &= saída.Pessoa.Setor.Código != 
                Setor.ObterSetor(Setor.SetorSistema.AltoAtacado).Código;
            

            linha["imprimirPreço"] = imprimirPreço;
            linha["tabela"] = saída.TabelaPreço.Nome;
        }

        protected override void MapearItem(System.Data.DataRow linha, Entidades.Relacionamento.SaquinhoRelacionamento s, Entidades.Relacionamento.Saída.Saída relacionamento)
        {
            base.MapearItem(linha, s, relacionamento);

            linha["preço"] = s.Mercadoria.CalcularPreço(relacionamento.Cotação).Valor;
        }
    }
}
