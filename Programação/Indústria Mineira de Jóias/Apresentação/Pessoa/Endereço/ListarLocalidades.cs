using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endereço;
using Apresentação.Formulários;

namespace Apresentação.Pessoa.Endereço
{
    /// <summary>
    /// Exibe a lista de localidades utilizada pela procura
    /// realizada pelo usuário.
    /// </summary>
    sealed partial class ListarLocalidades : Apresentação.Formulários.JanelaExplicativa
    {
        private Dictionary<ListViewItem, Localidade> hashItemLocalidade;

        public Localidade Seleção
        {
            get
            {
                if (lst.SelectedItems.Count == 1)
                    return hashItemLocalidade[lst.SelectedItems[0]];

                return null;
            }
        }

        public ListarLocalidades(Localidade[] localidades)
        {
            InitializeComponent();

            using (Aguarde aguarde = new Aguarde(
                "Carregando localidades...", localidades.Length,
                "Preparando informações",
                "Aguarde enquanto o sistema prepara as informações das localidades obtidas no banco de dados."))
            {
                hashItemLocalidade = new Dictionary<ListViewItem, Localidade>();

                foreach (Localidade localidade in localidades)
                {
                    ListViewItem item;

                    aguarde.Passo("Lendo " + localidade.Nome);

                    item = new ListViewItem(
                        new string[] {
                        localidade.Nome,
                        localidade.Estado.Nome,
                        localidade.Estado.País.Nome,
                        (localidade.Região != null ? localidade.Região.Nome :
                        (localidade.Estado.Região != null ? localidade.Estado.Região.Nome : ""))
                    });

                    lst.Items.Add(item);

                    hashItemLocalidade[item] = localidade;
                }
            }
        }

        private void AoMudarSeleção(object sender, EventArgs e)
        {
            btnOK.Enabled = lst.SelectedIndices.Count == 1;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}

