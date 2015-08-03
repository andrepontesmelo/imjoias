using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Controle
{
    public partial class BaseControleFinanceiroPessoal : Apresentação.Formulários.BaseInferior
    {
        Entidades.Pessoa.Pessoa pessoa;
        List<CobrançaItem> itens;

        public BaseControleFinanceiroPessoal()
        {
            InitializeComponent();
        }

        public BaseControleFinanceiroPessoal(Entidades.Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
            InitializeComponent();
        }

        private void BaseControleFinanceiroPessoal_Load(object sender, EventArgs e)
        {

        }

        protected override void AoExibir()
        {
            base.AoExibir();

            itens = new List<CobrançaItem>();

            Entidades.Relacionamento.Venda.Venda[] vendas =
                Entidades.Relacionamento.Venda.Venda.ObterVendas(null, pessoa, DateTime.MinValue, DateTime.MaxValue);

            foreach (Entidades.Relacionamento.Venda.Venda v in vendas)
                itens.Add(new CobrançaItem(v.Data, v.Valor, "Venda " + v.Código.ToString()));

            Entidades.Pagamentos.Pagamento[] pagamentos = Entidades.Pagamentos.Pagamento.ObterPagamentos(pessoa);

            foreach (Entidades.Pagamentos.Pagamento p in pagamentos)
            {
                if (!p.Pendente)
                {
                    itens.Add(new CobrançaItem(p.ÚltimoVencimento, -p.Valor, " Pag. " + p.ToString()));
                }

            }

            itens.Sort();
            double deve = 0;

            lista.Items.Add("Data\t\tValor\t\tCorrigido\t\tDescrição");

            foreach (CobrançaItem i in itens)
            {
                lista.Items.Add(i.Data.ToShortDateString() + "\t" + i.Valor.ToString("R$ 0,000.00") + "\t" + i.ValorCorrigido.ToString("R$ 0,000.00") + "\t" + i.Descrição);

                deve += i.ValorCorrigido;
            }

            lista.Items.Add(" Total... Cliente deve "  + deve.ToString("C"));
        }
    }
}
