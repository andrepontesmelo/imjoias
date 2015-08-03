using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negócio.Importação.EntidadesAntigas;

namespace Apresentação.Importação.Intervenção
{
    partial class EditarTelefones : BaseImportação
    {
        public EditarTelefones(CadCli cadcli, Entidades.Pessoa.Pessoa pessoa) : base(cadcli, pessoa)
        {
            InitializeComponent();

            txtTelefone.Text = cadcli.Telefone != null ? cadcli.Telefone : "";
            txtFax.Text = cadcli.Fax != null ? cadcli.Fax : "";
            telefones.Pessoa = pessoa;
        }
    }
}