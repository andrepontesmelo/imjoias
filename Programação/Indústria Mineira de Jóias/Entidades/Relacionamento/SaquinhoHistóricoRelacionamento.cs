using System;
using Entidades;
using Entidades.Relacionamento;

namespace Entidades.Relacionamento
{
    /// <summary>
    /// Adaptador para ItemRelacionado para que seja manipulado pela bandeja
    /// </summary>
    public class SaquinhoHistóricoRelacionado : ISaquinho
    {
        private HistóricoRelacionamentoItem item;

        public Entidades.Pessoa.Funcionário Funcionário
        {
            get { return item.Funcionário; }
        }

        public DateTime Data
        {
            get { return item.Data; }
        }

        public Entidades.Mercadoria.Mercadoria Mercadoria
        {
            get { return item.Mercadoria; }
        }

        public SaquinhoHistóricoRelacionado(HistóricoRelacionamentoItem item)
        {
            this.item = item;
        }

        public double Quantidade
        {
            get { return Math.Abs(item.Quantidade); }
        }

        public double Peso
        {
            get { return item.Mercadoria.Peso; }
        }

        public string IdentificaçãoAgrupável()
        {
            // Nenhum item é agrupável.
            return item.Código.ToString();
        }

        public enum TipoEnum { Adicionou, Removeu }
        public TipoEnum Tipo
        {
            get { return item.Quantidade > 0 ? TipoEnum.Adicionou : TipoEnum.Removeu; }
        }

        public ISaquinho Clone(double novaQuantidade)
        {
            throw new NotImplementedException();
        }

    }
}
