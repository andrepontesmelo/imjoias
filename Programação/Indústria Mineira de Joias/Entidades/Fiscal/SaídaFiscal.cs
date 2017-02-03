using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Data;
using Entidades.Fiscal.Fabricação;
using System.Text;

namespace Entidades.Fiscal
{
    public class SaídaFiscal : DocumentoFiscal
    {
        [DbColuna("datasaida")]
        private DateTime dataSaída;
        private uint setor;
        protected bool cancelada;
        private int? maquina;

        [DbColuna("fabricacao")]
        private int? fabricação;

        public int? Máquina
        {
            get { return maquina; }
            set { maquina = value; }
        }

        public DateTime DataSaída
        {
            get { return dataSaída; }
            set { dataSaída = value; }
        }

        public int? Fabricação
        {
            get { return fabricação; }
            set { fabricação = value; }
        }

        public static void Excluir(IEnumerable<string> idsSelecionados)
        {
            Excluir(NOME_RELAÇÃO, idsSelecionados);
        }

        private static readonly string NOME_RELAÇÃO = "saidafiscal";

        public SaídaFiscal(int tipoDocumento, DateTime dataEmissão, DateTime dataSaída, string id, decimal subTotal, decimal desconto,
            decimal valorTotal, int? número, string cnpjEmitente, string cpfEmissor, string cnpjEmissor, bool cancelada, string observações, uint setor, int? maquina, List<ItemFiscal> itens) : 
            base(tipoDocumento, dataEmissão, id, subTotal, desconto, valorTotal, número, cnpjEmitente, cpfEmissor, cnpjEmissor, observações, itens)
        {
            this.dataSaída = dataSaída;
            this.setor = setor;
            this.cancelada = cancelada;
            this.maquina = maquina;
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

        public uint Setor
        {
            get
            {
                return setor;
            }

            set
            {
                setor = value;
            }
        }

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

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = string.Format("update {0} set cancelada={1}, setor={2}, maquina={3}, datasaida={4}, fabricacao={5} WHERE id={6}",
                    NomeRelação,
                    DbTransformar(cancelada),
                    DbTransformar(setor),
                    DbTransformar(maquina),
                    DbTransformar(dataSaída),
                    DbTransformar(fabricação),
                    DbTransformar(id));

                cmd.ExecuteNonQuery();
            }
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
                    "(dataemissao, datasaida, tipo, id, subtotal, desconto, valortotal, numero, cnpjemitente, cancelada, setor, maquina, fabricacao, cnpjemissor, cpfemissor) " + 
                    " values ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15})",
                    NOME_RELAÇÃO,
                    DbTransformar(DataEmissão),
                    DbTransformar(dataSaída),
                    DbTransformar(((int) TipoDocumento).ToString()),
                    DbTransformar(Id),
                    DbTransformar(SubTotal),
                    DbTransformar(Desconto),
                    DbTransformar(ValorTotal),
                    DbTransformar(Número),
                    DbTransformar(CnpjEmitente),
                    DbTransformar(Cancelada),
                    DbTransformar(Setor),
                    DbTransformar(Máquina),
                    DbTransformar(Fabricação),
                    DbTransformar(CnpjEmissor),
                    DbTransformar(CpfEmissor));

                cmd.ExecuteNonQuery();
            }
        }

        public static void VincularFabricação(List<DocumentoFiscal> entidades, FabricaçãoFiscal fabricação)
        {
            StringBuilder sql = new StringBuilder("update saidafiscal set fabricacao=");
            sql.Append(fabricação.Código);
            sql.Append(" WHERE id in (");

            bool primeiro = true;

            foreach (DocumentoFiscal d in entidades)
            {
                if (!primeiro)
                    sql.Append(", ");

                sql.Append(DbTransformar(d.Id));
                primeiro = false;
            }

            sql.Append(")");
            ExecutarComando(sql.ToString());
        }

        public static DocumentoFiscal CriarDocumento(uint setor)
        {
            var novo = new SaídaFiscal(Guid.NewGuid());
            novo.Setor = setor;
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

        public static List<DocumentoFiscal> Obter(int? tipoDocumento, uint? setor, DateTime dataInicial, DateTime dataFinal)
        {
            return new List<DocumentoFiscal>(ObterListaEspecífica(tipoDocumento, setor, dataInicial, dataFinal));
        }

        private static List<SaídaFiscal> ObterListaEspecífica(int? tipoDocumento, uint? setor, DateTime dataInicial, DateTime dataFinal)
        {
            return Mapear<SaídaFiscal>("select * from " + NOME_RELAÇÃO + " WHERE 1=1 " +
                (tipoDocumento.HasValue ? " AND tipo=" + tipoDocumento.Value : "") +
                (setor.HasValue ? " AND setor=" + setor.Value : "")
                + " AND  " + DbDataEntre("datasaida", dataInicial, dataFinal));
        }

        public override string ToString()
        {
            return "Saída " + base.ToString();
        }

        protected override void CarregarItens()
        {
            itens = new List<ItemFiscal>(SaídaItemFiscal.CarregarItens(id));
        }
    }
}
