using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endereço;
using Apresentação.Formulários;
using Acesso.Comum;
using System.Data.Common;

namespace Apresentação.Pessoa.Endereço
{
    /// <summary>
    /// Janela para edição de localidade.
    /// </summary>
    public partial class EditarLocalidade : Apresentação.Formulários.JanelaExplicativa
    {
        private Localidade localidade;
        private string estadoOriginal, paísOriginal;

        private const string strMesma = "<A mesma para todo o estado>";

        public EditarLocalidade()
        {
            InitializeComponent();

            localidade = new Localidade();

            CarregarDados();
        }

        public EditarLocalidade(Localidade localidade)
        {
            InitializeComponent();
            CarregarDados();

            Localidade = localidade;
        }

        public Localidade Localidade
        {
            get { return localidade; }
            set
            {
                localidade = value;

                txtNome.Text = localidade.Nome;

                if (localidade.Estado != null)
                {
                    if (!localidade.Estado.Cadastrado)
                    {
                        estadoOriginal = localidade.Estado.Nome;
                        paísOriginal = localidade.Estado.País != null ? localidade.Estado.País.Nome : null;
                    }
                    else
                    {
                        cmbPaís.Text = localidade.Estado.País.Nome;
                        cmbEstado.Text = localidade.Estado.Nome;
                    }
                }
                else if (cmbEstado.SelectedItem != null)
                    localidade.Estado = Estado.ObterEstado(ulong.Parse((string)cmbEstado.SelectedValue));

                if (value.DDD.HasValue)
                    txtDDD.Int = (int)value.DDD;
                else
                    txtDDD.Text = "";

                cmbRegião.SelectedItem = localidade.Região;

                optDesconhecido.Checked = localidade.Tipo == TipoLocalidade.Desconhecido;
                optDistrito.Checked = localidade.Tipo == TipoLocalidade.Distrito;
                optMunicípio.Checked = localidade.Tipo == TipoLocalidade.Município;
                optPovoado.Checked = localidade.Tipo == TipoLocalidade.Povoado;
                optRegião.Checked = localidade.Tipo == TipoLocalidade.RegiãoAdministrativa;
            }
        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = txtNome.Text.Trim().Length == 0;
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            localidade.Nome = txtNome.Text.Trim();
        }

        private void cmbEstado_Validated(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedValue != null)
            {
                localidade.Estado = Estado.ObterEstado(ulong.Parse((string)cmbEstado.SelectedValue));
            }
        }

        private void txtDDD_Validated(object sender, EventArgs e)
        {
            if (txtDDD.Text.Length > 0)
                localidade.DDD = (uint)txtDDD.Int;
            else
                localidade.DDD = null;
        }

        private void cmbRegião_Validated(object sender, EventArgs e)
        {
            localidade.Região = cmbRegião.SelectedItem as Região;

            /* Verifica se o usuário na verdade não deseja
             * atribuir a região do estado, diferente de uma
             * região específica para a localidade, mesmo que
             * no momento sejam as mesmas.
             */
            if (localidade.Região != null && localidade.Estado != null
                && localidade.Estado.Região != null
                && localidade.Região.Código == localidade.Estado.Região.Código)
            {
                if (MessageBox.Show(this,
                    "A região que você escolheu para esta localidade é a mesma escolhida para o estado.\n\n"
                    + "Se posteriormente a região do estado for alterada, esta alteração não se refletirá na localidade, pois você atribuiu uma região específica para o estado, mesmo que neste momento elas sejam as mesmas.\n\n"
                    + "Deseja mesmo atribuir a região para esta localidade?",
                    "Atribuição de região para localidade",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    localidade.Região = null;
                    cmbRegião.SelectedItem = strMesma;

                    MessageBox.Show(this,
                        "A região para esta localidade foi alterada para que seja sempre a mesma do estado.\n\n",
                        "Atribuição de região para localidade",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void optDesconhecido_CheckedChanged(object sender, EventArgs e)
        {
            if (optDesconhecido.Checked)
                localidade.Tipo = TipoLocalidade.Desconhecido;
        }

        private void optMunicípio_CheckedChanged(object sender, EventArgs e)
        {
            if (optMunicípio.Checked)
                localidade.Tipo = TipoLocalidade.Município;
        }

        private void optDistrito_CheckedChanged(object sender, EventArgs e)
        {
            if (optDistrito.Checked)
                localidade.Tipo = TipoLocalidade.Distrito;
        }

        private void optPovoado_CheckedChanged(object sender, EventArgs e)
        {
            if (optPovoado.Checked)
                localidade.Tipo = TipoLocalidade.Povoado;
        }

        private void optRegião_CheckedChanged(object sender, EventArgs e)
        {
            if (optRegião.Checked)
                localidade.Tipo = TipoLocalidade.RegiãoAdministrativa;
        }

        private void CarregarDados()
        {
            AguardeDB.Mostrar();

            dsEstado.Clear();

            // DataSet "Estado"
            IDbConnection conexão;
            DbDataAdapter adapPaís, adapEstado;

            conexão = Usuários.UsuárioAtual.Conexão;

            lock (conexão)
            {
                dsEstado.Clear();
                adapPaís = Usuários.UsuárioAtual.CriarAdaptadorDados(conexão, "SELECT codigo, nome FROM pais");
                adapPaís.Fill(dsEstado.País);

                adapEstado = Usuários.UsuárioAtual.CriarAdaptadorDados(conexão, "SELECT codigo, pais, nome FROM estado");
                adapEstado.Fill(dsEstado._Estado);
            }

            // Campo "Região"
            cmbRegião.Items.Add(strMesma);
            cmbRegião.Items.AddRange(Região.ObterRegiões());

            cmbRegião.SelectedItem = strMesma;

            if (localidade != null && cmbEstado.SelectedItem != null)
                localidade.Estado = Estado.ObterEstado(ulong.Parse((string)cmbEstado.SelectedValue));

            AguardeDB.Fechar();
        }

        private void btnAdicionarPaís_Click(object sender, EventArgs e)
        {
            País país = new País();

            if (paísOriginal != null)
                país.Nome = paísOriginal;

            using (EditarPaís dlg = new EditarPaís(país))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    try
                    {
                        dlg.País.Cadastrar();
                    }
                    catch
                    {
                        MessageBox.Show(
                            this,
                            "Não foi possível cadastrar o país.",
                            "Cadastro de país",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        AguardeDB.Fechar();

                        return;
                    }

                    CarregarDados();

                    cmbPaís.SelectedIndex = cmbPaís.FindStringExact(dlg.País.Nome);

                    localidade.Estado = null;

                    AguardeDB.Fechar();
                }
            }
        }

        private void btnAdicionarEstado_Click(object sender, EventArgs e)
        {
            Estado estado = new Estado();

            if (estadoOriginal != null)
                estado.Nome = estadoOriginal;

            estado.País = cmbPaís.SelectedItem as País;

            using (EditarEstado dlg = new EditarEstado(estado))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    try
                    {
                        dlg.Estado.Cadastrar();
                    }
                    catch
                    {
                        MessageBox.Show(
                            this,
                            "Não foi possível cadastrar o estado.",
                            "Cadastro de estado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        AguardeDB.Fechar();

                        return;
                    }

                    CarregarDados();

                    cmbPaís.SelectedIndex = cmbPaís.FindStringExact(dlg.Estado.País.Nome);
                    cmbEstado.SelectedIndex = cmbEstado.FindStringExact(dlg.Estado.Nome);

                    localidade.Estado = dlg.Estado;

                    AguardeDB.Fechar();
                }
            }
        }

        private void btnAdicionarRegião_Click(object sender, EventArgs e)
        {
            using (EditarRegião dlg = new EditarRegião())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    try
                    {
                        dlg.Região.Cadastrar();
                    }
                    catch
                    {
                        MessageBox.Show(
                            this,
                            "Não foi possível cadastrar a região.",
                            "Cadastro de região",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        AguardeDB.Fechar();
                        return;
                    }

                    cmbRegião.Items.Add(dlg.Região);
                    cmbRegião.SelectedItem = dlg.Região;

                    AguardeDB.Fechar();
                }
            }
        }

        private void EditarLocalidade_Shown(object sender, EventArgs e)
        {
            if (localidade.Estado != null && localidade.Estado.Cadastrado)
            {
                cmbPaís.Text = localidade.Estado.País.Nome;
                cmbEstado.Text = localidade.Estado.Nome;
            }
        }
    }
}

