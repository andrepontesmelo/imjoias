using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Apresentação.Álbum.Edição.Fotos
{
    class TratamentoRemoverFundoComparando : TratamentoBase
    {
        private Bitmap fundo;

        private float tolerância = 10f;

        public Bitmap Fundo
        {
            get { return fundo; }
            set { fundo = new Bitmap((Image) value.Clone()); }
        }

        public float Tolerância
        {
            get { return tolerância; }
            set { tolerância = value; }
        }

        public override Bitmap RealizarTrabalho(Bitmap imagem)
        {
            Bitmap final;
            Bitmap processamento = new Bitmap((Image)imagem.Clone());

			/* Verifica-se todos os pixels da imagem, eliminando
			* as cores de fundo
			*/
            for (int y = 0; y < processamento.Height && !cancelado; y+= 1)
				for (int x = 0; x < processamento.Width && !cancelado; x+= 1)
				{
					Color cor = processamento.GetPixel(x, y);
                    Color fundo = this.fundo.GetPixel(x, y);
                    float diferença;

                    diferença = (Math.Abs(cor.R - fundo.R)
                        + Math.Abs(cor.G - fundo.G)
                        + Math.Abs(cor.B - fundo.B)) / 3f;

                    if (diferença <= tolerância)
						processamento.SetPixel(x, y, Color.FromArgb(0, cor));
				}

            if (cancelado)
                return null;

			// Suavizar transparência
            final = SuavizarTransparência(processamento);
			
            final.Tag = imagem.Clone();

			return final;
        }
    }
}
