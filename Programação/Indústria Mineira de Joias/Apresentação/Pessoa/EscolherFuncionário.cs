using Entidades;
using Entidades.Pessoa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Apresentação.Pessoa
{
    public class EscolherFuncionário : Formulários.JanelaExplicativa
	{
		private Label lblFuncionários;
		private Button cmdOK;
		private Button cmdCancelar;
		private Consultas.ListViewFuncionários lstFuncionários;
		private System.ComponentModel.IContainer components = null;

		public EscolherFuncionário(string descrição, IEnumerable<Funcionário> funcionários)
		{
			InitializeComponent();

			lblDescrição.Text = descrição;

			if (this.DesignMode)
				return;

			lstFuncionários.Funcionários = funcionários;
		}

		public EscolherFuncionário(string descrição, List<Funcionário> funcionários, string nome) : this(descrição, funcionários)
		{
			lstFuncionários.Procurar(nome);
		}

        public EscolherFuncionário(string descrição)
        {
            InitializeComponent();

            lblDescrição.Text = descrição;

            if (this.DesignMode)
                return;

            Apresentação.Formulários.AguardeDB.Mostrar();

            lstFuncionários.Funcionários = Entidades.Pessoa.Funcionário.ObterFuncionários(true, false);

            Apresentação.Formulários.AguardeDB.Fechar();
        }

        public EscolherFuncionário(string descrição, string nome) : this(descrição)
        {
            lstFuncionários.Procurar(nome);
        }

        /// <summary>
        /// Setor a se dar ênfase.
        /// </summary>
		public Setor ÊnfaseSetor
		{
			get { return lstFuncionários.ÊnfaseSetor; }
			set { lstFuncionários.ÊnfaseSetor = value; }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscolherFuncionário));
            this.lstFuncionários = new Apresentação.Pessoa.Consultas.ListViewFuncionários();
            this.lblFuncionários = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(173, 20);
            this.lblTítulo.Text = "Escolher funcionário";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(298, 48);
            this.lblDescrição.Text = "Escolha o funcionário desejado abaixo.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
            // 
            // lstVendedores
            // 
            this.lstFuncionários.ÊnfaseSetor = null;
            this.lstFuncionários.Funcionários = null;
            this.lstFuncionários.Location = new System.Drawing.Point(24, 120);
            this.lstFuncionários.Name = "lstFuncionários";
            this.lstFuncionários.Size = new System.Drawing.Size(336, 120);
            this.lstFuncionários.TabIndex = 0;
            this.lstFuncionários.DoubleClick += new System.EventHandler(this.lstFuncionários_DoubleClick);
            this.lstFuncionários.SelectedIndexChanged += new System.EventHandler(this.lstFuncionários_SelectedIndexChanged);
            // 
            // lblFuncionários
            // 
            this.lblFuncionários.AutoSize = true;
            this.lblFuncionários.BackColor = System.Drawing.Color.Transparent;
            this.lblFuncionários.Location = new System.Drawing.Point(24, 104);
            this.lblFuncionários.Name = "lblFuncionários";
            this.lblFuncionários.Size = new System.Drawing.Size(70, 13);
            this.lblFuncionários.TabIndex = 4;
            this.lblFuncionários.Text = "Funcionários:";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdOK.Location = new System.Drawing.Point(216, 256);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelar.Location = new System.Drawing.Point(297, 256);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 6;
            this.cmdCancelar.Text = "Cancelar";
            // 
            // EscolherFuncionário
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(386, 288);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lstFuncionários);
            this.Controls.Add(this.lblFuncionários);
            this.Name = "EscolherFuncionário";
            this.Text = "Escolher Funcionário";
            this.Controls.SetChildIndex(this.lblFuncionários, 0);
            this.Controls.SetChildIndex(this.lstFuncionários, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void lstFuncionários_DoubleClick(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void lstFuncionários_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = lstFuncionários.FuncionárioSelecionado != null;
		}

		public Funcionário Funcionário
		{
			get { return lstFuncionários.FuncionárioSelecionado; }
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}

	}
}