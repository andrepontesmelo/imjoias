using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Entidades.Privil�gio;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Summary description for Op��o.
	/// </summary>
	[DefaultEvent("Click"), DefaultProperty("Descri��o")]
	public class Op��o : System.Windows.Forms.UserControl, IRequerPrivil�gio
	{
        private Permiss�o privil�gio = Permiss�o.Nenhuma;
        private bool liberarRecurso = false;
        
        private System.Windows.Forms.PictureBox picOp��o;
		private System.Windows.Forms.LinkLabel lblDescri��o;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Op��o()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Op��o));
            this.picOp��o = new System.Windows.Forms.PictureBox();
            this.lblDescri��o = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picOp��o)).BeginInit();
            this.SuspendLayout();
            // 
            // picOp��o
            // 
            this.picOp��o.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOp��o.Image = ((System.Drawing.Image)(resources.GetObject("picOp��o.Image")));
            this.picOp��o.Location = new System.Drawing.Point(0, 0);
            this.picOp��o.Name = "picOp��o";
            this.picOp��o.Size = new System.Drawing.Size(16, 16);
            this.picOp��o.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOp��o.TabIndex = 0;
            this.picOp��o.TabStop = false;
            this.picOp��o.Click += new System.EventHandler(this.picOp��o_Click);
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescri��o.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescri��o.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(140)))), ((int)(((byte)(127)))));
            this.lblDescri��o.Location = new System.Drawing.Point(18, 0);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Size = new System.Drawing.Size(134, 24);
            this.lblDescri��o.TabIndex = 1;
            this.lblDescri��o.TabStop = true;
            this.lblDescri��o.Text = "Descri��o";
            this.lblDescri��o.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDescri��o_LinkClicked);
            // 
            // Op��o
            // 
            this.Controls.Add(this.lblDescri��o);
            this.Controls.Add(this.picOp��o);
            this.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MaximumSize = new System.Drawing.Size(150, 100);
            this.MinimumSize = new System.Drawing.Size(150, 16);
            this.Name = "Op��o";
            this.Size = new System.Drawing.Size(150, 24);
            this.Load += new System.EventHandler(this.Op��o_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOp��o)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void lblDescri��o_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			this.OnClick(null);
		}

		private void picOp��o_Click(object sender, System.EventArgs e)
		{
			this.OnClick(e);
		}

        protected override void OnClick(EventArgs e)
        {
            if (!DesignMode && liberarRecurso)
                if (!Login.LiberarRecurso(
                    ParentForm,
                    privil�gio,
                    lblDescri��o.Text,
                    ""))
                    return;

            base.OnClick(e);
        }

		public string Descri��o
		{
			get { return lblDescri��o.Text; }
			set { lblDescri��o.Text = value; }
		}

		public System.Drawing.Image Imagem
		{
			get { return picOp��o.Image; }
			set { picOp��o.Image = value; }
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged (e);

			lblDescri��o.Enabled = this.Enabled;
			picOp��o.Enabled = this.Enabled;
		}

        private void Op��o_Load(object sender, EventArgs e)
        {
            if (!DesignMode && !Permiss�oFuncion�rio.ValidarPermiss�o(privil�gio))
            {
                if (!liberarRecurso)
                {
                    Enabled = false;
                    Cursor = Cursors.No;
                    lblDescri��o.Cursor = Cursors.No;
                    picOp��o.Cursor = Cursors.No;
                }
                else
                    using (Graphics g = Graphics.FromImage(picOp��o.Image))
                    {
                        g.DrawImage(
                            Properties.Resources.cadeado_aberto__pequeno_,
                            picOp��o.Width / 2f, picOp��o.Height / 2f,
                            picOp��o.Width / 2f, picOp��o.Height / 2f);
                    }
            }
        }

        /// <summary>
        /// Privil�gios necess�rios para exibi��o do quadro.
        /// </summary>
        [DefaultValue(Permiss�o.Nenhuma), Description("Privil�gios necess�rios para exibi��o do quadro."), Browsable(true)]
        public Permiss�o Privil�gio
        {
            get { return privil�gio; }
            set { this.privil�gio = value; }
        }

        [DefaultValue(false)]
        public bool PermitirLibera��oRecurso
        {
            get { return liberarRecurso; }
            set { liberarRecurso = value; }
        }
	}
}
