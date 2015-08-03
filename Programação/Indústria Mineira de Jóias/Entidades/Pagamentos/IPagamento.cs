using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Pagamentos
{
    public interface IPagamento
    {
        long C�digo { get; }
        ulong Cliente { get; }
        double Valor { get; }
        DateTime Data { get; }

        /// <summary>
        /// Data a ser levada em considera��o no financeiro, quando o dinheiro entra.
        /// Pode ser data ou vencimento ou prorroga��o.
        /// </summary>
        DateTime �ltimoVencimento { get; }

        //DateTime? Prorroga��o { get; }
        Entidades.Pessoa.Funcion�rio RegistradoPor { get; }
        bool Pendente { get; }

        bool CobrarJuros { get; }

        /// <summary>
        /// Se o pagamento � compartilhado com mais de uma venda.
        /// </summary>
        bool Compartilhado { get; }
    }
}
