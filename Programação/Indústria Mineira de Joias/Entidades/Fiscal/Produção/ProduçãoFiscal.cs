using Acesso.Comum;
using Entidades.Configuração;
using Entidades.Fiscal.Esquema;
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

        public static void Excluir(List<ProduçãoFiscal> lstProduções)
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

        public void AdicionarProdução(string referência, decimal quantidade)
        {
            EsquemaProdução esquema = EsquemaProdução.Obter(referência);
            var ingredientes = Ingrediente.Obter(esquema.Referência);
            decimal qtdReceitas = quantidade / esquema.Quantidade;

            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    using (var cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = SaídaProduçãoFiscal.ObterSqlInserçãoSaída(this, qtdReceitas, referência, quantidade);
                        cmd.Transaction = transação;
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var ingrediente in ingredientes)
                    {
                        using (var cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = EntradaProduçãoFiscal.ObterSqlInserçãoEntrada(this, ingrediente, qtdReceitas);
                            cmd.Transaction = transação;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transação.Commit();
                }
            }
        }

        public void Excluir(List<ItemProduçãoFiscal> itensExcluir)
        {
            List<ItemProduçãoFiscal> novaListaSaída = ExcluirItens(SaídaProduçãoFiscal.Obter(Código), itensExcluir);

            var conexão = Conexão;

            lock (conexão)
            {
                using (var transação = conexão.BeginTransaction())
                {
                    using (var cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "delete from saidaproducaofiscal where producaofiscal = " + DbTransformar(Código);
                        cmd.Transaction = transação;
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "delete from entradaproducaofiscal where producaofiscal = " + DbTransformar(Código);
                        cmd.Transaction = transação;
                        cmd.ExecuteNonQuery();
                    }

                    foreach (ItemProduçãoFiscal novoItem in novaListaSaída)
                    {
                        EsquemaProdução esquema = EsquemaProdução.Obter(novoItem.Referência);
                        var ingredientes = Ingrediente.Obter(esquema.Referência);
                        decimal qtdReceitas = novoItem.Quantidade / esquema.Quantidade;

                        using (var cmd = conexão.CreateCommand())
                        {
                            cmd.CommandText = SaídaProduçãoFiscal.ObterSqlInserçãoSaída(this, qtdReceitas, novoItem.Referência, novoItem.Quantidade);
                            cmd.Transaction = transação;
                            cmd.ExecuteNonQuery();
                        }

                        foreach (var ingrediente in ingredientes)
                        {
                            using (var cmd = conexão.CreateCommand())
                            {
                                cmd.CommandText = EntradaProduçãoFiscal.ObterSqlInserçãoEntrada(this, ingrediente, qtdReceitas);
                                cmd.Transaction = transação;
                                cmd.ExecuteNonQuery();
                            }
                        }

                    }

                    transação.Commit();
                }
            }
        }

        private List<ItemProduçãoFiscal> ExcluirItens(List<ItemProduçãoFiscal> itens, List<ItemProduçãoFiscal> itensExcluir)
        {
            List<ItemProduçãoFiscal> novaLista = new List<Produção.ItemProduçãoFiscal>();

            foreach (ItemProduçãoFiscal i in itens)
            {
                if (!itensExcluir.Contains(i))
                    novaLista.Add(i);
            }

            return novaLista;
        }
    }
}
