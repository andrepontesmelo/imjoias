using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades;

namespace Apresentação.Impressão.Etiquetas.Sedex
{
    public class ControleImpressãoSedex
    {
        public static void PrepararImpressão(EtiquetaSedexCrystal relatório,
            List<Entidades.EtiquetaSedex> listaEtiquetas)
        {
            DataSetEtiquetaSedex ds = new DataSetEtiquetaSedex();
            DataTable tabelaEtiqueta = ds.Tables["Etiqueta"];

            // Preencher itens do relacionamento
            foreach (Entidades.EtiquetaSedex s in listaEtiquetas) 
            {
                for (int x = 0; x < s.Quantidade; x++)
                {
                    DataRow linha = tabelaEtiqueta.NewRow();
                    linha["nome"] = s.Pessoa.Nome;
                    linha["código"] = s.Pessoa.Código.ToString();
                    linha["endereço"] = s.Endereço.Logradouro + " " + s.Endereço.Número + " " +
                        (s.Endereço.Complemento == null ? "" : s.Endereço.Complemento);

                    linha["bairro"] = s.Endereço.Bairro;
                    linha["cidade"] = s.Endereço.Localidade.Nome;
                    linha["estado"] = s.Endereço.Localidade.Estado.Sigla;
                    linha["pais"] = s.Endereço.Localidade.Estado.País.Nome;
                    linha["cep"] = s.Endereço.CEP;

                    tabelaEtiqueta.Rows.Add(linha);

                    if (s.Tipo == EtiquetaSedex.TipoEndereco.Destinatário)
                        linha["título"] = "DESTINATÁRIO";
                    else
                        linha["título"] = "REMETENTE";
                }
            }

            relatório.SetDataSource(ds);
        }
    }
}
