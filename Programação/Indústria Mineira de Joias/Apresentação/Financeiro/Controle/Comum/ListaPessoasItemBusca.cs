using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresentação.Atendimento.Comum
{
	/// <summary>
	/// Item que será incluso a uma lista de clientes
	/// </summary>
	[Serializable]
	public class ListaPessoasItemBusca : System.Windows.Forms.UserControl, IComparable
	{
        // Atributos
        protected System.Windows.Forms.Label lblPrimária;
		protected System.Windows.Forms.Label lblSecundária;
        protected Label lblMeio;
        protected Panel pnlÍcone;

        private const int TAMANHO_MÁXIMO_PRIMÁRIO = 80;

		// Eventos
		public event EventHandler	Fechar;

        protected void AlterarTextoFonte(Label label, string texto)
        {
            AlterarTextoFonte(label, texto, texto.Length);
        }

        protected void AlterarTextoFonte(Label label, string texto, int máximoCaracteresTexto)
        {
            if (texto.Length > máximoCaracteresTexto)
                texto = texto.Substring(0, máximoCaracteresTexto - 4) + " ...";

            label.SuspendLayout();
            label.Text = texto;
            AjustarTamanhoFonte(label);
            label.ResumeLayout();
        }

        private void AjustarTamanhoFonte(Label label)
        {
            Graphics graphics = label.CreateGraphics();
            SizeF textSize = graphics.MeasureString(label.Text, label.Font);

            float falta = textSize.Width + 100 - label.Width;
            if (falta > 0)
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - Math.Abs(falta) / 200, FontStyle.Bold);
        }

        public string Primária 
        { 
            get { return lblPrimária.Text; }
            set { AlterarTextoFonte(lblPrimária, value, TAMANHO_MÁXIMO_PRIMÁRIO); }
        }

        public string Secundária 
        { 
            get { return lblSecundária.Text; }
            set { AlterarTextoFonte(lblSecundária, value); }
        }

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Cosntrutor padrão
		/// </summary>
		public ListaPessoasItemBusca()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			PrepararControle();
		}

		/// <summary>
		/// Construtor com texto pré-definido
		/// </summary>
		public ListaPessoasItemBusca(string primária, string secundária, string descrição, Image ícone)
		{
			InitializeComponent();
			PrepararControle();

            Primária = primária;
			Secundária = secundária;

            pnlÍcone.BackgroundImage = ícone;
		}

		/// <summary>
		/// Prepara controle
		/// </summary>
		/// <remarks>
		/// Método chamado pelas construtoras.
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
            this.lblPrimária = new System.Windows.Forms.Label();
            this.lblSecundária = new System.Windows.Forms.Label();
            this.lblMeio = new System.Windows.Forms.Label();
            this.pnlÍcone = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblPrimária
            // 
            this.lblPrimária.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrimária.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimária.ForeColor = System.Drawing.Color.Black;
            this.lblPrimária.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblPrimária.Location = new System.Drawing.Point(61, 3);
            this.lblPrimária.Name = "lblPrimária";
            this.lblPrimária.Size = new System.Drawing.Size(144, 36);
            this.lblPrimária.TabIndex = 1;
            this.lblPrimária.Text = "Maria Conceição Silvana Enfim Um Nome Muito Grande Almeida Albuquerque";
            this.lblPrimária.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrimária.UseMnemonic = false;
            this.lblPrimária.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.lblPrimária.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblPrimária.Click += new System.EventHandler(this.ClickInterno);
            this.lblPrimária.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            // 
            // lblSecundária
            // 
            this.lblSecundária.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSecundária.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecundária.ForeColor = System.Drawing.Color.Black;
            this.lblSecundária.Location = new System.Drawing.Point(62, 48);
            this.lblSecundária.Name = "lblSecundária";
            this.lblSecundária.Size = new System.Drawing.Size(143, 19);
            this.lblSecundária.TabIndex = 4;
            this.lblSecundária.Text = "Belo Horizonte - MG";
            this.lblSecundária.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSecundária.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.lblSecundária.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblSecundária.Click += new System.EventHandler(this.ClickInterno);
            this.lblSecundária.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
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
            this.lblMeio.Text = "Região 812";
            this.lblMeio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlÍcone
            // 
            this.pnlÍcone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlÍcone.Location = new System.Drawing.Point(-1, -1);
            this.pnlÍcone.Name = "pnlÍcone";
            this.pnlÍcone.Size = new System.Drawing.Size(57, 68);
            this.pnlÍcone.TabIndex = 6;
            // 
            // ListaPessoasItemBusca
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.lblMeio);
            this.Controls.Add(this.lblSecundária);
            this.Controls.Add(this.lblPrimária);
            this.Controls.Add(this.pnlÍcone);
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
			return string.Compare(lblPrimária.Text, ((ListaPessoasItemBusca) obj).lblPrimária.Text);
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
			this.BackColor = Color.WhiteSmoke;
            //this.lblPrimária.Font = new Font(lblPrimária.Font, FontStyle.Bold | FontStyle.Underline);
            this.BorderStyle = BorderStyle.FixedSingle;
		}

		/// <summary>
		/// Seleciona item pelo teclado.
		/// </summary>
        protected internal virtual void SelecionarViaTeclado()
		{
            this.Select();
			lblPrimária.ForeColor = SystemColors.ActiveCaptionText;
			lblSecundária.ForeColor = SystemColors.ActiveCaptionText;;
			this.BackColor = SystemColors.ActiveCaption;
		}

		/// <summary>
		/// Desseleciona item.
		/// </summary>
		protected internal virtual void Desselecionar()
		{
			this.BackColor = Color.FromArgb(224, 224, 224);
            this.BorderStyle = BorderStyle.None;
            //this.lblPrimária.Font = new Font(lblPrimária.Font, FontStyle.Bold);
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
