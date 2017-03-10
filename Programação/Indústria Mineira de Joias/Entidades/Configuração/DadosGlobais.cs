using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using System.ComponentModel;

namespace Entidades.Configura��o
{
    /// <summary>
    /// Singleton que define informa��es globais para o programa.
    /// Tais informa��es n�o necessariamente est�o no banco de dados
    /// </summary>
    public class DadosGlobais : DbManipula��o
    {
        /// <summary>
        /// Cultura brasileira.
        /// </summary>
        private System.Globalization.CultureInfo cultura;

        private Configura��oGlobal<string> servidorNTP;
        private Configura��oGlobal<string> �ltimaVers�o;
        private Configura��oGlobal<DateTime> �ltimoLogInUsu�rio;

        /// <summary>
        /// Juros cobrado ao dia nas vendas da empresa.
        /// </summary>
        private Configura��oGlobal<double> juros;

        /// <summary>
        /// Intervalo em milissegundos para verifica��o de agendamento
        /// no banco de dados.
        /// </summary>
        private Configura��oGlobal<int> agendamentoIntervalo;

        private Configura��oGlobal<int> cacheExpira��oVendaPdfMs;

        /// <summary>
        /// Intervalo em milissegundos para verifica��o de dados
        /// por parte do temporizador do controle do usu�rio.
        /// </summary>
        private Configura��oGlobal<int> controleUsu�rioIntervalo;

        /// <summary>
        /// Intervalo em milissegundos para verifica��o de dados
        /// por parte do temporizador do controle do usu�rio.
        /// </summary>
        private Configura��oGlobal<uint> tabelaPadr�o;

        /// <summary>
        /// Prazo em dias que o sistema d� automaticamente a
        /// um consignado.
        /// </summary>
        private Configura��oGlobal<uint> prazoConsignadoPadr�o;

        /// <summary>
        /// Prazo m�ximo em dias que o sistema permite para um
        /// consignado.
        /// </summary>
        private Configura��oGlobal<uint> prazoConsignadoM�ximo;

        private Configura��oGlobal<string> parcelamento;

        private Configura��oGlobal<string> cnpjEmpresa;

        #region Singleton
        private static DadosGlobais inst�ncia = null;

        public static DadosGlobais Inst�ncia
        {
            get
            {
                if (inst�ncia == null)
                    inst�ncia = new DadosGlobais();

                return inst�ncia;
            }
        }
        #endregion

        public static bool ModoDesenho
        {
            get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }
        /// <summary>
        /// Constr�i o objeto de configura��o, introduzindo
        /// a configura��o padr�o.
        /// </summary>
        private DadosGlobais()
        {
            if (ModoDesenho || !Conectado)
                return;

            cultura = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR");
            juros = new Configura��oGlobal<double>("Juros ao m�s", 2.8);
            agendamentoIntervalo = new Configura��oGlobal<int>("Intervalo de verifica��o da agenda", 120000);
            controleUsu�rioIntervalo = new Configura��oGlobal<int>("Intervalo para controle de usu�rio", 60000);
            tabelaPadr�o = new Configura��oGlobal<uint>("Tabela Padr�o", 3);
            prazoConsignadoPadr�o = new Configura��oGlobal<uint>("Prazo consignado padr�o", 7);
            prazoConsignadoM�ximo = new Configura��oGlobal<uint>("Prazo consignado m�ximo", 25);
            parcelamento = new Configura��oGlobal<string>("Parcelamento", "0;30;30x60;30x60x90;30x60x90x120");
            cnpjEmpresa = new Configura��oGlobal<string>("CNPJ", "18219329000103");
            try
            {
                �ltimaVers�o = new Configura��oGlobal<string>("Vers�o." + System.Reflection.Assembly.GetEntryAssembly().FullName.Split(',')[0], "0.0.0.0");
                �ltimoLogInUsu�rio = new Configura��oGlobal<DateTime>("�ltimo login." + System.Reflection.Assembly.GetEntryAssembly().FullName.Split(',')[0] + "." + Usu�rios.Usu�rioAtual.Nome, DateTime.Now);
            }
            finally
            {
            }
            servidorNTP = new Configura��oGlobal<string>("Servidor NTP", "pool.ntp.org");
            cacheExpira��oVendaPdfMs = new Configura��oGlobal<int>("Expira��o de cache para reobten��o v�nculo entre vendas e pdfs de NFes", (int) TimeSpan.FromMinutes(5).TotalMilliseconds);
        }

        #region Propriedades

        public DateTime �ltimoLogInUsu�rio
        {
            get { return �ltimoLogInUsu�rio.Valor; }
            set
            {
                �ltimoLogInUsu�rio.Valor = value;
            }
        }

        public string ServidorNTP
        {
            get
            {
                return servidorNTP.Valor;
            }
        }

        public string ChaveConfigura��oSetorVisitantes { get { return "Setor de Monitora��o de Visitantes"; } }

        public System.Globalization.CultureInfo Cultura
        {
            get { return cultura; }
        }

        /// <summary>
        /// Juros ao dia.
        /// </summary>
        public double Juros
        {
            get { return juros; }
            set
            {
                juros.Valor = value;
            }
        }

        
        private DateTime �ltimaSincroniza��o = DateTime.MinValue;
        private TimeSpan difHora;

        /// <summary>
        /// Faz uma consuta no BD pela data do servidor.
        /// </summary>
        public DateTime HoraDataAtual
        {
            get
            {
                if (ModoDesenho)
                    return DateTime.Now;

                DateTime hora;

                if (((TimeSpan)(DateTime.Now - �ltimaSincroniza��o)).Minutes > 15)
                {
                    IDbConnection conex�o = Conex�o;

                    lock (conex�o)
                        using (IDbCommand cmd = conex�o.CreateCommand())
                        {
                            cmd.CommandText = "SELECT NOW()";

                            hora = Convert.ToDateTime(cmd.ExecuteScalar());
                        }

                    difHora = hora - DateTime.Now;
                    �ltimaSincroniza��o = DateTime.Now;
                }
                else
                    hora = TruncarMilesimosSegundos(DateTime.Now.Add(difHora));

                return hora;
            }
        }

        private DateTime TruncarMilesimosSegundos(DateTime dateTime)
        {
            return new DateTime(dateTime.Ticks - (dateTime.Ticks % TimeSpan.TicksPerSecond), dateTime.Kind);
        }

        /// <summary>
        /// Intervalo do agendamento em milissegundos.
        /// </summary>
        public int AgendamentoIntervalo
        {
            get { return agendamentoIntervalo; }
            set
            {
                agendamentoIntervalo.Valor = value;
            }
        }

        public int CacheExpira��oVendaPdfMs => cacheExpira��oVendaPdfMs;

        /// <summary>
        /// Intervalo em milissegundos para verifica��o de dados
        /// por parte do temporizador do controle do usu�rio.
        /// </summary>
        public int ControleUsu�rioIntervalo
        {
            get { return controleUsu�rioIntervalo.Valor; }
            set { controleUsu�rioIntervalo.Valor = value; }
        }

        public uint TabelaPadr�o
        {
            get { return tabelaPadr�o.Valor; }
            set { tabelaPadr�o.Valor = value; }
        }

        /// <summary>
        /// Prazo em dias que o sistema d� automaticamente a
        /// um consignado.
        /// </summary>
        public uint PrazoConsignadoPadr�o
        {
            get { return prazoConsignadoPadr�o.Valor; }
            set { prazoConsignadoPadr�o.Valor = value; }
        }

        /// <summary>
        /// Prazo m�ximo em dias que o sistema permite para um
        /// consignado.
        /// </summary>
        public uint PrazoConsignadoM�ximo
        {
            get { return prazoConsignadoM�ximo.Valor; }
            set { prazoConsignadoM�ximo.Valor = value; }
        }

        /// <summary>
        /// Parcelamentos padronizados.
        /// </summary>
        public string[] Parcelamento
        {
            get { return parcelamento.Valor.Split(';'); }
            set
            {
                string valor = "";

                foreach (string str in value)
                    if (valor.Length > 0)
                        valor += ";" + str;
                    else
                        valor = str;

                parcelamento.Valor = valor;
            }
        }

        public string CNPJEmpresa => cnpjEmpresa.Valor;

        public bool Conectado => Usu�rios.Usu�rioAtual != null;

        #endregion

        #region Manipula��o n�o suportada

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            throw new NotSupportedException();
        }

        protected override void Atualizar(System.Data.IDbCommand cmd)
        {
            throw new NotSupportedException();
        }

        protected override void Descadastrar(System.Data.IDbCommand cmd)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
