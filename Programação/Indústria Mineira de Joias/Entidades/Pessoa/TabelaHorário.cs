using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Acesso.Comum;

namespace Entidades.Pessoa
{
	/// <summary>
	/// Tabela de horário de funcionário.
	/// </summary>
	[Serializable]
	public class TabelaHorário : DbManipulação, IEnumerable
	{
		/// <summary>
		/// Dados do funcionário.
		/// </summary>
		private Funcionário funcionário;

		/// <summary>
		/// Lista de horários.
		/// </summary>
		private List<Horário> horários;

		/// <summary>
		/// Lista de remoção de horários.
		/// </summary>
        private List<Horário> listaRemoção = null;

		/// <summary>
		/// Constrói a tabela de horário para um funcionário.
		/// </summary>
		/// <param name="funcionário">Funcionário.</param>
		public TabelaHorário(Funcionário funcionário)
		{
            if (funcionário == null)
                throw new ArgumentNullException();

			this.funcionário = funcionário;

			Carregar();
		}

		internal TabelaHorário()
		{
            horários = new List<Horário>();
		}

        public Funcionário Funcionário
        {
            get { return funcionário; }
        }

		#region Manipulação do banco de dados

		/// <summary>
		/// Carregar tabela de horário.
		/// </summary>
		private void Carregar()
		{
			string comando = "SELECT * FROM horariofuncionario WHERE funcionario = "
					+ DbTransformar(funcionário.Código);

			horários = Mapear<Horário>(comando);
            horários.Sort();
		}

		/// <summary>
		/// Cadastra a tabela de horário.
		/// </summary>
		public override void Cadastrar()
		{
			Atualizar();
		}

		/// <summary>
		/// Cadastra tabela de horário.
		/// </summary>
		/// <param name="cmd">Comando para cadastro.</param>
		protected override void Cadastrar(System.Data.IDbCommand cmd)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Atualiza tabela de horário.
		/// </summary>
		public override void Atualizar()
		{
            if (listaRemoção != null)
            {
                foreach (Horário horário in listaRemoção)
                    if (horário.Cadastrado && !horários.Contains(horário))
                        horário.Descadastrar();

                listaRemoção = null;
            }
            
            foreach (Horário horário in horários)
			{
				if (horário.Cadastrado && !horário.Atualizado)
					horário.Atualizar();
				else if (!horário.Cadastrado)
					horário.Cadastrar();
			}
		}

		/// <summary>
		/// Atualiza tabela de horário.
		/// </summary>
		/// <param name="cmd">Comando de atualização.</param>
		protected override void Atualizar(System.Data.IDbCommand cmd)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Descadastra tabela de horário.
		/// </summary>
		public override void Descadastrar()
		{
			foreach (Horário horário in horários)
				if (horário.Cadastrado)
					horário.Descadastrar();
		}

		/// <summary>
		/// Descadastra tabela de horário.
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
			return horários.GetEnumerator();
		}

		#endregion

		#region Recuperação do banco de dados

		/// <summary>
		/// Carrega tabela de horários para uma coleção de funcionários.
		/// </summary>
		/// <param name="funcionários">Coleção de funcionários.</param>
		public static void Recuperar(ArrayList funcionários)
		{
			IDbConnection conexão;
			IDbCommand    cmd;
            IDataReader   leitor = null;				

			conexão = Conexão;
			cmd     = conexão.CreateCommand();

			cmd.CommandText = FormularComandoRecuperação(funcionários);

			funcionários.Sort(new Entidades.Pessoa.ComparadorCódigoPessoa());

            lock (conexão)
            {
 

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {
                        ulong funcAtual;			// Código do funcionário atual.
                        int cntFunc;			// Contador de funcionários.
                        Funcionário func;

                        funcAtual = 0;
                        cntFunc = 0;
                        func = null;

                        while (leitor.Read())
                        {
                            while (funcAtual != Convert.ToUInt64(leitor.GetValue(0)))
                            {
                                func = (Funcionário)funcionários[cntFunc++];
                                funcAtual = func.Código;
                                func.CriarTabelaHorárioVazia();
                            }

                            try
                            {
                                func.TabelaHorário.Adicionar(Horário.CriarHorárioCadastrado(
                                    funcAtual,
                                    (DayOfWeek)leitor.GetInt16(1),
                                    Convert.ToUInt16(leitor.GetValue(2)),
                                    Convert.ToUInt16(leitor.GetValue(3)),
                                    Convert.ToUInt16(leitor.GetValue(4)),
                                    Convert.ToUInt16(leitor.GetValue(5))));
                            }
                            catch (ExceçãoHorárioSobreposto e)
                            {
                                CorrigirHorários(e);
                            }


                            func.TabelaHorário.DefinirCadastrado();
                            func.TabelaHorário.DefinirAtualizado();
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
        /// Corrige dois horários que se sobrepuseram.
        /// </summary>
        /// <param name="e">Sobreposição de horários.</param>
        public static void CorrigirHorários(ExceçãoHorárioSobreposto e)
        {
            if (e.Horários[0].IniHora > e.Horários[1].IniHora)
            {
                e.Horários[0].IniHora = e.Horários[1].IniHora;
                e.Horários[0].IniMinuto = e.Horários[1].IniMinuto;
            }
            else if (e.Horários[0].IniHora == e.Horários[1].IniHora)
                e.Horários[0].IniMinuto = Math.Min(e.Horários[0].IniMinuto, e.Horários[1].IniMinuto);

            if (e.Horários[0].FimHora < e.Horários[1].FimHora)
            {
                e.Horários[0].FimHora = e.Horários[1].FimHora;
                e.Horários[0].FimMinuto = e.Horários[1].FimMinuto;
            }
            else if (e.Horários[0].FimHora == e.Horários[1].FimHora)
                e.Horários[0].FimMinuto = Math.Max(e.Horários[0].FimMinuto, e.Horários[1].FimMinuto);
        }

		/// <summary>
		/// Constrói comando para recuperação de horários para coleção de funcionários.
		/// </summary>
		/// <param name="funcionários">Coleção de funcionários.</param>
		/// <returns>Comando para recuperação de horários.</returns>
		private static string FormularComandoRecuperação(ICollection funcionários)
		{
			string strCmd;
			int    cnt;

			// Formular consulta.
			strCmd = "SELECT funcionario, diaSemana, iniHora, iniMinuto, fimHora, fimMinuto FROM horariofuncionario WHERE funcionario IN (";
			cnt    = 0;

			foreach (Funcionário funcionário in funcionários)
			{
				if (cnt++ > 0)
					strCmd += ", " + funcionário.Código.ToString();
				else
					strCmd += funcionário.Código.ToString();
			}

			return strCmd + ") ORDER BY funcionario";
		}

		#endregion

		/// <summary>
		/// Adiciona um horário à tabela.
		/// </summary>
		/// <param name="horário">Horário a ser adicionado.</param>
		public void Adicionar(Horário horário)
		{
			foreach (Horário aux in horários)
				if (aux.DiaSemana == horário.DiaSemana && aux <= horário)
					if (aux.FimHora > horário.IniHora || (aux.FimHora == horário.IniHora && aux.FimMinuto > horário.IniMinuto))
						throw new ExceçãoHorárioSobreposto(aux.Funcionário, aux, horário);

			horários.Add(horário);
            horários.Sort();

            DefinirDesatualizado();
		}

		/// <summary>
		/// Remove horário da tabela.
		/// </summary>
		/// <param name="horário">Horário a ser removido.</param>
		public void Remover(Horário horário)
		{
            if (listaRemoção == null)
                listaRemoção = new List<Horário>();

			horários.Remove(horário);
			listaRemoção.Add(horário);

            DefinirDesatualizado();
		}

        public void Limpar()
        {
            if (listaRemoção == null)
                listaRemoção = new List<Horário>(horários);
            else
                listaRemoção.AddRange(horários);

            horários.Clear();

            DefinirDesatualizado();
        }

		/// <summary>
		/// Obtém o horário atual.
		/// </summary>
		/// <returns>Horário atual.</returns>
		/// <remarks>Caso não tenha nenhum horário atual, será retornado o próximo.</remarks>
		public Horário ObterHorárioAtual()
		{
			if (horários.Count > 0)
			{
				// Realiza busca binária
				int ini, fim;
				DateTime agora;

				ini = 0;
				fim = horários.Count - 1;
				agora = DateTime.Now;

				while (fim > ini)
				{
					int     meio = (ini + fim) / 2;
					Horário horário = (Horário) horários[meio];

					if (horário.Compreende(agora))
						return horário;

					if (horário < agora)
						ini = meio + 1;
					else if (horário > agora)
						fim = meio - 1;
				}

				if (ini < horários.Count)
					return (Horário) horários[ini];
				else
					return (Horário) horários[fim >= 0 ? fim : 0];
			}
			else
				return null;
		}

        /// <summary>
        /// Calcula a carga horária semanal.
        /// </summary>
        /// <returns>Valor aproximado da carga horária semanal.</returns>
        public uint CalcularCargaHoráriaSemanal()
        {
            uint minutos = 0;

            foreach (Horário horário in horários)
                minutos += horário.CalcularMinutos();

            return (uint)Math.Round(minutos / 60f);
        }

        /// <summary>
        /// Obtém os horários de um dia da semana.
        /// </summary>
        /// <param name="dia">Dia da semana.</param>
        /// <returns>Lista de horários deste dia.</returns>
        public IList<Horário> ObterHorários(DayOfWeek dia)
        {
            List<Horário> lista = new List<Horário>(2);

            foreach (Horário horário in horários)
                if (horário.DiaSemana == dia)
                    lista.Add(horário);

            return lista;
        }
    }
}
