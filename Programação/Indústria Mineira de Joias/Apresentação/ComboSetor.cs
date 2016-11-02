using System;
using System.Windows.Forms;
using Entidades;

namespace Apresentação
{
    public partial class ComboSetor : ComboBox
    {
        public ComboSetor()
        {
            InitializeComponent();
        }

        public Setor Seleção
        {
            get { return SelectedItem as Setor; }
            set { SelectedItem = value; }
        }

        public void Carregar(bool atendimento)
        {
            if (!atendimento)
                throw new NotImplementedException();

            Items.AddRange(Entidades.Setor.ObterSetoresAtendimento());
        }

        private void ComboSetor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Seleção == null;
        }
    }
}
