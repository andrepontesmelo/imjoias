using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using Entidades;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Consultas
{
    /// <summary>
    /// Mostra lista de vendedores.
    /// </summary>
    public class ListViewVendedores : System.Windows.Forms.UserControl, IComparer
    {
        // Atributos
        private List<Entidades.Pessoa.Pessoa> vendedores = null;
        private Dictionary<ListViewItem, Entidades.Pessoa.Pessoa> hashPessoas;
        private Dictionary<Setor, ListViewGroup> hashSetorGrupo;
        private int ordenaçãoColuna = 0;

        // Designer
        private System.Windows.Forms.ListView lstVendedores;
        public System.Windows.Forms.ColumnHeader colNome;
        public System.Windows.Forms.ColumnHeader colSetor;
        public System.Windows.Forms.ColumnHeader colRamal;
        private ImageList imageList;
        private IContainer components;

        public ListViewVendedores()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

            if (designMode)
                return;

            hashPessoas = new Dictionary<ListViewItem, Entidades.Pessoa.Pessoa>();

            lstVendedores.ListViewItemSorter = this;
            
            Setor[] setores = Setor.ObterSetores();
            hashSetorGrupo = new Dictionary<Setor, ListViewGroup>(setores.Length);
            foreach (Setor s in setores)
            {
                ListViewGroup grupo = new ListViewGroup(s.Nome);
                hashSetorGrupo.Add(s, grupo);
                lstVendedores.Groups.Add(grupo);
            }
        }

        /// <summary>
        /// Lista de vendedores
        /// </summary>
        public IEnumerable<Entidades.Pessoa.Pessoa> Vendedores
        {
            get
            {
                return vendedores;
            }
            set
            {
                if (this.DesignMode)
                    return;

                if (value == null)
                    return;

                if (vendedores != null)
                {
                    hashPessoas.Clear();
                    lstVendedores.Items.Clear();
                    imageList.Images.Clear();
                }

                vendedores = new List<Entidades.Pessoa.Pessoa>();

                foreach (Entidades.Pessoa.Pessoa pessoa in value)
                {
                    //if (pessoa is Funcionário)
                    //    AdicionarFuncionário((Funcionário)pessoa);
                    //else if (pessoa is Representante)
                    //    AdicionarRepresentante((Representante)pessoa);
                    //else
                    //    throw new NotSupportedException("Tipo de pessoa não suportada pela lista de vendedores.");

                    Adicionar(pessoa);
                }
            }
        }

        ///// <summary>
        ///// Adiciona funcionário à lista.
        ///// </summary>
        ///// <param name="funcionário">Funcionário a ser adicionado.</param>
        //private void AdicionarFuncionário(Funcionário funcionário)
        //{
        //    ListViewItem linha;

        //    // Inserir linha
        //    linha = new ListViewItem(funcionário.Nome);
        //    linha.SubItems.Add(funcionário.Ramal.ToString());
        //    linha.SubItems.Add(funcionário.Setor != null ?
        //        funcionário.Setor.Nome :
        //        "");

        //    lstVendedores.Items.Add(linha);
        //    linhas[funcionário.Código] = linha;
        //    linhas[linha] = funcionário;

        //    vendedores.Add(funcionário);
        //}

        private void Adicionar(Entidades.Pessoa.Pessoa pessoa)
        {
            ListViewItem linha;

            // Inserir linha
            linha = new ListViewItem(hashSetorGrupo[pessoa.Setor]);
            linha.Text = pessoa.Nome;
            Bitmap ícone = ControladorÍconePessoa.ObterÍcone(pessoa);
            imageList.Images.Add(ícone);
            linha.ImageIndex = imageList.Images.Count - 1;
            lstVendedores.Items.Add(linha);
            
            //vendedores.Add(pessoa);
            hashPessoas[linha] = pessoa;
        }

        ///// <summary>
        ///// Adiciona representante à lista.
        ///// </summary>
        ///// <param name="funcionário">Representante a ser adicionado.</param>
        //private void AdicionarRepresentante(Representante representante)
        //{
        //    ListViewItem linha;

        //    // Inserir linha
        //    linha = new ListViewItem(representante.Nome);
        //    linha.SubItems.Add("-");
        //    linha.SubItems.Add("Representante");
        //    lstVendedores.Items.Add(linha);
        //    linhas[representante.Código] = linha;
        //    linhas[linha] = representante;

        //    vendedores.Add(representante);
        //}

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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstVendedores = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRamal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSetor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lstVendedores
            // 
            this.lstVendedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colRamal,
            this.colSetor});
            this.lstVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVendedores.FullRowSelect = true;
            this.lstVendedores.HideSelection = false;
            this.lstVendedores.LargeImageList = this.imageList;
            this.lstVendedores.Location = new System.Drawing.Point(0, 0);
            this.lstVendedores.MultiSelect = false;
            this.lstVendedores.Name = "lstVendedores";
            this.lstVendedores.Size = new System.Drawing.Size(336, 96);
            this.lstVendedores.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstVendedores.TabIndex = 1;
            this.lstVendedores.UseCompatibleStateImageBehavior = false;
            this.lstVendedores.View = System.Windows.Forms.View.Details;
            this.lstVendedores.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LstColumnClick);
            this.lstVendedores.SelectedIndexChanged += new System.EventHandler(this.LstSelectedIndexChanged);
            this.lstVendedores.DoubleClick += new System.EventHandler(this.LstDoubleClick);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 178;
            // 
            // colRamal
            // 
            this.colRamal.Text = "Ramal";
            this.colRamal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRamal.Width = 53;
            // 
            // colSetor
            // 
            this.colSetor.Text = "Setor";
            this.colSetor.Width = 86;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ListViewVendedores
            // 
            this.Controls.Add(this.lstVendedores);
            this.Name = "ListViewVendedores";
            this.Size = new System.Drawing.Size(336, 96);
            this.VisibleChanged += new System.EventHandler(this.ListViewVendedores_VisibleChanged);
            this.ResumeLayout(false);

        }
        #endregion

        public event EventHandler SelectedIndexChanged;

        private void LstSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
        }

        private void LstDoubleClick(object sender, System.EventArgs e)
        {
            this.OnDoubleClick(e);
        }

        public Entidades.Pessoa.Pessoa VendedorSelecionado
        {
            get
            {
                if (lstVendedores.SelectedItems.Count != 1)
                    return null;

                return hashPessoas[lstVendedores.SelectedItems[0]];
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        /// <summary>
        /// Procura um vendedor cujo nome se inicia
        /// com um especificado.
        /// </summary>
        /// <param name="nome">Prefixo do nome a ser
        /// procurado nos funcionários</param>
        public void Procurar(string nome)
        {
            foreach (ListViewItem linha in lstVendedores.Items)
            {
                if (string.Compare(linha.Text, 0, nome, 0, nome.Length, true) == 0)
                {
                    linha.Selected = true;
                    linha.Focused = true;
                    linha.EnsureVisible();
                    return;
                }
            }
        }

        private void LstColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (ordenaçãoColuna == e.Column)
            {
                if (lstVendedores.Sorting == SortOrder.Descending)
                    lstVendedores.Sorting = SortOrder.Ascending;
                else
                    lstVendedores.Sorting = SortOrder.Descending;
            }
            else
            {
                ordenaçãoColuna = e.Column;
                lstVendedores.Sorting = SortOrder.Ascending;
            }

            lstVendedores.Sort();
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            return ((ListViewItem)x).SubItems[ordenaçãoColuna].Text.CompareTo(((ListViewItem)y).SubItems[ordenaçãoColuna].Text);
        }

        #endregion

        /// <summary>
        /// Ocorre quando a lista muda sua visibilidade
        /// </summary>
        private void ListViewVendedores_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible && lstVendedores.SelectedItems.Count > 0)
                lstVendedores.SelectedItems[0].EnsureVisible();
        }
    }
}
