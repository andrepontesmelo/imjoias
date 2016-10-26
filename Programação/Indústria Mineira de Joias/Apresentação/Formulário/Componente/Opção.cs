using Entidades.Privilégio;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    [DefaultEvent("Click"), DefaultProperty("Descrição")]
	public class Opção : UserControl, IRequerPrivilégio
	{
        private Permissão privilégio = Permissão.Nenhuma;
        private bool liberarRecurso = false;
        
        private PictureBox picOpção;
		private LinkLabel lblDescrição;

		private Container components = null;

		public Opção()
		{
			InitializeComponent();

			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor = Color.Transparent;
		}

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opção));
            this.picOpção = new System.Windows.Forms.PictureBox();
            this.lblDescrição = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picOpção)).BeginInit();
            this.SuspendLayout();
            // 
            // picOpção
            // 
            this.picOpção.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOpção.Image = ((System.Drawing.Image)(resources.GetObject("picOpção.Image")));
            this.picOpção.Location = new System.Drawing.Point(0, 0);
            this.picOpção.Name = "picOpção";
            this.picOpção.Size = new System.Drawing.Size(16, 16);
            this.picOpção.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOpção.TabIndex = 0;
            this.picOpção.TabStop = false;
            this.picOpção.Click += new System.EventHandler(this.picOpção_Click);
            // 
            // lblDescrição
            // 
            this.lblDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrição.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescrição.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(140)))), ((int)(((byte)(127)))));
            this.lblDescrição.Location = new System.Drawing.Point(18, 0);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(134, 24);
            this.lblDescrição.TabIndex = 1;
            this.lblDescrição.TabStop = true;
            this.lblDescrição.Text = "Descrição";
            this.lblDescrição.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDescrição_LinkClicked);
            // 
            // Opção
            // 
            this.Controls.Add(this.lblDescrição);
            this.Controls.Add(this.picOpção);
            this.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MaximumSize = new System.Drawing.Size(150, 100);
            this.MinimumSize = new System.Drawing.Size(150, 16);
            this.Name = "Opção";
            this.Size = new System.Drawing.Size(150, 24);
            this.Load += new System.EventHandler(this.Opção_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOpção)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void lblDescrição_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OnClick(null);
		}

		private void picOpção_Click(object sender, System.EventArgs e)
		{
			OnClick(e);
		}

        protected override void OnClick(EventArgs e)
        {
            if (!DesignMode && liberarRecurso)
                if (!Login.LiberarRecurso(
                    ParentForm,
                    privilégio,
                    lblDescrição.Text,
                    ""))
                    return;

            base.OnClick(e);
        }

		public string Descrição
		{
			get { return lblDescrição.Text; }
			set { lblDescrição.Text = value; }
		}

		public Image Imagem
		{
			get { return picOpção.Image; }
			set { picOpção.Image = value; }
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged (e);

			lblDescrição.Enabled = Enabled;
			picOpção.Enabled = Enabled;
		}

        private void Opção_Load(object sender, EventArgs e)
        {
            if (!DesignMode && !PermissãoFuncionário.ValidarPermissão(privilégio))
            {
                if (!liberarRecurso)
                {
                    Enabled = false;
                    Cursor = Cursors.No;
                    lblDescrição.Cursor = Cursors.No;
                    picOpção.Cursor = Cursors.No;
                }
                else
                    using (Graphics g = Graphics.FromImage(picOpção.Image))
                    {
                        g.DrawImage(
                            global::Apresentação.Resource.cadeado_aberto__pequeno_,
                            picOpção.Width / 2f, picOpção.Height / 2f,
                            picOpção.Width / 2f, picOpção.Height / 2f);
                    }
            }
        }

        [DefaultValue(Permissão.Nenhuma), Description("Privilégios necessários para exibição do quadro."), Browsable(true)]
        public Permissão Privilégio
        {
            get { return privilégio; }
            set { privilégio = value; }
        }

        [DefaultValue(false)]
        public bool PermitirLiberaçãoRecurso
        {
            get { return liberarRecurso; }
            set { liberarRecurso = value; }
        }
	}
}
