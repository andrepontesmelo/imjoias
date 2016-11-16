using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ArquivoExceção : Arquivo
    {
        private Exception erro;

        public ArquivoExceção(string nome, Exception Exceção) : base(nome)
        {
            this.erro = Exceção;
        }

        public Exception Exceção => erro;

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
