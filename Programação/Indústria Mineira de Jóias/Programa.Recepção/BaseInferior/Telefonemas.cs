using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Apresentação.Pessoa.Consultas;
using Entidades.Pessoa;
using Apresentação.Pessoa;

namespace Programa.Recepção.BaseInferior
{
	sealed class Telefonemas : Apresentação.Formulários.BaseInferior
	{
		private Controles.CadastrarTelefonema cadastrarTelefonema;
		private Apresentação.Formulários.Quadro quadroInf;
		private System.Windows.Forms.Label lblInf;
		private Apresentação.Formulários.TítuloBaseInferior títuloBaseInferior;
		private System.ComponentModel.IContainer components = null;

		public Telefonemas()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Telefonemas));
            this.cadastrarTelefonema = new Programa.Recepção.BaseInferior.Controles.CadastrarTelefonema();
            this.quadroInf = new Apresentação.Formulários.Quadro();
            this.lblInf = new System.Windows.Forms.Label();
            this.títuloBaseInferior = new Apresentação.Formulários.TítuloBaseInferior();
            this.esquerda.SuspendLayout();
            this.quadroInf.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroInf);
            this.esquerda.Size = new System.Drawing.Size(187, 440);
            this.esquerda.Controls.SetChildIndex(this.quadroInf, 0);
            // 
            // cadastrarTelefonema
            // 
            this.cadastrarTelefonema.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cadastrarTelefonema.BackColor = System.Drawing.Color.White;
            this.cadastrarTelefonema.Location = new System.Drawing.Point(216, 72);
            this.cadastrarTelefonema.Name = "cadastrarTelefonema";
            this.cadastrarTelefonema.Size = new System.Drawing.Size(360, 368);
            this.cadastrarTelefonema.TabIndex = 5;
            this.cadastrarTelefonema.Cancelar += new Programa.Recepção.BaseInferior.Controles.CadastrarTelefonema.Comando(this.cadastrarTelefonema_Cancelar);
            this.cadastrarTelefonema.OK += new Programa.Recepção.BaseInferior.Controles.CadastrarTelefonema.Comando(this.cadastrarTelefonema_OK);
            // 
            // quadroInf
            // 
            this.quadroInf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroInf.bInfDirArredondada = true;
            this.quadroInf.bInfEsqArredondada = true;
            this.quadroInf.bSupDirArredondada = true;
            this.quadroInf.bSupEsqArredondada = true;
            this.quadroInf.Controls.Add(this.lblInf);
            this.quadroInf.Cor = System.Drawing.Color.Black;
            this.quadroInf.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroInf.LetraTítulo = System.Drawing.Color.White;
            this.quadroInf.Location = new System.Drawing.Point(7, 14);
            this.quadroInf.MostrarBotãoMinMax = false;
            this.quadroInf.Name = "quadroInf";
            this.quadroInf.Size = new System.Drawing.Size(160, 112);
            this.quadroInf.TabIndex = 0;
            this.quadroInf.Tamanho = 30;
            this.quadroInf.Título = "Registro de Telefonemas";
            // 
            // lblInf
            // 
            this.lblInf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInf.BackColor = System.Drawing.Color.Transparent;
            this.lblInf.Location = new System.Drawing.Point(8, 32);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(144, 80);
            this.lblInf.TabIndex = 1;
            this.lblInf.Text = "Em caso de registro de telefonema de funcionário, ao pressionar OK surgirá uma ja" +
    "nela para confirmação dos dados do funcionário.";
            // 
            // títuloBaseInferior
            // 
            this.títuloBaseInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.títuloBaseInferior.BackColor = System.Drawing.Color.White;
            this.títuloBaseInferior.Descrição = "Preencha os dados a serem cadastrados relativos ao telefonema sendo realizado.";
            this.títuloBaseInferior.ÍconeArredondado = false;
            this.títuloBaseInferior.Imagem = ((System.Drawing.Image)(resources.GetObject("títuloBaseInferior.Imagem")));
            this.títuloBaseInferior.Location = new System.Drawing.Point(200, 8);
            this.títuloBaseInferior.Name = "títuloBaseInferior";
            this.títuloBaseInferior.Size = new System.Drawing.Size(376, 70);
            this.títuloBaseInferior.TabIndex = 6;
            this.títuloBaseInferior.Título = "Registro de telefonema";
            // 
            // Telefonemas
            // 
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(592, 440);
            this.Controls.Add(this.títuloBaseInferior);
            this.Controls.Add(this.cadastrarTelefonema);
            this.Name = "Telefonemas";
            this.Size = new System.Drawing.Size(592, 440);
            this.Controls.SetChildIndex(this.cadastrarTelefonema, 0);
            this.Controls.SetChildIndex(this.títuloBaseInferior, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroInf.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void cadastrarTelefonema_Cancelar()
		{
			cadastrarTelefonema.Preparar();
		}

		private void cadastrarTelefonema_OK()
		{
			// Verificar se origem é funcionário
			if (cadastrarTelefonema.TipoOrigem == Telefonema.TipoOrigem.Funcionário)
			{
				Funcionário funcionário;

                funcionário = Funcionário.ObterPessoa(cadastrarTelefonema.Origem);

				if (funcionário == null)
				{
					EscolherFuncionário dlg;
				
					dlg = new EscolherFuncionário(
						"Confirme o funcionário que originou este telefonema",
						cadastrarTelefonema.Origem);

					if (dlg.ShowDialog(this) == DialogResult.OK)
					{
						Telefonema telefonema;
			
						telefonema = new Telefonema(
							cadastrarTelefonema.Quando,
							cadastrarTelefonema.Telefone,
							cadastrarTelefonema.Destino,
							dlg.Funcionário.Código,
							dlg.Funcionário.Nome,
							cadastrarTelefonema.Cidade,
							cadastrarTelefonema.TipoOrigem,
							cadastrarTelefonema.TipoDestino);
				
						telefonema.Cadastrar();
					}
					else
					{
						dlg.Dispose();
						return;
					}
				
					dlg.Dispose();
				}
				else
				{
					Telefonema telefonema;
			
					telefonema = new Telefonema(
						cadastrarTelefonema.Quando,
						cadastrarTelefonema.Telefone,
						cadastrarTelefonema.Destino,
						funcionário.Código,
						funcionário.Nome,
						cadastrarTelefonema.Cidade,
						cadastrarTelefonema.TipoOrigem,
						cadastrarTelefonema.TipoDestino);
				
					telefonema.Cadastrar();
				}
			}
				// Verificar se destino é funcionário
			else if (cadastrarTelefonema.TipoDestino == Telefonema.TipoDestino.Funcionário)
			{
				EscolherFuncionário dlg;
				
				dlg = new EscolherFuncionário(
					"Confirme o funcionário a quem foi destinado este telefonema",
					cadastrarTelefonema.Destino);

				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					Telefonema telefonema;
			
					telefonema = new Telefonema(
						cadastrarTelefonema.Quando,
						cadastrarTelefonema.Telefone,
						cadastrarTelefonema.Origem,
						dlg.Funcionário.Código,
						dlg.Funcionário.Nome,
						cadastrarTelefonema.Cidade,
						cadastrarTelefonema.TipoOrigem,
						cadastrarTelefonema.TipoDestino);
				
					telefonema.Cadastrar();
				}
				else
				{
					dlg.Dispose();
					return;
				}
				
				dlg.Dispose();
			}
			else
			{
				TelefonemaNomeNome telefonema;
			
				telefonema = new TelefonemaNomeNome(
					cadastrarTelefonema.Quando,
					cadastrarTelefonema.Telefone,
					cadastrarTelefonema.Origem,
					cadastrarTelefonema.Destino,
					cadastrarTelefonema.Cidade,
					(TelefonemaNomeNome.TipoOrigem) cadastrarTelefonema.TipoOrigem,
					(TelefonemaNomeNome.TipoDestino) cadastrarTelefonema.TipoDestino);

				telefonema.Cadastrar();
			}

			MessageBox.Show(this, "Telefonema registrado com sucesso!", "Indústria Mineira de Jóias", MessageBoxButtons.OK, MessageBoxIcon.Information);

			cadastrarTelefonema.Preparar();
		}
	}
}