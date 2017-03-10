using System.Collections.Generic;

namespace Entidades.Coaf.Inconsistência
{
    public class InconsistênciaPessoa
    {
        private const int TAMANHO_MÍNIMO_NOME = 10;

        Pessoa.Pessoa pessoa;

        public InconsistênciaPessoa(Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public bool VerificarNomeConsistente()
        {
            return pessoa.Nome.Trim().Length > TAMANHO_MÍNIMO_NOME;
        }

        public virtual List<EnumInconsistência> ObterInconsistências()
        {
            List<EnumInconsistência> resultado = new List<EnumInconsistência>();

            if (!VerificarNomeConsistente())
                resultado.Add(EnumInconsistência.NomeInválido);

            return resultado;
        }
    }
}
