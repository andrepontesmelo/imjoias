using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Álbum;
using Apresentação.Formulários;
using Apresentação.Álbum.Edição.Fotos;

namespace Apresentação.Álbum.Edição.Álbuns
{
    public partial class ListViewEdiçãoFotos : ListaFotos
    {
        private Entidades.Álbum.Álbum álbum;
        private BaseInferior baseInferior;

        #region Propriedades

        public BaseInferior BaseInferior
        { set { baseInferior = value; } }

        /// <summary>
        /// Entidade de álbum em edição.
        /// </summary>
        public Entidades.Álbum.Álbum Álbum
        {
            get { return álbum; }
            set
            {
                if (álbum != null)
                {
                    lock (álbum)
                    {
                        // Desregistra eventos passados
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

        #endregion

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

        /// <summary>
        /// Carrega um álbum para edição.
        /// </summary>
        /// <param name="álbum">Álbum a ser editado.</param>
        public override void Carregar(Entidades.Álbum.Álbum álbum)
        {
            this.Álbum = álbum;
        }

        /// <summary>
        /// Adiciona um item ao álbum.
        /// </summary>
        /// <param name="foto">Foto a ser adicionada.</param>
        public override void Adicionar(Foto foto)
        {
            álbum.Fotos.Adicionar(foto);

            // A interface será modificada pelo evento da composição.
        }

        ///// <summary>
        ///// Remove um item do álbum.
        ///// </summary>
        ///// <param name="foto">Foto a ser removida.</param>
        //public override void Remover(Foto foto)
        //{
        //    álbum.Fotos.Remover(foto);

        //    // A interface será modificada pelo evento da composição.
        //}

        /// <summary>
        /// Ocorre ao remover um item da composição do álbum.
        /// </summary>
        void Fotos_AoRemover(Acesso.Comum.DbComposição<Foto> composição, Foto entidade)
        {
            //base.Remover(entidade);
            álbum.Fotos.Atualizar();
        }

        /// <summary>
        /// Ocorre ao adicionar um item da composição do álbum.
        /// </summary>
        void Fotos_AoAdicionar(Acesso.Comum.DbComposição<Foto> composição, Foto entidade)
        {
            base.Adicionar(entidade);
            álbum.Fotos.Atualizar();
        }

        /// <summary>
        /// Ocorre ao mudar a seleção.
        /// </summary>
        private void ListViewEdiçãoFotos_AoSelecionar(Foto foto)
        {
            btnEditar.Enabled = foto != null;
            btnRemover.Enabled = Seleções.Length > 0;
        }

        /// <summary>
        /// Ocorre quando usuário clica em remover foto selecionada.
        /// </summary>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            Foto[] fotos = Seleções;

            foreach (Foto f in fotos)
                álbum.Fotos.Remover(f);

            Carregar(álbum);
        }

        /// <summary>
        /// Ocorre quando usuário clica em editar foto selecionada.
        /// </summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Seleção != null)
            {
                AguardeDB.Mostrar();
                Fotógrafo f = new Fotógrafo();
                baseInferior.SubstituirBase(f);
                f.Editar(Seleção);
                AguardeDB.Fechar();
            }
        }

        /// <summary>
        /// Ocorre quando usuário clica em capturar nova foto.
        /// </summary>
        private void btnCapturar_Click(object sender, EventArgs e)
        {
            baseInferior.SubstituirBase(new Fotógrafo());
            //Fotógrafo.Instância.Controlador.Exibir();
            //Fotógrafo.Instância.listaÁlbuns.Marcar(álbum);
        }

        ///// <summary>
        ///// Dispara duplo clique ao receber um.
        ///// </summary>
        //private void lst_DoubleClick(object sender, EventArgs e)
        //{
        //    OnDoubleClick(e);
        //}

        /// <summary>
        /// Ocorre ao receber um elemento por drag'n'drop.
        /// </summary>
        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            UseWaitCursor = true;
            AguardeDB.Mostrar();
            Foto[] fotos = (Foto[])e.Data.GetData(typeof(Foto[]));

            if (fotos != null)
                foreach (Foto foto in fotos)
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

            UseWaitCursor = false;
            AguardeDB.Fechar();
        }

        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Foto[])))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}

