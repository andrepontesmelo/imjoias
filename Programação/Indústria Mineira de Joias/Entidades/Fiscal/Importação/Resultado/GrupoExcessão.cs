using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class GrupoExceção : Grupo
    {
        private static readonly int MAX_DESCRIÇÕES_ERRO_EXIBIR_CABEÇALHO_GRUPO = 5;

        string tipoExceção;
        
        public GrupoExceção(string tipoExceção, StreamWriter escritor) : base(escritor)
        {
            this.tipoExceção = tipoExceção;
        }

        internal override string Título => tipoExceção;

        internal override void EscreverResumo()
        {
            base.EscreverResumo();
            MostrarMensagens(ObterMensagens());
        }

        private SortedSet<string> ObterMensagens()
        {
            SortedSet<string> mensagens = new SortedSet<string>();

            foreach (ArquivoExceção arquivo in arquivos)
            {
                mensagens.Add(arquivo.Exceção.Message);
                if (mensagens.Count > MAX_DESCRIÇÕES_ERRO_EXIBIR_CABEÇALHO_GRUPO)
                    break;
            }

            return mensagens;
        }

        public void MostrarMensagens(SortedSet<string> mensagens)
        {
            if (mensagens.Count < MAX_DESCRIÇÕES_ERRO_EXIBIR_CABEÇALHO_GRUPO)
            {
                foreach (string descrição in mensagens)
                    escritor.WriteLine(string.Format("  .. {0}", descrição));
            }
            else
                escritor.WriteLine("    [...]");
        }
    }
}
