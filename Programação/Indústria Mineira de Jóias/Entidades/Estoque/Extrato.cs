using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    public class Extrato : DbManipulaçãoAutomática
    {

        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
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
        private string operacao;

        public string Operacao
        {
            get { return operacao; }
            set { operacao = value; }
        }
    
        public Extrato()
        {

        }

        [DbAtributo(TipoAtributo.Ignorar)]
        private double saldo;

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }



        public static List<Extrato> Obter(string referencia, double? peso)
        {
            StringBuilder sql = new StringBuilder("select * from estoque_extrato where referencia = ");
            sql.Append(referencia);

            if (peso.HasValue)
            { 
                sql.Append(" AND peso= ");
                sql.Append(DbTransformar(peso.Value));
            }

            return Mapear<Extrato>(sql.ToString());
        }

        public static void ComputarSaldo(List<Extrato> entidades)
        {
            double saldo = 0;
            foreach (Extrato e in entidades)
            {
                saldo += e.entrada;
                saldo -= e.venda;
                saldo += e.devolucao;
                e.Saldo = saldo;
            }
        }
    }
}
