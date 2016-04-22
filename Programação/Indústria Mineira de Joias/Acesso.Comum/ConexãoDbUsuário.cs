using System;
using System.Data;
using Acesso.Comum.Mapeamento;
using System.Collections.Generic;
using Acesso.Comum.Adaptadores;

namespace Acesso.Comum
{
    /// <summary>
    /// Conexão do usuário com o banco de dados.
    /// </summary>
    [Serializable]
    class ConexãoDbUsuário : IDisposable
    {
        private ConexãoConcorrente conexão;
        private DateTime últimoUso;

        /// <summary>
        /// Hash mapeando informações gerais para informações específicas
        /// da conexão.
        /// </summary>
        private Dictionary<InfoManipulação, InfoManipulaçãoConexão> hashManipulação = new Dictionary<InfoManipulação, InfoManipulaçãoConexão>();

        /// <summary>
        /// Constrói a conexão do usuário com o banco de dados.
        /// </summary>
        /// <param name="conexão">Conexão do usuário.</param>
        public ConexãoDbUsuário(IDbConnection conexão)
        {
            if (!(conexão is ConexãoConcorrente))
                this.conexão = new ConexãoConcorrente(conexão);
            else
                this.conexão = (ConexãoConcorrente) conexão;

            últimoUso = DateTime.Now;
        }

        /// <summary>
        /// Conexão com o banco de dados.
        /// </summary>
        public ConexãoConcorrente Conexão
        {
            get
            {
                últimoUso = DateTime.Now;
                return conexão;
            }
        }

        /// <summary>
        /// Último momento em que a conexão foi utilizada.
        /// </summary>
        public DateTime ÚltimoUso
        {
            get { return últimoUso; }
        }

        /// <summary>
        /// Verifica igualdade entre objetos.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is IDbConnection)
                return conexão.Equals(obj);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return conexão.GetHashCode();
        }

        public void Dispose()
        {
            foreach (InfoManipulaçãoConexão info in hashManipulação.Values)
                info.Dispose();
        }

        /// <summary>
        /// Obtém informações para manipulação automática.
        /// </summary>
        /// <param name="dbEntidade">Entidade a ser manipulada.</param>
        public InfoManipulaçãoConexão ObterInfoManipulação(InfoManipulação infoGeral)
        {
            InfoManipulaçãoConexão info;
            
            if (!hashManipulação.TryGetValue(infoGeral, out info))
            {
                info = new InfoManipulaçãoConexão(infoGeral, conexão);
                hashManipulação[infoGeral] = info;
            }

            return info;
        }
    }
}
