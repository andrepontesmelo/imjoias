using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;
using System.IO;

namespace Apresentação.Pessoa.Cadastro
{
    /// <summary>
    /// Controle para edição de dados de pessoa jurídica.
    /// </summary>
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

                //if (pessoa.Foto != null)
                //    try
                //    {
                //        picFoto.Image = pessoa.Foto;
                //    }
                //    catch (Exception e)
                //    {
                //        Apresentação.Formulários.NotificaçãoSimples.Mostrar(
                //            "Cadastro de pessoa",
                //            "Não foi possível carregar a foto da pessoa.");

                //        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                //    }
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

        //private void picFoto_Click(object sender, EventArgs e)
        //{
        //início:
        //    if (abrirArquivo.ShowDialog(this.ParentForm) == DialogResult.OK)
        //    {
        //        UseWaitCursor = true;

        //        try
        //        {
        //            FileStream f = File.OpenRead(abrirArquivo.FileName);

        //            picFoto.Image = Image.FromStream(f);
        //            picFoto.Refresh();

        //            f.Close();
        //        }
        //        catch (Exception erro)
        //        {
        //            MessageBox.Show(
        //                ParentForm,
        //                "Não foi possível carregar a foto. O seguinte erro ocorreu:\n\n" + erro.Message,
        //                "Cadastro de pessoa física", MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);

        //            picFoto.Image = null;
        //        }
        //    }
        //    else if (MessageBox.Show(this.ParentForm,
        //        "Deseja excluir a foto atual?",
        //        "Cadastro de Pessoa Física",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        picFoto.Image = null;
        //    }

        //    //try
        //    //{
        //    //    pessoa.Foto = picFoto.Image;
        //    //}
        //    //catch
        //    //{
        //    //    if (MessageBox.Show(
        //    //        ParentForm,
        //    //        "Não foi possível importar a foto atual.",
        //    //        "Cadastro de pessoa",
        //    //        MessageBoxButtons.RetryCancel,
        //    //        MessageBoxIcon.Error) == DialogResult.Retry)
        //    //        goto início;
        //    //}

        //    UseWaitCursor = false;
        //}

        private void txtCódigo_Validating(object sender, CancelEventArgs e)
        {
                e.Cancel =
        Entidades.Pessoa.Pessoa.ObterPessoa((ulong)txtCódigo.Long) != null;
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
            Entidades.Pessoa.PessoaJurídica p = null;

            if (txtCNPJ.Text.Length != 0)
            {
                p = Entidades.Pessoa.PessoaJurídica.ObterPessoaPorCNPJ(txtCNPJ.Text);

                if (p != null && p.Código != pessoa.Código)
                {
                    e.Cancel = true;
                    MessageBox.Show("O CNPJ " + txtCNPJ.Text + " já está associado ao segunte cliente\n\nCódigo:" + p.Código.ToString() + "\nNome:" + (p.Nome != null ? p.Nome : ""), "CNPJ já cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
