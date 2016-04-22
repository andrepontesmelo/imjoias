using Acesso.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    public class Entrada : Entidades.Relacionamento.Relacionamento
    {
        protected override Relacionamento.HistóricoRelacionamento ConstruirItens()
        {
            return new HistóricoRelacionamentoEntrada(this);
        }

        public Entrada()
        {
            tabela = Entidades.Tabela.TabelaPadrão;
            digitadopor = Entidades.Pessoa.Funcionário.FuncionárioAtual;
            observações = "";
        }

        public static List<Entrada> Obter()
        {
            return Mapear<Entrada>("select * from entrada where data > (select max(data) from zeragemestoque) ");
        }

        public static Entrada Obter(ulong código)
        {
            return MapearÚnicaLinha<Entrada>("select * from entrada where codigo = " + DbTransformar(código));
        }

    }
}
