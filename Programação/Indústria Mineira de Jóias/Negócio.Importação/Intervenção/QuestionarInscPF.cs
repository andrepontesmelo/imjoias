using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negócio.Importação.EntidadesAntigas;
using Entidades.Pessoa;

namespace Apresentação.Importação.Intervenção
{
    partial class QuestionarInscPF : BaseImportação
    {
        public QuestionarInscPF(CadCli cadcli, PessoaFísica pessoa) : base(cadcli, pessoa)
        {
            InitializeComponent();

            txtInsc.Text = cadcli.Insc;
            txtDI.Text = pessoa.DI;
            txtÓrgão.Text = pessoa.DIEmissor;
        }

        public string DI { get { return txtDI.Text; } }

        public string Órgão { get { return txtÓrgão.Text; } }
    }
}