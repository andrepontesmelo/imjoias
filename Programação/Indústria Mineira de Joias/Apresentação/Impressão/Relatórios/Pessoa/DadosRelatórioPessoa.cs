using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Impressão.Relatórios.Pessoa
{
    public class DadosRelatórioPessoa : DadosRelatório
    {
        private Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão ordem;
        private Região região;

        public Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão Ordem
        {
            get { return ordem; }
        }

        public Região Região
        {
            get { return região; }
        }

        public DadosRelatórioPessoa(Entidades.Pessoa.Impressão.PessoaImpressão.OrdemImpressão ordem, Região região)
            : base()
        {
            this.ordem = ordem;
            this.região = região;
        }
    }
}
