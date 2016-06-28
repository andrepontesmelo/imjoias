using System;
using System.Drawing;
using Entidades.�lbum;
using System.Collections.Generic;
using Entidades.Mercadoria;

namespace Apresenta��o.�lbum.Edi��o.�lbuns.Desenhista
{
	/// <summary>
	/// P�gina do �lbum
	/// </summary>
	public class P�gina
	{
		protected int linhasTexto = 3;

        internal int p�gina = 1;

		/// <summary>
		/// Dimens�es da p�gina
		/// </summary>
		private SizeF p�ginaDimens�es;

		/// <summary>
		/// Dimens�es de um item
		/// </summary>
		private SizeF itemDimens�es;
		private SizeF fotoDimens�es;

		/// <summary>
		/// Quantidade de itens
		/// </summary>
		private int colunas = 3, linhas = 5;

		/// <summary>
		/// Espa�amento m�nimo entre itens
		/// </summary>
        private float espa�amentoM�nimo = 0.787401575f / 3f;
        private float espa�amentoTexto = 0.1f;

		/// <summary>
		/// Plano de fundo
		/// </summary>
		private Image fundo = null;
        private Image fundoCabe�alho = Resource.Modelo_Risco;

		/// <summary>
		/// Margens
		/// </summary>
        private float margemEsquerda = 0.787401575f / 2, margemCabe�alho = 0, margemDireita = 0.787401575f / 2, margemRodap� = 0.787401575f / 2;
        // 0.787401575 = 2cm

		/// <summary>
		/// Fonte
		/// </summary>
		private Font fonte = new Font(FontFamily.GenericSansSerif, 10);
        private Font fonteT�tulo = new Font(FontFamily.GenericSansSerif, 14);

		/// <summary>
		/// Constr�i uma p�gina
		/// </summary>
		/// <param name="largura">Lagura da p�gina em polegadas.</param>
        /// <param name="altura">Altura da p�gina em polegadas.</param>
		/// <param name="colunas">Quantidade de colunas para itens.</param>
		/// <param name="linhas">Quantidade de linhas para itens.</param>
		public P�gina(float largura, float altura, int colunas, int linhas)
		{
			p�ginaDimens�es = new SizeF(largura, altura);

			this.colunas = colunas;
			this.linhas  = linhas;
		}

		/// <summary>
		/// Constr�i a p�gina sem par�metros
		/// </summary>
		protected P�gina()
		{
		}

		#region Propriedades

		/// <summary>
		/// Imagem para plano de fundo
		/// </summary>
		public Image Fundo
		{
			get { return fundo; }
			set { fundo = value; }
		}

		public float MargemEsquerda
		{
			get { return MargemEsquerda; }
			set { margemEsquerda = value; }
		}
		
		public float MargemCabe�alho
		{
			get { return margemCabe�alho; }
			set { margemCabe�alho = value; }
		}
		
		public float MargemDireita
		{
			get { return margemDireita; }
			set { margemDireita = value; }
		}
		
		public float MargemRodap�
		{
			get { return margemRodap�; }
			set { margemRodap� = value; }
		}

		public Font Fonte
		{
			get { return fonte; }
			set { fonte = value; }
		}

		public int Colunas
		{
			get { return colunas; }
			set { colunas = value; }
		}

		public int Linhas
		{
			get { return linhas; }
			set { linhas = value; }
		}

		public float Espa�amentoM�nimo
		{
			get { return espa�amentoM�nimo; }
			set { espa�amentoM�nimo = value; }
		}

		#endregion

		/// <summary>
		/// Calcula dimens�es para os itens
		/// </summary>
		protected virtual void CalcularDimens�esitem(Graphics g, out SizeF itemDimens�es, out SizeF fotoDimens�es, float alturaCabe�alho, ItensImpress�o itens)
		{
            SizeF tamanhoTexto = g.MeasureString("Tj����", fonte);
            
			itemDimens�es = new SizeF(
				(p�ginaDimens�es.Width - margemEsquerda - margemDireita - (colunas  - 1) * espa�amentoM�nimo) / colunas,
				(p�ginaDimens�es.Height - alturaCabe�alho - margemRodap� - margemCabe�alho - (linhas - 1) * espa�amentoM�nimo) / linhas);

            linhasTexto = 0;

            if ((itens & ItensImpress�o.Descri��o) > 0)
                linhasTexto++;

            if ((itens & ItensImpress�o.Fornecedor) > 0)
                linhasTexto++;

            if ((itens & ItensImpress�o.Refer�ncia) > 0)
                linhasTexto++;

            if ((itens & ItensImpress�o.Descri��oMercadoria) > 0)
                linhasTexto++;

            if ((itens & (ItensImpress�o.FaixaGrupo | ItensImpress�o.�ndice | ItensImpress�o.Peso)) > 0)
                linhasTexto++;

            if ((itens & ItensImpress�o.FornecedorRefer�ncia) > 0)
                linhasTexto++;

			fotoDimens�es = new SizeF(
                itemDimens�es.Width, itemDimens�es.Height - tamanhoTexto.Height * linhasTexto - espa�amentoTexto);

            if (fotoDimens�es.Height <= 0 || fotoDimens�es.Width <= 0)
                throw new Exception("Dimens�es muito pequenas para impress�o.");
		}

		/// <summary>
		/// Imprime conjunto de fotos
		/// </summary>
		/// <param name="fotos">Fotos a serem impressas</param>
		/// <param name="itens">itens a serem impressos</param>
        /// <param name="primeira">Primeira foto a ser impressa.</param>
        /// <returns>�ltima foto impressa.</returns>
		public int Imprimir(Graphics g, string t�tulo, Entidades.�lbum.Foto [] fotos, ItensImpress�o itens, int primeira)
		{
			PointF posi��oAtual = new PointF(margemEsquerda, 0);
            int �ltimo = -1;

            g.PageUnit = GraphicsUnit.Inch;

            Apresenta��o.Pessoa.FormatadorNome.CarregarConstantes();

			// Imprimir fundo
			ImprimirFundo(g);
			
			// Imprimir cabe�alho
			posi��oAtual.Y = ImprimirCabe�alho(g, t�tulo, itens) + margemCabe�alho;

            CalcularDimens�esitem(g, out itemDimens�es, out fotoDimens�es, posi��oAtual.Y, itens);

            if (fotos != null)
				for (int i = 0; i < linhas && i * colunas < fotos.Length - primeira; i++)
				{
					for (int j = 0; j < colunas && i * colunas + j < fotos.Length - primeira; j++)
					{
                        �ltimo = primeira + i * colunas + j;

						Foto foto = fotos[�ltimo];

						ImprimirItem(g, foto, posi��oAtual, itens);

						posi��oAtual.X += itemDimens�es.Width + espa�amentoM�nimo;
					}

					posi��oAtual.Y += itemDimens�es.Height + espa�amentoM�nimo;
					posi��oAtual.X = margemEsquerda;
				}

            �ltimo++;

			ImprimirRodap�(g);
            return �ltimo;
		}

		/// <summary>
		/// Desenha uma string centralizada
		/// </summary>
		/// <param name="s">String</param>
		private void DesenharStringCentralizada(Graphics g, string s, float x, ref float y, float largura)
		{
			SizeF tamanho = g.MeasureString(s, fonte, new SizeF(largura, float.MaxValue));

			g.DrawString(s, fonte, Brushes.Black, new RectangleF((largura - tamanho.Width) / 2 + x, y, largura, tamanho.Height));

			y += tamanho.Height;
		}

		/// <summary>
		/// Impress�o do plano de fundo
		/// </summary>
		protected virtual void ImprimirFundo(Graphics g)
		{
			if (fundo != null)
				g.DrawImage(fundo, 0, 0, p�ginaDimens�es.Width, p�ginaDimens�es.Height);
		}

		/// <summary>
		/// Imprime cabe�alho do papel
		/// </summary>
		/// <returns>Linha para iniciar impress�o de itens</returns>
		protected virtual float ImprimirCabe�alho(Graphics g, string t�tulo, ItensImpress�o itens)
		{
            float y, pulo;
            SizeF tamanho;

            tamanho = g.MeasureString(t�tulo, fonteT�tulo);

            if (fundoCabe�alho != null && (itens & ItensImpress�o.Logotipo) > 0)
            {
                g.DrawImageUnscaled(fundoCabe�alho, 0, 0);
                y = (fundoCabe�alho.Height / fundoCabe�alho.VerticalResolution - tamanho.Height) / 2;
                pulo = Math.Max(y + tamanho.Height, fundoCabe�alho.Height / fundoCabe�alho.VerticalResolution);
            }
            else
            {
                y = 0;
                pulo = tamanho.Height;
            }

            g.DrawString(t�tulo, fonteT�tulo, Brushes.Black, new PointF((p�ginaDimens�es.Width - tamanho.Width) / 2, y));

            return pulo;
		}

		/// <summary>
		/// Imprime rodap� do papel
		/// </summary>
		protected virtual void ImprimirRodap�(Graphics g)
		{
            string s = "Pg. " + p�gina.ToString();
            SizeF tamanho = g.MeasureString(s, fonte);

            g.DrawString(s, fonte, Brushes.Black, new PointF(p�ginaDimens�es.Width - tamanho.Width, Math.Min(p�ginaDimens�es.Height, g.ClipBounds.Bottom) - tamanho.Height));

            p�gina++;
		}

		/// <summary>
		/// Imprime item
		/// </summary>
		protected virtual void ImprimirItem(Graphics g, Foto foto, PointF posi��oAtual, ItensImpress�o itens)
		{
			float y = posi��oAtual.Y;

			// Desenhar foto
			if ((itens & ItensImpress�o.Foto) > 0)
			{
				SizeF tamanho;

				if (foto.Imagem.Width / (double)foto.Imagem.Height >= fotoDimens�es.Width / (double)fotoDimens�es.Height)
					tamanho = new SizeF(fotoDimens�es.Width, (float)((float) fotoDimens�es.Width * (float) foto.Imagem.Height)/(float)foto.Imagem.Width);
				else
					tamanho = new SizeF((float)((float) foto.Imagem.Width * (float) fotoDimens�es.Height / (float) foto.Imagem.Height), fotoDimens�es.Height);

#if DEBUG
                if (tamanho.Width > fotoDimens�es.Width)
                    throw new Exception("Largura maior que tamanho m�ximo.");

                if (tamanho.Height > fotoDimens�es.Height)
                    throw new Exception("Altura maior que tamanho m�ximo.");
#endif

				g.DrawImage(foto.Imagem,
					posi��oAtual.X + (fotoDimens�es.Width - tamanho.Width) / 2,
					posi��oAtual.Y + (fotoDimens�es.Height - tamanho.Height) / 2,
					tamanho.Width,
					tamanho.Height);

				y += fotoDimens�es.Height;
                y += espa�amentoTexto;
			}

            Entidades.Mercadoria.Mercadoria mercadoria = null;

            if ((itens & (ItensImpress�o.RequerMercadoria | ItensImpress�o.Refer�ncia)) > 0)
                mercadoria = foto.ObterMercadoria();

			// Desenhar refer�ncia
            if ((itens & ItensImpress�o.Refer�ncia) > 0)
                DesenharStringCentralizada(g, foto.Refer�nciaFormatada + "-" + mercadoria.D�gito.ToString(), posi��oAtual.X, ref y, itemDimens�es.Width);

            if ((itens & ItensImpress�o.FaixaGrupo) > 0)
            {
                string str = "";

                if (mercadoria.Grupo.HasValue)
                    str = string.Format("{0}-{1}", mercadoria.Faixa, mercadoria.Grupo.Value);
                else
                    str = mercadoria.Faixa;

                if ((itens & ItensImpress�o.Peso) > 0 && mercadoria.DePeso)
                {
                    if (str.Length > 0)
                        str += " - ";

                    str += string.Format("9{0:###0.0}9", mercadoria.Peso);
                }

                if ((itens & ItensImpress�o.�ndice) > 0)
                {
                    if (str.Length > 0)
                        str += " - ";

                    str += string.Format(" {0:###,###,##0.00}", mercadoria.�ndiceArredondado);
                }

                DesenharStringCentralizada(g, str, posi��oAtual.X, ref y, itemDimens�es.Width);
            }
            else if ((itens & ItensImpress�o.Peso) > 0 && mercadoria.DePeso)
            {
                string str;

                str = string.Format("9{0:###0.0}9", mercadoria.Peso);

                if (str.Length > 0)
                    str += " - ";

                if ((itens & ItensImpress�o.�ndice) > 0)
                {
                    if (str.Length > 0)
                        str += " - ";

                    str += string.Format(" {0:###,###,##0.00}", mercadoria.�ndiceArredondado);
                }

                DesenharStringCentralizada(g, str, posi��oAtual.X, ref y, itemDimens�es.Width);
            }
            else if ((itens & ItensImpress�o.�ndice) > 0 && mercadoria.�ndiceArredondado > 0)
            {
                DesenharStringCentralizada(g, string.Format("{0:###,###,##0.00}", mercadoria.�ndiceArredondado), posi��oAtual.X, ref y, itemDimens�es.Width);
            }

            // Desenhar descri��o
            if ((itens & ItensImpress�o.Descri��o) > 0)
                DesenharStringCentralizada(g, foto.Descri��o, posi��oAtual.X, ref y, itemDimens�es.Width);

            if ((itens & ItensImpress�o.Descri��oMercadoria) > 0)
            {
                string str = mercadoria.Descri��o.Trim();
                bool formatar = true;

                foreach (char c in str)
                    formatar &= !char.IsLower(c);

                if (formatar)
                    str = Apresenta��o.Pessoa.FormatadorNome.FormatarTexto(str);

                DesenharStringCentralizada(g, str, posi��oAtual.X, ref y, itemDimens�es.Width);
            }

            // Desenhar fornecedor
            MercadoriaFornecedor fornecedor = Entidades.Mercadoria.MercadoriaFornecedor.ObterFornecedor(mercadoria.Refer�nciaNum�rica);

            if (fornecedor != null)
            {
                if ((itens & ItensImpress�o.Fornecedor) > 0)
                    DesenharStringCentralizada(g, (fornecedor != null ? fornecedor.FornecedorC�digo.ToString() : ""), posi��oAtual.X, ref y, itemDimens�es.Width);

                if ((itens & ItensImpress�o.FornecedorRefer�ncia) > 0)
                    DesenharStringCentralizada(g, (!String.IsNullOrEmpty(fornecedor.Refer�nciaFornecedor) ? fornecedor.Refer�nciaFornecedor : ""), posi��oAtual.X, ref y, itemDimens�es.Width);
            }
        }
	}
}
