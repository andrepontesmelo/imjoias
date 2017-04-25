using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Configuração;
using Entidades.Controle;
using Entidades.Pessoa.Endereço;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades.Coaf;
using System.Text.RegularExpressions;

namespace Entidades.Pessoa
{
    [Serializable, DbTransação, Cacheável("ObterPessoaSemCache"), NãoCopiarCache]
    public class Pessoa : DbManipulação, IComparable
    {
        public static readonly int TotalAtributos = 12;

        protected ulong codigo;
        protected string nome;
        protected DbComposição<Endereço.Endereço> endereços;
        protected DbComposição<Telefone> telefones;
        protected string email;

        [DbColuna("observacoes")]
        protected string observações;

        protected DbFoto foto;

        [DbColuna("classificacoes")]
        protected ulong classificações;

        protected DateTime? dataRegistro;

        [DbColuna("dataAlteracao")]
        protected DateTime? dataAlteração;

        [DbColuna("ultimaVisita")]
        protected DateTime? últimaVisita;

        [Flags]
        private enum EstadoFoto
        {
            Desconhecido = 0,
            Inexistente = 1,
            Desatualizada = 2,
            Cadastrada = 4
        }

        [DbAtributo(TipoAtributo.Ignorar)]
        private EstadoFoto estadoFoto = EstadoFoto.Desconhecido;

        [DbRelacionamento("codigo", "setor")]
        protected Setor setor;

        protected DbComposição<DataRelevante> datasRelevantes;

        protected double? maiorVenda;

        [DbColuna("credito")]
        protected double? crédito;

        [DbRelacionamento("código", "regiao"), DbColuna("regiao")]
        protected Região região;

        public ulong Código
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nome
        {
            get
            {
                return nome == null ? "" : nome;
            }
            set
            {
                nome = value;
                DefinirDesatualizado();
            }
        }

        public string PrimeiroNome
        {
            get
            {
                int i = nome.IndexOf(' ');

                if (i <= 0)
                    return nome;

                return nome.Substring(0, nome.IndexOf(' '));
            }
        }

        public string Observações
        {
            get { return observações; }
            set
            {
                observações = value;
                DefinirDesatualizado();
            }
        }

        public string EMail
        {
            get { return email; }
            set
            {
                email = value;
                DefinirDesatualizado();
            }
        }

        public static string FormatarCpfCnpj(string cpfCnpj)
        {
            if (cpfCnpj == null)
                return null;

            if (PessoaFísica.ValidarCPF(cpfCnpj))
                return PessoaFísica.Formatar(cpfCnpj);

            if (PessoaJurídica.ValidarCNPJ(cpfCnpj))
                return PessoaJurídica.FormatarCNPJ(cpfCnpj);

            return cpfCnpj;
        }


        public ulong Classificações
        {
            get { return classificações; }
            set { classificações = value; DefinirDesatualizado(); }
        }

        public DateTime? DataRegistro => dataRegistro; 

        public DateTime? DataAlteração => dataAlteração; 

        public DateTime? ÚltimaVisita
        {
            get { return últimaVisita; }
            set { últimaVisita = value; DefinirDesatualizado(); }
        }

        public DbComposição<Endereço.Endereço> Endereços
        {
            get
            {
                if (endereços == null)
                    CarregarEndereços();

                return endereços;
            }
        }

        public DbComposição<Telefone> Telefones
        {
            get
            {
                if (telefones == null)
                    CarregarTelefones();

                return telefones;
            }
            set { telefones = value; }
        }

        public Setor Setor { get { return setor; } set { setor = value; DefinirDesatualizado(); } }

        public DbComposição<DataRelevante> DatasRelevantes
        {
            get
            {
                if (datasRelevantes == null)
                    datasRelevantes = new DbComposição<DataRelevante>(
                        DataRelevante.ObterDatasRelevantes(this));

                return datasRelevantes;
            }
        }

        public double? MaiorVenda
        {
            get { return maiorVenda; }
            set { maiorVenda = value; }
        }

        public double? Crédito
        {
            get { return crédito; }
            set { crédito = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Codificação:
        /// MMYYYYxxxxCC
        /// 
        /// MM = mês da primeira compra
        /// YYYY = ano da primeira compra
        /// xxxx = maior compra
        /// CC = crédito
        /// </summary>
        public string NossoNúmero
        {
            get
            {
                string nn;

                if (dataRegistro.HasValue)
                    nn = String.Format("{0:MMyyyy}{1}",
                        this.dataRegistro.Value,
                        CodificarValor(this.maiorVenda));
                else
                    nn = CodificarValor(this.maiorVenda);

                if (crédito.HasValue)
                    nn += String.Format("{0:##00}",
                        Math.Truncate(this.crédito.Value / 1000));

                return nn;
            }
        }

        public Região Região
        {
            get { return região; }
            set { região = value; DefinirDesatualizado(); }
        }

        public Pessoa()
        {
            if (DadosGlobais.Instância.Conectado)
            {
                dataRegistro = DadosGlobais.Instância.HoraDataAtual;
                dataAlteração = DadosGlobais.Instância.HoraDataAtual;
            }
        }

        public Pessoa(ulong código)
        {
            this.codigo = código;
        }

        public int CompareTo(object obj)
        {
            if (obj is Pessoa)
                return this.Nome.CompareTo(((Pessoa)obj).Nome);
            else
                return Nome.CompareTo(obj.ToString());
        }

        public static Pessoa Varejo => ObterPessoa(1022);

        public static string[] ObterNomes(string nomeBase, int limite)
        {
            IDbConnection conexão;
            ArrayList dados = new ArrayList(limite);
            conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                try
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        IDataReader leitor = null;

                        string tmpNome = InserirNomeBase(nomeBase, limite, dados, cmd, ref leitor);
                        leitor = PesquisarDemaisNomes(nomeBase, limite, dados, cmd, leitor);
                    }

                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }

                return (string[])dados.ToArray(typeof(string));
            }
        }

        private static string InserirNomeBase(string nomeBase, int limite, ArrayList dados, IDbCommand cmd, ref IDataReader leitor)
        {
            string tmpNome = nomeBase.Replace(' ', '%').Replace("%%", "%");
            cmd.CommandText = "SELECT nome FROM pessoa p WHERE nome LIKE '" +
                tmpNome + "%' ORDER BY nome ASC LIMIT " +
                limite.ToString();

            try
            {
                using (leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        dados.Add(leitor.GetString(0));
                    }
                }
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }

            return tmpNome;
        }

        private static IDataReader PesquisarDemaisNomes(string nomeBase, int limite, ArrayList dados, IDbCommand cmd, IDataReader leitor)
        {
            if (dados.Count == 0)
            {
                ICollection nomes = ExtrairNomes(nomeBase);

                cmd.CommandText = "SELECT nome FROM pessoa p WHERE ";

                foreach (string parte in nomes)
                {
                    cmd.CommandText += "nome LIKE '%" +
                        parte + "%' AND ";
                }

                cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 3, 3)
                    + " ORDER BY nome ASC LIMIT " + ((int)(limite - dados.Count)).ToString();

                try
                {
                    using (leitor = cmd.ExecuteReader())
                    {

                        while (leitor.Read())
                        {
                            dados.Add(leitor.GetString(0));
                        }
                    }
                }
                finally
                {
                    if (leitor != null)
                        leitor.Close();
                }
            }

            return leitor;
        }

        public static Pessoa ObterPessoa(ulong código)
        {
            return (Pessoa) CacheDb.Instância.ObterEntidade(typeof(Pessoa), código);
        }

        public static Pessoa ObterPessoa(IDataReader leitor, int inicioPessoa, int inicioPessoaFisica, int inicioPessoaJuridica)
        {
            if (!leitor.IsDBNull(inicioPessoaFisica))
            {
                return PessoaFísica.Obter(leitor, inicioPessoa, inicioPessoaFisica);
            }
            else
            {
                return PessoaJurídica.Obter(leitor, inicioPessoa, inicioPessoaJuridica);
            }
        }

        public static Pessoa ObterPessoaSemCache(ulong código)
        {
            IDbConnection conexão = Conexão;
            IDataReader leitor = null;
            Pessoa p = null;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "SELECT * FROM pessoa left join pessoafisica on pessoa.codigo=pessoafisica.codigo left " + 
                            " join pessoajuridica pj on pessoa.codigo=pj.codigo WHERE pessoa.codigo = "
                            + DbTransformar(código);

                        using (leitor = cmd.ExecuteReader())
                        {
                            if (leitor.Read())
                                p = (Pessoa.ObterPessoa(leitor, 0, TotalAtributos, TotalAtributos + PessoaFísica.TotalAtributos));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }

            return p;
        }

        public static List<Pessoa> ObterPessoas()
        {
            IDataReader leitor = null;
            List<Pessoa> dados = new List<Pessoa>();
            IDbConnection conexão = Conexão;
            StringBuilder comando = new StringBuilder();

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.regiao, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo ";
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                                dados.Add(Pessoa.ObterPessoa(leitor, 0, TotalAtributos, TotalAtributos + PessoaFísica.TotalAtributos));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }

                CarregarEndereços(dados);

                return dados;
            }
        }

        public static List<Pessoa> ObterPessoas(Região região)
        {
            return RealizarConsulta(
                "SELECT * FROM pessoa p LEFT JOIN pessoafisica pf ON p.codigo = pf.codigo" +
                " WHERE p.regiao = " + DbTransformar(região.Código), 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterPessoas(Classificação classificação)
        {
            return RealizarConsulta(
                "SELECT * FROM pessoa p LEFT JOIN pessoafisica pf ON p.codigo = pf.codigo" +
                " WHERE classificacoes & 1 << ( " + classificação.Código.ToString() + " - 1) > 0", 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterPessoas(Entidades.Setor setor)
        {
            List<Pessoa> pessoas;

            if (setor == null)
                throw new ArgumentNullException("setor");

            if (!setor.Cadastrado)
                throw new ArgumentException("Setor não cadastrado.", "setor");

            string cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE"
                + " pessoa.setor = " + DbTransformar(setor.Código);

            pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            return pessoas;
        }

        public static Dictionary<ulong, Pessoa> ObterPessoas(SortedSet<ulong> códigos)
        {
            if (códigos.Count == 0)
                return new Dictionary<ulong, Pessoa>();

            string cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE"
                + " pessoa.codigo in " + DbTransformarConjunto(códigos);

            List<Pessoa> pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            Dictionary<ulong, Pessoa> hash = new Dictionary<ulong, Pessoa>();
            foreach (Pessoa p in pessoas)
            {
                hash[p.Código] = p;
            }

            return hash;
        }

        public static List<Pessoa> ObterPessoas(Entidades.Setor setor, DateTime início, DateTime final)
        {
            List<Pessoa> pessoas;
            string cmd;

            if (setor == null)
                throw new ArgumentNullException("setor");

            if (!setor.Cadastrado)
                throw new ArgumentException("Setor não cadastrado.", "setor");

            if (início >= final)
                throw new ArgumentException("Período incorreto.");

            cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE"
                + " pessoa.setor = " + DbTransformar(setor.Código)
                + " AND pessoa.ultimaVisita BETWEEN " + DbTransformar(início)
                + " AND " + DbTransformar(final);

            pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            return pessoas;
        }

        public static List<Pessoa> ObterPessoasPorRegião(Entidades.Pessoa.Endereço.Região região)
        {
            List<Pessoa> pessoas;
            string cmd;

            cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE regiao = " + DbTransformar(região.Código);

            pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            return pessoas;
        }

        public static List<Pessoa> ObterPessoasPorTelefone(string telefone)
        {
            string cmd = "SELECT p.*, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo, telefone t"
                + " WHERE replace(replace(replace(replace(t.telefone,'(',''),')',''),'-',''),' ','') LIKE '%" + telefone + "%'"
                + " AND t.pessoa = p.codigo ";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        public static string ObterCódigoPessoas(HashSet<Pessoa> pessoas)
        {
            String retorno;
            StringBuilder códigoPessoas = new StringBuilder("(");
            bool primeiro = true;
            foreach (Pessoa p in pessoas)
            {
                if (!primeiro)
                    códigoPessoas.Append(", ");
                códigoPessoas.Append(p.Código);

                primeiro = false;
            }
            códigoPessoas.Append(") ");
            retorno = códigoPessoas.ToString();

            return retorno;
        }

        private static List<Pessoa> RealizarConsulta(string consulta, int inícioPessoa, int inícioPessoaFísica)
        {
            IDbConnection conexao = Conexão;
            IDataReader leitor = null;
            List<Pessoa> lista = new List<Pessoa>();

            lock (conexao)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexao);
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = consulta;
                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                                lista.Add(Pessoa.ObterPessoa(leitor, inícioPessoa, inícioPessoaFísica, 0));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexao);
                    }
                }
            }

            return lista;
        }


        public static Pessoa ObterConsumidorFinal()
        {
            return MapearÚnicaLinha<Pessoa>(
                "SELECT * FROM pessoa WHERE nome LIKE 'Consumidor Final'");
        }

        public static List<Pessoa> ObterPessoasPorCidade(Endereço.Localidade[] cidades)
        {
            if (cidades.Length == 0)
                return new List<Pessoa>();

            string strCidades = "";

            foreach (Endereço.Localidade cidade in cidades)
            {
                if (strCidades.Length > 0)
                    strCidades += ", ";

                strCidades += DbTransformar(cidade.Código);
            }

            string cmd = "SELECT p.*, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo, endereco e"
                + " WHERE e.localidade IN (" + strCidades + ")"
                + " AND e.pessoa = p.codigo "
                + " GROUP BY p.codigo ";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterPessoasPorEstado(Endereço.Estado[] estados)
        {
            string strEstados = "";

            if (estados.Length == 0)
                return new List<Pessoa>();

            foreach (Endereço.Estado estado in estados)
            {
                if (strEstados.Length > 0)
                    strEstados += ", ";

                strEstados += DbTransformar(estado.Código);
            }

            string cmd = "SELECT p.*, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo, endereco e, localidade l"
                + " WHERE e.pessoa = p.codigo AND l.estado IN (" + strEstados + ")"
                + " AND l.codigo = e.localidade";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterVendedores(string chave, int limite)
        {
            List<Pessoa> lista;
            List<Pessoa> funcionários;
            Representante[] representantes;

            funcionários = Funcionário.ObterFuncionários(chave, limite);
            representantes = Representante.ObterRepresentantes(chave, limite);
            lista = new List<Pessoa>(funcionários.Count + representantes.Length);

            lista.AddRange(funcionários);
            lista.AddRange(representantes);
            lista.Sort();

            if (lista.Count > limite)
                lista.RemoveRange(limite, lista.Count - limite);

            return lista;
        }

        public static IList<Pessoa> ObterVendedores()
        {
            string cmd = "SELECT p.*, pf.*, f.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join funcionario f on pf.codigo=f.codigo "
            + " WHERE p.codigo in (select vendedor from venda) and f.dataSaida is null ";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        public static implicit operator Pessoa(long código)
        {
            return (Pessoa) CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        public static implicit operator Pessoa(ulong código)
        {
            return (Pessoa )CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        public static implicit operator Pessoa(uint código)
        {
            return (Pessoa )CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        public static implicit operator Pessoa(int código)
        {
            return (Pessoa) CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        public override string ToString()
        {
            return nome + " (cód " + Código.ToString() + ")";
        }

        public static ArrayList ExtrairNomes(string nome)
        {

            ArrayList nomes = new ArrayList(5);
            string tmpNome = "";

            foreach (char c in nome)
            {
                if (c == ' ' || c == '-')
                {
                    if (tmpNome.Length > 0)
                        nomes.Add(tmpNome);

                    tmpNome = "";
                }
                else
                    tmpNome += c;
            }

            if (tmpNome.Length > 0)
                nomes.Add(tmpNome);

            return nomes;
        }

        public static void AbreviarNomes(System.Data.DataSet dataSet, int coluna)
        {
            foreach (DataRow linha in dataSet.Tables[0].Rows)
                linha[coluna] = AbreviarNome((string)linha[coluna]);
        }

        public static String AbreviarNome(string nome)
        {
            return Abreviador.AbreviarÚltimoNome(nome);
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            dataRegistro = dataAlteração = DadosGlobais.Instância.HoraDataAtual;

            bool códigoAutomático = Código == 0;

            cmd.CommandText = "INSERT INTO pessoa (" +
                            (códigoAutomático ? "" : "codigo, ") +
                            "nome, setor, " +
                            "email, observacoes, ultimaVisita, classificacoes, " +
                            "dataRegistro, dataAlteracao, " +
                            "maiorVenda, credito, regiao) " +
                            "VALUES (" +
                            (códigoAutomático ? "" : DbTransformar(Código) + ", ") +
                            DbTransformar(this.Nome) + ", " +
                            (this.setor != null ? DbTransformar(this.Setor.Código) : "NULL") + ", " +
                            DbTransformar(this.email) + ", " +
                            DbTransformar(this.observações) + ", " +
                            DbTransformar(this.últimaVisita) + ", " +
                            DbTransformar(this.classificações) + ", " +
                            "NOW(), " +
                            "NOW(), " +
                            DbTransformar(this.maiorVenda) + ", " +
                            DbTransformar(this.crédito) + ", " +
                            (this.região != null ? DbTransformar(this.região.Código) : DbTransformar((string)null)) + ")";

            cmd.ExecuteNonQuery();

            if (códigoAutomático)
                this.codigo = Convert.ToUInt64(ObterÚltimoCódigoInserido(cmd.Connection));

            if (endereços != null)
            {
                VerificarEndereços();
                CadastrarEntidade(cmd, endereços);
            }

            if (telefones != null)
                CadastrarEntidade(cmd, telefones);

            if (datasRelevantes != null)
                CadastrarEntidade(cmd, datasRelevantes);

        }

        public override bool Atualizado
        {
            get
            {
                return base.Atualizado && estadoFoto != EstadoFoto.Desatualizada;
            }
        }

        public virtual PessoaExpostaPoliticamente PessoaExpostaPoliticamente => null;

        protected override void Atualizar(IDbCommand cmd)
        {
            dataAlteração = DadosGlobais.Instância.HoraDataAtual;

            cmd.CommandText = "UPDATE pessoa SET" +
                " nome = " + DbTransformar(this.nome) + ", " +
                " setor = " + (this.Setor != null ? DbTransformar(this.Setor.Código) : "NULL") + ", " +
                " email = " + DbTransformar(this.email) + ", " +
                " observacoes = " + DbTransformar(this.observações) + ", " +
                " ultimaVisita = " + DbTransformar(this.últimaVisita) + ", " +
                " classificacoes = " + DbTransformar(this.classificações) + ", " +
                " dataAlteracao = NOW(), " +
                " maiorVenda = " + DbTransformar(this.maiorVenda) + ", " +
                " credito = " + DbTransformar(this.crédito) + ", " +
                " regiao = " + (this.região != null ? DbTransformar(this.região.Código) : DbTransformar((string)null)) +
                " WHERE codigo = " + DbTransformar(this.codigo);

            cmd.ExecuteNonQuery();

            if (endereços != null)
            {
                VerificarEndereços();
                AtualizarEntidade(cmd, endereços);
            }

            if (telefones != null)
                AtualizarEntidade(cmd, telefones);

            if (datasRelevantes != null)
                AtualizarEntidade(cmd, datasRelevantes);
        }

        public void AtualizarÚltimaVisita(IDbCommand cmd, DateTime entrada)
        {
            if (!Cadastrado)
                throw new Acesso.Comum.Exceções.EntidadeNãoCadastrada(this);

            últimaVisita = entrada;

            cmd.CommandText = "UPDATE pessoa SET ultimaVisita = " + DbTransformar(entrada)
                + " WHERE codigo = " + DbTransformar(codigo);

            cmd.ExecuteNonQuery();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            double dívida;

            if (Dívida.ObterVendasNãoQuitadas(this, out dívida).Length > 0)
                throw new ExceçãoClientePossuiPendências(this, "Existe vendas não quitadas.");

            if (Acerto.AcertoConsignado.ObterAcertosPendentes(this).Length > 0)
                throw new ExceçãoClientePossuiPendências(this, "Existem acertos pendentes.");

            DescadastrarEntidade(cmd, Endereços);
            DescadastrarEntidade(cmd, Telefones);
            DescadastrarEntidade(cmd, DatasRelevantes);

            cmd.CommandText = "DELETE FROM pessoa WHERE codigo = " + DbTransformar(codigo);
            cmd.ExecuteNonQuery();
        }

        public void AtualizarClassificação()
        {
            if (Cadastrado)
            {
                IDbConnection conexão = Conexão;

                lock (conexão)
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE pessoa SET classificacoes = "
                            + DbTransformar(classificações)
                            + " WHERE codigo = "
                            + DbTransformar(codigo);

                        cmd.ExecuteNonQuery();
                    }
            }
        }

        private void CarregarEndereços()
        {
            endereços = new DbComposição<Entidades.Pessoa.Endereço.Endereço>();

            if (Cadastrado)
                endereços.AdicionarJáCadastrado(Endereço.Endereço.ObterEndereços(this));
        }

        public static void CarregarEndereços(List<Pessoa> pessoas)
        {
            Dictionary<ulong, DbComposição<Endereço.Endereço>> hashEndereços =
                Endereço.Endereço.ObterEndereços(pessoas);

            AtribuiEndereçosÀsPessoas(pessoas, hashEndereços);
        }

        private static void AtribuiEndereçosÀsPessoas(List<Pessoa> pessoas, Dictionary<ulong, DbComposição<Endereço.Endereço>> hashEndereços)
        {
            foreach (Pessoa p in pessoas)
            {
                DbComposição<Endereço.Endereço> endereços = null;

                if (!hashEndereços.TryGetValue(p.Código, out endereços))
                    endereços = new DbComposição<Endereço.Endereço>();

                p.endereços = endereços;
            }
        }

        private void CarregarTelefones()
        {
            AdicionarJáCadastrado(Telefone.ObterTelefones(this));
        }

        public void AdicionarJáCadastrado(Telefone[] tels)
        {
            telefones = new DbComposição<Telefone>();

            if (Cadastrado)
                telefones.AdicionarJáCadastrado(tels);
        }

        public override bool Equals(object obj)
        {
            if (obj is Pessoa)
            {
                Pessoa outro = (Pessoa)obj;

                if (outro.Cadastrado && this.Cadastrado)
                    return outro.Código == this.Código;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Código.GetHashCode();
        }

        /// <summary>
        /// Codifica um valor seguindo o mapeamento:
        /// TUDO VAI BEX
        /// 1234 567 890
        /// 
        /// Esta codificação é utilizada pelos viajantes
        /// por questões de privacidade, constando no campo
        /// "Nosso Número".
        /// </summary>
        /// <param name="crédito">Valor a ser codificado.</param>
        /// <returns>Codificação para valor.</returns>
        public static string CodificarValor(double? valor)
        {
            if (!valor.HasValue)
                return " ";
            else
            {
                char[] mapa = new char[] {
                    'X',
                    'T', 'U', 'D', 'O',
                    'V', 'A', 'I',
                    'B', 'E' };
                string codificação = "";
                long aux = (long)Math.Truncate(valor.Value);

                if (aux >= 1)
                    do
                    {
                        codificação = mapa[aux % 10] + codificação;
                        aux /= 10;
                    } while (aux > 0);
                else
                    codificação = mapa[0].ToString();

                return codificação;
            }
        }

        private void VerificarEndereços()
        {
            List<Endereço.Endereço> lista = endereços.ExtrairElementos();

            for (int i = 0; i < lista.Count; i++)
            {
                Endereço.Endereço endereço = lista[i];

                if (endereço.Localidade != null && !endereço.Localidade.Cadastrado)
                    for (int j = i + 1; j < lista.Count; j++)
                    {
                        Endereço.Endereço aux = lista[j];

                        if (aux.Localidade != null &&
                            aux.Localidade.Nome == endereço.Localidade.Nome &&
                            aux.Localidade.Estado != null &&
                            endereço.Localidade.Estado != null &&
                            aux.Localidade.Estado.Nome == endereço.Localidade.Estado.Nome &&
                            aux.Localidade.Estado.País != null &&
                            endereço.Localidade.Estado.País != null &&
                            aux.Localidade.Estado.País.Nome == aux.Localidade.Estado.País.Nome)
                        {
                            endereço.Localidade = aux.Localidade;
                        }
                    }
            }
        }

        DateTime últimoRegistro = DateTime.MinValue;

        public void RegistrarHistórico(string texto)
        {
            TimeSpan diff = (DateTime.Now - últimoRegistro);

            if (diff < TimeSpan.FromSeconds(1))
            {
                System.Threading.Thread.Sleep(1000 - (int) diff.TotalMilliseconds);
            }

            Histórico item = new Histórico();

            item.Pessoa = this;
            item.Texto = texto;
            item.Cadastrar();

            últimoRegistro = DateTime.Now;
        }

        public override bool Referente(DbManipulação entidade)
        {
            if (entidade is Pessoa)
                return ((Pessoa)entidade).Código == this.Código;

            return false;
        }

        public static bool ÉCliente(Pessoa pessoa)
        {
            if (Funcionário.ÉFuncionário(pessoa))
                return false;

            return !Representante.ÉRepresentante(pessoa);
        }

        protected virtual void LerAtributos(IDataReader leitor, int inicioAtributo)
        {
            codigo = (ulong)leitor.GetInt64(inicioAtributo);

            nome = leitor.GetString(inicioAtributo + 1);

            if (!leitor.IsDBNull(inicioAtributo + 2))
                setor = Setor.ObterSetor((uint)leitor.GetInt16(inicioAtributo + 2));

            if (leitor[inicioAtributo + 3] != DBNull.Value)
                email = leitor.GetString(inicioAtributo + 3);

            if (leitor[inicioAtributo + 4] != DBNull.Value)
                observações = leitor.GetString(inicioAtributo + 4);

            if (leitor[inicioAtributo + 5] != DBNull.Value)
                últimaVisita = leitor.GetDateTime(inicioAtributo + 5);

            if (leitor[inicioAtributo + 6] != DBNull.Value)
                dataRegistro = leitor.GetDateTime(inicioAtributo + 6);

            if (leitor[inicioAtributo + 7] != DBNull.Value)
                dataAlteração = leitor.GetDateTime(inicioAtributo + 7);

            classificações = (ulong)leitor.GetInt64(inicioAtributo + 8);

            if (leitor[inicioAtributo + 9] != DBNull.Value)
                maiorVenda = leitor.GetDouble(inicioAtributo + 9);

            if (leitor[inicioAtributo + 10] != DBNull.Value)
                crédito = leitor.GetDouble(inicioAtributo + 10);

            if (leitor[inicioAtributo + 11] != DBNull.Value)
                região = Região.ObterRegião((uint)leitor[inicioAtributo + 11]);

        }

        public static int TrocarRegião(List<Pessoa> pessoas, Endereço.Região região)
        {
            IDbConnection conexão;
            IDbCommand cmd;

            List<ulong> códigos = new List<ulong>();
            foreach (Pessoa p in pessoas)
                códigos.Add(p.Código);

            int linhasAlteradas;
            ExecutaSqlTrocaRegião(região, out conexão, out cmd, códigos, out linhasAlteradas);

            return linhasAlteradas;
        }

        private static void ExecutaSqlTrocaRegião(Região região, out IDbConnection conexão, out IDbCommand cmd, List<ulong> códigos, out int linhasAlteradas)
        {
            conexão = Conexão;
            linhasAlteradas = 0;
            lock (conexão)
            {
                using (cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "update pessoa set regiao = " + DbTransformar(região.Código) +
                        " WHERE codigo in " + DbTransformarConjunto(códigos);

                    linhasAlteradas = cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Pessoa> ObterPessoasComissionadas()
        {
            DateTime? dia = null;

            StringBuilder cmd = new StringBuilder("SELECT cp.*, pf.*, pj.* ");

            cmd.Append(" from comissao_valor c join pessoa cp on c.comissaopara=cp.codigo ");
            cmd.Append(" left join pessoafisica pf on cp.codigo=pf.codigo ");
            cmd.Append(" left join pessoajuridica pj on cp.codigo=pj.codigo ");

            cmd.Append(" join venda v on c.venda=v.codigo");

            cmd.Append(" WHERE 1=1 ");
            if (dia != null)
            {
                cmd.Append(" AND v.data like '");
                cmd.Append(dia.Value.ToString("yyyy-MM-dd"));
                cmd.Append("%' ");
            }

            cmd.Append(" group by cp.codigo order by cp.nome");

            return RealizarConsulta(cmd.ToString(), 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterPessoasNaComissão(int códigoComissão)
        {
            StringBuilder cmd = new StringBuilder("SELECT cp.*, pf.*, pj.* ");
            cmd.Append(" from vinculocomissaopessoa v join pessoa cp ");
            cmd.Append(" ON v.comissao=");
            cmd.Append(códigoComissão);
            cmd.Append(" AND v.pessoa=cp.codigo ");
            cmd.Append(" left join pessoafisica pf on cp.codigo=pf.codigo ");
            cmd.Append(" left join pessoajuridica pj on cp.codigo=pj.codigo ");
            cmd.Append(" join comissao_valor cv on cv.comissaopara=cp.codigo ");
            cmd.Append(" group by cp.codigo ");


            return RealizarConsulta(cmd.ToString(), 0, Pessoa.TotalAtributos);
        }

        public bool PossuiAlgumEndereçoInválido()
        {
            foreach (Endereço.Endereço e in endereços)
            {
                if (e.Inválido)
                    return true;
            }
         
            return false;
        }

        public static bool CódigoNovaPessoaVálido(ulong código)
        {
            bool respeitaLimite = código < 999999;
            bool códigoEmUso = ObterPessoa(código) != null;

            return respeitaLimite && !códigoEmUso;
        }

        public static string LimparCaracteresNãoNuméricos(string entrada)
        {
            return Regex.Replace(entrada, @"[^\d]", "");
        }
    }
}
