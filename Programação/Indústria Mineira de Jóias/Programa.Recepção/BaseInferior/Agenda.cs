using Entidades.Agenda;
using Programa.Recep��o.Formul�rios.Agenda;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Programa.Recep��o.BaseInferior
{
	sealed class Agenda : Apresenta��o.Formul�rios.BaseInferior
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
        private Apresenta��o.Formul�rios.Quadro quadroAgenda;
		private System.Windows.Forms.Label label2;
		private Apresenta��o.Formul�rios.Op��o op��oIncluirTelefone;
		private Apresenta��o.Formul�rios.Op��o op��oExcluir;
		private Apresenta��o.Formul�rios.Op��o op��oAlterar;
		private Apresenta��o.Formul�rios.Quadro op��esNome;
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
            this.quadroAgenda = new Apresenta��o.Formul�rios.Quadro();
            this.op��oIncluirTelefone = new Apresenta��o.Formul�rios.Op��o();
            this.op��esNome = new Apresenta��o.Formul�rios.Quadro();
            this.op��oAlterar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oExcluir = new Apresenta��o.Formul�rios.Op��o();
            this.label2 = new System.Windows.Forms.Label();
            this.esquerda.SuspendLayout();
            this.quadroAgenda.SuspendLayout();
            this.op��esNome.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.op��esNome);
            this.esquerda.Controls.Add(this.quadroAgenda);
            this.esquerda.Size = new System.Drawing.Size(187, 344);
            this.esquerda.Controls.SetChildIndex(this.quadroAgenda, 0);
            this.esquerda.Controls.SetChildIndex(this.op��esNome, 0);
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
            this.quadroAgenda.Controls.Add(this.op��oIncluirTelefone);
            this.quadroAgenda.Cor = System.Drawing.Color.Black;
            this.quadroAgenda.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroAgenda.LetraT�tulo = System.Drawing.Color.White;
            this.quadroAgenda.Location = new System.Drawing.Point(7, 16);
            this.quadroAgenda.MostrarBot�oMinMax = false;
            this.quadroAgenda.Name = "quadroAgenda";
            this.quadroAgenda.Size = new System.Drawing.Size(160, 72);
            this.quadroAgenda.TabIndex = 7;
            this.quadroAgenda.Tamanho = 30;
            this.quadroAgenda.T�tulo = "Agenda";
            // 
            // op��oIncluirTelefone
            // 
            this.op��oIncluirTelefone.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oIncluirTelefone.Descri��o = "Incluir telefone na agenda da recep��o";
            this.op��oIncluirTelefone.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oIncluirTelefone.Imagem")));
            this.op��oIncluirTelefone.Location = new System.Drawing.Point(8, 32);
            this.op��oIncluirTelefone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oIncluirTelefone.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oIncluirTelefone.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oIncluirTelefone.Name = "op��oIncluirTelefone";
            this.op��oIncluirTelefone.Size = new System.Drawing.Size(150, 32);
            this.op��oIncluirTelefone.TabIndex = 4;
            this.op��oIncluirTelefone.Click += new System.EventHandler(this.op��oIncluirTelefone_Click);
            // 
            // op��esNome
            // 
            this.op��esNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.op��esNome.bInfDirArredondada = true;
            this.op��esNome.bInfEsqArredondada = true;
            this.op��esNome.bSupDirArredondada = true;
            this.op��esNome.bSupEsqArredondada = true;
            this.op��esNome.Controls.Add(this.op��oAlterar);
            this.op��esNome.Controls.Add(this.op��oExcluir);
            this.op��esNome.Controls.Add(this.label2);
            this.op��esNome.Cor = System.Drawing.Color.Black;
            this.op��esNome.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.op��esNome.LetraT�tulo = System.Drawing.Color.White;
            this.op��esNome.Location = new System.Drawing.Point(7, 93);
            this.op��esNome.MostrarBot�oMinMax = false;
            this.op��esNome.Name = "op��esNome";
            this.op��esNome.Size = new System.Drawing.Size(160, 128);
            this.op��esNome.TabIndex = 8;
            this.op��esNome.Tamanho = 30;
            this.op��esNome.T�tulo = "�tem da Agenda";
            this.op��esNome.Visible = false;
            // 
            // op��oAlterar
            // 
            this.op��oAlterar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oAlterar.Descri��o = "Alterar dados";
            this.op��oAlterar.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oAlterar.Imagem")));
            this.op��oAlterar.Location = new System.Drawing.Point(8, 104);
            this.op��oAlterar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oAlterar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oAlterar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oAlterar.Name = "op��oAlterar";
            this.op��oAlterar.Size = new System.Drawing.Size(150, 24);
            this.op��oAlterar.TabIndex = 7;
            this.op��oAlterar.Click += new System.EventHandler(this.op��oAlterar_Click);
            // 
            // op��oExcluir
            // 
            this.op��oExcluir.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oExcluir.Descri��o = "Excluir";
            this.op��oExcluir.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oExcluir.Imagem")));
            this.op��oExcluir.Location = new System.Drawing.Point(8, 80);
            this.op��oExcluir.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oExcluir.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oExcluir.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oExcluir.Name = "op��oExcluir";
            this.op��oExcluir.Size = new System.Drawing.Size(150, 24);
            this.op��oExcluir.TabIndex = 6;
            this.op��oExcluir.Click += new System.EventHandler(this.op��oExcluir_Click);
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
            this.op��esNome.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        void lstPessoas_DoubleClick(object sender, EventArgs e)
        {
            if (lstPessoas.SelectedItems.Count == 1)
                op��oAlterar_Click(sender, e);
        }
		#endregion

		/// <summary>
		/// Insere uma linha no ListView
		/// </summary>
		private ListViewItem CriarLinha(Registro r)
		{
			ListViewItem linha;

			// Atribuir valores � linha criada
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
            op��esNome.Visible = (lstPessoas.SelectedItems.Count == 1);
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
		private void op��oIncluirTelefone_Click(object sender, System.EventArgs e)
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

                        if (Registro.VerificarExist�ncia(novo.Nome))
                            MessageBox.Show("Este nome j� est� cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            novo.Cadastrar();
                            CriarLinha(novo);
                        }

                    }
                    catch (Exception erro)
                    {
                        Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);
                        MessageBox.Show("N�o foi poss�vel concluir sua opera��o!",
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
		private void op��oExcluir_Click(object sender, System.EventArgs e)
		{
            if (lstPessoas.SelectedItems.Count != 1)
            {
                op��esNome.Visible = false;
                return;
            }

			ListViewItem linha = lstPessoas.SelectedItems[0];

			// Confirma exclus�o
			Exclus�o dlg = new Exclus�o(linha.Text);

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Exclui da agenda
					Registro.Excluir(linha.Text);

					// Exclui do ListView
					linha.Remove();

                    if (lstPessoas.SelectedItems.Count != 1)
                        op��esNome.Visible = false;
				}
				catch (Exception erro)
				{
					Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);
					MessageBox.Show("N�o foi poss�vel concluir a exclus�o!",
						"Agenda da Recep��o",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}


			dlg.Dispose();		
		}

		/// <summary>
		/// Ocorre ao clicar em alterar a agenda.
		/// </summary>
		private void op��oAlterar_Click(object sender, System.EventArgs e)
		{
            if (lstPessoas.SelectedItems.Count != 1)
            {
                op��esNome.Enabled = false;
                return;
            }

			Telefone dlg = new Telefone();
            ListViewItem linha = lstPessoas.SelectedItems[0];

			// Preencher formul�rio
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
                    if (dlg.Nome != linha.Text && Registro.VerificarExist�ncia(dlg.Nome))
                        MessageBox.Show("Este nome j� est� cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
    					Registro.Alterar(linha.Text, dlg.Nome, dlg.TelFixo, dlg.TelCelular, dlg.TelOutro, dlg.Cidade, dlg.Estado);
                    
				}
				catch (Exception erro)
				{
					Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);
					MessageBox.Show("N�o foi poss�vel concluir a altera��o",
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

