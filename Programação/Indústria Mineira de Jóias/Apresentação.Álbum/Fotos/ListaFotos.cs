using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Álbum;
using Apresentação.Formulários;
using System.Collections;
using Acesso.Comum;
using Apresentação.Mercadoria;

namespace Apresentação.Álbum.Fotos
{
    public partial class ListaFotos : UserControl, IDisposable
    {
        /// <summary>
        /// Fotos a serem exibidas.
        /// </summary>
        private List<Foto> fotos = null;

        private bool ordenar = true;

        /// <summary>
        /// Pilha para carga de fotos.
        /// </summary>
        private LinkedList<Foto> cargaFotos = new LinkedList<Foto>();

        public bool Ordenar { get { return ordenar; } set { ordenar = value; } }

        public delegate void FotoHandle(Foto foto);

        public event FotoHandle AoSelecionar;
        public event FotoHandle AoDuploClique;


        /// <summary>
        /// Constrói a lista de fotos.
        /// </summary>
        public ListaFotos()
        {
            InitializeComponent();
            lst.DoubleClick += new EventHandler(lst_DoubleClick);
        }

        void lst_DoubleClick(object sender, EventArgs e)
        {
            Entidades.Mercadoria.Mercadoria m = 
                Entidades.Mercadoria.Mercadoria.ObterMercadoria(Seleção.ReferênciaFormatada, Entidades.Tabela.TabelaPadrão);

            InformaçõesMercadoria janela = new InformaçõesMercadoria(m, 
                Entidades.Cotação.ObterCotaçãoVigente(Entidades.Moeda.ObterMoeda(Entidades.Moeda.MoedaSistema.Ouro)));

            janela.Show();

            if (AoDuploClique != null)
                AoDuploClique(Seleção);
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

#if DEBUG
                if (fotos != null)
                    foreach (Foto foto in fotos)
                        if (foto == null)
                            throw new ArgumentNullException();
#endif

                if (fotos != null && ordenar)
                    fotos.Sort();

                lock (cargaFotos)
                {
                    cargaFotos.Clear();
                }

                if (value == null)
                    lst.VirtualListSize = 0;
                else
                    lst.VirtualListSize = value.Count;

                lock (imagens)
                {
                    imagens.Images.Clear();
                    imagens.Images.Add("logo", Foto.Redesenhar(Properties.Resources.Logo, imagens.ImageSize.Width, imagens.ImageSize.Height));
                }
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
            if (!imagens.Images.ContainsKey(foto.Código.ToString()))
            {
                lock (cargaFotos)
                    cargaFotos.AddFirst(foto);

                if (!bgRecuperação.IsBusy)
                    bgRecuperação.RunWorkerAsync();
            }
        }

//        /// <summary>
//        /// Remove excesso de fotos no cadastro.
//        /// </summary>
//        private void RemoverExcesso()
//        {
//            lock (cargaFotos)
//            {
//                if (imagens.Images.Count >= limiarImagens)
//                {
//                    DateTime agora = DateTime.Now;

//                    // Desconsiderando o logo da IMJ (i = 0).
//                    for (int i = 1; i < imagens.Images.Count; i++)
//                    {
//                        /* Uma imagem nunca deveria ter tag nula, mas por
//                         * algum motivo desconhecido, está acontecendo.
//                         * -- Júlio, 13/06/2006
//                         */
//                        if (imagens.Images[i].Tag == null)
//                        {
//#if DEBUG
//                            Console.Out.WriteLine("*** Removendo imagem {0} do banco de imagens. Tag nula!", i);
//#endif
//                            imagens.Images.RemoveAt(i--);
//                        }
//                        else if (hashExibição[(Foto)imagens.Images[i].Tag] - agora > tempoImagens)
//                            imagens.Images.RemoveAt(i--);
//                    }
//                }
//            }
//        }

        /// <summary>
        /// Recupera a foto a ser exibida.
        /// </summary>
        private void lst_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            Foto foto;
            string título;

            foto = fotos[e.ItemIndex];
            título = foto.ReferênciaFormatada;

            if (foto.Descrição != null && foto.Descrição.Length > 0)
                título += "\n" + foto.Descrição;

            e.Item = new ListViewItem(título);

            //Entidades.Mercadoria.Mercadoria m = foto.ObterMercadoria();

            //if (m != null && m.ForaDeLinha)
            //{
            //    e.Item.BackColor = Color.Red;
            //    e.Item.Font = new Font(e.Item.Font, FontStyle.Strikeout);
            //}

            bool recuperado;

            lock (imagens)
            {
                recuperado = imagens.Images.ContainsKey(foto.Código.ToString());
            }

            if (!recuperado)
            {
                e.Item.ImageIndex = 0;
                RecuperarImagem(foto);
            }
            else
            {
                lock (imagens)
                    e.Item.ImageIndex = imagens.Images.IndexOfKey(foto.Código.ToString());
            }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AoSelecionar != null)
                AoSelecionar(Seleção);
        }

        private void lst_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            //lock (cargaFotos)
            //{
            lock (cargaFotos)
                cargaFotos.Clear();

            for (int i = e.StartIndex; i < e.EndIndex; i++)
            {
                int idx;

                lock (imagens)
                    idx = imagens.Images.IndexOfKey(fotos[i].Código.ToString());

                if (idx < 0)
                    RecuperarImagem(fotos[i]);
            }

                //for (int i = imagens.Images.Count - 1; i > 0; i--)
                //{
                //    TimeSpan ts;

                //    ts = hashExibição[imagens.Images.Keys[i]] - DateTime.Now;

                //    if (ts.TotalSeconds > tempoImagens)
                //        imagens.Images.RemoveAt(i);
                //}
            //}
        }

        /// <summary>
        /// Recupera em segundo plano a foto.
        /// </summary>
        private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            LinkedList<Foto> pilhaLocal;

            //lock (cargaFotos)
            //{
                // Carrega do banco as miniaturas de todas as fotos pendentes para carregamento.
                Dictionary<uint, Foto> hashFotos = new Dictionary<uint, Foto>(cargaFotos.Count);
                lock (cargaFotos)
                {
                    pilhaLocal = new LinkedList<Foto>(cargaFotos);
                    cargaFotos.Clear();
                }

                foreach (Foto fotoCarga in pilhaLocal)
                    hashFotos[fotoCarga.Código] = fotoCarga;

                Foto.ObterMiniaturas(hashFotos);

                while (pilhaLocal.Count > 0)
                {
                    Foto foto;
                    Image miniatura;
                    bool temMiniatura;

                    do
                    {
                        foto = pilhaLocal.Last.Value;
                        pilhaLocal.RemoveLast();
                        
                        lock (imagens)
                            temMiniatura = imagens.Images.ContainsKey(foto.Código.ToString());
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
                        else
                            miniatura = Foto.Redesenhar(fotoMiniatura, imagens.ImageSize.Width, imagens.ImageSize.Height);

                        lock (imagens)
                            imagens.Images.Add(foto.Código.ToString(), miniatura);
                    }
                }
            //}
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
        /// Remove uma foto da lista.
        /// </summary>
        /// <param name="foto">Foto a ser removida.</param>
        public virtual void Remover(Foto foto)
        {
            //lock (cargaFotos)
            //{
                fotos.Remove(foto);

                lock (cargaFotos)
                {
                    if (cargaFotos.Contains(foto))
                        cargaFotos.Clear();
                }

                lock (imagens)
                {
                    while (imagens.Images.ContainsKey(foto.Código.ToString()))
                    {
                        imagens.Images.RemoveByKey(foto.Código.ToString());
                    }
                }

                lst.VirtualListSize--;
            //}

            lst.Invalidate();
        }

        /// <summary>
        /// Remove todos os itens da lista.
        /// </summary>
        public void Limpar()
        {
            lst.VirtualListSize = 0;

            lock (imagens)
            {
                imagens.Images.Clear();
            }

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
                    lst.Items[indice].EnsureVisible();
                    lst.Items[indice].Selected = true;
                }
            }
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);

        //    progresso.Top = ClientSize.Height - progresso.Height - progresso.Margin.Bottom;
        //    progresso.Width = ClientSize.Width - progresso.Left * 2 - SystemInformation.VerticalScrollBarWidth;
        //}

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void verSemelhantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        void editarToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Fotógrafo controle = new Fotógrafo();
            if (listaFotosTodas.Seleção != null)
                Controlador.InserirBaseInferior(controle);

            controle.Editar(listaFotosTodas.Seleção);
        }

    }
}
