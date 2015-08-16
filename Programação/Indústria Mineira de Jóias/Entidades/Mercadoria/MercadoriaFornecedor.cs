using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.Mercadoria
{
    [DbTabela("vinculomercadoriafornecedor")]
    public class MercadoriaFornecedor : DbManipulaçãoSimples
    {
#pragma warning disable 0649
        private int fornecedor;
        private string referenciafornecedor;
        private string mercadoria;
#pragma warning restore 0649
        public int FornecedorCódigo 
        { 
            get { return fornecedor; }
        }

        public string ReferênciaFornecedor 
        { 
            get { return referenciafornecedor; }
        }

        public Fornecedor Fornecedor
        {
            get
            {
                return Fornecedor.ObterFornecedor(FornecedorCódigo);
            }
        }

        public MercadoriaFornecedor()
        {
        }

        /// <summary>
        /// Se o fornecedor for nulo, o vinculo é  apenas descadastrado.
        /// </summary>
        public static void DeterminarFornecedor(string referênciaNumérica, int? fornecedor, string referênciaFornecedor)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "delete from vinculomercadoriafornecedor where mercadoria = " + DbTransformar(referênciaNumérica) ;
                    cmd.ExecuteNonQuery();
                }

                if (fornecedor.HasValue)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                            cmd.CommandText = "insert into vinculomercadoriafornecedor (fornecedor, referenciafornecedor, mercadoria) values  (" +
                                DbTransformar(fornecedor.Value) + ", " +
                                DbTransformar(referênciaFornecedor) + ", " +
                                DbTransformar(referênciaNumérica) + ")";
                            cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static MercadoriaFornecedor ObterFornecedor(string referênciaNumérica)
        {
            return (MercadoriaFornecedor ) MapearÚnicaLinha<MercadoriaFornecedor>("SELECT * FROM vinculomercadoriafornecedor where mercadoria = "
                + DbTransformar(referênciaNumérica));
        }

        /// <summary>
        /// Dado a referência numérica, retorna os dados de fornecedor.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, MercadoriaFornecedor> ObterFornecedores()
        {
            Dictionary<string, MercadoriaFornecedor> hash = new Dictionary<string, MercadoriaFornecedor>(StringComparer.Ordinal);

            List<MercadoriaFornecedor> lista = Mapear<MercadoriaFornecedor>("SELECT * FROM vinculomercadoriafornecedor");
            foreach (MercadoriaFornecedor f in lista)
            {
                hash.Add(f.mercadoria, f);
            }

            return hash;
        }
    }
}
