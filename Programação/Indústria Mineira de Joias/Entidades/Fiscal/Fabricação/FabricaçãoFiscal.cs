﻿using Acesso.Comum;
using Entidades.Configuração;
using Entidades.Fiscal.Esquema;
using Entidades.Fiscal.Exceções;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Entidades.Fiscal.Fabricação
{
    [DbTabela("fabricacaofiscal")]
    public class FabricaçãoFiscal : DbManipulaçãoAutomática
    {
        [DbChavePrimária(true)]
        private int codigo;
        private DateTime data;

        public int Código => codigo;
        public DateTime Data => data;

        public string DataFormatada => string.Format("{0} {1}", data.ToShortDateString(), data.ToShortTimeString());

        public FabricaçãoFiscal()
        {
        }

        public FabricaçãoFiscal(DateTime data)
        {
            this.data = data;
        }

        public static FabricaçãoFiscal Criar()
        {
            var fabricação = new FabricaçãoFiscal(DadosGlobais.Instância.HoraDataAtual);
            fabricação.Cadastrar();

            return fabricação;
        }

        public static FabricaçãoFiscal Criar(List<ItemFabricaçãoFiscal> itens)
        {
            LevantarErrosCriação(itens);

            var fabricação = Criar();
            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    foreach (ItemFabricaçãoFiscal item in itens)
                        fabricação.AdicionarFabricação(conexão, transação, item,
                            ObterEsquemaLevantandoErroCasoNãoExista(item));

                    transação.Commit();
                }
            }

            return fabricação;
        }

        private static void LevantarErrosCriação(List<ItemFabricaçãoFiscal> itens)
        {
            foreach (ItemFabricaçãoFiscal item in itens)
                ObterEsquemaLevantandoErroCasoNãoExista(item);

            if (!ExisteItemNãoVazio(itens))
                throw new FabricaçãoVazia();
        }

        private static bool ExisteItemNãoVazio(List<ItemFabricaçãoFiscal> itens)
        {
            return (from i in itens where i.Quantidade != 0 select i).FirstOrDefault() != null;
        }

        public static List<FabricaçãoFiscal> Obter(DateTime inicio, DateTime fim)
        {
            return Mapear<FabricaçãoFiscal>(string.Format("select * from fabricacaofiscal where {0}",
            DbDataEntre("data", inicio, fim.AddDays(1))));
        }

        public void AdicionarFabricação(ItemFabricaçãoFiscal novoItem)
        {
            var esquema = ObterEsquemaLevantandoErroCasoNãoExista(novoItem);

            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    AdicionarFabricação(conexão, transação, novoItem, esquema);
                    transação.Commit();
                }
            }
        }

        private void AdicionarFabricação(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, ItemFabricaçãoFiscal novoItem, EsquemaFabricação esquema)
        {
            if (novoItem.Quantidade == 0)
                return;

            var ingredientes = MateriaPrima.Obter(esquema.Referência);
            decimal qtdReceitas = novoItem.Quantidade / esquema.Quantidade;

            AdicionarSaída(conexão, transação, novoItem, qtdReceitas);

            foreach (var ingrediente in ingredientes)
                AdicionarEntrada(conexão, transação, qtdReceitas, ingrediente);
        }

        private static EsquemaFabricação ObterEsquemaLevantandoErroCasoNãoExista(ItemFabricaçãoFiscal novoItem)
        {
            EsquemaFabricação esquema = EsquemaFabricação.Obter(novoItem.Referência);

            if (esquema == null)
                throw new EsquemaInexistente(novoItem.Referência);

            return esquema;
        }

        private void AdicionarEntrada(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, decimal qtdReceitas, MateriaPrima ingrediente)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = EntradaFabricaçãoFiscal.ObterSqlInserçãoEntrada(this, ingrediente, qtdReceitas);
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
        }

        private void AdicionarSaída(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, ItemFabricaçãoFiscal novoItem, decimal qtdReceitas)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = SaídaFabricaçãoFiscal.ObterSqlInserçãoSaída(this, qtdReceitas, novoItem.Referência, novoItem.Quantidade);
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
        }

        public void Remover(List<ItemFabricaçãoFiscal> itensRemover)
        {
            List<ItemFabricaçãoFiscal> novaListaSaída = FiltrarItens(SaídaFabricaçãoFiscal.Obter(Código), itensRemover);

            foreach (ItemFabricaçãoFiscal novoItem in novaListaSaída)
                ObterEsquemaLevantandoErroCasoNãoExista(novoItem);

            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    RemoverSaídas(conexão, transação);
                    RemoverEntradas(conexão, transação);

                    foreach (ItemFabricaçãoFiscal novoItem in novaListaSaída)
                        AdicionarFabricação(conexão, transação, novoItem, ObterEsquemaLevantandoErroCasoNãoExista(novoItem));

                    transação.Commit();
                }
            }
        }

        private void RemoverItens(System.Data.IDbConnection conexão, string relação, System.Data.IDbTransaction transação)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = string.Format("delete from {0} where fabricacaofiscal = {1}", relação, DbTransformar(Código));
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
        }

        private void RemoverEntradas(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            RemoverItens(conexão, EntradaFabricaçãoFiscal.RELAÇÃO, transação);
        }

        private void RemoverSaídas(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            RemoverItens(conexão, SaídaFabricaçãoFiscal.RELAÇÃO, transação);
        }

        private List<ItemFabricaçãoFiscal> FiltrarItens(List<ItemFabricaçãoFiscal> itens, List<ItemFabricaçãoFiscal> itensExcluir)
        {
            List<ItemFabricaçãoFiscal> novaLista = new List<ItemFabricaçãoFiscal>();

            foreach (ItemFabricaçãoFiscal i in itens)
            {
                if (!itensExcluir.Contains(i))
                    novaLista.Add(i);
            }

            return novaLista;
        }

        public static void Remover(List<FabricaçãoFiscal> lstFabricações)
        {
            StringBuilder sql = new StringBuilder("delete from fabricacaofiscal where codigo in (");

            bool primeiro = true;
            foreach (FabricaçãoFiscal f in lstFabricações)
            {
                if (!primeiro)
                    sql.Append(", ");

                sql.Append(f.Código);

                primeiro = false;
            }

            sql.Append(")");

            ExecutarComando(sql.ToString());
        }
    }
}
