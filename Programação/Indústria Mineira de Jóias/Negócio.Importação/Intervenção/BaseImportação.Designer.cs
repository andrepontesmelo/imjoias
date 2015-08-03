namespace Apresentação.Importação.Intervenção
{
    partial class BaseImportação
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseImportação));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.propriedades = new System.Windows.Forms.PropertyGrid();
            this.painel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabProfissão = new System.Windows.Forms.TabPage();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProfissão = new System.Windows.Forms.TextBox();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabProfissão.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.propriedades);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.painel);
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Size = new System.Drawing.Size(593, 367);
            this.splitContainer.SplitterDistance = 179;
            this.splitContainer.TabIndex = 0;
            // 
            // propriedades
            // 
            this.propriedades.CommandsVisibleIfAvailable = false;
            this.propriedades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propriedades.HelpVisible = false;
            this.propriedades.Location = new System.Drawing.Point(0, 0);
            this.propriedades.Name = "propriedades";
            this.propriedades.Size = new System.Drawing.Size(179, 367);
            this.propriedades.TabIndex = 0;
            // 
            // painel
            // 
            this.painel.AutoScroll = true;
            this.painel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painel.Location = new System.Drawing.Point(0, 0);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(410, 252);
            this.painel.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 115);
            this.panel1.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(323, 80);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(242, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabProfissão);
            this.tabControl.Location = new System.Drawing.Point(3, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(404, 74);
            this.tabControl.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtObs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(396, 48);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Observações";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabProfissão
            // 
            this.tabProfissão.Controls.Add(this.txtProfissão);
            this.tabProfissão.Controls.Add(this.label1);
            this.tabProfissão.Location = new System.Drawing.Point(4, 22);
            this.tabProfissão.Name = "tabProfissão";
            this.tabProfissão.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfissão.Size = new System.Drawing.Size(396, 48);
            this.tabProfissão.TabIndex = 1;
            this.tabProfissão.Text = "Profissão";
            this.tabProfissão.UseVisualStyleBackColor = true;
            // 
            // txtObs
            // 
            this.txtObs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObs.Location = new System.Drawing.Point(3, 3);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(390, 42);
            this.txtObs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profissão:";
            // 
            // txtProfissão
            // 
            this.txtProfissão.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfissão.Location = new System.Drawing.Point(65, 13);
            this.txtProfissão.Name = "txtProfissão";
            this.txtProfissão.Size = new System.Drawing.Size(325, 20);
            this.txtProfissão.TabIndex = 1;
            this.txtProfissão.Validated += new System.EventHandler(this.txtProfissão_Validated);
            // 
            // BaseImportação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 367);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseImportação";
            this.Text = "Intervenção na importação";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabProfissão.ResumeLayout(false);
            this.tabProfissão.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propriedades;
        protected System.Windows.Forms.SplitContainer splitContainer;
        protected System.Windows.Forms.Panel painel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.TabPage tabProfissão;
        private System.Windows.Forms.TextBox txtProfissão;
        private System.Windows.Forms.Label label1;
    }
}