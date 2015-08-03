using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão.Relatórios.Retorno
{
    public class ControleImpressãoRetorno : ControleImpressãoRelacionamento<DataSetRetorno, Entidades.Relacionamento.Retorno.Retorno>
    {
        protected override void MapearInformações(System.Data.DataRow linha, Entidades.Relacionamento.Retorno.Retorno retorno)
        {
            base.MapearInformações(linha, retorno);

            linha["acerto"] = retorno.AcertoConsignado != null ? retorno.AcertoConsignado.Código.ToString() : "Não definido";
        }
    }
}
