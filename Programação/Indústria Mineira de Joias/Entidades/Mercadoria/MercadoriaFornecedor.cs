using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Mercadoria
{
    [DbTabela("vinculomercadoriafornecedor")]
    public class MercadoriaFornecedor : DbManipulaçãoSimples
    {
#pragma warning disable 0649
        private ulong fornecedor;
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

        public ulong FornecedorCódigo => fornecedor;

        public string ReferênciaFornecedor => referenciafornecedor;

        public string ReferênciaFornecedorComFFL => referenciafornecedor + (foradelinha ? " FFL" : "");
        public bool ForaDeLinha => foradelinha;

        public decimal PesoFornecedor => peso;

        public MercadoriaFornecedor()
        {
        }

        public static MercadoriaFornecedor ObterFornecedor(string referênciaNumérica)
        {
            return (MercadoriaFornecedor ) MapearÚnicaLinha<MercadoriaFornecedor>("SELECT * FROM vinculomercadoriafornecedor where mercadoria = "
                + DbTransformar(referênciaNumérica));
        }

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
