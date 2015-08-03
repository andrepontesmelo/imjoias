namespace Entidades.Pessoa
{
    /// <summary>
    /// Estados possíveis do funcionário. Estes valores são armazenados
    /// no banco de dados.
    /// </summary>
    public enum EstadoFuncionário : uint
    {
        Desconhecido = 0,
        Disponível = 1,
        Atendendo = 2,
        Ocupado = 3,
        Ausente = 4
    }
}
