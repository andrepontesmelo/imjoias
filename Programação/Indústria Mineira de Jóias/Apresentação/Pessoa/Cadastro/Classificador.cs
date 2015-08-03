using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa.Cadastro
{
    public partial class Classificador : UserControl, Apresenta��o.Formul�rios.IP�sCargaSistema
    {
        /// <summary>
        /// Define se deve ser exibido somente as
        /// classifica��es atribu�das.
        /// </summary>
        private bool mostrarSomenteAtribu�dos = true;

        /// <summary>
        /// Define se o classificador est� sendo carregado,
        /// impedindo que o banco de dados seja alterado.
        /// </summary>
        private bool carregando = false;

        /// <summary>
        /// Pessoa a ser classificada.
        /// </summary>
        private Entidades.Pessoa.Pessoa pessoa;

        /// <summary>
        /// Define se deve atualizar automaticamente o banco de dados.
        /// </summary>
        private bool autoAtualizarBD = true;


        /// <summary>
        /// Constr�i o classificador.
        /// </summary>
        public Classificador()
        {
            InitializeComponent();
        }

        #region Propriedades

        /// <summary>
        /// Define se deve ser exibido somente as
        /// classifica��es atribu�das.
        /// </summary>
        [Description("Define se deve ser exibido apenas as classifica��es atribu�das."),
        DefaultValue(true)]
        public bool MostrarSomenteAtribu�dos
        {
            get { return mostrarSomenteAtribu�dos; }
            set
            {
                mostrarSomenteAtribu�dos = value;
                btnSomenteAtribu�dos.Checked = value;
                btnMostrarTodos.Checked = !value;
                MostrarDados();
            }
        }

        /// <summary>
        /// Pessoa a ser classificada.
        /// </summary>
        public Entidades.Pessoa.Pessoa Pessoa
        {
            get { return pessoa; }
            set
            {
                pessoa = value;

                if (pessoa == null)
                    chkLst.Items.Clear();
                else
                    MostrarDados();
            }
        }

        /// <summary>
        /// Define se deve atualizar automaticamente o banco de dados.
        /// </summary>
        public bool AutoAtualizarBD { get { return autoAtualizarBD; } set { autoAtualizarBD = value; } }

        [Browsable(false)]
        public Classifica��o Sele��o
        {
            get
            {
                if (chkLst.SelectedItem != null)
                    return (Classifica��o)chkLst.SelectedItem;
                else
                    return null;
            }
        }

        #endregion

        /// <summary>
        /// Ocorre quando usu�rio clica nas op��es de exibi��o.
        /// </summary>
        private void AoMudarExibi��o(object sender, EventArgs e)
        {
            if (sender == btnMostrarTodos)
                btnSomenteAtribu�dos.Checked = !btnMostrarTodos.Checked;
            else
                btnMostrarTodos.Checked = !btnSomenteAtribu�dos.Checked;

            MostrarSomenteAtribu�dos = btnSomenteAtribu�dos.Checked;
        }

        /// <summary>
        /// Mostra dados da pessoa definida.
        /// </summary>
        private void MostrarDados()
        {
            if (!DesignMode)
            {
                carregando = true;

                try
                {
                    if (mostrarSomenteAtribu�dos)
                        MostrarDadosAtribu�dos();
                    else
                        MostrarDadosCompletos();
                }
                finally
                {
                    carregando = false;
                }
            }
        }

        /// <summary>
        /// Mostra somente os dados atribu�dos da pessoa.
        /// </summary>
        private void MostrarDadosAtribu�dos()
        {
            chkLst.Items.Clear();

            if (pessoa != null)
            {
                Classifica��o[] classifica��es;

                classifica��es = Classifica��o.ObterClassifica��es(pessoa.Classifica��es);

                foreach (Classifica��o classifica��o in classifica��es)
                {
                    if (classifica��o != null)
                        chkLst.Items.Add(classifica��o, true);
                }
            }
        }

        /// <summary>
        /// Mostra todas as classifica��es poss�veis,
        /// marcadas aquelas atribu�das � pessoa.
        /// </summary>
        private void MostrarDadosCompletos()
        {
            Classifica��o[] classifica��es;

            chkLst.Items.Clear();

            if (pessoa != null)
            {
                classifica��es = Classifica��o.ObterClassifica��es();

                foreach (Classifica��o classifica��o in classifica��es)
                    chkLst.Items.Add(classifica��o, classifica��o.Atribu�doA(pessoa));
            }
        }

        /// <summary>
        /// Ocorre ao mudar a marca��o.
        /// </summary>
        private void AoMudarMarca��o(object sender, ItemCheckEventArgs e)
        {
            if (!carregando)
            {
                if (pessoa != null)
                {
                    Classifica��o classifica��o;

                    classifica��o = (Classifica��o)chkLst.Items[e.Index];
                    classifica��o.DefinirAtribui��o(pessoa, (e.NewValue == CheckState.Checked));
                }

                if (autoAtualizarBD && pessoa.Cadastrado)
                    pessoa.AtualizarClassifica��o();
            }
        }

        public void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            btnEditar.Visible = 
                btnNova.Visible =
                toolStripSeparator1.Visible =
                chkLst.Enabled = 
                Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Entidades.Privil�gio.Permiss�o.CadastroEditar);
        }

        /// <summary>
        /// Usu�rio clica em criar nova classifica��o.
        /// </summary>
        private void CriarNova(object sender, EventArgs e)
        {
            using (EditarClassifica��o dlg = new EditarClassifica��o())
            {
                DialogResult resultado = dlg.ShowDialog(this.ParentForm);
                
                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        dlg.Classifica��o.Cadastrar();
                        chkLst.Items.Add(dlg.Classifica��o);
                    }
                    catch (Exception erro)
                    {
                        /* O cadastro pode retornar exce��o caso
                         * o limite de classificadores seja atingido.
                         * 
                         * No momento da concep��o do classificador, foi
                         * utilizado o tipo inteiro sem sinal de 64 bits,
                         * limitando, portanto, a 63 diferentes
                         * classificadores poss�veis.
                         * 
                         * -- J�lio, 12/07/2006
                         */
                        MessageBox.Show(this.ParentForm,
                            erro.Message,
                            "Criar nova classifica��o",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Usu�rio edita uma classifica��o j� existente.
        /// </summary>
        private void EditarClassifica��o(object sender, EventArgs e)
        {
            if (Sele��o == null)
                return;

            using (EditarClassifica��o dlg = new EditarClassifica��o(Sele��o))
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                    if (dlg.Classifica��o.Cadastrado)
                    {
                        dlg.Classifica��o.Atualizar();
                        chkLst.Refresh();
                    }
                    else
                    {
                        dlg.Classifica��o.Cadastrar();
                        chkLst.Items.Add(dlg.Classifica��o);
                    }

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Sele��o == null)
                return;

            if (Sele��o.Sistema)
            {
                MessageBox.Show(this,
                    "Esta � uma classifica��o do sistema - e n�o pode ser removida",
                    "Opera��o n�o permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(Sele��o);
            Exclus�oClassifica��o janela = new Exclus�oClassifica��o();
            
            janela.Carregar(Sele��o, pessoas);
            janela.ShowDialog(this);
            
            MostrarDados();
        }
    }
}

