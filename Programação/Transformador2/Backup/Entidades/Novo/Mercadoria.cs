using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Data;
using ByteFX.Data.MySqlClient;

namespace Entidades
{
	/// <summary>
	/// Mercadoria
	/// </summary>
	public class Mercadoria
	{
		// Atributos
		public string				referencia;
		public int					digito = -1;
		public string				nome;
		public float				teor;
		public double				peso;
		public char				faixa;
		public int					grupo;
		public double				indice;
		public bool				linha;
		
		public bool ConferirMercadoriaJ·Existente(Transformador2.Acesso.MySql mysql)
		{
			return false;
		}

	}

}
