using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Entidades;
using Apresentação.Formulários;

namespace Apresentação.Usuário.Agendamentos
{
    public class ControleAgendamento : Controle, IDisposable
    {
        private ControladorBaseInferior controlador;

        /// <summary>
        /// Constrói o controle de agendamento.
        /// </summary>
        public ControleAgendamento(ControladorBaseInferior controlador)
        {
            this.controlador = controlador;
        }

        protected override int IntervaloTemporizador
        {
            get
            {
                return Entidades.Configuração.DadosGlobais.Instância.AgendamentoIntervalo;
            }
        }

        protected override int AtrasoParaPrimeiraVerificação
        {
            get
            {
                return Entidades.Configuração.DadosGlobais.Instância.AgendamentoIntervalo;
            }
        }

        /// <summary>
        /// Liberar os recursos.
        /// </summary>
        public void Dispose()
        {
            try
            {
                temporizador.Dispose();
            }
            catch { }
        }

        /// <summary>
        /// Verifica agendamentos no banco de dados.
        /// </summary>
        protected override void  TemporizadorDisparou(object obj)
        {
            try
            {
                IList<Agendamento> agendamentos = Agendamento.ObterAgendamentosDespertados();

                foreach (Agendamento agendamento in agendamentos)
                    DespertarBalão(agendamento);
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
        }

        /// <summary>
        /// Objetivo: mostrar o balão
        /// </summary>
        /// <param name="agendamentoAtual">a ser mostrado no balão</param>
        private void DespertarBalão(Agendamento agendamentoAtual)
        {
            DespertadorBalão balão = new DespertadorBalão(agendamentoAtual);

            // Colocar evento para fechar
            balão.Closed += new EventHandler(AoFecharBalão);
            balão.AlterarAgendamento += new DespertadorBalão.DAgendamento(AbrirAlterar);
            balão.ShowDialog();
        }


        /// <summary>
        /// Ocorre ao fechar o balão.
        /// </summary>
        private void AoFecharBalão(object sender, EventArgs e)
        {
            try
            {
                DespertadorBalão balão = (DespertadorBalão)sender;

                if (!balão.UsuárioAlterou)
                    balão.Entidade.DesligarDespertador();

                balão.Dispose();
            }
            catch (Exception erro)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
            }
        }

        /// <summary>
        /// Altera um agendamento. 
        /// Para isso, abre a janela para usuário fazer alterações
        /// </summary>
        private void AbrirAlterar(Agendamento agendamentoAtual)
        {
            try
            {
                using (InserirAgendamento dlg = new InserirAgendamento())
                {
                    dlg.Descrição = agendamentoAtual.Descrição;
                    dlg.Alarme = agendamentoAtual.Alarme;
                    dlg.HoraEvento = agendamentoAtual.Data;

                    dlg.ShowDialog();

                    if (dlg.AtualizaçãoBemSucedida)
                    {
                        agendamentoAtual.Data = dlg.HoraEvento;
                        agendamentoAtual.Descrição = dlg.Descrição;
                        if (dlg.Despertar)
                            agendamentoAtual.Alarme = dlg.Alarme;
                        else
                            agendamentoAtual.Alarme = DateTime.MinValue;

                        if (!agendamentoAtual.Cadastrado)
                            agendamentoAtual.Cadastrar();
                        else
                            agendamentoAtual.Atualizar();
                    }
                }
            }
            catch (Exception e)
            {
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
        }
    }
}
