using Apresenta��o.Formul�rios;
using Entidades.Moedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Indicadores
{
    /// <summary>
    /// Lista de cota��o do ouro.
    /// </summary>
    public partial class ListaCota��o : Apresenta��o.Formul�rios.Quadro, IP�sCargaSistema
    {
        /// <summary>
        /// Define que a lista carrega seus pr�prios dados.
        /// </summary>
        private bool autoAlimenta��o = true;

        /// <summary>
        /// Per�odos de listagem.
        /// </summary>
        private DateTime per�odoInicial, per�odoFinal;

        private Moeda moeda;

        /// <summary>
        /// Determina se a lista encontra-se desatualizada
        /// frente ao per�odo estabelecido.
        /// </summary>
        private bool desatualizado;

        private ListViewColumnSorter ordenador;

        /// <summary>
        /// Constr�i a lista de cota��o.
        /// </summary>
        public ListaCota��o()
        {
            InitializeComponent();

            per�odoInicial = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0));
            per�odoFinal   = DateTime.MaxValue;

            ordenador = new ListViewColumnSorter();
            lst.ListViewItemSorter = ordenador;
        }

        #region Propriedades

        /// <summary>
        /// Define que a lista carrega seus pr�prios dados.
        /// </summary>
        [DefaultValue(true), Description("Define se a lista carrega seus pr�prios dados.")]
        public bool AutoAlimenta��o { get { return autoAlimenta��o; } set { autoAlimenta��o = value; } }

        /// <summary>
        /// Per�odo inicial.
        /// </summary>
        [Browsable(false)]
        public DateTime Per�odoInicial
        {
            get { return per�odoInicial; }
            set
            {
                per�odoInicial = value;
                desatualizado = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Per�odo final.
        /// </summary>
        [Browsable(false)]
        public DateTime Per�odoFinal
        {
            get { return per�odoFinal; }
            set
            {
                per�odoFinal = value;
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
                    T�tulo = string.Format("Hist�rico de Cota��o de {0}", moeda.Nome);
            }
        }

        public Entidades.Financeiro.Cota��o Selecionado
        {
            get
            {
                if (lst.SelectedItems.Count == 0)
                    return null;
                else
                    return hashItemCota��o[lst.SelectedItems[0]];
            }
        }

        #endregion

        /// <summary>
        /// Ocorre ao carregar completamente.
        /// </summary>
        public void AoCarregarCompletamente(Splash splash)
        {
            if (splash != null)
                splash.Mensagem = "Carregando cota��es";

            CarregarCota��es();
        }

        /// <summary>
        /// Carrega as �ltimas cota��es cadastradas.
        /// </summary>
        protected void CarregarCota��es()
        {
            if (autoAlimenta��o)
            {
                Entidades.Financeiro.Cota��o[] cota��es;

                cota��es = Entidades.Financeiro.Cota��o.ObterCota��es(moeda, per�odoInicial, per�odoFinal);

                CarregarCota��es(cota��es);
            }
        }

        /// <summary>
        /// Carrega um conjunto de cota��es na lista.
        /// </summary>
        /// <param name="cota��es">Cota��es a serem carregadas.</param>
        public void CarregarCota��es(Entidades.Financeiro.Cota��o[] cota��es)
        {

            UseWaitCursor = true;

            lst.Items.Clear();
            hashItemCota��o.Clear();

            for (int x = cota��es.Length - 1; x >= 0; x--)
                AdicionarCota��o(cota��es[x]);

            UseWaitCursor = false;
            desatualizado = false;
        }

        private Dictionary<ListViewItem, Entidades.Financeiro.Cota��o> hashItemCota��o = new Dictionary<ListViewItem,Entidades.Financeiro.Cota��o>();

        /// <summary>
        /// Adiciona uma cota��o � lista. Pode n�o Adicionar, 
        /// caso o per�odo n�o esteja sendo observado.
        /// </summary>
        public ListViewItem AdicionarCota��o(Entidades.Financeiro.Cota��o cota��o)
        {
            if (cota��o.Data >= per�odoInicial && cota��o.Data <= per�odoFinal)
            {

                ListViewItem item;
                Entidades.Pessoa.Funcion�rio funcion�rio;

                funcion�rio = cota��o.Funcion�rio;

                item = new ListViewItem(new string[] {
                cota��o.Data.ToString(),
                cota��o.Valor.ToString("C", Aplica��o.Aplica��oAtual.Cultura),
                funcion�rio != null ? funcion�rio.Nome : "?"});

                lst.Items.Add(item);

                hashItemCota��o[item] = cota��o;

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
                CarregarCota��es();
        }

        private delegate void MostrarCota��esCallback(Entidades.Financeiro.Cota��o[] cota��es);

        /// <summary>
        /// Mostra um conjunto de cota��es.
        /// </summary>
        /// <param name="cota��es">Conjunto de cota��es a ser exibido.</param>
        public void MostrarCota��es(Entidades.Financeiro.Cota��o[] cota��es)
        {
            if (InvokeRequired)
            {
                MostrarCota��esCallback m�todo = new MostrarCota��esCallback(MostrarCota��es);
                BeginInvoke(m�todo, new object[] { cota��es } );
            }
            else
            {
                UseWaitCursor = true;
                hashItemCota��o.Clear();
                lst.Items.Clear();

                for (int x = cota��es.Length - 1; x >= 0; x--)
                    AdicionarCota��o(cota��es[x]);

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

