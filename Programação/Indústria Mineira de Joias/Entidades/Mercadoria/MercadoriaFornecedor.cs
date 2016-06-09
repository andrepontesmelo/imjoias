using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Mercadoria
{
    [DbTabela("vinculomercadoriafornecedor")]
    public class MercadoriaFornecedor : DbManipulaçãoSimples
    {
#pragma warning disable 0649
        private int fornecedor;
        private string referenciafornecedor;
        private string mercadoria;
        private DateTime inicio;
        private bool foradelinha;
        private decimal peso;

#pragma warning restore 0649

        public DateTime Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }

        public int FornecedorCódigo 
        { 
            get { return fornecedor; }
        }

        public string ReferênciaFornecedor 
        { 
            get { return referenciafornecedor; }
        }

        public Fornecedor Fornecedor
        {
            get
            {
                return Fornecedor.ObterFornecedor(FornecedorCódigo);
            }
        }

        public bool ForaDeLinha
        {
            get { return foradelinha; }
        }
        
        public decimal PesoFornecedor
        {
            get { return peso; }
        }

        public MercadoriaFornecedor()
        {
        }

        public static MercadoriaFornecedor ObterFornecedor(string referênciaNumérica)
        {
            return (MercadoriaFornecedor ) MapearÚnicaLinha<MercadoriaFornecedor>("SELECT * FROM vinculomercadoriafornecedor where mercadoria = "
                + DbTransformar(referênciaNumérica));
        }

        /// <summary>
        /// Dado a referência numérica, retorna os dados de fornecedor.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, MercadoriaFornecedor> ObterFornecedores()
        {
            Dictionary<string, MercadoriaFornecedor> hash = new Dictionary<string, MercadoriaFornecedor>(StringComparer.Ordinal);

            List<MercadoriaFornecedor> lista = Mapear<MercadoriaFornecedor>("SELECT * FROM vinculomercadoriafornecedor");
            foreach (MercadoriaFornecedor f in lista)
            {
                hash.Add(f.mercadoria, f);
            }

            return hash;
        }
    }
}
