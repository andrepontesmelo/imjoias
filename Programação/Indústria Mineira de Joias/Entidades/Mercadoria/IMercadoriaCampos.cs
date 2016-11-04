namespace Entidades.Mercadoria
{
    interface IMercadoriaCampos
    {
        /// <summary>
        /// Referência formatada
        /// </summary>
        string Referência
        {
            get; set;
        }

        /// <summary>
        /// Dígito verificador
        /// </summary>
        /// 
        /// <remarks>
        /// O dígito não deve ser definido, mas sim calculado.
        /// </remarks>
        int Dígito
        {
            get;
        }

        /// <summary>
        /// Referência numérica não formatada, sem dígito.
        /// </summary>
        string ReferênciaNumérica
        {
            get;
        }

        /// <summary>
        /// Descrição da mercadoria
        /// </summary>
        string Descrição
        {
            get;
            set;
        }

        /// <summary>
        /// Teor da mercadoria
        /// </summary>
        int Teor
        {
            get;
            set;
        }

        /// <summary>
        /// Peso da mercadoria
        /// </summary>
        double PesoOriginal
        {
            get;
            set;
        }

        /// <summary>
        /// Faixa da meracdoria
        /// </summary>
        string Faixa
        {
            get;
            set;
        }

        /// <summary>
        /// Grupo da mercadoria
        /// </summary>
        int? Grupo
        {
            get;
            set;
        }

        /// <summary>
        /// Coeficiente da mercadoria. Só é igual ao índice para mercadorias de peça.
        /// </summary>
        Coeficientes Coeficientes
        {
            get;
        }

        /// <summary>
        /// Mercadoria de peso
        /// </summary>
        bool DePeso
        {
            get;
            set;
        }

        /// <summary>
        /// Fora de linha
        /// </summary>
        bool ForaDeLinha
        {
            get;
            set;
        }

        int CFOP
        {
            get;
        }

        int TipoUnidadeComercial
        {
            get;
        }

        string ClassificaçãoFiscal
        {
            get;
        }
    }
}
