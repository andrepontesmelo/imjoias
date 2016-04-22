using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários.Consultas;
using Entidades.Pessoa.Endereço;
using Apresentação.Formulários;

namespace Apresentação.Pessoa.Endereço
{
    /// <summary>
    /// TextBox para entrada de dados.
    /// </summary>
    public abstract partial class TextBoxEndereçoBase : Apresentação.Formulários.TextBoxPesquisável
    {
        private TextBoxLocalidade txtLocalidade;
        private TextBoxEstado txtEstado;
        private TextBoxPaís txtPaís;

        public event EventHandler AoAlterar;

        #region Propriedades

        /// <summary>
        /// TextBox para edição de localidade.
        /// </summary>
        [DefaultValue(null)]
        public TextBoxLocalidade TxtLocalidade
        {
            get { return txtLocalidade; }
            set
            {
                txtLocalidade = value;

                if (txtEstado != null && txtEstado != this && txtEstado.TxtLocalidade != value)
                    txtEstado.TxtLocalidade = value;

                if (txtPaís != null && txtPaís != this && txtPaís.TxtLocalidade != value)
                    txtPaís.TxtLocalidade = value;
            }
        }

        /// <summary>
        /// TextBox para edição de estado.
        /// </summary>
        [DefaultValue(null)]
        public TextBoxEstado TxtEstado
        {
            get { return txtEstado; }
            set
            {
                txtEstado = value;

                if (txtLocalidade != null && txtLocalidade != this && txtLocalidade.TxtEstado != value)
                    txtLocalidade.TxtEstado = value;

                if (txtPaís != null && txtPaís != this && txtPaís.TxtEstado != value)
                    txtPaís.TxtEstado = value;
            }
        }

        /// <summary>
        /// Textbox para edição de país.
        /// </summary>
        [DefaultValue(null)]
        public TextBoxPaís TxtPaís
        {
            get { return txtPaís; }
            set
            {
                txtPaís = value;

                if (txtLocalidade != null && txtLocalidade != this && txtLocalidade.TxtPaís != value)
                    txtLocalidade.TxtPaís = value;

                if (txtEstado != null && txtEstado != this && txtEstado.TxtPaís != value)
                    txtEstado.TxtPaís = value;
            }
        }

        /// <summary>
        /// Valor da localidade.
        /// </summary>
        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public virtual Localidade Localidade
        {
            get { return txtLocalidade.Localidade; }
            set { txtLocalidade.Localidade = value; }
        }

        /// <summary>
        /// Valor do estado.
        /// </summary>
        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public virtual Estado Estado
        {
            get { return txtEstado.Estado; }
            set { txtEstado.Estado = value; }
        }

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public virtual País País
        {
            get { return txtPaís.País; }
            set { txtPaís.País = value; }
        }

        #endregion

        /// <summary>
        /// Constrói o TextBoxLocalidade.
        /// </summary>
        public TextBoxEndereçoBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ocorre ao clicar no botão procurar.
        /// </summary>
        protected override void AoClicarBtnProcurar(object sender, EventArgs e)
        {
            Localidade localidade;

            base.AoClicarBtnProcurar(sender, e);

            localidade = ProcurarLocalidade.Procurar(ParentForm);

            if (localidade != null)
            {
                Localidade = localidade;
                DispararAoAlterar();
            }
        }

        /// <summary>
        /// Ocorre ao perder o foco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (NecessárioPesquisar())
            {
                if (!bgRecuperação.IsBusy)
                    bgRecuperação.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Verifica se é necessário pesquisar pelo valor entrado.
        /// </summary>
        /// <returns></returns>
        protected abstract bool NecessárioPesquisar();

        /// <summary>
        /// Ocorre ao ganhar o foco.
        /// </summary>
        private void TextBoxLocalidade_Enter(object sender, EventArgs e)
        {
            try
            {
                if (bgRecuperação.IsBusy)
                    bgRecuperação.CancelAsync();
            }
            catch { }
        }

        /// <summary>
        /// Procura pela cidade no banco de dados.
        /// </summary>
        protected abstract void bgRecuperação_DoWork(object sender, DoWorkEventArgs e);

        protected abstract void bgRecuperação_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e);

        protected void DispararAoAlterar()
        {
            if (AoAlterar != null)
                AoAlterar(this, new EventArgs());
        }
    }
}
