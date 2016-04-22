using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apresentação.Formulários
{
    public sealed partial class NotificaçãoSimples : Apresentação.Formulários.Notificação
    {
        public NotificaçãoSimples(string título, string descrição)
        {
            InitializeComponent();

            Título = título;
            Descrição = descrição;
        }

        public string Descrição
        {
            get { return lblDescrição.Text; }
            set { lblDescrição.Text = value; }
        }

        public override string ToString()
        {
            return Descrição;
        }
    }
}

