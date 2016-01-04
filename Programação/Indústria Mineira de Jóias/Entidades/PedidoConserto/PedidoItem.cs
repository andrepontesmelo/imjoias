using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.PedidoConserto
{
    public class PedidoItem : DbManipulaçãoAutomática
    {
#pragma warning disable 0649
        [DbChavePrimária(true)]
        private long codigo;
        private long pedido;
        private int quantidade;
        private string mercadoria = null;
        private string descricao;
#pragma warning restore 0649

        public PedidoItem()
        {
            quantidade = 1;
        }

        public long Código
        {
            get
            {
                return codigo;
            }
        }

        public long Pedido
        {
            get
            {
                return pedido;
            }
            set
            {
                pedido = value;
            }
        }

        public string ReferênciaFormatada
        {
            get
            {
                return String.IsNullOrEmpty(mercadoria) ? "" : 
                    Mercadoria.Mercadoria.MascararReferência(mercadoria, 
                    Mercadoria.Mercadoria.ObterDígito(mercadoria));
            }
        }

        public string ReferênciaNumérica
        {
            get
            {
                return mercadoria;
            }
            set
            {
                mercadoria = value;
                DefinirDesatualizado();
            }
        }


        public int Quantidade
        {
            get
            {
                return quantidade;
            }
            set
            {
                quantidade = value;
                DefinirDesatualizado();
            }
        }

        public string Descrição
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
                DefinirDesatualizado();
            }
        }

        public static List<PedidoItem> Obter(Pedido pedido)
        {
            return Mapear<PedidoItem>("select * from pedidoitem where pedido=" + DbTransformar(pedido.Código));
        }

        public static List<PedidoItem> Obter(List<Pedido> pedidos)
        {
            List<PedidoItem> itens = null;


            if (pedidos.Count > 0)
            {
                itens = Mapear<PedidoItem>("select * from pedidoitem where pedido IN " + DbTransformarConjunto(pedidos) + " order by mercadoria ");
            }
            else
                itens = new List<PedidoItem>();

            return itens;
        }
    }
}

