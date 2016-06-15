using Apresenta��o.Formul�rios;
using Apresenta��o.Impress�o.Relat�rios.Venda;
using Entidades.Acerto;
using Entidades.Pessoa;
using Entidades.Privil�gio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades.Relacionamento;

namespace Apresenta��o.Financeiro.Venda
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

            Digita��oVenda digita��o = new Digita��oVenda();
            // 
            // digita��o
            // 
            digita��o.Anchor = base.digita��o.Anchor;
            digita��o.Dock = base.digita��o.Dock;
            digita��o.BackColor = System.Drawing.Color.Transparent;
            digita��o.Location = base.digita��o.Location;
            digita��o.Name = "digita��o";
            digita��o.Size = base.digita��o.Size;
            digita��o.TabIndex = base.digita��o.TabIndex;
            digita��o.TipoExibi��oAtual = Digita��oComum.TipoExibi��o.TipoAgrupado;
            digita��o.Verificador = verificadorMercadoria;
            verificadorMercadoria.SetVerificarMercadoria(digita��o, true);
            verificadorMercadoria.SetVerificarMercadoria(digita��oDevolu��o, true);
            digita��oDevolu��o.Verificador = verificadorMercadoria;
            tabItens.Controls.Remove(base.digita��o);
            tabItens.Controls.Add(digita��o);

            base.digita��o = digita��o;

            Digita��o.MostrarPre�o = true;
            digita��oDevolu��o.PermitirSele��oTabela = false;
            digita��o.PermitirSele��oTabela = false;

            if (DesignMode) return;

            tabs.SuspendLayout();
            tabs.Controls.Clear();
            tabs.Controls.AddRange(new Control[] {
                tabVenda, tabItens, tabD�bitos, tabCr�ditos, tabDevolu��o, tabPagamentos, tabObserva��es });
            tabs.ResumeLayout();
           
        }

        protected override bool ValidarPermiss�oDestravar()
        {
            return Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.VendasDestravar);
        }

        protected override Apresenta��o.Impress�o.TipoDocumento TipoDocumento
        {
            get
            {
                return Apresenta��o.Impress�o.TipoDocumento.Venda;
            }
        }

        /// <summary>
        /// � a primeiro m�todo chamado nesta base inferior.
        /// Deve ser chamado externamente,
        /// Abre as bandejas e inicia observa��o.
        /// </summary>
        public override void Abrir(Entidades.Relacionamento.Relacionamento relacionamento)
        {
            Entidades.Relacionamento.Venda.Venda v = (Entidades.Relacionamento.Venda.Venda)relacionamento;

            try
            {
                verificadorMercadoria.Enabled = false;

                Digita��o.Cota��o = digita��oDevolu��o.Cota��o = v.Cota��o;
                Digita��o.Cota��o.Data = digita��oDevolu��o.Cota��o.Data = null;

                base.Abrir(v);

                CamposLivres = true;

                // Abre a devolu��o
                digita��oDevolu��o.Abrir(v.ItensDevolu��o, v, this);

                // Abre os pagamentos
                listaPagamentos.Venda = v;

                // Abre os dados gerais da venda
                dadosVenda.Abrir(v, this);

                listaD�bitos.Abrir(v);
                listaD�bitos.InformarBaseEditarVenda(this);
                listaCr�ditos.Abrir(v);
                listaCr�ditos.InformarBaseEditarVenda(this);

                MostrarT�tulo();

                verificadorMercadoria.Enabled = v.AcertoConsignado != null;
                verificadorMercadoria.Restringir(v.AcertoConsignado);

                v.DepoisDeCadastrar += new Acesso.Comum.DbManipula��o.DbManipula��oHandler(DepoisDeCadastrar);
                v.Alterado += new Acesso.Comum.DbManipula��o.DbManipula��oHandler(AoAlterar);

                CamposLivres = false;

                if (!dadosVenda.Enabled)
                    tabs.TabIndex = 1;

                bool vendaTravada = v.Travado;

                if (v.Vendedor != null && !Representante.�Representante(v.Vendedor) && !Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.VendasEditar))
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

                AtualizarEnabledPuxarD�bitosCr�ditos(vendaTravada);
            }
            finally
            {
                AguardeDB.Fechar();
            }

            if (v.Itens.Count == 0 && v.Cliente != null)
                try
                {
                    Pessoa.AlertaClassifica��o.Alertar(v.Cliente, Classifica��o.TipoAlerta.Venda);
                }
                catch (Permiss�oNegada erro)
                {
                    MessageBox.Show(
                        ParentForm,
                        erro.Message,
                        "Permiss�o negada",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    
                    AtualizarTravamento(true);
                }

            CadastrarVendaSeNecess�rio();
        }

        public override Relacionamento ReobterRelacionamento()
        {
            return Entidades.Relacionamento.Venda.Venda.ObterVenda(Relacionamento.C�digo);
        }

        void v_AoCancelarCadastro(object sender, EventArgs e)
        {
            MostrarMensagemEntidadeN�oSalva();
        }

        protected override void MostrarMensagemEntidadeN�oSalva()
        {
            MessageBox.Show(this,
                "Venda ainda n�o foi cadastrada. Verifique se possui cliente.",
                "Ainda n�o cadastrado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        void AoAlterar(Acesso.Comum.DbManipula��o entidade)
        {
            if (entidade == Relacionamento)
                MostrarT�tulo();
        }

        void DepoisDeCadastrar(Acesso.Comum.DbManipula��o entidade)
        {
            if (entidade == Relacionamento)
                MostrarT�tulo();

            AtualizarTravamento(Relacionamento.Travado);   

            listaPagamentos.Carregar();
        }

        /// <summary>
        /// Mostra o t�tulo na base inferior, conforme dados da venda.
        /// </summary>
        private void MostrarT�tulo()
        {
            Entidades.Relacionamento.Venda.Venda v = (Entidades.Relacionamento.Venda.Venda)Relacionamento;

            if (v.Vendedor != null && Entidades.Pessoa.Representante.�Representante(v.Vendedor))
                t�tulo.T�tulo = v.Vendedor.Nome;

            else if (v.Cliente != null)
                t�tulo.T�tulo = v.Cliente.Nome;

            else if (v.Vendedor != null)
                t�tulo.T�tulo = v.Vendedor.Nome;

            else
                t�tulo.T�tulo = "Venda";

            if (v.Cadastrado)
            {
                if (v.Controle.HasValue)
                    t�tulo.Descri��o = string.Format(
                        "Venda de c�digo {0} (N. Controle: {1})",
                        v.C�digoFormatado, v.Controle.Value);
                else
                    t�tulo.Descri��o = string.Format(
                        "Venda de c�digo {0}",
                        v.C�digoFormatado);
            }
            else
                t�tulo.Descri��o = "Venda ainda n�o cadastrada";

            if (v.Vendedor != null)
                t�tulo.Descri��o += "\nDe " + Entidades.Pessoa.Pessoa.ReduzirNome(v.Vendedor.Nome);

            if (v.Cliente != null)
                t�tulo.Descri��o += " para " + v.Cliente.Nome;
        }

        protected override void AtualizarTravamento(bool entidadeTravada)
        {
            base.AtualizarTravamento(entidadeTravada);

            Entidades.Relacionamento.Venda.Venda v = (Entidades.Relacionamento.Venda.Venda)Relacionamento;

            int? dentroDaComiss�o = v.DentroDaComiss�o;

            if (dentroDaComiss�o.HasValue)
            {
                quadroTravamento.T�tulo = "Comiss�o nr. " + dentroDaComiss�o.Value.ToString();
                lblTravamento.Text = "Este documento n�o pode ser alterado nem exclu�do uma vez que j� est� com a comiss�o fechada.";
                op��oDestravar.Visible = false;
            }

            digita��oDevolu��o.AtualizarTravamento(entidadeTravada);
            dadosVenda.AtualizarTravamento(entidadeTravada);
            AtualizarEnabledPuxarD�bitosCr�ditos(entidadeTravada);
        }

        private void AtualizarEnabledPuxarD�bitosCr�ditos(bool entidadeTravada)
        {
            op��oCobran�aAutom�tica.Enabled =
                op��oGastarCr�ditosCliente.Enabled =
            (Relacionamento.Pessoa != null && (!entidadeTravada) && Relacionamento.Cadastrado);
        }

        /// <summary>
        /// Abre a base para digita��o de nova venda.
        /// A pessoa serve para preparar a base, preenchendo automaticamente
        /// os campos cliente e/ou vendedor.
        /// </summary>
        public void PrepararNovaVenda(Entidades.Pessoa.Pessoa pessoa)
        {
            Entidades.Pessoa.Pessoa cliente, vendedor;
            Entidades.Relacionamento.Venda.Venda venda;

            if (Funcion�rio.�Vendedor(pessoa))
            {
                vendedor = pessoa;
                cliente = null;
            }
            else
            {
                // Caso padr�o. Vendendor � o funcion�rio e cliente � aquele que foi selecionado.
                vendedor = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;
                cliente = pessoa;
            }

            venda = Entidades.Relacionamento.Venda.Venda.CriarNovaVenda(cliente, vendedor);

            // Todas as vendas de representante tem acerto
            if (venda.AcertoConsignado == null && Representante.�Representante(pessoa))
            {
                AcertoConsignado acerto = Acerto.EscolherAcerto.QuestionarUsu�rio(ParentForm, pessoa, false);
                
                if (acerto == null)
                    MessageBox.Show(
                        ParentForm,
                        "Venda de representante normalmente est� vinculada a algum acerto. Por favor, defina o acerto.",
                        "Venda de representante",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    acerto.Adicionar(venda);
            }

            // Todas as vendas de varejo tem acerto
            if (venda.AcertoConsignado == null && pessoa.Setor == Entidades.Setor.ObterSetor(Entidades.Setor.SetorSistema.Varejo))
            {
                AcertoConsignado acerto = 
                    Acerto.EscolherAcerto.QuestionarUsu�rio(ParentForm, Entidades.Pessoa.Pessoa.Varejo, false);

                if (acerto == null)
                    MessageBox.Show(
                        ParentForm,
                        "Venda de varejo normalmente est� vinculada a algum acerto. Por favor, defina o acerto.",
                        "Venda de varejo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    acerto.Adicionar(venda);
            }

            Abrir(venda);
        }

        private void dadosVenda_Cota��oAlterada(Entidades.Financeiro.Cota��o cota��o)
        {
            digita��oDevolu��o.Cota��o = cota��o;
            Digita��o.Cota��o = cota��o;

            listaPagamentos.Carregar();
        }

        protected override void AlternarBandeja(object sender, EventArgs e)
        {
            base.AlternarBandeja(sender, e);

            if (optAgrupado.Checked)
                digita��oDevolu��o.TipoExibi��oAtual = Digita��oComum.TipoExibi��o.TipoAgrupado;
            else
                digita��oDevolu��o.TipoExibi��oAtual = Digita��oComum.TipoExibi��o.TipoHist�rico;

        }

        void dadosVenda_AoAlterarCliente(object sender, System.EventArgs e)
        {
            listaPagamentos.Venda = dadosVenda.Venda;

            AtualizarEnabledPuxarD�bitosCr�ditos(Relacionamento.TravadoEmCache);

            CadastrarVendaSeNecess�rio();
        }

        private void CadastrarVendaSeNecess�rio()
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

        private void op��oFormaPagamento_Click(object sender, EventArgs e)
        {
            using (JanelaCriarPagamentos dlg = new JanelaCriarPagamentos((Entidades.Relacionamento.Venda.Venda)Relacionamento))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    dadosVenda.MostrarPre�os();
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
            listaCr�ditos.DataDaVendaFoiAtualizada(dadosVenda.Venda.Data);
            listaD�bitos.DataDaVendaFoiAtualizada(dadosVenda.Venda.Data);
        }

        void dadosVenda_AoAlterarDiasSemJuros(object sender, System.EventArgs e)
        {
            listaPagamentos.Carregar();
        }

        private void op��oCobran�aAutom�tica_Click(object sender, EventArgs e)
        {
            if (!ConferirTravamento())
            {
                AguardeDB.Mostrar();

                Entidades.Pagamentos.Pagamento[] pagamentos =
                    Entidades.Pagamentos.Pagamento.ObterPagamentos(Relacionamento.Pessoa, true);

                tabs.SelectTab(tabD�bitos);

                listaD�bitos.AdicionarCadastrando(pagamentos);

                AguardeDB.Fechar();
            }
            else
            {
                op��oCobran�aAutom�tica.Enabled =  
                    op��oGastarCr�ditosCliente.Enabled = false;
            }
        }

        private void op��oGastarCr�ditosCliente_Click(object sender, EventArgs e)
        {
            if (!ConferirTravamento()) {
                AguardeDB.Mostrar();

                List<Entidades.Financeiro.Cr�dito> cr�ditosN�oUtilizados = Entidades.Financeiro.Cr�dito.ObterCr�ditosN�oUtilizados(Relacionamento.Pessoa);

                tabs.SelectTab(tabCr�ditos);
                listaCr�ditos.AdicionarCadastrando(cr�ditosN�oUtilizados);
                AguardeDB.Fechar();
            }
            else
                op��oGastarCr�ditosCliente.Enabled = false;

        }

        private Relat�rio ObterRelat�rio()
        {
            Relat�rio relat�rio = new Relat�rio();

            new ControleImpress�oVenda().PrepararImpress�oVenda(relat�rio,
                (Entidades.Relacionamento.Venda.Venda)Relacionamento,
                listaPagamentos.ObterPagamentosExibidos()
                );

            return relat�rio;
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == tabVenda)
                dadosVenda.MostrarPre�os();
        }

        protected override void InserirDocumento(JanelaImpress�o j)
        {
            Relat�rio relat�rio = ObterRelat�rio();

            j.T�tulo = "Impress�o de venda";
            j.Descri��o = "";
            j.InserirDocumento(relat�rio, "Venda");
        }
    }
}
