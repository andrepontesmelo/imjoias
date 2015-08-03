/*
using System;
using System.Collections;


namespace HttpProxy.Configuração
{
	/// <summary>
	/// Summary description for UsrSql.
	/// </summary>
	public class UsrSql : IDisposable
	{
		static MySql banco;
		private bool downloadLista=false;
		private int tipoAcesso,id;
		private string ip;
		private ArrayList listaLinks= new ArrayList();
		public int Id 
		{
			get
			{
				return id;
			}
		}
		public int TipoAcesso 
		{
			get 
			{
				return tipoAcesso;
			}
		}
		//enderecoIp,tipoAcesso, id from ips,usuarios WHERE usuarios.id = ips.usuarioId";
		public UsrSql(string meuIp,int meuTipoAcesso,int meuId,MySql meuBanco)
		{
			banco = meuBanco;
			ip = meuIp;
			tipoAcesso = meuTipoAcesso;
			id = meuId;
		}

		public bool EstáNaLista(string link) 
		{
			if (downloadLista==false) 
			{
				//fazer o download da listá!
				listaLinks = banco.LerArrayList("SELECT host FROM links, permissao " +
					"WHERE links.id = permissao.linkId AND usuarioId = " + id.ToString() + " " +
					"UNION SELECT host FROM links, permissaoglobal " +
					"WHERE links.id = permissaoglobal.linkId");
				downloadLista = true;
			}

			foreach( string atual in listaLinks ) 
			{
				
				if ( link.EndsWith(atual) ) 
				{
					return true;
				}

			}
			return false;
		} 

		#region IDisposable Members

		public void Dispose()
		{
			banco.Dispose();
		}

		#endregion
	}
}
*/