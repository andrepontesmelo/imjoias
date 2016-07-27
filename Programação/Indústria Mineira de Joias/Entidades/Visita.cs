using Acesso.Comum;
using Entidades.Configuração;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades
{
    [DbTransação]
    public class Visita : DbManipulaçãoAutomática
    {
        private static readonly string SQL_ORDEM = " ORDER BY entrada desc ";

        [DbChavePrimária(false)]
        private DateTime entrada;

        [DbColuna("saida")]
        private DateTime? saída;

        private uint? espera;

        private MotivoContato motivo;

        [DbRelacionamento("codigo", "setor")]
        private Setor setor;

        private DbComposiçãoInalterável<string> nomes;

        private DbComposiçãoInalterável<Pessoa.Pessoa> pessoas;

        [DbColuna("funcionario"), DbRelacionamento("codigo", "funcionario")]
        private Funcionário atendente;

        [DbAtributo(TipoAtributo.Ignorar)]
        private bool atendimentoForaDoRodízio = false;

        public bool AtendimentoForaDoRodízio
        {
            get { return atendimentoForaDoRodízio; }
            set { atendimentoForaDoRodízio = value; }
        }

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

        public DateTime? Saída
        {
            get { return saída; }
            set { saída = value; DefinirDesatualizado(); }
        }

        public uint? Espera
        {
            get { return espera; }
            set { espera = value; DefinirDesatualizado(); }
        }

        private MotivoContato Motivo
        {
            get { return motivo; }
            set { motivo = value; DefinirDesatualizado(); }
        }

        public Setor Setor
        {
            get { return setor; }
            set { setor = value; DefinirDesatualizado(); }
        }

        public DbComposiçãoInalterável<string> Nomes
        {
            get { return nomes; }
        }

        public DbComposiçãoInalterável<Pessoa.Pessoa> Pessoas
        {
            get { return pessoas; }
        }

        public Funcionário Atendente
        {
            get { return atendente; }
            set { atendente = value; DefinirDesatualizado(); }
        }

        public Visita()
        {
            nomes = new DbComposiçãoInalterável<string>(
                new DbAção<string>(CadastrarNome),
                new DbAção<string>(DescadastrarNome));

            pessoas = new DbComposiçãoInalterável<Pessoa.Pessoa>(
                new DbAção<Pessoa.Pessoa>(CadastrarPessoa),
                new DbAção<Pessoa.Pessoa>(DescadastrarPessoa));
        }

        public Visita(params PessoaFísica[] clientes)
            : this()
        {
            foreach (PessoaFísica cliente in clientes)
                pessoas.Adicionar(cliente);
        }

        private void CadastrarNome(IDbCommand cmd, string nome)
        {
            cmd.CommandText = "INSERT INTO visitanome (visita, nome) VALUES ("
                + DbTransformar(entrada) + ", "
                + DbTransformar(nome) + ")";

            cmd.ExecuteNonQuery();
        }

        private void DescadastrarNome(IDbCommand cmd, string nome)
        {
            cmd.CommandText = "DELETE FROM visitanome WHERE "
                + "visita = " + DbTransformar(entrada) + " AND "
                + "nome = " + DbTransformar(nome);

            cmd.ExecuteNonQuery();
        }

        private void CadastrarPessoa(IDbCommand cmd, Pessoa.Pessoa pessoaFísica)
        {
            cmd.CommandText = "INSERT INTO visitapessoafisica (visita, pessoafisica) VALUES ("
                + DbTransformar(entrada) + ","
                + DbTransformar(pessoaFísica.Código) + ")";

            cmd.ExecuteNonQuery();
        }

        private void DescadastrarPessoa(IDbCommand cmd, Pessoa.Pessoa pessoaFísica)
        {
            cmd.CommandText = "DELETE FROM visitapessoafisica WHERE "
                + "entrada = " + DbTransformar(entrada) + " AND "
                + "pessoafisica = " + DbTransformar(pessoaFísica.Código);

            cmd.ExecuteNonQuery();
        }

        public static Visita ObterPróximaVisitaEsperando(Setor setor)
        {
            Visita visita;
            
            visita = MapearÚnicaLinha<Visita>("SELECT * FROM visita WHERE espera is NULL "
                        + "AND setor = " + DbTransformar(setor.Código)
                        + " ORDER BY entrada LIMIT 1");

            if (visita != null)
                CarregarRelacionamentos(new List<Visita>() { visita }, " v.entrada = " + DbTransformar(visita.Entrada));

            return visita;
        }

        public static List<Visita> ObterVisitas(DateTime pInicial, DateTime pFinal)
        {
            string where = " v.entrada BETWEEN " + DbTransformar(pInicial) + " AND " + DbTransformar(pFinal);

            List<Visita> visitas = Mapear<Visita>("SELECT * FROM visita v WHERE " + where + SQL_ORDEM);

            CarregarRelacionamentos(visitas, where);

            return visitas;
        }


        public static List<Visita> ObterVisitas(Pessoa.Pessoa pessoa)
        {
            string códigoPessoa = DbTransformar(pessoa.Código);

            List<Visita> visitas = Mapear<Visita>("SELECT v.* FROM visita v JOIN visitapessoafisica f on v.entrada=f.visita WHERE " +
                " pessoafisica=" + códigoPessoa + SQL_ORDEM);

            CarregarRelacionamentos(visitas, " entrada in (select visita from visitapessoafisica where pessoafisica=" + 
                códigoPessoa + ")");

            return visitas;
        }

        public static List<Visita> ObterVisitas(DateTime pInicial)
        {
            string where = " v.entrada > " + DbTransformar(pInicial) +  " OR v.saida > " + DbTransformar(pInicial);

            List<Visita> visitas = Mapear<Visita>(
                "SELECT * FROM visita v WHERE " + where + SQL_ORDEM);

            CarregarRelacionamentos(visitas, where);

            return visitas;
        }

        private static Dictionary<DateTime, Visita> CriarHashEntradaVisita(List<Visita> visitas)
        {
            Dictionary<DateTime, Visita> hash = new Dictionary<DateTime, Visita>();

            foreach (Visita v in visitas)
                hash[v.entrada] = v;

            return hash;
        }

        private static void CarregarRelacionamentos(List<Visita> visitas, string where)
        {
            if (visitas.Count == 0)
                return;

            IDataReader leitor = null;
            StringBuilder str = new StringBuilder();
            Dictionary<DateTime, Visita> hashEntradaVisita = CriarHashEntradaVisita(visitas);
            Dictionary<DateTime, ulong> hashVisitaCódigoPessoaFísica = new Dictionary<DateTime, ulong>();
            SortedSet<ulong> conjuntoPessoas = new SortedSet<ulong>();

            str.Append("select n.visita, n.nome, null as pessoaFisica from visitanome n ");
            str.Append(" JOIN visita v on n.visita=v.entrada where ");
            str.Append(where);
            str.Append(" UNION SELECT f.visita, null as nome, f.pessoaFisica from visitapessoafisica f ");
            str.Append(" JOIN visita v on f.visita=v.entrada where ");
            str.Append(where);

            string myStr = str.ToString();

            IDbConnection conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = str.ToString();

                        using (leitor = cmd.ExecuteReader())
                        {
                            Lê(leitor, hashEntradaVisita, hashVisitaCódigoPessoaFísica, conjuntoPessoas);
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();

                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }
            }

            CarregarPessoasFísicas(hashEntradaVisita, hashVisitaCódigoPessoaFísica, conjuntoPessoas);
        }

        private static void CarregarPessoasFísicas(Dictionary<DateTime, Visita> hash, Dictionary<DateTime, ulong> hashVisitaCódigoPessoaFísica, SortedSet<ulong> conjuntoPessoas)
        {
            Dictionary<ulong, Pessoa.Pessoa> hashPessoas =
                Pessoa.Pessoa.ObterPessoas(conjuntoPessoas);

            foreach (KeyValuePair<DateTime, Visita> par in hash)
            {
                DateTime entrada = par.Key;
                Visita visita = par.Value;
                ulong códigoPessoaFísica;

                if (hashVisitaCódigoPessoaFísica.TryGetValue(entrada, out códigoPessoaFísica))
                {
                    Pessoa.Pessoa pessoa = hashPessoas[códigoPessoaFísica];
                    visita.Pessoas.AdicionarJáCadastrado(pessoa);
                }
            }
        }

        private static void Lê(IDataReader leitor, Dictionary<DateTime, Visita> hash, Dictionary<DateTime, ulong> hashVisitaCódigoPessoaFísica, SortedSet<ulong> conjuntoPessoas)
        {
            while (leitor.Read())
            {
                Visita visita = hash[leitor.GetDateTime(0)];

                if (!leitor.IsDBNull(1))
                    visita.nomes.AdicionarJáCadastrado(leitor.GetString(1));

                if (!leitor.IsDBNull(2))
                {
                    ulong código = Convert.ToUInt64(leitor.GetValue(2));
                    hashVisitaCódigoPessoaFísica.Add(visita.entrada, código);
                    conjuntoPessoas.Add(código);
                }
            }
        }

        public static bool EmAtendimento(Funcionário funcionário)
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

        public static List<Visita> ObterAtendimentos(Funcionário funcionário)
        {
            string where = " v.funcionario = " + DbTransformar(funcionário.Código) + " AND v.saida IS NULL";

            List<Visita> visitas = Mapear<Visita>("SELECT v.* FROM visita v WHERE " + where);

            CarregarRelacionamentos(visitas, where);

            return visitas;
        }

        public static List<Visita> ObterVisitasRelevantes()
        {
            string where = " v.saida IS NULL OR v.entrada >= CURDATE() ";

            List<Visita> visitas = Mapear<Visita>("SELECT * FROM visita v WHERE " + 
                where + " ORDER BY entrada ");

            CarregarRelacionamentos(visitas,  where);

            return visitas;
        }

        public static List<Visita> ObterVisitasRelevantes(Funcionário funcionário, Setor[] setores)
        {
            string strSetores = Setor.ObterSetoresSeparadosPorVirgula(setores);

            if (String.IsNullOrEmpty(strSetores))
                return null;

            string where = " v.saida IS NULL OR v.entrada >= date(" +
                "(SELECT MAX(entrada) FROM visita WHERE funcionario = " +
                DbTransformar(funcionário.Código) + "))" +
                " AND setor IN (" + strSetores + ")" +
                " AND entrada >= " + DbTransformar(DadosGlobais.Instância.HoraDataAtual.Date.Subtract(new TimeSpan(3, 0, 0, 0))) +
                " ORDER BY entrada";

            List<Visita> visitas = Mapear<Visita>("SELECT * FROM visita v WHERE " + where);
            CarregarRelacionamentos(visitas, where);

            return visitas;
        }

        public string ExtrairNomes()
        {
            StringBuilder nomes = new StringBuilder();

            foreach (Entidades.Pessoa.Pessoa pessoa in this.pessoas)
            {
                if (nomes.Length > 0)
                    nomes.Append(", ");

                nomes.Append(pessoa.Nome);
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
