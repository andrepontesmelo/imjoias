using System;
using System.Data;

namespace TransformadorBancoDeDados.Controles
{
	/// <summary>
	/// Summary description for Logradouros.
	/// </summary>
	public class CaixasPostaisComunitárias
	{
		DataSet dsNovo, dsVelho;
		System.Windows.Forms.ProgressBar pb;

		
		public CaixasPostaisComunitárias(DataSet dsNovoContrói, DataSet dsVelhoContrói, System.Windows.Forms.ProgressBar mpb)
		{
			dsNovo = dsNovoContrói;
			dsVelho = dsVelhoContrói;
			pb = mpb;
		}

		public void Traspõe()
		{
			pb.Value = 0;
			pb.Maximum = dsVelho.Tables["LOG_CPC"].Rows.Count;
			foreach (DataRow elemento in dsVelho.Tables["LOG_CPC"].Rows)
			{
				TranspõeElemento(elemento);
				pb.Value++; pb.Update();
			}
		}
		private void TranspõeElemento(DataRow elemento)
		{
			DataRow novo;
			string complemento;
			string bairroFinal;

			novo = dsNovo.Tables["logradouros"].NewRow();
			novo["cep"] = elemento["cep"];
			complemento = elemento["CPC_NO"].ToString().Trim();
			if (complemento.Length == 0)
			{
				novo["complemento"] = DBNull.Value;
			} 
			else
			{
				novo["complemento"] = complemento;
			}
			novo["cep"] = elemento["cep"];
			novo["bairroFinal"] = DBNull.Value;
			novo["bairroinicial"] = DBNull.Value;
			novo["logradouro"] = elemento["cpc_endereco"].ToString().Trim();
			novo["localidade"] = elemento["LOC_NU_SEQUENCIAL"];
			dsNovo.Tables["logradouros"].Rows.Add(novo);
		}
	}
}
