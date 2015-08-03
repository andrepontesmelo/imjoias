using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace Apresenta��o.�lbum
{
	/// <summary>
	/// ItemFoto � o item do controle ListaFoto.
	/// </summary>
	public class ItemFoto : System.Windows.Forms.UserControl, IComparable
	{
		// Constantes
		
		/// <summary>
		/// A miniatura � automaticamente perdida caso ela fique muito
		/// longe da area de visibilidade. Aqui voc� configura
		/// a quantos pixels de dist�ncia (fora da area de vis�o)
		/// para ela n�o descartar a miniatura. 
		/// 
		/// Portanto aqui se configura o m�ximo de mem�ria alocada
		/// pelo programa.
		/// 
		/// Para diminuir a memoria alocada sem perder as miniaturas,
		/// uma op��o � diminuir o tamanho da miniatura. Veja
		/// constante 'tamanhoMaiorLadoMiniatura' em Entidades.�lbum.Foto
		/// </summary>
		private const int m�xPixelsProximidadePermanecerMiniatura = 40000;

		// Controles
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PictureBox picFoto;
		private System.Windows.Forms.Label lblRefer�ncia;
		//private System.Windows.Forms.Label lblDescri��o;

		// Atributos
		private Entidades.�lbum.Foto entidade;
		private bool sendoMostradoNaTela = false;
		// Indica se est� selecionado com o fundo azul, (modo teclado)
		private bool estouSelecionado = false; 
		
		// Eventos
		//public event EventHandler Selecionado;
		public event EventHandler Apareceu;
		public event EventHandler Escondeu;

		public Entidades.�lbum.Foto Entidade
		{
			get { return entidade; }
		}

		public ItemFoto(Entidades.�lbum.Foto entidade)
		{
			InitializeComponent();
			this.entidade = entidade;

			//picFoto.Image = entidade.Imagem;
			lblRefer�ncia.Text = entidade.Refer�nciaFormatada;
			//lblDescri��o.Text = entidade.Descri��o;
		
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.StandardClick, true);

		}

		/// <summary>
		/// Define as cores do item
		/// </summary>
		internal void Selecionar()
		{
			lblRefer�ncia.ForeColor = Color.Red;
			this.BackColor = Color.WhiteSmoke;

			//Selecionado(this, null);
		}


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

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// � chamado pela Cole��oItemFoto, assim que obt�m esta miniatura.
		/// A entidade j� deve conter a miniatura, caso contr�rio uma excess�o � disparada.
		/// </remarks>
		public void MostrarMiniatura()
		{
#if DEBUG
			if (!entidade.MiniaturaObtida)
				throw new Exception("MostrarMiniatura ir� obter ela pr�pria a miniatura, porque n�o foi obtida anteriormente. � isso o que se deseja fazer ? A miniatura n�o deveria ter sido obtida anteriormente pela thread ?" );
#endif
			Image miniatura = entidade.Miniatura.Imagem;
			this.picFoto.Width = miniatura.Width;
			this.picFoto.Height = miniatura.Height;
			this.picFoto.Image = miniatura;
			
			CentralizarFoto();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.picFoto = new System.Windows.Forms.PictureBox();
			this.lblRefer�ncia = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// picFoto
			// 
			this.picFoto.Location = new System.Drawing.Point(24, 0);
			this.picFoto.Name = "picFoto";
			this.picFoto.Size = new System.Drawing.Size(80, 70);
			this.picFoto.TabIndex = 0;
			this.picFoto.TabStop = false;
			this.picFoto.Click += new System.EventHandler(this.picFoto_Click);
			this.picFoto.MouseEnter += new System.EventHandler(this.ItemFoto_MouseEnter);
			// 
			// lblRefer�ncia
			// 
			this.lblRefer�ncia.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRefer�ncia.Location = new System.Drawing.Point(0, 77);
			this.lblRefer�ncia.Name = "lblRefer�ncia";
			this.lblRefer�ncia.Size = new System.Drawing.Size(152, 9);
			this.lblRefer�ncia.TabIndex = 1;
			this.lblRefer�ncia.Text = "Refer�ncia";
			this.lblRefer�ncia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ItemFoto
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(235)), ((System.Byte)(235)), ((System.Byte)(218)));
			this.Controls.Add(this.lblRefer�ncia);
			this.Controls.Add(this.picFoto);
			this.Name = "ItemFoto";
			this.Size = new System.Drawing.Size(136, 84);
			this.LocationChanged += new System.EventHandler(this.ItemFoto_LocationChanged);
			this.Resize += new System.EventHandler(this.ItemFoto_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ItemFoto_Paint);
			this.MouseEnter += new System.EventHandler(this.ItemFoto_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.ItemFoto_MouseLeave);
			this.ResumeLayout(false);

		}
		#endregion

		#region IComparable Members

		public int CompareTo(object obj)
		{
			return Entidade.Refer�nciaNum�rica.CompareTo(((ItemFoto) obj).Entidade.Refer�nciaNum�rica);
		}

		#endregion

		private void ItemFoto_LocationChanged(object sender, System.EventArgs e)
		{
			if ((this.Bounds.Location.Y < 0) ||
				(this.Bounds.Location.Y > this.Parent.Bounds.Height))
			{
				// O Item sa�u da area de visibilidade
				if (sendoMostradoNaTela) 
				{
					sendoMostradoNaTela = false;
					Escondeu(this, null);
				}

				if ((this.Bounds.Location.Y < m�xPixelsProximidadePermanecerMiniatura*-1) ||
					(this.Bounds.Location.Y > this.Parent.Bounds.Height + m�xPixelsProximidadePermanecerMiniatura))
				{
					// Alem de estar fora da visibilidade,
					// Est� fora da �rea permitida para armazenagem de miniaturas
					DisposarMiniatura();
				}
			}
		}
		public void DisposarMiniatura()
		{
			this.picFoto.Image = null;
			entidade.DisposarMiniatura();
		}

		private bool primeiroPaint = true;
		private void ItemFoto_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			/* o apareceu() s� deve ser chamado a partir do segundo Paint().
			 * Isso porqu� o primeiro � chamado no inicio do programa, na posi��o (0,0)
			 * Como o programa interpreta o Apareceu() como o momento de solicitar a miniatura,
			 * ent�o se utilizarmos o primeiro Paint(), todas as fotos v�o ser solicitadas
			 * no in�cio do programa!
			 */

			if (primeiroPaint)
				primeiroPaint = false;
			else
				Apareceu(this, new EventArgs());
		}

		private void ItemFoto_MouseEnter(object sender, System.EventArgs e)
		{
			if (!estouSelecionado)
				Selecionar();
		}

		private void ItemFoto_MouseLeave(object sender, System.EventArgs e)
		{
			if (Focused)
				SelecionarViaTeclado();
			else
				Desselecionar();
		}

		/// <summary>
		/// Muda as cores do item
		/// </summary>
		internal void SelecionarViaTeclado()
		{
			lblRefer�ncia.ForeColor = SystemColors.ActiveCaptionText;
			//lblSecund�ria.ForeColor = SystemColors.ActiveCaptionText;;
			//lblDescri��o.ForeColor = SystemColors.ActiveCaptionText;
			this.BackColor = SystemColors.ActiveCaption;

			estouSelecionado = true;
		}
		/// <summary>
		/// Desseleciona item.
		/// </summary>
		internal void Desselecionar()
		{
			lblRefer�ncia.ForeColor = Color.Black;
			//lblSecund�ria.ForeColor = Color.Black;
			//lblDescri��o.ForeColor = Color.Blue;
			this.BackColor = Color.FromArgb(235, 235, 218);

			estouSelecionado = false;
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

		private void ItemFoto_Resize(object sender, System.EventArgs e)
		{
			lblRefer�ncia.Width = this.Width;
			CentralizarFoto();

//			picFoto.Left = 0;
//			picFoto.Height = this.Height - lblRefer�ncia.Height;
//			picFoto.Width = this.Width;
//			picFoto.Top = 0;
		}
		
		/// <summary>
		/// Centraliza o controle de acordo com suas dimens�es
		/// </summary>
		/// <remarks>  � chamado pelo resize e tamb�m pelo MostrarMiniatura() </remarks>
		private void CentralizarFoto()
		{
			// Altura dispon�vel para a foto, no itemFoto:
			int alturaDispon�vel = this.Height - lblRefer�ncia.Height;

			picFoto.Left = (this.Width / 2) - (picFoto.Width / 2);
			picFoto.Top = (alturaDispon�vel / 2) - (picFoto.Height / 2);
		}
		
		private void picFoto_Click(object sender, System.EventArgs e)
		{
			this.Focus();

			//this.OnGotFocus(e);
			//this.OnClick(e);
		}

	}
}
