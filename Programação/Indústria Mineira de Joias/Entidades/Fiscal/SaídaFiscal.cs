using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class SaídaFiscal : DocumentoFiscal
    {
        protected int? coo;
        protected int? contadorDocumentoEmitido;

        public SaídaFiscal(int tipoDocumento, DateTime dataEmissão, string id,
            decimal valorTotal, int? nnf, int? coo, int? contadorDocumentoEmitido,
            string emitidoPorCNPJ, bool cancelada, string observações, List<ItemFiscal> itens) : 
            base(tipoDocumento, dataEmissão, id, valorTotal, nnf, emitidoPorCNPJ, cancelada, observações, itens)
        {
            this.coo = coo;
            this.contadorDocumentoEmitido = contadorDocumentoEmitido;
        }

        internal static List<string> ObterIdsCadastrados()
        {
            return MapearStrings("select id from saidafiscal");
        }

        protected override void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO saidafiscal " + 
                    "(dataemissao, tiposaida, id, valortotal, nnf, coo, contadordocumentoemitido, cnpjemitente, cancelada) " + 
                    " values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                    DbTransformar(dataEmissão),
                    DbTransformar(((int) tipoDocumento).ToString()),
                    DbTransformar(id),
                    DbTransformar(ValorTotal),
                    DbTransformar(NNF),
                    DbTransformar(COO),
                    DbTransformar(ContadorDocumentoEmitido),
                    DbTransformar(cnpjEmitente),
                    DbTransformar(Cancelada));

                cmd.ExecuteNonQuery();
            }
        }

        internal static string ObterIdNfe(string idCancelamento)
        {
            if (!idCancelamento.StartsWith("ID"))
                throw new Exception("ID de cancelamento deveria começar com **ID**, mas não começa: " + idCancelamento);

            return "NFe" + idCancelamento.Substring(2);
        }

        internal static void Cancelar(string id)
        {
            using (IDbCommand cmd = Conexão.CreateCommand())
            {
                cmd.CommandText = string.Format("update saidafiscal set cancelada=1 WHERE id={0}", DbTransformar(id));
                cmd.ExecuteNonQuery();
            }
        }

        public static List<string> ObterIds(int tipo, bool? canceladas)
        {
            return MapearStrings(
                string.Format("select id from saidafiscal where cancelada={0} and tiposaida='{1}'",
                canceladas.HasValue ? (canceladas.Value ? "1" : "0") : "cancelada",
                tipo));
        }

        public int? ContadorDocumentoEmitido => contadorDocumentoEmitido;
        public int? COO => coo;
    }
}
