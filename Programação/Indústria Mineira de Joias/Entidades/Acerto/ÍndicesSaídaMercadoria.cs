using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;

namespace Entidades.Acerto
{
    /// <summary>
    /// Um acerto tem várias saídas.
    /// Então uma mercadoria (ref, peso)
    /// pode ter vários índices.
    /// </summary>
    public class ÍndicesSaídaMercadoria : DbManipulaçãoAutomática
    {
            private string referencia;
            private double peso;
            private List<double> índices;

            public string Referência { get { return referencia; } }
            public double Peso { get { return peso; } }
            public List<double> Índices { get { return índices; } }

            public ÍndicesSaídaMercadoria(string referência, double peso)
            {
                this.referencia = referência;
                this.peso = peso;

                this.índices = new List<double>();
            }

            /// <summary>
            /// Gera chave para uma mercadoria.
            /// </summary>
            /// <param name="mercadoria">Mercadoria cuja chave deve ser gerada.</param>
            /// <returns>Chave para uso na árvore patrícia.</returns>
            public static string GerarChave(Entidades.Mercadoria.Mercadoria mercadoria)
            {
                return GerarChave(mercadoria.ReferênciaNumérica, mercadoria.Peso);
            }

            public static string GerarChave(string referênciaNumérica, double peso)
            {
                if (Entidades.Mercadoria.Mercadoria.ConferirSeÉDePeso(referênciaNumérica))
                    return referênciaNumérica + "#" + peso.ToString();
                else
                    return referênciaNumérica;
            }

            /// <summary>
            /// Dado uma chave (ref, peso),
            /// retorna o objeto ÍndiceSaídaMercadoria, contendo a lista de indices daquela mercadoria.
            /// </summary>
            public static Dictionary<string, ÍndicesSaídaMercadoria> ObterHashÍndicesSaídas(AcertoConsignado acerto)
            {
                Dictionary<string, ÍndicesSaídaMercadoria> hash = new Dictionary<string, ÍndicesSaídaMercadoria>(StringComparer.Ordinal);

                using (IDbCommand cmd = Conexão.CreateCommand())
                {
                    cmd.CommandText = " select referencia,peso,indice from saidaitem, saida where "
                    + " saidaitem.saida=saida.codigo "
                    + " and acerto= " + acerto.Código.ToString()
                    + " group by referencia, peso, indice having sum(quantidade) > 0 ";

                    using (IDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            string referencia = leitor.GetString(0);
                            double peso = leitor.GetDouble(1);
                            double indice = Math.Round(leitor.GetDouble(2), 2);

                            string chave = GerarChave(referencia, peso);

                            ÍndicesSaídaMercadoria item = null;

                            if (!hash.TryGetValue(chave, out item))
                            {
                                item = new ÍndicesSaídaMercadoria(referencia, peso);
                                hash.Add(chave, item);
                            }

                            if (!item.Índices.Contains(indice))
                                item.Índices.Add(indice);
                        }

                        leitor.Close();
                    }
                }

                return hash;
            }
    }
}
