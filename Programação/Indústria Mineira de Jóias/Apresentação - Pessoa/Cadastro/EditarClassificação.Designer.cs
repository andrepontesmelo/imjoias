namespace Apresenta��o.Pessoa.Cadastro
{
    partial class EditarClassifica��o
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpDefini��o = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCria��o = new System.Windows.Forms.TextBox();
            this.txtDenomina��o = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpHist�rico = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMsgDesmarcando = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMsgMarcando = new System.Windows.Forms.TextBox();
            this.grpComportamento = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkQuestionarAntigos = new System.Windows.Forms.CheckBox();
            this.chkAlertarVenda = new System.Windows.Forms.CheckBox();
            this.chkAlertarSa�da = new System.Windows.Forms.CheckBox();
            this.chkAlertarCorreio = new System.Windows.Forms.CheckBox();
            this.chkAlertarConserto = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpDefini��o.SuspendLayout();
            this.grpHist�rico.SuspendLayout();
            this.grpComportamento.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(165, 20);
            this.lblT�tulo.Text = "Editar classifica��o";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Digite abaixo os dados da classifica��o.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = global::Apresenta��o.Pessoa.Properties.Resources.CONTACTS;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpDefini��o, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpHist�rico, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpComportamento, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 109);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(355, 324);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // grpDefini��o
            // 
            this.grpDefini��o.Controls.Add(this.label1);
            this.grpDefini��o.Controls.Add(this.txtCria��o);
            this.grpDefini��o.Controls.Add(this.txtDenomina��o);
            this.grpDefini��o.Controls.Add(this.label2);
            this.grpDefini��o.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDefini��o.Location = new System.Drawing.Point(3, 3);
            this.grpDefini��o.Name = "grpDefini��o";
            this.grpDefini��o.Size = new System.Drawing.Size(349, 74);
            this.grpDefini��o.TabIndex = 0;
            this.grpDefini��o.TabStop = false;
            this.grpDefini��o.Text = "Defini��o";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Denomina��o:";
            // 
            // txtCria��o
            // 
            this.txtCria��o.Location = new System.Drawing.Point(123, 45);
            this.txtCria��o.Name = "txtCria��o";
            this.txtCria��o.ReadOnly = true;
            this.txtCria��o.Size = new System.Drawing.Size(220, 20);
            this.txtCria��o.TabIndex = 11;
            // 
            // txtDenomina��o
            // 
            this.txtDenomina��o.Location = new System.Drawing.Point(123, 19);
            this.txtDenomina��o.Name = "txtDenomina��o";
            this.txtDenomina��o.Size = new System.Drawing.Size(220, 20);
            this.txtDenomina��o.TabIndex = 9;
            this.txtDenomina��o.Validated += new System.EventHandler(this.AoValidarDenomina��o);
            this.txtDenomina��o.TextChanged += new System.EventHandler(this.txtDenomina��o_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Data de cria��o:";
            // 
            // grpHist�rico
            // 
            this.grpHist�rico.Controls.Add(this.label4);
            this.grpHist�rico.Controls.Add(this.txtMsgDesmarcando);
            this.grpHist�rico.Controls.Add(this.label3);
            this.grpHist�rico.Controls.Add(this.txtMsgMarcando);
            this.grpHist�rico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHist�rico.Location = new System.Drawing.Point(3, 83);
            this.grpHist�rico.Name = "grpHist�rico";
            this.grpHist�rico.Size = new System.Drawing.Size(349, 74);
            this.grpHist�rico.TabIndex = 1;
            this.grpHist�rico.TabStop = false;
            this.grpHist�rico.Text = "Registro no hist�rico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ao remover, escrever:";
            // 
            // txtMsgDesmarcando
            // 
            this.txtMsgDesmarcando.Location = new System.Drawing.Point(123, 45);
            this.txtMsgDesmarcando.Name = "txtMsgDesmarcando";
            this.txtMsgDesmarcando.Size = new System.Drawing.Size(220, 20);
            this.txtMsgDesmarcando.TabIndex = 13;
            this.txtMsgDesmarcando.Validated += new System.EventHandler(this.AoValidarMsgDesmarcando);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ao atribuir, escrever:";
            // 
            // txtMsgMarcando
            // 
            this.txtMsgMarcando.Location = new System.Drawing.Point(123, 19);
            this.txtMsgMarcando.Name = "txtMsgMarcando";
            this.txtMsgMarcando.Size = new System.Drawing.Size(220, 20);
            this.txtMsgMarcando.TabIndex = 11;
            this.txtMsgMarcando.Validated += new System.EventHandler(this.AoValidarMsgMarcando);
            // 
            // grpComportamento
            // 
            this.grpComportamento.Controls.Add(this.flowLayoutPanel1);
            this.grpComportamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComportamento.Location = new System.Drawing.Point(3, 163);
            this.grpComportamento.Name = "grpComportamento";
            this.grpComportamento.Size = new System.Drawing.Size(349, 158);
            this.grpComportamento.TabIndex = 2;
            this.grpComportamento.TabStop = false;
            this.grpComportamento.Text = "Comportamento";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.chkQuestionarAntigos);
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarVenda);
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarSa�da);
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarCorreio);
            this.flowLayoutPanel1.Controls.Add(this.chkAlertarConserto);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(336, 129);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chkQuestionarAntigos
            // 
            this.chkQuestionarAntigos.Location = new System.Drawing.Point(3, 3);
            this.chkQuestionarAntigos.Name = "chkQuestionarAntigos";
            this.chkQuestionarAntigos.Size = new System.Drawing.Size(329, 31);
            this.chkQuestionarAntigos.TabIndex = 14;
            this.chkQuestionarAntigos.Text = "Solicitar funcion�rio para conferir esta classifica��o para cadastros antigos.";
            this.chkQuestionarAntigos.UseVisualStyleBackColor = true;
            this.chkQuestionarAntigos.CheckedChanged += new System.EventHandler(this.AoMudarQuestionarAntigo);
            // 
            // chkAlertarVenda
            // 
            this.chkAlertarVenda.AutoSize = true;
            this.chkAlertarVenda.Location = new System.Drawing.Point(3, 40);
            this.chkAlertarVenda.Name = "chkAlertarVenda";
            this.chkAlertarVenda.Size = new System.Drawing.Size(222, 17);
            this.chkAlertarVenda.TabIndex = 16;
            this.chkAlertarVenda.Text = "Alertar funcion�rio ao registrar uma venda";
            this.chkAlertarVenda.UseVisualStyleBackColor = true;
            this.chkAlertarVenda.CheckedChanged += new System.EventHandler(this.AoMudarAlertarVenda);
            // 
            // chkAlertarSa�da
            // 
            this.chkAlertarSa�da.AutoSize = true;
            this.chkAlertarSa�da.Location = new System.Drawing.Point(3, 63);
            this.chkAlertarSa�da.Name = "chkAlertarSa�da";
            this.chkAlertarSa�da.Size = new System.Drawing.Size(292, 17);
            this.chkAlertarSa�da.TabIndex = 17;
            this.chkAlertarSa�da.Text = "Alertar funcion�rio ao registrar uma sa�da de consignado";
            this.chkAlertarSa�da.UseVisualStyleBackColor = true;
            this.chkAlertarSa�da.CheckedChanged += new System.EventHandler(this.AoMudarAlertarSa�da);
            // 
            // chkAlertarCorreio
            // 
            this.chkAlertarCorreio.AutoSize = true;
            this.chkAlertarCorreio.Location = new System.Drawing.Point(3, 86);
            this.chkAlertarCorreio.Name = "chkAlertarCorreio";
            this.chkAlertarCorreio.Size = new System.Drawing.Size(293, 17);
            this.chkAlertarCorreio.TabIndex = 18;
            this.chkAlertarCorreio.Text = "Alertar funcion�rio ao iniciar despachamento pelo correio";
            this.chkAlertarCorreio.UseVisualStyleBackColor = true;
            this.chkAlertarCorreio.CheckedChanged += new System.EventHandler(this.AoMudarAlertarCorreio);
            // 
            // chkAlertarConserto
            // 
            this.chkAlertarConserto.AutoSize = true;
            this.chkAlertarConserto.Location = new System.Drawing.Point(3, 109);
            this.chkAlertarConserto.Name = "chkAlertarConserto";
            this.chkAlertarConserto.Size = new System.Drawing.Size(227, 17);
            this.chkAlertarConserto.TabIndex = 19;
            this.chkAlertarConserto.Text = "Alertar funcion�rio ao registrar um conserto";
            this.chkAlertarConserto.UseVisualStyleBackColor = true;
            this.chkAlertarConserto.CheckedChanged += new System.EventHandler(this.AoMudarAlertarConserto);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(224, 442);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(305, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // EditarClassifica��o
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(392, 477);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Name = "EditarClassifica��o";
            this.Text = "Editar classifica��o";
            this.Shown += new System.EventHandler(this.EditarClassifica��o_Shown);
            this.Load += new System.EventHandler(this.AoCarregar);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpDefini��o.ResumeLayout(false);
            this.grpDefini��o.PerformLayout();
            this.grpHist�rico.ResumeLayout(false);
            this.grpHist�rico.PerformLayout();
            this.grpComportamento.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpDefini��o;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCria��o;
        private System.Windows.Forms.TextBox txtDenomina��o;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpHist�rico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMsgDesmarcando;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMsgMarcando;
        private System.Windows.Forms.GroupBox grpComportamento;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkQuestionarAntigos;
        private System.Windows.Forms.CheckBox chkAlertarVenda;
        private System.Windows.Forms.CheckBox chkAlertarSa�da;
        private System.Windows.Forms.CheckBox chkAlertarCorreio;
        private System.Windows.Forms.CheckBox chkAlertarConserto;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;

    }
}
