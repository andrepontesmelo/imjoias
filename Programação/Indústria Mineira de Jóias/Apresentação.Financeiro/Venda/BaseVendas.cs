using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using Apresentação.Impressão.Relatórios.Venda;
using Apresentação.Impressão;
using Apresentação.Formulários.Impressão;
using Entidades.Acerto;
using Apresentação.Financeiro.Acerto;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Venda
{
    public partial class BaseVendas : Apresentação.Formulários.BaseInferior
    {
        private Entidades.Pessoa.Pessoa pessoa;

        /// <summary>
        /// Forçar tratar a pessoa seleciona como cliente.
        /// Mostra compras dela ao invés de vendas.
        /// </summary>
        private bool forçarTrataloCliente = false;

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
            //AtualizarLabelIntervalo();
        }
    
        private void MudarLeiaute(bool cliente)
        {
            if (cliente)
            {
                quadroLista.Título = título.Título = "Histórico de compras";
                opçãoProcurar.Descrição = "Procurar compra...";
                opçãoRegistrarNovaVenda.Descrição = "Registrar nova compra...";
                lista.ApenasNãoAcertado = false;
            }
            else
            {
                quadroLista.Título = título.Título = "Histórico de vendas";
                opçãoProcurar.Descrição = "Procurar por venda...";
                opçãoRegistrarNovaVenda.Descrição = "Registrar nova venda...";
                lista.ApenasNãoAcertado = true;
                quadroComprasDesteFuncionário.Visible = true;
            }
        }


        public BaseVendas(Entidades.Pessoa.Pessoa pessoa) : this()
        {
            this.pessoa = pessoa;
            título.Descrição = pessoa.Nome;

            MudarLeiaute(Entidades.Pessoa.Pessoa.ÉCliente(pessoa));
            título.Descrição = pessoa.Nome;
        }

        //private void lista_HandleCreated(object sender, EventArgs args)
        //{
        //    lista.AbrirParalelo(pessoa, dataInício, dataFim);
        //}

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
            catch
            {
                MessageBox.Show("Operação cancelada", "Operação cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                System.Windows.Forms.Cursor.Current = Cursors.AppStarting;

                UseWaitCursor = true;
                Apresentação.Formulários.AguardeDB.Mostrar();

                Application.DoEvents();

                baseEditarVenda = new BaseEditarVenda();
                baseEditarVenda.Abrir(Entidades.Relacionamento.Venda.Venda.ObterVenda(códigoVenda.Value));

                SubstituirBase(baseEditarVenda);

                System.Windows.Forms.Cursor.Current = Cursors.Default;

                Apresentação.Formulários.AguardeDB.Fechar();
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
                //AtualizarLabelIntervalo();

                //lista.Carregar(pessoa, dataInício, dataFim);
                lista.Carregar(pessoa, forçarTrataloCliente);
            }

            janela.Close();
            janela.Dispose();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            // Recarrega lista, pois pode ter sido modificada.
            //lista.Carregar(pessoa, dataInício, dataFim);
            lista.Carregar(pessoa, forçarTrataloCliente);
        }

        private void opçãoImpressão_Click(object sender, EventArgs e)
        {
            //Apresentação.Financeiro.Impressão janela;

            UseWaitCursor = true;
            
            List<IDadosVenda> listaDocumentos = lista.ObterVendasMarcadas();

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

            using (RequisitarImpressão dlg = new RequisitarImpressão(TipoDocumento.Venda))
            {
                dlg.PermitirEscolherPágina = listaDocumentos.Count == 1;

                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    FilaImpressão fila = FilaImpressão.ObterFila(dlg.ControleImpressão, dlg.Impressora);
                    ulong[] códigos = new ulong[listaDocumentos.Count];

                    for (int i = 0; i < listaDocumentos.Count; i++)
                        códigos[i] = (ulong)listaDocumentos[i].Código;

                    fila.Imprimir(códigos, dlg.NúmeroCópias);
                }
            }
    
            //using (Apresentação.Formulários.Aguarde janelaAguarde = new Apresentação.Formulários.Aguarde("Preparando impressão", listaDocumentos.Count, "Preparando impressão", "As vendas estão sendo obtidas do banco de dados e os dados estão sendo posicionados."))
            //{
            //    janelaAguarde.Abrir();

            //    janela = new Apresentação.Financeiro.Impressão();
            //    janela.Título = "Impressão";
            //    janela.Descrição = "O(s) documento(s) não poderão ser modificados após a impressão.";

            //    foreach (IDadosVenda v in listaDocumentos)
            //    {
            //        janelaAguarde.Passo("Obtendo " + v.ToString());

            //        Relatório relatório = new Relatório();

            //        Entidades.Relacionamento.Venda.Venda venda;

            //        if (v is Entidades.Relacionamento.Venda.Venda)
            //            venda = (Entidades.Relacionamento.Venda.Venda)v;
            //        else
            //            venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(v.Código);

            //        relatório.SetDataSource(venda.ObterImpressão());

            //        janela.InserirDocumento(relatório, venda.ToString(), venda);
            //    }

            //    janelaAguarde.Close();
            //}

            UseWaitCursor = false;

            //janela.Abrir(this);
        }

        private void opçãoMoverAcerto_Click(object sender, EventArgs e)
        {
            if (lista.ObterVendasMarcadas().Count == 0)
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
                MessageBox.Show(
                    ParentForm,
                    "Operação cancelada.",
                    "Mover para outro acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    foreach (IDadosVenda iVenda in lista.ObterVendasMarcadas())
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
            forçarTrataloCliente = true;
            quadroComprasDesteFuncionário.Visible = false;
            lista.Carregar(pessoa, forçarTrataloCliente);
            MudarLeiaute(true);
            AguardeDB.Fechar(); 
        }

        private void opçãoExcluirVendas_Click(object sender, EventArgs e)
        {

            List<IDadosVenda> colecao = lista.ItensSelecionado;
            string vendasDescadastradas = "";
            string vendasNãoDescadastradas = "";
            string vendasCodigo = "";

            if (colecao.Count == 0)
                return;

            foreach (IDadosVenda item in colecao)
            {
                vendasCodigo += item.Código.ToString() + "  ";
            }

            if (MessageBox.Show("Deseja apagar as vendas de código " + vendasCodigo + " ? ", "Apagar várias vendas", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;


            Apresentação.Formulários.AguardeDB.Mostrar();


            foreach (IDadosVenda item in colecao)
            {
                try
                {
                    Entidades.Relacionamento.Venda.Venda v = Entidades.Relacionamento.Venda.Venda.ObterVenda(item.Código);
                    v.Descadastrar();
                    vendasDescadastradas += v.Código + ",";
                }
                catch (Exception erro)
                {
                    vendasNãoDescadastradas += item.Código.ToString() + ",";
                }
            }

            lista.Carregar(pessoa, forçarTrataloCliente);

            Apresentação.Formulários.AguardeDB.Fechar();

            if (vendasNãoDescadastradas == "")
                MessageBox.Show("Todas as vendas selecionadas foram excluídas.", "Fim da exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Vendas descadastrada: " + vendasDescadastradas + "\n\n\nVendas não descadastradas:" + vendasNãoDescadastradas, "Nem todas foram excluídas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

