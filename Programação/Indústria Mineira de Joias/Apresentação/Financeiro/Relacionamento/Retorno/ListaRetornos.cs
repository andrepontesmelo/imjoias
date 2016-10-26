using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Entidades.Relacionamento;

namespace Apresentação.Financeiro.Retorno
{
    public partial class ListaRetornos : Apresentação.Financeiro.ListaConsignado
    {
        public ListaRetornos()
        {
            InitializeComponent();
        }

        protected override void PrepararListViewItem(ListViewItem item, Entidades.Relacionamento.RelacionamentoAcerto relacionamento)
        {
            base.PrepararListViewItem(item, relacionamento);
        }

        protected override ArrayList ObterRelacionamentos(Entidades.Pessoa.Pessoa pessoa, DateTime início, DateTime fim, bool apenasNãoAcertados)
        {
            return new ArrayList(Entidades.Relacionamento.Retorno.Retorno.ObterRetornos(pessoa, início, fim, apenasNãoAcertados));
        }
    }
}

