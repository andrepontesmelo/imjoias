using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Apresentação.Pessoa
{
	/// <summary>
	/// Controle para formatando a caixa de telefone.
	/// 3134220185 -> 10 dígitos  (31) 3422-0185
	/// 34220815 ->    8 digitos  3422-0185
	/// 0800151617  -> início de 0800: 0800 15-15-17
	///	153134220815 -> 12 digitos -> +55 (31) 3422-0185
	/// </summary>
	public class TxtTelefone : System.Windows.Forms.UserControl
	{
		// Atributos
		private bool formatando			= true;					// Se formatando automaticamente
		private bool mostrandoMensagem	= false;				// Se mostrando informações
        //private Point posiçãoCaixa;

		// Windows.Forms
		private System.Windows.Forms.TextBox caixaTexto;
		private System.ComponentModel.IContainer components;
		
		#region Propriedades

		/// <summary>
		/// Texto formatado
		/// </summary>
		public override string Text 
		{
			get 
			{
				return caixaTexto.Text;
			}
			set 
			{
				caixaTexto.Text = value;

				if (formatando)
					Formatar();
			}
		}

		/// <summary>
		/// Valor sem formatação
		/// </summary>
		public string ValorCru 
		{
			get 
			{
				return LimparCaracteres(caixaTexto.Text);
			}
		}

		/// <summary>
		/// Formatar automaticamente
		/// </summary>
		[DefaultValue(true),
		Description("Formatar automaticamente a caixa de telefone")]
		public bool AutoFormatar
		{
			get { return formatando; }
			set { formatando = value; }
		}

		#endregion

		/// <summary>
		/// Constrói a caixa de telefone
		/// </summary>
		public TxtTelefone()
		{
			InitializeComponent();
            //posiçãoCaixa = new Point(caixaTexto.Location.X,caixaTexto.Location.Y);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.caixaTexto = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// caixaTexto
			// 
			this.caixaTexto.Location = new System.Drawing.Point(0, 0);
			this.caixaTexto.Name = "caixaTexto";
			this.caixaTexto.TabIndex = 0;
			this.caixaTexto.Text = "";
			this.caixaTexto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.caixaTexto_KeyPress);
			// 
			// TxtTelefone
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.caixaTexto);
			this.Name = "CaixaTelefone";
			this.Size = new System.Drawing.Size(150, 144);
			this.Resize += new System.EventHandler(this.BaseControle_Resize);
			this.Enter += new System.EventHandler(this.TextboxTelefone_Enter);
			this.Leave += new System.EventHandler(this.TextboxTelefone_Leave);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre quando o controle é redimensionado
		/// </summary>
		private void BaseControle_Resize(object sender, System.EventArgs e)
		{
			RedesenharControle();
		}

		/// <summary>
		/// Redesenha o controle
		/// </summary>
		private void RedesenharControle() 
		{
			caixaTexto.Width = base.Width;
		
			if (!mostrandoMensagem) 
				base.Height = caixaTexto.Height;
		}

		/// <summary>
		/// Ocorre quando se pressiona alguma tecla
		/// </summary>
		private void caixaTexto_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (!formatando)
				return;

            switch (e.KeyChar)
            {
                case (char)13:    // Enter
                    Formatar();
                    caixaTexto.Focus();
                    e.Handled = true;
                    break;

                case (char)27:    // ESC
                    Formatar();
                    EsconderMensagem();
                    e.Handled = true;
                    break;

                default:
                    // Tudo menos números
                    //if ((e.KeyChar < 48 && e.KeyChar >= 32) || (e.KeyChar > 57))
                    //{
                    //    MostrarBalão();
                    //    e.Handled = true;
                    //}
                    break;
            }
		}

		/// <summary>
		/// Esconder mensagem
		/// </summary>
		private void EsconderMensagem() 
		{
			mostrandoMensagem = false;
			RedesenharControle();
		}
 
		/// <summary>
		/// Formata a textbox
		/// </summary>
		private void Formatar()
		{
			string novoTexto = "";

			novoTexto = LimparCaracteres(caixaTexto.Text);

			if (novoTexto.Trim().Length != 0) 
			{
				if (novoTexto.StartsWith("0800"))
					caixaTexto.Text = "0800 " + ColocarTraços(novoTexto.Substring(4, novoTexto.Length - 4));

				else if	(novoTexto.Length == 8) 
					caixaTexto.Text = ColocarTraços(novoTexto);

                else if (novoTexto.Length == 10 || novoTexto.Length == 9) 
					caixaTexto.Text = "(" + novoTexto.Substring(0, 2) + ") " + ColocarTraços(novoTexto.Substring(2, novoTexto.Length - 2));

				else
					caixaTexto.Text = ColocarTraços(novoTexto);
			}
			else
			{
				caixaTexto.Text = "";
			
                //if (this.Focused || caixaTexto.Focused) 
                //{
                //    MostrarBalão();
                //    caixaTexto.Focus();
                //}
			}
		}

		/// <summary>
		/// Etapa da formatação em que se coloca traço separador
		/// </summary>
		/// <param name="telefone">String contendo o telefone a ser formatado</param>
		/// <returns>Telefone formatada</returns>
		private string ColocarTraços(string telefone) 
		{
			string novoTelefone = "";

			if (telefone.Length < 6)
				return telefone;

            if (telefone.Length == 7)
                novoTelefone = telefone.Substring(0, 3) + "-" + telefone.Substring(3);
            else
            {
                while (telefone.Length >= 4)
                {
                    if (!String.IsNullOrEmpty(novoTelefone))
                        novoTelefone += "-" + telefone.Substring(0, 4);
                    else
                        novoTelefone += telefone.Substring(0, 4);

                    telefone = telefone.Substring(4, telefone.Length - 4);
                }

                if (telefone.Length > 1)
                    novoTelefone += "-" + telefone;
                else
                    novoTelefone += telefone;
            }

			return novoTelefone;
		}

		/// <summary>
		/// Ocorre quando sai do controle
		/// </summary>
		private void TextboxTelefone_Leave(object sender, System.EventArgs e)
		{
			if (formatando)
				Formatar();
		}

		/// <summary>
		/// Remove a formatação do texto
		/// </summary>
		/// <param name="antigo">Texto a ter sua formatação removida</param>
		/// <returns></returns>
		private string LimparCaracteres(string antigo) 
		{
			string novo = "";
			
			for (int x = 0; x < antigo.Length; x++) 
			{
				char letraAt = Convert.ToChar((string) antigo.Substring(x, 1));

				if ((letraAt.CompareTo('/') > 0) && (letraAt.CompareTo(':') < 0))
					novo += letraAt;
			}

			return novo;
		}

		/// <summary>
		/// Mostra balão para ativação da formatação automática
		/// </summary>
		private void MostrarBalão()
		{
			TxtTelefoneBalão balão = new TxtTelefoneBalão(this);
			
			balão.ShowBalloon(this);

			if (ParentForm != null && !this.ParentForm.TopMost)
			{
				this.ParentForm.Focus();
				this.Focus();
			}
		}

		/// <summary>
		/// Ocorre quando entra na caixa de telefone
		/// </summary>
		private void TextboxTelefone_Enter(object sender, System.EventArgs e)
		{
			if (!formatando) 
				MostrarBalão();
		}
	}
}