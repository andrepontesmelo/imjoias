using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão.Pacotes
{
    struct ErroImpressão
    {
        private byte chksum;
        private Comando comando;

        private TipoDocumento tipo;
        private ulong código;

        public ErroImpressão(TipoDocumento tipo, ulong código)
        {
            this.tipo = tipo;
            this.código = código;
            comando = Comando.ErroImpressão;
            chksum = 0;
        }

        public TipoDocumento Tipo { get { return tipo; } }
        public ulong Código { get { return código; } }
    }
}
