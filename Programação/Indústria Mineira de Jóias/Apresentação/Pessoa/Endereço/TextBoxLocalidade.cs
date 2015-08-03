using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários.Consultas;
using Entidades.Pessoa.Endereço;
using Apresentação.Formulários;
using System.Reflection;
using Entidades;

namespace Apresentação.Pessoa.Endereço
{
    /// <summary>
    /// TextBox para entrada de localidade.
    /// </summary>
    public partial class TextBoxLocalidade : TextBoxEndereçoBase
    {
        private Localidade localidade;

        private Acesso.Comum.DbManipulação.DbManipulaçãoCancelávelHandler antesDeCadastrarCallback;

        [Browsable(false), DefaultValue(null), ReadOnly(true)]
        public override Localidade Localidade
        {
            get
            {
                if (localidade == null)
                    CriarNovaLocalidade();

                return localidade;
            }
            set
            {
                if (localidade != null)
                    localidade.AntesDeCadastrar -= antesDeCadastrarCallback;

                localidade = value;

                if (value == null)
                    TextBox.Text = "";
                else
                {
                    TextBox.Text = value.Nome;
                    Estado = value.Estado;
                    localidade.AntesDeCadastrar += antesDeCadastrarCallback;
                }
            }
        }

        public TextBoxLocalidade()
        {
            antesDeCadastrarCallback = new Acesso.Comum.DbManipulação.DbManipulaçãoCancelávelHandler(AntesDeCadastrarLocalidade);
        }

        protected override bool NecessárioPesquisar()
        {
            if (localidade == null || localidade.Nome != TextBox.Text)
            {
                if (localidade != null && localidade.Nome != null && localidade.Nome.Trim().Length > 0)
                    CriarNovaLocalidadeSimples();
                else
                    localidade = null;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Procura pela cidade no banco de dados.
        /// </summary>
        protected override void bgRecuperação_DoWork(object sender, DoWorkEventArgs e)
        {
            Localidade[] localidades;

            //localidades = Localidade.ObterLocalidades(TextBox.Text);
            localidades = Localidade.ObterLocalidades(TextBox.Text, true);

            e.Result = localidades;
        }

        protected override void bgRecuperação_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Localidade[] localidades = (Localidade[])e.Result;

            if (localidades == null || localidades.Length != 1)
            {
                CriarNovaLocalidade();

                if (TxtEstado != null && TxtEstado.ReadOnly)
                    TxtEstado.Estado = null;

                if (TxtPaís != null && TxtPaís.ReadOnly)
                    TxtPaís.País = null;
            }
            else // if (localidades.Length == 1)
                Localidade = localidades[0];

            DispararAoAlterar();
        }

        /// <summary>
        /// Cria uma nova localidade.
        /// </summary>
        private void CriarNovaLocalidade()
        {
            if (bgRecuperação.IsBusy)
                bgRecuperação.CancelAsync();

            CriarNovaLocalidadeSimples();
        }

        private void CriarNovaLocalidadeSimples()
        {
            string nome = TextBox.Text.Trim();

            if (nome.Length > 0)
            {
                localidade = new Localidade();
                localidade.Nome = nome;
            }
            else
                localidade = new Localidade();

            if (TxtEstado != null)
                localidade.Estado = TxtEstado.Estado;

            localidade.AntesDeCadastrar += antesDeCadastrarCallback;
        }

        /// <summary>
        /// Requisita dados do usuário para efetivar cadastro da localidade.
        /// </summary>
        /// <param name="entidade">Entidade a ser cadastrada.</param>
        /// <param name="cancelar">Se a operação deverá ser cancelada.</param>
        private void AntesDeCadastrarLocalidade(Acesso.Comum.DbManipulação entidade, out bool cancelar)
        {
            Localidade localidade = (Localidade)entidade;
            bool ignorarCadastro = false;
            
            if (bgRecuperação.IsBusy)
                bgRecuperação.CancelAsync();

            AguardeDB.Mostrar();

            try
            {
                if (localidade.Estado == null && TxtEstado != null && TxtEstado.Estado != null)
                    localidade.Estado = TxtEstado.Estado;

                // Vamos verificar se realmente não existe a localidade.
                if (localidade.Estado != null)
                {
                    Localidade aux = Localidade.ObterLocalidade(localidade.Estado, localidade.Nome);

                    if (aux != null)
                    {
                        /* Vamos copiar a entidade no lugar desta.
                         * Isto só é possível devido à verificação forçada
                         * de "Cadastrado" inserido no método Cadastrar(IDbCommand)
                         * em Localidade (veja comentário lá).
                         * -- Júlio, 23/09/2006
                         */
                        foreach (FieldInfo campo in Localidade.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                           | System.Reflection.BindingFlags.Public))
                        {
                            campo.SetValue(localidade, campo.GetValue(aux));
                        }

                        ignorarCadastro = true;
                    }
                    else
                    {
                        // Vamos verificar se não houve erro de grafia.
                        Localidade[] todas = Localidade.ObterLocalidades(localidade.Estado);
                        List<Localidade> semelhantes = new List<Localidade>();
                        int minDist = Math.Max(2, localidade.Nome.Length / 4);

                        foreach (Localidade l in todas)
                            if (DistânciaLevenshtein.CalcularDistância(localidade.Nome, l.Nome) <= minDist)
                                semelhantes.Add(l);

                        if (semelhantes.Count > 0)
                            QuestionarSemelhantes(localidade, out ignorarCadastro, semelhantes.ToArray());
                    }
                }

                // Vamos verificar se o nome não está incorreto.
                if (!ignorarCadastro)
                {
                    Localidade[] aux = Localidade.ObterLocalidades(localidade.Nome);

                    if (aux.Length > 0)
                        QuestionarSemelhantes(localidade, out ignorarCadastro, aux);
                }
            }
            finally
            {
                AguardeDB.Fechar();
            }

            if (!ignorarCadastro)
            {
                using (EditarLocalidade dlg = new EditarLocalidade(localidade))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                    {
                        Localidade = dlg.Localidade;
                        cancelar = false;

                        System.Diagnostics.Debug.Assert(Localidade == entidade);
                    }
                    else
                        cancelar = true;
                }
            }
            else
                cancelar = false;
        }

        /// <summary>
        /// Questiona ao usuário se a localidade a ser cadastrada
        /// encontra-se na lista de localidades semelhantes.
        /// </summary>
        /// <param name="localidade">Localidade a ser cadastrada.</param>
        /// <param name="ignorarCadastro">Se o cadastro deve ser ignorado.</param>
        /// <param name="aux">Vetor de localidades semelhantes.</param>
        private void QuestionarSemelhantes(Localidade localidade, out bool ignorarCadastro, Localidade[] aux)
        {
            AguardeDB.Suspensão(true);

            MessageBox.Show(
                ParentForm,
                "Foram encontradas uma ou mais localidades com nome semelhante a " + localidade.Nome + ".\n\nPor favor, verifique se a localidade desejada encontra-se na lista que irá ser exibida a seguir. Caso a encontre, escolha-a e pressione \"OK\". Caso contrário, pressione \"Cancelar\" para iniciar o processo de cadastramento de localidade.",
                "Localidade", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (ListarLocalidades dlg = new ListarLocalidades(aux))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    // Copia o cadastro...
                    foreach (FieldInfo campo in Localidade.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                        | System.Reflection.BindingFlags.Public))
                    {
                        campo.SetValue(localidade, campo.GetValue(dlg.Seleção));
                    }

                    ignorarCadastro = true;
                }
                else
                    ignorarCadastro = false;
            }

            AguardeDB.Suspensão(false);
        }

        /// <summary>
        /// Ocorre quando usuário clica em procurar.
        /// </summary>
        protected override void AoClicarBtnProcurar(object sender, EventArgs e)
        {
            if (Text.Trim().Length > 3)
            {
                Localidade[] localidades;

                AguardeDB.Mostrar();

                try
                {
                    localidades = Localidade.ObterLocalidades(Text);
                }
                finally
                {
                    AguardeDB.Fechar();
                }

                using (ListarLocalidades dlg = new ListarLocalidades(localidades))
                {
                    if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                    {
                        Localidade = dlg.Seleção;
                        DispararAoAlterar();
                    }
                    else
                        base.AoClicarBtnProcurar(sender, e);
                }
            }
            else
                base.AoClicarBtnProcurar(sender, e);
        }
    }
}
