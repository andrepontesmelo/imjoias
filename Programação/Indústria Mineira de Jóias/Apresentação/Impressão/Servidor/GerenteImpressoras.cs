using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using Entidades.Configuração;

namespace Apresentação.Impressão.Servidor
{
    /// <summary>
    /// Responsável pela coordenação das impressoras que a máquina
    /// local é capaz de imprimir.
    /// </summary>
    class GerenteImpressoras : IEnumerable<GerenteImpressoras.InfoImpressora>
    {
        private Dictionary<string, InfoImpressora> impressoras = new Dictionary<string, InfoImpressora>(StringComparer.Ordinal);

        /// <summary>
        /// Estrutura com informações da impressora.
        /// </summary>
        public struct InfoImpressora
        {
            private ConfiguraçãoImpressora cfg;
            private bool colorido;

            public InfoImpressora(string nome, ConfiguraçãoImpressora cfg)
            {
                this.cfg = cfg;
                PrinterSettings cfgImpressora = new PrinterSettings();
                cfgImpressora.PrinterName = nome;

                // Demora muito para impressoras remotas!
                //colorido = cfgImpressora.SupportsColor;

                colorido = true;
            }

            public ConfiguraçãoImpressora Configuração { get { return cfg; } }
            public bool Colorido { get { return colorido; } }
        }


        /// <summary>
        /// Constrói o gerente, coletando informações de impressoras.
        /// </summary>
        public GerenteImpressoras()
        {
            try
            {
                foreach (string nome in PrinterSettings.InstalledPrinters)
                {
                    try
                    {
                        Preparar(nome);
                    }
                    //catch (Exception e)
                    //{
                    //    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(new Exception("Máquina " + Environment.MachineName + " não consegue preparar impressora " + nome + ".", e));
                    //}
                    catch { }
                }
            }
            //catch (Exception e)
            //{
            //    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(new Exception("Máquina " + Environment.MachineName + " não consegue preparar impressoras.", e));

            //    throw new Exception("Erro preparando impressoras.", e);
            //}
            catch { }
        }

        /// <summary>
        /// Consulta a impressora.
        /// </summary>
        private void Preparar(string nome)
        {
            ConfiguraçãoImpressora cfgGeral;

            cfgGeral = new ConfiguraçãoImpressora(nome);

            impressoras[nome] = new InfoImpressora(nome, cfgGeral);
        }

        #region IEnumerable<InfoImpressora> Members

        public IEnumerator<GerenteImpressoras.InfoImpressora> GetEnumerator()
        {
            return impressoras.Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return impressoras.Values.GetEnumerator();
        }

        #endregion
    }
}
