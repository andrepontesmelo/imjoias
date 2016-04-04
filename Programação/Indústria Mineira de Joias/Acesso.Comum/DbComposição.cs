using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Acesso.Comum
{
    /// <summary>
    /// Permite a criação de um relacionamento de 1 para N, típico de composição.
    /// </summary>
    /// <remarks>
    /// Composição de entidades do tipo DbManipulação podem
    /// ser criados sem a implementação específica de comandos
    /// para manipulação da entidade. No entanto, CUIDADO, pois
    /// o relacionamento é implementado sempre pelo usuário. Assim,
    /// se um tipo DbManipulação for inserido na lista de relacionamento
    /// e nenhum método de manipulação tiver sido fornecido na construtora
    /// deste relacionamento, será chamado o método da entidade inserida.
    /// Isso somente é útil se a entidade DbManipulação for exclusiva
    /// de relacionamento, ou seja, do tipo composição.
    /// </remarks>
    /// <typeparam name="Entidade">Tipo da entidade a ser relacionada.</typeparam>
    [DbTransação, DbRelacionamentoInvertido]
    public class DbComposição<Entidade> : DbManipulação, IEnumerable<Entidade>
    {
        /// <summary>
        /// Lista de entidades a cadastrar no banco de dados.
        /// </summary>
        private List<Entidade> listaAdicionar;

        /// <summary>
        /// Lista de entidades a remover do banco de dados.
        /// </summary>
        private List<Entidade> listaRemover;

        /// <summary>
        /// Lista de entidades cadastradas e mantidas no banco de dados.
        /// </summary>
        private List<Entidade> listaItens;

        /// <summary>
        /// Método para cadastrar individualmente um item do banco de dados.
        /// </summary>
        protected DbAção<Entidade> cadastrar;

        /// <summary>
        /// Método para atualizar individualmente um item do banco de dados.
        /// </summary>
        protected DbAção<Entidade> atualizar;

        /// <summary>
        /// Método para descadastrar individualmente um item do banco de dados.
        /// </summary>
        protected DbAção<Entidade> descadastrar;


        public delegate void EventoComposição(DbComposição<Entidade> composição, Entidade entidade);

        /// <summary>
        /// Ocorre ao adicionar um novo item à composição.
        /// </summary>
        public event EventoComposição AoAdicionar;

        /// <summary>
        /// Ocorre ao remover um item da composição.
        /// </summary>
        public event EventoComposição AoRemover;

        /// <summary>
        /// Constrói uma composição, considerando somente
        /// objetos DbManipulação. Para cadastro, atualização e descadastro
        /// serão chamados os métodos correspondentes de cada item relacionado.
        /// </summary>
        public DbComposição()
        {
            ValidarEntidade();

            listaAdicionar = new List<Entidade>();
            listaRemover = new List<Entidade>();
            listaItens = new List<Entidade>();
        }

        /// <summary>
        /// Constrói uma composição, considerando somente
        /// objetos DbManipulação, fornecendo uma lista de objetos relacioandos
        /// já cadastrados. Para cadastro, atualização e descadastro
        /// serão chamados os métodos correspondentes de cada item relacionado.
        /// </summary>
        /// <param name="itens">Itens relacionados já cadastrados.</param>
        public DbComposição(IEnumerable<Entidade> itens)
        {
            ValidarEntidade();

            foreach (Entidade item in itens)
                if (item is DbManipulação)
                {
                    DbManipulação dbEntidade = item as DbManipulação;

                    if (dbEntidade == null)
                        throw new Exceções.ExceçãoEntidade(this, "Não foi possível realizar conversão do item relacionado para DbManipulação.");

                    if (!dbEntidade.Cadastrado)
                        throw new Exceções.ExceçãoEntidade(this, "Entidades não cadastradas devem ser adicionadas após a construção do objeto de composição.");
                }

            listaAdicionar = new List<Entidade>();
            listaRemover = new List<Entidade>();
            listaItens = new List<Entidade>(itens);
        }



        /// <summary>
        /// Verifica se o tipo da Entidade é manipulável.
        /// </summary>
        private static void ValidarEntidade()
        {
            if (!typeof(Entidade).IsSubclassOf(typeof(DbManipulação)))
                throw new NotSupportedException("Não foram fornecidos métodos para manipulação da entidade de banco de dados e o tipo " + 
                    typeof(Entidade).Name + " não herda de DbManipulação.");
        }

        /// <summary>
        /// Verifica se requer manipulação pela entidade.
        /// </summary>
        protected virtual bool RequerManipulação()
        {
            return cadastrar == null || atualizar == null || descadastrar == null;
        }

        /// <summary>
        /// Constrói uma composição. Para cadastro, atualização
        /// e descadastro, serão utilizados métodos próprios, fornecidos pelo
        /// usuário.
        /// </summary>
        /// <param name="cadastrar">Método para cadastrar individualmente um item no banco de dados.</param>
        /// <param name="atualizar">Método para atualizar individualmente um item no banco de dados.</param>
        /// <param name="descadastrar">Método para descadastrar individualmente um item no banco de dados.</param>
        public DbComposição(DbAção<Entidade> cadastrar, DbAção<Entidade> atualizar, DbAção<Entidade> descadastrar)
        {
            this.cadastrar = cadastrar;
            this.atualizar = atualizar;
            this.descadastrar = descadastrar;

            if (RequerManipulação())
                ValidarEntidade();

            listaAdicionar = new List<Entidade>();
            listaRemover = new List<Entidade>();
            listaItens = new List<Entidade>();
        }

        /// <summary>
        /// Constrói uma composição, informando os itens já existentes
        /// no banco de dados.  Para cadastro, atualização
        /// e descadastro, serão utilizados métodos próprios, fornecidos pelo
        /// usuário.
        /// </summary>
        /// <param name="itens">Itens já existentes.</param>
        public DbComposição(IEnumerable<Entidade> itens, DbAção<Entidade> cadastrar, DbAção<Entidade> atualizar, DbAção<Entidade> descadastrar)
        {
            this.cadastrar = cadastrar;
            this.atualizar = atualizar;
            this.descadastrar = descadastrar;

            if (cadastrar == null || atualizar == null || descadastrar == null)
                ValidarEntidade();

            listaAdicionar = new List<Entidade>();
            listaRemover = new List<Entidade>();
            listaItens = new List<Entidade>(itens);
        }

        /// <summary>
        /// Dispara evento AoAdicionar.
        /// </summary>
        /// <param name="item">Item adicionado.</param>
        private void DispararAoAdicionar(Entidade item)
        {
            if (AoAdicionar != null)
                AoAdicionar(this, item);
        }

        /// <summary>
        /// Dispara evento AoRemover.
        /// </summary>
        /// <param name="item">Item removido.</param>
        private void DispararAoRemover(Entidade item)
        {
            if (AoRemover != null)
                AoRemover(this, item);
        }

        /// <summary>
        /// Adiciona um novo item.
        /// </summary>
        /// <param name="item">Item a ser adicionado.</param>
        public void Adicionar(Entidade item)
        {
            if (item == null)
                throw new ArgumentNullException();

            lock (this)
            {
                if (listaItens.Contains(item) || listaAdicionar.Contains(item))
                    throw new Exceções.EntidadeJáExistente();

                /* Se o item já estiver cadastrado, somente removê-lo
                 * da lista de remoção...
                 */
                if (listaRemover.Contains(item))
                {
                    listaRemover.Remove(item);
                    listaItens.Add(item);
                }
                // senão, marca como a ser cadastrado...
                else
                {
                    /* Adicionar um item cadastrado implica em erro,
                     * exceto se este constar na lista de itens removidos,
                     * que seria o caso do usuário requisitar a exclusão e,
                     * em seguida, a reinclusão do item. No entanto, a
                     * inclusão de um item já cadastrado indica erro de lógica.
                     */
                    if (cadastrar == null)
                    {
                        DbManipulação dbEntidade = item as DbManipulação;

                        if (dbEntidade == null)
                            throw new Exceções.ExceçãoEntidade(this, "Não foi possível realizar conversão do item relacionado para DbManipulação.");

                        if (dbEntidade.Cadastrado)
                            throw new Exceções.EntidadeJáExistente(this, "Não se pode adicionar uma entidade já cadastrada a um composição novo.");
                    }

                    listaAdicionar.Add(item);
                }
            }

            DefinirDesatualizado();
            DispararAoAdicionar(item);
        }

        /// <summary>
        /// Adiciona um novo item.
        /// </summary>
        /// <param name="itens">Itens a serem adicionados.</param>
        public void AdicionarJáCadastrado(params Entidade[] itens)
        {
#if DEBUG
            foreach (Entidade obj in itens)
                if (obj == null)
                    throw new ArgumentNullException();
#endif
            lock (this)
            {
                listaItens.AddRange(itens);
            }
        }

        /// <summary>
        /// Remove um item.
        /// </summary>
        /// <param name="item">Item a ser removido.</param>
        public void Remover(Entidade item)
        {
            if (item == null)
                throw new ArgumentNullException();

            lock (this)
            {
                // Se o item já está cadastrado, marca como a ser removido...
                if (listaItens.Contains(item))
                {
                    listaItens.Remove(item);
                    listaRemover.Add(item);
                }
                // senão apenas remove da lista de cadastro.
                else if (listaAdicionar.Contains(item))
                    listaAdicionar.Remove(item);
                else
                    throw new Exceções.EntidadeNãoEncontrada();
            }

            DefinirDesatualizado();
            DispararAoRemover(item);
        }

        /// <summary>
        /// Cadastra a composição no banco de dados.
        /// </summary>
        protected internal override void Cadastrar(System.Data.IDbCommand cmd)
        {
            Atualizar(cmd);
        }

        /// <summary>
        /// Atualiza a composição no banco de dados.
        /// </summary>
        protected internal override void Atualizar(System.Data.IDbCommand cmd)
        {
            RemoverItens(cmd);
            AtualizarItens(cmd);
            CadastrarItens(cmd);
        }

        /// <summary>
        /// Descadastra a composição no banco de dados.
        /// </summary>
        protected internal override void Descadastrar(System.Data.IDbCommand cmd)
        {
            RemoverItens(cmd);

            /* Remover itens cadastrados no banco de dados,
             * mas não marcados para remoção.
             */
            if (descadastrar == null)
                foreach (Entidade entidade in listaItens)
                {
                    DbManipulação dbEntidade = entidade as DbManipulação;

                    if (dbEntidade == null)
                        throw new Exceções.ExceçãoEntidade(this, "Não foi possível realizar conversão do item relacionado para DbManipulação.");

                    DescadastrarEntidade(cmd, dbEntidade);
                }
            else
                foreach (Entidade entidade in listaItens)
                    descadastrar(cmd, entidade);
        }

        /// <summary>
        /// Remove itens marcados para remoção do banco de dados.
        /// </summary>
        protected void RemoverItens(IDbCommand cmd)
        {
            lock (this)
            {
                if (descadastrar == null)
                    foreach (Entidade entidade in listaRemover)
                    {
                        DbManipulação dbEntidade = entidade as DbManipulação;

                        if (dbEntidade == null)
                            throw new Exceções.ExceçãoEntidade(this, "Não foi possível realizar conversão do item relacionado para DbManipulação.");

                        dbEntidade.Descadastrar(cmd);
                    }
                else
                    foreach (Entidade entidade in listaRemover)
                        descadastrar(cmd, entidade);

                listaRemover.Clear();
            }
        }

        /// <summary>
        /// Atualiza itens já cadastrados no banco de dados.
        /// </summary>
        protected void AtualizarItens(IDbCommand cmd)
        {
            lock (this)
            {
                if (atualizar == null)
                    foreach (Entidade entidade in listaItens)
                    {
                        DbManipulação dbEntidade = entidade as DbManipulação;

                        if (dbEntidade == null)
                            throw new Exceções.ExceçãoEntidade(this, "Não foi possível realizar conversão do item relacionado para DbManipulação.");

                        AtualizarEntidade(cmd, dbEntidade);
                    }
                else
                    foreach (Entidade entidade in listaItens)
                        atualizar(cmd, entidade);
            }
        }

        /// <summary>
        /// Cadastra itens ainda não cadastrados no banco de dados.
        /// </summary>
        /// <param name="cmd"></param>
        protected void CadastrarItens(IDbCommand cmd)
        {
            lock (this)
            {
                if (cadastrar == null)
                    foreach (Entidade entidade in listaAdicionar)
                    {
                        DbManipulação dbEntidade = entidade as DbManipulação;

                        if (dbEntidade == null)
                            throw new Exceções.ExceçãoEntidade(this, "Não foi possível realizar conversão do item relacionado para DbManipulação.");

                        CadastrarEntidade(cmd, dbEntidade);
                    }
                else
                    foreach (Entidade entidade in listaAdicionar)
                        cadastrar(cmd, entidade);

                listaItens.AddRange(listaAdicionar);
                listaAdicionar.Clear();
            }
        }

        /// <summary>
        /// Obtém enumerador de itens cadastrados e a serem cadastrados.
        /// </summary>
        public IEnumerator<Entidade> GetEnumerator()
        {
            List<Entidade> itens = ExtrairElementos();

            return itens.GetEnumerator();
        }

        /// <summary>
        /// Extrai uma lista contendo os elementos.
        /// </summary>
        /// <returns>Lista contendo elementos.</returns>
        /// <remarks>
        /// Alterações nesta lista não afetam os relacionamentos.
        /// </remarks>
        public List<Entidade> ExtrairElementos()
        {
            List<Entidade> itens;

            itens = new List<Entidade>(listaItens.Count + listaAdicionar.Count);

            itens.AddRange(listaItens);
            itens.AddRange(listaAdicionar);
            
            return itens;
        }

        public static explicit operator List<Entidade>(DbComposição<Entidade> entidade)
        {
            return entidade.ExtrairElementos();
        }

        /// <summary>
        /// Obtém enumerador compatível de itens cadastrados e a serem cadastrados.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            List<Entidade> itens = ExtrairElementos();

            return itens.GetEnumerator();
        }

        /// <summary>
        /// Uma composição é um relacionamento, cujo cadastro
        /// depende de outros itens e não da lista em si.
        /// Portanto, este valor é uma constante verdadeira.
        /// </summary>
        /// <remarks>
        /// Cadastrado é uma constante de valor verdadeiro.
        /// </remarks>
        public override bool Cadastrado
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Determina se todos os relacionamentos encontram-se atualizados.
        /// </summary>
        public override bool Atualizado
        {
            get
            {
                bool atualizado = listaAdicionar.Count == 0 && listaRemover.Count == 0;

                if (atualizado)
                    foreach (Entidade entidade in listaItens)
                        if (entidade is DbManipulação)
                        {
                            DbManipulação dbEntidade = entidade as DbManipulação;

                            atualizado &= dbEntidade.Atualizado;
                        }

                return atualizado;
            }
        }

        /// <summary>
        /// Verifica se contém uma determinada entidade.
        /// </summary>
        /// <param name="entidade">Entidade a ser verificada.</param>
        /// <returns>Se a entidade encontra-se na composição.</returns>
        public bool Contém(Entidade entidade)
        {
            if (listaItens.Contains(entidade) || listaAdicionar.Contains(entidade))
                return true;

            
            foreach (Entidade e in listaItens)
                if (e.Equals(entidade)) return true;

            foreach (Entidade e in listaAdicionar)
                if (e.Equals(entidade)) return true;

            return false;

            /* As vezes o objeto entidade é diferente que aquele dentro da lista.
             * Como Contains() não executa o compareTo(), então sempre Contém retorna falso,
             * (quando as instancias sao diferentes)
             */
            //return listaItens.Contains(entidade) || listaAdicionar.Contains(entidade);
        }

        /// <summary>
        /// Conta quantos elementos existem na composição.
        /// </summary>
        /// <returns>Número total de elementos.</returns>
        public int ContarElementos()
        {
            return listaAdicionar.Count + listaItens.Count;
        }

        public Entidade[] ToArray()
        {
            return ExtrairElementos().ToArray();
        }
    }
}
