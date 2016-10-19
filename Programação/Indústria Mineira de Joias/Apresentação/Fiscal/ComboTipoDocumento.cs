﻿using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class ComboTipoDocumento : ComboBox
    {
        public ComboTipoDocumento()
        {
            InitializeComponent();
        }

        public void Carregar(bool entrada)
        {
            IEnumerable<TipoDocumento> itens;

            if (entrada)
                itens = TipoDocumento.TiposEntrada;
            else
                itens = TipoDocumento.TiposSaída;

            Items.AddRange(itens.ToArray<TipoDocumento>());
        }
    }
}
