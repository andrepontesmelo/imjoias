using System.Collections.Generic;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class GrupoExcessão : Grupo
    {
        private static readonly int MAX_DESCRIÇÕES_ERRO_EXIBIR_CABEÇALHO_GRUPO = 5;

        string tipoExcessão;
        
        public GrupoExcessão(string tipoExcessão, StreamWriter escritor) : base(escritor)
        {
            this.tipoExcessão = tipoExcessão;
        }

        internal override string Título => tipoExcessão;

        internal override void EscreverResumo()
        {
            base.EscreverResumo();
            MostrarMensagens(ObterMensagens());
        }

        private SortedSet<string> ObterMensagens()
        {
            SortedSet<string> mensagens = new SortedSet<string>();

            foreach (ArquivoExcessão arquivo in arquivos)
            {
                mensagens.Add(arquivo.Excessão.Message);
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
