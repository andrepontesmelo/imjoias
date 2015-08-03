using System;
using System.Collections;
namespace TransformadorBancoDeDados
{
	public class GerenciamentoEstados
	{
		private GerenciamentoEstados()
		{}

		private static MySql novo;
		private static Hashtable estados = new Hashtable();
		public static int ObterNúmeroSequencialEstado(String sigla)
		{
			sigla = corrigeSigla(sigla);
			if (estados.Contains(sigla))
			{
				Entidades.Estado estado;
				estado = (Entidades.Estado) estados[sigla];
				return estado.estado;
			} 
			else
			{
				Entidades.Estado novoEstado;
				novoEstado = new TransformadorBancoDeDados.Entidades.Estado();
				novoEstado.Sigla = sigla;
				novoEstado.estado = estados.Count;
				gravarNovoEstadoMySql(novoEstado);
				estados.Add(sigla,novoEstado);
				return novoEstado.estado;
			}			
		}
		private static void gravarNovoEstadoMySql(Entidades.Estado novoEstado)
		{
			novo.ComandoString("INSERT INTO `estados` (`estado`, `sigla`) VALUES (" + novoEstado.estado + ", '" + novoEstado.Sigla + "')");
		}
		private static String corrigeSigla(String sigla)
		{
			return sigla.Trim().ToUpper();
		}
		public static void DeterminarMySql(MySql mysql)
		{
			novo = mysql;
		}
	}
}
