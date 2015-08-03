using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão.Pacotes
{
    struct ImpressãoCompleta
    {
        private byte chksum;
        private Comando comando;

        private TipoDocumento tipo;
        private ulong código;

        public ImpressãoCompleta(TipoDocumento tipo, ulong código)
        {
            this.tipo = tipo;
            this.código = código;
            comando = Comando.ImpressãoCompleta;
            chksum = 0;
        }

        public TipoDocumento Tipo { get { return tipo; } }
        public ulong Código { get { return código; } }
    }
}
