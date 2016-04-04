using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresenta��o.Atendimento.Comum
{
	/// <summary>
	/// Item que ser� incluso a uma lista de clientes
	/// </summary>
	[Serializable]
	public class ListaPessoasItemBusca : System.Windows.Forms.UserControl, IComparable
	{
        // Atributos
		protected System.Windows.Forms.Label lblPrim�ria;
		protected System.Windows.Forms.Label lblSecund�ria;
        protected Label lblMeio;
        protected Panel pnl�cone;


		// Eventos
		public event EventHandler	Fechar;

        public string Prim�ria 
        { 
            get { return lblPrim�ria.Text; }

            set
            {
                Graphics graphics = lblPrim�ria.CreateGraphics();
                SizeF textSize = graphics.MeasureString(value, lblPrim�ria.Font);

                while (textSize.Width >= lblPrim�ria.Width * 2 && lblPrim�ria.Font.Size >= 6)
                {
                    lblPrim�ria.Font = new Font(lblPrim�ria.Font.FontFamily, lblPrim�ria.Font.Size - 2, FontStyle.Bold);
                    textSize = graphics.MeasureString(value, lblPrim�ria.Font);
                }

                lblPrim�ria.Text = value;
            }

        }
        public string Secund�ria 
        { 
            get 
            { return lblSecund�ria.Text; }

            set
            {
                Graphics graphics = lblSecund�ria.CreateGraphics();
                SizeF textSize = graphics.MeasureString(value, lblSecund�ria.Font);

                while (textSize.Width >= lblSecund�ria.Width && lblSecund�ria.Font.Size > 7)
                {
                    lblSecund�ria.Font = new Font(lblSecund�ria.Font.FontFamily, lblSecund�ria.Font.Size - 1);
                    textSize = graphics.MeasureString(value, lblSecund�ria.Font);
                }

                lblSecund�ria.Text = value;
            }
        }

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Cosntrutor padr�o
		/// </summary>
		public ListaPessoasItemBusca()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			PrepararControle();
		}

		/// <summary>
		/// Construtor com texto pr�-definido
		/// </summary>
		public ListaPessoasItemBusca(string prim�ria, string secund�ria, string descri��o, Image �cone)
		{
			InitializeComponent();
			PrepararControle();

            Prim�ria = prim�ria;
			Secund�ria = secund�ria;

            pnl�cone.BackgroundImage = �cone;
		}

		/// <summary>
		/// Prepara controle
		/// </summary>
		/// <remarks>
		/// M�todo chamado pelas construtoras.
		/// </remarks>
		private void PrepararControle()
		{
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.StandardClick, true);
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
            this.lblPrim�ria = new System.Windows.Forms.Label();
            this.lblSecund�ria = new System.Windows.Forms.Label();
            this.lblMeio = new System.Windows.Forms.Label();
            this.pnl�cone = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblPrim�ria
            // 
            this.lblPrim�ria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrim�ria.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrim�ria.ForeColor = System.Drawing.Color.Black;
            this.lblPrim�ria.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblPrim�ria.Location = new System.Drawing.Point(61, 3);
            this.lblPrim�ria.Name = "lblPrim�ria";
            this.lblPrim�ria.Size = new System.Drawing.Size(144, 36);
            this.lblPrim�ria.TabIndex = 1;
            this.lblPrim�ria.Text = "Maria Concei��o Silvana Enfim Um Nome Muito Grande Almeida Albuquerque";
            this.lblPrim�ria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrim�ria.UseMnemonic = false;
            this.lblPrim�ria.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.lblPrim�ria.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblPrim�ria.Click += new System.EventHandler(this.ClickInterno);
            this.lblPrim�ria.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            // 
            // lblSecund�ria
            // 
            this.lblSecund�ria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSecund�ria.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecund�ria.ForeColor = System.Drawing.Color.Black;
            this.lblSecund�ria.Location = new System.Drawing.Point(62, 48);
            this.lblSecund�ria.Name = "lblSecund�ria";
            this.lblSecund�ria.Size = new System.Drawing.Size(143, 19);
            this.lblSecund�ria.TabIndex = 4;
            this.lblSecund�ria.Text = "Belo Horizonte - MG";
            this.lblSecund�ria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSecund�ria.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.lblSecund�ria.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblSecund�ria.Click += new System.EventHandler(this.ClickInterno);
            this.lblSecund�ria.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            // 
            // lblMeio
            // 
            this.lblMeio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMeio.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeio.ForeColor = System.Drawing.Color.Gray;
            this.lblMeio.Location = new System.Drawing.Point(59, 38);
            this.lblMeio.Name = "lblMeio";
            this.lblMeio.Size = new System.Drawing.Size(146, 15);
            this.lblMeio.TabIndex = 5;
            this.lblMeio.Text = "Regi�o 812";
            this.lblMeio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl�cone
            // 
            this.pnl�cone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnl�cone.Location = new System.Drawing.Point(-1, -1);
            this.pnl�cone.Name = "pnl�cone";
            this.pnl�cone.Size = new System.Drawing.Size(57, 68);
            this.pnl�cone.TabIndex = 6;
            // 
            // ListaPessoasItemBusca
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.lblMeio);
            this.Controls.Add(this.lblSecund�ria);
            this.Controls.Add(this.lblPrim�ria);
            this.Controls.Add(this.pnl�cone);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ListaPessoasItemBusca";
            this.Size = new System.Drawing.Size(208, 64);
            this.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            this.ResumeLayout(false);

		}
		#endregion

		#region IComparable Members

		public virtual int CompareTo(object obj)
		{
			return string.Compare(lblPrim�ria.Text, ((ListaPessoasItemBusca) obj).lblPrim�ria.Text);
		}

		#endregion

		/// <summary>
		/// Ocorre ao retirar o mouse do item
		/// </summary>
		private void ListaPessoasItemBusca_MouseLeave(object sender, System.EventArgs e)
		{
			if (!Focused)
				Desselecionar();
		}

		/// <summary>
		/// Ocorre ao posicionar o mouse sobre o item
		/// </summary>
		private void ListaPessoasItemBusca_MouseEnter(object sender, System.EventArgs e)
		{
			if (!Focused)
				Selecionar();

            // Manda o foco para o pai poder dar scroll com a roda do mouse
            if (Parent != null)
                Parent.Focus();
		}

		/// <summary>
		/// Ocorre ao clicar no item.
		/// </summary>
		private void ClickInterno(object sender, System.EventArgs e)
		{
			this.Focus();

			this.OnClick(e);
		}

		/// <summary>
		/// Ocorre ao clicar duas vezes no item.
		/// </summary>
		private void DuploClickInterno(object sender, System.EventArgs e)
		{
			this.Focus();

			this.OnDoubleClick(e);
		}

		/// <summary>
		/// Seleciona item.
		/// </summary>
        protected internal virtual void Selecionar()
		{
			lblPrim�ria.ForeColor = Color.Red;
			lblSecund�ria.ForeColor = Color.Red;
			this.BackColor = Color.WhiteSmoke;

            this.BorderStyle = BorderStyle.FixedSingle;
		}

		/// <summary>
		/// Seleciona item pelo teclado.
		/// </summary>
        protected internal virtual void SelecionarViaTeclado()
		{
            this.Select();
			lblPrim�ria.ForeColor = SystemColors.ActiveCaptionText;
			lblSecund�ria.ForeColor = SystemColors.ActiveCaptionText;;
			this.BackColor = SystemColors.ActiveCaption;
		}

		/// <summary>
		/// Desseleciona item.
		/// </summary>
		protected internal virtual void Desselecionar()
		{
			lblPrim�ria.ForeColor = Color.Black;
			lblSecund�ria.ForeColor = Color.Black;
			this.BackColor = Color.FromArgb(224, 224, 224);

            this.BorderStyle = BorderStyle.None;
		}

		/// <summary>
		/// Ocorre ao ganhar foco.
		/// </summary>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);

			SelecionarViaTeclado();
		}

		/// <summary>
		/// Ocorre ao perder o foco.
		/// </summary>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);

			Desselecionar();
		}

		/// <summary>
		/// Ocorre ao pressionar alguma tecla.
		/// </summary>
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp (e);

			if (e.KeyCode == Keys.Enter)
				this.OnClick(new EventArgs());
		}

		/// <summary>
		/// Dispara evento de fechar.
		/// </summary>
		protected virtual void DispararFechar()
		{
			if (Fechar != null)
				Fechar(this, new EventArgs());
		}
	}
}
