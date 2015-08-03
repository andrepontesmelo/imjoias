using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace IMJWeb.Dominio.Util
{
    /// <summary>
    /// Wrapper para injeção de dependência.
    /// </summary>
    public static class InjecaoDependencia
    {
        private static UnityContainer container;
        
        static InjecaoDependencia()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            container = new UnityContainer();

            if (section == null)
                throw new NullReferenceException("Não foi possível encontrar a seção de configuração de injeção de dependência.");

            if (section.Containers.Default == null)
                throw new NullReferenceException("Seção padrão de injeção de dependência não encontrada.");

            section.Containers.Default.Configure(container);
        }

        /// <summary>
        /// Obtém objeto de um tipo específico.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto.</typeparam>
        /// <returns>Instância do objeto.</returns>
        public static T Resolver<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Obtém objeto de um tipo específico.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto.</typeparam>
        /// <param name="nome">Nome do objeto.</param>
        /// <returns>Instância do objeto.</returns>
        public static T Resolver<T>(string nome)
        {
            return container.Resolve<T>(nome);
        }
    }
}
