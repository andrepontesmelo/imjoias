using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negócio.Importação.EntidadesAntigas;
using Entidades.Pessoa.Endereço;

namespace Apresentação.Importação.Intervenção
{
    partial class EditarEndereço : BaseImportação
    {
        public EditarEndereço(CadCli cadcli, Endereço endereço, string logradouro, string bairro, string cep, string cidade, string uf) : base(cadcli, endereço.Pessoa)
        {
            InitializeComponent();

            novoEndereço.Item = endereço;
            txtCEP.Text = cep;
            txtEndereço.Text = logradouro;
            txtCidade.Text = cidade;
            txtUF.Text = uf;
            txtBairro.Text = bairro;
        }
    }
}