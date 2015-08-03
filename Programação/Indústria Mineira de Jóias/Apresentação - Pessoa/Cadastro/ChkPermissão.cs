using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Pessoa.Cadastro
{
    class ChkPermissão : System.Windows.Forms.CheckBox
    {
        private Entidades.Privilégio.Permissão privilégio = Entidades.Privilégio.Permissão.Nenhuma;

        /// <summary>
        /// Privilégio necessário.
        /// </summary>
        public Entidades.Privilégio.Permissão Privilégio
        {
            get { return privilégio; }
            set { privilégio = value; }
        }

        private Permissões ControlePermissões
        {
            get
            {
                System.Windows.Forms.Control controle = Parent;

                while (!(controle is Permissões))
                    controle = controle.Parent;

                return (Permissões)controle;
            }
        }

        /// <summary>
        /// Ocorre ao criar o controle.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                Enabled = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(privilégio);
            }
        }

        /// <summary>
        /// Ocorre ao alterar a entidade.
        /// </summary>
        internal void AoAlterarEntidade(Entidades.Pessoa.Funcionário funcionário)
        {
            Checked = (funcionário.Privilégios & privilégio) > 0;
        }

        /// <summary>
        /// Ocorre ao mudar a marcação.
        /// </summary>
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);

            if (!DesignMode)
                if (Checked)
                    ControlePermissões.Entidade.Privilégios |= privilégio;
                else
                    ControlePermissões.Entidade.Privilégios &= ~privilégio;
        }
    }
}
