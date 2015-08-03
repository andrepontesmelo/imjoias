using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Apresentação.Pessoa.Horário
{
    /// <summary>
    /// Permite a edição de um horário por parte do usuário.
    /// </summary>
    partial class Horário : UserControl
    {
        private int origemY;
        private double topo, altura;

        /// <summary>
        /// Hora mínima exibida.
        /// </summary>
        private ushort minHora = 07;
        
        /// <summary>
        /// Pixel por hora.
        /// </summary>
        private double pph;

        /// <summary>
        /// Determina se deve permitir edição, sendo
        /// utilizado apenas internamente para verificar
        /// se o usuário moveu o horário ou se clicou para
        /// edição.
        /// </summary>
        private bool permitirEdição = true;

        #region Propriedades

        /// <summary>
        /// Determina se o controle pode ser editado.
        /// </summary>
        public bool PermitirEdição
        {
            get { return permitirEdição; }
        }

        private new double Top
        {
            get { return topo; }
            set
            {
                topo = value;
                base.Top = (int)Math.Round(topo);
            }
        }

        private new double Height
        {
            get { return altura; }
            set
            {
                altura = value;
                base.Height = (int)Math.Round(value);
            }
        }

        public ushort HoraMínima
        {
            get { return minHora; }
            set
            {
                Top = (int)((InícioHora - HoraMínima) * pph);
                minHora = value;
            }
        }

        /// <summary>
        /// Pixel por hora.
        /// </summary>
        [Description("Pixel por hora.")]
        public double PPH
        {
            get { return pph; }
            set
            {
                Top = Top / pph * value;
                Height = Height / pph * value;
                pph = value;
            }
        }
        
        /// <summary>
        /// Hora inicial.
        /// </summary>
        public ushort InícioHora
        {
            get
            {
                return (ushort)(CalcularMinutosIniciais() / 60);
            }
        }

        public ushort InícioMinuto
        {
            get
            {
                return (ushort)(CalcularMinutosIniciais() % 60);
            }
        }

        private uint CalcularMinutosIniciais()
        {
            return (uint)((Top / pph * 60d) + minHora * 60);
        }

        /// <summary>
        /// Hora final.
        /// </summary>
        public ushort FinalHora
        {
            get
            {
                double minutos;
                uint minutosIniciais;

                minutosIniciais = CalcularMinutosIniciais();
                minutos = Height / pph * 60d;

                return (ushort)Math.Floor((minutosIniciais + minutos) / 60);
            }
        }

        /// <summary>
        /// Minuto da hora final.
        /// </summary>
        public ushort FinalMinuto
        {
            get
            {
                double minutos;
                uint minutosIniciais;

                minutosIniciais = CalcularMinutosIniciais();
                minutos = Height / pph * 60d;

                return (ushort)((minutosIniciais + minutos) % 60);
            }
        }

        #endregion

        private Horário()
        {
            InitializeComponent();
        }

        public Horário(double pph, ushort iniHora, ushort iniMin, ushort fimHora, ushort fimMin)
            : this()
        {
            this.pph = pph;

            DefinirHorário(iniHora, iniMin, fimHora, fimMin);

            SetStyle(ControlStyles.Selectable, true);
        }

        internal void DefinirHorário(ushort iniHora, ushort iniMin, ushort fimHora, ushort fimMin)
        {
            Top = (iniHora - minHora) * pph + iniMin / 60d * pph;

            DefinirHorário(fimHora, fimMin);
        }

        /// <summary>
        /// Define horário.
        /// </summary>
        /// <param name="fimHora">Hora final.</param>
        /// <param name="fimMin">Minuto da hora final.</param>
        internal void DefinirHorário(ushort fimHora, ushort fimMin)
        {
            uint minutos;

            minutos = (fimHora * 60u + fimMin) - CalcularMinutosIniciais();

            Height = minutos / 60d * pph;
        }

        /// <summary>
        /// Captura o ponto em que o usuário clicou para
        /// controlar a edição gráfica do horário.
        /// </summary>
        private void AoPressionarMouse(object sender, MouseEventArgs e)
        {
            Point p = ((Control)sender).PointToScreen(e.Location);

            origemY = p.Y;
        }

        /// <summary>
        /// Altera a hora final.
        /// </summary>
        private void AoMoverMouseFundo(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = painelFundo.PointToScreen(e.Location);

                this.Height += p.Y - origemY;
                origemY = p.Y;

                permitirEdição = false;
            }
        }

        /// <summary>
        /// Altera a hora inicial.
        /// </summary>
        private void AoMoverMouseTopo(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = painelTopo.PointToScreen(e.Location);
                int dy = p.Y - origemY;

                this.Height -= dy;
                this.Top += dy;
                origemY = p.Y;

                permitirEdição = false;
            }
        }

        private void AoMoverMouse(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = ((Control)sender).PointToScreen(e.Location);
                int dy = p.Y - origemY;

                this.Top += dy;
                origemY = p.Y;

                permitirEdição = false;

                AtualizarHorário(this, null);
            }
        }

        /// <summary>
        /// Atualiza exibição de horário.
        /// </summary>
        private void AtualizarHorário(object sender, EventArgs e)
        {
            lblHorário.Text = String.Format(
                "{0:00}:{1:00}-{2:00}:{3:00}",
                InícioHora, InícioMinuto,
                FinalHora, FinalMinuto);
        }

        /// <summary>
        /// Edita horário.
        /// </summary>
        private void EditarHorário(object sender, EventArgs e)
        {
            if (permitirEdição)
            {
                txtHorário.Text = lblHorário.Text;
                txtHorário.Visible = true;
                lblHorário.Visible = false;
                txtHorário.Focus();
                txtHorário.SelectAll();
            }
            else
            {
                permitirEdição = true;
                OnResize(new EventArgs());
            }
        }

        /// <summary>
        /// Finaliza edição de horário.
        /// </summary>
        private void FinalizarEdição(object sender, EventArgs e)
        {
            if (txtHorário.Text != lblHorário.Text)
            {
                // Interpreta o texto entrado.
                Regex regex = new Regex(@"[ ]*(?<iniHora>\d{1,2})[ ]*:[ ]*(?<iniMin>\d{1,2})-[ ]*(?<fimHora>\d{1,2})[ ]*:[ ]*(?<fimMin>\d{1,2})[ ]*");
                Match m = regex.Match(txtHorário.Text);

                if (!m.Success)
                    MessageBox.Show(
                        this.ParentForm,
                        "Não foi possível interpretar o horário entrado.",
                        "Interpretação de horário",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    DefinirHorário(
                        ushort.Parse(m.Groups["iniHora"].Value),
                        ushort.Parse(m.Groups["iniMin"].Value),
                        ushort.Parse(m.Groups["fimHora"].Value),
                        ushort.Parse(m.Groups["fimMin"].Value));
            }

            txtHorário.Visible = false;
            lblHorário.Visible = true;
        }

        /// <summary>
        /// Exclui o horário.
        /// </summary>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ((ControleHorário)Parent).Remover(this);
        }

        private void txtHorário_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    txtHorário.Text = lblHorário.Text;
                    txtHorário.Visible = false;
                    e.Handled = true;
                    break;

                case Keys.Enter:
                    txtHorário.Visible = false;
                    e.Handled = true;
                    break;
            }
        }

        public override string ToString()
        {
            return lblHorário.Text;
        }
    }
}
