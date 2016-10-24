using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class SaídaFiscal : DocumentoFiscal
    {
        [DbColuna("datasaida")]
        private DateTime dataSaída;
        private uint setor;
        protected bool cancelada;

        public DateTime DataSaída => dataSaída;
        public uint Setor => setor;
               
        public SaídaFiscal(int tipoDocumento, DateTime dataEmissão, DateTime dataSaída, string id,
            decimal valorTotal, int? número, string cnpjEmitente, bool cancelada, string observações, uint setor, List<ItemFiscal> itens) : 
            base(tipoDocumento, dataEmissão, id, valorTotal, número, cnpjEmitente, observações, itens)
        {
            this.dataSaída = dataSaída;
            this.setor = setor;
            this.cancelada = cancelada;
        }

        public bool Cancelada
        {
            get
            {
                return cancelada;
            }

            set
            {
                cancelada = value;
            }
        }

        public SaídaFiscal()
        {
        }

        public override void GravarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            base.GravarEntidade(transação, conexão);

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = string.Format("update saidafiscal set id={0} where id={1}",
                    DbTransformar(novoId), 
                    DbTransformar(id));

                cmd.ExecuteNonQuery();
            }
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
                    "(dataemissao, datasaida, tipo, id, valortotal, numero, cnpjemitente, cancelada, setor) " + 
                    " values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                    DbTransformar(DataEmissão),
                    DbTransformar(dataSaída),
                    DbTransformar(((int) TipoDocumento).ToString()),
                    DbTransformar(Id),
                    DbTransformar(ValorTotal),
                    DbTransformar(Número),
                    DbTransformar(CnpjEmitente),
                    DbTransformar(Cancelada),
                    DbTransformar(Setor));

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

        public static List<DocumentoFiscal> Obter(int? tipoDocumento, int? setor)
        {
            return new List<DocumentoFiscal>(ObterListaEspecífica(tipoDocumento, setor));
        }

        private static List<SaídaFiscal> ObterListaEspecífica(int? tipoDocumento, int? setor)
        {
            return Mapear<SaídaFiscal>("select * from saidafiscal WHERE 1=1 " +
                (tipoDocumento.HasValue ? " AND tipo=" + tipoDocumento.Value : "") +
                (setor.HasValue ? " AND setor=" + setor.Value : ""));
        }

        public override string ToString()
        {
            return "Saída " + base.ToString();
        }
    }
}
