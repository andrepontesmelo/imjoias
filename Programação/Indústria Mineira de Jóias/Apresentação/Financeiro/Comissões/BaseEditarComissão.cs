using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.ComissãoCálculo;
using Apresentação.Financeiro.Venda;
using Apresentação.Atendimento;
using Entidades.ComissãoCálculo.Impressão;

namespace Apresentação.Financeiro.Comissões
{
    public partial class BaseEditarComissão : BaseInferior
    {
        /// <summary>
        /// O processamento de comissão só é feito quando o usuário abre a aba do resultado.
        /// É reculado quando tem alteração de venda selecionada.
        /// </summary>
        //private bool resultadoPrecisaSerRecalculado;
        Comissão comissão;
        private bool necessárioRecarregar = false;

        public BaseEditarComissão()
        {
            InitializeComponent();
        }

        private DateTime? diaInicial = null;
        private DateTime? diaFinal = null;
        private Entidades.Pessoa.Pessoa comissãoPara = null;


        private DateTime? DiaInicial
        {
            get { return diaInicial; }
            set { diaInicial = value;  }
        }

        private DateTime? DiaFinal
        {
            get { return diaFinal; }
            set { diaFinal = value; }
        }

        private DateTime? NovoDiaFinal
        {
            get
            {
                if (!dataFinal.Enabled)
                    return null;
                else
                    return dataFinal.Value;
            }
            set
            {
                diaFinal = value;
                if (!diaFinal.HasValue)
                    dataFinal.Enabled = false;
                else
                {
                    dataFinal.Enabled = true;
                    dataFinal.Value = diaFinal.Value;
                }
            }
        }
       

        private DateTime? NovoDiaInicial
        {
            get 
            { 
                if (!dataInicial.Enabled)
                    return null;
                else
                    return dataInicial.Value; 
            }
            set
            {
                diaInicial = value;
                if (!diaInicial.HasValue)
                    dataInicial.Enabled = false;
                else
                {
                    dataInicial.Enabled = true;
                    dataInicial.Value = diaInicial.Value;
                }
            }
        }
       
        private Entidades.Pessoa.Pessoa NovaComissãoPara
        {
            get { return comboboxFuncionário.Enabled ? comboboxFuncionário.Funcionário : null; }
            set
            {
                comissãoPara = value;

                if (comissãoPara == null)
                {
                    comboboxFuncionário.Enabled = false;
                } else
                {
                    comboboxFuncionário.Enabled = true;
                    comboboxFuncionário.Funcionário = comissãoPara;
                }
            }
        }

       private Entidades.Pessoa.Pessoa ComissãoPara
        {
            get { return comissãoPara; }
            set { comissãoPara = value; }
        }
     
        public void Abrir(Comissão comissão)
        {
            this.comissão = comissão;

            //resultadoPrecisaSerRecalculado = true;
            //listViewVendas.Carregar(true, comissão.Funcionário);
            //listViewVendas.Marcar(comissão.ObterVendas());
            ////listViewVendas.AoMarcar += new EventHandler(listViewVendas_AoMarcar);
            //this.entidade = comissão;
            títuloBaseInferior.Título = "Edição de comissão No " + comissão.Código.ToString() +
                " - " + comissão.MêsReferência.ToString("MMMM/yyyy");
            títuloBaseInferior.Descrição = comissão.Descrição;

            CarregarListasVendasAbertaseFechadas();

            lstComissionados.Carregar(comissão);
        }

        private void CarregarListasVendasAbertaseFechadas()
        {
            aberturaVenda.Carregar(DiaInicial, DiaFinal, ComissãoPara, comissão, true, false);
            aberturaEstorno.Carregar(DiaInicial, DiaFinal, ComissãoPara, comissão, true, true);
        }

        //private void listViewVendas_AoMarcar(object sender, EventArgs e)
        //{
        //    //// entidade é nula ao carregar tela.
        //    //if (entidade != null)
        //    //{
        //    //    resultadoPrecisaSerRecalculado = true;
        //    //    entidade.DeterminarVendas(listViewVendas.ObterCódigosMarcados());
        //    //}
        //}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            VerificarVisibilidadeLinkAplicarCancelar();
        }

        private void comboboxFuncionário_FuncionárioAlterado(object sender, EventArgs e)
        {
            VerificarVisibilidadeLinkAplicarCancelar();
        }

        private void VerificarVisibilidadeLinkAplicarCancelar()
        {
            opçãoAplicarFiltros.Visible = 
                opçãoCancelarFiltros.Visible = 
                (NovoDiaInicial != DiaInicial) ||
                (NovoDiaFinal != DiaFinal) ||
                (NovaComissãoPara != ComissãoPara);
        }

        private void opçãoAplicarFiltros_Click(object sender, EventArgs e)
        {
            DiaInicial = NovoDiaInicial;
            DiaFinal = NovoDiaFinal;
            ComissãoPara = NovaComissãoPara;

            CarregarListasVendasAbertaseFechadas();

            VerificarVisibilidadeLinkAplicarCancelar();
        }

        private void opçãoCancelar_Click(object sender, EventArgs e)
        {
            NovoDiaInicial = DiaInicial;
            NovoDiaFinal = DiaFinal;
            NovaComissãoPara = ComissãoPara;

            VerificarVisibilidadeLinkAplicarCancelar();
        }



        private void opçãoRecarregar_Click(object sender, EventArgs e)
        {
            CarregarListasVendasAbertaseFechadas();


            comboboxFuncionário.Carregar(comissão);
            lstComissionados.Carregar(comissão);

            necessárioRecarregar = false;
        }

        public override void AoCarregarCompletamente(Splash splash)
        {
            base.AoCarregarCompletamente(splash);

            comboboxFuncionário.Carregar(comissão);
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (necessárioRecarregar)
            {
                Recarregar();
            }

            //quadroFiltrarExibição.Visible = 
            //    tabs.SelectedTab != tabVendedores;
        }

        private void Recarregar()
        {
            CarregarListasVendasAbertaseFechadas();
            comboboxFuncionário.Carregar(comissão);
            lstComissionados.Carregar(comissão);
            necessárioRecarregar = false;
        }

        private void dataFinal_ValueChanged(object sender, EventArgs e)
        {
            VerificarVisibilidadeLinkAplicarCancelar();
        }

        private void dataInicial_Validating(object sender, CancelEventArgs e)
        {
            if (dataInicial.Enabled && dataFinal.Enabled
                && dataInicial.Value > dataFinal.Value)
            {
                e.Cancel = true;
                MessageBox.Show(this,
                    "Escolha uma data anterior a " + dataFinal.Value.AddDays(1).ToLongDateString(),
                    "Data inicial maior que data final",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void dataFinal_Validating(object sender, CancelEventArgs e)
        {
            if (dataInicial.Enabled && dataFinal.Enabled
                && dataInicial.Value > dataFinal.Value)
            {
                e.Cancel = true;
                MessageBox.Show(this,
                    "Escolha uma data posterior a " + dataInicial.Value.AddDays(-1).ToLongDateString(),
                    "Data final menor que data inicial",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void aberturaVenda_AoSolicitarAbrirAtendimentoPessoa(Entidades.Pessoa.Pessoa p)
        {
            BaseAtendimento baseAtendimento = new BaseAtendimento(p);
            SubstituirBase(baseAtendimento);
        }

        private void aberturaVenda_AoSolicitarAbrirVenda(Entidades.Relacionamento.Venda.Venda v)
        {
            BaseEditarVenda baseVenda = new BaseEditarVenda();
            baseVenda.Abrir(v);
            SubstituirBase(baseVenda);
        }

        private void iconeFiltroPessoa_Click(object sender, EventArgs e)
        {
            comboboxFuncionário.Enabled = !comboboxFuncionário.Enabled;

            VerificarVisibilidadeLinkAplicarCancelar();
        }

        private void iconeDataInicial_Click(object sender, EventArgs e)
        {
            dataInicial.Enabled = !dataInicial.Enabled;

            VerificarVisibilidadeLinkAplicarCancelar();
        }

        private void iconeDataFinal_Click(object sender, EventArgs e)
        {
            dataFinal.Enabled = !dataFinal.Enabled;

            VerificarVisibilidadeLinkAplicarCancelar();
        }

        private void iconeFiltroPessoa_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void iconeDataFinal_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void aberturaEstorno_AoSerNecessárioRecarregar(object sender, EventArgs e)
        {
            necessárioRecarregar = true;
        }

        private void aberturaVenda_AoSerNecessárioRecarregar(object sender, EventArgs e)
        {
            necessárioRecarregar = true;
        }

        private void opçãoRelatórioResumo_Click(object sender, EventArgs e)
        {
            JanelaImpressãoComissão j = new JanelaImpressãoComissão(comissão, ObterFiltro());
            j.InserirRelatórioResumo();
            j.Abrir(this);
        }

        private void opçãoRelatórioPorVenda_Click(object sender, EventArgs e)
        {
            JanelaImpressãoComissão j = new JanelaImpressãoComissão(comissão, ObterFiltro());
            j.InserirRelatórioVenda();
            j.Abrir(this);
        }

        private void opçãoImprimirTodos_Click(object sender, EventArgs e)
        {
            JanelaImpressãoComissão j = new JanelaImpressãoComissão(comissão, ObterFiltro());
            j.InserirTodosRelatorios();
            j.Abrir(this);
        }

        private void opçãoRelatórioRegraPessoa_Click(object sender, EventArgs e)
        {
            JanelaImpressãoComissão j = new JanelaImpressãoComissão(comissão, ObterFiltro());
            j.InserirRelatórioRegraPessoa();
            j.Abrir(this);

        }

        private void opçãoRelatórioCompartilhada_Click(object sender, EventArgs e)
        {
            JanelaImpressãoComissão j = new JanelaImpressãoComissão(comissão, ObterFiltro());
            j.InserirRelatórioCompartilhada();
            j.Abrir(this);
        }

        private Filtro ObterFiltro()
        {
            Filtro filtro = new Filtro(DiaInicial, DiaFinal, comissãoPara);
            return filtro;
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            Recarregar();
        }

        private void opçãoVendaItem_Click(object sender, EventArgs e)
        {
            JanelaImpressãoComissão j = new JanelaImpressãoComissão(comissão, ObterFiltro());
            j.InserirRelatórioVendaItem();
            j.Abrir(this);
        }

        private void opçãoSetor_Click(object sender, EventArgs e)
        {
            JanelaImpressãoComissão j = new JanelaImpressãoComissão(comissão, ObterFiltro());
            j.InserirRelatórioSetor();
            j.Abrir(this);
        }
    }
}
