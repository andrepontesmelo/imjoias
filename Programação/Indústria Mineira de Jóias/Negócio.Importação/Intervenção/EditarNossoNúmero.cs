using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negócio.Importação.EntidadesAntigas;
using Entidades;

namespace Apresentação.Importação.Intervenção
{
    partial class EditarNossoNúmero : BaseImportação
    {
//        private Entidades.Pessoa.Pessoa pessoa;

        public EditarNossoNúmero(CadCli cadcli, Entidades.Pessoa.Pessoa pessoa, Setor varejo, Setor atacado, Setor altoAtacado)
            : base(cadcli, pessoa)
        {
            InitializeComponent();

//            this.pessoa = pessoa;

            this.txtNossoNúmero.Text= cadcli.NossoNúmero;

            if (pessoa.DataRegistro.HasValue)
                this.txtDataRegistro.Value = pessoa.DataRegistro.Value;
            else
                txtDataRegistro.Text = "";

            if (pessoa.MaiorVenda.HasValue)
                this.txtMaiorVenda.Double = pessoa.MaiorVenda.Value;
            else
                this.txtMaiorVenda.Text = "";

            if (pessoa.Crédito.HasValue)
                this.txtCrédito.Double = pessoa.Crédito.Value;
            else
                this.txtCrédito.Text = "";

            if (pessoa.Setor == varejo)
                optVarejo.Checked = true;

            else if (pessoa.Setor == atacado)
                optAtacado.Checked = true;

            else if (pessoa.Setor == altoAtacado)
                optAltoAtacado.Checked = true;

            optVarejo.Tag = varejo;
            optAtacado.Tag = atacado;
            optAltoAtacado.Tag = altoAtacado;

            classificador.Pessoa = pessoa;
        }

        private void txtDataRegistro_Validated(object sender, EventArgs e)
        {
            pessoa.DataRegistro = txtDataRegistro.Value;
        }

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

        private void optSetor_Validated(object sender, EventArgs e)
        {
            pessoa.Setor = (Setor)((RadioButton)sender).Tag;
        }
    }
}