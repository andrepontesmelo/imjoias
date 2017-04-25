using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Configura��o;
using Entidades.Controle;
using Entidades.Pessoa.Endere�o;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades.Coaf;
using System.Text.RegularExpressions;

namespace Entidades.Pessoa
{
    [Serializable, DbTransa��o, Cache�vel("ObterPessoaSemCache"), N�oCopiarCache]
    public class Pessoa : DbManipula��o, IComparable
    {
        public static readonly int TotalAtributos = 12;

        protected ulong codigo;
        protected string nome;
        protected DbComposi��o<Endere�o.Endere�o> endere�os;
        protected DbComposi��o<Telefone> telefones;
        protected string email;

        [DbColuna("observacoes")]
        protected string observa��es;

        protected DbFoto foto;

        [DbColuna("classificacoes")]
        protected ulong classifica��es;

        protected DateTime? dataRegistro;

        [DbColuna("dataAlteracao")]
        protected DateTime? dataAltera��o;

        [DbColuna("ultimaVisita")]
        protected DateTime? �ltimaVisita;

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

        protected DbComposi��o<DataRelevante> datasRelevantes;

        protected double? maiorVenda;

        [DbColuna("credito")]
        protected double? cr�dito;

        [DbRelacionamento("c�digo", "regiao"), DbColuna("regiao")]
        protected Regi�o regi�o;

        public ulong C�digo
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

        public string Observa��es
        {
            get { return observa��es; }
            set
            {
                observa��es = value;
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

            if (PessoaF�sica.ValidarCPF(cpfCnpj))
                return PessoaF�sica.Formatar(cpfCnpj);

            if (PessoaJur�dica.ValidarCNPJ(cpfCnpj))
                return PessoaJur�dica.FormatarCNPJ(cpfCnpj);

            return cpfCnpj;
        }


        public ulong Classifica��es
        {
            get { return classifica��es; }
            set { classifica��es = value; DefinirDesatualizado(); }
        }

        public DateTime? DataRegistro => dataRegistro; 

        public DateTime? DataAltera��o => dataAltera��o; 

        public DateTime? �ltimaVisita
        {
            get { return �ltimaVisita; }
            set { �ltimaVisita = value; DefinirDesatualizado(); }
        }

        public DbComposi��o<Endere�o.Endere�o> Endere�os
        {
            get
            {
                if (endere�os == null)
                    CarregarEndere�os();

                return endere�os;
            }
        }

        public DbComposi��o<Telefone> Telefones
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

        public DbComposi��o<DataRelevante> DatasRelevantes
        {
            get
            {
                if (datasRelevantes == null)
                    datasRelevantes = new DbComposi��o<DataRelevante>(
                        DataRelevante.ObterDatasRelevantes(this));

                return datasRelevantes;
            }
        }

        public double? MaiorVenda
        {
            get { return maiorVenda; }
            set { maiorVenda = value; }
        }

        public double? Cr�dito
        {
            get { return cr�dito; }
            set { cr�dito = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Codifica��o:
        /// MMYYYYxxxxCC
        /// 
        /// MM = m�s da primeira compra
        /// YYYY = ano da primeira compra
        /// xxxx = maior compra
        /// CC = cr�dito
        /// </summary>
        public string NossoN�mero
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

                if (cr�dito.HasValue)
                    nn += String.Format("{0:##00}",
                        Math.Truncate(this.cr�dito.Value / 1000));

                return nn;
            }
        }

        public Regi�o Regi�o
        {
            get { return regi�o; }
            set { regi�o = value; DefinirDesatualizado(); }
        }

        public Pessoa()
        {
            if (DadosGlobais.Inst�ncia.Conectado)
            {
                dataRegistro = DadosGlobais.Inst�ncia.HoraDataAtual;
                dataAltera��o = DadosGlobais.Inst�ncia.HoraDataAtual;
            }
        }

        public Pessoa(ulong c�digo)
        {
            this.codigo = c�digo;
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
            IDbConnection conex�o;
            ArrayList dados = new ArrayList(limite);
            conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                try
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        IDataReader leitor = null;

                        string tmpNome = InserirNomeBase(nomeBase, limite, dados, cmd, ref leitor);
                        leitor = PesquisarDemaisNomes(nomeBase, limite, dados, cmd, leitor);
                    }

                }
                finally
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
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

        public static Pessoa ObterPessoa(ulong c�digo)
        {
            return (Pessoa) CacheDb.Inst�ncia.ObterEntidade(typeof(Pessoa), c�digo);
        }

        public static Pessoa ObterPessoa(IDataReader leitor, int inicioPessoa, int inicioPessoaFisica, int inicioPessoaJuridica)
        {
            if (!leitor.IsDBNull(inicioPessoaFisica))
            {
                return PessoaF�sica.Obter(leitor, inicioPessoa, inicioPessoaFisica);
            }
            else
            {
                return PessoaJur�dica.Obter(leitor, inicioPessoa, inicioPessoaJuridica);
            }
        }

        public static Pessoa ObterPessoaSemCache(ulong c�digo)
        {
            IDbConnection conex�o = Conex�o;
            IDataReader leitor = null;
            Pessoa p = null;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "SELECT * FROM pessoa left join pessoafisica on pessoa.codigo=pessoafisica.codigo left " + 
                            " join pessoajuridica pj on pessoa.codigo=pj.codigo WHERE pessoa.codigo = "
                            + DbTransformar(c�digo);

                        using (leitor = cmd.ExecuteReader())
                        {
                            if (leitor.Read())
                                p = (Pessoa.ObterPessoa(leitor, 0, TotalAtributos, TotalAtributos + PessoaF�sica.TotalAtributos));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }

            return p;
        }

        public static List<Pessoa> ObterPessoas()
        {
            IDataReader leitor = null;
            List<Pessoa> dados = new List<Pessoa>();
            IDbConnection conex�o = Conex�o;
            StringBuilder comando = new StringBuilder();

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.regiao, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo ";
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                                dados.Add(Pessoa.ObterPessoa(leitor, 0, TotalAtributos, TotalAtributos + PessoaF�sica.TotalAtributos));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }

                CarregarEndere�os(dados);

                return dados;
            }
        }

        public static List<Pessoa> ObterPessoas(Regi�o regi�o)
        {
            return RealizarConsulta(
                "SELECT * FROM pessoa p LEFT JOIN pessoafisica pf ON p.codigo = pf.codigo" +
                " WHERE p.regiao = " + DbTransformar(regi�o.C�digo), 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterPessoas(Classifica��o classifica��o)
        {
            return RealizarConsulta(
                "SELECT * FROM pessoa p LEFT JOIN pessoafisica pf ON p.codigo = pf.codigo" +
                " WHERE classificacoes & 1 << ( " + classifica��o.C�digo.ToString() + " - 1) > 0", 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterPessoas(Entidades.Setor setor)
        {
            List<Pessoa> pessoas;

            if (setor == null)
                throw new ArgumentNullException("setor");

            if (!setor.Cadastrado)
                throw new ArgumentException("Setor n�o cadastrado.", "setor");

            string cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE"
                + " pessoa.setor = " + DbTransformar(setor.C�digo);

            pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            return pessoas;
        }

        public static Dictionary<ulong, Pessoa> ObterPessoas(SortedSet<ulong> c�digos)
        {
            if (c�digos.Count == 0)
                return new Dictionary<ulong, Pessoa>();

            string cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE"
                + " pessoa.codigo in " + DbTransformarConjunto(c�digos);

            List<Pessoa> pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            Dictionary<ulong, Pessoa> hash = new Dictionary<ulong, Pessoa>();
            foreach (Pessoa p in pessoas)
            {
                hash[p.C�digo] = p;
            }

            return hash;
        }

        public static List<Pessoa> ObterPessoas(Entidades.Setor setor, DateTime in�cio, DateTime final)
        {
            List<Pessoa> pessoas;
            string cmd;

            if (setor == null)
                throw new ArgumentNullException("setor");

            if (!setor.Cadastrado)
                throw new ArgumentException("Setor n�o cadastrado.", "setor");

            if (in�cio >= final)
                throw new ArgumentException("Per�odo incorreto.");

            cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE"
                + " pessoa.setor = " + DbTransformar(setor.C�digo)
                + " AND pessoa.ultimaVisita BETWEEN " + DbTransformar(in�cio)
                + " AND " + DbTransformar(final);

            pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            return pessoas;
        }

        public static List<Pessoa> ObterPessoasPorRegi�o(Entidades.Pessoa.Endere�o.Regi�o regi�o)
        {
            List<Pessoa> pessoas;
            string cmd;

            cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE regiao = " + DbTransformar(regi�o.C�digo);

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

        public static string ObterC�digoPessoas(HashSet<Pessoa> pessoas)
        {
            String retorno;
            StringBuilder c�digoPessoas = new StringBuilder("(");
            bool primeiro = true;
            foreach (Pessoa p in pessoas)
            {
                if (!primeiro)
                    c�digoPessoas.Append(", ");
                c�digoPessoas.Append(p.C�digo);

                primeiro = false;
            }
            c�digoPessoas.Append(") ");
            retorno = c�digoPessoas.ToString();

            return retorno;
        }

        private static List<Pessoa> RealizarConsulta(string consulta, int in�cioPessoa, int in�cioPessoaF�sica)
        {
            IDbConnection conexao = Conex�o;
            IDataReader leitor = null;
            List<Pessoa> lista = new List<Pessoa>();

            lock (conexao)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conexao);
                using (IDbCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = consulta;
                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                                lista.Add(Pessoa.ObterPessoa(leitor, in�cioPessoa, in�cioPessoaF�sica, 0));
                        }
                    }
                    finally
                    {
                        if (leitor != null)
                            leitor.Close();
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conexao);
                    }
                }
            }

            return lista;
        }


        public static Pessoa ObterConsumidorFinal()
        {
            return Mapear�nicaLinha<Pessoa>(
                "SELECT * FROM pessoa WHERE nome LIKE 'Consumidor Final'");
        }

        public static List<Pessoa> ObterPessoasPorCidade(Endere�o.Localidade[] cidades)
        {
            if (cidades.Length == 0)
                return new List<Pessoa>();

            string strCidades = "";

            foreach (Endere�o.Localidade cidade in cidades)
            {
                if (strCidades.Length > 0)
                    strCidades += ", ";

                strCidades += DbTransformar(cidade.C�digo);
            }

            string cmd = "SELECT p.*, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo, endereco e"
                + " WHERE e.localidade IN (" + strCidades + ")"
                + " AND e.pessoa = p.codigo "
                + " GROUP BY p.codigo ";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterPessoasPorEstado(Endere�o.Estado[] estados)
        {
            string strEstados = "";

            if (estados.Length == 0)
                return new List<Pessoa>();

            foreach (Endere�o.Estado estado in estados)
            {
                if (strEstados.Length > 0)
                    strEstados += ", ";

                strEstados += DbTransformar(estado.C�digo);
            }

            string cmd = "SELECT p.*, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo, endereco e, localidade l"
                + " WHERE e.pessoa = p.codigo AND l.estado IN (" + strEstados + ")"
                + " AND l.codigo = e.localidade";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        public static List<Pessoa> ObterVendedores(string chave, int limite)
        {
            List<Pessoa> lista;
            List<Pessoa> funcion�rios;
            Representante[] representantes;

            funcion�rios = Funcion�rio.ObterFuncion�rios(chave, limite);
            representantes = Representante.ObterRepresentantes(chave, limite);
            lista = new List<Pessoa>(funcion�rios.Count + representantes.Length);

            lista.AddRange(funcion�rios);
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

        public static implicit operator Pessoa(long c�digo)
        {
            return (Pessoa) CacheDb.Inst�ncia.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(c�digo));
        }

        public static implicit operator Pessoa(ulong c�digo)
        {
            return (Pessoa )CacheDb.Inst�ncia.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(c�digo));
        }

        public static implicit operator Pessoa(uint c�digo)
        {
            return (Pessoa )CacheDb.Inst�ncia.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(c�digo));
        }

        public static implicit operator Pessoa(int c�digo)
        {
            return (Pessoa) CacheDb.Inst�ncia.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(c�digo));
        }

        public override string ToString()
        {
            return nome + " (c�d " + C�digo.ToString() + ")";
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
            return Abreviador.Abreviar�ltimoNome(nome);
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            dataRegistro = dataAltera��o = DadosGlobais.Inst�ncia.HoraDataAtual;

            bool c�digoAutom�tico = C�digo == 0;

            cmd.CommandText = "INSERT INTO pessoa (" +
                            (c�digoAutom�tico ? "" : "codigo, ") +
                            "nome, setor, " +
                            "email, observacoes, ultimaVisita, classificacoes, " +
                            "dataRegistro, dataAlteracao, " +
                            "maiorVenda, credito, regiao) " +
                            "VALUES (" +
                            (c�digoAutom�tico ? "" : DbTransformar(C�digo) + ", ") +
                            DbTransformar(this.Nome) + ", " +
                            (this.setor != null ? DbTransformar(this.Setor.C�digo) : "NULL") + ", " +
                            DbTransformar(this.email) + ", " +
                            DbTransformar(this.observa��es) + ", " +
                            DbTransformar(this.�ltimaVisita) + ", " +
                            DbTransformar(this.classifica��es) + ", " +
                            "NOW(), " +
                            "NOW(), " +
                            DbTransformar(this.maiorVenda) + ", " +
                            DbTransformar(this.cr�dito) + ", " +
                            (this.regi�o != null ? DbTransformar(this.regi�o.C�digo) : DbTransformar((string)null)) + ")";

            cmd.ExecuteNonQuery();

            if (c�digoAutom�tico)
                this.codigo = Convert.ToUInt64(Obter�ltimoC�digoInserido(cmd.Connection));

            if (endere�os != null)
            {
                VerificarEndere�os();
                CadastrarEntidade(cmd, endere�os);
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
            dataAltera��o = DadosGlobais.Inst�ncia.HoraDataAtual;

            cmd.CommandText = "UPDATE pessoa SET" +
                " nome = " + DbTransformar(this.nome) + ", " +
                " setor = " + (this.Setor != null ? DbTransformar(this.Setor.C�digo) : "NULL") + ", " +
                " email = " + DbTransformar(this.email) + ", " +
                " observacoes = " + DbTransformar(this.observa��es) + ", " +
                " ultimaVisita = " + DbTransformar(this.�ltimaVisita) + ", " +
                " classificacoes = " + DbTransformar(this.classifica��es) + ", " +
                " dataAlteracao = NOW(), " +
                " maiorVenda = " + DbTransformar(this.maiorVenda) + ", " +
                " credito = " + DbTransformar(this.cr�dito) + ", " +
                " regiao = " + (this.regi�o != null ? DbTransformar(this.regi�o.C�digo) : DbTransformar((string)null)) +
                " WHERE codigo = " + DbTransformar(this.codigo);

            cmd.ExecuteNonQuery();

            if (endere�os != null)
            {
                VerificarEndere�os();
                AtualizarEntidade(cmd, endere�os);
            }

            if (telefones != null)
                AtualizarEntidade(cmd, telefones);

            if (datasRelevantes != null)
                AtualizarEntidade(cmd, datasRelevantes);
        }

        public void Atualizar�ltimaVisita(IDbCommand cmd, DateTime entrada)
        {
            if (!Cadastrado)
                throw new Acesso.Comum.Exce��es.EntidadeN�oCadastrada(this);

            �ltimaVisita = entrada;

            cmd.CommandText = "UPDATE pessoa SET ultimaVisita = " + DbTransformar(entrada)
                + " WHERE codigo = " + DbTransformar(codigo);

            cmd.ExecuteNonQuery();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            double d�vida;

            if (D�vida.ObterVendasN�oQuitadas(this, out d�vida).Length > 0)
                throw new Exce��oClientePossuiPend�ncias(this, "Existe vendas n�o quitadas.");

            if (Acerto.AcertoConsignado.ObterAcertosPendentes(this).Length > 0)
                throw new Exce��oClientePossuiPend�ncias(this, "Existem acertos pendentes.");

            DescadastrarEntidade(cmd, Endere�os);
            DescadastrarEntidade(cmd, Telefones);
            DescadastrarEntidade(cmd, DatasRelevantes);

            cmd.CommandText = "DELETE FROM pessoa WHERE codigo = " + DbTransformar(codigo);
            cmd.ExecuteNonQuery();
        }

        public void AtualizarClassifica��o()
        {
            if (Cadastrado)
            {
                IDbConnection conex�o = Conex�o;

                lock (conex�o)
                    using (IDbCommand cmd = conex�o.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE pessoa SET classificacoes = "
                            + DbTransformar(classifica��es)
                            + " WHERE codigo = "
                            + DbTransformar(codigo);

                        cmd.ExecuteNonQuery();
                    }
            }
        }

        private void CarregarEndere�os()
        {
            endere�os = new DbComposi��o<Entidades.Pessoa.Endere�o.Endere�o>();

            if (Cadastrado)
                endere�os.AdicionarJ�Cadastrado(Endere�o.Endere�o.ObterEndere�os(this));
        }

        public static void CarregarEndere�os(List<Pessoa> pessoas)
        {
            Dictionary<ulong, DbComposi��o<Endere�o.Endere�o>> hashEndere�os =
                Endere�o.Endere�o.ObterEndere�os(pessoas);

            AtribuiEndere�os�sPessoas(pessoas, hashEndere�os);
        }

        private static void AtribuiEndere�os�sPessoas(List<Pessoa> pessoas, Dictionary<ulong, DbComposi��o<Endere�o.Endere�o>> hashEndere�os)
        {
            foreach (Pessoa p in pessoas)
            {
                DbComposi��o<Endere�o.Endere�o> endere�os = null;

                if (!hashEndere�os.TryGetValue(p.C�digo, out endere�os))
                    endere�os = new DbComposi��o<Endere�o.Endere�o>();

                p.endere�os = endere�os;
            }
        }

        private void CarregarTelefones()
        {
            AdicionarJ�Cadastrado(Telefone.ObterTelefones(this));
        }

        public void AdicionarJ�Cadastrado(Telefone[] tels)
        {
            telefones = new DbComposi��o<Telefone>();

            if (Cadastrado)
                telefones.AdicionarJ�Cadastrado(tels);
        }

        public override bool Equals(object obj)
        {
            if (obj is Pessoa)
            {
                Pessoa outro = (Pessoa)obj;

                if (outro.Cadastrado && this.Cadastrado)
                    return outro.C�digo == this.C�digo;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return C�digo.GetHashCode();
        }

        /// <summary>
        /// Codifica um valor seguindo o mapeamento:
        /// TUDO VAI BEX
        /// 1234 567 890
        /// 
        /// Esta codifica��o � utilizada pelos viajantes
        /// por quest�es de privacidade, constando no campo
        /// "Nosso N�mero".
        /// </summary>
        /// <param name="cr�dito">Valor a ser codificado.</param>
        /// <returns>Codifica��o para valor.</returns>
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
                string codifica��o = "";
                long aux = (long)Math.Truncate(valor.Value);

                if (aux >= 1)
                    do
                    {
                        codifica��o = mapa[aux % 10] + codifica��o;
                        aux /= 10;
                    } while (aux > 0);
                else
                    codifica��o = mapa[0].ToString();

                return codifica��o;
            }
        }

        private void VerificarEndere�os()
        {
            List<Endere�o.Endere�o> lista = endere�os.ExtrairElementos();

            for (int i = 0; i < lista.Count; i++)
            {
                Endere�o.Endere�o endere�o = lista[i];

                if (endere�o.Localidade != null && !endere�o.Localidade.Cadastrado)
                    for (int j = i + 1; j < lista.Count; j++)
                    {
                        Endere�o.Endere�o aux = lista[j];

                        if (aux.Localidade != null &&
                            aux.Localidade.Nome == endere�o.Localidade.Nome &&
                            aux.Localidade.Estado != null &&
                            endere�o.Localidade.Estado != null &&
                            aux.Localidade.Estado.Nome == endere�o.Localidade.Estado.Nome &&
                            aux.Localidade.Estado.Pa�s != null &&
                            endere�o.Localidade.Estado.Pa�s != null &&
                            aux.Localidade.Estado.Pa�s.Nome == aux.Localidade.Estado.Pa�s.Nome)
                        {
                            endere�o.Localidade = aux.Localidade;
                        }
                    }
            }
        }

        DateTime �ltimoRegistro = DateTime.MinValue;

        public void RegistrarHist�rico(string texto)
        {
            TimeSpan diff = (DateTime.Now - �ltimoRegistro);

            if (diff < TimeSpan.FromSeconds(1))
            {
                System.Threading.Thread.Sleep(1000 - (int) diff.TotalMilliseconds);
            }

            Hist�rico item = new Hist�rico();

            item.Pessoa = this;
            item.Texto = texto;
            item.Cadastrar();

            �ltimoRegistro = DateTime.Now;
        }

        public override bool Referente(DbManipula��o entidade)
        {
            if (entidade is Pessoa)
                return ((Pessoa)entidade).C�digo == this.C�digo;

            return false;
        }

        public static bool �Cliente(Pessoa pessoa)
        {
            if (Funcion�rio.�Funcion�rio(pessoa))
                return false;

            return !Representante.�Representante(pessoa);
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
                observa��es = leitor.GetString(inicioAtributo + 4);

            if (leitor[inicioAtributo + 5] != DBNull.Value)
                �ltimaVisita = leitor.GetDateTime(inicioAtributo + 5);

            if (leitor[inicioAtributo + 6] != DBNull.Value)
                dataRegistro = leitor.GetDateTime(inicioAtributo + 6);

            if (leitor[inicioAtributo + 7] != DBNull.Value)
                dataAltera��o = leitor.GetDateTime(inicioAtributo + 7);

            classifica��es = (ulong)leitor.GetInt64(inicioAtributo + 8);

            if (leitor[inicioAtributo + 9] != DBNull.Value)
                maiorVenda = leitor.GetDouble(inicioAtributo + 9);

            if (leitor[inicioAtributo + 10] != DBNull.Value)
                cr�dito = leitor.GetDouble(inicioAtributo + 10);

            if (leitor[inicioAtributo + 11] != DBNull.Value)
                regi�o = Regi�o.ObterRegi�o((uint)leitor[inicioAtributo + 11]);

        }

        public static int TrocarRegi�o(List<Pessoa> pessoas, Endere�o.Regi�o regi�o)
        {
            IDbConnection conex�o;
            IDbCommand cmd;

            List<ulong> c�digos = new List<ulong>();
            foreach (Pessoa p in pessoas)
                c�digos.Add(p.C�digo);

            int linhasAlteradas;
            ExecutaSqlTrocaRegi�o(regi�o, out conex�o, out cmd, c�digos, out linhasAlteradas);

            return linhasAlteradas;
        }

        private static void ExecutaSqlTrocaRegi�o(Regi�o regi�o, out IDbConnection conex�o, out IDbCommand cmd, List<ulong> c�digos, out int linhasAlteradas)
        {
            conex�o = Conex�o;
            linhasAlteradas = 0;
            lock (conex�o)
            {
                using (cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "update pessoa set regiao = " + DbTransformar(regi�o.C�digo) +
                        " WHERE codigo in " + DbTransformarConjunto(c�digos);

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

        public static List<Pessoa> ObterPessoasNaComiss�o(int c�digoComiss�o)
        {
            StringBuilder cmd = new StringBuilder("SELECT cp.*, pf.*, pj.* ");
            cmd.Append(" from vinculocomissaopessoa v join pessoa cp ");
            cmd.Append(" ON v.comissao=");
            cmd.Append(c�digoComiss�o);
            cmd.Append(" AND v.pessoa=cp.codigo ");
            cmd.Append(" left join pessoafisica pf on cp.codigo=pf.codigo ");
            cmd.Append(" left join pessoajuridica pj on cp.codigo=pj.codigo ");
            cmd.Append(" join comissao_valor cv on cv.comissaopara=cp.codigo ");
            cmd.Append(" group by cp.codigo ");


            return RealizarConsulta(cmd.ToString(), 0, Pessoa.TotalAtributos);
        }

        public bool PossuiAlgumEndere�oInv�lido()
        {
            foreach (Endere�o.Endere�o e in endere�os)
            {
                if (e.Inv�lido)
                    return true;
            }
         
            return false;
        }

        public static bool C�digoNovaPessoaV�lido(ulong c�digo)
        {
            bool respeitaLimite = c�digo < 999999;
            bool c�digoEmUso = ObterPessoa(c�digo) != null;

            return respeitaLimite && !c�digoEmUso;
        }

        public static string LimparCaracteresN�oNum�ricos(string entrada)
        {
            return Regex.Replace(entrada, @"[^\d]", "");
        }
    }
}
