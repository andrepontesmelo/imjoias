using Apresentação.Financeiro.Comissões;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Apresentação.Usuário.InterForm
{
    /// <summary>
    /// Base contendo ambiente do funcionário.
    /// </summary>
    public class BaseUsuário : Apresentação.Formulários.BaseInferior
	{
		/// <summary>
		/// Funcionário atual.
		/// </summary>
        //private Entidades.Pessoa.Funcionário funcionário;

		// Componentes
        private Apresentação.Formulários.TítuloBaseInferior título;
        protected Apresentação.Usuário.Agendamentos.ListaAgendamentosAtuais listaAgendamentos;
        protected Apresentação.Formulários.Quadro quadroPrivado;
        private Apresentação.Formulários.Opção opçãoAgendamentos;
        private Apresentação.Formulários.Opção opçãoRamal;
        private Apresentação.Formulários.Opção opçãoSenha;
        protected Apresentação.Formulários.Quadro quadroRamais;
        private Apresentação.Usuário.Funcionários.Ramais ramais;
        private Formulários.Opção opçãoNovidades;
        private Formulários.Opção opçãoComissão;
        private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Esta construtora permite que classes que herdem dessa
		/// possa ser trabalhada no Visual Studio.
		/// </summary>
		private BaseUsuário()
		{
			InitializeComponent();
		}

        protected new ControladorUsuário Controlador
        {
            get { return (ControladorUsuário)base.Controlador; }
        }

		/// <summary>
		/// Constrói a base para um funcionário específico.
		/// </summary>
		/// <param name="funcionário">Funcionário atual.</param>
		public BaseUsuário(Entidades.Pessoa.Funcionário funcionário)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            //this.funcionário = funcionário;
			título.Descrição = funcionário.Nome;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseUsuário));
            this.título = new Apresentação.Formulários.TítuloBaseInferior();
            this.listaAgendamentos = new Apresentação.Usuário.Agendamentos.ListaAgendamentosAtuais();
            this.quadroPrivado = new Apresentação.Formulários.Quadro();
            this.opçãoComissão = new Apresentação.Formulários.Opção();
            this.opçãoNovidades = new Apresentação.Formulários.Opção();
            this.opçãoAgendamentos = new Apresentação.Formulários.Opção();
            this.opçãoRamal = new Apresentação.Formulários.Opção();
            this.opçãoSenha = new Apresentação.Formulários.Opção();
            this.quadroRamais = new Apresentação.Formulários.Quadro();
            this.ramais = new Apresentação.Usuário.Funcionários.Ramais();
            this.esquerda.SuspendLayout();
            this.quadroPrivado.SuspendLayout();
            this.quadroRamais.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.quadroPrivado);
            this.esquerda.Size = new System.Drawing.Size(187, 392);
            this.esquerda.Controls.SetChildIndex(this.quadroPrivado, 0);
            // 
            // título
            // 
            this.título.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.título.BackColor = System.Drawing.Color.White;
            this.título.Descrição = "Fulano de tal";
            this.título.ÍconeArredondado = false;
            this.título.Imagem = ((System.Drawing.Image)(resources.GetObject("título.Imagem")));
            this.título.Location = new System.Drawing.Point(208, 16);
            this.título.Name = "título";
            this.título.Size = new System.Drawing.Size(568, 70);
            this.título.TabIndex = 6;
            this.título.Título = "Ambiente do funcionário";
            // 
            // listaAgendamentos
            // 
            this.listaAgendamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaAgendamentos.BackColor = System.Drawing.Color.White;
            this.listaAgendamentos.Location = new System.Drawing.Point(185, 92);
            this.listaAgendamentos.Name = "listaAgendamentos";
            this.listaAgendamentos.Size = new System.Drawing.Size(349, 276);
            this.listaAgendamentos.TabIndex = 7;
            // 
            // quadroPrivado
            // 
            this.quadroPrivado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroPrivado.bInfDirArredondada = true;
            this.quadroPrivado.bInfEsqArredondada = true;
            this.quadroPrivado.bSupDirArredondada = true;
            this.quadroPrivado.bSupEsqArredondada = true;
            this.quadroPrivado.Controls.Add(this.opçãoComissão);
            this.quadroPrivado.Controls.Add(this.opçãoNovidades);
            this.quadroPrivado.Controls.Add(this.opçãoAgendamentos);
            this.quadroPrivado.Controls.Add(this.opçãoRamal);
            this.quadroPrivado.Controls.Add(this.opçãoSenha);
            this.quadroPrivado.Cor = System.Drawing.Color.Black;
            this.quadroPrivado.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroPrivado.LetraTítulo = System.Drawing.Color.White;
            this.quadroPrivado.Location = new System.Drawing.Point(7, 13);
            this.quadroPrivado.MostrarBotãoMinMax = false;
            this.quadroPrivado.Name = "quadroPrivado";
            this.quadroPrivado.Size = new System.Drawing.Size(160, 131);
            this.quadroPrivado.TabIndex = 1;
            this.quadroPrivado.Tamanho = 30;
            this.quadroPrivado.Título = "Ações";
            // 
            // opçãoComissão
            // 
            this.opçãoComissão.BackColor = System.Drawing.Color.Transparent;
            this.opçãoComissão.Descrição = "Minha comissão";
            this.opçãoComissão.Imagem = global::Apresentação.Resource.comissao;
            this.opçãoComissão.Location = new System.Drawing.Point(7, 90);
            this.opçãoComissão.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoComissão.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoComissão.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoComissão.Name = "opçãoComissão";
            this.opçãoComissão.Size = new System.Drawing.Size(150, 16);
            this.opçãoComissão.TabIndex = 7;
            this.opçãoComissão.Click += new System.EventHandler(this.opçãoComissão_Click);
            // 
            // opçãoNovidades
            // 
            this.opçãoNovidades.BackColor = System.Drawing.Color.Transparent;
            this.opçãoNovidades.Descrição = "Ver novidades da versão";
            this.opçãoNovidades.Imagem = global::Apresentação.Resource.eventlogInfo3;
            this.opçãoNovidades.Location = new System.Drawing.Point(7, 110);
            this.opçãoNovidades.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoNovidades.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoNovidades.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoNovidades.Name = "opçãoNovidades";
            this.opçãoNovidades.Size = new System.Drawing.Size(150, 16);
            this.opçãoNovidades.TabIndex = 6;
            this.opçãoNovidades.Click += new System.EventHandler(this.opçãoNovidades_Click);
            // 
            // opçãoAgendamentos
            // 
            this.opçãoAgendamentos.BackColor = System.Drawing.Color.Transparent;
            this.opçãoAgendamentos.Descrição = "Editar agendamentos";
            this.opçãoAgendamentos.Imagem = global::Apresentação.Resource.DedoMenor;
            this.opçãoAgendamentos.Location = new System.Drawing.Point(7, 30);
            this.opçãoAgendamentos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoAgendamentos.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoAgendamentos.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoAgendamentos.Name = "opçãoAgendamentos";
            this.opçãoAgendamentos.Size = new System.Drawing.Size(150, 16);
            this.opçãoAgendamentos.TabIndex = 2;
            this.opçãoAgendamentos.Click += new System.EventHandler(this.opçãoAgendamentos_Click);
            // 
            // opçãoRamal
            // 
            this.opçãoRamal.BackColor = System.Drawing.Color.Transparent;
            this.opçãoRamal.Descrição = "Alterar ramal";
            this.opçãoRamal.Imagem = global::Apresentação.Resource.botão___telefone;
            this.opçãoRamal.Location = new System.Drawing.Point(7, 50);
            this.opçãoRamal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRamal.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRamal.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRamal.Name = "opçãoRamal";
            this.opçãoRamal.Size = new System.Drawing.Size(150, 16);
            this.opçãoRamal.TabIndex = 3;
            this.opçãoRamal.Click += new System.EventHandler(this.opçãoRamal_Click);
            // 
            // opçãoSenha
            // 
            this.opçãoSenha.BackColor = System.Drawing.Color.Transparent;
            this.opçãoSenha.Descrição = "Alterar senha";
            this.opçãoSenha.Imagem = global::Apresentação.Resource.keys;
            this.opçãoSenha.Location = new System.Drawing.Point(7, 70);
            this.opçãoSenha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoSenha.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoSenha.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoSenha.Name = "opçãoSenha";
            this.opçãoSenha.Size = new System.Drawing.Size(150, 16);
            this.opçãoSenha.TabIndex = 4;
            this.opçãoSenha.Click += new System.EventHandler(this.opçãoSenha_Click);
            // 
            // quadroRamais
            // 
            this.quadroRamais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroRamais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.quadroRamais.bInfDirArredondada = true;
            this.quadroRamais.bInfEsqArredondada = true;
            this.quadroRamais.bSupDirArredondada = true;
            this.quadroRamais.bSupEsqArredondada = true;
            this.quadroRamais.Controls.Add(this.ramais);
            this.quadroRamais.Cor = System.Drawing.Color.Black;
            this.quadroRamais.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroRamais.LetraTítulo = System.Drawing.Color.White;
            this.quadroRamais.Location = new System.Drawing.Point(540, 92);
            this.quadroRamais.MostrarBotãoMinMax = false;
            this.quadroRamais.Name = "quadroRamais";
            this.quadroRamais.Size = new System.Drawing.Size(244, 276);
            this.quadroRamais.TabIndex = 8;
            this.quadroRamais.Tamanho = 30;
            this.quadroRamais.Título = "Ramais Telefônicos";
            // 
            // ramais
            // 
            this.ramais.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ramais.Location = new System.Drawing.Point(5, 27);
            this.ramais.Margin = new System.Windows.Forms.Padding(5);
            this.ramais.Name = "ramais";
            this.ramais.Size = new System.Drawing.Size(234, 244);
            this.ramais.TabIndex = 2;
            this.ramais.AoDuploClique += new System.EventHandler(this.ramais_AoDuploClique);
            // 
            // BaseUsuário
            // 
            this.Controls.Add(this.título);
            this.Controls.Add(this.quadroRamais);
            this.Controls.Add(this.listaAgendamentos);
            this.Imagem = global::Apresentação.Resource.empregado;
            this.Name = "BaseUsuário";
            this.Size = new System.Drawing.Size(800, 392);
            this.Controls.SetChildIndex(this.listaAgendamentos, 0);
            this.Controls.SetChildIndex(this.quadroRamais, 0);
            this.Controls.SetChildIndex(this.título, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.quadroPrivado.ResumeLayout(false);
            this.quadroRamais.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Propriedades

		/// <summary>
		/// Título da base inferior.
		/// </summary>
		[DefaultValue("Ambiente do funcionário")]
		public string Título
		{
			get { return título.Título; }
			set { título.Título = value; }
		}

		#endregion

        private void opçãoAgendamentos_Click(object sender, EventArgs e)
        {
            Controlador.MostrarAgendamentos();
        }

        private void opçãoRamal_Click(object sender, EventArgs e)
        {
            using (Apresentação.Pessoa.Cadastro.EditarRamal dlg = new Apresentação.Pessoa.Cadastro.EditarRamal(Entidades.Pessoa.Funcionário.FuncionárioAtual))
            {
                dlg.ShowDialog(this.ParentForm);
            }

            ramais.Atualizar();
        }

        private void opçãoSenha_Click(object sender, EventArgs e)
        {
            using (Apresentação.Usuário.Funcionários.AlterarSenha dlg = new Apresentação.Usuário.Funcionários.AlterarSenha())
            {
                dlg.ShowDialog(this.ParentForm);
            }
        }

        private void ramais_AoDuploClique(object sender, EventArgs e)
        {
            SubstituirBase(new Apresentação.Atendimento.BaseAtendimento(ramais.Seleção));
        }

        private void opçãoNovidades_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/andrepontesmelo/imjoias/commits/" + Versão.VersãoNumérica);
        }

        private void opçãoComissão_Click(object sender, EventArgs e)
        {
            SubstituirBase(new BaseComissão());
        }
    }
}