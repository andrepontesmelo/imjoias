using Entidades.Agenda;
using Programa.Recepção.Formulários.Agenda;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Programa.Recepção.BaseInferior
{
	sealed class Agenda : Apresentação.Formulários.BaseInferior
	{
		// Designer
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.ListView lstPessoas;
		private System.Windows.Forms.Label lblPessoas;
		private System.Windows.Forms.ColumnHeader colNome;
		private System.Windows.Forms.ColumnHeader colTelFixo;
		private System.Windows.Forms.ColumnHeader colTelCelular;
		private System.Windows.Forms.ColumnHeader colTelOutro;
		private System.Windows.Forms.ColumnHeader colCidade;
		private System.Windows.Forms.ColumnHeader colEstado;
		private System.Windows.Forms.Label label1;
        private Apresentação.Formulários.Quadro quadroAgenda;
		private System.Windows.Forms.Label label2;
		private Apresentação.Formulários.Opção opçãoIncluirTelefone;
		private Apresentação.Formulários.Opção opçãoExcluir;
		private Apresentação.Formulários.Opção opçãoAlterar;
		private Apresentação.Formulários.Quadro opçõesNome;
		private System.ComponentModel.IContainer components = null;
		
		public Agenda()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			if (this.DesignMode)
				return;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agenda));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lstPessoas = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelFixo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelCelular = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelOutro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPessoas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quadroAgenda = new Apresentação.Formulários.Quadro();
            this.opçãoIncluirTelefone = new Apresentação.Formulários.Opção();
            this.opçõesNome = new Apresentação.Formulários.Quadro();
            this.opçãoAlterar = new Apresentação.Formulários.Opção();
            this.opçãoExcluir = new Apresentação.Formulários.Opção();
            this.label2 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroAgenda.SuspendLayout();
            this.opçõesNome.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.opçõesNome);
            this.esquerda.Controls.Add(this.quadroAgenda);
            this.esquerda.Size = new System.Drawing.Size(187, 344);
            this.esquerda.Controls.SetChildIndex(this.quadroAgenda, 0);
            this.esquerda.Controls.SetChildIndex(this.opçõesNome, 0);
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(304, 16);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(464, 20);
            this.txtNome.TabIndex = 6;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // lstPessoas
            // 
            this.lstPessoas.AllowColumnReorder = true;
            this.lstPessoas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPessoas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colTelFixo,
            this.colTelCelular,
            this.colTelOutro,
            this.colCidade,
            this.colEstado});
            this.lstPessoas.FullRowSelect = true;
            this.lstPessoas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPessoas.HideSelection = false;
            this.lstPessoas.Location = new System.Drawing.Point(200, 72);
            this.lstPessoas.Name = "lstPessoas";
            this.lstPessoas.Size = new System.Drawing.Size(568, 264);
            this.lstPessoas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstPessoas.TabIndex = 7;
            this.lstPessoas.UseCompatibleStateImageBehavior = false;
            this.lstPessoas.View = System.Windows.Forms.View.Details;
            this.lstPessoas.SelectedIndexChanged += new System.EventHandler(this.lstPessoas_SelectedIndexChanged);
            this.lstPessoas.DoubleClick += new System.EventHandler(this.lstPessoas_DoubleClick);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 141;
            // 
            // colTelFixo
            // 
            this.colTelFixo.Text = "Telefone Fixo";
            this.colTelFixo.Width = 91;
            // 
            // colTelCelular
            // 
            this.colTelCelular.Text = "Telefone Celular";
            this.colTelCelular.Width = 91;
            // 
            // colTelOutro
            // 
            this.colTelOutro.Text = "Telefone (Outro)";
            this.colTelOutro.Width = 91;
            // 
            // colCidade
            // 
            this.colCidade.Text = "Cidade";
            this.colCidade.Width = 87;
            // 
            // colEstado
            // 
            this.colEstado.Text = "Estado";
            this.colEstado.Width = 48;
            // 
            // lblPessoas
            // 
            this.lblPessoas.AutoSize = true;
            this.lblPessoas.Location = new System.Drawing.Point(200, 56);
            this.lblPessoas.Name = "lblPessoas";
            this.lblPessoas.Size = new System.Drawing.Size(50, 13);
            this.lblPessoas.TabIndex = 8;
            this.lblPessoas.Text = "Pessoas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pesquisa por nome:";
            // 
            // quadroAgenda
            // 
            this.quadroAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroAgenda.bInfDirArredondada = true;
            this.quadroAgenda.bInfEsqArredondada = true;
            this.quadroAgenda.bSupDirArredondada = true;
            this.quadroAgenda.bSupEsqArredondada = true;
            this.quadroAgenda.Controls.Add(this.opçãoIncluirTelefone);
            this.quadroAgenda.Cor = System.Drawing.Color.Black;
            this.quadroAgenda.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgenda.LetraTítulo = System.Drawing.Color.White;
            this.quadroAgenda.Location = new System.Drawing.Point(7, 16);
            this.quadroAgenda.MostrarBotãoMinMax = false;
            this.quadroAgenda.Name = "quadroAgenda";
            this.quadroAgenda.Size = new System.Drawing.Size(160, 72);
            this.quadroAgenda.TabIndex = 7;
            this.quadroAgenda.Tamanho = 30;
            this.quadroAgenda.Título = "Agenda";
            // 
            // opçãoIncluirTelefone
            // 
            this.opçãoIncluirTelefone.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoIncluirTelefone.Descrição = "Incluir telefone na agenda da recepção";
            this.opçãoIncluirTelefone.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoIncluirTelefone.Imagem")));
            this.opçãoIncluirTelefone.Location = new System.Drawing.Point(8, 32);
            this.opçãoIncluirTelefone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoIncluirTelefone.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoIncluirTelefone.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoIncluirTelefone.Name = "opçãoIncluirTelefone";
            this.opçãoIncluirTelefone.Size = new System.Drawing.Size(150, 32);
            this.opçãoIncluirTelefone.TabIndex = 4;
            this.opçãoIncluirTelefone.Click += new System.EventHandler(this.opçãoIncluirTelefone_Click);
            // 
            // opçõesNome
            // 
            this.opçõesNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.opçõesNome.bInfDirArredondada = true;
            this.opçõesNome.bInfEsqArredondada = true;
            this.opçõesNome.bSupDirArredondada = true;
            this.opçõesNome.bSupEsqArredondada = true;
            this.opçõesNome.Controls.Add(this.opçãoAlterar);
            this.opçõesNome.Controls.Add(this.opçãoExcluir);
            this.opçõesNome.Controls.Add(this.label2);
            this.opçõesNome.Cor = System.Drawing.Color.Black;
            this.opçõesNome.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.opçõesNome.LetraTítulo = System.Drawing.Color.White;
            this.opçõesNome.Location = new System.Drawing.Point(7, 93);
            this.opçõesNome.MostrarBotãoMinMax = false;
            this.opçõesNome.Name = "opçõesNome";
            this.opçõesNome.Size = new System.Drawing.Size(160, 128);
            this.opçõesNome.TabIndex = 8;
            this.opçõesNome.Tamanho = 30;
            this.opçõesNome.Título = "Ítem da Agenda";
            this.opçõesNome.Visible = false;
            // 
            // opçãoAlterar
            // 
            this.opçãoAlterar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoAlterar.Descrição = "Alterar dados";
            this.opçãoAlterar.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoAlterar.Imagem")));
            this.opçãoAlterar.Location = new System.Drawing.Point(8, 104);
            this.opçãoAlterar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAlterar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAlterar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAlterar.Name = "opçãoAlterar";
            this.opçãoAlterar.Size = new System.Drawing.Size(150, 24);
            this.opçãoAlterar.TabIndex = 7;
            this.opçãoAlterar.Click += new System.EventHandler(this.opçãoAlterar_Click);
            // 
            // opçãoExcluir
            // 
            this.opçãoExcluir.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoExcluir.Descrição = "Excluir";
            this.opçãoExcluir.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoExcluir.Imagem")));
            this.opçãoExcluir.Location = new System.Drawing.Point(8, 80);
            this.opçãoExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoExcluir.Name = "opçãoExcluir";
            this.opçãoExcluir.Size = new System.Drawing.Size(150, 24);
            this.opçãoExcluir.TabIndex = 6;
            this.opçãoExcluir.Click += new System.EventHandler(this.opçãoExcluir_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sobre o nome selecionado, o que deseja?";
            // 
            // Agenda
            // 
            this.Controls.Add(this.lstPessoas);
            this.Controls.Add(this.lblPessoas);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Name = "Agenda";
            this.Size = new System.Drawing.Size(800, 344);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lblPessoas, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.Controls.SetChildIndex(this.lstPessoas, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroAgenda.ResumeLayout(false);
            this.opçõesNome.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        void lstPessoas_DoubleClick(object sender, EventArgs e)
        {
            if (lstPessoas.SelectedItems.Count == 1)
                opçãoAlterar_Click(sender, e);
        }
		#endregion

		/// <summary>
		/// Insere uma linha no ListView
		/// </summary>
		private ListViewItem CriarLinha(Registro r)
		{
			ListViewItem linha;

			// Atribuir valores à linha criada
			linha = new ListViewItem(r.Nome);
			linha.SubItems.Add(r.TelFixo);
			linha.SubItems.Add(r.TelCelular);
			linha.SubItems.Add(r.TelOutro);
			linha.SubItems.Add(r.EndCidade);
			linha.SubItems.Add(r.EndEstado);

            return linha;
		}

		/// <summary>
		/// Nome da agenda selecionado
		/// </summary>
		private void lstPessoas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            opçõesNome.Visible = (lstPessoas.SelectedItems.Count == 1);
		}

		private void RealizarBusca(string nome)
		{
            txtNome.Enabled = false;

			if (!String.IsNullOrEmpty(nome))
			{
                List<Registro> registros = Registro.Buscar(nome);

                ListViewItem[] itens = new ListViewItem[registros.Count];

                int x = 0;

                foreach (Registro r in registros)
                    itens[x++] = CriarLinha(r);

                lstPessoas.Items.Clear();
                lstPessoas.Items.AddRange(itens);
                lstPessoas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			}

            txtNome.Enabled = true;
            txtNome.Focus();
		}

		/// <summary>
		/// Nome para pesquisa alterado
		/// </summary>
		private void txtNome_TextChanged(object sender, System.EventArgs e)
		{
			//RealizarBusca(txtNome.Text.Trim());
		}

		/// <summary>
		/// Ocorre quando se pressiona uma tecla
		/// </summary>
		private void txtNome_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)	// Enter
			{
				e.Handled = true;
                RealizarBusca(txtNome.Text.Trim());
				txtNome.SelectAll();
			}
		}

		/// <summary>
		/// Ocorre ao clicar em incluir novo telefone na agenda.
		/// </summary>
		private void opçãoIncluirTelefone_Click(object sender, System.EventArgs e)
		{
            bool cadastrarOutro = true;

            while (cadastrarOutro)
            {

                Telefone dlg = new Telefone();

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        Registro novo = new Registro(dlg.Nome, dlg.TelFixo, dlg.TelCelular, dlg.TelOutro, dlg.Cidade, dlg.Estado);

                        if (Registro.VerificarExistência(novo.Nome))
                            MessageBox.Show("Este nome já está cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            novo.Cadastrar();
                            CriarLinha(novo);
                        }

                    }
                    catch (Exception erro)
                    {
                        Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
                        MessageBox.Show("Não foi possível concluir sua operação!",
                            "Agenda de telefones",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                    cadastrarOutro = false;
                dlg.Dispose();		

            }
			
		}

		/// <summary>
		/// Ocorre ao clicar em excluir da agenda.
		/// </summary>
		private void opçãoExcluir_Click(object sender, System.EventArgs e)
		{
            if (lstPessoas.SelectedItems.Count != 1)
            {
                opçõesNome.Visible = false;
                return;
            }

			ListViewItem linha = lstPessoas.SelectedItems[0];

			// Confirma exclusão
			Exclusão dlg = new Exclusão(linha.Text);

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Exclui da agenda
					Registro.Excluir(linha.Text);

					// Exclui do ListView
					linha.Remove();

                    if (lstPessoas.SelectedItems.Count != 1)
                        opçõesNome.Visible = false;
				}
				catch (Exception erro)
				{
					Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
					MessageBox.Show("Não foi possível concluir a exclusão!",
						"Agenda da Recepção",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}


			dlg.Dispose();		
		}

		/// <summary>
		/// Ocorre ao clicar em alterar a agenda.
		/// </summary>
		private void opçãoAlterar_Click(object sender, System.EventArgs e)
		{
            if (lstPessoas.SelectedItems.Count != 1)
            {
                opçõesNome.Enabled = false;
                return;
            }

			Telefone dlg = new Telefone();
            ListViewItem linha = lstPessoas.SelectedItems[0];

			// Preencher formulário
			dlg.Nome = linha.Text;
			dlg.TelFixo = linha.SubItems[colTelFixo.Index].Text;
			dlg.TelCelular = linha.SubItems[colTelCelular.Index].Text;
			dlg.TelOutro = linha.SubItems[colTelOutro.Index].Text;
			dlg.Cidade = linha.SubItems[colCidade.Index].Text;
			dlg.Estado = linha.SubItems[colEstado.Index].Text;

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
                    if (dlg.Nome != linha.Text && Registro.VerificarExistência(dlg.Nome))
                        MessageBox.Show("Este nome já está cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
    					Registro.Alterar(linha.Text, dlg.Nome, dlg.TelFixo, dlg.TelCelular, dlg.TelOutro, dlg.Cidade, dlg.Estado);
                    
				}
				catch (Exception erro)
				{
					Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);
					MessageBox.Show("Não foi possível concluir a alteração",
						"Agenda de telefones",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);

					dlg.Dispose();

					return;
				}

				// Alterar ListView
				linha.Text = dlg.Nome;
				linha.SubItems[colTelFixo.Index].Text = dlg.TelFixo;
				linha.SubItems[colTelCelular.Index].Text = dlg.TelCelular;
				linha.SubItems[colTelOutro.Index].Text = dlg.TelOutro;
				linha.SubItems[colCidade.Index].Text = dlg.Cidade;
				linha.SubItems[colEstado.Index].Text = dlg.Estado;
			}

			dlg.Dispose();
		}
	}
}

