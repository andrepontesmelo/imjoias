using System;
using System.Drawing;
using Entidades.Álbum;
using System.Collections.Generic;
using Entidades.Mercadoria;

namespace Apresentação.Álbum.Edição.Álbuns.Desenhista
{
	/// <summary>
	/// Página do álbum
	/// </summary>
	public class Página
	{
		protected int linhasTexto = 3;

        internal int página = 1;

		/// <summary>
		/// Dimensões da página
		/// </summary>
		private SizeF páginaDimensões;

		/// <summary>
		/// Dimensões de um item
		/// </summary>
		private SizeF itemDimensões;
		private SizeF fotoDimensões;

		/// <summary>
		/// Quantidade de itens
		/// </summary>
		private int colunas = 3, linhas = 5;

		/// <summary>
		/// Espaçamento mínimo entre itens
		/// </summary>
        private float espaçamentoMínimo = 0.787401575f / 3f;
        private float espaçamentoTexto = 0.1f;

		/// <summary>
		/// Plano de fundo
		/// </summary>
		private Image fundo = null;
        private Image fundoCabeçalho = Resource.Modelo_Risco;

		/// <summary>
		/// Margens
		/// </summary>
        private float margemEsquerda = 0.787401575f / 2, margemCabeçalho = 0, margemDireita = 0.787401575f / 2, margemRodapé = 0.787401575f / 2;
        // 0.787401575 = 2cm

		/// <summary>
		/// Fonte
		/// </summary>
		private Font fonte = new Font(FontFamily.GenericSansSerif, 10);
        private Font fonteTítulo = new Font(FontFamily.GenericSansSerif, 14);

		/// <summary>
		/// Constrói uma página
		/// </summary>
		/// <param name="largura">Lagura da página em polegadas.</param>
        /// <param name="altura">Altura da página em polegadas.</param>
		/// <param name="colunas">Quantidade de colunas para itens.</param>
		/// <param name="linhas">Quantidade de linhas para itens.</param>
		public Página(float largura, float altura, int colunas, int linhas)
		{
			páginaDimensões = new SizeF(largura, altura);

			this.colunas = colunas;
			this.linhas  = linhas;
		}

		/// <summary>
		/// Constrói a página sem parâmetros
		/// </summary>
		protected Página()
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
		
		public float MargemCabeçalho
		{
			get { return margemCabeçalho; }
			set { margemCabeçalho = value; }
		}
		
		public float MargemDireita
		{
			get { return margemDireita; }
			set { margemDireita = value; }
		}
		
		public float MargemRodapé
		{
			get { return margemRodapé; }
			set { margemRodapé = value; }
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

		public float EspaçamentoMínimo
		{
			get { return espaçamentoMínimo; }
			set { espaçamentoMínimo = value; }
		}

		#endregion

		/// <summary>
		/// Calcula dimensões para os itens
		/// </summary>
		protected virtual void CalcularDimensõesitem(Graphics g, out SizeF itemDimensões, out SizeF fotoDimensões, float alturaCabeçalho, ItensImpressão itens)
		{
            SizeF tamanhoTexto = g.MeasureString("TjçÇÁÃ", fonte);
            
			itemDimensões = new SizeF(
				(páginaDimensões.Width - margemEsquerda - margemDireita - (colunas  - 1) * espaçamentoMínimo) / colunas,
				(páginaDimensões.Height - alturaCabeçalho - margemRodapé - margemCabeçalho - (linhas - 1) * espaçamentoMínimo) / linhas);

            linhasTexto = 0;

            if ((itens & ItensImpressão.Descrição) > 0)
                linhasTexto++;

            if ((itens & ItensImpressão.Fornecedor) > 0)
                linhasTexto++;

            if ((itens & ItensImpressão.Referência) > 0)
                linhasTexto++;

            if ((itens & ItensImpressão.DescriçãoMercadoria) > 0)
                linhasTexto++;

            if ((itens & (ItensImpressão.FaixaGrupo | ItensImpressão.Índice | ItensImpressão.Peso)) > 0)
                linhasTexto++;

            if ((itens & ItensImpressão.FornecedorReferência) > 0)
                linhasTexto++;

			fotoDimensões = new SizeF(
                itemDimensões.Width, itemDimensões.Height - tamanhoTexto.Height * linhasTexto - espaçamentoTexto);

            if (fotoDimensões.Height <= 0 || fotoDimensões.Width <= 0)
                throw new Exception("Dimensões muito pequenas para impressão.");
		}

		/// <summary>
		/// Imprime conjunto de fotos
		/// </summary>
		/// <param name="fotos">Fotos a serem impressas</param>
		/// <param name="itens">itens a serem impressos</param>
        /// <param name="primeira">Primeira foto a ser impressa.</param>
        /// <returns>Última foto impressa.</returns>
		public int Imprimir(Graphics g, string título, Entidades.Álbum.Foto [] fotos, ItensImpressão itens, int primeira)
		{
			PointF posiçãoAtual = new PointF(margemEsquerda, 0);
            int último = -1;

            g.PageUnit = GraphicsUnit.Inch;

            Apresentação.Pessoa.FormatadorNome.CarregarConstantes();

			// Imprimir fundo
			ImprimirFundo(g);
			
			// Imprimir cabeçalho
			posiçãoAtual.Y = ImprimirCabeçalho(g, título, itens) + margemCabeçalho;

            CalcularDimensõesitem(g, out itemDimensões, out fotoDimensões, posiçãoAtual.Y, itens);

            if (fotos != null)
				for (int i = 0; i < linhas && i * colunas < fotos.Length - primeira; i++)
				{
					for (int j = 0; j < colunas && i * colunas + j < fotos.Length - primeira; j++)
					{
                        último = primeira + i * colunas + j;

						Foto foto = fotos[último];

						ImprimirItem(g, foto, posiçãoAtual, itens);

						posiçãoAtual.X += itemDimensões.Width + espaçamentoMínimo;
					}

					posiçãoAtual.Y += itemDimensões.Height + espaçamentoMínimo;
					posiçãoAtual.X = margemEsquerda;
				}

            último++;

			ImprimirRodapé(g);
            return último;
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
		/// Impressão do plano de fundo
		/// </summary>
		protected virtual void ImprimirFundo(Graphics g)
		{
			if (fundo != null)
				g.DrawImage(fundo, 0, 0, páginaDimensões.Width, páginaDimensões.Height);
		}

		/// <summary>
		/// Imprime cabeçalho do papel
		/// </summary>
		/// <returns>Linha para iniciar impressão de itens</returns>
		protected virtual float ImprimirCabeçalho(Graphics g, string título, ItensImpressão itens)
		{
            float y, pulo;
            SizeF tamanho;

            tamanho = g.MeasureString(título, fonteTítulo);

            if (fundoCabeçalho != null && (itens & ItensImpressão.Logotipo) > 0)
            {
                g.DrawImageUnscaled(fundoCabeçalho, 0, 0);
                y = (fundoCabeçalho.Height / fundoCabeçalho.VerticalResolution - tamanho.Height) / 2;
                pulo = Math.Max(y + tamanho.Height, fundoCabeçalho.Height / fundoCabeçalho.VerticalResolution);
            }
            else
            {
                y = 0;
                pulo = tamanho.Height;
            }

            g.DrawString(título, fonteTítulo, Brushes.Black, new PointF((páginaDimensões.Width - tamanho.Width) / 2, y));

            return pulo;
		}

		/// <summary>
		/// Imprime rodapé do papel
		/// </summary>
		protected virtual void ImprimirRodapé(Graphics g)
		{
            string s = "Pg. " + página.ToString();
            SizeF tamanho = g.MeasureString(s, fonte);

            g.DrawString(s, fonte, Brushes.Black, new PointF(páginaDimensões.Width - tamanho.Width, Math.Min(páginaDimensões.Height, g.ClipBounds.Bottom) - tamanho.Height));

            página++;
		}

		/// <summary>
		/// Imprime item
		/// </summary>
		protected virtual void ImprimirItem(Graphics g, Foto foto, PointF posiçãoAtual, ItensImpressão itens)
		{
			float y = posiçãoAtual.Y;

			// Desenhar foto
			if ((itens & ItensImpressão.Foto) > 0)
			{
				SizeF tamanho;

				if (foto.Imagem.Width / (double)foto.Imagem.Height >= fotoDimensões.Width / (double)fotoDimensões.Height)
					tamanho = new SizeF(fotoDimensões.Width, (float)((float) fotoDimensões.Width * (float) foto.Imagem.Height)/(float)foto.Imagem.Width);
				else
					tamanho = new SizeF((float)((float) foto.Imagem.Width * (float) fotoDimensões.Height / (float) foto.Imagem.Height), fotoDimensões.Height);

#if DEBUG
                if (tamanho.Width > fotoDimensões.Width)
                    throw new Exception("Largura maior que tamanho máximo.");

                if (tamanho.Height > fotoDimensões.Height)
                    throw new Exception("Altura maior que tamanho máximo.");
#endif

				g.DrawImage(foto.Imagem,
					posiçãoAtual.X + (fotoDimensões.Width - tamanho.Width) / 2,
					posiçãoAtual.Y + (fotoDimensões.Height - tamanho.Height) / 2,
					tamanho.Width,
					tamanho.Height);

				y += fotoDimensões.Height;
                y += espaçamentoTexto;
			}

            Entidades.Mercadoria.Mercadoria mercadoria = null;

            if ((itens & (ItensImpressão.RequerMercadoria | ItensImpressão.Referência)) > 0)
                mercadoria = foto.ObterMercadoria();

			// Desenhar referência
            if ((itens & ItensImpressão.Referência) > 0)
                DesenharStringCentralizada(g, foto.ReferênciaFormatada + "-" + mercadoria.Dígito.ToString(), posiçãoAtual.X, ref y, itemDimensões.Width);

            if ((itens & ItensImpressão.FaixaGrupo) > 0)
            {
                string str = "";

                if (mercadoria.Grupo.HasValue)
                    str = string.Format("{0}-{1}", mercadoria.Faixa, mercadoria.Grupo.Value);
                else
                    str = mercadoria.Faixa;

                if ((itens & ItensImpressão.Peso) > 0 && mercadoria.DePeso)
                {
                    if (str.Length > 0)
                        str += " - ";

                    str += string.Format("9{0:###0.0}9", mercadoria.Peso);
                }

                if ((itens & ItensImpressão.Índice) > 0)
                {
                    if (str.Length > 0)
                        str += " - ";

                    str += string.Format(" {0:###,###,##0.00}", mercadoria.ÍndiceArredondado);
                }

                DesenharStringCentralizada(g, str, posiçãoAtual.X, ref y, itemDimensões.Width);
            }
            else if ((itens & ItensImpressão.Peso) > 0 && mercadoria.DePeso)
            {
                string str;

                str = string.Format("9{0:###0.0}9", mercadoria.Peso);

                if (str.Length > 0)
                    str += " - ";

                if ((itens & ItensImpressão.Índice) > 0)
                {
                    if (str.Length > 0)
                        str += " - ";

                    str += string.Format(" {0:###,###,##0.00}", mercadoria.ÍndiceArredondado);
                }

                DesenharStringCentralizada(g, str, posiçãoAtual.X, ref y, itemDimensões.Width);
            }
            else if ((itens & ItensImpressão.Índice) > 0 && mercadoria.ÍndiceArredondado > 0)
            {
                DesenharStringCentralizada(g, string.Format("{0:###,###,##0.00}", mercadoria.ÍndiceArredondado), posiçãoAtual.X, ref y, itemDimensões.Width);
            }

            // Desenhar descrição
            if ((itens & ItensImpressão.Descrição) > 0)
                DesenharStringCentralizada(g, foto.Descrição, posiçãoAtual.X, ref y, itemDimensões.Width);

            if ((itens & ItensImpressão.DescriçãoMercadoria) > 0)
            {
                string str = mercadoria.Descrição.Trim();
                bool formatar = true;

                foreach (char c in str)
                    formatar &= !char.IsLower(c);

                if (formatar)
                    str = Apresentação.Pessoa.FormatadorNome.FormatarTexto(str);

                DesenharStringCentralizada(g, str, posiçãoAtual.X, ref y, itemDimensões.Width);
            }

            // Desenhar fornecedor
            MercadoriaFornecedor fornecedor = Entidades.Mercadoria.MercadoriaFornecedor.ObterFornecedor(mercadoria.ReferênciaNumérica);

            if (fornecedor != null)
            {
                if ((itens & ItensImpressão.Fornecedor) > 0)
                    DesenharStringCentralizada(g, (fornecedor != null ? fornecedor.FornecedorCódigo.ToString() : ""), posiçãoAtual.X, ref y, itemDimensões.Width);

                if ((itens & ItensImpressão.FornecedorReferência) > 0)
                    DesenharStringCentralizada(g, (!String.IsNullOrEmpty(fornecedor.ReferênciaFornecedor) ? fornecedor.ReferênciaFornecedor : ""), posiçãoAtual.X, ref y, itemDimensões.Width);
            }
        }
	}
}
