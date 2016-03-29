using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Etiqueta;
using Apresentação.Formulários;

//[assembly: ExporBotão(
//    int.MinValue,
//    "Configurar Etiquetas",
//    true,
//    typeof(Apresentação.Mercadoria.Etiqueta.Impressão.ListaEtiquetas))]

namespace Apresentação.Mercadoria.Etiqueta.Impressão
{
	public class ListaEtiquetas : Apresentação.Formulários.BaseInferior
	{
		private Hashtable formatos = new Hashtable();

		// Formulário
		private System.Windows.Forms.ListView listViewFormatos;
		private System.Windows.Forms.ColumnHeader colFormato;
		private System.Windows.Forms.ColumnHeader colAutor;
		private System.Windows.Forms.ColumnHeader colData;
		private Apresentação.Formulários.Quadro quadroFormatos;
		private Apresentação.Formulários.Quadro quadroOpcFormatos;
		private Apresentação.Formulários.Opção opçãoNovo;
		private Apresentação.Formulários.Quadro quadroSeleção;
		private System.Windows.Forms.Label label1;
		private Apresentação.Formulários.Opção opçãoExcluir;
		private Apresentação.Formulários.Opção opçãoEditar;
		private Apresentação.Formulários.Opção opçãoRenomear;
		private System.ComponentModel.IContainer components = null;

		public ListaEtiquetas()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaEtiquetas));
            this.quadroFormatos = new Apresentação.Formulários.Quadro();
            this.listViewFormatos = new System.Windows.Forms.ListView();
            this.colFormato = new System.Windows.Forms.ColumnHeader();
            this.colAutor = new System.Windows.Forms.ColumnHeader();
            this.colData = new System.Windows.Forms.ColumnHeader();
            this.quadroOpcFormatos = new Apresentação.Formulários.Quadro();
            this.opçãoNovo = new Apresentação.Formulários.Opção();
            this.quadroSeleção = new Apresentação.Formulários.Quadro();
            this.opçãoRenomear = new Apresentação.Formulários.Opção();
            this.opçãoEditar = new Apresentação.Formulários.Opção();
            this.label1 = new System.Windows.Forms.Label();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadroFormatos.SuspendLayout();
            this.quadroOpcFormatos.SuspendLayout();
            this.quadroSeleção.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroOpcFormatos);
            this.esquerda.Controls.Add(this.quadroSeleção);
            this.esquerda.Size = new System.Drawing.Size(187, 400);
            this.esquerda.Controls.SetChildIndex(this.quadroSeleção, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroOpcFormatos, 0);
            // 
            // quadroFormatos
            // 
            this.quadroFormatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quadroFormatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroFormatos.bInfDirArredondada = false;
            this.quadroFormatos.bInfEsqArredondada = false;
            this.quadroFormatos.bSupDirArredondada = true;
            this.quadroFormatos.bSupEsqArredondada = true;
            this.quadroFormatos.Controls.Add(this.listViewFormatos);
            this.quadroFormatos.Cor = System.Drawing.Color.SteelBlue;
            this.quadroFormatos.FundoTítulo = System.Drawing.Color.SteelBlue;
            this.quadroFormatos.LetraTítulo = System.Drawing.Color.White;
            this.quadroFormatos.Location = new System.Drawing.Point(240, 24);
            this.quadroFormatos.MostrarBotãoMinMax = false;
            this.quadroFormatos.Name = "quadroFormatos";
            this.quadroFormatos.Size = new System.Drawing.Size(368, 336);
            this.quadroFormatos.TabIndex = 6;
            this.quadroFormatos.Tamanho = 30;
            this.quadroFormatos.Título = "Formatos de etiquetas existentes";
            // 
            // listViewFormatos
            // 
            this.listViewFormatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFormatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFormatos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFormato,
            this.colAutor,
            this.colData});
            this.listViewFormatos.FullRowSelect = true;
            this.listViewFormatos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewFormatos.Location = new System.Drawing.Point(1, 24);
            this.listViewFormatos.Name = "listViewFormatos";
            this.listViewFormatos.Size = new System.Drawing.Size(366, 311);
            this.listViewFormatos.TabIndex = 1;
            this.listViewFormatos.UseCompatibleStateImageBehavior = false;
            this.listViewFormatos.View = System.Windows.Forms.View.Details;
            this.listViewFormatos.DoubleClick += new System.EventHandler(this.listViewFormatos_DoubleClick);
            this.listViewFormatos.SelectedIndexChanged += new System.EventHandler(this.listViewFormatos_SelectedIndexChanged);
            // 
            // colFormato
            // 
            this.colFormato.Text = "Formato";
            this.colFormato.Width = 124;
            // 
            // colAutor
            // 
            this.colAutor.Text = "Autor";
            this.colAutor.Width = 122;
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 103;
            // 
            // quadroOpcFormatos
            // 
            this.quadroOpcFormatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroOpcFormatos.bInfDirArredondada = true;
            this.quadroOpcFormatos.bInfEsqArredondada = true;
            this.quadroOpcFormatos.bSupDirArredondada = true;
            this.quadroOpcFormatos.bSupEsqArredondada = true;
            this.quadroOpcFormatos.Controls.Add(this.opçãoNovo);
            this.quadroOpcFormatos.Cor = System.Drawing.Color.Black;
            this.quadroOpcFormatos.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOpcFormatos.LetraTítulo = System.Drawing.Color.White;
            this.quadroOpcFormatos.Location = new System.Drawing.Point(7, 13);
            this.quadroOpcFormatos.MostrarBotãoMinMax = false;
            this.quadroOpcFormatos.Name = "quadroOpcFormatos";
            this.quadroOpcFormatos.Size = new System.Drawing.Size(160, 56);
            this.quadroOpcFormatos.TabIndex = 0;
            this.quadroOpcFormatos.Tamanho = 30;
            this.quadroOpcFormatos.Título = "Formatos";
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoNovo.Descrição = "Criar novo formato";
            this.opçãoNovo.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoNovo.Imagem")));
            this.opçãoNovo.Location = new System.Drawing.Point(8, 32);
            this.opçãoNovo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovo.Name = "opçãoNovo";
            this.opçãoNovo.Size = new System.Drawing.Size(150, 24);
            this.opçãoNovo.TabIndex = 1;
            this.opçãoNovo.Click += new System.EventHandler(this.opçãoNovo_Click);
            // 
            // quadroSeleção
            // 
            this.quadroSeleção.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroSeleção.bInfDirArredondada = true;
            this.quadroSeleção.bInfEsqArredondada = true;
            this.quadroSeleção.bSupDirArredondada = true;
            this.quadroSeleção.bSupEsqArredondada = true;
            this.quadroSeleção.Controls.Add(this.opçãoRenomear);
            this.quadroSeleção.Controls.Add(this.opçãoEditar);
            this.quadroSeleção.Controls.Add(this.label1);
            this.quadroSeleção.Controls.Add(this.opçãoExcluir);
            this.quadroSeleção.Cor = System.Drawing.Color.Black;
            this.quadroSeleção.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroSeleção.LetraTítulo = System.Drawing.Color.White;
            this.quadroSeleção.Location = new System.Drawing.Point(7, 75);
            this.quadroSeleção.MostrarBotãoMinMax = false;
            this.quadroSeleção.Name = "quadroSeleção";
            this.quadroSeleção.Size = new System.Drawing.Size(160, 152);
            this.quadroSeleção.TabIndex = 1;
            this.quadroSeleção.Tamanho = 30;
            this.quadroSeleção.Título = "Formato selecionado";
            this.quadroSeleção.Visible = false;
            // 
            // opçãoRenomear
            // 
            this.opçãoRenomear.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoRenomear.Descrição = "Renomear";
            this.opçãoRenomear.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoRenomear.Imagem")));
            this.opçãoRenomear.Location = new System.Drawing.Point(8, 128);
            this.opçãoRenomear.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoRenomear.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRenomear.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRenomear.Name = "opçãoRenomear";
            this.opçãoRenomear.Size = new System.Drawing.Size(150, 24);
            this.opçãoRenomear.TabIndex = 4;
            this.opçãoRenomear.Click += new System.EventHandler(this.opçãoRenomear_Click);
            // 
            // opçãoEditar
            // 
            this.opçãoEditar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoEditar.Descrição = "Editar formato";
            this.opçãoEditar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoEditar.Imagem")));
            this.opçãoEditar.Location = new System.Drawing.Point(8, 104);
            this.opçãoEditar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoEditar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEditar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEditar.Name = "opçãoEditar";
            this.opçãoEditar.Size = new System.Drawing.Size(150, 24);
            this.opçãoEditar.TabIndex = 3;
            this.opçãoEditar.Click += new System.EventHandler(this.opçãoEditar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sobre o formato selecionado ao lado, o que deseja?";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoExcluir.Descrição = "Excluir formato";
            this.opçãoExcluir.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoExcluir.Imagem")));
            this.opçãoExcluir.Location = new System.Drawing.Point(8, 80);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 24);
            this.opçãoExcluir.TabIndex = 1;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // ListaEtiquetas
            // 
            this.Controls.Add(this.quadroFormatos);
            this.Imagem = Resource.Etiqueta;
            this.Name = "ListaEtiquetas";
            this.Size = new System.Drawing.Size(664, 400);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.quadroFormatos, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroFormatos.ResumeLayout(false);
            this.quadroOpcFormatos.ResumeLayout(false);
            this.quadroSeleção.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao exibir a lista de etiquetas
		/// </summary>
		protected override void AoExibir()
		{
			EtiquetaFormato [] todosFormatos;

			base.AoExibir();

			todosFormatos = EtiquetaFormato.ObterEtiquetas();
			MostrarFormatos(todosFormatos);
		}

		/// <summary>
		/// Mostra formatos na ListView
		/// </summary>
		private void MostrarFormatos(EtiquetaFormato [] todosFormatos)
		{
			listViewFormatos.Items.Clear();
			formatos.Clear();

			foreach (EtiquetaFormato formato in todosFormatos)
			{
				ListViewItem linha;

				linha = new ListViewItem();
				linha.Text = formato.Formato;

				linha.SubItems.Add(formato.Autor);
				linha.SubItems.Add(formato.Data.ToShortDateString());

				listViewFormatos.Items.Add(linha);

				formatos[linha] = formato;
			}
		}

		/// <summary>
		/// Ocorre ao mudar a seleção no ListView
		/// </summary>
		private void listViewFormatos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			quadroSeleção.Visible = listViewFormatos.SelectedItems.Count == 1;
		}

		/// <summary>
		/// Ocorre ao clicar em "Novo Formato"
		/// </summary>
		private void opçãoNovo_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			SubstituirBase(new ConfigurarEtiqueta());

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Ocorre ao clicar em "Editar formato"
		/// </summary>
		private void opçãoEditar_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			SubstituirBase(new ConfigurarEtiqueta(FormatoSelecionado));

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Ocorre ao clicar em "Excluir formato"
		/// </summary>
		private void opçãoExcluir_Click(object sender, System.EventArgs e)
		{
            if (MessageBox.Show("A exclusão de um formato é um processo irreversível. \nTem certeza que deseja excluir o formato " + FormatoSelecionado.Formato + "?", "Excluír formato", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                == DialogResult.Yes)
            {
                UseWaitCursor = true;
                FormatoSelecionado.Descadastrar();

                formatos.Remove(listViewFormatos.SelectedItems[0]);
                listViewFormatos.SelectedItems[0].Remove();
                UseWaitCursor = false;
            }
		}

		/// <summary>
		/// Ocorre ao clicar em "Renomear"
		/// </summary>
		private void opçãoRenomear_Click(object sender, System.EventArgs e)
		{
			using (Renomear dlg = new Renomear(FormatoSelecionado.Formato))
			{
				if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
				{
					if (dlg.Nome != FormatoSelecionado.Formato)
						try
						{
							FormatoSelecionado.Renomear(dlg.Nome);

							listViewFormatos.SelectedItems[0].Text = dlg.Nome;
						}
						catch (Acesso.Comum.Exceções.EntidadeJáExistente)
						{
							MessageBox.Show(
								this.ParentForm,
                                "O nome escolhido já existe. Não foi possível renomear.",
                                "Configuração de Etiquetas",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
						}
				}
			}
		}

		/// <summary>
		/// Formato selecionado
		/// </summary>
		public EtiquetaFormato FormatoSelecionado
		{
			get
			{
				if (listViewFormatos.SelectedItems.Count == 1)
					return (EtiquetaFormato) formatos[listViewFormatos.SelectedItems[0]];
				else
					return null;
			}
		}

        private void listViewFormatos_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            SubstituirBase(new ConfigurarEtiqueta(FormatoSelecionado));

            Cursor.Current = Cursors.Default;
        }
	}
}

