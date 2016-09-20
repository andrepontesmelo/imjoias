using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Pagamento
{
    public partial class EscolhaVendas : Apresentação.Formulários.JanelaExplicativa
    {
        public EscolhaVendas()
        {
            InitializeComponent();
        }

        public void Abrir(Entidades.Pessoa.Pessoa pessoa)
        {
            lista.Carregar(false, pessoa);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
            
        }

        public List<IDadosVenda> ObterVendasMarcadas()
        {
            return lista.ObterVendasSelecionadas();
        }

        public void Marcar(List<IDadosVenda> vendas)
        {
            lista.SelecionarApenas(vendas);   
        }
    }
}

