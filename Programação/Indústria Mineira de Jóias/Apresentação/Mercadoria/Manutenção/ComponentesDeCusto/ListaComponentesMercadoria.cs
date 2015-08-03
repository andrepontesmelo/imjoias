using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresentação.Mercadoria.Manutenção.ComponentesDeCusto
{
    public partial class ListaComponentesMercadoria : Apresentação.Mercadoria.Manutenção.ComponentesDeCusto.ListaComponentesCusto
    {
        // Atributos
        ColumnHeader colQuantidade;
        Entidades.Mercadoria.Mercadoria mercadoria;
        Dictionary<ComponenteCusto, VinculoMercadoriaComponenteCusto> hash;

        public ListaComponentesMercadoria()
        {
            InitializeComponent();

            colQuantidade = new ColumnHeader();
            colQuantidade.Name = "colQuantidade";
            colQuantidade.Text = "Qtd";
            lst.Columns.Add(colQuantidade);

            /// Coloca coluna Nome por último
            lst.Columns.Remove(colNome);
            lst.Columns.Add(colNome);

            // Apaga outra colunas
            colValor.Width = 0;
            colValorAbsoluto.Width = 0;
            colRelativo.Width = 0;
        }

        /// <summary>
        /// Abre os vinculos desta mercadoria.
        /// </summary>
        /// <param name="m"></param>
        public void Carregar(Entidades.Mercadoria.Mercadoria m)
        {
            List<VinculoMercadoriaComponenteCusto> componentes;

            

            Limpar();

            this.mercadoria = m;
            componentes = VinculoMercadoriaComponenteCusto.ObterVinculos(m);
            hash = new Dictionary<ComponenteCusto, VinculoMercadoriaComponenteCusto>(componentes.Count);

            foreach (VinculoMercadoriaComponenteCusto c in componentes)
            {
                hash.Add(c.ComponenteCusto, c);
                ListViewItem item = InserirItem(c.ComponenteCusto);
            }

            colNome.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colCódigo.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            colQuantidade.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            AtualizarEnabled();
        }

        protected override void PreencherListViewItem(ListViewItem item, ComponenteCusto c)
        {
            base.PreencherListViewItem(item, c);
            item.SubItems[colQuantidade.Index].Text = hash[c].Quantidade.ToString();
        }

        private void ListaComponentesMercadoria_ClicouAdicionar(object sender, EventArgs e)
        {
            JanelaEdiçãoVínculo janela = new JanelaEdiçãoVínculo();
            janela.Mercadoria = mercadoria;
            janela.Modo = JanelaEdiçãoVínculo.EnumModo.Inserção;
            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                Apresentação.Formulários.AguardeDB.Mostrar();
                VinculoMercadoriaComponenteCusto novoVínculo =
                    new VinculoMercadoriaComponenteCusto(janela.Mercadoria.ReferênciaNumérica,
                    janela.Componente.Código, janela.Quantidade);

                novoVínculo.Cadastrar();

                Carregar(mercadoria);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
        }

        private void ListaComponentesMercadoria_ClicouAlterar(object sender, EventArgs e)
        {
            JanelaEdiçãoVínculo janela;
            VinculoMercadoriaComponenteCusto vinculo;

            janela = new JanelaEdiçãoVínculo();
            janela.Mercadoria = mercadoria;
            janela.Modo = JanelaEdiçãoVínculo.EnumModo.Alteração;

            if (Selecionado == null)
                throw new NullReferenceException();

            vinculo = hash[Selecionado];
            janela.Quantidade = vinculo.Quantidade;
            janela.Componente = vinculo.ComponenteCusto;

            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                string componenteAnterior = vinculo.ComponenteCusto;

                Apresentação.Formulários.AguardeDB.Mostrar();
                vinculo.Quantidade = janela.Quantidade;
                vinculo.ComponenteCusto = janela.Componente.Código;
                vinculo.AtualizarTrocandoComponente(componenteAnterior);

                Carregar(mercadoria);
                Apresentação.Formulários.AguardeDB.Fechar();
            }
        }

        private void ListaComponentesMercadoria_ClicouExcluir(object sender, EventArgs e)
        {
            Apresentação.Formulários.AguardeDB.Mostrar();
            hash[Selecionado].Descadastrar();
            Carregar(mercadoria);
            Apresentação.Formulários.AguardeDB.Fechar();
        }
    }
}

