using Acesso.Comum;
using Entidades.Configuração;
using Entidades.Fiscal.Fabricação;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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

        [DbColuna("subtotal")]
        protected decimal subTotal;

        [DbColuna("cpfemissor")]
        protected string cpfEmissor;

        [DbColuna("cnpjemissor")]
        protected string cnpjEmissor;

        protected decimal desconto;

        public DocumentoFiscal()
        {
        }

        public DocumentoFiscal(int tipoDocumento, DateTime dataEmissão, string id, decimal subTotal, decimal desconto,
            decimal valorTotal, int? número,  
            string cnpjEmitente, string cpfEmissor, string cnpjEmissor, string observações, List<ItemFiscal> itens)
        {
            this.tipoDocumento = tipoDocumento;
            this.dataEmissão = dataEmissão;
            this.id = id;
            this.novoId = id;
            this.subTotal = subTotal;
            this.desconto = desconto;
            this.valorTotal = valorTotal;
            this.número = número;
            this.cnpjEmitente = cnpjEmitente;
            this.cpfEmissor = cpfEmissor;
            this.cnpjEmissor = cnpjEmissor;
            this.observações = observações;
            this.itens = itens;
        }

        public DocumentoFiscal(Guid guid)
        {
            id = guid.ToString();
            dataEmissão = DadosGlobais.Instância.HoraDataAtual;
            tipoDocumento = (int) Tipo.TipoDocumentoSistema.NFe;
            itens = new List<ItemFiscal>();
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
                novoId = novoId == null ? id : novoId;

                cmd.Transaction = transação;
                cmd.CommandText = string.Format("update {0} set id={1}, " +
                    " numero={2}, tipo={3}, dataemissao={4}, subtotal={5}, desconto={6}, valortotal={7}, " +
                    " cnpjemitente={8}, observacoes={9}, cpfemissor={10}, cnpjemissor={11} where id={12}",
                    NomeRelação,
                    DbTransformar(novoId),
                    DbTransformar(número),
                    DbTransformar(tipoDocumento),
                    DbTransformar(dataEmissão),
                    DbTransformar(subTotal),
                    DbTransformar(desconto),
                    DbTransformar(valorTotal),
                    DbTransformar(cnpjEmitente),
                    DbTransformar(observações),
                    DbTransformar(cpfEmissor),
                    DbTransformar(CnpjEmissor),
                    DbTransformar(id));

                cmd.ExecuteNonQuery();

                id = novoId;
            }

            AtualizarIdItens(novoId);
        }

        private void AtualizarIdItens(string novoId)
        {
            foreach (ItemFiscal d in Itens)
                d.AtualizarIdDocumento(novoId);
        }

        public bool EmitidoPorEstaEmpresa => cnpjEmitente.Equals(DadosGlobais.Instância.CNPJEmpresa);
        public string CNPJEmitenteFormatado => Pessoa.PessoaJurídica.FormatarCNPJ(cnpjEmitente);

        public List<ItemFiscal> Itens
        {
            get
            {
                if (itens == null)
                    CarregarItens();

                return itens;
            }

            set { itens = value; }
        }

        protected abstract void CarregarItens();

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

        public string CpfEmissor
        {
            get { return cpfEmissor; }
            set { cpfEmissor = value; }
        }

        public string CnpjEmissor
        {
            get { return cnpjEmissor; }
            set { cnpjEmissor = value; }
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

        public decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        public abstract string NomeRelação { get; }

        public decimal Desconto
        {
            get { return desconto; }
            set
            {
                desconto = value;
            }
        }

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

        protected static void Excluir(string relação, IEnumerable<string> ids)
        {
            var sql = ObterSqlExclusão(relação, ids);
            var conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static string ObterSqlExclusão(string relação, IEnumerable<string> ids)
        {
            StringBuilder str = new StringBuilder("DELETE from ");
            str.Append(relação);
            str.Append(" WHERE id in ('");

            bool primeiro = true;

            foreach (string id in ids)
            {
                if (!primeiro)
                    str.Append("','");

                str.Append(id);

                primeiro = false;
            }

            str.Append("')");

            return str.ToString(); ;
        }

        public override string ToString()
        {
            return string.Format("Id {0}", id);
        }

        public void Excluir(List<ItemFiscal> itens)
        {
            if (itens.Count == 0)
                return;

            itens[0].Excluir(itens);

            CarregarItens();
        }

        internal static Dictionary<string, SaídaFabricaçãoFiscal> Agrupar(List<DocumentoFiscal> entidades,
            Dictionary<string, MercadoriaFechamento> hashMercadoriaFechamento)
        {
            Dictionary<string, SaídaFabricaçãoFiscal> hash = new Dictionary<string, SaídaFabricaçãoFiscal>();

            foreach (var documento in entidades)
            {
                foreach (var item in documento.Itens)
                {
                    var mercadoria = hashMercadoriaFechamento[item.Referência];
                    decimal qtd = 0;
                    decimal peso = 0;

                    if (mercadoria.DePeso)
                    {
                        peso = item.Quantidade;
                        qtd = 1;
                    }
                    else
                    {
                        peso = mercadoria.Peso;
                        qtd = item.Quantidade;
                    }

                    SaídaFabricaçãoFiscal itemHash;
                    var códigoHash = ObterCódigoHash(item.Referência, peso);
                    if (!hash.TryGetValue(códigoHash, out itemHash))
                    {
                        itemHash = new SaídaFabricaçãoFiscal(item.Referência, 0, 0,  0, peso);
                        hash[códigoHash] = itemHash;
                    }

                    itemHash.Quantidade += qtd;
                }
            }

            return hash;
        }

        private static string ObterCódigoHash(string referência, decimal peso)
        {
            return string.Format("{0}#{1}", referência, peso);
        }

    }
}
