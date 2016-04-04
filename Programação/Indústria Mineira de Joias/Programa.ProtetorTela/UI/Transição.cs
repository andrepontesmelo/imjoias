//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Drawing;
//using System.Windows.Forms;
//using Entidades;

//namespace Programa.ProtetorTela.UI
//{
//    class Transição : IDisposable
//    {
//        /// <summary>
//        /// Vetor de mercadorias a ser exibido.
//        /// </summary>
//        private Mercadoria[] mercadorias;

//        /// <summary>
//        /// Próximo modo que será utilizado.
//        /// </summary>
//        private ScreenSaverForm.Modo próximoModo;

//        /// <summary>
//        /// Deslocamento dos ícones das mercadorias.
//        /// </summary>
//        private int deslocamento = 0;

//        /// <summary>
//        /// Cor de fundo.
//        /// </summary>
//        private Color backColor;

//        /// <summary>
//        /// Tamanho da área de desenho.
//        /// </summary>
//        private Size size;

//        /// <summary>
//        /// Localização da área de desenho.
//        /// </summary>
//        private Point location;

//        private Timer tmrDeslocamento;

//        public event EventHandler Concluído;
//        public event EventHandler Atualizado;

//        #region Propriedades

//        public Color BackColor { get { return backColor; } set { backColor = value; } }
//        public Point Location { get { return location; } set { location = value; } }
//        public Size Size
//        {
//            get { return size; }
//            set { size = value; }
//        }

//        public ScreenSaverForm.Modo PróximoModo
//        {
//            get { return próximoModo; }
//            set { próximoModo = value; }
//        }

//        #endregion

//        /// <summary>
//        /// Constrói a transição.
//        /// </summary>
//        public Transição()
//        {
//            mercadorias = Mercadoria.ObterMercadoriasExibição(15);

//            Mercadoria.ObterÍcones(this.mercadorias);
//        }

//        public void Reiniciar()
//        {
//            mercadorias = Mercadoria.ObterMercadoriasExibição(15);
//        }

//        /// <summary>
//        /// Libera recursos de memória.
//        /// </summary>
//        public void Dispose()
//        {
//            foreach (Mercadoria mercadoria in mercadorias)
//                mercadoria.Dispose();

//            if (tmrDeslocamento != null)
//                tmrDeslocamento.Dispose();
//        }

//        /// <summary>
//        /// Desenha a transição.
//        /// </summary>
//        public void Desenhar(PaintEventArgs e)
//        {
//            int pri, últ;           // Índice da primeira e última imagem a ser exibida

//            if (tmrDeslocamento == null)
//            {
//                tmrDeslocamento = new Timer();
//                tmrDeslocamento.Tick += new EventHandler(tmrDeslocamento_Tick);
//                tmrDeslocamento.Interval = 40;
//                tmrDeslocamento.Enabled = true;
//            }

//            pri = Math.Max(0, (deslocamento - Size.Width) / Entidades.Álbum.Foto.tamanhoÍcone);
//            últ = Math.Min(mercadorias.Length - 1, pri + Math.Min(Size.Width, deslocamento) / Entidades.Álbum.Foto.tamanhoÍcone);

//            for (int i = pri; i <= últ; i++)
//            {
//                int x;
//                Image img;

//                x = deslocamento - i * Entidades.Álbum.Foto.tamanhoÍcone;
//                img = mercadorias[i].Ícone;

//                if (img != null)
//                {
//                    e.Graphics.DrawImageUnscaled(img, x, 4);
//                    e.Graphics.DrawImageUnscaled(img, Size.Width - x, Size.Height - 4 - Entidades.Álbum.Foto.tamanhoÍcone);
//                }
//            }
//        }

//        /// <summary>
//        /// Ocorre ao expirar o temporizador.
//        /// </summary>
//        private void tmrDeslocamento_Tick(object sender, EventArgs e)
//        {
//            deslocamento += 15;

//            if (deslocamento > mercadorias.Length * Entidades.Álbum.Foto.tamanhoÍcone + Size.Width)
//            {
//                tmrDeslocamento.Stop();
//                tmrDeslocamento.Dispose();
//                tmrDeslocamento = null;
//                Concluído(this, e);
//            }
//            else
//                Atualizado(this, e);
//        }
//    }
//}
