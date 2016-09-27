using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ArquivoExcessão : Arquivo
    {
        private Exception erro;

        public ArquivoExcessão(string nome, Exception excessão) : base(nome)
        {
            this.erro = excessão;
        }

        public Exception Excessão => erro;

        public override string ObterChaveGrupo()
        {
            return erro.GetType().ToString();
        }

        internal override void Escrever(StreamWriter escritor)
        {
            base.Escrever(escritor);
            escritor.WriteLine(string.Format("      {0}", erro.Message));
        }
    }
}
