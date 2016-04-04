using System;
using System.Collections;
using System.Data;

namespace Entidades
{ 
	/// <summary>
	/// O Entidades.Saquinho.Saquinho � usado Bandeja.
	/// Uma bandeja possui v�rios saquinhos.
	/// </summary>
	public class Saquinho : ISaquinho, IComparable
	{
		// Vari�veis do escopo:
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
				throw new Exception("Saquinho n�o pode mudar sua rela��o com mercadoria!");
			}
		}

		#endregion
		
		/// <summary>
		/// Os saquinhos espec�ficos devem retornar uma string 
		/// que seja a mesma para saquinhos agrup�veis
		/// </summary>
		public virtual string Identifica��oAgrup�vel()
		{
			return this.Mercadoria.Refer�ncia + Peso.ToString() + "!" + this.Mercadoria.�ndice.ToString();
		}

		/// <summary>
		/// Atualiza objetos dentro do saquinho
		/// </summary>
		public virtual void AtualizaObjetosIntr�nsecos()
		{
			double pesoCorreto;

			pesoCorreto = Peso;

            mercadoria.ReobterInforma��es();
            mercadoria.Peso = pesoCorreto;
            
			Peso = pesoCorreto;
		}

		public virtual ISaquinho Clone(double novaQuantidade)
		{
			return new Saquinho((Entidades.Mercadoria.Mercadoria) Mercadoria.Clone(), novaQuantidade);
		}
		public override string ToString()
		{
			return "m = " + mercadoria.Refer�ncia + " qtd=" + quantidade.ToString();
		}

        public virtual void PreencherDataRow(DataRow linha)
        {
            linha["refer�ncia"] = Mercadoria.Refer�ncia;
            linha["faixaGrupo"] = (Mercadoria.Faixa != null ? Mercadoria.Faixa : "") + " - " + Mercadoria.Grupo.ToString();
            linha["�ndice"] = Entidades.Mercadoria.Mercadoria.Formatar�ndice(Mercadoria.�ndiceArredondado);
            linha["quantidade"] = Quantidade.ToString();
            linha["peso"] = Mercadoria.PesoFormatado;
            linha["descri��o"] = Mercadoria.Descri��o;
            linha["depeso"] = Mercadoria.DePeso;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            //if (this.mercadoria.DePeso && !this.mercadoria.DePeso)
            //    return 1;
            //else if (!this.mercadoria.DePeso && this.mercadoria.DePeso)
            //    return -1;

            int compara��oRefer�ncias = this.Mercadoria.Refer�nciaNum�rica.CompareTo(((Saquinho)obj).Mercadoria.Refer�nciaNum�rica);

            if (compara��oRefer�ncias != 0)
                return compara��oRefer�ncias;
            else
                return Mercadoria.Peso.CompareTo(((Saquinho)obj).Mercadoria.Peso);

        }

        #endregion
    }
}
