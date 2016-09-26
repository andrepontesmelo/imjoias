﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class SaídaFiscal : DocumentoFiscal
    {
        private TipoSaída tipoSaída;
        protected int? coo;
        protected int? contadorDocumentoEmitido;

        public SaídaFiscal(TipoSaída tipoSaída, DateTime dataEmissão, string id,
            decimal valorTotal, int? nnf, int? coo, int? contadorDocumentoEmitido,
            string emitidoPorCNPJ, List<ItemFiscal> itens) : base(dataEmissão, id, valorTotal, nnf, emitidoPorCNPJ, itens)
        {
            this.tipoSaída = tipoSaída;
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

                cmd.CommandText = string.Format("INSERT INTO saidafiscal (dataemissao, tiposaida, id, valortotal, nnf, coo, contadordocumentoemitido, cnpjemitente) " + 
                    " values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                    DbTransformar(dataEmissão),
                    DbTransformar(((char)tipoSaída).ToString()),
                    DbTransformar(id),
                    DbTransformar(ValorTotal),
                    DbTransformar(NNF),
                    DbTransformar(COO),
                    DbTransformar(ContadorDocumentoEmitido),
                    DbTransformar(cnpjEmitente));

                cmd.ExecuteNonQuery();
            }
        }

        public int? ContadorDocumentoEmitido => contadorDocumentoEmitido;
        public int? COO => coo;
        public TipoSaída TipoSaída => tipoSaída;
    }
}
