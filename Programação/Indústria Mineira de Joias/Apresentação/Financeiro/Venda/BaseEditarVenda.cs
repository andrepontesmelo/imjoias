using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Venda;
using Entidades.Acerto;
using Entidades.Pessoa;
using Entidades.Privilégio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.Relacionamento;

namespace Apresentação.Financeiro.Venda
{
    public partial class BaseEditarVenda : BaseEditarRelacionamento
    {
        protected new RelacionamentoAcerto Relacionamento
        {
            get
            {
                return base.Relacionamento as RelacionamentoAcerto;
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
            digitação.TipoExibiçãoAtual = DigitaçãoComum.TipoExibição.TipoAgrupado;
            digitação.Verificador = verificadorMercadoria;
            verificadorMercadoria.SetVerificarMercadoria(digitação, true);
            verificadorMercadoria.SetVerificarMercadoria(digitaçãoDevolução, true);
            digitaçãoDevolução.Verificador = verificadorMercadoria;
            tabItens.Controls.Remove(base.digitação);
            tabItens.Controls.Add(digitação);

            base.digitação = digitação;

            Digitação.MostrarPreço = true;
            digitaçãoDevolução.PermitirSeleçãoTabela = false;
            digitação.PermitirSeleçãoTabela = false;

            if (DesignMode) return;

            tabs.SuspendLayout();
            tabs.Controls.Clear();
            tabs.Controls.AddRange(new Control[] {
                tabVenda, tabItens, tabDébitos, tabCréditos, tabDevolução, tabPagamentos, tabObservações });
            tabs.ResumeLayout();
           
        }

        protected override bool ValidarPermissãoDestravar()
        {
            return PermissãoFuncionário.ValidarPermissão(Permissão.VendasDestravar);
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

                bool vendaTravada = v.Travado;

                if (v.Vendedor != null && !Representante.ÉRepresentante(v.Vendedor) && !PermissãoFuncionário.ValidarPermissão(Permissão.VendasEditar))
                {
                    if (vendaTravada)
                    {
                        dadosVenda.Enabled = false;
                        listaPagamentos.Enabled = false;
                    }
                    else
                    {
                        tabs.Controls.Remove(tabVenda);
                        tabs.Controls.Remove(tabPagamentos);
                    }
                }

                AtualizarEnabledPuxarDébitosCréditos(vendaTravada);
            }
            finally
            {
                AguardeDB.Fechar();
            }

            if (v.Itens.Count == 0 && v.Cliente != null)
                try
                {
                    Pessoa.AlertaClassificação.Alertar(v.Cliente, Classificação.TipoAlerta.Venda);
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

            CadastrarVendaSeNecessário();
        }

        public override Relacionamento ReobterRelacionamento()
        {
            return Entidades.Relacionamento.Venda.Venda.ObterVenda(Relacionamento.Código);
        }

        void v_AoCancelarCadastro(object sender, EventArgs e)
        {
            MostrarMensagemEntidadeNãoSalva();
        }

        protected override void MostrarMensagemEntidadeNãoSalva()
        {
            MessageBox.Show(this,
                "Venda ainda não foi cadastrada. Verifique se possui cliente.",
                "Ainda não cadastrado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        void AoAlterar(Acesso.Comum.DbManipulação entidade)
        {
            if (entidade == Relacionamento)
                MostrarTítulo();
        }

        void DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            if (entidade == Relacionamento)
                MostrarTítulo();

            AtualizarTravamento(Relacionamento.Travado);   

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
                        "Venda de código {0} (N. Controle: {1})",
                        v.CódigoFormatado, v.Controle.Value);
                else
                    título.Descrição = string.Format(
                        "Venda de código {0}",
                        v.CódigoFormatado);
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

            int? dentroDaComissão = v.DentroDaComissão;

            if (dentroDaComissão.HasValue)
            {
                quadroTravamento.Título = "Comissão nr. " + dentroDaComissão.Value.ToString();
                lblTravamento.Text = "Este documento não pode ser alterado nem excluído uma vez que já está com a comissão fechada.";
                opçãoDestravar.Visible = false;
            }

            digitaçãoDevolução.AtualizarTravamento(entidadeTravada);
            dadosVenda.AtualizarTravamento(entidadeTravada);
            AtualizarEnabledPuxarDébitosCréditos(entidadeTravada);
        }

        private void AtualizarEnabledPuxarDébitosCréditos(bool entidadeTravada)
        {
            opçãoCobrançaAutomática.Enabled =
                opçãoGastarCréditosCliente.Enabled =
            (Relacionamento.Pessoa != null && (!entidadeTravada) && Relacionamento.Cadastrado);
        }

        /// <summary>
        /// Abre a base para digitação de nova venda.
        /// A pessoa serve para preparar a base, preenchendo automaticamente
        /// os campos cliente e/ou vendedor.
        /// </summary>
        public void PrepararNovaVenda(Entidades.Pessoa.Pessoa pessoa)
        {
            Entidades.Pessoa.Pessoa cliente, vendedor;
            Entidades.Relacionamento.Venda.Venda venda;

            if (Funcionário.ÉVendedor(pessoa))
            {
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
            if (venda.AcertoConsignado == null && Representante.ÉRepresentante(pessoa))
            {
                AcertoConsignado acerto = Acerto.EscolherAcerto.QuestionarUsuário(ParentForm, pessoa, false);
                
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
                    Acerto.EscolherAcerto.QuestionarUsuário(ParentForm, Entidades.Pessoa.Pessoa.Varejo, false);

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

        private void dadosVenda_CotaçãoAlterada(Entidades.Financeiro.Cotação cotação)
        {
            digitaçãoDevolução.Cotação = cotação;
            Digitação.Cotação = cotação;

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

        void dadosVenda_AoAlterarCliente(object sender, System.EventArgs e)
        {
            listaPagamentos.Venda = dadosVenda.Venda;

            AtualizarEnabledPuxarDébitosCréditos(Relacionamento.TravadoEmCache);

            CadastrarVendaSeNecessário();
        }

        private void CadastrarVendaSeNecessário()
        {
            if (!dadosVenda.Venda.Cadastrado
                && dadosVenda.Venda.Cliente != null
                && dadosVenda.Venda.Vendedor != null)

                dadosVenda.Venda.Cadastrar();
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
                AguardeDB.Mostrar();

                Entidades.Pagamentos.Pagamento[] pagamentos =
                    Entidades.Pagamentos.Pagamento.ObterPagamentos(Relacionamento.Pessoa, true);

                tabs.SelectTab(tabDébitos);

                listaDébitos.AdicionarCadastrando(pagamentos);

                AguardeDB.Fechar();
            }
            else
            {
                opçãoCobrançaAutomática.Enabled =  
                    opçãoGastarCréditosCliente.Enabled = false;
            }
        }

        private void opçãoGastarCréditosCliente_Click(object sender, EventArgs e)
        {
            if (!ConferirTravamento()) {
                AguardeDB.Mostrar();

                List<Entidades.Financeiro.Crédito> créditosNãoUtilizados = Entidades.Financeiro.Crédito.ObterCréditosNãoUtilizados(Relacionamento.Pessoa);

                tabs.SelectTab(tabCréditos);
                listaCréditos.AdicionarCadastrando(créditosNãoUtilizados);
                AguardeDB.Fechar();
            }
            else
                opçãoGastarCréditosCliente.Enabled = false;

        }

        private Relatório ObterRelatório()
        {
            Relatório relatório = new Relatório();

            new ControleImpressãoVenda().PrepararImpressãoVenda(relatório,
                (Entidades.Relacionamento.Venda.Venda)Relacionamento,
                listaPagamentos.ObterPagamentosExibidos()
                );

            return relatório;
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == tabVenda)
                dadosVenda.MostrarPreços();
        }

        protected override void InserirDocumento(JanelaImpressão j)
        {
            Relatório relatório = ObterRelatório();

            j.Título = "Impressão de venda";
            j.Descrição = "";
            j.InserirDocumento(relatório, "Venda");
        }
    }
}
