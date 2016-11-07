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
                    SaídaProduçãoFiscal.InserirProduçãoSaída(this, qtdReceitas, referência, quantidade, transação);

                    foreach (var ingrediente in ingredientes)
                        EntradaProduçãoFiscal.InserirProduçãoEntrada(this, ingrediente, qtdReceitas, transação);

                    transação.Commit();
                }
            }
        }
    }
}
