using System;

namespace Entidades.Relacionamento.Venda
{
    public interface IDadosVenda
    {
        string NomeCliente { get; }
        string NomeVendedor { get; }
        double Valor { get; }
        long Código { get; }
        uint? Controle { get; }
        DateTime Data { get; }
        double Cotação { get; }
        uint DiasSemJuros { get; }
        double TaxaJuros { get; }
        SemaforoEnum Semáforo { get; }
        string CódigoFormatado { get; }
    }
}
