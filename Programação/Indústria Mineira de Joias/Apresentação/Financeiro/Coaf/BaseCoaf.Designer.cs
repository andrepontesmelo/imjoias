namespace Apresentação.Financeiro.Coaf
{
    partial class BaseCoaf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseCoaf));
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoImportar = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.opçãoConfigurar = new Apresentação.Formulários.Opção();
            this.listaPessoa = new Apresentação.Financeiro.Coaf.Lista.ListaPessoa();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.split = new System.Windows.Forms.SplitContainer();
            this.listaSaída = new Apresentação.Financeiro.Coaf.Lista.ListaSaída();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.opçãoNotificação = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro2);
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 478);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            this.esquerda.Controls.SetChildIndex(this.quadro2, 0);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Operações de saídas fiscais acumuladas nos últimos 6 mêses. Este relatório implem" +
    "enta a resolução 23 de 20 de Dezembro de 2012 da COAF. PEP: Pessoa exposta polít" +
    "icamente.";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = global::Apresentação.Resource.Logo_COAF;
            this.título.Location = new System.Drawing.Point(193, 3);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(705, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Relatório Coaf ";
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoImportar);
            this.quadro1.Controls.Add(this.opçãoImprimir);
            this.quadro1.Controls.Add(this.opçãoConfigurar);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 107);
            this.quadro1.TabIndex = 7;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Ações";
            // 
            // opçãoImportar
            // 
            this.opçãoImportar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImportar.Descrição = "Importar CSV de pessoas politicamente expostas";
            this.opçãoImportar.Imagem = global::Apresentação.Resource.importar21;
            this.opçãoImportar.Location = new System.Drawing.Point(7, 70);
            this.opçãoImportar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImportar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImportar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImportar.Name = "opçãoImportar";
            this.opçãoImportar.Size = new System.Drawing.Size(150, 32);
            this.opçãoImportar.TabIndex = 10;
            this.opçãoImportar.Click += new System.EventHandler(this.opçãoImportar_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Resource.impressora__altura_58_;
            this.opçãoImprimir.Location = new System.Drawing.Point(7, 50);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 18);
            this.opçãoImprimir.TabIndex = 8;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // opçãoConfigurar
            // 
            this.opçãoConfigurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoConfigurar.Descrição = "Configurar";
            this.opçãoConfigurar.Imagem = global::Apresentação.Resource.repair;
            this.opçãoConfigurar.Location = new System.Drawing.Point(7, 30);
            this.opçãoConfigurar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoConfigurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoConfigurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoConfigurar.Name = "opçãoConfigurar";
            this.opçãoConfigurar.Size = new System.Drawing.Size(150, 16);
            this.opçãoConfigurar.TabIndex = 9;
            this.opçãoConfigurar.Click += new System.EventHandler(this.opçãoConfigurar_Click);
            // 
            // listaPessoa
            // 
            this.listaPessoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaPessoa.Location = new System.Drawing.Point(0, 0);
            this.listaPessoa.Name = "listaPessoa";
            this.listaPessoa.Size = new System.Drawing.Size(706, 256);
            this.listaPessoa.TabIndex = 8;
            this.listaPessoa.DuploClique += new System.EventHandler(this.listaPessoa_DuploClique);
            this.listaPessoa.SeleçãoAlterada += new System.EventHandler(this.listaPessoa_SeleçãoAlterada);
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
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.listaPessoa);
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
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.opçãoNotificação);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(7, 126);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(160, 53);
            this.quadro2.TabIndex = 8;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Notificações";
            // 
            // opçãoNotificação
            // 
            this.opçãoNotificação.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNotificação.Descrição = "Notificações";
            this.opçãoNotificação.Imagem = global::Apresentação.Resource.notificacao;
            this.opçãoNotificação.Location = new System.Drawing.Point(7, 30);
            this.opçãoNotificação.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNotificação.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNotificação.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNotificação.Name = "opçãoNotificação";
            this.opçãoNotificação.Size = new System.Drawing.Size(150, 16);
            this.opçãoNotificação.TabIndex = 9;
            this.opçãoNotificação.Click += new System.EventHandler(this.opçãoNotificação_Click);
            // 
            // BaseCoaf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.título);
            this.Name = "BaseCoaf";
            this.Size = new System.Drawing.Size(916, 478);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoImprimir;
        private Formulários.Opção opçãoConfigurar;
        private Formulários.TítuloBaseInferior título;
        private Lista.ListaPessoa listaPessoa;
        private Formulários.Opção opçãoImportar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer split;
        private Lista.ListaSaída listaSaída;
        private Formulários.Quadro quadro2;
        private Formulários.Opção opçãoNotificação;
    }
}
