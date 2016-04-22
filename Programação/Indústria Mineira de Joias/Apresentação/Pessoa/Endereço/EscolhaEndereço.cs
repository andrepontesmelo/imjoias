using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa.Endere�o
{
    public partial class EscolhaEndere�o : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        public EscolhaEndere�o(IEnumerable<Entidades.Pessoa.Endere�o.Endere�o> endere�os)
        {
            InitializeComponent();

            foreach (Entidades.Pessoa.Endere�o.Endere�o endere�o in endere�os)
                Adicionar(endere�o);

            lst.Sort();
        }

        public Entidades.Pessoa.Endere�o.Endere�o Endere�o
        {
            get
            {
                if (lst.SelectedItems.Count == 1)
                    return lst.SelectedItems[0].Tag as Entidades.Pessoa.Endere�o.Endere�o;
                else
                    return null;
            }
        }

        private void Adicionar(Entidades.Pessoa.Endere�o.Endere�o endere�o)
        {
            ListViewItem item = new ListViewItem(endere�o.Descri��o);
            item.SubItems.Add(endere�o.Logradouro);
            item.SubItems.Add(endere�o.N�mero);
            item.SubItems.Add(endere�o.Complemento);
            item.SubItems.Add(endere�o.Bairro);
            item.SubItems.Add(endere�o.CEP);
            item.SubItems.Add(endere�o.Localidade != null ? endere�o.Localidade.Nome : "");
            item.SubItems.Add(endere�o.Localidade != null ? endere�o.Localidade.Estado.Nome: "");
            item.SubItems.Add(endere�o.Localidade != null ? endere�o.Localidade.Estado.Pa�s.Nome : "");
            item.Tag = endere�o;
            lst.Items.Add(item);
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lst.SelectedItems.Count == 1;
        }
    }
}
