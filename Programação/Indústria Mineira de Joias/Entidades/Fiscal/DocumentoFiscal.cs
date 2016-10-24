using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Fiscal
{
    public abstract class DocumentoFiscal : DbManipulaçãoSimples
    {
        protected string id;
        protected bool cancelada;

        [DbColuna("numero")]
        protected int? número;

        [DbColuna("tipo")]
        protected int tipoDocumento;

        [DbColuna("dataemissao")]
        protected DateTime dataEmissão;

        [DbColuna("valortotal")]
        protected decimal valorTotal;

        [DbColuna("cnpjemitente")]
        protected string cnpjEmitente;
        
        [DbColuna("observacoes")]
        protected string observações;

        [DbAtributo(TipoAtributo.Ignorar)]
        protected List<ItemFiscal> itens;

        public DocumentoFiscal()
        {
        }

        public DocumentoFiscal(int tipoDocumento, DateTime dataEmissão, string id, 
            decimal valorTotal, int? número,  
            string cnpjEmitente, bool cancelada, string observações, List<ItemFiscal> itens)
        {
            this.tipoDocumento = tipoDocumento;
            this.dataEmissão = dataEmissão;
            this.id = id;
            this.valorTotal = valorTotal;
            this.número = número;
            this.cnpjEmitente = cnpjEmitente;
            this.cancelada = cancelada;
            this.observações = observações;
            this.itens = itens;
        }

        public DateTime DataEmissão => dataEmissão;
        public string Id => id;
        public decimal ValorTotal => valorTotal;
        public int? Número => número;
        public bool EmitidoPorEstaEmpresa => cnpjEmitente.Equals(Configuração.DadosGlobais.Instância.CNPJEmpresa);
        public string CNPJEmitiente => cnpjEmitente;
        public string CNPJEmitenteFormatado => Pessoa.PessoaJurídica.FormatarCNPJ(cnpjEmitente);
        public List<ItemFiscal> Itens => itens;
        public bool Cancelada => cancelada;
        public int TipoDocumento => tipoDocumento;

        public string Observações => observações;

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

        public override string ToString()
        {
            return string.Format("Id {0}", id);
        }
    }
}
