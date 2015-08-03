using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;

namespace Apresentação.Mercadoria.Manutenção.ComponentesDeCusto
{
    public partial class BaseListagem : Apresentação.Formulários.BaseInferior
    {
        public BaseListagem()
        {
            InitializeComponent();
        }

        protected override void AoExibir()
        {
            base.AoExibir();

            lista.CarregarTodosComponentes();
        }

        private void lista_ClicouAdicionar(object sender, EventArgs e)
        {
            JanelaEditarComponenteCusto janela = new JanelaEditarComponenteCusto();
            
            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                // Adiciona novo componente
                ComponenteCusto novoComponente = new ComponenteCusto();
                novoComponente.Código = janela.Código;
                novoComponente.Valor = janela.Valor;
                novoComponente.Nome = janela.Nome;

                if (janela.Referência == null)
                    novoComponente.MultiplicarComponenteCusto = null;
                else
                    novoComponente.MultiplicarComponenteCusto = janela.Referência.Código;

                novoComponente.Cadastrar();

                // Recarrega
                lista.CarregarTodosComponentes();
            }
        }

        private void lista_ClicouExcluir(object sender, EventArgs e)
        {
            ComponenteCusto entidade = lista.Selecionado;

            if (entidade == null)
            {
                MessageBox.Show("Selecione um componente antes", "Nada selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("Realmente apagar " + entidade.ToString() + " ? ", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                    == DialogResult.Yes)
                {
                    // Apaga!
                    entidade.Descadastrar();
                    lista.CarregarTodosComponentes();
                }
            }
        }

        private void lista_ClicouAlterar(object sender, EventArgs e)
        {
            Apresentação.Formulários.AguardeDB.Mostrar();
            JanelaEditarComponenteCusto janela = new JanelaEditarComponenteCusto();
            ComponenteCusto entidade = lista.Selecionado;

            if (entidade == null)
                return;

            // Modo alteração
            janela.ModoAtual = JanelaEditarComponenteCusto.Modo.Alteração;
            janela.Código = entidade.Código;
            janela.Referência = ComponenteCusto.Obter(entidade.MultiplicarComponenteCusto);
            janela.Valor = entidade.Valor;
            janela.Nome = entidade.Nome;

            Apresentação.Formulários.AguardeDB.Fechar();

            if (janela.ShowDialog(this) == DialogResult.OK)
            {
                Apresentação.Formulários.AguardeDB.Mostrar();

                // altera componente
                if (janela.Referência == null)
                    entidade.MultiplicarComponenteCusto = null;
                else
                    entidade.MultiplicarComponenteCusto = janela.Referência.Código;

                entidade.Nome = janela.Nome;
                entidade.Valor = janela.Valor;
                entidade.Atualizar();

                // Recarrega
                lista.CarregarTodosComponentes();
                Apresentação.Formulários.AguardeDB.Fechar();
            }
        }
    }
}
