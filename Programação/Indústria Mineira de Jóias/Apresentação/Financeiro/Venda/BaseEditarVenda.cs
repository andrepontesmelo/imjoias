using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Impressão.Relatórios.Venda;
using Entidades.Pessoa;
using Entidades.Privilégio;
using Entidades.Configuração;
using Entidades.Acerto;
using System.Collections;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Venda
{
    public partial class BaseEditarVenda : Apresentação.Financeiro.BaseEditarRelacionamento
    {
        protected new Entidades.Relacionamento.RelacionamentoAcerto Relacionamento
        {
            get
            {
                return base.Relacionamento as Entidades.Relacionamento.RelacionamentoAcerto;
            }
        }

        public BaseEditarVenda()
        {
            InitializeComponent();

            DigitaçãoVenda digitação = new DigitaçãoVenda();
            // 
            // digitação
            // 
            digitação.Anchor = base.digitação.Anchor;
            digitação.Dock = base.digitação.Dock;
            digitação.BackColor = System.Drawing.Color.Transparent;
            digitação.Location = base.digitação.Location;
            digitação.Name = "digitação";
            digitação.Size = base.digitação.Size;
            digitação.TabIndex = base.digitação.TabIndex;
            digitação.TipoExibiçãoAtual = Apresentação.Financeiro.DigitaçãoComum.TipoExibição.TipoAgrupado;
            ((DigitaçãoVenda)digitação).Verificador = verificadorMercadoria;
            verificadorMercadoria.SetVerificarMercadoria(digitação, true);
            verificadorMercadoria.SetVerificarMercadoria(digitaçãoDevolução, true);
            digitaçãoDevolução.Verificador = verificadorMercadoria;
            tabItens.Controls.Remove(base.digitação);
            tabItens.Controls.Add(digitação);

            base.digitação = digitação;

            Digitação.MostrarPreço = true;


            ///* Como a base já insere a tab de itens em primeiro,
            // * é necessário reposicionar as tabs:
            // */

            digitaçãoDevolução.PermitirSeleçãoTabela = false;
            digitação.PermitirSeleçãoTabela = false;

            if (this.DesignMode) return;

           
           //this.tabs.Controls.Remove(tabItens);
           //this.tabs.Controls.Remove(tabPagamentos);
           //this.tabs.Controls.Remove(tabDevolução);
           //this.tabs.Controls.Remove(tabDébitos);
           //this.tabs.Controls.Remove(tabObservações);

            this.tabs.SuspendLayout();
            this.tabs.Controls.Clear();
            this.tabs.Controls.AddRange(new Control[] {
                tabVenda, tabItens, tabDébitos, tabCréditos, tabDevolução, tabPagamentos, tabObservações });
            this.tabs.ResumeLayout();
           
           //this.tabs.Controls.Add(tabItens);
           //this.tabs.Controls.Add(tabDébitos);
           //this.tabs.Controls.Add(tabDevolução);
           //this.tabs.Controls.Add(tabPagamentos);
        }

        protected override bool ValidarPermissãoDestravar()
        {
            return Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.VendasDestravar);
        }

        protected override Apresentação.Impressão.TipoDocumento TipoDocumento
        {
            get
            {
                return Apresentação.Impressão.TipoDocumento.Venda;
            }
        }

        /// <summary>
        /// É a primeiro método chamado nesta base inferior.
        /// Deve ser chamado externamente,
        /// Abre as bandejas e inicia observação.
        /// </summary>
        public override void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            Entidades.Relacionamento.Venda.Venda v = (Entidades.Relacionamento.Venda.Venda)relacionamento;

            //Apresentação.Formulários.AguardeDB.Mostrar();

            try
            {
                verificadorMercadoria.Enabled = false;

                Digitação.Cotação = digitaçãoDevolução.Cotação = v.Cotação;
                Digitação.Cotação.Data = digitaçãoDevolução.Cotação.Data = null;

                base.Abrir(v);

                CamposLivres = true;

                // Abre a devolução
                digitaçãoDevolução.Abrir(v.ItensDevolução, v, this);

                // Abre os pagamentos
                listaPagamentos.Venda = v;

                // Abre os dados gerais da venda
                dadosVenda.Abrir(v, this);

                listaDébitos.Abrir(v);
                listaDébitos.InformarBaseEditarVenda(this);
                listaCréditos.Abrir(v);
                listaCréditos.InformarBaseEditarVenda(this);

                MostrarTítulo();

                verificadorMercadoria.Enabled = v.AcertoConsignado != null;
                verificadorMercadoria.Restringir(v.AcertoConsignado);

                v.DepoisDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(DepoisDeCadastrar);
                v.Alterado += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(AoAlterar);

                CamposLivres = false;

                if (!dadosVenda.Enabled)
                    tabs.TabIndex = 1;

                if (v.Vendedor != null && !Representante.ÉRepresentante(v.Vendedor) && !PermissãoFuncionário.ValidarPermissão(Permissão.VendasEditar))
                {
                    if (v.Travado)
                    {
                        dadosVenda.Enabled = false;
                        listaPagamentos.Enabled = false;
                        //txtObservações.ReadOnly = true;
                    }
                    else
                    {
                        tabs.Controls.Remove(tabVenda);
                        tabs.Controls.Remove(tabPagamentos);
                    }
                }

                opçãoCobrançaAutomática.Enabled =
                opçãoGastarCréditosCliente.Enabled = 
                    (v.Cliente != null && (!v.Travado));
                

                //quadroPagamento.Visible = !v.Acertado;

                //txtObservações.Text = v.Observações == null ? "" : v.Observações;
            }
            finally
            {
                Apresentação.Formulários.AguardeDB.Fechar();
            }

            if (v.Itens.Count == 0 && v.Cliente != null)
                try
                {
                    Apresentação.Pessoa.AlertaClassificação.Alertar(v.Cliente, Classificação.TipoAlerta.Venda);
                }
                catch (PermissãoNegada erro)
                {
                    MessageBox.Show(
                        ParentForm,
                        erro.Message,
                        "Permissão negada",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                    AtualizarTravamento(true);
                }

        }

        void AoAlterar(Acesso.Comum.DbManipulação entidade)
        {
            if (entidade == Relacionamento)
            {
                MostrarTítulo();

                //if (!verificadorMercadoria.Enabled && !Relacionamento.Acertado)
                //{
                //    if (dadosVenda.Venda.Vendedor == null && Representante.ÉRepresentante(dadosVenda.Venda.Vendedor))
                //        verificadorMercadoria.Restringir(dadosVenda.Venda.Vendedor);
                //    else
                //        verificadorMercadoria.Restringir(dadosVenda.Venda.Cliente);

                //    verificadorMercadoria.Enabled = true;
                //}
            }
        }

        void DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            if (entidade == Relacionamento)
                MostrarTítulo();

            listaPagamentos.Carregar();
        }

        /// <summary>
        /// Mostra o título na base inferior, conforme dados da venda.
        /// </summary>
        private void MostrarTítulo()
        {
            Entidades.Relacionamento.Venda.Venda v = (Entidades.Relacionamento.Venda.Venda)Relacionamento;

            if (v.Vendedor != null && Entidades.Pessoa.Representante.ÉRepresentante(v.Vendedor))
                título.Título = v.Vendedor.Nome;

            else if (v.Cliente != null)
                título.Título = v.Cliente.Nome;

            else if (v.Vendedor != null)
                título.Título = v.Vendedor.Nome;

            else
                título.Título = "Venda";

            if (v.Cadastrado)
            {
                if (v.Controle.HasValue)
                    título.Descrição = string.Format(
                        "Venda de número {0} (N. Controle: {1})",
                        v.Código, v.Controle.Value);
                else
                    título.Descrição = string.Format(
                        "Venda de número {0}",
                        v.Código);
            }
            else
                título.Descrição = "Venda ainda não cadastrada";

            if (v.Vendedor != null)
                título.Descrição += "\nDe " + Entidades.Pessoa.Pessoa.ReduzirNome(v.Vendedor.Nome);

            if (v.Cliente != null)
                título.Descrição += " para " + v.Cliente.Nome;
        }

        protected override void AtualizarTravamento(bool entidadeTravada)
        {
            base.AtualizarTravamento(entidadeTravada);

            Entidades.Relacionamento.Venda.Venda v = (Entidades.Relacionamento.Venda.Venda)Relacionamento;

            if (v.DentroDeComissão)
            {
                quadroTravamento.Título = "Comissão Fechada";
                lblTravamento.Text = "Este documento não pode ser alterado nem excluído uma vez que já está com a comissão fechada.";
                opçãoDestravar.Visible = false;
            }
            digitaçãoDevolução.AtualizarTravamento(entidadeTravada);
            dadosVenda.AtualizarTravamento(entidadeTravada);
            //listaPagamentos.AtualizarTravamento(entidadeTravada);
            
            opçãoCobrançaAutomática.Enabled =
                opçãoGastarCréditosCliente.Enabled = 
            (Relacionamento.Pessoa != null && (!entidadeTravada));
        }

        //protected override Apresentação.Formulários.JanelaImpressão CriarJanelaImpressão()
        //{
        //    /*
        //    UseWaitCursor = true;
        //    Apresentação.Formulários.AguardeDB.Mostrar();
        //    Application.DoEvents();

        //    Impressão.JanelaImpressãoVenda janela = new Impressão.JanelaImpressãoVenda((Entidades.Relacionamento.Venda.Venda)base.Relacionamento);

        //    Apresentação.Formulários.AguardeDB.Fechar();
        //    UseWaitCursor = false;

        //    return janela;
        //     */
        //    return null;
        //}

        /// <summary>
        /// Abre a base para digitação de nova venda.
        /// A pessoa serve para preparar a base, preenchendo automaticamente
        /// os campos cliente e/ou vendedor.
        /// </summary>
        public void PrepararNovaVenda(Entidades.Pessoa.Pessoa pessoa)
        {
            Entidades.Pessoa.Pessoa cliente, vendedor;
            Entidades.Relacionamento.Venda.Venda venda;

            if (Entidades.Pessoa.Funcionário.ÉVendedor(pessoa))
            {
                // Excessão ao caso padrão. Se a pessoa selecionada é da empresa, então será
                // digitado uma venda desta pessoa para algum cliente qualquer.
                vendedor = pessoa;
                cliente = null;
            }
            else
            {
                // Caso padrão. Vendendor é o funcionário e cliente é aquele que foi selecionado.
                vendedor = Entidades.Pessoa.Funcionário.FuncionárioAtual;
                cliente = pessoa;
            }

            venda = Entidades.Relacionamento.Venda.Venda.CriarNovaVenda(cliente, vendedor);

            // Todas as vendas de representante tem acerto
            if (venda.AcertoConsignado == null && Entidades.Pessoa.Representante.ÉRepresentante(pessoa))
            {
                AcertoConsignado acerto = Apresentação.Financeiro.Acerto.EscolherAcerto.QuestionarUsuário(ParentForm, pessoa, false);
                
                if (acerto == null)
                    MessageBox.Show(
                        ParentForm,
                        "Venda de representante normalmente está vinculada a algum acerto. Por favor, defina o acerto.",
                        "Venda de representante",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    acerto.Adicionar(venda);
            }

            // Todas as vendas de varejo tem acerto
            if (venda.AcertoConsignado == null && pessoa.Setor == Entidades.Setor.ObterSetor(Entidades.Setor.SetorSistema.Varejo))
            {
                AcertoConsignado acerto = 
                    Apresentação.Financeiro.Acerto.EscolherAcerto.QuestionarUsuário(ParentForm, Entidades.Pessoa.Pessoa.Varejo, false);

                if (acerto == null)
                    MessageBox.Show(
                        ParentForm,
                        "Venda de varejo normalmente está vinculada a algum acerto. Por favor, defina o acerto.",
                        "Venda de varejo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    acerto.Adicionar(venda);
            }

            Abrir(venda);
        }

        private void dadosVenda_CotaçãoAlterada(Entidades.Cotação cotação)
        {
            // Neste ponto a nova cotação já foi gravada no bd.

            // Atualiza as duas bandejas com a nova cotação.
            digitaçãoDevolução.Cotação = Digitação.Cotação = cotação;
            listaPagamentos.Carregar();
        }

        protected override void AlternarBandeja(object sender, EventArgs e)
        {
            base.AlternarBandeja(sender, e);

            if (optAgrupado.Checked)
                digitaçãoDevolução.TipoExibiçãoAtual = DigitaçãoComum.TipoExibição.TipoAgrupado;
            else
                digitaçãoDevolução.TipoExibiçãoAtual = DigitaçãoComum.TipoExibição.TipoHistórico;

        }

        private void dadosVenda_AoAlterarVendedor(object sender, EventArgs e)
        {
            //if (verificadorMercadoria.Enabled && (dadosVenda.Venda.Vendedor != null && Representante.ÉRepresentante(dadosVenda.Venda.Vendedor)))
            //    verificadorMercadoria.Restringir(dadosVenda.Venda.Vendedor);
        }

        void dadosVenda_AoAlterarCliente(object sender, System.EventArgs e)
        {
            listaPagamentos.Venda = dadosVenda.Venda;

            //if (verificadorMercadoria.Enabled && (dadosVenda.Venda.Vendedor == null || !Representante.ÉRepresentante(dadosVenda.Venda.Vendedor)))
            //    verificadorMercadoria.Restringir(dadosVenda.Venda.Cliente);

            opçãoCobrançaAutomática.Enabled =
                opçãoGastarCréditosCliente.Enabled = 
            (Relacionamento.Pessoa != null && (!dadosVenda.Venda.Travado));
        }

        public void MostrarItens()
        {
            tabs.TabIndex = 1;
        }

        private void opçãoFormaPagamento_Click(object sender, EventArgs e)
        {
            using (JanelaCriarPagamentos dlg = new JanelaCriarPagamentos((Entidades.Relacionamento.Venda.Venda)Relacionamento))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    //quadroPagamento.Visible = false;

                    dadosVenda.MostrarPreços();
                    listaPagamentos.Carregar();

                    if (!tabs.Controls.Contains(tabPagamentos))
                        tabs.Controls.Add(tabPagamentos);
                }
            }
        }

        private void dadosVenda_AoAlterarAcerto(object sender, EventArgs e)
        {
            verificadorMercadoria.Restringir(Relacionamento.AcertoConsignado);
            verificadorMercadoria.Enabled = Relacionamento.AcertoConsignado != null;            
        }


        private void dadosVenda_AoAlterarTabela(object sender, EventArgs e)
        {
            //digitação.Tabela = ((Entidades.Relacionamento.Venda.Venda)Relacionamento).TabelaPreço;
        }

        void dadosVenda_AoAlterarDataVenda(object sender, System.EventArgs e)
        {
            listaCréditos.DataDaVendaFoiAtualizada(dadosVenda.Venda.Data);
            listaDébitos.DataDaVendaFoiAtualizada(dadosVenda.Venda.Data);
        }

        void dadosVenda_AoAlterarDiasSemJuros(object sender, System.EventArgs e)
        {
            listaPagamentos.Carregar();
        }

        private void opçãoCobrançaAutomática_Click(object sender, EventArgs e)
        {
            if (!ConferirTravamento())
            {
                Apresentação.Formulários.AguardeDB.Mostrar();

                Entidades.Pagamentos.Pagamento[] pagamentos =
                    Entidades.Pagamentos.Pagamento.ObterPagamentos(Relacionamento.Pessoa, true);

                tabs.SelectTab(tabDébitos);
                listaDébitos.AdicionarCadastrando(pagamentos);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
            else
                opçãoCobrançaAutomática.Enabled = false;
        }

        private void opçãoGastarCréditosCliente_Click(object sender, EventArgs e)
        {
            if (!ConferirTravamento()) {
                Apresentação.Formulários.AguardeDB.Mostrar();

                List<Entidades.Crédito> créditosNãoUtilizados = Entidades.Crédito.ObterCréditosNãoUtilizados(Relacionamento.Pessoa);

                tabs.SelectTab(tabCréditos);
                listaCréditos.AdicionarCadastrando(créditosNãoUtilizados);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
            else
                opçãoGastarCréditosCliente.Enabled = false;

        }

        protected override void Imprimir()
        {
            AguardeDB.Mostrar();
            Apresentação.Impressão.Relatórios.Venda.ControleImpressãoVenda 
                controle = new ControleImpressãoVenda();

            Apresentação.Impressão.Relatórios.Venda.Relatório relatório = new
                Apresentação.Impressão.Relatórios.Venda.Relatório();

            controle.PrepararImpressãoVenda(relatório, 
                (Entidades.Relacionamento.Venda.Venda) Relacionamento,
                listaPagamentos.ObterPagamentosExibidos()
                );

            PrintDialog printDialog = new PrintDialog();
            AguardeDB.Fechar();
            DialogResult resultado = printDialog.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                try
                {
                    //AguardeDB.Mostrar();
                    relatório.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                    relatório.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ocorreu um erro na impressão. A impressora está ligada? \n" + err.Message, "Erro na impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //AguardeDB.Fechar();
                }
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == tabVenda)
                dadosVenda.MostrarPreços();
        }
    }
}

