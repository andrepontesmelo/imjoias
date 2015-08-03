using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.ComissãoCálculo;
using Apresentação.Formulários;
using Apresentação.Financeiro.Comissões.Delegate;

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

        public ControleAberturaVenda()
        {
            InitializeComponent();
        }

        internal void Carregar(DateTime? diaInicial, DateTime? diaFinal, Entidades.Pessoa.Pessoa comissãoPara, Comissão comissão, bool emAberto, bool estorno)
        {
            this.comissão = comissão;
            this.diaInicial = diaInicial;
            this.diaFinal = diaFinal;
            this.comissãoPara = comissãoPara;
            this.emAberto = emAberto;
            this.estorno = estorno;

            Recarregar();
        }

        public void Recarregar()
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

            AguardeDB.Mostrar();
            comissão.FecharLançamentos(selecionados, estorno);
            if (AoSerNecessárioRecarregar != null)
                AoSerNecessárioRecarregar(sender, e);
            
            Recarregar();

            AguardeDB.Fechar();
        }

        private void btnRemoverLançamento_Click(object sender, EventArgs e)
        {
            List<ComissãoValor> selecionados = lstVendasFechadas.Selecionados;
            if (selecionados.Count == 0)
                return;

            AguardeDB.Mostrar();
            comissão.AbrirLançamentos(selecionados, estorno);
            if (AoSerNecessárioRecarregar != null)
                AoSerNecessárioRecarregar(sender, e);
            Recarregar();

            AguardeDB.Fechar();
        }

        private void lstVendasAbertas_AoDuploClique(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void lstVendasFechadas_AoDuploCliqueNoVazio(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }
    }
}
