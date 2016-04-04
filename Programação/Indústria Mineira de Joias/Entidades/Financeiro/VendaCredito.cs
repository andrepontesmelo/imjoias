using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Financeiro
{
    public class VendaCrédito : DbManipulaçãoAutomática
    {
        private uint credito;
        private ulong venda;

        public uint Crédito
        {
            get { return credito; }
            set { credito = value; }
        }

        public ulong Venda
        {
            get { return venda; }
            set { venda = value; }
        }

        public VendaCrédito()
        {
        }

        public static List<VendaCrédito> ObterCréditos(ulong pessoa)
        {
            return Mapear<VendaCrédito>(
                 "select vc.credito, vc.venda from credito c left join vendacredito vc on c.codigo=vc.credito WHERE pessoa = "
                 + DbTransformar(pessoa) + " AND vc.credito is not null ");
        }

        public static Dictionary<uint, ulong> ObterHashCréditoVenda(ulong códigoPessoa)
        {
            List<VendaCrédito> paresVendaCrédito = ObterCréditos(códigoPessoa);

            Dictionary<uint, ulong> hashCréditoVenda = new Dictionary<uint, ulong>();
            foreach (VendaCrédito vendaCrédito in paresVendaCrédito)
                hashCréditoVenda.Add(vendaCrédito.Crédito, vendaCrédito.Venda);

            return hashCréditoVenda;
        }
    }
}
