using Acesso.Comum;
using Entidades.Configura��o;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Relacionamento
{
    [Serializable, DbTransa��o]
	public abstract class Relacionamento : DbManipula��oAutom�tica
	{
        public event DbManipula��oHandler AoAlterarTabela;

        [DbRelacionamento("c�digo", "tabela")]
        protected Tabela tabela;

		[DbAtributo(TipoAtributo.Ignorar)]
		private Hist�ricoRelacionamento	itens = null;

        [DbRelacionamento("codigo", "digitadopor")]
        protected Pessoa.Funcion�rio digitadopor;

		[DbChavePrim�ria(true)]
		protected long codigo;

        protected DateTime data;

        [DbColuna("observacoes")]
        protected string observa��es;
        
        public delegate void AntesDeCadastrarItemCallback(Hist�ricoRelacionamentoItem item, out bool cancelar);

        public event AntesDeCadastrarItemCallback AntesDeCadastrarItem;

        public string Observa��es
        {
            get { return observa��es; }
            set { observa��es = value; DefinirDesatualizado(); }
        }

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

		public Relacionamento()
		{
		}

        internal virtual void RecuperarCole��o(IDbCommand  cmd)
        {
            Itens.Recuperar(cmd);
        }

        protected static void RecuperarCole��es(IEnumerable entidades)
        {
            IDbConnection conex�o = Conex�o;

            using (IDbCommand cmd = conex�o.CreateCommand())
            {
                lock (conex�o)
                {
                    Usu�rios.Usu�rioAtual.GerenciadorConex�es.RemoverConex�o(conex�o);

                    try
                    {
                        foreach (Relacionamento r in entidades)
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
        
        public static List<long> ObterC�digos(List<Relacionamento> lista)
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
