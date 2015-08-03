using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão
{
    public struct DadosDocumento
    {
        private TipoDocumento tipo;
        private ulong código;
        private int cópias;
        private bool collated;
        private int págInicial;
        private int págFinal;

        public DadosDocumento(TipoDocumento tipo, ulong código)
        {
            this.tipo = tipo;
            this.código = código;
            collated = false;
            cópias = 1;
            págInicial = 1;
            págFinal = int.MaxValue;
        }

        public TipoDocumento Tipo { get { return tipo; } set { tipo = value; } }
        public ulong Código { get { return código; } set { código = value; } }
        public int Cópias { get { return cópias; } set { cópias = value; } }
        public bool Collated { get { return collated; } set { collated = value; } }
        public int PágInicial { get { return págInicial; } set { págInicial = value; } }
        public int PágFinal { get { return págFinal; } set { págFinal = value; } }
    }
}
