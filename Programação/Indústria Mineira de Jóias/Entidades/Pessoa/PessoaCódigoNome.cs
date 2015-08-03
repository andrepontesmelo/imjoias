using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Pessoa
{
    public class PessoaCódigoNome
    {
        /// <summary>
        /// Chave primária.
        /// </summary>
        protected ulong código;

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        protected string nome;


        /// <summary>
        /// Código da pessoa.
        /// </summary>
        public ulong Código { get { return código; } }

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        public string Nome { get { return nome; } }


        /// <summary>
        /// Constrói uma pessoa com código e nome.
        /// </summary>
        /// <param name="código">Código da pessoa.</param>
        /// <param name="nome">Nome da pessoa.</param>
        public PessoaCódigoNome(ulong código, string nome)
        {
            this.código = código;
            this.nome = nome;
        }

        public static implicit operator Pessoa(PessoaCódigoNome pessoa)
        {
            return Pessoa.ObterPessoa(pessoa.código);
        }

        public static implicit operator PessoaFísica(PessoaCódigoNome pessoa)
        {
            return PessoaFísica.ObterPessoa(pessoa.código);
        }

        public static implicit operator PessoaJurídica(PessoaCódigoNome pessoa)
        {
            return PessoaJurídica.ObterPessoa(pessoa.código);
        }

        public static implicit operator Representante(PessoaCódigoNome pessoa)
        {
            return Representante.ObterPessoa(pessoa.código);
        }
    }
}
