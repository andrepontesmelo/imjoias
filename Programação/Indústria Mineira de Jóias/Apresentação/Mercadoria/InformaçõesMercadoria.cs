using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades;
using Entidades.Configuração;
using Entidades.Álbum;
using Acesso.Comum;

namespace Apresentação.Mercadoria
{
    /// <summary>
    /// Use apenas Show() para abrir.
    /// </summary>
    public class InformaçõesMercadoria : System.Windows.Forms.Form
    {
        /* Português: pagamento à vista (com crase)
         *            pagamento a prazo (sem crase)
         */
        private const string strPagVista = "Preço à vista";
        private const string strPagPrazo = "A prazo: ";

        // Atributos
        private Entidades.Mercadoria.Mercadoria mercadoria;
        private Entidades.Cotação cotação;
        private int[] dias = new int[] { 0, 30, 45, 60 };

        // Eventos
        public EventHandler Fechando;


        // Gambiarras do Windows
        public const int WM_NCLBUTTONDOWN = 0xA1;
        private System.Windows.Forms.Button btnFechar;
        private ContextMenuStrip mnuPreço;
        private ToolStripMenuItem mnuVista;
        private ToolStripMenuItem mnuPrazo;
        private ToolStripMenuItem mnuPrazo30;
        private ToolStripMenuItem mnuPrazo30x62;
        private ToolStripMenuItem mnuPrazo30x60x90;
        private ToolStripMenuItem mnuPrazoPersonalizado;
        private ToolStripTextBox mnuPrazoPersonalizadoTxt;
        private Label lblPreço2;
        private Label lblRótuloPreço30;
        private Label lblPreço3;
        private Label lblRótuloPreço30x60;
        private Label lblPreço4;
        private PictureBox picEscolhaPreço4;
        private Label lblRótuloPreço30x60x90;
        private Label lblCotação;
        private Button btnRastrear;
        private Button btnSalvarFoto;
        private SaveFileDialog saveFileDialog;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        // Formulário

        private MostradorAnimação picFoto;
        private System.Windows.Forms.Label lblReferência;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblÍndice;
        private System.Windows.Forms.Label lblRótuloPreço1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPreço1;
        private System.Windows.Forms.Label lblFaixaGrupo;
        private System.Windows.Forms.Label lblDescrição;
        private IContainer components;

        /// <param name="mercadoria">Mercadoria para exibição</param>
        public InformaçõesMercadoria(Entidades.Mercadoria.Mercadoria mercadoria, Entidades.Cotação cotação)
        {
            InitializeComponent();

            Cotação = cotação;
            Mercadoria = mercadoria;

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformaçõesMercadoria));
            this.lblReferência = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblÍndice = new System.Windows.Forms.Label();
            this.lblPreço1 = new System.Windows.Forms.Label();
            this.mnuPreço = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuVista = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30x62 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30x60x90 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazoPersonalizado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazoPersonalizadoTxt = new System.Windows.Forms.ToolStripTextBox();
            this.lblRótuloPreço1 = new System.Windows.Forms.Label();
            this.lblFaixaGrupo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblPreço2 = new System.Windows.Forms.Label();
            this.lblRótuloPreço30 = new System.Windows.Forms.Label();
            this.lblPreço3 = new System.Windows.Forms.Label();
            this.lblRótuloPreço30x60 = new System.Windows.Forms.Label();
            this.lblPreço4 = new System.Windows.Forms.Label();
            this.picEscolhaPreço4 = new System.Windows.Forms.PictureBox();
            this.lblRótuloPreço30x60x90 = new System.Windows.Forms.Label();
            this.lblCotação = new System.Windows.Forms.Label();
            this.btnRastrear = new System.Windows.Forms.Button();
            this.btnSalvarFoto = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.picFoto = new Apresentação.Mercadoria.MostradorAnimação();
            this.mnuPreço.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEscolhaPreço4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReferência
            // 
            this.lblReferência.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferência.BackColor = System.Drawing.Color.Transparent;
            this.lblReferência.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferência.Location = new System.Drawing.Point(303, 38);
            this.lblReferência.Name = "lblReferência";
            this.lblReferência.Size = new System.Drawing.Size(192, 23);
            this.lblReferência.TabIndex = 1;
            this.lblReferência.Text = "888.888.88.888-8";
            this.lblReferência.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // lblPeso
            // 
            this.lblPeso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPeso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPeso.Location = new System.Drawing.Point(84, 360);
            this.lblPeso.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(100, 16);
            this.lblPeso.TabIndex = 2;
            this.lblPeso.Text = "0 g";
            this.lblPeso.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPeso.UseMnemonic = false;
            this.lblPeso.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(81, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Peso";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(84, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Índice";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // lblÍndice
            // 
            this.lblÍndice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblÍndice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblÍndice.Location = new System.Drawing.Point(84, 397);
            this.lblÍndice.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblÍndice.Name = "lblÍndice";
            this.lblÍndice.Size = new System.Drawing.Size(100, 16);
            this.lblÍndice.TabIndex = 5;
            this.lblÍndice.Text = "0,00";
            this.lblÍndice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblÍndice.UseMnemonic = false;
            this.lblÍndice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // lblPreço1
            // 
            this.lblPreço1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço1.ContextMenuStrip = this.mnuPreço;
            this.lblPreço1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreço1.Location = new System.Drawing.Point(237, 360);
            this.lblPreço1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço1.Name = "lblPreço1";
            this.lblPreço1.Size = new System.Drawing.Size(100, 16);
            this.lblPreço1.TabIndex = 7;
            this.lblPreço1.Tag = "0";
            this.lblPreço1.Text = "R$ 0,00";
            this.lblPreço1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço1.UseMnemonic = false;
            // 
            // mnuPreço
            // 
            this.mnuPreço.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVista,
            this.mnuPrazo});
            this.mnuPreço.Name = "mnuPreço";
            this.mnuPreço.Size = new System.Drawing.Size(146, 48);
            // 
            // mnuVista
            // 
            this.mnuVista.Image = global::Apresentação.Resource.Flag_greenHS;
            this.mnuVista.Name = "mnuVista";
            this.mnuVista.Size = new System.Drawing.Size(145, 22);
            this.mnuVista.Text = "Preço à vista";
            this.mnuVista.Click += new System.EventHandler(this.mnuVista_Click);
            // 
            // mnuPrazo
            // 
            this.mnuPrazo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrazo30,
            this.mnuPrazo30x62,
            this.mnuPrazo30x60x90,
            this.mnuPrazoPersonalizado});
            this.mnuPrazo.Image = global::Apresentação.Resource.MonthlyViewHS;
            this.mnuPrazo.Name = "mnuPrazo";
            this.mnuPrazo.Size = new System.Drawing.Size(145, 22);
            this.mnuPrazo.Text = "Preço a prazo";
            // 
            // mnuPrazo30
            // 
            this.mnuPrazo30.Name = "mnuPrazo30";
            this.mnuPrazo30.Size = new System.Drawing.Size(147, 22);
            this.mnuPrazo30.Text = "30 dias";
            this.mnuPrazo30.Click += new System.EventHandler(this.mnuPrazo30_Click);
            // 
            // mnuPrazo30x62
            // 
            this.mnuPrazo30x62.Name = "mnuPrazo30x62";
            this.mnuPrazo30x62.Size = new System.Drawing.Size(147, 22);
            this.mnuPrazo30x62.Text = "30x62 dias";
            this.mnuPrazo30x62.Click += new System.EventHandler(this.mnuPrazo30x60_Click);
            // 
            // mnuPrazo30x60x90
            // 
            this.mnuPrazo30x60x90.Name = "mnuPrazo30x60x90";
            this.mnuPrazo30x60x90.Size = new System.Drawing.Size(147, 22);
            this.mnuPrazo30x60x90.Text = "30x60x90 dias";
            this.mnuPrazo30x60x90.Click += new System.EventHandler(this.mnuPrazo30x60x90_Click);
            // 
            // mnuPrazoPersonalizado
            // 
            this.mnuPrazoPersonalizado.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrazoPersonalizadoTxt});
            this.mnuPrazoPersonalizado.Image = global::Apresentação.Resource.EditTableHS;
            this.mnuPrazoPersonalizado.Name = "mnuPrazoPersonalizado";
            this.mnuPrazoPersonalizado.Size = new System.Drawing.Size(147, 22);
            this.mnuPrazoPersonalizado.Text = "Personalizado";
            // 
            // mnuPrazoPersonalizadoTxt
            // 
            this.mnuPrazoPersonalizadoTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "30",
            "30x60",
            "30x60x90"});
            this.mnuPrazoPersonalizadoTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.mnuPrazoPersonalizadoTxt.Name = "mnuPrazoPersonalizadoTxt";
            this.mnuPrazoPersonalizadoTxt.Size = new System.Drawing.Size(100, 23);
            this.mnuPrazoPersonalizadoTxt.Text = "(Clique para editar)";
            this.mnuPrazoPersonalizadoTxt.ToolTipText = "Utilize o formato de exemplo: 30x60x90";
            this.mnuPrazoPersonalizadoTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mnuPrazoPersonalizadoTxt_KeyDown);
            this.mnuPrazoPersonalizadoTxt.Click += new System.EventHandler(this.mnuPrazoPersonalizadoTxt_Enter);
            // 
            // lblRótuloPreço1
            // 
            this.lblRótuloPreço1.AutoSize = true;
            this.lblRótuloPreço1.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço1.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço1.Location = new System.Drawing.Point(237, 344);
            this.lblRótuloPreço1.Name = "lblRótuloPreço1";
            this.lblRótuloPreço1.Size = new System.Drawing.Size(69, 13);
            this.lblRótuloPreço1.TabIndex = 6;
            this.lblRótuloPreço1.Tag = "0";
            this.lblRótuloPreço1.Text = "Preço à vista";
            // 
            // lblFaixaGrupo
            // 
            this.lblFaixaGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFaixaGrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFaixaGrupo.Location = new System.Drawing.Point(84, 434);
            this.lblFaixaGrupo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblFaixaGrupo.Name = "lblFaixaGrupo";
            this.lblFaixaGrupo.Size = new System.Drawing.Size(100, 16);
            this.lblFaixaGrupo.TabIndex = 9;
            this.lblFaixaGrupo.Text = "G5";
            this.lblFaixaGrupo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblFaixaGrupo.UseMnemonic = false;
            this.lblFaixaGrupo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(84, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Faixa e grupo";
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // lblDescrição
            // 
            this.lblDescrição.BackColor = System.Drawing.Color.Transparent;
            this.lblDescrição.Location = new System.Drawing.Point(192, 63);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(290, 24);
            this.lblDescrição.TabIndex = 10;
            this.lblDescrição.Text = "Descrição";
            this.lblDescrição.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDescrição.UseMnemonic = false;
            this.lblDescrição.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Location = new System.Drawing.Point(281, 427);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(56, 23);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblPreço2
            // 
            this.lblPreço2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço2.ContextMenuStrip = this.mnuPreço;
            this.lblPreço2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço2.Location = new System.Drawing.Point(382, 360);
            this.lblPreço2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço2.Name = "lblPreço2";
            this.lblPreço2.Size = new System.Drawing.Size(100, 16);
            this.lblPreço2.TabIndex = 14;
            this.lblPreço2.Tag = "1";
            this.lblPreço2.Text = "R$ 0,00";
            this.lblPreço2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço2.UseMnemonic = false;
            // 
            // lblRótuloPreço30
            // 
            this.lblRótuloPreço30.AutoSize = true;
            this.lblRótuloPreço30.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço30.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço30.Location = new System.Drawing.Point(382, 344);
            this.lblRótuloPreço30.Name = "lblRótuloPreço30";
            this.lblRótuloPreço30.Size = new System.Drawing.Size(61, 13);
            this.lblRótuloPreço30.TabIndex = 13;
            this.lblRótuloPreço30.Tag = "1";
            this.lblRótuloPreço30.Text = "A prazo: 30";
            // 
            // lblPreço3
            // 
            this.lblPreço3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço3.ContextMenuStrip = this.mnuPreço;
            this.lblPreço3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço3.Location = new System.Drawing.Point(382, 397);
            this.lblPreço3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço3.Name = "lblPreço3";
            this.lblPreço3.Size = new System.Drawing.Size(100, 16);
            this.lblPreço3.TabIndex = 17;
            this.lblPreço3.Tag = "2";
            this.lblPreço3.Text = "R$ 0,00";
            this.lblPreço3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço3.UseMnemonic = false;
            // 
            // lblRótuloPreço30x60
            // 
            this.lblRótuloPreço30x60.AutoSize = true;
            this.lblRótuloPreço30x60.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço30x60.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço30x60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço30x60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço30x60.Location = new System.Drawing.Point(382, 381);
            this.lblRótuloPreço30x60.Name = "lblRótuloPreço30x60";
            this.lblRótuloPreço30x60.Size = new System.Drawing.Size(78, 13);
            this.lblRótuloPreço30x60.TabIndex = 16;
            this.lblRótuloPreço30x60.Tag = "2";
            this.lblRótuloPreço30x60.Text = "A prazo: 30x60";
            // 
            // lblPreço4
            // 
            this.lblPreço4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço4.ContextMenuStrip = this.mnuPreço;
            this.lblPreço4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço4.Location = new System.Drawing.Point(382, 434);
            this.lblPreço4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço4.Name = "lblPreço4";
            this.lblPreço4.Size = new System.Drawing.Size(100, 16);
            this.lblPreço4.TabIndex = 20;
            this.lblPreço4.Tag = "3";
            this.lblPreço4.Text = "R$ 0,00";
            this.lblPreço4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço4.UseMnemonic = false;
            this.lblPreço4.Click += new System.EventHandler(this.lblRótuloPreço_Click);
            this.lblPreço4.MouseHover += new System.EventHandler(this.lblRótuloPreço_MouseHover);
            // 
            // picEscolhaPreço4
            // 
            this.picEscolhaPreço4.ContextMenuStrip = this.mnuPreço;
            this.picEscolhaPreço4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEscolhaPreço4.Image = global::Apresentação.Resource.FillDownHS;
            this.picEscolhaPreço4.Location = new System.Drawing.Point(480, 435);
            this.picEscolhaPreço4.Name = "picEscolhaPreço4";
            this.picEscolhaPreço4.Size = new System.Drawing.Size(10, 16);
            this.picEscolhaPreço4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEscolhaPreço4.TabIndex = 21;
            this.picEscolhaPreço4.TabStop = false;
            this.picEscolhaPreço4.Tag = "3";
            this.picEscolhaPreço4.Click += new System.EventHandler(this.lblRótuloPreço_Click);
            this.picEscolhaPreço4.MouseHover += new System.EventHandler(this.lblRótuloPreço_MouseHover);
            // 
            // lblRótuloPreço30x60x90
            // 
            this.lblRótuloPreço30x60x90.AutoSize = true;
            this.lblRótuloPreço30x60x90.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço30x60x90.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço30x60x90.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço30x60x90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço30x60x90.Location = new System.Drawing.Point(382, 418);
            this.lblRótuloPreço30x60x90.Name = "lblRótuloPreço30x60x90";
            this.lblRótuloPreço30x60x90.Size = new System.Drawing.Size(95, 13);
            this.lblRótuloPreço30x60x90.TabIndex = 19;
            this.lblRótuloPreço30x60x90.Tag = "3";
            this.lblRótuloPreço30x60x90.Text = "A prazo: 30x60x90";
            this.lblRótuloPreço30x60x90.Click += new System.EventHandler(this.lblRótuloPreço_Click);
            this.lblRótuloPreço30x60x90.Paint += new System.Windows.Forms.PaintEventHandler(this.AoDesenharLblPreço);
            this.lblRótuloPreço30x60x90.MouseHover += new System.EventHandler(this.lblRótuloPreço_MouseHover);
            this.lblRótuloPreço30x60x90.Resize += new System.EventHandler(this.lblRótuloPreço_Resize);
            // 
            // lblCotação
            // 
            this.lblCotação.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCotação.AutoSize = true;
            this.lblCotação.BackColor = System.Drawing.Color.Transparent;
            this.lblCotação.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCotação.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.lblCotação.Location = new System.Drawing.Point(249, 379);
            this.lblCotação.Name = "lblCotação";
            this.lblCotação.Size = new System.Drawing.Size(88, 12);
            this.lblCotação.TabIndex = 22;
            this.lblCotação.Text = "* Cotação: R$ ??,??";
            // 
            // btnRastrear
            // 
            this.btnRastrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnRastrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRastrear.Location = new System.Drawing.Point(219, 427);
            this.btnRastrear.Name = "btnRastrear";
            this.btnRastrear.Size = new System.Drawing.Size(56, 23);
            this.btnRastrear.TabIndex = 23;
            this.btnRastrear.Text = "&Rastrear";
            this.btnRastrear.UseVisualStyleBackColor = false;
            this.btnRastrear.Click += new System.EventHandler(this.btnRastrear_Click);
            // 
            // btnSalvarFoto
            // 
            this.btnSalvarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalvarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvarFoto.Image = global::Apresentação.Resource.saveHS;
            this.btnSalvarFoto.Location = new System.Drawing.Point(464, 88);
            this.btnSalvarFoto.Name = "btnSalvarFoto";
            this.btnSalvarFoto.Size = new System.Drawing.Size(26, 26);
            this.btnSalvarFoto.TabIndex = 24;
            this.btnSalvarFoto.UseVisualStyleBackColor = false;
            this.btnSalvarFoto.Click += new System.EventHandler(this.btnSalvarFoto_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.Filter = "JPEG (*.jpg)|*.jpg|GIF (*.gif)|*.gif|PNG (*.png)|*.png";
            this.saveFileDialog.Title = "Salvar foto de mercadoria";
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.Transparent;
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.Location = new System.Drawing.Point(45, 88);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(445, 242);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            this.picFoto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // InformaçõesMercadoria
            // 
            this.AcceptButton = this.btnFechar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(498, 461);
            this.ControlBox = false;
            this.Controls.Add(this.lblPreço4);
            this.Controls.Add(this.lblFaixaGrupo);
            this.Controls.Add(this.lblCotação);
            this.Controls.Add(this.btnRastrear);
            this.Controls.Add(this.picEscolhaPreço4);
            this.Controls.Add(this.btnSalvarFoto);
            this.Controls.Add(this.lblPreço3);
            this.Controls.Add(this.lblRótuloPreço30x60x90);
            this.Controls.Add(this.lblRótuloPreço30x60);
            this.Controls.Add(this.lblPreço2);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblRótuloPreço30);
            this.Controls.Add(this.lblÍndice);
            this.Controls.Add(this.lblPreço1);
            this.Controls.Add(this.lblDescrição);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRótuloPreço1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.lblReferência);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformaçõesMercadoria";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformaçõesMercadoria";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Navy;
            this.Closed += new System.EventHandler(this.InformaçõesMercadoria_Closed);
            this.Shown += new System.EventHandler(this.InformaçõesMercadoria_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InformaçõesMercadoria_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InformaçõesMercadoria_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            this.mnuPreço.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEscolhaPreço4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Ocorre ao pressionar um botão do mouse
        /// </summary>
        private void InformaçõesMercadoria_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ReleaseCapture();

            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        /// <summary>
        /// Fecha janela
        /// </summary>
        private void btnFechar_Click(object sender, System.EventArgs e)
        {
            if (Fechando != null)
                Fechando(sender, e);

            this.Close();
        }

        /// <summary>
        /// Ocorre ao fechar janela
        /// </summary>
        private void InformaçõesMercadoria_Closed(object sender, System.EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Mercadoria exibida
        /// </summary>
        public Entidades.Mercadoria.Mercadoria Mercadoria
        {
            get { return mercadoria; }
            set
            {
                this.mercadoria = value;

                lblReferência.Text = mercadoria.Referência;
                lblPeso.Text = mercadoria.PesoFormatado;
                lblÍndice.Text = Entidades.Mercadoria.Mercadoria.FormatarÍndice(mercadoria.ÍndiceArredondado);
                lblFaixaGrupo.Text = (mercadoria.Faixa != null ? mercadoria.Faixa : "") + "-" + mercadoria.Grupo;

                AtualizarPreço();

                lblDescrição.Text = mercadoria.Descrição;
                //picFoto.Image	   = mercadoria.EnquadrarFoto(picFoto.Width, picFoto.Height);
                picFoto.MostrarAnimação(mercadoria);
            }
        }

        /// <summary>
        /// Cotação a ser utilizada.
        /// </summary>
        public Entidades.Cotação Cotação
        {
            get { return cotação; }
            set
            {
                cotação = value;
                AtualizarPreço();
            }
        }

        /// <summary>
        /// Atualiza exibição de preço.
        /// </summary>
        private void AtualizarPreço()
        {
            if (mercadoria != null)
            {
                lblPreço1.Text = CalcularPreço(dias[0]);
                lblPreço2.Text = CalcularPreço(dias[1]);
                lblPreço3.Text = CalcularPreço(dias[2]);
                lblPreço4.Text = CalcularPreço(dias[3]);
                lblCotação.Text = "* Cotação: " +
                    (cotação != null ? cotação.Valor.ToString("C", DadosGlobais.Instância.Cultura) : "Informação não disponível");
                lblCotação.Text = "; Tabela: " +
                    (mercadoria.TabelaPreço != null ? mercadoria.TabelaPreço.Nome : "Desconhecida");

                bool tabelaVerejo = (mercadoria.TabelaPreço.Nome.IndexOf("Varejo", StringComparison.CurrentCultureIgnoreCase) >= 0);
                lblRótuloPreço30.Visible = picEscolhaPreço4.Visible = lblRótuloPreço30x60.Visible = lblRótuloPreço30x60x90.Visible = !tabelaVerejo;
            }
        }

        /// <summary>
        /// Calcula o preço da mercadoria.
        /// </summary>
        /// <returns>Preço da mercadoria.</returns>
        private Preço CalcularPreço(int dias)
        {
            Preço preço;

            if (cotação != null)
                preço = mercadoria.CalcularPreço(cotação);
            else
                throw new Exception("Cotação desconhecida.");

            preço.Dias = dias;

            return preço;
        }

        #region Mecanismo para escolha de preço (prazo)

        /// <summary>
        /// Desenha linha pontilhada abaixo do rótulo de preço.
        /// </summary>
        private void AoDesenharLblPreço(object sender, PaintEventArgs e)
        {
            for (int i = 3; i < lblRótuloPreço1.ClientSize.Width; i += 3)
                e.Graphics.FillRectangle(Brushes.Green, i, lblRótuloPreço1.ClientRectangle.Bottom - 2, 1, 1);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento à vista.
        /// </summary>
        private void mnuVista_Click(object sender, EventArgs e)
        {
            AtualizarMenuRótulo(strPagVista);
            AtualizarMenuPreço(0);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento a prazo de 30 dias.
        /// </summary>
        private void mnuPrazo30_Click(object sender, EventArgs e)
        {
            AtualizarMenuRótulo(strPagPrazo + "30");
            AtualizarMenuPreço(30);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento a prazo de 30x60 dias.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPrazo30x60_Click(object sender, EventArgs e)
        {
            AtualizarMenuRótulo(strPagPrazo + "30x60");
            AtualizarMenuPreço(45);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento a prazo de 30x60x90 dias.
        /// </summary>
        private void mnuPrazo30x60x90_Click(object sender, EventArgs e)
        {
            AtualizarMenuRótulo(strPagPrazo + "30x60x90");
            AtualizarMenuPreço(60);
        }

        /// <summary>
        /// Interpreta o prazo digitado pelo usuário no formato
        /// "##x##x##x..." (ex.: 30x60x90x120).
        /// </summary>
        private void InterpretarPrazoPersonalizado()
        {
            int dias;

            try
            {
                dias = Preço.InterpretarPrestações(mnuPrazoPersonalizadoTxt.Text);
            }
            catch (FormatException e)
            {
                MessageBox.Show(this,
                    e.Message,
                    "Prazo personalizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

                MessageBox.Show(this,
                    "Não foi possível construir o prazo proposto.",
                    "Prazo personalizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            AtualizarMenuRótulo(strPagPrazo + mnuPrazoPersonalizadoTxt.Text.ToLower());
            AtualizarMenuPreço(Convert.ToInt32(dias));
        }

        /// <summary>
        /// Atualiza o rótulo do preço conforme tag do menu.
        /// </summary>
        /// <param name="rótulo">Rótulo a ser exibido.</param>
        private void AtualizarMenuRótulo(string rótulo)
        {
            Label[] lbl = new Label[] {
                lblRótuloPreço1, lblRótuloPreço30,
                lblRótuloPreço30x60, lblRótuloPreço30x60x90 };
            Label lblRótulo;

            lblRótulo = lbl[int.Parse(mnuPreço.Tag.ToString())];
            lblRótulo.Text = rótulo;
        }

        /// <summary>
        /// Atualiza o preço conforme tag do menu.
        /// </summary>
        /// <param name="preço">Preço a ser exibido.</param>
        private void AtualizarMenuPreço(int dias)
        {
            Label[] lbl = new Label[] {
                lblPreço1, lblPreço2, lblPreço3, lblPreço4 };
            Label lblPreço;

            lblPreço = lbl[int.Parse(mnuPreço.Tag.ToString())];
            this.dias[int.Parse(mnuPreço.Tag.ToString())] = dias;
            lblPreço.Text = CalcularPreço(dias); ;
        }

        /// <summary>
        /// Reposiciona a imagem para mostrar opções de menu
        /// ao lado do rótulo de preço, sempre que ele mudar de tamanho.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRótuloPreço_Resize(object sender, EventArgs e)
        {
            //PictureBox[] pic = new PictureBox[] {
            //   picEscolhaPreço1, picEscolhaPreço2,
            //    picEscolhaPreço3, picEscolhaPreço4 };
            //
            //pic[int.Parse(((Label)sender).Tag.ToString())].Left = ((Label)sender).Right;

            picEscolhaPreço4.Left = ((Label)sender).Right;
        }

        /// <summary>
        /// Mostra menu de contexto quando o preço é clicado.
        /// </summary>
        private void lblRótuloPreço_Click(object sender, EventArgs e)
        {
            Label[] lbl = new Label[] {
                lblPreço1, lblPreço2, lblPreço3, lblPreço4 };
            Label lblPreço;

            lblPreço = lbl[int.Parse(((Control)sender).Tag.ToString())];

            mnuPreço.Tag = ((Control)sender).Tag;
            mnuPreço.Show(PointToScreen(new Point(lblPreço.Left, lblPreço.Bottom)));
        }

        /// <summary>
        /// Mostra menu de contexto quando o mouse passa sobre o preço.
        /// </summary>
        private void lblRótuloPreço_MouseHover(object sender, EventArgs e)
        {
            Label[] lbl = new Label[] {
                lblPreço1, lblPreço2, lblPreço3, lblPreço4 };
            Label lblPreço;

            lblPreço = lbl[int.Parse(((Control)sender).Tag.ToString())];

            mnuPreço.Tag = ((Control)sender).Tag;
            mnuPreço.Show(PointToScreen(new Point(lblPreço.Left, lblPreço.Bottom)));
        }

        /// <summary>
        /// Trata evento de tecla pressionada no TextBox dentro
        /// do menu de contexto de personalização de pagamento a prazo.
        /// </summary>
        private void mnuPrazoPersonalizadoTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                InterpretarPrazoPersonalizado();
        }

        /// <summary>
        /// Seleciona todo o texto ao ganhar foco.
        /// </summary>
        private void mnuPrazoPersonalizadoTxt_Enter(object sender, EventArgs e)
        {
            mnuPrazoPersonalizadoTxt.TextBox.SelectAll();
        }

        #endregion

        private void InformaçõesMercadoria_Shown(object sender, EventArgs e)
        {
            //btnFechar.Focus();
            //Focus();
        }

        private void btnRastrear_Click(object sender, EventArgs e)
        {
            RastrearMercadoria rastro = new RastrearMercadoria(mercadoria);

            rastro.Show(this);
        }

        private void btnSalvarFoto_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    mercadoria.Foto.Save(saveFileDialog.FileName);
                    MessageBox.Show(
                        this,
                        "Foto da mercadoria " + mercadoria.Referência + " salva em " + saveFileDialog.FileName + ".",
                        "Salvar foto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(this,
                        "Não foi possível salvar a foto.\n\n" + erro.Message,
                        "Erro salvando foto",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InformaçõesMercadoria_KeyDown(object sender, KeyEventArgs e)
        {
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape || keyData == Keys.Enter))
            {
                if (keyData == Keys.Enter)
                {
                    if (Fechando != null)
                        Fechando(null, null);
                }

                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void InformaçõesMercadoria_Paint(object sender, PaintEventArgs e)
        {
            this.Focus();
        }
    }
}