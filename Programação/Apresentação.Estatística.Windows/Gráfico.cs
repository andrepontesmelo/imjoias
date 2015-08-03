using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;
using Entidades.Estat�stica;
using Entidades.Estat�stica.Gr�ficos;

namespace Apresenta��o.Estat�stica.Windows
{
	public abstract class Gr�fico : System.Windows.Forms.UserControl
	{
		// Atributos
		protected Desenhista	desenhista;
		protected Bitmap		gr�fico = null;
		protected string []	legendas = null;
		protected IDictionary props = Desenhista.ObterPropriedades();

		// Propriedades
        protected Color bordaCor = Color.Black;
        protected Color bordaFundo = Color.White;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Gr�fico()
		{
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Gr�fico
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Name = "Gr�fico";
			this.Size = new System.Drawing.Size(184, 150);
			this.Resize += new System.EventHandler(this.Gr�fico_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Chart_Paint);

		}
		#endregion

		private void Chart_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (gr�fico == null)
				gr�fico = desenhista.Desenhar(this.Width, this.Height, props);

			if (gr�fico != null)
				e.Graphics.DrawImageUnscaled(gr�fico, 0, 0);
		}

		private void Gr�fico_Resize(object sender, System.EventArgs e)
		{
			gr�fico = null; this.Invalidate();
		}

		public Color FundoCor
		{
			get { return this.BackColor; }
			set { BackColor = value; }
		}

		#region Propriedades

        /// <summary>
        /// Matriz contendo seq��ncia e valores.
        /// </summary>
        [Browsable(false), ReadOnly(true)]
        public double[][] Dados
		{
			get { return desenhista.Dados; }
			set { desenhista.Dados = value; gr�fico = null; Invalidar(); }
		}

        /// <summary>
        /// Vetor contendo valores da �nica seq��ncia de dados.
        /// </summary>
        [Browsable(false), ReadOnly(true)]
        public double[] Vetor�nico
		{
			get { return desenhista.Vetor�nico; }
			set { desenhista.Vetor�nico = value; gr�fico = null; Invalidar(); }
		}

        [Browsable(false)]
		public string [] Legendas
		{
			get { return legendas; }
			set
			{
				legendas = value;
				desenhista.Legendas = value;
			}
		}

        [Browsable(false), ReadOnly(true)]
		public IDictionary PropriedadesDesenho
		{
			get { return props; }
			set { props = value; Invalidar(); }
		}

		#endregion

        /// <summary>
        /// Mostra dados de v�rias seq��ncias de valores.
        /// </summary>
        /// <param name="seq��nicas">Seq��ncias de valores</param>
        public void Mostrar(double[][] seq��ncias)
        {
            Dados = seq��ncias;
        }

        /// <summary>
        /// Mostra dados de v�rias seq��ncias de valores obtidas
        /// a partir de objetos plot�veis.
        /// </summary>
        /// <param name="objetos">Lista de objetos plot�veis.</param>
        public void Mostrar(IEnumerable<IPlot�velSeq��ncia> objetos)
        {
            LinkedList<string> seq��ncias = new LinkedList<string>();
            Dictionary<string, LinkedList<double>> hashSeq = new Dictionary<string, LinkedList<double>>();

            // Identificar seq��ncias.
            foreach (IPlot�velSeq��ncia obj in objetos)
            {
                LinkedList<double> lista;

                if (hashSeq.TryGetValue(obj.ObterSeq��nciaPlotagem(), out lista))
                    lista.AddLast(obj.ObterValorPlotagem());
                else
                {
                    double valor = obj.ObterValorPlotagem();
                    string strSeq = obj.ObterSeq��nciaPlotagem();

                    lista = new LinkedList<double>();
                    lista.AddLast(valor);
                    hashSeq.Add(strSeq, lista);
                    seq��ncias.AddLast(strSeq);
                }
            }

            // Vari�veis para convers�o para matriz.
            long nSeq��ncias, nDados = 0;
            double[][] dados;
            string[] legenda;

            // Contar dados.
            foreach (LinkedList<double> lista in hashSeq.Values)
                nDados = Math.Max(nDados, lista.Count);

            // Converter para matriz.
            nSeq��ncias = seq��ncias.Count;
            legenda     = new string[nSeq��ncias];
            dados       = new double[nSeq��ncias][];
            
            int i = 0;

            foreach (string seq��ncia in seq��ncias)
            {
                int j = 0;

                legenda[i] = seq��ncia;
                dados[i]   = new double[nDados];

                foreach (double valor in hashSeq[seq��ncia])
                    dados[i][j++] = valor;

                i++;
            }

            Dados = dados;
            Legendas = legenda;
        }

        /// <summary>
        /// Mostra dados rotulados de valores obtidos
        /// a partir de objetos plot�veis.
        /// </summary>
        /// <param name="objetos">Lista de objetos plot�veis.</param>
        public void Mostrar(IEnumerable<IPlot�velRotulado> objetos)
        {
            List<double> dados = new List<double>();
            List<string> r�tulos = new List<string>();

            // Identificar seq��ncias.
            foreach (IPlot�velRotulado obj in objetos)
            {
                dados.Add(obj.ObterValorPlotagem());
                r�tulos.Add(obj.ObterR�tulo());
            }

            Vetor�nico = dados.ToArray();
            desenhista.R�tulosX = r�tulos.ToArray();
        }

        /// <summary>
        /// Mostra dados de valores obtidos a partir de objetos
        /// plot�veis.
        /// </summary>
        /// <param name="objetos">Lista de objetos plot�veis.</param>
        public void Mostrar(IEnumerable<IPlot�vel> objetos)
        {
            List<double> dados = new List<double>();

            foreach (IPlot�vel obj in objetos)
                dados.Add(obj.ObterValorPlotagem());

            Vetor�nico = dados.ToArray();
        }

        private delegate void InvalidarCallback();

        private void Invalidar()
        {
            if (InvokeRequired)
            {
                InvalidarCallback m�todo = new InvalidarCallback(Invalidate);
                BeginInvoke(m�todo);
            }
            else
                Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                Dados = new double[][] {
                    new double[] { 1, 2, 3, 7, 8, 9 },
                    new double[] { 5, 3, 7, 9, 2, 2 }};
        }
    }
}
