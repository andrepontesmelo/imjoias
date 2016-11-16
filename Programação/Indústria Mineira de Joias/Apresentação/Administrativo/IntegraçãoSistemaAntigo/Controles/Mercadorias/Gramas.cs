using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Apresenta��o.Integra��oSistemaAntigo.Controles.Mercadorias
{
	public class Gramas
	{
        private const int tabelaConsignado = 2;
        private const int tabelaAtacado = 3;
        private const int tabelaAltoAtacado = 4;
        private const int tabelaVarejo = 1;
        private const int tabelaVarejoConsulta = 5;
        private const int tabelaRepresentante = 6;

		private DataTable gramas;
	
		public Gramas(DataSet dataSetVelho)
		{
            gramas = dataSetVelho.Tables["gramas"];
		}

		public void Transpor(StringBuilder sa�da)
        {
            int maxComandosPorVez = 200;

            IDbConnection cn = Acesso.MySQL.ConectorMysql.Inst�ncia.CriarConex�o(
                Acesso.MySQL.MySQLUsu�rios.Obter�ltimaStrConex�o());

            cn.Open();

            IDbTransaction t = cn.BeginTransaction();

            StringBuilder consulta = new StringBuilder("");
            int vezAtual = 0;

            consulta.AppendLine("DELETE FROM grama; ");

            foreach (DataRow grama in gramas.Rows)
            {
                int c�digoTabela = int.Parse(grama["G_CODTAB"].ToString());

                if (c�digoTabela == 4 || c�digoTabela == 8)

                    TransporGrama(grama, consulta, c�digoTabela, sa�da);
                vezAtual++;

                if (vezAtual >= maxComandosPorVez && consulta.Length > 0)
                {
                    vezAtual = 0;
                    ExecutaSql(cn, t, consulta);
                }
            }

            ReplicaGramasAtacadoParaOutrasTabelasExcetoAA(consulta);

            ExecutaSql(cn, t, consulta);

            t.Commit();
        }

        private static void ExecutaSql(IDbConnection cn, IDbTransaction t, StringBuilder consulta)
        {
            IDbCommand cmd = cn.CreateCommand();
            cmd.Transaction = t;
            cmd.CommandText = consulta.ToString();
            consulta.Clear();
            cmd.ExecuteNonQuery();
        }

        private static void ReplicaGramasAtacadoParaOutrasTabelasExcetoAA(StringBuilder consulta)
        {
            consulta.Append(" insert into grama (tabela, faixa, grupo, valor) select t.codigo as tabela, faixa, grupo, valor ");
            consulta.AppendLine(" from grama g, tabela t where t.codigo != 3 and t.codigo != 4 and g.tabela=3; ");
        }

		private void TransporGrama(DataRow grama, StringBuilder consulta, int c�digoTabela, StringBuilder saida)
		{
            double coeficienteAtacado = 0;

            coeficienteAtacado = double.Parse(grama["G_VISTA"].ToString());

            consulta.Append(" INSERT INTO grama (tabela, faixa, grupo, valor) values (");
            consulta.Append(ObterTabelaEquivalente(c�digoTabela));
            consulta.Append(", '");
            consulta.Append(grama["G_FAIXA"].ToString().ToLower());
            consulta.Append("', ");
            consulta.Append(grama["G_GRUPO"].ToString());
            consulta.Append(", ");
            consulta.Append(DbTransformar(coeficienteAtacado));
            consulta.AppendLine("); ");
		}

        private int ObterTabelaEquivalente(int c�digoTabela)
        {
            switch (c�digoTabela)
            {
                case 4:
                    return tabelaAtacado;
                case 8:
                    return tabelaAltoAtacado;
                default:
                    throw new NotImplementedException();
            }
        }

        private static string DbTransformar(double valor)
        {
            return valor.ToString().Replace(',', '.');
        }
	}
}
