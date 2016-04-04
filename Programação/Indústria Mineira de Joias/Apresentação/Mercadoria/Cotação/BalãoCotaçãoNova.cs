using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Configuração;

namespace Apresentação.Mercadoria.Cotação
{
	/// <summary>
	/// Balão para escolha de atualização da cotação.
	/// 
	/// O valor retornado em ShowDialog é:
	///   DialogResult.Yes       Usuário escolheu atualizar;
	///   DialogResult.No        Usuário escolheu não atualizar;
	///   DialogResult.Cancel    A cotação se tornou desatualizada.
	/// </summary>
	internal class BalãoCotaçãoNova : BalãoCotação
	{
		private System.Windows.Forms.Label lblDescrição;
		private System.Windows.Forms.RadioButton opçãoAtualizar;
		private System.Windows.Forms.RadioButton opçãoIgnorar;
		private System.Windows.Forms.Label lblFuncionário;
		private System.Windows.Forms.Label lblValor;
		private System.Windows.Forms.TextBox txtFuncionário;
		private System.Windows.Forms.TextBox txtValor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Balão ilustrado para atualização do TxtCotação
		/// </summary>
		/// <param name="novaCotação">Nova cotação cadastrada</param>
		public BalãoCotaçãoNova(Entidades.Financeiro.Cotação novaCotação)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            txtFuncionário.Text = novaCotação.Funcionário.Nome;
            txtValor.Text = novaCotação.Valor.ToString("C", DadosGlobais.Instância.Cultura);
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
            this.lblDescrição = new System.Windows.Forms.Label();
            this.opçãoAtualizar = new System.Windows.Forms.RadioButton();
            this.opçãoIgnorar = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblFuncionário = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtFuncionário = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescrição
            // 
            this.lblDescrição.AutoSize = true;
            this.lblDescrição.Location = new System.Drawing.Point(40, 40);
            this.lblDescrição.Name = "lblDescrição";
            this.lblDescrição.Size = new System.Drawing.Size(186, 13);
            this.lblDescrição.TabIndex = 3;
            this.lblDescrição.Text = "Existe uma nova cotação cadastrada:";
            // 
            // opçãoAtualizar
            // 
            this.opçãoAtualizar.Location = new System.Drawing.Point(40, 128);
            this.opçãoAtualizar.Name = "opçãoAtualizar";
            this.opçãoAtualizar.Size = new System.Drawing.Size(200, 24);
            this.opçãoAtualizar.TabIndex = 0;
            this.opçãoAtualizar.Text = "Atualizar valor desta cotação.";
            this.opçãoAtualizar.CheckedChanged += new System.EventHandler(this.opçãoAtualizar_CheckedChanged);
            // 
            // opçãoIgnorar
            // 
            this.opçãoIgnorar.Location = new System.Drawing.Point(40, 152);
            this.opçãoIgnorar.Name = "opçãoIgnorar";
            this.opçãoIgnorar.Size = new System.Drawing.Size(200, 24);
            this.opçãoIgnorar.TabIndex = 1;
            this.opçãoIgnorar.Text = "Ignorar a nova cotação cadastrada.";
            this.opçãoIgnorar.CheckedChanged += new System.EventHandler(this.opçãoIgnorar_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Location = new System.Drawing.Point(224, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            // 
            // lblFuncionário
            // 
            this.lblFuncionário.AutoSize = true;
            this.lblFuncionário.Location = new System.Drawing.Point(40, 64);
            this.lblFuncionário.Name = "lblFuncionário";
            this.lblFuncionário.Size = new System.Drawing.Size(68, 13);
            this.lblFuncionário.TabIndex = 7;
            this.lblFuncionário.Text = "Funcionário: ";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(40, 80);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 8;
            this.lblValor.Text = "Valor:";
            // 
            // txtFuncionário
            // 
            this.txtFuncionário.BackColor = System.Drawing.SystemColors.Info;
            this.txtFuncionário.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFuncionário.Location = new System.Drawing.Point(112, 64);
            this.txtFuncionário.Name = "txtFuncionário";
            this.txtFuncionário.ReadOnly = true;
            this.txtFuncionário.Size = new System.Drawing.Size(184, 13);
            this.txtFuncionário.TabIndex = 9;
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.SystemColors.Info;
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValor.Location = new System.Drawing.Point(104, 80);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(192, 13);
            this.txtValor.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "O que deseja fazer?";
            // 
            // BalãoCotaçãoNova
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(304, 206);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtFuncionário);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblFuncionário);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.opçãoIgnorar);
            this.Controls.Add(this.opçãoAtualizar);
            this.Controls.Add(this.lblDescrição);
            this.Name = "BalãoCotaçãoNova";
            this.Text = "Nova cotação cadastrada!";
            this.UtilizarTemporizador = false;
            this.Controls.SetChildIndex(this.lblDescrição, 0);
            this.Controls.SetChildIndex(this.opçãoAtualizar, 0);
            this.Controls.SetChildIndex(this.opçãoIgnorar, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.lblFuncionário, 0);
            this.Controls.SetChildIndex(this.lblValor, 0);
            this.Controls.SetChildIndex(this.txtFuncionário, 0);
            this.Controls.SetChildIndex(this.txtValor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        ///// <summary>
        ///// Ocorre quando a cotação sofre alguma ação.
        ///// </summary>
        ///// <param name="sujeito">Cotação recentemente cadastrada.</param>
        //private void ObservaçãoCotação(ISujeito sujeito, int ação, object objeto)
        //{
        //    switch ((AçãoCotação) ação)
        //    {
        //        case AçãoCotação.CotaçãoDesatualizada:
        //            this.DialogResult = DialogResult.Cancel;
        //            this.Close();
        //            break;
        //    }
        //}

		/// <summary>
		/// Ocorre ao escolher a opção atualizar.
		/// </summary>
		private void opçãoAtualizar_CheckedChanged(object sender, System.EventArgs e)
		{
			btnOK.DialogResult = DialogResult.Yes;
			btnOK.Enabled = true;
		}


        protected override void BalãoFoiClicado()
        {
            if (opçãoAtualizar.Checked || opçãoIgnorar.Checked)
                return;
            else
                base.BalãoFoiClicado();

        }

		/// <summary>
		/// Ocorre ao escolher a opção de manter a cotação antiga.
		/// </summary>
		private void opçãoIgnorar_CheckedChanged(object sender, System.EventArgs e)
		{
			btnOK.DialogResult = DialogResult.No;
			btnOK.Enabled = true;
		}
	}
}

