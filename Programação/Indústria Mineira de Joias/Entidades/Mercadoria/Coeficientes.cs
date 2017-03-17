using System;
using System.Collections.Specialized;

namespace Entidades.Mercadoria
{
    /// <summary>
    /// Coeficientes de uma mercadoria.
    /// </summary>
    public class Coeficientes
    {
        // Chave: uint. Código da tabela.
        // Valor: double. Coeficiente da mercadoria naquela tabela.
        private ListDictionary hashTabela;

        public Coeficientes()
        {
            hashTabela = new ListDictionary();
        }

        internal void AdicionarCoeficiente(uint tabela, double valor)
        {
            if (hashTabela.Contains(tabela))
            {
                throw new Exception("Tentativa de adicionar um indice ja cadastrado, para tabela: " + tabela.ToString() + " valor já existente: " + hashTabela[tabela].ToString() + " valor a ser colocado: " + valor.ToString());
            }

            hashTabela[tabela] = valor;
        }

        public double this[Tabela tabela]
        {
            get
            {
                if (tabela == null)
                    throw new ArgumentNullException("Tabela não pode ser nula!");

                if (tabela.Código == (uint) Tabela.Tabelas.Consignado || 
                    tabela.Código == (uint) Tabela.Tabelas.Representante || 
                     tabela.Código == (uint) Tabela.Tabelas.ConsignadoX)
                    return (double) hashTabela[(uint) Tabela.Tabelas.Atacado];
                else
                    return (double) hashTabela[tabela.Código];
            }
        }
    }
}
