﻿using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal
{
    public class Fechamento : DbManipulaçãoAutomática
    {
        [DbChavePrimária(true)]
        private int codigo;
        private DateTime inicio;
        private DateTime fim;
        private bool fechado;

        public Fechamento()
        {
            inicio = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month,
                1);

            fim = inicio.AddMonths(1).AddDays(-1);

            fechado = false;
        }

        public int Código => codigo;

        public DateTime Início
        {
            get { return inicio; }
            set
            {
                inicio = value;
                DefinirDesatualizado();
            }
        }

        public DateTime Fim
        {
            get { return fim; }
            set
            {
                fim = value;
                DefinirDesatualizado();
            }
        }

        public bool Fechado
        {
            get { return fechado; }
            set
            {
                fechado = value;
                DefinirDesatualizado();
            }
        }


        private static List<Fechamento> cache = null;
        public static List<Fechamento> Obter()
        {
            if (cache == null)
                cache = Mapear<Fechamento>("select * from fechamento");

            return cache;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} a {2}",
                codigo,
                inicio.ToShortDateString(),
                fim.ToShortDateString());
        }

        public override void Cadastrar()
        {
            base.Cadastrar();
            cache = null;
        }

        public override void Descadastrar()
        {
            base.Descadastrar();
            cache = null;
        }

        public override void Atualizar()
        {
            base.Atualizar();
            cache = null;
        }

        internal bool Fora(DateTime data)
        {
            return !Dentro(data);
        }

        private bool Dentro(DateTime data)
        {
            return data >= Início && data < Fim.AddDays(1);  
        }

        public void AtualizarMercadorias()
        {
            if (Fechado)
                throw new Exception("Não é possível atualizar um fechamento fechado");

            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    using (var cmd = conexão.CreateCommand())
                    {
                        cmd.Transaction = transação;
                        cmd.CommandText = "delete from mercadoriafechamento where fechamento=" + DbTransformar(Código);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = conexão.CreateCommand())
                    {
                        cmd.Transaction = transação;
                        cmd.CommandText = string.Format("insert into mercadoriafechamento(referencia, descricao, valor, fechamento) " +
                        " select m.*, {0} as fechamento from mercadoria_fiscal m", DbTransformar(Código));
                        cmd.ExecuteNonQuery();
                    }

                    transação.Commit();
                }
            }
        }
    }
}
