using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa.Endereço;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Endereço
{
    public class TextBoxPaís : TextBoxEndereçoBase
    {
        private País país;

        public override Entidades.Pessoa.Endereço.País País
        {
            get
            {
                if (país == null)
                    CriarNovoPaís();

                return país;
            }
            set
            {
                país = value;

                if (value == null)
                {
                    TextBox.Text = "";

                    if (Estado != null && Estado.Cadastrado)
                        Estado = null;
                }
                else
                {
                    TextBox.Text = país.Nome;

                    if (Estado != null && !Estado.Cadastrado && Estado.País != value)
                        Estado.País = value;

                    else if (Estado != null && Estado.País != null && Estado.País.Código != value.Código)
                        Estado = null;
                }
            }
        }

        protected override bool NecessárioPesquisar()
        {
            if (país == null || país.Nome != TextBox.Text)
            {
                país = null;
                return true;
            }
            else
                return false;
        }

        protected override void bgRecuperação_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            País[] países;

            países = País.ObterPaíses(TextBox.Text);

            e.Result = países;
        }

        protected override void bgRecuperação_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            País[] países = (País[])e.Result;

            if (países == null || países.Length != 1)
                CriarNovoPaís();

            else // if (países.Length == 1)
                País = países[0];

            DispararAoAlterar();
        }

        /// <summary>
        /// Cria um novo país.
        /// </summary>
        private void CriarNovoPaís()
        {
            if (bgRecuperação.IsBusy)
                bgRecuperação.CancelAsync();

            string nome = TextBox.Text.Trim();

            if (nome.Length > 0)
            {
                país = new País();
                país.Nome = nome;
            }
            else
                país = new País();

            País = país;

            país.AntesDeCadastrar += new Acesso.Comum.DbManipulação.DbManipulaçãoCancelávelHandler(CadastrarPaís);
        }

        /// <summary>
        /// Requisita do usuário dados para o cadastro do país.
        /// </summary>
        /// <param name="entidade">Entidade do país.</param>
        /// <param name="cancelar">Se deve cancelar a operação.</param>
        private void CadastrarPaís(Acesso.Comum.DbManipulação entidade, out bool cancelar)
        {
            País país = (País)entidade;

            using (EditarPaís dlg = new EditarPaís(país))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    País = dlg.País;
                    cancelar = false;

                    System.Diagnostics.Debug.Assert(País == entidade);
                }
                else
                    cancelar = true;
            }
        }
    }
}
