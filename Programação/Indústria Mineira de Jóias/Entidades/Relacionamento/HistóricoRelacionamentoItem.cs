using System;
using System.Collections;
using Acesso.Comum;
using Acesso.Comum.Exce��es;
using System.Collections.Generic;
using Entidades.Pessoa;
using System.Data;

namespace Entidades.Relacionamento
{
	[Serializable]
	public class Hist�ricoRelacionamentoItem : Acesso.Comum.DbManipula��oAutom�tica
	{
		[DbRelacionamento(false, "referencia", "referencia"), DbRelacionamento(false, "peso", "peso")]
		protected Mercadoria.Mercadoria	mercadoria; // 'refer�ncia' no BD

		protected double		quantidade;
        protected DateTime      data;
        protected double        indice;

        [DbChavePrim�ria(true)]
        protected int codigo;

        [DbRelacionamento("codigo", "funcionario")]
        protected Funcion�rio   funcion�rio;

		public Hist�ricoRelacionamentoItem(Mercadoria.Mercadoria mercadoria, double quantidade, DateTime data, Entidades.Pessoa.Funcion�rio funcion�rio, double �ndice)
		{
			this.mercadoria = mercadoria;
			this.quantidade = quantidade;
            this.data = data;
            this.funcion�rio = funcion�rio;
            this.indice = �ndice;
		}

        public int C�digo
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

        public Entidades.Pessoa.Funcion�rio Funcion�rio
        {
            get { return funcion�rio; }
        }

        public double �ndice
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
