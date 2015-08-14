using System;
using Acesso.Comum;
using System.Data;
using System.Collections;
using Entidades.Acerto;
using System.Collections.Generic;
using Acesso.Comum.Cache;
using Entidades.Balan�o;

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

		public new Hist�ricoRelacionamentoRetorno Itens
		{
			get { return (Hist�ricoRelacionamentoRetorno) base.Itens; }
		}


        public override bool Travado
        {
            get
            {
                if (!Cadastrado) return travado;

                IDbConnection conex�o = Conex�o;

                lock (conex�o)
                {
                    using (IDbCommand cmd = conex�o.CreateCommand())
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

		private Retorno(DateTime data, Entidades.Pessoa.Funcion�rio digitadoPor, Entidades.Pessoa.Pessoa pessoa)
		{
			this.codigo = -1;
			this.travado = false;

			this.data = data;
			this.digitadopor = digitadopor;
			this.pessoa = pessoa;
		}

        protected override Hist�ricoRelacionamento ConstruirItens()
		{
			return new Hist�ricoRelacionamentoRetorno(this);
		}

        public Retorno() { }

        public Retorno(Entidades.Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        private enum Ordem
        {
            IndiceItem, DataItem, Funcion�rioItem, C�digo, Refer�ncia, PesoRetorno, Quantidade, Referencia, Nome, Teor, Peso, Faixa, Grupo, Digito, ForaDeLinha, DePeso
        }

        /// <summary>
        /// Obt�m retornos vinculados a um acerto.
        /// </summary>
        public static List<Retorno> ObterRetornos(AcertoConsignado acerto)
        {
            List<Retorno> retornos = Mapear<Retorno>(
                "SELECT * FROM retorno WHERE acerto = " + DbTransformar(acerto.C�digo));

            // Itens ser�o recuperados quando necess�rio.
            //RecuperarCole��es(retornos);

            return retornos;
        }

        /// <summary>
        /// Esta lista preenche 3 entidades de uma s� vez:
        ///		- retorno, itemretorno, Mercadoria (do itemretorno)
        ///	
        ///	Basicamente recupera todos as retornos n�o acertadas.
        ///	a lista de itens e suas mercadorias tamb�m s�o obtidas
        /// </summary>
        /// <remarks> Pessoa pode ser nulo </remarks>
        public static List<Retorno> ObterRetornos(Pessoa.Pessoa pessoa, DateTime in�cio, DateTime final, bool apenasN�oAcertados)
        {
            // Obt�m os retornos sem os itens, e cria uma hash para auxiliar futuramente
            List<Retorno> retornos = ObterRetornosSemItens(pessoa, in�cio, final, apenasN�oAcertados);

            return retornos;
        }

        private enum OrdemSemItens
        {
            C�digo, Data, Pessoa, DigitadoPor, Travado, Tabela
        }

        private static List<Retorno> ObterRetornosSemItens(Pessoa.Pessoa pessoa, DateTime in�cio, DateTime final, bool apenasN�oAcertados)
        {
            IDbConnection conex�o;
            List<Retorno> retornos; // = new ArrayList();

            conex�o = Conex�o;

            lock (conex�o)
            {
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    //cmd.CommandText = "SELECT codigo, data, pessoa, digitadopor, travado, acertado, tabela, acerto from retorno where ";
                    cmd.CommandText = "SELECT * from retorno where ";

                    if (apenasN�oAcertados) cmd.CommandText += " acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    if (pessoa != null)
                        cmd.CommandText += " AND pessoa=" + pessoa.C�digo;

                    cmd.CommandText +=
                        " AND data BETWEEN " + DbTransformar((DateTime?)in�cio) + " AND " + DbTransformar(final);

                    retornos = Mapear<Retorno>(cmd);
                }
            }

            return retornos;
        }

        /// <summary>
        /// Conta quantos retornos do cliente ainda n�o foram acertados.
        /// </summary>
        /// <param name="pessoa">Cliente.</param>
        /// <returns>N�mero de retornos n�o acertados.</returns>
        public static uint ContarRetornosN�oAcertados(Pessoa.Pessoa pessoa)
        {
            IDbConnection conex�o;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM retorno WHERE acerto in (select codigo from acertoconsignado where dataefetiva is null) AND pessoa="
                    + DbTransformar(pessoa.C�digo);

                lock (conex�o)
                    return Convert.ToUInt32(cmd.ExecuteScalar());
            }
        }

        private enum OrdemAcerto { Refer�ncia, D�gito, Peso, Quantidade, �ndice };

        private static void ObterAcerto(string consulta, Dictionary<string, Acerto.SaquinhoAcerto> hash, F�rmulaAcerto f�rmula)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {

                            while (leitor.Read())
                            {
                                string refer�ncia = leitor.GetString((int)OrdemAcerto.Refer�ncia);
                                byte d�gito = leitor.GetByte((int)OrdemAcerto.D�gito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double �ndice = leitor.GetDouble((int)OrdemAcerto.�ndice);

                                SaquinhoAcerto itemNovo = SaquinhoAcerto.Construir(f�rmula, new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, �ndice), 0, peso, �ndice);

                                bool itemJ�Existente;


                                // Item a ser utilizado
                                SaquinhoAcerto item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, null);
                                itemJ�Existente = hash.TryGetValue(itemNovo.Identifica��oAgrup�vel(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJ�Existente)
                                    item = itemNovo;

                                item.QtdRetorno += qtd;

                                if (!itemJ�Existente)
                                    hash.Add(item.Identifica��oAgrup�vel(), item);
                            }
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

        }

        private static void ObterAcerto(string consulta, Dictionary<string, Balan�o.SaquinhoBalan�o> hash)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;

            conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                cmd.CommandText = consulta;

                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    try
                    {
                        using (leitor = cmd.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                string refer�ncia = leitor.GetString((int)OrdemAcerto.Refer�ncia);
                                byte d�gito = leitor.GetByte((int)OrdemAcerto.D�gito);
                                double qtd = leitor.GetDouble((int)OrdemAcerto.Quantidade);
                                double peso = leitor.GetDouble((int)OrdemAcerto.Peso);
                                double �ndice = leitor.GetDouble((int)OrdemAcerto.�ndice);

                                SaquinhoBalan�o itemNovo = new SaquinhoBalan�o(new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, �ndice), 0, peso, �ndice);

                                bool itemJ�Existente;


                                // Item a ser utilizado
                                SaquinhoBalan�o item;

                                Mercadoria.Mercadoria mercadoria = new Mercadoria.Mercadoria(refer�ncia, d�gito, peso, null);
                                itemJ�Existente = hash.TryGetValue(itemNovo.Identifica��oAgrup�vel(), out item);

                                // Primeira vez deste item: utiliza um novinho
                                if (!itemJ�Existente)
                                    item = itemNovo;

                                item.QtdRetorno += qtd;

                                if (!itemJ�Existente)
                                    hash.Add(item.Identifica��oAgrup�vel(), item);
                            }
                        }
                    } finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }

        }


        public static List<long> ObterAcerto(List<long> c�digoRetornos, Dictionary<string, Acerto.SaquinhoAcerto> hash, F�rmulaAcerto f�rmula)
        {
            string consulta;

            if (c�digoRetornos.Count != 0)
            {
                consulta = "select retornoitem.referencia, mercadoria.digito, retornoitem.peso, sum(quantidade) as qtd, retornoitem.indice"
                    + " from retornoitem, retorno, mercadoria WHERE retorno.codigo=retornoitem.retorno AND retorno.codigo IN "
                    + DbTransformarConjunto(c�digoRetornos);
                consulta += " AND mercadoria.referencia=retornoitem.referencia group by referencia, digito, peso, indice having qtd != 0 order by referencia, peso";

                ObterAcerto(consulta, hash, f�rmula);
            }

            return c�digoRetornos;
        }
        

        private enum OrdemRastro { Data, Documento, Quantidade };

        public static void PreencherRastro(Entidades.Mercadoria.Mercadoria mercadoria, Pessoa.Pessoa pessoa, List<RastroItem> lista, List<long> c�digosRetornos)
        {
            IDbConnection conex�o;
            IDataReader leitor = null;

            if (c�digosRetornos.Count == 0)
                return;

            conex�o = Conex�o;

            lock (conex�o)
            {
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
   
                    cmd.CommandText = "select retorno.data, retorno.codigo, sum(retornoitem.quantidade) as qtd from retorno "
                    + ", retornoitem WHERE retornoitem.retorno=retorno.codigo "
                    + " AND referencia=" + DbTransformar(mercadoria.Refer�nciaNum�rica);

                    if (mercadoria.DePeso)
                        cmd.CommandText += " AND peso=" + DbTransformar(mercadoria.Peso);

                    cmd.CommandText += " AND retorno.codigo IN "
                        + DbTransformarConjunto(c�digosRetornos);

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

                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }
        }

        public static Retorno ObterRetorno(long c�digo)
        {
            return ObterRetorno((ulong)c�digo);
        }

        public static Retorno ObterRetorno(ulong c�digo)
        {
            Retorno retorno;

            retorno = Mapear�nicaLinha<Retorno>("SELECT * FROM retorno WHERE "
                + "codigo = " + DbTransformar(c�digo));

            return retorno;
        }

        /// <summary>
        /// Obt�m a data do �ltimo retorno acertado.
        /// </summary>
        /// <returns>Data do �ltimo retorno acertado.</returns>
        public static DateTime ObterData�ltimoRetornoAcertado(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(data) FROM retorno WHERE pessoa = "
                        + DbTransformar(pessoa.C�digo)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is not null) ";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // N�o existem retornos...
                        return DateTime.MinValue;
                    }
                }
        }

        /// <summary>
        /// Obt�m a data do primeiro retorno n�o acertada.
        /// </summary>
        /// <returns>Data do primeiro retorno n�o acertada.</returns>
        public static DateTime ObterDataPrimeiroRetornoN�oAcertado(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM retorno WHERE pessoa = "
                        + DbTransformar(pessoa.C�digo)
                        + " AND acerto in (select codigo from acertoconsignado where dataefetiva is null) ";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // N�o existem retornos...
                        return DateTime.MinValue;
                    }
                }
        }

        public static void TravarV�rios(List<long> c�digos)
        {
            IDbConnection conex�o = Conex�o;

            if (c�digos.Count == 0) return;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "update retorno set travado=1 ";

                    cmd.CommandText += " where codigo IN " + DbTransformarConjunto(c�digos);

                    cmd.ExecuteNonQuery();
                }

        }

        public override string ToString()
        {
            return "Retorno " + C�digo.ToString();
        }

        public static void ObterAcerto(List<long> retornos, Dictionary<string, Balan�o.SaquinhoBalan�o> hash)
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
