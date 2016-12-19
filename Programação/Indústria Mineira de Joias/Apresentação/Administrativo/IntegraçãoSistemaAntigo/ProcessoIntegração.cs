using Apresenta��o.Formul�rios;
using Entidades.Configura��o;
using Entidades.Financeiro;
using Entidades.Mercadoria;
using Entidades.Moedas;
using Neg�cio.Integra��o;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Integra��oSistemaAntigo
{
    public class ProcessoIntegra��o 
	{
		public ProcessoIntegra��o()
		{
		}

        private DataSet ObterDataSetMercadoria(List<IDbConnection> conex�esRemovidas)
        {
            DataSet ds = new DataSet();
            MySQL.AdicionarTabelaAoDataSet(ds, "faixa", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "componentecusto", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriacomponentecusto", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriafornecedor", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "fornecedor", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conex�esRemovidas);

            return ds;
        }

        public void TransporEstoqueAnterior()
        {
            string diret�rio = ObterPastaSelecionada();

            if (diret�rio == null)
                return;

            AguardeDB.Mostrar();
            new EstoqueLegado(new Dbf(diret�rio).ObterDataSetMercadoria()).Transpor();
            AguardeDB.Fechar();
        }

        public void TransporPre�osMat�riasPrimas()
        {
            string diret�rio = ObterPastaSelecionada();

            if (diret�rio == null)
                return;

            AguardeDB.Mostrar();

            DataSet dsVelho = TransporMercadoriasMat�riasPrimas(diret�rio);
            Mat�riaPrima.Importar(dsVelho.Tables["cadmer"]);
            AguardeDB.Fechar();
        }

        private DataSet TransporMercadoriasMat�riasPrimas(string diret�rio)
        {
            var dbf = new Dbf(diret�rio);
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
            StringBuilder strSa�da;
            
            DateTime inicio = DateTime.Now;

            Transpor(ref dsVelho, pastaSelecionada, ref dbf, out dsNovo, out strSa�da);

            TimeSpan decorrido = DateTime.Now - inicio;

            strSa�da.AppendLine();
            strSa�da.AppendLine("A integra��o terminou em " + 
             Math.Round(decorrido.TotalSeconds).ToString() + 
             " segundos. � necess�rio \nreiniciar cada esta��o para acessar os novos �ndices.");

            string nomeArquivo = Path.GetTempFileName();
            File.WriteAllText(nomeArquivo, strSa�da.ToString());
            Process.Start("notepad.exe", nomeArquivo);
            Environment.Exit(0);
        }

        public string ObterPastaSelecionada()
        {
            Configura��oUsu�rio<string> pastaImporta��oFiscal = new Configura��oUsu�rio<string>("pasta_importa��o_fiscal", "");

            FolderBrowserDialog pasta = new FolderBrowserDialog();
            pasta.SelectedPath = pastaImporta��oFiscal.Valor;
            pasta.ShowNewFolderButton = false;
            pasta.Description = "Selecione a pasta com DBF's.";

            if (pasta.ShowDialog() != DialogResult.OK)
                return null;

            pastaImporta��oFiscal.Valor = pasta.SelectedPath;
            return pasta.SelectedPath;
        }

        private void Transpor(ref DataSet dsVelho, string diret�rio, ref Dbf dbf, out DataSet dsNovo, out StringBuilder strSa�da)
        {
            AguardeDB.Mostrar();

            strSa�da = new StringBuilder(" === Sa�da do Processo de Integra��o ===");
            strSa�da.AppendLine();

            List<IDbConnection> conex�esRemovidas = new List<IDbConnection>();
            dsNovo = ObterDataSetMercadoria(conex�esRemovidas);

            dbf = new Dbf(diret�rio);
            dsVelho = dbf.ObterDataSetMercadoria();

            var mercadorias = new Controles.Mercadorias.Mercadorias(dsVelho, dsNovo, dbf);
            mercadorias.MarcarMercadoriasForaDeLinha();
            mercadorias.Transpor(strSa�da, false, dsNovo);

            new Integra��oComponenteCusto().Transpor(dsVelho);
            MySQL.GravarDataSetTodasTabelas(dsNovo);

            dsNovo = ObterDataSetMercadoria(conex�esRemovidas);
            new Controles.Mercadorias.VinculoMercadoriaComponenteCusto(dsVelho, dsNovo).Transpor(strSa�da);
            double cota��oVarejo = Cota��o.ObterCota��oVigente(Moeda.ObterMoeda(4)).Valor;
            MySQL.GravarDataSetTodasTabelas(dsNovo);

            new Controles.Mercadorias.Indices(dsVelho, dsNovo).Transpor(cota��oVarejo, strSa�da);
            new Controles.Mercadorias.Gramas(dsVelho).Transpor(strSa�da);
            new Controles.Mercadorias.Fornecedor(dsVelho).Transpor();

            AguardeDB.Fechar();

            MySQL.AdicionarConex�esRemovidas(conex�esRemovidas);
        }
	}
}

