using Acesso.Comum;
using Entidades.Pessoa;
using Entidades.Privilégio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public sealed class Login : JanelaExplicativa
	{
		private Label lblUsuário;
		private TextBox txtUsuário;
		private Label lblSenha;
		private TextBox txtSenha;
		private Button cmdOK;
		private Button cmdCancelar;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Somente a própria classe pode se instanciar
		/// </summary>
		private Login() : base(false)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            if (Environment.UserName != null)
                txtUsuário.Text = Environment.UserName;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblUsuário = new System.Windows.Forms.Label();
            this.txtUsuário = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(205, 20);
            this.lblTítulo.Text = "Identificação de Usuário";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Por favor, entre com o seu nome de usuário e sua senha pessoa para obter acesso a" +
                "o sistema.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // lblUsuário
            // 
            this.lblUsuário.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsuário.AutoSize = true;
            this.lblUsuário.Location = new System.Drawing.Point(80, 106);
            this.lblUsuário.Name = "lblUsuário";
            this.lblUsuário.Size = new System.Drawing.Size(46, 13);
            this.lblUsuário.TabIndex = 3;
            this.lblUsuário.Text = "Usuário:";
            // 
            // txtUsuário
            // 
            this.txtUsuário.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUsuário.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUsuário.Location = new System.Drawing.Point(144, 104);
            this.txtUsuário.Name = "txtUsuário";
            this.txtUsuário.Size = new System.Drawing.Size(144, 20);
            this.txtUsuário.TabIndex = 4;
            this.txtUsuário.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsuário_Validating);
            // 
            // lblSenha
            // 
            this.lblSenha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(80, 130);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 5;
            this.lblSenha.Text = "Senha:";
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSenha.Location = new System.Drawing.Point(144, 128);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(144, 20);
            this.txtSenha.TabIndex = 6;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(224, 157);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "&OK";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(305, 157);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 8;
            this.cmdCancelar.Text = "&Cancelar";
            // 
            // Login
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(392, 192);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtUsuário);
            this.Controls.Add(this.lblUsuário);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indústria Mineira de Joias";
            this.Controls.SetChildIndex(this.lblUsuário, 0);
            this.Controls.SetChildIndex(this.txtUsuário, 0);
            this.Controls.SetChildIndex(this.lblSenha, 0);
            this.Controls.SetChildIndex(this.txtSenha, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        /// <summary>
        /// </summary>
        /// <returns>Falso se usuário cancelou</returns>
        public static bool EfetuarLogin(Usuários usuários, Splash splash)
        {
#pragma warning disable 0162            
#if DEBUG

            Usuários.UsuárioAtual = usuários.EfetuarLogin("root", "!root");
            return true;
#endif


            bool conectado = false;
            // Constrói janela de login
            using (Login loginDlg = new Login())
            {
                do
                {
                    DialogResult resultado;

                    if (splash != null)
                        splash.Hide();

                    resultado = loginDlg.ShowDialog();

                    if (splash != null)
                        splash.Show();

                    switch (resultado)
                    {
                        case DialogResult.OK:
                            if (splash != null)
                                splash.Mensagem = "Autenticando usuário";

                            try
                            {
                                Usuários.UsuárioAtual = usuários.EfetuarLogin(loginDlg.txtUsuário.Text, loginDlg.txtSenha.Text);

                                if (Usuários.UsuárioAtual == null)
                                    MessageBox.Show("Senha ou usuário incorreto!",
                                        "Indústria Mineira de Joias",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                                else
                                {
                                    conectado = true;
                                }
                            }
                            catch (Exception e)
                            {
                                if (splash != null)
                                    splash.Mensagem = "Não foi possível autenticar usuário";

                                MessageBox.Show("Não foi possível autenticar usuário.\r\n\r\nOcorreu o seguinte erro: " + e.Message,
                                    "Indústria Mineira de Joias",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                            // Conectado!
                            break;

                        case DialogResult.Cancel:
                            return false;

                        default:
                            break;
                    }

                } while (!conectado);

#if DEBUG
                Usuários.UsuárioAtual.GerenciadorConexões.ConexãoPresa += new GerenciadorConexões.ConexãoPresaCallback(GerenciadorConexões_ConexãoPresa);
#endif
                return true;
            }

#pragma warning restore 0162
        }

#if DEBUG
        static void GerenciadorConexões_ConexãoPresa(string comando, TimeSpan tempoPassado, System.Diagnostics.StackTrace pilha)
        {
            NotificaçãoSimples.Mostrar("Conexão presa a " + tempoPassado.TotalSeconds.ToString() + " s",
                comando);

            if (tempoPassado.TotalSeconds > 10)
                MessageBox.Show(string.Format("Conexão presa a {0} s\n\n{1}\n\n{2}",
                     tempoPassado.TotalSeconds,
                     comando, pilha.ToString()));
            else
                Console.WriteLine(pilha.ToString());
        }
#endif

		private void txtUsuário_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (txtUsuário.Text.IndexOf(' ') >= 0)
			{
				LoginBalãoUsuárioInválido dlg;

				e.Cancel = true;

				dlg = new LoginBalãoUsuárioInválido();
				dlg.ShowBalloon(txtUsuário);
			}
		}

        public static bool LiberarRecurso(IWin32Window owner, Permissão privilégios, string recurso, string descrição)
        {
            if (PermissãoFuncionário.ValidarPermissão(privilégios))
                return true;

            return ExigirIdentificação(owner, privilégios, Funcionário.FuncionárioAtual, null, recurso, descrição);
        }

        public static bool ExigirIdentificação(IWin32Window owner, Permissão privilégios, Entidades.Pessoa.Pessoa autorizada, string título, string recurso, string descrição)
        {
            using (Login dlg = new Login())
            {
                if ((Funcionário.FuncionárioAtual.Privilégios & privilégios) == privilégios)
                {
                    // Usuário atual já tem permissão. Manda vê.
                    return true;
                }

                if (!Funcionário.ÉFuncionário(autorizada))
                {
                    dlg.txtUsuário.Text = Funcionário.FuncionárioAtual.Usuário;
                    dlg.txtUsuário.ReadOnly = true;
                }
                else
                    dlg.txtUsuário.Text = "";

                dlg.lblTítulo.Text = título ?? recurso;
                dlg.lblDescrição.Text = descrição;
                dlg.picÍcone.Image = Resource.cadeado_aberto;

                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    Funcionário super;

                    super = Funcionário.ObterFuncionárioPorUsuárioSemCache(dlg.txtUsuário.Text);

                    if (super == null)
                    {
                        MessageBox.Show(
                            owner,
                            "Usuário desconhecido.",
                            "Permissão negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if ((super.Privilégios & privilégios) != privilégios)
                    {
                        MessageBox.Show(
                            owner,
                            "O usuário não possui privilégios suficientes para liberar o(s) recurso(s) requisitado(s).",
                            "Permissão negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    try
                    {
                        using (IDbConnection conexão = Acesso.Comum.Usuários.UsuárioAtual.Usuários.Conectar(dlg.txtUsuário.Text, dlg.txtSenha.Text))
                        {
                            conexão.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(
                            owner,
                            "Não foi possível autenticar usuário.",
                            "Permissão negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    using (JustificarLiberaçãoRecursos justificativa = new JustificarLiberaçãoRecursos(autorizada, super.Nome, recurso))
                    {
                        bool senhaIncorreta;

                        do
                        {
                            senhaIncorreta = false;

                            if (justificativa.ShowDialog(owner) != DialogResult.OK)
                                return false;
                            else if (justificativa.Senha != dlg.txtSenha.Text)
                            {
                                MessageBox.Show(
                                    owner,
                                    "Senha incorreta!",
                                    "Permissão negada",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                senhaIncorreta = true;
                            }
                            else
                            {
                                string strJustificativa;

                                if (justificativa.Motivo.Trim().Length > 0)
                                    strJustificativa = "com a seguinte justificativa: \n\n" + justificativa.Motivo;
                                else
                                    strJustificativa = "sem apresentar justificativa.";

                                try
                                {
                                    if (autorizada.Código != super.Código)
                                    {
                                        autorizada.RegistrarHistórico(
                                            string.Format("Recurso \"{0}\" autorizado por {1} {2}.",
                                            recurso, super.Nome, strJustificativa));

                                        super.RegistrarHistórico(
                                            string.Format("Autorizou {0} o uso do recurso \"{1}\" {2}.",
                                            autorizada.Nome, recurso, strJustificativa));
                                    }
                                    else
                                        autorizada.RegistrarHistórico(
                                            string.Format("Recurso \"{0}\" utilizado {1}.",
                                            recurso, strJustificativa));
                                }
                                catch
                                {
                                    MessageBox.Show(
                                        owner,
                                        "Não foi possível registrar no histórico a autorização.",
                                        "Permissão negada",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        } while (senhaIncorreta);
                    }

                    return true;
                }
                else
                    return false;
            }
        }

            /// <summary>
        /// Exige identificação de usuário.
        /// </summary>
        /// <param name="título">Título da janela.</param>
        /// <param name="descrição">Descrição da janela, instruindo o usuário.</param>
        /// <returns>Autorização concedida.</returns>
        public static bool ExigirIdentificação(IWin32Window owner, string título, string descrição)
        {
            using (Login dlg = new Login())
            {
                dlg.txtUsuário.Text = Funcionário.FuncionárioAtual.Usuário;
                dlg.txtUsuário.ReadOnly = true;

                dlg.lblTítulo.Text = título;
                dlg.lblDescrição.Text = descrição;
                dlg.picÍcone.Image = Resource.cadeado_aberto;

                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    Funcionário super;

                    super = Funcionário.ObterFuncionárioPorUsuárioSemCache(dlg.txtUsuário.Text);

                    if (super == null)
                    {
                        MessageBox.Show(
                            owner,
                            "Usuário desconhecido.",
                            "Permissão negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    try
                    {
                        using (IDbConnection conexão = Acesso.Comum.Usuários.UsuárioAtual.Usuários.Conectar(dlg.txtUsuário.Text, dlg.txtSenha.Text))
                        {
                            conexão.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(
                            owner,
                            "Não foi possível autenticar usuário.",
                            "Permissão negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return true;
                }
                else
                    return false;
            }
        }
    }
}
