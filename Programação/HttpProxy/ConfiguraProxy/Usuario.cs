using System;
using System.Collections;
namespace ConfiguraProxy
{
	/// <summary>
	/// Summary description for Usuario.
	/// </summary>
	

	public class Usuario
	{
		private string nome;
		private int tipoAcesso,id;
		private ArrayList hosts,ips;

		//Propriedades: 
		public ArrayList Ips 
		{
			get
			{
				return ips;
			}
		}
		
		public int Id 
		{
			get
			{
				return id;
			}
			set 
			{
				id = value;
			}

		}

		public ArrayList Hosts 
		{
			get 
			{
				return hosts;
			}
		}

		public int TipoAcesso 
		{
			get 
			{
				return tipoAcesso;
			}
			set 
			{
				tipoAcesso = value;
			}
		}

		public string Nome 
		{
			get 
			{
				return nome;
			}
			set 
			{
				nome = value;
			}
		}
		

		
		public Usuario()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public void ColetarDados(MySql banco,String meuNome) 
		{
			nome = meuNome;
			//tipoAcesso = Convert.ToInt32( banco.ComandoString("select tipoAcesso from usuarios where nome='" + nome + "'") );
			tipoAcesso = banco.ComandoInt("select tipoAcesso from usuarios where nome='" + nome + "'");
			id = banco.ComandoInt("select id from usuarios where nome='" + nome + "'");
			PegarHosts(banco);
			PegarIps(banco);
		}
		public void PegarIps(MySql banco) 
		{
			ips = banco.LerArrayList("select enderecoIp from ips where usuarioId='" + id.ToString() + "'");
		}

		public void Gravar(MySql banco) 
		{
			banco.ComandoString("UPDATE `usuarios` SET `nome`='" + nome + "',`tipoAcesso`=" + tipoAcesso.ToString()  + " WHERE `id`=" + id.ToString());
		}

		public void PegarHosts(MySql banco) 
		{
			hosts = banco.LerArrayList("SELECT host FROM usuarios,permissao,links WHERE usuarios.id = permissao.usuarioId AND permissao.linkId = links.id AND nome ='" + nome + "'");
		}
	}

}
