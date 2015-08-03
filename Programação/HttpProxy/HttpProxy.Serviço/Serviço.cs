using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace HttpProxy
{
	public class Serviço : System.ServiceProcess.ServiceBase
	{
		private HttpProxy proxy;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Serviço()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Serviço
			// 
			this.ServiceName = "HttpProxy";

		}
		#endregion

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
		}

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.BelowNormal;

			proxy = new HttpProxy(args.Length > 0 ? int.Parse(args[0]) : 6070);
		}
 
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			proxy.Dispose();
		}

		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;

			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Serviço() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}
	}
}
