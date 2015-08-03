using System;
using System.Collections;

namespace Proxy.Clientes
{
	/// <summary>
	/// Gerencia os perfis
	/// </summary>
	/// <remarks>Singleton</remarks>
	public class GerentePerfis
	{
		private ArrayList		perfis;

		public static GerentePerfis instância = new GerentePerfis();
		public static GerentePerfis Instância { get { return instância; } }

		/// <summary>
		/// Constrói gerente de perfis
		/// </summary>
		private GerentePerfis()
		{
			perfis = new ArrayList();
		}

		/// <summary>
		/// Obtém o perfil de um IP
		/// </summary>
		public Perfil [] this[byte [] ip]
		{
			get
			{
				ArrayList resposta = new ArrayList();

				foreach (Perfil perfil in perfis)
					if (perfil.VerificarEnquadramento(ip))
						resposta.Add(perfil);

				return (Perfil []) resposta.ToArray(typeof(Perfil));
			}
		}

		/// <summary>
		/// Adiciona um perfil à lista
		/// </summary>
		/// <param name="perfil">Perfil a ser adicionado</param>
		public void AdicionarPerfil(Perfil perfil)
		{
			perfis.Add(perfil);
		}
	}
}
