using Entidades.Pessoa;
namespace Apresentação.Pessoa.Cadastro
{
    partial class CadastroRepresentante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroRepresentante));
            this.tabRepresentante = new System.Windows.Forms.TabPage();
            this.tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabRepresentante);
            this.tab.Size = new System.Drawing.Size(408, 441);
            this.tab.Controls.SetChildIndex(this.tabRepresentante, 0);
            // 
            // ícones
            // 
            this.ícones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ícones.ImageStream")));
            this.ícones.Images.SetKeyName(0, "Dados Pessoais");
            this.ícones.Images.SetKeyName(1, "Endereço");
            this.ícones.Images.SetKeyName(2, "Observações");
            this.ícones.Images.SetKeyName(3, "Grupos");
            this.ícones.Images.SetKeyName(4, "Telefone");
            this.ícones.Images.SetKeyName(5, "Calendário");
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(256, 458);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(337, 458);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(8, 458);
            // 
            // tabRepresentante
            // 
            this.tabRepresentante.Location = new System.Drawing.Point(4, 42);
            this.tabRepresentante.Name = "tabRepresentante";
            this.tabRepresentante.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepresentante.Size = new System.Drawing.Size(400, 435);
            this.tabRepresentante.TabIndex = 3;
            this.tabRepresentante.Text = "Representante";
            this.tabRepresentante.UseVisualStyleBackColor = true;
            // 
            // CadastroRepresentante
            // 
            this.ClientSize = new System.Drawing.Size(426, 490);
            this.Name = "CadastroRepresentante";
            this.Text = "Cadastro [Representante]";
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabRepresentante;
    }
}
