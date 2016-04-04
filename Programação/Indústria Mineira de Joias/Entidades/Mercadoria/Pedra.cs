using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.Mercadoria
{
    public class Pedra : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbChavePrimária(true), DbColuna("codigo")]
        private uint código;

        private string pedra;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        public string Nome { get { return pedra; } set { pedra = value; } }
        public uint Código { get { return código; } }

        public static Pedra[] ObterPedras()
        {
            return Mapear<Pedra>("SELECT * FROM pedra ORDER BY pedra").ToArray() ;
        }

        public string[] ObterCódigosReferência()
        {
            List<string> códigos = new List<string>();

            using (IDbCommand cmd = Conexão.CreateCommand())
            {
                cmd.CommandText = "SELECT codigo FROM mercadoriapedra WHERE pedra = " + DbTransformar(código);

                using (IDataReader leitor = cmd.ExecuteReader())
                {
                    try
                    {
                        while (leitor.Read())
                        {
                            códigos.Add(leitor.GetString(0));
                        }
                    }
                    finally
                    {
                        leitor.Close();
                    }
                }
            }

            return códigos.ToArray();
        }

        public override string ToString()
        {
            return pedra;
        }
    }
}
