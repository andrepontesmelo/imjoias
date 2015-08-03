using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.�lbum;
using Entidades;
using Entidades.Mercadoria;

namespace Apresenta��o.�lbum.Edi��o
{
	public class TxtFornecedor : System.Windows.Forms.UserControl
	{
		// Atributos
		private ColetorFornecedor	coletor = null;
		private ListViewFornecedor	lst = null;

		/* mostrarLista: Usado com mudan�a de foco; 
		 * se deve mostrar a lista ou n�o quando obter os dados */
		private bool				mostrarLista = false;	

		// Controle
		private TextBox txt;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TxtFornecedor()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
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
            this.txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(368, 20);
            this.txt.TabIndex = 0;
            this.txt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txt.Leave += new System.EventHandler(this.txt_Leave);
            this.txt.Move += new System.EventHandler(this.txt_Move);
            this.txt.Resize += new System.EventHandler(this.txt_Move);
            // 
            // TxtFornecedor
            // 
            this.Controls.Add(this.txt);
            this.Name = "TxtFornecedor";
            this.Size = new System.Drawing.Size(368, 24);
            this.Resize += new System.EventHandler(this.txtFornecedor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Constr�i o coletor
		/// </summary>
		/// <remarks>
		/// Necess�rio que a ListView j� esteja constru�da.
		/// </remarks>
		private void ConstruirColetor()
		{
			// Constr�i o coletor
			coletor = new ColetorFornecedor(lst);
			coletor.In�cioDeBusca += new Apresenta��o.Formul�rios.Consultas.Coletor.In�cioDeBuscaDelegate(coletor_In�cioDeBusca);
			coletor.FinalDeBusca  += new Apresenta��o.Formul�rios.Consultas.Coletor.FinalDeBuscaDelegate(coletor_FinalDeBusca);
		}

        private delegate void Callback();

		/// <summary>
		/// Ocorre quando o coletor inicia sua busca
		/// </summary>
		private void coletor_In�cioDeBusca()
		{
            if (InvokeRequired)
            {
                Callback m�todo = new Callback(coletor_In�cioDeBusca);
                BeginInvoke(m�todo);
            }
            else if (lst.Visible)
				lst.Visible = false;
		}

		/// <summary>
		/// Ocorre quando o coletor finaliza sua busca
		/// </summary>
		private void coletor_FinalDeBusca()
		{
            if (InvokeRequired)
            {
                Callback m�todo = new Callback(coletor_FinalDeBusca);
                BeginInvoke(m�todo);
            }
            else
            {
                // Verificar se controle cont�m o foco
                if (mostrarLista)
                {
                    lst.Visible = true && lst.Items.Count > 0 && Focused;
                    lst.BringToFront();
                }
            }
		}

		/// <summary>
		/// Constr�i a ListView
		/// </summary>
		private void ConstruirListView()
		{
			// Constr�i a lista
			lst				= new ListViewFornecedor();
			lst.Width		= this.Width;
			lst.Height		= this.Height * 5;
			lst.Name		= this.Name + "Lista";
			lst.AoSelecionarFornecedor += new Apresenta��o.�lbum.Edi��o.ListViewFornecedor.Sele��oFornecedor(lst_AoSelecionarFornecedor);

			// Adiciona ao formul�rio
			this.Parent.SuspendLayout();
			this.Parent.Controls.Add(lst);

			ReposicionarLista();
			lst.BringToFront();
            lst.Visible = false;

			this.Parent.ResumeLayout();

			ConstruirColetor();
		}

		/// <summary>
		/// Reposiciona lista
		/// </summary>
		private void ReposicionarLista()
		{
			if (lst != null)
			{
				lst.Width	= this.Width;
				lst.Left	= this.Left;
				lst.Top		= this.Top + this.Height;
				lst.Height	= this.Height * 5;

				if (lst.Height + lst.Top > this.Parent.Height)
					lst.Height = this.Parent.Height - lst.Top;
			}
		}
		
		/// <summary>
		/// Ocorre quando o texto � alterado
		/// </summary>
		private void txt_TextChanged(object sender, System.EventArgs e)
		{
			if (coletor == null)
				ConstruirListView();

			if (mostrarLista)
				coletor.Pesquisar(txt.Text);

		}

		/// <summary>
		/// Ocorre quando o textbox ganha foco
		/// </summary>
		private void txt_Enter(object sender, System.EventArgs e)
		{
			mostrarLista = true;
			
			if (txt.Text.Trim().Length > 0)
			{
				if (coletor == null) 
					ConstruirListView();

				coletor.Pesquisar(txt.Text);
			}
		}

		/// <summary>
		/// Ocorre quando o textbox perde o foco
		/// </summary>
		private void txt_Leave(object sender, System.EventArgs e)
		{
			mostrarLista = false;

			if (lst != null && lst.Visible)
				lst.Visible = false;
		}

		/// <summary>
		/// Ocorre quando o textbox muda de tamanho ou �
		/// redimensionado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_Move(object sender, System.EventArgs e)
		{
			ReposicionarLista();
		}

		/// <summary>
		/// Ocorre quando altera-se o tamanho da textbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtFornecedor_Resize(object sender, System.EventArgs e)
		{
			this.Height = txt.Height;
		}

		/// <summary>
		/// TextBox
		/// </summary>
		public TextBox Txt
		{
			get { return txt; }
		}

		/// <summary>
		/// Ocorre assim que seleciona um fornecedor no ListView
		/// </summary>
		private void lst_AoSelecionarFornecedor(string nomeFornecedor)
		{
			mostrarLista = false;
			txt.Text = nomeFornecedor;
			txt.Select(txt.SelectionStart, txt.Text.Length - txt.SelectionStart);
			mostrarLista = true;
		}


		/// <summary>
		/// Ocorre ao pressionar uma tecla no textbox
		/// </summary>
		private void txt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)

		{
			if (coletor == null) 
				ConstruirListView();

			switch (e.KeyCode)
			{
				case Keys.Down:
					if (lst != null)
					{
						lst.SelecionarPr�ximo();
						e.Handled = true;
					}
					break;

				case Keys.Up:
					if (lst != null)
					{
						lst.SelecionarAnterior();
						e.Handled = true;
					}
					break;

				case Keys.Escape:
					lst.Visible = false;
					break;

				case Keys.Enter:
					e.Handled = CompletarCaixa();
					break;
			}
		}

		/// <summary>
		/// Completar a caixa com o resto do fornecedor
		/// Retorna verdadeiro se obteve sucesso.
		/// </summary>
		private bool CompletarCaixa()
		{
			string nomeFornecedor = null;

			nomeFornecedor = coletor.RecuperarPrimeiroSomente(txt.Text);

			if (nomeFornecedor != null)
			{
				mostrarLista = false;
				lst.Visible = false;
				txt.Text = nomeFornecedor;
				mostrarLista = true;
				return true;
			}
			
			return false;
		}

		/// <summary>
		/// Refer�ncia
		/// </summary>
		[Bindable(true)]
		public string Refer�ncia
		{
			get { return txt.Text; }
			set
			{
				mostrarLista = false;
				txt.Text = value;
			}
		}

		public new event KeyEventHandler KeyDown
		{
			add { txt.KeyDown += value; }
			remove { txt.KeyDown -= value; }
		}

		public new event KeyEventHandler KeyUp
		{
			add { txt.KeyUp += value; }
			remove { txt.KeyUp -= value; }
		}

		/// <summary>
		/// V� se a sele��o corresponde � um fornecedor no banco de dados.
		/// Recupera no BD um fornecedor que corresponda ao que foi entrado.
		/// </summary>
		/// <remarks>
		/// Foi implementado dessa forma por quest�o de tempo.
		/// Este esquema pode ser re-implementado para aumento de desempenho.
		/// Al�m disso, � interessante que o controle exiba uma cor diferente
		/// para o caso de existir forcedor j� cadastrado ou n�o,
		/// a fim de se evitar duplicamentos desnecess�rios.
		/// </remarks>
		/// <returns> nulo caso n�o exista fornecedor cadastrado </returns>
		public Fornecedor ObterFornecedor()
		{
            return Fornecedor.ObterFornecedorPorNome(txt.Text.Trim());
		}

        public override bool Focused
        {
            get
            {
                return base.Focused || txt.Focused;
            }
        }
	}
}