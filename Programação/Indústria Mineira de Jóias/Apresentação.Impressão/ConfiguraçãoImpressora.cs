using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Configuração;

namespace Apresentação.Impressão
{
    /// <summary>
    /// Reúne configurações da impressora.
    /// </summary>
    public class ConfiguraçãoImpressora
    {
        private string nome;
        private ConfiguraçãoGlobal<bool> compartilhar;
//        private ConfiguraçãoGlobal<bool> relatórios;
        private Dictionary<string, ConfiguraçãoGlobal<bool>> hashTipoDocumento = new Dictionary<string,ConfiguraçãoGlobal<bool>>();

        public ConfiguraçãoImpressora(string nome)
        {
            this.nome = nome;

            compartilhar = new ConfiguraçãoGlobal<bool>(
                    ObterChave("Compartilhar"),
                    true);
        }

        private string ObterChave(string chave)
        {
            return String.Format(
                    "Impressora \"{0}:{1}\" - {2}",
                    System.Environment.MachineName,
                    nome, chave);
        }

        public string Nome
        {
            get { return nome; }
        }

        public ConfiguraçãoGlobal<bool> Compartilhar
        {
            get
            {
                return compartilhar;
            }
        }

        public ConfiguraçãoGlobal<bool> Suporta(TipoDocumento tipo)
        {
            ConfiguraçãoGlobal<bool> suporte;
            string chave = ObterChave(Enum.GetName(typeof(TipoDocumento), tipo));

            if (!hashTipoDocumento.TryGetValue(chave, out suporte))
            {
                suporte = new ConfiguraçãoGlobal<bool>(chave, true);
                hashTipoDocumento[chave] = suporte;
            }

            return suporte;
        }
    }
}
