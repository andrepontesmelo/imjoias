#pragma warning disable 0649            // Field 'field' is never assigned to, and will always have its default value 'value'

namespace Apresentação.Impressão.Pacotes
{
    struct Cabeçalho
    {
        public byte chksum;
        public Comando comando;
    }
}
