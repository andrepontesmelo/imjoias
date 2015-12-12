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
using Apresentação.Mercadoria.Bandeja;
using Apresentação.Formulários;
using Entidades.Pessoa;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// Controle gráfico para digitação de mercadorias que
    /// é utilizado tanto para registrar venda, devolução e retorno.
    /// </summary>
    public partial class DigitaçãoComum : UserControl
    {
        /// <summary>
        /// Pode ser itens de saída, itens de retorno, itens de venda ou itens de devolução
        /// </summary>
        private Entidades.Relacionamento.HistóricoRelacionamento coleção;

        private VerificadorMercadoria verificador;

        public VerificadorMercadoria Verificador
        {
            set { verificador = value; }
        }


        private BaseEditarRelacionamento baseInferior;

        /// <summary>
        /// Venda, retorno ou saída
        /// </summary>
        protected Entidades.Relacionamento.Relacionamento entidade;
        
        public enum TipoExibição { TipoAgrupado, TipoHistórico }
        private TipoExibição tipoExibiçãoAtual;

        public delegate void AdicionouDelegate(DigitaçãoComum sender, Entidades.Mercadoria.Mercadoria mercadoria, double quantidade);
        public event AdicionouDelegate AoAdicionar;

        public delegate void TabelAlteradaCallback(DigitaçãoComum sender, Tabela tabela);
        public event TabelAlteradaCallback AoAlterarTabela;

        public TipoExibição TipoExibiçãoAtual
        {
            get { return tipoExibiçãoAtual; }
            set 
            { 
                tipoExibiçãoAtual = value; 

                quadroAgrupado.Visible = (tipoExibiçãoAtual == TipoExibição.TipoAgrupado);
                quadroHistórico.Visible = (tipoExibiçãoAtual == TipoExibição.TipoHistórico);
            }
        }

        public Tabela Tabela
        {
            get { return bandejaAgrupada.Tabela; }
        }

        [DefaultValue(true)]
        public bool PermitirSeleçãoTabela
        {
            get { return bandejaAgrupada.PermitirSeleçãoTabela; }
            set { bandejaAgrupada.PermitirSeleçãoTabela = bandejaHistórico.PermitirSeleçãoTabela = value; }
        }

        /// <summary>
        /// Mostra preço nas bandejas
        /// </summary>
        public bool MostrarPreço
        {
            get { return bandejaAgrupada.MostrarPreço; }
            set { bandejaAgrupada.MostrarPreço = value; }
        }

        [ReadOnly(true), Browsable(false)]
        public Entidades.Financeiro.Cotação Cotação
        {
            get { return bandejaAgrupada.Cotação; }
            set { bandejaAgrupada.Cotação = value; bandejaHistórico.Cotação = value;  }
        }

        //private bool PermitirÍndiceDiferenteDoVigente { get; set; }

        //public enum TipoDigitação
        //{
        //    NãoDefinido,
        //    Venda,
        //    Devolução
        //}

        ///// <summary>
        ///// Tipo de digitação.
        ///// </summary>
        //private TipoDigitação tipo = TipoDigitação.NãoDefinido;

        /// <summary>
        /// Hash que mapeia saquinho ao item relacionado.
        /// </summary>
        private Dictionary<Saquinho, HistóricoRelacionamentoItem> hashSaquinhoItemRelacionado;

        /// <summary>
        /// Constrói o controle de digitação comum.
        /// </summary>
        public DigitaçãoComum()
        {
            InitializeComponent();

            hashSaquinhoItemRelacionado = new Dictionary<Saquinho, HistóricoRelacionamentoItem>();
        }

        /// <summary>
        /// Bandeja que contém os itens digitados.
        /// </summary>
        [Browsable(false)]
        public Apresentação.Mercadoria.Bandeja.Bandeja Bandeja
        {
            get { return bandejaAgrupada; }
        }

        /// <summary>
        /// Caso a entidade esteja travada,
        /// os controle são travados ou liberados.
        /// </summary>
        public void AtualizarTravamento(bool entidadeTravada)
        {
            quadroMercadoria.Enabled = !entidadeTravada;
            bandejaAgrupada.MostrarExcluir = !entidadeTravada;
            bandejaAgrupada.PermitirExclusão = !entidadeTravada;

            
            // Não pode disparar o evento 'EntidadeTravada', pois faz ciclo.
        }

        /// <summary>
        /// Carrega entidade, preenchendo o controle.
        /// Solicitado no Set da propriedade Coleção
        /// </summary>
        private void RecuperarEntidade(Entidades.Relacionamento.HistóricoRelacionamento coleção)
        {
            bandejaAgrupada.LimparLista();
            hashSaquinhoItemRelacionado.Clear();
            ArrayList lista = new ArrayList();

            foreach (Entidades.Relacionamento.HistóricoRelacionamentoItem item in coleção)
            {
                Saquinho saquinho = new Saquinho(item.Mercadoria, item.Quantidade);

                lista.Add(saquinho);
                hashSaquinhoItemRelacionado.Add(saquinho, item);
                
            }

            bandejaAgrupada.AdicionarVários(lista);
        }

        private void Adicionar(Entidades.Mercadoria.Mercadoria mercadoria, double quantidade, ModoJanelaÍndice modoJanelaÍndice)
        {
            Adicionar(mercadoria, quantidade, modoJanelaÍndice, true);
        }

        private bool ConferirTravamento()
        {
            try
            {
                if (baseInferior.ConferirTravamento())
                {
                    MessageBox.Show(ParentForm,
                        "ATENÇÃO\n\nEste documento foi travado e não pode ser alterado.",
                        "Documento travado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(ParentForm,
                    "Não foi possível verificar se o documento estava travado, por isso a operação foi cancelada.",
                    "Documento travado",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                return true;
            }

            return false;
        }

        private void Adicionar(Entidades.Mercadoria.Mercadoria mercadoria, double quantidade, ModoJanelaÍndice modoJanelaÍndice, bool conferirTravamento)
        {
            double índice;

            if (conferirTravamento && ConferirTravamento())
                return;

            try
            {
                EscolherÍndice(mercadoria, modoJanelaÍndice);
                índice = mercadoria.ÍndiceArredondado;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    Parent,
                    "A operação foi cancelada pelo sistema, pois não foi possível obter o índice da mercadoria.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Altera o valor do indice dentro da mercadoria:
            HistóricoRelacionamentoItem itemAdicionado;

            //try
            {
                itemAdicionado = coleção.Relacionar(mercadoria, quantidade, índice);
            }
            //catch (Acesso.Comum.Exceções.OperaçãoCancelada)
            //{
            //    MessageBox.Show(
            //        ParentForm,
            //        "A operação foi cancelada pelo sistema. Nenhuma alteração foi realizada no banco de dados.",
            //        "Relacionamento de mercadoria",
            //        MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(ParentForm,
            //        "Ocorreu um erro enquanto a mercadoria era registrada no banco de dados.\n\n" + e.Message,
            //        "Relacionamento de mercadoria",
            //        MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            //    return;
            //}

            try
            {
                bandejaHistórico.Adicionar(new SaquinhoHistóricoRelacionado(itemAdicionado));
                bandejaAgrupada.Adicionar(new Saquinho(mercadoria, quantidade));
            }
            catch (Exception e)
            {
                MessageBox.Show(ParentForm,
                    "Ocorreu um erro enquanto tentava-se atualizar a interface gráfica, porém a mercadoria foi registrada no banco de dados.\n\nPor favor, abra de novo o documento com o qual você está trabalhando.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
                bandejaAgrupada.Visible = false;
                bandejaHistórico.Visible = false;
                quadroMercadoria.Visible = false;
                quadroHistórico.Visible = false;
                quadroAgrupado.Visible = false;
                quadroFoto.Visible = false;
            }
            
#if !DEBUG
            try
            {
#endif 
                if (AoAdicionar != null)
                    AoAdicionar(this, mercadoria, quantidade);
#if !DEBUG
            }
            catch (Exception e)
            {
                MessageBox.Show(ParentForm,
                    "Ocorreu um erro disparando evento de adição de mercadoria. De qualquer maneira, a mercadoria foi registrada no banco de dados.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
            }
#endif

        }

        /// <summary>
        /// Ocorre quando usuário adiciona mercadoria.
        /// </summary>
        private void quadroMercadoria_EventoAdicionou(Entidades.Mercadoria.Mercadoria mercadoria, double quantidade)
        {
            Adicionar(mercadoria, quantidade, ModoJanelaÍndice.MostrarSeNecessário);
        }

        protected enum ModoJanelaÍndice
        { NuncaMostrarNãoAlterandoÍndice, MostrarSeNecessário, MostrarSempre } 

        /// <summary>
        /// Caso o modo seja "NuncaMostrarNãoAlterandoÍndice",
        /// o índice deve ser obtido da mercadoria no parâmetro.
        /// </summary>
        protected virtual void EscolherÍndice(Entidades.Mercadoria.Mercadoria mercadoria, ModoJanelaÍndice modoJanela)
        {
            if (verificador != null)
            {
                List<double> listaÍndicesCompletos = verificador.ObterListaÍndices(mercadoria);

                // Cria uma lista com os índices arredondados
                List<double> listaÍndicesArredondados = new List<double>();
                foreach (double d in listaÍndicesCompletos)
                {
                    double arredondado = Math.Round(d, 2);
                    if (!listaÍndicesArredondados.Contains(arredondado))
                        listaÍndicesArredondados.Add(arredondado);
                }
                if (!listaÍndicesArredondados.Contains(mercadoria.ÍndiceArredondado))
                    listaÍndicesArredondados.Add(mercadoria.ÍndiceArredondado);

                /* Código temporário:
                 * 
                 * a seguinte linha desliga a janela de escolha de índice para o Varejo.
                 * Será escolhido o valor da mercadoria em real (índice arrendondado).
                 * 
                 * Para novos acertos, o indice na saída já será o valor em real e então
                 * todo este código poderá ser removido.
                 * 
                 */
                if (mercadoria.TabelaPreço.Nome == "Varejo")
                {
                    mercadoria.Índice = mercadoria.ÍndiceArredondado;
                    return;
                }

                // Neste ponto a listaÍndices tem um ou mais elementos.
                if ((modoJanela == ModoJanelaÍndice.MostrarSempre || listaÍndicesArredondados.Count > 1)
                    && (modoJanela != ModoJanelaÍndice.NuncaMostrarNãoAlterandoÍndice))
                {
                    JanelaEscolhaÍndice j = new JanelaEscolhaÍndice();
                    j.CarregarÍndices(listaÍndicesArredondados, mercadoria.ÍndiceArredondado, mercadoria, entidade as RelacionamentoAcerto);
                    if (j.ShowDialog() == DialogResult.OK)
                    {
                        // Altera o indice na mercadoria
                        mercadoria.Índice = j.ObterValorEscolhido();
                    }
                    else
                    {
                        //MessageBox.Show("Será utilizado o indice vigente (" + mercadoria.Índice.ToString() + ")", "Escolha do índice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        throw new Exception("Cancelado pelo usuário");
                    }

                    mercadoria.Índice = j.ObterValorEscolhido();
                }
                else if (modoJanela != ModoJanelaÍndice.NuncaMostrarNãoAlterandoÍndice)
                    mercadoria.Índice = listaÍndicesArredondados[0];
            }
        }

        private void quadroMercadoria_EventoAlterou(ISaquinho saquinhoOriginal, double novaQtd, double novoPeso)
        {
            if (baseInferior.ConferirTravamento())
            {
                MessageBox.Show(ParentForm,
                    "ATENÇÃO\n\nEste documento foi travado e não pode ser alterado.",
                    "Documento travado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            bandejaAgrupada.Remover(saquinhoOriginal);

            ISaquinho novoSaquinho = saquinhoOriginal.Clone(novaQtd);
            novoSaquinho.Mercadoria.EsquecerCoeficientePersonalizado();
            
            if (novoSaquinho.Mercadoria.DePeso)
                novoSaquinho.Mercadoria.Peso = novoPeso;

            bandejaAgrupada.Adicionar(novoSaquinho);

            DateTime agora = Entidades.Configuração.DadosGlobais.Instância.HoraDataAtual;
            
            // Retira
            //bandejaHistórico.Adicionar(new SaquinhoHistóricoRelacionado(coleção.Relacionar(saquinhoOriginal.Mercadoria, saquinhoOriginal.Quantidade * -1)));
            //já é removido

            // Relaciona
            try
            {
                bandejaHistórico.Adicionar(new SaquinhoHistóricoRelacionado(coleção.Relacionar(novoSaquinho.Mercadoria, novaQtd, novoSaquinho.Mercadoria.ÍndiceArredondado)));
            }
            catch (Acesso.Comum.Exceções.OperaçãoCancelada)
            {
                MessageBox.Show(
                    ParentForm,
                    "A operação foi cancelada pelo sistema. Nenhuma alteração foi realizada no banco de dados.",
                    "Relacionamento de mercadoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        internal void Abrir(HistóricoRelacionamento coleção, Entidades.Relacionamento.Relacionamento entidade, BaseEditarRelacionamento baseInferior)
        {
            this.baseInferior = baseInferior;
            this.coleção = coleção;
            this.entidade = entidade;

            Entidades.Relacionamento.RelacionamentoAcerto entidadeAcerto = entidade as Entidades.Relacionamento.RelacionamentoAcerto;

            /* Não permitir edição de tabela em documentos cujo
             * acerto possui tabela definida.
             */
            if (entidadeAcerto == null || entidadeAcerto.AcertoConsignado != null && entidadeAcerto.AcertoConsignado.TabelaPreço != null)
            {
                bandejaAgrupada.PermitirSeleçãoTabela = false;
                bandejaHistórico.PermitirSeleçãoTabela = false;
            }

            if (entidade.TabelaPreço == null)
            {
                if (entidadeAcerto.AcertoConsignado != null && entidadeAcerto.AcertoConsignado.TabelaPreço != null
                    && !(entidade is Entidades.Relacionamento.Venda.Venda))
                    entidadeAcerto.TabelaPreço = entidadeAcerto.AcertoConsignado.TabelaPreço;
                else
                    QuestionarTabelaPreço(entidadeAcerto);
            }

            // Deve-se garantir que existe uma tabelad e preço definida.
            while (entidade.TabelaPreço == null)
            {
                if (MessageBox.Show(
                    ParentForm,
                    "Por favor, escolha uma tabela de preços para iniciar a sua digitação de mercadorias.",
                    "Digitação de mercadorias",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    throw new ExceçãoTabelaVazia();
                }
                else
                    QuestionarTabelaPreço(entidadeAcerto);
            }

            quadroMercadoria.Tabela = entidade.TabelaPreço;
            bandejaAgrupada.Tabela = entidade.TabelaPreço;
            bandejaHistórico.Tabela = entidade.TabelaPreço;
            bandejaAgrupada.Abrir(coleção);
            bandejaHistórico.Abrir(coleção);

            entidade.AoAlterarTabela += new Acesso.Comum.DbManipulação.DbManipulaçãoHandler(AoAlterarTabelaEntidade);

            if (coleção.Count > 0)
                PermitirSeleçãoTabela = false;
            else if (entidade is Entidades.Relacionamento.Venda.Venda &&
                Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.PersonalizarVenda))
            {
                bandejaAgrupada.PermitirSeleçãoTabela = true;
                bandejaHistórico.PermitirSeleçãoTabela = true;
            }
        }

        /// <summary>
        /// Questiona qual tabela de preço será utilizada.
        /// </summary>
        private void QuestionarTabelaPreço(Entidades.Relacionamento.RelacionamentoAcerto entidade)
        {
            Entidades.Pessoa.Pessoa pessoa;
            Entidades.Relacionamento.Venda.Venda venda = entidade as Entidades.Relacionamento.Venda.Venda;

            if (venda != null && (entidade.Pessoa == null || Representante.ÉRepresentante(venda.Vendedor)))
                pessoa = venda.Vendedor;
            else
                pessoa = entidade.Pessoa;

            using (EscolherTabela dlg = new EscolherTabela(pessoa))
            {
                AguardeDB.Suspensão(true);

                dlg.ShowDialog(ParentForm);

                AguardeDB.Suspensão(false);

                if (dlg.DialogResult == DialogResult.Cancel)
                    throw new OperationCanceledException();

                entidade.TabelaPreço = dlg.Tabela;
            }
        }

        void AoAlterarTabelaEntidade(Acesso.Comum.DbManipulação entidade)
        {
            Relacionamento entidadeAcerto = (Relacionamento) this.entidade;
            if (this.entidade == entidade)
            {
                quadroMercadoria.Tabela = entidadeAcerto.TabelaPreço;
                bandejaAgrupada.Tabela = entidadeAcerto.TabelaPreço;
                bandejaHistórico.Tabela = entidadeAcerto.TabelaPreço;
            }
            else
                System.Diagnostics.Debug.Fail("Entidade diferente!");
        }

        private void bandejaAgrupada_SaquinhoExcluído(Bandeja bandeja, ISaquinho saquinho)
        {
            if (!baseInferior.ConferirTravamento())
            {
                try
                {
                    HistóricoRelacionamentoItem item = coleção.Relacionar(saquinho.Mercadoria, saquinho.Quantidade * -1, saquinho.Mercadoria.ÍndiceArredondado);
                    bandejaHistórico.Adicionar(new SaquinhoHistóricoRelacionado(item));
                }
                catch (Acesso.Comum.Exceções.OperaçãoCancelada)
                {
                    MessageBox.Show(
                        ParentForm,
                        "A operação foi cancelada pelo sistema. Nenhuma alteração foi realizada no banco de dados.",
                        "Relacionamento de mercadoria",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void bandejaAgrupada_AntesExclusão(ref bool cancelado)
        {
            bool travado = baseInferior.ConferirTravamento();

            cancelado = travado;
        }

        private void bandejaAgrupada_SeleçãoMudou(Bandeja bandeja, ISaquinho saquinho)
        {
            if (saquinho != null)
            {
                quadroFoto.MostrarFoto(saquinho.Mercadoria);

                if (tipoExibiçãoAtual == TipoExibição.TipoAgrupado)
                    quadroMercadoria.AlternarParaAlteração(saquinho);
            }
            else
            {
                // Des-selecionou
                quadroMercadoria.AlternarParaAdicionar();
            }

        }

        private void bandejaHistórico_SeleçãoMudou(Bandeja bandeja, ISaquinho saquinho)
        {
            // Assim que usuário clica no item do histórico, a bandeja agrupada já encontra o item para facilitar modificação
            if (saquinho != null)
            {
                if (saquinho.Mercadoria.Peso != saquinho.Peso)
                    throw new Exception("Esperava-se que o peso da mercadoria fosse o peso do saquinho.");

                if (bandejaAgrupada.Contém(saquinho.Mercadoria))
                    bandejaAgrupada.Selecionar(saquinho.Mercadoria);
            }
        }

        private void bandejaAgrupada_TabelaAlterada(Bandeja bandeja, Tabela tabela)
        {
            bandejaHistórico.Tabela = tabela;

            if (AoAlterarTabela != null)
                AoAlterarTabela(this, tabela);
        }

        private void bandejaHistórico_TabelaAlterada(Bandeja bandeja, Tabela tabela)
        {
            try
            {
                if (entidade.TabelaPreço != tabela)
                    entidade.TabelaPreço = tabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    ParentForm,
                    "Não foi possível alterar a tabela.\n\n" + e.Message,
                    "Alteração de tabela",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                bandeja.Tabela = entidade.TabelaPreço;
                return;
            }

            bandejaAgrupada.Tabela = tabela;
            quadroMercadoria.Tabela = tabela;
        
            if (AoAlterarTabela != null)
                AoAlterarTabela(this, tabela);
        }

        private void bandejaAgrupada_AlteraçãoÍndiceSolicitada(Bandeja bandeja, ISaquinho saquinho)
        {
            if (!baseInferior.ConferirTravamento())
            {

                ISaquinho saquinhoParaReAdicionar = saquinho.Clone(saquinho.Quantidade);
                bool deuErro = false;
                try
                {
                    EscolherÍndice(saquinhoParaReAdicionar.Mercadoria, ModoJanelaÍndice.MostrarSempre);
                }
                catch
                {
                    deuErro = true;
                }

                if (!deuErro)
                {
                    bandejaAgrupada.Remover(saquinho);
                    Adicionar(saquinhoParaReAdicionar.Mercadoria, saquinhoParaReAdicionar.Quantidade, ModoJanelaÍndice.NuncaMostrarNãoAlterandoÍndice);
                }
            }
        }

        private void bandejaAgrupada_ColarSolicitado(object sender, EventArgs e)
        {
            List<ISaquinho> lista = ÁreaDeTransferência.Instância.Lista;

            if (lista.Count == 0) return;

            if (ConferirTravamento())
                return;

            Aguarde aguarde = new Aguarde("Colando..", lista.Count);
            aguarde.Abrir();
            foreach (ISaquinho s in lista)
            {
                s.Mercadoria.Peso = s.Peso;
                Adicionar(s.Mercadoria, s.Quantidade, ModoJanelaÍndice.MostrarSeNecessário, false);
                aguarde.Passo(s.Mercadoria.Referência);
            }
            aguarde.Close();
        }
    }
}