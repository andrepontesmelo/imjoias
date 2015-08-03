using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Apresentação.Financeiro.Saída
{
    public partial class ListaSaídas : Apresentação.Financeiro.ListaConsignado
    {
        public ListaSaídas()
        {
            InitializeComponent();
        }

        protected override void PrepararListViewItem(ListViewItem item, Entidades.Relacionamento.Relacionamento relacionamento)
        {
            base.PrepararListViewItem(item, relacionamento);

            Entidades.Relacionamento.Saída.Saída saída = (Entidades.Relacionamento.Saída.Saída)relacionamento; ;
        }

        protected override ArrayList ObterRelacionamentos(Entidades.Pessoa.Pessoa pessoa, DateTime início, DateTime fim, bool apenasAcertados)
        {
            return new ArrayList(Entidades.Relacionamento.Saída.Saída.ObterSaídas(pessoa, início, fim, apenasAcertados));
        }
    }
}

