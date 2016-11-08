using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Configura��o;

namespace Apresenta��o.Formul�rios
{
	public class Sele��oPer�odo : JanelaExplicativa
	{
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Label lblPer�odoFinal;
		private System.Windows.Forms.DateTimePicker dtIn�cio;
		private System.Windows.Forms.Label lblPer�odoInicial;
		private System.ComponentModel.IContainer components = null;

		public Sele��oPer�odo()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			Iniciar();
		}

		private void Iniciar()
		{
            DateTime hoje = DadosGlobais.Inst�ncia.HoraDataAtual;

			dtIn�cio.Value = new DateTime(
                hoje.Year, hoje.Month,
                hoje.Day, 0, 0, 0, 0);

            dtFinal.Value = new DateTime(hoje.Year, hoje.Month, hoje.Day, 23, 59, 59);

            //dtIn�cio.MaxDate = hoje;
			dtFinal.MinDate = dtIn�cio.MaxDate;
            //dtFinal.MaxDate = new DateTime(hoje.AddMonths(1).Year, hoje.AddMonths(1).Month, hoje.AddMonths(1).Day, 23, 59, 59);
		}

        public DateTime Per�odoInicialM�nimo 
        { 
            get { return dtIn�cio.MinDate; } 
            
            set 
            {
                if (value == DateTime.MinValue)
                    dtIn�cio.MinDate = DateTimePicker.MinimumDateTime;
                else
                    dtIn�cio.MinDate = value; 
            } 
        }
        
        public DateTime Per�odoFinalM�ximo 
        { 
            get { return dtFinal.MaxDate; } 
            
            set 
            {
                if (value == DateTime.MaxValue)
                    dtIn�cio.MaxDate = DateTimePicker.MaximumDateTime;
                else
                    dtFinal.MaxDate = value; 
            }
        }

		public Sele��oPer�odo(string t�tulo, string descri��o)
		{
			InitializeComponent();
			Iniciar();
			this.Text = t�tulo;
			this.lblDescri��o.Text = descri��o;
		}

		public Sele��oPer�odo(string t�tulo, string descri��o, DateTime in�cio, DateTime final)
		{
			InitializeComponent();
			Iniciar();
			this.Text = t�tulo;
			this.lblDescri��o.Text = descri��o;

            try
            {
                dtIn�cio.Value = dtIn�cio.MinDate > in�cio ? dtIn�cio.MinDate : in�cio;
            }
            catch { }

            try
            {
                dtFinal.Value = final;
            }
            catch { }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sele��oPer�odo));
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.lblPer�odoFinal = new System.Windows.Forms.Label();
            this.dtIn�cio = new System.Windows.Forms.DateTimePicker();
            this.lblPer�odoInicial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(153, 20);
            this.lblT�tulo.Text = "Escolha o per�odo";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Text = "Escolha o per�odo desejado.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(305, 168);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 14;
            this.cmdCancelar.Text = "Cancelar";
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(224, 168);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 13;
            this.cmdOK.Text = "OK";
            // 
            // dtFinal
            // 
            this.dtFinal.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, HH:mm";
            this.dtFinal.Location = new System.Drawing.Point(112, 136);
            this.dtFinal.MinDate = new System.DateTime(2003, 12, 1, 0, 0, 0, 0);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(248, 20);
            this.dtFinal.TabIndex = 12;
            this.dtFinal.ValueChanged += new System.EventHandler(this.dtFinal_ValueChanged);
            // 
            // lblPer�odoFinal
            // 
            this.lblPer�odoFinal.AutoSize = true;
            this.lblPer�odoFinal.Location = new System.Drawing.Point(24, 136);
            this.lblPer�odoFinal.Name = "lblPer�odoFinal";
            this.lblPer�odoFinal.Size = new System.Drawing.Size(70, 13);
            this.lblPer�odoFinal.TabIndex = 11;
            this.lblPer�odoFinal.Text = "Per�odo final:";
            // 
            // dtIn�cio
            // 
            this.dtIn�cio.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, HH:mm";
            this.dtIn�cio.Location = new System.Drawing.Point(112, 104);
            this.dtIn�cio.MinDate = new System.DateTime(2003, 12, 1, 0, 0, 0, 0);
            this.dtIn�cio.Name = "dtIn�cio";
            this.dtIn�cio.Size = new System.Drawing.Size(248, 20);
            this.dtIn�cio.TabIndex = 10;
            this.dtIn�cio.ValueChanged += new System.EventHandler(this.dtIn�cio_ValueChanged);
            // 
            // lblPer�odoInicial
            // 
            this.lblPer�odoInicial.AutoSize = true;
            this.lblPer�odoInicial.Location = new System.Drawing.Point(24, 104);
            this.lblPer�odoInicial.Name = "lblPer�odoInicial";
            this.lblPer�odoInicial.Size = new System.Drawing.Size(77, 13);
            this.lblPer�odoInicial.TabIndex = 9;
            this.lblPer�odoInicial.Text = "Per�odo inicial:";
            // 
            // Sele��oPer�odo
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(392, 198);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.dtFinal);
            this.Controls.Add(this.lblPer�odoFinal);
            this.Controls.Add(this.dtIn�cio);
            this.Controls.Add(this.lblPer�odoInicial);
            this.KeyPreview = true;
            this.Name = "Sele��oPer�odo";
            this.Text = "Escolha o per�odo";
            this.Controls.SetChildIndex(this.lblPer�odoInicial, 0);
            this.Controls.SetChildIndex(this.dtIn�cio, 0);
            this.Controls.SetChildIndex(this.lblPer�odoFinal, 0);
            this.Controls.SetChildIndex(this.dtFinal, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public DateTime Per�odoInicial
        {
            get { return this.dtIn�cio.Value; }

            // Usar AtribuirPer�odo() !
            //set
            //{
            //    if (value == DateTime.MinValue)
            //        this.dtIn�cio.Value = DateTimePicker.MinimumDateTime;
            //    else
            //        this.dtIn�cio.Value = value.Date;
            //}
        }

        public DateTime Per�odoFinal
        {
            get { return this.dtFinal.Value; }

            // Usar AtribuirPer�odo() !
            //set
            //{
            //    if (value == DateTime.MaxValue)
            //        this.dtFinal.Value = DateTimePicker.MaximumDateTime;
            //    else
            //        this.dtFinal.Value = value.Date;
            //}
        }
        
        public void AtribuirPer�odo(DateTime in�cio, DateTime fim)
        {
            // Relaxa o controla para n�o dar Exce��o nas atribui��es de in�cio e fim.
            dtIn�cio.MinDate = DateTimePicker.MinimumDateTime;
            dtIn�cio.MaxDate = DateTimePicker.MaximumDateTime;

            if (in�cio == DateTime.MinValue)
                this.dtIn�cio.Value = DateTimePicker.MinimumDateTime;
            else
                this.dtIn�cio.Value = in�cio.Date;

            if (fim == DateTime.MaxValue)
                this.dtFinal.Value = DateTimePicker.MaximumDateTime;
            else
                this.dtFinal.Value = fim.Date; 
        }

		private void dtIn�cio_ValueChanged(object sender, System.EventArgs e)
		{
			dtFinal.MinDate = dtIn�cio.Value.Date;
		}

		private void dtFinal_ValueChanged(object sender, System.EventArgs e)
		{
			dtIn�cio.MaxDate = dtFinal.Value.Date;
		
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

