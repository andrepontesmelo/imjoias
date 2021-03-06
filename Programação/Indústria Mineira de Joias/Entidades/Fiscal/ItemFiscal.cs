﻿using Acesso.Comum;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System;

namespace Entidades.Fiscal
{
    public abstract class ItemFiscal : DbManipulaçãoAutomática
    {
        [DbColuna("referencia")]
        protected string referência;

        [DbColuna("descricao")]
        protected string descrição;
        protected int? cfop;

        [DbColuna("tipounidade")]
        protected int? tipoUnidade;

        protected decimal quantidade;

        [DbColuna("valorunitario")]
        protected decimal valorUnitário;
        protected decimal valor;

        [DbChavePrimária(true)]
        protected int codigo;

        public ItemFiscal(string referência, string descrição, int? cfop,
            int tipoUnidade, decimal quantidade, decimal valorUnitário,
            decimal valor)
        {
            this.referência = referência;
            this.descrição = descrição;
            this.cfop = cfop;
            this.tipoUnidade = tipoUnidade;
            this.quantidade = quantidade;
            this.valorUnitário = valorUnitário;
            this.valor = valor;
        }

        public ItemFiscal()
        {
        }

        public int Código
        {
            set { codigo = value; }
            get { return codigo; }
        }

        internal static void CadastrarItens(string idSaídaFiscal, List<ItemFiscal> itens, IDbTransaction transação, IDbConnection conexão)
        {
            if (itens.Count == 0)
                return;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = ObterSqlInserção(idSaídaFiscal, itens);
                cmd.ExecuteNonQuery();
            }
        }

        private static string ObterSqlInserção(string idSaídaFiscal, List<ItemFiscal> itens)
        {
            var sql = new StringBuilder(string.Format("INSERT INTO {0} ({1}, referencia, descricao, cfop, " +
                "tipounidade, quantidade, valorunitario, valor) values (", itens[0].Relação, itens[0].RelaçãoPai));

            bool primeiro = true;

            foreach (ItemFiscal item in itens)
            {
                if (!primeiro)
                    sql.Append(",(");

                sql.Append(DbTransformar(idSaídaFiscal) + ",");
                sql.Append(DbTransformar(item.referência) + ",");
                sql.Append(DbTransformar(item.descrição) + ",");
                sql.Append(DbTransformar(item.cfop) + ",");
                sql.Append(DbTransformar(item.tipoUnidade) + ",");
                sql.Append(DbTransformar(item.quantidade) + ",");
                sql.Append(DbTransformar(item.valorUnitário) + ",");
                sql.Append(DbTransformar(item.valor));

                sql.Append(")");
                primeiro = false;
            }

            return sql.ToString();
        }

        protected abstract string Relação { get; }

        protected abstract string RelaçãoPai { get; }

        internal abstract void AtualizarIdDocumento(string novoId);
        
        public string Referência
        {
            get
            {
                return referência;
            }

            set
            {
                referência = value;
            }
        }

        public string Descrição
        {
            get
            {
                return descrição;
            }

            set
            {
                descrição = value;
            }
        }

        public int? Cfop
        {
            get
            {
                return cfop;
            }

            set
            {
                cfop = value;
            }
        }

        public int? TipoUnidade
        {
            get
            {
                return tipoUnidade;
            }

            set
            {
                tipoUnidade = value;
            }
        }

        public decimal Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public decimal ValorUnitário
        {
            get
            {
                return valorUnitário;
            }

            set
            {
                valorUnitário = value;
            }
        }

        public decimal Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public new void DefinirDesatualizado()
        {
            base.DefinirDesatualizado();
        }

        public void Excluir(List<ItemFiscal> itens)
        {
            ExecutarComando(string.Format("delete from {0} where codigo in ({1})", Relação, ObterCódigosSeparados(itens, ",")));
        }

        private string ObterCódigosSeparados(List<ItemFiscal> itens, string separação)
        {
            StringBuilder str = new StringBuilder();
            bool primeiro = true;

            foreach (ItemFiscal i in itens)
            {
                if (!primeiro)
                    str.Append(separação);

                str.Append(i.Código);

                primeiro = false;
            }

            return str.ToString();
        }
    }
}
