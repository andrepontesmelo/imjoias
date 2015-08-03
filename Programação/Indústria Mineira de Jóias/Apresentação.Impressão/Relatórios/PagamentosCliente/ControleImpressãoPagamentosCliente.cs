using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades.Pagamentos;

namespace Apresentação.Impressão.Relatórios.PagamentosCliente
{
    public class ControleImpressãoPagamentosCliente
    {
        public static void PrepararImpressão(CrystalDecisions.CrystalReports.Engine.ReportClass relatório, Entidades.Pessoa.Pessoa pessoa)
        {
            DataSetPagamentosCliente ds = new DataSetPagamentosCliente();

            DataTable tabelaInformações = ds.Tables["Informações"];
            DataTable tabelaPagamentos = ds.Tables["Pagamentos"];

            DataRow linhaInfo = tabelaInformações.NewRow();
            linhaInfo["data"] = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual;
            linhaInfo["pessoaNome"] = pessoa.ToString();

            // Preencher pagamentos
            foreach (Pagamento p in Pagamento.ObterPagamentos(pessoa))
            {
                DataRow item = tabelaPagamentos.NewRow();
                item["valor"] = p.Valor;
                //item["valorLíquido"] = "";

                switch (p.Tipo)
                {
                    case Pagamento.TipoEnum.Cheque:
                        item["tipo"] = "Ch";
                        break;

                    case Pagamento.TipoEnum.Dinheiro:
                        item["tipo"] = "Esp.";
                        break;

                    case Pagamento.TipoEnum.NotaPromissória:
                        item["tipo"] = "NP";
                        break;

                    case Pagamento.TipoEnum.Crédito:
                        item["tipo"] = "CR";
                        break;

                    case Pagamento.TipoEnum.Ouro:
                        item["tipo"] = "FF";
                        break;

                    case Pagamento.TipoEnum.Dolar:
                        item["tipo"] = "US$";
                        break;

                    default:
                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(new Exception("Tipo de pagamento desconhecido no momento de impressão: " + p.Tipo.ToString()));
                        item["tipo"] = "?";
                        break;
                }

                item["pendente"] = p.Pendente;
                item["vencimento"] = p.ÚltimoVencimento;
                item["data"] = p.Data;
                item["código"] = p.Código;
                item["observações"] = p.Descrição + " " + p.DescriçãoAdicional;

                if (p.Tipo == Pagamento.TipoEnum.Ouro)
                    item["observações"] += " " + p.ToString();

                item["deTerceiro"] = p.Tipo == Pagamento.TipoEnum.Cheque ? ((Cheque)p).DeTerceiro : false;

                if (p.Tipo == Pagamento.TipoEnum.Cheque && ((Cheque)p).DeTerceiro)
                    item["tipo"] += " cliente";

                tabelaPagamentos.Rows.Add(item);
            }

            tabelaInformações.Rows.Add(linhaInfo);
        
            relatório.Subreports["Pagamentos.rpt"].SetDataSource(tabelaPagamentos);

            relatório.SetDataSource(ds);
        }
    }
}