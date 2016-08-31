using Acesso.Comum;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Mercadoria.Componente
{
    public class VinculoMercadoriaComponenteCusto : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        private string mercadoria;

        [DbChavePrimária(false)]
        private string componentecusto;

        private double quantidade;

        public VinculoMercadoriaComponenteCusto() { }
        public VinculoMercadoriaComponenteCusto(string mercadoria, string componentecusto, double quantidade)
        {
            this.mercadoria = mercadoria;
            this.componentecusto = componentecusto;
            this.quantidade = quantidade;
        }

        public string ComponenteCusto
        {
            get { return componentecusto; }
            set
            {
                componentecusto = value;
                DefinirDesatualizado();
            }
        }

        public double Quantidade
        {
            get { return quantidade; }
            set 
            { 
                quantidade = value;
                DefinirDesatualizado();
            }
        }

        public string Mercadoria
        {
            get { return mercadoria; }
        }

        public static void GravarVinculos(List<VinculoMercadoriaComponenteCusto> lista, Mercadoria mercadoria)
        {
            IDbCommand cmd;
            IDbConnection conexão;

            string consulta;

            consulta = "delete from vinculomercadoriacomponentecusto where mercadoria=" + DbTransformar(mercadoria.ReferênciaNumérica) + ";";

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

                    consulta += v.Mercadoria + "," + DbTransformar(v.ComponenteCusto) + "," + DbTransformar(v.Quantidade);
                }

                consulta += ");";
            }

            conexão = Conexão;
            lock (conexão)
            {
                cmd = conexão.CreateCommand();
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

            if (componenteAnterior != ComponenteCusto)
            {
                conexão = Conexão;
                lock (conexão)
                {
                    cmd = conexão.CreateCommand();
                    cmd.CommandText = "update vinculomercadoriacomponentecusto set componentecusto="
                    + DbTransformar(ComponenteCusto) +
                    " WHERE mercadoria=" + DbTransformar(mercadoria)
                    + " AND componentecusto=" + DbTransformar(componenteAnterior);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
