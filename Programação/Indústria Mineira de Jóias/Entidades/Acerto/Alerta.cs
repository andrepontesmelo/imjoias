using System;
using System.Collections.Generic;
using System.Text;
using Acesso.Comum;
using Entidades.Relacionamento.Saída;
using Entidades.Relacionamento.Venda;
using Entidades.Relacionamento.Retorno;

namespace Entidades.Acerto
{
    /// <summary>
    /// Apresenta alerta sobre o acerto realizado que
    /// auxiliam na detecção de possíveis problemas com
    /// o acerto trabalhado.
    /// </summary>
    public class Alerta : DbManipulaçãoSimples
    {
        /// <summary>
        /// Acerto vinculado.
        /// </summary>
        private ControleAcertoMercadorias acerto;

        /// <summary>
        /// Descrição do alerta.
        /// </summary>
        private string descrição;

        /// <summary>
        /// Enumeração que determina o nível de prioridade
        /// de um alerta.
        /// </summary>
        public enum NívelPrioridade
        {
            Baixa, Normal, Alta
        }

        /// <summary>
        /// Prioridade do alerta.
        /// </summary>
        private NívelPrioridade prioridade;

        /// <summary>
        /// Constrói o objeto de alertas, verificando
        /// no banco de dados questões que podem comprometer
        /// o acerto.
        /// </summary>
        /// <param name="acerto">Acerto a ser verificado.</param>
        /// <param name="descrição">Descrição do alerta.</param>
        /// <param name="prioridade">Prioridade do alerta.</param>
        private Alerta(ControleAcertoMercadorias acerto, string descrição,
            NívelPrioridade prioridade)
        {
            this.acerto = acerto;
            this.descrição = descrição;
            this.prioridade = prioridade;
        }

        #region Propriedades

        /// <summary>
        /// Acerto relacionado à este alerta.
        /// </summary>
        public ControleAcertoMercadorias Acerto { get { return acerto; } }

        /// <summary>
        /// Descrição do alerta.
        /// </summary>
        public string Descrição { get { return descrição; } }

        /// <summary>
        /// Nível de prioridade do alerta.
        /// </summary>
        public NívelPrioridade Prioridade { get { return prioridade; } }

        #endregion

        /// <summary>
        /// Verifica possíveis questões que podem dificultar
        /// o acerto correto.
        /// </summary>
        /// <param name="acerto">Acerto a ser verificado.</param>
        /// <returns>Lista de alertas.</returns>
        public static IList<Alerta> VerificarAcerto(ControleAcertoMercadorias acerto)
        {
            List<Alerta> alertas;
            DateTime dSaídaÚltAcerto, dSaídaPri, dVendaPri, dVendaÚltAcerto;
            DateTime dRetornoÚltAcerto, dRetornoPri;

            if (acerto == null)
                throw new NullReferenceException("Acerto é nulo!");

            dSaídaPri         = Saída.ObterDataPrimeiraSaídaNãoAcertada(acerto.Pessoa);
            dSaídaÚltAcerto   = Saída.ObterDataÚltimaSaídaAcertada(acerto.Pessoa);
            dVendaPri         = Venda.ObterDataPrimeiraVendaNãoAcertada(acerto.Pessoa);
            dVendaÚltAcerto   = Venda.ObterDataÚltimaVendaAcertada(acerto.Pessoa);
            dRetornoPri       = Retorno.ObterDataPrimeiroRetornoNãoAcertado(acerto.Pessoa);
            dRetornoÚltAcerto = Retorno.ObterDataÚltimoRetornoAcertado(acerto.Pessoa);

            alertas = new List<Alerta>(5);

            if (dSaídaÚltAcerto > dSaídaPri)
                alertas.Add(new Alerta(
                    acerto,
                    "Existe(m) saída(s) de mercadorias que foram acertadas posteriormente a saída(s) ainda não acertada(s)."
                    + " A última saída acertada é datada em " + dSaídaÚltAcerto.ToShortDateString()
                    + " enquanto a primeira saída não acertada é datada em " + dSaídaPri.ToShortDateString(),
                    NívelPrioridade.Alta));

            if (dVendaÚltAcerto > dVendaPri)
                alertas.Add(new Alerta(
                    acerto,
                    "Existe(m) venda(s) que foram acertadas posteriormente a venda(s) que ainda não fora(m) acertada(s)."
                    + " A última venda acertada é datada em " + dVendaÚltAcerto.ToShortDateString()
                    + " enquanto a primeira venda não acertada é datada em " + dVendaPri.ToShortDateString(),
                    NívelPrioridade.Alta));

            if (dRetornoÚltAcerto > dRetornoPri)
                alertas.Add(new Alerta(
                    acerto,
                    "Existe(m) retorno(s) de mercadorias que foram acertados posteriormente a retorno(s) ainda não acertado(s)."
                    + " O último retorno acertado é datado em " + dRetornoÚltAcerto.ToShortDateString()
                    + " enquanto o primeiro retorno não acertado é datado em " + dRetornoPri.ToShortDateString(),
                    NívelPrioridade.Alta));

            if (dVendaÚltAcerto > dSaídaPri)
                alertas.Add(new Alerta(
                    acerto,
                    "Existe(m) venda(s) que foram acertadas posteriormente ao registro de uma saída não acertada."
                    + " A última venda acertada é datada em " + dVendaÚltAcerto.ToShortDateString()
                    + " enquanto a primeira saída não acertada é datada em " + dSaídaPri.ToShortDateString(),
                    NívelPrioridade.Normal));

            if (dRetornoÚltAcerto > dSaídaPri)
                alertas.Add(new Alerta(
                    acerto,
                    "Existe(m) retorno(s) que foram acertados posteriormente ao registro de uma saída não acertada."
                    + " O último retorno acertado é datado em " + dVendaÚltAcerto.ToShortDateString()
                    + " enquanto a primeira saída não acertada é datada em " + dSaídaPri.ToShortDateString(),
                    NívelPrioridade.Normal));

            return alertas;
        }
    }
}
