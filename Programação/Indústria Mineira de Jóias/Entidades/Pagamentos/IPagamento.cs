using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Pagamentos
{
    public interface IPagamento
    {
        long Código { get; }
        ulong Cliente { get; }
        double Valor { get; }
        DateTime Data { get; }

        /// <summary>
        /// Data a ser levada em consideração no financeiro, quando o dinheiro entra.
        /// Pode ser data ou vencimento ou prorrogação.
        /// </summary>
        DateTime ÚltimoVencimento { get; }

        //DateTime? Prorrogação { get; }
        Entidades.Pessoa.Funcionário RegistradoPor { get; }
        bool Pendente { get; }

        bool CobrarJuros { get; }

        /// <summary>
        /// Se o pagamento é compartilhado com mais de uma venda.
        /// </summary>
        bool Compartilhado { get; }
    }
}
