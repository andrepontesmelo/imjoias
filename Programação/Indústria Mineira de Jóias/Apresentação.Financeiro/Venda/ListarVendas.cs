using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Impressão.Relatórios.Venda;

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

        //private VínculoVendaPessoa Tipo
        //{
        //    set
        //    {
        //        lista.TipoExibição = value;

        //        switch (value)
        //        {
        //            case VínculoVendaPessoa.Indefinido:
        //                lblDescrição.Text = "";
        //                break;
        //            case VínculoVendaPessoa.Vendedor:
        //                lblDescrição.Text = "Abaixo estão as compras de " + vendas[0].Cliente;
        //    }
        //    else 
        //    {
        //        lista.TipoExibição = VínculoVendaPessoa.Vendedor;
        //        //lblDescrição.Text = "Vendas realizadas pelo vendedor " + vendas[0].Vendedor.Código;
        //        lblDescrição.Text = "Abaixo estã as vendas de " + vendas[0].Vendedor.PrimeiroNome;
        //    }

        /// <summary>
        /// Constrói a lista de vendas mostrando um
        /// vetor de vendas.
        /// </summary>
        /// <param name="vendas">Vetor de vendas a ser exibido.</param>
        public ListarVendas(Entidades.Relacionamento.Venda.Venda[] vendas, VínculoVendaPessoa tipo)
            : this()
        {
            if (vendas.Length != 0)
            {
                switch (tipo)
                {
                    case VínculoVendaPessoa.Cliente:
                        lblDescrição.Text = "Abaixo estão as compras de " + vendas[0].Cliente;
                        break;
                    case VínculoVendaPessoa.Vendedor:
                        lblDescrição.Text = "Abaixo estã as vendas de " + vendas[0].Vendedor.PrimeiroNome;
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
        public ListarVendas(ControladorBaseInferior controlador, Entidades.Relacionamento.Venda.Venda[] vendas, VínculoVendaPessoa tipo)
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

        ///// <summary>
        ///// Determina se o tipo a ser exibido é de vendas
        ///// para cliente ou vendas de um representante ou vendedor.
        ///// </summary>
        ///// <param name="vendas">Vetor de vendas.</param>
        //private void DeterminarTipo(Entidades.Relacionamento.Venda.Venda[] vendas)
        //{
        //    bool cliente = true;
        //    bool vendedor = true;

        //    for (int i = 1; i < vendas.Length; i++)
        //    {
        //        cliente &= vendas[i].Vendedor.Código == vendas[0].Vendedor.Código;
        //        vendedor &= vendas[i].Cliente.Código == vendas[0].Cliente.Código;
        //    }

        //    if ((cliente && vendedor) && (vendas.Length >= 2))
        //        throw new NotSupportedException("A janela ListarVendas não suporta mostrar vendas de múltiplos clientes e múltiplos vendedores.");

        //    /*  Imagine apenas uma venda sendo recuperada. Não é possível então descobrir qual 
        //      * vinculo o usuário deseja. Na verdade, é necessário no mímino 2 vendas para observar
        //      * algum padrão.
        //      */

        //    if (vendas.Length < 2)
        //    {
        //        // Assume-se uma posição neutra.
        //        lblDescrição.Text = "";
        //        lista.TipoExibição = VínculoVendaPessoa.Indefinido;
        //    } else if (!cliente)
        //    {
        //        lista.TipoExibição = VínculoVendaPessoa.Cliente;
        //        //lblDescrição.Text = "Vendas realizadas para o cliente " + vendas[0].Cliente.Nome;
        //        lblDescrição.Text = "Abaixo estão as compras de " + vendas[0].Cliente;
        //    }
        //    else 
        //    {
        //        lista.TipoExibição = VínculoVendaPessoa.Vendedor;
        //        //lblDescrição.Text = "Vendas realizadas pelo vendedor " + vendas[0].Vendedor.Código;
        //        lblDescrição.Text = "Abaixo estã as vendas de " + vendas[0].Vendedor.PrimeiroNome;
        //    }
        //}

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

            
            //controlador.SubstituirBaseArbitrariamente(
            //    new BaseEditarVenda(venda),
            //    "Visualização de venda",
            //    "Será exibida a venda realizada para " + venda.Cliente.Nome
            //    + " feita por " + venda.Vendedor.Nome + ".");

            //Close();

            JanelaImpressão janela = new JanelaImpressão();
            Relatório relatórioVenda = new Relatório();
            ControleImpressãoVenda controle = new ControleImpressãoVenda();

            controle.PrepararImpressão(relatórioVenda, venda);

            janela.InserirDocumento(relatórioVenda, "Venda #" + (venda.Controle.HasValue ? venda.Controle.Value.ToString() : venda.Código.ToString() + " (cód interno)"));
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

    }
}
