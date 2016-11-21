using Acesso.Comum;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System;

namespace Entidades.Fiscal.Esquema
{
    [DbTabela("materiaprimaesquemafabricacaofiscal")]
    public class MateriaPrima : DbManipulaçãoSimples
    {
        public MateriaPrima()
        {
        }

        public MateriaPrima(string esquema, string materiaprima, decimal quantidade)
        {
            this.esquema = esquema;
            this.materiaprima = materiaprima;
            this.quantidade = quantidade;
        }

        private string esquema;
        private string materiaprima;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;
        private int cfop;

        private string referenciaAlterada;

        public string Esquema => esquema;
        public string Descrição => descricao;
        public int CFOP => cfop;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);

        public decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public string Referência
        {
            get { return referenciaAlterada == null ? materiaprima : referenciaAlterada; }
            set { referenciaAlterada = value;  }
        }

        public static List<MateriaPrima> Obter(string esquema)
        {
            return Mapear<MateriaPrima>(
                string.Format("select i.*, m.nome as descricao, m.tipounidade, m.cfop from materiaprimaesquemafabricacaofiscal i join mercadoria m on " + 
                " i.materiaprima=m.referencia where esquema={0}", DbTransformar(esquema)));
        }

        public void Atualizar()
        {
            var sql = "UPDATE materiaprimaesquemafabricacaofiscal set " +
                "materiaprima=" + DbTransformar(Referência) + ", " +
                "quantidade=" + DbTransformar(Quantidade) +
                " WHERE materiaprima=" + DbTransformar(materiaprima) +
                " AND esquema=" + DbTransformar(Esquema);

            ExecutarComando(sql);
        }

        public void Cadastrar()
        {
            ExecutarComando(string.Format("INSERT INTO materiaprimaesquemafabricacaofiscal (materiaprima, quantidade, esquema) values ({0},{1},{2})",
                DbTransformar(Referência), DbTransformar(Quantidade), DbTransformar(Esquema)));
        }

        public static void Excluir(List<MateriaPrima> materiasPrimas)
        {
            var sql = "DELETE FROM materiaprimaesquemafabricacaofiscal where ";
            bool primeiro = true;

            foreach (MateriaPrima i in materiasPrimas)
            {
                if (!primeiro)
                    sql += " OR ";

                sql += " (esquema= " + DbTransformar(i.esquema);
                sql += " AND materiaprima=" + DbTransformar(i.materiaprima);
                sql += " ) ";

                primeiro = false;
            }

            ExecutarComando(sql);
        }
    }
}
