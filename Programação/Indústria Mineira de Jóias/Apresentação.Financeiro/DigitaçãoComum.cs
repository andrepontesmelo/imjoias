using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Entidades;
using Entidades.Relacionamento;
using System.Collections;
using Apresenta��o.�til;
using Apresenta��o.Mercadoria.Bandeja;
using Apresenta��o.Formul�rios;
using Entidades.Pessoa;

namespace Apresenta��o.Financeiro
{
    /// <summary>
    /// Controle gr�fico para digita��o de mercadorias que
    /// � utilizado tanto para registrar venda, devolu��o e retorno.
    /// </summary>
    public partial class Digita��oComum : UserControl
    {
        /// <summary>
        /// Pode ser itens de sa�da, itens de retorno, itens de venda ou itens de devolu��o
        /// </summary>
        private Entidades.Relacionamento.Hist�ricoRelacionamento cole��o;

        private VerificadorMercadoria verificador;

        public VerificadorMercadoria Verificador
        {
            set { verificador = value; }
        }


        private BaseEditarRelacionamento baseInferior;

        /// <summary>
        /// Venda, retorno ou sa�da
        /// </summary>
        protected Entidades.Relacionamento.Relacionamento entidade;

        public enum TipoExibi��o { TipoAgrupado, TipoHist�rico }
        private TipoExibi��o tipoExibi��oAtual;

        public delegate void AdicionouDelegate(Digita��oComum sender, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade);
        public event AdicionouDelegate AoAdicionar;

        public delegate void TabelAlteradaCallback(Digita��oComum sender, Tabela tabela);
        public event TabelAlteradaCallback AoAlterarTabela;

        public TipoExibi��o TipoExibi��oAtual
        {
            get { return tipoExibi��oAtual; }
            set 
            { 
                tipoExibi��oAtual = value; 

                quadroAgrupado.Visible = (tipoExibi��oAtual == TipoExibi��o.TipoAgrupado);
                quadroHist�rico.Visible = (tipoExibi��oAtual == TipoExibi��o.TipoHist�rico);
            }
        }

        public Tabela Tabela
        {
            get { return bandejaAgrupada.Tabela; }
        }

        [DefaultValue(true)]
        public bool PermitirSele��oTabela
        {
            get { return bandejaAgrupada.PermitirSele��oTabela; }
            set { bandejaAgrupada.PermitirSele��oTabela = bandejaHist�rico.PermitirSele��oTabela = value; }
        }

        /// <summary>
        /// Mostra pre�o nas bandejas
        /// </summary>
        public bool MostrarPre�o
        {
            get { return bandejaAgrupada.MostrarPre�o; }
            set { bandejaAgrupada.MostrarPre�o = value; }
        }

        [ReadOnly(true), Browsable(false)]
        public Entidades.Cota��o Cota��o
        {
            get { return bandejaAgrupada.Cota��o; }
            set { bandejaAgrupada.Cota��o = value; bandejaHist�rico.Cota��o = value;  }
        }

        //public enum TipoDigita��o
        //{
        //    N�oDefinido,
        //    Venda,
        //    Devolu��o
        //}

        ///// <summary>
        ///// Tipo de digita��o.
        ///// </summary>
        //private TipoDigita��o tipo = TipoDigita��o.N�oDefinido;

        /// <summary>
        /// Hash que mapeia saquinho ao item relacionado.
        /// </summary>
        private Dictionary<Saquinho, Hist�ricoRelacionamentoItem> hashSaquinhoItemRelacionado;

        /// <summary>
        /// Constr�i o controle de digita��o comum.
        /// </summary>
        public Digita��oComum()
        {
            InitializeComponent();

            hashSaquinhoItemRelacionado = new Dictionary<Saquinho, Hist�ricoRelacionamentoItem>();
        }

        /// <summary>
        /// Bandeja que cont�m os itens digitados.
        /// </summary>
        [Browsable(false)]
        public Apresenta��o.Mercadoria.Bandeja.Bandeja Bandeja
        {
            get { return bandejaAgrupada; }
        }

        /// <summary>
        /// Caso a entidade esteja travada,
        /// os controle s�o travados ou liberados.
        /// </summary>
        public void AtualizarTravamento(bool entidadeTravada)
        {
            quadroMercadoria.Enabled = !entidadeTravada;
            bandejaAgrupada.MostrarExcluir = !entidadeTravada;
            bandejaAgrupada.PermitirExclus�o = !entidadeTravada;

            
            // N�o pode disparar o evento 'EntidadeTravada', pois faz ciclo.
        }

        /// <summary>
        /// Carrega entidade, preenchendo o controle.
        /// Solicitado no Set da propriedade Cole��o
        /// </summary>
        private void RecuperarEntidade(Entidades.Relacionamento.Hist�ricoRelacionamento cole��o)
        {
            bandejaAgrupada.LimparLista();
            hashSaquinhoItemRelacionado.Clear();
            ArrayList lista = new ArrayList();

            foreach (Entidades.Relacionamento.Hist�ricoRelacionamentoItem item in cole��o)
            {
                Saquinho saquinho = new Saquinho(item.Mercadoria, item.Quantidade);

                lista.Add(saquinho);
                hashSaquinhoItemRelacionado.Add(saquinho, item);
                
            }

            bandejaAgrupada.AdicionarV�rios(lista);
        }

        /// <summary>
        /// Ocorre quando usu�rio adiciona mercadoria.
        /// </summary>
        private void quadroMercadoria_EventoAdicionou(Entidades.Mercadoria.Mercadoria mercadoria, double quantidade)
        {
            double �ndice;

            try
            {
                if (baseInferior.ConferirTravamento(true))
                {
                    MessageBox.Show(ParentForm,
                        "ATEN��O\n\nEste documento foi travado e n�o pode ser alterado.",
                        "Documento travado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(ParentForm,
                    "N�o foi poss�vel verificar se o documento estava travado, por isso a opera��o foi cancelada.",
                    "Documento travado",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                return;
            }

            try
            {
                Escolher�ndice(mercadoria);
                �ndice = mercadoria.�ndice;
            }
            catch
            {
                MessageBox.Show(
                    Parent,
                    "A opera��o foi cancelada pelo sistema, pois n�o foi poss�vel obter o �ndice da mercadoria.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Altera o valor do indice dentro da mercadoria:
            Hist�ricoRelacionamentoItem itemAdicionado;

            try
            {
                itemAdicionado = cole��o.Relacionar(mercadoria, quantidade, �ndice);
            }
            catch (Acesso.Comum.Exce��es.Opera��oCancelada)
            {
                MessageBox.Show(
                    ParentForm,
                    "A opera��o foi cancelada pelo sistema. Nenhuma altera��o foi realizada no banco de dados.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show( ParentForm,
                    "Ocorreu um erro enquanto a mercadoria era registrada no banco de dados.\n\n" + e.Message,
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                return;
            }

            try
            {
                bandejaHist�rico.Adicionar(new SaquinhoHist�ricoRelacionado(itemAdicionado));
                bandejaAgrupada.Adicionar(new Saquinho(mercadoria, quantidade));
            }
            catch (Exception e)
            {
                MessageBox.Show(ParentForm,
                    "Ocorreu um erro enquanto tentava-se atualizar a interface gr�fica, por�m a mercadoria foi registrada no banco de dados.\n\nPor favor, abra de novo o documento com o qual voc� est� trabalhando.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                bandejaAgrupada.Visible = false;
                bandejaHist�rico.Visible = false;
                quadroMercadoria.Visible = false;
                quadroHist�rico.Visible = false;
                quadroAgrupado.Visible = false;
                quadroFoto.Visible = false;
            }

            try
            {
                if (AoAdicionar != null)
                    AoAdicionar(this, mercadoria, quantidade);
            }
            catch (Exception e)
            {
                MessageBox.Show(ParentForm,
                    "Ocorreu um erro disparando evento de adi��o de mercadoria. De qualquer maneira, a mercadoria foi registrada no banco de dados.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
            }
        }

        protected virtual void Escolher�ndice(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            List<double> lista�ndices = verificador.ObterLista�ndices(mercadoria);

            if (!lista�ndices.Contains(Math.Round(mercadoria.�ndice,2)))
                lista�ndices.Add(Math.Round(mercadoria.�ndice,2));

            // Neste ponto a lista�ndices tem um ou mais elementos.

            if (lista�ndices.Count > 1)
            {
                JanelaEscolha�ndice j = new JanelaEscolha�ndice();
                j.Carregar�ndices(lista�ndices);
                if (j.ShowDialog() == DialogResult.OK)
                {
                    // Altera o indice na mercadoria
                    mercadoria.�ndice = j.ObterValorEscolhido();
                }
                else
                {
                    MessageBox.Show("Ser� utilizado o indice vigente (" + mercadoria.�ndice.ToString() + ")", "Escolha do �ndice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                mercadoria.�ndice = j.ObterValorEscolhido();
            }
            else
                mercadoria.�ndice = lista�ndices[0];
        }

        private void quadroMercadoria_EventoAlterou(ISaquinho saquinhoOriginal, double novaQtd, double novoPeso)
        {
            if (baseInferior.ConferirTravamento(true))
            {
                MessageBox.Show(ParentForm,
                    "ATEN��O\n\nEste documento foi travado e n�o pode ser alterado.",
                    "Documento travado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            bandejaAgrupada.Remover(saquinhoOriginal);

            ISaquinho novoSaquinho = saquinhoOriginal.Clone(novaQtd);
            
            if (novoSaquinho.Mercadoria.DePeso)
                novoSaquinho.Mercadoria.Peso = novoPeso;

            bandejaAgrupada.Adicionar(novoSaquinho);

            DateTime agora = Entidades.Configura��o.DadosGlobais.Inst�ncia.HoraDataAtual;
            
            // Retira
            //bandejaHist�rico.Adicionar(new SaquinhoHist�ricoRelacionado(cole��o.Relacionar(saquinhoOriginal.Mercadoria, saquinhoOriginal.Quantidade * -1)));
            //j� � removido

            // Relaciona
            try
            {
                bandejaHist�rico.Adicionar(new SaquinhoHist�ricoRelacionado(cole��o.Relacionar(novoSaquinho.Mercadoria, novaQtd, novoSaquinho.Mercadoria.�ndice)));
            }
            catch (Acesso.Comum.Exce��es.Opera��oCancelada)
            {
                MessageBox.Show(
                    ParentForm,
                    "A opera��o foi cancelada pelo sistema. Nenhuma altera��o foi realizada no banco de dados.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        internal void Abrir(Hist�ricoRelacionamento cole��o, Entidades.Relacionamento.Relacionamento entidade, BaseEditarRelacionamento baseInferior)
        {
            this.baseInferior = baseInferior;
            this.cole��o = cole��o;
            this.entidade = entidade;

            /* N�o permitir edi��o de tabela em documentos cujo
             * acerto possui tabela definida.
             */
            if (entidade.AcertoConsignado != null && entidade.AcertoConsignado.TabelaPre�o != null)
            {
                bandejaAgrupada.PermitirSele��oTabela = false;
                bandejaHist�rico.PermitirSele��oTabela = false;
            }

            if (entidade.TabelaPre�o == null)
            {
                if (entidade.AcertoConsignado != null && entidade.AcertoConsignado.TabelaPre�o != null && !(entidade is Entidades.Relacionamento.Venda.Venda))
                    entidade.TabelaPre�o = entidade.AcertoConsignado.TabelaPre�o;
                else
                    QuestionarTabelaPre�o(entidade);
            }

            // Deve-se garantir que existe uma tabelad e pre�o definida.
            while (entidade.TabelaPre�o == null)
            {
                if (MessageBox.Show(
                    ParentForm,
                    "Por favor, escolha uma tabela de pre�os para iniciar a sua digita��o de mercadorias.",
                    "Digita��o de mercadorias",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    throw new Exce��oTabelaVazia();
                }
                else
                    QuestionarTabelaPre�o(entidade);
            }

            quadroMercadoria.Tabela = entidade.TabelaPre�o;
            bandejaAgrupada.Tabela = entidade.TabelaPre�o;
            bandejaHist�rico.Tabela = entidade.TabelaPre�o;
            bandejaAgrupada.Abrir(cole��o);
            bandejaHist�rico.Abrir(cole��o);

            entidade.AoAlterarTabela += new Acesso.Comum.DbManipula��o.DbManipula��oHandler(AoAlterarTabelaEntidade);

            if (cole��o.Count > 0)
                PermitirSele��oTabela = false;
            else if (entidade is Entidades.Relacionamento.Venda.Venda && Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Entidades.Privil�gio.Permiss�o.PersonalizarVenda))
            {
                bandejaAgrupada.PermitirSele��oTabela = true;
                bandejaHist�rico.PermitirSele��oTabela = true;
            }
        }

        /// <summary>
        /// Questiona qual tabela de pre�o ser� utilizada.
        /// </summary>
        private void QuestionarTabelaPre�o(Entidades.Relacionamento.Relacionamento entidade)
        {
            Entidades.Pessoa.Pessoa pessoa;
            Entidades.Relacionamento.Venda.Venda venda = entidade as Entidades.Relacionamento.Venda.Venda;

            if (venda != null && (entidade.Pessoa == null || Representante.�Representante(venda.Vendedor)))
                pessoa = venda.Vendedor;
            else
                pessoa = entidade.Pessoa;

            using (EscolherTabela dlg = new EscolherTabela(pessoa))
            {
                AguardeDB.Suspens�o(true);

                dlg.ShowDialog(ParentForm);

                AguardeDB.Suspens�o(false);

                if (dlg.DialogResult == DialogResult.Cancel)
                    throw new OperationCanceledException();

                entidade.TabelaPre�o = dlg.Tabela;
            }
        }

        void AoAlterarTabelaEntidade(Acesso.Comum.DbManipula��o entidade)
        {
            if (this.entidade == entidade)
            {
                quadroMercadoria.Tabela = this.entidade.TabelaPre�o;
                bandejaAgrupada.Tabela = this.entidade.TabelaPre�o;
                bandejaHist�rico.Tabela = this.entidade.TabelaPre�o;
            }
            else
                System.Diagnostics.Debug.Fail("Entidade diferente!");
        }

        private void bandejaAgrupada_SaquinhoExclu�do(Bandeja bandeja, ISaquinho saquinho)
        {
            if (!baseInferior.ConferirTravamento(true))
            {
                try
                {
                    Hist�ricoRelacionamentoItem item = cole��o.Relacionar(saquinho.Mercadoria, saquinho.Quantidade * -1, saquinho.Mercadoria.�ndice);
                    bandejaHist�rico.Adicionar(new SaquinhoHist�ricoRelacionado(item));
                }
                catch (Acesso.Comum.Exce��es.Opera��oCancelada)
                {
                    MessageBox.Show(
                        ParentForm,
                        "A opera��o foi cancelada pelo sistema. Nenhuma altera��o foi realizada no banco de dados.",
                        "Relacionamento de mercadoria",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void bandejaAgrupada_AntesExclus�o(ref bool cancelado)
        {
            bool travado = baseInferior.ConferirTravamento(false);

            cancelado = travado;
        }

        private void bandejaAgrupada_Sele��oMudou(Bandeja bandeja, ISaquinho saquinho)
        {
            if (saquinho != null)
            {
                quadroFoto.MostrarFoto(saquinho.Mercadoria);

                if (tipoExibi��oAtual == TipoExibi��o.TipoAgrupado)
                    quadroMercadoria.AlternarParaAltera��o(saquinho);
            }
            else
            {
                // Des-selecionou
                quadroMercadoria.AlternarParaAdicionar();
            }

        }

        private void bandejaHist�rico_Sele��oMudou(Bandeja bandeja, ISaquinho saquinho)
        {
            // Assim que usu�rio clica no item do hist�rico, a bandeja agrupada j� encontra o item para facilitar modifica��o
            if (saquinho != null)
            {
                if (saquinho.Mercadoria.Peso != saquinho.Peso)
                    throw new Exception("Esperava-se que o peso da mercadoria fosse o peso do saquinho.");

                if (bandejaAgrupada.Cont�m(saquinho.Mercadoria))
                    bandejaAgrupada.Selecionar(saquinho.Mercadoria);
            }
        }

        private void bandejaAgrupada_TabelaAlterada(Bandeja bandeja, Tabela tabela)
        {
            bandejaHist�rico.Tabela = tabela;

            if (AoAlterarTabela != null)
                AoAlterarTabela(this, tabela);
        }

        private void bandejaHist�rico_TabelaAlterada(Bandeja bandeja, Tabela tabela)
        {
            try
            {
                if (entidade.TabelaPre�o != tabela)
                    entidade.TabelaPre�o = tabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    ParentForm,
                    "N�o foi poss�vel alterar a tabela.\n\n" + e.Message,
                    "Altera��o de tabela",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                bandeja.Tabela = entidade.TabelaPre�o;
                return;
            }

            bandejaAgrupada.Tabela = tabela;
            quadroMercadoria.Tabela = tabela;
        
            if (AoAlterarTabela != null)
                AoAlterarTabela(this, tabela);
        }
    }
}