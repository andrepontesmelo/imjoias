using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades.Relacionamento.Venda;

namespace Apresentação.Financeiro.Venda
{
    public partial class ProcurarVendas : Apresentação.Formulários.JanelaExplicativa
    {
        /// <summary>
        /// Controlador da base inferior.
        /// </summary>
        private ControladorBaseInferior controlador;

        public ProcurarVendas()
        {
            InitializeComponent();

            dataInício.Value = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0, 0));
        }

        /// <summary>
        /// Constrói a janela para procura de vendas.
        /// </summary>
        /// <param name="controlador">
        /// Controlador da base inferior que será utilizado
        /// para substituição de base, caso o usuário deseje
        /// visualizar uma venda.
        /// </param>
        /// <param name="pessoa">Cliente, vendedor ou representante.</param>
        public ProcurarVendas(ControladorBaseInferior controlador, Entidades.Pessoa.Pessoa pessoa) : this()
        {
            this.controlador = controlador;

            if (!Entidades.Pessoa.Pessoa.ÉCliente(pessoa))
            {
                txtVendedor.Pessoa = pessoa;
            }
            else
                txtCliente.Pessoa = pessoa;
        }

        /// <summary>
        /// Ocorre ao clicar em OK.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            IDadosVenda[] vendas;
            VínculoVendaPessoa tipoVinculo;

            if (txtVendedor.Pessoa != null && txtCliente.Pessoa == null)
            {
                // Vendas de um vendedor foi escolhido.
                tipoVinculo = VínculoVendaPessoa.Vendedor;
                vendas = VendaSintetizada.ObterVendas(txtVendedor.Pessoa, null, dataInício.Value, dataFim.Value);
            }
            else if (txtVendedor.Pessoa == null)
            {
                // Os dois campos preenchidos. Cliente e vendedor.
                tipoVinculo = VínculoVendaPessoa.Indefinido;
                vendas = VendaSintetizada.ObterVendas(txtVendedor.Pessoa, txtCliente.Pessoa, dataInício.Value, dataFim.Value);
            }
            else 
            {
                // Compras de um cliente
                tipoVinculo = VínculoVendaPessoa.Cliente;

                vendas = VendaSintetizada.ObterVendas(null, txtCliente.Pessoa, dataInício.Value, dataFim.Value);
            }

            Close();

            ListarVendas listagem = new ListarVendas(controlador, vendas, tipoVinculo);

            listagem.Show(ParentForm);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

