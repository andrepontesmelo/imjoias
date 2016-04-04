using System;
using System.Collections.Generic;
using System.Text;

namespace Apresentação.Impressão
{
    public class DadosRelatório
    {
        private TipoDocumento tipo;
        private int cópias;
        private bool collated;
        private int págInicial;
        private int págFinal;
        private DateTime períodoInicial;
        private DateTime períodoFinal;
        private bool apenasConsertos;
        private bool períodoPrevisão;

        public DadosRelatório()
        {
        }

        public DadosRelatório(TipoDocumento tipo, DateTime períodoInicial, DateTime períodoFinal, bool apenasConsertos, bool períodoPrevisão)
        {
            if (períodoInicial > períodoFinal)
                throw new ArgumentException("Período inicial não pode ser maior que o período final.");

            this.tipo = tipo;
            collated = false;
            cópias = 1;
            págInicial = 1;
            págFinal = int.MaxValue;
            this.períodoInicial = períodoInicial;
            this.períodoFinal = períodoFinal;
            this.apenasConsertos = apenasConsertos;
            this.períodoPrevisão = períodoPrevisão;
        }

        public TipoDocumento Tipo { get { return tipo; } set { tipo = value; } }
        public int Cópias { get { return cópias; } set { cópias = value; } }
        public bool Collated { get { return collated; } set { collated = value; } }
        public int PágInicial { get { return págInicial; } set { págInicial = value; } }
        public int PágFinal { get { return págFinal; } set { págFinal = value; } }
        public DateTime PeríodoInicial { get { return períodoInicial; } set { períodoInicial = value; } }
        public DateTime PeríodoFinal { get { return períodoFinal; } set { períodoFinal = value; } }
        public bool ApenasConsertos { get { return apenasConsertos; } set { apenasConsertos = value; } }
        public bool PeríodoPrevisão { get { return períodoPrevisão; } set { períodoPrevisão = value; } }
    }
}