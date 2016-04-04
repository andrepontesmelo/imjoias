using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    public class EditorPessoaBase<Item, ControleItem> : Apresentação.Formulários.EditorBase<Item, ControleItem>
        where Item : class, new()
        where ControleItem : Control, Apresentação.Formulários.IEditorItem<Item>, new()
    {
        /// <summary>
        /// Pessoa cujos endereços estão em edição.
        /// </summary>
        private Entidades.Pessoa.Pessoa pessoa;

        [DefaultValue(null), Browsable(false), ReadOnly(true)]
        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                this.pessoa = value;

                Limpar();

                AoDefinirPessoa();
            }
        }

        /// <summary>
        /// Ocorre ao definir a pessoa.
        /// </summary>
        protected virtual void AoDefinirPessoa()
        {
        }
    }
}
