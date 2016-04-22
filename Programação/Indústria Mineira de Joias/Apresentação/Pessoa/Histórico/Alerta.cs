using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresenta��o.Pessoa.Hist�rico
{
    public partial class Alerta : Apresenta��o.Formul�rios.JanelaExplicativa
    {
        private Entidades.Pessoa.ItemAlert�vel.TipoAlerta alerta;
        private Entidades.Pessoa.Hist�rico hist�rico;

        public Alerta(Entidades.Pessoa.Hist�rico hist�rico, Entidades.Pessoa.ItemAlert�vel.TipoAlerta alerta)
        {
            InitializeComponent();

            this.alerta = alerta;
            this.hist�rico = hist�rico;

            chkDesligar.Visible = Entidades.Privil�gio.Permiss�oFuncion�rio.ValidarPermiss�o(Entidades.Privil�gio.Permiss�o.CadastroEditar);

            txtPessoa.Text = hist�rico.Pessoa.Nome;
            txtDigitadoPor.Text = hist�rico.DigitadoPor.Nome;
            txtTexto.Text = hist�rico.Texto;
            txtData.Text = hist�rico.Data.ToLongDateString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            timer.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkDesligar.Checked && chkDesligar.Visible)
            {
                switch (alerta)
                {
                    case ItemAlert�vel.TipoAlerta.Pedido:
                        hist�rico.AlertarPedido = false;
                        break;

                    case ItemAlert�vel.TipoAlerta.Correio:
                        hist�rico.AlertarCorreio = false;
                        break;

                    case ItemAlert�vel.TipoAlerta.Sa�da:
                        hist�rico.AlertarSa�da = false;
                        break;

                    case ItemAlert�vel.TipoAlerta.Venda:
                        hist�rico.AlertarVenda = false;
                        break;

                    default:
                        throw new NotSupportedException();
                }

                hist�rico.Atualizar();
            }
        }

        public static void Mostrar(Entidades.Pessoa.Hist�rico hist�rico, Entidades.Pessoa.ItemAlert�vel.TipoAlerta alerta)
        {
            using (Alerta dlg = new Alerta(hist�rico, alerta))
                dlg.ShowDialog();
        }

        private void Alerta_Shown(object sender, EventArgs e)
        {
            Neg�cio.Beepador.Alerta();
        }
    }
}

