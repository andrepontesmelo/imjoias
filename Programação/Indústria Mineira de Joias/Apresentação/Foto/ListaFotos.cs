using Acesso.Comum;
using Apresentação.Formulários;
using Apresentação.Mercadoria;
using Entidades.Álbum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Álbum.Edição.Fotos
{
    public partial class ListaFotos : UserControl, IDisposable
    {
        private bool ordenar = true;
        private bool incluirForaDeLinha;

        private LinkedList<Foto> cargaFotos = new LinkedList<Foto>();
        private List<Foto> fotos = null;

        public bool Ordenar { get { return ordenar; } set { ordenar = value; } }

        public delegate void FotoHandle(Foto foto);

        public event FotoHandle AoSelecionar;
        public event FotoHandle AoSolicitarExclusão;
        public event FotoHandle AoDuploClique;
        public event FotoHandle AoExcluído;

        public ListaFotos()
        {
            InitializeComponent();

            lst.MouseMove += new MouseEventHandler(lst_MouseMove);
            lst.MouseDown += new MouseEventHandler(lst_MouseDown);

            AllowDrop = true;
        }

        /// <summary>
        /// Fotos a serem exibidas.
        /// </summary>
        public List<Foto> Fotos
        {
            get { return fotos; }
            set
            {
                fotos = value;
                if (fotos != null && ordenar)
                    fotos.Sort();

                lock (cargaFotos)
                {
                    cargaFotos.Clear();
                }

                imagens.Images.Clear();
                imagens.Images.Add("logo", Foto.Redesenhar(Resource.logo, imagens.ImageSize.Width, imagens.ImageSize.Height));

                if (value == null)
                    lst.VirtualListSize = 0;
                else
                    lst.VirtualListSize = value.Count;
            }
        }

        /// <summary>
        /// Foto selecionada.
        /// </summary>
        public Foto Seleção
        {
            get
            {
                return lst.SelectedIndices.Count == 1 ? fotos[lst.SelectedIndices[0]] : null;
            }
        }

        public Foto[] Seleções
        {
            get
            {
                int x = 0;
                for (int idx = 0; idx < lst.Items.Count; idx++) 
                {
                    if (lst.Items[idx].Selected)
                        x++;
                }

                Foto[] fotos = new Foto[lst.SelectedIndices.Count];

                for (int i = 0; i < fotos.Length; i++)
                    fotos[i] = this.fotos[lst.SelectedIndices[i]];

                return fotos;
            }
        }

        /// <summary>
        /// Recupera imagem do banco de dados.
        /// </summary>
        /// <param name="foto">Foto a ser recuperada.</param>
        private void RecuperarImagem(Foto foto)
        {
            bool existe;

            try
            {
                existe = imagens.Images.ContainsKey(foto.Código.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                existe = false;
            }

            if (!existe)
            {
                lock (cargaFotos)
                    cargaFotos.AddFirst(foto);

                if (!bgRecuperação.IsBusy)
                    bgRecuperação.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Recupera a foto a ser exibida.
        /// </summary>
        private void lst_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            Foto foto;
            string título;

            foto = fotos[e.ItemIndex];

            var mercadoria = foto.ObterMercadoria();
            título = string.Format("{0}\n9{1}9 - {2}",
                Entidades.Mercadoria.Mercadoria.MascararReferência(foto.ReferênciaNumérica, true),
                mercadoria.Peso,
                mercadoria.ÍndiceArredondado);

            if (foto.Descrição != null && foto.Descrição.Length > 0)
                título += "\n" + foto.Descrição;

            e.Item = new ListViewItem(título);

            int idx;

            try
            {
                string chave = foto.Código.ToString();

                if (imagens.Images.ContainsKey(chave))
                    idx = imagens.Images.IndexOfKey(foto.Código.ToString());
                else
                    idx = -1;
            }
            catch (ArgumentOutOfRangeException)
            {
                idx = -1;
            }

            if (idx < 0)
            {
                e.Item.ImageIndex = 0;
                RecuperarImagem(foto);
            }
            else
            {
                e.Item.ImageIndex = idx;
            }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AoSelecionar != null)
                AoSelecionar(Seleção);
        }

        private void lst_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            for (int i = e.StartIndex; i < e.EndIndex; i++)
            {
                int idx;

                try
                {
                    idx = imagens.Images.IndexOfKey(fotos[i].Código.ToString());
                }
                catch (ArgumentOutOfRangeException)
                {
                    idx = -1;
                }

                if (idx < 0)
                    RecuperarImagem(fotos[i]);
            }
        }

        /// <summary>
        /// Recupera em segundo plano a foto.
        /// </summary>
        private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            LinkedList<Foto> pilhaLocal = CarregaBancoDadosMiniaturasPendentes();

            while (pilhaLocal.Count > 0)
            {
                Foto foto;
                Image miniatura = null;
                bool temMiniatura;

                do
                {
                    foto = pilhaLocal.First.Value;
                    pilhaLocal.RemoveFirst();

                    try
                    {
                        temMiniatura = imagens.Images.ContainsKey(foto.Código.ToString());
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        temMiniatura = false;
                    }
                } while
                    (temMiniatura && pilhaLocal.Count > 0);

                if (!temMiniatura)
                {
                    DbFoto fotoMiniatura = foto.Miniatura;

                    /* Anterior ao Windows Vista, o ListView não é
                     * capaz de mostrar pixel com alfa diferente de 0
                     * ou 255.
                     */
                    if (Environment.OSVersion.Version.Major < 6)
                    {
                        Image img = Foto.Redesenhar(fotoMiniatura, imagens.ImageSize.Width, imagens.ImageSize.Height);

                        miniatura = new Bitmap(img.Width, img.Height);

                        using (Graphics g = Graphics.FromImage(miniatura))
                        {
                            g.FillRectangle(new SolidBrush(BackColor), 0, 0, img.Width, img.Height);
                            g.DrawImageUnscaled(img, 0, 0);
                        }
                    }
                    else if (fotoMiniatura.Imagem != null)
                        miniatura = Foto.Redesenhar(fotoMiniatura, imagens.ImageSize.Width, imagens.ImageSize.Height);

                    if (fotoMiniatura.Imagem != null && miniatura != null)
                    {
                        imagens.Images.Add(foto.Código.ToString(), miniatura);
                    }
                }
            }

            if (cargaFotos.Count > 500)
            {
                lock (cargaFotos)
                {
                    cargaFotos.Clear();
                }
            }
        }

        private LinkedList<Foto> CarregaBancoDadosMiniaturasPendentes()
        {
            LinkedList<Foto> pilhaLocal;
            Dictionary<uint, Foto> hashFotos = new Dictionary<uint, Foto>(cargaFotos.Count);
            lock (cargaFotos)
            {
                pilhaLocal = new LinkedList<Foto>(cargaFotos);
            }

            foreach (Foto fotoCarga in pilhaLocal)
                hashFotos[fotoCarga.Código] = fotoCarga;

            CacheMiniaturas.Instância.ObterMiniaturas(hashFotos);
            return pilhaLocal;
        }

        private delegate void bgRecuperação_RunWorkerCompletedDelegate(object sender, RunWorkerCompletedEventArgs e);
        /// <summary>
        /// Ocorre ao terminar a recuperação de fotos.
        /// </summary>
        private void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (lst.InvokeRequired)
            {
                bgRecuperação_RunWorkerCompletedDelegate método = new bgRecuperação_RunWorkerCompletedDelegate(bgRecuperação_RunWorkerCompleted);
                lst.BeginInvoke(método, sender, e);
            }
            else
            {
                lst.Invalidate();
            }
        }

        void IDisposable.Dispose()
        {
            try
            {
                if (bgRecuperação.IsBusy)
                    bgRecuperação.CancelAsync();

                if (bgCarregarTudo.IsBusy)
                    bgCarregarTudo.CancelAsync();
            }
            catch { }
        }

        /// <summary>
        /// Adiciona uma foto à lista.
        /// </summary>
        /// <param name="foto">Foto a ser adicionada.</param>
        public virtual void Adicionar(Foto foto)
        {
            if (fotos == null)
                fotos = new List<Foto>();

            fotos.Add(foto);

            if (ordenar)
                fotos.Sort();

            lst.VirtualListSize++;
        }

        /// <summary>
        /// Remove todos os itens da lista.
        /// </summary>
        public void Limpar()
        {
            lst.VirtualListSize = 0;

            imagens.Images.Clear();
            imagens.Images.Add("logo", Foto.Redesenhar(Resource.logo, imagens.ImageSize.Width, imagens.ImageSize.Height));

            lock (cargaFotos)
            {
                cargaFotos.Clear();
            }
        }

        /// <summary>
        /// Carrega fotos a partir de um álbum.
        /// </summary>
        /// <param name="álbum">Álbum a ser carregado.</param>
        public virtual void Carregar(Entidades.Álbum.Álbum álbum)
        {
            AguardeDB.Mostrar();
            Fotos = álbum.Fotos.ExtrairElementos();
            AguardeDB.Fechar();
        }

        /// <summary>
        /// Carrega todas as fotos do banco de dados.
        /// </summary>
        public void Carregar(bool incluirForaDeLinha)
        {
            this.incluirForaDeLinha = incluirForaDeLinha;

            SinalizaçãoCarga.Sinalizar(lst, "Carregando...", "Aguarde enquanto as fotos são carregadas do banco de dados.");

            bgCarregarTudo.RunWorkerAsync(incluirForaDeLinha);
        }

        /// <summary>
        /// Carrega todas as fotos em segundo plano.
        /// </summary>
        private void CarregarTudo(object sender, DoWorkEventArgs e)
        {
            e.Result = new List<Foto>(Foto.ObterFotos((bool)e.Argument));
        }

        /// <summary>
        /// Ocorre ao terminar de carregar todas as fotos em segundo plano.
        /// </summary>
        private void AoCarregarTudo(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Limpar();
                Fotos = (List<Foto>)e.Result;
            }

            SinalizaçãoCarga.Dessinalizar(lst);
        }

        private void lst_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);

            if (Seleção != null && e.Clicks > 1)
                AoDuploClique?.Invoke(Seleção);
        }

        private void lst_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        /// <summary>
        /// Seleciona uma mercadoria pela referência,
        /// mesmo que incompleta.
        /// </summary>
        /// <param name="referência">Referência que pode estar incompleta.</param>
        public void Selecionar(string referência)
        {
            if (fotos != null && fotos.Count > 1)
            {
                // Busca binária 
                int idx, max, min, comparação;

                idx = 0;
                max = fotos.Count - 1;
                min = 0;

                do
                {
                    idx = (max + min) / 2;
                    comparação = fotos[idx].ReferênciaFormatada.CompareTo(referência);

                    if (comparação < 0)
                        min = idx + 1;
                    else if (comparação > 0)
                        max = idx - 1;
                    else
                        break;
                } while (min < max);

                // A foto está nas proximidades de idx. Busca linear.

                min = idx - 1 > 0 ? idx - 1 : 0; 
                max = idx + 2 < lst.Items.Count ? idx + 2 : lst.Items.Count;

                int indice = idx;

                for (int x = min; x < max; x++)
                {
                    if (fotos[x].ReferênciaFormatada.CompareTo(referência) < 0)
                        indice = x + 1;
                }

                if (indice >= 0 && indice < lst.Items.Count)
                {
                    lst.SelectedIndices.Clear();
                    lst.Items[indice].EnsureVisible();
                    lst.Items[indice].Selected = true;
                    return;
                }
            }
        }   

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JanelaInformaçõesMercadoriaResumo.Abrir(Seleção?.ReferênciaNumérica);
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Seleção != null)
            {
                Fotógrafo controle = new Fotógrafo();
                Control pai = Parent;

                while (pai as BaseInferior == null)
                    pai = pai.Parent;

                (pai as BaseInferior).SubstituirBase(controle);

                controle.Editar(Seleção);
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AoSolicitarExclusão != null)
                AoSolicitarExclusão(Seleção);
            else
            {
                Foto[] selecionados = Seleções;

                string mensagem = "Deseja realmente excluir a foto selecionada? Ela será removida de todos os álbuns e do sistema para sempre!";

                if (selecionados.Length > 1)
                    mensagem = "Deseja realmente excluir as " + selecionados.Length.ToString() + " fotos selecionadas? Ela será removida de todos os álbuns e do sistema para sempre!";

                if (selecionados.Length > 0)
                    if (MessageBox.Show(
                        ParentForm,
                        mensagem,
                        "Excluir foto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (MessageBox.Show(
                            ParentForm,
                            "Você está ciente que esta operação afetará todo o sistema e não somente o álbum em edição?",
                            "Excluir foto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            foreach (Foto s in selecionados)
                            {
                                s.Descadastrar();
                            }

                            if (AoExcluído != null)
                                AoExcluído(null);
                        }
            }
        }
    }
}
