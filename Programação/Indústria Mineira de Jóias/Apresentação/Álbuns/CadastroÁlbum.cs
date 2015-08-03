using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Álbum;

namespace Apresentação.Álbum.Edição.Álbuns
{
    /// <summary>
    /// Cria ou edita um cadastro de um álbum.
    /// </summary>
    public partial class CadastroÁlbum : Apresentação.Formulários.JanelaExplicativa
    {
        private Entidades.Álbum.Álbum álbum;

        public Entidades.Álbum.Álbum Álbum
        {
            get { return álbum; }
            set
            {
                álbum = value;

                txtNome.Text = álbum.Nome;
                txtNome.SelectAll();

                txtDescrição.Text = álbum.Descrição;
                txtDescrição.SelectAll();

                groupBox1.Enabled = !value.Cadastrado;
            }
        }

        public CadastroÁlbum()
        {
            InitializeComponent();
        }

        public CadastroÁlbum(Entidades.Álbum.Álbum álbum) : this()
        {
            Álbum = álbum;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();

            try
            {
                if (álbum == null || !álbum.Cadastrado)
                {
                    álbum = Entidades.Álbum.Álbum.Cadastrar(txtNome.Text.Trim(), txtDescrição.Text);

                    if (radioTudo.Checked || radioLinha.Checked)
                    {
                        int qtd = Entidades.Álbum.Foto.ContarFotos();

                        AguardeDB.Suspensão(true);

                        try
                        {
                            using (Aguarde dlg = new Aguarde("Preparando álbum", qtd, "Inserindo fotos", "Aguarde enquanto o sistema insere as fotos no novo álbum."))
                            {
                                Foto[] fotos = Foto.ObterFotos(true);

                                foreach (Foto foto in fotos)
                                {
                                    bool ok = true;

                                    Entidades.Mercadoria.Mercadoria mercadoria;

                                    dlg.Show();
                                    dlg.Passo(foto.ReferênciaFormatada);

                                    if (radioLinha.Checked)
                                    {
                                        mercadoria = Entidades.Mercadoria.Mercadoria.ObterMercadoria(foto.ReferênciaFormatada, Entidades.Tabela.TabelaPadrão);

                                        if (mercadoria != null)
                                            ok = !mercadoria.ForaDeLinha;
                                    }

                                    if (ok)
                                        álbum.Fotos.Adicionar(foto);
                                }
                            }
                        }
                        finally
                        {
                            AguardeDB.Suspensão(false);
                        }

                        álbum.Atualizar();
                    }
                }
                else
                {
                    álbum.Nome = txtNome.Text.Trim();
                    álbum.Descrição = txtDescrição.Text;
                    álbum.Atualizar();
                }
            }
            finally
            {
                AguardeDB.Fechar();
            }

            DialogResult = DialogResult.OK;
        }

        private void CadastroÁlbum_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = txtNome.Text.Trim().Length > 0;
        }
    }
}

