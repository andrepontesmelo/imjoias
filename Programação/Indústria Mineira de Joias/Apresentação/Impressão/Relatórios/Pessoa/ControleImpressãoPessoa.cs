using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;
using Entidades;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Impressão.Relatórios.Pessoa
{
    public class ControleImpressãoPessoa
    {
        public void PrepararImpressão(ReportClass relatório, IEnumerable<Entidades.Pessoa.Impressão.PessoaImpressão> pessoas, Região região)
        {
            DataSetPessoa ds = new DataSetPessoa();
            DataTable tabela = ds.Tables["Pessoa"];
            DataTable info = ds.Tables["Informações"];
            DataRow itemInfo = info.NewRow();
            
            if (região != null)
            {
                Representante representante = região.ObterRepresentante();
                itemInfo["Representante"] = (representante == null ? "" : representante.PrimeiroNome);
                itemInfo["Região"] = (região.Nome);
            }
            else
            {
                itemInfo["Representante"] = "";
                itemInfo["Região"] = "Todas";
            }

            info.Rows.Add(itemInfo);

            foreach (Entidades.Pessoa.Impressão.PessoaImpressão p in pessoas)
            {
                DataRow linha = tabela.NewRow();
                MapearItem(p, linha);
                tabela.Rows.Add(linha);
            }

            relatório.SetDataSource(ds);
        }

        private static void MapearItem(Entidades.Pessoa.Impressão.PessoaImpressão pessoa, DataRow linha)
        {
            linha["Nome"] = pessoa.Nome;
            linha["Código"] = pessoa.Código;
            linha["Telefones"] = pessoa.Telefones;
            linha["Endereços"] = pessoa.Endereços;
            linha["EstadoCidade"] = pessoa.EstadoCidade;
            linha["Documento"] = pessoa.Documento;

            StringBuilder dadosPessoa = new StringBuilder();
            if (!String.IsNullOrEmpty(pessoa.Endereços))
            {
                dadosPessoa.Append(pessoa.Endereços.Trim());
                if (pessoa.Endereços.Trim().Length > 0)
                    dadosPessoa.AppendLine();
            }

            if (!String.IsNullOrEmpty(pessoa.Telefones))
            {
                dadosPessoa.Append(pessoa.Telefones.Trim());
                if (pessoa.Telefones.Trim().Length > 0)
                    dadosPessoa.AppendLine();
            }

            if (!String.IsNullOrEmpty(pessoa.Documento))
            {
                dadosPessoa.Append(pessoa.Documento.Trim());
                if (pessoa.Documento.Trim().Length > 0)
                    dadosPessoa.AppendLine();
            }

            if (!String.IsNullOrEmpty(pessoa.Email))
            {
                dadosPessoa.Append(pessoa.Email.Trim());
                if (pessoa.Email.Trim().Length > 0)
                    dadosPessoa.AppendLine();
            }

            linha["DadosPessoa"] = dadosPessoa.ToString();

            string classificaçõesStr = (pessoa.Crédito.HasValue ? (pessoa.Crédito.Value.ToString("C") + "\n"): ""); ;

            bool amarelo = false;
            bool vermelho = false;

            Classificação[] classificações = Classificação.ObterClassificações(pessoa.ClassificaçõesStr);

            foreach (Classificação c in classificações)
            {
                if (c != null)
                {
                    switch (c.Código)
                    {
                        case (int)Classificação.CódigoSistema.CréditoCortado:
                        case (int)Classificação.CódigoSistema.Devedor:
                        case (int)Classificação.CódigoSistema.DifícilPagar:
                        case (int)Classificação.CódigoSistema.Eliminado:
                        case (int)Classificação.CódigoSistema.IncluimosSPC:
                            vermelho = true;
                            break;

                        case (int)Classificação.CódigoSistema.FazerFicha:
                        case (int)Classificação.CódigoSistema.ConstaSPC:
                        case (int)Classificação.CódigoSistema.SomenteÀVista:
                        case (int)Classificação.CódigoSistema.ConsultarSePodeVender:
                        case (int)Classificação.CódigoSistema.AguardarPagamento:
                            amarelo = true;
                            break;
                    }

                    classificaçõesStr += c.Denominação + "\n";
                }
            }

            if (vermelho)
                linha["CorAlerta"] = "V";
            else if (amarelo)
                linha["CorAlerta"] = "A";
            else
                linha["CorAlerta"] = "";
            
            linha["Classificações"] = classificaçõesStr;
        }
    }
}
