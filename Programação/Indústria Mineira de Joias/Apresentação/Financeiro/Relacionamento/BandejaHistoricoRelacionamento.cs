using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Relacionamento;

namespace Apresentação.Financeiro
{
	public class BandejaHistóricoRelacionamento : Apresentação.Mercadoria.Bandeja.Bandeja
	{
		private System.Windows.Forms.ColumnHeader colPreço;
		private System.Windows.Forms.ColumnHeader colData;
		private System.Windows.Forms.ColumnHeader colFuncionário;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ColumnHeader colAção;
		private System.Windows.Forms.ImageList icones;

		public BandejaHistóricoRelacionamento()
		{
			InitializeComponent();

			this.Agrupar = false;
            this.OrdenaçãoReferência = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BandejaHistóricoRelacionamento));
            this.colPreço = new System.Windows.Forms.ColumnHeader();
            this.colFuncionário = new System.Windows.Forms.ColumnHeader();
            this.colData = new System.Windows.Forms.ColumnHeader();
            this.colAção = new System.Windows.Forms.ColumnHeader();
            this.icones = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAção,
            this.colPreço,
            this.colFuncionário,
            this.colData});
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Size = new System.Drawing.Size(704, 368);
            // 
            // colPreço
            // 
            this.colPreço.Text = "Preço";
            // 
            // colFuncionário
            // 
            this.colFuncionário.Text = "Funcionário";
            this.colFuncionário.Width = 81;
            // 
            // colData
            // 
            this.colData.Text = "Data";
            // 
            // colAção
            // 
            this.colAção.Text = "Ação";
            // 
            // icones
            // 
            this.icones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icones.ImageStream")));
            this.icones.TransparentColor = System.Drawing.Color.Transparent;
            this.icones.Images.SetKeyName(0, "");
            this.icones.Images.SetKeyName(1, "");
            // 
            // BandejaHistóricoRelacionamento
            // 
            this.MostrarStatus = false;
            this.Name = "BandejaHistóricoRelacionamento";
            this.PermitirExclusão = false;
            this.Size = new System.Drawing.Size(704, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        protected override ListViewItem ConstruirListView(ISaquinho saquinho)
        {
            ListViewItem item;
            SaquinhoHistóricoRelacionado saquinhoRelacionado;

            saquinhoRelacionado =
                (saquinho as SaquinhoHistóricoRelacionado);

            if (saquinhoRelacionado == null)
            {
                Exception erro;

                if (saquinho == null)
                    erro = new NullReferenceException("O saquinho não pode ser nulo");
                else
                    erro = new InvalidCastException("O saquinho não é do tipo saquinhoRelacionado");

                throw erro;
            }

            item = base.ConstruirListView(saquinho);

            item.SubItems[colData.Index].Text = saquinhoRelacionado.Data.ToString();

            if (saquinhoRelacionado.Funcionário != null)
                item.SubItems[colFuncionário.Index].Text = saquinhoRelacionado.Funcionário.Nome;

            item.SubItems[colAção.Index].Text = saquinhoRelacionado.Tipo == SaquinhoHistóricoRelacionado.TipoEnum.Removeu ? "Excluíu" : "Relacionou";

            if (saquinhoRelacionado.Tipo == SaquinhoHistóricoRelacionado.TipoEnum.Removeu)
            {
                item.ForeColor = Color.White;
                item.BackColor = Color.Red;
                item.UseItemStyleForSubItems = true;
            }

            return item;
        }

        public void Abrir(HistóricoRelacionamento coleção)
        {
            LimparLista();

            ArrayList lista = new ArrayList(coleção.Count);

            foreach (HistóricoRelacionamentoItem item in coleção)
                lista.Add(new SaquinhoHistóricoRelacionado(item));

            AdicionarVários(lista);
        }
	}
}