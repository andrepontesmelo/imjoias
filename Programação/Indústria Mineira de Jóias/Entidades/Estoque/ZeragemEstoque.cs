using Acesso.Comum;
using Entidades.Configuração;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entidades.Estoque
{
    public class ZeragemEstoque : DbManipulaçãoAutomática, IComparable<ZeragemEstoque>
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

        private int comissaoVigente;

        public int ComissaoVigente
        {
            get { return comissaoVigente; }
            set { comissaoVigente = value; }
        }

        public ZeragemEstoque()
        {
            data = DadosGlobais.Instância.HoraDataAtual;
            funcionario = Entidades.Pessoa.Funcionário.FuncionárioAtual;
        }

        public ZeragemEstoque(int comissãoVigente)
        {
            this.comissaoVigente = comissãoVigente;
        }

        public override void Cadastrar()
        {
            comissaoVigente = ObterComissãoVigente();
        
            base.Cadastrar();
        }

        private int ObterComissãoVigente()
        {
            IDbConnection conexão = Conexão;

            using (IDbCommand cmd = conexão.CreateCommand())
            {
                cmd.CommandText = " select max(codigo) from comissao ";

                object objeto = cmd.ExecuteScalar();

                return ((int)objeto);
            }
        }

        public static List<ZeragemEstoque> Obter()
        {
            return Mapear<ZeragemEstoque>("select * from zeragemestoque order by comissaoVigente desc, data desc ");
        }

        //public int CompareTo(ZeragemEstoque outro)
        {
            return comissaoVigente.CompareTo(outro.comissaoVigente);
        }
    }
}
