using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class EntradaFiscal : DocumentoFiscal
    {
        [DbColuna("dataentrada")]
        private DateTime dataEntrada;

        public DateTime DataEntrada => dataEntrada;

        private static readonly string NOME_RELAÇÃO = "entradafiscal";

        public EntradaFiscal(int tipoDocumento, DateTime dataEmissão, DateTime dataEntrada, string id,
        decimal valorTotal, int? nnf, string emitidoPorCNPJ, string observações, List<ItemFiscal> itens) : 
            base(tipoDocumento, dataEmissão, id, valorTotal, nnf, emitidoPorCNPJ, observações, itens)
        {
            this.dataEntrada = dataEntrada;
        }

        public static void Excluir(IEnumerable<string> idsSelecionados)
        {
            Excluir(NOME_RELAÇÃO, idsSelecionados);
        }

        public override string NomeRelação => NOME_RELAÇÃO;

        public EntradaFiscal()
        {
        }

        public EntradaFiscal(Guid guid) : base(guid)
        {
            dataEntrada = DadosGlobais.Instância.HoraDataAtual;
        }

        public static List<string> ObterIds()
        {
            return MapearStrings("select id from " + NOME_RELAÇÃO, true);
        }

        public static List<DocumentoFiscal> Obter(int? tipoDocumento)
        {
            return new List<DocumentoFiscal>(ObterListaEspecífica(tipoDocumento));
        }

        private static List<EntradaFiscal> ObterListaEspecífica(int? tipoDocumento)
        {
            return Mapear<EntradaFiscal>("select * from " + NOME_RELAÇÃO +
                (tipoDocumento.HasValue ? " WHERE tipo=" + tipoDocumento.Value : ""));
        }

        protected override void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO {0} (dataemissao, dataentrada, id, valortotal, numero, cnpjemitente, tipo) " + 
                    "values ({1}, {2}, {3}, {4}, {5}, {6}, {7})",
                    NOME_RELAÇÃO,
                    DbTransformar(DataEmissão),
                    DbTransformar(dataEntrada),
                    DbTransformar(Id),
                    DbTransformar(ValorTotal),
                    DbTransformar(Número),
                    DbTransformar(CnpjEmitente), 
                    DbTransformar(TipoDocumento));

                cmd.ExecuteNonQuery();
            }

        }

        public override string ToString()
        {
            return "Entrada " + base.ToString();
        }

        public static DocumentoFiscal CriarDocumento()
        {
            DocumentoFiscal novo = new EntradaFiscal(Guid.NewGuid());
            novo.Cadastrar();

            return novo;
        }

        protected override void CarregarItens()
        {
            itens = new List<ItemFiscal>(EntradaItemFiscal.CarregarItens(id));
        }
    }
}
