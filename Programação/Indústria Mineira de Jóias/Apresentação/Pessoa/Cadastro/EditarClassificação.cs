using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    /// <summary>
    /// Janela para edição de classificação nova ou já existente.
    /// </summary>
    /// <remarks>
    /// A entidade alterada ou criada não é cadastrada automaticamente
    /// no banco de dados, sendo esta tarefa de responsabilidade
    /// do programador!
    /// </remarks>
    public partial class EditarClassificação : Apresentação.Formulários.JanelaExplicativa
    {
        private const string títuloNovo = "Cadastro de classificação";
        private const string títuloEditar = "Editar classificação: ";

        /// <summary>
        /// Entidade do banco de dados.
        /// </summary>
        private Entidades.Pessoa.Classificação classificação = null;

        /// <summary>
        /// Denominação original para classificações já existentes.
        /// </summary>
        /// <remarks>
        /// Esta variável é utilizada para comparar se o usuário
        /// está alterando a denominação original, para fins de
        /// alerta sobre a mudança.
        /// </remarks>
        private string denominaçãoOriginal = null;

        /// <summary>
        /// Constrói a janela com uma nova classificação.
        /// </summary>
        public EditarClassificação() : this(new Classificação())
        {
        }

        /// <summary>
        /// Constrói uma janela utilizando uma classificação já existente.
        /// </summary>
        /// <param name="classificação">
        /// Classificação já existente.
        /// </param>
        /// <remarks>
        /// Mesmo editando uma classificação já cadastrada,
        /// esta janela pode questionar ao usuário se ele não
        /// prefere criar uma nova classificação. Assim,
        /// o valor retornado pela propriedade "Classificação"
        /// pode ser de uma nova classificação não cadastrada.
        /// </remarks>
        public EditarClassificação(Entidades.Pessoa.Classificação classificação)
        {
            InitializeComponent();

            Entidades.Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.CadastroEditar);

            Classificação = classificação != null ? classificação : new Classificação();
        }

        /// <summary>
        /// Entidade de classificação.
        /// </summary>
        /// <remarks>
        /// Mesmo ao editar uma classificação já cadastrada,
        /// esta propriedade pode retornar uma nova classificação,
        /// criada no momento em que o usuário decide por não
        /// alterar uma denominação já digitada.
        /// </remarks>
        public Classificação Classificação
        {
            get { return classificação; }
            set
            {
                classificação = value;

                txtDenominação.Text = classificação.Denominação;
                txtDenominação.SelectAll();

                txtCriação.Text = classificação.Criação.ToLongDateString();

                txtMsgMarcando.Text = classificação.MsgMarcando;
                txtMsgMarcando.SelectAll();

                txtMsgDesmarcando.Text = classificação.MsgDesmarcando;
                txtMsgDesmarcando.SelectAll();

                chkQuestionarAntigos.Checked = classificação.QuestionarAntigos;
                chkAlertarConserto.Checked = classificação.AlertarPedido;
                chkAlertarCorreio.Checked = classificação.AlertarCorreio;
                chkAlertarSaída.Checked = classificação.AlertarSaída;
                chkAlertarVenda.Checked = classificação.AlertarVenda;

                if (classificação.Cadastrado)
                {
                    denominaçãoOriginal = classificação.Denominação;
                    lblTítulo.Text = títuloEditar + denominaçãoOriginal;
                }
                else
                {
                    denominaçãoOriginal = null;
                    lblTítulo.Text = títuloNovo;
                }

                if (classificação.Sistema)
                    txtDenominação.ReadOnly = true;
            }
        }

        /// <summary>
        /// Ocorre ao carregar a janela.
        /// </summary>
        private void AoCarregar(object sender, EventArgs e)
        {
            txtDenominação.Focus();
        }

        /// <summary>
        /// Ocorre ao validar a denominação.
        /// </summary>
        private void AoValidarDenominação(object sender, EventArgs e)
        {
            string novaDenominação = txtDenominação.Text.Trim();

            if (denominaçãoOriginal != null && denominaçãoOriginal != novaDenominação)
            {
                if (MessageBox.Show(
                    this,
                    "Alterar o sentido de uma denominação de uma classificação pode fazer com que cadastros antigos que tenham sido classificados por esta classificação tenham sentidos errados.\n\nVocê tem certeza que deseja alterar a denominação?\n\nEsteja ciente de que tal operação pode criar inconsistência semântica nos cadastros antigos.",
                    "Edição de classificação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                if (MessageBox.Show(
                    this,
                    "Você não prefere criar uma nova classificação ao invés de alterar uma já existente? Desta maneira não seriam afetados os cadastros antigos.",
                    "Edição de classificação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    TransformarNovaClassificação();
                    return;
                }

                classificação.Denominação = novaDenominação;
            }

            if (!classificação.Cadastrado)
                classificação.Denominação = novaDenominação;
        }

        /// <summary>
        /// Cria uma nova classificação baseada na classificação
        /// já existente.
        /// </summary>
        private void TransformarNovaClassificação()
        {
            classificação = new Classificação();

            classificação.Denominação = txtDenominação.Text.Trim();
            classificação.MsgMarcando = txtMsgMarcando.Text.Trim();
            classificação.MsgDesmarcando = txtMsgDesmarcando.Text.Trim();
            classificação.QuestionarAntigos = chkQuestionarAntigos.Checked;
            classificação.AlertarPedido = chkAlertarConserto.Checked;
            classificação.AlertarCorreio = chkAlertarCorreio.Checked;
            classificação.AlertarSaída = chkAlertarSaída.Checked;
            classificação.AlertarVenda = chkAlertarVenda.Checked;
        }

        private void AoValidarMsgMarcando(object sender, EventArgs e)
        {
            classificação.MsgMarcando = txtMsgMarcando.Text.Trim();
        }

        private void AoValidarMsgDesmarcando(object sender, EventArgs e)
        {
            classificação.MsgDesmarcando = txtMsgDesmarcando.Text.Trim();
        }

        private void AoMudarQuestionarAntigo(object sender, EventArgs e)
        {
            classificação.QuestionarAntigos = chkQuestionarAntigos.Checked;
        }

        private void AoMudarAlertarVenda(object sender, EventArgs e)
        {
            classificação.AlertarVenda = chkAlertarVenda.Checked;
        }

        private void AoMudarAlertarSaída(object sender, EventArgs e)
        {
            classificação.AlertarSaída = chkAlertarSaída.Checked;
        }

        private void AoMudarAlertarCorreio(object sender, EventArgs e)
        {
            classificação.AlertarCorreio = chkAlertarCorreio.Checked;
        }

        private void AoMudarAlertarConserto(object sender, EventArgs e)
        {
            classificação.AlertarPedido = chkAlertarConserto.Checked;
        }

        private void txtDenominação_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtDenominação.Text.Length > 0;
        }

        private void EditarClassificação_Shown(object sender, EventArgs e)
        {
            if (Classificação.Sistema)
                MessageBox.Show(
                    this,
                    "Esta é uma classificação do sistema e, portanto, não pode ser alterada a sua denominação.",
                    "Editar classificação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

