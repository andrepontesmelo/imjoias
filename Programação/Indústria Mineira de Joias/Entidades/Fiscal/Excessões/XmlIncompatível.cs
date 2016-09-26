using System;

namespace Entidades.Fiscal.Excessões
{
    public class XmlIncompatível : Exception
    {
        public XmlIncompatível(string mensagem) : base(mensagem)
        {
        }
    }
}
