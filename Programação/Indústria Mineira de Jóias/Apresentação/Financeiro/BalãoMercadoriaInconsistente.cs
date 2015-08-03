using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresenta��o.Financeiro
{
    /// <summary>
    /// Bal�o que informa ao usu�rio que a mercadoria entrada
    /// n�o condiz com o relacionamento de sa�da.
    /// </summary>
    public partial class Bal�oMercadoriaInconsistente : Balloon.NET.BalloonWindow
    {
        public Bal�oMercadoriaInconsistente(Entidades.Mercadoria.Mercadoria mercadoria)
        {
            InitializeComponent();

            lblRef.Text = mercadoria.Refer�ncia;
            lblPeso.Text = mercadoria.PesoFormatado;
        }
    }
}

