using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;
using Apresenta��o.Formul�rios;
using System.Collections;
using Entidades.Pessoa;

namespace Apresenta��o.Financeiro.Acerto
{
    public partial class BandejaAcerto : Apresenta��o.Mercadoria.Bandeja.Bandeja
    {
        //public event EventHandler AoTerminarAbrir;

        // Acerto fica registrado na bandeja
        private Entidades.Acerto.ControleAcertoMercadorias acerto;

        // Se apenas s�o exibidos itens com acerto != 0
        private bool filtragemAcerto = true;

        private ToolStripButton btnFiltrar;
        
        /// <summary>
        /// Constr�i a bandeja de acerto.
        /// </summary>
        public BandejaAcerto()
        {
            InitializeComponent();
            btnFiltrar = new ToolStripButton("Filtrar", Resource.Filter2HS);
            btnFiltrar.CheckOnClick = true;
            btnFiltrar.CheckedChanged += new EventHandler(btnFiltrar_CheckedChanged);
            btnFiltrar.Checked = filtragemAcerto;
            barraFerramentas.Items.Add(btnFiltrar);

            lista.Columns.Clear();

            this.lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRefer�ncia, 
            this.colQuantidade,
            this.colPeso,
            this.colSa�da,
            this.colRetorno,
            this.colVenda,
            this.colDevolu��o,
            this.colAcerto});
        }

        /// <summary>
        /// Ocorre ao clicar em filtrar.
        /// </summary>
        void btnFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            if (filtragemAcerto != btnFiltrar.Checked)
                FiltragemAcerto = btnFiltrar.Checked;
        }

        /// <summary>
        /// Acerto � obtido do banco de dados pelo m�todo Abrir().
        /// Fica aqui armazenado.
        /// </summary>
        public ControleAcertoMercadorias Acerto
        {
            get { return acerto; }
            set
            {
                if (acerto != null)
                    throw new NotSupportedException("Acerto s� pode ser definido uma �nica vez.");

                acerto = value;

                if (acerto != null && Representante.�Representante(acerto.Pessoa))
                    btnFiltrar.Checked = filtragemAcerto = true;
                else
                    btnFiltrar.Checked = filtragemAcerto = false;
            }
        }

        public bool FiltragemAcerto
        {
            get
            {
                return filtragemAcerto;
            }
            set
            {
                filtragemAcerto = value;

                if (btnFiltrar.Checked != value)
                    btnFiltrar.Checked = value;

                if (acerto != null)
                    PreencherBandeja();
            }
        }

        protected override void AtualizaElementoListView(Entidades.ISaquinho saquinho, ListViewItem item)
        {
            SaquinhoAcerto saquinhoAcerto = (SaquinhoAcerto)saquinho;

            // Redund�ncia para n�o recuperar a mercadoriaOca. O certo seria chamar o m�todo da base, que recupera grupo, faixa, etc
            item.SubItems[colRefer�ncia.Index].Text = saquinho.Mercadoria.Refer�ncia;
            item.SubItems[colQuantidade.Index].Text = saquinho.Quantidade.ToString();
            item.SubItems[colPeso.Index].Text = Entidades.Mercadoria.Mercadoria.FormatarPeso(saquinho.Peso);
            item.SubItems[colSa�da.Index].Text = saquinhoAcerto.QtdSa�da.ToString();
            item.SubItems[colRetorno.Index].Text = saquinhoAcerto.QtdRetorno.ToString();
            item.SubItems[colVenda.Index].Text = saquinhoAcerto.QtdVenda.ToString();
            item.SubItems[colAcerto.Index].Text = saquinhoAcerto.QtdAcerto.ToString();
            item.SubItems[colDevolu��o.Index].Text = saquinhoAcerto.QtdDevolvida.ToString();

            if (saquinhoAcerto.QtdAcerto > 0)
                item.Font = new Font(item.Font, FontStyle.Bold);
        }

        public void Abrir(ControleAcertoMercadorias acerto)
        {
            this.acerto = null;
            this.Acerto = acerto;
            PreencherBandeja();
        }

        private void PreencherBandeja()
        {
            // Insere novos dados
            //Visible = false;
            LimparLista();

            List<SaquinhoAcerto> saquinhos = acerto.Cole��oSaquinhos;

            if (filtragemAcerto)
            {
                ArrayList saquinhosParaIgnorar = new ArrayList();

                // Filtra os saquinhos com acerto != 0
                foreach (SaquinhoAcerto s in saquinhos)
                    if (s.QtdAcerto == 0)
                        saquinhosParaIgnorar.Add(s);

                // Ignora os saquinhos
                foreach (SaquinhoAcerto s in saquinhosParaIgnorar)
                    saquinhos.Remove(s);
             }
            
            AdicionarV�rios(new ArrayList(saquinhos));
            Visible = true;
        }

    }
}

