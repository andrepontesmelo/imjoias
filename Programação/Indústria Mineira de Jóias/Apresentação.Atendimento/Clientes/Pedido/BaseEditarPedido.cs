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

namespace Apresentação.Atendimento.Clientes.Pedido
{
    public partial class BaseEditarPedido : BaseInferior
    {
        private Entidades.Pedido pedido;
        private bool abrindo = false;
        private ModoEdição modo;

        private enum ModoEdição { Inserção, Alteração }

        public BaseEditarPedido()
        {
            InitializeComponent();
            Pedido = null;
            pedido.Receptor = Funcionário.FuncionárioAtual;
            txtFuncionário.Pessoa = pedido.Receptor;
        }

        public BaseEditarPedido(Entidades.Pedido pedido)
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

        public Entidades.Pedido Pedido
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

                    switch (pedido.TipoPedido)
                    {
                        case Entidades.Pedido.Tipo.Conserto:
                            radioConserto.Checked = true;
                            break;

                        case Entidades.Pedido.Tipo.Pedido:
                            radioEncomenda.Checked = true;
                            break;
                    }

                    switch (pedido.EntregaPedido)
                    {
                        case Entidades.Pedido.Entrega.Despachar:
                            chkDespachar.Checked = true;
                            break;

                        case Entidades.Pedido.Entrega.Levar:
                            chkLevar.Checked = true;
                            break;
                    }


                    //radioConserto.Enabled = radioEncomenda.Checked = true;

                    if (pedido.Controle.HasValue)
                        txtControle.Int = (int)pedido.Controle.Value;
                    else
                        txtControle.Text = "";

                    //txtControle.ReadOnly = true;

                    txtCliente.Pessoa = pedido.Cliente;
                    //txtCliente.ReadOnly = true;
                    //txtRepresentante.Pessoa = pedido.Representante;
                    //txtRepresentante.ReadOnly = true;
                    if (pedido.Cliente.Região != null)
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
                    }
                    else
                    {
                        dtConclusão.Visible = false;
                        dtConclusão.Enabled = true;
                        btnConclusao.Visible = true;
                    }

                    if (pedido.DataEntrega.HasValue)
                    {
                        dtEntrega.Value = pedido.DataEntrega.Value;
                        dtEntrega.Visible = true;
                        //dtEntrega.Enabled = false;
                        btnEntregar.Visible = false;
                    }
                    else
                    {
                        dtEntrega.Visible = false;
                        dtEntrega.Enabled = true;
                        btnEntregar.Visible = true;
                    }

                    txtDescrição.Text = pedido.Observações;
                    //txtDescrição.ReadOnly = true;

                    títuloBaseInferior1.Título = (pedido.TipoPedido == Entidades.Pedido.Tipo.Pedido ? "Pedido " : "Conserto ") + pedido.Código.ToString();
                    títuloBaseInferior1.Descrição = "Visualize ou edite os dados do pedido, caso necessário.";
                    grpEntrega.Visible = grpRecepção.Visible = grpObservações.Visible = true;
                }
                else
                {
                    modo = ModoEdição.Inserção;
                    pedido = new Entidades.Pedido();
                    pedido.TipoPedido = Entidades.Pedido.Tipo.Pedido;
                    radioEncomenda.Checked = true;

                    radioConserto.Checked = false;
                    
                    //txtDescrição.ReadOnly = true;

                    chkDespachar.Checked = true;
                    chkLevar.Checked = false;
                    pedido.EntregaPedido = Entidades.Pedido.Entrega.Despachar;

                    radioConserto.Enabled = radioEncomenda.Enabled = true;
                    txtControle.Text = "";
                    txtControle.ReadOnly = false;
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
                    títuloBaseInferior1.Descrição = "Entre com os dados do novo pedido ainda não cadastrado.";
                    grpEntrega.Visible = grpRecepção.Visible = grpObservações.Visible = false;
;
                }

                pedido.DepoisDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(pedido_DepoisDeCadastrar);

                if (!pedido.DataConclusão.HasValue)
                    dtEntrega.MinDate = dtConclusão.MinDate = pedido.DataRecepção;

                else if (!pedido.DataEntrega.HasValue)
                    dtEntrega.MinDate = dtConclusão.MinDate;

                bool travar = (modo == ModoEdição.Alteração && !Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.EditarPedidosConsertos));
                quadroPrivilégio.Visible = travar;

                grpIdentificação.Enabled = !travar;
                grpObservações.Enabled = !travar;
                grpRecepção.Enabled = !travar;

                // Entrega de pedidos à clientes sempre é liberada
                //grpEntrega.Enabled = !travar;


                quadroManutenção.Enabled = !travar;

                dtRecepção.Enabled = 
                    Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.EditarPedidosConsertos);


                abrindo = false;
            }
        }

        void pedido_DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            grpEntrega.Visible = grpRecepção.Visible = grpObservações.Visible = true;
            txtFuncionário.ReadOnly = false;
            títuloBaseInferior1.Título = "Pedido " + pedido.Código.ToString();
        }

        private void radioEncomenda_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEncomenda.Checked)
            {
                pedido.TipoPedido = Entidades.Pedido.Tipo.Pedido;
                títuloBaseInferior1.Título = "Pedido " + pedido.Código.ToString();
                chkDespachar.Text = "Despachar pedido";

                if (!abrindo)
                {
                    AtualizarPrevisão();
                    Gravar();
                }
            }
        }

        private void radioConserto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioConserto.Checked)
            {
                pedido.TipoPedido = Entidades.Pedido.Tipo.Conserto;
                títuloBaseInferior1.Título = "Conserto " + pedido.Código.ToString();
                chkDespachar.Text = "Despachar conserto";

                if (!abrindo)
                {
                    AtualizarPrevisão();
                    Gravar();
                }
            }
        }

        private void txtControle_Validated(object sender, EventArgs e)
        {
            if (txtControle.Int > 0)
            {
                pedido.Controle = (uint)txtControle.Int;

                Entidades.Pedido jaExistente = Entidades.Pedido.ObterPedido(pedido.Controle.Value, Pedido.TipoPedido);

                if (jaExistente != null && jaExistente.Código != pedido.Código)
                {
                    Entidades.Pessoa.Pessoa cliente = Entidades.Pessoa.PessoaCPFCNPJRG.ObterPessoa(jaExistente.Cliente.Código);

                    MessageBox.Show(
                        ParentForm,
                        string.Format("O número de controle {0} já foi utilizado em outro pedido deste tipo e portanto não pode ser reutilizado:\n\nCódigo:{1}\nCliente:{2}\nRecepção:{3}\nPrevisão:{4}\nConclusão:{5}\nEntrega:{6}",
                        pedido.Controle,
                        jaExistente.Código,
                        cliente.ToString(),
                        jaExistente.DataRecepção,
                        jaExistente.DataPrevisão,
                        jaExistente.DataConclusão,
                        jaExistente.DataEntrega),
                        "Número de controle já existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtControle.Text = "";
                    txtControle.Focus();
                    return;
                }
            }
            else
                pedido.Controle = null;

            if (pedido.Cadastrado)
                pedido.Atualizar();
        }

        private void txtCliente_Selecionado(object sender, EventArgs e)
        {
            pedido.Cliente = txtCliente.Pessoa;
            Gravar();

            ObterRepresentante();

            if (pedido.Cadastrado)
                pedido.Atualizar();
        }

        private void ObterRepresentante()
        {
            if (txtCliente.Pessoa.Região != null)
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

            if (pedido.TipoPedido == Entidades.Pedido.Tipo.Conserto)
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

        private void dtEntrega_Validated(object sender, EventArgs e)
        {
            if (dtEntrega.Visible)
                pedido.DataEntrega = dtEntrega.Value;
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
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            dtEntrega.MinDate = dtConclusão.Value;
            dtEntrega.Visible = true;
            dtEntrega.Focus();
            btnEntregar.Visible = false;
        }

        private void opçãoRemoverConclusão_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                ParentForm,
                "Deseja mesmo remover o registro de conclusão do pedido?",
                "Remover conclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (pedido.DataEntrega.HasValue)
                    MessageBox.Show(
                        ParentForm,
                        "Não é possível remover o registro de conclusão do pedido, pois ele já foi entregue.",
                        "Remover conclusão",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                else
                {
                    UseWaitCursor = true;

                    try
                    {
                        pedido.DataConclusão = null;

                        if (pedido.Cadastrado)
                            pedido.Atualizar();

                        dtConclusão.Visible = false;
                        btnConclusao.Visible = true;
                    }
                    finally
                    {
                        UseWaitCursor = false;
                    }
                }
            }
        }

        private void opçãoRemoverEntrega_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                ParentForm,
                "Deseja mesmo remover o registro de entrega do pedido?",
                "Remover entrega",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                UseWaitCursor = true;

                try
                {
                    pedido.DataEntrega = null;

                    if (pedido.Cadastrado)
                        pedido.Atualizar();

                    dtEntrega.Visible = false;
                    btnEntregar.Visible = true;
                }
                finally
                {
                    UseWaitCursor = false;
                }
            }
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
                        "Não foi possível atualizar o pedido. Certifique-se de que o número de controle e os demais dados estão corretos.",
                        "Pedido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            else if (pedido.Cliente != null)
            {
                pedido.Cadastrar();
                títuloBaseInferior1.Título = (pedido.TipoPedido == Entidades.Pedido.Tipo.Pedido ? "Pedido " : "Conserto ") + pedido.Código.ToString();
            }
        }

        private void chkDespachar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDespachar.Checked)
            {
                pedido.EntregaPedido = Entidades.Pedido.Entrega.Despachar;
                Gravar();
            }
        }

        private void chkLevar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLevar.Checked)
            {
                pedido.EntregaPedido = Entidades.Pedido.Entrega.Levar;
                Gravar();
            }
        }

        private void dtPrevisão_ValueChanged(object sender, EventArgs e)
        {
            if (dtPrevisão.Value.DayOfWeek == DayOfWeek.Sunday
                || dtPrevisão.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                lblInfoOficina.Text = "A data de previsão está marcada para"
                    + (dtPrevisão.Value.DayOfWeek == DayOfWeek.Sunday ? " domingo" : " sabado")
                    + ". No entanto, a oficina não trabalha neste dia.";

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

        //private void opçãoImprimir_Click(object sender, EventArgs e)
        //{
        //    JanelaImpressão janela = new JanelaImpressão();
        //    Relatório relatório = new Relatório();
        //    //ControleImpressãoVenda controle = new ControleImpressãoVenda();

        //    //controle.PrepararImpressão(relatórioVenda, venda);

        //    janela.InserirDocumento(relatório, "Recibo");

        //    janela.Abrir(this);
        //}
    }
}
