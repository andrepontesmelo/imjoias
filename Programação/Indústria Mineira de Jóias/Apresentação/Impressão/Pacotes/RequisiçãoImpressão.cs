using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Apresentação.Impressão.Pacotes
{
    unsafe struct RequisiçãoImpressão
    {
        private byte chksum;
        private Comando comando;

        private TipoDocumento tipo;
        private ulong código;
        private int cópias;
        private bool collated;
        private int págInicial;
        private int págFinal;
        private byte tnome;
        private fixed char nome[128];

        public TipoDocumento Tipo { get { return tipo; } set { tipo = value; } }
        public ulong CódigoDocumento { get { return código; } set { código = value; } }

        public RequisiçãoImpressão(string nome)
        {
            this.chksum = 0;
            this.comando = Comando.RequisitarImpressão;
            this.tipo = TipoDocumento.Desconhecido;
            this.código = 0;
            this.cópias = 1;
            this.collated = false;
            this.págInicial = 1;
            this.págFinal = int.MaxValue;

            fixed (char* nptr = this.nome)
                tnome = (byte)Útil.PreencherString(nptr, 128, nome);
        }

        public string Nome
        {
            get
            {
                fixed (char* nptr = this.nome)
                    return Útil.RecuperarString(nptr, Math.Min(tnome, (byte)128));
            }
        }

        public int Cópias { get { return cópias; } set { cópias = value; } }
        public bool Collated { get { return collated; } set { collated = value; } }
        public int PágInicial { get { return págInicial; } set { págInicial = value; } }
        public int PágFinal { get { return págFinal; } set { págFinal = value; } }
    }
}
