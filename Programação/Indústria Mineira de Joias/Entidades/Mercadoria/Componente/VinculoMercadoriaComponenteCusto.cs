using System.Collections.Generic;
using System.Data;

namespace Entidades.Mercadoria.Componente
{
    public class VinculoMercadoriaComponenteCusto : VinculoMercadoriaComponente
    {
        public VinculoMercadoriaComponenteCusto() { }
        public VinculoMercadoriaComponenteCusto(string mercadoria, string componente, double quantidade) : base(mercadoria, componente, quantidade)
        {
        }

        public static void GravarVinculos(List<VinculoMercadoriaComponenteCusto> lista, Mercadoria mercadoria)
        {
            string consulta = "delete from vinculomercadoriacomponentecusto where mercadoria=" + DbTransformar(mercadoria.ReferênciaNumérica) + ";";

            if (lista.Count != 0)
            {
                consulta += " INSERT INTO vinculomercadoriacomponentecusto (mercadoria, componentecusto, quantidade) VALUES (";
                bool primeiro = true;

                foreach (VinculoMercadoriaComponenteCusto v in lista)
                {
                    if (!primeiro)
                        consulta += "),(";
                    else
                        primeiro = false;

                    consulta += v.Mercadoria + "," + DbTransformar(v.Componente) + "," + DbTransformar(v.Quantidade);
                }

                consulta += ");";
            }

            IDbConnection conexão = Conexão;
            lock (conexão)
            {
                var cmd = conexão.CreateCommand();
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
            }
        }

        public static List<VinculoMercadoriaComponenteCusto> ObterVinculos(Mercadoria mercadoria)
        {
            string consulta = "select * from vinculomercadoriacomponentecusto where "
            + "mercadoria=" + DbTransformar(mercadoria.ReferênciaNumérica);

            return Mapear<VinculoMercadoriaComponenteCusto>(consulta);
        }

        public void AtualizarTrocandoComponente(string componenteAnterior)
        {
            IDbCommand cmd;
            IDbConnection conexão;

            Atualizar();

            if (componenteAnterior != Componente)
            {
                conexão = Conexão;
                lock (conexão)
                {
                    cmd = conexão.CreateCommand();
                    cmd.CommandText = "update vinculomercadoriacomponentecusto set componentecusto="
                    + DbTransformar(Componente) +
                    " WHERE mercadoria=" + DbTransformar(mercadoria)
                    + " AND componentecusto=" + DbTransformar(componenteAnterior);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
