using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Entidades.Álbum;
using Acesso.Comum;

namespace Apresentação.Mercadoria
{
    partial class MostradorAnimação
    {
        /// <summary>
        /// Esta classe permite que uma animação seja carregada em
        /// segundo plano enquanto a logotipo seja exibida na tela.
        /// </summary>
        private class AnimaçãoOca : Entidades.Álbum.Animação
        {
            private Entidades.Álbum.Animação animação = null;
            private Entidades.Mercadoria.Mercadoria mercadoria;
            private volatile bool carregado = false;

            /// <summary>
            /// Constrói uma animação com a logotipo da empresa e carrega
            /// a animação em segundo plano.
            /// </summary>
            /// <param name="mercadoria">
            /// Mercadoria cuja animação será carregada em segundo plano.</param>
            public AnimaçãoOca(Entidades.Mercadoria.Mercadoria mercadoria)
            {
                // Apresentação.Mercadoria.Properties.Resources.logo
                DbFoto fotoTemporária = CacheMiniaturas.Instância.Obter(mercadoria);
                if (fotoTemporária != null)
                    Imagens.Add(fotoTemporária);
                else
                    Imagens.Add(Resource.logo);

                this.mercadoria = mercadoria;

                AsyncCarregarAnimação carregar = new AsyncCarregarAnimação(CarregarAnimação);
                carregar.BeginInvoke(new AsyncCallback(CallbackCarregarAnimação), carregar);
            }

            private delegate void AsyncCarregarAnimação();

            /// <summary>
            /// Carrega a animação em segundo plano (chamada pela thread).
            /// </summary>
            private void CarregarAnimação()
            {
                animação = mercadoria.Animação;

                if (animação != null && animação.Imagens != null)
                {
                    this.Imagens.AddRange(animação.Imagens);
                    this.Imagens.RemoveAt(0);
                }

                carregado = true;
            }

            private void CallbackCarregarAnimação(IAsyncResult resultado)
            {
                AsyncCarregarAnimação carregar = (AsyncCarregarAnimação)resultado.AsyncState;

                carregar.EndInvoke(resultado);
            }

            public override bool Carregado
            {
                get { return carregado; }
            }
        }
    }
}
