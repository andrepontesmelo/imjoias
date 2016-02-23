using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Summary description for JanelaExplicativa.
	/// </summary>
	[Serializable]
	public class JanelaExplicativa : System.Windows.Forms.Form
	{
        private bool isGlassSupported = true;

        protected System.Windows.Forms.Label lblT�tulo;
		protected System.Windows.Forms.Label lblDescri��o;
		protected System.Windows.Forms.PictureBox pic�cone;
		private System.Windows.Forms.Panel topo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JanelaExplicativa()
		{
			InitializeComponent();

            isGlassSupported = Environment.OSVersion.Version.Major >= 6;
		}

        public JanelaExplicativa(bool efeitoVista)
        {
            InitializeComponent();
      
            isGlassSupported = efeitoVista && Environment.OSVersion.Version.Major >= 6;
        }

        public new bool ShowInTaskbar
        {
            get { return base.ShowInTaskbar; }
            set
            {
                     /* APENAS FINGE QUE MUDA! N�o mudar!
                     * D� pau com o efeito de vidro (pq? sei l�!)
                     * -- J�lio, 23/11/2006
                     */
                    base.ShowInTaskbar = value;
             }
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.topo = new System.Windows.Forms.Panel();
            this.lblT�tulo = new System.Windows.Forms.Label();
            this.lblDescri��o = new System.Windows.Forms.Label();
            this.pic�cone = new System.Windows.Forms.PictureBox();
            this.topo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // topo
            // 
            this.topo.BackColor = System.Drawing.SystemColors.Window;
            this.topo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topo.Controls.Add(this.lblT�tulo);
            this.topo.Controls.Add(this.lblDescri��o);
            this.topo.Controls.Add(this.pic�cone);
            this.topo.Dock = System.Windows.Forms.DockStyle.Top;
            this.topo.Location = new System.Drawing.Point(0, 0);
            this.topo.Name = "topo";
            this.topo.Size = new System.Drawing.Size(392, 88);
            this.topo.TabIndex = 2;
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT�tulo.Location = new System.Drawing.Point(72, 16);
            this.lblT�tulo.Name = "lblT�tulo";
            this.lblT�tulo.Size = new System.Drawing.Size(313, 20);
            this.lblT�tulo.TabIndex = 4;
            this.lblT�tulo.Text = "T�tulo";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescri��o.Location = new System.Drawing.Point(72, 40);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Size = new System.Drawing.Size(304, 48);
            this.lblDescri��o.TabIndex = 3;
            this.lblDescri��o.Text = "Descri��o";
            // 
            // pic�cone
            // 
            this.pic�cone.Location = new System.Drawing.Point(0, 0);
            this.pic�cone.Name = "pic�cone";
            this.pic�cone.Size = new System.Drawing.Size(72, 88);
            this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic�cone.TabIndex = 2;
            this.pic�cone.TabStop = false;
            // 
            // JanelaExplicativa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(392, 198);
            this.Controls.Add(this.topo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JanelaExplicativa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JanelaExplicativa";
            this.Resize += new System.EventHandler(this.JanelaExplicativa_Resize);
            this.topo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DefinirBorda();
        }

		private void JanelaExplicativa_Resize(object sender, System.EventArgs e)
		{
			lblDescri��o.Width = ClientSize.Width - lblDescri��o.Left - 16;

            if (isGlassSupported)
                Invalidate(false);
		}

        private void DefinirBorda()
        {
            // Requer pelo menos Windows Vista.
            if (Environment.OSVersion.Version.Major >= 6 && isGlassSupported && !DesignMode)
            {
                VistaAPI.DwmIsCompositionEnabled(ref isGlassSupported);

                if (isGlassSupported)
                {
                    VistaAPI.Margins marg;

                    marg.Top = topo.Height;
                    marg.Left = 0;
                    marg.Right = 0;
                    marg.Bottom = 0;
                    
                    VistaAPI.DwmExtendFrameIntoClientArea(this.Handle, ref marg);

                    topo.Visible = false;
                    lblDescri��o.Visible = false;
                    lblT�tulo.Visible = false;
                    topo.Controls.Remove(pic�cone);
                    Controls.Add(pic�cone);
                    pic�cone.BackColor = Color.Black;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (isGlassSupported)
            {
                e.Graphics.FillRectangle(Brushes.Black,
                    0, 0, ClientSize.Width, topo.Height);

                VistaAPI.DrawGlowingText(e.Graphics,
                    lblT�tulo.Text,
                    lblT�tulo.Font,
                    new Rectangle(lblT�tulo.Location, lblT�tulo.Size),
                    WindowState == FormWindowState.Normal ? Color.Black : Color.White, TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);

                VistaAPI.DrawGlowingText(e.Graphics,
                    lblDescri��o.Text,
                    lblDescri��o.Font,
                    new Rectangle(lblDescri��o.Location, lblDescri��o.Size),
                    WindowState == FormWindowState.Normal ? Color.Black : Color.White, TextFormatFlags.NoPrefix | TextFormatFlags.WordBreak);
            }
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        // make windows do the work for us by lieing to it about where the user clicked
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            if (m.Msg == 0x84 // if this is a click
                && m.Result.ToInt32() == 1 // ...and it is on the client
                && this.IsOnGlass(m.LParam.ToInt32())) // ...and specifically in the glass area
            {
                m.Result = new IntPtr(2); // lie and say they clicked on the title bar
            }
        }
        
        private bool IsOnGlass(int lParam)
        {
            // get screen coordinates
            int x = (lParam << 16) >> 16; // lo order word
            int y =  lParam        >> 16; // hi order word
            // translate screen coordinates to client area
            Point p = this.PointToClient(new Point(x, y));
            // work out if point clicked is on glass
            if (p.Y <= topo.Height)
                return true;
            return false;
        }
	}
}
