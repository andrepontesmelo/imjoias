namespace Apresentação.Financeiro.Cotação
{
    partial class DadosCotação
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
            this.picMoeda = new System.Windows.Forms.PictureBox();
            this.lnkVisualizar = new System.Windows.Forms.LinkLabel();
            this.lnkAtualizar = new System.Windows.Forms.LinkLabel();
            this.txtCotação = new AMS.TextBox.NumericTextBox();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.lblCotação = new System.Windows.Forms.Label();
            this.picVariação = new System.Windows.Forms.PictureBox();
            this.lblVariação = new System.Windows.Forms.Label();
            this.lblAtualização = new System.Windows.Forms.Label();
            this.lnkCancelar = new System.Windows.Forms.LinkLabel();
            this.lblValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMoeda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVariação)).BeginInit();
            this.SuspendLayout();
            // 
            // picMoeda
            // 
            this.picMoeda.BackColor = System.Drawing.Color.Transparent;
            this.picMoeda.Image = global::Apresentação.Resource.moeda;
            this.picMoeda.Location = new System.Drawing.Point(3, 3);
            this.picMoeda.Name = "picMoeda";
            this.picMoeda.Size = new System.Drawing.Size(49, 49);
            this.picMoeda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMoeda.TabIndex = 8;
            this.picMoeda.TabStop = false;
            // 
            // lnkVisualizar
            // 
            this.lnkVisualizar.AutoSize = true;
            this.lnkVisualizar.BackColor = System.Drawing.Color.Transparent;
            this.lnkVisualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkVisualizar.Location = new System.Drawing.Point(4, 69);
            this.lnkVisualizar.Name = "lnkVisualizar";
            this.lnkVisualizar.Size = new System.Drawing.Size(83, 12);
            this.lnkVisualizar.TabIndex = 7;
            this.lnkVisualizar.TabStop = true;
            this.lnkVisualizar.Text = "Visualizar histórico";
            this.lnkVisualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVisualizar_LinkClicked);
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAtualizar.BackColor = System.Drawing.Color.Transparent;
            this.lnkAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAtualizar.Location = new System.Drawing.Point(157, 69);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(47, 12);
            this.lnkAtualizar.TabIndex = 6;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Editar";
            this.lnkAtualizar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
            // 
            // txtCotação
            // 
            this.txtCotação.AllowNegative = false;
            this.txtCotação.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCotação.BackColor = System.Drawing.SystemColors.Control;
            this.txtCotação.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCotação.DigitsInGroup = 3;
            this.txtCotação.Flags = 73216;
            this.txtCotação.Location = new System.Drawing.Point(114, 20);
            this.txtCotação.MaxDecimalPlaces = 4;
            this.txtCotação.MaxWholeDigits = 9;
            this.txtCotação.Name = "txtCotação";
            this.txtCotação.Prefix = "";
            this.txtCotação.RangeMax = 1.7976931348623157E+308;
            this.txtCotação.RangeMin = -1.7976931348623157E+308;
            this.txtCotação.Size = new System.Drawing.Size(90, 13);
            this.txtCotação.TabIndex = 5;
            this.txtCotação.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCotação.Visible = false;
            this.txtCotação.Enter += new System.EventHandler(this.txtCotação_Enter);
            this.txtCotação.Leave += new System.EventHandler(this.txtCotação_Leave);
            this.txtCotação.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCotação_KeyUp);
            this.txtCotação.TextChanged += new System.EventHandler(this.txtCotação_TextChanged);
            // 
            // lblMoeda
            // 
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.BackColor = System.Drawing.Color.Transparent;
            this.lblMoeda.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoeda.Location = new System.Drawing.Point(58, 3);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(50, 14);
            this.lblMoeda.TabIndex = 9;
            this.lblMoeda.Text = "Moeda";
            // 
            // lblCotação
            // 
            this.lblCotação.AutoSize = true;
            this.lblCotação.BackColor = System.Drawing.Color.Transparent;
            this.lblCotação.Location = new System.Drawing.Point(58, 20);
            this.lblCotação.Name = "lblCotação";
            this.lblCotação.Size = new System.Drawing.Size(50, 13);
            this.lblCotação.TabIndex = 10;
            this.lblCotação.Text = "Cotação:";
            // 
            // picVariação
            // 
            this.picVariação.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picVariação.BackColor = System.Drawing.Color.Transparent;
            this.picVariação.Image = global::Apresentação.Resource.VariaçãoPositiva;
            this.picVariação.Location = new System.Drawing.Point(188, 36);
            this.picVariação.Name = "picVariação";
            this.picVariação.Size = new System.Drawing.Size(16, 16);
            this.picVariação.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVariação.TabIndex = 13;
            this.picVariação.TabStop = false;
            // 
            // lblVariação
            // 
            this.lblVariação.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVariação.BackColor = System.Drawing.Color.Transparent;
            this.lblVariação.ForeColor = System.Drawing.Color.Green;
            this.lblVariação.Location = new System.Drawing.Point(58, 36);
            this.lblVariação.Name = "lblVariação";
            this.lblVariação.Size = new System.Drawing.Size(131, 16);
            this.lblVariação.TabIndex = 14;
            this.lblVariação.Text = "+99,99%";
            this.lblVariação.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAtualização
            // 
            this.lblAtualização.AutoSize = true;
            this.lblAtualização.BackColor = System.Drawing.Color.Transparent;
            this.lblAtualização.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtualização.Location = new System.Drawing.Point(4, 57);
            this.lblAtualização.Name = "lblAtualização";
            this.lblAtualização.Size = new System.Drawing.Size(197, 12);
            this.lblAtualização.TabIndex = 15;
            this.lblAtualização.Text = "Atualizado por XXXXXXX XXXX em 10/02/1999";
            // 
            // lnkCancelar
            // 
            this.lnkCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCancelar.AutoSize = true;
            this.lnkCancelar.BackColor = System.Drawing.Color.Transparent;
            this.lnkCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCancelar.Location = new System.Drawing.Point(112, 69);
            this.lnkCancelar.Name = "lnkCancelar";
            this.lnkCancelar.Size = new System.Drawing.Size(42, 12);
            this.lnkCancelar.TabIndex = 16;
            this.lnkCancelar.TabStop = true;
            this.lnkCancelar.Text = "Cancelar";
            this.lnkCancelar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lnkCancelar.Visible = false;
            this.lnkCancelar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancelar_LinkClicked);
            // 
            // lblValor
            // 
            this.lblValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValor.BackColor = System.Drawing.Color.Transparent;
            this.lblValor.Location = new System.Drawing.Point(114, 20);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(90, 13);
            this.lblValor.TabIndex = 17;
            this.lblValor.Text = "Lbl sobre Txt";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DadosCotação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lnkCancelar);
            this.Controls.Add(this.picVariação);
            this.Controls.Add(this.lblVariação);
            this.Controls.Add(this.lblCotação);
            this.Controls.Add(this.lblMoeda);
            this.Controls.Add(this.txtCotação);
            this.Controls.Add(this.lnkAtualizar);
            this.Controls.Add(this.lnkVisualizar);
            this.Controls.Add(this.picMoeda);
            this.Controls.Add(this.lblAtualização);
            this.MaximumSize = new System.Drawing.Size(207, 84);
            this.MinimumSize = new System.Drawing.Size(207, 84);
            this.Name = "DadosCotação";
            this.Size = new System.Drawing.Size(207, 84);
            ((System.ComponentModel.ISupportInitialize)(this.picMoeda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVariação)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkAtualizar;
        private AMS.TextBox.NumericTextBox txtCotação;
        private System.Windows.Forms.LinkLabel lnkVisualizar;
        private System.Windows.Forms.PictureBox picMoeda;
        private System.Windows.Forms.Label lblMoeda;
        private System.Windows.Forms.Label lblCotação;
        private System.Windows.Forms.PictureBox picVariação;
        private System.Windows.Forms.Label lblVariação;
        private System.Windows.Forms.Label lblAtualização;
        private System.Windows.Forms.LinkLabel lnkCancelar;
        private System.Windows.Forms.Label lblValor;

    }
}
