using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Apresentação.Pessoa.Cadastro
{
    /// <summary>
    /// Exibe dados do cliente.
    /// </summary>
    public partial class DadosCliente : UserControl
    {
        private Entidades.Pessoa.Pessoa pessoa;

        public DadosCliente()
        {
            InitializeComponent();
        }

        private static string Formatar(DateTime data)
        {
            // Sabado, 1 de abril de 2011 => 1 de abril de 2011;
            return data.ToLongDateString().Split(',')[1];
        }

        /// <summary>
        /// Pessoa cujos dados serão editados.
        /// </summary>
        [DefaultValue(null), ReadOnly(true), Browsable(false)]
        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                pessoa = value;

                DateTime? últimaVenda;
                double? maiorVenda;
                Entidades.Relacionamento.Venda.Venda.ObtemRecordes(pessoa, out maiorVenda, out últimaVenda);

                if (value.DataRegistro.HasValue)
                    txtCadastro.Text = Formatar(value.DataRegistro.Value);  // "Sunday, March 9, 2008" 
                else
                    txtÚltimaVenda.Text = "<não registrado>";

                //if (value.ÚltimaVisita.HasValue)
                //    txtÚltimaVenda.Text = value.ÚltimaVisita.Value.ToLongDateString();
                //else
                //    txtÚltimaVenda.Text = "<não registrado>";

                txtÚltimaVenda.Text = últimaVenda.HasValue ? Formatar(últimaVenda.Value) : "<não registrado>";

                if (value.Setor != null)
                    switch (value.Setor.Nome.ToLower())
                    {
                        case "varejo":
                            optVarejo.Checked = true;
                            break;

                        case "atacado":
                            optAtacado.Checked = true;
                            break;

                        case "alto-atacado":
                            optAltoAtacado.Checked = true;
                            break;

                        default:
                            optOutro.Checked = true;
                            break;
                    }
                else
                    optOutro.Checked = true;

                //avaliadorVarejo.Nota = value.AvaliaçãoVolVarejo;
                //avaliadorAtacado.Nota = value.AvaliaçãoVolAtacado;
                //avaliadorPagamento.Nota = value.AvaliaçãoPagamento;
                //avaliadorConsignado.Nota = value.AvaliaçãoVendaConsignado;

                classificador.Pessoa = value;

                classificador.MostrarSomenteAtribuídos = value.Classificações > 0;

                //if (value.MaiorVenda.HasValue)
                //    txtMaiorVenda.Double = value.MaiorVenda.Value;
                //else
                //    txtMaiorVenda.Text = "";

                if (maiorVenda.HasValue)
                    txtMaiorVenda.Double = maiorVenda.Value;
                else
                    txtMaiorVenda.Text = "";

                if (value.Crédito.HasValue)
                    txtCrédito.Double = value.Crédito.Value;
                else
                    txtCrédito.Text = "";
            }
        }

        private void optVarejo_CheckedChanged(object sender, EventArgs e)
        {
            pessoa.Setor = Setor.ObterSetor("Varejo");
        }

        private void optAtacado_CheckedChanged(object sender, EventArgs e)
        {
            pessoa.Setor = Setor.ObterSetor("Atacado");
        }

        private void optAltoAtacado_CheckedChanged(object sender, EventArgs e)
        {
            pessoa.Setor = Setor.ObterSetor("Alto-Atacado");
        }

        private void optOutro_CheckedChanged(object sender, EventArgs e)
        {
            if (pessoa.Setor != null)
            {
                string anterior = pessoa.Setor.Nome.ToLower();

                if (anterior == "varejo" ||
                    anterior == "atacado" ||
                    anterior == "alto-atacado")
                {
                    pessoa.Setor = null;
                }
            }
        }

        //private void avaliadorVarejo_AvaliaçãoAlterada(object sender, EventArgs e)
        //{
        //    pessoa.AvaliaçãoVolVarejo = avaliadorVarejo.Nota;
        //}

        //private void avaliadorAtacado_AvaliaçãoAlterada(object sender, EventArgs e)
        //{
        //    pessoa.AvaliaçãoVolAtacado = avaliadorAtacado.Nota;
        //}

        //private void avaliadorPagamento_AvaliaçãoAlterada(object sender, EventArgs e)
        //{
        //    pessoa.AvaliaçãoPagamento = avaliadorPagamento.Nota;
        //}

        //private void avaliadorConsignado_AvaliaçãoAlterada(object sender, EventArgs e)
        //{
        //    pessoa.AvaliaçãoVendaConsignado = avaliadorPagamento.Nota;
        //}

        private void txtMaiorVenda_Validated(object sender, EventArgs e)
        {
            if (txtMaiorVenda.Text.Trim().Length > 0)
                pessoa.MaiorVenda = txtMaiorVenda.Double;
            else
                pessoa.MaiorVenda = null;
        }

        private void txtCrédito_Validated(object sender, EventArgs e)
        {
            if (txtCrédito.Text.Trim().Length > 0)
                pessoa.Crédito = txtCrédito.Double;
            else
                pessoa.Crédito = null;
        }
    }
}
