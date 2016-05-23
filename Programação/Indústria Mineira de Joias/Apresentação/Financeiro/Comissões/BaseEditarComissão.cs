using Apresentação.Atendimento;
using Apresentação.Financeiro.Venda;
using Apresentação.Formulários;
using Entidades.ComissãoCálculo;
using Entidades.ComissãoCálculo.Impressão;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentação.Financeiro.Comissões
{
    public partial class BaseEditarComissão : BaseInferior
    {
        Comissão comissão;
        private bool necessárioRecarregar = false;

        public BaseEditarComissão()
        {
            InitializeComponent();

            comissãoPara = NovaComissãoPara = Comissão.UsuárioPodeManipularComissão ? null :
                Entidades.Pessoa.Funcionário.FuncionárioAtual;
        }

        private DateTime? diaInicial = null;
        private DateTime? diaFinal = null;
        private Entidades.Pessoa.Pessoa comissãoPara;

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
            get {
                if (!Comissão.UsuárioPodeManipularComissão)
                    return Entidades.Pessoa.Funcionário.FuncionárioAtual;

                return comboboxFuncionário.Enabled ? comboboxFuncionário.Funcionário : null;
            }
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
     
        private void AlternarExibiçãoSomenteLeitura()
        {
            tabs.Controls.Remove(tabVendedores);
            tabs.Controls.Remove(tabAjuda);
            quadro1.Visible = quadro3.Visible = iconeFiltroPessoa.Visible = comboboxFuncionário.Visible = false;
            comissãoPara = comboboxFuncionário.Funcionário = Entidades.Pessoa.Funcionário.FuncionárioAtual;
        }

        public void Abrir(Comissão comissão)
        {
            this.comissão = comissão;
            títuloBaseInferior.Título = (Comissão.UsuárioPodeManipularComissão ? "Edição de comissão" : "Comissão de " + 
                Entidades.Pessoa.Pessoa.ReduzirNome(ComissãoPara.Nome)) + " nº " + comissão.Código.ToString() +
                " - " + comissão.MêsReferência.ToString("MMMM/yyyy");

            if (!Comissão.UsuárioPodeManipularComissão)
                AlternarExibiçãoSomenteLeitura();

            títuloBaseInferior.Descrição = comissão.Descrição;
            CarregarListasVendasAbertaseFechadas();

            lstComissionados.Carregar(comissão);
        }

        private void CarregarListasVendasAbertaseFechadas()
        {
            aberturaVenda.Carregar(DiaInicial, DiaFinal, ComissãoPara, comissão, true, false);
            aberturaEstorno.Carregar(DiaInicial, DiaFinal, ComissãoPara, comissão, true, true);
        }

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
