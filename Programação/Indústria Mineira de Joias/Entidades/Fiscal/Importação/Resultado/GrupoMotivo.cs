using System;
using System.IO;

namespace Entidades.Fiscal.Importação.Resultado
{
    public class GrupoMotivo : Grupo
    {
        private Motivo motivo;
        private string título;

        public GrupoMotivo(Motivo motivo, StreamWriter escritor) : base(escritor)
        {
            this.motivo = motivo;
            this.título = ObterTítulo();
        }

        private string ObterTítulo()
        {
            switch (motivo)
            {
                case Motivo.ChaveJáImportada:
                    return "Chave já importada";

                case Motivo.NotaEmitidaEstaEmpresa:
                    return "Nota emitida por esta empresa";

                case Motivo.NotaEmitidaOutraEmpresa:
                    return "Nota emitida por outra empresa";

                case Motivo.NãoÉCancelamento:
                    return "Não ser cancelamento";

                case Motivo.CancelamentoJáRegistrado:
                    return "Cancelamento já registrado";

                default:
                    throw new NotImplementedException();
            }
        }

        internal override void EscreverResumo()
        {
            escritor.WriteLine(string.Format(" > {0} arquivo{1} {2} ignorado{1} pelo motivo de {3}", 
                arquivos.Count, // 0
                arquivos.Count == 1 ? "" : "s", //1 
                arquivos.Count == 1 ? "foi" : "foram", //2
                Título.ToLower())); //3 
        }

        internal override string Título => título;
    }
}
