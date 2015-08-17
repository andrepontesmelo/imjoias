#define PERMITIR_IMPORTAÇÃO

using System;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Collections.Generic;
using Entidades.Configuração;
using Entidades.Pessoa.Endereço;
using Entidades.Controle;
using System.Text;

namespace Entidades.Pessoa
{
    /// <summary>
    /// Value-Object da tabela "PessoaFisica"
    /// </summary>
    /// <remarks>
    /// Os herdeiros desta classe deverão sobrescrever o seguinte método:
    /// protected virtual void CadastrarCascata(IDbCommand cmd)
    /// </remarks>
    [Serializable, DbTransação, Cacheável("ObterPessoaSemCache"), NãoCopiarCache]
    public class Pessoa : Acesso.Comum.DbManipulação, IComparable
    {
        public static readonly int LIMITE_PADRÃO_PESSOAS = 400;
        public static readonly int TotalAtributos = 13;

        #region Atributos

        /// <summary>
        /// Chave primária.
        /// </summary>
        protected ulong codigo;

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        protected string nome;

        /// <summary>
        /// Conjunto de endereços.
        /// </summary>
        protected DbComposição<Endereço.Endereço> endereços;

        /// <summary>
        /// Conjunto de telefones.
        /// </summary>
        protected DbComposição<Telefone> telefones;

        protected string email;

        [DbColuna("observacoes")]
        protected string observações;

        protected DbFoto foto;

        [DbColuna("classificacoes")]
        protected ulong classificações;

        protected DateTime? dataRegistro = DadosGlobais.Instância.HoraDataAtual;

        [DbColuna("dataAlteracao")]
        protected DateTime? dataAlteração = DadosGlobais.Instância.HoraDataAtual;

        [DbColuna("ultimaVisita")]
        protected DateTime? últimaVisita;

        /// <summary>
        /// Estado da foto em relação ao banco de dados.
        /// </summary>
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

        //protected DbComposição<RelacionamentoInterpessoal> relacionamentos;

        //[DbColuna("avaliacaoVolVarejo")]
        //protected byte? avaliaçãoVolVarejo;

        //[DbColuna("avaliacaoVolAtacado")]
        //protected byte? avaliaçãoVolAtacado;

        //[DbColuna("avaliacaoPagamento")]
        //protected byte? avaliaçãoPagamento;

        //[DbColuna("avaliacaoVendaConsignado")]
        //protected byte? avaliaçãoVendaConsignado;

        protected DbComposição<DataRelevante> datasRelevantes;

        protected double? maiorVenda;

        [DbColuna("credito")]
        protected double? crédito;

        protected bool fornecedor = false;

        [DbRelacionamento("código", "regiao"), DbColuna("regiao")]
        protected Região região;

        #endregion

        #region Propriedades

        #region Propriedades da tabela

        /// <summary>
        /// Obtem o código da pessoa
        /// </summary>
        public ulong Código
        {
            get { return codigo; }
#if PERMITIR_IMPORTAÇÃO
            set
            {
                if (!Cadastrado)
                    codigo = value;
                else
                    throw new NotSupportedException();
            }
#endif
        }

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
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

        /// <summary>
        /// Primeiro nome da pessoa.
        /// </summary>
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

        /// <summary>
        /// Observações sobre a pessoa.
        /// </summary>
        public string Observações
        {
            get { return observações; }
            set
            {
                observações = value;
                DefinirDesatualizado();
            }
        }

        /// <summary>
        /// E-Mail da pessoa.
        /// </summary>
        public string EMail
        {
            get { return email; }
            set
            {
                email = value;
                DefinirDesatualizado();
            }
        }


        ///// <summary>
        ///// Foto da pessoa.
        ///// </summary>
        //public Image Foto
        //{
        //    get
        //    {
        //        lock (this)
        //        {
        //            if (foto == null && estadoFoto == EstadoFoto.Desconhecido)
        //                ObterFoto();
        //        }

        //        return foto;
        //    }
        //    set
        //    {
        //        lock (this)
        //        {
        //            /* Necessário garantir que existe foto, para atribuir
        //             * informações de foto inexistente ou existente.
        //             */
        //            if (foto == null && estadoFoto == EstadoFoto.Desconhecido)
        //                ObterFoto();

        //            foto = value;
        //            estadoFoto |= EstadoFoto.Desatualizada;
        //        }
        //    }
        //}

        /// <summary>
        /// Flag de classificações para ser utilizado
        /// com a classe <c>Classificação</c>.
        /// </summary>
        public ulong Classificações
        {
            get { return classificações; }
            set { classificações = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Data de registro da pessoa.
        /// </summary>
        public DateTime? DataRegistro
        {
            get { return dataRegistro; }
#if PERMITIR_IMPORTAÇÃO
            set { dataRegistro = value; DefinirDesatualizado(); }
#endif
        }

        /// <summary>
        /// Data da última alteração.
        /// </summary>
        public DateTime? DataAlteração
        {
            get { return dataAlteração; }
        }

        public DateTime? ÚltimaVisita
        {
            get { return últimaVisita; }
            set { últimaVisita = value; DefinirDesatualizado(); }
        }

        /// <summary>
        /// Endereços da pessoa.
        /// </summary>
        public DbComposição<Endereço.Endereço> Endereços
        {
            get
            {
                if (endereços == null)
                    CarregarEndereços();

                return endereços;
            }
        }

        /// <summary>
        /// Telefones da pessoa.
        /// </summary>
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

        ///// <summary>
        ///// Lista de relacionamentos interpessoais.
        ///// </summary>
        //public DbComposição<RelacionamentoInterpessoal> Relacionamentos
        //{
        //    get
        //    {
        //        if (relacionamentos == null)
        //            relacionamentos = new DbComposição<RelacionamentoInterpessoal>(RelacionamentoInterpessoal.ObterRelacionamentos(this));

        //        return relacionamentos;
        //    }
        //}

        //public byte? AvaliaçãoVolVarejo
        //{
        //    get { return avaliaçãoVolVarejo; }
        //    set { avaliaçãoVolVarejo = value; DefinirDesatualizado(); }
        //}

        //public  byte? AvaliaçãoVolAtacado
        //{
        //    get { return avaliaçãoVolAtacado; }
        //    set { avaliaçãoVolAtacado = value; DefinirDesatualizado(); }
        //}

        //public byte? AvaliaçãoPagamento
        //{
        //    get { return avaliaçãoPagamento; }
        //    set { avaliaçãoPagamento = value; DefinirDesatualizado(); }
        //}

        //public byte? AvaliaçãoVendaConsignado
        //{
        //    get { return avaliaçãoVendaConsignado; }
        //    set { avaliaçãoVendaConsignado = value; DefinirDesatualizado(); }
        //}

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

        /// <summary>
        /// Opção herdada do banco de dados antigo.
        /// </summary>
        // TODO: Verificar se este campo será extingüido.
        public bool Fornecedor
        {
            get { return fornecedor; }
#if PERMITIR_IMPORTAÇÃO
            set { fornecedor = value; DefinirDesatualizado(); }
#endif
        }

        public Região Região
        {
            get { return região; }
            set { região = value; DefinirDesatualizado(); }
        }

        #endregion

        #endregion

        public Pessoa() { }

        public Pessoa(ulong código)
        {
            this.codigo = código;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is Pessoa)
                return this.Nome.CompareTo(((Pessoa)obj).Nome);
            else
                return Nome.CompareTo(obj.ToString());
        }

        #endregion

        /// <summary>
        /// Usuário padrão para varejo
        /// </summary>
        public static Pessoa Varejo
        {
            get
            {
                return ObterPessoa(1022);
            }
        }

        #region Recuperação de Dados

        /// <summary>
        /// Obtém nomes do banco de dados.
        /// </summary>
        /// <param name="nomeBase">Nome de base para pesquisa.</param>
        /// <param name="limite">Limite de nomes.</param>
        /// <returns>Vetor de nomes.</returns>
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


                        string tmpNome;

                        // Primeiramente inserir nome base
                        tmpNome = nomeBase.Replace(' ', '%').Replace("%%", "%");

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

                        /*
                         * Pesquisar demais nomes, se necessário
                         */
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
                    }

                }
                finally
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                }

                return (string[])dados.ToArray(typeof(string));
            }
        }
        

        ///// <summary>
        ///// Hash para pessoas com foto.
        ///// Deve ser usado apenas dentro de ObterFoto para evitar consultas desnecessarias.
        ///// </summary>
        //private static List<ulong> pessoasComFoto = null;

        ///// <summary>
        ///// Recupera a foto do banco de dados.
        ///// </summary>
        //private void ObterFoto()
        //{
        //    IDbConnection conexão;

        //    lock (this)
        //    {
        //        if (!Cadastrado)
        //        {
        //            foto = null;
        //            estadoFoto = EstadoFoto.Inexistente;
        //        }
        //        else
        //        {
        //            if (pessoasComFoto == null)
        //            {
        //                // Cria a hash!
        //                pessoasComFoto = new List<ulong>();
        //                conexão = Conexão;
        //                IDataReader leitor;

        //                lock (conexão)
        //                {
        //                    using (IDbCommand cmd = conexão.CreateCommand())
        //                    {
        //                        cmd.CommandText = "SELECT codigo FROM pessoafoto";

        //                        leitor = cmd.ExecuteReader() ;

        //                        while (leitor.Read())
        //                        {
        //                            pessoasComFoto.Add((ulong) leitor.GetInt64(0));
        //                        }

        //                        if (leitor != null)
        //                            leitor.Close();
        //                    }
        //                }
        //            }

        //            if (!pessoasComFoto.Contains(Código))
        //            {
        //                // Sai fora economizando consulta!
        //                foto = null;
        //                estadoFoto = EstadoFoto.Inexistente;
        //                return;
        //            }

        //            object objFoto;
        //            conexão = Conexão;

        //            lock (conexão)
        //            {
        //                using (IDbCommand cmd = conexão.CreateCommand())
        //                {
        //                    cmd.CommandText = "SELECT foto FROM pessoafoto WHERE codigo = " + DbTransformar(Código);

        //                    objFoto = cmd.ExecuteScalar();
        //                }
        //            }

        //            if (objFoto != null && objFoto.GetType() != typeof(DBNull))
        //            {
        //                this.foto = (byte[])objFoto;
        //                estadoFoto = EstadoFoto.Cadastrada;
        //            }
        //            else
        //            {
        //                this.foto = null;
        //                estadoFoto = EstadoFoto.Inexistente;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Obtém uma pessoa a partir de um código.
        /// </summary>
        /// <param name="código">Código da pessoa.</param>
        /// <returns>Retorna uma pessoa-física ou jurídica.</returns>
        public static Pessoa ObterPessoa(ulong código)
        {
            return (Entidades.Pessoa.Pessoa)CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), código);
        }

        public static Pessoa ObterPessoa(IDataReader leitor, int inicioPessoa, int inicioPessoaFisica, int inicioPessoaJuridica)
        {
            // campo codigo da pessoa física
            if (!leitor.IsDBNull(inicioPessoaFisica))
            {
                // É pessoa física
                return PessoaFísica.Obter(leitor, inicioPessoa, inicioPessoaFisica);
            }
            else
            {
                // É pessoa jurídica.
                //return Pessoa.ObterPessoa((ulong) leitor.GetInt64(inicioPessoa));
                return PessoaJurídica.Obter(leitor, inicioPessoa, inicioPessoaJuridica);
            }
        }

        /// <summary>
        /// Apenas deve ser chamado pelo CacheDb. 
        /// </summary>
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
                        cmd.CommandText = "SELECT * FROM pessoa left join pessoafisica on pessoa.codigo=pessoafisica.codigo  left join pessoajuridica pj on pessoa.codigo=pj.codigo WHERE pessoa.codigo = "
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


        public static List<Pessoa> ObterPessoas(string chaveBusca, int limite)
        {
            if (String.IsNullOrEmpty(chaveBusca))
            {
                return new List<Pessoa>(Representante.ObterRepresentantes());
            }

            IDataReader leitor = null;
            List<Pessoa> dados = new List<Pessoa>(limite);
            IDbConnection conexão = Conexão;
            chaveBusca = chaveBusca.Trim();
            chaveBusca = chaveBusca.Replace("%%", "%").Replace("'","").Replace("\"","").Replace("\\","").Replace("  "," ").Replace("  "," ");
            
            string tmpNome = chaveBusca.Replace(' ', '%');

            StringBuilder comando = new StringBuilder();

            /* select * from (select * from (select * from pessoa where nome like 'melo%' order by nome) a UNION select * from (select * from pessoa where nome like '%melo%' order by nome desc) b) tudo limit 5 
             */
            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    // Procura por código da pessoa
                    long código;
                    bool chaveÉNúmero = long.TryParse(chaveBusca, out código);

                    try
                    {
                        comando.Append("select * from (select * from ");

                        // Inclui busca por código da pessoa
                        if (chaveÉNúmero)
                        {
                            comando.Append("(SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE p.codigo= ");
                            comando.Append(DbTransformar(código));
                            comando.Append(" ) cod UNION select * from ");
                        }

                        if (chaveBusca.Length < 4)
                        {
                            comando.Append(" ( SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE nome LIKE '");
                            comando.Append(chaveBusca);
                            comando.Append("%' ) peq order by nome ");
                        }
                        else
                        {
                            // pontes melo%
                            comando.Append("  (SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE nome LIKE '");
                            comando.Append(tmpNome.Substring(0, tmpNome.Length).Replace('%', ' '));
                            comando.Append("%' ORDER BY nome ");

                            comando.Append(") aa UNION select * from ");

                            // %pontes melo
                            comando.Append(" (SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE nome LIKE '%");
                            comando.Append(chaveBusca);
                            comando.Append("' ORDER BY nome ) ab UNION select * from ");

                            //// Busca no nome fantasia
                            //comando.Append(" (SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE pj.fantasia LIKE '%");
                            //comando.Append(chaveBusca);
                            //comando.Append("%' ORDER BY nome ) fant UNION select * from ");

                            // %pontes melo%
                            comando.Append(" (SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE nome LIKE '%");
                            comando.Append(chaveBusca);
                            comando.Append("%' ORDER BY nome ) abw ");

                            if (chaveBusca.Contains(" "))
                            {
                                // %pontes%melo%
                                comando.Append(" UNION select * from   (SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE nome LIKE '%");
                                comando.Append(tmpNome.Substring(0, tmpNome.Length));
                                comando.Append("%' ORDER BY nome ) a ");

                                String[] palavras = chaveBusca.Split(' ');
                                //// Se tiver 'André Pontes Melo', faz as seguintes consultas:
                                //// André Pontes Melo%
                                //// André Pontes%
                                //// André% =)
                                //for (int x = palavras.Length - 1; x >= 0; x--)
                                //{
                                //    comando.Append(" UNION select * from   (SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE nome LIKE '");
                                //    bool primeiro = true;
                                //    for (int y = 0; y <= x; y++)
                                //    {
                                //        if (!primeiro)
                                //        {
                                //            comando.Append(" ");
                                //        }

                                //        comando.Append(palavras[y]);
                                //        primeiro = false;
                                //    }
                                //    comando.Append("%' ORDER BY nome ) a");
                                //    comando.Append(x.ToString());
                                //}

                                // %pontes% OR %melo%
                                String[] nomes = chaveBusca.Split(' ');
                                List<String> lstNomesGrandes = new List<string>();
                                foreach (string parte in nomes)
                                {
                                    if (parte.Length < 4) continue;
                                    lstNomesGrandes.Add(parte);
                                }
    
                                if (lstNomesGrandes.Count > 0)
                                {
                                    comando.Append(" UNION select * from (SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE ");

                                    bool primeiro = true;
                                    foreach (string nomeGrande in lstNomesGrandes)
                                    {
                                        if (!primeiro)
                                            comando.Append(" OR ");

                                        comando.Append("nome LIKE '%");
                                        comando.Append(nomeGrande);
                                        comando.Append("%' ");
                                        primeiro = false;
                                    }

                                    comando.Append(" order by nome) b ");
                                }

                                comando.Append(" UNION select * from (SELECT p.codigo as cod, p.nome, p.setor, p.email,  p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.*,pj.codigo as c, pj.cnpj, pj.fantasia, pj.inscEstadual, pj.inscMunicipal   FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join pessoajuridica pj on p.codigo=pj.codigo WHERE observacoes LIKE '%");

                                //comando.Append(tmpNome.Substring(0, tmpNome.Length - 2));
                                comando.Append(chaveBusca);

                                comando.Append("%' order by nome) obs ");
                            }
                        }
                        comando.Append(" ) tudo limit ");
                        comando.Append(limite.ToString());

                        cmd.CommandText = comando.ToString();
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

                // Carrega o endereços das pessoas.
                CarregarEndereços(dados);

                return dados;
            }
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
                        cmd.CommandText = "SELECT p.codigo as cod, p.nome, p.setor, p.email, p.observacoes, p.ultimaVisita, p.dataRegistro, p.dataAlteracao, p.classificacoes, p.maiorVenda, p.credito, p.fornecedor, p.regiao, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo ";
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

                // Carrega o endereços das pessoas.
                CarregarEndereços(dados);

                return dados;
            }
        }


        /// <summary>
        /// Obtém pessoas de uma região.
        /// </summary>
        /// <param name="região">Região cujas pessoas serão recuperadas.</param>
        /// <returns>Vetor de pessoas que pertencem à região.</returns>
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

        /// <summary>
        /// Obtém PessoaFísica, Jurídica e Representantes de um setor.
        /// </summary>
        /// <param name="setor">Setor cujas pessoas serão recuperadas.</param>
        /// <returns>Vetor de pessoas.</returns>
        public static List<Pessoa> ObterPessoas(Entidades.Setor setor)
        {
            List<Pessoa> pessoas;

            /* Verificar parâmetros. */

            if (setor == null)
                throw new ArgumentNullException("setor");

            if (!setor.Cadastrado)
                throw new ArgumentException("Setor não cadastrado.", "setor");


            /* Construir consultas. */

            string cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE"
                + " pessoa.setor = " + DbTransformar(setor.Código);

            pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            return pessoas;
        }

        /// <summary>
        /// Obtém PessoaFísica, Jurídica e Representantes de um setor em
        /// um período específico.
        /// </summary>
        /// <param name="setor">Setor cujas pessoas serão recuperadas.</param>
        /// <param name="início">Período inicial.</param>
        /// <param name="final">Período final.</param>
        /// <returns>Vetor de pessoas.</returns>
        public static List<Pessoa> ObterPessoas(Entidades.Setor setor, DateTime início, DateTime final)
        {
            List<Pessoa> pessoas;
            string cmd;

            /* Verificar parâmetros. */

            if (setor == null)
                throw new ArgumentNullException("setor");

            if (!setor.Cadastrado)
                throw new ArgumentException("Setor não cadastrado.", "setor");

            if (início >= final)
                throw new ArgumentException("Período incorreto.");


            /* Construir consultas. */

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

            /* Verificar parâmetros. */

            /* Construir consultas. */

            cmd = "SELECT * FROM pessoa left join pessoafisica ON pessoa.codigo = pessoafisica.codigo WHERE regiao = " + DbTransformar(região.Código);

            pessoas = RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);

            return pessoas;
        }

        /// <summary>
        /// Obtém pessoa a partir do telefone.
        /// </summary>
        /// <param name="telefone">Telefone da pessoa.</param>
        /// <returns>Vetor de pessoas.</returns>
        public static List<Pessoa> ObterPessoasPorTelefone(string telefone)
        {
            string cmd = "SELECT p.*, pf.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo, telefone t"
                + " WHERE t.telefone LIKE '%" + telefone + "%'"
                + " AND t.pessoa = p.codigo ";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        public static string ObterCódigoPessoas(List<Pessoa> pessoas)
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

        /// <summary>
        /// Obtém pessoa a partir do nome.
        /// </summary>
        /// <param name="nome">Nome da pessoa.</param>
        /// <returns>Vetor de pessoas-física e jurídicas.</returns>
        public static List<Pessoa> ObterPessoas(string nome)
        {
            //string nomeQualquer = nome.Replace(' ', '%').Replace("'", @"\'");

            //return RealizarConsulta("SELECT * FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo" +
            //  " WHERE p.nome LIKE '%" + nomeQualquer + "%' LIMIT " + DbTransformar(limite), 0, Pessoa.TotalAtributos);
            return ObterPessoas(nome, LIMITE_PADRÃO_PESSOAS);
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

        /// <summary>
        /// Obtém pessoa a partir da cidade.
        /// </summary>
        /// <param name="cidade">Cidade da pessoa.</param>
        /// <returns>Vetor de pessoas-física e jurídicas.</returns>
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

        /// <summary>
        /// Obtém pessoa a partir do estado.
        /// </summary>
        /// <param name="estados">Estado da pessoa.</param>
        /// <returns>Vetor de pessoas-física e jurídicas.</returns>
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

        /// <summary>
        /// Obtém vendedores.
        /// </summary>
        /// <param name="chave">Parte do nome a ser procurado.</param>
        /// <param name="limite">Limite de pessoas a serem recuperadas.</param>
        /// <returns>Vetor de vendedores.</returns>
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

        /// <summary>
        /// Obtém vendedores.
        /// </summary>
        /// <returns>Lista de vendedores.</returns>
        public static IList<Pessoa> ObterVendedores()
        {
            //List<Pessoa> vendedores;
            //Funcionário[] funcionários;
            //Representante[] representantes;

            //funcionários = Funcionário.ObterFuncionários(true, false);
            //representantes = Representante.ObterRepresentantes();
            //vendedores = new List<Pessoa>(funcionários.Length + representantes.Length);

            //vendedores.AddRange(funcionários);
            //vendedores.AddRange(representantes);

            //return vendedores;

            string cmd = "SELECT p.*, pf.*, f.* FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo left join funcionario f on pf.codigo=f.codigo "
            + " WHERE p.codigo in (select vendedor from venda) and f.dataSaida is null ";

            return RealizarConsulta(cmd, 0, Pessoa.TotalAtributos);
        }

        #endregion

        #region Recuperação por cast

        public static implicit operator Pessoa(long código)
        {
            return (Entidades.Pessoa.Pessoa)CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        public static implicit operator Pessoa(ulong código)
        {
            return (Entidades.Pessoa.Pessoa)CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        public static implicit operator Pessoa(uint código)
        {
            return (Entidades.Pessoa.Pessoa)CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        public static implicit operator Pessoa(int código)
        {
            return (Entidades.Pessoa.Pessoa)CacheDb.Instância.ObterEntidade(typeof(Entidades.Pessoa.Pessoa), Convert.ToUInt64(código));
        }

        #endregion

        public override string ToString()
        {
            return nome + " (cód " + Código.ToString() + ")";
        }

        /// <summary>
        /// Extrai nomes contidos em outro nome completo
        /// </summary>
        /// <param name="nome">Nome completo</param>
        /// <returns>Nomes contidos</returns>
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

        /// <summary>
        /// Extrai nome de várias pessoas, formando uma string
        /// separando cada nome (apenas o primeiro nome) por vírgula.
        /// </summary>
        public static string ExtrairNomes(Pessoa[] pessoas)
        {
            string nomes = "";

            foreach (Pessoa pessoa in pessoas)
            {
                if (nomes.Length > 0)
                    nomes += ", ";

                nomes += pessoa.PrimeiroNome;
            }

            return nomes;
        }



        /// <summary>
        /// Reduz nomes em um dataset
        /// </summary>
        /// <param name="dataSet">DataSet que contém os dados</param>
        /// <param name="coluna">Coluna que contém o nome. Começa do 0</param>
        public static void ReduzirNomes(System.Data.DataSet dataSet, int coluna)
        {
            foreach (DataRow linha in dataSet.Tables[0].Rows)
            {
                //string[] nomes;
                //string novoNome;

                //nomes = ((string)linha[coluna]).Split(' ');
                //novoNome = nomes[0];

                //for (int i = 1; i < nomes.Length; i++)
                //    if (nomes[i].Length > 3)
                //        novoNome += " " + nomes[i][0] + '.';

                //linha[coluna] = novoNome;

                linha[coluna] = ReduzirNome((string)linha[coluna]);
            }
        }

        public static String ReduzirNome(string nome)
        {
            string[] nomes;
            string novoNome;

            nomes = nome.Split(' ');
            novoNome = nomes[0];

            for (int i = 1; i < nomes.Length; i++)
                if (nomes[i].Length > 3)
                    novoNome += " " + nomes[i][0] + '.';

            return novoNome;
        }


        #region Atualização do banco de dados

        /// <summary>
        /// Cadastra a entidade no banco de dados.
        /// </summary>
        protected override void Cadastrar(IDbCommand cmd)
        {
            dataRegistro = dataAlteração = DadosGlobais.Instância.HoraDataAtual;

            cmd.CommandText = "INSERT INTO pessoa (" +
#if PERMITIR_IMPORTAÇÃO
 (codigo > 0 ? "codigo, " : "") +
#endif
 "nome, setor, " +
                            "email, observacoes, ultimaVisita, classificacoes, " +
                            "dataRegistro, dataAlteracao, " +
                //"avaliacaoVolVarejo, " +
                //"avaliacaoVolAtacado, avaliacaoPagamento, avaliacaoVendaConsignado, " +
                            "maiorVenda, credito, fornecedor, regiao) " +
                            "VALUES (" +
#if PERMITIR_IMPORTAÇÃO
 (codigo > 0 ? DbTransformar(codigo) + ", " : "") +
#endif
 DbTransformar(this.Nome) + ", " +
                            (this.setor != null ? DbTransformar(this.Setor.Código) : "NULL") + ", " +
                            DbTransformar(this.email) + ", " +
                            DbTransformar(this.observações) + ", " +
                            DbTransformar(this.últimaVisita) + ", " +
                            DbTransformar(this.classificações) + ", " +
#if PERMITIR_IMPORTAÇÃO
 DbTransformar(this.dataRegistro) + ", " +
#else
                            "NOW(), " +
#endif
 "NOW(), " +
                //DbTransformar(this.avaliaçãoVolVarejo) + ", " +
                //DbTransformar(this.avaliaçãoVolAtacado) + ", " +
                //DbTransformar(this.avaliaçãoPagamento) + ", " +
                //DbTransformar(this.avaliaçãoVendaConsignado) + ", " +
                            DbTransformar(this.maiorVenda) + ", " +
                            DbTransformar(this.crédito) + ", " +
                            DbTransformar(this.fornecedor) + ", " +
                            (this.região != null ? DbTransformar(this.região.Código) : DbTransformar((string)null)) + ")";

            cmd.ExecuteNonQuery();

#if PERMITIR_IMPORTAÇÃO
            if (this.codigo == 0)
#endif
                this.codigo = Convert.ToUInt64(ObterÚltimoCódigoInserido(cmd.Connection));

            if (endereços != null)
            {
                VerificarEndereços();
                CadastrarEntidade(cmd, endereços);
            }

            if (telefones != null)
                CadastrarEntidade(cmd, telefones);

            //if (relacionamentos != null)
            //    CadastrarEntidade(cmd, relacionamentos);

            if (datasRelevantes != null)
                CadastrarEntidade(cmd, datasRelevantes);

            //// Cadastrar foto, se houver
            //if (this.Foto != null)
            //    CadastrarFoto(cmd);
        }

        ///// <summary>
        ///// Cadastra foto no banco de dados.
        ///// </summary>
        //private void CadastrarFoto(IDbCommand cmd)
        //{
        //    if (this.foto != null)
        //    {
        //        byte[] foto = this.foto;
        //        IDbDataParameter arg = cmd.CreateParameter();

        //        arg.ParameterName = "?foto";
        //        arg.DbType = DbType.Binary;
        //        arg.Value = foto;

        //        cmd.Parameters.Add(arg);

        //        cmd.CommandText = "INSERT INTO pessoafoto (codigo, foto) VALUES " +
        //            "(" + this.Código.ToString() + ", ?foto)";

        //        cmd.ExecuteNonQuery();

        //        estadoFoto = EstadoFoto.Cadastrada;

        //        if (pessoasComFoto != null && !pessoasComFoto.Contains(Código))
        //            pessoasComFoto.Add(Código);

        //    }
        //}

        /// <summary>
        /// Verifica se a entidade encontra-se atualizada.
        /// </summary>
        public override bool Atualizado
        {
            get
            {
                return base.Atualizado && estadoFoto != EstadoFoto.Desatualizada;
            }
        }

        ///// <summary>
        ///// Atualiza a entidade no banco de dados.
        ///// </summary>
        ///// <remarks>
        ///// O implementador deverá atribuir o valor
        ///// verdadeiro para o atributo "atualizado".
        ///// </remarks>
        //public override void Atualizar()
        //{
        //    if (Atualizado && (estadoFoto & EstadoFoto.Desatualizada) > 0)
        //        AtualizarFoto();
        //    else
        //        base.Atualizar();

        //    //CacheDb.Instância.Remover(this);
        //}

        /// <summary>
        /// Atualiza a entidade no banco de dados.
        /// </summary>
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
                //" avaliacaoVolVarejo = " + DbTransformar(this.avaliaçãoVolVarejo) + ", " +
                //" avaliacaoVolAtacado = " + DbTransformar(this.avaliaçãoVolAtacado) + ", " +
                //" avaliacaoPagamento = " + DbTransformar(this.avaliaçãoPagamento) + ", " +
                //" avaliacaoVendaConsignado = " + DbTransformar(this.avaliaçãoVendaConsignado) + ", " +
                " maiorVenda = " + DbTransformar(this.maiorVenda) + ", " +
                " credito = " + DbTransformar(this.crédito) + ", " +
                " fornecedor = " + DbTransformar(this.fornecedor) + ", " +
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

            //if ((estadoFoto & EstadoFoto.Desatualizada) > 0)
            //    AtualizarFoto(cmd);

            //if (relacionamentos != null)
            //    AtualizarEntidade(cmd, relacionamentos);

            if (datasRelevantes != null)
                AtualizarEntidade(cmd, datasRelevantes);
        }

        ///// <summary>
        ///// Cria comando para atualização de foto.
        ///// </summary>
        //private void AtualizarFoto()
        //{
        //    IDbConnection conexão = Conexão;

        //    lock (conexão)
        //        using (IDbCommand cmd = conexão.CreateCommand())
        //            AtualizarFoto(cmd);
        //}

        ///// <summary>
        ///// Atualiza a foto.
        ///// </summary>
        ///// <param name="cmd">Atualização de foto.</param>
        //private void AtualizarFoto(IDbCommand cmd)
        //{
        //    switch (estadoFoto)
        //    {
        //        case EstadoFoto.Inexistente | EstadoFoto.Desatualizada:
        //            if (foto != null)
        //                CadastrarFoto(cmd);
        //            else
        //                estadoFoto = EstadoFoto.Inexistente;
        //            break;

        //        case EstadoFoto.Cadastrada | EstadoFoto.Desatualizada:
        //            if (foto != null)
        //                DescadastrarFoto(cmd);
        //            else
        //                SubstituirFoto(cmd);
        //            break;
        //    }
        //}

        ///// <summary>
        ///// Substitui foto já existente.
        ///// </summary>
        ///// <param name="cmd">Comando do banco de dados.</param>
        //private void SubstituirFoto(IDbCommand cmd)
        //{
        //    if (foto == null)
        //        DescadastrarFoto(cmd);
        //    else
        //    {
        //        IDataParameter arg = cmd.CreateParameter();
        //        arg.ParameterName = "?foto";
        //        arg.DbType = DbType.Binary;
        //        arg.Value = (byte[])foto;

        //        cmd.Parameters.Add(arg);

        //        cmd.CommandText = "UPDATE pessoafoto SET " +
        //            "foto = ?foto " +
        //            "WHERE codigo = " + DbTransformar(Código);

        //        cmd.ExecuteNonQuery();

        //        estadoFoto = EstadoFoto.Cadastrada;
        //    }
        //}

        /// <summary>
        /// Atualiza os dados sobre o último acesso.
        /// </summary>
        /// <param name="cmd">Comando do banco de dados.</param>
        /// <param name="entrada">Momento que visitante entrou na empresa.</param>
        public void AtualizarÚltimaVisita(IDbCommand cmd, DateTime entrada)
        {
            if (!Cadastrado)
                throw new Acesso.Comum.Exceções.EntidadeNãoCadastrada(this);

            últimaVisita = entrada;

            cmd.CommandText = "UPDATE pessoa SET ultimaVisita = " + DbTransformar(entrada)
                + " WHERE codigo = " + DbTransformar(codigo);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Descadastra a entidade no banco de dados.
        /// </summary>
        protected override void Descadastrar(IDbCommand cmd)
        {
            /* Verificar se o cliente está em dia. */
            double dívida;

            if (Dívida.ObterVendasNãoQuitadas(this, out dívida).Length > 0)
                throw new ExceçãoClientePossuiPendências(this, "Existe vendas não quitadas.");

            if (Acerto.AcertoConsignado.ObterAcertosPendentes(this).Length > 0)
                throw new ExceçãoClientePossuiPendências(this, "Existem acertos pendentes.");

            //if ((estadoFoto & EstadoFoto.Cadastrada) > 0)
            //    DescadastrarFoto(cmd);

            DescadastrarEntidade(cmd, Endereços);
            DescadastrarEntidade(cmd, Telefones);
            //DescadastrarEntidade(cmd, Relacionamentos);
            DescadastrarEntidade(cmd, DatasRelevantes);

            cmd.CommandText = "DELETE FROM pessoa WHERE codigo = " + DbTransformar(codigo);
            cmd.ExecuteNonQuery();
        }

        ///// <summary>
        ///// Descadastra foto do banco de dados.
        ///// </summary>
        ///// <param name="cmd">Comando do banco de dados.</param>
        //private void DescadastrarFoto(IDbCommand cmd)
        //{
        //    cmd.CommandText = "DELETE FROM pessoafoto WHERE codigo = " + DbTransformar(Código);
        //    cmd.ExecuteNonQuery();

        //    estadoFoto = EstadoFoto.Inexistente;

        //    if (pessoasComFoto != null && pessoasComFoto.Contains(Código))
        //        pessoasComFoto.Remove(Código);
        //}

        /// <summary>
        /// Atualiza a classificação da pessoa.
        /// </summary>
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

        #endregion

        private void CarregarEndereços()
        {
            endereços = new DbComposição<Entidades.Pessoa.Endereço.Endereço>();

            if (Cadastrado)
                endereços.AdicionarJáCadastrado(Endereço.Endereço.ObterEndereços(this));
        }

        public static void CarregarEndereços(List<Pessoa> pessoas)
        {
            // Obtem os endereços

            Dictionary<ulong, DbComposição<Endereço.Endereço>> hashEndereços =
                Endereço.Endereço.ObterEndereços(pessoas);

            // Atribui os endereços às pessoas
            foreach (Pessoa p in pessoas)
            {
                DbComposição<Endereço.Endereço> endereços = null;

                if (!hashEndereços.TryGetValue(p.Código, out endereços))
                {
                    // A pessoa não tem endereço
                    endereços = new DbComposição<Entidades.Pessoa.Endereço.Endereço>();
                }

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

        ///// <summary>
        ///// Obtém o relacionamento que esta pessoa possui com outra.
        ///// </summary>
        ///// <param name="pessoa">Pessoa com que será verificado o relacionamento.</param>
        ///// <returns>O tipo de relacionamento desta pessoa com a outra passada por parâmetro.</returns>
        //public TipoRelacionamento ObterRelacionamento(Pessoa pessoa)
        //{
        //    foreach (RelacionamentoInterpessoal relacionamento in Relacionamentos)
        //        if (relacionamento.Pessoa2.Equals(pessoa))
        //            return relacionamento.TipoRelacionamento;
        //        else if (relacionamento.Pessoa1.Equals(pessoa))
        //            return RelacionamentoInterpessoal.InverterRelacionamento(relacionamento.TipoRelacionamento);

        //    return TipoRelacionamento.Nenhum;
        //}

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

        /// <summary>
        /// Verifica se novos endereços possuem novas localidades duplicadas.
        /// </summary>
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

        /// <summary>
        /// Registra item no histórico da pessoa, em nome
        /// do sistema.
        /// </summary>
        /// <param name="texto">Texto a constar no histórico da pessoa.</param>
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
            else
                return false;
        }

        /// <summary>
        /// Todas as pessoas são clientes
        /// exceto os funcionários ainda não demitidos
        /// e representantes.
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static bool ÉCliente(Entidades.Pessoa.Pessoa pessoa)
        {
            if (Entidades.Pessoa.Funcionário.ÉFuncionário(pessoa))
            {
                Funcionário f;

                if (pessoa is Funcionário)
                    f = (Funcionário)pessoa;
                else
                    f = Funcionário.ObterPessoa(pessoa.Código);

                if (f.DataSaída.HasValue)
                    return true;

                // É funcionário
                return false;
            }
            else
                return !Entidades.Pessoa.Representante.ÉRepresentante(pessoa);
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

            fornecedor = leitor.GetBoolean(inicioAtributo + 11);

            if (leitor[inicioAtributo + 12] != DBNull.Value)
                região = Região.ObterRegião((uint)leitor[inicioAtributo + 12]);

        }

        public static int TrocarRegião(List<Pessoa> pessoas, Endereço.Região região)
        {
            IDbConnection conexão;
            IDbCommand cmd;

            List<ulong> códigos = new List<ulong>();
            foreach (Pessoa p in pessoas)
                códigos.Add(p.Código);

            // Efetuar cadastro.
            conexão = Conexão;
            int linhasAlteradas = 0;

            lock (conexão)
            {
                using (cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "update pessoa set regiao = " + DbTransformar(região.Código) +
                        " WHERE codigo in " + DbTransformarConjunto(códigos);

                    linhasAlteradas = cmd.ExecuteNonQuery();
                }
            }

            return linhasAlteradas;
        }

        public static List<Pessoa> ObterPessoasComissionadas()
        {
            DateTime? dia = null;

            //SELECT * FROM pessoa p left join pessoafisica pf on p.codigo=pf.codigo
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
    }
}
