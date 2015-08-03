using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;
using Apresentação.Impressão.Relatórios.Retorno;
using Apresentação.Impressão.Relatórios.Saída;
using Apresentação.Impressão.Relatórios.Venda;

namespace Apresentação.Financeiro.Acerto
{
    public partial class JanelaRastro : Apresentação.Formulários.JanelaExplicativa
    {
        // Eventos
        public delegate void EditarDocumentoDelegate(JanelaRastro janela, RastroItem rastroItem);
        public EditarDocumentoDelegate EditarDocumento;

        public JanelaRastro()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Abrir(Entidades.Mercadoria.Mercadoria mercadoria, Entidades.Acerto.ControleAcertoMercadorias acerto, Form formulárioPai)
        {
            lstRastro.Abrir(mercadoria, acerto);
            lblTítulo.Text = mercadoria.Referência;

            if (mercadoria.DePeso)
                lblTítulo.Text += ", Peso = " + mercadoria.PesoFormatado;

            lblDescrição.Text = "Rastro desta mercadoria para " + acerto.Pessoa.PrimeiroNome + ". Em ordem cronológica, é possivel conferir em quais documentos ela está relacionada."; 

            Show(formulárioPai);
        }

        /// <summary>
        /// Abre documento impresso
        /// </summary>
        private void AbrirImpressão()
        {
            Apresentação.Formulários.AguardeDB.Mostrar();
            UseWaitCursor = true;
            RastroItem rastro = lstRastro.Selecionado;
            Entidades.Relacionamento.Relacionamento relacionamento = rastro.ObterRelacionamento();
            Apresentação.Financeiro.Impressão janela = new Apresentação.Financeiro.Impressão();
            janela.Título = "Vizualização de documentos";
            janela.Descrição = "";
            CrystalDecisions.CrystalReports.Engine.ReportClass documento;

            switch (rastro.Tipo)
            {
                case RastroItem.TipoEnum.Venda:
                    //documento = new Apresentação.Impressão.Relatórios.Venda.Relatório();
                    //documento.SetDataSource(relacionamento.ObterImpressão());
                    {
                        Apresentação.Impressão.Relatórios.Venda.ControleImpressãoVenda controle = new Apresentação.Impressão.Relatórios.Venda.ControleImpressãoVenda();
                        Entidades.Relacionamento.Venda.Venda venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(relacionamento.Código);

                        documento = new Apresentação.Impressão.Relatórios.Venda.Relatório();

                        controle.PrepararImpressão(documento, venda);
                        janela.InserirDocumento(documento, "Venda", relacionamento);
                    }
                    break;

                case RastroItem.TipoEnum.Saída:
                    //documento = new Apresentação.Impressão.Relatórios.Saída.Relatório();
                    //documento.SetDataSource(relacionamento.ObterImpressão());
                    {
                        Apresentação.Impressão.Relatórios.Saída.ControleImpressãoSaída controle = new Apresentação.Impressão.Relatórios.Saída.ControleImpressãoSaída();
                        Entidades.Relacionamento.Saída.Saída saída = Entidades.Relacionamento.Saída.Saída.ObterSaída(relacionamento.Código);

                        documento = new Apresentação.Impressão.Relatórios.Saída.Relatório();

                        controle.PrepararImpressão(documento, saída);
                        janela.InserirDocumento(documento, "Saída", relacionamento);
                    }
                    break;

                case RastroItem.TipoEnum.Retorno:
                    //documento = new Apresentação.Impressão.Relatórios.Retorno.Relatório();
                    //documento.SetDataSource(relacionamento.ObterImpressão());
                    {
                        Apresentação.Impressão.Relatórios.Retorno.ControleImpressãoRetorno controle = new Apresentação.Impressão.Relatórios.Retorno.ControleImpressãoRetorno();
                        Entidades.Relacionamento.Retorno.Retorno retorno = Entidades.Relacionamento.Retorno.Retorno.ObterRetorno(relacionamento.Código);

                        documento = new Apresentação.Impressão.Relatórios.Retorno.Relatório();

                        controle.PrepararImpressão(documento, retorno);
                        janela.InserirDocumento(documento, "Retorno", relacionamento);
                    }
                    break;
                default:
                    throw new Exception("Tipo inexistente");
            }

            Apresentação.Formulários.AguardeDB.Fechar();
            UseWaitCursor = false;

            janela.Abrir(this);
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            AbrirImpressão();
        }

        private void lstRastro_ItemDeselecionado(object sender, EventArgs e)
        {
            btnEditar.Enabled = btnExibir.Enabled = false;
        }

        private void lstRastro_ItemSelecionado(object sender, EventArgs e)
        {
            btnEditar.Enabled = btnExibir.Enabled = true;
        }

        private void lstRastro_DuploClique(object sender, EventArgs e)
        {
            //AbrirImpressão();
            AbrirEdição();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirEdição();
        }

        private void AbrirEdição()
        {
            if (EditarDocumento != null)
            {
                if (lstRastro.Selecionado == null)
                    MessageBox.Show(
                        this,
                        "Por favor, selecione antes o documento a ser editado.",
                        "Edição de documento",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    EditarDocumento(this, lstRastro.Selecionado);
                    Close();
                }
            }
            else
                throw new NotImplementedException("Não é possível abrir edição porque ninguém observa este evento.");
        }
    }
}

