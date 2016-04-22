namespace Apresentação.Álbum.Edição.Álbuns
{
    partial class CadastroÁlbum
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioLinha = new System.Windows.Forms.RadioButton();
            this.radioTudo = new System.Windows.Forms.RadioButton();
            this.radioVazio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(160, 20);
            this.lblTítulo.Text = "Cadastro de álbum";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(188, 48);
            this.lblDescrição.Text = "Informe os dados para o cadastro do novo álbum";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = Resource._3228_icon;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 122);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(252, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Location = new System.Drawing.Point(12, 170);
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(252, 58);
            this.txtDescrição.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome do álbum:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(189, 344);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(108, 344);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioLinha);
            this.groupBox1.Controls.Add(this.radioTudo);
            this.groupBox1.Controls.Add(this.radioVazio);
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 101);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conteúdo inicial";
            // 
            // radioLinha
            // 
            this.radioLinha.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioLinha.Location = new System.Drawing.Point(6, 63);
            this.radioLinha.Name = "radioLinha";
            this.radioLinha.Size = new System.Drawing.Size(238, 32);
            this.radioLinha.TabIndex = 12;
            this.radioLinha.TabStop = true;
            this.radioLinha.Text = "Incluir somente as fotos de mercadorias que não sairam de linha";
            this.radioLinha.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioLinha.UseVisualStyleBackColor = true;
            // 
            // radioTudo
            // 
            this.radioTudo.AutoSize = true;
            this.radioTudo.Location = new System.Drawing.Point(6, 40);
            this.radioTudo.Name = "radioTudo";
            this.radioTudo.Size = new System.Drawing.Size(183, 17);
            this.radioTudo.TabIndex = 11;
            this.radioTudo.TabStop = true;
            this.radioTudo.Text = "Incluir todas as fotos cadastradas";
            this.radioTudo.UseVisualStyleBackColor = true;
            // 
            // radioVazio
            // 
            this.radioVazio.AutoSize = true;
            this.radioVazio.Checked = true;
            this.radioVazio.Location = new System.Drawing.Point(6, 17);
            this.radioVazio.Name = "radioVazio";
            this.radioVazio.Size = new System.Drawing.Size(105, 17);
            this.radioVazio.TabIndex = 10;
            this.radioVazio.TabStop = true;
            this.radioVazio.Text = "Criar álbum vazio";
            this.radioVazio.UseVisualStyleBackColor = true;
            // 
            // CadastroÁlbum
            // 
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(276, 379);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDescrição);
            this.Name = "CadastroÁlbum";
            this.Text = "Novo álbum";
            this.Load += new System.EventHandler(this.CadastroÁlbum_Load);
            this.Controls.SetChildIndex(this.txtDescrição, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioLinha;
        private System.Windows.Forms.RadioButton radioTudo;
        private System.Windows.Forms.RadioButton radioVazio;

    }
}
