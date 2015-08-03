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

		public static GerentePerfis inst�ncia = new GerentePerfis();
		public static GerentePerfis Inst�ncia { get { return inst�ncia; } }

		/// <summary>
		/// Constr�i gerente de perfis
		/// </summary>
		private GerentePerfis()
		{
			perfis = new ArrayList();
		}

		/// <summary>
		/// Obt�m o perfil de um IP
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
		/// Adiciona um perfil � lista
		/// </summary>
		/// <param name="perfil">Perfil a ser adicionado</param>
		public void AdicionarPerfil(Perfil perfil)
		{
			perfis.Add(perfil);
		}
	}
}
