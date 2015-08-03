using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using Entidades;
using Apresentação.Financeiro.Venda;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Comissão
{
    public partial class BaseComissão : Apresentação.Formulários.BaseInferior
    {
        private Entidades.Pessoa.Pessoa pessoa;

        public BaseComissão()
        {
            InitializeComponent();
            lista.AoDuploClique += new ListViewVendas.DelegaçãoVenda(lista_AoDuploClique);
        }

        void lista_AoDuploClique(long? códigoVenda)
        {
            if (códigoVenda.HasValue) 
            {
                BaseEditarVenda baseEditarVenda = new BaseEditarVenda();
                baseEditarVenda.Abrir(Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda.Value));
                SubstituirBase(baseEditarVenda);
            }
        }

        public void Carregar(Entidades.Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        protected override void AoExibir()
        {
            base.AoExibir();
            lista.Carregar(true, pessoa);
        }

        protected override void AoCarregarCompletamente(Splash splash)
        {
            base.AoCarregarCompletamente(splash);
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Versão em desenvolvimento", "Protótipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void opçãoEscolherPeríodo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Versão em desenvolvimento", "Protótipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void opçãoCalcular_Click(object sender, EventArgs e)
        {
            if (lista.ItensSelecionado.Count == 0) {
                MessageBox.Show(this, "Favor selecionar alguma venda antes", "Nenhuma venda selecionada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AguardeDB.Mostrar();

            List<int> vendas = new List<int>();

            foreach (IDadosVenda dados in lista.ItensSelecionado)
                vendas.Add((int) dados.Código);

            string texto = ComissaoCalculo.ObterComissao(vendas);

            string arquivo = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            System.IO.File.WriteAllText(arquivo, texto);
            System.Diagnostics.Process.Start("EXCEL.EXE", arquivo);

            AguardeDB.Fechar();
        }
    }
}
