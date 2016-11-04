using Entidades.Fiscal.Esquema;

namespace Apresentação.Administrativo.Fiscal.BaseInferior.Esquema
{
    public partial class BaseEsquema : Apresentação.Formulários.BaseInferior
    {
        private EsquemaProdução esquema;

        public BaseEsquema()
        {
            InitializeComponent();
        }

        internal void Carregar(EsquemaProdução esquema)
        {
            this.esquema = esquema;

            listaIngredientes.Carregar(esquema);
        }
    }
}
