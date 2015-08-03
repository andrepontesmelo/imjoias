using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;

namespace Apresentação.Pessoa
{
    public class EscolherVendedor : Apresentação.Formulários.JanelaExplicativa
    {
        private System.Windows.Forms.Label lblVendedores;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancelar;
        private Apresentação.Pessoa.Consultas.ListViewVendedores lstVendedores;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Escolhe vendedor a partir de uma lista de vendedores.
        /// </summary>
        /// <param name="descrição">Descrição da operação para escolha de vendedor.</param>
        /// <param name="vendedores">Lista de vendedores.</param>
        public EscolherVendedor(string descrição, Entidades.Pessoa.Pessoa[] vendedores)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            lblDescrição.Text = descrição;

            if (this.DesignMode)
                return;

            lstVendedores.Vendedores = new List<Entidades.Pessoa.Pessoa>(vendedores);
        }

        /// <summary>
        /// Escolhe vendedor a partir de uma lista de vendedores.
        /// </summary>
        /// <param name="descrição">Descrição da operação para escolha de vendedor.</param>
        /// <param name="vendedores">Lista de vendedores.</param>
        public EscolherVendedor(string descrição, IEnumerable<Entidades.Pessoa.Pessoa> vendedores)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            lblDescrição.Text = descrição;

            if (this.DesignMode)
                return;

            lstVendedores.Vendedores = vendedores;
        }

        /// <summary>
        /// Escolhe vendedor a partir de uma lista de vendedores, podendo
        /// deixar previamente selecionado um vendedor pelo nome.
        /// </summary>
        /// <param name="descrição">Descrição da operação para escolha de vendedor.</param>
        /// <param name="funcionários">Lista de vendedores.</param>
        /// <param name="nome">Nome do vendedor a selecionar.</param>
        public EscolherVendedor(string descrição, List<Entidades.Pessoa.Pessoa> vendedores, string nome)
            : this(descrição, vendedores)
        {
            lstVendedores.Procurar(nome);
        }

        /// <summary>
        /// Escolhe funcionário a partir do banco de dados.
        /// </summary>
        /// <param name="descrição">Descrição da operação para escolha de vendedor.</param>
        public EscolherVendedor(string descrição)
        {
            InitializeComponent();

            lblDescrição.Text = descrição;

            if (this.DesignMode)
                return;

            Apresentação.Formulários.AguardeDB.Mostrar();

            lstVendedores.Vendedores = Entidades.Pessoa.Pessoa.ObterVendedores();

            Apresentação.Formulários.AguardeDB.Fechar();
        }

        /// <summary>
        /// Escolhe vendedor a partir do banco de dados, podendo
        /// deixar previamente selecionado um vendedor pelo nome.
        /// </summary>
        /// <param name="descrição">Descrição da operação para escolha de vendedor.</param>
        /// <param name="nome">Nome do vendedor a selecionar.</param>
        public EscolherVendedor(string descrição, string nome)
            : this(descrição)
        {
            lstVendedores.Procurar(nome);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstVendedores = new Apresentação.Pessoa.Consultas.ListViewVendedores();
            this.lblVendedores = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTítulo
            // 
            this.lblTítulo.Size = new System.Drawing.Size(158, 20);
            this.lblTítulo.Text = "Escolher vendedor";
            // 
            // lblDescrição
            // 
            this.lblDescrição.Size = new System.Drawing.Size(298, 48);
            this.lblDescrição.Text = "Escolha o vendedor desejado abaixo.";
            // 
            // picÍcone
            // 
            this.picÍcone.Image = global::Apresentação.Pessoa.Properties.Resources.botão___pessoas;
            // 
            // lstVendedores
            // 
            this.lstVendedores.Location = new System.Drawing.Point(24, 120);
            this.lstVendedores.Name = "lstVendedores";
            this.lstVendedores.Size = new System.Drawing.Size(336, 120);
            this.lstVendedores.TabIndex = 0;
            this.lstVendedores.Vendedores = null;
            this.lstVendedores.DoubleClick += new System.EventHandler(this.LstDoubleClick);
            this.lstVendedores.SelectedIndexChanged += new System.EventHandler(this.LstSelectedIndexChanged);
            // 
            // lblVendedores
            // 
            this.lblVendedores.AutoSize = true;
            this.lblVendedores.BackColor = System.Drawing.Color.Transparent;
            this.lblVendedores.Location = new System.Drawing.Point(24, 104);
            this.lblVendedores.Name = "lblVendedores";
            this.lblVendedores.Size = new System.Drawing.Size(67, 13);
            this.lblVendedores.TabIndex = 4;
            this.lblVendedores.Text = "Vendedores:";
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
            // EscolherVendedor
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(386, 288);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lstVendedores);
            this.Controls.Add(this.lblVendedores);
            this.Name = "EscolherVendedor";
            this.Text = "Escolher Vendedor";
            this.Controls.SetChildIndex(this.lblVendedores, 0);
            this.Controls.SetChildIndex(this.lstVendedores, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picÍcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void LstDoubleClick(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void LstSelectedIndexChanged(object sender, System.EventArgs e)
        {
            cmdOK.Enabled = lstVendedores.VendedorSelecionado != null;
        }

        public Entidades.Pessoa.Pessoa Vendedor
        {
            get { return lstVendedores.VendedorSelecionado; }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

    }
}