using Apresentação.Formulários;
using Entidades.Moedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Indicadores
{
    /// <summary>
    /// Lista de cotação do ouro.
    /// </summary>
    public partial class ListaCotação : Apresentação.Formulários.Quadro, IPósCargaSistema
    {
        /// <summary>
        /// Define que a lista carrega seus próprios dados.
        /// </summary>
        private bool autoAlimentação = true;

        /// <summary>
        /// Períodos de listagem.
        /// </summary>
        private DateTime períodoInicial, períodoFinal;

        private Moeda moeda;

        /// <summary>
        /// Determina se a lista encontra-se desatualizada
        /// frente ao período estabelecido.
        /// </summary>
        private bool desatualizado;

        private ListViewColumnSorter ordenador;

        /// <summary>
        /// Constrói a lista de cotação.
        /// </summary>
        public ListaCotação()
        {
            InitializeComponent();

            períodoInicial = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0));
            períodoFinal   = DateTime.MaxValue;

            ordenador = new ListViewColumnSorter();
            lst.ListViewItemSorter = ordenador;
        }

        #region Propriedades

        /// <summary>
        /// Define que a lista carrega seus próprios dados.
        /// </summary>
        [DefaultValue(true), Description("Define se a lista carrega seus próprios dados.")]
        public bool AutoAlimentação { get { return autoAlimentação; } set { autoAlimentação = value; } }

        /// <summary>
        /// Período inicial.
        /// </summary>
        [Browsable(false)]
        public DateTime PeríodoInicial
        {
            get { return períodoInicial; }
            set
            {
                períodoInicial = value;
                desatualizado = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Período final.
        /// </summary>
        [Browsable(false)]
        public DateTime PeríodoFinal
        {
            get { return períodoFinal; }
            set
            {
                períodoFinal = value;
                desatualizado = true;
                Invalidate();
            }
        }

        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value; desatualizado = true; Invalidate();

                if (moeda != null)
                    Título = string.Format("Histórico de Cotação de {0}", moeda.Nome);
            }
        }

        public Entidades.Financeiro.Cotação Selecionado
        {
            get
            {
                if (lst.SelectedItems.Count == 0)
                    return null;
                else
                    return hashItemCotação[lst.SelectedItems[0]];
            }
        }

        #endregion

        /// <summary>
        /// Ocorre ao carregar completamente.
        /// </summary>
        public void AoCarregarCompletamente(Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Carregando cotações";

            CarregarCotações();
        }

        /// <summary>
        /// Carrega as últimas cotações cadastradas.
        /// </summary>
        protected void CarregarCotações()
        {
            if (autoAlimentação)
            {
                Entidades.Financeiro.Cotação[] cotações;

                cotações = Entidades.Financeiro.Cotação.ObterCotações(moeda, períodoInicial, períodoFinal);

                CarregarCotações(cotações);
            }
        }

        /// <summary>
        /// Carrega um conjunto de cotações na lista.
        /// </summary>
        /// <param name="cotações">Cotações a serem carregadas.</param>
        public void CarregarCotações(Entidades.Financeiro.Cotação[] cotações)
        {

            UseWaitCursor = true;

            lst.Items.Clear();
            hashItemCotação.Clear();

            for (int x = cotações.Length - 1; x >= 0; x--)
                AdicionarCotação(cotações[x]);

            UseWaitCursor = false;
            desatualizado = false;
        }

        private Dictionary<ListViewItem, Entidades.Financeiro.Cotação> hashItemCotação = new Dictionary<ListViewItem,Entidades.Financeiro.Cotação>();

        /// <summary>
        /// Adiciona uma cotação à lista. Pode não Adicionar, 
        /// caso o período não esteja sendo observado.
        /// </summary>
        public ListViewItem AdicionarCotação(Entidades.Financeiro.Cotação cotação)
        {
            if (cotação.Data >= períodoInicial && cotação.Data <= períodoFinal)
            {

                ListViewItem item;
                Entidades.Pessoa.Funcionário funcionário;

                funcionário = cotação.Funcionário;

                item = new ListViewItem(new string[] {
                cotação.Data.ToString(),
                cotação.Valor.ToString("C", Aplicação.AplicaçãoAtual.Cultura),
                funcionário != null ? funcionário.Nome : "?"});

                lst.Items.Add(item);

                hashItemCotação[item] = cotação;

                return item;
            }
            else
                return null;
        }

        /// <summary>
        /// Ocorre ao desenhar.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (desatualizado && !DesignMode)
                CarregarCotações();
        }

        private delegate void MostrarCotaçõesCallback(Entidades.Financeiro.Cotação[] cotações);

        /// <summary>
        /// Mostra um conjunto de cotações.
        /// </summary>
        /// <param name="cotações">Conjunto de cotações a ser exibido.</param>
        public void MostrarCotações(Entidades.Financeiro.Cotação[] cotações)
        {
            if (InvokeRequired)
            {
                MostrarCotaçõesCallback método = new MostrarCotaçõesCallback(MostrarCotações);
                BeginInvoke(método, new object[] { cotações } );
            }
            else
            {
                UseWaitCursor = true;
                hashItemCotação.Clear();
                lst.Items.Clear();

                for (int x = cotações.Length - 1; x >= 0; x--)
                    AdicionarCotação(cotações[x]);

                UseWaitCursor = false;
                desatualizado = false;
            }
        }

        private void lst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenador.OnClick(lst, e);
        }
    }
}

