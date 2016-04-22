namespace Apresentação.Financeiro.Controle
{
    partial class BaseControleFinanceiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseControleFinanceiro));
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.sinalizaçãoCarga = new Apresentação.Formulários.SinalizaçãoCarga();
            this.progresso = new System.Windows.Forms.ProgressBar();
            this.títuloBaseInferior1 = new Apresentação.Formulários.TítuloBaseInferior();
            this.bgRecuperação = new System.ComponentModel.BackgroundWorker();
            this.sinalizaçãoCarga.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow
            // 
            this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flow.AutoScroll = true;
            this.flow.Location = new System.Drawing.Point(193, 95);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(589, 184);
            this.flow.TabIndex = 6;
            // 
            // sinalizaçãoCarga
            // 
            this.sinalizaçãoCarga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sinalizaçãoCarga.BackColor = System.Drawing.Color.White;
            this.sinalizaçãoCarga.Controls.Add(this.progresso);
            this.sinalizaçãoCarga.Descrição = "Por favor, aguarde a carga dos dados.";
            this.sinalizaçãoCarga.Imagem = ((System.Drawing.Image)(resources.GetObject("sinalizaçãoCarga.Imagem")));
            this.sinalizaçãoCarga.Location = new System.Drawing.Point(350, 137);
            this.sinalizaçãoCarga.Name = "sinalizaçãoCarga";
            this.sinalizaçãoCarga.Padding = new System.Windows.Forms.Padding(3);
            this.sinalizaçãoCarga.Size = new System.Drawing.Size(288, 96);
            this.sinalizaçãoCarga.TabIndex = 9;
            this.sinalizaçãoCarga.Título = "Carregando...";
            // 
            // progresso
            // 
            this.progresso.Location = new System.Drawing.Point(54, 67);
            this.progresso.Name = "progresso";
            this.progresso.Size = new System.Drawing.Size(228, 23);
            this.progresso.TabIndex = 8;
            // 
            // títuloBaseInferior1
            // 
            this.títuloBaseInferior1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior1.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior1.Descrição = "Abaixo constam todos os clientes com alguma pendência financeira.";
            this.títuloBaseInferior1.Imagem = global::Apresentação.Resource.dívida;
            this.títuloBaseInferior1.Location = new System.Drawing.Point(193, 3);
            this.títuloBaseInferior1.Name = "títuloBaseInferior1";
            this.títuloBaseInferior1.Size = new System.Drawing.Size(589, 70);
            this.títuloBaseInferior1.TabIndex = 7;
            this.títuloBaseInferior1.Título = "Controle Financeiro";
            // 
            // bgRecuperação
            // 
            this.bgRecuperação.WorkerReportsProgress = true;
            this.bgRecuperação.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRecuperação_DoWork);
            this.bgRecuperação.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgRecuperação_RunWorkerCompleted);
            this.bgRecuperação.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgRecuperação_ProgressChanged);
            // 
            // BaseControleFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sinalizaçãoCarga);
            this.Controls.Add(this.flow);
            this.Controls.Add(this.títuloBaseInferior1);
            this.Imagem = global::Apresentação.Resource.dívida;
            this.Name = "BaseControleFinanceiro";
            this.Controls.SetChildIndex(this.títuloBaseInferior1, 0);
            this.Controls.SetChildIndex(this.flow, 0);
            this.Controls.SetChildIndex(this.sinalizaçãoCarga, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.sinalizaçãoCarga.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow;
        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior1;
        private System.Windows.Forms.ProgressBar progresso;
        private Apresentação.Formulários.SinalizaçãoCarga sinalizaçãoCarga;
        private System.ComponentModel.BackgroundWorker bgRecuperação;
    }
}
