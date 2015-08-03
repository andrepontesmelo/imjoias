using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negócio;
using Apresentação.Formulários;
using System.Collections;
using Entidades.Mercadoria;
using Entidades;
using Entidades.Pessoa;

namespace Apresentação.Financeiro
{
    public partial class PesquisaMercadoria : Apresentação.Formulários.JanelaExplicativa
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

        private void btnPesqusiar_Click(object sender, EventArgs e)
        {
            PesquisaMercadoriaResultado resultado;
            Entidades.Mercadoria.Mercadoria[] mercadorias;

            UseWaitCursor = true;

            using (Aguarde aguarde = new Aguarde("Pesquisando...", 4))
            {
                aguarde.Abrir();

                using (ControlePesquisaMercadoria controle = new ControlePesquisaMercadoria(cmbTabela.Seleção))
                {
                    aguarde.Passo();

                    if (txtValorMáximo.Double > 0 && txtCotação.Cotação != null)
                    {
                        controle.FiltrarÍndice(txtValorMáximo.Double / txtCotação.Cotação.Valor);
                    }

                    aguarde.Passo();
                    if (chkTipo.CheckedItems.Count > 0)
                        controle.FiltrarTipos((MercadoriaTipo[])(new ArrayList(chkTipo.CheckedItems).ToArray(typeof(MercadoriaTipo))));

                    aguarde.Passo();
                    if (chkMetal.CheckedItems.Count > 0)
                        controle.FiltrarMetais((Metal[])(new ArrayList(chkMetal.CheckedItems).ToArray(typeof(Metal))));

                    aguarde.Passo();
                    if (chkPedras.CheckedItems.Count > 0)
                        controle.FiltrarPedras((Pedra[])(new ArrayList(chkPedras.CheckedItems).ToArray(typeof(Pedra))));

                    aguarde.Passo();

                    mercadorias = controle.ObterMercadorias().ToArray();
                }
            }

            resultado = new PesquisaMercadoriaResultado(mercadorias, cmbTabela.Seleção, txtCotação.Cotação);
            DialogResult = DialogResult.OK;
            Close();
            resultado.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisaMercadoria_Load(object sender, EventArgs e)
        {
            Tabela[] tabelas = Tabela.ObterTabelas(Funcionário.FuncionárioAtual.Setor);

            if (tabelas.Length == 0)
                cmbTabela.Seleção = Tabela.TabelaPadrão;
            else
                cmbTabela.Seleção = tabelas[0];
        }
    }
}
