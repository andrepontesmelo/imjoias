using Acesso.Comum;
using Entidades.Configuração;
using Entidades.Fiscal.Esquema;
using Entidades.Fiscal.Exceções;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

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

        public static FabricaçãoFiscal Criar(List<SaídaFabricaçãoFiscal> itens, Fechamento fechamento)
        {
            Dictionary<string, EsquemaFabricação> hashEsquemas = EsquemaFabricação.ObterHashEsquemas(fechamento);

            LevantarErrosCriação(itens, hashEsquemas);

            var fabricação = Criar();
            fabricação.AdicionarMatériasPrimas(itens, hashEsquemas);

            return fabricação;
        }

        public void AdicionarMatériasPrimas(List<SaídaFabricaçãoFiscal> itens, Dictionary<string, EsquemaFabricação> hashEsquemas)
        {
            LevantarErrosCriação(itens, hashEsquemas);

            StringBuilder cmd = SaídaFabricaçãoFiscal.ObterCabeçalhoSqlInserçãoSaída();

            bool primeiro = true;

            foreach (var novoItem in itens)
            {
                if (!primeiro)
                    cmd.Append(", ");

                SaídaFabricaçãoFiscal.AdicionarSqlInserçãoSaída(cmd, this, novoItem.Referência, novoItem.Quantidade, novoItem.Valor, novoItem.CFOP, novoItem.Peso);

                primeiro = false;
            }

            ExecutarComando(cmd.ToString());
            RecalcularMatériasPrimas();
        }

        public void AdicionarFabricação(SaídaFabricaçãoFiscal novoItem, Dictionary<string, EsquemaFabricação> hashEsquemas)
        {
            ObterEsquemaLevantandoErroCasoNãoExista(novoItem, hashEsquemas);
            ExecutarComando(SaídaFabricaçãoFiscal.ObterSqlInserçãoSaída(this, novoItem.Referência, novoItem.Quantidade, novoItem.Valor, novoItem.CFOP, novoItem.Peso));
            RecalcularMatériasPrimas();
        }

        private static void LevantarErrosCriação(List<SaídaFabricaçãoFiscal> itens, Dictionary<string, EsquemaFabricação> hashEsquemas)
        {
            foreach (ItemFabricaçãoFiscal item in itens)
                ObterEsquemaLevantandoErroCasoNãoExista(item, hashEsquemas);

            if (!ExisteItemNãoVazio(itens))
                throw new FabricaçãoVazia();
        }

        private static bool ExisteItemNãoVazio(List<SaídaFabricaçãoFiscal> itens)
        {
            return (from i in itens where i.Quantidade != 0 select i).FirstOrDefault() != null;
        }

        public static List<FabricaçãoFiscal> Obter(DateTime inicio, DateTime fim)
        {
            return Mapear<FabricaçãoFiscal>(string.Format("select * from fabricacaofiscal where {0}",
            DbDataEntre("data", inicio, fim)));
        }

        private static EsquemaFabricação ObterEsquemaLevantandoErroCasoNãoExista(ItemFabricaçãoFiscal novoItem, Dictionary<string, EsquemaFabricação> hashEsquemas)
        {
            EsquemaFabricação resultado = null;

            if (!hashEsquemas.TryGetValue(novoItem.Referência, out resultado))
                throw new EsquemaInexistente(novoItem.Referência);

            return resultado;
        }

        private void AdicionarMatériaPrimaSql(IDbConnection conexão, IDbTransaction transação, decimal qtd, decimal valor, string ingrediente, int fechamento, int fabricação)
        {
            var hashReferênciaValor = MercadoriaFechamento.ObterHash(fechamento);

            using (var cmd = conexão.CreateCommand())
            {
                cmd.CommandText = EntradaFabricaçãoFiscal.ObterSqlInserçãoEntrada(Código, ingrediente, qtd, valor, cfopPadrãoOperaçõesInternas.Valor);
                cmd.Transaction = transação;
                cmd.ExecuteNonQuery();
            }
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

        public void RecalcularMatériasPrimas()
        {
            var saídas = SaídaFabricaçãoFiscal.Obter(codigo);
            var fechamentoVigente = Fechamento.Obter(data);
            var hashReferênciaValor = MercadoriaFechamento.ObterHash(fechamentoVigente.Código);
            var hashEsquemas = EsquemaFabricação.ObterHashEsquemas(fechamentoVigente);

            var hashMatériasPrimas = CalcularMatériasPrimas(saídas, hashEsquemas, fechamentoVigente);

            var conexão = Conexão;
            
            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    RemoverMatériasPrimas(conexão, transação);

                    foreach (KeyValuePair<string, decimal> par in hashMatériasPrimas)
                    {
                        var matériaPrima = par.Key;
                        var qtd = par.Value;
                        var valor = hashReferênciaValor[matériaPrima].Valor;

                        AdicionarMatériaPrimaSql(conexão, transação, qtd, valor, matériaPrima, fechamentoVigente.Código, Código);
                    }
                    transação.Commit();
                }
            }
        }

        public Dictionary<string, decimal> CalcularMatériasPrimas(List<SaídaFabricaçãoFiscal> itens, 
            Dictionary<string, EsquemaFabricação> hashEsquemas,
            Fechamento fechamento)
        {
            Dictionary<string, decimal> hashMatériaPrimaQuantidade = new Dictionary<string, decimal>();
            Dictionary<string, List<MateriaPrima>> hashEsquemaMatériaPrima = MateriaPrima.ObterHash(fechamento.Código);

            foreach (SaídaFabricaçãoFiscal item in itens)
            {
                var esquemaFabricação = ObterEsquemaLevantandoErroCasoNãoExista(item, hashEsquemas);
                ProcessarSaída(hashMatériaPrimaQuantidade, hashEsquemaMatériaPrima, item, esquemaFabricação);
            }

            return hashMatériaPrimaQuantidade;
        }

        private void ProcessarSaída(Dictionary<string, decimal> hashMatériaPrimaQuantidade, 
            Dictionary<string, List<MateriaPrima>> hashEsquemaMatériaPrima,            
            SaídaFabricaçãoFiscal novoItem, 
            EsquemaFabricação esquema)
        {
            if (novoItem.Quantidade == 0)
                return;

            var ingredientes = hashEsquemaMatériaPrima[esquema.Referência];
            decimal qtdReceitas = novoItem.Quantidade / esquema.Quantidade;

            foreach (var ingrediente in ingredientes)
            {
                if (ingrediente.Proporcional)
                    qtdReceitas *= novoItem.Peso;

                ProcessarIngrediente(hashMatériaPrimaQuantidade, qtdReceitas, ingrediente);
            }
        }

        private void ProcessarIngrediente(Dictionary<string, decimal> hashMatériaPrimaQuantidade, decimal qtdReceitas, MateriaPrima ingrediente)
        {
            string matériaPrima = ingrediente.Referência;
            decimal qtd = qtdReceitas * ingrediente.Quantidade;

            decimal qtdAnterior = 0;
            hashMatériaPrimaQuantidade.TryGetValue(matériaPrima, out qtdAnterior);

            hashMatériaPrimaQuantidade[matériaPrima] = qtdAnterior + qtd;
        }


        private void RemoverMatériasPrimas(System.Data.IDbConnection conexão, System.Data.IDbTransaction transação)
        {
            RemoverItens(conexão, EntradaFabricaçãoFiscal.RELAÇÃO, transação);
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

    }
}
