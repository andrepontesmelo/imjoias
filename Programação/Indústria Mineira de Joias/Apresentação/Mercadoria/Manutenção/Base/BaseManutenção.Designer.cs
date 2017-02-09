namespace Apresentação.Mercadoria.Manutenção.Base
{
    partial class BaseManutenção
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.lista = new Apresentação.Mercadoria.Manutenção.Lista.ListaMercadorias();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoNova = new Apresentação.Formulários.Opção();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.opçãoAtualizarPreços = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro1);
            this.esquerda.Size = new System.Drawing.Size(187, 513);
            this.esquerda.Controls.SetChildIndex(this.quadro1, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Manutenção no cadastro de mercadorias";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.ficha;
            this.títuloBaseInferior.Location = new System.Drawing.Point(190, 9);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(640, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Manutenção de mercadorias";
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Location = new System.Drawing.Point(193, 85);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(654, 413);
            this.lista.TabIndex = 7;
            this.lista.DuploClique += new System.EventHandler(this.lista_DuploClique);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoAtualizarPreços);
            this.quadro1.Controls.Add(this.opçãoExcluir);
            this.quadro1.Controls.Add(this.opçãoNova);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(7, 13);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 93);
            this.quadro1.TabIndex = 8;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Ações";
            // 
            // opçãoNova
            // 
            this.opçãoNova.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNova.Descrição = "Nova";
            this.opçãoNova.Imagem = global::Apresentação.Resource.novo;
            this.opçãoNova.Location = new System.Drawing.Point(7, 30);
            this.opçãoNova.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNova.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNova.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNova.Name = "opçãoNova";
            this.opçãoNova.Size = new System.Drawing.Size(150, 16);
            this.opçãoNova.TabIndex = 2;
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Resource.Excluir;
            this.opçãoExcluir.Location = new System.Drawing.Point(7, 50);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.TabIndex = 3;
            // 
            // opçãoAtualizarPreços
            // 
            this.opçãoAtualizarPreços.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAtualizarPreços.Descrição = "Atualizar Preços";
            this.opçãoAtualizarPreços.Imagem = global::Apresentação.Resource.RefreshDocViewHS;
            this.opçãoAtualizarPreços.Location = new System.Drawing.Point(7, 70);
            this.opçãoAtualizarPreços.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAtualizarPreços.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAtualizarPreços.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAtualizarPreços.Name = "opçãoAtualizarPreços";
            this.opçãoAtualizarPreços.Size = new System.Drawing.Size(150, 16);
            this.opçãoAtualizarPreços.TabIndex = 4;
            // 
            // BaseManutenção
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lista);
            this.Controls.Add(this.títuloBaseInferior);
            this.Name = "BaseManutenção";
            this.Size = new System.Drawing.Size(850, 513);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.lista, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Formulários.TítuloBaseInferior títuloBaseInferior;
        private Lista.ListaMercadorias lista;
        private Formulários.Quadro quadro1;
        private Formulários.Opção opçãoExcluir;
        private Formulários.Opção opçãoNova;
        private Formulários.Opção opçãoAtualizarPreços;
    }
}
