using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Pessoa.Horário
{
    /// <summary>
    /// Controla os horário de um dia,
    /// permitindo inserção, remoção, alteração
    /// e união.
    /// </summary>
    partial class ControleHorário : UserControl
    {
        /// <summary>
        /// Hora inicial para exibição.
        /// </summary>
        private ushort horaInicial = 07;

        /// <summary>
        /// Hora final para exibição.
        /// </summary>
        private ushort horaFinal = 19;

        /// <summary>
        /// Lista de horários.
        /// </summary>
        private List<Horário> horários = new List<Horário>();

        #region Propriedades

        /// <summary>
        /// Hora inicial de exibição.
        /// </summary>
        [DefaultValue((ushort)07)]
        public ushort HoraInicial
        {
            get { return horaInicial; }
            set { horaInicial = value; }
        }

        /// <summary>
        /// Hora final de exibição.
        /// </summary>
        [DefaultValue((ushort)19)]
        public ushort HoraFinal
        {
            get { return horaFinal; }
            set { horaFinal = value; }
        }

        /// <summary>
        /// Lista de horários.
        /// </summary>
        public List<Horário> Horários
        {
            get { return horários; }
        }

        #endregion

        private EventHandler aoAlterarHorário;

        public ControleHorário()
        {
            InitializeComponent();

            aoAlterarHorário = new EventHandler(AoAlterarHorário);
        }

        /// <summary>
        /// Desenha a separação horária.
        /// </summary>
        private void ControleHorário_Paint(object sender, PaintEventArgs e)
        {
            float passo;

            passo = ClientSize.Height / (float)(horaFinal - horaInicial + 1);

            for (float i = 0; i < ClientSize.Height; i += passo)
                e.Graphics.DrawLine(
                    new Pen(SystemColors.Highlight),
                    0f, i, ClientRectangle.Right, i);
        }

        /// <summary>
        /// Constrói um novo horário.
        /// </summary>
        private void ControleHorário_MouseClick(object sender, MouseEventArgs e)
        {
            if (!DesignMode)
            {
                ushort iniHora;
                ushort iniMin;
                double pph = CalcularPPH();
                Horário horário;

                iniHora = (ushort)(e.Y / pph + this.horaInicial);
                iniMin = (ushort)(((int)(e.Y / pph * 60)) % 60);
                horário = new Horário(pph, iniHora, iniMin, (ushort)(6 + iniHora), 0);

                Adicionar(horário);

                horário.Focus();
            }
        }

        /// <summary>
        /// Calcula pixels por hora.
        /// </summary>
        private double CalcularPPH()
        {
            double pph = (ClientSize.Height / (double)(horaFinal - horaInicial + 1d));

            return pph;
        }

        /// <summary>
        /// Adiciona um novo horário.
        /// </summary>
        public void Adicionar(ushort iniHora, ushort iniMin, ushort fimHora, ushort fimMin)
        {
            Horário horário;

            horário = new Horário(CalcularPPH(), iniHora, iniMin, fimHora, fimMin);

            Adicionar(horário);
        }
        
        /// <summary>
        /// Adiciona um novo horário.
        /// </summary>
        /// <param name="horário">Horário a ser adicionado.</param>
        private void Adicionar(Horário horário)
        {
            // Configurar controle.
            horário.Visible = true;
            Posicionar(horário);
            horário.Width = ClientRectangle.Width;
            horário.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // Adicionar controle.
            horários.Add(horário);
            Controls.Add(horário);

            // Observar controle.
            horário.Resize += aoAlterarHorário;
            horário.Move += aoAlterarHorário;
        }

        /// <summary>
        /// Remove um horário da lista.
        /// </summary>
        /// <param name="horário">Horário a ser removido.</param>
        internal void Remover(Horário horário)
        {
            if (!DesignMode)
            {
                Controls.Remove(horário);
                horários.Remove(horário);

                horário.Resize -= aoAlterarHorário;
                horário.Move -= aoAlterarHorário;
            }
        }

        /// <summary>
        /// Posiciona horário no controle.
        /// </summary>
        /// <param name="horário">Horário a ser posicionado.</param>
        private void Posicionar(Horário horário)
        {
            double pph = CalcularPPH();

            if (horário.PPH != pph)
                horário.PPH = pph;
        }

        /// <summary>
        /// Ocorre ao alterar o horário.
        /// </summary>
        private void AoAlterarHorário(object sender, EventArgs e)
        {
            for (int i = 1; i < horários.Count; i++)
                if (horários[i -1 ].PermitirEdição && horários[i].PermitirEdição && horários[i].Top < horários[i - 1].Bottom)
                {
                    if (horários[i].Bottom > horários[i - 1].Bottom)
                    {
                        // Unir os dois horários.
                        Horário união, aux;

                        união = horários[i - 1];
                        aux = horários[i];

                        Remover(aux);

                        união.DefinirHorário(aux.FinalHora, aux.FinalMinuto);
                    }
                    else
                        // Excluir o horário sobreposto.
                        Remover(horários[i]);

                    i--;
                }
        }

        /// <summary>
        /// Adequa todos os horários.
        /// </summary>
        private void ControleHorário_Resize(object sender, EventArgs e)
        {
            foreach (Horário horário in horários)
            {
                horário.Resize -= aoAlterarHorário;
                Posicionar(horário);
                horário.Resize += aoAlterarHorário;
            }
        }

        /// <summary>
        /// Limpa o controle.
        /// </summary>
        public void Limpar()
        {
            foreach (Horário horário in new List<Horário>(horários))
                Remover(horário);
        }
    }
}
