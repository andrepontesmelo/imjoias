using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;
using Apresentação.Formulários;
using System.Collections;
using Entidades.Pessoa;

namespace Apresentação.Financeiro.Acerto
{
    public partial class BandejaAcerto : Apresentação.Mercadoria.Bandeja.Bandeja
    {
        //public event EventHandler AoTerminarAbrir;

        // Acerto fica registrado na bandeja
        private Entidades.Acerto.ControleAcertoMercadorias acerto;

        // Se apenas são exibidos itens com acerto != 0
        private bool filtragemAcerto = true;

        private ToolStripButton btnFiltrar;
        
        /// <summary>
        /// Constrói a bandeja de acerto.
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
            this.colReferência, 
            this.colQuantidade,
            this.colPeso,
            this.colSaída,
            this.colRetorno,
            this.colVenda,
            this.colDevolução,
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
        /// Acerto é obtido do banco de dados pelo método Abrir().
        /// Fica aqui armazenado.
        /// </summary>
        public ControleAcertoMercadorias Acerto
        {
            get { return acerto; }
            set
            {
                if (acerto != null)
                    throw new NotSupportedException("Acerto só pode ser definido uma única vez.");

                acerto = value;

                if (acerto != null && Representante.ÉRepresentante(acerto.Pessoa))
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

            // Redundância para não recuperar a mercadoriaOca. O certo seria chamar o método da base, que recupera grupo, faixa, etc
            item.SubItems[colReferência.Index].Text = saquinho.Mercadoria.Referência;
            item.SubItems[colQuantidade.Index].Text = saquinho.Quantidade.ToString();
            item.SubItems[colPeso.Index].Text = Entidades.Mercadoria.Mercadoria.FormatarPeso(saquinho.Peso);
            item.SubItems[colSaída.Index].Text = saquinhoAcerto.QtdSaída.ToString();
            item.SubItems[colRetorno.Index].Text = saquinhoAcerto.QtdRetorno.ToString();
            item.SubItems[colVenda.Index].Text = saquinhoAcerto.QtdVenda.ToString();
            item.SubItems[colAcerto.Index].Text = saquinhoAcerto.QtdAcerto.ToString();
            item.SubItems[colDevolução.Index].Text = saquinhoAcerto.QtdDevolvida.ToString();

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

            List<SaquinhoAcerto> saquinhos = acerto.ColeçãoSaquinhos;

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
            
            AdicionarVários(new ArrayList(saquinhos));
            Visible = true;
        }

    }
}

