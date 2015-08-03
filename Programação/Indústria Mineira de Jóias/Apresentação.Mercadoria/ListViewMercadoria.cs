using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Apresentação.Formulários.Consultas;
using Entidades;
using System.IO;
using System.Collections.Generic;
using Apresentação.Formulários;

namespace Apresentação.Mercadoria
{
	/// <summary>
	/// ListView de mercadorias
	/// </summary>
	public class ListViewMercadoria : System.Windows.Forms.UserControl
	{
		// Eventos
		public delegate void SeleçãoMercadoria(string referência);
		public event SeleçãoMercadoria AoSelecionarMercadoria;

		// Atributos
        private IList<Entidades.Mercadoria.Mercadoria> mercadorias;
        private RecuperaçãoÍcone recuperaçãoÍcone;

        ///// <summary>
        ///// Hash de mercadorias.
        ///// </summary>
        //private Hashtable hashMercadorias = new Hashtable();

		// Controle
		private System.Windows.Forms.ListView lst;
		private System.Windows.Forms.ImageList imagens;
		private System.Windows.Forms.ColumnHeader colReferência;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Constrói a list view
		/// </summary>
		public ListViewMercadoria()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            // Somente para Windows XP ou superior.
            if (System.Environment.OSVersion.Version.Major >= 5)
                recuperaçãoÍcone = new RecuperaçãoÍcone(this);
            else
                recuperaçãoÍcone = null;
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
            this.lst = new System.Windows.Forms.ListView();
            this.colReferência = new System.Windows.Forms.ColumnHeader();
            this.imagens = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReferência});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            this.lst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst.HideSelection = false;
            this.lst.LabelWrap = false;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(368, 200);
            this.lst.SmallImageList = this.imagens;
            this.lst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.Resize += new System.EventHandler(this.lst_Resize);
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // colReferência
            // 
            this.colReferência.Text = "Referência";
            // 
            // imagens
            // 
            this.imagens.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagens.ImageSize = new System.Drawing.Size(32, 32);
            this.imagens.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ListViewMercadoria
            // 
            this.Controls.Add(this.lst);
            this.Name = "ListViewMercadoria";
            this.Size = new System.Drawing.Size(368, 200);
            this.ResumeLayout(false);

		}
		#endregion

		private delegate void LimparCallback();

		/// <summary>
		/// Limpa a lista.
		/// </summary>
		private void Limpar()
		{
			lst.Items.Clear();
			imagens.Images.Clear();
            //hashMercadorias.Clear();
		}

        private delegate void MostrarCallback(IList<Entidades.Mercadoria.Mercadoria> mercadorias);

		/// <summary>
		/// Mostra dados na ListView
		/// </summary>
		public void Mostrar(IList<Entidades.Mercadoria.Mercadoria> mercadorias)
		{
            if (lst.InvokeRequired)
            {
                MostrarCallback método = new MostrarCallback(Mostrar);

                lst.BeginInvoke(método, mercadorias);
            }
            else
			    lock (lst)
			    {
				    // Limpar ítens
                    Limpar();

                    this.mercadorias = mercadorias;

                    for (int i = 0; i < mercadorias.Count; i++)
				    {
					    Entidades.Mercadoria.Mercadoria mercadoria = (Entidades.Mercadoria.Mercadoria) mercadorias[i];
                        lst.SuspendLayout();
                        lst.Visible = false;
					    AdicionarItem(mercadoria.Referência);
                        lst.Visible = true;
                        lst.ResumeLayout();
                        //hashMercadorias[mercadoria.Referência] = mercadorias[i];
				    }

                    if (mercadorias != null && mercadorias.Count > 0 && recuperaçãoÍcone != null)
                        recuperaçãoÍcone.IniciarTrabalho();
			    }
		}

		private delegate void AdicionarItemCallback(string referência);

		/// <summary>
		/// Adiciona item na lista de forma segura.
		/// </summary>
		/// <param name="referência">Referência a ser adicionada.</param>
		private void AdicionarItem(string referência)
		{
			if (lst.InvokeRequired)
			{
				AdicionarItemCallback método = new AdicionarItemCallback(AdicionarItem);

				lst.BeginInvoke(método, new object[] { referência });
			}
			else
			{
				lst.Items.Add(referência);
			}
		}

        private class RecuperaçãoÍcone : TrabalhoSegundoPlano
        {
            private ListViewMercadoria lst;

            public RecuperaçãoÍcone(ListViewMercadoria lst)
            {
                this.lst = lst;
            }

            protected override void RealizarTrabalho()
            {
                if (lst.mercadorias == null || lst.mercadorias.Count == 0)
                    return;

                //Entidades.Mercadoria.Mercadoria.ObterÍcones(lst.mercadorias);

                lst.MostrarÍconesSeguramente(lst.mercadorias);
            }
		}

		private delegate void MostrarÍconesSeguramenteCallback(IList<Entidades.Mercadoria.Mercadoria> mercadorias);

		/// <summary>
		/// Mostra os ícones seguramente em relação à thread.
		/// </summary>
		/// <param name="mercadorias">Lista de mercadorias já com ícones carregados.</param>
        private void MostrarÍconesSeguramente(IList<Entidades.Mercadoria.Mercadoria> mercadorias)
		{
			if (lst.InvokeRequired)
			{
				MostrarÍconesSeguramenteCallback método = new MostrarÍconesSeguramenteCallback(MostrarÍconesSeguramente);

				lst.BeginInvoke(método, new object[] { mercadorias });
			}
			else if (lst.Items.Count == mercadorias.Count)
			{
                int cnt = lst.Items.Count;

				try
				{
					for (int i = 0; i < cnt; i++)
					{
						Entidades.Mercadoria.Mercadoria mercadoria = mercadorias[i];


						Image ícone = mercadoria.Ícone;

						if (ícone != null)
						{
							imagens.Images.Add(ícone);

							/* Pode ocorre da lista mudar. Sendo este o caso,
							 * apenas ignorar.
							 */
							if (lst.Items[i].Text != mercadoria.Referência)
								break;

							lst.Items[i].ImageIndex = imagens.Images.Count - 1;
						}
					}
				}
				catch (Exception exceção)
				{
					Exception e = new Exception("Erro considerado e ignorado: a lista pode ter sido alterada por outra thread enquanto recuperava os ícones.\n\n" + exceção.Message, exceção);
#if DEBUG
					MessageBox.Show(e.ToString());
#endif
					Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
				}
			}
		}

		/// <summary>
		/// Ocorre quando altera-se o tamanho
		/// </summary>
		private void lst_Resize(object sender, System.EventArgs e)
		{
			colReferência.Width = lst.ClientSize.Width;
		}

		/// <summary>
		/// Ocorre quando altera-se a seleção
		/// </summary>
		private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
            Update();

			if (AoSelecionarMercadoria != null && lst.SelectedItems.Count == 1)
				AoSelecionarMercadoria(lst.SelectedItems[0].Text);
		}

		/// <summary>
		/// Seleciona próximo elemento
		/// </summary>
		public void SelecionarPróximo()
		{
			lock (lst)
			{
				if (lst.Items.Count > 0)
				{
					if (lst.SelectedIndices.Count == 0)
						lst.Items[0].Selected = true;
					else
					{
						int idx = lst.SelectedIndices[0] + 1;

						if (idx < lst.Items.Count)
						{
							lst.SelectedItems.Clear();
							lst.Items[idx].Selected = true;
							lst.Items[idx].EnsureVisible();
						} 
						else
						{
							/* caso em que só existe 1 elemento na lista
							* e já está selecionado. O evento de sua nova
							* seleção deve ser enviado. Isto é intuitivo.
							*/ 
							lst_SelectedIndexChanged(null, null);
						}
					}
				}
			}
		}

		/// <summary>
		/// Seleciona elemento anterior
		/// </summary>
		public void SelecionarAnterior()
		{
			lock (lst)
			{
				if (lst.Items.Count > 0)
				{
					if (lst.SelectedIndices.Count == 0)
						lst.Items[0].Selected = true;
					else
					{
						int idx = lst.SelectedIndices[0] - 1;

						if (idx >= 0)
						{
							lst.SelectedItems.Clear();
							lst.Items[idx].Selected = true;
							lst.Items[idx].EnsureVisible();
						}
					}
				}
			}
		}

		public ListView.ListViewItemCollection Items
		{
			get
			{
				return lst.Items;
			}
		}

        ///// <summary>
        ///// Obtém a mercadoria utilizada na lista.
        ///// </summary>
        ///// <param name="referência">Referência da mercadoria.</param>
        ///// <returns>
        ///// Mercadoria utilizada na lista ou null caso não
        ///// esteja em uso.
        ///// </returns>
        //public Entidades.Mercadoria.Mercadoria ObterMercadoriaLista(string referência)
        //{
        //    return hashMercadorias[referência] as Entidades.Mercadoria.Mercadoria;
        //}
	}
}
