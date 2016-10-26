using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Editor base de conjuntos.
    /// </summary>
    public partial class EditorBase<Item, ControleItem> : UserControl
        where Item : class, new()
        where ControleItem : Control, IEditorItem<Item>, new()
    {
        /// <summary>
        /// Tratamento de evento de foco em DadosEndereço.
        /// </summary>
        private EventHandler aoFocar;

        /// <summary>
        /// Endereço selecioando.
        /// </summary>
        private ControleItem seleção;


        /// <summary>
        /// Constrói o editor base.
        /// </summary>
        public EditorBase()
        {
            InitializeComponent();

            aoFocar = new EventHandler(AoFocarItem);
        }

        /// <summary>
        /// Ocorre ao clicar em adicionar.
        /// </summary>
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Item item;
            ControleItem controle;

            item = ConstruirNovoItem();

            AoAdicionar(item);
            
            controle = Adicionar(item);

            painel.ScrollControlIntoView(controle);
            controle.Focus();
        }

        /// <summary>
        /// Constrói um novo item.
        /// </summary>
        /// <returns>Novo item.</returns>
        protected virtual Item ConstruirNovoItem()
        {
            return new Item();
        }

        /// <summary>
        /// Ocorre ao adicionar um novo item.
        /// </summary>
        /// <param name="item">Novo item adicionado.</param>
        protected virtual void AoAdicionar(Item item)
        {
        }

        /// <summary>
        /// Adiciona um controle de edição.
        /// </summary>
        protected ControleItem Adicionar(Item item)
        {
            ControleItem controle = new ControleItem();

            ConfigurarControle(controle);
            controle.Item = item;

            painel.Controls.Add(controle);

            return controle;
        }

        /// <summary>
        /// Configura o controle para exibição.
        /// </summary>
        /// <param name="controle">Controle a ser configurado.</param>
        /// <remarks>
        /// Este método é chamado antes de que Item seja atribuído!
        /// </remarks>
        protected virtual void ConfigurarControle(ControleItem controle)
        {
            controle.Margin = new Padding(0, 3, 0, 3);
            controle.Visible = true;
            controle.Width = painel.ClientSize.Width;
            controle.GotFocus += aoFocar;
        }

        /// <summary>
        /// Ocorre quando um item ganha foco,
        /// marcando ele como selecionado.
        /// </summary>
        private void AoFocarItem(object sender, EventArgs e)
        {
            seleção = (ControleItem)sender;
            btnRemover.Enabled = true;
        }

        /// <summary>
        /// Ocorre ao clicar em remover um item,
        /// removendo-o também da lista de endereços da pessoa.
        /// O controle removido é adicionado na Tag do botão
        /// Desfazer, permitindo que a última ação de remoção
        /// seja desfeita.
        /// </summary>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            ControleItem seleção = this.seleção;

            this.seleção = null;
            btnRemover.Enabled = false;

            if (seleção != null)
            {
                AoRemover(seleção.Item);
                painel.Controls.Remove(seleção);
                seleção.GotFocus -= aoFocar;

                btnDesfazer.Tag = seleção.Item;
                btnDesfazer.Visible = true;

                seleção.Dispose();
            }
        }

        /// <summary>
        /// Ocorre ao remover um item.
        /// </summary>
        /// <param name="item">Item removido.</param>
        protected virtual void AoRemover(Item item)
        {
        }

        /// <summary>
        /// Ocorre ao clicar em desfazer, reinserindo o controle
        /// para edição de item anteriormente removido.
        /// </summary>
        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            Item item = btnDesfazer.Tag as Item;

            if (item != null)
            {
                AoAdicionar(item);

                ControleItem controle = Adicionar(item);

                painel.ScrollControlIntoView(controle);
                controle.Focus();
            }
            else
                MessageBox.Show(
                    ParentForm,
                    "Não foi possível desfazer a remoção!",
                    "Desfazer remoção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            btnDesfazer.Visible = false;
            btnDesfazer.Tag = null;
        }

        protected void Limpar()
        {
            painel.Controls.Clear();
            seleção = null;
            btnRemover.Enabled = false;
        }
    }
}
