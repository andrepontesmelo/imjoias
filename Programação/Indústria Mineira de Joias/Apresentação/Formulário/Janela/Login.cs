using Acesso.Comum;
using Entidades.Pessoa;
using Entidades.Privil�gio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Apresenta��o.Formul�rios
{
    public sealed class Login : JanelaExplicativa
	{
		private Label lblUsu�rio;
		private TextBox txtUsu�rio;
		private Label lblSenha;
		private TextBox txtSenha;
		private Button cmdOK;
		private Button cmdCancelar;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Somente a pr�pria classe pode se instanciar
		/// </summary>
		private Login() : base(false)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            if (Environment.UserName != null)
                txtUsu�rio.Text = Environment.UserName;
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
            this.lblUsu�rio = new System.Windows.Forms.Label();
            this.txtUsu�rio = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(205, 20);
            this.lblT�tulo.Text = "Identifica��o de Usu�rio";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Por favor, entre com o seu nome de usu�rio e sua senha pessoa para obter acesso a" +
                "o sistema.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // lblUsu�rio
            // 
            this.lblUsu�rio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsu�rio.AutoSize = true;
            this.lblUsu�rio.Location = new System.Drawing.Point(80, 106);
            this.lblUsu�rio.Name = "lblUsu�rio";
            this.lblUsu�rio.Size = new System.Drawing.Size(46, 13);
            this.lblUsu�rio.TabIndex = 3;
            this.lblUsu�rio.Text = "Usu�rio:";
            // 
            // txtUsu�rio
            // 
            this.txtUsu�rio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUsu�rio.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUsu�rio.Location = new System.Drawing.Point(144, 104);
            this.txtUsu�rio.Name = "txtUsu�rio";
            this.txtUsu�rio.Size = new System.Drawing.Size(144, 20);
            this.txtUsu�rio.TabIndex = 4;
            this.txtUsu�rio.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsu�rio_Validating);
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
            this.Controls.Add(this.txtUsu�rio);
            this.Controls.Add(this.lblUsu�rio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ind�stria Mineira de Joias";
            this.Controls.SetChildIndex(this.lblUsu�rio, 0);
            this.Controls.SetChildIndex(this.txtUsu�rio, 0);
            this.Controls.SetChildIndex(this.lblSenha, 0);
            this.Controls.SetChildIndex(this.txtSenha, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        /// <summary>
        /// </summary>
        /// <returns>Falso se usu�rio cancelou</returns>
        public static bool EfetuarLogin(Usu�rios usu�rios, Splash splash)
        {
#pragma warning disable 0162            
#if DEBUG

            Usu�rios.Usu�rioAtual = usu�rios.EfetuarLogin("root", "!root");
            return true;
#endif


            bool conectado = false;
            // Constr�i janela de login
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
                                splash.Mensagem = "Autenticando usu�rio";

                            try
                            {
                                Usu�rios.Usu�rioAtual = usu�rios.EfetuarLogin(loginDlg.txtUsu�rio.Text, loginDlg.txtSenha.Text);

                                if (Usu�rios.Usu�rioAtual == null)
                                    MessageBox.Show("Senha ou usu�rio incorreto!",
                                        "Ind�stria Mineira de Joias",
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
                                    splash.Mensagem = "N�o foi poss�vel autenticar usu�rio";

                                MessageBox.Show("N�o foi poss�vel autenticar usu�rio.\r\n\r\nOcorreu o seguinte erro: " + e.Message,
                                    "Ind�stria Mineira de Joias",
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
                Usu�rios.Usu�rioAtual.GerenciadorConex�es.Conex�oPresa += new GerenciadorConex�es.Conex�oPresaCallback(GerenciadorConex�es_Conex�oPresa);
#endif
                return true;
            }

#pragma warning restore 0162
        }

#if DEBUG
        static void GerenciadorConex�es_Conex�oPresa(string comando, TimeSpan tempoPassado, System.Diagnostics.StackTrace pilha)
        {
            Notifica��oSimples.Mostrar("Conex�o presa a " + tempoPassado.TotalSeconds.ToString() + " s",
                comando);

            if (tempoPassado.TotalSeconds > 10)
                MessageBox.Show(string.Format("Conex�o presa a {0} s\n\n{1}\n\n{2}",
                     tempoPassado.TotalSeconds,
                     comando, pilha.ToString()));
            else
                Console.WriteLine(pilha.ToString());
        }
#endif

		private void txtUsu�rio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (txtUsu�rio.Text.IndexOf(' ') >= 0)
			{
				LoginBal�oUsu�rioInv�lido dlg;

				e.Cancel = true;

				dlg = new LoginBal�oUsu�rioInv�lido();
				dlg.ShowBalloon(txtUsu�rio);
			}
		}

        public static bool LiberarRecurso(IWin32Window owner, Permiss�o privil�gios, string recurso, string descri��o)
        {
            if (Permiss�oFuncion�rio.ValidarPermiss�o(privil�gios))
                return true;

            return ExigirIdentifica��o(owner, privil�gios, Funcion�rio.Funcion�rioAtual, null, recurso, descri��o);
        }

        public static bool ExigirIdentifica��o(IWin32Window owner, Permiss�o privil�gios, Entidades.Pessoa.Pessoa autorizada, string t�tulo, string recurso, string descri��o)
        {
            using (Login dlg = new Login())
            {
                if ((Funcion�rio.Funcion�rioAtual.Privil�gios & privil�gios) == privil�gios)
                {
                    // Usu�rio atual j� tem permiss�o. Manda v�.
                    return true;
                }

                if (!Funcion�rio.�Funcion�rio(autorizada))
                {
                    dlg.txtUsu�rio.Text = Funcion�rio.Funcion�rioAtual.Usu�rio;
                    dlg.txtUsu�rio.ReadOnly = true;
                }
                else
                    dlg.txtUsu�rio.Text = "";

                dlg.lblT�tulo.Text = t�tulo ?? recurso;
                dlg.lblDescri��o.Text = descri��o;
                dlg.pic�cone.Image = Resource.cadeado_aberto;

                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    Funcion�rio super;

                    super = Funcion�rio.ObterFuncion�rioPorUsu�rioSemCache(dlg.txtUsu�rio.Text);

                    if (super == null)
                    {
                        MessageBox.Show(
                            owner,
                            "Usu�rio desconhecido.",
                            "Permiss�o negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if ((super.Privil�gios & privil�gios) != privil�gios)
                    {
                        MessageBox.Show(
                            owner,
                            "O usu�rio n�o possui privil�gios suficientes para liberar o(s) recurso(s) requisitado(s).",
                            "Permiss�o negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    try
                    {
                        using (IDbConnection conex�o = Acesso.Comum.Usu�rios.Usu�rioAtual.Usu�rios.Conectar(dlg.txtUsu�rio.Text, dlg.txtSenha.Text))
                        {
                            conex�o.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(
                            owner,
                            "N�o foi poss�vel autenticar usu�rio.",
                            "Permiss�o negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    using (JustificarLibera��oRecursos justificativa = new JustificarLibera��oRecursos(autorizada, super.Nome, recurso))
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
                                    "Permiss�o negada",
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
                                    if (autorizada.C�digo != super.C�digo)
                                    {
                                        autorizada.RegistrarHist�rico(
                                            string.Format("Recurso \"{0}\" autorizado por {1} {2}.",
                                            recurso, super.Nome, strJustificativa));

                                        super.RegistrarHist�rico(
                                            string.Format("Autorizou {0} o uso do recurso \"{1}\" {2}.",
                                            autorizada.Nome, recurso, strJustificativa));
                                    }
                                    else
                                        autorizada.RegistrarHist�rico(
                                            string.Format("Recurso \"{0}\" utilizado {1}.",
                                            recurso, strJustificativa));
                                }
                                catch
                                {
                                    MessageBox.Show(
                                        owner,
                                        "N�o foi poss�vel registrar no hist�rico a autoriza��o.",
                                        "Permiss�o negada",
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
        /// Exige identifica��o de usu�rio.
        /// </summary>
        /// <param name="t�tulo">T�tulo da janela.</param>
        /// <param name="descri��o">Descri��o da janela, instruindo o usu�rio.</param>
        /// <returns>Autoriza��o concedida.</returns>
        public static bool ExigirIdentifica��o(IWin32Window owner, string t�tulo, string descri��o)
        {
            using (Login dlg = new Login())
            {
                dlg.txtUsu�rio.Text = Funcion�rio.Funcion�rioAtual.Usu�rio;
                dlg.txtUsu�rio.ReadOnly = true;

                dlg.lblT�tulo.Text = t�tulo;
                dlg.lblDescri��o.Text = descri��o;
                dlg.pic�cone.Image = Resource.cadeado_aberto;

                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    Funcion�rio super;

                    super = Funcion�rio.ObterFuncion�rioPorUsu�rioSemCache(dlg.txtUsu�rio.Text);

                    if (super == null)
                    {
                        MessageBox.Show(
                            owner,
                            "Usu�rio desconhecido.",
                            "Permiss�o negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    try
                    {
                        using (IDbConnection conex�o = Acesso.Comum.Usu�rios.Usu�rioAtual.Usu�rios.Conectar(dlg.txtUsu�rio.Text, dlg.txtSenha.Text))
                        {
                            conex�o.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(
                            owner,
                            "N�o foi poss�vel autenticar usu�rio.",
                            "Permiss�o negada",
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
