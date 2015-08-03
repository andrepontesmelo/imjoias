using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;
using Negócio.Importação.EntidadesAntigas;

namespace Apresentação.Importação.Intervenção
{
    partial class QuestionarTipoPessoa : BaseImportação
    {
        public QuestionarTipoPessoa(CadCli cadcli) : base(cadcli, null)
        {
            InitializeComponent();

            this.textBox1.Text = cadcli.Nome;
        }

        public TipoPessoa Tipo
        {
            get
            {
                if (optFísica.Checked)
                    return TipoPessoa.Física;
                else if (optJurídica.Checked)
                    return TipoPessoa.Jurídica;

                throw new NotSupportedException();
            }
        }

        public static TipoPessoa? Questionar(CadCli cadcli)
        {
            using (QuestionarTipoPessoa dlg = new QuestionarTipoPessoa(cadcli))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.Tipo;
                else
                    return null;
            }
        }
    }
}