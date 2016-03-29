using Apresentação.Formulários;
using Apresentação.Pessoa;
using Entidades;
using Entidades.Configuração;
using Entidades.Pessoa;
using Negócio;
using Programa.Recepção.Formulários.EntradaSaída;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Programa.Recepção.BaseInferior
{
	sealed class EntradaSaída : Apresentação.Formulários.BaseInferior
	{
		// Atributos
		private Control							opçõesAtuais = null;

		// Bases pré-carregadas
		private RegistrarVisitante	biRegistrarVisitante = new RegistrarVisitante();

		// Designer
		private Controles.ListaVisitantes		 listaVisitantes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Apresentação.Formulários.Quadro opçõesVisitante;
		private System.Windows.Forms.Panel opçõesGenéricas;
		private Apresentação.Formulários.Quadro quadroVisitantes;
		private Apresentação.Formulários.Quadro quadroInformação;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel opçõesVendedor;
		private Apresentação.Formulários.Quadro quadroVendedor;
		private System.Windows.Forms.Label label4;
        private Apresentação.Formulários.Quadro quadro1;
		private Apresentação.Formulários.Opção opçãoVisitanteAtribuirVendedor;
		private Apresentação.Formulários.Opção opçãoVisitanteRegistrarSaída;
		private Apresentação.Formulários.Opção opçãoVisitanteRegistrarNovoVisitante;
		private Apresentação.Formulários.Opção opçãoVendedorAlterarEstado;
		private Apresentação.Formulários.Opção opçãoVendedorRodízio;
		private Apresentação.Formulários.Opção opçãoGenéricaRegistrarEntrada;
		private Apresentação.Formulários.Opção opçãoVendedorRegistrarEntrada;
        private Opção opçãoVisualizar;
        private Opção opçãoVisitaVisualizar;
        private Opção opçãoVendedorVisualizarVisitantes;
        private Opção opçãoRenomear;
		private System.ComponentModel.IContainer components = null;

		public EntradaSaída()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Mostrar listas
			if (this.DesignMode)
				return;

			// Configurar barra de opções
			opçõesAtuais = opçõesGenéricas;
			opçõesVendedor.Top = opçõesVisitante.Top = opçõesAtuais.Top;

            biRegistrarVisitante.AoCadastrar += new RegistrarVisitante.AoCadastrarCallback(biRegistrarVisitante_AoCadastrar);
		}

        /// <summary>
        /// Ocorre ao definir o controlador da base inferior.
        /// </summary>
        protected override void AoDefinirControlador(Apresentação.Formulários.ControladorBaseInferior controlador)
        {
            base.AoDefinirControlador(controlador);

            controlador.InserirBaseInferior(biRegistrarVisitante);
        }

        public override void AoCarregarCompletamente(Apresentação.Formulários.Splash splash)
        {
            Rodízio.AtendimentoCallback iniciarAtendimento;
            
            base.AoCarregarCompletamente(splash);

            iniciarAtendimento = new Rodízio.AtendimentoCallback(ConfirmandoAtendimento);

            foreach (Setor setor in Setor.ObterSetoresAtendimento())
                Rodízio.ObterRodízio(setor).ConfirmandoAtendimento += iniciarAtendimento;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
					components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradaSaída));
            this.opçõesVisitante = new Apresentação.Formulários.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.opçãoVisitanteRegistrarSaída = new Apresentação.Formulários.Opção();
            this.opçãoRenomear = new Apresentação.Formulários.Opção();
            this.opçãoVisitaVisualizar = new Apresentação.Formulários.Opção();
            this.opçãoVisitanteAtribuirVendedor = new Apresentação.Formulários.Opção();
            this.opçãoVisitanteRegistrarNovoVisitante = new Apresentação.Formulários.Opção();
            this.label2 = new System.Windows.Forms.Label();
            this.opçõesGenéricas = new System.Windows.Forms.Panel();
            this.quadroVisitantes = new Apresentação.Formulários.Quadro();
            this.opçãoGenéricaRegistrarEntrada = new Apresentação.Formulários.Opção();
            this.opçãoVisualizar = new Apresentação.Formulários.Opção();
            this.quadroInformação = new Apresentação.Formulários.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.opçõesVendedor = new System.Windows.Forms.Panel();
            this.quadroVendedor = new Apresentação.Formulários.Quadro();
            this.opçãoVendedorAlterarEstado = new Apresentação.Formulários.Opção();
            this.label4 = new System.Windows.Forms.Label();
            this.opçãoVendedorRodízio = new Apresentação.Formulários.Opção();
            this.quadro1 = new Apresentação.Formulários.Quadro();
            this.opçãoVendedorVisualizarVisitantes = new Apresentação.Formulários.Opção();
            this.opçãoVendedorRegistrarEntrada = new Apresentação.Formulários.Opção();
            this.listaVisitantes = new Programa.Recepção.BaseInferior.Controles.ListaVisitantes();
            this.esquerda.SuspendLayout();
            this.opçõesVisitante.SuspendLayout();
            this.opçõesGenéricas.SuspendLayout();
            this.quadroVisitantes.SuspendLayout();
            this.quadroInformação.SuspendLayout();
            this.opçõesVendedor.SuspendLayout();
            this.quadroVendedor.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.opçõesVendedor);
            this.esquerda.Controls.Add(this.quadroInformação);
            this.esquerda.Controls.Add(this.opçõesGenéricas);
            this.esquerda.Controls.Add(this.opçõesVisitante);
            this.esquerda.Size = new System.Drawing.Size(187, 756);
            this.esquerda.Controls.SetChildIndex(this.opçõesVisitante, 0);
            this.esquerda.Controls.SetChildIndex(this.opçõesGenéricas, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroInformação, 0);
            this.esquerda.Controls.SetChildIndex(this.opçõesVendedor, 0);
            // 
            // opçõesVisitante
            // 
            this.opçõesVisitante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.opçõesVisitante.bInfDirArredondada = true;
            this.opçõesVisitante.bInfEsqArredondada = true;
            this.opçõesVisitante.bSupDirArredondada = true;
            this.opçõesVisitante.bSupEsqArredondada = true;
            this.opçõesVisitante.Controls.Add(this.label3);
            this.opçõesVisitante.Controls.Add(this.opçãoVisitanteRegistrarSaída);
            this.opçõesVisitante.Controls.Add(this.opçãoRenomear);
            this.opçõesVisitante.Controls.Add(this.opçãoVisitaVisualizar);
            this.opçõesVisitante.Controls.Add(this.opçãoVisitanteAtribuirVendedor);
            this.opçõesVisitante.Controls.Add(this.opçãoVisitanteRegistrarNovoVisitante);
            this.opçõesVisitante.Controls.Add(this.label2);
            this.opçõesVisitante.Cor = System.Drawing.Color.Black;
            this.opçõesVisitante.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.opçõesVisitante.LetraTítulo = System.Drawing.Color.White;
            this.opçõesVisitante.Location = new System.Drawing.Point(7, 115);
            this.opçõesVisitante.MostrarBotãoMinMax = false;
            this.opçõesVisitante.Name = "opçõesVisitante";
            this.opçõesVisitante.Size = new System.Drawing.Size(160, 260);
            this.opçõesVisitante.TabIndex = 8;
            this.opçõesVisitante.Tamanho = 30;
            this.opçõesVisitante.Título = "Visitantes";
            this.opçõesVisitante.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sobre o visitante escolhido, o que você deseja?";
            // 
            // opçãoVisitanteRegistrarSaída
            // 
            this.opçãoVisitanteRegistrarSaída.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVisitanteRegistrarSaída.Descrição = "Registrar saída";
            this.opçãoVisitanteRegistrarSaída.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVisitanteRegistrarSaída.Imagem")));
            this.opçãoVisitanteRegistrarSaída.Location = new System.Drawing.Point(5, 105);
            this.opçãoVisitanteRegistrarSaída.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVisitanteRegistrarSaída.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVisitanteRegistrarSaída.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVisitanteRegistrarSaída.Name = "opçãoVisitanteRegistrarSaída";
            this.opçãoVisitanteRegistrarSaída.Size = new System.Drawing.Size(150, 24);
            this.opçãoVisitanteRegistrarSaída.TabIndex = 2;
            this.opçãoVisitanteRegistrarSaída.Click += new System.EventHandler(this.opçãoVisitanteRegistrarSaída_Click);
            // 
            // opçãoRenomear
            // 
            this.opçãoRenomear.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoRenomear.Descrição = "Corrigir nome";
            this.opçãoRenomear.Imagem = global::Programa.Recepção.Properties.Resources.RenameFolderHS;
            this.opçãoRenomear.Location = new System.Drawing.Point(5, 129);
            this.opçãoRenomear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoRenomear.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoRenomear.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoRenomear.Name = "opçãoRenomear";
            this.opçãoRenomear.Size = new System.Drawing.Size(150, 24);
            this.opçãoRenomear.TabIndex = 3;
            this.opçãoRenomear.Click += new System.EventHandler(this.opçãoRenomear_Click);
            // 
            // opçãoVisitaVisualizar
            // 
            this.opçãoVisitaVisualizar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVisitaVisualizar.Descrição = "Visualizar visitas";
            this.opçãoVisitaVisualizar.Imagem = global::Programa.Recepção.Properties.Resources.relatório;
            this.opçãoVisitaVisualizar.Location = new System.Drawing.Point(5, 232);
            this.opçãoVisitaVisualizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVisitaVisualizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVisitaVisualizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVisitaVisualizar.Name = "opçãoVisitaVisualizar";
            this.opçãoVisitaVisualizar.Size = new System.Drawing.Size(150, 30);
            this.opçãoVisitaVisualizar.TabIndex = 6;
            this.opçãoVisitaVisualizar.Click += new System.EventHandler(this.opçãoVisualizar_Click);
            // 
            // opçãoVisitanteAtribuirVendedor
            // 
            this.opçãoVisitanteAtribuirVendedor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVisitanteAtribuirVendedor.Descrição = "Atribuir vendedor";
            this.opçãoVisitanteAtribuirVendedor.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVisitanteAtribuirVendedor.Imagem")));
            this.opçãoVisitanteAtribuirVendedor.Location = new System.Drawing.Point(5, 81);
            this.opçãoVisitanteAtribuirVendedor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVisitanteAtribuirVendedor.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVisitanteAtribuirVendedor.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVisitanteAtribuirVendedor.Name = "opçãoVisitanteAtribuirVendedor";
            this.opçãoVisitanteAtribuirVendedor.Size = new System.Drawing.Size(150, 24);
            this.opçãoVisitanteAtribuirVendedor.TabIndex = 1;
            this.opçãoVisitanteAtribuirVendedor.Click += new System.EventHandler(this.opçãoVisitanteAtribuirVendedor_Click);
            // 
            // opçãoVisitanteRegistrarNovoVisitante
            // 
            this.opçãoVisitanteRegistrarNovoVisitante.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVisitanteRegistrarNovoVisitante.Descrição = "Registrar entrada de novo visitante";
            this.opçãoVisitanteRegistrarNovoVisitante.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVisitanteRegistrarNovoVisitante.Imagem")));
            this.opçãoVisitanteRegistrarNovoVisitante.Location = new System.Drawing.Point(5, 200);
            this.opçãoVisitanteRegistrarNovoVisitante.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVisitanteRegistrarNovoVisitante.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVisitanteRegistrarNovoVisitante.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVisitanteRegistrarNovoVisitante.Name = "opçãoVisitanteRegistrarNovoVisitante";
            this.opçãoVisitanteRegistrarNovoVisitante.Size = new System.Drawing.Size(150, 38);
            this.opçãoVisitanteRegistrarNovoVisitante.TabIndex = 5;
            this.opçãoVisitanteRegistrarNovoVisitante.Click += new System.EventHandler(this.opçãoGenéricaRegistrarEntrada_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ou então, o que você deseja?";
            // 
            // opçõesGenéricas
            // 
            this.opçõesGenéricas.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçõesGenéricas.Controls.Add(this.quadroVisitantes);
            this.opçõesGenéricas.Location = new System.Drawing.Point(7, 16);
            this.opçõesGenéricas.Name = "opçõesGenéricas";
            this.opçõesGenéricas.Size = new System.Drawing.Size(160, 200);
            this.opçõesGenéricas.TabIndex = 9;
            // 
            // quadroVisitantes
            // 
            this.quadroVisitantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVisitantes.bInfDirArredondada = true;
            this.quadroVisitantes.bInfEsqArredondada = true;
            this.quadroVisitantes.bSupDirArredondada = true;
            this.quadroVisitantes.bSupEsqArredondada = true;
            this.quadroVisitantes.Controls.Add(this.opçãoGenéricaRegistrarEntrada);
            this.quadroVisitantes.Controls.Add(this.opçãoVisualizar);
            this.quadroVisitantes.Cor = System.Drawing.Color.Black;
            this.quadroVisitantes.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVisitantes.LetraTítulo = System.Drawing.Color.White;
            this.quadroVisitantes.Location = new System.Drawing.Point(0, 110);
            this.quadroVisitantes.MostrarBotãoMinMax = false;
            this.quadroVisitantes.Name = "quadroVisitantes";
            this.quadroVisitantes.Size = new System.Drawing.Size(160, 77);
            this.quadroVisitantes.TabIndex = 8;
            this.quadroVisitantes.Tamanho = 30;
            this.quadroVisitantes.Título = "Visitantes";
            // 
            // opçãoGenéricaRegistrarEntrada
            // 
            this.opçãoGenéricaRegistrarEntrada.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoGenéricaRegistrarEntrada.Descrição = "Registrar entrada";
            this.opçãoGenéricaRegistrarEntrada.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoGenéricaRegistrarEntrada.Imagem")));
            this.opçãoGenéricaRegistrarEntrada.Location = new System.Drawing.Point(8, 32);
            this.opçãoGenéricaRegistrarEntrada.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoGenéricaRegistrarEntrada.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoGenéricaRegistrarEntrada.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoGenéricaRegistrarEntrada.Name = "opçãoGenéricaRegistrarEntrada";
            this.opçãoGenéricaRegistrarEntrada.Size = new System.Drawing.Size(150, 24);
            this.opçãoGenéricaRegistrarEntrada.TabIndex = 2;
            this.opçãoGenéricaRegistrarEntrada.Click += new System.EventHandler(this.opçãoGenéricaRegistrarEntrada_Click);
            // 
            // opçãoVisualizar
            // 
            this.opçãoVisualizar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVisualizar.Descrição = "Visualizar visitas";
            this.opçãoVisualizar.Imagem = global::Programa.Recepção.Properties.Resources.relatório;
            this.opçãoVisualizar.Location = new System.Drawing.Point(8, 56);
            this.opçãoVisualizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVisualizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVisualizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVisualizar.Name = "opçãoVisualizar";
            this.opçãoVisualizar.Size = new System.Drawing.Size(150, 24);
            this.opçãoVisualizar.TabIndex = 3;
            this.opçãoVisualizar.Click += new System.EventHandler(this.opçãoVisualizar_Click);
            // 
            // quadroInformação
            // 
            this.quadroInformação.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroInformação.bInfDirArredondada = true;
            this.quadroInformação.bInfEsqArredondada = true;
            this.quadroInformação.bSupDirArredondada = true;
            this.quadroInformação.bSupEsqArredondada = true;
            this.quadroInformação.Controls.Add(this.label1);
            this.quadroInformação.Cor = System.Drawing.Color.Black;
            this.quadroInformação.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroInformação.LetraTítulo = System.Drawing.Color.White;
            this.quadroInformação.Location = new System.Drawing.Point(7, 13);
            this.quadroInformação.MostrarBotãoMinMax = false;
            this.quadroInformação.Name = "quadroInformação";
            this.quadroInformação.Size = new System.Drawing.Size(160, 104);
            this.quadroInformação.TabIndex = 9;
            this.quadroInformação.Tamanho = 30;
            this.quadroInformação.Título = "Dica";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecionando um vendedor ou um visitante nos quadros ao lado direito, surgem aqui" +
    " opções para estas pessoas.";
            // 
            // opçõesVendedor
            // 
            this.opçõesVendedor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçõesVendedor.Controls.Add(this.quadroVendedor);
            this.opçõesVendedor.Controls.Add(this.quadro1);
            this.opçõesVendedor.Location = new System.Drawing.Point(7, 381);
            this.opçõesVendedor.Name = "opçõesVendedor";
            this.opçõesVendedor.Size = new System.Drawing.Size(160, 273);
            this.opçõesVendedor.TabIndex = 10;
            this.opçõesVendedor.Visible = false;
            // 
            // quadroVendedor
            // 
            this.quadroVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVendedor.bInfDirArredondada = true;
            this.quadroVendedor.bInfEsqArredondada = true;
            this.quadroVendedor.bSupDirArredondada = true;
            this.quadroVendedor.bSupEsqArredondada = true;
            this.quadroVendedor.Controls.Add(this.opçãoVendedorAlterarEstado);
            this.quadroVendedor.Controls.Add(this.label4);
            this.quadroVendedor.Controls.Add(this.opçãoVendedorRodízio);
            this.quadroVendedor.Cor = System.Drawing.Color.Black;
            this.quadroVendedor.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendedor.LetraTítulo = System.Drawing.Color.White;
            this.quadroVendedor.Location = new System.Drawing.Point(0, 0);
            this.quadroVendedor.MostrarBotãoMinMax = false;
            this.quadroVendedor.Name = "quadroVendedor";
            this.quadroVendedor.Size = new System.Drawing.Size(160, 136);
            this.quadroVendedor.TabIndex = 7;
            this.quadroVendedor.Tamanho = 30;
            this.quadroVendedor.Título = "Vendedor";
            // 
            // opçãoVendedorAlterarEstado
            // 
            this.opçãoVendedorAlterarEstado.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVendedorAlterarEstado.Descrição = "Alterar estado";
            this.opçãoVendedorAlterarEstado.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVendedorAlterarEstado.Imagem")));
            this.opçãoVendedorAlterarEstado.Location = new System.Drawing.Point(8, 80);
            this.opçãoVendedorAlterarEstado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVendedorAlterarEstado.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVendedorAlterarEstado.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVendedorAlterarEstado.Name = "opçãoVendedorAlterarEstado";
            this.opçãoVendedorAlterarEstado.Size = new System.Drawing.Size(150, 24);
            this.opçãoVendedorAlterarEstado.TabIndex = 7;
            this.opçãoVendedorAlterarEstado.Click += new System.EventHandler(this.opçãoVendedorAlterarEstado_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sobre o vendedor escolhido, o que você deseja?";
            // 
            // opçãoVendedorRodízio
            // 
            this.opçãoVendedorRodízio.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVendedorRodízio.Descrição = "Modificar opções de rodízio";
            this.opçãoVendedorRodízio.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVendedorRodízio.Imagem")));
            this.opçãoVendedorRodízio.Location = new System.Drawing.Point(8, 104);
            this.opçãoVendedorRodízio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVendedorRodízio.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVendedorRodízio.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVendedorRodízio.Name = "opçãoVendedorRodízio";
            this.opçãoVendedorRodízio.Size = new System.Drawing.Size(150, 32);
            this.opçãoVendedorRodízio.TabIndex = 8;
            this.opçãoVendedorRodízio.Click += new System.EventHandler(this.opçãoVendedorRodízio_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.opçãoVendedorVisualizarVisitantes);
            this.quadro1.Controls.Add(this.opçãoVendedorRegistrarEntrada);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraTítulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(0, 142);
            this.quadro1.MostrarBotãoMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 78);
            this.quadro1.TabIndex = 8;
            this.quadro1.Tamanho = 30;
            this.quadro1.Título = "Visitantes";
            // 
            // opçãoVendedorVisualizarVisitantes
            // 
            this.opçãoVendedorVisualizarVisitantes.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVendedorVisualizarVisitantes.Descrição = "Visualizar visitas";
            this.opçãoVendedorVisualizarVisitantes.Imagem = global::Programa.Recepção.Properties.Resources.relatório;
            this.opçãoVendedorVisualizarVisitantes.Location = new System.Drawing.Point(5, 56);
            this.opçãoVendedorVisualizarVisitantes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVendedorVisualizarVisitantes.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVendedorVisualizarVisitantes.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVendedorVisualizarVisitantes.Name = "opçãoVendedorVisualizarVisitantes";
            this.opçãoVendedorVisualizarVisitantes.Size = new System.Drawing.Size(150, 24);
            this.opçãoVendedorVisualizarVisitantes.TabIndex = 4;
            this.opçãoVendedorVisualizarVisitantes.Click += new System.EventHandler(this.opçãoVisualizar_Click);
            // 
            // opçãoVendedorRegistrarEntrada
            // 
            this.opçãoVendedorRegistrarEntrada.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.opçãoVendedorRegistrarEntrada.Descrição = "Registrar entrada";
            this.opçãoVendedorRegistrarEntrada.Imagem = ((System.Drawing.Image)(resources.GetObject("opçãoVendedorRegistrarEntrada.Imagem")));
            this.opçãoVendedorRegistrarEntrada.Location = new System.Drawing.Point(5, 32);
            this.opçãoVendedorRegistrarEntrada.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.opçãoVendedorRegistrarEntrada.MaximumSize = new System.Drawing.Size(150, 100);
            this.opçãoVendedorRegistrarEntrada.MinimumSize = new System.Drawing.Size(150, 16);
            this.opçãoVendedorRegistrarEntrada.Name = "opçãoVendedorRegistrarEntrada";
            this.opçãoVendedorRegistrarEntrada.Size = new System.Drawing.Size(150, 24);
            this.opçãoVendedorRegistrarEntrada.TabIndex = 3;
            this.opçãoVendedorRegistrarEntrada.Click += new System.EventHandler(this.opçãoGenéricaRegistrarEntrada_Click);
            // 
            // listaVisitantes
            // 
            this.listaVisitantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaVisitantes.BackColor = System.Drawing.Color.White;
            this.listaVisitantes.Location = new System.Drawing.Point(184, 0);
            this.listaVisitantes.Name = "listaVisitantes";
            this.listaVisitantes.Size = new System.Drawing.Size(600, 756);
            this.listaVisitantes.TabIndex = 5;
            this.listaVisitantes.AoSelecionarFuncionário += new System.EventHandler(this.listaVisitantes_AoSelecionarFuncionário);
            this.listaVisitantes.AoSelecionarVisitante += new System.EventHandler(this.listaVisitantes_AoSelecionarVisitante);
            this.listaVisitantes.DuploCliqueVendedores += new System.EventHandler(this.listaVisitantes_DuploCliqueVendedores);
            // 
            // EntradaSaída
            // 
            this.Controls.Add(this.listaVisitantes);
            this.Name = "EntradaSaída";
            this.Size = new System.Drawing.Size(784, 756);
            this.Controls.SetChildIndex(this.listaVisitantes, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.opçõesVisitante.ResumeLayout(false);
            this.opçõesGenéricas.ResumeLayout(false);
            this.quadroVisitantes.ResumeLayout(false);
            this.quadroInformação.ResumeLayout(false);
            this.opçõesVendedor.ResumeLayout(false);
            this.quadroVendedor.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Processamento da interface de usuário (Eventos, etc)

		private void Mostrar(Control controle)
		{
			// Verificar se controle já está sendo exibido
			if (opçõesAtuais != controle)
			{
                //this.SuspendLayout();
                //esquerda.SuspendLayout();

				if (controle != null)
				{
                    //controle.SuspendLayout();

					//controle.Top = 0;
					controle.Visible = true;
				}

				if (opçõesAtuais != null)
					opçõesAtuais.Visible = false;

                //if (controle != null)
                //    controle.ResumeLayout();

                //esquerda.ResumeLayout();
                //this.ResumeLayout();

				opçõesAtuais = controle;
			}
		}

		private void listaVisitantes_DuploCliqueVendedores(object sender, System.EventArgs e)
		{
			opçãoVendedorAlterarEstado_Click(sender, e);
		}

		#endregion

		#region Visitantes

		private void opçãoVisitanteAtribuirVendedor_Click(object sender, System.EventArgs e)
		{
            List<Funcionário> funcionários = Funcionário.ObterFuncionários(true, false);
            Visita visita;

            visita = listaVisitantes.VisitaSelecionada;

            using (AtribuirAtendimento dlg = new AtribuirAtendimento(visita.ExtrairNomes(), funcionários))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Funcionário funcionário = dlg.Funcionário;

                    // Verificar estado do funcionário
                    if (funcionário.Situação == EstadoFuncionário.Atendendo)
                        if (MessageBox.Show(this, "O funcionário \""
                            + funcionário.Nome
                            + "\" encontra-se atendendo o(s) cliente(s) \""
                            + Visita.ExtrairNomes(Visita.ObterAtendimentos(funcionário))
                            + "\". Deseja mesmo interromper este atendimento para que este funcionário atenda \""
                            + visita.ExtrairNomes() + "\"?",
                            "Encaminhar atendimento",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        {
                            dlg.Dispose();

                            return;
                        }

                    Funcionário funcionárioAtendendoAntes = visita.Atendente;

                    Rodízio.RegistrarAtendimento(visita, funcionário);
                    listaVisitantes.AtualizarVisita(visita);

                    visita.AtendimentoForaDoRodízio = 
                        !Rodízio.ObterRodízio(visita.Setor).Atendentes.Contains(funcionário);

                    if (funcionárioAtendendoAntes != null)
                        if (funcionárioAtendendoAntes.Situação == EstadoFuncionário.Atendendo && Visita.ObterAtendimentos(funcionárioAtendendoAntes).Count == 0)
                            funcionárioAtendendoAntes.Situação = EstadoFuncionário.Disponível;

                }
            }
		}
		
		#endregion

		#region Funcionários

		/// <summary>
		/// Mostra propriedades de estado do funcinário
		/// </summary>
		private void opçãoVendedorAlterarEstado_Click(object sender, System.EventArgs e)
		{
            Funcionário vendedor;

            vendedor = listaVisitantes.FuncionárioSelecionado;

            if (vendedor == null)
                MessageBox.Show(
                    ParentForm,
                    "Por favor, selecione um funcionário antes de prosseguir.",
                    "Alterar estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                using (FuncionárioPropriedades dlg = new FuncionárioPropriedades(vendedor))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        vendedor.Situação = dlg.Estado;
                        listaVisitantes.AtualizarFuncionário(vendedor);
                    }
                }
        }

		/// <summary>
		/// Mostra as propriedades do ordenarPorRodízio
		/// </summary>
		private void opçãoVendedorRodízio_Click(object sender, System.EventArgs e)
		{
			RodízioPropriedades rodízio = new RodízioPropriedades();

			rodízio.ShowDialog(this);
		}

		#endregion

		private void opçãoGenéricaRegistrarEntrada_Click(object sender, System.EventArgs e)
		{
			SubstituirBase(biRegistrarVisitante);
		}

        private void listaVisitantes_AoSelecionarFuncionário(object sender, EventArgs e)
        {
            Mostrar(opçõesVendedor);
        }

        /// <summary>
        /// Ocorre ao cadastrar um visitante.
        /// </summary>
        private void biRegistrarVisitante_AoCadastrar(Visita visita)
        {
            listaVisitantes.AdicionarVisita(visita);

            if (visita.Setor != null)
            {
                Rodízio rodízio = Rodízio.ObterRodízio(visita.Setor);
                Atendimento atendimento;

                atendimento = rodízio.ObterPróximoAtendimento();

                if (atendimento != null)
                    listaVisitantes.AtualizarVisita(atendimento.Visita);
            }
        }

        private void listaVisitantes_AoSelecionarVisitante(object sender, EventArgs e)
        {
            Mostrar(opçõesVisitante);
        }

        private void opçãoVisitanteRegistrarSaída_Click(object sender, EventArgs e)
        {
            Visita visita = listaVisitantes.VisitaSelecionada;
            
            if (visita == null)
            {
                MessageBox.Show(
                    ParentForm,
                    "Por favor, escolha um visitante antes de registrar a saída.",
                    "Registrar saída",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UseWaitCursor = true;

            AguardeDB.Mostrar();

            try
            {
                visita.Saída = DadosGlobais.Instância.HoraDataAtual;
                visita.Atualizar();


                if (visita.Atendente != null)
                    if (visita.Atendente.Situação == EstadoFuncionário.Atendendo && Visita.ObterAtendimentos(visita.Atendente).Count == 0)
                        visita.Atendente.Situação = EstadoFuncionário.Disponível;

                if (visita.Setor != null)
                {
                    Rodízio rodízio = Rodízio.ObterRodízio(visita.Setor);
                    Atendimento atendimento;

                    rodízio.EncerrarAtendimento(visita);
                    atendimento = rodízio.ObterPróximoAtendimento();

                    if (atendimento != null)
                        listaVisitantes.AtualizarVisita(atendimento.Visita);
                }

                listaVisitantes.AtualizarVisita(visita);
            }
            finally
            {
                UseWaitCursor = false;
                AguardeDB.Fechar();
            }
        }

        private void opçãoRenomear_Click(object sender, EventArgs e)
        {
            Visita visita = listaVisitantes.VisitaSelecionada;

            if (visita == null)
            {
                MessageBox.Show(
                    ParentForm,
                    "Por favor, escolha um visitante antes de corrigir seu nome.",
                    "Correção de nome",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (visita.Nomes.ContarElementos() == 0)
                MessageBox.Show(
                    ParentForm,
                    "Não é possível alterar pelo sistema da recepção nome de cliente cadastrado no banco de dados.",
                    "Correção de nome",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (visita.Pessoas.ContarElementos() > 0)
                    MessageBox.Show(
                        ParentForm,
                        "Nomes de clientes cadastrados não podem ser alterados pelo sistema da recepção.\n\n"
                        + "Somente nomes não cadastrados serão questionados sobre correção.",
                        "Correção de nome",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (string nome in visita.Nomes.ToArray())
                {
                    using (CorrigirNome dlg = new CorrigirNome(nome))
                    {
                        if (dlg.ShowDialog(ParentForm) == DialogResult.OK)
                        {
                            if (dlg.Nome != nome)
                            {
                                visita.Nomes.Remover(nome);
                                visita.Nomes.Adicionar(dlg.Nome);
                            }
                        }
                    }
                }
            }

            visita.Atualizar();
            listaVisitantes.AtualizarVisita(visita);
        }

        /// <summary>
        /// Retorna a aceitação do atendimento
        /// </summary>
        private bool ConfirmandoAtendimento(Atendimento atendimento)
        {
            using (IniciarAtendimento dlg = new IniciarAtendimento(atendimento))
            {
                AguardeDB.Suspensão(true);
                dlg.ShowDialog(this.ParentForm);
                AguardeDB.Suspensão(false);

                return dlg.DialogResult == DialogResult.OK;
            }
        }

        /// <summary>
        /// Considera uma base inferior de ausência automática,
        /// tratando eventos para atualização da interface gráfica.
        /// </summary>
        public void Considerar(AusênciaAutomática bAA)
        {
        }

        /// <summary>
        /// Ocorre ao definir funcionário como ausente.
        /// </summary>
        private void AoDefinirAusente(Funcionário funcionário)
        {
            listaVisitantes.AtualizarFuncionário(funcionário);
        }

        private void opçãoVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarVisitas dlg;

            dlg = new VisualizarVisitas();
            dlg.Show(this.ParentForm);
        }
    }
}