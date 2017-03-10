using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using System.ComponentModel;

namespace Entidades.Configuração
{
    /// <summary>
    /// Singleton que define informações globais para o programa.
    /// Tais informações não necessariamente estão no banco de dados
    /// </summary>
    public class DadosGlobais : DbManipulação
    {
        /// <summary>
        /// Cultura brasileira.
        /// </summary>
        private System.Globalization.CultureInfo cultura;

        private ConfiguraçãoGlobal<string> servidorNTP;
        private ConfiguraçãoGlobal<string> últimaVersão;
        private ConfiguraçãoGlobal<DateTime> últimoLogInUsuário;

        /// <summary>
        /// Juros cobrado ao dia nas vendas da empresa.
        /// </summary>
        private ConfiguraçãoGlobal<double> juros;

        /// <summary>
        /// Intervalo em milissegundos para verificação de agendamento
        /// no banco de dados.
        /// </summary>
        private ConfiguraçãoGlobal<int> agendamentoIntervalo;

        private ConfiguraçãoGlobal<int> cacheExpiraçãoVendaPdfMs;

        /// <summary>
        /// Intervalo em milissegundos para verificação de dados
        /// por parte do temporizador do controle do usuário.
        /// </summary>
        private ConfiguraçãoGlobal<int> controleUsuárioIntervalo;

        /// <summary>
        /// Intervalo em milissegundos para verificação de dados
        /// por parte do temporizador do controle do usuário.
        /// </summary>
        private ConfiguraçãoGlobal<uint> tabelaPadrão;

        /// <summary>
        /// Prazo em dias que o sistema dá automaticamente a
        /// um consignado.
        /// </summary>
        private ConfiguraçãoGlobal<uint> prazoConsignadoPadrão;

        /// <summary>
        /// Prazo máximo em dias que o sistema permite para um
        /// consignado.
        /// </summary>
        private ConfiguraçãoGlobal<uint> prazoConsignadoMáximo;

        private ConfiguraçãoGlobal<string> parcelamento;

        private ConfiguraçãoGlobal<string> cnpjEmpresa;

        #region Singleton
        private static DadosGlobais instância = null;

        public static DadosGlobais Instância
        {
            get
            {
                if (instância == null)
                    instância = new DadosGlobais();

                return instância;
            }
        }
        #endregion

        public static bool ModoDesenho
        {
            get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }
        /// <summary>
        /// Constrói o objeto de configuração, introduzindo
        /// a configuração padrão.
        /// </summary>
        private DadosGlobais()
        {
            if (ModoDesenho || !Conectado)
                return;

            cultura = System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR");
            juros = new ConfiguraçãoGlobal<double>("Juros ao mês", 2.8);
            agendamentoIntervalo = new ConfiguraçãoGlobal<int>("Intervalo de verificação da agenda", 120000);
            controleUsuárioIntervalo = new ConfiguraçãoGlobal<int>("Intervalo para controle de usuário", 60000);
            tabelaPadrão = new ConfiguraçãoGlobal<uint>("Tabela Padrão", 3);
            prazoConsignadoPadrão = new ConfiguraçãoGlobal<uint>("Prazo consignado padrão", 7);
            prazoConsignadoMáximo = new ConfiguraçãoGlobal<uint>("Prazo consignado máximo", 25);
            parcelamento = new ConfiguraçãoGlobal<string>("Parcelamento", "0;30;30x60;30x60x90;30x60x90x120");
            cnpjEmpresa = new ConfiguraçãoGlobal<string>("CNPJ", "18219329000103");
            try
            {
                últimaVersão = new ConfiguraçãoGlobal<string>("Versão." + System.Reflection.Assembly.GetEntryAssembly().FullName.Split(',')[0], "0.0.0.0");
                últimoLogInUsuário = new ConfiguraçãoGlobal<DateTime>("Último login." + System.Reflection.Assembly.GetEntryAssembly().FullName.Split(',')[0] + "." + Usuários.UsuárioAtual.Nome, DateTime.Now);
            }
            finally
            {
            }
            servidorNTP = new ConfiguraçãoGlobal<string>("Servidor NTP", "pool.ntp.org");
            cacheExpiraçãoVendaPdfMs = new ConfiguraçãoGlobal<int>("Expiração de cache para reobtenção vínculo entre vendas e pdfs de NFes", (int) TimeSpan.FromMinutes(5).TotalMilliseconds);
        }

        #region Propriedades

        public DateTime ÚltimoLogInUsuário
        {
            get { return últimoLogInUsuário.Valor; }
            set
            {
                últimoLogInUsuário.Valor = value;
            }
        }

        public string ServidorNTP
        {
            get
            {
                return servidorNTP.Valor;
            }
        }

        public string ChaveConfiguraçãoSetorVisitantes { get { return "Setor de Monitoração de Visitantes"; } }

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

        
        private DateTime últimaSincronização = DateTime.MinValue;
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

                if (((TimeSpan)(DateTime.Now - últimaSincronização)).Minutes > 15)
                {
                    IDbConnection conexão = Conexão;

                    lock (conexão)
                        using (IDbCommand cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = "SELECT NOW()";

                            hora = Convert.ToDateTime(cmd.ExecuteScalar());
                        }

                    difHora = hora - DateTime.Now;
                    últimaSincronização = DateTime.Now;
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

        public int CacheExpiraçãoVendaPdfMs => cacheExpiraçãoVendaPdfMs;

        /// <summary>
        /// Intervalo em milissegundos para verificação de dados
        /// por parte do temporizador do controle do usuário.
        /// </summary>
        public int ControleUsuárioIntervalo
        {
            get { return controleUsuárioIntervalo.Valor; }
            set { controleUsuárioIntervalo.Valor = value; }
        }

        public uint TabelaPadrão
        {
            get { return tabelaPadrão.Valor; }
            set { tabelaPadrão.Valor = value; }
        }

        /// <summary>
        /// Prazo em dias que o sistema dá automaticamente a
        /// um consignado.
        /// </summary>
        public uint PrazoConsignadoPadrão
        {
            get { return prazoConsignadoPadrão.Valor; }
            set { prazoConsignadoPadrão.Valor = value; }
        }

        /// <summary>
        /// Prazo máximo em dias que o sistema permite para um
        /// consignado.
        /// </summary>
        public uint PrazoConsignadoMáximo
        {
            get { return prazoConsignadoMáximo.Valor; }
            set { prazoConsignadoMáximo.Valor = value; }
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

        public bool Conectado => Usuários.UsuárioAtual != null;

        #endregion

        #region Manipulação não suportada

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
