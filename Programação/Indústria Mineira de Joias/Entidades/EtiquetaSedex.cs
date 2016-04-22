using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EtiquetaSedex
    {
        public enum TipoEndereco { Destinatário, Remetente };

        public Entidades.Pessoa.Pessoa Pessoa { get; set; }
        public Entidades.Pessoa.Endereço.Endereço Endereço { get; set; }
        public TipoEndereco Tipo { get; set; }
        public int Quantidade { get; set; }

        public EtiquetaSedex()
        {
            Quantidade = 1;
            Tipo = TipoEndereco.Destinatário;
        }
    }
}
