using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Report;
using Report.Layout;

namespace Teste
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader Teste;
		private System.Windows.Forms.ColumnHeader bla;
		private System.Windows.Forms.ColumnHeader asdfas;
		private Report.Layout.SimpleLayout leiaute;
		private System.Windows.Forms.Label label1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.Teste = new System.Windows.Forms.ColumnHeader();
			this.bla = new System.Windows.Forms.ColumnHeader();
			this.asdfas = new System.Windows.Forms.ColumnHeader();
			this.leiaute = new Report.Layout.SimpleLayout(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.SuspendLayout();
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(132, 174);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(120, 80);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.Teste,
																						this.bla,
																						this.asdfas});
			this.listView1.Location = new System.Drawing.Point(8, 152);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(256, 56);
			this.listView1.TabIndex = 1;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// bla
			// 
			this.bla.Text = "Outro teste";
			this.bla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// asdfas
			// 
			this.asdfas.Text = "Mais alguma coisa?";
			this.asdfas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.asdfas.Width = 215;
			// 
			// leiaute
			// 
			this.leiaute.AutoDistributeColumns = true;
			this.leiaute.Document = this.printDocument1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			leiaute.ImportarClasse(typeof(ColumnHeader));
			leiaute.Objects = listView1.Columns;
			
		//	documentLayout.Objects = listView1.Columns;

			printPreviewDialog1.Document = leiaute.Document;
			printPreviewDialog1.Show();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

		}
	}
}
