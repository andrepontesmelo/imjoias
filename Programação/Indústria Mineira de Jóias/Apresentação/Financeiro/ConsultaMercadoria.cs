using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Mercadoria;
using Entidades.Configuração;
using Entidades;
using Entidades.Pessoa;
using Apresentação.Formulários;

namespace Apresentação.Financeiro
{
    public partial class ConsultaMercadoria : Apresentação.Formulários.JanelaExplicativa
    {
        public ConsultaMercadoria()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Tabela[] tabelas = Tabela.ObterTabelas(Funcionário.FuncionárioAtual.Setor);

            if (tabelas.Length == 0)
                cmbTabela.Seleção = Tabela.TabelaPadrão;
            else
                cmbTabela.Seleção = tabelas[0];
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //cmbTabela
            if (txtMercadoria.Mercadoria == null)
            {
                MessageBox.Show(this,
                    "A mercadoria digitada não encontra-se cadastrada.",
                    "Mercadoria não cadastrada",
                    MessageBoxButtons.OK);

                return;
            }

            UseWaitCursor = true;

            Apresentação.Formulários.AguardeDB.Mostrar();

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
                Apresentação.Formulários.AguardeDB.Fechar();
            }

            /* A janela de consulta não escondia e, portanto,
             * agora ela é fechada. De qualquer maneira, acredito
             * que uma consulta de preço possa ser uma tarefa
             * executada em cima de um trabalho em andamento
             * (principalmente no cofre, mas não no atendimento)
             * e, portanto, pode ser fechada logo após o uso.
             * 
             * Júlio, 08/03/2006
             */

            /* Foi solicitado em maio/2005 que a janela de consulta volte 
             * a aparecer logo depois do fechamento da tela de informações.
             * 
             * André, 15/05/2006
             */
            // Close();
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
            Indicadores.JanelaHistóricoCotação histórico = new Apresentação.Financeiro.Indicadores.JanelaHistóricoCotação(
                cmbTabela.Seleção != null ? cmbTabela.Seleção.Moeda : Entidades.Moeda.ObterMoeda(Entidades.Moeda.MoedaSistema.Ouro));

            histórico.Show(Owner);
        }

        private void cmbTabela_AoSelecionar(ComboTabela sender, Tabela moeda)
        {
            // Necessário para que a mudança de tabela atualize a txtCotação
            txtCotação.Valor = 0;

            txtCotação.Moeda = moeda.Moeda;
        }

        private void linkPesquisaAvançada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PesquisaMercadoria pesquisa = new PesquisaMercadoria();
            pesquisa.Show();
            Close();
        }

        private void ConsultaMercadoria_Load(object sender, EventArgs e)
        {

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
    }

}

