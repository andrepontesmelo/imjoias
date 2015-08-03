using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Financeiro.Venda
{
    public partial class ProcurarVendas : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        /// <summary>
        /// Controlador da base inferior.
        /// </summary>
        private ControladorBaseInferior controlador;

        public ProcurarVendas()
        {
            InitializeComponent();

            dataIn�cio.Value = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0, 0));
        }

        /// <summary>
        /// Constr�i a janela para procura de vendas.
        /// </summary>
        /// <param name="controlador">
        /// Controlador da base inferior que ser� utilizado
        /// para substitui��o de base, caso o usu�rio deseje
        /// visualizar uma venda.
        /// </param>
        /// <param name="pessoa">Cliente, vendedor ou representante.</param>
        public ProcurarVendas(ControladorBaseInferior controlador, Entidades.Pessoa.Pessoa pessoa) : this()
        {
            this.controlador = controlador;

            if (!Entidades.Pessoa.Pessoa.�Cliente(pessoa))
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
            Entidades.Relacionamento.Venda.Venda[] vendas;
            V�nculoVendaPessoa tipoVinculo;

            AguardeDB.Mostrar();
            UseWaitCursor = true;
            Application.DoEvents();

            try
            {
                if (txtVendedor.Pessoa != null && txtCliente.Pessoa == null)
                {
                    // Vendas de um vendedor foi escolhido.
                    tipoVinculo = V�nculoVendaPessoa.Vendedor;
                    vendas = Entidades.Relacionamento.Venda.Venda.ObterVendas(txtVendedor.Pessoa, null, dataIn�cio.Value, dataFim.Value);
                }
                else if (txtVendedor.Pessoa == null)
                {
                    // Os dois campos preenchidos. Cliente e vendedor.
                    tipoVinculo = V�nculoVendaPessoa.Indefinido;
                    vendas = Entidades.Relacionamento.Venda.Venda.ObterVendas(txtVendedor.Pessoa, txtCliente.Pessoa, dataIn�cio.Value, dataFim.Value);
                }
                else 
                {
                    // Compras de um cliente
                    tipoVinculo = V�nculoVendaPessoa.Cliente;

                    vendas = Entidades.Relacionamento.Venda.Venda.ObterVendas(null, txtCliente.Pessoa, dataIn�cio.Value, dataFim.Value);
                }
                //else if (txtCliente.Pessoa != null)
                //{
                //    // Compras de um cliente
                //    tipoVinculo = V�nculoVendaPessoa.Cliente;

                //    vendas = Entidades.Relacionamento.Venda.VendaOca.ObterVendas(false, txtCliente.Pessoa, dataIn�cio.Value, dataFim.Value);
                //}
                //else
                //{
                //    AguardeDB.Fechar();
                //    UseWaitCursor = false;

                //    MessageBox.Show("A busca n�o pode ser feita porqu� os dados s�o insuficientes.", "Dados Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }
            finally
            {
                AguardeDB.Fechar();
                UseWaitCursor = false;
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

