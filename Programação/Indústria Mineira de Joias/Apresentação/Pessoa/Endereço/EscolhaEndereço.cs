using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Endereço
{
    public partial class EscolhaEndereço : Apresentação.Formulários.JanelaExplicativa
    {
        public EscolhaEndereço(IEnumerable<Entidades.Pessoa.Endereço.Endereço> endereços)
        {
            InitializeComponent();

            foreach (Entidades.Pessoa.Endereço.Endereço endereço in endereços)
                Adicionar(endereço);

            lst.Sort();
        }

        public Entidades.Pessoa.Endereço.Endereço Endereço
        {
            get
            {
                if (lst.SelectedItems.Count == 1)
                    return lst.SelectedItems[0].Tag as Entidades.Pessoa.Endereço.Endereço;
                else
                    return null;
            }
        }

        private void Adicionar(Entidades.Pessoa.Endereço.Endereço endereço)
        {
            ListViewItem item = new ListViewItem(endereço.Descrição);
            item.SubItems.Add(endereço.Logradouro);
            item.SubItems.Add(endereço.Número);
            item.SubItems.Add(endereço.Complemento);
            item.SubItems.Add(endereço.Bairro);
            item.SubItems.Add(endereço.CEP);
            item.SubItems.Add(endereço.Localidade != null ? endereço.Localidade.Nome : "");
            item.SubItems.Add(endereço.Localidade != null ? endereço.Localidade.Estado.Nome: "");
            item.SubItems.Add(endereço.Localidade != null ? endereço.Localidade.Estado.País.Nome : "");
            item.Tag = endereço;
            lst.Items.Add(item);
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lst.SelectedItems.Count == 1;
        }
    }
}
