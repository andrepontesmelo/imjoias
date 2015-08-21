using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades;
using Entidades.Configura��o;
using Entidades.�lbum;
using Acesso.Comum;

namespace Apresenta��o.Mercadoria
{
    /// <summary>
    /// Use apenas Show() para abrir.
    /// </summary>
    public class Informa��esMercadoriaResumo : System.Windows.Forms.Form
    {
        /* Portugu�s: pagamento � vista (com crase)
         *            pagamento a prazo (sem crase)
         */
        private const string strPagVista = "Pre�o � vista";
        private const string strPagPrazo = "A prazo: ";

        // Atributos
        private Entidades.Mercadoria.Mercadoria mercadoria;
        private Entidades.Cota��o cota��o;
        private int[] dias = new int[] { 0, 30, 45, 60 };

        // Eventos
        public EventHandler Fechando;

        // Gambiarras do Windows
        public const int WM_NCLBUTTONDOWN = 0xA1;
        private System.Windows.Forms.Button btnFechar;
        private ContextMenuStrip mnuPre�o;
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
        private Label lblPre�o30x60x90Atacado;
        private Label lblPre�o30x60Atacado;
        private Label lblR�tuloPre�o4;
        private Label lblR�tuloPre�o3;
        private Label lblPre�o30Atacado;
        private Label lblR�tuloPre�o2;
        private Label lblPre�o�VistaAtacado;
        private Label lblR�tuloPre�o1;
        private GroupBox groupBox2;
        private Label lbl�ndice30x60x90;
        private Label lbl�ndice30x60;
        private Label label5;
        private Label label7;
        private Label lbl�ndice30;
        private Label label9;
        private Label lbl�ndice�Vista;
        private Label label11;
        private GroupBox groupBox3;
        private Label lblPre�o30x60x90Consignado;
        private Label lblPre�o30x60Consignado;
        private Label label12;
        private Label label13;
        private Label lblPre�o30Consignado;
        private Label label15;
        private Label lblPre�o�VistaConsignado;
        private Label label17;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        // Formul�rio

        private MostradorAnima��o picFoto;
        private System.Windows.Forms.Label lblRefer�ncia;
        private System.Windows.Forms.Label lblFaixaGrupoPeso;
        private System.Windows.Forms.Label lblDescri��o;
        private IContainer components;

        /// <param name="mercadoria">Mercadoria para exibi��o</param>
        public Informa��esMercadoriaResumo(Entidades.Mercadoria.Mercadoria mercadoria, Entidades.Cota��o cota��o)
        {
            InitializeComponent();

            Cota��o = cota��o;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informa��esMercadoriaResumo));
            this.lblRefer�ncia = new System.Windows.Forms.Label();
            this.mnuPre�o = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuVista = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30x62 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazo30x60x90 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazoPersonalizado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrazoPersonalizadoTxt = new System.Windows.Forms.ToolStripTextBox();
            this.lblFaixaGrupoPeso = new System.Windows.Forms.Label();
            this.lblDescri��o = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnRastrear = new System.Windows.Forms.Button();
            this.btnSalvarFoto = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPre�o30x60x90Atacado = new System.Windows.Forms.Label();
            this.lblPre�o30x60Atacado = new System.Windows.Forms.Label();
            this.lblR�tuloPre�o4 = new System.Windows.Forms.Label();
            this.lblR�tuloPre�o3 = new System.Windows.Forms.Label();
            this.lblPre�o30Atacado = new System.Windows.Forms.Label();
            this.lblR�tuloPre�o2 = new System.Windows.Forms.Label();
            this.lblPre�o�VistaAtacado = new System.Windows.Forms.Label();
            this.lblR�tuloPre�o1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl�ndice30x60x90 = new System.Windows.Forms.Label();
            this.lbl�ndice30x60 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl�ndice30 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl�ndice�Vista = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPre�o30x60x90Consignado = new System.Windows.Forms.Label();
            this.lblPre�o30x60Consignado = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPre�o30Consignado = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPre�o�VistaConsignado = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.picFoto = new Apresenta��o.Mercadoria.MostradorAnima��o();
            this.mnuPre�o.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRefer�ncia
            // 
            this.lblRefer�ncia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefer�ncia.BackColor = System.Drawing.Color.Transparent;
            this.lblRefer�ncia.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefer�ncia.Location = new System.Drawing.Point(195, 37);
            this.lblRefer�ncia.Name = "lblRefer�ncia";
            this.lblRefer�ncia.Size = new System.Drawing.Size(192, 23);
            this.lblRefer�ncia.TabIndex = 1;
            this.lblRefer�ncia.Text = "888.888.88.888-8";
            this.lblRefer�ncia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Informa��esMercadoria_MouseDown);
            // 
            // mnuPre�o
            // 
            this.mnuPre�o.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVista,
            this.mnuPrazo});
            this.mnuPre�o.Name = "mnuPre�o";
            this.mnuPre�o.Size = new System.Drawing.Size(146, 48);
            // 
            // mnuVista
            // 
            this.mnuVista.Image = global::Apresenta��o.Resource.Flag_greenHS;
            this.mnuVista.Name = "mnuVista";
            this.mnuVista.Size = new System.Drawing.Size(145, 22);
            this.mnuVista.Text = "Pre�o � vista";
            this.mnuVista.Click += new System.EventHandler(this.mnuVista_Click);
            // 
            // mnuPrazo
            // 
            this.mnuPrazo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrazo30,
            this.mnuPrazo30x62,
            this.mnuPrazo30x60x90,
            this.mnuPrazoPersonalizado});
            this.mnuPrazo.Image = global::Apresenta��o.Resource.MonthlyViewHS;
            this.mnuPrazo.Name = "mnuPrazo";
            this.mnuPrazo.Size = new System.Drawing.Size(145, 22);
            this.mnuPrazo.Text = "Pre�o a prazo";
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
            this.mnuPrazoPersonalizado.Image = global::Apresenta��o.Resource.EditTableHS;
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
            this.lblFaixaGrupoPeso.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Informa��esMercadoria_MouseDown);
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.BackColor = System.Drawing.Color.Transparent;
            this.lblDescri��o.Location = new System.Drawing.Point(203, 63);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Size = new System.Drawing.Size(285, 24);
            this.lblDescri��o.TabIndex = 10;
            this.lblDescri��o.Text = "Descri��o";
            this.lblDescri��o.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDescri��o.UseMnemonic = false;
            this.lblDescri��o.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Informa��esMercadoria_MouseDown);
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
            this.btnSalvarFoto.Image = global::Apresenta��o.Resource.saveHS;
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
            this.groupBox1.Controls.Add(this.lblPre�o30x60x90Atacado);
            this.groupBox1.Controls.Add(this.lblPre�o30x60Atacado);
            this.groupBox1.Controls.Add(this.lblR�tuloPre�o4);
            this.groupBox1.Controls.Add(this.lblR�tuloPre�o3);
            this.groupBox1.Controls.Add(this.lblPre�o30Atacado);
            this.groupBox1.Controls.Add(this.lblR�tuloPre�o2);
            this.groupBox1.Controls.Add(this.lblPre�o�VistaAtacado);
            this.groupBox1.Controls.Add(this.lblR�tuloPre�o1);
            this.groupBox1.Location = new System.Drawing.Point(45, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 98);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atacado";
            // 
            // lblPre�o30x60x90Atacado
            // 
            this.lblPre�o30x60x90Atacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o30x60x90Atacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o30x60x90Atacado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o30x60x90Atacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o30x60x90Atacado.Location = new System.Drawing.Point(57, 78);
            this.lblPre�o30x60x90Atacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o30x60x90Atacado.Name = "lblPre�o30x60x90Atacado";
            this.lblPre�o30x60x90Atacado.Size = new System.Drawing.Size(75, 16);
            this.lblPre�o30x60x90Atacado.TabIndex = 26;
            this.lblPre�o30x60x90Atacado.Tag = "3";
            this.lblPre�o30x60x90Atacado.Text = "R$ 0,00";
            this.lblPre�o30x60x90Atacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o30x60x90Atacado.UseMnemonic = false;
            // 
            // lblPre�o30x60Atacado
            // 
            this.lblPre�o30x60Atacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o30x60Atacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o30x60Atacado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o30x60Atacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o30x60Atacado.Location = new System.Drawing.Point(57, 58);
            this.lblPre�o30x60Atacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o30x60Atacado.Name = "lblPre�o30x60Atacado";
            this.lblPre�o30x60Atacado.Size = new System.Drawing.Size(75, 16);
            this.lblPre�o30x60Atacado.TabIndex = 24;
            this.lblPre�o30x60Atacado.Tag = "2";
            this.lblPre�o30x60Atacado.Text = "R$ 1224,99";
            this.lblPre�o30x60Atacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o30x60Atacado.UseMnemonic = false;
            // 
            // lblR�tuloPre�o4
            // 
            this.lblR�tuloPre�o4.AutoSize = true;
            this.lblR�tuloPre�o4.BackColor = System.Drawing.Color.Transparent;
            this.lblR�tuloPre�o4.ContextMenuStrip = this.mnuPre�o;
            this.lblR�tuloPre�o4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblR�tuloPre�o4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR�tuloPre�o4.Location = new System.Drawing.Point(1, 81);
            this.lblR�tuloPre�o4.Name = "lblR�tuloPre�o4";
            this.lblR�tuloPre�o4.Size = new System.Drawing.Size(53, 13);
            this.lblR�tuloPre�o4.TabIndex = 25;
            this.lblR�tuloPre�o4.Tag = "3";
            this.lblR�tuloPre�o4.Text = "30x60x90";
            // 
            // lblR�tuloPre�o3
            // 
            this.lblR�tuloPre�o3.AutoSize = true;
            this.lblR�tuloPre�o3.BackColor = System.Drawing.Color.Transparent;
            this.lblR�tuloPre�o3.ContextMenuStrip = this.mnuPre�o;
            this.lblR�tuloPre�o3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblR�tuloPre�o3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR�tuloPre�o3.Location = new System.Drawing.Point(18, 61);
            this.lblR�tuloPre�o3.Name = "lblR�tuloPre�o3";
            this.lblR�tuloPre�o3.Size = new System.Drawing.Size(36, 13);
            this.lblR�tuloPre�o3.TabIndex = 23;
            this.lblR�tuloPre�o3.Tag = "2";
            this.lblR�tuloPre�o3.Text = "30x60";
            // 
            // lblPre�o30Atacado
            // 
            this.lblPre�o30Atacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o30Atacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o30Atacado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o30Atacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o30Atacado.Location = new System.Drawing.Point(57, 37);
            this.lblPre�o30Atacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o30Atacado.Name = "lblPre�o30Atacado";
            this.lblPre�o30Atacado.Size = new System.Drawing.Size(75, 16);
            this.lblPre�o30Atacado.TabIndex = 22;
            this.lblPre�o30Atacado.Tag = "1";
            this.lblPre�o30Atacado.Text = "R$ 0,00";
            this.lblPre�o30Atacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o30Atacado.UseMnemonic = false;
            // 
            // lblR�tuloPre�o2
            // 
            this.lblR�tuloPre�o2.AutoSize = true;
            this.lblR�tuloPre�o2.BackColor = System.Drawing.Color.Transparent;
            this.lblR�tuloPre�o2.ContextMenuStrip = this.mnuPre�o;
            this.lblR�tuloPre�o2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblR�tuloPre�o2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR�tuloPre�o2.Location = new System.Drawing.Point(35, 40);
            this.lblR�tuloPre�o2.Name = "lblR�tuloPre�o2";
            this.lblR�tuloPre�o2.Size = new System.Drawing.Size(19, 13);
            this.lblR�tuloPre�o2.TabIndex = 21;
            this.lblR�tuloPre�o2.Tag = "1";
            this.lblR�tuloPre�o2.Text = "30";
            // 
            // lblPre�o�VistaAtacado
            // 
            this.lblPre�o�VistaAtacado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o�VistaAtacado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o�VistaAtacado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o�VistaAtacado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o�VistaAtacado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPre�o�VistaAtacado.Location = new System.Drawing.Point(57, 16);
            this.lblPre�o�VistaAtacado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o�VistaAtacado.Name = "lblPre�o�VistaAtacado";
            this.lblPre�o�VistaAtacado.Size = new System.Drawing.Size(75, 16);
            this.lblPre�o�VistaAtacado.TabIndex = 9;
            this.lblPre�o�VistaAtacado.Tag = "0";
            this.lblPre�o�VistaAtacado.Text = "R$ 0,00";
            this.lblPre�o�VistaAtacado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o�VistaAtacado.UseMnemonic = false;
            // 
            // lblR�tuloPre�o1
            // 
            this.lblR�tuloPre�o1.AutoSize = true;
            this.lblR�tuloPre�o1.BackColor = System.Drawing.Color.Transparent;
            this.lblR�tuloPre�o1.ContextMenuStrip = this.mnuPre�o;
            this.lblR�tuloPre�o1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblR�tuloPre�o1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR�tuloPre�o1.Location = new System.Drawing.Point(15, 17);
            this.lblR�tuloPre�o1.Name = "lblR�tuloPre�o1";
            this.lblR�tuloPre�o1.Size = new System.Drawing.Size(39, 13);
            this.lblR�tuloPre�o1.TabIndex = 8;
            this.lblR�tuloPre�o1.Tag = "0";
            this.lblR�tuloPre�o1.Text = "� vista";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(253)))));
            this.groupBox2.Controls.Add(this.lbl�ndice30x60x90);
            this.groupBox2.Controls.Add(this.lbl�ndice30x60);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbl�ndice30);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbl�ndice�Vista);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(193, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 98);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "�ndices";
            // 
            // lbl�ndice30x60x90
            // 
            this.lbl�ndice30x60x90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lbl�ndice30x60x90.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl�ndice30x60x90.ContextMenuStrip = this.mnuPre�o;
            this.lbl�ndice30x60x90.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl�ndice30x60x90.Location = new System.Drawing.Point(66, 78);
            this.lbl�ndice30x60x90.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lbl�ndice30x60x90.Name = "lbl�ndice30x60x90";
            this.lbl�ndice30x60x90.Size = new System.Drawing.Size(66, 16);
            this.lbl�ndice30x60x90.TabIndex = 26;
            this.lbl�ndice30x60x90.Tag = "3";
            this.lbl�ndice30x60x90.Text = "R$ 0,00";
            this.lbl�ndice30x60x90.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl�ndice30x60x90.UseMnemonic = false;
            // 
            // lbl�ndice30x60
            // 
            this.lbl�ndice30x60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lbl�ndice30x60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl�ndice30x60.ContextMenuStrip = this.mnuPre�o;
            this.lbl�ndice30x60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl�ndice30x60.Location = new System.Drawing.Point(66, 58);
            this.lbl�ndice30x60.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lbl�ndice30x60.Name = "lbl�ndice30x60";
            this.lbl�ndice30x60.Size = new System.Drawing.Size(66, 16);
            this.lbl�ndice30x60.TabIndex = 24;
            this.lbl�ndice30x60.Tag = "2";
            this.lbl�ndice30x60.Text = "R$ 1224,99";
            this.lbl�ndice30x60.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl�ndice30x60.UseMnemonic = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ContextMenuStrip = this.mnuPre�o;
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
            this.label7.ContextMenuStrip = this.mnuPre�o;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 23;
            this.label7.Tag = "2";
            this.label7.Text = "30x60";
            // 
            // lbl�ndice30
            // 
            this.lbl�ndice30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lbl�ndice30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl�ndice30.ContextMenuStrip = this.mnuPre�o;
            this.lbl�ndice30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl�ndice30.Location = new System.Drawing.Point(66, 37);
            this.lbl�ndice30.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lbl�ndice30.Name = "lbl�ndice30";
            this.lbl�ndice30.Size = new System.Drawing.Size(66, 16);
            this.lbl�ndice30.TabIndex = 22;
            this.lbl�ndice30.Tag = "1";
            this.lbl�ndice30.Text = "R$ 0,00";
            this.lbl�ndice30.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl�ndice30.UseMnemonic = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ContextMenuStrip = this.mnuPre�o;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 21;
            this.label9.Tag = "1";
            this.label9.Text = "30";
            // 
            // lbl�ndice�Vista
            // 
            this.lbl�ndice�Vista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lbl�ndice�Vista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl�ndice�Vista.ContextMenuStrip = this.mnuPre�o;
            this.lbl�ndice�Vista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl�ndice�Vista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl�ndice�Vista.Location = new System.Drawing.Point(66, 16);
            this.lbl�ndice�Vista.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lbl�ndice�Vista.Name = "lbl�ndice�Vista";
            this.lbl�ndice�Vista.Size = new System.Drawing.Size(66, 16);
            this.lbl�ndice�Vista.TabIndex = 9;
            this.lbl�ndice�Vista.Tag = "0";
            this.lbl�ndice�Vista.Text = "R$ 0,00";
            this.lbl�ndice�Vista.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl�ndice�Vista.UseMnemonic = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ContextMenuStrip = this.mnuPre�o;
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 8;
            this.label11.Tag = "0";
            this.label11.Text = "� vista";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(253)))));
            this.groupBox3.Controls.Add(this.lblPre�o30x60x90Consignado);
            this.groupBox3.Controls.Add(this.lblPre�o30x60Consignado);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lblPre�o30Consignado);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lblPre�o�VistaConsignado);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(344, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 98);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consignado";
            // 
            // lblPre�o30x60x90Consignado
            // 
            this.lblPre�o30x60x90Consignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o30x60x90Consignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o30x60x90Consignado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o30x60x90Consignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o30x60x90Consignado.Location = new System.Drawing.Point(54, 78);
            this.lblPre�o30x60x90Consignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o30x60x90Consignado.Name = "lblPre�o30x60x90Consignado";
            this.lblPre�o30x60x90Consignado.Size = new System.Drawing.Size(78, 16);
            this.lblPre�o30x60x90Consignado.TabIndex = 26;
            this.lblPre�o30x60x90Consignado.Tag = "3";
            this.lblPre�o30x60x90Consignado.Text = "R$ 0,00";
            this.lblPre�o30x60x90Consignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o30x60x90Consignado.UseMnemonic = false;
            // 
            // lblPre�o30x60Consignado
            // 
            this.lblPre�o30x60Consignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o30x60Consignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o30x60Consignado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o30x60Consignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o30x60Consignado.Location = new System.Drawing.Point(54, 58);
            this.lblPre�o30x60Consignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o30x60Consignado.Name = "lblPre�o30x60Consignado";
            this.lblPre�o30x60Consignado.Size = new System.Drawing.Size(78, 16);
            this.lblPre�o30x60Consignado.TabIndex = 24;
            this.lblPre�o30x60Consignado.Tag = "2";
            this.lblPre�o30x60Consignado.Text = "R$ 1224,99";
            this.lblPre�o30x60Consignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o30x60Consignado.UseMnemonic = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ContextMenuStrip = this.mnuPre�o;
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
            this.label13.ContextMenuStrip = this.mnuPre�o;
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 23;
            this.label13.Tag = "2";
            this.label13.Text = "30x60";
            // 
            // lblPre�o30Consignado
            // 
            this.lblPre�o30Consignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o30Consignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o30Consignado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o30Consignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o30Consignado.Location = new System.Drawing.Point(54, 37);
            this.lblPre�o30Consignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o30Consignado.Name = "lblPre�o30Consignado";
            this.lblPre�o30Consignado.Size = new System.Drawing.Size(78, 16);
            this.lblPre�o30Consignado.TabIndex = 22;
            this.lblPre�o30Consignado.Tag = "1";
            this.lblPre�o30Consignado.Text = "R$ 0,00";
            this.lblPre�o30Consignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o30Consignado.UseMnemonic = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ContextMenuStrip = this.mnuPre�o;
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(33, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 21;
            this.label15.Tag = "1";
            this.label15.Text = "30";
            // 
            // lblPre�o�VistaConsignado
            // 
            this.lblPre�o�VistaConsignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(230)))), ((int)(((byte)(193)))), ((int)(((byte)(162)))));
            this.lblPre�o�VistaConsignado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPre�o�VistaConsignado.ContextMenuStrip = this.mnuPre�o;
            this.lblPre�o�VistaConsignado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPre�o�VistaConsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPre�o�VistaConsignado.Location = new System.Drawing.Point(54, 16);
            this.lblPre�o�VistaConsignado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblPre�o�VistaConsignado.Name = "lblPre�o�VistaConsignado";
            this.lblPre�o�VistaConsignado.Size = new System.Drawing.Size(78, 16);
            this.lblPre�o�VistaConsignado.TabIndex = 9;
            this.lblPre�o�VistaConsignado.Tag = "0";
            this.lblPre�o�VistaConsignado.Text = "R$ 0,00";
            this.lblPre�o�VistaConsignado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPre�o�VistaConsignado.UseMnemonic = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ContextMenuStrip = this.mnuPre�o;
            this.label17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 8;
            this.label17.Tag = "0";
            this.label17.Text = "� vista";
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
            this.picFoto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Informa��esMercadoria_MouseDown);
            // 
            // Informa��esMercadoriaResumo
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
            this.Controls.Add(this.lblDescri��o);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.lblRefer�ncia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Informa��esMercadoriaResumo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informa��esMercadoria";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Navy;
            this.Closed += new System.EventHandler(this.Informa��esMercadoria_Closed);
            this.Shown += new System.EventHandler(this.Informa��esMercadoria_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Informa��esMercadoriaResumo_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Informa��esMercadoria_MouseDown);
            this.mnuPre�o.ResumeLayout(false);
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
        /// Ocorre ao pressionar um bot�o do mouse
        /// </summary>
        private void Informa��esMercadoria_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
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
        private void Informa��esMercadoria_Closed(object sender, System.EventArgs e)
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

                lblRefer�ncia.Text = mercadoria.Refer�ncia;
                lblFaixaGrupoPeso.Text = (mercadoria.Faixa != null ? mercadoria.Faixa + "-" : "") + mercadoria.Grupo
                    + mercadoria.PesoFormatado;

                //lblPeso.Text = mercadoria.PesoFormatado;
                // lbl�ndice.Text = Entidades.Mercadoria.Mercadoria.Formatar�ndice(mercadoria.�ndiceArredondado);
                //lblFaixaGrupo.Text = (mercadoria.Faixa != null ?  mercadoria.Faixa  : "") + "-" + mercadoria.Grupo;

                AtualizarPre�o();

                lblDescri��o.Text = mercadoria.Descri��o;
                //picFoto.Image	   = mercadoria.EnquadrarFoto(picFoto.Width, picFoto.Height);
                picFoto.MostrarAnima��o(mercadoria);
            }
        }

        /// <summary>
        /// Cota��o a ser utilizada.
        /// </summary>
        public Entidades.Cota��o Cota��o
        {
            get { return cota��o; }
            set
            {
                cota��o = value;
                AtualizarPre�o();
            }
        }

        /// <summary>
        /// Atualiza exibi��o de pre�o.
        /// </summary>
        private void AtualizarPre�o()
        {
            if (mercadoria != null)
            {
                // Atacado
                mercadoria.TabelaPre�o = Tabela.ObterTabela(3);
                cota��o = Entidades.Cota��o.ObterCota��oVigente(Moeda.ObterMoeda(Moeda.MoedaSistema.Ouro));

                lblPre�o�VistaAtacado.Text = CalcularPre�o(dias[0]);
                lblPre�o30Atacado.Text = CalcularPre�o(dias[1]);
                lblPre�o30x60Atacado.Text = CalcularPre�o(dias[2]);
                lblPre�o30x60x90Atacado.Text = CalcularPre�o(dias[3]);

                // Decora as porcentagens
                double taxa30Dias = CalcularPre�o(dias[1]) / CalcularPre�o(dias[0]);
                double taxa30x60Dias = CalcularPre�o(dias[2]) / CalcularPre�o(dias[0]);
                double taxa30x60x90Dias = CalcularPre�o(dias[3]) / CalcularPre�o(dias[0]);

                // Consignado
                mercadoria.TabelaPre�o = Tabela.ObterTabela(2);
                cota��o = Entidades.Cota��o.ObterCota��oVigente(Moeda.ObterMoeda(5));
                lblPre�o�VistaConsignado.Text = CalcularPre�o(dias[0]);
                lblPre�o30Consignado.Text = CalcularPre�o(dias[1]);
                lblPre�o30x60Consignado.Text = CalcularPre�o(dias[2]);
                lblPre�o30x60x90Consignado.Text = CalcularPre�o(dias[3]);

                // �ndice
                lbl�ndice�Vista.Text = mercadoria.�ndiceArredondado.ToString();
                lbl�ndice30.Text = Math.Round(mercadoria.�ndiceArredondado * taxa30Dias, 2).ToString();
                lbl�ndice30x60.Text = Math.Round(mercadoria.�ndiceArredondado * taxa30x60Dias, 2).ToString();
                lbl�ndice30x60x90.Text = Math.Round(mercadoria.�ndiceArredondado * taxa30x60x90Dias, 2).ToString();

                //lblCota��o.Text = "* Cota��o: " +
                //    (cota��o != null ? cota��o.Valor.ToString("C", DadosGlobais.Inst�ncia.Cultura) : "Informa��o n�o dispon�vel");
                //lblCota��o.Text = "; Tabela: " +
                //    (mercadoria.TabelaPre�o != null ? mercadoria.TabelaPre�o.Nome : "Desconhecida");
            }
        }

        /// <summary>
        /// Calcula o pre�o da mercadoria.
        /// </summary>
        /// <returns>Pre�o da mercadoria.</returns>
        private Pre�o CalcularPre�o(int dias)
        {
            Pre�o pre�o;

            if (cota��o != null)
                pre�o = mercadoria.CalcularPre�o(cota��o);
            else
                throw new Exception("Cota��o desconhecida.");

            pre�o.Dias = dias;

            return pre�o;
        }

        #region Mecanismo para escolha de pre�o (prazo)

        /// <summary>
        /// Desenha linha pontilhada abaixo do r�tulo de pre�o.
        /// </summary>
        private void AoDesenharLblPre�o(object sender, PaintEventArgs e)
        {
            for (int i = 3; i < lblR�tuloPre�o1.ClientSize.Width; i += 3)
                e.Graphics.FillRectangle(Brushes.Green, i, lblR�tuloPre�o1.ClientRectangle.Bottom - 2, 1, 1);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento � vista.
        /// </summary>
        private void mnuVista_Click(object sender, EventArgs e)
        {
            AtualizarMenuR�tulo(strPagVista);
            AtualizarMenuPre�o(0);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento a prazo de 30 dias.
        /// </summary>
        private void mnuPrazo30_Click(object sender, EventArgs e)
        {
            AtualizarMenuR�tulo(strPagPrazo + "30");
            AtualizarMenuPre�o(30);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento a prazo de 30x60 dias.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPrazo30x60_Click(object sender, EventArgs e)
        {
            AtualizarMenuR�tulo(strPagPrazo + "30x60");
            AtualizarMenuPre�o(45);
        }

        /// <summary>
        /// Ocorre ao escolher pagamento a prazo de 30x60x90 dias.
        /// </summary>
        private void mnuPrazo30x60x90_Click(object sender, EventArgs e)
        {
            AtualizarMenuR�tulo(strPagPrazo + "30x60x90");
            AtualizarMenuPre�o(60);
        }

        /// <summary>
        /// Interpreta o prazo digitado pelo usu�rio no formato
        /// "##x##x##x..." (ex.: 30x60x90x120).
        /// </summary>
        private void InterpretarPrazoPersonalizado()
        {
            int dias;

            try
            {
                dias = Pre�o.InterpretarPresta��es(mnuPrazoPersonalizadoTxt.Text);
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
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);

                MessageBox.Show(this,
                    "N�o foi poss�vel construir o prazo proposto.",
                    "Prazo personalizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            AtualizarMenuR�tulo(strPagPrazo + mnuPrazoPersonalizadoTxt.Text.ToLower());
            AtualizarMenuPre�o(Convert.ToInt32(dias));
        }

        /// <summary>
        /// Atualiza o r�tulo do pre�o conforme tag do menu.
        /// </summary>
        /// <param name="r�tulo">R�tulo a ser exibido.</param>
        private void AtualizarMenuR�tulo(string r�tulo)
        {
            Label[] lbl = new Label[] {
                lblR�tuloPre�o1, lblR�tuloPre�o2,
                lblR�tuloPre�o3, lblR�tuloPre�o4 };
            Label lblR�tulo;

            lblR�tulo = lbl[int.Parse(mnuPre�o.Tag.ToString())];
            lblR�tulo.Text = r�tulo;
        }

        /// <summary>
        /// Atualiza o pre�o conforme tag do menu.
        /// </summary>
        /// <param name="pre�o">Pre�o a ser exibido.</param>
        private void AtualizarMenuPre�o(int dias)
        {
            Label[] lbl = new Label[] {
                lblPre�o�VistaAtacado, lblPre�o30Atacado, lblPre�o30x60Atacado, lblPre�o30x60x90Atacado };
            Label lblPre�o;

            lblPre�o = lbl[int.Parse(mnuPre�o.Tag.ToString())];
            this.dias[int.Parse(mnuPre�o.Tag.ToString())] = dias;
            lblPre�o.Text = CalcularPre�o(dias); ;
        }

        /// <summary>
        /// Reposiciona a imagem para mostrar op��es de menu
        /// ao lado do r�tulo de pre�o, sempre que ele mudar de tamanho.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblR�tuloPre�o_Resize(object sender, EventArgs e)
        {
            //PictureBox[] pic = new PictureBox[] {
            //   picEscolhaPre�o1, picEscolhaPre�o2,
            //    picEscolhaPre�o3, picEscolhaPre�o4 };
            //
            //pic[int.Parse(((Label)sender).Tag.ToString())].Left = ((Label)sender).Right;

            // picEscolhaPre�o4.Left = ((Label)sender).Right;
        }

        /// <summary>
        /// Mostra menu de contexto quando o pre�o � clicado.
        /// </summary>
        private void lblR�tuloPre�o_Click(object sender, EventArgs e)
        {
            Label[] lbl = new Label[] {
                lblPre�o�VistaAtacado, lblPre�o30Atacado, lblPre�o30x60Atacado, lblPre�o30x60x90Atacado };
            Label lblPre�o;

            lblPre�o = lbl[int.Parse(((Control)sender).Tag.ToString())];

            mnuPre�o.Tag = ((Control)sender).Tag;
            mnuPre�o.Show(PointToScreen(new Point(lblPre�o.Left, lblPre�o.Bottom)));
        }

        /// <summary>
        /// Mostra menu de contexto quando o mouse passa sobre o pre�o.
        /// </summary>
        private void lblR�tuloPre�o_MouseHover(object sender, EventArgs e)
        {
            Label[] lbl = new Label[] {
                lblPre�o�VistaAtacado, lblPre�o30Atacado, lblPre�o30x60Atacado, lblPre�o30x60x90Atacado };
            Label lblPre�o;

            lblPre�o = lbl[int.Parse(((Control)sender).Tag.ToString())];

            mnuPre�o.Tag = ((Control)sender).Tag;
            mnuPre�o.Show(PointToScreen(new Point(lblPre�o.Left, lblPre�o.Bottom)));
        }

        /// <summary>
        /// Trata evento de tecla pressionada no TextBox dentro
        /// do menu de contexto de personaliza��o de pagamento a prazo.
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

        private void Informa��esMercadoria_Shown(object sender, EventArgs e)
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
                        "Foto da mercadoria " + mercadoria.Refer�ncia + " salva em " + saveFileDialog.FileName + ".",
                        "Salvar foto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception erro)
                {
                    MessageBox.Show(this,
                        "N�o foi poss�vel salvar a foto.\n\n" + erro.Message,
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

   
        private void Informa��esMercadoriaResumo_Paint(object sender, PaintEventArgs e)
        {
            this.Focus();
        }
    }
}