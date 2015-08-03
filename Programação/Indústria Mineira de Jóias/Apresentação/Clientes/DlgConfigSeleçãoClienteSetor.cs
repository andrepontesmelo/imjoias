using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Configura��o;
using AMS;
using Apresenta��o.Formul�rios;
using System.Collections.Generic;

namespace Apresenta��o.Atendimento.Clientes
{
	/// <summary>
	/// Janela de configura��o da base inferior BaseSele��oClienteSetor
	/// </summary>
	internal class DlgConfigSele��oClienteSetor : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		/// <summary>
		/// Base inferior a ser configurada.
		/// </summary>
		private BaseSele��oClienteSetor baseInferior;

		/// <summary>
		/// Base inferior a ser configurada.
		/// </summary>
		private string chaveConfigura��o;

		/// <summary>
		/// Poss�veis setores.
		/// </summary>
		private Setor [] setores;

        private Setor setorNE = Setor.ObterSetor(Setor.SetorSistema.N�oEspecificado);

		// Controles
		private System.Windows.Forms.CheckedListBox chkSetores;
		private System.Windows.Forms.Label lblEscolha;
		private System.Windows.Forms.Label lblUsu�rio;
		private System.Windows.Forms.Label lblOl�;
		private System.Windows.Forms.Label lblExplica��oTempoM�ximo;
		private System.Windows.Forms.Label lblTempoM�ximo;
		private AMS.TextBox.NumericTextBox txtDias;
		//private System.Windows.Forms.TextBox txtDias;
		private System.Windows.Forms.Label lblDias;
		private Apresenta��o.Formul�rios.Assistente.AssistenteControle assistente;
		private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelSetores;
		private Apresenta��o.Formul�rios.Assistente.PainelAssistente painelTempoM�ximo;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constr�i a janela
		/// </summary>
		public DlgConfigSele��oClienteSetor(BaseSele��oClienteSetor baseInferior, string chaveConfigura��o, Setor [] setores)
		{
            List<Setor> listaSetores = new List<Setor>(setores);

            if (!listaSetores.Contains(setorNE))
                listaSetores.Add(setorNE);

			// This call is required by the Windows Form Designer.
			InitializeComponent();

            listaSetores.Sort(delegate(Setor a, Setor b)
            {
                return a.Nome.CompareTo(b.Nome);
            });


			this.baseInferior      = baseInferior;
			this.chaveConfigura��o = chaveConfigura��o;
			this.setores           = listaSetores.ToArray();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgConfigSele��oClienteSetor));
			this.assistente = new Apresenta��o.Formul�rios.Assistente.AssistenteControle();
			this.painelSetores = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
			this.chkSetores = new System.Windows.Forms.CheckedListBox();
			this.lblEscolha = new System.Windows.Forms.Label();
			this.lblUsu�rio = new System.Windows.Forms.Label();
			this.lblOl� = new System.Windows.Forms.Label();
			this.painelTempoM�ximo = new Apresenta��o.Formul�rios.Assistente.PainelAssistente();
			this.lblDias = new System.Windows.Forms.Label();
			this.txtDias = new AMS.TextBox.NumericTextBox();
			this.lblTempoM�ximo = new System.Windows.Forms.Label();
			this.lblExplica��oTempoM�ximo = new System.Windows.Forms.Label();
			this.assistente.SuspendLayout();
			this.painelSetores.SuspendLayout();
			this.painelTempoM�ximo.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(254, 22);
			this.lblT�tulo.Text = "Configura��o da lista de clientes";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(266, 48);
			this.lblDescri��o.Text = "Este assistente lhe auxiliar� a configurar a lista de cilentes que ser� exibida.";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Name = "pic�cone";
			// 
			// assistente
			// 
			this.assistente.Controls.Add(this.painelSetores);
			this.assistente.Controls.Add(this.painelTempoM�ximo);
			this.assistente.Itens = new Apresenta��o.Formul�rios.Assistente.PainelAssistente[] {
																								   this.painelSetores,
																								   this.painelTempoM�ximo};
			this.assistente.Location = new System.Drawing.Point(8, 96);
			this.assistente.Name = "assistente";
			this.assistente.Size = new System.Drawing.Size(336, 176);
			this.assistente.TabIndex = 4;
			this.assistente.Terminado += new System.EventHandler(this.assistente_Terminado);
			// 
			// painelSetores
			// 
			this.painelSetores.AutoScroll = true;
			this.painelSetores.Controls.Add(this.chkSetores);
			this.painelSetores.Controls.Add(this.lblEscolha);
			this.painelSetores.Controls.Add(this.lblUsu�rio);
			this.painelSetores.Controls.Add(this.lblOl�);
			this.painelSetores.Location = new System.Drawing.Point(0, 0);
			this.painelSetores.Name = "painelSetores";
			this.painelSetores.Size = new System.Drawing.Size(336, 144);
			this.painelSetores.TabIndex = 1;
			this.painelSetores.ValidandoTransi��o += new System.ComponentModel.CancelEventHandler(this.painelSetores_ValidandoTransi��o);
			// 
			// chkSetores
			// 
			this.chkSetores.CheckOnClick = true;
			this.chkSetores.IntegralHeight = false;
			this.chkSetores.Location = new System.Drawing.Point(88, 48);
			this.chkSetores.Name = "chkSetores";
			this.chkSetores.Size = new System.Drawing.Size(176, 80);
			this.chkSetores.TabIndex = 3;
			// 
			// lblEscolha
			// 
			this.lblEscolha.AutoSize = true;
			this.lblEscolha.Location = new System.Drawing.Point(8, 24);
			this.lblEscolha.Name = "lblEscolha";
			this.lblEscolha.Size = new System.Drawing.Size(254, 16);
			this.lblEscolha.TabIndex = 2;
			this.lblEscolha.Text = "Escolha com quais setores voc� deseja trabalhar.";
			// 
			// lblUsu�rio
			// 
			this.lblUsu�rio.AutoSize = true;
			this.lblUsu�rio.Location = new System.Drawing.Point(32, 8);
			this.lblUsu�rio.Name = "lblUsu�rio";
			this.lblUsu�rio.Size = new System.Drawing.Size(41, 16);
			this.lblUsu�rio.TabIndex = 1;
			this.lblUsu�rio.Text = "usu�rio";
			// 
			// lblOl�
			// 
			this.lblOl�.AutoSize = true;
			this.lblOl�.Location = new System.Drawing.Point(8, 8);
			this.lblOl�.Name = "lblOl�";
			this.lblOl�.Size = new System.Drawing.Size(25, 16);
			this.lblOl�.TabIndex = 0;
			this.lblOl�.Text = "Ol�,";
			// 
			// painelTempoM�ximo
			// 
			this.painelTempoM�ximo.AutoScroll = true;
			this.painelTempoM�ximo.Controls.Add(this.lblDias);
			this.painelTempoM�ximo.Controls.Add(this.txtDias);
			this.painelTempoM�ximo.Controls.Add(this.lblTempoM�ximo);
			this.painelTempoM�ximo.Controls.Add(this.lblExplica��oTempoM�ximo);
			this.painelTempoM�ximo.Location = new System.Drawing.Point(0, 0);
			this.painelTempoM�ximo.Name = "painelTempoM�ximo";
			this.painelTempoM�ximo.Size = new System.Drawing.Size(336, 144);
			this.painelTempoM�ximo.TabIndex = 2;
			this.painelTempoM�ximo.ValidandoTransi��o += new System.ComponentModel.CancelEventHandler(this.painelTempoM�ximo_ValidandoTransi��o);
			// 
			// lblDias
			// 
			this.lblDias.AutoSize = true;
			this.lblDias.Location = new System.Drawing.Point(216, 80);
			this.lblDias.Name = "lblDias";
			this.lblDias.Size = new System.Drawing.Size(28, 16);
			this.lblDias.TabIndex = 3;
			this.lblDias.Text = "dias.";
			// 
			// txtDias
			// 
			this.txtDias.AllowNegative = true;
			this.txtDias.DigitsInGroup = 0;
			this.txtDias.Flags = 0;
			this.txtDias.Location = new System.Drawing.Point(152, 78);
			this.txtDias.MaxDecimalPlaces = 0;
			this.txtDias.MaxWholeDigits = 5;
			this.txtDias.Name = "txtDias";
			this.txtDias.Prefix = "";
			this.txtDias.RangeMax = 99999;
			this.txtDias.RangeMin = 0;
			this.txtDias.Size = new System.Drawing.Size(56, 20);
			this.txtDias.TabIndex = 2;
			this.txtDias.Text = "90";
			this.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblTempoM�ximo
			// 
			this.lblTempoM�ximo.AutoSize = true;
			this.lblTempoM�ximo.Location = new System.Drawing.Point(64, 80);
			this.lblTempoM�ximo.Name = "lblTempoM�ximo";
			this.lblTempoM�ximo.Size = new System.Drawing.Size(85, 16);
			this.lblTempoM�ximo.TabIndex = 1;
			this.lblTempoM�ximo.Text = "Tempo m�ximo:";
			// 
			// lblExplica��oTempoM�ximo
			// 
			this.lblExplica��oTempoM�ximo.Location = new System.Drawing.Point(8, 8);
			this.lblExplica��oTempoM�ximo.Name = "lblExplica��oTempoM�ximo";
			this.lblExplica��oTempoM�ximo.Size = new System.Drawing.Size(320, 40);
			this.lblExplica��oTempoM�ximo.TabIndex = 0;
			this.lblExplica��oTempoM�ximo.Text = "Para facilitar a visualiza��o da lista de clientes, voc� pode especificar um temp" +
				"o m�ximo com que o cliente tenha visitado a firma para que ele apare�a na lista." +
				"";
			// 
			// DlgConfigSele��oClienteSetor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 280);
			this.Controls.Add(this.assistente);
			this.Name = "DlgConfigSele��oClienteSetor";
			this.Text = "Lista de Clientes";
			this.Load += new System.EventHandler(this.DlgConfigSele��oClienteSetor_Load);
			this.Controls.SetChildIndex(this.assistente, 0);
			this.assistente.ResumeLayout(false);
			this.painelSetores.ResumeLayout(false);
			this.painelTempoM�ximo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao carregar a janela.
		/// </summary>
		private void DlgConfigSele��oClienteSetor_Load(object sender, System.EventArgs e)
		{
            Configura��oUsu�rio<int> prazo;
            Configura��oUsu�rio<bool> bSetor;

            AguardeDB.Mostrar();

            // Mostra nome do usu�rio.
			lblUsu�rio.Text = Acesso.Comum.Usu�rios.Usu�rioAtual.Nome + "!";

			// Carrega setores.
			chkSetores.Items.AddRange(setores);

			for (int i = 0; i < setores.Length; i++)
			{
                bSetor = new Configura��oUsu�rio<bool>(chaveConfigura��o + ": setor " + setores[i].Nome, false);

				chkSetores.SetItemChecked(
					i,
					bSetor.Valor);
			}

			// Carrega prazo.
            prazo = new Configura��oUsu�rio<int>(chaveConfigura��o + ": prazo", 90);
			txtDias.Int = prazo.Valor;

            AguardeDB.Fechar();
		}

		/// <summary>
		/// Ocorre ao sair do painelSetores.
		/// </summary>
		private void painelSetores_ValidandoTransi��o(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (chkSetores.CheckedItems.Count == 0)
			{
				MessageBox.Show(
					this,
                    "Voc� deve escolher pelo menos um setor de atendimento.",
                    "Lista de pessoas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				e.Cancel = true;
			}
		}

		/// <summary>
		/// Ocorre ao sair do painelTempoM�ximo
		/// </summary>
		private void painelTempoM�ximo_ValidandoTransi��o(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int valor;

			try
			{
				valor = int.Parse(txtDias.Text);
			}
			catch (Exception)
			{
				MessageBox.Show(
					this,
					"O valor definido para dias n�o � num�rico.",
					"Lista de pessoas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				e.Cancel = true;

				return;
			}

			if (valor <= 0)
			{
				MessageBox.Show(
					this,
					"Voc� deve escolher pelo menos um dia para tempo m�ximo.",
					"Lista de pessoas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				e.Cancel = true;
			}
			else if (valor <= 30)
			{
				e.Cancel = MessageBox.Show(
					this,
					"O tempo m�ximo est� muito curto. Voc� tem certeza de que deseja utiliz�-lo?",
					"Lista de pessoas",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.No;
			}
		}

		/// <summary>
		/// Ocorre ao terminar o assistente.
		/// </summary>
		private void assistente_Terminado(object sender, System.EventArgs e)
		{
			Setor [] setores;
            Configura��oUsu�rio<bool> registro;
            Configura��oUsu�rio<int> prazo;
            Configura��oUsu�rio<bool> bSetor;

            AguardeDB.Mostrar();

			setores = new Setor[chkSetores.CheckedItems.Count];
			chkSetores.CheckedItems.CopyTo(setores, 0);

			// Atualiza base inferior.
			baseInferior.Prazo   = int.Parse(txtDias.Text);
			baseInferior.Setores = setores;

			// Grava setores.
            for (int i = 0; i < this.setores.Length; i++)
            {
                bSetor = new Configura��oUsu�rio<bool>(chaveConfigura��o + ": setor " + this.setores[i].Nome, false);

                bSetor.Valor = chkSetores.GetItemChecked(i);
            }

			// Grava prazo.
            prazo = new Configura��oUsu�rio<int>(chaveConfigura��o + ": prazo", 90);
            prazo.Valor = txtDias.Int;

            registro = new Configura��oUsu�rio<bool>(chaveConfigura��o + ": configurado", false);
            registro.Valor = true;

            AguardeDB.Fechar();

            DialogResult = DialogResult.OK;
			this.Close();
		}


		/// <summary>
		/// Tempo m�ximo.
		/// </summary>
		public int Prazo
		{
			get
			{
				return int.Parse(txtDias.Text);
			}
			set
			{
				txtDias.Text = value.ToString();
			}
		}
	}
}

