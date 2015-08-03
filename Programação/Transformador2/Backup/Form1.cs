using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ByteFX.Data.MySqlClient;

namespace Transformador2
{
	public class Form1 : System.Windows.Forms.Form
	{
		private ByteFX.Data.MySqlClient.MySqlConnection mySqlConnection1;
		private ByteFX.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
		private System.Windows.Forms.Button btnInicio;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			InitializeComponent();

		}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mySqlConnection1 = new ByteFX.Data.MySqlClient.MySqlConnection(this.components);
			this.mySqlDataAdapter1 = new ByteFX.Data.MySqlClient.MySqlDataAdapter();
			this.btnInicio = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mySqlConnection1
			// 
			this.mySqlConnection1.ConnectionString = "server=localhost";
			// 
			// mySqlDataAdapter1
			// 
			this.mySqlDataAdapter1.DeleteCommand = null;
			this.mySqlDataAdapter1.InsertCommand = null;
			this.mySqlDataAdapter1.SelectCommand = null;
			this.mySqlDataAdapter1.UpdateCommand = null;
			// 
			// btnInicio
			// 
			this.btnInicio.Location = new System.Drawing.Point(512, 296);
			this.btnInicio.Name = "btnInicio";
			this.btnInicio.Size = new System.Drawing.Size(96, 24);
			this.btnInicio.TabIndex = 0;
			this.btnInicio.Text = "Inicio";
			this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 334);
			this.Controls.Add(this.btnInicio);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnInicio_Click(object sender, System.EventArgs e)
		{
			Acesso.Dbf dbf;
			Acesso.MySql mysql;
			ComponenteDeCusto componenteDeCusto;
			
			
			dbf = new Transformador2.Acesso.Dbf(@"c:\imj\Programa antigo\");
			mysql = new Transformador2.Acesso.MySql();
			
			

			componenteDeCusto = new ComponenteDeCusto(dbf, mysql);
			componenteDeCusto.Transpor();

			new Mercadorias(dbf, mysql).Transpor();
			new Indice(dbf, mysql).Transpor();
			
//			mysql.AdicionarTabelaAoDataSet("mercadoria");
			//dbf.AdicionarTabelaAoObterDataSet("cadmer");
			new VinculoMercadoriaComponenteCusto(dbf, mysql).Transpor();

			mysql.GravarDataSet("mercadoria");
			MessageBox.Show("Acabou");

		}
	}
}
