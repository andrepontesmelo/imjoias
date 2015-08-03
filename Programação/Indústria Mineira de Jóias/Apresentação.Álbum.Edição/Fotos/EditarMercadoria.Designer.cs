using Apresenta��o.�lbum.Edi��o.Fotos;
namespace Apresenta��o.�lbum.Edi��o.Fotos
{
    partial class EditarMercadoria
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

            DescarregarListaFotos();
        }

        private delegate void DescarregarListaFotosDelegate();
        private void DescarregarListaFotos()
        {
            if (listaFotos.InvokeRequired)
            {
                DescarregarListaFotosDelegate m�todo = new DescarregarListaFotosDelegate(DescarregarListaFotos);
                listaFotos.BeginInvoke(m�todo);
            }
            else
            {
                listaFotos.Dispose();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.t�tuloBaseInferior = new Apresenta��o.Formul�rios.T�tuloBaseInferior();
            this.quadroFotos = new Apresenta��o.Formul�rios.Quadro();
            this.listaFotos = new Apresenta��o.�lbum.Edi��o.Fotos.ListaFotos();
            this.quadroItem = new Apresenta��o.Formul�rios.Quadro();
            this.op��oEditar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oExcluir = new Apresenta��o.Formul�rios.Op��o();
            this.quadroGeral = new Apresenta��o.Formul�rios.Quadro();
            this.op��oProcurar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oExportar = new Apresenta��o.Formul�rios.Op��o();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.esquerda.SuspendLayout();
            this.quadroFotos.SuspendLayout();
            this.quadroItem.SuspendLayout();
            this.quadroGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroGeral);
            this.esquerda.Controls.Add(this.quadroItem);
            this.esquerda.Controls.SetChildIndex(this.quadroItem, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroGeral, 0);
            // 
            // t�tuloBaseInferior
            // 
            this.t�tuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.t�tuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.t�tuloBaseInferior.Descri��o = "Mercadoria XXX";
            this.t�tuloBaseInferior.Imagem = global::Apresenta��o.�lbum.Edi��o.Properties.Resources.propriedades__altura_58_;
            this.t�tuloBaseInferior.Location = new System.Drawing.Point(216, 14);
            this.t�tuloBaseInferior.Name = "t�tuloBaseInferior";
            this.t�tuloBaseInferior.Size = new System.Drawing.Size(565, 70);
            this.t�tuloBaseInferior.TabIndex = 6;
            this.t�tuloBaseInferior.T�tulo = "Edi��o de fotos";
            // 
            // quadroFotos
            // 
            this.quadroFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFotos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroFotos.bInfDirArredondada = true;
            this.quadroFotos.bInfEsqArredondada = true;
            this.quadroFotos.bSupDirArredondada = true;
            this.quadroFotos.bSupEsqArredondada = true;
            this.quadroFotos.Controls.Add(this.listaFotos);
            this.quadroFotos.Cor = System.Drawing.Color.Black;
            this.quadroFotos.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFotos.LetraT�tulo = System.Drawing.Color.White;
            this.quadroFotos.Location = new System.Drawing.Point(216, 102);
            this.quadroFotos.MostrarBot�oMinMax = false;
            this.quadroFotos.Name = "quadroFotos";
            this.quadroFotos.Size = new System.Drawing.Size(547, 174);
            this.quadroFotos.TabIndex = 7;
            this.quadroFotos.Tamanho = 30;
            this.quadroFotos.T�tulo = "Cole��o de Fotos";
            // 
            // listaFotos
            // 
            this.listaFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaFotos.Fotos = null;
            this.listaFotos.Location = new System.Drawing.Point(10, 34);
            this.listaFotos.Name = "listaFotos";
            this.listaFotos.Size = new System.Drawing.Size(526, 129);
            this.listaFotos.TabIndex = 2;
            this.listaFotos.AoSelecionar += new ListaFotos.FotoHandle(listaFotos_AoSelecionar);
            // 
            // quadroItem
            // 
            this.quadroItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroItem.bInfDirArredondada = true;
            this.quadroItem.bInfEsqArredondada = true;
            this.quadroItem.bSupDirArredondada = true;
            this.quadroItem.bSupEsqArredondada = true;
            this.quadroItem.Controls.Add(this.op��oEditar);
            this.quadroItem.Controls.Add(this.op��oExcluir);
            this.quadroItem.Controls.Add(this.op��oExportar);
            this.quadroItem.Cor = System.Drawing.Color.Black;
            this.quadroItem.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroItem.LetraT�tulo = System.Drawing.Color.White;
            this.quadroItem.Location = new System.Drawing.Point(7, 91);
            this.quadroItem.MostrarBot�oMinMax = false;
            this.quadroItem.Name = "quadroItem";
            this.quadroItem.Size = new System.Drawing.Size(160, 101);
            this.quadroItem.TabIndex = 1;
            this.quadroItem.Tamanho = 30;
            this.quadroItem.T�tulo = "Foto selecionada";
            this.quadroItem.Visible = false;
            // 
            // op��oEditar
            // 
            this.op��oEditar.BackColor = System.Drawing.Color.Transparent;
            this.op��oEditar.Descri��o = "Editar foto...";
            this.op��oEditar.Imagem = global::Apresenta��o.�lbum.Edi��o.Properties.Resources.Propriedades;
            this.op��oEditar.Location = new System.Drawing.Point(5, 31);
            this.op��oEditar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oEditar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oEditar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oEditar.Name = "op��oEditar";
            this.op��oEditar.Size = new System.Drawing.Size(150, 24);
            this.op��oEditar.TabIndex = 2;
            this.op��oEditar.Click += new System.EventHandler(this.op��oEditar_Click);
            // 
            // op��oExcluir
            // 
            this.op��oExcluir.BackColor = System.Drawing.Color.Transparent;
            this.op��oExcluir.Descri��o = "Excluir foto";
            this.op��oExcluir.Imagem = global::Apresenta��o.�lbum.Edi��o.Properties.Resources.Excluir;
            this.op��oExcluir.Location = new System.Drawing.Point(5, 55);
            this.op��oExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oExcluir.Name = "op��oExcluir";
            this.op��oExcluir.Size = new System.Drawing.Size(150, 24);
            this.op��oExcluir.TabIndex = 3;
            this.op��oExcluir.Click += new System.EventHandler(this.op��oExcluir_Click);
            // 
            // quadroGeral
            // 
            this.quadroGeral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroGeral.bInfDirArredondada = true;
            this.quadroGeral.bInfEsqArredondada = true;
            this.quadroGeral.bSupDirArredondada = true;
            this.quadroGeral.bSupEsqArredondada = true;
            this.quadroGeral.Controls.Add(this.op��oProcurar);
            this.quadroGeral.Cor = System.Drawing.Color.Black;
            this.quadroGeral.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroGeral.LetraT�tulo = System.Drawing.Color.White;
            this.quadroGeral.Location = new System.Drawing.Point(7, 13);
            this.quadroGeral.MostrarBot�oMinMax = false;
            this.quadroGeral.Name = "quadroGeral";
            this.quadroGeral.Size = new System.Drawing.Size(160, 71);
            this.quadroGeral.TabIndex = 2;
            this.quadroGeral.Tamanho = 30;
            this.quadroGeral.T�tulo = "Op��es gerais";
            // 
            // op��oProcurar
            // 
            this.op��oProcurar.BackColor = System.Drawing.Color.Transparent;
            this.op��oProcurar.Descri��o = "Procurar outra mercadoria...";
            this.op��oProcurar.Imagem = global::Apresenta��o.�lbum.Edi��o.Properties.Resources.Lupa;
            this.op��oProcurar.Location = new System.Drawing.Point(5, 32);
            this.op��oProcurar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oProcurar.Name = "op��oProcurar";
            this.op��oProcurar.Size = new System.Drawing.Size(150, 30);
            this.op��oProcurar.TabIndex = 2;
            this.op��oProcurar.Click += new System.EventHandler(this.op��oProcurar_Click);
            // 
            // op��oExportar
            // 
            this.op��oExportar.BackColor = System.Drawing.Color.Transparent;
            this.op��oExportar.Descri��o = "Exportar para arquivo...";
            this.op��oExportar.Imagem = global::Apresenta��o.�lbum.Edi��o.Properties.Resources.saveHS;
            this.op��oExportar.Location = new System.Drawing.Point(5, 77);
            this.op��oExportar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oExportar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oExportar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oExportar.Name = "op��oExportar";
            this.op��oExportar.Size = new System.Drawing.Size(150, 24);
            this.op��oExportar.TabIndex = 4;
            this.op��oExportar.Click += new System.EventHandler(this.op��oExportar_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG (*.jpg)|*.jpg|GIF (.gif)|*.gif|PNG (*.png)|*.png|Todos os arquivos|*.*";
            this.saveFileDialog.Title = "Exportar para arquivo";
            // 
            // EditarMercadoria
            // 
            this.Controls.Add(this.t�tuloBaseInferior);
            this.Controls.Add(this.quadroFotos);
            this.Name = "EditarMercadoria";
            this.Controls.SetChildIndex(this.quadroFotos, 0);
            this.Controls.SetChildIndex(this.t�tuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroFotos.ResumeLayout(false);
            this.quadroItem.ResumeLayout(false);
            this.quadroGeral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.T�tuloBaseInferior t�tuloBaseInferior;
        private Apresenta��o.Formul�rios.Quadro quadroFotos;
        private ListaFotos listaFotos;
        private Apresenta��o.Formul�rios.Quadro quadroItem;
        private Apresenta��o.Formul�rios.Op��o op��oEditar;
        private Apresenta��o.Formul�rios.Op��o op��oExcluir;
        private Apresenta��o.Formul�rios.Quadro quadroGeral;
        private Apresenta��o.Formul�rios.Op��o op��oProcurar;
        private Apresenta��o.Formul�rios.Op��o op��oExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
