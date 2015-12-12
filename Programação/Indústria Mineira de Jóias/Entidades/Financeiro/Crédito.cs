using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;

namespace Entidades.Financeiro
{
    [DbTabela("credito")]
    public class Crédito : DbManipulaçãoAutomática
    {
#pragma warning disable 0649
        [DbChavePrimária(true)]
        private uint codigo;

        [DbRelacionamento("codigo", "pessoa")]
        private Entidades.Pessoa.Pessoa pessoa;

        private double valor;
        private DateTime data;
        private string descricao;

#pragma warning restore 0649

        public uint Código
        {
            get { return codigo; }
        }

        public double Valor 
        { 
            get { return valor; }
            set
            {
                valor = value;
                DefinirDesatualizado();
            }
        }

        public DateTime Data
        {
            get { return data; }
            set 
            {
                data = value;
                DefinirDesatualizado();
            }
        }

        public string Descrição
        {
            get { return descricao; }
            set
            {
                descricao = value;
                DefinirDesatualizado();
            }
        }


        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                pessoa = value;
                DefinirDesatualizado();
            }
        }

        public Crédito()
        {
            data = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual;
        }

        public static List<Crédito> ObterCréditos(Entidades.Pessoa.Pessoa pessoa)
        {
            return Mapear<Crédito>("select * from credito where pessoa = " + DbTransformar(pessoa.Código));
        }

        public static List<Crédito> ObterCréditosNãoUtilizados(Entidades.Pessoa.Pessoa pessoa)
        {
            return Mapear<Crédito>("select credito.* from credito left join vendacredito " +
            " on credito.codigo=vendacredito.credito " +
            " where pessoa = " + DbTransformar(pessoa.Código) + " and vendacredito.credito is null ");
        }
    }
}

