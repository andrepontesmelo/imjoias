using Entidades;
using Entidades.Pessoa;

using Programa.Recepção.Formulários.EntradaSaída;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Entidades.Configuração;
using System.Threading;
using Apresentação.Formulários;

namespace Programa.Recepção.BaseInferior.Controles
{
	/// <summary>
	/// Lista de visitantes.
	/// </summary>
    /// <remarks>
    /// O implementador deverá tratar os eventos AoSelecionarFuncionário,
    /// AoSelecionarVisitante, obrigatoriamente. Ainda, deverá utilizar os
    /// métodos AdicionarVisita e AtualizarVisita.
    /// </remarks>
	sealed class ListaVisitantes : System.Windows.Forms.UserControl, Apresentação.Formulários.IPósCargaSistema
	{
		public delegate void DuploClique();

		// Eventos
        public event EventHandler               AoSelecionarFuncionário;
        public event EventHandler               AoSelecionarVisitante;
		public event EventHandler				DuploCliqueVendedores;

		// Atributos
        private Dictionary<ListViewItem, Funcionário> linhaVendedor = new Dictionary<ListViewItem, Funcionário>();
        private Dictionary<ulong, ListViewItem> hashVendedorLinha = new Dictionary<ulong, ListViewItem>();
        private Dictionary<string, ListViewItem> hashVisitaLinha = new Dictionary<string, ListViewItem>(StringComparer.Ordinal);
        private Dictionary<ListViewItem, Visita> hashLinhaVisita = new Dictionary<ListViewItem, Visita>();
        private bool ignorarAusência = false;

		// Atributos do design
		private System.Windows.Forms.ListView lstVisitantes;
		private System.Windows.Forms.ColumnHeader colVisitante;
		private System.Windows.Forms.ColumnHeader colSetor;
		private System.Windows.Forms.ColumnHeader colAtendente;
		private System.Windows.Forms.ColumnHeader colEntrada;
		private System.Windows.Forms.ColumnHeader colSaída;
		private Apresentação.Formulários.Quadro quadroVisitante;
		private Apresentação.Formulários.Quadro quadroVendedor;
		private System.Windows.Forms.ListView lstVendedores;
		private System.Windows.Forms.ColumnHeader colVendedor;
		private System.Windows.Forms.ColumnHeader colSituação;
		private System.Windows.Forms.ColumnHeader colCliente;
		private System.Windows.Forms.ColumnHeader colRamal;
		private System.Windows.Forms.ColumnHeader colVendedorSetor;
        private Programa.Recepção.BaseInferior.Controles.FuncionárioAusência funcionárioAusência;
        private System.Windows.Forms.Timer tmrAtualizarFuncionários;
        private IContainer components;

		public ListaVisitantes()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

        public Funcionário FuncionárioSelecionado
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
                Funcionário[] atendentes = Funcionário.ObterFuncionários(true, false);

                foreach (Funcionário funcionário in atendentes)
                    AdicionarFuncionário(funcionário);
                
                // Inserir visitantes
                Visita[] visitas = Visita.ObterVisitasRelevantes();

				foreach (Visita visita in visitas)
				{
					AdicionarVisita(visita);

					if (visita.Saída.HasValue)
						AtualizarVisita(visita);
				}
			}
			catch (Exception e)
			{
				try
				{
					Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
					MessageBox.Show("Ocorreu o seguinte erro carregando ListaVisitantes:\n\n" + e.ToString());
				}
				catch
				{
					MessageBox.Show("Ocorreu o seguinte erro carregando ListaVisitantes que não pôde ser registrado:\n\n" + e.ToString());
				}
			}
		}

        private delegate void AdicionarFuncCallback(Funcionário f, Visita[] a);

		/// <summary>
		/// Adiciona um funcionário à lista
		/// </summary>
		/// <param name="funcionário">Funcionário a ser inserido</param>
		private void AdicionarFuncionário(Funcionário funcionário)
		{
            Visita[] atendimentos = Visita.ObterAtendimentos(funcionário);
            ListViewItem item = new ListViewItem(funcionário.Nome);
            string strAtendimentos = Visita.ExtrairNomes(atendimentos);

            if (funcionário.Situação == EstadoFuncionário.Atendendo)
                if (atendimentos.Length == 0)
                    funcionário.Situação = EstadoFuncionário.Desconhecido; 
            
            item.SubItems.Add(funcionário.Ramal.ToString());
            item.SubItems.Add(funcionário.Setor == null ? "" : funcionário.Setor.Nome);
            item.SubItems.Add(funcionário.Situação == EstadoFuncionário.Disponível ? "" : funcionário.Situação.ToString());

            item.SubItems.Add(strAtendimentos);
            lstVendedores.Items.Add(item);
            linhaVendedor[item] = funcionário;
            hashVendedorLinha[funcionário.Código] = item;
            ColorirFuncionário(item, funcionário);
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

        private static string ExtrairNomes(IEnumerable<Funcionário> funcionários)
        {
            string strAtendimentos = "";

            foreach (Funcionário pessoa in funcionários)
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Já sairam", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Aguardando", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Em atendimento", System.Windows.Forms.HorizontalAlignment.Left);
            this.quadroVisitante = new Apresentação.Formulários.Quadro();
            this.lstVisitantes = new System.Windows.Forms.ListView();
            this.colVisitante = new System.Windows.Forms.ColumnHeader();
            this.colSetor = new System.Windows.Forms.ColumnHeader();
            this.colAtendente = new System.Windows.Forms.ColumnHeader();
            this.colEntrada = new System.Windows.Forms.ColumnHeader();
            this.colSaída = new System.Windows.Forms.ColumnHeader();
            this.quadroVendedor = new Apresentação.Formulários.Quadro();
            this.lstVendedores = new System.Windows.Forms.ListView();
            this.colVendedor = new System.Windows.Forms.ColumnHeader();
            this.colRamal = new System.Windows.Forms.ColumnHeader();
            this.colVendedorSetor = new System.Windows.Forms.ColumnHeader();
            this.colSituação = new System.Windows.Forms.ColumnHeader();
            this.colCliente = new System.Windows.Forms.ColumnHeader();
            this.funcionárioAusência = new Programa.Recepção.BaseInferior.Controles.FuncionárioAusência();
            this.tmrAtualizarFuncionários = new System.Windows.Forms.Timer(this.components);
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
            this.quadroVisitante.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVisitante.LetraTítulo = System.Drawing.Color.White;
            this.quadroVisitante.Location = new System.Drawing.Point(8, 160);
            this.quadroVisitante.MostrarBotãoMinMax = false;
            this.quadroVisitante.Name = "quadroVisitante";
            this.quadroVisitante.Size = new System.Drawing.Size(576, 192);
            this.quadroVisitante.TabIndex = 0;
            this.quadroVisitante.Tamanho = 30;
            this.quadroVisitante.Título = "Visitantes na Empresa";
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
            this.colSaída});
            this.lstVisitantes.FullRowSelect = true;
            listViewGroup1.Header = "Já sairam";
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
            // colSaída
            // 
            this.colSaída.Text = "Saída";
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
            this.quadroVendedor.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.quadroVendedor.LetraTítulo = System.Drawing.Color.White;
            this.quadroVendedor.Location = new System.Drawing.Point(8, 8);
            this.quadroVendedor.MostrarBotãoMinMax = false;
            this.quadroVendedor.Name = "quadroVendedor";
            this.quadroVendedor.Size = new System.Drawing.Size(368, 136);
            this.quadroVendedor.TabIndex = 1;
            this.quadroVendedor.Tamanho = 30;
            this.quadroVendedor.Título = "Funcionários";
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
            this.colSituação,
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
            this.colVendedor.Text = "Funcionário";
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
            // colSituação
            // 
            this.colSituação.Text = "Situação";
            this.colSituação.Width = 93;
            // 
            // colCliente
            // 
            this.colCliente.Text = "Cliente em atendimento";
            this.colCliente.Width = 140;
            // 
            // funcionárioAusência
            // 
            this.funcionárioAusência.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionárioAusência.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(221)))));
            this.funcionárioAusência.bInfDirArredondada = true;
            this.funcionárioAusência.bInfEsqArredondada = true;
            this.funcionárioAusência.bSupDirArredondada = true;
            this.funcionárioAusência.bSupEsqArredondada = true;
            this.funcionárioAusência.Cor = System.Drawing.Color.Black;
            this.funcionárioAusência.FundoTítulo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(97)))));
            this.funcionárioAusência.LetraTítulo = System.Drawing.Color.White;
            this.funcionárioAusência.Location = new System.Drawing.Point(392, 8);
            this.funcionárioAusência.MostrarBotãoMinMax = false;
            this.funcionárioAusência.Name = "funcionárioAusência";
            this.funcionárioAusência.Size = new System.Drawing.Size(192, 136);
            this.funcionárioAusência.TabIndex = 2;
            this.funcionárioAusência.Tamanho = 30;
            this.funcionárioAusência.Título = "Funcionários Ausentes";
            this.funcionárioAusência.AoAlterarAusência += new Programa.Recepção.BaseInferior.Controles.FuncionárioAusência.AoAlterarAusênciaCallback(this.funcionárioAusência_AoAlterarAusência);
            // 
            // tmrAtualizarFuncionários
            // 
            this.tmrAtualizarFuncionários.Enabled = true;
            this.tmrAtualizarFuncionários.Interval = 300000;
            this.tmrAtualizarFuncionários.Tick += new System.EventHandler(this.tmrAtualizarFuncionários_Tick);
            // 
            // ListaVisitantes
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.funcionárioAusência);
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
                AoSelecionarFuncionário(this, e);
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
                AtualizarVisitaCallback método = new AtualizarVisitaCallback(AtualizarVisita);
                BeginInvoke(método, visita);
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
                        if (!visita.Espera.HasValue && !visita.Saída.HasValue)
                            linha.Group = lstVisitantes.Groups["lstGrpAguardando"];

                        else if (!visita.Saída.HasValue)
                        {
                            if (visita.Atendente != null)
                            {
                                linha.Group = lstVisitantes.Groups["lstGrpAtendimento"];

                                ListViewItem itemFunc = hashVendedorLinha[visita.Atendente.Código];

                                itemFunc.SubItems[colCliente.Index].Text = ExtrairNomes(visita);
                                itemFunc.SubItems[colSituação.Index].Text = visita.Atendente.Situação.ToString();

                                ColorirFuncionário(itemFunc, visita.Atendente);
                            }
                        }
                        else
                        {
                            linha.Group = lstVisitantes.Groups["lstGrpPassado"];
                            linha.UseItemStyleForSubItems = true;
                            linha.ForeColor = SystemColors.GrayText;
                            linha.SubItems[colSaída.Index].Text = visita.Saída.Value.ToLongTimeString();

                            if (visita.Atendente != null)
                                AtualizarFuncionário(visita.Atendente);
                        }
                    }
                }
                catch (Exception e)
                {
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
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
                AtualizarVisitaCallback método = new AtualizarVisitaCallback(AdicionarVisita);
                BeginInvoke(método, visita);
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

                    if (visita.Saída.HasValue)
                    {
                        item.SubItems.Add(visita.Saída.Value.ToLongTimeString());
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
                    Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
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

            AtualizarFuncionários();
		}

        private delegate void MétodoSimples();

		public void AtualizarFuncionários()
		{
            if (InvokeRequired)
            {
                MétodoSimples método = new MétodoSimples(AtualizarFuncionários);
                BeginInvoke(método);
            }
			try
			{
				foreach (ListViewItem linha in lstVendedores.Items)
                {
                    Funcionário funcionário = linhaVendedor[linha];

					// Atualizar lista de atendentes
					linha.SubItems[colSituação.Index].Text =
						funcionário.Situação == EstadoFuncionário.Disponível ? "" : funcionário.Situação.ToString();

					ColorirFuncionário(linha, funcionário);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				Acesso.Comum.Usuários.UsuárioAtual.RegistrarErro(e);
			}
		}

        private delegate void AtualizarFuncionárioCallback(Funcionário funcionário);

        public void AtualizarFuncionário(Funcionário funcionário)
        {
            ListViewItem linha;

            if (InvokeRequired)
            {
                AtualizarFuncionárioCallback método = new AtualizarFuncionárioCallback(AtualizarFuncionário);
                BeginInvoke(método, funcionário);
            }
            else
                try
                {
                    linha = hashVendedorLinha[funcionário.Código];

                    linha.SubItems[colSituação.Index].Text =
                        funcionário.Situação == EstadoFuncionário.Disponível ? "" : funcionário.Situação.ToString();

                    if (funcionário.Situação != EstadoFuncionário.Atendendo)
                        linha.SubItems[colCliente.Index].Text = "";

                    ColorirFuncionário(linha, funcionário);

                    if (!ignorarAusência)
                    {
                        if (funcionário.Situação == EstadoFuncionário.Ausente)
                            funcionárioAusência.AdicionarFuncionário(funcionário);
                        else
                            funcionárioAusência.RemoverFuncionário(funcionário);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
        }

		/// <summary>
		/// Colorir o estado do funcionário
		/// </summary>
		/// <param name="linha"></param>
		/// <param name="Funcionário"></param>
		private void ColorirFuncionário(ListViewItem linha, Funcionário funcionário)
		{
			switch (funcionário.Situação)
			{
				case EstadoFuncionário.Disponível:
					linha.ForeColor = lstVendedores.ForeColor;
					linha.UseItemStyleForSubItems = true;
					break;

                case EstadoFuncionário.Atendendo:
					linha.ForeColor = lstVendedores.ForeColor;
					linha.UseItemStyleForSubItems = false;
					linha.SubItems[colSituação.Index].ForeColor = Color.Blue;
					break;

                case EstadoFuncionário.Ausente:
					linha.ForeColor = SystemColors.GrayText;
					linha.UseItemStyleForSubItems = true;
					break;

                case EstadoFuncionário.Ocupado:
					linha.ForeColor = lstVendedores.ForeColor;
					linha.UseItemStyleForSubItems = false;
					linha.SubItems[colSituação.Index].ForeColor = Color.Red;
					break;
			}
		}

		#region Ordenando lstVisitantes

		/// <summary>
		/// Ocorre quando se clica no cabeçalho da coluna
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
					case 5:		// Saída
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

		#region IPósCargaSistema Members

		/// <summary>
		/// Ocorre ao carregar completamente o sistema.
		/// </summary>
		public void AoCarregarCompletamente(Splash splash)
		{
			// Executar pós-carga nos controles existentes.
			foreach (Control controle in Controls)
				if (controle is IPósCargaSistema)
					((IPósCargaSistema) controle).AoCarregarCompletamente(splash);

            Carregar();
		}

		#endregion

        private void tmrAtualizarFuncionários_Tick(object sender, EventArgs e)
        {
            AtualizarFuncionários();
        }

        private void funcionárioAusência_AoAlterarAusência(Funcionário funcionário)
        {
            try
            {
                ignorarAusência = true;
                AtualizarFuncionário(funcionário);
            }
            finally
            {
                ignorarAusência = false;
            }
        }

        /// <summary>
        /// Reduz uma DateTime a sua representação DD/MM/YYYY HH:MM:SS
        /// Para utilização como chave em tabelas hash.
        /// 
        /// Existem problemas quando vc usa o DateTime diretamente como chave
        /// uma vez que dois objetos podem ter o mesmo segundo, porém o millisecond ser diferente.
        /// Isto já aconteceu!!
        /// </summary>
        /// <param name="tempo"></param>
        /// <returns></returns>
        private string Chave(DateTime tempo)
        {
            return tempo.ToString();
        }
	}
}
