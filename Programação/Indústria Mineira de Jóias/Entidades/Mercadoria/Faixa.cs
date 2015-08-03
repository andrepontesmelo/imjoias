using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using System.Collections;

namespace Entidades.Mercadoria
{
    public class Faixa : DbManipula��oAutom�tica
    {
        // Atributos
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        private double valor;

        [DbColuna("faixa")]
        private string c�digo;

        //[DbRelacionamento("codigo", "setor")]
        //private Setor setor;

        [DbRelacionamento("c�digo", "tabela")]
        private Tabela tabela;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        //[DbAtributo(TipoAtributo.Ignorar)]
        //private Dictionary<uint, double> hashSetorValor;

        #region Propriedades
        public string C�digo
        {
            get { return c�digo; }
        }

        //public Setor Setor
        //{
        //    get { return setor; }
        //}

        public Tabela TabelaPre�o
        {
            get { return tabela; }
        }

        public double Valor
        {
            get { return valor; }
        }
        #endregion

        public static Faixa ObterFaixa(string c�digo, int c�digoTabela)
        {
            Faixa faixa = Mapear�nicaLinha<Faixa>("select * from faixa where faixa=" + DbTransformar(c�digo) 
                + " AND tabela= " + DbTransformar(c�digoTabela));

            return faixa;
        }

        public static List<string> Faixas
        {
            get
            {
                List<string> faixas = new List<string>();
                IDbCommand cmd;
                IDbConnection conex�o;
                IDataReader leitor = null;

                conex�o = Conex�o;

                lock (conex�o)
                {
                    cmd = conex�o.CreateCommand();
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
