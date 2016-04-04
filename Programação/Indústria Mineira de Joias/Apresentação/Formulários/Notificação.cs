using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
	/// <summary>
	/// Summary description for Notifica��o.
	/// </summary>
	public class Notifica��o : System.Windows.Forms.Form
	{
        // Atributos est�ticos
        private static Queue<Notifica��o> exibi��o = new Queue<Notifica��o>(4);

        // Atributos
		private int contagem;
		private int tempoTransi��o = 2000;
		private int tempoMostrando = 5000;
		private int distanciamento = 10;

        /// <summary>
        /// Formul�rio a ser ativado ao ganhar foco.
        /// </summary>
        private Form ativarFormul�rio;

		// Gambiarras do Windows
		public const int WM_NCLBUTTONDOWN = 0xA1;
		private System.Windows.Forms.PictureBox picLogotipo;
		public const int HTCAPTION = 0x2; 
		[DllImport("User32.dll")] 
		public static extern bool ReleaseCapture(); 
		[DllImport("User32.dll")] 
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Designer
		private System.Windows.Forms.Timer timer;
		protected Apresenta��o.Formul�rios.Quadro quadro;
		private System.ComponentModel.IContainer components;

		public Notifica��o()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.SetStyle(ControlStyles.Selectable, false);

            Reposicionar();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Notifica��o));
			this.quadro = new Apresenta��o.Formul�rios.Quadro();
			this.picLogotipo = new System.Windows.Forms.PictureBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.quadro.SuspendLayout();
			this.SuspendLayout();
			// 
			// quadro
			// 
			this.quadro.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
			this.quadro.BackColor = System.Drawing.Color.Linen;
			this.quadro.bInfDirArredondada = true;
			this.quadro.bInfEsqArredondada = true;
			this.quadro.bSupDirArredondada = true;
			this.quadro.bSupEsqArredondada = true;
			this.quadro.Controls.Add(this.picLogotipo);
			this.quadro.Cor = System.Drawing.Color.Black;
			this.quadro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.quadro.FundoT�tulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadro.LetraT�tulo = System.Drawing.Color.White;
			this.quadro.Location = new System.Drawing.Point(0, 0);
			this.quadro.MostrarBot�oMinMax = false;
			this.quadro.Name = "quadro";
			this.quadro.Size = new System.Drawing.Size(288, 120);
			this.quadro.TabIndex = 0;
			this.quadro.Tamanho = 30;
			this.quadro.T�tulo = "Notifica��o";
			// 
			// picLogotipo
			// 
			this.picLogotipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.picLogotipo.BackColor = System.Drawing.Color.Transparent;
			this.picLogotipo.Image = ((System.Drawing.Image)(resources.GetObject("picLogotipo.Image")));
			this.picLogotipo.Location = new System.Drawing.Point(256, 88);
			this.picLogotipo.Name = "picLogotipo";
			this.picLogotipo.Size = new System.Drawing.Size(24, 24);
			this.picLogotipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogotipo.TabIndex = 1;
			this.picLogotipo.TabStop = false;
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// Notifica��o
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Crimson;
			this.ClientSize = new System.Drawing.Size(288, 120);
			this.ControlBox = false;
			this.Controls.Add(this.quadro);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Notifica��o";
			this.Opacity = 0;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Crimson;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Notifica��o_MouseDown);
			this.quadro.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre na batida do timer
		/// </summary>
		private void timer_Tick(object sender, System.EventArgs e)
		{
            if (Enabled)
            {
                if (contagem <= tempoTransi��o / timer.Interval)
                {
                    this.Opacity = contagem / ((float)tempoTransi��o / timer.Interval);
                    this.Update();
                }
                else if (contagem >= (tempoTransi��o + tempoMostrando) / timer.Interval
                    && contagem < (2 * tempoTransi��o + tempoMostrando) / timer.Interval)
                {
                    this.Opacity = 1d - (contagem - (tempoTransi��o + tempoMostrando) / timer.Interval) / ((float)tempoTransi��o / timer.Interval);
                    this.Update();
                }
                else if (contagem >= (2 * tempoTransi��o + tempoMostrando) / timer.Interval)
                {
                    timer.Stop();
                    Close();

#if DEBUG
                    Console.WriteLine("Fim de timer da notifica��o {0}", ToString());
#endif
                }

                contagem++;
            }
		}

		/// <summary>
		/// Tempo de transi��o em milissegundos
		/// </summary>
		[Description("Tempo de transi��o em milissegundos utilizado para aparecer e desaparecer a janela"),
		 Category("Dura��o")]
		public int TempoTransi��o
		{
			get { return tempoTransi��o; }
			set { tempoTransi��o = value; }
		}

		/// <summary>
		/// Tempo de dura��o da notifica��o
		/// </summary>
		[Description("Tempo em que a janela permanece vis�vel."),
		 Category("Dura��o")]
		public int TempoMostrando
		{
			get { return tempoMostrando; }
			set { tempoMostrando = value; }
		}

		public string T�tulo
		{
			get
			{
				return this.quadro.T�tulo;
			}
			set
			{
				this.quadro.T�tulo = value;
			}
		}

		public Image ImagemFundo
		{
			get { return quadro.BackgroundImage; }
			set { quadro.BackgroundImage = value; }
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged (e);

			if (Visible && !DesignMode)
			{
				contagem = 0;

                ReativarFormul�rio();

                IniciarNotifica��o(this);
			}
		}

        /// <summary>
        /// Ocorre ao alterar o tamanho da janela.
        /// </summary>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);

			if (!DesignMode)
                Reposicionar();
		}

        /// <summary>
        /// Ocorre ao fechar a janela.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (!DesignMode)
                FinalizarNotifica��o(this);
        }

        /// <summary>
        /// Reposiciona janela de notifica��o.
        /// </summary>
        private void Reposicionar()
        {
            if (!DesignMode)
            {
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - Width - distanciamento;
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - Height - distanciamento;
            }

            this.picLogotipo.Top = ClientSize.Height - picLogotipo.Height -
                (ClientSize.Width - picLogotipo.Width - picLogotipo.Left);
        }

        /// <summary>
        /// Ocorre ao pressionar o mouse na janela.
        /// </summary>
		private void Notifica��o_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ReleaseCapture(); 
 
			SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); 
		}

        private delegate void ReativarFormul�rioCallback();

        /// <summary>
        /// Reativa formul�rio que possuia foco anteriormente.
        /// </summary>
        private void ReativarFormul�rio()
        {
            try
            {
                if (ativarFormul�rio != null && !ativarFormul�rio.Disposing && ativarFormul�rio.Visible)
                {
                    if (ativarFormul�rio.InvokeRequired)
                        ativarFormul�rio.BeginInvoke(new ReativarFormul�rioCallback(ReativarFormul�rio));
                    else
                        ativarFormul�rio.Activate();
                }
                else
                {
                    ativarFormul�rio = null;

#if DEBUG
                    Console.WriteLine("Cancelada reativa��o de formul�rio.");
#endif
                }
            }
            catch { }
        }

        /// <summary>
        /// Inicia exibi��o de notifica��o, se nenhuma outra
        /// estiver em exibi��o no momento.
        /// </summary>
        private static void IniciarNotifica��o(Notifica��o janela)
        {
#if DEBUG
            Console.WriteLine("Iniciando notifica��o {0}", janela.ToString());
#endif

            lock (typeof(Notifica��o))
            {
                exibi��o.Enqueue(janela);

                janela.Enabled = (exibi��o.Count == 1);
                janela.timer.Enabled = true;
                janela.timer.Start();
            }
        }

        /// <summary>
        /// Finaliza notifica��o.
        /// </summary>
        /// <param name="janela">Janela finalizada.</param>
        private static void FinalizarNotifica��o(Notifica��o janela)
        {
#if DEBUG
            Console.WriteLine("Finalizando notifica��o {0}", janela.ToString());
#endif

            lock (typeof(Notifica��o))
            {
                bool ok = false;

                if (exibi��o.Count > 0)
                {
                    exibi��o.Dequeue();

                    while (exibi��o.Count > 0 && !ok)
                    {
                        try
                        {
                            exibi��o.Peek().Ativar();
                            ok = true;
#if DEBUG
                            Console.WriteLine("Ativando notifica��o {0}", exibi��o.Peek().ToString());
#endif
                        }
                        catch
                        {
                            exibi��o.Dequeue();
                            ok = false;
#if DEBUG
                            Console.WriteLine("Problemas com a notifica��o {0}", janela.ToString());
#endif
                        }
                    }
                }
            }
        }

        private delegate void AtivarCallback();

        /// <summary>
        /// Ativa a notifica��o.
        /// </summary>
        private void Ativar()
        {
            if (InvokeRequired)
            {
                AtivarCallback m�todo = new AtivarCallback(Ativar);
                BeginInvoke(m�todo);
            }
            else
                Enabled = true;
        }

        /// <summary>
        /// Mostra janela em thread separada.
        /// </summary>
        /// <param name="janela">Tipo da janela de notifica��o a ser exibida.</param>
        /// <param name="par�metros">Par�metros da construtora.</param>
        public static void Mostrar(Type janela, params object [] par�metros)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadMostrar));
            thread.Name = "Notifica��o - mostrar janela de notifica��o";
            thread.IsBackground = true;
            thread.Start(new object[] { janela, par�metros });
        }

        public static void Mostrar(string t�tulo, string descri��o)
        {
            Mostrar(typeof(Notifica��oSimples), t�tulo, descri��o);
        }

        /// <summary>
        /// Thread para exibi��o da janela.
        /// </summary>
        private static void ThreadMostrar(object dados)
        {
            try
            {
                Type            tipo;
                Type []         tipoPar�metros;
                object []       par�metros, vetor;
                ConstructorInfo construtora;
                Notifica��o     dlg;

                vetor          = (object[])dados;
                tipo           = (Type)vetor[0];
                par�metros     = (object[])vetor[1];
                tipoPar�metros = new Type[par�metros.Length];

                for (int i = 0; i < par�metros.Length; i++)
                    tipoPar�metros[i] = par�metros[i].GetType();

                construtora          = tipo.GetConstructor(tipoPar�metros);
                dlg                  = (Notifica��o)construtora.Invoke(par�metros);

                try
                {
                    dlg.ativarFormul�rio = Form.ActiveForm;
                }
                catch { }

                dlg.ShowDialog();
                dlg.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erro ao mostrar janela de notifica��o");
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
	}
}
