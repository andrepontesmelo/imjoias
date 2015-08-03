using Apresentação.Álbum.Edição.Fotos;
namespace Apresentação.Álbum.Edição.Fotos
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
                DescarregarListaFotosDelegate método = new DescarregarListaFotosDelegate(DescarregarListaFotos);
                listaFotos.BeginInvoke(método);
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
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.quadroFotos = new Apresentação.Formulários.Quadro();
            this.listaFotos = new Apresentação.Álbum.Edição.Fotos.ListaFotos();
            this.quadroItem = new Apresentação.Formulários.Quadro();
            this.opçãoEditar = new Apresentação.Formulários.Opção();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.quadroGeral = new Apresentação.Formulários.Quadro();
            this.opçãoProcurar = new Apresentação.Formulários.Opção();
            this.opçãoExportar = new Apresentação.Formulários.Opção();
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
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Mercadoria XXX";
            this.títuloBaseInferior.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.propriedades__altura_58_;
            this.títuloBaseInferior.Location = new System.Drawing.Point(216, 14);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(565, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Edição de fotos";
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
            this.quadroFotos.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFotos.LetraTítulo = System.Drawing.Color.White;
            this.quadroFotos.Location = new System.Drawing.Point(216, 102);
            this.quadroFotos.MostrarBotãoMinMax = false;
            this.quadroFotos.Name = "quadroFotos";
            this.quadroFotos.Size = new System.Drawing.Size(547, 174);
            this.quadroFotos.TabIndex = 7;
            this.quadroFotos.Tamanho = 30;
            this.quadroFotos.Título = "Coleção de Fotos";
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
            this.quadroItem.Controls.Add(this.opçãoEditar);
            this.quadroItem.Controls.Add(this.opçãoExcluir);
            this.quadroItem.Controls.Add(this.opçãoExportar);
            this.quadroItem.Cor = System.Drawing.Color.Black;
            this.quadroItem.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroItem.LetraTítulo = System.Drawing.Color.White;
            this.quadroItem.Location = new System.Drawing.Point(7, 91);
            this.quadroItem.MostrarBotãoMinMax = false;
            this.quadroItem.Name = "quadroItem";
            this.quadroItem.Size = new System.Drawing.Size(160, 101);
            this.quadroItem.TabIndex = 1;
            this.quadroItem.Tamanho = 30;
            this.quadroItem.Título = "Foto selecionada";
            this.quadroItem.Visible = false;
            // 
            // opçãoEditar
            // 
            this.opçãoEditar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoEditar.Descrição = "Editar foto...";
            this.opçãoEditar.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.Propriedades;
            this.opçãoEditar.Location = new System.Drawing.Point(5, 31);
            this.opçãoEditar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoEditar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoEditar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoEditar.Name = "opçãoEditar";
            this.opçãoEditar.Size = new System.Drawing.Size(150, 24);
            this.opçãoEditar.TabIndex = 2;
            this.opçãoEditar.Click += new System.EventHandler(this.opçãoEditar_Click);
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExcluir.Descrição = "Excluir foto";
            this.opçãoExcluir.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.Excluir;
            this.opçãoExcluir.Location = new System.Drawing.Point(5, 55);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 24);
            this.opçãoExcluir.TabIndex = 3;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // quadroGeral
            // 
            this.quadroGeral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroGeral.bInfDirArredondada = true;
            this.quadroGeral.bInfEsqArredondada = true;
            this.quadroGeral.bSupDirArredondada = true;
            this.quadroGeral.bSupEsqArredondada = true;
            this.quadroGeral.Controls.Add(this.opçãoProcurar);
            this.quadroGeral.Cor = System.Drawing.Color.Black;
            this.quadroGeral.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroGeral.LetraTítulo = System.Drawing.Color.White;
            this.quadroGeral.Location = new System.Drawing.Point(7, 13);
            this.quadroGeral.MostrarBotãoMinMax = false;
            this.quadroGeral.Name = "quadroGeral";
            this.quadroGeral.Size = new System.Drawing.Size(160, 71);
            this.quadroGeral.TabIndex = 2;
            this.quadroGeral.Tamanho = 30;
            this.quadroGeral.Título = "Opções gerais";
            // 
            // opçãoProcurar
            // 
            this.opçãoProcurar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoProcurar.Descrição = "Procurar outra mercadoria...";
            this.opçãoProcurar.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.Lupa;
            this.opçãoProcurar.Location = new System.Drawing.Point(5, 32);
            this.opçãoProcurar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoProcurar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoProcurar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoProcurar.Name = "opçãoProcurar";
            this.opçãoProcurar.Size = new System.Drawing.Size(150, 30);
            this.opçãoProcurar.TabIndex = 2;
            this.opçãoProcurar.Click += new System.EventHandler(this.opçãoProcurar_Click);
            // 
            // opçãoExportar
            // 
            this.opçãoExportar.BackColor = System.Drawing.Color.Transparent;
            this.opçãoExportar.Descrição = "Exportar para arquivo...";
            this.opçãoExportar.Imagem = global::Apresentação.Álbum.Edição.Properties.Resources.saveHS;
            this.opçãoExportar.Location = new System.Drawing.Point(5, 77);
            this.opçãoExportar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExportar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExportar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExportar.Name = "opçãoExportar";
            this.opçãoExportar.Size = new System.Drawing.Size(150, 24);
            this.opçãoExportar.TabIndex = 4;
            this.opçãoExportar.Click += new System.EventHandler(this.opçãoExportar_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG (*.jpg)|*.jpg|GIF (.gif)|*.gif|PNG (*.png)|*.png|Todos os arquivos|*.*";
            this.saveFileDialog.Title = "Exportar para arquivo";
            // 
            // EditarMercadoria
            // 
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.quadroFotos);
            this.Name = "EditarMercadoria";
            this.Controls.SetChildIndex(this.quadroFotos, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroFotos.ResumeLayout(false);
            this.quadroItem.ResumeLayout(false);
            this.quadroGeral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
        private Apresentação.Formulários.Quadro quadroFotos;
        private ListaFotos listaFotos;
        private Apresentação.Formulários.Quadro quadroItem;
        private Apresentação.Formulários.Opção opçãoEditar;
        private Apresentação.Formulários.Opção opçãoExcluir;
        private Apresentação.Formulários.Quadro quadroGeral;
        private Apresentação.Formulários.Opção opçãoProcurar;
        private Apresentação.Formulários.Opção opçãoExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
