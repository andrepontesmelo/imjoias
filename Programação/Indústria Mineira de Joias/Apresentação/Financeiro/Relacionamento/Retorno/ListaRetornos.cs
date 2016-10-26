using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Entidades.Relacionamento;

namespace Apresenta��o.Financeiro.Retorno
{
    public partial class ListaRetornos : Apresenta��o.Financeiro.ListaConsignado
    {
        public ListaRetornos()
        {
            InitializeComponent();
        }

        protected override void PrepararListViewItem(ListViewItem item, Entidades.Relacionamento.RelacionamentoAcerto relacionamento)
        {
            base.PrepararListViewItem(item, relacionamento);
        }

        protected override ArrayList ObterRelacionamentos(Entidades.Pessoa.Pessoa pessoa, DateTime in�cio, DateTime fim, bool apenasN�oAcertados)
        {
            return new ArrayList(Entidades.Relacionamento.Retorno.Retorno.ObterRetornos(pessoa, in�cio, fim, apenasN�oAcertados));
        }
    }
}

