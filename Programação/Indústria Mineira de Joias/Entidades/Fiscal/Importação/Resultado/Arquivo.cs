using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class Arquivo
    {
        protected string nome;
        private string idDocumentoFiscal;

        public Arquivo(string nome, string idDocumentoFiscal)
        {
            this.nome = nome;
            this.idDocumentoFiscal = idDocumentoFiscal;
        }

        public Arquivo(string nome) : this(nome, null)
        {
        }

        public virtual string ObterChaveGrupo()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            if (idDocumentoFiscal == null)
                return nome;

            return string.Format("Id {0} @ {1}", idDocumentoFiscal, nome);
        }

        public string Nome => nome;

        internal virtual void Escrever(StreamWriter escritor)
        {
            escritor.WriteLine(ToString());
        }
    }
}
