using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Armazena métodos de diversos tipos para recuperação
	/// no banco de dados.
	/// </summary>
	internal class MétodosRecuperação
	{
		private Dictionary<Type, MethodInfo[]> hashMétodos = new Dictionary<Type,MethodInfo[]>();

		/// <summary>
		/// Obtém métodos para recuperação de um tipo de entidade.
		/// </summary>
		public MethodInfo [] this[Type tipo]
		{
			get
			{
				MethodInfo [] métodos;

                if (!hashMétodos.TryGetValue(tipo, out métodos))
					return ExtrairMétodos(tipo);

				return métodos;
			}
		}

		/// <summary>
		/// Extrai métodos estáticos para recuperação do banco de dados.
		/// </summary>
		/// <param name="tipo">Tipo em que serão extraídos os métodos estáticos.</param>
		/// <returns>Métodos para recuperação do tipo no banco de dados.</returns>
		private MethodInfo [] ExtrairMétodos(Type tipo)
		{
			List<MethodInfo> métodos = new List<MethodInfo>();
			Cacheável[] atributos;
			MethodInfo[] vetorMétodos;

			atributos = (Cacheável []) tipo.GetCustomAttributes(typeof(Cacheável), true);

			foreach (Cacheável atributo in atributos)
				foreach (string método in atributo.Métodos)
#if !DEBUG
                    try
                    {
                        métodos.Add(tipo.GetMethod(método, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
                    }
                    catch (AmbiguousMatchException)
#endif
                    {
                        foreach (MethodInfo inf in tipo.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                            if (inf.Name == método)
                                métodos.Add(inf);
                    }

            vetorMétodos      = (MethodInfo []) métodos.ToArray();

            if (hashMétodos.ContainsKey(tipo))
                throw new Exception("método para recuperação já adicionada na hash: " + tipo.ToString());
            else
                hashMétodos.Add(tipo, vetorMétodos);

			return vetorMétodos;
		}
	}
}
