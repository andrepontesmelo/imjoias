using Apresenta��o.Formul�rios;
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

        public void ImportarDadosDoSistemaLegado()
        {
            FolderBrowserDialog pasta = new FolderBrowserDialog();
            pasta.ShowNewFolderButton = false;

            if (pasta.ShowDialog() != DialogResult.OK)
                return;

            DataSet dsNovo;
            DataSet dsVelho = new DataSet();
            Dbf dbf = null;
            StringBuilder strSa�da;
            
            DateTime inicio = DateTime.Now;

            Transpor(ref dsVelho, pasta.SelectedPath, ref dbf, out dsNovo, out strSa�da);

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

        private void Transpor(ref DataSet dsVelho, string diret�rio, ref Dbf dbf, out DataSet dsNovo, out StringBuilder strSa�da)
        {
            AguardeDB.Mostrar();

            strSa�da = new StringBuilder(" === Sa�da do Processo de Integra��o ===");
            strSa�da.AppendLine();

            List<IDbConnection> conex�esRemovidas = new List<IDbConnection>();
            dsNovo = ObterDataSetMercadoria(conex�esRemovidas);

            Controles.Mercadorias.Faixas.dsNovo = dsNovo;

            dbf = new Apresenta��o.Integra��oSistemaAntigo.Dbf(diret�rio);
            dsVelho = dbf.ObterDataSetMercadoria();
            new Controles.Mercadorias.Gramas(dsVelho).Transpor(strSa�da);
            new Controles.Mercadorias.Fornecedor(dsVelho, dsNovo, dbf);
            new Controles.Mercadorias.ComponenteDeCusto(dsVelho, dsNovo, dbf).Transpor();
            new Controles.Mercadorias.Mercadorias(dsVelho, dsNovo, dbf).Transpor(strSa�da);
            new Controles.Mercadorias.VinculoMercadoriaComponenteCusto(dsVelho, dsNovo).Transpor(strSa�da);
            MySQL.GravarDataSetTodasTabelas(dsNovo);

            AguardeDB.Fechar();

            double cota��oVarejo = Entidades.Financeiro.Cota��o.ObterCota��oVigente(Entidades.Moeda.ObterMoeda(4)).Valor;

            new Controles.Mercadorias.Indices(dsVelho, dsNovo).Transpor(cota��oVarejo, strSa�da);

            MySQL.AdicionarConex�esRemovidas(conex�esRemovidas);
        }
	}
}

