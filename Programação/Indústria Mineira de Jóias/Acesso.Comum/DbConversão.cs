using System;

namespace Acesso.Comum
{
    /// <summary>
    /// Define propriedade para conversão do tipo durante leitura
    /// e escrita do banco de dados.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)]
    public class DbConversão : Attribute
    {
        private DbConversor conversor;

        /// <summary>
        /// Define uma propriedade para conversão tipo durante leitura
        /// e escrita do banco de dados.
        /// </summary>
        /// <param name="propriedade">
        /// Nome da propriedade que converte o tipo. O tipo deve implementar
        /// a classe abstrata <c>DbConversor</c>.</param>
        public DbConversão(Type tipo)
        {
            conversor = tipo.GetConstructor(Type.EmptyTypes).Invoke(null) as DbConversor;

            if (conversor == null)
                throw new InvalidCastException("O parâmetro de DbConversão deve implementar a classe a abstrata DbConversor.");
        }

        public DbConversor Conversor { get { return conversor; } }
    }
}
