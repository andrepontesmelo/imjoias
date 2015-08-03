using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Apresentação.Formulários;
using Entidades;

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

        /// <summary>
        /// Constrói a lista de cotação.
        /// </summary>
        public ListaCotação()
        {
            InitializeComponent();

//            receptor = new ReceptorMensagens(new EventoObservação(AoObservarCotação), this);

            períodoInicial = DateTime.Now.Subtract(new TimeSpan(90, 0, 0, 0));
            períodoFinal   = DateTime.MaxValue;
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

        public Entidades.Cotação Selecionado
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
                Entidades.Cotação[] cotações;

                cotações = Entidades.Cotação.ObterCotações(moeda, períodoInicial, períodoFinal);

                CarregarCotações(cotações);
            }
        }

        /// <summary>
        /// Carrega um conjunto de cotações na lista.
        /// </summary>
        /// <param name="cotações">Cotações a serem carregadas.</param>
        public void CarregarCotações(Entidades.Cotação[] cotações)
        {

            UseWaitCursor = true;

            lst.Items.Clear();
            hashItemCotação.Clear();

            for (int x = cotações.Length - 1; x >= 0; x--)
                AdicionarCotação(cotações[x]);

            UseWaitCursor = false;
            desatualizado = false;
        }

        private Dictionary<ListViewItem, Entidades.Cotação> hashItemCotação = new Dictionary<ListViewItem,Entidades.Cotação>();

        /// <summary>
        /// Adiciona uma cotação à lista. Pode não Adicionar, 
        /// caso o período não esteja sendo observado.
        /// </summary>
        public ListViewItem AdicionarCotação(Entidades.Cotação cotação)
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

        ///// <summary>
        ///// Ocorre ao observar uma cotação.
        ///// </summary>
        //public void AoObservarCotação(ISujeito sujeito, int ação, object dados)
        //{
        //    ICotação cotação = (ICotação) sujeito;

        //    switch ((AçãoCotação) ação)
        //    {
        //        case AçãoCotação.NovaCotação:
        //            if (cotação.Entidade.Data >= períodoInicial && cotação.Entidade.Data <= períodoFinal)
        //                AdicionarCotação(cotação.Entidade);
        //            break;
        //    }
        //}

        /// <summary>
        /// Ocorre ao desenhar.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (desatualizado && !DesignMode)
                CarregarCotações();
        }

        private delegate void MostrarCotaçõesCallback(Entidades.Cotação[] cotações);

        /// <summary>
        /// Mostra um conjunto de cotações.
        /// </summary>
        /// <param name="cotações">Conjunto de cotações a ser exibido.</param>
        public void MostrarCotações(Entidades.Cotação[] cotações)
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
    }
}

