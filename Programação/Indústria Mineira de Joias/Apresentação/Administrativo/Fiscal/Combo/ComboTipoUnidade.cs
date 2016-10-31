﻿using Entidades.Fiscal.Tipo;

namespace Apresentação.Fiscal.Combobox
{
    public partial class ComboTipoUnidade : System.Windows.Forms.ComboBox
    {
        public ComboTipoUnidade()
        {
            InitializeComponent();
            Items.AddRange(new string[] { "Peça", "Gramas" });
        }

        public TipoUnidade? Seleção { get; set; }
    }
}
