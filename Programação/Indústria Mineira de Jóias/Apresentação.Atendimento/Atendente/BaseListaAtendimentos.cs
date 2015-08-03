using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;
using Entidades;
using Entidades.Pessoa;
using Apresentação.Atendimento.Clientes;
using Entidades.Configuração;

namespace Apresentação.Atendimento.Atendente
{
    public partial class BaseListaAtendimentos : BaseSeleçãoClienteSetor
    {
        public BaseListaAtendimentos()
        {
            InitializeComponent();
        }

        protected override void  CarregarDados()
        {
            if (!bgRecuperarVisitantes.IsBusy)
            {
                SinalizaçãoCarga.Sinalizar(
                    listaPessoas,
                    "Carregando...",
                    "Aguarde enquanto o sistema carrega a lista de visitantes.");

                bgRecuperarVisitantes.RunWorkerAsync();
            }

            próximaCarga = DadosGlobais.Instância.HoraDataAtual.Add(validadeCarga);
        }

        private void bgRecuperarVisitantes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (listaDatasRelevantes.Itens.Count == 0)
            {
                /*
                 * Obter datas relevantes.
                 */
                DAdicionarDataRelevante métodoAdicionarDataRelevante = new DAdicionarDataRelevante(AdicionarDatasRelevantes);
                DataRelevante[] datas;

                foreach (Setor setor in setores)
                {
                    datas = DataRelevante.ObterPróximasDatasRelevantes(setor);
                    listaDatasRelevantes.BeginInvoke(métodoAdicionarDataRelevante, new object[] { datas });
                }

                datas = DataRelevante.ObterPróximasDatasRelevantes(Setor.ObterSetor(Setor.SetorSistema.NãoEspecificado));
                listaDatasRelevantes.BeginInvoke(métodoAdicionarDataRelevante, new object[] { datas });
            }

            e.Result = Visita.ObterVisitasRelevantes(Funcionário.FuncionárioAtual, setores);
        }

        private void bgRecuperarVisitantes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listaPessoas.Itens.Clear();

            if (e.Result != null)
            {
                foreach (Visita visita in (Visita[])e.Result)
                    listaPessoas.Itens.Add(visita);
            }

            SinalizaçãoCarga.Dessinalizar(listaPessoas);
        }

        protected override void listaPessoas_PessoaSelecionada(Apresentação.Atendimento.Comum.ListaPessoasItem item)
        {
            Visita visita = ((ListaPessoasVisitante)item).Visita;

            if (visita.Pessoas.ContarElementos() == 1 && visita.Nomes.ContarElementos() == 0)
                DispararEscolha(visita.Pessoas.ExtrairElementos()[0]);
            else
            {
                if (visita.Nomes.ContarElementos() == 1 && visita.Pessoas.ContarElementos() == 0)
                {
                    using (QuestionarNomeVisitante dlg = new QuestionarNomeVisitante(visita.Nomes.ExtrairElementos()[0]))
                    {
                        if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        {
                            Entidades.Pessoa.Pessoa pessoa = dlg.Pessoa;

                            if (pessoa != null)
                                DispararEscolha(pessoa);
                        }
                    }
                }
                else
                {
                    ResolverVisitante resolução = new ResolverVisitante(visita);
                    resolução.Escolhido += new EscolhaPessoa(resolução_Escolhido);
                    SubstituirBase(new ResolverVisitante(visita));
                }
            }
        }

        void resolução_Escolhido(Entidades.Pessoa.Pessoa pessoa)
        {
            DispararEscolha(pessoa);
        }

        private void opçãoHistóricoAtendimentos_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseInfoAtendimentos());
        }
    }
}
