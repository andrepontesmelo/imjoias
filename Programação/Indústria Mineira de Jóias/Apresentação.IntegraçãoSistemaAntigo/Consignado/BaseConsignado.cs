using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Apresentação.IntegraçãoSistemaAntigo.Consignado
{
    public class BaseConsignado : Apresentação.Formulários.BaseInferior
    {
        private System.ComponentModel.IContainer components = null;

        //Variáveis 
        private DataSet dsVelho = new DataSet();
        private Apresentação.Formulários.Quadro quadroErros;
        private Apresentação.Formulários.Quadro quadro1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aaa;
        private Apresentação.Formulários.Quadro quadro2;
        private System.Windows.Forms.Label label2;
        private Apresentação.Formulários.Quadro quadro3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstErros;
        private string diretório = @"c:\fox\";

        public BaseConsignado()
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
            this.quadroErros = new Apresentação.Formulários.Quadro();
            this.lstErros = new System.Windows.Forms.ListBox();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.aaa = new System.Windows.Forms.Button();
            this.quadro2 = new Apresentação.Formulários.Quadro();
            this.label2 = new System.Windows.Forms.Label();
            this.quadro3 = new Apresentação.Formulários.Quadro();
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
            this.quadroErros.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroErros.LetraTítulo = System.Drawing.Color.White;
            this.quadroErros.Location = new System.Drawing.Point(193, 16);
            this.quadroErros.MostrarBotãoMinMax = false;
            this.quadroErros.Name = "quadroErros";
            this.quadroErros.Size = new System.Drawing.Size(440, 605);
            this.quadroErros.TabIndex = 8;
            this.quadroErros.Tamanho = 30;
            this.quadroErros.Título = "O sistema é transposto idependentemente dos erros mostrados abaixo";
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
            this.label1.Text = "consig.dbf";
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
            this.label3.Location = new System.Drawing.Point(25, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 43);
            this.label3.TabIndex = 1;
            this.label3.Text = "consig.dbf (saidas e retornos)";
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
            // BaseConsignado
            // 
            this.Controls.Add(this.quadroErros);
            this.Name = "BaseConsignado";
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

            Apresentação.Formulários.Aguarde aguarde;

            aguarde = new Apresentação.Formulários.Aguarde("Recuperando mysql... ", 7, "Transpondo banco de dados", "Aguarde enquanto o banco de dados é sincronizado.");
            aguarde.Abrir();
            dataSetMysql = new DataSet();
            MySql.AdicionarTabelaAoDataSet(dataSetMysql, "pessoa"); aguarde.Passo();
            MySql.AdicionarTabelaAoDataSet(dataSetMysql, "saida"); aguarde.Passo();
            MySql.AdicionarTabelaAoDataSet(dataSetMysql, "saidaitem"); aguarde.Passo();
            MySql.AdicionarTabelaAoDataSet(dataSetMysql, "retorno"); aguarde.Passo();
            MySql.AdicionarTabelaAoDataSet(dataSetMysql, "retornoitem"); aguarde.Passo();

            aguarde.Passo("Obtendo pagamentos do dbf"); aguarde.Refresh();
            Dbf dbf = new Dbf(diretório);

            dataSetDbf = new DataSet();
            dbf.AdicionarTabelaAoDataSet(dataSetDbf, "consig");
            
            Transpor(dataSetMysql, dataSetDbf);

            aguarde.Close();

            Apresentação.Formulários.AguardeDB.Mostrar();

            //try
            //{
                MySql.GravarDataSetTodasTabelas(dataSetMysql);
                Apresentação.Formulários.AguardeDB.Fechar();
                System.Windows.Forms.MessageBox.Show(this, "Operação bem sucedida", "fim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception erro)
            //{
            //    if (erro.Message == "#23000Cannot add or update a child row: a foreign key constraint fails")
            //        MessageBox.Show("O banco-de-dados relatou uma inconsistência de chave extrangeira: " + erro.Message.ToString() + " Nada foi atualizado.");
            //    else
            //        MessageBox.Show("Erro relatado pelo banco-de-dados: " + erro.Message.ToString() + " nada foi atualizado.");

            //    System.Windows.Forms.MessageBox.Show(this, "Operação cancelada", "fim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
                Apresentação.Formulários.AguardeDB.Fechar();
            //}
        }

        private void Transpor(DataSet dsMysql, DataSet dsDBF)
        {
            Dictionary<long, Saida> saidas = new Dictionary<long, Saida>();
            List<Saida> saidaLst = new List<Saida>();

            Dictionary<long, Retorno> retornos = new Dictionary<long, Retorno>();
            List<Retorno> retornoLst = new List<Retorno>();

            foreach (DataRow i in dsDBF.Tables[0].Rows)
            {
                long codigo = long.Parse(i["CO_PEDIDO"].ToString()) + 1000000;
                long cliente = long.Parse(i["CO_CODCLI"].ToString());
                DateTime data = DateTime.Parse(i["CO_DATA"].ToString());
                Saida s;

                if (MySql.ExisteCliente(cliente, dsMysql)
                    && !Saida.ExisteSaída(codigo, dsMysql))
                {
                    if (!saidas.TryGetValue(codigo, out s))
                    {
                        s = new Saida(codigo, cliente, data);
                        saidas[codigo] = s;
                        saidaLst.Add(s);
                    }

                    s.itens.Add(new SaidaItem(
                        i["CO_CODMER"].ToString(),
                        double.Parse(i["CO_QTD"].ToString()),
                        double.Parse(i["CO_GRAMAS"].ToString()),
                        double.Parse(i["CO_PRECO"].ToString()), codigo)
                        );

                    double qtdVenda = double.Parse(i["CO_VENDA"].ToString());
                    if (qtdVenda != 0)
                    {
                        // Retorno tem mesmo codigo da saida.
                        long códigoRetorno = codigo;
                        if (!Retorno.ExisteRetorno(códigoRetorno, dsMysql))
                        {
                            // Okey, nao existe retorno no mysql (antes de iniciar a transposicao)
                            Retorno retorno = null;

                            // Mas retorno já foi criado?
                            if (!retornos.TryGetValue(códigoRetorno, out retorno))
                            {
                                retorno = new Retorno(códigoRetorno, cliente, data);
                                retornoLst.Add(retorno);
                                retornos[códigoRetorno] = retorno;
                            }

                            // Agora cria item retorno
                            retorno.itens.Add(new RetornoItem(
                                i["CO_CODMER"].ToString(),
                                qtdVenda,
                                double.Parse(i["CO_GRAMAS"].ToString()),
                                double.Parse(i["CO_PRECO"].ToString()), códigoRetorno)
                                );
                        }
                    }
                }
            }

            // Grava o novo:
            foreach (Retorno r in retornoLst)
                r.Gravar(dsMysql);

            // Grava o novo:
            foreach (Saida s in saidaLst)
                s.Gravar(dsMysql);
        }
    }
}

