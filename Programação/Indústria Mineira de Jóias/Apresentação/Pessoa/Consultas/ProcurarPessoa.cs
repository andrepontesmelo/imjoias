using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Pessoa;
using Entidades.Pessoa.Endereço;
using System.Collections.Generic;

namespace Apresentação.Pessoa.Consultas
{
    /* Porque existem dois txts ?
     * Antes, erá só o de pessoa.
     * Porém, assim que o usuário pressionava OK
     * e estava procurando por outro campo senão "Nome"
     * o TxtPessoa zerava o campo a ser procurado uma vez
     * que não achava nome.
     */

    public class ProcurarPessoa : Apresentação.Formulários.JanelaExplicativa
	{
		public enum TipoChave
		{
            Código,
			Cidade,
			CNPJ,
			CPF,
			Estado,
			Nome,
//			País,
			RG,
			Telefone
		}

		// Componentes
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbDado;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancelar;
		private Apresentação.Pessoa.Consultas.TextBoxPessoa txtPessoa;
        private TextBox txtProcura;
		private System.ComponentModel.IContainer components = null;

		public ProcurarPessoa()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			cmbDado.Items.AddRange(Enum.GetNames(typeof(TipoChave)));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcurarPessoa));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtProcura = new System.Windows.Forms.TextBox();
            this.txtPessoa = new Apresentação.Pessoa.Consultas.TextBoxPessoa();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(140, 20);
            this.lblTítulo.TabIndex = 999;
            this.lblTítulo.Text = "Procurar pessoa";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(528, 48);
            this.lblDescrição.Text = "";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Procurar por";
            // 
            // cmbDado
            // 
            this.cmbDado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDado.Location = new System.Drawing.Point(15, 118);
            this.cmbDado.Name = "cmbDado";
            this.cmbDado.Size = new System.Drawing.Size(590, 21);
            this.cmbDado.Sorted = true;
            this.cmbDado.TabIndex = 3;
            this.cmbDado.SelectedIndexChanged += new System.EventHandler(this.cmbDado_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Palavra chave";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(449, 503);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancelar.Location = new System.Drawing.Point(530, 503);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtProcura
            // 
            this.txtProcura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcura.Location = new System.Drawing.Point(15, 161);
            this.txtProcura.Name = "txtProcura";
            this.txtProcura.Size = new System.Drawing.Size(590, 20);
            this.txtProcura.TabIndex = 7;
            this.txtProcura.Visible = false;
            this.txtProcura.TextChanged += new System.EventHandler(this.txtProcura_TextChanged);
            this.txtProcura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcura_KeyDown);
            // 
            // txtPessoa
            // 
            this.txtPessoa.AlturaProposta = 300;
            this.txtPessoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPessoa.Location = new System.Drawing.Point(15, 161);
            this.txtPessoa.MostrarBotãoProcurar = false;
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.NãoPodeSerNulo = false;
            this.txtPessoa.Pessoa = null;
            this.txtPessoa.Size = new System.Drawing.Size(590, 20);
            this.txtPessoa.TabIndex = 0;
            this.txtPessoa.TxtChanged += new System.EventHandler(this.txtPessoa_TxtChanged);
            this.txtPessoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPessoa_KeyDown);
            // 
            // ProcurarPessoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 536);
            this.Controls.Add(this.txtProcura);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPessoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDado);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "ProcurarPessoa";
            this.Text = "Procurar pessoa";
            this.Activated += new System.EventHandler(this.ProcurarPessoa_Activated);
            this.Load += new System.EventHandler(this.ProcurarPessoa_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbDado, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPessoa, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtProcura, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		/// <summary>
		/// Ocorre ao carregar a janela.
		/// </summary>
		private void ProcurarPessoa_Load(object sender, System.EventArgs e)
		{
			cmbDado.SelectedItem = "Nome";
			txtPessoa.Focus();
		}

		/// <summary>
		/// Pessoa selecionada.
		/// </summary>
		public Entidades.Pessoa.Pessoa Pessoa
		{
			get
			{
				return txtPessoa.Pessoa;
			}
		}

		/// <summary>
		/// Chave utilizada para pesquisa.
		/// </summary>
		public TipoChave Chave
		{
			get { return (TipoChave) Enum.Parse(typeof(TipoChave), cmbDado.Text, false); }
		}

		/// <summary>
		/// Mostra a janela para procurar pessoa e também
		/// a de resultados, caso seja mais de um.
		/// </summary>
		/// <returns>Pessoa escolhida ou nulo.</returns>
		public static Entidades.Pessoa.Pessoa Procurar(IWin32Window owner)
		{
			bool procurar;

			do
			{
				procurar = false;

				using (ProcurarPessoa procura = new ProcurarPessoa())
				{
                    DialogResult resultado;

                    if (owner != null)
                        resultado = procura.ShowDialog(owner);
                    else
                        resultado = procura.ShowDialog();

					if (resultado == DialogResult.OK)
					{
						if (procura.Pessoa != null)
							return procura.Pessoa;

						try
						{
                            Entidades.Pessoa.Pessoa pessoa = 
							    Procurar(owner, procura.Chave, procura.Chave == TipoChave.Nome ? procura.txtPessoa.Text : procura.txtProcura.Text);

                            if (pessoa != null)
                                return pessoa;
                            else
                                procurar = true;
						}
						catch (NadaEncontrado)
						{
                            const string msg = "Nenhuma pessoa foi encontrada com os dados fornecidos. Deseja tentar novamente?";
                            const string título = "Procurar por pessoa";

                            if (owner != null)
                                resultado = MessageBox.Show(
                                    owner,
                                    msg,
                                    título,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation);
                            else
                                resultado = MessageBox.Show(
                                    msg,
                                    título,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation);

                            if (resultado == DialogResult.Yes)
                                procurar = true;
						}
					}
				}
			} while (procurar);

			return null;
		}

		private void ProcurarPessoa_Activated(object sender, System.EventArgs e)
		{
			txtPessoa.Focus();
		}

		/// <summary>
		/// Procura os dados desejados e mostra janela de resultados.
		/// </summary>
		/// <param name="tipo">Tipo de chave.</param>
		/// <param name="chave">Texto chave.</param>
		/// <returns>Pessoa escolhida ou nulo.</returns>
		private static Entidades.Pessoa.Pessoa Procurar(IWin32Window owner, TipoChave tipo, string chave)
		{
			List<Entidades.Pessoa.Pessoa> pessoas;

            using (Apresentação.Formulários.Aguarde aguarde =
                       new Apresentação.Formulários.Aguarde(
                       "Procurando no banco de dados.",
                       1,
                       "Procurando pessoas",
                       "Aguarde enquanto o sistema procura no banco de dados pelos dados fornecidos."))
            {
                aguarde.Abrir();

                switch (tipo)
                {
                    case TipoChave.Código:
                        ulong código = 0;
                        bool erro = false;

                        try
                        {
                            código = ulong.Parse(chave);
                        }
                        catch
                        {
                            erro = true;
                        }

                        if (erro)
                            pessoas = new List<Entidades.Pessoa.Pessoa> { };
                        else
                            pessoas = new List<Entidades.Pessoa.Pessoa> { Entidades.Pessoa.Pessoa.ObterPessoa(código) };
                        break;

                    case TipoChave.Nome:
                        pessoas = Entidades.Pessoa.Pessoa.ObterPessoas(chave);
                        break;

                    case TipoChave.CPF:
                        pessoas = new List<Entidades.Pessoa.Pessoa>() { PessoaFísica.ObterPessoaPorCPF(chave) };
                        break;

                    case TipoChave.RG:
                        pessoas = PessoaFísica.ObterPessoasPorRG(chave);
                        break;

                    case TipoChave.CNPJ:
                        pessoas = new List<Entidades.Pessoa.Pessoa>()  { PessoaJurídica.ObterPessoaPorCNPJ(chave) };
                        break;

                    case TipoChave.Telefone:
                        pessoas = Entidades.Pessoa.Pessoa.ObterPessoasPorTelefone(chave);
                        break;

                    case TipoChave.Cidade:
                        pessoas = Entidades.Pessoa.Pessoa.ObterPessoasPorCidade(Localidade.ObterLocalidades(chave.Trim()));
                        break;

                    case TipoChave.Estado:
                        pessoas = Entidades.Pessoa.Pessoa.ObterPessoasPorEstado(Estado.ObterEstados(chave));
                        break;

                    default:
                        throw new NotSupportedException("Chave não suportada: " + Enum.GetName(typeof(TipoChave), tipo));
                }

                if (pessoas.Count == 0)
                {
                    aguarde.Close();
                    throw new NadaEncontrado();
                }
                else if (pessoas.Count == 1)
                    return pessoas[0];
                else
                {
                    aguarde.Passo("Preparando resultado.");

                    using (ProcurarPessoaResultados dlg = new ProcurarPessoaResultados(pessoas))
                    {
                        aguarde.Close();

                        if (dlg.ShowDialog(owner) == DialogResult.OK)
                        {
                            if (dlg.PessoaSelecionada is PessoaFísica)
                            {
                                Entidades.Pessoa.Pessoa pessoa;

                                Apresentação.Formulários.AguardeDB.Mostrar();

                                pessoa = Entidades.Pessoa.Pessoa.ObterPessoa(dlg.PessoaSelecionada.Código);

                                Apresentação.Formulários.AguardeDB.Fechar();

                                return pessoa;
                            }
                            else
                            {
                                return dlg.PessoaSelecionada;
                            }

                        }
                        else
                        {
                            // Cancelar

                        }
                    }
                }
            }

			return null;
		}

		private class NadaEncontrado : Exception
		{}

        private void txtPessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnOK.Enabled)
            {
                //btnOK.Focus();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtProcura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnOK.Enabled)
            {
                //btnOK.Focus();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cmbDado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPessoa.Visible = cmbDado.SelectedItem.ToString() == "Nome";
            txtProcura.Visible = !txtPessoa.Visible;
        }

        private void txtProcura_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtProcura.Text.Trim().Length > 0;
        }

        void txtPessoa_TxtChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtPessoa.Text.Trim().Length > 0;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
	}
}

