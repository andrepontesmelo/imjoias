using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Controle de interface gr�fica utilizado para sinalizar
    /// que o sistema est� carregando os dados.
	/// </summary>
    /// <example>
    /// sinaliza��o = Sinaliza��oCarga.Sinalizar(this, "Carregando...", "Este � um exemplo de carga");
    /// (...)
    /// Sinaliza��oCarga.Dessinalizar(sinaliza��o);
    /// </example>
    [Designer("System.Windows.Forms.Design.ParentControlDesigner,System.Design",
     typeof(System.ComponentModel.Design.IDesigner))]
    [Serializable]
    public sealed class Sinaliza��oCarga : System.Windows.Forms.UserControl
	{
		// Atributos
		private Pen caneta;

        private static Dictionary<Control, Sinaliza��oCarga> hashSinaliza��o = new Dictionary<Control,Sinaliza��oCarga>();

        private System.Threading.Timer tmr;
        private PictureBox pic�cone;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblDescri��o;
        private Label lblT�tulo;

		public Sinaliza��oCarga()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			caneta = new Pen(Color.LightBlue, 2);
		}

		/// <summary>
		/// Constr�i a sinaliza��o com uma descri��o personalizada.
		/// </summary>
		/// <param name="descri��o">Descri��o personalizada.</param>
		public Sinaliza��oCarga(string descri��o) : this()
		{
			lblDescri��o.Text = descri��o;
		}

		/// <summary>
		/// Constr�i a sinaliza��o com t�tulo e descri��o personalizadas.
		/// </summary>
		/// <param name="t�tulo">T�tulo personalizado.</param>
		/// <param name="descri��o">Descri��o personalizada.</param>
		public Sinaliza��oCarga(string t�tulo, string descri��o) : this(descri��o)
		{
			lblT�tulo.Text = t�tulo;
		}

        /// <summary>
        /// Constr�i a sinaliza��o com t�tulo e descri��o personalizadas.
        /// </summary>
        /// <param name="t�tulo">T�tulo personalizado.</param>
        /// <param name="descri��o">Descri��o personalizada.</param>
        public Sinaliza��oCarga(string t�tulo, string descri��o, Image imagem)
            : this(t�tulo, descri��o)
        {
            pic�cone.Image = imagem;
        }

        ///// <summary> 
        ///// Clean up any resources being used.
        ///// </summary>
        //protected override void Dispose( bool disposing )
        //{
        //    try
        //    {
        //        if (Parent != null && hashSinaliza��o.ContainsKey(Parent))
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
            if (Parent != null && hashSinaliza��o.ContainsKey(Parent))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sinaliza��oCarga));
            this.pic�cone = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescri��o = new System.Windows.Forms.Label();
            this.lblT�tulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic�cone
            // 
            this.pic�cone.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            this.pic�cone.Location = new System.Drawing.Point(3, 3);
            this.pic�cone.Name = "pic�cone";
            this.pic�cone.Size = new System.Drawing.Size(43, 90);
            this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic�cone.TabIndex = 4;
            this.pic�cone.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblDescri��o, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblT�tulo, 0, 0);
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
            // lblDescri��o
            // 
            this.lblDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescri��o.Location = new System.Drawing.Point(6, 23);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblDescri��o.Size = new System.Drawing.Size(230, 64);
            this.lblDescri��o.TabIndex = 2;
            this.lblDescri��o.Text = "Por favor, aguarde a carga dos dados.";
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT�tulo.Location = new System.Drawing.Point(6, 3);
            this.lblT�tulo.Name = "lblT�tulo";
            this.lblT�tulo.Size = new System.Drawing.Size(230, 20);
            this.lblT�tulo.TabIndex = 1;
            this.lblT�tulo.Text = "Carregando...";
            // 
            // Sinaliza��oCarga
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pic�cone);
            this.Name = "Sinaliza��oCarga";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(288, 96);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Sinaliza��oCarga_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao desenhar a sinaliza��o.
		/// </summary>
		private void Sinaliza��oCarga_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawRectangle(caneta, this.ClientRectangle);
		}

		/// <summary>
		/// T�tulo da sinaliza��o.
		/// </summary>
		public string T�tulo
		{
			get { return lblT�tulo.Text; }
			set { lblT�tulo.Text = value; }
		}

		/// <summary>
		/// Descri��o da sinaliza��o.
		/// </summary>
		public string Descri��o
		{
			get { return lblDescri��o.Text; }
			set 
            { 
                lblDescri��o.Text = value; 
            }
		}

        private delegate void AtribuirDescri��oDelegate(string descri��o);
        private void AtribuirDescri��o(string descri��o)
        {
            if (lblDescri��o.InvokeRequired)
            {
                AtribuirDescri��oDelegate m�todo = new AtribuirDescri��oDelegate(AtribuirDescri��o);
                lblDescri��o.BeginInvoke(m�todo, descri��o);
            } else
            {
                lblDescri��o.Text = descri��o;
            }
        }

        /// <summary>
        /// Imagem da sinaliza��o.
        /// </summary>
        public Image Imagem
        {
            get { return pic�cone.Image; }
            set
            {
                AtribuirImagem(value);
            }
        }

        private delegate void AtribuirImagemDelegate(Image imagem);
        private void AtribuirImagem(Image imagem)
        {
            if (pic�cone.InvokeRequired)
            {
                AtribuirImagemDelegate m�todo = new AtribuirImagemDelegate(AtribuirImagem);
                pic�cone.Invoke(m�todo, imagem);
            }
            else
            {
                pic�cone.Image = imagem;
            }
        }

        private delegate Sinaliza��oCarga SinalizarCallback(Control resid�ncia, string t�tulo, string descri��o, Image imagem);

        /// <summary>
        /// Introduz sinaliza��o de carga em um controle.
        /// </summary>
        /// <param name="resid�ncia">Controle onde ser� inserida a sinaliza��o de carga.</param>
        /// <param name="t�tulo">T�tulo da sinaliza��o.</param>
        /// <param name="descri��o">Descri��o da sinaliza��o.</param>
        public static Sinaliza��oCarga Sinalizar(Control resid�ncia, string t�tulo, string descri��o, MessageBoxIcon �cone)
        {
            Icon imagem;

            switch (�cone)
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

            return Sinalizar(resid�ncia, t�tulo, descri��o, imagem != null ? imagem.ToBitmap() : null);
        }

        /// <summary>
        /// Introduz sinaliza��o de carga em um controle.
        /// </summary>
        /// <param name="resid�ncia">Controle onde ser� inserida a sinaliza��o de carga.</param>
        /// <param name="t�tulo">T�tulo da sinaliza��o.</param>
        /// <param name="descri��o">Descri��o da sinaliza��o.</param>
        public static Sinaliza��oCarga Sinalizar(Control resid�ncia, string t�tulo, string descri��o)
        {
            return Sinalizar(resid�ncia, t�tulo, descri��o, null);
        }

        /// <summary>
        /// Introduz sinaliza��o de carga em um controle.
        /// </summary>
        /// <param name="resid�ncia">Controle onde ser� inserida a sinaliza��o de carga.</param>
        /// <param name="t�tulo">T�tulo da sinaliza��o.</param>
        /// <param name="descri��o">Descri��o da sinaliza��o.</param>
        public static Sinaliza��oCarga Sinalizar(Control resid�ncia, string t�tulo, string descri��o, Image imagem)
        {
            if (resid�ncia.InvokeRequired)
            {
                SinalizarCallback m�todo = new SinalizarCallback(Sinalizar);
                return (Sinaliza��oCarga) resid�ncia.Invoke(m�todo, resid�ncia, t�tulo, descri��o, imagem);
            }
            else
            {
                Sinaliza��oCarga sinaliza��o;

                if (imagem == null)
                    sinaliza��o = new Sinaliza��oCarga(t�tulo, descri��o);
                else
                    sinaliza��o = new Sinaliza��oCarga(t�tulo, descri��o, imagem);

                resid�ncia.SuspendLayout();
                resid�ncia.Controls.Add(sinaliza��o);

                if (resid�ncia.ClientSize.Width < sinaliza��o.Width)
                    sinaliza��o.Width = resid�ncia.ClientSize.Width * 8 / 10;

                sinaliza��o.Location = new Point(
                        (resid�ncia.ClientSize.Width - sinaliza��o.Width) / 2,
                        (resid�ncia.ClientSize.Height - sinaliza��o.Height) / 2);

                sinaliza��o.BringToFront();
                resid�ncia.ResumeLayout();
                sinaliza��o.Refresh();
                //Application.DoEvents();

                if (hashSinaliza��o.ContainsKey(resid�ncia))
                    Dessinalizar(resid�ncia);

                hashSinaliza��o.Add(resid�ncia, sinaliza��o);

                return sinaliza��o;
            }
        }

        private delegate void DessinalizarCallback(Sinaliza��oCarga sinaliza��o);

        /// <summary>
        /// Remove sinaliza��o de carga.
        /// </summary>
        /// <param name="sinaliza��o">Sinaliza��o de carga a ser removida.</param>
        public static void Dessinalizar(Sinaliza��oCarga sinaliza��o)
        {
            if (sinaliza��o.InvokeRequired)
            {
                DessinalizarCallback m�todo = new DessinalizarCallback(Dessinalizar);
                sinaliza��o.BeginInvoke(m�todo, sinaliza��o);
            }
            else
            {
                if (sinaliza��o.Parent != null)
                {
                    hashSinaliza��o.Remove(sinaliza��o.Parent);
                    sinaliza��o.Parent.Controls.Remove(sinaliza��o);
                }

                //sinaliza��o.Dispose();
                sinaliza��o.Descarregar();
            }
        }

        /// <summary>
        /// Remove sinaliza��o de carga.
        /// </summary>
        /// <param name="resid�ncia">Controle em que a sinaliza��o reside.</param>
        public static void Dessinalizar(Control resid�ncia)
        {
            try
            {
                Dessinalizar(hashSinaliza��o[resid�ncia]);
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
            if (pic�cone.InvokeRequired)
            {
                AtualizarVisibleDelegate m�todo = new AtualizarVisibleDelegate(AtualizarVisible);
                pic�cone.BeginInvoke(m�todo);
            }
            else
            {
                pic�cone.Visible = Width >= 160;
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
