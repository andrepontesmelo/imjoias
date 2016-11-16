using System;

namespace Apresentação.Formulários
{
    public class ExceçãoPósCarga : ApplicationException
    {
        string msg;

        public ExceçãoPósCarga(string problema)
        {
            msg = "Não foi possível executar pós-carga em:" + problema;
        }

        public override string Message
        {
            get
            {
                return msg;
            }
        }
    }

}
