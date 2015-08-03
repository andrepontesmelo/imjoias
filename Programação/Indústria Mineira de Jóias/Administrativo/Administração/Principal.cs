using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Observador;
using Negócio.Observador;

namespace Administração
{
	public class Principal : Apresentação.Formulários.BaseFormulário
	{
		private Bases.Relatórios		baseRelatórios;
		
		private Apresentação.Formulários.Botão cmdFuncionários;
		private Apresentação.Formulários.Botão cmdClientes;
		private Apresentação.Formulários.Botão cmdSetores;

		// Observação
//		private EventoObservação		observaçãoFuncionário;

		// Designer
		private System.ComponentModel.IContainer components = null;

		public Principal()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			IniciarBases();
			SubstituirBase(baseRelatórios, this);  

			// Preparar observação
//			observaçãoFuncionário = new Observador.EventoObservação(ObservaçãoFuncionário);

//			Controle.ObservaçãoFuncionário += observaçãoFuncionário;
		}

		private void IniciarBases()
		{
			baseRelatórios = new Administração.Bases.Relatórios();
			//NovaBase(baseRelatórios);
			cmdClientes.Base = baseRelatórios;

			cmdFuncionários.Base = new Administração.Bases.Funcionários();

			cmdSetores.Base = new Administração.Bases.Setores();
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

//			Controle.ObservaçãoFuncionário -= observaçãoFuncionário;
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Principal));
			this.cmdFuncionários = new Apresentação.Formulários.Botão();
			this.cmdClientes = new Apresentação.Formulários.Botão();
			this.cmdSetores = new Apresentação.Formulários.Botão();
			this.topo.SuspendLayout();
			this.barraBotões.SuspendLayout();
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
			// barraBotões
			// 
			this.barraBotões.Botões = new Apresentação.Formulários.Botão[] {
																			   this.cmdFuncionários,
																			   this.cmdClientes,
																			   this.cmdSetores};
			this.barraBotões.Controls.Add(this.cmdFuncionários);
			this.barraBotões.Controls.Add(this.cmdClientes);
			this.barraBotões.Controls.Add(this.cmdSetores);
			this.barraBotões.Name = "barraBotões";
			this.barraBotões.Size = new System.Drawing.Size(408, 75);
			// 
			// cmdFuncionários
			// 
			this.cmdFuncionários.BackColor = System.Drawing.Color.Transparent;
			this.cmdFuncionários.Imagem = ((System.Drawing.Image)(resources.GetObject("cmdFuncionários.Imagem")));
			this.cmdFuncionários.Location = new System.Drawing.Point(0, 0);
			this.cmdFuncionários.Name = "cmdFuncionários";
			this.cmdFuncionários.Size = new System.Drawing.Size(72, 73);
			this.cmdFuncionários.TabIndex = 0;
			this.cmdFuncionários.Texto = "Funcionários";
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
			this.barraBotões.ResumeLayout(false);
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
			Apresentação.Formulários.Splash splash;

			splash = new Apresentação.Formulários.Splash();
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

		private static Negócio.Controle.IAdministração controle = null;

		public static Negócio.Controle.IAdministração Controle
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
						reg = reg.OpenSubKey("Indústria Mineira de Jóias");
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
							"/Administração";
					}
					catch
					{
						caminho = caminho = "tcp://imjoias:8100/Administração";
					}

					controle = (Negócio.Controle.IAdministração) Activator.GetObject(typeof(Negócio.Controle.IAdministração), caminho);
				
					// TODO: Pedir senha
					Negócio.Controle.InterfaceControleCriptografado.Conectar(controle, "imjoias", "***REMOVED***");
				}

				return controle;
			}
		}

		#endregion

		#region Observação
/*
		/// <summary>
		/// Observação de funcionários
		/// </summary>
		public void ObservaçãoFuncionário(ISujeito sujeito, int ação, object dados)
		{
			switch ((AçãoFuncionário) ação)
			{
				case AçãoFuncionário.Contratado:
			}
		}
*/
		#endregion
	}
}

