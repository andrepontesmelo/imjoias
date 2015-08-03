namespace Apresentação.Financeiro.Cotação
{
    partial class EscolherEdiçãoMoeda
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
            this.radioCriar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioEditar = new System.Windows.Forms.RadioButton();
            this.comboMoeda = new Apresentação.Mercadoria.Cotação.ComboMoeda();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(192, 20);
            this.lblTítulo.Text = "Manutenção de moeda";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(316, 48);
            this.lblDescrição.Text = "Escolha a atividade que deseja realizar sobre a moeda.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Financeiro.Properties.Resources.moeda;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // radioCriar
            // 
            this.radioCriar.AutoSize = true;
            this.radioCriar.Location = new System.Drawing.Point(32, 137);
            this.radioCriar.Name = "radioCriar";
            this.radioCriar.Size = new System.Drawing.Size(131, 17);
            this.radioCriar.TabIndex = 3;
            this.radioCriar.TabStop = true;
            this.radioCriar.Text = "Criar uma nova moeda";
            this.radioCriar.UseVisualStyleBackColor = true;
            this.radioCriar.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "O que deseja?";
            // 
            // radioEditar
            // 
            this.radioEditar.AutoSize = true;
            this.radioEditar.Location = new System.Drawing.Point(32, 160);
            this.radioEditar.Name = "radioEditar";
            this.radioEditar.Size = new System.Drawing.Size(219, 17);
            this.radioEditar.TabIndex = 5;
            this.radioEditar.TabStop = true;
            this.radioEditar.Text = "Editar ou visualizar uma moeda existente:";
            this.radioEditar.UseVisualStyleBackColor = true;
            this.radioEditar.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // comboMoeda
            // 
            this.comboMoeda.Cotação = null;
            this.comboMoeda.DisplayMember = "Nome";
            this.comboMoeda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMoeda.FormattingEnabled = true;
            this.comboMoeda.Location = new System.Drawing.Point(257, 159);
            this.comboMoeda.Name = "comboMoeda";
            this.comboMoeda.Size = new System.Drawing.Size(121, 21);
            this.comboMoeda.TabIndex = 6;
            this.comboMoeda.SelectedIndexChanged += new System.EventHandler(this.comboMoeda_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(236, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(317, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // EscolherEdiçãoMoeda
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(404, 243);
            this.Controls.Add(this.radioCriar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboMoeda);
            this.Controls.Add(this.radioEditar);
            this.Name = "EscolherEdiçãoMoeda";
            this.Text = "Visualização/Edição de moeda";
            this.Controls.SetChildIndex(this.radioEditar, 0);
            this.Controls.SetChildIndex(this.comboMoeda, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.radioCriar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCriar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioEditar;
        private Apresentação.Mercadoria.Cotação.ComboMoeda comboMoeda;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
    }
}