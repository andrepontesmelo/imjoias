using System;
using System.Collections.Generic;
using System.Text;

namespace Acesso.Comum
{
    /// <summary>
    /// Composição de entidades cujos elemenos podem ser cadastrados
    /// ou descadastrados, porém não atualizados, normalmente devido
    /// a restrições de chave primária.
    /// </summary>
    /// <typeparam name="Entidade">Tipo da entidade a ser relacionada.</typeparam>
    public class DbComposiçãoInalterável<Entidade> : DbComposição<Entidade>
    {
        /// <summary>
        /// Constrói uma composição, considerando somente
        /// objetos DbManipulação. Para cadastro e descadastro
        /// serão chamados os métodos correspondentes de cada item relacionado.
        /// </summary>
        public DbComposiçãoInalterável()
            : base()
        { }

        /// <summary>
        /// Constrói uma composição, considerando somente
        /// objetos DbManipulação, fornecendo uma lista de objetos relacioandos
        /// já cadastrados. Para cadastro e descadastro
        /// serão chamados os métodos correspondentes de cada item relacionado.
        /// </summary>
        /// <param name="itens">Itens relacionados já cadastrados.</param>
        public DbComposiçãoInalterável(IEnumerable<Entidade> itens)
            : base(itens)
        { }

        /// <summary>
        /// Constrói uma composição. Para cadastro e descadastro,
        /// serão utilizados métodos próprios, fornecidos pelo
        /// usuário.
        /// </summary>
        /// <param name="cadastrar">Método para cadastrar individualmente um item no banco de dados.</param>
        /// <param name="atualizar">Método para atualizar individualmente um item no banco de dados.</param>
        /// <param name="descadastrar">Método para descadastrar individualmente um item no banco de dados.</param>
        public DbComposiçãoInalterável(DbAção<Entidade> cadastrar, DbAção<Entidade> descadastrar)
            : base(cadastrar, null, descadastrar)
        { }

        /// <summary>
        /// Constrói uma composição, informando os itens já existentes
        /// no banco de dados.  Para cadastro e descadastro, serão
        /// utilizados métodos próprios, fornecidos pelo usuário.
        /// </summary>
        /// <param name="itens">Itens já existentes.</param>
        public DbComposiçãoInalterável(IEnumerable<Entidade> itens, DbAção<Entidade> cadastrar, DbAção<Entidade> descadastrar)
            : base(itens, cadastrar, null, descadastrar)
        { }

        /// <summary>
        /// Verifica se requer manipulação da entidade.
        /// </summary>
        protected override bool RequerManipulação()
        {
            return cadastrar == null || descadastrar == null;
        }

        /// <summary>
        /// Atualiza a composição no banco de dados.
        /// </summary>
        protected internal override void Atualizar(System.Data.IDbCommand cmd)
        {
            RemoverItens(cmd);
            CadastrarItens(cmd);
        }
    }
}
