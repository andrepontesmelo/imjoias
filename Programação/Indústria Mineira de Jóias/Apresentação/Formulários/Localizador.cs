using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Entidades.Árvores;

namespace Apresentação.Formulários
{
    public partial class Localizador : UserControl
    {
        // Atributos
        private Patricia<ArrayList> patricia;
        private ArrayList listaBusca;
        private int listaBuscaPosição;
        private ToolStripButton botãoPesquisar;
        
        /// <summary>
        /// último objeto encontrado pelo usuário
        /// </summary>
        private object últimoEncontrado;

        // Eventos
        public delegate void RealçarDelegate(ArrayList itens);
        public delegate void EncontrarDelegate(object item, object últimoEncontrado);
        public event RealçarDelegate RealçarItens;
        public event EventHandler DesrealçarTudo;
        public event EncontrarDelegate EncontrarItem;

        public ToolStripButton BotãoPesquisar
        {
            get { return botãoPesquisar; }
            set
            {
                botãoPesquisar = value;

                if (botãoPesquisar != null)
                    botãoPesquisar.Click += new EventHandler(botãoPesquisar_Click);
            }
        }

        public Localizador()
        {
            InitializeComponent();
            patricia = new Patricia<ArrayList>();
            Visible = false;
        }

        /// <summary>
        /// Torna buscavel todo o texto de um item de listview.
        /// O objeto associado é o proprio item.
        /// </summary>
        /// <param name="item"></param>
        public void InserirListViewItem(ListViewItem item)
        {
            foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                InserirFraseBuscável(subitem.Text, item);
        }

        public void InserirFraseBuscável(string frase, object item)
        {
            string [] palavras = frase.Split(' ');
                foreach (string palavra in palavras)
                    InserirPalavraBuscável(palavra, item);

                   
                InserirPalavraBuscável(frase, item);
        }

        public void InserirPalavraBuscável(string palavra, object item)
        {
            ArrayList lista;

            if (!String.IsNullOrEmpty(palavra) && palavra != "\0")
            {
                if (patricia.TryGetValue(palavra, out lista))
                    lista.Add(item);
                else
                {
                    lista = new ArrayList();
                    lista.Add(item);
                    patricia.Add(palavra, lista);
                }
            }
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listaBusca.Count > 0)
            {
                if (e.Shift)
                    listaBuscaPosição--;
                else
                    listaBuscaPosição++;

                object item = listaBusca[Math.Abs(listaBuscaPosição % listaBusca.Count)];

                if (EncontrarItem != null)
                    EncontrarItem(item, últimoEncontrado);

                últimoEncontrado = item;
            }
        }

        private void chkRealçar_CheckedChanged(object sender, EventArgs e)
        {
            if (listaBusca == null)
                return;

            if (chkRealçar.Checked && RealçarItens != null)
                RealçarItens(listaBusca);
            else
                if (DesrealçarTudo != null)
                    DesrealçarTudo(sender, e);
        }

        private void botãoPesquisar_Click(object sender, EventArgs e)
        {
            if (Visible)
                Visible = false;
            else
                Abrir();
        }

        public void Abrir()
        {
            Visible = true;
            txtBusca.SelectAll();
            txtBusca.Focus();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            PatriciaPrefixoEnumerator<ArrayList> enumerador;

            if (DesrealçarTudo != null)
                DesrealçarTudo(sender, e);

            if (txtBusca.Text.Length > 0)
            {
                enumerador = patricia.GetPrefixo(txtBusca.Text);
                listaBusca = new ArrayList();
                listaBuscaPosição = 0;

                if (enumerador.Count > 0)
                {
                    txtBusca.BackColor = Color.White;

                    while (enumerador.MoveNext())
                    {
                        ArrayList listaItens = enumerador.Current;

                        foreach (object item in listaItens)
                            listaBusca.Add(item);
                    }

                    // Procura o proximo resultado
                    txtBusca_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                }
                else
                    txtBusca.BackColor = Color.Red;
            }
            else
                txtBusca.BackColor = Color.White;

            // Realça se necessário
            chkRealçar_CheckedChanged(sender, EventArgs.Empty);
        }


        public void Limpar()
        {
            patricia = new Patricia<ArrayList>();

            if (listaBusca != null)
                listaBusca.Clear();
            
            listaBuscaPosição = 0;
            últimoEncontrado = null;
        }

        private void btnFecharBusca_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
