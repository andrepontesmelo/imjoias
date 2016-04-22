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
    /// Controlador para obtenção do acerto de representante ou consignado
    /// </summary>
    public class Acerto : DbManipulação 
    {
        /// <summary>
        /// Hash que contm o acerto em s. chave  gerada pela mercadoria oca.
        /// </summary>
        private Dictionary<string, SaquinhoAcerto> hash = new Dictionary<string, SaquinhoAcerto>();

        /// <summary>
        /// É disponibilizada uma versão ArrayList da hash:
        /// </summary>
        private ArrayList coleçãoSaquinhos;

        /// <summary>
        /// Pessoa para quem est sendo feito o acerto
        /// </summary>
        private Pessoa.Pessoa pessoa;

        /// <summary>
        /// Código das entidades consideradas no acerto
        /// </summary>
        private List<long> códigoVendas, códigoSaídas, códigoRetornos;

        public Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        public List<long> CódigoVendas
        {
            get { return códigoVendas; }
        }

        public List<long> CódigoRetornos
        {
            get { return códigoRetornos; }
        }

        public List<long> CódigoSaídas
        {
            get { return códigoSaídas; }
        }

        /// <summary>
        /// Gerado apenas pelo método estático ObterAcerto()
        /// </summary>
        private Acerto(Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        private Acerto(List<long> códigoSaídas, List<long> códigoRetornos, List<long> códigoVendas)
        {
            this.códigoSaídas = códigoSaídas;
            this.códigoRetornos = códigoRetornos;
            this.códigoVendas = códigoVendas;
        }


        public ArrayList ColeçãoSaquinhos
        {
            get
            {
                // Lista gerada toda vez intencionamente:
                // Na bandeja de acerto, a lista é modificada quando usuário solicita filtragem.
                // Ao utilizar esta propriedade em mais locais, modificar implementação da filtragem.
                //if (coleçãoSaquinhos == null)
                //{
                    coleçãoSaquinhos = new ArrayList(hash.Count);

                    foreach (KeyValuePair<string, Entidades.Acerto.SaquinhoAcerto> tupla in hash)
                        coleçãoSaquinhos.Add(tupla.Value);
                //}

                return coleçãoSaquinhos;
            }
        }

        /* O código abaixo não é necessário, visto que
         * todas as mercadorias são recuperadas do banco de dados
         * e inseridas na árvore, de onde serão recuperadas quando ocas.
         * -- Júlio, 27/09/2006
         */
        ///// <summary>
        ///// Recuperação as mercadoriasOcas da hash, 
        ///// pois todas elas serão inseridas na bandeja, que perguntam por propriedades
        ///// próprias da mercadoria.
        ///// </summary>
        //private void RecuperarMercadorias()
        //{
        //    ArrayList listaSaquinhos;
        //    ArrayList listaMercadoriasOca;


        //    listaSaquinhos = ColeçãoSaquinhos;
            
        //    listaMercadoriasOca = new ArrayList(listaSaquinhos.Count);
            
        //    foreach (SaquinhoAcerto s in listaSaquinhos)
        //        listaMercadoriasOca.Add(s.Mercadoria);

        //    MercadoriaOca.RecuperarVários(listaMercadoriasOca);
        //}


        public static Acerto ObterAcerto(Pessoa.Pessoa p, List<Entidades.Relacionamento.Relacionamento> saídas, List<Entidades.Relacionamento.Relacionamento> retornos, List<Entidades.Relacionamento.Venda.IDadosVenda> vendas)
        {
            Acerto novoAcerto;

            novoAcerto = new Acerto(p);

            novoAcerto.códigoSaídas = Entidades.Relacionamento.Relacionamento.ObterCódigos(saídas);
            novoAcerto.códigoRetornos = Entidades.Relacionamento.Relacionamento.ObterCódigos(retornos);
            novoAcerto.códigoVendas = Entidades.Relacionamento.Venda.Venda.ObterCódigos(vendas);

            Entidades.Relacionamento.Saída.Saída.ObterAcerto(novoAcerto.códigoSaídas, novoAcerto.hash);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(novoAcerto.códigoRetornos, novoAcerto.hash);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(novoAcerto.códigoVendas, novoAcerto.hash);


            //novoAcerto.RecuperarMercadorias();

            return novoAcerto;
        }

        public static Acerto ObterAcerto(List<long> códigoSaídas, List<long> códigoRetornos, List<long> códigoVendas)
        {
            Acerto novoAcerto;

            novoAcerto = new Acerto(códigoSaídas, códigoRetornos, códigoVendas);

            Entidades.Relacionamento.Saída.Saída.ObterAcerto(códigoSaídas, novoAcerto.hash);
            Entidades.Relacionamento.Retorno.Retorno.ObterAcerto(códigoRetornos, novoAcerto.hash);
            Entidades.Relacionamento.Venda.Venda.ObterAcerto(códigoVendas, novoAcerto.hash);

            //novoAcerto.RecuperarMercadorias();

            return novoAcerto;
        }


        #region Métodos do DbManipulação

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

        public System.Data.DataSet ObterImpressão(bool resumido)
        {   
            System.Data.DataSet ds = new System.Data.DataSet();
            DataTable tabelaItens = new DataTable("Itens");
            DataTable tabelaInformações = new DataTable("Informações");

            //// Gera as colunas da tabela
            //DataColumn colRef = new DataColumn("referência", typeof(string));
            //DataColumn colPeso = new DataColumn("peso", typeof(string));
            //DataColumn colQtd = new DataColumn("quantidade", typeof(string));
            //DataColumn colFaixa = new DataColumn("faixa", typeof(string));
            //DataColumn colGrupo = new DataColumn("grupo", typeof(string));
            //DataColumn colIndice = new DataColumn("índice", typeof(string));
            //DataColumn colDescrição = new DataColumn("descrição", typeof(string));


            tabelaItens.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("referência"),
                new DataColumn("peso"),
                new DataColumn("quantidade"),
                new DataColumn("saída"),
                new DataColumn("retorno"),
                new DataColumn("venda"),
                new DataColumn("acerto"),
                new DataColumn("depeso", typeof(bool)),
                new DataColumn("faixagrupo")
            });

            List<SaquinhoAcerto> lista = new List<SaquinhoAcerto>();

            foreach (KeyValuePair<string, SaquinhoAcerto> tupla in hash)
            {
                // Adiciona saquinho à uma lista ordenada por referência.
                if ((resumido && tupla.Value.QtdAcerto != 0) || (!resumido))
                    lista.Add(tupla.Value);
            }

            // Ordena lista por referência e peso.
            lista.Sort(new SaquinhoAcertoComparador());

            foreach (SaquinhoAcerto s in lista)
            {
                DataRow linha = tabelaItens.NewRow();
                s.PreencherDataRow(linha);
                tabelaItens.Rows.Add(linha);
            }

            // Cria coluna pessoa, que é para quem está sendo feito o acerto
            DataColumn colPessoa = new DataColumn("pessoa", typeof(string));
            DataColumn colFuncionário = new DataColumn("funcionário", typeof(string));
            DataColumn colSaídas = new DataColumn("saídas", typeof(string));
            DataColumn colRetornos = new DataColumn("retornos", typeof(string));
            DataColumn colVendas = new DataColumn("vendas", typeof(string));

            tabelaInformações.Columns.Add(colPessoa);
            tabelaInformações.Columns.Add(colFuncionário);
            tabelaInformações.Columns.Add(colSaídas);
            tabelaInformações.Columns.Add(colRetornos);
            tabelaInformações.Columns.Add(colVendas);

            // Escreve um item único
            DataRow itemÚnico = tabelaInformações.NewRow();
            itemÚnico[colPessoa] = pessoa.Nome;
            itemÚnico[colFuncionário] = Entidades.Pessoa.Funcionário.FuncionárioAtual;
            tabelaInformações.Rows.Add(itemÚnico);

            // Descreve saídas
            bool primeiro = true;
            foreach (long codSaída in códigoSaídas)
            {
                if (!primeiro)
                    itemÚnico[colSaídas] += ", ";
                else
                    primeiro = false;

                itemÚnico[colSaídas] += codSaída.ToString();
            }

            // Descreve retornos
            primeiro = true;
            foreach (long codRetorno in códigoRetornos)
            {
                if (!primeiro)
                    itemÚnico[colRetornos] += ", ";
                else
                    primeiro = false;

                itemÚnico[colRetornos] += codRetorno.ToString();
            }


            List<string> códigoFormatadoVendas = Entidades.Relacionamento.Venda.Venda.ObterCódigoVendas(códigoVendas);

            // Descreve vendas
            primeiro = true;
            foreach (string codVenda in códigoFormatadoVendas)
            {
                if (!primeiro)
                    itemÚnico[colVendas] += ", ";
                else
                    primeiro = false;

                itemÚnico[colVendas] += codVenda;
            }

            // Adiciona as tabelas ao dataset.
            ds.Tables.Add(tabelaItens);
            ds.Tables.Add(tabelaInformações);

            return ds;
        }


        /// <summary>
        /// Preenche o rastro parte do rastro 'lista', olhando todos os documentos
        /// do tipo deste objeto. 
        /// </summary>
        public List<RastroItem> ObterRastro(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            List<RastroItem> lista = new List<RastroItem>();

            Entidades.Relacionamento.Venda.Venda.PreencherRastro(mercadoria, pessoa, lista, códigoVendas);
            Entidades.Relacionamento.Saída.Saída.PreencherRastro(mercadoria, pessoa, lista, códigoSaídas);
            Entidades.Relacionamento.Retorno.Retorno.PreencherRastro(mercadoria, pessoa, lista, códigoRetornos);

            return lista;
        }

        public void Acertar()
        {
            IDbConnection conexão;

            Privilégio.PermissãoFuncionário.AssegurarPermissão(Entidades.Privilégio.Permissão.ZerarAcerto);

            conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.Transaction = conexão.BeginTransaction();

                    try
                    {
                        Entidades.Relacionamento.Venda.Venda.Acertar(this, cmd);
                        Entidades.Relacionamento.Saída.Saída.Acertar(this, cmd);
                        Entidades.Relacionamento.Retorno.Retorno.Acertar(this, cmd);
                        cmd.Transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        cmd.Transaction.Rollback();
                        throw new Exception("Não foi possível concluir a transação.", e);
                    }
                }
        }

        /// <summary>
        /// Obtém data do primeiro documento não acertado.
        /// </summary>
        public static DateTime? ObterPrimeiraDataNãoAcertada(Entidades.Pessoa.Pessoa pessoa)
        {
            IDbConnection conexão = Conexão;

            lock (conexão)
                using (IDbCommand cmd = conexão.CreateCommand())
                {
                    cmd.CommandText = "SELECT MIN(data) FROM "
                        + "((SELECT data FROM saida WHERE pessoa = " + DbTransformar(pessoa.Código) + " AND acertado = 0)"
                        + " UNION (SELECT data FROM venda WHERE " 
                        + ((Entidades.Pessoa.Representante.ÉRepresentante(pessoa) ||
                           Entidades.Pessoa.Funcionário.ÉFuncionário(pessoa)) ? "vendedor" : "cliente")
                        + " = " + DbTransformar(pessoa.Código) + " AND acertado = 0)"
                        + " UNION (SELECT data FROM retorno WHERE pessoa = " + DbTransformar(pessoa.Código) + " AND acertado = 0)"
                        +") documentos";

                    try
                    {
                        return Convert.ToDateTime(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        // Não existem saídas...
                        return null;
                    }
                }
        }
    }
}
