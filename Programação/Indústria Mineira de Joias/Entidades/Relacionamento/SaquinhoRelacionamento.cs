using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Entidades.Relacionamento
{
    /// <summary>
    /// Itens agrupados do relacionamento
    /// Serve para impressão.
    /// </summary>
    public class SaquinhoRelacionamento : Saquinho
    {
        private double índice;

        public double Índice
        {
            get { return índice; }
        }

        public SaquinhoRelacionamento(Mercadoria.Mercadoria m, double qtd, double índice)
            : base(m, qtd)
        {
            this.índice = índice;
        }

        public override void PreencherDataRow(DataRow linha)
        {
            linha["referência"] = Mercadoria.Referência;
            linha["faixaGrupo"] = Mercadoria.Faixa + " - " + Mercadoria.Grupo.ToString();
            //linha["índice"] = Entidades.Mercadoria.Mercadoria.FormatarÍndice(índice);
            //linha["quantidade"] = Quantidade.ToString();
            //linha["peso"] = Mercadoria.PesoFormatado;
            linha["índice"] = Math.Round(índice, 2);
            linha["quantidade"] = Quantidade;
            linha["peso"] = Peso;
            linha["descrição"] = Mercadoria.Descrição;
            linha["depeso"] = Mercadoria.DePeso;
        }
    }
}