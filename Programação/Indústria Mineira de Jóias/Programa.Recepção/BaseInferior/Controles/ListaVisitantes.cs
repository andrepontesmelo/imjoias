using Entidades;
using Entidades.Pessoa;

using Programa.Recep��o.Formul�rios.EntradaSa�da;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Configura��o;
using System.Threading;
using Apresenta��o.Formul�rios;

namespace Programa.Recep��o.BaseInferior.Controles
{
	/// <summary>
	/// Lista de visitantes.
	/// </summary>
    /// <remarks>
    /// O implementador dever� tratar os eventos AoSelecionarFuncion�rio,
    /// AoSelecionarVisitante, obrigatoriamente. Ainda, dever� utilizar os
    /// m�todos AdicionarVisita e AtualizarVisita.
    /// </remarks>
	sealed class ListaVisitantes : System.Windows.Forms.UserControl, Apresenta��o.Formul�rios.IP�sCargaSistema
	{
		public delegate void DuploClique();

		// Eventos
        public event EventHandler               AoSelecionarFuncion�rio;
        public event EventHandler               AoSelecionarVisitante;
		public event EventHandler				DuploCliqueVendedores;

		// Atributos
        private Dictionary<ListViewItem, Funcion�rio> linhaVendedor = new Dictionary<ListViewItem, Funcion�rio>();
        private Dictionary<ulong, ListViewItem> hashVendedorLinha = new Dictionary<ulong, ListViewItem>();
        private Dictionary<string, ListViewItem> hashVisitaLinha = new Dictionary<string, ListViewItem>(StringComparer.Ordinal);
        private Dictionary<ListViewItem, Visita> hashLinhaVisita = new Dictionary<ListViewItem, Visita>();
        private bool ignorarAus�ncia = false;

		// Atributos do design
		private System.Windows.Forms.ListView lstVisitantes;
		private System.Windows.Forms.ColumnHeader colVisitante;
		private System.Windows.Forms.ColumnHeader colSetor;
		private System.Windows.Forms.ColumnHeader colAtendente;
		private System.Windows.Forms.ColumnHeader colEntrada;
		private System.Windows.Forms.ColumnHeader colSa�da;
		private Apresenta��o.Formul�rios.Quadro quadroVisitante;
		private Apresenta��o.Formul�rios.Quadro quadroVendedor;
		private System.Windows.Forms.ListView lstVendedores;
		private System.Windows.Forms.ColumnHeader colVendedor;
		private System.Windows.Forms.ColumnHeader colSitua��o;
		private System.Windows.Forms.ColumnHeader colCliente;
		private System.Windows.Forms.ColumnHeader colRamal;
		private System.Windows.Forms.ColumnHeader colVendedorSetor;
        private Programa.Recep��o.BaseInferior.Controles.Funcion�rioAus�ncia funcion�rioAus�ncia;
        private System.Windows.Forms.Timer tmrAtualizarFuncion�rios;
        private IContainer components;

		public ListaVisitantes()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

        public Funcion�rio Funcion�rioSelecionado
        {
            get
            {
                if (lstVendedores.SelectedItems.Count != 1)
                    return null;

                return linhaVendedor[lstVendedores.SelectedItems[0]];
            }
        }

        public Visita VisitaSelecionada
        {
            get
            {
                if (lstVisitantes.SelectedItems.Count != 1)
                    return null;

                return hashLinhaVisita[lstVisitantes.SelectedItems[0]];
            }
        }

		private void Carregar()
		{
			try
			{
                // Inserir vendedores.
                Funcion�rio[] atendentes = Funcion�rio.ObterFuncion�rios(true, false);

                foreach (Funcion�rio funcion�rio in atendentes)
                    AdicionarFuncion�rio(funcion�rio);
                
                // Inserir visitantes
                Visita[] visitas = Visita.ObterVisitasRelevantes();

				foreach (Visita visita in visitas)
				{
					AdicionarVisita(visita);

					if (visita.Sa�da.HasValue)
						AtualizarVisita(visita);
				}
			}
			catch (Exception e)
			{
				try
				{
					Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
					MessageBox.Show("Ocorreu o seguinte erro carregando ListaVisitantes:\n\n" + e.ToString());
				}
				catch
				{
					MessageBox.Show("Ocorreu o seguinte erro carregando ListaVisitantes que n�o p�de ser registrado:\n\n" + e.ToString());
				}
			}
		}

        private delegate void AdicionarFuncCallback(Funcion�rio f, Visita[] a);

		/// <summary>
		/// Adiciona um funcion�rio � lista
		/// </summary>
		/// <param name="funcion�rio">Funcion�rio a ser inserido</param>
		private void AdicionarFuncion�rio(Funcion�rio funcion�rio)
		{
            Visita[] atendimentos = Visita.ObterAtendimentos(funcion�rio);
            ListViewItem item = new ListViewItem(funcion�rio.Nome);
            string strAtendimentos = Visita.ExtrairNomes(atendimentos);

            if (funcion�rio.Situa��o == EstadoFuncion�rio.Atendendo)
                if (atendimentos.Length == 0)
                    funcion�rio.Situa��o = EstadoFuncion�rio.Desconhecido; 
            
            item.SubItems.Add(funcion�rio.Ramal.ToString());
            item.SubItems.Add(funcion�rio.Setor == null ? "" : funcion�rio.Setor.Nome);
            item.SubItems.Add(funcion�rio.Situa��o == EstadoFuncion�rio.Dispon�vel ? "" : funcion�rio.Situa��o.ToString());

            item.SubItems.Add(strAtendimentos);
            lstVendedores.Items.Add(item);
            linhaVendedor[item] = funcion�rio;
            hashVendedorLinha[funcion�rio.C�digo] = item;
            ColorirFuncion�rio(item, funcion�rio);
        }

        private static string ExtrairNomes(Visita visita)
        {
            string strAtendimentos = "";

            foreach (Pessoa pessoa in visita.Pessoas)
            {
                if (strAtendimentos.Length > 0)
                    strAtendimentos += ", ";

                strAtendimentos += pessoa.Nome;
            }

            foreach (string nome in visita.Nomes)
            {
                if (strAtendimentos.Length > 0)
                    strAtendimentos += ", ";

                strAtendimentos += nome;
            }

            return strAtendimentos;
        }

        private static string ExtrairNomes(IEnumerable<Funcion�rio> funcion�rios)
        {
            string strAtendimentos = "";

            foreach (Funcion�rio pessoa in funcion�rios)
            {
                if (strAtendimentos.Length > 0)
                    strAtendimentos += ", ";

                strAtendimentos += pessoa.PrimeiroNome;
            }

            return strAtendimentos;
        }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("J� sairam", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Aguardando", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Em atendimento", System.Windows.Forms.HorizontalAlignment.Left);
            this.quadroVisitante = new Apresenta��o.Formul�rios.Quadro();
            this.lstVisitantes = new System.Windows.Forms.ListView();
            this.colVisitante = new System.Windows.Forms.ColumnHeader();
            this.colSetor = new System.Windows.Forms.ColumnHeader();
            this.colAtendente = new System.Windows.Forms.ColumnHeader();
            this.colEntrada = new System.Windows.Forms.ColumnHeader();
            this.colSa�da = new System.Windows.Forms.ColumnHeader();
            this.quadroVendedor = new Apresenta��o.Formul�rios.Quadro();
            this.lstVendedores = new System.Windows.Forms.ListView();
            this.colVendedor = new System.Windows.Forms.ColumnHeader();
            this.colRamal = new System.Windows.Forms.ColumnHeader();
            this.colVendedorSetor = new System.Windows.Forms.ColumnHeader();
            this.colSitua��o = new System.Windows.Forms.ColumnHeader();
            this.colCliente = new System.Windows.Forms.ColumnHeader();
            this.funcion�rioAus�ncia = new Programa.Recep��o.BaseInferior.Controles.Funcion�rioAus�ncia();
            this.tmrAtualizarFuncion�rios = new System.Windows.Forms.Timer(this.components);
            this.quadroVisitante.SuspendLayout();
            this.quadroVendedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // quadroVisitante
            // 
            this.quadroVisitante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroVisitante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(231)))), ((int)(((byte)(202)))));
            this.quadroVisitante.bInfDirArredondada = true;
            this.quadroVisitante.bInfEsqArredondada = true;
            this.quadroVisitante.bSupDirArredondada = true;
            this.quadroVisitante.bSupEsqArredondada = true;
            this.quadroVisitante.Controls.Add(this.lstVisitantes);
            this.quadroVisitante.Cor = System.Drawing.Color.Black;
            this.quadroVisitante.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVisitante.LetraT�tulo = System.Drawing.Color.White;
            this.quadroVisitante.Location = new System.Drawing.Point(8, 160);
            this.quadroVisitante.MostrarBot�oMinMax = false;
            this.quadroVisitante.Name = "quadroVisitante";
            this.quadroVisitante.Size = new System.Drawing.Size(576, 192);
            this.quadroVisitante.TabIndex = 0;
            this.quadroVisitante.Tamanho = 30;
            this.quadroVisitante.T�tulo = "Visitantes na Empresa";
            // 
            // lstVisitantes
            // 
            this.lstVisitantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVisitantes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVisitante,
            this.colSetor,
            this.colAtendente,
            this.colEntrada,
            this.colSa�da});
            this.lstVisitantes.FullRowSelect = true;
            listViewGroup1.Header = "J� sairam";
            listViewGroup1.Name = "lstGrpPassado";
            listViewGroup2.Header = "Aguardando";
            listViewGroup2.Name = "lstGrpAguardando";
            listViewGroup3.Header = "Em atendimento";
            listViewGroup3.Name = "lstGrpAtendimento";
            this.lstVisitantes.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lstVisitantes.Location = new System.Drawing.Point(8, 32);
            this.lstVisitantes.MultiSelect = false;
            this.lstVisitantes.Name = "lstVisitantes";
            this.lstVisitantes.Size = new System.Drawing.Size(560, 152);
            this.lstVisitantes.TabIndex = 4;
            this.lstVisitantes.UseCompatibleStateImageBehavior = false;
            this.lstVisitantes.View = System.Windows.Forms.View.Details;
            this.lstVisitantes.SelectedIndexChanged += new System.EventHandler(this.lstVisitantes_SelectedIndexChanged);
            this.lstVisitantes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstVisitantes_ColumnClick);
            this.lstVisitantes.Click += new System.EventHandler(this.lstVisitantes_Click);
            // 
            // colVisitante
            // 
            this.colVisitante.Text = "Visitante";
            this.colVisitante.Width = 200;
            // 
            // colSetor
            // 
            this.colSetor.Text = "Setor";
            this.colSetor.Width = 74;
            // 
            // colAtendente
            // 
            this.colAtendente.Text = "Atendente";
            this.colAtendente.Width = 81;
            // 
            // colEntrada
            // 
            this.colEntrada.Text = "Entrada";
            // 
            // colSa�da
            // 
            this.colSa�da.Text = "Sa�da";
            // 
            // quadroVendedor
            // 
            this.quadroVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.quadroVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(231)))), ((int)(((byte)(202)))));
            this.quadroVendedor.bInfDirArredondada = true;
            this.quadroVendedor.bInfEsqArredondada = true;
            this.quadroVendedor.bSupDirArredondada = true;
            this.quadroVendedor.bSupEsqArredondada = true;
            this.quadroVendedor.Controls.Add(this.lstVendedores);
            this.quadroVendedor.Cor = System.Drawing.Color.Black;
            this.quadroVendedor.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendedor.LetraT�tulo = System.Drawing.Color.White;
            this.quadroVendedor.Location = new System.Drawing.Point(8, 8);
            this.quadroVendedor.MostrarBot�oMinMax = false;
            this.quadroVendedor.Name = "quadroVendedor";
            this.quadroVendedor.Size = new System.Drawing.Size(368, 136);
            this.quadroVendedor.TabIndex = 1;
            this.quadroVendedor.Tamanho = 30;
            this.quadroVendedor.T�tulo = "Funcion�rios";
            // 
            // lstVendedores
            // 
            this.lstVendedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVendedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVendedor,
            this.colRamal,
            this.colVendedorSetor,
            this.colSitua��o,
            this.colCliente});
            this.lstVendedores.FullRowSelect = true;
            this.lstVendedores.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstVendedores.Location = new System.Drawing.Point(8, 32);
            this.lstVendedores.MultiSelect = false;
            this.lstVendedores.Name = "lstVendedores";
            this.lstVendedores.Size = new System.Drawing.Size(352, 96);
            this.lstVendedores.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstVendedores.TabIndex = 1;
            this.lstVendedores.UseCompatibleStateImageBehavior = false;
            this.lstVendedores.View = System.Windows.Forms.View.Details;
            this.lstVendedores.DoubleClick += new System.EventHandler(this.lstVendedores_DoubleClick);
            this.lstVendedores.SelectedIndexChanged += new System.EventHandler(this.lstVendedores_SelectedIndexChanged);
            this.lstVendedores.Click += new System.EventHandler(this.lstVendedores_Click);
            // 
            // colVendedor
            // 
            this.colVendedor.Text = "Funcion�rio";
            this.colVendedor.Width = 169;
            // 
            // colRamal
            // 
            this.colRamal.Text = "Ramal";
            this.colRamal.Width = 47;
            // 
            // colVendedorSetor
            // 
            this.colVendedorSetor.Text = "Setor";
            this.colVendedorSetor.Width = 90;
            // 
            // colSitua��o
            // 
            this.colSitua��o.Text = "Situa��o";
            this.colSitua��o.Width = 93;
            // 
            // colCliente
            // 
            this.colCliente.Text = "Cliente em atendimento";
            this.colCliente.Width = 140;
            // 
            // funcion�rioAus�ncia
            // 
            this.funcion�rioAus�ncia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.funcion�rioAus�ncia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.funcion�rioAus�ncia.bInfDirArredondada = true;
            this.funcion�rioAus�ncia.bInfEsqArredondada = true;
            this.funcion�rioAus�ncia.bSupDirArredondada = true;
            this.funcion�rioAus�ncia.bSupEsqArredondada = true;
            this.funcion�rioAus�ncia.Cor = System.Drawing.Color.Black;
            this.funcion�rioAus�ncia.FundoT�tulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.funcion�rioAus�ncia.LetraT�tulo = System.Drawing.Color.White;
            this.funcion�rioAus�ncia.Location = new System.Drawing.Point(392, 8);
            this.funcion�rioAus�ncia.MostrarBot�oMinMax = false;
            this.funcion�rioAus�ncia.Name = "funcion�rioAus�ncia";
            this.funcion�rioAus�ncia.Size = new System.Drawing.Size(192, 136);
            this.funcion�rioAus�ncia.TabIndex = 2;
            this.funcion�rioAus�ncia.Tamanho = 30;
            this.funcion�rioAus�ncia.T�tulo = "Funcion�rios Ausentes";
            this.funcion�rioAus�ncia.AoAlterarAus�ncia += new Programa.Recep��o.BaseInferior.Controles.Funcion�rioAus�ncia.AoAlterarAus�nciaCallback(this.funcion�rioAus�ncia_AoAlterarAus�ncia);
            // 
            // tmrAtualizarFuncion�rios
            // 
            this.tmrAtualizarFuncion�rios.Enabled = true;
            this.tmrAtualizarFuncion�rios.Interval = 300000;
            this.tmrAtualizarFuncion�rios.Tick += new System.EventHandler(this.tmrAtualizarFuncion�rios_Tick);
            // 
            // ListaVisitantes
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.funcion�rioAus�ncia);
            this.Controls.Add(this.quadroVendedor);
            this.Controls.Add(this.quadroVisitante);
            this.Name = "ListaVisitantes";
            this.Size = new System.Drawing.Size(600, 360);
            this.quadroVisitante.ResumeLayout(false);
            this.quadroVendedor.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public override object InitializeLifetimeService()
		{
			return null;
		}

		/*** Tratamento de eventos *************************************/

		#region Listas (ListBox)

		private void lstVisitantes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (lstVisitantes.SelectedItems.Count > 0)
                AoSelecionarVisitante(this, e);            
		}

		private void lstVendedores_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (lstVendedores.SelectedItems.Count > 0)
                AoSelecionarFuncion�rio(this, e);
		}

		private void lstVendedores_DoubleClick(object sender, System.EventArgs e)
		{
			if (DuploCliqueVendedores != null)
				DuploCliqueVendedores(this, e);
		}

		private void lstVendedores_Click(object sender, System.EventArgs e)
		{
			lstVisitantes.SelectedItems.Clear();
		}

		private void lstVisitantes_Click(object sender, System.EventArgs e)
		{
			lstVendedores.SelectedItems.Clear();
		}

        #endregion

        private delegate void AtualizarVisitaCallback(Visita visita);

        /// <summary>
		/// Atualiza o estado do visitante na lista de visitantes
		/// </summary>
        public void AtualizarVisita(Visita visita)
        {
            if (InvokeRequired)
            {
                AtualizarVisitaCallback m�todo = new AtualizarVisitaCallback(AtualizarVisita);
                BeginInvoke(m�todo, visita);
            }
            else
                try
                {
                    ListViewItem linha;

                    if (hashVisitaLinha.TryGetValue(Chave(visita.Entrada), out linha))
                    {
                        hashLinhaVisita[linha] = visita;
                        linha.Text = ExtrairNomes(visita);
                        linha.SubItems[colAtendente.Index].Text = visita.Atendente != null ? visita.Atendente.Nome : "";
                        if (!visita.Espera.HasValue && !visita.Sa�da.HasValue)
                            linha.Group = lstVisitantes.Groups["lstGrpAguardando"];

                        else if (!visita.Sa�da.HasValue)
                        {
                            if (visita.Atendente != null)
                            {
                                linha.Group = lstVisitantes.Groups["lstGrpAtendimento"];

                                ListViewItem itemFunc = hashVendedorLinha[visita.Atendente.C�digo];

                                itemFunc.SubItems[colCliente.Index].Text = ExtrairNomes(visita);
                                itemFunc.SubItems[colSitua��o.Index].Text = visita.Atendente.Situa��o.ToString();

                                ColorirFuncion�rio(itemFunc, visita.Atendente);
                            }
                        }
                        else
                        {
                            linha.Group = lstVisitantes.Groups["lstGrpPassado"];
                            linha.UseItemStyleForSubItems = true;
                            linha.ForeColor = SystemColors.GrayText;
                            linha.SubItems[colSa�da.Index].Text = visita.Sa�da.Value.ToLongTimeString();

                            if (visita.Atendente != null)
                                AtualizarFuncion�rio(visita.Atendente);
                        }
                    }
                }
                catch (Exception e)
                {
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                    MessageBox.Show(this, e.ToString());
                }
        }

		/// <summary>
		/// Trata evento de visitante que entrou na empresa
		/// </summary>
        public void AdicionarVisita(Visita visita)
        {
            if (InvokeRequired)
            {
                AtualizarVisitaCallback m�todo = new AtualizarVisitaCallback(AdicionarVisita);
                BeginInvoke(m�todo, visita);
            }
            else
                try
                {
                    ListViewItem item = new ListViewItem(ExtrairNomes(visita));

                    item.SubItems.Add(visita.Setor != null ? visita.Setor.Nome : "");

                    if (visita.Espera.HasValue)
                    {
                        item.SubItems.Add(visita.Atendente.Nome);
                        item.Group = lstVisitantes.Groups["lstGrpAtendimento"];
                    }
                    else
                    {
                        item.SubItems.Add("");
                        item.Group = lstVisitantes.Groups["lstGrpAguardando"];
                    }

                    item.SubItems.Add(visita.Entrada.ToLongTimeString());

                    if (visita.Sa�da.HasValue)
                    {
                        item.SubItems.Add(visita.Sa�da.Value.ToLongTimeString());
                        item.Group = lstVisitantes.Groups["lstGrpPassado"];
                    }
                    else
                        item.SubItems.Add("");

                    lstVisitantes.Items.Add(item);

                    // Adicionar na hashtable de linhas
                    hashLinhaVisita[item] = visita;

                    hashVisitaLinha[Chave(visita.Entrada)] = item;

                    // Garantir visibilidade
                    item.EnsureVisible();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
                }
        }

		/// <summary>
		/// Remove visitante
		/// </summary>
		private void RemoverVisita(Visita visita)
		{
			ListViewItem linha;

            // Encontrar linha da listview
            linha = hashVisitaLinha[Chave(visita.Entrada)];

            if (linha != null)
            {
                hashVisitaLinha.Remove(Chave(visita.Entrada));
                hashLinhaVisita.Remove(linha);

                // Verificar se existe outras linhas para esta visita
                linha.Remove();
            }

            AtualizarFuncion�rios();
		}

        private delegate void M�todoSimples();

		public void AtualizarFuncion�rios()
		{
            if (InvokeRequired)
            {
                M�todoSimples m�todo = new M�todoSimples(AtualizarFuncion�rios);
                BeginInvoke(m�todo);
            }
			try
			{
				foreach (ListViewItem linha in lstVendedores.Items)
                {
                    Funcion�rio funcion�rio = linhaVendedor[linha];

					// Atualizar lista de atendentes
					linha.SubItems[colSitua��o.Index].Text =
						funcion�rio.Situa��o == EstadoFuncion�rio.Dispon�vel ? "" : funcion�rio.Situa��o.ToString();

					ColorirFuncion�rio(linha, funcion�rio);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				Acesso.Comum.Usu�rios.Usu�rioAtual.RegistrarErro(e);
			}
		}

        private delegate void AtualizarFuncion�rioCallback(Funcion�rio funcion�rio);

        public void AtualizarFuncion�rio(Funcion�rio funcion�rio)
        {
            ListViewItem linha;

            if (InvokeRequired)
            {
                AtualizarFuncion�rioCallback m�todo = new AtualizarFuncion�rioCallback(AtualizarFuncion�rio);
                BeginInvoke(m�todo, funcion�rio);
            }
            else
                try
                {
                    linha = hashVendedorLinha[funcion�rio.C�digo];

                    linha.SubItems[colSitua��o.Index].Text =
                        funcion�rio.Situa��o == EstadoFuncion�rio.Dispon�vel ? "" : funcion�rio.Situa��o.ToString();

                    if (funcion�rio.Situa��o != EstadoFuncion�rio.Atendendo)
                        linha.SubItems[colCliente.Index].Text = "";

                    ColorirFuncion�rio(linha, funcion�rio);

                    if (!ignorarAus�ncia)
                    {
                        if (funcion�rio.Situa��o == EstadoFuncion�rio.Ausente)
                            funcion�rioAus�ncia.AdicionarFuncion�rio(funcion�rio);
                        else
                            funcion�rioAus�ncia.RemoverFuncion�rio(funcion�rio);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
        }

		/// <summary>
		/// Colorir o estado do funcion�rio
		/// </summary>
		/// <param name="linha"></param>
		/// <param name="Funcion�rio"></param>
		private void ColorirFuncion�rio(ListViewItem linha, Funcion�rio funcion�rio)
		{
			switch (funcion�rio.Situa��o)
			{
				case EstadoFuncion�rio.Dispon�vel:
					linha.ForeColor = lstVendedores.ForeColor;
					linha.UseItemStyleForSubItems = true;
					break;

                case EstadoFuncion�rio.Atendendo:
					linha.ForeColor = lstVendedores.ForeColor;
					linha.UseItemStyleForSubItems = false;
					linha.SubItems[colSitua��o.Index].ForeColor = Color.Blue;
					break;

                case EstadoFuncion�rio.Ausente:
					linha.ForeColor = SystemColors.GrayText;
					linha.UseItemStyleForSubItems = true;
					break;

                case EstadoFuncion�rio.Ocupado:
					linha.ForeColor = lstVendedores.ForeColor;
					linha.UseItemStyleForSubItems = false;
					linha.SubItems[colSitua��o.Index].ForeColor = Color.Red;
					break;
			}
		}

		#region Ordenando lstVisitantes

		/// <summary>
		/// Ocorre quando se clica no cabe�alho da coluna
		/// </summary>
		private void lstVisitantes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			lstVisitantes.ListViewItemSorter = new OrdenadorLstVisitantes(e.Column);
		}

		/// <summary>
		/// Ordena a lstVisitantes
		/// </summary>
		private class OrdenadorLstVisitantes : IComparer
		{
			int coluna;

			public OrdenadorLstVisitantes(int coluna)
			{
				this.coluna = coluna;
			}

			public int Compare(object x, object y)
			{
				ListViewItem a = (ListViewItem) x;
				ListViewItem b = (ListViewItem) y;
				TimeSpan ta, tb;
				int resultado;

				ta = tb = TimeSpan.MaxValue;

				switch (coluna)
				{
					case 0:		// Visitante
						resultado = string.Compare(a.Text, b.Text, true);
						break;

					case 4:		// Entrada
					case 5:		// Sa�da
						try
						{
							ta = TimeSpan.Parse(a.SubItems[coluna].Text);
							tb = TimeSpan.Parse(b.SubItems[coluna].Text);
						}
						catch {}
						
						resultado = TimeSpan.Compare(ta, tb);
						break;

					default:
						resultado = string.Compare(a.SubItems[coluna].Text, b.SubItems[coluna].Text);
						break;

				}

				if (resultado == 0)
				{
					try
					{
						ta = TimeSpan.Parse(a.SubItems[4].Text);
						tb = TimeSpan.Parse(b.SubItems[4].Text);
					}
					catch {}

					resultado = TimeSpan.Compare(ta, tb);
				}

				return resultado;
			}
		}

		#endregion

		#region IP�sCargaSistema Members

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
		public void AoCarregarCompletamente(Splash splash)
		{
			// Executar p�s-carga nos controles existentes.
			foreach (Control controle in Controls)
				if (controle is IP�sCargaSistema)
					((IP�sCargaSistema) controle).AoCarregarCompletamente(splash);

            Carregar();
		}

		#endregion

        private void tmrAtualizarFuncion�rios_Tick(object sender, EventArgs e)
        {
            AtualizarFuncion�rios();
        }

        private void funcion�rioAus�ncia_AoAlterarAus�ncia(Funcion�rio funcion�rio)
        {
            try
            {
                ignorarAus�ncia = true;
                AtualizarFuncion�rio(funcion�rio);
            }
            finally
            {
                ignorarAus�ncia = false;
            }
        }

        /// <summary>
        /// Reduz uma DateTime a sua representa��o DD/MM/YYYY HH:MM:SS
        /// Para utiliza��o como chave em tabelas hash.
        /// 
        /// Existem problemas quando vc usa o DateTime diretamente como chave
        /// uma vez que dois objetos podem ter o mesmo segundo, por�m o millisecond ser diferente.
        /// Isto j� aconteceu!!
        /// </summary>
        /// <param name="tempo"></param>
        /// <returns></returns>
        private string Chave(DateTime tempo)
        {
            return tempo.ToString();
        }
	}
}
