namespace Apresentação.Álbum.Edição.Álbuns
{
    partial class BaseEditarÁlbum
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroÁlbum = new Apresentação.Formulários.Quadro();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.opçãoRenomear = new Apresentação.Formulários.Opção();
            this.opçãoImprimir = new Apresentação.Formulários.Opção();
            this.quadroFotosÁlbum = new Apresentação.Formulários.Quadro();
            this.lstEdição = new Apresentação.Álbum.Edição.Álbuns.ListViewEdiçãoFotos();
            this.quadroFotosTodas = new Apresentação.Formulários.Quadro();
            this.lnkMaisFotos = new System.Windows.Forms.LinkLabel();
            this.listaFotosTodas = new Apresentação.Álbum.Edição.Fotos.ListaFotos();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.verSemelhantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtReferência = new Apresentação.Mercadoria.TxtMercadoria();
            this.label1 = new System.Windows.Forms.Label();
            this.chkForaDeLinha = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.esquerda.SuspendLayout();
            this.quadroÁlbum.SuspendLayout();
            this.quadroFotosÁlbum.SuspendLayout();
            this.quadroFotosTodas.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroÁlbum);
            this.esquerda.Size = new System.Drawing.Size(187, 308);
            this.esquerda.Controls.SetChildIndex(this.quadroÁlbum, 0);
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Nome do álbum";
            this.títuloBaseInferior.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.botão___agenda;
            this.títuloBaseInferior.Location = new System.Drawing.Point(193, 12);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(598, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Edição de álbum";
            // 
            // quadroÁlbum
            // 
            this.quadroÁlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroÁlbum.bInfDirArredondada = true;
            this.quadroÁlbum.bInfEsqArredondada = true;
            this.quadroÁlbum.bSupDirArredondada = true;
            this.quadroÁlbum.bSupEsqArredondada = true;
            this.quadroÁlbum.Controls.Add(this.opçãoExcluir);
            this.quadroÁlbum.Controls.Add(this.opçãoRenomear);
            this.quadroÁlbum.Controls.Add(this.opçãoImprimir);
            this.quadroÁlbum.Cor = System.Drawing.Color.Black;
            this.quadroÁlbum.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroÁlbum.LetraTítulo = System.Drawing.Color.White;
            this.quadroÁlbum.Location = new System.Drawing.Point(7, 13);
            this.quadroÁlbum.MostrarBotãoMinMax = false;
            this.quadroÁlbum.Name = "quadroÁlbum";
            this.quadroÁlbum.Size = new System.Drawing.Size(160, 103);
            this.quadroÁlbum.TabIndex = 1;
            this.quadroÁlbum.Tamanho = 30;
            this.quadroÁlbum.Título = "Manutenção do álbum";
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.Excluir;
            this.opçãoExcluir.Location = new System.Drawing.Point(5, 30);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 24);
            this.opçãoExcluir.TabIndex = 2;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // opçãoRenomear
            // 
            this.opçãoRenomear.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRenomear.Descrição = "Renomear...";
            this.opçãoRenomear.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.RenameFolderHS;
            this.opçãoRenomear.Location = new System.Drawing.Point(5, 54);
            this.opçãoRenomear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRenomear.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRenomear.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRenomear.Name = "opçãoRenomear";
            this.opçãoRenomear.Size = new System.Drawing.Size(150, 24);
            this.opçãoRenomear.TabIndex = 3;
            this.opçãoRenomear.Click += new System.EventHandler(this.opçãoRenomear_Click);
            // 
            // opçãoImprimir
            // 
            this.opçãoImprimir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoImprimir.Descrição = "Imprimir";
            this.opçãoImprimir.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.Impressora_3D;
            this.opçãoImprimir.Location = new System.Drawing.Point(5, 78);
            this.opçãoImprimir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoImprimir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoImprimir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoImprimir.Name = "opçãoImprimir";
            this.opçãoImprimir.Size = new System.Drawing.Size(150, 24);
            this.opçãoImprimir.TabIndex = 4;
            this.opçãoImprimir.Click += new System.EventHandler(this.opçãoImprimir_Click);
            // 
            // quadroFotosÁlbum
            // 
            this.quadroFotosÁlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFotosÁlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroFotosÁlbum.bInfDirArredondada = false;
            this.quadroFotosÁlbum.bInfEsqArredondada = false;
            this.quadroFotosÁlbum.bSupDirArredondada = true;
            this.quadroFotosÁlbum.bSupEsqArredondada = true;
            this.quadroFotosÁlbum.Controls.Add(this.lstEdição);
            this.quadroFotosÁlbum.Cor = System.Drawing.Color.Black;
            this.quadroFotosÁlbum.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFotosÁlbum.LetraTítulo = System.Drawing.Color.White;
            this.quadroFotosÁlbum.Location = new System.Drawing.Point(184, 88);
            this.quadroFotosÁlbum.MostrarBotãoMinMax = false;
            this.quadroFotosÁlbum.Name = "quadroFotosÁlbum";
            this.quadroFotosÁlbum.Size = new System.Drawing.Size(385, 205);
            this.quadroFotosÁlbum.TabIndex = 7;
            this.quadroFotosÁlbum.Tamanho = 30;
            this.quadroFotosÁlbum.Título = "Fotos presentes no álbum";
            // 
            // lstEdição
            // 
            this.lstEdição.Álbum = null;
            this.lstEdição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEdição.Fotos = null;
            this.lstEdição.Location = new System.Drawing.Point(3, 26);
            this.lstEdição.Name = "lstEdição";
            this.lstEdição.Ordenar = true;
            this.lstEdição.Size = new System.Drawing.Size(379, 176);
            this.lstEdição.TabIndex = 2;
            this.toolTip.SetToolTip(this.lstEdição, "Estas são as fotos presentes no álbum. Para adicionar uma foto existente, clique " +
                    "e arraste a foto na lista ao lado até esta. Para fazer uma nova fotografia, util" +
                    "ize o botão \"Capturar nova foto\".");
            // 
            // quadroFotosTodas
            // 
            this.quadroFotosTodas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFotosTodas.BackColor = System.Drawing.Color.NavajoWhite;
            this.quadroFotosTodas.bInfDirArredondada = false;
            this.quadroFotosTodas.bInfEsqArredondada = false;
            this.quadroFotosTodas.bSupDirArredondada = true;
            this.quadroFotosTodas.bSupEsqArredondada = true;
            this.quadroFotosTodas.Controls.Add(this.lnkMaisFotos);
            this.quadroFotosTodas.Controls.Add(this.listaFotosTodas);
            this.quadroFotosTodas.Controls.Add(this.txtReferência);
            this.quadroFotosTodas.Controls.Add(this.label1);
            this.quadroFotosTodas.Controls.Add(this.chkForaDeLinha);
            this.quadroFotosTodas.Cor = System.Drawing.Color.SaddleBrown;
            this.quadroFotosTodas.FundoTítulo = System.Drawing.Color.SaddleBrown;
            this.quadroFotosTodas.LetraTítulo = System.Drawing.Color.White;
            this.quadroFotosTodas.Location = new System.Drawing.Point(575, 88);
            this.quadroFotosTodas.MostrarBotãoMinMax = false;
            this.quadroFotosTodas.Name = "quadroFotosTodas";
            this.quadroFotosTodas.Size = new System.Drawing.Size(216, 205);
            this.quadroFotosTodas.TabIndex = 8;
            this.quadroFotosTodas.Tamanho = 30;
            this.quadroFotosTodas.Título = "Todas as fotos";
            // 
            // lnkMaisFotos
            // 
            this.lnkMaisFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkMaisFotos.AutoSize = true;
            this.lnkMaisFotos.Location = new System.Drawing.Point(149, 189);
            this.lnkMaisFotos.Name = "lnkMaisFotos";
            this.lnkMaisFotos.Size = new System.Drawing.Size(64, 13);
            this.lnkMaisFotos.TabIndex = 9;
            this.lnkMaisFotos.TabStop = true;
            this.lnkMaisFotos.Text = "Mais fotos...";
            this.lnkMaisFotos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMaisFotos_LinkClicked);
            // 
            // listaFotosTodas
            // 
            this.listaFotosTodas.AllowDrop = true;
            this.listaFotosTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaFotosTodas.ContextMenuStrip = this.contextMenuStrip;
            this.listaFotosTodas.Fotos = null;
            this.listaFotosTodas.Location = new System.Drawing.Point(3, 75);
            this.listaFotosTodas.Name = "listaFotosTodas";
            this.listaFotosTodas.Ordenar = true;
            this.listaFotosTodas.Size = new System.Drawing.Size(210, 111);
            this.listaFotosTodas.TabIndex = 2;
            this.toolTip.SetToolTip(this.listaFotosTodas, "Estas são as fotos que já foram tiradas e não necessariamente estão neste álbum. " +
                    "Clique e arraste na foto nesta lista até a lista ao lado para adicionar a foto n" +
                    "o álbum.");
            this.listaFotosTodas.AoExcluído += new Apresentação.Álbum.Edição.Fotos.ListaFotos.FotoHandle(this.listaFotosTodas_AoExcluído);
            this.listaFotosTodas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listaFotosTodas_MouseMove);
            this.listaFotosTodas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listaFotosTodas_MouseDown);
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
            this.removerToolStripMenuItem.Image = global::Apresentação.Álbum.Edição.Properties.Resources.Excluir;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::Apresentação.Álbum.Edição.Properties.Resources.Propriedades;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.editarToolStripMenuItem.Text = "Editar fotografia...";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
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
            this.verSemelhantesToolStripMenuItem.Click += new System.EventHandler(this.verSemelhantesToolStripMenuItem_Click);
            // 
            // txtReferência
            // 
            this.txtReferência.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferência.Location = new System.Drawing.Point(71, 26);
            this.txtReferência.MostrarBalãoRefNãoEncontrada = false;
            this.txtReferência.Name = "txtReferência";
            this.txtReferência.Referência = "";
            this.txtReferência.Size = new System.Drawing.Size(142, 20);
            this.txtReferência.TabIndex = 4;
            this.toolTip.SetToolTip(this.txtReferência, "Digite parte da referência para localizar a foto na lista abaixo.");
            this.txtReferência.UtilizarListView = false;
            this.txtReferência.ReferênciaAlterada += new System.EventHandler(this.txtReferência_ReferênciaAlterada);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Referência:";
            // 
            // chkForaDeLinha
            // 
            this.chkForaDeLinha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkForaDeLinha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkForaDeLinha.Location = new System.Drawing.Point(6, 52);
            this.chkForaDeLinha.Name = "chkForaDeLinha";
            this.chkForaDeLinha.Size = new System.Drawing.Size(207, 17);
            this.chkForaDeLinha.TabIndex = 5;
            this.chkForaDeLinha.Text = "Incluir mercadoria fora de linha";
            this.chkForaDeLinha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkForaDeLinha.UseVisualStyleBackColor = true;
            this.chkForaDeLinha.CheckedChanged += new System.EventHandler(this.chkForaDeLinha_CheckedChanged);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Precisa de ajuda?";
            // 
            // BaseEditarÁlbum
            // 
            this.Controls.Add(this.quadroFotosÁlbum);
            this.Controls.Add(this.quadroFotosTodas);
            this.Controls.Add(this.títuloBaseInferior);
            this.Name = "BaseEditarÁlbum";
            this.Size = new System.Drawing.Size(800, 308);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.quadroFotosTodas, 0);
            this.Controls.SetChildIndex(this.quadroFotosÁlbum, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroÁlbum.ResumeLayout(false);
            this.quadroFotosÁlbum.ResumeLayout(false);
            this.quadroFotosTodas.ResumeLayout(false);
            this.quadroFotosTodas.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadroÁlbum;
        private Apresentação.Formulários.Quadro quadroFotosÁlbum;
        private Apresentação.Álbum.Edição.Álbuns.ListViewEdiçãoFotos lstEdição;
        private Apresentação.Formulários.Quadro quadroFotosTodas;
        private Apresentação.Álbum.Edição.Fotos.ListaFotos listaFotosTodas;
        private Apresentação.Mercadoria.TxtMercadoria txtReferência;
        private System.Windows.Forms.Label label1;
        private Apresentação.Formulários.Opção opçãoExcluir;
        private Apresentação.Formulários.Opção opçãoRenomear;
        private Apresentação.Formulários.Opção opçãoImprimir;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkForaDeLinha;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verSemelhantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.LinkLabel lnkMaisFotos;
    }
}
