using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades.Pessoa;

namespace Apresentação.Pessoa.Histórico
{
    public partial class Alerta : Apresentação.Formulários.JanelaExplicativa
    {
        private Entidades.Pessoa.ItemAlertável.TipoAlerta alerta;
        private Entidades.Pessoa.Histórico histórico;

        public Alerta(Entidades.Pessoa.Histórico histórico, Entidades.Pessoa.ItemAlertável.TipoAlerta alerta)
        {
            InitializeComponent();

            this.alerta = alerta;
            this.histórico = histórico;

            chkDesligar.Visible = Entidades.Privilégio.PermissãoFuncionário.ValidarPermissão(Entidades.Privilégio.Permissão.CadastroEditar);

            txtPessoa.Text = histórico.Pessoa.Nome;
            txtDigitadoPor.Text = histórico.DigitadoPor.Nome;
            txtTexto.Text = histórico.Texto;
            txtData.Text = histórico.Data.ToLongDateString();
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
                    case ItemAlertável.TipoAlerta.Pedido:
                        histórico.AlertarPedido = false;
                        break;

                    case ItemAlertável.TipoAlerta.Correio:
                        histórico.AlertarCorreio = false;
                        break;

                    case ItemAlertável.TipoAlerta.Saída:
                        histórico.AlertarSaída = false;
                        break;

                    case ItemAlertável.TipoAlerta.Venda:
                        histórico.AlertarVenda = false;
                        break;

                    default:
                        throw new NotSupportedException();
                }

                histórico.Atualizar();
            }
        }

        public static void Mostrar(Entidades.Pessoa.Histórico histórico, Entidades.Pessoa.ItemAlertável.TipoAlerta alerta)
        {
            using (Alerta dlg = new Alerta(histórico, alerta))
                dlg.ShowDialog();
        }

        private void Alerta_Shown(object sender, EventArgs e)
        {
            Negócio.Beepador.Alerta();
        }
    }
}

