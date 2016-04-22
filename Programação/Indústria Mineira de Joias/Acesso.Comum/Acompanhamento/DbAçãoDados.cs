using System;
using System.Reflection;

namespace Acesso.Comum.Acompanhamento
{
    /// <summary>
    /// Descreve a entidade e ação sofrida por ela.
    /// A entidade herda de MarshalByRef, permitindo
    /// que ações sejam notificadas sem que todos os
    /// dados da entidade sejam trafegados quando
    /// o acompanhamento for remoto.
    /// </summary>
    public class DbAçãoDados : MarshalByRefObject
    {
        private DbManipulação entidade;
        private DbAção        ação;

        /// <summary>
        /// Ação ocorrida.
        /// </summary>
        /// <param name="entidade">Entidade que sofreu a ação.</param>
        /// <param name="ação">Ação sofrida.</param>
        public DbAçãoDados(DbManipulação entidade, DbAção ação)
        {
            this.entidade = entidade;
            this.ação = ação;
        }

        /// <summary>
        /// Entidade que sofreu a ação.
        /// </summary>
        /// <remarks>
        /// Se este método está sendo chamado remotamente,
        /// considere a utilização do método "ObterPropriedade"
        /// para reduzir tráfego na rede. <see cref="ObterPropriedade"/>.
        /// </remarks>
        public DbManipulação Entidade
        {
            get { return entidade; }
        }

        /// <summary>
        /// Ação sofrida pela entidade.
        /// </summary>
        public DbAção Ação
        {
            get { return ação; }
        }

        /// <summary>
        /// Obtém remotamente o valor da propriedade do objeto.
        /// Utilize este método para trafegar pela rede somente
        /// o valor da propriedade, em contraposição a toda entidade.
        /// </summary>
        /// <param name="propriedade">Nome da propriedade pública a ser obtida.</param>
        /// <returns>Valor da propriedade da entidade que foreu a ação.</returns>
        public object ObterPropriedade(string propriedade)
        {
            PropertyInfo propInfo;
            
            propInfo = entidade.GetType().GetProperty(propriedade);
            
            return propInfo.GetValue(entidade, null);
        }
    }
}
