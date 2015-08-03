namespace Apresentação.Importação.Intervenção
{
    partial class QuestionarDevedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionarDevedor));
            this.label1 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.classificador = new Apresentação.Pessoa.Cadastro.Classificador();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 83);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(24, 108);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ReadOnly = true;
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObs.Size = new System.Drawing.Size(309, 79);
            this.txtObs.TabIndex = 1;
            // 
            // classificador
            // 
            this.classificador.AutoAtualizarBD = true;
            this.classificador.Location = new System.Drawing.Point(26, 221);
            this.classificador.Name = "classificador";
            this.classificador.Pessoa = null;
            this.classificador.Size = new System.Drawing.Size(307, 100);
            this.classificador.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(187, 364);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(268, 364);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // QuestionarDevedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 399);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.classificador);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionarDevedor";
            this.Text = "Importação de cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObs;
        private Apresentação.Pessoa.Cadastro.Classificador classificador;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}