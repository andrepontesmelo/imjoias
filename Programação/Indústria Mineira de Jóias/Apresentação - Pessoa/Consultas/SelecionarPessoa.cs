using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa.Consultas
{
	/// <summary>
	/// Summary description for SelecionarPessoa.
	/// </summary>
	public class SelecionarPessoa : System.Windows.Forms.Form
	{
		private ICollection pessoas;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblDescri��o;
		private System.Windows.Forms.PictureBox pic�cone;
		private System.Windows.Forms.Label lblT�tulo;
		private System.Windows.Forms.Label lblEscolha;
		private System.Windows.Forms.ListView lstPessoas;
		private System.Windows.Forms.ColumnHeader colNome;
		private System.Windows.Forms.ColumnHeader colTipo;
		private System.Windows.Forms.ColumnHeader colCPFCNPJ;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.ToolTip dica;
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.RadioButton optNenhum;
		private System.Windows.Forms.RadioButton optSele��o;
		private System.ComponentModel.IContainer components;

		public SelecionarPessoa(ICollection pessoas, string original)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			txtNome.Text = original;

			// Incluir na ListView de pessoas
			foreach (Entidades.Pessoa.Pessoa pessoa in pessoas)
			{
				ListViewItem linha = new ListViewItem(pessoa.Nome);

				if (pessoa.GetType() == typeof(Entidades.Pessoa.PessoaF�sica))
				{
					linha.SubItems.Add("F�sica");
					linha.SubItems.Add(((PessoaF�sica) pessoa).CPF);
				}
				else if (pessoa.GetType() == typeof(Entidades.Pessoa.PessoaJur�dica))
				{
					linha.SubItems.Add("Jur�dica");
					linha.SubItems.Add(((PessoaJur�dica) pessoa).CNPJ);
				}
				else
				{
					linha.SubItems.Add("");
					linha.SubItems.Add("");
				}

				lstPessoas.Items.Add(linha);

				if (linha.Text == original)
					linha.Selected = true;
			}

			this.pessoas = pessoas;

/*			if (pessoas.Count == 1)
			{
				lstPessoas.Items[0].Selected = true;
			}
*/		}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SelecionarPessoa));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblT�tulo = new System.Windows.Forms.Label();
			this.lblDescri��o = new System.Windows.Forms.Label();
			this.pic�cone = new System.Windows.Forms.PictureBox();
			this.lblEscolha = new System.Windows.Forms.Label();
			this.lstPessoas = new System.Windows.Forms.ListView();
			this.colNome = new System.Windows.Forms.ColumnHeader();
			this.colTipo = new System.Windows.Forms.ColumnHeader();
			this.colCPFCNPJ = new System.Windows.Forms.ColumnHeader();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.dica = new System.Windows.Forms.ToolTip(this.components);
			this.lblNome = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.optNenhum = new System.Windows.Forms.RadioButton();
			this.optSele��o = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.lblT�tulo);
			this.panel1.Controls.Add(this.lblDescri��o);
			this.panel1.Controls.Add(this.pic�cone);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(418, 88);
			this.panel1.TabIndex = 0;
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.AutoSize = true;
			this.lblT�tulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblT�tulo.Location = new System.Drawing.Point(88, 16);
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(257, 22);
			this.lblT�tulo.TabIndex = 4;
			this.lblT�tulo.Text = "Encontrado um ou mais registros";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescri��o.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDescri��o.Location = new System.Drawing.Point(88, 40);
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(312, 32);
			this.lblDescri��o.TabIndex = 3;
			this.lblDescri��o.Text = "Foram encontradas uma ou mais pessoas cadastradas. Por favor, escolha aquela em q" +
				"uest�o.";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Location = new System.Drawing.Point(16, 16);
			this.pic�cone.Name = "pic�cone";
			this.pic�cone.Size = new System.Drawing.Size(57, 57);
			this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pic�cone.TabIndex = 2;
			this.pic�cone.TabStop = false;
			// 
			// lblEscolha
			// 
			this.lblEscolha.AutoSize = true;
			this.lblEscolha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEscolha.Location = new System.Drawing.Point(16, 136);
			this.lblEscolha.Name = "lblEscolha";
			this.lblEscolha.Size = new System.Drawing.Size(385, 16);
			this.lblEscolha.TabIndex = 0;
			this.lblEscolha.Text = "Verifique se o nome acima corresponde a algum cadastro listado abaixo:";
			// 
			// lstPessoas
			// 
			this.lstPessoas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.colNome,
																						 this.colTipo,
																						 this.colCPFCNPJ});
			this.lstPessoas.FullRowSelect = true;
			this.lstPessoas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstPessoas.HideSelection = false;
			this.lstPessoas.Location = new System.Drawing.Point(16, 152);
			this.lstPessoas.MultiSelect = false;
			this.lstPessoas.Name = "lstPessoas";
			this.lstPessoas.Size = new System.Drawing.Size(384, 80);
			this.lstPessoas.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstPessoas.TabIndex = 1;
			this.lstPessoas.View = System.Windows.Forms.View.Details;
			this.lstPessoas.DoubleClick += new System.EventHandler(this.lstPessoas_DoubleClick);
			this.lstPessoas.SelectedIndexChanged += new System.EventHandler(this.lstPessoas_SelectedIndexChanged);
			// 
			// colNome
			// 
			this.colNome.Text = "Nome";
			this.colNome.Width = 183;
			// 
			// colTipo
			// 
			this.colTipo.Text = "Tipo";
			// 
			// colCPFCNPJ
			// 
			this.colCPFCNPJ.Text = "CPF/CNPJ";
			this.colCPFCNPJ.Width = 118;
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Enabled = false;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(328, 296);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 4;
			this.cmdOK.Text = "OK";
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancelar.Location = new System.Drawing.Point(248, 296);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.TabIndex = 5;
			this.cmdCancelar.Text = "Cancelar";
			this.dica.SetToolTip(this.cmdCancelar, "Use a op��o cancelar se n�o for nenhuma das pessoas acima.");
			// 
			// dica
			// 
			this.dica.ShowAlways = true;
			// 
			// lblNome
			// 
			this.lblNome.AutoSize = true;
			this.lblNome.Location = new System.Drawing.Point(16, 106);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(38, 16);
			this.lblNome.TabIndex = 5;
			this.lblNome.Text = "Nome:";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(80, 104);
			this.txtNome.Name = "txtNome";
			this.txtNome.ReadOnly = true;
			this.txtNome.Size = new System.Drawing.Size(320, 20);
			this.txtNome.TabIndex = 6;
			this.txtNome.Text = "";
			// 
			// optNenhum
			// 
			this.optNenhum.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.optNenhum.Location = new System.Drawing.Point(16, 264);
			this.optNenhum.Name = "optNenhum";
			this.optNenhum.Size = new System.Drawing.Size(384, 24);
			this.optNenhum.TabIndex = 3;
			this.optNenhum.Text = "Nenhum nome acima corresponde � pessoa em quest�o";
			this.optNenhum.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
			// 
			// optSele��o
			// 
			this.optSele��o.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.optSele��o.Location = new System.Drawing.Point(16, 240);
			this.optSele��o.Name = "optSele��o";
			this.optSele��o.Size = new System.Drawing.Size(384, 24);
			this.optSele��o.TabIndex = 2;
			this.optSele��o.Text = "A pessoa acima selecionada corresponde � pessoa em quest�o";
			this.optSele��o.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
			// 
			// SelecionarPessoa
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancelar;
			this.ClientSize = new System.Drawing.Size(418, 328);
			this.Controls.Add(this.optSele��o);
			this.Controls.Add(this.optNenhum);
			this.Controls.Add(this.txtNome);
			this.Controls.Add(this.lblNome);
			this.Controls.Add(this.cmdCancelar);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.lstPessoas);
			this.Controls.Add(this.lblEscolha);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelecionarPessoa";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Escolha pessoa";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void lstPessoas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstPessoas.SelectedItems.Count == 1)
				optSele��o.Checked = true;
			else
				optNenhum.Checked = true;
		}

		private void lstPessoas_DoubleClick(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void opt_CheckedChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = optNenhum.Checked || optSele��o.Checked;
		}

		/// <summary>
		/// Pessoa escolhida
		/// </summary>
		public Entidades.Pessoa.Pessoa PessoaEscolhida
		{
			get
			{
				if (lstPessoas.SelectedItems.Count != 1)
					return null;

				ListViewItem linha = lstPessoas.SelectedItems[0];
				string cpfcnpj = linha.SubItems[colCPFCNPJ.Index].Text;

				if (cpfcnpj.Length == 0)
					cpfcnpj = null;

				// Procurar pessoa escolhida
				foreach (Entidades.Pessoa.Pessoa pessoa in pessoas)
				{
					if (pessoa.Nome == linha.Text)
					{
						if (pessoa.GetType() == typeof(PessoaF�sica)
							&& linha.SubItems[colTipo.Index].Text == "F�sica")
						{
							if (cpfcnpj == ((PessoaF�sica) pessoa).CPF)
								return pessoa;
						}
						else if (pessoa.GetType() == typeof(PessoaJur�dica)
							&& linha.SubItems[colTipo.Index].Text == "Jur�dica")
						{
							if (cpfcnpj == ((PessoaJur�dica) pessoa).CNPJ)
								return pessoa;
						}
						else if (pessoa.GetType() == typeof(Entidades.Pessoa.Pessoa)
							&& linha.SubItems[colTipo.Index].Text == "")
							return pessoa;
					}
				}

				return null;
			}
		}
	}
}
