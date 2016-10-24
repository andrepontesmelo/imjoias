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

        [DbAtributo(TipoAtributo.Ignorar)]
        protected string novoId;

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
            string cnpjEmitente, string observações, List<ItemFiscal> itens)
        {
            this.tipoDocumento = tipoDocumento;
            this.dataEmissão = dataEmissão;
            this.id = id;
            this.novoId = id;
            this.valorTotal = valorTotal;
            this.número = número;
            this.cnpjEmitente = cnpjEmitente;
            this.observações = observações;
            this.itens = itens;
        }

        public void Gravar()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbTransaction transação = conexão.BeginTransaction())
                {
                    GravarEntidade(transação, conexão);

                    transação.Commit();
                }
            }
        }

        public virtual void GravarEntidade(IDbTransaction transação, IDbConnection conexão)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = string.Format("update {0} set id={1} where id={2}",
                    NomeRelação,
                    DbTransformar(novoId),
                    DbTransformar(id));

                cmd.ExecuteNonQuery();
            }
        }

        public bool EmitidoPorEstaEmpresa => cnpjEmitente.Equals(Configuração.DadosGlobais.Instância.CNPJEmpresa);
        public string CNPJEmitenteFormatado => Pessoa.PessoaJurídica.FormatarCNPJ(cnpjEmitente);
        public List<ItemFiscal> Itens => itens;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                novoId = value;
            }
        }

        public int? Número
        {
            get
            {
                return número;
            }

            set
            {
                número = value;
            }
        }

        public int TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }

            set
            {
                tipoDocumento = value;
            }
        }

        public DateTime DataEmissão
        {
            get
            {
                return dataEmissão;
            }

            set
            {
                dataEmissão = value;
            }
        }

        public decimal ValorTotal
        {
            get
            {
                return valorTotal;
            }

            set
            {
                valorTotal = value;
            }
        }

        public string CnpjEmitente
        {
            get
            {
                return cnpjEmitente;
            }

            set
            {
                cnpjEmitente = value;
            }
        }

        public string Observações
        {
            get
            {
                return observações;
            }

            set
            {
                observações = value;
            }
        }

        public virtual string NomeRelação => "abstrato";

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
