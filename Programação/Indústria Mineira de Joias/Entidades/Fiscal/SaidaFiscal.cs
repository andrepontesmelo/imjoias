using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class SaidaFiscal : DbManipulaçãoSimples
    {
        private DateTime dataEmissão;
        private TipoSaída tipoSaída;
        private string id;
        private decimal valorTotal;
        private int? nnf;
        private string emitidoPorCNPJ;
        private int? coo;
        private int? contadorDocumentoEmitido;

        private List<SaidaItemFiscal> itens;

        public SaidaFiscal()
        {
        }

        public SaidaFiscal(TipoSaída tipoSaída, DateTime dataEmissão, string id, 
            decimal valorTotal, int? nnf, int? coo, int? contadorDocumentoEmitido, 
            string emitidoPorCNPJ, List<SaidaItemFiscal> itens)
        {
            this.tipoSaída = tipoSaída;
            this.dataEmissão = dataEmissão;
            this.id = id;
            this.valorTotal = valorTotal;
            this.nnf = nnf;
            this.coo = coo;
            this.contadorDocumentoEmitido = contadorDocumentoEmitido;
            this.itens = itens;
            this.emitidoPorCNPJ = emitidoPorCNPJ;
        }

        internal static List<string> ObterIdsCadastrados()
        {
            return MapearStrings("select id from saidafiscal");
        }

        public TipoSaída TipoSaída => tipoSaída;
        public DateTime DataEmissão => dataEmissão;
        public string Id => id;
        public List<SaidaItemFiscal> Itens => itens;
        public decimal ValorTotal => valorTotal;
        public int? NNF => nnf;
        public bool EmitidoPorEstaEmpresa => emitidoPorCNPJ.Equals(Configuração.DadosGlobais.Instância.CNPJEmpresa);
        public int? ContadorDocumentoEmitido => contadorDocumentoEmitido;
        public int? COO => coo;

        public void Cadastrar()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbTransaction transação = conexão.BeginTransaction())
                {
                    CadastrarEntidade(transação, conexão);
                    SaidaItemFiscal.CadastrarItens(id, itens, transação, conexão);

                    transação.Commit();
                }
            }
        }

        private void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO saidafiscal (dataemissao, tiposaida, id, valortotal, nnf, coo, contadordocumentoemitido) values ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                    DbTransformar(dataEmissão),
                    DbTransformar(((char) tipoSaída).ToString()),
                    DbTransformar(id),
                    DbTransformar(ValorTotal),
                    DbTransformar(NNF),
                    DbTransformar(COO),
                    DbTransformar(ContadorDocumentoEmitido));

                cmd.ExecuteNonQuery();
            }
        }
    }
}
