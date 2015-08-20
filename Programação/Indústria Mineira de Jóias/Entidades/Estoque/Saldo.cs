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
        private string referenciafornecedor;

        public string FornecedorReferência
        {
            get { return referenciafornecedor; }
            set { referenciafornecedor = value; }
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
            return Obter(true, true, null, Ordem.FornecedorReferênciaPeso);
        }

        public enum Ordem { FornecedorReferênciaPeso, ReferênciaPeso }
        
        public static List<Saldo> Obter(bool incluirPeso, bool incluirReferências, Entidades.Fornecedor fornecedorÚnico, Ordem ordem)
        {
            if (!incluirPeso && !incluirReferências)
                return new List<Saldo>();

            String consulta =

            "select v.referenciafornecedor as referenciafornecedor, m.referencia, ifnull(e.peso,m.peso) as peso, ifnull(e.entrada,0) as entrada,ifnull(e.venda,0) as venda ,ifnull(e.devolucao,0) as devolucao,ifnull(e.saldo,0) as saldo, " +
                " m.depeso, f.nome as fornecedornome from mercadoria m left join estoque_saldo e " +
                " on e.referencia=m.referencia " +
                " join vinculomercadoriafornecedor v on m.referencia=v.mercadoria join fornecedor f on v.fornecedor=f.codigo " +
                " WHERE 1=1 AND " +
                (fornecedorÚnico != null ? " f.codigo= " + DbTransformar(fornecedorÚnico.Código) + " AND " : "") +
                " ( m.depeso=" + (incluirPeso ? "1" : "0") +
                " or m.depeso=" + (incluirReferências ? "0" : "1") +
                " ) ORDER BY " + (ordem == Ordem.FornecedorReferênciaPeso ? " f.nome, m.referencia, e.peso " : " m.referencia, e.peso ");

            return Mapear<Saldo>(consulta);
        }

        public double ProdudoPesoSaldo
        { get { return peso * saldo;  } }
    }
}
