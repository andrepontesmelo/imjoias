using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Venda;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Venda
{
    public partial class ListarVendas : Apresentação.Formulários.JanelaExplicativa
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
        /// Constrói a lista de vendas mostrando um
        /// vetor de vendas.
        /// </summary>
        /// <param name="vendas">Vetor de vendas a ser exibido.</param>
        public ListarVendas(IDadosVenda[] vendas, VínculoVendaPessoa tipo)
            : this()
        {
            if (vendas.Length != 0)
            {
                switch (tipo)
                {
                    case VínculoVendaPessoa.Cliente:
                        lblDescrição.Text = "Abaixo estão as compras de " + vendas[0].NomeCliente;
                        break;
                    case VínculoVendaPessoa.Vendedor:
                        lblDescrição.Text = "Abaixo estão as vendas de " + Entidades.Pessoa.Pessoa.ReduzirNome(vendas[0].NomeVendedor);
                        break;
                    default:
                        lblDescrição.Text = "Listagem das vendas";
                        break;
                }
                
                lista.TipoExibição = tipo;
                lista.Carregar(vendas);
            }
        }

        /// <summary>
        /// Constrói a lista de vendas mostrando um
        /// vetor de vendas.
        /// </summary>
        /// <param name="controlador">
        /// Controlador da base inferior que será utilizada para
        /// exibir a base de visualização de vendas.
        /// </param>
        /// <param name="vendas">Vetor de vendas a ser exibido.</param>
        public ListarVendas(ControladorBaseInferior controlador, IDadosVenda[] vendas, VínculoVendaPessoa tipo)
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
                    "Visualização de venda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }
            else
                venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(lista.ItemSelecionado.Value);

            JanelaImpressão janela = new JanelaImpressão();
            Relatório relatórioVenda = new Relatório();
            ControleImpressãoVenda controle = new ControleImpressãoVenda();

            controle.PrepararImpressão(relatórioVenda, venda);

            janela.InserirDocumento(relatórioVenda, "Venda #" + (venda.Controle.HasValue ? venda.Controle.Value.ToString() : venda.CódigoFormatado.ToString() + " (cód interno)"));
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
                    "Visualização de venda",
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
                "Visualização de venda",
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
