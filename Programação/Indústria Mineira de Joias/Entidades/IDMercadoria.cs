using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Informações básicas sobre uma mercadoria.
    /// </summary>
    public struct IDMercadoria
    {
        private string referência;
        private double peso;

        public IDMercadoria(string referência, double peso)
        {
            this.referência = referência;
            this.peso = peso;
        }

        public string ReferênciaNumérica
        {
            get { return referência; }
            set { referência = value; }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public static implicit operator Mercadoria.Mercadoria(IDMercadoria mercadoria)
        {
            return Mercadoria.Mercadoria.ObterMercadoria(mercadoria.referência, mercadoria.peso, Tabela.TabelaPadrão);
        }
    }
}
