using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Entidades;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Indicadores
{
    /// <summary>
    /// Gráfico de cotação do ouro.
    /// </summary>
    public partial class GráficoCotação : Apresentação.Formulários.Quadro
    {
        /// <summary>
        /// Períodos de listagem.
        /// </summary>
        private DateTime períodoInicial, períodoFinal;
        private bool recarregar = true;
        private bool recarregando = false;
        private Moeda moeda;
        private ListaCotação lista = null;

        public GráficoCotação()
        {
            InitializeComponent();

            períodoInicial = DateTime.Now.Subtract(new TimeSpan(182, 0, 0, 0));
            períodoFinal = DateTime.MaxValue;
            Padding = new Padding(0);
        }

        #region Propriedades

        [DefaultValue(null)]
        public ListaCotação Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                recarregar = true;

                if (value != null)
                    value.AutoAlimentação = false;
            }
        }

        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value; recarregar = true; Invalidate();
                
                if (value != null)
                    Título = string.Format("Gráfico do Histórico de Cotação de {0}", moeda.Nome);
            }
        }

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
                recarregar = true;
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
                recarregar = true;
                Invalidate();
            }
        }

        #endregion

        private delegate void RecarregarDelegate();

        public void Recarregar()
        {
            Entidades.Financeiro.Cotação[] cotações;
            double[] valores;
            string[] rótulos;
            int i = 0;

            recarregar = false;

            cotações = Entidades.Financeiro.Cotação.ObterCotações(moeda, períodoInicial, períodoFinal);
            valores = new double[cotações.Length];
            rótulos = new string[cotações.Length];

            foreach (Entidades.Financeiro.Cotação cotação in cotações)
            {
                valores[i] = cotação.Valor;
                rótulos[i++] = cotação.Data.Value.ToString("dd/MM/yy");
            }

            gráfico.VetorÚnico = valores;
            gráfico.RótulosX = rótulos;

            if (lista != null)
                lista.MostrarCotações(cotações);
        }

        private void RecarregarCallback(IAsyncResult resultado)
        {
            RecarregarDelegate método = (RecarregarDelegate)resultado.AsyncState;
            método.EndInvoke(resultado);
            SinalizaçãoCarga.Dessinalizar(this);
            recarregando = false;
        }

        ///// <summary>
        ///// Ocorre ao observar uma cotação.
        ///// </summary>
        //public void AoObservarCotação(ISujeito sujeito, int ação, object dados)
        //{
        //    ICotação cotação = (ICotação)sujeito;

        //    switch ((AçãoCotação) ação)
        //    {
        //        case AçãoCotação.NovaCotação:
        //            if (cotação.Entidade.Data >= períodoInicial && cotação.Entidade.Data <= períodoFinal)
        //                AdicionarCotação(cotação.Entidade);
        //            break;
        //    }
        //}

        /// <summary>
        /// Adiciona uma cotação ao gráfico.
        /// Só é adicionado se o período for interessante.
        /// </summary>
        public void AdicionarCotação(Entidades.Financeiro.Cotação cotação)
        {
            if (cotação.Data >= períodoInicial && cotação.Data <= períodoFinal)
            {

                double[] valores;
                string[] rótulos;

                valores = new double[gráfico.VetorÚnico.Length + 1];
                rótulos = new string[gráfico.RótulosX.Length + 1];

                gráfico.VetorÚnico.CopyTo(valores, 0);
                gráfico.RótulosX.CopyTo(rótulos, 0);

                valores[gráfico.VetorÚnico.Length] = cotação.Valor;
                rótulos[gráfico.RótulosX.Length] = cotação.Data.Value.ToString("dd/MM");

                gráfico.VetorÚnico = valores;
                gráfico.RótulosX = rótulos;
            }
        }

        private void GráficoCotaçãoOuro_Paint(object sender, PaintEventArgs e)
        {
            if (recarregar && !recarregando && !DesignMode)
            {
                recarregando = true;

                SinalizaçãoCarga.Sinalizar(this,
                    string.Format("{0} - Cotação", moeda.Nome),
                    string.Format("Carregando histórico de cotação de {0}.", moeda.Nome));

                RecarregarDelegate método = new RecarregarDelegate(Recarregar);

                método.BeginInvoke(new AsyncCallback(RecarregarCallback), método);
            }
        }
    }
}

