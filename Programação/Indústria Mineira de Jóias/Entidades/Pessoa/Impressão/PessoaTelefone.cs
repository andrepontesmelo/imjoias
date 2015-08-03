using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Pessoa.Impressão
{
    public class PessoaTelefone : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        private uint pessoa;
        private string telefone;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        public uint Pessoa { get { return pessoa; } }
        public string Telefone { get { return telefone; } }

        public static List<PessoaTelefone> ObterTelefones()
        {
            //string cmd = "SELECT pessoa, concat(telefone, ' ', ifnull(observacoes,''), ' [', descricao,']') as telefone FROM telefone";
            string cmd = "SELECT pessoa, concat(descricao, ':', telefone, ' ', ifnull(observacoes,''), '<br>') as telefone FROM telefone";
            return Mapear<PessoaTelefone>(cmd);
        }
    }
}
