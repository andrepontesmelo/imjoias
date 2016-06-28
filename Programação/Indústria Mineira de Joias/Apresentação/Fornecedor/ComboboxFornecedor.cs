using System.Collections.Generic;
using System.ComponentModel;
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
            IList<Entidades.Fornecedor> fornecedores = Entidades.Fornecedor.ObterFornecedores();

            e.Result = fornecedores;
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Entidades.Fornecedor> fornecedores = (List<Entidades.Fornecedor>) e.Result;
            Entidades.Fornecedor[] fornecedoresVetor = fornecedores.ToArray();

            comboBox.Items.Clear();
            comboBox.Items.AddRange(fornecedoresVetor);

            if (códigoFornecedorParaSelecionar != 0)
                Selecionar(códigoFornecedorParaSelecionar);
        }

        private ulong códigoFornecedorParaSelecionar = 0;

        internal void Selecionar(ulong códigoFornecedor)
        {
            if (bg.IsBusy)
            {
                códigoFornecedorParaSelecionar = códigoFornecedor;
                return;
            }

            foreach (Entidades.Fornecedor f in comboBox.Items)
            {
                if (f.Código == códigoFornecedor)
                {
                    comboBox.SelectedItem = f;
                    return;
                }
            }

            comboBox.SelectedValue = null;
        }

        public Entidades.Fornecedor Seleção 
        {
            get
            {
                return comboBox.SelectedItem as Entidades.Fornecedor;
            }
        }
    }
}
