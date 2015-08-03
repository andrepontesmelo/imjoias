using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ConfiguraProxy
{
	/// <summary>
	/// Summary description for Relatório.
	/// </summary>
	public class Relatório : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MySql banco=null;
		public Relatório(MySql meuBanco)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			banco = meuBanco;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
																													 "",
																													 ""}, -1);
			this.listView1 = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1});
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(288, 256);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
			// 
			// Relatório
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.listView1);
			this.Name = "Relatório";
			this.Text = "Relatório";
			this.Resize += new System.EventHandler(this.Relatório_Resize);
			this.Load += new System.EventHandler(this.Relatório_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void Relatório_Load(object sender, System.EventArgs e)
		{

		}
		private void CriaTítulos() 
		{
			listView1.Columns.Clear();

			listView1.Columns.Add("Acesso Id",70,HorizontalAlignment.Center);
			listView1.Columns.Add("Data",120,HorizontalAlignment.Left);
			listView1.Columns.Add("Usuário",100,HorizontalAlignment.Left);
			listView1.Columns.Add("Ip",200,HorizontalAlignment.Left );
			listView1.Columns.Add("Site",170,HorizontalAlignment.Left );
			listView1.Columns.Add("Acesso",50,HorizontalAlignment.Center);

		}
		public void ConstruirLog() 
		{
			CriaTítulos();
			banco.PreencheListView(listView1,5,"select log.ID,data,nome,enderecoIp,host,permitido from log,ips,links,usuarios WHERE log.usuarioId=usuarios.id AND log.usuarioId = ips.usuarioId AND log.linkId=links.Id order by log.id");

		}

		private void listView1_Resize(object sender, System.EventArgs e)
		{
		}

		private void Relatório_Resize(object sender, System.EventArgs e)
		{
			listView1.Height = Convert.ToInt32(this.Height*(0.85));
			listView1.Width = Convert.ToInt32(this.Width*(0.85));
					
		}
	}
}
