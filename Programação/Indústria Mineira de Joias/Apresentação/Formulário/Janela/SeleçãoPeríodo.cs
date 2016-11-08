using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Configuração;

namespace Apresentação.Formulários
{
	public class SeleçãoPeríodo : JanelaExplicativa
	{
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Label lblPeríodoFinal;
		private System.Windows.Forms.DateTimePicker dtInício;
		private System.Windows.Forms.Label lblPeríodoInicial;
		private System.ComponentModel.IContainer components = null;

		public SeleçãoPeríodo()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			Iniciar();
		}

		private void Iniciar()
		{
            DateTime hoje = DadosGlobais.Instância.HoraDataAtual;

			dtInício.Value = new DateTime(
                hoje.Year, hoje.Month,
                hoje.Day, 0, 0, 0, 0);

            dtFinal.Value = new DateTime(hoje.Year, hoje.Month, hoje.Day, 23, 59, 59);

            //dtInício.MaxDate = hoje;
			dtFinal.MinDate = dtInício.MaxDate;
            //dtFinal.MaxDate = new DateTime(hoje.AddMonths(1).Year, hoje.AddMonths(1).Month, hoje.AddMonths(1).Day, 23, 59, 59);
		}

        public DateTime PeríodoInicialMínimo 
        { 
            get { return dtInício.MinDate; } 
            
            set 
            {
                if (value == DateTime.MinValue)
                    dtInício.MinDate = DateTimePicker.MinimumDateTime;
                else
                    dtInício.MinDate = value; 
            } 
        }
        
        public DateTime PeríodoFinalMáximo 
        { 
            get { return dtFinal.MaxDate; } 
            
            set 
            {
                if (value == DateTime.MaxValue)
                    dtInício.MaxDate = DateTimePicker.MaximumDateTime;
                else
                    dtFinal.MaxDate = value; 
            }
        }

		public SeleçãoPeríodo(string título, string descrição)
		{
			InitializeComponent();
			Iniciar();
			this.Text = título;
			this.lblDescrição.Text = descrição;
		}

		public SeleçãoPeríodo(string título, string descrição, DateTime início, DateTime final)
		{
			InitializeComponent();
			Iniciar();
			this.Text = título;
			this.lblDescrição.Text = descrição;

            try
            {
                dtInício.Value = dtInício.MinDate > início ? dtInício.MinDate : início;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleçãoPeríodo));
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.lblPeríodoFinal = new System.Windows.Forms.Label();
            this.dtInício = new System.Windows.Forms.DateTimePicker();
            this.lblPeríodoInicial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(153, 20);
            this.lblTítulo.Text = "Escolha o período";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Text = "Escolha o período desejado.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
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
            // lblPeríodoFinal
            // 
            this.lblPeríodoFinal.AutoSize = true;
            this.lblPeríodoFinal.Location = new System.Drawing.Point(24, 136);
            this.lblPeríodoFinal.Name = "lblPeríodoFinal";
            this.lblPeríodoFinal.Size = new System.Drawing.Size(70, 13);
            this.lblPeríodoFinal.TabIndex = 11;
            this.lblPeríodoFinal.Text = "Período final:";
            // 
            // dtInício
            // 
            this.dtInício.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy, HH:mm";
            this.dtInício.Location = new System.Drawing.Point(112, 104);
            this.dtInício.MinDate = new System.DateTime(2003, 12, 1, 0, 0, 0, 0);
            this.dtInício.Name = "dtInício";
            this.dtInício.Size = new System.Drawing.Size(248, 20);
            this.dtInício.TabIndex = 10;
            this.dtInício.ValueChanged += new System.EventHandler(this.dtInício_ValueChanged);
            // 
            // lblPeríodoInicial
            // 
            this.lblPeríodoInicial.AutoSize = true;
            this.lblPeríodoInicial.Location = new System.Drawing.Point(24, 104);
            this.lblPeríodoInicial.Name = "lblPeríodoInicial";
            this.lblPeríodoInicial.Size = new System.Drawing.Size(77, 13);
            this.lblPeríodoInicial.TabIndex = 9;
            this.lblPeríodoInicial.Text = "Período inicial:";
            // 
            // SeleçãoPeríodo
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(392, 198);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.dtFinal);
            this.Controls.Add(this.lblPeríodoFinal);
            this.Controls.Add(this.dtInício);
            this.Controls.Add(this.lblPeríodoInicial);
            this.KeyPreview = true;
            this.Name = "SeleçãoPeríodo";
            this.Text = "Escolha o período";
            this.Controls.SetChildIndex(this.lblPeríodoInicial, 0);
            this.Controls.SetChildIndex(this.dtInício, 0);
            this.Controls.SetChildIndex(this.lblPeríodoFinal, 0);
            this.Controls.SetChildIndex(this.dtFinal, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public DateTime PeríodoInicial
        {
            get { return this.dtInício.Value; }

            // Usar AtribuirPeríodo() !
            //set
            //{
            //    if (value == DateTime.MinValue)
            //        this.dtInício.Value = DateTimePicker.MinimumDateTime;
            //    else
            //        this.dtInício.Value = value.Date;
            //}
        }

        public DateTime PeríodoFinal
        {
            get { return this.dtFinal.Value; }

            // Usar AtribuirPeríodo() !
            //set
            //{
            //    if (value == DateTime.MaxValue)
            //        this.dtFinal.Value = DateTimePicker.MaximumDateTime;
            //    else
            //        this.dtFinal.Value = value.Date;
            //}
        }
        
        public void AtribuirPeríodo(DateTime início, DateTime fim)
        {
            // Relaxa o controla para não dar Exceção nas atribuições de início e fim.
            dtInício.MinDate = DateTimePicker.MinimumDateTime;
            dtInício.MaxDate = DateTimePicker.MaximumDateTime;

            if (início == DateTime.MinValue)
                this.dtInício.Value = DateTimePicker.MinimumDateTime;
            else
                this.dtInício.Value = início.Date;

            if (fim == DateTime.MaxValue)
                this.dtFinal.Value = DateTimePicker.MaximumDateTime;
            else
                this.dtFinal.Value = fim.Date; 
        }

		private void dtInício_ValueChanged(object sender, System.EventArgs e)
		{
			dtFinal.MinDate = dtInício.Value.Date;
		}

		private void dtFinal_ValueChanged(object sender, System.EventArgs e)
		{
			dtInício.MaxDate = dtFinal.Value.Date;
		
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

