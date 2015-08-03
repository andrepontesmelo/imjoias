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
            this.tab.Controls.SetChildIndex(this.tabRepresentante, 0);
            // 
            // tabRepresentante
            // 
            this.tabRepresentante.Location = new System.Drawing.Point(4, 23);
            this.tabRepresentante.Name = "tabRepresentante";
            this.tabRepresentante.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepresentante.Size = new System.Drawing.Size(400, 413);
            this.tabRepresentante.TabIndex = 3;
            this.tabRepresentante.Text = "Representante";
            this.tabRepresentante.UseVisualStyleBackColor = true;
            // 
            // CadastroRepresentante
            // 
            this.ClientSize = new System.Drawing.Size(426, 488);
            this.Name = "CadastroRepresentante";
            this.Text = "Cadastro [Representante]";
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabRepresentante;
    }
}
