using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Usuário.Financeiro
{
    public partial class NotificaçãoCotação : Apresentação.Formulários.Notificação
    {
        /// <summary>
        /// Constrói uma janela de notificação de cotação do ouro.
        /// </summary>
        /// <param name="cotação">Cotação atual.</param>
        public NotificaçãoCotação(Entidades.Cotação cotação)
        {
            InitializeComponent();

            Entidades.Pessoa.Funcionário funcionário;

            funcionário = cotação.Funcionário;

            this.lblResponsável.Text = funcionário.Nome;
            this.lblData.Text        = cotação.Data.ToString();
            this.lblCotação.Text     = cotação.Valor.ToString("c");

            AtualizarImagem(cotação);
        }

        /// <summary>
        /// Atualiza imagem, conforme mudança da cotação.
        /// </summary>
        /// <param name="cotação">Cotação atual.</param>
        private void AtualizarImagem(Entidades.Cotação cotação)
        {
            Entidades.Cotação[] cotações;

            cotações = Entidades.Cotação.ObterListaCotaçõesAnteriores(cotação.Moeda, 2);

            if (cotações.Length > 1)
            {
                Entidades.Cotação anterior;

                anterior = cotações[1];

                if (cotação.Valor > anterior.Valor)
                    imagem.Image = imageList.Images["aumento"];

                else if (cotação.Valor < anterior.Valor)
                    imagem.Image = imageList.Images["queda"];
            }
        }
    }
}
