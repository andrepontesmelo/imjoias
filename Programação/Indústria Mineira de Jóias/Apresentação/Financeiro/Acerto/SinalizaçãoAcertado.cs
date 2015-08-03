using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Apresentação.Formulários;

namespace Apresentação.Financeiro.Acerto
{
    public partial class SinalizaçãoAcertado : QuadroSimples
    {
        private SinalizaçãoAcertado()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label3.Visible = true;
            timer.Enabled = false;
        }

        private void SinalizaçãoAcertado_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            Parent.Controls.Remove(this);
            Dispose();
        }

        public static void Sinalizar(Control hospedeiro)
        {
            SinalizaçãoAcertado sinalização = new SinalizaçãoAcertado();

            sinalização.Location = new Point((hospedeiro.ClientSize.Width - sinalização.Width) / 2, (hospedeiro.ClientSize.Height - sinalização.Height) / 2);

            hospedeiro.SuspendLayout();
            hospedeiro.Controls.Add(sinalização);
            hospedeiro.Visible = true;
            sinalização.BringToFront();
            hospedeiro.ResumeLayout();

            hospedeiro.Resize += new EventHandler(sinalização.Reposicionar);
        }

        private void Reposicionar(object sender, EventArgs e)
        {
            try
            {
                Location = new Point((Parent.ClientSize.Width - Width) / 2, (Parent.ClientSize.Height - Height) / 2);
            } catch(Exception)
            {}
            this.BringToFront();
        }
    }
}
