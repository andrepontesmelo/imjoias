using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Entidades.Relacionamento
{
    /// <summary>
    /// Itens agrupados do relacionamento
    /// Serve para impress�o.
    /// </summary>
    public class SaquinhoRelacionamento : Saquinho
    {
        private double �ndice;

        public double �ndice
        {
            get { return �ndice; }
        }

        public SaquinhoRelacionamento(Mercadoria.Mercadoria m, double qtd, double �ndice)
            : base(m, qtd)
        {
            this.�ndice = �ndice;
        }

        public override void PreencherDataRow(DataRow linha)
        {
            linha["refer�ncia"] = Mercadoria.Refer�ncia;
            linha["faixaGrupo"] = Mercadoria.Faixa + " - " + Mercadoria.Grupo.ToString();
            //linha["�ndice"] = Entidades.Mercadoria.Mercadoria.Formatar�ndice(�ndice);
            //linha["quantidade"] = Quantidade.ToString();
            //linha["peso"] = Mercadoria.PesoFormatado;
            linha["�ndice"] = Math.Round(�ndice, 2);
            linha["quantidade"] = Quantidade;
            linha["peso"] = Peso;
            linha["descri��o"] = Mercadoria.Descri��o;
            linha["depeso"] = Mercadoria.DePeso;
        }
    }
}