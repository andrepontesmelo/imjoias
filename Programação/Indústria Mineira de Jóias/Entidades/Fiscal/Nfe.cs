using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Fiscal
{
    public class Nfe : DbManipulaçãoAutomática
    {
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        
        [DbRelacionamento("codigo","venda")]
        private Entidades.Relacionamento.Venda.Venda venda;

        public Entidades.Relacionamento.Venda.Venda Venda
        {
            get { return venda; }
            set { venda = value; }
        }

        private uint fatura;

        public uint Fatura
        {
            get { return fatura; }
            set { fatura = value; }
        }

        private uint cfop;

        public uint Cfop
        {
            get { return cfop; }
            set { cfop = value; }
        }
        private uint nfe;

        public uint NfeNúmero
        {
            get { return nfe; }
            set { nfe = value; }
        }
        private double aliquota;

        public double Aliquota
        {
            get { return aliquota; }
            set { aliquota = value; }
        }

        [DbRelacionamento("codigo", "funcionario")]
        private Entidades.Pessoa.Funcionário funcionario;

        public Entidades.Pessoa.Funcionário Funcionário
        {
            get { return funcionario; }
            set { funcionario = value; }
        }

        public Nfe()
        {
            data = DadosGlobais.Instância.HoraDataAtual;
        }
    }
}
