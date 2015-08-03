using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria 
{
	public class Bandeja : System.Windows.Forms.UserControl
	{
		#region declara��o objetos do controle (listview, menuItems, bot�es...)
		private System.Windows.Forms.ListView lista;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.StatusBar status;
		private System.Windows.Forms.ToolBar barraFerramentas;
		private System.Windows.Forms.LinkLabel mudarVizualiza��oLnk;
		private System.Windows.Forms.ContextMenu menuExibi��o;
		private System.Windows.Forms.ImageList imagensGrandes;
		private System.Windows.Forms.ImageList imagensPequenas;
#endregion
		
		//Eventos:
		public event EventHandler eventoMenuIconesGrandes, eventoMenuDetalhes;

		//Variaveis Locais:
		private ArrayList saquinhos = new ArrayList();

		#region tipo
		/* O tipo serve para diferenciar as informa��es contidas na bandeja.
		 * Dependendo de onde o controle � colocado, as colunas do listview s�o diferentes.
		 * Por isso, � importante, ao usar o controle, defir seu tipo.
		 */ 
		public enum TipoDeBandeja {Etiquetas };
		private TipoDeBandeja tipo;
		
		public TipoDeBandeja Tipo
		{
			set
			{
				tipo = value;
				limparLista();
			}
		}
#endregion
			
		public Bandeja()
		{
			InitializeComponent();
		
			#region eventos para o menu
			eventoMenuDetalhes += new EventHandler(Bandeja_eventoMenuDetalhes);
			eventoMenuIconesGrandes += new EventHandler(Bandeja_eventoMenuIconesGrandes);
			#endregion eventos para o menu

			menuExibi��o.MenuItems.Add("Icones Grandes", eventoMenuIconesGrandes);
			menuExibi��o.MenuItems.Add("Tabela", eventoMenuDetalhes);

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

		public void AdicionarMercadoria(Entidades.Saquinho saquinho)
		{
			Image foto = saquinho.Mercadoria.�cone;
			int itemIncluso = lista.Items.Count;
			
			if (foto != null)
			{
				imagensGrandes.Images.Add(foto);
				imagensPequenas.Images.Add(foto);
				lista.Items.Add(saquinho.Mercadoria.Refer�ncia,itemIncluso);
			} 
			else
			{
				lista.Items.Add(saquinho.Mercadoria.Refer�ncia);
			}
			switch (tipo)
			{
				case TipoDeBandeja.Etiquetas:
					//Referencia;Quantidade;Formato;Peso;Indice;Faixa;Grupo
					lista.Items[itemIncluso].SubItems.Add(saquinho.Quantidade.ToString());
					lista.Items[itemIncluso].SubItems.Add(saquinho.Mercadoria.Peso.ToString());
					lista.Items[itemIncluso].SubItems.Add(saquinho.Mercadoria.�ndice.ToString());
					lista.Items[itemIncluso].SubItems.Add(saquinho.Mercadoria.Faixa.ToString());
					break;
			}

		}
		
		
		/// <summary>
		/// Apenas limpa os elementos.
		/// </summary>
		public void limparLista()
		{
			lista.Items.Clear();
			imagensGrandes.Images.Clear();
			imagensPequenas.Images.Clear();
			saquinhos.Clear();
		}
		
		
		/// <summary>
		/// Apenas cria as colunas com o tipo espec�fico. N�o limpa.
		/// </summary>
		public void criarColunas()
		{
			if (tipo == TipoDeBandeja.Etiquetas)
			{
				//Referencia, Quantidade, Formato, Peso, Indice, Faixa , Grupo
				lista.Columns.Add("Refer�ncia",30,System.Windows.Forms.HorizontalAlignment.Left);
				lista.Columns.Add("Quantidade",90,System.Windows.Forms.HorizontalAlignment.Center);
				lista.Columns.Add("Formato",90,System.Windows.Forms.HorizontalAlignment.Center);
				lista.Columns.Add("Peso",90,System.Windows.Forms.HorizontalAlignment.Center);
				lista.Columns.Add("�ndice",90,System.Windows.Forms.HorizontalAlignment.Center);
				lista.Columns.Add("Faixa",90,System.Windows.Forms.HorizontalAlignment.Center);
				lista.Columns.Add("Grupo",90,System.Windows.Forms.HorizontalAlignment.Center);
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lista = new System.Windows.Forms.ListView();
			this.imagensGrandes = new System.Windows.Forms.ImageList(this.components);
			this.imagensPequenas = new System.Windows.Forms.ImageList(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.status = new System.Windows.Forms.StatusBar();
			this.barraFerramentas = new System.Windows.Forms.ToolBar();
			this.mudarVizualiza��oLnk = new System.Windows.Forms.LinkLabel();
			this.menuExibi��o = new System.Windows.Forms.ContextMenu();
			this.SuspendLayout();
			// 
			// lista
			// 
			this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lista.BackColor = System.Drawing.Color.White;
			this.lista.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lista.FullRowSelect = true;
			this.lista.HideSelection = false;
			this.lista.LabelWrap = false;
			this.lista.LargeImageList = this.imagensGrandes;
			this.lista.Location = new System.Drawing.Point(0, 48);
			this.lista.Name = "lista";
			this.lista.Size = new System.Drawing.Size(352, 280);
			this.lista.SmallImageList = this.imagensPequenas;
			this.lista.TabIndex = 1;
			this.lista.View = System.Windows.Forms.View.Details;
			// 
			// imagensGrandes
			// 
			this.imagensGrandes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imagensGrandes.ImageSize = new System.Drawing.Size(32, 32);
			this.imagensGrandes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imagensPequenas
			// 
			this.imagensPequenas.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.imagensPequenas.ImageSize = new System.Drawing.Size(20, 20);
			this.imagensPequenas.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem2});
			this.menuItem1.Text = "";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "";
			// 
			// status
			// 
			this.status.Location = new System.Drawing.Point(0, 328);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(352, 24);
			this.status.TabIndex = 3;
			// 
			// barraFerramentas
			// 
			this.barraFerramentas.DropDownArrows = true;
			this.barraFerramentas.Location = new System.Drawing.Point(0, 0);
			this.barraFerramentas.Name = "barraFerramentas";
			this.barraFerramentas.ShowToolTips = true;
			this.barraFerramentas.Size = new System.Drawing.Size(352, 42);
			this.barraFerramentas.TabIndex = 4;
			// 
			// mudarVizualiza��oLnk
			// 
			this.mudarVizualiza��oLnk.BackColor = System.Drawing.SystemColors.Control;
			this.mudarVizualiza��oLnk.DisabledLinkColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.mudarVizualiza��oLnk.Location = new System.Drawing.Point(8, 16);
			this.mudarVizualiza��oLnk.Name = "mudarVizualiza��oLnk";
			this.mudarVizualiza��oLnk.Size = new System.Drawing.Size(72, 16);
			this.mudarVizualiza��oLnk.TabIndex = 7;
			this.mudarVizualiza��oLnk.TabStop = true;
			this.mudarVizualiza��oLnk.Text = "Vizualiza��o";
			this.mudarVizualiza��oLnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mudarVizualiza��oLnk_LinkClicked);
			// 
			// Bandeja
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.mudarVizualiza��oLnk);
			this.Controls.Add(this.barraFerramentas);
			this.Controls.Add(this.status);
			this.Controls.Add(this.lista);
			this.Name = "Bandeja";
			this.Size = new System.Drawing.Size(352, 352);
			this.ResumeLayout(false);

		}
		#endregion

	
		#region eventos associados ao modo de exibi��o (icones grandes, detalhes...)

		private void mudarVizualiza��oLnk_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//menuExibi��o.Show(this,new Point(MousePosition.X - this.Left,MousePosition.Y  - this.Top - 110));
			menuExibi��o.Show(this, mudarVizualiza��oLnk.Location);

		}

		private void Bandeja_eventoMenuDetalhes(object sender, EventArgs e)
		{
			lista.View = View.Details;
		}

		private void Bandeja_eventoMenuIconesGrandes(object sender, EventArgs e)
		{
			lista.View = View.LargeIcon;
		}
		#endregion modo de exibi��o (icones grandes, detalhes...)

	}
}
