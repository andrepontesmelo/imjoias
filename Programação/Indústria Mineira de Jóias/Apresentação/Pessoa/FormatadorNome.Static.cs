using System.Collections.Generic;
using Entidades.Configuração;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System;
namespace Apresentação.Pessoa
{
    partial class FormatadorNome
    {
        /// <summary>
        /// Constantes carregadas quando nenhuma configuração
        /// for encontrada no banco de dados.
        /// </summary>
        private const string padrãoConstantes = "e=e;de=de;do=do;da=da;dos=dos;das=das";

        /// <summary>
        /// Chave de configuração.
        /// </summary>
        private const string cfgChave = "FormatadorNome: constantes";

        /// <summary>
        /// Tabela hash com palavras que devem ser desconsideradas.
        /// </summary>
        private static Dictionary<string, string> constantes = null;

        /// <summary>
        /// Carrega as constantes.
        /// </summary>
        public static void CarregarConstantes()
        {
            ConfiguraçãoGlobal<string> cfgConstantes;
            string[] tuplas;
            Regex regex;
            Match m;

            cfgConstantes = new Entidades.Configuração.ConfiguraçãoGlobal<string>(
                cfgChave, padrãoConstantes);

            tuplas = cfgConstantes.Valor.Split(';', ',');

            constantes = new Dictionary<string, string>(tuplas.Length + tuplas.Length / 3, StringComparer.Ordinal);

            regex = new Regex(@"((\s*)(?<chave>\w+)(\s*)=(\s*)(?<valor>\w+)(\s*))+");
            m = regex.Match(cfgConstantes.Valor + ";");

            //foreach (string tupla in tuplas)
            while (m.Success)
            {
//                m = regex.Match(tupla + ";");
                constantes[m.Groups["chave"].Value] = m.Groups["valor"].Value;
                m = m.NextMatch();
            }
        }

        /// <summary>
        /// Mostra mensagem.
        /// </summary>
        private static void MostrarMensagem(TextBoxBase txt, string título, string mensagem)
        {
            Balloon.NET.BalloonHelp balão = new Balloon.NET.BalloonHelp();
            balão.Caption = título;
            balão.Icon = SystemIcons.Exclamation;
            balão.CloseOnDeactivate = false;
            balão.CloseOnKeyPress = false;
            balão.Content = mensagem;

            try
            {
                balão.ShowBalloon(txt);
                txt.Focus();
            }
            catch
            { }
        }
    }
}
