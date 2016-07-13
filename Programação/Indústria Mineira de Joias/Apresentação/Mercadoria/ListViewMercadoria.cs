using Apresentação.Formulários;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    public class ListViewMercadoria : UserControl
	{
		public delegate void SeleçãoMercadoria(string referência);
		public event SeleçãoMercadoria AoSelecionarMercadoria;

        private IList<Entidades.Mercadoria.Mercadoria> mercadorias;
        private RecuperaçãoÍcone recuperaçãoÍcone;

		private ListView lst;
		private ImageList imagens;
		private ColumnHeader colReferência;
		private IContainer components;

		public ListViewMercadoria()
		{
			InitializeComponent();

            recuperaçãoÍcone = new RecuperaçãoÍcone(this);
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
            this.colReferência = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
                MostrarCallback método = new MostrarCallback(Mostrar);

                lst.BeginInvoke(método, mercadorias);
            }
            else
			    lock (lst)
			    {
                    Limpar();

                    this.mercadorias = mercadorias;

                    string[] referências = new string[mercadorias.Count];
                    for (int i = 0; i < mercadorias.Count; i++)
                        referências[i] = mercadorias[i].Referência;

                    AdicionarVáriosItens(referências);

                    if (mercadorias != null && mercadorias.Count > 0 && recuperaçãoÍcone != null)
                        recuperaçãoÍcone.IniciarTrabalho();
			    }
		}

		private delegate void AdicionarItemCallback(string referência);

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
                lst.Focus();
			}
		}

        private void AdicionarVáriosItens(string[] referências)
        {
            if (lst.InvokeRequired)
            {
                AdicionarItemCallback método = new AdicionarItemCallback(AdicionarItem);

                lst.BeginInvoke(método, referências);
            }
            else
            {
                ListViewItem[] itens = new ListViewItem[referências.Length];

                for (int x = 0; x < referências.Length; x++)
                    itens[x] = new ListViewItem(referências[x]);

                lst.Items.AddRange(itens);
                lst.Focus();
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

                lst.MostrarÍconesSeguramente(lst.mercadorias);
            }
		}

		private delegate void MostrarÍconesSeguramenteCallback(IList<Entidades.Mercadoria.Mercadoria> mercadorias);

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

		private void lst_Resize(object sender, System.EventArgs e)
		{
			colReferência.Width = lst.ClientSize.Width;
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
                bool idxVálido = (idx >= 0) && (idx < lst.Items.Count);

                if (idxVálido)
                {
                    lst.SelectedItems.Clear();
                    lst.Items[idx].Selected = true;
                    lst.Items[idx].EnsureVisible();
                }
            }
        }


        public void SelecionarPróximo()
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
