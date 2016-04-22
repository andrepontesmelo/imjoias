using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;
using Apresentação.Formulários;

namespace Apresentação.Mercadoria
{
    public partial class CmbFaixa : ComboBox, IPósCargaSistema
    {
        public CmbFaixa()
        {
            InitializeComponent();
        }

        public void CarregarFaixas()
        {
            Items.Clear();

            foreach (string faixa in Faixa.Faixas)
                Items.Add(faixa);
        }

        public void AoCarregarCompletamente(Splash splash)
        {
            CarregarFaixas();
        }
    }
}
