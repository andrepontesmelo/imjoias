﻿using Acesso.Comum;
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

        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set { dataEntrada = value; }
        }

        private static readonly string NOME_RELAÇÃO = "entradafiscal";

        public EntradaFiscal(int tipoDocumento, DateTime dataEmissão, DateTime dataEntrada, string id,
        decimal subTotal, decimal desconto, decimal valorTotal, int? nnf, string cnpjEmitente, string cpfEmissor, string cnpjEmissor, string observações, List<ItemFiscal> itens) : 
            base(tipoDocumento, dataEmissão, id, subTotal, desconto, valorTotal, nnf, cnpjEmitente, cpfEmissor, cnpjEmissor, observações, itens)
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

        public static List<DocumentoFiscal> Obter(int? tipoDocumento, DateTime dataInicial, DateTime dataFinal)
        {
            return new List<DocumentoFiscal>(ObterListaEspecífica(tipoDocumento, dataInicial, dataFinal));
        }

        private static List<EntradaFiscal> ObterListaEspecífica(int? tipoDocumento, DateTime dataInicial, DateTime dataFinal)
        {
            return Mapear<EntradaFiscal>("select * from " + NOME_RELAÇÃO +
                " WHERE 1=1 " +
                (tipoDocumento.HasValue ? " AND tipo=" + tipoDocumento.Value : "") + 
                " AND " + DbDataEntre("dataentrada", dataInicial, dataFinal));
        }

        protected override void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO {0} (dataemissao, dataentrada, id, subtotal, desconto, valortotal, numero, cnpjemitente, cpfemissor, cnpjemissor, tipo) " + 
                    "values ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})",
                    NOME_RELAÇÃO,
                    DbTransformar(DataEmissão),
                    DbTransformar(dataEntrada),
                    DbTransformar(Id),
                    DbTransformar(SubTotal),
                    DbTransformar(Desconto),
                    DbTransformar(ValorTotal),
                    DbTransformar(Número),
                    DbTransformar(CnpjEmitente), 
                    DbTransformar(CpfEmissor),
                    DbTransformar(CnpjEmissor),
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

        public override void GravarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            base.GravarEntidade(transação, conexão);

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = string.Format("update {0} set dataentrada={1} WHERE id={2}",
                    NomeRelação,
                    DbTransformar(dataEntrada),
                    DbTransformar(id));

                cmd.ExecuteNonQuery();
            }
        }
    }
}
