using Apresentação.Formulários;
using Entidades;
using Entidades.Mercadoria;
using Entidades.Pessoa;
using Negócio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    public partial class PesquisaMercadoria : JanelaExplicativa
    {
        public PesquisaMercadoria()
        {
            InitializeComponent();

            using (Aguarde aguarde = new Aguarde("Recuperando componentes da mercadoria...", 2))
            {
                aguarde.Abrir();

                chkTipo.Items.AddRange(MercadoriaTipo.ObterTipos());
                aguarde.Passo();

                chkMetal.Items.AddRange(Metal.ObterMetais());
                aguarde.Passo();

                chkPedras.Items.AddRange(Pedra.ObterPedras());
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisaMercadoriaResultado resultado;
            Entidades.Mercadoria.Mercadoria[] mercadorias;

            mercadorias = CarregarMercadorias();

            resultado = new PesquisaMercadoriaResultado(mercadorias, cmbTabela.Seleção, txtCotação.Cotação);

            resultado.ShowDialog(this);
        }

        private Entidades.Mercadoria.Mercadoria[] CarregarMercadorias()
        {
            Entidades.Mercadoria.Mercadoria[] mercadorias;
            UseWaitCursor = true;
            using (Aguarde aguarde = new Aguarde("Pesquisando...", 4))
            {
                aguarde.Abrir();

                using (ControlePesquisaMercadoria controle = new ControlePesquisaMercadoria(cmbTabela.Seleção))
                {
                    Filtrar(aguarde, controle);
                    aguarde.Passo();

                    mercadorias = controle.ObterMercadorias();
                }
            }

            UseWaitCursor = false;
            return mercadorias;
        }

        private void Filtrar(Aguarde aguarde, ControlePesquisaMercadoria controle)
        {
            FiltrarValorMáximo(aguarde, controle);
            FiltrarTipos(aguarde, controle);
            FiltrarMetais(aguarde, controle);
            FiltrarPedras(aguarde, controle);
        }

        private void FiltrarPedras(Aguarde aguarde, ControlePesquisaMercadoria controle)
        {
            aguarde.Passo();
            if (chkPedras.CheckedItems.Count > 0)
                controle.FiltrarPedras((Pedra[])(new ArrayList(chkPedras.CheckedItems).ToArray(typeof(Pedra))));
        }

        private void FiltrarMetais(Aguarde aguarde, ControlePesquisaMercadoria controle)
        {
            aguarde.Passo();
            if (chkMetal.CheckedItems.Count > 0)
                controle.FiltrarMetais((Metal[])(new ArrayList(chkMetal.CheckedItems).ToArray(typeof(Metal))));
        }

        private void FiltrarTipos(Aguarde aguarde, ControlePesquisaMercadoria controle)
        {
            aguarde.Passo();
            if (chkTipo.CheckedItems.Count > 0)
                controle.FiltrarTipos((MercadoriaTipo[])(new ArrayList(chkTipo.CheckedItems).ToArray(typeof(MercadoriaTipo))));
        }

        private void FiltrarValorMáximo(Aguarde aguarde, ControlePesquisaMercadoria controle)
        {
            aguarde.Passo();
            if (txtValorMáximo.Double > 0 && txtCotação.Cotação != null)
                controle.FiltrarÍndice(txtValorMáximo.Double / txtCotação.Cotação.Valor);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisaMercadoria_Load(object sender, EventArgs e)
        {
            List<Tabela> tabelas = Tabela.ObterTabelas(Funcionário.FuncionárioAtual.Setor);

            if (tabelas.Count == 0)
                cmbTabela.Seleção = Tabela.TabelaPadrão;
            else
                cmbTabela.Seleção = tabelas[0];
        }
    }
}
