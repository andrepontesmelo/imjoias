using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Financeiro.Controle
{
    public class CobrançaItem : IComparable
    {
        private DateTime data;
        private double valor;
        private string descrição;

        public DateTime Data
        { get { return data; } }

        public double Valor
        { get { return valor; } }

        public string Descrição
        { get { return descrição; } }

        public double ValorCorrigido
        {
            get
            {
                return Entidades.Preço.Corrigir(data, DateTime.Now, valor, Entidades.Configuração.DadosGlobais.Instância.Juros);

            }
        }



        public CobrançaItem(DateTime data, double valor, string descrição)
        {
            this.data = data;
            this.valor = valor;
            this.descrição = descrição;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(CobrançaItem))
                return 0;
            else
                return Data.CompareTo(((CobrançaItem)obj).Data);
        }

        #endregion
    }
}
