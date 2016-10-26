using System;
using System.Collections.Generic;
using System.Data;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles
{
	/// <summary>
	/// Transp�e-se aqui o mercadorias.
	/// Por�m n�o transpoe o indice. � feito em Indice.cs
	/// Tamb�m n�o transpoe o vinculo entre mercadoria e componenete custo
	/// 
	/// A atualiza��o � feita assim:
	/// se existe uma mercadoria com determinado c�digo, ent�o todos os outros
	/// valores s�o sobrescritos.
	/// </summary>
	public class CodBarras
	{
		private DataSet		dsVelho;	//Dataset dbf, que ser� gerado
		private DataSet		dsNovo;		//Dataset mysql, origem dos dados.
		private Dbf	dbf;
		private string nomeTabelaDbf;

        private Dictionary<string, DataRow> hashRefer�nciaItem;

        private void CriarHash()
        {
            DataRowCollection itens = dsNovo.Tables["mercadoria"].Rows;
            hashRefer�nciaItem = new Dictionary<string, DataRow>(itens.Count, StringComparer.Ordinal);

            foreach (DataRow itemAtual in itens)
                hashRefer�nciaItem.Add(itemAtual["referencia"].ToString().Trim(), itemAtual);
        }

		public CodBarras(string caminhoCompletoArquivo)
		{
			System.IO.FileInfo informa��esArquivo;

			informa��esArquivo = new System.IO.FileInfo(caminhoCompletoArquivo);
			nomeTabelaDbf = informa��esArquivo.Name.Remove(informa��esArquivo.Name.Length - informa��esArquivo.Extension.Length, informa��esArquivo.Extension.Length).ToUpper();
			dbf = new Dbf(informa��esArquivo.Directory.FullName);
			
			if (System.IO.File.Exists(informa��esArquivo.FullName))
				System.IO.File.Delete(informa��esArquivo.FullName);

			dsVelho = new DataSet();
			dsNovo = new DataSet();

			dbf.ExecutaComando("CREATE TABLE " + nomeTabelaDbf + " (refe varchar(30), codi DECIMAL(11), peso DECIMAL(4,2))");
			dbf.AdicionarTabelaAoDataSet(dsVelho, nomeTabelaDbf);

			dsNovo = ObterDataSetMapeamentoC�digoBarras();
		}

        private static void AdicionarTabelaAoDataSet(DataSet ds, string tabela)
        {
            System.Data.Common.DbDataAdapter adaptador;

            adaptador = Apresenta��o.Formul�rios.Aplica��o.Aplica��oAtual.Usu�rio.CriarAdaptadorDados(Apresenta��o.Formul�rios.Aplica��o.Aplica��oAtual.Usu�rio.Conex�o, "select * from " + tabela);

            adaptador.Fill(ds, tabela);
        }


        public DataSet ObterDataSetMapeamentoC�digoBarras()
        {
            DataSet ds = new DataSet();

            AdicionarTabelaAoDataSet(ds, "mercadoriamapeamento");
            AdicionarTabelaAoDataSet(ds, "mercadoria");
            return ds;
        }

		private void TransporItem(DataRow itemAtual)
		{
			DataRow novo;

			novo = dsVelho.Tables[nomeTabelaDbf].NewRow();
			novo["refe"] = itemAtual["referencia"].ToString().Trim() + ObterD�gitoVerificador(itemAtual["referencia"].ToString().Trim());
			novo["codi"] = itemAtual["codigo"].ToString().Trim();
			novo["peso"] = itemAtual["peso"].ToString().Trim();
			
            dsVelho.Tables[nomeTabelaDbf].Rows.Add(novo);
		}


		private String ObterD�gitoVerificador(String refer�ncia)
		{
			DataRow dataRow;
			String d�gito;

            if (!hashRefer�nciaItem.TryGetValue(refer�ncia, out dataRow))
                throw new Exception("N�o foi poss�vel encontrar mercadoria " + refer�ncia + " na tabela 'mercadoria' para saber o digito verificador");

			d�gito = dataRow["digito"].ToString();
			return d�gito.Trim();
		}

		public void Transpor()
		{
            Apresenta��o.Formul�rios.AguardeDB.Mostrar();

            CriarHash();
            
            foreach(DataRow itemAtual in dsNovo.Tables["mercadoriamapeamento"].Rows)
				TransporItem(itemAtual);

            dbf.Gravar(dsVelho, nomeTabelaDbf);
            Apresenta��o.Formul�rios.AguardeDB.Fechar();
		}
	}
}
