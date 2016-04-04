using System;
using Acesso.Comum;
using System.Collections.Generic;
using System.Data;
using Entidades.Acerto;
using System.Collections;
using Entidades.Configura��o;

namespace Entidades.Relacionamento
{
	/// <summary>
	/// N�o chama Consignado porque � gen�rico para sa�da, retorno e venda tamb�m!
	/// </summary>
    [Serializable, DbTransa��o]
	public abstract class Relacionamento : Acesso.Comum.DbManipula��oAutom�tica
	{
        public event DbManipula��o.DbManipula��oHandler AoAlterarTabela;

        [DbRelacionamento("c�digo", "tabela")]
        protected Tabela tabela;

		// Atributos
		[DbAtributo(TipoAtributo.Ignorar)]
		private Hist�ricoRelacionamento	itens = null;

        [DbRelacionamento("codigo", "digitadopor")]
        protected Pessoa.Funcion�rio digitadopor;

		[DbChavePrim�ria(true)]
		protected long                      codigo;

        protected DateTime                  data;

        [DbColuna("observacoes")]
        protected string observa��es;

        
        public delegate void AntesDeCadastrarItemCallback(Hist�ricoRelacionamentoItem item, out bool cancelar);

        /// <summary>
        /// Disparado antes de cadastrar um item.
        /// </summary>
        public event AntesDeCadastrarItemCallback AntesDeCadastrarItem;

        #region Propriedades

        public string Observa��es { get { return observa��es; } set { observa��es = value; DefinirDesatualizado(); } }




        public Tabela TabelaPre�o
        {
            get { return tabela; }
            set
            {
                if (!PermiteAltera��oTabela())
                    throw new Exception("Tabela de pre�os n�o pode ser alterada ap�s inser��o de itens.");

                tabela = value; DefinirDesatualizado();

                if (AoAlterarTabela != null)
                    AoAlterarTabela(this);
            }
        }

        /// <summary>
        /// Verifica se � poss�vel alterar a tabela de pre�os.
        /// </summary>
        /// <returns>Se � permitido a altera��o da tabela de pre�os.</returns>
        public virtual bool PermiteAltera��oTabela()
        {
            return Itens.Count == 0;
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; DefinirDesatualizado(); }
        }

        public Hist�ricoRelacionamento Itens
        {
            get
            {
                if (itens == null)
                {
                    if (Cadastrado)
                    {
                        ArrayList listaCom�nicoElemento = new ArrayList();
                        listaCom�nicoElemento.Add(this);
                        RecuperarCole��es(listaCom�nicoElemento);
                    }
                    else
                        itens = ConstruirItens();
                }

                return itens;
            }
        }

        protected abstract Hist�ricoRelacionamento ConstruirItens();

		public long C�digo
		{
			get { return codigo; }
			set
			{
                DefinirDesatualizado();
				codigo = value;
			}
		}

        public Pessoa.Funcion�rio DigitadoPor
        {
            get { return digitadopor; }
            set
            {
                DefinirDesatualizado();
                digitadopor = value;
            }
        }


        #endregion

        //// Delega��es
        //public delegate Entidades.Relacionamento.Relacionamento ObterRelacionamento(long c�digo);

		public Relacionamento()
		{
            /* Deve-se tomar cuidado em atribui��es na construtoras b�sicas de entidade.
             * Neste comentado abaixo, o Mapear, ao gerar um objeto recem obtido do BD
             * estava mudando a data. Este n�o era o problema, porque a data original seria carregada
             * por cima depois. Por�m a atri��o abaixo torna a entidade recem obtida do bd Desatualizada.
             */
            //this.Data = DateTime.Now;

            /* Andr�, descordo do seu coment�rio acima. O mapear atribui "Cadastrado"
             * e "Atualizado" ao t�rmino do mapear. Estes valores s�o inicialmente
             * sempre falsos, sendo estabelecidos somente ap�s construir o objeto.
             * -- J�lio, 12/07/2006
             */
		}

        /// <summary>
        /// Deve ser chamado pelo RecuperarCole��es()
        /// </summary>
        internal virtual void RecuperarCole��o(IDbCommand  cmd)
        {
            Itens.Recuperar(cmd);
        }

        /// <summary>
        /// Recupera cole��es de um conjunto de relacionamentos.
        /// </summary>
        protected static void RecuperarCole��es(IEnumerable entidades)
        {
            IDbConnection conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                lock (conex�o)
                {
                    /* As cole��es requerem acessar outras tabelas, tais como
                     * Mercadoria e Pessoa. Se uma dessas entidades utilizarem a
                     * mesma conex�o, por estarem na mesma Thread, elas n�o ter�o
                     * acesso ao DataReader.
                     */
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    try
                    {
                        foreach (Entidades.Relacionamento.Relacionamento r in entidades)
                        {
                            r.itens = r.ConstruirItens();
                            r.RecuperarCole��o(cmd);
                        }
                    }
                    finally
                    {
                        Usu�rios.Usu�rioAtual.GerenciadorConex�es.AdicionarConex�o(conex�o);
                    }
                }
            }
        }
        
        public static List<long> ObterC�digos(List<Entidades.Relacionamento.Relacionamento> lista)
        {
            List<long> c�digos = new List<long>(lista.Count);

            foreach (Relacionamento r in lista)
                c�digos.Add(r.C�digo);

            return c�digos;
        }

        protected override void Cadastrar(IDbCommand cmd)
        {
            data = DadosGlobais.Inst�ncia.HoraDataAtual;

            base.Cadastrar(cmd);
        }

        /// <summary>
        /// Dispara evento antes de cadastrar um item.
        /// </summary>
        /// <param name="novoItem">Item a ser cadastrado.</param>
        internal void DispararAntesDeCadastrarItem(Hist�ricoRelacionamentoItem novoItem)
        {
            if (AntesDeCadastrarItem != null)
            {
                bool cancelar;

                AntesDeCadastrarItem(novoItem, out cancelar);

                if (cancelar)
                    throw new Acesso.Comum.Exce��es.Opera��oCancelada(novoItem);
            }
        }

        /// <summary>
        /// Libera recursos computacionais que podem ser recuperados
        /// posteriormente.
        /// </summary>
        public virtual void LiberarRecursos()
        {
            if (Cadastrado)
                itens = null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return obj.GetType() == this.GetType()
            && ((Relacionamento) obj).C�digo == this.C�digo;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
