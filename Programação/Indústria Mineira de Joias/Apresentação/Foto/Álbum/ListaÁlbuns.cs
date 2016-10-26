using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Apresentação.Formulários;
using Entidades.Álbum;

namespace Apresentação.Álbum.Edição.Álbuns
{
    /// <summary>
    /// Lista de álbum.
    /// </summary>
    public partial class ListaÁlbuns : UserControl, IPósCargaSistema
    {
        /// <summary>
        /// Ocorre quando usuário marca/desmarca
        /// </summary>
        public event EventHandler Alterado;

        /// <summary>
        /// Entidade de foto relacionada.
        /// </summary>
        private Entidades.Álbum.Foto foto = null;

        /// <summary>
        /// Constrói a lista do álbum.
        /// </summary>
        public ListaÁlbuns()
        {
            InitializeComponent();
        }

        private bool alterandoFoto = false;

        public void CarregarFotoParaAlteração(Foto foto)
        {
            Carregar();

            alterandoFoto = true;

            foreach (int i in lista.CheckedIndices)
                lista.SetItemChecked(i, false);

            // Atribuir nulo para que as marcações não alterem a lista.
            this.foto = null;

            if (foto != null)
            {
                lock (foto.Álbuns)
                {
                    foreach (Entidades.Álbum.Álbum álbum in foto.Álbuns)
                    {
                        int i = 0;

                        foreach (Entidades.Álbum.Álbum lÁlbum in lista.Items)
                        {
                            if (lÁlbum.Nome == álbum.Nome)
                            {
                                lista.Items[i] = álbum;
                                lista.SetItemChecked(i, true);
                                break;
                            }

                            i++;
                        }
                    }
                }
            }
            this.foto = foto;
            alterandoFoto = false;
        }

        /// <summary>
        /// Entidade de foto relacionada. Ao atribuir,
        /// marca automaticamente os álbuns vinculados.
        /// </summary>
        [Browsable(false), DefaultValue(null)]
        public Entidades.Álbum.Foto Foto
        {
            get { return foto; }
            set
            {
                this.foto = value;
            }
        }

        /// <summary>
        /// Lista de álbuns marcados.
        /// </summary>
        [Browsable(false)]
        public Entidades.Álbum.Álbum[] ÁlbunsMarcados
        {
            get
            {
                List<Entidades.Álbum.Álbum> lstÁlbuns = new List<Entidades.Álbum.Álbum>();

                bool albumRecémSelecionadoInserido = false;
                foreach (Entidades.Álbum.Álbum álbum in lista.CheckedItems)
                {
                    if (álbum != álbumRecemDeselecionado)
                    {
                        lstÁlbuns.Add(álbum);

                        if (álbum == álbumRecemSelecionado)
                            albumRecémSelecionadoInserido = true;
                    }
                }

                if (!albumRecémSelecionadoInserido && álbumRecemSelecionado != null)
                    lstÁlbuns.Add(álbumRecemSelecionado);

                return lstÁlbuns.ToArray();
            }
        }

        /// <summary>
        /// Ocorre ao carregar completamente o sistema.
        /// </summary>
        public void AoCarregarCompletamente(Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Carregando lista de álbuns.";

            Carregar();
        }

        /// <summary>
        /// Carrega todos os albuns do banco de dados na lista.
        /// </summary>
        public void Carregar()
        {
            Entidades.Álbum.Álbum[] entidades = Entidades.Álbum.Álbum.ObterÁlbuns();

            lista.Items.Clear();
            lista.Items.AddRange(entidades);
        }

        /// <summary>
        /// Ocorre ao marcar um item na lista.
        /// Esta marca irá alterar a lista de álbuns
        /// relacionados à foto, se diferente de nula.
        /// </summary>
        private void lista_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (foto != null && !alterandoFoto)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    álbumRecemSelecionado = (Entidades.Álbum.Álbum) lista.Items[e.Index];
                    foto.Álbuns.Add(álbumRecemSelecionado);
                    álbumRecemDeselecionado = null;
                }
                else
                {
                    álbumRecemDeselecionado = (Entidades.Álbum.Álbum) lista.Items[e.Index];
                    foto.Álbuns.Remove(álbumRecemDeselecionado);
                    álbumRecemSelecionado = null;
                }

                if (Alterado != null)
                    Alterado(sender, e);
            }
        }

        /* O lista_ItemCheck, dispara o evento Alterado que atualiza o banco conforme a marcação dos albuns que está na tela,
         * porém a lista de itens marcados não tem a informação do último item marcado ou desmarcado.
         */
        private Entidades.Álbum.Álbum álbumRecemSelecionado = null;
        private Entidades.Álbum.Álbum álbumRecemDeselecionado = null;

        private void btnCriar_Click(object sender, EventArgs e)
        {
            Entidades.Álbum.Álbum album;

            using (CadastroÁlbum janela = new CadastroÁlbum())
            {
                if (janela.ShowDialog() == DialogResult.OK)
                {
                    album = janela.Álbum;
                    lista.Items.Add(album);
                }
            }
        }

        /// <summary>
        /// Marca um determinado álbum.
        /// </summary>
        /// <param name="álbum">Álbum a ser marcado.</param>
        public void Marcar(Entidades.Álbum.Álbum álbum)
        {
            if (!lista.Items.Contains(álbum))
            {
                foreach (Entidades.Álbum.Álbum item in lista.Items)
                    if (item.Código == álbum.Código)
                    {
                        lista.Items.Remove(item);
                        break;
                    }

                lista.Items.Add(álbum);
            }

            lista.SetItemChecked(lista.Items.IndexOf(álbum), true);
        }
    }
}
