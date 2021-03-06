﻿using Apresentação.Formulário;
using Entidades.Fiscal.Tipo;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Apresentação.Fiscal.Combobox
{
    public partial class ComboTipoDocumento : ComboRígido
    {
        public ComboTipoDocumento()
        {
            InitializeComponent();
        }

        public TipoDocumento Seleção
        {
            set
            {
                SelectedItem = value;
            }
            get
            {
                return SelectedItem as TipoDocumento;
            }
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

        protected override bool SeleçãoNula => Seleção == null;
    }
}
