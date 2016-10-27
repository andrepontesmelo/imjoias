using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Mercadoria.Componente;
using System.Drawing;

namespace Entidades.Moedas
{
    [DbTransação, Cacheável("ObterMoeda"), DbTabela("moeda"), Validade(6, 0, 0), NãoCopiarCache]
    public class Moeda : DbManipulaçãoAutomática
    {
#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        [DbColuna("codigo"), DbChavePrimária(true)]
        private uint código;
        private bool sistema;
        private string nome;

        [DbRelacionamento("codigo", "componentecusto")]
        private ComponenteCusto componenteCusto;

        [DbColuna("icone")]
        private DbFoto ícone;

        private byte casasDecimais = 2;

#pragma warning restore 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

        public uint Código => código;

        public bool Sistema  => sistema;

        public string Nome { get { return nome; } set { nome = value; DefinirDesatualizado(); } }

        public ComponenteCusto ComponenteCusto
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
