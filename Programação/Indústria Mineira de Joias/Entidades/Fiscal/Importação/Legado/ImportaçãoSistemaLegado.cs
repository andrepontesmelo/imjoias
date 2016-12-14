using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Fiscal.Importação.Legado
{
    public class ImportaçãoSistemaLegado : DbManipulaçãoSimples
    {
        public ImportaçãoSistemaLegado()
        {
        }

        public void CriarEntradaTransição()
        {
            var fechamento = Fechamento.Obter(DadosGlobais.Instância.HoraDataAtual);

            if (fechamento == null)
                throw new NullReferenceException("Não há fechamento vigente na data atual");

            var hashInventário = ObterHashInventário(fechamento);
            StringBuilder sql = new StringBuilder();
            int qtdSqls = 0;

            var conexão = Conexão;

            lock (conexão)
            {
                var transação = conexão.BeginTransaction();

                ExecutarComandoTransação("INSERT INTO  entradafiscal(id, dataemissao, valortotal, tipo, observacoes, dataentrada)  VALUES('transição_sistema_legado', NOW(),  0, 1, 'Transição', NOW())", transação);

                var legados = EstoqueLegado.Obter();
                int x = 0;
                foreach (EstoqueLegado legado in legados)
                {
                    x++;
                    decimal qtdInventário = 0;
                    Inventário inventário = null;
                    if (hashInventário.TryGetValue(legado.Referência, out inventário))
                        qtdInventário = inventário.Quantidade;

                    var qtdLegado = legado.Estoque;

                    Inserir(legado.Referência, qtdLegado - qtdInventário, sql);
                    qtdSqls++;

                    if (qtdSqls > 100)
                    {
                        qtdSqls = 0;
                        ExecutarComandoTransação(sql.ToString(), transação);
                        sql.Clear();
                        Console.WriteLine(string.Format("{0}% =====================", 100 * x / legados.Count));
                    }
                }

                ExecutarComandoTransação(sql.ToString(), transação);
                Console.WriteLine("Inicio Commit");
                transação.Commit();
                Console.WriteLine("Commit Fim.");
            }
        }

        private void Inserir(string referência, decimal qtd, StringBuilder sql)
        {
            sql.Append(string.Format(" INSERT INTO entradaitemfiscal(referencia, descricao, cfop, tipounidade, quantidade, valorunitario, valor, entradafiscal) " +
                " select {0} as referencia, m.nome, m.cfop, m.tipounidade, {1} as quantidade, 0 as valorunitario, 0 as valor, 'transição_sistema_legado' as entradafiscal from mercadoria m where referencia={0}; ",
                DbTransformar(referência), DbTransformar(qtd)));
        }

        private Dictionary<string, Inventário> ObterHashInventário(Fechamento fechamento)
        {
            Dictionary<string, Inventário> hashInventário = new Dictionary<string, Inventário>();
            foreach (var inventário in Inventário.Obter(fechamento))
                hashInventário.Add(inventário.Referência, inventário);

            return hashInventário;
        }
    }
}
