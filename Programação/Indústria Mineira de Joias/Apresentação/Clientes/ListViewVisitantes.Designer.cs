namespace Apresentação.Atendimento.Clientes
{
    partial class ListViewVisitantes
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Já sairam", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Aguardando", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Em atendimento", System.Windows.Forms.HorizontalAlignment.Left);
            this.lstVisitantes = new System.Windows.Forms.ListView();
            this.colVisitante = new System.Windows.Forms.ColumnHeader();
            this.colSetor = new System.Windows.Forms.ColumnHeader();
            this.colAtendente = new System.Windows.Forms.ColumnHeader();
            this.colEntrada = new System.Windows.Forms.ColumnHeader();
            this.colSaída = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstVisitantes
            // 
            this.lstVisitantes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVisitante,
            this.colSetor,
            this.colAtendente,
            this.colEntrada,
            this.colSaída});
            this.lstVisitantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVisitantes.FullRowSelect = true;
            listViewGroup1.Header = "Já sairam";
            listViewGroup1.Name = "lstGrpPassado";
            listViewGroup2.Header = "Aguardando";
            listViewGroup2.Name = "lstGrpAguardando";
            listViewGroup3.Header = "Em atendimento";
            listViewGroup3.Name = "lstGrpAtendimento";
            this.lstVisitantes.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lstVisitantes.Location = new System.Drawing.Point(0, 0);
            this.lstVisitantes.MultiSelect = false;
            this.lstVisitantes.Name = "lstVisitantes";
            this.lstVisitantes.Size = new System.Drawing.Size(541, 208);
            this.lstVisitantes.TabIndex = 5;
            this.lstVisitantes.UseCompatibleStateImageBehavior = false;
            this.lstVisitantes.View = System.Windows.Forms.View.Details;
            this.lstVisitantes.SelectedIndexChanged += new System.EventHandler(this.lstVisitantes_SelectedIndexChanged);
            // 
            // colVisitante
            // 
            this.colVisitante.Text = "Visitante";
            this.colVisitante.Width = 200;
            // 
            // colSetor
            // 
            this.colSetor.Text = "Setor";
            this.colSetor.Width = 74;
            // 
            // colAtendente
            // 
            this.colAtendente.Text = "Atendente";
            this.colAtendente.Width = 81;
            // 
            // colEntrada
            // 
            this.colEntrada.Text = "Entrada";
            this.colEntrada.Width = 80;
            // 
            // colSaída
            // 
            this.colSaída.Text = "Saída";
            this.colSaída.Width = 80;
            // 
            // ListViewVisitantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstVisitantes);
            this.Name = "ListViewVisitantes";
            this.Size = new System.Drawing.Size(541, 208);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstVisitantes;
        private System.Windows.Forms.ColumnHeader colVisitante;
        private System.Windows.Forms.ColumnHeader colSetor;
        private System.Windows.Forms.ColumnHeader colAtendente;
        private System.Windows.Forms.ColumnHeader colEntrada;
        private System.Windows.Forms.ColumnHeader colSaída;
    }
}
