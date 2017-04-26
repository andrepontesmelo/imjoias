using Acesso.Comum;
using System;
using System.Collections.Generic;

namespace Entidades.Coaf
{
    public class Notificação : DbManipulaçãoSimples
    {
        private int codigo;
        private DateTime data;
        private DateTime ocorrenciainicio;
        private DateTime ocorrenciafim;
        private decimal valor;
        private string cpf;
        private string cnpj;
        private string nome;

        public Notificação()
        {
        }

        public int Código => codigo;
        public DateTime Data => data;
        public DateTime OcorrênciaInício => ocorrenciainicio;
        public DateTime OcorrênciaFim => ocorrenciafim;
        public decimal Valor => valor;
        public string CPF => cpf;
        public string CNPF => cnpj;
        public string Nome => nome;

        public static List<Notificação> Obter()
        {
            return Mapear<Notificação>("select c.*, ifnull(p1.nome,p2.nome) as nome from coafnotificacao c " + 
                " LEFT JOIN pessoafisica pf on pf.cpf=c.cpf LEFT JOIN pessoa p1 on p1.codigo=pf.codigo " + 
                " LEFT JOIN pessoajuridica pj on pj.cnpj=c.cnpj LEFT JOIN pessoa p2 on p2.codigo=pj.codigo ");
        }
    }
}
