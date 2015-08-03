namespace Apresentação.Pessoa.Endereço
{
    partial class ListarLocalidades
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst = new System.Windows.Forms.ListView();
            this.colLocalidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPaís = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegião = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(105, 20);
            this.lblTítulo.Text = "Localidades";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(530, 48);
            this.lblDescrição.Text = "Escolha a localidade desejada";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.Lupa;
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLocalidade,
            this.colEstado,
            this.colPaís,
            this.colRegião});
            this.lst.FullRowSelect = true;
            this.lst.Location = new System.Drawing.Point(24, 108);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(594, 201);
            this.lst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lst.TabIndex = 3;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.AoMudarSeleção);
            // 
            // colLocalidade
            // 
            this.colLocalidade.Text = "Localidade";
            this.colLocalidade.Width = 173;
            // 
            // colEstado
            // 
            this.colEstado.Text = "Estado";
            this.colEstado.Width = 77;
            // 
            // colPaís
            // 
            this.colPaís.Text = "País";
            this.colPaís.Width = 161;
            // 
            // colRegião
            // 
            this.colRegião.Text = "Região";
            this.colRegião.Width = 154;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(450, 315);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(531, 315);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // ListarLocalidades
            // 
            this.ClientSize = new System.Drawing.Size(618, 350);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.KeyPreview = true;
            this.Name = "ListarLocalidades";
            this.Text = "Localidades";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lst, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colLocalidade;
        private System.Windows.Forms.ColumnHeader colEstado;
        private System.Windows.Forms.ColumnHeader colPaís;
        private System.Windows.Forms.ColumnHeader colRegião;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
    }
}
