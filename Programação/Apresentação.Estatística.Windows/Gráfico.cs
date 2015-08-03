using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;
using Entidades.Estatística;
using Entidades.Estatística.Gráficos;

namespace Apresentação.Estatística.Windows
{
	public abstract class Gráfico : System.Windows.Forms.UserControl
	{
		// Atributos
		protected Desenhista	desenhista;
		protected Bitmap		gráfico = null;
		protected string []	legendas = null;
		protected IDictionary props = Desenhista.ObterPropriedades();

		// Propriedades
        protected Color bordaCor = Color.Black;
        protected Color bordaFundo = Color.White;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Gráfico()
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
			// Gráfico
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Name = "Gráfico";
			this.Size = new System.Drawing.Size(184, 150);
			this.Resize += new System.EventHandler(this.Gráfico_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Chart_Paint);

		}
		#endregion

		private void Chart_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (gráfico == null)
				gráfico = desenhista.Desenhar(this.Width, this.Height, props);

			if (gráfico != null)
				e.Graphics.DrawImageUnscaled(gráfico, 0, 0);
		}

		private void Gráfico_Resize(object sender, System.EventArgs e)
		{
			gráfico = null; this.Invalidate();
		}

		public Color FundoCor
		{
			get { return this.BackColor; }
			set { BackColor = value; }
		}

		#region Propriedades

        /// <summary>
        /// Matriz contendo seqüência e valores.
        /// </summary>
        [Browsable(false), ReadOnly(true)]
        public double[][] Dados
		{
			get { return desenhista.Dados; }
			set { desenhista.Dados = value; gráfico = null; Invalidar(); }
		}

        /// <summary>
        /// Vetor contendo valores da única seqüência de dados.
        /// </summary>
        [Browsable(false), ReadOnly(true)]
        public double[] VetorÚnico
		{
			get { return desenhista.VetorÚnico; }
			set { desenhista.VetorÚnico = value; gráfico = null; Invalidar(); }
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
        /// Mostra dados de várias seqüências de valores.
        /// </summary>
        /// <param name="seqüênicas">Seqüências de valores</param>
        public void Mostrar(double[][] seqüências)
        {
            Dados = seqüências;
        }

        /// <summary>
        /// Mostra dados de várias seqüências de valores obtidas
        /// a partir de objetos plotáveis.
        /// </summary>
        /// <param name="objetos">Lista de objetos plotáveis.</param>
        public void Mostrar(IEnumerable<IPlotávelSeqüência> objetos)
        {
            LinkedList<string> seqüências = new LinkedList<string>();
            Dictionary<string, LinkedList<double>> hashSeq = new Dictionary<string, LinkedList<double>>();

            // Identificar seqüências.
            foreach (IPlotávelSeqüência obj in objetos)
            {
                LinkedList<double> lista;

                if (hashSeq.TryGetValue(obj.ObterSeqüênciaPlotagem(), out lista))
                    lista.AddLast(obj.ObterValorPlotagem());
                else
                {
                    double valor = obj.ObterValorPlotagem();
                    string strSeq = obj.ObterSeqüênciaPlotagem();

                    lista = new LinkedList<double>();
                    lista.AddLast(valor);
                    hashSeq.Add(strSeq, lista);
                    seqüências.AddLast(strSeq);
                }
            }

            // Variáveis para conversão para matriz.
            long nSeqüências, nDados = 0;
            double[][] dados;
            string[] legenda;

            // Contar dados.
            foreach (LinkedList<double> lista in hashSeq.Values)
                nDados = Math.Max(nDados, lista.Count);

            // Converter para matriz.
            nSeqüências = seqüências.Count;
            legenda     = new string[nSeqüências];
            dados       = new double[nSeqüências][];
            
            int i = 0;

            foreach (string seqüência in seqüências)
            {
                int j = 0;

                legenda[i] = seqüência;
                dados[i]   = new double[nDados];

                foreach (double valor in hashSeq[seqüência])
                    dados[i][j++] = valor;

                i++;
            }

            Dados = dados;
            Legendas = legenda;
        }

        /// <summary>
        /// Mostra dados rotulados de valores obtidos
        /// a partir de objetos plotáveis.
        /// </summary>
        /// <param name="objetos">Lista de objetos plotáveis.</param>
        public void Mostrar(IEnumerable<IPlotávelRotulado> objetos)
        {
            List<double> dados = new List<double>();
            List<string> rótulos = new List<string>();

            // Identificar seqüências.
            foreach (IPlotávelRotulado obj in objetos)
            {
                dados.Add(obj.ObterValorPlotagem());
                rótulos.Add(obj.ObterRótulo());
            }

            VetorÚnico = dados.ToArray();
            desenhista.RótulosX = rótulos.ToArray();
        }

        /// <summary>
        /// Mostra dados de valores obtidos a partir de objetos
        /// plotáveis.
        /// </summary>
        /// <param name="objetos">Lista de objetos plotáveis.</param>
        public void Mostrar(IEnumerable<IPlotável> objetos)
        {
            List<double> dados = new List<double>();

            foreach (IPlotável obj in objetos)
                dados.Add(obj.ObterValorPlotagem());

            VetorÚnico = dados.ToArray();
        }

        private delegate void InvalidarCallback();

        private void Invalidar()
        {
            if (InvokeRequired)
            {
                InvalidarCallback método = new InvalidarCallback(Invalidate);
                BeginInvoke(método);
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
