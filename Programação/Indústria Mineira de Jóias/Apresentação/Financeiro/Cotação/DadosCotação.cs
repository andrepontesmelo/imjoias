using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Entidades.Privilégio;
using Apresentação.Financeiro.Indicadores;
using Entidades.Pessoa;
using Apresentação.Formulários;
using Entidades.Configuração;
using System.Drawing.Drawing2D;

namespace Apresentação.Financeiro.Cotação
{
    /// <summary>
    /// Permite exibição e edição da cotação de uma moeda.
    /// </summary>
    public partial class DadosCotação : QuadroSimples
    {
        private Moeda moeda;
        private Entidades.Financeiro.Cotação cotação;
        BaseCotações baseCotações;

        public DadosCotação(BaseCotações pai)
        {
            InitializeComponent();

            this.baseCotações = pai;
            lnkAtualizar.Enabled = PermissãoFuncionário.ValidarPermissão(Permissão.EditarCotação);
        }

        /// <summary>
        /// Moeda a ser trabalhada.
        /// </summary>
        [DefaultValue(null), ReadOnly(true)]
        public Moeda Moeda
        {
            get { return moeda; }
            set
            {
                this.moeda = value;

                if (moeda != null)
                {
                    lblMoeda.Text = moeda.Nome;

                    if (moeda.Ícone != null)
                        picMoeda.Image = moeda.Ícone;
                    else
                        picMoeda.Image = Resource.moeda;

                    txtCotação.MaxDecimalPlaces = moeda.CasasDecimais;

                    ExibirCotaçãoVigente();
                }
                else
                {
                    lblAtualização.Text = "";
                    txtCotação.Text = "";
                    lblValor.Text = "N/D";
                    lblMoeda.Text = "Moeda";
                    picMoeda.Image = Resource.moeda;
                    lblVariação.Text = "";
                    picVariação.Image = null;
                }
            }
        }

        /// <summary>
        /// Mostra a cotação vigente.
        /// </summary>
        private void ExibirCotaçãoVigente()
        {
            try
            {
                double variação;

                cotação = Entidades.Financeiro.Cotação.ObterCotaçãoVigente(moeda);

                if (cotação.Data.HasValue)
                    lblAtualização.Text = string.Format(
                        "Atualizado por {0} em {1:dd/MM/yy} às {1:HH:mm}.",
                        cotação.Funcionário.PrimeiroNome,
                        cotação.Data.Value);
                else
                    lblAtualização.Text = "";

                txtCotação.Visible = false;
                txtCotação.Double = cotação.Valor;
                txtCotação.BackColor = BackColor;
                lblValor.Text = cotação.ValorFormatado;
                lblValor.Visible = true;

                try
                {
                    variação = cotação.CalcularVariaçãoPercentual();

                    if (!double.IsInfinity(variação))
                    {
                        lblVariação.Text = string.Format("{0}{1:##0.00}%",
                            variação >= 0 ? "+" : "",
                            variação * 100);

                        if (variação >= 0)
                        {
                            picVariação.Image = Resource.VariaçãoPositiva;
                            lblVariação.ForeColor = Color.Green;
                        }
                        else
                        {
                            picVariação.Image = Resource.VariaçãoNegativa;
                            lblVariação.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        lblVariação.Text = "";
                        picVariação.Image = null;
                    }
                }
                catch
                {
                    lblVariação.Text = "";
                    picVariação.Image = null;
                }
            }
            catch (Entidades.Financeiro.Cotação.CotaçãoInexistente)
            {
                lblAtualização.Text = "Cotação nunca registrada.";
                txtCotação.Text = "";
                lblValor.Text = "N/D";
                lblVariação.Text = "";
                picVariação.Image = null;
            }
            finally
            {
                //txtCotação.ReadOnly = true;
                lnkAtualizar.Text = "Editar";
                lnkAtualizar.Enabled = PermissãoFuncionário.ValidarPermissão(Permissão.EditarCotação);
                lnkCancelar.Visible = false;
            }
        }

        /// <summary>
        /// Exibe janela com histórico de cotações.
        /// </summary>
        private void lnkVisualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JanelaHistóricoCotação dlg = new JanelaHistóricoCotação(moeda);

            dlg.ShowDialog();
            baseCotações.CarregarCotações();
        }

        /// <summary>
        /// Prepara atualização da cotação ou registra a atualização
        /// no banco de dados.
        /// </summary>
        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCotação.ReadOnly || !txtCotação.Visible)
            {
                IniciarEdição();
            }
            /* Se for do mesmo dia, talvez o usuário queira corrigir
             * a cotação digitada.
             */
            else if (cotação != null && cotação.Data.HasValue
                && cotação.Data.Value.Date == DadosGlobais.Instância.HoraDataAtual.Date)
            {
                DialogResult resposta;

                resposta = MessageBox.Show(
                    ParentForm,
                    "Você deseja manter no histórico a cotação anterior?\n\nSe você responder que não, a cotação anterior será excluída do banco de dados.",
                    string.Format("{0} - Cotação", moeda.Nome),
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (resposta)
                {
                    case DialogResult.Yes:
                        CadastrarNovaCotação();
                        break;

                    case DialogResult.No:
                        if (MessageBox.Show(
                            ParentForm,
                            "Você tem certeza que deseja excluir a cotação anterior do histórico?\n\nFaça isso somente se aquela cotação estiver errada.",
                            string.Format("{0} - Cotação", moeda.Nome),
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            SubstituirCotação();
                            break;
                        }
                        else
                            goto case DialogResult.Cancel;

                    case DialogResult.Cancel:
                        MessageBox.Show(
                            ParentForm,
                            "Nenhuma modificação foi feita no banco de dados.",
                            string.Format("{0} - Cotação", moeda.Nome),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else
                CadastrarNovaCotação();
        }

        private void IniciarEdição()
        {
            lblValor.Visible = false;
            lblAtualização.Text = "Em edição por " + Funcionário.FuncionárioAtual.Nome;
            lnkAtualizar.Text = "Atualizar";
            txtCotação.ReadOnly = false;
            txtCotação.Visible = true;
            txtCotação.Clear();
            txtCotação.Focus();
            lnkCancelar.Visible = true;
            picVariação.Image = null;
            lblVariação.Text = "";
        }

        /// <summary>
        /// Substitui a cotação existente.
        /// </summary>
        private void SubstituirCotação()
        {
            AguardeDB.Mostrar();

            try
            {
                cotação.Descadastrar();
                cotação = null;
                CadastrarNovaCotação();
            }
            finally
            {
                AguardeDB.Fechar();

                if (cotação == null)
                    MessageBox.Show(
                        ParentForm,
                        "Não foi possível cadastrar a nova cotação, porém a anterior foi removida.",
                        string.Format("{0} - Cotação", moeda.Nome),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cadastra nova cotação no banco de dados.
        /// </summary>
        private void CadastrarNovaCotação()
        {
            // Cadastra cotação.
            AguardeDB.Mostrar();

            try
            {
                try
                {
                    if (!Entidades.Financeiro.Cotação.VerificarValor(moeda, txtCotação.Double))
                    {
                        AguardeDB.Suspensão(true);

                        if (MessageBox.Show(
                            ParentForm,
                            string.Format("O valor {0} para a cotação de {1} encontra-se distante dos últimos valores registrados.\n\nEste valor está correto?",
                            txtCotação.Double, moeda.Nome),
                            string.Format("{0} - Cotação", moeda.Nome),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.No)
                        {
                            AguardeDB.Suspensão(false);
                            txtCotação.Focus();
                            txtCotação.SelectAll();
                            return;
                        }
                    }
                    cotação = Entidades.Financeiro.Cotação.RegistrarCotação(moeda, txtCotação.Double);
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

                    AguardeDB.Suspensão(true);

                    MessageBox.Show(
                        ParentForm,
                        "Não foi possível atualizar a cotação.",
                        string.Format("{0} - Cotação", moeda.Nome),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    AguardeDB.Suspensão(false);
                }
                ExibirCotaçãoVigente();
            }
            finally
            {
                AguardeDB.Fechar();
            }
        }

        /// <summary>
        /// Cancela edição de cotação.
        /// </summary>
        private void lnkCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExibirCotaçãoVigente();
        }

        private void txtCotação_TextChanged(object sender, EventArgs e)
        {
            if (cotação != null && txtCotação.Double != cotação.Valor && !lnkCancelar.Visible)
                IniciarEdição();
        }

        private void txtCotação_Leave(object sender, EventArgs e)
        {
            if (cotação == null || txtCotação.Double != cotação.Valor)
                txtCotação.BackColor = Color.Red;
        }

        private void txtCotação_Enter(object sender, EventArgs e)
        {
            txtCotação.BackColor = BackColor;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtCotação.BackColor = BackColor;
        }

        private void txtCotação_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                lnkAtualizar_LinkClicked(this, null);
        }
    }
}
