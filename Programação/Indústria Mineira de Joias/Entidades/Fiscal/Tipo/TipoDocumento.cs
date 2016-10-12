namespace Entidades.Fiscal.Tipo
{
    public class TipoDocumento
    {
        private TipoDocumentoSistema cupom;
        private int id;

        public TipoDocumento()
        {
        }

        public TipoDocumento(TipoDocumentoSistema cupom)
        {
            this.cupom = cupom;
        }

        public int Id => id;
    }
}
