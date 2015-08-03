using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresenta��o.Mercadoria.Manuten��o.ComponentesDeCusto
{
    public partial class ListaComponentesMercadoria : Apresenta��o.Mercadoria.Manuten��o.ComponentesDeCusto.ListaComponentesCusto
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

            /// Coloca coluna Nome por �ltimo
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
            colC�digo.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
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
            JanelaEdi��oV�nculo janela = new JanelaEdi��oV�nculo();
            janela.Mercadoria = mercadoria;
            janela.Modo = JanelaEdi��oV�nculo.EnumModo.Inser��o;
            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                Apresenta��o.Formul�rios.AguardeDB.Mostrar();
                VinculoMercadoriaComponenteCusto novoV�nculo =
                    new VinculoMercadoriaComponenteCusto(janela.Mercadoria.Refer�nciaNum�rica,
                    janela.Componente.C�digo, janela.Quantidade);

                novoV�nculo.Cadastrar();

                Carregar(mercadoria);
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }
        }

        private void ListaComponentesMercadoria_ClicouAlterar(object sender, EventArgs e)
        {
            JanelaEdi��oV�nculo janela;
            VinculoMercadoriaComponenteCusto vinculo;

            janela = new JanelaEdi��oV�nculo();
            janela.Mercadoria = mercadoria;
            janela.Modo = JanelaEdi��oV�nculo.EnumModo.Altera��o;

            if (Selecionado == null)
                throw new NullReferenceException();

            vinculo = hash[Selecionado];
            janela.Quantidade = vinculo.Quantidade;
            janela.Componente = vinculo.ComponenteCusto;

            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                string componenteAnterior = vinculo.ComponenteCusto;

                Apresenta��o.Formul�rios.AguardeDB.Mostrar();
                vinculo.Quantidade = janela.Quantidade;
                vinculo.ComponenteCusto = janela.Componente.C�digo;
                vinculo.AtualizarTrocandoComponente(componenteAnterior);

                Carregar(mercadoria);
                Apresenta��o.Formul�rios.AguardeDB.Fechar();
            }
        }

        private void ListaComponentesMercadoria_ClicouExcluir(object sender, EventArgs e)
        {
            Apresenta��o.Formul�rios.AguardeDB.Mostrar();
            hash[Selecionado].Descadastrar();
            Carregar(mercadoria);
            Apresenta��o.Formul�rios.AguardeDB.Fechar();
        }
    }
}

