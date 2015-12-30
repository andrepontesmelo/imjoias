using System.Windows.Forms;

namespace Programa.Recep��o.Formul�rios.Agenda
{
	sealed class Exclus�o : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.Button cmdExcluir;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.IContainer components = null;

		public Exclus�o(string nome)
		{
			InitializeComponent();

			txtNome.Text = nome;
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


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && (keyData == Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exclus�o));
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cmdExcluir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(162, 20);
            this.lblT�tulo.Text = "Confirmar exclus�o";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "O �tem abaixo est� sendo exclu�do. Confirma? (Esta exclus�o afetar� apenas a sua " +
                "agenda)";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(24, 106);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(72, 104);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(296, 20);
            this.txtNome.TabIndex = 4;
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdExcluir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdExcluir.Location = new System.Drawing.Point(222, 136);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.Size = new System.Drawing.Size(75, 23);
            this.cmdExcluir.TabIndex = 5;
            this.cmdExcluir.Text = "Excluir";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(303, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cancelar";
            // 
            // Exclus�o
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(392, 168);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdExcluir);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Name = "Exclus�o";
            this.Text = "Exclus�o de �tem da agenda de telefones";
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.cmdExcluir, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}

