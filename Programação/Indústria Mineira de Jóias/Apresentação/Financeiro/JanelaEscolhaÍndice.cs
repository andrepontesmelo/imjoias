using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Negócio;
using Entidades.Relacionamento;

namespace Apresentação.Financeiro
{
    public partial class JanelaEscolhaÍndice : JanelaExplicativa
    {
        private Entidades.Mercadoria.Mercadoria mercadoria;
        private Entidades.Relacionamento.RelacionamentoAcerto relacionamento;
        private double índiceVigente;
        List<RadioButton> radios = new List<RadioButton>();

        public JanelaEscolhaÍndice()
        {
            InitializeComponent();
            radios.Add(radioPersonalizado);
            txtÍndice.Focus();
        }

        public void CarregarÍndices(List<double> indices, double índiceVigente,
            Entidades.Mercadoria.Mercadoria mercadoria,
            Entidades.Relacionamento.RelacionamentoAcerto relacionamento
            )
        {
            this.índiceVigente = índiceVigente;
            this.mercadoria = mercadoria;
            this.relacionamento = relacionamento;

            RadioButton radioPadrão = null;

            bool primeiro = true;
            
            foreach (double d in indices)
            {
                RadioButton radio = new RadioButton();
                radio.CheckedChanged += new EventHandler(radio_CheckedChanged);
                radio.Font = new Font(Font.FontFamily, 14, FontStyle.Regular);

                radio.Checked = primeiro;

                radio.Text = d.ToString();
                if (d == índiceVigente)
                {
                    radio.Font = new Font(radio.Font, FontStyle.Bold);
                    radio.Checked = true;
                    radioPadrão = radio;
                }
                radio.Tag = d;
                flow.Controls.Add(radio);

                if (primeiro)
                    primeiro = false;
                
                radios.Add(radio);
            }

            //if (radioPadrão != null)
            //{
            //    radioPersonalizado.Checked = false;
            //    radioPadrão.Checked = true;
            //    btnOK.Focus();
            //}
        }

        void radio_CheckedChanged(object sender, EventArgs e)
        {
            txtÍndice.Enabled = radioPersonalizado.Enabled;
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
            Beepador.Alerta();
        }

        private void txtÍndice_Validated(object sender, EventArgs e)
        {
            radioPersonalizado.Tag = (double)txtÍndice.Double;
        }

        private void radioPersonalizado_Click(object sender, EventArgs e)
        {
            txtÍndice.Enabled = radioPersonalizado.Checked;
        }

        private void lnkEscolhaIndiceDetalhes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (relacionamento.AcertoConsignado == null)
                return;

            List<EscolhaÍndicesDetalhes> lst = 
                Entidades.Relacionamento.EscolhaÍndicesDetalhes.Obter(relacionamento.AcertoConsignado.Código,
                mercadoria);

            if (lst.Count == 0)
                return;

            StringBuilder mensagem = new StringBuilder("O índice vigente da empresa é ");
            mensagem.Append(índiceVigente);
            mensagem.Append(". No entanto, ");

            foreach (EscolhaÍndicesDetalhes escolha in lst)
            {
                mensagem.AppendLine();
                mensagem.Append(escolha.ToString());
            }

            MessageBox.Show(mensagem.ToString(),
                "Vários índices possíveis",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}