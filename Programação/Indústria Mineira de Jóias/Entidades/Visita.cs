using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Pessoa;
using System.Data;
using System.Collections;
using Entidades.Configuração;

namespace Entidades
{
    /// <summary>
    /// Registro de visita.
    /// </summary>
    [DbTransação]
    public class Visita : DbManipulaçãoAutomática
    {
        #region Atributos

        /// <summary>
        /// Momento em que o visitante entrou na empresa.
        /// </summary>
        [DbChavePrimária(false)]
        private DateTime entrada;

        /// <summary>
        /// Momento em que o visitante deixou a empresa.
        /// </summary>
        [DbColuna("saida")]
        private DateTime? saída;

        /// <summary>
        /// Tempo em segundos de espera por atendimento.
        /// </summary>
        private uint? espera;

        /// <summary>
        /// Motivo da visita do cliente.
        /// </summary>
        private MotivoContato motivo;

        /// <summary>
        /// Setor de atendimento.
        /// </summary>
        [DbRelacionamento("codigo", "setor")]
        private Setor setor;

        /// <summary>
        /// Lista de nomes dos visitantes não cadastrados.
        /// </summary>
        private DbComposiçãoInalterável<string> nomes;

        /// <summary>
        /// Lista de visitantes cadastrados.
        /// </summary>
        private DbComposiçãoInalterável<PessoaFísica> pessoas;

        /// <summary>
        /// Atendente da visita.
        /// </summary>
        [DbColuna("funcionario"), DbRelacionamento("codigo", "funcionario")]
        private Funcionário atendente;

        [DbAtributo(TipoAtributo.Ignorar)]
        private bool atendimentoForaDoRodízio = false;

        #endregion

        #region Propriedades

        public bool AtendimentoForaDoRodízio
        {
            get { return atendimentoForaDoRodízio; }
            set { atendimentoForaDoRodízio = value; }
        }

        /// <summary>
        /// Momento em que o visitante entrou na empresa.
        /// </summary>
        /// <remarks>
        /// Por ser chave primária, só pode ser alterado se
        /// o objeto não estiver cadastrado no banco de dados.
        /// </remarks>
        public DateTime Entrada
        {
            get { return entrada; }
            set
            {
                if (Cadastrado)
                    throw new Acesso.Comum.Exceções.AlteraçãoChavePrimária(this);

                entrada = value;
            }
        }

        /// <summary>
        /// Momento em que o visitante deixou a empresa.
        /// </summary>
        public DateTime? Saída
        {
            get { return saída; }
            set { saída = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Tempo em segundos de espera por atendimento.
        /// </summary>
        public uint? Espera
        {
            get { return espera; }
            set { espera = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Motivo da visita do cliente.
        /// </summary>
        private MotivoContato Motivo
        {
            get { return motivo; }
            set { motivo = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Setor de atendimento.
        /// </summary>
        public Setor Setor
        {
            get { return setor; }
            set { setor = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Lista de nomes dos visitantes não cadastrados.
        /// </summary>
        public DbComposiçãoInalterável<string> Nomes
        {
            get { return nomes; }
        }

        /// <summary>
        /// Lista de visitantes cadastrados.
        /// </summary>
        public DbComposiçãoInalterável<PessoaFísica> Pessoas
        {
            get { return pessoas; }
        }

        /// <summary>
        /// Atendente da visita.
        /// </summary>
        public Funcionário Atendente
        {
            get { return atendente; }
            set { atendente = value; DefinirDesatualizado(); }
        }

        #endregion

        /// <summary>
        /// Constrói a visita.
        /// </summary>
        public Visita()
        {
            nomes = new DbComposiçãoInalterável<string>(
                new DbAção<string>(CadastrarNome),
                new DbAção<string>(DescadastrarNome));

            pessoas = new DbComposiçãoInalterável<PessoaFísica>(
                new DbAção<PessoaFísica>(CadastrarPessoa),
                new DbAção<PessoaFísica>(DescadastrarPessoa));
        }

        /// <summary>
        /// Constrói a visita considerando já um cliente para atendimento.
        /// </summary>
        /// <param name="clientes">Clientes a serem atendidos.</param>
        public Visita(params PessoaFísica[] clientes)
            : this()
        {
            foreach (PessoaFísica cliente in clientes)
                pessoas.Adicionar(cliente);
        }

        #region Manipulação de nomes de visitantes.

        /// <summary>
        /// Cadastra um nome do visitante no banco de dados.
        /// </summary>
        private void CadastrarNome(IDbCommand cmd, string nome)
        {
            cmd.CommandText = "INSERT INTO visitanome (visita, nome) VALUES ("
                + DbTransformar(entrada) + ", "
                + DbTransformar(nome) + ")";

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Descadastra um nome do banco de dados.
        /// </summary>
        private void DescadastrarNome(IDbCommand cmd, string nome)
        {
            cmd.CommandText = "DELETE FROM visitanome WHERE "
                + "visita = " + DbTransformar(entrada) + " AND "
                + "nome = " + DbTransformar(nome);

            cmd.ExecuteNonQuery();
        }

        #endregion

        #region Manipulação de visitantes cadastrados.

        /// <summary>
        /// Cadastra a pessoa como visitante.
        /// </summary>
        private void CadastrarPessoa(IDbCommand cmd, PessoaFísica pessoa)
        {
            cmd.CommandText = "INSERT INTO visitapessoafisica (visita, pessoafisica) VALUES ("
                + DbTransformar(entrada) + ","
                + DbTransformar(pessoa.Código) + ")";

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Descadastra a pessoa como visitante.
        /// </summary>
        private void DescadastrarPessoa(IDbCommand cmd, PessoaFísica pessoa)
        {
            cmd.CommandText = "DELETE FROM visitapessoafisica WHERE "
                + "entrada = " + DbTransformar(entrada) + " AND "
                + "pessoafisica = " + DbTransformar(pessoa.Código);

            cmd.ExecuteNonQuery();
        }

        #endregion

        #region Recuperação do banco de dados

        /// <summary>
        /// Obtém próximo cliente a ser atendido por um setor.
        /// </summary>
        /// <param name="setor">Setor para atendimento.</param>
        /// <returns>Dados da visita do cliente que é o próximo a ser atendido.</returns>
        public static Visita ObterPróximaVisitaEsperando(Setor setor)
        {
            Visita visita;
            
            visita = MapearÚnicaLinha<Visita>("SELECT * FROM visita WHERE espera is NULL "
                        + "AND setor = " + DbTransformar(setor.Código)
                        + " ORDER BY entrada LIMIT 1");

            if (visita != null)
                visita.CarregarRelacionamentos();

            return visita;
        }

        /// <summary>
        /// Obtém clientes que visitaram a empresa em um determinado período.
        /// </summary>
        /// <param name="pInicial">Período inicial.</param>
        /// <param name="pFinal">Período final.</param>
        /// <returns>Visitas neste período.</returns>
        public static Visita[] ObterVisitas(DateTime pInicial, DateTime pFinal)
        {
            /* Esta consulta pode ser otimizada,
             * porém sua complexidade será aumentada.
             * Como ela raramente é utilizada,
             * foi optado por deixá-la mais simples.
             * -- Júlio, 12/04/2006
             */
            Visita[] vetor;

            vetor = Mapear<Visita>(
                "SELECT * FROM visita WHERE entrada BETWEEN "
                + DbTransformar(pInicial) + " AND" + DbTransformar(pFinal)).ToArray();

            foreach (Visita visita in vetor)
                visita.CarregarRelacionamentos();

            return vetor;
        }

        /// <summary>
        /// Obtém clientes que visitaram ou sariam da empresa a partir
        /// de um determinado momento.
        /// </summary>
        /// <param name="pInicial">Período inicial.</param>
        /// <returns>Visitas neste período.</returns>
        public static Visita[] ObterVisitas(DateTime pInicial)
        {
            Visita[] vetor;

            vetor = Mapear<Visita>(
                "SELECT * FROM visita WHERE entrada > "
                + DbTransformar(pInicial) +  " OR saida > " + DbTransformar(pInicial)).ToArray();

            foreach (Visita visita in vetor)
                visita.CarregarRelacionamentos();

            return vetor;
        }

        /// <summary>
        /// Carrega todos os relacionamentos da visita.
        /// </summary>
        private void CarregarRelacionamentos()
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        IDataReader leitor;

                        #region Carregar nomes

                        cmd.CommandText = "SELECT nome FROM visitanome WHERE visita = " + DbTransformar(entrada);

                        using (leitor = cmd.ExecuteReader())
                        {

                            try
                            {
                                while (leitor.Read())
                                    nomes.AdicionarJáCadastrado(leitor.GetString(0));
                            }
                            finally
                            {
                                if (leitor != null)
                                    leitor.Close();
                            }
                        }

                        #endregion

                        #region Carregar pessoas cadastradas

                        cmd.CommandText = "SELECT pessoafisica FROM visitapessoafisica WHERE visita = " + DbTransformar(entrada);

                        using (leitor = cmd.ExecuteReader())
                        {

                            try
                            {
                                while (leitor.Read())
                                    pessoas.AdicionarJáCadastrado(PessoaFísica.ObterPessoa(Convert.ToUInt64(leitor.GetValue(0))));
                            }
                            finally
                            {
                                if (leitor != null)
                                    leitor.Close();
                            }
                        }

                        #endregion
                    }
                } finally {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }
        }

        #endregion

        /// <summary>
        /// Verifica se um determinado funcionário está em atendimento.
        /// </summary>
        /// <param name="funcionário">Funcionário em atendimento.</param>
        /// <returns>Se o funcionário está em atendimento.</returns>
        public static bool VerificarAtendimento(Funcionário funcionário)
        {
            IDbConnection conexão = Conexão;
            int qtd;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM visita v" +
                        " WHERE v.funcionario = " + DbTransformar(funcionário.Código) +
                        " AND v.saida IS NULL";

                    qtd = Convert.ToInt32(cmd.ExecuteScalar());
                }

            return qtd > 0;
        }

        /// <summary>
        /// Verifica se um determinado funcionário está em atendimento.
        /// </summary>
        /// <param name="funcionário">Funcionário em atendimento.</param>
        /// <returns>Se o funcionário está em atendimento.</returns>
        public static List<Visita> ObterAtendimentos(Funcionário funcionário)
        {
            List<Visita> visitas = Mapear<Visita>(
                    "SELECT v.* FROM visita v" +
                        " WHERE v.funcionario = " + DbTransformar(funcionário.Código) +
                        " AND v.saida IS NULL");

            foreach (Visita visita in visitas)
                visita.CarregarRelacionamentos();

            return visitas;
        }

        /// <summary>
        /// Obtém visitas relevantes conforme os critérios:
        /// (i) se está na empresa;
        /// (ii) se chegou à empresa no dia corrente.
        /// </summary>
        public static List<Visita> ObterVisitasRelevantes()
        {
            List<Visita> visitas = Mapear<Visita>(
                    "SELECT * FROM visita" +
                    " WHERE saida IS NULL OR entrada >= CURDATE() ORDER BY entrada");

            foreach (Visita visita in visitas)
                visita.CarregarRelacionamentos();

            return visitas;
        }

        /// <summary>
        /// Obtém visitas relevantes para um funcionário conforme os critérios:
        /// (i) se está na empresa;
        /// (ii) se chegou à empresa no dia corrente.
        /// </summary>
        public static List<Visita> ObterVisitasRelevantes(Funcionário funcionário, Setor[] setores)
        {
            string strSetores = "";

            if (setores.Length == 0)
                return null;
            
            foreach (Setor setor in setores)
            {
                if (strSetores.Length > 0)
                    strSetores += ", ";

                strSetores += setor.Código;
            }

            List<Visita> visitas;

            visitas = Mapear<Visita>(
                "SELECT * FROM visita" +
                " WHERE saida IS NULL OR entrada >= date(" +
                "(SELECT MAX(entrada) FROM visita WHERE funcionario = " +
                DbTransformar(funcionário.Código) + "))" +
                " AND setor IN (" + strSetores + ")" +
                " AND entrada >= " + DbTransformar(DadosGlobais.Instância.HoraDataAtual.Date.Subtract(new TimeSpan(3, 0, 0, 0))) +
                " ORDER BY entrada");

            foreach (Visita visita in visitas)
                visita.CarregarRelacionamentos();

            return visitas;
        }

        public string ExtrairNomes()
        {
            StringBuilder nomes = new StringBuilder();

            foreach (Entidades.Pessoa.Pessoa pessoa in this.pessoas)
            {
                if (nomes.Length > 0)
                    nomes.Append(", ");

                nomes.Append(pessoa.PrimeiroNome);
            }

            foreach (string nome in this.nomes)
            {
                if (nomes.Length > 0)
                    nomes.Append(", ");

                nomes.Append(nome);
            }

            return nomes.ToString();
        }

        public static string ExtrairNomes(List<Visita> visitas)
        {
            StringBuilder nomes = new StringBuilder();

            foreach (Visita visita in visitas)
            {
                if (nomes.Length > 0)
                    nomes.Append("; ");

                nomes.Append(visita.ExtrairNomes());
            }

            return nomes.ToString();
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            entrada = DadosGlobais.Instância.HoraDataAtual;
            Console.WriteLine("Entrada da visita: " + entrada.ToString());
            base.Cadastrar(cmd);
        }

        public override bool Equals(object obj)
        {
            if (obj is Visita)
                return entrada == ((Visita)obj).entrada || base.Equals(obj);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return entrada.GetHashCode();
        }
    }
}
