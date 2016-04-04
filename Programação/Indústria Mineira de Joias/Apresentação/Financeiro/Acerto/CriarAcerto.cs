using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Configuração;

namespace Apresentação.Financeiro.Acerto
{
    /// <summary>
    /// Janela utilizada para criar acerto.
    /// </summary>
    partial class CriarAcerto : JanelaExplicativa
    {
        private DateTime hoje;

        public DateTime? Previsão
        {
            get
            {
                if (chkSemPrevisão.Checked)
                    return null;
                else
                    return dtPrevisão.Value;
            }
        }

        public CriarAcerto(Entidades.Pessoa.Pessoa pessoa)
        {
            InitializeComponent();

            hoje = DadosGlobais.Instância.HoraDataAtual.Date;

            dtPrevisão.Value = hoje.AddDays(DadosGlobais.Instância.PrazoConsignadoPadrão);
            dtPrevisão.MaxDate = hoje.AddDays(DadosGlobais.Instância.PrazoConsignadoMáximo);
            dtPrevisão.MinDate = hoje;

            txtCliente.Text = pessoa.Nome;

            if (Entidades.Pessoa.Representante.ÉRepresentante(pessoa))
            {
                botãoLiberarRecurso_LiberarRecurso(this, null);
                botãoLiberarRecurso.Enabled = false;
                chkSemPrevisão.Checked = true;
            }
        }

        public CriarAcerto(Entidades.Acerto.AcertoConsignado acerto)
            : this(acerto.Cliente)
        {
            if (acerto.Previsão.HasValue)
            {
                if (dtPrevisão.MinDate > acerto.Previsão.Value)
                    dtPrevisão.MinDate = acerto.Previsão.Value;

                if (dtPrevisão.MaxDate < acerto.Previsão.Value)
                    dtPrevisão.MaxDate = acerto.Previsão.Value;

                dtPrevisão.Value = acerto.Previsão.Value;
            }
        }

        private void dtPrevisão_ValueChanged(object sender, EventArgs e)
        {
            if (!txtDias.Focused)
            {
                TimeSpan ts = dtPrevisão.Value - hoje;

                txtDias.Int = ts.Days;
            }

            listaAcertoHorário.Data = dtPrevisão.Value;
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            if (txtDias.Focused)
                try
                {
                    dtPrevisão.Value = hoje.AddDays(txtDias.Int);
                }
                catch
                {
                    TimeSpan ts = dtPrevisão.Value - hoje;

                    txtDias.Int = ts.Days;
                    txtDias.SelectAll();
                }
        }

        private void botãoLiberarRecurso_LiberarRecurso(object sender, EventArgs e)
        {
            dtPrevisão.MaxDate = DateTimePicker.MaximumDateTime;
            chkSemPrevisão.Visible = true;
        }

        private void chkSemPrevisão_CheckedChanged(object sender, EventArgs e)
        {
            txtDias.ReadOnly = chkSemPrevisão.Checked;
            dtPrevisão.Enabled = chkSemPrevisão.Checked;

            if (chkSemPrevisão.Checked)
                txtDias.Text = "";
            else
            {
                TimeSpan ts = dtPrevisão.Value - hoje;

                txtDias.Int = ts.Days;
            }
       }
    }
}