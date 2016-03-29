using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace Apresenta��o.Integra��oSistemaAntigo.Pagamentos
{
    public class BasePagamentos : Apresenta��o.Formul�rios.BaseInferior
    {
        private System.ComponentModel.IContainer components = null;

        //Vari�veis 
        private Apresenta��o.Formul�rios.Quadro quadroErros;
        private Apresenta��o.Formul�rios.Quadro quadro1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aaa;
        private Apresenta��o.Formul�rios.Quadro quadro2;
        private System.Windows.Forms.Label label2;
        private Apresenta��o.Formul�rios.Quadro quadro3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstErros;
        private string diret�rio = @"c:\fox\";

        public BasePagamentos()
        {
            InitializeComponent();

        }

        protected override void AoExibirDaPrimeiraVez()
        {
            base.AoExibirDaPrimeiraVez();
        }

        public void ReportarInconsistencia(string mensagem)
        {
            lstErros.Items.Add(mensagem);
            lstErros.Update();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            this.aaa = new System.Windows.Forms.Button();
            this.quadro2 = new Apresenta��o.Formul�rios.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.quadro3 = new Apresenta��o.Formul�rios.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.esquerda.SuspendLayout();
            this.quadroErros.SuspendLayout();
            this.quadro1.SuspendLayout();
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
            this.quadroErros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
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
            this.quadroErros.Location = new System.Drawing.Point(193, 16);
            this.quadroErros.MostrarBot�oMinMax = false;
            this.quadroErros.Name = "quadroErros";
            this.quadroErros.Size = new System.Drawing.Size(440, 605);
            this.quadroErros.TabIndex = 8;
            this.quadroErros.Tamanho = 30;
            this.quadroErros.T�tulo = "O sistema � transposto idependentemente dos erros mostrados abaixo";
            // 
            // lstErros
            // 
            this.lstErros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstErros.Location = new System.Drawing.Point(8, 32);
            this.lstErros.Name = "lstErros";
            this.lstErros.Size = new System.Drawing.Size(424, 563);
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
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "cadmer.dbf ccusto.dbf gramas.dbf";
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
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
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
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Location = new System.Drawing.Point(28, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "vendcli.dbf (pagamentos)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Iniciar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BasePagamentos
            // 
            this.Controls.Add(this.quadroErros);
            this.Name = "BasePagamentos";
            this.Size = new System.Drawing.Size(640, 624);
            this.Controls.SetChildIndex(this.quadroErros, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroErros.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.quadro2.ResumeLayout(false);
            this.quadro3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
            // Tabelas do mysql
            DataSet dataSetMysql, dataSetDbf;

            Apresenta��o.Formul�rios.Aguarde aguarde;

            aguarde = new Apresenta��o.Formul�rios.Aguarde("Recuperando do novo bd para que seja atualizado", 8, "Transpondo banco de dados", "Aguarde enquanto o banco de dados � sincronizado.");
            aguarde.Abrir();
            dataSetMysql = new DataSet();
            List<IDbConnection> conex�esRemovidas = new List<IDbConnection>();
            MySQL.AdicionarTabelaAoDataSet(dataSetMysql, "pessoa", conex�esRemovidas); aguarde.Passo();
            MySQL.AdicionarTabelaAoDataSet(dataSetMysql, "pagamento", conex�esRemovidas); aguarde.Passo();
            MySQL.AdicionarTabelaAoDataSet(dataSetMysql, "cheque", conex�esRemovidas); aguarde.Passo();
            MySQL.AdicionarTabelaAoDataSet(dataSetMysql, "dinheiro", conex�esRemovidas); aguarde.Passo();
            MySQL.AdicionarTabelaAoDataSet(dataSetMysql, "notapromissoria", conex�esRemovidas); aguarde.Passo();
            MySQL.AdicionarTabelaAoDataSet(dataSetMysql, "venda", conex�esRemovidas); aguarde.Passo();
            //MySql.AdicionarTabelaAoDataSet(dataSetMysql, "vinculovendapagamento"); aguarde.Passo();

            aguarde.Passo("Lendo DBF"); aguarde.Refresh();
            Dbf dbf = new Dbf(diret�rio);

            dataSetDbf = new DataSet();
            dbf.AdicionarTabelaAoDataSet(dataSetDbf, "vendcli");

            Transpor(dataSetDbf, dataSetMysql);

            aguarde.Close();

            Apresenta��o.Formul�rios.AguardeDB.Mostrar();

            MySQL.GravarDataSetTodasTabelas(dataSetMysql);
            MySQL.AdicionarConex�esRemovidas(conex�esRemovidas);
            Apresenta��o.Formul�rios.AguardeDB.Fechar();
            System.Windows.Forms.MessageBox.Show(this, "Opera��o bem sucedida", "fim", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private static void Transpor(DataSet dbf, DataSet mysql)
        {
            List<Pagamento> pagamentoLst = new List<Pagamento>();

            foreach (DataRow i in dbf.Tables[0].Rows)
            {
                long cliente = -1;

                try { long.Parse(i["CL_COD"].ToString()); }
                catch (Exception) { cliente = -1; }

                long venda = -1000001;
                try { venda = long.Parse(i["CL_VEND"].ToString()) + 1000000; }
                catch (Exception) { } 

                DateTime data, datac;
                
                try
                { data = DateTime.Parse(i["CL_DATA"].ToString());  }
                catch (Exception)
                { data = DateTime.MinValue; }

                try
                { datac = DateTime.Parse(i["CL_DATAC"].ToString()); }
                catch (Exception)
                { datac = DateTime.MinValue; }


                double valor = 0;
                try { valor = double.Parse(i["CL_VALOR"].ToString()); }
                catch (Exception) { } 
                
                string descri��o = i["CL_DESCPG"].ToString();
                Pagamento p;

                if (valor != 0 && Vendas.Venda.ExisteVenda(venda, mysql))
                {
                    DataRow vendaDataRow = Vendas.Venda.ObterVenda(venda);

                    cliente = long.Parse(vendaDataRow["cliente"].ToString());

                    p = new Pagamento(Pagamento.ReconhecerTipo(descri��o),
                        cliente, valor, data, datac);

                    pagamentoLst.Add(p);
                }
                

            }

            // Grava o novo:
            foreach (Pagamento p in pagamentoLst)
                p.Gravar(mysql);
        }
    }
}

