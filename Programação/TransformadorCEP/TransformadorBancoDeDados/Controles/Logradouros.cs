using System;
using System.Data;

namespace TransformadorBancoDeDados.Controles
{
	/// <summary>
	/// Summary description for Logradouros.
	/// </summary>
	public class Logradouros
	{
		DataSet dsNovo, dsVelho;
		System.Windows.Forms.ProgressBar pb;

		
		public Logradouros(DataSet dsNovoContr�i, DataSet dsVelhoContr�i, System.Windows.Forms.ProgressBar mpb)
		{
			dsNovo = dsNovoContr�i;
			dsVelho = dsVelhoContr�i;
			pb = mpb;
		}

		public void Trasp�e()
		{
			pb.Value = 0;
			pb.Maximum = dsVelho.Tables["LOG_LOGRADOURO"].Rows.Count;
			foreach (DataRow elemento in dsVelho.Tables["LOG_LOGRADOURO"].Rows)
			{
				Transp�eElemento(elemento);
				pb.Value++; pb.Update();
			}
		}
		private void Transp�eElemento(DataRow elemento)
		{
			DataRow novo;
			string complemento;
			string bairroFinal;

			novo = dsNovo.Tables["logradouros"].NewRow();
			novo["cep"] = elemento["cep"];
			complemento = elemento["LOG_COMPLEMENTO"].ToString().Trim();
			if (complemento.Length == 0)
			{
				novo["complemento"] = DBNull.Value;
			} 
			else
			{
				novo["complemento"] = complemento;
			}
			novo["cep"] = elemento["cep"];
			bairroFinal = elemento["BAI_NU_SEQUENCIAL_FIM"].ToString();
			if (bairroFinal == "")
				novo["bairrofinal"] = DBNull.Value;
			else
				novo["bairroFinal"] = bairroFinal;
			novo["bairroinicial"] = elemento["BAI_NU_SEQUENCIAL_INI"];
			novo["logradouro"] = elemento["LOG_NOME"].ToString().Trim();
			novo["localidade"] = elemento["LOC_NU_SEQUENCIAL"];
			dsNovo.Tables["logradouros"].Rows.Add(novo);
		}
	}
}
