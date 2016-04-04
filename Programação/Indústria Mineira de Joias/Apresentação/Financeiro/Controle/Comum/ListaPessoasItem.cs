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
	public class ListaPessoasItem : System.Windows.Forms.UserControl, IComparable
	{
		// Atributos
		protected System.Windows.Forms.PictureBox picFoto;
		protected System.Windows.Forms.Label lblDescrição;
		protected System.Windows.Forms.Label lblPrimária;
		protected System.Windows.Forms.Label lblSecundária;

		// Eventos
		public event EventHandler	Fechar;

        public string Primária { get { return lblPrimária.Text; } }
        public string Secundária { get { return lblSecundária.Text; } }

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Cosntrutor padrão
		/// </summary>
		public ListaPessoasItem()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			PrepararControle();
		}

		/// <summary>
		/// Construtor com texto pré-definido
		/// </summary>
		public ListaPessoasItem(string primária, string secundária, string descrição)
		{
			InitializeComponent();
			PrepararControle();

			lblPrimária.Text = primária;
			lblSecundária.Text = secundária;
			lblDescrição.Text = descrição;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPessoasItem));
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.lblPrimária = new System.Windows.Forms.Label();
            this.lblSecundária = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.Location = new System.Drawing.Point(8, 8);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(54, 72);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            this.picFoto.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.picFoto.MouseLeave += new System.EventHandler(this.ListaPessoasItem_MouseLeave);
            this.picFoto.Click += new System.EventHandler(this.ClickInterno);
            this.picFoto.MouseEnter += new System.EventHandler(this.ListaPessoasItem_MouseEnter);
            // 
            // lblPrimária
            // 
            this.lblPrimária.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrimária.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimária.ForeColor = System.Drawing.Color.Black;
            this.lblPrimária.Location = new System.Drawing.Point(72, 8);
            this.lblPrimária.Name = "lblPrimária";
            this.lblPrimária.Size = new System.Drawing.Size(224, 20);
            this.lblPrimária.TabIndex = 1;
            this.lblPrimária.Text = "?";
            this.lblPrimária.UseMnemonic = false;
            this.lblPrimária.MouseLeave += new System.EventHandler(this.ListaPessoasItem_MouseLeave);
            this.lblPrimária.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblPrimária.Click += new System.EventHandler(this.ClickInterno);
            this.lblPrimária.MouseEnter += new System.EventHandler(this.ListaPessoasItem_MouseEnter);
            // 
            // lblSecundária
            // 
            this.lblSecundária.Location = new System.Drawing.Point(72, 28);
            this.lblSecundária.Name = "lblSecundária";
            this.lblSecundária.Size = new System.Drawing.Size(232, 28);
            this.lblSecundária.TabIndex = 4;
            this.lblSecundária.Text = "?";
            this.lblSecundária.MouseLeave += new System.EventHandler(this.ListaPessoasItem_MouseLeave);
            this.lblSecundária.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblSecundária.Click += new System.EventHandler(this.ClickInterno);
            this.lblSecundária.MouseEnter += new System.EventHandler(this.ListaPessoasItem_MouseEnter);
            // 
            // lblDescrição
            // 
            this.lblDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrição.ForeColor = System.Drawing.Color.Blue;
            this.lblDescrição.Location = new System.Drawing.Point(72, 56);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(224, 32);
            this.lblDescrição.TabIndex = 3;
            this.lblDescrição.Text = "Vazio";
            this.lblDescrição.UseMnemonic = false;
            this.lblDescrição.MouseLeave += new System.EventHandler(this.ListaPessoasItem_MouseLeave);
            this.lblDescrição.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblDescrição.Click += new System.EventHandler(this.ClickInterno);
            this.lblDescrição.MouseEnter += new System.EventHandler(this.ListaPessoasItem_MouseEnter);
            // 
            // ListaPessoasItem
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(218)))));
            this.Controls.Add(this.lblDescrição);
            this.Controls.Add(this.lblSecundária);
            this.Controls.Add(this.lblPrimária);
            this.Controls.Add(this.picFoto);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ListaPessoasItem";
            this.Size = new System.Drawing.Size(304, 88);
            this.MouseLeave += new System.EventHandler(this.ListaPessoasItem_MouseLeave);
            this.MouseEnter += new System.EventHandler(this.ListaPessoasItem_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region IComparable Members

		public virtual int CompareTo(object obj)
		{
			return string.Compare(lblPrimária.Text, ((ListaPessoasItem) obj).lblPrimária.Text);
		}

		#endregion

		/// <summary>
		/// Ocorre ao retirar o mouse do item
		/// </summary>
		private void ListaPessoasItem_MouseLeave(object sender, System.EventArgs e)
		{
			if (!Focused)
				Desselecionar();
		}

		/// <summary>
		/// Ocorre ao posicionar o mouse sobre o item
		/// </summary>
		private void ListaPessoasItem_MouseEnter(object sender, System.EventArgs e)
		{
			if (!Focused)
				Selecionar();
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
			lblPrimária.ForeColor = Color.Red;
			lblSecundária.ForeColor = Color.Red;
			this.BackColor = Color.WhiteSmoke;
		}

		/// <summary>
		/// Seleciona item pelo teclado.
		/// </summary>
        protected internal virtual void SelecionarViaTeclado()
		{
			lblPrimária.ForeColor = SystemColors.ActiveCaptionText;
			lblSecundária.ForeColor = SystemColors.ActiveCaptionText;;
			lblDescrição.ForeColor = SystemColors.ActiveCaptionText;
			this.BackColor = SystemColors.ActiveCaption;
		}

		/// <summary>
		/// Desseleciona item.
		/// </summary>
		protected internal virtual void Desselecionar()
		{
			lblPrimária.ForeColor = Color.Black;
			lblSecundária.ForeColor = Color.Black;
			lblDescrição.ForeColor = Color.Blue;
			this.BackColor = Color.FromArgb(235, 235, 218);
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

		[Bindable(false)]
		public string Descrição
		{
			get { return lblDescrição.Text; }
			set { lblDescrição.Text = value; }
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
