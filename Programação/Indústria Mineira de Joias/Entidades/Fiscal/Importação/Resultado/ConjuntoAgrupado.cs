using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class ConjuntoAgrupado
    {
        Dictionary<string, Grupo> grupos;
        private int totalArquivos;
        protected StreamWriter escritor;

        public ConjuntoAgrupado(StreamWriter escritor)
        {
            if (escritor == null)
                throw new NullReferenceException();

            grupos = new Dictionary<string, Grupo>();
            this.escritor = escritor;
        }

        public void Adicionar(Arquivo arquivo)
        {
            Grupo grupo;

            string chave = arquivo.ObterChaveGrupo();

            if (!grupos.TryGetValue(chave, out grupo))
            {
                grupo = CriarGrupo(chave);
                grupos[chave] = grupo;
            }

            grupo.Adicionar(arquivo);
            totalArquivos++;
        }

        protected virtual Grupo CriarGrupo(string chave)
        {
            return new GrupoÚnico(escritor);
        }

        internal int ObtemTamanhoMáximo(int tamanhoMáximo)
        {
            foreach (Grupo grupo in grupos.Values)
                tamanhoMáximo = grupo.ObtemTamanhoMáximo(tamanhoMáximo);

            return tamanhoMáximo;
        }

        public int TotalArquivos => totalArquivos;

        internal void Escrever()
        {
            if (TotalArquivos == 0)
                return;

            foreach (Grupo grupo in grupos.Values)
                grupo.EscreverResumo();

            foreach (Grupo grupo in grupos.Values)
                grupo.Escrever();
        }
    }
}
