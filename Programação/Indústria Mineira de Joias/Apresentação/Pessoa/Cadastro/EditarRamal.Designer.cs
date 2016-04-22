namespace Apresentação.Pessoa.Cadastro
{
    partial class EditarRamal
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFuncionário = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRamal = new AMS.TextBox.IntegerTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(144, 20);
            this.lblTítulo.Text = "Ramal telefônico";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Entre com o ramal telefônico para contactar o funcionário abaixo.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.botão___telefone;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Funcionário:";
            // 
            // txtFuncionário
            // 
            this.txtFuncionário.Location = new System.Drawing.Point(100, 111);
            this.txtFuncionário.Name = "txtFuncionário";
            this.txtFuncionário.ReadOnly = true;
            this.txtFuncionário.Size = new System.Drawing.Size(246, 20);
            this.txtFuncionário.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ramal:";
            // 
            // txtRamal
            // 
            this.txtRamal.AllowNegative = true;
            this.txtRamal.DigitsInGroup = 0;
            this.txtRamal.Flags = 0;
            this.txtRamal.Location = new System.Drawing.Point(100, 137);
            this.txtRamal.MaxDecimalPlaces = 0;
            this.txtRamal.MaxWholeDigits = 9;
            this.txtRamal.Name = "txtRamal";
            this.txtRamal.Prefix = "";
            this.txtRamal.RangeMax = 1.7976931348623157E+308;
            this.txtRamal.RangeMin = 0;
            this.txtRamal.Size = new System.Drawing.Size(72, 20);
            this.txtRamal.TabIndex = 0;
            this.txtRamal.Text = "1";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(222, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(303, 163);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // EditarRamal
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 198);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRamal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtFuncionário);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Name = "EditarRamal";
            this.Text = "Ramal telefônico";
            this.Load += new System.EventHandler(this.EditarRamal_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.txtFuncionário, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtRamal, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFuncionário;
        private System.Windows.Forms.Label label2;
        private AMS.TextBox.IntegerTextBox txtRamal;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}
