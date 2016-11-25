using Apresentação.Fiscal.Lista;

namespace Apresentação.Fiscal.BaseInferior.Documentos
{
    partial class BaseSaídas
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.esquerda.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Descrição = "Notas fiscais de saída de itens de inventário.";
            this.títuloBaseInferior1.Título = "Saídas";
            // 
            // opçãoNovo
            // 
            this.opçãoNovo.Descrição = "Nova saída";
            // 
            // quadroTipo
            // 
            this.quadroTipo.SeleçãoAlterada += new System.EventHandler(this.quadroTipo_SeleçãoAlterada);
            // 
            // comboFechamento
            // 
            this.comboFechamento.Location = new System.Drawing.Point(386, 51);
            this.comboFechamento.Size = new System.Drawing.Size(394, 22);
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 392);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(193, 79);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(587, 298);
            this.tabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BaseSaídas
            // 
            this.Controls.Add(this.tabControl);
            this.Name = "BaseSaídas";
            this.Size = new System.Drawing.Size(800, 392);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.comboFechamento, 0);
            this.esquerda.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
