using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Cadastro
{
    /// <summary>
    /// Editor de endereços de uma pessoa.
    /// </summary>
    public partial class EditorEndereços : EditorPessoaBase<Entidades.Pessoa.Endereço.Endereço, DadosEndereço>
    {
        protected override Entidades.Pessoa.Endereço.Endereço ConstruirNovoItem()
        {
            return new Entidades.Pessoa.Endereço.Endereço(Pessoa);
        }

        protected override void AoDefinirPessoa()
        {
            base.AoDefinirPessoa();

            foreach (Entidades.Pessoa.Endereço.Endereço endereço in Pessoa.Endereços)
                Adicionar(endereço);
        }

        protected override void AoAdicionar(Entidades.Pessoa.Endereço.Endereço item)
        {
            base.AoAdicionar(item);
            Pessoa.Endereços.Adicionar(item);
        }

        protected override void AoRemover(Entidades.Pessoa.Endereço.Endereço item)
        {
            base.AoRemover(item);
            Pessoa.Endereços.Remover(item);
        }
    }
}
