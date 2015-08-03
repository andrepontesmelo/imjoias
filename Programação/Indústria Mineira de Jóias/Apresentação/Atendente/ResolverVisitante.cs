using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades;
using Apresentação.Atendimento.Clientes;

namespace Apresentação.Atendimento.Atendente
{
    /// <summary>
    /// Resolve questão de escolha de cadastro para um
    /// visitante com acompanhantes.
    /// </summary>
    public partial class ResolverVisitante : BaseInferior
    {
        private Visita visita;

        public event Apresentação.Atendimento.Clientes.BaseSeleçãoCliente.EscolhaPessoa Escolhido;

        public ResolverVisitante(Visita visita)
        {
            InitializeComponent();

            this.visita = visita;

            foreach (Entidades.Pessoa.Pessoa pessoa in visita.Pessoas.ExtrairElementos())
                listaPessoas.Itens.Add(pessoa);

            foreach (string nome in visita.Nomes.ExtrairElementos())
                listaPessoas.Itens.Add(nome, "", "Não cadastrado");
        }

        private void listaPessoas_PessoaSelecionada(Apresentação.Atendimento.Comum.ListaPessoasItem item)
        {
            if (item is ListaEntidadePessoaItem)
                Escolhido(((ListaEntidadePessoaItem)item).Pessoa);
            else
                using (QuestionarNomeVisitante dlg = new QuestionarNomeVisitante(item.Primária))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                    {
                        Entidades.Pessoa.Pessoa pessoa = dlg.Pessoa;

                        if (pessoa != null)
                            Escolhido(pessoa);
                    }
                }
        }
    }
}
