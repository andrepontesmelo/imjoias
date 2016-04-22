using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Acesso.Comum;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Tabela de hor�rio de funcion�rio.
	/// </summary>
	[Serializable]
	public class TabelaHor�rio : DbManipula��o, IEnumerable
	{
		/// <summary>
		/// Dados do funcion�rio.
		/// </summary>
		private Funcion�rio funcion�rio;

		/// <summary>
		/// Lista de hor�rios.
		/// </summary>
		private List<Hor�rio> hor�rios;

		/// <summary>
		/// Lista de remo��o de hor�rios.
		/// </summary>
        private List<Hor�rio> listaRemo��o = null;

		/// <summary>
		/// Constr�i a tabela de hor�rio para um funcion�rio.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio.</param>
		public TabelaHor�rio(Funcion�rio funcion�rio)
		{
            if (funcion�rio == null)
                throw new ArgumentNullException();

			this.funcion�rio = funcion�rio;

			Carregar();
		}

		internal TabelaHor�rio()
		{
            hor�rios = new List<Hor�rio>();
		}

        public Funcion�rio Funcion�rio
        {
            get { return funcion�rio; }
        }

		#region Manipula��o do banco de dados

		/// <summary>
		/// Carregar tabela de hor�rio.
		/// </summary>
		private void Carregar()
		{
			string comando = "SELECT * FROM horariofuncionario WHERE funcionario = "
					+ DbTransformar(funcion�rio.C�digo);

			hor�rios = Mapear<Hor�rio>(comando);
            hor�rios.Sort();
		}

		/// <summary>
		/// Cadastra a tabela de hor�rio.
		/// </summary>
		public override void Cadastrar()
		{
			Atualizar();
		}

		/// <summary>
		/// Cadastra tabela de hor�rio.
		/// </summary>
		/// <param name="cmd">Comando para cadastro.</param>
		protected override void Cadastrar(System.Data.IDbCommand cmd)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Atualiza tabela de hor�rio.
		/// </summary>
		public override void Atualizar()
		{
            if (listaRemo��o != null)
            {
                foreach (Hor�rio hor�rio in listaRemo��o)
                    if (hor�rio.Cadastrado && !hor�rios.Contains(hor�rio))
                        hor�rio.Descadastrar();

                listaRemo��o = null;
            }
            
            foreach (Hor�rio hor�rio in hor�rios)
			{
				if (hor�rio.Cadastrado && !hor�rio.Atualizado)
					hor�rio.Atualizar();
				else if (!hor�rio.Cadastrado)
					hor�rio.Cadastrar();
			}
		}

		/// <summary>
		/// Atualiza tabela de hor�rio.
		/// </summary>
		/// <param name="cmd">Comando de atualiza��o.</param>
		protected override void Atualizar(System.Data.IDbCommand cmd)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Descadastra tabela de hor�rio.
		/// </summary>
		public override void Descadastrar()
		{
			foreach (Hor�rio hor�rio in hor�rios)
				if (hor�rio.Cadastrado)
					hor�rio.Descadastrar();
		}

		/// <summary>
		/// Descadastra tabela de hor�rio.
		/// </summary>
		/// <param name="cmd">Comando de descadastramento.</param>
		protected override void Descadastrar(System.Data.IDbCommand cmd)
		{
			throw new NotSupportedException();
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return hor�rios.GetEnumerator();
		}

		#endregion

		#region Recupera��o do banco de dados

		/// <summary>
		/// Carrega tabela de hor�rios para uma cole��o de funcion�rios.
		/// </summary>
		/// <param name="funcion�rios">Cole��o de funcion�rios.</param>
		public static void Recuperar(ArrayList funcion�rios)
		{
			IDbConnection conex�o;
			IDbCommand    cmd;
            IDataReader   leitor = null;				

			conex�o = Conex�o;
			cmd     = conex�o.CreateCommand();

			cmd.CommandText = FormularComandoRecupera��o(funcion�rios);

			funcion�rios.Sort(new Entidades.Pessoa.ComparadorC�digoPessoa());

            lock (conex�o)
            {
 

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {
                        ulong funcAtual;			// C�digo do funcion�rio atual.
                        int cntFunc;			// Contador de funcion�rios.
                        Funcion�rio func;

                        funcAtual = 0;
                        cntFunc = 0;
                        func = null;

                        while (leitor.Read())
                        {
                            while (funcAtual != Convert.ToUInt64(leitor.GetValue(0)))
                            {
                                func = (Funcion�rio)funcion�rios[cntFunc++];
                                funcAtual = func.C�digo;
                                func.CriarTabelaHor�rioVazia();
                            }

                            try
                            {
                                func.TabelaHor�rio.Adicionar(Hor�rio.CriarHor�rioCadastrado(
                                    funcAtual,
                                    (DayOfWeek)leitor.GetInt16(1),
                                    Convert.ToUInt16(leitor.GetValue(2)),
                                    Convert.ToUInt16(leitor.GetValue(3)),
                                    Convert.ToUInt16(leitor.GetValue(4)),
                                    Convert.ToUInt16(leitor.GetValue(5))));
                            }
                            catch (Exce��oHor�rioSobreposto e)
                            {
                                CorrigirHor�rios(e);
                            }


                            func.TabelaHor�rio.DefinirCadastrado();
                            func.TabelaHor�rio.DefinirAtualizado();
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();
                }
            }
		}

        /// <summary>
        /// Corrige dois hor�rios que se sobrepuseram.
        /// </summary>
        /// <param name="e">Sobreposi��o de hor�rios.</param>
        public static void CorrigirHor�rios(Exce��oHor�rioSobreposto e)
        {
            if (e.Hor�rios[0].IniHora > e.Hor�rios[1].IniHora)
            {
                e.Hor�rios[0].IniHora = e.Hor�rios[1].IniHora;
                e.Hor�rios[0].IniMinuto = e.Hor�rios[1].IniMinuto;
            }
            else if (e.Hor�rios[0].IniHora == e.Hor�rios[1].IniHora)
                e.Hor�rios[0].IniMinuto = Math.Min(e.Hor�rios[0].IniMinuto, e.Hor�rios[1].IniMinuto);

            if (e.Hor�rios[0].FimHora < e.Hor�rios[1].FimHora)
            {
                e.Hor�rios[0].FimHora = e.Hor�rios[1].FimHora;
                e.Hor�rios[0].FimMinuto = e.Hor�rios[1].FimMinuto;
            }
            else if (e.Hor�rios[0].FimHora == e.Hor�rios[1].FimHora)
                e.Hor�rios[0].FimMinuto = Math.Max(e.Hor�rios[0].FimMinuto, e.Hor�rios[1].FimMinuto);
        }

		/// <summary>
		/// Constr�i comando para recupera��o de hor�rios para cole��o de funcion�rios.
		/// </summary>
		/// <param name="funcion�rios">Cole��o de funcion�rios.</param>
		/// <returns>Comando para recupera��o de hor�rios.</returns>
		private static string FormularComandoRecupera��o(ICollection funcion�rios)
		{
			string strCmd;
			int    cnt;

			// Formular consulta.
			strCmd = "SELECT funcionario, diaSemana, iniHora, iniMinuto, fimHora, fimMinuto FROM horariofuncionario WHERE funcionario IN (";
			cnt    = 0;

			foreach (Funcion�rio funcion�rio in funcion�rios)
			{
				if (cnt++ > 0)
					strCmd += ", " + funcion�rio.C�digo.ToString();
				else
					strCmd += funcion�rio.C�digo.ToString();
			}

			return strCmd + ") ORDER BY funcionario";
		}

		#endregion

		/// <summary>
		/// Adiciona um hor�rio � tabela.
		/// </summary>
		/// <param name="hor�rio">Hor�rio a ser adicionado.</param>
		public void Adicionar(Hor�rio hor�rio)
		{
			foreach (Hor�rio aux in hor�rios)
				if (aux.DiaSemana == hor�rio.DiaSemana && aux <= hor�rio)
					if (aux.FimHora > hor�rio.IniHora || (aux.FimHora == hor�rio.IniHora && aux.FimMinuto > hor�rio.IniMinuto))
						throw new Exce��oHor�rioSobreposto(aux.Funcion�rio, aux, hor�rio);

			hor�rios.Add(hor�rio);
            hor�rios.Sort();

            DefinirDesatualizado();
		}

		/// <summary>
		/// Remove hor�rio da tabela.
		/// </summary>
		/// <param name="hor�rio">Hor�rio a ser removido.</param>
		public void Remover(Hor�rio hor�rio)
		{
            if (listaRemo��o == null)
                listaRemo��o = new List<Hor�rio>();

			hor�rios.Remove(hor�rio);
			listaRemo��o.Add(hor�rio);

            DefinirDesatualizado();
		}

        public void Limpar()
        {
            if (listaRemo��o == null)
                listaRemo��o = new List<Hor�rio>(hor�rios);
            else
                listaRemo��o.AddRange(hor�rios);

            hor�rios.Clear();

            DefinirDesatualizado();
        }

		/// <summary>
		/// Obt�m o hor�rio atual.
		/// </summary>
		/// <returns>Hor�rio atual.</returns>
		/// <remarks>Caso n�o tenha nenhum hor�rio atual, ser� retornado o pr�ximo.</remarks>
		public Hor�rio ObterHor�rioAtual()
		{
			if (hor�rios.Count > 0)
			{
				// Realiza busca bin�ria
				int ini, fim;
				DateTime agora;

				ini = 0;
				fim = hor�rios.Count - 1;
				agora = DateTime.Now;

				while (fim > ini)
				{
					int     meio = (ini + fim) / 2;
					Hor�rio hor�rio = (Hor�rio) hor�rios[meio];

					if (hor�rio.Compreende(agora))
						return hor�rio;

					if (hor�rio < agora)
						ini = meio + 1;
					else if (hor�rio > agora)
						fim = meio - 1;
				}

				if (ini < hor�rios.Count)
					return (Hor�rio) hor�rios[ini];
				else
					return (Hor�rio) hor�rios[fim >= 0 ? fim : 0];
			}
			else
				return null;
		}

        /// <summary>
        /// Calcula a carga hor�ria semanal.
        /// </summary>
        /// <returns>Valor aproximado da carga hor�ria semanal.</returns>
        public uint CalcularCargaHor�riaSemanal()
        {
            uint minutos = 0;

            foreach (Hor�rio hor�rio in hor�rios)
                minutos += hor�rio.CalcularMinutos();

            return (uint)Math.Round(minutos / 60f);
        }

        /// <summary>
        /// Obt�m os hor�rios de um dia da semana.
        /// </summary>
        /// <param name="dia">Dia da semana.</param>
        /// <returns>Lista de hor�rios deste dia.</returns>
        public IList<Hor�rio> ObterHor�rios(DayOfWeek dia)
        {
            List<Hor�rio> lista = new List<Hor�rio>(2);

            foreach (Hor�rio hor�rio in hor�rios)
                if (hor�rio.DiaSemana == dia)
                    lista.Add(hor�rio);

            return lista;
        }
    }
}
