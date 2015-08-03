using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades;


using Apresentação.Mercadoria.Bandeja;

namespace Apresentação.Mercadoria.Resumo
{
	/// <summary>
	/// Apartir de uma lista de saquinhos,
	/// é possível computar quantas gramas existem por faixa. 
	/// Este tipo de informação é extremamente útil na empresa,
	/// em todo e qualquer coleção de mercadoria.
	/// Este controle tem a finalidade de apresentar um resumo para o usuário de qualquer coleção de saquinhos.
	/// O processamento é feito localmente. No entanto, pode-se experimentar realiza-lo em servidor para melhor desempenho.
	/// 
   	/// </summary>
	public class Resumo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabFaixas;
		private System.Windows.Forms.ListView lstFaixas;
		private System.Windows.Forms.ColumnHeader colFaixa;
		private System.Windows.Forms.ColumnHeader colUnidades;
		private System.Windows.Forms.ColumnHeader colPeso;
		private System.Windows.Forms.ColumnHeader colÍndice;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Resumo()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		public void Carregar(ArrayList listaSaquinhos)
		{
			// Guarda: listviewitem Chave: string faixa
			Hashtable itensFaixa = new Hashtable();


			// Somatório
			foreach (Saquinho s in listaSaquinhos)
			{
				if (!itensFaixa.ContainsKey(s.Mercadoria.Faixa))
				{
					// Cria item para esta nova faixa.
					ResumoItem novoItem = new ResumoItem(s.Quantidade, s.Peso, s.Mercadoria.Índice, s.Mercadoria.Faixa.ToString());
					itensFaixa[s.Mercadoria.Faixa] = novoItem;

				} 
				else
				{
					ResumoItem itemExistente = (ResumoItem) itensFaixa[s.Mercadoria.Faixa];

					itemExistente.Acrescentar(s.Quantidade, s.Peso, s.Mercadoria.Índice);
				}
			}

			// Preenche listview
			foreach (object obj in itensFaixa)
			{
				ResumoItem r = (ResumoItem) ((DictionaryEntry) obj).Value;

				ListViewItem novoItem = new ListViewItem(new string[lstFaixas.Columns.Count]);
				novoItem.Text = (r.Faixa != null ? r.Faixa.ToString() : "");
				
				novoItem.SubItems[colUnidades.Index].Text = r.Quantidade.ToString();
				novoItem.SubItems[colPeso.Index].Text = r.Peso.ToString();
				novoItem.SubItems[colÍndice.Index].Text = r.Índice.ToString();

				lstFaixas.Items.Add(novoItem);
			}
				
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFaixas = new System.Windows.Forms.TabPage();
            this.lstFaixas = new System.Windows.Forms.ListView();
            this.colFaixa = new System.Windows.Forms.ColumnHeader();
            this.colUnidades = new System.Windows.Forms.ColumnHeader();
            this.colPeso = new System.Windows.Forms.ColumnHeader();
            this.colÍndice = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tabFaixas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFaixas);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 264);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFaixas
            // 
            this.tabFaixas.Controls.Add(this.lstFaixas);
            this.tabFaixas.Location = new System.Drawing.Point(4, 22);
            this.tabFaixas.Name = "tabFaixas";
            this.tabFaixas.Size = new System.Drawing.Size(312, 238);
            this.tabFaixas.TabIndex = 0;
            this.tabFaixas.Text = "Faixas";
            // 
            // lstFaixas
            // 
            this.lstFaixas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFaixas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFaixa,
            this.colUnidades,
            this.colPeso,
            this.colÍndice});
            this.lstFaixas.Location = new System.Drawing.Point(8, 8);
            this.lstFaixas.Name = "lstFaixas";
            this.lstFaixas.Size = new System.Drawing.Size(296, 224);
            this.lstFaixas.TabIndex = 0;
            this.lstFaixas.UseCompatibleStateImageBehavior = false;
            this.lstFaixas.View = System.Windows.Forms.View.Details;
            // 
            // colFaixa
            // 
            this.colFaixa.Text = "Faixa";
            // 
            // colUnidades
            // 
            this.colUnidades.Text = "Unidades";
            // 
            // colPeso
            // 
            this.colPeso.Text = "Peso";
            // 
            // colÍndice
            // 
            this.colÍndice.Text = "Indice";
            // 
            // Resumo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(331, 283);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Resumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabFaixas.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

	}
}
