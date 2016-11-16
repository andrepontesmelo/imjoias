using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Relacionamento;

namespace Apresenta��o.Financeiro
{
	public class BandejaHist�ricoRelacionamento : Apresenta��o.Mercadoria.Bandeja.Bandeja
	{
		private System.Windows.Forms.ColumnHeader colPre�o;
		private System.Windows.Forms.ColumnHeader colData;
		private System.Windows.Forms.ColumnHeader colFuncion�rio;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ColumnHeader colA��o;
		private System.Windows.Forms.ImageList icones;

		public BandejaHist�ricoRelacionamento()
		{
			InitializeComponent();

			this.Agrupar = false;
            this.Ordena��oRefer�ncia = false;
            this.btnAgrupar.Visible = false;
		}

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BandejaHist�ricoRelacionamento));
            this.colPre�o = new System.Windows.Forms.ColumnHeader();
            this.colFuncion�rio = new System.Windows.Forms.ColumnHeader();
            this.colData = new System.Windows.Forms.ColumnHeader();
            this.colA��o = new System.Windows.Forms.ColumnHeader();
            this.icones = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colA��o,
            this.colPre�o,
            this.colFuncion�rio,
            this.colData});
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Size = new System.Drawing.Size(704, 368);
            // 
            // colPre�o
            // 
            this.colPre�o.Text = "Pre�o";
            // 
            // colFuncion�rio
            // 
            this.colFuncion�rio.Text = "Funcion�rio";
            this.colFuncion�rio.Width = 81;
            // 
            // colData
            // 
            this.colData.Text = "Data";
            // 
            // colA��o
            // 
            this.colA��o.Text = "A��o";
            // 
            // icones
            // 
            this.icones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icones.ImageStream")));
            this.icones.TransparentColor = System.Drawing.Color.Transparent;
            this.icones.Images.SetKeyName(0, "");
            this.icones.Images.SetKeyName(1, "");
            // 
            // BandejaHist�ricoRelacionamento
            // 
            this.MostrarStatus = false;
            this.Name = "BandejaHist�ricoRelacionamento";
            this.PermitirExclus�o = false;
            this.Size = new System.Drawing.Size(704, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        protected override ListViewItem ConstruirListView(ISaquinho saquinho)
        {
            ListViewItem item;
            SaquinhoHist�ricoRelacionado saquinhoRelacionado;

            saquinhoRelacionado =
                (saquinho as SaquinhoHist�ricoRelacionado);

            if (saquinhoRelacionado == null)
            {
                Exception erro;

                if (saquinho == null)
                    erro = new NullReferenceException("O saquinho n�o pode ser nulo");
                else
                    erro = new InvalidCastException("O saquinho n�o � do tipo saquinhoRelacionado");

                throw erro;
            }

            item = base.ConstruirListView(saquinho);

            item.SubItems[colData.Index].Text = saquinhoRelacionado.Data.ToString();

            if (saquinhoRelacionado.Funcion�rio != null)
                item.SubItems[colFuncion�rio.Index].Text = saquinhoRelacionado.Funcion�rio.Nome;

            item.SubItems[colA��o.Index].Text = saquinhoRelacionado.Tipo == SaquinhoHist�ricoRelacionado.TipoEnum.Removeu ? "Exclu�u" : "Relacionou";

            if (saquinhoRelacionado.Tipo == SaquinhoHist�ricoRelacionado.TipoEnum.Removeu)
            {
                item.ForeColor = Color.White;
                item.BackColor = Color.Red;
                item.UseItemStyleForSubItems = true;
            }

            return item;
        }

        public void Abrir(Hist�ricoRelacionamento cole��o)
        {
            LimparLista();

            ArrayList lista = new ArrayList(cole��o.Count);

            foreach (Hist�ricoRelacionamentoItem item in cole��o)
                lista.Add(new SaquinhoHist�ricoRelacionado(item));

            AdicionarV�rios(lista);
        }
	}
}