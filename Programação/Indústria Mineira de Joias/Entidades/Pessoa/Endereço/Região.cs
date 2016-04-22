using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Data;

namespace Entidades.Pessoa.Endereço
{
    /// <summary>
    /// Região: Conjunto personalizável de estados e cidades.
    /// </summary>
    [DbTabela("regiao"), Cacheável("ObterRegião"), DbTransação, NãoCopiarCache]
    public class Região : DbManipulaçãoAutomática
    {
        #region Atributos

        /// <summary>
        /// Chave primária.
        /// </summary>
        [DbChavePrimária(true), DbColuna("codigo")]
        private uint código = 0;

        /// <summary>
        /// Nome da região.
        /// </summary>
        private string nome;

        [DbColuna("observacoes")]
        private string observações;

        //[DbRelacionamento("codigo", "pessoa")]
        //private Entidades.Pessoa.Pessoa representante;

#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        // Não pose usar DbRelacionamento porque cria chamadas ciclicas.
        // Para debugar, entre no atendimento ao cliente.
        private ulong? representante;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        /// <summary>
        /// Estados pertencentes à região.
        /// </summary>
        private DbComposição<Estado> estados;

        /// <summary>
        /// Localidades pertencentes à região.
        /// </summary>
        private DbComposição<Localidade> localidades;

        /// <summary>
        /// Pessoas pertencentes à região.
        /// </summary>
        private DbComposição<Pessoa> pessoas;

        #endregion

        #region Propriedades

        /// <summary>
        /// Chave primária.
        /// </summary>
        public uint Código { get { return código; } }

        /// <summary>
        /// Nome da região.
        /// </summary>
        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        //public Entidades.Pessoa.Pessoa Representante { get { return representante; } }

        /// <summary>
        /// Observações sobre a região.
        /// </summary>
        public string Observações { get { return observações; } set { observações = value; DefinirDesatualizado(); } }

        /// <summary>
        /// Estados pertencentes à região.
        /// </summary>
        public DbComposição<Estado> Estados
        {
            get
            {
                if (estados == null)
                    CarregarEstados();

                return estados;
            }
        }

        /// <summary>
        /// Localidades específicas pertencentes à região.
        /// </summary>
        public DbComposição<Localidade> Localidades
        {
            get
            {
                if (localidades == null)
                    CarregarLocalidades();

                return localidades;
            }
        }

        /// <summary>
        /// Pessoas que pertencem à região.
        /// </summary>
        public DbComposição<Pessoa> Pessoas
        {
            get
            {
                if (pessoas == null)
                    CarregarPessoas();

                return pessoas;
            }
        }

        #endregion

        /// <summary>
        /// Construtora padrão.
        /// </summary>
        public Região() { }

        /// <summary>
        /// Cria uma região com código específico.
        /// </summary>
        /// <param name="código">Código da região.</param>
        /// <remarks>Utilizado para importação de banco de dados.</remarks>
        public Região(uint código)
        {
            this.código = código;
            this.nome = "Região " + código.ToString();
        }

        #region Recuperação da entidade

        public static implicit operator Região(uint? código)
        {
            if (código.HasValue)
                return código.Value;
            else
                return null;
        }

        public static implicit operator Região(uint código)
        {
            return (Região)CacheDb.Instância.ObterEntidade(typeof(Região), código);
        }

        public static Região ObterRegião(uint código)
        {
            if (hashRegiões == null)
                ConstruirHashRegiões();

            Região encontrada = null;

            hashRegiões.TryGetValue(código, out encontrada);
                
            return encontrada;
        }

        private static Dictionary<uint, Região> hashRegiões = null;
        private static void ConstruirHashRegiões()
        {
            Região[] todas = ObterRegiões();
            hashRegiões = new Dictionary<uint,Região>(todas.Length);
            foreach (Região r in todas)
                hashRegiões[r.Código] = r;
        }


        #endregion

        /// <summary>
        /// Carrega estados vinculados à região.
        /// </summary>
        private void CarregarEstados()
        {
            estados = new DbComposição<Estado>(
                Estado.ObterEstados(this),
                new DbAção<Estado>(InserirEstado),
                new DbAção<Estado>(AtualizarEstado),
                new DbAção<Estado>(RemoverEstado));
        }

        /// <summary>
        /// Carrega localidades vinculadas especificamente à região.
        /// </summary>
        private void CarregarLocalidades()
        {
            localidades = new DbComposição<Localidade>(
                Localidade.ObterLocalidades(this),
                new DbAção<Localidade>(InserirLocalidade),
                new DbAção<Localidade>(AtualizarLocalidade),
                new DbAção<Localidade>(RemoverLocalidade));
        }

        private void CarregarPessoas()
        {
            pessoas = new DbComposição<Pessoa>(
                Pessoa.ObterPessoas(this),
                new DbAção<Pessoa>(InserirPessoa),
                new DbAção<Pessoa>(AtualizarPessoa),
                new DbAção<Pessoa>(RemoverPessoa));
        }

        private void InserirEstado(IDbCommand cmd, Estado estado)
        {
            estado.Região = this;

            if (estado.Cadastrado)
                estado.Atualizar();
            else
                estado.Cadastrar();

            CacheDb.Instância.Remover(estado);
        }

        private void AtualizarEstado(IDbCommand cmd, Estado estado)
        {
            if (estado.Região != this)
                estado.Região = this;

            estado.Atualizar();
            CacheDb.Instância.Remover(estado);
        }

        private void RemoverEstado(IDbCommand cmd, Estado estado)
        {
            estado.Região = null;
            estado.Atualizar();
            CacheDb.Instância.Remover(estado);
        }

        private void InserirLocalidade(IDbCommand cmd, Localidade localidade)
        {
            localidade.Região = this;

            if (localidade.Cadastrado)
                localidade.Atualizar();
            else
                localidade.Cadastrar();

            CacheDb.Instância.Remover(localidade);
        }

        private void AtualizarLocalidade(IDbCommand cmd, Localidade localidade)
        {
            if (localidade.Região != this)
                localidade.Região = this;

            localidade.Atualizar();
            CacheDb.Instância.Remover(localidade);
        }

        private void RemoverLocalidade(IDbCommand cmd, Localidade localidade)
        {
            localidade.Região = null;
            localidade.Atualizar();
            CacheDb.Instância.Remover(localidade);
        }

        private void InserirPessoa(IDbCommand cmd, Pessoa pessoa)
        {
            pessoa.Região = this;

            if (pessoa.Cadastrado)
                pessoa.Atualizar();
            else
                pessoa.Cadastrar();

            CacheDb.Instância.Remover(pessoa);
        }

        private void AtualizarPessoa(IDbCommand cmd, Pessoa pessoa)
        {
            if (pessoa.Região != this)
                pessoa.Região = this;

            pessoa.Atualizar();
            CacheDb.Instância.Remover(pessoa);
        }

        private void RemoverPessoa(IDbCommand cmd, Pessoa pessoa)
        {
            pessoa.Região = null;
            pessoa.Atualizar();
            CacheDb.Instância.Remover(pessoa);
        }

        public static Região[] ObterRegiões()
        {
            return Mapear<Região>("SELECT * FROM regiao ORDER BY nome").ToArray();
        }

        public override string ToString()
        {
            return nome;
        }

        public override bool Equals(object obj)
        {
            if (obj is Região)
                return código.Equals(((Região)obj).código);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return código.GetHashCode();
        }

        public void DefinirCódigo(uint código)
        {
            if (Cadastrado)
                throw new NotSupportedException("Não é possível definir código de uma região já cadastrada.");

            this.código = código;
        }

        public Entidades.Pessoa.Representante ObterRepresentante()
        {
            if (representante.HasValue)
                return Entidades.Pessoa.Representante.ObterPessoa(representante.Value);
            else
                return null;
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            if (código > 0)
            {
                cmd.CommandText = "INSERT INTO regiao (codigo, nome, observacoes) VALUES" +
                    " (" + DbTransformar(código) + ", " +
                    DbTransformar(nome) + ", " +
                    DbTransformar(observações) + ")";
                cmd.ExecuteNonQuery();

                if (estados != null)
                    estados.Cadastrar();

                if (localidades != null)
                    localidades.Cadastrar();

                if (pessoas != null)
                    pessoas.Cadastrar();
            }
            else
                base.Cadastrar(cmd);
        }

        public static Região[] Remover(Região[] regiões, Região exceto)
        {
            List<Região> lst = new List<Região>(regiões);
            lst.Remove(exceto);
            return lst.ToArray();
        }
    }
}
