using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Cadastro
{
    public partial class Classificador : UserControl, Apresentação.Formulários.IPósCargaSistema
    {
        /// <summary>
        /// Define se deve ser exibido somente as
        /// classificações atribuídas.
        /// </summary>
        private bool mostrarSomenteAtribuídos = true;

        /// <summary>
        /// Define se o classificador está sendo carregado,
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
        /// Constrói o classificador.
        /// </summary>
        public Classificador()
        {
            InitializeComponent();
        }

        #region Propriedades

        /// <summary>
        /// Define se deve ser exibido somente as
        /// classificações atribuídas.
        /// </summary>
        [Description("Define se deve ser exibido apenas as classificações atribuídas."),
        DefaultValue(true)]
        public bool MostrarSomenteAtribuídos
        {
            get { return mostrarSomenteAtribuídos; }
            set
            {
                mostrarSomenteAtribuídos = value;
                btnSomenteAtribuídos.Checked = value;
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
        public Classificação Seleção
        {
            get
            {
                if (chkLst.SelectedItem != null)
                    return (Classificação)chkLst.SelectedItem;
                else
                    return null;
            }
        }

        #endregion

        /// <summary>
        /// Ocorre quando usuário clica nas opções de exibição.
        /// </summary>
        private void AoMudarExibição(object sender, EventArgs e)
        {
            if (sender == btnMostrarTodos)
                btnSomenteAtribuídos.Checked = !btnMostrarTodos.Checked;
            else
                btnMostrarTodos.Checked = !btnSomenteAtribuídos.Checked;

            MostrarSomenteAtribuídos = btnSomenteAtribuídos.Checked;
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
                    if (mostrarSomenteAtribuídos)
                        MostrarDadosAtribuídos();
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
        /// Mostra somente os dados atribuídos da pessoa.
        /// </summary>
        private void MostrarDadosAtribuídos()
        {
            chkLst.Items.Clear();

            if (pessoa != null)
            {
                Classificação[] classificações;

                classificações = Classificação.ObterClassificações(pessoa.Classificações);

                foreach (Classificação classificação in classificações)
                {
                    if (classificação != null)
                        chkLst.Items.Add(classificação, true);
                }
            }
        }

        /// <summary>
        /// Mostra todas as classificações possíveis,
        /// marcadas aquelas atribuídas à pessoa.
        /// </summary>
        private void MostrarDadosCompletos()
        {
            Classificação[] classificações;

            chkLst.Items.Clear();

            if (pessoa != null)
            {
                classificações = Classificação.ObterClassificações();

                foreach (Classificação classificação in classificações)
                    chkLst.Items.Add(classificação, classificação.AtribuídoA(pessoa));
            }
        }

        /// <summary>
        /// Ocorre ao mudar a marcação.
        /// </summary>
        private void AoMudarMarcação(object sender, ItemCheckEventArgs e)
        {
            if (!carregando)
            {
                if (pessoa != null)
                {
                    Classificação classificação;

                    classificação = (Classificação)chkLst.Items[e.Index];
                    classificação.DefinirAtribuição(pessoa, (e.NewValue == CheckState.Checked));
                }

                if (autoAtualizarBD && pessoa.Cadastrado)
                    pessoa.AtualizarClassificação();
            }
        }

        public void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            btnEditar.Visible = 
                btnNova.Visible =
                toolStripSeparator1.Visible =
                chkLst.Enabled = 
                Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroEditar);
        }

        /// <summary>
        /// Usuário clica em criar nova classificação.
        /// </summary>
        private void CriarNova(object sender, EventArgs e)
        {
            using (EditarClassificação dlg = new EditarClassificação())
            {
                DialogResult resultado = dlg.ShowDialog(this.ParentForm);
                
                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        dlg.Classificação.Cadastrar();
                        chkLst.Items.Add(dlg.Classificação);
                    }
                    catch (Exception erro)
                    {
                        /* O cadastro pode retornar exceção caso
                         * o limite de classificadores seja atingido.
                         * 
                         * No momento da concepção do classificador, foi
                         * utilizado o tipo inteiro sem sinal de 64 bits,
                         * limitando, portanto, a 63 diferentes
                         * classificadores possíveis.
                         * 
                         * -- Júlio, 12/07/2006
                         */
                        MessageBox.Show(this.ParentForm,
                            erro.Message,
                            "Criar nova classificação",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Usuário edita uma classificação já existente.
        /// </summary>
        private void EditarClassificação(object sender, EventArgs e)
        {
            if (Seleção == null)
                return;

            using (EditarClassificação dlg = new EditarClassificação(Seleção))
            {
                if (dlg.ShowDialog(this.ParentForm) == DialogResult.OK)
                    if (dlg.Classificação.Cadastrado)
                    {
                        dlg.Classificação.Atualizar();
                        chkLst.Refresh();
                    }
                    else
                    {
                        dlg.Classificação.Cadastrar();
                        chkLst.Items.Add(dlg.Classificação);
                    }

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Seleção == null)
                return;

            if (Seleção.Sistema)
            {
                MessageBox.Show(this,
                    "Esta é uma classificação do sistema - e não pode ser removida",
                    "Operação não permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            List<Entidades.Pessoa.Pessoa> pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(Seleção);
            ExclusãoClassificação janela = new ExclusãoClassificação();
            
            janela.Carregar(Seleção, pessoas);
            janela.ShowDialog(this);
            
            MostrarDados();
        }
    }
}

