using Acesso.Comum;
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

        private static ConfiguraçãoGlobal<int> cfopPadrãoOperaçõesInternas =
            new ConfiguraçãoGlobal<int>("cfopPadrãoOperaçõesInternas", 1999);

        public static ConfiguraçãoGlobal<int> CfopPadrãoOperaçõesInternas => cfopPadrãoOperaçõesInternas;

        public DateTime Data
        {
            get { return data; }
            set
            {
                data = value;
                DefinirDesatualizado();

                AtualizarMercadoriasFechamento();
            }
        }

        public void AtualizarMercadoriasFechamento()
        {
            var fechamento = Fechamento.Obter(data);

            if (fechamento == null)
                return;

            fechamento.AtualizarMercadoriasSeAberto();
        }


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
            fabricação.AtualizarMercadoriasFechamento();

            return fabricação;
        }

        public static FabricaçãoFiscal Criar(List<ItemFabricaçãoFiscal> itens, Fechamento fechamento)
        {
            LevantarErrosCriação(itens, fechamento);

            var fabricação = Criar();
            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    foreach (ItemFabricaçãoFiscal item in itens)
                        fabricação.AdicionarFabricação(conexão, transação, item,
                            ObterEsquemaLevantandoErroCasoNãoExista(item, fechamento));

                    transação.Commit();
                }
            }

            return fabricação;
        }

        private static void LevantarErrosCriação(List<ItemFabricaçãoFiscal> itens, Fechamento fechamento)
        {
            foreach (ItemFabricaçãoFiscal item in itens)
                ObterEsquemaLevantandoErroCasoNãoExista(item, fechamento);

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

        public void AdicionarFabricação(ItemFabricaçãoFiscal novoItem, Fechamento fechamento)
        {
            var esquema = ObterEsquemaLevantandoErroCasoNãoExista(novoItem, fechamento);

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

            var ingredientes = MateriaPrima.Obter(esquema.Referência, esquema.Fechamento);
            decimal qtdReceitas = novoItem.Quantidade / esquema.Quantidade;

            AdicionarSaída(conexão, transação, novoItem, qtdReceitas, esquema.Fechamento);
            
            foreach (var ingrediente in ingredientes)
                AdicionarEntrada(conexão, transação, qtdReceitas, ingrediente, esquema.Fechamento);
        }

        private static EsquemaFabricação ObterEsquemaLevantandoErroCasoNãoExista(ItemFabricaçãoFiscal novoItem, Fechamento fechamento)
        {
            EsquemaFabricação esquema = EsquemaFabricação.ObterÚnico(fechamento, novoItem.Referência);

            if (esquema == null)
                throw new EsquemaInexistente(novoItem.Referência);

            return esquema;
        }

        private void AdicionarEntrada(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, decimal qtdReceitas, MateriaPrima ingrediente, int fechamento)
        {
            var hashReferênciaValor = MercadoriaFechamento.ObterHash(fechamento);

            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = EntradaFabricaçãoFiscal.ObterSqlInserçãoEntrada(this, ingrediente, qtdReceitas, hashReferênciaValor[ingrediente.Referência].Valor, cfopPadrãoOperaçõesInternas.Valor);
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
        }

        private void AdicionarSaída(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação, ItemFabricaçãoFiscal novoItem, decimal qtdReceitas, int fechamento)
        {
            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = SaídaFabricaçãoFiscal.ObterSqlInserçãoSaída(this, qtdReceitas, novoItem.Referência, novoItem.Quantidade, novoItem.Valor, cfopPadrãoOperaçõesInternas.Valor);
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
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
