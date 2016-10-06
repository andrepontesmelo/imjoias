namespace Apresentação.Fiscal
{
    partial class JanelaImportação
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkEntradaXMLAtacado = new System.Windows.Forms.CheckBox();
            this.chkSaídaTDMVarejo = new System.Windows.Forms.CheckBox();
            this.chkSaídaPDFAtacado = new System.Windows.Forms.CheckBox();
            this.chkSaídaXMLAtacado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPasta = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(77, 20);
            this.lblTítulo.Text = "Importar";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Inicia processo de importação em lote dos arquivos fiscais.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.importar21;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(303, 303);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciar.Location = new System.Drawing.Point(222, 303);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(51, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 22);
            this.textBox1.TabIndex = 5;
            // 
            // chkEntradaXMLAtacado
            // 
            this.chkEntradaXMLAtacado.AutoSize = true;
            this.chkEntradaXMLAtacado.Location = new System.Drawing.Point(51, 171);
            this.chkEntradaXMLAtacado.Name = "chkEntradaXMLAtacado";
            this.chkEntradaXMLAtacado.Size = new System.Drawing.Size(105, 17);
            this.chkEntradaXMLAtacado.TabIndex = 6;
            this.chkEntradaXMLAtacado.Text = "XML @ Atacado";
            this.chkEntradaXMLAtacado.UseVisualStyleBackColor = true;
            // 
            // chkSaídaTDMVarejo
            // 
            this.chkSaídaTDMVarejo.AutoSize = true;
            this.chkSaídaTDMVarejo.Location = new System.Drawing.Point(51, 259);
            this.chkSaídaTDMVarejo.Name = "chkSaídaTDMVarejo";
            this.chkSaídaTDMVarejo.Size = new System.Drawing.Size(97, 17);
            this.chkSaídaTDMVarejo.TabIndex = 8;
            this.chkSaídaTDMVarejo.Text = "TDM @ Varejo";
            this.chkSaídaTDMVarejo.UseVisualStyleBackColor = true;
            // 
            // chkSaídaPDFAtacado
            // 
            this.chkSaídaPDFAtacado.AutoSize = true;
            this.chkSaídaPDFAtacado.Location = new System.Drawing.Point(51, 237);
            this.chkSaídaPDFAtacado.Name = "chkSaídaPDFAtacado";
            this.chkSaídaPDFAtacado.Size = new System.Drawing.Size(104, 17);
            this.chkSaídaPDFAtacado.TabIndex = 9;
            this.chkSaídaPDFAtacado.Text = "PDF @ Atacado";
            this.chkSaídaPDFAtacado.UseVisualStyleBackColor = true;
            // 
            // chkSaídaXMLAtacado
            // 
            this.chkSaídaXMLAtacado.AutoSize = true;
            this.chkSaídaXMLAtacado.Location = new System.Drawing.Point(51, 215);
            this.chkSaídaXMLAtacado.Name = "chkSaídaXMLAtacado";
            this.chkSaídaXMLAtacado.Size = new System.Drawing.Size(105, 17);
            this.chkSaídaXMLAtacado.TabIndex = 10;
            this.chkSaídaXMLAtacado.Text = "XML @ Atacado";
            this.chkSaídaXMLAtacado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Entrada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Saída";
            // 
            // btnPasta
            // 
            this.btnPasta.BackgroundImage = global::Apresentação.Resource.folderopen1;
            this.btnPasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPasta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasta.Location = new System.Drawing.Point(20, 110);
            this.btnPasta.Name = "btnPasta";
            this.btnPasta.Size = new System.Drawing.Size(24, 24);
            this.btnPasta.TabIndex = 13;
            // 
            // JanelaImportação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 338);
            this.Controls.Add(this.btnPasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSaídaXMLAtacado);
            this.Controls.Add(this.chkSaídaPDFAtacado);
            this.Controls.Add(this.chkSaídaTDMVarejo);
            this.Controls.Add(this.chkEntradaXMLAtacado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "JanelaImportação";
            this.Text = "Importação";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnIniciar, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.chkEntradaXMLAtacado, 0);
            this.Controls.SetChildIndex(this.chkSaídaTDMVarejo, 0);
            this.Controls.SetChildIndex(this.chkSaídaPDFAtacado, 0);
            this.Controls.SetChildIndex(this.chkSaídaXMLAtacado, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnPasta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkEntradaXMLAtacado;
        private System.Windows.Forms.CheckBox chkSaídaTDMVarejo;
        private System.Windows.Forms.CheckBox chkSaídaPDFAtacado;
        private System.Windows.Forms.CheckBox chkSaídaXMLAtacado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel btnPasta;
    }
}