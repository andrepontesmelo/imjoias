using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Data;

namespace Entidades.Álbum
{
    [Cacheável("ObterÍconeSemCache"), NãoCopiarCache, Validade(0, 1, 0)]
    public class Ícone : DbManipulação
    {
        public Ícone(byte[] dados)
        {
            this.dados = dados;
        }

        private byte[] dados;

        public byte[] Dados
        {
            get { return dados; }
            set { dados = value; }
        }

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        protected override void Descadastrar(System.Data.IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        protected override void Atualizar(System.Data.IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
