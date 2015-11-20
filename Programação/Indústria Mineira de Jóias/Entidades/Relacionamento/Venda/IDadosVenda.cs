using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Relacionamento.Venda
{
    /// <summary>
    /// Provê informações sobre uma venda.
    /// </summary>
    public interface IDadosVenda
    {
        /// <summary>
        /// Nome do cliente.
        /// </summary>
        string NomeCliente
        {
            get;
        }

        /// <summary>
        /// Nome do vendedor.
        /// </summary>
        string NomeVendedor
        {
            get;
        }

        /// <summary>
        /// Valor total da venda.
        /// </summary>
        double Valor
        {
            get;
        }

        /// <summary>
        /// Código da venda.
        /// </summary>
        long Código
        {
            get;
        }

        /// <summary>
        /// Número de controle.
        /// </summary>
        uint? Controle
        {
            get;
        }

        /// <summary>
        /// Data da venda.
        /// </summary>
        DateTime Data
        {
            get;
        }



        //double Comissão
        //{
        //    get;
        //}

        double Cotação
        {
            get;
        }

        //bool Acertado
        //{
        //    get;
        //}

        uint DiasSemJuros
        {
            get;
        }

        double TaxaJuros
        {
            get;
        }

        SemaforoEnum Semáforo { get; }

        string CódigoFormatado { get; }
    }
}
