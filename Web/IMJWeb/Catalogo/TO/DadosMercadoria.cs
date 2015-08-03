using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using IMJWeb.Dominio;
using IMJWeb.Sessao;
using IMJWeb.Dominio.Util;

namespace IMJWeb.Catalogo.TO
{
    [DataContract]
    public class DadosMercadoria
    {
        /// <summary>
        /// Referência da mercadoria.
        /// </summary>
        [DataMember]
        public Referencia Referencia { get; set; }

        /// <summary>
        /// Descrição da mercadoria.
        /// </summary>
        [DataMember]
        public string Descricao { get; set; }

        /// <summary>
        /// Peso da mercadoria.
        /// </summary>
        [DataMember]
        public string Peso { get; set; }

        /// <summary>
        /// Índice da mercadoria.
        /// </summary>
        [DataMember]
        public string Indice { get; set; }

        public DadosMercadoria() { }

        /// <summary>
        /// Constrói um transfer-object de dados de mercadoria a partir de
        /// uma entidade de mercadoria.
        /// </summary>
        /// <param name="mercadoria">Mercadoria cujos dados serão copiados.</param>
        public DadosMercadoria(IMercadoria mercadoria)
        {
            this.Referencia = mercadoria.Referencia;
            this.Descricao = mercadoria.Descricao;
            this.Peso = MercadoriaHelper.FormatarPeso(mercadoria.Peso);

            try
            {
                this.Indice = MercadoriaHelper.FormatarIndice(mercadoria.ObterIndice(HttpContext.Current.Session.ObterUsuarioAtual()));
            }
            catch (IndiceIndisponivelException)
            {
                this.Indice = MercadoriaHelper.FormatarIndice(null);
            }
        }
    }
}