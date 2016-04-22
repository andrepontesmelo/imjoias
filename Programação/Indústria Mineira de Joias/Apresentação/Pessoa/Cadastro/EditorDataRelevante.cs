using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    public class EditorDataRelevante : EditorPessoaBase<DataRelevante, DadosDataRelevante>
    {
        protected override DataRelevante ConstruirNovoItem()
        {
            DataRelevante data;

            data = new DataRelevante(Pessoa);

            return data;
        }

        protected override void AoDefinirPessoa()
        {
            base.AoDefinirPessoa();
        
            foreach (DataRelevante data in Pessoa.DatasRelevantes)
                Adicionar(data);
        }

        protected override void AoAdicionar(DataRelevante item)
        {
            base.AoAdicionar(item);
            Pessoa.DatasRelevantes.Adicionar(item);
        }

        protected override void AoRemover(DataRelevante item)
        {
            base.AoRemover(item);
            Pessoa.DatasRelevantes.Remover(item);
        }
    }
}
