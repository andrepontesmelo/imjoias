using Entidades.Configuração;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Venda.Semáforo
{
    public class ConfiguraçãoMarcaçãoSemáforo
    {
        private static readonly string PREFIXO_CONFIGURAÇÃO = "semáforo_";

        private CheckBox[] checkBox;

        public ConfiguraçãoMarcaçãoSemáforo()
        {
        }

        public ConfiguraçãoMarcaçãoSemáforo(CheckBox[] checkBox)
        {
            this.checkBox = checkBox;

            foreach (CheckBox controle in checkBox)
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
            foreach (CheckBox controle in checkBox)
                controle.Checked = ObterConfiguração(controle).Valor;
        }

        private ConfiguraçãoUsuário<bool> ObterConfiguração(CheckBox controle)
        {
            return new ConfiguraçãoUsuário<bool>(PREFIXO_CONFIGURAÇÃO + controle.Name, true);
        }
    }
}
