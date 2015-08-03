using System;
using System.Collections.Generic;
using System.Text;

namespace Comunicação.Pacotes
{
    unsafe struct Cabeçalho
    {
        public byte versão;
        public byte chksum;
    }
}
