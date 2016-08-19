using Apresentação.Formulários;
using Apresentação.Mercadoria;
using Entidades;
using Entidades.Configuração;
using Entidades.Moedas;
using Entidades.Pessoa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    public partial class ConsultaMercadoria : JanelaExplicativa
    {
        private ConfiguraçãoUsuário<uint> configuração = null;

        public ConsultaMercadoria()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            configuração = new ConfiguraçãoUsuário<uint>("ÚltimaTabelaConsulta", Tabela.TabelaPadrão.Código);
            cmbTabela.Seleção = Tabela.ObterTabela(configuração.Valor);
        }

        private Tabela ObterTabelaPadrão()
        {
            List<Tabela> tabelas = Tabela.ObterTabelas(Funcionário.FuncionárioAtual.Setor);

            if (tabelas.Count == 0)
                return Tabela.TabelaPadrão;
            else
                return cmbTabela.Seleção = tabelas[0];
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtMercadoria.Mercadoria == null)
            {
                MessageBox.Show(this,
                    "A mercadoria digitada não encontra-se cadastrada.",
                    "Mercadoria não cadastrada",
                    MessageBoxButtons.OK);

                return;
            }

            configuração.Valor = cmbTabela.Seleção.Código;

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
                            "O coeficiente desta mercadoria nesta tabela é nulo ou negativo.",
                            Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (NullReferenceException)
                {
                    AguardeDB.Suspensão(true);

                    MessageBox.Show(
                        this,
                        "Não existe preço para esta mercadoria nesta tabela.",
                        Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AguardeDB.Suspensão(false);

                    return;
                }

                if (cmbTabela.Text == "Atacado")
                {
                    InformaçõesMercadoriaResumo janelaInformações
                        = new InformaçõesMercadoriaResumo(txtMercadoria.Mercadoria, txtCotação.Cotação);

                    Hide();

                    janelaInformações.Fechando += new EventHandler(janelaInformações_Fechando);
                    janelaInformações.Show();
                    janelaInformações.Focus();
                }
                else
                {
                    InformaçõesMercadoria janelaInformações
                        = new InformaçõesMercadoria(txtMercadoria.Mercadoria, txtCotação.Cotação);

                    Hide();

                    janelaInformações.Fechando += new EventHandler(janelaInformações_Fechando);
                    janelaInformações.Show();
                    janelaInformações.Focus();
                }
            }
            finally
            {
                UseWaitCursor = false;
                AguardeDB.Fechar();
            }
        }

        private void janelaInformações_Fechando(object sender, EventArgs args)
        {
            try
            {
                Show();

                txtMercadoria.Referência = "";
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

        private void txtMercadoria_ReferênciaConfirmada(object sender, EventArgs e)
        {
            Entidades.Mercadoria.Mercadoria m = txtMercadoria.Mercadoria;
            
            if (m != null)
            {
                txtPeso.Enabled = m.DePeso;
                btnConsultar.Enabled = true;

                if (m.DePeso && txtMercadoria.DigitaçãoManual)
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

        private void lnkHistóricoCotações_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Indicadores.JanelaHistóricoCotação histórico = new Indicadores.JanelaHistóricoCotação(
                cmbTabela.Seleção != null ? cmbTabela.Seleção.Moeda : MoedaObtenção.Instância.ObterMoeda(MoedaSistema.Ouro));

            histórico.Show(Owner);
        }

        private void linkPesquisaAvançada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            txtCotação.SelecionarPrimeiro();
        }
    }
}