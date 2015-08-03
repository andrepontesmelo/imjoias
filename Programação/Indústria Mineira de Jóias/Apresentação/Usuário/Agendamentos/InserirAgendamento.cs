using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresenta��o.Usu�rio.Agendamentos
{
	/// <summary>
	/// Summary description for InserirAgendamento.
	/// </summary>
	sealed class InserirAgendamento : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.ComponentModel.Container components = null;
		private bool atualiza��oBemSucedida;
		private System.Windows.Forms.TextBox txtDescri��o;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelaBtn;
		private System.Windows.Forms.CheckBox chkDespertar;
		private System.Windows.Forms.DateTimePicker calEvento;
		private System.Windows.Forms.DateTimePicker calDesperta;	//Serve apenas na hora de re-agendar. o agendamentos.cs precisa saber se clicou em ok ou em cancelar. o .ShowDialog n�o funcionou no agendamentos.cs
		private string meuTexto;

		public InserirAgendamento()
		{
			InitializeComponent();

			if (this.DesignMode) 
				return;

			meuTexto = "";
//			meuC�digo = -1;
			atualiza��oBemSucedida = false;

			calDesperta.Value = DateTime.Now;
			calEvento.Value = DateTime.Now;
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InserirAgendamento));
            this.txtDescri��o = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelaBtn = new System.Windows.Forms.Button();
            this.chkDespertar = new System.Windows.Forms.CheckBox();
            this.calEvento = new System.Windows.Forms.DateTimePicker();
            this.calDesperta = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(121, 20);
            this.lblT�tulo.Text = "Agendamento";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(218, 40);
            this.lblDescri��o.Text = "Entre com os dados para o novo agendamento";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // txtDescri��o
            // 
            this.txtDescri��o.Location = new System.Drawing.Point(8, 224);
            this.txtDescri��o.Multiline = true;
            this.txtDescri��o.Name = "txtDescri��o";
            this.txtDescri��o.Size = new System.Drawing.Size(288, 64);
            this.txtDescri��o.TabIndex = 11;
            this.txtDescri��o.TextChanged += new System.EventHandler(this.txtDescri��o_TextChanged);
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Hor�rio do Agendamento:";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(8, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Descri��o do compromisso:";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.okBtn.Location = new System.Drawing.Point(216, 152);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(80, 24);
            this.okBtn.TabIndex = 13;
            this.okBtn.Text = "Inserir";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelaBtn
            // 
            this.cancelaBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelaBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelaBtn.Location = new System.Drawing.Point(216, 184);
            this.cancelaBtn.Name = "cancelaBtn";
            this.cancelaBtn.Size = new System.Drawing.Size(80, 24);
            this.cancelaBtn.TabIndex = 14;
            this.cancelaBtn.Text = "Cancelar";
            this.cancelaBtn.Click += new System.EventHandler(this.cancelaBtn_Click);
            // 
            // chkDespertar
            // 
            this.chkDespertar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkDespertar.Location = new System.Drawing.Point(16, 160);
            this.chkDespertar.Name = "chkDespertar";
            this.chkDespertar.Size = new System.Drawing.Size(144, 16);
            this.chkDespertar.TabIndex = 12;
            this.chkDespertar.Text = "Avise-me neste hor�rio:";
            this.chkDespertar.CheckedChanged += new System.EventHandler(this.chkDespertar_CheckedChanged);
            // 
            // calEvento
            // 
            this.calEvento.CustomFormat = "dd/MM/yyyy HH:mm";
            this.calEvento.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.calEvento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.calEvento.ImeMode = System.Windows.Forms.ImeMode.On;
            this.calEvento.Location = new System.Drawing.Point(8, 120);
            this.calEvento.Name = "calEvento";
            this.calEvento.Size = new System.Drawing.Size(160, 23);
            this.calEvento.TabIndex = 16;
            this.calEvento.Value = new System.DateTime(2004, 5, 22, 0, 0, 0, 0);
            // 
            // calDesperta
            // 
            this.calDesperta.CustomFormat = "dd/MM/yyyy HH:mm";
            this.calDesperta.Enabled = false;
            this.calDesperta.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.calDesperta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.calDesperta.ImeMode = System.Windows.Forms.ImeMode.On;
            this.calDesperta.Location = new System.Drawing.Point(8, 176);
            this.calDesperta.Name = "calDesperta";
            this.calDesperta.Size = new System.Drawing.Size(160, 23);
            this.calDesperta.TabIndex = 17;
            this.calDesperta.Value = new System.DateTime(2004, 5, 22, 0, 0, 0, 0);
            // 
            // InserirAgendamento
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(306, 296);
            this.Controls.Add(this.txtDescri��o);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelaBtn);
            this.Controls.Add(this.chkDespertar);
            this.Controls.Add(this.calEvento);
            this.Controls.Add(this.calDesperta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "InserirAgendamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Agendamento";
            this.Controls.SetChildIndex(this.calDesperta, 0);
            this.Controls.SetChildIndex(this.calEvento, 0);
            this.Controls.SetChildIndex(this.chkDespertar, 0);
            this.Controls.SetChildIndex(this.cancelaBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDescri��o, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void chkDespertar_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkDespertar.Checked == true)
				calDesperta.Enabled = true;
			else
				calDesperta.Enabled = false;
		}

		private void txtDescri��o_TextChanged(object sender, System.EventArgs e)
		{
			if (txtDescri��o.Text.Trim().Length == 0) 
			{
				okBtn.Enabled = false;
			} 
			else 
			{
				okBtn.Enabled = true;
			}
			meuTexto = txtDescri��o.Text;
		}

		private void cancelaBtn_Click(object sender, System.EventArgs e)
		{
			atualiza��oBemSucedida = false;
			this.Close();
		}

		private void okBtn_Click(object sender, System.EventArgs e)
		{
			atualiza��oBemSucedida = true;
			this.Close();
		}
		
		#region Propriedades

		public DateTime HoraEvento
		{
			get
			{ 
				return calEvento.Value;
			}
			set
			{
				calEvento.Value = value;
			}
		}
		public DateTime Alarme
		{
			get
			{
				return  DateTime.Parse(calDesperta.Value.ToString("dd/MM/yyyy HH:mm"));
				//isso � para desprezar os segundos.
			}
			set
			{
				if (value == DateTime.MinValue) 
					chkDespertar.Checked = false;
				else
				{
					chkDespertar.Checked = true;
					calDesperta.Value = value;
				}
			}
		}
		public bool Despertar 
		{
			get
			{
				return chkDespertar.Checked;
			}
		}
		public string Descri��o
		{
			get
			{
				return meuTexto;
			}
			set
			{
				/*Como est� setando um descri��o do lado de fora,
				Ent�o sub-entende-se que va� mudar a extrutura para o modo de Atualiza��o.
				*/
				txtDescri��o.Text = value;
				ModoAtualiza��o();
			}
		}
		/// <summary>
		/// S� para saber se o usu�rio
		/// apertou ok ou n�o.
		/// � usado em agendamentos.cs
		/// logo ap�s uma solicita��o de re-agendamento
		/// no bal�o.
		/// </summary>
		public bool Atualiza��oBemSucedida
		{
			get
			{
				return atualiza��oBemSucedida;
			}
		}
		#endregion

		/// <summary>
		/// Este m�dodo � interno, chamado quando alguem
		/// muda a propriedade Descri��o geralmente publicamente.
		/// Serve para mudar a interface da janel� para o modo de atualiza��o 
		/// de agendamentos.
		/// </summary>
		private void ModoAtualiza��o() 
		{
			okBtn.Text = "Alterar";
			this.Text = "Alterando um agendamento";
			lblDescri��o.Text = "Voc� pode mudar o compromisso, a data e a hora do lembrete.";
			lblDescri��o.Height = 45;
			lblDescri��o.Width = 250;
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
