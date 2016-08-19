using Apresenta��o.Formul�rios;
using Apresenta��o.Mercadoria;
using Entidades;
using Entidades.Configura��o;
using Entidades.Moedas;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro
{
    public partial class ConsultaMercadoria : JanelaExplicativa
    {
        private Configura��oUsu�rio<uint> configura��o = null;

        public ConsultaMercadoria()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            configura��o = new Configura��oUsu�rio<uint>("�ltimaTabelaConsulta", Tabela.TabelaPadr�o.C�digo);
            cmbTabela.Sele��o = Tabela.ObterTabela(configura��o.Valor);
        }

        private Tabela ObterTabelaPadr�o()
        {
            List<Tabela> tabelas = Tabela.ObterTabelas(Funcion�rio.Funcion�rioAtual.Setor);

            if (tabelas.Count == 0)
                return Tabela.TabelaPadr�o;
            else
                return cmbTabela.Sele��o = tabelas[0];
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtMercadoria.Mercadoria == null)
            {
                MessageBox.Show(this,
                    "A mercadoria digitada n�o encontra-se cadastrada.",
                    "Mercadoria n�o cadastrada",
                    MessageBoxButtons.OK);

                return;
            }

            configura��o.Valor = cmbTabela.Sele��o.C�digo;

            UseWaitCursor = true;

            AguardeDB.Mostrar();

            try
            {
                try
                {
                    double teste = txtMercadoria.Mercadoria.Coeficiente;

                    if (teste <= 0)
                        MessageBox.Show(
                            this,
                            "O coeficiente desta mercadoria nesta tabela � nulo ou negativo.",
                            Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (NullReferenceException)
                {
                    AguardeDB.Suspens�o(true);

                    MessageBox.Show(
                        this,
                        "N�o existe pre�o para esta mercadoria nesta tabela.",
                        Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AguardeDB.Suspens�o(false);

                    return;
                }

                if (cmbTabela.Text == "Atacado")
                {
                    Informa��esMercadoriaResumo janelaInforma��es
                        = new Informa��esMercadoriaResumo(txtMercadoria.Mercadoria, txtCota��o.Cota��o);

                    Hide();

                    janelaInforma��es.Fechando += new EventHandler(janelaInforma��es_Fechando);
                    janelaInforma��es.Show();
                    janelaInforma��es.Focus();
                }
                else
                {
                    Informa��esMercadoria janelaInforma��es
                        = new Informa��esMercadoria(txtMercadoria.Mercadoria, txtCota��o.Cota��o);

                    Hide();

                    janelaInforma��es.Fechando += new EventHandler(janelaInforma��es_Fechando);
                    janelaInforma��es.Show();
                    janelaInforma��es.Focus();
                }
            }
            finally
            {
                UseWaitCursor = false;
                AguardeDB.Fechar();
            }
        }

        private void janelaInforma��es_Fechando(object sender, EventArgs args)
        {
            try
            {
                Show();

                txtMercadoria.Refer�ncia = "";
                txtPeso.Text = "";
                txtMercadoria.Txt.Focus();
            }
            catch
            {
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void txtMercadoria_Refer�nciaConfirmada(object sender, EventArgs e)
        {
            Entidades.Mercadoria.Mercadoria m = txtMercadoria.Mercadoria;
            
            if (m != null)
            {
                txtPeso.Enabled = m.DePeso;
                btnConsultar.Enabled = true;

                if (m.DePeso && txtMercadoria.Digita��oManual)
                    txtPeso.Focus();
                else
                {
                    btnConsultar.Focus();
                    btnConsultar_Click(sender, e);
                }
            } else
                btnConsultar.Enabled = false;
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConsultar.Focus();
        }

        private void ConsultaMercadoria_Shown(object sender, EventArgs e)
        {
            txtMercadoria.Txt.SelectAll();
            txtMercadoria.Txt.Focus();
        }

        private void lnkHist�ricoCota��es_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Indicadores.JanelaHist�ricoCota��o hist�rico = new Indicadores.JanelaHist�ricoCota��o(
                cmbTabela.Sele��o != null ? cmbTabela.Sele��o.Moeda : MoedaObten��o.Inst�ncia.ObterMoeda(MoedaSistema.Ouro));

            hist�rico.Show(Owner);
        }

        private void linkPesquisaAvan�ada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PesquisaMercadoria pesquisa = new PesquisaMercadoria();
            pesquisa.ShowDialog(ParentForm);
        }

        private void ConsultaMercadoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void txtMercadoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void txtMercadoria_EscPressionado(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbTabela_AoSelecionar(ComboTabela sender, Tabela moeda)
        {
            txtCota��o.SelecionarPrimeiro();
        }
    }
}