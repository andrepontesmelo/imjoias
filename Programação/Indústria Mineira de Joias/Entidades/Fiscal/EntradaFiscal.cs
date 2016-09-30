using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class EntradaFiscal : DocumentoFiscal
    {
        public EntradaFiscal(DateTime dataEmissão, string id,
        decimal valorTotal, int? nnf,
        string emitidoPorCNPJ, bool cancelada, List<ItemFiscal> itens) : base(dataEmissão, id, valorTotal, nnf, emitidoPorCNPJ, cancelada, itens)
        {
        }

        internal static List<string> ObterIdsCadastrados()
        {
            return MapearStrings("select id from entradafiscal");
        }

        protected override void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO entradafiscal (dataemissao, id, valortotal, nnf, cnpjemitente) values ({0}, {1}, {2}, {3}, {4})",
                    DbTransformar(dataEmissão),
                    DbTransformar(id),
                    DbTransformar(ValorTotal),
                    DbTransformar(NNF),
                    DbTransformar(cnpjEmitente));

                cmd.ExecuteNonQuery();
            }

        }
    }
}
