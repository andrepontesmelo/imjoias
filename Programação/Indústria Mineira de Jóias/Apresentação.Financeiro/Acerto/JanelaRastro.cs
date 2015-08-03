using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;
using Apresenta��o.Impress�o.Relat�rios.Retorno;
using Apresenta��o.Impress�o.Relat�rios.Sa�da;
using Apresenta��o.Impress�o.Relat�rios.Venda;

namespace Apresenta��o.Financeiro.Acerto
{
    public partial class JanelaRastro : Apresenta��o.Formul�rios.JanelaExplicativa
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

        public void Abrir(Entidades.Mercadoria.Mercadoria mercadoria, Entidades.Acerto.ControleAcertoMercadorias acerto, Form formul�rioPai)
        {
            lstRastro.Abrir(mercadoria, acerto);
            lblT�tulo.Text = mercadoria.Refer�ncia;

            if (mercadoria.DePeso)
                lblT�tulo.Text += ", Peso = " + mercadoria.PesoFormatado;

            lblDescri��o.Text = "Rastro desta mercadoria para " + acerto.Pessoa.PrimeiroNome + ". Em ordem cronol�gica, � possivel conferir em quais documentos ela est� relacionada."; 

            Show(formul�rioPai);
        }

        /// <summary>
        /// Abre documento impresso
        /// </summary>
        private void AbrirImpress�o()
        {
            Apresenta��o.Formul�rios.AguardeDB.Mostrar();
            UseWaitCursor = true;
            RastroItem rastro = lstRastro.Selecionado;
            Entidades.Relacionamento.Relacionamento relacionamento = rastro.ObterRelacionamento();
            Apresenta��o.Financeiro.Impress�o janela = new Apresenta��o.Financeiro.Impress�o();
            janela.T�tulo = "Vizualiza��o de documentos";
            janela.Descri��o = "";
            CrystalDecisions.CrystalReports.Engine.ReportClass documento;

            switch (rastro.Tipo)
            {
                case RastroItem.TipoEnum.Venda:
                    //documento = new Apresenta��o.Impress�o.Relat�rios.Venda.Relat�rio();
                    //documento.SetDataSource(relacionamento.ObterImpress�o());
                    {
                        Apresenta��o.Impress�o.Relat�rios.Venda.ControleImpress�oVenda controle = new Apresenta��o.Impress�o.Relat�rios.Venda.ControleImpress�oVenda();
                        Entidades.Relacionamento.Venda.Venda venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(relacionamento.C�digo);

                        documento = new Apresenta��o.Impress�o.Relat�rios.Venda.Relat�rio();

                        controle.PrepararImpress�o(documento, venda);
                        janela.InserirDocumento(documento, "Venda", relacionamento);
                    }
                    break;

                case RastroItem.TipoEnum.Sa�da:
                    //documento = new Apresenta��o.Impress�o.Relat�rios.Sa�da.Relat�rio();
                    //documento.SetDataSource(relacionamento.ObterImpress�o());
                    {
                        Apresenta��o.Impress�o.Relat�rios.Sa�da.ControleImpress�oSa�da controle = new Apresenta��o.Impress�o.Relat�rios.Sa�da.ControleImpress�oSa�da();
                        Entidades.Relacionamento.Sa�da.Sa�da sa�da = Entidades.Relacionamento.Sa�da.Sa�da.ObterSa�da(relacionamento.C�digo);

                        documento = new Apresenta��o.Impress�o.Relat�rios.Sa�da.Relat�rio();

                        controle.PrepararImpress�o(documento, sa�da);
                        janela.InserirDocumento(documento, "Sa�da", relacionamento);
                    }
                    break;

                case RastroItem.TipoEnum.Retorno:
                    //documento = new Apresenta��o.Impress�o.Relat�rios.Retorno.Relat�rio();
                    //documento.SetDataSource(relacionamento.ObterImpress�o());
                    {
                        Apresenta��o.Impress�o.Relat�rios.Retorno.ControleImpress�oRetorno controle = new Apresenta��o.Impress�o.Relat�rios.Retorno.ControleImpress�oRetorno();
                        Entidades.Relacionamento.Retorno.Retorno retorno = Entidades.Relacionamento.Retorno.Retorno.ObterRetorno(relacionamento.C�digo);

                        documento = new Apresenta��o.Impress�o.Relat�rios.Retorno.Relat�rio();

                        controle.PrepararImpress�o(documento, retorno);
                        janela.InserirDocumento(documento, "Retorno", relacionamento);
                    }
                    break;
                default:
                    throw new Exception("Tipo inexistente");
            }

            Apresenta��o.Formul�rios.AguardeDB.Fechar();
            UseWaitCursor = false;

            janela.Abrir(this);
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            AbrirImpress�o();
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
            //AbrirImpress�o();
            AbrirEdi��o();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AbrirEdi��o();
        }

        private void AbrirEdi��o()
        {
            if (EditarDocumento != null)
            {
                if (lstRastro.Selecionado == null)
                    MessageBox.Show(
                        this,
                        "Por favor, selecione antes o documento a ser editado.",
                        "Edi��o de documento",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    EditarDocumento(this, lstRastro.Selecionado);
                    Close();
                }
            }
            else
                throw new NotImplementedException("N�o � poss�vel abrir edi��o porque ningu�m observa este evento.");
        }
    }
}

