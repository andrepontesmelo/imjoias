using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Importador
{
    public partial class Acompanhamento : Form
    {
        private volatile Importador importador;
        private Thread thread;
        private bool finalizado = false;

        public Acompanhamento(string origem)
        {
            InitializeComponent();

            thread = new Thread(new ParameterizedThreadStart(Importar));
            thread.IsBackground = true;
            thread.Start(origem);

            txtOrigem.Text = origem;
        }

        private void Importar(object p)
        {
            try
            {
                importador = new Importador((string)p);

                importador.Importar();
            }
            catch (Exception e)
            {
                thread = null;
                MessageBox.Show(e.ToString(),
                    "Importação de CEP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            thread = null;
            finalizado = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "Você tem certeza que deseja cancelar a importação?",
                this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                importador.Cancelar = true;
                Close();
            }
        }

        private void tmrAtualizar_Tick(object sender, EventArgs e)
        {
            if (finalizado)
                Close();

            else if (importador == null)
                lblProgresso.Text = "Iniciando...";

            else if (thread == null)
                lblProgresso.Text = "Thread finalizada";

            else if (progresso.Value == 0)
            {
                progresso.Maximum = importador.QtdLogradouros;
                progresso.Value = importador.QtdImportado;
            }
            else
            {
                progresso.Value = importador.QtdImportado;
                lblProgresso.Text = String.Format("{0} de {1}", progresso.Value, progresso.Maximum);
            }
        }
    }
}
