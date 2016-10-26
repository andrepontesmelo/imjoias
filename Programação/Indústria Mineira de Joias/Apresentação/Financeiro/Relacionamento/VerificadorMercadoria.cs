using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Entidades.Relacionamento;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Threading;
using Entidades.Acerto;
using Negócio;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// Verifica se a mercadoria entrada pelo usuário foi realmente
    /// levada pelo representante ou pessoa do consignado. Caso
    /// a mercadoria entrada não conste na relação de saída,
    /// o usuário é alertado do erro.
    /// </summary>
    [ProvideProperty("VerificarMercadoria", typeof(DigitaçãoComum))]
    public partial class VerificadorMercadoria : Component, IExtenderProvider
    {
        private Dictionary<string, ÍndicesSaídaMercadoria> mercadorias;

        /// <summary>
        /// Controle de digitação dos dados da mercadoria.
        /// </summary>
        private List<DigitaçãoComum> controles = new List<DigitaçãoComum>();

        /// <summary>
        /// Define se o verificador irá atuar ou não.
        /// </summary>
        private bool ligado = true;

        /// <summary>
        /// Método que trata adição de mercadoria.
        /// </summary>
        private DigitaçãoComum.AdicionouDelegate aoAdicionar;

        #region Construtora

        /// <summary>
        /// Constrói o verificador de mercadorias.
        /// </summary>
        public VerificadorMercadoria()
        {
            InitializeComponent();

            aoAdicionar = new DigitaçãoComum.AdicionouDelegate(AoAdicionarMercadoria);
        }

        /// <summary>
        /// Constrói o verificador de mercadorias.
        /// </summary>
        public VerificadorMercadoria(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            aoAdicionar = new DigitaçãoComum.AdicionouDelegate(AoAdicionarMercadoria);
        }

        #endregion

        #region Propriedades

        public bool Enabled
        {
            get { return ligado; }
            set
            {
                if (ligado != value)
                {
                    ligado = value;

                    if (ligado)
                        foreach (DigitaçãoComum controle in controles)
                            MarcarMercadorias(controle);
                    else
                        foreach (DigitaçãoComum controle in controles)
                            DesmarcarMercadorias(controle);
                }
            }
        }

        #endregion

        /// <summary>
        /// Verifica se uma mercadoria consta na lista de saídas.
        /// </summary>
        /// <param name="mercadoria">Mercadoria a ser verificada.</param>
        /// <returns>Verdadeiro se a mercadoria consta na lista de saídas.</returns>
        public bool Verificar(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            if (mercadorias == null || !ligado)
                return true;
            else
                lock (mercadorias)
                    return mercadorias.ContainsKey(ÍndicesSaídaMercadoria.GerarChave(mercadoria));
        }


        /// <summary>
        /// Ocorre ao adicionar a mercadoria.
        /// </summary>
        /// <param name="mercadoria">Mercadoria adicionada.</param>
        /// <param name="quantidade">Quantidade de mercadoria.</param>
        private void AoAdicionarMercadoria(DigitaçãoComum controle, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade)
        {
            if (ligado && !Verificar(mercadoria))
            {
                MarcarMercadoria(controle, mercadoria);

                Beepador.Alerta();
                
                //using (BalãoMercadoriaInconsistente dlg = new BalãoMercadoriaInconsistente(mercadoria))
                //{
                //    Apresentação.Útil.Beepador.Aviso();
                //    dlg.ShowDialog(controle);
                //}
            }
        }

        private delegate void MarcarMercadoriaCallback(DigitaçãoComum controle, Entidades.Mercadoria.Mercadoria mercadoria);

        /// <summary>
        /// Marca uma mercadoria de um controle como inválida.
        /// </summary>
        private void MarcarMercadoria(DigitaçãoComum controle, Entidades.Mercadoria.Mercadoria mercadoria)
        {
            ListViewItem item = controle.Bandeja.ObterLinha(mercadoria);

            if (item.ListView.InvokeRequired)
            {
                MarcarMercadoriaCallback método = new MarcarMercadoriaCallback(MarcarMercadoria);
                item.ListView.BeginInvoke(método, controle, mercadoria);
            }
            else
            {
                item.BackColor = Color.Red;
                item.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Marca todas as mercadorias inválidas de um controle.
        /// </summary>
        /// <param name="controle">Controle cuja bandeja será validada.</param>
        private void MarcarMercadorias(DigitaçãoComum controle)
        {
            if (mercadorias != null)
                foreach (Entidades.ISaquinho saquinho in controle.Bandeja)
                    if (!Verificar(saquinho.Mercadoria))
                        MarcarMercadoria(controle, saquinho.Mercadoria);
        }

        private delegate void DesmarcarMercadoriasCallback(DigitaçãoComum controle);

        /// <summary>
        /// Desmarca todas as mercadorias de um controle de digitação.
        /// </summary>
        /// <param name="controle">
        /// Controle digitação cuja bandeja será totalmente desmarcada.
        /// </param>
        private void DesmarcarMercadorias(DigitaçãoComum controle)
        {
            if (controle.Bandeja.ListView.InvokeRequired)
            {
                DesmarcarMercadoriasCallback método = new DesmarcarMercadoriasCallback(DesmarcarMercadorias);
                controle.Bandeja.ListView.BeginInvoke(método, controle);
            }
            else
            {
                Color foreColor = controle.Bandeja.ListView.ForeColor;
                Color backColor = controle.Bandeja.ListView.BackColor;

                foreach (ListViewItem item in controle.Bandeja.ListView.Items)
                {
                    item.ForeColor = foreColor;
                    item.BackColor = backColor;
                    //item.SubItems["peso"].ForeColor = foreColor;
                    //item.SubItems["peso"].BackColor = backColor;
                }
            }
        }

        /// <summary>
        /// Restringe a verificação às mercadorias relacionadas
        /// como saída para um acerto.
        /// </summary>
        /// <param name="relacionamento">Relacionamento cujo acerto será considerado.</param>
        /// <remarks>
        /// Processo realizado em segundo plano.
        /// </remarks>
        public void Restringir(RelacionamentoAcerto relacionamento)
        {
            Restringir(relacionamento.AcertoConsignado);
        }

        /// <summary>
        /// Restringe a verificação às mercadorias relacionadas
        /// como saída para um acerto.
        /// </summary>
        /// <param name="acerto">Acerto a ser considerado.</param>
        /// <remarks>
        /// Processo realizado em segundo plano.
        /// </remarks>
        public void Restringir(AcertoConsignado acerto)
        {
            mercadorias = null;

            foreach (DigitaçãoComum controle in controles)
                DesmarcarMercadorias(controle);

            if (acerto != null)
                mercadorias = ÍndicesSaídaMercadoria.ObterHashÍndicesSaídas(acerto);


            if (ligado)
            {
                    foreach (DigitaçãoComum controle in controles)
                        MarcarMercadorias(controle);
            }
        }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is DigitaçãoComum;
        }

        /// <summary>
        /// Método utilizado pelo designer para verificar se
        /// um controle do tipo DigitaçãoComum está sendo verificado
        /// por este controle.
        /// </summary>
        [Description("Determina se a bandeja deve ter cada mercadoria validada."),
         DefaultValue(false)]
        public bool GetVerificarMercadoria(DigitaçãoComum controle)
        {
            return controles.Contains(controle);
        }

        /// <summary>
        /// Método utilizado pelo designer para definir se um
        /// controle do tipo DigitaçãoComum deve ser verificado por
        /// este controle.
        /// </summary>
        public void SetVerificarMercadoria(DigitaçãoComum controle, bool valor)
        {
            bool contém = controles.Contains(controle);

            if (!valor && contém)
            {
                controles.Remove(controle);
                controle.AoAdicionar -= aoAdicionar;
                DesmarcarMercadorias(controle);
            }
            else if (valor && !contém)
            {
                controles.Add(controle);
                controle.AoAdicionar += aoAdicionar;

                if (ligado)
                    MarcarMercadorias(controle);
            }
        }

        #endregion

        /// <summary>
        /// Retorna todos os índices utilizados nas saidas para uma mercadoria e para tal pessoa.
        /// Retorna lista vazia se a referencia-peso está em nenhuma saída.
        /// </summary>
        /// <param name="mercadoria"></param>
        /// <returns></returns>
        public List<double> ObterListaÍndices(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            ÍndicesSaídaMercadoria info;

            if (mercadorias != null)
                lock (mercadorias)
                    if (mercadorias.TryGetValue(ÍndicesSaídaMercadoria.GerarChave(mercadoria), out info))
                        return info.Índices;
                    else
                        return new List<double>();
            else
                return new List<double>();
        }

        ///// <summary>
        ///// Recupera mercadorias em segundo plano, construindo a árvore.
        ///// </summary>
        //private void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    AcertoConsignado acerto = e.Argument as AcertoConsignado;

        //    if (acerto != null)
        //        mercadorias = ÍndicesSaídaMercadoria.ObterHashÍndicesSaídas(acerto);
        //    else
        //        mercadorias = null;
        //}

        ///// <summary>
        ///// Ocorre ao terminar de construir a árvore em segundo plano.
        ///// </summary>
        //private void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (ligado)
        //    {
        //        foreach (DigitaçãoComum controle in controles)
        //            DesmarcarMercadorias(controle);

        //        foreach (DigitaçãoComum controle in controles)
        //            MarcarMercadorias(controle);
        //    }
        //}
    }
}
