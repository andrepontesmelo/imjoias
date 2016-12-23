using Apresentação.Formulários;
using Entidades.Configuração;
using System;
using System.Windows.Forms;

namespace Apresentação.Administrativo.Fiscal.Janela
{
    public partial class JanelaPáginaInicial : JanelaExplicativa
    {
        private ConfiguraçãoGlobal<int> últimaPágina;

        public JanelaPáginaInicial()
        {
            InitializeComponent();
            últimaPágina = new ConfiguraçãoGlobal<int>("últimaPágina", 464);

            txtPrimeiraFolha.Int = últimaPágina.Valor;
        }

        public int PrimeiraPágina => txtPrimeiraFolha.Int;

        private void btnOk_Click(object sender, EventArgs e)
        {
            últimaPágina.Valor = txtPrimeiraFolha.Int;
            DialogResult = DialogResult.OK;
        }
    }
}
