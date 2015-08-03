using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Pessoa;
using Entidades.Configuração;
using System.Data;

namespace Entidades.Relacionamento.Venda
{
    [DbTabela("vendacredito")]
    public class VendaCrédito : DbManipulaçãoAutomática
    {
        #region Atributos

        // OBS: Select manual de colunas! Se alterar atributos, altere ObterCréditos!

#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbChavePrimária(true), DbColuna("codigo")]
        private ulong código;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbRelacionamento("codigo", "venda")]
        private Venda venda;

        [DbColuna("descricao")]
        private string descrição;

        private double valorbruto;
        private double valorliquido;

        private DateTime data;

        //[DbColuna("comissao")]
        //private bool comissão;

        [DbColuna("cobrarjuros")]
        private bool cobrarJuros;

        private long? credito;

        [DbColuna("diasdejuros")]
        private int diasDeJuros;

        // OBS: Select manual de colunas! Se alterar atributos, altere ObterCréditos!

        #endregion

        /// <summary>
        /// Constrói o item vazio, para recuperação do banco
        /// de dados.
        /// </summary>
        public VendaCrédito() { }

        /// <summary>
        /// Constrói o item para uma venda.
        /// </summary>
        /// <param name="venda">Venda vinculada.</param>
        public VendaCrédito(Venda venda)
        {
            this.venda = venda;
            this.data = DadosGlobais.Instância.HoraDataAtual;
        }

        #region Propriedades

        /// <summary>
        /// Código do item do Crédito.
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
        /// Este crédito pode estar gastando um crédito.
        /// </summary>
        public long? Credito { get { return credito; } set { credito = value; DefinirDesatualizado(); } }


        ///// <summary>
        ///// Determina se deve pagar comissão pelo Crédito.
        ///// </summary>
        //public bool Comissão { get { return comissão; } set { comissão = value; AtualizarComissão(); } }

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
            /* O setor financeiro faz alterações em vendas acertadas.
             * Não há problemas nisso. André, 15/12/07
             *
            if (venda.Acertado)
                throw new NotSupportedException("Não é possível atualizar um item de uma venda acertada.");
            */

            if (venda.Travado)
                throw new NotSupportedException("Não é possível atualizar um item de uma venda travada.");
        }

        ///// <summary>
        ///// Atualiza a comissão no banco de dados.
        ///// </summary>
        //private void AtualizarComissão()
        //{
        //    IDbConnection conexão = Conexão;

        //    lock (conexão)
        //        using (IDbCommand cmd = conexão.CreateCommand())
        //        {
        //            cmd.CommandText = "UPDATE vendacredito SET comissao = " + DbTransformar(comissão)
        //                + " WHERE codigo = " + DbTransformar(código);
        //            cmd.ExecuteNonQuery();
        //        }
        //}

        #endregion

        #region Recuperação de dados

        /// <summary>
        /// Obtém os Créditos de uma venda.
        /// </summary>
        public static VendaCrédito[] ObterCréditos(Venda venda)
        {
            VendaCrédito[] Créditos = Mapear<VendaCrédito>(
                 "SELECT codigo, descricao, valorbruto, valorliquido, data, diasdejuros, cobrarjuros, credito FROM vendacredito WHERE venda = " + DbTransformar(venda.Código)).ToArray();

            foreach (VendaCrédito Crédito in Créditos)
                Crédito.venda = venda;

            return Créditos;
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
    }
}
