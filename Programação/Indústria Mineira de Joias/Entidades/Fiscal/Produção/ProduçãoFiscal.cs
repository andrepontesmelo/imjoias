using Acesso.Comum;
using Entidades.Configuração;
using Entidades.Fiscal.Esquema;
using Entidades.Fiscal.Excessões;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Fiscal.Produção
{
    [DbTabela("producaofiscal")]
    public class ProduçãoFiscal : DbManipulaçãoAutomática
    {
        [DbChavePrimária(true)]
        private int codigo;
        private DateTime data;

        public int Código => codigo;
        public DateTime Data => data;

        public string DataFormatada => string.Format("{0} {1}", data.ToShortDateString(), data.ToShortTimeString());

        public ProduçãoFiscal()
        {
        }

        public ProduçãoFiscal(DateTime data)
        {
            this.data = data;
        }

        public static ProduçãoFiscal Criar()
        {
            var produção = new ProduçãoFiscal(DadosGlobais.Instância.HoraDataAtual);
            produção.Cadastrar();

            return produção;
        }

        public static List<ProduçãoFiscal> Obter()
        {
            return Mapear<ProduçãoFiscal>("select * from producaofiscal");
        }

        public void AdicionarProdução(ItemProduçãoFiscal novoItem)
        {
            var esquema = ObterEsquemaLevantandoErroCasoNãoExista(novoItem);

            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    AdicionarProdução(conexão, transação, novoItem, esquema);
                    transação.Commit();
                }
            }
        }

        private void AdicionarProdução(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, ItemProduçãoFiscal novoItem, EsquemaProdução esquema)
        {
            var ingredientes = Ingrediente.Obter(esquema.Referência);
            decimal qtdReceitas = novoItem.Quantidade / esquema.Quantidade;

            AdicionarSaída(conexão, transação, novoItem, qtdReceitas);

            foreach (var ingrediente in ingredientes)
                AdicionarEntrada(conexão, transação, qtdReceitas, ingrediente);
        }

        private static EsquemaProdução ObterEsquemaLevantandoErroCasoNãoExista(ItemProduçãoFiscal novoItem)
        {
            EsquemaProdução esquema = EsquemaProdução.Obter(novoItem.Referência);

            if (esquema == null)
                throw new EsquemaInexistente(novoItem.Referência);

            return esquema;
        }

        private void AdicionarEntrada(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, decimal qtdReceitas, Ingrediente ingrediente)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = EntradaProduçãoFiscal.ObterSqlInserçãoEntrada(this, ingrediente, qtdReceitas);
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
        }

        private void AdicionarSaída(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, ItemProduçãoFiscal novoItem, decimal qtdReceitas)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = SaídaProduçãoFiscal.ObterSqlInserçãoSaída(this, qtdReceitas, novoItem.Referência, novoItem.Quantidade);
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
        }

        public void Remover(List<ItemProduçãoFiscal> itensRemover)
        {
            List<ItemProduçãoFiscal> novaListaSaída = FiltrarItens(SaídaProduçãoFiscal.Obter(Código), itensRemover);

            foreach (ItemProduçãoFiscal novoItem in novaListaSaída)
                ObterEsquemaLevantandoErroCasoNãoExista(novoItem);

            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    RemoverSaídas(conexão, transação);
                    RemoverEntradas(conexão, transação);

                    foreach (ItemProduçãoFiscal novoItem in novaListaSaída)
                        AdicionarProdução(conexão, transação, novoItem, ObterEsquemaLevantandoErroCasoNãoExista(novoItem));

                    transação.Commit();
                }
            }
        }

        private void RemoverItens(System.Data.IDbConnection conexão, string relação, System.Data.IDbTransaction transação)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = string.Format("delete from {0} where producaofiscal = {1}", relação, DbTransformar(Código));
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
        }

        private void RemoverEntradas(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            RemoverItens(conexão, EntradaProduçãoFiscal.RELAÇÃO, transação);
        }

        private void RemoverSaídas(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            RemoverItens(conexão, SaídaProduçãoFiscal.RELAÇÃO, transação);
        }

        private List<ItemProduçãoFiscal> FiltrarItens(List<ItemProduçãoFiscal> itens, List<ItemProduçãoFiscal> itensExcluir)
        {
            List<ItemProduçãoFiscal> novaLista = new List<Produção.ItemProduçãoFiscal>();

            foreach (ItemProduçãoFiscal i in itens)
            {
                if (!itensExcluir.Contains(i))
                    novaLista.Add(i);
            }

            return novaLista;
        }

        public static void Remover(List<ProduçãoFiscal> lstProduções)
        {
            StringBuilder sql = new StringBuilder("delete from producaofiscal where codigo in (");

            bool primeiro = true;
            foreach (ProduçãoFiscal f in lstProduções)
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
