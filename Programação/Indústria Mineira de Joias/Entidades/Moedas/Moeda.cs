using Acesso.Comum;
using Acesso.Comum.Cache;
using System.Drawing;

namespace Entidades.Moedas
{
    [DbTransação, Cacheável("ObterMoeda"), DbTabela("moeda"), Validade(6, 0, 0), NãoCopiarCache]
    public class Moeda : DbManipulaçãoAutomática
    {
        [DbColuna("codigo"), DbChavePrimária(true)]
        private uint código;
        private bool sistema;
        private string nome;

        [DbRelacionamento("codigo", "componentecusto")]
        private Mercadoria.ComponenteCusto componenteCusto;

        [DbColuna("icone")]
        private DbFoto ícone;

        private byte casasDecimais = 2;

        public uint Código => código;

        public bool Sistema  => sistema;

        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        public Mercadoria.ComponenteCusto ComponenteCusto
        {
            get { return componenteCusto; }
            set { componenteCusto = value; DefinirDesatualizado(); }
        }

        public Image Ícone { get { return ícone; } set { ícone = value; DefinirDesatualizado(); } }
        public byte CasasDecimais { get { return casasDecimais; } set { casasDecimais = value; DefinirDesatualizado(); } }

        public static Moeda ObterMoeda(uint código)
        {
            return MoedaObtenção.Instância.ObterMoeda(código);
        }

        public static Moeda[] ObterMoedas()
        {
            return MoedaObtenção.Instância.ObterMoedas();
        }

        public static Moeda ObterMoeda(MoedaSistema moeda)
        {
            return MoedaObtenção.Instância.ObterMoeda(moeda);
        }
    }
}
