using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Acesso.Comum;
using Entidades;
using Entidades.Configuração;
using Entidades.Pessoa;

namespace Apresentação.Usuário.Visitantes
{
    /// <summary>
    /// Controle sobre ações tomadas por visitantes.
    /// </summary>
    internal class ControleVisitantes : Controle
    {
        /// <summary>
        /// Setores observados.
        /// </summary>
        private Entidades.Setor[] setores;

        private DateTime últimaVerificação;

        /// <summary>
        /// Constrói o controle de visitantes.
        /// </summary>
        public ControleVisitantes()
        {
            ConfiguraçãoUsuário<string> configuração;

            // Abrir chave de configuração.
            if (Funcionário.FuncionárioAtual.Setor.Nome.ToLower() == "atacado")
                configuração = new ConfiguraçãoUsuário<string>(DadosGlobais.Instância.ChaveConfiguraçãoSetorVisitantes, "Atacado, Alto-Atacado");
            else
                configuração = new ConfiguraçãoUsuário<string>(DadosGlobais.Instância.ChaveConfiguraçãoSetorVisitantes, Funcionário.FuncionárioAtual.Setor.Nome);

            // Carregar configurações.
            CarregarSetores(configuração);

            últimaVerificação = DadosGlobais.Instância.HoraDataAtual;
        }

        #region Configuração

        /// <summary>
        /// Carrega setores da configuração do usuário.
        /// </summary>
        /// <param name="configuração">Configuração do usuário.</param>
        /// <remarks>
        /// Caso não exista configuração deste usuário,
        /// o valor padrão é o setor em que ele trabalha.
        /// </remarks>
        private void CarregarSetores(ConfiguraçãoUsuário<string> configuração)
        {
            string strConfig;
            string[] nomes;
            List<Setor> setores;

            strConfig = configuração.Valor;
            nomes = strConfig.Split(',', ';');
            setores = new List<Setor>(nomes.Length);

            foreach (string nome in nomes)
            {
                Setor setor;

                setor = Setor.ObterSetor(nome.Trim());

                if (setor != null)
                    setores.Add(setor);
            }

            this.setores = setores.ToArray();
        }

        #endregion

        /// <summary>
        /// Verifica os funcionários que sairam ou entraram na empresa.
        /// </summary>
        protected override void TemporizadorDisparou(object obj)
        {
            try
            {
                Funcionário funcionárioAtual = Funcionário.FuncionárioAtual;

                if (funcionárioAtual.Situação != EstadoFuncionário.Atendendo)
                {
                    Visita[] visitas;

                    visitas = Visita.ObterVisitas(últimaVerificação);

                    foreach (Visita visita in visitas)
                    {
                        if (ValidarVisitante(visita))
                            NotificaçãoEntradaSaída.Mostrar(typeof(NotificaçãoEntradaSaída), visita);

                        if (visita.Saída.HasValue && visita.Saída.Value > últimaVerificação)
                            últimaVerificação = visita.Saída.Value;

                        else if (visita.Entrada > últimaVerificação)
                            últimaVerificação = visita.Entrada;
                    }
                }
            }
            catch (Exception e)
            {
                últimaVerificação = DadosGlobais.Instância.HoraDataAtual;
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
        }

        /// <summary>
        /// Verifica se um visitante é de interesse do usuário.
        /// </summary>
        /// <returns>Se o visitante é de interesse do usuário.</returns>
        private bool ValidarVisitante(Visita visita)
        {
            bool válido = false;

            foreach (Entidades.Setor setor in setores)
                válido |= visita.Setor.Código == setor.Código;

            return válido;
        }
    }
}
