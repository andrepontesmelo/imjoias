using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ByteFX.Data.MySqlClient;

namespace Estat�stica.Db.Visualizador
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class VisGr�fico : System.Windows.Forms.Form
	{
		private IDbConnection conex�o;
		private IDataParameterCollection par�metros;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuArqAbrir;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public VisGr�fico()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			conex�o = new MySqlConnection("Data Source=localhost;Database=imjoias;User Id=imjoias;Password=imj");
			conex�o.Open();

			par�metros = new MySqlParameterCollection();
			par�metros.Add(new MySqlParameter("periodoInicial", new DateTime(2004, 02, 01, 01, 01, 01)));
			par�metros.Add(new MySqlParameter("periodoFinal", DateTime.Now));
			par�metros.Add(new MySqlParameter("setor", 1));
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuArqAbrir = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuArqAbrir});
			this.menuItem1.Text = "&Arquivo";
			// 
			// mnuArqAbrir
			// 
			this.mnuArqAbrir.Index = 0;
			this.mnuArqAbrir.Text = "A&brir";
			this.mnuArqAbrir.Click += new System.EventHandler(this.mnuArqAbrir_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Documentos XML|*.xml|Todos os arquivos|*.*";
			this.openFileDialog.Title = "Abrir defini��es de gr�ficos";
			// 
			// VisGr�fico
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "VisGr�fico";
			this.Text = "Visualizador de Gr�ficos";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new VisGr�fico());
		}

		private void mnuArqAbrir_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				AbrirDefini��es(openFileDialog.FileName);
			}
		}

		/// <summary>
		/// Abre arquivo de defini��es
		/// </summary>
		/// <param name="arquivo">Defini��es</param>
		private void AbrirDefini��es(string arquivo)
		{
			Estat�stica.Db.Gr�fico gr�fico;
			
			gr�fico = new Estat�stica.Db.Gr�fico();
			gr�fico.CarregarDefini��es(arquivo);
			
			foreach (string t�tulo in gr�fico.Gr�ficos)
			{
				Gr�fico frm = new Gr�fico(conex�o, par�metros, gr�fico, t�tulo);
				frm.MdiParent = this;
				frm.Show();
				frm.Refresh();
			}
		}
	}
}
