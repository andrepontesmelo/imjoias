using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Collections;
using System.Data;
using Entidades.Mercadoria;

namespace Entidades.Acerto
{
    /// <summary>
    /// Controlador para obten��o do acerto de representante ou consignado
    /// </summary>
    public class Acerto : DbManipula��o 
    {
        /// <summary>
        /// Hash que contm o acerto em s. chave  gerada pela mercadoria oca.
        /// </summary>
        private Dictionary<string, SaquinhoAcerto> hash = new Dictionary<string, SaquinhoAcerto>();

        /// <summary>
        /// � disponibilizada uma vers�o ArrayList da hash:
        /// </summary>
        private ArrayList cole��oSaquinhos;

        /// <summary>
        /// Pessoa para quem est sendo feito o acerto
        /// </summary>
        private Pessoa.Pessoa pessoa;

        /// <summary>
        /// C�digo das entidades consideradas no acerto
        /// </summary>
        private List<long> c�digoVendas, c�digoSa�das, c�digoRetornos;

        public Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        public List<long> C�digoVendas
        {
            get { return c�digoVendas; }
        }

        public List<long> C�digoRetornos
        {
            get { return c�digoRetornos; }
        }

        public List<long> C�digoSa�das
        {
            get { return c�digoSa�das; }
        }

        /// <summary>
        /// Gerado apenas pelo m�todo est�tico ObterAcerto()
        /// </summary>
        private Acerto(Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        private Acerto(List<long> c�digoSa�das, List<long> c�digoRetornos, List<long> c�digoVendas)
        {
            this.c�digoSa�das = c�digoSa�das;
            this.c�digoRetornos = c�digoRetornos;
            this.c�digoVendas = c�digoVendas;
        }


        public ArrayList Cole��oSaquinhos
        {
            get
            {
                // Lista gerada toda vez intencionamente:
                // Na bandeja de acerto, a lista � modificada quando usu�rio solicita filtragem.
                // Ao utilizar esta propriedade em mais locais, modificar implementa��o da filtragem.
                //if (cole��oSaquinhos == null)
                //{
                    cole��oSaquinhos = new ArrayList(hash.Count);

                    foreach (KeyValuePair<string, Entidades.Acerto.SaquinhoAcerto> tupla in hash)
                        cole��oSaquinhos.Add(tupla.Value);
                //}

                return cole��oSaquinhos;
            }
        }

        /* O c�digo abaixo n�o � necess�rio, visto que
         * todas as mercadorias s�o recuperadas do banco de dados
         * e inseridas na �rvore, de onde ser�o recuperadas quando ocas.
         * -- J�lio, 27/09/2006
         */
        ///// <summary>
        ///// Recupera��o as mercadoriasOcas da hash, 
        ///// pois todas elas ser�o inseridas na bandeja, que perguntam por propriedades
        ///// pr�prias da mercadoria.
        ///// </summary>
        //private void RecuperarMercadorias()
        //{
        //    ArrayList listaSaquinhos;
        //    ArrayList listaMercadoriasOca;


        //    listaSaquinhos = Cole��oSaquinhos;
            
        //    listaMercadoriasOca = new ArrayList(listaSaquinhos.Count);
            
        //    foreach (SaquinhoAcerto s in listaSaquinhos)
        //        listaMercadoriasOca.Add(s.Mercadoria);

        //    MercadoriaOca.RecuperarV�rios(listaMercadoriasOca);
        //}


        public static Acerto ObterAcerto(Pessoa.Pessoa p, List<Entidades.Relacionamento.Relacionamento> sa�das, List<Entidades.Relacionamento.Relacionamento> retornos, List<Entidades.Relacionamento.Venda.IDadosVenda> vendas)
        {
            Acerto novoAcerto;

            novoAcerto = new Acerto(p);

            novoAcerto.c�digoSa�das = Entidades.Relacionamento.Relacionamento.ObterC�digos(sa�das);
            novoAcerto.c�digoRetornos = Entidades.Relacionamento.Relacionamento.ObterC�digos(retornos);
            novoAcerto.c�digoVendas = Entidades.Relacionamento.Venda.Venda.ObterC�digos(vendas);

            Entidades.Relacionamento.Sa�da.Sa�da.ObterAcerto(novoAcerto.c�digoSa�das, novoAcerto.hash);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(novoAcerto.c�digoRetornos, novoAcerto.hash);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(novoAcerto.c�digoVendas, novoAcerto.hash);


            //novoAcerto.RecuperarMercadorias();

            return novoAcerto;
        }

        public static Acerto ObterAcerto(List<long> c�digoSa�das, List<long> c�digoRetornos, List<long> c�digoVendas)
        {
            Acerto novoAcerto;

            novoAcerto = new Acerto(c�digoSa�das, c�digoRetornos, c�digoVendas);

            Entidades.Relacionamento.Sa�da.Sa�da.ObterAcerto(c�digoSa�das, novoAcerto.hash);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(c�digoRetornos, novoAcerto.hash);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(c�digoVendas, novoAcerto.hash);

            //novoAcerto.RecuperarMercadorias();

            return novoAcerto;
        }


        #region M�todos do DbManipula��o

        protected override void Cadastrar(System.Data.IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Atualizar(System.Data.IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Descadastrar(System.Data.IDbCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        public System.Data.DataSet ObterImpress�o(bool resumido)
        {   
            System.Data.DataSet ds = new System.Data.DataSet();
            DataTable tabelaItens = new DataTable("Itens");
            DataTable tabelaInforma��es = new DataTable("Informa��es");

            //// Gera as colunas da tabela
            //DataColumn colRef = new DataColumn("refer�ncia", typeof(string));
            //DataColumn colPeso = new DataColumn("peso", typeof(string));
            //DataColumn colQtd = new DataColumn("quantidade", typeof(string));
            //DataColumn colFaixa = new DataColumn("faixa", typeof(string));
            //DataColumn colGrupo = new DataColumn("grupo", typeof(string));
            //DataColumn colIndice = new DataColumn("�ndice", typeof(string));
            //DataColumn colDescri��o = new DataColumn("descri��o", typeof(string));


            tabelaItens.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("refer�ncia"),
                new DataColumn("peso"),
                new DataColumn("quantidade"),
                new DataColumn("sa�da"),
                new DataColumn("retorno"),
                new DataColumn("venda"),
                new DataColumn("acerto"),
                new DataColumn("depeso", typeof(bool)),
                new DataColumn("faixagrupo")
            });

            List<SaquinhoAcerto> lista = new List<SaquinhoAcerto>();

            foreach (KeyValuePair<string, SaquinhoAcerto> tupla in hash)
            {
                // Adiciona saquinho � uma lista ordenada por refer�ncia.
                if ((resumido && tupla.Value.QtdAcerto != 0) || (!resumido))
                    lista.Add(tupla.Value);
            }

            // Ordena lista por refer�ncia e peso.
            lista.Sort(new SaquinhoAcertoComparador());

            foreach (SaquinhoAcerto s in lista)
            {
                DataRow linha = tabelaItens.NewRow();
                s.PreencherDataRow(linha);
                tabelaItens.Rows.Add(linha);
            }

            // Cria coluna pessoa, que � para quem est� sendo feito o acerto
            DataColumn colPessoa = new DataColumn("pessoa", typeof(string));
            DataColumn colFuncion�rio = new DataColumn("funcion�rio", typeof(string));
            DataColumn colSa�das = new DataColumn("sa�das", typeof(string));
            DataColumn colRetornos = new DataColumn("retornos", typeof(string));
            DataColumn colVendas = new DataColumn("vendas", typeof(string));

            tabelaInforma��es.Columns.Add(colPessoa);
            tabelaInforma��es.Columns.Add(colFuncion�rio);
            tabelaInforma��es.Columns.Add(colSa�das);
            tabelaInforma��es.Columns.Add(colRetornos);
            tabelaInforma��es.Columns.Add(colVendas);

            // Escreve um item �nico
            DataRow item�nico = tabelaInforma��es.NewRow();
            item�nico[colPessoa] = pessoa.Nome;
            item�nico[colFuncion�rio] = Entidades.Pessoa.Funcion�rio.Funcion�rioAtual;
            tabelaInforma��es.Rows.Add(item�nico);

            // Descreve sa�das
            bool primeiro = true;
            foreach (long codSa�da in c�digoSa�das)
            {
                if (!primeiro)
                    item�nico[colSa�das] += ", ";
                else
                    primeiro = false;

                item�nico[colSa�das] += codSa�da.ToString();
            }

            // Descreve retornos
            primeiro = true;
            foreach (long codRetorno in c�digoRetornos)
            {
                if (!primeiro)
                    item�nico[colRetornos] += ", ";
                else
                    primeiro = false;

                item�nico[colRetornos] += codRetorno.ToString();
            }


            List<string> c�digoFormatadoVendas = Entidades.Relacionamento.Venda.Venda.ObterC�digoVendas(c�digoVendas);

            // Descreve vendas
            primeiro = true;
            foreach (string codVenda in c�digoFormatadoVendas)
            {
                if (!primeiro)
                    item�nico[colVendas] += ", ";
                else
                    primeiro = false;

                item�nico[colVendas] += codVenda;
            }

            // Adiciona as tabelas ao dataset.
            ds.Tables.Add(tabelaItens);
            ds.Tables.Add(tabelaInforma��es);

            return ds;
        }


        /// <summary>
        /// Preenche o rastro parte do rastro 'lista', olhando todos os documentos
        /// do tipo deste objeto. 
        /// </summary>
        public List<RastroItem> ObterRastro(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            List<RastroItem> lista = new List<RastroItem>();

            Entidades.Relacionamento.Venda.Venda.PreencherRastro(mercadoria, pessoa, lista, c�digoVendas);
            Entidades.Relacionamento.Sa�da.Sa�da.PreencherRastro(mercadoria, pessoa, lista, c�digoSa�das);
            Entidades.Relacionamento.Retorno.Retorno.PreencherRastro(mercadoria, pessoa, lista, c�digoRetornos);

            return lista;
        }

        public void Acertar()
        {
            IDbConnection conex�o;

            Privil�gio.Permiss�oFuncion�rio.AssegurarPermiss�o(Entidades.Privil�gio.Permiss�o.ZerarAcerto);

            conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.Transaction = conex�o.BeginTransaction();

                    try
                    {
                        Entidades.Relacionamento.Venda.Venda.Acertar(this, cmd);
                        Entidades.Relacionamento.Sa�da.Sa�da.Acertar(this, cmd);
                        Entidades.Relacionamento.Retorno.Retorno.Acertar(this, cmd);
                        cmd.Transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        cmd.Transaction.Rollback();
                        throw new Exception("N�o foi poss�vel concluir a transa��o.", e);
                    }
                }
        }

        /// <summary>
        /// Obt�m data do primeiro documento n�o acertado.
        /// </summary>
        public static DateTime? ObterPrimeiraDataN�oAcertada(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conex�o = Conex�o;

            lock (conex�o)
                using (IDbCommand cmd = conex�o.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM "
                        + "((SELECT data FROM saida WHERE pessoa = " + DbTransformar(pessoa.C�digo) + " AND acertado = 0)"
                        + " UNION (SELECT data FROM venda WHERE " 
                        + ((Entidades.Pessoa.Representante.�Representante(pessoa) ||
                           Entidades.Pessoa.Funcion�rio.�Funcion�rio(pessoa)) ? "vendedor" : "cliente")
                        + " = " + DbTransformar(pessoa.C�digo) + " AND acertado = 0)"
                        + " UNION (SELECT data FROM retorno WHERE pessoa = " + DbTransformar(pessoa.C�digo) + " AND acertado = 0)"
                        +") documentos";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // N�o existem sa�das...
                        return null;
                    }
                }
        }
    }
}
