namespace Apresentação.Pessoa.Endereço
{
    partial class EscolhaEndereço
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
            this.colDescrição = new System.Windows.Forms.ColumnHeader();
            this.colLogradouro = new System.Windows.Forms.ColumnHeader();
            this.colBairro = new System.Windows.Forms.ColumnHeader();
            this.colLocalidade = new System.Windows.Forms.ColumnHeader();
            this.colEstado = new System.Windows.Forms.ColumnHeader();
            this.colPaís = new System.Windows.Forms.ColumnHeader();
            this.colObservações = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.colNúmero = new System.Windows.Forms.ColumnHeader();
            this.colComplemento = new System.Windows.Forms.ColumnHeader();
            this.colCEP = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(86, 20);
            this.lblTítulo.Text = "Endereço";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(414, 48);
            this.lblDescrição.Text = "Escolha o endereço desejado.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.placa_de_rua;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescrição,
            this.colLogradouro,
            this.colNúmero,
            this.colComplemento,
            this.colBairro,
            this.colCEP,
            this.colLocalidade,
            this.colEstado,
            this.colPaís,
            this.colObservações});
            this.lst.FullRowSelect = true;
            this.lst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst.HideSelection = false;
            this.lst.Location = new System.Drawing.Point(12, 100);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(478, 161);
            this.lst.TabIndex = 3;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // colDescrição
            // 
            this.colDescrição.Text = "Descrição";
            this.colDescrição.Width = 94;
            // 
            // colLogradouro
            // 
            this.colLogradouro.Text = "Logradouro";
            // 
            // colBairro
            // 
            this.colBairro.Text = "Bairro";
            // 
            // colLocalidade
            // 
            this.colLocalidade.Text = "Localidade";
            // 
            // colEstado
            // 
            this.colEstado.Text = "Estado";
            // 
            // colPaís
            // 
            this.colPaís.Text = "País";
            // 
            // colObservações
            // 
            this.colObservações.Text = "Observações";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(334, 277);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(415, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // colNúmero
            // 
            this.colNúmero.Text = "Número";
            // 
            // colComplemento
            // 
            this.colComplemento.Text = "Complemento";
            // 
            // colCEP
            // 
            this.colCEP.Text = "CEP";
            // 
            // EscolhaEndereço
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(502, 312);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Name = "EscolhaEndereço";
            this.Text = "Escolha de endereço";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lst, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colLogradouro;
        private System.Windows.Forms.ColumnHeader colBairro;
        private System.Windows.Forms.ColumnHeader colLocalidade;
        private System.Windows.Forms.ColumnHeader colEstado;
        private System.Windows.Forms.ColumnHeader colDescrição;
        private System.Windows.Forms.ColumnHeader colPaís;
        private System.Windows.Forms.ColumnHeader colObservações;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ColumnHeader colNúmero;
        private System.Windows.Forms.ColumnHeader colComplemento;
        private System.Windows.Forms.ColumnHeader colCEP;
    }
}
