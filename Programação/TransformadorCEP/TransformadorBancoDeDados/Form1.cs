using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using ByteFX.Data.MySqlClient;

namespace TransformadorBancoDeDados
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Dbf antigo;

		private MySql novo;
		private System.Windows.Forms.Button Inicio;
		private System.Windows.Forms.ProgressBar pb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox mysqlLogin;
		private System.Windows.Forms.TextBox mysqlSenha;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox mysqlIp;
		private System.Windows.Forms.TextBox origemTxt;
		private System.Windows.Forms.TextBox errosTxt;
		private System.ComponentModel.Container components = null;
		
		public void Loga(String oque)
		{
			errosTxt.Text  += oque;
		}

		public Form1()
		{
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
			this.Inicio = new System.Windows.Forms.Button();
			this.pb = new System.Windows.Forms.ProgressBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.origemTxt = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.mysqlSenha = new System.Windows.Forms.TextBox();
			this.mysqlLogin = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.mysqlIp = new System.Windows.Forms.TextBox();
			this.errosTxt = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Inicio
			// 
			this.Inicio.Location = new System.Drawing.Point(592, 16);
			this.Inicio.Name = "Inicio";
			this.Inicio.Size = new System.Drawing.Size(80, 80);
			this.Inicio.TabIndex = 0;
			this.Inicio.Text = "inicio";
			this.Inicio.Click += new System.EventHandler(this.Inicio_Click);
			// 
			// pb
			// 
			this.pb.Location = new System.Drawing.Point(8, 232);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(664, 32);
			this.pb.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.origemTxt);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 64);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Configure a entrada";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Arquivo de origem";
			// 
			// origemTxt
			// 
			this.origemTxt.Location = new System.Drawing.Point(8, 32);
			this.origemTxt.Name = "origemTxt";
			this.origemTxt.Size = new System.Drawing.Size(272, 20);
			this.origemTxt.TabIndex = 0;
			this.origemTxt.Text = "e:\\cep\\novo.mdb";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.mysqlSenha);
			this.groupBox2.Controls.Add(this.mysqlLogin);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.mysqlIp);
			this.groupBox2.Location = new System.Drawing.Point(312, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(264, 112);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Configure a Saída";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Senha:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 24);
			this.label4.TabIndex = 4;
			this.label4.Text = "Login:";
			// 
			// mysqlSenha
			// 
			this.mysqlSenha.Location = new System.Drawing.Point(56, 88);
			this.mysqlSenha.Name = "mysqlSenha";
			this.mysqlSenha.PasswordChar = '*';
			this.mysqlSenha.Size = new System.Drawing.Size(136, 20);
			this.mysqlSenha.TabIndex = 3;
			this.mysqlSenha.Text = "cep";
			// 
			// mysqlLogin
			// 
			this.mysqlLogin.Location = new System.Drawing.Point(56, 64);
			this.mysqlLogin.Name = "mysqlLogin";
			this.mysqlLogin.Size = new System.Drawing.Size(136, 20);
			this.mysqlLogin.TabIndex = 2;
			this.mysqlLogin.Text = "cep";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Endereço Ip do servidor MySql";
			// 
			// mysqlIp
			// 
			this.mysqlIp.Location = new System.Drawing.Point(56, 32);
			this.mysqlIp.Name = "mysqlIp";
			this.mysqlIp.Size = new System.Drawing.Size(168, 20);
			this.mysqlIp.TabIndex = 0;
			this.mysqlIp.Text = "127.0.0.1";
			// 
			// errosTxt
			// 
			this.errosTxt.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.errosTxt.Location = new System.Drawing.Point(16, 72);
			this.errosTxt.Multiline = true;
			this.errosTxt.Name = "errosTxt";
			this.errosTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.errosTxt.Size = new System.Drawing.Size(288, 160);
			this.errosTxt.TabIndex = 4;
			this.errosTxt.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 278);
			this.Controls.Add(this.errosTxt);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pb);
			this.Controls.Add(this.Inicio);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Transfere de MDB para MySql";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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

		private void Inicio_Click(object sender, System.EventArgs e)
		{
			ByteFX.Data.MySqlClient.MySqlDataAdapter adaptadorNovo;
			DataSet dsNovo, dsVelho, dsVelhoCaixaPostalComunitária, dsVelhoGrandeUsuário, dsVelhoUnidadeOperação;
			
			dsNovo = new DataSet();

			//ArrayList logradouros;
			ArrayList bairros;
			ArrayList localidades;

			Inicio.Enabled = false;
			
			novo = new MySql(this,pb);
			antigo  = new Dbf(origemTxt.Text,novo,pb);
			this.Text = "Conectar";
			novo.Conectar("cep", mysqlIp.Text, mysqlLogin.Text, mysqlSenha.Text);
			this.Text = "apagando tudo";
			novo.apagarTudo();
			this.Text = "obtendo logradouros";
			
			adaptadorNovo = new MySqlDataAdapter("select * from logradouros", novo.Conexão);
			new MySqlCommandBuilder(adaptadorNovo);
			adaptadorNovo.Fill(dsNovo, "logradouros");

						
			dsVelho = antigo.ObterDataSet("LOG_LOGRADOURO");

			this.Text = "1 -> Obtendo os Bairros";
			bairros = antigo.ObterBairros();
			
			this.Text = "2 -> Gravando os Bairros";
			novo.ColocarBairro(bairros);
			bairros = null;

			this.Text = "3 -> Obtendo os Logradouros e gravando";
			new Controles.Logradouros(dsNovo, dsVelho, pb).Traspõe();
			
			this.Text = "4 -> Obtendo os CaixasPostaisComunitárias";
			dsVelhoCaixaPostalComunitária = antigo.ObterDataSet("LOG_CPC");
			new Controles.CaixasPostaisComunitárias(dsNovo, dsVelhoCaixaPostalComunitária, pb).Traspõe();

			this.Text = "5 -> Obtendo Grandes usuários";
			dsVelhoGrandeUsuário = antigo.ObterDataSet("LOG_GRANDE_USUARIO");
			new Controles.GrandesUsuários(dsNovo, dsVelhoGrandeUsuário, pb).Traspõe();
			
			this.Text = "6 -> Obtendo Unidades de operação";
			dsVelhoUnidadeOperação = antigo.ObterDataSet("LOG_UNID_OPER");
			new Controles.UnidadesOperação(dsNovo, dsVelhoUnidadeOperação, pb).Traspõe();

			this.Text = "7 -> Lendo as localidades";
			localidades = antigo.ObterLocalidades();

			this.Text = "8 -> Gravando as localidades";
			novo.ColocarLocalidades(localidades);
			localidades = null;

			this.Text = "Esperando update()";
			adaptadorNovo.Update(dsNovo, "logradouros");

			this.Text = "Fim";
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
		}

	}
}
