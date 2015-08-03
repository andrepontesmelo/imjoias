//namespace Apresentação.Financeiro.Acerto.Alerta
//{
//    partial class AlertaBaseInferior
//    {
//        /// <summary> 
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Component Designer generated code

//        /// <summary> 
//        /// Required method for Designer support - do not modify 
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.quadro1 = new Apresentação.Formulários.Quadro();
//            this.opçãoResumo = new Apresentação.Formulários.Opção();
//            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
//            this.flow = new System.Windows.Forms.FlowLayoutPanel();
//            this.esquerda.SuspendLayout();
//            this.quadro1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // esquerda
//            // 
//            this.esquerda.Controls.Add(this.quadro1);
//            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
//            // 
//            // quadro1
//            // 
//            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
//            this.quadro1.bInfDirArredondada = true;
//            this.quadro1.bInfEsqArredondada = true;
//            this.quadro1.bSupDirArredondada = true;
//            this.quadro1.bSupEsqArredondada = true;
//            this.quadro1.Controls.Add(this.opçãoResumo);
//            this.quadro1.Cor = System.Drawing.Color.Black;
//            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
//            this.quadro1.LetraTítulo = System.Drawing.Color.White;
//            this.quadro1.Location = new System.Drawing.Point(7, 13);
//            this.quadro1.MostrarBotãoMinMax = false;
//            this.quadro1.Name = "quadro1";
//            this.quadro1.Size = new System.Drawing.Size(160, 91);
//            this.quadro1.TabIndex = 1;
//            this.quadro1.Tamanho = 30;
//            this.quadro1.Título = "Prosseguir";
//            // 
//            // opçãoResumo
//            // 
//            this.opçãoResumo.BackColor = System.Drawing.Color.Transparent;
//            this.opçãoResumo.Descrição = "Ignorar alertas";
//            this.opçãoResumo.Imagem = global::Apresentação.Financeiro.Properties.Resources.none;
//            this.opçãoResumo.Location = new System.Drawing.Point(10, 61);
//            this.opçãoResumo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
//            this.opçãoResumo.MaximumSize = new System.Drawing.Size(150, 100);
//            this.opçãoResumo.MinimumSize = new System.Drawing.Size(150, 16);
//            this.opçãoResumo.Name = "opçãoResumo";
//            this.opçãoResumo.Size = new System.Drawing.Size(150, 24);
//            this.opçãoResumo.TabIndex = 2;
//            this.opçãoResumo.Click += new System.EventHandler(this.opçãoResumo_Click);
//            // 
//            // títuloBaseInferior1
//            // 
//            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
//            this.títuloBaseInferior1.Descrição = "Algumas inconsistências foram encontradas na seleção dos documentos para acerto. " +
//                "Favor corrigi-los antes de prosseguir.";
//            this.títuloBaseInferior1.Imagem = null;
//            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 13);
//            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
//            this.títuloBaseInferior1.Size = new System.Drawing.Size(367, 70);
//            this.títuloBaseInferior1.TabIndex = 6;
//            this.títuloBaseInferior1.Título = "Alertas do acerto";
//            // 
//            // flow
//            // 
//            this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.flow.Location = new System.Drawing.Point(193, 89);
//            this.flow.Name = "flow";
//            this.flow.Size = new System.Drawing.Size(351, 192);
//            this.flow.TabIndex = 7;
//            // 
//            // AlertaBaseInferior
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.Controls.Add(this.títuloBaseInferior1);
//            this.Controls.Add(this.flow);
//            this.Name = "AlertaBaseInferior";
//            this.Size = new System.Drawing.Size(563, 296);
//            this.Controls.SetChildIndex(this.flow, 0);
//            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
//            this.Controls.SetChildIndex(this.esquerda, 0);
//            this.esquerda.ResumeLayout(false);
//            this.quadro1.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private Apresentação.Formulários.Quadro quadro1;
//        private Apresentação.Formulários.Opção opçãoResumo;
//        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
//        private System.Windows.Forms.FlowLayoutPanel flow;

//    }
//}
