using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Impress�o.Relat�rios.Venda;
using Entidades.Pessoa;
using Entidades.Privil�gio;
using Entidades.Configura��o;
using Entidades.Acerto;
using System.Collections;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Financeiro.Venda
{
    public partial class BaseEditarVenda : Apresenta��o.Financeiro.BaseEditarRelacionamento
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
            digita��o.TipoExibi��oAtual = Apresenta��o.Financeiro.Digita��oComum.TipoExibi��o.TipoAgrupado;
            ((Digita��oVenda)digita��o).Verificador = verificadorMercadoria;
            verificadorMercadoria.SetVerificarMercadoria(digita��o, true);
            verificadorMercadoria.SetVerificarMercadoria(digita��oDevolu��o, true);
            digita��oDevolu��o.Verificador = verificadorMercadoria;
            tabItens.Controls.Remove(base.digita��o);
            tabItens.Controls.Add(digita��o);

            base.digita��o = digita��o;

            Digita��o.MostrarPre�o = true;


            ///* Como a base j� insere a tab de itens em primeiro,
            // * � necess�rio reposicionar as tabs:
            // */

            digita��oDevolu��o.PermitirSele��oTabela = false;
            digita��o.PermitirSele��oTabela = false;

            if (this.DesignMode) return;

           
           //this.tabs.Controls.Remove(tabItens);
           //this.tabs.Controls.Remove(tabPagamentos);
           //this.tabs.Controls.Remove(tabDevolu��o);
           //this.tabs.Controls.Remove(tabD�bitos);
           //this.tabs.Controls.Remove(tabObserva��es);

            this.tabs.SuspendLayout();
            this.tabs.Controls.Clear();
            this.tabs.Controls.AddRange(new Control[] {
                tabVenda, tabItens, tabD�bitos, tabCr�ditos, tabDevolu��o, tabPagamentos, tabObserva��es });
            this.tabs.ResumeLayout();
           
           //this.tabs.Controls.Add(tabItens);
           //this.tabs.Controls.Add(tabD�bitos);
           //this.tabs.Controls.Add(tabDevolu��o);
           //this.tabs.Controls.Add(tabPagamentos);
        }

        protected override bool ValidarPermiss�oDestravar()
        {
            return Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Entidades.Privil�gio.Permiss�o.VendasDestravar);
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

            //Apresenta��o.Formul�rios.AguardeDB.Mostrar();

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

                if (v.Vendedor != null && !Representante.�Representante(v.Vendedor) && !Permiss�oFuncion�rio.ValidarPermiss�o(Permiss�o.VendasEditar))
                {
                    if (v.Travado)
                    {
                        dadosVenda.Enabled = false;
                        listaPagamentos.Enabled = false;
                        //txtObserva��es.ReadOnly = true;
                    }
                    else
                    {
                        tabs.Controls.Remove(tabVenda);
                        tabs.Controls.Remove(tabPagamentos);
                    }
                }

                op��oCobran�aAutom�tica.Enabled =
                op��oGastarCr�ditosCliente.Enabled = 
                    (v.Cliente != null && (!v.Travado));
                

                //quadroPagamento.Visible = !v.Acertado;

                //txtObserva��es.Text = v.Observa��es == null ? "" : v.Observa��es;
            }
            finally
            {
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }

            if (v.Itens.Count == 0 && v.Cliente != null)
                try
                {
                    Apresenta��o.Pessoa.AlertaClassifica��o.Alertar(v.Cliente, Classifica��o.TipoAlerta.Venda);
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

        }

        void AoAlterar(Acesso.Comum.DbManipula��o entidade)
        {
            if (entidade == Relacionamento)
            {
                MostrarT�tulo();

                //if (!verificadorMercadoria.Enabled && !Relacionamento.Acertado)
                //{
                //    if (dadosVenda.Venda.Vendedor == null && Representante.�Representante(dadosVenda.Venda.Vendedor))
                //        verificadorMercadoria.Restringir(dadosVenda.Venda.Vendedor);
                //    else
                //        verificadorMercadoria.Restringir(dadosVenda.Venda.Cliente);

                //    verificadorMercadoria.Enabled = true;
                //}
            }
        }

        void DepoisDeCadastrar(Acesso.Comum.DbManipula��o entidade)
        {
            if (entidade == Relacionamento)
                MostrarT�tulo();

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
                        "Venda de n�mero {0} (N. Controle: {1})",
                        v.C�digo, v.Controle.Value);
                else
                    t�tulo.Descri��o = string.Format(
                        "Venda de n�mero {0}",
                        v.C�digo);
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

            if (v.DentroDeComiss�o)
            {
                quadroTravamento.T�tulo = "Comiss�o Fechada";
                lblTravamento.Text = "Este documento n�o pode ser alterado nem exclu�do uma vez que j� est� com a comiss�o fechada.";
                op��oDestravar.Visible = false;
            }
            digita��oDevolu��o.AtualizarTravamento(entidadeTravada);
            dadosVenda.AtualizarTravamento(entidadeTravada);
            //listaPagamentos.AtualizarTravamento(entidadeTravada);
            
            op��oCobran�aAutom�tica.Enabled =
                op��oGastarCr�ditosCliente.Enabled = 
            (Relacionamento.Pessoa != null && (!entidadeTravada));
        }

        //protected override Apresenta��o.Formul�rios.JanelaImpress�o CriarJanelaImpress�o()
        //{
        //    /*
        //    UseWaitCursor = true;
        //    Apresenta��o.Formul�rios.AguardeDB.Mostrar();
        //    Application.DoEvents();

        //    Impress�o.JanelaImpress�oVenda janela = new Impress�o.JanelaImpress�oVenda((Entidades.Relacionamento.Venda.Venda)base.Relacionamento);

        //    Apresenta��o.Formul�rios.AguardeDB.Fechar();
        //    UseWaitCursor = false;

        //    return janela;
        //     */
        //    return null;
        //}

        /// <summary>
        /// Abre a base para digita��o de nova venda.
        /// A pessoa serve para preparar a base, preenchendo automaticamente
        /// os campos cliente e/ou vendedor.
        /// </summary>
        public void PrepararNovaVenda(Entidades.Pessoa.Pessoa pessoa)
        {
            Entidades.Pessoa.Pessoa cliente, vendedor;
            Entidades.Relacionamento.Venda.Venda venda;

            if (Entidades.Pessoa.Funcion�rio.�Vendedor(pessoa))
            {
                // Excess�o ao caso padr�o. Se a pessoa selecionada � da empresa, ent�o ser�
                // digitado uma venda desta pessoa para algum cliente qualquer.
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
            if (venda.AcertoConsignado == null && Entidades.Pessoa.Representante.�Representante(pessoa))
            {
                AcertoConsignado acerto = Apresenta��o.Financeiro.Acerto.EscolherAcerto.QuestionarUsu�rio(ParentForm, pessoa, false);
                
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
                    Apresenta��o.Financeiro.Acerto.EscolherAcerto.QuestionarUsu�rio(ParentForm, Entidades.Pessoa.Pessoa.Varejo, false);

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

        private void dadosVenda_Cota��oAlterada(Entidades.Cota��o cota��o)
        {
            // Neste ponto a nova cota��o j� foi gravada no bd.

            // Atualiza as duas bandejas com a nova cota��o.
            digita��oDevolu��o.Cota��o = Digita��o.Cota��o = cota��o;
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

        private void dadosVenda_AoAlterarVendedor(object sender, EventArgs e)
        {
            //if (verificadorMercadoria.Enabled && (dadosVenda.Venda.Vendedor != null && Representante.�Representante(dadosVenda.Venda.Vendedor)))
            //    verificadorMercadoria.Restringir(dadosVenda.Venda.Vendedor);
        }

        void dadosVenda_AoAlterarCliente(object sender, System.EventArgs e)
        {
            listaPagamentos.Venda = dadosVenda.Venda;

            //if (verificadorMercadoria.Enabled && (dadosVenda.Venda.Vendedor == null || !Representante.�Representante(dadosVenda.Venda.Vendedor)))
            //    verificadorMercadoria.Restringir(dadosVenda.Venda.Cliente);

            op��oCobran�aAutom�tica.Enabled =
                op��oGastarCr�ditosCliente.Enabled = 
            (Relacionamento.Pessoa != null && (!dadosVenda.Venda.Travado));
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
                    //quadroPagamento.Visible = false;

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


        private void dadosVenda_AoAlterarTabela(object sender, EventArgs e)
        {
            //digita��o.Tabela = ((Entidades.Relacionamento.Venda.Venda)Relacionamento).TabelaPre�o;
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
                Apresenta��o.Formul�rios.AguardeDB.Mostrar();

                Entidades.Pagamentos.Pagamento[] pagamentos =
                    Entidades.Pagamentos.Pagamento.ObterPagamentos(Relacionamento.Pessoa, true);

                tabs.SelectTab(tabD�bitos);
                listaD�bitos.AdicionarCadastrando(pagamentos);
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }
            else
                op��oCobran�aAutom�tica.Enabled = false;
        }

        private void op��oGastarCr�ditosCliente_Click(object sender, EventArgs e)
        {
            if (!ConferirTravamento()) {
                Apresenta��o.Formul�rios.AguardeDB.Mostrar();

                List<Entidades.Cr�dito> cr�ditosN�oUtilizados = Entidades.Cr�dito.ObterCr�ditosN�oUtilizados(Relacionamento.Pessoa);

                tabs.SelectTab(tabCr�ditos);
                listaCr�ditos.AdicionarCadastrando(cr�ditosN�oUtilizados);
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }
            else
                op��oGastarCr�ditosCliente.Enabled = false;

        }

        protected override void Imprimir()
        {
            AguardeDB.Mostrar();
            Apresenta��o.Impress�o.Relat�rios.Venda.ControleImpress�oVenda 
                controle = new ControleImpress�oVenda();

            Apresenta��o.Impress�o.Relat�rios.Venda.Relat�rio relat�rio = new
                Apresenta��o.Impress�o.Relat�rios.Venda.Relat�rio();

            controle.PrepararImpress�oVenda(relat�rio, 
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
                    relat�rio.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                    relat�rio.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ocorreu um erro na impress�o. A impressora est� ligada? \n" + err.Message, "Erro na impress�o", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dadosVenda.MostrarPre�os();
        }
    }
}

