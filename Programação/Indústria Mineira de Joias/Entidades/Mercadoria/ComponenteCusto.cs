using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Data;
using System.Collections;
using Acesso.Comum.Cache;

namespace Entidades.Mercadoria
{
    [Cache�vel("Obter")]
    public class ComponenteCusto : DbManipula��oAutom�tica
    {
        // Atributos
        [DbChavePrim�ria(false)]
        private string codigo;

        private string nome;
        private string multiplicarcomponentecusto;
        private double valor;

        private static Hashtable hashC�digoComponente = null;

        #region Propriedades

        public string C�digo
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
        /// Obt�m todos os componentes
        /// </summary>
        /// <returns>Lista de ComponenteCusto</returns>
        public static List<ComponenteCusto> ObterComponentes()
        {
            List<ComponenteCusto> lista;

            lista = Mapear<ComponenteCusto>("select * from componentecusto");

            // Aproveita para refrescar a hash
            hashC�digoComponente = CriarHash(lista);

            return lista;
        }

        public static ComponenteCusto Obter(string c�digo)
        {
            return Mapear�nicaLinha<ComponenteCusto>("select * from componentecusto where codigo=" + DbTransformar(c�digo));
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
                ComponenteCusto refer�ncia;
                refer�ncia = (ComponenteCusto) HashC�digoComponente[MultiplicarComponenteCusto];

                return Valor * refer�ncia.ObterValorAbsoluto();
            }
        }

        
        /// <summary>
        /// Verifica se a adi��o de uma refer�ncia no objeto atual � invi�vel.
        /// uso:
        /// NovaDepenciaN�oOK = poss�velDepend�ncia.GeraRefer�nciaC�clica(this);
        /// </summary>
        public bool GeraRefer�nciaC�clica(ComponenteCusto primeiroComponente)
        {
            ComponenteCusto meuDependente;
            
            if (this.MultiplicarComponenteCusto == null)
                return false;
            
            meuDependente = (ComponenteCusto) HashC�digoComponente[MultiplicarComponenteCusto];

            if (meuDependente == primeiroComponente)
                return true;
            else 
                return meuDependente.GeraRefer�nciaC�clica(primeiroComponente);
        }

        public override string ToString()
        {
            return C�digo.ToString() + " - " + Nome.ToString();
        }

        /// <summary>
        /// Retorna falso quando n�o existe o c�digo.
        /// </summary>
        /// <param name="C�digo"></param>
        /// <returns></returns>
        public static bool VerificarExist�ncia(string C�digo)
        {
            IDbCommand cmd;
            IDbConnection conex�o;

            conex�o = Conex�o;

            lock (conex�o)
            {
                cmd = conex�o.CreateCommand();
                cmd.CommandText = "select count(*) from componentecusto where codigo=" + DbTransformar(C�digo);
                return ((long) cmd.ExecuteScalar()) != 0;
            }
        }

        /// <summary>
        /// Cria uma hash. Chave: c�digo, Valor: componente.
        /// </summary>
        private static Hashtable CriarHash(List<ComponenteCusto> componentes)
        {
            Hashtable hash = new Hashtable(componentes.Count);

            foreach (ComponenteCusto c in componentes)
                hash.Add(c.C�digo, c);

            return hash;
        }

        private static Hashtable HashC�digoComponente
        {
            get
            {
                if (hashC�digoComponente == null)
                {
                    // Obter componentes j� cria a hash
                    ObterComponentes();
                }

                return hashC�digoComponente;
            }
        }

        public static implicit operator ComponenteCusto(string c�digo)
        {
            return HashC�digoComponente[c�digo] as ComponenteCusto;
        }

        public bool ExisteV�nculo(Mercadoria mercadoria)
        {
            IDbCommand cmd;
            IDbConnection conex�o;

            conex�o = Conex�o;

            lock (conex�o)
            {
                cmd = conex�o.CreateCommand();
                cmd.CommandText = "select count(*) from vinculomercadoriacomponentecusto "
                + " where mercadoria=" + DbTransformar(mercadoria.Refer�nciaNum�rica)
                + " AND componentecusto=" + DbTransformar(C�digo);

                return ((long)cmd.ExecuteScalar()) != 0;
            }
        }
    }
}
