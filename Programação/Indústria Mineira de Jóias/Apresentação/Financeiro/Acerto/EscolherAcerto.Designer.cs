namespace Apresentação.Financeiro.Acerto
{
    partial class EscolherAcerto
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
            this.lblInstrução = new System.Windows.Forms.Label();
            this.dadosAcerto = new Apresentação.Financeiro.Acerto.DadosAcerto();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstAcertos = new System.Windows.Forms.ListView();
            this.colCódigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrevisão = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.botãoLiberarAcertosAntigos = new Apresentação.Formulários.BotãoLiberarRecurso();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(184, 20);
            this.lblTítulo.Text = "Acerto de consignado";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(507, 48);
            this.lblDescrição.Text = "Escolha quando será feito o acerto referente ao documento que está sendo registra" +
    "do.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.Acerto;
            this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // lblInstrução
            // 
            this.lblInstrução.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstrução.Location = new System.Drawing.Point(17, 103);
            this.lblInstrução.Name = "lblInstrução";
            this.lblInstrução.Size = new System.Drawing.Size(564, 31);
            this.lblInstrução.TabIndex = 3;
            this.lblInstrução.Text = "Escolha com qual acerto de {0} você deseja trabalhar.";
            this.lblInstrução.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dadosAcerto
            // 
            this.dadosAcerto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dadosAcerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dadosAcerto.bInfDirArredondada = true;
            this.dadosAcerto.bInfEsqArredondada = true;
            this.dadosAcerto.bSupDirArredondada = true;
            this.dadosAcerto.bSupEsqArredondada = true;
            this.dadosAcerto.Cor = System.Drawing.Color.Black;
            this.dadosAcerto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.dadosAcerto.LetraTítulo = System.Drawing.Color.White;
            this.dadosAcerto.Location = new System.Drawing.Point(339, 3);
            this.dadosAcerto.MinimumSize = new System.Drawing.Size(221, 226);
            this.dadosAcerto.MostrarBotãoMinMax = false;
            this.dadosAcerto.Name = "dadosAcerto";
            this.dadosAcerto.Size = new System.Drawing.Size(221, 313);
            this.dadosAcerto.TabIndex = 4;
            this.dadosAcerto.Tamanho = 30;
            this.dadosAcerto.Título = "Informações - Acerto";
            this.dadosAcerto.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lstAcertos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dadosAcerto, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 137);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 320);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lstAcertos
            // 
            this.lstAcertos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAcertos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCódigo,
            this.colPrevisão});
            this.lstAcertos.FullRowSelect = true;
            this.lstAcertos.Location = new System.Drawing.Point(3, 3);
            this.lstAcertos.Name = "lstAcertos";
            this.lstAcertos.Size = new System.Drawing.Size(330, 314);
            this.lstAcertos.TabIndex = 7;
            this.lstAcertos.UseCompatibleStateImageBehavior = false;
            this.lstAcertos.View = System.Windows.Forms.View.Details;
            this.lstAcertos.SelectedIndexChanged += new System.EventHandler(this.lstAcertos_SelectedIndexChanged);
            this.lstAcertos.DoubleClick += new System.EventHandler(this.lstAcertos_DoubleClick);
            // 
            // colCódigo
            // 
            this.colCódigo.Text = "Código";
            this.colCódigo.Width = 75;
            // 
            // colPrevisão
            // 
            this.colPrevisão.Text = "Previsão";
            this.colPrevisão.Width = 222;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(427, 472);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(508, 472);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnNovo.Image = global::Apresentação.Resource.novo;
            this.btnNovo.Location = new System.Drawing.Point(149, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(111, 23);
            this.btnNovo.TabIndex = 10;
            this.btnNovo.Text = "Criar novo acerto";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // botãoLiberarAcertosAntigos
            // 
            this.botãoLiberarAcertosAntigos.AutoSize = true;
            this.botãoLiberarAcertosAntigos.Descrição = null;
            this.botãoLiberarAcertosAntigos.Location = new System.Drawing.Point(3, 3);
            this.botãoLiberarAcertosAntigos.Name = "botãoLiberarAcertosAntigos";
            this.botãoLiberarAcertosAntigos.Privilégios = Entidades.Privilégio.Permissão.Nenhuma;
            this.botãoLiberarAcertosAntigos.Recurso = null;
            this.botãoLiberarAcertosAntigos.Size = new System.Drawing.Size(140, 23);
            this.botãoLiberarAcertosAntigos.TabIndex = 11;
            this.botãoLiberarAcertosAntigos.Texto = "Mostrar acertos antigos";
            this.botãoLiberarAcertosAntigos.LiberarRecurso += new System.EventHandler(this.botãoLiberarAcertosAntigos_LiberarRecurso);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.botãoLiberarAcertosAntigos);
            this.flowLayoutPanel1.Controls.Add(this.btnNovo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 466);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(263, 29);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // EscolherAcerto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 507);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblInstrução);
            this.KeyPreview = true;
            this.Name = "EscolherAcerto";
            this.Text = "Escolher acerto";
            this.Controls.SetChildIndex(this.lblInstrução, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstrução;
        private Apresentação.Financeiro.Acerto.DadosAcerto dadosAcerto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ListView lstAcertos;
        private System.Windows.Forms.ColumnHeader colCódigo;
        private System.Windows.Forms.ColumnHeader colPrevisão;
        private Apresentação.Formulários.BotãoLiberarRecurso botãoLiberarAcertosAntigos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}