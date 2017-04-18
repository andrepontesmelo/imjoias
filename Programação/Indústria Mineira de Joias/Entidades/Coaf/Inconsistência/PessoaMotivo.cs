namespace Entidades.Coaf.Inconsistência
{
    public class PessoaMotivo
    {
        private uint codigo;
        private long motivo;

        public PessoaMotivo()
        {
        }

        public uint Pessoa => codigo;
        public EnumInconsistência Motivo => (EnumInconsistência) motivo;
    }
}
