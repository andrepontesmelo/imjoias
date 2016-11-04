﻿using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Esquema
{
    [DbTabela("ingredienteesquemaproducaofiscal")]
    public class Ingrediente : DbManipulaçãoSimples
    {
        public Ingrediente()
        {
        }

        public Ingrediente(string esquema, string referencia, decimal quantidade)
        {
            this.esquema = esquema;
            this.referencia = referencia;
            this.quantidade = quantidade;
        }

        private string esquema;
        private string referencia;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;
        private int cfop;

        private string referenciaAlterada;

        public string Esquema => esquema;
        public string Descrição => descricao;
        public int CFOP => cfop;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);

        public decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public string Referência
        {
            get { return referenciaAlterada == null ? referencia : referenciaAlterada; }
            set { referenciaAlterada = value;  }
        }

        public static List<Ingrediente> Obter(string esquema)
        {
            return Mapear<Ingrediente>(
                string.Format("select i.*, m.nome as descricao, m.tipounidade, m.cfop from ingredienteesquemaproducaofiscal i join mercadoria m on " + 
                " i.referencia=m.referencia where esquema={0}", DbTransformar(esquema)));
        }

        public void Atualizar()
        {
            var sql = "UPDATE ingredienteesquemaproducaofiscal set " +
                "referencia=" + DbTransformar(Referência) + ", " +
                "quantidade=" + DbTransformar(Quantidade) +
                " WHERE referencia=" + DbTransformar(referencia) +
                " AND esquema=" + DbTransformar(Esquema);

            ExecutarComando(sql);
        }

        public void Cadastrar()
        {
            ExecutarComando(string.Format("INSERT INTO ingredienteesquemaproducaofiscal (referencia, quantidade, esquema) values ({0},{1},{2})",
                DbTransformar(Referência), DbTransformar(Quantidade), DbTransformar(Esquema)));
        }

        public static void Excluir(List<Ingrediente> ingredientes)
        {
            var sql = "DELETE FROM ingredienteesquemaproducaofiscal where ";
            bool primeiro = true;

            foreach (Ingrediente i in ingredientes)
            {
                if (!primeiro)
                    sql += " OR ";

                sql += " (esquema= " + DbTransformar(i.esquema);
                sql += " AND referencia=" + DbTransformar(i.referencia);
                sql += " ) ";

                primeiro = false;
            }

            ExecutarComando(sql);
        }
    }
}
