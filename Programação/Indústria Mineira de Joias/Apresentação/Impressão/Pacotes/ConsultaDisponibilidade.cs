namespace Apresentação.Impressão.Pacotes
{
    struct ConsultaDisponibilidade
    {
        private byte chksum;
        private Comando comando;
        private TipoDocumento tipo;

        public ConsultaDisponibilidade(TipoDocumento tipo)
        {
            chksum = 0;
            this.tipo = tipo;
            this.comando = Comando.ConsultarDisponibilidade;
        }

        public TipoDocumento Tipo { get { return tipo; } }
    }
}
