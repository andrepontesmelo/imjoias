namespace Apresentação.Atendimento.Atendente
{
    partial class BaseInfoAtendimentos
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
            this.listViewVisitantes = new Apresentação.Atendimento.Clientes.ListViewVisitantes();
            this.quadroLista = new Apresentação.Formulários.Quadro();
            this.opçãoAlterarPeríodo = new Apresentação.Formulários.Opção();
            this.opçãoRecarregar = new Apresentação.Formulários.Opção();
            this.esquerda.SuspendLayout();
            this.quadroLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroLista);
            this.esquerda.Controls.SetChildIndex(this.quadroLista, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Informações sobre atendimentos passados.";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = global::Apresentação.Resource.atendimento;
            this.títuloBaseInferior.Location = new System.Drawing.Point(203, 13);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(581, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Atendimentos passados";
            // 
            // listViewVisitantes
            // 
            this.listViewVisitantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewVisitantes.Location = new System.Drawing.Point(193, 89);
            this.listViewVisitantes.Name = "listViewVisitantes";
            this.listViewVisitantes.Size = new System.Drawing.Size(591, 190);
            this.listViewVisitantes.TabIndex = 7;
            this.listViewVisitantes.AoDuploClique += new Apresentação.Atendimento.Clientes.ListViewVisitantes.VisitaCallback(this.listViewVisitantes_AoDuploClique);
            // 
            // quadroLista
            // 
            this.quadroLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroLista.bInfDirArredondada = true;
            this.quadroLista.bInfEsqArredondada = true;
            this.quadroLista.bSupDirArredondada = true;
            this.quadroLista.bSupEsqArredondada = true;
            this.quadroLista.Controls.Add(this.opçãoAlterarPeríodo);
            this.quadroLista.Controls.Add(this.opçãoRecarregar);
            this.quadroLista.Cor = System.Drawing.Color.Black;
            this.quadroLista.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroLista.LetraTítulo = System.Drawing.Color.White;
            this.quadroLista.Location = new System.Drawing.Point(7, 13);
            this.quadroLista.MostrarBotãoMinMax = false;
            this.quadroLista.Name = "quadroLista";
            this.quadroLista.Size = new System.Drawing.Size(160, 77);
            this.quadroLista.TabIndex = 1;
            this.quadroLista.Tamanho = 30;
            this.quadroLista.Título = "Opções";
            // 
            // opçãoAlterarPeríodo
            // 
            this.opçãoAlterarPeríodo.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAlterarPeríodo.Descrição = "Alterar período...";
            this.opçãoAlterarPeríodo.Imagem = global::Apresentação.Resource.calendário___inclinado;
            this.opçãoAlterarPeríodo.Location = new System.Drawing.Point(7, 30);
            this.opçãoAlterarPeríodo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAlterarPeríodo.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAlterarPeríodo.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAlterarPeríodo.Name = "opçãoAlterarPeríodo";
            this.opçãoAlterarPeríodo.Size = new System.Drawing.Size(150, 16);
            this.opçãoAlterarPeríodo.TabIndex = 2;
            this.opçãoAlterarPeríodo.Click += new System.EventHandler(this.opçãoAlterarPeríodo_Click);
            // 
            // opçãoRecarregar
            // 
            this.opçãoRecarregar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRecarregar.Descrição = "Recarregar lista";
            this.opçãoRecarregar.Imagem = global::Apresentação.Resource.rodízio;
            this.opçãoRecarregar.Location = new System.Drawing.Point(7, 50);
            this.opçãoRecarregar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRecarregar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRecarregar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRecarregar.Name = "opçãoRecarregar";
            this.opçãoRecarregar.Size = new System.Drawing.Size(150, 24);
            this.opçãoRecarregar.TabIndex = 3;
            this.opçãoRecarregar.Click += new System.EventHandler(this.opçãoRecarregar_Click);
            // 
            // BaseInfoAtendimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewVisitantes);
            this.Controls.Add(this.títuloBaseInferior);
            this.Name = "BaseInfoAtendimentos";
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.listViewVisitantes, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroLista.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Atendimento.Clientes.ListViewVisitantes listViewVisitantes;
        private Apresentação.Formulários.Quadro quadroLista;
        private Apresentação.Formulários.Opção opçãoAlterarPeríodo;
        private Apresentação.Formulários.Opção opçãoRecarregar;
    }
}
