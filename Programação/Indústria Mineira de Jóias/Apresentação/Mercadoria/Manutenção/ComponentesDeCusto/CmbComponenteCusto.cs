using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Entidades.Mercadoria;
using System.Collections;

namespace Apresentação.Mercadoria.Manutenção.ComponentesDeCusto
{
    public partial class CmbComponenteCusto : ComboBox
    {
        public CmbComponenteCusto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obtem o item selecionado. Pode ser null.
        /// </summary>
        public ComponenteCusto Componente
        {
            get
            {
                return SelectedItem as ComponenteCusto;
            }

            set
            {
                SelectedItem = value;
            }
        }

        /// <summary>
        /// Preenche os componentes
        /// </summary>
        public void Carregar()
        {
            AutoCompleteCustomSource.Clear();
            List<ComponenteCusto> lista =  ComponenteCusto.ObterComponentes();
            
            foreach (ComponenteCusto c in lista)
            {
                AutoCompleteCustomSource.Add(c.ToString());
                Items.Add(c);
            }
        }

        private void ComboBoxComponenteCusto_Validating(object sender, CancelEventArgs e)
        {
            // Cancela texto digitado for inválido. Mas texto nenhum é válido.
            e.Cancel = (SelectedItem == null) && (Text.Length == 0);
        }
    }
}
