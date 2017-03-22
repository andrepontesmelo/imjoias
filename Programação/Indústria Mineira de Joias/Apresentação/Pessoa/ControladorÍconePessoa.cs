using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Entidades.Pessoa;
using Entidades;
using System.Drawing.Drawing2D;


namespace Apresentação.Pessoa
{
    public class ControladorÍconePessoa
    {
        /// <summary>
        /// A caixa corresponde ao ícone inteiro, com a borda.
        /// </summary>
        private static readonly int larguraCaixa = 57;
        private static readonly int alturaCaixa = 68;

        /// <summary>
        /// As dimensões do ícone devem ser as mesmas da figura para não perder qualidade redimensionando.
        /// </summary>
        private static readonly int larguraÍcone = 49;
        private static readonly int alturaÍcone = 65;

        public static Bitmap ObterÍcone(Entidades.Pessoa.Pessoa pessoa)
        {
            if (pessoa == null)
                return null;

            if (Representante.ÉRepresentante(pessoa))
                return Resource.malaimj;
            else if (pessoa is PessoaJurídica)
                return Resource.predios;
            else if (((PessoaFísica)pessoa).Sexo == Sexo.Feminino)
            {
                //if (pessoa.Setor != null
                //    && pessoa.Setor.Código == Setor.ObterSetor(SetorSistema.Varejo).Código)
                //    return Resources.mulherrosa;
                //else
                //    return Resources.mulherpreto;

                return Resource.mulherpreto;
            }
            else
            {
                //if (pessoa.Setor != null &&
                //    pessoa.Setor.Código == Setor.ObterSetor(SetorSistema.Varejo).Código)
                //    return Resources.homemrosa;
                //else
                //    return Resources.homempreto;

                return Resource.homempreto;
            }
        }

        private static Font fonteTexto = new Font("Calibri", 9f);

        public static Bitmap ObterÍconeComFundoECódigo(Entidades.Pessoa.Pessoa pessoa)
        {
            
            Bitmap ícone = ObterÍcone(pessoa);
            Bitmap novo = new Bitmap(larguraCaixa, alturaCaixa);
            Graphics desenhador = Graphics.FromImage(novo);
            //desenhador.FillPath(.DrawCurve(.DrawClosedCurve(Pens.AliceBlue, 23, 2, System.Drawing.Drawing2D.FillMode.
            //desenhador.Clear(Color.FromArgb(192, 192, 255));


            desenhador.Clear(Color.Black);
            //Cria retângulo na posição 10,10 com 50 por 50
            Rectangle rect = new Rectangle(0, 0, larguraCaixa, alturaCaixa);

            Color corFundo;

            if (pessoa.Setor != null &&
                pessoa.Setor.Código == Setor.ObterSetor(SetorSistema.Varejo).Código)
                corFundo = Color.Gray;
            else if (pessoa.Setor != null &&
                pessoa.Setor.Código == Setor.ObterSetor(SetorSistema.AltoAtacado).Código)
                corFundo = Color.BlueViolet;
            else
                corFundo = Color.DarkGreen;

            LinearGradientBrush linBrush = new LinearGradientBrush(rect, corFundo, Color.FromArgb(224, 224, 224), LinearGradientMode.ForwardDiagonal);
            
            //cria o degrade no retângulo
            desenhador.FillRectangle(linBrush, rect);
            
            //imprime retângulo
            //e.FillRectangle(linBrush, rect);

            //desenhador.Clear(Color.FromKnownColor(KnownColor.DarkOliveGreen));

            desenhador.DrawImage(ícone, (larguraCaixa - larguraÍcone) / 2, -4 + (alturaCaixa - alturaÍcone) / 2, larguraÍcone, alturaÍcone);
            //desenhador.DrawImage(ícone, 0, 0);

            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            
            SizeF tamanhoTexto = desenhador.MeasureString(pessoa.Código.ToString(), fonteTexto);

            desenhador.DrawString(pessoa.Código.ToString(), fonteTexto, Brushes.Black,
                new RectangleF(0, alturaCaixa - tamanhoTexto.Height, larguraCaixa, tamanhoTexto.Height), formato);

            return novo;
        }
    }
}
