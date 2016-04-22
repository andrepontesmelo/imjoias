using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Pessoa.Endereço;

namespace Entidades.Pessoa.Impressão
{
    public class PessoaImpressão : DbManipulaçãoAutomática
    {
#pragma warning disable 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        private uint codigo;
        private string nome;

        [DbAtributo(TipoAtributo.Ignorar)]
        private string telefones;

        [DbAtributo(TipoAtributo.Ignorar)]
        private string enderecos;

        private string email;
        private ulong classificacoes;
        private string documento;
        
        [DbColuna("estadoCidade")]
        private string estadoCidade;
        
        [DbColuna("credito")]
        private double? crédito;

#pragma warning restore 0649        // Field 'field' is never assigned to, and will always have its default value 'value'

        public string Nome { get { return nome; } }
        public string Telefones { get { return telefones; } set { telefones = value; }  }
        public string Endereços { get { return enderecos; } set { enderecos = value; }  }
        public string Email { get { return email; } }
        public ulong Classificações { get { return classificacoes; } }
        public uint Código { get { return codigo; } }
        public string Documento { get { return documento; } }
        public double? Crédito { get { return crédito; } }
        public string EstadoCidade { get { return estadoCidade; } set { estadoCidade = value; } }

        //* Ordenção: (alfabetica, código cliente, nome da cidade & logradouro)
        public enum OrdemImpressão { Alfabética, CódCliente, Endereço }

        public static List<PessoaImpressão> ObterPessoas(OrdemImpressão ordem, Região região)
        {
            string cmd = "SELECT pessoa.codigo, pessoa.nome, email, documentos.documento, classificacoes, pessoa.credito, concat(estado.sigla, ' - ', localidade.nome) as EstadoCidade from pessoa, "
            + " endereco, localidade, estado "
            + " join (select codigo, concat('CPF: ', cpf, ' - RG: ', diEmissor, ' ', di) as documento from pessoafisica "
            + " UNION select codigo, concat('CNPJ: ', cnpj, ' - INSC. EST.: ', inscEstadual) "
            + " as documento from pessoajuridica) documentos "
            + " WHERE pessoa.codigo=documentos.codigo "
            + " AND pessoa.codigo=endereco.pessoa and endereco.localidade = localidade.codigo "
            + " AND estado.codigo=localidade.estado "
            + ( região != null ?  " AND pessoa.regiao = " + região.Código.ToString() : " ") 
            + " group by pessoa.codigo ";
            
            // região, sigla estado, Cidade, Nome de Pessoa.
            if (ordem == OrdemImpressão.Alfabética)
                cmd += " ORDER BY estado.sigla, localidade.nome, pessoa.nome";
            else if (ordem == OrdemImpressão.Endereço)
                cmd += " ORDER BY estado.sigla, localidade.nome, bairro, logradouro, numero, pessoa.nome";
            else if (ordem == OrdemImpressão.CódCliente)
                cmd += " ORDER BY pessoa.codigo";

            List<PessoaImpressão> lista = Mapear<PessoaImpressão>(cmd);

            // Prepara para pegar telefones e endereços:
            Dictionary<uint, PessoaImpressão> hashCódigoPessoa = new Dictionary<uint, PessoaImpressão>();
            foreach (PessoaImpressão pessoa in lista)
                hashCódigoPessoa.Add(pessoa.codigo, pessoa);

            // Pega os telefones:
            List<PessoaTelefone> todosTelefones = PessoaTelefone.ObterTelefones();
            foreach (PessoaTelefone t in todosTelefones)
            {
                if (t.Telefone != null &&
                    hashCódigoPessoa.ContainsKey(t.Pessoa))
                {
                    PessoaImpressão pessoa;
                    hashCódigoPessoa.TryGetValue(t.Pessoa, out pessoa);

                    pessoa.Telefones += t.Telefone + "\n";
                }
            }

            // Pega os endereços:
            List<PessoaEndereço> todosEndereços = PessoaEndereço.ObterEndereços();
            foreach (PessoaEndereço e in todosEndereços)
            {
                if (e.Endereço != null &&
                    hashCódigoPessoa.ContainsKey(e.Pessoa))
                {
                    PessoaImpressão pessoa;
                    hashCódigoPessoa.TryGetValue(e.Pessoa, out pessoa);
                    pessoa.Endereços += e.Endereço + "\n";
                }
            }


            return lista;
        }

    }
}
