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
    public class InformaçõesMercadoriaResumo : System.Windows.Forms.Form
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
        private Button btnRastrear;
        private Button btnSalvarFoto;
        private SaveFileDialog saveFileDialog;
        private GroupBox groupBox1;
        private Label lblPreço30x60x90Atacado;
        private Label lblPreço30x60Atacado;
        private Label lblRótuloPreço4;
        private Label lblRótuloPreço3;
        private Label lblPreço30Atacado;
        private Label lblRótuloPreço2;
        private Label lblPreçoÁVistaAtacado;
        private Label lblRótuloPreço1;
        private GroupBox groupBox2;
        private Label lblÍndice30x60x90;
        private Label lblÍndice30x60;
        private Label label5;
        private Label label7;
        private Label lblÍndice30;
        private Label label9;
        private Label lblÍndiceÁVista;
        private Label label11;
        private GroupBox groupBox3;
        private Label lblPreço30x60x90Consignado;
        private Label lblPreço30x60Consignado;
        private Label label12;
        private Label label13;
        private Label lblPreço30Consignado;
        private Label label15;
        private Label lblPreçoÁVistaConsignado;
        private Label label17;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        // Formulário

        private MostradorAnimação picFoto;
        private System.Windows.Forms.Label lblReferência;
        private System.Windows.Forms.Label lblFaixaGrupoPeso;
        private System.Windows.Forms.Label lblDescrição;
        private IContainer components;

        /// <param name="mercadoria">Mercadoria para exibição</param>
        public InformaçõesMercadoriaResumo(Entidades.Mercadoria.Mercadoria mercadoria, Entidades.Cotação cotação)
        {
            InitializeComponent();

            Cotação = cotação;
            Mercadoria = mercadoria;
            
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformaçõesMercadoriaResumo));
            this.lblReferência = new System.Windows.Forms.Label();
            this.mnuPreço = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuVista = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30x62 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30x60x90 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazoPersonalizado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazoPersonalizadoTxt = new System.Windows.Forms.ToolStripTextBox();
            this.lblFaixaGrupoPeso = new System.Windows.Forms.Label();
            this.lblDescrição = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnRastrear = new System.Windows.Forms.Button();
            this.btnSalvarFoto = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPreço30x60x90Atacado = new System.Windows.Forms.Label();
            this.lblPreço30x60Atacado = new System.Windows.Forms.Label();
            this.lblRótuloPreço4 = new System.Windows.Forms.Label();
            this.lblRótuloPreço3 = new System.Windows.Forms.Label();
            this.lblPreço30Atacado = new System.Windows.Forms.Label();
            this.lblRótuloPreço2 = new System.Windows.Forms.Label();
            this.lblPreçoÁVistaAtacado = new System.Windows.Forms.Label();
            this.lblRótuloPreço1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblÍndice30x60x90 = new System.Windows.Forms.Label();
            this.lblÍndice30x60 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblÍndice30 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblÍndiceÁVista = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPreço30x60x90Consignado = new System.Windows.Forms.Label();
            this.lblPreço30x60Consignado = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPreço30Consignado = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPreçoÁVistaConsignado = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.picFoto = new Apresentação.Mercadoria.MostradorAnimação();
            this.mnuPreço.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReferência
            // 
            this.lblReferência.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferência.BackColor = System.Drawing.Color.Transparent;
            this.lblReferência.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferência.Location = new System.Drawing.Point(195, 37);
            this.lblReferência.Name = "lblReferência";
            this.lblReferência.Size = new System.Drawing.Size(192, 23);
            this.lblReferência.TabIndex = 1;
            this.lblReferência.Text = "888.888.88.888-8";
            this.lblReferência.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
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
            // lblFaixaGrupoPeso
            // 
            this.lblFaixaGrupoPeso.AutoSize = true;
            this.lblFaixaGrupoPeso.BackColor = System.Drawing.Color.Transparent;
            this.lblFaixaGrupoPeso.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaixaGrupoPeso.Location = new System.Drawing.Point(394, 37);
            this.lblFaixaGrupoPeso.Name = "lblFaixaGrupoPeso";
            this.lblFaixaGrupoPeso.Size = new System.Drawing.Size(94, 24);
            this.lblFaixaGrupoPeso.TabIndex = 8;
            this.lblFaixaGrupoPeso.Text = "G5; 2.6g";
            this.lblFaixaGrupoPeso.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // lblDescrição
            // 
            this.lblDescrição.BackColor = System.Drawing.Color.Transparent;
            this.lblDescrição.Location = new System.Drawing.Point(203, 63);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(285, 24);
            this.lblDescrição.TabIndex = 10;
            this.lblDescrição.Text = "Descrição";
            this.lblDescrição.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDescrição.UseMnemonic = false;
            this.lblDescrição.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Location = new System.Drawing.Point(410, 426);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnRastrear
            // 
            this.btnRastrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.btnRastrear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRastrear.Location = new System.Drawing.Point(329, 426);
            this.btnRastrear.Name = "btnRastrear";
            this.btnRastrear.Size = new System.Drawing.Size(75, 23);
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
            this.btnSalvarFoto.Location = new System.Drawing.Point(459, 88);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(253)))));
            this.groupBox1.Controls.Add(this.lblPreço30x60x90Atacado);
            this.groupBox1.Controls.Add(this.lblPreço30x60Atacado);
            this.groupBox1.Controls.Add(this.lblRótuloPreço4);
            this.groupBox1.Controls.Add(this.lblRótuloPreço3);
            this.groupBox1.Controls.Add(this.lblPreço30Atacado);
            this.groupBox1.Controls.Add(this.lblRótuloPreço2);
            this.groupBox1.Controls.Add(this.lblPreçoÁVistaAtacado);
            this.groupBox1.Controls.Add(this.lblRótuloPreço1);
            this.groupBox1.Location = new System.Drawing.Point(45, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 98);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atacado";
            // 
            // lblPreço30x60x90Atacado
            // 
            this.lblPreço30x60x90Atacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço30x60x90Atacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço30x60x90Atacado.ContextMenuStrip = this.mnuPreço;
            this.lblPreço30x60x90Atacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço30x60x90Atacado.Location = new System.Drawing.Point(57, 78);
            this.lblPreço30x60x90Atacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço30x60x90Atacado.Name = "lblPreço30x60x90Atacado";
            this.lblPreço30x60x90Atacado.Size = new System.Drawing.Size(75, 16);
            this.lblPreço30x60x90Atacado.TabIndex = 26;
            this.lblPreço30x60x90Atacado.Tag = "3";
            this.lblPreço30x60x90Atacado.Text = "R$ 0,00";
            this.lblPreço30x60x90Atacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço30x60x90Atacado.UseMnemonic = false;
            // 
            // lblPreço30x60Atacado
            // 
            this.lblPreço30x60Atacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço30x60Atacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço30x60Atacado.ContextMenuStrip = this.mnuPreço;
            this.lblPreço30x60Atacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço30x60Atacado.Location = new System.Drawing.Point(57, 58);
            this.lblPreço30x60Atacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço30x60Atacado.Name = "lblPreço30x60Atacado";
            this.lblPreço30x60Atacado.Size = new System.Drawing.Size(75, 16);
            this.lblPreço30x60Atacado.TabIndex = 24;
            this.lblPreço30x60Atacado.Tag = "2";
            this.lblPreço30x60Atacado.Text = "R$ 1224,99";
            this.lblPreço30x60Atacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço30x60Atacado.UseMnemonic = false;
            // 
            // lblRótuloPreço4
            // 
            this.lblRótuloPreço4.AutoSize = true;
            this.lblRótuloPreço4.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço4.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço4.Location = new System.Drawing.Point(1, 81);
            this.lblRótuloPreço4.Name = "lblRótuloPreço4";
            this.lblRótuloPreço4.Size = new System.Drawing.Size(53, 13);
            this.lblRótuloPreço4.TabIndex = 25;
            this.lblRótuloPreço4.Tag = "3";
            this.lblRótuloPreço4.Text = "30x60x90";
            // 
            // lblRótuloPreço3
            // 
            this.lblRótuloPreço3.AutoSize = true;
            this.lblRótuloPreço3.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço3.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço3.Location = new System.Drawing.Point(18, 61);
            this.lblRótuloPreço3.Name = "lblRótuloPreço3";
            this.lblRótuloPreço3.Size = new System.Drawing.Size(36, 13);
            this.lblRótuloPreço3.TabIndex = 23;
            this.lblRótuloPreço3.Tag = "2";
            this.lblRótuloPreço3.Text = "30x60";
            // 
            // lblPreço30Atacado
            // 
            this.lblPreço30Atacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço30Atacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço30Atacado.ContextMenuStrip = this.mnuPreço;
            this.lblPreço30Atacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço30Atacado.Location = new System.Drawing.Point(57, 37);
            this.lblPreço30Atacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço30Atacado.Name = "lblPreço30Atacado";
            this.lblPreço30Atacado.Size = new System.Drawing.Size(75, 16);
            this.lblPreço30Atacado.TabIndex = 22;
            this.lblPreço30Atacado.Tag = "1";
            this.lblPreço30Atacado.Text = "R$ 0,00";
            this.lblPreço30Atacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço30Atacado.UseMnemonic = false;
            // 
            // lblRótuloPreço2
            // 
            this.lblRótuloPreço2.AutoSize = true;
            this.lblRótuloPreço2.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço2.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço2.Location = new System.Drawing.Point(35, 40);
            this.lblRótuloPreço2.Name = "lblRótuloPreço2";
            this.lblRótuloPreço2.Size = new System.Drawing.Size(19, 13);
            this.lblRótuloPreço2.TabIndex = 21;
            this.lblRótuloPreço2.Tag = "1";
            this.lblRótuloPreço2.Text = "30";
            // 
            // lblPreçoÁVistaAtacado
            // 
            this.lblPreçoÁVistaAtacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreçoÁVistaAtacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreçoÁVistaAtacado.ContextMenuStrip = this.mnuPreço;
            this.lblPreçoÁVistaAtacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreçoÁVistaAtacado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreçoÁVistaAtacado.Location = new System.Drawing.Point(57, 16);
            this.lblPreçoÁVistaAtacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreçoÁVistaAtacado.Name = "lblPreçoÁVistaAtacado";
            this.lblPreçoÁVistaAtacado.Size = new System.Drawing.Size(75, 16);
            this.lblPreçoÁVistaAtacado.TabIndex = 9;
            this.lblPreçoÁVistaAtacado.Tag = "0";
            this.lblPreçoÁVistaAtacado.Text = "R$ 0,00";
            this.lblPreçoÁVistaAtacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreçoÁVistaAtacado.UseMnemonic = false;
            // 
            // lblRótuloPreço1
            // 
            this.lblRótuloPreço1.AutoSize = true;
            this.lblRótuloPreço1.BackColor = System.Drawing.Color.Transparent;
            this.lblRótuloPreço1.ContextMenuStrip = this.mnuPreço;
            this.lblRótuloPreço1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRótuloPreço1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRótuloPreço1.Location = new System.Drawing.Point(15, 17);
            this.lblRótuloPreço1.Name = "lblRótuloPreço1";
            this.lblRótuloPreço1.Size = new System.Drawing.Size(39, 13);
            this.lblRótuloPreço1.TabIndex = 8;
            this.lblRótuloPreço1.Tag = "0";
            this.lblRótuloPreço1.Text = "À vista";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(253)))));
            this.groupBox2.Controls.Add(this.lblÍndice30x60x90);
            this.groupBox2.Controls.Add(this.lblÍndice30x60);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblÍndice30);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblÍndiceÁVista);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(193, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 98);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Índices";
            // 
            // lblÍndice30x60x90
            // 
            this.lblÍndice30x60x90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblÍndice30x60x90.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblÍndice30x60x90.ContextMenuStrip = this.mnuPreço;
            this.lblÍndice30x60x90.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblÍndice30x60x90.Location = new System.Drawing.Point(66, 78);
            this.lblÍndice30x60x90.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblÍndice30x60x90.Name = "lblÍndice30x60x90";
            this.lblÍndice30x60x90.Size = new System.Drawing.Size(66, 16);
            this.lblÍndice30x60x90.TabIndex = 26;
            this.lblÍndice30x60x90.Tag = "3";
            this.lblÍndice30x60x90.Text = "R$ 0,00";
            this.lblÍndice30x60x90.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblÍndice30x60x90.UseMnemonic = false;
            // 
            // lblÍndice30x60
            // 
            this.lblÍndice30x60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblÍndice30x60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblÍndice30x60.ContextMenuStrip = this.mnuPreço;
            this.lblÍndice30x60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblÍndice30x60.Location = new System.Drawing.Point(66, 58);
            this.lblÍndice30x60.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblÍndice30x60.Name = "lblÍndice30x60";
            this.lblÍndice30x60.Size = new System.Drawing.Size(66, 16);
            this.lblÍndice30x60.TabIndex = 24;
            this.lblÍndice30x60.Tag = "2";
            this.lblÍndice30x60.Text = "R$ 1224,99";
            this.lblÍndice30x60.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblÍndice30x60.UseMnemonic = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ContextMenuStrip = this.mnuPreço;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 25;
            this.label5.Tag = "3";
            this.label5.Text = "30x60x90";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ContextMenuStrip = this.mnuPreço;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 23;
            this.label7.Tag = "2";
            this.label7.Text = "30x60";
            // 
            // lblÍndice30
            // 
            this.lblÍndice30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblÍndice30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblÍndice30.ContextMenuStrip = this.mnuPreço;
            this.lblÍndice30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblÍndice30.Location = new System.Drawing.Point(66, 37);
            this.lblÍndice30.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblÍndice30.Name = "lblÍndice30";
            this.lblÍndice30.Size = new System.Drawing.Size(66, 16);
            this.lblÍndice30.TabIndex = 22;
            this.lblÍndice30.Tag = "1";
            this.lblÍndice30.Text = "R$ 0,00";
            this.lblÍndice30.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblÍndice30.UseMnemonic = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ContextMenuStrip = this.mnuPreço;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 21;
            this.label9.Tag = "1";
            this.label9.Text = "30";
            // 
            // lblÍndiceÁVista
            // 
            this.lblÍndiceÁVista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblÍndiceÁVista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblÍndiceÁVista.ContextMenuStrip = this.mnuPreço;
            this.lblÍndiceÁVista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblÍndiceÁVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblÍndiceÁVista.Location = new System.Drawing.Point(66, 16);
            this.lblÍndiceÁVista.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblÍndiceÁVista.Name = "lblÍndiceÁVista";
            this.lblÍndiceÁVista.Size = new System.Drawing.Size(66, 16);
            this.lblÍndiceÁVista.TabIndex = 9;
            this.lblÍndiceÁVista.Tag = "0";
            this.lblÍndiceÁVista.Text = "R$ 0,00";
            this.lblÍndiceÁVista.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblÍndiceÁVista.UseMnemonic = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ContextMenuStrip = this.mnuPreço;
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 8;
            this.label11.Tag = "0";
            this.label11.Text = "À vista";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(253)))));
            this.groupBox3.Controls.Add(this.lblPreço30x60x90Consignado);
            this.groupBox3.Controls.Add(this.lblPreço30x60Consignado);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lblPreço30Consignado);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lblPreçoÁVistaConsignado);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(344, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 98);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consignado";
            // 
            // lblPreço30x60x90Consignado
            // 
            this.lblPreço30x60x90Consignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço30x60x90Consignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço30x60x90Consignado.ContextMenuStrip = this.mnuPreço;
            this.lblPreço30x60x90Consignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço30x60x90Consignado.Location = new System.Drawing.Point(54, 78);
            this.lblPreço30x60x90Consignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço30x60x90Consignado.Name = "lblPreço30x60x90Consignado";
            this.lblPreço30x60x90Consignado.Size = new System.Drawing.Size(78, 16);
            this.lblPreço30x60x90Consignado.TabIndex = 26;
            this.lblPreço30x60x90Consignado.Tag = "3";
            this.lblPreço30x60x90Consignado.Text = "R$ 0,00";
            this.lblPreço30x60x90Consignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço30x60x90Consignado.UseMnemonic = false;
            // 
            // lblPreço30x60Consignado
            // 
            this.lblPreço30x60Consignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço30x60Consignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço30x60Consignado.ContextMenuStrip = this.mnuPreço;
            this.lblPreço30x60Consignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço30x60Consignado.Location = new System.Drawing.Point(54, 58);
            this.lblPreço30x60Consignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço30x60Consignado.Name = "lblPreço30x60Consignado";
            this.lblPreço30x60Consignado.Size = new System.Drawing.Size(78, 16);
            this.lblPreço30x60Consignado.TabIndex = 24;
            this.lblPreço30x60Consignado.Tag = "2";
            this.lblPreço30x60Consignado.Text = "R$ 1224,99";
            this.lblPreço30x60Consignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço30x60Consignado.UseMnemonic = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ContextMenuStrip = this.mnuPreço;
            this.label12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(-1, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 25;
            this.label12.Tag = "3";
            this.label12.Text = "30x60x90";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ContextMenuStrip = this.mnuPreço;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 23;
            this.label13.Tag = "2";
            this.label13.Text = "30x60";
            // 
            // lblPreço30Consignado
            // 
            this.lblPreço30Consignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreço30Consignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreço30Consignado.ContextMenuStrip = this.mnuPreço;
            this.lblPreço30Consignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreço30Consignado.Location = new System.Drawing.Point(54, 37);
            this.lblPreço30Consignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreço30Consignado.Name = "lblPreço30Consignado";
            this.lblPreço30Consignado.Size = new System.Drawing.Size(78, 16);
            this.lblPreço30Consignado.TabIndex = 22;
            this.lblPreço30Consignado.Tag = "1";
            this.lblPreço30Consignado.Text = "R$ 0,00";
            this.lblPreço30Consignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreço30Consignado.UseMnemonic = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ContextMenuStrip = this.mnuPreço;
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(33, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 21;
            this.label15.Tag = "1";
            this.label15.Text = "30";
            // 
            // lblPreçoÁVistaConsignado
            // 
            this.lblPreçoÁVistaConsignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPreçoÁVistaConsignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPreçoÁVistaConsignado.ContextMenuStrip = this.mnuPreço;
            this.lblPreçoÁVistaConsignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPreçoÁVistaConsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreçoÁVistaConsignado.Location = new System.Drawing.Point(54, 16);
            this.lblPreçoÁVistaConsignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPreçoÁVistaConsignado.Name = "lblPreçoÁVistaConsignado";
            this.lblPreçoÁVistaConsignado.Size = new System.Drawing.Size(78, 16);
            this.lblPreçoÁVistaConsignado.TabIndex = 9;
            this.lblPreçoÁVistaConsignado.Tag = "0";
            this.lblPreçoÁVistaConsignado.Text = "R$ 0,00";
            this.lblPreçoÁVistaConsignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPreçoÁVistaConsignado.UseMnemonic = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ContextMenuStrip = this.mnuPreço;
            this.label17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 8;
            this.label17.Tag = "0";
            this.label17.Text = "À vista";
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.Transparent;
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.Location = new System.Drawing.Point(45, 88);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(440, 228);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            this.picFoto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            // 
            // InformaçõesMercadoriaResumo
            // 
            this.AcceptButton = this.btnFechar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(498, 461);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFaixaGrupoPeso);
            this.Controls.Add(this.btnRastrear);
            this.Controls.Add(this.btnSalvarFoto);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblDescrição);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.lblReferência);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformaçõesMercadoriaResumo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformaçõesMercadoria";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Navy;
            this.Closed += new System.EventHandler(this.InformaçõesMercadoria_Closed);
            this.Shown += new System.EventHandler(this.InformaçõesMercadoria_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InformaçõesMercadoriaResumo_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformaçõesMercadoria_MouseDown);
            this.mnuPreço.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
                lblFaixaGrupoPeso.Text = (mercadoria.Faixa != null ? mercadoria.Faixa + "-" : "") + mercadoria.Grupo
                    + mercadoria.PesoFormatado;

                //lblPeso.Text = mercadoria.PesoFormatado;
                // lblÍndice.Text = Entidades.Mercadoria.Mercadoria.FormatarÍndice(mercadoria.ÍndiceArredondado);
                //lblFaixaGrupo.Text = (mercadoria.Faixa != null ?  mercadoria.Faixa  : "") + "-" + mercadoria.Grupo;

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
                // Atacado
                mercadoria.TabelaPreço = Tabela.ObterTabela(3);
                cotação = Entidades.Cotação.ObterCotaçãoVigente(Moeda.ObterMoeda(Moeda.MoedaSistema.Ouro));

                lblPreçoÁVistaAtacado.Text = CalcularPreço(dias[0]);
                lblPreço30Atacado.Text = CalcularPreço(dias[1]);
                lblPreço30x60Atacado.Text = CalcularPreço(dias[2]);
                lblPreço30x60x90Atacado.Text = CalcularPreço(dias[3]);

                // Decora as porcentagens
                double taxa30Dias = CalcularPreço(dias[1]) / CalcularPreço(dias[0]);
                double taxa30x60Dias = CalcularPreço(dias[2]) / CalcularPreço(dias[0]);
                double taxa30x60x90Dias = CalcularPreço(dias[3]) / CalcularPreço(dias[0]);

                // Consignado
                mercadoria.TabelaPreço = Tabela.ObterTabela(2);
                cotação = Entidades.Cotação.ObterCotaçãoVigente(Moeda.ObterMoeda(5));
                lblPreçoÁVistaConsignado.Text = CalcularPreço(dias[0]);
                lblPreço30Consignado.Text = CalcularPreço(dias[1]);
                lblPreço30x60Consignado.Text = CalcularPreço(dias[2]);
                lblPreço30x60x90Consignado.Text = CalcularPreço(dias[3]);

                // Índice
                lblÍndiceÁVista.Text = mercadoria.ÍndiceArredondado.ToString();
                lblÍndice30.Text = Math.Round(mercadoria.ÍndiceArredondado * taxa30Dias, 2).ToString();
                lblÍndice30x60.Text = Math.Round(mercadoria.ÍndiceArredondado * taxa30x60Dias, 2).ToString();
                lblÍndice30x60x90.Text = Math.Round(mercadoria.ÍndiceArredondado * taxa30x60x90Dias, 2).ToString();

                //lblCotação.Text = "* Cotação: " +
                //    (cotação != null ? cotação.Valor.ToString("C", DadosGlobais.Instância.Cultura) : "Informação não disponível");
                //lblCotação.Text = "; Tabela: " +
                //    (mercadoria.TabelaPreço != null ? mercadoria.TabelaPreço.Nome : "Desconhecida");
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
                lblRótuloPreço1, lblRótuloPreço2,
                lblRótuloPreço3, lblRótuloPreço4 };
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
                lblPreçoÁVistaAtacado, lblPreço30Atacado, lblPreço30x60Atacado, lblPreço30x60x90Atacado };
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

            // picEscolhaPreço4.Left = ((Label)sender).Right;
        }

        /// <summary>
        /// Mostra menu de contexto quando o preço é clicado.
        /// </summary>
        private void lblRótuloPreço_Click(object sender, EventArgs e)
        {
            Label[] lbl = new Label[] {
                lblPreçoÁVistaAtacado, lblPreço30Atacado, lblPreço30x60Atacado, lblPreço30x60x90Atacado };
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
                lblPreçoÁVistaAtacado, lblPreço30Atacado, lblPreço30x60Atacado, lblPreço30x60x90Atacado };
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
            //Focus();
            //ActiveControl = btnFechar;
            //btnFechar.Select();
            //btnFechar.Focus();
            this.Focus();
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

   
        private void InformaçõesMercadoriaResumo_Paint(object sender, PaintEventArgs e)
        {
            this.Focus();
        }
    }
}