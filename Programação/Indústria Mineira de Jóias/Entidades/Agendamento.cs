using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Acesso.Comum;

namespace Entidades
{
	[Serializable] 
	public class Agendamento : DbManipula��oAutom�tica
	{
		[DbChavePrim�ria(true)]
		private long codigo;
		private DateTime data;
		private string descricao;
		private DateTime alarme;

        [DbColuna("funcionario")]
        private ulong? funcion�rio;

		#region Propriedades

		public DateTime Data
		{
			get { return data; }
            set { data = value; DefinirDesatualizado(); }
		}
		
		public long C�digo
		{
			get { return codigo; }
            set { codigo = value; DefinirDesatualizado(); }
		}

		public string Descri��o
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
		/// Hora do alarme � menor que hora atual
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
					throw new Exception("Alarme est� no passado. N�o � poss�vel descobrir Agendamento.AlarmeTempoRestante");

				return alarme - DateTime.Now;
			}
		}

			#endregion

        public Agendamento()
        {
            this.funcion�rio = ObterFuncion�rioAtual();
        }

        /// <summary>
        /// Obt�m o c�digo do funcion�rio atual.
        /// </summary>
        /// <returns>C�digo do funcion�rio atual.</returns>
        private static ulong? ObterFuncion�rioAtual()
        {
            Entidades.Pessoa.Funcion�rio funcion�rio;

            funcion�rio = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;

            if (funcion�rio != null)
                return funcion�rio.C�digo;
            else
                return null;
        }

		/// <summary>
		/// Pega um arraylist de agendamentos de um dia espec�fico
		/// </summary>
		/// <param name="diaEspec�fico">S� o dia do DateTime importa, dia referente aos agendamentos</param>
		/// <returns>Lista de agendamentos</returns>
        public static Agendamento[] ObterAgendamentos(DateTime diaEspec�fico)
        {
            IDbConnection conex�o = Conex�o;


            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                try
                {
                    //devemos transformar o diaEspec�fico 01/02/04 08:32:44 em 01/02/04 00:00:00
                    diaEspec�fico = diaEspec�fico.Date;

                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        ulong? func = ObterFuncion�rioAtual();

                        cmd.CommandText = @"SELECT * FROM agendamento WHERE data>=" +
                            DbTransformar(diaEspec�fico) +
                            " AND data<" + DbTransformar(diaEspec�fico.AddDays(1)) +
                            (func.HasValue ? " AND funcionario = " + DbTransformar(func.Value) : " AND funcionario is null") +
                            " ORDER BY data";

                        return Mapear<Entidades.Agendamento>(cmd).ToArray();
                    }
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                }
            }
        }

		/// <summary>
		/// Obt�m agendamento a partir do c�digo.
		/// </summary>
		/// <param name="c�digo">C�digo do agendamento.</param>
		/// <returns>Agendamento.</returns>
		public static Agendamento ObterAgendamento(int c�digo)
		{
			return Mapear�nicaLinha<Agendamento>(
				@"SELECT * FROM agendamento WHERE codigo = " + DbTransformar(c�digo));
		}
		
		/// <summary>
		/// Obt�m o pr�ximo agendamento a despertar, pode ser nulo.
		/// </summary>
		public static Entidades.Agendamento ObterPr�ximo() 
		{
			Agendamento pr�ximoAgendamento = new Entidades.Agendamento();
            ulong? func = ObterFuncion�rioAtual();
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
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
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                        using (leitor = cmd.ExecuteReader())
                        {

                            if (leitor.Read() == false)
                                return null;

                            pr�ximoAgendamento.C�digo = (int)leitor[0];
                            pr�ximoAgendamento.DefinirCadastrado();
                            pr�ximoAgendamento.DefinirAtualizado();

                            try
                            {
                                pr�ximoAgendamento.Descri��o = leitor.GetString(1);
                            }
                            catch
                            {
                                pr�ximoAgendamento.Descri��o = "";
                            }

                            pr�ximoAgendamento.Data = leitor.GetDateTime(2);

                            try
                            {
                                pr�ximoAgendamento.Alarme = leitor.GetDateTime(3);
                            }
                            catch
                            {
                                pr�ximoAgendamento.Alarme = new DateTime(1);
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null && !leitor.IsClosed)
                            leitor.Close();

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);

                    }
                }
			
			return pr�ximoAgendamento;
		}

		/// <summary>
		/// Desliga despertador.
		/// </summary>
		public void DesligarDespertador()
		{
			IDbConnection conex�o;

			conex�o = Conex�o;

			using (IDbCommand cmd = conex�o.CreateCommand())
			{
				cmd.CommandText =
					"UPDATE agendamento SET alarme = NULL WHERE codigo = " +
					DbTransformar(this.codigo);

				try
				{
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

					lock (conex�o)
						if (cmd.ExecuteNonQuery() != 1)
							throw new Exception("N�o foi poss�vel desligar o despertador para o agendamento.");
				}
				catch (Exception e)
				{
					throw new Exception(e.ToString());
                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);

                }
			}
		}

        /// <summary>
        /// Obt�m agendamentos despertados.
        /// </summary>
        /// <returns>Lista de agendamentos despertados.</returns>
        public static IList<Agendamento> ObterAgendamentosDespertados()
        {
            IDbConnection conex�o;
            List<Agendamento> agendamentos;
            ulong? func = ObterFuncion�rioAtual();

            agendamentos = new List<Agendamento>();

            conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    IDataReader leitor = null;

                    cmd.CommandText =
                        @"SELECT codigo,descricao,data,alarme FROM agendamento WHERE" +
                        " alarme < NOW()" +
                        (func.HasValue ? " AND funcionario = " + DbTransformar(func.Value) : " AND funcionario is null") +
                        " ORDER BY alarme";

                    try
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);


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

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }

            return agendamentos;
        }
    }
}
