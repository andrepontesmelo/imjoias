namespace Entidades.Fiscal.Importação.Resultado
{
    public class ArquivoIgnorado : Arquivo
    {
        Motivo motivo;

        public ArquivoIgnorado(string nome, Motivo motivo, string idDocumentoFiscal) : base(nome, idDocumentoFiscal)
        {
            this.motivo = motivo;
        }

        public ArquivoIgnorado(string nome, Motivo motivo) : this(nome, motivo, null)
        {
        }

        public Motivo Motivo => motivo;

        public override int GetHashCode()
        {
            return motivo.GetHashCode();
        }

        public override string ObterChaveGrupo()
        {
            return motivo.ToString();
        }
       
    }
}
