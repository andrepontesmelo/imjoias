using Apresentação.Formulário;
using Entidades;
using System;

namespace Apresentação
{
    public partial class ComboSetor : ComboRígido
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

        protected override bool SeleçãoNula => Seleção == null;
    }
}
