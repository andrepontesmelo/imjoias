using Apresentação.Formulários;
using Entidades;
using Entidades.Pessoa.Endereço;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

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
            Localidade[] localidades = Localidade.ObterLocalidades(TextBox.Text, true);

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
            else 
                Localidade = localidades[0];

            DispararAoAlterar();
        }

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

                ignorarCadastro = VerificarLocalidadeNãoExistente(localidade, ignorarCadastro);
                ignorarCadastro = VerificarNomeIncorreto(localidade, ignorarCadastro);
            }
            finally
            {
                AguardeDB.Fechar();
            }

            if (!ignorarCadastro)
                cancelar = AbrirJanelaCadastrarLocalidade(entidade, localidade);
            else
                cancelar = false;
        }

        private bool AbrirJanelaCadastrarLocalidade(Acesso.Comum.DbManipulação entidade, Localidade localidade)
        {
            bool cancelar;
            using (EditarLocalidade dlg = new EditarLocalidade(localidade))
            {
                AguardeDB.Suspensão(true);
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    Localidade = dlg.Localidade;
                    cancelar = false;

                    System.Diagnostics.Debug.Assert(Localidade == entidade);
                }
                else
                    cancelar = true;
                AguardeDB.Suspensão(false);
            }

            return cancelar;
        }

        private bool VerificarNomeIncorreto(Localidade localidade, bool ignorarCadastro)
        {
            if (!ignorarCadastro)
            {
                Localidade[] aux = null;

                if (localidade.Nome != null)
                    aux = Localidade.ObterLocalidades(localidade.Nome);

                if (aux != null && aux.Length > 0)
                    QuestionarSemelhantes(localidade, out ignorarCadastro, aux);
            }

            return ignorarCadastro;
        }

        private bool VerificarLocalidadeNãoExistente(Localidade localidade, bool ignorarCadastro)
        {
            if (localidade.Estado != null)
            {
                Localidade localidadeRecemObtida = Localidade.ObterLocalidade(localidade.Estado, localidade.Nome);

                if (localidadeRecemObtida != null)
                {
                    foreach (FieldInfo campo in Localidade.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                       | BindingFlags.Public))
                    {
                        campo.SetValue(localidade, campo.GetValue(localidadeRecemObtida));
                    }

                    ignorarCadastro = true;
                }
                else if (localidade.Nome != null)
                {
                    ignorarCadastro = VerificarErroGrafia(localidade, ignorarCadastro);
                }
            }

            return ignorarCadastro;
        }

        private bool VerificarErroGrafia(Localidade localidade, bool ignorarCadastro)
        {
            Localidade[] todas = Localidade.ObterLocalidades(localidade.Estado);
            List<Localidade> semelhantes = new List<Localidade>();
            int minDist = Math.Max(2, localidade.Nome.Length / 4);

            foreach (Localidade l in todas)
                if (DistânciaLevenshtein.CalcularDistância(localidade.Nome, l.Nome) <= minDist)
                    semelhantes.Add(l);

            if (semelhantes.Count > 0)
                QuestionarSemelhantes(localidade, out ignorarCadastro, semelhantes.ToArray());
            return ignorarCadastro;
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

            MostrarMensagemLocalidadesSemelhantes(localidade);

            using (ListarLocalidades dlg = new ListarLocalidades(aux))
            {
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    CopiaCadastro(localidade, dlg);
                    ignorarCadastro = true;
                }
                else
                    ignorarCadastro = false;
            }

            AguardeDB.Suspensão(false);
        }

        private void MostrarMensagemLocalidadesSemelhantes(Localidade localidade)
        {
            MessageBox.Show(
                ParentForm,
                "Foram encontradas uma ou mais localidades com nome semelhante a " + localidade.Nome + ".\n\nPor favor, verifique se a localidade desejada encontra-se na lista que irá ser exibida a seguir. Caso a encontre, escolha-a e pressione \"OK\". Caso contrário, pressione \"Cancelar\" para iniciar o processo de cadastramento de localidade.",
                "Localidade", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopiaCadastro(Localidade localidade, ListarLocalidades dlg)
        {
            foreach (FieldInfo campo in Localidade.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                campo.SetValue(localidade, campo.GetValue(dlg.Seleção));
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
