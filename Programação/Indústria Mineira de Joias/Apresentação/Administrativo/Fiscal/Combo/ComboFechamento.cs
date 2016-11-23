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

        ConfiguraçãoUsuário<int?> fechamentoEmUso;

        public ComboFechamento()
        {
            InitializeComponent();
            cmb.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            if (DadosGlobais.ModoDesenho)
                return;

            fechamentoEmUso = new ConfiguraçãoUsuário<int?>("fechamentoEmUso", null);
        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fechamento seleção = Seleção as Fechamento;
            fechamentoEmUso.Valor = seleção?.Código;

            SelectedIndexChanged?.Invoke(sender, e);
        }

        public object Seleção => cmb.SelectedItem;

        public void Carregar()
        {
            CarregarItens(Fechamento.Obter());

            foreach (Fechamento f in cmb.Items)
                if (f.Código.Equals(fechamentoEmUso.Valor))
                {
                    cmb.SelectedValue = f;
                    return;
                }
        }

        private void CarregarItens(List<Fechamento> entidades)
        {
            cmb.Items.Clear();
            cmb.Items.AddRange(entidades.ToArray());
        }
    }
}
