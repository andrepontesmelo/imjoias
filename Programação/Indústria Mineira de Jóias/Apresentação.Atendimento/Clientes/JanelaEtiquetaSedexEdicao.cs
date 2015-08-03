using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Pessoa.Cadastro;
using Apresentação.Pessoa.Endereço;

namespace Apresentação.Atendimento.Clientes
{
    public partial class JanelaEtiquetaSedexEdicao : Apresentação.Formulários.JanelaExplicativa
    {
        private Entidades.EtiquetaSedex etiqueta;
        
        public JanelaEtiquetaSedexEdicao()
        {
            InitializeComponent();
        }

        public void Carregar(Entidades.EtiquetaSedex etiqueta)
        {
            this.etiqueta = etiqueta;

            txtQuantidade.Value = (decimal)etiqueta.Quantidade;
            txtEndereço.Text = etiqueta.Endereço.ToString();

            optDestinatario.Checked = etiqueta.Tipo == Entidades.EtiquetaSedex.TipoEndereco.Destinatário;
            optRemetente.Checked = !optDestinatario.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            etiqueta.Quantidade = (int) txtQuantidade.Value;
            if (optDestinatario.Checked)
                etiqueta.Tipo = Entidades.EtiquetaSedex.TipoEndereco.Destinatário;
            else
                etiqueta.Tipo = Entidades.EtiquetaSedex.TipoEndereco.Remetente;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void lnkAlterar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (etiqueta.Pessoa.Endereços.ContarElementos() > 0)
            {
                EscolhaEndereço janela;

                using (janela = new EscolhaEndereço(etiqueta.Pessoa.Endereços.ExtrairElementos()))
                {
                    if (janela.ShowDialog(ParentForm) == DialogResult.OK)
                    {
                        etiqueta.Endereço = janela.Endereço;
                        txtEndereço.Text = etiqueta.Endereço.ToString();
                    }
                    else
                        return;
                }
            }
        }
    }
}
