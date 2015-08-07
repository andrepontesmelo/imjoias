using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using Entidades;
using Entidades.Etiqueta;

namespace Apresentação.Mercadoria.Etiqueta.Impressão
{
	public class BandejaEtiqueta : Apresentação.Mercadoria.Bandeja.Bandeja
	{
        private ToolStripItem btnRemoverImpressos;

        private System.Windows.Forms.ColumnHeader colFormato;
		private System.ComponentModel.Container components = null;

        public BandejaEtiqueta()
		{
			InitializeComponent();

            MostrarPreço = false;
            MostrarSeleçãoTabela = false;

            btnRemoverImpressos = new ToolStripButton();
            btnRemoverImpressos.Text = "Remover impressos";
            btnRemoverImpressos.Click += new EventHandler(AoRemoverImpressos);
            btnRemoverImpressos.ToolTipText = "Remove etiquetas que ja\'foram impressas";

            barraFerramentas.Items.Insert(0, btnRemoverImpressos);
		}

        private void AoRemoverImpressos(object sender, EventArgs e)
        {
            RemoverImpressos();
        }
			
		protected override ListViewItem ConstruirListView(ISaquinho saquinhoASerAdicionado)
		{
			SaquinhoEtiqueta saquinho = (SaquinhoEtiqueta) saquinhoASerAdicionado;
			ListViewItem item;
			
			item = base.ConstruirListView(saquinho);	//Adiciona o essencial: Ref e Qtd
			
			item.SubItems[colFormato.Index].Text 
				= saquinho.Etiqueta.ToString();

			if (saquinho.Impresso)
			{
				item.ForeColor = Color.Red;
				item.Font = new Font(item.Font, FontStyle.Strikeout);
				item.UseItemStyleForSubItems = true;
				btnRemoverImpressos.Enabled = true;
			}

			return item;
		}

        //protected override void AtualizaElementoListView(ISaquinho saquinhoAtualizado, ListViewItem item)
        //{
        //    SaquinhoEtiqueta saquinho;

        //    base.AtualizaElementoListView(saquinhoAtualizado, item);

        //    saquinho = (SaquinhoEtiqueta) saquinhoAtualizado;

        //    item.SubItems[colFormato.Index].Text = saquinho.Etiqueta.ToString(); 

        //    if (saquinho.Impresso)
        //    {
        //        item.ForeColor = Color.Red;
        //        item.Font = new Font(item.Font, FontStyle.Strikeout);
        //        item.UseItemStyleForSubItems = true;
        //        btnRemoverImpressos.Enabled = true;
        //    }
        //    else if (item.Font.Strikeout)
        //    {
        //        item.ForeColor = ForeColor;
        //        item.Font = new Font(item.Font, FontStyle.Regular);
        //    }
        //}		

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
            this.colFormato = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFormato});
            this.lista.Location = new System.Drawing.Point(0, 25);
            this.lista.Size = new System.Drawing.Size(560, 306);
            // 
            // colFormato
            // 
            this.colFormato.Text = "Formato";
            this.colFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFormato.Width = 120;
            // 
            // BandejaEtiqueta
            // 
            this.MostrarPreço = false;
            this.Name = "BandejaEtiqueta";
            this.Size = new System.Drawing.Size(560, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Remove saquinhos que já foram impressos
		/// </summary>
		private void RemoverImpressos()
		{
            UseWaitCursor = true;

            Saquinho[] cloneSaquinhos = new Saquinho[saquinhos.Count];

            saquinhos.CopyTo(cloneSaquinhos);

			foreach (SaquinhoEtiqueta saquinho in cloneSaquinhos)
				if (saquinho.Impresso)
					Remover(saquinho);

			btnRemoverImpressos.Enabled = false;

            UseWaitCursor = false;
		}

        /// <summary>
        /// Método deve ser chamado assim
        /// </summary>
        public void FoiImpresso(ArrayList saquinhos)
        {
            foreach (SaquinhoEtiqueta s in saquinhos)
            {
                Remover(s);
                s.Impresso = true;
            }

            AdicionarVários(saquinhos);

            btnRemoverImpressos.Enabled = saquinhos.Count > 0;
        }
	}
}
