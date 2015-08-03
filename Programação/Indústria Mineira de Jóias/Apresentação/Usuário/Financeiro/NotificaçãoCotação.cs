using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Usu�rio.Financeiro
{
    public partial class Notifica��oCota��o : Apresenta��o.Formul�rios.Notifica��o
    {
        /// <summary>
        /// Constr�i uma janela de notifica��o de cota��o do ouro.
        /// </summary>
        /// <param name="cota��o">Cota��o atual.</param>
        public Notifica��oCota��o(Entidades.Cota��o cota��o)
        {
            InitializeComponent();

            Entidades.Pessoa.Funcion�rio funcion�rio;

            funcion�rio = cota��o.Funcion�rio;

            this.lblRespons�vel.Text = funcion�rio.Nome;
            this.lblData.Text        = cota��o.Data.ToString();
            this.lblCota��o.Text     = cota��o.Valor.ToString("c");

            AtualizarImagem(cota��o);
        }

        /// <summary>
        /// Atualiza imagem, conforme mudan�a da cota��o.
        /// </summary>
        /// <param name="cota��o">Cota��o atual.</param>
        private void AtualizarImagem(Entidades.Cota��o cota��o)
        {
            Entidades.Cota��o[] cota��es;

            cota��es = Entidades.Cota��o.ObterListaCota��esAnteriores(cota��o.Moeda, 2);

            if (cota��es.Length > 1)
            {
                Entidades.Cota��o anterior;

                anterior = cota��es[1];

                if (cota��o.Valor > anterior.Valor)
                    imagem.Image = imageList.Images["aumento"];

                else if (cota��o.Valor < anterior.Valor)
                    imagem.Image = imageList.Images["queda"];
            }
        }
    }
}
