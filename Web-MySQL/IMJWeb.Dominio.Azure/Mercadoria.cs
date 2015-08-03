using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Common;

namespace IMJWeb.Dominio.Azure
{
    [DataServiceKey("PartitionKey", "RowKey")]
    public class Mercadoria : IMercadoria
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }

        #region IMercadoria Members

        private Referencia referencia;

        /// <summary>
        /// Referência da mercadoria.
        /// </summary>
        public Referencia Referencia
        {
            get
            {
                return referencia;
            }
            set
            {
                this.PartitionKey = ObterPartitionKey(value);
                this.RowKey = ObterRowKey(value);
                this.referencia = value;
            }
        }

        /// <summary>
        /// Descrição da mercadoria.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Peso da mercadoria.
        /// </summary>
        public double Peso { get; set; }
        decimal? IMercadoria.Peso { get { return Convert.ToDecimal(this.Peso); }  set { this.Peso = Convert.ToDouble(value); } }

        /// <summary>
        /// Fotos da mercadoria.
        /// </summary>
        public ICollection<IFoto> Fotos
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Índices.
        /// </summary>
        public ICollection<IIndice> Indices
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Catálogo.
        /// </summary>
        public ICatalogo Catalogo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Determina se a mercadoria é exclusiva para usuários autenticados.
        /// </summary>
        public bool Exclusiva { get; set; }

        public IFoto ObterFoto(int largura, int altura)
        {
            throw new NotImplementedException();
        }

        public bool PermiteAcesso(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public decimal? ObterIndice(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Obtenção de chave

        public static string ObterPartitionKey(Referencia referencia)
        {
            return referencia.ValorNumerico.Substring(0, 6);
        }

        public static string ObterRowKey(Referencia referencia)
        {
            return referencia.ValorNumerico;
        }

        #endregion
    }
}
