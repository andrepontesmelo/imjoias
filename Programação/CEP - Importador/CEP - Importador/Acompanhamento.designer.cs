namespace Importador
{
    partial class Acompanhamento
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
            this.components = new System.ComponentModel.Container();
            this.lblOrigem = new System.Windows.Forms.Label();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.progresso = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tmrAtualizar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Location = new System.Drawing.Point(9, 16);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(78, 13);
            this.lblOrigem.TabIndex = 0;
            this.lblOrigem.Text = "Importando de:";
            // 
            // txtOrigem
            // 
            this.txtOrigem.Location = new System.Drawing.Point(12, 32);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.ReadOnly = true;
            this.txtOrigem.Size = new System.Drawing.Size(297, 20);
            this.txtOrigem.TabIndex = 1;
            // 
            // progresso
            // 
            this.progresso.Location = new System.Drawing.Point(15, 71);
            this.progresso.Name = "progresso";
            this.progresso.Size = new System.Drawing.Size(294, 23);
            this.progresso.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Progresso:";
            // 
            // lblProgresso
            // 
            this.lblProgresso.Location = new System.Drawing.Point(78, 55);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(231, 13);
            this.lblProgresso.TabIndex = 6;
            this.lblProgresso.Text = "Iniciando...";
            this.lblProgresso.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(234, 105);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tmrAtualizar
            // 
            this.tmrAtualizar.Enabled = true;
            this.tmrAtualizar.Interval = 1000;
            this.tmrAtualizar.Tick += new System.EventHandler(this.tmrAtualizar_Tick);
            // 
            // Acompanhamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(321, 136);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progresso);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.lblOrigem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Acompanhamento";
            this.Text = "Importação de CEP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.ProgressBar progresso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Timer tmrAtualizar;
    }
}

