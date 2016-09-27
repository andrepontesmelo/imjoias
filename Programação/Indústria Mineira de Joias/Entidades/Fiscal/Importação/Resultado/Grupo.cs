using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public abstract class Grupo
    {
        protected List<Arquivo> arquivos;
        protected StreamWriter escritor;

        public Grupo(StreamWriter escritor)
        {
            arquivos = new List<Arquivo>();
            this.escritor = escritor;
        }

        internal void Adicionar(Arquivo arquivo)
        {
            arquivos.Add(arquivo);
        }

        internal virtual void EscreverResumo()
        {
            escritor.WriteLine(string.Format(" > {0} arquivo{1}", arquivos.Count,
                arquivos.Count == 1 ? "" : "s"));
        }

        internal abstract string Título { get; }

        private void EscreverItens()
        {
            int x = 0;

            foreach (Arquivo arquivo in arquivos)
            {
                escritor.Write(string.Format("{0} ", ++x));
                arquivo.Escrever(escritor);
            }
        }

        private void EscreverTítulo()
        {
            escritor.WriteLine();
            escritor.WriteLine(Título);
            escritor.WriteLine();
        }

        public void Escrever()
        {
            EscreverTítulo();
            EscreverItens();
        }

        internal int ObtemTamanhoMáximo(int tamanhoMáximo)
        {
            foreach (Arquivo arquivo in arquivos)
                if (arquivo.Nome.Length > tamanhoMáximo)
                    tamanhoMáximo = arquivo.Nome.Length;

            return tamanhoMáximo;
        }
    }
}
