using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Data;
using static Entidades.Setor;

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
               
        private static readonly string NOME_RELAÇÃO = "saidafiscal";

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

        public override string NomeRelação => NOME_RELAÇÃO;

        public SaídaFiscal()
        {
        }

        public SaídaFiscal(Guid guid) : base(guid)
        {
            dataSaída = DadosGlobais.Instância.HoraDataAtual;
            setor = (int) SetorSistema.Atacado;
        }

        public override void GravarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            base.GravarEntidade(transação, conexão);
        }

        public static List<string> ObterIds()
        {
            return MapearStrings("select id from " + NOME_RELAÇÃO, true);
        }

        protected override void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO {0} " + 
                    "(dataemissao, datasaida, tipo, id, valortotal, numero, cnpjemitente, cancelada, setor) " + 
                    " values ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})",
                    NOME_RELAÇÃO,
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

        public static DocumentoFiscal CriarDocumento()
        {
            DocumentoFiscal novo = new SaídaFiscal(Guid.NewGuid());
            novo.Cadastrar();

            return novo;
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
                string.Format("select id from {0} where cancelada={1} and tiposaida='{2}'",
                NOME_RELAÇÃO,
                canceladas.HasValue ? (canceladas.Value ? "1" : "0") : "cancelada",
                tipo));
        }

        public static List<DocumentoFiscal> Obter(int? tipoDocumento, int? setor)
        {
            return new List<DocumentoFiscal>(ObterListaEspecífica(tipoDocumento, setor));
        }

        private static List<SaídaFiscal> ObterListaEspecífica(int? tipoDocumento, int? setor)
        {
            return Mapear<SaídaFiscal>("select * from " + NOME_RELAÇÃO + " WHERE 1=1 " +
                (tipoDocumento.HasValue ? " AND tipo=" + tipoDocumento.Value : "") +
                (setor.HasValue ? " AND setor=" + setor.Value : ""));
        }

        public override string ToString()
        {
            return "Saída " + base.ToString();
        }
    }
}
