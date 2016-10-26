using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Álbum
{
    public partial class ListViewÁlbuns : UserControl, IAoMostrarBaseInferior
    {
        private Entidades.Álbum.Álbum[] álbuns;
        private Dictionary<ListViewItem, Entidades.Álbum.Álbum> hashÁlbum;

        public event EventHandler AoSelecionarÁlbum;

        public ListViewÁlbuns()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao redimensionar ListView, redimensionando
        /// também suas colunas.
        /// </summary>
        private void AoRedimensionar(object sender, EventArgs e)
        {
            colDescrição.Width = lst.ClientSize.Width - colÁlbum.Width - colData.Width;
        }

        /// <summary>
        /// Ocorre ao exibir pela primeira vez a base inferior
        /// em que este controle está inserido.
        /// </summary>
        public void AoExibirDaPrimeiraVez(BaseInferior baseInferior)
        {
            // Nada aqui.
        }

        /// <summary>
        /// Ocorre ao exibir a base ifnerior em que está inserido
        /// este controle.
        /// </summary>
        public void AoExibir(BaseInferior baseInferior)
        {
            SinalizaçãoCarga.Sinalizar(lst, "Carregando dados...", "Aguarde enquanto os dados sobre os álbuns são carregados do banco de dados.");

            bgRecuperação.RunWorkerAsync();
        }

        /// <summary>
        /// Recupera os álbuns do banco de dados em segundo plano.
        /// </summary>
        private void RecuperarÁlbuns(object sender, DoWorkEventArgs e)
        {
            álbuns = Entidades.Álbum.Álbum.ObterÁlbuns();
        }

        /// <summary>
        /// Ocorre ao recuperar álbuns do banco de dados
        /// em segundo plano, inserindo dados na ListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AoRecuperarÁlbuns(object sender, RunWorkerCompletedEventArgs e)
        {
            lst.Items.Clear();

            hashÁlbum = new Dictionary<ListViewItem, Entidades.Álbum.Álbum>();

            foreach (Entidades.Álbum.Álbum álbum in álbuns)
                Adicionar(álbum);

            SinalizaçãoCarga.Dessinalizar(lst);
        }

        /// <summary>
        /// Adiciona um álbum à ListView.
        /// </summary>
        private void Adicionar(Entidades.Álbum.Álbum álbum)
        {
            ListViewItem item;

            item = new ListViewItem(álbum.Nome);
            item.SubItems.Add(álbum.Descrição);
            item.SubItems.Add(álbum.Alteração.HasValue ? álbum.Alteração.Value.ToString("dd/MM/yyyy HH:mm") : álbum.Criação.ToString("dd/MM/yyyy HH:mm"));
            lst.Items.Add(item);
            item.ImageIndex = 0;
            hashÁlbum[item] = álbum;
        }

        /// <summary>
        /// Ocorre ao selecionar o álbum.
        /// </summary>
        private void AoSelecionar(object sender, EventArgs e)
        {
            if (AoSelecionarÁlbum != null)
                AoSelecionarÁlbum(this, e);
        }

        /// <summary>
        /// Álbum selecinoado.
        /// </summary>
        public Entidades.Álbum.Álbum Seleção
        {
            get { return lst.SelectedIndices.Count == 1 ? hashÁlbum[lst.SelectedItems[0]] : null; }
        }

        /// <summary>
        /// Remove álbum da lista.
        /// </summary>
        /// <param name="álbum">Álbum a ser removido.</param>
        public void Remover(Entidades.Álbum.Álbum álbum)
        {
            foreach (ListViewItem item in lst.Items)
                if (hashÁlbum[item] == álbum)
                {
                    hashÁlbum.Remove(item);
                    item.Remove();
                    return;
                }
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }
    }
}
