using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Apresenta��o.Formul�rios;
using System.Collections.Generic;

namespace Apresenta��o.Integra��oSistemaAntigo
{
	public class BaseMercadorias : Apresenta��o.Formul�rios.BaseInferior
	{
		private System.ComponentModel.IContainer components = null;
	
		//Vari�veis 
		private Apresenta��o.Formul�rios.Quadro quadroErros;
		private Apresenta��o.Formul�rios.Quadro quadro1;
		private System.Windows.Forms.Label label1;
		private Apresenta��o.Formul�rios.Quadro quadroDiret�rio;
		private System.Windows.Forms.Button btnTrocarDiret�rio;
		
		private System.Windows.Forms.TextBox txtDiret�rio;
		private System.Windows.Forms.Button aaa;
		private Apresenta��o.Formul�rios.Quadro quadro2;
		private System.Windows.Forms.Label label2;
		private Apresenta��o.Formul�rios.Quadro quadro3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox lstErros;
        private System.Windows.Forms.Label label4;
        private Label label5;
        private Label lblCota��oVarejo;
        //private string diret�rio = @"c:\";
        private double cota��oVarejo;

		public delegate void ReportarInconsistenciaDelegate(string mensagem);
		
		public BaseMercadorias()
		{
			InitializeComponent();
		}

        public static DataSet ObterDataSetMercadoria(List<IDbConnection> conex�esRemovidas)
        {
            DataSet ds;
            
            ds = new DataSet();
            MySQL.AdicionarTabelaAoDataSet(ds, "faixa", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "mercadoria", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "componentecusto", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriacomponentecusto", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "vinculomercadoriafornecedor", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "fornecedor", conex�esRemovidas);
            MySQL.AdicionarTabelaAoDataSet(ds, "tabelamercadoria", conex�esRemovidas);

            return ds;
        }

		protected override void AoExibirDaPrimeiraVez()
		{
			base.AoExibirDaPrimeiraVez ();

            txtDiret�rio.Text = @"c:\fox";

            cota��oVarejo = 
            Entidades.Cota��o.ObterCota��oVigente(Entidades.Moeda.ObterMoeda(4)).Valor;

            lblCota��oVarejo.Text = cota��oVarejo.ToString("C");
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
            this.quadroErros = new Apresenta��o.Formul�rios.Quadro();
            this.lstErros = new System.Windows.Forms.ListBox();
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.quadroDiret�rio = new Apresenta��o.Formul�rios.Quadro();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiret�rio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTrocarDiret�rio = new System.Windows.Forms.Button();
            this.lblCota��oVarejo = new System.Windows.Forms.Label();
            this.aaa = new System.Windows.Forms.Button();
            this.quadro2 = new Apresenta��o.Formul�rios.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.quadro3 = new Apresenta��o.Formul�rios.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.esquerda.SuspendLayout();
            this.quadroErros.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.quadroDiret�rio.SuspendLayout();
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
            this.quadroErros.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroErros.LetraT�tulo = System.Drawing.Color.White;
            this.quadroErros.Location = new System.Drawing.Point(193, 152);
            this.quadroErros.MostrarBot�oMinMax = false;
            this.quadroErros.Name = "quadroErros";
            this.quadroErros.Size = new System.Drawing.Size(440, 328);
            this.quadroErros.TabIndex = 8;
            this.quadroErros.Tamanho = 30;
            this.quadroErros.T�tulo = "O sistema � transposto idependentemente dos erros mostrados abaixo";
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
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(16, 32);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(144, 104);
            this.quadro1.TabIndex = 0;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "T�tulo";
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
            // quadroDiret�rio
            // 
            this.quadroDiret�rio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroDiret�rio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroDiret�rio.bInfDirArredondada = true;
            this.quadroDiret�rio.bInfEsqArredondada = true;
            this.quadroDiret�rio.bSupDirArredondada = true;
            this.quadroDiret�rio.bSupEsqArredondada = true;
            this.quadroDiret�rio.Controls.Add(this.label4);
            this.quadroDiret�rio.Controls.Add(this.txtDiret�rio);
            this.quadroDiret�rio.Controls.Add(this.label5);
            this.quadroDiret�rio.Controls.Add(this.btnTrocarDiret�rio);
            this.quadroDiret�rio.Controls.Add(this.lblCota��oVarejo);
            this.quadroDiret�rio.Cor = System.Drawing.Color.Black;
            this.quadroDiret�rio.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroDiret�rio.LetraT�tulo = System.Drawing.Color.White;
            this.quadroDiret�rio.Location = new System.Drawing.Point(192, 8);
            this.quadroDiret�rio.MostrarBot�oMinMax = false;
            this.quadroDiret�rio.Name = "quadroDiret�rio";
            this.quadroDiret�rio.Size = new System.Drawing.Size(440, 138);
            this.quadroDiret�rio.TabIndex = 9;
            this.quadroDiret�rio.Tamanho = 30;
            this.quadroDiret�rio.T�tulo = "Informa��es necess�rias para a transposi��o";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Diret�rio dos dbfs:";
            // 
            // txtDiret�rio
            // 
            this.txtDiret�rio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiret�rio.Location = new System.Drawing.Point(8, 40);
            this.txtDiret�rio.Name = "txtDiret�rio";
            this.txtDiret�rio.Size = new System.Drawing.Size(424, 20);
            this.txtDiret�rio.TabIndex = 3;
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
            this.label5.Text = "Certifique-se de que a cota��o do varejo est� corretamente cadastrada antes de re" +
                "alizar a transposi��o ";
            // 
            // btnTrocarDiret�rio
            // 
            this.btnTrocarDiret�rio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTrocarDiret�rio.Location = new System.Drawing.Point(392, 0);
            this.btnTrocarDiret�rio.Name = "btnTrocarDiret�rio";
            this.btnTrocarDiret�rio.Size = new System.Drawing.Size(24, 16);
            this.btnTrocarDiret�rio.TabIndex = 2;
            this.btnTrocarDiret�rio.Text = "...";
            this.btnTrocarDiret�rio.UseVisualStyleBackColor = false;
            // 
            // lblCota��oVarejo
            // 
            this.lblCota��oVarejo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCota��oVarejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCota��oVarejo.Location = new System.Drawing.Point(8, 112);
            this.lblCota��oVarejo.Name = "lblCota��oVarejo";
            this.lblCota��oVarejo.Size = new System.Drawing.Size(429, 24);
            this.lblCota��oVarejo.TabIndex = 6;
            this.lblCota��oVarejo.Text = "R$";
            this.lblCota��oVarejo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.quadro2.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro2.LetraT�tulo = System.Drawing.Color.White;
            this.quadro2.Location = new System.Drawing.Point(16, 16);
            this.quadro2.MostrarBot�oMinMax = false;
            this.quadro2.Name = "quadro2";
            this.quadro2.Size = new System.Drawing.Size(144, 88);
            this.quadro2.TabIndex = 0;
            this.quadro2.Tamanho = 30;
            this.quadro2.T�tulo = "T�tulo";
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
            this.quadro3.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro3.LetraT�tulo = System.Drawing.Color.White;
            this.quadro3.Location = new System.Drawing.Point(7, 16);
            this.quadro3.MostrarBot�oMinMax = false;
            this.quadro3.Name = "quadro3";
            this.quadro3.Size = new System.Drawing.Size(160, 104);
            this.quadro3.TabIndex = 0;
            this.quadro3.Tamanho = 30;
            this.quadro3.T�tulo = "Arquivos necess�rios";
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
            this.Controls.Add(this.quadroDiret�rio);
            this.Controls.Add(this.quadroErros);
            this.Name = "BaseMercadorias";
            this.Size = new System.Drawing.Size(640, 624);
            this.Controls.SetChildIndex(this.quadroErros, 0);
            this.Controls.SetChildIndex(this.quadroDiret�rio, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroErros.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadroDiret�rio.ResumeLayout(false);
            this.quadroDiret�rio.PerformLayout();
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
            string diret�rio = pasta.SelectedPath;

            Dbf dbf = null;
            
            DateTime inicio = DateTime.Now;

            AguardeDB.Mostrar();

            // ReportarInconsistenciaDelegate ErroFun��o = new ReportarInconsistenciaDelegate(ReportarInconsistencia);
            List<IDbConnection> conex�esRemovidas = new List<IDbConnection>();
            dsNovo = ObterDataSetMercadoria(conex�esRemovidas);

            Controles.Mercadorias.Faixas.dsNovo = dsNovo;

            dbf = new Apresenta��o.Integra��oSistemaAntigo.Dbf(diret�rio);
            dsVelho = dbf.ObterDataSetMercadoria();

            new Controles.Mercadorias.Fornecedor(dsVelho, dsNovo, dbf);

            //aguarde.Passo("Transpondo componente de custo");
            new Controles.Mercadorias.ComponenteDeCusto(dsVelho, dsNovo, dbf).Transpor();

            new Controles.Mercadorias.Mercadorias(dsVelho, dsNovo, dbf).Transpor();

            //aguarde.Passo("Gerando coeficientes a partir do dbf");
            //new Controles.Mercadorias.Indices(ErroFun��o, dsVelho, dsNovo).Transpor(cota��oVarejo);

            //aguarde.Passo("Transpondo v�nculo entre mercadoria e componente de custo"); 
            new Controles.Mercadorias.VinculoMercadoriaComponenteCusto(dsVelho, dsNovo).Transpor();
            MySQL.GravarDataSetTodasTabelas(dsNovo);
            
            AguardeDB.Fechar();

            double cota��oVarejo =
            Entidades.Cota��o.ObterCota��oVigente(Entidades.Moeda.ObterMoeda(4)).Valor;

            new Controles.Mercadorias.Indices(dsVelho, dsNovo).Transpor(cota��oVarejo);

            MySQL.AdicionarConex�esRemovidas(conex�esRemovidas);
            TimeSpan decorrido = DateTime.Now - inicio;
            MessageBox.Show("A integra��o terminou em " + 
             Math.Round(decorrido.TotalSeconds).ToString() + 
             " segundos. � necess�rio \nreiniciar cada esta��o para acessar os novos �ndices.", "T�rmino da Integra��o", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
	}
}

