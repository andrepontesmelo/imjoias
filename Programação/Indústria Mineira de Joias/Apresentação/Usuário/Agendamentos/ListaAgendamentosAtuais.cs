using System;
using System.Collections.Generic;
using System.Text;
using Apresentação.Formulários;
using Entidades;

namespace Apresentação.Usuário.Agendamentos
{
    public class ListaAgendamentosAtuais : ListaAgendamentos, IAoMostrarBaseInferior
    {
        public void AoExibirDaPrimeiraVez(Apresentação.Formulários.BaseInferior baseInferior)
        {
        }

        public void AoExibir(Apresentação.Formulários.BaseInferior baseInferior)
        {
            Agendamento[] agendamentos;

            agendamentos = Agendamento.ObterAgendamentos(Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual.Date);

            PreencherListView(agendamentos);
        }
    }
}
