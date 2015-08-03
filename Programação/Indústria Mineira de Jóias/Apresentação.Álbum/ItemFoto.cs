using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace Apresentação.Álbum
{
	/// <summary>
	/// ItemFoto é o item do controle ListaFoto.
	/// </summary>
	public class ItemFoto : System.Windows.Forms.UserControl, IComparable
	{
		// Constantes
		
		/// <summary>
		/// A miniatura é automaticamente perdida caso ela fique muito
		/// longe da area de visibilidade. Aqui você configura
		/// a quantos pixels de distância (fora da area de visão)
		/// para ela não descartar a miniatura. 
		/// 
		/// Portanto aqui se configura o máximo de memória alocada
		/// pelo programa.
		/// 
		/// Para diminuir a memoria alocada sem perder as miniaturas,
		/// uma opção é diminuir o tamanho da miniatura. Veja
		/// constante 'tamanhoMaiorLadoMiniatura' em Entidades.Álbum.Foto
		/// </summary>
		private const int máxPixelsProximidadePermanecerMiniatura = 40000;

		// Controles
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PictureBox picFoto;
		private System.Windows.Forms.Label lblReferência;
		//private System.Windows.Forms.Label lblDescrição;

		// Atributos
		private Entidades.Álbum.Foto entidade;
		private bool sendoMostradoNaTela = false;
		// Indica se está selecionado com o fundo azul, (modo teclado)
		private bool estouSelecionado = false; 
		
		// Eventos
		//public event EventHandler Selecionado;
		public event EventHandler Apareceu;
		public event EventHandler Escondeu;

		public Entidades.Álbum.Foto Entidade
		{
			get { return entidade; }
		}

		public ItemFoto(Entidades.Álbum.Foto entidade)
		{
			InitializeComponent();
			this.entidade = entidade;

			//picFoto.Image = entidade.Imagem;
			lblReferência.Text = entidade.ReferênciaFormatada;
			//lblDescrição.Text = entidade.Descrição;
		
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.StandardClick, true);

		}

		/// <summary>
		/// Define as cores do item
		/// </summary>
		internal void Selecionar()
		{
			lblReferência.ForeColor = Color.Red;
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
		/// É chamado pela ColeçãoItemFoto, assim que obtém esta miniatura.
		/// A entidade já deve conter a miniatura, caso contrário uma excessão é disparada.
		/// </remarks>
		public void MostrarMiniatura()
		{
#if DEBUG
			if (!entidade.MiniaturaObtida)
				throw new Exception("MostrarMiniatura irá obter ela própria a miniatura, porque não foi obtida anteriormente. É isso o que se deseja fazer ? A miniatura não deveria ter sido obtida anteriormente pela thread ?" );
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
			this.lblReferência = new System.Windows.Forms.Label();
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
			// lblReferência
			// 
			this.lblReferência.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblReferência.Location = new System.Drawing.Point(0, 77);
			this.lblReferência.Name = "lblReferência";
			this.lblReferência.Size = new System.Drawing.Size(152, 9);
			this.lblReferência.TabIndex = 1;
			this.lblReferência.Text = "Referência";
			this.lblReferência.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ItemFoto
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(235)), ((System.Byte)(235)), ((System.Byte)(218)));
			this.Controls.Add(this.lblReferência);
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
			return Entidade.ReferênciaNumérica.CompareTo(((ItemFoto) obj).Entidade.ReferênciaNumérica);
		}

		#endregion

		private void ItemFoto_LocationChanged(object sender, System.EventArgs e)
		{
			if ((this.Bounds.Location.Y < 0) ||
				(this.Bounds.Location.Y > this.Parent.Bounds.Height))
			{
				// O Item saíu da area de visibilidade
				if (sendoMostradoNaTela) 
				{
					sendoMostradoNaTela = false;
					Escondeu(this, null);
				}

				if ((this.Bounds.Location.Y < máxPixelsProximidadePermanecerMiniatura*-1) ||
					(this.Bounds.Location.Y > this.Parent.Bounds.Height + máxPixelsProximidadePermanecerMiniatura))
				{
					// Alem de estar fora da visibilidade,
					// Está fora da área permitida para armazenagem de miniaturas
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
			/* o apareceu() só deve ser chamado a partir do segundo Paint().
			 * Isso porquê o primeiro é chamado no inicio do programa, na posição (0,0)
			 * Como o programa interpreta o Apareceu() como o momento de solicitar a miniatura,
			 * então se utilizarmos o primeiro Paint(), todas as fotos vão ser solicitadas
			 * no início do programa!
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
			lblReferência.ForeColor = SystemColors.ActiveCaptionText;
			//lblSecundária.ForeColor = SystemColors.ActiveCaptionText;;
			//lblDescrição.ForeColor = SystemColors.ActiveCaptionText;
			this.BackColor = SystemColors.ActiveCaption;

			estouSelecionado = true;
		}
		/// <summary>
		/// Desseleciona item.
		/// </summary>
		internal void Desselecionar()
		{
			lblReferência.ForeColor = Color.Black;
			//lblSecundária.ForeColor = Color.Black;
			//lblDescrição.ForeColor = Color.Blue;
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
			lblReferência.Width = this.Width;
			CentralizarFoto();

//			picFoto.Left = 0;
//			picFoto.Height = this.Height - lblReferência.Height;
//			picFoto.Width = this.Width;
//			picFoto.Top = 0;
		}
		
		/// <summary>
		/// Centraliza o controle de acordo com suas dimensões
		/// </summary>
		/// <remarks>  É chamado pelo resize e também pelo MostrarMiniatura() </remarks>
		private void CentralizarFoto()
		{
			// Altura disponível para a foto, no itemFoto:
			int alturaDisponível = this.Height - lblReferência.Height;

			picFoto.Left = (this.Width / 2) - (picFoto.Width / 2);
			picFoto.Top = (alturaDisponível / 2) - (picFoto.Height / 2);
		}
		
		private void picFoto_Click(object sender, System.EventArgs e)
		{
			this.Focus();

			//this.OnGotFocus(e);
			//this.OnClick(e);
		}

	}
}
