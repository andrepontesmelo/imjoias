using System;
using System.Collections.Generic;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Controles
{
	/// <summary>
	/// Transpõe-se aqui o mercadorias.
	/// Porém não transpoe o indice. é feito em Indice.cs
	/// Também não transpoe o vinculo entre mercadoria e componenete custo
	/// 
	/// A atualização é feita assim:
	/// se existe uma mercadoria com determinado código, então todos os outros
	/// valores são sobrescritos.
	/// </summary>
	public class CodBarras
	{
		private DataSet		dsVelho;	//Dataset dbf, que será gerado
		private DataSet		dsNovo;		//Dataset mysql, origem dos dados.
		private Dbf	dbf;
		private string nomeTabelaDbf;

        private Dictionary<string, DataRow> hashReferênciaItem;

        private void CriarHash()
        {
            DataRowCollection itens = dsNovo.Tables["mercadoria"].Rows;
            hashReferênciaItem = new Dictionary<string, DataRow>(itens.Count, StringComparer.Ordinal);

            foreach (DataRow itemAtual in itens)
                hashReferênciaItem.Add(itemAtual["referencia"].ToString().Trim(), itemAtual);
        }

		public CodBarras(string caminhoCompletoArquivo)
		{
			System.IO.FileInfo informaçõesArquivo;

			informaçõesArquivo = new System.IO.FileInfo(caminhoCompletoArquivo);
			nomeTabelaDbf = informaçõesArquivo.Name.Remove(informaçõesArquivo.Name.Length - informaçõesArquivo.Extension.Length, informaçõesArquivo.Extension.Length).ToUpper();
			dbf = new Dbf(informaçõesArquivo.Directory.FullName);
			
			if (System.IO.File.Exists(informaçõesArquivo.FullName))
				System.IO.File.Delete(informaçõesArquivo.FullName);

			dsVelho = new DataSet();
			dsNovo = new DataSet();

			dbf.ExecutaComando("CREATE TABLE " + nomeTabelaDbf + " (refe varchar(30), codi DECIMAL(11), peso DECIMAL(4,2))");
			dbf.AdicionarTabelaAoDataSet(dsVelho, nomeTabelaDbf);

			dsNovo = ObterDataSetMapeamentoCódigoBarras();
		}

        private static void AdicionarTabelaAoDataSet(DataSet ds, string tabela)
        {
            System.Data.Common.DbDataAdapter adaptador;

            adaptador = Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.CriarAdaptadorDados(Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.Conexão, "select * from " + tabela);

            adaptador.Fill(ds, tabela);
        }


        public DataSet ObterDataSetMapeamentoCódigoBarras()
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
			novo["refe"] = itemAtual["referencia"].ToString().Trim() + ObterDígitoVerificador(itemAtual["referencia"].ToString().Trim());
			novo["codi"] = itemAtual["codigo"].ToString().Trim();
			novo["peso"] = itemAtual["peso"].ToString().Trim();
			
            dsVelho.Tables[nomeTabelaDbf].Rows.Add(novo);
		}


		private String ObterDígitoVerificador(String referência)
		{
			DataRow dataRow;
			String dígito;

            if (!hashReferênciaItem.TryGetValue(referência, out dataRow))
                throw new Exception("Não foi possível encontrar mercadoria " + referência + " na tabela 'mercadoria' para saber o digito verificador");

			dígito = dataRow["digito"].ToString();
			return dígito.Trim();
		}

		public void Transpor()
		{
            Apresentação.Formulários.AguardeDB.Mostrar();

            CriarHash();
            
            foreach(DataRow itemAtual in dsNovo.Tables["mercadoriamapeamento"].Rows)
				TransporItem(itemAtual);

            dbf.Gravar(dsVelho, nomeTabelaDbf);
            Apresentação.Formulários.AguardeDB.Fechar();
		}
	}
}
