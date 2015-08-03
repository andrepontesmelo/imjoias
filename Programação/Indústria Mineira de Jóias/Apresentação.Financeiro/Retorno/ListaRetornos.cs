using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Apresenta��o.Financeiro.Retorno
{
    public partial class ListaRetornos : Apresenta��o.Financeiro.ListaConsignado
    {
        public ListaRetornos()
        {
            InitializeComponent();
        }

        protected override void PrepararListViewItem(ListViewItem item, Entidades.Relacionamento.Relacionamento relacionamento)
        {
            base.PrepararListViewItem(item, relacionamento);
        }

        protected override ArrayList ObterRelacionamentos(Entidades.Pessoa.Pessoa pessoa, DateTime in�cio, DateTime fim, bool apenasAcertados)
        {
            return new ArrayList(Entidades.Relacionamento.Retorno.Retorno.ObterRetornos(pessoa, in�cio, fim, apenasAcertados));
        }
    }
}

