using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Programa.Recepção.BaseInferior.Controles
{
	/// <summary>
	/// Controle para exibição de funcionários ausentes.
	/// </summary>
	sealed class FuncionárioAusência : Apresentação.Formulários.Quadro, Apresentação.Formulários.IPósCargaSistema
	{
        public delegate void AoAlterarAusênciaCallback(Funcionário funcionário);

        public event AoAlterarAusênciaCallback AoAlterarAusência;

        private bool limpando = false;

		// Designer
		private System.Windows.Forms.CheckedListBox chkAusentes;
		private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
		private System.ComponentModel.IContainer components = null;

		public FuncionárioAusência()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
		public void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
		{
			chkAusentes.BackColor = this.BackColor;

			lock (this)
			{
				// Inserir funcionários ausentes.
				foreach (Funcionário funcionário in Funcionário.ObterFuncionários(true, false))
					if (funcionário.Situação == EstadoFuncionário.Ausente)
						AdicionarFuncionário(funcionário);
			}
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
            this.components = new System.ComponentModel.Container();
            this.chkAusentes = new System.Windows.Forms.CheckedListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // chkAusentes
            // 
            this.chkAusentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAusentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkAusentes.CheckOnClick = true;
            this.chkAusentes.IntegralHeight = false;
            this.chkAusentes.Location = new System.Drawing.Point(8, 32);
            this.chkAusentes.Name = "chkAusentes";
            this.chkAusentes.Size = new System.Drawing.Size(248, 128);
            this.chkAusentes.Sorted = true;
            this.chkAusentes.TabIndex = 2;
            this.toolTip.SetToolTip(this.chkAusentes, "Marque os funcionários que estiverem presentes na empresa.");
            this.chkAusentes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkAusentes_ItemCheck);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FuncionárioAusência
            // 
            this.Controls.Add(this.chkAusentes);
            this.Name = "FuncionárioAusência";
            this.Size = new System.Drawing.Size(264, 168);
            this.Título = "Funcionários Ausentes";
            this.Controls.SetChildIndex(this.chkAusentes, 0);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Adiciona funcionário ausente.
		/// </summary>
		/// <param name="funcionário">Funcionário ausente.</param>
		public void AdicionarFuncionário(Funcionário funcionário)
		{
			lock (this)
			{
				if (!chkAusentes.Items.Contains(funcionário) && funcionário.Situação == EstadoFuncionário.Ausente)
				{
					try
					{
						chkAusentes.Items.Add(funcionário);
					}
					catch (Exception e)
					{
						MessageBox.Show(
							"Não foi possível adicionar funcionário à lista de funcionários ausentes!",
							"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
						Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
					}
				}
			}
		}

		/// <summary>
		/// Remove funcionário ausente.
		/// </summary>
		/// <param name="funcionário">Funcionário ausente.</param>
		public void RemoverFuncionário(Funcionário funcionário)
		{
			lock (this)
			{
				try
				{
                    if (limpando)
                        chkAusentes.Items.Remove(funcionário);
                    else
                    {
                        if (chkAusentes.Items.Contains(funcionário))
                        {
                            int idx = chkAusentes.Items.IndexOf(funcionário);

                            if (!chkAusentes.GetItemChecked(idx))
                                chkAusentes.SetItemChecked(idx, true);
                        }
                    }
				}
				catch (Exception e)
				{
					MessageBox.Show(
						"Não foi possível remover funcionário da lista de funcionários ausentes!",
						"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					throw new Exception("Não foi possível remover funcionário da lista de funcionários ausentes!", e);
				}
			}
		}

		/// <summary>
		/// Inicia remoção de funcionário da lista de ausentes.
		/// </summary>
		/// <param name="funcionário">Funcionário ausente.</param>
		private void IniciarRemoçãoFuncionário(Funcionário funcionário)
		{
			int index;

			index = chkAusentes.Items.IndexOf(funcionário);

			if (index < 0)
				throw new Exception("Funcionário não encontrado na lista de funcionários ausentes.");

			if (funcionário.Situação == EstadoFuncionário.Ausente)
				funcionário.Situação = EstadoFuncionário.Disponível;
		}

		/// <summary>
		/// Cancela remoção de funcionário da lista de ausentes.
		/// </summary>
		private static void CancelarRemoçãoFuncionário(Funcionário funcionário)
		{
			funcionário.Situação = EstadoFuncionário.Ausente;
		}

		/// <summary>
		/// Ocorre ao mudar marca de um item.
		/// </summary>
		private void chkAusentes_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
            lock (this)
            {
                try
                {
                    Funcionário funcionário = (Funcionário)chkAusentes.Items[e.Index];

                    Cursor = Cursors.WaitCursor;

                    if (e.NewValue == CheckState.Checked)
                        IniciarRemoçãoFuncionário(funcionário);
                    else
                        CancelarRemoçãoFuncionário(funcionário);

                    AoAlterarAusência(funcionário);

                    timer.Enabled = true;
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(erro);

                    MessageBox.Show(
                        "Não foi possível alterar estado do funcionário.",
                        "Atribuição de ausência", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
		}

		/// <summary>
		/// Limpa a lista.
		/// </summary>
		private void LimparCheckList()
		{
			try
			{
				lock (this)
				{
					Funcionário [] itensRemoção;

                    limpando = true;
                    itensRemoção = new Funcionário[chkAusentes.CheckedItems.Count];

					chkAusentes.CheckedItems.CopyTo(itensRemoção, 0);
					
					foreach (Funcionário funcionário in itensRemoção)
						RemoverFuncionário(funcionário);
				}
			}
			catch (Exception e)
			{
				Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
			}
			finally
			{
                limpando = false;
                chkAusentes.Refresh();
			}
		}

        public override bool Focused
        {
            get
            {
                return base.Focused || chkAusentes.Focused;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LimparCheckList();
            timer.Enabled = false;
        }
    }
}
