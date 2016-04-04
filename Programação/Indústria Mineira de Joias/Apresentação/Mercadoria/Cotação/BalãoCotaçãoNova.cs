using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Configura��o;

namespace Apresenta��o.Mercadoria.Cota��o
{
	/// <summary>
	/// Bal�o para escolha de atualiza��o da cota��o.
	/// 
	/// O valor retornado em ShowDialog �:
	///   DialogResult.Yes       Usu�rio escolheu atualizar;
	///   DialogResult.No        Usu�rio escolheu n�o atualizar;
	///   DialogResult.Cancel    A cota��o se tornou desatualizada.
	/// </summary>
	internal class Bal�oCota��oNova : Bal�oCota��o
	{
		private System.Windows.Forms.Label lblDescri��o;
		private System.Windows.Forms.RadioButton op��oAtualizar;
		private System.Windows.Forms.RadioButton op��oIgnorar;
		private System.Windows.Forms.Label lblFuncion�rio;
		private System.Windows.Forms.Label lblValor;
		private System.Windows.Forms.TextBox txtFuncion�rio;
		private System.Windows.Forms.TextBox txtValor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Bal�o ilustrado para atualiza��o do TxtCota��o
		/// </summary>
		/// <param name="novaCota��o">Nova cota��o cadastrada</param>
		public Bal�oCota��oNova(Entidades.Financeiro.Cota��o novaCota��o)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            txtFuncion�rio.Text = novaCota��o.Funcion�rio.Nome;
            txtValor.Text = novaCota��o.Valor.ToString("C", DadosGlobais.Inst�ncia.Cultura);
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
            this.lblDescri��o = new System.Windows.Forms.Label();
            this.op��oAtualizar = new System.Windows.Forms.RadioButton();
            this.op��oIgnorar = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblFuncion�rio = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtFuncion�rio = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.AutoSize = true;
            this.lblDescri��o.Location = new System.Drawing.Point(40, 40);
            this.lblDescri��o.Name = "lblDescri��o";
            this.lblDescri��o.Size = new System.Drawing.Size(186, 13);
            this.lblDescri��o.TabIndex = 3;
            this.lblDescri��o.Text = "Existe uma nova cota��o cadastrada:";
            // 
            // op��oAtualizar
            // 
            this.op��oAtualizar.Location = new System.Drawing.Point(40, 128);
            this.op��oAtualizar.Name = "op��oAtualizar";
            this.op��oAtualizar.Size = new System.Drawing.Size(200, 24);
            this.op��oAtualizar.TabIndex = 0;
            this.op��oAtualizar.Text = "Atualizar valor desta cota��o.";
            this.op��oAtualizar.CheckedChanged += new System.EventHandler(this.op��oAtualizar_CheckedChanged);
            // 
            // op��oIgnorar
            // 
            this.op��oIgnorar.Location = new System.Drawing.Point(40, 152);
            this.op��oIgnorar.Name = "op��oIgnorar";
            this.op��oIgnorar.Size = new System.Drawing.Size(200, 24);
            this.op��oIgnorar.TabIndex = 1;
            this.op��oIgnorar.Text = "Ignorar a nova cota��o cadastrada.";
            this.op��oIgnorar.CheckedChanged += new System.EventHandler(this.op��oIgnorar_CheckedChanged);
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
            // lblFuncion�rio
            // 
            this.lblFuncion�rio.AutoSize = true;
            this.lblFuncion�rio.Location = new System.Drawing.Point(40, 64);
            this.lblFuncion�rio.Name = "lblFuncion�rio";
            this.lblFuncion�rio.Size = new System.Drawing.Size(68, 13);
            this.lblFuncion�rio.TabIndex = 7;
            this.lblFuncion�rio.Text = "Funcion�rio: ";
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
            // txtFuncion�rio
            // 
            this.txtFuncion�rio.BackColor = System.Drawing.SystemColors.Info;
            this.txtFuncion�rio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFuncion�rio.Location = new System.Drawing.Point(112, 64);
            this.txtFuncion�rio.Name = "txtFuncion�rio";
            this.txtFuncion�rio.ReadOnly = true;
            this.txtFuncion�rio.Size = new System.Drawing.Size(184, 13);
            this.txtFuncion�rio.TabIndex = 9;
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
            // Bal�oCota��oNova
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(304, 206);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtFuncion�rio);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblFuncion�rio);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.op��oIgnorar);
            this.Controls.Add(this.op��oAtualizar);
            this.Controls.Add(this.lblDescri��o);
            this.Name = "Bal�oCota��oNova";
            this.Text = "Nova cota��o cadastrada!";
            this.UtilizarTemporizador = false;
            this.Controls.SetChildIndex(this.lblDescri��o, 0);
            this.Controls.SetChildIndex(this.op��oAtualizar, 0);
            this.Controls.SetChildIndex(this.op��oIgnorar, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.lblFuncion�rio, 0);
            this.Controls.SetChildIndex(this.lblValor, 0);
            this.Controls.SetChildIndex(this.txtFuncion�rio, 0);
            this.Controls.SetChildIndex(this.txtValor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        ///// <summary>
        ///// Ocorre quando a cota��o sofre alguma a��o.
        ///// </summary>
        ///// <param name="sujeito">Cota��o recentemente cadastrada.</param>
        //private void Observa��oCota��o(ISujeito sujeito, int a��o, object objeto)
        //{
        //    switch ((A��oCota��o) a��o)
        //    {
        //        case A��oCota��o.Cota��oDesatualizada:
        //            this.DialogResult = DialogResult.Cancel;
        //            this.Close();
        //            break;
        //    }
        //}

		/// <summary>
		/// Ocorre ao escolher a op��o atualizar.
		/// </summary>
		private void op��oAtualizar_CheckedChanged(object sender, System.EventArgs e)
		{
			btnOK.DialogResult = DialogResult.Yes;
			btnOK.Enabled = true;
		}


        protected override void Bal�oFoiClicado()
        {
            if (op��oAtualizar.Checked || op��oIgnorar.Checked)
                return;
            else
                base.Bal�oFoiClicado();

        }

		/// <summary>
		/// Ocorre ao escolher a op��o de manter a cota��o antiga.
		/// </summary>
		private void op��oIgnorar_CheckedChanged(object sender, System.EventArgs e)
		{
			btnOK.DialogResult = DialogResult.No;
			btnOK.Enabled = true;
		}
	}
}

