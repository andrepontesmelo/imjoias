namespace Apresenta��o.Financeiro
{
    partial class Digita��oComum
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
            this.quadroAgrupado = new Apresenta��o.Formul�rios.Quadro();
            this.bandejaAgrupada = new Apresenta��o.Financeiro.BandejaRelacionamento();
            this.quadroHist�rico = new Apresenta��o.Formul�rios.Quadro();
            this.bandejaHist�rico = new Apresenta��o.Financeiro.BandejaHist�ricoRelacionamento();
            this.quadroFoto = new Apresenta��o.Mercadoria.QuadroFoto();
            this.quadroMercadoria = new Apresenta��o.Mercadoria.QuadroMercadoria();
            this.quadroAgrupado.SuspendLayout();
            this.quadroHist�rico.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadroAgrupado
            // 
            this.quadroAgrupado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroAgrupado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroAgrupado.bInfDirArredondada = false;
            this.quadroAgrupado.bInfEsqArredondada = false;
            this.quadroAgrupado.bSupDirArredondada = true;
            this.quadroAgrupado.bSupEsqArredondada = true;
            this.quadroAgrupado.Controls.Add(this.bandejaAgrupada);
            this.quadroAgrupado.Cor = System.Drawing.Color.Black;
            this.quadroAgrupado.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgrupado.LetraT�tulo = System.Drawing.Color.White;
            this.quadroAgrupado.Location = new System.Drawing.Point(0, 152);
            this.quadroAgrupado.MostrarBot�oMinMax = false;
            this.quadroAgrupado.Name = "quadroAgrupado";
            this.quadroAgrupado.Size = new System.Drawing.Size(473, 138);
            this.quadroAgrupado.TabIndex = 21;
            this.quadroAgrupado.Tamanho = 30;
            this.quadroAgrupado.T�tulo = "Mercadorias";
            // 
            // bandejaAgrupada
            // 
            this.bandejaAgrupada.Agrupar = true;
            this.bandejaAgrupada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaAgrupada.Location = new System.Drawing.Point(1, 24);
            this.bandejaAgrupada.MostrarAgrupar = false;
            this.bandejaAgrupada.MostrarAlterar�ndice = false;
            this.bandejaAgrupada.MostrarBarraFerramentas = true;
            this.bandejaAgrupada.MostrarPre�o = false;
            this.bandejaAgrupada.MostrarStatus = true;
            this.bandejaAgrupada.Name = "bandejaAgrupada";
            this.bandejaAgrupada.Ordena��oRefer�ncia = true;
            this.bandejaAgrupada.Size = new System.Drawing.Size(471, 113);
            this.bandejaAgrupada.TabIndex = 16;
            this.bandejaAgrupada.Sele��oMudou += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAgrupada_Sele��oMudou);
            this.bandejaAgrupada.SaquinhoExclu�do += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAgrupada_SaquinhoExclu�do);
            this.bandejaAgrupada.Altera��o�ndiceSolicitada += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAgrupada_Altera��o�ndiceSolicitada);
            this.bandejaAgrupada.ColarSolicitado += new System.EventHandler(this.bandejaAgrupada_ColarSolicitado);
            this.bandejaAgrupada.TabelaAlterada += new Apresenta��o.Mercadoria.Bandeja.Bandeja.TabelaCallback(this.bandejaAgrupada_TabelaAlterada);
            this.bandejaAgrupada.AntesExclus�o += new Apresenta��o.Mercadoria.Bandeja.Bandeja.AntesExclus�oDelegate(this.bandejaAgrupada_AntesExclus�o);
            // 
            // quadroHist�rico
            // 
            this.quadroHist�rico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroHist�rico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroHist�rico.bInfDirArredondada = false;
            this.quadroHist�rico.bInfEsqArredondada = false;
            this.quadroHist�rico.bSupDirArredondada = true;
            this.quadroHist�rico.bSupEsqArredondada = true;
            this.quadroHist�rico.Controls.Add(this.bandejaHist�rico);
            this.quadroHist�rico.Cor = System.Drawing.Color.Black;
            this.quadroHist�rico.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroHist�rico.LetraT�tulo = System.Drawing.Color.White;
            this.quadroHist�rico.Location = new System.Drawing.Point(0, 152);
            this.quadroHist�rico.MostrarBot�oMinMax = false;
            this.quadroHist�rico.Name = "quadroHist�rico";
            this.quadroHist�rico.Size = new System.Drawing.Size(470, 121);
            this.quadroHist�rico.TabIndex = 23;
            this.quadroHist�rico.Tamanho = 30;
            this.quadroHist�rico.T�tulo = "Hist�rico do relacionamento";
            this.quadroHist�rico.Visible = false;
            // 
            // bandejaHist�rico
            // 
            this.bandejaHist�rico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaHist�rico.Location = new System.Drawing.Point(0, 26);
            this.bandejaHist�rico.MostrarAgrupar = false;
            this.bandejaHist�rico.MostrarAlterar�ndice = false;
            this.bandejaHist�rico.MostrarBarraFerramentas = false;
            this.bandejaHist�rico.MostrarExcluir = false;
            this.bandejaHist�rico.MostrarPre�o = false;
            this.bandejaHist�rico.MostrarSele��oTabela = false;
            this.bandejaHist�rico.MostrarStatus = false;
            this.bandejaHist�rico.Name = "bandejaHist�rico";
            this.bandejaHist�rico.Ordena��oRefer�ncia = false;
            this.bandejaHist�rico.PermitirExclus�o = false;
            this.bandejaHist�rico.PermitirSele��oTabela = false;
            this.bandejaHist�rico.Size = new System.Drawing.Size(467, 95);
            this.bandejaHist�rico.TabIndex = 2;
            this.bandejaHist�rico.Sele��oMudou += new Apresenta��o.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaHist�rico_Sele��oMudou);
            this.bandejaHist�rico.TabelaAlterada += new Apresenta��o.Mercadoria.Bandeja.Bandeja.TabelaCallback(this.bandejaHist�rico_TabelaAlterada);
            // 
            // quadroFoto
            // 
            this.quadroFoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(215)))));
            this.quadroFoto.bInfDirArredondada = true;
            this.quadroFoto.bInfEsqArredondada = true;
            this.quadroFoto.bSupDirArredondada = true;
            this.quadroFoto.bSupEsqArredondada = true;
            this.quadroFoto.Cor = System.Drawing.Color.Black;
            this.quadroFoto.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFoto.LetraT�tulo = System.Drawing.Color.White;
            this.quadroFoto.Location = new System.Drawing.Point(231, 0);
            this.quadroFoto.MostrarBot�oMinMax = false;
            this.quadroFoto.Name = "quadroFoto";
            this.quadroFoto.Size = new System.Drawing.Size(242, 146);
            this.quadroFoto.TabIndex = 22;
            this.quadroFoto.Tamanho = 30;
            this.quadroFoto.T�tulo = "Foto ilustrativa";
            // 
            // quadroMercadoria
            // 
            this.quadroMercadoria.AtualizarFotoNaSele��o = false;
            this.quadroMercadoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroMercadoria.bInfDirArredondada = true;
            this.quadroMercadoria.bInfEsqArredondada = true;
            this.quadroMercadoria.bSupDirArredondada = true;
            this.quadroMercadoria.bSupEsqArredondada = true;
            this.quadroMercadoria.ControleFoto = null;
            this.quadroMercadoria.Cor = System.Drawing.Color.Black;
            this.quadroMercadoria.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroMercadoria.LetraT�tulo = System.Drawing.Color.White;
            this.quadroMercadoria.Location = new System.Drawing.Point(1, 0);
            this.quadroMercadoria.MaximumSize = new System.Drawing.Size(999999, 146);
            this.quadroMercadoria.MinimumSize = new System.Drawing.Size(160, 146);
            this.quadroMercadoria.MostrarBot�oMinMax = false;
            this.quadroMercadoria.Name = "quadroMercadoria";
            this.quadroMercadoria.Size = new System.Drawing.Size(222, 146);
            this.quadroMercadoria.SomenteDeLinha = true;
            this.quadroMercadoria.TabIndex = 20;
            this.quadroMercadoria.Tamanho = 30;
            this.quadroMercadoria.T�tulo = "Escolha da mercadoria";
            this.quadroMercadoria.EventoAdicionou += new Apresenta��o.Mercadoria.QuadroMercadoria.AdicionouDelegate(this.quadroMercadoria_EventoAdicionou);
            this.quadroMercadoria.EventoAlterou += new Apresenta��o.Mercadoria.QuadroMercadoria.AlterouDelegate(this.quadroMercadoria_EventoAlterou);
            // 
            // Digita��oComum
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.quadroAgrupado);
            this.Controls.Add(this.quadroFoto);
            this.Controls.Add(this.quadroMercadoria);
            this.Controls.Add(this.quadroHist�rico);
            this.Name = "Digita��oComum";
            this.Size = new System.Drawing.Size(473, 290);
            this.quadroAgrupado.ResumeLayout(false);
            this.quadroHist�rico.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresenta��o.Formul�rios.Quadro quadroAgrupado;
        private Apresenta��o.Mercadoria.QuadroFoto quadroFoto;
        protected Apresenta��o.Mercadoria.QuadroMercadoria quadroMercadoria;
        protected Apresenta��o.Financeiro.BandejaRelacionamento bandejaAgrupada;
        private Apresenta��o.Formul�rios.Quadro quadroHist�rico;
        private Apresenta��o.Financeiro.BandejaHist�ricoRelacionamento bandejaHist�rico;
    }
}
