using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;
using Apresentação.Formulários;
using Entidades;
using Entidades.Privilégio;
using Entidades.Configuração;
using Entidades.Pagamentos;
using System.Threading;
using Entidades.Acerto;
using Apresentação.Financeiro.Acerto;
using System.Collections;

namespace Apresentação.Financeiro.Venda
{
    /// <summary>
    /// Este controle carrega uma venda quando a propriedade Venda é atribuída.
    /// 
    /// Os controles gráficos de cotação, peso, etc, disparam eventos quando são alterados.
    /// Estes eventos fazem com que este controle altere Propriedades da entidade, 
    /// gravando apenas ao chamar GravarDados(), em momento escolhido pelo usuário
    /// 
    /// Como os controle gráficos também são alterados pelo programa ao abrir uma venda,
    /// é necessário a variável (abrindoVenda) para que a entidade não seja alterada 
    /// sem necessidade, o que implica em Atualizado=falso incorretamente.
    /// </summary>
    public partial class DadosVenda : UserControl
    {
        private Entidades.Relacionamento.Venda.Venda vendaEntidade;
        private BaseEditarRelacionamento baseInferior;
        private bool carregando = false;

        public delegate void CotaçãoAlteradaDelegate(Entidades.Cotação cotação);
        public event CotaçãoAlteradaDelegate CotaçãoAlterada;

        public event EventHandler AoAlterarVendedor;
        public event EventHandler AoAlterarCliente;
        public event EventHandler AoAlterarTabela;
        public event EventHandler AoAlterarAcerto;
        public event EventHandler AoAlterarDataVenda;
        public event EventHandler AoAlterarDiasSemJurosOuTaxaJuros;

        // venda está sendo carregada pelo Venda = { set; }
        //private bool abrindoVenda;

        public DadosVenda()
        {
            InitializeComponent();
        }

        public double Cotação
        {
            get { return txtCotação.Valor; }
        }

        /// <summary>
        /// Tabela que o usuário pode usar.
        /// </summary>
        public Tabela Tabela
        {
            get { return cmbTabela.Seleção; }
        }

        /// <summary>
        /// Tabelas que o usuário pode trabalhar.
        /// </summary>
        public Tabela[] Tabelas
        {
            get { return cmbTabela.ObterTabelas(); }
        }

        [Browsable(false), DefaultValue(null)]
        public Entidades.Relacionamento.Venda.Venda Venda
        {
            get { return vendaEntidade; }
        }

        private void txtVendedor_Selecionado(object sender, EventArgs e)
        {
            if (!carregando)
            {
                if (!baseInferior.ConferirTravamento(true))
                {
                    vendaEntidade.Vendedor = txtVendedor.Pessoa;

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();

                    PrepararTabelas();

                    if (AoAlterarVendedor != null)
                        AoAlterarVendedor(this, e);
                }
                else
                {
                    // Libera os campos para voltar a pessoa original
                    baseInferior.CamposLivres = true;
                    txtVendedor.Pessoa = vendaEntidade.Vendedor;
                    baseInferior.CamposLivres = false;
                }
            }
        }


        private void txtVendedor_Deselecionado(object sender, EventArgs e)
        {
            if (!carregando)
            {

                if (DesignMode)
                    return;

                if (!baseInferior.ConferirTravamento(true))
                {
                    vendaEntidade.Vendedor = null;

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();

                    if (AoAlterarVendedor != null)
                        AoAlterarVendedor(this, e);
                }
                else
                {
                    baseInferior.CamposLivres = true;
                    txtVendedor.Pessoa = vendaEntidade.Vendedor;
                    baseInferior.CamposLivres = false;
                }
            }
        }


        private void txtCliente_Selecionado(object sender, EventArgs e)
        {
            if (!carregando)
            {
                if (!baseInferior.ConferirTravamento(true))
                {
                    try
                    {
                        Apresentação.Pessoa.AlertaClassificação.Alertar(txtCliente.Pessoa, Classificação.TipoAlerta.Venda);
                    }
                    catch (PermissãoNegada erro)
                    {
                        MessageBox.Show(
                            ParentForm,
                            erro.Message,
                            "Permissão negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        baseInferior.CamposLivres = true;
                        txtCliente.Pessoa = vendaEntidade.Cliente;
                        baseInferior.CamposLivres = false;
                        return;
                    }
                    catch (Exception erro)
                    {
                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

                        MessageBox.Show(
                            ParentForm,
                            "Ocorreu um erro ao tentar verificar alertas para o cliente.",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCliente.Pessoa = null;

                        return;
                    }

                    try
                    {
                        vendaEntidade.Cliente = txtCliente.Pessoa;
                    }
                    catch (Entidades.Relacionamento.Venda.Venda.InconsistênciaEntreVendaPagamento erro)
                    {
                        MessageBox.Show(
                            ParentForm, erro.Message, "Edição de cliente",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtCliente.Pessoa = vendaEntidade.Cliente;

                        return;
                    }

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();

                    PrepararTabelas();

                    if (AoAlterarCliente != null)
                        AoAlterarCliente(sender, e);
                }
                else
                {
                    baseInferior.CamposLivres = true;
                    txtCliente.Pessoa = vendaEntidade.Cliente;
                    baseInferior.CamposLivres = false;
                }
            }
        }

        private void txtCliente_Deselecionado(object sender, EventArgs e)
        {
            if (!carregando)
            {
                if (DesignMode)
                    return;

                if (!baseInferior.ConferirTravamento(true))
                {
                    try
                    {
                        vendaEntidade.Cliente = null;
                    }
                    catch (Entidades.Relacionamento.Venda.Venda.InconsistênciaEntreVendaPagamento erro)
                    {
                        MessageBox.Show(
                            ParentForm, erro.Message, "Edição de cliente",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txtCliente.Pessoa = vendaEntidade.Cliente;

                        return;
                    }

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();
                }
                else
                {
                    baseInferior.CamposLivres = true;
                    txtCliente.Pessoa = vendaEntidade.Cliente;
                    baseInferior.CamposLivres = false;
                }

                if (AoAlterarCliente != null)
                    AoAlterarCliente(sender, e);
            }
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtCotação_EscolheuCotação(Entidades.Cotação escolha)
        {
            if (!carregando)
            {
                if (!baseInferior.ConferirTravamento(true))
                {
                    if (CotaçãoAlterada != null)
                        CotaçãoAlterada(escolha);

                    if (vendaEntidade != null)
                    {
                        vendaEntidade.Cotação = escolha;

                        if (vendaEntidade.Cadastrado)
                            vendaEntidade.Atualizar();

                        MostrarPreços();
                    }
                }
                else
                {
                    baseInferior.CamposLivres = true;
                    txtCotação.Valor = vendaEntidade.Cotação;
                    baseInferior.CamposLivres = false;
                }
            }
        }

        /// <summary>
        /// Ocorre quando uma tecla é pressionada no txtControle.
        /// </summary>
        private void txtControle_KeyPress(object sender, KeyPressEventArgs e)
        {
            // \b é backspace
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
                e.KeyChar = (char)0;
            }
        }


        public void Abrir(Entidades.Relacionamento.Venda.Venda venda, BaseEditarRelacionamento baseInferior)
        {
            this.vendaEntidade = venda;
            this.baseInferior = baseInferior;

            carregando = true;

            if (!DesignMode)
            {
                //chkAcertado.Enabled =
                //    Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.ZerarAcerto);

                //// Desregistra os eventos:
                ////chkAcertado.CheckedChanged -= new EventHandler(chkAcertado_CheckedChanged);
                //chkComissãoPaga.CheckedChanged -= new EventHandler(chkComissãoPaga_CheckedChanged);

                //chkVerificado.Checked = venda.Verificado;
                //chkAcertado.Checked = venda.Acertado;
                //chkComissãoPaga.Checked = vendaComissãoPaga;
                chkRastreada.Checked = venda.Rastreada;

                // Registra os eventos:
                //chkVerificado.CheckedChanged += new EventHandler(chkVerificado_CheckedChanged);
                //chkAcertado.CheckedChanged += new EventHandler(chkAcertado_CheckedChanged);
                //chkComissãoPaga.CheckedChanged += new EventHandler(chkComissãoPaga_CheckedChanged);
                chkRastreada.CheckedChanged += new EventHandler(chkRastreada_CheckedChanged);

                txtDiasSemJuros.Int = (int) venda.DiasSemJuros; 

                // TxtCotacao só interfere quando venda for nova
                //txtCotação.AvisarNovaCotação = !vendaEntidade.Cadastrado;
                //txtCotação.IniciarValorAtual = !vendaEntidade.Cadastrado;

                //if (venda.Cliente != null)
                txtCliente.Pessoa = venda.Cliente;

                //if (venda.Vendedor != null)
                txtVendedor.Pessoa = venda.Vendedor;

                if (venda.Cadastrado)
                    txtCotação.Valor = venda.Cotação;

                txtData.Value = venda.Data;

                if (venda.AcertoConsignado != null)
                {
                    if (venda.AcertoConsignado.Previsão.HasValue)
                        txtAcerto.Text = string.Format(
                            "{0}, {1:dd/MM/yyyy} às {1:HH:mm}",
                            venda.AcertoConsignado.Código, venda.AcertoConsignado.Previsão.Value);
                    else
                        txtAcerto.Text = venda.AcertoConsignado.Código.ToString();
                }
                else
                    txtAcerto.Text = "Não definido";

                MostrarPreços();

                if (vendaEntidade.Controle.HasValue)
                    txtControle.Text = venda.Controle.ToString();

                PrepararTabelas();

                vendaEntidade.AntesDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoCancelávelHandler(AntesDeCadastrarVenda);

                if (vendaEntidade.Quitação.HasValue)
                {
                    chkVendaQuitada.Checked = true;
                    chkVendaQuitada.Text = "Venda quitada em " + vendaEntidade.Quitação.Value.ToString();
                }
                else
                {
                    chkVendaQuitada.Checked = false;
                    chkVendaQuitada.Text = "Venda quitada";
                }

                Enabled = PermissãoFuncionário.ValidarPermissão(Permissão.PersonalizarVenda);
            }

            carregando = false;

            if (!venda.Cadastrado)
            {
                venda.Cotação = txtCotação.Valor;
                venda.DepoisDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(venda_DepoisDeCadastrar);
            }
        }

        void chkRastreada_CheckedChanged(object sender, EventArgs e)
        {
            if (!carregando)
            {
                vendaEntidade.Rastreada = chkRastreada.Checked;

                if (vendaEntidade.Cadastrado)
                    vendaEntidade.Atualizar();
            }
        }

        void venda_DepoisDeCadastrar(Acesso.Comum.DbManipulação entidade)
        {
            try
            {
                vendaEntidade.Data = txtData.Value;
            }
            catch { }
                
            vendaEntidade.Atualizar();
        }

        /// <summary>
        /// Mostra todos os dados de preços.
        /// </summary>
        public void MostrarPreços()
        {
            // Evita query provocada por vendaEntidade.Valor
            double valorVenda = Math.Round(vendaEntidade.Valor, 2);
            double créditos = Math.Round(vendaEntidade.CalcularCréditos(), 2);
            double débitos = Math.Round(vendaEntidade.CalcularDébitos(), 2);

            // Valor dos itens
            txtValorItens.Double = Math.Round(vendaEntidade.Itens.CalcularPreço(vendaEntidade.Cotação), 2);

            // Valor da devolução
            txtDevolução.Text = vendaEntidade.ValorDevolução.ToString("C",
                Entidades.Configuração.DadosGlobais.Instância.Cultura);

            // Desconto
            txtDesconto.Double = vendaEntidade.Desconto;

            // Subtotal
            txtSubtotal.Double = valorVenda;

            // Débitos
            txtValorDébitos.Double = débitos;

            // Créditos
            txtValorCréditos.Double = créditos;

            // Total
            txtTotal.Double = valorVenda + débitos - créditos;


            // Pago bruto

            List<Entidades.Pagamentos.Pagamento> listaPagamentos;
            string[] prestações = vendaEntidade.ObterPrestações(out listaPagamentos);

            List<IPagamento> pagamentos = new List<IPagamento>();
            foreach (Entidades.Pagamentos.Pagamento p in listaPagamentos)
                pagamentos.Add((IPagamento)p);

            double valorPago = Entidades.Pagamentos.Pagamento.CalcularValorPago(pagamentos);
            txtValorPago.Double = Math.Round(valorPago, 2);

            // Pago líquido
            txtValorPagoLíquido.Double = Math.Round(Entidades.Pagamentos.Pagamento.CalcularValorPagoLíquido(pagamentos,
                                         Preço.SomarDiasTabelaComercial(vendaEntidade.Data, (int)vendaEntidade.DiasSemJuros),
                                         vendaEntidade.TaxaJuros), 2);


            if (vendaEntidade.DescontoPercentual.HasValue)
                txtPercentualDesconto.Text = string.Format("{0}%", vendaEntidade.DescontoPercentual.Value);
            else
                txtPercentualDesconto.Text = "";


            // Juros
            txtJuros.Double =
                Math.Round(Entidades.Pagamentos.Pagamento.CalcularJuros(pagamentos,
                Preço.SomarDiasTabelaComercial(vendaEntidade.Data,
                (int)vendaEntidade.DiasSemJuros), vendaEntidade.TaxaJuros), 2);


            // Dívida na data da venda
            double dívida, juros;

            vendaEntidade.CalcularDívida(vendaEntidade.Data,
            out dívida, out juros, listaPagamentos, prestações);

            txtSaldoDataVenda.Double = Math.Round(-dívida, 2);
            txtSaldoDataVenda.ForeColor = (dívida > 0) ? Color.Red : Color.Green;

            lblSaldoNaDataVenda.Visible = lblInfoDívida.Visible = txtSaldoDataVenda.Visible
                = txtSaldoHoje.Visible = lblSaldoHoje.Visible
            = !chkVendaQuitada.Checked;


            if (vendaEntidade.Data.Date != Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Date)
            {
                // Dívida hoje
                vendaEntidade.CalcularDívida(
                    Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual,
                    out dívida, out juros, listaPagamentos, prestações);

                txtSaldoHoje.Double = Math.Round(-dívida, 2);
                txtSaldoHoje.ForeColor = (dívida > 0) ? Color.Red : Color.Green;

                txtSaldoHoje.Visible = true;
                lblSaldoHoje.Visible = true;
            }
            else
            {
                // Mesma data.
                txtSaldoHoje.Visible = false;
                lblSaldoHoje.Visible = false;
            }

            // Taxa de juros
            txtTaxaJuros.Text = vendaEntidade.TaxaJuros.ToString() + "% a.m.";

            // Prestações

            StringBuilder prestaçõesStr = new StringBuilder();

            foreach (string str in prestações)
            {
                if (prestaçõesStr.Length > 0)
                    prestaçõesStr.Append(" + ");

                prestaçõesStr.Append(str);
            }

            if (prestações.Length > 0)
                prestaçõesStr.Append(" dias");

            txtPrestações.Text = prestaçõesStr.ToString();
        }

        private void PrepararTabelas()
        {
            if (vendaEntidade.Vendedor != null && Representante.ÉRepresentante(vendaEntidade.Vendedor))
                cmbTabela.Setor = Setor.ObterSetor(Setor.SetorSistema.Representante);
            else if (vendaEntidade.Cliente != null && vendaEntidade.Cliente.Setor != null)
                cmbTabela.Setor = vendaEntidade.Cliente.Setor;
            else if (vendaEntidade.Vendedor != null)
                cmbTabela.Setor = vendaEntidade.Vendedor.Setor;
            else
                return;

            cmbTabela.Seleção = vendaEntidade.TabelaPreço;
            cmbTabela.Enabled = vendaEntidade.Itens.Count == 0 && vendaEntidade.ItensDevolução.Count == 0;
        }

        /// <summary>
        /// Verifica a venda antes de cadastra-la.
        /// </summary>
        void AntesDeCadastrarVenda(Acesso.Comum.DbManipulação obj, out bool cancelar)
        {
            Entidades.Relacionamento.Venda.Venda entidade = (Entidades.Relacionamento.Venda.Venda)obj;

            if (entidade.Cliente == null)
            {
                MessageBox.Show(ParentForm,
                    "Por favor, defina o cliente desta venda.",
                    "Venda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                cancelar = true;
            }
            else if (entidade.Vendedor == null)
            {
                MessageBox.Show(ParentForm,
                    "Por favor, defina o vendedor desta venda.",
                    "Venda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                cancelar = true;
            }
            else if (entidade.Cotação <= 0)
            {
                MessageBox.Show(ParentForm,
                    "Por favor, defina corretamente o valor da cotação a ser utilizado.",
                    "Venda",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                cancelar = true;
            }
            else
                cancelar = false;
        }

        //private void chkVerificado_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!carregando)
        //    {
        //        Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.VendasVerificar);
        //        vendaEntidade.Verificado = chkVerificado.Checked;

        //        if (vendaEntidade.Cadastrado)
        //            vendaEntidade.Atualizar();
        //    }
        //}

        internal void AtualizarTravamento(bool entidadeTravada)
        {
            txtCliente.ReadOnly = entidadeTravada;
            txtVendedor.ReadOnly = entidadeTravada;
            txtCotação.ReadOnly = entidadeTravada;
            txtCotação.Enabled = !entidadeTravada;
            txtControle.ReadOnly = entidadeTravada;
            txtData.Enabled = !entidadeTravada;
            txtDiasSemJuros.ReadOnly = entidadeTravada;
            txtDesconto.ReadOnly = entidadeTravada;
            txtPercentualDesconto.ReadOnly = entidadeTravada;

            try
            {
                if (vendaEntidade != null && vendaEntidade.Itens != null && vendaEntidade.ItensDevolução != null)
                    cmbTabela.Enabled = !entidadeTravada && (vendaEntidade.Itens.Count == 0 && vendaEntidade.ItensDevolução.Count == 0);
                else
                    cmbTabela.Enabled = !entidadeTravada;
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                cmbTabela.Enabled = !entidadeTravada;
            }

            btnAcerto.Enabled = !entidadeTravada;

            // Estas propriedades podem ser alteradas mesmo travado.
            //chkAcertado.Enabled = true;
            chkRastreada.Enabled = true;
        }

        /// <summary>
        /// Valida o número de controle.
        /// </summary>
        private void txtControle_Validating(object sender, CancelEventArgs e)
        {
            if (!baseInferior.ConferirTravamento(true))
            {
                //bool invalidar = false;

                if (txtControle.Text.Trim().Length == 0)
                    vendaEntidade.Controle = null;
                else
                    vendaEntidade.Controle = Convert.ToUInt32(txtControle.Text);

                // Verifica se o número de controle já existe.
                //long? codigoVenda = Entidades.Relacionamento.Venda.Venda.VerificarExistência(vendaEntidade.Controle);

                //if (codigoVenda.HasValue && codigoVenda.Value != vendaEntidade.Código)
                //{
                //    Entidades.Relacionamento.Venda.Venda vAntiga;
                //    string str;

                //    invalidar = true;

                //    /* O número de controle já foi usado, mas será que está
                //     * sendo reutilizado? Podemos verificar isso conferindo
                //     * se a venda já foi acertada.
                //     * -- Júlio, 21/10/2006
                //     */
                //    AguardeDB.Mostrar();

                //    try
                //    {
                //        vAntiga = Entidades.Relacionamento.Venda.Venda.ObterVenda(codigoVenda.Value);

                //        str = String.Format(
                //            "O número de controle {0} já foi utilizada em uma venda de {1} para {2} datada em {3:dd/MM/yyyy}.",
                //            vendaEntidade.Controle,
                //            vAntiga.Vendedor != null ? vAntiga.Vendedor.Nome : "*não informado*",
                //            vAntiga.Cliente != null ? vAntiga.Cliente.Nome : "*não informado*",
                //            vAntiga.Data);
                //    }
                //    finally
                //    {
                //        AguardeDB.Fechar();
                //    }

                //    MessageBox.Show(str, "Número de controle da venda já existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //if (vAntiga.Acertado && Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.VendasRemoverControle))
                    //{
                    //    if (MessageBox.Show(
                    //        ParentForm,
                    //        "Deseja reutilizar o número de controle " + vendaEntidade.Controle.ToString() + "?",
                    //        "Número de controle da venda já existente",
                    //        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    //        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    //    {
                    //        vAntiga.RemoverControle();
                    //        invalidar = false;
                    //    }
                    //}
                }

                //if (invalidar)
                //{
                //    txtControle.Text = "";

                //    /* Comentei o cancelamento porque senão o programa pode ficar inviabilizado de mudar a base inferior
                //        * porque fica tentando chamar este método */

                //    //e.Cancel = true;
                //    txtControle.Text = vendaEntidade.Controle.ToString();
                //    txtControle.Focus();
                //}
                //else
                //{
                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();

                    e.Cancel = false;
                //}
        }

        private void chkAcertado_CheckedChanged(object sender, EventArgs e)
        {
            //if (!carregando)
            //{
            //Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.ZerarAcerto);
            //vendaEntidade.Acertado = chkAcertado.Checked;

            //if (vendaEntidade.Cadastrado)
            //    vendaEntidade.Atualizar();
            //}
        }


        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* O padrão da cultura atual é utilizar virgula. 
             * No entanto, os funcionários utilizam o ponto do 
             * teclado numérico.
             */

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
                e.Handled = false;
            }
        }

        private void txtDesconto_Validating(object sender, CancelEventArgs e)
        {
            // bool cancelar = baseInferior.ConferirTravamento(true);

            //if (!cancelar)
            //    txtDesconto.Double = vendaEntidade.Desconto;

            /* Comentei o cancelamento porque senão o programa pode ficar inviabilizado de mudar a base inferior
             * porque fica tentando chamar este método */
            //e.Cancel = cancelar;
        }

        private void txtDesconto_Validated(object sender, EventArgs e)
        {
            if (!baseInferior.ConferirTravamento(false))
            {
                if (txtDesconto.Double != vendaEntidade.Desconto)
                {
                    vendaEntidade.Desconto = txtDesconto.Double;

                    txtPercentualDesconto.Text = string.Format("{0}%", vendaEntidade.Desconto / vendaEntidade.Valor * 100);

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();

                    MostrarPreços();
                }
            }
            else
            {
                txtPercentualDesconto.Text = string.Format("{0}%", vendaEntidade.Desconto / vendaEntidade.Valor * 100);
                txtDesconto.Double = vendaEntidade.Desconto;

            }
        }

        private void txtPercentualDesconto_Validated(object sender, EventArgs e)
        {
            double percentual;

            if (double.TryParse(txtPercentualDesconto.Text, out percentual))
            {
                if (!baseInferior.ConferirTravamento(true))
                {
                    vendaEntidade.DescontoPercentual = percentual;
                    txtDesconto.Double = vendaEntidade.Desconto;

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();

                    MostrarPreços();
                }
            }

            if (vendaEntidade.DescontoPercentual.HasValue)
                txtPercentualDesconto.Text = string.Format("{0}%", vendaEntidade.DescontoPercentual.Value);
            else
                txtPercentualDesconto.Text = "";
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (vendaEntidade != null)
                MostrarPreços();
        }

        private void cmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregando)
            {
                try
                {
                    vendaEntidade.TabelaPreço = cmbTabela.Seleção;

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(
                        ParentForm,
                        erro.Message,
                        "Alteração de tabela",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    cmbTabela.Seleção = vendaEntidade.TabelaPreço;

                    return;
                }

                if (AoAlterarTabela != null)
                    AoAlterarTabela(this, e);
            }
        }

        //private struct DadosBgAtualizar
        //{
        //    public double dívidaVenda, dívidaHoje, juros, valorTotal, 
        //        valorPago, valorPagoLíquido, valorDevolução, valorItens, valorDébitos, valorCréditos;
        //    public string prestações;
        //}

        //private void bgAtualizarPreços_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        List<Entidades.Pagamentos.Pagamento> pagamentos;
        //        List<IPagamento> listaPagamentos = new List<IPagamento>();

        //        string[] prestações = vendaEntidade.ObterPrestações(out pagamentos);
        //        foreach (Entidades.Pagamentos.Pagamento p in pagamentos) listaPagamentos.Add(p);

        //        double dívida, juros;
        //        DadosBgAtualizar dados = new DadosBgAtualizar();
        //        double valorVenda = vendaEntidade.Valor;

        //        vendaEntidade.CalcularDívida(
        //            Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual,
        //            out dívida, out juros, pagamentos, prestações);

        //        double jurosPagamentos;
        //        /* Pela definição da firma, os juros mostrados são os juros 
        //         * embutidos nos pagamentos.
        //         * Se não tem pagamentos relacionados a venda, juros = 0.
        //         */

        //        jurosPagamentos = Entidades.Pagamentos.Pagamento.CalcularJuros(listaPagamentos, Preço.SomarDiasTabelaComercial(vendaEntidade.Data, (int) vendaEntidade.DiasSemJuros), Entidades.Configuração.DadosGlobais.Instância.Juros);
                
        //        List<IPagamento> lista = new List<IPagamento>();
        //        foreach (Entidades.Pagamentos.Pagamento p in pagamentos)
        //            lista.Add((IPagamento) p);

        //        dados.valorPago = Entidades.Pagamentos.Pagamento.CalcularValorPago(lista);
                
        //        dados.valorPagoLíquido =
        //            Entidades.Pagamentos.Pagamento.CalcularValorPagoLíquido(listaPagamentos, Preço.SomarDiasTabelaComercial(vendaEntidade.Data, (int) vendaEntidade.DiasSemJuros), Entidades.Configuração.DadosGlobais.Instância.Juros);

        //        dados.valorDevolução = vendaEntidade.ValorDevolução;
        //        dados.valorDébitos = vendaEntidade.CalcularDébitos();
        //        dados.valorCréditos = vendaEntidade.CalcularCréditos();
        //        dados.valorItens = vendaEntidade.Itens.CalcularPreço(vendaEntidade.Cotação);
        //        dados.valorTotal = valorVenda;
        //        dados.dívidaHoje = dívida;
                
        //        vendaEntidade.CalcularDívida(vendaEntidade.Data,
        //            out dívida, out juros, pagamentos, prestações);

        //        dados.dívidaVenda = dívida;

        //        //dados.juros = juros;
        //        dados.juros = jurosPagamentos;

        //        dados.prestações = "";

        //        foreach (string str in prestações)
        //        {
        //            if (dados.prestações.Length > 0)
        //                dados.prestações += " + ";

        //            dados.prestações += str;
        //        }

        //        e.Result = dados;
        //    }
        //    catch
        //    {
        //        e.Cancel = true;
        //    }
        //}

        //private void bgAtualizarPreços_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (!e.Cancelled)
        //    {
        //        DadosBgAtualizar dados = (DadosBgAtualizar)e.Result;

        //        txtValorItens.Double = Math.Round(dados.valorItens, 2);
        //        txtValorDébitos.Double = Math.Round(dados.valorDébitos, 2);
        //        txtValorCréditos.Double = Math.Round(dados.valorCréditos, 2);
        //        txtDevolução.Text = dados.valorDevolução.ToString("C", Entidades.Configuração.DadosGlobais.Instância.Cultura);
        //        txtValorPago.Double = Math.Round(dados.valorPago, 2);
        //        txtValorPagoLíquido.Double = Math.Round(dados.valorPagoLíquido, 2);
        //        txtTotal.Double = Math.Round(dados.valorTotal, 2);
        //        txtJuros.Double = Math.Round(dados.juros, 2);
        //        txtPrestações.Text = dados.prestações + " dias";
        //        txtDívidaDataVenda.Double = Math.Round(Math.Abs(dados.dívidaVenda), 2);
        //        txtDívidaHoje.Double = Math.Round(Math.Abs(dados.dívidaHoje),2);

        //        if (dados.dívidaVenda > 0)
        //        {
        //            lblDívidaNaDataVenda.Text = "Dívida na data da venda:";
        //            lblDívidaNaDataVenda.ForeColor = lblInfoDívida.ForeColor = txtDívidaDataVenda.ForeColor = Color.Red;
        //        } else
        //        {
        //            lblDívidaNaDataVenda.Text = "Crédito na data da venda:";
        //            lblDívidaNaDataVenda.ForeColor = lblInfoDívida.ForeColor = txtDívidaDataVenda.ForeColor = Color.DarkBlue;
        //        }
        //        if (dados.dívidaHoje> 0)
        //        {
        //            lblDívidaHoje.Text = "Dívida hoje:";
        //            lblDívidaHoje.ForeColor = txtDívidaHoje.ForeColor = Color.Red;
        //        }
        //        else
        //        {
        //            lblDívidaHoje.Text = "Crédito hoje:";
        //            lblDívidaHoje.ForeColor = txtDívidaHoje.ForeColor = Color.DarkBlue;
        //        }

        //        txtSubtotal.Visible = lblValorVenda.Visible = true;
        //        lblDébitos.Visible = true;
        //        lblCréditos.Visible = true;
        //        txtValorDébitos.Visible = true;
        //        txtValorCréditos.Visible = true;
        //        lblItens.Visible = true;
        //        txtValorItens.Visible = true;
        //        lblValorPagoLíquido.Visible = true;
        //        txtValorPago.Visible = true;
        //        txtValorPagoLíquido.Visible = true;
        //        lblValorPago.Visible = true;
        //        txtPrestações.Visible = true;
        //        txtTotal.Visible = true;
        //        lblValorPagar.Visible = true;
        //        lblPrestações.Visible = true;
        //        lblJuros.Visible = true;
        //        txtJuros.Visible = true;
        //        lblDesconto.Visible = true;
        //        txtDevolução.Visible = lblDevolução.Visible = true;

        //        lblDívidaNaDataVenda.Visible = lblInfoDívida.Visible = txtDívidaDataVenda.Visible
        //            = txtDívidaHoje.Visible = lblDívidaHoje.Visible
        //        = !chkVendaQuitada.Checked;
        //    }
        //}

        private void chkVendaQuitada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVendaQuitada.Checked && !vendaEntidade.Quitação.HasValue)
            {
                foreach (Entidades.Pagamentos.Pagamento pagamento in Entidades.Pagamentos.Pagamento.ObterPagamentos(vendaEntidade))
                    if (pagamento.Pendente)
                    {
                        chkVendaQuitada.Checked = false;
                        MessageBox.Show(
                            ParentForm,
                            "Não é possível marcar esta venda como quitada, pois existem pagamentos pendentes.",
                            "Quitação de venda",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                double dívida, juros;

                vendaEntidade.CalcularDívida(out dívida, out juros);

                if (dívida != 0)
                    if (MessageBox.Show(
                        ParentForm,
                        "O saldo desta venda não está nula. Você tem certeza de que deseja quitar esta venda?",
                        "Quitação de venda",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        chkVendaQuitada.Checked = false;
                        return;
                    }

                vendaEntidade.Quitar();

                chkVendaQuitada.Text = "Venda quitada em " + vendaEntidade.Quitação.Value.ToString();

            }

            lblSaldoNaDataVenda.Visible = lblInfoDívida.Visible = txtSaldoDataVenda.Visible
                = txtSaldoHoje.Visible = lblSaldoHoje.Visible
            = !chkVendaQuitada.Checked;
        }

        private void btnAcerto_Click(object sender, EventArgs e)
        {
            AcertoConsignado acerto = null;
            Entidades.Pessoa.Pessoa pessoa = null;

            if (vendaEntidade.Vendedor != null && Representante.ÉRepresentante(vendaEntidade.Vendedor))
                pessoa = vendaEntidade.Vendedor;
            else
                pessoa = vendaEntidade.Cliente;

            //ArrayList pessoas = new ArrayList();

            //if (vendaEntidade.Pessoa != null)
            //    pessoas.Add(vendaEntidade.Pessoa);

            //if (vendaEntidade.Vendedor != null)
            //    pessoas.Add(vendaEntidade.Vendedor);

            //if (pessoas.Count > 1)
            //{
            //    using (Apresentação.Pessoa.Consultas.SelecionarPessoa dlg = new Apresentação.Pessoa.Consultas.SelecionarPessoa(pessoas, ""))
            //    {
            //        if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
            //            pessoa = dlg.PessoaEscolhida;
            //    }
            //}

            if (pessoa != null)
            {
                acerto = EscolherAcerto.QuestionarUsuário(ParentForm, pessoa, false);

                if (acerto != null && acerto.Acertado)
                {
                    MessageBox.Show(
                        ParentForm,
                        "Não é permitido mover documentos para um acerto já encerrado.\n\nOperação cancelada.",
                        "Mover para outro acerto",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            if (acerto == null)
                if (MessageBox.Show(
                    ParentForm,
                    "Deseja desvincular a venda do acerto?",
                    "Acerto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

            AguardeDB.Mostrar();

            try
            {
                if (vendaEntidade.AcertoConsignado == null || !vendaEntidade.AcertoConsignado.Equals(acerto))
                {
                    if (acerto != null && !acerto.Cadastrado)
                        acerto.Cadastrar();

                    if (vendaEntidade.AcertoConsignado != null)
                        vendaEntidade.AcertoConsignado.Remover(vendaEntidade);

                    if (acerto != null)
                        try
                        {
                            acerto.Adicionar(vendaEntidade);
                        }
                        catch (Entidades.Acerto.AcertoConsignado.DocumentoInconsistente erro)
                        {
                            MessageBox.Show(
                                ParentForm,
                                erro.Message,
                                "Editar venda",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();
                }
            }
            finally
            {
                AguardeDB.Fechar();
            }

            if (vendaEntidade.AcertoConsignado != null)
            {
                if (vendaEntidade.AcertoConsignado.Previsão.HasValue)
                    txtAcerto.Text = string.Format(
                        "{0}, {1:dd/MM/yyyy} às {1:HH:mm}",
                        vendaEntidade.AcertoConsignado.Código, vendaEntidade.AcertoConsignado.Previsão.Value);
                else
                    txtAcerto.Text = vendaEntidade.AcertoConsignado.Código.ToString();
            }
            else
                txtAcerto.Text = "Não definido";

            AoAlterarAcerto(this, EventArgs.Empty);
        }

        private void txtData_Validated(object sender, EventArgs e)
        {
            if (!carregando)
            {
                if (!baseInferior.ConferirTravamento(true))
                {
                    if (vendaEntidade.Data != txtData.Value.Date)
                    {
                        vendaEntidade.Data = txtData.Value.Date;

                        if (vendaEntidade.Cadastrado)
                            vendaEntidade.Atualizar();
                    }

                    //(atualmente não funciona)?
                    txtCotação.Data = txtData.Value;

                    MostrarPreços();
                }
                else
                {
                    baseInferior.CamposLivres = true;
                    txtData.Value = vendaEntidade.Data;
                    baseInferior.CamposLivres = false;
                }
            }

            if (AoAlterarDataVenda != null)
                AoAlterarDataVenda(sender, e);
        }

        private void txtDiasSemJuros_Validated(object sender, EventArgs e)
        {
            if (!baseInferior.ConferirTravamento(true))
            {
                vendaEntidade.DiasSemJuros = (uint)txtDiasSemJuros.Int;

                if (vendaEntidade.Cadastrado)
                    vendaEntidade.Atualizar();

                MostrarPreços();
                if (AoAlterarDiasSemJurosOuTaxaJuros != null)
                    AoAlterarDiasSemJurosOuTaxaJuros(sender, e);
            }
            else
            {
                txtDiasSemJuros.Int = (int)vendaEntidade.DiasSemJuros;
            }
        }

        private void txtTaxaJuros_Validated(object sender, EventArgs e)
        {
            if (!baseInferior.ConferirTravamento(true))
            {
                Double d;

                if (Double.TryParse(txtTaxaJuros.Text.Trim(), out d))
                {
                    vendaEntidade.TaxaJuros = d;

                    if (vendaEntidade.Cadastrado)
                        vendaEntidade.Atualizar();

                    MostrarPreços();

                    if (AoAlterarDiasSemJurosOuTaxaJuros != null)
                        AoAlterarDiasSemJurosOuTaxaJuros(sender, e);
                }
            }
            else
            {
                txtTaxaJuros.Text = vendaEntidade.TaxaJuros.ToString() + "% a.m.";
            }
        }
    }
}
