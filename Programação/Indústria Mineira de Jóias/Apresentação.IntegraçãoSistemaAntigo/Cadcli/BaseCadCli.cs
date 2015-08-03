using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using System.Collections;

namespace Apresentação.IntegraçãoSistemaAntigo.Cadcli
{
    public partial class BaseCadCli : BaseInferior
    {
        Hashtable adaptadoresPelaTabela = new Hashtable();

        public BaseCadCli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dbf dbf = new Dbf(txtArquivo.Text);
            DataSet dataSetDbf = new DataSet();
            DataSet dataSetMysql = new DataSet();
            
            AdicionarTabelaAoDataSet(dataSetMysql, "cadcli");

            DataTable tabelaCadCliMysql = dataSetMysql.Tables["cadcli"];

            dbf.AdicionarTabelaAoDataSet(dataSetDbf, "cadcli");

            DataRowCollection coleção = dataSetDbf.Tables["cadcli"].Rows;
            Apresentação.Formulários.Aguarde janelaAguarde = new Aguarde("Transpondo", coleção.Count);
            janelaAguarde.Show();

            foreach (DataRow item in coleção)
            {
                janelaAguarde.Passo();

                DataRow novo;

                novo = tabelaCadCliMysql.NewRow();
                novo["cod"] = item["CL_COD"];
                novo["dig"] = item["CL_DIG"];
                novo["nosso"] = item["CL_NOSSO"];
                novo["nome"] = item["CL_NOME"];
                novo["regiao"] = item["CL_REGIAO"];
                novo["end"] = item["CL_END"];
                novo["bairro"] = item["CL_BAIRRO"];
                novo["cep"] = item["CL_CEP"];
                novo["cid"] = item["CL_CID"];
                novo["uf"] = item["CL_UF"];
                novo["cgc"] = item["CL_CGC"];
                novo["cpf"] = item["CL_CPF"];
                novo["insc"] = item["CL_INSC"];
                novo["endcob"] = item["CL_ENDCOB"];
                novo["cidcob"] = item["CL_CIDCOB"];
                novo["cepcob"] = item["CL_CEPCOB"];
                novo["ufcob"] = item["CL_UFCOB"];
                novo["contato"] = item["CL_CONTATO"];
                novo["fone"] = item["CL_FONE"];
                novo["fax"] = item["CL_FAX"];
                novo["conta"] = item["CL_CONTA"];
                novo["classe"] = item["CL_CLASSE"];
                novo["categor"] = item["CL_CATEGOR"];
                novo["obs"] = item["CL_OBS"].ToString() + "\n" +
                    item["CL_OBS1"].ToString() + "\n" +
                    item["CL_OBS2"].ToString() + "\n" +
                    item["CL_OBS3"].ToString() + "\n" +
                    item["CL_OBS4"].ToString() + "\n" +
                    item["CL_OBS5"].ToString() + "\n" +
                    item["CL_OBS6"].ToString() + "\n" + 
                    item["CL_OBS7"].ToString();

                    
                //novo["obs"] = "retirado no codigo fonte!";
                
                tabelaCadCliMysql.Rows.Add(novo);
            }
            janelaAguarde.Passo("Gravando...");
            GravarDataSet(dataSetMysql, "cadcli");
            janelaAguarde.Close();
            MessageBox.Show("Fim");
        }


        /// <summary>
        /// Usa conexão com mysql
        /// </summary>
        private void AdicionarTabelaAoDataSet(DataSet ds, string tabela)
        {
            System.Data.Common.DbDataAdapter adaptador;

            if (adaptadoresPelaTabela.Contains(tabela))
            {
                adaptador = (System.Data.Common.DbDataAdapter)adaptadoresPelaTabela[tabela];
            }
            else
            {
                adaptador = Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.CriarAdaptadorDados(Apresentação.Formulários.Aplicação.AplicaçãoAtual.Usuário.Conexão, "select * from " + tabela);
                adaptadoresPelaTabela.Add(tabela, adaptador);
            }

            adaptador.Fill(ds, tabela);
        }
        
        public void GravarDataSet(DataSet ds, string tabela)
        {
            System.Data.Common.DbDataAdapter adaptador;
            adaptador = (System.Data.Common.DbDataAdapter)adaptadoresPelaTabela[tabela];

            adaptador.Update(ds, tabela);
        }
    }
}
