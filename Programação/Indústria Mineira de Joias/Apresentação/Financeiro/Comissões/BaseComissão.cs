using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Relacionamento.Venda;
using Entidades;
using Apresentação.Financeiro.Venda;
using Apresentação.Formulários;
using Entidades.ComissãoCálculo;

namespace Apresentação.Financeiro.Comissões
{
    public partial class BaseComissão : Apresentação.Formulários.BaseInferior
    {
        //private Dictionary<ListViewItem, Comissão> hashComissões;

        public BaseComissão()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            listaComissões.Carregar();

            //// Recarrega a lista de comissões.
            //List<Comissão> lista = Comissão.ObterComissões();
            //hashComissões = new Dictionary<ListViewItem, Comissão>();
            //lstComissões.Items.Clear();
            //foreach (Comissão c in lista)
            //{
            //    ListViewItem novoItem = new ListViewItem();
            //    novoItem.Text = c.Código.ToString();
            //    novoItem.SubItems.Add(c.Funcionário.Nome);
            //    novoItem.SubItems.Add(c.Descrição);
            //    lstComissões.Items.Add(novoItem);
            //    hashComissões[novoItem] = c;
            //}

            //if (lista.Count == 0)
            //    CriarComissão();
        }

        private void opçãoNova_Click(object sender, EventArgs e)
        {
            JanelaNovaComissão janela = new JanelaNovaComissão();
            janela.EventoComissãoAlterardaOuCadastrada += janela_EventoComissãoAlterardaOuCadastrada;
            janela.ShowDialog();
        }


        private void opçãoAlterarEstado_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            UseWaitCursor = true;
            Application.DoEvents();

            Comissão selecionado = listaComissões.Selecionado;

            if (selecionado == null)
                return;


            JanelaNovaComissão janela = new JanelaNovaComissão();
            janela.EventoComissãoAlterardaOuCadastrada += janela_EventoComissãoAlterardaOuCadastrada;
            janela.Comissão = selecionado;

            janela.Show();
            UseWaitCursor = false;
        }

        void janela_EventoComissãoAlterardaOuCadastrada(object sender, EventArgs e)
        {
            listaComissões.Carregar();
        }

        private void opçãoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void Excluir()
        {
            Comissão selecionado = listaComissões.Selecionado;

            if (selecionado == null)
                return;

            DialogResult resposta = MessageBox.Show(this,
                "A informação de que alguma venda está vinculada a esta comissão será excluída, bem como estornos de comissão neste documento.\nDeseja prosseguir?",
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                return;

            UseWaitCursor = true;

            selecionado.Descadastrar();

            UseWaitCursor = false;

            MessageBox.Show(this,
                "O documento foi excluído.",
                "Excluir comissão",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);

            listaComissões.Carregar();
        }

        private void opçãoAbrir_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        private void Entrar()
        {
            UseWaitCursor = true;
            Application.DoEvents();

            if (listaComissões.Selecionado == null)
                return;

            BaseEditarComissão novaBase = new BaseEditarComissão();
            novaBase.Abrir(listaComissões.Selecionado);
            SubstituirBase(novaBase);
            UseWaitCursor = false;
        }

        private void listaComissões_DuploClique(object sender, EventArgs e)
        {
            Entrar();
        }

        private void listaComissões_AoPressionar(Keys teclas)
        {
            switch (teclas)
            {
                case Keys.F2:
                    Editar();
                    break;
                case Keys.Enter:
                    Entrar();
                    break;
                case Keys.Delete:
                    Excluir();
                    break;
            }
        }

        private void opçãoImprimir_Click(object sender, EventArgs e)
        {
            Comissão selecionado = listaComissões.Selecionado;

            if (selecionado == null)
                return;

            JanelaImpressãoComissão j = new JanelaImpressãoComissão(selecionado, null);
            j.InserirTodosRelatorios();
            j.Abrir(this);
        }

        private void opçãoVendasSemComissão_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseVendaSemComissão());
        }
    }
}
