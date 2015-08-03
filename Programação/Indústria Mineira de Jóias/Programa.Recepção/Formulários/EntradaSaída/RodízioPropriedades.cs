using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Entidades.Pessoa;
using Entidades;
using Neg�cio;
using Apresenta��o.Formul�rios;
using Apresenta��o.Pessoa;

namespace Programa.Recep��o.Formul�rios.EntradaSa�da
{
	sealed class Rod�zioPropriedades : Apresenta��o.Formul�rios.JanelaExplicativa
	{
		private Setor setor;
        private Dictionary<string, Setor> hSetores = new Dictionary<string, Setor>(StringComparer.Ordinal);
        private Dictionary<ListViewItem, Funcion�rio> linhas = new Dictionary<ListViewItem, Funcion�rio>();
		private bool			outroSetorAdvertido = false;

		// Designer
		private System.Windows.Forms.Label lblVarejo;
		private System.Windows.Forms.Label lblAtacado;
		private System.Windows.Forms.Label lblAltoAtacado;
		private System.Windows.Forms.Panel setores;
		private System.Windows.Forms.Label lblOrdem;
		private System.Windows.Forms.Button cmdSubir;
		private System.Windows.Forms.Button cmdDescer;
		private System.Windows.Forms.ListView lstFuncion�rios;
		private System.Windows.Forms.ColumnHeader colFuncion�rio;
		private System.Windows.Forms.ColumnHeader colSitua��o;
		private System.Windows.Forms.Button cmdAdicionar;
		private System.Windows.Forms.Button cmdRemover;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancelar;
		private System.Windows.Forms.Button cmdAplicar;
		private System.ComponentModel.IContainer components = null;

		public Rod�zioPropriedades()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            AguardeDB.Mostrar();

			// Obter setores
            try
            {
                Setor[] setores = Setor.ObterSetoresAtendimento();

                foreach (Setor setor in setores)
                    hSetores[setor.Nome] = setor;

                this.setor = hSetores["Varejo"];
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.ToString());
                Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                cmdOK.Visible = false;
                cmdAplicar.Visible = false;
            }
            finally
            {
                AguardeDB.Fechar();
            }
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Rod�zioPropriedades));
			this.setores = new System.Windows.Forms.Panel();
			this.lblAltoAtacado = new System.Windows.Forms.Label();
			this.lblAtacado = new System.Windows.Forms.Label();
			this.lblVarejo = new System.Windows.Forms.Label();
			this.lblOrdem = new System.Windows.Forms.Label();
			this.cmdSubir = new System.Windows.Forms.Button();
			this.cmdDescer = new System.Windows.Forms.Button();
			this.lstFuncion�rios = new System.Windows.Forms.ListView();
			this.colFuncion�rio = new System.Windows.Forms.ColumnHeader();
			this.colSitua��o = new System.Windows.Forms.ColumnHeader();
			this.cmdAdicionar = new System.Windows.Forms.Button();
			this.cmdRemover = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.cmdAplicar = new System.Windows.Forms.Button();
			this.setores.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblT�tulo
			// 
			this.lblT�tulo.Name = "lblT�tulo";
			this.lblT�tulo.Size = new System.Drawing.Size(63, 22);
			this.lblT�tulo.Text = "Rod�zio";
			// 
			// lblDescri��o
			// 
			this.lblDescri��o.Name = "lblDescri��o";
			this.lblDescri��o.Size = new System.Drawing.Size(368, 32);
			this.lblDescri��o.Text = "Defina aqui os funcion�rios e a ordem do rod�zio para os setores de atendimento.";
			// 
			// pic�cone
			// 
			this.pic�cone.Image = ((System.Drawing.Image)(resources.GetObject("pic�cone.Image")));
			this.pic�cone.Location = new System.Drawing.Point(8, 16);
			this.pic�cone.Name = "pic�cone";
			this.pic�cone.Size = new System.Drawing.Size(56, 56);
			this.pic�cone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			// 
			// setores
			// 
			this.setores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.setores.BackColor = System.Drawing.SystemColors.ControlLight;
			this.setores.Controls.Add(this.lblAltoAtacado);
			this.setores.Controls.Add(this.lblAtacado);
			this.setores.Controls.Add(this.lblVarejo);
			this.setores.Location = new System.Drawing.Point(8, 96);
			this.setores.Name = "setores";
			this.setores.Size = new System.Drawing.Size(96, 184);
			this.setores.TabIndex = 3;
			// 
			// lblAltoAtacado
			// 
			this.lblAltoAtacado.BackColor = System.Drawing.SystemColors.ControlLight;
			this.lblAltoAtacado.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblAltoAtacado.Location = new System.Drawing.Point(8, 72);
			this.lblAltoAtacado.Name = "lblAltoAtacado";
			this.lblAltoAtacado.Size = new System.Drawing.Size(80, 24);
			this.lblAltoAtacado.TabIndex = 2;
			this.lblAltoAtacado.Text = "Alto-Atacado";
			this.lblAltoAtacado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAltoAtacado.Click += new System.EventHandler(this.Setor_Click);
			this.lblAltoAtacado.MouseEnter += new System.EventHandler(this.Setor_MouseEnter);
			this.lblAltoAtacado.MouseLeave += new System.EventHandler(this.Setor_MouseLeave);
			// 
			// lblAtacado
			// 
			this.lblAtacado.BackColor = System.Drawing.SystemColors.ControlLight;
			this.lblAtacado.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblAtacado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblAtacado.Location = new System.Drawing.Point(8, 40);
			this.lblAtacado.Name = "lblAtacado";
			this.lblAtacado.Size = new System.Drawing.Size(80, 24);
			this.lblAtacado.TabIndex = 1;
			this.lblAtacado.Text = "Atacado";
			this.lblAtacado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblAtacado.Click += new System.EventHandler(this.Setor_Click);
			this.lblAtacado.MouseEnter += new System.EventHandler(this.Setor_MouseEnter);
			this.lblAtacado.MouseLeave += new System.EventHandler(this.Setor_MouseLeave);
			// 
			// lblVarejo
			// 
			this.lblVarejo.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lblVarejo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblVarejo.Location = new System.Drawing.Point(8, 8);
			this.lblVarejo.Name = "lblVarejo";
			this.lblVarejo.Size = new System.Drawing.Size(80, 24);
			this.lblVarejo.TabIndex = 0;
			this.lblVarejo.Text = "Varejo";
			this.lblVarejo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblVarejo.Click += new System.EventHandler(this.Setor_Click);
			this.lblVarejo.MouseEnter += new System.EventHandler(this.Setor_MouseEnter);
			this.lblVarejo.MouseLeave += new System.EventHandler(this.Setor_MouseLeave);
			// 
			// lblOrdem
			// 
			this.lblOrdem.Location = new System.Drawing.Point(112, 96);
			this.lblOrdem.Name = "lblOrdem";
			this.lblOrdem.Size = new System.Drawing.Size(224, 16);
			this.lblOrdem.TabIndex = 4;
			this.lblOrdem.Text = "Defina aqui a ordem do rod�zio:";
			// 
			// cmdSubir
			// 
			this.cmdSubir.Enabled = false;
			this.cmdSubir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdSubir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSubir.Image")));
			this.cmdSubir.Location = new System.Drawing.Point(368, 112);
			this.cmdSubir.Name = "cmdSubir";
			this.cmdSubir.Size = new System.Drawing.Size(32, 32);
			this.cmdSubir.TabIndex = 6;
			this.cmdSubir.Click += new System.EventHandler(this.cmdSubir_Click);
			// 
			// cmdDescer
			// 
			this.cmdDescer.Enabled = false;
			this.cmdDescer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdDescer.Image = ((System.Drawing.Image)(resources.GetObject("cmdDescer.Image")));
			this.cmdDescer.Location = new System.Drawing.Point(368, 144);
			this.cmdDescer.Name = "cmdDescer";
			this.cmdDescer.Size = new System.Drawing.Size(32, 32);
			this.cmdDescer.TabIndex = 7;
			this.cmdDescer.Click += new System.EventHandler(this.cmdDescer_Click);
			// 
			// lstFuncion�rios
			// 
			this.lstFuncion�rios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.colFuncion�rio,
																							  this.colSitua��o});
			this.lstFuncion�rios.FullRowSelect = true;
			this.lstFuncion�rios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstFuncion�rios.HideSelection = false;
			this.lstFuncion�rios.Location = new System.Drawing.Point(112, 112);
			this.lstFuncion�rios.MultiSelect = false;
			this.lstFuncion�rios.Name = "lstFuncion�rios";
			this.lstFuncion�rios.Size = new System.Drawing.Size(256, 128);
			this.lstFuncion�rios.TabIndex = 8;
			this.lstFuncion�rios.View = System.Windows.Forms.View.Details;
			this.lstFuncion�rios.SelectedIndexChanged += new System.EventHandler(this.lstFuncion�rios_SelectedIndexChanged);
			// 
			// colFuncion�rio
			// 
			this.colFuncion�rio.Text = "Funcion�rio";
			this.colFuncion�rio.Width = 170;
			// 
			// colSitua��o
			// 
			this.colSitua��o.Text = "Situa��o";
			this.colSitua��o.Width = 64;
			// 
			// cmdAdicionar
			// 
			this.cmdAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdicionar.Image")));
			this.cmdAdicionar.Location = new System.Drawing.Point(368, 176);
			this.cmdAdicionar.Name = "cmdAdicionar";
			this.cmdAdicionar.Size = new System.Drawing.Size(32, 32);
			this.cmdAdicionar.TabIndex = 9;
			this.cmdAdicionar.Click += new System.EventHandler(this.cmdAdicionar_Click);
			// 
			// cmdRemover
			// 
			this.cmdRemover.Enabled = false;
			this.cmdRemover.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmdRemover.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemover.Image")));
			this.cmdRemover.Location = new System.Drawing.Point(368, 208);
			this.cmdRemover.Name = "cmdRemover";
			this.cmdRemover.Size = new System.Drawing.Size(32, 32);
			this.cmdRemover.TabIndex = 10;
			this.cmdRemover.Click += new System.EventHandler(this.cmdRemover_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(240, 256);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 11;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancelar.Location = new System.Drawing.Point(160, 256);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.TabIndex = 12;
			this.cmdCancelar.Text = "Cancelar";
			// 
			// cmdAplicar
			// 
			this.cmdAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAplicar.Enabled = false;
			this.cmdAplicar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdAplicar.Location = new System.Drawing.Point(320, 256);
			this.cmdAplicar.Name = "cmdAplicar";
			this.cmdAplicar.TabIndex = 13;
			this.cmdAplicar.Text = "Aplicar";
			this.cmdAplicar.Click += new System.EventHandler(this.cmdAplicar_Click);
			// 
			// Rod�zioPropriedades
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(410, 288);
			this.Controls.Add(this.cmdAplicar);
			this.Controls.Add(this.cmdCancelar);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdRemover);
			this.Controls.Add(this.cmdAdicionar);
			this.Controls.Add(this.lstFuncion�rios);
			this.Controls.Add(this.cmdDescer);
			this.Controls.Add(this.cmdSubir);
			this.Controls.Add(this.lblOrdem);
			this.Controls.Add(this.setores);
			this.Name = "Rod�zioPropriedades";
			this.Text = "Propriedades do Rod�zio";
			this.Load += new System.EventHandler(this.Rod�zioPropriedades_Load);
			this.Controls.SetChildIndex(this.setores, 0);
			this.Controls.SetChildIndex(this.lblOrdem, 0);
			this.Controls.SetChildIndex(this.cmdSubir, 0);
			this.Controls.SetChildIndex(this.cmdDescer, 0);
			this.Controls.SetChildIndex(this.lstFuncion�rios, 0);
			this.Controls.SetChildIndex(this.cmdAdicionar, 0);
			this.Controls.SetChildIndex(this.cmdRemover, 0);
			this.Controls.SetChildIndex(this.cmdOK, 0);
			this.Controls.SetChildIndex(this.cmdCancelar, 0);
			this.Controls.SetChildIndex(this.cmdAplicar, 0);
			this.setores.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Barra de setores

		private void Setor_MouseEnter(object sender, System.EventArgs e)
		{
			((Label) sender).BorderStyle = BorderStyle.Fixed3D;
		}

		private void Setor_MouseLeave(object sender, System.EventArgs e)
		{
			((Label) sender).BorderStyle = BorderStyle.None;
		}

		private void Setor_Click(object sender, System.EventArgs e)
		{
			// Verificar se dados est�o salvos
			if (cmdAplicar.Enabled)
			{
				switch (MessageBox.Show(this, "Os dados deste rod�zio ainda n�o est�o salvos. Deseja salv�-lo?", "Rod�zio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Yes:
						cmdAplicar_Click(sender, e);
						break;

					case DialogResult.No:
						cmdAplicar.Enabled = false;
						break;

					case DialogResult.Cancel:
						return;
				}
			}

			// Alterar visualiza��o
			lblVarejo.BackColor = setores.BackColor;
			lblAtacado.BackColor = setores.BackColor;
			lblAltoAtacado.BackColor = setores.BackColor;

			((Label) sender).BackColor = SystemColors.ControlLightLight;

			setor = hSetores[((Label) sender).Text];

			MostrarFuncion�rios();
		}

		#endregion

		/// <summary>
		/// Mostra funcion�rios do ordenarPorRod�zio do setor na lista de
		/// funcion�rios.
		/// </summary>
		public void MostrarFuncion�rios()
		{
            AguardeDB.Mostrar();

            try
            {
                Rod�zio rod�zio = Rod�zio.ObterRod�zio(setor);

                // Limpar lista
                lstFuncion�rios.Items.Clear();
                linhas.Clear();

                // Inserir funcion�rios na listview
                foreach (Funcion�rio atendente in rod�zio.Atendentes)
                    AdicionarFuncion�rio(atendente);
            }
            finally
            {
                AguardeDB.Fechar();
            }
		}

		/// <summary>
		/// Adiciona na listview o funcion�rio
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio a ser inserido</param>
		private void AdicionarFuncion�rio(Funcion�rio funcion�rio)
		{
			ListViewItem linha = new ListViewItem();

			linha.Text = funcion�rio.Nome;
			linha.SubItems.Add(funcion�rio.Situa��o.ToString());

			if (funcion�rio.Situa��o == EstadoFuncion�rio.Atendendo)
				linha.ForeColor = Color.Red;

			// Verificar a qual setor o funcion�rio pertence
			if (funcion�rio.Setor.C�digo != setor.C�digo)
			{
				linha.BackColor = Color.LightGreen;

				if (!outroSetorAdvertido)
				{
					outroSetorAdvertido = true;

					MessageBox.Show(this, "Foi inserido no rod�zio um funcion�rio de outro setor. Funcion�rios de outros setores ser�o marcados com a cor verde.", "Rod�zio", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			lstFuncion�rios.Items.Add(linha);
			linhas[linha] = funcion�rio;
		}

		/// <summary>
		/// Encontra linha da lista de funcion�rios que cont�m
		/// o funcion�rio espec�fico.
		/// </summary>
		private ListViewItem EncontrarFuncion�rio(Funcion�rio funcion�rio)
		{
			foreach (ListViewItem linha in lstFuncion�rios.Items)
				if (linha.Text == funcion�rio.Nome)
					return linha;

			return null;
		}

		private void Rod�zioPropriedades_Load(object sender, System.EventArgs e)
		{
			MostrarFuncion�rios();
		}

		private void Trocar(ListViewItem pri, ListViewItem seg)
		{
			lock (this)
			{
				int i = pri.Index;

				pri.Remove();
				seg.Remove();

				lstFuncion�rios.Items.Insert(i - 1, pri);
				lstFuncion�rios.Items.Insert(i, seg);
			}		
		}

		private void lstFuncion�rios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmdSubir.Enabled = cmdDescer.Enabled = cmdRemover.Enabled = lstFuncion�rios.SelectedItems.Count == 1;

			cmdSubir.Enabled = cmdSubir.Enabled && lstFuncion�rios.SelectedIndices[0] > 0;
			cmdDescer.Enabled = cmdDescer.Enabled && lstFuncion�rios.SelectedIndices[0] < lstFuncion�rios.Items.Count - 1;
		}

		private void cmdSubir_Click(object sender, System.EventArgs e)
		{
			if (lstFuncion�rios.SelectedItems.Count < 1 ||
				lstFuncion�rios.Items.Count < 2)
				return;

			ListViewItem subindo = lstFuncion�rios.SelectedItems[0];
			ListViewItem descendo = lstFuncion�rios.Items[subindo.Index - 1];

			Trocar(subindo, descendo);

			subindo.Focused = true;

			cmdAplicar.Enabled = true;
		}

		private void cmdDescer_Click(object sender, System.EventArgs e)
		{
			if (lstFuncion�rios.SelectedItems.Count < 1 ||
				lstFuncion�rios.Items.Count < 2)
				return;

			ListViewItem descendo = lstFuncion�rios.SelectedItems[0];
			ListViewItem subindo = lstFuncion�rios.Items[descendo.Index + 1];

			Trocar(subindo, descendo);

			descendo.Focused = true;

			cmdAplicar.Enabled = true;
		}

		private void cmdAdicionar_Click(object sender, System.EventArgs e)
		{
            List<Funcion�rio> funcion�rios;
            Dictionary<ListViewItem, Funcion�rio>.Enumerator iterador;

            funcion�rios = new List<Funcion�rio>(Funcion�rio.ObterFuncion�rios(true, false));
            iterador = linhas.GetEnumerator();
            
			while (iterador.MoveNext())
				funcion�rios.Remove(iterador.Current.Value);

            using (EscolherFuncion�rio dlg = new Apresenta��o.Pessoa.EscolherFuncion�rio(
                "Escolha o funcion�rio que ser� inclu�do ao rod�zio do setor \""
                + setor.Nome
                + "\".",
                funcion�rios))
            {
                dlg.�nfaseSetor = setor;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                    AdicionarFuncion�rio(dlg.Funcion�rio);
            }

			cmdAplicar.Enabled = true;
		}

		private void cmdRemover_Click(object sender, System.EventArgs e)
		{
			if (lstFuncion�rios.SelectedItems.Count < 1)
				return;

			ListViewItem linha = lstFuncion�rios.SelectedItems[0];

			linha.Remove();
			linhas.Remove(linha);
			linha = null;

			cmdAplicar.Enabled = true;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if (cmdAplicar.Enabled)
				cmdAplicar_Click(sender, e);
		}

		private void cmdAplicar_Click(object sender, System.EventArgs e)
		{
            LinkedList<Funcion�rio> funcion�rios = new LinkedList<Funcion�rio>();

            AguardeDB.Mostrar();

            try
            {
                // Construir lista de funcion�rios em ordem
                foreach (ListViewItem linha in lstFuncion�rios.Items)
                    funcion�rios.AddLast(linhas[linha]);

                Rod�zio.ObterRod�zio(setor).Atendentes = funcion�rios;

                cmdAplicar.Enabled = false;
            }
            finally
            {
                AguardeDB.Fechar();
            }
		}
	}
}

