using Apresenta��o.Formul�rios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresenta��o.Mercadoria
{
    public class ListViewMercadoria : UserControl
	{
		public delegate void Sele��oMercadoria(string refer�ncia);
		public event Sele��oMercadoria AoSelecionarMercadoria;

        private IList<Entidades.Mercadoria.Mercadoria> mercadorias;
        private Recupera��o�cone recupera��o�cone;

		private ListView lst;
		private ImageList imagens;
		private ColumnHeader colRefer�ncia;
		private IContainer components;

		public ListViewMercadoria()
		{
			InitializeComponent();

            recupera��o�cone = new Recupera��o�cone(this);
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lst = new System.Windows.Forms.ListView();
            this.colRefer�ncia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.lst.LargeImageList = this.imagens;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(368, 200);
            this.lst.SmallImageList = this.imagens;
            this.lst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.Resize += new System.EventHandler(this.lst_Resize);
            this.lst.Click += Lst_Click;
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

        private void Lst_Click(object sender, EventArgs e)
        {
            Selecionar(0);
            Hide();
        }

        #endregion

        private delegate void LimparCallback();

		private void Limpar()
		{
			lst.Items.Clear();
			imagens.Images.Clear();
		}

        private delegate void MostrarCallback(IList<Entidades.Mercadoria.Mercadoria> mercadorias);

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
                    Limpar();

                    this.mercadorias = mercadorias;

                    string[] refer�ncias = new string[mercadorias.Count];
                    for (int i = 0; i < mercadorias.Count; i++)
                        refer�ncias[i] = mercadorias[i].Refer�ncia;

                    AdicionarV�riosItens(refer�ncias);

                    if (mercadorias != null && mercadorias.Count > 0 && recupera��o�cone != null)
                        recupera��o�cone.IniciarTrabalho();
			    }
		}

		private delegate void AdicionarItemCallback(string refer�ncia);

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
                lst.Focus();
			}
		}

        private void AdicionarV�riosItens(string[] refer�ncias)
        {
            if (lst.InvokeRequired)
            {
                AdicionarItemCallback m�todo = new AdicionarItemCallback(AdicionarItem);

                lst.BeginInvoke(m�todo, refer�ncias);
            }
            else
            {
                ListViewItem[] itens = new ListViewItem[refer�ncias.Length];

                for (int x = 0; x < refer�ncias.Length; x++)
                    itens[x] = new ListViewItem(refer�ncias[x]);

                lst.Items.AddRange(itens);
                lst.Focus();
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

                lst.Mostrar�conesSeguramente(lst.mercadorias);
            }
		}

		private delegate void Mostrar�conesSeguramenteCallback(IList<Entidades.Mercadoria.Mercadoria> mercadorias);

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

		private void lst_Resize(object sender, System.EventArgs e)
		{
			colRefer�ncia.Width = lst.ClientSize.Width;
		}

		private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
            Update();

			if (AoSelecionarMercadoria != null && lst.SelectedItems.Count == 1)
				AoSelecionarMercadoria(lst.SelectedItems[0].Text);
		}

        public void Selecionar(int delta)
        {
            lock (lst)
            {
                if (lst.Items.Count == 0)
                    return;

                if (lst.SelectedIndices.Count == 0)
                {
                    lst.Items[0].Selected = true;
                    return;
                }

                int idx = lst.SelectedIndices[0] + delta;
                bool idxV�lido = (idx >= 0) && (idx < lst.Items.Count);

                if (idxV�lido)
                {
                    lst.SelectedItems.Clear();
                    lst.Items[idx].Selected = true;
                    lst.Items[idx].EnsureVisible();
                }
            }
        }


        public void SelecionarPr�ximo()
		{
            Selecionar(1);
        }

		public void SelecionarAnterior()
		{
            Selecionar(-1);
		}

		public ListView.ListViewItemCollection Items
		{
			get
			{
				return lst.Items;
			}
		}
	}
}
