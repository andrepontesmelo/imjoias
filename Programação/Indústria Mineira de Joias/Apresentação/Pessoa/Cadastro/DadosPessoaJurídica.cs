using Entidades.Pessoa;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class DadosPessoaJurídica : UserControl
    {
        private PessoaJurídica pessoa;

        public DadosPessoaJurídica()
        {
            InitializeComponent();
        }

        [Browsable(false), ReadOnly(true)]
        public PessoaJurídica Pessoa
        {
            get { return pessoa; }
            set
            {
                pessoa = value;
                
                txtNome.Text = value.Nome != null ? value.Nome : "";
                txtFantasia.Text = value.Fantasia != null ? value.Fantasia : "";
                txtCNPJ.Text = value.CNPJ != null ? value.CNPJ : "";
                txtInscEstadual.Text = value.InscEstadual != null ? value.InscEstadual : "";
                txtInscMunicipal.Text = value.InscMunicipal != null ? value.InscMunicipal : "";
                CarregarDadosPreposto();
                
                if (pessoa.Cadastrado)
                {
                    this.txtCódigo.Text = pessoa.Código.ToString();
                    this.cmbNumeraçãoAutomática.Enabled = false;
                }
                else
                {
                    txtCódigo.Text = "";
                    cmbNumeraçãoAutomática.Enabled = true;
                }

                this.txtCódigo.Enabled = false;
            }
        }

        private static string ExtrairString(TextBox controle)
        {
            string str = controle.Text.Trim();

            if (str.Length > 0)
                return str;
            else
                return null;
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            pessoa.Nome = ExtrairString(txtNome);
        }

        private void txtFantasia_Validated(object sender, EventArgs e)
        {
            pessoa.Fantasia = ExtrairString(txtFantasia);
        }

        private void txtCNPJ_Validated(object sender, EventArgs e)
        {
            try
            {
                pessoa.CNPJ = txtCNPJ.Text.Length > 0 ? txtCNPJ.Text : null;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Cadastro de Pessoa Jurídica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInscEstadual_Validated(object sender, EventArgs e)
        {
            pessoa.InscEstadual = ExtrairString(txtInscEstadual);
        }

        private void txtInscMunicipal_Validated(object sender, EventArgs e)
        {
            pessoa.InscMunicipal = ExtrairString(txtInscMunicipal);
        }

        private void txtCódigo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Entidades.Pessoa.Pessoa.CódigoNovaPessoaVálido((ulong) txtCódigo.Long);
        }

        private void txtCódigo_Validated(object sender, EventArgs e)
        {
            if (txtCódigo.Enabled)
                pessoa.Código = (ulong)txtCódigo.Long;
        }

        private void cmbNumeraçãoAutomática_CheckedChanged(object sender, EventArgs e)
        {
            txtCódigo.Enabled = !cmbNumeraçãoAutomática.Checked;
        }

        private void txtCNPJ_Validating(object sender, CancelEventArgs e)
        {
            PessoaJurídica p = null;

            if (txtCNPJ.Text.Length != 0)
            {
                p = PessoaJurídica.ObterPessoaPorCNPJ(txtCNPJ.Text);

                if (p != null && p.Código != pessoa.Código)
                {
                    e.Cancel = true;
                    MessageBox.Show("O CNPJ " + txtCNPJ.Text + " já está associado ao segunte cliente\n\nCódigo:" + 
                        p.Código.ToString() + "\nNome:" + (p.Nome != null ? p.Nome : ""), "CNPJ já cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtCPFPreposto_Validated(object sender, EventArgs e)
        {
            pessoa.CpfPreposto = txtCPFPreposto.TextoSemFormatação;
            CarregarDadosPreposto();
        }

        private void CarregarDadosPreposto()
        {
            CarregarDadosPreposto(PessoaFísica.ObterPessoaPorCPF(pessoa.CpfPreposto));
        }

        private void CarregarDadosPreposto(PessoaFísica preposto)
        {
            txtCPFPreposto.Text = pessoa.CpfPreposto != null ? pessoa.CpfPreposto : "";

            txtNomePreposto.Text = preposto != null ? preposto.Nome : "";
            txtCódigoPreposto.Text = preposto != null ? preposto.Código.ToString() : "";
            txtRG.Text = preposto != null ? preposto.DI : "";
            txtRGEmissor.Text = preposto != null ? preposto.DIEmissor : "";
            lnkAbrirCadastroPreposto.Enabled = preposto != null;
        }

        private void lnkAbrirCadastroPreposto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var preposto = PessoaFísica.ObterPessoaPorCPF(pessoa.CpfPreposto);

            if (preposto == null)
                return;

            Entidades.Pessoa.Pessoa pessoaAtualizada;

            if (CadastroPessoa.Abrir(preposto, this.Parent, out pessoaAtualizada) == DialogResult.OK)
            {
                PessoaFísica pessoaFísica = (PessoaFísica) pessoaAtualizada;

                if (pessoaFísica.CPF == null || !pessoaFísica.CPF.Equals(pessoa.CpfPreposto))
                    CarregarDadosPreposto();
                else
                    CarregarDadosPreposto(pessoaFísica);
            }
        }
    }
}
