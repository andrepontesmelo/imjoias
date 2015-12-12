using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Entidades;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Financeiro.Indicadores
{
    /// <summary>
    /// Gr�fico de cota��o do ouro.
    /// </summary>
    public partial class Gr�ficoCota��o : Apresenta��o.Formul�rios.Quadro
    {
        /// <summary>
        /// Per�odos de listagem.
        /// </summary>
        private DateTime per�odoInicial, per�odoFinal;
        private bool recarregar = true;
        private bool recarregando = false;
        private Moeda moeda;
        private ListaCota��o lista = null;

        public Gr�ficoCota��o()
        {
            InitializeComponent();

            per�odoInicial = DateTime.Now.Subtract(new TimeSpan(182, 0, 0, 0));
            per�odoFinal = DateTime.MaxValue;
            Padding = new Padding(0);
        }

        #region Propriedades

        [DefaultValue(null)]
        public ListaCota��o Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                recarregar = true;

                if (value != null)
                    value.AutoAlimenta��o = false;
            }
        }

        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                moeda = value; recarregar = true; Invalidate();
                
                if (value != null)
                    T�tulo = string.Format("Gr�fico do Hist�rico de Cota��o de {0}", moeda.Nome);
            }
        }

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
                recarregar = true;
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
                recarregar = true;
                Invalidate();
            }
        }

        #endregion

        private delegate void RecarregarDelegate();

        public void Recarregar()
        {
            Entidades.Financeiro.Cota��o[] cota��es;
            double[] valores;
            string[] r�tulos;
            int i = 0;

            recarregar = false;

            cota��es = Entidades.Financeiro.Cota��o.ObterCota��es(moeda, per�odoInicial, per�odoFinal);
            valores = new double[cota��es.Length];
            r�tulos = new string[cota��es.Length];

            foreach (Entidades.Financeiro.Cota��o cota��o in cota��es)
            {
                valores[i] = cota��o.Valor;
                r�tulos[i++] = cota��o.Data.Value.ToString("dd/MM/yy");
            }

            gr�fico.Vetor�nico = valores;
            gr�fico.R�tulosX = r�tulos;

            if (lista != null)
                lista.MostrarCota��es(cota��es);
        }

        private void RecarregarCallback(IAsyncResult resultado)
        {
            RecarregarDelegate m�todo = (RecarregarDelegate)resultado.AsyncState;
            m�todo.EndInvoke(resultado);
            Sinaliza��oCarga.Dessinalizar(this);
            recarregando = false;
        }

        ///// <summary>
        ///// Ocorre ao observar uma cota��o.
        ///// </summary>
        //public void AoObservarCota��o(ISujeito sujeito, int a��o, object dados)
        //{
        //    ICota��o cota��o = (ICota��o)sujeito;

        //    switch ((A��oCota��o) a��o)
        //    {
        //        case A��oCota��o.NovaCota��o:
        //            if (cota��o.Entidade.Data >= per�odoInicial && cota��o.Entidade.Data <= per�odoFinal)
        //                AdicionarCota��o(cota��o.Entidade);
        //            break;
        //    }
        //}

        /// <summary>
        /// Adiciona uma cota��o ao gr�fico.
        /// S� � adicionado se o per�odo for interessante.
        /// </summary>
        public void AdicionarCota��o(Entidades.Financeiro.Cota��o cota��o)
        {
            if (cota��o.Data >= per�odoInicial && cota��o.Data <= per�odoFinal)
            {

                double[] valores;
                string[] r�tulos;

                valores = new double[gr�fico.Vetor�nico.Length + 1];
                r�tulos = new string[gr�fico.R�tulosX.Length + 1];

                gr�fico.Vetor�nico.CopyTo(valores, 0);
                gr�fico.R�tulosX.CopyTo(r�tulos, 0);

                valores[gr�fico.Vetor�nico.Length] = cota��o.Valor;
                r�tulos[gr�fico.R�tulosX.Length] = cota��o.Data.Value.ToString("dd/MM");

                gr�fico.Vetor�nico = valores;
                gr�fico.R�tulosX = r�tulos;
            }
        }

        private void Gr�ficoCota��oOuro_Paint(object sender, PaintEventArgs e)
        {
            if (recarregar && !recarregando && !DesignMode)
            {
                recarregando = true;

                Sinaliza��oCarga.Sinalizar(this,
                    string.Format("{0} - Cota��o", moeda.Nome),
                    string.Format("Carregando hist�rico de cota��o de {0}.", moeda.Nome));

                RecarregarDelegate m�todo = new RecarregarDelegate(Recarregar);

                m�todo.BeginInvoke(new AsyncCallback(RecarregarCallback), m�todo);
            }
        }
    }
}

