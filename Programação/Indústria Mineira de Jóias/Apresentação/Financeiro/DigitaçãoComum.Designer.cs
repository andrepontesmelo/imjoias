namespace Apresentação.Financeiro
{
    partial class DigitaçãoComum
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
            this.quadroAgrupado = new Apresentação.Formulários.Quadro();
            this.bandejaAgrupada = new Apresentação.Financeiro.BandejaRelacionamento();
            this.quadroHistórico = new Apresentação.Formulários.Quadro();
            this.bandejaHistórico = new Apresentação.Financeiro.BandejaHistóricoRelacionamento();
            this.quadroFoto = new Apresentação.Mercadoria.QuadroFoto();
            this.quadroMercadoria = new Apresentação.Mercadoria.QuadroMercadoria();
            this.quadroAgrupado.SuspendLayout();
            this.quadroHistórico.SuspendLayout();
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
            this.quadroAgrupado.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgrupado.LetraTítulo = System.Drawing.Color.White;
            this.quadroAgrupado.Location = new System.Drawing.Point(0, 152);
            this.quadroAgrupado.MostrarBotãoMinMax = false;
            this.quadroAgrupado.Name = "quadroAgrupado";
            this.quadroAgrupado.Size = new System.Drawing.Size(473, 138);
            this.quadroAgrupado.TabIndex = 21;
            this.quadroAgrupado.Tamanho = 30;
            this.quadroAgrupado.Título = "Mercadorias";
            // 
            // bandejaAgrupada
            // 
            this.bandejaAgrupada.Agrupar = true;
            this.bandejaAgrupada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaAgrupada.Location = new System.Drawing.Point(1, 24);
            this.bandejaAgrupada.MostrarAgrupar = false;
            this.bandejaAgrupada.MostrarAlterarÍndice = false;
            this.bandejaAgrupada.MostrarBarraFerramentas = true;
            this.bandejaAgrupada.MostrarPreço = false;
            this.bandejaAgrupada.MostrarStatus = true;
            this.bandejaAgrupada.Name = "bandejaAgrupada";
            this.bandejaAgrupada.OrdenaçãoReferência = true;
            this.bandejaAgrupada.Size = new System.Drawing.Size(471, 113);
            this.bandejaAgrupada.TabIndex = 16;
            this.bandejaAgrupada.SeleçãoMudou += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAgrupada_SeleçãoMudou);
            this.bandejaAgrupada.SaquinhoExcluído += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAgrupada_SaquinhoExcluído);
            this.bandejaAgrupada.AlteraçãoÍndiceSolicitada += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaAgrupada_AlteraçãoÍndiceSolicitada);
            this.bandejaAgrupada.ColarSolicitado += new System.EventHandler(this.bandejaAgrupada_ColarSolicitado);
            this.bandejaAgrupada.TabelaAlterada += new Apresentação.Mercadoria.Bandeja.Bandeja.TabelaCallback(this.bandejaAgrupada_TabelaAlterada);
            this.bandejaAgrupada.AntesExclusão += new Apresentação.Mercadoria.Bandeja.Bandeja.AntesExclusãoDelegate(this.bandejaAgrupada_AntesExclusão);
            // 
            // quadroHistórico
            // 
            this.quadroHistórico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroHistórico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroHistórico.bInfDirArredondada = false;
            this.quadroHistórico.bInfEsqArredondada = false;
            this.quadroHistórico.bSupDirArredondada = true;
            this.quadroHistórico.bSupEsqArredondada = true;
            this.quadroHistórico.Controls.Add(this.bandejaHistórico);
            this.quadroHistórico.Cor = System.Drawing.Color.Black;
            this.quadroHistórico.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroHistórico.LetraTítulo = System.Drawing.Color.White;
            this.quadroHistórico.Location = new System.Drawing.Point(0, 152);
            this.quadroHistórico.MostrarBotãoMinMax = false;
            this.quadroHistórico.Name = "quadroHistórico";
            this.quadroHistórico.Size = new System.Drawing.Size(470, 121);
            this.quadroHistórico.TabIndex = 23;
            this.quadroHistórico.Tamanho = 30;
            this.quadroHistórico.Título = "Histórico do relacionamento";
            this.quadroHistórico.Visible = false;
            // 
            // bandejaHistórico
            // 
            this.bandejaHistórico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandejaHistórico.Location = new System.Drawing.Point(0, 26);
            this.bandejaHistórico.MostrarAgrupar = false;
            this.bandejaHistórico.MostrarAlterarÍndice = false;
            this.bandejaHistórico.MostrarBarraFerramentas = false;
            this.bandejaHistórico.MostrarExcluir = false;
            this.bandejaHistórico.MostrarPreço = false;
            this.bandejaHistórico.MostrarSeleçãoTabela = false;
            this.bandejaHistórico.MostrarStatus = false;
            this.bandejaHistórico.Name = "bandejaHistórico";
            this.bandejaHistórico.OrdenaçãoReferência = false;
            this.bandejaHistórico.PermitirExclusão = false;
            this.bandejaHistórico.PermitirSeleçãoTabela = false;
            this.bandejaHistórico.Size = new System.Drawing.Size(467, 95);
            this.bandejaHistórico.TabIndex = 2;
            this.bandejaHistórico.SeleçãoMudou += new Apresentação.Mercadoria.Bandeja.Bandeja.SaquinhoHandler(this.bandejaHistórico_SeleçãoMudou);
            this.bandejaHistórico.TabelaAlterada += new Apresentação.Mercadoria.Bandeja.Bandeja.TabelaCallback(this.bandejaHistórico_TabelaAlterada);
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
            this.quadroFoto.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroFoto.LetraTítulo = System.Drawing.Color.White;
            this.quadroFoto.Location = new System.Drawing.Point(231, 0);
            this.quadroFoto.MostrarBotãoMinMax = false;
            this.quadroFoto.Name = "quadroFoto";
            this.quadroFoto.Size = new System.Drawing.Size(242, 146);
            this.quadroFoto.TabIndex = 22;
            this.quadroFoto.Tamanho = 30;
            this.quadroFoto.Título = "Foto ilustrativa";
            // 
            // quadroMercadoria
            // 
            this.quadroMercadoria.AtualizarFotoNaSeleção = false;
            this.quadroMercadoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroMercadoria.bInfDirArredondada = true;
            this.quadroMercadoria.bInfEsqArredondada = true;
            this.quadroMercadoria.bSupDirArredondada = true;
            this.quadroMercadoria.bSupEsqArredondada = true;
            this.quadroMercadoria.ControleFoto = null;
            this.quadroMercadoria.Cor = System.Drawing.Color.Black;
            this.quadroMercadoria.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroMercadoria.LetraTítulo = System.Drawing.Color.White;
            this.quadroMercadoria.Location = new System.Drawing.Point(1, 0);
            this.quadroMercadoria.MaximumSize = new System.Drawing.Size(999999, 146);
            this.quadroMercadoria.MinimumSize = new System.Drawing.Size(160, 146);
            this.quadroMercadoria.MostrarBotãoMinMax = false;
            this.quadroMercadoria.Name = "quadroMercadoria";
            this.quadroMercadoria.Size = new System.Drawing.Size(222, 146);
            this.quadroMercadoria.SomenteDeLinha = true;
            this.quadroMercadoria.TabIndex = 20;
            this.quadroMercadoria.Tamanho = 30;
            this.quadroMercadoria.Título = "Escolha da mercadoria";
            this.quadroMercadoria.EventoAdicionou += new Apresentação.Mercadoria.QuadroMercadoria.AdicionouDelegate(this.quadroMercadoria_EventoAdicionou);
            this.quadroMercadoria.EventoAlterou += new Apresentação.Mercadoria.QuadroMercadoria.AlterouDelegate(this.quadroMercadoria_EventoAlterou);
            // 
            // DigitaçãoComum
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.quadroAgrupado);
            this.Controls.Add(this.quadroFoto);
            this.Controls.Add(this.quadroMercadoria);
            this.Controls.Add(this.quadroHistórico);
            this.Name = "DigitaçãoComum";
            this.Size = new System.Drawing.Size(473, 290);
            this.quadroAgrupado.ResumeLayout(false);
            this.quadroHistórico.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Apresentação.Formulários.Quadro quadroAgrupado;
        private Apresentação.Mercadoria.QuadroFoto quadroFoto;
        protected Apresentação.Mercadoria.QuadroMercadoria quadroMercadoria;
        protected Apresentação.Financeiro.BandejaRelacionamento bandejaAgrupada;
        private Apresentação.Formulários.Quadro quadroHistórico;
        private Apresentação.Financeiro.BandejaHistóricoRelacionamento bandejaHistórico;
    }
}
