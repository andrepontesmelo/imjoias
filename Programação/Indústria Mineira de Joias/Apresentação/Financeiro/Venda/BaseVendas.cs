using Acesso.Comum.Exceções;
using Apresentação.Financeiro.Acerto;
using Apresentação.Formulários;
using Entidades.Acerto;
using Entidades.Relacionamento.Venda;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Apresentação.Impressão.Relatórios.Venda;

namespace Apresentação.Financeiro.Venda
{
    public partial class BaseVendas : BaseInferior
    {
        private Entidades.Pessoa.Pessoa pessoa;
        
        private long? últimoItemSelecionado;
        private List<IDadosVenda> últimosItensChecados;

        /// <summary>
        /// Forçar tratar a pessoa seleciona como cliente.
        /// Mostra compras dela ao invés de vendas.
        /// </summary>
        private bool forçarHistóricoCompras = false;

        /// <summary>
        /// Datas que delimitam a exibição das vendas
        /// </summary>
        private DateTime dataInício, dataFim;

        public BaseVendas()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            // Define e exibe o intervalo padrão:
            TimeSpan umAno = TimeSpan.FromDays(365);
            dataInício = DateTime.Now - umAno;
            dataFim = DateTime.Now;
        }
    
        private void MudarLeiaute(bool cliente)
        {
            if (cliente || forçarHistóricoCompras)
            {
                quadroLista.Título = título.Título = "Histórico de compras";
                opçãoProcurar.Descrição = "Procurar compra...";
                opçãoRegistrarNovaVenda.Descrição = "Registrar nova compra...";
            }
            else
            {
                quadroLista.Título = título.Título = "Histórico de vendas";
                opçãoProcurar.Descrição = "Procurar por venda...";
                opçãoRegistrarNovaVenda.Descrição = "Registrar nova venda...";
                quadroComprasDesteFuncionário.Visible = true;
            }
        }
        
        public BaseVendas(Entidades.Pessoa.Pessoa pessoa)
            : this(pessoa, false)
        {
        }

        public BaseVendas(Entidades.Pessoa.Pessoa pessoa, bool forçarHistóricoCompras) : this()
        {
            this.pessoa = pessoa;
            título.Descrição = pessoa.Nome;
            this.forçarHistóricoCompras = forçarHistóricoCompras;

            MudarLeiaute(Entidades.Pessoa.Pessoa.ÉCliente(pessoa));
            título.Descrição = pessoa.Nome;
        }

        /// <summary>
        /// Ocorre ao clicar em registrar nova venda.
        /// </summary>
        private void opçãoRegistrarNovaVenda_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Application.DoEvents();

            BaseEditarVenda baseEditarVenda = new BaseEditarVenda();

            try
            {
                baseEditarVenda.PrepararNovaVenda(pessoa);
                SubstituirBase(baseEditarVenda);
            }
            catch (OperaçãoCancelada)
            { 
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        /// <summary>
        /// Ocorre ao clicar em procurar por venda.
        /// </summary>
        private void opçãoProcurar_Click(object sender, EventArgs e)
        {
            ProcurarVendas dlg = new ProcurarVendas(Controlador, pessoa);

            dlg.Show(ParentForm);
        }

        private void lista_AoDuploClique(long? códigoVenda)
        {
            if (códigoVenda.HasValue)
            {
                BaseEditarVenda baseEditarVenda;

                Cursor.Current = Cursors.AppStarting;

                UseWaitCursor = true;

                Application.DoEvents();

                baseEditarVenda = new BaseEditarVenda();
                baseEditarVenda.Abrir(Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda.Value));

                SubstituirBase(baseEditarVenda);

                Cursor.Current = Cursors.Default;

                UseWaitCursor = false;
            }
        }

        private void optAlterarPeríodo_Click(object sender, EventArgs e)
        {
            JanelaPeríodo janela = new JanelaPeríodo();
            janela.Abrir(dataInício, dataFim);

            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                dataInício = janela.DataInício;
                dataFim = janela.DataFim;
                lista.Carregar(pessoa, forçarHistóricoCompras);
            }

            janela.Close();
            janela.Dispose();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();
        }

        private void opçãoImpressão_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            List<IDadosVenda> listaDocumentos = lista.ObterVendasSelecionadas();

            if (listaDocumentos.Count == 0)
            {
                UseWaitCursor = false;

                MessageBox.Show(
                    ParentForm,
                    "Por favor, selecione antes um documento.",
                    "Visualização de vendas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            AguardeDB.Mostrar();

            Formulários.JanelaImpressão visualizadorImpressão = CriaJanelaImpressão();

            AguardeDB.Fechar();
            UseWaitCursor = false;

            visualizadorImpressão.Show();
        }

        private Formulários.JanelaImpressão CriaJanelaImpressão()
        {
            Formulários.JanelaImpressão visualizadorImpressão = new Formulários.JanelaImpressão();
            List<ReportClass> relatórios = ObterRelatórios();
            int x = 0;
            foreach (ReportClass relatório in relatórios)
            {
                visualizadorImpressão.InserirDocumento(relatório, lista.ItensSelecionados[x++].ToString());
            }

            return visualizadorImpressão;
        }

        private List<ReportClass> ObterRelatórios()
        {
            List<ReportClass> relatórios = new List<ReportClass>();

            foreach (IDadosVenda v in lista.ItensSelecionados)
            {
                Relatório relatório = new Relatório();
                new ControleImpressãoVenda().PrepararImpressão(relatório, Entidades.Relacionamento.Venda.Venda.ObterVenda(v.Código));

                relatórios.Add(relatório);
            }

            return relatórios;
        }

        private void opçãoMoverAcerto_Click(object sender, EventArgs e)
        {
            if (lista.ObterVendasSelecionadas().Count == 0)
            {
                MessageBox.Show(
                    ParentForm,
                    "Para mover documentos para um acerto, é necessário marcá-los primeiro.",
                    "Mover para acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AcertoConsignado acerto = EscolherAcerto.QuestionarUsuário(ParentForm, pessoa, false);

            if (acerto == null)
            {
                return;
            }
            else if (acerto.Acertado)
                MessageBox.Show(
                    ParentForm,
                    "Não é permitido mover documentos para um acerto já encerrado.\n\nOperação cancelada.",
                    "Mover para outro acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int contador = 0;

                AguardeDB.Mostrar();

                try
                {
                    foreach (IDadosVenda iVenda in lista.ObterVendasSelecionadas())
                    {
                        Entidades.Relacionamento.Venda.Venda venda = iVenda as Entidades.Relacionamento.Venda.Venda;

                        if (venda == null)
                            venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(iVenda.Código);

                        if (venda.AcertoConsignado == null || !venda.AcertoConsignado.Equals(acerto))
                        {
                            if (!acerto.Cadastrado)
                                acerto.Cadastrar();

                            if (venda.AcertoConsignado != null)
                                venda.AcertoConsignado.Remover(venda);

                            acerto.Adicionar(venda);
                            contador++;
                            venda.Atualizar();
                        }
                    }

                    AoExibir();

                    AguardeDB.Suspensão(true);

                    MessageBox.Show(
                        Parent,
                        string.Format("{0} documentos foram movidos para o acerto {1}.",
                        contador, acerto.Código),
                        "Mover para outro acerto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Entidades.Acerto.AcertoConsignado.DocumentoInconsistente erro)
                {
                    AguardeDB.Suspensão(true);
                    MessageBox.Show(
                        Parent,
                        string.Format("Não foi possível mover o documento.\n\n{0}", erro.Message),
                        "Mover para outro acerto",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }

        private void opçãoComprasDesteFuncionário_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            forçarHistóricoCompras = true;
            quadroComprasDesteFuncionário.Visible = false;
            lista.Carregar(pessoa, forçarHistóricoCompras);
            MudarLeiaute(true);
            AguardeDB.Fechar(); 
        }

        private void opçãoExcluirVendas_Click(object sender, EventArgs e)
        {

            List<IDadosVenda> colecao = lista.ItensSelecionados;
            string vendasDescadastradas = "";
            string vendasNãoDescadastradas = "";
            StringBuilder vendasCodigo = new StringBuilder();

            if (colecao.Count == 0)
                return;

            foreach (IDadosVenda item in colecao)
            {
                vendasCodigo.Append(item.CódigoFormatado.ToString()).Append("  ");
            }

            if (colecao.Count > 1)
            {
                if (MessageBox.Show("Deseja apagar as vendas de código " + vendasCodigo.ToString() + "? ", "Apagar várias vendas", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    != DialogResult.Yes)
                    return;
            } else
            {
                if (MessageBox.Show("Deseja apagar a venda de código " + vendasCodigo.ToString() + "? ", "Apagar uma venda", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    != DialogResult.Yes)
                    return;
            }

            AguardeDB.Mostrar();

            foreach (IDadosVenda item in colecao)
            {
                try
                {
                    Entidades.Relacionamento.Venda.Venda v = Entidades.Relacionamento.Venda.Venda.ObterVenda(item.Código);
                    v.Descadastrar();
                    vendasDescadastradas += v.CódigoFormatado + ",";
                }
                catch (Exception)
                {
                    vendasNãoDescadastradas += item.CódigoFormatado.ToString() + ",";
                }
            }

            lista.Carregar(pessoa, forçarHistóricoCompras);

            AguardeDB.Fechar();

            string ajuda = "Vendas com NF-e emitida e/ou comissão paga não podem ser excluídas.";

            if (String.IsNullOrEmpty(vendasNãoDescadastradas))
                MessageBox.Show("Todas as vendas selecionadas foram excluídas.", "Fim da exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (String.IsNullOrEmpty(vendasDescadastradas))
                MessageBox.Show("Nenhuma venda foi excluída.\n\n" + ajuda, "Não foi possível excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Vendas descadastradas: " + vendasDescadastradas + "\n\n\nVendas não descadastradas:" + vendasNãoDescadastradas + "\n\n" + ajuda, "Nem todas foram excluídas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Recarregar()
        {
            últimoItemSelecionado = lista.ItemSelecionado;
            últimosItensChecados = lista.ItensSelecionados;
            
            lista.Carregar(pessoa, forçarHistóricoCompras);
            lista.ItemSelecionado = últimoItemSelecionado;
            lista.ItensSelecionados = últimosItensChecados;
        }
    }
}