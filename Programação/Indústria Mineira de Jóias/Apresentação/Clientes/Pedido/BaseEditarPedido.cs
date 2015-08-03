using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Pessoa;
using Entidades.Configuração;
using Apresentação.Impressão.Relatórios.Pedido.Recibo;
using Entidades;
using Entidades.PedidoConserto;

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class BaseEditarPedido : BaseInferior
    {
        private Entidades.PedidoConserto.Pedido pedido;
        private bool abrindo = false;
        private ModoEdição modo;

        private enum ModoEdição { Inserção, Alteração }

        public Entidades.PedidoConserto.Pedido.Tipo Tipo
        {
            set
            {
                radioConserto.Checked = (value == Entidades.PedidoConserto.Pedido.Tipo.Conserto);
                radioEncomenda.Checked = !radioConserto.Checked;

                if (pedido != null)
                    pedido.TipoPedido = value;
            }
        }

                
        public BaseEditarPedido()
        {
            InitializeComponent();
            Pedido = null;
            pedido.Receptor = Funcionário.FuncionárioAtual;
            txtFuncionário.Pessoa = pedido.Receptor;
        }

        public BaseEditarPedido(Entidades.PedidoConserto.Pedido pedido)
        {
            InitializeComponent();
            Pedido = pedido;
        }

        public BaseEditarPedido(Entidades.Pessoa.Pessoa cliente)
            : this()
        {
            txtCliente.Pessoa = cliente;
            pedido.Cliente = cliente;

            if (cliente.Região != null)
                txtRegião.Text = txtCliente.Pessoa.Região.Nome + " " + (pedido.Representante == null ? "" : " (" + pedido.Representante.PrimeiroNome + ")");
            else
                txtRegião.Text = "";

            ObterRepresentante();
            Gravar();
        }

        public Entidades.PedidoConserto.Pedido Pedido
        {
            get { return pedido; }
            set
            {
                // Nao grava enquanto está abrindo
                abrindo = true;

                pedido = value;

                if (value != null)
                {
                    modo = ModoEdição.Alteração;

                    optPertenceCliente.Checked = pedido.PertenceAoCliente;
                    optPertenceEmpresa.Checked = !pedido.PertenceAoCliente;

                    AtualizarVisibilidadeControlesDeOficina();
                    AtualizarVisibilidadeEncomendaItem();

                    switch (pedido.TipoPedido)
                    {
                        case Entidades.PedidoConserto.Pedido.Tipo.Conserto:
                            radioConserto.Checked = true;

                            if (pedido.DataOficina.HasValue)
                                dtOficina.Value = pedido.DataOficina.Value;

                            break;

                        case Entidades.PedidoConserto.Pedido.Tipo.Pedido:
                            radioEncomenda.Checked = true;
                            
                            break;
                    }

                    switch (pedido.EntregaPedido)
                    {
                        case Entidades.PedidoConserto.Pedido.Entrega.Despachar:
                            chkDespachar.Checked = true;
                            break;

                        case Entidades.PedidoConserto.Pedido.Entrega.Levar:
                            chkLevar.Checked = true;
                            break;
                    }


                    //radioConserto.Enabled = radioEncomenda.Checked = true;

                    //if (pedido.Controle.HasValue)
                    //    txtControle.Int = (int)pedido.Controle.Value;
                    //else
                    //    txtControle.Text = "";

                    //txtControle.ReadOnly = true;
                    txtValor.Double = pedido.Valor;

                    if (pedido.Cliente != null)
                        txtCliente.Pessoa = pedido.Cliente;
                    else
                        txtCliente.Text = pedido.NomeDoCliente;

                    //txtCliente.ReadOnly = true;
                    //txtRepresentante.Pessoa = pedido.Representante;
                    //txtRepresentante.ReadOnly = true;
                    if (pedido.Cliente != null && pedido.Cliente.Região != null)
                        txtRegião.Text = txtCliente.Pessoa.Região.Nome + " " + (pedido.Representante == null ? "" : " (" + pedido.Representante.PrimeiroNome + ")");
                    else
                        txtRegião.Text = "";
                    
                    txtFuncionário.Pessoa = pedido.Receptor;
                    txtFuncionário.ReadOnly = true;
                    dtRecepção.Value = pedido.DataRecepção;


                    //dtRecepção.Enabled = false;
                    dtPrevisão.Value = pedido.DataPrevisão;

                    //dtPrevisão.Enabled = false;

                    if (pedido.DataConclusão.HasValue)
                    {
                        dtConclusão.Value = pedido.DataConclusão.Value;
                        //dtConclusão.Enabled = false;
                        btnConclusao.Visible = false;
                        dtConclusão.Visible = true;
                        btnRemoverDataConclusão.Visible = true;
                    }
                    else
                    {
                        dtConclusão.Visible = false;
                        dtConclusão.Enabled = true;
                        btnConclusao.Visible = true;
                        btnRemoverDataConclusão.Visible = false;
                    }

                    if (pedido.DataEntrega.HasValue)
                    {
                        dtEntrega.Text = ObterEntreguePor();

                        dtEntrega.Visible = true;
                        //dtEntrega.Enabled = false;
                        btnEntregar.Visible = false;
                        btnRemoverDataEntrega.Visible = true;
                    }
                    else
                    {
                        dtEntrega.Visible = false;
                        dtEntrega.Enabled = true;
                        btnEntregar.Visible = true;
                        btnRemoverDataEntrega.Visible = false;
                    }

                    txtDescrição.Text = pedido.Observações;
                    //txtDescrição.ReadOnly = true;

                    títuloBaseInferior1.Título = (pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Pedido ? "Pedido " : "Conserto ") + pedido.Código.ToString();
                    títuloBaseInferior1.Descrição = "Visualize ou edite os dados do pedido, caso necessário.";
                 //   grpEntrega.Visible = grpRecepção.Visible = grpObservações.Visible = true;
                }
                else
                {
                    modo = ModoEdição.Inserção;
                    pedido = new Entidades.PedidoConserto.Pedido();
                    pedido.TipoPedido = Entidades.PedidoConserto.Pedido.Tipo.Pedido;
                    radioEncomenda.Checked = true;

                    radioConserto.Checked = false;
                    
                    //txtDescrição.ReadOnly = true;

                    chkDespachar.Checked = true;
                    chkLevar.Checked = false;
                    pedido.EntregaPedido = Entidades.PedidoConserto.Pedido.Entrega.Despachar;

                    radioConserto.Enabled = radioEncomenda.Enabled = true;
                    //txtControle.Text = "";
                    //txtControle.ReadOnly = false;
                    txtCliente.Pessoa = null;
                    txtCliente.ReadOnly = false;
                    //txtRepresentante.Pessoa = null;
                    //txtRepresentante.ReadOnly = false;
                    txtFuncionário.Pessoa = Funcionário.FuncionárioAtual;
                    txtFuncionário.ReadOnly = false;
                    dtRecepção.Value = DadosGlobais.Instância.HoraDataAtual;
                    //dtRecepção.Enabled = false;
                    
                    // Como é um novo pedido, permitir gravação
                    abrindo = false;
                    AtualizarPrevisão();
                    abrindo = true;

                    dtPrevisão.Enabled = true;
                    dtConclusão.Visible = false;
                    dtConclusão.Enabled = true;
                    btnConclusao.Visible = true;
                    dtEntrega.Visible = false;
                    dtEntrega.Enabled = true;
                    btnEntregar.Visible = true;
                    txtDescrição.Text = "";
                    títuloBaseInferior1.Título = "Novo pedido";
                    títuloBaseInferior1.Descrição = "";
                    //grpEntrega.Visible = grpRecepção.Visible = grpObservações.Visible = false;
                    Gravar();

                }

                pedido.DepoisDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(pedido_DepoisDeCadastrar);

                if (!pedido.DataConclusão.HasValue)
                    dtConclusão.MinDate = pedido.DataRecepção;

                else if (!pedido.DataEntrega.HasValue)
                    dtEntrega.Text = "";

                bool travar = (modo == ModoEdição.Alteração && !Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.EditarPedidosConsertos));
                opçãoExcluir.Visible = !travar;

                grpIdentificação.Enabled = !travar;
                grpObservações.Enabled = !travar;
                grpItens.Enabled = !travar;
                grpRecepção.Enabled = !travar;

                // Entrega de pedidos à clientes sempre é liberada
                //grpEntrega.Enabled = !travar;


                quadroManutenção.Enabled = !travar;

                dtRecepção.Enabled = 
                    Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.EditarPedidosConsertos);

                // Carrega itens de pedido
                flow.Controls.Clear();
                List<PedidoItem> itens = PedidoItem.Obter(pedido);
                foreach (PedidoItem i in itens)
                {
                    AdicionarItem(i);
                }

                abrindo = false;
            }
        }

        private string ObterEntreguePor()
        {
            return pedido.DataEntrega.Value.ToShortDateString() + " por " +
               Entidades.Pessoa.Pessoa.ReduzirNome(pedido.FuncionárioEntrega.Nome);
        }

        private EncomendaItem AdicionarItem(PedidoItem item)
        {
            EncomendaItem itemGráfico = new EncomendaItem(item);
            itemGráfico.SolicitouExclusão += new EventHandler(itemGráfico_SolicitouExclusão);
            flow.Controls.Add(itemGráfico);
            //itemGráfico.Width = flow.Width - 10;

            return itemGráfico;
        }

        void itemGráfico_SolicitouExclusão(object sender, EventArgs e)
        {
            EncomendaItem item = (EncomendaItem)sender;
            flow.Controls.Remove(item);
            item.Item.Descadastrar();
        }

        void pedido_DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            //grpEntrega.Visible = grpRecepção.Visible = grpObservações.Visible = true;
            txtFuncionário.ReadOnly = false;
            títuloBaseInferior1.Título = "Pedido " + pedido.Código.ToString();
        }

        private void radioEncomenda_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEncomenda.Checked)
            {
                opçãoImprimir.Visible = false;
                pedido.TipoPedido = Entidades.PedidoConserto.Pedido.Tipo.Pedido;
                títuloBaseInferior1.Título = "Pedido " + pedido.Código.ToString();
                chkDespachar.Text = "Despachar pedido";

                if (!abrindo)
                {
                    AtualizarPrevisão();
                    Gravar();
                }
            }

            AtualizarVisibilidadeControlesDeOficina();
            AtualizarVisibilidadeEncomendaItem();
        }

        private void radioConserto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioConserto.Checked)
            {
                opçãoImprimir.Visible = true;
                pedido.TipoPedido = Entidades.PedidoConserto.Pedido.Tipo.Conserto;
                títuloBaseInferior1.Título = "Conserto " + pedido.Código.ToString();
                chkDespachar.Text = "Despachar conserto";

                if (!abrindo)
                {
                    AtualizarPrevisão();
                    Gravar();
                }
            }

            AtualizarVisibilidadeControlesDeOficina();
            AtualizarVisibilidadeEncomendaItem();
        }

        private void AtualizarVisibilidadeEncomendaItem()
        {
            if (pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Conserto)
            {
                grpObservações.Width = grpIdentificação.Width;
                grpItens.Visible = false;
            }
            else
            {
                grpRecepção.Refresh();
                grpObservações.Width = grpRecepção.Width;
                grpItens.Visible = true;
            }
        }

        private void txtCliente_Selecionado(object sender, EventArgs e)
        {
            pedido.Cliente = txtCliente.Pessoa;
            pedido.NomeDoCliente = null;
            ObterRepresentante();
            Gravar();
        }

        private void ObterRepresentante()
        {
            if (txtCliente.Pessoa != null && txtCliente.Pessoa.Região != null)
            {
                txtRegião.Text = txtCliente.Pessoa.Região.Nome + " " + (pedido.Representante == null ? "" : " (" + pedido.Representante.PrimeiroNome + ")");
                pedido.Representante = txtCliente.Pessoa.Região.ObterRepresentante();
            }
            else
            {
                txtRegião.Text = "";
                pedido.Representante = null;
            }
        }

        private void txtCliente_Deselecionado(object sender, EventArgs e)
        {
            pedido.Cliente = null;
            ObterRepresentante();
            Gravar();
        }

        //private void txtRepresentante_Validated(object sender, EventArgs e)
        //{
        //    pedido.Representante = txtRepresentante.Pessoa as Representante;

        //    if (pedido.Cadastrado)
        //        pedido.Atualizar();
        //}

        private void txtFuncionário_Validated(object sender, EventArgs e)
        {
            pedido.Receptor = txtFuncionário.Pessoa as Funcionário;
            pedido.Atualizar();
        }

        private void dtRecepção_Validated(object sender, EventArgs e)
        {
            pedido.DataRecepção = dtRecepção.Value;

            if (!abrindo)
            {
                AtualizarPrevisão();
                pedido.Atualizar();
            }
        }

        private void AtualizarPrevisão()
        {
            if (abrindo)
                throw new Exception("Mudança na entidade enquanto estava carregando-a");

            if (pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Conserto)
                pedido.DataPrevisão = dtRecepção.Value.AddDays(8);
            else
                pedido.DataPrevisão = dtRecepção.Value.AddDays(30);

            dtPrevisão.Value = pedido.DataPrevisão;
        }

        private void dtPrevisão_Validated(object sender, EventArgs e)
        {
            pedido.DataPrevisão = dtPrevisão.Value;
            grpObservações.Enabled = true;
            pedido.Atualizar();
        }

        private void dtConclusão_Validated(object sender, EventArgs e)
        {
            if (dtConclusão.Visible)
                pedido.DataConclusão = dtConclusão.Value;
            pedido.Atualizar();
        }

        private void txtDescrição_Validated(object sender, EventArgs e)
        {
            pedido.Observações = txtDescrição.Text;
            pedido.Atualizar();
        }

        private void btnConclusao_Click(object sender, EventArgs e)
        {
            dtConclusão.Visible = true;
            dtConclusão.Focus();
            btnConclusao.Visible = false;
            pedido.DataConclusão = dtConclusão.Value;
            btnRemoverDataConclusão.Visible = true;
            Gravar();
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            dtEntrega.Visible = true;
            dtEntrega.Focus();
            btnEntregar.Visible = false;

            pedido.DataEntrega = DadosGlobais.Instância.HoraDataAtual;
            btnRemoverDataEntrega.Visible = true;
            Gravar();

            dtEntrega.Text = ObterEntreguePor();
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            if (pedido.Cadastrado)
            {
                if (MessageBox.Show(
                    ParentForm,
                    "Deseja mesmo excluir permanentemente o pedido?",
                    "Remover pedido",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (MessageBox.Show(
                        ParentForm,
                        "ATENÇÃO!!!\n\nEsta é uma operação irreversível. Deseja mesmo excluir o pedido?",
                        "Remover conclusão",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        pedido.Descadastrar();
                        SubstituirBaseParaAnterior();
                    }
                }
            }
            else
                SubstituirBaseParaAnterior();
        }

        /// <summary>
        /// Cadastra se necessário
        /// </summary>
        /// <returns>sucesso</returns>
        void Gravar()
        {
            if (abrindo)
                return;

            if (modo == ModoEdição.Alteração)
            {
                Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.EditarPedidosConsertos);
            }

            if (pedido.Cadastrado)
                try
                {
                    pedido.Atualizar();
                }
                catch
                {
                    MessageBox.Show(
                        ParentForm,
                        "Não foi possível atualizar o pedido.",
                        "Pedido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            else 
            {
                pedido.Cadastrar();
                títuloBaseInferior1.Título = (pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Pedido ? "Pedido " : "Conserto ") + pedido.Código.ToString();
            }
        }

        private void chkDespachar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDespachar.Checked)
            {
                pedido.EntregaPedido = Entidades.PedidoConserto.Pedido.Entrega.Despachar;
                Gravar();
            }
        }

        private void chkLevar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLevar.Checked)
            {
                pedido.EntregaPedido = Entidades.PedidoConserto.Pedido.Entrega.Levar;
                Gravar();
            }
        }

        private void dtPrevisão_ValueChanged(object sender, EventArgs e)
        {
            if (dtPrevisão.Value.DayOfWeek == DayOfWeek.Sunday
                || dtPrevisão.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                lblInfoOficina.Text = "A oficina não trabalha neste dia.";

                lblInfoOficina.Visible = true;
            } else
                lblInfoOficina.Visible = false;
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            JanelaImpressão janela = JanelaImpressão.Instância;
            janela.AdicionarPedidoNaFila(pedido);
            janela.Show();
        }

        private void optPertenceCliente_CheckedChanged(object sender, EventArgs e)
        {
            pedido.PertenceAoCliente = optPertenceCliente.Checked;
            Gravar();
        }

        private void optPertenceEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            pedido.PertenceAoCliente = optPertenceCliente.Checked;
            Gravar();
        }

        private void txtValor_Validated(object sender, EventArgs e)
        {
            pedido.Valor = txtValor.Double;
            Gravar();
        }

        private void btnOficina_Click(object sender, EventArgs e)
        {
            dtOficina.Focus();
            
            pedido.DataOficina = dtOficina.Value;
            AtualizarVisibilidadeControlesDeOficina();
            Gravar();
        }


        private void dtOficina_Validated(object sender, EventArgs e)
        {
            pedido.DataOficina = dtOficina.Value;
            AtualizarVisibilidadeControlesDeOficina();
            Gravar();
        }

        private void txtCliente_TxtChanged(object sender, EventArgs e)
        {
            pedido.Cliente = txtCliente.Pessoa;

            if (pedido.Cliente == null)
                pedido.NomeDoCliente = txtCliente.Text;

            ObterRepresentante();
            Gravar();
        }

        private void btnRemoverEnvioParaOficina_Click(object sender, EventArgs e)
        {
            pedido.DataOficina = null;
            Gravar();
            AtualizarVisibilidadeControlesDeOficina();
        }

        //private void opçãoImprimir_Click(object sender, EventArgs e)
        //{
        //    JanelaImpressão janela = new JanelaImpressão();
        //    Relatório relatório = new Relatório();
        //    //ControleImpressãoVenda controle = new ControleImpressãoVenda();

        //    //controle.PrepararImpressão(relatórioVenda, venda);

        //    janela.InserirDocumento(relatório, "Recibo");

        //    janela.Abrir(this);
        //}

        private void AtualizarVisibilidadeControlesDeOficina()
        {
            if (pedido.TipoPedido == Entidades.PedidoConserto.Pedido.Tipo.Conserto)
            {
                lblOficina.Visible = true;
                dtOficina.Visible = pedido.DataOficina.HasValue;
                btnRemoverEnvioParaOficina.Visible = pedido.DataOficina.HasValue;
                btnOficina.Visible = !pedido.DataOficina.HasValue;
            }
            else
            {
                lblOficina.Visible = false;
                dtOficina.Visible = false;
                btnRemoverEnvioParaOficina.Visible = false;
                btnOficina.Visible = false;
            }
        }

        private void btnRemoverDataConclusão_Click(object sender, EventArgs e)
        {
            btnRemoverDataConclusão.Visible = false;

            pedido.DataConclusão = null;
            dtConclusão.Visible = false;
            btnConclusao.Visible = true;
            Gravar();
        }

        private void btnRemoverDataEntrega_Click(object sender, EventArgs e)
        {
            btnRemoverDataEntrega.Visible = false;
            
            pedido.DataEntrega = null;
            dtEntrega.Visible = false;
            btnEntregar.Visible = true;
            Gravar();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            // Assegura que o pedido tem código válido.
            Gravar();

            PedidoItem novo = new PedidoItem();
            novo.Pedido = (int) pedido.Código;

            novo.Cadastrar();
            AdicionarItem(novo).Focus();
        }

        private void flow_Resize(object sender, EventArgs e)
        {
            //foreach (Control c in flow.Controls)
            //{
            //    c.Width = flow.ClientRectangle.Width - 10;
            //}
        }

        private void BaseEditarPedido_Resize(object sender, EventArgs e)
        {
            AtualizarVisibilidadeEncomendaItem();
        }
    }
}
