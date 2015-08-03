using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace TransformadorBancoDeDados
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Dbf ccusto,cadmer;
		private MySql novo = new MySql();
		private System.Windows.Forms.Button Inicio;
		private System.Windows.Forms.ProgressBar pb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox cadmerArquivo;
		private System.Windows.Forms.TextBox ccustoArquivo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox mysqlLogin;
		private System.Windows.Forms.TextBox mysqlSenha;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox mysqlIp;
		private System.Windows.Forms.TextBox camposRepetidos;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox vfa;
		private System.Windows.Forms.TextBox vfb;
		private System.Windows.Forms.TextBox vfc;
		private System.Windows.Forms.TextBox vfd;
		private System.Windows.Forms.TextBox vfe;
		private System.Windows.Forms.TextBox afa;
		private System.Windows.Forms.TextBox afb;
		private System.Windows.Forms.TextBox afc;
		private System.Windows.Forms.TextBox afd;
		private System.Windows.Forms.TextBox afe;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button Benchmark;
		private System.ComponentModel.Container components = null;
		

		public Form1()
		{
			
			//
			// Required for Windows Form Designer support

			InitializeComponent();

		}

		public void Logar(string mensagem) 
		{
			camposRepetidos.Text+=mensagem+"\n";
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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ccustoArquivo = new System.Windows.Forms.TextBox();
			this.cadmerArquivo = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.mysqlSenha = new System.Windows.Forms.TextBox();
			this.mysqlLogin = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.mysqlIp = new System.Windows.Forms.TextBox();
			this.camposRepetidos = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.vfe = new System.Windows.Forms.TextBox();
			this.vfd = new System.Windows.Forms.TextBox();
			this.vfc = new System.Windows.Forms.TextBox();
			this.vfb = new System.Windows.Forms.TextBox();
			this.vfa = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.afe = new System.Windows.Forms.TextBox();
			this.afd = new System.Windows.Forms.TextBox();
			this.afc = new System.Windows.Forms.TextBox();
			this.afb = new System.Windows.Forms.TextBox();
			this.afa = new System.Windows.Forms.TextBox();
			this.Benchmark = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
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
			this.pb.Location = new System.Drawing.Point(16, 136);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(664, 32);
			this.pb.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ccustoArquivo);
			this.groupBox1.Controls.Add(this.cadmerArquivo);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 112);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Configure a entrada";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(232, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Arquivo CCusto (Componente de custo)";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Arquivo Cadmer ( mercadorias ) ";
			// 
			// ccustoArquivo
			// 
			this.ccustoArquivo.Location = new System.Drawing.Point(8, 72);
			this.ccustoArquivo.Name = "ccustoArquivo";
			this.ccustoArquivo.Size = new System.Drawing.Size(272, 20);
			this.ccustoArquivo.TabIndex = 1;
			this.ccustoArquivo.Text = "D:\\Firma Nova\\Programa antigo";
			this.ccustoArquivo.TextChanged += new System.EventHandler(this.ccustoArquivo_TextChanged);
			// 
			// cadmerArquivo
			// 
			this.cadmerArquivo.Location = new System.Drawing.Point(8, 32);
			this.cadmerArquivo.Name = "cadmerArquivo";
			this.cadmerArquivo.Size = new System.Drawing.Size(272, 20);
			this.cadmerArquivo.TabIndex = 0;
			this.cadmerArquivo.Text = "D:\\Firma Nova\\Programa antigo";
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
			this.mysqlSenha.Text = "imj";
			// 
			// mysqlLogin
			// 
			this.mysqlLogin.Location = new System.Drawing.Point(56, 64);
			this.mysqlLogin.Name = "mysqlLogin";
			this.mysqlLogin.Size = new System.Drawing.Size(136, 20);
			this.mysqlLogin.TabIndex = 2;
			this.mysqlLogin.Text = "imjoias";
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
			// camposRepetidos
			// 
			this.camposRepetidos.Location = new System.Drawing.Point(16, 176);
			this.camposRepetidos.Multiline = true;
			this.camposRepetidos.Name = "camposRepetidos";
			this.camposRepetidos.Size = new System.Drawing.Size(112, 184);
			this.camposRepetidos.TabIndex = 4;
			this.camposRepetidos.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.vfe);
			this.groupBox3.Controls.Add(this.vfd);
			this.groupBox3.Controls.Add(this.vfc);
			this.groupBox3.Controls.Add(this.vfb);
			this.groupBox3.Controls.Add(this.vfa);
			this.groupBox3.Location = new System.Drawing.Point(136, 176);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 176);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Marcação das Faixas - Varejo";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(24, 96);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 16);
			this.label15.TabIndex = 11;
			this.label15.Text = "Faixa D:";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(24, 120);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(48, 16);
			this.label14.TabIndex = 10;
			this.label14.Text = "Faixa E:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(24, 80);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 9;
			this.label13.Text = "Faixa C";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(24, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 16);
			this.label12.TabIndex = 8;
			this.label12.Text = "Faixa A:";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(24, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 7;
			this.label11.Text = "Faixa B";
			// 
			// vfe
			// 
			this.vfe.Location = new System.Drawing.Point(72, 120);
			this.vfe.Name = "vfe";
			this.vfe.Size = new System.Drawing.Size(88, 20);
			this.vfe.TabIndex = 4;
			this.vfe.Text = " 0.59";
			// 
			// vfd
			// 
			this.vfd.Location = new System.Drawing.Point(72, 96);
			this.vfd.Name = "vfd";
			this.vfd.Size = new System.Drawing.Size(88, 20);
			this.vfd.TabIndex = 3;
			this.vfd.Text = "1.61";
			// 
			// vfc
			// 
			this.vfc.Location = new System.Drawing.Point(72, 72);
			this.vfc.Name = "vfc";
			this.vfc.Size = new System.Drawing.Size(88, 20);
			this.vfc.TabIndex = 2;
			this.vfc.Text = "1.35";
			// 
			// vfb
			// 
			this.vfb.Location = new System.Drawing.Point(72, 48);
			this.vfb.Name = "vfb";
			this.vfb.Size = new System.Drawing.Size(88, 20);
			this.vfb.TabIndex = 1;
			this.vfb.Text = "1.03";
			// 
			// vfa
			// 
			this.vfa.Location = new System.Drawing.Point(72, 24);
			this.vfa.Name = "vfa";
			this.vfa.Size = new System.Drawing.Size(88, 20);
			this.vfa.TabIndex = 0;
			this.vfa.Text = "0.86";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.afe);
			this.groupBox4.Controls.Add(this.afd);
			this.groupBox4.Controls.Add(this.afc);
			this.groupBox4.Controls.Add(this.afb);
			this.groupBox4.Controls.Add(this.afa);
			this.groupBox4.Location = new System.Drawing.Point(344, 176);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(240, 176);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Marcação das Faixas - Atacado";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(56, 112);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 16);
			this.label10.TabIndex = 12;
			this.label10.Text = "Faixa E";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(64, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 11;
			this.label9.Text = "Faixa D";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(56, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 16);
			this.label8.TabIndex = 10;
			this.label8.Text = "Faixa C";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(56, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 9;
			this.label7.Text = "Faixa B";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(56, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "Faixa A:";
			// 
			// afe
			// 
			this.afe.Location = new System.Drawing.Point(112, 112);
			this.afe.Name = "afe";
			this.afe.Size = new System.Drawing.Size(88, 20);
			this.afe.TabIndex = 5;
			this.afe.Text = "0.16";
			// 
			// afd
			// 
			this.afd.Location = new System.Drawing.Point(112, 88);
			this.afd.Name = "afd";
			this.afd.Size = new System.Drawing.Size(88, 20);
			this.afd.TabIndex = 4;
			this.afd.Text = "0.63";
			// 
			// afc
			// 
			this.afc.Location = new System.Drawing.Point(112, 64);
			this.afc.Name = "afc";
			this.afc.Size = new System.Drawing.Size(88, 20);
			this.afc.TabIndex = 3;
			this.afc.Text = "0.47";
			// 
			// afb
			// 
			this.afb.Location = new System.Drawing.Point(112, 40);
			this.afb.Name = "afb";
			this.afb.Size = new System.Drawing.Size(88, 20);
			this.afb.TabIndex = 2;
			this.afb.Text = "0.27";
			// 
			// afa
			// 
			this.afa.Location = new System.Drawing.Point(112, 16);
			this.afa.Name = "afa";
			this.afa.Size = new System.Drawing.Size(88, 20);
			this.afa.TabIndex = 1;
			this.afa.Text = "0.16";
			// 
			// Benchmark
			// 
			this.Benchmark.Location = new System.Drawing.Point(592, 192);
			this.Benchmark.Name = "Benchmark";
			this.Benchmark.Size = new System.Drawing.Size(72, 72);
			this.Benchmark.TabIndex = 7;
			this.Benchmark.Text = "BenchMark";
			this.Benchmark.Click += new System.EventHandler(this.Benchmark_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 374);
			this.Controls.Add(this.Benchmark);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.camposRepetidos);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pb);
			this.Controls.Add(this.Inicio);
			this.Controls.Add(this.groupBox4);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Transfere de MDB para MySql";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
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
			TestePerformace.modoTeste = false;
			Inicio.Enabled = false;
			ccusto  = new Dbf(ccustoArquivo.Text,novo,pb);
			cadmer = new Dbf(cadmerArquivo.Text ,novo,pb);
			novo.Conectar("imjoias",mysqlIp.Text ,mysqlLogin.Text ,mysqlSenha.Text );
			if ( TestePerformace.modoTeste == false ) 	novo.ApagarTudo();
			CriarFaixas();
			
			this.Text = "1. Copiando Componente de custo...";
			ccusto.LerComponenteCusto();
			this.Text = "2. Copiando Preços dos Componente de custo... e inserir mercadorias e vinculos";
			cadmer.LerValores();
			this.Text = "3. Pronto.";
		}

		private void CriarFaixas() 
		{
			//1 varejo
			//2 atacado
			
			novo.CriarFaixas("1","a",vfa.Text);
			novo.CriarFaixas("1","b",vfb.Text);
			novo.CriarFaixas("1","c",vfc.Text);
			novo.CriarFaixas("1","d",vfd.Text);
			novo.CriarFaixas("1","e",vfe.Text);
			
			novo.CriarFaixas("2","a",afa.Text);
			novo.CriarFaixas("2","b",afb.Text);
			novo.CriarFaixas("2","c",afc.Text);
			novo.CriarFaixas("2","d",afd.Text);
			novo.CriarFaixas("2","e",afe.Text);



		}

		private void ccustoArquivo_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Benchmark_Click(object sender, System.EventArgs e)
		{

			
			novo.Conectar("imjoias",mysqlIp.Text ,mysqlLogin.Text ,mysqlSenha.Text );
			TestePerformace[] performace = new TestePerformace[TestePerformace.threads];
			TestePerformace.modoTeste = true;
			Thread[] thread = new Thread[TestePerformace.threads];
			
			for ( short atual=0;atual<TestePerformace.threads;atual++) 
			{
				performace[atual] = new  TestePerformace(novo)  ;
				if (atual < (TestePerformace.threads /2)) 
					thread[atual] = new Thread(new ThreadStart( performace[atual].GerarComponenteCustoValor )  );
				else	thread[atual] = new Thread(new ThreadStart( performace[atual].GerarMercadorias )  );
					thread[atual].Start();
			}

		}


			}
}
