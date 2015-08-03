using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Apresenta��o.Financeiro.Sa�da
{
    public partial class ListaSa�das : Apresenta��o.Financeiro.ListaConsignado
    {
        public ListaSa�das()
        {
            InitializeComponent();
        }

        protected override void PrepararListViewItem(ListViewItem item, Entidades.Relacionamento.Relacionamento relacionamento)
        {
            base.PrepararListViewItem(item, relacionamento);

            Entidades.Relacionamento.Sa�da.Sa�da sa�da = (Entidades.Relacionamento.Sa�da.Sa�da)relacionamento; ;
        }

        protected override ArrayList ObterRelacionamentos(Entidades.Pessoa.Pessoa pessoa, DateTime in�cio, DateTime fim, bool apenasAcertados)
        {
            return new ArrayList(Entidades.Relacionamento.Sa�da.Sa�da.ObterSa�das(pessoa, in�cio, fim, apenasAcertados));
        }
    }
}

