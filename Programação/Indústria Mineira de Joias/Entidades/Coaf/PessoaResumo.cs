using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Coaf
{
    public class PessoaResumo : DbManipulaçãoSimples
    {
        private uint codigo;
        private string nome;
        private string cpfcnpj;
        private decimal valoracumulado;

        public PessoaResumo()
        {
        }

        public uint Código => codigo;
        public string Nome => nome;
        public string CpfCnpj => cpfcnpj;
        public decimal ValorAcumulado => valoracumulado;

        public bool Notificável
        {
            get
            {
                var configuração = ConfiguraçõesCoaf.Instância;
                decimal valorMínimo = PoliticamenteExposta ? 
                    configuração.ValorMínimoAcumuladoPessoaExpostaPoliticamente.Valor : 
                    configuração.ValorMínimoAcumuladoDemaisPessoas.Valor;
                return (ValorAcumulado >= valorMínimo);
            }
        }

        public bool PoliticamenteExposta => CódigoPep.PessoaÉPoliticamenteExposta(Código);

        public static List<PessoaResumo> Obter(DateTime dataInicial)
        {
            string sql =
                string.Format("select p.codigo, p.nome, cpfemissor as cpfcnpj, sum(valortotal) as valoracumulado from saidafiscal " +
            " left join pessoafisica pf on pf.cpf=cpfemissor " +
            " join pessoa p on pf.codigo=p.codigo " +
            " where cpfemissor is not null " +
            " and datasaida > {0} " +
            " and cancelada = 0 group by cpfemissor UNION " +
            " select p.codigo, p.nome, cnpjemissor as cpfcnpj, sum(valortotal) as valoracumulado from saidafiscal " +
            " left join pessoajuridica pj on pj.cnpj=cnpjemissor " +
            " join pessoa p on pj.codigo=p.codigo " +
            " where cnpjemissor is not null " +
            " and datasaida > {0} " +
            " and cancelada = 0 group by cnpjemissor ", DbTransformar(dataInicial));

            return Mapear<PessoaResumo>(sql);
        }
    }
}
