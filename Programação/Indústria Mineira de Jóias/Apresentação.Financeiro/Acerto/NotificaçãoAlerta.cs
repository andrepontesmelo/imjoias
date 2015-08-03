using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Acerto;

namespace Apresentação.Financeiro.Acerto
{
    /// <summary>
    /// Notificação de alerta a respeito de um acerto.
    /// </summary>
    public sealed partial class NotificaçãoAlerta : Apresentação.Formulários.Notificação
    {
        public NotificaçãoAlerta(Alerta alerta)
        {
            InitializeComponent();

            lblNome.Text = alerta.Acerto.Pessoa.Nome;
            lblDescrição.Text = alerta.Descrição;
        }
    }
}

