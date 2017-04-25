using System;
using System.Collections.Generic;
using Acesso.Comum;
using Entidades.Pessoa;

namespace Entidades.Coaf
{
    public class PessoaResumo : DbManipulaçãoSimples
    {
        private uint codigo;
        private string nome;
        private string cpfcnpj;
        private string cpfresponsavel;
        private decimal valoracumulado;

        public PessoaResumo() { }

        public uint Código => codigo;
        public string Nome => nome;
        public string CpfCnpj => cpfcnpj;
        public string CpfResponsável => cpfresponsavel;
        public decimal ValorAcumulado => valoracumulado;

        public bool Notificável
        {
            get
            {
                var configuração = ConfiguraçõesCoaf.Instância;
                decimal valorMínimo = PoliticamenteExposta ?
                    configuração.LimiarNotificaçãoPessoaExpostaPoliticamente.Valor :
                    configuração.LimiarNotificaçãoDemaisPessoas.Valor;
                return (ValorAcumulado >= valorMínimo);
            }
        }

        public PessoaExpostaPoliticamente PessoaPoliticamenteExposta => HashPessoaExpostaPoliticamente.ObterPessoa(cpfresponsavel);

        public string DescriçãoPessoaExposta
        {
            get
            {
                var pep = PessoaPoliticamenteExposta;
                return pep != null ? pep.Descrição : null;
            }
        }

        public bool PoliticamenteExposta => HashPessoaExpostaPoliticamente.PessoaÉPoliticamenteExposta(cpfresponsavel);

        public bool Verificável
        {
            get
            {
                if (PoliticamenteExposta)
                    return ValorAcumulado >= ConfiguraçõesCoaf.Instância.LimiarVerificaçãoPessoaExpostaPoliticamente;
                else
                    return ValorAcumulado >= ConfiguraçõesCoaf.Instância.LimiarVerificaçãoDemaisPessoas;
            }
        }

        public static List<PessoaResumo> Obter(DateTime dataInicial, DateTime dataFinal, decimal valorMínimo)
        {
            dataInicial = RemoverHorário(dataInicial);
            dataFinal = RemoverHorário(dataFinal);

            string sql =
                string.Format("select p.codigo, p.nome, cpfemissor as cpfcnpj, cpfemissor as cpfresponsavel, sum(valortotal) as valoracumulado from saidafiscal " +
                    " left join pessoafisica pf on pf.cpf=cpfemissor " +
                    " left join pessoa p on pf.codigo=p.codigo " +
                    " where cpfemissor is not null " +
                    " and {0} " +
                    " and cancelada = 0 group by cpfemissor " +
                    " HAVING sum(valortotal) >= {1} " +
                    " UNION " +
                    " select p.codigo, p.nome, cnpjemissor as cpfcnpj, cpfPreposto as cpfresponsavel, sum(valortotal) as valoracumulado from saidafiscal " +
                    " left join pessoajuridica pj on pj.cnpj=cnpjemissor " +
                    " left join pessoa p on pj.codigo=p.codigo " +
                    " where cnpjemissor is not null " +
                    " and {0} " +
                    " and cancelada = 0 " +
                    " group by cnpjemissor " +
                    " HAVING sum(valortotal) >= {1} order by valoracumulado desc",
                    DbDataEntre("datasaida", dataInicial, dataFinal),
                    DbTransformar(valorMínimo)
                );

            return Mapear<PessoaResumo>(sql);
        }

        public static List<PessoaResumo> Obter()
        {
            var resultado = Obter(ConfiguraçõesCoaf.Instância.DataInício,
                ConfiguraçõesCoaf.Instância.DataFim,
                ConfiguraçõesCoaf.Instância.ValorMínimoLimiar);

            return FiltrarResumosSemPessoaSemDocumento(resultado);
        }

        private static List<PessoaResumo> FiltrarResumosSemPessoaSemDocumento(List<PessoaResumo> resumos)
        {
            var resultado = new List<PessoaResumo>();

            foreach (PessoaResumo resumo in resumos)
            {
                if (!resumo.Código.Equals(0) || !String.IsNullOrWhiteSpace(resumo.CpfCnpj))
                    resultado.Add(resumo);
            }

            return resultado;
        }
    }
}