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
    /// TextBox para entrada de estado.
    /// </summary>
    public partial class TextBoxEstado : TextBoxEndereçoBase
    {
        private Estado estado;

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public override Estado Estado
        {
            get
            {
                if (estado == null)
                    CriarNovoEstado();

                return estado;
            }
            set
            {
                estado = value;

                if (value == null)
                {
                    TextBox.Text = "";

                    if (Localidade != null && Localidade.Cadastrado)
                        Localidade = null;
                }
                else
                {
                    TextBox.Text = value.Nome;
                    País = value.País;

                    if (Localidade != null && !Localidade.Cadastrado && Localidade.Estado != value)
                        Localidade.Estado = value;

                    else if (Localidade != null && Localidade.Estado != null && Localidade.Estado.Código != value.Código)
                        Localidade = null;
                }
            }
        }

        /// <summary>
        /// Procura pela cidade no banco de dados.
        /// </summary>
        protected override void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            Estado[] estados;

            estados = Estado.ObterEstados(TextBox.Text, true);

            e.Result = estados;
        }

        protected override void  bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Estado[] estados = (Estado[])e.Result;

            if (estados == null || estados.Length != 1)
            {
                bool ok = false;

                foreach (Estado estado in estados)
                    if (estado.Sigla.ToUpper() == TextBox.Text.ToUpper())
                    {
                        Estado = estado;
                        ok = true;
                        break;
                    }

                if (!ok)
                    CriarNovoEstado();
            }
            else // if (estados.Length == 1)
                Estado = estados[0];

            DispararAoAlterar();
        }

        /// <summary>
        /// Cria uma nova localidade.
        /// </summary>
        private void CriarNovoEstado()
        {
            if (bgRecuperação.IsBusy)
                bgRecuperação.CancelAsync();

            string nome = TextBox.Text.Trim();

            if (nome.Length > 0)
            {
                estado = new Estado();
                estado.Nome = nome;
            }
            else
                estado = new Estado();

            if (TxtPaís != null)
                estado.País = TxtPaís.País;

            estado.AntesDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoCancelávelHandler(CadastrarEstado);

            Estado = estado;
        }

        /// <summary>
        /// Requisita dados do usuário para o cadastro do estado.
        /// </summary>
        /// <param name="entidade">Estado a ser cadastrado.</param>
        /// <param name="cancelar">Se a operação deve ser cancelada.</param>
        public void CadastrarEstado(Acesso.Comum.DbManipulação entidade, out bool cancelar)
        {
            Estado estado = (Estado)entidade;

            using (EditarEstado dlg = new EditarEstado(estado))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    Estado = dlg.Estado;
                    cancelar = false;

                    System.Diagnostics.Debug.Assert(Estado == entidade);
                }
                else
                    cancelar = true;
            }
        }

        protected override bool NecessárioPesquisar()
        {
            if (estado == null || estado.Nome != TextBox.Text)
            {
                estado = null;
                return true;
            }
            else
                return false;
        }
    }
}
