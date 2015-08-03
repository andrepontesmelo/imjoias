using System;
using System.Data;

namespace TransformadorBancoDeDados.Controles
{
	/// <summary>
	/// Summary description for Logradouros.
	/// </summary>
	public class UnidadesOperação
	{
		DataSet dsNovo, dsVelho;
		System.Windows.Forms.ProgressBar pb;

		
		public UnidadesOperação(DataSet dsNovoContrói, DataSet dsVelhoContrói, System.Windows.Forms.ProgressBar mpb)
		{
			dsNovo = dsNovoContrói;
			dsVelho = dsVelhoContrói;
			pb = mpb;
		}

		public void Traspõe()
		{
			pb.Value = 0;
			pb.Maximum = dsVelho.Tables["LOG_UNID_OPER"].Rows.Count;
			foreach (DataRow elemento in dsVelho.Tables["LOG_UNID_OPER"].Rows)
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
			complemento = elemento["UOP_NO"].ToString().Trim();
			if (complemento.Length == 0)
			{
				novo["complemento"] = DBNull.Value;
			} 
			else
			{
				novo["complemento"] = complemento;
			}
			novo["cep"] = elemento["cep"];
			novo["bairroinicial"] = elemento["bai_nu_sequencial"];
			novo["logradouro"] = elemento["UOP_endereco"].ToString().Trim();
			novo["localidade"] = elemento["LOC_NU_SEQUENCIAL"];
			dsNovo.Tables["logradouros"].Rows.Add(novo);
		}
	}
}
