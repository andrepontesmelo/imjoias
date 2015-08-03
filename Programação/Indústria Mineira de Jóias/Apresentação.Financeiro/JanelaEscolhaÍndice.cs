using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Financeiro
{
    public partial class JanelaEscolhaÍndice : JanelaExplicativa
    {
        List<RadioButton> radios = new List<RadioButton>();

        public JanelaEscolhaÍndice()
        {
            InitializeComponent();
        }

        public void CarregarÍndices(List<double> indices)
        {
            bool primeiro = true;

            foreach (double d in indices)
            {
                RadioButton radio = new RadioButton();
                radio.Font = new Font(Font.FontFamily, 14, FontStyle.Regular);

                radio.Checked = primeiro;

                radio.Text = d.ToString();
                radio.Tag = d;
                flow.Controls.Add(radio);

                if (primeiro)
                    primeiro = false;
                
                radios.Add(radio);
            }
        }

        public Double ObterValorEscolhido()
        {
            foreach (RadioButton r in radios)
            {
                if (r.Checked == true)
                    return (double)r.Tag;
            }

            throw new Exception("Nenhum valor selecionado");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void JanelaEscolhaÍndice_Load(object sender, EventArgs e)
        {
            Apresentação.Útil.Beepador.Alerta();
        }
    }
}