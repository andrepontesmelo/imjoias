using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Entidades.Privilégio;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Summary description for Quadro.
	/// </summary>
	[Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design", 
		 typeof(System.ComponentModel.Design.IDesigner))]
	[Serializable]
    public class Quadro : System.Windows.Forms.UserControl, IRequerPrivilégio
	{
		// Atributos
		private string título = "Título";
		private int tamanho = 30;
		private GraphicsPath caminho = new GraphicsPath();
		private Color cor = Color.Black;
		private bool [] bordaArredondada = new bool[4];
		private System.Windows.Forms.Label lblTítulo;
		private System.Windows.Forms.ImageList listaIcones;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.PictureBox botãoMinMax;
		private bool minimizado = false;
		private bool mostrarBotãoMinMax = false;
		private Rectangle posiçãoOriginal;
        private Permissão privilégio = Permissão.Nenhuma;

		//Ordem dos ícones no listaÍcones
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

			lblTítulo.Width = Width;

			botãoMinMax.Image = listaIcones.Images[(int) OrdemIcones.minimizar];
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
            this.lblTítulo = new System.Windows.Forms.Label();
            this.botãoMinMax = new System.Windows.Forms.PictureBox();
            this.listaIcones = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.botãoMinMax)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTítulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.lblTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTítulo.ForeColor = System.Drawing.Color.White;
            this.lblTítulo.Location = new System.Drawing.Point(0, 0);
            this.lblTítulo.Name = "lblTítulo";
            this.lblTítulo.Size = new System.Drawing.Size(156, 24);
            this.lblTítulo.TabIndex = 0;
            this.lblTítulo.Text = "Título";
            this.lblTítulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botãoMinMax
            // 
            this.botãoMinMax.Image = ((System.Drawing.Image)(resources.GetObject("botãoMinMax.Image")));
            this.botãoMinMax.Location = new System.Drawing.Point(128, 4);
            this.botãoMinMax.Name = "botãoMinMax";
            this.botãoMinMax.Size = new System.Drawing.Size(20, 16);
            this.botãoMinMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.botãoMinMax.TabIndex = 1;
            this.botãoMinMax.TabStop = false;
            this.botãoMinMax.Visible = false;
            this.botãoMinMax.MouseLeave += new System.EventHandler(this.botãoMinimizar_MouseLeave);
            this.botãoMinMax.Click += new System.EventHandler(this.botãoMinMax_Click);
            this.botãoMinMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.botãoMinMax_MouseDown);
            this.botãoMinMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.botãoMinMax_MouseUp);
            this.botãoMinMax.MouseEnter += new System.EventHandler(this.botãoMinMax_MouseEnter);
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
            this.Controls.Add(this.botãoMinMax);
            this.Controls.Add(this.lblTítulo);
            this.Name = "Quadro";
            this.Size = new System.Drawing.Size(156, 101);
            this.Load += new System.EventHandler(this.Quadro_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Quadro_Paint);
            this.Resize += new System.EventHandler(this.Quadro_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.botãoMinMax)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// Propriedades -------------------------------------
		[Browsable(true)]
		public bool MostrarBotãoMinMax
		{
			get { return mostrarBotãoMinMax; }
			set 
			{ 
				mostrarBotãoMinMax = value;
				PreparaBotãoMinMax();
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

		//		[DefaultValue("Título"), Browsable(true)]
		public string Título
		{
			get { return título; }
			set { lblTítulo.Text = título = value; }
		}

		public Color FundoTítulo
		{
			get { return lblTítulo.BackColor; }
			set { lblTítulo.BackColor = value; }
		}

		public Color LetraTítulo
		{
			get { return lblTítulo.ForeColor; }
			set { lblTítulo.ForeColor = value; }
		}

		/// <summary>
		/// escolhe imagem correta(minimizar ou max), 
		/// Desaparece ou mostra botão, posiciona corretamente.
		/// </summary>
		private void PreparaBotãoMinMax()
		{
			botãoMinMax.Image = minimizado ?
                listaIcones.Images[(int) OrdemIcones.maximizar] : listaIcones.Images[(int) OrdemIcones.minimizar];

			botãoMinMax.Left = lblTítulo.Width - botãoMinMax.Width - botãoMinMax.Top;
			botãoMinMax.Visible = mostrarBotãoMinMax;
		}

		private void Quadro_Resize(object sender, System.EventArgs e)
		{			
			caminho.Reset();

			// Delimita área de desenho
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
			
			// Cria região baseada nos limites
			this.Region = new Region(caminho);

			lblTítulo.Width = Width;

			PreparaBotãoMinMax();

            Invalidate();
		}

		private void Quadro_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawPath(new Pen(cor, 2), caminho);
		}

		private void botãoMinMax_Click(object sender, System.EventArgs e)
		{
			if (minimizado)
				Maximizar();
			else
				Minimizar();

		}

		private void botãoMinMax_MouseEnter(object sender, System.EventArgs e)
		{
			if (!mostrarBotãoMinMax)
				return;

			botãoMinMax.Image = minimizado ?
                listaIcones.Images[(int) OrdemIcones.maximizarMouseCima] : listaIcones.Images[(int) OrdemIcones.minimizarMouseCima];

		}

		private void botãoMinimizar_MouseLeave(object sender, System.EventArgs e)
		{
			PreparaBotãoMinMax();
		}

		private void botãoMinMax_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!mostrarBotãoMinMax)
				return;

			botãoMinMax.Image = minimizado ?
                listaIcones.Images[(int) OrdemIcones.maximizarApertado] : listaIcones.Images[(int) OrdemIcones.minimizarApertado];
		}

		private void botãoMinMax_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
				PreparaBotãoMinMax();
		}

		public void Maximizar()
		{
			int meuÍndice;  // indice do controle atual nos controles do pai
			int meuTop;		// top do controle atual.
			int diferença;  // quantidade de pixels para subir outros controles

			minimizado = false;

			meuÍndice = this.Parent.Controls.GetChildIndex(this, true);
			meuTop = this.Parent.Controls[meuÍndice].Location.Y;

			// Restaura posição original:
			diferença = posiçãoOriginal.Height - this.Height;			
			this.SuspendLayout();
			this.Bounds = new 
				Rectangle(Bounds.X, Bounds.Y, Width, Height + diferença);
			/* não pode-se fazer this.Bounds = posiçãoOriginal;
			 * pois caso um segundo quadro seja minimizado assim 
			 * que o primeiro já foi minimizado
			 * e então o primeiro é maximizado,
			 * quando o segundo for maximizado, a posição restaurada
			 * será errada, pois será aquela antiga.
			 * André, 14/jan/05
			 */
			
			// Muda a posição dos outros controles
			foreach (Control c in this.Parent.Controls)
			{
				int topOriginalC
					= c.Location.Y + diferença;

				// mudar somente controles abaixo do quadro atual.
				if (topOriginalC > meuTop + posiçãoOriginal.Height)
					c.Bounds = new Rectangle(c.Location.X, c.Location.Y + diferença, c.Width, c.Height);
			}

			foreach (Control c in this.Parent.Controls)
				c.ResumeLayout();

			PreparaBotãoMinMax();
		}

		public void Minimizar() 
		{
			int meuÍndice;  // indice do controle atual nos controles do pai
			int meuTop;		// top do controle atual.
			int diferença;  // quantidade de pixels para abaixar outros controles

			minimizado = true;

			meuÍndice = this.Parent.Controls.GetChildIndex(this, true);
			meuTop = this.Parent.Controls[meuÍndice].Location.Y;

			// Grava posição atual:
			posiçãoOriginal = this.Bounds;
			
			// Muda a posição do próprio controle
			this.SuspendLayout();
			this.Bounds = new Rectangle(Location.X, Location.Y, Width, lblTítulo.Height); 
			
			// Muda a posição dos outros controles
			diferença = this.Height - posiçãoOriginal.Height;
			foreach (Control c in this.Parent.Controls)
			{
				// mudar somente controles abaixo do quadro atual.
				if (c.Location.Y > meuTop + posiçãoOriginal.Height)
				{
					c.Bounds = new Rectangle(c.Location.X, c.Location.Y + diferença, c.Width, c.Height);
				}
			}

			foreach (Control c in this.Parent.Controls)
				c.ResumeLayout();

			PreparaBotãoMinMax();
		}

		/// <summary>
		/// Ocorre ao carregar o quadro.
		/// </summary>
		private void Quadro_Load(object sender, System.EventArgs e)
		{
			if (Parent != null && Parent.BackColor == Color.White && BackColor.R == 255 && BackColor.G == 255 && BackColor.B == 255 && BackColor.A != 255)
				//BackColor = Color.FromArgb(232, 231, 202);
				BackColor = Color.FromArgb(242, 239, 221);

            if (!DesignMode && !PermissãoFuncionário.ValidarPermissão(privilégio))
                Enabled = false;
		}

        /// <summary>
        /// Privilégios necessários para exibição do quadro.
        /// </summary>
        [DefaultValue(Permissão.Nenhuma), Description("Privilégios necessários para exibição do quadro."), Browsable(true)]
        public Permissão Privilégio
        {
            get { return privilégio; }
            set { this.privilégio = value; }
        }
	}
}
