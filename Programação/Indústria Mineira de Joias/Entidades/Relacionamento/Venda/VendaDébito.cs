using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades.Relacionamento.Venda
{
    [DbTabela("vendadebito")]
    public class VendaDébito : DbManipulaçãoAutomática
    {
        #region Atributos

        // OBS: Select manual de colunas! Se alterar atributos, altere ObterDébitos!

#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbChavePrimária(true), DbColuna("codigo")]
        private ulong código;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbRelacionamento("codigo", "venda")]
        private Venda venda;

        //[DbRelacionamento("codigo", "pagamento")]
        private long? pagamento;

        [DbColuna("descricao")]
        private string descrição;

        private double valorbruto;
        private double valorliquido;

        private DateTime data;

        //[DbColuna("comissao")]
        //private bool comissão;

        [DbColuna("cobrarjuros")]
        private bool cobrarJuros;

        [DbColuna("diasdejuros")]
        private int diasDeJuros;

        // OBS: Select manual de colunas! Se alterar atributos, altere ObterDébitos!

        #endregion

        /// <summary>
        /// Constrói o item vazio, para recuperação do banco
        /// de dados.
        /// </summary>
        public VendaDébito() { }

        /// <summary>
        /// Constrói o item para uma venda.
        /// </summary>
        /// <param name="venda">Venda vinculada.</param>
        public VendaDébito(Venda venda)
        {
            this.venda = venda;
            this.data = DadosGlobais.Instância.HoraDataAtual;
        }

        #region Propriedades

        /// <summary>
        /// Código do item do débito.
        /// </summary>
        public ulong Código { get { return código; } }

        /// <summary>
        /// Venda relacionada.
        /// </summary>
        public Venda Venda { get { return venda; } }

        public string Descrição { get { return descrição; } set { descrição = value; DefinirDesatualizado(); } }

        public double ValorBruto { get { return valorbruto; } set { valorbruto = value; DefinirDesatualizado(); } }

        public double ValorLíquido { get { return valorliquido; } set { throw new Exception("Chame CalcularValorLíquido()"); } }

        public DateTime Data { get { return data; } set { data = value; } }

        public int DiasDeJuros { get { return diasDeJuros; } set { diasDeJuros = value; DefinirDesatualizado(); } }

        public bool CobrarJuros { get { return cobrarJuros; } set { cobrarJuros = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Este débito pode estar pagamento um pagamento.
        /// </summary>
         public long? Pagamento { get { return pagamento; } set { pagamento = value; DefinirDesatualizado(); } }

        #endregion

        #region Manipulação de dados

        /// <summary>
        /// Cadastra o item no banco de dados, desde que
        /// não esteja travado nem acertado.
        /// </summary>
        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            AssegurarManipulação();
            base.Cadastrar(cmd);
        }

        /// <summary>
        /// Atualiza o item no banco de dados, desde que
        /// não esteja travado nem acertado.
        /// </summary>
        protected override void Atualizar(System.Data.IDbCommand cmd)
        {
            if (!Atualizado)
            {
                AssegurarManipulação();
                base.Atualizar(cmd);
            }
        }

        /// <summary>
        /// Descadastra o item no banco de dados, desde que
        /// não esteja travado nem acertado.
        /// </summary>
        protected override void Descadastrar(System.Data.IDbCommand cmd)
        {
            AssegurarManipulação();
            base.Descadastrar(cmd);
        }

        /// <summary>
        /// Assegura que a venda é manipulável, ou seja,
        /// que nem está acertada nem travada.
        /// </summary>
        private void AssegurarManipulação()
        {
            if (venda.Travado)
                throw new NotSupportedException("Não é possível atualizar um item de uma venda travada.");
        }

        #endregion

        #region Recuperação de dados

        /// <summary>
        /// Obtém os débitos de uma venda.
        /// </summary>
        public static List<VendaDébito> ObterDébitos(Venda venda)
        {
           List<VendaDébito> débitos = Mapear<VendaDébito>(
                "SELECT codigo, descricao, valorbruto, valorliquido, data, diasdejuros, cobrarjuros, pagamento FROM vendadebito WHERE venda = " + DbTransformar(venda.Código));

            foreach (VendaDébito débito in débitos)
                débito.venda = venda;

            return débitos;
        }

        #endregion

        /// <summary>
        /// É utilizado o diasDeJuros. Certifique-se de que ele esteja certo antes de chamar.
        /// </summary>
        /// <returns></returns>
        public double CalcularValorLíquido()
        {
            double taxaJuros;
            
            if (venda != null)
                taxaJuros = venda.TaxaJuros;
            else
                taxaJuros = Entidades.Configuração.DadosGlobais.Instância.Juros;

            valorliquido =
                (CobrarJuros ?
                    Entidades.Preço.AcrescentarJurosSimples(ValorBruto, taxaJuros, diasDeJuros)
                    : ValorBruto);

            DefinirDesatualizado();

            return valorliquido;
        }

        public static void TransferirPagamentosParaDébitosEmTransação(List<KeyValuePair<Pagamentos.Pagamento, VendaDébito>> lstPagamentoDébitos)
        {
            if (lstPagamentoDébitos.Count == 0)
                return;

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                using (IDbTransaction transação = conexão.BeginTransaction())
                {
                    try
                    {
                        foreach (KeyValuePair<Pagamentos.Pagamento, VendaDébito> parPagamentoDébito in lstPagamentoDébitos)
                        {
                            Pagamentos.Pagamento pagamento = parPagamentoDébito.Key;
                            VendaDébito vendaDébito = parPagamentoDébito.Value;

                            InsereTransacionado(conexão, transação, pagamento);
                            InsereTransacionado(conexão, transação, pagamento, vendaDébito);
                        }

                        transação.Commit();

                    }
                    catch (Exception)
                    {
                        if (transação != null)
                            transação.Rollback();
                    }
                }
            }
        }

        private static void InsereTransacionado(IDbConnection conexão, IDbTransaction transação, Pagamentos.Pagamento pagamento)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                cmd.CommandText = " update pagamento set pendente = 0 where codigo = " +
                    DbTransformar(pagamento.Código);

                cmd.ExecuteNonQuery();
            }
        }

        private static void InsereTransacionado(IDbConnection conexão, IDbTransaction transação, Pagamentos.Pagamento pagamento, VendaDébito vendaDébito)
        {
            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.Transaction = transação;

                StringBuilder comandoStr = new StringBuilder();

                comandoStr.Append(" INSERT INTO vendadebito(venda, descricao, valorliquido, valorbruto, data, diasdejuros, cobrarjuros, pagamento) VALUES (");
                comandoStr.Append(DbTransformar(vendaDébito.Venda.Código));
                comandoStr.Append(", ");
                comandoStr.Append(DbTransformar(vendaDébito.Descrição, true));
                comandoStr.Append(", ");
                comandoStr.Append(DbTransformar(vendaDébito.ValorLíquido));
                comandoStr.Append(", ");
                comandoStr.Append(DbTransformar(vendaDébito.ValorBruto));
                comandoStr.Append(", ");
                comandoStr.Append(DbTransformar(vendaDébito.Data));
                comandoStr.Append(", ");
                comandoStr.Append(DbTransformar(vendaDébito.DiasDeJuros));
                comandoStr.Append(", ");
                comandoStr.Append(DbTransformar(vendaDébito.CobrarJuros));
                comandoStr.Append(", ");
                comandoStr.Append(DbTransformar(pagamento.Código));
                comandoStr.Append(" ) ");

                cmd.CommandText = comandoStr.ToString();

                if (pagamento.Código != vendaDébito.Pagamento.Value)
                    throw new InvalidProgramException();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
