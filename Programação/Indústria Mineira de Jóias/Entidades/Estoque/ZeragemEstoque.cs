using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    public class ZeragemEstoque : DbManipulaçãoAutomática
    {
        [DbChavePrimária]
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        [DbRelacionamento("codigo", "funcionario")]
        private Entidades.Pessoa.Funcionário funcionario;

        public Entidades.Pessoa.Funcionário Funcionário
        {
            get { return funcionario; }
            set { funcionario = value; }
        }
        private string observacoes;

        public string Observações
        {
            get { return observacoes; }
            set { observacoes = value; }
        }

        public ZeragemEstoque()
        {
            data = DadosGlobais.Instância.HoraDataAtual;
            funcionario = Entidades.Pessoa.Funcionário.FuncionárioAtual;
        }

        public static List<ZeragemEstoque> Obter()
        {
            return Mapear<ZeragemEstoque>("select * from zeragemestoque");
        }
    }
}
