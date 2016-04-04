using System;
using System.Collections;
using System.Data;

namespace Entidades
{ 
	/// <summary>
	/// O Entidades.Saquinho.Saquinho é usado Bandeja.
	/// Uma bandeja possui vários saquinhos.
	/// </summary>
	public class Saquinho : ISaquinho, IComparable
	{
		// Variáveis do escopo:
        private Mercadoria.Mercadoria mercadoria;
        private double     quantidade;

		public Saquinho(Entidades.Mercadoria.Mercadoria m, double qtd)
		{
			quantidade = qtd;
			mercadoria = m;
		}

		#region Propriedades

		/// <summary>
		/// Quantidade de mercadorias
		/// </summary>
		public double Quantidade
		{
			get { return quantidade; }
			set { quantidade = value; }
		}

		public virtual double Peso
		{
            get { return mercadoria.Peso;  }
			set { mercadoria.Peso = value; }
		}

		public Entidades.Mercadoria.Mercadoria Mercadoria
		{
			get { return mercadoria; }
			set
			{
				throw new Exception("Saquinho não pode mudar sua relação com mercadoria!");
			}
		}

		#endregion
		
		/// <summary>
		/// Os saquinhos específicos devem retornar uma string 
		/// que seja a mesma para saquinhos agrupáveis
		/// </summary>
		public virtual string IdentificaçãoAgrupável()
		{
			return this.Mercadoria.Referência + Peso.ToString() + "!" + this.Mercadoria.Índice.ToString();
		}

		/// <summary>
		/// Atualiza objetos dentro do saquinho
		/// </summary>
		public virtual void AtualizaObjetosIntrínsecos()
		{
			double pesoCorreto;

			pesoCorreto = Peso;

            mercadoria.ReobterInformações();
            mercadoria.Peso = pesoCorreto;
            
			Peso = pesoCorreto;
		}

		public virtual ISaquinho Clone(double novaQuantidade)
		{
			return new Saquinho((Entidades.Mercadoria.Mercadoria) Mercadoria.Clone(), novaQuantidade);
		}
		public override string ToString()
		{
			return "m = " + mercadoria.Referência + " qtd=" + quantidade.ToString();
		}

        public virtual void PreencherDataRow(DataRow linha)
        {
            linha["referência"] = Mercadoria.Referência;
            linha["faixaGrupo"] = (Mercadoria.Faixa != null ? Mercadoria.Faixa : "") + " - " + Mercadoria.Grupo.ToString();
            linha["índice"] = Entidades.Mercadoria.Mercadoria.FormatarÍndice(Mercadoria.ÍndiceArredondado);
            linha["quantidade"] = Quantidade.ToString();
            linha["peso"] = Mercadoria.PesoFormatado;
            linha["descrição"] = Mercadoria.Descrição;
            linha["depeso"] = Mercadoria.DePeso;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            //if (this.mercadoria.DePeso && !this.mercadoria.DePeso)
            //    return 1;
            //else if (!this.mercadoria.DePeso && this.mercadoria.DePeso)
            //    return -1;

            int comparaçãoReferências = this.Mercadoria.ReferênciaNumérica.CompareTo(((Saquinho)obj).Mercadoria.ReferênciaNumérica);

            if (comparaçãoReferências != 0)
                return comparaçãoReferências;
            else
                return Mercadoria.Peso.CompareTo(((Saquinho)obj).Mercadoria.Peso);

        }

        #endregion
    }
}
