using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    public class Saldo : DbManipulaçãoAutomática
    {
        private DateTime inicio;

        public DateTime Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }

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
            return Obter(true, true, null, Ordem.FornecedorReferênciaPeso, false);
        }

        public enum Ordem { FornecedorReferênciaPeso, ReferênciaPeso }
        
        public static List<Saldo> Obter(bool incluirPeso, bool incluirReferências, 
            Entidades.Fornecedor fornecedorÚnico, Ordem ordem, bool usarPesoMédio)
        {
            if (!incluirPeso && !incluirReferências)
                return new List<Saldo>();

            StringBuilder consulta = new StringBuilder();

            consulta.Append("select v.inicio, v.referenciafornecedor as referenciafornecedor, m.referencia, ");

            consulta.Append(usarPesoMédio ? " m.peso " : " ifnull(e.peso, m.peso) " );

            consulta.Append(" as peso, sum(ifnull(e.entrada,0)) as entrada,sum(ifnull(e.venda,0)) as venda ,sum(ifnull(e.devolucao,0)) as devolucao,sum(ifnull(e.saldo,0)) as saldo, " +
                " m.depeso, f.nome as fornecedornome from mercadoria m left join estoque_saldo e " +
                " on e.referencia=m.referencia " +
                " join vinculomercadoriafornecedor v on m.referencia=v.mercadoria join fornecedor f on v.fornecedor=f.codigo " +
                " WHERE foradelinha=0 AND " +
                (fornecedorÚnico != null ? " f.codigo= " + DbTransformar(fornecedorÚnico.Código) + " AND " : "") +
                " ( m.depeso=" + (incluirPeso ? "1" : "0") +
                " or m.depeso=" + (incluirReferências ? "0" : "1") +
                " ) ");
            
            consulta.Append(" GROUP BY ");
            consulta.Append(usarPesoMédio ? " m.referencia, m.peso " : " m.referencia, e.peso " );
            consulta.Append(" ORDER BY " + (ordem == Ordem.FornecedorReferênciaPeso ? " f.nome, m.referencia, e.peso " : " m.referencia, e.peso "));


            return Mapear<Saldo>(consulta.ToString());
        }

        public double ProdudoPesoSaldo
        { get { return peso * saldo;  } }

        public string InícioFormatado 
        {
            get { return (Inicio == null ? "" : Inicio.ToString("MM/yy"));  }
        }

        public string ReferênciaFormatadaComDígito 
        {
            get { return Entidades.Mercadoria.Mercadoria.MascararReferência(Referencia, true); }
        }
    }
}
