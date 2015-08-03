using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Financeiro
{
    /// <summary>
    /// Balão que informa ao usuário que a mercadoria entrada
    /// não condiz com o relacionamento de saída.
    /// </summary>
    public partial class BalãoMercadoriaInconsistente : Balloon.NET.BalloonWindow
    {
        public BalãoMercadoriaInconsistente(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            InitializeComponent();

            lblRef.Text = mercadoria.Referência;
            lblPeso.Text = mercadoria.PesoFormatado;
        }
    }
}

