namespace Apresentação.Financeiro.Indicadores
{
    partial class JanelaHistóricoCotação
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaHistóricoCotação));
            this.label1 = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.gráficoCotação = new Apresentação.Financeiro.Indicadores.GráficoCotação();
            this.btnFechar = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listaCotação = new Apresentação.Financeiro.Indicadores.ListaCotação();
            this.btnExcluír = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(76, 20);
            this.lblTítulo.Text = "Cotação";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(596, 48);
            this.lblDescrição.Text = "Este é o gráfico da evolução da cotação, atualizado pelo setor financeiro.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.dinheiro;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desde:";
            // 
            // data
            // 
            this.data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.data.Location = new System.Drawing.Point(59, 99);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(613, 20);
            this.data.TabIndex = 4;
            this.data.ValueChanged += new System.EventHandler(this.data_ValueChanged);
            // 
            // gráficoCotação
            // 
            this.gráficoCotação.BackColor = System.Drawing.Color.White;
            this.gráficoCotação.bInfDirArredondada = false;
            this.gráficoCotação.bInfEsqArredondada = false;
            this.gráficoCotação.bSupDirArredondada = false;
            this.gráficoCotação.bSupEsqArredondada = false;
            this.gráficoCotação.Cor = System.Drawing.SystemColors.ActiveBorder;
            this.gráficoCotação.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gráficoCotação.FundoTítulo = System.Drawing.SystemColors.ActiveCaption;
            this.gráficoCotação.LetraTítulo = System.Drawing.SystemColors.ActiveCaptionText;
            this.gráficoCotação.Location = new System.Drawing.Point(0, 0);
            this.gráficoCotação.Moeda = null;
            this.gráficoCotação.MostrarBotãoMinMax = false;
            this.gráficoCotação.Name = "gráficoCotação";
            this.gráficoCotação.PeríodoFinal = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.gráficoCotação.PeríodoInicial = new System.DateTime(2006, 4, 9, 9, 57, 16, 715);
            this.gráficoCotação.Size = new System.Drawing.Size(409, 348);
            this.gráficoCotação.TabIndex = 5;
            this.gráficoCotação.Tamanho = 10;
            this.gráficoCotação.Título = "Cotação do Ouro";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(597, 479);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 125);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gráficoCotação);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listaCotação);
            this.splitContainer.Size = new System.Drawing.Size(660, 348);
            this.splitContainer.SplitterDistance = 409;
            this.splitContainer.TabIndex = 7;
            // 
            // listaCotação
            // 
            this.listaCotação.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listaCotação.bInfDirArredondada = false;
            this.listaCotação.bInfEsqArredondada = false;
            this.listaCotação.bSupDirArredondada = false;
            this.listaCotação.bSupEsqArredondada = false;
            this.listaCotação.Cor = System.Drawing.SystemColors.ActiveCaption;
            this.listaCotação.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaCotação.FundoTítulo = System.Drawing.SystemColors.ActiveCaption;
            this.listaCotação.LetraTítulo = System.Drawing.SystemColors.ActiveCaptionText;
            this.listaCotação.Location = new System.Drawing.Point(0, 0);
            this.listaCotação.Moeda = null;
            this.listaCotação.MostrarBotãoMinMax = false;
            this.listaCotação.Name = "listaCotação";
            this.listaCotação.PeríodoFinal = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.listaCotação.PeríodoInicial = new System.DateTime(2006, 8, 13, 15, 58, 36, 175);
            this.listaCotação.Size = new System.Drawing.Size(247, 348);
            this.listaCotação.TabIndex = 0;
            this.listaCotação.Tamanho = 30;
            this.listaCotação.Título = "Lista de Cotação do Ouro";
            // 
            // btnExcluír
            // 
            this.btnExcluír.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluír.Location = new System.Drawing.Point(516, 479);
            this.btnExcluír.Name = "btnExcluír";
            this.btnExcluír.Size = new System.Drawing.Size(75, 23);
            this.btnExcluír.TabIndex = 8;
            this.btnExcluír.Text = "Excluir";
            this.btnExcluír.UseVisualStyleBackColor = true;
            this.btnExcluír.Click += new System.EventHandler(this.btnExcluír_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrar.Location = new System.Drawing.Point(435, 479);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 9;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // JanelaHistóricoCotação
            // 
            this.AcceptButton = this.btnFechar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(684, 514);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnExcluír);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "JanelaHistóricoCotação";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "Histórico de cotação";
            this.Controls.SetChildIndex(this.data, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnFechar, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.Controls.SetChildIndex(this.btnExcluír, 0);
            this.Controls.SetChildIndex(this.btnCadastrar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker data;
        private GráficoCotação gráficoCotação;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.SplitContainer splitContainer;
        private ListaCotação listaCotação;
        private System.Windows.Forms.Button btnExcluír;
        private System.Windows.Forms.Button btnCadastrar;
    }
}