using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class EntradaFiscal : DocumentoFiscal
    {
        public EntradaFiscal(int tipoDocumento, DateTime dataEmissão, string id,
        decimal valorTotal, int? nnf, string emitidoPorCNPJ, bool cancelada, string observações, List<ItemFiscal> itens) : 
            base(tipoDocumento, dataEmissão, id, valorTotal, nnf, emitidoPorCNPJ, cancelada, observações, itens)
        {
        }

        public EntradaFiscal()
        {
        }

        internal static List<string> ObterIdsCadastrados()
        {
            return MapearStrings("select id from entradafiscal");
        }

        public static List<DocumentoFiscal> Obter(int? tipoDocumento)
        {
            return new List<DocumentoFiscal>(ObterListaEspecífica(tipoDocumento));
        }

        private static List<EntradaFiscal> ObterListaEspecífica(int? tipoDocumento)
        {
            return Mapear<EntradaFiscal>("select * from entradafiscal " +
                (tipoDocumento.HasValue ? " WHERE tipo=" + tipoDocumento.Value : ""));
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
