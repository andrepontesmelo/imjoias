using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using System.Data.Common;
using Apresentação.Pessoa;

namespace Apresentação.Atendimento.Clientes.Importação
{
    public partial class EscolherClienteAntigo : JanelaExplicativa
    {
        public EscolherClienteAntigo()
        {
            InitializeComponent();

            FormatadorNome.CarregarConstantes();

            try
            {
                IDbConnection conexão = Acesso.Comum.Usuários.UsuárioAtual.Conexão;

                AguardeDB.Mostrar();

                lock (conexão)
                {
                    using (DbDataAdapter adaptador = Acesso.Comum.Usuários.UsuárioAtual.CriarAdaptadorDados(
                        conexão, "SELECT cod AS Codigo, nome as Nome FROM cadcli where mapeamento is null"))
                    {
                        adaptador.Fill(codNome, "CodNome");
                    }
                }
            }
            
            finally
            {
                AguardeDB.Fechar();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnImportar.Enabled = dataGridView1.SelectedRows.Count == 1;
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            btnImportar.Enabled = dataGridView1.SelectedRows.Count == 1;
        }

        public long Código
        {
            get
            {
                //return (long)dataGridView1.SelectedRows[0].Cells["Codigo"].Value;
                return long.Parse(txtCódigo.Text);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            txtCódigo.Text = ((DataGridView)sender).CurrentRow.Cells["Codigo"].Value.ToString();
        }
   }
}