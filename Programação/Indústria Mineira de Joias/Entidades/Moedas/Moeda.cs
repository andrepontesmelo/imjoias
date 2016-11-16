using Acesso.Comum;
using Acesso.Comum.Cache;
using Entidades.Mercadoria.Componente;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Entidades.Moedas
{
    [DbTransação, Cacheável("ObterMoeda"), DbTabela("moeda"), NãoCopiarCache]
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
        public Image Ícone { get { return ícone; } set { ícone = value; DefinirDesatualizado(); } }
        public byte CasasDecimais { get { return casasDecimais; } set { casasDecimais = value; DefinirDesatualizado(); } }

        public ComponenteCusto ComponenteCusto
        {
            get { return componenteCusto; }
            set { componenteCusto = value; DefinirDesatualizado(); }
        }

        private static List<Moeda> moedas = null;

        public static Moeda ObterMoeda(uint código)
        {
            return (from moeda in ObterMoedas() where moeda.Código.Equals(código) select moeda).First();
        }

        public static List<Moeda> ObterMoedas()
        {
            if (moedas == null)
                moedas = Mapear<Moeda>("SELECT * FROM moeda ORDER BY nome");

            return moedas;
        }

        public static Moeda ObterMoeda(MoedaSistema moeda)
        {
            return ObterMoeda((uint) moeda);
        }
    }
}
