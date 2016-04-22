using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Apresenta��o.Impress�o.Relat�rios.Venda;
using Entidades.Relacionamento.Venda;

namespace Apresenta��o.Financeiro.Venda
{
    public partial class ListarVendas : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        /// <summary>
        /// Controlador da base inferior.
        /// </summary>
        private ControladorBaseInferior controlador;

        public ListarVendas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constr�i a lista de vendas mostrando um
        /// vetor de vendas.
        /// </summary>
        /// <param name="vendas">Vetor de vendas a ser exibido.</param>
        public ListarVendas(IDadosVenda[] vendas, V�nculoVendaPessoa tipo)
            : this()
        {
            if (vendas.Length != 0)
            {
                switch (tipo)
                {
                    case V�nculoVendaPessoa.Cliente:
                        lblDescri��o.Text = "Abaixo est�o as compras de " + vendas[0].NomeCliente;
                        break;
                    case V�nculoVendaPessoa.Vendedor:
                        lblDescri��o.Text = "Abaixo est�o as vendas de " + Entidades.Pessoa.Pessoa.ReduzirNome(vendas[0].NomeVendedor);
                        break;
                    default:
                        lblDescri��o.Text = "Listagem das vendas";
                        break;
                }
                
                lista.TipoExibi��o = tipo;
                lista.Carregar(vendas);
            }
        }

        /// <summary>
        /// Constr�i a lista de vendas mostrando um
        /// vetor de vendas.
        /// </summary>
        /// <param name="controlador">
        /// Controlador da base inferior que ser� utilizada para
        /// exibir a base de visualiza��o de vendas.
        /// </param>
        /// <param name="vendas">Vetor de vendas a ser exibido.</param>
        public ListarVendas(ControladorBaseInferior controlador, IDadosVenda[] vendas, V�nculoVendaPessoa tipo)
            : this(vendas, tipo)
        {
            this.controlador = controlador;
            btnVisualizar.Visible = true;
        }

        /// <summary>
        /// Ocorre ao clicar em OK.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ocorre ao clicar em visualizar.
        /// </summary>
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Entidades.Relacionamento.Venda.Venda venda;

            if (!lista.ItemSelecionado.HasValue)
            {
                MessageBox.Show(
                    this,
                    "Por favor, selecione uma venda para que ela seja exibida.",
                    "Visualiza��o de venda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }
            else
                venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(lista.ItemSelecionado.Value);

            JanelaImpress�o janela = new JanelaImpress�o();
            Relat�rio relat�rioVenda = new Relat�rio();
            ControleImpress�oVenda controle = new ControleImpress�oVenda();

            controle.PrepararImpress�o(relat�rioVenda, venda);

            janela.InserirDocumento(relat�rioVenda, "Venda #" + (venda.Controle.HasValue ? venda.Controle.Value.ToString() : venda.C�digoFormatado.ToString() + " (c�d interno)"));
            janela.Abrir(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Entidades.Relacionamento.Venda.Venda venda;
            UseWaitCursor = true;

            if (!lista.ItemSelecionado.HasValue)
            {
                MessageBox.Show(
                    this,
                    "Por favor, selecione uma venda para que ela seja exibida.",
                    "Visualiza��o de venda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }
            else
                venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(lista.ItemSelecionado.Value);

            BaseEditarVenda baseEditar = new BaseEditarVenda();
            baseEditar.Abrir(venda);

            controlador.SubstituirBaseArbitrariamente(
                baseEditar,
                "Visualiza��o de venda",
                venda.Controle.ToString());

            UseWaitCursor = false;
            Close();
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
