using Apresentação.Financeiro.Comissões.Delegate;
using Apresentação.Formulários;
using Entidades.ComissãoCálculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Comissões
{
    public partial class ControleAberturaVenda : UserControl
    {
        public event VendaDelegate AoSolicitarAbrirVenda;
        public event PessoaDelegate AoSolicitarAbrirAtendimentoPessoa;
        public event EventHandler AoSerNecessárioRecarregar;

        private Comissão comissão;
        private DateTime? diaInicial;
        private DateTime? diaFinal;
        private Entidades.Pessoa.Pessoa comissãoPara;
        private bool emAberto;
        private bool estorno;
        private bool carregado = false;

        public ControleAberturaVenda()
        {
            InitializeComponent();
        }

        internal void DefinirLimites(DateTime? diaInicial, DateTime? diaFinal, Entidades.Pessoa.Pessoa comissãoPara, Comissão comissão, bool emAberto, bool estorno)
        {
            this.comissão = comissão;
            this.diaInicial = diaInicial;
            this.diaFinal = diaFinal;
            this.comissãoPara = comissãoPara;
            this.emAberto = emAberto;
            this.estorno = estorno;

            btnAdicionarLançamento.Visible = btnRemoverLançamento.Visible = Comissão.UsuárioPodeManipularComissão;

            Comissão.AssegurarManipulaçãoComissãoPara(comissãoPara);
        }

        public void Carregar()
        {
            lstVendasAbertas.Carregar(diaInicial, diaFinal, comissãoPara, comissão, true, estorno);
            lstVendasFechadas.Carregar(diaInicial, diaFinal, comissãoPara, comissão, false, estorno);
        }

        private void lstVendas_AoSolicitarAbrirVenda(Entidades.Relacionamento.Venda.Venda v)
        {
            if (AoSolicitarAbrirVenda != null)
                AoSolicitarAbrirVenda(v);
        }

        private void lstVendas_AoSolicitarAbrirAtendimentoPessoa(Entidades.Pessoa.Pessoa p)
        {
            if (AoSolicitarAbrirAtendimentoPessoa != null)
                AoSolicitarAbrirAtendimentoPessoa(p);
        }

        private void btnAdicionarLançamento_Click(object sender, EventArgs e)
        {
            List<ComissãoValor> selecionados = lstVendasAbertas.Selecionados;
            if (selecionados.Count == 0)
                return;

            comissão.FecharLançamentos(selecionados, estorno);
            if (AoSerNecessárioRecarregar != null)
                AoSerNecessárioRecarregar(sender, e);
            
            Carregar();
        }

        private void btnRemoverLançamento_Click(object sender, EventArgs e)
        {
            List<ComissãoValor> selecionados = lstVendasFechadas.Selecionados;
            if (selecionados.Count == 0)
                return;

            comissão.AbrirLançamentos(selecionados, estorno);
            if (AoSerNecessárioRecarregar != null)
                AoSerNecessárioRecarregar(sender, e);
            Carregar();
        }

        private void lstVendasAbertas_AoDuploClique(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void lstVendasFechadas_AoDuploCliqueNoVazio(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void ControleAberturaVenda_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible || carregado)
                return;

            Carregar();
            carregado = true;
        }
    }
}
