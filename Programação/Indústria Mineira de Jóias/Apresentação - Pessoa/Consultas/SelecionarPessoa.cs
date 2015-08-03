using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Consultas
{
	/// <summary>
	/// Summary description for SelecionarPessoa.
	/// </summary>
	public class SelecionarPessoa : System.Windows.Forms.Form
	{
		private ICollection pessoas;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblDescrição;
		private System.Windows.Forms.PictureBox picÍcone;
		private System.Windows.Forms.Label lblTítulo;
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
		private System.Windows.Forms.RadioButton optSeleção;
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

				if (pessoa.GetType() == typeof(Entidades.Pessoa.PessoaFísica))
				{
					linha.SubItems.Add("Física");
					linha.SubItems.Add(((PessoaFísica) pessoa).CPF);
				}
				else if (pessoa.GetType() == typeof(Entidades.Pessoa.PessoaJurídica))
				{
					linha.SubItems.Add("Jurídica");
					linha.SubItems.Add(((PessoaJurídica) pessoa).CNPJ);
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
			this.lblTítulo = new System.Windows.Forms.Label();
			this.lblDescrição = new System.Windows.Forms.Label();
			this.picÍcone = new System.Windows.Forms.PictureBox();
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
			this.optSeleção = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.lblTítulo);
			this.panel1.Controls.Add(this.lblDescrição);
			this.panel1.Controls.Add(this.picÍcone);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(418, 88);
			this.panel1.TabIndex = 0;
			// 
			// lblTítulo
			// 
			this.lblTítulo.AutoSize = true;
			this.lblTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTítulo.Location = new System.Drawing.Point(88, 16);
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(257, 22);
			this.lblTítulo.TabIndex = 4;
			this.lblTítulo.Text = "Encontrado um ou mais registros";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescrição.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDescrição.Location = new System.Drawing.Point(88, 40);
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(312, 32);
			this.lblDescrição.TabIndex = 3;
			this.lblDescrição.Text = "Foram encontradas uma ou mais pessoas cadastradas. Por favor, escolha aquela em q" +
				"uestão.";
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Location = new System.Drawing.Point(16, 16);
			this.picÍcone.Name = "picÍcone";
			this.picÍcone.Size = new System.Drawing.Size(57, 57);
			this.picÍcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picÍcone.TabIndex = 2;
			this.picÍcone.TabStop = false;
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
			this.dica.SetToolTip(this.cmdCancelar, "Use a opção cancelar se não for nenhuma das pessoas acima.");
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
			this.optNenhum.Text = "Nenhum nome acima corresponde à pessoa em questão";
			this.optNenhum.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
			// 
			// optSeleção
			// 
			this.optSeleção.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.optSeleção.Location = new System.Drawing.Point(16, 240);
			this.optSeleção.Name = "optSeleção";
			this.optSeleção.Size = new System.Drawing.Size(384, 24);
			this.optSeleção.TabIndex = 2;
			this.optSeleção.Text = "A pessoa acima selecionada corresponde à pessoa em questão";
			this.optSeleção.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
			// 
			// SelecionarPessoa
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancelar;
			this.ClientSize = new System.Drawing.Size(418, 328);
			this.Controls.Add(this.optSeleção);
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
				optSeleção.Checked = true;
			else
				optNenhum.Checked = true;
		}

		private void lstPessoas_DoubleClick(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void opt_CheckedChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = optNenhum.Checked || optSeleção.Checked;
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
						if (pessoa.GetType() == typeof(PessoaFísica)
							&& linha.SubItems[colTipo.Index].Text == "Física")
						{
							if (cpfcnpj == ((PessoaFísica) pessoa).CPF)
								return pessoa;
						}
						else if (pessoa.GetType() == typeof(PessoaJurídica)
							&& linha.SubItems[colTipo.Index].Text == "Jurídica")
						{
							if (cpfcnpj == ((PessoaJurídica) pessoa).CNPJ)
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
