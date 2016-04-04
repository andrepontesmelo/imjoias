using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Controle de interface gráfica utilizado para sinalizar
    /// que o sistema está carregando os dados.
	/// </summary>
    /// <example>
    /// sinalização = SinalizaçãoCarga.Sinalizar(this, "Carregando...", "Este é um exemplo de carga");
    /// (...)
    /// SinalizaçãoCarga.Dessinalizar(sinalização);
    /// </example>
    [Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design",
     typeof(System.ComponentModel.Design.IDesigner))]
    [Serializable]
    public sealed class SinalizaçãoCarga : System.Windows.Forms.UserControl
	{
		// Atributos
		private Pen caneta;

        private static Dictionary<Control, SinalizaçãoCarga> hashSinalização = new Dictionary<Control,SinalizaçãoCarga>();

        private System.Threading.Timer tmr;
        private PictureBox picÍcone;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblDescrição;
        private Label lblTítulo;

		public SinalizaçãoCarga()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			caneta = new Pen(Color.LightBlue, 2);
		}

		/// <summary>
		/// Constrói a sinalização com uma descrição personalizada.
		/// </summary>
		/// <param name="descrição">Descrição personalizada.</param>
		public SinalizaçãoCarga(string descrição) : this()
		{
			lblDescrição.Text = descrição;
		}

		/// <summary>
		/// Constrói a sinalização com título e descrição personalizadas.
		/// </summary>
		/// <param name="título">Título personalizado.</param>
		/// <param name="descrição">Descrição personalizada.</param>
		public SinalizaçãoCarga(string título, string descrição) : this(descrição)
		{
			lblTítulo.Text = título;
		}

        /// <summary>
        /// Constrói a sinalização com título e descrição personalizadas.
        /// </summary>
        /// <param name="título">Título personalizado.</param>
        /// <param name="descrição">Descrição personalizada.</param>
        public SinalizaçãoCarga(string título, string descrição, Image imagem)
            : this(título, descrição)
        {
            picÍcone.Image = imagem;
        }

        ///// <summary> 
        ///// Clean up any resources being used.
        ///// </summary>
        //protected override void Dispose( bool disposing )
        //{
        //    try
        //    {
        //        if (Parent != null && hashSinalização.ContainsKey(Parent))
        //            Dessinalizar(this);

        //        if (tmr != null)
        //        {
        //            tmr.Dispose();
        //            tmr = null;
        //        }
        //    }
        //    catch { }

        //    if (disposing)
        //    {
        //        if (components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}

        private void Descarregar()
        {
            if (Parent != null && hashSinalização.ContainsKey(Parent))
                Dessinalizar(this);

            if (tmr != null)
            {
                tmr.Dispose();
                tmr = null;
            }
        }

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinalizaçãoCarga));
            this.picÍcone = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.lblTítulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picÍcone
            // 
            this.picÍcone.Dock = System.Windows.Forms.DockStyle.Left;
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            this.picÍcone.Location = new System.Drawing.Point(3, 3);
            this.picÍcone.Name = "picÍcone";
            this.picÍcone.Size = new System.Drawing.Size(43, 90);
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picÍcone.TabIndex = 4;
            this.picÍcone.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblDescrição, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTítulo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(239, 90);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblDescrição
            // 
            this.lblDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrição.Location = new System.Drawing.Point(6, 23);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblDescrição.Size = new System.Drawing.Size(230, 64);
            this.lblDescrição.TabIndex = 2;
            this.lblDescrição.Text = "Por favor, aguarde a carga dos dados.";
            // 
            // lblTítulo
            // 
            this.lblTítulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTítulo.Location = new System.Drawing.Point(6, 3);
            this.lblTítulo.Name = "lblTítulo";
            this.lblTítulo.Size = new System.Drawing.Size(230, 20);
            this.lblTítulo.TabIndex = 1;
            this.lblTítulo.Text = "Carregando...";
            // 
            // SinalizaçãoCarga
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.picÍcone);
            this.Name = "SinalizaçãoCarga";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(288, 96);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SinalizaçãoCarga_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao desenhar a sinalização.
		/// </summary>
		private void SinalizaçãoCarga_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawRectangle(caneta, this.ClientRectangle);
		}

		/// <summary>
		/// Título da sinalização.
		/// </summary>
		public string Título
		{
			get { return lblTítulo.Text; }
			set { lblTítulo.Text = value; }
		}

		/// <summary>
		/// Descrição da sinalização.
		/// </summary>
		public string Descrição
		{
			get { return lblDescrição.Text; }
			set 
            { 
                lblDescrição.Text = value; 
            }
		}

        private delegate void AtribuirDescriçãoDelegate(string descrição);
        private void AtribuirDescrição(string descrição)
        {
            if (lblDescrição.InvokeRequired)
            {
                AtribuirDescriçãoDelegate método = new AtribuirDescriçãoDelegate(AtribuirDescrição);
                lblDescrição.BeginInvoke(método, descrição);
            } else
            {
                lblDescrição.Text = descrição;
            }
        }

        /// <summary>
        /// Imagem da sinalização.
        /// </summary>
        public Image Imagem
        {
            get { return picÍcone.Image; }
            set
            {
                AtribuirImagem(value);
            }
        }

        private delegate void AtribuirImagemDelegate(Image imagem);
        private void AtribuirImagem(Image imagem)
        {
            if (picÍcone.InvokeRequired)
            {
                AtribuirImagemDelegate método = new AtribuirImagemDelegate(AtribuirImagem);
                picÍcone.Invoke(método, imagem);
            }
            else
            {
                picÍcone.Image = imagem;
            }
        }

        private delegate SinalizaçãoCarga SinalizarCallback(Control residência, string título, string descrição, Image imagem);

        /// <summary>
        /// Introduz sinalização de carga em um controle.
        /// </summary>
        /// <param name="residência">Controle onde será inserida a sinalização de carga.</param>
        /// <param name="título">Título da sinalização.</param>
        /// <param name="descrição">Descrição da sinalização.</param>
        public static SinalizaçãoCarga Sinalizar(Control residência, string título, string descrição, MessageBoxIcon ícone)
        {
            Icon imagem;

            switch (ícone)
            {
                //case MessageBoxIcon.Asterisk:
                //    imagem = SystemIcons.Asterisk;
                //    break;

                case MessageBoxIcon.Error:
                //case MessageBoxIcon.Stop:
                    imagem = SystemIcons.Error;
                    break;

                //case MessageBoxIcon.Exclamation:
                //    imagem = SystemIcons.Exclamation;
                //    break;

                //case MessageBoxIcon.Hand:
                //    imagem = SystemIcons.Hand;
                //    break;

                case MessageBoxIcon.Information:
                    imagem = SystemIcons.Information;
                    break;

                case MessageBoxIcon.Question:
                    imagem = SystemIcons.Question;
                    break;

                case MessageBoxIcon.Warning:
                    imagem = SystemIcons.Warning;
                    break;

                default:
                    imagem = null;
                    break;
            }

            return Sinalizar(residência, título, descrição, imagem != null ? imagem.ToBitmap() : null);
        }

        /// <summary>
        /// Introduz sinalização de carga em um controle.
        /// </summary>
        /// <param name="residência">Controle onde será inserida a sinalização de carga.</param>
        /// <param name="título">Título da sinalização.</param>
        /// <param name="descrição">Descrição da sinalização.</param>
        public static SinalizaçãoCarga Sinalizar(Control residência, string título, string descrição)
        {
            return Sinalizar(residência, título, descrição, null);
        }

        /// <summary>
        /// Introduz sinalização de carga em um controle.
        /// </summary>
        /// <param name="residência">Controle onde será inserida a sinalização de carga.</param>
        /// <param name="título">Título da sinalização.</param>
        /// <param name="descrição">Descrição da sinalização.</param>
        public static SinalizaçãoCarga Sinalizar(Control residência, string título, string descrição, Image imagem)
        {
            if (residência.InvokeRequired)
            {
                SinalizarCallback método = new SinalizarCallback(Sinalizar);
                return (SinalizaçãoCarga) residência.Invoke(método, residência, título, descrição, imagem);
            }
            else
            {
                SinalizaçãoCarga sinalização;

                if (imagem == null)
                    sinalização = new SinalizaçãoCarga(título, descrição);
                else
                    sinalização = new SinalizaçãoCarga(título, descrição, imagem);

                residência.SuspendLayout();
                residência.Controls.Add(sinalização);

                if (residência.ClientSize.Width < sinalização.Width)
                    sinalização.Width = residência.ClientSize.Width * 8 / 10;

                sinalização.Location = new Point(
                        (residência.ClientSize.Width - sinalização.Width) / 2,
                        (residência.ClientSize.Height - sinalização.Height) / 2);

                sinalização.BringToFront();
                residência.ResumeLayout();
                sinalização.Refresh();
                //Application.DoEvents();

                if (hashSinalização.ContainsKey(residência))
                    Dessinalizar(residência);

                hashSinalização.Add(residência, sinalização);

                return sinalização;
            }
        }

        private delegate void DessinalizarCallback(SinalizaçãoCarga sinalização);

        /// <summary>
        /// Remove sinalização de carga.
        /// </summary>
        /// <param name="sinalização">Sinalização de carga a ser removida.</param>
        public static void Dessinalizar(SinalizaçãoCarga sinalização)
        {
            if (sinalização.InvokeRequired)
            {
                DessinalizarCallback método = new DessinalizarCallback(Dessinalizar);
                sinalização.BeginInvoke(método, sinalização);
            }
            else
            {
                if (sinalização.Parent != null)
                {
                    hashSinalização.Remove(sinalização.Parent);
                    sinalização.Parent.Controls.Remove(sinalização);
                }

                //sinalização.Dispose();
                sinalização.Descarregar();
            }
        }

        /// <summary>
        /// Remove sinalização de carga.
        /// </summary>
        /// <param name="residência">Controle em que a sinalização reside.</param>
        public static void Dessinalizar(Control residência)
        {
            try
            {
                Dessinalizar(hashSinalização[residência]);
            }
            catch (KeyNotFoundException)
            { 
            
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AtualizarVisible();
        }

        private delegate void AtualizarVisibleDelegate();
        private void AtualizarVisible()
        {
            if (picÍcone.InvokeRequired)
            {
                AtualizarVisibleDelegate método = new AtualizarVisibleDelegate(AtualizarVisible);
                picÍcone.BeginInvoke(método);
            }
            else
            {
                picÍcone.Visible = Width >= 160;
            }
        }

        public void IniciarTemporizador(int milissegundos)
        {
            tmr = new System.Threading.Timer(new System.Threading.TimerCallback(DesligarPorTimer),
                null, milissegundos, Timeout.Infinite);
        }

        private void DesligarPorTimer(object obj)
        {
            Descarregar();
        }
	}
}
