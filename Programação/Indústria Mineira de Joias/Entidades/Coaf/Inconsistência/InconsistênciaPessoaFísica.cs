using System.Collections.Generic;
using Entidades.Pessoa;

namespace Entidades.Coaf.Inconsistência
{
    public class InconsistênciaPessoaFísica : InconsistênciaPessoa
    {
        public InconsistênciaPessoaFísica(PessoaFísica pessoaFísica) : base(pessoaFísica)
        {
        }

        public bool VerificarCpfVálido()
        {
            return PessoaFísica.CPFVálido;
        }


        public override List<EnumInconsistência> ObterInconsistências()
        {
            var resultado = base.ObterInconsistências();

            if (!VerificarCpfVálido())
                resultado.Add(EnumInconsistência.CpfInválido);

            return resultado;

        }
        private PessoaFísica PessoaFísica => (PessoaFísica) pessoa;
    }
}
