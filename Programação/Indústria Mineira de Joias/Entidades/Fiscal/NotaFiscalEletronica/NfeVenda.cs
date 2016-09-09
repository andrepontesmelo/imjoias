using Acesso.Comum;
using Entidades.Configuração;
using System;
using Entidades.Relacionamento.Venda;
using System.Collections.Generic;

namespace Entidades.Fiscal.NotaFiscalEletronica
{
    [DbTabela("nfe")]
    public class NfeVenda : DbManipulaçãoAutomática
    {
        [DbRelacionamento("codigo", "funcionario")]
        private Pessoa.Funcionário funcionário;

        [DbColuna("aliquota")]
        private double alíquota;
        private DateTime data;
        private uint fatura;

        [DbRelacionamento("codigo", "venda")]
        private Venda venda;
        private uint cfop;
        private uint nfe;

        public Pessoa.Funcionário Funcionário => funcionário;
        public double Alíquota => alíquota;
        public uint Fatura => fatura;
        public DateTime Data => data;
        public Venda Venda => venda;
        public uint Cfop => cfop;
        public uint Nfe => nfe;

        public NfeVenda()
        {
        }

        public NfeVenda(Venda venda, int nfe, int cfop, int fatura, double alíquota)
        {
            data = DadosGlobais.Instância.HoraDataAtual;
            funcionário = Pessoa.Funcionário.FuncionárioAtual;

            this.fatura = (uint)fatura;
            this.alíquota = alíquota;
            this.cfop = (uint)cfop;
            this.nfe = (uint) nfe;
            this.venda = venda;
        }
    }
}
