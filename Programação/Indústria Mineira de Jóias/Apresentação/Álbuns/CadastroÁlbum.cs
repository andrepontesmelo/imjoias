using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Entidades.�lbum;

namespace Apresenta��o.�lbum.Edi��o.�lbuns
{
    /// <summary>
    /// Cria ou edita um cadastro de um �lbum.
    /// </summary>
    public partial class Cadastro�lbum : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private Entidades.�lbum.�lbum �lbum;

        public Entidades.�lbum.�lbum �lbum
        {
            get { return �lbum; }
            set
            {
                �lbum = value;

                txtNome.Text = �lbum.Nome;
                txtNome.SelectAll();

                txtDescri��o.Text = �lbum.Descri��o;
                txtDescri��o.SelectAll();

                groupBox1.Enabled = !value.Cadastrado;
            }
        }

        public Cadastro�lbum()
        {
            InitializeComponent();
        }

        public Cadastro�lbum(Entidades.�lbum.�lbum �lbum) : this()
        {
            �lbum = �lbum;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                if (�lbum == null || !�lbum.Cadastrado)
                {
                    �lbum = Entidades.�lbum.�lbum.Cadastrar(txtNome.Text.Trim(), txtDescri��o.Text);

                    if (radioTudo.Checked || radioLinha.Checked)
                    {
                        int qtd = Entidades.�lbum.Foto.ContarFotos();

                        AguardeDB.Suspens�o(true);

                        try
                        {
                            using (Aguarde dlg = new Aguarde("Preparando �lbum", qtd, "Inserindo fotos", "Aguarde enquanto o sistema insere as fotos no novo �lbum."))
                            {
                                Foto[] fotos = Foto.ObterFotos(true);

                                foreach (Foto foto in fotos)
                                {
                                    bool ok = true;

                                    Entidades.Mercadoria.Mercadoria mercadoria;

                                    dlg.Show();
                                    dlg.Passo(foto.Refer�nciaFormatada);

                                    if (radioLinha.Checked)
                                    {
                                        mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(foto.Refer�nciaFormatada, Entidades.Tabela.TabelaPadr�o);

                                        if (mercadoria != null)
                                            ok = !mercadoria.ForaDeLinha;
                                    }

                                    if (ok)
                                        �lbum.Fotos.Adicionar(foto);
                                }
                            }
                        }
                        finally
                        {
                            AguardeDB.Suspens�o(false);
                        }

                        �lbum.Atualizar();
                    }
                }
                else
                {
                    �lbum.Nome = txtNome.Text.Trim();
                    �lbum.Descri��o = txtDescri��o.Text;
                    �lbum.Atualizar();
                }
            }
            finally
            {
                AguardeDB.Fechar();
            }

            DialogResult = DialogResult.OK;
        }

        private void Cadastro�lbum_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = txtNome.Text.Trim().Length > 0;
        }
    }
}

