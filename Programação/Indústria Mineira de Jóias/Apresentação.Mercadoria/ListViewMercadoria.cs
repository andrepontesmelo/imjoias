using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Apresenta��o.Formul�rios.Consultas;
using Entidades;
using System.IO;
using System.Collections.Generic;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Mercadoria
{
	/// <summary>
	/// ListView de mercadorias
	/// </summary>
	public class ListViewMercadoria : System.Windows.Forms.UserControl
	{
		// Eventos
		public delegate void Sele��oMercadoria(string refer�ncia);
		public event Sele��oMercadoria AoSelecionarMercadoria;

		// Atributos
        private IList<Entidades.Mercadoria.Mercadoria> mercadorias;
        private Recupera��o�cone recupera��o�cone;

        ///// <summary>
        ///// Hash de mercadorias.
        ///// </summary>
        //private Hashtable hashMercadorias = new Hashtable();

		// Controle
		private System.Windows.Forms.ListView lst;
		private System.Windows.Forms.ImageList imagens;
		private System.Windows.Forms.ColumnHeader colRefer�ncia;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Constr�i a list view
		/// </summary>
		public ListViewMercadoria()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            // Somente para Windows XP ou superior.
            if (System.Environment.OSVersion.Version.Major >= 5)
                recupera��o�cone = new Recupera��o�cone(this);
            else
                recupera��o�cone = null;
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
            this.colRefer�ncia = new System.Windows.Forms.ColumnHeader();
            this.imagens = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRefer�ncia});
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
            // colRefer�ncia
            // 
            this.colRefer�ncia.Text = "Refer�ncia";
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
                MostrarCallback m�todo = new MostrarCallback(Mostrar);

                lst.BeginInvoke(m�todo, mercadorias);
            }
            else
			    lock (lst)
			    {
				    // Limpar �tens
                    Limpar();

                    this.mercadorias = mercadorias;

                    for (int i = 0; i < mercadorias.Count; i++)
				    {
					    Entidades.Mercadoria.Mercadoria mercadoria = (Entidades.Mercadoria.Mercadoria) mercadorias[i];
                        lst.SuspendLayout();
                        lst.Visible = false;
					    AdicionarItem(mercadoria.Refer�ncia);
                        lst.Visible = true;
                        lst.ResumeLayout();
                        //hashMercadorias[mercadoria.Refer�ncia] = mercadorias[i];
				    }

                    if (mercadorias != null && mercadorias.Count > 0 && recupera��o�cone != null)
                        recupera��o�cone.IniciarTrabalho();
			    }
		}

		private delegate void AdicionarItemCallback(string refer�ncia);

		/// <summary>
		/// Adiciona item na lista de forma segura.
		/// </summary>
		/// <param name="refer�ncia">Refer�ncia a ser adicionada.</param>
		private void AdicionarItem(string refer�ncia)
		{
			if (lst.InvokeRequired)
			{
				AdicionarItemCallback m�todo = new AdicionarItemCallback(AdicionarItem);

				lst.BeginInvoke(m�todo, new object[] { refer�ncia });
			}
			else
			{
				lst.Items.Add(refer�ncia);
			}
		}

        private class Recupera��o�cone : TrabalhoSegundoPlano
        {
            private ListViewMercadoria lst;

            public Recupera��o�cone(ListViewMercadoria lst)
            {
                this.lst = lst;
            }

            protected override void RealizarTrabalho()
            {
                if (lst.mercadorias == null || lst.mercadorias.Count == 0)
                    return;

                //Entidades.Mercadoria.Mercadoria.Obter�cones(lst.mercadorias);

                lst.Mostrar�conesSeguramente(lst.mercadorias);
            }
		}

		private delegate void Mostrar�conesSeguramenteCallback(IList<Entidades.Mercadoria.Mercadoria> mercadorias);

		/// <summary>
		/// Mostra os �cones seguramente em rela��o � thread.
		/// </summary>
		/// <param name="mercadorias">Lista de mercadorias j� com �cones carregados.</param>
        private void Mostrar�conesSeguramente(IList<Entidades.Mercadoria.Mercadoria> mercadorias)
		{
			if (lst.InvokeRequired)
			{
				Mostrar�conesSeguramenteCallback m�todo = new Mostrar�conesSeguramenteCallback(Mostrar�conesSeguramente);

				lst.BeginInvoke(m�todo, new object[] { mercadorias });
			}
			else if (lst.Items.Count == mercadorias.Count)
			{
                int cnt = lst.Items.Count;

				try
				{
					for (int i = 0; i < cnt; i++)
					{
						Entidades.Mercadoria.Mercadoria mercadoria = mercadorias[i];


						Image �cone = mercadoria.�cone;

						if (�cone != null)
						{
							imagens.Images.Add(�cone);

							/* Pode ocorre da lista mudar. Sendo este o caso,
							 * apenas ignorar.
							 */
							if (lst.Items[i].Text != mercadoria.Refer�ncia)
								break;

							lst.Items[i].ImageIndex = imagens.Images.Count - 1;
						}
					}
				}
				catch (Exception exce��o)
				{
					Exception e = new Exception("Erro considerado e ignorado: a lista pode ter sido alterada por outra thread enquanto recuperava os �cones.\n\n" + exce��o.Message, exce��o);
#if DEBUG
					MessageBox.Show(e.ToString());
#endif
					Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
				}
			}
		}

		/// <summary>
		/// Ocorre quando altera-se o tamanho
		/// </summary>
		private void lst_Resize(object sender, System.EventArgs e)
		{
			colRefer�ncia.Width = lst.ClientSize.Width;
		}

		/// <summary>
		/// Ocorre quando altera-se a sele��o
		/// </summary>
		private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
            Update();

			if (AoSelecionarMercadoria != null && lst.SelectedItems.Count == 1)
				AoSelecionarMercadoria(lst.SelectedItems[0].Text);
		}

		/// <summary>
		/// Seleciona pr�ximo elemento
		/// </summary>
		public void SelecionarPr�ximo()
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
							/* caso em que s� existe 1 elemento na lista
							* e j� est� selecionado. O evento de sua nova
							* sele��o deve ser enviado. Isto � intuitivo.
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
        ///// Obt�m a mercadoria utilizada na lista.
        ///// </summary>
        ///// <param name="refer�ncia">Refer�ncia da mercadoria.</param>
        ///// <returns>
        ///// Mercadoria utilizada na lista ou null caso n�o
        ///// esteja em uso.
        ///// </returns>
        //public Entidades.Mercadoria.Mercadoria ObterMercadoriaLista(string refer�ncia)
        //{
        //    return hashMercadorias[refer�ncia] as Entidades.Mercadoria.Mercadoria;
        //}
	}
}
