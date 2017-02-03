using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    [DbTabela("nfe")]
    public class VínculoNfeVenda : DbManipulaçãoAutomática
    {
        [DbRelacionamento("codigo", "funcionario")]
        private Pessoa.Funcionário funcionário;

        [DbColuna("aliquota")]
        private double alíquota;
        private DateTime data;
        private uint fatura;

        [DbRelacionamento("codigo", "venda")]
        private Relacionamento.Venda.Venda venda;
        private uint cfop;
        private uint nfe;

        public Pessoa.Funcionário Funcionário => funcionário;
        public double Alíquota => alíquota;
        public uint Fatura => fatura;
        public DateTime Data => data;
        public Relacionamento.Venda.Venda Venda => venda;
        public uint Cfop => cfop;
        public uint Nfe => nfe;

        public VínculoNfeVenda()
        {
        }

        public VínculoNfeVenda(Relacionamento.Venda.Venda venda, int nfe, int cfop, int fatura, double alíquota)
        {
            data = DadosGlobais.Instância.HoraDataAtual;
            funcionário = Pessoa.Funcionário.FuncionárioAtual;

            this.fatura = (uint)fatura;
            this.alíquota = alíquota;
            this.cfop = (uint)cfop;
            this.nfe = (uint) nfe;
            this.venda = venda;
        }

        private static List<ParNfeVenda> ObterEntidades()
        {
            return Mapear<ParNfeVenda>("select nfe, venda from nfe");
        }

        public static Dictionary<uint, long> ObterHashNfeVenda()
        {
            var resultado = new Dictionary<uint, long>();

            foreach (ParNfeVenda entidade in ObterEntidades())
                resultado[entidade.nfe] = entidade.venda;

            return resultado;
        }

        public class ParNfeVenda
        {
            public uint nfe;
            public long venda;
        }
    }
}
