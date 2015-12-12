using Apresentação.Formulários;
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

        public void ImportarDadosDoSistemaLegado()
        {
            FolderBrowserDialog pasta = new FolderBrowserDialog();
            pasta.ShowNewFolderButton = false;

            if (pasta.ShowDialog() != DialogResult.OK)
                return;

            DataSet dsNovo;
            DataSet dsVelho = new DataSet();
            Dbf dbf = null;
            StringBuilder strSaída;
            
            DateTime inicio = DateTime.Now;

            Transpor(ref dsVelho, pasta.SelectedPath, ref dbf, out dsNovo, out strSaída);

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

        private void Transpor(ref DataSet dsVelho, string diretório, ref Dbf dbf, out DataSet dsNovo, out StringBuilder strSaída)
        {
            AguardeDB.Mostrar();

            strSaída = new StringBuilder(" === Saída do Processo de Integração ===");
            strSaída.AppendLine();

            List<IDbConnection> conexõesRemovidas = new List<IDbConnection>();
            dsNovo = ObterDataSetMercadoria(conexõesRemovidas);

            Controles.Mercadorias.Faixas.dsNovo = dsNovo;

            dbf = new Apresentação.IntegraçãoSistemaAntigo.Dbf(diretório);
            dsVelho = dbf.ObterDataSetMercadoria();
            new Controles.Mercadorias.Gramas(dsVelho).Transpor(strSaída);
            new Controles.Mercadorias.Fornecedor(dsVelho, dsNovo, dbf);
            new Controles.Mercadorias.ComponenteDeCusto(dsVelho, dsNovo, dbf).Transpor();
            new Controles.Mercadorias.Mercadorias(dsVelho, dsNovo, dbf).Transpor(strSaída);
            new Controles.Mercadorias.VinculoMercadoriaComponenteCusto(dsVelho, dsNovo).Transpor(strSaída);
            MySQL.GravarDataSetTodasTabelas(dsNovo);

            AguardeDB.Fechar();

            double cotaçãoVarejo = Entidades.Financeiro.Cotação.ObterCotaçãoVigente(Entidades.Moeda.ObterMoeda(4)).Valor;

            new Controles.Mercadorias.Indices(dsVelho, dsNovo).Transpor(cotaçãoVarejo, strSaída);

            MySQL.AdicionarConexõesRemovidas(conexõesRemovidas);
        }
	}
}

