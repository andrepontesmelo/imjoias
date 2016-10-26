using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
	/// <summary>
	/// Summary description for Notificação.
	/// </summary>
	public class Notificação : System.Windows.Forms.Form
	{
        // Atributos estáticos
        private static Queue<Notificação> exibição = new Queue<Notificação>(4);

        // Atributos
		private int contagem;
		private int tempoTransição = 2000;
		private int tempoMostrando = 5000;
		private int distanciamento = 10;

        /// <summary>
        /// Formulário a ser ativado ao ganhar foco.
        /// </summary>
        private Form ativarFormulário;

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
		protected Apresentação.Formulários.Quadro quadro;
		private System.ComponentModel.IContainer components;

		public Notificação()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Notificação));
			this.quadro = new Apresentação.Formulários.Quadro();
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
			this.quadro.FundoTítulo = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(165)), ((System.Byte)(159)), ((System.Byte)(97)));
			this.quadro.LetraTítulo = System.Drawing.Color.White;
			this.quadro.Location = new System.Drawing.Point(0, 0);
			this.quadro.MostrarBotãoMinMax = false;
			this.quadro.Name = "quadro";
			this.quadro.Size = new System.Drawing.Size(288, 120);
			this.quadro.TabIndex = 0;
			this.quadro.Tamanho = 30;
			this.quadro.Título = "Notificação";
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
			// Notificação
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Crimson;
			this.ClientSize = new System.Drawing.Size(288, 120);
			this.ControlBox = false;
			this.Controls.Add(this.quadro);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Notificação";
			this.Opacity = 0;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Crimson;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Notificação_MouseDown);
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
                if (contagem <= tempoTransição / timer.Interval)
                {
                    this.Opacity = contagem / ((float)tempoTransição / timer.Interval);
                    this.Update();
                }
                else if (contagem >= (tempoTransição + tempoMostrando) / timer.Interval
                    && contagem < (2 * tempoTransição + tempoMostrando) / timer.Interval)
                {
                    this.Opacity = 1d - (contagem - (tempoTransição + tempoMostrando) / timer.Interval) / ((float)tempoTransição / timer.Interval);
                    this.Update();
                }
                else if (contagem >= (2 * tempoTransição + tempoMostrando) / timer.Interval)
                {
                    timer.Stop();
                    Close();

#if DEBUG
                    Console.WriteLine("Fim de timer da notificação {0}", ToString());
#endif
                }

                contagem++;
            }
		}

		/// <summary>
		/// Tempo de transição em milissegundos
		/// </summary>
		[Description("Tempo de transição em milissegundos utilizado para aparecer e desaparecer a janela"),
		 Category("Duração")]
		public int TempoTransição
		{
			get { return tempoTransição; }
			set { tempoTransição = value; }
		}

		/// <summary>
		/// Tempo de duração da notificação
		/// </summary>
		[Description("Tempo em que a janela permanece visível."),
		 Category("Duração")]
		public int TempoMostrando
		{
			get { return tempoMostrando; }
			set { tempoMostrando = value; }
		}

		public string Título
		{
			get
			{
				return this.quadro.Título;
			}
			set
			{
				this.quadro.Título = value;
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

                ReativarFormulário();

                IniciarNotificação(this);
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
                FinalizarNotificação(this);
        }

        /// <summary>
        /// Reposiciona janela de notificação.
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
		private void Notificação_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ReleaseCapture(); 
 
			SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); 
		}

        private delegate void ReativarFormulárioCallback();

        /// <summary>
        /// Reativa formulário que possuia foco anteriormente.
        /// </summary>
        private void ReativarFormulário()
        {
            try
            {
                if (ativarFormulário != null && !ativarFormulário.Disposing && ativarFormulário.Visible)
                {
                    if (ativarFormulário.InvokeRequired)
                        ativarFormulário.BeginInvoke(new ReativarFormulárioCallback(ReativarFormulário));
                    else
                        ativarFormulário.Activate();
                }
                else
                {
                    ativarFormulário = null;

#if DEBUG
                    Console.WriteLine("Cancelada reativação de formulário.");
#endif
                }
            }
            catch { }
        }

        /// <summary>
        /// Inicia exibição de notificação, se nenhuma outra
        /// estiver em exibição no momento.
        /// </summary>
        private static void IniciarNotificação(Notificação janela)
        {
#if DEBUG
            Console.WriteLine("Iniciando notificação {0}", janela.ToString());
#endif

            lock (typeof(Notificação))
            {
                exibição.Enqueue(janela);

                janela.Enabled = (exibição.Count == 1);
                janela.timer.Enabled = true;
                janela.timer.Start();
            }
        }

        /// <summary>
        /// Finaliza notificação.
        /// </summary>
        /// <param name="janela">Janela finalizada.</param>
        private static void FinalizarNotificação(Notificação janela)
        {
#if DEBUG
            Console.WriteLine("Finalizando notificação {0}", janela.ToString());
#endif

            lock (typeof(Notificação))
            {
                bool ok = false;

                if (exibição.Count > 0)
                {
                    exibição.Dequeue();

                    while (exibição.Count > 0 && !ok)
                    {
                        try
                        {
                            exibição.Peek().Ativar();
                            ok = true;
#if DEBUG
                            Console.WriteLine("Ativando notificação {0}", exibição.Peek().ToString());
#endif
                        }
                        catch
                        {
                            exibição.Dequeue();
                            ok = false;
#if DEBUG
                            Console.WriteLine("Problemas com a notificação {0}", janela.ToString());
#endif
                        }
                    }
                }
            }
        }

        private delegate void AtivarCallback();

        /// <summary>
        /// Ativa a notificação.
        /// </summary>
        private void Ativar()
        {
            if (InvokeRequired)
            {
                AtivarCallback método = new AtivarCallback(Ativar);
                BeginInvoke(método);
            }
            else
                Enabled = true;
        }

        /// <summary>
        /// Mostra janela em thread separada.
        /// </summary>
        /// <param name="janela">Tipo da janela de notificação a ser exibida.</param>
        /// <param name="parâmetros">Parâmetros da construtora.</param>
        public static void Mostrar(Type janela, params object [] parâmetros)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadMostrar));
            thread.Name = "Notificação - mostrar janela de notificação";
            thread.IsBackground = true;
            thread.Start(new object[] { janela, parâmetros });
        }

        public static void Mostrar(string título, string descrição)
        {
            Mostrar(typeof(NotificaçãoSimples), título, descrição);
        }

        /// <summary>
        /// Thread para exibição da janela.
        /// </summary>
        private static void ThreadMostrar(object dados)
        {
            try
            {
                Type            tipo;
                Type []         tipoParâmetros;
                object []       parâmetros, vetor;
                ConstructorInfo construtora;
                Notificação     dlg;

                vetor          = (object[])dados;
                tipo           = (Type)vetor[0];
                parâmetros     = (object[])vetor[1];
                tipoParâmetros = new Type[parâmetros.Length];

                for (int i = 0; i < parâmetros.Length; i++)
                    tipoParâmetros[i] = parâmetros[i].GetType();

                construtora          = tipo.GetConstructor(tipoParâmetros);
                dlg                  = (Notificação)construtora.Invoke(parâmetros);

                try
                {
                    dlg.ativarFormulário = Form.ActiveForm;
                }
                catch { }

                dlg.ShowDialog();
                dlg.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erro ao mostrar janela de notificação");
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
