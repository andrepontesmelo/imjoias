using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Acesso.Comum;
using Entidades.Relacionamento.Venda;
using Entidades.Relacionamento;
using Entidades.Acerto;
using Acesso.Comum.Cache;
using Entidades.Balanço;

namespace Entidades.Relacionamento.Saída
{
    /// <summary>
    /// Uma saída é uma monitoração de mercadorias que foram relacionadas para alguem.
    /// Não existe um histórico de quando que a mercadoria saiu ou entrou na firma.
    /// Mas sim o número de quantas mercadorias já sairam, e quantas já retornaram.
    /// 
    /// A saída pode ser relacionado para
    ///		- um cliente de atacado
    ///		- um cliente de auto-atacado
    ///		- um funcionário representante
    ///		
    /// Todo contexto saída possui uma entidade saída correspondente.
    /// 
    /// Todo: Documentar serialização
    /// </summary>
    [Serializable, DbTabela("saida")]
    public class Saída : Entidades.Relacionamento.RelacionamentoAcerto
    {
        [DbRelacionamento("codigo", "pessoa")]
        protected Pessoa.Pessoa pessoa;

        [DbColuna("cotacao")]
        protected double cotação;

        #region Propriedades

        /// <summary>
        /// Cotação no momento da saída.
        /// </summary>
        public double Cotação
        {
            get { return cotação; }
            set { cotação = value; DefinirDesatualizado(); }
        }

        public new HistóricoRelacionamentoSaída Itens
        {
            get
            {
                return (HistóricoRelacionamentoSaída) base.Itens;
            }
        }

        public override Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                DefinirDesatualizado();
                pessoa = value;
            }
        }

        #endregion

        protected override HistóricoRelacionamento ConstruirItens()
        {
            return new HistóricoRelacionamentoSaída(this);
        }

        public Saída() { }

        public Saída(Entidades.Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public bool ObterTravadoEmCache()
        {
            return travado;
        }

        public override bool Travado
        {
            get
            {
                if (!Cadastrado) return travado;

                IDbConnection conexão = Conexão;

                lock (conexão)
                {
                    using (IDbCommand cmd = conexão.CreateCommand())
                    {
                        cmd.CommandText =
                            "SELECT travado FROM saida where codigo=" + DbTransformar(codigo);

                        travado = Convert.ToBoolean(cmd.ExecuteScalar());
                    }
                }

                return travado;
            }
            set
            {
                travado = value;

                DefinirDesatualizado();

                if (Cadastrado)
                    Atualizar();
            }
        }

        private enum Ordem
        {
            IndiceItem, DataItem, FuncionárioItem, Código, Referência, PesoSaída, Quantidade, Referencia, Nome, Teor, Peso, Faixa, Grupo, Digito, ForaDeLinha, DePeso
        }

        /// <summary>
        /// Obtém as saídas vinculadas a um acerto.
        /// </summary>
        public static List<Saída> ObterSaídas(AcertoConsignado acerto)
        {
            List<Saída> saídas = Mapear<Saída>(
                "SELECT * FROM saida WHERE acerto = " + DbTransformar(acerto.Código));

            // Saídas serão recuperadas quando necessário
            //RecuperarColeções(saídas);

            return saídas;
        }

        /// <summary>
        /// Esta lista preenche 3 entidades de uma só vez:
        ///		- Saída, itemsaida, Mercadoria (do itemsaida)
        ///	
        ///	Basicamente recupera todos as saídas não acertadas.
        ///	a lista de itens e suas mercadorias também são obtidas
        /// </summary>
        /// <param name="pessoa"> Para quem foi relacionado </param>
        public static List<Saída> ObterSaídas(Pessoa.Pessoa pessoa, DateTime início, DateTime final, bool apenasNãoAcertados)
        {
            // Obtém as saídas sem os itens, e cria uma hash para auxiliar futuramente
            List<Saída> saídas = ObterSaídasSemItens(pessoa, início, final, apenasNãoAcertados);

            return saídas;
        }

        private static List<Saída> ObterSaídasSemItens(Pessoa.Pessoa pessoa, DateTime início, DateTime final, bool apenasNãoAcertados)
        {
            // Lista de interios, utilizado para carregar posteriormente as pessoas.
            //ArrayList pessoas;
            //long[] vPessoas;

            //pessoas = new ArrayList();

            IDbConnection conexão;
            List<Saída> saídas; // = new ArrayList();

            conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    //cmd.CommandText = "SELECT codigo, data, pessoa, digitadopor, travado, acertado, tabela, acerto from saida where ";
                    cmd.CommandText = "SELECT * from saida where 1=1 ";

                    if (apenasNãoAcertados)
                        cmd.CommandText += " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    if (pessoa != null)
                        cmd.CommandText += " AND pessoa=" + pessoa.Código;

                    cmd.CommandText +=
                    " AND data BETWEEN " + DbTransformar((DateTime?)início) + " AND " + DbTransformar(final);

                    saídas = Mapear<Saída>(cmd);
                }
            }

            return saídas;
        }


        /// <summary>
        /// Conta quantos saídas do cliente ainda não foram acertados.
        /// </summary>
        /// <param name="pessoa">Cliente.</param>
        /// <returns>Número de saídas não acertados.</returns>
        public static uint ContarSaídasNãoAcertadas(Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão;

            conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM saida WHERE acerto in (select codigo from acertoconsignado where dataefetiva is null) AND pessoa="
                        + DbTransformar(pessoa.Código);

                    return Convert.ToUInt32(cmd.ExecuteScalar());
                }
        }

        private enum OrdemAcerto { Referência, Dígito, Peso, Quantidade, Índice };

        private static void ObterAcerto(string consulta, Dictionary<string, Acerto.SaquinhoAcerto> hash, FórmulaAcerto fórmula)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string referência = leitor.GetString((int)OrdemAcerto.Referência);
                                byte dígito = leitor.GetByte((int)OrdemAcerto.Dígito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double índice = leitor.GetDouble((int)OrdemAcerto.Índice);

                                //SaquinhoAcerto itemNovo = new SaquinhoAcerto(new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);
                                SaquinhoAcerto itemNovo = SaquinhoAcerto.Construir(fórmula, new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);

                                bool itemJáExistente;

                                // Item a ser utilizado
                                SaquinhoAcerto item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(referência, dígito, peso, null);
                                itemJáExistente = hash.TryGetValue(itemNovo.IdentificaçãoAgrupável(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJáExistente)
                                    item = itemNovo;

                                item.QtdSaída += qtd;

                                if (!itemJáExistente)
                                    hash.Add(item.IdentificaçãoAgrupável(), item);
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
            }
        }

        private static void ObterAcerto(string consulta, Dictionary<string, SaquinhoBalanço> hash)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                string referência = leitor.GetString((int)OrdemAcerto.Referência);
                                byte dígito = leitor.GetByte((int)OrdemAcerto.Dígito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double índice = leitor.GetDouble((int)OrdemAcerto.Índice);

                                SaquinhoBalanço itemNovo = new SaquinhoBalanço(new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);

                                bool itemJáExistente;

                                // Item a ser utilizado
                                SaquinhoBalanço item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(referência, dígito, peso, null);
                                itemJáExistente = hash.TryGetValue(itemNovo.IdentificaçãoAgrupável(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJáExistente)
                                    item = itemNovo;

                                item.QtdSaída += qtd;

                                if (!itemJáExistente)
                                    hash.Add(item.IdentificaçãoAgrupável(), item);
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
            }
        }


        public static List<long> ObterAcerto(List<long> códigoSaídas, Dictionary<string, Acerto.SaquinhoAcerto> hash, FórmulaAcerto fórmula)
        {
            string consulta;
            
            if (códigoSaídas.Count != 0) 
            {
                consulta = "select saidaitem.referencia, mercadoria.digito, saidaitem.peso, sum(quantidade) as qtd, saidaitem.indice"
                    + " from saidaitem, saida, mercadoria WHERE saida.codigo=saidaitem.saida AND saida.codigo IN "
                    + DbTransformarConjunto(códigoSaídas)
                    + " AND mercadoria.referencia=saidaitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash, fórmula);
            }

            return códigoSaídas;
        }

        private enum OrdemRastro { Data, Documento, Quantidade };

        public static void PreencherRastro(Entidades.Mercadoria.Mercadoria mercadoria, Pessoa.Pessoa pessoa, List<RastroItem> lista, List<long> códigoSaídas)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            if (códigoSaídas.Count == 0)
                return;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                lock (conexão)
                {
                    Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);

                    cmd.CommandText = "select saida.data, saida.codigo, sum(saidaitem.quantidade) as qtd from saida "
                    + ", saidaitem WHERE saidaitem.saida=saida.codigo "
                    + " AND referencia=" + DbTransformar(mercadoria.ReferênciaNumérica);

                    if (mercadoria.DePeso)
                        cmd.CommandText += " AND peso=" + DbTransformar(mercadoria.Peso);

                    cmd.CommandText += " AND saida.codigo IN " + DbTransformarConjunto(códigoSaídas);
                    cmd.CommandText += " GROUP BY saida.codigo, referencia, peso HAVING qtd != 0 ORDER by data";

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                DateTime data = leitor.GetDateTime((int)OrdemRastro.Data);
                                long documento = leitor.GetInt64((int)OrdemRastro.Documento);
                                double qtd = leitor.GetDouble((int)OrdemRastro.Quantidade);

                                RastroItem rastro = new RastroItem(RastroItem.TipoEnum.Saída, data, documento, qtd);
                                rastro.Documento = "Saída #" + documento.ToString();
                                lista.Add(rastro);
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
            }
        }

        public static Saída ObterSaída(long código)
        {
            return ObterSaída((ulong)código);
        }

        public static Saída ObterSaída(ulong código)
        {
            Saída saída;
            
            saída = MapearÚnicaLinha<Saída>("SELECT * FROM saida WHERE "
                    + "codigo = " + DbTransformar(código));

            return saída;
        }

        /// <summary>
        /// Obtém a data da última saída.
        /// </summary>
        /// <returns>Data da última saída.</returns>
        public static DateTime ObterDataÚltimaSaída(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(data) FROM saida WHERE pessoa = " + DbTransformar(pessoa.Código);

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem saídas...
                        return DateTime.MinValue;
                    }
                }
        }

        /// <summary>
        /// Obtém a data da última saída acertada.
        /// </summary>
        /// <returns>Data da última saída.</returns>
        public static DateTime ObterDataÚltimaSaídaAcertada(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(data) FROM saida WHERE pessoa = "
                        + DbTransformar(pessoa.Código)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is not null) ";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem saídas...
                        return DateTime.MinValue;
                    }
                }
        }

        /// <summary>
        /// Obtém a data da primeira saída não acertada.
        /// </summary>
        /// <returns>Data da primeira saída não acertada.</returns>
        public static DateTime ObterDataPrimeiraSaídaNãoAcertada(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM saida WHERE pessoa = "
                        + DbTransformar(pessoa.Código)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem saídas...
                        return DateTime.MinValue;
                    }
                }
        }

        public static void TravarVários(List<long> códigos)
        {
            IDbConnection conexão = Conexão;
           
             if (códigos.Count == 0) return;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "update saida set travado=1 ";

                    //if (acertarTambém)
                    //    cmd.CommandText += " AND acertado=1 ";
                    
                    cmd.CommandText += " where codigo IN " + DbTransformarConjunto(códigos);
                    cmd.ExecuteNonQuery();
                }

        }

        public override string ToString()
        {
            return "Saída " + Código.ToString();
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            System.Diagnostics.Debug.Assert(cotação > 0);
            System.Diagnostics.Debug.Assert(tabela != null);

            base.Cadastrar(cmd);
        }

        public static void ObterAcerto(List<long> saídas, Dictionary<string, Balanço.SaquinhoBalanço> hash)
        {
            string consulta;

            if (saídas.Count != 0)
            {
                consulta = "select saidaitem.referencia, mercadoria.digito, saidaitem.peso, sum(quantidade) as qtd, saidaitem.indice"
                    + " from saidaitem, saida, mercadoria WHERE saida.codigo=saidaitem.saida AND saida.codigo IN "
                    + DbTransformarConjunto(saídas)
                    + " AND mercadoria.referencia=saidaitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash);
            }

            return;
        }
    }
}
