using Acesso.Comum;
using Entidades.Acerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Relacionamento
{
    public abstract class RelacionamentoAcerto : Relacionamento
    {


        [DbRelacionamento("código", "acerto"), DbColuna("acerto")]
        protected AcertoConsignado acertoConsignado;



        protected bool travado;
        public abstract bool Travado { get; set; }
        public abstract Pessoa.Pessoa Pessoa { get; set; }

        /// <summary>
        /// Retorna última estado de 'travado'
        /// Não faz busca ao BD
        /// </summary>
        public bool TravadoEmCache
        {
            get { return travado; }
        }



        public AcertoConsignado AcertoConsignado
        {
            get { return acertoConsignado; }
        }

        internal void DefinirAcertoConsignado(AcertoConsignado value)
        {
            acertoConsignado = value;
            DefinirDesatualizado();
        }

    }
}
