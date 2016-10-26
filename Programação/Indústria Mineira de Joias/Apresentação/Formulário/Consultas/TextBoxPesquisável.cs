using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Textbox pesquisável.
    /// </summary>
    public partial class TextBoxPesquisável : UserControl
    {
        private bool mostrarPesquisa = true;

        public event EventHandler AoProcurar;
        public event EventHandler TextoAlterado;

        #region Propriedades

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return txt.ReadOnly; }
            set { txt.ReadOnly = value; }
        }

        /// <summary>
        /// Determina se deve mostrar o botão de pesquisa.
        /// </summary>
        [Description("Determina se deve mostrar o botão de pesquisa."),
        DefaultValue(true)]
        public bool MostrarPesquisa
        {
            get { return mostrarPesquisa; }
            set
            {
                mostrarPesquisa = value;
                btnProcurar.Visible = mostrarPesquisa;
            }
        }

        public TextBox TextBox
        {
            get { return txt; }
        }

        #endregion

        /// <summary>
        /// Constrói o TextBoxPesquisável.
        /// </summary>
        public TextBoxPesquisável()
        {
            InitializeComponent();

            Height = txt.Height;

            txt.ReadOnlyChanged += new EventHandler(txt_ReadOnlyChanged);
            btnProcurar.VisibleChanged += new EventHandler(btnProcurar_VisibleChanged);
        }

        void btnProcurar_VisibleChanged(object sender, EventArgs e)
        {
            if (btnProcurar.Visible)
                txt.Width = ClientSize.Width - btnProcurar.Width - txt.Left;
            else
                txt.Width = ClientSize.Width - txt.Left;
        }

        void txt_ReadOnlyChanged(object sender, EventArgs e)
        {
            btnProcurar.Visible = mostrarPesquisa && !txt.ReadOnly;
        }

        /// <summary>
        /// Ocorre ao redimensionar o TextBox.
        /// </summary>
        private void txt_Resize(object sender, EventArgs e)
        {
            Height = txt.Height;
        }

        /// <summary>
        /// Ocorre ao mudar a visibilidade do botão de procura.
        /// </summary>
        private void AoMudarVisibilidadeProcura(object sender, EventArgs e)
        {
            if (btnProcurar.Visible)
                txt.Width = ClientSize.Width - btnProcurar.Width;
            else
                txt.Width = ClientSize.Width;
        }

        /// <summary>
        /// Ocorre ao clicar em procurar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AoClicarBtnProcurar(object sender, EventArgs e)
        {
            if (AoProcurar != null)
                AoProcurar(this, e);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            OnEnter(e);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            OnLeave(e);
        }

        public override bool Focused
        {
            get
            {
                return txt.Focused || btnProcurar.Focused || base.Focused;
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        [Browsable(true), Bindable(BindableSupport.Yes), ReadOnly(true)]
        public override string Text
        {
            get
            {
                return txt.Text;
            }
            set
            {
                txt.Text = value;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (TextoAlterado != null)
                TextoAlterado(this, e);
        }
    }
}
