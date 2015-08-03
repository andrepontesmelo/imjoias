using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    sealed partial class QuadroNavegação : UserControl, IAoMostrarBaseInferior
    {
        /// <summary>
        /// Determina se o quadro de navegação estava
        /// em exibição anteriormente.
        /// </summary>
        private bool exibindoAnteriomente = false;


        /// <summary>
        /// Constrói o quadro de navegação.
        /// </summary>
        public QuadroNavegação()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// Ocorre ao mudar visibilidade de alguma opção.
        ///// </summary>
        //private void AoMudarVisibilidade()
        //{
        //    int y = 27;
        //    bool visível = false;

        //    foreach (Control controle in quadro.Controls)
        //        if (controle.Visible)
        //        {
        //            controle.Top = y;
        //            y += controle.Height;
        //            visível = true;
        //        }

        //    Height = y;

        //    Visible = visível;

        //    if (exibindoAnteriomente != visível)
        //        ReajustarBarraEsquerda();

        //    exibindoAnteriomente = visível;
        //}

        /// <summary>
        /// Reajusta a barra esquerda, reposicionando os itens.
        /// </summary>
        private void ReajustarBarraEsquerda()
        {
            int dy = (Height + 7) * (Visible ? 1 : -1);

            foreach (Control controle in Parent.Controls)
                if (controle != this)
                    controle.Top += dy;
        }

        /// <summary>
        /// Ocorre ao exibir da primeira vez.
        /// </summary>
        public void AoExibirDaPrimeiraVez(BaseInferior baseInferior)
        {
        }

        /// <summary>
        /// Ocorre ao exibir a base inferior.
        /// </summary>
        /// <param name="baseInferior"></param>
        public void AoExibir(BaseInferior baseInferior)
        {
            //Visible = true;

            //opçãoVoltar.Visible = (baseInferior.baseAnterior != null);
            //opçãoAvançar.Visible = false;

            //AoMudarVisibilidade();

            Visible = (baseInferior.baseAnterior != null
                && baseInferior.baseAnterior != baseInferior);

            if (exibindoAnteriomente != Visible)
                ReajustarBarraEsquerda();

            exibindoAnteriomente = Visible;
        }

        /// <summary>
        /// Ocorre ao clicar em ir para a tela anterior.
        /// </summary>
        private void opçãoVoltar_Click(object sender, EventArgs e)
        {
            ((BaseInferior)(Parent.Parent)).Controlador.SubstituirBaseParaAnterior();
        }
    }
}
