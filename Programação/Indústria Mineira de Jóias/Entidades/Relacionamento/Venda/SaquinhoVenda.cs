using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades.Configura��o;

namespace Entidades.Relacionamento.Venda
{
    public class SaquinhoVenda : SaquinhoRelacionamento
    {
        private Venda venda;

        public SaquinhoVenda(Venda v, Mercadoria.Mercadoria m, double qtd, double �ndice)
            : base(m, qtd, �ndice)
        {
            venda = v;
        }

        public double Pre�oUnit�rio
        {
            get { return Mercadoria.CalcularPre�o(venda.Cota��o); }
        }

        public double Pre�oTotal
        {
            get { return Pre�oUnit�rio * Quantidade; }
        }

        public override void PreencherDataRow(DataRow linha)
        {
            base.PreencherDataRow(linha);


            // Foi solicitado pela Lourdes que o peso n�o seja mostrado para Faixa C, D
            if (!Mercadoria.DePeso)
                linha["peso"] = "";

            //linha["valorUnit�rio"] = Pre�oUnit�rio.ToString("C", DadosGlobais.Inst�ncia.Cultura);
            //linha["valorTotal"] = Pre�oTotal.ToString("C", DadosGlobais.Inst�ncia.Cultura);

            linha["valorUnit�rio"] = string.Format("{0:###,###,###,##0.00}", Pre�oUnit�rio);
            linha["valorTotal"] = string.Format("{0:###,###,###,##0.00}", Pre�oTotal);
            linha["devolvido"] = false;
        }
    }
}
