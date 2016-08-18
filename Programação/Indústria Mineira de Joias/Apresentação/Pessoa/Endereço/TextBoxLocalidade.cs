using Apresenta��o.Formul�rios;
using Entidades;
using Entidades.Pessoa.Endere�o;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Apresenta��o.Pessoa.Endere�o
{
    /// <summary>
    /// TextBox para entrada de localidade.
    /// </summary>
    public partial class TextBoxLocalidade : TextBoxEndere�oBase
    {
        private Localidade localidade;

        private Acesso.Comum.DbManipula��o.DbManipula��oCancel�velHandler antesDeCadastrarCallback;

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
            antesDeCadastrarCallback = new Acesso.Comum.DbManipula��o.DbManipula��oCancel�velHandler(AntesDeCadastrarLocalidade);
        }

        protected override bool Necess�rioPesquisar()
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
        protected override void bgRecupera��o_DoWork(object sender, DoWorkEventArgs e)
        {
            Localidade[] localidades = Localidade.ObterLocalidades(TextBox.Text, true);

            e.Result = localidades;
        }

        protected override void bgRecupera��o_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Localidade[] localidades = (Localidade[])e.Result;

            if (localidades == null || localidades.Length != 1)
            {
                CriarNovaLocalidade();

                if (TxtEstado != null && TxtEstado.ReadOnly)
                    TxtEstado.Estado = null;

                if (TxtPa�s != null && TxtPa�s.ReadOnly)
                    TxtPa�s.Pa�s = null;
            }
            else 
                Localidade = localidades[0];

            DispararAoAlterar();
        }

        private void CriarNovaLocalidade()
        {
            if (bgRecupera��o.IsBusy)
                bgRecupera��o.CancelAsync();

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
        /// Requisita dados do usu�rio para efetivar cadastro da localidade.
        /// </summary>
        /// <param name="entidade">Entidade a ser cadastrada.</param>
        /// <param name="cancelar">Se a opera��o dever� ser cancelada.</param>
        private void AntesDeCadastrarLocalidade(Acesso.Comum.DbManipula��o entidade, out bool cancelar)
        {
            Localidade localidade = (Localidade)entidade;
            bool ignorarCadastro = false;
            
            if (bgRecupera��o.IsBusy)
                bgRecupera��o.CancelAsync();

            AguardeDB.Mostrar();

            try
            {
                if (localidade.Estado == null && TxtEstado != null && TxtEstado.Estado != null)
                    localidade.Estado = TxtEstado.Estado;

                ignorarCadastro = VerificarLocalidadeN�oExistente(localidade, ignorarCadastro);
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

        private bool AbrirJanelaCadastrarLocalidade(Acesso.Comum.DbManipula��o entidade, Localidade localidade)
        {
            bool cancelar;
            using (EditarLocalidade dlg = new EditarLocalidade(localidade))
            {
                AguardeDB.Suspens�o(true);
                if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    Localidade = dlg.Localidade;
                    cancelar = false;

                    System.Diagnostics.Debug.Assert(Localidade == entidade);
                }
                else
                    cancelar = true;
                AguardeDB.Suspens�o(false);
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

        private bool VerificarLocalidadeN�oExistente(Localidade localidade, bool ignorarCadastro)
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
                if (Dist�nciaLevenshtein.CalcularDist�ncia(localidade.Nome, l.Nome) <= minDist)
                    semelhantes.Add(l);

            if (semelhantes.Count > 0)
                QuestionarSemelhantes(localidade, out ignorarCadastro, semelhantes.ToArray());
            return ignorarCadastro;
        }

        /// <summary>
        /// Questiona ao usu�rio se a localidade a ser cadastrada
        /// encontra-se na lista de localidades semelhantes.
        /// </summary>
        /// <param name="localidade">Localidade a ser cadastrada.</param>
        /// <param name="ignorarCadastro">Se o cadastro deve ser ignorado.</param>
        /// <param name="aux">Vetor de localidades semelhantes.</param>
        private void QuestionarSemelhantes(Localidade localidade, out bool ignorarCadastro, Localidade[] aux)
        {
            AguardeDB.Suspens�o(true);

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

            AguardeDB.Suspens�o(false);
        }

        private void MostrarMensagemLocalidadesSemelhantes(Localidade localidade)
        {
            MessageBox.Show(
                ParentForm,
                "Foram encontradas uma ou mais localidades com nome semelhante a " + localidade.Nome + ".\n\nPor favor, verifique se a localidade desejada encontra-se na lista que ir� ser exibida a seguir. Caso a encontre, escolha-a e pressione \"OK\". Caso contr�rio, pressione \"Cancelar\" para iniciar o processo de cadastramento de localidade.",
                "Localidade", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopiaCadastro(Localidade localidade, ListarLocalidades dlg)
        {
            foreach (FieldInfo campo in Localidade.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                campo.SetValue(localidade, campo.GetValue(dlg.Sele��o));
        }

        /// <summary>
        /// Ocorre quando usu�rio clica em procurar.
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
                        Localidade = dlg.Sele��o;
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
