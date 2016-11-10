using System;
using System.Collections.Generic;
using System.Data;
using Entidades.Fiscal.Tipo;
using Entidades.Configuração;
using Entidades.Pessoa;

namespace Apresentação.Impressão.Relatórios.Fiscal.Inventário
{
    public class ControladorImpressãoInventário
    {
        public RelatórioInventário CriarRelatório(DateTime data)
        {
            var relatório = new RelatórioInventário();
            var dataset = new DataSetInventário();
            relatório.SetDataSource(dataset);

            CriarAdicionarDocumento(dataset, data);
            CriarItens(Entidades.Fiscal.Inventário.Obter(data), dataset.Tables["Item"]);

            return relatório;
        }

        private static void CriarAdicionarDocumento(DataSetInventário dataset, DateTime data)
        {
            var tabelaDocumento = dataset.Tables["Documento"];
            tabelaDocumento.Rows.Add(CriarDocumento(tabelaDocumento, data));
        }

        private static void CriarItens(List<Entidades.Fiscal.Inventário> entidades, DataTable tabelaItens)
        {
            foreach (var entidade in entidades)
            {
                DataRow item = CriarItem(tabelaItens, entidade);
                tabelaItens.Rows.Add(item);
            }
        }

        private static DataRow CriarDocumento(DataTable tabelaDocumento, DateTime data)
        {
            var empresa = PessoaJurídica.ObterEmpresa();

            DataRow linha = tabelaDocumento.NewRow();
            linha["nomeEmpresa"] = empresa.Nome.ToUpper();
            linha["cnpj"] = empresa.CNPJ;
            linha["inscriçãoEstadual"] = empresa.InscEstadual;
            linha["data"] = string.Format("{0} {1}", data.ToShortDateString(), data.ToShortTimeString());

            return linha;
        }

        private static DataRow CriarItem(DataTable tabelaItens, Entidades.Fiscal.Inventário entidade)
        {
            DataRow item = tabelaItens.NewRow();

            item["referência"] = Entidades.Mercadoria.Mercadoria.MascararReferência(entidade.Referência, true);
            item["classificaçãoFiscal"] = entidade.ClassificaçãoFiscalFormatada;
            item["descrição"] = entidade.Descrição.ToUpper();
            item["tipoUnidade"] = ObterSigla(entidade.TipoUnidadeComercial);
            item["quantidade"] = entidade.Quantidade.ToString();
            item["valorUnitário"] = entidade.ValorUnitário;
            item["valorTotal"] = entidade.ValorTotal;

            return item;
        }

        private static string ObterSigla(TipoUnidade tipoUnidadeComercial)
        {
            switch (tipoUnidadeComercial.Id)
            {
                case (int) TipoUnidadeSistema.Cxa:
                    return "CXA";
                case (int)TipoUnidadeSistema.Grs:
                    return "GRS";
                case (int)TipoUnidadeSistema.Par:
                    return "PAR";
                case (int)TipoUnidadeSistema.Pca:
                    return "PÇA";
                case (int)TipoUnidadeSistema.Un:
                    return "UN";
                default:
                    return tipoUnidadeComercial.Nome.ToUpper();
            }
        }
    }
}

