using Apresentação.Álbum.Edição.Fotos;
using Apresentação.Formulários;
using Apresentação.Mercadoria;
using Entidades.Álbum;
using System;
using System.Windows.Forms;

namespace Apresentação.Álbum.Edição.Álbuns
{
    public partial class ListViewEdiçãoFotos : ListaFotos
    {
        private Entidades.Álbum.Álbum álbum;
        private BaseInferior baseInferior;

        public BaseInferior BaseInferior
        { set { baseInferior = value; } }

        public Entidades.Álbum.Álbum Álbum
        {
            get { return álbum; }
            set
            {
                if (álbum != null)
                {
                    lock (álbum)
                    {
                        álbum.Fotos.AoAdicionar -= new Acesso.Comum.DbComposição<Foto>.EventoComposição(Fotos_AoAdicionar);
                        álbum.Fotos.AoRemover -= new Acesso.Comum.DbComposição<Foto>.EventoComposição(Fotos_AoRemover);
                    }
                }

                álbum = value;

                if (álbum == null)
                    Limpar();
                else
                {
                    lock (álbum)
                    {
                        base.Carregar(álbum);
                        álbum.Fotos.AoAdicionar += new Acesso.Comum.DbComposição<Foto>.EventoComposição(Fotos_AoAdicionar);
                        álbum.Fotos.AoRemover += new Acesso.Comum.DbComposição<Foto>.EventoComposição(Fotos_AoRemover);
                    }
                }
            }
        }

        public ListViewEdiçãoFotos()
        {
            InitializeComponent();

            try
            {
                lst.AllowDrop = true;
            }
#if !DEBUG
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
#else
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível permitir o drag'n'drop no ListViewEdiçãoFotos.");
                MessageBox.Show(e.ToString());
                MessageBox.Show("Erro ignorado (inclusive em modo Release).");
            }
#endif
        }

        public override void Carregar(Entidades.Álbum.Álbum álbum)
        {
            this.Álbum = álbum;
        }

        public override void Adicionar(Foto foto)
        {
            álbum.Fotos.Adicionar(foto);
        }

        void Fotos_AoRemover(Acesso.Comum.DbComposição<Foto> composição, Foto entidade)
        {
            álbum.Fotos.Atualizar();
        }

        void Fotos_AoAdicionar(Acesso.Comum.DbComposição<Foto> composição, Foto entidade)
        {
            base.Adicionar(entidade);
            álbum.Fotos.Atualizar();
        }

        private void ListViewEdiçãoFotos_AoSelecionar(Foto foto)
        {
            btnEditar.Enabled = foto != null;
            btnRemover.Enabled = Seleções.Length > 0;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Foto[] fotos = Seleções;

            if (fotos.Length == 0)
                return;

            if (MessageBox.Show(this, 
                String.Format("Deseja remover {0} foto(s) ?", fotos.Length),
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            foreach (Foto f in fotos)
                álbum.Fotos.Remover(f);

            Carregar(álbum);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Seleção == null)
                return;

            AguardeDB.Mostrar();

            Fotógrafo f = new Fotógrafo();
            baseInferior.SubstituirBase(f);
            f.Editar(Seleção);

            AguardeDB.Fechar();
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            baseInferior.SubstituirBase(new Fotógrafo());
        }

        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            Foto[] fotos = (Foto[])e.Data.GetData(typeof(Foto[]));

            if (fotos == null)
                return;

            UseWaitCursor = true;
            AguardeDB.Mostrar();

            foreach (Foto foto in fotos)
                Adiciona(foto);

            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        private void Adiciona(Foto foto)
        {
            try
            {
                if (!álbum.Fotos.Contém(foto))
                    álbum.Fotos.Adicionar(foto);
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

                MessageBox.Show(
                    ParentForm,
                    "Não foi possível adicionar a foto ao álbum. Ocorreu o seguinte erro:\n\n" + erro.ToString(),
                    "Adicionar foto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Foto[])))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }


        private void btnConsultarFotografia_Click(object sender, EventArgs e)
        {
            AbrirJanelaInformaçõesMercadoria();
        }

        private void AbrirJanelaInformaçõesMercadoria()
        {
            if (Seleção != null)
                JanelaInformaçõesMercadoriaResumo.Abrir(Seleção.ReferênciaNumérica);
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            AbrirJanelaInformaçõesMercadoria();
        }
    }
}

