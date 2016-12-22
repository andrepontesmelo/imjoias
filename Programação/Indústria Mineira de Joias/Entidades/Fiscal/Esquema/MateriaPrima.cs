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

        public MateriaPrima(int fechamento, string esquema, string materiaprima, decimal quantidade, bool proporcional)
        {
            this.fechamento = fechamento;
            this.esquema = esquema;
            this.materiaprima = materiaprima;
            this.quantidade = quantidade;
            this.proporcional = proporcional;
        }

        private int fechamento;
        private string esquema;
        private string materiaprima;
        private decimal quantidade;
        private string descricao;
        private int tipounidade;
        private int cfop;
        private bool proporcional;

        private string referenciaAlterada;
        public int Fechamento => fechamento;
        public string Esquema => esquema;
        public string Descrição => descricao;
        public int CFOP => cfop;
        public TipoUnidade TipoUnidadeComercial => TipoUnidade.Obter(tipounidade);
        public bool Proporcional
        {
            get { return proporcional; }
            set { proporcional = value; }
        }

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

        public static List<MateriaPrima> Obter(string esquema, int fechamento)
        {
            return Mapear<MateriaPrima>(
                string.Format("select i.*, m.nome as descricao, m.tipounidade, m.cfop from materiaprimaesquemafabricacaofiscal i join mercadoria m on " + 
                " i.materiaprima=m.referencia where esquema={0} and fechamento={1}", 
                esquema == null ? "esquema" : DbTransformar(esquema), 
                DbTransformar(fechamento)));
        }

        public static Dictionary<string, List<MateriaPrima>> ObterHash(int fechamento)
        {
            Dictionary<string, List<MateriaPrima>> hash = new Dictionary<string, List<Fiscal.Esquema.MateriaPrima>>();

            List<MateriaPrima> todas = Obter(null, fechamento);

            foreach (MateriaPrima m in todas)
            {
                List<MateriaPrima> lista;
                if (!hash.TryGetValue(m.Esquema, out lista))
                {
                    lista = new List<MateriaPrima>();
                    hash[m.Esquema] = lista;
                }

                lista.Add(m);
            }

            return hash;
        }


        public void Atualizar()
        {
            var sql = "UPDATE materiaprimaesquemafabricacaofiscal set " +
                "materiaprima=" + DbTransformar(Referência) + ", " +
                "quantidade=" + DbTransformar(Quantidade) + ", " +
                "proporcional=" + DbTransformar(Proporcional) +
                " WHERE materiaprima=" + DbTransformar(materiaprima) +
                " AND esquema=" + DbTransformar(Esquema) +
                " AND fechamento=" + DbTransformar(Fechamento);

            ExecutarComando(sql);
        }

        public void Cadastrar()
        {
            ExecutarComando(string.Format("INSERT INTO materiaprimaesquemafabricacaofiscal (materiaprima, quantidade, " + 
                " esquema, fechamento, proporcional) values ({0},{1},{2},{3}, {4})",
                DbTransformar(Referência), DbTransformar(Quantidade), DbTransformar(Esquema), DbTransformar(Fechamento), 
                DbTransformar(Proporcional)));
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
                sql += " AND fechamento=" + DbTransformar(i.fechamento);
                sql += " ) ";

                primeiro = false;
            }

            ExecutarComando(sql);
        }
    }
}
