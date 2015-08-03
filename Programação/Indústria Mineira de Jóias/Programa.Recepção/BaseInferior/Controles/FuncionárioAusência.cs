using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Programa.Recep��o.BaseInferior.Controles
{
	/// <summary>
	/// Controle para exibi��o de funcion�rios ausentes.
	/// </summary>
	sealed class Funcion�rioAus�ncia : Apresenta��o.Formul�rios.Quadro, Apresenta��o.Formul�rios.IP�sCargaSistema
	{
        public delegate void AoAlterarAus�nciaCallback(Funcion�rio funcion�rio);

        public event AoAlterarAus�nciaCallback AoAlterarAus�ncia;

        private bool limpando = false;

		// Designer
		private System.Windows.Forms.CheckedListBox chkAusentes;
		private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
		private System.ComponentModel.IContainer components = null;

		public Funcion�rioAus�ncia()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
		public void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
		{
			chkAusentes.BackColor = this.BackColor;

			lock (this)
			{
				// Inserir funcion�rios ausentes.
				foreach (Funcion�rio funcion�rio in Funcion�rio.ObterFuncion�rios(true, false))
					if (funcion�rio.Situa��o == EstadoFuncion�rio.Ausente)
						AdicionarFuncion�rio(funcion�rio);
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
            this.toolTip.SetToolTip(this.chkAusentes, "Marque os funcion�rios que estiverem presentes na empresa.");
            this.chkAusentes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkAusentes_ItemCheck);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Funcion�rioAus�ncia
            // 
            this.Controls.Add(this.chkAusentes);
            this.Name = "Funcion�rioAus�ncia";
            this.Size = new System.Drawing.Size(264, 168);
            this.T�tulo = "Funcion�rios Ausentes";
            this.Controls.SetChildIndex(this.chkAusentes, 0);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Adiciona funcion�rio ausente.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio ausente.</param>
		public void AdicionarFuncion�rio(Funcion�rio funcion�rio)
		{
			lock (this)
			{
				if (!chkAusentes.Items.Contains(funcion�rio) && funcion�rio.Situa��o == EstadoFuncion�rio.Ausente)
				{
					try
					{
						chkAusentes.Items.Add(funcion�rio);
					}
					catch (Exception e)
					{
						MessageBox.Show(
							"N�o foi poss�vel adicionar funcion�rio � lista de funcion�rios ausentes!",
							"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
						Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
					}
				}
			}
		}

		/// <summary>
		/// Remove funcion�rio ausente.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio ausente.</param>
		public void RemoverFuncion�rio(Funcion�rio funcion�rio)
		{
			lock (this)
			{
				try
				{
                    if (limpando)
                        chkAusentes.Items.Remove(funcion�rio);
                    else
                    {
                        if (chkAusentes.Items.Contains(funcion�rio))
                        {
                            int idx = chkAusentes.Items.IndexOf(funcion�rio);

                            if (!chkAusentes.GetItemChecked(idx))
                                chkAusentes.SetItemChecked(idx, true);
                        }
                    }
				}
				catch (Exception e)
				{
					MessageBox.Show(
						"N�o foi poss�vel remover funcion�rio da lista de funcion�rios ausentes!",
						"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					throw new Exception("N�o foi poss�vel remover funcion�rio da lista de funcion�rios ausentes!", e);
				}
			}
		}

		/// <summary>
		/// Inicia remo��o de funcion�rio da lista de ausentes.
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio ausente.</param>
		private void IniciarRemo��oFuncion�rio(Funcion�rio funcion�rio)
		{
			int index;

			index = chkAusentes.Items.IndexOf(funcion�rio);

			if (index < 0)
				throw new Exception("Funcion�rio n�o encontrado na lista de funcion�rios ausentes.");

			if (funcion�rio.Situa��o == EstadoFuncion�rio.Ausente)
				funcion�rio.Situa��o = EstadoFuncion�rio.Dispon�vel;
		}

		/// <summary>
		/// Cancela remo��o de funcion�rio da lista de ausentes.
		/// </summary>
		private static void CancelarRemo��oFuncion�rio(Funcion�rio funcion�rio)
		{
			funcion�rio.Situa��o = EstadoFuncion�rio.Ausente;
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
                    Funcion�rio funcion�rio = (Funcion�rio)chkAusentes.Items[e.Index];

                    Cursor = Cursors.WaitCursor;

                    if (e.NewValue == CheckState.Checked)
                        IniciarRemo��oFuncion�rio(funcion�rio);
                    else
                        CancelarRemo��oFuncion�rio(funcion�rio);

                    AoAlterarAus�ncia(funcion�rio);

                    timer.Enabled = true;
                }
                catch (Exception erro)
                {
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(erro);

                    MessageBox.Show(
                        "N�o foi poss�vel alterar estado do funcion�rio.",
                        "Atribui��o de aus�ncia", MessageBoxButtons.OK,
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
					Funcion�rio [] itensRemo��o;

                    limpando = true;
                    itensRemo��o = new Funcion�rio[chkAusentes.CheckedItems.Count];

					chkAusentes.CheckedItems.CopyTo(itensRemo��o, 0);
					
					foreach (Funcion�rio funcion�rio in itensRemo��o)
						RemoverFuncion�rio(funcion�rio);
				}
			}
			catch (Exception e)
			{
				Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
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
