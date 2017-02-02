using Entidades.Configuração;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using System;

namespace Apresentação.Financeiro.Venda.Semáforo
{
    public class ConfiguraçãoMarcaçãoSemáforo
    {
        private static readonly string PREFIXO_CONFIGURAÇÃO = "semáforo_";

        private CheckBox[] checkBoxes;

        public ConfiguraçãoMarcaçãoSemáforo()
        {
        }

        public ConfiguraçãoMarcaçãoSemáforo(CheckBox[] checkBoxes)
        {
            this.checkBoxes = checkBoxes;

            foreach (CheckBox controle in checkBoxes)
            {
                controle.CheckedChanged += Controle_CheckedChanged;
                controle.Checked = ObterConfiguração(controle).Valor;
            }
        }

        private void Controle_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox controle = sender as CheckBox;
            var configuração = ObterConfiguração(controle);

            configuração.Valor = controle.Checked;
        }

        private void CarregarMarcações()
        {
            foreach (CheckBox controle in checkBoxes)
                controle.Checked = ObterConfiguração(controle).Valor;
        }

        private ConfiguraçãoUsuário<bool> ObterConfiguração(CheckBox controle)
        {
            return new ConfiguraçãoUsuário<bool>(PREFIXO_CONFIGURAÇÃO + controle.Name, true);
        }

        internal bool DeveExibir(SemaforoEnum semáforo)
        {
            return checkBoxes[(int)semáforo].Checked;
        }
    }
}
