using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Entidades.Álbum;

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
        /// Uma mercadoria pode entrar em promoção. Trata-se de um desconto fixo para todas as 
        /// mercadorias. A promoção não é uma para cada mercadoria porque é tradição da empresa
        /// fazer uma unica promoção para liquidar algumas mercadorias pesadas após o balanço.
        /// Além disto pode-se usar um label na etiqueta que ou aparece ou não, conforme
        /// este valor booleano.
        /// </summary>
        bool Promoção
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

        ///// <summary>
        ///// Ícone da mercadoria
        ///// </summary>
        //Image Ícone
        //{
        //    get;
        //}

        //bool ÍconeObtido { get; }

        //void PrepararÍcone();

        //Fornecedor Fornecedor
        //{
        //    get;
        //    set;
        //}

        //string FornecedorReferência 
        //{
        //    get; 
        //    set;
        //}
    }
}
