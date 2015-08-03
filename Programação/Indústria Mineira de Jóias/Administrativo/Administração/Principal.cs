using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Observador;
using Neg�cio.Observador;

namespace Administra��o
{
	public class Principal : Apresenta��o.Formul�rios.BaseFormul�rio
	{
		private Bases.Relat�rios		baseRelat�rios;
		
		private Apresenta��o.Formul�rios.Bot�o cmdFuncion�rios;
		private Apresenta��o.Formul�rios.Bot�o cmdClientes;
		private Apresenta��o.Formul�rios.Bot�o cmdSetores;

		// Observa��o
//		private EventoObserva��o		observa��oFuncion�rio;

		// Designer
		private System.ComponentModel.IContainer components = null;

		public Principal()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			IniciarBases();
			SubstituirBase(baseRelat�rios, this);  

			// Preparar observa��o
//			observa��oFuncion�rio = new Observador.EventoObserva��o(Observa��oFuncion�rio);

//			Controle.Observa��oFuncion�rio += observa��oFuncion�rio;
		}

		private void IniciarBases()
		{
			baseRelat�rios = new Administra��o.Bases.Relat�rios();
			//NovaBase(baseRelat�rios);
			cmdClientes.Base = baseRelat�rios;

			cmdFuncion�rios.Base = new Administra��o.Bases.Funcion�rios();

			cmdSetores.Base = new Administra��o.Bases.Setores();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			
			base.Dispose( disposing );

//			Controle.Observa��oFuncion�rio -= observa��oFuncion�rio;
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Principal));
			this.cmdFuncion�rios = new Apresenta��o.Formul�rios.Bot�o();
			this.cmdClientes = new Apresenta��o.Formul�rios.Bot�o();
			this.cmdSetores = new Apresenta��o.Formul�rios.Bot�o();
			this.topo.SuspendLayout();
			this.barraBot�es.SuspendLayout();
			this.SuspendLayout();
			// 
			// topo
			// 
			this.topo.Name = "topo";
			this.topo.Size = new System.Drawing.Size(632, 93);
			// 
			// baseInferior
			// 
			this.baseInferior.Name = "baseInferior";
			this.baseInferior.Size = new System.Drawing.Size(632, 353);
			// 
			// barraBot�es
			// 
			this.barraBot�es.Bot�es = new Apresenta��o.Formul�rios.Bot�o[] {
																			   this.cmdFuncion�rios,
																			   this.cmdClientes,
																			   this.cmdSetores};
			this.barraBot�es.Controls.Add(this.cmdFuncion�rios);
			this.barraBot�es.Controls.Add(this.cmdClientes);
			this.barraBot�es.Controls.Add(this.cmdSetores);
			this.barraBot�es.Name = "barraBot�es";
			this.barraBot�es.Size = new System.Drawing.Size(408, 75);
			// 
			// cmdFuncion�rios
			// 
			this.cmdFuncion�rios.BackColor = System.Drawing.Color.Transparent;
			this.cmdFuncion�rios.Imagem = ((System.Drawing.Image)(resources.GetObject("cmdFuncion�rios.Imagem")));
			this.cmdFuncion�rios.Location = new System.Drawing.Point(0, 0);
			this.cmdFuncion�rios.Name = "cmdFuncion�rios";
			this.cmdFuncion�rios.Size = new System.Drawing.Size(72, 73);
			this.cmdFuncion�rios.TabIndex = 0;
			this.cmdFuncion�rios.Texto = "Funcion�rios";
			// 
			// cmdClientes
			// 
			this.cmdClientes.BackColor = System.Drawing.Color.Transparent;
			this.cmdClientes.Imagem = ((System.Drawing.Image)(resources.GetObject("cmdClientes.Imagem")));
			this.cmdClientes.Location = new System.Drawing.Point(87, 0);
			this.cmdClientes.Name = "cmdClientes";
			this.cmdClientes.Size = new System.Drawing.Size(57, 73);
			this.cmdClientes.TabIndex = 1;
			this.cmdClientes.Texto = "Clientes";
			// 
			// cmdSetores
			// 
			this.cmdSetores.BackColor = System.Drawing.Color.Transparent;
			this.cmdSetores.Imagem = ((System.Drawing.Image)(resources.GetObject("cmdSetores.Imagem")));
			this.cmdSetores.Location = new System.Drawing.Point(174, 0);
			this.cmdSetores.Name = "cmdSetores";
			this.cmdSetores.Size = new System.Drawing.Size(57, 73);
			this.cmdSetores.TabIndex = 2;
			this.cmdSetores.Texto = "Setores";
			// 
			// Principal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Name = "Principal";
			this.topo.ResumeLayout(false);
			this.barraBot�es.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		static void CriarCanal(string nome, int porta)
		{
			SinkProviderData provider = new SinkProviderData("imjoias");

			IDictionary props = new Hashtable();

			props["name"] = nome;
			props["port"] = porta.ToString();

			IDictionary propsCliente = new Hashtable();

			BinaryClientFormatterSinkProvider cliente = new BinaryClientFormatterSinkProvider(propsCliente, provider.Children);

			IDictionary propsServidor = new Hashtable();
			propsServidor["typeFilterLevel"] = "Full";

			BinaryServerFormatterSinkProvider servidor = new BinaryServerFormatterSinkProvider(propsServidor, provider.Children);

			TcpChannel canal = new TcpChannel(props, cliente, servidor);

			ChannelServices.RegisterChannel(canal);
		}

		[STAThread]
		static void Main()
		{
			Apresenta��o.Formul�rios.Splash splash;

			splash = new Apresenta��o.Formul�rios.Splash();
			splash.Show();
			splash.Refresh();

			CriarCanal("local", 9001);

			splash.Refresh();

			Principal principal = new Principal();

			Application.EnableVisualStyles();

			splash.Close();
			splash.Dispose();

			try
			{		
				Application.Run(principal);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		#region Controle

		private static Neg�cio.Controle.IAdministra��o controle = null;

		public static Neg�cio.Controle.IAdministra��o Controle
		{
			get
			{
				if (controle == null)
				{
					string caminho;

					try
					{
						string protocolo;
						string host;
						string porta;

						Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software");
						reg = reg.OpenSubKey("Ind�stria Mineira de J�ias");
						reg = reg.OpenSubKey("Controle - Administrativo");
						
						protocolo = (string) reg.GetValue("protocolo");
						host = (string) reg.GetValue("host");
						porta = (string) reg.GetValue("porta");

						caminho =
							(protocolo == null ? "tcp" : protocolo) +
							"://" +
							(host == null ? "imjoias" : host) +
							":" +
							(porta == null ? "8100" : porta) +
							"/Administra��o";
					}
					catch
					{
						caminho = caminho = "tcp://imjoias:8100/Administra��o";
					}

					controle = (Neg�cio.Controle.IAdministra��o) Activator.GetObject(typeof(Neg�cio.Controle.IAdministra��o), caminho);
				
					// TODO: Pedir senha
					Neg�cio.Controle.InterfaceControleCriptografado.Conectar(controle, "imjoias", "***REMOVED***");
				}

				return controle;
			}
		}

		#endregion

		#region Observa��o
/*
		/// <summary>
		/// Observa��o de funcion�rios
		/// </summary>
		public void Observa��oFuncion�rio(ISujeito sujeito, int a��o, object dados)
		{
			switch ((A��oFuncion�rio) a��o)
			{
				case A��oFuncion�rio.Contratado:
			}
		}
*/
		#endregion
	}
}

