using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Acesso.Comum;
using Entidades;
using Entidades.Configura��o;
using Entidades.Pessoa;

namespace Apresenta��o.Usu�rio.Visitantes
{
    /// <summary>
    /// Controle sobre a��es tomadas por visitantes.
    /// </summary>
    internal class ControleVisitantes : Controle
    {
        /// <summary>
        /// Setores observados.
        /// </summary>
        private Entidades.Setor[] setores;

        private DateTime �ltimaVerifica��o;

        /// <summary>
        /// Constr�i o controle de visitantes.
        /// </summary>
        public ControleVisitantes()
        {
            Configura��oUsu�rio<string> configura��o;

            // Abrir chave de configura��o.
            if (Funcion�rio.Funcion�rioAtual.Setor.Nome.ToLower() == "atacado")
                configura��o = new Configura��oUsu�rio<string>(DadosGlobais.Inst�ncia.ChaveConfigura��oSetorVisitantes, "Atacado, Alto-Atacado");
            else
                configura��o = new Configura��oUsu�rio<string>(DadosGlobais.Inst�ncia.ChaveConfigura��oSetorVisitantes, Funcion�rio.Funcion�rioAtual.Setor.Nome);

            // Carregar configura��es.
            CarregarSetores(configura��o);

            �ltimaVerifica��o = DadosGlobais.Inst�ncia.HoraDataAtual;
        }

        #region Configura��o

        /// <summary>
        /// Carrega setores da configura��o do usu�rio.
        /// </summary>
        /// <param name="configura��o">Configura��o do usu�rio.</param>
        /// <remarks>
        /// Caso n�o exista configura��o deste usu�rio,
        /// o valor padr�o � o setor em que ele trabalha.
        /// </remarks>
        private void CarregarSetores(Configura��oUsu�rio<string> configura��o)
        {
            string strConfig;
            string[] nomes;
            List<Setor> setores;

            strConfig = configura��o.Valor;
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
        /// Verifica os funcion�rios que sairam ou entraram na empresa.
        /// </summary>
        protected override void TemporizadorDisparou(object obj)
        {
            try
            {
                Funcion�rio funcion�rioAtual = Funcion�rio.Funcion�rioAtual;

                if (funcion�rioAtual.Situa��o != EstadoFuncion�rio.Atendendo)
                {
                    Visita[] visitas;

                    visitas = Visita.ObterVisitas(�ltimaVerifica��o);

                    foreach (Visita visita in visitas)
                    {
                        if (ValidarVisitante(visita))
                            Notifica��oEntradaSa�da.Mostrar(typeof(Notifica��oEntradaSa�da), visita);

                        if (visita.Sa�da.HasValue && visita.Sa�da.Value > �ltimaVerifica��o)
                            �ltimaVerifica��o = visita.Sa�da.Value;

                        else if (visita.Entrada > �ltimaVerifica��o)
                            �ltimaVerifica��o = visita.Entrada;
                    }
                }
            }
            catch (Exception e)
            {
                �ltimaVerifica��o = DadosGlobais.Inst�ncia.HoraDataAtual;
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
            }
        }

        /// <summary>
        /// Verifica se um visitante � de interesse do usu�rio.
        /// </summary>
        /// <returns>Se o visitante � de interesse do usu�rio.</returns>
        private bool ValidarVisitante(Visita visita)
        {
            bool v�lido = false;

            foreach (Entidades.Setor setor in setores)
                v�lido |= visita.Setor.C�digo == setor.C�digo;

            return v�lido;
        }
    }
}
