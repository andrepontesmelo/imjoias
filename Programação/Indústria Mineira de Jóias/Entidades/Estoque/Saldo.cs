using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    public class Saldo : DbManipulaçãoAutomática
    {
        private string fornecedornome;

        public string FornecedorNome
        {
            get { return fornecedornome; }
            set { fornecedornome = value; }
        }
        private string fornecedorreferencia;

        public string FornecedorReferência
        {
            get { return fornecedorreferencia; }
            set { fornecedorreferencia = value; }
        }

        private string referencia;

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }
        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private double entrada;

        public double Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }
        private double venda;

        public double Venda
        {
            get { return venda; }
            set { venda = value; }
        }
        private double devolucao;

        public double Devolucao
        {
            get { return devolucao; }
            set { devolucao = value; }
        }
        private double saldo;

        /// <summary>
        /// Entrada - Venda + Devolução
        /// </summary>
        public double SaldoValor
        {
            get { return saldo; }
            set { saldo = value; }
        }

        private bool depeso;

        public bool Depeso
        {
            get { return depeso; }
            set { depeso = value; }
        }

        public Saldo()
        { }


        public static List<Saldo> Obter()
        {
            return Obter(true, true);
        }
        public static List<Saldo> Obter(bool incluirPeso, bool incluirReferências)
        {
            if (!incluirPeso && !incluirReferências)
                return new List<Saldo>();

            return Mapear<Saldo>("select e.*, m.depeso, f.nome as fornecedornome, v.referenciafornecedor as fornecedorreferencia from estoque_saldo e " +
                " join mercadoria m on e.referencia=m.referencia " +
                " join vinculomercadoriafornecedor v on e.referencia=v.mercadoria join fornecedor f on v.fornecedor=f.codigo " +
                " WHERE m.depeso=" + (incluirPeso ? "1" : "0") +
                " or m.depeso=" + (incluirReferências ? "0" : "1"));
        }

        public double ProdudoPesoSaldo
        { get { return peso * saldo;  } }
    }
}
