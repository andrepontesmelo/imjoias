using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using System.Diagnostics;

//[assembly:ExporBotão(Entidades.Privilégio.Permissão.VendasVerificar,
//    "Controle Financeiro",
//    true, typeof(Apresentação.Financeiro.Controle.BaseControleFinanceiro))]

namespace Apresentação.Financeiro.Controle
{
    public partial class BaseControleFinanceiro : BaseInferior
    {
        public BaseControleFinanceiro()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Carregar();
        }

        private void Carregar()
        {
            flow.Controls.Clear();
            progresso.Value = progresso.Minimum;
            sinalizaçãoCarga.Visible = true;
            progresso.Visible = true;
            progresso.BringToFront();

            bgRecuperação.RunWorkerAsync();
        }

        private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Relacionamento.Venda.Venda.ObterPessoasComVendasNãoQuitadas();
                int contador = 0;

                foreach (Entidades.Pessoa.Pessoa pessoa in pessoas)
                {
                    ClienteDívida controle = new ClienteDívida(pessoa);
                    controle.AoClicarPagamento += new ClienteDívida.PagamentoCallback(AoClicarPagamento);
                    controle.AoClicarVenda += new ClienteDívida.VendaCallback(AoClicarVenda);
                    bgRecuperação.ReportProgress((int)Math.Round(pessoas.Count / (double)++contador), controle);
                }
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
                Debug.Fail(erro.ToString());
            }
        }

        void AoClicarVenda(Entidades.Relacionamento.Venda.Venda venda)
        {
            UseWaitCursor = true;

            try
            {
                Apresentação.Financeiro.Venda.BaseEditarVenda baseInferior = new Apresentação.Financeiro.Venda.BaseEditarVenda();
                baseInferior.Abrir(venda);
                SubstituirBase(baseInferior);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        void AoClicarPagamento(Entidades.Pagamentos.Pagamento pagamento)
        {
            if (pagamento.Venda.HasValue)
                AoClicarVenda(Entidades.Relacionamento.Venda.Venda.ObterVenda(pagamento.Venda.Value));

            Apresentação.Financeiro.Pagamento.Cadastro dlg = Apresentação.Financeiro.Pagamento.Cadastro.ConstruirJanelaEdição(pagamento);

            dlg.ShowDialog(ParentForm);
        }

        private void bgRecuperação_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progresso.Value = e.ProgressPercentage;
            flow.Controls.Add((Control)e.UserState);
        }

        private void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sinalizaçãoCarga.Visible = false;
        }
    }
}
