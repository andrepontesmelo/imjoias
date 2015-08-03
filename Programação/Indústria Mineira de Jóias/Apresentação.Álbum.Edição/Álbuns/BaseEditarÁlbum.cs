using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Álbum;
using Apresentação.Formulários;
using Apresentação.Álbum.Edição.Impressão;
using Apresentação.Álbum.Edição.Álbuns.Desenhista;
using Apresentação.Álbum.Edição.Fotos;

namespace Apresentação.Álbum.Edição.Álbuns
{
    public partial class BaseEditarÁlbum : Apresentação.Formulários.BaseInferior
    {
        public BaseEditarÁlbum()
        {
            InitializeComponent();

            lstEdição.BaseInferior = this;
        }

        public BaseEditarÁlbum(Entidades.Álbum.Álbum álbum)
            : this()
        {
            lstEdição.Álbum = álbum;
            lstEdição.BaseInferior = this;

            títuloBaseInferior.Descrição = álbum.Nome + "\n" + álbum.Descrição;
        }


        /// <summary>
        /// Ocorre ao exibir a base inferior.
        /// </summary>
        protected override void AoExibir()
        {
            base.AoExibir();

            listaFotosTodas.Carregar(chkForaDeLinha.Checked);

            // Talvez que o vinculo foto-album tenha sido alterado:
            Entidades.Álbum.Álbum album = Entidades.Álbum.Álbum.ObterÁlbum(lstEdição.Álbum.Código);
            lstEdição.Carregar(album);
        }

        private bool dragging = false;

        /// <summary>
        /// Ocorre ao pressionar o mouse na lista de todas as fotos.
        /// </summary>
        private void listaFotosTodas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dragging && e.Button == MouseButtons.Left)
                try
                {
                    Foto[] fotos = listaFotosTodas.Seleções;

                    if (fotos.Length > 0)
                    {
                        dragging = true;
                        listaFotosTodas.DoDragDrop(listaFotosTodas.Seleções, DragDropEffects.Link);
                    }
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

#if DEBUG
                    MessageBox.Show("Não foi possível iniciar drag'n'drop!\n\n" + erro.ToString());
#endif
                }
        }

        private void listaFotosTodas_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        /// <summary>
        /// Ao alterar uma referência, procurá-la na lista de fotos.
        /// </summary>
        private void txtReferência_ReferênciaAlterada(object sender, EventArgs e)
        {
            if (txtReferência.Referência.Length > 0)
                try
                {
                    listaFotosTodas.Selecionar(txtReferência.Referência);
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
                }
        }

        /// <summary>
        /// Exclui o álbum inteiro.
        /// </summary>
        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            bool confirmado;
            Entidades.Álbum.Álbum álbum;

            álbum = lstEdição.Álbum;

            if (álbum.Fotos.ContarElementos() == 0)
                confirmado = true;
            else
            {
                confirmado = MessageBox.Show(
                    this.ParentForm,
                    "Deseja mesmo excluir o álbum " + álbum.Nome + "?\n\n"
                    + "(Obs.: As fotos não serão excluidas do banco de dados.",
                    "Excluir álbum",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes;

                if (confirmado)
                    confirmado = MessageBox.Show(
                        this.ParentForm,
                        "Você tem certeza?\n\nNÃO SERÁ POSSÍVEL REVERTER ESSA AÇÃO!",
                        "Excluir álbum",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes;
            }

            if (confirmado)
            {
                AguardeDB.Mostrar();
                álbum.Descadastrar();
                AguardeDB.Fechar();
                SubstituirBaseParaInicial();
            }
        }

        /// <summary>
        /// Imprime o álbum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            using (JanelaOpçõesImpressão dlg = new JanelaOpçõesImpressão())
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                    ControleImpressão.Imprimir(lstEdição.Álbum, dlg.Itens);
            }
        }

        /// <summary>
        /// Renomea o álbum.
        /// </summary>
        private void opçãoRenomear_Click(object sender, EventArgs e)
        {
            using (CadastroÁlbum dlg = new CadastroÁlbum(lstEdição.Álbum))
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                    títuloBaseInferior.Descrição = lstEdição.Álbum.Nome + "\n" + lstEdição.Álbum.Descrição;
            }
        }

        private void chkForaDeLinha_CheckedChanged(object sender, EventArgs e)
        {
            listaFotosTodas.Carregar(chkForaDeLinha.Checked);
        }

        //void listaFotosTodas_AoDuploClique(Entidades.Álbum.Foto foto)
        //{

        //    Fotógrafo controle = new Fotógrafo(); 
        //    if (listaFotosTodas.Seleção != null)
        //        Controlador.InserirBaseInferior(controle);

        //    controle.Editar(listaFotosTodas.Seleção);
        //}

        void editarToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Fotógrafo controle = new Fotógrafo();
            if (listaFotosTodas.Seleção != null)
                Controlador.InserirBaseInferior(controle);

            controle.Editar(listaFotosTodas.Seleção);
        }


        private void verSemelhantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listaFotosTodas.Seleção != null)
                SubstituirBase(new EditarMercadoria(Entidades.Mercadoria.Mercadoria.ObterMercadoria(listaFotosTodas.Seleção.ReferênciaFormatada, Entidades.Tabela.TabelaPadrão)));
        }

        private void lnkMaisFotos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BaseTodasFotos novaBase = new BaseTodasFotos();
            SubstituirBase(novaBase);
        }

        private void listaFotosTodas_AoExcluído(Foto foto)
        {
            Entidades.Álbum.Álbum album = Entidades.Álbum.Álbum.ObterÁlbum(lstEdição.Álbum.Código);
            lstEdição.Carregar(album);

            listaFotosTodas.Carregar(chkForaDeLinha.Checked);
        }
    }
}

