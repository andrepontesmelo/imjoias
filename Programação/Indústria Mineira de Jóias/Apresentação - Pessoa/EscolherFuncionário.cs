using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa
{
	public class EscolherFuncion�rio : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private System.Windows.Forms.Label lblFuncion�rios;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private Apresenta��o.Pessoa.Consultas.ListViewFuncion�rios lstFuncion�rios;
		private System.ComponentModel.IContainer components = null;

        //// <summary>
        ///// Escolhe funcion�rios a partir de uma lista de funcion�rios.
        ///// </summary>
        ///// <param name="descri��o">Descri��o da opera��o para escolha de funcion�rio.</param>
        ///// <param name="funcion�rios">Lista de funcion�rios.</param>
        //[Obsolete("IFuncion�rio est� obsoleto!")]
        //public EscolherFuncion�rio(string descri��o, Neg�cio.IFuncion�rio[] funcion�rios)
        //{
        //    // This call is required by the Windows Form Designer.
        //    InitializeComponent();

        //    lblDescri��o.Text = descri��o;

        //    if (this.DesignMode)
        //        return;

        //    List<Funcion�rio> lista = new List<Funcion�rio>();

        //    foreach (Neg�cio.IFuncion�rio funcion�rio in funcion�rios)
        //        lista.Add(funcion�rio.Dados);

        //    lstFuncion�rios.Funcion�rios = lista;
        //}
        
        /// <summary>
        /// Escolhe funcion�rios a partir de uma lista de funcion�rios.
        /// </summary>
        /// <param name="descri��o">Descri��o da opera��o para escolha de funcion�rio.</param>
        /// <param name="funcion�rios">Lista de funcion�rios.</param>
        public EscolherFuncion�rio(string descri��o, Funcion�rio[] funcion�rios)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            lblDescri��o.Text = descri��o;

            if (this.DesignMode)
                return;

            lstFuncion�rios.Funcion�rios = new List<Funcion�rio>(funcion�rios);
        }

        /// <summary>
        /// Escolhe funcion�rios a partir de uma lista de funcion�rios.
        /// </summary>
        /// <param name="descri��o">Descri��o da opera��o para escolha de funcion�rio.</param>
        /// <param name="funcion�rios">Lista de funcion�rios.</param>
		public EscolherFuncion�rio(string descri��o, IEnumerable<Funcion�rio> funcion�rios)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			lblDescri��o.Text = descri��o;

			if (this.DesignMode)
				return;

			lstFuncion�rios.Funcion�rios = funcion�rios;
		}

		/// <summary>
		/// Escolhe funcion�rios a partir de uma lista de funcion�rios, podendo
        /// deixar um previamente selecionado um funcion�rio pelo nome.
		/// </summary>
		/// <param name="descri��o">Descri��o da opera��o para escolha de funcion�rio.</param>
		/// <param name="funcion�rios">Lista de funcion�rios.</param>
		/// <param name="nome">Nome do funcion�rio a selecionar.</param>
		public EscolherFuncion�rio(string descri��o, List<Funcion�rio> funcion�rios, string nome) : this(descri��o, funcion�rios)
		{
			lstFuncion�rios.Procurar(nome);
		}

        /// <summary>
        /// Escolhe funcion�rio a partir do banco de dados.
        /// </summary>
        /// <param name="descri��o">Descri��o da opera��o para escolha de funcion�rio.</param>
        public EscolherFuncion�rio(string descri��o)
        {
            InitializeComponent();

            lblDescri��o.Text = descri��o;

            if (this.DesignMode)
                return;

            Apresenta��o.Formul�rios.AguardeDB.Mostrar();

            lstFuncion�rios.Funcion�rios = Entidades.Pessoa.Funcion�rio.ObterFuncion�rios(true, false);

            Apresenta��o.Formul�rios.AguardeDB.Fechar();
        }

        /// <summary>
        /// Escolhe funcion�rio a partir do banco de dados, podendo
        /// deixar previamente selecionado um funcion�rio pelo nome.
        /// </summary>
        /// <param name="descri��o">Descri��o da opera��o para escolha de funcion�rio.</param>
        /// <param name="nome">Nome do funcion�rio a selecionar.</param>
        public EscolherFuncion�rio(string descri��o, string nome) : this(descri��o)
        {
            lstFuncion�rios.Procurar(nome);
        }

        /// <summary>
        /// Setor a se dar �nfase.
        /// </summary>
		public Setor �nfaseSetor
		{
			get { return lstFuncion�rios.�nfaseSetor; }
			set { lstFuncion�rios.�nfaseSetor = value; }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscolherFuncion�rio));
            this.lstFuncion�rios = new Apresenta��o.Pessoa.Consultas.ListViewFuncion�rios();
            this.lblFuncion�rios = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblT�tulo
            // 
            this.lblT�tulo.Size = new System.Drawing.Size(173, 20);
            this.lblT�tulo.Text = "Escolher funcion�rio";
            // 
            // lblDescri��o
            // 
            this.lblDescri��o.Size = new System.Drawing.Size(298, 48);
            this.lblDescri��o.Text = "Escolha o funcion�rio desejado abaixo.";
            // 
            // pic�cone
            // 
            this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
            // 
            // lstVendedores
            // 
            this.lstFuncion�rios.�nfaseSetor = null;
            this.lstFuncion�rios.Funcion�rios = null;
            this.lstFuncion�rios.Location = new System.Drawing.Point(24, 120);
            this.lstFuncion�rios.Name = "lstFuncion�rios";
            this.lstFuncion�rios.Size = new System.Drawing.Size(336, 120);
            this.lstFuncion�rios.TabIndex = 0;
            this.lstFuncion�rios.DoubleClick += new System.EventHandler(this.lstFuncion�rios_DoubleClick);
            this.lstFuncion�rios.SelectedIndexChanged += new System.EventHandler(this.lstFuncion�rios_SelectedIndexChanged);
            // 
            // lblFuncion�rios
            // 
            this.lblFuncion�rios.AutoSize = true;
            this.lblFuncion�rios.BackColor = System.Drawing.Color.Transparent;
            this.lblFuncion�rios.Location = new System.Drawing.Point(24, 104);
            this.lblFuncion�rios.Name = "lblFuncion�rios";
            this.lblFuncion�rios.Size = new System.Drawing.Size(70, 13);
            this.lblFuncion�rios.TabIndex = 4;
            this.lblFuncion�rios.Text = "Funcion�rios:";
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
            // EscolherFuncion�rio
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(386, 288);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lstFuncion�rios);
            this.Controls.Add(this.lblFuncion�rios);
            this.Name = "EscolherFuncion�rio";
            this.Text = "Escolher Funcion�rio";
            this.Controls.SetChildIndex(this.lblFuncion�rios, 0);
            this.Controls.SetChildIndex(this.lstFuncion�rios, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pic�cone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void lstFuncion�rios_DoubleClick(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void lstFuncion�rios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = lstFuncion�rios.Funcion�rioSelecionado != null;
		}

		public Funcion�rio Funcion�rio
		{
			get { return lstFuncion�rios.Funcion�rioSelecionado; }
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}

	}
}