namespace Apresentação.Financeiro.Coaf
{
    partial class BaseNotificação
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseNotificação));
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.split = new System.Windows.Forms.SplitContainer();
            this.listaSaída = new Apresentação.Financeiro.Coaf.Lista.ListaSaída();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Size = new System.Drawing.Size(187, 478);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Documentos de notificação";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.notificacao;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(705, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Notificações";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.ImageList = this.imageList1;
            this.tabControl.Location = new System.Drawing.Point(193, 83);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(720, 383);
            this.tabControl.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.split);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sumário";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(3, 3);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.listaSaída);
            this.split.Size = new System.Drawing.Size(706, 350);
            this.split.SplitterDistance = 256;
            this.split.TabIndex = 10;
            // 
            // listaSaída
            // 
            this.listaSaída.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaSaída.Location = new System.Drawing.Point(0, 0);
            this.listaSaída.Name = "listaSaída";
            this.listaSaída.Size = new System.Drawing.Size(706, 90);
            this.listaSaída.TabIndex = 9;
            this.listaSaída.DuploClique += new System.EventHandler(this.listaSaída_DuploClique);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chamando atenção.gif");
            this.imageList1.Images.SetKeyName(1, "info.png");
            // 
            // BaseNotificação
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.título);
            this.Name = "BaseNotificação";
            this.Size = new System.Drawing.Size(916, 478);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Formulários.TítuloBaseInferior título;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer split;
        private Lista.ListaSaída listaSaída;
    }
}
