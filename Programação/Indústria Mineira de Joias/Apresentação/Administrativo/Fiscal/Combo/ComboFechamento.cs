using Entidades.Fiscal;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Entidades.Configuração;

namespace Apresentação.Administrativo.Fiscal.Combo
{
    public partial class ComboFechamento : UserControl
    {
        public event EventHandler SelectedIndexChanged;

        ConfiguraçãoUsuário<int> fechamentoEmUso;
        private bool carregando = false;

        public ComboFechamento()
        {
            InitializeComponent();
            cmb.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            if (DadosGlobais.ModoDesenho)
                return;

            fechamentoEmUso = new ConfiguraçãoUsuário<int>("fechamentoEmUso", 0);
        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregando)
                return;

            Fechamento seleção = Seleção as Fechamento;
            fechamentoEmUso.Valor = seleção.Código;

            SelectedIndexChanged?.Invoke(sender, e);
        }

        public object Seleção => cmb.SelectedItem;

        public void Carregar()
        {
            carregando = true;
            CarregarItens(Fechamento.Obter());

            cmb.SelectedItem = Fechamento.Obter(fechamentoEmUso.Valor);

            carregando = false;
        }

        private void CarregarItens(List<Fechamento> entidades)
        {
            cmb.Items.Clear();
            cmb.Items.AddRange(entidades.ToArray());
        }
    }
}
