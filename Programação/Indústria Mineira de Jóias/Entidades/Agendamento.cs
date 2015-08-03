using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades
{
	[Serializable] 
	public class Agendamento : DbManipulaçãoAutomática
	{
		[DbChavePrimária(true)]
		private long codigo;
		private DateTime data;
		private string descricao;
		private DateTime alarme;

        [DbColuna("funcionario")]
        private ulong? funcionário;

		#region Propriedades

		public DateTime Data
		{
			get { return data; }
            set { data = value; DefinirDesatualizado(); }
		}
		
		public long Código
		{
			get { return codigo; }
            set { codigo = value; DefinirDesatualizado(); }
		}

		public string Descrição
		{
			get { return descricao; }
            set { descricao = value; DefinirDesatualizado(); }
		}


		public DateTime Alarme
		{
			get { return alarme; }
            set { alarme = value; DefinirDesatualizado(); }
		}
		public bool Despertar
		{
			get 
			{
				if (alarme == DateTime.MinValue) 
				{
					return false;
				} 
				else return true;
			}
		}
		
		/// <summary>
		/// Hora do alarme é menor que hora atual
		/// </summary>
		public bool AlarmeNoPassado
		{
			get
			{
				// Adiciona uma folga computacional de 5 segundos.
				return DateTime.Compare(DateTime.Now.AddMilliseconds(5000), alarme) > 0;
			}
		}

		/// <summary>
		/// Tempo restante para despertar
		/// </summary>
		public TimeSpan AlarmeTempoRestante
		{
			get
			{
				if (AlarmeNoPassado)
					throw new Exception("Alarme está no passado. Não é possível descobrir Agendamento.AlarmeTempoRestante");

				return alarme - DateTime.Now;
			}
		}

			#endregion

        public Agendamento()
        {
            this.funcionário = ObterFuncionárioAtual();
        }

        /// <summary>
        /// Obtém o código do funcionário atual.
        /// </summary>
        /// <returns>Código do funcionário atual.</returns>
        private static ulong? ObterFuncionárioAtual()
        {
            Entidades.Pessoa.Funcionário funcionário;

            funcionário = Entidades.Pessoa.Funcionário.FuncionárioAtual;

            if (funcionário != null)
                return funcionário.Código;
            else
                return null;
        }

		/// <summary>
		/// Pega um arraylist de agendamentos de um dia específico
		/// </summary>
		/// <param name="diaEspecífico">Só o dia do DateTime importa, dia referente aos agendamentos</param>
		/// <returns>Lista de agendamentos</returns>
        public static Agendamento[] ObterAgendamentos(DateTime diaEspecífico)
        {
            IDbConnection conexão = Conexão;


            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    //devemos transformar o diaEspecífico 01/02/04 08:32:44 em 01/02/04 00:00:00
                    diaEspecífico = diaEspecífico.Date;

                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        ulong? func = ObterFuncionárioAtual();

                        cmd.CommandText = @"SELECT * FROM agendamento WHERE data>=" +
                            DbTransformar(diaEspecífico) +
                            " AND data<" + DbTransformar(diaEspecífico.AddDays(1)) +
                            (func.HasValue ? " AND funcionario = " + DbTransformar(func.Value) : " AND funcionario is null") +
                            " ORDER BY data";

                        return Mapear<Entidades.Agendamento>(cmd).ToArray();
                    }
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }
        }

		/// <summary>
		/// Obtém agendamento a partir do código.
		/// </summary>
		/// <param name="código">Código do agendamento.</param>
		/// <returns>Agendamento.</returns>
		public static Agendamento ObterAgendamento(int código)
		{
			return MapearÚnicaLinha<Agendamento>(
				@"SELECT * FROM agendamento WHERE codigo = " + DbTransformar(código));
		}
		
		/// <summary>
		/// Obtém o próximo agendamento a despertar, pode ser nulo.
		/// </summary>
		public static Entidades.Agendamento ObterPróximo() 
		{
			Agendamento próximoAgendamento = new Entidades.Agendamento();
            ulong? func = ObterFuncionárioAtual();
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    IDataReader leitor = null;
                    DateTime daquiAUmaSemana;
                    TimeSpan umaSemana = new TimeSpan(7, 0, 0, 0, 0);
                    daquiAUmaSemana = DateTime.Now + umaSemana;

                    cmd.CommandText =
                        @"SELECT codigo,descricao,data,alarme FROM agendamento WHERE " +
                        "alarme is not NULL " +
                        "AND alarme < " + DbTransformar(daquiAUmaSemana) +
                        (func.HasValue ? " AND funcionario = " + DbTransformar(func.Value) : " AND funcionario is null") +
                        " ORDER BY alarme LIMIT 1";

                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                        using (leitor = cmd.ExecuteReader())
                        {

                            if (leitor.Read() == false)
                                return null;

                            próximoAgendamento.Código = (int)leitor[0];
                            próximoAgendamento.DefinirCadastrado();
                            próximoAgendamento.DefinirAtualizado();

                            try
                            {
                                próximoAgendamento.Descrição = leitor.GetString(1);
                            }
                            catch
                            {
                                próximoAgendamento.Descrição = "";
                            }

                            próximoAgendamento.Data = leitor.GetDateTime(2);

                            try
                            {
                                próximoAgendamento.Alarme = leitor.GetDateTime(3);
                            }
                            catch
                            {
                                próximoAgendamento.Alarme = new DateTime(1);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null && !leitor.IsClosed)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);

                    }
                }
			
			return próximoAgendamento;
		}

		/// <summary>
		/// Desliga despertador.
		/// </summary>
		public void DesligarDespertador()
		{
			IDbConnection conexão;

			conexão = Conexão;

			using (IDbCommand cmd = conexão.CreateCommand())
			{
				cmd.CommandText =
					"UPDATE agendamento SET alarme = NULL WHERE codigo = " +
					DbTransformar(this.codigo);

				try
				{
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

					lock (conexão)
						if (cmd.ExecuteNonQuery() != 1)
							throw new Exception("Não foi possível desligar o despertador para o agendamento.");
				}
				catch (Exception e)
				{
					throw new Exception(e.ToString());
                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);

                }
			}
		}

        /// <summary>
        /// Obtém agendamentos despertados.
        /// </summary>
        /// <returns>Lista de agendamentos despertados.</returns>
        public static IList<Agendamento> ObterAgendamentosDespertados()
        {
            IDbConnection conexão;
            List<Agendamento> agendamentos;
            ulong? func = ObterFuncionárioAtual();

            agendamentos = new List<Agendamento>();

            conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    IDataReader leitor = null;

                    cmd.CommandText =
                        @"SELECT codigo,descricao,data,alarme FROM agendamento WHERE" +
                        " alarme < NOW()" +
                        (func.HasValue ? " AND funcionario = " + DbTransformar(func.Value) : " AND funcionario is null") +
                        " ORDER BY alarme";

                    try
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);


                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                Agendamento agendamento = new Agendamento();

                                agendamento.codigo = leitor.GetInt64(0);
                                agendamento.descricao = leitor.GetString(1);
                                agendamento.data = leitor.GetDateTime(2);
                                agendamento.alarme = leitor.GetDateTime(3);

                                agendamentos.Add(agendamento);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }

            return agendamentos;
        }
    }
}
