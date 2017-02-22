using System;
using Entidades.Configuração;

namespace Entidades.Coaf
{
    public class ConfiguraçõesCoaf
    {
        private static readonly int PADRÃO_QTD_MESES = 6;
        private static readonly decimal PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP = 10000;
        private static readonly int PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS = 30000;
        private static readonly decimal PADRÃO_LIMIAR_CONFERÊNCIA_PEP = 5000;
        private static readonly int PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS = 15000;

        private ConfiguraçãoGlobal<int> qtdMeses;
        private ConfiguraçãoGlobal<decimal> limiarNotificaçãoPessoaExpostaPoliticamente;
        private ConfiguraçãoGlobal<decimal> limiarNotificaçãoDemaisPessoas;
        private ConfiguraçãoGlobal<decimal> limiarConferênciaPessoaExpostaPoliticamente;
        private ConfiguraçãoGlobal<decimal> limiarConferênciaDemaisPessoas;

        public ConfiguraçãoGlobal<int> QtdMeses => qtdMeses;
        public ConfiguraçãoGlobal<decimal> LimiarNotificaçãoPessoaExpostaPoliticamente => limiarNotificaçãoPessoaExpostaPoliticamente;
        public ConfiguraçãoGlobal<decimal> LimiarNotificaçãoDemaisPessoas => limiarNotificaçãoDemaisPessoas;
        public ConfiguraçãoGlobal<decimal> LimiarConferênciaPessoaExpostaPoliticamente => limiarConferênciaPessoaExpostaPoliticamente;
        public ConfiguraçãoGlobal<decimal> LimiarConferênciaDemaisPessoas => limiarConferênciaDemaisPessoas;

        private static ConfiguraçõesCoaf instância;

        private ConfiguraçõesCoaf()
        {
            qtdMeses = new ConfiguraçãoGlobal<int>("coaf_qtdMeses", PADRÃO_QTD_MESES);
            limiarNotificaçãoDemaisPessoas = new ConfiguraçãoGlobal<decimal>("coaf_limiar_notificação_demais_pessoas", PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS);
            limiarNotificaçãoPessoaExpostaPoliticamente = new ConfiguraçãoGlobal<decimal>("coaf_limiar_notificação_pep", PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP);
            limiarConferênciaDemaisPessoas = new ConfiguraçãoGlobal<decimal>("coaf_limiar_conferência_demais_pessoas", PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS);
            limiarConferênciaPessoaExpostaPoliticamente= new ConfiguraçãoGlobal<decimal>("coaf_limiar_conferência_pep", PADRÃO_LIMIAR_CONFERÊNCIA_PEP);

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

        public void RestaurarPadrão()
        {
            qtdMeses.Valor = PADRÃO_QTD_MESES;
            limiarNotificaçãoPessoaExpostaPoliticamente.Valor = PADRÃO_LIMIAR_NOTIFICAÇÂO_PEP;
            limiarNotificaçãoDemaisPessoas.Valor = PADRÃO_LIMIAR_NOTIFICAÇÂO_DEMAIS;
            limiarConferênciaPessoaExpostaPoliticamente.Valor = PADRÃO_LIMIAR_CONFERÊNCIA_PEP;
            limiarConferênciaDemaisPessoas.Valor = PADRÃO_LIMIAR_CONFERÊNCIA_DEMAIS;
        }
    }
}
