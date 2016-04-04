using System;
using Entidades;
using System.Xml;

namespace Entidades.Etiqueta
{
    public class SaquinhoEtiqueta : Saquinho
    {
        // Atributos
        private EtiquetaFormato etiqueta;
        private bool impresso = false;

        #region Propriedades

        /// <summary>
        /// Formato para a etiqueta
        /// </summary>
        public EtiquetaFormato Etiqueta
        {
            get { return etiqueta; }
            set { etiqueta = value; }
        }

        /// <summary>
        /// Se saquinho j� foi impresso
        /// </summary>
        public bool Impresso
        {
            get { return impresso; }
            set { impresso = value; }
        }

        #endregion

        /// <summary>
        /// Constr�i um saquinho a ser usado no cofre
        /// </summary>
        /// <param name="mercadoriaPresenteNoSaquinho">Mercadoria</param>
        /// <param name="quantidadeMercadoriasNoSaquinho">Quantidade</param>
        /// <param name="etiqueta">Formato da etiqueta</param>
        public SaquinhoEtiqueta(Entidades.Mercadoria.Mercadoria mercadoriaPresenteNoSaquinho, double quantidadeMercadoriasNoSaquinho, EtiquetaFormato etiqueta)
            : base(mercadoriaPresenteNoSaquinho, quantidadeMercadoriasNoSaquinho)
        {
            this.etiqueta = etiqueta;
        }

        public override string Identifica��oAgrup�vel()
        {
            return base.Identifica��oAgrup�vel() + etiqueta.ObterHashSemelhan�a();
        }

        public override void AtualizaObjetosIntr�nsecos()
        {
            etiqueta.ReobterInforma��es();
            base.AtualizaObjetosIntr�nsecos();
        }

        public override ISaquinho Clone(double novaQuantidade)
        {
            return new SaquinhoEtiqueta((Entidades.Mercadoria.Mercadoria)Mercadoria.Clone(), novaQuantidade, etiqueta);
        }

        public override string ToString()
        {
            return base.ToString() + " peso=" + Peso.ToString() + " etiqueta=" + etiqueta.ToString();
        }

    }
}
