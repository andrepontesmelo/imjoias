using System;
using Entidades.Configuração;

namespace Entidades.Coaf
{
    public class ConfiguraçõesCoaf
    {
        private static readonly int PADRÃO_QTD_MESES = 6;
        private static readonly decimal PADRÃO_MÍNIMO_ACUMULADO_PEP = 10000;
        private static readonly int PADRÃO_MÍNIMO_ACUMULADO_DEMAIS = 30000;
        private static readonly bool PADRÃO_EXIBIR_OPERAÇÕES_NÃO_NOTIFICÁVEIS;

        private ConfiguraçãoGlobal<int> qtdMeses;
        private ConfiguraçãoGlobal<decimal> valorMínimoAcumuladoPessoaExpostaPoliticamente;
        private ConfiguraçãoGlobal<decimal> valorMínimoAcumuladoDemaisPessoas;
        private ConfiguraçãoGlobal<bool> exibirOperaçõesNãoNotificáveis;

        public ConfiguraçãoGlobal<int> QtdMeses => qtdMeses;
        public ConfiguraçãoGlobal<decimal> ValorMínimoAcumuladoPessoaExpostaPoliticamente => valorMínimoAcumuladoPessoaExpostaPoliticamente;
        public ConfiguraçãoGlobal<decimal> ValorMínimoAcumuladoDemaisPessoas => valorMínimoAcumuladoDemaisPessoas;
        public ConfiguraçãoGlobal<bool> ExibirOperaçõesNãoNotificáveis => exibirOperaçõesNãoNotificáveis;

        private static ConfiguraçõesCoaf instância;

        private ConfiguraçõesCoaf()
        {
            qtdMeses = new ConfiguraçãoGlobal<int>("coaf_qtdMeses", PADRÃO_QTD_MESES);
            valorMínimoAcumuladoDemaisPessoas = new ConfiguraçãoGlobal<decimal>("coaf_valor_mínimo_demais_pessoas", PADRÃO_MÍNIMO_ACUMULADO_DEMAIS);
            valorMínimoAcumuladoPessoaExpostaPoliticamente = new ConfiguraçãoGlobal<decimal>("coaf_valor_mínimo_pep", PADRÃO_MÍNIMO_ACUMULADO_PEP);
            exibirOperaçõesNãoNotificáveis = new ConfiguraçãoGlobal<bool>("coaf_exibir_operações_não_notificáveis", PADRÃO_EXIBIR_OPERAÇÕES_NÃO_NOTIFICÁVEIS);
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
            ValorMínimoAcumuladoPessoaExpostaPoliticamente.Valor = PADRÃO_MÍNIMO_ACUMULADO_PEP;
            valorMínimoAcumuladoDemaisPessoas.Valor = PADRÃO_MÍNIMO_ACUMULADO_DEMAIS;
            exibirOperaçõesNãoNotificáveis.Valor = PADRÃO_EXIBIR_OPERAÇÕES_NÃO_NOTIFICÁVEIS;
        }
    }
}
