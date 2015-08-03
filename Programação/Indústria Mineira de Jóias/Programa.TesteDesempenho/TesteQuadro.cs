using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Programa.TesteDesempenho
{
    public partial class TesteQuadro : Apresentação.Formulários.BaseInferior
    {
        private DateTime tempo = DateTime.Now;

        private string Momento
        {
            get
            {
                TimeSpan dif = DateTime.Now - tempo;

                return dif.Milliseconds.ToString();
            }
        }

        public TesteQuadro()
        {
            InitializeComponent();

            Console.WriteLine("Construído em {0}", Momento);
        }

        private void quadroMercadoria1_EventoAdicionou(Entidades.Mercadoria.Mercadoria mercadoria, double quantidade)
        {
            Console.WriteLine("Adicionado em: {0}", Momento);
        }

        private void quadroMercadoria1_EventoReferênciaEscolhida(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            Console.WriteLine("Escolhido em: {0}", Momento);
        }
    }
}

