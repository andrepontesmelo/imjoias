using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    /// <summary>
    /// Editor de telefones de uma pessoa.
    /// </summary>
    public partial class EditorTelefones : EditorPessoaBase<Telefone, DadosTelefone>
    {
        protected override Telefone ConstruirNovoItem()
        {
            Telefone telefone;

            telefone = new Telefone();
            telefone.Pessoa = Pessoa;

            return telefone;
        }

        protected override void AoDefinirPessoa()
        {
            base.AoDefinirPessoa();

            foreach (Telefone telefone in Pessoa.Telefones)
                Adicionar(telefone);
        }

        protected override void AoAdicionar(Telefone item)
        {
            base.AoAdicionar(item);
            Pessoa.Telefones.Adicionar(item);
        }

        protected override void AoRemover(Telefone item)
        {
            base.AoRemover(item);
            Pessoa.Telefones.Remover(item);
        }
    }
}
