using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades.Configuração;

namespace Entidades.Relacionamento.Venda
{
    public class SaquinhoDevolução : SaquinhoRelacionamento
    {
        private Venda venda;
        private double índice;

        public SaquinhoDevolução(Venda v, Mercadoria.Mercadoria m, double qtd, double índice)
            : base(m, qtd, índice)
        {
            venda = v;
            this.índice = índice;
        }

        public double PreçoUnitário
        {
            get { return Mercadoria.CalcularPreço(venda.Cotação); }
        }

        public double PreçoTotal
        {
            get { return PreçoUnitário * Quantidade; }
        }

        public override void PreencherDataRow(DataRow linha)
        {
            base.PreencherDataRow(linha);

            // Foi solicitado pela Lourdes que o peso não seja mostrado para Faixa C, D
            if (!Mercadoria.DePeso)
                linha["peso"] = "";

            linha["valorUnitário"] = string.Format("{0:###,###,###,##0.00}", PreçoUnitário);
            linha["valorTotal"] = string.Format("{0:###,###,###,##0.00}", PreçoTotal);
            linha["devolvido"] = true;
        }
    }
}
