using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using System.Collections;
using Acesso.Comum.Cache;

namespace Entidades.Mercadoria
{
    [Cacheável("Obter")]
    public class ComponenteCusto : DbManipulaçãoAutomática
    {
        // Atributos
        [DbChavePrimária(false)]
        private string codigo;

        private string nome;
        private string multiplicarcomponentecusto;
        private double valor;

        private static Hashtable hashCódigoComponente = null;

        #region Propriedades

        public string Código
        {
            get { return codigo; }
            set 
            { 
                codigo = value;
                DefinirDesatualizado();
            }
        }

        public string Nome
        {
            get { return nome; }
            set 
            { 
                nome = value;
                DefinirDesatualizado();
            }

        }

        public string MultiplicarComponenteCusto
        {
            get { return multiplicarcomponentecusto; }
            set 
            { 
                multiplicarcomponentecusto = value;
                DefinirDesatualizado();
            }
        }

        public double Valor
        {
            get { return valor; }
            set 
            { 
                valor = value;
                DefinirDesatualizado();
            }
        }
        
        #endregion

        /// <summary>
        /// Obtém todos os componentes
        /// </summary>
        /// <returns>Lista de ComponenteCusto</returns>
        public static List<ComponenteCusto> ObterComponentes()
        {
            List<ComponenteCusto> lista;

            lista = Mapear<ComponenteCusto>("select * from componentecusto");

            // Aproveita para refrescar a hash
            hashCódigoComponente = CriarHash(lista);

            return lista;
        }

        public static ComponenteCusto Obter(string código)
        {
            return MapearÚnicaLinha<ComponenteCusto>("select * from componentecusto where codigo=" + DbTransformar(código));
        }

        /// <summary>
        /// Multiplica o valor relativo do componente
        /// pelo valor absoluto do componente referenciado, recursivamente 
        /// </summary>
        public double ObterValorAbsoluto()
        {
            if (MultiplicarComponenteCusto == null)
                return Valor;
            else
            {
                ComponenteCusto referência;
                referência = (ComponenteCusto) HashCódigoComponente[MultiplicarComponenteCusto];

                return Valor * referência.ObterValorAbsoluto();
            }
        }

        
        /// <summary>
        /// Verifica se a adição de uma referência no objeto atual é inviável.
        /// uso:
        /// NovaDepenciaNãoOK = possívelDependência.GeraReferênciaCíclica(this);
        /// </summary>
        public bool GeraReferênciaCíclica(ComponenteCusto primeiroComponente)
        {
            ComponenteCusto meuDependente;
            
            if (this.MultiplicarComponenteCusto == null)
                return false;
            
            meuDependente = (ComponenteCusto) HashCódigoComponente[MultiplicarComponenteCusto];

            if (meuDependente == primeiroComponente)
                return true;
            else 
                return meuDependente.GeraReferênciaCíclica(primeiroComponente);
        }

        public override string ToString()
        {
            return Código.ToString() + " - " + Nome.ToString();
        }

        /// <summary>
        /// Retorna falso quando não existe o código.
        /// </summary>
        /// <param name="Código"></param>
        /// <returns></returns>
        public static bool VerificarExistência(string Código)
        {
            IDbCommand cmd;
            IDbConnection conexão;

            conexão = Conexão;

            lock (conexão)
            {
                cmd = conexão.CreateCommand();
                cmd.CommandText = "select count(*) from componentecusto where codigo=" + DbTransformar(Código);
                return ((long) cmd.ExecuteScalar()) != 0;
            }
        }

        /// <summary>
        /// Cria uma hash. Chave: código, Valor: componente.
        /// </summary>
        private static Hashtable CriarHash(List<ComponenteCusto> componentes)
        {
            Hashtable hash = new Hashtable(componentes.Count);

            foreach (ComponenteCusto c in componentes)
                hash.Add(c.Código, c);

            return hash;
        }

        private static Hashtable HashCódigoComponente
        {
            get
            {
                if (hashCódigoComponente == null)
                {
                    // Obter componentes já cria a hash
                    ObterComponentes();
                }

                return hashCódigoComponente;
            }
        }

        public static implicit operator ComponenteCusto(string código)
        {
            return HashCódigoComponente[código] as ComponenteCusto;
        }

        public bool ExisteVínculo(Mercadoria mercadoria)
        {
            IDbCommand cmd;
            IDbConnection conexão;

            conexão = Conexão;

            lock (conexão)
            {
                cmd = conexão.CreateCommand();
                cmd.CommandText = "select count(*) from vinculomercadoriacomponentecusto "
                + " where mercadoria=" + DbTransformar(mercadoria.ReferênciaNumérica)
                + " AND componentecusto=" + DbTransformar(Código);

                return ((long)cmd.ExecuteScalar()) != 0;
            }
        }
    }
}
