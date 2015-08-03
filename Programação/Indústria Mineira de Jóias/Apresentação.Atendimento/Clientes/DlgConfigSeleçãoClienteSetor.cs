using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Entidades.Configuração;
using AMS;
using Apresentação.Formulários;
using System.Collections.Generic;

namespace Apresentação.Atendimento.Clientes
{
	/// <summary>
	/// Janela de configuração da base inferior BaseSeleçãoClienteSetor
	/// </summary>
	internal class DlgConfigSeleçãoClienteSetor : Apresentação.Formulários.JanelaExplicativa
	{
		/// <summary>
		/// Base inferior a ser configurada.
		/// </summary>
		private BaseSeleçãoClienteSetor baseInferior;

		/// <summary>
		/// Base inferior a ser configurada.
		/// </summary>
		private string chaveConfiguração;

		/// <summary>
		/// Possíveis setores.
		/// </summary>
		private Setor [] setores;

        private Setor setorNE = Setor.ObterSetor(Setor.SetorSistema.NãoEspecificado);

		// Controles
		private System.Windows.Forms.CheckedListBox chkSetores;
		private System.Windows.Forms.Label lblEscolha;
		private System.Windows.Forms.Label lblUsuário;
		private System.Windows.Forms.Label lblOlá;
		private System.Windows.Forms.Label lblExplicaçãoTempoMáximo;
		private System.Windows.Forms.Label lblTempoMáximo;
		private AMS.TextBox.NumericTextBox txtDias;
		//private System.Windows.Forms.TextBox txtDias;
		private System.Windows.Forms.Label lblDias;
		private Apresentação.Formulários.Assistente.AssistenteControle assistente;
		private Apresentação.Formulários.Assistente.PainelAssistente painelSetores;
		private Apresentação.Formulários.Assistente.PainelAssistente painelTempoMáximo;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Constrói a janela
		/// </summary>
		public DlgConfigSeleçãoClienteSetor(BaseSeleçãoClienteSetor baseInferior, string chaveConfiguração, Setor [] setores)
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
			this.chaveConfiguração = chaveConfiguração;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgConfigSeleçãoClienteSetor));
			this.assistente = new Apresentação.Formulários.Assistente.AssistenteControle();
			this.painelSetores = new Apresentação.Formulários.Assistente.PainelAssistente();
			this.chkSetores = new System.Windows.Forms.CheckedListBox();
			this.lblEscolha = new System.Windows.Forms.Label();
			this.lblUsuário = new System.Windows.Forms.Label();
			this.lblOlá = new System.Windows.Forms.Label();
			this.painelTempoMáximo = new Apresentação.Formulários.Assistente.PainelAssistente();
			this.lblDias = new System.Windows.Forms.Label();
			this.txtDias = new AMS.TextBox.NumericTextBox();
			this.lblTempoMáximo = new System.Windows.Forms.Label();
			this.lblExplicaçãoTempoMáximo = new System.Windows.Forms.Label();
			this.assistente.SuspendLayout();
			this.painelSetores.SuspendLayout();
			this.painelTempoMáximo.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTítulo
			// 
			this.lblTítulo.Name = "lblTítulo";
			this.lblTítulo.Size = new System.Drawing.Size(254, 22);
			this.lblTítulo.Text = "Configuração da lista de clientes";
			// 
			// lblDescrição
			// 
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(266, 48);
			this.lblDescrição.Text = "Este assistente lhe auxiliará a configurar a lista de cilentes que será exibida.";
			// 
			// picÍcone
			// 
			this.picÍcone.Image = ((System.Drawing.Image)(resources.GetObject("picÍcone.Image")));
			this.picÍcone.Name = "picÍcone";
			// 
			// assistente
			// 
			this.assistente.Controls.Add(this.painelSetores);
			this.assistente.Controls.Add(this.painelTempoMáximo);
			this.assistente.Itens = new Apresentação.Formulários.Assistente.PainelAssistente[] {
																								   this.painelSetores,
																								   this.painelTempoMáximo};
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
			this.painelSetores.Controls.Add(this.lblUsuário);
			this.painelSetores.Controls.Add(this.lblOlá);
			this.painelSetores.Location = new System.Drawing.Point(0, 0);
			this.painelSetores.Name = "painelSetores";
			this.painelSetores.Size = new System.Drawing.Size(336, 144);
			this.painelSetores.TabIndex = 1;
			this.painelSetores.ValidandoTransição += new System.ComponentModel.CancelEventHandler(this.painelSetores_ValidandoTransição);
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
			this.lblEscolha.Text = "Escolha com quais setores você deseja trabalhar.";
			// 
			// lblUsuário
			// 
			this.lblUsuário.AutoSize = true;
			this.lblUsuário.Location = new System.Drawing.Point(32, 8);
			this.lblUsuário.Name = "lblUsuário";
			this.lblUsuário.Size = new System.Drawing.Size(41, 16);
			this.lblUsuário.TabIndex = 1;
			this.lblUsuário.Text = "usuário";
			// 
			// lblOlá
			// 
			this.lblOlá.AutoSize = true;
			this.lblOlá.Location = new System.Drawing.Point(8, 8);
			this.lblOlá.Name = "lblOlá";
			this.lblOlá.Size = new System.Drawing.Size(25, 16);
			this.lblOlá.TabIndex = 0;
			this.lblOlá.Text = "Olá,";
			// 
			// painelTempoMáximo
			// 
			this.painelTempoMáximo.AutoScroll = true;
			this.painelTempoMáximo.Controls.Add(this.lblDias);
			this.painelTempoMáximo.Controls.Add(this.txtDias);
			this.painelTempoMáximo.Controls.Add(this.lblTempoMáximo);
			this.painelTempoMáximo.Controls.Add(this.lblExplicaçãoTempoMáximo);
			this.painelTempoMáximo.Location = new System.Drawing.Point(0, 0);
			this.painelTempoMáximo.Name = "painelTempoMáximo";
			this.painelTempoMáximo.Size = new System.Drawing.Size(336, 144);
			this.painelTempoMáximo.TabIndex = 2;
			this.painelTempoMáximo.ValidandoTransição += new System.ComponentModel.CancelEventHandler(this.painelTempoMáximo_ValidandoTransição);
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
			// lblTempoMáximo
			// 
			this.lblTempoMáximo.AutoSize = true;
			this.lblTempoMáximo.Location = new System.Drawing.Point(64, 80);
			this.lblTempoMáximo.Name = "lblTempoMáximo";
			this.lblTempoMáximo.Size = new System.Drawing.Size(85, 16);
			this.lblTempoMáximo.TabIndex = 1;
			this.lblTempoMáximo.Text = "Tempo máximo:";
			// 
			// lblExplicaçãoTempoMáximo
			// 
			this.lblExplicaçãoTempoMáximo.Location = new System.Drawing.Point(8, 8);
			this.lblExplicaçãoTempoMáximo.Name = "lblExplicaçãoTempoMáximo";
			this.lblExplicaçãoTempoMáximo.Size = new System.Drawing.Size(320, 40);
			this.lblExplicaçãoTempoMáximo.TabIndex = 0;
			this.lblExplicaçãoTempoMáximo.Text = "Para facilitar a visualização da lista de clientes, você pode especificar um temp" +
				"o máximo com que o cliente tenha visitado a firma para que ele apareça na lista." +
				"";
			// 
			// DlgConfigSeleçãoClienteSetor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 280);
			this.Controls.Add(this.assistente);
			this.Name = "DlgConfigSeleçãoClienteSetor";
			this.Text = "Lista de Clientes";
			this.Load += new System.EventHandler(this.DlgConfigSeleçãoClienteSetor_Load);
			this.Controls.SetChildIndex(this.assistente, 0);
			this.assistente.ResumeLayout(false);
			this.painelSetores.ResumeLayout(false);
			this.painelTempoMáximo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ocorre ao carregar a janela.
		/// </summary>
		private void DlgConfigSeleçãoClienteSetor_Load(object sender, System.EventArgs e)
		{
            ConfiguraçãoUsuário<int> prazo;
            ConfiguraçãoUsuário<bool> bSetor;

            AguardeDB.Mostrar();

            // Mostra nome do usuário.
			lblUsuário.Text = Acesso.Comum.Usuários.UsuárioAtual.Nome + "!";

			// Carrega setores.
			chkSetores.Items.AddRange(setores);

			for (int i = 0; i < setores.Length; i++)
			{
                bSetor = new ConfiguraçãoUsuário<bool>(chaveConfiguração + ": setor " + setores[i].Nome, false);

				chkSetores.SetItemChecked(
					i,
					bSetor.Valor);
			}

			// Carrega prazo.
            prazo = new ConfiguraçãoUsuário<int>(chaveConfiguração + ": prazo", 90);
			txtDias.Int = prazo.Valor;

            AguardeDB.Fechar();
		}

		/// <summary>
		/// Ocorre ao sair do painelSetores.
		/// </summary>
		private void painelSetores_ValidandoTransição(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (chkSetores.CheckedItems.Count == 0)
			{
				MessageBox.Show(
					this,
                    "Você deve escolher pelo menos um setor de atendimento.",
                    "Lista de pessoas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				e.Cancel = true;
			}
		}

		/// <summary>
		/// Ocorre ao sair do painelTempoMáximo
		/// </summary>
		private void painelTempoMáximo_ValidandoTransição(object sender, System.ComponentModel.CancelEventArgs e)
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
					"O valor definido para dias não é numérico.",
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
					"Você deve escolher pelo menos um dia para tempo máximo.",
					"Lista de pessoas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				e.Cancel = true;
			}
			else if (valor <= 30)
			{
				e.Cancel = MessageBox.Show(
					this,
					"O tempo máximo está muito curto. Você tem certeza de que deseja utilizá-lo?",
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
            ConfiguraçãoUsuário<bool> registro;
            ConfiguraçãoUsuário<int> prazo;
            ConfiguraçãoUsuário<bool> bSetor;

            AguardeDB.Mostrar();

			setores = new Setor[chkSetores.CheckedItems.Count];
			chkSetores.CheckedItems.CopyTo(setores, 0);

			// Atualiza base inferior.
			baseInferior.Prazo   = int.Parse(txtDias.Text);
			baseInferior.Setores = setores;

			// Grava setores.
            for (int i = 0; i < this.setores.Length; i++)
            {
                bSetor = new ConfiguraçãoUsuário<bool>(chaveConfiguração + ": setor " + this.setores[i].Nome, false);

                bSetor.Valor = chkSetores.GetItemChecked(i);
            }

			// Grava prazo.
            prazo = new ConfiguraçãoUsuário<int>(chaveConfiguração + ": prazo", 90);
            prazo.Valor = txtDias.Int;

            registro = new ConfiguraçãoUsuário<bool>(chaveConfiguração + ": configurado", false);
            registro.Valor = true;

            AguardeDB.Fechar();

            DialogResult = DialogResult.OK;
			this.Close();
		}


		/// <summary>
		/// Tempo máximo.
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

