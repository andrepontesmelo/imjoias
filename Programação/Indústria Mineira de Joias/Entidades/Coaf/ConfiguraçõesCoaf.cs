using System;
using Entidades.Configuração;

namespace Entidades.Coaf
{
    public class ConfiguraçõesCoaf
    {
        public static readonly int PADRÃO_QTD_MESES = 6;
        public static readonly decimal PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP = 10000;
        public static readonly decimal PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS = 30000;
        public static readonly decimal PADRÃO_LIMIAR_CONFERÊNCIA_PEP = 5000;
        public static readonly decimal PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS = 15000;
        public static readonly DateTime PADRÃO_DATA_INÍCIO = new DateTime(2000, 1, 1);
        public static readonly DateTime PADRÃO_DATA_FIM = new DateTime(2100, 1, 1);

        private ConfiguraçãoGlobal<int> qtdMeses;
        private ConfiguraçãoGlobal<decimal> limiarNotificaçãoPessoaExpostaPoliticamente;
        private ConfiguraçãoGlobal<decimal> limiarNotificaçãoDemaisPessoas;
        private ConfiguraçãoGlobal<decimal> limiarVerificaçãoPessoaExpostaPoliticamente;
        private ConfiguraçãoGlobal<decimal> limiarVerificaçãoDemaisPessoas;
        private ConfiguraçãoGlobal<DateTime> dataInício;
        private ConfiguraçãoGlobal<DateTime> dataFim;

        public ConfiguraçãoGlobal<int> QtdMeses => qtdMeses;
        public ConfiguraçãoGlobal<decimal> LimiarNotificaçãoPessoaExpostaPoliticamente => limiarNotificaçãoPessoaExpostaPoliticamente;
        public ConfiguraçãoGlobal<decimal> LimiarNotificaçãoDemaisPessoas => limiarNotificaçãoDemaisPessoas;
        public ConfiguraçãoGlobal<decimal> LimiarVerificaçãoPessoaExpostaPoliticamente => limiarVerificaçãoPessoaExpostaPoliticamente;
        public ConfiguraçãoGlobal<decimal> LimiarVerificaçãoDemaisPessoas => limiarVerificaçãoDemaisPessoas;
        public ConfiguraçãoGlobal<DateTime> DataFim => dataFim;
        public ConfiguraçãoGlobal<DateTime> DataInício => dataInício;

        private static ConfiguraçõesCoaf instância;

        private ConfiguraçõesCoaf()
        {
            qtdMeses = new ConfiguraçãoGlobal<int>("coaf_qtdMeses", PADRÃO_QTD_MESES);
            limiarNotificaçãoDemaisPessoas = new ConfiguraçãoGlobal<decimal>("coaf_limiar_notificação_demais_pessoas", PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS);
            limiarNotificaçãoPessoaExpostaPoliticamente = new ConfiguraçãoGlobal<decimal>("coaf_limiar_notificação_pep", PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP);
            limiarVerificaçãoDemaisPessoas = new ConfiguraçãoGlobal<decimal>("coaf_limiar_conferência_demais_pessoas", PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS);
            limiarVerificaçãoPessoaExpostaPoliticamente= new ConfiguraçãoGlobal<decimal>("coaf_limiar_conferência_pep", PADRÃO_LIMIAR_CONFERÊNCIA_PEP);
            dataFim = new ConfiguraçãoGlobal<DateTime>("coaf_data_fim", PADRÃO_DATA_FIM);
            dataInício = new ConfiguraçãoGlobal<DateTime>("coaf_data_início", PADRÃO_DATA_INÍCIO);
        }

        public static ConfiguraçõesCoaf Instância
        {
            get
            {
                if (instância == null)
                    instância = new ConfiguraçõesCoaf();

                return instância;
            }
        }

        public decimal ValorMínimoLimiar => Math.Min(ValorMínimoVerificação, ValorMínimoNotificação);
        private decimal ValorMínimoVerificação => Math.Min(LimiarVerificaçãoDemaisPessoas.Valor, LimiarVerificaçãoPessoaExpostaPoliticamente.Valor);
        private decimal ValorMínimoNotificação => Math.Min(LimiarNotificaçãoDemaisPessoas.Valor, LimiarNotificaçãoPessoaExpostaPoliticamente.Valor);

        public void RestaurarPadrão()
        {
            qtdMeses.Valor = PADRÃO_QTD_MESES;
            limiarNotificaçãoPessoaExpostaPoliticamente.Valor = PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP;
            limiarNotificaçãoDemaisPessoas.Valor = PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS;
            limiarVerificaçãoPessoaExpostaPoliticamente.Valor = PADRÃO_LIMIAR_CONFERÊNCIA_PEP;
            limiarVerificaçãoDemaisPessoas.Valor = PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS;
            dataInício.Valor = PADRÃO_DATA_INÍCIO;
            dataFim.Valor = PADRÃO_DATA_FIM;
        }
    }
}
