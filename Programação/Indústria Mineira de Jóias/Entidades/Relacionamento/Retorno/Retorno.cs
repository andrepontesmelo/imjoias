using System;
using Acesso.Comum;
using System.Data;
using System.Collections;
using Entidades.Acerto;
using System.Collections.Generic;
using Acesso.Comum.Cache;
using Entidades.Balanço;

namespace Entidades.Relacionamento.Retorno
{
    [Serializable]
	public class Retorno : Entidades.Relacionamento.RelacionamentoAcerto
	{
        [DbRelacionamento("codigo", "pessoa")]
        protected Pessoa.Pessoa pessoa;
		
		#region Propriedades

        public override Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                DefinirDesatualizado();
                pessoa = value;
            }
        }

		public new HistóricoRelacionamentoRetorno Itens
		{
			get { return (HistóricoRelacionamentoRetorno) base.Itens; }
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
                            "SELECT travado FROM retorno where codigo=" + DbTransformar(codigo);

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
        #endregion

		private Retorno(DateTime data, Entidades.Pessoa.Funcionário digitadoPor, Entidades.Pessoa.Pessoa pessoa)
		{
			this.codigo = -1;
			this.travado = false;

			this.data = data;
			this.digitadopor = digitadopor;
			this.pessoa = pessoa;
		}

        protected override HistóricoRelacionamento ConstruirItens()
		{
			return new HistóricoRelacionamentoRetorno(this);
		}

        public Retorno() { }

        public Retorno(Entidades.Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        private enum Ordem
        {
            IndiceItem, DataItem, FuncionárioItem, Código, Referência, PesoRetorno, Quantidade, Referencia, Nome, Teor, Peso, Faixa, Grupo, Digito, ForaDeLinha, DePeso
        }

        /// <summary>
        /// Obtém retornos vinculados a um acerto.
        /// </summary>
        public static List<Retorno> ObterRetornos(AcertoConsignado acerto)
        {
            List<Retorno> retornos = Mapear<Retorno>(
                "SELECT * FROM retorno WHERE acerto = " + DbTransformar(acerto.Código));

            // Itens serão recuperados quando necessário.
            //RecuperarColeções(retornos);

            return retornos;
        }

        /// <summary>
        /// Esta lista preenche 3 entidades de uma só vez:
        ///		- retorno, itemretorno, Mercadoria (do itemretorno)
        ///	
        ///	Basicamente recupera todos as retornos não acertadas.
        ///	a lista de itens e suas mercadorias também são obtidas
        /// </summary>
        /// <remarks> Pessoa pode ser nulo </remarks>
        public static List<Retorno> ObterRetornos(Pessoa.Pessoa pessoa, DateTime início, DateTime final, bool apenasNãoAcertados)
        {
            // Obtém os retornos sem os itens, e cria uma hash para auxiliar futuramente
            List<Retorno> retornos = ObterRetornosSemItens(pessoa, início, final, apenasNãoAcertados);

            return retornos;
        }

        private enum OrdemSemItens
        {
            Código, Data, Pessoa, DigitadoPor, Travado, Tabela
        }

        private static List<Retorno> ObterRetornosSemItens(Pessoa.Pessoa pessoa, DateTime início, DateTime final, bool apenasNãoAcertados)
        {
            IDbConnection conexão;
            List<Retorno> retornos; // = new ArrayList();

            conexão = Conexão;

            lock (conexão)
            {
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    //cmd.CommandText = "SELECT codigo, data, pessoa, digitadopor, travado, acertado, tabela, acerto from retorno where ";
                    cmd.CommandText = "SELECT * from retorno where ";

                    if (apenasNãoAcertados) cmd.CommandText += " acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    if (pessoa != null)
                        cmd.CommandText += " AND pessoa=" + pessoa.Código;

                    cmd.CommandText +=
                        " AND data BETWEEN " + DbTransformar((DateTime?)início) + " AND " + DbTransformar(final);

                    retornos = Mapear<Retorno>(cmd);
                }
            }

            return retornos;
        }

        /// <summary>
        /// Conta quantos retornos do cliente ainda não foram acertados.
        /// </summary>
        /// <param name="pessoa">Cliente.</param>
        /// <returns>Número de retornos não acertados.</returns>
        public static uint ContarRetornosNãoAcertados(Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão;

            conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM retorno WHERE acerto in (select codigo from acertoconsignado where dataefetiva is null) AND pessoa="
                    + DbTransformar(pessoa.Código);

                lock (conexão)
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

                                SaquinhoAcerto itemNovo = SaquinhoAcerto.Construir(fórmula, new Mercadoria.Mercadoria(referência, dígito, peso, índice), 0, peso, índice);

                                bool itemJáExistente;


                                // Item a ser utilizado
                                SaquinhoAcerto item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(referência, dígito, peso, null);
                                itemJáExistente = hash.TryGetValue(itemNovo.IdentificaçãoAgrupável(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJáExistente)
                                    item = itemNovo;

                                item.QtdRetorno += qtd;

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

        private static void ObterAcerto(string consulta, Dictionary<string, Balanço.SaquinhoBalanço> hash)
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

                                item.QtdRetorno += qtd;

                                if (!itemJáExistente)
                                    hash.Add(item.IdentificaçãoAgrupável(), item);
                            }
                        }
                    } finally
                    {
                        Usuários.UsuárioAtual.GerenciadorConexões.AdicionarConexão(conexão);
                    }
                }
            }

        }


        public static List<long> ObterAcerto(List<long> códigoRetornos, Dictionary<string, Acerto.SaquinhoAcerto> hash, FórmulaAcerto fórmula)
        {
            string consulta;

            if (códigoRetornos.Count != 0)
            {
                consulta = "select retornoitem.referencia, mercadoria.digito, retornoitem.peso, sum(quantidade) as qtd, retornoitem.indice"
                    + " from retornoitem, retorno, mercadoria WHERE retorno.codigo=retornoitem.retorno AND retorno.codigo IN "
                    + DbTransformarConjunto(códigoRetornos);
                consulta += " AND mercadoria.referencia=retornoitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash, fórmula);
            }

            return códigoRetornos;
        }
        

        private enum OrdemRastro { Data, Documento, Quantidade };

        public static void PreencherRastro(Entidades.Mercadoria.Mercadoria mercadoria, Pessoa.Pessoa pessoa, List<RastroItem> lista, List<long> códigosRetornos)
        {
            IDbConnection conexão;
            IDataReader leitor = null;

            if (códigosRetornos.Count == 0)
                return;

            conexão = Conexão;

            lock (conexão)
            {
                Usuários.UsuárioAtual.GerenciadorConexões.RemoverConexão(conexão);
                using (IDbCommand cmd = conexão.CreateCommand())
                {
   
                    cmd.CommandText = "select retorno.data, retorno.codigo, sum(retornoitem.quantidade) as qtd from retorno "
                    + ", retornoitem WHERE retornoitem.retorno=retorno.codigo "
                    + " AND referencia=" + DbTransformar(mercadoria.ReferênciaNumérica);

                    if (mercadoria.DePeso)
                        cmd.CommandText += " AND peso=" + DbTransformar(mercadoria.Peso);

                    cmd.CommandText += " AND retorno.codigo IN "
                        + DbTransformarConjunto(códigosRetornos);

                    cmd.CommandText += " GROUP BY retorno.codigo, referencia, peso HAVING qtd != 0 ORDER by data";

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                DateTime data = leitor.GetDateTime((int)OrdemRastro.Data);
                                long documento = leitor.GetInt64((int)OrdemRastro.Documento);
                                double qtd = leitor.GetDouble((int)OrdemRastro.Quantidade);

                                RastroItem rastro = new RastroItem(RastroItem.TipoEnum.Retorno, data, documento, qtd);
                                rastro.Documento = "Retorno #" + documento.ToString();
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

        public static Retorno ObterRetorno(long código)
        {
            return ObterRetorno((ulong)código);
        }

        public static Retorno ObterRetorno(ulong código)
        {
            Retorno retorno;

            retorno = MapearÚnicaLinha<Retorno>("SELECT * FROM retorno WHERE "
                + "codigo = " + DbTransformar(código));

            return retorno;
        }

        /// <summary>
        /// Obtém a data do último retorno acertado.
        /// </summary>
        /// <returns>Data do último retorno acertado.</returns>
        public static DateTime ObterDataÚltimoRetornoAcertado(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(data) FROM retorno WHERE pessoa = "
                        + DbTransformar(pessoa.Código)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is not null) ";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem retornos...
                        return DateTime.MinValue;
                    }
                }
        }

        /// <summary>
        /// Obtém a data do primeiro retorno não acertada.
        /// </summary>
        /// <returns>Data do primeiro retorno não acertada.</returns>
        public static DateTime ObterDataPrimeiroRetornoNãoAcertado(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM retorno WHERE pessoa = "
                        + DbTransformar(pessoa.Código)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem retornos...
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
                    cmd.CommandText = "update retorno set travado=1 ";

                    cmd.CommandText += " where codigo IN " + DbTransformarConjunto(códigos);

                    cmd.ExecuteNonQuery();
                }

        }

        public override string ToString()
        {
            return "Retorno " + Código.ToString();
        }

        public static void ObterAcerto(List<long> retornos, Dictionary<string, Balanço.SaquinhoBalanço> hash)
        {
            string consulta;

            if (retornos.Count != 0)
            {
                consulta = "select retornoitem.referencia, mercadoria.digito, retornoitem.peso, sum(quantidade) as qtd, retornoitem.indice"
                    + " from retornoitem, retorno, mercadoria WHERE retorno.codigo=retornoitem.retorno AND retorno.codigo IN "
                    + DbTransformarConjunto(retornos);
                consulta += " AND mercadoria.referencia=retornoitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash);
            }

            return;
        }
    }
}
