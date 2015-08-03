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

        ///// <summary>
        ///// Obtém ícone da mercadoria
        ///// </summary>
        ///// <returns>Vetor de bytes representando o ícone da mercadoria</returns>
        //public static Ícone ObterÍcone(string referência, double? peso)
        //{
        //    return Acesso.Comum.Cache.CacheDb.Instância.ObterEntidade(typeof(Entidades.Álbum.Ícone), referência, peso) as Entidades.Álbum.Ícone;
        //}

        //public static Ícone ObterÍconeSemCache(string referência, double? peso)
        //{
        //    Console.WriteLine("Consúltima de obtenção de 1 ícone");
        //    object objÍcone;
        //    IDbConnection conexão = Conexão;

        //    lock (conexão)
        //        using (IDbCommand cmd = conexão.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT icone FROM foto WHERE mercadoria = " + DbTransformar(referência);

        //            if (peso.HasValue)
        //                cmd.CommandText += " AND peso = " + DbTransformar(peso.Value);

        //            cmd.CommandText += " LIMIT 1";

        //            objÍcone = cmd.ExecuteScalar();
        //        }

        //    if (objÍcone == null || objÍcone.GetType() == typeof(DBNull))
        //    {
        //        if (peso.HasValue)
        //            return ObterÍcone(referência, null);
        //        else
        //            return null;
        //    }

        //    return new Ícone((byte[])objÍcone);
        //}

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
