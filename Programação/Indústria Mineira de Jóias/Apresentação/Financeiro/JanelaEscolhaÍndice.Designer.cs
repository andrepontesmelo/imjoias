namespace Apresentação.Financeiro
{
    partial class JanelaEscolhaÍndice
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
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.radioPersonalizado = new System.Windows.Forms.RadioButton();
            this.txtÍndice = new AMS.TextBox.NumericTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lnkEscolhaIndiceDetalhes = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.flow.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(150, 20);
            this.lblTítulo.Text = "Escolha do índice";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(185, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.repair;
            // 
            // flow
            // 
            this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow.AutoScroll = true;
            this.flow.Controls.Add(this.radioPersonalizado);
            this.flow.Controls.Add(this.txtÍndice);
            this.flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flow.Location = new System.Drawing.Point(6, 19);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(247, 167);
            this.flow.TabIndex = 3;
            // 
            // radioPersonalizado
            // 
            this.radioPersonalizado.AutoSize = true;
            this.radioPersonalizado.Location = new System.Drawing.Point(3, 3);
            this.radioPersonalizado.Name = "radioPersonalizado";
            this.radioPersonalizado.Size = new System.Drawing.Size(94, 17);
            this.radioPersonalizado.TabIndex = 0;
            this.radioPersonalizado.TabStop = true;
            this.radioPersonalizado.Text = "Personalizado:";
            this.radioPersonalizado.UseVisualStyleBackColor = true;
            this.radioPersonalizado.Click += new System.EventHandler(this.radioPersonalizado_Click);
            // 
            // txtÍndice
            // 
            this.txtÍndice.AllowNegative = true;
            this.txtÍndice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtÍndice.DigitsInGroup = 0;
            this.txtÍndice.Enabled = false;
            this.txtÍndice.Flags = 0;
            this.txtÍndice.Location = new System.Drawing.Point(3, 26);
            this.txtÍndice.MaxDecimalPlaces = 2;
            this.txtÍndice.MaxWholeDigits = 5;
            this.txtÍndice.Name = "txtÍndice";
            this.txtÍndice.Prefix = "";
            this.txtÍndice.RangeMax = 1.7976931348623157E+308D;
            this.txtÍndice.RangeMin = -1.7976931348623157E+308D;
            this.txtÍndice.Size = new System.Drawing.Size(94, 20);
            this.txtÍndice.TabIndex = 1;
            this.txtÍndice.Validated += new System.EventHandler(this.txtÍndice_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.flow);
            this.groupBox1.Location = new System.Drawing.Point(6, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 192);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Índices";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(111, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(192, 287);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lnkEscolhaIndiceDetalhes
            // 
            this.lnkEscolhaIndiceDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkEscolhaIndiceDetalhes.AutoSize = true;
            this.lnkEscolhaIndiceDetalhes.Location = new System.Drawing.Point(35, 315);
            this.lnkEscolhaIndiceDetalhes.Name = "lnkEscolhaIndiceDetalhes";
            this.lnkEscolhaIndiceDetalhes.Size = new System.Drawing.Size(232, 13);
            this.lnkEscolhaIndiceDetalhes.TabIndex = 7;
            this.lnkEscolhaIndiceDetalhes.TabStop = true;
            this.lnkEscolhaIndiceDetalhes.Text = "Informação adicional sobre índices disponíveis.";
            this.lnkEscolhaIndiceDetalhes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEscolhaIndiceDetalhes_LinkClicked);
            // 
            // JanelaEscolhaÍndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(273, 334);
            this.Controls.Add(this.lnkEscolhaIndiceDetalhes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "JanelaEscolhaÍndice";
            this.Text = "Escolha do índice";
            this.Load += new System.EventHandler(this.JanelaEscolhaÍndice_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lnkEscolhaIndiceDetalhes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.flow.ResumeLayout(false);
            this.flow.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton radioPersonalizado;
        private AMS.TextBox.NumericTextBox txtÍndice;
        private System.Windows.Forms.LinkLabel lnkEscolhaIndiceDetalhes;
    }
}