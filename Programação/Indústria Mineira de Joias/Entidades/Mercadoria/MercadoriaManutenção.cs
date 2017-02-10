using Acesso.Comum;
using System.Collections.Generic;

namespace Entidades.Mercadoria
{
    public class MercadoriaManutenção : DbManipulaçãoSimples
    {
        private string referencia;
        private double peso;
        private bool depeso;
        private bool foradelinha;
        private uint fornecedor;
        private double precocusto;
        private string nome;

        public string Referência => referencia;
        public double Peso => peso;
        public bool DePeso => depeso;
        public uint Fornecedor => fornecedor;
        public bool ForaDeLinha => foradelinha;
        public double PreçoCusto => precocusto;
        public string Nome => nome;

        public static List<MercadoriaManutenção> Obter()
        {
            return Mapear<MercadoriaManutenção>(
                "select referencia, m.peso, depeso, m.foradelinha, vf.fornecedor, " +
                " nome, novoPrecoCusto as precocusto from mercadoria m left join  " +
                " vinculomercadoriafornecedor vf on m.referencia = vf.mercadoria  " +
                " join novosPrecos n on n.mercadoria = m.referencia ");
        }
    }
}
