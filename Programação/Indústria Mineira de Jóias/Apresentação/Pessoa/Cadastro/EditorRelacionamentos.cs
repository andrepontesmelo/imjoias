/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class EditorRelacionamentos : EditorPessoaBase<RelacionamentoInterpessoal, DadosRelacionamento>
    {
        protected override RelacionamentoInterpessoal ConstruirNovoItem()
        {
            RelacionamentoInterpessoal relacionamento;

            relacionamento = new RelacionamentoInterpessoal();
            relacionamento.Pessoa1 = Pessoa;

            return relacionamento;
        }

        protected override void ConfigurarControle(DadosRelacionamento controle)
        {
            controle.Referência = Pessoa;
            base.ConfigurarControle(controle);
        }

        protected override void AoDefinirPessoa()
        {
            base.AoDefinirPessoa();

            foreach (RelacionamentoInterpessoal relacionamento in Pessoa.Relacionamentos)
                Adicionar(relacionamento);
        }

        protected override void AoAdicionar(RelacionamentoInterpessoal item)
        {
            base.AoAdicionar(item);
            Pessoa.Relacionamentos.Adicionar(item);
        }

        protected override void AoRemover(RelacionamentoInterpessoal item)
        {
            base.AoRemover(item);
            Pessoa.Relacionamentos.Remover(item);
        }
    }
}
*/