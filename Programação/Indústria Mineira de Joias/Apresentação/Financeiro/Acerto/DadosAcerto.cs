using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Acerto;
using Entidades.Pessoa;
using Entidades.Configuração;

namespace Apresentação.Financeiro.Acerto
{
    /// <summary>
    /// Exibe informações de um acerto.
    /// </summary>
    public partial class DadosAcerto : Quadro
    {
        private AcertoConsignado acerto;

        public DadosAcerto()
        {
            InitializeComponent();

            dtPrevisão.Enabled = false;
        }

        [DefaultValue(false)]
        public bool PermitirAlteração
        {
            get { return dtPrevisão.Enabled; }
            set { 
                dtPrevisão.Enabled = txtCotação.Enabled = value; 
            }
        }

        [DefaultValue(false), Browsable(false), ReadOnly(true)]
        public bool LiberarPrazo
        {
            get
            {
                if (!DesignMode)
                    return ((TimeSpan)(dtPrevisão.MaxDate.Date - DadosGlobais.Instância.HoraDataAtual.Date)).Days > DadosGlobais.Instância.PrazoConsignadoMáximo;
                else
                    return false;
            }
            set
            {
                if (DesignMode)
                    return;
                else if (value)
                    dtPrevisão.MaxDate = DateTimePicker.MaximumDateTime;
                else
                {
                    DateTime dataMáxima = DadosGlobais.Instância.HoraDataAtual.Date.AddDays(DadosGlobais.Instância.PrazoConsignadoMáximo);

                    if (acerto != null && acerto.Previsão.HasValue)
                        dtPrevisão.MaxDate = dataMáxima > acerto.Previsão.Value ? dataMáxima : acerto.Previsão.Value;
                }
            }
        }

        [DefaultValue(null), ReadOnly(true), Browsable(false)]
        public AcertoConsignado AcertoConsignado
        {
            get { return acerto; }
            set
            {
                acerto = value;

                if (acerto != null)
                {
                    dtDesde.Value = acerto.DataMarcação;
                    lblMarcação.Text = "Marcado por " + Entidades.Pessoa.Pessoa.ReduzirNome(acerto.FuncConsignado.Nome);

                    // Altera o valor mínimo da previsão.
                    dtPrevisão.MinDate = acerto.DataMarcação.Date;
                    dtPrevisão.Value = acerto.DataMarcação;
                   
                    if (acerto.Previsão.HasValue)
                    {
                        if (dtPrevisão.MaxDate < dtPrevisão.Value)
                            dtPrevisão.MaxDate = dtPrevisão.Value;

                        dtPrevisão.Value = acerto.Previsão.Value;
                    }
                    else
                        dtPrevisão.Text = "";

                    if (acerto.DataEfetiva.HasValue)
                    {
                        dtRealização.Value = acerto.DataEfetiva.Value;
                        dtRealização.Visible = true;
                        lblEfetivação.Visible = true;

                        lblEfetivação.Text = "Efetivado por " + 
                            Entidades.Pessoa.Pessoa.ReduzirNome(acerto.FuncAcerto.Nome);
                    }
                    else
                    {
                        dtRealização.Text = "";
                        dtRealização.Visible = false;
                        lblEfetivação.Visible = false;
                    }

                    cmbTabela.Seleção = acerto.TabelaPreço;

                    txtCotação.Data = acerto.DataMarcação;

                    if (acerto.Cotação.HasValue)
                        txtCotação.Valor = acerto.Cotação.Value;
                    else
                        txtCotação.Limpar();
                }
            }
        }

        private void dtPrevisão_Validating(object sender, CancelEventArgs e)
        {
            if (!DesignMode && acerto != null && dtPrevisão.Value < acerto.DataMarcação)
            {
                MessageBox.Show(
                    ParentForm,
                    "A data de previsão não pode ser anterior à data de marcação.",
                    "Acerto - " + acerto.Cliente.Nome,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void dtPrevisão_Validated(object sender, EventArgs e)
        {
            if (!DesignMode && acerto != null && acerto.Cadastrado && acerto.Previsão != dtPrevisão.Value)
            {
                DateTime? previsãoOriginal = acerto.Previsão;

                AguardeDB.Mostrar();

                acerto.Previsão = dtPrevisão.Value;
                acerto.Atualizar();

                if (previsãoOriginal.HasValue)
                    acerto.Cliente.RegistrarHistórico(
                        string.Format(
                        "Previsão para o acerto {0} alterado de {1} para {2} por {3}.",
                        acerto.Código,
                        previsãoOriginal,
                        acerto.Previsão,
                        Funcionário.FuncionárioAtual.Nome));

                AguardeDB.Fechar();
            }
        }

        void txtCotação_EscolheuCotação(Entidades.Financeiro.Cotação escolha)
        {
            acerto.Cotação = escolha.Valor;
            acerto.Atualizar();
        }

        public void IniciarEdição()
        {
            dtPrevisão.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LiberarPrazo = false;
        }
    }
}
