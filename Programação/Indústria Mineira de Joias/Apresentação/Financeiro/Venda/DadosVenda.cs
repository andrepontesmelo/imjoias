using Apresentação.Financeiro.Acerto;
using Apresentação.Formulários;
using Entidades;
using Entidades.Acerto;
using Entidades.Pagamentos;
using Entidades.Pessoa;
using Entidades.Privilégio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        public delegate void CotaçãoAlteradaDelegate(Entidades.Financeiro.Cotação cotação);
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
            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            
            if (!designMode)
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
                if (baseInferior != null && !baseInferior.ConferirTravamento())
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
                    if (baseInferior != null) baseInferior.CamposLivres = true;
                    txtVendedor.Pessoa = vendaEntidade.Vendedor;
                    if (baseInferior != null) baseInferior.CamposLivres = false;
                }
            }
        }


        private void txtVendedor_Deselecionado(object sender, EventArgs e)
        {
            if (!carregando)
            {

                //if (DesignMode)
                //    return;

                //if (baseInferior != null && !baseInferior.ConferirTravamento(true))
                //{
                //    if (vendaEntidade.Cadastrado)
                //    {
                //        txtVendedor.Focus();
                //        return;
                //    }

                //    vendaEntidade.Vendedor = null;

                //    if (vendaEntidade.Cadastrado)
                //        vendaEntidade.Atualizar();

                //    if (AoAlterarVendedor != null)
                //        AoAlterarVendedor(this, e);
                //}
                //else
                //{
                    if (baseInferior != null) baseInferior.CamposLivres = true;
                    txtVendedor.Pessoa = vendaEntidade.Vendedor;
                    if (baseInferior != null) baseInferior.CamposLivres = false;
                //}
            }
        }


        private void txtCliente_Selecionado(object sender, EventArgs e)
        {
            if (!carregando)
            {
                if (baseInferior != null && !baseInferior.ConferirTravamento())
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

                        if (baseInferior != null) baseInferior.CamposLivres = true;
                        txtCliente.Pessoa = vendaEntidade.Cliente;
                        if (baseInferior != null) baseInferior.CamposLivres = false;
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
                    if (baseInferior != null) baseInferior.CamposLivres = true;
                    txtCliente.Pessoa = vendaEntidade.Cliente;
                    if (baseInferior != null) baseInferior.CamposLivres = false;
                }
            }
        }

        private void txtCliente_Deselecionado(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            if (!carregando)
            {
                ////if (baseInferior != null && !baseInferior.ConferirTravamento(true))
                ////{
                ////    try
                ////    {
                ////        // Este código causa um travamento ao remover cliente e vendedor:
                ////        //if (vendaEntidade.Cadastrado)
                ////        //{
                ////        //    txtCliente.Focus();
                ////        //    return;
                ////        //}

                ////        txtCliente.Pessoa = vendaEntidade.Cliente;
                ////        //vendaEntidade.Cliente = null;
                ////    } 
                ////    catch (Entidades.Relacionamento.Venda.Venda.InconsistênciaEntreVendaPagamento erro)
                ////    {
                ////        MessageBox.Show(
                ////            ParentForm, erro.Message, "Edição de cliente",
                ////            MessageBoxButtons.OK, MessageBoxIcon.Error);

                ////        txtCliente.Pessoa = vendaEntidade.Cliente;

                ////        return;
                ////    }

                ////    if (vendaEntidade.Cadastrado)
                ////        vendaEntidade.Atualizar();
                ////}
                ////else
                ////{
                    if (baseInferior != null) baseInferior.CamposLivres = true;
                    txtCliente.Pessoa = vendaEntidade.Cliente;
                    if (baseInferior != null) baseInferior.CamposLivres = false;
                //}

                //if (AoAlterarCliente != null)
                //    AoAlterarCliente(sender, e);
            }
        }

        private void txtData_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtCotação_EscolheuCotação(Entidades.Financeiro.Cotação escolha)
        {
            if (!carregando)
            {
                if (baseInferior != null && !baseInferior.ConferirTravamento())
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
                    if (baseInferior != null) baseInferior.CamposLivres = true;
                    txtCotação.Valor = vendaEntidade.Cotação;
                    if (baseInferior != null) baseInferior.CamposLivres = false;
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

            if (DesignMode)
                return;

            txtCotação.Carregar();

            chkRastreada.Checked = venda.Rastreada;
            chkSedex.Checked = venda.Sedex;

            txtDiasSemJuros.Int = (int)venda.DiasSemJuros;

            txtCliente.Pessoa = venda.Cliente;
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

            AtualizarChkVendaQuitada();

            Enabled = PermissãoFuncionário.ValidarPermissão(Permissão.PersonalizarVenda);

            carregando = false;

            if (!venda.Cadastrado)
            {
                venda.Cotação = txtCotação.Valor;
                venda.DepoisDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(venda_DepoisDeCadastrar);
            }
        }

        private void AtualizarChkVendaQuitada()
        {
            if (vendaEntidade != null)
            {
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

                bool comissãoAberta = !Entidades.ComissãoCálculo.Comissão.ComissãoFechada(vendaEntidade.Código);
                chkVendaQuitada.Enabled = comissãoAberta && PermissãoFuncionário.ValidarPermissão(Permissão.ManipularComissão)
                    && vendaEntidade.Cadastrado;
            } else
            {
                chkVendaQuitada.Enabled = false;
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
            if (vendaEntidade == null)
                return;

            double valorVenda;

            try
            {
                // Evita query provocada por vendaEntidade.Valor
                valorVenda = Math.Round(vendaEntidade.Valor, 2);
            } catch (Exception err)
            {
                MessageBox.Show(this,
                    "Erro ao salvar a venda",
                    err.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                return; 
            }

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

            txtDiasSemJuros.Int = (int) vendaEntidade.DiasSemJuros; 

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
                                         vendaEntidade.DataCobrança,
                                         vendaEntidade.TaxaJuros), 2);


            double? descontoPercentual = vendaEntidade.ObterDescontoPercentual(valorVenda);

            if (descontoPercentual.HasValue)
                txtPercentualDesconto.Text = string.Format("{0}%", descontoPercentual.Value);
            else
                txtPercentualDesconto.Text = "";


            // Juros
            txtJuros.Double =
                Math.Round(Entidades.Pagamentos.Pagamento.CalcularJuros(pagamentos,
                vendaEntidade.DataCobrança, vendaEntidade.TaxaJuros), 2);


            // Dívida na data da venda
            double dívida, juros;

            vendaEntidade.CalcularDívida(valorVenda, vendaEntidade.DataCobrança,
            out dívida, out juros, listaPagamentos, prestações);

            txtSaldoDataVenda.Double = Math.Round(-dívida, 2);
            txtSaldoDataVenda.ForeColor = (dívida > 0) ? Color.Red : Color.Green;

            lblSaldoNaDataVenda.Visible = lblInfoDívida.Visible = txtSaldoDataVenda.Visible
                = txtSaldoHoje.Visible = lblSaldoHoje.Visible
            = !chkVendaQuitada.Checked;


            if (vendaEntidade.Data.Date != Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Date)
            {
                // Dívida hoje
                vendaEntidade.CalcularDívida(valorVenda, 
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

            if (prestações.Length > 0 && prestações[0].Trim().Length > 0)
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
            cmbTabela.Enabled = vendaEntidade.Itens.Count == 0 && vendaEntidade.ItensDevolução.Count == 0 && vendaEntidade.AcertoConsignado == null;
        }

        /// <summary>
        /// Verifica a venda antes de cadastra-la.
        /// </summary>
        void AntesDeCadastrarVenda(Acesso.Comum.DbManipulação obj, out bool cancelar)
        {
            Entidades.Relacionamento.Venda.Venda entidade = (Entidades.Relacionamento.Venda.Venda)obj;

            string título = "Venda não cadastrada";

            if (entidade.Cliente == null)
            {
                MessageBox.Show(ParentForm,
                    "Por favor, defina o cliente desta venda.",
                    título,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                cancelar = true;
            }
            else if (entidade.Vendedor == null)
            {
                MessageBox.Show(ParentForm,
                    "Por favor, defina o vendedor desta venda.",
                    título,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                cancelar = true;
            }
            else if (entidade.Cotação <= 0)
            {
                MessageBox.Show(ParentForm,
                    "Por favor, defina corretamente o valor da cotação a ser utilizado.",
                    título,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                cancelar = true;
            }
            else
                cancelar = false;
        }

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
                    cmbTabela.Enabled = !entidadeTravada && (vendaEntidade.Itens.Count == 0 && vendaEntidade.ItensDevolução.Count == 0 && vendaEntidade.AcertoConsignado == null);
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
            chkSedex.Enabled = true;

            AtualizarChkVendaQuitada();
        }

        /// <summary>
        /// Valida o número de controle.
        /// </summary>
        private void txtControle_Validating(object sender, CancelEventArgs e)
        {
            if (baseInferior != null && !baseInferior.ConferirTravamento())
            {
                //bool invalidar = false;

                if (txtControle.Text.Trim().Length == 0)
                    vendaEntidade.Controle = null;
                else
                    vendaEntidade.Controle = Convert.ToUInt32(txtControle.Text);
            }
         
            if (vendaEntidade.Cadastrado)
                vendaEntidade.Atualizar();

            e.Cancel = false;
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

        private void txtDesconto_Validated(object sender, EventArgs e)
        {
            if (baseInferior != null && !baseInferior.ConferirTravamento())
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
                if (baseInferior != null && !baseInferior.ConferirTravamento())
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

        private void chkVendaQuitada_CheckedChanged(object sender, EventArgs e)
        {
            bool necessárioQuitar = chkVendaQuitada.Checked && !vendaEntidade.Quitação.HasValue;
            bool necessárioDesquitar = !chkVendaQuitada.Checked && vendaEntidade.Quitação.HasValue;

            if (necessárioQuitar)
            {
                double dívida, juros;

                vendaEntidade.CalcularDívida(out dívida, out juros);

                if (dívida != 0)
                    if (MessageBox.Show(
                        ParentForm,
                        "O saldo desta venda não está nulo. Você tem certeza de que deseja quitar esta venda?",
                        "Quitação de venda",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        AtualizarChkVendaQuitada();

                        return;
                    }

                chkRastreada.Checked = false;
                vendaEntidade.Quitar();

                AtualizarChkVendaQuitada();
            }

            if (necessárioDesquitar)
                vendaEntidade.Desquitar();

            lblSaldoNaDataVenda.Visible = lblInfoDívida.Visible = txtSaldoDataVenda.Visible
                = txtSaldoHoje.Visible = lblSaldoHoje.Visible
            = !chkVendaQuitada.Checked;

            AtualizarChkVendaQuitada();
        }

        private void btnAcerto_Click(object sender, EventArgs e)
        {
            AcertoConsignado acertoMarcadoAnteriormente = vendaEntidade.AcertoConsignado;

            AcertoConsignado acerto = null;
            Entidades.Pessoa.Pessoa pessoa = null;

            if (vendaEntidade.Vendedor != null && Representante.ÉRepresentante(vendaEntidade.Vendedor))
                pessoa = vendaEntidade.Vendedor;
            else
                pessoa = vendaEntidade.Cliente;

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

            if (acerto == null && acertoMarcadoAnteriormente != null)
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

            AtualizarTravamento(vendaEntidade.TravadoEmCache);

            AoAlterarAcerto(this, EventArgs.Empty);
        }

        private void txtData_Validated(object sender, EventArgs e)
        {
            if (!carregando)
            {
                if (baseInferior != null && !baseInferior.ConferirTravamento())
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
                    if (baseInferior != null) baseInferior.CamposLivres = true;
                    txtData.Value = vendaEntidade.Data;
                    if (baseInferior != null) baseInferior.CamposLivres = false;
                }
            }

            if (AoAlterarDataVenda != null)
                AoAlterarDataVenda(sender, e);
        }

        private void txtDiasSemJuros_Validated(object sender, EventArgs e)
        {
            if (baseInferior != null && !baseInferior.ConferirTravamento())
            {
                vendaEntidade.DiasSemJuros = (uint)txtDiasSemJuros.Int;

                if (vendaEntidade.Cadastrado)
                    vendaEntidade.Atualizar();

                MostrarPreços();
                if (AoAlterarDiasSemJurosOuTaxaJuros != null)
                    AoAlterarDiasSemJurosOuTaxaJuros(sender, e);
            }
            else
                txtDiasSemJuros.Int = (int)vendaEntidade.DiasSemJuros;
        }

        private void txtTaxaJuros_Validated(object sender, EventArgs e)
        {
            if (baseInferior != null && !baseInferior.ConferirTravamento())
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

        private void btnTrocarClienteVendedor_Click(object sender, EventArgs e)
        {
            if (baseInferior != null && !baseInferior.ConferirTravamento())
            {
                Entidades.Pessoa.Pessoa clienteAntigo, vendedorAntigo;
                clienteAntigo = vendaEntidade.Cliente;
                vendedorAntigo = vendaEntidade.Vendedor;

                txtCliente.Pessoa = vendedorAntigo;
                vendaEntidade.Cliente = vendedorAntigo;

                txtVendedor.Pessoa = clienteAntigo;
                vendaEntidade.Vendedor = clienteAntigo;
            }
        }

        private void chkSedex_CheckedChanged(object sender, EventArgs e)
        {
            if (!carregando)
            {
                vendaEntidade.Sedex = chkSedex.Checked;

                if (vendaEntidade.Cadastrado)
                    vendaEntidade.Atualizar();
            }
        }
    }
}