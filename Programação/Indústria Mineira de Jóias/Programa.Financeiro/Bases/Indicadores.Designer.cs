namespace Programa.Financeiro.Bases
{
    partial class Indicadores
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
            this.gráficoCotaçãoOuro1 = new Apresentação.Financeiro.Indicadores.GráficoCotação();
            this.listaCotaçãoOuro1 = new Apresentação.Financeiro.Indicadores.ListaCotação();
            this.quadroCotação = new Apresentação.Formulários.Quadro();
            this.opçãoRegistrarOuro = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadroCotação.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroCotação);
            // 
            // gráficoCotaçãoOuro1
            // 
            this.gráficoCotaçãoOuro1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gráficoCotaçãoOuro1.BackColor = System.Drawing.Color.White;
            this.gráficoCotaçãoOuro1.bInfDirArredondada = true;
            this.gráficoCotaçãoOuro1.bInfEsqArredondada = true;
            this.gráficoCotaçãoOuro1.bSupDirArredondada = true;
            this.gráficoCotaçãoOuro1.bSupEsqArredondada = true;
            this.gráficoCotaçãoOuro1.Cor = System.Drawing.Color.Black;
            this.gráficoCotaçãoOuro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.gráficoCotaçãoOuro1.LetraTítulo = System.Drawing.Color.White;
            this.gráficoCotaçãoOuro1.Location = new System.Drawing.Point(202, 15);
            this.gráficoCotaçãoOuro1.MostrarBotãoMinMax = false;
            this.gráficoCotaçãoOuro1.Name = "gráficoCotaçãoOuro1";
            this.gráficoCotaçãoOuro1.PeríodoFinal = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.gráficoCotaçãoOuro1.PeríodoInicial = new System.DateTime(2005, 9, 21, 3, 10, 31, 718);
            this.gráficoCotaçãoOuro1.Size = new System.Drawing.Size(286, 265);
            this.gráficoCotaçãoOuro1.TabIndex = 0;
            this.gráficoCotaçãoOuro1.Tamanho = 30;
            this.gráficoCotaçãoOuro1.Título = "Cotação do Ouro";
            // 
            // listaCotaçãoOuro1
            // 
            this.listaCotaçãoOuro1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaCotaçãoOuro1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listaCotaçãoOuro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.listaCotaçãoOuro1.bInfDirArredondada = true;
            this.listaCotaçãoOuro1.bInfEsqArredondada = true;
            this.listaCotaçãoOuro1.bSupDirArredondada = true;
            this.listaCotaçãoOuro1.bSupEsqArredondada = true;
            this.listaCotaçãoOuro1.Cor = System.Drawing.Color.Black;
            this.listaCotaçãoOuro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.listaCotaçãoOuro1.LetraTítulo = System.Drawing.Color.White;
            this.listaCotaçãoOuro1.Location = new System.Drawing.Point(505, 15);
            this.listaCotaçãoOuro1.MostrarBotãoMinMax = false;
            this.listaCotaçãoOuro1.Name = "listaCotaçãoOuro1";
            this.listaCotaçãoOuro1.PeríodoFinal = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.listaCotaçãoOuro1.PeríodoInicial = new System.DateTime(2005, 9, 21, 3, 10, 35, 687);
            this.listaCotaçãoOuro1.Size = new System.Drawing.Size(281, 265);
            this.listaCotaçãoOuro1.TabIndex = 1;
            this.listaCotaçãoOuro1.Tamanho = 30;
            this.listaCotaçãoOuro1.Título = "Lista de Cotação do Ouro";
            // 
            // quadroCotação
            // 
            this.quadroCotação.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroCotação.bInfDirArredondada = true;
            this.quadroCotação.bInfEsqArredondada = true;
            this.quadroCotação.bSupDirArredondada = true;
            this.quadroCotação.bSupEsqArredondada = true;
            this.quadroCotação.Controls.Add(this.opçãoRegistrarOuro);
            this.quadroCotação.Cor = System.Drawing.Color.Black;
            this.quadroCotação.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroCotação.LetraTítulo = System.Drawing.Color.White;
            this.quadroCotação.Location = new System.Drawing.Point(7, 15);
            this.quadroCotação.MostrarBotãoMinMax = false;
            this.quadroCotação.Name = "quadroCotação";
            this.quadroCotação.Size = new System.Drawing.Size(162, 61);
            this.quadroCotação.TabIndex = 8;
            this.quadroCotação.Tamanho = 30;
            this.quadroCotação.Título = "Cotação";
            // 
            // opçãoRegistrarOuro
            // 
            this.opçãoRegistrarOuro.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRegistrarOuro.Descrição = "Registrar nova cotação do ouro...";
            this.opçãoRegistrarOuro.Imagem = global::Programa.Financeiro.Properties.Resources.botão___ouro;
            this.opçãoRegistrarOuro.Location = new System.Drawing.Point(3, 27);
            this.opçãoRegistrarOuro.Name = "opçãoRegistrarOuro";
            this.opçãoRegistrarOuro.Size = new System.Drawing.Size(156, 30);
            this.opçãoRegistrarOuro.TabIndex = 2;
            this.opçãoRegistrarOuro.Click += new System.EventHandler(this.opçãoRegistrarOuro_Click);
            // 
            // Indicadores
            // 
            this.Controls.Add(this.gráficoCotaçãoOuro1);
            this.Controls.Add(this.listaCotaçãoOuro1);
            this.Name = "Indicadores";
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.listaCotaçãoOuro1, 0);
            this.Controls.SetChildIndex(this.gráficoCotaçãoOuro1, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroCotação.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadroCotação;
        private Apresentação.Formulários.Opção opçãoRegistrarOuro;
        private Apresentação.Financeiro.Indicadores.GráficoCotação gráficoCotaçãoOuro1;
        private Apresentação.Financeiro.Indicadores.ListaCotação listaCotaçãoOuro1;

    }
}
