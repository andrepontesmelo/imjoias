using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using System.Collections;

namespace Apresentação.Importação
{
    public class RankingItem : DbManipulaçãoAutomática
    {
        private string colaborador;
        private long intervencoes;

        public string Colaborador
        {
            get { return colaborador; }
        }

        public long Intervenções
        {
            get { return intervencoes; }
        }

        public RankingItem(string colaborador, int intervenções)
        {
            this.colaborador = colaborador;
            this.intervencoes = intervenções;
        }

        public RankingItem()
        {
        }

        public static List<RankingItem> ObterRanking()
        {
            return Mapear<RankingItem>("select pessoa.nome as colaborador, count(*) as intervencoes from cadcli join pessoa where  intervencaoFuncionario is not null and intervencaoFuncionario = pessoa.codigo group by intervencaoFuncionario order by intervencoes DESC");
        }
    }
}
