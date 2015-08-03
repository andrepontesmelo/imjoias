using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Acesso.Comum.Cache
{
	/// <summary>
	/// Armazena m�todos de diversos tipos para recupera��o
	/// no banco de dados.
	/// </summary>
	internal class M�todosRecupera��o
	{
		private Dictionary<Type, MethodInfo[]> hashM�todos = new Dictionary<Type,MethodInfo[]>();

		/// <summary>
		/// Obt�m m�todos para recupera��o de um tipo de entidade.
		/// </summary>
		public MethodInfo [] this[Type tipo]
		{
			get
			{
				MethodInfo [] m�todos;

                if (!hashM�todos.TryGetValue(tipo, out m�todos))
					return ExtrairM�todos(tipo);

				return m�todos;
			}
		}

		/// <summary>
		/// Extrai m�todos est�ticos para recupera��o do banco de dados.
		/// </summary>
		/// <param name="tipo">Tipo em que ser�o extra�dos os m�todos est�ticos.</param>
		/// <returns>M�todos para recupera��o do tipo no banco de dados.</returns>
		private MethodInfo [] ExtrairM�todos(Type tipo)
		{
			List<MethodInfo> m�todos = new List<MethodInfo>();
			Cache�vel[] atributos;
			MethodInfo[] vetorM�todos;

			atributos = (Cache�vel []) tipo.GetCustomAttributes(typeof(Cache�vel), true);

			foreach (Cache�vel atributo in atributos)
				foreach (string m�todo in atributo.M�todos)
#if !DEBUG
                    try
                    {
                        m�todos.Add(tipo.GetMethod(m�todo, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
                    }
                    catch (AmbiguousMatchException)
#endif
                    {
                        foreach (MethodInfo inf in tipo.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                            if (inf.Name == m�todo)
                                m�todos.Add(inf);
                    }

            vetorM�todos      = (MethodInfo []) m�todos.ToArray();

            if (hashM�todos.ContainsKey(tipo))
                throw new Exception("m�todo para recupera��o j� adicionada na hash: " + tipo.ToString());
            else
                hashM�todos.Add(tipo, vetorM�todos);

			return vetorM�todos;
		}
	}
}
