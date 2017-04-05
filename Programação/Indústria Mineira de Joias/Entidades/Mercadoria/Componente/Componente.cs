using Acesso.Comum;
using Acesso.Comum.Cache;

namespace Entidades.Mercadoria.Componente
{
    [Cacheável("Obter")]
    public class Componente : DbManipulaçãoAutomática
    {
        [DbChavePrimária(false)]
        protected string codigo;
        protected string nome;
        protected int? grupo;
        protected string materiaprima;

        public string Código
        {
            get { return codigo; }
            set 
            {
                if (value.Equals(codigo))
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

        public static Componente Obter(string código)
        {
            return MapearÚnicaLinha<Componente>("select * from componente where codigo=" + DbTransformar(código));
        }

        public override string ToString()
        {
            return Código.ToString() + " - " + Nome.ToString();
        }
    }
}
