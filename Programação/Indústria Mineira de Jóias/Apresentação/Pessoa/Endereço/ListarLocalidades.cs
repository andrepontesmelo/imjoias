using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa.Endere�o;
using Apresenta��o.Formul�rios;

namespace Apresenta��o.Pessoa.Endere�o
{
    /// <summary>
    /// Exibe a lista de localidades utilizada pela procura
    /// realizada pelo usu�rio.
    /// </summary>
    sealed partial class ListarLocalidades : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private Dictionary<ListViewItem, Localidade> hashItemLocalidade;

        public Localidade Sele��o
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
                "Preparando informa��es",
                "Aguarde enquanto o sistema prepara as informa��es das localidades obtidas no banco de dados."))
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
                        localidade.Estado.Pa�s.Nome,
                        (localidade.Regi�o != null ? localidade.Regi�o.Nome :
                        (localidade.Estado.Regi�o != null ? localidade.Estado.Regi�o.Nome : ""))
                    });

                    lst.Items.Add(item);

                    hashItemLocalidade[item] = localidade;
                }
            }
        }

        private void AoMudarSele��o(object sender, EventArgs e)
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

