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
		protected System.Windows.Forms.Panel picFoto;
		protected System.Windows.Forms.Label lblDescri��o;
		protected System.Windows.Forms.Label lblPrim�ria;
		protected System.Windows.Forms.Label lblSecund�ria;

		// Eventos
		public event EventHandler	Fechar;

        public string Prim�ria { get { return lblPrim�ria.Text; } }
        public string Secund�ria { get { return lblSecund�ria.Text; } }

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

			lblPrim�ria.Text = prim�ria;

			lblSecund�ria.Text = secund�ria;
			lblDescri��o.Text = descri��o;
            picFoto.BackgroundImage = �cone;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPessoasItemBusca));
            this.picFoto = new System.Windows.Forms.Panel();
            this.lblPrim�ria = new System.Windows.Forms.Label();
            this.lblSecund�ria = new System.Windows.Forms.Label();
            this.lblDescri��o = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picFoto.BackgroundImage")));
            this.picFoto.Location = new System.Drawing.Point(8, 8);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(54, 72);
            this.picFoto.TabIndex = 0;
            this.picFoto.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.picFoto.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.picFoto.Click += new System.EventHandler(this.ClickInterno);
            this.picFoto.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            // 
            // lblPrim�ria
            // 
            this.lblPrim�ria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrim�ria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrim�ria.ForeColor = System.Drawing.Color.Black;
            this.lblPrim�ria.Location = new System.Drawing.Point(72, 8);
            this.lblPrim�ria.Name = "lblPrim�ria";
            this.lblPrim�ria.Size = new System.Drawing.Size(232, 20);
            this.lblPrim�ria.TabIndex = 1;
            this.lblPrim�ria.Text = "?";
            this.lblPrim�ria.UseMnemonic = false;
            this.lblPrim�ria.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.lblPrim�ria.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblPrim�ria.Click += new System.EventHandler(this.ClickInterno);
            this.lblPrim�ria.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            // 
            // lblSecund�ria
            // 
            this.lblSecund�ria.Location = new System.Drawing.Point(72, 28);
            this.lblSecund�ria.Name = "lblSecund�ria";
            this.lblSecund�ria.Size = new System.Drawing.Size(232, 28);
            this.lblSecund�ria.TabIndex = 4;
            this.lblSecund�ria.Text = "?";
            this.lblSecund�ria.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.lblSecund�ria.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblSecund�ria.Click += new System.EventHandler(this.ClickInterno);
            this.lblSecund�ria.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescri��o.ForeColor = System.Drawing.Color.Blue;
            this.lblDescri��o.Location = new System.Drawing.Point(72, 56);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Size = new System.Drawing.Size(232, 32);
            this.lblDescri��o.TabIndex = 3;
            this.lblDescri��o.Text = "Vazio";
            this.lblDescri��o.UseMnemonic = false;
            this.lblDescri��o.MouseLeave += new System.EventHandler(this.ListaPessoasItemBusca_MouseLeave);
            this.lblDescri��o.DoubleClick += new System.EventHandler(this.DuploClickInterno);
            this.lblDescri��o.Click += new System.EventHandler(this.ClickInterno);
            this.lblDescri��o.MouseEnter += new System.EventHandler(this.ListaPessoasItemBusca_MouseEnter);
            // 
            // ListaPessoasItemBusca
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(218)))));
            this.Controls.Add(this.lblDescri��o);
            this.Controls.Add(this.lblSecund�ria);
            this.Controls.Add(this.lblPrim�ria);
            this.Controls.Add(this.picFoto);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ListaPessoasItemBusca";
            this.Size = new System.Drawing.Size(312, 88);
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
		}

		/// <summary>
		/// Seleciona item pelo teclado.
		/// </summary>
        protected internal virtual void SelecionarViaTeclado()
		{
            this.Select();
			lblPrim�ria.ForeColor = SystemColors.ActiveCaptionText;
			lblSecund�ria.ForeColor = SystemColors.ActiveCaptionText;;
			lblDescri��o.ForeColor = SystemColors.ActiveCaptionText;
			this.BackColor = SystemColors.ActiveCaption;
		}

		/// <summary>
		/// Desseleciona item.
		/// </summary>
		protected internal virtual void Desselecionar()
		{
			lblPrim�ria.ForeColor = Color.Black;
			lblSecund�ria.ForeColor = Color.Black;
			lblDescri��o.ForeColor = Color.Blue;
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
		public string Descri��o
		{
			get { return lblDescri��o.Text; }
			set { lblDescri��o.Text = value; }
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
