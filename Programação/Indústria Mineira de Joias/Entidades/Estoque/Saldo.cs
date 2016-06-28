using Acesso.Comum;
using System;
using System.Collections.Generic;
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

        private ulong fornecedor;

        public ulong Fornecedor => fornecedor;

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

        private bool foradelinha;

        public bool ForaDeLinhaFornecedor
        {
            get { return foradelinha; } 
            set { foradelinha = value;  }
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

            consulta.Append("select v.inicio, v.referenciafornecedor as referenciafornecedor, v.foradelinha, m.referencia, ");
            consulta.Append(usarPesoMédio ? " m.peso " : " ifnull(e.peso, m.peso) " );

            consulta.Append(" as peso, sum(ifnull(e.entrada,0)) as entrada,sum(ifnull(e.venda,0)) as venda ,sum(ifnull(e.devolucao,0)) as devolucao,sum(ifnull(e.saldo,0)) as saldo, " +
                " m.depeso, v.fornecedor from mercadoria m left join estoque_saldo e " +
                " on e.referencia=m.referencia " +
                " join vinculomercadoriafornecedor v on m.referencia=v.mercadoria " +
                " WHERE m.foradelinha=0 AND " +
                (fornecedorÚnico != null ? " v.fornecedor= " + DbTransformar(fornecedorÚnico.Código) + " AND " : "") +
                " ( m.depeso=" + (incluirPeso ? "1" : "0") +
                " or m.depeso=" + (incluirReferências ? "0" : "1") +
                " ) ");
            
            consulta.Append(" GROUP BY ");
            string peso = (usarPesoMédio ? "m.peso" : "e.peso");
            consulta.Append(" m.referencia,");
            consulta.Append(peso);
            consulta.Append(", inicio, referenciafornecedor, v.fornecedor ");
            consulta.Append(" ORDER BY ");
            consulta.Append((ordem == Ordem.FornecedorReferênciaPeso ? " v.fornecedor ,  " : " "));
            consulta.Append(" m.referencia, ");
            consulta.Append(peso);

            return Mapear<Saldo>(consulta.ToString());
        }

        public double ProdudoPesoSaldo
        {
            get
            {
                return peso * saldo;
            }
        }

        public string InícioFormatado 
        {
            get { return (Inicio == null ? "" : Inicio.ToString("MM/yy"));  }
        }

        public string ReferênciaFormatadaComDígito 
        {
            get { return Mercadoria.Mercadoria.MascararReferência(Referencia, true); }
        }
    }
}
