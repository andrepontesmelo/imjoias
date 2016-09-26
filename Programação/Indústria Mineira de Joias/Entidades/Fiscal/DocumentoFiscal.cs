using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public abstract class DocumentoFiscal : DbManipulaçãoSimples
    {
        protected string id;
        protected DateTime dataEmissão;
        protected decimal valorTotal;
        protected int? nnf;
        protected string cnpjEmitente;
        protected List<ItemFiscal> itens;

        public DocumentoFiscal()
        {
        }

        public DocumentoFiscal(DateTime dataEmissão, string id, 
            decimal valorTotal, int? nnf,  
            string cnpjEmitente, List<ItemFiscal> itens)
        {
            this.dataEmissão = dataEmissão;
            this.id = id;
            this.valorTotal = valorTotal;
            this.nnf = nnf;
            this.cnpjEmitente = cnpjEmitente;
            this.itens = itens;
        }

        public DateTime DataEmissão => dataEmissão;
        public string Id => id;
        public decimal ValorTotal => valorTotal;
        public int? NNF => nnf;
        public bool EmitidoPorEstaEmpresa => cnpjEmitente.Equals(Configuração.DadosGlobais.Instância.CNPJEmpresa);
        public List<ItemFiscal> Itens => itens;

        protected abstract void CadastrarEntidade(IDbTransaction transação, IDbConnection conexão);

        protected void CadastrarItens(IDbTransaction transação, IDbConnection conexão)
        {
            ItemFiscal.CadastrarItens(id, itens, transação, conexão);
        }

        public void Cadastrar()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbTransaction transação = conexão.BeginTransaction())
                {
                    CadastrarEntidade(transação, conexão);
                    CadastrarItens(transação, conexão);

                    transação.Commit();
                }
            }
        }
    }
}
