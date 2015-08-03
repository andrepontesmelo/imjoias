using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Apresentação.Financeiro.Retorno
{
    public partial class ListaRetornos : Apresentação.Financeiro.ListaConsignado
    {
        public ListaRetornos()
        {
            InitializeComponent();
        }

        protected override void PrepararListViewItem(ListViewItem item, Entidades.Relacionamento.Relacionamento relacionamento)
        {
            base.PrepararListViewItem(item, relacionamento);
        }

        protected override ArrayList ObterRelacionamentos(Entidades.Pessoa.Pessoa pessoa, DateTime início, DateTime fim, bool apenasAcertados)
        {
            return new ArrayList(Entidades.Relacionamento.Retorno.Retorno.ObterRetornos(pessoa, início, fim, apenasAcertados));
        }
    }
}

