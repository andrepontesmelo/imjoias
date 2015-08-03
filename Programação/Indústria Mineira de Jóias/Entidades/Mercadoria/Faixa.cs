using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using System.Collections;

namespace Entidades.Mercadoria
{
    public class Faixa : DbManipulaçãoAutomática
    {
        // Atributos
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        private double valor;

        [DbColuna("faixa")]
        private string código;

        //[DbRelacionamento("codigo", "setor")]
        //private Setor setor;

        [DbRelacionamento("código", "tabela")]
        private Tabela tabela;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        //[DbAtributo(TipoAtributo.Ignorar)]
        //private Dictionary<uint, double> hashSetorValor;

        #region Propriedades
        public string Código
        {
            get { return código; }
        }

        //public Setor Setor
        //{
        //    get { return setor; }
        //}

        public Tabela TabelaPreço
        {
            get { return tabela; }
        }

        public double Valor
        {
            get { return valor; }
        }
        #endregion

        public static Faixa ObterFaixa(string código, int códigoTabela)
        {
            Faixa faixa = MapearÚnicaLinha<Faixa>("select * from faixa where faixa=" + DbTransformar(código) 
                + " AND tabela= " + DbTransformar(códigoTabela));

            return faixa;
        }

        public static List<string> Faixas
        {
            get
            {
                List<string> faixas = new List<string>();
                IDbCommand cmd;
                IDbConnection conexão;
                IDataReader leitor = null;

                conexão = Conexão;

                lock (conexão)
                {
                    cmd = conexão.CreateCommand();
                    cmd.CommandText = "select faixa from faixa group by faixa";

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                faixas.Add((string)leitor.GetString(0));
                            }
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                    }
                }

                return faixas;
            }
        }
    }
}
