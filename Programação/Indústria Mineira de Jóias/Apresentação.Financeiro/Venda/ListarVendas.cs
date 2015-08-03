using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;
using Apresenta��o.Impress�o.Relat�rios.Venda;

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

        //private V�nculoVendaPessoa Tipo
        //{
        //    set
        //    {
        //        lista.TipoExibi��o = value;

        //        switch (value)
        //        {
        //            case V�nculoVendaPessoa.Indefinido:
        //                lblDescri��o.Text = "";
        //                break;
        //            case V�nculoVendaPessoa.Vendedor:
        //                lblDescri��o.Text = "Abaixo est�o as compras de " + vendas[0].Cliente;
        //    }
        //    else 
        //    {
        //        lista.TipoExibi��o = V�nculoVendaPessoa.Vendedor;
        //        //lblDescri��o.Text = "Vendas realizadas pelo vendedor " + vendas[0].Vendedor.C�digo;
        //        lblDescri��o.Text = "Abaixo est� as vendas de " + vendas[0].Vendedor.PrimeiroNome;
        //    }

        /// <summary>
        /// Constr�i a lista de vendas mostrando um
        /// vetor de vendas.
        /// </summary>
        /// <param name="vendas">Vetor de vendas a ser exibido.</param>
        public ListarVendas(Entidades.Relacionamento.Venda.Venda[] vendas, V�nculoVendaPessoa tipo)
            : this()
        {
            if (vendas.Length != 0)
            {
                switch (tipo)
                {
                    case V�nculoVendaPessoa.Cliente:
                        lblDescri��o.Text = "Abaixo est�o as compras de " + vendas[0].Cliente;
                        break;
                    case V�nculoVendaPessoa.Vendedor:
                        lblDescri��o.Text = "Abaixo est� as vendas de " + vendas[0].Vendedor.PrimeiroNome;
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
        public ListarVendas(ControladorBaseInferior controlador, Entidades.Relacionamento.Venda.Venda[] vendas, V�nculoVendaPessoa tipo)
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
        ///// Determina se o tipo a ser exibido � de vendas
        ///// para cliente ou vendas de um representante ou vendedor.
        ///// </summary>
        ///// <param name="vendas">Vetor de vendas.</param>
        //private void DeterminarTipo(Entidades.Relacionamento.Venda.Venda[] vendas)
        //{
        //    bool cliente = true;
        //    bool vendedor = true;

        //    for (int i = 1; i < vendas.Length; i++)
        //    {
        //        cliente &= vendas[i].Vendedor.C�digo == vendas[0].Vendedor.C�digo;
        //        vendedor &= vendas[i].Cliente.C�digo == vendas[0].Cliente.C�digo;
        //    }

        //    if ((cliente && vendedor) && (vendas.Length >= 2))
        //        throw new NotSupportedException("A janela ListarVendas n�o suporta mostrar vendas de m�ltiplos clientes e m�ltiplos vendedores.");

        //    /*  Imagine apenas uma venda sendo recuperada. N�o � poss�vel ent�o descobrir qual 
        //      * vinculo o usu�rio deseja. Na verdade, � necess�rio no m�mino 2 vendas para observar
        //      * algum padr�o.
        //      */

        //    if (vendas.Length < 2)
        //    {
        //        // Assume-se uma posi��o neutra.
        //        lblDescri��o.Text = "";
        //        lista.TipoExibi��o = V�nculoVendaPessoa.Indefinido;
        //    } else if (!cliente)
        //    {
        //        lista.TipoExibi��o = V�nculoVendaPessoa.Cliente;
        //        //lblDescri��o.Text = "Vendas realizadas para o cliente " + vendas[0].Cliente.Nome;
        //        lblDescri��o.Text = "Abaixo est�o as compras de " + vendas[0].Cliente;
        //    }
        //    else 
        //    {
        //        lista.TipoExibi��o = V�nculoVendaPessoa.Vendedor;
        //        //lblDescri��o.Text = "Vendas realizadas pelo vendedor " + vendas[0].Vendedor.C�digo;
        //        lblDescri��o.Text = "Abaixo est� as vendas de " + vendas[0].Vendedor.PrimeiroNome;
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
                    "Visualiza��o de venda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }
            else
                venda = Entidades.Relacionamento.Venda.Venda.ObterVenda(lista.ItemSelecionado.Value);

            
            //controlador.SubstituirBaseArbitrariamente(
            //    new BaseEditarVenda(venda),
            //    "Visualiza��o de venda",
            //    "Ser� exibida a venda realizada para " + venda.Cliente.Nome
            //    + " feita por " + venda.Vendedor.Nome + ".");

            //Close();

            JanelaImpress�o janela = new JanelaImpress�o();
            Relat�rio relat�rioVenda = new Relat�rio();
            ControleImpress�oVenda controle = new ControleImpress�oVenda();

            controle.PrepararImpress�o(relat�rioVenda, venda);

            janela.InserirDocumento(relat�rioVenda, "Venda #" + (venda.Controle.HasValue ? venda.Controle.Value.ToString() : venda.C�digo.ToString() + " (c�d interno)"));
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

    }
}
