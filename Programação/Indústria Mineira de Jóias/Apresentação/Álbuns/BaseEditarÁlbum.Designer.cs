namespace Apresenta��o.�lbum.Edi��o.�lbuns
{
    partial class BaseEditar�lbum
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
            this.components = new System.ComponentModel.Container();
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadro�lbum = new Apresenta��o.Formul�rios.Quadro();
            this.op��oExcluir = new Apresenta��o.Formul�rios.Op��o();
            this.op��oRenomear = new Apresenta��o.Formul�rios.Op��o();
            this.op��oImprimir = new Apresenta��o.Formul�rios.Op��o();
            this.quadroFotos�lbum = new Apresenta��o.Formul�rios.Quadro();
            this.lstEdi��o = new Apresenta��o.�lbum.Edi��o.�lbuns.ListViewEdi��oFotos();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.verSemelhantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.todasFotos = new Apresenta��o.�lbum.Edi��o.Fotos.TodasFotos();
            this.esquerda.SuspendLayout();
            this.quadro�lbum.SuspendLayout();
            this.quadroFotos�lbum.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadro�lbum);
            this.esquerda.Size = new System.Drawing.Size(187, 338);
            this.esquerda.Controls.SetChildIndex(this.quadro�lbum, 0);
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Nome do �lbum";
            this.t�tuloBaseInferior.�coneArredondado = false;
            this.t�tuloBaseInferior.Imagem = global::Apresenta��o.Resource.bot�o___agenda;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(193, 12);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(598, 70);
            this.t�tuloBaseInferior.TabIndex = 6;
            this.t�tuloBaseInferior.T�tulo = "Edi��o de �lbum";
            // 
            // quadro�lbum
            // 
            this.quadro�lbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro�lbum.bInfDirArredondada = true;
            this.quadro�lbum.bInfEsqArredondada = true;
            this.quadro�lbum.bSupDirArredondada = true;
            this.quadro�lbum.bSupEsqArredondada = true;
            this.quadro�lbum.Controls.Add(this.op��oExcluir);
            this.quadro�lbum.Controls.Add(this.op��oRenomear);
            this.quadro�lbum.Controls.Add(this.op��oImprimir);
            this.quadro�lbum.Cor = System.Drawing.Color.Black;
            this.quadro�lbum.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro�lbum.LetraT�tulo = System.Drawing.Color.White;
            this.quadro�lbum.Location = new System.Drawing.Point(7, 13);
            this.quadro�lbum.MostrarBot�oMinMax = false;
            this.quadro�lbum.Name = "quadro�lbum";
            this.quadro�lbum.Size = new System.Drawing.Size(160, 97);
            this.quadro�lbum.TabIndex = 1;
            this.quadro�lbum.Tamanho = 30;
            this.quadro�lbum.T�tulo = "Manuten��o do �lbum";
            // 
            // op��oExcluir
            // 
            this.op��oExcluir.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oExcluir.Descri��o = "Excluir";
            this.op��oExcluir.Imagem = global::Apresenta��o.Resource.Excluir;
            this.op��oExcluir.Location = new System.Drawing.Point(7, 30);
            this.op��oExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oExcluir.Name = "op��oExcluir";
            this.op��oExcluir.Size = new System.Drawing.Size(150, 16);
            this.op��oExcluir.TabIndex = 2;
            this.op��oExcluir.Click += new System.EventHandler(this.op��oExcluir_Click);
            // 
            // op��oRenomear
            // 
            this.op��oRenomear.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oRenomear.Descri��o = "Renomear...";
            this.op��oRenomear.Imagem = global::Apresenta��o.Resource.RenameFolderHS1;
            this.op��oRenomear.Location = new System.Drawing.Point(7, 50);
            this.op��oRenomear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oRenomear.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRenomear.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRenomear.Name = "op��oRenomear";
            this.op��oRenomear.Size = new System.Drawing.Size(150, 19);
            this.op��oRenomear.TabIndex = 3;
            this.op��oRenomear.Click += new System.EventHandler(this.op��oRenomear_Click);
            // 
            // op��oImprimir
            // 
            this.op��oImprimir.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oImprimir.Descri��o = "Imprimir";
            this.op��oImprimir.Imagem = global::Apresenta��o.Resource.Impressora_3D;
            this.op��oImprimir.Location = new System.Drawing.Point(7, 70);
            this.op��oImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oImprimir.Name = "op��oImprimir";
            this.op��oImprimir.Size = new System.Drawing.Size(150, 24);
            this.op��oImprimir.TabIndex = 4;
            this.op��oImprimir.Click += new System.EventHandler(this.op��oImprimir_Click);
            // 
            // quadroFotos�lbum
            // 
            this.quadroFotos�lbum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFotos�lbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroFotos�lbum.bInfDirArredondada = false;
            this.quadroFotos�lbum.bInfEsqArredondada = false;
            this.quadroFotos�lbum.bSupDirArredondada = true;
            this.quadroFotos�lbum.bSupEsqArredondada = true;
            this.quadroFotos�lbum.Controls.Add(this.lstEdi��o);
            this.quadroFotos�lbum.Cor = System.Drawing.Color.Black;
            this.quadroFotos�lbum.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFotos�lbum.LetraT�tulo = System.Drawing.Color.White;
            this.quadroFotos�lbum.Location = new System.Drawing.Point(184, 88);
            this.quadroFotos�lbum.MostrarBot�oMinMax = false;
            this.quadroFotos�lbum.Name = "quadroFotos�lbum";
            this.quadroFotos�lbum.Size = new System.Drawing.Size(413, 235);
            this.quadroFotos�lbum.TabIndex = 7;
            this.quadroFotos�lbum.Tamanho = 30;
            this.quadroFotos�lbum.T�tulo = "Fotos presentes no �lbum";
            // 
            // lstEdi��o
            // 
            this.lstEdi��o.�lbum = null;
            this.lstEdi��o.AllowDrop = true;
            this.lstEdi��o.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEdi��o.Fotos = null;
            this.lstEdi��o.Location = new System.Drawing.Point(3, 25);
            this.lstEdi��o.Name = "lstEdi��o";
            this.lstEdi��o.Ordenar = true;
            this.lstEdi��o.Size = new System.Drawing.Size(407, 210);
            this.lstEdi��o.TabIndex = 2;
            this.toolTip.SetToolTip(this.lstEdi��o, "Estas s�o as fotos presentes no �lbum. Para adicionar uma foto existente, clique " +
        "e arraste a foto na lista ao lado at� esta. Para fazer uma nova fotografia, util" +
        "ize o bot�o \"Capturar nova foto\".");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.toolStripSeparator1,
            this.verSemelhantesToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(225, 76);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = global::Apresenta��o.Resource.Excluir;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::Apresenta��o.Resource.propriedades;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.editarToolStripMenuItem.Text = "Editar fotografia...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // verSemelhantesToolStripMenuItem
            // 
            this.verSemelhantesToolStripMenuItem.Name = "verSemelhantesToolStripMenuItem";
            this.verSemelhantesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.verSemelhantesToolStripMenuItem.Text = "Ver/Exportar mercadoria(s)...";
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Precisa de ajuda?";
            // 
            // todasFotos
            // 
            this.todasFotos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.todasFotos.Location = new System.Drawing.Point(600, 91);
            this.todasFotos.Name = "todasFotos";
            this.todasFotos.Size = new System.Drawing.Size(216, 235);
            this.todasFotos.TabIndex = 10;
            // 
            // BaseEditar�lbum
            // 
            this.Controls.Add(this.todasFotos);
            this.Controls.Add(this.quadroFotos�lbum);
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Name = "BaseEditar�lbum";
            this.Size = new System.Drawing.Size(828, 338);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.quadroFotos�lbum, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.todasFotos, 0);
            this.esquerda.ResumeLayout(false);
            this.quadro�lbum.ResumeLayout(false);
            this.quadroFotos�lbum.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private Apresenta��o.Formul�rios.Quadro quadro�lbum;
        private Apresenta��o.Formul�rios.Quadro quadroFotos�lbum;
        private Apresenta��o.�lbum.Edi��o.�lbuns.ListViewEdi��oFotos lstEdi��o;
        private Apresenta��o.Formul�rios.Op��o op��oExcluir;
        private Apresenta��o.Formul�rios.Op��o op��oRenomear;
        private Apresenta��o.Formul�rios.Op��o op��oImprimir;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verSemelhantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Fotos.TodasFotos todasFotos;
    }
}
