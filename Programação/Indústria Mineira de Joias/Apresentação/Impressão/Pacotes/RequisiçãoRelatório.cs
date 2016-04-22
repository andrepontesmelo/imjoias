using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Apresentação.Impressão.Pacotes
{
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct RequisiçãoRelatório
    {
        [FieldOffset(0)]
        private byte chksum;
        [FieldOffset(1)]
        private Comando comando;
        [FieldOffset(2)]
        private TipoDocumento tipo;
        [FieldOffset(3)]
        private DateTime períodoInicial;        // 64 bits
        [FieldOffset(11)]
        private DateTime períodoFinal;
        [FieldOffset(19)]
        private int cópias;
        [FieldOffset(23)]
        private bool collated;
        [FieldOffset(23 + sizeof(Boolean))]
        private int págInicial;
        [FieldOffset(23 + sizeof(Boolean) + 4)]
        private int págFinal;
        [FieldOffset(23 + sizeof(Boolean) + 8)]
        private byte tnome;
        [FieldOffset(23 + sizeof(Boolean) + 9)]
        private bool apenasConserto;
        [FieldOffset(23 + sizeof(Boolean) + sizeof(Boolean) + 9)]
        private bool períodoPrevisão;
        [FieldOffset(23 + sizeof(Boolean) + sizeof(Boolean) + sizeof(Boolean) + 9)]
        private fixed char nome[128];

        public TipoDocumento Tipo { get { return tipo; } set { tipo = value; } }
        public DateTime PeríodoInicial { get { return períodoInicial; } set { períodoInicial = value; } }
        public DateTime PeríodoFinal { get { return períodoFinal; } set { períodoFinal = value; } }
        public bool ApenasConserto { get { return apenasConserto; } set { apenasConserto = value; } }
        public bool PeríodoPrevisão { get { return períodoPrevisão; } set { períodoPrevisão = value; } }

        public RequisiçãoRelatório(string nome)
        {
            this.chksum = 0;
            this.comando = Comando.RequisitarRelatório;
            this.tipo = TipoDocumento.Desconhecido;
            this.cópias = 1;
            this.collated = false;
            this.págInicial = 1;
            this.págFinal = int.MaxValue;
            this.períodoInicial = DateTime.MaxValue;
            this.períodoFinal = DateTime.MinValue;
            this.apenasConserto = false;
            this.períodoPrevisão = false;

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
