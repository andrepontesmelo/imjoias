using Acesso.Comum;
using System.Collections.Generic;
using System;

namespace Entidades.Coaf.Inconsistência
{
    public class InconsistênciaPessoa : DbManipulaçãoSimples
    {
        private uint pessoa;
        private List<EnumInconsistência> inconsistências;

        public List<EnumInconsistência> Inconsistências => inconsistências;

        public InconsistênciaPessoa(uint pessoa)
        {
            this.pessoa = pessoa;
            inconsistências = new List<EnumInconsistência>();
        }

        public static Dictionary<uint, InconsistênciaPessoa> ObterInconsistências()
        {
            var lista = Mapear<PessoaMotivo>("select * from coaf_inconsistencia");
            Dictionary<uint, InconsistênciaPessoa> resultado = new Dictionary<uint, InconsistênciaPessoa>();

            foreach (PessoaMotivo pessoaMotivo in lista)
            {
                InconsistênciaPessoa inconsistênciaPessoa;
                if (!resultado.TryGetValue(pessoaMotivo.Pessoa, out inconsistênciaPessoa))
                {
                    inconsistênciaPessoa = new InconsistênciaPessoa(pessoaMotivo.Pessoa);
                    resultado[pessoaMotivo.Pessoa] = inconsistênciaPessoa;
                }

                inconsistênciaPessoa.Inconsistências.Add(pessoaMotivo.Motivo);
            }

            return resultado;
        }

        public string Concatenar()
        {
            string resultado = "";
            bool primeiro = true;

            foreach (EnumInconsistência inconsistência in inconsistências)
            {
                if (!primeiro)
                    resultado += "; ";

                resultado += ObterDescrição(inconsistência);
                primeiro = false;
            }

            return resultado;
        }

        private string ObterDescrição(EnumInconsistência inconsistência)
        {
            switch (inconsistência)
            {
                case EnumInconsistência.IdentidadeInválida:
                    return "Pessoa física sem identidade";
                case EnumInconsistência.PFNomeInválido:
                    return "Pessoa física sem nome";
                case EnumInconsistência.OrgãoEmissorInválido:
                    return "Pessoa física sem orgão emissor";
                case EnumInconsistência.PessoaFísicaSemCPF:
                    return "Pessoa física sem CPF";
                case EnumInconsistência.PJSemPreposto:
                    return "Pessoa juridica sem preposto";
                case EnumInconsistência.PrepostoIdentidadeInválida:
                    return "Preposto sem identidade";
                case EnumInconsistência.PJNomeFantasiaInválido:
                    return "Pessoa jurídica sem nome de fantasia";
                case EnumInconsistência.PJRazãoSocialInválido:
                    return "Pessoa jurídica sem razão social";
                case EnumInconsistência.PrepostoÓrgãoEmissorInválido:
                    return "Preposto sem órgão emissor da identidade";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
