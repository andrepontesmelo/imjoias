using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Mercadoria
{
    public class TxtPeso : AMS.TextBox.NumericTextBox
    {
        public TxtPeso() 
        {
            KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPeso_KeyPress);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '.':
                case ',':
                    SelectedText = Entidades.Configuração.DadosGlobais.Instância.Cultura.NumberFormat.CurrencyDecimalSeparator;
                    e.Handled = true;
                    break;
            }
        }
    }
}
