using Acesso.Comum;
using Acesso.Comum.Cache;

namespace Entidades.Mercadoria.Componente
{
    [Cache�vel("Obter")]
    public class Componente : DbManipula��oAutom�tica
    {
        [DbChavePrim�ria(false)]
        protected string codigo;

        protected string nome;

        public string C�digo
        {
            get { return codigo; }
            set 
            {
                if (codigo.Equals(value))
                    return;

                codigo = value;
                DefinirDesatualizado();
            }
        }

        public string Nome
        {
            get { return nome; }
            set 
            {
                if (value.Equals(nome))
                    return;

                nome = value;
                DefinirDesatualizado();
            }

        }

        public static Componente Obter(string c�digo)
        {
            return Mapear�nicaLinha<Componente>("select * from componente where codigo=" + DbTransformar(c�digo));
        }

        public override string ToString()
        {
            return C�digo.ToString() + " - " + Nome.ToString();
        }
    }
}
