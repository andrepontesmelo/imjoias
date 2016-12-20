using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void CopiarEsquemasDe(Fechamento origem)
        {
            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    ApagarEsquemaFabricação(conexão, transação);
                    ApagarMatériaPrima(conexão, transação);
                    InserirEsquemaFabricação(origem, conexão, transação);
                    InserirMatériaPrima(origem, conexão, transação);

                    transação.Commit();
                }
            }
        }

        private void InserirMatériaPrima(Fechamento origem, System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = string.Format("insert into materiaprimaesquemafabricacaofiscal select " +
                    " esquema, materiaprima, quantidade, {0} as fechamento from materiaprimaesquemafabricacaofiscal where fechamento={1}",
                    DbTransformar(Código),
                    DbTransformar(origem.Código));

                cmd.ExecuteNonQuery();
            }
        }

        private void InserirEsquemaFabricação(Fechamento origem, System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = string.Format("insert into esquemafabricacaofiscal select referencia, quantidade, {0} as fechamento " +
                    " from esquemafabricacaofiscal where fechamento={1}",
                    DbTransformar(Código),
                    DbTransformar(origem.Código));

                cmd.ExecuteNonQuery();
            }
        }

        private void ApagarMatériaPrima(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = "delete from materiaprimaesquemafabricacaofiscal where fechamento=" + DbTransformar(Código);
                cmd.ExecuteNonQuery();
            }
        }

        private void ApagarEsquemaFabricação(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;
                cmd.CommandText = "delete from esquemafabricacaofiscal where fechamento=" + DbTransformar(Código);
                cmd.ExecuteNonQuery();
            }
        }

        public static Fechamento Obter(DateTime data)
        {
            data = new DateTime(data.Year, data.Month, data.Day);

            return MapearÚnicaLinha<Fechamento>(string.Format("select * from fechamento where inicio <= {0} and fim >= {0} limit 1",
                DbTransformar(data)));
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

        public static Fechamento Obter(int código)
        {
            if (cache == null)
                cache = Obter();

            var item =
                (from i in cache
                where i.Código.Equals(código)
                select i).FirstOrDefault();

            return item;
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

        public void AtualizarMercadoriasSeAberto()
        {
            if (Fechado)
                return;

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
                        cmd.CommandText = string.Format("insert into mercadoriafechamento(referencia, descricao, valor, peso, depeso, fechamento) " +
                        " select m.*, {0} as fechamento from mercadoria_fiscal m", DbTransformar(Código));
                        cmd.ExecuteNonQuery();
                    }

                    transação.Commit();
                }
            }
        }
    }
}
