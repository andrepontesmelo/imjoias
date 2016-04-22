using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Acerto;
using Entidades.Pessoa;

namespace Apresentação.Financeiro.Acerto
{
    /// <summary>
    /// Janela para escolha de acerto de consignado.
    /// </summary>
    /// <remarks>
    /// Utilize o método estático QuestionarUsuário.</remarks>
    public partial class EscolherAcerto : JanelaExplicativa
    {
        private Entidades.Pessoa.Pessoa pessoa;

        public AcertoConsignado AcertoConsignado
        {
            get { return dadosAcerto.AcertoConsignado; }
        }

        private EscolherAcerto(Entidades.Pessoa.Pessoa cliente, AcertoConsignado[] acertos)
        {
            InitializeComponent();

            this.pessoa = cliente;

            foreach (AcertoConsignado acerto in acertos)
                AdicionarAcerto(acerto);

            lblInstrução.Text = string.Format(
                lblInstrução.Text, cliente.Nome);
        }

        /// <summary>
        /// Adiciona acerto à lista.
        /// </summary>
        private void AdicionarAcerto(AcertoConsignado acerto)
        {
            ListViewItem item = new ListViewItem();
            item.Text = acerto.Código.ToString();

            if (acerto.Previsão.HasValue)
                item.SubItems.Add(acerto.Previsão.Value.ToLongDateString());
            else
                item.SubItems.Add("Sem previsão");

            if (acerto.DataEfetiva.HasValue)
                item.ForeColor = SystemColors.GrayText;

            lstAcertos.Items.Add(item);

            item.Tag = acerto;
        }

        private void lstAcertos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lstAcertos.SelectedItems.Count == 1;
            dadosAcerto.Visible = btnOK.Enabled;

            if (lstAcertos.SelectedItems.Count == 1)
                dadosAcerto.AcertoConsignado = (AcertoConsignado)lstAcertos.SelectedItems[0].Tag;
            else
                dadosAcerto.AcertoConsignado = null;
        }

        private void lstAcertos_DoubleClick(object sender, EventArgs e)
        {
            if (btnOK.Enabled)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Questiona usuário qual acerto utilizar.
        /// </summary>
        public static AcertoConsignado QuestionarUsuário(IWin32Window owner, Entidades.Pessoa.Pessoa pessoa, bool permitirNovo)
        {
            bool loop;

            do
            {
                AcertoConsignado[] acertos;

                loop = false;

                AguardeDB.Mostrar();

                try
                {
                    acertos = AcertoConsignado.ObterAcertosPendentes(pessoa);
                }
                finally
                {
                    AguardeDB.Fechar();
                }

                if (acertos.Length > 0 || !permitirNovo)
                    using (EscolherAcerto dlg = new EscolherAcerto(pessoa, acertos))
                    {
                        dlg.btnNovo.Visible = permitirNovo;

                        switch (dlg.ShowDialog(owner))
                        {
                            case DialogResult.OK:
                                return dlg.AcertoConsignado;

                            case DialogResult.Cancel:
                                return null;

                            case DialogResult.Retry:
                                using (CriarAcerto novo = new CriarAcerto(pessoa))
                                {
                                    if (novo.ShowDialog(owner) == DialogResult.OK)
                                        return CadastrarAcerto(pessoa, novo.Previsão);
                                    else
                                        loop = true;
                                }
                                break;

                            default:
                                throw new NotSupportedException();
                        }
                    }
                else
                    using (CriarAcerto novo = new CriarAcerto(pessoa))
                    {
                        if (novo.ShowDialog(owner) == DialogResult.OK)
                            return CadastrarAcerto(pessoa, novo.Previsão);
                    }
            } while (loop);

            return null;
        }

        /// <summary>
        /// Cadastra novo acerto.
        /// </summary>
        private static AcertoConsignado CadastrarAcerto(Entidades.Pessoa.Pessoa pessoa, DateTime? previsão)
        {
            AcertoConsignado acerto = new AcertoConsignado();

            acerto.Previsão = previsão;
            acerto.FuncConsignado = Funcionário.FuncionárioAtual;
            acerto.Cliente = pessoa;

            return acerto;
        }

        /// <summary>
        /// Permite a exibição de outros acertos.
        /// </summary>
        private void botãoLiberarAcertosAntigos_LiberarRecurso(object sender, EventArgs e)
        {
            using (SeleçãoPeríodo dlg = new SeleçãoPeríodo())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    lstAcertos.Items.Clear();

                    AguardeDB.Mostrar();

                    try
                    {
                        foreach (AcertoConsignado acerto in AcertoConsignado.ObterAcertos(pessoa, dlg.PeríodoInicial, dlg.PeríodoFinal))
                            AdicionarAcerto(acerto);
                    }
                    finally
                    {
                        AguardeDB.Fechar();
                    }
                }
            }

            botãoLiberarAcertosAntigos.Visible = true;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}