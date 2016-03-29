using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Entidades.Privil�gio;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Summary description for Quadro.
	/// </summary>
	[Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", 
		 typeof(System.ComponentModel.Design.IDesigner))]
	[Serializable]
    public class Quadro : System.Windows.Forms.UserControl, IRequerPrivil�gio
	{
		// Atributos
		private string t�tulo = "T�tulo";
		private int tamanho = 30;
		private GraphicsPath caminho = new GraphicsPath();
		private Color cor = Color.Black;
		private bool [] bordaArredondada = new bool[4];
		private System.Windows.Forms.Label lblT�tulo;
		private System.Windows.Forms.ImageList listaIcones;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.PictureBox bot�oMinMax;
		private bool minimizado = false;
		private bool mostrarBot�oMinMax = false;
		private Rectangle posi��oOriginal;
        private Permiss�o privil�gio = Permiss�o.Nenhuma;

		//Ordem dos �cones no lista�cones
		private enum OrdemIcones { minimizar, minimizarMouseCima, minimizarApertado, maximizar, maximizarMouseCima, maximizarApertado};
		
		public Quadro()
		{
			// This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            
			// TODO: Add any initialization after the InitializeComponent call
			this.SetStyle(ControlStyles.Opaque, false);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			this.BackColor = Color.FromArgb(128, 255, 255, 255); //Color.PaleGoldenrod;

			for (int i = 0; i < 4; i++)
				bordaArredondada[i] = true;

			lblT�tulo.Width = Width;

			bot�oMinMax.Image = listaIcones.Images[(int) OrdemIcones.minimizar];
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quadro));
            this.lblT�tulo = new System.Windows.Forms.Label();
            this.bot�oMinMax = new System.Windows.Forms.PictureBox();
            this.listaIcones = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bot�oMinMax)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT�tulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT�tulo.ForeColor = System.Drawing.Color.White;
            this.lblT�tulo.Location = new System.Drawing.Point(0, 0);
            this.lblT�tulo.Name = "lblT�tulo";
            this.lblT�tulo.Size = new System.Drawing.Size(156, 24);
            this.lblT�tulo.TabIndex = 0;
            this.lblT�tulo.Text = "T�tulo";
            this.lblT�tulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bot�oMinMax
            // 
            this.bot�oMinMax.Image = ((System.Drawing.Image)(resources.GetObject("bot�oMinMax.Image")));
            this.bot�oMinMax.Location = new System.Drawing.Point(128, 4);
            this.bot�oMinMax.Name = "bot�oMinMax";
            this.bot�oMinMax.Size = new System.Drawing.Size(20, 16);
            this.bot�oMinMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bot�oMinMax.TabIndex = 1;
            this.bot�oMinMax.TabStop = false;
            this.bot�oMinMax.Visible = false;
            this.bot�oMinMax.MouseLeave += new System.EventHandler(this.bot�oMinimizar_MouseLeave);
            this.bot�oMinMax.Click += new System.EventHandler(this.bot�oMinMax_Click);
            this.bot�oMinMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bot�oMinMax_MouseDown);
            this.bot�oMinMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bot�oMinMax_MouseUp);
            this.bot�oMinMax.MouseEnter += new System.EventHandler(this.bot�oMinMax_MouseEnter);
            // 
            // listaIcones
            // 
            this.listaIcones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listaIcones.ImageStream")));
            this.listaIcones.TransparentColor = System.Drawing.Color.PaleGoldenrod;
            this.listaIcones.Images.SetKeyName(0, "");
            this.listaIcones.Images.SetKeyName(1, "");
            this.listaIcones.Images.SetKeyName(2, "");
            this.listaIcones.Images.SetKeyName(3, "");
            this.listaIcones.Images.SetKeyName(4, "");
            this.listaIcones.Images.SetKeyName(5, "");
            // 
            // Quadro
            // 
            this.Controls.Add(this.bot�oMinMax);
            this.Controls.Add(this.lblT�tulo);
            this.Name = "Quadro";
            this.Size = new System.Drawing.Size(156, 101);
            this.Load += new System.EventHandler(this.Quadro_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Quadro_Paint);
            this.Resize += new System.EventHandler(this.Quadro_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bot�oMinMax)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// Propriedades -------------------------------------
		[Browsable(true)]
		public bool MostrarBot�oMinMax
		{
			get { return mostrarBot�oMinMax; }
			set 
			{ 
				mostrarBot�oMinMax = value;
				PreparaBot�oMinMax();
			}
		}

		public Color Cor
		{
			get { return cor; }
			set { cor = value; this.Refresh(); }
		}

		public int Tamanho
		{
			get { return tamanho; }
			set
			{
				tamanho = value;
				Quadro_Resize(this, null);
				this.Refresh();
			}
		}

		public bool bSupEsqArredondada
		{
			get { return bordaArredondada[0]; }
			set { bordaArredondada[0] = value; Quadro_Resize(this, null); this.Refresh(); }
		}

		public bool bSupDirArredondada
		{
			get { return bordaArredondada[1]; }
			set { bordaArredondada[1] = value; Quadro_Resize(this, null); this.Refresh(); }
		}

		public bool bInfDirArredondada
		{
			get { return bordaArredondada[2]; }
			set { bordaArredondada[2] = value; Quadro_Resize(this, null); this.Refresh(); }
		}

		public bool bInfEsqArredondada
		{
			get { return bordaArredondada[3]; }
			set { bordaArredondada[3] = value; Quadro_Resize(this, null); this.Refresh(); }
		}

		//		[DefaultValue("T�tulo"), Browsable(true)]
		public string T�tulo
		{
			get { return t�tulo; }
			set { lblT�tulo.Text = t�tulo = value; }
		}

		public Color FundoT�tulo
		{
			get { return lblT�tulo.BackColor; }
			set { lblT�tulo.BackColor = value; }
		}

		public Color LetraT�tulo
		{
			get { return lblT�tulo.ForeColor; }
			set { lblT�tulo.ForeColor = value; }
		}

		/// <summary>
		/// escolhe imagem correta(minimizar ou max), 
		/// Desaparece ou mostra bot�o, posiciona corretamente.
		/// </summary>
		private void PreparaBot�oMinMax()
		{
			bot�oMinMax.Image = minimizado ?
                listaIcones.Images[(int) OrdemIcones.maximizar] : listaIcones.Images[(int) OrdemIcones.minimizar];

			bot�oMinMax.Left = lblT�tulo.Width - bot�oMinMax.Width - bot�oMinMax.Top;
			bot�oMinMax.Visible = mostrarBot�oMinMax;
		}

		private void Quadro_Resize(object sender, System.EventArgs e)
		{			
			caminho.Reset();

			// Delimita �rea de desenho
			if (bordaArredondada[0])
				caminho.AddArc(0, 0, tamanho, tamanho, 180, 90);
			else
			{
				caminho.AddLine(0, tamanho, 0, 0);
				caminho.AddLine(0, 0, tamanho, 0);
			}

			if (bordaArredondada[1])
				caminho.AddArc(this.Width - tamanho, 0, tamanho, tamanho, 270, 90);
			else
			{
				caminho.AddLine(this.Width - tamanho, 0, this.Width, 0);
				caminho.AddLine(this.Width, 0, this.Width, tamanho);
			}

			if (bordaArredondada[2])
				caminho.AddArc(this.Width - tamanho, this.Height - tamanho, tamanho, tamanho, 0, 90);
			else
			{
				caminho.AddLine(this.Width, this.Height - tamanho, this.Width, this.Height);
				caminho.AddLine(this.Width, this.Height, this.Width - tamanho, this.Height);
			}

			if (bordaArredondada[3])
				caminho.AddArc(0, this.Height - tamanho, tamanho, tamanho, 90, 90);
			else
			{
				caminho.AddLine(tamanho, this.Height, 0, this.Height);
				caminho.AddLine(0, this.Height, 0, this.Height - tamanho);
			}

			caminho.CloseFigure();
			
			// Cria regi�o baseada nos limites
			this.Region = new Region(caminho);

			lblT�tulo.Width = Width;

			PreparaBot�oMinMax();

            Invalidate();
		}

		private void Quadro_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawPath(new Pen(cor, 2), caminho);
		}

		private void bot�oMinMax_Click(object sender, System.EventArgs e)
		{
			if (minimizado)
				Maximizar();
			else
				Minimizar();

		}

		private void bot�oMinMax_MouseEnter(object sender, System.EventArgs e)
		{
			if (!mostrarBot�oMinMax)
				return;

			bot�oMinMax.Image = minimizado ?
                listaIcones.Images[(int) OrdemIcones.maximizarMouseCima] : listaIcones.Images[(int) OrdemIcones.minimizarMouseCima];

		}

		private void bot�oMinimizar_MouseLeave(object sender, System.EventArgs e)
		{
			PreparaBot�oMinMax();
		}

		private void bot�oMinMax_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!mostrarBot�oMinMax)
				return;

			bot�oMinMax.Image = minimizado ?
                listaIcones.Images[(int) OrdemIcones.maximizarApertado] : listaIcones.Images[(int) OrdemIcones.minimizarApertado];
		}

		private void bot�oMinMax_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
				PreparaBot�oMinMax();
		}

		public void Maximizar()
		{
			int meu�ndice;  // indice do controle atual nos controles do pai
			int meuTop;		// top do controle atual.
			int diferen�a;  // quantidade de pixels para subir outros controles

			minimizado = false;

			meu�ndice = this.Parent.Controls.GetChildIndex(this, true);
			meuTop = this.Parent.Controls[meu�ndice].Location.Y;

			// Restaura posi��o original:
			diferen�a = posi��oOriginal.Height - this.Height;			
			this.SuspendLayout();
			this.Bounds = new 
				Rectangle(Bounds.X, Bounds.Y, Width, Height + diferen�a);
			/* n�o pode-se fazer this.Bounds = posi��oOriginal;
			 * pois caso um segundo quadro seja minimizado assim 
			 * que o primeiro j� foi minimizado
			 * e ent�o o primeiro � maximizado,
			 * quando o segundo for maximizado, a posi��o restaurada
			 * ser� errada, pois ser� aquela antiga.
			 * Andr�, 14/jan/05
			 */
			
			// Muda a posi��o dos outros controles
			foreach (Control c in this.Parent.Controls)
			{
				int topOriginalC
					= c.Location.Y + diferen�a;

				// mudar somente controles abaixo do quadro atual.
				if (topOriginalC > meuTop + posi��oOriginal.Height)
					c.Bounds = new Rectangle(c.Location.X, c.Location.Y + diferen�a, c.Width, c.Height);
			}

			foreach (Control c in this.Parent.Controls)
				c.ResumeLayout();

			PreparaBot�oMinMax();
		}

		public void Minimizar() 
		{
			int meu�ndice;  // indice do controle atual nos controles do pai
			int meuTop;		// top do controle atual.
			int diferen�a;  // quantidade de pixels para abaixar outros controles

			minimizado = true;

			meu�ndice = this.Parent.Controls.GetChildIndex(this, true);
			meuTop = this.Parent.Controls[meu�ndice].Location.Y;

			// Grava posi��o atual:
			posi��oOriginal = this.Bounds;
			
			// Muda a posi��o do pr�prio controle
			this.SuspendLayout();
			this.Bounds = new Rectangle(Location.X, Location.Y, Width, lblT�tulo.Height); 
			
			// Muda a posi��o dos outros controles
			diferen�a = this.Height - posi��oOriginal.Height;
			foreach (Control c in this.Parent.Controls)
			{
				// mudar somente controles abaixo do quadro atual.
				if (c.Location.Y > meuTop + posi��oOriginal.Height)
				{
					c.Bounds = new Rectangle(c.Location.X, c.Location.Y + diferen�a, c.Width, c.Height);
				}
			}

			foreach (Control c in this.Parent.Controls)
				c.ResumeLayout();

			PreparaBot�oMinMax();
		}

		/// <summary>
		/// Ocorre ao carregar o quadro.
		/// </summary>
		private void Quadro_Load(object sender, System.EventArgs e)
		{
			if (Parent != null && Parent.BackColor == Color.White && BackColor.R == 255 && BackColor.G == 255 && BackColor.B == 255 && BackColor.A != 255)
				//BackColor = Color.FromArgb(232, 231, 202);
				BackColor = Color.FromArgb(242, 239, 221);

            if (!DesignMode && !Permiss�oFuncion�rio.ValidarPermiss�o(privil�gio))
                Enabled = false;
		}

        /// <summary>
        /// Privil�gios necess�rios para exibi��o do quadro.
        /// </summary>
        [DefaultValue(Permiss�o.Nenhuma), Description("Privil�gios necess�rios para exibi��o do quadro."), Browsable(true)]
        public Permiss�o Privil�gio
        {
            get { return privil�gio; }
            set { this.privil�gio = value; }
        }
	}
}
