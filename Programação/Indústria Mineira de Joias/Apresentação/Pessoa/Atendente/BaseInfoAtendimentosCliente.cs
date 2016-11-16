using Apresentação.Formulários;
using Entidades;
using System.Collections.Generic;

namespace Apresentação.Atendente
{
    public partial class BaseInfoAtendimentosCliente : Apresentação.Atendimento.Atendente.BaseInfoAtendimentos
    {
        private Entidades.Pessoa.Pessoa pessoa;

        public BaseInfoAtendimentosCliente(Entidades.Pessoa.Pessoa pessoa)
        {
            this.pessoa = pessoa;
            títuloBaseInferior.Título = "Atendimentos de " + pessoa.Nome;
            títuloBaseInferior.Descrição = "";

            InitializeComponent();
        }

        protected override void Recarregar()
        {
            if (pessoa == null)
                return;

            AguardeDB.Mostrar();

            try
            {
                List<Visita> visitas = Visita.ObterVisitas(pessoa);

                listViewVisitantes.Limpar();
                listViewVisitantes.AdicionarVisitas(visitas);
            }
            finally
            {
                AguardeDB.Fechar();
            }

        }
    }
}
