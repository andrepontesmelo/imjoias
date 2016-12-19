using Apresentação.Formulários;
using Entidades.Configuração;
using Entidades.Financeiro;
using Entidades.Mercadoria;
using Entidades.Moedas;
using Negócio.Integração;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.IntegraçãoSistemaAntigo
{
    public class ProcessoIntegração 
	{
		public ProcessoIntegração()
		{
		}

        private DataSet ObterDataSetMercadoria(List<IDbConnection> conexõesRemovidas)
        {
            DataSet ds = new DataSet();
            MySQL.AdicionarTabelaAoDataSet(ds, "faixa", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "componentecusto", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriacomponentecusto", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriafornecedor", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "fornecedor", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conexõesRemovidas);

            return ds;
        }

        public void TransporEstoqueAnterior()
        {
            string diretório = ObterPastaSelecionada();

            if (diretório == null)
                return;

            AguardeDB.Mostrar();
            new EstoqueLegado(new Dbf(diretório).ObterDataSetMercadoria()).Transpor();
            AguardeDB.Fechar();
        }

        public void TransporPreçosMatériasPrimas()
        {
            string diretório = ObterPastaSelecionada();

            if (diretório == null)
                return;

            AguardeDB.Mostrar();

            DataSet dsVelho = TransporMercadoriasMatériasPrimas(diretório);
            MatériaPrima.Importar(dsVelho.Tables["cadmer"]);
            AguardeDB.Fechar();
        }

        private DataSet TransporMercadoriasMatériasPrimas(string diretório)
        {
            var dbf = new Dbf(diretório);
            var dsVelho = dbf.ObterDataSetMercadoria();
            var dsNovo = ObterDataSetMercadoria(new List<IDbConnection>());
            new Controles.Mercadorias.Mercadorias(dsVelho, dsNovo, dbf).Transpor(new StringBuilder(), true, dsNovo);
            MySQL.GravarDataSetTodasTabelas(dsNovo);
            return dsVelho;
        }

        public void ImportarDadosDoSistemaLegado()
        {
            string pastaSelecionada = ObterPastaSelecionada();

            if (pastaSelecionada == null)
                return;

            DataSet dsNovo;
            DataSet dsVelho = new DataSet();
            Dbf dbf = null;
            StringBuilder strSaída;
            
            DateTime inicio = DateTime.Now;

            Transpor(ref dsVelho, pastaSelecionada, ref dbf, out dsNovo, out strSaída);

            TimeSpan decorrido = DateTime.Now - inicio;

            strSaída.AppendLine();
            strSaída.AppendLine("A integração terminou em " + 
             Math.Round(decorrido.TotalSeconds).ToString() + 
             " segundos. É necessário \nreiniciar cada estação para acessar os novos índices.");

            string nomeArquivo = Path.GetTempFileName();
            File.WriteAllText(nomeArquivo, strSaída.ToString());
            Process.Start("notepad.exe", nomeArquivo);
            Environment.Exit(0);
        }

        public string ObterPastaSelecionada()
        {
            ConfiguraçãoUsuário<string> pastaImportaçãoFiscal = new ConfiguraçãoUsuário<string>("pasta_importação_fiscal", "");

            FolderBrowserDialog pasta = new FolderBrowserDialog();
            pasta.SelectedPath = pastaImportaçãoFiscal.Valor;
            pasta.ShowNewFolderButton = false;
            pasta.Description = "Selecione a pasta com DBF's.";

            if (pasta.ShowDialog() != DialogResult.OK)
                return null;

            pastaImportaçãoFiscal.Valor = pasta.SelectedPath;
            return pasta.SelectedPath;
        }

        private void Transpor(ref DataSet dsVelho, string diretório, ref Dbf dbf, out DataSet dsNovo, out StringBuilder strSaída)
        {
            AguardeDB.Mostrar();

            strSaída = new StringBuilder(" === Saída do Processo de Integração ===");
            strSaída.AppendLine();

            List<IDbConnection> conexõesRemovidas = new List<IDbConnection>();
            dsNovo = ObterDataSetMercadoria(conexõesRemovidas);

            dbf = new Dbf(diretório);
            dsVelho = dbf.ObterDataSetMercadoria();

            var mercadorias = new Controles.Mercadorias.Mercadorias(dsVelho, dsNovo, dbf);
            mercadorias.MarcarMercadoriasForaDeLinha();
            mercadorias.Transpor(strSaída, false, dsNovo);

            new IntegraçãoComponenteCusto().Transpor(dsVelho);
            MySQL.GravarDataSetTodasTabelas(dsNovo);

            dsNovo = ObterDataSetMercadoria(conexõesRemovidas);
            new Controles.Mercadorias.VinculoMercadoriaComponenteCusto(dsVelho, dsNovo).Transpor(strSaída);
            double cotaçãoVarejo = Cotação.ObterCotaçãoVigente(Moeda.ObterMoeda(4)).Valor;
            MySQL.GravarDataSetTodasTabelas(dsNovo);

            new Controles.Mercadorias.Indices(dsVelho, dsNovo).Transpor(cotaçãoVarejo, strSaída);
            new Controles.Mercadorias.Gramas(dsVelho).Transpor(strSaída);
            new Controles.Mercadorias.Fornecedor(dsVelho).Transpor();

            AguardeDB.Fechar();

            MySQL.AdicionarConexõesRemovidas(conexõesRemovidas);
        }
	}
}

