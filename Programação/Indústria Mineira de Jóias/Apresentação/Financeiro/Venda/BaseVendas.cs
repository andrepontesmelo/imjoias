using Apresenta��o.Financeiro.Acerto;
using Apresenta��o.Formul�rios;
using Apresenta��o.Formul�rios.Impress�o;
using Apresenta��o.Impress�o;
using Entidades.Acerto;
using Entidades.Relacionamento.Venda;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro.Venda
{
    public partial class BaseVendas : Apresenta��o.Formul�rios.BaseInferior
    {
        private Entidades.Pessoa.Pessoa pessoa;
        
        private long? �ltimoItemSelecionado;
        private List<IDadosVenda> �ltimosItensChecados;

        /// <summary>
        /// For�ar tratar a pessoa seleciona como cliente.
        /// Mostra compras dela ao inv�s de vendas.
        /// </summary>
        private bool for�arHist�ricoCompras = false;

        /// <summary>
        /// Datas que delimitam a exibi��o das vendas
        /// </summary>
        private DateTime dataIn�cio, dataFim;

        public BaseVendas()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            // Define e exibe o intervalo padr�o:
            TimeSpan umAno = TimeSpan.FromDays(365);
            dataIn�cio = DateTime.Now - umAno;
            dataFim = DateTime.Now;
            //AtualizarLabelIntervalo();
        }
    
        private void MudarLeiaute(bool cliente)
        {
            if (cliente || for�arHist�ricoCompras)
            {
                quadroLista.T�tulo = t�tulo.T�tulo = "Hist�rico de compras";
                op��oProcurar.Descri��o = "Procurar compra...";
                op��oRegistrarNovaVenda.Descri��o = "Registrar nova compra...";
                lista.ApenasN�oAcertado = false;
            }
            else
            {
                quadroLista.T�tulo = t�tulo.T�tulo = "Hist�rico de vendas";
                op��oProcurar.Descri��o = "Procurar por venda...";
                op��oRegistrarNovaVenda.Descri��o = "Registrar nova venda...";
                lista.ApenasN�oAcertado = true;
                quadroComprasDesteFuncion�rio.Visible = true;
            }
        }
        
        public BaseVendas(Entidades.Pessoa.Pessoa pessoa)
            : this(pessoa, false)
        {

        }

        public BaseVendas(Entidades.Pessoa.Pessoa pessoa, bool for�arHist�ricoCompras) : this()
        {
            this.pessoa = pessoa;
            t�tulo.Descri��o = pessoa.Nome;
            this.for�arHist�ricoCompras = for�arHist�ricoCompras;

            MudarLeiaute(Entidades.Pessoa.Pessoa.�Cliente(pessoa));
            t�tulo.Descri��o = pessoa.Nome;
        }

        /// <summary>
        /// Ocorre ao clicar em registrar nova venda.
        /// </summary>
        private void op��oRegistrarNovaVenda_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Application.DoEvents();

            BaseEditarVenda baseEditarVenda = new BaseEditarVenda();

            try
            {
                baseEditarVenda.PrepararNovaVenda(pessoa);
                SubstituirBase(baseEditarVenda);
            }
            catch (OperationCanceledException)
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
        private void op��oProcurar_Click(object sender, EventArgs e)
        {
            ProcurarVendas dlg = new ProcurarVendas(Controlador, pessoa);

            dlg.Show(ParentForm);
        }

        private void lista_AoDuploClique(long? c�digoVenda)
        {
            if (c�digoVenda.HasValue)
            {
                BaseEditarVenda baseEditarVenda;

                System.Windows.Forms.Cursor.Current = Cursors.AppStarting;

                UseWaitCursor = true;

                Application.DoEvents();

                baseEditarVenda = new BaseEditarVenda();
                baseEditarVenda.Abrir(Entidades.Relacionamento.Venda.Venda.ObterVenda(c�digoVenda.Value));

                SubstituirBase(baseEditarVenda);

                System.Windows.Forms.Cursor.Current = Cursors.Default;

                UseWaitCursor = false;
            }
        }

        private void optAlterarPer�odo_Click(object sender, EventArgs e)
        {
            JanelaPer�odo janela = new JanelaPer�odo();
            janela.Abrir(dataIn�cio, dataFim);

            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                dataIn�cio = janela.DataIn�cio;
                dataFim = janela.DataFim;
                lista.Carregar(pessoa, for�arHist�ricoCompras);
            }

            janela.Close();
            janela.Dispose();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();
        }

        private void op��oImpress�o_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            
            List<IDadosVenda> listaDocumentos = lista.ObterVendasSelecionadas();

            if (listaDocumentos.Count == 0)
            {
                UseWaitCursor = false;

                MessageBox.Show(
                    ParentForm,
                    "Por favor, selecione antes um documento.",
                    "Visualiza��o de vendas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            using (RequisitarImpress�o dlg = new RequisitarImpress�o(TipoDocumento.Venda))
            {
                dlg.PermitirEscolherP�gina = listaDocumentos.Count == 1;

                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    FilaImpress�o fila = FilaImpress�o.ObterFila(dlg.ControleImpress�o, dlg.Impressora);
                    ulong[] c�digos = new ulong[listaDocumentos.Count];

                    for (int i = 0; i < listaDocumentos.Count; i++)
                        c�digos[i] = (ulong)listaDocumentos[i].C�digo;

                    fila.Imprimir(c�digos, dlg.N�meroC�pias);
                }
            }
    
            UseWaitCursor = false;
        }

        private void op��oMoverAcerto_Click(object sender, EventArgs e)
        {
            if (lista.ObterVendasSelecionadas().Count == 0)
            {
                MessageBox.Show(
                    ParentForm,
                    "Para mover documentos para um acerto, � necess�rio marc�-los primeiro.",
                    "Mover para acerto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AcertoConsignado acerto = EscolherAcerto.QuestionarUsu�rio(ParentForm, pessoa, false);

            if (acerto == null)
            {
                return;
            }
            else if (acerto.Acertado)
                MessageBox.Show(
                    ParentForm,
                    "N�o � permitido mover documentos para um acerto j� encerrado.\n\nOpera��o cancelada.",
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
                            venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(iVenda.C�digo);

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

                    AguardeDB.Suspens�o(true);

                    MessageBox.Show(
                        Parent,
                        string.Format("{0} documentos foram movidos para o acerto {1}.",
                        contador, acerto.C�digo),
                        "Mover para outro acerto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Entidades.Acerto.AcertoConsignado.DocumentoInconsistente erro)
                {
                    AguardeDB.Suspens�o(true);
                    MessageBox.Show(
                        Parent,
                        string.Format("N�o foi poss�vel mover o documento.\n\n{0}", erro.Message),
                        "Mover para outro acerto",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    AguardeDB.Fechar();
                }
            }
        }

        private void op��oComprasDesteFuncion�rio_Click(object sender, EventArgs e)
        {
            AguardeDB.Mostrar();
            for�arHist�ricoCompras = true;
            quadroComprasDesteFuncion�rio.Visible = false;
            lista.Carregar(pessoa, for�arHist�ricoCompras);
            MudarLeiaute(true);
            AguardeDB.Fechar(); 
        }

        private void op��oExcluirVendas_Click(object sender, EventArgs e)
        {

            List<IDadosVenda> colecao = lista.ItensSelecionados;
            string vendasDescadastradas = "";
            string vendasN�oDescadastradas = "";
            StringBuilder vendasCodigo = new StringBuilder();

            if (colecao.Count == 0)
                return;

            foreach (IDadosVenda item in colecao)
            {
                vendasCodigo.Append(item.C�digoFormatado.ToString()).Append("  ");
            }

            if (colecao.Count > 1)
            {
                if (MessageBox.Show("Deseja apagar as vendas de c�digo " + vendasCodigo.ToString() + "? ", "Apagar v�rias vendas", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    != DialogResult.Yes)
                    return;
            } else
            {
                if (MessageBox.Show("Deseja apagar a venda de c�digo " + vendasCodigo.ToString() + "? ", "Apagar uma venda", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    != DialogResult.Yes)
                    return;
            }

            Apresenta��o.Formul�rios.AguardeDB.Mostrar();

            foreach (IDadosVenda item in colecao)
            {
                try
                {
                    Entidades.Relacionamento.Venda.Venda v = Entidades.Relacionamento.Venda.Venda.ObterVenda(item.C�digo);
                    v.Descadastrar();
                    vendasDescadastradas += v.C�digoFormatado + ",";
                }
                catch (Exception)
                {
                    vendasN�oDescadastradas += item.C�digoFormatado.ToString() + ",";
                }
            }

            lista.Carregar(pessoa, for�arHist�ricoCompras);

            Apresenta��o.Formul�rios.AguardeDB.Fechar();

            string ajuda = "Vendas com NF-e emitida e/ou comiss�o paga n�o podem ser exclu�das.";

            if (String.IsNullOrEmpty(vendasN�oDescadastradas))
                MessageBox.Show("Todas as vendas selecionadas foram exclu�das.", "Fim da exclus�o", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (String.IsNullOrEmpty(vendasDescadastradas))
                MessageBox.Show("Nenhuma venda foi exclu�da.\n\n" + ajuda, "N�o foi poss�vel excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Vendas descadastradas: " + vendasDescadastradas + "\n\n\nVendas n�o descadastradas:" + vendasN�oDescadastradas + "\n\n" + ajuda, "Nem todas foram exclu�das", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lista_AoSalvarNfe(object sender, EventArgs e)
        {
            Recarregar();
        }

        private void Recarregar()
        {
            �ltimoItemSelecionado = lista.ItemSelecionado;
            �ltimosItensChecados = lista.ItensSelecionados;
            
            lista.Carregar(pessoa, for�arHist�ricoCompras);
            lista.ItemSelecionado = �ltimoItemSelecionado;
            lista.ItensSelecionados = �ltimosItensChecados;
        }
    }
}