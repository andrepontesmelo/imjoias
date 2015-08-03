using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endere�o;
using Apresenta��o.Formul�rios;
using Acesso.Comum;
using System.Data.Common;

namespace Apresenta��o.Pessoa.Endere�o
{
    /// <summary>
    /// Janela para edi��o de localidade.
    /// </summary>
    public partial class EditarLocalidade : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private Localidade localidade;
        private string estadoOriginal, pa�sOriginal;

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
                        pa�sOriginal = localidade.Estado.Pa�s != null ? localidade.Estado.Pa�s.Nome : null;
                    }
                    else
                    {
                        cmbPa�s.Text = localidade.Estado.Pa�s.Nome;
                        cmbEstado.Text = localidade.Estado.Nome;
                    }
                }
                else if (cmbEstado.SelectedItem != null)
                    localidade.Estado = Estado.ObterEstado(ulong.Parse((string)cmbEstado.SelectedValue));

                if (value.DDD.HasValue)
                    txtDDD.Int = (int)value.DDD;
                else
                    txtDDD.Text = "";

                cmbRegi�o.SelectedItem = localidade.Regi�o;

                optDesconhecido.Checked = localidade.Tipo == TipoLocalidade.Desconhecido;
                optDistrito.Checked = localidade.Tipo == TipoLocalidade.Distrito;
                optMunic�pio.Checked = localidade.Tipo == TipoLocalidade.Munic�pio;
                optPovoado.Checked = localidade.Tipo == TipoLocalidade.Povoado;
                optRegi�o.Checked = localidade.Tipo == TipoLocalidade.Regi�oAdministrativa;
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

        private void cmbRegi�o_Validated(object sender, EventArgs e)
        {
            localidade.Regi�o = cmbRegi�o.SelectedItem as Regi�o;

            /* Verifica se o usu�rio na verdade n�o deseja
             * atribuir a regi�o do estado, diferente de uma
             * regi�o espec�fica para a localidade, mesmo que
             * no momento sejam as mesmas.
             */
            if (localidade.Regi�o != null && localidade.Estado != null
                && localidade.Estado.Regi�o != null
                && localidade.Regi�o.C�digo == localidade.Estado.Regi�o.C�digo)
            {
                if (MessageBox.Show(this,
                    "A regi�o que voc� escolheu para esta localidade � a mesma escolhida para o estado.\n\n"
                    + "Se posteriormente a regi�o do estado for alterada, esta altera��o n�o se refletir� na localidade, pois voc� atribuiu uma regi�o espec�fica para o estado, mesmo que neste momento elas sejam as mesmas.\n\n"
                    + "Deseja mesmo atribuir a regi�o para esta localidade?",
                    "Atribui��o de regi�o para localidade",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    localidade.Regi�o = null;
                    cmbRegi�o.SelectedItem = strMesma;

                    MessageBox.Show(this,
                        "A regi�o para esta localidade foi alterada para que seja sempre a mesma do estado.\n\n",
                        "Atribui��o de regi�o para localidade",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void optDesconhecido_CheckedChanged(object sender, EventArgs e)
        {
            if (optDesconhecido.Checked)
                localidade.Tipo = TipoLocalidade.Desconhecido;
        }

        private void optMunic�pio_CheckedChanged(object sender, EventArgs e)
        {
            if (optMunic�pio.Checked)
                localidade.Tipo = TipoLocalidade.Munic�pio;
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

        private void optRegi�o_CheckedChanged(object sender, EventArgs e)
        {
            if (optRegi�o.Checked)
                localidade.Tipo = TipoLocalidade.Regi�oAdministrativa;
        }

        private void CarregarDados()
        {
            AguardeDB.Mostrar();

            dsEstado.Clear();

            // DataSet "Estado"
            IDbConnection conex�o;
            DbDataAdapter adapPa�s, adapEstado;

            conex�o = Usu�rios.Usu�rioAtual.Conex�o;

            lock (conex�o)
            {
                dsEstado.Clear();
                adapPa�s = Usu�rios.Usu�rioAtual.CriarAdaptadorDados(conex�o, "SELECT codigo, nome FROM pais");
                adapPa�s.Fill(dsEstado.Pa�s);

                adapEstado = Usu�rios.Usu�rioAtual.CriarAdaptadorDados(conex�o, "SELECT codigo, pais, nome FROM estado");
                adapEstado.Fill(dsEstado._Estado);
            }

            // Campo "Regi�o"
            cmbRegi�o.Items.Add(strMesma);
            cmbRegi�o.Items.AddRange(Regi�o.ObterRegi�es());

            cmbRegi�o.SelectedItem = strMesma;

            if (localidade != null && cmbEstado.SelectedItem != null)
                localidade.Estado = Estado.ObterEstado(ulong.Parse((string)cmbEstado.SelectedValue));

            AguardeDB.Fechar();
        }

        private void btnAdicionarPa�s_Click(object sender, EventArgs e)
        {
            Pa�s pa�s = new Pa�s();

            if (pa�sOriginal != null)
                pa�s.Nome = pa�sOriginal;

            using (EditarPa�s dlg = new EditarPa�s(pa�s))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    try
                    {
                        dlg.Pa�s.Cadastrar();
                    }
                    catch
                    {
                        MessageBox.Show(
                            this,
                            "N�o foi poss�vel cadastrar o pa�s.",
                            "Cadastro de pa�s",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        AguardeDB.Fechar();

                        return;
                    }

                    CarregarDados();

                    cmbPa�s.SelectedIndex = cmbPa�s.FindStringExact(dlg.Pa�s.Nome);

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

            estado.Pa�s = cmbPa�s.SelectedItem as Pa�s;

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
                            "N�o foi poss�vel cadastrar o estado.",
                            "Cadastro de estado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        AguardeDB.Fechar();

                        return;
                    }

                    CarregarDados();

                    cmbPa�s.SelectedIndex = cmbPa�s.FindStringExact(dlg.Estado.Pa�s.Nome);
                    cmbEstado.SelectedIndex = cmbEstado.FindStringExact(dlg.Estado.Nome);

                    localidade.Estado = dlg.Estado;

                    AguardeDB.Fechar();
                }
            }
        }

        private void btnAdicionarRegi�o_Click(object sender, EventArgs e)
        {
            using (EditarRegi�o dlg = new EditarRegi�o())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AguardeDB.Mostrar();

                    try
                    {
                        dlg.Regi�o.Cadastrar();
                    }
                    catch
                    {
                        MessageBox.Show(
                            this,
                            "N�o foi poss�vel cadastrar a regi�o.",
                            "Cadastro de regi�o",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        AguardeDB.Fechar();
                        return;
                    }

                    cmbRegi�o.Items.Add(dlg.Regi�o);
                    cmbRegi�o.SelectedItem = dlg.Regi�o;

                    AguardeDB.Fechar();
                }
            }
        }

        private void EditarLocalidade_Shown(object sender, EventArgs e)
        {
            if (localidade.Estado != null && localidade.Estado.Cadastrado)
            {
                cmbPa�s.Text = localidade.Estado.Pa�s.Nome;
                cmbEstado.Text = localidade.Estado.Nome;
            }
        }
    }
}

