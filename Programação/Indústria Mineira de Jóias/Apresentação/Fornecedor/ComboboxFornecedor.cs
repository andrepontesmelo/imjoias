using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Fornecedor
{
    public partial class ComboboxFornecedor : UserControl
    {
        public ComboboxFornecedor()
        {
            InitializeComponent();
        }

        public void Carregar()
        {
            if (!bg.IsBusy)
                bg.RunWorkerAsync();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Entidades.Fornecedor> fornecedores = Entidades.Fornecedor.ObterFornecedores();

            e.Result = fornecedores;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Entidades.Fornecedor> fornecedores = (List<Entidades.Fornecedor>) e.Result;
            Entidades.Fornecedor[] fornecedoresVetor = fornecedores.ToArray();

            comboBox.Items.Clear();
            comboBox.Items.AddRange(fornecedoresVetor);
        }
    }
}
