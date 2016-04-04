using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    /// <summary>
    /// Controle para edição e exibição de avaliação,
    /// exibida de zero a cinco estrelas.
    /// </summary>
    public partial class Avaliador : UserControl
    {
        /// <summary>
        /// Vetor com as estrelas.
        /// </summary>
        private PictureBox[] pics;

        /// <summary>
        /// Nota de avaliação.
        /// </summary>
        private byte? nota;

        /// <summary>
        /// Determina se o usuário está editando a avaliação.
        /// Neste caso, estrelas cinzas são exibidas para
        /// permitir o clique.
        /// </summary>
        private bool editando;

        /// <summary>
        /// Ocorre ao alterar a avaliação.
        /// </summary>
        [Description("Ocorre ao alterar a avaliação.")]
        public event EventHandler AvaliaçãoAlterada;


        /// <summary>
        /// Constrói o controle avaliador.
        /// </summary>
        public Avaliador()
        {
            InitializeComponent();

            pics = new PictureBox[] {
                pic1, pic2, pic3, pic4, pic5 };
        }

        /// <summary>
        /// Nota de avaliação.
        /// </summary>
        [DefaultValue(null)]
        public byte? Nota
        {
            get { return nota; }
            set
            {
                if (value.HasValue)
                {
                    if (value.Value > 5)
                        throw new ArgumentException("Nota da avaliação tem que ser positivo e menor ou igual a 5.");

                    nota = value;

                    for (byte i = 0; i < nota.Value; i++)
                        pics[i].Image = Resource.estrela;

                    if (editando)
                        for (byte i = nota.Value; i < 5; i++)
                            pics[i].Image = Resource.estrelaCinza;
                }
                else if (editando)
                    for (byte i = 0; i < 5; i++)
                        pics[i].Image = Resource.estrelaCinza;
                else
                {
                    Image bmp = Resource.dívida;

                    for (byte i = 0; i < 5; i++)
                        pics[i].Image = bmp;
                }
            }
        }

        /// <summary>
        /// Ocorre quando o mouse entra na parte visível do controle.
        /// </summary>
        private void Avaliador_MouseEnter(object sender, EventArgs e)
        {
            IniciarEdição();
        }

        /// <summary>
        /// Ocorre quando o mouse deixa a parte visível do controle.
        /// </summary>
        private void Avaliador_MouseLeave(object sender, EventArgs e)
        {
            FinalizarEdição();
        }

        #region Atribuição de valores por clique.

        private void pic1_Click(object sender, EventArgs e)
        {
            if (nota != 1)
                Nota = 1;
            else
                Nota = 0;

            if (AvaliaçãoAlterada != null)
                AvaliaçãoAlterada(this, new EventArgs());
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            Nota = 2;

            if (AvaliaçãoAlterada != null)
                AvaliaçãoAlterada(this, new EventArgs());
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            Nota = 3;

            if (AvaliaçãoAlterada != null)
                AvaliaçãoAlterada(this, new EventArgs());
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            Nota = 4;

            if (AvaliaçãoAlterada != null)
                AvaliaçãoAlterada(this, new EventArgs());
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            Nota = 5;

            if (AvaliaçãoAlterada != null)
                AvaliaçãoAlterada(this, new EventArgs());
        }

        #endregion

        /// <summary>
        /// Ocorre ao carregar o controle.
        /// </summary>
        private void Avaliador_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                IniciarEdição();
        }

        /// <summary>
        /// Inicia edição, mostrando estrelas cinzas.
        /// </summary>
        private void IniciarEdição()
        {
            editando = true;

            for (byte i = nota.HasValue ? nota.Value : (byte)0; i < 5; i++)
                pics[i].Image = Resource.estrelaCinza;
        }

        /// <summary>
        /// Finaliza edição, escondendo estrelas cinzas.
        /// </summary>
        private void FinalizarEdição()
        {
            editando = false;

            for (byte i = nota.HasValue ? nota.Value : (byte)0; i < 5; i++)
                pics[i].Image = null;
        }
    }
}
