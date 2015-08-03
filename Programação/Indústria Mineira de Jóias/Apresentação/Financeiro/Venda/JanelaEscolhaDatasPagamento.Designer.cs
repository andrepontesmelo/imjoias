namespace Apresentação.Financeiro.Venda
{
    partial class JanelaEscolhaDatasPagamento
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstDatas = new System.Windows.Forms.ListBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnRemoveData = new System.Windows.Forms.Button();
            this.btnAdicionarData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(148, 20);
            this.lblTítulo.Text = "Escolha de datas";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(388, 48);
            this.lblDescrição.Text = "Utilite o duplo clique nos dias para incluí-los na lista.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Resource.calendário___inclinado;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAdicionarData);
            this.groupBox1.Controls.Add(this.btnRemoveData);
            this.groupBox1.Controls.Add(this.lstDatas);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Location = new System.Drawing.Point(2, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 199);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Escolha da data:";
            // 
            // lstDatas
            // 
            this.lstDatas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDatas.FormattingEnabled = true;
            this.lstDatas.Location = new System.Drawing.Point(281, 25);
            this.lstDatas.Name = "lstDatas";
            this.lstDatas.Size = new System.Drawing.Size(178, 160);
            this.lstDatas.TabIndex = 1;
            this.lstDatas.SelectedIndexChanged += new System.EventHandler(this.lstDatas_SelectedIndexChanged);
            this.lstDatas.DoubleClick += new System.EventHandler(this.lstDatas_DoubleClick);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(16, 25);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(386, 308);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnRemoveData
            // 
            this.btnRemoveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveData.Location = new System.Drawing.Point(250, 80);
            this.btnRemoveData.Name = "btnRemoveData";
            this.btnRemoveData.Size = new System.Drawing.Size(25, 23);
            this.btnRemoveData.TabIndex = 2;
            this.btnRemoveData.Text = "<";
            this.btnRemoveData.UseVisualStyleBackColor = true;
            this.btnRemoveData.Click += new System.EventHandler(this.btnRemoveData_Click);
            // 
            // btnAdicionarData
            // 
            this.btnAdicionarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarData.Location = new System.Drawing.Point(250, 109);
            this.btnAdicionarData.Name = "btnAdicionarData";
            this.btnAdicionarData.Size = new System.Drawing.Size(25, 23);
            this.btnAdicionarData.TabIndex = 3;
            this.btnAdicionarData.Text = ">";
            this.btnAdicionarData.UseVisualStyleBackColor = true;
            this.btnAdicionarData.Click += new System.EventHandler(this.btnAdicionarData_Click);
            // 
            // JanelaEscolhaDatasPagamento
            // 
            this.AcceptButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(476, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFechar);
            this.Name = "JanelaEscolhaDatasPagamento";
            this.Text = "Escolha de datas";
            this.Controls.SetChildIndex(this.btnFechar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstDatas;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnRemoveData;
        private System.Windows.Forms.Button btnAdicionarData;
    }
}
