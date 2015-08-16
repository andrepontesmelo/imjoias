using Apresentação.Formulários.Fornecedor;
namespace Apresentação.Álbum.Edição.Fotos
{
    partial class IdentificaçãoMercadoria
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
            this.quadroIdentificação = new Apresentação.Formulários.Quadro();
            this.txtDescriçãoMercadoria = new System.Windows.Forms.TextBox();
            this.txtReferência = new Apresentação.Mercadoria.TxtMercadoria();
            this.txtPeso = new Apresentação.Mercadoria.TxtPeso();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFornecedorReferência = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new Apresentação.Formulários.Fornecedor.TxtFornecedor();
            this.label4 = new System.Windows.Forms.Label();
            this.quadroIdentificação.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadroIdentificação
            // 
            this.quadroIdentificação.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroIdentificação.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroIdentificação.bInfDirArredondada = true;
            this.quadroIdentificação.bInfEsqArredondada = true;
            this.quadroIdentificação.bSupDirArredondada = true;
            this.quadroIdentificação.bSupEsqArredondada = true;
            this.quadroIdentificação.Controls.Add(this.txtDescriçãoMercadoria);
            this.quadroIdentificação.Controls.Add(this.txtReferência);
            this.quadroIdentificação.Controls.Add(this.label1);
            this.quadroIdentificação.Controls.Add(this.txtPeso);
            this.quadroIdentificação.Controls.Add(this.lblPeso);
            this.quadroIdentificação.Controls.Add(this.label2);
            this.quadroIdentificação.Controls.Add(this.txtFornecedorReferência);
            this.quadroIdentificação.Controls.Add(this.label3);
            this.quadroIdentificação.Controls.Add(this.label6);
            this.quadroIdentificação.Controls.Add(this.txtData);
            this.quadroIdentificação.Controls.Add(this.txtDescrição);
            this.quadroIdentificação.Controls.Add(this.txtFornecedor);
            this.quadroIdentificação.Controls.Add(this.label4);
            this.quadroIdentificação.Cor = System.Drawing.Color.Black;
            this.quadroIdentificação.FundoTítulo = System.Drawing.Color.IndianRed;
            this.quadroIdentificação.LetraTítulo = System.Drawing.Color.White;
            this.quadroIdentificação.Location = new System.Drawing.Point(0, 0);
            this.quadroIdentificação.MinimumSize = new System.Drawing.Size(216, 168);
            this.quadroIdentificação.MostrarBotãoMinMax = false;
            this.quadroIdentificação.Name = "quadroIdentificação";
            this.quadroIdentificação.Size = new System.Drawing.Size(463, 216);
            this.quadroIdentificação.TabIndex = 10;
            this.quadroIdentificação.Tamanho = 20;
            this.quadroIdentificação.Título = "Identificação da mercadoria";
            // 
            // txtDescriçãoMercadoria
            // 
            this.txtDescriçãoMercadoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescriçãoMercadoria.Location = new System.Drawing.Point(80, 161);
            this.txtDescriçãoMercadoria.Name = "txtDescriçãoMercadoria";
            this.txtDescriçãoMercadoria.ReadOnly = true;
            this.txtDescriçãoMercadoria.Size = new System.Drawing.Size(367, 20);
            this.txtDescriçãoMercadoria.TabIndex = 5;
            this.txtDescriçãoMercadoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescriçãoMercadoria_KeyPress);
            // 
            // txtReferência
            // 
            this.txtReferência.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferência.ControlePeso = this.txtPeso;
            this.txtReferência.Location = new System.Drawing.Point(80, 32);
            this.txtReferência.Name = "txtReferência";
            this.txtReferência.Referência = "";
            this.txtReferência.Size = new System.Drawing.Size(367, 20);
            this.txtReferência.SomenteCadastrado = true;
            this.txtReferência.TabIndex = 0;
            this.txtReferência.ReferênciaConfirmada += new System.EventHandler(this.txtReferência_ReferênciaConfirmada);
            this.txtReferência.Enter += new System.EventHandler(this.AoGanharFocoEmTextBox);
            this.txtReferência.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeyDown);
            // 
            // txtPeso
            // 
            this.txtPeso.AllowNegative = true;
            this.txtPeso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeso.DigitsInGroup = 0;
            this.txtPeso.Flags = 0;
            this.txtPeso.Location = new System.Drawing.Point(80, 58);
            this.txtPeso.MaxDecimalPlaces = 4;
            this.txtPeso.MaxWholeDigits = 9;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Prefix = "";
            this.txtPeso.RangeMax = 1.7976931348623157E+308;
            this.txtPeso.RangeMin = -1.7976931348623157E+308;
            this.txtPeso.Size = new System.Drawing.Size(367, 20);
            this.txtPeso.TabIndex = 1;
            this.txtPeso.Leave += new System.EventHandler(this.txtPeso_Leave);
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Referência:";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(8, 62);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(34, 13);
            this.lblPeso.TabIndex = 12;
            this.lblPeso.Text = "Peso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição:";
            // 
            // txtDetalhesFornecedor
            // 
            this.txtFornecedorReferência.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFornecedorReferência.Location = new System.Drawing.Point(80, 110);
            this.txtFornecedorReferência.Name = "txtDetalhesFornecedor";
            this.txtFornecedorReferência.Size = new System.Drawing.Size(367, 20);
            this.txtFornecedorReferência.TabIndex = 3;
            this.txtFornecedorReferência.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeyDown);
            this.txtFornecedorReferência.Leave += new System.EventHandler(this.txtDetalhesFornecedor_Leave);
            this.txtFornecedorReferência.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDetalhesFornecedor_KeyPress);
            this.txtFornecedorReferência.Enter += new System.EventHandler(this.AoGanharFocoEmTextBox);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fornecedor:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ref do Fornecedor:";
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(80, 187);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(367, 20);
            this.txtData.TabIndex = 6;
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // txtDescrição
            // 
            this.txtDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrição.Location = new System.Drawing.Point(80, 136);
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(367, 20);
            this.txtDescrição.TabIndex = 4;
            this.txtDescrição.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeyDown);
            this.txtDescrição.Leave += new System.EventHandler(this.txtDescrição_Leave);
            this.txtDescrição.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescrição_KeyPress);
            this.txtDescrição.Enter += new System.EventHandler(this.AoGanharFocoEmTextBox);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFornecedor.Location = new System.Drawing.Point(80, 84);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Referência = "";
            this.txtFornecedor.Size = new System.Drawing.Size(367, 20);
            this.txtFornecedor.TabIndex = 2;
            this.txtFornecedor.Leave += new System.EventHandler(this.txtFornecedor_Leave);
            this.txtFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFornecedor_KeyPress);
            this.txtFornecedor.Enter += new System.EventHandler(this.AoGanharFocoEmTextBox);
            this.txtFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data:";
            // 
            // IdentificaçãoMercadoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.quadroIdentificação);
            this.MinimumSize = new System.Drawing.Size(216, 213);
            this.Name = "IdentificaçãoMercadoria";
            this.Size = new System.Drawing.Size(463, 216);
            this.quadroIdentificação.ResumeLayout(false);
            this.quadroIdentificação.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadroIdentificação;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label6;
        private Apresentação.Mercadoria.TxtMercadoria txtReferência;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFornecedorReferência;
        private TxtFornecedor txtFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Label label2;
        private Apresentação.Mercadoria.TxtPeso txtPeso;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.TextBox txtDescriçãoMercadoria;
    }
}
