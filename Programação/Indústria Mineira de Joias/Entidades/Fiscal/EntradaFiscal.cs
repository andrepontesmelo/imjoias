﻿using Acesso.Comum;
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

        public override string NomeRelação => NOME_RELAÇÃO;

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

                cmd.CommandText = string.Format("INSERT INTO entradafiscal (dataemissao, dataentrada, id, valortotal, numero, cnpjemitente, tipo) " + 
                    "values ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
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
    }
}
