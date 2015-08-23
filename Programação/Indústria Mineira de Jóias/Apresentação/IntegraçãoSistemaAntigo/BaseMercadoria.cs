using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Apresentação.Formulários;
using System.Collections.Generic;

namespace Apresentação.IntegraçãoSistemaAntigo
{
	public class BaseMercadorias : Apresentação.Formulários.BaseInferior
	{
		private System.ComponentModel.IContainer components = null;
	
		//Variáveis 
		private Apresentação.Formulários.Quadro quadroErros;
		private Apresentação.Formulários.Quadro quadro1;
		private System.Windows.Forms.Label label1;
		private Apresentação.Formulários.Quadro quadroDiretório;
		private System.Windows.Forms.Button btnTrocarDiretório;
		
		private System.Windows.Forms.TextBox txtDiretório;
		private System.Windows.Forms.Button aaa;
		private Apresentação.Formulários.Quadro quadro2;
		private System.Windows.Forms.Label label2;
		private Apresentação.Formulários.Quadro quadro3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox lstErros;
        private System.Windows.Forms.Label label4;
        private Label label5;
        private Label lblCotaçãoVarejo;
        //private string diretório = @"c:\";
        private double cotaçãoVarejo;

		public delegate void ReportarInconsistenciaDelegate(string mensagem);
		
		public BaseMercadorias()
		{
			InitializeComponent();
		}

        public static DataSet ObterDataSetMercadoria(List<IDbConnection> conexõesRemovidas)
        {
            DataSet ds;
            
            ds = new DataSet();
            MySQL.AdicionarTabelaAoDataSet(ds, "faixa", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "componentecusto", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriacomponentecusto", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriafornecedor", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "fornecedor", conexõesRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conexõesRemovidas);

            return ds;
        }

		protected override void AoExibirDaPrimeiraVez()
		{
			base.AoExibirDaPrimeiraVez ();

            txtDiretório.Text = @"c:\fox";

            cotaçãoVarejo = 
            Entidades.Cotação.ObterCotaçãoVigente(Entidades.Moeda.ObterMoeda(4)).Valor;

            lblCotaçãoVarejo.Text = cotaçãoVarejo.ToString("C");
		}

		public void ReportarInconsistencia(string mensagem)
		{
			lstErros.Items.Add(mensagem);
			lstErros.Update();
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.quadroErros = new Apresentação.Formulários.Quadro();
            this.lstErros = new System.Windows.Forms.ListBox();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.quadroDiretório = new Apresentação.Formulários.Quadro();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiretório = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTrocarDiretório = new System.Windows.Forms.Button();
            this.lblCotaçãoVarejo = new System.Windows.Forms.Label();
            this.aaa = new System.Windows.Forms.Button();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.quadro3 = new Apresentação.Formulários.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.esquerda.SuspendLayout();
            this.quadroErros.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroDiretório.SuspendLayout();
            this.quadro2.SuspendLayout();
            this.quadro3.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.button1);
            this.esquerda.Controls.Add(this.quadro3);
            this.esquerda.Size = new System.Drawing.Size(187, 624);
            this.esquerda.Controls.SetChildIndex(this.quadro3, 0);
            this.esquerda.Controls.SetChildIndex(this.button1, 0);
            // 
            // quadroErros
            // 
            this.quadroErros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroErros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroErros.bInfDirArredondada = true;
            this.quadroErros.bInfEsqArredondada = true;
            this.quadroErros.bSupDirArredondada = true;
            this.quadroErros.bSupEsqArredondada = true;
            this.quadroErros.Controls.Add(this.lstErros);
            this.quadroErros.Cor = System.Drawing.Color.Black;
            this.quadroErros.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroErros.LetraTítulo = System.Drawing.Color.White;
            this.quadroErros.Location = new System.Drawing.Point(193, 152);
            this.quadroErros.MostrarBotãoMinMax = false;
            this.quadroErros.Name = "quadroErros";
            this.quadroErros.Size = new System.Drawing.Size(440, 328);
            this.quadroErros.TabIndex = 8;
            this.quadroErros.Tamanho = 30;
            this.quadroErros.Título = "O sistema é transposto idependentemente dos erros mostrados abaixo";
            // 
            // lstErros
            // 
            this.lstErros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstErros.Location = new System.Drawing.Point(8, 32);
            this.lstErros.Name = "lstErros";
            this.lstErros.Size = new System.Drawing.Size(424, 277);
            this.lstErros.TabIndex = 1;
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.label1);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(16, 32);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(144, 104);
            this.quadro1.TabIndex = 0;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Título";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "cadmer.dbf ccusto.dbf gramas.dbf";
            // 
            // quadroDiretório
            // 
            this.quadroDiretório.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroDiretório.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroDiretório.bInfDirArredondada = true;
            this.quadroDiretório.bInfEsqArredondada = true;
            this.quadroDiretório.bSupDirArredondada = true;
            this.quadroDiretório.bSupEsqArredondada = true;
            this.quadroDiretório.Controls.Add(this.label4);
            this.quadroDiretório.Controls.Add(this.txtDiretório);
            this.quadroDiretório.Controls.Add(this.label5);
            this.quadroDiretório.Controls.Add(this.btnTrocarDiretório);
            this.quadroDiretório.Controls.Add(this.lblCotaçãoVarejo);
            this.quadroDiretório.Cor = System.Drawing.Color.Black;
            this.quadroDiretório.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDiretório.LetraTítulo = System.Drawing.Color.White;
            this.quadroDiretório.Location = new System.Drawing.Point(192, 8);
            this.quadroDiretório.MostrarBotãoMinMax = false;
            this.quadroDiretório.Name = "quadroDiretório";
            this.quadroDiretório.Size = new System.Drawing.Size(440, 138);
            this.quadroDiretório.TabIndex = 9;
            this.quadroDiretório.Tamanho = 30;
            this.quadroDiretório.Título = "Informações necessárias para a transposição";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Diretório dos dbfs:";
            // 
            // txtDiretório
            // 
            this.txtDiretório.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiretório.Location = new System.Drawing.Point(8, 40);
            this.txtDiretório.Name = "txtDiretório";
            this.txtDiretório.Size = new System.Drawing.Size(424, 20);
            this.txtDiretório.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(8, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(408, 37);
            this.label5.TabIndex = 5;
            this.label5.Text = "Certifique-se de que a cotação do varejo está corretamente cadastrada antes de re" +
                "alizar a transposição ";
            // 
            // btnTrocarDiretório
            // 
            this.btnTrocarDiretório.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTrocarDiretório.Location = new System.Drawing.Point(392, 0);
            this.btnTrocarDiretório.Name = "btnTrocarDiretório";
            this.btnTrocarDiretório.Size = new System.Drawing.Size(24, 16);
            this.btnTrocarDiretório.TabIndex = 2;
            this.btnTrocarDiretório.Text = "...";
            this.btnTrocarDiretório.UseVisualStyleBackColor = false;
            // 
            // lblCotaçãoVarejo
            // 
            this.lblCotaçãoVarejo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCotaçãoVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCotaçãoVarejo.Location = new System.Drawing.Point(8, 112);
            this.lblCotaçãoVarejo.Name = "lblCotaçãoVarejo";
            this.lblCotaçãoVarejo.Size = new System.Drawing.Size(429, 24);
            this.lblCotaçãoVarejo.TabIndex = 6;
            this.lblCotaçãoVarejo.Text = "R$";
            this.lblCotaçãoVarejo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // aaa
            // 
            this.aaa.Location = new System.Drawing.Point(0, 0);
            this.aaa.Name = "aaa";
            this.aaa.Size = new System.Drawing.Size(75, 23);
            this.aaa.TabIndex = 0;
            // 
            // quadro2
            // 
            this.quadro2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro2.bInfDirArredondada = true;
            this.quadro2.bInfEsqArredondada = true;
            this.quadro2.bSupDirArredondada = true;
            this.quadro2.bSupEsqArredondada = true;
            this.quadro2.Controls.Add(this.label2);
            this.quadro2.Cor = System.Drawing.Color.Black;
            this.quadro2.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraTítulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(16, 16);
            this.quadro2.MostrarBotãoMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(144, 88);
            this.quadro2.TabIndex = 0;
            this.quadro2.Tamanho = 30;
            this.quadro2.Título = "Título";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(40, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "cadmer.dbf ccusto.dbf gramas.dbf";
            // 
            // quadro3
            // 
            this.quadro3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro3.bInfDirArredondada = true;
            this.quadro3.bInfEsqArredondada = true;
            this.quadro3.bSupDirArredondada = true;
            this.quadro3.bSupEsqArredondada = true;
            this.quadro3.Controls.Add(this.label3);
            this.quadro3.Cor = System.Drawing.Color.Black;
            this.quadro3.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraTítulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 16);
            this.quadro3.MostrarBotãoMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 104);
            this.quadro3.TabIndex = 0;
            this.quadro3.Tamanho = 30;
            this.quadro3.Título = "Arquivos necessários";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(40, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "cadmer.dbf ccusto.dbf gramas.dbf";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Iniciar";
            // 
            // BaseMercadorias
            // 
            this.Controls.Add(this.quadroDiretório);
            this.Controls.Add(this.quadroErros);
            this.Name = "BaseMercadorias";
            this.Size = new System.Drawing.Size(640, 624);
            this.Controls.SetChildIndex(this.quadroErros, 0);
            this.Controls.SetChildIndex(this.quadroDiretório, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroErros.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroDiretório.ResumeLayout(false);
            this.quadroDiretório.PerformLayout();
            this.quadro2.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        public static void ImportarDadosDoSistemaLegado()
        {
            FolderBrowserDialog pasta = new FolderBrowserDialog();
            pasta.ShowNewFolderButton = false;

            if (pasta.ShowDialog() != DialogResult.OK)
                return;

            DataSet dsNovo;
            DataSet dsVelho = new DataSet();
            string diretório = pasta.SelectedPath;

            Dbf dbf = null;
            
            DateTime inicio = DateTime.Now;

            AguardeDB.Mostrar();

            // ReportarInconsistenciaDelegate ErroFunção = new ReportarInconsistenciaDelegate(ReportarInconsistencia);
            List<IDbConnection> conexõesRemovidas = new List<IDbConnection>();
            dsNovo = ObterDataSetMercadoria(conexõesRemovidas);

            Controles.Mercadorias.Faixas.dsNovo = dsNovo;

            dbf = new Apresentação.IntegraçãoSistemaAntigo.Dbf(diretório);
            dsVelho = dbf.ObterDataSetMercadoria();

            new Controles.Mercadorias.Fornecedor(dsVelho, dsNovo, dbf);

            //aguarde.Passo("Transpondo componente de custo");
            new Controles.Mercadorias.ComponenteDeCusto(dsVelho, dsNovo, dbf).Transpor();

            new Controles.Mercadorias.Mercadorias(dsVelho, dsNovo, dbf).Transpor();

            //aguarde.Passo("Gerando coeficientes a partir do dbf");
            //new Controles.Mercadorias.Indices(ErroFunção, dsVelho, dsNovo).Transpor(cotaçãoVarejo);

            //aguarde.Passo("Transpondo vínculo entre mercadoria e componente de custo"); 
            new Controles.Mercadorias.VinculoMercadoriaComponenteCusto(dsVelho, dsNovo).Transpor();
            MySQL.GravarDataSetTodasTabelas(dsNovo);
            
            AguardeDB.Fechar();

            double cotaçãoVarejo =
            Entidades.Cotação.ObterCotaçãoVigente(Entidades.Moeda.ObterMoeda(4)).Valor;

            new Controles.Mercadorias.Indices(dsVelho, dsNovo).Transpor(cotaçãoVarejo);

            MySQL.AdicionarConexõesRemovidas(conexõesRemovidas);
            TimeSpan decorrido = DateTime.Now - inicio;
            MessageBox.Show("A integração terminou em " + 
             Math.Round(decorrido.TotalSeconds).ToString() + 
             " segundos. É necessário \nreiniciar cada estação para acessar os novos índices.", "Término da Integração", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
	}
}

