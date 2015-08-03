using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Mercadoria;
using Entidades.Configura��o;
using Entidades;
using Entidades.Pessoa;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Financeiro
{
    public partial class ConsultaMercadoria : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public ConsultaMercadoria()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Tabela[] tabelas = Tabela.ObterTabelas(Funcion�rio.Funcion�rioAtual.Setor);

            if (tabelas.Length == 0)
                cmbTabela.Sele��o = Tabela.TabelaPadr�o;
            else
                cmbTabela.Sele��o = tabelas[0];
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //cmbTabela
            if (txtMercadoria.Mercadoria == null)
            {
                MessageBox.Show(this,
                    "A mercadoria digitada n�o encontra-se cadastrada.",
                    "Mercadoria n�o cadastrada",
                    MessageBoxButtons.OK);

                return;
            }

            UseWaitCursor = true;

            Apresenta��o.Formul�rios.AguardeDB.Mostrar();

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
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }

            /* A janela de consulta n�o escondia e, portanto,
             * agora ela � fechada. De qualquer maneira, acredito
             * que uma consulta de pre�o possa ser uma tarefa
             * executada em cima de um trabalho em andamento
             * (principalmente no cofre, mas n�o no atendimento)
             * e, portanto, pode ser fechada logo ap�s o uso.
             * 
             * J�lio, 08/03/2006
             */

            /* Foi solicitado em maio/2005 que a janela de consulta volte 
             * a aparecer logo depois do fechamento da tela de informa��es.
             * 
             * Andr�, 15/05/2006
             */
            // Close();
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
            Indicadores.JanelaHist�ricoCota��o hist�rico = new Apresenta��o.Financeiro.Indicadores.JanelaHist�ricoCota��o(
                cmbTabela.Sele��o != null ? cmbTabela.Sele��o.Moeda : Entidades.Moeda.ObterMoeda(Entidades.Moeda.MoedaSistema.Ouro));

            hist�rico.Show(Owner);
        }

        private void cmbTabela_AoSelecionar(ComboTabela sender, Tabela moeda)
        {
            // Necess�rio para que a mudan�a de tabela atualize a txtCota��o
            txtCota��o.Valor = 0;

            txtCota��o.Moeda = moeda.Moeda;
        }

        private void linkPesquisaAvan�ada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

