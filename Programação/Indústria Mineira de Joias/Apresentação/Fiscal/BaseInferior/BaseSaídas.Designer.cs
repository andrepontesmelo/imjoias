using Apresentação.Fiscal.Lista;

namespace Apresentação.Fiscal.BaseInferior
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAtacado = new System.Windows.Forms.TabPage();
            this.tabVarejo = new System.Windows.Forms.TabPage();
            this.listaDocumentoSaída1 = new Apresentação.Fiscal.Lista.ListaDocumentoSaída();
            this.esquerda.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAtacado.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadroTipo
            // 
            this.quadroTipo.SeleçãoAlterada += new System.EventHandler(this.quadroTipo_SeleçãoAlterada);
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 392);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAtacado);
            this.tabControl1.Controls.Add(this.tabVarejo);
            this.tabControl1.Location = new System.Drawing.Point(193, 79);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 298);
            this.tabControl1.TabIndex = 7;
            // 
            // tabAtacado
            // 
            this.tabAtacado.Controls.Add(this.listaDocumentoSaída1);
            this.tabAtacado.Location = new System.Drawing.Point(4, 22);
            this.tabAtacado.Name = "tabAtacado";
            this.tabAtacado.Padding = new System.Windows.Forms.Padding(3);
            this.tabAtacado.Size = new System.Drawing.Size(495, 272);
            this.tabAtacado.TabIndex = 0;
            this.tabAtacado.Text = "Atacado";
            this.tabAtacado.UseVisualStyleBackColor = true;
            // 
            // tabVarejo
            // 
            this.tabVarejo.Location = new System.Drawing.Point(4, 22);
            this.tabVarejo.Name = "tabVarejo";
            this.tabVarejo.Padding = new System.Windows.Forms.Padding(3);
            this.tabVarejo.Size = new System.Drawing.Size(495, 272);
            this.tabVarejo.TabIndex = 1;
            this.tabVarejo.Text = "Varejo";
            this.tabVarejo.UseVisualStyleBackColor = true;
            // 
            // listaDocumentoSaída1
            // 
            this.listaDocumentoSaída1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaDocumentoSaída1.Location = new System.Drawing.Point(3, 3);
            this.listaDocumentoSaída1.Name = "listaDocumentoSaída1";
            this.listaDocumentoSaída1.Size = new System.Drawing.Size(489, 266);
            this.listaDocumentoSaída1.TabIndex = 0;
            // 
            // BaseSaídas
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "BaseSaídas";
            this.Size = new System.Drawing.Size(800, 392);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.esquerda.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAtacado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAtacado;
        private System.Windows.Forms.TabPage tabVarejo;
        private ListaDocumentoSaída listaDocumentoSaída1;
    }
}
