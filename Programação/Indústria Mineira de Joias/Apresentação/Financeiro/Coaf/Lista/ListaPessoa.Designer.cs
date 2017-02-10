using Apresentação.Formulários;

namespace Apresentação.Financeiro.Coaf.Lista
{
    partial class ListaPessoa
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
            this.lista = new Apresentação.Formulários.ListViewUsabilidade();
            this.colCódigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPessoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPEP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCPFCNPJ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValorAcumulado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNotificável = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCódigo,
            this.colPessoa,
            this.colPEP,
            this.colCPFCNPJ,
            this.colValorAcumulado,
            this.colNotificável});
            this.lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lista.FullRowSelect = true;
            this.lista.Location = new System.Drawing.Point(0, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(757, 366);
            this.lista.TabIndex = 0;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.Details;
            this.lista.DoubleClick += new System.EventHandler(this.lista_DoubleClick);
            // 
            // colCódigo
            // 
            this.colCódigo.Text = "Código";
            // 
            // colPessoa
            // 
            this.colPessoa.Text = "Pessoa";
            this.colPessoa.Width = 190;
            // 
            // colPEP
            // 
            this.colPEP.Text = "PEP";
            this.colPEP.Width = 223;
            // 
            // colCPFCNPJ
            // 
            this.colCPFCNPJ.Text = "CPF/CNPJ";
            this.colCPFCNPJ.Width = 151;
            // 
            // colValorAcumulado
            // 
            this.colValorAcumulado.Text = "Valor Acumulado";
            this.colValorAcumulado.Width = 131;
            // 
            // colNotificável
            // 
            this.colNotificável.Text = "Notificável";
            // 
            // ListaPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lista);
            this.Name = "ListaPessoa";
            this.Size = new System.Drawing.Size(757, 366);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewUsabilidade lista;
        private System.Windows.Forms.ColumnHeader colPessoa;
        private System.Windows.Forms.ColumnHeader colPEP;
        private System.Windows.Forms.ColumnHeader colCPFCNPJ;
        private System.Windows.Forms.ColumnHeader colValorAcumulado;
        private System.Windows.Forms.ColumnHeader colCódigo;
        private System.Windows.Forms.ColumnHeader colNotificável;
    }
}
