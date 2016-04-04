using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Álbum.Edição.Impressão
{
    public partial class VisualizarPáginaVirtual : JanelaExplicativa
    {
        public VisualizarPáginaVirtual(Entidades.Álbum.Álbum álbum)
        {
            InitializeComponent();

            páginaVirtual.Fotos = álbum.Fotos.ToArray();
        }
    }
}