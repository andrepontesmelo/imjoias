using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa.Endereço
{
    public class CEP : DbManipulaçãoAutomática
    {
#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        /// <summary>
        /// Chave primária.
        /// </summary>
        [DbChavePrimária(true), DbColuna("cep")]
        private string cep;

        [DbRelacionamento("codigo", "localidade")]
        private Localidade localidade;

        private string logradouro;

        private string bairro;

#pragma warning restore 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        public string CEPNumeros { get { return cep; } }
        public Localidade Localidade { get { return localidade; } }
        public string Logradouro { get { return logradouro; } }
        public string Bairro { get { return bairro; } }

        public static CEP ObterCEP(string cep)
        {
            StringBuilder cepLimp = new StringBuilder();

            foreach (char c in cep)
                if (Char.IsDigit(c))
                    cepLimp.Append(c);

            if (cepLimp.Length == 0)
                return null;

            return MapearÚnicaLinha<CEP>(
                string.Format("SELECT * FROM cep WHERE cep = {0}",
                    cepLimp.ToString()));
        }
    }
}
