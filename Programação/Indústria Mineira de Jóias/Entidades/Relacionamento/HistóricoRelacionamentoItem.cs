using System;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Exceções;
using System.Collections.Generic;
using Entidades.Pessoa;
using System.Data;

namespace Entidades.Relacionamento
{
	[Serializable]
	public class HistóricoRelacionamentoItem : Acesso.Comum.DbManipulaçãoAutomática
	{
		[DbRelacionamento(false, "referencia", "referencia"), DbRelacionamento(false, "peso", "peso")]
		protected Mercadoria.Mercadoria	mercadoria; // 'referência' no BD

		protected double		quantidade;
        protected DateTime      data;
        protected double        indice;

        [DbChavePrimária(true)]
        protected int codigo;

        [DbRelacionamento("codigo", "funcionario")]
        protected Funcionário   funcionário;

		public HistóricoRelacionamentoItem(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcionário funcionário, double índice)
		{
			this.mercadoria = mercadoria;
			this.quantidade = quantidade;
            this.data = data;
            this.funcionário = funcionário;
            this.indice = índice;
		}

        public int Código
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Mercadoria.Mercadoria Mercadoria
        {
            get { return mercadoria; }
        }

		public double Quantidade
		{
			get { return quantidade; }
		}
        public DateTime Data
        {
            get { return data; }
        }

        public Entidades.Pessoa.Funcionário Funcionário
        {
            get { return funcionário; }
        }

        public double Índice
        {
            get { return Math.Round(indice,2); }
            set { indice = value; }
        }
        
        protected override void  Atualizar(IDbCommand cmd)
        {
            throw new NotSupportedException();
        }

        protected override void Descadastrar(IDbCommand cmd)
        {
            throw new NotSupportedException();
        }
    }
}
