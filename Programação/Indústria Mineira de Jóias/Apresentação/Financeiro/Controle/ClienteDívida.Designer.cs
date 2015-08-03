using Apresentação.Formulários;
namespace Apresentação.Financeiro.Controle
{
    partial class ClienteDívida
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quadroSimples1 = new Apresentação.Formulários.QuadroSimples();
            this.lblCódigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.dívidas = new Apresentação.Formulários.ItemExpandível();
            this.pagamentosPendentes = new Apresentação.Formulários.ItemExpandível();
            this.pagamentosDevolvidos = new Apresentação.Formulários.ItemExpandível();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.quadroSimples1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.quadroSimples1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNome, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // quadroSimples1
            // 
            this.quadroSimples1.AutoSize = true;
            this.quadroSimples1.Borda = System.Drawing.Color.SteelBlue;
            this.quadroSimples1.Controls.Add(this.lblCódigo);
            this.quadroSimples1.Cor1 = System.Drawing.Color.SteelBlue;
            this.quadroSimples1.Cor2 = System.Drawing.Color.CornflowerBlue;
            this.quadroSimples1.Location = new System.Drawing.Point(6, 6);
            this.quadroSimples1.Name = "quadroSimples1";
            this.quadroSimples1.Size = new System.Drawing.Size(44, 31);
            this.quadroSimples1.TabIndex = 0;
            this.quadroSimples1.Tamanho = 10;
            // 
            // lblCódigo
            // 
            this.lblCódigo.AutoSize = true;
            this.lblCódigo.ForeColor = System.Drawing.Color.White;
            this.lblCódigo.Location = new System.Drawing.Point(9, 9);
            this.lblCódigo.Margin = new System.Windows.Forms.Padding(9);
            this.lblCódigo.Name = "lblCódigo";
            this.lblCódigo.Size = new System.Drawing.Size(26, 13);
            this.lblCódigo.TabIndex = 0;
            this.lblCódigo.Text = "Cód";
            // 
            // lblNome
            // 
            this.lblNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNome.Location = new System.Drawing.Point(56, 3);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(198, 37);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome do cliente";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dívidas
            // 
            this.dívidas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dívidas.AutoSize = true;
            this.dívidas.Borda = System.Drawing.Color.WhiteSmoke;
            this.dívidas.Cor1 = System.Drawing.Color.White;
            this.dívidas.Cor2 = System.Drawing.Color.WhiteSmoke;
            this.dívidas.Descrição = "Dívida";
            this.dívidas.Location = new System.Drawing.Point(0, 42);
            this.dívidas.Margin = new System.Windows.Forms.Padding(0);
            this.dívidas.Name = "dívidas";
            this.dívidas.Size = new System.Drawing.Size(260, 19);
            this.dívidas.TabIndex = 2;
            // 
            // pagamentosPendentes
            // 
            this.pagamentosPendentes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pagamentosPendentes.AutoSize = true;
            this.pagamentosPendentes.Borda = System.Drawing.Color.WhiteSmoke;
            this.pagamentosPendentes.Cor1 = System.Drawing.Color.White;
            this.pagamentosPendentes.Cor2 = System.Drawing.Color.WhiteSmoke;
            this.pagamentosPendentes.Descrição = "Pagamentos pendentes";
            this.pagamentosPendentes.Location = new System.Drawing.Point(0, 61);
            this.pagamentosPendentes.Margin = new System.Windows.Forms.Padding(0);
            this.pagamentosPendentes.Name = "pagamentosPendentes";
            this.pagamentosPendentes.Size = new System.Drawing.Size(260, 19);
            this.pagamentosPendentes.TabIndex = 3;
            // 
            // pagamentosDevolvidos
            // 
            this.pagamentosDevolvidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pagamentosDevolvidos.AutoSize = true;
            this.pagamentosDevolvidos.Borda = System.Drawing.Color.WhiteSmoke;
            this.pagamentosDevolvidos.Cor1 = System.Drawing.Color.White;
            this.pagamentosDevolvidos.Cor2 = System.Drawing.Color.WhiteSmoke;
            this.pagamentosDevolvidos.Descrição = "Pagamentos devolvidos";
            this.pagamentosDevolvidos.Location = new System.Drawing.Point(0, 80);
            this.pagamentosDevolvidos.Margin = new System.Windows.Forms.Padding(0);
            this.pagamentosDevolvidos.Name = "pagamentosDevolvidos";
            this.pagamentosDevolvidos.Size = new System.Drawing.Size(260, 19);
            this.pagamentosDevolvidos.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.dívidas);
            this.flowLayoutPanel1.Controls.Add(this.pagamentosPendentes);
            this.flowLayoutPanel1.Controls.Add(this.pagamentosDevolvidos);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 99);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // ClienteDívida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ClienteDívida";
            this.Size = new System.Drawing.Size(260, 99);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.quadroSimples1.ResumeLayout(false);
            this.quadroSimples1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Apresentação.Formulários.QuadroSimples quadroSimples1;
        private System.Windows.Forms.Label lblCódigo;
        private System.Windows.Forms.Label lblNome;
        private ItemExpandível pagamentosDevolvidos;
        private ItemExpandível pagamentosPendentes;
        private ItemExpandível dívidas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
