using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Fiscal
{
    public partial class VisualizadorPDF : Apresentação.Formulários.JanelaExplicativa
    {
        public VisualizadorPDF()
        {
            InitializeComponent();
            ((AcroPDFLib.IAcroAXDocShim)axAcroPDF.GetOcx()).LoadFile(@"C:\Users\Andre\Desktop\Fiscal\owncloud-fiscal\Danfes e arquivos nfe apartir de abril 2015\Carla Aparecida de Queiros Braga\carla aparecida de queiros braga 02062016 000352.pdf");
        }
    }
}
