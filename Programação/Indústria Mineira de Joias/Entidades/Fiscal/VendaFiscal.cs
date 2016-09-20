using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public class VendaFiscal : DbManipulaçãoSimples
    {
        private DateTime dataEmissão;
        private TipoVenda tipoVenda;
        private string id;
        private decimal valorTotal;
        private int? nnf;
        private string emitidoPorCNPJ;
        private int? coo;
        private int? contadorDocumentoEmitido;

        private List<VendaItemFiscal> itens;

        public VendaFiscal()
        {
        }

        public VendaFiscal(TipoVenda tipoVenda, DateTime dataEmissão, string id, 
            decimal valorTotal, int? nnf, int? coo, int? contadorDocumentoEmitido, 
            string emitidoPorCNPJ, List<VendaItemFiscal> itens)
        {
            this.tipoVenda = tipoVenda;
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
            return MapearStrings("select id from vendafiscal");
        }

        public TipoVenda TipoVenda => tipoVenda;
        public DateTime DataEmissão => dataEmissão;
        public string Id => id;
        public List<VendaItemFiscal> Itens => itens;
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
                    VendaItemFiscal.CadastrarItens(id, itens, transação, conexão);

                    transação.Commit();
                }
            }
        }

        private void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = string.Format("INSERT INTO vendafiscal (dataemissao, tipovenda, id, valortotal, nnf, coo, contadordocumentoemitido) values ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                    DbTransformar(dataEmissão),
                    DbTransformar(((char) tipoVenda).ToString()),
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
