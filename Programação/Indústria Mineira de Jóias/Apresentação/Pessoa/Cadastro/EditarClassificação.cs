using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa.Cadastro
{
    /// <summary>
    /// Janela para edi��o de classifica��o nova ou j� existente.
    /// </summary>
    /// <remarks>
    /// A entidade alterada ou criada n�o � cadastrada automaticamente
    /// no banco de dados, sendo esta tarefa de responsabilidade
    /// do programador!
    /// </remarks>
    public partial class EditarClassifica��o : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private const string t�tuloNovo = "Cadastro de classifica��o";
        private const string t�tuloEditar = "Editar classifica��o: ";

        /// <summary>
        /// Entidade do banco de dados.
        /// </summary>
        private Entidades.Pessoa.Classifica��o classifica��o = null;

        /// <summary>
        /// Denomina��o original para classifica��es j� existentes.
        /// </summary>
        /// <remarks>
        /// Esta vari�vel � utilizada para comparar se o usu�rio
        /// est� alterando a denomina��o original, para fins de
        /// alerta sobre a mudan�a.
        /// </remarks>
        private string denomina��oOriginal = null;

        /// <summary>
        /// Constr�i a janela com uma nova classifica��o.
        /// </summary>
        public EditarClassifica��o() : this(new Classifica��o())
        {
        }

        /// <summary>
        /// Constr�i uma janela utilizando uma classifica��o j� existente.
        /// </summary>
        /// <param name="classifica��o">
        /// Classifica��o j� existente.
        /// </param>
        /// <remarks>
        /// Mesmo editando uma classifica��o j� cadastrada,
        /// esta janela pode questionar ao usu�rio se ele n�o
        /// prefere criar uma nova classifica��o. Assim,
        /// o valor retornado pela propriedade "Classifica��o"
        /// pode ser de uma nova classifica��o n�o cadastrada.
        /// </remarks>
        public EditarClassifica��o(Entidades.Pessoa.Classifica��o classifica��o)
        {
            InitializeComponent();

            Entidades.Privil�gio.Permiss�oFuncion�rio.AssegurarPermiss�o(Entidades.Privil�gio.Permiss�o.CadastroEditar);

            Classifica��o = classifica��o != null ? classifica��o : new Classifica��o();
        }

        /// <summary>
        /// Entidade de classifica��o.
        /// </summary>
        /// <remarks>
        /// Mesmo ao editar uma classifica��o j� cadastrada,
        /// esta propriedade pode retornar uma nova classifica��o,
        /// criada no momento em que o usu�rio decide por n�o
        /// alterar uma denomina��o j� digitada.
        /// </remarks>
        public Classifica��o Classifica��o
        {
            get { return classifica��o; }
            set
            {
                classifica��o = value;

                txtDenomina��o.Text = classifica��o.Denomina��o;
                txtDenomina��o.SelectAll();

                txtCria��o.Text = classifica��o.Cria��o.ToLongDateString();

                txtMsgMarcando.Text = classifica��o.MsgMarcando;
                txtMsgMarcando.SelectAll();

                txtMsgDesmarcando.Text = classifica��o.MsgDesmarcando;
                txtMsgDesmarcando.SelectAll();

                chkQuestionarAntigos.Checked = classifica��o.QuestionarAntigos;
                chkAlertarConserto.Checked = classifica��o.AlertarPedido;
                chkAlertarCorreio.Checked = classifica��o.AlertarCorreio;
                chkAlertarSa�da.Checked = classifica��o.AlertarSa�da;
                chkAlertarVenda.Checked = classifica��o.AlertarVenda;

                if (classifica��o.Cadastrado)
                {
                    denomina��oOriginal = classifica��o.Denomina��o;
                    lblT�tulo.Text = t�tuloEditar + denomina��oOriginal;
                }
                else
                {
                    denomina��oOriginal = null;
                    lblT�tulo.Text = t�tuloNovo;
                }

                if (classifica��o.Sistema)
                    txtDenomina��o.ReadOnly = true;
            }
        }

        /// <summary>
        /// Ocorre ao carregar a janela.
        /// </summary>
        private void AoCarregar(object sender, EventArgs e)
        {
            txtDenomina��o.Focus();
        }

        /// <summary>
        /// Ocorre ao validar a denomina��o.
        /// </summary>
        private void AoValidarDenomina��o(object sender, EventArgs e)
        {
            string novaDenomina��o = txtDenomina��o.Text.Trim();

            if (denomina��oOriginal != null && denomina��oOriginal != novaDenomina��o)
            {
                if (MessageBox.Show(
                    this,
                    "Alterar o sentido de uma denomina��o de uma classifica��o pode fazer com que cadastros antigos que tenham sido classificados por esta classifica��o tenham sentidos errados.\n\nVoc� tem certeza que deseja alterar a denomina��o?\n\nEsteja ciente de que tal opera��o pode criar inconsist�ncia sem�ntica nos cadastros antigos.",
                    "Edi��o de classifica��o",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                if (MessageBox.Show(
                    this,
                    "Voc� n�o prefere criar uma nova classifica��o ao inv�s de alterar uma j� existente? Desta maneira n�o seriam afetados os cadastros antigos.",
                    "Edi��o de classifica��o",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    TransformarNovaClassifica��o();
                    return;
                }

                classifica��o.Denomina��o = novaDenomina��o;
            }

            if (!classifica��o.Cadastrado)
                classifica��o.Denomina��o = novaDenomina��o;
        }

        /// <summary>
        /// Cria uma nova classifica��o baseada na classifica��o
        /// j� existente.
        /// </summary>
        private void TransformarNovaClassifica��o()
        {
            classifica��o = new Classifica��o();

            classifica��o.Denomina��o = txtDenomina��o.Text.Trim();
            classifica��o.MsgMarcando = txtMsgMarcando.Text.Trim();
            classifica��o.MsgDesmarcando = txtMsgDesmarcando.Text.Trim();
            classifica��o.QuestionarAntigos = chkQuestionarAntigos.Checked;
            classifica��o.AlertarPedido = chkAlertarConserto.Checked;
            classifica��o.AlertarCorreio = chkAlertarCorreio.Checked;
            classifica��o.AlertarSa�da = chkAlertarSa�da.Checked;
            classifica��o.AlertarVenda = chkAlertarVenda.Checked;
        }

        private void AoValidarMsgMarcando(object sender, EventArgs e)
        {
            classifica��o.MsgMarcando = txtMsgMarcando.Text.Trim();
        }

        private void AoValidarMsgDesmarcando(object sender, EventArgs e)
        {
            classifica��o.MsgDesmarcando = txtMsgDesmarcando.Text.Trim();
        }

        private void AoMudarQuestionarAntigo(object sender, EventArgs e)
        {
            classifica��o.QuestionarAntigos = chkQuestionarAntigos.Checked;
        }

        private void AoMudarAlertarVenda(object sender, EventArgs e)
        {
            classifica��o.AlertarVenda = chkAlertarVenda.Checked;
        }

        private void AoMudarAlertarSa�da(object sender, EventArgs e)
        {
            classifica��o.AlertarSa�da = chkAlertarSa�da.Checked;
        }

        private void AoMudarAlertarCorreio(object sender, EventArgs e)
        {
            classifica��o.AlertarCorreio = chkAlertarCorreio.Checked;
        }

        private void AoMudarAlertarConserto(object sender, EventArgs e)
        {
            classifica��o.AlertarPedido = chkAlertarConserto.Checked;
        }

        private void txtDenomina��o_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtDenomina��o.Text.Length > 0;
        }

        private void EditarClassifica��o_Shown(object sender, EventArgs e)
        {
            if (Classifica��o.Sistema)
                MessageBox.Show(
                    this,
                    "Esta � uma classifica��o do sistema e, portanto, n�o pode ser alterada a sua denomina��o.",
                    "Editar classifica��o",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

