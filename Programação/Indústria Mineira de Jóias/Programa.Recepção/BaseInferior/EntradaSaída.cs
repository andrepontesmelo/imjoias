using Apresenta��o.Formul�rios;
using Apresenta��o.Pessoa;
using Entidades;
using Entidades.Configura��o;
using Entidades.Pessoa;
using Neg�cio;
using Programa.Recep��o.Formul�rios.EntradaSa�da;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Programa.Recep��o.BaseInferior
{
	sealed class EntradaSa�da : Apresenta��o.Formul�rios.BaseInferior
	{
		// Atributos
		private Control							op��esAtuais = null;

		// Bases pr�-carregadas
		private RegistrarVisitante	biRegistrarVisitante = new RegistrarVisitante();

		// Designer
		private Controles.ListaVisitantes		 listaVisitantes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private Apresenta��o.Formul�rios.Quadro op��esVisitante;
		private System.Windows.Forms.Panel op��esGen�ricas;
		private Apresenta��o.Formul�rios.Quadro quadroVisitantes;
		private Apresenta��o.Formul�rios.Quadro quadroInforma��o;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel op��esVendedor;
		private Apresenta��o.Formul�rios.Quadro quadroVendedor;
		private System.Windows.Forms.Label label4;
        private Apresenta��o.Formul�rios.Quadro quadro1;
		private Apresenta��o.Formul�rios.Op��o op��oVisitanteAtribuirVendedor;
		private Apresenta��o.Formul�rios.Op��o op��oVisitanteRegistrarSa�da;
		private Apresenta��o.Formul�rios.Op��o op��oVisitanteRegistrarNovoVisitante;
		private Apresenta��o.Formul�rios.Op��o op��oVendedorAlterarEstado;
		private Apresenta��o.Formul�rios.Op��o op��oVendedorRod�zio;
		private Apresenta��o.Formul�rios.Op��o op��oGen�ricaRegistrarEntrada;
		private Apresenta��o.Formul�rios.Op��o op��oVendedorRegistrarEntrada;
        private Op��o op��oVisualizar;
        private Op��o op��oVisitaVisualizar;
        private Op��o op��oVendedorVisualizarVisitantes;
        private Op��o op��oRenomear;
		private System.ComponentModel.IContainer components = null;

		public EntradaSa�da()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Mostrar listas
			if (this.DesignMode)
				return;

			// Configurar barra de op��es
			op��esAtuais = op��esGen�ricas;
			op��esVendedor.Top = op��esVisitante.Top = op��esAtuais.Top;

            biRegistrarVisitante.AoCadastrar += new RegistrarVisitante.AoCadastrarCallback(biRegistrarVisitante_AoCadastrar);
		}

        /// <summary>
        /// Ocorre ao definir o controlador da base inferior.
        /// </summary>
        protected override void AoDefinirControlador(Apresenta��o.Formul�rios.ControladorBaseInferior controlador)
        {
            base.AoDefinirControlador(controlador);

            controlador.InserirBaseInferior(biRegistrarVisitante);
        }

        public override void AoCarregarCompletamente(Apresenta��o.Formul�rios.Splash splash)
        {
            Rod�zio.AtendimentoCallback iniciarAtendimento;
            
            base.AoCarregarCompletamente(splash);

            iniciarAtendimento = new Rod�zio.AtendimentoCallback(ConfirmandoAtendimento);

            foreach (Setor setor in Setor.ObterSetoresAtendimento())
                Rod�zio.ObterRod�zio(setor).ConfirmandoAtendimento += iniciarAtendimento;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradaSa�da));
            this.op��esVisitante = new Apresenta��o.Formul�rios.Quadro();
            this.label3 = new System.Windows.Forms.Label();
            this.op��oVisitanteRegistrarSa�da = new Apresenta��o.Formul�rios.Op��o();
            this.op��oRenomear = new Apresenta��o.Formul�rios.Op��o();
            this.op��oVisitaVisualizar = new Apresenta��o.Formul�rios.Op��o();
            this.op��oVisitanteAtribuirVendedor = new Apresenta��o.Formul�rios.Op��o();
            this.op��oVisitanteRegistrarNovoVisitante = new Apresenta��o.Formul�rios.Op��o();
            this.label2 = new System.Windows.Forms.Label();
            this.op��esGen�ricas = new System.Windows.Forms.Panel();
            this.quadroVisitantes = new Apresenta��o.Formul�rios.Quadro();
            this.op��oGen�ricaRegistrarEntrada = new Apresenta��o.Formul�rios.Op��o();
            this.op��oVisualizar = new Apresenta��o.Formul�rios.Op��o();
            this.quadroInforma��o = new Apresenta��o.Formul�rios.Quadro();
            this.label1 = new System.Windows.Forms.Label();
            this.op��esVendedor = new System.Windows.Forms.Panel();
            this.quadroVendedor = new Apresenta��o.Formul�rios.Quadro();
            this.op��oVendedorAlterarEstado = new Apresenta��o.Formul�rios.Op��o();
            this.label4 = new System.Windows.Forms.Label();
            this.op��oVendedorRod�zio = new Apresenta��o.Formul�rios.Op��o();
            this.quadro1 = new Apresenta��o.Formul�rios.Quadro();
            this.op��oVendedorVisualizarVisitantes = new Apresenta��o.Formul�rios.Op��o();
            this.op��oVendedorRegistrarEntrada = new Apresenta��o.Formul�rios.Op��o();
            this.listaVisitantes = new Programa.Recep��o.BaseInferior.Controles.ListaVisitantes();
            this.esquerda.SuspendLayout();
            this.op��esVisitante.SuspendLayout();
            this.op��esGen�ricas.SuspendLayout();
            this.quadroVisitantes.SuspendLayout();
            this.quadroInforma��o.SuspendLayout();
            this.op��esVendedor.SuspendLayout();
            this.quadroVendedor.SuspendLayout();
            this.quadro1.SuspendLayout();
            this.SuspendLayout();
            // 
            // esquerda
            // 
            this.esquerda.Controls.Add(this.op��esVendedor);
            this.esquerda.Controls.Add(this.quadroInforma��o);
            this.esquerda.Controls.Add(this.op��esGen�ricas);
            this.esquerda.Controls.Add(this.op��esVisitante);
            this.esquerda.Size = new System.Drawing.Size(187, 756);
            this.esquerda.Controls.SetChildIndex(this.op��esVisitante, 0);
            this.esquerda.Controls.SetChildIndex(this.op��esGen�ricas, 0);
            this.esquerda.Controls.SetChildIndex(this.quadroInforma��o, 0);
            this.esquerda.Controls.SetChildIndex(this.op��esVendedor, 0);
            // 
            // op��esVisitante
            // 
            this.op��esVisitante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.op��esVisitante.bInfDirArredondada = true;
            this.op��esVisitante.bInfEsqArredondada = true;
            this.op��esVisitante.bSupDirArredondada = true;
            this.op��esVisitante.bSupEsqArredondada = true;
            this.op��esVisitante.Controls.Add(this.label3);
            this.op��esVisitante.Controls.Add(this.op��oVisitanteRegistrarSa�da);
            this.op��esVisitante.Controls.Add(this.op��oRenomear);
            this.op��esVisitante.Controls.Add(this.op��oVisitaVisualizar);
            this.op��esVisitante.Controls.Add(this.op��oVisitanteAtribuirVendedor);
            this.op��esVisitante.Controls.Add(this.op��oVisitanteRegistrarNovoVisitante);
            this.op��esVisitante.Controls.Add(this.label2);
            this.op��esVisitante.Cor = System.Drawing.Color.Black;
            this.op��esVisitante.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.op��esVisitante.LetraT�tulo = System.Drawing.Color.White;
            this.op��esVisitante.Location = new System.Drawing.Point(7, 115);
            this.op��esVisitante.MostrarBot�oMinMax = false;
            this.op��esVisitante.Name = "op��esVisitante";
            this.op��esVisitante.Size = new System.Drawing.Size(160, 260);
            this.op��esVisitante.TabIndex = 8;
            this.op��esVisitante.Tamanho = 30;
            this.op��esVisitante.T�tulo = "Visitantes";
            this.op��esVisitante.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sobre o visitante escolhido, o que voc� deseja?";
            // 
            // op��oVisitanteRegistrarSa�da
            // 
            this.op��oVisitanteRegistrarSa�da.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVisitanteRegistrarSa�da.Descri��o = "Registrar sa�da";
            this.op��oVisitanteRegistrarSa�da.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVisitanteRegistrarSa�da.Imagem")));
            this.op��oVisitanteRegistrarSa�da.Location = new System.Drawing.Point(5, 105);
            this.op��oVisitanteRegistrarSa�da.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVisitanteRegistrarSa�da.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVisitanteRegistrarSa�da.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVisitanteRegistrarSa�da.Name = "op��oVisitanteRegistrarSa�da";
            this.op��oVisitanteRegistrarSa�da.Size = new System.Drawing.Size(150, 24);
            this.op��oVisitanteRegistrarSa�da.TabIndex = 2;
            this.op��oVisitanteRegistrarSa�da.Click += new System.EventHandler(this.op��oVisitanteRegistrarSa�da_Click);
            // 
            // op��oRenomear
            // 
            this.op��oRenomear.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oRenomear.Descri��o = "Corrigir nome";
            this.op��oRenomear.Imagem = global::Programa.Recep��o.Properties.Resources.RenameFolderHS;
            this.op��oRenomear.Location = new System.Drawing.Point(5, 129);
            this.op��oRenomear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oRenomear.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oRenomear.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oRenomear.Name = "op��oRenomear";
            this.op��oRenomear.Size = new System.Drawing.Size(150, 24);
            this.op��oRenomear.TabIndex = 3;
            this.op��oRenomear.Click += new System.EventHandler(this.op��oRenomear_Click);
            // 
            // op��oVisitaVisualizar
            // 
            this.op��oVisitaVisualizar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVisitaVisualizar.Descri��o = "Visualizar visitas";
            this.op��oVisitaVisualizar.Imagem = global::Programa.Recep��o.Properties.Resources.relat�rio;
            this.op��oVisitaVisualizar.Location = new System.Drawing.Point(5, 232);
            this.op��oVisitaVisualizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVisitaVisualizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVisitaVisualizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVisitaVisualizar.Name = "op��oVisitaVisualizar";
            this.op��oVisitaVisualizar.Size = new System.Drawing.Size(150, 30);
            this.op��oVisitaVisualizar.TabIndex = 6;
            this.op��oVisitaVisualizar.Click += new System.EventHandler(this.op��oVisualizar_Click);
            // 
            // op��oVisitanteAtribuirVendedor
            // 
            this.op��oVisitanteAtribuirVendedor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVisitanteAtribuirVendedor.Descri��o = "Atribuir vendedor";
            this.op��oVisitanteAtribuirVendedor.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVisitanteAtribuirVendedor.Imagem")));
            this.op��oVisitanteAtribuirVendedor.Location = new System.Drawing.Point(5, 81);
            this.op��oVisitanteAtribuirVendedor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVisitanteAtribuirVendedor.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVisitanteAtribuirVendedor.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVisitanteAtribuirVendedor.Name = "op��oVisitanteAtribuirVendedor";
            this.op��oVisitanteAtribuirVendedor.Size = new System.Drawing.Size(150, 24);
            this.op��oVisitanteAtribuirVendedor.TabIndex = 1;
            this.op��oVisitanteAtribuirVendedor.Click += new System.EventHandler(this.op��oVisitanteAtribuirVendedor_Click);
            // 
            // op��oVisitanteRegistrarNovoVisitante
            // 
            this.op��oVisitanteRegistrarNovoVisitante.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVisitanteRegistrarNovoVisitante.Descri��o = "Registrar entrada de novo visitante";
            this.op��oVisitanteRegistrarNovoVisitante.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVisitanteRegistrarNovoVisitante.Imagem")));
            this.op��oVisitanteRegistrarNovoVisitante.Location = new System.Drawing.Point(5, 200);
            this.op��oVisitanteRegistrarNovoVisitante.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVisitanteRegistrarNovoVisitante.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVisitanteRegistrarNovoVisitante.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVisitanteRegistrarNovoVisitante.Name = "op��oVisitanteRegistrarNovoVisitante";
            this.op��oVisitanteRegistrarNovoVisitante.Size = new System.Drawing.Size(150, 38);
            this.op��oVisitanteRegistrarNovoVisitante.TabIndex = 5;
            this.op��oVisitanteRegistrarNovoVisitante.Click += new System.EventHandler(this.op��oGen�ricaRegistrarEntrada_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ou ent�o, o que voc� deseja?";
            // 
            // op��esGen�ricas
            // 
            this.op��esGen�ricas.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��esGen�ricas.Controls.Add(this.quadroVisitantes);
            this.op��esGen�ricas.Location = new System.Drawing.Point(7, 16);
            this.op��esGen�ricas.Name = "op��esGen�ricas";
            this.op��esGen�ricas.Size = new System.Drawing.Size(160, 200);
            this.op��esGen�ricas.TabIndex = 9;
            // 
            // quadroVisitantes
            // 
            this.quadroVisitantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVisitantes.bInfDirArredondada = true;
            this.quadroVisitantes.bInfEsqArredondada = true;
            this.quadroVisitantes.bSupDirArredondada = true;
            this.quadroVisitantes.bSupEsqArredondada = true;
            this.quadroVisitantes.Controls.Add(this.op��oGen�ricaRegistrarEntrada);
            this.quadroVisitantes.Controls.Add(this.op��oVisualizar);
            this.quadroVisitantes.Cor = System.Drawing.Color.Black;
            this.quadroVisitantes.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVisitantes.LetraT�tulo = System.Drawing.Color.White;
            this.quadroVisitantes.Location = new System.Drawing.Point(0, 110);
            this.quadroVisitantes.MostrarBot�oMinMax = false;
            this.quadroVisitantes.Name = "quadroVisitantes";
            this.quadroVisitantes.Size = new System.Drawing.Size(160, 77);
            this.quadroVisitantes.TabIndex = 8;
            this.quadroVisitantes.Tamanho = 30;
            this.quadroVisitantes.T�tulo = "Visitantes";
            // 
            // op��oGen�ricaRegistrarEntrada
            // 
            this.op��oGen�ricaRegistrarEntrada.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oGen�ricaRegistrarEntrada.Descri��o = "Registrar entrada";
            this.op��oGen�ricaRegistrarEntrada.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oGen�ricaRegistrarEntrada.Imagem")));
            this.op��oGen�ricaRegistrarEntrada.Location = new System.Drawing.Point(8, 32);
            this.op��oGen�ricaRegistrarEntrada.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oGen�ricaRegistrarEntrada.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oGen�ricaRegistrarEntrada.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oGen�ricaRegistrarEntrada.Name = "op��oGen�ricaRegistrarEntrada";
            this.op��oGen�ricaRegistrarEntrada.Size = new System.Drawing.Size(150, 24);
            this.op��oGen�ricaRegistrarEntrada.TabIndex = 2;
            this.op��oGen�ricaRegistrarEntrada.Click += new System.EventHandler(this.op��oGen�ricaRegistrarEntrada_Click);
            // 
            // op��oVisualizar
            // 
            this.op��oVisualizar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVisualizar.Descri��o = "Visualizar visitas";
            this.op��oVisualizar.Imagem = global::Programa.Recep��o.Properties.Resources.relat�rio;
            this.op��oVisualizar.Location = new System.Drawing.Point(8, 56);
            this.op��oVisualizar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVisualizar.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVisualizar.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVisualizar.Name = "op��oVisualizar";
            this.op��oVisualizar.Size = new System.Drawing.Size(150, 24);
            this.op��oVisualizar.TabIndex = 3;
            this.op��oVisualizar.Click += new System.EventHandler(this.op��oVisualizar_Click);
            // 
            // quadroInforma��o
            // 
            this.quadroInforma��o.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroInforma��o.bInfDirArredondada = true;
            this.quadroInforma��o.bInfEsqArredondada = true;
            this.quadroInforma��o.bSupDirArredondada = true;
            this.quadroInforma��o.bSupEsqArredondada = true;
            this.quadroInforma��o.Controls.Add(this.label1);
            this.quadroInforma��o.Cor = System.Drawing.Color.Black;
            this.quadroInforma��o.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroInforma��o.LetraT�tulo = System.Drawing.Color.White;
            this.quadroInforma��o.Location = new System.Drawing.Point(7, 13);
            this.quadroInforma��o.MostrarBot�oMinMax = false;
            this.quadroInforma��o.Name = "quadroInforma��o";
            this.quadroInforma��o.Size = new System.Drawing.Size(160, 104);
            this.quadroInforma��o.TabIndex = 9;
            this.quadroInforma��o.Tamanho = 30;
            this.quadroInforma��o.T�tulo = "Dica";
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
    " op��es para estas pessoas.";
            // 
            // op��esVendedor
            // 
            this.op��esVendedor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��esVendedor.Controls.Add(this.quadroVendedor);
            this.op��esVendedor.Controls.Add(this.quadro1);
            this.op��esVendedor.Location = new System.Drawing.Point(7, 381);
            this.op��esVendedor.Name = "op��esVendedor";
            this.op��esVendedor.Size = new System.Drawing.Size(160, 273);
            this.op��esVendedor.TabIndex = 10;
            this.op��esVendedor.Visible = false;
            // 
            // quadroVendedor
            // 
            this.quadroVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadroVendedor.bInfDirArredondada = true;
            this.quadroVendedor.bInfEsqArredondada = true;
            this.quadroVendedor.bSupDirArredondada = true;
            this.quadroVendedor.bSupEsqArredondada = true;
            this.quadroVendedor.Controls.Add(this.op��oVendedorAlterarEstado);
            this.quadroVendedor.Controls.Add(this.label4);
            this.quadroVendedor.Controls.Add(this.op��oVendedorRod�zio);
            this.quadroVendedor.Cor = System.Drawing.Color.Black;
            this.quadroVendedor.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendedor.LetraT�tulo = System.Drawing.Color.White;
            this.quadroVendedor.Location = new System.Drawing.Point(0, 0);
            this.quadroVendedor.MostrarBot�oMinMax = false;
            this.quadroVendedor.Name = "quadroVendedor";
            this.quadroVendedor.Size = new System.Drawing.Size(160, 136);
            this.quadroVendedor.TabIndex = 7;
            this.quadroVendedor.Tamanho = 30;
            this.quadroVendedor.T�tulo = "Vendedor";
            // 
            // op��oVendedorAlterarEstado
            // 
            this.op��oVendedorAlterarEstado.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVendedorAlterarEstado.Descri��o = "Alterar estado";
            this.op��oVendedorAlterarEstado.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVendedorAlterarEstado.Imagem")));
            this.op��oVendedorAlterarEstado.Location = new System.Drawing.Point(8, 80);
            this.op��oVendedorAlterarEstado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVendedorAlterarEstado.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVendedorAlterarEstado.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVendedorAlterarEstado.Name = "op��oVendedorAlterarEstado";
            this.op��oVendedorAlterarEstado.Size = new System.Drawing.Size(150, 24);
            this.op��oVendedorAlterarEstado.TabIndex = 7;
            this.op��oVendedorAlterarEstado.Click += new System.EventHandler(this.op��oVendedorAlterarEstado_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 40);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sobre o vendedor escolhido, o que voc� deseja?";
            // 
            // op��oVendedorRod�zio
            // 
            this.op��oVendedorRod�zio.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVendedorRod�zio.Descri��o = "Modificar op��es de rod�zio";
            this.op��oVendedorRod�zio.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVendedorRod�zio.Imagem")));
            this.op��oVendedorRod�zio.Location = new System.Drawing.Point(8, 104);
            this.op��oVendedorRod�zio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVendedorRod�zio.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVendedorRod�zio.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVendedorRod�zio.Name = "op��oVendedorRod�zio";
            this.op��oVendedorRod�zio.Size = new System.Drawing.Size(150, 32);
            this.op��oVendedorRod�zio.TabIndex = 8;
            this.op��oVendedorRod�zio.Click += new System.EventHandler(this.op��oVendedorRod�zio_Click);
            // 
            // quadro1
            // 
            this.quadro1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.quadro1.bInfDirArredondada = true;
            this.quadro1.bInfEsqArredondada = true;
            this.quadro1.bSupDirArredondada = true;
            this.quadro1.bSupEsqArredondada = true;
            this.quadro1.Controls.Add(this.op��oVendedorVisualizarVisitantes);
            this.quadro1.Controls.Add(this.op��oVendedorRegistrarEntrada);
            this.quadro1.Cor = System.Drawing.Color.Black;
            this.quadro1.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadro1.LetraT�tulo = System.Drawing.Color.White;
            this.quadro1.Location = new System.Drawing.Point(0, 142);
            this.quadro1.MostrarBot�oMinMax = false;
            this.quadro1.Name = "quadro1";
            this.quadro1.Size = new System.Drawing.Size(160, 78);
            this.quadro1.TabIndex = 8;
            this.quadro1.Tamanho = 30;
            this.quadro1.T�tulo = "Visitantes";
            // 
            // op��oVendedorVisualizarVisitantes
            // 
            this.op��oVendedorVisualizarVisitantes.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVendedorVisualizarVisitantes.Descri��o = "Visualizar visitas";
            this.op��oVendedorVisualizarVisitantes.Imagem = global::Programa.Recep��o.Properties.Resources.relat�rio;
            this.op��oVendedorVisualizarVisitantes.Location = new System.Drawing.Point(5, 56);
            this.op��oVendedorVisualizarVisitantes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVendedorVisualizarVisitantes.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVendedorVisualizarVisitantes.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVendedorVisualizarVisitantes.Name = "op��oVendedorVisualizarVisitantes";
            this.op��oVendedorVisualizarVisitantes.Size = new System.Drawing.Size(150, 24);
            this.op��oVendedorVisualizarVisitantes.TabIndex = 4;
            this.op��oVendedorVisualizarVisitantes.Click += new System.EventHandler(this.op��oVisualizar_Click);
            // 
            // op��oVendedorRegistrarEntrada
            // 
            this.op��oVendedorRegistrarEntrada.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.op��oVendedorRegistrarEntrada.Descri��o = "Registrar entrada";
            this.op��oVendedorRegistrarEntrada.Imagem = ((System.Drawing.Image)(resources.GetObject("op��oVendedorRegistrarEntrada.Imagem")));
            this.op��oVendedorRegistrarEntrada.Location = new System.Drawing.Point(5, 32);
            this.op��oVendedorRegistrarEntrada.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.op��oVendedorRegistrarEntrada.MaximumSize = new System.Drawing.Size(150, 100);
            this.op��oVendedorRegistrarEntrada.MinimumSize = new System.Drawing.Size(150, 16);
            this.op��oVendedorRegistrarEntrada.Name = "op��oVendedorRegistrarEntrada";
            this.op��oVendedorRegistrarEntrada.Size = new System.Drawing.Size(150, 24);
            this.op��oVendedorRegistrarEntrada.TabIndex = 3;
            this.op��oVendedorRegistrarEntrada.Click += new System.EventHandler(this.op��oGen�ricaRegistrarEntrada_Click);
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
            this.listaVisitantes.AoSelecionarFuncion�rio += new System.EventHandler(this.listaVisitantes_AoSelecionarFuncion�rio);
            this.listaVisitantes.AoSelecionarVisitante += new System.EventHandler(this.listaVisitantes_AoSelecionarVisitante);
            this.listaVisitantes.DuploCliqueVendedores += new System.EventHandler(this.listaVisitantes_DuploCliqueVendedores);
            // 
            // EntradaSa�da
            // 
            this.Controls.Add(this.listaVisitantes);
            this.Name = "EntradaSa�da";
            this.Size = new System.Drawing.Size(784, 756);
            this.Controls.SetChildIndex(this.listaVisitantes, 0);
            this.Controls.SetChildIndex(this.esquerda, 0);
            this.esquerda.ResumeLayout(false);
            this.op��esVisitante.ResumeLayout(false);
            this.op��esGen�ricas.ResumeLayout(false);
            this.quadroVisitantes.ResumeLayout(false);
            this.quadroInforma��o.ResumeLayout(false);
            this.op��esVendedor.ResumeLayout(false);
            this.quadroVendedor.ResumeLayout(false);
            this.quadro1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Processamento da interface de usu�rio (Eventos, etc)

		private void Mostrar(Control controle)
		{
			// Verificar se controle j� est� sendo exibido
			if (op��esAtuais != controle)
			{
                //this.SuspendLayout();
                //esquerda.SuspendLayout();

				if (controle != null)
				{
                    //controle.SuspendLayout();

					//controle.Top = 0;
					controle.Visible = true;
				}

				if (op��esAtuais != null)
					op��esAtuais.Visible = false;

                //if (controle != null)
                //    controle.ResumeLayout();

                //esquerda.ResumeLayout();
                //this.ResumeLayout();

				op��esAtuais = controle;
			}
		}

		private void listaVisitantes_DuploCliqueVendedores(object sender, System.EventArgs e)
		{
			op��oVendedorAlterarEstado_Click(sender, e);
		}

		#endregion

		#region Visitantes

		private void op��oVisitanteAtribuirVendedor_Click(object sender, System.EventArgs e)
		{
            List<Funcion�rio> funcion�rios = Funcion�rio.ObterFuncion�rios(true, false);
            Visita visita;

            visita = listaVisitantes.VisitaSelecionada;

            using (AtribuirAtendimento dlg = new AtribuirAtendimento(visita.ExtrairNomes(), funcion�rios))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Funcion�rio funcion�rio = dlg.Funcion�rio;

                    // Verificar estado do funcion�rio
                    if (funcion�rio.Situa��o == EstadoFuncion�rio.Atendendo)
                        if (MessageBox.Show(this, "O funcion�rio \""
                            + funcion�rio.Nome
                            + "\" encontra-se atendendo o(s) cliente(s) \""
                            + Visita.ExtrairNomes(Visita.ObterAtendimentos(funcion�rio))
                            + "\". Deseja mesmo interromper este atendimento para que este funcion�rio atenda \""
                            + visita.ExtrairNomes() + "\"?",
                            "Encaminhar atendimento",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        {
                            dlg.Dispose();

                            return;
                        }

                    Funcion�rio funcion�rioAtendendoAntes = visita.Atendente;

                    Rod�zio.RegistrarAtendimento(visita, funcion�rio);
                    listaVisitantes.AtualizarVisita(visita);

                    visita.AtendimentoForaDoRod�zio = 
                        !Rod�zio.ObterRod�zio(visita.Setor).Atendentes.Contains(funcion�rio);

                    if (funcion�rioAtendendoAntes != null)
                        if (funcion�rioAtendendoAntes.Situa��o == EstadoFuncion�rio.Atendendo && Visita.ObterAtendimentos(funcion�rioAtendendoAntes).Count == 0)
                            funcion�rioAtendendoAntes.Situa��o = EstadoFuncion�rio.Dispon�vel;

                }
            }
		}
		
		#endregion

		#region Funcion�rios

		/// <summary>
		/// Mostra propriedades de estado do funcin�rio
		/// </summary>
		private void op��oVendedorAlterarEstado_Click(object sender, System.EventArgs e)
		{
            Funcion�rio vendedor;

            vendedor = listaVisitantes.Funcion�rioSelecionado;

            if (vendedor == null)
                MessageBox.Show(
                    ParentForm,
                    "Por favor, selecione um funcion�rio antes de prosseguir.",
                    "Alterar estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                using (Funcion�rioPropriedades dlg = new Funcion�rioPropriedades(vendedor))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        vendedor.Situa��o = dlg.Estado;
                        listaVisitantes.AtualizarFuncion�rio(vendedor);
                    }
                }
        }

		/// <summary>
		/// Mostra as propriedades do ordenarPorRod�zio
		/// </summary>
		private void op��oVendedorRod�zio_Click(object sender, System.EventArgs e)
		{
			Rod�zioPropriedades rod�zio = new Rod�zioPropriedades();

			rod�zio.ShowDialog(this);
		}

		#endregion

		private void op��oGen�ricaRegistrarEntrada_Click(object sender, System.EventArgs e)
		{
			SubstituirBase(biRegistrarVisitante);
		}

        private void listaVisitantes_AoSelecionarFuncion�rio(object sender, EventArgs e)
        {
            Mostrar(op��esVendedor);
        }

        /// <summary>
        /// Ocorre ao cadastrar um visitante.
        /// </summary>
        private void biRegistrarVisitante_AoCadastrar(Visita visita)
        {
            listaVisitantes.AdicionarVisita(visita);

            if (visita.Setor != null)
            {
                Rod�zio rod�zio = Rod�zio.ObterRod�zio(visita.Setor);
                Atendimento atendimento;

                atendimento = rod�zio.ObterPr�ximoAtendimento();

                if (atendimento != null)
                    listaVisitantes.AtualizarVisita(atendimento.Visita);
            }
        }

        private void listaVisitantes_AoSelecionarVisitante(object sender, EventArgs e)
        {
            Mostrar(op��esVisitante);
        }

        private void op��oVisitanteRegistrarSa�da_Click(object sender, EventArgs e)
        {
            Visita visita = listaVisitantes.VisitaSelecionada;
            
            if (visita == null)
            {
                MessageBox.Show(
                    ParentForm,
                    "Por favor, escolha um visitante antes de registrar a sa�da.",
                    "Registrar sa�da",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UseWaitCursor = true;

            AguardeDB.Mostrar();

            try
            {
                visita.Sa�da = DadosGlobais.Inst�ncia.HoraDataAtual;
                visita.Atualizar();


                if (visita.Atendente != null)
                    if (visita.Atendente.Situa��o == EstadoFuncion�rio.Atendendo && Visita.ObterAtendimentos(visita.Atendente).Count == 0)
                        visita.Atendente.Situa��o = EstadoFuncion�rio.Dispon�vel;

                if (visita.Setor != null)
                {
                    Rod�zio rod�zio = Rod�zio.ObterRod�zio(visita.Setor);
                    Atendimento atendimento;

                    rod�zio.EncerrarAtendimento(visita);
                    atendimento = rod�zio.ObterPr�ximoAtendimento();

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

        private void op��oRenomear_Click(object sender, EventArgs e)
        {
            Visita visita = listaVisitantes.VisitaSelecionada;

            if (visita == null)
            {
                MessageBox.Show(
                    ParentForm,
                    "Por favor, escolha um visitante antes de corrigir seu nome.",
                    "Corre��o de nome",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (visita.Nomes.ContarElementos() == 0)
                MessageBox.Show(
                    ParentForm,
                    "N�o � poss�vel alterar pelo sistema da recep��o nome de cliente cadastrado no banco de dados.",
                    "Corre��o de nome",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (visita.Pessoas.ContarElementos() > 0)
                    MessageBox.Show(
                        ParentForm,
                        "Nomes de clientes cadastrados n�o podem ser alterados pelo sistema da recep��o.\n\n"
                        + "Somente nomes n�o cadastrados ser�o questionados sobre corre��o.",
                        "Corre��o de nome",
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
        /// Retorna a aceita��o do atendimento
        /// </summary>
        private bool ConfirmandoAtendimento(Atendimento atendimento)
        {
            using (IniciarAtendimento dlg = new IniciarAtendimento(atendimento))
            {
                AguardeDB.Suspens�o(true);
                dlg.ShowDialog(this.ParentForm);
                AguardeDB.Suspens�o(false);

                return dlg.DialogResult == DialogResult.OK;
            }
        }

        /// <summary>
        /// Considera uma base inferior de aus�ncia autom�tica,
        /// tratando eventos para atualiza��o da interface gr�fica.
        /// </summary>
        public void Considerar(Aus�nciaAutom�tica bAA)
        {
        }

        /// <summary>
        /// Ocorre ao definir funcion�rio como ausente.
        /// </summary>
        private void AoDefinirAusente(Funcion�rio funcion�rio)
        {
            listaVisitantes.AtualizarFuncion�rio(funcion�rio);
        }

        private void op��oVisualizar_Click(object sender, EventArgs e)
        {
            VisualizarVisitas dlg;

            dlg = new VisualizarVisitas();
            dlg.Show(this.ParentForm);
        }
    }
}