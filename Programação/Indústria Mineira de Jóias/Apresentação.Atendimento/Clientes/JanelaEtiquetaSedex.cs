using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Apresentação.Impressão.Etiquetas.Sedex;
using Entidades;

namespace Apresentação.Atendimento.Clientes
{
    public partial class JanelaEtiquetaSedex : JanelaExplicativa
    {
        private Dictionary<ListViewItem, Entidades.EtiquetaSedex> hashItens;

        private static JanelaEtiquetaSedex instancia;

        public static JanelaEtiquetaSedex Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new JanelaEtiquetaSedex();

                return instancia;
            }
        }

        private JanelaEtiquetaSedex()
        {
            InitializeComponent();
            hashItens = new Dictionary<ListViewItem, Entidades.EtiquetaSedex>();
        }

        /// <summary>
        /// Adiciona um endereço
        /// </summary>
        /// <param name="Pessoa"></param>
        internal void Adicionar(Entidades.Pessoa.Pessoa pessoa)
        {
            Entidades.Pessoa.Endereço.Endereço endereço = null;

            Focus();

            // Primeiro verifica se pessoa já está na lista.
            // Se estiver, faz nada.
            foreach (EtiquetaSedex etiqueta in hashItens.Values)
            {
                if (etiqueta.Pessoa.Código == pessoa.Código)
                    return;
            }

            if (pessoa.Endereços.ContarElementos() > 1) 
            {
                using (Apresentação.Pessoa.Endereço.EscolhaEndereço dlg =
                    new Apresentação.Pessoa.Endereço.EscolhaEndereço(pessoa.Endereços)) 
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        endereço = dlg.Endereço;
                    else
                        return;
                }
            }
            else if (pessoa.Endereços.ContarElementos() == 0)
            {
                MessageBox.Show(
                    ParentForm,
                    "Não existe nenhum endereço cadastrado para este cliente, portanto não é possível imprimir etiqueta para mala-direta.",
                    "Mala-Direta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Existe só um endereço
                endereço = pessoa.Endereços.ExtrairElementos()[0];
            }

            Entidades.EtiquetaSedex entidade = new Entidades.EtiquetaSedex();
            entidade.Pessoa = pessoa;
            entidade.Endereço = endereço;

            ListViewItem item = new ListViewItem();
            AtualizarItem(item, entidade);
            lista.Items.Add(item);
            hashItens[item] = entidade;

            Show();
        }

        private void AtualizarItem(ListViewItem item, EtiquetaSedex entidade)
        {
            item.SubItems.Clear();
            item.Text = entidade.Pessoa.Código.ToString();

            if (entidade.Tipo == EtiquetaSedex.TipoEndereco.Remetente)
                item.SubItems.Add("Remetente");
            else
                item.SubItems.Add("Destinatário");

            item.SubItems.Add(entidade.Quantidade.ToString());
            item.SubItems.Add(entidade.Pessoa.Nome);
            item.SubItems.Add(entidade.Endereço.Localidade.Estado.Sigla);
            item.SubItems.Add(entidade.Endereço.Localidade.Nome);
            item.SubItems.Add(entidade.Endereço.Logradouro + " " + entidade.Endereço.Número);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
            {
                ListViewItem item = lista.SelectedItems[0]; 
                lista.Items.Remove(item);
                hashItens.Remove(item);
            }
        }

        private void btnLimparLista_Click(object sender, EventArgs e)
        {
            if (lista.Items.Count > 0 && 
                MessageBox.Show(this, "Remover todos os endereços ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                lista.Items.Clear();
                hashItens.Clear();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (hashItens.Count > 0)
            {
                JanelaImpressão janela = new JanelaImpressão();
                janela.Título = "Etiquetas de sedex";
                janela.Descrição = "Visualização de impressão para etiquetas de sedex";

                EtiquetaSedexCrystal relatório = new EtiquetaSedexCrystal();

                List<Entidades.EtiquetaSedex> lista = new List<Entidades.EtiquetaSedex>();
                foreach (KeyValuePair<ListViewItem, Entidades.EtiquetaSedex> par in hashItens)
                {
                    lista.Add(par.Value);
                }

                ControleImpressãoSedex.PrepararImpressão(relatório, lista);
                janela.InserirDocumento(relatório, "Etiquetas");
                janela.Abrir(this);
            }
        }

        private void lista_DoubleClick(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
            {
                JanelaEtiquetaSedexEdicao janela = new JanelaEtiquetaSedexEdicao();
                ListViewItem item = lista.SelectedItems[0];
                EtiquetaSedex entidade = hashItens[item];

                janela.Carregar(entidade);

                if (janela.ShowDialog(this) == DialogResult.OK)
                {
                    AtualizarItem(item, entidade);
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (txtPessoa.Pessoa == null)
            {
                txtPessoa.Focus();
            }
            else
            {
                Adicionar(txtPessoa.Pessoa);
            }
        }
    }
}
