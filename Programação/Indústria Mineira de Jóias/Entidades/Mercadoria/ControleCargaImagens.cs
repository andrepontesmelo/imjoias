using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Mercadoria
{
    /// <summary>
    /// Controla a quantidade de imagens carregadas de mercadorias.
    /// </summary>
    class ControleCargaImagens
    {
        private const int capacidadeÍcones = 100;

        private Queue<MercadoriaCampos> filaCargaImagens;

        public ControleCargaImagens()
        {
            filaCargaImagens = new Queue<MercadoriaCampos>(capacidadeÍcones + 1);
        }

        /// <summary>
        /// Adiciona uma nova mercadoria que recuperou as imagens.
        /// </summary>
        public void Adicionar(MercadoriaCampos campos)
        {
            lock (filaCargaImagens)
            {
                filaCargaImagens.Enqueue(campos);

                if (filaCargaImagens.Count == capacidadeÍcones)
                {
                    MercadoriaCampos remoção = filaCargaImagens.Dequeue();

                    remoção.LiberarÍcone();
                }
            }
        }
    }
}
