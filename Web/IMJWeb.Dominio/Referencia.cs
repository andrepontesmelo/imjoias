using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace IMJWeb.Dominio
{
    /// <summary>
    /// Referência de uma mercadoria.
    /// </summary>
    [Serializable]
    public struct Referencia
    {
        private static Regex regex = new Regex(@"^(?<Digitos1>\d{3})\.?(?<Digitos2>\d{3})\.?(?<Digitos3>\d{2})\.?(?<Digitos4>\d{3})\.?-?(?<Verificador>\d)?", RegexOptions.Compiled);
        private const string padraoFormatado = "${1}.${2}.${3}.${4}-$5";
        private const string padraoNumerico = "${1}${2}${3}${4}${5}";

        private string numero;

        public string ValorNumerico
        {
            get
            {
                return numero;
            }
        }

        public string ValorFormatado
        {
            get
            {
                return regex.Replace(ValorNumerico, padraoFormatado);
            }
        }

        public bool Completa
        {
            get
            {
                return ValorFormatado.Length == 16;
            }
        }

        /// <summary>
        /// Constrói uma referência da mercadoria.
        /// </summary>
        /// <param name="referencia">Referência numérica da mercadoria.</param>
        public Referencia(string referencia)
        {
            this.numero = regex.Replace(referencia, padraoNumerico);

            if (this.numero.Length != 12)
                this.numero = this.numero.Replace(".", "").Replace("-", "");
        }

        /// <summary>
        /// Converte uma referência para literal.
        /// </summary>
        /// <param name="referencia">Referência a ser convertida.</param>
        /// <returns>Representação da referência em literal.</returns>
        public static implicit operator string(Referencia referencia)
        {
            return referencia.ValorFormatado;
        }

        /// <summary>
        /// Interpreta uma referência literal.
        /// </summary>
        /// <param name="referencia">Referência a ser interpretada.</param>
        /// <returns>Referência interpretada.</returns>
        public static implicit operator Referencia(string referencia)
        {
            return new Referencia(referencia);
        }

        /// <summary>
        /// Transforma em literal.
        /// </summary>
        /// <returns>Versão literal da referência.</returns>
        public override string ToString()
        {
            return this;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Referencia))
                return false;

            return ValorNumerico.Equals(((Referencia)obj).ValorNumerico);
        }

        public override int GetHashCode()
        {
            return ValorNumerico.GetHashCode();
        }
    }
}
