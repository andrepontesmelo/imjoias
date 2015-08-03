using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;

namespace Apresenta��o.Financeiro.Acerto
{
    /// <summary>
    /// Notifica��o de alerta a respeito de um acerto.
    /// </summary>
    public sealed partial class Notifica��oAlerta : Apresenta��o.Formul�rios.Notifica��o
    {
        public Notifica��oAlerta(Alerta alerta)
        {
            InitializeComponent();

            lblNome.Text = alerta.Acerto.Pessoa.Nome;
            lblDescri��o.Text = alerta.Descri��o;
        }
    }
}

