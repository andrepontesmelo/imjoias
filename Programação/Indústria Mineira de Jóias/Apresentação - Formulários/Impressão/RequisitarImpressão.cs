using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Impressão.Cliente;
using Apresentação.Impressão;

namespace Apresentação.Formulários.Impressão
{
    /// <summary>
    /// Mostra o usuário as opções de impressoras disponíveis.
    /// </summary>
    /// <remarks>
    /// O controle de impressão é construído pelo formulário
    /// e DEVE ser utilizado pelo implementador para imprimir
    /// na impressora escolhida pelo usuário.
    /// </remarks>
    public partial class RequisitarImpressão : JanelaExplicativa
    {
        private const float notaPerfeito = 1f;
        private const float notaBom = 0.5f;

        private ControleImpressão controle;
        private SinalizaçãoCarga sinalização;
        private TipoDocumento tipo;

        private Dictionary<string, ListViewItem> hashCandidato = new Dictionary<string, ListViewItem>();

        /// <summary>
        /// Determina o último movimento do mouse sobre a ListView.
        /// </summary>
        private DateTime últimoMovimento = DateTime.MinValue;

        /// <summary>
        /// Tempo que o mouse deve permanecer sem mexer dentro
        /// da ListView para que a ordenação da lista seja feita.
        /// </summary>
        private const int limiarMovimento = 5;



        public RequisitarImpressão(Apresentação.Impressão.TipoDocumento tipo)
        {
            InitializeComponent();

            this.tipo = tipo;
        }

        /// <summary>
        /// Controle de impressão a ser utilizado.
        /// </summary>
        public ControleImpressão ControleImpressão
        {
            get { return controle; }
        }

        /// <summary>
        /// Impressora escolhida.
        /// </summary>
        public DadosCandidatura Impressora
        {
            get { return (DadosCandidatura)lstImpressoras.SelectedItems[0].Tag; }
        }

        /// <summary>
        /// Obtem número de cópias entrado pelo usuário
        /// </summary>
        public int NúmeroCópias
        {
            get
            {
                try
                {
                    return Math.Abs(int.Parse(txtNúmeroCópias.Text)) == 0 ? 1 : Math.Abs(int.Parse(txtNúmeroCópias.Text));
                }
                catch (Exception)
                {
                }

                return 1;
            }
        }

        /// <summary>
        /// Define se a interface deve permitir que o usuário
        /// escolha a página.
        /// </summary>
        public bool PermitirEscolherPágina
        {
            get { return lblImprimirPaginasDe.Enabled; }
            set
            {
                if (value != lblImprimirPaginasDe.Enabled)
                {
                    lblImprimirPaginasDe.Enabled
                        = txtA.Enabled
                        = txtInício.Enabled
                        = txtFinal.Enabled = value;
                }
            }
        }

        public int PáginaInicial
        {
            get
            {
                int página;

                if (int.TryParse(txtInício.Text, out página))
                    return página;
                else
                    return 1;
            }
        }

        public int PáginaFinal
        {
            get
            {
                int página;

                if (int.TryParse(txtFinal.Text, out página))
                    return página;
                else
                    return int.MaxValue;
            }
        }

        /// <summary>
        /// Ocorre quando o temporizador dispara para que a janela
        /// verifique novos candidatos de impressão.
        /// </summary>
        private void tmrRecuperarCandidatos_Tick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler método = new EventHandler(this.tmrRecuperarCandidatos_Tick);
                BeginInvoke(método, sender, e);
            }
            else if (controle != null && Visible)
            {
                List<DadosCandidatura> candidatos = controle.Candidatos;
                List<ListViewItem> remoção = new List<ListViewItem>();

                lock (lstImpressoras)
                {
                    foreach (DadosCandidatura candidato in candidatos)
                    {
                        if (hashCandidato.ContainsKey(candidato.Chave))
                            AtualizarListView(hashCandidato[candidato.Chave], candidato);
                        else
                            hashCandidato[candidato.Chave] = AdicionarListView(candidato);
                    }

                    foreach (ListViewItem item in lstImpressoras.Items)
                        if (!candidatos.Contains((DadosCandidatura)item.Tag))
                            remoção.Add(item);

                    foreach (ListViewItem item in remoção)
                    {
                        hashCandidato.Remove(((DadosCandidatura)item.Tag).Chave);
                        lstImpressoras.Items.Remove(item);
                    }
                }

                /* A ordenação da lista só será feita se o usuário permanecer
                 * sem movimentar o mouse durante os segundos estipulados
                 * na constante da classe. Assim, evita a dificuldade de
                 * seleção da impressora desejada quando existem máquinas
                 * com disponibilidade volátil de recursos.
                 */
                TimeSpan dif = DateTime.Now - últimoMovimento;

                if (dif.TotalSeconds >= limiarMovimento && !Focused)
                {
                    try
                    {
                        lock (lstImpressoras)
                            lstImpressoras.Sort();
                    }
                    catch { }
                    btnOrdenar.Visible = false;
                }
                else if (btnOrdenar.Visible == false)
                    btnOrdenar.Visible = true;

                if (sinalização != null && candidatos.Count > 0)
                {
                    if (btnOrdenar.Visible)
                    {
                        try
                        {
                            lock (lstImpressoras)
                                lstImpressoras.Sort();
                        }
                        catch { }
                        btnOrdenar.Visible = false;
                    }
                    SinalizaçãoCarga.Dessinalizar(sinalização);
                    sinalização = null;
                }
            }
        }

        private ListViewItem AdicionarListView(DadosCandidatura candidato)
        {
            ListViewItem item = new ListViewItem();
            item.Text = candidato.Impressora;
            item.SubItems.Add(candidato.Máquina);
            //item.SubItems.Add(string.Format("{0:##0.00}", candidato.Nota.ToString()));

            if (candidato.Nota >= notaPerfeito)
            {
                item.ImageKey = "Perfeito";
                item.Group = lstImpressoras.Groups["grpDisponível"];
            }
            else if (candidato.Nota >= notaBom)
            {
                item.ImageKey = "Bom";
                item.Group = lstImpressoras.Groups["grpLeve"];
            }
            else
            {
                item.ImageKey = "Ruim";
                item.Group = lstImpressoras.Groups["grpPesado"];
            }

            item.Tag = candidato;

            lock (lstImpressoras)
                lstImpressoras.Items.Add(item);

            return item;
        }

        private void AtualizarListView(ListViewItem item, DadosCandidatura candidato)
        {
            //item.Text = candidato.Impressora;
            //item.SubItems[1].Text = candidato.Máquina;
            //item.SubItems[2].Text = string.Format("{0:##0.00}", candidato.Nota.ToString());

            if (candidato.Nota >= notaPerfeito)
            {
                if (item.ImageKey != "Perfeito")
                {
                    item.ImageKey = "Perfeito";
                    item.Group = lstImpressoras.Groups["grpDisponível"];
                }
            }
            else if (candidato.Nota >= notaBom)
            {
                if (item.ImageKey != "Bom")
                {
                    item.ImageKey = "Bom";
                    item.Group = lstImpressoras.Groups["grpLeve"];
                }
            }
            else
            {
                if (item.ImageKey != "Ruim")
                {
                    item.ImageKey = "Ruim";
                    item.Group = lstImpressoras.Groups["grpPesado"];
                }
            }

            item.Tag = candidato;
        }

        private void lstImpressoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lstImpressoras.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Ocorre ao mostrar a janela.
        /// </summary>
        private void RequisitarImpressão_Shown(object sender, EventArgs e)
        {
            controle = new ControleImpressão(tipo);
        }

        /// <summary>
        /// Ocorer quando usuário escolhe impressora e clica em OK.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Impressora.Nota < notaBom)
                if (MessageBox.Show(this,
                    "A máquina escolhida foi má avaliada em relação à disponibilidade de recursos para realizar uma impressão rápida. Deseja continuar assim mesmo?",
                    "Impressão remota",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

            DialogResult = DialogResult.OK;
            Close();
        }


        /// <summary>
        /// Ocorre quando usuário requisita cancelamento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controle.Dispose();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Ocorre quando usuário movimenta o mouse sobre a lista
        /// de impressoras. O momento é armazenado para decidir
        /// se o temporizador de candidatura deve ordenar ou não
        /// a ListView.
        /// </summary>
        private void lstImpressoras_Move(object sender, EventArgs e)
        {
            últimoMovimento = DateTime.Now;
        }

        /// <summary>
        /// Ocorre quando usuário clica em ordenar.
        /// </summary>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            btnOrdenar.Visible = false;

            lock (lstImpressoras)
                lstImpressoras.Sort();
        }

        private void lnkImprimirRemotamente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controle.Remoto = true;
            lnkImprimirRemotamente.Visible = false;

            sinalização = SinalizaçãoCarga.Sinalizar(lstImpressoras, "Procurando impressoras", "Aguarde enquanto o sistema procura por impressoras na rede.");
        }

        private void txtNúmeroCópias_Validating(object sender, CancelEventArgs e)
        {
            txtNúmeroCópias.Text = NúmeroCópias.ToString();
        }



        private void btnMaisCópias_Click(object sender, EventArgs e)
        {
            txtNúmeroCópias.Text = ((int)(NúmeroCópias + 1)).ToString();
        }

        private void lnkMaisOpções_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            painelMaisOpções.Visible = true;
            lnkMaisOpções.Visible = false;
        }
    }
}