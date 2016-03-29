using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Etiqueta;
using Apresenta��o.Formul�rios;

//[assembly: ExporBot�o(
//    int.MinValue,
//    "Configurar Etiquetas",
//    true,
//    typeof(Apresenta��o.Mercadoria.Etiqueta.Impress�o.ListaEtiquetas))]

namespace Apresenta��o.Mercadoria.Etiqueta.Impress�o
{
	public class ListaEtiquetas : Apresenta��o.Formul�rios.BaseInferior
	{
		private Hashtable formatos = new Hashtable();

		// Formul�rio
		private System.Windows.Forms.ListView listViewFormatos;
		private System.Windows.Forms.ColumnHeader colFormato;
		private System.Windows.Forms.ColumnHeader colAutor;
		private System.Windows.Forms.ColumnHeader colData;
		private Apresenta��o.Formul�rios.Quadro quadroFormatos;
		private Apresenta��o.Formul�rios.Quadro quadroOpcFormatos;
		private Apresenta��o.Formul�rios.Op��o op��oNovo;
		private Apresenta��o.Formul�rios.Quadro quadroSele��o;
		private System.Windows.Forms.Label label1;
		private Apresenta��o.Formul�rios.Op��o op��oExcluir;
		private Apresenta��o.Formul�rios.Op��o op��oEditar;
		private Apresenta��o.Formul�rios.Op��o op��oRenomear;
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
            this.quadroFormatos = new Apresenta��o.Formul�rios.Quadro();
            this.listViewFormatos = new System.Windows.Forms.ListView();
            this.colFormato = new System.Windows.Forms.ColumnHeader();
            this.colAutor = new System.Windows.Forms.ColumnHeader();
            this.colData = new System.Windows.Forms.ColumnHeader();
            this.quadroOpcFormatos = new Apresenta��o.Formul�rios.Quadro();
            this.op��oNovo = new Apresenta��o.Formul�rios.Op��o();
            this.quadroSele��o = new Apresenta��o.Formul�rios.Quadro();
            this.op��oRenomear = new Apresenta��o.Formul�rios.Op��o();
            this.op��oEditar = new Apresenta��o.Formul�rios.Op��o();
            this.label1 = new System.Windows.Forms.Label();
            this.op��oExcluir = new Apresenta��o.Formul�rios.Op��o();
            this.esquerda.SuspendLayout();
            this.quadroFormatos.SuspendLayout();
            this.quadroOpcFormatos.SuspendLayout();
            this.quadroSele��o.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroOpcFormatos);
            this.esquerda.Controls.Add(this.quadroSele��o);
            this.esquerda.Size = new System.Drawing.Size(187, 400);
            this.esquerda.Controls.SetChildIndex(this.quadroSele��o, 0);
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
            this.quadroFormatos.FundoT�tulo = System.Drawing.Color.SteelBlue;
            this.quadroFormatos.LetraT�tulo = System.Drawing.Color.White;
            this.quadroFormatos.Location = new System.Drawing.Point(240, 24);
            this.quadroFormatos.MostrarBot�oMinMax = false;
            this.quadroFormatos.Name = "quadroFormatos";
            this.quadroFormatos.Size = new System.Drawing.Size(368, 336);
            this.quadroFormatos.TabIndex = 6;
            this.quadroFormatos.Tamanho = 30;
            this.quadroFormatos.T�tulo = "Formatos de etiquetas existentes";
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
            this.quadroOpcFormatos.Controls.Add(this.op��oNovo);
            this.quadroOpcFormatos.Cor = System.Drawing.Color.Black;
            this.quadroOpcFormatos.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroOpcFormatos.LetraT�tulo = System.Drawing.Color.White;
            this.quadroOpcFormatos.Location = new System.Drawing.Point(7, 13);
            this.quadroOpcFormatos.MostrarBot�oMinMax = false;
            this.quadroOpcFormatos.Name = "quadroOpcFormatos";
            this.quadroOpcFormatos.Size = new System.Drawing.Size(160, 56);
            this.quadroOpcFormatos.TabIndex = 0;
            this.quadroOpcFormatos.Tamanho = 30;
            this.quadroOpcFormatos.T�tulo = "Formatos";
            // 
            // op��oNovo
            // 
            this.op��oNovo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oNovo.Descri��o = "Criar novo formato";
            this.op��oNovo.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oNovo.Imagem")));
            this.op��oNovo.Location = new System.Drawing.Point(8, 32);
            this.op��oNovo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oNovo.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oNovo.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oNovo.Name = "op��oNovo";
            this.op��oNovo.Size = new System.Drawing.Size(150, 24);
            this.op��oNovo.TabIndex = 1;
            this.op��oNovo.Click += new System.EventHandler(this.op��oNovo_Click);
            // 
            // quadroSele��o
            // 
            this.quadroSele��o.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroSele��o.bInfDirArredondada = true;
            this.quadroSele��o.bInfEsqArredondada = true;
            this.quadroSele��o.bSupDirArredondada = true;
            this.quadroSele��o.bSupEsqArredondada = true;
            this.quadroSele��o.Controls.Add(this.op��oRenomear);
            this.quadroSele��o.Controls.Add(this.op��oEditar);
            this.quadroSele��o.Controls.Add(this.label1);
            this.quadroSele��o.Controls.Add(this.op��oExcluir);
            this.quadroSele��o.Cor = System.Drawing.Color.Black;
            this.quadroSele��o.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroSele��o.LetraT�tulo = System.Drawing.Color.White;
            this.quadroSele��o.Location = new System.Drawing.Point(7, 75);
            this.quadroSele��o.MostrarBot�oMinMax = false;
            this.quadroSele��o.Name = "quadroSele��o";
            this.quadroSele��o.Size = new System.Drawing.Size(160, 152);
            this.quadroSele��o.TabIndex = 1;
            this.quadroSele��o.Tamanho = 30;
            this.quadroSele��o.T�tulo = "Formato selecionado";
            this.quadroSele��o.Visible = false;
            // 
            // op��oRenomear
            // 
            this.op��oRenomear.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oRenomear.Descri��o = "Renomear";
            this.op��oRenomear.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oRenomear.Imagem")));
            this.op��oRenomear.Location = new System.Drawing.Point(8, 128);
            this.op��oRenomear.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oRenomear.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRenomear.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRenomear.Name = "op��oRenomear";
            this.op��oRenomear.Size = new System.Drawing.Size(150, 24);
            this.op��oRenomear.TabIndex = 4;
            this.op��oRenomear.Click += new System.EventHandler(this.op��oRenomear_Click);
            // 
            // op��oEditar
            // 
            this.op��oEditar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oEditar.Descri��o = "Editar formato";
            this.op��oEditar.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oEditar.Imagem")));
            this.op��oEditar.Location = new System.Drawing.Point(8, 104);
            this.op��oEditar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oEditar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oEditar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oEditar.Name = "op��oEditar";
            this.op��oEditar.Size = new System.Drawing.Size(150, 24);
            this.op��oEditar.TabIndex = 3;
            this.op��oEditar.Click += new System.EventHandler(this.op��oEditar_Click);
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
            // op��oExcluir
            // 
            this.op��oExcluir.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oExcluir.Descri��o = "Excluir formato";
            this.op��oExcluir.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oExcluir.Imagem")));
            this.op��oExcluir.Location = new System.Drawing.Point(8, 80);
            this.op��oExcluir.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.op��oExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oExcluir.Name = "op��oExcluir";
            this.op��oExcluir.Size = new System.Drawing.Size(150, 24);
            this.op��oExcluir.TabIndex = 1;
            this.op��oExcluir.Click += new System.EventHandler(this.op��oExcluir_Click);
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
            this.quadroSele��o.ResumeLayout(false);
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
		/// Ocorre ao mudar a sele��o no ListView
		/// </summary>
		private void listViewFormatos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			quadroSele��o.Visible = listViewFormatos.SelectedItems.Count == 1;
		}

		/// <summary>
		/// Ocorre ao clicar em "Novo Formato"
		/// </summary>
		private void op��oNovo_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			SubstituirBase(new ConfigurarEtiqueta());

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Ocorre ao clicar em "Editar formato"
		/// </summary>
		private void op��oEditar_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			SubstituirBase(new ConfigurarEtiqueta(FormatoSelecionado));

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Ocorre ao clicar em "Excluir formato"
		/// </summary>
		private void op��oExcluir_Click(object sender, System.EventArgs e)
		{
            if (MessageBox.Show("A exclus�o de um formato � um processo irrevers�vel. \nTem certeza que deseja excluir o formato " + FormatoSelecionado.Formato + "?", "Exclu�r formato", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
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
		private void op��oRenomear_Click(object sender, System.EventArgs e)
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
						catch (Acesso.Comum.Exce��es.EntidadeJ�Existente)
						{
							MessageBox.Show(
								this.ParentForm,
                                "O nome escolhido j� existe. N�o foi poss�vel renomear.",
                                "Configura��o de Etiquetas",
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

