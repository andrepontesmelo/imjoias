using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Acerto
{
    public class VendaAcerto : DbManipulaçãoAutomática
    {
        private ulong codigo;

        public ulong Código
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public VendaAcerto()
        {

        }

        /// <summary>
        /// Obtém vendas vinculadas a um acerto.
        /// </summary>
        public static List<VendaAcerto> ObterVendas(AcertoConsignado acerto)
        {
            List<VendaAcerto> vendas = Mapear<VendaAcerto>(
                "SELECT codigo, data FROM venda WHERE acerto = " + DbTransformar(acerto.Código));

            return vendas;
        }
    }
}
