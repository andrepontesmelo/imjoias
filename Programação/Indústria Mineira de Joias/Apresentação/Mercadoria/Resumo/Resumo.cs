using Entidades;
using System.Collections;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace Apresentação.Mercadoria.Resumo
{
    public class Resumo : Form
	{
		private TabControl tabControl1;
		private TabPage tabFaixas;
		private ListView lstFaixas;
		private ColumnHeader colFaixa;
		private ColumnHeader colUnidades;
		private ColumnHeader colPeso;
		private ColumnHeader colÍndice;

        private System.ComponentModel.Container components = null;

		public Resumo()
		{
			InitializeComponent();
		}

		public void Carregar(ArrayList listaSaquinhos)
		{
            Dictionary<string, ResumoItem> itensFaixa = CriaHash(listaSaquinhos);
            PreencheListView(itensFaixa);
		}

        private Dictionary<string, ResumoItem> CriaHash(ArrayList listaSaquinhos)
        {
            Dictionary<string, ResumoItem> itensFaixa = new Dictionary<string, ResumoItem>();

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
                    ResumoItem itemExistente = itensFaixa[s.Mercadoria.Faixa];
                    itemExistente.Acrescentar(s.Quantidade, s.Peso, s.Mercadoria.Índice);
                }
            }

            return itensFaixa;
        }

        private void PreencheListView(Dictionary<string, ResumoItem> itensFaixa)
        {
            foreach (ResumoItem resumoItem in itensFaixa.Values)
            {
                ListViewItem novoItem = new ListViewItem(new string[lstFaixas.Columns.Count]);
                novoItem.Text = (resumoItem.Faixa != null ? resumoItem.Faixa.ToString() : "");

                novoItem.SubItems[colUnidades.Index].Text = resumoItem.Quantidade.ToString();
                novoItem.SubItems[colPeso.Index].Text = resumoItem.Peso.ToString();
                novoItem.SubItems[colÍndice.Index].Text = resumoItem.Índice.ToString();

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
