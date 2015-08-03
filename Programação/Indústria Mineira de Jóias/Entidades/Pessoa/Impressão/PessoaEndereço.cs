using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa.Impressão
{
    public class PessoaEndereço : DbManipulaçãoAutomática
    {
#pragma warning disable 0649
        private uint pessoa;
        private string endereco;

#pragma warning restore 0649

        public uint Pessoa { get { return pessoa; } }
        public string Endereço { get { return endereco; } }

        public static List<PessoaEndereço> ObterEndereços()
        {
            string cmd = " SELECT pessoa.codigo as pessoa, concat(ifnull(logradouro,''), ' ', ifnull(numero,''), ' - ',  " +
                " ifnull(complemento,''), ' ', ifnull(bairro,''), '<br>', " +
                " '<b>', ifnull(localidade.nome,''), ' - ', ifnull(estado.sigla,''), if(pais.codigo > 1, concat(' - ', pais.nome, ' '), '') , '</b>', if(length(trim(ifnull(cep,''))) = 0, '', concat(' CEP: ', cep)),'<br><br>') as endereco from pessoa,  " +
                " endereco, localidade, estado, pais where  " +
                 " pessoa.codigo=endereco.pessoa and  " +
                " endereco.localidade=localidade.codigo " +
                " and estado.codigo=localidade.estado and  " +
                " pais.codigo=estado.pais ";


            return Mapear<PessoaEndereço>(cmd);
        }
    }
}
